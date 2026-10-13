using System;
using System.Collections.Generic;
using ModestTree;

namespace Zenject;

public class MethodProviderUntyped : IProvider
{
	private readonly DiContainer _container;

	private readonly Func<InjectContext, object> _method;

	public bool IsCached => false;

	public bool TypeVariesBasedOnMemberType => false;

	public MethodProviderUntyped(Func<InjectContext, object> method, DiContainer container)
	{
		_container = container;
		_method = method;
	}

	public Type GetInstanceType(InjectContext context)
	{
		return context.MemberType;
	}

	public List<object> GetAllInstancesWithInjectSplit(InjectContext context, List<TypeValuePair> args, out Action injectAction)
	{
		Assert.IsEmpty(args);
		Assert.IsNotNull(context);
		injectAction = null;
		if (_container.IsValidating && !TypeAnalyzer.ShouldAllowDuringValidation(context.MemberType))
		{
			return new List<object>
			{
				new ValidationMarker(context.MemberType)
			};
		}
		object obj = _method(context);
		if (obj == null)
		{
			Assert.That(!context.MemberType.IsPrimitive(), "Invalid value returned from FromMethod.  Expected non-null.");
		}
		else
		{
			Assert.That(obj.GetType().DerivesFromOrEqual(context.MemberType));
		}
		return new List<object> { obj };
	}
}
