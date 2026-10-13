using System.Collections.Generic;
using Isto.GTW.Data;
using Isto.GTW.Leaderboards;
using Isto.GTW.LevelFeatures;
using UnityEngine;
using Zenject;

namespace Isto.GTW.UI;

public class UIDoinklerLeaderboardCheckpoint : MonoBehaviour
{
	[SerializeField]
	private GameObject _instructionsContainer;

	[SerializeField]
	private Checkpoint _checkpoint;

	[SerializeField]
	private GTWLeaderboardPlayerDisplay[] _playersCompletedList;

	private ILeaderboard _leaderboard;

	private CheckpointManager _checkpointManager;

	[Inject]
	public void Inject(ILeaderboard leaderboard, CheckpointManager checkpointManager)
	{
		_leaderboard = leaderboard;
		_checkpointManager = checkpointManager;
	}

	private void Awake()
	{
		UpdateLeaderboard();
	}

	public void UpdateLeaderboard()
	{
		SetupLeaderboard();
	}

	private void SetupLeaderboard()
	{
		int checkpointId = _checkpointManager.CheckpointData.GetCheckpointId(_checkpoint);
		List<LeaderboardEntryData> list = _leaderboard.LeaderboardEntries.FindAll((LeaderboardEntryData x) => x.HighestCheckpoint == checkpointId);
		if (list.Count == 0)
		{
			_instructionsContainer.SetActive(value: false);
			return;
		}
		_instructionsContainer.SetActive(value: true);
		for (int num = 0; num < _playersCompletedList.Length; num++)
		{
			if (num < list.Count)
			{
				_playersCompletedList[num].gameObject.SetActive(value: true);
				_playersCompletedList[num].Setup(list[num], isFriendsMode: true);
			}
			else
			{
				_playersCompletedList[num].gameObject.SetActive(value: false);
			}
		}
	}
}
