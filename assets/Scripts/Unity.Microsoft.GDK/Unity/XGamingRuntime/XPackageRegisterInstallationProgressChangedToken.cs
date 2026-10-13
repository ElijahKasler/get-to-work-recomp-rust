using System;
using Unity.XGamingRuntime.Interop;

namespace Unity.XGamingRuntime;

public class XPackageRegisterInstallationProgressChangedToken
{
	internal Unity.XGamingRuntime.Interop.XPackageRegisterInstallationProgressChangedToken interop { get; private set; }

	public ulong Token
	{
		get
		{
			return interop.Token;
		}
		set
		{
			interop.Token = value;
		}
	}

	public bool IsValid => interop.IsValid;

	internal XPackageRegisterInstallationProgressChangedToken(XPackageInstallationMonitorHandle handle, Unity.XGamingRuntime.Interop.XPackageInstallationProgressCallback callback, IntPtr context)
	{
		interop = new Unity.XGamingRuntime.Interop.XPackageRegisterInstallationProgressChangedToken(handle, callback, context);
	}

	public bool Unregister(XPackageInstallationMonitorHandle installationMonitor, bool wait)
	{
		return interop.Unregister(installationMonitor, wait);
	}

	public void Dispose()
	{
		interop.Dispose();
	}
}
