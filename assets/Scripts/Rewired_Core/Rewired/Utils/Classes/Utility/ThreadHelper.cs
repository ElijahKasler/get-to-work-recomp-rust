using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;

namespace Rewired.Utils.Classes.Utility;

[CustomObfuscation(rename = false)]
[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
internal class ThreadHelper : IDisposable
{
	private const uint yhjqXvvdrpuglERbdLqZGbYFCfRl = 750u;

	private readonly Stopwatch aQBKawBwoHgJWfLafjZoNkBeIJcw;

	private Thread ctPOIZGfjcwvUeKjfDOBCewqzTwuA;

	private ManualResetEvent xRoYlnhSbJYpvyKaddDDXbkQifmC;

	private ManualResetEvent ZbiAycRFyJemRAxLEUFavtNFHlcq;

	private AutoResetEvent FKmhveeRKixbpNcpurGNJWAMpiwM;

	private bool KMPNqcxPcuXuMdoYuvcVmkFxfqVBA;

	private bool IPHUFYyMFDNSTKqfIleUzwIOkFSX;

	private int RcKBwAKubFHmvJUMzGItiPDJbzgIA;

	private bool RQjazDAvwLuPlJfIyMQWgamMXIzFA;

	private int VnnfQaflooYnIlwKJzfgWSkMZKbS;

	private long kVMnNernRxzdWkJkhwfNnMwzTEXt;

	private bool vidzdNzRgVBhZQONDHhCDHsWcxqg;

	private int HTDjGFTOhJHyagAWqxtSFZXfHqah;

	private long vcBnmsTcfsGDvMnHmLpSBifPGFMT;

	private uint zmnEqZtCHgUOEuCEBgetfBOkiYysA;

	private readonly object cOqnPYWgTvpLpqDgyNWYrOddrpLM;

	private Queue<Action> jevCGUYEOZBNkczBIfRxHWkgUWt;

	private Queue<Action> gRjzofZAVXSgHsPcehDnKGOPypqH;

	private bool QfohlWfxAjeFBYaLEIYSgIwGfzAXA;

	private Action hMgUwkHCjFsXNkfqxNKcJzhKdMaN;

	[CompilerGenerated]
	private Action gsfjXyDIbiOShzWnzRauTmYYfyNp;

	[CompilerGenerated]
	private Action ylNUFKFKYoflkaAjWuqEurKQMAlfb;

	private bool EOjwsNAILutegiObRlpMOrbgwpII;

	public bool isRunning => IPHUFYyMFDNSTKqfIleUzwIOkFSX;

	public bool isStopped
	{
		get
		{
			if (!IPHUFYyMFDNSTKqfIleUzwIOkFSX)
			{
				if (ctPOIZGfjcwvUeKjfDOBCewqzTwuA == null)
				{
					return true;
				}
				return !ctPOIZGfjcwvUeKjfDOBCewqzTwuA.IsAlive;
			}
			return false;
		}
	}

	public bool useHighPrecitionTimer
	{
		get
		{
			if (!RQjazDAvwLuPlJfIyMQWgamMXIzFA)
			{
				return (long)VnnfQaflooYnIlwKJzfgWSkMZKbS >= 750L;
			}
			return true;
		}
		set
		{
			if (value != RQjazDAvwLuPlJfIyMQWgamMXIzFA)
			{
				RQjazDAvwLuPlJfIyMQWgamMXIzFA = value;
				QzOSlxJqqImvvqOdXHefbhoLaaVKA();
			}
		}
	}

	public bool useFixedTimeStep => vidzdNzRgVBhZQONDHhCDHsWcxqg;

	public int fixedTimeStepFPS
	{
		get
		{
			return VnnfQaflooYnIlwKJzfgWSkMZKbS;
		}
		set
		{
			VnnfQaflooYnIlwKJzfgWSkMZKbS = ((value > 0) ? value : 0);
			QzOSlxJqqImvvqOdXHefbhoLaaVKA();
		}
	}

	public int timeoutMS
	{
		get
		{
			return HTDjGFTOhJHyagAWqxtSFZXfHqah;
		}
		set
		{
			HTDjGFTOhJHyagAWqxtSFZXfHqah = ((value > 0) ? value : 0);
			QzOSlxJqqImvvqOdXHefbhoLaaVKA();
		}
	}

	public uint tick => zmnEqZtCHgUOEuCEBgetfBOkiYysA;

	public event Action ThreadUpdateEvent
	{
		add
		{
			hMgUwkHCjFsXNkfqxNKcJzhKdMaN = (Action)Delegate.Combine(hMgUwkHCjFsXNkfqxNKcJzhKdMaN, value);
		}
		remove
		{
			hMgUwkHCjFsXNkfqxNKcJzhKdMaN = (Action)Delegate.Remove(hMgUwkHCjFsXNkfqxNKcJzhKdMaN, value);
		}
	}

	private event Action _ThreadStartedEvent
	{
		add
		{
			zaDeOaVEgrdVCCPDqtwlnxDuhwxp(action);
		}
		remove
		{
			NxnmKSpYKITLOAjHcUszTjBwghBHA(action);
		}
	}

	public event Action ThreadStartedEvent
	{
		add
		{
			zaDeOaVEgrdVCCPDqtwlnxDuhwxp(value);
		}
		remove
		{
			NxnmKSpYKITLOAjHcUszTjBwghBHA(value);
		}
	}

	private event Action _ThreadPreStopEvent
	{
		add
		{
			ASEYJvETCxhZOPBMbrjrPFPJfkKU(action);
		}
		remove
		{
			KXaJRQOHuMTXnjqpdpFNIopSCiGCA(action);
		}
	}

	public event Action ThreadPreStopEvent
	{
		add
		{
			ASEYJvETCxhZOPBMbrjrPFPJfkKU(value);
		}
		remove
		{
			KXaJRQOHuMTXnjqpdpFNIopSCiGCA(value);
		}
	}

	public static ThreadHelper Create(bool fixedTimeStep = false, int fixedTimeStepFPS = 100, bool useHighPrecisionTimer = false, int timeoutMS = 0)
	{
		if (fixedTimeStep)
		{
			return new ThreadHelper(fixedTimeStepFPS, useHighPrecisionTimer, timeoutMS);
		}
		return new ThreadHelper(timeoutMS);
	}

	public static ThreadHelper CreateFixedTimeStep(int timeStepFPS, int timeoutMS = 0)
	{
		return CreateFixedTimeStep(timeStepFPS, useHighPrecisionTimer: false, timeoutMS);
	}

	public static ThreadHelper CreateFixedTimeStep(int timeStepFPS, bool useHighPrecisionTimer = false, int timeoutMS = 0)
	{
		return new ThreadHelper(timeStepFPS, useHighPrecisionTimer, timeoutMS);
	}

	private void zaDeOaVEgrdVCCPDqtwlnxDuhwxp(Action P_0)
	{
		Action action = gsfjXyDIbiOShzWnzRauTmYYfyNp;
		Action action2;
		do
		{
			action2 = action;
			Action value = (Action)Delegate.Combine(action2, P_0);
			action = Interlocked.CompareExchange(ref gsfjXyDIbiOShzWnzRauTmYYfyNp, value, action2);
		}
		while ((object)action != action2);
	}

	private void NxnmKSpYKITLOAjHcUszTjBwghBHA(Action P_0)
	{
		Action action = gsfjXyDIbiOShzWnzRauTmYYfyNp;
		Action action2;
		do
		{
			action2 = action;
			Action value = (Action)Delegate.Remove(action2, P_0);
			action = Interlocked.CompareExchange(ref gsfjXyDIbiOShzWnzRauTmYYfyNp, value, action2);
		}
		while ((object)action != action2);
	}

	private void ASEYJvETCxhZOPBMbrjrPFPJfkKU(Action P_0)
	{
		Action action = ylNUFKFKYoflkaAjWuqEurKQMAlfb;
		Action action2;
		do
		{
			action2 = action;
			Action value = (Action)Delegate.Combine(action2, P_0);
			action = Interlocked.CompareExchange(ref ylNUFKFKYoflkaAjWuqEurKQMAlfb, value, action2);
		}
		while ((object)action != action2);
	}

	private void KXaJRQOHuMTXnjqpdpFNIopSCiGCA(Action P_0)
	{
		Action action = ylNUFKFKYoflkaAjWuqEurKQMAlfb;
		Action action2;
		do
		{
			action2 = action;
			Action value = (Action)Delegate.Remove(action2, P_0);
			action = Interlocked.CompareExchange(ref ylNUFKFKYoflkaAjWuqEurKQMAlfb, value, action2);
		}
		while ((object)action != action2);
	}

	private ThreadHelper()
		: this(0)
	{
	}

	private ThreadHelper(int P_0)
		: this(0, false, P_0)
	{
	}

	private ThreadHelper(int P_0, bool P_1, int P_2)
	{
		aQBKawBwoHgJWfLafjZoNkBeIJcw = Stopwatch.Global;
		if (P_0 < 0)
		{
			P_0 = 0;
		}
		if (P_2 < 0)
		{
			P_2 = 0;
		}
		HTDjGFTOhJHyagAWqxtSFZXfHqah = P_2;
		VnnfQaflooYnIlwKJzfgWSkMZKbS = P_0;
		RQjazDAvwLuPlJfIyMQWgamMXIzFA = P_1;
		QzOSlxJqqImvvqOdXHefbhoLaaVKA();
		xRoYlnhSbJYpvyKaddDDXbkQifmC = new ManualResetEvent(initialState: false);
		ZbiAycRFyJemRAxLEUFavtNFHlcq = new ManualResetEvent(initialState: false);
		FKmhveeRKixbpNcpurGNJWAMpiwM = new AutoResetEvent(initialState: false);
		cOqnPYWgTvpLpqDgyNWYrOddrpLM = new object();
		jevCGUYEOZBNkczBIfRxHWkgUWt = new Queue<Action>();
		gRjzofZAVXSgHsPcehDnKGOPypqH = new Queue<Action>();
	}

	public bool Start(bool wait)
	{
		if (IPHUFYyMFDNSTKqfIleUzwIOkFSX)
		{
			return false;
		}
		try
		{
			xRoYlnhSbJYpvyKaddDDXbkQifmC.Reset();
			FKmhveeRKixbpNcpurGNJWAMpiwM.Reset();
			ctPOIZGfjcwvUeKjfDOBCewqzTwuA = new Thread(vLeYrHAvHtfMNuMJlIqpNRXmlcbr);
			ctPOIZGfjcwvUeKjfDOBCewqzTwuA.Start();
			if (wait)
			{
				xRoYlnhSbJYpvyKaddDDXbkQifmC.WaitOne();
			}
			return true;
		}
		catch (Exception)
		{
			return false;
		}
	}

	public void Stop(bool wait)
	{
		if (ctPOIZGfjcwvUeKjfDOBCewqzTwuA != null && IPHUFYyMFDNSTKqfIleUzwIOkFSX && KMPNqcxPcuXuMdoYuvcVmkFxfqVBA)
		{
			xRoYlnhSbJYpvyKaddDDXbkQifmC.Reset();
			KMPNqcxPcuXuMdoYuvcVmkFxfqVBA = false;
			FKmhveeRKixbpNcpurGNJWAMpiwM.Set();
			if (wait)
			{
				xRoYlnhSbJYpvyKaddDDXbkQifmC.WaitOne();
			}
			HuWYWNQaAfEGNLEfMlSQdKdJFDzd();
		}
	}

	public bool EnqueueAction(Action action)
	{
		if (action == null)
		{
			return false;
		}
		if (!IPHUFYyMFDNSTKqfIleUzwIOkFSX)
		{
			return false;
		}
		if (!KMPNqcxPcuXuMdoYuvcVmkFxfqVBA)
		{
			return false;
		}
		ResetTimeout();
		lock (cOqnPYWgTvpLpqDgyNWYrOddrpLM)
		{
			jevCGUYEOZBNkczBIfRxHWkgUWt.Enqueue(action);
			QfohlWfxAjeFBYaLEIYSgIwGfzAXA = true;
			FKmhveeRKixbpNcpurGNJWAMpiwM.Set();
		}
		return true;
	}

	public bool InvokeActionSync(Action action)
	{
		if (!IPHUFYyMFDNSTKqfIleUzwIOkFSX)
		{
			return false;
		}
		if (!KMPNqcxPcuXuMdoYuvcVmkFxfqVBA)
		{
			return false;
		}
		EnqueueAction(action);
		WaitForActionQueueToFinish();
		return true;
	}

	public void WaitForActionQueueToFinish()
	{
		if (!IPHUFYyMFDNSTKqfIleUzwIOkFSX || !KMPNqcxPcuXuMdoYuvcVmkFxfqVBA)
		{
			return;
		}
		ResetTimeout();
		lock (cOqnPYWgTvpLpqDgyNWYrOddrpLM)
		{
			ZbiAycRFyJemRAxLEUFavtNFHlcq.Reset();
			RcKBwAKubFHmvJUMzGItiPDJbzgIA++;
		}
		FKmhveeRKixbpNcpurGNJWAMpiwM.Set();
		ZbiAycRFyJemRAxLEUFavtNFHlcq.WaitOne();
		lock (cOqnPYWgTvpLpqDgyNWYrOddrpLM)
		{
			RcKBwAKubFHmvJUMzGItiPDJbzgIA--;
		}
	}

	public void ResetTimeout()
	{
		vcBnmsTcfsGDvMnHmLpSBifPGFMT = ((HTDjGFTOhJHyagAWqxtSFZXfHqah > 0) ? (aQBKawBwoHgJWfLafjZoNkBeIJcw.elapsedMillisecondsRaw + HTDjGFTOhJHyagAWqxtSFZXfHqah) : 0);
	}

	private void vLeYrHAvHtfMNuMJlIqpNRXmlcbr()
	{
		ResetTimeout();
		IPHUFYyMFDNSTKqfIleUzwIOkFSX = true;
		KMPNqcxPcuXuMdoYuvcVmkFxfqVBA = true;
		xRoYlnhSbJYpvyKaddDDXbkQifmC.Set();
		if (gsfjXyDIbiOShzWnzRauTmYYfyNp != null)
		{
			lock (gsfjXyDIbiOShzWnzRauTmYYfyNp)
			{
				try
				{
					gsfjXyDIbiOShzWnzRauTmYYfyNp();
				}
				catch (Exception ex)
				{
					Logger.LogError("Caught exception in thread start event callback.\n" + ex, requiredThreadSafety: true);
				}
			}
		}
		while (KMPNqcxPcuXuMdoYuvcVmkFxfqVBA)
		{
			long num = aQBKawBwoHgJWfLafjZoNkBeIJcw.elapsedTicksRaw + kVMnNernRxzdWkJkhwfNnMwzTEXt;
			MeWsMSZMywkwogoKYstztGTUrEvT();
			lock (cOqnPYWgTvpLpqDgyNWYrOddrpLM)
			{
				if (!QfohlWfxAjeFBYaLEIYSgIwGfzAXA && RcKBwAKubFHmvJUMzGItiPDJbzgIA > 0)
				{
					ZbiAycRFyJemRAxLEUFavtNFHlcq.Set();
				}
			}
			if (hMgUwkHCjFsXNkfqxNKcJzhKdMaN != null)
			{
				try
				{
					hMgUwkHCjFsXNkfqxNKcJzhKdMaN();
				}
				catch (Exception ex2)
				{
					Logger.LogError("Exception occurred in a Thread Update Event callback.\n" + ex2, requiredThreadSafety: true);
				}
			}
			if (vidzdNzRgVBhZQONDHhCDHsWcxqg)
			{
				if (RQjazDAvwLuPlJfIyMQWgamMXIzFA || (long)VnnfQaflooYnIlwKJzfgWSkMZKbS >= 750L)
				{
					while (aQBKawBwoHgJWfLafjZoNkBeIJcw.elapsedTicksRaw < num)
					{
					}
				}
				else
				{
					long num2 = num - aQBKawBwoHgJWfLafjZoNkBeIJcw.elapsedTicksRaw;
					if (num2 > 0)
					{
						FKmhveeRKixbpNcpurGNJWAMpiwM.WaitOne(TimeSpan.FromTicks(Stopwatch.ConvertTo100NSTicks(num2)));
					}
				}
			}
			zmnEqZtCHgUOEuCEBgetfBOkiYysA = ((zmnEqZtCHgUOEuCEBgetfBOkiYysA != uint.MaxValue) ? (zmnEqZtCHgUOEuCEBgetfBOkiYysA + 1) : 0u);
			if (HTDjGFTOhJHyagAWqxtSFZXfHqah > 0 && aQBKawBwoHgJWfLafjZoNkBeIJcw.elapsedMillisecondsRaw >= vcBnmsTcfsGDvMnHmLpSBifPGFMT)
			{
				KMPNqcxPcuXuMdoYuvcVmkFxfqVBA = false;
			}
		}
		if (ylNUFKFKYoflkaAjWuqEurKQMAlfb != null)
		{
			lock (ylNUFKFKYoflkaAjWuqEurKQMAlfb)
			{
				try
				{
					ylNUFKFKYoflkaAjWuqEurKQMAlfb();
				}
				catch (Exception ex3)
				{
					Logger.LogError("Caught exception in thread pre-stop event event callback.\n" + ex3, requiredThreadSafety: true);
				}
			}
		}
		IPHUFYyMFDNSTKqfIleUzwIOkFSX = false;
		xRoYlnhSbJYpvyKaddDDXbkQifmC.Set();
	}

	private void MeWsMSZMywkwogoKYstztGTUrEvT()
	{
		if (!QfohlWfxAjeFBYaLEIYSgIwGfzAXA)
		{
			return;
		}
		lock (cOqnPYWgTvpLpqDgyNWYrOddrpLM)
		{
			MiscTools.Swap(ref jevCGUYEOZBNkczBIfRxHWkgUWt, ref gRjzofZAVXSgHsPcehDnKGOPypqH);
			QfohlWfxAjeFBYaLEIYSgIwGfzAXA = false;
		}
		while (gRjzofZAVXSgHsPcehDnKGOPypqH.Count > 0)
		{
			Action action = gRjzofZAVXSgHsPcehDnKGOPypqH.Dequeue();
			try
			{
				action();
			}
			catch (Exception ex)
			{
				Logger.LogError("Exception occurred while processing thread Action queue.\n" + ex, requiredThreadSafety: true);
			}
		}
	}

	private void QzOSlxJqqImvvqOdXHefbhoLaaVKA()
	{
		if (VnnfQaflooYnIlwKJzfgWSkMZKbS <= 0)
		{
			vidzdNzRgVBhZQONDHhCDHsWcxqg = false;
		}
		else
		{
			vidzdNzRgVBhZQONDHhCDHsWcxqg = true;
			kVMnNernRxzdWkJkhwfNnMwzTEXt = Stopwatch.frequency / VnnfQaflooYnIlwKJzfgWSkMZKbS;
		}
		ResetTimeout();
	}

	private void HuWYWNQaAfEGNLEfMlSQdKdJFDzd()
	{
		ctPOIZGfjcwvUeKjfDOBCewqzTwuA = null;
		IPHUFYyMFDNSTKqfIleUzwIOkFSX = false;
		KMPNqcxPcuXuMdoYuvcVmkFxfqVBA = false;
		jevCGUYEOZBNkczBIfRxHWkgUWt.Clear();
		gRjzofZAVXSgHsPcehDnKGOPypqH.Clear();
		QfohlWfxAjeFBYaLEIYSgIwGfzAXA = false;
		RcKBwAKubFHmvJUMzGItiPDJbzgIA = 0;
		xRoYlnhSbJYpvyKaddDDXbkQifmC.Reset();
		ZbiAycRFyJemRAxLEUFavtNFHlcq.Reset();
		vcBnmsTcfsGDvMnHmLpSBifPGFMT = 0L;
		zmnEqZtCHgUOEuCEBgetfBOkiYysA = 0u;
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	~ThreadHelper()
	{
		Dispose(disposing: false);
	}

	protected void Dispose(bool disposing)
	{
		if (!EOjwsNAILutegiObRlpMOrbgwpII)
		{
			if (disposing)
			{
				Stop(wait: true);
			}
			else
			{
				KMPNqcxPcuXuMdoYuvcVmkFxfqVBA = false;
			}
			EOjwsNAILutegiObRlpMOrbgwpII = true;
		}
	}

	[Conditional("DEBUG_THREAD_HELPER")]
	private static void gwZgsNJkxsEqIhSuVulLfmEmxkAeA(object P_0)
	{
		if (P_0 != null)
		{
			Logger.Log(P_0, requiredThreadSafety: true);
		}
	}
}
