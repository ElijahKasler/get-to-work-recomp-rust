namespace System.Windows.Forms.RTF;

internal struct KeyStruct(Major major, Minor minor, string symbol)
{
	public Major Major = major;

	public Minor Minor = minor;

	public string Symbol = symbol;
}
