using Unity.XGamingRuntime.Interop;

namespace Unity.XGamingRuntime;

public class XGameStreamingClientId
{
	internal Unity.XGamingRuntime.Interop.XGameStreamingClientId data;

	public ulong Value
	{
		get
		{
			return data.value;
		}
		set
		{
			data.value = value;
		}
	}

	public XGameStreamingClientId(ulong value)
	{
		data = default;
		data.value = value;
	}

	internal XGameStreamingClientId(Unity.XGamingRuntime.Interop.XGameStreamingClientId interop)
	{
		data = interop;
	}
}
