using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Isto.Core;

public static class Events
{
	public const string GAME_END = "EndOfGame";

	public const string HEART_BOX_ENTER_STATE = "OnHeartEnterState";

	public const string HEART_BOX_TRANSITION_COMPLETE = "OnHeartTransitionComplete";

	public const string PLAYER_INVENTORY_CHANGED_EVENT = "PlayerInventoryChanged";

	public const string PLAYER_INVENTORY_FULL_EVENT = "PlayerInventoryFull";

	public const string RESEARCH_COMPLETE_EVENT = "ResearchComplete";

	public const string SETTINGS_CHANGED = "SettingsChanged";

	public const string SETTINGS_SAVED = "SettingsSaved";

	public const string GAME_AUTOSAVING = "GameAutoSaving";

	public const string GAME_SAVED = "GameSaved";

	public const string PLAYER_DEATH_CUTSCENE_START = "PlayerDeathCutsceneStart";

	public const string PLAYER_DEATH_CUTSCENE_END = "PlayerDeathCutsceneEnd";

	public const string FAST_TRAVEL_START = "FastTravelStart";

	public const string FAST_TRAVEL_END = "FastTravelEnd";

	public const string GAME_START_FADE_IN = "GameStartFadeIn";

	public const string GIANT_CUTSCENE_START = "GiantCutsceneStart";

	public const string GIANT_CUTSCENE_END = "GiantCutsceneEnd";

	public const string THEME_CHANGED = "ThemeChanged";

	public const string PLAYER_SKIN_SET_CHANGED = "PlayerSkinSetChanged";

	public const string PLAYER_SKIN_HAT_CHANGED = "PlayerHatChanged";

	public const string PLAYER_SKIN_BODY_CHANGED = "PlayerBodyChanged";

	public const string MINIDEER_SKIN_CHANGED = "MiniDeerSkinChanged";

	public const string PUSHBACK_SKIN_CHANGED = "PushbackSkinChanged";

	public const string ADVANCED_ITEMS_SKIN_CHANGED = "AdvancedItemsSkinChanged";

	public const string CONTROLLER_INPUT = "ChangeInputToControllerMode";

	public const string MOUSEKEYBOARD_INPUT = "ChangeInputToMouseKeyboardMode";

	public const string INPUT_MODE_CHANGED = "InputChanged";

	public const string LANGUAGE_CHANGED = "LanguageChanged";

	public const string CONTROLS_CHANGED = "ControlsChanged";

	public const string USER_CHANGED = "UserChanged";

	public const string XBOX_INITIALIZED = "XboxInitialized";

	public const string INITIALIZED_HEARTBOX_CONTROLLER = "HeartboxControllerInitialized";

	public const string PLAYER_ANIMATION_SET = "PlayerAnimationTrigger";

	public const string DEVELOPER_COMMAND = "DeveloperCommand";

	public static readonly string PLAYER_ITEM_ACQUIRED = "PlayerItemAcquired";

	public const string SAVE_SPEEDRUN_BUTTON_CLICKED = "SaveSpeedrunButtonClicked";

	private static Dictionary<string, List<OrderedParamEvent>> _paramListeners = new Dictionary<string, List<OrderedParamEvent>>();

	private static Dictionary<string, List<OrderedEvent>> _listeners = new Dictionary<string, List<OrderedEvent>>();

	public static void Subscribe(string eventName, OrderedEvent.GameEvent del, int priority = 100)
	{
		List<OrderedEvent> list;
		if (!_listeners.ContainsKey(eventName))
		{
			list = new List<OrderedEvent>();
			_listeners.Add(eventName, list);
		}
		else
		{
			list = _listeners[eventName];
		}
		list.Add(new OrderedEvent(del, priority));
		_listeners[eventName] = list.OrderBy((OrderedEvent x) => x.priority).ToList();
	}

	public static void SubscribeWithParams(string eventName, OrderedParamEvent.ParamGameEvent del, int priority = 100)
	{
		List<OrderedParamEvent> list;
		if (!_paramListeners.ContainsKey(eventName))
		{
			list = new List<OrderedParamEvent>();
			_paramListeners.Add(eventName, list);
		}
		else
		{
			list = _paramListeners[eventName];
		}
		list.Add(new OrderedParamEvent(del, priority));
		_paramListeners[eventName] = list.OrderBy((OrderedParamEvent x) => x.priority).ToList();
	}

	public static void UnSubscribe(string eventName, OrderedEvent.GameEvent del)
	{
		if (_listeners.ContainsKey(eventName))
		{
			List<OrderedEvent> list = _listeners[eventName];
			OrderedEvent orderedEvent = list.Find((OrderedEvent x) => x.callback == del);
			if (orderedEvent != null)
			{
				list.Remove(orderedEvent);
			}
			_listeners[eventName] = list;
		}
	}

	public static void UnSubscribeWithParams(string eventName, OrderedParamEvent.ParamGameEvent del)
	{
		if (_paramListeners.ContainsKey(eventName) && _paramListeners[eventName].Count > 0)
		{
			List<OrderedParamEvent> list = _paramListeners[eventName];
			OrderedParamEvent orderedParamEvent = list.Find((OrderedParamEvent x) => x.callback == del);
			if (orderedParamEvent != null)
			{
				list.Remove(orderedParamEvent);
			}
			else
			{
				Debug.LogWarningFormat("Trying to remove event listener {0} that is not registered to event {1}", del.ToString(), eventName);
			}
			_paramListeners[eventName] = list;
		}
		else
		{
			Debug.LogWarningFormat("Trying to remove event listener {0} that is not registered to event {1}", del.ToString(), eventName);
		}
	}

	public static void RaiseEvent(string eventName)
	{
		if (_listeners.ContainsKey(eventName) && _listeners[eventName].Count > 0)
		{
			List<OrderedEvent> list = _listeners[eventName];
			for (int i = 0; i < list.Count; i++)
			{
				list[i].callback();
			}
		}
	}

	public static void RaiseEvent(string eventName, params object[] args)
	{
		if (_paramListeners.ContainsKey(eventName) && _paramListeners[eventName].Count > 0)
		{
			List<OrderedParamEvent> list = _paramListeners[eventName];
			for (int i = 0; i < list.Count; i++)
			{
				list[i].callback(args);
			}
		}
	}

	public static void RaiseEvent<T>(string eventName, T args)
	{
		if (_paramListeners.ContainsKey(eventName) && _paramListeners[eventName].Count > 0)
		{
			List<OrderedParamEvent> list = _paramListeners[eventName];
			for (int i = 0; i < list.Count; i++)
			{
				list[i].callback(args);
			}
		}
	}
}
