using System.Collections;

namespace System.Configuration.Install;

public class TransactedInstaller : Installer
{
	public override void Install(IDictionary savedState)
	{
		base.Install(savedState);
	}

	public override void Uninstall(IDictionary savedState)
	{
		base.Uninstall(savedState);
	}
}
