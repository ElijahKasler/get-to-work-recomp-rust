using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Isto.Core.Enums;

public abstract class ExpandableFlags<T, U> : ExpandableEnum<T, U>, IEnumerable where T : ExpandableFlags<T, U> where U : new()
{
	public ExpandableFlags()
	{
	}

	public ExpandableFlags(U value, string name)
		: base(value, name)
	{
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}

	public IEnumerator<ExpandableFlags<T, U>> GetEnumerator()
	{
		List<ExpandableFlags<T, U>> list = new List<ExpandableFlags<T, U>>();
		T val = this as T;
		U val2 = new U();
		foreach (T value in ExpandableEnum<T, U>.GetValues())
		{
			if (!value.Value.Equals(val2) && val.HasFlag(value as T))
			{
				list.Add(value);
			}
		}
		return list.GetEnumerator();
	}

	public abstract bool HasFlag(T flag);

	public static int LogAndCountFlags(T flags)
	{
		int num = 0;
		foreach (T flag in flags)
		{
			num++;
			Debug.Log($"Value:{flag.Value} Name:{flag.Name}");
		}
		return num;
	}
}
