using System;
using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop;

[UnmanagedFunctionPointer(CallingConvention.StdCall)]
[return: MarshalAs(UnmanagedType.I1)]
internal delegate bool XGameSaveContainerInfoCallback(XGameSaveContainerInfo info, IntPtr context);
