using System.Collections;
using Isto.Core;
using Isto.Core.Data;
using Isto.Core.Game;
using Isto.GTW.Configuration;
using Isto.GTW.Player;
using Isto.GTW.Providers;
using UnityEngine;
using Zenject;

namespace Isto.GTW.Managers;

public class GTWDoinklerLevelTimeManager : MonoBehaviour
{
	private GTWProgressProvider _gameProgressProvider;

	private GTWGameState _gameState;

	private PlayerController _playerController;

	private IDoinklerWorldDefinitionProvider _doinklerWorldDefinitionProvider;

	private DoinklerLevelVariables _doinklerLevelVariables;

	private IGameData _gameData;

	[Inject]
	public void Inject(IGameProgressProvider gameProgressProvider, GTWGameState gameState, PlayerController playerController, IDoinklerWorldDefinitionProvider doinklerWorldDefinitionProvider, DoinklerLevelVariables levelVariables, IGameData gameData)
	{
		_gameProgressProvider = gameProgressProvider as GTWProgressProvider;
		_gameState = gameState;
		_playerController = playerController;
		_doinklerWorldDefinitionProvider = doinklerWorldDefinitionProvider;
		_doinklerLevelVariables = levelVariables;
		_gameData = gameData;
	}

	private void OnEnable()
	{
		RegisterEvents();
	}

	private void OnDisable()
	{
		UnregisterEvents();
	}

	private void RegisterEvents()
	{
		Events.SubscribeWithParams(GTWEvents.DOINKLER_STAGE_RESET, Events_OnDoinklerStageReset);
	}

	private void Events_OnDoinklerStageReset(object[] args)
	{
		bool num = (bool)args[0];
		_playerController.CheckpointManager.Respawn(showBlackOut: true);
		if (_playerController.IsMoveState)
		{
			_playerController.TeleportToGround();
		}
		int currentGameProgressLevel = _gameProgressProvider.GetCurrentGameProgressLevel();
		GTWGameLevelDefinition gTWGameLevelDefinition = _gameState.GameLevelDefinition ?? _doinklerWorldDefinitionProvider.Current.GameLevels[currentGameProgressLevel];
		int num2 = _doinklerLevelVariables.GetInt(gTWGameLevelDefinition.UniqueIDAttempts);
		_doinklerLevelVariables.SetInt(gTWGameLevelDefinition.UniqueIDAttempts, num2 + 1);
		if (num)
		{
			float gameSecondsElapsedInLevel = _gameProgressProvider.GetGameSecondsElapsedInLevel(currentGameProgressLevel);
			if (!_gameState.IsDoinklerSpecial)
			{
				_gameProgressProvider.GameTime[currentGameProgressLevel] = 0f;
			}
			float num3 = _doinklerLevelVariables.GetFloat(gTWGameLevelDefinition.UniqueIDTotal);
			_doinklerLevelVariables.SetFloat(gTWGameLevelDefinition.UniqueIDTotal, num3 + gameSecondsElapsedInLevel);
			StartCoroutine(AutoSave());
		}
		else if (!_gameState.IsDoinklerSpecial)
		{
			_gameProgressProvider.GameTime[currentGameProgressLevel] = 0f;
		}
		Events.RaiseEvent(GTWEvents.DOINKLER_STAGE_COMPLETE);
		Events.RaiseEvent(GTWEvents.DOINKLER_STAGE_START);
	}

	private IEnumerator AutoSave()
	{
		Debug.Log("ActivateCheckpointEvent.AutoSave()");
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
		});
		yield return null;
	}

	private void UnregisterEvents()
	{
		Events.UnSubscribeWithParams(GTWEvents.DOINKLER_STAGE_RESET, Events_OnDoinklerStageReset);
	}
}
