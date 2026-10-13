namespace System.ServiceProcess;

internal abstract class ServiceControllerImpl
{
	private readonly ServiceController _serviceController;

	protected ServiceController ServiceController => _serviceController;

	public abstract bool CanPauseAndContinue { get; }

	public abstract bool CanShutdown { get; }

	public abstract bool CanStop { get; }

	public abstract ServiceController[] DependentServices { get; }

	public abstract string DisplayName { get; }

	public abstract string ServiceName { get; }

	public abstract ServiceController[] ServicesDependedOn { get; }

	public abstract ServiceType ServiceType { get; }

	public abstract ServiceControllerStatus Status { get; }

	protected ServiceControllerImpl(ServiceController serviceController)
	{
		_serviceController = serviceController;
	}

	public abstract void Close();

	public abstract void Continue();

	public abstract void Dispose(bool disposing);

	public abstract void ExecuteCommand(int command);

	public abstract ServiceController[] GetDevices();

	public abstract ServiceController[] GetServices();

	public abstract void Pause();

	public abstract void Refresh();

	public abstract void Start(string[] args);

	public abstract void Stop();
}
