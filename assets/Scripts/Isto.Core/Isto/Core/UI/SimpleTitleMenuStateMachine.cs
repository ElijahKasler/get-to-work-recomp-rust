using Isto.Core.StateMachine;
using UnityEngine;

namespace Isto.Core.UI;

public class SimpleTitleMenuStateMachine : MonoPushdownStateMachine, IUIMenu
{
	private MenusEnum _currentMenu;

	public MenusEnum CurrentMenu => _currentMenu;

	public virtual void OpenMenu(MenusEnum menu, OpenMenuArgs args = null)
	{
		_currentMenu = menu;
		if (_currentMenu == MenusEnum.CLOSED)
		{
			CloseMenu();
		}
		else
		{
			Debug.LogError("Unhandled");
		}
	}

	public virtual void CloseMenu()
	{
		if (_currentState != startState)
		{
			while (_stateStack.Count > 1)
			{
				ExitSubState();
			}
		}
		_currentMenu = MenusEnum.CLOSED;
	}
}
