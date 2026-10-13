using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop;

internal struct XStoreImage
{
	[MarshalAs(UnmanagedType.LPStr)]
	internal string uri;

	internal uint height;

	internal uint width;

	[MarshalAs(UnmanagedType.LPStr)]
	internal string caption;

	[MarshalAs(UnmanagedType.LPStr)]
	internal string imagePurposeTag;
}
