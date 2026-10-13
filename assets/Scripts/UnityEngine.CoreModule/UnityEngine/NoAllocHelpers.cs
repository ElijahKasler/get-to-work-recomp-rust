#define UNITY_ASSERTIONS
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Collections.LowLevel.Unsafe;

namespace UnityEngine;

internal static class NoAllocHelpers
{
	private class ListPrivateFieldAccess<T>
	{
		internal T[] _items;

		internal int _size;

		internal int _version;
	}

	public static void EnsureListElemCount<T>(List<T> list, int count)
	{
		if (list == null)
		{
			throw new ArgumentNullException("list");
		}
		if (count < 0)
		{
			throw new ArgumentException("invalid size to resize.", "list");
		}
		list.Clear();
		if (list.Capacity < count)
		{
			list.Capacity = count;
		}
		if (count != list.Count)
		{
			ListPrivateFieldAccess<T> listPrivateFieldAccess = UnsafeUtility.As<List<T>, ListPrivateFieldAccess<T>>(ref list);
			listPrivateFieldAccess._size = count;
			listPrivateFieldAccess._version++;
		}
	}

	public static int SafeLength(Array values)
	{
		return values?.Length ?? 0;
	}

	public static int SafeLength<T>(List<T> values)
	{
		return values?.Count ?? 0;
	}

	[Obsolete("Use ExtractArrayFromList", false)]
	public static T[] ExtractArrayFromListT<T>(List<T> list)
	{
		return ExtractArrayFromList(list);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static T[] ExtractArrayFromList<T>(List<T> list)
	{
		if (list == null)
		{
			return null;
		}
		ListPrivateFieldAccess<T> listPrivateFieldAccess = UnsafeUtility.As<ListPrivateFieldAccess<T>>(list);
		return listPrivateFieldAccess._items;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void ResetListContents<T>(List<T> list, ReadOnlySpan<T> span)
	{
		ListPrivateFieldAccess<T> listPrivateFieldAccess = UnsafeUtility.As<ListPrivateFieldAccess<T>>(list);
		listPrivateFieldAccess._items = span.ToArray();
		listPrivateFieldAccess._size = span.Length;
		listPrivateFieldAccess._version++;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void ResetListSize<T>(List<T> list, int size) where T : unmanaged
	{
		Debug.Assert(list.Capacity >= size);
		ListPrivateFieldAccess<T> listPrivateFieldAccess = UnsafeUtility.As<ListPrivateFieldAccess<T>>(list);
		listPrivateFieldAccess._size = size;
		listPrivateFieldAccess._version++;
	}
}
