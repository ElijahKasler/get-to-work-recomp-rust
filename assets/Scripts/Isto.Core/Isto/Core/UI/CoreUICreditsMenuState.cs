using Isto.Core.Inputs;
using Isto.Core.StateMachine;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;

namespace Isto.Core.UI;

public class CoreUICreditsMenuState : MonoState
{
	[SerializeField]
	private Selectable _firstSelection;

	private MonoPushdownStateMachine _controller;

	private IControls _controls;

	[Inject]
	public void Inject(IControls controls)
	{
		_controls = controls;
	}

	public override void Enter(MonoStateMachine controller)
	{
		_controller = controller as MonoPushdownStateMachine;
		base.gameObject.SetActive(value: true);
		if (_firstSelection != null && Controls.UsingController)
		{
			_firstSelection.Select();
		}
		RegisterEvents();
	}

	public override void Exit(MonoStateMachine controller)
	{
		UnregisterEvents();
		base.gameObject.SetActive(value: false);
	}

	public override void ReturnFromSubState(MonoStateMachine controller, MonoState previousState)
	{
		Debug.LogError("Shouldn't happen");
	}

	public override MonoState Run(MonoStateMachine controller)
	{
		if (_controls.GetButtonDown(UserActions.UICANCEL))
		{
			_controller.ExitSubState();
		}
		return this;
	}

	public void ExitSubState()
	{
		_controller.ExitSubState();
	}

	private void RegisterEvents()
	{
		Events.Subscribe("InputChanged", Events_OnInputModeChanged);
	}

	private void UnregisterEvents()
	{
		Events.UnSubscribe("InputChanged", Events_OnInputModeChanged);
	}

	private void Events_OnInputModeChanged()
	{
		if (Controls.UsingController)
		{
			_firstSelection.Select();
		}
		else if (EventSystem.current.currentSelectedGameObject != null)
		{
			EventSystem.current.SetSelectedGameObject(null);
		}
	}
}
