using System;
using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop;

public static class XboxLiveContext
{
	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern int XblContextDuplicateHandle(IntPtr xboxLiveContextHandle, out IntPtr duplicatedHandle);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern int XblContextGetUser(IntPtr context, out IntPtr user);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern int XblContextGetXboxUserId(IntPtr context, out ulong xboxUserId);
}
