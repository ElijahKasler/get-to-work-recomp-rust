namespace UnityEngine.UIElements.UIR;

internal enum EntryType : ushort
{
	DrawSolidMesh = 0,
	DrawTexturedMesh = 1,
	DrawTexturedMeshSkipAtlas = 2,
	DrawTextMesh = 3,
	DrawGradients = 4,
	DrawImmediate = 5,
	DrawImmediateCull = 6,
	DrawChildren = 7,
	BeginStencilMask = 8,
	EndStencilMask = 9,
	PopStencilMask = 10,
	PushClippingRect = 11,
	PopClippingRect = 12,
	PushScissors = 13,
	PopScissors = 14,
	PushGroupMatrix = 15,
	PopGroupMatrix = 16,
	PushRenderTexture = 17,
	BlitAndPopRenderTexture = 18,
	PushDefaultMaterial = 19,
	PopDefaultMaterial = 20,
	CutRenderChain = 21,
	DedicatedPlaceholder = 22
}
