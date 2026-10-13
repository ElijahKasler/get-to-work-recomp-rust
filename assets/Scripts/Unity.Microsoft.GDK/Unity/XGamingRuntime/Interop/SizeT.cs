using System;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime.Interop;

[MovedFrom("Unity.GameCore.Interop")]
public struct SizeT
{
	private readonly UIntPtr value;

	public bool IsZero => value == UIntPtr.Zero;

	public SizeT(int length)
	{
		value = new UIntPtr(Convert.ToUInt64(length));
	}

	public SizeT(uint length)
	{
		value = new UIntPtr(Convert.ToUInt64(length));
	}

	public SizeT(long length)
	{
		value = new UIntPtr(Convert.ToUInt64(length));
	}

	public SizeT(ulong length)
	{
		value = new UIntPtr(length);
	}

	public uint ToUInt32()
	{
		UIntPtr uIntPtr = value;
		return Convert.ToUInt32(uIntPtr.ToUInt64());
	}

	public int ToInt32()
	{
		UIntPtr uIntPtr = value;
		return Convert.ToInt32(uIntPtr.ToUInt64());
	}

	public ulong ToUInt64()
	{
		UIntPtr uIntPtr = value;
		return uIntPtr.ToUInt64();
	}

	public long ToInt64()
	{
		UIntPtr uIntPtr = value;
		return Convert.ToInt64(uIntPtr.ToUInt64());
	}
}
