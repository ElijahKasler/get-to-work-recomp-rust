using System;

namespace Unity.XGamingRuntime;

public delegate void XGameStreamingClientPropertiesChangedCallback(IntPtr context, XGameStreamingClientId client, XGameStreamingClientProperty[] updatedProperties);
