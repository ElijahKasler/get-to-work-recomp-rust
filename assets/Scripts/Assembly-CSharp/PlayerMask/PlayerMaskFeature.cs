using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.RenderGraphModule;
using UnityEngine.Rendering.Universal;

namespace PlayerMask;

public class PlayerMaskFeature : ScriptableRendererFeature
{
	public class PlayerMaskData : ContextItem
	{
		public TextureHandle mask;

		public RendererListHandle rendererList;

		public override void Reset()
		{
			mask = TextureHandle.nullHandle;
		}
	}

	private class RenderObjectsPass : ScriptableRenderPass
	{
		private FilteringSettings _filteringSettings;

		private RenderStateBlock _renderStateBlock;

		private List<ShaderTagId> _shaderTagIdList = new List<ShaderTagId>();

		private Material _drawingMat;

		private Shader _drawingShader;

		private PlayerMaskFeature _settings;

		private static readonly int _SSPlayerMaskId = Shader.PropertyToID("_SSPlayerMask");

		public RenderObjectsPass(int layerMask, PlayerMaskFeature settings)
		{
			_settings = settings;
			_filteringSettings = new FilteringSettings(RenderQueueRange.opaque, layerMask);
			_renderStateBlock = new RenderStateBlock(RenderStateMask.Nothing)
			{
				mask = RenderStateMask.Depth,
				depthState = new DepthState(writeEnabled: false, CompareFunction.LessEqual)
			};
			_drawingShader = Resources.Load<Shader>("PlayerMask");
			_drawingMat = CoreUtils.CreateEngineMaterial(_drawingShader);
			_shaderTagIdList.Add(new ShaderTagId("SRPDefaultUnlit"));
			_shaderTagIdList.Add(new ShaderTagId("UniversalForward"));
			_shaderTagIdList.Add(new ShaderTagId("UniversalForwardOnly"));
		}

		public override void OnCameraSetup(CommandBuffer cmd, ref RenderingData renderingData)
		{
			RenderTextureDescriptor cameraTargetDescriptor = renderingData.cameraData.cameraTargetDescriptor;
			cameraTargetDescriptor.depthBufferBits = 0;
		}

		public override void RecordRenderGraph(RenderGraph renderGraph, ContextContainer frameData)
		{
			if (_drawingMat == null)
			{
				return;
			}
			PlayerMaskData passData;
			using IRasterRenderGraphBuilder rasterRenderGraphBuilder = renderGraph.AddRasterRenderPass<PlayerMaskData>("Player Mask", out passData, "C:\\Users\\steph\\GameDev\\GetToWork2\\GetToWork\\Assets\\Scripts\\Camera\\PlayerMask\\PlayerMaskFeature.cs", 84);
			UniversalResourceData universalResourceData = frameData.Get<UniversalResourceData>();
			UniversalCameraData universalCameraData = frameData.Get<UniversalCameraData>();
			UniversalRenderingData universalRenderingData = frameData.Get<UniversalRenderingData>();
			UniversalLightData lightData = frameData.Get<UniversalLightData>();
			PlayerMaskData playerMaskData = frameData.Create<PlayerMaskData>();
			RenderTextureDescriptor cameraTargetDescriptor = universalCameraData.cameraTargetDescriptor;
			cameraTargetDescriptor.depthBufferBits = 0;
			rasterRenderGraphBuilder.SetRenderAttachment(playerMaskData.mask = (passData.mask = UniversalRenderer.CreateRenderGraphTexture(renderGraph, cameraTargetDescriptor, "Player Mask", clear: false)), 0);
			rasterRenderGraphBuilder.SetRenderAttachmentDepth(universalResourceData.activeDepthTexture);
			DrawingSettings drawSettings = RenderingUtils.CreateDrawingSettings(_shaderTagIdList, universalRenderingData, universalCameraData, lightData, universalCameraData.defaultOpaqueSortFlags);
			drawSettings.overrideShader = null;
			drawSettings.overrideShaderPassIndex = 0;
			drawSettings.overrideMaterial = _drawingMat;
			drawSettings.overrideMaterialPassIndex = 0;
			RendererListParams desc = new RendererListParams(universalRenderingData.cullResults, drawSettings, _filteringSettings);
			passData.rendererList = renderGraph.CreateRendererList(in desc);
			rasterRenderGraphBuilder.UseRendererList(in passData.rendererList);
			rasterRenderGraphBuilder.AllowPassCulling(value: false);
			rasterRenderGraphBuilder.AllowGlobalStateModification(value: true);
			rasterRenderGraphBuilder.SetRenderFunc<PlayerMaskData>(RenderFunc);
			rasterRenderGraphBuilder.SetGlobalTextureAfterPass(in passData.mask, _SSPlayerMaskId);
		}

		private void RenderFunc(PlayerMaskData data, RasterGraphContext ctx)
		{
			ctx.cmd.ClearRenderTarget(clearDepth: false, clearColor: true, Color.black);
			ctx.cmd.DrawRendererList(data.rendererList);
		}
	}

	public RenderPassEvent Event = RenderPassEvent.AfterRenderingOpaques;

	public LayerMask LayerMask;

	private RenderObjectsPass _pass;

	public override void Create()
	{
		_pass = new RenderObjectsPass(LayerMask, this);
	}

	public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
	{
		if (_pass != null)
		{
			_pass.renderPassEvent = Event;
			renderer.EnqueuePass(_pass);
		}
	}
}
