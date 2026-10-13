namespace System.Windows.Forms.CarbonInternal;

internal enum MouseTrackingResult : ushort
{
	kMouseTrackingMouseDown = 1,
	kMouseTrackingMouseUp = 2,
	kMouseTrackingMouseExited = 3,
	kMouseTrackingMouseEntered = 4,
	kMouseTrackingMouseDragged = 5,
	kMouseTrackingKeyModifiersChanged = 6,
	kMouseTrackingUserCancelled = 7,
	kMouseTrackingTimedOut = 8,
	kMouseTrackingMouseMoved = 9
}
