namespace Zenject;

public class DeclareSignalAsyncTickPriorityCopyBinder : SignalTickPriorityCopyBinder
{
	public DeclareSignalAsyncTickPriorityCopyBinder(SignalDeclarationBindInfo signalBindInfo)
		: base(signalBindInfo)
	{
	}

	public SignalTickPriorityCopyBinder RunAsync()
	{
		base.SignalBindInfo.RunAsync = true;
		return this;
	}

	public SignalCopyBinder RunSync()
	{
		base.SignalBindInfo.RunAsync = false;
		return this;
	}
}
