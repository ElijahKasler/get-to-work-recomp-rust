using System;
using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop;

internal delegate void XTaskQueueCallback(IntPtr context, [MarshalAs(UnmanagedType.I1)] bool canceled);
