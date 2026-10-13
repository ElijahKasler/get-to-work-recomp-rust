using System.Collections;
using System.ComponentModel;
using System.Configuration.Install;
using System.Runtime.InteropServices;

namespace System.ServiceProcess;

[System.MonoTODO]
public class ServiceInstaller : ComponentInstaller
{
	private string display_name;

	private string service_name;

	private string[] services_depended_on;

	private ServiceStartMode start_type;

	private string description;

	private bool delayedAutoStart;

	[DefaultValue(false)]
	[ServiceProcessDescription("Indicates that the service's start should be delayed after other automatically started services have started.")]
	public bool DelayedAutoStart
	{
		get
		{
			return delayedAutoStart;
		}
		set
		{
			delayedAutoStart = value;
		}
	}

	[ComVisible(false)]
	[DefaultValue("")]
	[ServiceProcessDescription("Indicates the service's description (a brief comment that explains the purpose of the service). ")]
	public string Description
	{
		get
		{
			return description;
		}
		set
		{
			description = value;
		}
	}

	[DefaultValue("")]
	[ServiceProcessDescription("Indicates the friendly name that identifies the service to the user.")]
	public string DisplayName
	{
		get
		{
			return display_name;
		}
		set
		{
			display_name = value;
		}
	}

	[ServiceProcessDescription("Indicates the name used by the system to identify this service.")]
	[TypeConverter("System.Diagnostics.Design.StringValueConverter, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
	[DefaultValue("")]
	public string ServiceName
	{
		get
		{
			return service_name;
		}
		set
		{
			if (value == null || value.Length == 0 || value.Length > 256)
			{
				throw new ArgumentException();
			}
			service_name = value;
		}
	}

	[ServiceProcessDescription("Indicates the services that must be running in order for this service to run.")]
	public string[] ServicesDependedOn
	{
		get
		{
			return services_depended_on;
		}
		set
		{
			services_depended_on = value;
		}
	}

	[ServiceProcessDescription("Indicates how and when this service is started.")]
	[DefaultValue(ServiceStartMode.Manual)]
	public ServiceStartMode StartType
	{
		get
		{
			return start_type;
		}
		set
		{
			start_type = value;
		}
	}

	public override void CopyFromComponent(IComponent component)
	{
		if (!component.GetType().IsSubclassOf(typeof(ServiceBase)))
		{
			throw new ArgumentException();
		}
	}

	public override void Install(IDictionary stateSaver)
	{
		throw new NotImplementedException();
	}

	public override bool IsEquivalentInstaller(ComponentInstaller otherInstaller)
	{
		throw new NotImplementedException();
	}

	public override void Rollback(IDictionary savedState)
	{
		throw new NotImplementedException();
	}

	public override void Uninstall(IDictionary savedState)
	{
		throw new NotImplementedException();
	}
}
