using System;
using System.Collections.Generic;
using ModestTree;
using UnityEngine;

namespace Zenject;

public class EmptyGameObjectProvider : IProvider
{
	private readonly DiContainer _container;

	private readonly GameObjectCreationParameters _gameObjectBindInfo;

	public bool IsCached => false;

	public bool TypeVariesBasedOnMemberType => false;

	public EmptyGameObjectProvider(DiContainer container, GameObjectCreationParameters gameObjectBindInfo)
	{
		_gameObjectBindInfo = gameObjectBindInfo;
		_container = container;
	}

	public Type GetInstanceType(InjectContext context)
	{
		return typeof(GameObject);
	}

	public List<object> GetAllInstancesWithInjectSplit(InjectContext context, List<TypeValuePair> args, out Action injectAction)
	{
		Assert.IsEmpty(args);
		injectAction = null;
		return new List<object> { _container.CreateEmptyGameObject(_gameObjectBindInfo, context) };
	}
}
