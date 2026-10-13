using System;
using System.Collections.Generic;
using ModestTree;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject.Internal;

namespace Zenject;

public class GameObjectContext : RunnableContext
{
	[SerializeField]
	[Tooltip("Note that this field is optional and can be ignored in most cases.  This is really only needed if you want to control the 'Script Execution Order' of your subcontainer.  In this case, define a new class that derives from MonoKernel, add it to this game object, then drag it into this field.  Then you can set a value for 'Script Execution Order' for this new class and this will control when all ITickable/IInitializable classes bound within this subcontainer get called.")]
	[FormerlySerializedAs("_facade")]
	private MonoKernel _kernel;

	private DiContainer _container;

	public override DiContainer Container => _container;

	public event Action PreInstall;

	public event Action PostInstall;

	public event Action PreResolve;

	public event Action PostResolve;

	public override IEnumerable<GameObject> GetRootGameObjects()
	{
		return new GameObject[1] { base.gameObject };
	}

	[Inject]
	public void Construct(DiContainer parentContainer)
	{
		Assert.IsNull(_container);
		_container = parentContainer.CreateSubContainer();
		Initialize();
	}

	protected override void RunInternal()
	{
		if (PreInstall != null)
		{
			PreInstall();
		}
		List<MonoBehaviour> list = new List<MonoBehaviour>();
		GetInjectableMonoBehaviours(list);
		foreach (MonoBehaviour item in list)
		{
			if (item is MonoKernel)
			{
				Assert.That((object)item == _kernel, "Found MonoKernel derived class that is not hooked up to GameObjectContext.  If you use MonoKernel, you must indicate this to GameObjectContext by dragging and dropping it to the Kernel field in the inspector");
			}
			_container.QueueForInject(item);
		}
		_container.IsInstalling = true;
		try
		{
			InstallBindings(list);
		}
		finally
		{
			_container.IsInstalling = false;
		}
		if (PostInstall != null)
		{
			PostInstall();
		}
		if (PreResolve != null)
		{
			PreResolve();
		}
		_container.ResolveRoots();
		if (PostResolve != null)
		{
			PostResolve();
		}
		if (base.gameObject.scene.isLoaded && !_container.IsValidating)
		{
			_kernel = _container.Resolve<MonoKernel>();
			_kernel.Initialize();
		}
	}

	protected override void GetInjectableMonoBehaviours(List<MonoBehaviour> monoBehaviours)
	{
		ZenUtilInternal.AddStateMachineBehaviourAutoInjectersUnderGameObject(base.gameObject);
		MonoBehaviour[] components = GetComponents<MonoBehaviour>();
		foreach (MonoBehaviour monoBehaviour in components)
		{
			if (!(monoBehaviour == null) && ZenUtilInternal.IsInjectableMonoBehaviourType(monoBehaviour.GetType()) && !(monoBehaviour == this))
			{
				monoBehaviours.Add(monoBehaviour);
			}
		}
		for (int j = 0; j < base.transform.childCount; j++)
		{
			Transform child = base.transform.GetChild(j);
			if (child != null)
			{
				ZenUtilInternal.GetInjectableMonoBehavioursUnderGameObject(child.gameObject, monoBehaviours);
			}
		}
	}

	private void InstallBindings(List<MonoBehaviour> injectableMonoBehaviours)
	{
		_container.DefaultParent = base.transform;
		_container.Bind<Context>().FromInstance(this);
		_container.Bind<GameObjectContext>().FromInstance(this);
		if (_kernel == null)
		{
			_container.Bind<MonoKernel>().To<DefaultGameObjectKernel>().FromNewComponentOn(base.gameObject)
				.AsSingle()
				.NonLazy();
		}
		else
		{
			_container.Bind<MonoKernel>().FromInstance(_kernel).AsSingle()
				.NonLazy();
		}
		InstallSceneBindings(injectableMonoBehaviours);
		InstallInstallers();
	}
}
