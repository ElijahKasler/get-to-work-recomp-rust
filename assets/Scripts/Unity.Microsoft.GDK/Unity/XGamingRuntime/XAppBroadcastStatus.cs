using System;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime;

[MovedFrom("Unity.GameCore")]
public class XAppBroadcastStatus
{
	internal Unity.XGamingRuntime.Interop.XAppBroadcastStatus interop;

	public bool CanStartBroadcast
	{
		get
		{
			return interop.canStartBroadcast;
		}
		set
		{
			interop.canStartBroadcast = value;
		}
	}

	public bool IsAnyAppBroadcasting
	{
		get
		{
			return interop.isAnyAppBroadcasting;
		}
		set
		{
			interop.isAnyAppBroadcasting = value;
		}
	}

	public bool IsCaptureResourceUnavailable
	{
		get
		{
			return interop.isCaptureResourceUnavailable;
		}
		set
		{
			interop.isCaptureResourceUnavailable = value;
		}
	}

	public bool IsGameStreamInProgress
	{
		get
		{
			return interop.isGameStreamInProgress;
		}
		set
		{
			interop.isGameStreamInProgress = value;
		}
	}

	public bool IsGpuConstrained
	{
		get
		{
			return interop.isGpuConstrained;
		}
		set
		{
			interop.isGpuConstrained = value;
		}
	}

	public bool IsAppInactive
	{
		get
		{
			return interop.isAppInactive;
		}
		set
		{
			interop.isAppInactive = value;
		}
	}

	public bool IsBlockedForApp
	{
		get
		{
			return interop.isBlockedForApp;
		}
		set
		{
			interop.isBlockedForApp = value;
		}
	}

	public bool IsDisabledByUser
	{
		get
		{
			return interop.isDisabledByUser;
		}
		set
		{
			interop.isDisabledByUser = value;
		}
	}

	public bool IsDisabledBySystem
	{
		get
		{
			return interop.isDisabledBySystem;
		}
		set
		{
			interop.isDisabledBySystem = value;
		}
	}

	[Obsolete("Please use CanStartBroadcast instead, (UnityUpgradable) -> CanStartBroadcast", true)]
	public bool canStartBroadcast
	{
		get
		{
			return interop.canStartBroadcast;
		}
		set
		{
			interop.canStartBroadcast = value;
		}
	}

	[Obsolete("Please use IsAnyAppBroadcasting instead, (UnityUpgradable) -> IsAnyAppBroadcasting", true)]
	public bool isAnyAppBroadcasting
	{
		get
		{
			return interop.isAnyAppBroadcasting;
		}
		set
		{
			interop.isAnyAppBroadcasting = value;
		}
	}

	[Obsolete("Please use IsCaptureResourceUnavailable instead, (UnityUpgradable) -> IsCaptureResourceUnavailable", true)]
	public bool isCaptureResourceUnavailable
	{
		get
		{
			return interop.isCaptureResourceUnavailable;
		}
		set
		{
			interop.isCaptureResourceUnavailable = value;
		}
	}

	[Obsolete("Please use IsGameStreamInProgress instead, (UnityUpgradable) -> IsGameStreamInProgress", true)]
	public bool isGameStreamInProgress
	{
		get
		{
			return interop.isGameStreamInProgress;
		}
		set
		{
			interop.isGameStreamInProgress = value;
		}
	}

	[Obsolete("Please use IsGpuConstrained instead, (UnityUpgradable) -> IsGpuConstrained", true)]
	public bool isGpuConstrained
	{
		get
		{
			return interop.isGpuConstrained;
		}
		set
		{
			interop.isGpuConstrained = value;
		}
	}

	[Obsolete("Please use IsAppInactive instead, (UnityUpgradable) -> IsAppInactive", true)]
	public bool isAppInactive
	{
		get
		{
			return interop.isAppInactive;
		}
		set
		{
			interop.isAppInactive = value;
		}
	}

	[Obsolete("Please use IsBlockedForApp instead, (UnityUpgradable) -> IsBlockedForApp", true)]
	public bool isBlockedForApp
	{
		get
		{
			return interop.isBlockedForApp;
		}
		set
		{
			interop.isBlockedForApp = value;
		}
	}

	[Obsolete("Please use IsDisabledByUser instead, (UnityUpgradable) -> IsDisabledByUser", true)]
	public bool isDisabledByUser
	{
		get
		{
			return interop.isDisabledByUser;
		}
		set
		{
			interop.isDisabledByUser = value;
		}
	}

	[Obsolete("Please use IsDisabledBySystem instead, (UnityUpgradable) -> IsDisabledBySystem", true)]
	public bool isDisabledBySystem
	{
		get
		{
			return interop.isDisabledBySystem;
		}
		set
		{
			interop.isDisabledBySystem = value;
		}
	}

	internal XAppBroadcastStatus(Unity.XGamingRuntime.Interop.XAppBroadcastStatus interop)
	{
		this.interop = interop;
	}

	public XAppBroadcastStatus()
	{
		interop = default;
	}
}
