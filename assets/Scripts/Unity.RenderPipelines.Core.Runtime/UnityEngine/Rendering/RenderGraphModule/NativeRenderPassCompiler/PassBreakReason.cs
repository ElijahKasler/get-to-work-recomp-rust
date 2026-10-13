namespace UnityEngine.Rendering.RenderGraphModule.NativeRenderPassCompiler;

internal enum PassBreakReason
{
	NotOptimized = 0,
	TargetSizeMismatch = 1,
	NextPassReadsTexture = 2,
	NextPassTargetsTexture = 3,
	NonRasterPass = 4,
	DifferentDepthTextures = 5,
	AttachmentLimitReached = 6,
	SubPassLimitReached = 7,
	EndOfGraph = 8,
	FRStateMismatch = 9,
	Merged = 10,
	Count = 11
}
