using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime;

[MovedFrom("Unity.GameCore")]
public class XblGuid
{
	public string Value { get; }

	internal XblGuid(Unity.XGamingRuntime.Interop.XblGuid interopStruct)
	{
		Value = interopStruct.GetValue();
	}
}
