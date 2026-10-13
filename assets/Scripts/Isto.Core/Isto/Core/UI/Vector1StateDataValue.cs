using System;

namespace Isto.Core.UI;

[Serializable]
public class Vector1StateDataValue : Vector1StateData
{
	public Vector1Data normal = new Vector1Data();

	public Vector1Data selected = new Vector1Data();

	public Vector1Data pressed = new Vector1Data();

	public Vector1Data disabled = new Vector1Data();

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
