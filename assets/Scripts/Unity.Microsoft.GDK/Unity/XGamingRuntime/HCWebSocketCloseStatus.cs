using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime;

[MovedFrom("Unity.GameCore")]
public enum HCWebSocketCloseStatus : uint
{
	Normal = 1000u,
	GoingAway = 1001u,
	ProtocolError = 1002u,
	Unsupported = 1003u,
	EmptyStatus = 1005u,
	AbnormalClose = 1006u,
	InconsistentDatatype = 1007u,
	PolicyViolation = 1008u,
	TooLarge = 1009u,
	NegotiateError = 1010u,
	ServerTerminate = 1011u,
	HandshakeError = 1015u,
	UnknownError = 4000u,
	ErrorWinhttpTimeout = 12002u
}
