using System;
using System.Collections.Generic;
using Isto.Core.Scenes;
using UnityEngine;

namespace Isto.Core.Configuration;

[CreateAssetMenu(fileName = "GlobalSettings", menuName = "Scriptables/Tools/GlobalSettingsAsset")]
public class SceneSettingMappings : ScriptableObject
{
	[Serializable]
	public class Mappping
	{
		public GameModeDefinition gameMode;

		[SceneReference]
		public string sceneName;

		[SceneReference]
		public string parentSceneName;

		public GameplaySettings settings;

		public bool sandboxUseOnly;
	}

	public List<Mappping> settingsMappings;

	[Header("Default Settings")]
	[Tooltip("If mapping cannot resolve, use this settings asset for it")]
	public GameplaySettings defaultSettings;

	[Header("Default Scene")]
	[Tooltip("If mapping cannot resolve, use this scene for it")]
	[SceneReference]
	public string defaultScene;

	[SceneReference]
	public string defaultParentSceneName;

	public List<GameModeDefinition> GetGameModes()
	{
		List<GameModeDefinition> list = new List<GameModeDefinition>();
		foreach (Mappping settingsMapping in settingsMappings)
		{
			if (settingsMapping.gameMode != null)
			{
				list.Add(settingsMapping.gameMode);
			}
		}
		return list;
	}

	public bool TryGetScene(GameModeDefinition mode, out Mappping sceneSettings)
	{
		for (int i = 0; i < settingsMappings.Count; i++)
		{
			if (settingsMappings[i].gameMode.InternalName == mode.InternalName)
			{
				sceneSettings = settingsMappings[i];
				if (string.IsNullOrEmpty(sceneSettings.parentSceneName))
				{
					sceneSettings.parentSceneName = defaultParentSceneName;
				}
				return true;
			}
		}
		sceneSettings = new Mappping
		{
			sceneName = defaultScene,
			parentSceneName = defaultParentSceneName
		};
		return false;
	}

	public bool TryGetSettings<TGameplaySettings>(GameModeDefinition mode, out TGameplaySettings settings) where TGameplaySettings : GameplaySettings
	{
		for (int i = 0; i < settingsMappings.Count; i++)
		{
			if (settingsMappings[i].gameMode.InternalName == mode.InternalName)
			{
				settings = settingsMappings[i].settings as TGameplaySettings;
				return true;
			}
		}
		settings = defaultSettings as TGameplaySettings;
		return false;
	}

	public bool TryGetSettings<TGameplaySettings>(string sceneName, out TGameplaySettings settings) where TGameplaySettings : GameplaySettings
	{
		for (int i = 0; i < settingsMappings.Count; i++)
		{
			if (settingsMappings[i].sceneName.Equals(sceneName))
			{
				settings = settingsMappings[i].settings as TGameplaySettings;
				return true;
			}
		}
		settings = defaultSettings as TGameplaySettings;
		return false;
	}

	public bool TryGetGameMode(string sceneName, out GameModeDefinition mode)
	{
		for (int i = 0; i < settingsMappings.Count; i++)
		{
			if (settingsMappings[i].sceneName.Equals(sceneName))
			{
				mode = settingsMappings[i].gameMode;
				return true;
			}
		}
		mode = null;
		return false;
	}

	public void OnValidate()
	{
		HashSet<GameModeDefinition> hashSet = new HashSet<GameModeDefinition>();
		for (int i = 0; i < settingsMappings.Count; i++)
		{
			if (!settingsMappings[i].sandboxUseOnly)
			{
				if (hashSet.Contains(settingsMappings[i].gameMode))
				{
					Debug.LogError("Duplicate Settings Mapping found in SettingsMappings, this is not supported");
				}
				else
				{
					hashSet.Add(settingsMappings[i].gameMode);
				}
			}
		}
	}
}
