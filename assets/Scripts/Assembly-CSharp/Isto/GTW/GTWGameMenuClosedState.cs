using Isto.Core.Inputs;
using Isto.Core.StateMachine;
using Isto.Core.UI;
using UI.ReadyScreen;

namespace Isto.GTW;

public class GTWGameMenuClosedState : UISimpleMenusClosedState
{
	public override MonoState Run(MonoStateMachine controller)
	{
		if (_controls.GetButtonDown(UserActions.TOGGLEGAMEMENU) && !ReadyScreen.IsVisible && !ReadyScreen.IsClosing)
		{
			_coreMainMenu.OpenMenu(GameMenusEnum.GAME);
		}
		return this;
	}
}
