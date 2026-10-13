namespace Unity.XGamingRuntime.Interop;

internal struct XblMultiplayerInviteHandle
{
	private unsafe fixed byte Data[40];

	internal unsafe string GetData()
	{
		fixed (byte* data = Data)
		{
			return Converters.BytePointerToString(data, 40);
		}
	}
}
