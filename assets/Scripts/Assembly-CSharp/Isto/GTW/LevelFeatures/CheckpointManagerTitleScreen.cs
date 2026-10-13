using System.Collections.Generic;
using Isto.Core.Game;
using Isto.GTW.Configuration;
using UnityEngine;
using Zenject;

namespace Isto.GTW.LevelFeatures;

public class CheckpointManagerTitleScreen : MonoBehaviour
{
	[SerializeField]
	private CheckpointData _checkpointData;

	private CheckpointData.LevelCheckpointData _activeCheckpoint;

	private List<int> _seenCheckpointIds = new List<int>();

	private CanvasGroup _sceneBlackOutCanvas;

	private Coroutine _HideBlackOutAnimationCoroutine;

	private GTWGameState _gameState;

	public CheckpointData CheckpointData => _checkpointData;

	public CheckpointData.LevelCheckpointData ActiveCheckpoint => _activeCheckpoint;

	[Inject]
	public void Inject(GTWGameState gameState)
	{
		_gameState = gameState;
	}

	private void Start()
	{
		SetActiveCheckpoint(CheckpointData.StartingCheckpoint);
		if (!GameState.GameModeLoadedFromGameState)
		{
			return;
		}
		if (_gameState.CurrentGameMode != null && _gameState.GameLevelDefinition != null)
		{
			GTWGameLevelDefinition gameLevelDefinition = _gameState.GameLevelDefinition;
			if (!_gameState.StartedWithoutGameMode && gameLevelDefinition.CheckpointNumber > 0 && gameLevelDefinition.CheckpointNumber < CheckpointData.levelCheckpointDatas.Count)
			{
				CheckpointData.LevelCheckpointData checkpoint = CheckpointData.levelCheckpointDatas[gameLevelDefinition.CheckpointNumber];
				SetActiveCheckpoint(checkpoint);
			}
		}
		else
		{
			Debug.LogError($"Title Screen Checkpoin Error! Current Game Mode {_gameState.CurrentGameMode} Game Level Definition {_gameState.GameLevelDefinition}!");
		}
	}

	public bool SetActiveCheckpoint(CheckpointData.LevelCheckpointData checkpoint, bool idCheck = false)
	{
		int num = (checkpoint.checkpointId = _checkpointData.GetCheckpointId(checkpoint));
		if (!_seenCheckpointIds.Contains(num))
		{
			_seenCheckpointIds.Add(num);
			_seenCheckpointIds.Sort();
		}
		if (idCheck && _activeCheckpoint != null)
		{
			if (num > _checkpointData.GetCheckpointId(_activeCheckpoint))
			{
				_activeCheckpoint = checkpoint;
				return true;
			}
			return false;
		}
		_activeCheckpoint = checkpoint;
		return true;
	}
}
