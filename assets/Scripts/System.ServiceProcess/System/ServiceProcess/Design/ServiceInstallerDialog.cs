using System.Windows.Forms;

namespace System.ServiceProcess.Design;

[System.MonoTODO]
public class ServiceInstallerDialog : Form
{
	private string username;

	private string password;

	private const ServiceInstallerDialogResult result = ServiceInstallerDialogResult.OK;

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

	[System.MonoTODO]
	public ServiceInstallerDialogResult Result => ServiceInstallerDialogResult.OK;

	[System.MonoTODO]
	[STAThread]
	public static void Main()
	{
		Application.Run(new ServiceInstallerDialog());
	}
}
