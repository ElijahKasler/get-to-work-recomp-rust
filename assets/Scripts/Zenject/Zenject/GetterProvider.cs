using System;
using System.Collections.Generic;
using System.Linq;
using ModestTree;

namespace Zenject;

public class GetterProvider<TObj, TResult> : IProvider
{
	private readonly DiContainer _container;

	private readonly object _identifier;

	private readonly Func<TObj, TResult> _method;

	private readonly bool _matchAll;

	private readonly InjectSources _sourceType;

	public bool IsCached => false;

	public bool TypeVariesBasedOnMemberType => false;

	public GetterProvider(object identifier, Func<TObj, TResult> method, DiContainer container, InjectSources sourceType, bool matchAll)
	{
		_container = container;
		_identifier = identifier;
		_method = method;
		_matchAll = matchAll;
		_sourceType = sourceType;
	}

	public Type GetInstanceType(InjectContext context)
	{
		return typeof(TResult);
	}

	private InjectContext GetSubContext(InjectContext parent)
	{
		InjectContext injectContext = parent.CreateSubContext(typeof(TObj), _identifier);
		injectContext.Optional = false;
		injectContext.SourceType = _sourceType;
		return injectContext;
	}

	public List<object> GetAllInstancesWithInjectSplit(InjectContext context, List<TypeValuePair> args, out Action injectAction)
	{
		Assert.IsEmpty(args);
		Assert.IsNotNull(context);
		Assert.That(typeof(TResult).DerivesFromOrEqual(context.MemberType));
		injectAction = null;
		if (_container.IsValidating)
		{
			if (_matchAll)
			{
				_container.ResolveAll(GetSubContext(context));
			}
			else
			{
				_container.Resolve(GetSubContext(context));
			}
			return new List<object>
			{
				new ValidationMarker(typeof(TResult))
			};
		}
		if (_matchAll)
		{
			return (from TObj x in _container.ResolveAll(GetSubContext(context))
				select _method(x)).Cast<object>().ToList();
		}
		return new List<object> { _method((TObj)_container.Resolve(GetSubContext(context))) };
	}
}
