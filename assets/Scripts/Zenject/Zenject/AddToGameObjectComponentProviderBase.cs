using System;
using System.Collections.Generic;
using System.Linq;
using ModestTree;
using UnityEngine;

namespace Zenject;

public abstract class AddToGameObjectComponentProviderBase : IProvider
{
	private readonly Type _componentType;

	private readonly DiContainer _container;

	private readonly List<TypeValuePair> _extraArguments;

	private readonly object _concreteIdentifier;

	private readonly Action<InjectContext, object> _instantiateCallback;

	public bool IsCached => false;

	public bool TypeVariesBasedOnMemberType => false;

	protected DiContainer Container => _container;

	protected Type ComponentType => _componentType;

	protected abstract bool ShouldToggleActive { get; }

	public AddToGameObjectComponentProviderBase(DiContainer container, Type componentType, List<TypeValuePair> extraArguments, object concreteIdentifier, Action<InjectContext, object> instantiateCallback)
	{
		Assert.That(componentType.DerivesFrom<Component>());
		_extraArguments = extraArguments;
		_componentType = componentType;
		_container = container;
		_concreteIdentifier = concreteIdentifier;
		_instantiateCallback = instantiateCallback;
	}

	public Type GetInstanceType(InjectContext context)
	{
		return _componentType;
	}

	public List<object> GetAllInstancesWithInjectSplit(InjectContext context, List<TypeValuePair> args, out Action injectAction)
	{
		Assert.IsNotNull(context);
		GameObject gameObj = GetGameObject(context);
		bool wasActive = gameObj.activeSelf;
		if (wasActive && ShouldToggleActive)
		{
			gameObj.SetActive(value: false);
		}
		object instance;
		if (!_container.IsValidating || TypeAnalyzer.ShouldAllowDuringValidation(_componentType))
		{
			if (_componentType == typeof(Transform))
			{
				instance = gameObj.transform;
			}
			else
			{
				instance = gameObj.AddComponent(_componentType);
			}
			Assert.IsNotNull(instance);
		}
		else
		{
			instance = new ValidationMarker(_componentType);
		}
		injectAction = () =>
		{
			try
			{
				InjectArgs args2 = new InjectArgs
				{
					ExtraArgs = _extraArguments.Concat(args).ToList(),
					Context = context,
					ConcreteIdentifier = _concreteIdentifier
				};
				_container.InjectExplicit(instance, _componentType, args2);
				if (_instantiateCallback != null)
				{
					_instantiateCallback(context, instance);
				}
			}
			finally
			{
				if (wasActive && ShouldToggleActive)
				{
					gameObj.SetActive(value: true);
				}
			}
		};
		return new List<object> { instance };
	}

	protected abstract GameObject GetGameObject(InjectContext context);
}
