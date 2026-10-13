using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime;

[MovedFrom("Unity.GameCore")]
public class XblMultiplayerSessionReference
{
	public string Scid { get; }

	public string SessionTemplateName { get; }

	public string SessionName { get; }

	internal XblMultiplayerSessionReference(Unity.XGamingRuntime.Interop.XblMultiplayerSessionReference interopStruct)
	{
		Scid = interopStruct.GetScid();
		SessionTemplateName = interopStruct.GetSessionTemplateName();
		SessionName = interopStruct.GetSessionName();
	}
}
