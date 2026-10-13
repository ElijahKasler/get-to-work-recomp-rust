using UnityEngine.Rendering.RenderGraphModule;

namespace UnityEngine.Rendering.Universal;

internal class ClearTargetsPass
{
	private class PassData
	{
		internal TextureHandle color;

		internal TextureHandle depth;

		internal RTClearFlags clearFlags;

		internal Color clearColor;
	}

	private static ProfilingSampler s_ClearProfilingSampler = new ProfilingSampler("Clear Targets");

	internal static void Render(RenderGraph graph, TextureHandle colorHandle, TextureHandle depthHandle, UniversalCameraData cameraData)
	{
		RTClearFlags rTClearFlags = RTClearFlags.None;
		if (cameraData.renderType == CameraRenderType.Base)
		{
			rTClearFlags = RTClearFlags.All;
		}
		else if (cameraData.clearDepth)
		{
			rTClearFlags = RTClearFlags.Depth;
		}
		if (rTClearFlags != RTClearFlags.None)
		{
			Render(graph, colorHandle, depthHandle, rTClearFlags, cameraData.backgroundColor);
		}
	}

	internal static void Render(RenderGraph graph, TextureHandle colorHandle, TextureHandle depthHandle, RTClearFlags clearFlags, Color clearColor)
	{
		PassData passData;
		using IRasterRenderGraphBuilder rasterRenderGraphBuilder = graph.AddRasterRenderPass<PassData>("Clear Targets Pass", out passData, s_ClearProfilingSampler, "C:\\Users\\steph\\GameDev\\GetToWork2\\GetToWork\\Library\\PackageCache\\com.unity.render-pipelines.universal@7652a5c7e246\\Runtime\\UniversalRendererRenderGraph.cs", 1919);
		if (colorHandle.IsValid())
		{
			passData.color = colorHandle;
			rasterRenderGraphBuilder.SetRenderAttachment(colorHandle, 0);
		}
		if (depthHandle.IsValid())
		{
			passData.depth = depthHandle;
			rasterRenderGraphBuilder.SetRenderAttachmentDepth(depthHandle);
		}
		passData.clearFlags = clearFlags;
		passData.clearColor = clearColor;
		rasterRenderGraphBuilder.AllowPassCulling(value: false);
		rasterRenderGraphBuilder.SetRenderFunc((PassData data, RasterGraphContext context) =>
		{
			context.cmd.ClearRenderTarget(data.clearFlags, data.clearColor, 1f, 0u);
		});
	}
}
