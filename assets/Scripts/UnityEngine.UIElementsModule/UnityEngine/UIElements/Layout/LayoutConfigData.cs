using System.Runtime.InteropServices;

namespace UnityEngine.UIElements.Layout;

internal struct LayoutConfigData
{
	public float PointScaleFactor;

	[MarshalAs(UnmanagedType.U1)]
	public bool ShouldLog;

	public static LayoutConfigData Default => new LayoutConfigData
	{
		PointScaleFactor = 1f,
		ShouldLog = false
	};
}
