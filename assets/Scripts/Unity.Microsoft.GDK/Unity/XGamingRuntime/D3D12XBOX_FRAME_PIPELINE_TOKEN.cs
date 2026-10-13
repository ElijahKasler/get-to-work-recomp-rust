using Unity.XGamingRuntime.Interop;

namespace Unity.XGamingRuntime;

public class D3D12XBOX_FRAME_PIPELINE_TOKEN
{
	internal Unity.XGamingRuntime.Interop.D3D12XBOX_FRAME_PIPELINE_TOKEN data;

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

	public D3D12XBOX_FRAME_PIPELINE_TOKEN(ulong value)
	{
		data = default;
		data.value = value;
	}

	internal D3D12XBOX_FRAME_PIPELINE_TOKEN(Unity.XGamingRuntime.Interop.D3D12XBOX_FRAME_PIPELINE_TOKEN interop)
	{
		data = interop;
	}
}
