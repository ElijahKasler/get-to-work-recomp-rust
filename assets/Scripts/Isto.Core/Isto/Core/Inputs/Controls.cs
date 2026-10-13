using System;
using System.Collections;
using System.Collections.Generic;
using I2.Loc;
using Isto.Core.Configuration;
using Isto.Core.Enums;
using Rewired;
using Rewired.Integration.UnityUI;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Isto.Core.Inputs;

public class Controls : MonoBehaviour, IControls, ILocalizationParamsManager
{
	public enum MovementAxis
	{
		MoveHorizontal = 0,
		MoveVertical = 1,
		SecondaryHorizontal = 2,
		SecondaryVertical = 3,
		Zoom = 4,
		UIHorizontal = 5,
		UIVertical = 6,
		UISecondaryHorizontal = 7,
		UISecondaryVertical = 8
	}

	public enum Mode
	{
		Gameplay = 0,
		Building = 1,
		UI = 2,
		IntroUI = 3,
		DeveloperConsole = 4,
		Disabled = 5,
		Dismantling = 6,
		BugReportingTool = 7
	}

	public enum InputDevice
	{
		Joystick = 0,
		Keyboard = 1,
		Mouse = 2
	}

	public enum VibrationMode
	{
		Short = 0,
		Long = 1
	}

	public enum RewiredCategory
	{
		GameplayJoy = 0,
		GameplayMouseKey = 1,
		UIJoy = 2,
		UIMouseKey = 3,
		GameplayBuildingJoy = 4,
		GameplayBuildingMouseKey = 5,
		GameplayDismantlingJoy = 6,
		GameplayDismantlingMouseKey = 7,
		DeveloperConsole = 8,
		Development = 9
	}

	public static int DEFAULT_REWIRED_PLAYER_ID;

	public float defaultSpamTime = 0.2f;

	public float quickPressMaxTime = 0.1f;

	private Player _player;

	private int playerID = DEFAULT_REWIRED_PLAYER_ID;

	private Mode _currentMode;

	private InputDevice _lastInputDevice;

	private bool _disabled;

	private Coroutine _disableControlsRoutine;

	private bool _useControllerSwitchFrameProtection;

	private Dictionary<UserActions, int> _actionToControlIDMap = new Dictionary<UserActions, int>();

	private Dictionary<MovementAxis, int> _axisToControlIDMap = new Dictionary<MovementAxis, int>();

	private List<UserActions> _startGameActions = new List<UserActions>
	{
		UserActions.UISUBMIT,
		UserActions.TOGGLEGAMEMENU,
		UserActions.INTERACT
	};

	private Settings _settings;

	private ControllerGlyphs _glyphs;

	private RewiredStandaloneInputModule _inputModule;

	private const int CONTROLLER_TOPMOST_FACE_BUTTON = 3;

	public static bool UsingController { get; private set; }

	public bool IsControllerAvailable
	{
		get
		{
			Player player = _player;
			if (player == null)
			{
				return false;
			}
			return player.controllers.joystickCount > 0;
		}
	}

	[Inject]
	public void Inject(Settings settings, ControllerGlyphs glyphs, RewiredStandaloneInputModule inputModule)
	{
		_settings = settings;
		_glyphs = glyphs;
		_inputModule = inputModule;
	}

	private void Awake()
	{
		_player = ReInput.players.GetPlayer(playerID);
		foreach (UserActions value in ExpandableEnum<StringEnum<UserActions>, string>.GetValues())
		{
			int actionId = ReInput.mapping.GetActionId(value.Value);
			_actionToControlIDMap.Add(value, actionId);
		}
		foreach (MovementAxis value2 in Enum.GetValues(typeof(MovementAxis)))
		{
			int actionId2 = ReInput.mapping.GetActionId(value2.ToString());
			_axisToControlIDMap.Add(value2, actionId2);
		}
		LocalizationManager.ParamManagers.Add(this);
	}

	private void OnDestroy()
	{
		LocalizationManager.ParamManagers.Remove(this);
	}

	private void OnEnable()
	{
		AssignAllControllers();
		RegisterEvents();
	}

	private void OnDisable()
	{
		UnregisterEvents();
	}

	private void Start()
	{
		if (_settings.UseController)
		{
			if (_player.controllers.joystickCount == 0)
			{
				Debug.Log("No controller detected, switching to Keyboard / Mouse input");
				SetUseJoystick(useJoystick: false);
				SetControlMode(_currentMode);
			}
			else
			{
				SetUseJoystick(useJoystick: true);
			}
		}
		_lastInputDevice = InputDevice.Mouse;
	}

	private void Update()
	{
		if (!_disabled)
		{
			CheckUserUsingController();
		}
	}

	private void RegisterEvents()
	{
		ReInput.ControllerConnectedEvent += OnControllerConnected;
		ReInput.ControllerDisconnectedEvent += OnControllerDisconnected;
	}

	private void UnregisterEvents()
	{
		ReInput.ControllerConnectedEvent -= OnControllerConnected;
		ReInput.ControllerDisconnectedEvent -= OnControllerDisconnected;
	}

	private void OnControllerConnected(ControllerStatusChangedEventArgs args)
	{
		if (args.controllerType != ControllerType.Joystick)
		{
			Debug.LogError("[ReInput.OnControllerConnected] skip - non Joystick controller *************");
			return;
		}
		_ = args.name;
		int controllerId = args.controllerId;
		Debug.LogError($"[ReInput.OnControllerConnected] joystick #{controllerId} connected");
		_player.controllers.AddController(args.controller, removeFromOtherPlayers: true);
		if (_player.controllers.joystickCount == 1)
		{
			Events.RaiseEvent("ChangeInputToControllerMode");
		}
		SetUseJoystick(useJoystick: true);
		SetControlMode(_currentMode);
	}

	private void OnControllerDisconnected(ControllerStatusChangedEventArgs args)
	{
		if (args.controllerType != ControllerType.Joystick)
		{
			Debug.LogError("[ReInput.OnControllerDisconnected] skip - this isn't a Joystick *************");
			return;
		}
		Debug.LogError("[ReInput.OnControllerDisconnected] normal controller disconnect event received");
		_player.controllers.RemoveController(args.controller);
		if (_player.controllers.joystickCount == 0)
		{
			SetUseJoystick(useJoystick: false);
			SetControlMode(_currentMode);
			Events.RaiseEvent("ChangeInputToMouseKeyboardMode");
		}
	}

	private void AssignAllControllers(bool force = false)
	{
		if (force)
		{
			Debug.LogError($"[AssignAllControllers] forcing assignation of {ReInput.controllers.joystickCount} joysticks");
		}
		foreach (Joystick joystick in ReInput.controllers.Joysticks)
		{
			if (force || !ReInput.controllers.IsJoystickAssigned(joystick))
			{
				_player.controllers.AddController(joystick, removeFromOtherPlayers: true);
			}
		}
	}

	public void PrintControlsState()
	{
	}

	public int GetIDForAction(UserActions action)
	{
		if (_actionToControlIDMap.TryGetValue(action, out var value))
		{
			return value;
		}
		Debug.Log(action.Value + ": ID not found");
		return -1;
	}

	public int GetIDForAxis(MovementAxis movementAxis)
	{
		if (_axisToControlIDMap.TryGetValue(movementAxis, out var value))
		{
			return value;
		}
		return -1;
	}

	private void CheckUserUsingController()
	{
		if (_useControllerSwitchFrameProtection)
		{
			_useControllerSwitchFrameProtection = false;
		}
		else if (!_settings.UseController && IsControllerAvailable)
		{
			bool flag = false;
			for (int i = 0; i < _player.controllers.joystickCount; i++)
			{
				flag |= _player.controllers.Joysticks[i].GetAnyButton();
				flag |= _player.controllers.Joysticks[i].PollForFirstAxis().success;
			}
			if (flag)
			{
				SetUseJoystick(useJoystick: true);
				SetControlMode(_currentMode);
			}
		}
		else if (_settings.UseController)
		{
			bool num = _player.controllers.Keyboard.GetAnyButton() || _player.controllers.Mouse.GetAnyButton();
			bool flag2 = _player.controllers.Mouse.screenPositionDelta.sqrMagnitude > 0f;
			if (num | flag2)
			{
				SetUseJoystick(useJoystick: false);
				SetControlMode(_currentMode);
			}
		}
	}

	public Vector2 GetPointerPosition()
	{
		return Input.mousePosition;
	}

	public Vector3 GetPointerPositionOnGround()
	{
		Vector3 mousePosition = Input.mousePosition;
		if (Physics.Raycast(GetRayToPointerPosition(), out var hitInfo, 2000f, Layers.GROUND_LAYERS_MASK))
		{
			return hitInfo.point;
		}
		return Camera.main.ScreenToWorldPoint(mousePosition);
	}

	public Ray GetRayToPointerPosition()
	{
		Vector3 mousePosition = Input.mousePosition;
		return Camera.main.ScreenPointToRay(mousePosition);
	}

	public Vector3 GetCanvasMousePosition(Canvas parent)
	{
		RectTransformUtility.ScreenPointToLocalPointInRectangle(parent.transform as RectTransform, GetPointerPosition(), parent.worldCamera, out var localPoint);
		return parent.transform.TransformPoint(localPoint);
	}

	public bool GetButton(UserActions action, bool ignoreMouse = false)
	{
		bool flag = _player.GetButton(GetIDForAction(action));
		string text = action.Name;
		if (!(text == "INTERACT"))
		{
			if (text == "UISUBMIT")
			{
				if (ignoreMouse & flag)
				{
					flag &= GetActionSource(action.Value) != ControllerType.Mouse;
				}
				flag &= UsingController || EventSystem.current.IsPointerOverGameObject();
			}
		}
		else
		{
			flag &= UsingController || !EventSystem.current.IsPointerOverGameObject();
		}
		if (flag)
		{
			_lastInputDevice = GetDeviceForAction(action);
		}
		return flag;
	}

	public bool GetButtonDown(UserActions action)
	{
		bool flag = _player.GetButtonDown(GetIDForAction(action));
		string text = action.Name;
		if (text == "INTERACT" || text == "DISMANTLE")
		{
			flag &= UsingController || !EventSystem.current.IsPointerOverGameObject();
		}
		if (flag)
		{
			_lastInputDevice = GetDeviceForAction(action);
		}
		return flag;
	}

	public bool GetButtonUp(UserActions action)
	{
		return _player.GetButtonUp(GetIDForAction(action));
	}

	public bool GetButtonTap(UserActions action, bool ignoreKeyboard = false)
	{
		if (!_player.GetButtonUp(GetIDForAction(action)))
		{
			return false;
		}
		bool flag = _player.GetButtonTimePressed(GetIDForAction(action)) < (double)quickPressMaxTime;
		if (flag & ignoreKeyboard)
		{
			flag &= GetActionSource(action.Value) != ControllerType.Keyboard;
		}
		if (flag)
		{
			_lastInputDevice = GetDeviceForAction(action);
		}
		return flag;
	}

	public bool GetAnyButton()
	{
		return _player.GetAnyButton();
	}

	public bool GetDoubleClick(UserActions action)
	{
		return _player.GetButtonDoublePressDown(GetIDForAction(action));
	}

	public float GetAxis(MovementAxis axis)
	{
		if (_disabled)
		{
			return 0f;
		}
		float axis2 = _player.GetAxis(GetIDForAxis(axis));
		if (axis2 != 0f)
		{
			_lastInputDevice = GetDeviceForAction(axis);
		}
		return axis2;
	}

	public string GetAxisName(MovementAxis axis)
	{
		ActionElementMap actionElementMap = GetActionElementMap(axis.ToString());
		if (actionElementMap != null)
		{
			return actionElementMap.elementIdentifierName;
		}
		return "";
	}

	public string GetButtonName(UserActions action)
	{
		ActionElementMap actionElementMap = GetActionElementMap(action.Value);
		if (actionElementMap != null)
		{
			return actionElementMap.elementIdentifierName;
		}
		return "";
	}

	public Sprite GetIconForAction(UserActions action)
	{
		InputDevice device = ((!UsingController) ? InputDevice.Mouse : InputDevice.Joystick);
		return _glyphs.GetGlyph(GetIDForAction(action), device);
	}

	public float GetRawAxis(MovementAxis axis)
	{
		return _player.GetAxisRaw(axis.ToString());
	}

	public float GetRawAxis(UserActions axis)
	{
		return _player.GetAxisRaw(axis.Value);
	}

	public void SetControlMode(Mode mode)
	{
		_currentMode = mode;
		if (_disabled)
		{
			return;
		}
		_inputModule.allowMouseInput = !_settings.UseController;
		Cursor.visible = !_settings.UseController;
		switch (mode)
		{
		case Mode.Gameplay:
			_player.controllers.maps.SetAllMapsEnabled(state: false);
			if (_settings.UseController)
			{
				_player.controllers.maps.SetMapsEnabled(state: true, "GameplayJoy");
			}
			else
			{
				_player.controllers.maps.SetMapsEnabled(state: true, "GameplayMouseKey");
			}
			_player.controllers.maps.SetMapsEnabled(state: true, "Development");
			break;
		case Mode.UI:
			_player.controllers.maps.SetAllMapsEnabled(state: false);
			if (_settings.UseController)
			{
				_player.controllers.maps.SetMapsEnabled(state: true, "UIJoy");
			}
			else
			{
				_player.controllers.maps.SetMapsEnabled(state: true, "UIMouseKey");
			}
			break;
		case Mode.IntroUI:
			_player.controllers.maps.SetAllMapsEnabled(state: false);
			_player.controllers.maps.SetMapsEnabled(state: true, "UIJoy");
			_player.controllers.maps.SetMapsEnabled(state: true, "UIMouseKey");
			break;
		case Mode.Building:
			_player.controllers.maps.SetAllMapsEnabled(state: false);
			if (_settings.UseController)
			{
				_player.controllers.maps.SetMapsEnabled(state: true, "GameplayBuildingJoy");
			}
			else
			{
				_player.controllers.maps.SetMapsEnabled(state: true, "GameplayBuildingMouseKey");
			}
			break;
		case Mode.Dismantling:
			_player.controllers.maps.SetAllMapsEnabled(state: false);
			if (_settings.UseController)
			{
				_player.controllers.maps.SetMapsEnabled(state: true, "GameplayDismantlingJoy");
			}
			else
			{
				_player.controllers.maps.SetMapsEnabled(state: true, "GameplayDismantlingMouseKey");
			}
			break;
		case Mode.DeveloperConsole:
			_player.controllers.maps.SetAllMapsEnabled(state: false);
			_player.controllers.maps.SetMapsEnabled(state: true, "DeveloperConsole");
			break;
		case Mode.BugReportingTool:
			_player.controllers.maps.SetAllMapsEnabled(state: false);
			_player.controllers.maps.SetMapsEnabled(state: true, "BugReportingTool");
			break;
		case Mode.Disabled:
			_player.controllers.maps.SetAllMapsEnabled(state: false);
			_inputModule.allowMouseInput = false;
			break;
		}
		Events.RaiseEvent("SettingsChanged");
	}

	public void DisableControls(float time)
	{
		if (_disableControlsRoutine != null)
		{
			StopCoroutine(_disableControlsRoutine);
		}
		_player.controllers.maps.SetAllMapsEnabled(state: false);
		_disabled = true;
		_disableControlsRoutine = StartCoroutine(EnableAfterDelayRoutine(time));
	}

	private IEnumerator EnableAfterDelayRoutine(float time)
	{
		float timer = 0f;
		while (timer < time)
		{
			timer += Time.unscaledDeltaTime;
			yield return null;
		}
		RestoreControls();
	}

	public void EnableControls()
	{
		if (_disableControlsRoutine != null)
		{
			StopCoroutine(_disableControlsRoutine);
		}
		RestoreControls();
	}

	private void RestoreControls()
	{
		_disabled = false;
		SetControlMode(_currentMode);
	}

	public Mode GetControlMode()
	{
		return _currentMode;
	}

	public bool UsingJoystick()
	{
		return _settings.UseController;
	}

	public void SetInputDevice(InputDevice input)
	{
		bool useController = _settings.UseController;
		switch (input)
		{
		case InputDevice.Joystick:
			SetUseJoystick(useJoystick: true);
			break;
		case InputDevice.Keyboard:
		case InputDevice.Mouse:
			SetUseJoystick(useJoystick: false);
			break;
		default:
			throw new UnityException("No handler for InputDevice of type: " + input);
		}
		if (useController != _settings.UseController)
		{
			Events.RaiseEvent("SettingsChanged");
		}
	}

	private InputDevice GetDeviceForAction(UserActions action)
	{
		switch (GetActionSource(action.Value))
		{
		case ControllerType.Keyboard:
			return InputDevice.Keyboard;
		case ControllerType.Mouse:
			return InputDevice.Mouse;
		case ControllerType.Joystick:
		case ControllerType.Custom:
			return InputDevice.Joystick;
		default:
			return InputDevice.Keyboard;
		}
	}

	private InputDevice GetDeviceForAction(MovementAxis axis)
	{
		switch (GetActionSource(axis.ToString()))
		{
		case ControllerType.Keyboard:
			return InputDevice.Keyboard;
		case ControllerType.Mouse:
			return InputDevice.Mouse;
		case ControllerType.Joystick:
		case ControllerType.Custom:
			return InputDevice.Joystick;
		default:
			return InputDevice.Keyboard;
		}
	}

	public InputDevice GetLastInputDevice()
	{
		return _lastInputDevice;
	}

	public void VibrateController(VibrationMode mode)
	{
		if (GetLastInputDevice() == InputDevice.Joystick && _settings.UseVibration)
		{
			switch (mode)
			{
			case VibrationMode.Short:
				_player.SetVibration(0, 0.75f, 0.1f);
				break;
			case VibrationMode.Long:
				_player.SetVibration(0, 1f, 0.75f);
				break;
			}
		}
	}

	private ActionElementMap GetActionElementMap(string action)
	{
		Controller controller = ((!_settings.UseController) ? _player.controllers.GetController(ControllerType.Keyboard, 0) : _player.controllers.GetController(ControllerType.Joystick, 0));
		InputAction action2 = ReInput.mapping.GetAction(action);
		return _player.controllers.maps.GetFirstElementMapWithAction(controller, action2.id, skipDisabledMaps: true);
	}

	private ControllerType GetActionSource(string action)
	{
		IList<InputActionSourceData> currentInputSources = _player.GetCurrentInputSources(action);
		if (currentInputSources.Count > 0)
		{
			return currentInputSources[0].controllerType;
		}
		Debug.LogWarning("Should not be checking for Action Source on an action that has not occured this frame");
		return ControllerType.Custom;
	}

	private void SetUseJoystick(bool useJoystick)
	{
		_useControllerSwitchFrameProtection = true;
		_settings.SetUseJoystick(useJoystick);
		UsingController = useJoystick;
		Events.RaiseEvent("InputChanged");
	}

	public bool IsMouseOverUIRectTransform(RectTransform rectTransform)
	{
		if (_lastInputDevice == InputDevice.Joystick)
		{
			return true;
		}
		Vector2 point = rectTransform.InverseTransformPoint(Input.mousePosition);
		return rectTransform.rect.Contains(point);
	}

	public bool GetPointerOverUI()
	{
		return EventSystem.current.IsPointerOverGameObject();
	}

	public string GetParameterValue(string Param)
	{
		string result = null;
		if (Param.StartsWith(Constants.INSERT_TOKEN_ACTION_NAME))
		{
			result = StringEnum<UserActions>.GetByName(Param.Split(Constants.LOC_PARAM_TOKEN_SPLITTER)[1]).Value;
		}
		else if (Param.StartsWith(Constants.INSERT_TOKEN_ACTION_ICON))
		{
			string[] array = Param.Split(Constants.LOC_PARAM_TOKEN_SPLITTER);
			string text = array[1];
			string text2 = array[2];
			UserActions byName = StringEnum<UserActions>.GetByName(text);
			if (byName != null)
			{
				int iDForAction = GetIDForAction(byName);
				InputDevice inputDevice = InputDevice.Mouse;
				inputDevice = ((text2 == Constants.TOKEN_PARAM_KEYBOARD) ? InputDevice.Keyboard : ((!(text2 == Constants.TOKEN_PARAM_JOYSTICK)) ? InputDevice.Mouse : InputDevice.Joystick));
				result = _glyphs.GetGlyph(iDForAction, inputDevice).name;
			}
		}
		return result;
	}

	public bool GetStartGameAction()
	{
		for (int i = 0; i < _startGameActions.Count; i++)
		{
			if (_player.GetButtonDown(GetIDForAction(_startGameActions[i])))
			{
				return true;
			}
		}
		return false;
	}

	public bool GetResetMappingsButtonDown()
	{
		if (Input.GetKeyDown(KeyCode.F1))
		{
			return true;
		}
		IList<Joystick> joysticks = _player.controllers.Joysticks;
		for (int i = 0; i < joysticks.Count; i++)
		{
			if (joysticks[i].GetButtonDown(3))
			{
				return true;
			}
		}
		return false;
	}
}
