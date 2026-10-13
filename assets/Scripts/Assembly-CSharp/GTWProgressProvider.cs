using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Isto.Core;
using Isto.Core.Data;
using Isto.Core.Game;
using Isto.GTW;
using Isto.GTW.LevelFeatures;
using Isto.GTW.Player;
using UnityEngine;
using Zenject;

public class GTWProgressProvider : GameProgressProvider, IDataLoadCompleteHandler
{
	private CheckpointData _checkpointData;

	private CheckpointData.LevelCheckpointData _bestCheckpoint;

	private int _bestCheckpointIndex;

	private CheckpointData.LevelCheckpointData[] _indexableLevelsCache;

	private Dictionary<int, CheckpointData.LevelCheckpointData> _filteredLevelsCache;

	private bool _init;

	private const int HEIGHT_CHECKPOINT_COUNT = 11;

	private CheckpointManager _checkpointManager;

	private GTWGameState _gameState;

	public Dictionary<int, float> GameTime { get; set; }

	public bool GamePaused { get; private set; }

	public bool GameEnded { get; private set; }

	public float PlayerHeightPercent { get; private set; }

	private Dictionary<int, CheckpointData.LevelCheckpointData> FilteredLevels
	{
		get
		{
			if (_filteredLevelsCache == null)
			{
				_filteredLevelsCache = new Dictionary<int, CheckpointData.LevelCheckpointData>();
				if (_checkpointData != null && _checkpointData.levelCheckpointDatas != null)
				{
					for (int i = 0; i < _checkpointData.levelCheckpointDatas.Count; i++)
					{
						CheckpointData.LevelCheckpointData levelCheckpointData = _checkpointData.levelCheckpointDatas[i];
						if (levelCheckpointData.showInSpeedrunTimer || _gameState.IsDoinklerSpecial)
						{
							_filteredLevelsCache.Add(i, levelCheckpointData);
						}
					}
				}
			}
			return _filteredLevelsCache;
		}
	}

	private CheckpointData.LevelCheckpointData[] IndexableLevels
	{
		get
		{
			if (_indexableLevelsCache == null)
			{
				_indexableLevelsCache = FilteredLevels.Values.ToArray();
			}
			return _indexableLevelsCache;
		}
	}

	private PlayerController PlayerController => _checkpointManager.PlayerController;

	[Inject]
	private void Inject(GTWGameState gameState)
	{
		_gameState = gameState;
	}

	private void Awake()
	{
		if (GameTime == null)
		{
			GameTime = new Dictionary<int, float>();
		}
		GamePaused = true;
		RegisterEvents();
	}

	private IEnumerator Start()
	{
		while (!_init)
		{
			yield return null;
		}
		_checkpointData = _checkpointManager.CheckpointData;
		_bestCheckpoint = _checkpointData.StartingCheckpoint;
		InitStartingCheckpointIndex();
	}

	private void OnDestroy()
	{
		UnregisterEvents();
	}

	private void Update()
	{
		if (!_init)
		{
			CheckpointManager checkpointManager = Object.FindAnyObjectByType<CheckpointManager>();
			if (!(checkpointManager != null))
			{
				return;
			}
			_checkpointManager = checkpointManager;
			_init = true;
		}
		if (_checkpointManager.ActiveCheckpoint != null)
		{
			if (!GamePaused)
			{
				UpdateHeight();
			}
			UpdateCheckpoint();
			if (!GamePaused)
			{
				TrackTime();
			}
		}
	}

	private void RegisterEvents()
	{
		Events.Subscribe(GTWEvents.PLAYER_FIRST_INPUT, Events_OnFirstPlayerInput);
		Events.Subscribe(GTWEvents.DOINKLER_STAGE_COMPLETE, Events_OnDoinklerStageComplete);
		Events.SubscribeWithParams(GTWEvents.DOINKLER_STAGE_RESET, Events_OnDoinklerStageReset);
		Events.Subscribe("EndOfGame", Events_OnGameEnd);
	}

	private void UnregisterEvents()
	{
		Events.UnSubscribe(GTWEvents.PLAYER_FIRST_INPUT, Events_OnFirstPlayerInput);
		Events.UnSubscribe(GTWEvents.DOINKLER_STAGE_COMPLETE, Events_OnDoinklerStageComplete);
		Events.UnSubscribeWithParams(GTWEvents.DOINKLER_STAGE_RESET, Events_OnDoinklerStageReset);
		Events.UnSubscribe("EndOfGame", Events_OnGameEnd);
	}

	private void Events_OnDoinklerStageComplete()
	{
		GamePaused = true;
	}

	private void Events_OnDoinklerStageReset(object[] args)
	{
		if (GameEnded)
		{
			GameEnded = false;
		}
	}

	private void Events_OnFirstPlayerInput()
	{
		GamePaused = false;
	}

	private void Events_OnGameEnd()
	{
		_bestCheckpointIndex = GetMaxGameProgressLevel();
		if (_gameState.IsDoinklerPortfolio)
		{
			_bestCheckpointIndex = _gameState.GetCurrentDoinklerWorld();
		}
		GameEnded = true;
	}

	public void OnDataLoadComplete()
	{
		if (GameState.LoadingFromSave && !GameTime.ContainsKey(_bestCheckpointIndex))
		{
			GameTime.Add(_bestCheckpointIndex, 0f);
		}
	}

	public override int GetCurrentGameProgressLevel()
	{
		if (!_init || _checkpointData == null || _checkpointData.levelCheckpointDatas == null)
		{
			return -1;
		}
		return _bestCheckpointIndex;
	}

	public override int GetMaxGameProgressLevel()
	{
		if (!_init || _checkpointData == null || _checkpointData.levelCheckpointDatas == null)
		{
			return -1;
		}
		if (_gameState.IsDoinklerPortfolio)
		{
			return _gameState.GetDoinklerWorldCount();
		}
		if (_gameState.IsDoinklerSpecial)
		{
			return 11;
		}
		return FilteredLevels.Count;
	}

	public override bool IsLastProgressLevel()
	{
		if (!_init || _checkpointData == null || _checkpointData.levelCheckpointDatas == null)
		{
			return false;
		}
		if (_gameState.IsDoinklerPortfolio)
		{
			return GameEnded;
		}
		return base.IsLastProgressLevel();
	}

	public override float GetGameSecondsElapsedInLevel(int progressLevel)
	{
		return GetCumulativeGameTimeForCheckpoint(progressLevel);
	}

	public override float GetTotalGameSecondsElapsedInPlaythrough()
	{
		return GameTime.Sum((KeyValuePair<int, float> x) => x.Value);
	}

	public override string GetGameProgressLevelInternalName(int progressLevel)
	{
		return IndexableLevels[progressLevel].checkpointName;
	}

	private float GetCumulativeGameTimeForCheckpoint(int checkpointId)
	{
		if (GameTime.ContainsKey(checkpointId))
		{
			return GameTime[checkpointId];
		}
		return 0f;
	}

	public override void LoadLevelTimes(Dictionary<int, float> dictionary)
	{
		GameTime = new Dictionary<int, float>();
		foreach (KeyValuePair<int, float> item in dictionary)
		{
			GameTime.Add(item.Key, item.Value);
		}
		if (_gameState.GameLevelDefinition != null)
		{
			GameTime[_gameState.GameLevelDefinition.CheckpointNumber] = 0f;
		}
	}

	public void ResetLevelTimes()
	{
		GameTime.Clear();
		InitStartingCheckpointIndex();
	}

	private void InitStartingCheckpointIndex()
	{
		int bestCheckpointIndex = -1;
		PlayerHeightPercent = 0f;
		for (int i = 0; i < IndexableLevels.Length; i++)
		{
			if (GetCumulativeGameTimeForCheckpoint(i) > 0.001f)
			{
				bestCheckpointIndex = i;
			}
		}
		if (_gameState.IsDoinklerSpecial)
		{
			_bestCheckpointIndex = 0;
		}
		else if (_gameState.IsDoinklerPortfolio)
		{
			_bestCheckpointIndex = _gameState.GetCurrentDoinklerWorld();
		}
		else
		{
			_bestCheckpointIndex = bestCheckpointIndex;
		}
	}

	private void TrackTime()
	{
		if (!GameEnded)
		{
			GameTime[_bestCheckpointIndex] += Time.deltaTime;
		}
	}

	private void UpdateCheckpoint(bool clearCache = false)
	{
		if (_indexableLevelsCache != null && _indexableLevelsCache.Length == 0)
		{
			_indexableLevelsCache = null;
			_filteredLevelsCache = null;
		}
		int num = -1;
		for (int i = 0; i < IndexableLevels.Length; i++)
		{
			if (IndexableLevels[i].checkpointName == _checkpointManager.ActiveCheckpoint.checkpointName)
			{
				num = i;
				break;
			}
		}
		if (_bestCheckpointIndex == -1 && num == -1 && IndexableLevels.Length != 0)
		{
			RestoreProgress();
		}
		if (!_gameState.IsDoinklerSpecial && _bestCheckpoint != null && _bestCheckpointIndex >= num)
		{
			return;
		}
		_bestCheckpoint = _checkpointManager.ActiveCheckpoint;
		if (_gameState.IsDoinklerPortfolio)
		{
			_bestCheckpointIndex = _gameState.GetCurrentDoinklerWorld();
		}
		else if (_gameState.IsDoinklerSpecial)
		{
			int num2 = Mathf.Clamp(Mathf.FloorToInt(PlayerHeightPercent / 10f), 0, 10);
			int checkpointId = _checkpointManager.ActiveCheckpoint.checkpointId;
			List<CheckpointData.LevelCheckpointData> levelCheckpointDatas = _checkpointManager.CheckpointData.levelCheckpointDatas;
			if (checkpointId == levelCheckpointDatas[levelCheckpointDatas.Count - 1].checkpointId)
			{
				num2 = 10;
			}
			if (num2 > _bestCheckpointIndex)
			{
				_bestCheckpointIndex = num2;
				Debug.Log("_bestCheckpointIndex: " + _bestCheckpointIndex);
			}
		}
		else
		{
			_bestCheckpointIndex = num;
		}
		if (!GameTime.ContainsKey(_bestCheckpointIndex))
		{
			GameTime.Add(_bestCheckpointIndex, 0f);
		}
	}

	private void UpdateHeight()
	{
		if (!(_checkpointManager == null))
		{
			CheckpointData.LevelCheckpointData startingCheckpoint = _checkpointManager.StartingCheckpoint;
			CheckpointData.LevelCheckpointData levelCheckpointData = _checkpointManager.CheckpointData.levelCheckpointDatas.Last();
			float num = PlayerController.GetPlayerPosition().y - startingCheckpoint.position.y;
			float num2 = levelCheckpointData.position.y - startingCheckpoint.position.y;
			PlayerHeightPercent = Mathf.RoundToInt(num / num2 * 100f);
		}
	}

	private void RestoreProgress()
	{
		InitStartingCheckpointIndex();
		if (_bestCheckpointIndex < 0 || _bestCheckpointIndex >= IndexableLevels.Length)
		{
			return;
		}
		_bestCheckpoint = IndexableLevels[_bestCheckpointIndex];
		int checkpointId = _checkpointData.GetCheckpointId(_checkpointManager.ActiveCheckpoint);
		for (int i = 0; i < checkpointId; i++)
		{
			string checkpointName = _checkpointData.levelCheckpointDatas[i].checkpointName;
			for (int j = _bestCheckpointIndex; j < IndexableLevels.Length; j++)
			{
				if (IndexableLevels[j].checkpointName == checkpointName)
				{
					_bestCheckpointIndex = j;
					_bestCheckpoint = IndexableLevels[j];
					break;
				}
			}
		}
	}
}
