using UnityEngine.Experimental.Rendering;
using UnityEngine.Rendering.RenderGraphModule;
using UnityEngine.Rendering.Universal.Internal;

namespace UnityEngine.Rendering.Universal;

internal class DBufferCopyDepthPass : CopyDepthPass
{
	public DBufferCopyDepthPass(RenderPassEvent evt, Shader copyDepthShader, bool shouldClear = false, bool copyToDepth = false, bool copyResolvedDepth = false)
		: base(evt, copyDepthShader, shouldClear, copyToDepth, copyResolvedDepth)
	{
	}

	public override void RecordRenderGraph(RenderGraph renderGraph, ContextContainer frameData)
	{
		UniversalResourceData universalResourceData = frameData.Get<UniversalResourceData>();
		UniversalCameraData universalCameraData = frameData.Get<UniversalCameraData>();
		UniversalRenderer obj = universalCameraData.renderer as UniversalRenderer;
		bool flag = obj.renderingModeActual == RenderingMode.Deferred;
		bool useDepthPriming = obj.useDepthPriming;
		bool flag2 = universalCameraData.cameraTargetDescriptor.msaaSamples > 1;
		if (!flag && (!useDepthPriming || flag2))
		{
			RenderTextureDescriptor cameraTargetDescriptor = universalCameraData.cameraTargetDescriptor;
			cameraTargetDescriptor.graphicsFormat = GraphicsFormat.None;
			cameraTargetDescriptor.depthStencilFormat = universalCameraData.cameraTargetDescriptor.depthStencilFormat;
			cameraTargetDescriptor.msaaSamples = 1;
			universalResourceData.dBufferDepth = UniversalRenderer.CreateRenderGraphTexture(renderGraph, cameraTargetDescriptor, DBufferRenderPass.s_DBufferDepthName, clear: true);
			Render(renderGraph, universalResourceData.dBufferDepth, universalResourceData.cameraDepthTexture, universalResourceData, universalCameraData, bindAsCameraDepth: false, "Copy DBuffer Depth");
		}
	}
}
