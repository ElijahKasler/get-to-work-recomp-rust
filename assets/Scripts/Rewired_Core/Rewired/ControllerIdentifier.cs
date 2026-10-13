using System;

namespace Rewired;

public struct ControllerIdentifier
{
	private int CkqkmljQeYwoECqCggrJEpKPaCKlA;

	private ControllerType PwGdYvvbDHFwPoBeXecsKNGwFXzp;

	private Guid tdhznxrtYFQkxibpEQXhphLZiTgr;

	private string uHIoiUVDrxPZGyQTGhwVexDboYtH;

	private Guid mpcyoioEcNBvxJozqFUvzKBpQogj;

	public int controllerId
	{
		get
		{
			return CkqkmljQeYwoECqCggrJEpKPaCKlA;
		}
		set
		{
			CkqkmljQeYwoECqCggrJEpKPaCKlA = value;
		}
	}

	public ControllerType controllerType
	{
		get
		{
			return PwGdYvvbDHFwPoBeXecsKNGwFXzp;
		}
		set
		{
			PwGdYvvbDHFwPoBeXecsKNGwFXzp = value;
		}
	}

	public Guid hardwareTypeGuid
	{
		get
		{
			return tdhznxrtYFQkxibpEQXhphLZiTgr;
		}
		set
		{
			tdhznxrtYFQkxibpEQXhphLZiTgr = value;
		}
	}

	public string hardwareIdentifier
	{
		get
		{
			return uHIoiUVDrxPZGyQTGhwVexDboYtH;
		}
		set
		{
			uHIoiUVDrxPZGyQTGhwVexDboYtH = value;
		}
	}

	public Guid deviceInstanceGuid
	{
		get
		{
			return mpcyoioEcNBvxJozqFUvzKBpQogj;
		}
		set
		{
			mpcyoioEcNBvxJozqFUvzKBpQogj = value;
		}
	}

	public static ControllerIdentifier Blank => new ControllerIdentifier
	{
		CkqkmljQeYwoECqCggrJEpKPaCKlA = -1
	};

	internal ControllerIdentifier(Controller P_0)
	{
		CkqkmljQeYwoECqCggrJEpKPaCKlA = P_0.id;
		PwGdYvvbDHFwPoBeXecsKNGwFXzp = P_0.type;
		tdhznxrtYFQkxibpEQXhphLZiTgr = P_0.TlKwqXsIXURetJtusBGjLpbJxFcf;
		uHIoiUVDrxPZGyQTGhwVexDboYtH = P_0.hardwareIdentifier;
		mpcyoioEcNBvxJozqFUvzKBpQogj = P_0.deviceInstanceGuid;
	}
}
