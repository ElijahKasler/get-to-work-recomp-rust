using Isto.Core.Inputs;
using Isto.Core.StateMachine;
using UnityEngine.EventSystems;
using Zenject;

namespace Isto.Core.UI;

public class UISimpleMenusClosedState : MonoState
{
	protected SimpleGameMenuStateMachine _coreMainMenu;

	protected IControls _controls;

	[Inject]
	private void Inject(IControls controls)
	{
		_controls = controls;
	}

	public override void Enter(MonoStateMachine controller)
	{
		_coreMainMenu = controller as SimpleGameMenuStateMachine;
	}

	public override void Exit(MonoStateMachine controller)
	{
	}

	public override MonoState Run(MonoStateMachine controller)
	{
		if (_controls.GetButtonDown(UserActions.TOGGLEGAMEMENU))
		{
			_coreMainMenu.OpenMenu(GameMenusEnum.GAME);
		}
		return this;
	}

	public override void ReturnFromSubState(MonoStateMachine controller, MonoState previousState)
	{
		EventSystem.current.SetSelectedGameObject(null);
		_controls.DisableControls(Constants.BUTTON_SPAM_DELAY);
	}
}
