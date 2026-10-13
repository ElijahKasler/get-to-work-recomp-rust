namespace Zenject;

public class ConcreteIdBinderGeneric<TContract> : ConcreteBinderGeneric<TContract>
{
	public ConcreteIdBinderGeneric(DiContainer bindContainer, BindInfo bindInfo, BindFinalizerWrapper finalizerWrapper)
		: base(bindContainer, bindInfo, finalizerWrapper)
	{
	}

	public ConcreteBinderGeneric<TContract> WithId(object identifier)
	{
		base.BindInfo.Identifier = identifier;
		return this;
	}
}
