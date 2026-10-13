using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;

namespace System.ServiceProcess;

[InstallerType(typeof(ServiceProcessInstaller))]
public class ServiceBase : Component
{
	internal delegate void RunServiceCallback(ServiceBase[] services);

	internal delegate void NotifyStatusCallback(ServiceBase service, ServiceControllerStatus status);

	[Flags]
	private enum SERVICE_CONTROL_ACCEPTED
	{
		SERVICE_ACCEPT_NONE = 0,
		SERVICE_ACCEPT_STOP = 1,
		SERVICE_ACCEPT_PAUSE_CONTINUE = 2,
		SERVICE_ACCEPT_SHUTDOWN = 4,
		SERVICE_ACCEPT_PARAMCHANGE = 8,
		SERVICE_ACCEPT_NETBINDCHANGE = 0x10,
		SERVICE_ACCEPT_HARDWAREPROFILECHANGE = 0x20,
		SERVICE_ACCEPT_POWEREVENT = 0x40,
		SERVICE_ACCEPT_SESSIONCHANGE = 0x80
	}

	private enum SERVICE_CONTROL_TYPE
	{
		SERVICE_CONTROL_STOP = 1,
		SERVICE_CONTROL_PAUSE = 2,
		SERVICE_CONTROL_CONTINUE = 3,
		SERVICE_CONTROL_INTERROGATE = 4,
		SERVICE_CONTROL_SHUTDOWN = 5,
		SERVICE_CONTROL_PARAMCHANGE = 6,
		SERVICE_CONTROL_NETBINDADD = 7,
		SERVICE_CONTROL_NETBINDREMOVE = 8,
		SERVICE_CONTROL_NETBINDENABLE = 9,
		SERVICE_CONTROL_NETBINDDISABLE = 10,
		SERVICE_CONTROL_DEVICEEVENT = 11,
		SERVICE_CONTROL_HARDWAREPROFILECHANGE = 12,
		SERVICE_CONTROL_POWEREVENT = 13,
		SERVICE_CONTROL_SESSIONCHANGE = 14
	}

	private enum SERVICE_TYPE
	{
		SERVICE_KERNEL_DRIVER = 1,
		SERVICE_FILE_SYSTEM_DRIVER = 2,
		SERVICE_ADAPTER = 4,
		SERVICE_RECOGNIZER_DRIVER = 8,
		SERVICE_DRIVER = 11,
		SERVICE_WIN32_OWN_PROCESS = 16,
		SERVICE_WIN32_SHARE_PROCESS = 32,
		SERVICE_INTERACTIVE_PROCESS = 256,
		SERVICETYPE_NO_CHANGE = -1,
		SERVICE_WIN32 = 48,
		SERVICE_TYPE_ALL = 319
	}

	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	private delegate int LPHANDLER_FUNCTION_EX(int dwControl, int dwEventType, IntPtr lpEventData, IntPtr lpContext);

	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	private delegate void LPSERVICE_MAIN_FUNCTION(int dwArgc, IntPtr lpszArgv);

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	private struct SERVICE_STATUS
	{
		public int dwServiceType;

		public int dwCurrentState;

		public int dwControlsAccepted;

		public int dwWin32ExitCode;

		public int dwServiceSpecificErrorCode;

		public int dwCheckPoint;

		public int dwWaitHint;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	private struct SERVICE_TABLE_ENTRY
	{
		[MarshalAs(UnmanagedType.LPWStr)]
		public string lpServiceName;

		public LPSERVICE_MAIN_FUNCTION lpServiceProc;
	}

	internal static RunServiceCallback RunService;

	internal static NotifyStatusCallback NotifyStatus;

	public const int MaxNameLength = 80;

	private bool hasStarted;

	private bool auto_log = true;

	private bool can_handle_power_event;

	private bool can_pause_and_continue;

	private bool can_shutdown;

	private bool can_stop = true;

	private EventLog event_log;

	private string service_name;

	private bool can_handle_session_change_event;

	private IntPtr service_handle;

	private ManualResetEvent stop_event;

	private static bool share_process;

	private const int NO_ERROR = 0;

	private const int ERROR_CALL_NOT_IMPLEMENTED = 120;

	private const int SERVICE_NO_CHANGE = -1;

	[ServiceProcessDescription("Whether the service should automatically write to the event log on common events such as Install and Start.")]
	[DefaultValue(true)]
	public bool AutoLog
	{
		get
		{
			return auto_log;
		}
		set
		{
			auto_log = value;
		}
	}

	[System.MonoTODO]
	[DefaultValue(false)]
	public bool CanHandlePowerEvent
	{
		get
		{
			return can_handle_power_event;
		}
		set
		{
			if (hasStarted)
			{
				throw new InvalidOperationException(global::Locale.GetText("Cannot modify this property after the service has started."));
			}
			can_handle_power_event = value;
		}
	}

	[DefaultValue(false)]
	[ComVisible(false)]
	[System.MonoTODO]
	public bool CanHandleSessionChangeEvent
	{
		get
		{
			return can_handle_session_change_event;
		}
		set
		{
			if (hasStarted)
			{
				throw new InvalidOperationException(global::Locale.GetText("Cannot modify this property after the service has started."));
			}
			can_handle_session_change_event = value;
		}
	}

	[DefaultValue(false)]
	public bool CanPauseAndContinue
	{
		get
		{
			return can_pause_and_continue;
		}
		set
		{
			if (hasStarted)
			{
				throw new InvalidOperationException(global::Locale.GetText("Cannot modify this property after the service has started."));
			}
			can_pause_and_continue = value;
		}
	}

	[DefaultValue(false)]
	public bool CanShutdown
	{
		get
		{
			return can_shutdown;
		}
		set
		{
			if (hasStarted)
			{
				throw new InvalidOperationException(global::Locale.GetText("Cannot modify this property after the service has started."));
			}
			can_shutdown = value;
		}
	}

	[DefaultValue(true)]
	public bool CanStop
	{
		get
		{
			return can_stop;
		}
		set
		{
			if (hasStarted)
			{
				throw new InvalidOperationException(global::Locale.GetText("Cannot modify this property after the service has started."));
			}
			can_stop = value;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public virtual EventLog EventLog
	{
		get
		{
			if (event_log == null)
			{
				event_log = new EventLog("Application", ".", service_name);
			}
			return event_log;
		}
	}

	[ComVisible(false)]
	public int ExitCode { get; set; }

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[System.MonoTODO]
	protected IntPtr ServiceHandle => service_handle;

	[ServiceProcessDescription("The name by which the service is identified to the system.")]
	[TypeConverter("System.Diagnostics.Design.StringValueConverter, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
	public string ServiceName
	{
		get
		{
			return service_name;
		}
		set
		{
			if (hasStarted)
			{
				throw new InvalidOperationException(global::Locale.GetText("Cannot modify this property after the service has started."));
			}
			service_name = value;
		}
	}

	protected override void Dispose(bool disposing)
	{
	}

	protected virtual void OnStart(string[] args)
	{
	}

	protected virtual void OnStop()
	{
	}

	protected virtual void OnContinue()
	{
	}

	protected virtual void OnCustomCommand(int command)
	{
	}

	protected virtual void OnPause()
	{
	}

	protected virtual bool OnPowerEvent(PowerBroadcastStatus powerStatus)
	{
		return true;
	}

	protected virtual void OnShutdown()
	{
	}

	protected virtual void OnSessionChange(SessionChangeDescription changeDescription)
	{
	}

	[ComVisible(false)]
	[System.MonoTODO]
	public void RequestAdditionalTime(int milliseconds)
	{
		throw new NotImplementedException();
	}

	public void Stop()
	{
		if (stop_event != null)
		{
			stop_event.Set();
		}
		else
		{
			OnStop();
		}
	}

	private void SetStatus(ServiceControllerStatus status)
	{
		if (!hasStarted && status != ServiceControllerStatus.Stopped)
		{
			hasStarted = true;
		}
		if (NotifyStatus != null)
		{
			NotifyStatus(this, status);
		}
	}

	[DllImport("advapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
	private static extern IntPtr RegisterServiceCtrlHandlerEx(string lpServiceName, LPHANDLER_FUNCTION_EX lpHandlerProc, IntPtr lpContext);

	[DllImport("advapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
	private static extern bool SetServiceStatus(IntPtr hServiceStatus, [MarshalAs(UnmanagedType.LPStruct)] SERVICE_STATUS status);

	[DllImport("advapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
	private static extern bool StartServiceCtrlDispatcher([MarshalAs(UnmanagedType.LPArray)] SERVICE_TABLE_ENTRY[] lpServiceTable);

	private static void Win32NotifyStatus(ServiceBase service, ServiceControllerStatus status)
	{
		SERVICE_STATUS status2 = new SERVICE_STATUS
		{
			dwServiceType = (share_process ? 32 : 16),
			dwCurrentState = (int)status
		};
		if (status != ServiceControllerStatus.StartPending)
		{
			if (service.can_stop)
			{
				status2.dwControlsAccepted |= 1;
			}
			if (service.can_pause_and_continue)
			{
				status2.dwControlsAccepted |= 2;
			}
			if (service.can_handle_power_event)
			{
				status2.dwControlsAccepted |= 64;
			}
			if (service.can_handle_session_change_event)
			{
				status2.dwControlsAccepted |= 128;
			}
			if (service.can_shutdown)
			{
				status2.dwControlsAccepted |= 4;
			}
		}
		status2.dwWin32ExitCode = service.ExitCode;
		status2.dwWaitHint = 5000;
		SetServiceStatus(service.service_handle, status2);
	}

	private int Win32HandlerFn(int dwControl, int dwEventType, IntPtr lpEventData, IntPtr lpContext)
	{
		switch ((SERVICE_CONTROL_TYPE)dwControl)
		{
		case SERVICE_CONTROL_TYPE.SERVICE_CONTROL_STOP:
			if (can_stop)
			{
				Stop();
				return 0;
			}
			break;
		case SERVICE_CONTROL_TYPE.SERVICE_CONTROL_PAUSE:
			if (can_pause_and_continue)
			{
				SetStatus(ServiceControllerStatus.PausePending);
				OnPause();
				SetStatus(ServiceControllerStatus.Paused);
				return 0;
			}
			break;
		case SERVICE_CONTROL_TYPE.SERVICE_CONTROL_CONTINUE:
			if (can_pause_and_continue)
			{
				SetStatus(ServiceControllerStatus.ContinuePending);
				OnContinue();
				SetStatus(ServiceControllerStatus.Running);
				return 0;
			}
			break;
		case SERVICE_CONTROL_TYPE.SERVICE_CONTROL_INTERROGATE:
			return 0;
		case SERVICE_CONTROL_TYPE.SERVICE_CONTROL_SHUTDOWN:
			if (can_shutdown)
			{
				OnShutdown();
				return 0;
			}
			break;
		}
		return 120;
	}

	[ComVisible(false)]
	[System.MonoTODO("This only makes sense on Windows")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public void ServiceMainCallback(int argCount, IntPtr argPointer)
	{
		LPHANDLER_FUNCTION_EX lpHandlerProc = Win32HandlerFn;
		service_handle = RegisterServiceCtrlHandlerEx(ServiceName ?? "", lpHandlerProc, IntPtr.Zero);
		if (service_handle != IntPtr.Zero)
		{
			SetStatus(ServiceControllerStatus.StartPending);
			stop_event = new ManualResetEvent(initialState: false);
			string[] array = new string[argCount];
			for (int i = 0; i < argCount; i++)
			{
				IntPtr ptr = Marshal.ReadIntPtr(argPointer, IntPtr.Size * i);
				array[i] = Marshal.PtrToStringUni(ptr);
			}
			OnStart(array);
			SetStatus(ServiceControllerStatus.Running);
			stop_event.WaitOne();
			SetStatus(ServiceControllerStatus.StopPending);
			OnStop();
			SetStatus(ServiceControllerStatus.Stopped);
		}
	}

	private static void Win32RunService(ServiceBase[] services)
	{
		SERVICE_TABLE_ENTRY[] array = new SERVICE_TABLE_ENTRY[services.Length + 1];
		NotifyStatus = Win32NotifyStatus;
		for (int i = 0; i < services.Length; i++)
		{
			array[i].lpServiceName = services[i].ServiceName ?? "";
			array[i].lpServiceProc = services[i].ServiceMainCallback;
		}
		share_process = services.Length > 1;
		if (!StartServiceCtrlDispatcher(array))
		{
			throw new Win32Exception();
		}
	}

	public static void Run(ServiceBase service)
	{
		Run(new ServiceBase[1] { service });
	}

	public static void Run(ServiceBase[] services)
	{
		int platform = (int)Environment.OSVersion.Platform;
		if (RunService != null)
		{
			RunService(services);
		}
		else if (platform != 4 && platform != 128 && platform != 6)
		{
			Win32RunService(services);
		}
		else
		{
			Console.Error.WriteLine("Use mono-service to start service processes");
		}
	}
}
