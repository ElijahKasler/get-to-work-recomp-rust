namespace Unity.XGamingRuntime.Interop;

internal struct XUserDeviceAssociationChange
{
	internal APP_LOCAL_DEVICE_ID deviceId;

	internal XUserLocalId oldUser;

	internal XUserLocalId newUser;
}
