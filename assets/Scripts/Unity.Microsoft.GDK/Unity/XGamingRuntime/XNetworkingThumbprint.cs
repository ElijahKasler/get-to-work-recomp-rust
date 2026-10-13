using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime;

[MovedFrom("Unity.GameCore")]
public class XNetworkingThumbprint
{
	public XNetworkingThumbprintType ThumbprintType { get; set; }

	public byte[] ThumbprintBuffer { get; set; }
}
