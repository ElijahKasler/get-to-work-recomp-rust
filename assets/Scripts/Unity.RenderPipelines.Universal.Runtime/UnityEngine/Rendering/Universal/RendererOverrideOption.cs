using System;

namespace UnityEngine.Rendering.Universal;

[Obsolete("Renderer override is no longer used, renderers are referenced by index on the pipeline asset.")]
public enum RendererOverrideOption
{
	Custom = 0,
	UsePipelineSettings = 1
}
