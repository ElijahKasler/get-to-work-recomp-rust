using System;
using System.Collections.Generic;
using UnityEngine.Pool;
using UnityEngine.Scripting;

namespace UnityEngine.Rendering;

public static class RenderPipelineManager
{
	private static bool s_CleanUpPipeline = false;

	private const string k_BuiltinPipelineName = "Built-in Pipeline";

	private static string s_CurrentPipelineType = "Built-in Pipeline";

	private static RenderPipelineAsset s_CurrentPipelineAsset;

	private static RenderPipeline s_CurrentPipeline = null;

	internal static RenderPipelineAsset currentPipelineAsset => s_CurrentPipelineAsset;

	public static RenderPipeline currentPipeline
	{
		get
		{
			return s_CurrentPipeline;
		}
		private set
		{
			s_CurrentPipelineType = ((value != null) ? value.GetType().ToString() : "Built-in Pipeline");
			s_CurrentPipeline = value;
		}
	}

	public static bool pipelineSwitchCompleted => (object)s_CurrentPipelineAsset == GraphicsSettings.currentRenderPipeline && !IsPipelineRequireCreation();

	private static bool isCurrentPipelineValid
	{
		get
		{
			RenderPipeline renderPipeline = currentPipeline;
			return renderPipeline != null && !renderPipeline.disposed;
		}
	}

	public static event Action<ScriptableRenderContext, List<Camera>> beginContextRendering;

	public static event Action<ScriptableRenderContext, List<Camera>> endContextRendering;

	public static event Action<ScriptableRenderContext, Camera> beginCameraRendering;

	public static event Action<ScriptableRenderContext, Camera> endCameraRendering;

	public static event Action activeRenderPipelineTypeChanged;

	public static event Action<RenderPipelineAsset, RenderPipelineAsset> activeRenderPipelineAssetChanged;

	public static event Action activeRenderPipelineCreated;

	public static event Action activeRenderPipelineDisposed;

	[Obsolete("beginFrameRendering is deprecated. Use beginContextRendering instead. #from 2023.3", false)]
	public static event Action<ScriptableRenderContext, Camera[]> beginFrameRendering;

	[Obsolete("endFrameRendering is deprecated. Use endContextRendering instead. #from 2023.3", false)]
	public static event Action<ScriptableRenderContext, Camera[]> endFrameRendering;

	internal static void BeginContextRendering(ScriptableRenderContext context, List<Camera> cameras)
	{
		beginContextRendering?.Invoke(context, cameras);
		beginFrameRendering?.Invoke(context, cameras.ToArray());
	}

	internal static void BeginCameraRendering(ScriptableRenderContext context, Camera camera)
	{
		beginCameraRendering?.Invoke(context, camera);
	}

	internal static void EndContextRendering(ScriptableRenderContext context, List<Camera> cameras)
	{
		endFrameRendering?.Invoke(context, cameras.ToArray());
		endContextRendering?.Invoke(context, cameras);
	}

	internal static void EndCameraRendering(ScriptableRenderContext context, Camera camera)
	{
		endCameraRendering?.Invoke(context, camera);
	}

	[RequiredByNativeCode]
	internal static void OnActiveRenderPipelineTypeChanged()
	{
		activeRenderPipelineTypeChanged?.Invoke();
	}

	[RequiredByNativeCode]
	internal static void OnActiveRenderPipelineAssetChanged(ScriptableObject from, ScriptableObject to)
	{
		activeRenderPipelineAssetChanged?.Invoke(from as RenderPipelineAsset, to as RenderPipelineAsset);
	}

	[RequiredByNativeCode]
	internal static void HandleRenderPipelineChange(RenderPipelineAsset pipelineAsset)
	{
		bool flag = (object)s_CurrentPipelineAsset != pipelineAsset;
		if (s_CleanUpPipeline | flag)
		{
			CleanupRenderPipeline();
			s_CurrentPipelineAsset = pipelineAsset;
		}
	}

	[RequiredByNativeCode]
	internal static void RecreateCurrentPipeline(RenderPipelineAsset pipelineAsset)
	{
		if (s_CurrentPipelineAsset == pipelineAsset)
		{
			s_CleanUpPipeline = true;
		}
	}

	[RequiredByNativeCode]
	internal static void CleanupRenderPipeline()
	{
		if (isCurrentPipelineValid)
		{
			if (GraphicsSettings.currentRenderPipeline == null)
			{
				Shader.globalRenderPipeline = string.Empty;
			}
			activeRenderPipelineDisposed?.Invoke();
			currentPipeline.Dispose();
			currentPipeline = null;
			s_CleanUpPipeline = false;
			s_CurrentPipelineAsset = null;
			SupportedRenderingFeatures.active = null;
		}
	}

	[RequiredByNativeCode]
	private static string GetCurrentPipelineAssetType()
	{
		return s_CurrentPipelineType;
	}

	[RequiredByNativeCode]
	private static void DoRenderLoop_Internal(RenderPipelineAsset pipelineAsset, IntPtr loopPtr, Object renderRequest)
	{
		if (!TryPrepareRenderPipeline(pipelineAsset))
		{
			return;
		}
		ScriptableRenderContext context = new ScriptableRenderContext(loopPtr);
		List<Camera> value;
		using (CollectionPool<List<Camera>, Camera>.Get(out value))
		{
			context.GetCameras(value);
			if (renderRequest == null)
			{
				currentPipeline.InternalRender(context, value);
			}
			else
			{
				currentPipeline.InternalProcessRenderRequests(context, value[0], renderRequest);
			}
		}
	}

	internal static bool TryPrepareRenderPipeline(RenderPipelineAsset pipelineAsset)
	{
		HandleRenderPipelineChange(pipelineAsset);
		if (!IsPipelineRequireCreation())
		{
			return currentPipeline != null;
		}
		currentPipeline = s_CurrentPipelineAsset.InternalCreatePipeline();
		Shader.globalRenderPipeline = s_CurrentPipelineAsset.renderPipelineShaderTag;
		activeRenderPipelineCreated?.Invoke();
		return currentPipeline != null;
	}

	private static bool IsPipelineRequireCreation()
	{
		return s_CurrentPipelineAsset != null && (currentPipeline == null || currentPipeline.disposed);
	}
}
