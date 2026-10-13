using System;
using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop;

[UnmanagedFunctionPointer(CallingConvention.StdCall)]
internal delegate void XUserChangeEventCallback(IntPtr context, XUserLocalId userLocalId, XUserChangeEvent changeEvent);
