using System;

namespace Unity.XGamingRuntime.Interop;

internal struct WebSocketCompletionResult
{
	internal readonly IntPtr websocket;

	internal readonly int errorCode;

	internal readonly uint platformErrorCode;
}
