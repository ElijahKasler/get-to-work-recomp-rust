using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime;

[MovedFrom("Unity.GameCore")]
public class XNetworkingConnectivityHint
{
	internal Unity.XGamingRuntime.Interop.XNetworkingConnectivityHint data;

	public XNetworkingConnectivityLevelHint ConnectivityLevel
	{
		get
		{
			return data.connectivityLevel;
		}
		set
		{
			data.connectivityLevel = value;
		}
	}

	public XNetworkingConnectivityCostHint ConnectivityCost
	{
		get
		{
			return data.connectivityCost;
		}
		set
		{
			data.connectivityCost = value;
		}
	}

	public uint IanaInterfaceType
	{
		get
		{
			return data.ianaInterfaceType;
		}
		set
		{
			data.ianaInterfaceType = value;
		}
	}

	public bool NetworkInitialized
	{
		get
		{
			return data.networkInitialized;
		}
		set
		{
			data.networkInitialized = value;
		}
	}

	public bool ApproachingDataLimit
	{
		get
		{
			return data.approachingDataLimit;
		}
		set
		{
			data.approachingDataLimit = value;
		}
	}

	public bool OverDataLimit
	{
		get
		{
			return data.overDataLimit;
		}
		set
		{
			data.overDataLimit = value;
		}
	}

	public bool Roaming
	{
		get
		{
			return data.roaming;
		}
		set
		{
			data.roaming = value;
		}
	}

	internal XNetworkingConnectivityHint(Unity.XGamingRuntime.Interop.XNetworkingConnectivityHint interop)
	{
		data = interop;
	}

	public XNetworkingConnectivityHint()
	{
		data = default;
	}
}
