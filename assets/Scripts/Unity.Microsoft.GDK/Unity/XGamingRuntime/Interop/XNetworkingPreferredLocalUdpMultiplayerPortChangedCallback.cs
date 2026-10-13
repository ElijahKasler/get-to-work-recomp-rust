using System;
using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop;

[UnmanagedFunctionPointer(CallingConvention.StdCall)]
internal delegate void XNetworkingPreferredLocalUdpMultiplayerPortChangedCallback(IntPtr context, ushort preferredLocalUdpMultiplayerPort);
