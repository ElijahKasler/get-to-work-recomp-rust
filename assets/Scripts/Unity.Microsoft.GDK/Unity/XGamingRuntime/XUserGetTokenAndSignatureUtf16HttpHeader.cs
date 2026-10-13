using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime;

[MovedFrom("Unity.GameCore")]
public class XUserGetTokenAndSignatureUtf16HttpHeader
{
	internal Unity.XGamingRuntime.Interop.XUserGetTokenAndSignatureUtf16HttpHeader interop;

	public string Name
	{
		get
		{
			return interop.name;
		}
		set
		{
			interop.name = value;
		}
	}

	public string Value
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

	internal XUserGetTokenAndSignatureUtf16HttpHeader(Unity.XGamingRuntime.Interop.XUserGetTokenAndSignatureUtf16HttpHeader interop)
	{
		this.interop = interop;
	}

	public XUserGetTokenAndSignatureUtf16HttpHeader()
	{
		interop = default;
	}
}
