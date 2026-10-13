using System;
using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop;

[UnmanagedFunctionPointer(CallingConvention.StdCall)]
internal delegate void XGameStreamingConnectionStateChangedCallback(IntPtr context, XGameStreamingClientId client, XGameStreamingConnectionState state);
