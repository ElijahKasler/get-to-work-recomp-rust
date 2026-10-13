using System;
using System.Collections;
using System.Collections.Generic;
using Isto.Core.Inputs;
using Rewired;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Isto.Core.UI;

public abstract class UIControlRebindingBase : MonoBehaviour
{
	private struct TargetMapping
	{
		public ControllerMap controllerMap;

		public int actionElementMapId;
	}

	[Header("Display")]
	[SerializeField]
	protected TextMeshProUGUI _labelTextbox;

	[SerializeField]
	protected TextMeshProUGUI _controlKeyTextbox;

	[SerializeField]
	protected Image _keyImage;

	[SerializeField]
	protected Sprite _glyphOverride;

	[Header("Interaction")]
	[SerializeField]
	protected UISettingsSelectable _rebindButton;

	[Header("Action Settings")]
	[SerializeField]
	protected bool _isKeyboardAndMouse;

	[SerializeField]
	protected bool _allowForControllerTriggers;

	[SerializeField]
	protected Controls.InputDevice _device;

	[SerializeField]
	protected Controls.RewiredCategory _category;

	[Tooltip("Other categories that also contain this action and should always be using the same input as this action")]
	[SerializeField]
	protected List<Controls.RewiredCategory> _pairedCategories;

	protected int _actionId;

	protected ActionElementMap _aem;

	protected Sprite _cachedSprite;

	protected InputMapper.ConflictFoundEventData _conflictData;

	protected UISettingsControlsSubState _controlsSettings;

	protected bool _isInitialized;

	protected ControllerMap _map;

	protected bool _pollingForKeypress;

	private TargetMapping _replaceTargetMapping;

	protected Guid DEFAULT_CONTROLLER_GUID = new Guid("19002688-7406-4f4a-8340-8d25335406c8");

	private static readonly int LEFT_TRIGGER_ELEMENT_IDENTIFIER_ID = 4;

	private static readonly int RIGHT_TRIGGER_ELEMENT_IDENTIFIER_ID = 5;

	private static readonly List<UserActions> FORBIDDEN_ACTIONS_CONTROLLER = new List<UserActions>
	{
		UserActions.UIHORIZONTAL,
		UserActions.UIVERTICAL,
		UserActions.UISUBMIT,
		UserActions.UICANCEL,
		UserActions.TOGGLEGAMEMENU,
		UserActions.TOGGLEDEVCONSOLE,
		UserActions.CANCELDISMANTLING
	};

	private static readonly List<UserActions> FORBIDDEN_ACTIONS_KEYBOARD = new List<UserActions>
	{
		UserActions.TOGGLEGAMEMENU,
		UserActions.PAUSE,
		UserActions.TOGGLEDEVCONSOLE,
		UserActions.CANCELBUILDING,
		UserActions.CANCELDISMANTLING,
		UserActions.UIMODIFIERACTION
	};

	private static readonly List<Controls.MovementAxis> FORBIDDEN_AXES = new List<Controls.MovementAxis>
	{
		Controls.MovementAxis.UIHorizontal,
		Controls.MovementAxis.UIVertical,
		Controls.MovementAxis.UISecondaryHorizontal,
		Controls.MovementAxis.UISecondaryVertical
	};

	private string _cachedXML;

	private InputMapper _primaryInputMapper;

	private InputMapper _secondaryInputMapper;

	private Controls _controls;

	private ControllerGlyphs _glyphs;

	public abstract string InputActionName { get; }

	public abstract bool IsAxis { get; }

	public virtual AxisRange ActionAxisRange => AxisRange.Full;

	public virtual Pole AxisDirection => Pole.Positive;

	public string ActionName => _labelTextbox.text;

	protected UISettingsSelectable Button => _rebindButton;

	private bool IsRebindingForJoystick => _device == Controls.InputDevice.Joystick;

	[Inject]
	public void Inject(IControls controls, ControllerGlyphs glyphs)
	{
		_controls = controls as Controls;
		_glyphs = glyphs;
	}

	public void Awake()
	{
		_controlsSettings = GetComponentInParent<UISettingsControlsSubState>();
		if (_pairedCategories == null)
		{
			_pairedCategories = new List<Controls.RewiredCategory>();
		}
		if (!_pairedCategories.Contains(_category))
		{
			_pairedCategories.Add(_category);
		}
	}

	private void OnEnable()
	{
		_isInitialized = false;
	}

	private void InputMapper_OnConflictFound(InputMapper.ConflictFoundEventData data)
	{
		_ = data.conflicts.Count;
		_ = 1;
		_conflictData = data;
		if (IsToBeIgnored(data))
		{
			data.responseCallback(InputMapper.ConflictResponse.Replace);
			_pollingForKeypress = false;
		}
		else if (IsDataProtected(data.isProtected, data.conflicts))
		{
			data.responseCallback(InputMapper.ConflictResponse.Cancel);
			QuitRebindingImmediate();
			_controlsSettings.ShowBindingForbiddenPopup(SelectControllerRebind);
		}
		else
		{
			for (int i = 0; i < data.conflicts.Count; i++)
			{
				if (data.conflicts[i].controllerMap != _map && (!_isKeyboardAndMouse || (data.conflicts[i].controllerMap.controllerType != ControllerType.Keyboard && data.conflicts[i].controllerMap.controllerType != ControllerType.Mouse)))
				{
					continue;
				}
				if (_isKeyboardAndMouse)
				{
					if (data.conflicts[i].controllerMap.controllerType == ControllerType.Keyboard)
					{
						_secondaryInputMapper.Stop();
					}
					if (data.conflicts[i].controllerMap.controllerType == ControllerType.Mouse)
					{
						_primaryInputMapper.Stop();
					}
				}
				ElementAssignmentConflictInfo conflictInfo = data.conflicts[i];
				if (IsNewBindingValid(conflictInfo.elementMap))
				{
					ShowConflictInformationPopUp(conflictInfo);
					return;
				}
				QuitRebindingImmediate();
				DeleteMapping(conflictInfo.elementMap);
				ApplyCachedControllerMap();
				_controlsSettings.ShowOverrideFailedPopup(SelectControllerRebind);
				return;
			}
		}
		_pollingForKeypress = false;
	}

	private void InputMapper_OnInputMapped(InputMapper.InputMappedEventData data)
	{
		QuitRebindingImmediate();
		if (CanBeAppliedToAllPairedCategories(data))
		{
			if (TryClearConflictCollaterals(data))
			{
				ApplyToPairedCategories(data);
			}
			else
			{
				DeleteMapping(data.actionElementMap);
				ApplyCachedControllerMap();
				_controlsSettings.ShowOverrideFailedPopup(SelectControllerRebind);
			}
		}
		else
		{
			DeleteMapping(data.actionElementMap);
			ApplyCachedControllerMap();
			_controlsSettings.ShowOverrideFailedPopup(SelectControllerRebind);
		}
		if (_isKeyboardAndMouse && _replaceTargetMapping.controllerMap != null && data.actionElementMap.controllerMap != _replaceTargetMapping.controllerMap)
		{
			_replaceTargetMapping.controllerMap.DeleteElementMap(_replaceTargetMapping.actionElementMapId);
			_device = GetInputDevice(data.actionElementMap.controllerMap.controllerType);
		}
	}

	private Controls.InputDevice GetInputDevice(ControllerType controllerType)
	{
		Controls.InputDevice result = Controls.InputDevice.Joystick;
		switch (controllerType)
		{
		case ControllerType.Keyboard:
			result = Controls.InputDevice.Keyboard;
			break;
		case ControllerType.Mouse:
			result = Controls.InputDevice.Mouse;
			break;
		}
		return result;
	}

	private void InputMapper_OnTimedOut(InputMapper.TimedOutEventData timedOutEventData)
	{
		QuitRebindingImmediate();
		RefreshDisplay();
	}

	private bool InputMapper_IsElementValid(ControllerPollingInfo info)
	{
		if (!_pollingForKeypress)
		{
			return false;
		}
		if (_device == Controls.InputDevice.Keyboard || _device == Controls.InputDevice.Mouse)
		{
			if (info.keyboardKey == KeyCode.Escape || info.keyboardKey == KeyCode.Tab || info.elementType == ControllerElementType.Axis)
			{
				return false;
			}
		}
		else
		{
			if (info.controllerType != ControllerType.Joystick && info.controllerType != ControllerType.Custom)
			{
				return false;
			}
			if (IsAxis)
			{
				if (info.elementType != ControllerElementType.Axis)
				{
					return false;
				}
			}
			else if (info.elementType == ControllerElementType.Axis && (!_allowForControllerTriggers || (info.elementIdentifierId != LEFT_TRIGGER_ELEMENT_IDENTIFIER_ID && info.elementIdentifierId != RIGHT_TRIGGER_ELEMENT_IDENTIFIER_ID)))
			{
				QuitRebindingImmediate();
				_controlsSettings.ShowBindingForbiddenPopup(SelectControllerRebind);
				return false;
			}
		}
		return true;
	}

	private void ControlSettings_OnConflictPopUpClosed(bool replaceBinding)
	{
		_pollingForKeypress = false;
		SelectControllerRebind();
		if (replaceBinding)
		{
			_conflictData.responseCallback(InputMapper.ConflictResponse.Replace);
		}
		else
		{
			_conflictData.responseCallback(InputMapper.ConflictResponse.Cancel);
		}
		_controlsSettings.RefreshControlUIState();
	}

	protected ControllerMap GetControllerMapForCategory(Controls.RewiredCategory category)
	{
		Controller actionController = GetActionController();
		Player player = ReInput.players.GetPlayer(Controls.DEFAULT_REWIRED_PLAYER_ID);
		ControllerMap controllerMap = null;
		if (_isKeyboardAndMouse)
		{
			for (int i = 0; i < 2; i++)
			{
				ControllerType controllerType = ((i != 0) ? ControllerType.Mouse : ControllerType.Keyboard);
				ControllerMap map = player.controllers.maps.GetMap(controllerType, 0, category.ToString(), "Default");
				foreach (ActionElementMap item in map.ElementMapsWithAction(_actionId))
				{
					if (item.ShowInField(AxisRange.Full))
					{
						controllerMap = map;
						_device = GetInputDevice(controllerType);
						break;
					}
				}
				if (controllerMap != null)
				{
					break;
				}
			}
		}
		if (actionController == null)
		{
			controllerMap = ReInput.mapping.GetJoystickMapInstance(DEFAULT_CONTROLLER_GUID, category.ToString(), "Default");
		}
		else if (controllerMap == null)
		{
			controllerMap = player.controllers.maps.GetMap(actionController, category.ToString(), "Default");
		}
		return controllerMap;
	}

	protected Sprite GetGlyphForAction(ActionElementMap aem)
	{
		return _device switch
		{
			Controls.InputDevice.Joystick => GetJoystickGlyph(aem), 
			Controls.InputDevice.Mouse => GetMouseOrKeyboardGlyph(aem), 
			_ => _glyphs.GetKeyboardGlyph(aem.elementIdentifierId), 
		};
	}

	protected ActionElementMap GetFirstElementMapFromControllerMap(ControllerMap controllerMap, string actionName, Pole axisDirection = Pole.Positive)
	{
		ActionElementMap[] elementMapsWithAction = controllerMap.GetElementMapsWithAction(actionName);
		foreach (ActionElementMap actionElementMap in elementMapsWithAction)
		{
			if (actionElementMap.axisContribution == axisDirection)
			{
				return actionElementMap;
			}
		}
		return null;
	}

	private bool IsDataProtected(bool isProtected, IList<ElementAssignmentConflictInfo> conflicts)
	{
		if (isProtected)
		{
			return true;
		}
		foreach (ElementAssignmentConflictInfo conflict in conflicts)
		{
			if (IsActionForbidden(conflict.action))
			{
				return true;
			}
			if (IsAxisForbidden(conflict.action))
			{
				return true;
			}
		}
		return false;
	}

	private bool IsActionForbidden(InputAction action)
	{
		List<UserActions> list = (IsRebindingForJoystick ? FORBIDDEN_ACTIONS_CONTROLLER : FORBIDDEN_ACTIONS_KEYBOARD);
		for (int i = 0; i < list.Count; i++)
		{
			int iDForAction = _controls.GetIDForAction(list[i]);
			if (action.id == iDForAction)
			{
				return true;
			}
		}
		return false;
	}

	private bool IsAxisForbidden(InputAction action)
	{
		if (!IsRebindingForJoystick)
		{
			return false;
		}
		for (int i = 0; i < FORBIDDEN_AXES.Count; i++)
		{
			int iDForAxis = _controls.GetIDForAxis(FORBIDDEN_AXES[i]);
			if (action.id == iDForAxis)
			{
				return true;
			}
		}
		return false;
	}

	private bool IsToBeIgnored(InputMapper.ConflictFoundEventData data)
	{
		List<ElementAssignmentConflictInfo> list = new List<ElementAssignmentConflictInfo>();
		foreach (ElementAssignmentConflictInfo conflict in data.conflicts)
		{
			if (conflict.actionId == _controls.GetIDForAction(UserActions.FORCEGC))
			{
				list.Add(conflict);
			}
			else if (conflict.keyCode == KeyCode.Semicolon && conflict.actionId == _controls.GetIDForAction(UserActions.TOGGLEDEVCONSOLE))
			{
				list.Add(conflict);
			}
		}
		if (data.conflicts.Count == list.Count)
		{
			return true;
		}
		for (int i = 0; i < list.Count; i++)
		{
			data.conflicts.Remove(list[i]);
		}
		return false;
	}

	private bool IsConflictInSameMap(InputMapper.ConflictFoundEventData data)
	{
		for (int i = 0; i < data.conflicts.Count; i++)
		{
			if (data.conflicts[i].controllerMap == _map)
			{
				return true;
			}
		}
		return false;
	}

	private ElementAssignmentConflictInfo GetFakeConflictInfoFromMapping(ActionElementMap mapping)
	{
		return new ElementAssignmentConflictInfo(false, true, 0, ControllerType.Custom, 0, mapping.controllerMap.id, 0, mapping.actionId, mapping.elementType, mapping.elementIdentifierId, mapping.keyCode, mapping.modifierKeyFlags);
	}

	private ElementAssignment GetAssignmentFromMapping(ActionElementMap mapping)
	{
		return new ElementAssignment
		{
			actionId = mapping.actionId,
			axisContribution = mapping.axisContribution,
			axisRange = mapping.axisRange,
			elementIdentifierId = mapping.elementIdentifierId,
			invert = mapping.invert,
			keyboardKey = mapping.keyCode,
			modifierKeyFlags = mapping.modifierKeyFlags
		};
	}

	private Controller GetActionController()
	{
		Player player = ReInput.players.GetPlayer(Controls.DEFAULT_REWIRED_PLAYER_ID);
		Controller controller;
		switch (_device)
		{
		case Controls.InputDevice.Joystick:
			controller = player.controllers.GetController(ControllerType.Joystick, 0);
			break;
		case Controls.InputDevice.Mouse:
			controller = player.controllers.GetController(ControllerType.Mouse, 0);
			if (controller == null)
			{
				controller = player.controllers.GetController(ControllerType.Keyboard, 0);
			}
			break;
		case Controls.InputDevice.Keyboard:
			controller = player.controllers.GetController(ControllerType.Keyboard, 0);
			break;
		default:
			Debug.LogError("Unhandled case for get controller for remapping. Device:" + _device, base.gameObject);
			controller = player.controllers.Keyboard;
			break;
		}
		return controller;
	}

	private Sprite GetJoystickGlyph(ActionElementMap aem)
	{
		Controller actionController = GetActionController();
		Sprite sprite = ((actionController == null) ? _glyphs.GetJoystickGlyph(DEFAULT_CONTROLLER_GUID, aem.elementIdentifierId, aem.axisRange) : _glyphs.GetJoystickGlyph(actionController.hardwareTypeGuid, aem.elementIdentifierId, aem.axisRange));
		if (sprite == null)
		{
			sprite = _glyphs.GetDefaultControllerGlyph();
		}
		return sprite;
	}

	private Sprite GetMouseOrKeyboardGlyph(ActionElementMap aem)
	{
		Sprite sprite = _glyphs.GetMouseGlyph(aem.elementIdentifierId);
		if (sprite == null)
		{
			sprite = _glyphs.GetKeyboardGlyph(aem.elementIdentifierId);
		}
		return sprite;
	}

	public abstract void RefreshDisplay();

	public void BindingButtonClicked()
	{
		if (_controlsSettings.CurrentDevice == UISettingsControlsSubState.TargetInputDevice.Controller && !_controls.IsControllerAvailable)
		{
			_controlsSettings.ShowControllerRequiredPopup(SelectControllerRebind);
		}
		else
		{
			if (_pollingForKeypress)
			{
				return;
			}
			if (_isKeyboardAndMouse)
			{
				Player player = ReInput.players.GetPlayer(Controls.DEFAULT_REWIRED_PLAYER_ID);
				ControllerMap map = player.controllers.maps.GetMap(ControllerType.Keyboard, 0, _category.ToString(), "Default");
				ControllerMap map2 = player.controllers.maps.GetMap(ControllerType.Mouse, 0, _category.ToString(), "Default");
				ControllerMap controllerMap = null;
				if (_aem != null)
				{
					if (map.ContainsElementMap(_aem.id))
					{
						controllerMap = map;
					}
					else if (map2.ContainsElementMap(_aem.id))
					{
						controllerMap = map2;
					}
					_replaceTargetMapping = new TargetMapping
					{
						actionElementMapId = _aem.id,
						controllerMap = controllerMap
					};
				}
				StartCoroutine(PollForKeyboardAndMousePress(map, map2));
			}
			else
			{
				StartCoroutine(PollForKeyPress());
			}
		}
	}

	public void ClearRebindingCache()
	{
		_isInitialized = false;
		RefreshDisplay();
	}

	private IEnumerator PollForKeyPress()
	{
		_pollingForKeypress = true;
		_controlsSettings.ShowRebindingPopUp(ActionName);
		_conflictData = null;
		AxisRange actionAxisRange = ActionAxisRange;
		InputMapper.Context context = new InputMapper.Context
		{
			actionId = _actionId,
			controllerMap = _map,
			actionRange = actionAxisRange,
			actionElementMapToReplace = _aem
		};
		_cachedXML = _map.ToXmlString();
		SetupInputMapper(context);
		while (_pollingForKeypress)
		{
			if (Input.GetKeyDown(KeyCode.Escape))
			{
				QuitRebindingImmediate();
			}
			_controlsSettings.SetRebindingTimeRemaining(_primaryInputMapper.timeRemaining);
			yield return null;
		}
		SelectControllerRebind();
	}

	private IEnumerator PollForKeyboardAndMousePress(ControllerMap keyboardMap, ControllerMap mouseMap)
	{
		_pollingForKeypress = true;
		_controlsSettings.ShowRebindingPopUp(ActionName);
		_conflictData = null;
		AxisRange actionAxisRange = ActionAxisRange;
		InputMapper.Context keyboardContext = new InputMapper.Context
		{
			actionId = _actionId,
			controllerMap = keyboardMap,
			actionRange = actionAxisRange,
			actionElementMapToReplace = ((_aem == null) ? null : keyboardMap.GetElementMap(_aem.id))
		};
		InputMapper.Context mouseContext = new InputMapper.Context
		{
			actionId = _actionId,
			controllerMap = mouseMap,
			actionRange = actionAxisRange,
			actionElementMapToReplace = ((_aem == null) ? null : mouseMap.GetElementMap(_aem.id))
		};
		_cachedXML = _map.ToXmlString();
		SetupInputMappers(keyboardContext, mouseContext);
		while (_pollingForKeypress)
		{
			if (Input.GetKeyDown(KeyCode.Escape))
			{
				QuitRebindingImmediate();
			}
			_controlsSettings.SetRebindingTimeRemaining(_primaryInputMapper.timeRemaining);
			yield return null;
		}
		SelectControllerRebind();
	}

	private void SetupInputMapper(InputMapper.Context context)
	{
		if (_primaryInputMapper != null)
		{
			TearDownInputMapper(_primaryInputMapper);
		}
		_primaryInputMapper = GetUpInputMapper();
		_primaryInputMapper.Start(context);
	}

	private void SetupInputMappers(InputMapper.Context keyboardContext, InputMapper.Context mouseContext)
	{
		if (_primaryInputMapper != null)
		{
			TearDownInputMapper(_primaryInputMapper);
		}
		if (_secondaryInputMapper != null)
		{
			TearDownInputMapper(_secondaryInputMapper);
		}
		_primaryInputMapper = GetUpInputMapper();
		_secondaryInputMapper = GetUpInputMapper();
		_primaryInputMapper.Start(keyboardContext);
		_secondaryInputMapper.Start(mouseContext);
	}

	private InputMapper GetUpInputMapper()
	{
		InputMapper inputMapper = new InputMapper();
		inputMapper.options.ignoreMouseXAxis = true;
		inputMapper.options.ignoreMouseYAxis = true;
		inputMapper.options.isElementAllowedCallback = InputMapper_IsElementValid;
		inputMapper.options.allowKeyboardModifierKeyAsPrimary = true;
		inputMapper.options.allowKeyboardKeysWithModifiers = false;
		inputMapper.options.timeout = 5f;
		inputMapper.ConflictFoundEvent += InputMapper_OnConflictFound;
		inputMapper.InputMappedEvent += InputMapper_OnInputMapped;
		inputMapper.TimedOutEvent += InputMapper_OnTimedOut;
		return inputMapper;
	}

	private void TearDownInputMapper(InputMapper inputMapper)
	{
		inputMapper.ConflictFoundEvent -= InputMapper_OnConflictFound;
		inputMapper.InputMappedEvent -= InputMapper_OnInputMapped;
		inputMapper.TimedOutEvent -= InputMapper_OnTimedOut;
		inputMapper.Stop();
	}

	private void DeleteMapping(ActionElementMap mapping)
	{
		GetControllerMapForCategory(_category)?.DeleteElementMap(mapping.id);
	}

	private void ApplyCachedControllerMap()
	{
		Player player = ReInput.players.GetPlayer(Controls.DEFAULT_REWIRED_PLAYER_ID);
		Controller actionController = GetActionController();
		ControllerMap map = ControllerMap.CreateFromXml(actionController.type, _cachedXML);
		player.controllers.maps.AddMap(actionController, map);
	}

	private bool CanBeAppliedToAllPairedCategories(InputMapper.InputMappedEventData data)
	{
		return IsNewBindingValid(data.actionElementMap);
	}

	private bool IsNewBindingValid(ActionElementMap newBinding)
	{
		bool result = true;
		foreach (Controls.RewiredCategory pairedCategory in _pairedCategories)
		{
			if (pairedCategory == _category)
			{
				continue;
			}
			ControllerMap controllerMapForCategory = GetControllerMapForCategory(pairedCategory);
			if (controllerMapForCategory == null)
			{
				continue;
			}
			List<ActionElementMap> list = new List<ActionElementMap>();
			controllerMapForCategory.GetElementMapMatches((ActionElementMap x) => x.elementIdentifierName == newBinding.elementIdentifierName, list);
			foreach (ActionElementMap item in list)
			{
				if (IsDataProtected(isProtected: false, new List<ElementAssignmentConflictInfo> { GetFakeConflictInfoFromMapping(item) }))
				{
					result = false;
					return result;
				}
			}
		}
		return result;
	}

	private bool TryClearConflictCollaterals(InputMapper.InputMappedEventData data)
	{
		bool result = true;
		if (_conflictData == null || _conflictData.conflicts.Count == 0)
		{
			return result;
		}
		foreach (ElementAssignmentConflictInfo conflict in _conflictData.conflicts)
		{
			UIControlRebindingBase controlRebinder = _controlsSettings.GetControlRebinder(conflict.action.name, AxisDirection);
			List<Controls.RewiredCategory> list = controlRebinder?._pairedCategories;
			if (list == null || list.Count <= 0)
			{
				continue;
			}
			foreach (Controls.RewiredCategory item in list)
			{
				ControllerMap controllerMapForCategory = GetControllerMapForCategory(item);
				if (controllerMapForCategory != null)
				{
					string inputActionName = controlRebinder.InputActionName;
					ActionElementMap firstElementMapWithAction = controllerMapForCategory.GetFirstElementMapWithAction(inputActionName);
					if (firstElementMapWithAction != null && IsDataProtected(isProtected: false, new List<ElementAssignmentConflictInfo> { GetFakeConflictInfoFromMapping(firstElementMapWithAction) }))
					{
						result = false;
						return result;
					}
				}
			}
		}
		if (_device != Controls.InputDevice.Keyboard)
		{
			foreach (ElementAssignmentConflictInfo conflict2 in _conflictData.conflicts)
			{
				UIControlRebindingBase controlRebinder2 = _controlsSettings.GetControlRebinder(conflict2.action.name, AxisDirection);
				List<Controls.RewiredCategory> list2 = controlRebinder2?._pairedCategories;
				if (list2 == null || list2.Count <= 0)
				{
					continue;
				}
				foreach (Controls.RewiredCategory item2 in list2)
				{
					ControllerMap controllerMapForCategory2 = GetControllerMapForCategory(item2);
					if (controllerMapForCategory2 != null)
					{
						string inputActionName2 = controlRebinder2.InputActionName;
						ActionElementMap firstElementMapWithAction2 = controllerMapForCategory2.GetFirstElementMapWithAction(inputActionName2);
						if (firstElementMapWithAction2 != null)
						{
							controllerMapForCategory2.DeleteElementMap(firstElementMapWithAction2.id);
						}
					}
				}
			}
		}
		return result;
	}

	private void ApplyToPairedCategories(InputMapper.InputMappedEventData data)
	{
		ActionElementMap newBinding = data.actionElementMap;
		foreach (Controls.RewiredCategory pairedCategory in _pairedCategories)
		{
			if (pairedCategory == _category)
			{
				continue;
			}
			ControllerMap controllerMapForCategory = GetControllerMapForCategory(pairedCategory);
			if (controllerMapForCategory == null)
			{
				continue;
			}
			List<ActionElementMap> list = new List<ActionElementMap>();
			controllerMapForCategory.GetElementMapMatches((ActionElementMap x) => x.elementIdentifierName == newBinding.elementIdentifierName, list);
			if (list.Count > 0)
			{
				foreach (ActionElementMap item in list)
				{
					controllerMapForCategory.DeleteElementMap(item.id);
				}
			}
			ActionElementMap result = GetFirstElementMapFromControllerMap(controllerMapForCategory, InputActionName, AxisDirection);
			if (result == null)
			{
				if (!controllerMapForCategory.CreateElementMap(GetAssignmentFromMapping(newBinding), out result))
				{
					Debug.LogError($"Could not create new action element map for {InputActionName} in category {pairedCategory}");
				}
			}
			else if (_device == Controls.InputDevice.Keyboard)
			{
				result.keyCode = newBinding.keyCode;
				result.keyboardKeyCode = newBinding.keyboardKeyCode;
				result.axisContribution = newBinding.axisContribution;
			}
			else
			{
				result.elementIdentifierId = newBinding.elementIdentifierId;
			}
		}
	}

	private void ShowConflictInformationPopUp(ElementAssignmentConflictInfo conflictInfo)
	{
		StopAllCoroutines();
		_controlsSettings.HideRebindingPopUp();
		_controlsSettings.ShowConflictPopUp(conflictInfo, ControlSettings_OnConflictPopUpClosed);
	}

	private void QuitRebindingImmediate()
	{
		_pollingForKeypress = false;
		TearDownInputMapper(_primaryInputMapper);
		if (_isKeyboardAndMouse)
		{
			TearDownInputMapper(_secondaryInputMapper);
		}
		_controlsSettings.HideRebindingPopUp();
	}

	private void SelectControllerRebind()
	{
		_controlsSettings.RefreshControlUIState();
		if (Controls.UsingController)
		{
			_rebindButton.Select();
		}
	}
}
