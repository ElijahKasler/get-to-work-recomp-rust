namespace Unity.XGamingRuntime.Interop;

internal struct XblMultiplayerSessionMemberRole
{
	internal UTF8StringPtr roleTypeName;

	internal UTF8StringPtr roleName;

	internal XblMultiplayerSessionMemberRole(Unity.XGamingRuntime.XblMultiplayerSessionMemberRole publicObject, DisposableCollection disposableCollection)
	{
		roleTypeName = new UTF8StringPtr(publicObject.RoleTypeName, disposableCollection);
		roleName = new UTF8StringPtr(publicObject.RoleName, disposableCollection);
	}
}
