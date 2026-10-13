using System;
using I2.Loc;
using Isto.Core.Audio;
using Isto.Core.Inputs;
using Isto.Core.Localization;
using Isto.Core.StateMachine;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;

namespace Isto.Core.UI;

public class UIModalChoicePopup : MonoState
{
	public enum ChoicePopupType
	{
		NoChoice = 0,
		YesNoChoice = 1,
		OkCancelChoice = 2
	}

	[SerializeField]
	private LocalizedString _defaultTitleKey;

	[SerializeField]
	private LocalizedString _yesKey;

	[SerializeField]
	private LocalizedString _noKey;

	[SerializeField]
	private LocalizedString _okKey;

	[SerializeField]
	private LocalizedString _cancelKey;

	[SerializeField]
	private CanvasGroup _canvasGroup;

	[SerializeField]
	private UIPanelHeader _headerPanel;

	[SerializeField]
	private TextMeshProUGUI _informationTextArea;

	[SerializeField]
	private TextMeshProUGUI _questionTextArea;

	[SerializeField]
	private CoreButtonController _confirmButton;

	[SerializeField]
	private CoreButtonController _cancelButton;

	private Action _onConfirm;

	private Action _onCancel;

	private Controls.Mode _previousMode;

	private float _previousTimeScale;

	private IUIMenu _gameMenu;

	private GameObject _previousSelection;

	private IControls _controls;

	protected UISounds _uiSounds;

	[Inject]
	public void Inject(IControls controls, UISounds uiSounds)
	{
		_controls = controls;
		_uiSounds = uiSounds;
	}

	private void Awake()
	{
		ClosePopup();
	}

	public void DisplayChoice(ChoicePopupType type, LocalizedString questionText, Action onConfirm, Action onCancel = null, LocalizedString? optionalExtraDescription = null, LocalizedString? titleOverride = null, LocalizedString? confirmButtonOverride = null, LocalizedString? cancelButtonOverride = null)
	{
		DisplayChoice(type, Loc.Get(questionText), onConfirm, onCancel, optionalExtraDescription.HasValue ? Loc.Get(optionalExtraDescription.Value) : "", titleOverride.HasValue ? Loc.Get(titleOverride.Value) : "", confirmButtonOverride.HasValue ? Loc.Get(confirmButtonOverride.Value) : "", cancelButtonOverride.HasValue ? Loc.Get(cancelButtonOverride.Value) : "");
	}

	public void DisplayChoice(ChoicePopupType type, string questionText, Action onConfirm, Action onCancel = null, string optionalExtraDescription = "", string titleOverride = "", string confirmButtonOverride = "", string cancelButtonOverride = "")
	{
		Debug.Log($"DisplayChoice popup of type {type} asking: {questionText}");
		Selectable selectable = null;
		string text;
		string text2;
		switch (type)
		{
		case ChoicePopupType.NoChoice:
			_cancelButton.gameObject.SetActive(value: false);
			text = "";
			text2 = Loc.Get(_okKey);
			selectable = _confirmButton.GetSelectable();
			break;
		case ChoicePopupType.YesNoChoice:
			_cancelButton.gameObject.SetActive(value: true);
			text = Loc.Get(_noKey);
			text2 = Loc.Get(_yesKey);
			selectable = _cancelButton.GetSelectable();
			break;
		case ChoicePopupType.OkCancelChoice:
			_cancelButton.gameObject.SetActive(value: true);
			text = Loc.Get(_cancelKey);
			text2 = Loc.Get(_okKey);
			selectable = _cancelButton.GetSelectable();
			break;
		default:
			Debug.LogWarning($"Unsuported ChoicePopupType {type} in DisplayChoice");
			return;
		}
		string title = (string.IsNullOrEmpty(titleOverride) ? Loc.Get(_defaultTitleKey) : titleOverride);
		if (!string.IsNullOrEmpty(confirmButtonOverride))
		{
			text2 = confirmButtonOverride;
		}
		if (!string.IsNullOrEmpty(cancelButtonOverride))
		{
			text = cancelButtonOverride;
		}
		_headerPanel.SetTitle(title);
		_questionTextArea.text = questionText;
		_informationTextArea.text = optionalExtraDescription;
		_cancelButton.SetText(text);
		_confirmButton.SetText(text2);
		_onConfirm = onConfirm;
		_onCancel = onCancel;
		OpenPopup();
		StealUIContext();
		if (Controls.UsingController && selectable != null)
		{
			selectable.Select();
		}
	}

	public void OnConfirmButtonPressed()
	{
		ClosePopup();
		RestoreUIContext();
		_onConfirm?.Invoke();
	}

	public void OnCancelButtonPressed()
	{
		ClosePopup();
		RestoreUIContext();
		_onCancel?.Invoke();
	}

	private void OpenPopup()
	{
		_canvasGroup.alpha = 1f;
		_canvasGroup.interactable = true;
		_canvasGroup.blocksRaycasts = true;
	}

	private void ClosePopup()
	{
		_canvasGroup.alpha = 0f;
		_canvasGroup.interactable = false;
		_canvasGroup.blocksRaycasts = false;
	}

	[ContextMenu("ShowExampleChoice")]
	private void ShowExampleChoice()
	{
		DisplayChoice(ChoicePopupType.YesNoChoice, "Do you accept?", () =>
		{
			Debug.Log("Example choice accepted.");
		}, () =>
		{
			Debug.Log("Example choice refused.");
		}, "Here is an example choice.", "Test", "Um, yeah.", "Ugh, no.");
	}

	private void StealUIContext()
	{
		_previousMode = _controls.GetControlMode();
		_controls.SetControlMode(Controls.Mode.UI);
		_previousTimeScale = Time.timeScale;
		Time.timeScale = 0f;
		MonoPushdownStateMachine[] array = UnityEngine.Object.FindObjectsOfType<MonoPushdownStateMachine>();
		for (int i = 0; i < array.Length; i++)
		{
			if (array[i] is IUIMenu gameMenu)
			{
				_gameMenu = gameMenu;
			}
		}
		if (_gameMenu != null)
		{
			_gameMenu.EnterSubState(this);
		}
		_previousSelection = (Controls.UsingController ? EventSystem.current.currentSelectedGameObject : null);
	}

	private void RestoreUIContext()
	{
		Time.timeScale = _previousTimeScale;
		_controls.SetControlMode(_previousMode);
		if (_gameMenu != null && _gameMenu.GetCurrentState() == this)
		{
			_gameMenu.ExitSubState();
		}
		if (Controls.UsingController && _previousSelection != null)
		{
			EventSystem.current.SetSelectedGameObject(_previousSelection);
		}
	}

	public override void Enter(MonoStateMachine controller)
	{
	}

	public override void Exit(MonoStateMachine controller)
	{
	}

	public override MonoState Run(MonoStateMachine controller)
	{
		if (Controls.UsingController && _controls.GetButtonDown(UserActions.UICANCEL))
		{
			_uiSounds.PlayButtonClickSound();
			if (_cancelButton.gameObject.activeSelf)
			{
				OnCancelButtonPressed();
			}
			else
			{
				OnConfirmButtonPressed();
			}
		}
		return this;
	}
}
