using System;
using System.Collections.Generic;
using ModestTree;
using UnityEngine;
using Zenject.Internal;

namespace Zenject;

public class ProjectContext : Context
{
	public const string ProjectContextResourcePath = "ProjectContext";

	public const string ProjectContextResourcePathOld = "ProjectCompositionRoot";

	private static ProjectContext _instance;

	[Tooltip("When true, objects that are created at runtime will be parented to the ProjectContext")]
	[SerializeField]
	private bool _parentNewObjectsUnderContext = true;

	[SerializeField]
	private ZenjectSettings _settings;

	private DiContainer _container;

	public override DiContainer Container => _container;

	public static bool HasInstance => _instance != null;

	public static ProjectContext Instance
	{
		get
		{
			if (_instance == null)
			{
				InstantiateAndInitialize();
				Assert.IsNotNull(_instance);
			}
			return _instance;
		}
	}

	public bool ParentNewObjectsUnderContext
	{
		get
		{
			return _parentNewObjectsUnderContext;
		}
		set
		{
			_parentNewObjectsUnderContext = value;
		}
	}

	public event Action PreInstall;

	public event Action PostInstall;

	public event Action PreResolve;

	public event Action PostResolve;

	public override IEnumerable<GameObject> GetRootGameObjects()
	{
		return new GameObject[1] { base.gameObject };
	}

	public static GameObject TryGetPrefab()
	{
		GameObject gameObject = (GameObject)Resources.Load("ProjectContext");
		if (gameObject == null)
		{
			gameObject = (GameObject)Resources.Load("ProjectCompositionRoot");
		}
		return gameObject;
	}

	private static void InstantiateAndInitialize()
	{
		Assert.That(UnityEngine.Object.FindObjectsOfType<ProjectContext>().IsEmpty(), "Tried to create multiple instances of ProjectContext!");
		GameObject gameObject = TryGetPrefab();
		bool flag = false;
		if (gameObject == null)
		{
			_instance = new GameObject("ProjectContext").AddComponent<ProjectContext>();
		}
		else
		{
			flag = gameObject.activeSelf;
			GameObject gameObject2;
			if (flag)
			{
				gameObject.SetActive(value: false);
				gameObject2 = UnityEngine.Object.Instantiate(gameObject);
				gameObject.SetActive(value: true);
			}
			else
			{
				gameObject2 = UnityEngine.Object.Instantiate(gameObject);
			}
			_instance = gameObject2.GetComponent<ProjectContext>();
			Assert.IsNotNull(_instance, "Could not find ProjectContext component on prefab 'Resources/{0}.prefab'", "ProjectContext");
		}
		_instance.Initialize();
		if (flag)
		{
			_instance.gameObject.SetActive(value: true);
		}
	}

	public void EnsureIsInitialized()
	{
	}

	public void Awake()
	{
		if (Application.isPlaying)
		{
			UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
		}
	}

	private void Initialize()
	{
		Assert.IsNull(_container);
		bool isValidating = false;
		_container = new DiContainer(new DiContainer[1] { StaticContext.Container }, isValidating);
		if (PreInstall != null)
		{
			PreInstall();
		}
		List<MonoBehaviour> list = new List<MonoBehaviour>();
		GetInjectableMonoBehaviours(list);
		foreach (MonoBehaviour item in list)
		{
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
	}

	protected override void GetInjectableMonoBehaviours(List<MonoBehaviour> monoBehaviours)
	{
		ZenUtilInternal.AddStateMachineBehaviourAutoInjectersUnderGameObject(base.gameObject);
		ZenUtilInternal.GetInjectableMonoBehavioursUnderGameObject(base.gameObject, monoBehaviours);
	}

	private void InstallBindings(List<MonoBehaviour> injectableMonoBehaviours)
	{
		if (_parentNewObjectsUnderContext)
		{
			_container.DefaultParent = base.transform;
		}
		else
		{
			_container.DefaultParent = null;
		}
		_container.Settings = _settings ?? ZenjectSettings.Default;
		_container.Bind<ZenjectSceneLoader>().AsSingle();
		Installer<ZenjectManagersInstaller>.Install(_container);
		_container.Bind<Context>().FromInstance(this);
		_container.Bind(typeof(ProjectKernel), typeof(MonoKernel)).To<ProjectKernel>().FromNewComponentOn(base.gameObject)
			.AsSingle()
			.NonLazy();
		_container.Bind<SceneContextRegistry>().AsSingle();
		InstallSceneBindings(injectableMonoBehaviours);
		InstallInstallers();
	}
}
