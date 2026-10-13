using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime;

[MovedFrom("Unity.GameCore")]
public enum XPackageEnumerationScope : uint
{
	ThisOnly = 0u,
	ThisAndRelated = 1u,
	ThisPublisher = 2u
}
