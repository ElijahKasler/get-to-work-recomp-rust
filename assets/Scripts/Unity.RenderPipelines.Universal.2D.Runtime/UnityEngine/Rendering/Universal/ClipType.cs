using System;

namespace UnityEngine.Rendering.Universal;

[Obsolete("Will be removed in 2025.1", true)]
public enum ClipType
{
	ctIntersection = 0,
	ctUnion = 1,
	ctDifference = 2,
	ctXor = 3
}
