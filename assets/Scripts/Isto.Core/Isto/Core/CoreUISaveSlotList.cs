using System;
using System.Collections.Generic;
using I2.Loc;
using Isto.Core.Data;
using Isto.Core.Game;
using Isto.Core.Inputs;
using Isto.Core.Localization;
using Isto.Core.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Isto.Core;

public class CoreUISaveSlotList : MonoBehaviour
{
	[Header("UI rig references")]
	[SerializeField]
	private CoreUISetSaveSlotSubState _parentMenu;

	[SerializeField]
	private CoreUISaveSlotDisplay _selectedSaveSlotDisplay;

	[SerializeField]
	private Button _newSaveSlotButton;

	[SerializeField]
	private Button _deleteButton;

	[SerializeField]
	private Button _saveLoadButton;

	[SerializeField]
	private TMP_InputField _saveRenameField;

	[Header("Prefabs")]
	[SerializeField]
	private CoreUISaveSlotListItem _slotListItemPrefab;

	[Header("Loc Keys")]
	[SerializeField]
	private LocalizedString _emptySlotNameKey;

	[SerializeField]
	private LocalizedString _defaultSlotNameKey;

	[SerializeField]
	private LocalizedString _newSlotNameKey;

	private List<CoreUISaveSlotListItem> _slotList;

	private CoreUISetSaveSlotSubState.MenuMode _currentMode;

	private bool _waitingForSaves;

	private IGameData _gameData;

	private GameState _gameState;

	private DiContainer _container;

	public RectTransform RectTransform => base.transform as RectTransform;

	public TMP_InputField SaveRenameField => _saveRenameField;

	public Button NewSaveFileButton => _newSaveSlotButton;

	[Inject]
	public void Inject(IGameData gameData, GameState gameState, DiContainer container)
	{
		_gameData = gameData;
		_gameState = gameState;
		_container = container;
	}

	private void Awake()
	{
		_slotList = new List<CoreUISaveSlotListItem>(base.gameObject.GetComponentsInChildren<CoreUISaveSlotListItem>());
	}

	public void ClearListItems()
	{
		foreach (CoreUISaveSlotListItem slot in _slotList)
		{
			slot.GetComponent<UISelectableListButton>().OnSelected -= OnSlotButtonClicked;
			UnityEngine.Object.Destroy(slot.gameObject);
		}
		_slotList.Clear();
		StartCoroutine(_selectedSaveSlotDisplay.SetupSaveSlot(-1, _currentMode, null));
	}

	public void SetSlotMenuMode(CoreUISetSaveSlotSubState.MenuMode mode)
	{
		_currentMode = mode;
		_newSaveSlotButton.gameObject.SetActive(_currentMode == CoreUISetSaveSlotSubState.MenuMode.Save);
	}

	public void SetupSaveSlot(int slotnumber, bool selected = false, Action onFinished = null)
	{
		_gameData.LoadGameMetaData(slotnumber, (GameStateSaveData metaData) =>
		{
			bool dataChanged = false;
			bool setTemporaryNewFileName = false;
			if (metaData == null)
			{
				metaData = new GameStateSaveData();
				dataChanged = true;
				setTemporaryNewFileName = true;
				metaData.gameModeName = "---";
				metaData.gameVersion = _gameState.version.ActiveVersion.VersionText;
				metaData.internalBuildVersion = "";
				metaData.saveDate = DateTime.Now;
			}
			_gameData.HasSaveData(slotnumber, (bool hasSaveData) =>
			{
				Transform transform = base.transform;
				CoreUISaveSlotListItem coreUISaveSlotListItem = _container.InstantiatePrefabForComponent<CoreUISaveSlotListItem>(_slotListItemPrefab, base.transform);
				_slotList.Add(coreUISaveSlotListItem);
				if (_slotList.Count >= _gameData.MaximumSaveSlots)
				{
					_newSaveSlotButton.gameObject.SetActive(value: false);
				}
				UISelectableListButton component = coreUISaveSlotListItem.GetComponent<UISelectableListButton>();
				component.OnSelected += OnSlotButtonClicked;
				if (selected)
				{
					_selectedSaveSlotDisplay.SetSaveButtonText(slotnumber, metaData);
					if (component != null && !component.IsSelected)
					{
						component.Selected();
					}
					else
					{
						Debug.LogWarning("Navigation component UISelectableListButton was expected but missing on UISaveSlotListItem prefab", coreUISaveSlotListItem.gameObject);
					}
				}
				if (!hasSaveData)
				{
					if (string.IsNullOrEmpty(metaData.saveSlotName))
					{
						metaData.saveSlotName = $"{Loc.Get(_emptySlotNameKey)}{slotnumber}";
					}
					metaData.gameModeName = "---";
					metaData.gameVersion = _gameState.version.ActiveVersion.VersionText;
					metaData.internalBuildVersion = _gameState.version.ActiveVersion.shortDate;
					metaData.saveDate = DateTime.Now;
					if (setTemporaryNewFileName)
					{
						metaData.gameModeName = (_gameState.CurrentGameMode ? _gameState.CurrentGameMode.InternalName : "---");
						metaData.saveSlotName = $"{Loc.Get(_newSlotNameKey)}{slotnumber}";
					}
				}
				else
				{
					if (string.IsNullOrEmpty(metaData.saveSlotName))
					{
						metaData.saveSlotName = $"{Loc.Get(_defaultSlotNameKey)}{slotnumber}";
						dataChanged = true;
					}
					if (string.IsNullOrEmpty(metaData.gameModeName))
					{
						metaData.gameModeName = "---";
						dataChanged = true;
					}
					if (string.IsNullOrEmpty(metaData.gameVersion))
					{
						metaData.gameVersion = _gameState.version.ActiveVersion.VersionText;
						dataChanged = true;
					}
				}
				if (metaData.isAutoSave)
				{
					int num = 0;
					foreach (Transform item in transform)
					{
						num++;
						CoreUISaveSlotListItem component2 = item.GetComponent<CoreUISaveSlotListItem>();
						if (!(component2 != null) || component2.MetaData == null || !component2.MetaData.isAutoSave || !(component2.MetaData.saveDate > metaData.saveDate))
						{
							break;
						}
					}
					coreUISaveSlotListItem.transform.SetParent(transform, worldPositionStays: false);
					coreUISaveSlotListItem.transform.SetSiblingIndex(num - 1);
				}
				else
				{
					int num2 = 0;
					foreach (Transform item2 in transform)
					{
						num2++;
						CoreUISaveSlotListItem component3 = item2.GetComponent<CoreUISaveSlotListItem>();
						if (!(component3 != null) || component3.MetaData == null || (!component3.MetaData.isAutoSave && !(component3.MetaData.saveDate > metaData.saveDate)))
						{
							coreUISaveSlotListItem.transform.SetParent(transform, worldPositionStays: false);
							coreUISaveSlotListItem.transform.SetSiblingIndex(num2 - 1);
							break;
						}
					}
				}
				coreUISaveSlotListItem.SetupSaveSlot(slotnumber, metaData);
				if (selected)
				{
					coreUISaveSlotListItem.Select();
					SlotButtonClicked(coreUISaveSlotListItem);
				}
				if (dataChanged)
				{
					_gameData.SaveGameMetaData(slotnumber, metaData, (bool success) =>
					{
						Debug.Log(string.Format("UpdateSaveSlotMetaData {0} update data for slot#{1}", success ? "successfully" : "failed to", slotnumber));
					});
				}
				onFinished?.Invoke();
			});
		});
	}

	[ContextMenu("RebuildNavigation")]
	public void RebuildNavigation()
	{
		Transform transform = base.transform;
		for (int i = 0; i < transform.childCount; i++)
		{
			Transform child = transform.GetChild(i);
			UISelectableListButton component = child.GetComponent<UISelectableListButton>();
			if (component != null)
			{
				Button button = component.Button;
				UIUtils.SetNavigation(button, UIUtils.NavigationDirection.Right, _saveLoadButton);
				if (i == 0 && _newSaveSlotButton.isActiveAndEnabled)
				{
					UIUtils.SetNavigation(button, UIUtils.NavigationDirection.Up, _newSaveSlotButton);
					UIUtils.SetNavigation(_newSaveSlotButton, UIUtils.NavigationDirection.Down, button);
				}
				else if (i != 0 && transform.childCount > 1)
				{
					transform.GetChild(i - 1).GetComponent<UISelectableListButton>().LinkForNavigation(component);
				}
			}
			else
			{
				Debug.LogWarning("Navigation component UISelectableListButton was expected but missing on UISaveSlotListItem prefab", child.gameObject);
			}
		}
	}

	public void SelectFirstSlot()
	{
		if (base.transform.childCount > 0)
		{
			Transform child = base.transform.GetChild(0);
			if (Controls.UsingController && child.gameObject.activeSelf)
			{
				child.GetComponent<Button>().Select();
			}
			CoreUISaveSlotListItem component = base.transform.GetChild(0).GetComponent<CoreUISaveSlotListItem>();
			if (!(component == null))
			{
				SlotButtonClicked(component);
			}
		}
	}

	public void SlotButtonClicked(CoreUISaveSlotListItem slot)
	{
		StartCoroutine(_selectedSaveSlotDisplay.SetupSaveSlot(slot.SlotNumber, _currentMode, slot.MetaData));
		_parentMenu.SetCurrentSelectedSaveSlot(slot.SlotNumber);
		Button component = slot.GetComponent<Button>();
		UIUtils.SetNavigation(_saveLoadButton, UIUtils.NavigationDirection.Left, component);
		UIUtils.SetNavigation(_deleteButton, UIUtils.NavigationDirection.Left, component);
		RectTransform.EnsureChildIsVisibleVertically(slot.RectTransform, UIScrollListSelectableItem.ScrollListAdjustmentDriver.SiblingIndexDriven);
	}

	private void OnSlotButtonClicked(UISelectableListButton seletedButton)
	{
		Transform transform = base.transform;
		for (int i = 0; i < transform.childCount; i++)
		{
			transform.GetChild(i).GetComponent<UISelectableListButton>().SelectableListButtonClicked(seletedButton);
		}
	}

	public void NewSaveFileClicked()
	{
		if (_waitingForSaves)
		{
			return;
		}
		_waitingForSaves = true;
		_gameData.GetLowestAvailableSlotNumber((int newSlotNumber) =>
		{
			if (newSlotNumber == -1)
			{
				Debug.LogError("GetLowestAvailableSlotNumber failed to give us a valid index. User could have reached maximum");
			}
			else
			{
				_gameState.SelectSaveGame(newSlotNumber);
				_gameState.LoadGameStateData(null, -1);
				_gameData.SaveGameData(newSlotNumber, createBackup: false, (bool success) =>
				{
					if (success)
					{
						Events.RaiseEvent("GameSaved");
						_gameState.LoadSaveSlotMetaData(newSlotNumber, null);
						_parentMenu.ShowGameSavedConfirmationMessage();
					}
					else
					{
						Debug.LogError($"SaveGameData for slot#{newSlotNumber} has failed ");
					}
					_parentMenu.RefreshSaveList(newSlotNumber, () =>
					{
						_waitingForSaves = false;
					});
				});
			}
		});
	}
}
