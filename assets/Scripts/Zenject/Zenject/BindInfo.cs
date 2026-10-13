using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Zenject;

public class BindInfo
{
	public bool MarkAsCreationBinding;

	public bool MarkAsUniqueSingleton;

	public object ConcreteIdentifier;

	public bool SaveProvider;

	public bool OnlyBindIfNotBound;

	public bool RequireExplicitScope;

	public object Identifier;

	public List<Type> ContractTypes;

	public BindingInheritanceMethods BindingInheritanceMethod;

	public InvalidBindResponses InvalidBindResponse;

	public bool NonLazy;

	public BindingCondition Condition;

	public ToChoices ToChoice;

	public List<Type> ToTypes;

	public ScopeTypes Scope;

	public List<TypeValuePair> Arguments;

	public Action<InjectContext, object> InstantiatedCallback;

	public string ContextInfo { get; private set; }

	public BindInfo()
	{
		ContextInfo = null;
		Identifier = null;
		ConcreteIdentifier = null;
		ContractTypes = new List<Type>();
		ToTypes = new List<Type>();
		Arguments = new List<TypeValuePair>();
		ToChoice = ToChoices.Self;
		BindingInheritanceMethod = BindingInheritanceMethods.None;
		OnlyBindIfNotBound = false;
		SaveProvider = false;
		NonLazy = false;
		MarkAsUniqueSingleton = false;
		MarkAsCreationBinding = true;
		Scope = ScopeTypes.Unset;
		InvalidBindResponse = InvalidBindResponses.Assert;
	}

	[Conditional("UNITY_EDITOR")]
	public void SetContextInfo(string contextInfo)
	{
		ContextInfo = contextInfo;
	}
}
