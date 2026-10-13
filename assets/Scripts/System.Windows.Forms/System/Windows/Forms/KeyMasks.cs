namespace System.Windows.Forms;

[Flags]
internal enum KeyMasks
{
	ShiftMask = 1,
	LockMask = 2,
	ControlMask = 4,
	Mod1Mask = 8,
	Mod2Mask = 0x10,
	Mod3Mask = 0x20,
	Mod4Mask = 0x40,
	Mod5Mask = 0x80,
	ModMasks = Mod1Mask | Mod2Mask | Mod3Mask | Mod4Mask | Mod5Mask
}
