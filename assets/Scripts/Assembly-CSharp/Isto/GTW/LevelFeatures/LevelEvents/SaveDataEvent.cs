using System.Collections;
using Isto.Core;
using Isto.Core.Data;
using Isto.Core.Game;
using Isto.GTW.Configuration;
using Isto.GTW.Managers;
using Isto.GTW.Providers;
using UnityEngine;
using Zenject;

namespace Isto.GTW.LevelFeatures.LevelEvents;

public class SaveDataEvent : LevelEvent
{
	[SerializeField]
	private bool _asyncSave = true;

	private IGameData _gameData;

	private GTWGameState _gameState;

	private GTWProgressProvider _gameProgressProvider;

	private DoinklerLevelVariables _doinklerLevelVariables;

	private IDoinklerWorldDefinitionProvider _doinklerWorldDefinitionProvider;

	[Inject]
	public void Inject(IGameData gameData, GTWGameState gameState, IGameProgressProvider gameProgressProvider, DoinklerLevelVariables doinklerLevelVariables, IDoinklerWorldDefinitionProvider doinklerWorldDefinitionProvider)
	{
		_gameData = gameData;
		_gameState = gameState;
		_gameProgressProvider = gameProgressProvider as GTWProgressProvider;
		_doinklerLevelVariables = doinklerLevelVariables;
		_doinklerWorldDefinitionProvider = doinklerWorldDefinitionProvider;
	}

	public override void TriggerEvent(bool initialization = false)
	{
		StartCoroutine(AutoSave());
	}

	private IEnumerator AutoSave()
	{
		int currentGameProgressLevel = _gameProgressProvider.GetCurrentGameProgressLevel();
		float gameSecondsElapsedInLevel = _gameProgressProvider.GetGameSecondsElapsedInLevel(currentGameProgressLevel);
		if (!_gameState.IsDoinklerSpecial)
		{
			_gameProgressProvider.GameTime[currentGameProgressLevel] = 0f;
		}
		GTWGameLevelDefinition gTWGameLevelDefinition = _gameState.GameLevelDefinition ?? _doinklerWorldDefinitionProvider.Current.GameLevels[currentGameProgressLevel];
		float num = _doinklerLevelVariables.GetFloat(gTWGameLevelDefinition.UniqueIDTotal);
		_doinklerLevelVariables.SetFloat(gTWGameLevelDefinition.UniqueIDTotal, num + gameSecondsElapsedInLevel);
		Debug.Log("SaveDataEvent.AutoSave()");
		Events.RaiseEvent("GameAutoSaving");
		int slotNumber = _gameState.SaveSlot;
		_gameState.SelectSaveGame(slotNumber);
		_gameState.LoadGameStateData(null, -1);
		_gameData.SaveGameData(slotNumber, createBackup: false, (bool success) =>
		{
			if (success)
			{
				Events.RaiseEvent("GameSaved");
				_gameState.LoadSaveSlotMetaData(slotNumber, null);
			}
			else
			{
				Debug.LogError($"SaveGameData for slot#{slotNumber} has failed ");
			}
		}, _asyncSave);
		yield return null;
	}
}
