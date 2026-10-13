using System;

namespace Isto.Core.UI;

[Serializable]
public class MaterialStateDataRef : MaterialStateData
{
	public MaterialDataObject normal;

	public MaterialDataObject selected;

	public MaterialDataObject pressed;

	public MaterialDataObject disabled;

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
}
