using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime;

[MovedFrom("Unity.GameCore")]
public class XblMultiplayerInviteHandle
{
	public string Data { get; }

	internal XblMultiplayerInviteHandle(Unity.XGamingRuntime.Interop.XblMultiplayerInviteHandle interopStruct)
	{
		Data = interopStruct.GetData();
	}
}
