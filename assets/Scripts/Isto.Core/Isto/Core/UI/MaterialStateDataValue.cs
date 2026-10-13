using System;

namespace Isto.Core.UI;

[Serializable]
public class MaterialStateDataValue : MaterialStateData
{
	public MaterialData normal = new MaterialData();

	public MaterialData selected = new MaterialData();

	public MaterialData pressed = new MaterialData();

	public MaterialData disabled = new MaterialData();

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
}
