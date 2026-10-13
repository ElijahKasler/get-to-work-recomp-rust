using Unity.Profiling;

namespace UnityEngine.UIElements;

internal class VisualTreeHierarchyFlagsUpdater : BaseVisualTreeUpdater
{
	private uint m_Version = 0u;

	private uint m_LastVersion = 0u;

	private static readonly string s_Description = "Update Hierarchy Flags";

	private static readonly ProfilerMarker s_ProfilerMarker = new ProfilerMarker(s_Description);

	private const VersionChangeType WorldTransformChanged = VersionChangeType.Transform;

	private const VersionChangeType WorldClipChanged = VersionChangeType.Overflow | VersionChangeType.BorderWidth | VersionChangeType.Transform | VersionChangeType.Size;

	private const VersionChangeType EventParentCategoriesChanged = VersionChangeType.Hierarchy | VersionChangeType.EventCallbackCategories;

	private const VersionChangeType BoundingBoxChanged = VersionChangeType.Hierarchy | VersionChangeType.Overflow | VersionChangeType.Transform | VersionChangeType.Size;

	protected const VersionChangeType ChildrenChanged = VersionChangeType.Hierarchy | VersionChangeType.Overflow | VersionChangeType.BorderWidth | VersionChangeType.Transform | VersionChangeType.Size | VersionChangeType.EventCallbackCategories;

	protected const VersionChangeType ParentChanged = VersionChangeType.Hierarchy | VersionChangeType.Overflow | VersionChangeType.Transform | VersionChangeType.Size;

	protected const VersionChangeType VersionChanged = VersionChangeType.Hierarchy | VersionChangeType.Overflow | VersionChangeType.BorderWidth | VersionChangeType.Transform | VersionChangeType.Size | VersionChangeType.Picking;

	protected const VersionChangeType AnythingChanged = VersionChangeType.Hierarchy | VersionChangeType.Overflow | VersionChangeType.BorderWidth | VersionChangeType.Transform | VersionChangeType.Size | VersionChangeType.EventCallbackCategories | VersionChangeType.Picking;

	protected const VisualElementFlags BoundingBoxDirtyFlags = VisualElementFlags.BoundingBoxDirty | VisualElementFlags.WorldBoundingBoxDirty | VisualElementFlags.BoundingBoxDirtiedSinceLastLayoutPass;

	public override ProfilerMarker profilerMarker => s_ProfilerMarker;

	public override void OnVersionChanged(VisualElement ve, VersionChangeType versionChangeType)
	{
		if ((versionChangeType & (VersionChangeType.Hierarchy | VersionChangeType.Overflow | VersionChangeType.BorderWidth | VersionChangeType.Transform | VersionChangeType.Size | VersionChangeType.EventCallbackCategories | VersionChangeType.Picking)) != 0)
		{
			bool flag = (versionChangeType & VersionChangeType.Transform) != 0;
			bool flag2 = (versionChangeType & (VersionChangeType.Overflow | VersionChangeType.BorderWidth | VersionChangeType.Transform | VersionChangeType.Size)) != 0;
			bool flag3 = (versionChangeType & (VersionChangeType.Hierarchy | VersionChangeType.EventCallbackCategories)) != 0;
			VisualElementFlags visualElementFlags = (VisualElementFlags)((flag ? 17 : 0) | (flag2 ? 4 : 0) | (flag3 ? 32 : 0));
			VisualElementFlags visualElementFlags2 = visualElementFlags & ~ve.m_Flags;
			if (visualElementFlags2 != 0)
			{
				DirtyHierarchy(ve, visualElementFlags2);
			}
			DirtyBoundingBoxHierarchy(ve);
			m_Version++;
		}
	}

	protected static VisualElementFlags GetChildrenMustDirtyFlags(VisualElement ve, VersionChangeType versionChangeType)
	{
		VisualElementFlags visualElementFlags = (VisualElementFlags)0;
		if ((versionChangeType & VersionChangeType.Transform) != 0)
		{
			visualElementFlags |= VisualElementFlags.WorldTransformDirty | VisualElementFlags.WorldBoundingBoxDirty;
		}
		if ((versionChangeType & (VersionChangeType.Overflow | VersionChangeType.BorderWidth | VersionChangeType.Transform | VersionChangeType.Size)) != 0)
		{
			visualElementFlags |= VisualElementFlags.WorldClipDirty;
		}
		if ((versionChangeType & (VersionChangeType.Hierarchy | VersionChangeType.EventCallbackCategories)) != 0)
		{
			visualElementFlags |= VisualElementFlags.EventInterestParentCategoriesDirty;
		}
		return visualElementFlags;
	}

	protected static void DirtyHierarchy(VisualElement ve, VisualElementFlags mustDirtyFlags)
	{
		ve.m_Flags |= mustDirtyFlags;
		int childCount = ve.hierarchy.childCount;
		for (int i = 0; i < childCount; i++)
		{
			VisualElement visualElement = ve.hierarchy[i];
			VisualElementFlags visualElementFlags = mustDirtyFlags & ~visualElement.m_Flags;
			if (visualElementFlags != 0)
			{
				DirtyHierarchy(visualElement, visualElementFlags);
			}
		}
	}

	private static void DirtyBoundingBoxHierarchy(VisualElement ve)
	{
		ve.m_Flags |= VisualElementFlags.BoundingBoxDirty | VisualElementFlags.WorldBoundingBoxDirty | VisualElementFlags.BoundingBoxDirtiedSinceLastLayoutPass;
		DirtyParentHierarchy(ve.hierarchy.parent, VisualElementFlags.BoundingBoxDirty | VisualElementFlags.WorldBoundingBoxDirty | VisualElementFlags.BoundingBoxDirtiedSinceLastLayoutPass);
	}

	protected static void DirtyParentHierarchy(VisualElement ve, VisualElementFlags flags)
	{
		while (ve != null && (ve.m_Flags & flags) != flags)
		{
			ve.m_Flags |= flags;
			ve = ve.hierarchy.parent;
		}
	}

	public override void Update()
	{
		if (m_Version != m_LastVersion)
		{
			m_LastVersion = m_Version;
			base.panel.UpdateElementUnderPointers();
			base.panel.visualTree.UpdateBoundingBox();
		}
	}
}
