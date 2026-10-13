using Cinemachine;
using Code.Scripts.UI.Speedometer;
using Isto.Core.Beings;
using Isto.Core.Cheats;
using Isto.Core.Configuration;
using Isto.Core.Game;
using Isto.Core.Speedrun;
using Isto.Core.UI;
using Isto.GTW.Camera;
using Isto.GTW.Data;
using Isto.GTW.Managers;
using Isto.GTW.Player;
using Isto.GTW.Player.States;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Isto.GTW;

public class PlayerEssentialsSceneInstaller : MonoInstaller<PlayerEssentialsSceneInstaller>
{
	[Header("Player States")]
	public GTWPlayerMoveState moveState;

	public GTWPlayerRagdollState ragdollState;

	[Header("Game Stats")]
	public GTWGameStats gameStatsPrefab;

	[Header("Game Data")]
	public bool enableDataManagers = true;

	[Header("Settings")]
	public SceneSettingMappings settingsMapping;

	public SpeedrunSettings sceneSpeedrunSettings;

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
		base.Container.Bind<CorePlayerController>().FromComponentInHierarchy().AsSingle();
		base.Container.Bind<IPlayerController>().FromComponentInHierarchy().AsSingle();
		base.Container.Bind<PlayerController>().FromComponentInHierarchy().AsSingle();
		QueuePlayerStates();
		base.Container.Bind<CinemachineBrain>().FromComponentInHierarchy().AsSingle();
		base.Container.Bind<FixedVirtualCameraController>().FromComponentInHierarchy().AsSingle();
		base.Container.Bind<TimeManager>().FromComponentInHierarchy().AsSingle();
		base.Container.Bind<LevelVariables>().FromComponentInHierarchy().AsSingle();
		base.Container.Bind<IUIGameMenu>().FromComponentInHierarchy().AsSingle();
		base.Container.Bind<UISimpleMenusClosedState>().FromComponentInHierarchy().AsSingle();
		base.Container.Bind<UISimpleGameMenuState>().FromComponentInHierarchy().AsSingle();
		base.Container.Bind<SimpleGameMenuStateMachine>().FromComponentInHierarchy().AsSingle();
		base.Container.Bind<UIAccessManager>().AsSingle();
		base.Container.Bind<Speedometer>().FromComponentInHierarchy().AsSingle();
		base.Container.Bind<IGameProgressProvider>().FromComponentInHierarchy().AsSingle();
		base.Container.Bind<GTWGameStats>().FromComponentInNewPrefab(gameStatsPrefab).AsSingle()
			.NonLazy();
		base.Container.Rebind<SpeedrunSettings>().FromInstance(sceneSpeedrunSettings).AsSingle();
		BindDataManagers();
		BindGameplaySettings();
		BindCheaterUI();
	}

	private void BindDataManagers()
	{
		if (enableDataManagers)
		{
			Transform transform = new GameObject("Data Managers").transform;
			transform.SetParent(base.transform);
			base.Container.Bind<PlayerDataManager>().FromNewComponentOn(transform.gameObject).AsSingle()
				.NonLazy();
			base.Container.Bind<DialogueDataManager>().FromNewComponentOn(transform.gameObject).AsSingle()
				.NonLazy();
			base.Container.Bind<LevelDataManager>().FromNewComponentOn(transform.gameObject).AsSingle()
				.NonLazy();
		}
	}

	private void BindGameplaySettings()
	{
		GTWGameState gTWGameState = Object.FindObjectOfType<GTWGameState>();
		GameModeDefinition gameModeDefinition = gTWGameState?.CurrentGameMode;
		gTWGameState.StartedWithoutGameMode = false;
		for (int i = 0; i < SceneManager.sceneCount; i++)
		{
			string text = SceneManager.GetSceneAt(i).name;
			if (gameModeDefinition == null && settingsMapping.TryGetGameMode(text, out var mode) && gTWGameState != null)
			{
				gTWGameState.CurrentGameMode = mode;
				gTWGameState.StartedWithoutGameMode = true;
				gameModeDefinition = gTWGameState.CurrentGameMode;
				Debug.LogWarning("GameplaySettings: Unmapped Game Mode. Current scene \"" + text + "\" associated to game mode \"" + ((mode != null) ? mode.InternalName : "null") + "\".");
			}
		}
	}

	private void QueuePlayerStates()
	{
		base.Container.Bind<GTWPlayerMoveState>().FromInstance(moveState).AsSingle();
		base.Container.QueueForInject(moveState);
		base.Container.Bind<GTWPlayerRagdollState>().FromInstance(ragdollState).AsSingle();
		base.Container.QueueForInject(ragdollState);
	}

	private void BindCheaterUI()
	{
		if (_cheatSettings.CheatsEnabled)
		{
			base.Container.Bind<CheatMenuState>().FromComponentsInNewPrefab(cheatMenuPrefab).AsSingle()
				.NonLazy();
			return;
		}
		CheatMenuState instance = null;
		base.Container.Bind<CheatMenuState>().To<CheatMenuState>().FromInstance(instance)
			.AsSingle()
			.NonLazy();
	}
}
