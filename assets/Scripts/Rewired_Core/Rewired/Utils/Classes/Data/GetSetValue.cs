using System;
using Rewired.Utils.Interfaces;

namespace Rewired.Utils.Classes.Data;

[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
[CustomObfuscation(rename = false)]
internal sealed class GetSetValue<T> : IGetSetValue<T>, IGetValue<T>, ISetValue<T>
{
	private Func<T> LutWrEQZdUSdoAjqWckzNJpDpzmb;

	private Action<T> AkZDeHEnVBqtOXdBhkdFuzrizdynA;

	public Func<T> getValueDelegate
	{
		get
		{
			return LutWrEQZdUSdoAjqWckzNJpDpzmb;
		}
		set
		{
			LutWrEQZdUSdoAjqWckzNJpDpzmb = value;
		}
	}

	public Action<T> setValueDelegate
	{
		get
		{
			return AkZDeHEnVBqtOXdBhkdFuzrizdynA;
		}
		set
		{
			AkZDeHEnVBqtOXdBhkdFuzrizdynA = value;
		}
	}

	public GetSetValue(Func<T> P_0, Action<T> P_1)
	{
		LutWrEQZdUSdoAjqWckzNJpDpzmb = P_0;
		AkZDeHEnVBqtOXdBhkdFuzrizdynA = P_1;
	}

	public T GetValue()
	{
		if (LutWrEQZdUSdoAjqWckzNJpDpzmb == null)
		{
			throw new ArgumentNullException("getValueDelegate");
		}
		return LutWrEQZdUSdoAjqWckzNJpDpzmb();
	}

	T IGetValue<T>.GetValue()
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetValue
		return this.GetValue();
	}

	public void SetValue(T value)
	{
		if (AkZDeHEnVBqtOXdBhkdFuzrizdynA == null)
		{
			throw new ArgumentNullException("setValueDelegate");
		}
		AkZDeHEnVBqtOXdBhkdFuzrizdynA(value);
	}

	void ISetValue<T>.SetValue(T value)
	{
		//ILSpy generated this explicit interface implementation from .override directive in SetValue
		this.SetValue(value);
	}
}
