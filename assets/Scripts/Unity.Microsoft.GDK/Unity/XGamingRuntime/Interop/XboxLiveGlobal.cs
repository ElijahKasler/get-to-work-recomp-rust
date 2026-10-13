using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop;

public static class XboxLiveGlobal
{
	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public unsafe static extern int XblGetScid(sbyte** scid);
}
