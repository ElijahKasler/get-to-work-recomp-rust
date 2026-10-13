using System;

namespace Unity.XGamingRuntime;

public delegate void XSystemHandleCallback(IntPtr handle, XSystemHandleType type, XSystemHandleCallbackReason reason, IntPtr context);
