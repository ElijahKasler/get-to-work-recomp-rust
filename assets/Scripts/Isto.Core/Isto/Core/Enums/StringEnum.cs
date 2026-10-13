namespace Isto.Core.Enums;

public abstract class StringEnum<T> : ExpandableEnum<StringEnum<T>, string> where T : StringEnum<T>
{
	public StringEnum(string value, string name)
		: base(value, name)
	{
	}

	public static T GetByValue(string value)
	{
		return ExpandableEnum<StringEnum<T>, string>.GetFromValue(value) as T;
	}

	public static T GetByName(string name)
	{
		return ExpandableEnum<StringEnum<T>, string>.GetFromName(name) as T;
	}
}
