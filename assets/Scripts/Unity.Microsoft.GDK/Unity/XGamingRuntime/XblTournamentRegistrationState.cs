using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime;

[MovedFrom("Unity.GameCore")]
public enum XblTournamentRegistrationState : uint
{
	Unknown = 0u,
	Pending = 1u,
	Withdrawn = 2u,
	Rejected = 3u,
	Registered = 4u,
	Completed = 5u
}
