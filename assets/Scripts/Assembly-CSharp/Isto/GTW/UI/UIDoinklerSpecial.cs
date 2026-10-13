using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using I2.Loc;
using Isto.Core;
using Isto.Core.Data;
using Isto.Core.Game;
using Isto.Core.Inputs;
using Isto.Core.Localization;
using Isto.Core.Speedrun;
using Isto.Core.StateMachine;
using Isto.Core.UI;
using Isto.GTW.Configuration;
using Isto.GTW.Data;
using Isto.GTW.Leaderboards;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;

namespace Isto.GTW.UI;

public class UIDoinklerSpecial : CoreUISetGameModeSubState
{
	[Header("Confirm Dialogue")]
	[SerializeField]
	private UISimpleConfirmModalState _confirmationSubState;

	[Header("Leaderboard")]
	[SerializeField]
	private Transform _leaderboardContainer;

	[SerializeField]
	private GameObject _leaderboardEntryPrefab;

	[SerializeField]
	private Scrollbar _leaderboardScrollbar;

	[Header("Progress Report")]
	[SerializeField]
	private TextMeshProUGUI _employeeNameText;

	[SerializeField]
	private TextMeshProUGUI _totalTimeText;

	[SerializeField]
	private TextMeshProUGUI _currentCheckpointText;

	[SerializeField]
	private CoreButton _doinklerStartButton;

	[Header("Bottom of Folder")]
	[SerializeField]
	private CoreButton _resetProgressButton;

	[Header("Doinkler Special Data Hookup")]
	[SerializeField]
	private GTWGameLevelDefinition _gameLevelDefinition;

	[Header("Loc Terms")]
	[SerializeField]
	private LocalizedString _hoursLocTerm;

	[SerializeField]
	private LocalizedString _minutesLocTerm;

	[SerializeField]
	private LocalizedString _secondsLocTerm;

	[Header("Speedrun Settings for Doinkler Special")]
	[SerializeField]
	private SpeedrunSettings _doinklerSpecialSpeedrunSettings;

	private Selectable _currentSelection;

	private MonoPushdownStateMachine _menuController;

	private Color _normalButtonColor;

	private Color _disabledButtonColor = Color.gray;

	private bool _resetButtonAllowed;

	private MultiTermLocExpression _levelTimeLocExpression;

	private string _checkpointProgression;

	private IGameData _gameData;

	private GTWGameState _gameState;

	private ILeaderboard _doinklerSpecialLeaderboard;

	private GTWProgressProvider _gameProgressProvider;

	private TitleScreenPlayerDataManager _playerDataManager;

	private LocTerm.Factory _locTermFactory;

	[Inject]
	public void Inject(GTWGameState gamestate, IGameData gameData, ILeaderboard doinklerSpecialLeaderboard, IGameProgressProvider gameProgressProvider, TitleScreenPlayerDataManager playerDataManager, LocTerm.Factory locTermFactory)
	{
		_gameState = gamestate;
		_gameData = gameData;
		_doinklerSpecialLeaderboard = doinklerSpecialLeaderboard;
		_gameProgressProvider = gameProgressProvider as GTWProgressProvider;
		_playerDataManager = playerDataManager;
		_locTermFactory = locTermFactory;
	}

	private void Awake()
	{
		_normalButtonColor = _resetProgressButton.colors.normalColor;
	}

	public override void Enter(MonoStateMachine controller)
	{
		base.Enter(controller);
		RebindSpeedrunSettings();
		for (int num = _leaderboardContainer.childCount - 1; num >= 0; num--)
		{
			UnityEngine.Object.Destroy(_leaderboardContainer.GetChild(num).gameObject);
		}
		SetupStateMachineController(controller);
		SetupProgressReport();
		SetupCompanyLeaderboard();
		StartCoroutine(LoadDoinklerBestTimeAndCheckpoint());
		_resetButtonAllowed = false;
		SetupResetButton();
		_currentSelection = _doinklerStartButton;
		if (_controls.UsingJoystick())
		{
			_currentSelection.Select();
		}
	}

	public override MonoState Run(MonoStateMachine controller)
	{
		if (_controls.GetButtonDown(UserActions.UICANCEL))
		{
			_menuController.ExitSubState();
		}
		if (_controls.UsingJoystick() && EventSystem.current.currentSelectedGameObject == null)
		{
			HighlightFallbackSelectable();
		}
		return this;
	}

	public override void ReturnFromSubState(MonoStateMachine controller, MonoState previousState)
	{
		if (_controls.UsingJoystick())
		{
			HighlightFallbackSelectable();
		}
	}

	protected override void RegisterEvents()
	{
		base.RegisterEvents();
		Events.Subscribe("LanguageChanged", Events_OnLanguageChanged);
		Events.Subscribe("InputChanged", Events_OnInputModeChanged);
		_doinklerSpecialLeaderboard.OnCheckpointsDownloaded += LeaderboardManager_OnCheckpointsDownloaded;
	}

	protected override void UnregisterEvents()
	{
		base.UnregisterEvents();
		Events.UnSubscribe("InputChanged", Events_OnInputModeChanged);
		Events.UnSubscribe("LanguageChanged", Events_OnLanguageChanged);
		_doinklerSpecialLeaderboard.OnCheckpointsDownloaded -= LeaderboardManager_OnCheckpointsDownloaded;
	}

	private void Events_OnInputModeChanged()
	{
		if (_controls.UsingJoystick())
		{
			if (_currentSelection == null)
			{
				_currentSelection = _doinklerStartButton;
			}
			_currentSelection.Select();
		}
		else if (!_controls.UsingJoystick() && EventSystem.current.currentSelectedGameObject != null)
		{
			EventSystem.current.SetSelectedGameObject(null);
		}
	}

	private void Events_OnLanguageChanged()
	{
		UpdateLocalization();
	}

	private void LeaderboardManager_OnCheckpointsDownloaded()
	{
		for (int num = _leaderboardContainer.childCount - 1; num >= 0; num--)
		{
			UnityEngine.Object.Destroy(_leaderboardContainer.GetChild(num).gameObject);
		}
		List<LeaderboardEntryData> leaderboardEntries = _doinklerSpecialLeaderboard.LeaderboardEntries;
		List<Selectable> list = new List<Selectable>();
		foreach (LeaderboardEntryData item in leaderboardEntries)
		{
			GTWLeaderboardPlayerDisplay component = UnityEngine.Object.Instantiate(_leaderboardEntryPrefab, _leaderboardContainer).GetComponent<GTWLeaderboardPlayerDisplay>();
			component.Setup(item, isFriendsMode: true);
			list.Add(component.GetComponent<Selectable>());
		}
		float t = (float)(leaderboardEntries.Count - 12) / 38f;
		_leaderboardScrollbar.numberOfSteps = Mathf.RoundToInt(Mathf.Lerp(3f, 10f, t));
		SetupSelectables(list);
	}

	public void ResetProgress_ButtonClicked()
	{
		if (_resetButtonAllowed)
		{
			if (_controls.UsingJoystick() && _resetProgressButton != null && _resetProgressButton.gameObject.activeInHierarchy && _resetProgressButton.interactable)
			{
				_currentSelection = _resetProgressButton;
				_currentSelection.Select();
			}
			_confirmationSubState.SetCallbacks(ConfirmationSubState_ResetTimesConfirmed, null);
			_menuController.EnterSubState(_confirmationSubState);
		}
	}

	public void StartLevel_ButtonClicked()
	{
		_gameState.GameLevelDefinition = _gameLevelDefinition;
		int saveSlot = 7;
		_gameData.HasSaveData(saveSlot, (bool dataExists) =>
		{
			if (dataExists)
			{
				_gameState.LoadSaveSlotMetaData(saveSlot, (bool gameStateData) =>
				{
					_gameState.LoadSaveGame(saveSlot);
				});
			}
			else
			{
				_gameState.SaveSlot = saveSlot;
				_gameState.StartGameMode(_gameLevelDefinition.gameMode);
			}
			_menuController.ExitSubState();
		});
	}

	private void ConfirmationSubState_ResetTimesConfirmed()
	{
		_resetButtonAllowed = false;
		SetupResetButtonColors();
		_gameData.ClearSaveData(7, (bool _) =>
		{
			Debug.Log($"Cleared Save Data for saveslot {GTWGameState.SaveSlotId.DOINKLER_SPECIAL}");
		});
		SetDoinklerSpeedrunTime(0f);
		SetDoinklerCheckpointProgression(0);
		UpdateDoinklerTimeAndCheckpointUI();
	}

	private void SetDoinklerCheckpointProgression(int currentCheckpoint)
	{
		_checkpointProgression = $"{currentCheckpoint}/{_playerDataManager.GetMaxGameProgressLevel()}";
	}

	private void SetDoinklerSpeedrunTime(float gameTime)
	{
		List<LocTerm> list = new List<LocTerm>();
		LocTerm item = _locTermFactory.Create(LocTerm.LocalizationType.NonLocalized, ", ");
		LocTerm item2 = _locTermFactory.Create(LocTerm.LocalizationType.NonLocalized, " ");
		TimeSpan timeSpan = TimeSpan.FromSeconds(gameTime);
		list.Add(_locTermFactory.Create(LocTerm.LocalizationType.NonLocalized, timeSpan.Hours.ToString("00")));
		list.Add(item2);
		list.Add(_locTermFactory.Create(LocTerm.LocalizationType.Localized, _hoursLocTerm.mTerm));
		list.Add(item);
		list.Add(_locTermFactory.Create(LocTerm.LocalizationType.NonLocalized, timeSpan.Minutes.ToString("00")));
		list.Add(item2);
		list.Add(_locTermFactory.Create(LocTerm.LocalizationType.Localized, _minutesLocTerm.mTerm));
		list.Add(item);
		list.Add(_locTermFactory.Create(LocTerm.LocalizationType.NonLocalized, timeSpan.Seconds.ToString("00")));
		list.Add(item2);
		list.Add(_locTermFactory.Create(LocTerm.LocalizationType.Localized, _secondsLocTerm.mTerm));
		_levelTimeLocExpression = new MultiTermLocExpression(list);
	}

	protected override void HighlightFallbackSelectable()
	{
		_currentSelection = _resetProgressButton;
		_currentSelection.Select();
	}

	private void SetupCompanyLeaderboard()
	{
		_doinklerSpecialLeaderboard.DownloadFriendsEntries();
	}

	private void SetupResetButton()
	{
		SetupResetButtonColors();
		_gameData.HasSaveData(7, (bool yes) =>
		{
			if (yes)
			{
				_resetButtonAllowed = true;
			}
			SetupResetButtonColors();
		});
	}

	private void SetupResetButtonColors()
	{
		ColorBlock colors = _resetProgressButton.colors;
		if (_resetButtonAllowed)
		{
			colors.normalColor = _normalButtonColor;
		}
		else
		{
			colors.normalColor = _disabledButtonColor;
		}
		_resetProgressButton.colors = colors;
	}

	private void SetupProgressReport()
	{
		if (SteamManager.Initialized)
		{
			_employeeNameText.text = _doinklerSpecialLeaderboard.LeaderboardName;
		}
		_totalTimeText.text = "51 hr, 2 min, 4 sec";
		_currentCheckpointText.text = "5/45";
	}

	private void SetupStateMachineController(MonoStateMachine controller)
	{
		if (controller is MonoPushdownStateMachine menuController)
		{
			_menuController = menuController;
		}
		else
		{
			Debug.LogError("Using level select menu without a push down menu controller, this won't work");
		}
	}

	private void SetupSelectables(List<Selectable> leaderboardDisplaySelectables)
	{
		for (int i = 0; i < leaderboardDisplaySelectables.Count; i++)
		{
			Selectable selectable = leaderboardDisplaySelectables[i];
			if (leaderboardDisplaySelectables.Count > 1)
			{
				if (i == 0)
				{
					UIUtils.SetNavigation(selectable, UIUtils.NavigationDirection.Down, leaderboardDisplaySelectables[i + 1]);
				}
				else if (i == leaderboardDisplaySelectables.Count - 1)
				{
					UIUtils.SetNavigation(selectable, UIUtils.NavigationDirection.Up, leaderboardDisplaySelectables[i - 1]);
				}
				else
				{
					UIUtils.SetNavigation(selectable, UIUtils.NavigationDirection.Down, leaderboardDisplaySelectables[i + 1]);
					UIUtils.SetNavigation(selectable, UIUtils.NavigationDirection.Up, leaderboardDisplaySelectables[i - 1]);
				}
			}
			UIUtils.SetNavigation(selectable, UIUtils.NavigationDirection.Right, _doinklerStartButton);
		}
		if (leaderboardDisplaySelectables.Count > 0 && _leaderboardScrollbar.isActiveAndEnabled)
		{
			ConfigureScrollbarNavigation();
		}
	}

	private IEnumerator LoadDoinklerBestTimeAndCheckpoint()
	{
		_gameState.GameLevelDefinition = _gameLevelDefinition;
		int slotNumber = 7;
		bool isLoadComplete = false;
		_gameData.HasSaveData(slotNumber, (bool dataExists) =>
		{
			if (dataExists)
			{
				_gameData.LoadGameData(7, (bool success) =>
				{
					float doinklerSpeedrunTime = _gameProgressProvider.GameTime.Sum((KeyValuePair<int, float> x) => x.Value);
					SetDoinklerSpeedrunTime(doinklerSpeedrunTime);
					SetDoinklerCheckpointProgression(_playerDataManager.GetCurrentGameProgressLevel());
					isLoadComplete = true;
				});
			}
			else
			{
				isLoadComplete = true;
				SetDoinklerSpeedrunTime(0f);
				SetDoinklerCheckpointProgression(0);
			}
		});
		while (!isLoadComplete)
		{
			yield return null;
		}
		UpdateDoinklerTimeAndCheckpointUI();
	}

	private void UpdateDoinklerTimeAndCheckpointUI()
	{
		_currentCheckpointText.text = _checkpointProgression;
		_levelTimeLocExpression.LocalizeInto(_totalTimeText);
	}

	private void UpdateLocalization()
	{
		_levelTimeLocExpression.LocalizeInto(_totalTimeText);
	}

	private void RebindSpeedrunSettings()
	{
		DiContainer container = ProjectContext.Instance.Container;
		container.Rebind(typeof(SpeedrunSettings)).FromInstance(_doinklerSpecialSpeedrunSettings).AsCached()
			.NonLazy();
		container.Inject(_gameData);
	}

	private void ConfigureScrollbarNavigation()
	{
		UIUtils.SetNavigation(_doinklerStartButton, UIUtils.NavigationDirection.Left, _leaderboardScrollbar);
		UIUtils.SetNavigation(_leaderboardScrollbar, UIUtils.NavigationDirection.Right, _doinklerStartButton);
	}
}
