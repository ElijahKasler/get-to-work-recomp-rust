using System.Security.Permissions;

namespace System.ServiceProcess;

[Serializable]
public class ServiceControllerPermissionEntry
{
	private string machine_name;

	private string service_name;

	private ServiceControllerPermissionAccess permission_access;

	public string MachineName => machine_name;

	public string ServiceName => service_name;

	public ServiceControllerPermissionAccess PermissionAccess => permission_access;

	public ServiceControllerPermissionEntry()
	{
		machine_name = ".";
		service_name = "*";
		permission_access = ServiceControllerPermissionAccess.Browse;
	}

	public ServiceControllerPermissionEntry(ServiceControllerPermissionAccess permissionAccess, string machineName, string serviceName)
	{
		ServiceControllerPermission.ValidateMachineName(machineName);
		ServiceControllerPermission.ValidateServiceName(serviceName);
		permission_access = permissionAccess;
		machine_name = machineName;
		service_name = serviceName;
	}

	internal ResourcePermissionBaseEntry GetBaseEntry()
	{
		return new ResourcePermissionBaseEntry((int)permission_access, new string[2] { machine_name, service_name });
	}
}
