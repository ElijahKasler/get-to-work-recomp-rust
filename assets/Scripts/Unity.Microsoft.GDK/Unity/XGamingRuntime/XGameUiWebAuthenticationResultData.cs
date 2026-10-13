using System;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime;

[MovedFrom("Unity.GameCore")]
public class XGameUiWebAuthenticationResultData
{
	internal Unity.XGamingRuntime.Interop.XGameUiWebAuthenticationResultData data;

	public uint ResponseStatus
	{
		get
		{
			return data.responseStatus;
		}
		set
		{
			data.responseStatus = value;
		}
	}

	public ulong ResponseCompletionUriSize
	{
		get
		{
			return data.responseCompletionUriSize;
		}
		set
		{
			data.responseCompletionUriSize = value;
		}
	}

	public string ResponseCompletionUri
	{
		get
		{
			return data.responseCompletionUri;
		}
		set
		{
			data.responseCompletionUri = value;
		}
	}

	[Obsolete("Please use ResponseStatus instead, (UnityUpgradable) -> ResponseStatus", true)]
	public uint responseStatus
	{
		get
		{
			return data.responseStatus;
		}
		set
		{
			data.responseStatus = value;
		}
	}

	[Obsolete("Please use ResponseCompletionUriSize instead, (UnityUpgradable) -> ResponseCompletionUriSize", true)]
	public ulong responseCompletionUriSize
	{
		get
		{
			return data.responseCompletionUriSize;
		}
		set
		{
			data.responseCompletionUriSize = value;
		}
	}

	[Obsolete("Please use ResponseCompletionUri instead, (UnityUpgradable) -> ResponseCompletionUri", true)]
	public string responseCompletionUri
	{
		get
		{
			return data.responseCompletionUri;
		}
		set
		{
			data.responseCompletionUri = value;
		}
	}

	internal XGameUiWebAuthenticationResultData(Unity.XGamingRuntime.Interop.XGameUiWebAuthenticationResultData interop)
	{
		data = interop;
	}

	public XGameUiWebAuthenticationResultData()
	{
		data = default;
	}
}
