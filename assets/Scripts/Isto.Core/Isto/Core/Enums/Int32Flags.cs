namespace Isto.Core.Enums;

public abstract class Int32Flags<T> : ExpandableFlags<Int32Flags<T>, uint> where T : Int32Flags<T>, new()
{
	public const uint BIT_0 = 0u;

	public const uint BIT_1 = 1u;

	public const uint BIT_2 = 2u;

	public const uint BIT_3 = 4u;

	public const uint BIT_4 = 8u;

	public const uint BIT_5 = 16u;

	public const uint BIT_6 = 32u;

	public const uint BIT_7 = 64u;

	public const uint BIT_8 = 128u;

	public const uint BIT_9 = 256u;

	public const uint BIT_10 = 512u;

	public const uint BIT_11 = 1024u;

	public const uint BIT_12 = 2048u;

	public const uint BIT_13 = 4096u;

	public const uint BIT_14 = 8192u;

	public const uint BIT_15 = 16384u;

	public const uint BIT_16 = 32768u;

	public const uint BIT_17 = 65536u;

	public const uint BIT_18 = 131072u;

	public const uint BIT_19 = 262144u;

	public const uint BIT_20 = 524288u;

	public const uint BIT_21 = 1048576u;

	public const uint BIT_22 = 2097152u;

	public const uint BIT_23 = 4194304u;

	public const uint BIT_24 = 8388608u;

	public const uint BIT_25 = 16777216u;

	public const uint BIT_26 = 33554432u;

	public const uint BIT_27 = 67108864u;

	public const uint BIT_28 = 134217728u;

	public const uint BIT_29 = 268435456u;

	public const uint BIT_30 = 536870912u;

	public const uint BIT_31 = 1073741824u;

	public const uint BIT_32 = 2147483648u;

	public const uint BIT_ALL = uint.MaxValue;

	public T AsDerivedType => this as T;

	public Int32Flags()
	{
	}

	public Int32Flags(uint value, string name)
		: base(value, name)
	{
	}

	public new static T GetFromValue(uint value)
	{
		return (T)ExpandableEnum<Int32Flags<T>, uint>.GetFromValue(value);
	}

	public static T GetFromName(string enumValueName)
	{
		return (T)ExpandableEnum<Int32Flags<T>, uint>.GetFromName(enumValueName);
	}

	public static bool ContainsAny(T a, T b)
	{
		return a.HasAnyFlag(b);
	}

	public static bool ContainsAll(T a, T b)
	{
		return a.HasFlag(b);
	}

	private static T ExcludeInternal(T a, T b)
	{
		uint value = a.Value & ~b.Value;
		string name = a.Name + " without " + b.Name;
		T val = new T();
		val.SetValue(value, name);
		return val;
	}

	private static T IntersectInternal(T a, T b)
	{
		uint value = a.Value & b.Value;
		string name = a.Name + " & " + b.Name;
		T val = new T();
		val.SetValue(value, name);
		return val;
	}

	public static T Intersect(params T[] args)
	{
		T val = args[0];
		for (int i = 1; i < args.Length; i++)
		{
			val = IntersectInternal(val, args[i]);
		}
		return val;
	}

	private static T UnionInternal(T a, T b)
	{
		uint value = a.Value | b.Value;
		string name = a.Name + " | " + b.Name;
		T val = new T();
		val.SetValue(value, name);
		return val;
	}

	public static T Union(params T[] args)
	{
		T val = args[0];
		for (int i = 1; i < args.Length; i++)
		{
			val = UnionInternal(val, args[i]);
		}
		return val;
	}

	private static T ExclusiveUnion(T a, T b)
	{
		uint value = a.Value ^ b.Value;
		string name = a.Name + " ^ " + b.Name;
		T val = new T();
		val.SetValue(value, name);
		return val;
	}

	private static T Invert(T a)
	{
		uint value = ~a.Value;
		string name = "~" + a.Name;
		if (a.Name.StartsWith("~"))
		{
			name = a.Name.Substring(1);
		}
		T val = new T();
		val.SetValue(value, name);
		return val;
	}

	public T Exclude(T flags)
	{
		return ExcludeInternal(AsDerivedType, flags);
	}

	public Int32Flags<T> Exclude(Int32Flags<T> flags)
	{
		return ExcludeInternal(AsDerivedType, flags.AsDerivedType);
	}

	public T CombineWith(T flags)
	{
		return UnionInternal(AsDerivedType, flags);
	}

	public Int32Flags<T> CombineWith(Int32Flags<T> flags)
	{
		return UnionInternal(AsDerivedType, flags.AsDerivedType);
	}

	public bool ContainsAny(T flags)
	{
		return ContainsAny(AsDerivedType, flags);
	}

	public bool ContainsAny(Int32Flags<T> flags)
	{
		return ContainsAny(AsDerivedType, flags.AsDerivedType);
	}

	public bool ContainsAll(T flags)
	{
		return ContainsAll(AsDerivedType, flags);
	}

	public bool ContainsAll(Int32Flags<T> flags)
	{
		return ContainsAll(AsDerivedType, flags.AsDerivedType);
	}

	public static T operator &(Int32Flags<T> a, Int32Flags<T> b)
	{
		return IntersectInternal(a.AsDerivedType, b.AsDerivedType);
	}

	public static T operator |(Int32Flags<T> a, Int32Flags<T> b)
	{
		return UnionInternal(a.AsDerivedType, b.AsDerivedType);
	}

	public static T operator ^(Int32Flags<T> a, Int32Flags<T> b)
	{
		return ExclusiveUnion(a.AsDerivedType, b.AsDerivedType);
	}

	public static T operator ~(Int32Flags<T> flags)
	{
		return Invert(flags.AsDerivedType);
	}

	public bool HasAnyFlag(Int32Flags<T> other)
	{
		return (this & other).Value != 0;
	}

	public override bool HasFlag(Int32Flags<T> other)
	{
		return (this & other) == other;
	}
}
