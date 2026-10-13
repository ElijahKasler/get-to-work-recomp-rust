using System.Collections.Generic;
using Isto.Core.Inputs;
using Isto.Core.StateMachine;
using UnityEngine;
using Zenject;

namespace Isto.Core.UI;

public class SimpleGameMenuStateMachine : MonoPushdownStateMachine, IUIGameMenu, IUIMenu
{
	protected MonoState _previousState;

	protected MenusEnum _currentMenu;

	protected List<CanvasGroup> _hudGroups;

	protected IControls _controls;

	protected UISimpleMenusClosedState _closedMenuState;

	private UISimpleGameMenuState _coreUIGameMenuState;

	private CheatMenuState _cheatMenu;

	public MenusEnum CurrentMenu => _currentMenu;

	public GameMenusEnum CurrentGameMenu => _currentMenu as GameMenusEnum;

	public MonoState CurrentState => _stateStack.Peek();

	[Inject]
	private void Inject(IControls controls, UISimpleMenusClosedState closedMenuSTate, UIAccessManager uiAccessor, UISimpleGameMenuState gameMenuState, CheatMenuState cheatMenu)
	{
		_controls = controls;
		_closedMenuState = closedMenuSTate;
		_coreUIGameMenuState = gameMenuState;
		_cheatMenu = cheatMenu;
		_hudGroups = uiAccessor.GetCanvasGroups(UIAccessManager.CanvasGroupId.HUDGroups);
	}

	public virtual void OpenMenu(MenusEnum menu, OpenMenuArgs args = null)
	{
		_currentMenu = menu;
		if (menu == GameMenusEnum.GAME)
		{
			EnterSubState(_coreUIGameMenuState);
		}
		else if (menu == GameMenusEnum.CHEATER)
		{
			if (_cheatMenu != null)
			{
				EnterSubState(_cheatMenu);
			}
		}
		else if (menu == GameMenusEnum.SCENE_START)
		{
			if (_currentState != startState)
			{
				PushState(startState);
			}
		}
		else
		{
			Debug.LogError("Logic not implemented for this menu.  " + menu.ToString());
		}
	}

	public virtual void CloseMenu()
	{
		if (_currentState != _closedMenuState)
		{
			while (_stateStack.Count > 1)
			{
				ExitSubState();
			}
			if (_currentState != _closedMenuState)
			{
				ChangeState(_closedMenuState);
			}
		}
		_currentMenu = MenusEnum.CLOSED;
	}

	public override void ExitSubState()
	{
		if (_stateStack.Count > 1)
		{
			_previousState = PopState();
			_currentState.ReturnFromSubState(this, _previousState);
			if (_currentState == _closedMenuState)
			{
				_controls.SetControlMode(Controls.Mode.Gameplay);
				_currentMenu = MenusEnum.CLOSED;
			}
		}
	}

	public void HideHUD(float fadeTime)
	{
		StopAllCoroutines();
		for (int i = 0; i < _hudGroups.Count; i++)
		{
			StartCoroutine(UIUtils.SetCanvasAlpha(_hudGroups[i], 0f, fadeTime, interactable: false));
		}
	}

	public void ShowHUD(float fadeTime)
	{
		StopAllCoroutines();
		for (int i = 0; i < _hudGroups.Count; i++)
		{
			StartCoroutine(UIUtils.SetCanvasAlpha(_hudGroups[i], 1f, fadeTime, interactable: true));
		}
	}

	public virtual void EnterCutSceneState()
	{
	}

	public virtual void ExitCutSceneState()
	{
	}
}
