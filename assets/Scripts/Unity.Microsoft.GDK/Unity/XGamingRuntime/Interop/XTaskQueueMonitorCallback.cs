using System;

namespace Unity.XGamingRuntime.Interop;

internal delegate void XTaskQueueMonitorCallback(IntPtr context, IntPtr queue, XTaskQueuePort port);
