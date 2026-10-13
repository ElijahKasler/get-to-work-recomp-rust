using System;
using I2.Loc;
using Isto.Core.Configuration;
using Isto.Core.Data;
using Isto.Core.Inputs;
using Isto.Core.Localization;
using Isto.Core.StateMachine;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Isto.Core.UI;

public class CoreUIUpgradeSaveSlotSubState : MonoState, IStateExitResult
{
	protected const string WARNING_REGULAR = "We have made some changes that require your save to be migrated.\n\nIf you encounter any bugs please report it on Discord.";

	protected const string WARNING_RISKY = "We've made large changes to the game, making old saves unplayable.\n\nOur recommendation is to start with a new save.\n\nHowever, we know many of you want to keep what you've made, so we created a migration tool to preserve as much progress as possible.\n\nPlease note: there may be bugs and significant changes to your base.";

	[SerializeField]
	private CanvasGroup _canvasGroup;

	[SerializeField]
	private TextMeshProUGUI _upgradeWarningMessage;

	[Tooltip("Optional assignation that will attempt to tell the controller where the selection should land when this menu is shown")]
	[SerializeField]
	private Selectable _defaultSelection;

	[SerializeField]
	private Settings _settings;

	[SerializeField]
	private LocalizedString _upgradeSuffix;

	[SerializeField]
	private LocalizedString _saveUpgradeSuccess;

	[SerializeField]
	private LocalizedString _saveUpgradeBackupFailed;

	[SerializeField]
	private LocalizedString _saveUpgradeTooManyFiles;

	[SerializeField]
	protected LocalizedString _upgradeWarningRegular;

	[SerializeField]
	protected LocalizedString _upgradeWarningRisky;

	private MonoPushdownStateMachine _mainMenu;

	private int _saveSlot;

	private string _targetSaveVersion;

	private bool _isBlockingForPopup;

	private IControls _controls;

	private IGameData _gameData;

	private UIModalChoicePopup _modalPopup;

	public string BackupSuffix => " " + Loc.Get(_upgradeSuffix);

	public IStateExitResult.ResultType Result { get; private set; }

	[Inject]
	public void Inject(IControls controls, IGameData gameData, UIModalChoicePopup choicePopUp)
	{
		_controls = controls;
		_gameData = gameData;
		_modalPopup = choicePopUp;
	}

	public override void Enter(MonoStateMachine controller)
	{
		_mainMenu = controller as MonoPushdownStateMachine;
		StartCoroutine(UIUtils.SetCanvasAlpha(_canvasGroup, 1f, Constants.CANVAS_FADE_TIME, interactable: true, _defaultSelection));
	}

	public override void Exit(MonoStateMachine controller)
	{
		StartCoroutine(UIUtils.SetCanvasAlpha(_canvasGroup, 0f, Constants.CANVAS_FADE_TIME, interactable: false));
		_controls.DisableControls(Constants.BUTTON_SPAM_DELAY);
	}

	public override void ReturnFromSubState(MonoStateMachine controller, MonoState previousState)
	{
		if (previousState is UIModalChoicePopup)
		{
			_mainMenu.ExitSubState();
		}
	}

	public override MonoState Run(MonoStateMachine controller)
	{
		if (_controls.GetButtonDown(UserActions.UICANCEL) && !_isBlockingForPopup)
		{
			Result = IStateExitResult.ResultType.Cancelled;
			_mainMenu.ExitSubState();
		}
		return this;
	}

	public void UpgradeButtonClicked()
	{
		Result = IStateExitResult.ResultType.Submit;
		Debug.Log("Upgrading save");
		UpgradeSaveFile();
	}

	private void UpgradeSaveFile()
	{
		TryCreateBackupOfSaveFile((bool backupSuccess) =>
		{
			if (backupSuccess)
			{
				_gameData.UpgradeGameData(_saveSlot, _targetSaveVersion, (bool upgradeSuccess) =>
				{
					if (upgradeSuccess)
					{
						_isBlockingForPopup = true;
						_modalPopup.DisplayChoice(UIModalChoicePopup.ChoicePopupType.NoChoice, _saveUpgradeSuccess, OnUpgradeConfirmationPopupClosed);
					}
					else
					{
						Debug.LogError("Could not upgrade game data, operation aborted.");
					}
				});
			}
			else
			{
				Debug.LogError("Could not create backup of save file, upgrading aborted.");
				if (_mainMenu.GetCurrentState() is CoreUIUpgradeSaveSlotSubState || _mainMenu.GetCurrentState().GetType().IsSubclassOf(typeof(CoreUIUpgradeSaveSlotSubState)))
				{
					_mainMenu.ExitSubState();
				}
			}
		});
	}

	private void OnUpgradeConfirmationPopupClosed()
	{
		_isBlockingForPopup = false;
	}

	private void TryCreateBackupOfSaveFile(Action<bool> onBackupCreated)
	{
		_gameData.GetNextAvailableSlotNumber(_saveSlot, (int backupSlotNum) =>
		{
			if (backupSlotNum != -1)
			{
				_gameData.DuplicateGameData(_saveSlot, backupSlotNum, (bool backupSuccess) =>
				{
					if (backupSuccess)
					{
						_gameData.LoadGameMetaData(backupSlotNum, (GameStateSaveData backupMetaData) =>
						{
							if (backupMetaData == null)
							{
								Debug.LogError($"LoadSaveSlotMetaData returned null data for slot#{backupSlotNum} during backup process");
							}
							else
							{
								string backupSuffix = BackupSuffix;
								if (backupMetaData.saveSlotName.Length > _settings.MaxCharactersInSaveName - backupSuffix.Length)
								{
									backupMetaData.saveSlotName = backupMetaData.saveSlotName.Substring(0, _settings.MaxCharactersInSaveName - backupSuffix.Length);
								}
								backupMetaData.saveSlotName += backupSuffix;
								_gameData.SaveGameMetaData(backupSlotNum, backupMetaData, (bool success) =>
								{
									Debug.Log(string.Format("UpdateSaveSlotMetaData to rename backup slot#{0} was a {1}", backupSlotNum, success ? "success" : "failure"));
								});
								onBackupCreated?.Invoke(backupSuccess);
							}
						});
					}
					else
					{
						_modalPopup.DisplayChoice(UIModalChoicePopup.ChoicePopupType.NoChoice, _saveUpgradeBackupFailed, null);
						onBackupCreated?.Invoke(backupSuccess);
					}
				});
			}
			else
			{
				_modalPopup.DisplayChoice(UIModalChoicePopup.ChoicePopupType.NoChoice, _saveUpgradeTooManyFiles, null);
				onBackupCreated?.Invoke(obj: false);
			}
		});
	}

	public void ExitButtonClicked()
	{
		Result = IStateExitResult.ResultType.Cancelled;
		Debug.Log("Upgrade Cancelled");
		_mainMenu.ExitSubState();
	}

	public void SetSaveSlot(int slotNumber, string targetVersion)
	{
		_saveSlot = slotNumber;
		_targetSaveVersion = targetVersion;
		_upgradeWarningMessage.text = GetWarningMessage(targetVersion);
	}

	protected virtual string GetWarningMessage(string targetVersion)
	{
		if (!string.IsNullOrEmpty(_upgradeWarningRegular.mTerm))
		{
			Loc.Get(_upgradeWarningRegular);
		}
		return "We have made some changes that require your save to be migrated.\n\nIf you encounter any bugs please report it on Discord.";
	}
}
