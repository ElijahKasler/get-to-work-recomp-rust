using System;
using System.Collections.Generic;
using System.Linq;
using ModestTree;

namespace Zenject;

public class ConcreteBinderNonGeneric : FromBinderNonGeneric
{
	public ConcreteBinderNonGeneric(DiContainer bindContainer, BindInfo bindInfo, BindFinalizerWrapper finalizerWrapper)
		: base(bindContainer, bindInfo, finalizerWrapper)
	{
		ToSelf();
	}

	public FromBinderNonGeneric ToSelf()
	{
		Assert.IsEqual(base.BindInfo.ToChoice, ToChoices.Self);
		base.BindInfo.RequireExplicitScope = true;
		base.SubFinalizer = new ScopableBindingFinalizer(base.BindInfo, (DiContainer container, Type type) => new TransientProvider(type, container, base.BindInfo.Arguments, base.BindInfo.ContextInfo, base.BindInfo.ConcreteIdentifier, base.BindInfo.InstantiatedCallback));
		return this;
	}

	public FromBinderNonGeneric To<TConcrete>()
	{
		return To(typeof(TConcrete));
	}

	public FromBinderNonGeneric To(params Type[] concreteTypes)
	{
		return To((IEnumerable<Type>)concreteTypes);
	}

	public FromBinderNonGeneric To(IEnumerable<Type> concreteTypes)
	{
		base.BindInfo.ToChoice = ToChoices.Concrete;
		base.BindInfo.ToTypes = concreteTypes.ToList();
		if (base.BindInfo.ToTypes.Count > 1 && base.BindInfo.ContractTypes.Count > 1)
		{
			base.BindInfo.InvalidBindResponse = InvalidBindResponses.Skip;
		}
		else
		{
			BindingUtil.AssertIsDerivedFromTypes(concreteTypes, base.BindInfo.ContractTypes, base.BindInfo.InvalidBindResponse);
		}
		return this;
	}

	public FromBinderNonGeneric To(Action<ConventionSelectTypesBinder> generator)
	{
		ConventionBindInfo conventionBindInfo = new ConventionBindInfo();
		base.BindInfo.InvalidBindResponse = InvalidBindResponses.Skip;
		generator(new ConventionSelectTypesBinder(conventionBindInfo));
		base.BindInfo.ToChoice = ToChoices.Concrete;
		base.BindInfo.ToTypes = conventionBindInfo.ResolveTypes();
		return this;
	}
}
