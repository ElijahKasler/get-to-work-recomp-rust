using System;
using Unity.XGamingRuntime.Interop;

namespace Unity.XGamingRuntime;

public class XAppCaptureScreenshotStreamHandle : EquatableHandle
{
	public int CloseResult { get; private set; }

	public override bool IsInvalid => base.Handle == IntPtr.Zero;

	public XAppCaptureScreenshotStreamHandle(IntPtr handle)
		: base(IntPtr.Zero, ownsHandle: true, handle)
	{
	}

	protected override bool ReleaseHandle()
	{
		CloseResult = NativeMethods.XAppCaptureCloseScreenshotStream(base.Handle);
		SetHandle(IntPtr.Zero);
		return Unity.XGamingRuntime.Interop.HR.SUCCEEDED(CloseResult);
	}

	internal static int WrapAndReturnHResult(int hresult, IntPtr interopHandle, out XAppCaptureScreenshotStreamHandle handle)
	{
		if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(hresult))
		{
			handle = new XAppCaptureScreenshotStreamHandle(interopHandle);
		}
		else
		{
			handle = null;
		}
		return hresult;
	}
}
