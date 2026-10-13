using System.Diagnostics;

namespace UnityEngine.Rendering.RenderGraphModule.NativeRenderPassCompiler;

[DebuggerDisplay("PassRandomWriteData: Res({resource.index}):{index}:{preserveCounterValue}")]
internal struct PassRandomWriteData
{
	public ResourceHandle resource;

	public int index;

	public bool preserveCounterValue;

	public override int GetHashCode()
	{
		return resource.GetHashCode() * 23 + index.GetHashCode();
	}
}
