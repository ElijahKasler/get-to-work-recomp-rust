using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace UnityEngine.Rendering.RenderGraphModule.NativeRenderPassCompiler;

[DebuggerDisplay("PassFragmentData: Res({resource.index}):{accessFlags}")]
internal struct PassFragmentData
{
	public ResourceHandle resource;

	public AccessFlags accessFlags;

	public int mipLevel;

	public int depthSlice;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public override int GetHashCode()
	{
		return ((resource.GetHashCode() * 23 + accessFlags.GetHashCode()) * 23 + mipLevel.GetHashCode()) * 23 + depthSlice.GetHashCode();
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool SameSubResource(in PassFragmentData x, in PassFragmentData y)
	{
		if (x.resource.index == y.resource.index && x.mipLevel == y.mipLevel)
		{
			return x.depthSlice == y.depthSlice;
		}
		return false;
	}
}
