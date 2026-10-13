using Isto.Core.Inputs;
using Isto.GTW.Inputs;
using Isto.GTW.Player;
using UnityEngine;
using Zenject;

namespace UI.ReadyScreen;

public class ReadyScreen : MonoBehaviour
{
	[SerializeField]
	private CanvasGroup _canvasGroup;

	[SerializeField]
	private GameObject _keyboardMessage;

	[SerializeField]
	private GameObject _controllerMessage;

	[Tooltip("Delay before being able to hide the ready screen")]
	[SerializeField]
	private float _inputCheckDelay = 0.5f;

	private static bool _isVisible;

	private static bool _isClosing;

	private float _showDuration = -1f;

	private PlayerController _playerController;

	private IControls _controls;

	public static bool ShowReadyScreen { get; set; }

	public static bool IsVisible => _isVisible;

	public static bool IsClosing => _isClosing;

	[Inject]
	public void Inject(PlayerController playerController, IControls controls)
	{
		_playerController = playerController;
		_controls = controls;
	}

	private void Awake()
	{
		_canvasGroup.gameObject.SetActive(value: false);
	}

	private void Update()
	{
		if (ShowReadyScreen && !_isVisible)
		{
			Show();
		}
		if (_isVisible && _playerController.IsMoveState)
		{
			if (!Mathf.Approximately(Time.timeScale, 0f))
			{
				Time.timeScale = 0f;
			}
			UpdateControllerKeyboard();
			_showDuration += Time.unscaledDeltaTime;
			if (_showDuration > _inputCheckDelay && (_controls.GetAnyButton() || _controls.GetStartGameAction() || _controls.GetButton(GTWUserActions.STARTGAME)))
			{
				ShowReadyScreen = false;
				Hide();
			}
		}
	}

	private void LateUpdate()
	{
		_isClosing = false;
	}

	public void Show()
	{
		_isVisible = true;
		_canvasGroup.gameObject.SetActive(value: true);
		_showDuration = 0f;
		_isClosing = false;
	}

	public void Hide()
	{
		_isVisible = false;
		_canvasGroup.gameObject.SetActive(value: false);
		Time.timeScale = 1f;
		_isClosing = true;
	}

	private void UpdateControllerKeyboard()
	{
		_keyboardMessage.SetActive(!_controls.UsingJoystick());
		_controllerMessage.SetActive(_controls.UsingJoystick());
	}
}
