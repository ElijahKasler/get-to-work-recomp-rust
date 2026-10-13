using Isto.Core.UI.ButtonStyles;
using UnityEngine;

namespace Isto.Core.UI;

public abstract class CoreButtonColorAnimTransition : CoreButtonAnimTransitionBase<ColorStyle, ColorStateData, ColorStateDataValue>
{
	protected override bool Evaluate(CoreButton.CoreButtonSelectionState state, float time)
	{
		IStateData stateData = GetStateData();
		if (stateData != null && stateData.GetState(state) is IColorData colorData)
		{
			Color objectProperties = colorData.Evaluate(time);
			SetObjectProperties(objectProperties);
			return time >= colorData.AnimationTimeLength;
		}
		return true;
	}

	protected abstract void SetObjectProperties(Color color);
}
