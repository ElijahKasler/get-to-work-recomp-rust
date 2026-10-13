using System;

namespace UnityEngine.Rendering;

[Flags]
public enum SubPassFlags
{
	None = 0,
	ReadOnlyDepth = 2,
	ReadOnlyStencil = 4,
	ReadOnlyDepthStencil = ReadOnlyDepth | ReadOnlyStencil
}
