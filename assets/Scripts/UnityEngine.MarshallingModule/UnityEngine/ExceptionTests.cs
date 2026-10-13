using System;
using System.Runtime.CompilerServices;
using UnityEngine.Bindings;
using UnityEngine.Internal;

namespace UnityEngine;

[ExcludeFromDocs]
[NativeHeader("Modules/Marshalling/MarshallingTests.h")]
internal class ExceptionTests
{
	[NativeThrows]
	public static extern int PropertyThatCanThrow
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		set;
	}

	public static extern int PropertyGetThatCanThrow
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeThrows]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		set;
	}

	public static extern int PropertySetThatCanThrow
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeThrows]
		set;
	}

	[NativeThrows]
	public unsafe static void VoidReturnStringParameter(string param)
	{
		//The blocks IL_0029 are reachable both inside and outside the pinned region starting at IL_0018. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		try
		{
			ManagedSpanWrapper managedSpanWrapper = default;
			if (!StringMarshaller.TryMarshalEmptyOrNullString(param, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = param;
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					VoidReturnStringParameter_Injected(ref managedSpanWrapper);
					return;
				}
			}
			VoidReturnStringParameter_Injected(ref managedSpanWrapper);
		}
		finally
		{
		}
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[NativeThrows]
	public static extern int NonUnmarshallingReturn();

	[NativeThrows]
	public static string UnmarshallingReturn()
	{
		ManagedSpanWrapper ret = default;
		string stringAndDispose;
		try
		{
			UnmarshallingReturn_Injected(out ret);
		}
		finally
		{
			stringAndDispose = OutStringMarshaller.GetStringAndDispose(ret);
		}
		return stringAndDispose;
	}

	[NativeThrows]
	public static StructInt BlittableStructReturn()
	{
		BlittableStructReturn_Injected(out var ret);
		return ret;
	}

	[NativeThrows]
	public static StructCoreString NonblittableStructReturn()
	{
		NonblittableStructReturn_Injected(out var ret);
		return ret;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void VoidReturnStringParameter_Injected(ref ManagedSpanWrapper param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void UnmarshallingReturn_Injected(out ManagedSpanWrapper ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void BlittableStructReturn_Injected(out StructInt ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void NonblittableStructReturn_Injected(out StructCoreString ret);
}
