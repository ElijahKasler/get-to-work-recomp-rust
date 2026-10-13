using UnityEngine.Bindings;

namespace UnityEngine.Accessibility;

[NativeHeader("Modules/Accessibility/Native/AccessibilityNotificationContext.h")]
internal enum AccessibilityNotification
{
	None = 0,
	Announcement = 1,
	AnnouncementFinished = 2,
	ScreenReaderStatusChanged = 3,
	ScreenChanged = 4,
	LayoutChanged = 5,
	PageScrolled = 6,
	ElementFocused = 7,
	ElementUnfocused = 8,
	FontScaleChanged = 9,
	BoldTextStatusChanged = 10,
	ClosedCaptioningStatusChanged = 11
}
