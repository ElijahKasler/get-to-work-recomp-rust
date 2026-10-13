using System;
using System.Runtime.CompilerServices;

namespace UnityEngine.UIElements.Layout;

internal struct FixedBuffer9<T> where T : unmanaged
{
	private T __0;

	private T __1;

	private T __2;

	private T __3;

	private T __4;

	private T __5;

	private T __6;

	private T __7;

	private T __8;

	public const int Length = 9;

	public unsafe ref T this[int index]
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		get
		{
			if (index < 0 || index >= 9)
			{
				throw new IndexOutOfRangeException("index");
			}
			fixed (FixedBuffer9<T>* ptr = &this)
			{
				void* ptr2 = ptr;
				T* ptr3 = (T*)ptr2;
				return ref ptr3[index];
			}
		}
	}
}
