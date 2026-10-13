namespace System.Runtime.Serialization.Formatters.Soap;

internal enum RemMessageType
{
	MethodCall = 0,
	MethodResponse = 1,
	ServerFault = 2,
	NotRecognize = 3
}
