using Isto.Core;
using Isto.Core.Achievements;
using Isto.Core.Beings;
using Isto.Core.Game;
using Isto.GTW;
using Isto.GTW.LevelFeatures.LevelEvents;
using Isto.GTW.Managers;
using PixelCrushers.DialogueSystem;
using UnityEngine;
using Zenject;

public class GTWGameStats : MonoBehaviour
{
	[SerializeField]
	private DialogueDatabase _podcastsDatabase;

	private float _totalHeightGained;

	private float _totalDistanceFallen;

	private int _totalBigCrashes;

	private int _dunceHatsCollected;

	private float _previousHeight;

	private float _gameEndTime;

	private IAchievements _achievements;

	private IGameProgressProvider _gameProgress;

	private GTWGameState _gtwGameState;

	private LevelVariables _levelVariables;

	private IPlayerController _playerController;

	public float TotalHeightGained
	{
		get
		{
			return _totalHeightGained;
		}
		set
		{
			_totalHeightGained = value;
		}
	}

	public float TotalDistanceFallen
	{
		get
		{
			return _totalDistanceFallen;
		}
		set
		{
			_totalDistanceFallen = value;
		}
	}

	public int TotalBigCrashes
	{
		get
		{
			return _totalBigCrashes;
		}
		set
		{
			_totalBigCrashes = value;
		}
	}

	public int DunceHatsCollected
	{
		get
		{
			return _dunceHatsCollected;
		}
		set
		{
			_dunceHatsCollected = value;
		}
	}

	public float GameEndTime => _gameEndTime;

	[Inject]
	public void Inject(IAchievements achievements, IGameProgressProvider gameProgress, LevelVariables levelVariables, IPlayerController playerController, GTWGameState gtwGameState)
	{
		_achievements = achievements;
		_gameProgress = gameProgress;
		_levelVariables = levelVariables;
		_playerController = playerController;
		_gtwGameState = gtwGameState;
	}

	private void Start()
	{
		RegisterEvents();
		_previousHeight = _playerController.GetPlayerPosition().y;
	}

	private void OnEnable()
	{
		Events.Subscribe(GTWEvents.HARD_CRASH, PlayerRagdoll_HandleHardCrashes);
	}

	private void PlayerRagdoll_HandleHardCrashes()
	{
		_totalBigCrashes++;
	}

	private void OnDisable()
	{
		Events.UnSubscribe(GTWEvents.HARD_CRASH, PlayerRagdoll_HandleHardCrashes);
	}

	private void OnDestroy()
	{
		UnregisterEvents();
	}

	private void Update()
	{
		UpdatePlayerHeightStats();
	}

	private void RegisterEvents()
	{
		Events.Subscribe(GTWEvents.DIALOGUE_EVENT, Events_OnDialogueEvent);
		Events.Subscribe(GTWEvents.DUNCE_HAT_PICKUP, Events_OnDunceHatPickup);
		Events.Subscribe("EndOfGame", Events_OnGameEnd);
	}

	private void UnregisterEvents()
	{
		Events.UnSubscribe(GTWEvents.DIALOGUE_EVENT, Events_OnDialogueEvent);
		Events.UnSubscribe(GTWEvents.DUNCE_HAT_PICKUP, Events_OnDunceHatPickup);
		Events.UnSubscribe("EndOfGame", Events_OnGameEnd);
	}

	private void Events_OnDialogueEvent()
	{
		int podcastCount = GetPodcastCount();
		int podcastTotal = GetPodcastTotal();
		bool flag = false;
		if (podcastCount >= IGTWAchievements.GRINDSET_1_COUNT)
		{
			flag = true;
			_achievements.BeginBatchMode();
			_achievements.TriggerAchievement(IGTWAchievements.GTWAchievementsEnum.GRINDSET_1);
		}
		if (podcastCount >= IGTWAchievements.GRINDSET_2_COUNT)
		{
			if (!flag)
			{
				flag = true;
				_achievements.BeginBatchMode();
			}
			_achievements.TriggerAchievement(IGTWAchievements.GTWAchievementsEnum.GRINDSET_2);
		}
		if (podcastCount >= podcastTotal)
		{
			_achievements.TriggerAchievement(IGTWAchievements.GTWAchievementsEnum.GRINDSET_3);
		}
		if (flag)
		{
			_achievements.EndBatchMode();
		}
	}

	private void Events_OnGameEnd()
	{
		if (_gtwGameState.IsDoinklerPortfolio || _gtwGameState.IsDoinklerSpecial)
		{
			return;
		}
		float num = (_gameEndTime = _gameProgress.GetTotalGameSecondsElapsedInPlaythrough());
		bool flag = false;
		if (num < IGTWAchievements.SPEEDRUNNER_1_TIME)
		{
			flag = true;
			_achievements.BeginBatchMode();
			_achievements.TriggerAchievement(IGTWAchievements.GTWAchievementsEnum.SPEEDRUNNER_1);
		}
		if (num < IGTWAchievements.SPEEDRUNNER_2_TIME)
		{
			if (!flag)
			{
				flag = true;
				_achievements.BeginBatchMode();
			}
			_achievements.TriggerAchievement(IGTWAchievements.GTWAchievementsEnum.SPEEDRUNNER_2);
		}
		if (num < IGTWAchievements.SPEEDRUNNER_3_TIME)
		{
			if (!flag)
			{
				flag = true;
				_achievements.BeginBatchMode();
			}
			_achievements.TriggerAchievement(IGTWAchievements.GTWAchievementsEnum.SPEEDRUNNER_3);
		}
		if (num < IGTWAchievements.WAIT_SERIOUSLY_TIME)
		{
			_achievements.TriggerAchievement(IGTWAchievements.GTWAchievementsEnum.WAIT_SERIOUSLY);
		}
		if (flag)
		{
			_achievements.EndBatchMode();
		}
	}

	private void Events_OnDunceHatPickup()
	{
		_dunceHatsCollected++;
	}

	public int GetPodcastCount()
	{
		if (_podcastsDatabase == null)
		{
			return 0;
		}
		int num = 0;
		for (int i = 0; i < _podcastsDatabase.conversations.Count; i++)
		{
			string id = _podcastsDatabase.conversations[i].Title + LevelEventTriggerSerializer.TRIGGER_SUFFIX;
			if (_levelVariables.GetBool(id))
			{
				num++;
			}
		}
		return num;
	}

	public int GetPodcastTotal()
	{
		if (_podcastsDatabase == null)
		{
			return 0;
		}
		return _podcastsDatabase.conversations.Count;
	}

	[ContextMenu("PrintPodcastCount")]
	private void PrintPodcastCount()
	{
		int podcastCount = GetPodcastCount();
		Debug.Log($"podcast count={podcastCount}");
	}

	private void UpdatePlayerHeightStats()
	{
		float y = _playerController.GetPlayerPosition().y;
		if (!(Mathf.Abs(_previousHeight - y) <= 0.1f))
		{
			if (y > _previousHeight)
			{
				_totalHeightGained += y - _previousHeight;
			}
			else if (y < _previousHeight)
			{
				_totalDistanceFallen += 0f - (y - _previousHeight);
			}
			_previousHeight = y;
		}
	}
}
