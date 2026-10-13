using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.RenderGraphModule;
using UnityEngine.Rendering.Universal;

namespace VolumetricLights;

public class VolumetricLightsRenderFeature : ScriptableRendererFeature
{
	private static class ShaderParams
	{
		public static int LightBuffer = Shader.PropertyToID("_LightBuffer");

		public static int MainTex = Shader.PropertyToID("_MainTex");

		public static int BlurRT = Shader.PropertyToID("_BlurTex");

		public static int BlurRT2 = Shader.PropertyToID("_BlurTex2");

		public static int BlendDest = Shader.PropertyToID("_BlendDest");

		public static int BlendSrc = Shader.PropertyToID("_BlendSrc");

		public static int BlendOp = Shader.PropertyToID("_BlendOp");

		public static int MiscData = Shader.PropertyToID("_MiscData");

		public static int ForcedInvisible = Shader.PropertyToID("_ForcedLightInvisible");

		public static int DownsampledDepth = Shader.PropertyToID("_DownsampledDepth");

		public static int BlueNoiseTexture = Shader.PropertyToID("_BlueNoise");

		public static int BlurScale = Shader.PropertyToID("_BlurScale");

		public static int Downscaling = Shader.PropertyToID("_Downscaling");

		public static int CameraNormalsTexture = Shader.PropertyToID("_CameraNormalsTexture");

		public static int CameraGBuffer0 = Shader.PropertyToID("_GBuffer0");

		public static int CameraGBuffer1 = Shader.PropertyToID("_GBuffer1");

		public const string SKW_DITHER = "DITHER";

		public const string SKW_EDGE_PRESERVE = "EDGE_PRESERVE";

		public const string SKW_EDGE_PRESERVE_UPSCALING = "EDGE_PRESERVE_UPSCALING";
	}

	private class VolumetricLightsRenderPass : ScriptableRenderPass
	{
		private class PassData
		{
			public RendererListHandle rendererListHandle;

			public UniversalCameraData cameraData;

			public TextureHandle cameraNormalsTexture;

			public TextureHandle gBuffer0;

			public TextureHandle gBuffer1;
		}

		private const int renderingLayer = 262144;

		private const string m_ProfilerTag = "Volumetric Lights Buffer Rendering";

		private const string m_LightBufferName = "_LightBuffer";

		private FilteringSettings filteringSettings = new FilteringSettings(RenderQueueRange.transparent);

		private readonly List<ShaderTagId> shaderTagIdList = new List<ShaderTagId>();

		private static VolumetricLightsRenderFeature settings;

		private RTHandle m_LightBuffer;

		public VolumetricLightsRenderPass()
		{
			shaderTagIdList.Clear();
			shaderTagIdList.Add(new ShaderTagId("UniversalForward"));
			RenderTargetIdentifier tex = new RenderTargetIdentifier(ShaderParams.LightBuffer, 0, CubemapFace.Unknown, -1);
			m_LightBuffer = RTHandles.Alloc(tex, "_LightBuffer");
		}

		public void CleanUp()
		{
			RTHandles.Release(m_LightBuffer);
		}

		public void Setup(VolumetricLightsRenderFeature settings)
		{
			VolumetricLightsRenderPass.settings = settings;
			base.renderPassEvent = settings.renderPassEvent;
		}

		[Obsolete]
		public override void Configure(CommandBuffer cmd, RenderTextureDescriptor cameraTextureDescriptor)
		{
			RenderTextureDescriptor desc = cameraTextureDescriptor;
			if (settings.blendMode != BlendMode.Additive)
			{
				desc.colorFormat = RenderTextureFormat.ARGBHalf;
			}
			desc.width = GetScaledSize(cameraTextureDescriptor.width, settings.downscaling);
			desc.height = GetScaledSize(cameraTextureDescriptor.height, settings.downscaling);
			desc.depthBufferBits = 0;
			desc.useMipMap = false;
			desc.msaaSamples = 1;
			cmd.GetTemporaryRT(ShaderParams.LightBuffer, desc, FilterMode.Bilinear);
			ConfigureTarget(m_LightBuffer);
			ConfigureClear(ClearFlag.Color, new Color(0f, 0f, 0f, 0f));
			ConfigureInput(ScriptableRenderPassInput.Depth);
		}

		[Obsolete]
		public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
		{
			CommandBuffer commandBuffer = CommandBufferPool.Get("Volumetric Lights Buffer Rendering");
			commandBuffer.SetGlobalInt(ShaderParams.ForcedInvisible, 0);
			context.ExecuteCommandBuffer(commandBuffer);
			if ((settings.downscaling <= 1f && settings.blurPasses < 1) || VolumetricLight.volumetricLights.Count == 0)
			{
				CommandBufferPool.Release(commandBuffer);
				return;
			}
			foreach (VolumetricLight volumetricLight in VolumetricLight.volumetricLights)
			{
				if (volumetricLight != null && volumetricLight.meshRenderer != null)
				{
					volumetricLight.meshRenderer.renderingLayerMask = 262144u;
				}
			}
			commandBuffer.Clear();
			SortingCriteria sortingCriteria = SortingCriteria.CommonTransparent;
			DrawingSettings drawingSettings = CreateDrawingSettings(shaderTagIdList, ref renderingData, sortingCriteria);
			FilteringSettings filteringSettings = this.filteringSettings;
			filteringSettings.renderingLayerMask = 262144u;
			context.DrawRenderers(renderingData.cullResults, ref drawingSettings, ref filteringSettings);
			commandBuffer.SetGlobalTexture(value: new RenderTargetIdentifier(ShaderParams.LightBuffer, 0, CubemapFace.Unknown, -1), nameID: ShaderParams.LightBuffer);
			CommandBufferPool.Release(commandBuffer);
		}

		public override void RecordRenderGraph(RenderGraph renderGraph, ContextContainer frameData)
		{
			PassData passData;
			using IUnsafeRenderGraphBuilder unsafeRenderGraphBuilder = renderGraph.AddUnsafePass<PassData>("Volumetric Lights Buffer Rendering", out passData, "C:\\Users\\steph\\GameDev\\GetToWork2\\GetToWork\\Assets\\VolumetricLights\\Scripts\\VolumetricLightsRenderFeature.cs", 144);
			unsafeRenderGraphBuilder.AllowPassCulling(value: false);
			UniversalResourceData universalResourceData = frameData.Get<UniversalResourceData>();
			UniversalRenderingData universalRenderingData = frameData.Get<UniversalRenderingData>();
			UniversalLightData lightData = frameData.Get<UniversalLightData>();
			UniversalCameraData cameraData = (passData.cameraData = frameData.Get<UniversalCameraData>());
			unsafeRenderGraphBuilder.UseTexture(universalResourceData.activeDepthTexture);
			ConfigureInput(ScriptableRenderPassInput.Depth);
			if (universalResourceData.cameraNormalsTexture.IsValid())
			{
				unsafeRenderGraphBuilder.UseTexture(universalResourceData.cameraNormalsTexture);
				passData.cameraNormalsTexture = universalResourceData.cameraNormalsTexture;
			}
			if (universalResourceData.gBuffer[0].IsValid())
			{
				unsafeRenderGraphBuilder.UseTexture(in universalResourceData.gBuffer[0]);
				passData.gBuffer0 = universalResourceData.gBuffer[0];
			}
			if (universalResourceData.gBuffer[1].IsValid())
			{
				unsafeRenderGraphBuilder.UseTexture(in universalResourceData.gBuffer[1]);
				passData.gBuffer1 = universalResourceData.gBuffer[1];
			}
			SortingCriteria sortingCriteria = SortingCriteria.CommonTransparent;
			DrawingSettings drawSettings = CreateDrawingSettings(shaderTagIdList, universalRenderingData, cameraData, lightData, sortingCriteria);
			FilteringSettings filteringSettings = this.filteringSettings;
			filteringSettings.renderingLayerMask = 262144u;
			RendererListParams desc = new RendererListParams(universalRenderingData.cullResults, drawSettings, filteringSettings);
			passData.rendererListHandle = renderGraph.CreateRendererList(in desc);
			unsafeRenderGraphBuilder.UseRendererList(in passData.rendererListHandle);
			unsafeRenderGraphBuilder.SetRenderFunc((PassData passData2, UnsafeGraphContext context) =>
			{
				CommandBuffer nativeCommandBuffer = CommandBufferHelpers.GetNativeCommandBuffer(context.cmd);
				RenderTextureDescriptor cameraTargetDescriptor = passData2.cameraData.cameraTargetDescriptor;
				if (settings.blendMode != BlendMode.Additive)
				{
					cameraTargetDescriptor.colorFormat = RenderTextureFormat.ARGBHalf;
				}
				cameraTargetDescriptor.width = GetScaledSize(cameraTargetDescriptor.width, settings.downscaling);
				cameraTargetDescriptor.height = GetScaledSize(cameraTargetDescriptor.height, settings.downscaling);
				cameraTargetDescriptor.depthBufferBits = 0;
				cameraTargetDescriptor.useMipMap = false;
				cameraTargetDescriptor.msaaSamples = 1;
				nativeCommandBuffer.GetTemporaryRT(ShaderParams.LightBuffer, cameraTargetDescriptor, FilterMode.Bilinear);
				RenderTargetIdentifier renderTargetIdentifier = new RenderTargetIdentifier(ShaderParams.LightBuffer, 0, CubemapFace.Unknown, -1);
				nativeCommandBuffer.SetRenderTarget(renderTargetIdentifier);
				nativeCommandBuffer.ClearRenderTarget(clearDepth: false, clearColor: true, new Color(0f, 0f, 0f, 0f));
				nativeCommandBuffer.SetGlobalInt(ShaderParams.ForcedInvisible, 0);
				if ((!(settings.downscaling <= 1f) || settings.blurPasses >= 1) && VolumetricLight.volumetricLights.Count != 0)
				{
					if (passData2.cameraNormalsTexture.IsValid())
					{
						nativeCommandBuffer.SetGlobalTexture(ShaderParams.CameraNormalsTexture, passData2.cameraNormalsTexture);
					}
					if (passData2.gBuffer0.IsValid())
					{
						nativeCommandBuffer.SetGlobalTexture(ShaderParams.CameraGBuffer0, passData2.gBuffer0);
					}
					if (passData2.gBuffer1.IsValid())
					{
						nativeCommandBuffer.SetGlobalTexture(ShaderParams.CameraGBuffer1, passData2.gBuffer1);
					}
					foreach (VolumetricLight volumetricLight in VolumetricLight.volumetricLights)
					{
						if (volumetricLight != null && volumetricLight.meshRenderer != null)
						{
							volumetricLight.meshRenderer.renderingLayerMask = 262144u;
						}
					}
					nativeCommandBuffer.DrawRendererList(passData2.rendererListHandle);
					nativeCommandBuffer.SetGlobalTexture(ShaderParams.LightBuffer, renderTargetIdentifier);
				}
			});
		}
	}

	private class BlurRenderPass : ScriptableRenderPass
	{
		private enum Pass
		{
			BlurHorizontal = 0,
			BlurVertical = 1,
			BlurVerticalAndBlend = 2,
			Blend = 3,
			DownscaleDepth = 4,
			BlurVerticalFinal = 5
		}

		private class PassData
		{
			public RTHandle source;

			public TextureHandle colorTexture;
		}

		private const string m_strProfilerTag = "Volumetric Lights Render Feature";

		private ScriptableRenderer renderer;

		private static Material mat;

		private static RenderTextureDescriptor sourceDesc;

		private static VolumetricLightsRenderFeature settings;

		private readonly PassData passData = new PassData();

		private static Mesh _fullScreenMesh;

		private static Mesh fullscreenMesh
		{
			get
			{
				if (_fullScreenMesh != null)
				{
					return _fullScreenMesh;
				}
				float y = 1f;
				float y2 = 0f;
				_fullScreenMesh = new Mesh();
				_fullScreenMesh.SetVertices(new List<Vector3>
				{
					new Vector3(-1f, -1f, 0f),
					new Vector3(-1f, 1f, 0f),
					new Vector3(1f, -1f, 0f),
					new Vector3(1f, 1f, 0f)
				});
				_fullScreenMesh.SetUVs(0, new List<Vector2>
				{
					new Vector2(0f, y2),
					new Vector2(0f, y),
					new Vector2(1f, y2),
					new Vector2(1f, y)
				});
				_fullScreenMesh.SetIndices(new int[6] { 0, 1, 2, 2, 1, 3 }, MeshTopology.Triangles, 0, calculateBounds: false);
				_fullScreenMesh.UploadMeshData(markNoLongerReadable: true);
				return _fullScreenMesh;
			}
		}

		public void Setup(Shader shader, ScriptableRenderer renderer, VolumetricLightsRenderFeature settings)
		{
			BlurRenderPass.settings = settings;
			base.renderPassEvent = settings.renderPassEvent;
			this.renderer = renderer;
			if (mat == null)
			{
				mat = CoreUtils.CreateEngineMaterial(shader);
				Texture2D value = Resources.Load<Texture2D>("Textures/blueNoiseVL128");
				mat.SetTexture(ShaderParams.BlueNoiseTexture, value);
			}
			switch (settings.blendMode)
			{
			case BlendMode.Additive:
				mat.SetInt(ShaderParams.BlendOp, 0);
				mat.SetInt(ShaderParams.BlendSrc, 1);
				mat.SetInt(ShaderParams.BlendDest, 1);
				break;
			case BlendMode.Blend:
				mat.SetInt(ShaderParams.BlendOp, 0);
				mat.SetInt(ShaderParams.BlendSrc, 1);
				mat.SetInt(ShaderParams.BlendDest, 10);
				break;
			case BlendMode.PreMultiply:
				mat.SetInt(ShaderParams.BlendOp, 0);
				mat.SetInt(ShaderParams.BlendSrc, 5);
				mat.SetInt(ShaderParams.BlendDest, 1);
				break;
			case BlendMode.Substractive:
				mat.SetInt(ShaderParams.BlendOp, 2);
				mat.SetInt(ShaderParams.BlendSrc, 1);
				mat.SetInt(ShaderParams.BlendDest, 1);
				break;
			}
			mat.SetVector(ShaderParams.MiscData, new Vector4(settings.ditherStrength * 0.1f, settings.brightness, settings.blurEdgeDepthThreshold, 0f));
			if (settings.ditherStrength > 0f)
			{
				mat.EnableKeyword("DITHER");
			}
			else
			{
				mat.DisableKeyword("DITHER");
			}
			mat.DisableKeyword("EDGE_PRESERVE");
			mat.DisableKeyword("EDGE_PRESERVE_UPSCALING");
			if (settings.blurPasses > 0 && settings.blurEdgePreserve)
			{
				mat.EnableKeyword((settings.downscaling > 1f) ? "EDGE_PRESERVE_UPSCALING" : "EDGE_PRESERVE");
			}
		}

		[Obsolete]
		public override void Configure(CommandBuffer cmd, RenderTextureDescriptor cameraTextureDescriptor)
		{
			sourceDesc = cameraTextureDescriptor;
			ConfigureInput(ScriptableRenderPassInput.Depth);
		}

		[Obsolete]
		public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
		{
			passData.source = renderer.cameraColorTargetHandle;
			CommandBuffer commandBuffer = CommandBufferPool.Get("Volumetric Lights Render Feature");
			ExecutePass(passData, commandBuffer);
			context.ExecuteCommandBuffer(commandBuffer);
			CommandBufferPool.Release(commandBuffer);
		}

		public override void RecordRenderGraph(RenderGraph renderGraph, ContextContainer frameData)
		{
			PassData passData;
			using IUnsafeRenderGraphBuilder unsafeRenderGraphBuilder = renderGraph.AddUnsafePass<PassData>("Volumetric Lights Render Feature", out passData, "C:\\Users\\steph\\GameDev\\GetToWork2\\GetToWork\\Assets\\VolumetricLights\\Scripts\\VolumetricLightsRenderFeature.cs", 337);
			unsafeRenderGraphBuilder.AllowPassCulling(value: false);
			UniversalResourceData universalResourceData = frameData.Get<UniversalResourceData>();
			frameData.Get<UniversalRenderingData>();
			frameData.Get<UniversalLightData>();
			UniversalCameraData universalCameraData = frameData.Get<UniversalCameraData>();
			passData.colorTexture = universalResourceData.activeColorTexture;
			unsafeRenderGraphBuilder.UseTexture(universalResourceData.activeColorTexture, AccessFlags.ReadWrite);
			unsafeRenderGraphBuilder.UseTexture(universalResourceData.activeDepthTexture);
			ConfigureInput(ScriptableRenderPassInput.Depth);
			sourceDesc = universalCameraData.cameraTargetDescriptor;
			unsafeRenderGraphBuilder.SetRenderFunc((PassData passData2, UnsafeGraphContext context) =>
			{
				CommandBuffer nativeCommandBuffer = CommandBufferHelpers.GetNativeCommandBuffer(context.cmd);
				passData2.source = passData2.colorTexture;
				ExecutePass(passData2, nativeCommandBuffer);
			});
		}

		private static void ExecutePass(PassData passData, CommandBuffer cmd)
		{
			if (settings.downscaling <= 1f && settings.blurPasses < 1)
			{
				Cleanup();
				return;
			}
			RTHandle source = passData.source;
			cmd.SetGlobalInt(ShaderParams.ForcedInvisible, 1);
			RenderTextureDescriptor renderTextureDescriptor = sourceDesc;
			renderTextureDescriptor.width = GetScaledSize(sourceDesc.width, settings.downscaling);
			renderTextureDescriptor.height = GetScaledSize(sourceDesc.height, settings.downscaling);
			renderTextureDescriptor.useMipMap = false;
			renderTextureDescriptor.colorFormat = (settings.blurHDR ? RenderTextureFormat.ARGBHalf : RenderTextureFormat.ARGB32);
			renderTextureDescriptor.msaaSamples = 1;
			renderTextureDescriptor.depthBufferBits = 0;
			bool flag = settings.downscaling > 1f;
			if (flag)
			{
				RenderTextureDescriptor desc = renderTextureDescriptor;
				desc.colorFormat = RenderTextureFormat.RHalf;
				cmd.GetTemporaryRT(ShaderParams.DownsampledDepth, desc, FilterMode.Bilinear);
				FullScreenBlit(cmd, source, ShaderParams.DownsampledDepth, mat, 4);
			}
			if (settings.blurPasses < 1)
			{
				cmd.SetGlobalFloat(ShaderParams.BlurScale, settings.blurSpread);
				FullScreenBlit(cmd, ShaderParams.LightBuffer, source, mat, 3);
			}
			else
			{
				renderTextureDescriptor.width = GetScaledSize(renderTextureDescriptor.width, settings.blurDownscaling);
				renderTextureDescriptor.height = GetScaledSize(renderTextureDescriptor.height, settings.blurDownscaling);
				cmd.GetTemporaryRT(ShaderParams.BlurRT, renderTextureDescriptor, FilterMode.Bilinear);
				cmd.GetTemporaryRT(ShaderParams.BlurRT2, renderTextureDescriptor, FilterMode.Bilinear);
				cmd.SetGlobalFloat(ShaderParams.BlurScale, settings.blurSpread * settings.blurDownscaling);
				FullScreenBlit(cmd, ShaderParams.LightBuffer, ShaderParams.BlurRT, mat, 0);
				cmd.SetGlobalFloat(ShaderParams.BlurScale, settings.blurSpread);
				for (int i = 0; i < settings.blurPasses - 1; i++)
				{
					FullScreenBlit(cmd, ShaderParams.BlurRT, ShaderParams.BlurRT2, mat, 1);
					FullScreenBlit(cmd, ShaderParams.BlurRT2, ShaderParams.BlurRT, mat, 0);
				}
				if (flag)
				{
					FullScreenBlit(cmd, ShaderParams.BlurRT, ShaderParams.BlurRT2, mat, 5);
					FullScreenBlit(cmd, ShaderParams.BlurRT2, source, mat, 3);
				}
				else
				{
					FullScreenBlit(cmd, ShaderParams.BlurRT, source, mat, 2);
				}
				cmd.ReleaseTemporaryRT(ShaderParams.BlurRT2);
				cmd.ReleaseTemporaryRT(ShaderParams.BlurRT);
			}
			cmd.ReleaseTemporaryRT(ShaderParams.LightBuffer);
			if (flag)
			{
				cmd.ReleaseTemporaryRT(ShaderParams.DownsampledDepth);
			}
		}

		private static void FullScreenBlit(CommandBuffer cmd, RenderTargetIdentifier source, RenderTargetIdentifier destination, Material material, int passIndex)
		{
			destination = new RenderTargetIdentifier(destination, 0, CubemapFace.Unknown, -1);
			cmd.SetRenderTarget(destination);
			cmd.SetGlobalTexture(ShaderParams.MainTex, source);
			cmd.DrawMesh(fullscreenMesh, Matrix4x4.identity, material, 0, passIndex);
		}

		public static void Cleanup()
		{
			CoreUtils.Destroy(mat);
			Shader.SetGlobalInt(ShaderParams.ForcedInvisible, 0);
		}
	}

	[SerializeField]
	[HideInInspector]
	private Shader shader;

	private VolumetricLightsRenderPass vlRenderPass;

	private BlurRenderPass blurRenderPass;

	public static bool installed;

	public BlendMode blendMode;

	public RenderPassEvent renderPassEvent = RenderPassEvent.BeforeRenderingTransparents;

	[Range(1f, 4f)]
	public float downscaling = 1f;

	[Range(0f, 4f)]
	public int blurPasses = 1;

	[Range(1f, 4f)]
	public float blurDownscaling = 1f;

	[Range(0.1f, 4f)]
	public float blurSpread = 1f;

	[Tooltip("Uses 32 bit floating point pixel format for rendering & blur fog volumes.")]
	public bool blurHDR = true;

	[Tooltip("Enable to use an edge-aware blur.")]
	public bool blurEdgePreserve;

	[Tooltip("Bilateral filter edge detection threshold.")]
	public float blurEdgeDepthThreshold = 0.001f;

	public float brightness = 1f;

	[Range(0f, 0.2f)]
	public float ditherStrength;

	private static int GetScaledSize(int size, float factor)
	{
		size = (int)((float)size / factor);
		size /= 2;
		if (size < 1)
		{
			size = 1;
		}
		return size * 2;
	}

	private void OnDisable()
	{
		installed = false;
		if (blurRenderPass != null)
		{
			BlurRenderPass.Cleanup();
		}
		Shader.SetGlobalFloat(ShaderParams.Downscaling, 0f);
	}

	private void OnValidate()
	{
		brightness = Mathf.Max(0f, brightness);
		ditherStrength = Mathf.Clamp(ditherStrength, 0f, 0.2f);
		blurEdgeDepthThreshold = Mathf.Max(0.0001f, blurEdgeDepthThreshold);
		if (!base.isActive)
		{
			OnDisable();
		}
	}

	private void OnDestroy()
	{
		if (vlRenderPass != null)
		{
			vlRenderPass.CleanUp();
		}
	}

	public override void Create()
	{
		base.name = "Volumetric Lights";
		vlRenderPass = new VolumetricLightsRenderPass();
		blurRenderPass = new BlurRenderPass();
		shader = Shader.Find("Hidden/VolumetricLights/Blur");
		_ = shader == null;
	}

	public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
	{
		Camera camera = renderingData.cameraData.camera;
		if (!(camera.targetTexture != null) || camera.targetTexture.format != RenderTextureFormat.Depth)
		{
			bool flag = downscaling > 1f || blurPasses > 0;
			Shader.SetGlobalInt(ShaderParams.ForcedInvisible, flag ? 1 : 0);
			Shader.SetGlobalFloat(ShaderParams.Downscaling, downscaling - 1f);
			vlRenderPass.Setup(this);
			blurRenderPass.Setup(shader, renderer, this);
			renderer.EnqueuePass(vlRenderPass);
			renderer.EnqueuePass(blurRenderPass);
			installed = true;
		}
	}
}
