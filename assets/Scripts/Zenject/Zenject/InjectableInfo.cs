using System;

namespace Zenject;

public class InjectableInfo
{
	public readonly bool Optional;

	public readonly object Identifier;

	public readonly InjectSources SourceType;

	public readonly string MemberName;

	public readonly Type MemberType;

	public readonly Type ObjectType;

	public readonly Action<object, object> Setter;

	public readonly object DefaultValue;

	public InjectableInfo(bool optional, object identifier, string memberName, Type memberType, Type objectType, Action<object, object> setter, object defaultValue, InjectSources sourceType)
	{
		Optional = optional;
		Setter = setter;
		ObjectType = objectType;
		MemberType = memberType;
		MemberName = memberName;
		Identifier = identifier;
		DefaultValue = defaultValue;
		SourceType = sourceType;
	}

	public InjectContext SpawnInjectContext(DiContainer container, InjectContext currentContext, object targetInstance, object concreteIdentifier)
	{
		InjectContext injectContext = InjectContext.Pool.Spawn(container, MemberType);
		injectContext.ObjectType = ObjectType;
		injectContext.ParentContext = currentContext;
		injectContext.ObjectInstance = targetInstance;
		injectContext.Identifier = Identifier;
		injectContext.MemberName = MemberName;
		injectContext.Optional = Optional;
		injectContext.SourceType = SourceType;
		injectContext.FallBackValue = DefaultValue;
		injectContext.ConcreteIdentifier = concreteIdentifier;
		return injectContext;
	}
}
