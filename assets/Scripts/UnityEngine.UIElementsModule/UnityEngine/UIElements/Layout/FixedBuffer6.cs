using System;
using System.Runtime.CompilerServices;

namespace UnityEngine.UIElements.Layout;

internal struct FixedBuffer6<T> where T : unmanaged
{
	private T __0;

	private T __1;

	private T __2;

	private T __3;

	private T __4;

	private T __5;

	public const int Length = 6;

	public unsafe ref T this[int index]
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		get
		{
			if (index < 0 || index >= 6)
			{
				throw new IndexOutOfRangeException("index");
			}
			fixed (FixedBuffer6<T>* ptr = &this)
			{
				void* ptr2 = ptr;
				T* ptr3 = (T*)ptr2;
				return ref ptr3[index];
			}
		}
	}
}
