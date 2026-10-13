using System;

namespace Isto.Core.UI;

[Serializable]
public class Vector3StateDataRef : Vector3StateData
{
	public Vector3DataObject normal;

	public Vector3DataObject selected;

	public Vector3DataObject pressed;

	public Vector3DataObject disabled;

	public override IData GetState(CoreButton.CoreButtonSelectionState state)
	{
		switch (state)
		{
		case CoreButton.CoreButtonSelectionState.Normal:
			if (!(normal != null))
			{
				return null;
			}
			return normal.data;
		case CoreButton.CoreButtonSelectionState.Pressed:
			if (!(pressed != null))
			{
				return null;
			}
			return pressed.data;
		case CoreButton.CoreButtonSelectionState.Highlighted:
		case CoreButton.CoreButtonSelectionState.Selected:
			if (!(selected != null))
			{
				return null;
			}
			return selected.data;
		case CoreButton.CoreButtonSelectionState.Disabled:
			if (!(disabled != null))
			{
				return null;
			}
			return disabled.data;
		default:
			return null;
		}
	}

	public override void UpdateAnimLength()
	{
		normal?.data.UpdateAnimLength();
		pressed?.data.UpdateAnimLength();
		selected?.data.UpdateAnimLength();
		disabled?.data.UpdateAnimLength();
	}
}
