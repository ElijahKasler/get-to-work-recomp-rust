using System.Collections;
using System.ComponentModel;
using System.Configuration.Install;

namespace System.ServiceProcess;

public class ServiceProcessInstaller : ComponentInstaller
{
	private ServiceAccount account;

	private string password;

	private string username;

	[ServiceProcessDescription("Indicates the account type under which the service will run.")]
	[DefaultValue(ServiceAccount.User)]
	public ServiceAccount Account
	{
		get
		{
			return account;
		}
		set
		{
			account = value;
		}
	}

	public override string HelpText
	{
		get
		{
			throw new NotImplementedException();
		}
	}

	[Browsable(false)]
	public string Password
	{
		get
		{
			return password;
		}
		set
		{
			password = value;
		}
	}

	[TypeConverter("System.Diagnostics.Design.StringValueConverter, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
	[Browsable(false)]
	public string Username
	{
		get
		{
			return username;
		}
		set
		{
			username = value;
		}
	}

	public override void CopyFromComponent(IComponent comp)
	{
		if (!comp.GetType().IsSubclassOf(typeof(ServiceBase)))
		{
			throw new ArgumentException();
		}
	}

	public override void Install(IDictionary stateSaver)
	{
		throw new NotImplementedException();
	}

	public override void Rollback(IDictionary savedState)
	{
		throw new NotImplementedException();
	}
}
