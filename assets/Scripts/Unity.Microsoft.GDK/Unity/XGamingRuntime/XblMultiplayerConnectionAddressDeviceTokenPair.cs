using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime;

[MovedFrom("Unity.GameCore")]
public class XblMultiplayerConnectionAddressDeviceTokenPair
{
	public string ConnectionAddress { get; }

	public XblDeviceToken DeviceToken { get; }

	internal XblMultiplayerConnectionAddressDeviceTokenPair(Unity.XGamingRuntime.Interop.XblMultiplayerConnectionAddressDeviceTokenPair interopStruct)
	{
		ConnectionAddress = interopStruct.connectionAddress.GetString();
		DeviceToken = new XblDeviceToken(interopStruct.deviceToken);
	}
}
