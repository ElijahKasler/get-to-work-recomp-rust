using ModestTree;

namespace Zenject;

public class SignalBusInstaller : Installer<SignalBusInstaller>
{
	public override void InstallBindings()
	{
		Assert.That(!base.Container.HasBinding<SignalBus>(), "Detected multiple SignalBus bindings.  SignalBusInstaller should only be installed once");
		base.Container.BindInterfacesAndSelfTo<SignalBus>().AsSingle().CopyIntoAllSubContainers();
		base.Container.BindInterfacesTo<SignalDeclarationAsyncInitializer>().AsSingle().CopyIntoAllSubContainers();
		base.Container.BindMemoryPool<SignalSubscription, SignalSubscription.Pool>();
		base.Container.BindLateDisposableExecutionOrder<SignalBus>(-999);
	}
}
