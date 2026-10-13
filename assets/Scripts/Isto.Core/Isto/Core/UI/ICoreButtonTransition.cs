namespace Isto.Core.UI;

public interface ICoreButtonTransition
{
	CoreButton CoreButton { get; }

	void DoTransition(CoreButton.CoreButtonSelectionState state, bool instant = true);
}
