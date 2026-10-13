using System;
using System.Diagnostics;
using UnityEngine;

namespace Zenject;

[DebuggerStepThrough]
public class MonoInstallerBase : MonoBehaviour, IInstaller
{
	[Inject]
	private DiContainer _container;

	protected DiContainer Container => _container;

	public virtual bool IsEnabled => base.enabled;

	public virtual void Start()
	{
	}

	public virtual void InstallBindings()
	{
		throw new NotImplementedException();
	}
}
