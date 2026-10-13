using Unity.XGamingRuntime.Interop;

namespace Unity.XGamingRuntime;

public class XUserDeviceAssociationChange
{
	internal APP_LOCAL_DEVICE_ID _deviceId;

	internal XUserLocalId _oldUser;

	internal XUserLocalId _newUser;

	public APP_LOCAL_DEVICE_ID DeviceId
	{
		get
		{
			return _deviceId;
		}
		set
		{
			_deviceId = value;
		}
	}

	public XUserLocalId OldUser
	{
		get
		{
			return _oldUser;
		}
		set
		{
			_oldUser = value;
		}
	}

	public XUserLocalId NewUser
	{
		get
		{
			return _newUser;
		}
		set
		{
			_newUser = value;
		}
	}

	internal XUserDeviceAssociationChange(Unity.XGamingRuntime.Interop.XUserDeviceAssociationChange interop)
	{
		_deviceId = new APP_LOCAL_DEVICE_ID(interop.deviceId);
		_oldUser = new XUserLocalId(interop.oldUser);
		_newUser = new XUserLocalId(interop.newUser);
	}

	public XUserDeviceAssociationChange()
	{
		_oldUser = new XUserLocalId();
		_newUser = new XUserLocalId();
		_deviceId = new APP_LOCAL_DEVICE_ID();
	}
}
