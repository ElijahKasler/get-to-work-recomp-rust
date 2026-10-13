using System;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime;

[MovedFrom("Unity.GameCore")]
[Obsolete("XRegistrationToken has been removed. If you are upgrading from a legacy package, please refer to the migration guide.", true)]
public class XRegistrationToken
{
}
public abstract class XRegistrationToken<T> : CallbackWrapper<T> where T : Delegate
{
	public ulong Token;

	public bool IsValid => Token != 0;

	protected XRegistrationToken(T callback, IntPtr context, T staticCallback)
		: base(callback, context, staticCallback)
	{
	}

	protected override void Dispose(bool disposing)
	{
		if (Token != 0L)
		{
			DisposeInternal(disposing);
			Token = 0uL;
		}
		base.Dispose(disposing);
	}

	protected abstract void DisposeInternal(bool disposing);
}
