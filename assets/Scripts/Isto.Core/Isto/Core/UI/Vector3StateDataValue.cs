using System;

namespace Isto.Core.UI;

[Serializable]
public class Vector3StateDataValue : Vector3StateData
{
	public Vector3Data normal = new Vector3Data();

	public Vector3Data selected = new Vector3Data();

	public Vector3Data pressed = new Vector3Data();

	public Vector3Data disabled = new Vector3Data();

	public override IData GetState(CoreButton.CoreButtonSelectionState state)
	{
		switch (state)
		{
		case CoreButton.CoreButtonSelectionState.Normal:
			return normal;
		case CoreButton.CoreButtonSelectionState.Pressed:
			return pressed;
		case CoreButton.CoreButtonSelectionState.Highlighted:
		case CoreButton.CoreButtonSelectionState.Selected:
			return selected;
		case CoreButton.CoreButtonSelectionState.Disabled:
			return disabled;
		default:
			return null;
		}
	}

	public override void UpdateAnimLength()
	{
		normal.UpdateAnimLength();
		pressed.UpdateAnimLength();
		selected.UpdateAnimLength();
		disabled.UpdateAnimLength();
	}
}
