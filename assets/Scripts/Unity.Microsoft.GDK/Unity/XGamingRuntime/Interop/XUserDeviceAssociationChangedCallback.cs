using System;
using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop;

[UnmanagedFunctionPointer(CallingConvention.StdCall)]
internal delegate void XUserDeviceAssociationChangedCallback(IntPtr context, ref XUserDeviceAssociationChange change);
