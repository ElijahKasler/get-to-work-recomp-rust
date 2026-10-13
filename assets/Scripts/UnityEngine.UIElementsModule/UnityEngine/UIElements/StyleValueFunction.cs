using UnityEngine.Bindings;

namespace UnityEngine.UIElements;

[VisibleToOtherModules(new string[] { "UnityEditor.UIBuilderModule" })]
internal enum StyleValueFunction
{
	Unknown = 0,
	Var = 1,
	Env = 2,
	LinearGradient = 3
}
