using System;
using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop;

public static class RealTimeActivity
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	public delegate void XblRealTimeActivityConnectionStateChangeHandler(IntPtr context, XblRealTimeActivityConnectionState connectionState);

	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	public delegate void XblRealTimeActivityResyncHandler(IntPtr context);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern int XblRealTimeActivityAddConnectionStateChangeHandler(IntPtr xboxLiveContext, XblRealTimeActivityConnectionStateChangeHandler handler, IntPtr context);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern int XblRealTimeActivityRemoveConnectionStateChangeHandler(IntPtr xboxLiveContext, int token);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern int XblRealTimeActivityAddResyncHandler(IntPtr xboxLiveContext, XblRealTimeActivityResyncHandler handler, IntPtr context);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern int XblRealTimeActivityRemoveResyncHandler(IntPtr xboxLiveContext, int token);
}
