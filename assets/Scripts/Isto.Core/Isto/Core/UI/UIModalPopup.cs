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

public class UIModalPopup : MonoState
{
	public enum ErrorPopupType
	{
		UnknownError = 0,
		PathTooLongException = 1,
		DirectoryNotFoundException = 2,
		IOException = 3,
		UnauthorizedAccessException = 4,
		SecurityException = 5
	}

	[Header("Loc")]
	[SerializeField]
	private LocalizedString _pathlengthErrorKey;

	[SerializeField]
	private LocalizedString _notFoundErrorKey;

	[SerializeField]
	private LocalizedString _ioErrorKey;

	[SerializeField]
	private LocalizedString _noAccessErrorKey;

	[SerializeField]
	private LocalizedString _securityErrorKey;

	[SerializeField]
	private LocalizedString _unknownErrorKey;

	[Header("UI pieces")]
	[SerializeField]
	private CanvasGroup _canvasGroup;

	[SerializeField]
	private TextMeshProUGUI _errorMessageTextArea;

	[SerializeField]
	private TMP_Text _exceptionField;

	[SerializeField]
	private Button _closeButton;

	private IUIMenu _menuController;

	private GameObject _previousSelection;

	private Controls.Mode _previousMode;

	private float _previousTimeScale;

	private int _errorsOnDisplay;

	private bool _isOpen;

	private IControls _controls;

	protected UISounds _uiSounds;

	protected LocTerm.Factory _localizedStringFactory;

	[Inject]
	public void Inject(IControls controls, UISounds uiSounds, LocTerm.Factory localizedStringFactory)
	{
		_controls = controls;
		_uiSounds = uiSounds;
		_localizedStringFactory = localizedStringFactory;
	}

	private void Awake()
	{
		ClosePopup();
	}

	public void DisplayError(ErrorPopupType type)
	{
		string text = $"Displaying error popup of {type} (info: ";
		if (_exceptionField != null && _exceptionField.text != null)
		{
			text += _exceptionField.text;
		}
		text += ")";
		Debug.LogWarning(text);
		LocalizedString localizedString = type switch
		{
			ErrorPopupType.PathTooLongException => _pathlengthErrorKey, 
			ErrorPopupType.DirectoryNotFoundException => _notFoundErrorKey, 
			ErrorPopupType.IOException => _ioErrorKey, 
			ErrorPopupType.UnauthorizedAccessException => _noAccessErrorKey, 
			ErrorPopupType.SecurityException => _securityErrorKey, 
			_ => _unknownErrorKey, 
		};
		if ((string)localizedString != null)
		{
			_localizedStringFactory.Create(LocTerm.LocalizationType.Localized, localizedString.mTerm).LocalizeInto(_errorMessageTextArea);
		}
		else
		{
			_errorMessageTextArea.text = "Error in error message parsing, see details in exception message below.";
		}
		if (_errorsOnDisplay < 1)
		{
			OpenPopup();
			StealUIContext();
		}
		_errorsOnDisplay++;
	}

	public void DisplayError(ErrorPopupType type, Exception e)
	{
		if (_exceptionField != null)
		{
			if (e != null)
			{
				if (_errorsOnDisplay > 0)
				{
					_exceptionField.text += "\n\n";
				}
				else
				{
					_exceptionField.text = "";
				}
				TMP_Text exceptionField = _exceptionField;
				exceptionField.text = exceptionField.text + "Exception:" + e.Message + "\n" + e.InnerException?.Message;
			}
			else
			{
				_exceptionField.text = "";
			}
		}
		DisplayError(type);
	}

	public void OnConfirmButtonPressed()
	{
		_errorsOnDisplay = 0;
		ClosePopup();
		RestoreUIContext();
	}

	private void OpenPopup()
	{
		_isOpen = true;
		_canvasGroup.alpha = 1f;
		_canvasGroup.interactable = true;
		_canvasGroup.blocksRaycasts = true;
	}

	private void ClosePopup()
	{
		_isOpen = false;
		_canvasGroup.alpha = 0f;
		_canvasGroup.interactable = false;
		_canvasGroup.blocksRaycasts = false;
	}

	[ContextMenu("ShowExampleError")]
	private void ShowExampleError()
	{
		DisplayError(ErrorPopupType.UnknownError, new Exception("Here's the main exception message. It should be fairly long to take up as much realestate on the pop-up as possible since these things often are very verbose and full of useless crap\n", new Exception("Inner exception message.  This also should be really long just so we can test the functionality of the scroll rect if it's needed and make sure it actually works.  That would be great, something that actually works.  OMG that wasn't long enough to trigger the scroll rect.  Hopefully this does it because I'm getting bored of typing nonsenseNope, still wasn't long enough because I made the text smaller, which means I have to type more crap to get the scrolling to be needed.  Ugh\n\nSecond Verse\nApparently it still was not enough because I found out that the scroll rect was not working.\n\n-Frank\n\nP.S. Line breaks are neat")));
	}

	[ContextMenu("ShowExampleSmallError")]
	private void ShowExampleSmallError()
	{
		DisplayError(ErrorPopupType.UnknownError, new Exception("Sometimes errors could be simple"));
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
			if (array[i] is IUIMenu menuController)
			{
				_menuController = menuController;
				break;
			}
		}
		if (_menuController != null)
		{
			_menuController.EnterSubState(this);
		}
		if (Controls.UsingController)
		{
			_previousSelection = EventSystem.current.currentSelectedGameObject;
			_closeButton.Select();
		}
		else
		{
			_previousSelection = null;
		}
	}

	private void RestoreUIContext()
	{
		Time.timeScale = _previousTimeScale;
		_controls.SetControlMode(_previousMode);
		if (_menuController != null && _menuController.GetCurrentState() == this)
		{
			_menuController.ExitSubState();
		}
		if (Controls.UsingController && _previousSelection != null)
		{
			EventSystem.current.SetSelectedGameObject(_previousSelection);
		}
	}

	public override void Enter(MonoStateMachine controller)
	{
		Events.Subscribe("InputChanged", OnInputModeChanged);
	}

	public override void Exit(MonoStateMachine controller)
	{
		Events.UnSubscribe("InputChanged", OnInputModeChanged);
	}

	public override MonoState Run(MonoStateMachine controller)
	{
		if (Controls.UsingController && _controls.GetButtonDown(UserActions.UICANCEL))
		{
			_uiSounds.PlayButtonClickSound();
			OnConfirmButtonPressed();
		}
		return this;
	}

	private void OnInputModeChanged()
	{
		if (_isOpen)
		{
			EventSystem.current.SetSelectedGameObject(Controls.UsingController ? _closeButton.gameObject : null);
		}
	}
}
