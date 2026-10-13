using Isto.GTW.LevelFeatures;
using Zenject;

namespace Isto.GTW;

public class LevelSceneInstaller : MonoInstaller<LevelSceneInstaller>
{
	public override void InstallBindings()
	{
		base.Container.Bind<CheckpointManager>().FromComponentInHierarchy().AsSingle();
	}
}
