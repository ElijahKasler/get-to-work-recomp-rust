using System.Diagnostics;

namespace UnityEngine.Rendering.RenderGraphModule.NativeRenderPassCompiler;

[DebuggerDisplay("PassOutputData: Res({resource.index})")]
internal struct PassOutputData
{
	public ResourceHandle resource;
}
