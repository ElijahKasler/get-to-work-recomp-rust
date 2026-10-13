using System;
using ModestTree;
using UnityEngine;

namespace Zenject;

public static class SubContainerCreatorUtil
{
	private class DefaultParentObjectDestroyer : IDisposable
	{
		private readonly GameObject _gameObject;

		public DefaultParentObjectDestroyer(GameObject gameObject)
		{
			_gameObject = gameObject;
		}

		public void Dispose()
		{
			UnityEngine.Object.Destroy(_gameObject);
		}
	}

	public static void ApplyBindSettings(SubContainerCreatorBindInfo subContainerBindInfo, DiContainer subContainer)
	{
		if (subContainerBindInfo.DefaultParentName != null)
		{
			GameObject gameObject = new GameObject(subContainerBindInfo.DefaultParentName);
			gameObject.transform.SetParent(subContainer.InheritedDefaultParent, worldPositionStays: false);
			subContainer.DefaultParent = gameObject.transform;
			subContainer.Bind<IDisposable>().To<DefaultParentObjectDestroyer>().AsCached()
				.WithArguments(gameObject);
			subContainer.BindDisposableExecutionOrder<DefaultParentObjectDestroyer>(int.MinValue);
		}
		if (subContainerBindInfo.CreateKernel)
		{
			DiContainer diContainer = subContainer.ParentContainers.OnlyOrDefault();
			Assert.IsNotNull(diContainer, "Could not find unique container when using WithKernel!");
			if (subContainerBindInfo.KernelType != null)
			{
				diContainer.Bind(typeof(Kernel).Interfaces()).To(subContainerBindInfo.KernelType).FromSubContainerResolve()
					.ByInstance(subContainer)
					.AsCached();
				subContainer.Bind(subContainerBindInfo.KernelType).AsCached();
			}
			else
			{
				diContainer.BindInterfacesTo<Kernel>().FromSubContainerResolve().ByInstance(subContainer)
					.AsCached();
				subContainer.Bind<Kernel>().AsCached();
			}
		}
	}
}
