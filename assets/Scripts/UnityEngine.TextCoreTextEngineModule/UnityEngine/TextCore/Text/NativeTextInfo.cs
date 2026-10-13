using UnityEngine.Bindings;

namespace UnityEngine.TextCore.Text;

[VisibleToOtherModules(new string[] { "UnityEngine.UIElementsModule", "UnityEngine.IMGUIModule" })]
[NativeHeader("Modules/TextCoreTextEngine/Native/TextInfo.h")]
internal struct NativeTextInfo
{
	public ATGMeshInfo[] meshInfos;
}
