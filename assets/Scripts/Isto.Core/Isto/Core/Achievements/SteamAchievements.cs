using Steamworks;
using UnityEngine;

namespace Isto.Core.Achievements;

public class SteamAchievements : IAchievements
{
	protected static readonly string STAT_SUFFIX = "Progress";

	private CGameID _gameID;

	private Callback<UserStatsReceived_t> _onUserStatsReceived;

	private Callback<UserStatsStored_t> _onUserStatsStored;

	private Callback<UserAchievementStored_t> _onUserAchievementStored;

	private bool _statsValid;

	private bool _requestedStats;

	private bool _batchMode;

	private string GetAchievementID(IAchievements.CoreAchievementsEnum achievement)
	{
		return achievement.ToString();
	}

	private string GetStatID(IAchievements.CoreAchievementsEnum achievement)
	{
		return achievement.ToString() + STAT_SUFFIX;
	}

	public virtual void Initialize()
	{
		if (!SteamManager.Initialized)
		{
			Debug.LogError("Requested SteamAchievements.Initialize but steam is not initialized");
			return;
		}
		Debug.Log("SteamAchievements.Initialize success");
		_gameID = new CGameID(SteamUtils.GetAppID());
		_onUserStatsReceived = Callback<UserStatsReceived_t>.Create(OnUserStatsReceived);
		_onUserStatsStored = Callback<UserStatsStored_t>.Create(OnUserStatsStored);
		_onUserAchievementStored = Callback<UserAchievementStored_t>.Create(OnAchievementStored);
		_statsValid = false;
		_requestedStats = SteamUserStats.RequestCurrentStats();
	}

	public virtual void Cleanup()
	{
	}

	public void GetUserProgress(IAchievements.CoreAchievementsEnum achievement)
	{
		if (!SteamManager.Initialized)
		{
			Debug.LogError("Requested SteamAchievements.GetUserProgress but steam is not initialized");
			return;
		}
		if (!_statsValid)
		{
			Debug.LogError("Requested SteamAchievements.GetUserProgress but steam stats have not been received");
			return;
		}
		string statID = GetStatID(achievement);
		if (SteamUserStats.GetStat(statID, out int pData))
		{
			Debug.Log($"SteamUserStats.GetStat succeeded, {statID}={pData}");
		}
		else
		{
			Debug.LogWarning("SteamUserStats.GetStat failed for stat " + statID + " - Is it registered in the Steam Partner site?");
		}
		string achievementID = GetAchievementID(achievement);
		if (SteamUserStats.GetAchievement(achievementID, out var pbAchieved))
		{
			string achievementDisplayAttribute = SteamUserStats.GetAchievementDisplayAttribute(achievementID, "name");
			string achievementDisplayAttribute2 = SteamUserStats.GetAchievementDisplayAttribute(achievementID, "desc");
			Debug.Log("Found " + (pbAchieved ? "unlocked" : "locked") + " achievement \"" + achievementDisplayAttribute + "\" : " + achievementDisplayAttribute2);
		}
		else
		{
			Debug.LogWarning("SteamUserStats.GetAchievement failed for Achievement " + achievementID + " - Is it registered in the Steam Partner site?");
		}
	}

	private void OnUserStatsReceived(UserStatsReceived_t pCallback)
	{
		if (!SteamManager.Initialized)
		{
			Debug.LogError("Received OnUserStatsReceived from steam but steam is not initialized");
		}
		else if ((ulong)_gameID == pCallback.m_nGameID)
		{
			if (EResult.k_EResultOK == pCallback.m_eResult)
			{
				Debug.Log("Received stats and achievements from Steam");
				_statsValid = true;
			}
			else
			{
				Debug.Log("RequestStats - failed, " + pCallback.m_eResult);
			}
		}
	}

	private void OnUserStatsStored(UserStatsStored_t pCallback)
	{
		if ((ulong)_gameID == pCallback.m_nGameID)
		{
			if (EResult.k_EResultOK == pCallback.m_eResult)
			{
				Debug.Log("StoreStats - success");
			}
			else if (EResult.k_EResultInvalidParam == pCallback.m_eResult)
			{
				Debug.Log("StoreStats - some failed to validate");
				OnUserStatsReceived(new UserStatsReceived_t
				{
					m_eResult = EResult.k_EResultOK,
					m_nGameID = (ulong)_gameID
				});
			}
			else
			{
				Debug.Log("StoreStats - failed, " + pCallback.m_eResult);
			}
		}
	}

	private void OnAchievementStored(UserAchievementStored_t pCallback)
	{
		if ((ulong)_gameID == pCallback.m_nGameID)
		{
			if (pCallback.m_nMaxProgress == 0)
			{
				Debug.Log("Achievement '" + pCallback.m_rgchAchievementName + "' unlocked!");
				return;
			}
			Debug.Log("Achievement '" + pCallback.m_rgchAchievementName + "' progress callback, (" + pCallback.m_nCurProgress + "," + pCallback.m_nMaxProgress + ")");
		}
	}

	public void TriggerAchievement(IAchievements.CoreAchievementsEnum achievement)
	{
		if (!SteamManager.Initialized)
		{
			Debug.LogError($"Requested SteamAchievements.TriggerAchievement for achievement {achievement} but steam is not initialized");
			return;
		}
		if (!_statsValid)
		{
			Debug.LogError($"Requested SteamAchievements.TriggerAchievement for achievement {achievement} but steam stats have not been received");
			return;
		}
		SteamUserStats.SetAchievement(GetAchievementID(achievement));
		if (!_batchMode)
		{
			SteamUserStats.StoreStats();
		}
	}

	public void RecordAchievementProgress(IAchievements.CoreAchievementsEnum achievement, int progress, float completionPercentage)
	{
		if (!SteamManager.Initialized)
		{
			Debug.LogError("Requested SteamAchievements.RecordAchievementProgress but steam is not initialized");
			return;
		}
		if (!_statsValid)
		{
			Debug.LogError("Requested SteamAchievements.RecordAchievementProgress but steam stats have not been received");
			return;
		}
		SteamUserStats.SetStat(GetStatID(achievement), progress);
		if ((float)progress > 0.25f && (float)progress < 0.9f)
		{
			SteamUserStats.IndicateAchievementProgress(GetAchievementID(achievement), (uint)progress, 5u);
		}
		if (!_batchMode)
		{
			SteamUserStats.StoreStats();
		}
	}

	public void ResetAllProgress()
	{
		if (!SteamManager.Initialized)
		{
			Debug.LogError("Requested SteamAchievements.ResetAllProgress but steam is not initialized");
		}
		else if (!_statsValid)
		{
			Debug.LogError("Requested SteamAchievements.ResetAllProgress but steam stats have not been received");
		}
		else
		{
			SteamUserStats.ResetAllStats(bAchievementsToo: true);
		}
	}

	public void BeginBatchMode()
	{
		_batchMode = true;
	}

	public void EndBatchMode()
	{
		_batchMode = false;
		SteamUserStats.StoreStats();
	}
}
