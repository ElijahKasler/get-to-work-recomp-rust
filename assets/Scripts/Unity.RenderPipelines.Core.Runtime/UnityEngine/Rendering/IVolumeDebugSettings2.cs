using System;
using System.Collections.Generic;

namespace UnityEngine.Rendering;

[Obsolete("This variant is obsolete and kept only for not breaking user code. Use IVolumeDebugSettings instead. #from(23.2) (UnityUpgradable) -> IVolumeDebugSettings", false)]
public interface IVolumeDebugSettings2 : IVolumeDebugSettings
{
	[Obsolete("This property is obsolete and kept only for not breaking user code. VolumeDebugSettings will use current pipeline when it needs to gather volume component types and paths. #from(23.2)", false)]
	Type targetRenderPipeline { get; }

	[Obsolete("This property is obsolete and kept only for not breaking user code. VolumeDebugSettings will use current pipeline when it needs to gather volume component types and paths. #from(23.2)", false)]
	List<(string, Type)> volumeComponentsPathAndType { get; }
}
