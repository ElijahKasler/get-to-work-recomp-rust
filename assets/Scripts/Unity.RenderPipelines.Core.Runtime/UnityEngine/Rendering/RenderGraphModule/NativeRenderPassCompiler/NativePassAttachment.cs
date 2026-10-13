using System.Diagnostics;

namespace UnityEngine.Rendering.RenderGraphModule.NativeRenderPassCompiler;

[DebuggerDisplay("Res({handle.index}) : {loadAction} : {storeAction} : {memoryless}")]
internal struct NativePassAttachment
{
	public ResourceHandle handle;

	public RenderBufferLoadAction loadAction;

	public RenderBufferStoreAction storeAction;

	public bool memoryless;

	public int mipLevel;

	public int depthSlice;
}
