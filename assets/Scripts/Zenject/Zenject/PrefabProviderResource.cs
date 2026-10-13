using ModestTree;
using UnityEngine;

namespace Zenject;

public class PrefabProviderResource : IPrefabProvider
{
	private readonly string _resourcePath;

	public PrefabProviderResource(string resourcePath)
	{
		_resourcePath = resourcePath;
	}

	public Object GetPrefab()
	{
		GameObject obj = (GameObject)Resources.Load(_resourcePath);
		Assert.That(obj != null, "Expected to find prefab at resource path '{0}'", _resourcePath);
		return obj;
	}
}
