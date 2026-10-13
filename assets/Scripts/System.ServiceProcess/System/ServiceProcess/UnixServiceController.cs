namespace System.ServiceProcess;

internal class UnixServiceController : ServiceControllerImpl
{
	public override bool CanPauseAndContinue
	{
		get
		{
			throw new NotImplementedException();
		}
	}

	public override bool CanShutdown
	{
		get
		{
			throw new NotImplementedException();
		}
	}

	public override bool CanStop
	{
		get
		{
			throw new NotImplementedException();
		}
	}

	public override ServiceController[] DependentServices
	{
		get
		{
			throw new NotImplementedException();
		}
	}

	public override string DisplayName
	{
		get
		{
			throw new NotImplementedException();
		}
	}

	public override string ServiceName
	{
		get
		{
			throw new NotImplementedException();
		}
	}

	public override ServiceController[] ServicesDependedOn
	{
		get
		{
			throw new NotImplementedException();
		}
	}

	public override ServiceType ServiceType
	{
		get
		{
			throw new NotImplementedException();
		}
	}

	public override ServiceControllerStatus Status
	{
		get
		{
			throw new NotImplementedException();
		}
	}

	public UnixServiceController(ServiceController serviceController)
		: base(serviceController)
	{
	}

	public override void Close()
	{
		throw new NotImplementedException();
	}

	public override void Continue()
	{
		throw new NotImplementedException();
	}

	public override void Dispose(bool disposing)
	{
	}

	public override void ExecuteCommand(int command)
	{
		throw new NotImplementedException();
	}

	public override ServiceController[] GetDevices()
	{
		throw new NotImplementedException();
	}

	public override ServiceController[] GetServices()
	{
		throw new NotImplementedException();
	}

	public override void Pause()
	{
		throw new NotImplementedException();
	}

	public override void Refresh()
	{
		throw new NotImplementedException();
	}

	public override void Start(string[] args)
	{
		throw new NotImplementedException();
	}

	public override void Stop()
	{
		throw new NotImplementedException();
	}
}
