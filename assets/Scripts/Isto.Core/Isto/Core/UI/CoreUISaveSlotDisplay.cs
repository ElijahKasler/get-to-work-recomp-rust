using System;
using System.Collections;
using I2.Loc;
using Isto.Core.Configuration;
using Isto.Core.Data;
using Isto.Core.Game;
using Isto.Core.Inputs;
using Isto.Core.Localization;
using Isto.Core.StateMachine;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Zenject;

namespace Isto.Core.UI;

public class CoreUISaveSlotDisplay : MonoBehaviour
{
	[SerializeField]
	private CoreUISetSaveSlotSubState _parentMenu;

	[SerializeField]
	private RawImage _thumbnailDisplay;

	[SerializeField]
	private CoreButtonController _deleteButton;

	[FormerlySerializedAs("_slotButton")]
	[SerializeField]
	private CoreButtonController _saveOrLoadButton;

	[SerializeField]
	private TextMeshProUGUI buttonTextBox;

	[SerializeField]
	private Color _noSaveColor = new Color(101f, 59f, 59f, 256f);

	[SerializeField]
	private Settings _settings;

	[SerializeField]
	private LocalizedString _loadGameButtonKey;

	[SerializeField]
	private LocalizedString _saveGameButtonKey;

	[SerializeField]
	private LocalizedString _noDataButtonKey;

	[SerializeField]
	private LocalizedString _versionLabelKey;

	[SerializeField]
	private LocalizedString _playTimeLabelKey;

	[SerializeField]
	private LocalizedString _saveSlotNbLabelKey;

	[SerializeField]
	private LocalizedString _noSlotSelectedMsgKey;

	[SerializeField]
	private LocalizedString _overwriteSaveKey;

	[Header("Optional info fields")]
	[SerializeField]
	private TMP_InputField _saveFileName;

	[SerializeField]
	private TextMeshProUGUI _version;

	[SerializeField]
	private TextMeshProUGUI _playTime;

	[SerializeField]
	private TextMeshProUGUI _slotNumberLabel;

	[SerializeField]
	private TextMeshProUGUI _descriptiveName;

	[SerializeField]
	private TextMeshProUGUI _timeStamp;

	[Header("Optional Save Slot Deletion Confirmation Popup")]
	[SerializeField]
	private CanvasGroup _deleteSlotConfirmationDialog;

	[SerializeField]
	private Selectable _dialogDefaultSelection;

	[Header("Save Upgrade Sub Menu")]
	[SerializeField]
	private CoreUIUpgradeSaveSlotSubState _saveUpgradeSubMenu;

	[Header("Optional Features")]
	[SerializeField]
	private bool _thumbnailSupport = true;

	private int _slotNumber;

	private GameStateSaveData _metaData;

	private CoreUISetSaveSlotSubState.MenuMode _currentMode;

	private CoreButtonController _previousSelection;

	private Texture _originalThumbnailTexture;

	private IGameData _gameData;

	private GameState _gameState;

	private MonoPushdownStateMachine _menuController;

	private IControls _controls;

	public bool IsBlockingForPopup { get; private set; }

	[Inject]
	public void Inject(IGameData gameData, GameState gameState, [Inject(Optional = true)] SimpleGameMenuStateMachine inGameMenu, [Inject(Optional = true)] SimpleTitleMenuStateMachine titleMenuController, IControls controls)
	{
		_gameData = gameData;
		_gameState = gameState;
		_menuController = ((inGameMenu != null) ? ((MonoPushdownStateMachine)inGameMenu) : ((MonoPushdownStateMachine)titleMenuController));
		if (_menuController == null)
		{
			Debug.LogError("No menu controller found for UISaveSlotDisplay.");
		}
		_controls = controls;
	}

	private void Awake()
	{
		_slotNumber = base.transform.GetSiblingIndex();
		_originalThumbnailTexture = _thumbnailDisplay.texture;
	}

	private void OnEnable()
	{
		_saveFileName?.onValueChanged.AddListener(OnSaveSlotNameChanged);
		_saveFileName?.onSubmit.AddListener(OnSaveSlotNameSubmit);
	}

	private void OnDisable()
	{
		_saveFileName?.onValueChanged.RemoveListener(OnSaveSlotNameChanged);
		_saveFileName?.onSubmit.RemoveListener(OnSaveSlotNameSubmit);
	}

	private void LateUpdate()
	{
		if (_controls.GetButtonDown(UserActions.UICANCEL) && IsBlockingForPopup)
		{
			OnDeleteSlotCancelButton();
		}
	}

	private void OnSaveSlotNameChanged(string newName)
	{
		if (newName.Length > _settings.MaxCharactersInSaveName)
		{
			_saveFileName.SetTextWithoutNotify(newName.Substring(0, _settings.MaxCharactersInSaveName));
		}
	}

	private void OnSaveSlotNameSubmit(string newName)
	{
		_descriptiveName.text = newName;
		bool isRename = _metaData.saveSlotName != newName;
		_metaData.saveSlotName = newName;
		_metaData.isAutoSave = false;
		_gameData.SaveGameMetaData(_slotNumber, _metaData, (bool success) =>
		{
			Debug.Log(string.Format("UpdateSaveSlotMetaData {0} update data for slot#{1}", success ? "successfully" : "failed to", _slotNumber));
			_parentMenu.RefreshSaveList(_slotNumber);
			if (isRename)
			{
				_parentMenu.ShowRenameTextMessage();
			}
		});
	}

	private void OnUpgradeSaveChosen()
	{
		Debug.Log("Time to upgrade save");
	}

	public void SlotButtonClicked()
	{
		if (_slotNumber < 0)
		{
			return;
		}
		DoesSaveNeedUpgrade(_metaData, (bool needsUpgrade, string upgradeSaveVersion) =>
		{
			if ((_currentMode == CoreUISetSaveSlotSubState.MenuMode.Load) & needsUpgrade)
			{
				Debug.Log("This save needs upgrading");
				_previousSelection = _saveOrLoadButton;
				_saveUpgradeSubMenu.SetSaveSlot(_slotNumber, upgradeSaveVersion);
				_menuController.EnterSubState(_saveUpgradeSubMenu);
			}
			else
			{
				if (_currentMode == CoreUISetSaveSlotSubState.MenuMode.Save)
				{
					_metaData.saveSlotName = _saveFileName.text;
					_gameData.SaveGameMetaData(_slotNumber, _metaData, (bool success) =>
					{
						Debug.Log(string.Format("UpdateSaveSlotMetaData {0} update data for slot#{1}", success ? "successfully" : "failed to", _slotNumber));
					});
				}
				_gameState.LoadSaveSlotMetaData(_slotNumber, (bool metaData) =>
				{
					_parentMenu.SaveOrLoadButtonClicked(_slotNumber);
				});
			}
		});
	}

	public void DeleteSlotButtonClicked()
	{
		if (_slotNumber >= 0)
		{
			_previousSelection = _deleteButton;
			if (_deleteSlotConfirmationDialog != null)
			{
				OpenDeleteSlotDialog();
			}
			else
			{
				DeleteSaveSlot();
			}
		}
	}

	public void OnDeleteSlotConfirmButton()
	{
		CloseDeleteSlotDialog();
		DeleteSaveSlot();
	}

	public void OnDeleteSlotCancelButton()
	{
		CloseDeleteSlotDialog();
		if (_saveOrLoadButton != null && Controls.UsingController)
		{
			_saveOrLoadButton.Select();
		}
	}

	public IEnumerator SetupSaveSlot(int slotnumber, CoreUISetSaveSlotSubState.MenuMode mode, GameStateSaveData metaData)
	{
		_currentMode = mode;
		_metaData = metaData;
		_slotNumber = slotnumber;
		bool hasSaveData = false;
		if (_slotNumber >= 0)
		{
			bool waitingForThumb = true;
			if (_thumbnailSupport)
			{
				_gameData.LoadThumbnailForSaveSlot(_slotNumber, (Texture2D thumb) =>
				{
					if (_thumbnailDisplay.texture != null && _thumbnailDisplay.texture != _originalThumbnailTexture)
					{
						UnityEngine.Object.Destroy(_thumbnailDisplay.texture);
					}
					_thumbnailDisplay.texture = thumb;
					waitingForThumb = false;
				});
			}
			else
			{
				waitingForThumb = false;
			}
			bool waitingForSaveData = true;
			_gameData.HasSaveData(_slotNumber, (bool has) =>
			{
				hasSaveData = has;
				waitingForSaveData = false;
			});
			while (waitingForThumb | waitingForSaveData)
			{
				yield return null;
			}
		}
		_thumbnailDisplay.color = (hasSaveData ? Color.white : _noSaveColor);
		if (hasSaveData)
		{
			_saveOrLoadButton.SetEnabled();
		}
		else
		{
			_saveOrLoadButton.SetDisabled();
		}
		if (_metaData != null)
		{
			if (_saveFileName != null)
			{
				Loc.SetTMProFont(_saveFileName);
				_saveFileName.SetTextWithoutNotify(_metaData.saveSlotName);
			}
			if (_version != null)
			{
				Loc.SetTMProLocalized(_version, Loc.Get(_versionLabelKey) + " " + _metaData.gameVersion);
			}
			if (_playTime != null)
			{
				Loc.SetTMProLocalized(_playTime, Loc.Get(_playTimeLabelKey) + Loc.GetTimeLocalizedAndFormated(_metaData.totalGameTimeSeconds));
			}
			if (_slotNumberLabel != null)
			{
				Loc.SetTMProLocalized(_slotNumberLabel, $"{Loc.Get(_saveSlotNbLabelKey)} {_slotNumber}");
			}
			if (_descriptiveName != null)
			{
				Loc.SetTMProLocalized(_descriptiveName, _metaData.saveSlotName);
			}
			if (_timeStamp != null)
			{
				_timeStamp.text = _metaData.saveDate.ToString("HH:mm:ss tt, MMM d, yyyy");
			}
		}
		else
		{
			if (_saveFileName != null)
			{
				Loc.SetTMProFont(_saveFileName);
				_saveFileName.SetTextWithoutNotify(Loc.Get(_noSlotSelectedMsgKey));
			}
			if (_version != null)
			{
				Loc.SetTMProLocalized(_version, Loc.Get(_versionLabelKey) + " ---");
			}
			if (_playTime != null)
			{
				Loc.SetTMProLocalized(_playTime, Loc.Get(_playTimeLabelKey) + " ---");
			}
			if (_slotNumberLabel != null)
			{
				Loc.SetTMProLocalized(_slotNumberLabel, Loc.Get(_saveSlotNbLabelKey) + " ---");
			}
			if (_descriptiveName != null)
			{
				_descriptiveName.text = "";
			}
			if (_timeStamp != null)
			{
				_timeStamp.text = "";
			}
		}
		switch (mode)
		{
		case CoreUISetSaveSlotSubState.MenuMode.Save:
			_saveFileName.enabled = true;
			if (hasSaveData)
			{
				SetSaveButtonText(slotnumber, metaData);
			}
			break;
		case CoreUISetSaveSlotSubState.MenuMode.Load:
			if (hasSaveData)
			{
				Loc.SetTMPro(buttonTextBox, _loadGameButtonKey);
			}
			else
			{
				Loc.SetTMPro(buttonTextBox, _noDataButtonKey);
			}
			_saveFileName.enabled = false;
			break;
		default:
			Debug.LogWarning($"No handler for menu mode {mode}");
			break;
		}
	}

	public void SetSaveButtonText(int slotnumber, GameStateSaveData metaData)
	{
		if (_gameState.IsCurrentlyLoadedSaveGame(metaData, slotnumber))
		{
			Loc.SetTMPro(buttonTextBox, _saveGameButtonKey);
		}
		else
		{
			Loc.SetTMPro(buttonTextBox, _overwriteSaveKey);
		}
	}

	public void RestorePreviousSelection()
	{
		_previousSelection.Select();
	}

	private void DoesSaveNeedUpgrade(GameStateSaveData metaData, Action<bool, string> onResult)
	{
		_gameData.HasSaveData(_slotNumber, (bool hasSaveData) =>
		{
			bool arg = false;
			string versionToUpgradeTo;
			if (!hasSaveData)
			{
				versionToUpgradeTo = "";
			}
			else
			{
				arg = IsSaveOutOfDate(metaData, out versionToUpgradeTo);
			}
			onResult?.Invoke(arg, versionToUpgradeTo);
		});
	}

	protected virtual bool IsSaveOutOfDate(GameStateSaveData gameStateData, out string versionToUpgradeTo)
	{
		versionToUpgradeTo = "";
		return false;
	}

	private void OpenDeleteSlotDialog()
	{
		IsBlockingForPopup = true;
		_deleteSlotConfirmationDialog.alpha = 1f;
		_deleteSlotConfirmationDialog.interactable = true;
		_deleteSlotConfirmationDialog.blocksRaycasts = true;
		if (_dialogDefaultSelection != null && Controls.UsingController)
		{
			_dialogDefaultSelection.Select();
		}
	}

	private void CloseDeleteSlotDialog()
	{
		IsBlockingForPopup = false;
		_deleteSlotConfirmationDialog.alpha = 0f;
		_deleteSlotConfirmationDialog.interactable = false;
		_deleteSlotConfirmationDialog.blocksRaycasts = false;
	}

	private void DeleteSaveSlot()
	{
		_gameData.ClearSaveData(_slotNumber, (bool _) =>
		{
			_parentMenu.RefreshSaveList();
		});
	}
}
