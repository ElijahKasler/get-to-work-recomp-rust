using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime;

[MovedFrom("Unity.GameCore")]
public class XblMultiplayerSessionReferenceUri
{
	public string Value { get; }

	internal XblMultiplayerSessionReferenceUri(Unity.XGamingRuntime.Interop.XblMultiplayerSessionReferenceUri interopStruct)
	{
		Value = interopStruct.GetValue();
	}
}
