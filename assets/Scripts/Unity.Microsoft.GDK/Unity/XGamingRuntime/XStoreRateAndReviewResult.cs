using Unity.XGamingRuntime.Interop;

namespace Unity.XGamingRuntime;

public class XStoreRateAndReviewResult
{
	internal Unity.XGamingRuntime.Interop.XStoreRateAndReviewResult interop;

	public bool WasUpdated
	{
		get
		{
			return interop.wasUpdated;
		}
		set
		{
			interop.wasUpdated = value;
		}
	}

	internal XStoreRateAndReviewResult(Unity.XGamingRuntime.Interop.XStoreRateAndReviewResult interop)
	{
		this.interop = interop;
	}

	public XStoreRateAndReviewResult()
	{
		interop = default;
	}
}
