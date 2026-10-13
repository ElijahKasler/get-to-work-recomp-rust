using System;
using System.Collections.Generic;
using UnityEngine;

namespace Zenject;

public class PrefabGameObjectProvider : IProvider
{
	private readonly IPrefabInstantiator _prefabCreator;

	public bool IsCached => false;

	public bool TypeVariesBasedOnMemberType => false;

	public PrefabGameObjectProvider(IPrefabInstantiator prefabCreator)
	{
		_prefabCreator = prefabCreator;
	}

	public Type GetInstanceType(InjectContext context)
	{
		return typeof(GameObject);
	}

	public List<object> GetAllInstancesWithInjectSplit(InjectContext context, List<TypeValuePair> args, out Action injectAction)
	{
		GameObject item = _prefabCreator.Instantiate(args, out injectAction);
		return new List<object> { item };
	}
}
