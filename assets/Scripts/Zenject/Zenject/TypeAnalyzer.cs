using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ModestTree;

namespace Zenject;

public static class TypeAnalyzer
{
	private static Dictionary<Type, ZenjectTypeInfo> _typeInfo = new Dictionary<Type, ZenjectTypeInfo>();

	private static List<MethodInfo> _methodBuffer = new List<MethodInfo>();

	public static ZenjectTypeInfo GetInfo<T>()
	{
		return GetInfo(typeof(T));
	}

	public static bool ShouldAllowDuringValidation<T>()
	{
		return ShouldAllowDuringValidation(typeof(T));
	}

	public static bool ShouldAllowDuringValidation(Type type)
	{
		return false;
	}

	public static ZenjectTypeInfo GetInfo(Type type)
	{
		Assert.That(!type.IsAbstract(), "Tried to analyze abstract type '{0}'.  This is not currently allowed.", type);
		if (!_typeInfo.TryGetValue(type, out var value))
		{
			value = CreateTypeInfo(type);
			_typeInfo.Add(type, value);
		}
		return value;
	}

	private static ZenjectTypeInfo CreateTypeInfo(Type type)
	{
		ConstructorInfo injectConstructor = GetInjectConstructor(type);
		return new ZenjectTypeInfo(type, GetPostInjectMethods(type), injectConstructor, GetFieldInjectables(type).ToList(), GetPropertyInjectables(type).ToList(), GetConstructorInjectables(type, injectConstructor).ToList());
	}

	private static IEnumerable<InjectableInfo> GetConstructorInjectables(Type parentType, ConstructorInfo constructorInfo)
	{
		if (constructorInfo == null)
		{
			return Enumerable.Empty<InjectableInfo>();
		}
		return from paramInfo in constructorInfo.GetParameters()
			select CreateInjectableInfoForParam(parentType, paramInfo);
	}

	private static InjectableInfo CreateInjectableInfoForParam(Type parentType, ParameterInfo paramInfo)
	{
		List<InjectAttributeBase> list = paramInfo.AllAttributes<InjectAttributeBase>().ToList();
		Assert.That(list.Count <= 1, "Found multiple 'Inject' attributes on type parameter '{0}' of type '{1}'.  Parameter should only have one", paramInfo.Name, parentType);
		InjectAttributeBase injectAttributeBase = list.SingleOrDefault();
		object identifier = null;
		bool flag = false;
		InjectSources sourceType = InjectSources.Any;
		if (injectAttributeBase != null)
		{
			identifier = injectAttributeBase.Id;
			flag = injectAttributeBase.Optional;
			sourceType = injectAttributeBase.Source;
		}
		bool flag2 = (paramInfo.Attributes & ParameterAttributes.HasDefault) == ParameterAttributes.HasDefault;
		return new InjectableInfo(flag2 | flag, identifier, paramInfo.Name, paramInfo.ParameterType, parentType, null, flag2 ? paramInfo.DefaultValue : null, sourceType);
	}

	private static List<PostInjectableInfo> GetPostInjectMethods(Type type)
	{
		_methodBuffer.Clear();
		using (IEnumerator<MethodInfo> enumerator = type.GetAllInstanceMethods().GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.GetCustomAttributes(typeof(InjectAttribute), inherit: false).Any())
				{
					_methodBuffer.Add(enumerator.Current);
				}
			}
		}
		List<Type> heirarchyList = type.Yield().Concat(type.GetParentTypes()).Reverse()
			.ToList();
		IOrderedEnumerable<MethodInfo> orderedEnumerable = _methodBuffer.OrderBy((MethodInfo x) => heirarchyList.IndexOf(x.DeclaringType));
		List<PostInjectableInfo> list = new List<PostInjectableInfo>();
		foreach (MethodInfo item in orderedEnumerable)
		{
			ParameterInfo[] parameters = item.GetParameters();
			InjectAttribute injectAttribute = item.AllAttributes<InjectAttribute>().Single();
			Assert.That(!injectAttribute.Optional && injectAttribute.Id == null && injectAttribute.Source == InjectSources.Any, "Parameters of InjectAttribute do not apply to constructors and methods");
			list.Add(new PostInjectableInfo(item, parameters.Select((ParameterInfo paramInfo) => CreateInjectableInfoForParam(type, paramInfo)).ToList()));
		}
		return list;
	}

	private static IEnumerable<InjectableInfo> GetPropertyInjectables(Type type)
	{
		IEnumerable<PropertyInfo> enumerable = from x in type.GetAllInstanceProperties()
			where x.HasAttribute(typeof(InjectAttributeBase))
			select x;
		foreach (PropertyInfo item in enumerable)
		{
			yield return CreateForMember(item, type);
		}
	}

	private static IEnumerable<InjectableInfo> GetFieldInjectables(Type type)
	{
		IEnumerable<FieldInfo> enumerable = from x in type.GetAllInstanceFields()
			where x.HasAttribute(typeof(InjectAttributeBase))
			select x;
		foreach (FieldInfo item in enumerable)
		{
			yield return CreateForMember(item, type);
		}
	}

	private static IEnumerable<FieldInfo> GetAllFields(Type t, BindingFlags flags)
	{
		if (t == null)
		{
			return Enumerable.Empty<FieldInfo>();
		}
		return t.GetFields(flags).Concat(GetAllFields(t.BaseType, flags)).Distinct();
	}

	private static Action<object, object> GetOnlyPropertySetter(Type parentType, string propertyName)
	{
		Assert.That(parentType != null);
		Assert.That(!string.IsNullOrEmpty(propertyName));
		List<FieldInfo> source = GetAllFields(parentType, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy).ToList();
		List<FieldInfo> writeableFields = source.Where((FieldInfo f) => f.Name == $"<{propertyName}>k__BackingField").ToList();
		if (!writeableFields.Any())
		{
			throw new ZenjectException(string.Format("Can't find backing field for get only property {0} on {1}.\r\n{2}", propertyName, parentType.FullName, string.Join(";", source.Select((FieldInfo f) => f.Name).ToArray())));
		}
		return (object injectable, object value) =>
		{
			writeableFields.ForEach((FieldInfo f) =>
			{
				f.SetValue(injectable, value);
			});
		};
	}

	private static InjectableInfo CreateForMember(MemberInfo memInfo, Type parentType)
	{
		List<InjectAttributeBase> list = memInfo.AllAttributes<InjectAttributeBase>().ToList();
		Assert.That(list.Count <= 1, "Found multiple 'Inject' attributes on type field '{0}' of type '{1}'.  Field should only container one Inject attribute", memInfo.Name, parentType);
		InjectAttributeBase injectAttributeBase = list.SingleOrDefault();
		object identifier = null;
		bool optional = false;
		InjectSources sourceType = InjectSources.Any;
		if (injectAttributeBase != null)
		{
			identifier = injectAttributeBase.Id;
			optional = injectAttributeBase.Optional;
			sourceType = injectAttributeBase.Source;
		}
		Action<object, object> setter;
		Type memberType;
		if (memInfo is FieldInfo)
		{
			FieldInfo fieldInfo = (FieldInfo)memInfo;
			setter = (object injectable, object value) =>
			{
				fieldInfo.SetValue(injectable, value);
			};
			memberType = fieldInfo.FieldType;
		}
		else
		{
			Assert.That(memInfo is PropertyInfo);
			PropertyInfo propInfo = (PropertyInfo)memInfo;
			memberType = propInfo.PropertyType;
			setter = ((!propInfo.CanWrite) ? GetOnlyPropertySetter(parentType, propInfo.Name) : ((Action<object, object>)((object injectable, object value) =>
			{
				propInfo.SetValue(injectable, value, null);
			})));
		}
		return new InjectableInfo(optional, identifier, memInfo.Name, memberType, parentType, setter, null, sourceType);
	}

	private static ConstructorInfo GetInjectConstructor(Type parentType)
	{
		ConstructorInfo[] array = parentType.Constructors();
		if (array.IsEmpty())
		{
			return null;
		}
		if (array.HasMoreThan(1))
		{
			ConstructorInfo constructorInfo = array.Where((ConstructorInfo c) => c.HasAttribute<InjectAttribute>()).SingleOrDefault();
			if (constructorInfo != null)
			{
				return constructorInfo;
			}
			ConstructorInfo constructorInfo2 = array.Where((ConstructorInfo x) => !x.IsPrivate).OnlyOrDefault();
			if (constructorInfo2 != null)
			{
				return constructorInfo2;
			}
			return array.OrderBy((ConstructorInfo x) => x.GetParameters().Count()).First();
		}
		return array[0];
	}
}
