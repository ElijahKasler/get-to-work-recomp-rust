using System;

namespace Unity.XGamingRuntime;

public delegate bool XPackageChunkAvailabilityCallback(IntPtr context, XPackageChunkSelector selector, XPackageChunkAvailability availability);
