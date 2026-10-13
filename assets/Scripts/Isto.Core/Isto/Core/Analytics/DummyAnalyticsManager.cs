using System.Collections.Generic;
using Isto.Core.Configuration;
using UnityEngine;

namespace Isto.Core.Analytics;

public class DummyAnalyticsManager : MonoBehaviour, IAnalyticsHandler
{
	public bool TriggerEvent(IAnalyticsHandler.AnalyticsEvent e, Dictionary<string, object> data)
	{
		Debug.Log($"UnityAnalytics event {e} has been ignored because no analytics manager is enabled.");
		return false;
	}

	bool IAnalyticsHandler.RegisterApplicationStarted()
	{
		return false;
	}

	bool IAnalyticsHandler.RegisterDeveloperConsoleOpened()
	{
		return false;
	}

	bool IAnalyticsHandler.RegisterDialogueSkipUsed()
	{
		return false;
	}

	bool IAnalyticsHandler.RegisterCinematicSkipUsed()
	{
		return false;
	}

	bool IAnalyticsHandler.RegisterGameModeSelected(GameModeDefinition mode)
	{
		return false;
	}

	bool IAnalyticsHandler.RegisterGameProgress(int level, float gameSecondsSinceLastLevel, float gameSecondsSinceStart)
	{
		return false;
	}

	bool IAnalyticsHandler.RegisterMenuPageVisited(string uniqueMenuPageName)
	{
		return false;
	}

	public bool RegisterPlayerDeath(string areaName, Vector3 pos, List<string> recentDamageSourceNames)
	{
		return false;
	}

	bool IAnalyticsHandler.RegisterResearchCenterLevelUp(int level)
	{
		return false;
	}

	bool IAnalyticsHandler.RegisterResearchUnlocked(string researchName)
	{
		return false;
	}

	bool IAnalyticsHandler.RegisterSecretCheatActivated(string cheatName)
	{
		return false;
	}

	bool IAnalyticsHandler.RegisterThemeChanged(string internalThemeName)
	{
		return false;
	}

	public bool RegisterCheatActivated(string cheatName)
	{
		return false;
	}
}
