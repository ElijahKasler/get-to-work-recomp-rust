using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using I2.Loc;
using Isto.Core.Configuration;
using Isto.Core.Game;
using Isto.Core.Localization;
using Isto.Core.UI;
using UnityEngine;
using Zenject;

namespace Isto.Core.Data;

public class AutoSaveManager : MonoBehaviour
{
	public bool disableAutoSaves;

	public float minutesBetweenAutoSaves = 15f;

	public LocalizedString _gameAutoSavedMessageKey;

	public LocalizedString _gameAutoSaveFailedMessageKey;

	public static readonly string SAVE_FREQUENCY_PLAYER_PREFS_KEY = "SaveFrequencySetting";

	protected static readonly int MAX_CONCURRENT_AUTOSAVES = 3;

	protected bool _disabledFromEvents = true;

	private float _autoSaveInterval;

	private float _autoSaveTimer;

	private bool _disabledFromSettings;

	private IGameData _gameData;

	private Settings _settings;

	private IUIMessages _userFeedbackMessages;

	[Inject]
	public void Inject(IGameData gameData, [Inject(Id = UIMessageHandlerType.Message)] IUIMessages messages, Settings settings)
	{
		_gameData = gameData;
		_userFeedbackMessages = messages;
		_settings = settings;
	}

	protected virtual void Awake()
	{
		UpdateAutoSaveSettings();
		_autoSaveInterval = minutesBetweenAutoSaves * 60f;
	}

	protected virtual void Start()
	{
		RegisterEvents();
	}

	protected virtual void OnDestroy()
	{
		UnregisterEvents();
	}

	private void Update()
	{
		if (!disableAutoSaves && !_disabledFromSettings && !_disabledFromEvents && !GameState.StoryAnimationActive)
		{
			_autoSaveTimer += Time.deltaTime;
			if (_autoSaveTimer > _autoSaveInterval)
			{
				ResetAutoSaveTimer();
				CreateAutoSave();
				UpdateAutoSaveSettings();
			}
		}
	}

	private void RegisterEvents()
	{
		Events.Subscribe("GameSaved", OnGameSaved);
		GlobalGameplayEvents.MenuInteraction += OnMenuInteraction;
	}

	private void UnregisterEvents()
	{
		Events.UnSubscribe("GameSaved", OnGameSaved);
		GlobalGameplayEvents.MenuInteraction -= OnMenuInteraction;
	}

	protected void OnCutsceneStarted()
	{
		_disabledFromEvents = true;
	}

	protected void OnCutsceneEnded()
	{
		_disabledFromEvents = false;
	}

	private void OnGameSaved()
	{
		ResetAutoSaveTimer();
	}

	private void OnMenuInteraction(object sender, MenuInteractionEventArgs e)
	{
		if (e.menu == GameMenusEnum.GAME && e.action == MenuInteractionEventArgs.Action.Close)
		{
			UpdateAutoSaveSettings();
		}
	}

	public static int GetAutoSaveFrequencySetting()
	{
		if (!UnityUtils.IsAutoSaveSupported())
		{
			return 3;
		}
		return PlayerPrefs.GetInt(SAVE_FREQUENCY_PLAYER_PREFS_KEY, 2);
	}

	public static void SetAutoSaveFrequencySetting(int value)
	{
		PlayerPrefs.SetInt(SAVE_FREQUENCY_PLAYER_PREFS_KEY, value);
	}

	private IEnumerator GetAutoSaveSlotNumber(Action<int, bool> onNumberFound)
	{
		List<int> slots = null;
		bool waiting = true;
		_gameData.GetAllExistingSaveSlots((List<int> list) =>
		{
			slots = list;
			waiting = false;
		});
		while (waiting)
		{
			yield return null;
		}
		List<Tuple<int, GameStateSaveData>> autoSaves = new List<Tuple<int, GameStateSaveData>>();
		for (int i = 0; i < slots.Count; i++)
		{
			waiting = true;
			GameStateSaveData metaData = null;
			_gameData.LoadGameMetaData(slots[i], (GameStateSaveData loadedData) =>
			{
				metaData = loadedData;
				waiting = false;
			});
			while (waiting)
			{
				yield return null;
			}
			if (metaData != null && metaData.isAutoSave)
			{
				autoSaves.Add(new Tuple<int, GameStateSaveData>(slots[i], metaData));
				if (autoSaves.Count >= MAX_CONCURRENT_AUTOSAVES)
				{
					break;
				}
			}
		}
		if (autoSaves.Count < MAX_CONCURRENT_AUTOSAVES)
		{
			Debug.Log("Autosaves not maxed out, so getting a new autosave slot");
			_gameData.GetLowestAvailableSlotNumber((int number) =>
			{
				bool arg = false;
				if (number == -1 && autoSaves.Count > 0)
				{
					Tuple<int, GameStateSaveData> tuple2 = autoSaves.OrderBy((Tuple<int, GameStateSaveData> x) => x.Item2.saveDate).First();
					Debug.Log("GetLowestAvailableSlotNumber failed to get a new slot, so take an existing autosave slot; choosing #" + tuple2.Item1);
					number = tuple2.Item1;
					arg = true;
				}
				onNumberFound(number, arg);
			});
		}
		else
		{
			Tuple<int, GameStateSaveData> tuple = autoSaves.OrderBy((Tuple<int, GameStateSaveData> x) => x.Item2.saveDate).First();
			Debug.Log("Autosaves maxed out, so taking an existing autosave slot, choosing #" + tuple.Item1);
			onNumberFound(tuple.Item1, arg2: true);
		}
	}

	[ContextMenu("Save Now")]
	public void CreateAutoSave()
	{
		Events.RaiseEvent("GameAutoSaving");
		StartCoroutine(GetAutoSaveSlotNumber((int slotNumber, bool isPreExistingSlot) =>
		{
			if (slotNumber < 0)
			{
				Debug.LogError("Cannot create autosave. ");
				_userFeedbackMessages.CreateMessage(Loc.Get(_gameAutoSaveFailedMessageKey));
			}
			else
			{
				Debug.Log($"Creating autosave in slot#{slotNumber}. ");
				_gameData.SaveGameData(slotNumber, isPreExistingSlot, (bool success) =>
				{
					if (success)
					{
						Events.RaiseEvent("GameSaved");
						_userFeedbackMessages.CreateMessage(Loc.Get(_gameAutoSavedMessageKey));
						_gameData.LoadGameMetaData(slotNumber, (GameStateSaveData metaData) =>
						{
							if (metaData == null)
							{
								Debug.LogError($"LoadGameMetaData failed to load slot#{slotNumber} after saving it");
								_userFeedbackMessages.CreateMessage(Loc.Get(_gameAutoSaveFailedMessageKey));
							}
							else if (!metaData.isAutoSave)
							{
								metaData.isAutoSave = true;
								metaData.saveSlotName = "--AUTOSAVE--";
								_gameData.SaveGameMetaData(slotNumber, metaData, (bool flag) =>
								{
									if (!flag)
									{
										Debug.LogWarning($"SaveGameMetaData for slot#{slotNumber} has failed to save metadata after turning the autosave flag ON ");
									}
								});
							}
						});
					}
					else
					{
						Debug.LogWarning($"SaveGameData failed for slot#{slotNumber} during autosave attempt. ");
						_userFeedbackMessages.CreateMessage(Loc.Get(_gameAutoSaveFailedMessageKey));
					}
				});
			}
		}));
	}

	private void ResetAutoSaveTimer()
	{
		_autoSaveTimer = 0f;
	}

	private void UpdateAutoSaveSettings()
	{
		minutesBetweenAutoSaves = _settings.AutoSaveOptions[GetAutoSaveFrequencySetting()];
		_autoSaveInterval = minutesBetweenAutoSaves * 60f;
		_disabledFromSettings = minutesBetweenAutoSaves == 0f;
	}
}
