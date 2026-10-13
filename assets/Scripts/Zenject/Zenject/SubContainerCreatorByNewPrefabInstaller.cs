using System;
using System.Collections.Generic;
using System.Linq;
using ModestTree;

namespace Zenject;

public class SubContainerCreatorByNewPrefabInstaller : SubContainerCreatorByNewPrefabDynamicContext
{
	private readonly Type _installerType;

	private readonly List<TypeValuePair> _extraArgs;

	public SubContainerCreatorByNewPrefabInstaller(DiContainer container, IPrefabProvider prefabProvider, GameObjectCreationParameters gameObjectBindInfo, Type installerType, List<TypeValuePair> extraArgs)
		: base(container, prefabProvider, gameObjectBindInfo)
	{
		_installerType = installerType;
		_extraArgs = extraArgs;
		Assert.That(installerType.DerivesFrom<InstallerBase>(), "Invalid installer type given during bind command.  Expected type '{0}' to derive from 'Installer<>'", installerType);
	}

	protected override void AddInstallers(List<TypeValuePair> args, GameObjectContext context)
	{
		context.AddNormalInstaller(new ActionInstaller((DiContainer subContainer) =>
		{
			((InstallerBase)subContainer.InstantiateExplicit(_installerType, args.Concat(_extraArgs).ToList())).InstallBindings();
		}));
	}
}
