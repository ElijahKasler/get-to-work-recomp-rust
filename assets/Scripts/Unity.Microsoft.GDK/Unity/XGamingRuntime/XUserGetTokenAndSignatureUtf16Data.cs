using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime;

[MovedFrom("Unity.GameCore")]
public class XUserGetTokenAndSignatureUtf16Data
{
	internal Unity.XGamingRuntime.Interop.XUserGetTokenAndSignatureUtf16Data interop;

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

	internal XUserGetTokenAndSignatureUtf16Data(Unity.XGamingRuntime.Interop.XUserGetTokenAndSignatureUtf16Data interop)
	{
		this.interop = interop;
	}

	public XUserGetTokenAndSignatureUtf16Data()
	{
		interop = default;
	}
}
