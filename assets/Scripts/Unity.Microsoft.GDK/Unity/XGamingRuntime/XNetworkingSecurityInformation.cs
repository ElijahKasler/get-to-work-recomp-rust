using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime;

[MovedFrom("Unity.GameCore")]
public class XNetworkingSecurityInformation
{
	public uint EnabledHttpSecurityProtocolFlags { get; set; }

	public XNetworkingThumbprint[] Thumbprints { get; set; }
}
