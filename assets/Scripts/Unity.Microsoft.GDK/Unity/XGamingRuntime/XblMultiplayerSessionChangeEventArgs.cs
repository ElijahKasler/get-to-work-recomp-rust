using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime;

[MovedFrom("Unity.GameCore")]
public class XblMultiplayerSessionChangeEventArgs
{
	public XblMultiplayerSessionReference SessionReference { get; }

	public string Branch { get; }

	public ulong ChangeNumber { get; }

	internal XblMultiplayerSessionChangeEventArgs(Unity.XGamingRuntime.Interop.XblMultiplayerSessionChangeEventArgs interopStruct)
	{
		SessionReference = new XblMultiplayerSessionReference(interopStruct.SessionReference);
		Branch = interopStruct.GetBranch();
		ChangeNumber = interopStruct.ChangeNumber;
	}
}
