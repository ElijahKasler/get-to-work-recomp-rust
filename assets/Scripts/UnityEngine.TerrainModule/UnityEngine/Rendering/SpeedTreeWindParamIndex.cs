using UnityEngine.Bindings;

namespace UnityEngine.Rendering;

[NativeHeader("Modules/Terrain/Public/SpeedTreeWindManager.h")]
internal enum SpeedTreeWindParamIndex
{
	WindVector = 0,
	WindGlobal = 1,
	TreeExtents_SharedHeightStart = WindGlobal,
	WindBranch = 2,
	BranchStretchLimits = WindBranch,
	WindBranchTwitch = 3,
	Shared_NoisePosTurbulence_Independence = WindBranchTwitch,
	WindBranchWhip = 4,
	Shared_Bend_Oscillation_Turbulence_Flexibility = WindBranchWhip,
	WindBranchAnchor = 5,
	Branch1_NoisePosTurbulence_Independence = WindBranchAnchor,
	WindBranchAdherences = 6,
	Branch1_Bend_Oscillation_Turbulence_Flexibility = WindBranchAdherences,
	WindTurbulences = 7,
	Branch2_NoisePosTurbulence_Independence = WindTurbulences,
	WindLeaf1Ripple = 8,
	Branch2_Bend_Oscillation_Turbulence_Flexibility = WindLeaf1Ripple,
	WindLeaf1Tumble = 9,
	Ripple_NoisePosTurbulence_Independence = WindLeaf1Tumble,
	WindLeaf1Twitch = 10,
	Ripple_Planar_Directional_Flexibility_Shimmer = WindLeaf1Twitch,
	WindLeaf2Ripple = 11,
	WindLeaf2Tumble = 12,
	WindLeaf2Twitch = 13,
	WindFrondRipple = 14,
	WindParamsCount_v8 = 15,
	WindParamsCount_v9 = WindLeaf2Ripple,
	MaxWindParamsCount = 16
}
