using Isto.Core.UI.ButtonStyles;
using UnityEngine;

namespace Isto.Core.UI;

public abstract class CoreButtonVector3AnimTransition : CoreButtonAnimTransitionBase<Vector3Style, Vector3StateData, Vector3StateDataValue>
{
	protected override bool Evaluate(CoreButton.CoreButtonSelectionState state, float time)
	{
		IStateData stateData = GetStateData();
		if (stateData != null && stateData.GetState(state) is Vector3Data vector3Data)
		{
			SetObjectProperties(vector3Data.Evaluate(time));
			return time >= vector3Data.AnimationTimeLength;
		}
		return true;
	}

	protected abstract void SetObjectProperties(Vector3 value);
}
