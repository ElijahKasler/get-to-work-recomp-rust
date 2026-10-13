using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop;

[UnmanagedFunctionPointer(CallingConvention.StdCall)]
internal delegate void HCTraceCallback(byte[] areaName, HCTraceLevel level, ulong threadId, ulong timestamp, byte[] message);
