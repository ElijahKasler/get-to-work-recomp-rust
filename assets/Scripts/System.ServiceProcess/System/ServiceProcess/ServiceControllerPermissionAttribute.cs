using System.Security;
using System.Security.Permissions;

namespace System.ServiceProcess;

[Serializable]
[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Constructor | AttributeTargets.Method | AttributeTargets.Event, AllowMultiple = true, Inherited = false)]
public class ServiceControllerPermissionAttribute : CodeAccessSecurityAttribute
{
	private string machine_name;

	private string service_name;

	private ServiceControllerPermissionAccess permission_access;

	public string MachineName
	{
		get
		{
			return machine_name;
		}
		set
		{
			ServiceControllerPermission.ValidateMachineName(value);
			machine_name = value;
		}
	}

	public ServiceControllerPermissionAccess PermissionAccess
	{
		get
		{
			return permission_access;
		}
		set
		{
			permission_access = value;
		}
	}

	public string ServiceName
	{
		get
		{
			return service_name;
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentNullException("ServiceName");
			}
			ServiceControllerPermission.ValidateServiceName(value);
			service_name = value;
		}
	}

	public ServiceControllerPermissionAttribute(SecurityAction action)
		: base(action)
	{
		machine_name = ".";
		service_name = "*";
		permission_access = ServiceControllerPermissionAccess.Browse;
	}

	public override IPermission CreatePermission()
	{
		if (base.Unrestricted)
		{
			return new ServiceControllerPermission(PermissionState.Unrestricted);
		}
		return new ServiceControllerPermission(PermissionState.None);
	}
}
