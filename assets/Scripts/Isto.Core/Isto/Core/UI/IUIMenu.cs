using Isto.Core.StateMachine;

namespace Isto.Core.UI;

public interface IUIMenu
{
	MenusEnum CurrentMenu { get; }

	void OpenMenu(MenusEnum menu, OpenMenuArgs args = null);

	void CloseMenu();

	void EnterSubState(MonoState subState);

	void ExitSubState();

	MonoState GetCurrentState();
}
