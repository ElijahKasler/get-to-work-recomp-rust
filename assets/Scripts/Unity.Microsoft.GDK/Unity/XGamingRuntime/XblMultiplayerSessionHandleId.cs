using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime;

[MovedFrom("Unity.GameCore")]
public class XblMultiplayerSessionHandleId
{
	public string Value { get; }

	internal XblMultiplayerSessionHandleId(Unity.XGamingRuntime.Interop.XblMultiplayerSessionHandleId interopHandle)
	{
		Value = interopHandle.GetValue();
	}
}
