using Isto.Core.Beings;
using Isto.Core.Enums;
using Isto.Core.Inputs;
using Isto.Core.StateMachine;
using Isto.Core.UI;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace Isto.GTW.LevelFeatures.LevelEvents;

public class ChangeGameStateEvent : LevelEvent
{
	[SerializeField]
	private State _playerState;

	[Space]
	[SerializeField]
	private bool _changeControlsMode;

	[SerializeField]
	private Controls.Mode _controlsMode;

	[Space]
	[SerializeField]
	private bool _changeMenu;

	[EnumDropdown(typeof(MenusEnum))]
	[SerializeField]
	private int _menu;

	[SerializeField]
	private bool _enterMenuCutsceneState;

	[SerializeField]
	private bool _exitMenuCutsceneState;

	[SerializeField]
	private bool _showHUD;

	[SerializeField]
	private bool _hideHUD;

	[SerializeField]
	private float _hudTransitionTime = 1f;

	[SerializeField]
	private UnityEvent _onTrigger;

	private IControls _controls;

	private IUIGameMenu _menuController;

	private IPlayerController _player;

	[Inject]
	public void Inject(IControls controls, IPlayerController player, IUIGameMenu menu)
	{
		_controls = controls;
		_player = player;
		_menuController = menu;
	}

	public override void TriggerEvent(bool initialization = false)
	{
		if (_changeControlsMode)
		{
			_controls.SetControlMode(_controlsMode);
		}
		if (_playerState != null)
		{
			_player.ChangeToCustomState(_playerState);
		}
		if (_changeMenu)
		{
			MenusEnum menu = ExpandableEnum<Int32Enum<MenusEnum>, int>.GetFromValue(_menu) as MenusEnum;
			_menuController.OpenMenu(menu);
		}
		if (_enterMenuCutsceneState)
		{
			_menuController.EnterCutSceneState();
		}
		else if (_exitMenuCutsceneState)
		{
			_menuController.ExitCutSceneState();
		}
		if (_showHUD)
		{
			_menuController.ShowHUD(_hudTransitionTime);
		}
		else if (_hideHUD)
		{
			_menuController.HideHUD(_hudTransitionTime);
		}
		if (_onTrigger != null)
		{
			_onTrigger.Invoke();
		}
	}
}
