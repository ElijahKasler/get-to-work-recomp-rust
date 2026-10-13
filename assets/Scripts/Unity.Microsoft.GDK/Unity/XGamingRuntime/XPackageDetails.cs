using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime;

[MovedFrom("Unity.GameCore")]
public class XPackageDetails
{
	internal Unity.XGamingRuntime.Interop.XPackageDetails interop;

	internal XVersion _XVersion;

	public string PackageIdentifier
	{
		get
		{
			return interop.packageIdentifier;
		}
		set
		{
			interop.packageIdentifier = value;
		}
	}

	public XVersion Version
	{
		get
		{
			return _XVersion;
		}
		set
		{
			_XVersion = value;
		}
	}

	public XPackageKind Kind
	{
		get
		{
			return interop.kind;
		}
		set
		{
			interop.kind = value;
		}
	}

	public string DisplayName
	{
		get
		{
			return interop.displayName;
		}
		set
		{
			interop.displayName = value;
		}
	}

	public string Description
	{
		get
		{
			return interop.description;
		}
		set
		{
			interop.description = value;
		}
	}

	public string Publisher
	{
		get
		{
			return interop.publisher;
		}
		set
		{
			interop.publisher = value;
		}
	}

	public string StoreId
	{
		get
		{
			return interop.storeId;
		}
		set
		{
			interop.storeId = value;
		}
	}

	public bool Installing
	{
		get
		{
			return interop.installing;
		}
		set
		{
			interop.installing = value;
		}
	}

	internal XPackageDetails(Unity.XGamingRuntime.Interop.XPackageDetails interop)
	{
		this.interop = interop;
		_XVersion = new XVersion(interop.version);
	}

	public XPackageDetails()
	{
		interop = default;
		_XVersion = new XVersion();
	}
}
