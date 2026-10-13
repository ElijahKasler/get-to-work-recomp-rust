namespace Zenject;

public class ConcreteIdBinderNonGeneric : ConcreteBinderNonGeneric
{
	public ConcreteIdBinderNonGeneric(DiContainer bindContainer, BindInfo bindInfo, BindFinalizerWrapper finalizerWrapper)
		: base(bindContainer, bindInfo, finalizerWrapper)
	{
	}

	public ConcreteBinderNonGeneric WithId(object identifier)
	{
		base.BindInfo.Identifier = identifier;
		return this;
	}
}
