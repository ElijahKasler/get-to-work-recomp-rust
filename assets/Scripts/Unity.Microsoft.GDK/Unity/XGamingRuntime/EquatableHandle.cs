using System;
using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime;

public abstract class EquatableHandle : SafeHandle
{
	public IntPtr Handle => handle;

	public EquatableHandle(IntPtr invalidHandleValue, bool ownsHandle, IntPtr handle)
		: base(invalidHandleValue, ownsHandle)
	{
		SetHandle(handle);
	}

	public override bool Equals(object obj)
	{
		if (obj is EquatableHandle)
		{
			EquatableHandle equatableHandle = (EquatableHandle)obj;
			return handle == equatableHandle.handle;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return handle.GetHashCode();
	}

	public static bool operator ==(EquatableHandle handle1, EquatableHandle handle2)
	{
		return handle1?.Equals(handle2) ?? ((object)handle2 == null);
	}

	public static bool operator !=(EquatableHandle handle1, EquatableHandle handle2)
	{
		return !(handle1 == handle2);
	}
}
