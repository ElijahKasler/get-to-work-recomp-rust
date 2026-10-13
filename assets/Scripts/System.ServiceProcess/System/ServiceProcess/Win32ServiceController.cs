using System.Collections;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Text;

namespace System.ServiceProcess;

internal class Win32ServiceController : ServiceControllerImpl
{
	internal struct QUERY_SERVICE_CONFIG
	{
		public int dwServiceType;

		public int dwStartType;

		public int dwErrorControl;

		public IntPtr lpBinaryPathName;

		public IntPtr lpLoadOrderGroup;

		public int dwTagId;

		public IntPtr lpDependencies;

		public IntPtr lpServiceStartName;

		public IntPtr lpDisplayName;
	}

	[Flags]
	private enum SERVICE_RIGHTS
	{
		SERVICE_QUERY_CONFIG = 1,
		SERVICE_CHANGE_CONFIG = 2,
		SERVICE_QUERY_STATUS = 4,
		SERVICE_ENUMERATE_DEPENDENTS = 8,
		SERVICE_START = 0x10,
		SERVICE_STOP = 0x20,
		SERVICE_PAUSE_CONTINUE = 0x40,
		SERVICE_INTERROGATE = 0x80,
		SERVICE_USER_DEFINED_CONTROL = 0x100,
		SERVICE_ALL_ACCESS = 0xF01FF
	}

	private enum SERVICE_MANAGER_RIGHTS : uint
	{
		STANDARD_RIGHTS_READ = 131072u,
		STANDARD_RIGHTS_WRITE = STANDARD_RIGHTS_READ,
		STANDARD_RIGHTS_EXECUTE = STANDARD_RIGHTS_READ,
		STANDARD_RIGHTS_ALL = 2031616u,
		SC_MANAGER_ALL_ACCESS = 983103u,
		SC_MANAGER_CONNECT = 1u,
		SC_MANAGER_CREATE_SERVICE = 2u,
		SC_MANAGER_ENUMERATE_SERVICE = 4u,
		SC_MANAGER_LOCK = 8u,
		SC_MANAGER_QUERY_LOCK_STATUS = 16u,
		SC_MANAGER_MODIFY_BOOT_CONFIG = 32u,
		GENERIC_READ = 2147483648u,
		GENERIC_WRITE = 1073741824u,
		GENERIC_EXECUTE = 536870912u,
		GENERIC_ALL = 268435456u
	}

	private struct ENUM_SERVICE_STATUS_PROCESS
	{
		public static readonly int SizeOf = Marshal.SizeOf(typeof(ENUM_SERVICE_STATUS_PROCESS));

		[MarshalAs(UnmanagedType.LPWStr)]
		public string pServiceName;

		[MarshalAs(UnmanagedType.LPWStr)]
		public string pDisplayName;

		public SERVICE_STATUS_PROCESS ServiceStatus;
	}

	private struct ENUM_SERVICE_STATUS
	{
		public static readonly int SizeOf = Marshal.SizeOf(typeof(ENUM_SERVICE_STATUS));

		[MarshalAs(UnmanagedType.LPWStr)]
		public string pServiceName;

		[MarshalAs(UnmanagedType.LPWStr)]
		public string pDisplayName;

		public SERVICE_STATUS ServiceStatus;
	}

	private struct SERVICE_STATUS
	{
		public ServiceType dwServiceType;

		public ServiceControllerStatus dwCurrentState;

		public SERVICE_CONTROL_ACCEPTED dwControlsAccepted;

		public int dwWin32ExitCode;

		public int dwServiceSpecificExitCode;

		public uint dwCheckPoint;

		public uint dwWaitHint;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	private struct SERVICE_STATUS_PROCESS
	{
		public static readonly int SizeOf = Marshal.SizeOf(typeof(SERVICE_STATUS_PROCESS));

		public ServiceType dwServiceType;

		public ServiceControllerStatus dwCurrentState;

		public SERVICE_CONTROL_ACCEPTED dwControlsAccepted;

		public int dwWin32ExitCode;

		public int dwServiceSpecificExitCode;

		public int dwCheckPoint;

		public int dwWaitHint;

		public int dwProcessId;

		public int dwServiceFlags;
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

	private enum SERVICE_START_TYPE
	{
		SERVICE_BOOT_START = 0,
		SERVICE_SYSTEM_START = 1,
		SERVICE_AUTO_START = 2,
		SERVICE_DEMAND_START = 3,
		SERVICE_DISABLED = 4,
		SERVICESTARTTYPE_NO_CHANGE = -1
	}

	private enum SERVICE_ERROR_CONTROL
	{
		SERVICE_ERROR_IGNORE = 0,
		SERVICE_ERROR_NORMAL = 1,
		SERVICE_ERROR_SEVERE = 2,
		SERVICE_ERROR_CRITICAL = 3,
		msidbServiceInstallErrorControlVital = 32768,
		SERVICEERRORCONTROL_NO_CHANGE = -1
	}

	private enum SERVICE_STATE_REQUEST
	{
		SERVICE_ACTIVE = 1,
		SERVICE_INACTIVE = 2,
		SERVICE_STATE_ALL = 3
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

	private SERVICE_STATUS_PROCESS _status;

	private const int SC_ENUM_PROCESS_INFO = 0;

	private const char SC_GROUP_IDENTIFIER = '+';

	private const int SC_STATUS_PROCESS_INFO = 0;

	private const int SERVICE_NO_CHANGE = -1;

	private const int ERROR_MORE_DATA = 234;

	private const int ERROR_INSUFFICIENT_BUFFER = 122;

	private const int STANDARD_RIGHTS_REQUIRED = 983040;

	private const string SERVICES_ACTIVE_DATABASE = "ServicesActive";

	public override bool CanPauseAndContinue
	{
		get
		{
			if (_status.dwServiceType == (ServiceType)0)
			{
				_status = GetServiceStatus(base.ServiceController.ServiceName, base.ServiceController.MachineName);
			}
			return (_status.dwControlsAccepted & SERVICE_CONTROL_ACCEPTED.SERVICE_ACCEPT_PAUSE_CONTINUE) != 0;
		}
	}

	public override bool CanShutdown
	{
		get
		{
			if (_status.dwServiceType == (ServiceType)0)
			{
				_status = GetServiceStatus(base.ServiceController.ServiceName, base.ServiceController.MachineName);
			}
			return (_status.dwControlsAccepted & SERVICE_CONTROL_ACCEPTED.SERVICE_ACCEPT_SHUTDOWN) != 0;
		}
	}

	public override bool CanStop
	{
		get
		{
			if (_status.dwServiceType == (ServiceType)0)
			{
				_status = GetServiceStatus(base.ServiceController.ServiceName, base.ServiceController.MachineName);
			}
			return (_status.dwControlsAccepted & SERVICE_CONTROL_ACCEPTED.SERVICE_ACCEPT_STOP) != 0;
		}
	}

	public override ServiceController[] DependentServices => GetDependentServices(base.ServiceController.ServiceName, base.ServiceController.MachineName);

	public override string DisplayName
	{
		get
		{
			string serviceName = base.ServiceController.ServiceName;
			IntPtr intPtr = IntPtr.Zero;
			try
			{
				intPtr = OpenServiceControlManager(base.ServiceController.MachineName, SERVICE_MANAGER_RIGHTS.SC_MANAGER_CONNECT);
				if (serviceName.Length == 0)
				{
					try
					{
						string serviceName2 = GetServiceName(intPtr, serviceName);
						base.ServiceController.InternalServiceName = serviceName2;
						base.ServiceController.Name = string.Empty;
						return serviceName;
					}
					catch (Win32Exception)
					{
					}
				}
				if (base.ServiceController.InternalDisplayName.Length == 0)
				{
					return GetServiceDisplayName(intPtr, serviceName, base.ServiceController.MachineName);
				}
				return base.ServiceController.InternalDisplayName;
			}
			finally
			{
				if (intPtr != IntPtr.Zero)
				{
					CloseServiceHandle(intPtr);
				}
			}
		}
	}

	public override string ServiceName
	{
		get
		{
			string text = base.ServiceController.Name;
			if (text.Length == 0)
			{
				text = base.ServiceController.InternalDisplayName;
			}
			IntPtr intPtr = IntPtr.Zero;
			try
			{
				intPtr = OpenServiceControlManager(base.ServiceController.MachineName, SERVICE_MANAGER_RIGHTS.SC_MANAGER_CONNECT);
				try
				{
					string serviceName = GetServiceName(intPtr, text);
					base.ServiceController.InternalDisplayName = text;
					base.ServiceController.Name = string.Empty;
					return serviceName;
				}
				catch (Win32Exception)
				{
				}
				string serviceDisplayName = GetServiceDisplayName(intPtr, text, base.ServiceController.MachineName);
				base.ServiceController.InternalDisplayName = serviceDisplayName;
				base.ServiceController.Name = string.Empty;
				return text;
			}
			finally
			{
				if (intPtr != IntPtr.Zero)
				{
					CloseServiceHandle(intPtr);
				}
			}
		}
	}

	public override ServiceController[] ServicesDependedOn => GetServiceDependencies(base.ServiceController.ServiceName, base.ServiceController.MachineName);

	public override ServiceType ServiceType
	{
		get
		{
			if (_status.dwServiceType == (ServiceType)0)
			{
				_status = GetServiceStatus(base.ServiceController.ServiceName, base.ServiceController.MachineName);
			}
			return _status.dwServiceType;
		}
	}

	public override ServiceControllerStatus Status
	{
		get
		{
			if (_status.dwServiceType == (ServiceType)0)
			{
				_status = GetServiceStatus(base.ServiceController.ServiceName, base.ServiceController.MachineName);
			}
			return _status.dwCurrentState;
		}
	}

	public Win32ServiceController(ServiceController serviceController)
		: base(serviceController)
	{
	}

	public override void Close()
	{
		_status.dwServiceType = (ServiceType)0;
	}

	public override void Continue()
	{
		string serviceName = base.ServiceController.ServiceName;
		string machineName = base.ServiceController.MachineName;
		IntPtr intPtr = IntPtr.Zero;
		IntPtr intPtr2 = IntPtr.Zero;
		try
		{
			intPtr = OpenServiceControlManager(machineName, SERVICE_MANAGER_RIGHTS.SC_MANAGER_CONNECT);
			intPtr2 = OpenService(intPtr, serviceName, SERVICE_RIGHTS.SERVICE_PAUSE_CONTINUE);
			if (intPtr2 == IntPtr.Zero)
			{
				throw CreateCannotOpenServiceException(serviceName, machineName);
			}
			SERVICE_STATUS lpServiceStatus = default;
			if (!ControlService(intPtr2, SERVICE_CONTROL_TYPE.SERVICE_CONTROL_CONTINUE, ref lpServiceStatus))
			{
				throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, "Cannot resume {0} service on computer '{1}'.", serviceName, machineName), new Win32Exception());
			}
		}
		finally
		{
			if (intPtr2 != IntPtr.Zero)
			{
				CloseServiceHandle(intPtr2);
			}
			if (intPtr != IntPtr.Zero)
			{
				CloseServiceHandle(intPtr);
			}
		}
	}

	public override void Dispose(bool disposing)
	{
	}

	public override void ExecuteCommand(int command)
	{
		string serviceName = base.ServiceController.ServiceName;
		string machineName = base.ServiceController.MachineName;
		IntPtr intPtr = IntPtr.Zero;
		IntPtr intPtr2 = IntPtr.Zero;
		try
		{
			intPtr = OpenServiceControlManager(machineName, SERVICE_MANAGER_RIGHTS.SC_MANAGER_CONNECT);
			intPtr2 = OpenService(intPtr, serviceName, SERVICE_RIGHTS.SERVICE_USER_DEFINED_CONTROL);
			if (intPtr2 == IntPtr.Zero)
			{
				throw CreateCannotOpenServiceException(serviceName, machineName);
			}
			SERVICE_STATUS lpServiceStatus = default;
			if (!ControlService(intPtr2, (SERVICE_CONTROL_TYPE)command, ref lpServiceStatus))
			{
				throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, "Cannot control {0} service on computer '{1}'.", serviceName, machineName), new Win32Exception());
			}
		}
		finally
		{
			if (intPtr2 != IntPtr.Zero)
			{
				CloseServiceHandle(intPtr2);
			}
			if (intPtr != IntPtr.Zero)
			{
				CloseServiceHandle(intPtr);
			}
		}
	}

	public override ServiceController[] GetDevices()
	{
		return GetServices(base.ServiceController.MachineName, SERVICE_TYPE.SERVICE_DRIVER, null);
	}

	public override ServiceController[] GetServices()
	{
		return GetServices(base.ServiceController.MachineName, SERVICE_TYPE.SERVICE_WIN32, null);
	}

	public override void Pause()
	{
		string serviceName = base.ServiceController.ServiceName;
		string machineName = base.ServiceController.MachineName;
		IntPtr intPtr = IntPtr.Zero;
		IntPtr intPtr2 = IntPtr.Zero;
		try
		{
			intPtr = OpenServiceControlManager(machineName, SERVICE_MANAGER_RIGHTS.SC_MANAGER_CONNECT);
			intPtr2 = OpenService(intPtr, serviceName, SERVICE_RIGHTS.SERVICE_PAUSE_CONTINUE);
			if (intPtr2 == IntPtr.Zero)
			{
				throw CreateCannotOpenServiceException(serviceName, machineName);
			}
			SERVICE_STATUS lpServiceStatus = default;
			if (!ControlService(intPtr2, SERVICE_CONTROL_TYPE.SERVICE_CONTROL_PAUSE, ref lpServiceStatus))
			{
				throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, "Cannot pause {0} service on computer '{1}'.", serviceName, machineName), new Win32Exception());
			}
		}
		finally
		{
			if (intPtr2 != IntPtr.Zero)
			{
				CloseServiceHandle(intPtr2);
			}
			if (intPtr != IntPtr.Zero)
			{
				CloseServiceHandle(intPtr);
			}
		}
	}

	public override void Refresh()
	{
		_status.dwServiceType = (ServiceType)0;
	}

	public override void Start(string[] args)
	{
		string serviceName = base.ServiceController.ServiceName;
		string machineName = base.ServiceController.MachineName;
		IntPtr intPtr = IntPtr.Zero;
		IntPtr intPtr2 = IntPtr.Zero;
		IntPtr[] array = new IntPtr[args.Length];
		try
		{
			intPtr = OpenServiceControlManager(machineName, SERVICE_MANAGER_RIGHTS.SC_MANAGER_CONNECT);
			intPtr2 = OpenService(intPtr, serviceName, SERVICE_RIGHTS.SERVICE_START);
			if (intPtr2 == IntPtr.Zero)
			{
				throw CreateCannotOpenServiceException(serviceName, machineName);
			}
			for (int i = 0; i < args.Length; i++)
			{
				string s = args[i];
				array[i] = Marshal.StringToHGlobalAnsi(s);
			}
			if (!StartService(intPtr2, array.Length, array))
			{
				throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, "Cannot start {0} service on computer '{1}'.", serviceName, machineName), new Win32Exception());
			}
		}
		finally
		{
			for (int j = 0; j < array.Length; j++)
			{
				Marshal.FreeHGlobal(array[j]);
			}
			if (intPtr2 != IntPtr.Zero)
			{
				CloseServiceHandle(intPtr2);
			}
			if (intPtr != IntPtr.Zero)
			{
				CloseServiceHandle(intPtr);
			}
		}
	}

	public override void Stop()
	{
		string serviceName = base.ServiceController.ServiceName;
		string machineName = base.ServiceController.MachineName;
		IntPtr intPtr = IntPtr.Zero;
		IntPtr intPtr2 = IntPtr.Zero;
		try
		{
			intPtr = OpenServiceControlManager(machineName, SERVICE_MANAGER_RIGHTS.SC_MANAGER_CONNECT);
			intPtr2 = OpenService(intPtr, serviceName, SERVICE_RIGHTS.SERVICE_STOP);
			if (intPtr2 == IntPtr.Zero)
			{
				throw CreateCannotOpenServiceException(serviceName, machineName);
			}
			SERVICE_STATUS lpServiceStatus = default;
			if (!ControlService(intPtr2, SERVICE_CONTROL_TYPE.SERVICE_CONTROL_STOP, ref lpServiceStatus))
			{
				throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, "Cannot stop {0} service on computer '{1}'.", serviceName, machineName), new Win32Exception());
			}
		}
		finally
		{
			if (intPtr2 != IntPtr.Zero)
			{
				CloseServiceHandle(intPtr2);
			}
			if (intPtr != IntPtr.Zero)
			{
				CloseServiceHandle(intPtr);
			}
		}
	}

	private static ServiceController[] GetDependentServices(string serviceName, string machineName)
	{
		IntPtr intPtr = IntPtr.Zero;
		IntPtr intPtr2 = IntPtr.Zero;
		IntPtr intPtr3 = IntPtr.Zero;
		try
		{
			intPtr = OpenServiceControlManager(machineName, SERVICE_MANAGER_RIGHTS.SC_MANAGER_CONNECT);
			intPtr2 = OpenService(intPtr, serviceName, SERVICE_RIGHTS.SERVICE_ENUMERATE_DEPENDENTS);
			if (intPtr2 == IntPtr.Zero)
			{
				throw CreateCannotOpenServiceException(serviceName, machineName);
			}
			uint cbBufSize = 0u;
			uint pcbBytesNeeded = 0u;
			uint lpServicesReturned = 0u;
			while (!EnumDependentServices(intPtr2, SERVICE_STATE_REQUEST.SERVICE_STATE_ALL, intPtr3, cbBufSize, out pcbBytesNeeded, out lpServicesReturned))
			{
				int lastWin32Error = Marshal.GetLastWin32Error();
				if (lastWin32Error == 234)
				{
					intPtr3 = Marshal.AllocHGlobal((int)pcbBytesNeeded);
					cbBufSize = pcbBytesNeeded;
					continue;
				}
				throw new Win32Exception(lastWin32Error);
			}
			IntPtr intPtr4 = intPtr3;
			ServiceController[] array = new ServiceController[lpServicesReturned];
			for (int i = 0; i < lpServicesReturned; i++)
			{
				array[i] = new ServiceController(((ENUM_SERVICE_STATUS)Marshal.PtrToStructure(intPtr4, typeof(ENUM_SERVICE_STATUS))).pServiceName, machineName);
				intPtr4 = IntPtr.Add(intPtr4, ENUM_SERVICE_STATUS.SizeOf);
			}
			return array;
		}
		finally
		{
			if (intPtr != IntPtr.Zero)
			{
				CloseServiceHandle(intPtr);
			}
			if (intPtr2 != IntPtr.Zero)
			{
				CloseServiceHandle(intPtr2);
			}
			if (intPtr3 != IntPtr.Zero)
			{
				Marshal.FreeHGlobal(intPtr3);
			}
		}
	}

	private static ServiceController[] GetServiceDependencies(string serviceName, string machineName)
	{
		IntPtr intPtr = IntPtr.Zero;
		IntPtr intPtr2 = IntPtr.Zero;
		IntPtr intPtr3 = IntPtr.Zero;
		try
		{
			intPtr = OpenServiceControlManager(machineName, SERVICE_MANAGER_RIGHTS.SC_MANAGER_CONNECT);
			intPtr2 = OpenService(intPtr, serviceName, SERVICE_RIGHTS.SERVICE_QUERY_CONFIG);
			if (intPtr2 == IntPtr.Zero)
			{
				throw CreateCannotOpenServiceException(serviceName, machineName);
			}
			uint cbBufSize = 0u;
			uint pcbBytesNeeded = 0u;
			while (!QueryServiceConfig(intPtr2, intPtr3, cbBufSize, out pcbBytesNeeded))
			{
				int lastWin32Error = Marshal.GetLastWin32Error();
				if (lastWin32Error == 122)
				{
					intPtr3 = Marshal.AllocHGlobal((int)pcbBytesNeeded);
					cbBufSize = pcbBytesNeeded;
					continue;
				}
				throw new Win32Exception(lastWin32Error);
			}
			QUERY_SERVICE_CONFIG obj = (QUERY_SERVICE_CONFIG)Marshal.PtrToStructure(intPtr3, typeof(QUERY_SERVICE_CONFIG));
			Hashtable hashtable = new Hashtable();
			IntPtr ptr = obj.lpDependencies;
			StringBuilder stringBuilder = new StringBuilder();
			string text = Marshal.PtrToStringUni(ptr, 1);
			while (text != "\0")
			{
				stringBuilder.Append(text);
				ptr = new IntPtr(ptr.ToInt64() + Marshal.SystemDefaultCharSize);
				text = Marshal.PtrToStringUni(ptr, 1);
				if (text != "\0")
				{
					continue;
				}
				ptr = new IntPtr(ptr.ToInt64() + Marshal.SystemDefaultCharSize);
				text = Marshal.PtrToStringUni(ptr, 1);
				string text2 = stringBuilder.ToString();
				if (text2[0] == '+')
				{
					ServiceController[] services = GetServices(machineName, SERVICE_TYPE.SERVICE_WIN32, text2.Substring(1));
					foreach (ServiceController serviceController in services)
					{
						if (!hashtable.Contains(serviceController.ServiceName))
						{
							hashtable.Add(serviceController.ServiceName, serviceController);
						}
					}
				}
				else if (!hashtable.Contains(text2))
				{
					hashtable.Add(text2, new ServiceController(text2, machineName));
				}
				stringBuilder.Length = 0;
			}
			ServiceController[] array = new ServiceController[hashtable.Count];
			hashtable.Values.CopyTo(array, 0);
			return array;
		}
		finally
		{
			if (intPtr != IntPtr.Zero)
			{
				CloseServiceHandle(intPtr);
			}
			if (intPtr2 != IntPtr.Zero)
			{
				CloseServiceHandle(intPtr2);
			}
			if (intPtr3 != IntPtr.Zero)
			{
				Marshal.FreeHGlobal(intPtr3);
			}
		}
	}

	private static string GetServiceDisplayName(IntPtr scHandle, string serviceName, string machineName)
	{
		StringBuilder stringBuilder = new StringBuilder();
		uint lpcchBuffer = (uint)stringBuilder.Capacity;
		while (!GetServiceDisplayName(scHandle, serviceName, stringBuilder, ref lpcchBuffer))
		{
			if (Marshal.GetLastWin32Error() == 122)
			{
				stringBuilder = new StringBuilder((int)(lpcchBuffer + 1));
				lpcchBuffer = (uint)stringBuilder.Capacity;
				continue;
			}
			throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, "Service {0} was not found on computer '{1}'.", serviceName, machineName), new Win32Exception());
		}
		return stringBuilder.ToString();
	}

	private static string GetServiceName(IntPtr scHandle, string displayName)
	{
		StringBuilder stringBuilder = new StringBuilder();
		uint lpcchBuffer = (uint)stringBuilder.Capacity;
		while (!GetServiceKeyName(scHandle, displayName, stringBuilder, ref lpcchBuffer))
		{
			if (Marshal.GetLastWin32Error() == 122)
			{
				stringBuilder = new StringBuilder((int)(lpcchBuffer + 1));
				lpcchBuffer = (uint)stringBuilder.Capacity;
				continue;
			}
			throw new Win32Exception();
		}
		return stringBuilder.ToString();
	}

	private static SERVICE_STATUS_PROCESS GetServiceStatus(string serviceName, string machineName)
	{
		IntPtr intPtr = IntPtr.Zero;
		IntPtr intPtr2 = IntPtr.Zero;
		IntPtr intPtr3 = IntPtr.Zero;
		try
		{
			intPtr = OpenServiceControlManager(machineName, SERVICE_MANAGER_RIGHTS.SC_MANAGER_CONNECT);
			intPtr2 = OpenService(intPtr, serviceName, SERVICE_RIGHTS.SERVICE_QUERY_STATUS);
			if (intPtr2 == IntPtr.Zero)
			{
				throw CreateCannotOpenServiceException(serviceName, machineName);
			}
			int cbBufSize = 0;
			int pcbBytesNeeded = 0;
			while (!QueryServiceStatusEx(intPtr2, 0, intPtr3, cbBufSize, out pcbBytesNeeded))
			{
				int lastWin32Error = Marshal.GetLastWin32Error();
				if (lastWin32Error == 122)
				{
					intPtr3 = Marshal.AllocHGlobal(pcbBytesNeeded);
					cbBufSize = pcbBytesNeeded;
					continue;
				}
				throw new Win32Exception(lastWin32Error);
			}
			return (SERVICE_STATUS_PROCESS)Marshal.PtrToStructure(intPtr3, typeof(SERVICE_STATUS_PROCESS));
		}
		finally
		{
			if (intPtr != IntPtr.Zero)
			{
				CloseServiceHandle(intPtr);
			}
			if (intPtr2 != IntPtr.Zero)
			{
				CloseServiceHandle(intPtr2);
			}
			if (intPtr3 != IntPtr.Zero)
			{
				Marshal.FreeHGlobal(intPtr3);
			}
		}
	}

	private static ServiceController[] GetServices(string machineName, SERVICE_TYPE serviceType, string group)
	{
		IntPtr intPtr = IntPtr.Zero;
		IntPtr intPtr2 = IntPtr.Zero;
		try
		{
			intPtr = OpenServiceControlManager(machineName, SERVICE_MANAGER_RIGHTS.SC_MANAGER_ENUMERATE_SERVICE);
			uint cbBufSize = 0u;
			uint pcbBytesNeeded = 0u;
			uint lpServicesReturned = 0u;
			uint lpResumeHandle = 0u;
			while (!EnumServicesStatusEx(intPtr, 0, serviceType, SERVICE_STATE_REQUEST.SERVICE_STATE_ALL, intPtr2, cbBufSize, out pcbBytesNeeded, out lpServicesReturned, ref lpResumeHandle, group))
			{
				int lastWin32Error = Marshal.GetLastWin32Error();
				if (lastWin32Error == 234)
				{
					intPtr2 = Marshal.AllocHGlobal((int)pcbBytesNeeded);
					cbBufSize = pcbBytesNeeded;
					continue;
				}
				throw new Win32Exception(lastWin32Error);
			}
			IntPtr intPtr3 = intPtr2;
			ServiceController[] array = new ServiceController[lpServicesReturned];
			for (int i = 0; i < lpServicesReturned; i++)
			{
				array[i] = new ServiceController(((ENUM_SERVICE_STATUS_PROCESS)Marshal.PtrToStructure(intPtr3, typeof(ENUM_SERVICE_STATUS_PROCESS))).pServiceName, machineName);
				intPtr3 = IntPtr.Add(intPtr3, ENUM_SERVICE_STATUS_PROCESS.SizeOf);
			}
			return array;
		}
		finally
		{
			if (intPtr != IntPtr.Zero)
			{
				CloseServiceHandle(intPtr);
			}
			if (intPtr2 != IntPtr.Zero)
			{
				Marshal.FreeHGlobal(intPtr2);
			}
		}
	}

	private static IntPtr OpenServiceControlManager(string machineName, SERVICE_MANAGER_RIGHTS rights)
	{
		return OpenServiceControlManager(machineName, rights, ignoreWin32Error: false);
	}

	private static IntPtr OpenServiceControlManager(string machineName, SERVICE_MANAGER_RIGHTS rights, bool ignoreWin32Error)
	{
		IntPtr intPtr = OpenSCManager(machineName, "ServicesActive", rights);
		if (intPtr == IntPtr.Zero)
		{
			string message = string.Format(CultureInfo.CurrentCulture, "Cannot open Service Control Manager on computer '{0}'. This operation might require other priviliges.", machineName);
			if (ignoreWin32Error)
			{
				throw new InvalidOperationException(message);
			}
			throw new InvalidOperationException(message, new Win32Exception());
		}
		return intPtr;
	}

	private static InvalidOperationException CreateCannotOpenServiceException(string serviceName, string machineName)
	{
		return new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, "Cannot open {0} service on computer '{1}'.", serviceName, machineName), new Win32Exception());
	}

	[DllImport("advapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
	private static extern void CloseServiceHandle(IntPtr SCHANDLE);

	[DllImport("advapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
	private static extern bool ControlService(IntPtr hService, SERVICE_CONTROL_TYPE dwControl, ref SERVICE_STATUS lpServiceStatus);

	[DllImport("advapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
	private static extern bool EnumDependentServices(IntPtr hService, SERVICE_STATE_REQUEST dwServiceState, IntPtr lpServices, uint cbBufSize, out uint pcbBytesNeeded, out uint lpServicesReturned);

	[DllImport("advapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
	private static extern bool EnumServicesStatusEx(IntPtr hSCManager, int InfoLevel, SERVICE_TYPE dwServiceType, SERVICE_STATE_REQUEST dwServiceState, IntPtr lpServices, uint cbBufSize, out uint pcbBytesNeeded, out uint lpServicesReturned, ref uint lpResumeHandle, string pszGroupName);

	[DllImport("advapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
	private static extern bool GetServiceDisplayName(IntPtr hSCManager, string lpServiceName, StringBuilder lpDisplayName, ref uint lpcchBuffer);

	[DllImport("advapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
	private static extern bool GetServiceKeyName(IntPtr hSCManager, string lpDisplayName, StringBuilder lpServiceName, ref uint lpcchBuffer);

	[DllImport("advapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
	private static extern IntPtr OpenSCManager(string lpMachineName, string lpSCDB, SERVICE_MANAGER_RIGHTS scParameter);

	[DllImport("advapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
	private static extern IntPtr OpenService(IntPtr SCHANDLE, string lpSvcName, SERVICE_RIGHTS dwNumServiceArgs);

	[DllImport("advapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
	private static extern bool QueryServiceConfig(IntPtr hService, IntPtr lpServiceConfig, uint cbBufSize, out uint pcbBytesNeeded);

	[DllImport("advapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
	private static extern bool QueryServiceStatusEx(IntPtr serviceHandle, int InfoLevel, IntPtr lpBuffer, int cbBufSize, out int pcbBytesNeeded);

	[DllImport("advapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
	private static extern bool StartService(IntPtr SVHANDLE, int dwNumServiceArgs, IntPtr[] lpServiceArgVectors);
}
