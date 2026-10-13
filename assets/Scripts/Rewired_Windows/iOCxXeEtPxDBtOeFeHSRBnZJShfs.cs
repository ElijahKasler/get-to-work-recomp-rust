using System;

[Flags]
internal enum iOCxXeEtPxDBtOeFeHSRBnZJShfs
{
	Remove = 1,
	Exclude = 0x10,
	PageOnly = 0x20,
	NoLegacy = Exclude | PageOnly,
	InputSink = 0x100,
	CaptureMouse = 0x200,
	NoHotKeys = CaptureMouse,
	AppKeys = 0x400,
	ExclusiveInputSink = 0x1000,
	DeviceNotify = 0x2000,
	None = 0
}
