using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime;

[MovedFrom("Unity.GameCore")]
public enum XblMultiplayerSessionWriteMode
{
	CreateNew = 0,
	UpdateOrCreateNew = 1,
	UpdateExisting = 2,
	SynchronizedUpdate = 3
}
