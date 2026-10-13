using System.Linq;
using Isto.Core.Configuration;
using Isto.Core.Game;
using UnityEngine;
using Zenject;

namespace Isto.Core.Data;

public abstract class GameProgressAction : MonoBehaviour, IDataLoadCompleteHandler
{
	[Tooltip("Does the action repeat everytime the requirements are met or is it a one shot?")]
	public bool repeating;

	public string actionID;

	[Tooltip("The Action will only start if running the gane in a compabitle Game Mode")]
	public GameModeDefinition[] compatibleGameModes;

	protected bool _actionStarted;

	protected bool _actionCompleted;

	private GameState _gameState;

	public bool ActionCompleted => _actionCompleted;

	[Inject]
	public void Inject(GameState gameState)
	{
		_gameState = gameState;
	}

	public void OnDataLoadComplete()
	{
		if (base.enabled && !_actionCompleted && IsCompatibleWithCurrentGameMode())
		{
			RegisterForEvents();
		}
	}

	public void OnDisable()
	{
		UnregisterForEvents();
	}

	public abstract void RegisterForEvents();

	public abstract void UnregisterForEvents();

	public abstract GameProgressData GetSaveData();

	public abstract void LoadData(GameProgressData data);

	protected bool IsCompatibleWithCurrentGameMode()
	{
		if (_gameState.CurrentGameMode != null && compatibleGameModes.Length == 0)
		{
			Debug.LogWarning("Gameplay Action " + actionID + " has no compatible Game Modes asigned to it in inspector. Will not start.");
		}
		if (_gameState.CurrentGameMode != null && compatibleGameModes.Length != 0)
		{
			return compatibleGameModes.Contains(_gameState.CurrentGameMode);
		}
		return false;
	}
}
