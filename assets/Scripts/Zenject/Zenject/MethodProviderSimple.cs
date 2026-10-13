using System;
using System.Collections.Generic;
using ModestTree;

namespace Zenject;

public class MethodProviderSimple<TReturn> : IProvider
{
	private readonly Func<TReturn> _method;

	public bool IsCached => false;

	public bool TypeVariesBasedOnMemberType => false;

	public MethodProviderSimple(Func<TReturn> method)
	{
		_method = method;
	}

	public Type GetInstanceType(InjectContext context)
	{
		return typeof(TReturn);
	}

	public List<object> GetAllInstancesWithInjectSplit(InjectContext context, List<TypeValuePair> args, out Action injectAction)
	{
		Assert.IsEmpty(args);
		Assert.IsNotNull(context);
		Assert.That(typeof(TReturn).DerivesFromOrEqual(context.MemberType));
		injectAction = null;
		return new List<object> { _method() };
	}
}
