using System;
using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop;

[UnmanagedFunctionPointer(CallingConvention.StdCall)]
internal delegate void XGameInviteEventCallback(IntPtr context, [MarshalAs(UnmanagedType.LPStr)] string inviteUri);
