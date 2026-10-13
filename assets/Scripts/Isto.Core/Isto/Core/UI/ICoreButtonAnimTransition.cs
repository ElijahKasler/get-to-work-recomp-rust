using System.Collections;

namespace Isto.Core.UI;

public interface ICoreButtonAnimTransition
{
	IEnumerator EvaluateAnimation();

	IEnumerator EvaluateAnimation(CoreButton.CoreButtonSelectionState state);
}
