using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.RenderGraphModule;
using UnityEngine.Rendering.Universal;

namespace VolumetricLights;

public class VolumetricLightsTranslucentShadowMapFeature : ScriptableRendererFeature
{
	private static class ShaderParams
	{
		public static int MainTex = Shader.PropertyToID("_MainTex");

		public static int CustomTranspBaseMap = Shader.PropertyToID("_BaseMap");

		public static int TranslucencyIntensity = Shader.PropertyToID("_TranslucencyIntensity");

		public static int MainTex_ST = Shader.PropertyToID("_MainTex_ST");

		public static int Color = Shader.PropertyToID("_Color");
	}

	public class TranspRenderPass : ScriptableRenderPass
	{
		private class PassData
		{
			public RTHandle source;

			public TextureHandle depthTexture;
		}

		public VolumetricLightsTranslucentShadowMapFeature settings;

		private const string m_strProfilerTag = "TranslucencyPrePass";

		private const string m_TranspShader = "Hidden/VolumetricLights/TransparentMultiply";

		private const string m_TranspDepthOnlyShader = "Hidden/VolumetricLights/TransparentDepthWrite";

		private static Material transpOverrideMat;

		private static Material transpDepthOnlyMat;

		private static Material[] transpOverrideMaterials;

		private static VolumetricLight light;

		private ScriptableRenderer renderer;

		private RTHandle cameraDepth;

		public TranspRenderPass(VolumetricLightsTranslucentShadowMapFeature settings)
		{
			this.settings = settings;
			base.renderPassEvent = RenderPassEvent.AfterRenderingOpaques;
		}

		public void Setup(ScriptableRenderer renderer, VolumetricLight light)
		{
			this.renderer = renderer;
			TranspRenderPass.light = light;
		}

		[Obsolete]
		public override void OnCameraSetup(CommandBuffer cmd, ref RenderingData renderingData)
		{
			base.OnCameraSetup(cmd, ref renderingData);
			cameraDepth = renderer.cameraDepthTargetHandle;
		}

		[Obsolete]
		public override void Configure(CommandBuffer cmd, RenderTextureDescriptor cameraTextureDescriptor)
		{
			if (light.translucencyMapHandle == null || light.translucencyMapHandle.rt != light.translucentMap)
			{
				if (light.translucencyMapHandle != null)
				{
					RTHandles.Release(light.translucencyMapHandle);
				}
				light.translucencyMapHandle = RTHandles.Alloc(light.translucentMap);
			}
			ConfigureTarget(light.translucencyMapHandle, cameraDepth);
			ConfigureClear(ClearFlag.Color, Color.white);
		}

		[Obsolete]
		public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
		{
			CommandBuffer commandBuffer = CommandBufferPool.Get("TranslucencyPrePass");
			context.ExecuteCommandBuffer(commandBuffer);
			commandBuffer.Clear();
			ExecutePass(commandBuffer);
			context.ExecuteCommandBuffer(commandBuffer);
			CommandBufferPool.Release(commandBuffer);
		}

		public override void RecordRenderGraph(RenderGraph renderGraph, ContextContainer frameData)
		{
			PassData passData;
			using IUnsafeRenderGraphBuilder unsafeRenderGraphBuilder = renderGraph.AddUnsafePass<PassData>("TranslucencyPrePass", out passData, "C:\\Users\\steph\\GameDev\\GetToWork2\\GetToWork\\Assets\\VolumetricLights\\Scripts\\VolumetricLightsTranslucentShadowMapFeature.cs", 110);
			unsafeRenderGraphBuilder.AllowPassCulling(value: false);
			UniversalResourceData universalResourceData = frameData.Get<UniversalResourceData>();
			if (light.translucencyMapHandle == null || passData.source == null || passData.source.rt != light.translucentMap)
			{
				if (light.translucencyMapHandle != null)
				{
					RTHandles.Release(light.translucencyMapHandle);
				}
				light.translucencyMapHandle = RTHandles.Alloc(light.translucentMap);
			}
			passData.source = light.translucencyMapHandle;
			passData.depthTexture = universalResourceData.activeDepthTexture;
			unsafeRenderGraphBuilder.UseTexture(universalResourceData.activeDepthTexture);
			ConfigureInput(ScriptableRenderPassInput.Depth);
			unsafeRenderGraphBuilder.SetRenderFunc((PassData passData2, UnsafeGraphContext context) =>
			{
				CommandBuffer nativeCommandBuffer = CommandBufferHelpers.GetNativeCommandBuffer(context.cmd);
				nativeCommandBuffer.SetRenderTarget(passData2.source, passData2.depthTexture);
				nativeCommandBuffer.ClearRenderTarget(clearDepth: true, clearColor: true, Color.white);
				ExecutePass(nativeCommandBuffer);
			});
		}

		private static void ExecutePass(CommandBuffer cmd)
		{
			if (transpOverrideMat == null)
			{
				transpOverrideMat = new Material(Shader.Find("Hidden/VolumetricLights/TransparentMultiply"));
			}
			if (transpDepthOnlyMat == null)
			{
				transpDepthOnlyMat = new Material(Shader.Find("Hidden/VolumetricLights/TransparentDepthWrite"));
			}
			int count = VolumetricLightsTranslucency.objects.Count;
			if (transpOverrideMaterials == null || transpOverrideMaterials.Length < count)
			{
				transpOverrideMaterials = new Material[count];
			}
			float num = 10f * light.shadowTranslucencyIntensity / (light.brightness + 0.001f);
			for (int i = 0; i < count; i++)
			{
				VolumetricLightsTranslucency volumetricLightsTranslucency = VolumetricLightsTranslucency.objects[i];
				if (volumetricLightsTranslucency == null || volumetricLightsTranslucency.theRenderer == null || !volumetricLightsTranslucency.theRenderer.isVisible)
				{
					continue;
				}
				Material sharedMaterial = volumetricLightsTranslucency.theRenderer.sharedMaterial;
				if (sharedMaterial == null)
				{
					continue;
				}
				if (volumetricLightsTranslucency.preserveOriginalShader)
				{
					cmd.DrawRenderer(volumetricLightsTranslucency.theRenderer, sharedMaterial);
					cmd.DrawRenderer(volumetricLightsTranslucency.theRenderer, transpDepthOnlyMat);
				}
				else if (!(volumetricLightsTranslucency.intensityMultiplier <= 0f))
				{
					if (transpOverrideMaterials[i] == null)
					{
						transpOverrideMaterials[i] = UnityEngine.Object.Instantiate(transpOverrideMat);
					}
					Material material = transpOverrideMaterials[i];
					Vector2 vector = Vector2.one;
					Vector2 vector2 = Vector2.zero;
					if (sharedMaterial.HasProperty(ShaderParams.CustomTranspBaseMap))
					{
						material.SetTexture(ShaderParams.MainTex, sharedMaterial.GetTexture(ShaderParams.CustomTranspBaseMap));
						vector = sharedMaterial.GetTextureScale(ShaderParams.CustomTranspBaseMap);
						vector2 = sharedMaterial.GetTextureOffset(ShaderParams.CustomTranspBaseMap);
					}
					else if (sharedMaterial.HasProperty(ShaderParams.MainTex))
					{
						material.SetTexture(ShaderParams.MainTex, sharedMaterial.GetTexture(ShaderParams.MainTex));
						vector = sharedMaterial.GetTextureScale(ShaderParams.MainTex);
						vector2 = sharedMaterial.GetTextureOffset(ShaderParams.MainTex);
					}
					if (sharedMaterial.HasProperty(ShaderParams.Color))
					{
						Color color = sharedMaterial.GetColor(ShaderParams.Color);
						material.SetColor(ShaderParams.Color, color);
					}
					material.SetVector(ShaderParams.MainTex_ST, new Vector4(vector.x, vector.y, vector2.x, vector2.y));
					material.SetVector(ShaderParams.TranslucencyIntensity, new Vector4(num * volumetricLightsTranslucency.intensityMultiplier, light.shadowTranslucencyBlend, 0f, 0f));
					cmd.DrawRenderer(volumetricLightsTranslucency.theRenderer, material);
				}
			}
		}

		public void CleanUp()
		{
			if (light != null)
			{
				RTHandles.Release(light.translucencyMapHandle);
			}
			if (transpOverrideMaterials != null)
			{
				for (int i = 0; i < transpOverrideMaterials.Length; i++)
				{
					UnityEngine.Object.DestroyImmediate(transpOverrideMaterials[i]);
				}
			}
		}
	}

	private TranspRenderPass m_ScriptablePass;

	private bool needsTranslucencyTextureCleanUp;

	public override void Create()
	{
		m_ScriptablePass = new TranspRenderPass(this);
	}

	private void OnDestroy()
	{
		if (m_ScriptablePass != null)
		{
			m_ScriptablePass.CleanUp();
		}
	}

	public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
	{
		if (VolumetricLightsTranslucency.objects.Count == 0)
		{
			if (!needsTranslucencyTextureCleanUp)
			{
				return;
			}
			needsTranslucencyTextureCleanUp = false;
		}
		else
		{
			needsTranslucencyTextureCleanUp = true;
		}
		Camera camera = renderingData.cameraData.camera;
		Transform parent = camera.transform.parent;
		if (!(parent == null))
		{
			VolumetricLight component = parent.GetComponent<VolumetricLight>();
			if (!(component == null) && component.shadowTranslucency && !(component.translucentMap == null) && (camera.cameraType != CameraType.Reflection || (camera.cullingMask & (1 << component.gameObject.layer)) != 0))
			{
				m_ScriptablePass.Setup(renderer, component);
				renderer.EnqueuePass(m_ScriptablePass);
			}
		}
	}
}
