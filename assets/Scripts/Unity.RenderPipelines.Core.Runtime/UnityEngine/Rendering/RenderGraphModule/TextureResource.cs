using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace UnityEngine.Rendering.RenderGraphModule;

[DebuggerDisplay("TextureResource ({desc.name})")]
internal class TextureResource : RenderGraphResource<TextureDesc, RTHandle>
{
	private static int m_TextureCreationIndex;

	public override string GetName()
	{
		if (imported && !shared)
		{
			if (graphicsResource == null)
			{
				return "null resource";
			}
			return graphicsResource.name;
		}
		return desc.name;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public override int GetDescHashCode()
	{
		return desc.GetHashCode();
	}

	public override void CreateGraphicsResource()
	{
		string text = GetName();
		if (text == "")
		{
			text = $"RenderGraphTexture_{m_TextureCreationIndex++}";
		}
		switch (desc.sizeMode)
		{
		case TextureSizeMode.Explicit:
			graphicsResource = RTHandles.Alloc(desc.width, desc.height, desc.format, desc.slices, desc.filterMode, desc.wrapMode, desc.dimension, desc.enableRandomWrite, desc.useMipMap, desc.autoGenerateMips, desc.isShadowMap, desc.anisoLevel, desc.mipMapBias, desc.msaaSamples, desc.bindTextureMS, desc.useDynamicScale, desc.useDynamicScaleExplicit, desc.memoryless, desc.vrUsage, text);
			break;
		case TextureSizeMode.Scale:
			graphicsResource = RTHandles.Alloc(desc.scale, desc.format, desc.slices, desc.filterMode, desc.wrapMode, desc.dimension, desc.enableRandomWrite, desc.useMipMap, desc.autoGenerateMips, desc.isShadowMap, desc.anisoLevel, desc.mipMapBias, desc.msaaSamples, desc.bindTextureMS, desc.useDynamicScale, desc.useDynamicScaleExplicit, desc.memoryless, desc.vrUsage, text);
			break;
		case TextureSizeMode.Functor:
			graphicsResource = RTHandles.Alloc(desc.func, desc.format, desc.slices, desc.filterMode, desc.wrapMode, desc.dimension, desc.enableRandomWrite, desc.useMipMap, desc.autoGenerateMips, desc.isShadowMap, desc.anisoLevel, desc.mipMapBias, desc.msaaSamples, desc.bindTextureMS, desc.useDynamicScale, desc.useDynamicScaleExplicit, desc.memoryless, desc.vrUsage, text);
			break;
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public override void UpdateGraphicsResource()
	{
		if (graphicsResource != null)
		{
			graphicsResource.m_Name = GetName();
		}
	}

	public override void ReleaseGraphicsResource()
	{
		if (graphicsResource != null)
		{
			graphicsResource.Release();
		}
		base.ReleaseGraphicsResource();
	}

	public override void LogCreation(RenderGraphLogger logger)
	{
		logger.LogLine($"Created Texture: {desc.name} (Cleared: {desc.clearBuffer})");
	}

	public override void LogRelease(RenderGraphLogger logger)
	{
		logger.LogLine("Released Texture: " + desc.name);
	}
}
