using System.Collections.Generic;
using System.Linq;

namespace Zenject;

public class ArgConditionCopyNonLazyBinder : InstantiateCallbackConditionCopyNonLazyBinder
{
	public ArgConditionCopyNonLazyBinder(BindInfo bindInfo)
		: base(bindInfo)
	{
	}

	public InstantiateCallbackConditionCopyNonLazyBinder WithArguments<T>(T param)
	{
		base.BindInfo.Arguments = InjectUtil.CreateArgListExplicit(param);
		return this;
	}

	public InstantiateCallbackConditionCopyNonLazyBinder WithArguments<TParam1, TParam2>(TParam1 param1, TParam2 param2)
	{
		base.BindInfo.Arguments = InjectUtil.CreateArgListExplicit(param1, param2);
		return this;
	}

	public InstantiateCallbackConditionCopyNonLazyBinder WithArguments<TParam1, TParam2, TParam3>(TParam1 param1, TParam2 param2, TParam3 param3)
	{
		base.BindInfo.Arguments = InjectUtil.CreateArgListExplicit(param1, param2, param3);
		return this;
	}

	public InstantiateCallbackConditionCopyNonLazyBinder WithArguments<TParam1, TParam2, TParam3, TParam4>(TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4)
	{
		base.BindInfo.Arguments = InjectUtil.CreateArgListExplicit(param1, param2, param3, param4);
		return this;
	}

	public InstantiateCallbackConditionCopyNonLazyBinder WithArguments<TParam1, TParam2, TParam3, TParam4, TParam5>(TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4, TParam5 param5)
	{
		base.BindInfo.Arguments = InjectUtil.CreateArgListExplicit(param1, param2, param3, param4, param5);
		return this;
	}

	public InstantiateCallbackConditionCopyNonLazyBinder WithArguments<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6>(TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4, TParam5 param5, TParam6 param6)
	{
		base.BindInfo.Arguments = InjectUtil.CreateArgListExplicit(param1, param2, param3, param4, param5, param6);
		return this;
	}

	public InstantiateCallbackConditionCopyNonLazyBinder WithArguments(object[] args)
	{
		base.BindInfo.Arguments = InjectUtil.CreateArgList(args);
		return this;
	}

	public InstantiateCallbackConditionCopyNonLazyBinder WithArgumentsExplicit(IEnumerable<TypeValuePair> extraArgs)
	{
		base.BindInfo.Arguments = extraArgs.ToList();
		return this;
	}
}
