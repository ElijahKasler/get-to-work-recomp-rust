using System;
using System.Collections.Generic;
using System.Linq;
using ModestTree;

namespace Zenject;

public class MethodMultipleProviderUntyped : IProvider
{
	private readonly DiContainer _container;

	private readonly Func<InjectContext, IEnumerable<object>> _method;

	public bool IsCached => false;

	public bool TypeVariesBasedOnMemberType => false;

	public MethodMultipleProviderUntyped(Func<InjectContext, IEnumerable<object>> method, DiContainer container)
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
		IEnumerable<object> enumerable = _method(context);
		if (enumerable == null)
		{
			throw Assert.CreateException("Method '{0}' returned null when list was expected. Object graph:\n {1}", _method.ToDebugString(), context.GetObjectGraphString());
		}
		return enumerable.ToList();
	}
}
