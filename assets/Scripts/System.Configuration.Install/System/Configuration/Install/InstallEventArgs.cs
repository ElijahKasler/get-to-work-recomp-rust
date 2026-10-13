using System.Collections;

namespace System.Configuration.Install;

public class InstallEventArgs : EventArgs
{
	private IDictionary savedstate;

	public IDictionary SavedState => savedstate;

	public InstallEventArgs()
	{
	}

	public InstallEventArgs(IDictionary savedState)
	{
		savedstate = savedState;
	}
}
