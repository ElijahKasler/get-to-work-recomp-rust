using System;
using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop;

[UnmanagedFunctionPointer(CallingConvention.StdCall)]
[return: MarshalAs(UnmanagedType.I1)]
internal delegate bool XErrorCallback(int hr, [MarshalAs(UnmanagedType.LPStr)] string msg, IntPtr context);
