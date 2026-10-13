using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime;

[MovedFrom("Unity.GameCore")]
public enum XStoreCanLicenseStatus : uint
{
	NotLicensableToUser = 0u,
	Licensable = 1u,
	LicenseActionNotApplicableToProduct = 2u
}
