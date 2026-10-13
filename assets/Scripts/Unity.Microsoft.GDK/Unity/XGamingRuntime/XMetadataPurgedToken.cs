using System;
using Unity.XGamingRuntime.Interop;

namespace Unity.XGamingRuntime;

public class XMetadataPurgedToken
{
	internal Unity.XGamingRuntime.Interop.XMetadataPurgedToken interop { get; private set; }

	public bool IsValid => interop.IsValid;

	public ulong Token
	{
		get
		{
			return interop.Token;
		}
		set
		{
			interop.Token = value;
		}
	}

	internal XMetadataPurgedToken(Unity.XGamingRuntime.Interop.XAppCaptureMetadataPurgedCallback callback, IntPtr context)
	{
		interop = new Unity.XGamingRuntime.Interop.XMetadataPurgedToken(callback, context);
	}

	public bool Unregister(bool wait)
	{
		return interop.Unregister(wait);
	}
}
