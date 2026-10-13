using System;
using System.Collections.Generic;
using System.Linq;
using ModestTree;
using UnityEngine;
using UnityEngine.Serialization;

namespace Zenject;

public abstract class Context : MonoBehaviour
{
	[FormerlySerializedAs("Installers")]
	[SerializeField]
	private List<MonoInstaller> _installers = new List<MonoInstaller>();

	[SerializeField]
	private List<MonoInstaller> _installerPrefabs = new List<MonoInstaller>();

	[SerializeField]
	private List<ScriptableObjectInstaller> _scriptableObjectInstallers = new List<ScriptableObjectInstaller>();

	private List<InstallerBase> _normalInstallers = new List<InstallerBase>();

	private List<Type> _normalInstallerTypes = new List<Type>();

	public IEnumerable<MonoInstaller> Installers
	{
		get
		{
			return _installers;
		}
		set
		{
			_installers.Clear();
			_installers.AddRange(value);
		}
	}

	public IEnumerable<MonoInstaller> InstallerPrefabs
	{
		get
		{
			return _installerPrefabs;
		}
		set
		{
			_installerPrefabs.Clear();
			_installerPrefabs.AddRange(value);
		}
	}

	public IEnumerable<ScriptableObjectInstaller> ScriptableObjectInstallers
	{
		get
		{
			return _scriptableObjectInstallers;
		}
		set
		{
			_scriptableObjectInstallers.Clear();
			_scriptableObjectInstallers.AddRange(value);
		}
	}

	public IEnumerable<Type> NormalInstallerTypes
	{
		get
		{
			return _normalInstallerTypes;
		}
		set
		{
			Assert.That(value.All((Type x) => x != null && x.DerivesFrom<InstallerBase>()));
			_normalInstallerTypes.Clear();
			_normalInstallerTypes.AddRange(value);
		}
	}

	public IEnumerable<InstallerBase> NormalInstallers
	{
		get
		{
			return _normalInstallers;
		}
		set
		{
			_normalInstallers.Clear();
			_normalInstallers.AddRange(value);
		}
	}

	public abstract DiContainer Container { get; }

	public abstract IEnumerable<GameObject> GetRootGameObjects();

	public void AddNormalInstallerType(Type installerType)
	{
		Assert.IsNotNull(installerType);
		Assert.That(installerType.DerivesFrom<InstallerBase>());
		_normalInstallerTypes.Add(installerType);
	}

	public void AddNormalInstaller(InstallerBase installer)
	{
		_normalInstallers.Add(installer);
	}

	private void CheckInstallerPrefabTypes(List<MonoInstaller> installers, List<MonoInstaller> installerPrefabs)
	{
		foreach (MonoInstaller installer in installers)
		{
			Assert.IsNotNull(installer, "Found null installer in Context '{0}'", base.name);
		}
		foreach (MonoInstaller installerPrefab in installerPrefabs)
		{
			Assert.IsNotNull(installerPrefab, "Found null prefab in Context");
			Assert.That(installerPrefab.GetComponent<MonoInstaller>() != null, "Expected to find component with type 'MonoInstaller' on given installer prefab '{0}'", installerPrefab.name);
		}
	}

	protected void InstallInstallers()
	{
		InstallInstallers(_normalInstallers, _normalInstallerTypes, _scriptableObjectInstallers, _installers, _installerPrefabs);
	}

	protected void InstallInstallers(List<InstallerBase> normalInstallers, List<Type> normalInstallerTypes, List<ScriptableObjectInstaller> scriptableObjectInstallers, List<MonoInstaller> installers, List<MonoInstaller> installerPrefabs)
	{
		CheckInstallerPrefabTypes(installers, installerPrefabs);
		List<IInstaller> list = normalInstallers.Cast<IInstaller>().Concat(scriptableObjectInstallers.Cast<IInstaller>()).Concat(installers.Cast<IInstaller>())
			.ToList();
		foreach (MonoInstaller installerPrefab in installerPrefabs)
		{
			Assert.IsNotNull(installerPrefab, "Found null installer prefab in '{0}'", GetType());
			GameObject obj = UnityEngine.Object.Instantiate(installerPrefab.gameObject);
			obj.transform.SetParent(base.transform, worldPositionStays: false);
			MonoInstaller component = obj.GetComponent<MonoInstaller>();
			Assert.IsNotNull(component, "Could not find installer component on prefab '{0}'", installerPrefab.name);
			list.Add(component);
		}
		foreach (Type normalInstallerType in normalInstallerTypes)
		{
			((InstallerBase)Container.Instantiate(normalInstallerType)).InstallBindings();
		}
		foreach (IInstaller item in list)
		{
			Assert.IsNotNull(item, "Found null installer in '{0}'", GetType());
			Container.Inject(item);
			item.InstallBindings();
		}
	}

	protected void InstallSceneBindings(List<MonoBehaviour> injectableMonoBehaviours)
	{
		foreach (ZenjectBinding item in injectableMonoBehaviours.OfType<ZenjectBinding>())
		{
			if (!(item == null) && (item.Context == null || (item.UseSceneContext && this is SceneContext)))
			{
				item.Context = this;
			}
		}
		ZenjectBinding[] array = Resources.FindObjectsOfTypeAll<ZenjectBinding>();
		foreach (ZenjectBinding zenjectBinding in array)
		{
			if (!(zenjectBinding == null))
			{
				if (this is SceneContext && zenjectBinding.Context == null && zenjectBinding.UseSceneContext && zenjectBinding.gameObject.scene == base.gameObject.scene)
				{
					zenjectBinding.Context = this;
				}
				if (zenjectBinding.Context == this)
				{
					InstallZenjectBinding(zenjectBinding);
				}
			}
		}
	}

	private void InstallZenjectBinding(ZenjectBinding binding)
	{
		if (!binding.enabled)
		{
			return;
		}
		if (binding.Components == null || binding.Components.IsEmpty())
		{
			Log.Warn("Found empty list of components on ZenjectBinding on object '{0}'", binding.name);
			return;
		}
		string identifier = null;
		if (binding.Identifier.Trim().Length > 0)
		{
			identifier = binding.Identifier;
		}
		Component[] components = binding.Components;
		foreach (Component component in components)
		{
			ZenjectBinding.BindTypes bindType = binding.BindType;
			if (component == null)
			{
				Log.Warn("Found null component in ZenjectBinding on object '{0}'", binding.name);
				continue;
			}
			Type type = component.GetType();
			switch (bindType)
			{
			case ZenjectBinding.BindTypes.Self:
				Container.Bind(type).WithId(identifier).FromInstance(component);
				break;
			case ZenjectBinding.BindTypes.BaseType:
				Container.Bind(type.BaseType()).WithId(identifier).FromInstance(component);
				break;
			case ZenjectBinding.BindTypes.AllInterfaces:
				Container.Bind(type.Interfaces()).WithId(identifier).FromInstance(component);
				break;
			case ZenjectBinding.BindTypes.AllInterfacesAndSelf:
				Container.Bind(type.Interfaces().Concat(new Type[1] { type }).ToArray()).WithId(identifier).FromInstance(component);
				break;
			default:
				throw Assert.CreateException();
			}
		}
	}

	protected abstract void GetInjectableMonoBehaviours(List<MonoBehaviour> components);
}
