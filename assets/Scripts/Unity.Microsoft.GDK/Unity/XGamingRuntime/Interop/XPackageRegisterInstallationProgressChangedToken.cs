using System;
using System.Runtime.InteropServices;
using AOT;

namespace Unity.XGamingRuntime.Interop;

internal class XPackageRegisterInstallationProgressChangedToken : XRegistrationToken<XPackageInstallationProgressCallback>
{
	private XPackageInstallationMonitorHandle installationProgressChanged;

	[AOT.MonoPInvokeCallback(typeof(XPackageInstallationProgressCallback))]
	private static void OnInstallationProgress(IntPtr context, IntPtr monitor)
	{
		CallbackWrapper<XPackageInstallationProgressCallback> callbackWrapper = GCHandle.FromIntPtr(context).Target as CallbackWrapper<XPackageInstallationProgressCallback>;
		callbackWrapper.Callback(callbackWrapper.Context, monitor);
	}

	public XPackageRegisterInstallationProgressChangedToken(XPackageInstallationMonitorHandle installationProgressChanged, XPackageInstallationProgressCallback callback, IntPtr context)
		: base(callback, context, (XPackageInstallationProgressCallback)OnInstallationProgress)
	{
		this.installationProgressChanged = installationProgressChanged;
	}

	public bool Unregister(XPackageInstallationMonitorHandle installationProgressChanged, bool wait)
	{
		bool result = true;
		if (Token != 0L)
		{
			result = NativeMethods.XPackageUnregisterInstallationProgressChanged(installationProgressChanged.Handle, Token, wait);
			Token = 0uL;
		}
		return result;
	}

	public bool Unregister(bool wait)
	{
		return Unregister(installationProgressChanged, wait: true);
	}

	protected override void DisposeInternal(bool disposing)
	{
		Unregister(wait: true);
	}
}
