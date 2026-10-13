using System.ComponentModel;

namespace System.Configuration.Install;

public abstract class ComponentInstaller : Installer
{
	public abstract void CopyFromComponent(IComponent component);

	[System.MonoTODO("Mono always returns false")]
	public virtual bool IsEquivalentInstaller(ComponentInstaller otherInstaller)
	{
		return false;
	}
}
