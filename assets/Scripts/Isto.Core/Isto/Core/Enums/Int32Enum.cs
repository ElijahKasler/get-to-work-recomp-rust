using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace Isto.Core.Enums;

public abstract class Int32Enum<T> : ExpandableEnum<Int32Enum<T>, int> where T : Int32Enum<T>
{
	private static int highestRatingValue = -1;

	public Int32Enum()
	{
	}

	protected Int32Enum(string name)
		: base(++highestRatingValue, name)
	{
	}

	protected Int32Enum(int value, string name)
		: base(value, name)
	{
		if (value > highestRatingValue)
		{
			highestRatingValue = value;
		}
	}

	public new static ReadOnlyCollection<T> GetStrictValues(Type t)
	{
		return ExpandableEnum<Int32Enum<T>, int>.GetStrictValues(t).Cast<T>().ToList()
			.AsReadOnly();
	}

	public static T GetByValue(int value)
	{
		return ExpandableEnum<Int32Enum<T>, int>.GetFromValue(value) as T;
	}

	public static T GetByName(string name)
	{
		return ExpandableEnum<Int32Enum<T>, int>.GetFromName(name) as T;
	}
}
