using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime;

[MovedFrom("Unity.GameCore")]
public class XblPermissionCheckResult
{
	public bool IsAllowed { get; private set; }

	public ulong TargetXuid { get; private set; }

	public XblAnonymousUserType TargetUserType { get; private set; }

	public XblPermission PermissionRequested { get; private set; }

	public XblPermissionDenyReasonDetails[] Reasons { get; private set; }

	internal XblPermissionCheckResult(Unity.XGamingRuntime.Interop.XblPermissionCheckResult interopStruct)
	{
		IsAllowed = interopStruct.isAllowed.Value;
		TargetXuid = interopStruct.targetXuid;
		TargetUserType = interopStruct.targetUserType;
		PermissionRequested = interopStruct.permissionRequested;
		Reasons = interopStruct.GetReasons((Unity.XGamingRuntime.Interop.XblPermissionDenyReasonDetails x) => new XblPermissionDenyReasonDetails(x));
	}
}
