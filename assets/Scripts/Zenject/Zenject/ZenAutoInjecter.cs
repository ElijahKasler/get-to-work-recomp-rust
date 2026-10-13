using ModestTree;
using UnityEngine;

namespace Zenject;

public class ZenAutoInjecter : MonoBehaviour
{
	public enum ContainerSources
	{
		SceneContext = 0,
		ProjectContext = 1,
		SearchHierarchy = 2
	}

	[SerializeField]
	private ContainerSources _containerSource;

	private bool _hasInjected;

	public ContainerSources ContainerSource
	{
		get
		{
			return _containerSource;
		}
		set
		{
			_containerSource = value;
		}
	}

	[Inject]
	public void Construct()
	{
		if (!_hasInjected)
		{
			Object.DestroyImmediate(this);
		}
	}

	public void Awake()
	{
		_hasInjected = true;
		LookupContainer().InjectGameObject(base.gameObject);
	}

	private DiContainer LookupContainer()
	{
		if (_containerSource == ContainerSources.ProjectContext)
		{
			return ProjectContext.Instance.Container;
		}
		if (_containerSource == ContainerSources.SceneContext)
		{
			return GetContainerForCurrentScene();
		}
		Assert.IsEqual(_containerSource, ContainerSources.SearchHierarchy);
		Context componentInParent = base.transform.GetComponentInParent<Context>();
		if (componentInParent != null)
		{
			return componentInParent.Container;
		}
		return GetContainerForCurrentScene();
	}

	private DiContainer GetContainerForCurrentScene()
	{
		return ProjectContext.Instance.Container.Resolve<SceneContextRegistry>().GetContainerForScene(base.gameObject.scene);
	}
}
