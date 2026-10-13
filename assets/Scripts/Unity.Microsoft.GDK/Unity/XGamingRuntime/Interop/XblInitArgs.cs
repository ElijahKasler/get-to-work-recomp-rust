using System;

namespace Unity.XGamingRuntime.Interop;

internal struct XblInitArgs
{
	public XTaskQueueHandle queue;

	public IntPtr scid;
}
