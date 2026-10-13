using Isto.Core;
using Isto.Core.Data;
using Isto.Core.Game;
using Isto.GTW.Managers;
using Isto.GTW.Providers;
using UnityEngine;
using Zenject;

namespace Isto.GTW.LevelFeatures.LevelEvents;

[RequireComponent(typeof(LevelTransitionPopupEvent))]
public class DoinklerStageEventTriggerSerializer : LevelEvent
{
	private LevelTransitionPopupEvent _levelTransitionEvent;

	private int _lastTriggeredFrame = -1;

	[Space]
	[Tooltip("Add value field to the current variable value.")]
	[SerializeField]
	private bool _additive;

	[Tooltip("Prevent from setting variable to a new value lower value.")]
	[SerializeField]
	private bool _blockDecrement;

	[Tooltip("Prevent from setting variable to a new value higher value.")]
	[SerializeField]
	private bool _blockIncrement;

	private IGameProgressProvider _gameProgressProvider;

	private DoinklerLevelVariables _doinklerLevelVariables;

	private IGameData _gameData;

	private IDoinklerWorldDefinitionProvider _doinklerWorldDefinitionProvider;

	[Inject]
	public void Inject(IGameProgressProvider gameProgressProvider, DoinklerLevelVariables levelVariables, IGameData gameData, IDoinklerWorldDefinitionProvider doinklerWorldDefinitionProvider)
	{
		_gameProgressProvider = gameProgressProvider;
		_doinklerLevelVariables = levelVariables;
		_gameData = gameData;
		_doinklerWorldDefinitionProvider = doinklerWorldDefinitionProvider;
	}

	protected override void Awake()
	{
		base.Awake();
		_levelTransitionEvent = GetComponent<LevelTransitionPopupEvent>();
	}

	public override void TriggerEvent(bool initialization = false)
	{
		if (_lastTriggeredFrame == Time.frameCount)
		{
			return;
		}
		_lastTriggeredFrame = Time.frameCount;
		int currentGameProgressLevel = _gameProgressProvider.GetCurrentGameProgressLevel();
		float gameSecondsElapsedInLevel = _gameProgressProvider.GetGameSecondsElapsedInLevel(currentGameProgressLevel);
		float num = _doinklerLevelVariables.GetFloat(_levelTransitionEvent.CurrentLevel.UniqueIDBest);
		float num2 = _doinklerLevelVariables.GetFloat(_levelTransitionEvent.CurrentLevel.UniqueIDTotal);
		_doinklerLevelVariables.SetFloat(_levelTransitionEvent.CurrentLevel.UniqueIDTotal, num2 + gameSecondsElapsedInLevel);
		if (num == 0f || gameSecondsElapsedInLevel < num)
		{
			_doinklerLevelVariables.SetFloat(_levelTransitionEvent.CurrentLevel.UniqueIDBest, gameSecondsElapsedInLevel);
		}
		_doinklerLevelVariables.SetBool(_levelTransitionEvent.CurrentLevel.UniqueIDCompleted, value: true);
		int slotNumber = (int)_doinklerWorldDefinitionProvider.Current.SaveSlotId;
		_gameData.SaveGameData(slotNumber, createBackup: false, (bool success) =>
		{
			if (success)
			{
				Events.RaiseEvent("GameSaved");
			}
			else
			{
				Debug.LogError($"SaveGameData for slot#{slotNumber} has failed ");
			}
		});
	}
}
