using System;

namespace Unity.XGamingRuntime.Interop;

internal struct XAsyncProviderData
{
	internal IntPtr async;

	internal ulong bufferSize;

	internal IntPtr buffer;

	internal IntPtr context;
}
