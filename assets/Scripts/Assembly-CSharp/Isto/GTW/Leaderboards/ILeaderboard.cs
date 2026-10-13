using System;
using System.Collections.Generic;
using Isto.GTW.Data;
using UnityEngine;

namespace Isto.GTW.Leaderboards;

public interface ILeaderboard
{
	string UserName { get; }

	Texture2D UserAvatar { get; }

	string LeaderboardName { get; }

	List<LeaderboardEntryData> LeaderboardEntries { get; }

	event Action OnCheckpointsDownloaded;

	void UploadHighestCheckpoint(int score);

	void DownloadFriendsEntries();

	void DownloadFriendsEntries(float cooldown);
}
