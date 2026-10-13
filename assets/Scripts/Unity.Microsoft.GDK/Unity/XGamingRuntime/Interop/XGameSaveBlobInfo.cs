using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop;

public struct XGameSaveBlobInfo
{
	[MarshalAs(UnmanagedType.LPStr)]
	internal string name;

	internal uint size;
}
