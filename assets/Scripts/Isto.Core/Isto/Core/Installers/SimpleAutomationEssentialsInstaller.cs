using Isto.Core.Automation;
using Isto.Core.Beings;
using Isto.Core.Cameras;
using Isto.Core.Cheats;
using Isto.Core.Configuration;
using Isto.Core.Data;
using Isto.Core.Game;
using Isto.Core.Items;
using Isto.Core.Localization;
using Isto.Core.UI;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using Zenject;

namespace Isto.Core.Installers;

public class SimpleAutomationEssentialsInstaller : MonoInstaller<SimpleAutomationEssentialsInstaller>
{
	[Header("Game Data")]
	public bool enableDataManagers = true;

	[Header("Player States (in project)")]
	public AutomationPlayerMoveState moveState;

	public PlayerInteractWithItemState interactState;

	public PlayerPlaceItemState placeItemState;

	public PlayerDismantleState dismantleState;

	public PlayerHarvestState harvestState;

	[Header("Languages")]
	public LanguageList supportedLanguages;

	[Header("Cheat Menu")]
	public CheatMenuState cheatMenuPrefab;

	private CheatSettings _cheatSettings;

	[Inject]
	public void Inject(CheatSettings cheatSettings)
	{
		_cheatSettings = cheatSettings;
	}

	public override void InstallBindings()
	{
		BindGameSettings();
		base.Container.Bind<CameraController>().FromComponentInHierarchy().AsSingle();
		BindPlayer();
		BindPlayerStates();
		BindAutomation();
		BindGUI();
		BindMasterItemListItems();
		BindDataManagers();
		BindLocalization();
		BindCheaterUI();
	}

	private GameplaySettings BindGameSettings()
	{
		GameplaySettings gameplaySettings = null;
		GameState gameState = Object.FindObjectOfType<GameState>();
		GameModeDefinition gameModeDefinition = gameState?.CurrentGameMode;
		SceneSettingMappings sceneSettingMappings = gameState?.settingsMapping;
		if (gameplaySettings == null && gameModeDefinition != null && sceneSettingMappings.TryGetSettings<GameplaySettings>(gameModeDefinition, out var settings))
		{
			gameplaySettings = settings;
			Debug.Log("GameplaySettings: Game mode " + (gameModeDefinition?.InternalName ?? "(null)") + " requested gameplay settings: " + settings.name);
		}
		for (int i = 0; i < SceneManager.sceneCount; i++)
		{
			string text = SceneManager.GetSceneAt(i).name;
			if (gameModeDefinition == null && sceneSettingMappings.TryGetGameMode(text, out var mode) && gameState != null)
			{
				gameState.CurrentGameMode = mode;
				gameModeDefinition = gameState.CurrentGameMode;
				Debug.LogWarning("GameplaySettings: Unmapped Game Mode. Current scene \"" + text + "\" associated to game mode \"" + ((mode != null) ? mode.InternalName : "null") + "\".");
			}
			if (gameplaySettings == null && sceneSettingMappings.TryGetSettings<GameplaySettings>(text, out var settings2))
			{
				gameplaySettings = settings2;
				Debug.LogWarning("GameplaySettings: Unmapped Game Mode. Current scene \"" + text + "\" associated to gameplay settings \"" + settings2.name + "\".");
			}
		}
		if (gameplaySettings == null)
		{
			gameplaySettings = sceneSettingMappings.defaultSettings;
			Debug.LogWarning("GameplaySettings: No settings found for any game modes or scenes currently loaded, using default \"" + gameplaySettings.name + "\"");
		}
		base.Container.Bind<GameplaySettings>().FromInstance(gameplaySettings).AsSingle();
		return gameplaySettings;
	}

	private void BindPlayer()
	{
		base.Container.Bind<AutomationPlayerController>().FromComponentInHierarchy().AsSingle();
		base.Container.Bind<IPlayerController>().FromComponentInHierarchy().AsSingle();
		base.Container.Bind<PlayerItemInteraction>().FromComponentInHierarchy().AsSingle();
		base.Container.Bind<PlayerInventory>().FromComponentInHierarchy().AsSingle();
		base.Container.Bind<NavMeshAgent>().FromComponentInHierarchy().AsSingle();
		base.Container.Bind<PlayerHealth>().FromComponentInHierarchy().AsSingle();
		base.Container.Bind<PlayerProgress>().FromComponentInHierarchy().AsSingle();
	}

	private void BindAutomation()
	{
		base.Container.BindFactory<CoreItemParams, AutomationCoreItem, AutomationCoreItem.Factory>();
		base.Container.BindFactory<AutomationResourceParams, AutomationResource, AutomationResource.Factory>();
		AutomationSystem instance = new AutomationSystem(1f, base.Container.Resolve<AutomationCoreItem.Factory>(), base.Container.Resolve<AutomationResource.Factory>());
		base.Container.Bind<AutomationSystem>().FromInstance(instance).AsSingle();
	}

	private void BindGUI()
	{
		base.Container.Bind<UISimpleMenusClosedState>().FromComponentInHierarchy().AsSingle();
		base.Container.Bind<UISimpleGameMenuState>().FromComponentInHierarchy().AsSingle();
		base.Container.Bind<SimpleGameMenuStateMachine>().FromComponentInHierarchy().AsSingle();
		base.Container.Bind<IUIGameMenu>().FromComponentInHierarchy().AsSingle();
		base.Container.Bind<UIAccessManager>().AsSingle();
		UIMessagesAsLogs instance = new UIMessagesAsLogs();
		base.Container.Bind<IUIMessages>().WithId(UIMessageHandlerType.HighPriorityMessage).FromInstance(instance);
		base.Container.Bind<IUIMessages>().WithId(UIMessageHandlerType.ProgressMessage).FromInstance(instance);
		base.Container.Bind<IUIMessages>().WithId(UIMessageHandlerType.Message).FromInstance(instance);
		base.Container.Bind<IUIDisplayMessage>().FromInstance(instance).AsSingle();
	}

	private void BindPlayerStates()
	{
		base.Container.Bind<AutomationPlayerMoveState>().FromInstance(moveState).AsSingle();
		base.Container.QueueForInject(moveState);
		base.Container.Bind<PlayerInteractWithItemState>().FromInstance(interactState).AsSingle();
		base.Container.QueueForInject(interactState);
		base.Container.Bind<PlayerPlaceItemState>().FromInstance(placeItemState).AsSingle();
		base.Container.QueueForInject(placeItemState);
		base.Container.Bind<PlayerDismantleState>().FromInstance(dismantleState).AsSingle();
		base.Container.QueueForInject(dismantleState);
		base.Container.Bind<PlayerHarvestState>().FromInstance(harvestState).AsSingle();
		base.Container.QueueForInject(harvestState);
	}

	private void BindMasterItemListItems()
	{
		MasterItemList masterItemList = base.Container.TryResolve<MasterItemList>();
		if (masterItemList == null)
		{
			return;
		}
		for (int i = 0; i < masterItemList.items.Count; i++)
		{
			if (masterItemList.items[i] == null)
			{
				Debug.LogError("Master Item List contains null entries, please check entry number: " + i);
				continue;
			}
			base.Container.QueueForInject(masterItemList.items[i]);
			if (masterItemList.items[i] is UpgradeItem upgradeItem)
			{
				for (int j = 0; j < upgradeItem.effects.Count; j++)
				{
					if (upgradeItem.effects[j] != null)
					{
						base.Container.QueueForInject(upgradeItem.effects[j]);
					}
					else
					{
						Debug.LogError("Null item effect on item: " + upgradeItem.itemName + ", please correct this");
					}
				}
			}
			else
			{
				if (!(masterItemList.items[i] is UseableItem useableItem))
				{
					continue;
				}
				for (int k = 0; k < useableItem.effects.Count; k++)
				{
					if (useableItem.effects[k] != null)
					{
						base.Container.QueueForInject(useableItem.effects[k]);
					}
					else
					{
						Debug.LogError("Null item effect on item: " + useableItem.itemName + ", please correct this", useableItem);
					}
				}
			}
		}
	}

	private void BindDataManagers()
	{
		if (enableDataManagers)
		{
			Transform transform = new GameObject("Data Managers").transform;
			transform.SetParent(base.transform);
			base.Container.Bind<PlayerDataManager>().FromNewComponentOn(transform.gameObject).AsSingle()
				.NonLazy();
		}
	}

	private void BindLocalization()
	{
		base.Container.Bind<LanguageList>().WithId("SupportedLanguages").FromInstance(supportedLanguages)
			.AsSingle();
		base.Container.QueueForInject(supportedLanguages);
		base.Container.Bind<ILocalizationProvider>().To<I2LocProvider>().AsSingle();
		base.Container.BindFactory<LocTerm.LocalizationType, string, LocTerm, LocTerm.Factory>().FromFactory<LocTermFactory>();
	}

	private void BindCheaterUI()
	{
		if (_cheatSettings.CheatsEnabled)
		{
			base.Container.Bind<CheatMenuState>().FromComponentsInNewPrefab(cheatMenuPrefab).AsSingle()
				.NonLazy();
		}
	}
}
