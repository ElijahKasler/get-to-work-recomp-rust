using System;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime;

[Flags]
[MovedFrom("Unity.GameCore")]
public enum XblSocialManagerExtraDetailLevel : uint
{
	NoExtraDetail = 0u,
	TitleHistoryLevel = 1u,
	PreferredColorLevel = 2u,
	All = TitleHistoryLevel | PreferredColorLevel
}
