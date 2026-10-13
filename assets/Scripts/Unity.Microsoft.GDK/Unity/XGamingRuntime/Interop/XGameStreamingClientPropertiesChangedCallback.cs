using System;
using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop;

[UnmanagedFunctionPointer(CallingConvention.StdCall)]
internal delegate void XGameStreamingClientPropertiesChangedCallback(IntPtr context, XGameStreamingClientId client, uint updatedPropertiesCount, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] XGameStreamingClientProperty[] updatedProperties);
