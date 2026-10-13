using Data;
using Isto.Core.Game;
using Isto.Core.Installers;
using Isto.Core.UI;
using Isto.GTW.Data;
using Isto.GTW.Managers;
using UnityEngine;

namespace Isto.GTW;

public class TitleMenuSceneInstaller : SimpleTitleMenuSceneInstaller
{
	[SerializeField]
	private TitleScreenPlayerDataManager _titleScreenPlayerDataManager;

	[SerializeField]
	private TitleScreenDialogueDataManager _titleScreenDialogueDataManager;

	public override void InstallBindings()
	{
		base.Container.Bind<TitleMenuStateMachine>().FromComponentInHierarchy().AsSingle();
		base.Container.Bind<SimpleTitleMenuStateMachine>().To<TitleMenuStateMachine>().FromResolve();
		base.Container.Bind<IUIMenu>().FromComponentInHierarchy().AsSingle();
		base.Container.Bind<IGameProgressProvider>().To<GTWProgressProvider>().FromNewComponentOnNewGameObject()
			.AsSingle();
		base.Container.Bind<LevelVariables>().FromNewComponentOnNewGameObject().AsSingle();
		base.Container.Bind<DoinklerLevelVariables>().FromNewComponentOnNewGameObject().AsSingle();
		base.Container.Bind<LevelDataManager>().FromNewComponentOnNewGameObject().AsSingle()
			.NonLazy();
		base.Container.Bind<DoinklerLevelDataManager>().FromNewComponentOnNewGameObject().AsSingle()
			.NonLazy();
		base.Container.Bind<TitleScreenPlayerDataManager>().FromComponentInNewPrefab(_titleScreenPlayerDataManager).AsSingle()
			.NonLazy();
		base.Container.Bind<TitleScreenDialogueDataManager>().FromComponentInNewPrefab(_titleScreenDialogueDataManager).AsSingle()
			.NonLazy();
	}
}
