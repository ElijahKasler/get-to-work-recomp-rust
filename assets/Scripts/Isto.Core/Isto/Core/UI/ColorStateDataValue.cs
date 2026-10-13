using System;

namespace Isto.Core.UI;

[Serializable]
public class ColorStateDataValue : ColorStateData
{
	public ColorData normal = new ColorData();

	public ColorData selected = new ColorData();

	public ColorData pressed = new ColorData();

	public ColorData disabled = new ColorData();

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
	}
}
