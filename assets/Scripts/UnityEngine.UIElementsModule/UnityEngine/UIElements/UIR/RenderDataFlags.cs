using System;

namespace UnityEngine.UIElements.UIR;

[Flags]
internal enum RenderDataFlags
{
	IsInChain = 1,
	IsGroupTransform = 2,
	IsIgnoringDynamicColorHint = 4,
	HasExtraData = 8,
	HasExtraMeshes = 0x10
}
