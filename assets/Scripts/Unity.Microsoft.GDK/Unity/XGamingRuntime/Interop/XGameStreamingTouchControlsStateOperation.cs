using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop;

internal struct XGameStreamingTouchControlsStateOperation
{
	internal XGameStreamingTouchControlsStateOperationKind operationKind;

	[MarshalAs(UnmanagedType.LPStr)]
	internal string path;

	internal XGameStreamingTouchControlsStateValue value;
}
