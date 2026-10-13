using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime;

[MovedFrom("Unity.GameCore")]
public class XblMultiplayerPerformQoSMeasurementsArgs
{
	public XblMultiplayerConnectionAddressDeviceTokenPair[] RemoteClients { get; }

	internal XblMultiplayerPerformQoSMeasurementsArgs(Unity.XGamingRuntime.Interop.XblMultiplayerPerformQoSMeasurementsArgs interopStruct)
	{
		RemoteClients = interopStruct.GetRemoteClients((Unity.XGamingRuntime.Interop.XblMultiplayerConnectionAddressDeviceTokenPair x) => new XblMultiplayerConnectionAddressDeviceTokenPair(x));
	}
}
