using System.Collections.Generic;
using Isto.GTW.Data;
using UnityEngine;

namespace Isto.GTW.Leaderboards;

[CreateAssetMenu(fileName = "GTWLeaderboardDummyData", menuName = "Scriptables/Leaderboards/Leaderboard Dummy Data")]
public class GTWLeaderboardDummyData : ScriptableObject
{
	[SerializeField]
	private List<LeaderboardEntryData> _entries = new List<LeaderboardEntryData>();

	public List<LeaderboardEntryData> Entries => _entries;
}
