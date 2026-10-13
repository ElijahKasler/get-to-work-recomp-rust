using Isto.Core.UI;
using Zenject;

namespace Isto.Core.Installers;

public class SimpleTitleMenuSceneInstaller : MonoInstaller<SimpleTitleMenuSceneInstaller>
{
	public override void InstallBindings()
	{
		base.Container.Bind<SimpleTitleMenuStateMachine>().FromComponentInHierarchy().AsSingle();
		base.Container.Bind<IUIMenu>().FromComponentInHierarchy().AsSingle();
	}
}
