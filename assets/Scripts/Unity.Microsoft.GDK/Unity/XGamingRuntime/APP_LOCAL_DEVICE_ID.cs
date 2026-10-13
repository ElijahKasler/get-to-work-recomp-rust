using Unity.XGamingRuntime.Interop;

namespace Unity.XGamingRuntime;

public class APP_LOCAL_DEVICE_ID
{
	internal Unity.XGamingRuntime.Interop.APP_LOCAL_DEVICE_ID interop;

	public byte[] Value
	{
		get
		{
			return interop.value;
		}
		set
		{
			interop.value = value;
		}
	}

	internal APP_LOCAL_DEVICE_ID(Unity.XGamingRuntime.Interop.APP_LOCAL_DEVICE_ID interop)
	{
		this.interop = interop;
	}

	public APP_LOCAL_DEVICE_ID()
	{
		interop = default;
	}
}
