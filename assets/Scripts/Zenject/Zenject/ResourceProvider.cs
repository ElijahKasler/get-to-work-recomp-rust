using System;
using System.Collections.Generic;
using System.Linq;
using ModestTree;
using UnityEngine;

namespace Zenject;

public class ResourceProvider : IProvider
{
	private readonly Type _resourceType;

	private readonly string _resourcePath;

	private readonly bool _matchSingle;

	public bool IsCached => false;

	public bool TypeVariesBasedOnMemberType => false;

	public ResourceProvider(string resourcePath, Type resourceType, bool matchSingle)
	{
		_resourceType = resourceType;
		_resourcePath = resourcePath;
		_matchSingle = matchSingle;
	}

	public Type GetInstanceType(InjectContext context)
	{
		return _resourceType;
	}

	public List<object> GetAllInstancesWithInjectSplit(InjectContext context, List<TypeValuePair> args, out Action injectAction)
	{
		Assert.IsEmpty(args);
		Assert.IsNotNull(context);
		if (_matchSingle)
		{
			UnityEngine.Object obj = Resources.Load(_resourcePath, _resourceType);
			Assert.That(obj != null, "Could not find resource at path '{0}' with type '{1}'", _resourcePath, _resourceType);
			injectAction = null;
			return new List<object> { obj };
		}
		List<object> list = Resources.LoadAll(_resourcePath, _resourceType).Cast<object>().ToList();
		Assert.That(!list.IsEmpty(), "Could not find resource at path '{0}' with type '{1}'", _resourcePath, _resourceType);
		injectAction = null;
		return list;
	}
}
