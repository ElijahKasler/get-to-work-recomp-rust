using System;
using System.Collections;
using System.Collections.Generic;
using Isto.Core.Audio;
using Isto.Core.Data;
using Isto.Core.Game;
using Isto.Core.Localization;
using Isto.Core.Scenes;
using Isto.GTW.Audio;
using Isto.GTW.Configuration;
using Isto.GTW.Managers;
using Isto.GTW.Providers;
using Isto.GTW.SectionLoading;
using PixelCrushers.DialogueSystem;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Isto.GTW;

public class GTWGameState : GameState
{
	public enum SaveSlotId
	{
		MAIN_GAME = 0,
		DOINKLER_PORTFOLIO_WORLD_1 = 1,
		DOINKLER_PORTFOLIO_WORLD_2 = 2,
		DOINKLER_PORTFOLIO_WORLD_3 = 3,
		DOINKLER_PORTFOLIO_WORLD_4 = 4,
		DOINKLER_PORTFOLIO_WORLD_5 = 5,
		DOINKLER_PORTFOLIO_WORLD_6 = 6,
		DOINKLER_SPECIAL = 7
	}

	[Space]
	[SerializeField]
	[SceneReference]
	private string _doinklerPortfolioEssentialsScene;

	[SerializeField]
	[SceneReference]
	private string _doinklerSpecialEssentialsScene;

	[SerializeField]
	private GTWDoinklerPortfolioDefinition _doinklerPortfolioDefinition;

	private GTWGameSounds _sounds;

	private IDoinklerWorldDefinitionProvider _doinklerWorldDefinitionProvider;

	private float _finalizationProgress = 1f;

	public TimeManager TimeManager { get; set; }

	public bool StartedWithoutGameMode { get; set; }

	public GTWGameLevelDefinition GameLevelDefinition { get; set; }

	public bool IsDoinklerPortfolio
	{
		get
		{
			if (GameLevelDefinition != null)
			{
				return !IsDoinklerSpecial;
			}
			return false;
		}
	}

	public bool IsDoinklerSpecial => _saveSlot == 7;

	public int SaveSlot
	{
		get
		{
			return _saveSlot;
		}
		set
		{
			_saveSlot = value;
		}
	}

	[Inject]
	private void Inject(IGameSounds sounds, IDoinklerWorldDefinitionProvider doinklerWorldDefinitionProvider)
	{
		_sounds = sounds as GTWGameSounds;
		_doinklerWorldDefinitionProvider = doinklerWorldDefinitionProvider;
	}

	public override GameStateSaveData SaveGameStateData()
	{
		GameStateSaveData gameStateSaveData = new GameStateSaveData();
		gameStateSaveData.isAutoSave = false;
		gameStateSaveData.saveSlotName = $"{Loc.Get(defaultSlotNameKey)}{_saveSlot}";
		if (_selectedSaveSlotMetaData != null)
		{
			gameStateSaveData.saveSlotName = _selectedSaveSlotMetaData.saveSlotName;
		}
		if (base.CurrentGameMode != null)
		{
			gameStateSaveData.gameModeName = base.CurrentGameMode.InternalName;
		}
		else
		{
			Debug.LogWarning("Saving Game State: no game mode configured, it will be missing in the save file.");
		}
		gameStateSaveData.gameVersion = version.ActiveVersion.VersionText;
		gameStateSaveData.internalBuildVersion = version.ActiveVersion.shortDate;
		if (TimeManager != null)
		{
			gameStateSaveData.totalGameTimeSeconds = TimeManager.TotalGameTimeUnscaled;
		}
		gameStateSaveData.saveDate = DateTime.Now;
		gameStateSaveData.autoSaveDates = new List<DateTime>();
		gameStateSaveData.themeData = new ThemeManagerData();
		return gameStateSaveData;
	}

	protected override IEnumerator FinalizeLoading()
	{
		_finalizationProgress = 0f;
		yield return null;
		_finalizationProgress = 0.1f;
		while (SectionLoader.IsBusy)
		{
			_finalizationProgress = 0.1f + SectionLoader.SectionLoadingProgress * 0.7f;
			yield return null;
		}
		_finalizationProgress = 0.8f;
		for (float timer = 1f; timer > 0f; timer -= Time.deltaTime)
		{
			float num = 1f - timer;
			_finalizationProgress = 0.8f + num * 0.2f;
			yield return null;
		}
		_finalizationProgress = 1f;
		DialogueManager.instance.Unpause();
		_sounds.StopAllEventInstances();
		_sounds.SetGameplaySoundsPaused(isPaused: false);
		yield return null;
	}

	protected override float GetFinalizeProgress()
	{
		return _finalizationProgress;
	}

	protected override bool IsEssentialScene(Scene newScene)
	{
		if (IsDoinklerPortfolio)
		{
			return newScene.name == _doinklerPortfolioEssentialsScene;
		}
		if (IsDoinklerSpecial)
		{
			return newScene.name == _doinklerSpecialEssentialsScene;
		}
		return base.IsEssentialScene(newScene);
	}

	public int GetCurrentDoinklerWorld()
	{
		int result = -1;
		if (IsDoinklerPortfolio)
		{
			result = _doinklerPortfolioDefinition.GTWGameWorldDefinitions.IndexOf(_doinklerWorldDefinitionProvider.Current);
		}
		return result;
	}

	public int GetDoinklerWorldCount()
	{
		int result = -1;
		if (IsDoinklerPortfolio)
		{
			result = _doinklerPortfolioDefinition.GTWGameWorldDefinitions.Count;
		}
		return result;
	}
}
