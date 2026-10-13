using System;
using System.Collections;
using System.Collections.Generic;
using I2.Loc;
using Isto.Core.Data;
using Isto.Core.Game;
using Isto.Core.Inputs;
using Isto.Core.Localization;
using Isto.Core.StateMachine;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;

namespace Isto.Core.UI;

public class CoreUISetSaveSlotSubState : MonoState, IStateExitResult
{
	public enum MenuMode
	{
		Save = 0,
		Load = 1
	}

	[SerializeField]
	private LocalizedString _gameSavedMessageKey;

	[SerializeField]
	private LocalizedString _loadGameTitleKey;

	[SerializeField]
	private LocalizedString _saveGameTitleKey;

	[SerializeField]
	private LocalizedString _slotCountKey;

	[SerializeField]
	private TextMeshProUGUI _titleLabel;

	[SerializeField]
	private CanvasGroup _canvasGroup;

	[SerializeField]
	private TextMeshProUGUI _spaceRemainingLabel;

	[SerializeField]
	private CoreUISaveSlotList _saveSlotsList;

	[SerializeField]
	private TMP_Text _saveSlotCountLabel;

	[SerializeField]
	private CoreUISaveSlotDisplay _saveSlotDisplay;

	[SerializeField]
	private Button _exitAreaButton;

	[Header("File Renaming")]
	[SerializeField]
	private TextMeshProUGUI _renameMessageText;

	[SerializeField]
	private float _timeToShowRenameMessage = 3f;

	private MonoPushdownStateMachine _mainMenu;

	private MenuMode _currentMode;

	private float _spamTimer;

	private int _currentSelectedSaveSlotNumber = -1;

	private bool _open;

	private IControls _controls;

	private IUIMessages _uiMessages;

	private IGameData _gameData;

	private GameState _gameState;

	public IStateExitResult.ResultType Result { get; private set; }

	[Inject]
	public void Inject(IControls controls, [Inject(Optional = true, Id = UIMessageHandlerType.Message)] IUIMessages uIMessages, IGameData gameData, GameState gameState)
	{
		_controls = controls;
		_uiMessages = uIMessages;
		_gameData = gameData;
		_gameState = gameState;
	}

	public void Awake()
	{
		_exitAreaButton.interactable = false;
	}

	public override void Enter(MonoStateMachine controller)
	{
		_mainMenu = controller as MonoPushdownStateMachine;
		_spamTimer = Constants.CANVAS_FADE_TIME;
		_open = true;
		EventSystem.current.SetSelectedGameObject(null);
		RefreshSaveList();
		StartCoroutine(UIUtils.SetCanvasAlpha(_canvasGroup, 1f, Constants.CANVAS_FADE_TIME, interactable: true));
		StartCoroutine(UpdateFileSpaceLabel());
		_controls.DisableControls(Constants.BUTTON_SPAM_DELAY);
	}

	public override void Exit(MonoStateMachine controller)
	{
		_open = false;
		_exitAreaButton.interactable = false;
		StopAllCoroutines();
		_saveSlotsList.ClearListItems();
		if (Controls.UsingController)
		{
			EventSystem.current.SetSelectedGameObject(null);
		}
		StartCoroutine(UIUtils.SetCanvasAlpha(_canvasGroup, 0f, Constants.CANVAS_FADE_TIME, interactable: false));
		_controls.DisableControls(Constants.BUTTON_SPAM_DELAY);
		_renameMessageText.enabled = false;
	}

	public override void ReturnFromSubState(MonoStateMachine controller, MonoState previousState)
	{
		if (previousState is IStateExitResult stateExitResult)
		{
			Debug.Log("Coming back from Upgrade Menu, choice: " + stateExitResult.Result);
			switch (stateExitResult.Result)
			{
			case IStateExitResult.ResultType.Submit:
			case IStateExitResult.ResultType.Error:
				RefreshSaveList(_currentSelectedSaveSlotNumber);
				break;
			default:
				Debug.LogError($"UISetSaveSlotSubState.ReturnFromSubState: Unhandled IStateExitResult.ResultType \"{stateExitResult.Result}\" from previousState of type {previousState.GetType()} on object {previousState.name}");
				break;
			case IStateExitResult.ResultType.Cancelled:
				break;
			}
			_saveSlotDisplay.RestorePreviousSelection();
		}
	}

	public override MonoState Run(MonoStateMachine controller)
	{
		if (_controls.GetButtonDown(UserActions.UICANCEL) && !_saveSlotDisplay.IsBlockingForPopup)
		{
			Result = IStateExitResult.ResultType.Cancelled;
			_mainMenu.ExitSubState();
		}
		_spamTimer -= Time.unscaledDeltaTime;
		if (_spamTimer < 0f)
		{
			_exitAreaButton.interactable = true;
		}
		return this;
	}

	private IEnumerator UpdateFileSpaceLabel()
	{
		long freeBytes = 0L;
		long maxBytes = 0L;
		short blocking = 2;
		_gameData.GetRemainingSaveFileSpace((long bytes) =>
		{
			freeBytes = bytes;
			blocking--;
		});
		_gameData.GetMaximumSaveFileSpace((long bytes) =>
		{
			maxBytes = bytes;
			blocking--;
		});
		while (blocking > 0)
		{
			yield return null;
		}
		_spaceRemainingLabel.text = Loc.GetFileSizeLocalizedAndFormated(freeBytes) + " free of " + Loc.GetFileSizeLocalizedAndFormated(maxBytes);
	}

	public void SetMenuMode(MenuMode mode)
	{
		_currentMode = mode;
		if (_titleLabel != null && string.IsNullOrEmpty(_loadGameTitleKey.mTerm) && string.IsNullOrEmpty(_saveGameTitleKey.mTerm))
		{
			Loc.SetTMPro(_titleLabel, (mode == MenuMode.Load) ? _loadGameTitleKey : _saveGameTitleKey);
		}
	}

	public void SaveOrLoadButtonClicked(int slotNumber)
	{
		_controls.DisableControls(Constants.BUTTON_SPAM_DELAY);
		Result = IStateExitResult.ResultType.Submit;
		switch (_currentMode)
		{
		case MenuMode.Save:
			_gameData.SaveGameData(slotNumber, createBackup: true, (bool success) =>
			{
				if (!success)
				{
					Debug.LogError($"SaveGameData for slot#{slotNumber} has failed ");
				}
				else
				{
					Events.RaiseEvent("GameSaved");
					ShowGameSavedConfirmationMessage();
					_mainMenu.ExitSubState();
					_gameData.LoadGameMetaData(slotNumber, (GameStateSaveData metaData) =>
					{
						if (metaData == null)
						{
							Debug.LogError($"LoadSaveSlotMetaData for slot#{slotNumber}, right after saving it, has failed ");
						}
						else if (metaData.isAutoSave)
						{
							metaData.isAutoSave = false;
							_gameData.SaveGameMetaData(slotNumber, metaData, (bool saveSuccess) =>
							{
								if (!saveSuccess)
								{
									Debug.LogWarning($"SaveGameMetaData for slot#{slotNumber} has failed to save metadata after turning the autosave flag OFF ");
								}
							});
						}
					});
				}
			});
			break;
		case MenuMode.Load:
			_gameData.HasSaveData(slotNumber, (bool dataExists) =>
			{
				if (dataExists)
				{
					_mainMenu.ExitSubState();
					_gameState.LoadSaveGame(slotNumber);
				}
			});
			break;
		}
	}

	public void ShowGameSavedConfirmationMessage()
	{
		if (_uiMessages != null)
		{
			_uiMessages.CreateMessage(Loc.Get(_gameSavedMessageKey));
		}
	}

	public void ExitAreaClicked()
	{
		Result = IStateExitResult.ResultType.Cancelled;
		_mainMenu.ExitSubState();
	}

	public void RefreshSaveList(int selectedSlot = -1, Action callback = null)
	{
		if (_saveSlotsList == null)
		{
			return;
		}
		_saveSlotsList.SetSlotMenuMode(_currentMode);
		_saveSlotsList.ClearListItems();
		_gameData.GetAllExistingSaveSlots((List<int> slots) =>
		{
			if (_open)
			{
				int readySlots = 0;
				if (slots.Count == 0)
				{
					_saveSlotsList.NewSaveFileButton.Select();
				}
				foreach (int slot in slots)
				{
					_saveSlotsList.SetupSaveSlot(slot, slot == selectedSlot, () =>
					{
						if (_open)
						{
							readySlots++;
							if (readySlots >= slots.Count)
							{
								StartCoroutine(DelayedRebuildNavigation(selectedSlot == -1));
							}
						}
					});
				}
				_saveSlotCountLabel.text = $"({Loc.Get(_slotCountKey)} {slots.Count}/{_gameData.MaximumSaveSlots})";
			}
		});
		callback?.Invoke();
	}

	private IEnumerator DelayedRebuildNavigation(bool resetSelection)
	{
		yield return null;
		if (_open)
		{
			_saveSlotsList.RebuildNavigation();
			if (resetSelection)
			{
				_saveSlotsList.SelectFirstSlot();
				Vector2 anchoredPosition = _saveSlotsList.RectTransform.anchoredPosition;
				anchoredPosition.y = 0f;
				_saveSlotsList.RectTransform.anchoredPosition = anchoredPosition;
			}
		}
	}

	public void SetCurrentSelectedSaveSlot(int slotNumber)
	{
		_currentSelectedSaveSlotNumber = slotNumber;
	}

	public void ShowRenameTextMessage()
	{
		StartCoroutine(ShowRenameRoutine());
	}

	private IEnumerator ShowRenameRoutine()
	{
		_renameMessageText.enabled = true;
		yield return new WaitForSecondsRealtime(_timeToShowRenameMessage);
		_renameMessageText.enabled = false;
	}

	public void OnTextFieldSubmit()
	{
		if (_currentSelectedSaveSlotNumber != -1)
		{
			_ = _currentMode;
		}
	}

	private void EnableExitZoneButton()
	{
		_exitAreaButton.interactable = true;
	}
}
