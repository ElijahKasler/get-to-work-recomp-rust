using Unity.XGamingRuntime.Interop;

namespace Unity.XGamingRuntime;

public class XUserGetTokenAndSignatureData
{
	internal Unity.XGamingRuntime.Interop.XUserGetTokenAndSignatureData interop;

	public ulong TokenSize
	{
		get
		{
			return interop.tokenSize;
		}
		set
		{
			interop.tokenSize = value;
		}
	}

	public ulong SignatureSize
	{
		get
		{
			return interop.signatureSize;
		}
		set
		{
			interop.signatureSize = value;
		}
	}

	public string Token
	{
		get
		{
			return interop.token;
		}
		set
		{
			interop.token = value;
		}
	}

	public string Signature
	{
		get
		{
			return interop.signature;
		}
		set
		{
			interop.signature = value;
		}
	}

	internal XUserGetTokenAndSignatureData(Unity.XGamingRuntime.Interop.XUserGetTokenAndSignatureData interop)
	{
		this.interop = interop;
	}

	public XUserGetTokenAndSignatureData()
	{
		interop = default;
	}
}
