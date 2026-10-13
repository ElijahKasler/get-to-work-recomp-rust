using UnityEngine.Bindings;
using UnityEngine.Scripting;

namespace UnityEngine.VFX;

[RequiredByNativeCode]
[NativeType(Header = "Modules/VFX/Public/VFXRenderer.h")]
[RejectDragAndDropMaterial]
public sealed class VFXRenderer : Renderer
{
	[RequiredMember]
	public VFXRenderer()
	{
	}
}
