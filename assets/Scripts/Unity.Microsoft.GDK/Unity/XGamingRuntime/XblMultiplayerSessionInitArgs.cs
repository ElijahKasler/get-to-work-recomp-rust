using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime;

[MovedFrom("Unity.GameCore")]
public class XblMultiplayerSessionInitArgs
{
	public uint MaxMembersInSession { get; set; }

	public XblMultiplayerSessionVisibility Visibility { get; set; }

	public ulong[] InitiatorXuids { get; set; }

	public string CustomJson { get; set; }
}
