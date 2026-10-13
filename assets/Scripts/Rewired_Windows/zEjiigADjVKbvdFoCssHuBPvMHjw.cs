using System;
using System.Runtime.CompilerServices;
using System.Threading;

internal abstract class zEjiigADjVKbvdFoCssHuBPvMHjw : IDisposable
{
	private EventHandler<EventArgs> fpkBNjdUbHmqEUcuaZSIuYQBHhDb__BackingField;

	private EventHandler<EventArgs> cokrOpaELkrNORVCeNLthuUqCyTs__BackingField;

	[CompilerGenerated]
	private bool ItbaEuNlvETkUZJBmcLnKdYVgpdW;

	public bool vlkHwBCGgCElKrPRtwyQMgPGxdiE
	{
		get
		{
			return iRNdPjkrrGoPUgeJcaTOuTnuEnUW();
		}
		private set
		{
			nuHgNvgcVXUDJDYrbpGVQHAZzIbiA(flag);
		}
	}

	public event EventHandler<EventArgs> fpkBNjdUbHmqEUcuaZSIuYQBHhDb
	{
		add
		{
			LKpvHxdkdbQJPMgvSjfXQzYDlxHF(eventHandler);
		}
		remove
		{
			jnaUfmCgBoRsbhfPmIfEyQGCDrqBA(eventHandler);
		}
	}

	public event EventHandler<EventArgs> cokrOpaELkrNORVCeNLthuUqCyTs
	{
		add
		{
			sHfAzDcdADgUvQRJLgejQDkzNnyFA(eventHandler);
		}
		remove
		{
			SraanodFtYMapcygPtGZUzXNytvqA(eventHandler);
		}
	}

	public void LKpvHxdkdbQJPMgvSjfXQzYDlxHF(EventHandler<EventArgs> P_0)
	{
		EventHandler<EventArgs> eventHandler = fpkBNjdUbHmqEUcuaZSIuYQBHhDb__BackingField;
		EventHandler<EventArgs> eventHandler2;
		do
		{
			eventHandler2 = eventHandler;
			EventHandler<EventArgs> value = (EventHandler<EventArgs>)Delegate.Combine(eventHandler2, P_0);
			eventHandler = Interlocked.CompareExchange(ref fpkBNjdUbHmqEUcuaZSIuYQBHhDb__BackingField, value, eventHandler2);
		}
		while ((object)eventHandler != eventHandler2);
	}

	public void jnaUfmCgBoRsbhfPmIfEyQGCDrqBA(EventHandler<EventArgs> P_0)
	{
		EventHandler<EventArgs> eventHandler = fpkBNjdUbHmqEUcuaZSIuYQBHhDb__BackingField;
		EventHandler<EventArgs> eventHandler2;
		do
		{
			eventHandler2 = eventHandler;
			EventHandler<EventArgs> value = (EventHandler<EventArgs>)Delegate.Remove(eventHandler2, P_0);
			eventHandler = Interlocked.CompareExchange(ref fpkBNjdUbHmqEUcuaZSIuYQBHhDb__BackingField, value, eventHandler2);
		}
		while ((object)eventHandler != eventHandler2);
	}

	public void sHfAzDcdADgUvQRJLgejQDkzNnyFA(EventHandler<EventArgs> P_0)
	{
		EventHandler<EventArgs> eventHandler = cokrOpaELkrNORVCeNLthuUqCyTs__BackingField;
		EventHandler<EventArgs> eventHandler2;
		do
		{
			eventHandler2 = eventHandler;
			EventHandler<EventArgs> value = (EventHandler<EventArgs>)Delegate.Combine(eventHandler2, P_0);
			eventHandler = Interlocked.CompareExchange(ref cokrOpaELkrNORVCeNLthuUqCyTs__BackingField, value, eventHandler2);
		}
		while ((object)eventHandler != eventHandler2);
	}

	public void SraanodFtYMapcygPtGZUzXNytvqA(EventHandler<EventArgs> P_0)
	{
		EventHandler<EventArgs> eventHandler = cokrOpaELkrNORVCeNLthuUqCyTs__BackingField;
		EventHandler<EventArgs> eventHandler2;
		do
		{
			eventHandler2 = eventHandler;
			EventHandler<EventArgs> value = (EventHandler<EventArgs>)Delegate.Remove(eventHandler2, P_0);
			eventHandler = Interlocked.CompareExchange(ref cokrOpaELkrNORVCeNLthuUqCyTs__BackingField, value, eventHandler2);
		}
		while ((object)eventHandler != eventHandler2);
	}

	protected virtual void bFMpyKAqGJUvspelhCGmeqEPWUFp()
	{
		try
		{
			KmnYsvkTRNWMDHCNPtpodNgmrECu(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	public bool iRNdPjkrrGoPUgeJcaTOuTnuEnUW()
	{
		return ItbaEuNlvETkUZJBmcLnKdYVgpdW;
	}

	private void nuHgNvgcVXUDJDYrbpGVQHAZzIbiA(bool P_0)
	{
		ItbaEuNlvETkUZJBmcLnKdYVgpdW = P_0;
	}

	public void Dispose()
	{
		KmnYsvkTRNWMDHCNPtpodNgmrECu(true);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	private void KmnYsvkTRNWMDHCNPtpodNgmrECu(bool P_0)
	{
		if (!iRNdPjkrrGoPUgeJcaTOuTnuEnUW())
		{
			fpkBNjdUbHmqEUcuaZSIuYQBHhDb__BackingField?.Invoke(this, EventArgs.Empty);
			ZdREfhQubUNnOlWJZcTpVwfbwkXF(P_0);
			GC.SuppressFinalize(this);
			nuHgNvgcVXUDJDYrbpGVQHAZzIbiA(true);
			cokrOpaELkrNORVCeNLthuUqCyTs__BackingField?.Invoke(this, EventArgs.Empty);
		}
	}

	protected abstract void ZdREfhQubUNnOlWJZcTpVwfbwkXF(bool P_0);
}
