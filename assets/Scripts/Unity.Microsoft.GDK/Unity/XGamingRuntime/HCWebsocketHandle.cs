using System;
using System.Runtime.InteropServices;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime;

[MovedFrom("Unity.GameCore")]
public class HCWebsocketHandle : EquatableHandle
{
	internal Unity.XGamingRuntime.Interop.HCWebSocketMessageFunction messageFunc;

	internal Unity.XGamingRuntime.Interop.HCWebSocketBinaryMessageFunction binaryMessageFunc;

	internal Unity.XGamingRuntime.Interop.HCWebSocketCloseEventFunction closeFunc;

	internal HCWebSocketMessageFunction messageCallback;

	internal HCWebSocketBinaryMessageFunction binaryMessageCallback;

	internal HCWebSocketCloseEventFunction closeCallback;

	internal GCHandle cbHandle;

	public HCWebSocketMessageFunction MessageFunction => messageCallback;

	public HCWebSocketBinaryMessageFunction BinaryMessageFunction => binaryMessageCallback;

	public HCWebSocketCloseEventFunction CloseFunction => closeCallback;

	public override bool IsInvalid => base.Handle == IntPtr.Zero;

	internal HCWebsocketHandle(IntPtr handle)
		: base(IntPtr.Zero, ownsHandle: true, handle)
	{
	}

	internal HCWebsocketHandle(IntPtr handle, bool ownsHandle)
		: base(IntPtr.Zero, ownsHandle, handle)
	{
	}

	internal static int WrapAndReturnHResult(int hresult, IntPtr interopHandle, out HCWebsocketHandle handle, GCHandle callbackHandle)
	{
		if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(hresult))
		{
			handle = new HCWebsocketHandle(interopHandle);
			handle.cbHandle = callbackHandle;
		}
		else
		{
			if (callbackHandle.IsAllocated)
			{
				callbackHandle.Free();
			}
			handle = null;
		}
		return hresult;
	}

	public override bool Equals(object obj)
	{
		if (obj is HCWebsocketHandle hCWebsocketHandle)
		{
			return base.Handle == hCWebsocketHandle.Handle;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return base.Handle.GetHashCode();
	}

	protected override bool ReleaseHandle()
	{
		XGRInterop.HCWebSocketCloseHandle(base.Handle);
		SetHandle(IntPtr.Zero);
		return true;
	}

	public static bool operator ==(HCWebsocketHandle handle1, HCWebsocketHandle handle2)
	{
		return handle1?.Equals(handle2) ?? ((object)handle2 == null);
	}

	public static bool operator !=(HCWebsocketHandle handle1, HCWebsocketHandle handle2)
	{
		return !(handle1 == handle2);
	}
}
