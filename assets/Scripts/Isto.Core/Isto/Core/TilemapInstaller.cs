using Isto.Core.Tiles;
using Zenject;

namespace Isto.Core;

public class TilemapInstaller : MonoInstaller<TilemapInstaller>, IActionOnSceneOpenInEditor
{
	public TilemapCullingSettings tilemapSettings;

	public override void InstallBindings()
	{
		TilemapGlobalController tilemapGlobalController = base.Container.Resolve<TilemapGlobalController>();
		if (tilemapGlobalController != null)
		{
			tilemapGlobalController.AddTilemapSettings(tilemapSettings);
		}
		base.Container.Bind<TilemapCullingSettings>().FromInstance(tilemapSettings).AsSingle();
	}

	public void DoAction()
	{
	}
}
