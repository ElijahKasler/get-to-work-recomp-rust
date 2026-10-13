using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ModestTree;

public static class TypeExtensions
{
	private static readonly Dictionary<Type, string> _prettyNameCache = new Dictionary<Type, string>();

	private static readonly Dictionary<Type, bool> _isClosedGenericType = new Dictionary<Type, bool>();

	private static readonly Dictionary<Type, bool> _isOpenGenericType = new Dictionary<Type, bool>();

	private static readonly Dictionary<Type, bool> _isValueType = new Dictionary<Type, bool>();

	private static readonly Dictionary<Type, Type[]> _interfaces = new Dictionary<Type, Type[]>();

	public static bool DerivesFrom<T>(this Type a)
	{
		return a.DerivesFrom(typeof(T));
	}

	public static bool DerivesFrom(this Type a, Type b)
	{
		if (b != a)
		{
			return a.DerivesFromOrEqual(b);
		}
		return false;
	}

	public static bool DerivesFromOrEqual<T>(this Type a)
	{
		return a.DerivesFromOrEqual(typeof(T));
	}

	public static bool DerivesFromOrEqual(this Type a, Type b)
	{
		if (!(b == a))
		{
			return b.IsAssignableFrom(a);
		}
		return true;
	}

	public static bool IsAssignableToGenericType(Type givenType, Type genericType)
	{
		Type[] array = givenType.Interfaces();
		foreach (Type type in array)
		{
			if (type.IsGenericType && type.GetGenericTypeDefinition() == genericType)
			{
				return true;
			}
		}
		if (givenType.IsGenericType && givenType.GetGenericTypeDefinition() == genericType)
		{
			return true;
		}
		Type baseType = givenType.BaseType;
		if (baseType == null)
		{
			return false;
		}
		return IsAssignableToGenericType(baseType, genericType);
	}

	public static bool IsEnum(this Type type)
	{
		return type.IsEnum;
	}

	public static bool IsValueType(this Type type)
	{
		if (!_isValueType.TryGetValue(type, out var value))
		{
			value = type.IsValueType;
			_isValueType[type] = value;
		}
		return value;
	}

	public static MethodInfo[] DeclaredInstanceMethods(this Type type)
	{
		return type.GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
	}

	public static PropertyInfo[] DeclaredInstanceProperties(this Type type)
	{
		return type.GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
	}

	public static FieldInfo[] DeclaredInstanceFields(this Type type)
	{
		return type.GetFields(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
	}

	public static Type BaseType(this Type type)
	{
		return type.BaseType;
	}

	public static bool IsGenericType(this Type type)
	{
		return type.IsGenericType;
	}

	public static bool IsGenericTypeDefinition(this Type type)
	{
		return type.IsGenericTypeDefinition;
	}

	public static bool IsPrimitive(this Type type)
	{
		return type.IsPrimitive;
	}

	public static bool IsInterface(this Type type)
	{
		return type.IsInterface;
	}

	public static bool IsAbstract(this Type type)
	{
		return type.IsAbstract;
	}

	public static MethodInfo Method(this Delegate del)
	{
		return del.Method;
	}

	public static Type[] GenericArguments(this Type type)
	{
		return type.GetGenericArguments();
	}

	public static Type[] Interfaces(this Type type)
	{
		if (!_interfaces.TryGetValue(type, out var value))
		{
			value = type.GetInterfaces();
			_interfaces.Add(type, value);
		}
		return value;
	}

	public static ConstructorInfo[] Constructors(this Type type)
	{
		return type.GetConstructors(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
	}

	public static object GetDefaultValue(this Type type)
	{
		if (type.IsValueType())
		{
			return Activator.CreateInstance(type);
		}
		return null;
	}

	public static string GetSimpleName(this Type type)
	{
		string name = type.Name;
		int num = name.IndexOf("`");
		if (num == -1)
		{
			return name;
		}
		return name.Substring(0, num);
	}

	public static IEnumerable<Type> GetParentTypes(this Type type)
	{
		if (type == null || type.BaseType() == null || type == typeof(object) || type.BaseType() == typeof(object))
		{
			yield break;
		}
		yield return type.BaseType();
		foreach (Type parentType in type.BaseType().GetParentTypes())
		{
			yield return parentType;
		}
	}

	public static bool IsClosedGenericType(this Type type)
	{
		if (!_isClosedGenericType.TryGetValue(type, out var value))
		{
			value = type.IsGenericType() && type != type.GetGenericTypeDefinition();
			_isClosedGenericType[type] = value;
		}
		return value;
	}

	public static bool IsOpenGenericType(this Type type)
	{
		if (!_isOpenGenericType.TryGetValue(type, out var value))
		{
			value = type.IsGenericType() && type == type.GetGenericTypeDefinition();
			_isOpenGenericType[type] = value;
		}
		return value;
	}

	public static IEnumerable<FieldInfo> GetAllInstanceFields(this Type type)
	{
		FieldInfo[] array = type.DeclaredInstanceFields();
		for (int i = 0; i < array.Length; i++)
		{
			yield return array[i];
		}
		if (!(type.BaseType() != null) || !(type.BaseType() != typeof(object)))
		{
			yield break;
		}
		foreach (FieldInfo allInstanceField in type.BaseType().GetAllInstanceFields())
		{
			yield return allInstanceField;
		}
	}

	public static IEnumerable<PropertyInfo> GetAllInstanceProperties(this Type type)
	{
		PropertyInfo[] array = type.DeclaredInstanceProperties();
		for (int i = 0; i < array.Length; i++)
		{
			yield return array[i];
		}
		if (!(type.BaseType() != null) || !(type.BaseType() != typeof(object)))
		{
			yield break;
		}
		foreach (PropertyInfo allInstanceProperty in type.BaseType().GetAllInstanceProperties())
		{
			yield return allInstanceProperty;
		}
	}

	public static IEnumerable<MethodInfo> GetAllInstanceMethods(this Type type)
	{
		MethodInfo[] array = type.DeclaredInstanceMethods();
		for (int i = 0; i < array.Length; i++)
		{
			yield return array[i];
		}
		if (!(type.BaseType() != null) || !(type.BaseType() != typeof(object)))
		{
			yield break;
		}
		foreach (MethodInfo allInstanceMethod in type.BaseType().GetAllInstanceMethods())
		{
			yield return allInstanceMethod;
		}
	}

	public static string PrettyName(this Type type)
	{
		if (!_prettyNameCache.TryGetValue(type, out var value))
		{
			value = PrettyNameInternal(type);
			_prettyNameCache.Add(type, value);
		}
		return value;
	}

	private static string PrettyNameInternal(Type type)
	{
		StringBuilder stringBuilder = new StringBuilder();
		if (type.IsNested)
		{
			stringBuilder.Append(type.DeclaringType.PrettyName());
			stringBuilder.Append(".");
		}
		if (type.IsArray)
		{
			stringBuilder.Append(type.GetElementType().PrettyName());
			stringBuilder.Append("[]");
		}
		else
		{
			string cSharpTypeName = GetCSharpTypeName(type.Name);
			if (type.IsGenericType())
			{
				if (cSharpTypeName.IndexOf('`') != -1)
				{
					stringBuilder.Append(cSharpTypeName.Substring(0, cSharpTypeName.IndexOf('`')));
				}
				else
				{
					stringBuilder.Append(cSharpTypeName);
				}
				stringBuilder.Append("<");
				if (type.IsGenericTypeDefinition())
				{
					int num = type.GenericArguments().Count();
					if (num > 0)
					{
						stringBuilder.Append(new string(',', num - 1));
					}
				}
				else
				{
					stringBuilder.Append(string.Join(", ", (from t in type.GenericArguments()
						select t.PrettyName()).ToArray()));
				}
				stringBuilder.Append(">");
			}
			else
			{
				stringBuilder.Append(cSharpTypeName);
			}
		}
		return stringBuilder.ToString();
	}

	private static string GetCSharpTypeName(string typeName)
	{
		switch (typeName)
		{
		case "String":
		case "Object":
		case "Void":
		case "Byte":
		case "Double":
		case "Decimal":
			return typeName.ToLower();
		case "Int16":
			return "short";
		case "Int32":
			return "int";
		case "Int64":
			return "long";
		case "Single":
			return "float";
		case "Boolean":
			return "bool";
		default:
			return typeName;
		}
	}

	public static T GetAttribute<T>(this MemberInfo provider) where T : Attribute
	{
		return provider.AllAttributes<T>().Single();
	}

	public static T TryGetAttribute<T>(this MemberInfo provider) where T : Attribute
	{
		return provider.AllAttributes<T>().OnlyOrDefault();
	}

	public static bool HasAttribute(this MemberInfo provider, params Type[] attributeTypes)
	{
		return provider.AllAttributes(attributeTypes).Any();
	}

	public static bool HasAttribute<T>(this MemberInfo provider) where T : Attribute
	{
		return provider.AllAttributes(typeof(T)).Any();
	}

	public static IEnumerable<T> AllAttributes<T>(this MemberInfo provider) where T : Attribute
	{
		return provider.AllAttributes(typeof(T)).Cast<T>();
	}

	public static IEnumerable<Attribute> AllAttributes(this MemberInfo provider, params Type[] attributeTypes)
	{
		Attribute[] customAttributes = Attribute.GetCustomAttributes(provider, typeof(Attribute), inherit: true);
		if (attributeTypes.Length == 0)
		{
			return customAttributes;
		}
		return customAttributes.Where((Attribute a) => attributeTypes.Any((Type x) => a.GetType().DerivesFromOrEqual(x)));
	}

	public static bool HasAttribute(this ParameterInfo provider, params Type[] attributeTypes)
	{
		return provider.AllAttributes(attributeTypes).Any();
	}

	public static bool HasAttribute<T>(this ParameterInfo provider) where T : Attribute
	{
		return provider.AllAttributes(typeof(T)).Any();
	}

	public static IEnumerable<T> AllAttributes<T>(this ParameterInfo provider) where T : Attribute
	{
		return provider.AllAttributes(typeof(T)).Cast<T>();
	}

	public static IEnumerable<Attribute> AllAttributes(this ParameterInfo provider, params Type[] attributeTypes)
	{
		Attribute[] customAttributes = Attribute.GetCustomAttributes(provider, typeof(Attribute), inherit: true);
		if (attributeTypes.Length == 0)
		{
			return customAttributes;
		}
		return customAttributes.Where((Attribute a) => attributeTypes.Any((Type x) => a.GetType().DerivesFromOrEqual(x)));
	}
}
