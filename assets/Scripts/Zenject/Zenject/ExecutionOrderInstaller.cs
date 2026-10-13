using System;
using System.Collections.Generic;

namespace Zenject;

public class ExecutionOrderInstaller : Installer<List<Type>, ExecutionOrderInstaller>
{
	private List<Type> _typeOrder;

	public ExecutionOrderInstaller(List<Type> typeOrder)
	{
		_typeOrder = typeOrder;
	}

	public override void InstallBindings()
	{
		int num = -1 * _typeOrder.Count;
		foreach (Type item in _typeOrder)
		{
			base.Container.BindExecutionOrder(item, num);
			num++;
		}
	}
}
