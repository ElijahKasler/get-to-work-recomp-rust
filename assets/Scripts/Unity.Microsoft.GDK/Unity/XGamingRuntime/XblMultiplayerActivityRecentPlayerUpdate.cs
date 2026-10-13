using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime;

[MovedFrom("Unity.GameCore")]
public class XblMultiplayerActivityRecentPlayerUpdate
{
	public ulong Xuid { get; set; }

	public XblMultiplayerActivityEncounterType EncounterType { get; set; }
}
