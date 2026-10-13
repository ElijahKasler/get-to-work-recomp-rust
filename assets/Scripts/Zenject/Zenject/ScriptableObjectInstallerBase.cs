using System;
using UnityEngine;

namespace Zenject;

public class ScriptableObjectInstallerBase : ScriptableObject, IInstaller
{
	[Inject]
	private DiContainer _container;

	protected DiContainer Container => _container;

	bool IInstaller.IsEnabled => true;

	public virtual void InstallBindings()
	{
		throw new NotImplementedException();
	}
}
