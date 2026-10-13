using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime;

[MovedFrom("Unity.GameCore")]
public enum XblTicketStatus
{
	Unknown = 0,
	Expired = 1,
	Searching = 2,
	Found = 3,
	Canceled = 4
}
