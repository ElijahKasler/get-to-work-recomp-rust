using System;

namespace Unity.XGamingRuntime.Interop;

internal struct XblMultiplayerPerformQoSMeasurementsArgs
{
	private unsafe readonly XblMultiplayerConnectionAddressDeviceTokenPair* remoteClients = (XblMultiplayerConnectionAddressDeviceTokenPair*)(void*)Converters.ClassArrayToPtr(publicObject.RemoteClients, (Unity.XGamingRuntime.XblMultiplayerConnectionAddressDeviceTokenPair x, DisposableCollection dc) => new XblMultiplayerConnectionAddressDeviceTokenPair(x, dc), disposableCollection, out remoteClientsSize);

	internal readonly SizeT remoteClientsSize;

	internal unsafe T[] GetRemoteClients<T>(Func<XblMultiplayerConnectionAddressDeviceTokenPair, T> ctor)
	{
		return Converters.PtrToClassArray((IntPtr)remoteClients, remoteClientsSize, ctor);
	}

	internal unsafe XblMultiplayerPerformQoSMeasurementsArgs(Unity.XGamingRuntime.XblMultiplayerPerformQoSMeasurementsArgs publicObject, DisposableCollection disposableCollection)
	{
	}
}
