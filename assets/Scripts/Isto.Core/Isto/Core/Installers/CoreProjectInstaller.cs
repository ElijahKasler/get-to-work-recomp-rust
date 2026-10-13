using Isto.Core.Achievements;
using Isto.Core.Analytics;
using Isto.Core.Audio;
using Isto.Core.Cheats;
using Isto.Core.Configuration;
using Isto.Core.Data;
using Isto.Core.Game;
using Isto.Core.Inputs;
using Isto.Core.Items;
using Isto.Core.Localization;
using Isto.Core.Platforms;
using Isto.Core.Scenes;
using Isto.Core.Skins;
using Isto.Core.Speedrun;
using Isto.Core.Themes;
using Isto.Core.UI;
using Rewired;
using Rewired.Integration.UnityUI;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Isto.Core.Installers;

public class CoreProjectInstaller : MonoInstaller<CoreProjectInstaller>
{
	public static bool USE_CORE_TESTING_MASTER_ITEM_LIST;

	public GameObject eventSystemPrefab;

	public GameObject uiSoundsPrefab;

	public GameObject uiMusicPrefab;

	public GameObject gameSoundsCorePrefab;

	public GameObject gameStatePrefab;

	public GameObject analyticsManagerPrefab;

	public GameObject pcGameDataManagerPrefab;

	public GameScenesReference coreGameScenesReference;

	public UIModalPopup uiErrorPopupPrefab;

	public UIModalChoicePopup uiChoicePopupPrefab;

	[Header("Controls")]
	public GameObject controlsPrefab;

	public GameObject rewiredPrefab;

	public GameObject glyphsPrefab;

	[Header("Game Data")]
	public IGameData.GameDataLocation saveSlotLocation;

	public string fileNameSufix = "data.xml";

	[Header("Themes")]
	public ThemeSetup themeSetup;

	public ThemeManager themeManagerPrefab;

	[Header("Skins")]
	public MasterSkinList masterSkinList;

	[Header("Items")]
	[FormerlySerializedAs("masterItemList")]
	public MasterItemList masterItemList;

	[FormerlySerializedAs("coreMasterItemList")]
	public MasterItemList testMasterItemList;

	[Header("Languages")]
	public LanguageList supportedLanguages;

	[Header("Dev Console")]
	public CheatSettings cheatsSettings;

	[FormerlySerializedAs("developerConsolePrefab")]
	public GameObject cheatsPrefab;

	public override void InstallBindings()
	{
		InstallConfig();
		InstallLanguages();
		InstallDataManagers();
		InstallInputs();
		InstallAudio();
		InstallGUI();
		InstallThemes();
		InstallSkins();
		InstallItems();
		InstallAnalytics();
		InstallNetworking();
		InstallPlatformSpecificBindings();
		InstallDevConsole();
	}

	protected virtual void InstallConfig()
	{
		base.Container.Bind<GameScenesReference>().FromInstance(coreGameScenesReference).AsSingle();
		base.Container.Bind<Settings>().FromResource("CoreDefaultSettings");
		base.Container.Bind<SpeedrunSettings>().FromResource("CoreSpeedrunSettings");
		base.Container.Bind(typeof(GameState)).FromComponentInNewPrefab(gameStatePrefab).AsSingle()
			.NonLazy();
	}

	protected virtual void InstallLanguages()
	{
		base.Container.Bind<LanguageList>().WithId("SupportedLanguages").FromInstance(supportedLanguages)
			.AsSingle();
		base.Container.Bind<ILocalizationProvider>().To<I2LocProvider>().AsSingle()
			.NonLazy();
		base.Container.BindFactory<LocTerm.LocalizationType, string, LocTerm, LocTerm.Factory>().FromFactory<LocTermFactory>();
	}

	protected virtual void InstallDataManagers()
	{
		string gameObjectName = "Game Data";
		base.Container.Bind<IGameData>().FromComponentInNewPrefab(pcGameDataManagerPrefab).WithGameObjectName(gameObjectName)
			.AsSingle()
			.NonLazy();
		base.Container.Bind<string>().WithId("SaveFileSuffix").FromInstance(fileNameSufix)
			.AsSingle();
		base.Container.Bind<IGameData.GameDataLocation>().WithId("SaveSlotLocation").FromInstance(saveSlotLocation)
			.AsSingle();
	}

	protected virtual void InstallInputs()
	{
		base.Container.Bind<IControls>().To<Controls>().FromComponentInNewPrefab(controlsPrefab)
			.AsSingle();
		base.Container.Bind<RewiredStandaloneInputModule>().FromComponentInNewPrefab(eventSystemPrefab).AsSingle()
			.NonLazy();
		base.Container.Bind<InputManager>().FromComponentInNewPrefab(rewiredPrefab).AsSingle()
			.NonLazy();
		base.Container.Bind<UserKeybindingDataStore>().FromComponentInHierarchy().AsSingle();
		base.Container.Bind<ControllerGlyphs>().FromComponentInNewPrefab(glyphsPrefab).AsSingle();
	}

	protected virtual void InstallAudio()
	{
		base.Container.Bind<IGameMusic>().FromComponentInNewPrefab(uiMusicPrefab).UnderTransform(base.transform)
			.AsSingle();
		base.Container.Bind<IGameVolume>().To<FMODGameVolume>().FromNewComponentOnNewGameObject()
			.AsSingle();
		base.Container.Bind<UISounds>().FromComponentInNewPrefab(uiSoundsPrefab).UnderTransform(base.transform)
			.AsSingle();
		base.Container.Bind<IGameSounds>().FromComponentInNewPrefab(gameSoundsCorePrefab).UnderTransform(base.transform)
			.AsSingle();
	}

	protected virtual void InstallGUI()
	{
		base.Container.Bind<UIModalPopup>().FromComponentInNewPrefab(uiErrorPopupPrefab).WithGameObjectName("Error Dialog")
			.AsSingle()
			.NonLazy();
		base.Container.Bind<UIModalChoicePopup>().FromComponentInNewPrefab(uiChoicePopupPrefab).WithGameObjectName("Choice Dialog")
			.AsSingle()
			.NonLazy();
	}

	protected virtual void InstallThemes()
	{
		base.Container.Bind<ThemeManager>().FromComponentInNewPrefab(themeManagerPrefab).WithGameObjectName("Theme Manager")
			.AsSingle()
			.NonLazy();
		base.Container.Bind<ThemeSetup>().FromInstance(themeSetup).AsSingle();
	}

	protected virtual void InstallSkins()
	{
		base.Container.Bind<MasterSkinList>().FromInstance(masterSkinList).AsSingle();
	}

	protected virtual void InstallItems()
	{
		if (USE_CORE_TESTING_MASTER_ITEM_LIST)
		{
			Debug.Log("Installing automated testing simplified MasterItemList");
			base.Container.Bind<MasterItemList>().FromInstance(testMasterItemList).AsSingle();
		}
		else
		{
			Debug.Log("Installing project specific MasterItemList");
			base.Container.Bind<MasterItemList>().FromInstance(masterItemList).AsSingle();
		}
	}

	protected virtual void InstallAnalytics()
	{
		base.Container.Bind(typeof(IAnalyticsHandler)).FromComponentInNewPrefab(analyticsManagerPrefab).WithGameObjectName("Analytics Manager")
			.AsSingle()
			.NonLazy();
	}

	protected virtual void InstallNetworking()
	{
	}

	protected virtual void InstallPlatformSpecificBindings()
	{
		base.Container.Bind<IPlatformTools>().FromInstance(new EmptyPlatformTools()).AsSingle();
		base.Container.Bind<IAchievements>().FromInstance(new DisabledAchievements()).AsSingle();
	}

	protected virtual void InstallDevConsole()
	{
		base.Container.Bind<CheatSettings>().FromInstance(cheatsSettings).AsSingle();
		base.Container.QueueForInject(cheatsSettings);
		base.Container.Bind<CheatsManager>().FromComponentsInNewPrefab(cheatsPrefab).AsSingle()
			.NonLazy();
	}
}
