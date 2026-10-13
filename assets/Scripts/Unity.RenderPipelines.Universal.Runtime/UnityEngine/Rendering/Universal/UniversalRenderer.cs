using System;
using System.Collections.Generic;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Rendering.RenderGraphModule;
using UnityEngine.Rendering.RenderGraphModule.Util;
using UnityEngine.Rendering.Universal.Internal;
using UnityEngine.VFX;

namespace UnityEngine.Rendering.Universal;

public sealed class UniversalRenderer : ScriptableRenderer
{
	private static class Profiling
	{
		private const string k_Name = "UniversalRenderer";

		public static readonly ProfilingSampler createCameraRenderTarget = new ProfilingSampler("UniversalRenderer.CreateCameraRenderTarget");
	}

	private struct RenderPassInputSummary
	{
		internal bool requiresDepthTexture;

		internal bool requiresDepthPrepass;

		internal bool requiresNormalsTexture;

		internal bool requiresColorTexture;

		internal bool requiresColorTextureCreated;

		internal bool requiresMotionVectors;

		internal RenderPassEvent requiresDepthNormalAtEvent;

		internal RenderPassEvent requiresDepthTextureEarliestEvent;
	}

	private class CopyToDebugTexturePassData
	{
		internal TextureHandle src;

		internal TextureHandle dest;
	}

	private enum DepthCopySchedule
	{
		DuringPrepass = 0,
		AfterPrepass = 1,
		AfterGBuffer = 2,
		AfterOpaques = 3,
		AfterSkybox = 4,
		AfterTransparents = 5,
		None = 6
	}

	private enum ColorCopySchedule
	{
		AfterSkybox = 0,
		None = 1
	}

	private struct TextureCopySchedules
	{
		internal DepthCopySchedule depth;

		internal ColorCopySchedule color;
	}

	private const int k_FinalBlitPassQueueOffset = 1;

	private const int k_AfterFinalBlitPassQueueOffset = 2;

	private static readonly List<ShaderTagId> k_DepthNormalsOnly = new List<ShaderTagId>
	{
		new ShaderTagId("DepthNormalsOnly")
	};

	private bool m_Clustering;

	private DepthOnlyPass m_DepthPrepass;

	private DepthNormalOnlyPass m_DepthNormalPrepass;

	private CopyDepthPass m_PrimedDepthCopyPass;

	private MotionVectorRenderPass m_MotionVectorPass;

	private MainLightShadowCasterPass m_MainLightShadowCasterPass;

	private AdditionalLightsShadowCasterPass m_AdditionalLightsShadowCasterPass;

	private GBufferPass m_GBufferPass;

	private CopyDepthPass m_GBufferCopyDepthPass;

	private DeferredPass m_DeferredPass;

	private DrawObjectsPass m_RenderOpaqueForwardOnlyPass;

	private DrawObjectsPass m_RenderOpaqueForwardPass;

	private DrawObjectsWithRenderingLayersPass m_RenderOpaqueForwardWithRenderingLayersPass;

	private DrawSkyboxPass m_DrawSkyboxPass;

	private CopyDepthPass m_CopyDepthPass;

	private CopyColorPass m_CopyColorPass;

	private TransparentSettingsPass m_TransparentSettingsPass;

	private DrawObjectsPass m_RenderTransparentForwardPass;

	private InvokeOnRenderObjectCallbackPass m_OnRenderObjectCallbackPass;

	private FinalBlitPass m_FinalBlitPass;

	private CapturePass m_CapturePass;

	private XROcclusionMeshPass m_XROcclusionMeshPass;

	private CopyDepthPass m_XRCopyDepthPass;

	private XRDepthMotionPass m_XRDepthMotionPass;

	private DrawScreenSpaceUIPass m_DrawOffscreenUIPass;

	private DrawScreenSpaceUIPass m_DrawOverlayUIPass;

	private CopyColorPass m_HistoryRawColorCopyPass;

	private CopyDepthPass m_HistoryRawDepthCopyPass;

	internal RenderTargetBufferSystem m_ColorBufferSystem;

	internal RTHandle m_ActiveCameraColorAttachment;

	private RTHandle m_ColorFrontBuffer;

	internal RTHandle m_ActiveCameraDepthAttachment;

	internal RTHandle m_CameraDepthAttachment;

	internal RTHandle m_CameraDepthAttachment_D3d_11;

	private RTHandle m_TargetColorHandle;

	private RTHandle m_TargetDepthHandle;

	internal RTHandle m_DepthTexture;

	private RTHandle m_NormalsTexture;

	private RTHandle m_DecalLayersTexture;

	private RTHandle m_OpaqueColor;

	private RTHandle m_MotionVectorColor;

	private RTHandle m_MotionVectorDepth;

	private ForwardLights m_ForwardLights;

	private DeferredLights m_DeferredLights;

	private RenderingMode m_RenderingMode;

	private DepthPrimingMode m_DepthPrimingMode;

	private CopyDepthMode m_CopyDepthMode;

	private DepthFormat m_CameraDepthAttachmentFormat;

	private DepthFormat m_CameraDepthTextureFormat;

	private bool m_DepthPrimingRecommended;

	private StencilState m_DefaultStencilState;

	private LightCookieManager m_LightCookieManager;

	private IntermediateTextureMode m_IntermediateTextureMode;

	private bool m_VulkanEnablePreTransform;

	private Material m_BlitMaterial;

	private Material m_BlitHDRMaterial;

	private Material m_SamplingMaterial;

	private Material m_StencilDeferredMaterial;

	private Material m_CameraMotionVecMaterial;

	private PostProcessPasses m_PostProcessPasses;

	private Material m_DebugBlitMaterial = Blitter.GetBlitMaterial(TextureXR.dimension);

	private static RTHandle[] m_RenderGraphCameraColorHandles = new RTHandle[2];

	private static RTHandle m_RenderGraphCameraDepthHandle;

	private static int m_CurrentColorHandle = 0;

	private static RTHandle m_RenderGraphDebugTextureHandle;

	private bool m_RequiresRenderingLayer;

	private RenderingLayerUtils.Event m_RenderingLayersEvent;

	private RenderingLayerUtils.MaskSize m_RenderingLayersMaskSize;

	private bool m_RenderingLayerProvidesRenderObjectPass;

	private bool m_RenderingLayerProvidesByDepthNormalPass;

	private string m_RenderingLayersTextureName;

	private const string _CameraTargetAttachmentAName = "_CameraTargetAttachmentA";

	private const string _CameraTargetAttachmentBName = "_CameraTargetAttachmentB";

	private const string _SingleCameraTargetAttachmentName = "_CameraTargetAttachment";

	private const string _CameraDepthAttachmentName = "_CameraDepthAttachment";

	private const string _CameraColorUpscaled = "_CameraColorUpscaled";

	private const string _CameraColorAfterPostProcessingName = "_CameraColorAfterPostProcessing";

	private bool m_IssuedGPUOcclusionUnsupportedMsg;

	private static bool m_RequiresIntermediateAttachments;

	internal RenderingMode renderingModeRequested => m_RenderingMode;

	internal RenderingMode renderingModeActual
	{
		get
		{
			if (renderingModeRequested != RenderingMode.Deferred || (!GL.wireframe && (base.DebugHandler == null || !base.DebugHandler.IsActiveModeUnsupportedForDeferred) && m_DeferredLights != null && m_DeferredLights.IsRuntimeSupportedThisFrame() && !m_DeferredLights.IsOverlay))
			{
				return renderingModeRequested;
			}
			return RenderingMode.Forward;
		}
	}

	internal bool accurateGbufferNormals
	{
		get
		{
			if (m_DeferredLights == null)
			{
				return false;
			}
			return m_DeferredLights.AccurateGbufferNormals;
		}
	}

	public DepthPrimingMode depthPrimingMode
	{
		get
		{
			return m_DepthPrimingMode;
		}
		set
		{
			m_DepthPrimingMode = value;
		}
	}

	internal ColorGradingLutPass colorGradingLutPass => m_PostProcessPasses.colorGradingLutPass;

	internal PostProcessPass postProcessPass => m_PostProcessPasses.postProcessPass;

	internal PostProcessPass finalPostProcessPass => m_PostProcessPasses.finalPostProcessPass;

	internal RTHandle colorGradingLut => m_PostProcessPasses.colorGradingLut;

	internal DeferredLights deferredLights => m_DeferredLights;

	internal LayerMask opaqueLayerMask { get; set; }

	internal LayerMask transparentLayerMask { get; set; }

	internal bool shadowTransparentReceive { get; set; }

	internal GraphicsFormat cameraDepthTextureFormat
	{
		get
		{
			if (m_CameraDepthTextureFormat == DepthFormat.Default)
			{
				return CoreUtils.GetDefaultDepthStencilFormat();
			}
			return (GraphicsFormat)m_CameraDepthTextureFormat;
		}
	}

	internal GraphicsFormat cameraDepthAttachmentFormat
	{
		get
		{
			if (m_CameraDepthAttachmentFormat == DepthFormat.Default)
			{
				return CoreUtils.GetDefaultDepthStencilFormat();
			}
			return (GraphicsFormat)m_CameraDepthAttachmentFormat;
		}
	}

	internal override bool supportsNativeRenderPassRendergraphCompiler => true;

	private RTHandle currentRenderGraphCameraColorHandle
	{
		get
		{
			if (m_CurrentColorHandle < 0)
			{
				return null;
			}
			return m_RenderGraphCameraColorHandles[m_CurrentColorHandle];
		}
	}

	private RTHandle nextRenderGraphCameraColorHandle
	{
		get
		{
			if (m_CurrentColorHandle < 0)
			{
				return null;
			}
			m_CurrentColorHandle = (m_CurrentColorHandle + 1) % 2;
			return currentRenderGraphCameraColorHandle;
		}
	}

	public override bool supportsGPUOcclusion
	{
		get
		{
			bool flag = SystemInfo.graphicsDeviceVendorID != 20803;
			if (!flag && !m_IssuedGPUOcclusionUnsupportedMsg)
			{
				Debug.LogWarning("The GPU Occlusion Culling feature is currently unavailable on this device due to suspected driver issues.");
				m_IssuedGPUOcclusionUnsupportedMsg = true;
			}
			return (m_RenderingMode != RenderingMode.Deferred) & flag;
		}
	}

	public override int SupportedCameraStackingTypes()
	{
		switch (m_RenderingMode)
		{
		case RenderingMode.Forward:
		case RenderingMode.ForwardPlus:
			return 3;
		case RenderingMode.Deferred:
			return 1;
		default:
			return 0;
		}
	}

	protected internal override bool SupportsMotionVectors()
	{
		return true;
	}

	protected internal override bool SupportsCameraOpaque()
	{
		return true;
	}

	protected internal override bool SupportsCameraNormals()
	{
		return true;
	}

	public UniversalRenderer(UniversalRendererData data)
		: base(data)
	{
		PlatformAutoDetect.Initialize();
		if (GraphicsSettings.TryGetRenderPipelineSettings<UniversalRenderPipelineRuntimeXRResources>(out var settings))
		{
			XRSystem.Initialize(XRPassUniversal.Create, settings.xrOcclusionMeshPS, settings.xrMirrorViewPS);
			m_XRDepthMotionPass = new XRDepthMotionPass(RenderPassEvent.BeforeRenderingPrePasses, settings.xrMotionVector);
		}
		if (GraphicsSettings.TryGetRenderPipelineSettings<UniversalRenderPipelineRuntimeShaders>(out var settings2))
		{
			m_BlitMaterial = CoreUtils.CreateEngineMaterial(settings2.coreBlitPS);
			m_BlitHDRMaterial = CoreUtils.CreateEngineMaterial(settings2.blitHDROverlay);
			m_SamplingMaterial = CoreUtils.CreateEngineMaterial(settings2.samplingPS);
		}
		Shader copyDepthShader = null;
		if (GraphicsSettings.TryGetRenderPipelineSettings<UniversalRendererResources>(out var settings3))
		{
			copyDepthShader = settings3.copyDepthPS;
			m_StencilDeferredMaterial = CoreUtils.CreateEngineMaterial(settings3.stencilDeferredPS);
			m_CameraMotionVecMaterial = CoreUtils.CreateEngineMaterial(settings3.cameraMotionVector);
		}
		StencilStateData defaultStencilState = data.defaultStencilState;
		m_DefaultStencilState = StencilState.defaultValue;
		m_DefaultStencilState.enabled = defaultStencilState.overrideStencilState;
		m_DefaultStencilState.SetCompareFunction(defaultStencilState.stencilCompareFunction);
		m_DefaultStencilState.SetPassOperation(defaultStencilState.passOperation);
		m_DefaultStencilState.SetFailOperation(defaultStencilState.failOperation);
		m_DefaultStencilState.SetZFailOperation(defaultStencilState.zFailOperation);
		m_IntermediateTextureMode = data.intermediateTextureMode;
		opaqueLayerMask = data.opaqueLayerMask;
		transparentLayerMask = data.transparentLayerMask;
		shadowTransparentReceive = data.shadowTransparentReceive;
		UniversalRenderPipelineAsset asset = UniversalRenderPipeline.asset;
		if ((object)asset != null && asset.supportsLightCookies)
		{
			LightCookieManager.Settings settings4 = LightCookieManager.Settings.Create();
			UniversalRenderPipelineAsset asset2 = UniversalRenderPipeline.asset;
			if ((bool)asset2)
			{
				settings4.atlas.format = asset2.additionalLightsCookieFormat;
				settings4.atlas.resolution = asset2.additionalLightsCookieResolution;
			}
			m_LightCookieManager = new LightCookieManager(ref settings4);
		}
		base.stripShadowsOffVariants = data.stripShadowsOffVariants;
		base.stripAdditionalLightOffVariants = data.stripAdditionalLightOffVariants;
		ForwardLights.InitParams initParams = default;
		initParams.lightCookieManager = m_LightCookieManager;
		initParams.forwardPlus = data.renderingMode == RenderingMode.ForwardPlus;
		m_Clustering = data.renderingMode == RenderingMode.ForwardPlus;
		m_ForwardLights = new ForwardLights(initParams);
		m_RenderingMode = data.renderingMode;
		m_DepthPrimingMode = data.depthPrimingMode;
		m_CopyDepthMode = data.copyDepthMode;
		m_CameraDepthAttachmentFormat = data.depthAttachmentFormat;
		m_CameraDepthTextureFormat = data.depthTextureFormat;
		useRenderPassEnabled = data.useNativeRenderPass;
		m_DepthPrimingRecommended = true;
		m_MainLightShadowCasterPass = new MainLightShadowCasterPass(RenderPassEvent.BeforeRenderingShadows);
		m_AdditionalLightsShadowCasterPass = new AdditionalLightsShadowCasterPass(RenderPassEvent.BeforeRenderingShadows);
		m_XROcclusionMeshPass = new XROcclusionMeshPass(RenderPassEvent.BeforeRenderingOpaques);
		m_XRCopyDepthPass = new CopyDepthPass((RenderPassEvent)1002, copyDepthShader);
		m_DepthPrepass = new DepthOnlyPass(RenderPassEvent.BeforeRenderingPrePasses, RenderQueueRange.opaque, data.opaqueLayerMask);
		m_DepthNormalPrepass = new DepthNormalOnlyPass(RenderPassEvent.BeforeRenderingPrePasses, RenderQueueRange.opaque, data.opaqueLayerMask);
		if (renderingModeRequested == RenderingMode.Forward || renderingModeRequested == RenderingMode.ForwardPlus)
		{
			m_PrimedDepthCopyPass = new CopyDepthPass(RenderPassEvent.AfterRenderingPrePasses, copyDepthShader, shouldClear: true, copyToDepth: true);
		}
		if (renderingModeRequested == RenderingMode.Deferred)
		{
			m_DeferredLights = new DeferredLights(new DeferredLights.InitParams
			{
				stencilDeferredMaterial = m_StencilDeferredMaterial,
				lightCookieManager = m_LightCookieManager
			}, useRenderPassEnabled);
			m_DeferredLights.AccurateGbufferNormals = data.accurateGbufferNormals;
			m_GBufferPass = new GBufferPass(RenderPassEvent.BeforeRenderingGbuffer, RenderQueueRange.opaque, data.opaqueLayerMask, m_DefaultStencilState, defaultStencilState.stencilReference, m_DeferredLights);
			StencilState stencilState = DeferredLights.OverwriteStencil(m_DefaultStencilState, 96);
			ShaderTagId[] shaderTagIds = new ShaderTagId[3]
			{
				new ShaderTagId("UniversalForwardOnly"),
				new ShaderTagId("SRPDefaultUnlit"),
				new ShaderTagId("LightweightForward")
			};
			int stencilReference = defaultStencilState.stencilReference | 0;
			m_GBufferCopyDepthPass = new CopyDepthPass((RenderPassEvent)211, copyDepthShader, shouldClear: true, copyToDepth: false, copyResolvedDepth: false, "Copy GBuffer Depth");
			m_DeferredPass = new DeferredPass(RenderPassEvent.BeforeRenderingDeferredLights, m_DeferredLights);
			m_RenderOpaqueForwardOnlyPass = new DrawObjectsPass("Draw Opaques Forward Only", shaderTagIds, opaque: true, RenderPassEvent.BeforeRenderingOpaques, RenderQueueRange.opaque, data.opaqueLayerMask, stencilState, stencilReference);
		}
		m_RenderOpaqueForwardPass = new DrawObjectsPass(URPProfileId.DrawOpaqueObjects, opaque: true, RenderPassEvent.BeforeRenderingOpaques, RenderQueueRange.opaque, data.opaqueLayerMask, m_DefaultStencilState, defaultStencilState.stencilReference);
		m_RenderOpaqueForwardWithRenderingLayersPass = new DrawObjectsWithRenderingLayersPass(URPProfileId.DrawOpaqueObjects, opaque: true, RenderPassEvent.BeforeRenderingOpaques, RenderQueueRange.opaque, data.opaqueLayerMask, m_DefaultStencilState, defaultStencilState.stencilReference);
		bool flag = m_CopyDepthMode == CopyDepthMode.AfterTransparents;
		RenderPassEvent renderPassEvent = (flag ? RenderPassEvent.AfterRenderingTransparents : RenderPassEvent.AfterRenderingSkybox);
		m_CopyDepthPass = new CopyDepthPass(renderPassEvent, copyDepthShader, shouldClear: true, copyToDepth: false, RenderingUtils.MultisampleDepthResolveSupported() & flag);
		m_MotionVectorPass = new MotionVectorRenderPass(renderPassEvent + 1, m_CameraMotionVecMaterial, data.opaqueLayerMask);
		m_DrawSkyboxPass = new DrawSkyboxPass(RenderPassEvent.BeforeRenderingSkybox);
		m_CopyColorPass = new CopyColorPass(RenderPassEvent.AfterRenderingSkybox, m_SamplingMaterial, m_BlitMaterial);
		m_TransparentSettingsPass = new TransparentSettingsPass(RenderPassEvent.BeforeRenderingTransparents, data.shadowTransparentReceive);
		m_RenderTransparentForwardPass = new DrawObjectsPass(URPProfileId.DrawTransparentObjects, opaque: false, RenderPassEvent.BeforeRenderingTransparents, RenderQueueRange.transparent, data.transparentLayerMask, m_DefaultStencilState, defaultStencilState.stencilReference);
		m_OnRenderObjectCallbackPass = new InvokeOnRenderObjectCallbackPass(RenderPassEvent.BeforeRenderingPostProcessing);
		m_HistoryRawColorCopyPass = new CopyColorPass(RenderPassEvent.BeforeRenderingPostProcessing, m_SamplingMaterial, m_BlitMaterial, "Copy Color Raw History");
		m_HistoryRawDepthCopyPass = new CopyDepthPass(RenderPassEvent.BeforeRenderingPostProcessing, copyDepthShader, shouldClear: false, RenderingUtils.MultisampleDepthResolveSupported(), copyResolvedDepth: false, "Copy Depth Raw History");
		m_DrawOffscreenUIPass = new DrawScreenSpaceUIPass(RenderPassEvent.BeforeRenderingPostProcessing, renderOffscreen: true);
		m_DrawOverlayUIPass = new DrawScreenSpaceUIPass((RenderPassEvent)1002, renderOffscreen: false);
		PostProcessParams postProcessParams = PostProcessParams.Create();
		postProcessParams.blitMaterial = m_BlitMaterial;
		postProcessParams.requestColorFormat = GraphicsFormat.B10G11R11_UFloatPack32;
		UniversalRenderPipelineAsset asset3 = UniversalRenderPipeline.asset;
		if ((bool)asset3)
		{
			postProcessParams.requestColorFormat = UniversalRenderPipeline.MakeRenderTextureGraphicsFormat(asset3.supportsHDR, asset3.hdrColorBufferPrecision, needsAlpha: false);
		}
		m_PostProcessPasses = new PostProcessPasses(data.postProcessData, ref postProcessParams);
		m_CapturePass = new CapturePass(RenderPassEvent.AfterRendering);
		m_FinalBlitPass = new FinalBlitPass((RenderPassEvent)1001, m_BlitMaterial, m_BlitHDRMaterial);
		m_ColorBufferSystem = new RenderTargetBufferSystem("_CameraColorAttachment");
		base.supportedRenderingFeatures = new RenderingFeatures();
		if (renderingModeRequested == RenderingMode.Deferred)
		{
			base.supportedRenderingFeatures.msaa = false;
		}
		LensFlareCommonSRP.mergeNeeded = 0;
		LensFlareCommonSRP.maxLensFlareWithOcclusionTemporalSample = 1;
		LensFlareCommonSRP.Initialize();
		m_VulkanEnablePreTransform = GraphicsSettings.HasShaderDefine(BuiltinShaderDefine.UNITY_PRETRANSFORM_TO_DISPLAY_ORIENTATION);
	}

	protected override void Dispose(bool disposing)
	{
		m_ForwardLights.Cleanup();
		m_GBufferPass?.Dispose();
		m_PostProcessPasses.Dispose();
		m_FinalBlitPass?.Dispose();
		m_DrawOffscreenUIPass?.Dispose();
		m_DrawOverlayUIPass?.Dispose();
		m_CopyDepthPass?.Dispose();
		m_PrimedDepthCopyPass?.Dispose();
		m_GBufferCopyDepthPass?.Dispose();
		m_HistoryRawDepthCopyPass?.Dispose();
		m_XRCopyDepthPass?.Dispose();
		m_XRDepthMotionPass?.Dispose();
		m_TargetColorHandle?.Release();
		m_TargetDepthHandle?.Release();
		ReleaseRenderTargets();
		base.Dispose(disposing);
		CoreUtils.Destroy(m_BlitMaterial);
		CoreUtils.Destroy(m_BlitHDRMaterial);
		CoreUtils.Destroy(m_SamplingMaterial);
		CoreUtils.Destroy(m_StencilDeferredMaterial);
		CoreUtils.Destroy(m_CameraMotionVecMaterial);
		CleanupRenderGraphResources();
		LensFlareCommonSRP.Dispose();
		XRSystem.Dispose();
	}

	internal override void ReleaseRenderTargets()
	{
		m_ColorBufferSystem.Dispose();
		if (m_DeferredLights != null && !m_DeferredLights.UseFramebufferFetch)
		{
			m_GBufferPass?.Dispose();
		}
		m_PostProcessPasses.ReleaseRenderTargets();
		m_MainLightShadowCasterPass?.Dispose();
		m_AdditionalLightsShadowCasterPass?.Dispose();
		m_CameraDepthAttachment?.Release();
		m_CameraDepthAttachment_D3d_11?.Release();
		m_DepthTexture?.Release();
		m_NormalsTexture?.Release();
		m_DecalLayersTexture?.Release();
		m_OpaqueColor?.Release();
		m_MotionVectorColor?.Release();
		m_MotionVectorDepth?.Release();
		hasReleasedRTs = true;
	}

	private void SetupFinalPassDebug(UniversalCameraData cameraData)
	{
		if (base.DebugHandler == null || !base.DebugHandler.IsActiveForCamera(cameraData.isPreviewCamera))
		{
			return;
		}
		if (base.DebugHandler.TryGetFullscreenDebugMode(out var debugFullScreenMode, out var textureHeightPercent) && (debugFullScreenMode != DebugFullScreenMode.ReflectionProbeAtlas || m_Clustering))
		{
			Camera camera = cameraData.camera;
			float num = camera.pixelWidth;
			float num2 = camera.pixelHeight;
			float num3 = Mathf.Clamp01((float)textureHeightPercent / 100f);
			float height = num3 * num2;
			float width = num3 * num;
			RenderTexture renderTexture = null;
			switch (debugFullScreenMode)
			{
			case DebugFullScreenMode.ReflectionProbeAtlas:
				renderTexture = m_ForwardLights.reflectionProbeManager.atlasRT;
				break;
			case DebugFullScreenMode.MainLightShadowMap:
				renderTexture = m_MainLightShadowCasterPass.m_MainLightShadowmapTexture.rt;
				break;
			case DebugFullScreenMode.AdditionalLightsShadowMap:
				renderTexture = m_AdditionalLightsShadowCasterPass.m_AdditionalLightsShadowmapHandle.rt;
				break;
			case DebugFullScreenMode.AdditionalLightsCookieAtlas:
				if (m_LightCookieManager != null)
				{
					renderTexture = m_LightCookieManager?.AdditionalLightsCookieAtlasTexture?.rt;
				}
				break;
			}
			if (renderTexture != null)
			{
				CorrectForTextureAspectRatio(ref width, ref height, renderTexture.width, renderTexture.height);
			}
			float num4 = width / num;
			float num5 = height / num2;
			Rect displayRect = new Rect(1f - num4, 1f - num5, num4, num5);
			Vector4 zero = Vector4.zero;
			switch (debugFullScreenMode)
			{
			case DebugFullScreenMode.Depth:
				base.DebugHandler.SetDebugRenderTarget(m_DepthTexture, displayRect, supportsStereo: true, zero);
				break;
			case DebugFullScreenMode.MotionVector:
				zero.x = -0.01f;
				zero.y = 0.01f;
				zero.z = 0f;
				zero.w = 1f;
				base.DebugHandler.SetDebugRenderTarget(m_MotionVectorColor, displayRect, supportsStereo: true, zero);
				break;
			case DebugFullScreenMode.AdditionalLightsShadowMap:
				base.DebugHandler.SetDebugRenderTarget(m_AdditionalLightsShadowCasterPass.m_AdditionalLightsShadowmapHandle, displayRect, supportsStereo: false, zero);
				break;
			case DebugFullScreenMode.MainLightShadowMap:
				base.DebugHandler.SetDebugRenderTarget(m_MainLightShadowCasterPass.m_MainLightShadowmapTexture, displayRect, supportsStereo: false, zero);
				break;
			case DebugFullScreenMode.AdditionalLightsCookieAtlas:
				base.DebugHandler.SetDebugRenderTarget(m_LightCookieManager?.AdditionalLightsCookieAtlasTexture, displayRect, supportsStereo: false, zero);
				break;
			case DebugFullScreenMode.ReflectionProbeAtlas:
				base.DebugHandler.SetDebugRenderTarget(m_ForwardLights.reflectionProbeManager.atlasRTHandle, displayRect, supportsStereo: false, zero);
				break;
			}
		}
		else
		{
			base.DebugHandler.ResetDebugRenderTarget();
		}
	}

	public static bool IsOffscreenDepthTexture(ref CameraData cameraData)
	{
		return IsOffscreenDepthTexture(cameraData.universalCameraData);
	}

	public static bool IsOffscreenDepthTexture(UniversalCameraData cameraData)
	{
		if (cameraData.targetTexture != null)
		{
			return cameraData.targetTexture.format == RenderTextureFormat.Depth;
		}
		return false;
	}

	private bool IsDepthPrimingEnabled(UniversalCameraData cameraData)
	{
		if (!CanCopyDepth(cameraData))
		{
			return false;
		}
		bool flag = !IsWebGL();
		bool num = (m_DepthPrimingRecommended && m_DepthPrimingMode == DepthPrimingMode.Auto) || m_DepthPrimingMode == DepthPrimingMode.Forced;
		bool flag2 = m_RenderingMode == RenderingMode.Forward || m_RenderingMode == RenderingMode.ForwardPlus;
		bool flag3 = cameraData.renderType == CameraRenderType.Base || cameraData.clearDepth;
		bool flag4 = cameraData.cameraType != CameraType.Reflection;
		bool flag5 = !IsOffscreenDepthTexture(cameraData);
		bool flag6 = cameraData.cameraTargetDescriptor.msaaSamples == 1;
		return num & flag2 & flag3 & flag4 & flag5 & flag & flag6;
	}

	private bool IsWebGL()
	{
		return false;
	}

	private bool IsGLESDevice()
	{
		return SystemInfo.graphicsDeviceType == GraphicsDeviceType.OpenGLES3;
	}

	private bool IsGLDevice()
	{
		if (!IsGLESDevice())
		{
			return SystemInfo.graphicsDeviceType == GraphicsDeviceType.OpenGLCore;
		}
		return true;
	}

	internal bool HasActiveRenderFeatures()
	{
		if (base.rendererFeatures.Count == 0)
		{
			return false;
		}
		foreach (ScriptableRendererFeature rendererFeature in base.rendererFeatures)
		{
			if (rendererFeature.isActive)
			{
				return true;
			}
		}
		return false;
	}

	internal bool HasPassesRequiringIntermediateTexture()
	{
		if (base.activeRenderPassQueue.Count == 0)
		{
			return false;
		}
		foreach (ScriptableRenderPass item in base.activeRenderPassQueue)
		{
			if (item.requiresIntermediateTexture)
			{
				return true;
			}
		}
		return false;
	}

	[Obsolete("This rendering path is for compatibility mode only (when Render Graph is disabled). Use Render Graph API instead.", false)]
	public override void Setup(ScriptableRenderContext context, ref RenderingData renderingData)
	{
		UniversalRenderingData universalRenderingData = base.frameData.Get<UniversalRenderingData>();
		UniversalCameraData universalCameraData = base.frameData.Get<UniversalCameraData>();
		UniversalLightData lightData = base.frameData.Get<UniversalLightData>();
		UniversalShadowData shadowData = base.frameData.Get<UniversalShadowData>();
		UniversalPostProcessingData postProcessingData = base.frameData.Get<UniversalPostProcessingData>();
		m_ForwardLights.PreSetup(universalRenderingData, universalCameraData, lightData);
		Camera camera = universalCameraData.camera;
		RenderTextureDescriptor descriptor = universalCameraData.cameraTargetDescriptor;
		CommandBuffer commandBuffer = universalRenderingData.commandBuffer;
		if (base.DebugHandler != null && base.DebugHandler.IsActiveForCamera(universalCameraData.isPreviewCamera))
		{
			if (base.DebugHandler.WriteToDebugScreenTexture(universalCameraData.resolveFinalTarget))
			{
				RenderTextureDescriptor descriptor2 = universalCameraData.cameraTargetDescriptor;
				DebugHandler.ConfigureColorDescriptorForDebugScreen(ref descriptor2, universalCameraData.pixelWidth, universalCameraData.pixelHeight);
				RenderingUtils.ReAllocateHandleIfNeeded(ref base.DebugHandler.DebugScreenColorHandle, in descriptor2, FilterMode.Point, TextureWrapMode.Repeat, 1, 0f, "_DebugScreenColor");
				RenderTextureDescriptor descriptor3 = universalCameraData.cameraTargetDescriptor;
				DebugHandler.ConfigureDepthDescriptorForDebugScreen(ref descriptor3, cameraDepthTextureFormat, universalCameraData.pixelWidth, universalCameraData.pixelHeight);
				RenderingUtils.ReAllocateHandleIfNeeded(ref base.DebugHandler.DebugScreenDepthHandle, in descriptor3, FilterMode.Point, TextureWrapMode.Repeat, 1, 0f, "_DebugScreenDepth");
			}
			if (base.DebugHandler.HDRDebugViewIsActive(universalCameraData.resolveFinalTarget))
			{
				base.DebugHandler.hdrDebugViewPass.Setup(universalCameraData, base.DebugHandler.DebugDisplaySettings.lightingSettings.hdrDebugMode);
				EnqueuePass(base.DebugHandler.hdrDebugViewPass);
			}
		}
		if (universalCameraData.cameraType != CameraType.Game)
		{
			useRenderPassEnabled = false;
		}
		base.useDepthPriming = IsDepthPrimingEnabled(universalCameraData);
		if (IsOffscreenDepthTexture(universalCameraData))
		{
			ConfigureCameraTarget(ScriptableRenderer.k_CameraTarget, ScriptableRenderer.k_CameraTarget);
			EnqueuePass(m_RenderOpaqueForwardPass);
			EnqueuePass(m_RenderTransparentForwardPass);
			return;
		}
		bool isPreviewCamera = universalCameraData.isPreviewCamera;
		bool flag = (HasActiveRenderFeatures() && m_IntermediateTextureMode == IntermediateTextureMode.Always && !isPreviewCamera) || (Application.isEditor && m_Clustering);
		flag |= HasPassesRequiringIntermediateTexture();
		UpdateCameraHistory(universalCameraData);
		RenderPassInputSummary renderPassInputs = GetRenderPassInputs(universalCameraData.IsTemporalAAEnabled(), postProcessingData.isEnabled, universalCameraData.isSceneViewCamera);
		bool flag2 = RenderingLayerUtils.RequireRenderingLayers(this, base.rendererFeatures, descriptor.msaaSamples, out var combinedEvent, out var combinedMaskSize);
		if (IsGLDevice())
		{
			flag2 = false;
		}
		bool flag3 = false;
		bool flag4 = false;
		if (flag2 && renderingModeActual != RenderingMode.Deferred)
		{
			switch (combinedEvent)
			{
			case RenderingLayerUtils.Event.DepthNormalPrePass:
				flag3 = true;
				break;
			case RenderingLayerUtils.Event.Opaque:
				flag4 = true;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
		if (flag3)
		{
			renderPassInputs.requiresNormalsTexture = true;
		}
		if (m_DeferredLights != null)
		{
			m_DeferredLights.RenderingLayerMaskSize = combinedMaskSize;
			m_DeferredLights.UseDecalLayers = flag2;
			m_DeferredLights.HasNormalPrepass = renderPassInputs.requiresNormalsTexture;
			m_DeferredLights.ResolveMixedLightingMode(lightData);
			m_DeferredLights.IsOverlay = universalCameraData.renderType == CameraRenderType.Overlay;
			if (m_DeferredLights.UseFramebufferFetch)
			{
				foreach (ScriptableRenderPass item in base.activeRenderPassQueue)
				{
					if (item.renderPassEvent >= RenderPassEvent.AfterRenderingGbuffer && item.renderPassEvent <= RenderPassEvent.BeforeRenderingDeferredLights)
					{
						m_DeferredLights.DisableFramebufferFetchInput();
						break;
					}
				}
			}
		}
		bool flag5 = universalCameraData.postProcessEnabled && m_PostProcessPasses.isCreated;
		bool flag6 = postProcessingData.isEnabled && m_PostProcessPasses.isCreated;
		bool flag7 = flag5 && universalCameraData.postProcessingRequiresDepthTexture;
		bool flag8 = universalCameraData.postProcessEnabled && m_PostProcessPasses.isCreated;
		bool flag9 = universalCameraData.isSceneViewCamera || universalCameraData.isPreviewCamera;
		bool num = universalCameraData.requiresDepthTexture || renderPassInputs.requiresDepthTexture || base.useDepthPriming;
		bool flag10 = false;
		bool flag11 = m_MainLightShadowCasterPass.Setup(universalRenderingData, universalCameraData, lightData, shadowData);
		bool flag12 = m_AdditionalLightsShadowCasterPass.Setup(universalRenderingData, universalCameraData, lightData, shadowData);
		bool flag13 = m_TransparentSettingsPass.Setup();
		bool flag14 = m_CopyDepthMode == CopyDepthMode.ForcePrepass;
		bool flag15 = (num | flag7) && (!CanCopyDepth(universalCameraData) | flag14);
		flag15 |= flag9;
		flag15 |= flag10;
		flag15 |= isPreviewCamera;
		flag15 |= renderPassInputs.requiresDepthPrepass;
		flag15 |= renderPassInputs.requiresNormalsTexture;
		if (flag15 && renderingModeActual == RenderingMode.Deferred && !renderPassInputs.requiresNormalsTexture)
		{
			flag15 = false;
		}
		flag15 |= base.useDepthPriming;
		if (num)
		{
			RenderPassEvent renderPassEvent = ((m_CopyDepthMode == CopyDepthMode.AfterTransparents) ? RenderPassEvent.AfterRenderingTransparents : RenderPassEvent.AfterRenderingOpaques);
			if (renderPassInputs.requiresDepthTexture)
			{
				renderPassEvent = (RenderPassEvent)Mathf.Min(500, (int)(renderPassInputs.requiresDepthTextureEarliestEvent - 1));
			}
			m_CopyDepthPass.renderPassEvent = renderPassEvent;
			if (renderPassEvent < RenderPassEvent.AfterRenderingTransparents)
			{
				m_CopyDepthPass.m_CopyResolvedDepth = false;
				m_CopyDepthMode = CopyDepthMode.AfterOpaques;
			}
		}
		else if (flag7 | flag9 | flag10)
		{
			m_CopyDepthPass.renderPassEvent = RenderPassEvent.AfterRenderingTransparents;
		}
		flag |= RequiresIntermediateColorTexture(universalCameraData, ref renderPassInputs);
		flag &= !isPreviewCamera;
		bool flag16 = (num | flag7) && !flag15;
		flag16 |= !universalCameraData.resolveFinalTarget;
		flag16 |= renderingModeActual == RenderingMode.Deferred && !useRenderPassEnabled;
		flag16 |= base.useDepthPriming;
		flag16 |= flag4;
		if (universalCameraData.xr.enabled)
		{
			flag |= flag16;
		}
		if (RTHandles.rtHandleProperties.rtHandleScale.x != 1f || RTHandles.rtHandleProperties.rtHandleScale.y != 1f)
		{
			flag |= flag16;
		}
		if (useRenderPassEnabled || base.useDepthPriming)
		{
			flag |= flag16;
		}
		if (SystemInfo.graphicsUVStartsAtTop)
		{
			flag |= flag16;
		}
		RenderTextureDescriptor desc = descriptor;
		desc.useMipMap = false;
		desc.autoGenerateMips = false;
		desc.depthStencilFormat = GraphicsFormat.None;
		m_ColorBufferSystem.SetCameraSettings(desc, FilterMode.Bilinear);
		if (universalCameraData.renderType == CameraRenderType.Base)
		{
			bool flag17 = camera.sceneViewFilterMode == Camera.SceneViewFilterMode.ShowFiltered;
			bool flag18 = (flag | flag16) && !flag17;
			flag16 |= flag;
			RenderTargetIdentifier renderTargetIdentifier = BuiltinRenderTextureType.CameraTarget;
			if (universalCameraData.xr.enabled)
			{
				renderTargetIdentifier = universalCameraData.xr.renderTarget;
			}
			if (m_TargetColorHandle == null)
			{
				m_TargetColorHandle = RTHandles.Alloc(renderTargetIdentifier);
			}
			else if (m_TargetColorHandle.nameID != renderTargetIdentifier)
			{
				RTHandleStaticHelpers.SetRTHandleUserManagedWrapper(ref m_TargetColorHandle, renderTargetIdentifier);
			}
			if (m_TargetDepthHandle == null)
			{
				m_TargetDepthHandle = RTHandles.Alloc(renderTargetIdentifier);
			}
			else if (m_TargetDepthHandle.nameID != renderTargetIdentifier)
			{
				RTHandleStaticHelpers.SetRTHandleUserManagedWrapper(ref m_TargetDepthHandle, renderTargetIdentifier);
			}
			if (flag18)
			{
				CreateCameraRenderTarget(context, ref descriptor, commandBuffer, universalCameraData);
			}
			m_RenderOpaqueForwardPass.m_IsActiveTargetBackBuffer = !flag18;
			m_RenderTransparentForwardPass.m_IsActiveTargetBackBuffer = !flag18;
			m_XROcclusionMeshPass.m_IsActiveTargetBackBuffer = !flag18;
			m_ActiveCameraColorAttachment = (flag ? m_ColorBufferSystem.PeekBackBuffer() : m_TargetColorHandle);
			m_ActiveCameraDepthAttachment = (flag16 ? m_CameraDepthAttachment : m_TargetDepthHandle);
		}
		else
		{
			universalCameraData.baseCamera.TryGetComponent<UniversalAdditionalCameraData>(out var component);
			UniversalRenderer universalRenderer = (UniversalRenderer)component.scriptableRenderer;
			if (m_ColorBufferSystem != universalRenderer.m_ColorBufferSystem)
			{
				m_ColorBufferSystem.Dispose();
				m_ColorBufferSystem = universalRenderer.m_ColorBufferSystem;
			}
			m_ActiveCameraColorAttachment = m_ColorBufferSystem.PeekBackBuffer();
			m_ActiveCameraDepthAttachment = universalRenderer.m_ActiveCameraDepthAttachment;
			m_TargetColorHandle = universalRenderer.m_TargetColorHandle;
			m_TargetDepthHandle = universalRenderer.m_TargetDepthHandle;
		}
		if (base.rendererFeatures.Count != 0 && !isPreviewCamera)
		{
			ConfigureCameraColorTarget(m_ColorBufferSystem.PeekBackBuffer());
		}
		bool flag19 = universalCameraData.requiresOpaqueTexture || renderPassInputs.requiresColorTexture;
		flag19 &= !isPreviewCamera;
		ConfigureCameraTarget(m_ActiveCameraColorAttachment, m_ActiveCameraDepthAttachment);
		if (SystemInfo.graphicsDeviceType == GraphicsDeviceType.Direct3D11)
		{
			commandBuffer.CopyTexture(m_CameraDepthAttachment, m_CameraDepthAttachment_D3d_11);
		}
		bool flag20 = base.activeRenderPassQueue.Find((ScriptableRenderPass x) => x.renderPassEvent == RenderPassEvent.AfterRenderingPostProcessing) != null;
		if (flag11)
		{
			EnqueuePass(m_MainLightShadowCasterPass);
		}
		if (flag12)
		{
			EnqueuePass(m_AdditionalLightsShadowCasterPass);
		}
		bool flag21 = (!flag15 && ((universalCameraData.requiresDepthTexture | flag7) || renderPassInputs.requiresDepthTexture)) & flag16;
		if (base.DebugHandler != null && base.DebugHandler.IsActiveForCamera(universalCameraData.isPreviewCamera))
		{
			base.DebugHandler.TryGetFullscreenDebugMode(out var debugFullScreenMode);
			if (debugFullScreenMode == DebugFullScreenMode.Depth)
			{
				flag15 = true;
			}
			if (!base.DebugHandler.IsLightingActive)
			{
				flag11 = false;
				flag12 = false;
				if (!flag9)
				{
					flag15 = false;
					base.useDepthPriming = false;
					flag8 = false;
					flag19 = false;
					flag21 = false;
				}
			}
			if (useRenderPassEnabled)
			{
				useRenderPassEnabled = base.DebugHandler.IsRenderPassSupported;
			}
		}
		universalCameraData.renderer.useDepthPriming = base.useDepthPriming;
		if (renderingModeActual == RenderingMode.Deferred && m_DeferredLights.UseFramebufferFetch && (RenderPassEvent.AfterRenderingGbuffer == renderPassInputs.requiresDepthNormalAtEvent || !useRenderPassEnabled))
		{
			m_DeferredLights.DisableFramebufferFetchInput();
		}
		if ((renderingModeActual == RenderingMode.Deferred && !useRenderPassEnabled) | flag15 | flag21)
		{
			RenderTextureDescriptor descriptor4 = descriptor;
			if (flag15 && renderingModeActual != RenderingMode.Deferred)
			{
				descriptor4.graphicsFormat = GraphicsFormat.None;
				descriptor4.depthStencilFormat = cameraDepthTextureFormat;
			}
			else
			{
				descriptor4.graphicsFormat = GraphicsFormat.R32_SFloat;
				descriptor4.depthStencilFormat = GraphicsFormat.None;
			}
			descriptor4.msaaSamples = 1;
			RenderingUtils.ReAllocateHandleIfNeeded(ref m_DepthTexture, in descriptor4, FilterMode.Point, TextureWrapMode.Clamp, 1, 0f, "_CameraDepthTexture");
			commandBuffer.SetGlobalTexture(m_DepthTexture.name, m_DepthTexture.nameID);
			context.ExecuteCommandBuffer(commandBuffer);
			commandBuffer.Clear();
		}
		if (flag2 || (renderingModeActual == RenderingMode.Deferred && m_DeferredLights.UseRenderingLayers))
		{
			ref RTHandle reference = ref m_DecalLayersTexture;
			string name = "_CameraRenderingLayersTexture";
			if (renderingModeActual == RenderingMode.Deferred && m_DeferredLights.UseRenderingLayers)
			{
				reference = ref m_DeferredLights.GbufferAttachments[m_DeferredLights.GBufferRenderingLayers];
				name = reference.name;
			}
			RenderTextureDescriptor descriptor5 = descriptor;
			descriptor5.depthStencilFormat = GraphicsFormat.None;
			if (!flag4)
			{
				descriptor5.msaaSamples = 1;
			}
			if (renderingModeActual == RenderingMode.Deferred && m_DeferredLights.UseRenderingLayers)
			{
				descriptor5.graphicsFormat = m_DeferredLights.GetGBufferFormat(m_DeferredLights.GBufferRenderingLayers);
			}
			else
			{
				descriptor5.graphicsFormat = RenderingLayerUtils.GetFormat(combinedMaskSize);
			}
			if (renderingModeActual == RenderingMode.Deferred && m_DeferredLights.UseRenderingLayers)
			{
				m_DeferredLights.ReAllocateGBufferIfNeeded(descriptor5, m_DeferredLights.GBufferRenderingLayers);
			}
			else
			{
				RenderingUtils.ReAllocateHandleIfNeeded(ref reference, in descriptor5, FilterMode.Point, TextureWrapMode.Clamp, 1, 0f, name);
			}
			commandBuffer.SetGlobalTexture(reference.name, reference.nameID);
			RenderingLayerUtils.SetupProperties(CommandBufferHelpers.GetRasterCommandBuffer(commandBuffer), combinedMaskSize);
			if (renderingModeActual == RenderingMode.Deferred)
			{
				commandBuffer.SetGlobalTexture("_CameraRenderingLayersTexture", reference.nameID);
			}
			context.ExecuteCommandBuffer(commandBuffer);
			commandBuffer.Clear();
		}
		if (flag15 && renderPassInputs.requiresNormalsTexture)
		{
			ref RTHandle reference2 = ref m_NormalsTexture;
			string name2 = "_CameraNormalsTexture";
			if (renderingModeActual == RenderingMode.Deferred)
			{
				reference2 = ref m_DeferredLights.GbufferAttachments[m_DeferredLights.GBufferNormalSmoothnessIndex];
				name2 = reference2.name;
			}
			RenderTextureDescriptor descriptor6 = descriptor;
			descriptor6.depthStencilFormat = GraphicsFormat.None;
			descriptor6.msaaSamples = ((!base.useDepthPriming) ? 1 : descriptor.msaaSamples);
			if (renderingModeActual == RenderingMode.Deferred)
			{
				descriptor6.graphicsFormat = m_DeferredLights.GetGBufferFormat(m_DeferredLights.GBufferNormalSmoothnessIndex);
			}
			else
			{
				descriptor6.graphicsFormat = DepthNormalOnlyPass.GetGraphicsFormat();
			}
			if (renderingModeActual == RenderingMode.Deferred)
			{
				m_DeferredLights.ReAllocateGBufferIfNeeded(descriptor6, m_DeferredLights.GBufferNormalSmoothnessIndex);
			}
			else
			{
				RenderingUtils.ReAllocateHandleIfNeeded(ref reference2, in descriptor6, FilterMode.Point, TextureWrapMode.Clamp, 1, 0f, name2);
			}
			commandBuffer.SetGlobalTexture(reference2.name, reference2.nameID);
			if (renderingModeActual == RenderingMode.Deferred)
			{
				commandBuffer.SetGlobalTexture("_CameraNormalsTexture", reference2.nameID);
			}
			context.ExecuteCommandBuffer(commandBuffer);
			commandBuffer.Clear();
		}
		if (flag15)
		{
			if (renderPassInputs.requiresNormalsTexture)
			{
				if (renderingModeActual == RenderingMode.Deferred)
				{
					int gBufferNormalSmoothnessIndex = m_DeferredLights.GBufferNormalSmoothnessIndex;
					if (m_DeferredLights.UseRenderingLayers)
					{
						m_DepthNormalPrepass.Setup(m_ActiveCameraDepthAttachment, m_DeferredLights.GbufferAttachments[gBufferNormalSmoothnessIndex], m_DeferredLights.GbufferAttachments[m_DeferredLights.GBufferRenderingLayers]);
					}
					else if (flag3)
					{
						m_DepthNormalPrepass.Setup(m_ActiveCameraDepthAttachment, m_DeferredLights.GbufferAttachments[gBufferNormalSmoothnessIndex], m_DecalLayersTexture);
					}
					else
					{
						m_DepthNormalPrepass.Setup(m_ActiveCameraDepthAttachment, m_DeferredLights.GbufferAttachments[gBufferNormalSmoothnessIndex]);
					}
					if (RenderPassEvent.AfterRenderingGbuffer <= renderPassInputs.requiresDepthNormalAtEvent && renderPassInputs.requiresDepthNormalAtEvent <= RenderPassEvent.BeforeRenderingOpaques)
					{
						m_DepthNormalPrepass.shaderTagIds = k_DepthNormalsOnly;
					}
				}
				else if (flag3)
				{
					m_DepthNormalPrepass.Setup(m_DepthTexture, m_NormalsTexture, m_DecalLayersTexture);
				}
				else
				{
					m_DepthNormalPrepass.Setup(m_DepthTexture, m_NormalsTexture);
				}
				EnqueuePass(m_DepthNormalPrepass);
			}
			else if (renderingModeActual != RenderingMode.Deferred)
			{
				m_DepthPrepass.Setup(descriptor, m_DepthTexture);
				EnqueuePass(m_DepthPrepass);
			}
		}
		if (base.useDepthPriming)
		{
			m_PrimedDepthCopyPass.Setup(m_ActiveCameraDepthAttachment, m_DepthTexture);
			EnqueuePass(m_PrimedDepthCopyPass);
		}
		if (flag8)
		{
			colorGradingLutPass.ConfigureDescriptor(in postProcessingData, out var descriptor7, out var filterMode);
			RenderingUtils.ReAllocateHandleIfNeeded(ref m_PostProcessPasses.m_ColorGradingLut, in descriptor7, filterMode, TextureWrapMode.Clamp, 0, 0f, "_InternalGradingLut");
			colorGradingLutPass.Setup(colorGradingLut);
			EnqueuePass(colorGradingLutPass);
		}
		if (universalCameraData.xr.hasValidOcclusionMesh)
		{
			EnqueuePass(m_XROcclusionMeshPass);
		}
		bool resolveFinalTarget = universalCameraData.resolveFinalTarget;
		if (renderingModeActual == RenderingMode.Deferred)
		{
			if (m_DeferredLights.UseFramebufferFetch && (RenderPassEvent.AfterRenderingGbuffer == renderPassInputs.requiresDepthNormalAtEvent || !useRenderPassEnabled))
			{
				m_DeferredLights.DisableFramebufferFetchInput();
			}
			EnqueueDeferred(universalCameraData.cameraTargetDescriptor, flag15, renderPassInputs.requiresNormalsTexture, flag3, flag11, flag12);
		}
		else
		{
			RenderBufferStoreAction storeAction = RenderBufferStoreAction.Store;
			if (descriptor.msaaSamples > 1)
			{
				storeAction = (flag19 ? RenderBufferStoreAction.StoreAndResolve : RenderBufferStoreAction.Store);
			}
			RenderBufferStoreAction renderBufferStoreAction = ((!(flag19 | flag21) && resolveFinalTarget) ? RenderBufferStoreAction.DontCare : RenderBufferStoreAction.Store);
			if (universalCameraData.xr.enabled && universalCameraData.xr.copyDepth)
			{
				renderBufferStoreAction = RenderBufferStoreAction.Store;
			}
			if (flag21 && descriptor.msaaSamples > 1 && RenderingUtils.MultisampleDepthResolveSupported() && m_CopyDepthPass.renderPassEvent == RenderPassEvent.AfterRenderingTransparents && !flag19)
			{
				switch (renderBufferStoreAction)
				{
				case RenderBufferStoreAction.Store:
					renderBufferStoreAction = RenderBufferStoreAction.StoreAndResolve;
					break;
				case RenderBufferStoreAction.DontCare:
					renderBufferStoreAction = RenderBufferStoreAction.Resolve;
					break;
				}
			}
			DrawObjectsPass drawObjectsPass = null;
			if (flag4)
			{
				drawObjectsPass = m_RenderOpaqueForwardWithRenderingLayersPass;
				m_RenderOpaqueForwardWithRenderingLayersPass.Setup(m_ActiveCameraColorAttachment, m_DecalLayersTexture, m_ActiveCameraDepthAttachment);
			}
			else
			{
				drawObjectsPass = m_RenderOpaqueForwardPass;
			}
			drawObjectsPass.ConfigureColorStoreAction(storeAction);
			drawObjectsPass.ConfigureDepthStoreAction(renderBufferStoreAction);
			ClearFlag clearFlag = ((base.activeRenderPassQueue.Find((ScriptableRenderPass x) => x.renderPassEvent <= RenderPassEvent.BeforeRenderingOpaques && !x.overrideCameraTarget) == null && universalCameraData.renderType == CameraRenderType.Base && camera.clearFlags != CameraClearFlags.Nothing) ? ClearFlag.Color : ClearFlag.None);
			if (SystemInfo.usesLoadStoreActions)
			{
				drawObjectsPass.ConfigureClear(clearFlag, Color.black);
			}
			EnqueuePass(drawObjectsPass);
		}
		if (camera.clearFlags == CameraClearFlags.Skybox && universalCameraData.renderType != CameraRenderType.Overlay && (RenderSettings.skybox != null || (camera.TryGetComponent<Skybox>(out var component2) && component2.material != null)))
		{
			EnqueuePass(m_DrawSkyboxPass);
		}
		if (flag21 && (renderingModeActual != RenderingMode.Deferred || !useRenderPassEnabled || renderPassInputs.requiresDepthTexture))
		{
			m_CopyDepthPass.Setup(m_ActiveCameraDepthAttachment, m_DepthTexture);
			EnqueuePass(m_CopyDepthPass);
		}
		if (universalCameraData.renderType == CameraRenderType.Base && !flag15 && !flag21)
		{
			Shader.SetGlobalTexture("_CameraDepthTexture", SystemInfo.usesReversedZBuffer ? Texture2D.blackTexture : Texture2D.whiteTexture);
		}
		if (flag19)
		{
			Downsampling opaqueDownsampling = UniversalRenderPipeline.asset.opaqueDownsampling;
			RenderTextureDescriptor descriptor8 = descriptor;
			CopyColorPass.ConfigureDescriptor(opaqueDownsampling, ref descriptor8, out var filterMode2);
			RenderingUtils.ReAllocateHandleIfNeeded(ref m_OpaqueColor, in descriptor8, filterMode2, TextureWrapMode.Clamp, 1, 0f, "_CameraOpaqueTexture");
			m_CopyColorPass.Setup(m_ActiveCameraColorAttachment, m_OpaqueColor, opaqueDownsampling);
			EnqueuePass(m_CopyColorPass);
		}
		if (renderPassInputs.requiresMotionVectors)
		{
			RenderTextureDescriptor descriptor9 = descriptor;
			descriptor9.graphicsFormat = GraphicsFormat.R16G16_SFloat;
			descriptor9.depthStencilFormat = GraphicsFormat.None;
			descriptor9.msaaSamples = 1;
			RenderingUtils.ReAllocateHandleIfNeeded(ref m_MotionVectorColor, in descriptor9, FilterMode.Point, TextureWrapMode.Clamp, 1, 0f, "_MotionVectorTexture");
			RenderTextureDescriptor descriptor10 = descriptor;
			descriptor10.graphicsFormat = GraphicsFormat.None;
			descriptor10.depthStencilFormat = descriptor.depthStencilFormat;
			descriptor10.msaaSamples = 1;
			RenderingUtils.ReAllocateHandleIfNeeded(ref m_MotionVectorDepth, in descriptor10, FilterMode.Point, TextureWrapMode.Clamp, 1, 0f, "_MotionVectorDepthTexture");
			MotionVectorRenderPass.SetMotionVectorGlobalMatrices(commandBuffer, universalCameraData);
			m_MotionVectorPass.Setup(m_MotionVectorColor, m_MotionVectorDepth);
			EnqueuePass(m_MotionVectorPass);
		}
		if (flag13)
		{
			EnqueuePass(m_TransparentSettingsPass);
		}
		RenderBufferStoreAction storeAction2 = ((((descriptor.msaaSamples > 1) & resolveFinalTarget) && !isPreviewCamera) ? RenderBufferStoreAction.Resolve : RenderBufferStoreAction.Store);
		RenderBufferStoreAction storeAction3 = (resolveFinalTarget ? RenderBufferStoreAction.DontCare : RenderBufferStoreAction.Store);
		if (flag21 && m_CopyDepthPass.renderPassEvent >= RenderPassEvent.AfterRenderingTransparents)
		{
			storeAction3 = RenderBufferStoreAction.Store;
			if (descriptor.msaaSamples > 1 && RenderingUtils.MultisampleDepthResolveSupported())
			{
				storeAction3 = RenderBufferStoreAction.Resolve;
			}
		}
		m_RenderTransparentForwardPass.ConfigureColorStoreAction(storeAction2);
		m_RenderTransparentForwardPass.ConfigureDepthStoreAction(storeAction3);
		EnqueuePass(m_RenderTransparentForwardPass);
		EnqueuePass(m_OnRenderObjectCallbackPass);
		SetupVFXCameraBuffer(universalCameraData);
		SetupRawColorDepthHistory(universalCameraData, ref descriptor);
		bool rendersOverlayUI = universalCameraData.rendersOverlayUI;
		bool isHDROutputActive = universalCameraData.isHDROutputActive;
		if (rendersOverlayUI & isHDROutputActive)
		{
			m_DrawOffscreenUIPass.Setup(universalCameraData, cameraDepthTextureFormat);
			EnqueuePass(m_DrawOffscreenUIPass);
		}
		bool flag22 = (universalCameraData.captureActions != null) & resolveFinalTarget;
		bool flag23 = (flag6 & resolveFinalTarget) && (universalCameraData.antialiasing == AntialiasingMode.FastApproximateAntialiasing || (universalCameraData.imageScalingMode == ImageScalingMode.Upscaling && universalCameraData.upscalingFilter != ImageUpscalingFilter.Linear) || (universalCameraData.IsTemporalAAEnabled() && universalCameraData.taaSettings.contrastAdaptiveSharpening > 0f)) && (base.DebugHandler == null || (base.DebugHandler != null && base.DebugHandler.IsPostProcessingAllowed));
		bool flag24 = !flag22 && !flag20 && !flag23;
		bool flag25 = base.DebugHandler == null || !base.DebugHandler.HDRDebugViewIsActive(universalCameraData.resolveFinalTarget);
		if (flag5)
		{
			RenderTextureDescriptor descriptor11 = PostProcessPass.GetCompatibleDescriptor(descriptor, descriptor.width, descriptor.height, descriptor.graphicsFormat);
			RenderingUtils.ReAllocateHandleIfNeeded(ref m_PostProcessPasses.m_AfterPostProcessColor, in descriptor11, FilterMode.Point, TextureWrapMode.Clamp, 1, 0f, "_AfterPostProcessTexture");
		}
		if (resolveFinalTarget)
		{
			SetupFinalPassDebug(universalCameraData);
			if (flag5)
			{
				bool enableColorEncoding = flag24 & flag25;
				postProcessPass.Setup(in descriptor, in m_ActiveCameraColorAttachment, flag24, in m_ActiveCameraDepthAttachment, colorGradingLut, in m_MotionVectorColor, flag23, enableColorEncoding);
				EnqueuePass(postProcessPass);
			}
			RTHandle source = m_ActiveCameraColorAttachment;
			if (flag23)
			{
				finalPostProcessPass.SetupFinalPass(in source, useSwapBuffer: true, flag25);
				EnqueuePass(finalPostProcessPass);
			}
			if (universalCameraData.captureActions != null)
			{
				EnqueuePass(m_CapturePass);
			}
			if (!flag23 && (!flag5 || flag20 || flag22) && !(m_ActiveCameraColorAttachment.nameID == m_TargetColorHandle.nameID))
			{
				m_FinalBlitPass.Setup(descriptor, source);
				EnqueuePass(m_FinalBlitPass);
			}
			if (rendersOverlayUI && universalCameraData.isLastBaseCamera && !isHDROutputActive)
			{
				EnqueuePass(m_DrawOverlayUIPass);
			}
			if (universalCameraData.xr.enabled && !(m_ActiveCameraDepthAttachment.nameID == universalCameraData.xr.renderTarget) && universalCameraData.xr.copyDepth)
			{
				m_XRCopyDepthPass.Setup(m_ActiveCameraDepthAttachment, m_TargetDepthHandle);
				m_XRCopyDepthPass.CopyToDepthXR = true;
				EnqueuePass(m_XRCopyDepthPass);
			}
		}
		else if (flag5)
		{
			postProcessPass.Setup(in descriptor, in m_ActiveCameraColorAttachment, resolveToScreen: false, in m_ActiveCameraDepthAttachment, colorGradingLut, in m_MotionVectorColor, hasFinalPass: false, enableColorEncoding: false);
			EnqueuePass(postProcessPass);
		}
	}

	private void SetupVFXCameraBuffer(UniversalCameraData cameraData)
	{
		if (cameraData != null && cameraData.historyManager != null)
		{
			VFXCameraBufferTypes vFXCameraBufferTypes = VFXManager.IsCameraBufferNeeded(cameraData.camera);
			if (vFXCameraBufferTypes.HasFlag(VFXCameraBufferTypes.Color))
			{
				cameraData.historyManager.RequestAccess<RawColorHistory>();
				RTHandle rTHandle = cameraData.historyManager.GetHistoryForRead<RawColorHistory>()?.GetCurrentTexture();
				VFXManager.SetCameraBuffer(cameraData.camera, VFXCameraBufferTypes.Color, rTHandle, 0, 0, (int)((float)cameraData.pixelWidth * cameraData.renderScale), (int)((float)cameraData.pixelHeight * cameraData.renderScale));
			}
			if (vFXCameraBufferTypes.HasFlag(VFXCameraBufferTypes.Depth))
			{
				cameraData.historyManager.RequestAccess<RawDepthHistory>();
				RTHandle rTHandle2 = cameraData.historyManager.GetHistoryForRead<RawDepthHistory>()?.GetCurrentTexture();
				VFXManager.SetCameraBuffer(cameraData.camera, VFXCameraBufferTypes.Depth, rTHandle2, 0, 0, (int)((float)cameraData.pixelWidth * cameraData.renderScale), (int)((float)cameraData.pixelHeight * cameraData.renderScale));
			}
		}
	}

	private void SetupRawColorDepthHistory(UniversalCameraData cameraData, ref RenderTextureDescriptor cameraTargetDescriptor)
	{
		if (cameraData == null || cameraData.historyManager == null)
		{
			return;
		}
		UniversalCameraHistory historyManager = cameraData.historyManager;
		bool flag = false;
		int num = 0;
		flag = cameraData.xr.enabled && !cameraData.xr.singlePassEnabled;
		num = cameraData.xr.multipassId;
		if (historyManager.IsAccessRequested<RawColorHistory>() && m_ActiveCameraColorAttachment?.rt != null)
		{
			RawColorHistory historyForWrite = historyManager.GetHistoryForWrite<RawColorHistory>();
			if (historyForWrite != null)
			{
				historyForWrite.Update(ref cameraTargetDescriptor, flag);
				if (historyForWrite.GetCurrentTexture(num) != null)
				{
					m_HistoryRawColorCopyPass.Setup(m_ActiveCameraColorAttachment, historyForWrite.GetCurrentTexture(num), Downsampling.None);
					EnqueuePass(m_HistoryRawColorCopyPass);
				}
			}
		}
		if (!historyManager.IsAccessRequested<RawDepthHistory>() || !(m_ActiveCameraDepthAttachment?.rt != null))
		{
			return;
		}
		RawDepthHistory historyForWrite2 = historyManager.GetHistoryForWrite<RawDepthHistory>();
		if (historyForWrite2 != null)
		{
			if (!m_HistoryRawDepthCopyPass.CopyToDepth)
			{
				RenderTextureDescriptor cameraDesc = cameraTargetDescriptor;
				cameraDesc.colorFormat = RenderTextureFormat.RFloat;
				cameraDesc.graphicsFormat = GraphicsFormat.R32_SFloat;
				cameraDesc.depthStencilFormat = GraphicsFormat.None;
				historyForWrite2.Update(ref cameraDesc, flag);
			}
			else
			{
				RenderTextureDescriptor cameraDesc2 = cameraData.cameraTargetDescriptor;
				cameraDesc2.graphicsFormat = GraphicsFormat.None;
				historyForWrite2.Update(ref cameraDesc2, flag);
			}
			if (historyForWrite2.GetCurrentTexture(num) != null)
			{
				m_HistoryRawDepthCopyPass.Setup(m_ActiveCameraDepthAttachment, historyForWrite2.GetCurrentTexture(num));
				EnqueuePass(m_HistoryRawDepthCopyPass);
			}
		}
	}

	[Obsolete("This rendering path is for compatibility mode only (when Render Graph is disabled). Use Render Graph API instead.", false)]
	public override void SetupLights(ScriptableRenderContext context, ref RenderingData renderingData)
	{
		UniversalRenderingData renderingData2 = base.frameData.Get<UniversalRenderingData>();
		UniversalCameraData universalCameraData = base.frameData.Get<UniversalCameraData>();
		UniversalLightData lightData = base.frameData.Get<UniversalLightData>();
		m_ForwardLights.SetupLights(CommandBufferHelpers.GetUnsafeCommandBuffer(renderingData.commandBuffer), renderingData2, universalCameraData, lightData);
		if (renderingModeActual == RenderingMode.Deferred)
		{
			m_DeferredLights.SetupLights(renderingData.commandBuffer, universalCameraData, new Vector2Int(universalCameraData.cameraTargetDescriptor.width, universalCameraData.cameraTargetDescriptor.height), lightData);
		}
	}

	public override void SetupCullingParameters(ref ScriptableCullingParameters cullingParameters, ref CameraData cameraData)
	{
		if (renderingModeActual == RenderingMode.ForwardPlus && UniversalRenderPipeline.asset.ShouldUseReflectionProbeBlending())
		{
			cullingParameters.cullingOptions |= CullingOptions.DisablePerObjectCulling;
		}
		bool num = !UniversalRenderPipeline.asset.supportsMainLightShadows && !UniversalRenderPipeline.asset.supportsAdditionalLightShadows;
		bool flag = Mathf.Approximately(cameraData.maxShadowDistance, 0f);
		if (num | flag)
		{
			cullingParameters.cullingOptions &= ~CullingOptions.ShadowCasters;
		}
		if (renderingModeActual == RenderingMode.Deferred)
		{
			cullingParameters.maximumVisibleLights = 65535;
		}
		else if (renderingModeActual == RenderingMode.ForwardPlus)
		{
			cullingParameters.maximumVisibleLights = UniversalRenderPipeline.maxVisibleAdditionalLights;
			cullingParameters.reflectionProbeSortingCriteria = ReflectionProbeSortingCriteria.None;
		}
		else
		{
			cullingParameters.maximumVisibleLights = UniversalRenderPipeline.maxVisibleAdditionalLights + 1;
		}
		cullingParameters.shadowDistance = cameraData.maxShadowDistance;
		cullingParameters.conservativeEnclosingSphere = UniversalRenderPipeline.asset.conservativeEnclosingSphere;
		cullingParameters.numIterationsEnclosingSphere = UniversalRenderPipeline.asset.numIterationsEnclosingSphere;
	}

	public override void FinishRendering(CommandBuffer cmd)
	{
		m_ColorBufferSystem.Clear();
		m_ActiveCameraColorAttachment = null;
		m_ActiveCameraDepthAttachment = null;
	}

	private void EnqueueDeferred(RenderTextureDescriptor cameraTargetDescriptor, bool hasDepthPrepass, bool hasNormalPrepass, bool hasRenderingLayerPrepass, bool applyMainShadow, bool applyAdditionalShadow)
	{
		m_DeferredLights.Setup(applyAdditionalShadow ? m_AdditionalLightsShadowCasterPass : null, hasDepthPrepass, hasNormalPrepass, hasRenderingLayerPrepass, m_DepthTexture, m_ActiveCameraDepthAttachment, m_ActiveCameraColorAttachment);
		if (useRenderPassEnabled && m_DeferredLights.UseFramebufferFetch)
		{
			m_GBufferPass.Configure(null, cameraTargetDescriptor);
			m_DeferredPass.Configure(null, cameraTargetDescriptor);
		}
		EnqueuePass(m_GBufferPass);
		if (!useRenderPassEnabled || !m_DeferredLights.UseFramebufferFetch)
		{
			m_GBufferCopyDepthPass.Setup(m_CameraDepthAttachment, m_DepthTexture);
			EnqueuePass(m_GBufferCopyDepthPass);
		}
		EnqueuePass(m_DeferredPass);
		EnqueuePass(m_RenderOpaqueForwardOnlyPass);
	}

	private RenderPassInputSummary GetRenderPassInputs(bool isTemporalAAEnabled, bool postProcessingEnabled, bool isSceneViewCamera)
	{
		RenderPassInputSummary result = new RenderPassInputSummary
		{
			requiresDepthNormalAtEvent = RenderPassEvent.BeforeRenderingOpaques,
			requiresDepthTextureEarliestEvent = RenderPassEvent.BeforeRenderingPostProcessing
		};
		for (int i = 0; i < base.activeRenderPassQueue.Count; i++)
		{
			ScriptableRenderPass scriptableRenderPass = base.activeRenderPassQueue[i];
			bool flag = (scriptableRenderPass.input & ScriptableRenderPassInput.Depth) != 0;
			bool flag2 = (scriptableRenderPass.input & ScriptableRenderPassInput.Normal) != 0;
			bool flag3 = (scriptableRenderPass.input & ScriptableRenderPassInput.Color) != 0;
			bool flag4 = (scriptableRenderPass.input & ScriptableRenderPassInput.Motion) != 0;
			bool flag5 = scriptableRenderPass.renderPassEvent < RenderPassEvent.AfterRenderingOpaques;
			if (scriptableRenderPass is DBufferRenderPass)
			{
				result.requiresColorTextureCreated = true;
			}
			result.requiresDepthTexture |= flag;
			result.requiresDepthPrepass |= flag2 || (flag & flag5);
			result.requiresNormalsTexture |= flag2;
			result.requiresColorTexture |= flag3;
			result.requiresMotionVectors |= flag4;
			if (flag)
			{
				result.requiresDepthTextureEarliestEvent = (RenderPassEvent)Mathf.Min((int)scriptableRenderPass.renderPassEvent, (int)result.requiresDepthTextureEarliestEvent);
			}
			if (flag2 | flag)
			{
				result.requiresDepthNormalAtEvent = (RenderPassEvent)Mathf.Min((int)scriptableRenderPass.renderPassEvent, (int)result.requiresDepthNormalAtEvent);
			}
		}
		if (isTemporalAAEnabled)
		{
			result.requiresMotionVectors = true;
		}
		if (postProcessingEnabled)
		{
			MotionBlur component = VolumeManager.instance.stack.GetComponent<MotionBlur>();
			if (component != null && component.IsActive() && component.mode.value == MotionBlurMode.CameraAndObjects)
			{
				result.requiresMotionVectors = true;
			}
		}
		if (result.requiresMotionVectors)
		{
			result.requiresDepthTexture = true;
			result.requiresDepthTextureEarliestEvent = (RenderPassEvent)Mathf.Min((int)m_MotionVectorPass.renderPassEvent, (int)result.requiresDepthTextureEarliestEvent);
		}
		return result;
	}

	private void CreateCameraRenderTarget(ScriptableRenderContext context, ref RenderTextureDescriptor descriptor, CommandBuffer cmd, UniversalCameraData cameraData)
	{
		using (new ProfilingScope(Profiling.createCameraRenderTarget))
		{
			if (m_ColorBufferSystem.PeekBackBuffer() == null || m_ColorBufferSystem.PeekBackBuffer().nameID != BuiltinRenderTextureType.CameraTarget)
			{
				m_ActiveCameraColorAttachment = m_ColorBufferSystem.GetBackBuffer(cmd);
				ConfigureCameraColorTarget(m_ActiveCameraColorAttachment);
				cmd.SetGlobalTexture("_CameraColorTexture", m_ActiveCameraColorAttachment.nameID);
				cmd.SetGlobalTexture("_AfterPostProcessTexture", m_ActiveCameraColorAttachment.nameID);
			}
			if (m_CameraDepthAttachment == null || m_CameraDepthAttachment.nameID != BuiltinRenderTextureType.CameraTarget)
			{
				RenderTextureDescriptor descriptor2 = descriptor;
				descriptor2.useMipMap = false;
				descriptor2.autoGenerateMips = false;
				descriptor2.bindMS = false;
				if (descriptor2.msaaSamples > 1 && SystemInfo.supportsMultisampledTextures != 0)
				{
					if (IsDepthPrimingEnabled(cameraData))
					{
						descriptor2.bindMS = true;
					}
					else
					{
						descriptor2.bindMS = !RenderingUtils.MultisampleDepthResolveSupported() || m_CopyDepthMode != CopyDepthMode.AfterTransparents;
					}
				}
				if (IsGLESDevice())
				{
					descriptor2.bindMS = false;
				}
				descriptor2.graphicsFormat = GraphicsFormat.None;
				descriptor2.depthStencilFormat = cameraDepthAttachmentFormat;
				RenderingUtils.ReAllocateHandleIfNeeded(ref m_CameraDepthAttachment, in descriptor2, FilterMode.Point, TextureWrapMode.Clamp, 1, 0f, "_CameraDepthAttachment");
				if (SystemInfo.graphicsDeviceType == GraphicsDeviceType.Direct3D11)
				{
					RenderingUtils.ReAllocateHandleIfNeeded(ref m_CameraDepthAttachment_D3d_11, in descriptor2, FilterMode.Point, TextureWrapMode.Clamp, 1, 0f, "_CameraDepthAttachment_Temp");
					cmd.SetGlobalTexture(m_CameraDepthAttachment.name, m_CameraDepthAttachment_D3d_11.nameID);
				}
				else
				{
					cmd.SetGlobalTexture(m_CameraDepthAttachment.name, m_CameraDepthAttachment.nameID);
				}
				descriptor.depthStencilFormat = descriptor2.depthStencilFormat;
			}
		}
		context.ExecuteCommandBuffer(cmd);
		cmd.Clear();
	}

	internal static bool PlatformRequiresExplicitMsaaResolve()
	{
		if (!SystemInfo.supportsMultisampleAutoResolve || !Application.isMobilePlatform)
		{
			return SystemInfo.graphicsDeviceType != GraphicsDeviceType.Metal;
		}
		return false;
	}

	private bool RequiresIntermediateColorTexture(UniversalCameraData cameraData, ref RenderPassInputSummary renderPassInputs)
	{
		if (cameraData.renderType == CameraRenderType.Base && !cameraData.resolveFinalTarget)
		{
			return true;
		}
		if (renderingModeActual == RenderingMode.Deferred)
		{
			return true;
		}
		bool isSceneViewCamera = cameraData.isSceneViewCamera;
		RenderTextureDescriptor cameraTargetDescriptor = cameraData.cameraTargetDescriptor;
		int msaaSamples = cameraTargetDescriptor.msaaSamples;
		bool flag = cameraData.imageScalingMode != ImageScalingMode.None;
		bool flag2 = cameraTargetDescriptor.dimension == TextureDimension.Tex2D;
		bool flag3 = msaaSamples > 1 && PlatformRequiresExplicitMsaaResolve();
		bool num = cameraData.targetTexture != null && !isSceneViewCamera;
		bool flag4 = cameraData.captureActions != null;
		if (cameraData.xr.enabled)
		{
			flag = false;
			flag2 = cameraData.xr.renderTargetDesc.dimension == cameraTargetDescriptor.dimension;
		}
		bool flag5 = (((cameraData.postProcessEnabled && m_PostProcessPasses.isCreated) || cameraData.requiresOpaqueTexture) | flag3) || !cameraData.isDefaultViewport;
		if (num)
		{
			return flag5;
		}
		if (!(((flag5 | flag) || cameraData.isHdrEnabled || !flag2) | flag4) && !cameraData.requireSrgbConversion && !renderPassInputs.requiresColorTexture)
		{
			return renderPassInputs.requiresColorTextureCreated;
		}
		return true;
	}

	private bool CanCopyDepth(UniversalCameraData cameraData)
	{
		bool num = cameraData.cameraTargetDescriptor.msaaSamples > 1;
		bool flag = SystemInfo.copyTextureSupport != CopyTextureSupport.None;
		bool flag2 = RenderingUtils.SupportsRenderTextureFormat(RenderTextureFormat.Depth);
		bool flag3 = !num && (flag2 | flag);
		bool flag4 = num && SystemInfo.supportsMultisampledTextures != 0;
		if (IsGLESDevice() & flag4)
		{
			return false;
		}
		return flag3 | flag4;
	}

	internal override void SwapColorBuffer(CommandBuffer cmd)
	{
		m_ColorBufferSystem.Swap();
		if (m_ActiveCameraDepthAttachment.nameID != BuiltinRenderTextureType.CameraTarget)
		{
			ConfigureCameraTarget(m_ColorBufferSystem.GetBackBuffer(cmd), m_ActiveCameraDepthAttachment);
		}
		else
		{
			ConfigureCameraColorTarget(m_ColorBufferSystem.GetBackBuffer(cmd));
		}
		m_ActiveCameraColorAttachment = m_ColorBufferSystem.GetBackBuffer(cmd);
		cmd.SetGlobalTexture("_CameraColorTexture", m_ActiveCameraColorAttachment.nameID);
		cmd.SetGlobalTexture("_AfterPostProcessTexture", m_ActiveCameraColorAttachment.nameID);
	}

	[Obsolete("This rendering path is for compatibility mode only (when Render Graph is disabled). Use Render Graph API instead.", false)]
	internal override RTHandle GetCameraColorFrontBuffer(CommandBuffer cmd)
	{
		return m_ColorBufferSystem.GetFrontBuffer(cmd);
	}

	[Obsolete("This rendering path is for compatibility mode only (when Render Graph is disabled). Use Render Graph API instead.", false)]
	internal override RTHandle GetCameraColorBackBuffer(CommandBuffer cmd)
	{
		return m_ColorBufferSystem.GetBackBuffer(cmd);
	}

	internal override void EnableSwapBufferMSAA(bool enable)
	{
		m_ColorBufferSystem.EnableMSAA(enable);
	}

	private bool DebugHandlerRequireDepthPass(UniversalCameraData cameraData)
	{
		if (base.DebugHandler != null && base.DebugHandler.IsActiveForCamera(cameraData.isPreviewCamera) && base.DebugHandler.TryGetFullscreenDebugMode(out var _))
		{
			return true;
		}
		return false;
	}

	private void CreateDebugTexture(RenderTextureDescriptor descriptor)
	{
		RenderTextureDescriptor descriptor2 = descriptor;
		descriptor2.useMipMap = false;
		descriptor2.autoGenerateMips = false;
		descriptor2.bindMS = false;
		descriptor2.depthStencilFormat = GraphicsFormat.None;
		RenderingUtils.ReAllocateHandleIfNeeded(ref m_RenderGraphDebugTextureHandle, in descriptor2, FilterMode.Point, TextureWrapMode.Clamp, 1, 0f, "_RenderingDebuggerTexture");
	}

	private Rect CalculateUVRect(UniversalCameraData cameraData, float width, float height)
	{
		float num = width / (float)cameraData.pixelWidth;
		float num2 = height / (float)cameraData.pixelHeight;
		return new Rect(1f - num, 1f - num2, num, num2);
	}

	private Rect CalculateUVRect(UniversalCameraData cameraData, int textureHeightPercent)
	{
		float num = Mathf.Clamp01((float)textureHeightPercent / 100f);
		float width = num * (float)cameraData.pixelWidth;
		float height = num * (float)cameraData.pixelHeight;
		return CalculateUVRect(cameraData, width, height);
	}

	private void CorrectForTextureAspectRatio(ref float width, ref float height, float sourceWidth, float sourceHeight)
	{
		if (sourceWidth != 0f && sourceHeight != 0f)
		{
			float num = height * sourceWidth / sourceHeight;
			if (num > width)
			{
				height = width * sourceHeight / sourceWidth;
			}
			else
			{
				width = num;
			}
		}
	}

	private void SetupRenderGraphFinalPassDebug(RenderGraph renderGraph, ContextContainer frameData)
	{
		UniversalResourceData universalResourceData = frameData.Get<UniversalResourceData>();
		UniversalCameraData universalCameraData = frameData.Get<UniversalCameraData>();
		if (base.DebugHandler != null && base.DebugHandler.IsActiveForCamera(universalCameraData.isPreviewCamera))
		{
			if (base.DebugHandler.TryGetFullscreenDebugMode(out var debugFullScreenMode, out var textureHeightPercent) && (debugFullScreenMode != DebugFullScreenMode.ReflectionProbeAtlas || m_Clustering) && debugFullScreenMode != DebugFullScreenMode.STP)
			{
				float num = universalCameraData.pixelWidth;
				float num2 = universalCameraData.pixelHeight;
				float num3 = Mathf.Clamp01((float)textureHeightPercent / 100f);
				float height = num3 * num2;
				float width = num3 * num;
				bool supportsStereo = false;
				Vector4 zero = Vector4.zero;
				RenderTextureDescriptor cameraTargetDescriptor = universalCameraData.cameraTargetDescriptor;
				if (SystemInfo.IsFormatSupported(GraphicsFormat.R16G16B16A16_SFloat, GraphicsFormatUsage.Linear | GraphicsFormatUsage.Render))
				{
					cameraTargetDescriptor.graphicsFormat = GraphicsFormat.R16G16B16A16_SFloat;
				}
				CreateDebugTexture(cameraTargetDescriptor);
				TextureHandle destination = renderGraph.ImportTexture(importParams: new ImportResourceParams
				{
					clearOnFirstUse = false,
					discardOnLastUse = false
				}, rt: m_RenderGraphDebugTextureHandle);
				switch (debugFullScreenMode)
				{
				case DebugFullScreenMode.Depth:
					BlitToDebugTexture(renderGraph, universalResourceData.cameraDepthTexture, destination);
					supportsStereo = true;
					break;
				case DebugFullScreenMode.MotionVector:
					BlitToDebugTexture(renderGraph, universalResourceData.motionVectorColor, destination, isSourceTextureColor: true);
					supportsStereo = true;
					zero.x = -0.01f;
					zero.y = 0.01f;
					zero.z = 0f;
					zero.w = 1f;
					break;
				case DebugFullScreenMode.AdditionalLightsShadowMap:
					BlitToDebugTexture(renderGraph, universalResourceData.additionalShadowsTexture, destination);
					break;
				case DebugFullScreenMode.MainLightShadowMap:
					BlitToDebugTexture(renderGraph, universalResourceData.mainShadowsTexture, destination);
					break;
				case DebugFullScreenMode.AdditionalLightsCookieAtlas:
				{
					LightCookieManager lightCookieManager = m_LightCookieManager;
					TextureHandle source2 = ((lightCookieManager != null && lightCookieManager.AdditionalLightsCookieAtlasTexture != null) ? renderGraph.ImportTexture(m_LightCookieManager.AdditionalLightsCookieAtlasTexture) : TextureHandle.nullHandle);
					BlitToDebugTexture(renderGraph, source2, destination);
					break;
				}
				case DebugFullScreenMode.ReflectionProbeAtlas:
				{
					TextureHandle source = ((m_ForwardLights.reflectionProbeManager.atlasRT != null) ? renderGraph.ImportTexture(RTHandles.Alloc(m_ForwardLights.reflectionProbeManager.atlasRT, transferOwnership: true)) : TextureHandle.nullHandle);
					BlitToDebugTexture(renderGraph, source, destination);
					break;
				}
				}
				RenderTexture renderTexture = null;
				switch (debugFullScreenMode)
				{
				case DebugFullScreenMode.AdditionalLightsShadowMap:
					renderTexture = m_AdditionalLightsShadowCasterPass?.m_AdditionalLightsShadowmapHandle?.rt;
					break;
				case DebugFullScreenMode.MainLightShadowMap:
					renderTexture = m_MainLightShadowCasterPass?.m_MainLightShadowmapTexture?.rt;
					break;
				case DebugFullScreenMode.AdditionalLightsCookieAtlas:
					renderTexture = m_LightCookieManager?.AdditionalLightsCookieAtlasTexture?.rt;
					break;
				case DebugFullScreenMode.ReflectionProbeAtlas:
					renderTexture = m_ForwardLights?.reflectionProbeManager.atlasRT;
					break;
				}
				if (renderTexture != null)
				{
					CorrectForTextureAspectRatio(ref width, ref height, renderTexture.width, renderTexture.height);
				}
				Rect displayRect = CalculateUVRect(universalCameraData, width, height);
				base.DebugHandler.SetDebugRenderTarget(m_RenderGraphDebugTextureHandle, displayRect, supportsStereo, zero);
			}
			else
			{
				base.DebugHandler.ResetDebugRenderTarget();
			}
		}
		if (base.DebugHandler != null && !base.DebugHandler.TryGetFullscreenDebugMode(out var _, out var textureHeightPercent2))
		{
			DebugDisplayGPUResidentDrawer gpuResidentDrawerSettings = base.DebugHandler.DebugDisplaySettings.gpuResidentDrawerSettings;
			GPUResidentDrawer.RenderDebugOcclusionTestOverlay(renderGraph, gpuResidentDrawerSettings, universalCameraData.camera.GetInstanceID(), universalResourceData.activeColorTexture);
			float num4 = (int)((float)universalCameraData.pixelHeight * universalCameraData.renderScale);
			float num5 = (int)((float)universalCameraData.pixelHeight * universalCameraData.renderScale);
			float num6 = num5 * (float)textureHeightPercent2 / 100f;
			GPUResidentDrawer.RenderDebugOccluderOverlay(renderGraph, gpuResidentDrawerSettings, new Vector2(0.25f * num4, num5 - 1.5f * num6), num6, universalResourceData.activeColorTexture);
		}
	}

	private void SetupAfterPostRenderGraphFinalPassDebug(RenderGraph renderGraph, ContextContainer frameData)
	{
		UniversalResourceData universalResourceData = frameData.Get<UniversalResourceData>();
		UniversalCameraData universalCameraData = frameData.Get<UniversalCameraData>();
		if (base.DebugHandler != null && base.DebugHandler.IsActiveForCamera(universalCameraData.isPreviewCamera) && base.DebugHandler.TryGetFullscreenDebugMode(out var debugFullScreenMode, out var textureHeightPercent) && debugFullScreenMode == DebugFullScreenMode.STP)
		{
			CreateDebugTexture(universalCameraData.cameraTargetDescriptor);
			TextureHandle destination = renderGraph.ImportTexture(importParams: new ImportResourceParams
			{
				clearOnFirstUse = false,
				discardOnLastUse = false
			}, rt: m_RenderGraphDebugTextureHandle);
			BlitToDebugTexture(renderGraph, universalResourceData.stpDebugView, destination);
			Rect displayRect = CalculateUVRect(universalCameraData, textureHeightPercent);
			Vector4 zero = Vector4.zero;
			base.DebugHandler.SetDebugRenderTarget(m_RenderGraphDebugTextureHandle, displayRect, supportsStereo: true, zero);
		}
	}

	private void BlitToDebugTexture(RenderGraph renderGraph, TextureHandle source, TextureHandle destination, bool isSourceTextureColor = false)
	{
		if (source.IsValid())
		{
			if (isSourceTextureColor)
			{
				renderGraph.AddCopyPass(source, destination, "Copy Pass Utility", "C:\\Users\\steph\\GameDev\\GetToWork2\\GetToWork\\Library\\PackageCache\\com.unity.render-pipelines.universal@7652a5c7e246\\Runtime\\UniversalRendererDebug.cs", 251);
				return;
			}
			UnityEngine.Rendering.RenderGraphModule.Util.RenderGraphUtils.BlitMaterialParameters blitParameters = new UnityEngine.Rendering.RenderGraphModule.Util.RenderGraphUtils.BlitMaterialParameters(source, destination, m_DebugBlitMaterial, 0);
			renderGraph.AddBlitPass(blitParameters, "Blit Pass Utility w. Material", "C:\\Users\\steph\\GameDev\\GetToWork2\\GetToWork\\Library\\PackageCache\\com.unity.render-pipelines.universal@7652a5c7e246\\Runtime\\UniversalRendererDebug.cs", 260);
		}
		else
		{
			BlitEmptyTexture(renderGraph, destination);
		}
	}

	private void BlitEmptyTexture(RenderGraph renderGraph, TextureHandle destination, string passName = "Copy To Debug Texture")
	{
		CopyToDebugTexturePassData passData;
		using IRasterRenderGraphBuilder rasterRenderGraphBuilder = renderGraph.AddRasterRenderPass<CopyToDebugTexturePassData>(passName, out passData, "C:\\Users\\steph\\GameDev\\GetToWork2\\GetToWork\\Library\\PackageCache\\com.unity.render-pipelines.universal@7652a5c7e246\\Runtime\\UniversalRendererDebug.cs", 271);
		passData.src = renderGraph.defaultResources.blackTexture;
		passData.dest = destination;
		rasterRenderGraphBuilder.SetRenderAttachment(destination, 0);
		rasterRenderGraphBuilder.AllowPassCulling(value: false);
		rasterRenderGraphBuilder.SetRenderFunc((CopyToDebugTexturePassData data, RasterGraphContext context) =>
		{
			Blitter.BlitTexture(context.cmd, data.src, new Vector4(1f, 1f, 0f, 0f), 0f, bilinear: false);
		});
	}

	private void CleanupRenderGraphResources()
	{
		m_RenderGraphCameraColorHandles[0]?.Release();
		m_RenderGraphCameraColorHandles[1]?.Release();
		m_RenderGraphCameraDepthHandle?.Release();
		m_RenderGraphDebugTextureHandle?.Release();
	}

	public static TextureHandle CreateRenderGraphTexture(RenderGraph renderGraph, RenderTextureDescriptor desc, string name, bool clear, FilterMode filterMode = FilterMode.Point, TextureWrapMode wrapMode = TextureWrapMode.Clamp)
	{
		TextureDesc desc2 = new TextureDesc(desc.width, desc.height);
		desc2.dimension = desc.dimension;
		desc2.clearBuffer = clear;
		desc2.bindTextureMS = desc.bindMS;
		desc2.format = ((desc.depthStencilFormat != GraphicsFormat.None) ? desc.depthStencilFormat : desc.graphicsFormat);
		desc2.slices = desc.volumeDepth;
		desc2.msaaSamples = (MSAASamples)desc.msaaSamples;
		desc2.name = name;
		desc2.enableRandomWrite = desc.enableRandomWrite;
		desc2.filterMode = filterMode;
		desc2.wrapMode = wrapMode;
		desc2.isShadowMap = desc.shadowSamplingMode != ShadowSamplingMode.None && desc.depthStencilFormat != GraphicsFormat.None;
		desc2.vrUsage = desc.vrUsage;
		desc2.useDynamicScale = desc.useDynamicScale;
		desc2.useDynamicScaleExplicit = desc.useDynamicScaleExplicit;
		return renderGraph.CreateTexture(in desc2);
	}

	internal static TextureHandle CreateRenderGraphTexture(RenderGraph renderGraph, RenderTextureDescriptor desc, string name, bool clear, Color color, FilterMode filterMode = FilterMode.Point, TextureWrapMode wrapMode = TextureWrapMode.Clamp, bool discardOnLastUse = false)
	{
		TextureDesc desc2 = new TextureDesc(desc.width, desc.height);
		desc2.dimension = desc.dimension;
		desc2.clearBuffer = clear;
		desc2.clearColor = color;
		desc2.bindTextureMS = desc.bindMS;
		desc2.format = ((desc.depthStencilFormat != GraphicsFormat.None) ? desc.depthStencilFormat : desc.graphicsFormat);
		desc2.slices = desc.volumeDepth;
		desc2.msaaSamples = (MSAASamples)desc.msaaSamples;
		desc2.name = name;
		desc2.enableRandomWrite = desc.enableRandomWrite;
		desc2.filterMode = filterMode;
		desc2.wrapMode = wrapMode;
		desc2.useDynamicScale = desc.useDynamicScale;
		desc2.useDynamicScaleExplicit = desc.useDynamicScaleExplicit;
		desc2.discardBuffer = discardOnLastUse;
		desc2.vrUsage = desc.vrUsage;
		return renderGraph.CreateTexture(in desc2);
	}

	private bool ShouldApplyPostProcessing(bool postProcessEnabled)
	{
		if (postProcessEnabled)
		{
			return m_PostProcessPasses.isCreated;
		}
		return false;
	}

	private bool CameraHasPostProcessingWithDepth(UniversalCameraData cameraData)
	{
		if (ShouldApplyPostProcessing(cameraData.postProcessEnabled))
		{
			return cameraData.postProcessingRequiresDepthTexture;
		}
		return false;
	}

	private bool RequiresIntermediateAttachments(UniversalCameraData cameraData, ref RenderPassInputSummary renderPassInputs)
	{
		bool requiresDepthPrepass = RequireDepthPrepass(cameraData, ref renderPassInputs);
		bool num = (HasActiveRenderFeatures() && m_IntermediateTextureMode == IntermediateTextureMode.Always) | HasPassesRequiringIntermediateTexture() | (Application.isEditor && m_Clustering) | RequiresIntermediateColorTexture(cameraData, ref renderPassInputs);
		bool flag = RequireDepthTexture(cameraData, requiresDepthPrepass, ref renderPassInputs);
		base.useDepthPriming = IsDepthPrimingEnabled(cameraData);
		return num | flag;
	}

	private void UpdateCameraHistory(UniversalCameraData cameraData)
	{
		if (cameraData != null && cameraData.historyManager != null)
		{
			int num = 0;
			bool num2 = cameraData.xr.enabled && !cameraData.xr.singlePassEnabled;
			num = cameraData.xr.multipassId;
			if (!num2 || num == 0)
			{
				UniversalCameraHistory historyManager = cameraData.historyManager;
				historyManager.GatherHistoryRequests();
				historyManager.ReleaseUnusedHistory();
				historyManager.SwapAndSetReferenceSize(cameraData.cameraTargetDescriptor.width, cameraData.cameraTargetDescriptor.height);
			}
		}
	}

	private void CreateRenderGraphCameraRenderTargets(RenderGraph renderGraph, bool isCameraTargetOffscreenDepth)
	{
		UniversalResourceData universalResourceData = base.frameData.Get<UniversalResourceData>();
		UniversalCameraData universalCameraData = base.frameData.Get<UniversalCameraData>();
		UniversalPostProcessingData universalPostProcessingData = base.frameData.Get<UniversalPostProcessingData>();
		bool resolveFinalTarget = universalCameraData.resolveFinalTarget;
		bool flag = universalCameraData.targetTexture == null;
		RenderTargetIdentifier renderTargetIdentifier = ((universalCameraData.targetTexture != null) ? new RenderTargetIdentifier(universalCameraData.targetTexture) : ((RenderTargetIdentifier)BuiltinRenderTextureType.CameraTarget));
		RenderTargetIdentifier renderTargetIdentifier2 = ((universalCameraData.targetTexture != null) ? new RenderTargetIdentifier(universalCameraData.targetTexture) : ((RenderTargetIdentifier)BuiltinRenderTextureType.Depth));
		bool flag2 = universalCameraData.renderType == CameraRenderType.Base;
		bool clearOnFirstUse = universalCameraData.renderType == CameraRenderType.Base || universalCameraData.clearDepth;
		Color color = ((universalCameraData.camera.clearFlags == CameraClearFlags.Nothing && universalCameraData.targetTexture == null) ? Color.yellow : universalCameraData.backgroundColor);
		if (IsSceneFilteringEnabled(universalCameraData.camera))
		{
			color.a = 0f;
			clearOnFirstUse = false;
		}
		DebugHandler debugHandler = universalCameraData.renderer.DebugHandler;
		if (debugHandler != null && debugHandler.IsActiveForCamera(universalCameraData.isPreviewCamera) && debugHandler.IsScreenClearNeeded)
		{
			flag2 = true;
			clearOnFirstUse = true;
			if (base.DebugHandler != null && base.DebugHandler.IsActiveForCamera(universalCameraData.isPreviewCamera))
			{
				base.DebugHandler.TryGetScreenClearColor(ref color);
			}
		}
		if (universalCameraData.xr.enabled)
		{
			renderTargetIdentifier = universalCameraData.xr.renderTarget;
			renderTargetIdentifier2 = universalCameraData.xr.renderTarget;
			flag = false;
		}
		if (m_TargetColorHandle == null)
		{
			m_TargetColorHandle = RTHandles.Alloc(renderTargetIdentifier, "Backbuffer color");
		}
		else if (m_TargetColorHandle.nameID != renderTargetIdentifier)
		{
			RTHandleStaticHelpers.SetRTHandleUserManagedWrapper(ref m_TargetColorHandle, renderTargetIdentifier);
		}
		if (m_TargetDepthHandle == null)
		{
			m_TargetDepthHandle = RTHandles.Alloc(renderTargetIdentifier2, "Backbuffer depth");
		}
		else if (m_TargetDepthHandle.nameID != renderTargetIdentifier2)
		{
			RTHandleStaticHelpers.SetRTHandleUserManagedWrapper(ref m_TargetDepthHandle, renderTargetIdentifier2);
		}
		UpdateCameraHistory(universalCameraData);
		RenderPassInputSummary renderPassInputs = GetRenderPassInputs(universalCameraData.IsTemporalAAEnabled(), universalPostProcessingData.isEnabled, universalCameraData.isSceneViewCamera);
		if (m_RenderingLayerProvidesByDepthNormalPass)
		{
			renderPassInputs.requiresNormalsTexture = true;
		}
		if (universalCameraData.renderType == CameraRenderType.Base)
		{
			m_RequiresIntermediateAttachments = RequiresIntermediateAttachments(universalCameraData, ref renderPassInputs);
		}
		bool flag3 = universalCameraData.renderType == CameraRenderType.Base && !m_RequiresIntermediateAttachments;
		flag3 |= isCameraTargetOffscreenDepth;
		bool flag4 = !SupportedRenderingFeatures.active.rendersUIOverlay && universalCameraData.resolveToScreen;
		bool flag5 = Watermark.IsVisible() | flag4;
		bool discardOnLastUse = !m_RequiresIntermediateAttachments && !flag5 && universalCameraData.cameraTargetDescriptor.msaaSamples > 1;
		ImportResourceParams importParams = new ImportResourceParams
		{
			clearOnFirstUse = flag3,
			clearColor = color,
			discardOnLastUse = discardOnLastUse
		};
		ImportResourceParams importParams2 = new ImportResourceParams
		{
			clearOnFirstUse = flag3,
			clearColor = color,
			discardOnLastUse = !isCameraTargetOffscreenDepth
		};
		if (universalCameraData.xr.enabled && universalCameraData.xr.copyDepth)
		{
			importParams2.discardOnLastUse = false;
		}
		RenderTargetInfo renderTargetInfo = default;
		RenderTargetInfo renderTargetInfo2 = default;
		if (flag)
		{
			int msaaSamples = AdjustAndGetScreenMSAASamples(renderGraph, m_RequiresIntermediateAttachments);
			renderTargetInfo.width = Screen.width;
			renderTargetInfo.height = Screen.height;
			renderTargetInfo.volumeDepth = 1;
			renderTargetInfo.msaaSamples = msaaSamples;
			renderTargetInfo.format = universalCameraData.cameraTargetDescriptor.graphicsFormat;
			renderTargetInfo2 = renderTargetInfo;
			renderTargetInfo2.format = universalCameraData.cameraTargetDescriptor.depthStencilFormat;
		}
		else
		{
			if (universalCameraData.xr.enabled)
			{
				renderTargetInfo.width = universalCameraData.xr.renderTargetDesc.width;
				renderTargetInfo.height = universalCameraData.xr.renderTargetDesc.height;
				renderTargetInfo.volumeDepth = universalCameraData.xr.renderTargetDesc.volumeDepth;
				renderTargetInfo.msaaSamples = universalCameraData.xr.renderTargetDesc.msaaSamples;
				renderTargetInfo.format = universalCameraData.xr.renderTargetDesc.graphicsFormat;
				if (!PlatformRequiresExplicitMsaaResolve())
				{
					renderTargetInfo.bindMS = renderTargetInfo.msaaSamples > 1;
				}
				renderTargetInfo2 = renderTargetInfo;
				renderTargetInfo2.format = universalCameraData.xr.renderTargetDesc.depthStencilFormat;
			}
			else
			{
				renderTargetInfo.width = universalCameraData.targetTexture.width;
				renderTargetInfo.height = universalCameraData.targetTexture.height;
				renderTargetInfo.volumeDepth = universalCameraData.targetTexture.volumeDepth;
				renderTargetInfo.msaaSamples = universalCameraData.targetTexture.antiAliasing;
				renderTargetInfo.format = universalCameraData.targetTexture.graphicsFormat;
				renderTargetInfo2 = renderTargetInfo;
				renderTargetInfo2.format = universalCameraData.targetTexture.depthStencilFormat;
			}
			if (renderTargetInfo2.format == GraphicsFormat.None)
			{
				renderTargetInfo2.format = SystemInfo.GetGraphicsFormat(DefaultFormat.DepthStencil);
				Debug.LogWarning("In the render graph API, the output Render Texture must have a depth buffer. When you select a Render Texture in any camera's Output Texture property, the Depth Stencil Format property of the texture must be set to a value other than None.");
			}
		}
		if (!isCameraTargetOffscreenDepth)
		{
			universalResourceData.backBufferColor = renderGraph.ImportTexture(m_TargetColorHandle, renderTargetInfo, importParams);
		}
		universalResourceData.backBufferDepth = renderGraph.ImportTexture(m_TargetDepthHandle, renderTargetInfo2, importParams2);
		if (m_RequiresIntermediateAttachments && !isCameraTargetOffscreenDepth)
		{
			RenderTextureDescriptor descriptor = universalCameraData.cameraTargetDescriptor;
			descriptor.useMipMap = false;
			descriptor.autoGenerateMips = false;
			descriptor.depthStencilFormat = GraphicsFormat.None;
			if (universalCameraData.resolveFinalTarget && universalCameraData.renderType == CameraRenderType.Base)
			{
				universalResourceData.cameraColor = CreateRenderGraphTexture(renderGraph, descriptor, "_CameraTargetAttachment", flag2, color, FilterMode.Bilinear, TextureWrapMode.Clamp, universalCameraData.resolveFinalTarget);
				m_CurrentColorHandle = -1;
			}
			else
			{
				RenderingUtils.ReAllocateHandleIfNeeded(ref m_RenderGraphCameraColorHandles[0], in descriptor, FilterMode.Bilinear, TextureWrapMode.Clamp, 1, 0f, "_CameraTargetAttachmentA");
				RenderingUtils.ReAllocateHandleIfNeeded(ref m_RenderGraphCameraColorHandles[1], in descriptor, FilterMode.Bilinear, TextureWrapMode.Clamp, 1, 0f, "_CameraTargetAttachmentB");
				if (universalCameraData.renderType == CameraRenderType.Base)
				{
					m_CurrentColorHandle = 0;
				}
				universalResourceData.cameraColor = renderGraph.ImportTexture(importParams: new ImportResourceParams
				{
					clearOnFirstUse = flag2,
					clearColor = color,
					discardOnLastUse = universalCameraData.resolveFinalTarget
				}, rt: currentRenderGraphCameraColorHandle);
			}
			universalResourceData.activeColorID = UniversalResourceDataBase.ActiveID.Camera;
		}
		else
		{
			universalResourceData.activeColorID = UniversalResourceDataBase.ActiveID.BackBuffer;
		}
		bool flag6 = RequireDepthPrepass(universalCameraData, ref renderPassInputs) && renderingModeActual != RenderingMode.Deferred;
		if (m_RequiresIntermediateAttachments)
		{
			RenderTextureDescriptor descriptor2 = universalCameraData.cameraTargetDescriptor;
			descriptor2.useMipMap = false;
			descriptor2.autoGenerateMips = false;
			bool flag7 = descriptor2.msaaSamples > 1;
			bool flag8 = RenderingUtils.MultisampleDepthResolveSupported() && renderGraph.nativeRenderPassesEnabled;
			descriptor2.bindMS = !flag8 & flag7;
			if (IsGLESDevice())
			{
				descriptor2.bindMS = false;
			}
			descriptor2.graphicsFormat = GraphicsFormat.None;
			descriptor2.depthStencilFormat = cameraDepthAttachmentFormat;
			RenderingUtils.ReAllocateHandleIfNeeded(ref m_RenderGraphCameraDepthHandle, in descriptor2, FilterMode.Point, TextureWrapMode.Clamp, 1, 0f, "_CameraDepthAttachment");
			universalResourceData.cameraDepth = renderGraph.ImportTexture(importParams: new ImportResourceParams
			{
				clearOnFirstUse = clearOnFirstUse,
				clearColor = color,
				discardOnLastUse = resolveFinalTarget
			}, rt: m_RenderGraphCameraDepthHandle);
			universalResourceData.activeDepthID = UniversalResourceDataBase.ActiveID.Camera;
			m_CopyDepthPass.MssaSamples = descriptor2.msaaSamples;
			m_CopyDepthPass.CopyToDepth = flag6;
			bool copyResolvedDepth = !descriptor2.bindMS;
			m_CopyDepthPass.m_CopyResolvedDepth = copyResolvedDepth;
			m_XRCopyDepthPass.m_CopyResolvedDepth = copyResolvedDepth;
		}
		else
		{
			universalResourceData.activeDepthID = UniversalResourceDataBase.ActiveID.BackBuffer;
		}
		CreateCameraDepthCopyTexture(renderGraph, universalCameraData.cameraTargetDescriptor, flag6);
		CreateCameraNormalsTexture(renderGraph, universalCameraData.cameraTargetDescriptor);
		CreateMotionVectorTextures(renderGraph, universalCameraData.cameraTargetDescriptor);
		CreateRenderingLayersTexture(renderGraph, universalCameraData.cameraTargetDescriptor);
		if (!isCameraTargetOffscreenDepth)
		{
			CreateAfterPostProcessTexture(renderGraph, universalCameraData.cameraTargetDescriptor);
		}
	}

	private void SetupRenderingLayers(int msaaSamples)
	{
		m_RequiresRenderingLayer = RenderingLayerUtils.RequireRenderingLayers(this, base.rendererFeatures, msaaSamples, out m_RenderingLayersEvent, out m_RenderingLayersMaskSize);
		m_RenderingLayerProvidesRenderObjectPass = m_RequiresRenderingLayer && m_RenderingLayersEvent == RenderingLayerUtils.Event.Opaque;
		m_RenderingLayerProvidesByDepthNormalPass = m_RequiresRenderingLayer && m_RenderingLayersEvent == RenderingLayerUtils.Event.DepthNormalPrePass;
		if (m_DeferredLights != null)
		{
			m_DeferredLights.RenderingLayerMaskSize = m_RenderingLayersMaskSize;
			m_DeferredLights.UseDecalLayers = m_RequiresRenderingLayer;
		}
	}

	internal void SetupRenderGraphLights(RenderGraph renderGraph, UniversalRenderingData renderingData, UniversalCameraData cameraData, UniversalLightData lightData)
	{
		m_ForwardLights.SetupRenderGraphLights(renderGraph, renderingData, cameraData, lightData);
		if (renderingModeActual == RenderingMode.Deferred)
		{
			m_DeferredLights.UseFramebufferFetch = renderGraph.nativeRenderPassesEnabled;
			m_DeferredLights.SetupRenderGraphLights(renderGraph, cameraData, lightData);
		}
	}

	private void RenderRawColorDepthHistory(RenderGraph renderGraph, UniversalCameraData cameraData, UniversalResourceData resourceData)
	{
		if (cameraData == null || cameraData.historyManager == null || resourceData == null)
		{
			return;
		}
		UniversalCameraHistory historyManager = cameraData.historyManager;
		bool flag = false;
		int num = 0;
		flag = cameraData.xr.enabled && !cameraData.xr.singlePassEnabled;
		num = cameraData.xr.multipassId;
		if (historyManager.IsAccessRequested<RawColorHistory>() && resourceData.cameraColor.IsValid())
		{
			RawColorHistory historyForWrite = historyManager.GetHistoryForWrite<RawColorHistory>();
			if (historyForWrite != null)
			{
				historyForWrite.Update(ref cameraData.cameraTargetDescriptor, flag);
				if (historyForWrite.GetCurrentTexture(num) != null)
				{
					TextureHandle destination = renderGraph.ImportTexture(historyForWrite.GetCurrentTexture(num));
					m_HistoryRawColorCopyPass.RenderToExistingTexture(renderGraph, base.frameData, in destination, resourceData.cameraColor);
				}
			}
		}
		if (!historyManager.IsAccessRequested<RawDepthHistory>() || !resourceData.cameraDepth.IsValid())
		{
			return;
		}
		RawDepthHistory historyForWrite2 = historyManager.GetHistoryForWrite<RawDepthHistory>();
		if (historyForWrite2 != null)
		{
			if (!m_HistoryRawDepthCopyPass.CopyToDepth)
			{
				RenderTextureDescriptor cameraDesc = cameraData.cameraTargetDescriptor;
				cameraDesc.graphicsFormat = GraphicsFormat.R32_SFloat;
				cameraDesc.depthStencilFormat = GraphicsFormat.None;
				historyForWrite2.Update(ref cameraDesc, flag);
			}
			else
			{
				RenderTextureDescriptor cameraDesc2 = cameraData.cameraTargetDescriptor;
				cameraDesc2.graphicsFormat = GraphicsFormat.None;
				historyForWrite2.Update(ref cameraDesc2, flag);
			}
			if (historyForWrite2.GetCurrentTexture(num) != null)
			{
				TextureHandle destination2 = renderGraph.ImportTexture(historyForWrite2.GetCurrentTexture(num));
				m_HistoryRawDepthCopyPass.Render(renderGraph, base.frameData, destination2, resourceData.cameraDepth);
			}
		}
	}

	public override void OnBeginRenderGraphFrame()
	{
		base.frameData.Get<UniversalResourceData>().InitFrame();
	}

	internal override void OnRecordRenderGraph(RenderGraph renderGraph, ScriptableRenderContext context)
	{
		UniversalResourceData universalResourceData = base.frameData.Get<UniversalResourceData>();
		UniversalRenderingData renderingData = base.frameData.Get<UniversalRenderingData>();
		UniversalCameraData universalCameraData = base.frameData.Get<UniversalCameraData>();
		UniversalLightData lightData = base.frameData.Get<UniversalLightData>();
		useRenderPassEnabled = renderGraph.nativeRenderPassesEnabled;
		MotionVectorRenderPass.SetRenderGraphMotionVectorGlobalMatrices(renderGraph, universalCameraData);
		SetupRenderGraphLights(renderGraph, renderingData, universalCameraData, lightData);
		SetupRenderingLayers(universalCameraData.cameraTargetDescriptor.msaaSamples);
		bool flag = universalCameraData.camera.targetTexture != null && universalCameraData.camera.targetTexture.format == RenderTextureFormat.Depth;
		CreateRenderGraphCameraRenderTargets(renderGraph, flag);
		_ = base.DebugHandler;
		RecordCustomRenderGraphPasses(renderGraph, RenderPassEvent.BeforeRendering);
		SetupRenderGraphCameraProperties(renderGraph, universalResourceData.isActiveTargetBackBuffer);
		ProcessVFXCameraCommand(renderGraph);
		universalCameraData.renderer.useDepthPriming = base.useDepthPriming;
		if (flag)
		{
			OnOffscreenDepthTextureRendering(renderGraph, context, universalResourceData, universalCameraData);
			return;
		}
		OnBeforeRendering(renderGraph);
		BeginRenderGraphXRRendering(renderGraph);
		OnMainRendering(renderGraph, context);
		OnAfterRendering(renderGraph);
		EndRenderGraphXRRendering(renderGraph);
	}

	public override void OnEndRenderGraphFrame()
	{
		base.frameData.Get<UniversalResourceData>().EndFrame();
	}

	internal override void OnFinishRenderGraphRendering(CommandBuffer cmd)
	{
		if (renderingModeActual == RenderingMode.Deferred)
		{
			m_DeferredPass.OnCameraCleanup(cmd);
		}
		m_CopyDepthPass.OnCameraCleanup(cmd);
		m_DepthNormalPrepass.OnCameraCleanup(cmd);
	}

	private void OnOffscreenDepthTextureRendering(RenderGraph renderGraph, ScriptableRenderContext context, UniversalResourceData resourceData, UniversalCameraData cameraData)
	{
		if (!renderGraph.nativeRenderPassesEnabled)
		{
			ClearTargetsPass.Render(renderGraph, resourceData.activeColorTexture, resourceData.backBufferDepth, RTClearFlags.Depth, cameraData.backgroundColor);
		}
		RecordCustomRenderGraphPasses(renderGraph, RenderPassEvent.BeforeRenderingShadows, RenderPassEvent.BeforeRenderingOpaques);
		m_RenderOpaqueForwardPass.Render(renderGraph, base.frameData, TextureHandle.nullHandle, resourceData.backBufferDepth, TextureHandle.nullHandle, TextureHandle.nullHandle);
		RecordCustomRenderGraphPasses(renderGraph, RenderPassEvent.AfterRenderingOpaques, RenderPassEvent.BeforeRenderingTransparents);
		m_RenderTransparentForwardPass.Render(renderGraph, base.frameData, TextureHandle.nullHandle, resourceData.backBufferDepth, TextureHandle.nullHandle, TextureHandle.nullHandle);
		RecordCustomRenderGraphPasses(renderGraph, RenderPassEvent.AfterRenderingTransparents, RenderPassEvent.AfterRendering);
	}

	private void OnBeforeRendering(RenderGraph renderGraph)
	{
		UniversalResourceData universalResourceData = base.frameData.Get<UniversalResourceData>();
		UniversalRenderingData renderingData = base.frameData.Get<UniversalRenderingData>();
		UniversalCameraData universalCameraData = base.frameData.Get<UniversalCameraData>();
		UniversalLightData lightData = base.frameData.Get<UniversalLightData>();
		UniversalShadowData shadowData = base.frameData.Get<UniversalShadowData>();
		m_ForwardLights.PreSetup(renderingData, universalCameraData, lightData);
		RecordCustomRenderGraphPasses(renderGraph, RenderPassEvent.BeforeRenderingShadows);
		bool flag = false;
		if (m_MainLightShadowCasterPass.Setup(renderingData, universalCameraData, lightData, shadowData))
		{
			flag = true;
			universalResourceData.mainShadowsTexture = m_MainLightShadowCasterPass.Render(renderGraph, base.frameData);
		}
		if (m_AdditionalLightsShadowCasterPass.Setup(renderingData, universalCameraData, lightData, shadowData))
		{
			flag = true;
			universalResourceData.additionalShadowsTexture = m_AdditionalLightsShadowCasterPass.Render(renderGraph, base.frameData);
		}
		if (flag)
		{
			SetupRenderGraphCameraProperties(renderGraph, universalResourceData.isActiveTargetBackBuffer);
		}
		RecordCustomRenderGraphPasses(renderGraph, RenderPassEvent.AfterRenderingShadows);
		if (universalCameraData.postProcessEnabled && m_PostProcessPasses.isCreated)
		{
			m_PostProcessPasses.colorGradingLutPass.Render(renderGraph, base.frameData, out var internalColorLut);
			universalResourceData.internalColorLut = internalColorLut;
		}
	}

	private void UpdateInstanceOccluders(RenderGraph renderGraph, UniversalCameraData cameraData, TextureHandle depthTexture)
	{
		int x = (int)((float)cameraData.pixelWidth * cameraData.renderScale);
		int y = (int)((float)cameraData.pixelHeight * cameraData.renderScale);
		bool flag = cameraData.xr.enabled && cameraData.xr.singlePassEnabled;
		OccluderParameters occluderParameters = new OccluderParameters(cameraData.camera.GetInstanceID());
		occluderParameters.subviewCount = ((!flag) ? 1 : 2);
		occluderParameters.depthTexture = depthTexture;
		occluderParameters.depthSize = new Vector2Int(x, y);
		occluderParameters.depthIsArray = flag;
		OccluderParameters occluderParameters2 = occluderParameters;
		Span<OccluderSubviewUpdate> span = stackalloc OccluderSubviewUpdate[occluderParameters2.subviewCount];
		for (int i = 0; i < occluderParameters2.subviewCount; i++)
		{
			Matrix4x4 viewMatrix = cameraData.GetViewMatrix(i);
			Matrix4x4 projectionMatrix = cameraData.GetProjectionMatrix(i);
			span[i] = new OccluderSubviewUpdate(i)
			{
				depthSliceIndex = i,
				viewMatrix = viewMatrix,
				invViewMatrix = viewMatrix.inverse,
				gpuProjMatrix = GL.GetGPUProjectionMatrix(projectionMatrix, renderIntoTexture: true),
				viewOffsetWorldSpace = Vector3.zero
			};
		}
		GPUResidentDrawer.UpdateInstanceOccluders(renderGraph, in occluderParameters2, span);
	}

	private void InstanceOcclusionTest(RenderGraph renderGraph, UniversalCameraData cameraData, OcclusionTest occlusionTest)
	{
		bool flag = cameraData.xr.enabled && cameraData.xr.singlePassEnabled;
		int num = ((!flag) ? 1 : 2);
		OcclusionCullingSettings occlusionCullingSettings = new OcclusionCullingSettings(cameraData.camera.GetInstanceID(), occlusionTest);
		occlusionCullingSettings.instanceMultiplier = ((!flag || SystemInfo.supportsMultiview) ? 1 : 2);
		OcclusionCullingSettings settings = occlusionCullingSettings;
		Span<SubviewOcclusionTest> span = stackalloc SubviewOcclusionTest[num];
		for (int i = 0; i < num; i++)
		{
			span[i] = new SubviewOcclusionTest
			{
				cullingSplitIndex = 0,
				occluderSubviewIndex = i
			};
		}
		GPUResidentDrawer.InstanceOcclusionTest(renderGraph, in settings, span);
	}

	private void RecordCustomPassesWithDepthCopyAndMotion(RenderGraph renderGraph, UniversalResourceData resourceData, RenderPassEvent earliestDepthReadEvent, RenderPassEvent currentEvent, bool renderMotionVectors)
	{
		CalculateSplitEventRange(currentEvent, earliestDepthReadEvent, out var startEvent, out var splitEvent, out var endEvent);
		RecordCustomRenderGraphPassesInEventRange(renderGraph, startEvent, splitEvent);
		ExecuteScheduledDepthCopyWithMotion(renderGraph, resourceData, renderMotionVectors);
		RecordCustomRenderGraphPassesInEventRange(renderGraph, splitEvent, endEvent);
	}

	private bool AllowPartialDepthNormalsPrepass(bool isDeferred, RenderPassEvent requiresDepthNormalEvent)
	{
		if (isDeferred)
		{
			if (RenderPassEvent.AfterRenderingGbuffer <= requiresDepthNormalEvent)
			{
				return requiresDepthNormalEvent <= RenderPassEvent.BeforeRenderingOpaques;
			}
			return false;
		}
		return false;
	}

	private DepthCopySchedule CalculateDepthCopySchedule(RenderPassEvent earliestDepthReadEvent, bool hasFullPrepass)
	{
		if (earliestDepthReadEvent < RenderPassEvent.AfterRenderingOpaques || m_CopyDepthMode == CopyDepthMode.ForcePrepass)
		{
			if (hasFullPrepass)
			{
				return DepthCopySchedule.AfterPrepass;
			}
			return DepthCopySchedule.AfterGBuffer;
		}
		if (earliestDepthReadEvent < RenderPassEvent.AfterRenderingTransparents || m_CopyDepthMode == CopyDepthMode.AfterOpaques)
		{
			if (earliestDepthReadEvent < RenderPassEvent.AfterRenderingSkybox)
			{
				return DepthCopySchedule.AfterOpaques;
			}
			return DepthCopySchedule.AfterSkybox;
		}
		if (earliestDepthReadEvent < RenderPassEvent.BeforeRenderingPostProcessing || m_CopyDepthMode == CopyDepthMode.AfterTransparents)
		{
			return DepthCopySchedule.AfterTransparents;
		}
		return DepthCopySchedule.None;
	}

	private TextureCopySchedules CalculateTextureCopySchedules(UniversalCameraData cameraData, RenderPassInputSummary renderPassInputs, bool isDeferred, bool requiresDepthPrepass, bool hasFullPrepass)
	{
		bool flag = CameraHasPostProcessingWithDepth(cameraData);
		bool num = (cameraData.requiresDepthTexture | flag) || renderPassInputs.requiresDepthTexture || DebugHandlerRequireDepthPass(base.frameData.Get<UniversalCameraData>());
		DepthCopySchedule depth = DepthCopySchedule.None;
		if (num)
		{
			depth = ((isDeferred || !requiresDepthPrepass || base.useDepthPriming) ? CalculateDepthCopySchedule(renderPassInputs.requiresDepthTextureEarliestEvent, hasFullPrepass) : DepthCopySchedule.DuringPrepass);
		}
		ColorCopySchedule color = ((!cameraData.requiresOpaqueTexture && !renderPassInputs.requiresColorTexture) ? ColorCopySchedule.None : ColorCopySchedule.AfterSkybox);
		TextureCopySchedules result = default;
		result.depth = depth;
		result.color = color;
		return result;
	}

	private void CopyDepthToDepthTexture(RenderGraph renderGraph, UniversalResourceData resourceData)
	{
		m_CopyDepthPass.Render(renderGraph, base.frameData, resourceData.cameraDepthTexture, resourceData.activeDepthTexture, bindAsCameraDepth: true);
	}

	private void RenderMotionVectors(RenderGraph renderGraph, UniversalResourceData resourceData)
	{
		m_MotionVectorPass.Render(renderGraph, base.frameData, resourceData.cameraDepthTexture, resourceData.motionVectorColor, resourceData.motionVectorDepth);
	}

	private void ExecuteScheduledDepthCopyWithMotion(RenderGraph renderGraph, UniversalResourceData resourceData, bool renderMotionVectors)
	{
		CopyDepthToDepthTexture(renderGraph, resourceData);
		if (renderMotionVectors)
		{
			RenderMotionVectors(renderGraph, resourceData);
		}
	}

	private void OnMainRendering(RenderGraph renderGraph, ScriptableRenderContext context)
	{
		UniversalResourceData universalResourceData = base.frameData.Get<UniversalResourceData>();
		UniversalCameraData cameraData = base.frameData.Get<UniversalCameraData>();
		UniversalLightData lightData = base.frameData.Get<UniversalLightData>();
		UniversalPostProcessingData universalPostProcessingData = base.frameData.Get<UniversalPostProcessingData>();
		if (!renderGraph.nativeRenderPassesEnabled)
		{
			RTClearFlags cameraClearFlag = (RTClearFlags)ScriptableRenderer.GetCameraClearFlag(cameraData);
			if (cameraClearFlag != RTClearFlags.None)
			{
				ClearTargetsPass.Render(renderGraph, universalResourceData.activeColorTexture, universalResourceData.activeDepthTexture, cameraClearFlag, cameraData.backgroundColor);
			}
		}
		RecordCustomRenderGraphPasses(renderGraph, RenderPassEvent.BeforeRenderingPrePasses);
		RenderPassInputSummary renderPassInputs = GetRenderPassInputs(cameraData.IsTemporalAAEnabled(), universalPostProcessingData.isEnabled, cameraData.isSceneViewCamera);
		if (m_RenderingLayerProvidesByDepthNormalPass)
		{
			renderPassInputs.requiresNormalsTexture = true;
		}
		bool flag = renderingModeActual == RenderingMode.Deferred;
		bool flag2 = RequireDepthPrepass(cameraData, ref renderPassInputs);
		bool num = flag2 && !renderPassInputs.requiresNormalsTexture;
		bool flag3 = flag2 && renderPassInputs.requiresNormalsTexture;
		bool flag4 = num || (flag3 && !AllowPartialDepthNormalsPrepass(flag, renderPassInputs.requiresDepthNormalAtEvent));
		TextureCopySchedules textureCopySchedules = CalculateTextureCopySchedules(cameraData, renderPassInputs, flag, flag2, flag4);
		bool flag5 = cameraData.useGPUOcclusionCulling;
		if (cameraData.xr.enabled && cameraData.xr.hasMotionVectorPass)
		{
			m_XRDepthMotionPass?.Update(ref cameraData);
			m_XRDepthMotionPass?.Render(renderGraph, base.frameData);
		}
		if (flag2)
		{
			bool flag6 = base.useDepthPriming && (cameraData.renderType == CameraRenderType.Base || cameraData.clearDepth);
			bool flag7 = flag | flag6;
			TextureHandle cameraDepthTexture = (flag7 ? universalResourceData.activeDepthTexture : universalResourceData.cameraDepthTexture);
			int num2 = ((!flag5) ? 1 : 2);
			for (int i = 0; i < num2; i++)
			{
				uint batchLayerMask = uint.MaxValue;
				if (flag5)
				{
					OcclusionTest occlusionTest = ((i == 0) ? OcclusionTest.TestAll : OcclusionTest.TestCulled);
					InstanceOcclusionTest(renderGraph, cameraData, occlusionTest);
					batchLayerMask = occlusionTest.GetBatchLayerMask();
				}
				bool num3 = i == num2 - 1;
				bool setGlobalDepth = num3 && !flag7;
				bool setGlobalTextures = num3 && (!flag | flag4);
				if (flag3)
				{
					DepthNormalPrepassRender(renderGraph, renderPassInputs, cameraDepthTexture, batchLayerMask, setGlobalDepth, setGlobalTextures);
				}
				else
				{
					m_DepthPrepass.Render(renderGraph, base.frameData, ref cameraDepthTexture, batchLayerMask, setGlobalDepth);
				}
				if (flag5)
				{
					UpdateInstanceOccluders(renderGraph, cameraData, cameraDepthTexture);
					if (i != 0)
					{
						InstanceOcclusionTest(renderGraph, cameraData, OcclusionTest.TestAll);
					}
				}
			}
			flag5 = false;
		}
		if (textureCopySchedules.depth == DepthCopySchedule.AfterPrepass)
		{
			ExecuteScheduledDepthCopyWithMotion(renderGraph, universalResourceData, renderPassInputs.requiresMotionVectors);
		}
		else if (textureCopySchedules.depth == DepthCopySchedule.DuringPrepass && renderPassInputs.requiresMotionVectors)
		{
			RenderMotionVectors(renderGraph, universalResourceData);
		}
		RecordCustomRenderGraphPasses(renderGraph, RenderPassEvent.AfterRenderingPrePasses);
		if (cameraData.xr.hasValidOcclusionMesh)
		{
			m_XROcclusionMeshPass.Render(renderGraph, base.frameData, universalResourceData.activeColorTexture, universalResourceData.activeDepthTexture);
		}
		if (flag)
		{
			m_DeferredLights.Setup(m_AdditionalLightsShadowCasterPass);
			m_DeferredLights.UseFramebufferFetch = renderGraph.nativeRenderPassesEnabled;
			m_DeferredLights.HasNormalPrepass = flag3;
			m_DeferredLights.HasDepthPrepass = flag2;
			m_DeferredLights.ResolveMixedLightingMode(lightData);
			m_DeferredLights.IsOverlay = cameraData.renderType == CameraRenderType.Overlay;
			RecordCustomRenderGraphPasses(renderGraph, RenderPassEvent.BeforeRenderingGbuffer);
			bool setGlobalTextures2 = flag3 && !flag4;
			m_GBufferPass.Render(renderGraph, base.frameData, universalResourceData.activeColorTexture, universalResourceData.activeDepthTexture, setGlobalTextures2);
			if (textureCopySchedules.depth == DepthCopySchedule.AfterGBuffer)
			{
				ExecuteScheduledDepthCopyWithMotion(renderGraph, universalResourceData, renderPassInputs.requiresMotionVectors);
			}
			else if (!renderGraph.nativeRenderPassesEnabled)
			{
				CopyDepthToDepthTexture(renderGraph, universalResourceData);
			}
			RecordCustomRenderGraphPasses(renderGraph, RenderPassEvent.AfterRenderingGbuffer, RenderPassEvent.BeforeRenderingDeferredLights);
			m_DeferredPass.Render(renderGraph, base.frameData, universalResourceData.activeColorTexture, universalResourceData.activeDepthTexture, universalResourceData.gBuffer);
			RecordCustomRenderGraphPasses(renderGraph, RenderPassEvent.AfterRenderingDeferredLights, RenderPassEvent.BeforeRenderingOpaques);
			TextureHandle mainShadowsTexture = universalResourceData.mainShadowsTexture;
			TextureHandle additionalShadowsTexture = universalResourceData.additionalShadowsTexture;
			m_RenderOpaqueForwardOnlyPass.Render(renderGraph, base.frameData, universalResourceData.activeColorTexture, universalResourceData.activeDepthTexture, mainShadowsTexture, additionalShadowsTexture);
		}
		else
		{
			RecordCustomRenderGraphPasses(renderGraph, RenderPassEvent.BeforeRenderingGbuffer, RenderPassEvent.BeforeRenderingOpaques);
			int num4 = ((!flag5) ? 1 : 2);
			for (int j = 0; j < num4; j++)
			{
				uint batchLayerMask2 = uint.MaxValue;
				if (flag5)
				{
					OcclusionTest occlusionTest2 = ((j == 0) ? OcclusionTest.TestAll : OcclusionTest.TestCulled);
					InstanceOcclusionTest(renderGraph, cameraData, occlusionTest2);
					batchLayerMask2 = occlusionTest2.GetBatchLayerMask();
				}
				if (m_RenderingLayerProvidesRenderObjectPass)
				{
					m_RenderOpaqueForwardWithRenderingLayersPass.Render(renderGraph, base.frameData, universalResourceData.activeColorTexture, universalResourceData.renderingLayersTexture, universalResourceData.activeDepthTexture, universalResourceData.mainShadowsTexture, universalResourceData.additionalShadowsTexture, m_RenderingLayersMaskSize, batchLayerMask2);
					SetRenderingLayersGlobalTextures(renderGraph);
				}
				else
				{
					m_RenderOpaqueForwardPass.Render(renderGraph, base.frameData, universalResourceData.activeColorTexture, universalResourceData.activeDepthTexture, universalResourceData.mainShadowsTexture, universalResourceData.additionalShadowsTexture, batchLayerMask2);
				}
				if (flag5)
				{
					UpdateInstanceOccluders(renderGraph, cameraData, universalResourceData.activeDepthTexture);
					if (j != 0)
					{
						InstanceOcclusionTest(renderGraph, cameraData, OcclusionTest.TestAll);
					}
				}
			}
			flag5 = false;
		}
		if (textureCopySchedules.depth == DepthCopySchedule.AfterOpaques)
		{
			RecordCustomPassesWithDepthCopyAndMotion(renderGraph, universalResourceData, renderPassInputs.requiresDepthTextureEarliestEvent, RenderPassEvent.AfterRenderingOpaques, renderPassInputs.requiresMotionVectors);
		}
		else
		{
			RecordCustomRenderGraphPasses(renderGraph, RenderPassEvent.AfterRenderingOpaques);
		}
		RecordCustomRenderGraphPasses(renderGraph, RenderPassEvent.BeforeRenderingSkybox);
		if (cameraData.camera.clearFlags == CameraClearFlags.Skybox && cameraData.renderType != CameraRenderType.Overlay)
		{
			cameraData.camera.TryGetComponent<Skybox>(out var component);
			Material material = ((component != null) ? component.material : RenderSettings.skybox);
			if (material != null)
			{
				m_DrawSkyboxPass.Render(renderGraph, base.frameData, context, universalResourceData.activeColorTexture, universalResourceData.activeDepthTexture, material);
			}
		}
		if (textureCopySchedules.depth == DepthCopySchedule.AfterSkybox)
		{
			ExecuteScheduledDepthCopyWithMotion(renderGraph, universalResourceData, renderPassInputs.requiresMotionVectors);
		}
		RecordCustomRenderGraphPasses(renderGraph, RenderPassEvent.AfterRenderingSkybox);
		if (textureCopySchedules.color == ColorCopySchedule.AfterSkybox)
		{
			TextureHandle source = universalResourceData.activeColorTexture;
			Downsampling opaqueDownsampling = UniversalRenderPipeline.asset.opaqueDownsampling;
			m_CopyColorPass.Render(renderGraph, base.frameData, out var destination, in source, opaqueDownsampling);
			universalResourceData.cameraOpaqueTexture = destination;
		}
		RecordCustomRenderGraphPasses(renderGraph, RenderPassEvent.BeforeRenderingTransparents);
		m_RenderTransparentForwardPass.m_ShouldTransparentsReceiveShadows = !m_TransparentSettingsPass.Setup();
		m_RenderTransparentForwardPass.Render(renderGraph, base.frameData, universalResourceData.activeColorTexture, universalResourceData.activeDepthTexture, universalResourceData.mainShadowsTexture, universalResourceData.additionalShadowsTexture);
		if (textureCopySchedules.depth == DepthCopySchedule.AfterTransparents)
		{
			RecordCustomPassesWithDepthCopyAndMotion(renderGraph, universalResourceData, renderPassInputs.requiresDepthTextureEarliestEvent, RenderPassEvent.AfterRenderingTransparents, renderPassInputs.requiresMotionVectors);
		}
		else
		{
			RecordCustomRenderGraphPasses(renderGraph, RenderPassEvent.AfterRenderingTransparents);
		}
		if (context.HasInvokeOnRenderObjectCallbacks())
		{
			m_OnRenderObjectCallbackPass.Render(renderGraph, universalResourceData.activeColorTexture, universalResourceData.activeDepthTexture);
		}
		if (universalResourceData != null)
		{
			SetupVFXCameraBuffer(cameraData);
		}
		RenderRawColorDepthHistory(renderGraph, cameraData, universalResourceData);
		bool rendersOverlayUI = cameraData.rendersOverlayUI;
		bool isHDROutputActive = cameraData.isHDROutputActive;
		if (rendersOverlayUI & isHDROutputActive)
		{
			m_DrawOffscreenUIPass.RenderOffscreen(renderGraph, base.frameData, cameraDepthAttachmentFormat, out var output);
			universalResourceData.overlayUITexture = output;
		}
	}

	private void OnAfterRendering(RenderGraph renderGraph)
	{
		UniversalResourceData universalResourceData = base.frameData.Get<UniversalResourceData>();
		base.frameData.Get<UniversalRenderingData>();
		UniversalCameraData universalCameraData = base.frameData.Get<UniversalCameraData>();
		UniversalPostProcessingData universalPostProcessingData = base.frameData.Get<UniversalPostProcessingData>();
		if (universalCameraData.resolveFinalTarget)
		{
			SetupRenderGraphFinalPassDebug(renderGraph, base.frameData);
		}
		bool flag = DebugDisplaySettings<UniversalRenderPipelineDebugDisplaySettings>.Instance.renderingSettings.sceneOverrideMode == DebugSceneOverrideMode.None;
		if (flag)
		{
			DrawRenderGraphGizmos(renderGraph, base.frameData, universalResourceData.activeColorTexture, universalResourceData.activeDepthTexture, GizmoSubset.PreImageEffects);
		}
		RecordCustomRenderGraphPasses(renderGraph, RenderPassEvent.BeforeRenderingPostProcessing);
		bool flag2 = ShouldApplyPostProcessing(universalCameraData.postProcessEnabled);
		bool flag3 = universalPostProcessingData.isEnabled && m_PostProcessPasses.isCreated && universalCameraData.resolveFinalTarget && (universalCameraData.antialiasing == AntialiasingMode.FastApproximateAntialiasing || (universalCameraData.imageScalingMode == ImageScalingMode.Upscaling && universalCameraData.upscalingFilter != ImageUpscalingFilter.Linear) || (universalCameraData.IsTemporalAAEnabled() && universalCameraData.taaSettings.contrastAdaptiveSharpening > 0f));
		bool flag4 = universalCameraData.captureActions != null && universalCameraData.resolveFinalTarget;
		bool flag5 = base.activeRenderPassQueue.Find((ScriptableRenderPass x) => x.renderPassEvent >= RenderPassEvent.AfterRenderingPostProcessing && x.renderPassEvent < RenderPassEvent.AfterRendering) != null;
		bool flag6 = !flag4 && !flag5 && !flag3;
		bool flag7 = base.DebugHandler == null || !base.DebugHandler.HDRDebugViewIsActive(universalCameraData.resolveFinalTarget);
		bool flag8 = universalResourceData.activeDepthID == UniversalResourceDataBase.ActiveID.BackBuffer;
		DebugHandler activeDebugHandler = ScriptableRenderPass.GetActiveDebugHandler(universalCameraData);
		bool flag9 = activeDebugHandler?.WriteToDebugScreenTexture(universalCameraData.resolveFinalTarget) ?? false;
		if (flag9)
		{
			RenderTextureDescriptor descriptor = universalCameraData.cameraTargetDescriptor;
			DebugHandler.ConfigureColorDescriptorForDebugScreen(ref descriptor, universalCameraData.pixelWidth, universalCameraData.pixelHeight);
			universalResourceData.debugScreenColor = CreateRenderGraphTexture(renderGraph, descriptor, "_DebugScreenColor", clear: false);
			RenderTextureDescriptor descriptor2 = universalCameraData.cameraTargetDescriptor;
			DebugHandler.ConfigureDepthDescriptorForDebugScreen(ref descriptor2, cameraDepthAttachmentFormat, universalCameraData.pixelWidth, universalCameraData.pixelHeight);
			universalResourceData.debugScreenDepth = CreateRenderGraphTexture(renderGraph, descriptor2, "_DebugScreenDepth", clear: false);
		}
		_ = universalResourceData.afterPostProcessColor;
		if (flag2)
		{
			TextureHandle activeCameraColorTexture = universalResourceData.activeColorTexture;
			TextureHandle backBufferColor = universalResourceData.backBufferColor;
			TextureHandle lutTexture = universalResourceData.internalColorLut;
			TextureHandle overlayUITexture = universalResourceData.overlayUITexture;
			bool flag10 = universalCameraData.resolveFinalTarget && !flag3 && !flag5;
			TextureHandle postProcessingTarget;
			if (flag10)
			{
				postProcessingTarget = backBufferColor;
			}
			else
			{
				ImportResourceParams importParams = new ImportResourceParams
				{
					clearOnFirstUse = true,
					clearColor = Color.black,
					discardOnLastUse = universalCameraData.resolveFinalTarget
				};
				if (universalCameraData.IsSTPEnabled())
				{
					TextureDesc desc = universalResourceData.cameraColor.GetDescriptor(renderGraph);
					MakeCompatible(ref desc);
					desc.width = universalCameraData.pixelWidth;
					desc.height = universalCameraData.pixelHeight;
					desc.name = "_CameraColorUpscaled";
					universalResourceData.cameraColor = renderGraph.CreateTexture(in desc);
				}
				else
				{
					bool flag11 = universalCameraData.resolveFinalTarget && universalCameraData.renderType == CameraRenderType.Base;
					universalResourceData.cameraColor = (flag11 ? renderGraph.CreateTexture(activeCameraColorTexture, "_CameraColorAfterPostProcessing") : renderGraph.ImportTexture(nextRenderGraphCameraColorHandle, importParams));
				}
				postProcessingTarget = universalResourceData.cameraColor;
			}
			if (flag9 & flag10)
			{
				postProcessingTarget = universalResourceData.debugScreenColor;
			}
			bool enableColorEndingIfNeeded = flag6 & flag7;
			m_PostProcessPasses.postProcessPass.RenderPostProcessingRenderGraph(renderGraph, base.frameData, in activeCameraColorTexture, in lutTexture, in overlayUITexture, in postProcessingTarget, flag3, flag9, enableColorEndingIfNeeded);
			if (universalCameraData.resolveFinalTarget)
			{
				SetupAfterPostRenderGraphFinalPassDebug(renderGraph, base.frameData);
			}
			if (flag10)
			{
				universalResourceData.activeColorID = UniversalResourceDataBase.ActiveID.BackBuffer;
				universalResourceData.activeDepthID = UniversalResourceDataBase.ActiveID.BackBuffer;
			}
		}
		RecordCustomRenderGraphPasses(renderGraph, RenderPassEvent.AfterRenderingPostProcessing);
		if (flag3)
		{
			TextureHandle backBufferColor2 = universalResourceData.backBufferColor;
			TextureHandle overlayUITexture2 = universalResourceData.overlayUITexture;
			TextureHandle postProcessingTarget2 = backBufferColor2;
			if (flag9)
			{
				postProcessingTarget2 = universalResourceData.debugScreenColor;
			}
			TextureHandle source = universalResourceData.cameraColor;
			m_PostProcessPasses.finalPostProcessPass.RenderFinalPassRenderGraph(renderGraph, base.frameData, in source, in overlayUITexture2, in postProcessingTarget2, flag7);
			universalResourceData.activeColorID = UniversalResourceDataBase.ActiveID.BackBuffer;
			universalResourceData.activeDepthID = UniversalResourceDataBase.ActiveID.BackBuffer;
		}
		if (universalCameraData.captureActions != null)
		{
			m_CapturePass.RecordRenderGraph(renderGraph, base.frameData);
		}
		bool flag12 = flag3 || (flag2 && !flag5 && !flag4);
		RecordCustomRenderGraphPasses(renderGraph, RenderPassEvent.AfterRendering);
		if (!universalResourceData.isActiveTargetBackBuffer && universalCameraData.resolveFinalTarget && !flag12)
		{
			TextureHandle backBufferColor3 = universalResourceData.backBufferColor;
			TextureHandle overlayUITexture3 = universalResourceData.overlayUITexture;
			TextureHandle dest = backBufferColor3;
			if (flag9)
			{
				dest = universalResourceData.debugScreenColor;
			}
			TextureHandle src = universalResourceData.cameraColor;
			m_FinalBlitPass.Render(renderGraph, base.frameData, universalCameraData, in src, in dest, overlayUITexture3);
			universalResourceData.activeColorID = UniversalResourceDataBase.ActiveID.BackBuffer;
			universalResourceData.activeDepthID = UniversalResourceDataBase.ActiveID.BackBuffer;
		}
		bool num = universalCameraData.rendersOverlayUI && universalCameraData.isLastBaseCamera;
		bool isHDROutputActive = universalCameraData.isHDROutputActive;
		if (num && !isHDROutputActive)
		{
			TextureHandle depthBuffer = universalResourceData.backBufferDepth;
			TextureHandle colorBuffer = universalResourceData.backBufferColor;
			if (flag9)
			{
				colorBuffer = universalResourceData.debugScreenColor;
				depthBuffer = universalResourceData.debugScreenDepth;
			}
			m_DrawOverlayUIPass.RenderOverlay(renderGraph, base.frameData, in colorBuffer, in depthBuffer);
		}
		if (universalCameraData.xr.enabled && !flag8 && universalCameraData.xr.copyDepth)
		{
			m_XRCopyDepthPass.CopyToDepthXR = true;
			m_XRCopyDepthPass.MssaSamples = 1;
			m_XRCopyDepthPass.Render(renderGraph, base.frameData, universalResourceData.backBufferDepth, universalResourceData.cameraDepth, bindAsCameraDepth: false, "XR Depth Copy");
		}
		if (activeDebugHandler != null)
		{
			_ = universalResourceData.overlayUITexture;
			_ = universalResourceData.debugScreenColor;
		}
		if (universalCameraData.resolveFinalTarget)
		{
			if (universalCameraData.isSceneViewCamera)
			{
				DrawRenderGraphWireOverlay(renderGraph, base.frameData, universalResourceData.backBufferColor);
			}
			if (flag)
			{
				DrawRenderGraphGizmos(renderGraph, base.frameData, universalResourceData.backBufferColor, universalResourceData.activeDepthTexture, GizmoSubset.PostImageEffects);
			}
		}
		static void MakeCompatible(ref TextureDesc reference)
		{
			reference.msaaSamples = MSAASamples.None;
			reference.useMipMap = false;
			reference.autoGenerateMips = false;
			reference.anisoLevel = 0;
			reference.discardBuffer = false;
		}
	}

	private bool RequireDepthPrepass(UniversalCameraData cameraData, ref RenderPassInputSummary renderPassInputs)
	{
		bool flag = CameraHasPostProcessingWithDepth(cameraData);
		bool flag2 = m_CopyDepthMode == CopyDepthMode.ForcePrepass;
		bool flag3 = IsDepthPrimingEnabled(cameraData);
		return (((cameraData.requiresDepthTexture || renderPassInputs.requiresDepthTexture) | flag3 | flag) && (!CanCopyDepth(cameraData) | flag2)) | renderPassInputs.requiresDepthPrepass | renderPassInputs.requiresNormalsTexture | flag3;
	}

	private bool RequireDepthTexture(UniversalCameraData cameraData, bool requiresDepthPrepass, ref RenderPassInputSummary renderPassInputs)
	{
		bool flag = IsDepthPrimingEnabled(cameraData);
		bool num = (cameraData.requiresDepthTexture || renderPassInputs.requiresDepthTexture) | flag;
		bool flag2 = CameraHasPostProcessingWithDepth(cameraData);
		return ((num | flag2) && !requiresDepthPrepass) | !cameraData.resolveFinalTarget | (renderingModeActual == RenderingMode.Deferred && !useRenderPassEnabled) | flag | m_RenderingLayerProvidesRenderObjectPass | DebugHandlerRequireDepthPass(cameraData);
	}

	internal void SetRenderingLayersGlobalTextures(RenderGraph renderGraph)
	{
		UniversalResourceData universalResourceData = base.frameData.Get<UniversalResourceData>();
		if (universalResourceData.renderingLayersTexture.IsValid() && renderingModeActual != RenderingMode.Deferred)
		{
			RenderGraphUtils.SetGlobalTexture(renderGraph, Shader.PropertyToID(m_RenderingLayersTextureName), universalResourceData.renderingLayersTexture, "Set Global Rendering Layers Texture", "C:\\Users\\steph\\GameDev\\GetToWork2\\GetToWork\\Library\\PackageCache\\com.unity.render-pipelines.universal@7652a5c7e246\\Runtime\\UniversalRendererRenderGraph.cs", 1718);
		}
	}

	private void CreateCameraDepthCopyTexture(RenderGraph renderGraph, RenderTextureDescriptor descriptor, bool isDepthTexture)
	{
		UniversalResourceData universalResourceData = base.frameData.Get<UniversalResourceData>();
		RenderTextureDescriptor desc = descriptor;
		desc.msaaSamples = 1;
		if (isDepthTexture)
		{
			desc.graphicsFormat = GraphicsFormat.None;
			desc.depthStencilFormat = cameraDepthTextureFormat;
		}
		else
		{
			desc.graphicsFormat = GraphicsFormat.R32_SFloat;
			desc.depthStencilFormat = GraphicsFormat.None;
		}
		universalResourceData.cameraDepthTexture = CreateRenderGraphTexture(renderGraph, desc, "_CameraDepthTexture", clear: true);
	}

	private void CreateMotionVectorTextures(RenderGraph renderGraph, RenderTextureDescriptor descriptor)
	{
		UniversalResourceData universalResourceData = base.frameData.Get<UniversalResourceData>();
		RenderTextureDescriptor desc = descriptor;
		desc.msaaSamples = 1;
		desc.graphicsFormat = GraphicsFormat.R16G16_SFloat;
		desc.depthStencilFormat = GraphicsFormat.None;
		universalResourceData.motionVectorColor = CreateRenderGraphTexture(renderGraph, desc, "_MotionVectorTexture", clear: true);
		RenderTextureDescriptor desc2 = descriptor;
		desc2.msaaSamples = 1;
		desc2.graphicsFormat = GraphicsFormat.None;
		desc2.depthStencilFormat = cameraDepthAttachmentFormat;
		universalResourceData.motionVectorDepth = CreateRenderGraphTexture(renderGraph, desc2, "_MotionVectorDepthTexture", clear: true);
	}

	private void CreateCameraNormalsTexture(RenderGraph renderGraph, RenderTextureDescriptor descriptor)
	{
		UniversalResourceData universalResourceData = base.frameData.Get<UniversalResourceData>();
		RenderTextureDescriptor desc = descriptor;
		desc.depthStencilFormat = GraphicsFormat.None;
		desc.msaaSamples = 1;
		string name = ((renderingModeActual != RenderingMode.Deferred) ? "_CameraNormalsTexture" : DeferredLights.k_GBufferNames[m_DeferredLights.GBufferNormalSmoothnessIndex]);
		desc.graphicsFormat = ((renderingModeActual != RenderingMode.Deferred) ? DepthNormalOnlyPass.GetGraphicsFormat() : m_DeferredLights.GetGBufferFormat(m_DeferredLights.GBufferNormalSmoothnessIndex));
		universalResourceData.cameraNormalsTexture = CreateRenderGraphTexture(renderGraph, desc, name, clear: true);
	}

	private void CreateRenderingLayersTexture(RenderGraph renderGraph, RenderTextureDescriptor descriptor)
	{
		if (m_RequiresRenderingLayer)
		{
			UniversalResourceData universalResourceData = base.frameData.Get<UniversalResourceData>();
			m_RenderingLayersTextureName = "_CameraRenderingLayersTexture";
			if (renderingModeActual == RenderingMode.Deferred && m_DeferredLights.UseRenderingLayers)
			{
				m_RenderingLayersTextureName = DeferredLights.k_GBufferNames[m_DeferredLights.GBufferRenderingLayers];
			}
			RenderTextureDescriptor desc = descriptor;
			desc.depthStencilFormat = GraphicsFormat.None;
			if (!m_RenderingLayerProvidesRenderObjectPass)
			{
				desc.msaaSamples = 1;
			}
			if (renderingModeActual == RenderingMode.Deferred && m_RequiresRenderingLayer)
			{
				desc.graphicsFormat = m_DeferredLights.GetGBufferFormat(m_DeferredLights.GBufferRenderingLayers);
			}
			else
			{
				desc.graphicsFormat = RenderingLayerUtils.GetFormat(m_RenderingLayersMaskSize);
			}
			universalResourceData.renderingLayersTexture = CreateRenderGraphTexture(renderGraph, desc, m_RenderingLayersTextureName, clear: true);
		}
	}

	private void CreateAfterPostProcessTexture(RenderGraph renderGraph, RenderTextureDescriptor descriptor)
	{
		UniversalResourceData universalResourceData = base.frameData.Get<UniversalResourceData>();
		RenderTextureDescriptor compatibleDescriptor = PostProcessPass.GetCompatibleDescriptor(descriptor, descriptor.width, descriptor.height, descriptor.graphicsFormat);
		universalResourceData.afterPostProcessColor = CreateRenderGraphTexture(renderGraph, compatibleDescriptor, "_AfterPostProcessTexture", clear: true);
	}

	private void DepthNormalPrepassRender(RenderGraph renderGraph, RenderPassInputSummary renderPassInputs, TextureHandle depthTarget, uint batchLayerMask, bool setGlobalDepth, bool setGlobalTextures)
	{
		UniversalResourceData universalResourceData = base.frameData.Get<UniversalResourceData>();
		if (m_RenderingLayerProvidesByDepthNormalPass)
		{
			m_DepthNormalPrepass.enableRenderingLayers = true;
			m_DepthNormalPrepass.renderingLayersMaskSize = m_RenderingLayersMaskSize;
		}
		else
		{
			m_DepthNormalPrepass.enableRenderingLayers = false;
		}
		if (renderingModeActual == RenderingMode.Deferred && AllowPartialDepthNormalsPrepass(isDeferred: true, renderPassInputs.requiresDepthNormalAtEvent))
		{
			m_DepthNormalPrepass.shaderTagIds = k_DepthNormalsOnly;
		}
		TextureHandle cameraNormalsTexture = universalResourceData.cameraNormalsTexture;
		TextureHandle renderingLayersTexture = universalResourceData.renderingLayersTexture;
		m_DepthNormalPrepass.Render(renderGraph, base.frameData, cameraNormalsTexture, depthTarget, renderingLayersTexture, batchLayerMask, setGlobalDepth, setGlobalTextures);
		if (m_RequiresRenderingLayer)
		{
			SetRenderingLayersGlobalTextures(renderGraph);
		}
	}
}
