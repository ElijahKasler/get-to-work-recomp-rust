using System;
using System.Collections.Generic;
using System.Linq;
using ModestTree;
using UnityEngine;

namespace Zenject;

public class ScriptableObjectResourceProvider : IProvider
{
	private readonly DiContainer _container;

	private readonly Type _resourceType;

	private readonly string _resourcePath;

	private readonly List<TypeValuePair> _extraArguments;

	private readonly bool _createNew;

	private readonly object _concreteIdentifier;

	private readonly Action<InjectContext, object> _instantiateCallback;

	public bool IsCached => false;

	public bool TypeVariesBasedOnMemberType => false;

	public ScriptableObjectResourceProvider(string resourcePath, Type resourceType, DiContainer container, List<TypeValuePair> extraArguments, bool createNew, object concreteIdentifier, Action<InjectContext, object> instantiateCallback)
	{
		_container = container;
		Assert.DerivesFromOrEqual<ScriptableObject>(resourceType);
		_extraArguments = extraArguments;
		_resourceType = resourceType;
		_resourcePath = resourcePath;
		_createNew = createNew;
		_concreteIdentifier = concreteIdentifier;
		_instantiateCallback = instantiateCallback;
	}

	public Type GetInstanceType(InjectContext context)
	{
		return _resourceType;
	}

	public List<object> GetAllInstancesWithInjectSplit(InjectContext context, List<TypeValuePair> args, out Action injectAction)
	{
		Assert.IsNotNull(context);
		List<object> objects;
		if (_createNew)
		{
			objects = (from x in Resources.LoadAll(_resourcePath, _resourceType)
				select UnityEngine.Object.Instantiate(x)).Cast<object>().ToList();
		}
		else
		{
			objects = Resources.LoadAll(_resourcePath, _resourceType).Cast<object>().ToList();
		}
		Assert.That(!objects.IsEmpty(), "Could not find resource at path '{0}' with type '{1}'", _resourcePath, _resourceType);
		InjectArgs injectArgs = new InjectArgs
		{
			ExtraArgs = _extraArguments.Concat(args).ToList(),
			Context = context,
			ConcreteIdentifier = _concreteIdentifier
		};
		injectAction = () =>
		{
			foreach (object item in objects)
			{
				_container.InjectExplicit(item, _resourceType, injectArgs);
				if (_instantiateCallback != null)
				{
					_instantiateCallback(context, item);
				}
			}
		};
		return objects;
	}
}
