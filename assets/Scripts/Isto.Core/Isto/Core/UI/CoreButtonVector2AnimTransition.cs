using Isto.Core.UI.ButtonStyles;
using UnityEngine;

namespace Isto.Core.UI;

public abstract class CoreButtonVector2AnimTransition : CoreButtonAnimTransitionBase<Vector2Style, Vector2StateData, Vector2StateDataValue>
{
	protected override bool Evaluate(CoreButton.CoreButtonSelectionState state, float time)
	{
		IStateData stateData = GetStateData();
		if (stateData != null && stateData.GetState(state) is Vector2Data vector2Data)
		{
			SetObjectProperties(vector2Data.Evaluate(time));
			return time >= vector2Data.AnimationTimeLength;
		}
		return true;
	}

	protected abstract void SetObjectProperties(Vector2 value);
}
