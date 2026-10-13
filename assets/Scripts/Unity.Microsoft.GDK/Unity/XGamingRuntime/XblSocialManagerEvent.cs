using System;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime;

[MovedFrom("Unity.GameCore")]
public class XblSocialManagerEvent
{
	public XUserHandle User { get; private set; }

	public XblSocialManagerEventType EventType { get; private set; }

	public int Hr { get; private set; }

	public XblSocialManagerUserGroupHandle LoadedGroup { get; private set; }

	public XblSocialManagerUser[] UsersAffected { get; private set; }

	internal XblSocialManagerEvent(Unity.XGamingRuntime.Interop.XblSocialManagerEvent interopEvent)
	{
		User = new XUserHandle(interopEvent.user, ownsHandle: false);
		EventType = interopEvent.eventType;
		Hr = interopEvent.hr;
		LoadedGroup = new XblSocialManagerUserGroupHandle(interopEvent.loadedGroup);
		UsersAffected = Array.ConvertAll(interopEvent.GetUserArray(), (Unity.XGamingRuntime.Interop.XblSocialManagerUser u) => new XblSocialManagerUser(u));
	}
}
