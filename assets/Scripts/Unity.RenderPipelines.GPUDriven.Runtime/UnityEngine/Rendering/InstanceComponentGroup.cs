using System;

namespace UnityEngine.Rendering;

[Flags]
internal enum InstanceComponentGroup : uint
{
	Default = 1u,
	Wind = 2u,
	LightProbe = 4u,
	Lightmap = 8u,
	DefaultWind = Default | Wind,
	DefaultLightProbe = Default | LightProbe,
	DefaultLightmap = Default | Lightmap,
	DefaultWindLightProbe = DefaultWind | LightProbe,
	DefaultWindLightmap = DefaultWind | Lightmap
}
