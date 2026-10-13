using System;
using Rewired.Utils.Classes.Data;

namespace Rewired.Utils.Classes.Utility;

[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
[CustomObfuscation(rename = false)]
internal sealed class EnumNameValueCache<TEnum> where TEnum : struct, IComparable, IFormattable
{
	private static EnumNameValueCache<TEnum> wRVTAcGYJZfIjyGiFTKJusPVSOHf;

	private readonly ADictionary<string, TEnum> BftmMiUCcRgiPERjNaoYcHecPNVC;

	private readonly string[] VyMfsvieiXEkBfXgByxzoMMJPWRwB;

	private readonly long[] gnRvkCpIlHqvaILmMcrkXcyaiYlG;

	public static EnumNameValueCache<TEnum> Default => wRVTAcGYJZfIjyGiFTKJusPVSOHf ?? (wRVTAcGYJZfIjyGiFTKJusPVSOHf = new EnumNameValueCache<TEnum>());

	public int Count => gnRvkCpIlHqvaILmMcrkXcyaiYlG.Length;

	public static void Free()
	{
		wRVTAcGYJZfIjyGiFTKJusPVSOHf = null;
	}

	private EnumNameValueCache()
	{
		Type typeFromHandle = typeof(TEnum);
		if (!EnumTools.IsEnum(typeFromHandle))
		{
			throw new Exception("enumType is not an enum type.");
		}
		Type underlyingEnumType = ReflectionTools.GetUnderlyingEnumType(typeFromHandle);
		VyMfsvieiXEkBfXgByxzoMMJPWRwB = Enum.GetNames(typeFromHandle);
		TEnum[] array = (TEnum[])Enum.GetValues(typeFromHandle);
		BftmMiUCcRgiPERjNaoYcHecPNVC = new ADictionary<string, TEnum>();
		gnRvkCpIlHqvaILmMcrkXcyaiYlG = new long[array.Length];
		for (int i = 0; i < array.Length; i++)
		{
			gnRvkCpIlHqvaILmMcrkXcyaiYlG[i] = MiscTools.ToLongUnchecked(Convert.ChangeType(array[i], underlyingEnumType));
			BftmMiUCcRgiPERjNaoYcHecPNVC.Add(VyMfsvieiXEkBfXgByxzoMMJPWRwB[i], array[i]);
		}
	}

	public TEnum GetValue(string name)
	{
		return BftmMiUCcRgiPERjNaoYcHecPNVC.get_Item(name);
	}

	public bool TryGetValue(string name, out TEnum value)
	{
		return BftmMiUCcRgiPERjNaoYcHecPNVC.TryGetValue(name, out value);
	}

	public string GetName(long value)
	{
		int num = IndexOf(value);
		if (num < 0)
		{
			throw new Exception("The value does not exist in the enum.");
		}
		return VyMfsvieiXEkBfXgByxzoMMJPWRwB[num];
	}

	public bool TryGetName(long value, out string name)
	{
		int num = IndexOf(value);
		if (num < 0)
		{
			name = string.Empty;
			return false;
		}
		name = VyMfsvieiXEkBfXgByxzoMMJPWRwB[num];
		return true;
	}

	public TEnum GetValueAt(int index)
	{
		if ((uint)index >= (uint)gnRvkCpIlHqvaILmMcrkXcyaiYlG.Length)
		{
			throw new ArgumentOutOfRangeException("index");
		}
		return BftmMiUCcRgiPERjNaoYcHecPNVC.get_Item(VyMfsvieiXEkBfXgByxzoMMJPWRwB[index]);
	}

	public string GetNameAt(int index)
	{
		if ((uint)index >= (uint)gnRvkCpIlHqvaILmMcrkXcyaiYlG.Length)
		{
			throw new ArgumentOutOfRangeException("index");
		}
		return VyMfsvieiXEkBfXgByxzoMMJPWRwB[index];
	}

	public int IndexOf(string name)
	{
		return Array.IndexOf(VyMfsvieiXEkBfXgByxzoMMJPWRwB, name);
	}

	public int IndexOf(long value)
	{
		return Array.IndexOf(gnRvkCpIlHqvaILmMcrkXcyaiYlG, value);
	}

	public bool Contains(string name)
	{
		return BftmMiUCcRgiPERjNaoYcHecPNVC.ContainsKey(name);
	}

	public bool Contains(long value)
	{
		return IndexOf(value) >= 0;
	}
}
