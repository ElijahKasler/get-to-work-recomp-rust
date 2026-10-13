using System;

namespace Isto.Core.UI;

[Serializable]
public class Vector2StateDataValue : Vector2StateData
{
	public Vector2Data normal = new Vector2Data();

	public Vector2Data selected = new Vector2Data();

	public Vector2Data pressed = new Vector2Data();

	public Vector2Data disabled = new Vector2Data();

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
