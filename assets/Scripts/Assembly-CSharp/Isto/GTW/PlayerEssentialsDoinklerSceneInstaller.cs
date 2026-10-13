using System.Collections;
using System.Collections.Generic;
using Isto.Core.Data;
using Isto.GTW.Configuration;
using Isto.GTW.Data;
using Isto.GTW.Managers;
using Isto.GTW.Providers;
using UnityEngine;

namespace Isto.GTW;

public class PlayerEssentialsDoinklerSceneInstaller : PlayerEssentialsSceneInstaller
{
	[SerializeField]
	private GTWDoinklerPortfolioDefinition _doinklerPortfolioDefinition;

	private GTWGameState _gtwGameState;

	private List<GTWGameWorldDefinition> _gameWorlds => _doinklerPortfolioDefinition.GTWGameWorldDefinitions;

	public override void InstallBindings()
	{
		base.InstallBindings();
		base.Container.Bind<DoinklerLevelVariables>().FromComponentInHierarchy().AsSingle();
		BindDataManagers();
		_gtwGameState = base.Container.Resolve<GTWGameState>();
	}

	private void BindDataManagers()
	{
		if (enableDataManagers)
		{
			base.Container.Bind<DoinklerLevelDataManager>().FromNewComponentOnNewGameObject().AsSingle()
				.NonLazy();
		}
	}

	private void Awake()
	{
		if (_gtwGameState.IsDoinklerPortfolio)
		{
			StartCoroutine(LoadDoinklerWorldLevelVariables());
		}
	}

	private IEnumerator LoadDoinklerWorldLevelVariables()
	{
		IGameData gameData = base.Container.Resolve<IGameData>();
		IDoinklerWorldDefinitionProvider doinklerWorldDefinitionProvider = base.Container.Resolve<IDoinklerWorldDefinitionProvider>();
		LevelVariables levelVariables = base.Container.Resolve<LevelVariables>();
		int worldsFinishedLoading = 0;
		int worldsToLoad = _gameWorlds.Count;
		bool clearDoinklerLevels = false;
		foreach (GTWGameWorldDefinition gtwGameWorldDefinition in _gameWorlds)
		{
			int saveSlot = (int)gtwGameWorldDefinition.SaveSlotId;
			gameData.HasSaveData(saveSlot, (bool dataExists) =>
			{
				if (dataExists)
				{
					gameData.LoadGameData(saveSlot, (bool success) =>
					{
						worldsFinishedLoading++;
					});
				}
				else
				{
					int num = worldsFinishedLoading;
					worldsFinishedLoading = num + 1;
					if (doinklerWorldDefinitionProvider.Current != null && doinklerWorldDefinitionProvider.Current.SaveSlotId == gtwGameWorldDefinition.SaveSlotId)
					{
						clearDoinklerLevels = true;
					}
				}
			});
		}
		while (worldsFinishedLoading != worldsToLoad)
		{
			yield return null;
		}
		if (clearDoinklerLevels)
		{
			levelVariables.boolVariables.Clear();
		}
	}
}
