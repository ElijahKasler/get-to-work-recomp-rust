namespace Zenject;

public class DeclareSignalRequireHandlerAsyncTickPriorityCopyBinder : DeclareSignalAsyncTickPriorityCopyBinder
{
	public DeclareSignalRequireHandlerAsyncTickPriorityCopyBinder(SignalDeclarationBindInfo signalBindInfo)
		: base(signalBindInfo)
	{
	}

	public DeclareSignalAsyncTickPriorityCopyBinder RequireSubscriber()
	{
		base.SignalBindInfo.MissingHandlerResponse = SignalMissingHandlerResponses.Throw;
		return this;
	}

	public DeclareSignalAsyncTickPriorityCopyBinder OptionalSubscriber()
	{
		base.SignalBindInfo.MissingHandlerResponse = SignalMissingHandlerResponses.Ignore;
		return this;
	}

	public DeclareSignalAsyncTickPriorityCopyBinder OptionalSubscriberWithWarning()
	{
		base.SignalBindInfo.MissingHandlerResponse = SignalMissingHandlerResponses.Warn;
		return this;
	}
}
