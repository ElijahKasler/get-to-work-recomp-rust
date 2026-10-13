using Isto.Core.Beings;
using Isto.Core.Cheats;
using Isto.Core.Data;
using Isto.Core.UI;
using UnityEngine;
using Zenject;

namespace Isto.Core.Installers;

public class SimpleEssentialsSceneInstaller : MonoInstaller<SimpleEssentialsSceneInstaller>
{
	[Header("Game Data")]
	public bool enableDataManagers = true;

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
		base.Container.Bind<SimplePlayerController>().FromComponentInHierarchy().AsSingle();
		base.Container.Bind<IPlayerController>().FromComponentInHierarchy().AsSingle();
		base.Container.Bind<UISimpleMenusClosedState>().FromComponentInHierarchy().AsSingle();
		base.Container.Bind<UISimpleGameMenuState>().FromComponentInHierarchy().AsSingle();
		base.Container.Bind<SimpleGameMenuStateMachine>().FromComponentInHierarchy().AsSingle();
		base.Container.Bind<IUIGameMenu>().FromComponentInHierarchy().AsSingle();
		base.Container.Bind<UIAccessManager>().AsSingle();
		BindDataManagers();
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
		}
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
