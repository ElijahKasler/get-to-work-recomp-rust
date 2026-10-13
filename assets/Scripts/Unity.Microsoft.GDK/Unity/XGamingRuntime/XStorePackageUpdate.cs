using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime;

[MovedFrom("Unity.GameCore")]
public class XStorePackageUpdate
{
	internal Unity.XGamingRuntime.Interop.XStorePackageUpdate interop;

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

	public bool IsMandatory
	{
		get
		{
			return interop.isMandatory;
		}
		set
		{
			interop.isMandatory = value;
		}
	}

	internal XStorePackageUpdate(Unity.XGamingRuntime.Interop.XStorePackageUpdate interop)
	{
		this.interop = interop;
	}

	public XStorePackageUpdate()
	{
		interop = default;
	}
}
