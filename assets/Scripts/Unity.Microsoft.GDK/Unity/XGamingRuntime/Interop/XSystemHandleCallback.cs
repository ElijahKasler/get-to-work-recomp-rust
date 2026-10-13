using System;

namespace Unity.XGamingRuntime.Interop;

internal delegate void XSystemHandleCallback(IntPtr handle, XSystemHandleType type, XSystemHandleCallbackReason reason, IntPtr context);
