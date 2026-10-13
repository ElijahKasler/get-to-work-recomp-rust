using Unity.XGamingRuntime.Interop;

namespace Unity.XGamingRuntime;

public class XStoreConsumableResult
{
	internal Unity.XGamingRuntime.Interop.XStoreConsumableResult interop;

	public uint Quantity
	{
		get
		{
			return interop.quantity;
		}
		set
		{
			interop.quantity = value;
		}
	}

	internal XStoreConsumableResult(Unity.XGamingRuntime.Interop.XStoreConsumableResult interop)
	{
		this.interop = interop;
	}

	public XStoreConsumableResult()
	{
		interop = default;
	}
}
