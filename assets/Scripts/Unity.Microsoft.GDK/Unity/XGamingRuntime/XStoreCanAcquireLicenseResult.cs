using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime;

[MovedFrom("Unity.GameCore")]
public class XStoreCanAcquireLicenseResult
{
	internal Unity.XGamingRuntime.Interop.XStoreCanAcquireLicenseResult interop;

	public string LicensableSku
	{
		get
		{
			return interop.licensableSku;
		}
		set
		{
			interop.licensableSku = value;
		}
	}

	public XStoreCanLicenseStatus Status
	{
		get
		{
			return interop.status;
		}
		set
		{
			interop.status = value;
		}
	}

	internal XStoreCanAcquireLicenseResult(Unity.XGamingRuntime.Interop.XStoreCanAcquireLicenseResult interop)
	{
		this.interop = interop;
	}

	public XStoreCanAcquireLicenseResult()
	{
		interop = default;
	}
}
