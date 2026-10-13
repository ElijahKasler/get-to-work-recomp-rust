using System.Runtime.CompilerServices;

namespace UnityEngine.UIElements.UIR;

internal struct RenderChainVEData
{
	public VisualElement prev;

	public VisualElement next;

	public VisualElement groupTransformAncestor;

	public VisualElement boneTransformAncestor;

	public VisualElement prevDirty;

	public VisualElement nextDirty;

	public RenderDataFlags flags;

	public int hierarchyDepth;

	public RenderDataDirtyTypes dirtiedValues;

	public uint dirtyID;

	public RenderChainCommand firstHeadCommand;

	public RenderChainCommand lastHeadCommand;

	public RenderChainCommand firstTailCommand;

	public RenderChainCommand lastTailCommand;

	public bool localFlipsWinding;

	public bool localTransformScaleZero;

	public bool worldFlipsWinding;

	public bool worldTransformScaleZero;

	public ClipMethod clipMethod;

	public int childrenStencilRef;

	public int childrenMaskDepth;

	public MeshHandle headMesh;

	public MeshHandle tailMesh;

	public Matrix4x4 verticesSpace;

	public BMPAlloc transformID;

	public BMPAlloc clipRectID;

	public BMPAlloc opacityID;

	public BMPAlloc textCoreSettingsID;

	public BMPAlloc colorID;

	public BMPAlloc backgroundColorID;

	public BMPAlloc borderLeftColorID;

	public BMPAlloc borderTopColorID;

	public BMPAlloc borderRightColorID;

	public BMPAlloc borderBottomColorID;

	public BMPAlloc tintColorID;

	public float compositeOpacity;

	public float backgroundAlpha;

	public BasicNode<TextureEntry> textures;

	public bool pendingRepaint;

	public bool pendingHierarchicalRepaint;

	public RenderChainCommand lastTailOrHeadCommand => lastTailCommand ?? lastHeadCommand;

	public bool isInChain
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		get
		{
			return (flags & RenderDataFlags.IsInChain) == RenderDataFlags.IsInChain;
		}
	}

	public bool isGroupTransform
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		get
		{
			return (flags & RenderDataFlags.IsGroupTransform) == RenderDataFlags.IsGroupTransform;
		}
	}

	public bool isIgnoringDynamicColorHint
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		get
		{
			return (flags & RenderDataFlags.IsIgnoringDynamicColorHint) == RenderDataFlags.IsIgnoringDynamicColorHint;
		}
	}

	public bool hasExtraData
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		get
		{
			return (flags & RenderDataFlags.HasExtraData) == RenderDataFlags.HasExtraData;
		}
	}

	public bool hasExtraMeshes
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		get
		{
			return (flags & RenderDataFlags.HasExtraMeshes) == RenderDataFlags.HasExtraMeshes;
		}
	}

	public static bool AllocatesID(BMPAlloc alloc)
	{
		return alloc.ownedState == OwnedState.Owned && alloc.IsValid();
	}

	public static bool InheritsID(BMPAlloc alloc)
	{
		return alloc.ownedState == OwnedState.Inherited && alloc.IsValid();
	}
}
