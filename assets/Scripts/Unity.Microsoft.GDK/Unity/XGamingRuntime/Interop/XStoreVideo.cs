using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop;

internal struct XStoreVideo
{
	[MarshalAs(UnmanagedType.LPStr)]
	internal string uri;

	internal uint height;

	internal uint width;

	[MarshalAs(UnmanagedType.LPStr)]
	internal string caption;

	[MarshalAs(UnmanagedType.LPStr)]
	internal string videoPurposeTag;

	internal XStoreImage previewImage;
}
