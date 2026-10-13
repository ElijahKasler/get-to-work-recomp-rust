namespace System.Windows.Forms.CarbonInternal;

internal struct MouseTrackingRegionID(uint signature, uint id)
{
	public uint signature = signature;

	public uint id = id;
}
