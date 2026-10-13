using System;
using System.Collections.Generic;
using System.Linq;
using ModestTree;

namespace Zenject;

public class CachedOpenTypeProvider : IProvider
{
	private readonly IProvider _creator;

	private readonly Dictionary<Type, CachedProvider> _providerMap = new Dictionary<Type, CachedProvider>();

	public bool IsCached => true;

	public bool TypeVariesBasedOnMemberType
	{
		get
		{
			throw Assert.CreateException();
		}
	}

	public int NumInstances => _providerMap.Values.Select((CachedProvider x) => x.NumInstances).Sum();

	public CachedOpenTypeProvider(IProvider creator)
	{
		Assert.That(creator.TypeVariesBasedOnMemberType);
		_creator = creator;
	}

	public void ClearCache()
	{
		_providerMap.Clear();
	}

	public Type GetInstanceType(InjectContext context)
	{
		return _creator.GetInstanceType(context);
	}

	public List<object> GetAllInstancesWithInjectSplit(InjectContext context, List<TypeValuePair> args, out Action injectAction)
	{
		Assert.IsNotNull(context);
		if (!_providerMap.TryGetValue(context.MemberType, out var value))
		{
			value = new CachedProvider(_creator);
			_providerMap.Add(context.MemberType, value);
		}
		return value.GetAllInstancesWithInjectSplit(context, args, out injectAction);
	}
}
