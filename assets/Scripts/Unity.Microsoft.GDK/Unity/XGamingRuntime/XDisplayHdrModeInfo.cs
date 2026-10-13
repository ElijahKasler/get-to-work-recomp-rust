using System;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime;

[MovedFrom("Unity.GameCore")]
public class XDisplayHdrModeInfo
{
	internal Unity.XGamingRuntime.Interop.XDisplayHdrModeInfo interop;

	public float MinToneMapLuminance
	{
		get
		{
			return interop.minToneMapLuminance;
		}
		set
		{
			interop.minToneMapLuminance = value;
		}
	}

	public float MaxToneMapLuminance
	{
		get
		{
			return interop.maxToneMapLuminance;
		}
		set
		{
			interop.maxToneMapLuminance = value;
		}
	}

	public float MaxFullFrameToneMapLuminance
	{
		get
		{
			return interop.maxFullFrameToneMapLuminance;
		}
		set
		{
			interop.maxFullFrameToneMapLuminance = value;
		}
	}

	[Obsolete("Please use MinToneMapLuminance instead, (UnityUpgradable) -> MinToneMapLuminance", true)]
	public float minToneMapLuminance
	{
		get
		{
			return interop.minToneMapLuminance;
		}
		set
		{
			interop.minToneMapLuminance = value;
		}
	}

	[Obsolete("Please use MaxToneMapLuminance instead, (UnityUpgradable) -> MaxToneMapLuminance", true)]
	public float maxToneMapLuminance
	{
		get
		{
			return interop.maxToneMapLuminance;
		}
		set
		{
			interop.maxToneMapLuminance = value;
		}
	}

	[Obsolete("Please use MaxFullFrameToneMapLuminance instead, (UnityUpgradable) -> MaxFullFrameToneMapLuminance", true)]
	public float maxFullFrameToneMapLuminance
	{
		get
		{
			return interop.maxFullFrameToneMapLuminance;
		}
		set
		{
			interop.maxFullFrameToneMapLuminance = value;
		}
	}

	internal XDisplayHdrModeInfo(Unity.XGamingRuntime.Interop.XDisplayHdrModeInfo interop)
	{
		this.interop = interop;
	}

	public XDisplayHdrModeInfo()
	{
		interop = default;
	}
}
