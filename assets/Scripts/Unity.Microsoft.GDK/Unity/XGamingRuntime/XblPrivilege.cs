using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime;

[MovedFrom("Unity.GameCore")]
public enum XblPrivilege : uint
{
	Unknown = 0u,
	AllowIngameVoiceCommunications = 205u,
	AllowVideoCommunications = 235u,
	AllowProfileViewing = 249u,
	AllowCommunications = 252u,
	AllowMultiplayer = 254u,
	AllowAddFriend = 255u
}
