using System;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime;

[MovedFrom("Unity.GameCore")]
public class XUserLocalId
{
	internal Unity.XGamingRuntime.Interop.XUserLocalId interop;

	public ulong Value
	{
		get
		{
			return interop.value;
		}
		set
		{
			interop.value = value;
		}
	}

	[Obsolete("Please use Value instead, (UnityUpgradable) -> Value", true)]
	public ulong value
	{
		get
		{
			return interop.value;
		}
		set
		{
			interop.value = value;
		}
	}

	internal XUserLocalId(Unity.XGamingRuntime.Interop.XUserLocalId interop)
	{
		this.interop = interop;
	}

	public XUserLocalId()
	{
		interop = default;
	}
}
