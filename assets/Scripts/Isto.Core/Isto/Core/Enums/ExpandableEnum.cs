using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Isto.Core.Enums;

public static class ExpandableEnum
{
	public abstract class ReferenceTypeEnum
	{
	}

	private abstract class DummyEnum : ExpandableEnum<DummyEnum, int>
	{
	}

	public static readonly HashSet<Type> ALL_TYPES;

	public static readonly Dictionary<Type, List<object>> ALL_VALUES;

	private static readonly Type REFERENCE_ENUM_TYPE;

	private static readonly string ENUM_VALUE_PROPERTY_NAME;

	private static readonly string ENUM_NAME_PROPERTY_NAME;

	static ExpandableEnum()
	{
		ALL_TYPES = new HashSet<Type>();
		ALL_VALUES = new Dictionary<Type, List<object>>();
		REFERENCE_ENUM_TYPE = typeof(ReferenceTypeEnum);
		ENUM_VALUE_PROPERTY_NAME = "Value";
		ENUM_NAME_PROPERTY_NAME = "Name";
		Debug.Log("[ExpandableEnum] Initialization of all ReferenceTypeEnum");
		foreach (Type item in from assembly in AppDomain.CurrentDomain.GetAssemblies()
			from type in assembly.GetTypes()
			where REFERENCE_ENUM_TYPE.IsAssignableFrom(type) && !type.IsAbstract
			select type)
		{
			ALL_TYPES.Add(item);
			RuntimeHelpers.RunClassConstructor(item.TypeHandle);
		}
	}

	public static ReadOnlyCollection<object> GetValuesAndDependencies(Type type)
	{
		List<object> list = new List<object>();
		Type type2 = type;
		while (type2 != REFERENCE_ENUM_TYPE)
		{
			list.AddRange(GetStrictValues(type2));
			type2 = type2.BaseType;
		}
		list = list.OrderBy((object x) => GetBackingValue(x)).ToList();
		return list.AsReadOnly();
	}

	public static ReadOnlyCollection<object> GetAllCompatibleValues(Type type)
	{
		List<object> list = new List<object>();
		foreach (Type item in ALL_TYPES.Where((Type otherType) => type.IsAssignableFrom(otherType) || otherType.IsAssignableFrom(type)))
		{
			list.AddRange(GetStrictValues(item));
		}
		return list.AsReadOnly();
	}

	public static ReadOnlyCollection<object> GetStrictValues(Type type)
	{
		List<object> list = new List<object>();
		if (ALL_VALUES.ContainsKey(type))
		{
			foreach (object item in ALL_VALUES[type])
			{
				list.Add(item);
			}
		}
		return list.AsReadOnly();
	}

	public static object GetDefaultValue(Type enumType)
	{
		object result = null;
		if (ALL_VALUES.ContainsKey(enumType) && ALL_VALUES[enumType].Count > 0)
		{
			result = ALL_VALUES[enumType][0];
		}
		return result;
	}

	public static object GetFromValueAndType(object value, Type enumType)
	{
		object result = null;
		if (ALL_VALUES.ContainsKey(enumType))
		{
			IEnumerator<object> enumerator = GetValuesAndDependencies(enumType).GetEnumerator();
			while (enumerator.MoveNext())
			{
				object current = enumerator.Current;
				if (GetBackingValue(current).Equals(value))
				{
					result = current;
					break;
				}
			}
		}
		return result;
	}

	public static object GetFromValueAndStrictType(object value, Type enumType)
	{
		object result = null;
		if (ALL_VALUES.ContainsKey(enumType))
		{
			IEnumerator<object> enumerator = GetStrictValues(enumType).GetEnumerator();
			while (enumerator.MoveNext())
			{
				object current = enumerator.Current;
				if (GetBackingValue(current).Equals(value))
				{
					result = current;
					break;
				}
			}
		}
		return result;
	}

	public static object GetFromValueAndCompatibleType(object value, Type enumType)
	{
		object result = null;
		if (ALL_VALUES.ContainsKey(enumType))
		{
			IEnumerator<object> enumerator = GetAllCompatibleValues(enumType).GetEnumerator();
			while (enumerator.MoveNext())
			{
				object current = enumerator.Current;
				if (GetBackingValue(current).Equals(value))
				{
					result = current;
					break;
				}
			}
		}
		return result;
	}

	public static object GetFromNameAndType(string enumValueName, Type enumType)
	{
		object result = null;
		if (ALL_VALUES.ContainsKey(enumType))
		{
			IEnumerator<object> enumerator = GetValuesAndDependencies(enumType).GetEnumerator();
			while (enumerator.MoveNext())
			{
				object current = enumerator.Current;
				if (GetName(current).Equals(enumValueName))
				{
					result = current;
					break;
				}
			}
		}
		return result;
	}

	public static object GetFromNameAndStrictType(string enumValueName, Type enumType)
	{
		object result = null;
		if (ALL_VALUES.ContainsKey(enumType))
		{
			IEnumerator<object> enumerator = GetStrictValues(enumType).GetEnumerator();
			while (enumerator.MoveNext())
			{
				object current = enumerator.Current;
				if (GetName(current).Equals(enumValueName))
				{
					result = current;
					break;
				}
			}
		}
		return result;
	}

	public static object GetFromNameAndCompatibleType(string enumValueName, Type enumType)
	{
		object result = null;
		if (ALL_VALUES.ContainsKey(enumType))
		{
			IEnumerator<object> enumerator = GetAllCompatibleValues(enumType).GetEnumerator();
			while (enumerator.MoveNext())
			{
				object current = enumerator.Current;
				if (GetName(current).Equals(enumValueName))
				{
					result = current;
					break;
				}
			}
		}
		return result;
	}

	public static object GetFromName(string enumValueName)
	{
		return ALL_VALUES.Where((KeyValuePair<Type, List<object>> v) =>
		{
			KeyValuePair<Type, List<object>> keyValuePair = v;
			return keyValuePair.Value.Where((object x) => GetName(x).Equals(enumValueName)).Count() > 0;
		}).Select((KeyValuePair<Type, List<object>> v) =>
		{
			KeyValuePair<Type, List<object>> keyValuePair = v;
			return keyValuePair.Value.Where((object x) => GetName(x).Equals(enumValueName)).FirstOrDefault();
		}).FirstOrDefault();
	}

	public static bool IsDefined(Type enumType, object value)
	{
		if (ALL_VALUES.ContainsKey(enumType))
		{
			return ALL_VALUES[enumType].Contains(value);
		}
		return false;
	}

	public static bool IsDefined<TEnum>(TEnum value) where TEnum : ReferenceTypeEnum
	{
		return IsDefined(typeof(TEnum), value);
	}

	public static string GetName(Type enumType, object value)
	{
		string result = null;
		if (ALL_VALUES.ContainsKey(enumType))
		{
			IEnumerator<object> enumerator = GetValuesAndDependencies(enumType).GetEnumerator();
			while (enumerator.MoveNext())
			{
				object current = enumerator.Current;
				if (GetBackingValue(current).Equals(value))
				{
					result = GetName(current);
					break;
				}
			}
		}
		return result;
	}

	public static string GetNameStrictly(Type enumType, object value)
	{
		string result = null;
		if (ALL_VALUES.ContainsKey(enumType))
		{
			result = (from x in ALL_VALUES[enumType]
				where GetBackingValue(x).Equals(value)
				select GetName(x)).FirstOrDefault();
		}
		return result;
	}

	public static string GetNameFromAllCompatibleValues(Type enumType, object value)
	{
		string result = null;
		foreach (Type item in ALL_TYPES.Where((Type otherType) => enumType.IsAssignableFrom(otherType)))
		{
			IEnumerator<object> enumerator2 = GetStrictValues(item).GetEnumerator();
			while (enumerator2.MoveNext())
			{
				object current = enumerator2.Current;
				if (GetBackingValue(current).Equals(value))
				{
					result = GetName(current);
					break;
				}
			}
		}
		return result;
	}

	public static string GetName<TEnum>(TEnum value) where TEnum : ReferenceTypeEnum
	{
		return GetName(typeof(TEnum), GetBackingValue(value));
	}

	public static string[] GetNames(Type enumType)
	{
		return (from x in GetValuesAndDependencies(enumType)
			select GetName(x)).ToArray();
	}

	public static string[] GetNames<TEnum>() where TEnum : ReferenceTypeEnum
	{
		return GetNames(typeof(TEnum));
	}

	public static object GetBackingValue(object enumDefinition)
	{
		return enumDefinition.GetType().GetProperty(ENUM_VALUE_PROPERTY_NAME).GetValue(enumDefinition);
	}

	private static string GetName(object enumDefinition)
	{
		return enumDefinition.GetType().GetProperty(ENUM_NAME_PROPERTY_NAME).GetValue(enumDefinition) as string;
	}

	public static void LogAllTypes()
	{
		Debug.Log("All known ExpandableEnum types:");
		foreach (Type aLL_TYPE in ALL_TYPES)
		{
			Debug.Log($"{aLL_TYPE}");
		}
	}

	public static void LogStrictValues(Type type)
	{
		Debug.Log($"All ExpandableEnum values where type is strictly {type}:");
		foreach (object strictValue in GetStrictValues(type))
		{
			Debug.Log($"{strictValue}");
		}
	}

	public static void LogValuesAndDependencies(Type type)
	{
		Debug.Log($"All ExpandableEnum values (including parent values) for type {type}:");
		foreach (object valuesAndDependency in GetValuesAndDependencies(type))
		{
			Debug.Log($"{valuesAndDependency}");
		}
	}
}
public abstract class ExpandableEnum<T, U> : ExpandableEnum.ReferenceTypeEnum, ISerializationCallbackReceiver where T : ExpandableEnum<T, U>
{
	private static List<T> _values;

	[SerializeField]
	private U _value;

	[SerializeField]
	private string _name;

	protected static List<T> Values => _values;

	public U Value => _value;

	public string Name => _name;

	static ExpandableEnum()
	{
		_values = new List<T>();
		RuntimeHelpers.RunClassConstructor(typeof(ExpandableEnum).TypeHandle);
	}

	public ExpandableEnum()
	{
	}

	protected ExpandableEnum(U value, string name)
	{
		SetValue(value, name);
		RegisterType();
		RegisterValue();
	}

	protected void RegisterType()
	{
		Type type = GetType();
		ExpandableEnum.ALL_TYPES.Add(type);
		if (!ExpandableEnum.ALL_VALUES.ContainsKey(type))
		{
			ExpandableEnum.ALL_VALUES.Add(type, new List<object>());
		}
	}

	protected void RegisterValue()
	{
		Values.Add((T)this);
		ExpandableEnum.ALL_VALUES[GetType()].Add(this);
	}

	public void SetValue(U value, string name)
	{
		_value = value;
		_name = name;
	}

	public static ReadOnlyCollection<T> GetValues()
	{
		return GetAllValues();
	}

	public static ReadOnlyCollection<T> GetAllValues()
	{
		return Values.AsReadOnly();
	}

	public static ReadOnlyCollection<string> GetAllNames()
	{
		return Values.Select((T x) => x.Name).ToList().AsReadOnly();
	}

	public static ReadOnlyCollection<T> GetStrictValues(Type t)
	{
		return ExpandableEnum.GetStrictValues(t).Cast<T>().ToList()
			.AsReadOnly();
	}

	public static void LogAllValues()
	{
		Type typeFromHandle = typeof(T);
		Debug.Log($"All {typeFromHandle} values (including extended values):");
		foreach (T allValue in GetAllValues())
		{
			Debug.Log($"{allValue}");
		}
	}

	public static T GetFromValue(U value)
	{
		foreach (T value2 in Values)
		{
			if (value2.Value.Equals(value))
			{
				return value2;
			}
		}
		return null;
	}

	public static T GetFromName(string enumValueName, StringComparison comparisonType = StringComparison.Ordinal)
	{
		foreach (T value in Values)
		{
			if (string.Equals(value.Name, enumValueName, comparisonType))
			{
				return value;
			}
		}
		return null;
	}

	public static bool TryParse(string value, bool ignoreCase, out T result)
	{
		result = null;
		StringComparison comparisonType = (ignoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal);
		ReadOnlyCollection<T> allValues = GetAllValues();
		foreach (T item in allValues)
		{
			if (string.Equals(item.Name, value, comparisonType))
			{
				result = item;
				break;
			}
		}
		if (result == null)
		{
			foreach (T item2 in allValues)
			{
				if (string.Equals(item2.Value as string, value, comparisonType))
				{
					result = item2;
					break;
				}
			}
		}
		return result != null;
	}

	public override string ToString()
	{
		return Name;
	}

	public override bool Equals(object other)
	{
		if (other is ExpandableEnum<T, U> expandableEnum)
		{
			return this == expandableEnum;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return Value.GetHashCode();
	}

	public void OnBeforeSerialize()
	{
	}

	public void OnAfterDeserialize()
	{
		_name = ExpandableEnum.GetName(GetType(), Value);
	}

	public static bool operator ==(ExpandableEnum<T, U> a, ExpandableEnum<T, U> b)
	{
		if ((object)a == null && (object)b == null)
		{
			return true;
		}
		if ((object)a == null)
		{
			return false;
		}
		if ((object)b == null)
		{
			return false;
		}
		return a.Value.Equals(b.Value);
	}

	public static bool operator !=(ExpandableEnum<T, U> a, ExpandableEnum<T, U> b)
	{
		if ((object)a == null && (object)b == null)
		{
			return false;
		}
		if ((object)a == null)
		{
			return true;
		}
		if ((object)b == null)
		{
			return true;
		}
		return !a.Value.Equals(b.Value);
	}
}
