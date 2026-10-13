using System;

namespace Isto.Core.UI;

[Serializable]
public class ColorStateDataRef : ColorStateData
{
	public ColorDataObjectBase normal;

	public ColorDataObjectBase selected;

	public ColorDataObjectBase pressed;

	public ColorDataObjectBase disabled;

	public override IData GetState(CoreButton.CoreButtonSelectionState state)
	{
		switch (state)
		{
		case CoreButton.CoreButtonSelectionState.Normal:
			if (!(normal != null))
			{
				return null;
			}
			return normal.GetData();
		case CoreButton.CoreButtonSelectionState.Pressed:
			if (!(pressed != null))
			{
				return null;
			}
			return pressed.GetData();
		case CoreButton.CoreButtonSelectionState.Highlighted:
		case CoreButton.CoreButtonSelectionState.Selected:
			if (!(selected != null))
			{
				return null;
			}
			return selected.GetData();
		case CoreButton.CoreButtonSelectionState.Disabled:
			if (!(disabled != null))
			{
				return null;
			}
			return disabled.GetData();
		default:
			return null;
		}
	}

	public override void UpdateAnimLength()
	{
	}
}
