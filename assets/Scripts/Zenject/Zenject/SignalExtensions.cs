namespace Zenject;

public static class SignalExtensions
{
	public static DeclareSignalRequireHandlerAsyncTickPriorityCopyBinder DeclareSignal<TSignal>(this DiContainer container)
	{
		SignalDeclarationBindInfo signalDeclarationBindInfo = new SignalDeclarationBindInfo(typeof(TSignal));
		signalDeclarationBindInfo.RunAsync = container.Settings.Signals.DefaultSyncMode == SignalDefaultSyncModes.Asynchronous;
		signalDeclarationBindInfo.MissingHandlerResponse = container.Settings.Signals.MissingHandlerDefaultResponse;
		signalDeclarationBindInfo.TickPriority = container.Settings.Signals.DefaultAsyncTickPriority;
		BindInfo bindInfo = container.Bind<SignalDeclaration>().AsCached().WithArguments(typeof(TSignal), signalDeclarationBindInfo)
			.WhenInjectedInto(typeof(SignalBus), typeof(SignalDeclarationAsyncInitializer))
			.BindInfo;
		DeclareSignalRequireHandlerAsyncTickPriorityCopyBinder declareSignalRequireHandlerAsyncTickPriorityCopyBinder = new DeclareSignalRequireHandlerAsyncTickPriorityCopyBinder(signalDeclarationBindInfo);
		declareSignalRequireHandlerAsyncTickPriorityCopyBinder.AddCopyBindInfo(bindInfo);
		return declareSignalRequireHandlerAsyncTickPriorityCopyBinder;
	}

	public static BindSignalToBinder<TSignal> BindSignal<TSignal>(this DiContainer container)
	{
		return new BindSignalToBinder<TSignal>(container);
	}
}
