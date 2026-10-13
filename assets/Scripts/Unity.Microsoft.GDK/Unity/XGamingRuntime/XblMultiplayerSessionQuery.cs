using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime;

[MovedFrom("Unity.GameCore")]
public class XblMultiplayerSessionQuery
{
	public string Scid { get; set; }

	public uint MaxItems { get; set; }

	public bool IncludePrivateSessions { get; set; }

	public bool IncludeReservations { get; set; }

	public bool IncludeInactiveSessions { get; set; }

	public ulong[] XuidFilters { get; set; }

	public string KeywordFilter { get; set; }

	public string SessionTemplateNameFilter { get; set; }

	public XblMultiplayerSessionVisibility VisibilityFilter { get; set; }

	public uint ContractVersionFilter { get; set; }
}
