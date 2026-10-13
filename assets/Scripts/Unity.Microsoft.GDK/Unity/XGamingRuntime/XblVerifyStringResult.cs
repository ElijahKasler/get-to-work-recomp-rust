using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime;

[MovedFrom("Unity.GameCore")]
public class XblVerifyStringResult
{
	public XblVerifyStringResultCode ResultCode { get; private set; }

	public string FirstOffendingSubstring { get; private set; }

	internal XblVerifyStringResult(Unity.XGamingRuntime.Interop.XblVerifyStringResult interopStruct)
	{
		ResultCode = interopStruct.resultCode;
		FirstOffendingSubstring = interopStruct.firstOffendingSubstring.GetString();
	}
}
