using System;
using Rewired.Internal;
using Rewired.Internal.Glyphs;
using Rewired.Utils.Classes.Data;

internal sealed class VSVmHUODbXomiGNnnXuDkqxnRQPA : IPrefetch, IDisposable
{
	private Action ipjlgErPFdRSEnbuTeYWXOnyhQWT;

	private Id ADYDiFmTTPnCGjwuOkDSMENyvZnB;

	private bool lzEIgMfgIoKkQBcEyulSrxhKGiCg;

	public VSVmHUODbXomiGNnnXuDkqxnRQPA(Action P_0)
	{
		ipjlgErPFdRSEnbuTeYWXOnyhQWT = P_0;
		ADYDiFmTTPnCGjwuOkDSMENyvZnB = 0u;
		GlyphManager.Add(this, ref ADYDiFmTTPnCGjwuOkDSMENyvZnB);
	}

	void IPrefetch.Prefetch()
	{
		ipjlgErPFdRSEnbuTeYWXOnyhQWT();
	}

	private void spMJigDDFLdYJhvnoGMxawYbucEJB(bool P_0)
	{
		if (!lzEIgMfgIoKkQBcEyulSrxhKGiCg)
		{
			if (P_0)
			{
				GlyphManager.Remove(ref ADYDiFmTTPnCGjwuOkDSMENyvZnB);
			}
			lzEIgMfgIoKkQBcEyulSrxhKGiCg = true;
		}
	}

	public void Dispose()
	{
		spMJigDDFLdYJhvnoGMxawYbucEJB(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}
}
