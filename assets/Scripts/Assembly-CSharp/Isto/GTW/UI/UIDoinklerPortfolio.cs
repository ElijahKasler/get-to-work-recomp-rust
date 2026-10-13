using System;
using System.Collections;
using System.Collections.Generic;
using FMODUnity;
using Isto.Core;
using Isto.Core.Data;
using Isto.Core.Inputs;
using Isto.Core.Speedrun;
using Isto.Core.StateMachine;
using Isto.Core.UI;
using Isto.GTW.Configuration;
using Isto.GTW.Managers;
using Isto.GTW.Player;
using Isto.GTW.Providers;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;

namespace Isto.GTW.UI;

public class UIDoinklerPortfolio : CoreUISetGameModeSubState
{
	[Header("Pop up States")]
	[SerializeField]
	private UISimpleConfirmModalState _confirmationSubState;

	[SerializeField]
	private UISimpleTimedModalState _loadingLevelDataSubState;

	[Header("Left Side Of Folder")]
	[SerializeField]
	private TextMeshProUGUI _fileTitleText;

	[SerializeField]
	private TextMeshProUGUI _fileSubTitleText;

	[SerializeField]
	private Transform _levelSelectButtonsContainer;

	[SerializeField]
	private Transform _folderTabButtonsContainer;

	[SerializeField]
	private GTWDoinklerPortfolioDefinition _doinklerPortfolioDefinition;

	[SerializeField]
	private GameObject _levelSelectButtonPrefab;

	[Header("FolderBackground")]
	[SerializeField]
	private Image _folderBackground;

	[SerializeField]
	private Color _folderColorBeige = new Color(47f, 15f, 95f);

	[SerializeField]
	private Color _folderColorBlue = new Color(221f, 37f, 85f);

	[SerializeField]
	private Color _folderColorRed = new Color(1f, 49f, 72f);

	[Header("Right Side Of Folder")]
	[SerializeField]
	private Image _selectedLevelImage;

	[SerializeField]
	private TextMeshProUGUI _selectedLevelNameLabel;

	[SerializeField]
	private GameObject _levelCompleteImage;

	[SerializeField]
	private CoreButton _doinklerPlayLevelButton;

	[Header("Bottom of Folder")]
	[SerializeField]
	private CoreButton _freshStartButton;

	[Header("Speedrun Settings for Doinkler Gameplay")]
	[SerializeField]
	private SpeedrunSettings _doinklerSpeedrunSettings;

	[Header("Audio")]
	[SerializeField]
	private EventReference _tabSwitchRef;

	[Header("DEV MODE ONLY")]
	[SerializeField]
	public bool AllLevelsUnlocked;

	private GTWGameLevelDefinition _selectedLevel;

	private MonoPushdownStateMachine _menuController;

	private List<UIGameLevelDisplay> _gameLevelDisplays;

	private int _currentWorldIndex;

	private Selectable _currentSelection;

	private Color _normalButtonColor;

	private Color _disabledButtonColor = Color.gray;

	private bool _resetButtonAllowed;

	private DiContainer _container;

	private GTWGameState _gameState;

	private IGameData _gameData;

	private IDoinklerWorldDefinitionProvider _doinklerWorldDefinitionProvider;

	private DoinklerLevelVariables _doinklerLevelVariables;

	private LevelVariables _levelVariables;

	private PlayerController _playerController;

	private List<GTWGameWorldDefinition> _gameWorlds => _doinklerPortfolioDefinition.GTWGameWorldDefinitions;

	[Inject]
	public void Inject(DiContainer container, GTWGameState gameState, IGameData gameData, IDoinklerWorldDefinitionProvider doinklerWorldDefinitionProvider, DoinklerLevelVariables doinklerLevelVariables, LevelVariables levelVariables, [InjectOptional] PlayerController playerController)
	{
		_container = container;
		_gameState = gameState;
		_gameData = gameData;
		_doinklerWorldDefinitionProvider = doinklerWorldDefinitionProvider;
		_doinklerLevelVariables = doinklerLevelVariables;
		_levelVariables = levelVariables;
		_playerController = playerController;
	}

	private void Awake()
	{
		_normalButtonColor = _freshStartButton.colors.normalColor;
	}

	public override void Enter(MonoStateMachine controller)
	{
		base.Enter(controller);
		SetupStateMachineController(controller);
		SetupFolderTabs();
		StartCoroutine(LoadAllDoinklerVariables());
	}

	public override void Exit(MonoStateMachine controller)
	{
		if (_gameState.IsDoinklerPortfolio)
		{
			int saveSlot = _gameState.SaveSlot;
			_gameData.HasSaveData(saveSlot, (bool dataExists) =>
			{
				if (dataExists)
				{
					_gameData.LoadGameData(saveSlot, (bool success) =>
					{
					});
				}
			});
			if (_playerController != null)
			{
				_playerController.CheckpointManager.Respawn();
			}
		}
		base.Exit(controller);
	}

	public override MonoState Run(MonoStateMachine controller)
	{
		if (_controls.GetButtonDown(UserActions.UICANCEL))
		{
			if (_doinklerPlayLevelButton.IsSelected && _currentSelection != null)
			{
				_currentSelection.Select();
			}
			else
			{
				_menuController.ExitSubState();
			}
		}
		if (_controls.GetButtonDown(UserActions.UITABLEFT) || _controls.GetButtonDown(UserActions.UITABRIGHT))
		{
			HandleTabNavigation();
		}
		return this;
	}

	public override void ReturnFromSubState(MonoStateMachine controller, MonoState previousState)
	{
		if (_controls.UsingJoystick())
		{
			if (_freshStartButton != null && _freshStartButton.gameObject.activeInHierarchy && _freshStartButton.interactable)
			{
				_currentSelection = _freshStartButton;
				_currentSelection.Select();
			}
			else
			{
				HighlightFallbackSelectable();
			}
		}
	}

	protected override void RegisterEvents()
	{
		base.RegisterEvents();
		Events.Subscribe("InputChanged", Events_OnInputModeChanged);
	}

	protected override void UnregisterEvents()
	{
		base.UnregisterEvents();
		Events.UnSubscribe("InputChanged", Events_OnInputModeChanged);
	}

	private void Events_OnInputModeChanged()
	{
		if (_controls.UsingJoystick())
		{
			if (_currentSelection != null)
			{
				_currentSelection.Select();
			}
			else
			{
				StartCoroutine(SelectFirstLevelAfterTabSwitch());
			}
		}
		else if (!_controls.UsingJoystick() && EventSystem.current.currentSelectedGameObject != null)
		{
			EventSystem.current.SetSelectedGameObject(null);
		}
	}

	public void FolderTab_OnClick(int fileNumber)
	{
		DisplayTabContents(fileNumber);
		if (_controls.UsingJoystick())
		{
			UIDoinklerFolderTab[] componentsInChildren = _folderTabButtonsContainer.GetComponentsInChildren<UIDoinklerFolderTab>();
			if (componentsInChildren.Length > _currentWorldIndex && _currentWorldIndex >= 0)
			{
				UIDoinklerFolderTab uIDoinklerFolderTab = componentsInChildren[_currentWorldIndex];
				if (uIDoinklerFolderTab.gameObject.activeInHierarchy)
				{
					CoreButton componentInChildren = uIDoinklerFolderTab.GetComponentInChildren<CoreButton>();
					if (componentInChildren != null && componentInChildren.interactable)
					{
						_currentSelection = componentInChildren;
						_currentSelection.Select();
					}
				}
			}
		}
		StartCoroutine(UpdateFolderTabNavigation());
		if (!_tabSwitchRef.IsNull)
		{
			RuntimeManager.PlayOneShot(_tabSwitchRef);
		}
	}

	public void LevelDisplayButton_OnPressed(GTWGameLevelDefinition gameLevel)
	{
		DisplayLevelInfo(gameLevel);
		foreach (UIGameLevelDisplay gameLevelDisplay in _gameLevelDisplays)
		{
			if (!(gameLevel == gameLevelDisplay.GameLevel))
			{
				continue;
			}
			CoreButton componentInChildren = gameLevelDisplay.GetComponentInChildren<CoreButton>();
			if ((object)componentInChildren != null && componentInChildren != null)
			{
				if (componentInChildren.interactable)
				{
					_currentSelection = componentInChildren;
					break;
				}
			}
			else
			{
				Debug.LogError("Non CoreButton UIGameLevelDisplay, must be a setup problem", gameLevelDisplay.gameObject);
			}
		}
		if (_controls.UsingJoystick())
		{
			_doinklerPlayLevelButton.Select();
		}
	}

	public void ResetProgress_ButtonClicked()
	{
		if (_resetButtonAllowed)
		{
			if (_controls.UsingJoystick() && _freshStartButton != null && _freshStartButton.gameObject.activeInHierarchy && _freshStartButton.interactable)
			{
				_freshStartButton.Select();
			}
			_confirmationSubState.SetCallbacks(ConfirmationSubState_ResetTimesConfirmed, null);
			_menuController.EnterSubState(_confirmationSubState);
		}
	}

	private void ConfirmationSubState_ResetTimesConfirmed()
	{
		_resetButtonAllowed = false;
		SetupResetButtonColors();
		StartCoroutine(ClearAndSaveLevelData());
	}

	public void StartLevel_ButtonClicked()
	{
		_doinklerWorldDefinitionProvider.Current = _gameWorlds[_currentWorldIndex];
		RebindSpeedrunSettings();
		_gameState.GameLevelDefinition = _selectedLevel;
		int saveSlot = (int)_doinklerWorldDefinitionProvider.Current.SaveSlotId;
		_gameData.HasSaveData(saveSlot, (bool dataExists) =>
		{
			if (dataExists)
			{
				_gameState.LoadSaveSlotMetaData(saveSlot, (bool gameStateData) =>
				{
					_gameState.CurrentGameMode = _selectedLevel.gameMode;
					_gameState.LoadSaveGame(saveSlot);
				});
			}
			else
			{
				_gameState.SaveSlot = saveSlot;
				_gameState.StartGameMode(_selectedLevel.gameMode);
			}
		});
	}

	private void DisplayLevelInfo(GTWGameLevelDefinition gameLevel)
	{
		_selectedLevel = gameLevel;
		_selectedLevelImage.sprite = _selectedLevel.LevelImage;
		_selectedLevelNameLabel.text = _selectedLevel.LevelName.ToString();
		_levelCompleteImage.SetActive(_selectedLevel.IsCompleted);
		foreach (UIGameLevelDisplay gameLevelDisplay in _gameLevelDisplays)
		{
			gameLevelDisplay.NewButtonActive(gameLevel);
		}
	}

	private void DisplayTabContents(int tabNumber)
	{
		SetupScreenVariables(tabNumber);
		SetupLevelsInWorld(tabNumber);
		UIDoinklerFolderTab[] componentsInChildren = _folderTabButtonsContainer.GetComponentsInChildren<UIDoinklerFolderTab>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			componentsInChildren[i].NewTabActive(tabNumber);
		}
		SetFolderColor(tabNumber);
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

	private void SetupFolderTabs()
	{
		UIDoinklerFolderTab[] componentsInChildren = _folderTabButtonsContainer.GetComponentsInChildren<UIDoinklerFolderTab>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			componentsInChildren[i].Setup(this, i);
			componentsInChildren[i].NewTabActive(_currentWorldIndex);
		}
	}

	private void SetFolderColor(int fileNumber)
	{
		switch (fileNumber)
		{
		case 0:
		case 1:
			_folderBackground.color = _folderColorBeige;
			break;
		case 2:
		case 3:
			_folderBackground.color = _folderColorBlue;
			break;
		default:
			_folderBackground.color = _folderColorRed;
			break;
		}
	}

	private void SetupScreenVariables(int worldIndex)
	{
		_fileTitleText.text = _gameWorlds[worldIndex].WorldTitle;
		_currentWorldIndex = worldIndex;
	}

	private IEnumerator LoadAllDoinklerVariables()
	{
		Controls.Mode previousMode = _controls.GetControlMode();
		_controls.SetControlMode(Controls.Mode.Disabled);
		int progress = 0;
		int total = _gameWorlds.Count;
		foreach (GTWGameWorldDefinition gameWorld in _gameWorlds)
		{
			yield return ProcessSaveSlotLoading(gameWorld, () =>
			{
				progress++;
			});
		}
		while (progress < total)
		{
			yield return null;
		}
		SetupLevelsInWorld(0);
		_resetButtonAllowed = false;
		SetupResetButton();
		FolderTab_OnClick(_currentWorldIndex);
		_controls.SetControlMode(previousMode);
	}

	private IEnumerator ProcessSaveSlotLoading(GTWGameWorldDefinition gtwGameWorldDefinition, Action updateProgress)
	{
		int saveSlot = (int)gtwGameWorldDefinition.SaveSlotId;
		bool isProcessingComplete = false;
		_gameData.HasSaveData(saveSlot, (bool dataExists) =>
		{
			if (dataExists)
			{
				_gameData.LoadGameData(saveSlot, (bool success) =>
				{
					SetupGameLevelsData(gtwGameWorldDefinition.GameLevels, success);
					isProcessingComplete = true;
				});
			}
			else
			{
				SetupGameLevelsData(gtwGameWorldDefinition.GameLevels, loadFromSavedData: false);
				isProcessingComplete = true;
			}
		});
		while (!isProcessingComplete)
		{
			yield return null;
		}
		updateProgress?.Invoke();
	}

	private void SetupGameLevelsData(List<GTWGameLevelDefinition> gameLevels, bool loadFromSavedData)
	{
		foreach (GTWGameLevelDefinition gameLevel in gameLevels)
		{
			if (loadFromSavedData)
			{
				int attempts = _doinklerLevelVariables.GetInt(gameLevel.UniqueIDAttempts);
				float bestValue = _doinklerLevelVariables.GetFloat(gameLevel.UniqueIDBest);
				float totalValue = _doinklerLevelVariables.GetFloat(gameLevel.UniqueIDTotal);
				bool isCompleted = _doinklerLevelVariables.GetBool(gameLevel.UniqueIDCompleted);
				gameLevel.SetupSO(attempts, bestValue, totalValue, isCompleted);
			}
			else
			{
				gameLevel.SetupSO(0, 0f, 0f, isCompleted: false);
			}
		}
	}

	private void SetupLevelsInWorld(int worldIndex)
	{
		_gameLevelDisplays = new List<UIGameLevelDisplay>();
		GTWGameWorldDefinition gTWGameWorldDefinition = _gameWorlds[worldIndex];
		List<GTWGameLevelDefinition> gameLevels = gTWGameWorldDefinition.GameLevels;
		_ = gTWGameWorldDefinition.SaveSlotId;
		bool isUnlocked = true;
		foreach (GTWGameLevelDefinition item in gameLevels)
		{
			item.IsUnlocked = isUnlocked;
			isUnlocked = false;
			if (item.IsCompleted || AllLevelsUnlocked)
			{
				isUnlocked = true;
			}
		}
		for (int num = _levelSelectButtonsContainer.childCount - 1; num >= 0; num--)
		{
			UnityEngine.Object.Destroy(_levelSelectButtonsContainer.GetChild(num).gameObject);
		}
		for (int i = 0; i < gameLevels.Count; i++)
		{
			GTWGameLevelDefinition gTWGameLevelDefinition = gameLevels[i];
			UIGameLevelDisplay uIGameLevelDisplay = _container.InstantiatePrefabForComponent<UIGameLevelDisplay>(_levelSelectButtonPrefab, _levelSelectButtonsContainer);
			_gameLevelDisplays.Add(uIGameLevelDisplay);
			bool isUnlocked2 = false;
			if (i == 0)
			{
				isUnlocked2 = true;
			}
			else if (gTWGameLevelDefinition.IsCompleted)
			{
				isUnlocked2 = true;
			}
			else if (i > 0 && gameLevels[i - 1].IsCompleted)
			{
				isUnlocked2 = true;
			}
			gTWGameLevelDefinition.IsUnlocked = isUnlocked2;
			StartCoroutine(SetUpGameLevelDisplay(uIGameLevelDisplay, gTWGameLevelDefinition));
		}
		GTWGameLevelDefinition gameLevel = _gameWorlds[worldIndex].GameLevels[0];
		DisplayLevelInfo(gameLevel);
		StartCoroutine(SetupControllerNavigation());
	}

	private void SetupResetButton()
	{
		SetupResetButtonColors();
		if (!_gameState.IsInTitleScene())
		{
			return;
		}
		float num = 0f;
		foreach (GTWGameWorldDefinition gameWorld in _gameWorlds)
		{
			foreach (GTWGameLevelDefinition gameLevel in gameWorld.GameLevels)
			{
				float num2 = ((gameLevel.TotalTimeInLevel == "--") ? 0f : float.Parse(gameLevel.TotalTimeInLevel));
				num += num2;
			}
		}
		if (!num.Approx(0f))
		{
			_resetButtonAllowed = true;
			SetupResetButtonColors();
		}
	}

	private void SetupResetButtonColors()
	{
		ColorBlock colors = _freshStartButton.colors;
		if (_resetButtonAllowed)
		{
			colors.normalColor = _normalButtonColor;
		}
		else
		{
			colors.normalColor = _disabledButtonColor;
		}
		_freshStartButton.colors = colors;
	}

	private void HandleTabNavigation()
	{
		bool flag = false;
		bool flag2 = false;
		if (_controls.UsingJoystick() && EventSystem.current.currentSelectedGameObject != null)
		{
			Selectable component = EventSystem.current.currentSelectedGameObject.GetComponent<Selectable>();
			if (component != null)
			{
				if (_freshStartButton != null && _freshStartButton == component)
				{
					flag2 = true;
				}
				else
				{
					foreach (UIGameLevelDisplay gameLevelDisplay in _gameLevelDisplays)
					{
						CoreButton componentInChildren = gameLevelDisplay.GetComponentInChildren<CoreButton>();
						if (componentInChildren != null && componentInChildren == component)
						{
							flag = true;
							break;
						}
					}
					if (!flag && !flag2)
					{
						UIDoinklerFolderTab[] componentsInChildren = _folderTabButtonsContainer.GetComponentsInChildren<UIDoinklerFolderTab>();
						for (int i = 0; i < componentsInChildren.Length; i++)
						{
							CoreButton componentInChildren2 = componentsInChildren[i].GetComponentInChildren<CoreButton>();
							if (componentInChildren2 != null && componentInChildren2 == component)
							{
								break;
							}
						}
					}
				}
			}
		}
		int num;
		if (_controls.GetButtonDown(UserActions.UITABLEFT))
		{
			num = _currentWorldIndex - 1;
			if (num < 0)
			{
				num = _gameWorlds.Count - 1;
			}
		}
		else
		{
			num = _currentWorldIndex + 1;
			if (num >= _gameWorlds.Count)
			{
				num = 0;
			}
		}
		FolderTab_OnClick(num);
		if (flag || _doinklerPlayLevelButton.IsSelected)
		{
			StartCoroutine(SelectFirstLevelAfterTabSwitch());
		}
		else if (flag2)
		{
			StartCoroutine(SelectFreshStartButtonAfterTabSwitch());
		}
	}

	protected override void HighlightFallbackSelectable()
	{
		foreach (UIGameLevelDisplay gameLevelDisplay in _gameLevelDisplays)
		{
			CoreButton componentInChildren = gameLevelDisplay.GetComponentInChildren<CoreButton>();
			if (componentInChildren != null && componentInChildren.interactable)
			{
				_currentSelection = componentInChildren;
				_currentSelection.Select();
				return;
			}
		}
		UIDoinklerFolderTab[] componentsInChildren = _folderTabButtonsContainer.GetComponentsInChildren<UIDoinklerFolderTab>();
		if (componentsInChildren.Length > _currentWorldIndex && _currentWorldIndex >= 0)
		{
			CoreButton componentInChildren2 = componentsInChildren[_currentWorldIndex].GetComponentInChildren<CoreButton>();
			if (componentInChildren2 != null && componentInChildren2.interactable)
			{
				_currentSelection = componentInChildren2;
				_currentSelection.Select();
				return;
			}
		}
		if (_freshStartButton != null && _freshStartButton.gameObject.activeInHierarchy && _freshStartButton.interactable)
		{
			_currentSelection = _freshStartButton;
			_currentSelection.Select();
		}
	}

	private IEnumerator SetUpGameLevelDisplay(UIGameLevelDisplay gameLevelDisplay, GTWGameLevelDefinition gtwLevel)
	{
		gameLevelDisplay.Setup(gtwLevel, this);
		yield return null;
	}

	private IEnumerator SetupControllerNavigation()
	{
		yield return null;
		UIDoinklerFolderTab[] componentsInChildren = _folderTabButtonsContainer.GetComponentsInChildren<UIDoinklerFolderTab>();
		List<CoreButton> list = new List<CoreButton>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			if (componentsInChildren[i].gameObject.activeInHierarchy)
			{
				CoreButton componentInChildren = componentsInChildren[i].GetComponentInChildren<CoreButton>();
				if (componentInChildren != null && componentInChildren.interactable)
				{
					list.Add(componentInChildren);
				}
			}
		}
		List<CoreButton> list2 = new List<CoreButton>();
		foreach (UIGameLevelDisplay gameLevelDisplay in _gameLevelDisplays)
		{
			CoreButton componentInChildren2 = gameLevelDisplay.GetComponentInChildren<CoreButton>();
			if (componentInChildren2 != null && componentInChildren2.interactable)
			{
				list2.Add(componentInChildren2);
			}
		}
		CoreButton coreButton = null;
		if (_freshStartButton != null && _freshStartButton.gameObject.activeInHierarchy && _freshStartButton.interactable)
		{
			coreButton = _freshStartButton;
		}
		if (list.Count > 0)
		{
			for (int j = 0; j < list.Count; j++)
			{
				if (j > 0)
				{
					UIUtils.SetNavigation(list[j], UIUtils.NavigationDirection.Left, list[j - 1]);
				}
				else if (list.Count > 1)
				{
					UIUtils.SetNavigation(list[j], UIUtils.NavigationDirection.Left, list[list.Count - 1]);
				}
				if (j < list.Count - 1)
				{
					UIUtils.SetNavigation(list[j], UIUtils.NavigationDirection.Right, list[j + 1]);
				}
				else if (list.Count > 1)
				{
					UIUtils.SetNavigation(list[j], UIUtils.NavigationDirection.Right, list[0]);
				}
				if (list2.Count > 0)
				{
					UIUtils.SetNavigation(list[j], UIUtils.NavigationDirection.Down, list2[0]);
				}
				else if (coreButton != null)
				{
					UIUtils.SetNavigation(list[j], UIUtils.NavigationDirection.Down, coreButton);
				}
			}
		}
		if (list2.Count > 0)
		{
			for (int k = 0; k < list2.Count; k++)
			{
				if (k > 0)
				{
					UIUtils.SetNavigation(list2[k], UIUtils.NavigationDirection.Up, list2[k - 1]);
				}
				else
				{
					CoreButton coreButton2 = null;
					for (int l = 0; l < componentsInChildren.Length; l++)
					{
						if (l == _currentWorldIndex && componentsInChildren[l].gameObject.activeInHierarchy)
						{
							CoreButton componentInChildren3 = componentsInChildren[l].GetComponentInChildren<CoreButton>();
							if (componentInChildren3 != null && componentInChildren3.interactable)
							{
								coreButton2 = componentInChildren3;
								break;
							}
						}
					}
					if (coreButton2 != null)
					{
						UIUtils.SetNavigation(list2[k], UIUtils.NavigationDirection.Up, coreButton2);
					}
					else if (list.Count > 0)
					{
						UIUtils.SetNavigation(list2[k], UIUtils.NavigationDirection.Up, list[0]);
					}
				}
				if (k < list2.Count - 1)
				{
					UIUtils.SetNavigation(list2[k], UIUtils.NavigationDirection.Down, list2[k + 1]);
				}
				else if (coreButton != null)
				{
					UIUtils.SetNavigation(list2[k], UIUtils.NavigationDirection.Down, coreButton);
					UIUtils.SetNavigation(coreButton, UIUtils.NavigationDirection.Up, list2[k]);
				}
			}
		}
		else
		{
			if (!(coreButton != null) || list.Count <= 0)
			{
				yield break;
			}
			foreach (CoreButton item in list)
			{
				UIUtils.SetNavigation(item, UIUtils.NavigationDirection.Down, coreButton);
			}
			CoreButton coreButton3 = null;
			for (int m = 0; m < componentsInChildren.Length; m++)
			{
				if (m == _currentWorldIndex && componentsInChildren[m].gameObject.activeInHierarchy)
				{
					CoreButton componentInChildren4 = componentsInChildren[m].GetComponentInChildren<CoreButton>();
					if (componentInChildren4 != null && componentInChildren4.interactable)
					{
						coreButton3 = componentInChildren4;
						break;
					}
				}
			}
			if (coreButton3 != null)
			{
				UIUtils.SetNavigation(coreButton, UIUtils.NavigationDirection.Up, coreButton3);
			}
			else if (list.Count > 0)
			{
				UIUtils.SetNavigation(coreButton, UIUtils.NavigationDirection.Up, list[0]);
			}
		}
	}

	private IEnumerator UpdateFolderTabNavigation()
	{
		yield return null;
		yield return SetupControllerNavigation();
	}

	private IEnumerator SelectFirstLevelAfterTabSwitch()
	{
		yield return null;
		if (!_controls.UsingJoystick())
		{
			yield break;
		}
		foreach (UIGameLevelDisplay gameLevelDisplay in _gameLevelDisplays)
		{
			CoreButton componentInChildren = gameLevelDisplay.GetComponentInChildren<CoreButton>();
			if (componentInChildren != null && componentInChildren.interactable)
			{
				_currentSelection = componentInChildren;
				_currentSelection.Select();
				yield return SetupControllerNavigation();
				break;
			}
		}
	}

	private IEnumerator SelectFreshStartButtonAfterTabSwitch()
	{
		yield return null;
		if (_controls.UsingJoystick())
		{
			_freshStartButton.Select();
			yield return SetupControllerNavigation();
		}
	}

	private void RebindSpeedrunSettings()
	{
		DiContainer container = ProjectContext.Instance.Container;
		container.Rebind(typeof(SpeedrunSettings)).FromInstance(_doinklerSpeedrunSettings).AsCached()
			.NonLazy();
		container.Inject(_gameData);
	}

	private IEnumerator ClearAndSaveLevelData()
	{
		GTWGameWorldDefinition cachedWorldDefinition = _doinklerWorldDefinitionProvider.Current;
		Controls.Mode previousMode = _controls.GetControlMode();
		_controls.SetControlMode(Controls.Mode.Disabled);
		int progress = 0;
		int total = _gameWorlds.Count;
		foreach (GTWGameWorldDefinition gameWorld in _gameWorlds)
		{
			yield return ProcessWorldDataClearing(gameWorld, () =>
			{
				progress++;
			});
		}
		while (progress < total)
		{
			yield return null;
		}
		_doinklerWorldDefinitionProvider.Current = cachedWorldDefinition;
		_controls.SetControlMode(previousMode);
		FinalizeDataClearing();
	}

	private IEnumerator ProcessWorldDataClearing(GTWGameWorldDefinition gameWorld, Action updateProgress)
	{
		int saveSlot = (int)gameWorld.SaveSlotId;
		_doinklerWorldDefinitionProvider.Current = gameWorld;
		_gameState.SaveSlot = saveSlot;
		bool isProcessingComplete = false;
		_gameData.HasSaveData(saveSlot, (bool dataExists) =>
		{
			if (dataExists)
			{
				ProcessExistingSaveData(gameWorld, saveSlot, () =>
				{
					isProcessingComplete = true;
				});
			}
			else
			{
				Debug.Log($"Save Slot {saveSlot} doesn't exist: false");
				isProcessingComplete = true;
			}
		});
		while (!isProcessingComplete)
		{
			yield return null;
		}
		updateProgress?.Invoke();
	}

	private void ProcessExistingSaveData(GTWGameWorldDefinition gameWorld, int saveSlot, Action onComplete)
	{
		_gameData.LoadGameData(saveSlot, (bool success) =>
		{
			if (success)
			{
				ClearLevelDataForWorld(gameWorld);
				ClearGlobalLevelVariables();
				Debug.Log($"Save Slot {saveSlot} has been cleared.");
				_gameState.CurrentGameMode = gameWorld.GameLevels[0].gameMode;
				_gameData.SaveGameData(saveSlot, createBackup: false, (bool _) =>
				{
					Debug.Log($"Updating Save Data for saveslot {saveSlot}");
					onComplete?.Invoke();
				});
			}
			else
			{
				onComplete?.Invoke();
			}
		});
	}

	private void ClearLevelDataForWorld(GTWGameWorldDefinition gameWorld)
	{
		foreach (GTWGameLevelDefinition gameLevel in gameWorld.GameLevels)
		{
			ResetLevelVariables(gameLevel);
		}
	}

	private void ResetLevelVariables(GTWGameLevelDefinition levelDefinition)
	{
		int num = 0;
		float num2 = 0f;
		bool flag = false;
		float bestValue = _doinklerLevelVariables.GetFloat(levelDefinition.UniqueIDBest);
		_doinklerLevelVariables.SetInt(levelDefinition.UniqueIDAttempts, num);
		_doinklerLevelVariables.SetFloat(levelDefinition.UniqueIDTotal, num2);
		_doinklerLevelVariables.SetBool(levelDefinition.UniqueIDCompleted, flag);
		levelDefinition.SetupSO(num, bestValue, num2, flag);
	}

	private void ClearGlobalLevelVariables()
	{
		_levelVariables.boolVariables.Clear();
		_levelVariables.intVariables.Clear();
		_levelVariables.floatVariables.Clear();
	}

	private void FinalizeDataClearing()
	{
		RebindSpeedrunSettings();
		_currentWorldIndex = 0;
		_selectedLevel = _gameWorlds[0].GameLevels[0];
		DisplayTabContents(_currentWorldIndex);
	}
}
