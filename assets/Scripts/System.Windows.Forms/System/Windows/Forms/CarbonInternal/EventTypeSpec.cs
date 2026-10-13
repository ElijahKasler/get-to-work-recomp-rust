namespace System.Windows.Forms.CarbonInternal;

internal struct EventTypeSpec(uint eventClass, uint eventKind)
{
	public uint eventClass = eventClass;

	public uint eventKind = eventKind;
}
