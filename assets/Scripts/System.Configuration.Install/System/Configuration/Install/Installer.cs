using System.Collections;
using System.ComponentModel;

namespace System.Configuration.Install;

[DefaultEvent("AfterInstall")]
public class Installer : Component
{
	private InstallContext context;

	private string helptext;

	private InstallerCollection installers;

	internal Installer parent;

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public InstallContext Context
	{
		get
		{
			return context;
		}
		set
		{
			context = value;
		}
	}

	public virtual string HelpText => helptext;

	public InstallerCollection Installers
	{
		get
		{
			if (installers == null)
			{
				installers = new InstallerCollection(this);
			}
			return installers;
		}
	}

	public Installer Parent
	{
		get
		{
			return parent;
		}
		set
		{
			parent = value;
		}
	}

	public event InstallEventHandler AfterInstall;

	public event InstallEventHandler AfterRollback;

	public event InstallEventHandler AfterUninstall;

	public event InstallEventHandler BeforeInstall;

	public event InstallEventHandler BeforeRollback;

	public event InstallEventHandler BeforeUninstall;

	public event InstallEventHandler Committed;

	public event InstallEventHandler Committing;

	public virtual void Commit(IDictionary savedState)
	{
	}

	public virtual void Install(IDictionary stateSaver)
	{
	}

	protected virtual void OnAfterInstall(IDictionary savedState)
	{
		if (AfterInstall != null)
		{
			AfterInstall(this, new InstallEventArgs(savedState));
		}
	}

	protected virtual void OnAfterRollback(IDictionary savedState)
	{
		if (AfterRollback != null)
		{
			AfterRollback(this, new InstallEventArgs(savedState));
		}
	}

	protected virtual void OnAfterUninstall(IDictionary savedState)
	{
		if (AfterUninstall != null)
		{
			AfterUninstall(this, new InstallEventArgs(savedState));
		}
	}

	protected virtual void OnBeforeInstall(IDictionary savedState)
	{
		if (BeforeInstall != null)
		{
			BeforeInstall(this, new InstallEventArgs(savedState));
		}
	}

	protected virtual void OnBeforeRollback(IDictionary savedState)
	{
		if (BeforeRollback != null)
		{
			BeforeRollback(this, new InstallEventArgs(savedState));
		}
	}

	protected virtual void OnBeforeUninstall(IDictionary savedState)
	{
		if (BeforeUninstall != null)
		{
			BeforeUninstall(this, new InstallEventArgs(savedState));
		}
	}

	protected virtual void OnCommitted(IDictionary savedState)
	{
		if (Committed != null)
		{
			Committed(this, new InstallEventArgs(savedState));
		}
	}

	protected virtual void OnCommitting(IDictionary savedState)
	{
		if (Committing != null)
		{
			Committing(this, new InstallEventArgs(savedState));
		}
	}

	public virtual void Rollback(IDictionary savedState)
	{
	}

	public virtual void Uninstall(IDictionary savedState)
	{
	}
}
