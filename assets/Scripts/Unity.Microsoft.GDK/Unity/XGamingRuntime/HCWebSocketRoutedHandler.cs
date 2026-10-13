namespace Unity.XGamingRuntime;

public delegate void HCWebSocketRoutedHandler(HCWebsocketHandle websocket, bool receiving, string message, byte[] payloadBytes);
