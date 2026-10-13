namespace System.Windows.Forms.CarbonInternal;

internal struct HIViewID(uint type, uint id)
{
	public uint type = type;

	public uint id = id;
}
