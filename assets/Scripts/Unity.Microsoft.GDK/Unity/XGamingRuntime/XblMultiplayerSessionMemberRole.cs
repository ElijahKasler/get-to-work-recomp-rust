using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime;

[MovedFrom("Unity.GameCore")]
public class XblMultiplayerSessionMemberRole
{
	public string RoleTypeName { get; }

	public string RoleName { get; }

	internal Unity.XGamingRuntime.Interop.XblMultiplayerSessionMemberRole InteropHandle { get; }

	internal XblMultiplayerSessionMemberRole(Unity.XGamingRuntime.Interop.XblMultiplayerSessionMemberRole interopHandle)
	{
		InteropHandle = interopHandle;
		RoleTypeName = interopHandle.roleTypeName.GetString();
		RoleName = interopHandle.roleName.GetString();
	}
}
