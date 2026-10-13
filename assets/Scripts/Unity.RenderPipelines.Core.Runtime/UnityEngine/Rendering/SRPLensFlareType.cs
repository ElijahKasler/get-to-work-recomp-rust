using System;

namespace UnityEngine.Rendering;

[Serializable]
[GenerateHLSL(PackingRules.Exact, true, false, false, 1, false, false, false, -1, ".\\Library\\PackageCache\\com.unity.render-pipelines.core@3b8a69964696\\Runtime\\PostProcessing\\LensFlareDataSRP.cs")]
public enum SRPLensFlareType
{
	Image = 0,
	Circle = 1,
	Polygon = 2,
	Ring = 3,
	LensFlareDataSRP = 4
}
