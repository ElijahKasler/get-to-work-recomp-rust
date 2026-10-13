using System;
using System.Collections;
using System.Collections.Generic;
using I2.Loc;
using Isto.Core.Beings;
using Isto.Core.Configuration;
using Isto.Core.Enums;
using Isto.Core.Inputs;
using Isto.Core.Localization;
using Isto.Core.StateMachine;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;

namespace Isto.Core.UI;

public class UIDialogueMenuState : MonoState
{
	public enum MessageType
	{
		GameStart = 0,
		FuelDepot = 1,
		TutorialComplete = 2,
		DemoComplete = 3,
		CircuitJuiceWarning = 4,
		FirstTimeCircuitJuice = 5,
		CircuitJuiceRefillUnlocked = 6,
		GameCompleted = 7,
		EquippingTutorial = 8,
		PlacingLightbulbTutorial = 9,
		ResearchBackpackTutorial = 10,
		ResearchLightbulbTutorial = 11,
		EarlyAccessMainGameCompleted = 12,
		AttackWaveIncomingTutorial = 13,
		TornatoadTutorial = 14,
		BeeBoxTutorial = 15,
		RechargeableTorchTutorial = 16,
		FreePlayStart = 17,
		FreePlayComplete = 18,
		EntangledChestTutorial = 19
	}

	public class MessageTypeEnum : Int32Enum<MessageTypeEnum>
	{
		public MessageTypeEnum(int value, string name)
			: base(value, name)
		{
		}
	}

	public class AtrioMessageTypeEnum : MessageTypeEnum
	{
		public static readonly AtrioMessageTypeEnum GAMESTART = new AtrioMessageTypeEnum(0, "GAMESTART");

		public static readonly AtrioMessageTypeEnum FUELDEPOT = new AtrioMessageTypeEnum(1, "FUELDEPOT");

		public static readonly AtrioMessageTypeEnum TUTORIALCOMPLETE = new AtrioMessageTypeEnum(2, "TUTORIALCOMPLETE");

		public static readonly AtrioMessageTypeEnum DEMOCOMPLETE = new AtrioMessageTypeEnum(3, "DEMOCOMPLETE");

		public static readonly AtrioMessageTypeEnum CIRCUITJUICEWARNING = new AtrioMessageTypeEnum(4, "CIRCUITJUICEWARNING");

		public static readonly AtrioMessageTypeEnum FIRSTTIMECIRCUITJUICE = new AtrioMessageTypeEnum(5, "FIRSTTIMECIRCUITJUICE");

		public static readonly AtrioMessageTypeEnum CIRCUITJUICEREFILLUNLOCKED = new AtrioMessageTypeEnum(6, "CIRCUITJUICEREFILLUNLOCKED");

		public static readonly AtrioMessageTypeEnum GAMECOMPLETED = new AtrioMessageTypeEnum(7, "GAMECOMPLETED");

		public static readonly AtrioMessageTypeEnum EQUIPPINGTUTORIAL = new AtrioMessageTypeEnum(8, "EQUIPPINGTUTORIAL");

		public static readonly AtrioMessageTypeEnum PLACINGLIGHTBULBTUTORIAL = new AtrioMessageTypeEnum(9, "PLACINGLIGHTBULBTUTORIAL");

		public static readonly AtrioMessageTypeEnum RESEARCHBACKPACKTUTORIAL = new AtrioMessageTypeEnum(10, "RESEARCHBACKPACKTUTORIAL");

		public static readonly AtrioMessageTypeEnum RESEARCHLIGHTBULBTUTORIAL = new AtrioMessageTypeEnum(11, "RESEARCHLIGHTBULBTUTORIAL");

		public static readonly AtrioMessageTypeEnum EARLYACCESSMAINGAMECOMPLETED = new AtrioMessageTypeEnum(12, "EARLYACCESSMAINGAMECOMPLETED");

		public static readonly AtrioMessageTypeEnum ATTACKWAVEINCOMINGTUTORIAL = new AtrioMessageTypeEnum(13, "ATTACKWAVEINCOMINGTUTORIAL");

		public static readonly AtrioMessageTypeEnum TORNATOADTUTORIAL = new AtrioMessageTypeEnum(14, "TORNATOADTUTORIAL");

		public static readonly AtrioMessageTypeEnum BEEBOXTUTORIAL = new AtrioMessageTypeEnum(15, "BEEBOXTUTORIAL");

		public static readonly AtrioMessageTypeEnum RECHARGEABLETORCHTUTORIAL = new AtrioMessageTypeEnum(16, "RECHARGEABLETORCHTUTORIAL");

		public static readonly AtrioMessageTypeEnum FREEPLAYSTART = new AtrioMessageTypeEnum(17, "FREEPLAYSTART");

		public static readonly AtrioMessageTypeEnum FREEPLAYCOMPLETE = new AtrioMessageTypeEnum(18, "FREEPLAYCOMPLETE");

		public static readonly AtrioMessageTypeEnum ENTANGLEDCHESTTUTORIAL = new AtrioMessageTypeEnum(19, "ENTANGLEDCHESTTUTORIAL");

		public AtrioMessageTypeEnum(int value, string name)
			: base(value, name)
		{
		}
	}

	public class DialogueMessageArgs : EventArgs
	{
		public MessageType type;

		public DialogueMessageArgs(MessageType type)
		{
			this.type = type;
		}
	}

	[Header("Regular Message Box")]
	[SerializeField]
	private CanvasGroup _canvasGroup;

	[SerializeField]
	private TextMeshProUGUI _titleText;

	[SerializeField]
	private AnimationClip _taskComplete;

	[SerializeField]
	private Animator _anim;

	[SerializeField]
	private Button _confirmButton;

	[SerializeField]
	private Button _feedbackButton;

	[Header("Large Message Box")]
	[SerializeField]
	private CanvasGroup _largeCanvasGroup;

	[SerializeField]
	private TextMeshProUGUI _largeTitleText;

	[SerializeField]
	private Animator _largeAnim;

	[SerializeField]
	private CoreButtonController _largeConfirmButton;

	[Header("Loc refs")]
	[SerializeField]
	private LocalizedString _defaultTitleKey;

	[SerializeField]
	private LocalizedString _defaultConfirmButtonKey;

	[Header("Message Types")]
	[SerializeField]
	private GameObject _textOnlyParent;

	[SerializeField]
	private TextMeshProUGUI _textOnlyMessageTxt;

	[SerializeField]
	private GameObject _textWithImageParent;

	[SerializeField]
	private TextMeshProUGUI _textWithImageMessageTxt;

	[SerializeField]
	private Image _infoImage;

	[SerializeField]
	private TextMeshProUGUI _largeBoxPreImageMessageTxt;

	[SerializeField]
	private Image _largeBoxInfoImage;

	[SerializeField]
	private TextMeshProUGUI _largeBoxPostImageMessageTxt;

	private Dictionary<MessageType, string> _messages = new Dictionary<MessageType, string>
	{
		{
			MessageType.GameStart,
			"MainTasks/GameStart/Content"
		},
		{
			MessageType.FuelDepot,
			"MainTasks/FuelDepot/Content"
		},
		{
			MessageType.TutorialComplete,
			"MainTasks/TutorialComplete/Content"
		},
		{
			MessageType.DemoComplete,
			"MainTasks/DemoComplete/Content"
		},
		{
			MessageType.CircuitJuiceWarning,
			"MainTasks/CircuitJuiceWarning/Content"
		},
		{
			MessageType.FirstTimeCircuitJuice,
			"MainTasks/FirstTimeCircuitJuice/Content"
		},
		{
			MessageType.CircuitJuiceRefillUnlocked,
			"MainTasks/CircuitJuiceRefillUnlocked/Content"
		},
		{
			MessageType.GameCompleted,
			"MainTasks/GameCompleted/Content"
		},
		{
			MessageType.EquippingTutorial,
			"MainTasks/EquippingTutorial/Content"
		},
		{
			MessageType.PlacingLightbulbTutorial,
			"MainTasks/PlacingLightbulbTutorial/Content"
		},
		{
			MessageType.ResearchBackpackTutorial,
			"MainTasks/ResearchBackpackTutorial/Content"
		},
		{
			MessageType.ResearchLightbulbTutorial,
			"MainTasks/ResearchLightbulbTutorial/Content"
		},
		{
			MessageType.EarlyAccessMainGameCompleted,
			"MainTasks/EarlyAccessMainGameCompleted/Content"
		},
		{
			MessageType.AttackWaveIncomingTutorial,
			"MainTasks/AttackWaveIncomingTutorial/Content"
		},
		{
			MessageType.TornatoadTutorial,
			"MainTasks/TornatoadTutorial/Content"
		},
		{
			MessageType.BeeBoxTutorial,
			"MainTasks/BeeBoxTutorial/Content"
		},
		{
			MessageType.RechargeableTorchTutorial,
			"MainTasks/RechargeTorchTutorial/Content"
		},
		{
			MessageType.FreePlayStart,
			"MainTasks/FreePlayStart/Content"
		},
		{
			MessageType.FreePlayComplete,
			"MainTasks/FreePlayComplete/Content"
		},
		{
			MessageType.EntangledChestTutorial,
			"MainTasks/EntangledChest/Content"
		}
	};

	private Action _callbackOnClose;

	private bool _usingLargePopup;

	private MessageType _currentMessage;

	private Controls.Mode _previousMode;

	private Selectable _currentSelection;

	private Canvas _mainCanvas;

	private IControls _controls;

	private IUIGameMenu _mainMenu;

	private GameplaySettings _settings;

	private AutomationPlayerController _playerController;

	public event EventHandler<DialogueMessageArgs> DialogueOpen;

	[Inject]
	public void Inject(IControls controls, IUIGameMenu mainMenu, GameplaySettings gameplaySettings, AutomationPlayerController playerController)
	{
		_controls = controls;
		_mainMenu = mainMenu;
		_settings = gameplaySettings;
		_playerController = playerController;
	}

	private void Awake()
	{
		TryGetComponent<Canvas>(out _mainCanvas);
		if ((bool)_mainCanvas)
		{
			_mainCanvas.enabled = false;
		}
	}

	public override void Enter(MonoStateMachine controller)
	{
		if ((bool)_mainCanvas)
		{
			_mainCanvas.enabled = true;
		}
		_previousMode = _controls.GetControlMode();
		_playerController.PlaceAdvItemState.ForceCancelDrop();
		_controls.SetControlMode(Controls.Mode.UI);
		_controls.DisableControls(1f);
		_currentSelection = (_usingLargePopup ? _largeConfirmButton.GetSelectable() : _confirmButton);
		CanvasGroup canvasGroup = (_usingLargePopup ? _largeCanvasGroup : _canvasGroup);
		StartCoroutine(UIUtils.SetCanvasAlpha(canvasGroup, 1f, Constants.CANVAS_FADE_TIME, interactable: true, _currentSelection));
		Events.Subscribe("InputChanged", OnInputModeChanged);
	}

	public override void Exit(MonoStateMachine controller)
	{
		Events.UnSubscribe("InputChanged", OnInputModeChanged);
		_currentSelection = null;
		if (_usingLargePopup)
		{
			StartCoroutine(UIUtils.SetCanvasAlpha(_largeCanvasGroup, 0f, Constants.CANVAS_FADE_TIME, interactable: false));
		}
		else
		{
			StartCoroutine(UIUtils.SetCanvasAlpha(_canvasGroup, 0f, Constants.CANVAS_FADE_TIME, interactable: false));
		}
		_controls.SetControlMode(_previousMode);
		if ((bool)_mainCanvas)
		{
			_mainCanvas.enabled = false;
		}
	}

	public override void ReturnFromSubState(MonoStateMachine controller, MonoState previousState)
	{
		Debug.LogError("Shouldn't be coming back from sub state in dialogue menu.  Previous state: " + previousState.name + ". Forcing all menus closed");
		if (controller is IUIGameMenu iUIGameMenu)
		{
			iUIGameMenu.CloseMenu();
		}
	}

	public override MonoState Run(MonoStateMachine controller)
	{
		if (_controls.GetButtonUp(UserActions.PAUSE) && _controls.GetButtonUp(UserActions.UICANCEL))
		{
			ExitMenu();
		}
		return this;
	}

	public void OpenPopUp(MessageType type, Action callbackOnClose = null)
	{
		if (_messages.ContainsKey(type))
		{
			_currentMessage = type;
			OpenPopUp(Loc.Get(_defaultTitleKey), Loc.GetString(_messages[type]), callbackOnClose);
			_feedbackButton.gameObject.SetActive(type == MessageType.GameCompleted);
		}
		else
		{
			Debug.LogWarning("No message for type: " + type);
		}
	}

	public void OpenLargePopUp(MessageType type, Action callbackOnClose = null)
	{
		if (_messages.ContainsKey(type))
		{
			_currentMessage = type;
			OpenLargePopUp(Loc.Get(_defaultTitleKey), Loc.GetString(_messages[type]), null, null, Loc.Get(_defaultConfirmButtonKey), callbackOnClose);
			_feedbackButton.gameObject.SetActive(type == MessageType.GameCompleted);
		}
		else
		{
			Debug.LogWarning("No message for type: " + type);
		}
	}

	public void OpenPopUp(MessageType type, Sprite image, Action callbackOnClose = null)
	{
		if (_messages.ContainsKey(type))
		{
			_currentMessage = type;
			if (image != null)
			{
				OpenPopUpWithImage(Loc.Get(_defaultTitleKey), Loc.GetString(_messages[type]), image, callbackOnClose);
			}
			else
			{
				OpenPopUp(Loc.Get(_defaultTitleKey), Loc.GetString(_messages[type]), callbackOnClose);
			}
			_feedbackButton.gameObject.SetActive(type == MessageType.GameCompleted);
		}
		else
		{
			Debug.LogWarning("No message for type: " + type);
		}
	}

	public void OpenPopUp(MessageType type, LocalizedString title, LocalizedString extraMessage, LocalizedString buttonText, Sprite image = null, Action callbackOnClose = null)
	{
		if (_messages.ContainsKey(type))
		{
			_currentMessage = type;
			string localizedTitle = Loc.Get(title);
			string localizedFirstMessage = Loc.Get(_messages[type]);
			string localizedSecondMessage = (((string)extraMessage != null) ? Loc.Get(extraMessage) : null);
			string localizedButtonText = Loc.Get(buttonText);
			OpenLargePopUp(localizedTitle, localizedFirstMessage, image, localizedSecondMessage, localizedButtonText, callbackOnClose);
			_feedbackButton.gameObject.SetActive(value: false);
		}
		else
		{
			Debug.LogWarning("No message for type: " + type);
		}
	}

	public void OpenPopUp(string localizedTitle, string localizedMessage, Action callbackOnClose = null)
	{
		_usingLargePopup = false;
		Loc.SetTMProLocalized(_titleText, localizedTitle);
		Loc.SetTMProLocalized(_textOnlyMessageTxt, localizedMessage);
		_callbackOnClose = callbackOnClose;
		_textOnlyParent.SetActive(value: true);
		_textWithImageParent.SetActive(value: false);
		_anim.SetTrigger("showMainTask");
		_mainMenu.EnterSubState(this);
	}

	private void OpenPopUpWithImage(string localizedTitle, string localizedMessage, Sprite image, Action callbackOnClose = null)
	{
		_usingLargePopup = false;
		Loc.SetTMProLocalized(_titleText, localizedTitle);
		Loc.SetTMProLocalized(_textWithImageMessageTxt, localizedMessage);
		_callbackOnClose = callbackOnClose;
		_infoImage.sprite = image;
		_textOnlyParent.SetActive(value: false);
		_textWithImageParent.SetActive(value: true);
		_anim.SetTrigger("showMainTask");
		_mainMenu.EnterSubState(this);
	}

	private void OpenLargePopUp(string localizedTitle, string localizedFirstMessage, Sprite centerImage, string localizedSecondMessage, string localizedButtonText, Action callbackOnClose = null)
	{
		_usingLargePopup = true;
		Loc.SetTMProLocalized(_largeTitleText, localizedTitle);
		Loc.SetTMProLocalized(_largeBoxPreImageMessageTxt, localizedFirstMessage);
		Loc.SetTMProLocalized(_largeBoxPostImageMessageTxt, localizedSecondMessage);
		_largeConfirmButton.SetText(localizedButtonText);
		_callbackOnClose = callbackOnClose;
		_largeBoxInfoImage.sprite = centerImage;
		_largeBoxInfoImage.gameObject.SetActive(centerImage != null);
		_largeAnim.SetTrigger("showMainTask");
		_mainMenu.EnterSubState(this);
	}

	public void OnCloseButtonClicked()
	{
		ExitMenu();
	}

	public void OnFeedbackButtonClicked()
	{
		Application.OpenURL(_settings.feedbackUrl);
	}

	public IEnumerator RunTaskComplete()
	{
		StartCoroutine(UIUtils.SetCanvasAlpha(_canvasGroup, 1f, Constants.CANVAS_FADE_TIME, interactable: true));
		_anim.SetTrigger("taskComplete");
		yield return new WaitForSeconds(_taskComplete.length);
		DialogueOpen?.Invoke(this, new DialogueMessageArgs(_currentMessage));
	}

	private void ExitMenu()
	{
		_callbackOnClose?.Invoke();
		_mainMenu.ExitSubState();
	}

	private void OnInputModeChanged()
	{
		EventSystem.current.SetSelectedGameObject(Controls.UsingController ? _currentSelection.gameObject : null);
	}

	[ContextMenu("OpenTestPopup")]
	private void OpenTestPopup()
	{
		OpenPopUp(MessageType.FreePlayComplete, _defaultTitleKey, null, _defaultTitleKey);
	}
}
