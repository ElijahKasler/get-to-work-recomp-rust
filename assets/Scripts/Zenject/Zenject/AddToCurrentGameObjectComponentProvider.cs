using System;
using System.Collections.Generic;
using System.Linq;
using ModestTree;
using UnityEngine;

namespace Zenject;

public class AddToCurrentGameObjectComponentProvider : IProvider
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

	public AddToCurrentGameObjectComponentProvider(DiContainer container, Type componentType, List<TypeValuePair> extraArguments, object concreteIdentifier, Action<InjectContext, object> instantiateCallback)
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
		Assert.That(context.ObjectType.DerivesFrom<Component>(), "Object '{0}' can only be injected into MonoBehaviour's since it was bound with 'FromNewComponentSibling'. Attempted to inject into non-MonoBehaviour '{1}'", context.MemberType, context.ObjectType);
		object instance;
		if (!_container.IsValidating || TypeAnalyzer.ShouldAllowDuringValidation(_componentType))
		{
			GameObject gameObject = ((Component)context.ObjectInstance).gameObject;
			instance = gameObject.GetComponent(_componentType);
			if (instance != null)
			{
				injectAction = null;
				return new List<object> { instance };
			}
			instance = gameObject.AddComponent(_componentType);
		}
		else
		{
			instance = new ValidationMarker(_componentType);
		}
		InjectArgs injectArgs = new InjectArgs
		{
			ExtraArgs = _extraArguments.Concat(args).ToList(),
			Context = context,
			ConcreteIdentifier = _concreteIdentifier
		};
		injectAction = () =>
		{
			_container.InjectExplicit(instance, _componentType, injectArgs);
			Assert.That(injectArgs.ExtraArgs.IsEmpty());
			if (_instantiateCallback != null)
			{
				_instantiateCallback(context, instance);
			}
		};
		return new List<object> { instance };
	}
}
