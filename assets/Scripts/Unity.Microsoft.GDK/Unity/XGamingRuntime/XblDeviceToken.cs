using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime;

[MovedFrom("Unity.GameCore")]
public class XblDeviceToken
{
	public string Value { get; set; }

	internal XblDeviceToken(Unity.XGamingRuntime.Interop.XblDeviceToken interopStruct)
	{
		Value = interopStruct.GetValue();
	}
}
