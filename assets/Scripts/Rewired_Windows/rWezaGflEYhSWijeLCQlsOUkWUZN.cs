using System;

[Flags]
internal enum rWezaGflEYhSWijeLCQlsOUkWUZN
{
	All = 0,
	RelativeAxis = 1,
	AbsoluteAxis = 2,
	Axis = RelativeAxis | AbsoluteAxis,
	PushButton = 4,
	ToggleButton = 8,
	Button = PushButton | ToggleButton,
	PointOfViewController = 0x10,
	Collection = 0x40,
	NoData = 0x80,
	AnyInstance = 0xFFFF00,
	ForceFeedbackActuator = 0x1000000,
	ForceFeedbackEffectTrigger = 0x2000000,
	Output = 0x10000000,
	VendorDefined = 0x4000000,
	Alias = 0x8000000,
	Optional = int.MinValue
}
