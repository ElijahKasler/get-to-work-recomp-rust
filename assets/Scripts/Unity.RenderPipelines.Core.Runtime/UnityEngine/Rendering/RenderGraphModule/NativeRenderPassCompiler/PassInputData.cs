using System.Diagnostics;

namespace UnityEngine.Rendering.RenderGraphModule.NativeRenderPassCompiler;

[DebuggerDisplay("PassInputData: Res({resource.index})")]
internal struct PassInputData
{
	public ResourceHandle resource;
}
