using System.Linq;
using ModestTree;
using UnityEngine;
using Zenject.Internal;

namespace Zenject;

public class ProjectKernel : MonoKernel
{
	[Inject]
	private ZenjectSettings _settings;

	public void OnApplicationQuit()
	{
		if (_settings.EnsureDeterministicDestructionOrderOnApplicationQuit)
		{
			DestroyEverythingInOrder();
		}
	}

	public void DestroyEverythingInOrder()
	{
		ForceUnloadAllScenes(immediate: true);
		Assert.That(!base.IsDestroyed);
		Object.DestroyImmediate(base.gameObject);
		Assert.That(base.IsDestroyed);
	}

	public void ForceUnloadAllScenes(bool immediate = false)
	{
		Assert.That(!base.IsDestroyed);
		foreach (SceneContext item in ZenUtilInternal.GetAllSceneContexts().Reverse().ToList())
		{
			if (immediate)
			{
				Object.DestroyImmediate(item.gameObject);
			}
			else
			{
				Object.Destroy(item.gameObject);
			}
		}
	}
}
