using System;
using System.Collections.Generic;
using ModestTree;

namespace Zenject;

public class InstanceProvider : IProvider
{
	private readonly object _instance;

	private readonly Type _instanceType;

	private readonly DiContainer _container;

	public bool IsCached => true;

	public bool TypeVariesBasedOnMemberType => false;

	public InstanceProvider(Type instanceType, object instance, DiContainer container)
	{
		_instanceType = instanceType;
		_instance = instance;
		_container = container;
	}

	public Type GetInstanceType(InjectContext context)
	{
		return _instanceType;
	}

	public List<object> GetAllInstancesWithInjectSplit(InjectContext context, List<TypeValuePair> args, out Action injectAction)
	{
		Assert.IsEmpty(args);
		Assert.IsNotNull(context);
		Assert.That(_instanceType.DerivesFromOrEqual(context.MemberType));
		injectAction = () =>
		{
			_container.LazyInject(_instance);
		};
		return new List<object> { _instance };
	}
}
