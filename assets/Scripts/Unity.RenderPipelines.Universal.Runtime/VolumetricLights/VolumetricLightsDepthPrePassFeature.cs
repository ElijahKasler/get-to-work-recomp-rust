using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.RenderGraphModule;
using UnityEngine.Rendering.Universal;

namespace VolumetricLights;

public class VolumetricLightsDepthPrePassFeature : ScriptableRendererFeature
{
	private static class ShaderParams
	{
		public static int MainTex = Shader.PropertyToID("_MainTex");

		public static int CustomDepthTexture = Shader.PropertyToID("_CustomDepthTexture");

		public static int CustomDepthAlphaCutoff = Shader.PropertyToID("_AlphaCutOff");

		public static int CustomDepthBaseMap = Shader.PropertyToID("_BaseMap");

		public const string SKW_DEPTH_PREPASS = "VF2_DEPTH_PREPASS";

		public const string SKW_CUSTOM_DEPTH_ALPHA_TEST = "DEPTH_PREPASS_ALPHA_TEST";
	}

	public class DepthRenderPass : ScriptableRenderPass
	{
		private class PassData
		{
			public RendererListHandle rendererListHandle;

			public UniversalCameraData cameraData;
		}

		public VolumetricLightsDepthPrePassFeature settings;

		private const string m_ProfilerTag = "CustomDepthPrePass";

		private const string m_DepthOnlyShader = "Hidden/VolumetricLights/DepthOnly";

		private const string m_CustomDepthTextureName = "_CustomDepthTexture";

		private static FilteringSettings filterSettings;

		private int currentCutoutLayerMask;

		private static readonly List<ShaderTagId> shaderTagIdList = new List<ShaderTagId>();

		private readonly List<Renderer> cutOutRenderers = new List<Renderer>();

		private RTHandle m_Depth;

		private Material depthOnlyMaterial;

		private Material depthOnlyMaterialCutOff;

		private Material[] depthOverrideMaterials;

		public DepthRenderPass(VolumetricLightsDepthPrePassFeature settings)
		{
			this.settings = settings;
			base.renderPassEvent = RenderPassEvent.AfterRenderingOpaques;
			m_Depth = RTHandles.Alloc(ShaderParams.CustomDepthTexture, "_CustomDepthTexture");
			shaderTagIdList.Clear();
			shaderTagIdList.Add(new ShaderTagId("SRPDefaultUnlit"));
			shaderTagIdList.Add(new ShaderTagId("UniversalForward"));
			shaderTagIdList.Add(new ShaderTagId("LightweightForward"));
			filterSettings = new FilteringSettings(RenderQueueRange.transparent, 0);
			SetupKeywords();
			FindAlphaClippingRenderers();
		}

		private void SetupKeywords()
		{
			if ((int)settings.transparentLayerMask != 0 || (int)settings.alphaCutoutLayerMask != 0)
			{
				Shader.EnableKeyword("VF2_DEPTH_PREPASS");
			}
			else
			{
				Shader.DisableKeyword("VF2_DEPTH_PREPASS");
			}
		}

		private void FindAlphaClippingRenderers()
		{
			cutOutRenderers.Clear();
			if ((int)settings.alphaCutoutLayerMask == 0)
			{
				return;
			}
			Renderer[] array = Misc.FindObjectsOfType<Renderer>();
			for (int i = 0; i < array.Length; i++)
			{
				if (((1 << array[i].gameObject.layer) & (int)settings.alphaCutoutLayerMask) != 0)
				{
					cutOutRenderers.Add(array[i]);
				}
			}
		}

		[Obsolete]
		public override void Configure(CommandBuffer cmd, RenderTextureDescriptor cameraTextureDescriptor)
		{
			if ((int)settings.transparentLayerMask != filterSettings.layerMask || (int)settings.alphaCutoutLayerMask != currentCutoutLayerMask)
			{
				filterSettings = new FilteringSettings(RenderQueueRange.transparent, settings.transparentLayerMask);
				if ((int)settings.alphaCutoutLayerMask != currentCutoutLayerMask)
				{
					FindAlphaClippingRenderers();
				}
				currentCutoutLayerMask = settings.alphaCutoutLayerMask;
				SetupKeywords();
			}
			RenderTextureDescriptor desc = cameraTextureDescriptor;
			desc.colorFormat = RenderTextureFormat.Depth;
			desc.depthBufferBits = 24;
			desc.msaaSamples = 1;
			cmd.GetTemporaryRT(ShaderParams.CustomDepthTexture, desc, FilterMode.Point);
			cmd.SetGlobalTexture(ShaderParams.CustomDepthTexture, m_Depth);
			ConfigureTarget(m_Depth);
			ConfigureClear(ClearFlag.All, Color.black);
		}

		[Obsolete]
		public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
		{
			if ((int)settings.transparentLayerMask == 0 && (int)settings.alphaCutoutLayerMask == 0)
			{
				return;
			}
			CommandBuffer commandBuffer = CommandBufferPool.Get("CustomDepthPrePass");
			context.ExecuteCommandBuffer(commandBuffer);
			commandBuffer.Clear();
			if ((int)settings.alphaCutoutLayerMask != 0)
			{
				if (depthOnlyMaterialCutOff == null)
				{
					Shader shader = Shader.Find("Hidden/VolumetricLights/DepthOnly");
					depthOnlyMaterialCutOff = new Material(shader);
				}
				int count = cutOutRenderers.Count;
				if (depthOverrideMaterials == null || depthOverrideMaterials.Length < count)
				{
					depthOverrideMaterials = new Material[count];
				}
				for (int i = 0; i < count; i++)
				{
					Renderer renderer = cutOutRenderers[i];
					if (!(renderer != null) || !renderer.isVisible)
					{
						continue;
					}
					Material sharedMaterial = renderer.sharedMaterial;
					if (sharedMaterial != null)
					{
						if (depthOverrideMaterials[i] == null)
						{
							depthOverrideMaterials[i] = UnityEngine.Object.Instantiate(depthOnlyMaterialCutOff);
							depthOverrideMaterials[i].EnableKeyword("DEPTH_PREPASS_ALPHA_TEST");
						}
						Material material = depthOverrideMaterials[i];
						material.SetFloat(ShaderParams.CustomDepthAlphaCutoff, settings.alphaCutOff);
						if (sharedMaterial.HasProperty(ShaderParams.CustomDepthBaseMap))
						{
							material.SetTexture(ShaderParams.MainTex, sharedMaterial.GetTexture(ShaderParams.CustomDepthBaseMap));
						}
						else if (sharedMaterial.HasProperty(ShaderParams.MainTex))
						{
							material.SetTexture(ShaderParams.MainTex, sharedMaterial.GetTexture(ShaderParams.MainTex));
						}
						commandBuffer.DrawRenderer(renderer, material);
					}
				}
			}
			if ((int)settings.transparentLayerMask != 0)
			{
				SortingCriteria sortingCriteria = SortingCriteria.CommonTransparent;
				DrawingSettings drawingSettings = CreateDrawingSettings(shaderTagIdList, ref renderingData, sortingCriteria);
				drawingSettings.perObjectData = PerObjectData.None;
				if (depthOnlyMaterial == null)
				{
					Shader shader2 = Shader.Find("Hidden/VolumetricLights/DepthOnly");
					depthOnlyMaterial = new Material(shader2);
				}
				drawingSettings.overrideMaterial = depthOnlyMaterial;
				context.DrawRenderers(renderingData.cullResults, ref drawingSettings, ref filterSettings);
			}
			context.ExecuteCommandBuffer(commandBuffer);
			CommandBufferPool.Release(commandBuffer);
		}

		public override void RecordRenderGraph(RenderGraph renderGraph, ContextContainer frameData)
		{
			if ((int)settings.transparentLayerMask == 0 && (int)settings.alphaCutoutLayerMask == 0)
			{
				SetupKeywords();
				return;
			}
			PassData passData;
			using IUnsafeRenderGraphBuilder unsafeRenderGraphBuilder = renderGraph.AddUnsafePass<PassData>("CustomDepthPrePass", out passData, "C:\\Users\\steph\\GameDev\\GetToWork2\\GetToWork\\Assets\\VolumetricLights\\Scripts\\VolumetricLightsDepthPrePassFeature.cs", 173);
			unsafeRenderGraphBuilder.AllowPassCulling(value: false);
			frameData.Get<UniversalResourceData>();
			UniversalRenderingData universalRenderingData = frameData.Get<UniversalRenderingData>();
			UniversalLightData lightData = frameData.Get<UniversalLightData>();
			UniversalCameraData cameraData = (passData.cameraData = frameData.Get<UniversalCameraData>());
			SortingCriteria sortingCriteria = SortingCriteria.CommonTransparent;
			DrawingSettings drawSettings = CreateDrawingSettings(shaderTagIdList, universalRenderingData, cameraData, lightData, sortingCriteria);
			drawSettings.perObjectData = PerObjectData.None;
			if (depthOnlyMaterial == null)
			{
				Shader shader = Shader.Find("Hidden/VolumetricLights/DepthOnly");
				depthOnlyMaterial = new Material(shader);
			}
			drawSettings.overrideMaterial = depthOnlyMaterial;
			RendererListParams desc = new RendererListParams(universalRenderingData.cullResults, drawSettings, filterSettings);
			passData.rendererListHandle = renderGraph.CreateRendererList(in desc);
			unsafeRenderGraphBuilder.UseRendererList(in passData.rendererListHandle);
			unsafeRenderGraphBuilder.SetRenderFunc((PassData passData2, UnsafeGraphContext context) =>
			{
				CommandBuffer nativeCommandBuffer = CommandBufferHelpers.GetNativeCommandBuffer(context.cmd);
				if ((int)settings.transparentLayerMask != filterSettings.layerMask || (int)settings.alphaCutoutLayerMask != currentCutoutLayerMask)
				{
					filterSettings = new FilteringSettings(RenderQueueRange.transparent, settings.transparentLayerMask);
					if ((int)settings.alphaCutoutLayerMask != currentCutoutLayerMask)
					{
						FindAlphaClippingRenderers();
					}
					currentCutoutLayerMask = settings.alphaCutoutLayerMask;
					SetupKeywords();
				}
				RenderTextureDescriptor cameraTargetDescriptor = passData2.cameraData.cameraTargetDescriptor;
				cameraTargetDescriptor.colorFormat = RenderTextureFormat.Depth;
				cameraTargetDescriptor.depthBufferBits = 24;
				cameraTargetDescriptor.msaaSamples = 1;
				nativeCommandBuffer.GetTemporaryRT(ShaderParams.CustomDepthTexture, cameraTargetDescriptor, FilterMode.Point);
				nativeCommandBuffer.SetGlobalTexture(ShaderParams.CustomDepthTexture, m_Depth);
				RenderTargetIdentifier renderTarget = new RenderTargetIdentifier(ShaderParams.CustomDepthTexture, 0, CubemapFace.Unknown, -1);
				nativeCommandBuffer.SetRenderTarget(renderTarget);
				nativeCommandBuffer.ClearRenderTarget(clearDepth: true, clearColor: true, Color.black);
				if ((int)settings.alphaCutoutLayerMask != 0)
				{
					if (depthOnlyMaterialCutOff == null)
					{
						Shader shader2 = Shader.Find("Hidden/VolumetricLights/DepthOnly");
						depthOnlyMaterialCutOff = new Material(shader2);
					}
					int count = cutOutRenderers.Count;
					if (depthOverrideMaterials == null || depthOverrideMaterials.Length < count)
					{
						depthOverrideMaterials = new Material[count];
					}
					for (int i = 0; i < count; i++)
					{
						Renderer renderer = cutOutRenderers[i];
						if (renderer != null && renderer.isVisible)
						{
							Material sharedMaterial = renderer.sharedMaterial;
							if (sharedMaterial != null)
							{
								if (depthOverrideMaterials[i] == null)
								{
									depthOverrideMaterials[i] = UnityEngine.Object.Instantiate(depthOnlyMaterialCutOff);
									depthOverrideMaterials[i].EnableKeyword("DEPTH_PREPASS_ALPHA_TEST");
								}
								Material material = depthOverrideMaterials[i];
								material.SetFloat(ShaderParams.CustomDepthAlphaCutoff, settings.alphaCutOff);
								if (sharedMaterial.HasProperty(ShaderParams.CustomDepthBaseMap))
								{
									material.SetTexture(ShaderParams.MainTex, sharedMaterial.GetTexture(ShaderParams.CustomDepthBaseMap));
								}
								else if (sharedMaterial.HasProperty(ShaderParams.MainTex))
								{
									material.SetTexture(ShaderParams.MainTex, sharedMaterial.GetTexture(ShaderParams.MainTex));
								}
								nativeCommandBuffer.DrawRenderer(renderer, material);
							}
						}
					}
				}
				if ((int)settings.transparentLayerMask != 0)
				{
					nativeCommandBuffer.DrawRendererList(passData2.rendererListHandle);
				}
			});
		}

		public override void FrameCleanup(CommandBuffer cmd)
		{
			cmd?.ReleaseTemporaryRT(ShaderParams.CustomDepthTexture);
		}

		public void CleanUp()
		{
			RTHandles.Release(m_Depth);
		}
	}

	[Tooltip("Optionally specify which transparent layers must be included in the depth prepass. Use only to avoid fog clipping with certain transparent objects.")]
	public LayerMask transparentLayerMask;

	[Tooltip("Optionally specify which semi-transparent (materials using alpha clipping or cut-off) must be included in the depth prepass. Use only to avoid fog clipping with certain transparent objects.")]
	public LayerMask alphaCutoutLayerMask;

	[Tooltip("Optionally determines the alpha cut off for semitransparent objects.")]
	[Range(0f, 1f)]
	public float alphaCutOff;

	[Tooltip("If this depth pre-pass render feature can execute on reflection probes.")]
	public bool ignoreReflectionProbes = true;

	private DepthRenderPass m_ScriptablePass;

	public static bool installed;

	public override void Create()
	{
		m_ScriptablePass = new DepthRenderPass(this);
	}

	private void OnDestroy()
	{
		installed = false;
		if (m_ScriptablePass != null)
		{
			m_ScriptablePass.CleanUp();
		}
		Shader.DisableKeyword("VF2_DEPTH_PREPASS");
	}

	public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
	{
		Camera camera = renderingData.cameraData.camera;
		if ((!(camera.targetTexture != null) || camera.targetTexture.format != RenderTextureFormat.Depth) && (!ignoreReflectionProbes || camera.cameraType != CameraType.Reflection))
		{
			installed = true;
			renderer.EnqueuePass(m_ScriptablePass);
		}
	}
}
