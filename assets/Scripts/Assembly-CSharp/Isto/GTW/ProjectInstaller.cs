using Isto.Core.Achievements;
using Isto.Core.Analytics;
using Isto.Core.Configuration;
using Isto.Core.Data;
using Isto.Core.Game;
using Isto.Core.Inputs;
using Isto.Core.Installers;
using Isto.Core.Platforms;
using Isto.Core.Scenes;
using Isto.Core.Skins;
using Isto.Core.Speedrun;
using Isto.Core.Themes;
using Isto.Core.UI;
using Isto.GTW.Leaderboards;
using Isto.GTW.Managers;
using Isto.GTW.Providers;
using Rewired;
using Rewired.Integration.UnityUI;
using UnityEngine;
using Zenject;

namespace Isto.GTW;

public class ProjectInstaller : CoreProjectInstaller
{
	[Header("Get to Work Specifics")]
	public GameObject xboxGameDataManagerPrefab;

	public GameObject DoinklerSpecialLeaderboardManagerPrefab;

	[Header("Platform Tools")]
	public uint steamStoreID;

	public override void InstallBindings()
	{
		base.Container.Bind<GTWInitialization>().FromComponentInHierarchy().AsSingle();
		base.Container.Bind<IControls>().To<Controls>().FromComponentInNewPrefab(controlsPrefab)
			.AsSingle();
		base.Container.Bind<GameScenesReference>().FromInstance(coreGameScenesReference).AsSingle();
		base.Container.Bind<RewiredStandaloneInputModule>().FromComponentInNewPrefab(eventSystemPrefab).AsSingle()
			.NonLazy();
		base.Container.Bind<InputManager>().FromComponentInNewPrefab(rewiredPrefab).AsSingle()
			.NonLazy();
		base.Container.Bind<UserKeybindingDataStore>().FromComponentInHierarchy().AsSingle();
		base.Container.Bind<ControllerGlyphs>().FromComponentInNewPrefab(glyphsPrefab).AsSingle();
		base.Container.Bind<Settings>().FromResource("GTWDefaultSettings");
		base.Container.Bind(typeof(SpeedrunSettings)).FromResource(SpeedrunSettings.ASSET_NAME).AsCached();
		base.Container.Bind(typeof(GTWGameState), typeof(GameState)).FromComponentInNewPrefab(gameStatePrefab).AsSingle()
			.NonLazy();
		InstallAudio();
		string gameObjectName = "Game Data";
		base.Container.Bind<string>().WithId("SaveFileSuffix").FromInstance(fileNameSufix)
			.AsSingle();
		base.Container.Bind<IGameData.GameDataLocation>().WithId("SaveSlotLocation").FromInstance(saveSlotLocation)
			.AsSingle();
		base.Container.Bind<IGameData>().FromComponentInNewPrefab(pcGameDataManagerPrefab).WithGameObjectName(gameObjectName)
			.AsSingle()
			.NonLazy();
		base.Container.Bind(typeof(IAnalyticsHandler)).FromComponentInNewPrefab(analyticsManagerPrefab).WithGameObjectName("Analytics Manager")
			.AsSingle()
			.NonLazy();
		base.Container.Bind<UIModalPopup>().FromComponentInNewPrefab(uiErrorPopupPrefab).WithGameObjectName("Error Dialog")
			.AsSingle()
			.NonLazy();
		base.Container.Bind<UIModalChoicePopup>().FromComponentInNewPrefab(uiChoicePopupPrefab).WithGameObjectName("Choice Dialog")
			.AsSingle()
			.NonLazy();
		base.Container.Bind<ThemeManager>().FromComponentInNewPrefab(themeManagerPrefab).WithGameObjectName("Theme Manager")
			.AsSingle()
			.NonLazy();
		ConfigureDoinklerBindings();
		base.Container.Bind<ThemeSetup>().FromInstance(themeSetup).AsSingle();
		base.Container.Bind<MasterSkinList>().FromInstance(masterSkinList).AsSingle();
		base.gameObject.AddComponent<SteamManager>();
		base.Container.Bind<IPlatformTools>().FromInstance(new SteamPlatformTools(steamStoreID)).AsSingle();
		SteamAchievements achievementsInstance = new SteamAchievements();
		base.Container.Bind<ILeaderboard>().To<GTWSteamLeaderboard>().FromResolve();
		base.Container.Bind<GTWSteamLeaderboard>().FromNewComponentOnNewGameObject().WithGameObjectName("GTWSteamLeaderboard")
			.AsSingle()
			.NonLazy();
		base.Container.Bind(typeof(IAchievements)).FromMethod((InjectContext context) => achievementsInstance).AsSingle()
			.NonLazy();
		base.Container.QueueForInject(achievementsInstance);
		InstallLanguages();
		InstallDevConsole();
	}

	private void ConfigureDoinklerBindings()
	{
		base.Container.Bind<IDoinklerWorldDefinitionProvider>().To<DoinklerWorldDefinitionProvider>().AsSingle();
	}
}
