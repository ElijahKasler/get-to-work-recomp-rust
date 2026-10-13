namespace ModestTree.Util;

public class ValuePair<T1, T2>
{
	public readonly T1 First;

	public readonly T2 Second;

	public ValuePair()
	{
		First = default;
		Second = default;
	}

	public ValuePair(T1 first, T2 second)
	{
		First = first;
		Second = second;
	}

	public override bool Equals(object obj)
	{
		if (!(obj is ValuePair<T1, T2> that))
		{
			return false;
		}
		return Equals(that);
	}

	public bool Equals(ValuePair<T1, T2> that)
	{
		if (that == null)
		{
			return false;
		}
		if (object.Equals(First, that.First))
		{
			return object.Equals(Second, that.Second);
		}
		return false;
	}

	public override int GetHashCode()
	{
		return (17 * 29 + ((First != null) ? First.GetHashCode() : 0)) * 29 + ((Second != null) ? Second.GetHashCode() : 0);
	}
}
public class ValuePair<T1, T2, T3>
{
	public readonly T1 First;

	public readonly T2 Second;

	public readonly T3 Third;

	public ValuePair()
	{
		First = default;
		Second = default;
		Third = default;
	}

	public ValuePair(T1 first, T2 second, T3 third)
	{
		First = first;
		Second = second;
		Third = third;
	}

	public override bool Equals(object obj)
	{
		if (!(obj is ValuePair<T1, T2, T3> that))
		{
			return false;
		}
		return Equals(that);
	}

	public bool Equals(ValuePair<T1, T2, T3> that)
	{
		if (that == null)
		{
			return false;
		}
		if (object.Equals(First, that.First) && object.Equals(Second, that.Second))
		{
			return object.Equals(Third, that.Third);
		}
		return false;
	}

	public override int GetHashCode()
	{
		return ((17 * 29 + ((First != null) ? First.GetHashCode() : 0)) * 29 + ((Second != null) ? Second.GetHashCode() : 0)) * 29 + ((Third != null) ? Third.GetHashCode() : 0);
	}
}
public class ValuePair<T1, T2, T3, T4>
{
	public readonly T1 First;

	public readonly T2 Second;

	public readonly T3 Third;

	public readonly T4 Fourth;

	public ValuePair()
	{
		First = default;
		Second = default;
		Third = default;
		Fourth = default;
	}

	public ValuePair(T1 first, T2 second, T3 third, T4 fourth)
	{
		First = first;
		Second = second;
		Third = third;
		Fourth = fourth;
	}

	public override bool Equals(object obj)
	{
		if (!(obj is ValuePair<T1, T2, T3, T4> that))
		{
			return false;
		}
		return Equals(that);
	}

	public bool Equals(ValuePair<T1, T2, T3, T4> that)
	{
		if (that == null)
		{
			return false;
		}
		if (object.Equals(First, that.First) && object.Equals(Second, that.Second) && object.Equals(Third, that.Third))
		{
			return object.Equals(Fourth, that.Fourth);
		}
		return false;
	}

	public override int GetHashCode()
	{
		return (((17 * 29 + ((First != null) ? First.GetHashCode() : 0)) * 29 + ((Second != null) ? Second.GetHashCode() : 0)) * 29 + ((Third != null) ? Third.GetHashCode() : 0)) * 29 + ((Fourth != null) ? Fourth.GetHashCode() : 0);
	}
}
public static class ValuePair
{
	public static ValuePair<T1, T2> New<T1, T2>(T1 first, T2 second)
	{
		return new ValuePair<T1, T2>(first, second);
	}

	public static ValuePair<T1, T2, T3> New<T1, T2, T3>(T1 first, T2 second, T3 third)
	{
		return new ValuePair<T1, T2, T3>(first, second, third);
	}

	public static ValuePair<T1, T2, T3, T4> New<T1, T2, T3, T4>(T1 first, T2 second, T3 third, T4 fourth)
	{
		return new ValuePair<T1, T2, T3, T4>(first, second, third, fourth);
	}
}
