using PlayerMask;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.RenderGraphModule;
using UnityEngine.Rendering.Universal;

namespace PlayerShadow;

public class PlayerShadowFeature : ScriptableRendererFeature
{
	private class PlayerShadowPass : ScriptableRenderPass
	{
		private class PassData
		{
			public TextureHandle source;

			public TextureHandle destination;
		}

		private Material drawMat;

		private PlayerShadowFeature feature;

		private ProfilingSampler m_ProfilingSampler;

		public PlayerShadowPass(PlayerShadowFeature feature)
		{
			this.feature = feature;
		}

		public bool Initialize()
		{
			if (drawMat != null)
			{
				Object.DestroyImmediate(drawMat);
				drawMat = null;
			}
			Shader shader = Resources.Load<Shader>("PlayerShadowSS");
			if (shader == null)
			{
				return false;
			}
			drawMat = new Material(shader);
			m_ProfilingSampler = new ProfilingSampler("Player Shadow Pass");
			return true;
		}

		public override void RecordRenderGraph(RenderGraph renderGraph, ContextContainer frameData)
		{
			PassData passData;
			using IUnsafeRenderGraphBuilder unsafeRenderGraphBuilder = renderGraph.AddUnsafePass<PassData>("Player Shadow Pass", out passData, "C:\\Users\\steph\\GameDev\\GetToWork2\\GetToWork\\Assets\\Scripts\\Camera\\PlayerShadow\\PlayerShadowFeature.cs", 70);
			UniversalResourceData universalResourceData = frameData.Get<UniversalResourceData>();
			UniversalCameraData universalCameraData = frameData.Get<UniversalCameraData>();
			UniversalRenderingData universalRenderingData = frameData.Get<UniversalRenderingData>();
			PlayerMaskFeature.PlayerMaskData orCreate = frameData.GetOrCreate<PlayerMaskFeature.PlayerMaskData>();
			if (orCreate.mask.IsValid())
			{
				TextureHandle source = ((universalRenderingData.renderingMode == RenderingMode.Deferred) ? universalResourceData.activeColorTexture : universalResourceData.cameraColor);
				RenderTextureDescriptor cameraTargetDescriptor = universalCameraData.cameraTargetDescriptor;
				cameraTargetDescriptor.depthBufferBits = 0;
				passData.source = source;
				passData.destination = UniversalRenderer.CreateRenderGraphTexture(renderGraph, cameraTargetDescriptor, "Player Shadow Color Target", clear: false);
				unsafeRenderGraphBuilder.UseTexture(in passData.source, AccessFlags.ReadWrite);
				unsafeRenderGraphBuilder.UseTexture(in passData.destination, AccessFlags.ReadWrite);
				unsafeRenderGraphBuilder.UseTexture(in orCreate.mask);
				unsafeRenderGraphBuilder.AllowPassCulling(value: false);
				unsafeRenderGraphBuilder.SetRenderFunc<PassData>(RenderFunc);
			}
		}

		private void RenderFunc(PassData data, UnsafeGraphContext context)
		{
			CommandBuffer nativeCommandBuffer = CommandBufferHelpers.GetNativeCommandBuffer(context.cmd);
			Blitter.BlitTexture(nativeCommandBuffer, data.source, data.destination, drawMat, 0);
			Blitter.BlitTexture(nativeCommandBuffer, data.destination, data.source, drawMat, 1);
		}
	}

	public RenderPassEvent injectEvent = RenderPassEvent.AfterRenderingShadows;

	public RenderTexture debug;

	private PlayerShadowPass pass;

	public override void Create()
	{
		if (pass == null)
		{
			pass = new PlayerShadowPass(this);
		}
	}

	public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
	{
		if (pass.Initialize())
		{
			pass.renderPassEvent = injectEvent;
			renderer.EnqueuePass(pass);
		}
		else
		{
			Debug.LogError("Failed to initialize PlayerShadowPass");
		}
	}
}
