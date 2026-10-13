using System;
using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop;

[UnmanagedFunctionPointer(CallingConvention.StdCall)]
internal delegate void XUserDefaultAudioEndpointUtf16ChangedCallback(IntPtr context, XUserLocalId user, XUserDefaultAudioEndpointKind defaultAudioEndpointKind, [MarshalAs(UnmanagedType.LPWStr)] string endpointIdUtf16);
