using System;

namespace UnityEngine.UIElements.Layout;

internal struct LayoutNodeData
{
	[Flags]
	internal enum FlexStatus
	{
		IsDirty = 1,
		HasNewLayout = 4,
		DependsOnParentSize = 0x40,
		Fixed = 8,
		MinViolation = 0x10,
		MaxViolation = 0x20
	}

	public FixedBuffer2<LayoutValue> ResolvedDimensions;

	private float TargetSize;

	public int ManagedMeasureFunctionIndex;

	public int ManagedBaselineFunctionIndex;

	public int ManagedOwnerIndex;

	public int LineIndex;

	public LayoutHandle Config;

	public LayoutHandle Parent;

	public LayoutHandle NextChild;

	public LayoutList<LayoutHandle> Children;

	private FlexStatus Status;

	public bool HasNewLayout
	{
		get
		{
			return (Status & FlexStatus.HasNewLayout) == FlexStatus.HasNewLayout;
		}
		set
		{
			Status = (value ? (Status | FlexStatus.HasNewLayout) : (Status & ~FlexStatus.HasNewLayout));
		}
	}

	public bool IsDirty
	{
		get
		{
			return (Status & FlexStatus.IsDirty) == FlexStatus.IsDirty;
		}
		set
		{
			Status = (value ? (Status | FlexStatus.IsDirty) : (Status & ~FlexStatus.IsDirty));
		}
	}
}
