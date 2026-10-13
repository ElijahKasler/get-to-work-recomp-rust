using System;
using System.Collections.Generic;
using System.Linq;
using ModestTree;

namespace Zenject;

public abstract class ProviderBindingFinalizer : IBindingFinalizer
{
	public BindingInheritanceMethods BindingInheritanceMethod => BindInfo.BindingInheritanceMethod;

	protected BindInfo BindInfo { get; private set; }

	public ProviderBindingFinalizer(BindInfo bindInfo)
	{
		BindInfo = bindInfo;
	}

	protected ScopeTypes GetScope()
	{
		if (BindInfo.Scope == ScopeTypes.Unset)
		{
			Assert.That(!BindInfo.RequireExplicitScope || BindInfo.Condition != null, "Scope must be set for the previous binding!  Please either specify AsTransient, AsCached, or AsSingle. Last binding: Contract: {0}, Identifier: {1} {2}", BindInfo.ContractTypes.Select((Type x) => x.ToString()).Join(", "), BindInfo.Identifier, (BindInfo.ContextInfo != null) ? "Context: '{0}'".Fmt(BindInfo.ContextInfo) : "");
			return ScopeTypes.Transient;
		}
		return BindInfo.Scope;
	}

	public void FinalizeBinding(DiContainer container)
	{
		if (BindInfo.ContractTypes.Count == 0)
		{
			return;
		}
		try
		{
			OnFinalizeBinding(container);
		}
		catch (Exception innerException)
		{
			throw Assert.CreateException(innerException, "Error while finalizing previous binding! Contract: {0}, Identifier: {1} {2}", BindInfo.ContractTypes.Select((Type x) => x.ToString()).Join(", "), BindInfo.Identifier, (BindInfo.ContextInfo != null) ? "Context: '{0}'".Fmt(BindInfo.ContextInfo) : "");
		}
	}

	protected abstract void OnFinalizeBinding(DiContainer container);

	protected void RegisterProvider<TContract>(DiContainer container, IProvider provider)
	{
		RegisterProvider(container, typeof(TContract), provider);
	}

	protected void RegisterProvider(DiContainer container, Type contractType, IProvider provider)
	{
		if (!BindInfo.OnlyBindIfNotBound || !container.HasBindingId(contractType, BindInfo.Identifier))
		{
			container.RegisterProvider(new BindingId(contractType, BindInfo.Identifier), BindInfo.Condition, provider, BindInfo.NonLazy);
			if (contractType.IsValueType() && (!contractType.IsGenericType() || !(contractType.GetGenericTypeDefinition() == typeof(Nullable<>))))
			{
				Type type = typeof(Nullable<>).MakeGenericType(contractType);
				container.RegisterProvider(new BindingId(type, BindInfo.Identifier), BindInfo.Condition, provider, BindInfo.NonLazy);
			}
		}
	}

	protected void RegisterProviderPerContract(DiContainer container, Func<DiContainer, Type, IProvider> providerFunc)
	{
		foreach (Type contractType in BindInfo.ContractTypes)
		{
			IProvider provider = providerFunc(container, contractType);
			if (BindInfo.MarkAsUniqueSingleton)
			{
				container.SingletonMarkRegistry.MarkSingleton(contractType);
			}
			else if (BindInfo.MarkAsCreationBinding)
			{
				container.SingletonMarkRegistry.MarkNonSingleton(contractType);
			}
			RegisterProvider(container, contractType, provider);
		}
	}

	protected void RegisterProviderForAllContracts(DiContainer container, IProvider provider)
	{
		foreach (Type contractType in BindInfo.ContractTypes)
		{
			if (BindInfo.MarkAsUniqueSingleton)
			{
				container.SingletonMarkRegistry.MarkSingleton(contractType);
			}
			else if (BindInfo.MarkAsCreationBinding)
			{
				container.SingletonMarkRegistry.MarkNonSingleton(contractType);
			}
			RegisterProvider(container, contractType, provider);
		}
	}

	protected void RegisterProvidersPerContractAndConcreteType(DiContainer container, List<Type> concreteTypes, Func<Type, Type, IProvider> providerFunc)
	{
		Assert.That(!BindInfo.ContractTypes.IsEmpty());
		Assert.That(!concreteTypes.IsEmpty());
		foreach (Type contractType in BindInfo.ContractTypes)
		{
			foreach (Type concreteType in concreteTypes)
			{
				if (ValidateBindTypes(concreteType, contractType))
				{
					RegisterProvider(container, contractType, providerFunc(contractType, concreteType));
				}
			}
		}
	}

	private bool ValidateBindTypes(Type concreteType, Type contractType)
	{
		bool flag = concreteType.IsOpenGenericType();
		bool flag2 = contractType.IsOpenGenericType();
		if (flag != flag2)
		{
			return false;
		}
		if (flag2)
		{
			Assert.That(flag);
			if (TypeExtensions.IsAssignableToGenericType(concreteType, contractType))
			{
				return true;
			}
		}
		else if (concreteType.DerivesFromOrEqual(contractType))
		{
			return true;
		}
		if (BindInfo.InvalidBindResponse == InvalidBindResponses.Assert)
		{
			throw Assert.CreateException("Expected type '{0}' to derive from or be equal to '{1}'", concreteType, contractType);
		}
		Assert.IsEqual(BindInfo.InvalidBindResponse, InvalidBindResponses.Skip);
		return false;
	}

	protected void RegisterProvidersForAllContractsPerConcreteType(DiContainer container, List<Type> concreteTypes, Func<DiContainer, Type, IProvider> providerFunc)
	{
		Assert.That(!BindInfo.ContractTypes.IsEmpty());
		Assert.That(!concreteTypes.IsEmpty());
		Dictionary<Type, IProvider> dictionary = DictionaryPool<Type, IProvider>.Instance.Spawn();
		try
		{
			foreach (Type concreteType in concreteTypes)
			{
				IProvider value = providerFunc(container, concreteType);
				dictionary[concreteType] = value;
				if (BindInfo.MarkAsUniqueSingleton)
				{
					container.SingletonMarkRegistry.MarkSingleton(concreteType);
				}
				else if (BindInfo.MarkAsCreationBinding)
				{
					container.SingletonMarkRegistry.MarkNonSingleton(concreteType);
				}
			}
			foreach (Type contractType in BindInfo.ContractTypes)
			{
				foreach (Type concreteType2 in concreteTypes)
				{
					if (ValidateBindTypes(concreteType2, contractType))
					{
						RegisterProvider(container, contractType, dictionary[concreteType2]);
					}
				}
			}
		}
		finally
		{
			DictionaryPool<Type, IProvider>.Instance.Despawn(dictionary);
		}
	}
}
