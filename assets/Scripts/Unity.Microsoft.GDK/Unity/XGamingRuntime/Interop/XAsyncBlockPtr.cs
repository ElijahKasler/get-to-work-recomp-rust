using System;

namespace Unity.XGamingRuntime.Interop;

public struct XAsyncBlockPtr
{
	internal readonly IntPtr IntPtr;

	internal XAsyncBlockPtr(IntPtr intPtr)
	{
		IntPtr = intPtr;
	}

	public static implicit operator IntPtr(XAsyncBlockPtr ptr)
	{
		return ptr.IntPtr;
	}

	public static implicit operator XAsyncBlockPtr(XAsyncBlock block)
	{
		return new XAsyncBlockPtr(block.InteropPtr);
	}
}
