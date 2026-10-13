using System;
using System.Collections.Generic;
using ModestTree;

namespace Zenject;

public class SubContainerCreatorByMethod : SubContainerCreatorByMethodBase
{
	private readonly Action<DiContainer> _installMethod;

	public SubContainerCreatorByMethod(DiContainer container, SubContainerCreatorBindInfo containerBindInfo, Action<DiContainer> installMethod)
		: base(container, containerBindInfo)
	{
		_installMethod = installMethod;
	}

	public override DiContainer CreateSubContainer(List<TypeValuePair> args, InjectContext context)
	{
		Assert.IsEmpty(args);
		DiContainer diContainer = CreateEmptySubContainer();
		_installMethod(diContainer);
		diContainer.ResolveRoots();
		return diContainer;
	}
}
public class SubContainerCreatorByMethod<TParam1> : SubContainerCreatorByMethodBase
{
	private readonly Action<DiContainer, TParam1> _installMethod;

	public SubContainerCreatorByMethod(DiContainer container, SubContainerCreatorBindInfo containerBindInfo, Action<DiContainer, TParam1> installMethod)
		: base(container, containerBindInfo)
	{
		_installMethod = installMethod;
	}

	public override DiContainer CreateSubContainer(List<TypeValuePair> args, InjectContext context)
	{
		Assert.IsEqual(args.Count, 1);
		Assert.That(args[0].Type.DerivesFromOrEqual<TParam1>());
		DiContainer diContainer = CreateEmptySubContainer();
		_installMethod(diContainer, (TParam1)args[0].Value);
		diContainer.ResolveRoots();
		return diContainer;
	}
}
public class SubContainerCreatorByMethod<TParam1, TParam2> : SubContainerCreatorByMethodBase
{
	private readonly Action<DiContainer, TParam1, TParam2> _installMethod;

	public SubContainerCreatorByMethod(DiContainer container, SubContainerCreatorBindInfo containerBindInfo, Action<DiContainer, TParam1, TParam2> installMethod)
		: base(container, containerBindInfo)
	{
		_installMethod = installMethod;
	}

	public override DiContainer CreateSubContainer(List<TypeValuePair> args, InjectContext context)
	{
		Assert.IsEqual(args.Count, 2);
		Assert.That(args[0].Type.DerivesFromOrEqual<TParam1>());
		Assert.That(args[1].Type.DerivesFromOrEqual<TParam2>());
		DiContainer diContainer = CreateEmptySubContainer();
		_installMethod(diContainer, (TParam1)args[0].Value, (TParam2)args[1].Value);
		diContainer.ResolveRoots();
		return diContainer;
	}
}
public class SubContainerCreatorByMethod<TParam1, TParam2, TParam3> : SubContainerCreatorByMethodBase
{
	private readonly Action<DiContainer, TParam1, TParam2, TParam3> _installMethod;

	public SubContainerCreatorByMethod(DiContainer container, SubContainerCreatorBindInfo containerBindInfo, Action<DiContainer, TParam1, TParam2, TParam3> installMethod)
		: base(container, containerBindInfo)
	{
		_installMethod = installMethod;
	}

	public override DiContainer CreateSubContainer(List<TypeValuePair> args, InjectContext context)
	{
		Assert.IsEqual(args.Count, 3);
		Assert.That(args[0].Type.DerivesFromOrEqual<TParam1>());
		Assert.That(args[1].Type.DerivesFromOrEqual<TParam2>());
		Assert.That(args[2].Type.DerivesFromOrEqual<TParam3>());
		DiContainer diContainer = CreateEmptySubContainer();
		_installMethod(diContainer, (TParam1)args[0].Value, (TParam2)args[1].Value, (TParam3)args[2].Value);
		diContainer.ResolveRoots();
		return diContainer;
	}
}
public class SubContainerCreatorByMethod<TParam1, TParam2, TParam3, TParam4> : SubContainerCreatorByMethodBase
{
	private readonly Action<DiContainer, TParam1, TParam2, TParam3, TParam4> _installMethod;

	public SubContainerCreatorByMethod(DiContainer container, SubContainerCreatorBindInfo containerBindInfo, Action<DiContainer, TParam1, TParam2, TParam3, TParam4> installMethod)
		: base(container, containerBindInfo)
	{
		_installMethod = installMethod;
	}

	public override DiContainer CreateSubContainer(List<TypeValuePair> args, InjectContext context)
	{
		Assert.IsEqual(args.Count, 4);
		Assert.That(args[0].Type.DerivesFromOrEqual<TParam1>());
		Assert.That(args[1].Type.DerivesFromOrEqual<TParam2>());
		Assert.That(args[2].Type.DerivesFromOrEqual<TParam3>());
		Assert.That(args[3].Type.DerivesFromOrEqual<TParam4>());
		DiContainer diContainer = CreateEmptySubContainer();
		_installMethod(diContainer, (TParam1)args[0].Value, (TParam2)args[1].Value, (TParam3)args[2].Value, (TParam4)args[3].Value);
		diContainer.ResolveRoots();
		return diContainer;
	}
}
public class SubContainerCreatorByMethod<TParam1, TParam2, TParam3, TParam4, TParam5> : SubContainerCreatorByMethodBase
{
	private readonly Action<DiContainer, TParam1, TParam2, TParam3, TParam4, TParam5> _installMethod;

	public SubContainerCreatorByMethod(DiContainer container, SubContainerCreatorBindInfo containerBindInfo, Action<DiContainer, TParam1, TParam2, TParam3, TParam4, TParam5> installMethod)
		: base(container, containerBindInfo)
	{
		_installMethod = installMethod;
	}

	public override DiContainer CreateSubContainer(List<TypeValuePair> args, InjectContext context)
	{
		Assert.IsEqual(args.Count, 5);
		Assert.That(args[0].Type.DerivesFromOrEqual<TParam1>());
		Assert.That(args[1].Type.DerivesFromOrEqual<TParam2>());
		Assert.That(args[2].Type.DerivesFromOrEqual<TParam3>());
		Assert.That(args[3].Type.DerivesFromOrEqual<TParam4>());
		Assert.That(args[4].Type.DerivesFromOrEqual<TParam5>());
		DiContainer diContainer = CreateEmptySubContainer();
		_installMethod(diContainer, (TParam1)args[0].Value, (TParam2)args[1].Value, (TParam3)args[2].Value, (TParam4)args[3].Value, (TParam5)args[4].Value);
		diContainer.ResolveRoots();
		return diContainer;
	}
}
public class SubContainerCreatorByMethod<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6> : SubContainerCreatorByMethodBase
{
	private readonly Action<DiContainer, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6> _installMethod;

	public SubContainerCreatorByMethod(DiContainer container, SubContainerCreatorBindInfo containerBindInfo, Action<DiContainer, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6> installMethod)
		: base(container, containerBindInfo)
	{
		_installMethod = installMethod;
	}

	public override DiContainer CreateSubContainer(List<TypeValuePair> args, InjectContext context)
	{
		Assert.IsEqual(args.Count, 5);
		Assert.That(args[0].Type.DerivesFromOrEqual<TParam1>());
		Assert.That(args[1].Type.DerivesFromOrEqual<TParam2>());
		Assert.That(args[2].Type.DerivesFromOrEqual<TParam3>());
		Assert.That(args[3].Type.DerivesFromOrEqual<TParam4>());
		Assert.That(args[4].Type.DerivesFromOrEqual<TParam5>());
		Assert.That(args[5].Type.DerivesFromOrEqual<TParam6>());
		DiContainer diContainer = CreateEmptySubContainer();
		_installMethod(diContainer, (TParam1)args[0].Value, (TParam2)args[1].Value, (TParam3)args[2].Value, (TParam4)args[3].Value, (TParam5)args[4].Value, (TParam6)args[5].Value);
		diContainer.ResolveRoots();
		return diContainer;
	}
}
public class SubContainerCreatorByMethod<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10> : SubContainerCreatorByMethodBase
{
	private readonly Action<DiContainer, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10> _installMethod;

	public SubContainerCreatorByMethod(DiContainer container, SubContainerCreatorBindInfo containerBindInfo, Action<DiContainer, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10> installMethod)
		: base(container, containerBindInfo)
	{
		_installMethod = installMethod;
	}

	public override DiContainer CreateSubContainer(List<TypeValuePair> args, InjectContext context)
	{
		Assert.IsEqual(args.Count, 10);
		Assert.That(args[0].Type.DerivesFromOrEqual<TParam1>());
		Assert.That(args[1].Type.DerivesFromOrEqual<TParam2>());
		Assert.That(args[2].Type.DerivesFromOrEqual<TParam3>());
		Assert.That(args[3].Type.DerivesFromOrEqual<TParam4>());
		Assert.That(args[4].Type.DerivesFromOrEqual<TParam5>());
		Assert.That(args[5].Type.DerivesFromOrEqual<TParam6>());
		Assert.That(args[6].Type.DerivesFromOrEqual<TParam7>());
		Assert.That(args[7].Type.DerivesFromOrEqual<TParam8>());
		Assert.That(args[8].Type.DerivesFromOrEqual<TParam9>());
		Assert.That(args[9].Type.DerivesFromOrEqual<TParam10>());
		DiContainer diContainer = CreateEmptySubContainer();
		_installMethod(diContainer, (TParam1)args[0].Value, (TParam2)args[1].Value, (TParam3)args[2].Value, (TParam4)args[3].Value, (TParam5)args[4].Value, (TParam6)args[5].Value, (TParam7)args[6].Value, (TParam8)args[7].Value, (TParam9)args[8].Value, (TParam10)args[9].Value);
		diContainer.ResolveRoots();
		return diContainer;
	}
}
