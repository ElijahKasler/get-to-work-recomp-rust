using System;
using System.Collections.Generic;
using ModestTree;

namespace Zenject;

public class CachedProvider : IProvider
{
	private readonly IProvider _creator;

	private List<object> _instances;

	private bool _isCreatingInstance;

	public bool IsCached => true;

	public bool TypeVariesBasedOnMemberType
	{
		get
		{
			throw Assert.CreateException();
		}
	}

	public int NumInstances
	{
		get
		{
			if (_instances != null)
			{
				return _instances.Count;
			}
			return 0;
		}
	}

	public CachedProvider(IProvider creator)
	{
		_creator = creator;
	}

	public void ClearCache()
	{
		_instances = null;
	}

	public Type GetInstanceType(InjectContext context)
	{
		return _creator.GetInstanceType(context);
	}

	public List<object> GetAllInstancesWithInjectSplit(InjectContext context, List<TypeValuePair> args, out Action injectAction)
	{
		Assert.IsNotNull(context);
		if (_instances != null)
		{
			injectAction = null;
			return _instances;
		}
		if (_isCreatingInstance)
		{
			Type instanceType = _creator.GetInstanceType(context);
			throw Assert.CreateException("Found circular dependency when creating type '{0}'. Object graph:\n {1}{2}\n", instanceType, context.GetObjectGraphString(), instanceType.PrettyName());
		}
		_isCreatingInstance = true;
		_instances = _creator.GetAllInstancesWithInjectSplit(context, args, out injectAction);
		Assert.IsNotNull(_instances);
		_isCreatingInstance = false;
		return _instances;
	}
}
