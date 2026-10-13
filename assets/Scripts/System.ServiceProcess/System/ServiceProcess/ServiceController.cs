using System.ComponentModel;
using System.Globalization;
using System.Runtime.InteropServices;
using System.ServiceProcess.Design;
using System.Threading;
using Unity;

namespace System.ServiceProcess;

[Designer("System.ServiceProcess.Design.ServiceControllerDesigner, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
[System.MonoTODO("No unix implementation")]
[ServiceProcessDescription("Provides the ability to connect to, query, and manipulate running or stopped Windows services.")]
public class ServiceController : Component
{
	private string _name;

	private string _serviceName = string.Empty;

	private string _machineName;

	private string _displayName = string.Empty;

	private readonly ServiceControllerImpl _impl;

	private ServiceController[] _dependentServices;

	private ServiceController[] _servicesDependedOn;

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[ServiceProcessDescription("Whether this service recognizes the Pause and Continue commands.")]
	public bool CanPauseAndContinue
	{
		get
		{
			ValidateServiceName(ServiceName);
			return _impl.CanPauseAndContinue;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[ServiceProcessDescription("Whether this service can respond to a system shutdown.")]
	public bool CanShutdown
	{
		get
		{
			ValidateServiceName(ServiceName);
			return _impl.CanShutdown;
		}
	}

	[ServiceProcessDescription("Whether this service can be stopped.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public bool CanStop
	{
		get
		{
			ValidateServiceName(ServiceName);
			return _impl.CanStop;
		}
	}

	[ServiceProcessDescription("The services that depend on this service in order to run.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public ServiceController[] DependentServices
	{
		get
		{
			ValidateServiceName(ServiceName);
			if (_dependentServices == null)
			{
				_dependentServices = _impl.DependentServices;
			}
			return _dependentServices;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[ReadOnly(true)]
	[ServiceProcessDescription("The descriptive name of the service.")]
	public string DisplayName
	{
		get
		{
			if (_displayName.Length == 0 && (_serviceName.Length > 0 || _name.Length > 0))
			{
				_displayName = _impl.DisplayName;
			}
			return _displayName;
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			if (!(_displayName == value))
			{
				_displayName = value;
				_serviceName = string.Empty;
				Close();
			}
		}
	}

	[ServiceProcessDescription("The name of the machine on which this service resides.")]
	[RecommendedAsConfigurable(true)]
	[DefaultValue(".")]
	[Browsable(false)]
	public string MachineName
	{
		get
		{
			return _machineName;
		}
		set
		{
			ValidateMachineName(value);
			if (!(_machineName == value))
			{
				_machineName = value;
				Close();
			}
		}
	}

	[RecommendedAsConfigurable(true)]
	[DefaultValue("")]
	[TypeConverter(typeof(ServiceNameConverter))]
	[ReadOnly(true)]
	[ServiceProcessDescription("The short name of the service.")]
	public string ServiceName
	{
		get
		{
			if (_serviceName.Length == 0 && (_displayName.Length > 0 || _name.Length > 0))
			{
				_serviceName = _impl.ServiceName;
			}
			return _serviceName;
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			if (!(_serviceName == value))
			{
				ValidateServiceName(value);
				_serviceName = value;
				_displayName = string.Empty;
				Close();
			}
		}
	}

	[ServiceProcessDescription("Services that must be started in order for this one to start.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public ServiceController[] ServicesDependedOn
	{
		get
		{
			ValidateServiceName(ServiceName);
			if (_servicesDependedOn == null)
			{
				_servicesDependedOn = _impl.ServicesDependedOn;
			}
			return _servicesDependedOn;
		}
	}

	[System.MonoTODO]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public SafeHandle ServiceHandle
	{
		get
		{
			throw new NotImplementedException();
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[ServiceProcessDescription("The type of this service.")]
	public ServiceType ServiceType
	{
		get
		{
			ValidateServiceName(ServiceName);
			return _impl.ServiceType;
		}
	}

	[ServiceProcessDescription("The status of the service, e.g., Running or Stopped.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public ServiceControllerStatus Status
	{
		get
		{
			ValidateServiceName(ServiceName);
			return _impl.Status;
		}
	}

	internal string Name
	{
		get
		{
			return _name;
		}
		set
		{
			_name = value;
		}
	}

	internal string InternalDisplayName
	{
		get
		{
			return _displayName;
		}
		set
		{
			_displayName = value;
		}
	}

	internal string InternalServiceName
	{
		get
		{
			return _serviceName;
		}
		set
		{
			_serviceName = value;
		}
	}

	public ServiceStartMode StartType
	{
		get
		{
			Unity.ThrowStub.ThrowNotSupportedException();
			return default;
		}
	}

	public ServiceController()
	{
		_machineName = ".";
		_name = string.Empty;
		_impl = CreateServiceControllerImpl(this);
	}

	public ServiceController(string name)
		: this(name, ".")
	{
	}

	public ServiceController(string name, string machineName)
	{
		if (name == null || name.Length == 0)
		{
			throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid value {0} for parameter name.", name));
		}
		ValidateMachineName(machineName);
		_machineName = machineName;
		_name = name;
		_impl = CreateServiceControllerImpl(this);
	}

	public void Close()
	{
		_impl.Close();
	}

	public void Continue()
	{
		ValidateServiceName(ServiceName);
		_impl.Continue();
	}

	protected override void Dispose(bool disposing)
	{
		_impl.Dispose(disposing);
		base.Dispose(disposing);
	}

	public void ExecuteCommand(int command)
	{
		ValidateServiceName(ServiceName);
		_impl.ExecuteCommand(command);
	}

	public static ServiceController[] GetDevices()
	{
		return GetDevices(".");
	}

	public static ServiceController[] GetDevices(string machineName)
	{
		ValidateMachineName(machineName);
		using ServiceController serviceController = new ServiceController("dummy", machineName);
		return CreateServiceControllerImpl(serviceController).GetDevices();
	}

	public static ServiceController[] GetServices()
	{
		return GetServices(".");
	}

	public static ServiceController[] GetServices(string machineName)
	{
		ValidateMachineName(machineName);
		using ServiceController serviceController = new ServiceController("dummy", machineName);
		return CreateServiceControllerImpl(serviceController).GetServices();
	}

	public void Pause()
	{
		ValidateServiceName(ServiceName);
		_impl.Pause();
	}

	public void Refresh()
	{
		_dependentServices = null;
		_servicesDependedOn = null;
		_impl.Refresh();
	}

	public void Start()
	{
		Start(new string[0]);
	}

	public void Start(string[] args)
	{
		ValidateServiceName(ServiceName);
		_impl.Start(args);
	}

	public void Stop()
	{
		ValidateServiceName(ServiceName);
		_impl.Stop();
	}

	public void WaitForStatus(ServiceControllerStatus desiredStatus)
	{
		WaitForStatus(desiredStatus, TimeSpan.MaxValue);
	}

	public void WaitForStatus(ServiceControllerStatus desiredStatus, TimeSpan timeout)
	{
		ValidateServiceName(ServiceName);
		DateTime now = DateTime.Now;
		while (Status != desiredStatus)
		{
			if (timeout < DateTime.Now - now)
			{
				throw new TimeoutException("Time out has expired and the operation has not been completed.");
			}
			Thread.Sleep(100);
			Refresh();
		}
	}

	private static void ValidateServiceName(string serviceName)
	{
		if (serviceName.Length == 0 || serviceName.Length > 80)
		{
			throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Service name {0} contains invalid characters, is empty or is too long (max length = 80).", serviceName));
		}
	}

	private static void ValidateMachineName(string machineName)
	{
		if (machineName == null || machineName.Length == 0)
		{
			throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "MachineName value {0} is invalid.", machineName));
		}
	}

	private static ServiceControllerImpl CreateServiceControllerImpl(ServiceController serviceController)
	{
		int platform = (int)Environment.OSVersion.Platform;
		if (platform == 4 || platform == 128 || platform == 6)
		{
			return new UnixServiceController(serviceController);
		}
		return new Win32ServiceController(serviceController);
	}
}
