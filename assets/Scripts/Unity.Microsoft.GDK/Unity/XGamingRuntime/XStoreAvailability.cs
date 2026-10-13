using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime;

[MovedFrom("Unity.GameCore")]
public class XStoreAvailability
{
	internal Unity.XGamingRuntime.Interop.XStoreAvailability _interop;

	internal XStorePrice _xstorePrice;

	internal Unity.XGamingRuntime.Interop.XStoreAvailability interop
	{
		get
		{
			_interop.price = _xstorePrice.interop;
			return _interop;
		}
		set
		{
			_interop = value;
		}
	}

	public string AvailabilityId
	{
		get
		{
			return _interop.availabilityId;
		}
		set
		{
			_interop.availabilityId = value;
		}
	}

	public XStorePrice Price
	{
		get
		{
			return _xstorePrice;
		}
		set
		{
			_interop.price = value.interop;
			_xstorePrice = value;
		}
	}

	public long EndDate
	{
		get
		{
			return _interop.endDate;
		}
		set
		{
			_interop.endDate = value;
		}
	}

	internal XStoreAvailability(Unity.XGamingRuntime.Interop.XStoreAvailability interop)
	{
		_xstorePrice = new XStorePrice(interop.price);
		_interop = interop;
	}

	public XStoreAvailability()
	{
		_xstorePrice = new XStorePrice();
		_interop = default;
		_interop.price = _xstorePrice.interop;
	}
}
