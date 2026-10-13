using System;
using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop;

[UnmanagedFunctionPointer(CallingConvention.StdCall)]
internal delegate void XGameProtocolActivationCallback(IntPtr context, [MarshalAs(UnmanagedType.LPStr)] string protocolUri);
