using UnityEngine.Bindings;

namespace UnityEngine.UIElements;

[VisibleToOtherModules(new string[] { "UnityEditor.UIBuilderModule" })]
internal enum DispatchMode
{
	Default = 1,
	Queued = Default,
	Immediate = 2
}
