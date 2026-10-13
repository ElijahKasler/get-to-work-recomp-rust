using System;
using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop;

[UnmanagedFunctionPointer(CallingConvention.StdCall)]
internal delegate void HCWebSocketBinaryMessageFunction(IntPtr websocket, IntPtr payloadBytes, uint payloadSize, IntPtr functionContext);
