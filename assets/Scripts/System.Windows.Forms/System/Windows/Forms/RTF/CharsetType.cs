namespace System.Windows.Forms.RTF;

internal enum CharsetType : byte
{
	ANSI = 0,
	General = 1,
	Symbol = 2,
	Mac = 77,
	Shift_Jis = 128,
	Hangul = 129,
	Johab = 130,
	GB2312 = 134,
	Big5 = 136,
	Greek = 161,
	Turkish = 162,
	Vietnamese = 163,
	Hebrew = 177,
	Arabic = 178,
	Arabic_Traditional = 179,
	Arabic_user = 180,
	Hebrew_user = 181,
	Baltic = 186,
	Russian = 204,
	Thai = 222,
	Eastern_European = 238,
	PC_437 = 254,
	OEM = byte.MaxValue
}
