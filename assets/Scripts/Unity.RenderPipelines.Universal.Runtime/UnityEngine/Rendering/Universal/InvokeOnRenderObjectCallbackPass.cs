using System;
using UnityEngine.Rendering.RenderGraphModule;

namespace UnityEngine.Rendering.Universal;

internal class InvokeOnRenderObjectCallbackPass : ScriptableRenderPass
{
	private class PassData
	{
		internal TextureHandle colorTarget;

		internal TextureHandle depthTarget;
	}

	public InvokeOnRenderObjectCallbackPass(RenderPassEvent evt)
	{
		base.profilingSampler = new ProfilingSampler("Invoke OnRenderObject Callback");
		base.renderPassEvent = evt;
		base.useNativeRenderPass = false;
	}

	[Obsolete("This rendering path is for compatibility mode only (when Render Graph is disabled). Use Render Graph API instead.", false)]
	public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
	{
		renderingData.commandBuffer.InvokeOnRenderObjectCallbacks();
	}

	internal void Render(RenderGraph renderGraph, TextureHandle colorTarget, TextureHandle depthTarget)
	{
		PassData passData;
		using IUnsafeRenderGraphBuilder unsafeRenderGraphBuilder = renderGraph.AddUnsafePass<PassData>(base.passName, out passData, base.profilingSampler, "C:\\Users\\steph\\GameDev\\GetToWork2\\GetToWork\\Library\\PackageCache\\com.unity.render-pipelines.universal@7652a5c7e246\\Runtime\\Passes\\InvokeOnRenderObjectCallbackPass.cs", 36);
		passData.colorTarget = colorTarget;
		unsafeRenderGraphBuilder.UseTexture(in colorTarget, AccessFlags.Write);
		passData.depthTarget = depthTarget;
		unsafeRenderGraphBuilder.UseTexture(in depthTarget, AccessFlags.Write);
		unsafeRenderGraphBuilder.AllowPassCulling(value: false);
		unsafeRenderGraphBuilder.SetRenderFunc((PassData data, UnsafeGraphContext context) =>
		{
			context.cmd.SetRenderTarget(data.colorTarget, data.depthTarget);
			context.cmd.InvokeOnRenderObjectCallbacks();
		});
	}
}
