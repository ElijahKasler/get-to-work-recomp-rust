namespace UnityEngine.UIElements;

internal class VisualTreeWorldSpaceHierarchyFlagsUpdater : VisualTreeHierarchyFlagsUpdater
{
	private new const VisualElementFlags BoundingBoxDirtyFlags = VisualElementFlags.BoundingBoxDirty | VisualElementFlags.WorldBoundingBoxDirty | VisualElementFlags.LocalBounds3DDirty | VisualElementFlags.BoundingBoxDirtiedSinceLastLayoutPass;

	public override void OnVersionChanged(VisualElement ve, VersionChangeType versionChangeType)
	{
		base.OnVersionChanged(ve, versionChangeType);
		if ((versionChangeType & (VersionChangeType.Hierarchy | VersionChangeType.Overflow | VersionChangeType.BorderWidth | VersionChangeType.Transform | VersionChangeType.Size | VersionChangeType.EventCallbackCategories | VersionChangeType.Picking)) != 0)
		{
			if ((versionChangeType & (VersionChangeType.Hierarchy | VersionChangeType.Overflow | VersionChangeType.BorderWidth | VersionChangeType.Transform | VersionChangeType.Size | VersionChangeType.EventCallbackCategories)) != 0)
			{
				VisualTreeHierarchyFlagsUpdater.DirtyHierarchy(ve, VisualTreeHierarchyFlagsUpdater.GetChildrenMustDirtyFlags(ve, versionChangeType));
			}
			if ((versionChangeType & (VersionChangeType.Hierarchy | VersionChangeType.Overflow | VersionChangeType.Transform | VersionChangeType.Size)) != 0)
			{
				VisualTreeHierarchyFlagsUpdater.DirtyParentHierarchy(ve, GetParentMustDirtyFlags(ve));
			}
		}
	}

	private VisualElementFlags GetParentMustDirtyFlags(VisualElement ve)
	{
		VisualElementFlags visualElementFlags = VisualElementFlags.BoundingBoxDirty | VisualElementFlags.WorldBoundingBoxDirty | VisualElementFlags.LocalBounds3DDirty | VisualElementFlags.BoundingBoxDirtiedSinceLastLayoutPass;
		if (ve.has3DTransform)
		{
			visualElementFlags |= VisualElementFlags.Needs3DBounds;
		}
		return visualElementFlags;
	}

	public override void Update()
	{
	}
}
