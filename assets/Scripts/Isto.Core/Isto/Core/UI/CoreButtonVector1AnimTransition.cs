using Isto.Core.UI.ButtonStyles;

namespace Isto.Core.UI;

public abstract class CoreButtonVector1AnimTransition : CoreButtonAnimTransitionBase<Vector1Style, Vector1StateData, Vector1StateDataValue>
{
	protected override bool Evaluate(CoreButton.CoreButtonSelectionState state, float time)
	{
		Vector1StateData vector1StateData = GetStateData();
		if (vector1StateData != null && vector1StateData.GetState(state) is Vector1Data vector1Data)
		{
			SetObjectProperties(vector1Data.Evaluate(time));
			return time >= vector1Data.AnimationTimeLength;
		}
		return true;
	}

	protected abstract void SetObjectProperties(float xValue);
}
