using System.Collections;
using System.Collections.Generic;
using Isto.Core.Configuration;
using Isto.Core.Game;
using UnityEngine;
using UnityEngine.Analytics;
using Zenject;

namespace Isto.Core.Analytics;

public class UnityAnalyticsManager : MonoBehaviour, IAnalyticsHandler
{
	[Inject]
	private GameState _gameState;

	protected IGameProgressProvider GameProgress => _gameState.GameProgressProvider;

	protected int GameProgressLevel => GameProgress?.GetCurrentGameProgressLevel() ?? 0;

	protected float GameSecondsInLevel => GameProgress?.GetGameSecondsElapsedInCurrentProgressLevel() ?? 0f;

	protected float GameSecondsSinceStart => GameProgress?.GetTotalGameSecondsElapsedInPlaythrough() ?? 0f;

	private void Awake()
	{
		((IAnalyticsHandler)this).RegisterApplicationStarted();
	}

	private void Start()
	{
	}

	private IEnumerator EventSequenceSimulation()
	{
		yield return null;
		yield return new WaitForSeconds(3f);
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		dictionary.Add(IAnalyticsHandler.AnalyticsDataKeys.GAMEMODESELECTED_NAME, "MainGame");
		TriggerEvent(IAnalyticsHandler.AnalyticsEvent.GameModeSelected, dictionary);
		dictionary.Clear();
		_ = Time.timeSinceLevelLoad;
		yield return new WaitForSeconds(0.5f);
		for (int i = 1; i <= 13; i++)
		{
			_ = Time.timeSinceLevelLoad;
		}
		yield return new WaitForSeconds(1.33f);
	}

	public bool TriggerEvent(IAnalyticsHandler.AnalyticsEvent e, Dictionary<string, object> data = null)
	{
		AnalyticsResult analyticsResult = UnityEngine.Analytics.Analytics.CustomEvent(e.ToString(), data);
		if (analyticsResult == AnalyticsResult.Ok)
		{
			Debug.Log($"UnityAnalytics event {e} has been sent");
		}
		else
		{
			Debug.LogError($"UnityAnalytics event {e} has failed: {analyticsResult}");
		}
		return analyticsResult == AnalyticsResult.Ok;
	}

	bool IAnalyticsHandler.RegisterGameProgress(int level, float gameSecondsSinceLastLevel, float gameSecondsSinceStart)
	{
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		dictionary.Add(IAnalyticsHandler.AnalyticsDataKeys.GAMEPROGRESS_LEVEL, level);
		string key = GenerateLevelKey(level);
		bool flag = PlayerPrefs.GetInt(key, 0) == 0;
		PlayerPrefs.SetInt(key, 1);
		PlayerPrefs.Save();
		dictionary.Add(IAnalyticsHandler.AnalyticsDataKeys.GAMEPROGRESS_FIRST_EVER, flag);
		dictionary.Add(IAnalyticsHandler.AnalyticsDataKeys.GAMEPROGRESS_LEVEL_TIME, gameSecondsSinceLastLevel);
		dictionary.Add(IAnalyticsHandler.AnalyticsDataKeys.GAMEPROGRESS_TOTAL_GAME_TIME, gameSecondsSinceStart);
		return TriggerEvent(IAnalyticsHandler.AnalyticsEvent.GameLevelProgress, dictionary);
	}

	private static string GenerateLevelKey(int level)
	{
		return "Level_Visited_" + level;
	}

	bool IAnalyticsHandler.RegisterApplicationStarted()
	{
		BuildTypeEnum buildTypeEnum = BuildTypeEnum.DEVELOPER;
		string value = IAnalyticsHandler.AnalyticsDataKeys.GAMESTART_BUILD_DATE_DEFAULT;
		string arg = IAnalyticsHandler.AnalyticsDataKeys.GAMESTART_BUILD_NUMBER_DEFAULT;
		VersionInfo versionInfo = _gameState.version;
		if (versionInfo == null)
		{
			versionInfo = Resources.Load<VersionInfo>("CoreGameVersionInfo");
		}
		if (versionInfo == null)
		{
			Debug.LogError("Can't load version info asset");
		}
		else
		{
			versionInfo.PrintCurrentVersion();
			buildTypeEnum = versionInfo.Type;
			value = versionInfo.ActiveVersion.shortDate;
			arg = versionInfo.ActiveVersion.ShortVersionText;
		}
		string value2 = string.Format(IAnalyticsHandler.AnalyticsDataKeys.GAMESTART_BUILD_NUMBER_FORMAT, arg);
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		dictionary.Add(IAnalyticsHandler.AnalyticsDataKeys.GAMESTART_BUILD_TYPE, buildTypeEnum.ToString());
		dictionary.Add(IAnalyticsHandler.AnalyticsDataKeys.GAMESTART_BUILD_DATE, value);
		dictionary.Add(IAnalyticsHandler.AnalyticsDataKeys.GAMESTART_BUILD_NUMBER, value2);
		return TriggerEvent(IAnalyticsHandler.AnalyticsEvent.GameStart, dictionary);
	}

	bool IAnalyticsHandler.RegisterThemeChanged(string internalThemeName)
	{
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		dictionary.Add(IAnalyticsHandler.AnalyticsDataKeys.THEMECHANGED_NAME, internalThemeName);
		return TriggerEvent(IAnalyticsHandler.AnalyticsEvent.ThemeChanged, dictionary);
	}

	bool IAnalyticsHandler.RegisterMenuPageVisited(string uniqueMenuPageName)
	{
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		dictionary.Add(IAnalyticsHandler.AnalyticsDataKeys.MENUPAGEVISIT_ID, uniqueMenuPageName);
		return TriggerEvent(IAnalyticsHandler.AnalyticsEvent.MenuPageVisited, dictionary);
	}

	bool IAnalyticsHandler.RegisterGameModeSelected(GameModeDefinition mode)
	{
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		dictionary.Add(IAnalyticsHandler.AnalyticsDataKeys.GAMEMODESELECTED_NAME, mode.InternalName);
		return TriggerEvent(IAnalyticsHandler.AnalyticsEvent.GameModeSelected, dictionary);
	}

	bool IAnalyticsHandler.RegisterDialogueSkipUsed()
	{
		return TriggerEvent(IAnalyticsHandler.AnalyticsEvent.DialogueSkipped);
	}

	bool IAnalyticsHandler.RegisterCinematicSkipUsed()
	{
		return TriggerEvent(IAnalyticsHandler.AnalyticsEvent.CinematicSkipped);
	}

	bool IAnalyticsHandler.RegisterPlayerDeath(string areaName, Vector3 pos, List<string> recentDamageSourceNames)
	{
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		dictionary.Add(IAnalyticsHandler.AnalyticsDataKeys.PLAYERDEATH_AREA, areaName);
		dictionary.Add(IAnalyticsHandler.AnalyticsDataKeys.PLAYERDEATH_POS, pos.ToString());
		foreach (string recentDamageSourceName in recentDamageSourceNames)
		{
			dictionary.Add(IAnalyticsHandler.AnalyticsDataKeys.PLAYERDEATH_DAMAGE_SOURCE, recentDamageSourceName);
		}
		dictionary.Add(IAnalyticsHandler.AnalyticsDataKeys.PLAYERDEATH_LEVEL_NUMBER, GameProgressLevel);
		dictionary.Add(IAnalyticsHandler.AnalyticsDataKeys.PLAYERDEATH_LEVEL_TIME, GameSecondsInLevel);
		dictionary.Add(IAnalyticsHandler.AnalyticsDataKeys.PLAYERDEATH_TOTAL_GAME_TIME, GameSecondsSinceStart);
		return TriggerEvent(IAnalyticsHandler.AnalyticsEvent.PlayerDeath, dictionary);
	}

	bool IAnalyticsHandler.RegisterResearchUnlocked(string researchName)
	{
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		dictionary.Add(IAnalyticsHandler.AnalyticsDataKeys.RESEARCHUNLOCKED_NAME, researchName);
		dictionary.Add(IAnalyticsHandler.AnalyticsDataKeys.RESEARCHUNLOCKED_LEVEL_NUMBER, GameProgressLevel);
		dictionary.Add(IAnalyticsHandler.AnalyticsDataKeys.RESEARCHUNLOCKED_LEVEL_TIME, GameSecondsInLevel);
		dictionary.Add(IAnalyticsHandler.AnalyticsDataKeys.RESEARCHUNLOCKED_TOTAL_GAME_TIME, GameSecondsSinceStart);
		return TriggerEvent(IAnalyticsHandler.AnalyticsEvent.ResearchUnlocked, dictionary);
	}

	bool IAnalyticsHandler.RegisterResearchCenterLevelUp(int level)
	{
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		dictionary.Add(IAnalyticsHandler.AnalyticsDataKeys.RESEARCHUPGRADED_LEVEL, level);
		dictionary.Add(IAnalyticsHandler.AnalyticsDataKeys.RESEARCHUPGRADED_LEVEL_NUMBER, GameProgressLevel);
		dictionary.Add(IAnalyticsHandler.AnalyticsDataKeys.RESEARCHUPGRADED_LEVEL_TIME, GameSecondsInLevel);
		dictionary.Add(IAnalyticsHandler.AnalyticsDataKeys.RESEARCHUPGRADED_TOTAL_GAME_TIME, GameSecondsSinceStart);
		return TriggerEvent(IAnalyticsHandler.AnalyticsEvent.ResearchCenterLevelUp, dictionary);
	}

	bool IAnalyticsHandler.RegisterDeveloperConsoleOpened()
	{
		return TriggerEvent(IAnalyticsHandler.AnalyticsEvent.DeveloperConsoleOpened);
	}

	public virtual bool RegisterSecretCheatActivated(string cheatName)
	{
		int num = 0;
		float num2 = 0f;
		float realtimeSinceStartup = Time.realtimeSinceStartup;
		Debug.LogWarning("CoreUnityAnalyticsManager.RegisterSecretCheatActivated() needs to be implemented!");
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		dictionary.Add(IAnalyticsHandler.AnalyticsDataKeys.CHEATACTIVATED_NAME, cheatName);
		dictionary.Add(IAnalyticsHandler.AnalyticsDataKeys.CHEATACTIVATED_LEVEL_NUMBER, num);
		dictionary.Add(IAnalyticsHandler.AnalyticsDataKeys.CHEATACTIVATED_LEVEL_TIME, num2);
		dictionary.Add(IAnalyticsHandler.AnalyticsDataKeys.CHEATACTIVATED_TOTAL_GAME_TIME, realtimeSinceStartup);
		return TriggerEvent(IAnalyticsHandler.AnalyticsEvent.SecretCheatActivated, dictionary);
	}

	public virtual bool RegisterCheatActivated(string cheatName)
	{
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		dictionary.Add(IAnalyticsHandler.AnalyticsDataKeys.CHEATACTIVATED_NAME, cheatName);
		dictionary.Add(IAnalyticsHandler.AnalyticsDataKeys.CHEATACTIVATED_LEVEL_NUMBER, GameProgressLevel);
		dictionary.Add(IAnalyticsHandler.AnalyticsDataKeys.CHEATACTIVATED_LEVEL_TIME, GameSecondsInLevel);
		dictionary.Add(IAnalyticsHandler.AnalyticsDataKeys.CHEATACTIVATED_TOTAL_GAME_TIME, GameSecondsSinceStart);
		return TriggerEvent(IAnalyticsHandler.AnalyticsEvent.CheatActivated, dictionary);
	}
}
