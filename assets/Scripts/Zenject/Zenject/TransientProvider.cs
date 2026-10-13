using System;
using System.Collections.Generic;
using System.Linq;
using ModestTree;

namespace Zenject;

public class TransientProvider : IProvider
{
	private readonly DiContainer _container;

	private readonly Type _concreteType;

	private readonly List<TypeValuePair> _extraArguments;

	private readonly object _concreteIdentifier;

	private readonly Action<InjectContext, object> _instantiateCallback;

	public bool IsCached => false;

	public bool TypeVariesBasedOnMemberType => _concreteType.IsOpenGenericType();

	public TransientProvider(Type concreteType, DiContainer container, List<TypeValuePair> extraArguments, string bindingContext, object concreteIdentifier, Action<InjectContext, object> instantiateCallback)
	{
		Assert.That(!concreteType.IsAbstract(), "Expected non-abstract type for given binding but instead found type '{0}'{1}", concreteType, (bindingContext == null) ? "" : " when binding '{0}'".Fmt(bindingContext));
		_container = container;
		_concreteType = concreteType;
		_extraArguments = extraArguments ?? new List<TypeValuePair>();
		_concreteIdentifier = concreteIdentifier;
		_instantiateCallback = instantiateCallback;
	}

	public Type GetInstanceType(InjectContext context)
	{
		if (!_concreteType.DerivesFromOrEqual(context.MemberType))
		{
			return null;
		}
		return GetTypeToCreate(context.MemberType);
	}

	public List<object> GetAllInstancesWithInjectSplit(InjectContext context, List<TypeValuePair> args, out Action injectAction)
	{
		Assert.IsNotNull(context);
		Type instanceType = GetTypeToCreate(context.MemberType);
		InjectArgs injectArgs = new InjectArgs
		{
			ExtraArgs = _extraArguments.Concat(args).ToList(),
			Context = context,
			ConcreteIdentifier = _concreteIdentifier
		};
		object instance = _container.InstantiateExplicit(instanceType, autoInject: false, injectArgs);
		injectAction = () =>
		{
			_container.InjectExplicit(instance, instanceType, injectArgs);
			if (_instantiateCallback != null)
			{
				_instantiateCallback(context, instance);
			}
		};
		return new List<object> { instance };
	}

	private Type GetTypeToCreate(Type contractType)
	{
		return ProviderUtil.GetTypeToInstantiate(contractType, _concreteType);
	}
}
