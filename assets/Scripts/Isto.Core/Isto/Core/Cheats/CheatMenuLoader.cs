using Isto.Core.Game;
using Isto.Core.Inputs;
using Isto.Core.UI;
using UnityEngine;
using Zenject;

namespace Isto.Core.Cheats;

public class CheatMenuLoader : MonoBehaviour
{
	private float _spamTimer;

	private IControls _controls;

	private GameState _gameState;

	private SimpleGameMenuStateMachine _menuStateMachine;

	private CheatMenuState _cheatMenu;

	private CheatSettings _cheatSettings;

	[Inject]
	public void Inject(IControls controls, GameState gameState, SimpleGameMenuStateMachine menuStateMachine, CheatMenuState cheatMenu, CheatSettings cheatSettings)
	{
		_controls = controls;
		_gameState = gameState;
		_menuStateMachine = menuStateMachine;
		_cheatMenu = cheatMenu;
		_cheatSettings = cheatSettings;
	}

	private void Awake()
	{
	}

	private void Update()
	{
		if (!_cheatSettings.CheatsEnabled || (!(_gameState.CurrentGameMode == null) && !_gameState.CurrentGameMode.DeveloperConsoleEnabled) || PlayerPrefs.GetInt(UISettingsGameplaySubState.CHEAT_MENU_PLAYER_PREFS_KEY, 0) != 1)
		{
			return;
		}
		_spamTimer += Time.deltaTime;
		bool buttonDown = _controls.GetButtonDown(UserActions.TOGGLEDEVCONSOLE);
		if ((_spamTimer > Constants.BUTTON_SPAM_DELAY) & buttonDown)
		{
			if (_cheatMenu.IsOpen)
			{
				_menuStateMachine.CloseMenu();
			}
			else
			{
				_menuStateMachine.OpenMenu(GameMenusEnum.CHEATER);
			}
			_spamTimer = 0f;
		}
	}
}
