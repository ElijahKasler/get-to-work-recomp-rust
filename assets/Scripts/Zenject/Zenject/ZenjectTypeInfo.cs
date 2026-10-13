using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Zenject;

public class ZenjectTypeInfo
{
	private readonly List<PostInjectableInfo> _postInjectMethods;

	private readonly List<InjectableInfo> _constructorInjectables;

	private readonly List<InjectableInfo> _fieldInjectables;

	private readonly List<InjectableInfo> _propertyInjectables;

	private readonly ConstructorInfo _injectConstructor;

	private readonly Type _typeAnalyzed;

	public Type Type => _typeAnalyzed;

	public IEnumerable<PostInjectableInfo> PostInjectMethods => _postInjectMethods;

	public IEnumerable<InjectableInfo> AllInjectables => _constructorInjectables.Concat(_fieldInjectables).Concat(_propertyInjectables).Concat(_postInjectMethods.SelectMany((PostInjectableInfo x) => x.InjectableInfo));

	public IEnumerable<InjectableInfo> FieldInjectables => _fieldInjectables;

	public IEnumerable<InjectableInfo> PropertyInjectables => _propertyInjectables;

	public IEnumerable<InjectableInfo> ConstructorInjectables => _constructorInjectables;

	public ConstructorInfo InjectConstructor => _injectConstructor;

	public ZenjectTypeInfo(Type typeAnalyzed, List<PostInjectableInfo> postInjectMethods, ConstructorInfo injectConstructor, List<InjectableInfo> fieldInjectables, List<InjectableInfo> propertyInjectables, List<InjectableInfo> constructorInjectables)
	{
		_postInjectMethods = postInjectMethods;
		_fieldInjectables = fieldInjectables;
		_propertyInjectables = propertyInjectables;
		_constructorInjectables = constructorInjectables;
		_injectConstructor = injectConstructor;
		_typeAnalyzed = typeAnalyzed;
	}
}
