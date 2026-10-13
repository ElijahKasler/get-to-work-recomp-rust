using System.Collections.Generic;
using System.Text;
using Isto.Core.Analytics;
using Isto.Core.Game;
using Isto.Core.Themes;
using Isto.Core.UI;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Isto.Core.Cheats;

public class CheatCodeDetector : MonoBehaviour
{
	public static bool CheatsBlocked;

	[FormerlySerializedAs("titleMenuCheats")]
	public CheatCodeSetup cheatsData;

	public bool verbose;

	public bool runInTitleMenu = true;

	private List<KeyCode> _inputHistory = new List<KeyCode>();

	private HashSet<KeyCode> _validInputs = new HashSet<KeyCode>();

	private int _maxQueueSize;

	private bool _waitingForPopup;

	private GameState _gameState;

	private ThemeSetup _themeSetup;

	private ThemeManager _themeManager;

	private IAnalyticsHandler _analytics;

	private UIModalChoicePopup _modalChoicePopup;

	[Inject]
	public void Inject(GameState gameState, ThemeSetup themeSetup, ThemeManager themeManager, IAnalyticsHandler analytics, UIModalChoicePopup modalChoicePopup)
	{
		_gameState = gameState;
		_themeSetup = themeSetup;
		_themeManager = themeManager;
		_analytics = analytics;
		_modalChoicePopup = modalChoicePopup;
	}

	private void Start()
	{
		if (cheatsData.IsNullOrDestroyed())
		{
			Debug.LogError("CheatActivator needs a CheatsSetup assigned in the inspector");
			return;
		}
		foreach (CheatCodeSetup.KeyboardCheatData keyboardCheat in cheatsData.keyboardCheats)
		{
			if (keyboardCheat.buttonPresses.Count > _maxQueueSize)
			{
				_maxQueueSize = keyboardCheat.buttonPresses.Count;
			}
			foreach (KeyCode buttonPress in keyboardCheat.buttonPresses)
			{
				_validInputs.Add(buttonPress);
			}
		}
	}

	private void Update()
	{
		if (cheatsData.IsNullOrDestroyed() || !runInTitleMenu || (runInTitleMenu && (!_gameState.IsInTitleScene() || CheatsBlocked)))
		{
			return;
		}
		bool anyKeyDown = Input.anyKeyDown;
		bool flag = false;
		foreach (KeyCode validInput in _validInputs)
		{
			if (Input.GetKeyDown(validInput))
			{
				_inputHistory.Add(validInput);
				if (_inputHistory.Count > _maxQueueSize)
				{
					_inputHistory.RemoveAt(0);
				}
				flag = true;
				if (verbose)
				{
					Debug.Log("[cheat] input history = " + DebugListInputHistory());
				}
				break;
			}
		}
		if (anyKeyDown && !flag)
		{
			_inputHistory.Clear();
			if (verbose)
			{
				Debug.Log("[cheat] input history = RESET");
			}
		}
		if (flag)
		{
			CheckForActivatedCheats();
		}
	}

	private void CheckForActivatedCheats()
	{
		foreach (CheatCodeSetup.KeyboardCheatData keyboardCheat in cheatsData.keyboardCheats)
		{
			if (keyboardCheat.buttonPresses.Count <= _inputHistory.Count && CheckForActivation(keyboardCheat))
			{
				Activate(keyboardCheat);
				break;
			}
		}
	}

	private string DebugListInputHistory()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("<");
		foreach (KeyCode item in _inputHistory)
		{
			stringBuilder.Append(item.ToString() + ",");
		}
		stringBuilder.Append(">");
		return stringBuilder.ToString();
	}

	private bool CheckForActivation(CheatCodeSetup.KeyboardCheatData cheat)
	{
		bool result = true;
		for (int i = 0; i < cheat.buttonPresses.Count; i++)
		{
			KeyCode num = cheat.buttonPresses[cheat.buttonPresses.Count - 1 - i];
			KeyCode keyCode = _inputHistory[_inputHistory.Count - 1 - i];
			if (num != keyCode)
			{
				result = false;
				break;
			}
		}
		return result;
	}

	private void Activate(CheatCodeSetup.KeyboardCheatData cheat)
	{
		if (_waitingForPopup)
		{
			return;
		}
		if (verbose)
		{
			Debug.Log($"Activating cheat code {cheat.internalName} with effect {cheat.effect}");
		}
		CheatCodeSetup.CheatEffect effect = cheat.effect;
		if (effect != CheatCodeSetup.CheatEffect.DoNothing && effect == CheatCodeSetup.CheatEffect.ToggleCatrioTheme)
		{
			if (_themeManager.CurrentTheme.internalName == Constants.CATRIO_THEME_NAME || _themeManager.CurrentTheme.internalName == Constants.ATRIOC_THEME_NAME)
			{
				_themeManager.CurrentTheme = _themeSetup.GetTheme(Constants.DEFAULT_THEME_NAME);
			}
			else
			{
				_modalChoicePopup.DisplayChoice(UIModalChoicePopup.ChoicePopupType.YesNoChoice, "Employee Question: Is your name Atrioc?", OnAtriocPopupYes1, OnAtriocPopupNo, "", "Catrio Settings: Employee Name");
				_waitingForPopup = true;
			}
		}
		_analytics.RegisterSecretCheatActivated(cheat.internalName);
	}

	private void OnAtriocPopupYes1()
	{
		_modalChoicePopup.DisplayChoice(UIModalChoicePopup.ChoicePopupType.NoChoice, "Difficulty set to: PURE DEATH", OnAtriocPopupYes2, null, "Welcome, Atrioc.", "Catrio Settings: Difficulty", "OK");
	}

	private void OnAtriocPopupYes2()
	{
		_modalChoicePopup.DisplayChoice(UIModalChoicePopup.ChoicePopupType.NoChoice, "Custom skin set to: PATRIOTIC CANADIAN \nNote: This skin is permanent and can never be changed.", OnAtriocPopupYes3, null, "New Skin Unlocked!", "Catrio Settings", "Atrio Forever!");
	}

	private void OnAtriocPopupYes3()
	{
		_modalChoicePopup.DisplayChoice(UIModalChoicePopup.ChoicePopupType.NoChoice, "We did add something small in game just for you. \n Thanks for playing and enjoy. \n \n- Steve + The Isto Team", OnInfoPopupClosed, null, "Just Kidding", "Gotem", "Finish");
	}

	private void OnAtriocPopupNo()
	{
		_themeManager.CurrentTheme = _themeSetup.GetTheme(Constants.CATRIO_THEME_NAME);
		_waitingForPopup = false;
	}

	private void OnInfoPopupClosed()
	{
		_themeManager.CurrentTheme = _themeSetup.GetTheme(Constants.ATRIOC_THEME_NAME);
		_waitingForPopup = false;
	}
}
