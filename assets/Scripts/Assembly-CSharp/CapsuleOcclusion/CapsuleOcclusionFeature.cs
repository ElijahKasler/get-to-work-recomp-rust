using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace CapsuleOcclusion;

public class CapsuleOcclusionFeature : ScriptableRendererFeature
{
	private class CapsuleOcclusionPass : ScriptableRenderPass
	{
		private Material _drawMat;

		private RTHandle _temporaryColorTexture;

		public bool Initialize()
		{
			if (_drawMat != null)
			{
				Object.DestroyImmediate(_drawMat);
				_drawMat = null;
			}
			Shader obj = null;
			Utils.LazyLoadResource(ref obj, "Shaders/CapsuleOcclusionPass");
			if (obj == null)
			{
				return false;
			}
			_drawMat = new Material(obj);
			return true;
		}

		public override void OnCameraSetup(CommandBuffer cmd, ref RenderingData renderingData)
		{
			RenderTextureDescriptor descriptor = renderingData.cameraData.cameraTargetDescriptor;
			descriptor.depthBufferBits = 0;
			RenderingUtils.ReAllocateIfNeeded(ref _temporaryColorTexture, in descriptor, FilterMode.Bilinear, TextureWrapMode.Clamp, isShadowMap: false, 1, 0f, "_TemporaryColorTexture");
		}

		public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
		{
			if (!(_drawMat == null))
			{
				CommandBuffer commandBuffer = CommandBufferPool.Get("Capsule Occlusion Pass");
				using (new ProfilingScope(commandBuffer, new ProfilingSampler("Capsule Occlusion Pass")))
				{
					ScriptableRenderer renderer = renderingData.cameraData.renderer;
					RTHandle cameraColorTargetHandle = renderer.cameraColorTargetHandle;
					RTHandle cameraColorTargetHandle2 = renderer.cameraColorTargetHandle;
					Blitter.BlitCameraTexture(commandBuffer, cameraColorTargetHandle, _temporaryColorTexture, _drawMat, 0);
					Blitter.BlitCameraTexture(commandBuffer, _temporaryColorTexture, cameraColorTargetHandle2);
				}
				context.ExecuteCommandBuffer(commandBuffer);
				CommandBufferPool.Release(commandBuffer);
			}
		}

		public override void OnCameraCleanup(CommandBuffer cmd)
		{
			_temporaryColorTexture?.Release();
			_temporaryColorTexture = null;
		}
	}

	public RenderPassEvent injectEvent = RenderPassEvent.AfterRenderingShadows;

	private CapsuleOcclusionPass pass;

	public override void Create()
	{
		if (pass == null)
		{
			pass = new CapsuleOcclusionPass();
		}
	}

	public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
	{
		if (pass.Initialize())
		{
			pass.renderPassEvent = injectEvent;
			renderer.EnqueuePass(pass);
		}
	}
}
