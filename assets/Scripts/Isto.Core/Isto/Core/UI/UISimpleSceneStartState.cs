using Isto.Core.Inputs;
using Isto.Core.StateMachine;
using Zenject;

namespace Isto.Core.UI;

public class UISimpleSceneStartState : MonoState
{
	private IUIGameMenu _mainMenu;

	protected IControls _controls;

	public bool SceneStartComplete { get; protected set; }

	[Inject]
	private void Inject(IControls controls)
	{
		_controls = controls;
	}

	public override void Enter(MonoStateMachine controller)
	{
		_mainMenu = controller as IUIGameMenu;
		SceneStartComplete = false;
	}

	public override void Exit(MonoStateMachine controller)
	{
		SceneStartComplete = true;
	}

	public override MonoState Run(MonoStateMachine controller)
	{
		_mainMenu.CloseMenu();
		_controls.SetControlMode(Controls.Mode.Gameplay);
		return this;
	}
}
