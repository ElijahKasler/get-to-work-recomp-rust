namespace Zenject;

public class SignalTickPriorityCopyBinder : SignalCopyBinder
{
	protected SignalDeclarationBindInfo SignalBindInfo { get; private set; }

	public SignalTickPriorityCopyBinder(SignalDeclarationBindInfo signalBindInfo)
	{
		SignalBindInfo = signalBindInfo;
	}

	public SignalCopyBinder WithTickPriority(int priority)
	{
		SignalBindInfo.TickPriority = priority;
		SignalBindInfo.RunAsync = true;
		return this;
	}
}
