using System;
using System.Collections.Generic;
using System.Linq;
using Isto.GTW.Data;
using UnityEngine;

namespace Isto.GTW.Leaderboards;

public class GTWDummyDataLeaderboard : MonoBehaviour, ILeaderboard
{
	[Header("Leaderboard Dummy Data")]
	[SerializeField]
	private GTWLeaderboardDummyData _gtwLeaderboardDummyData;

	private List<LeaderboardEntryData> _leaderboardEntries = new List<LeaderboardEntryData>();

	private int _highestCheckpoint;

	public string UserName => string.Empty;

	public Texture2D UserAvatar => null;

	public string LeaderboardName => "Richard Bankman";

	public List<LeaderboardEntryData> LeaderboardEntries => _leaderboardEntries;

	public event Action OnCheckpointsDownloaded;

	private void Start()
	{
		_gtwLeaderboardDummyData = Resources.Load<GTWLeaderboardDummyData>("GTWLeaderboardDummyData");
	}

	private LeaderboardEntryData GetCurrentPlayerEntryData()
	{
		return _gtwLeaderboardDummyData.Entries.First((LeaderboardEntryData x) => x.PlayerName == LeaderboardName);
	}

	public void UploadHighestCheckpoint(int score)
	{
		if (score > _highestCheckpoint)
		{
			GetCurrentPlayerEntryData().SetHighestCheckpoint(score);
		}
	}

	public void DownloadFriendsEntries()
	{
		LeaderboardEntryData currentPlayerEntryData = GetCurrentPlayerEntryData();
		_highestCheckpoint = currentPlayerEntryData.HighestCheckpoint;
		List<LeaderboardEntryData> list = _gtwLeaderboardDummyData.Entries.OrderByDescending((LeaderboardEntryData x) => x.HighestCheckpoint).ToList();
		int num = 1;
		foreach (LeaderboardEntryData item in list)
		{
			item.LocalRank = num;
			num++;
		}
		_leaderboardEntries = list;
		OnCheckpointsDownloaded?.Invoke();
	}

	public void DownloadFriendsEntries(float cooldown)
	{
		if (_leaderboardEntries.Count == 0)
		{
			DownloadFriendsEntries();
		}
	}
}
