using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime;

[MovedFrom("Unity.GameCore")]
public class XblPermissionDenyReasonDetails
{
	public XblPermissionDenyReason Reason { get; private set; }

	public XblPrivilege RestrictedPrivilege { get; private set; }

	public XblPrivacySetting RestrictedPrivacySetting { get; private set; }

	internal XblPermissionDenyReasonDetails(Unity.XGamingRuntime.Interop.XblPermissionDenyReasonDetails interopStruct)
	{
		Reason = interopStruct.reason;
		RestrictedPrivilege = interopStruct.restrictedPrivilege;
		RestrictedPrivacySetting = interopStruct.restrictedPrivacySetting;
	}
}
