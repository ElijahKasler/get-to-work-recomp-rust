using System;
using System.Runtime.CompilerServices;

namespace UnityEngine.UIElements.Layout;

internal struct FixedBuffer16<T> where T : unmanaged
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

	private T __9;

	private T _10;

	private T _11;

	private T _12;

	private T _13;

	private T _14;

	private T _15;

	public const int Length = 16;

	public unsafe ref T this[int index]
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		get
		{
			if (index < 0 || index >= 16)
			{
				throw new IndexOutOfRangeException("index");
			}
			fixed (FixedBuffer16<T>* ptr = &this)
			{
				void* ptr2 = ptr;
				T* ptr3 = (T*)ptr2;
				return ref ptr3[index];
			}
		}
	}
}
