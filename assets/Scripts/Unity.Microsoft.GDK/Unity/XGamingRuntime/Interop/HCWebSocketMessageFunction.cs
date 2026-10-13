using System;
using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop;

[UnmanagedFunctionPointer(CallingConvention.StdCall)]
internal delegate void HCWebSocketMessageFunction(IntPtr websocket, IntPtr incomingBodyString, IntPtr functionContext);
