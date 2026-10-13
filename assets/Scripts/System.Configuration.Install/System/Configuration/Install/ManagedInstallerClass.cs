using System.Runtime.InteropServices;

namespace System.Configuration.Install;

[ComVisible(true)]
[Guid("42EB0342-0393-448f-84AA-D4BEB0283595")]
public class ManagedInstallerClass : IManagedInstaller
{
	[System.MonoTODO]
	public static void InstallHelper(string[] args)
	{
		throw new NotImplementedException();
	}

	[System.MonoTODO]
	int IManagedInstaller.ManagedInstall(string argString, int hInstall)
	{
		throw new NotImplementedException();
	}
}
