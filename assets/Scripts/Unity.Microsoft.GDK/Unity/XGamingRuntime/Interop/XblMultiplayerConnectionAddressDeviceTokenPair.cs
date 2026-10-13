namespace Unity.XGamingRuntime.Interop;

internal struct XblMultiplayerConnectionAddressDeviceTokenPair
{
	internal readonly UTF8StringPtr connectionAddress;

	internal readonly XblDeviceToken deviceToken;

	internal XblMultiplayerConnectionAddressDeviceTokenPair(Unity.XGamingRuntime.XblMultiplayerConnectionAddressDeviceTokenPair publicObject, DisposableCollection disposableCollection)
	{
		connectionAddress = new UTF8StringPtr(publicObject.ConnectionAddress, disposableCollection);
		deviceToken = new XblDeviceToken(publicObject.DeviceToken);
	}
}
