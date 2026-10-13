using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime;

[MovedFrom("Unity.GameCore")]
public class XblMultiplayerSessionNumberAttribute
{
	public string Name { get; }

	public double Value { get; }

	public XblMultiplayerSessionNumberAttribute(string name, double value)
	{
		Name = name;
		Value = value;
	}

	internal XblMultiplayerSessionNumberAttribute(Unity.XGamingRuntime.Interop.XblMultiplayerSessionNumberAttribute interopStruct)
	{
		Name = interopStruct.GetName();
		Value = interopStruct.value;
	}
}
