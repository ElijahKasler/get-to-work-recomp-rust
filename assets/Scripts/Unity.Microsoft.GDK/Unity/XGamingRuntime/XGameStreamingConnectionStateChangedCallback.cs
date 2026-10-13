using System;

namespace Unity.XGamingRuntime;

public delegate void XGameStreamingConnectionStateChangedCallback(IntPtr context, XGameStreamingClientId client, XGameStreamingConnectionState state);
