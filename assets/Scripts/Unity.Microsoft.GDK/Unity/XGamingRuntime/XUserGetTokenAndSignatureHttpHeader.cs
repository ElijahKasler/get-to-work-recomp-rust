using Unity.XGamingRuntime.Interop;

namespace Unity.XGamingRuntime;

public class XUserGetTokenAndSignatureHttpHeader
{
	internal Unity.XGamingRuntime.Interop.XUserGetTokenAndSignatureHttpHeader interop;

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

	internal XUserGetTokenAndSignatureHttpHeader(Unity.XGamingRuntime.Interop.XUserGetTokenAndSignatureHttpHeader interop)
	{
		this.interop = interop;
	}

	public XUserGetTokenAndSignatureHttpHeader()
	{
		interop = default;
	}
}
