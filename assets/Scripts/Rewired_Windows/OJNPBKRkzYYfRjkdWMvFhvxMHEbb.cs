using System;
using System.Threading;
using Rewired;
using Rewired.Utils;
using Rewired.Utils.Classes.Utility;

internal class OJNPBKRkzYYfRjkdWMvFhvxMHEbb : IDisposable
{
	public delegate void QasDLTqICMBbkEBZkeUcJrElKfQeA(IntPtr reportPointer, int reportByteLength, int reportCount, double timestamp);

	private const int lnKdojxpMpSYgzwSVBMvvKbWNcGq = 512;

	private const int LVgdAZaCPkMpRSZVeRSmEdxsdbThA = 250;

	private readonly QasDLTqICMBbkEBZkeUcJrElKfQeA UeIowbyAIyYbvUyllsvoJuHtlkWI;

	private readonly CmKBFdWgWjaMERsUXWmocJatQsnE ANAsKzjODNBLRGUKLHLmWBTzUDAAA;

	private readonly ThreadHelper vMAxhPploxKZGJyfkNMWLENurZnU;

	private readonly int TvzFBoUbRWimMAMfZHyFjZyysdUX;

	private readonly int iBEHMXghbZAniXOxzUZVzUHQHLiIA;

	private readonly string lGlqXVWtTocNeEeqexEeFkjRHnAAA;

	private readonly byte[] bFnduBCzYgJgNkypIDsSYtsHqClIA;

	private readonly byte[] KQiOSmdTMezBsaFXtmcjxDpzZXMJ;

	private int eOzbsXAKJWQnHenxBQRqARggTnDmA;

	private nGmHJBDkYYdTCONkFlbkXsaMwQZL xzUDPbfsLAxkKoOpmuMJOdYgliJM;

	private nGmHJBDkYYdTCONkFlbkXsaMwQZL UZQBDykPoWHoZIBQyEbQyPlqZOmO;

	private bool gUuaJTkdoQMJmeDiLZegctArvXYw;

	public OJNPBKRkzYYfRjkdWMvFhvxMHEbb(string P_0, int P_1, string P_2, QasDLTqICMBbkEBZkeUcJrElKfQeA P_3)
	{
		if (string.IsNullOrEmpty(P_0))
		{
			throw new ArgumentNullException("hidDevicePath");
		}
		if (P_3 == null)
		{
			throw new ArgumentNullException("processReportDelegate");
		}
		iBEHMXghbZAniXOxzUZVzUHQHLiIA = P_1;
		if (iBEHMXghbZAniXOxzUZVzUHQHLiIA <= 0)
		{
			iBEHMXghbZAniXOxzUZVzUHQHLiIA = 512;
		}
		TvzFBoUbRWimMAMfZHyFjZyysdUX = P_1 + 8;
		lGlqXVWtTocNeEeqexEeFkjRHnAAA = P_2;
		UeIowbyAIyYbvUyllsvoJuHtlkWI = P_3;
		int num = TvzFBoUbRWimMAMfZHyFjZyysdUX * 60;
		if (num <= 0)
		{
			Logger.LogError("Invalid report buffer size. This device \"" + P_2 + "\" will not function.");
			throw new Exception();
		}
		try
		{
			ANAsKzjODNBLRGUKLHLmWBTzUDAAA = new CmKBFdWgWjaMERsUXWmocJatQsnE(P_0, P_1, 250);
		}
		catch (Exception)
		{
			Logger.LogError("Out of memory. This device \"" + P_2 + "\" will not function.");
			throw;
		}
		try
		{
			xzUDPbfsLAxkKoOpmuMJOdYgliJM = new nGmHJBDkYYdTCONkFlbkXsaMwQZL(num);
			UZQBDykPoWHoZIBQyEbQyPlqZOmO = new nGmHJBDkYYdTCONkFlbkXsaMwQZL(num);
			bFnduBCzYgJgNkypIDsSYtsHqClIA = new byte[TvzFBoUbRWimMAMfZHyFjZyysdUX];
			KQiOSmdTMezBsaFXtmcjxDpzZXMJ = new byte[TvzFBoUbRWimMAMfZHyFjZyysdUX];
		}
		catch (Exception)
		{
			Logger.LogError("Out of memory. This device \"" + P_2 + "\" will not function.");
			throw;
		}
		try
		{
			vMAxhPploxKZGJyfkNMWLENurZnU = ThreadHelper.Create();
			vMAxhPploxKZGJyfkNMWLENurZnU.ThreadUpdateEvent += LUMnGYAeAvZNdaERvKOqpJQJDsvn;
			vMAxhPploxKZGJyfkNMWLENurZnU.Start(wait: false);
		}
		catch (Exception)
		{
			Logger.LogError("Error creating thread. This device \"" + P_2 + "\" will not function.");
			throw;
		}
	}

	public unsafe void MUGYSSscJkPzLvhnFqAHFyklEjTA()
	{
		try
		{
			if (GsMNYVJiOkJRHIfIXWfdwmzIxrbY())
			{
				return;
			}
			ekVkaGHxHDRrygJThKwTVJuIqNDL();
			int num = 0;
			byte[] array = bFnduBCzYgJgNkypIDsSYtsHqClIA;
			fixed (byte* ptr = array)
			{
				while (xzUDPbfsLAxkKoOpmuMJOdYgliJM.KsudtZUdFWGblDebnuXMTcJsdkejA(array, TvzFBoUbRWimMAMfZHyFjZyysdUX) > 0)
				{
					UeIowbyAIyYbvUyllsvoJuHtlkWI((IntPtr)ptr, iBEHMXghbZAniXOxzUZVzUHQHLiIA, 1, *(double*)(ptr + iBEHMXghbZAniXOxzUZVzUHQHLiIA));
					num++;
				}
			}
		}
		catch
		{
		}
	}

	private void ekVkaGHxHDRrygJThKwTVJuIqNDL()
	{
		lock (xzUDPbfsLAxkKoOpmuMJOdYgliJM)
		{
			lock (UZQBDykPoWHoZIBQyEbQyPlqZOmO)
			{
				MiscTools.Swap(ref xzUDPbfsLAxkKoOpmuMJOdYgliJM, ref UZQBDykPoWHoZIBQyEbQyPlqZOmO);
			}
		}
	}

	private void LUMnGYAeAvZNdaERvKOqpJQJDsvn()
	{
		if (eOzbsXAKJWQnHenxBQRqARggTnDmA != 0)
		{
			Thread.Sleep(500);
			return;
		}
		try
		{
			byte[] kQiOSmdTMezBsaFXtmcjxDpzZXMJ = KQiOSmdTMezBsaFXtmcjxDpzZXMJ;
			if (!ChJbqgEkgAdNKxePXGVYHbjCdBxd(kQiOSmdTMezBsaFXtmcjxDpzZXMJ))
			{
				return;
			}
			lock (UZQBDykPoWHoZIBQyEbQyPlqZOmO)
			{
				UZQBDykPoWHoZIBQyEbQyPlqZOmO.LbszLhUpnAnONEtQIPlrvdunBzxs(kQiOSmdTMezBsaFXtmcjxDpzZXMJ, kQiOSmdTMezBsaFXtmcjxDpzZXMJ.Length);
			}
		}
		catch
		{
		}
	}

	private bool ChJbqgEkgAdNKxePXGVYHbjCdBxd(byte[] P_0)
	{
		switch (ANAsKzjODNBLRGUKLHLmWBTzUDAAA.rwsvelOrytleWEYvJctElJXoeSjH(P_0))
		{
		case CmKBFdWgWjaMERsUXWmocJatQsnE.hwbqJPqcJAtdWlmntexJbYbZUAAW.Success:
			return true;
		case CmKBFdWgWjaMERsUXWmocJatQsnE.hwbqJPqcJAtdWlmntexJbYbZUAAW.Error:
			Thread.Sleep(500);
			break;
		case CmKBFdWgWjaMERsUXWmocJatQsnE.hwbqJPqcJAtdWlmntexJbYbZUAAW.CriticalError:
			eOzbsXAKJWQnHenxBQRqARggTnDmA = 1;
			break;
		}
		return false;
	}

	private bool GsMNYVJiOkJRHIfIXWfdwmzIxrbY()
	{
		if (eOzbsXAKJWQnHenxBQRqARggTnDmA != 0)
		{
			if (eOzbsXAKJWQnHenxBQRqARggTnDmA == 1)
			{
				Logger.LogError("Error communicating with HID device. This device \"" + lGlqXVWtTocNeEeqexEeFkjRHnAAA + "\" will not function.");
				eOzbsXAKJWQnHenxBQRqARggTnDmA = 2;
				try
				{
					vMAxhPploxKZGJyfkNMWLENurZnU.Stop(wait: false);
				}
				catch
				{
				}
			}
			return true;
		}
		return false;
	}

	public void Dispose()
	{
		diobDWRhHoFDlyBnwBifhRFuKfnWA(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	protected virtual void qiBHcBFOvMMqkwEqzbvFgqBOnFqO()
	{
		try
		{
			diobDWRhHoFDlyBnwBifhRFuKfnWA(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	protected virtual void diobDWRhHoFDlyBnwBifhRFuKfnWA(bool P_0)
	{
		if (gUuaJTkdoQMJmeDiLZegctArvXYw)
		{
			return;
		}
		if (P_0)
		{
			if (vMAxhPploxKZGJyfkNMWLENurZnU != null)
			{
				vMAxhPploxKZGJyfkNMWLENurZnU.Dispose();
			}
			if (ANAsKzjODNBLRGUKLHLmWBTzUDAAA != null)
			{
				ANAsKzjODNBLRGUKLHLmWBTzUDAAA.Dispose();
			}
		}
		gUuaJTkdoQMJmeDiLZegctArvXYw = true;
	}
}
