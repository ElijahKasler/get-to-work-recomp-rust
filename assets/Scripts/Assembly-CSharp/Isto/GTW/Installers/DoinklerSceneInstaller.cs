using Isto.GTW.Configuration;
using Isto.GTW.Managers;
using Isto.GTW.Player;
using Isto.GTW.Providers;
using Isto.GTW.UI;
using UnityEngine;
using Zenject;

namespace Isto.GTW.Installers;

public class DoinklerSceneInstaller : MonoInstaller<DoinklerSceneInstaller>
{
	[Inject]
	private PlayerController _playerController;

	[SerializeField]
	private GTWUINextLevelPopup _uiNextLevelPopup;

	[SerializeField]
	private GTWGameWorldDefinition _sceneDefinition;

	[SerializeField]
	private bool _restartAbilityAvailable;

	public override void InstallBindings()
	{
		base.Container.Bind<GTWUINextLevelPopup>().FromComponentInNewPrefab(_uiNextLevelPopup).WithGameObjectName("Next Level Popup")
			.AsSingle()
			.NonLazy();
		base.Container.Bind<GTWDoinklerLevelTimeManager>().FromNewComponentOnNewGameObject().WithGameObjectName("Level Time Manager")
			.AsSingle()
			.NonLazy();
		base.Container.Resolve<IDoinklerWorldDefinitionProvider>().Current = _sceneDefinition;
	}

	private void Awake()
	{
		_playerController.restartAbilityAvailable = _restartAbilityAvailable;
	}
}
