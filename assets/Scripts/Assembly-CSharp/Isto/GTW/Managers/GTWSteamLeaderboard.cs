using System;
using System.Collections;
using System.Collections.Generic;
using Isto.GTW.Data;
using Isto.GTW.Leaderboards;
using Isto.GTW.UI;
using Steamworks;
using UnityEngine;

namespace Isto.GTW.Managers;

public class GTWSteamLeaderboard : MonoBehaviour, ILeaderboard
{
	private static string LEADERBOARD_NAME = "Doinkler Special Highest Checkpoint";

	private static int START_RANK = 1;

	private static int END_RANK = 50;

	private static readonly string PENDING_UPLOAD_KEY = "GTW_PendingLeaderboardScore";

	private CallResult<LeaderboardScoresDownloaded_t> _downloadScoresResult;

	private CallResult<LeaderboardFindResult_t> _findLeaderboardResult;

	private CallResult<LeaderboardScoreUploaded_t> _uploadScoreResult;

	private SteamLeaderboard_t _steamLeaderboard;

	private List<LeaderboardEntryData> _leaderboardEntries = new List<LeaderboardEntryData>();

	private bool _leaderboardFound;

	private int _highestCheckpoint;

	private float _lastDownloadTime = -1f;

	private static readonly int MAX_UPLOADS_PER_WINDOW = 8;

	private static readonly float RATE_LIMIT_WINDOW_SECONDS = 600f;

	private List<float> _uploadTimestamps = new List<float>();

	private int? _pendingUploadScore;

	private bool _hasOutstandingUpload;

	private bool _rateLimitMonitorActive;

	private bool _isInitialSetupComplete;

	public string UserName => SteamFriends.GetPersonaName();

	public Texture2D UserAvatar => GetLocalPlayerAvatar();

	public string LeaderboardName => SteamFriends.GetPersonaName();

	public List<LeaderboardEntryData> LeaderboardEntries => _leaderboardEntries;

	public event Action OnCheckpointsDownloaded;

	private void Start()
	{
		if (!SteamManager.Initialized)
		{
			Debug.LogError("[LeaderboardManager] SteamManager not initialized. Cannot find or create leaderboard.");
			return;
		}
		RegisterEvents();
		SetupLeaderboard();
	}

	private void OnDestroy()
	{
		UnregisterEvents();
		if (_rateLimitMonitorActive)
		{
			_rateLimitMonitorActive = false;
		}
		StopAllCoroutines();
	}

	private void RegisterEvents()
	{
		Application.quitting += Application_OnQuit;
		_findLeaderboardResult = CallResult<LeaderboardFindResult_t>.Create(SteamLeaderboard_OnFindLeaderboard);
		_uploadScoreResult = CallResult<LeaderboardScoreUploaded_t>.Create(SteamLeaderboard_OnUploadScore);
		_downloadScoresResult = CallResult<LeaderboardScoresDownloaded_t>.Create(SteamLeaderboard_OnDownloadScores);
	}

	private void UnregisterEvents()
	{
		Application.quitting -= Application_OnQuit;
		_findLeaderboardResult?.Cancel();
		_uploadScoreResult?.Cancel();
		_downloadScoresResult?.Cancel();
	}

	private void Application_OnQuit()
	{
		if (_pendingUploadScore.HasValue && _leaderboardFound && !_hasOutstandingUpload)
		{
			Debug.Log($"[LeaderboardManager] Application quitting - attempting to upload pending score {_pendingUploadScore.Value}");
			ForceUploadOnQuit(_pendingUploadScore.Value);
		}
	}

	private void SteamLeaderboard_OnFindLeaderboard(LeaderboardFindResult_t result, bool isIOFailure)
	{
		if (isIOFailure || result.m_bLeaderboardFound == 0)
		{
			Debug.LogError($"[LeaderboardManager] Failed to find or create leaderboard '{LEADERBOARD_NAME}'. IOFailure? {isIOFailure}");
			return;
		}
		_steamLeaderboard = result.m_hSteamLeaderboard;
		_leaderboardFound = true;
		Debug.Log($"[LeaderboardManager] Found or created leaderboard '{LEADERBOARD_NAME}' (Handle: {_steamLeaderboard.m_SteamLeaderboard}).");
		DownloadFriendsEntries();
	}

	private void SteamLeaderboard_OnUploadScore(LeaderboardScoreUploaded_t result, bool isIOFailure)
	{
		_hasOutstandingUpload = false;
		if (isIOFailure || result.m_bSuccess == 0)
		{
			Debug.LogError($"[LeaderboardManager] Score upload failed. IOFailure? {isIOFailure}. Will Queue for next available upload.");
			QueueUpload(result.m_nScore);
		}
		else
		{
			Debug.Log($"[LeaderboardManager] Upload succeeded. New rank: {result.m_nGlobalRankNew}, Score: {result.m_nScore}");
		}
	}

	private void SteamLeaderboard_OnDownloadScores(LeaderboardScoresDownloaded_t result, bool isIOFailure)
	{
		if (isIOFailure)
		{
			Debug.LogError($"[LeaderboardManager] Failed to download leaderboard entries. IOFailure? {isIOFailure}");
			return;
		}
		Debug.Log("[LeaderboardManager] Downloading leaderboard entries...");
		int cEntryCount = result.m_cEntryCount;
		List<LeaderboardEntryData> list = new List<LeaderboardEntryData>(cEntryCount);
		for (int i = 0; i < cEntryCount; i++)
		{
			SteamUserStats.GetDownloadedLeaderboardEntry(result.m_hSteamLeaderboardEntries, i, out var pLeaderboardEntry, null, 0);
			LeaderboardEntryData item = new LeaderboardEntryData(SteamFriends.GetFriendPersonaName(pLeaderboardEntry.m_steamIDUser), globalRank: pLeaderboardEntry.m_nGlobalRank, localRank: i + 1, avatarTexture: GetPlayerAvatar(pLeaderboardEntry), highestCheckpoint: pLeaderboardEntry.m_nScore);
			list.Add(item);
		}
		FindAndSetPlayersHighestScoreFromLeaderboard(list);
		_leaderboardEntries = list;
		Debug.Log("[LeaderboardManager] Downloading leaderboard entries complete!");
		if (!_isInitialSetupComplete)
		{
			RestorePendingUploads();
		}
		OnCheckpointsDownloaded?.Invoke();
	}

	private static Texture2D GetPlayerAvatar(LeaderboardEntry_t entry)
	{
		SteamFriends.RequestUserInformation(entry.m_steamIDUser, bRequireNameOnly: true);
		int largeFriendAvatar = SteamFriends.GetLargeFriendAvatar(entry.m_steamIDUser);
		Texture2D result = null;
		if (largeFriendAvatar != -1 && SteamUtils.GetImageSize(largeFriendAvatar, out var pnWidth, out var pnHeight))
		{
			byte[] array = new byte[pnWidth * pnHeight * 4];
			if (SteamUtils.GetImageRGBA(largeFriendAvatar, array, array.Length))
			{
				result = new Texture2D((int)pnWidth, (int)pnHeight, TextureFormat.RGBA32, mipChain: false);
				result.LoadRawTextureData(array);
				result.Apply();
				result = GTWUtils.FlipTextureVertically(result);
			}
		}
		return result;
	}

	private static Texture2D GetLocalPlayerAvatar()
	{
		SteamFriends.RequestUserInformation(SteamUser.GetSteamID(), bRequireNameOnly: true);
		int largeFriendAvatar = SteamFriends.GetLargeFriendAvatar(SteamUser.GetSteamID());
		Texture2D result = null;
		if (largeFriendAvatar != -1 && SteamUtils.GetImageSize(largeFriendAvatar, out var pnWidth, out var pnHeight))
		{
			byte[] array = new byte[pnWidth * pnHeight * 4];
			if (SteamUtils.GetImageRGBA(largeFriendAvatar, array, array.Length))
			{
				result = new Texture2D((int)pnWidth, (int)pnHeight, TextureFormat.RGBA32, mipChain: false);
				result.LoadRawTextureData(array);
				result.Apply();
				result = GTWUtils.FlipTextureVertically(result);
			}
		}
		return result;
	}

	public void UploadHighestCheckpoint(int score)
	{
		if (!_leaderboardFound)
		{
			Debug.LogError("[LeaderboardManager] UploadScore called too early. Leaderboard not yet found.");
		}
		else if (score > _highestCheckpoint)
		{
			_highestCheckpoint = score;
			if (CanUploadImmediately())
			{
				PerformUpload(score);
			}
			else
			{
				QueueUpload(score);
			}
		}
	}

	public void DownloadFriendsEntries()
	{
		_lastDownloadTime = Time.unscaledTime;
		if (!_leaderboardFound)
		{
			Debug.LogError("[LeaderboardManager] DownloadTopEntries called too early. Leaderboard not yet found.");
			return;
		}
		SteamAPICall_t hAPICall = SteamUserStats.DownloadLeaderboardEntries(_steamLeaderboard, ELeaderboardDataRequest.k_ELeaderboardDataRequestFriends, START_RANK, END_RANK);
		_downloadScoresResult.Set(hAPICall);
		Debug.Log("[LeaderboardManager] Requesting friends entries from leaderboard...");
	}

	public void DownloadFriendsEntries(float cooldown)
	{
		if (Time.unscaledTime > _lastDownloadTime + cooldown)
		{
			DownloadFriendsEntries();
		}
	}

	private void FindAndSetPlayersHighestScoreFromLeaderboard(List<LeaderboardEntryData> entries)
	{
		LeaderboardEntryData leaderboardEntryData = entries.Find((LeaderboardEntryData x) => x.PlayerName == LeaderboardName);
		if (leaderboardEntryData != null)
		{
			_highestCheckpoint = leaderboardEntryData.HighestCheckpoint;
		}
		else
		{
			_highestCheckpoint = 0;
		}
	}

	private void SetupLeaderboard()
	{
		_isInitialSetupComplete = false;
		SteamAPICall_t hAPICall = SteamUserStats.FindOrCreateLeaderboard(LEADERBOARD_NAME, ELeaderboardSortMethod.k_ELeaderboardSortMethodDescending, ELeaderboardDisplayType.k_ELeaderboardDisplayTypeNumeric);
		_findLeaderboardResult.Set(hAPICall);
		Debug.Log("[LeaderboardManager] Attempting to find or create leaderboard '" + LEADERBOARD_NAME + "'...");
	}

	private bool CanUploadImmediately()
	{
		if (_hasOutstandingUpload)
		{
			return false;
		}
		CleanupOldTimestamps();
		return _uploadTimestamps.Count < MAX_UPLOADS_PER_WINDOW;
	}

	private void CleanupOldTimestamps()
	{
		float num = Time.time - RATE_LIMIT_WINDOW_SECONDS;
		for (int num2 = _uploadTimestamps.Count - 1; num2 >= 0; num2--)
		{
			if (_uploadTimestamps[num2] < num)
			{
				_uploadTimestamps.RemoveAt(num2);
			}
		}
	}

	private void PerformUpload(int score)
	{
		_hasOutstandingUpload = true;
		_uploadTimestamps.Add(Time.time);
		SteamAPICall_t hAPICall = SteamUserStats.UploadLeaderboardScore(_steamLeaderboard, ELeaderboardUploadScoreMethod.k_ELeaderboardUploadScoreMethodForceUpdate, score, null, 0);
		_uploadScoreResult.Set(hAPICall);
		Debug.Log($"[LeaderboardManager] Uploading score {score}...");
	}

	private void QueueUpload(int score)
	{
		if (!_pendingUploadScore.HasValue || score > _pendingUploadScore.Value)
		{
			_pendingUploadScore = score;
			Debug.Log($"[LeaderboardManager] Queued score {score} for upload (rate limited).");
			SavePendingUploadToDisk(score);
			StartRateLimitMonitoring();
		}
	}

	private void ProcessPendingUploads()
	{
		if (_pendingUploadScore.HasValue && CanUploadImmediately())
		{
			int value = _pendingUploadScore.Value;
			_pendingUploadScore = null;
			ClearPendingUploadFromDisk();
			PerformUpload(value);
			if (!_pendingUploadScore.HasValue)
			{
				StopRateLimitMonitoring();
			}
		}
	}

	private void ForceUploadOnQuit(int score)
	{
		_pendingUploadScore = null;
		ClearPendingUploadFromDisk();
		_hasOutstandingUpload = true;
		SteamAPICall_t hAPICall = SteamUserStats.UploadLeaderboardScore(_steamLeaderboard, ELeaderboardUploadScoreMethod.k_ELeaderboardUploadScoreMethodForceUpdate, score, null, 0);
		_uploadScoreResult.Set(hAPICall);
		Debug.Log($"[LeaderboardManager] Force uploading score {score} on application quit (bypassing rate limits)...");
	}

	private void StartRateLimitMonitoring()
	{
		if (!_rateLimitMonitorActive)
		{
			_rateLimitMonitorActive = true;
			StartCoroutine(RateLimitMonitorCoroutine());
			Debug.Log("[LeaderboardManager] Started rate limit monitoring for pending uploads.");
		}
	}

	private void StopRateLimitMonitoring()
	{
		if (_rateLimitMonitorActive)
		{
			_rateLimitMonitorActive = false;
			Debug.Log("[LeaderboardManager] Stopped rate limit monitoring.");
		}
	}

	private IEnumerator RateLimitMonitorCoroutine()
	{
		while (_rateLimitMonitorActive && _pendingUploadScore.HasValue)
		{
			yield return new WaitForSeconds(5f);
			if (_pendingUploadScore.HasValue)
			{
				ProcessPendingUploads();
			}
		}
		_rateLimitMonitorActive = false;
	}

	private void SavePendingUploadToDisk(int score)
	{
		PlayerPrefs.SetInt(PENDING_UPLOAD_KEY, score);
	}

	private void ClearPendingUploadFromDisk()
	{
		if (PlayerPrefs.HasKey(PENDING_UPLOAD_KEY))
		{
			PlayerPrefs.DeleteKey(PENDING_UPLOAD_KEY);
			Debug.Log("[LeaderboardManager] Cleared pending upload from disk.");
		}
	}

	private void RestorePendingUploads()
	{
		if (PlayerPrefs.HasKey(PENDING_UPLOAD_KEY))
		{
			Debug.Log("[LeaderboardManager] Checking pending upload from disk...");
			int num = PlayerPrefs.GetInt(PENDING_UPLOAD_KEY);
			if (num > _highestCheckpoint)
			{
				Debug.Log("[LeaderboardManager] Pending upload found. Uploading to leaderboards.");
				UploadHighestCheckpoint(num);
			}
			else
			{
				Debug.Log("[LeaderboardManager] Pending upload score is not greater than current highest checkpoint. Cancelling upload.");
			}
			ClearPendingUploadFromDisk();
		}
		_isInitialSetupComplete = true;
	}
}
