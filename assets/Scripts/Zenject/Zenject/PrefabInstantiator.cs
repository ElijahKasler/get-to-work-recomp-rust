using System;
using System.Collections.Generic;
using System.Linq;
using ModestTree;
using UnityEngine;

namespace Zenject;

public class PrefabInstantiator : IPrefabInstantiator
{
	private readonly IPrefabProvider _prefabProvider;

	private readonly DiContainer _container;

	private readonly List<TypeValuePair> _extraArguments;

	private readonly GameObjectCreationParameters _gameObjectBindInfo;

	private readonly Type _argumentTarget;

	private readonly Action<InjectContext, object> _instantiateCallback;

	public GameObjectCreationParameters GameObjectCreationParameters => _gameObjectBindInfo;

	public Type ArgumentTarget => _argumentTarget;

	public List<TypeValuePair> ExtraArguments => _extraArguments;

	public PrefabInstantiator(DiContainer container, GameObjectCreationParameters gameObjectBindInfo, Type argumentTarget, List<TypeValuePair> extraArguments, IPrefabProvider prefabProvider, Action<InjectContext, object> instantiateCallback)
	{
		_prefabProvider = prefabProvider;
		_extraArguments = extraArguments;
		_container = container;
		_gameObjectBindInfo = gameObjectBindInfo;
		_argumentTarget = argumentTarget;
		_instantiateCallback = instantiateCallback;
	}

	public UnityEngine.Object GetPrefab()
	{
		return _prefabProvider.GetPrefab();
	}

	public GameObject Instantiate(List<TypeValuePair> args, out Action injectAction)
	{
		InjectContext context = new InjectContext(_container, _argumentTarget, null);
		GameObject gameObject = _container.CreateAndParentPrefab(GetPrefab(), _gameObjectBindInfo, context, out var shouldMakeActive);
		Assert.IsNotNull(gameObject);
		injectAction = () =>
		{
			List<TypeValuePair> list = _extraArguments.Concat(args).ToList();
			if (_argumentTarget == null)
			{
				Assert.That(list.IsEmpty(), "Unexpected arguments provided to prefab instantiator.  Arguments are not allowed if binding multiple components in the same binding");
			}
			Component component = null;
			if (_argumentTarget == null || list.IsEmpty())
			{
				_container.InjectGameObject(gameObject);
			}
			else
			{
				InjectArgs args2 = new InjectArgs
				{
					ExtraArgs = list,
					Context = context,
					ConcreteIdentifier = null
				};
				component = _container.InjectGameObjectForComponentExplicit(gameObject, _argumentTarget, args2);
			}
			if (shouldMakeActive)
			{
				gameObject.SetActive(value: true);
			}
			if (_instantiateCallback != null && _argumentTarget != null)
			{
				if (component == null)
				{
					component = gameObject.GetComponentInChildren(_argumentTarget);
				}
				if (component != null)
				{
					_instantiateCallback(context, component);
				}
			}
		};
		return gameObject;
	}
}
