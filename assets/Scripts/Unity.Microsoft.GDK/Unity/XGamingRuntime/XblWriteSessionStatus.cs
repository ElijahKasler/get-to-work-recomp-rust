using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime;

[MovedFrom("Unity.GameCore")]
public enum XblWriteSessionStatus
{
	Unknown = 0,
	AccessDenied = 1,
	Created = 2,
	Conflict = 3,
	HandleNotFound = 4,
	OutOfSync = 5,
	SessionDeleted = 6,
	Updated = 7
}
