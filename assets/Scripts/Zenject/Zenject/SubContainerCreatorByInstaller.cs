using System;
using System.Collections.Generic;
using System.Linq;
using ModestTree;

namespace Zenject;

public class SubContainerCreatorByInstaller : ISubContainerCreator
{
	private readonly Type _installerType;

	private readonly DiContainer _container;

	private readonly List<TypeValuePair> _extraArgs;

	private readonly SubContainerCreatorBindInfo _containerBindInfo;

	public SubContainerCreatorByInstaller(DiContainer container, SubContainerCreatorBindInfo containerBindInfo, Type installerType, List<TypeValuePair> extraArgs)
	{
		_installerType = installerType;
		_container = container;
		_extraArgs = extraArgs;
		_containerBindInfo = containerBindInfo;
		Assert.That(installerType.DerivesFrom<InstallerBase>(), "Invalid installer type given during bind command.  Expected type '{0}' to derive from 'Installer<>'", installerType);
	}

	public SubContainerCreatorByInstaller(DiContainer container, SubContainerCreatorBindInfo containerBindInfo, Type installerType)
		: this(container, containerBindInfo, installerType, new List<TypeValuePair>())
	{
	}

	public DiContainer CreateSubContainer(List<TypeValuePair> args, InjectContext context)
	{
		DiContainer diContainer = _container.CreateSubContainer();
		SubContainerCreatorUtil.ApplyBindSettings(_containerBindInfo, diContainer);
		((InstallerBase)diContainer.InstantiateExplicit(_installerType, args.Concat(_extraArgs).ToList())).InstallBindings();
		diContainer.ResolveRoots();
		return diContainer;
	}
}
