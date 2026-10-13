using System;
using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop;

[UnmanagedFunctionPointer(CallingConvention.StdCall)]
[return: MarshalAs(UnmanagedType.I1)]
internal delegate bool XPackageChunkAvailabilityCallback(IntPtr context, XPackageChunkSelectorInterop selector, XPackageChunkAvailability availability);
