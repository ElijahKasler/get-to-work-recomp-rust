using System;
using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop;

[UnmanagedFunctionPointer(CallingConvention.StdCall)]
internal delegate void HCWebSocketRoutedHandler(IntPtr websocket, NativeBool receiving, [Optional] IntPtr message, [Optional] IntPtr payloadBytes, SizeT payloadSize, IntPtr conext);
