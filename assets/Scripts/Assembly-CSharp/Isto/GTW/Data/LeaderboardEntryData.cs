using System;
using UnityEngine;

namespace Isto.GTW.Data;

[Serializable]
public class LeaderboardEntryData
{
	[SerializeField]
	private string _playerName;

	[SerializeField]
	private int _highestCheckpoint;

	public string PlayerName
	{
		get
		{
			return _playerName;
		}
		set
		{
			_playerName = value;
		}
	}

	public int HighestCheckpoint => _highestCheckpoint;

	public int GlobalRank { get; set; }

	public int LocalRank { get; set; }

	public Texture2D AvatarTexture { get; set; }

	public LeaderboardEntryData()
	{
	}

	public LeaderboardEntryData(string playerName, int highestCheckpoint, int globalRank, int localRank, Texture2D avatarTexture = null)
	{
		_playerName = playerName;
		_highestCheckpoint = highestCheckpoint;
		GlobalRank = globalRank;
		LocalRank = localRank;
		AvatarTexture = avatarTexture;
	}

	public void SetHighestCheckpoint(int highestCheckpoint)
	{
		if (highestCheckpoint > _highestCheckpoint)
		{
			_highestCheckpoint = highestCheckpoint;
		}
	}
}
