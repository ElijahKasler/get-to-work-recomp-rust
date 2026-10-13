using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop;

internal struct XClosedCaptionProperties
{
	internal XColor BackgroundColor;

	internal XColor FontColor;

	internal XColor WindowColor;

	internal XClosedCaptionFontEdgeAttribute FontEdgeAttribute;

	internal XClosedCaptionFontStyle FontStyle;

	internal float FontScale;

	[MarshalAs(UnmanagedType.I1)]
	internal bool Enabled;
}
