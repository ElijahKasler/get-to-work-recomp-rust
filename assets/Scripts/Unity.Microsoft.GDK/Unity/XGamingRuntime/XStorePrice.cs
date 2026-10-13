using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime;

[MovedFrom("Unity.GameCore")]
public class XStorePrice
{
	internal Unity.XGamingRuntime.Interop.XStorePrice interop;

	public float BasePrice
	{
		get
		{
			return interop.basePrice;
		}
		set
		{
			interop.basePrice = value;
		}
	}

	public float Price
	{
		get
		{
			return interop.price;
		}
		set
		{
			interop.price = value;
		}
	}

	public float RecurrencePrice
	{
		get
		{
			return interop.recurrencePrice;
		}
		set
		{
			interop.recurrencePrice = value;
		}
	}

	public string CurrencyCode
	{
		get
		{
			return interop.currencyCode;
		}
		set
		{
			interop.currencyCode = value;
		}
	}

	public string FormattedBasePrice
	{
		get
		{
			return interop.formattedBasePrice;
		}
		set
		{
			interop.formattedBasePrice = value;
		}
	}

	public string FormattedPrice
	{
		get
		{
			return interop.formattedPrice;
		}
		set
		{
			interop.formattedPrice = value;
		}
	}

	public string FormattedRecurrencePrice
	{
		get
		{
			return interop.formattedRecurrencePrice;
		}
		set
		{
			interop.formattedRecurrencePrice = value;
		}
	}

	public bool IsOnSale
	{
		get
		{
			return interop.isOnSale;
		}
		set
		{
			interop.isOnSale = value;
		}
	}

	public long SaleEndDate
	{
		get
		{
			return interop.saleEndDate;
		}
		set
		{
			interop.saleEndDate = value;
		}
	}

	internal XStorePrice(Unity.XGamingRuntime.Interop.XStorePrice interop)
	{
		this.interop = interop;
	}

	public XStorePrice()
	{
		interop = default;
	}
}
