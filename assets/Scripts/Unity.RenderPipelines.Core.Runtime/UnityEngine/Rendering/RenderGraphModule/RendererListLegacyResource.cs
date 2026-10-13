namespace UnityEngine.Rendering.RenderGraphModule;

internal struct RendererListLegacyResource
{
	public RendererList rendererList;

	public bool isActive;

	internal RendererListLegacyResource(in bool active = false)
	{
		rendererList = default;
		isActive = active;
	}
}
