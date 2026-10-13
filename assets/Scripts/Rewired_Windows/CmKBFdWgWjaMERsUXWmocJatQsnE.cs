using System;
using System.Diagnostics;
using Rewired;
using Rewired.Utils.Attributes;
using Rewired.Utils.Classes.Data;
using Rewired.Utils.Classes.Utility;

internal class CmKBFdWgWjaMERsUXWmocJatQsnE : IDisposable
{
	private enum qDPmWqPnvwNSOwceOEJGFNsrKbee
	{
		Idle = 0,
		Waiting = 1,
		ErrorPending = 2,
		FinishedError = 3,
		SuccessPending = 4,
		FinishedSuccess = 5
	}

	public enum hwbqJPqcJAtdWlmntexJbYbZUAAW
	{
		Idle = 0,
		Success = 1,
		Error = 2,
		Waiting = 3,
		CriticalError = 4
	}

	public const int FWneJGoEyGyrkwaOJsDTOjJbxfQg = 8;

	private const int clwazyZNhBHTEooumVTDpSzfnHap = 10;

	private readonly string bLHkgcNpegOEnjrqEMHeEaPcjsNDA;

	private IntPtr VOwyNYEjhbIESaxCBcrkpAlXyOCgA = ShLxNDAuNJnTDKEaZHAvIhFLYQDS.hXYiniRQUQgqgoifAoCGkJYkSfKC;

	private readonly NativeBuffer VDOABtRHHtbwJUUOlpLkpjYKGqtk;

	private readonly int iQNFjhsUUUQcFcbBGVwwWHfAdwom;

	private readonly ShLxNDAuNJnTDKEaZHAvIhFLYQDS.lQEVtOJEmvgtlYlUWCRmGoHvjDpJA zvPEhTEIKXnNHvEbWcdWXXCXYUdD;

	private readonly object QiOyOZlMYxMsOuObqBUfnqVstxz;

	private readonly uint jCcFLYazereWbJjJhqwDlkqWlGYY;

	private global::ObqXgUUqhavcGIoFqIXpOyTOjTCP<ShLxNDAuNJnTDKEaZHAvIhFLYQDS.SApgQYHIDWDqrfeOlHCjwjtAOodt> ciSbQLLELPGAOigmeUJyIvrAKmqnA;

	private qDPmWqPnvwNSOwceOEJGFNsrKbee kfwJjjbkswyUNnEhEqUPTxRTuzQi;

	private int otjNAnsfyJyOuBIzXaLPfexvCAPW;

	private bool RhalvavDPvXHqDHWFmDDpbBQbXoG;

	private int fXVTZKaHrzpwyHsIlyXUAEQEEpmW;

	private int DGiyiIHoVpmRosyFkuHxTNWoZWon;

	public readonly int wVAMcyxbqjPskpbnIcmDeSrMXkznA;

	private bool QAYGpFGzcumqLoxdedPfdFKZHPSA;

	private bool WDQsCgcLpgtnzvJaPfICfKzEtqHF => wkIGGWbLPIkJxoxBnGEVIZmcGvQac();

	private bool wkIGGWbLPIkJxoxBnGEVIZmcGvQac()
	{
		return jJVMeOSGFiWvYXFSLLMERjkQCZOv.TLqMDQefyqSrEEltqOfbmKGXgxSZ(bLHkgcNpegOEnjrqEMHeEaPcjsNDA);
	}

	public CmKBFdWgWjaMERsUXWmocJatQsnE(string P_0, int P_1, int P_2)
	{
		if (string.IsNullOrEmpty(P_0))
		{
			throw new ArgumentNullException("devicePath");
		}
		if (P_1 <= 0)
		{
			throw new ArgumentOutOfRangeException("reportLength must be > 0");
		}
		jCcFLYazereWbJjJhqwDlkqWlGYY = ObjectInstanceTracker.Default.Register(this);
		bLHkgcNpegOEnjrqEMHeEaPcjsNDA = P_0;
		if (!WQzbeRFUzCcwyBSCFDfwfiILPNdHA())
		{
			throw new Exception("Could not open HID device.");
		}
		iQNFjhsUUUQcFcbBGVwwWHfAdwom = P_1;
		wVAMcyxbqjPskpbnIcmDeSrMXkznA = P_1 + 8;
		VDOABtRHHtbwJUUOlpLkpjYKGqtk = new NativeBuffer(wVAMcyxbqjPskpbnIcmDeSrMXkznA);
		ciSbQLLELPGAOigmeUJyIvrAKmqnA = new global::ObqXgUUqhavcGIoFqIXpOyTOjTCP<ShLxNDAuNJnTDKEaZHAvIhFLYQDS.SApgQYHIDWDqrfeOlHCjwjtAOodt>();
		kfwJjjbkswyUNnEhEqUPTxRTuzQi = qDPmWqPnvwNSOwceOEJGFNsrKbee.Idle;
		otjNAnsfyJyOuBIzXaLPfexvCAPW = ((P_2 < 0) ? 65535 : P_2);
		QiOyOZlMYxMsOuObqBUfnqVstxz = new object();
		zvPEhTEIKXnNHvEbWcdWXXCXYUdD = FtCAPaEuBHcaScfwnHivaQYLhyWn;
		dFAbuzjeLDgHJsJBqjrLfcPaequyA();
	}

	public hwbqJPqcJAtdWlmntexJbYbZUAAW rwsvelOrytleWEYvJctElJXoeSjH(byte[] P_0)
	{
		lock (QiOyOZlMYxMsOuObqBUfnqVstxz)
		{
			if (QAYGpFGzcumqLoxdedPfdFKZHPSA)
			{
				return hwbqJPqcJAtdWlmntexJbYbZUAAW.CriticalError;
			}
			if (!hNGajPImtpnSHNAxjKNdcNNsGnvAb())
			{
				return (DGiyiIHoVpmRosyFkuHxTNWoZWon >= 10) ? hwbqJPqcJAtdWlmntexJbYbZUAAW.CriticalError : hwbqJPqcJAtdWlmntexJbYbZUAAW.Error;
			}
			if (P_0 == null)
			{
				throw new ArgumentNullException("buffer");
			}
			if (P_0.Length < wVAMcyxbqjPskpbnIcmDeSrMXkznA)
			{
				int num = wVAMcyxbqjPskpbnIcmDeSrMXkznA;
				throw new Exception("buffer must be at least " + num + " bytes");
			}
			switch (kfwJjjbkswyUNnEhEqUPTxRTuzQi)
			{
			case qDPmWqPnvwNSOwceOEJGFNsrKbee.Idle:
				LkPdCeIsAHQwemzhHAUYVhUgqhaQA();
				break;
			case qDPmWqPnvwNSOwceOEJGFNsrKbee.Waiting:
				dpBQNFtoIuxIvdtfPJoMvgFFvYlh();
				break;
			case qDPmWqPnvwNSOwceOEJGFNsrKbee.ErrorPending:
				mRXZIAkdxABCAZdvhnSTpPUoHvKW();
				break;
			case qDPmWqPnvwNSOwceOEJGFNsrKbee.SuccessPending:
				SeoDuMtjQaCbngGXKmzVhNVcUeiL();
				break;
			}
			switch (kfwJjjbkswyUNnEhEqUPTxRTuzQi)
			{
			case qDPmWqPnvwNSOwceOEJGFNsrKbee.Idle:
				return hwbqJPqcJAtdWlmntexJbYbZUAAW.Idle;
			case qDPmWqPnvwNSOwceOEJGFNsrKbee.Waiting:
			case qDPmWqPnvwNSOwceOEJGFNsrKbee.ErrorPending:
			case qDPmWqPnvwNSOwceOEJGFNsrKbee.SuccessPending:
				return hwbqJPqcJAtdWlmntexJbYbZUAAW.Waiting;
			case qDPmWqPnvwNSOwceOEJGFNsrKbee.FinishedSuccess:
				VDOABtRHHtbwJUUOlpLkpjYKGqtk.TryReadBytes(P_0, wVAMcyxbqjPskpbnIcmDeSrMXkznA);
				kfwJjjbkswyUNnEhEqUPTxRTuzQi = qDPmWqPnvwNSOwceOEJGFNsrKbee.Idle;
				return hwbqJPqcJAtdWlmntexJbYbZUAAW.Success;
			case qDPmWqPnvwNSOwceOEJGFNsrKbee.FinishedError:
				kfwJjjbkswyUNnEhEqUPTxRTuzQi = qDPmWqPnvwNSOwceOEJGFNsrKbee.Idle;
				return hwbqJPqcJAtdWlmntexJbYbZUAAW.Error;
			default:
				throw new NotImplementedException();
			}
		}
	}

	private bool LkPdCeIsAHQwemzhHAUYVhUgqhaQA()
	{
		if (kfwJjjbkswyUNnEhEqUPTxRTuzQi != qDPmWqPnvwNSOwceOEJGFNsrKbee.Idle)
		{
			int num = (int)kfwJjjbkswyUNnEhEqUPTxRTuzQi;
			throw new Exception("Cannot StartRead from this state. State = " + num);
		}
		try
		{
			mJLANpiJPfKzeZKpCYRGqAINONszA();
			bool num2 = ShLxNDAuNJnTDKEaZHAvIhFLYQDS.dioWUTmzymizieLPYUJFTLnDekqJA(VOwyNYEjhbIESaxCBcrkpAlXyOCgA, VDOABtRHHtbwJUUOlpLkpjYKGqtk, (uint)iQNFjhsUUUQcFcbBGVwwWHfAdwom, zPYtRvRddGYtyjvCeSHFiOzocDBi.LBmhHOATglrnrMJyhDckXAWXTXYLA(ciSbQLLELPGAOigmeUJyIvrAKmqnA.mwSEgQGUOFjwVgCqBoHNLVnkJQTEA()), zvPEhTEIKXnNHvEbWcdWXXCXYUdD);
			if (num2)
			{
				kfwJjjbkswyUNnEhEqUPTxRTuzQi = qDPmWqPnvwNSOwceOEJGFNsrKbee.Waiting;
				RhalvavDPvXHqDHWFmDDpbBQbXoG = true;
			}
			else
			{
				ZaVzYnJIGZezhUOdMVTEZXDssffX();
			}
			return num2;
		}
		catch (Exception)
		{
			ZaVzYnJIGZezhUOdMVTEZXDssffX();
			return false;
		}
	}

	private void dpBQNFtoIuxIvdtfPJoMvgFFvYlh()
	{
		if (kfwJjjbkswyUNnEhEqUPTxRTuzQi != qDPmWqPnvwNSOwceOEJGFNsrKbee.Waiting)
		{
			int num = (int)kfwJjjbkswyUNnEhEqUPTxRTuzQi;
			throw new Exception("Cannot CheckReadStatus from this state. State = " + num);
		}
		switch (fbAtivBaXaFYnMUoSAqyrUAIGwbbA())
		{
		case hwbqJPqcJAtdWlmntexJbYbZUAAW.Error:
			ZaVzYnJIGZezhUOdMVTEZXDssffX();
			break;
		case hwbqJPqcJAtdWlmntexJbYbZUAAW.Success:
			mvdxJIFgkLrhmuafOWnkEkXCAQoL();
			break;
		case hwbqJPqcJAtdWlmntexJbYbZUAAW.Waiting:
			break;
		}
	}

	private hwbqJPqcJAtdWlmntexJbYbZUAAW fbAtivBaXaFYnMUoSAqyrUAIGwbbA()
	{
		if (kfwJjjbkswyUNnEhEqUPTxRTuzQi != qDPmWqPnvwNSOwceOEJGFNsrKbee.Waiting)
		{
			return hwbqJPqcJAtdWlmntexJbYbZUAAW.Error;
		}
		try
		{
			switch (ShLxNDAuNJnTDKEaZHAvIhFLYQDS.hqsSLTUsdhPOenBknEZzRvDfuoYb(otjNAnsfyJyOuBIzXaLPfexvCAPW, true))
			{
			case 0u:
				return hwbqJPqcJAtdWlmntexJbYbZUAAW.Waiting;
			case 192u:
			{
				if (!ShLxNDAuNJnTDKEaZHAvIhFLYQDS.EiTSrumDqvdVfaWLiudFlerUOYiwA(VOwyNYEjhbIESaxCBcrkpAlXyOCgA, zPYtRvRddGYtyjvCeSHFiOzocDBi.LBmhHOATglrnrMJyhDckXAWXTXYLA(ciSbQLLELPGAOigmeUJyIvrAKmqnA.mwSEgQGUOFjwVgCqBoHNLVnkJQTEA()), out var num, false))
				{
					return hwbqJPqcJAtdWlmntexJbYbZUAAW.Error;
				}
				return (num > 0) ? hwbqJPqcJAtdWlmntexJbYbZUAAW.Success : hwbqJPqcJAtdWlmntexJbYbZUAAW.Error;
			}
			case uint.MaxValue:
			case 128u:
			case 258u:
				return hwbqJPqcJAtdWlmntexJbYbZUAAW.Waiting;
			default:
				return hwbqJPqcJAtdWlmntexJbYbZUAAW.Error;
			}
		}
		catch
		{
			return hwbqJPqcJAtdWlmntexJbYbZUAAW.Error;
		}
	}

	private void ZaVzYnJIGZezhUOdMVTEZXDssffX()
	{
		kfwJjjbkswyUNnEhEqUPTxRTuzQi = qDPmWqPnvwNSOwceOEJGFNsrKbee.ErrorPending;
		mRXZIAkdxABCAZdvhnSTpPUoHvKW();
	}

	private void mRXZIAkdxABCAZdvhnSTpPUoHvKW()
	{
		if (kfwJjjbkswyUNnEhEqUPTxRTuzQi != qDPmWqPnvwNSOwceOEJGFNsrKbee.ErrorPending)
		{
			int num = (int)kfwJjjbkswyUNnEhEqUPTxRTuzQi;
			throw new Exception("Cannot CheckErrorFinished from this state. State = " + num);
		}
		kfwJjjbkswyUNnEhEqUPTxRTuzQi = qDPmWqPnvwNSOwceOEJGFNsrKbee.FinishedError;
	}

	private void mvdxJIFgkLrhmuafOWnkEkXCAQoL()
	{
		kfwJjjbkswyUNnEhEqUPTxRTuzQi = qDPmWqPnvwNSOwceOEJGFNsrKbee.SuccessPending;
		SeoDuMtjQaCbngGXKmzVhNVcUeiL();
	}

	private void SeoDuMtjQaCbngGXKmzVhNVcUeiL()
	{
		if (kfwJjjbkswyUNnEhEqUPTxRTuzQi != qDPmWqPnvwNSOwceOEJGFNsrKbee.SuccessPending)
		{
			int num = (int)kfwJjjbkswyUNnEhEqUPTxRTuzQi;
			throw new Exception("Cannot CheckSuccessFinished from this state. State = " + num);
		}
		kfwJjjbkswyUNnEhEqUPTxRTuzQi = qDPmWqPnvwNSOwceOEJGFNsrKbee.FinishedSuccess;
		VDOABtRHHtbwJUUOlpLkpjYKGqtk.Write(ReInput.realTime, iQNFjhsUUUQcFcbBGVwwWHfAdwom);
	}

	private void mJLANpiJPfKzeZKpCYRGqAINONszA()
	{
		dFAbuzjeLDgHJsJBqjrLfcPaequyA();
		VDOABtRHHtbwJUUOlpLkpjYKGqtk.Clear();
		fXVTZKaHrzpwyHsIlyXUAEQEEpmW = 0;
		RhalvavDPvXHqDHWFmDDpbBQbXoG = false;
	}

	private void dFAbuzjeLDgHJsJBqjrLfcPaequyA()
	{
		ShLxNDAuNJnTDKEaZHAvIhFLYQDS.SApgQYHIDWDqrfeOlHCjwjtAOodt sApgQYHIDWDqrfeOlHCjwjtAOodt = default;
		sApgQYHIDWDqrfeOlHCjwjtAOodt.JUuPIAsTcHPMbJaypPLicSsTtoky = new IntPtr((int)jCcFLYazereWbJjJhqwDlkqWlGYY);
		sApgQYHIDWDqrfeOlHCjwjtAOodt.rmMQUGJWYxWCiuGKcuTnDGwrYXPJ = IntPtr.Zero;
		sApgQYHIDWDqrfeOlHCjwjtAOodt.vDClAiMlNiJbvTViFQzaQzBGCRWh = IntPtr.Zero;
		sApgQYHIDWDqrfeOlHCjwjtAOodt.KjKhGKusMPbdeOZZhsCLLTNSlobS = 0;
		sApgQYHIDWDqrfeOlHCjwjtAOodt.ByyKSVVZzeJHUnlkMTpDdEdocynF = 0;
		ciSbQLLELPGAOigmeUJyIvrAKmqnA.qgXcjcONdntCoXdHpYFklYrLmQsm(sApgQYHIDWDqrfeOlHCjwjtAOodt);
	}

	private bool hNGajPImtpnSHNAxjKNdcNNsGnvAb()
	{
		if (DGiyiIHoVpmRosyFkuHxTNWoZWon >= 10)
		{
			return false;
		}
		if (!WQzbeRFUzCcwyBSCFDfwfiILPNdHA())
		{
			DGiyiIHoVpmRosyFkuHxTNWoZWon++;
			return false;
		}
		if (DGiyiIHoVpmRosyFkuHxTNWoZWon > 0)
		{
			DGiyiIHoVpmRosyFkuHxTNWoZWon = 0;
		}
		return true;
	}

	private bool WQzbeRFUzCcwyBSCFDfwfiILPNdHA()
	{
		if (VOwyNYEjhbIESaxCBcrkpAlXyOCgA != ShLxNDAuNJnTDKEaZHAvIhFLYQDS.hXYiniRQUQgqgoifAoCGkJYkSfKC)
		{
			return true;
		}
		if (!wkIGGWbLPIkJxoxBnGEVIZmcGvQac())
		{
			return false;
		}
		IntPtr intPtr = uBrmqrtoboLqIilEjDdEvcpBPEer.gWjGJUhMvvfdSztdGkHOvFhFxUtv(bLHkgcNpegOEnjrqEMHeEaPcjsNDA, ctOFTJFVBKiuzGJBAAphUVuqjMxQ.Overlapped, 3221225472u, hKqNTnjGuYYhXibhfhIzNpZPKuhD.ShareRead | hKqNTnjGuYYhXibhfhIzNpZPKuhD.ShareWrite);
		if (intPtr == ShLxNDAuNJnTDKEaZHAvIhFLYQDS.hXYiniRQUQgqgoifAoCGkJYkSfKC)
		{
			return false;
		}
		VOwyNYEjhbIESaxCBcrkpAlXyOCgA = intPtr;
		return true;
	}

	private void AUnQWLGsmZuHNzpuyvfDZhHKEJyz()
	{
		if (!(VOwyNYEjhbIESaxCBcrkpAlXyOCgA == ShLxNDAuNJnTDKEaZHAvIhFLYQDS.hXYiniRQUQgqgoifAoCGkJYkSfKC))
		{
			uBrmqrtoboLqIilEjDdEvcpBPEer.loNBgHHnJJMkGKStYGscmBCMLcfeA(VOwyNYEjhbIESaxCBcrkpAlXyOCgA);
			VOwyNYEjhbIESaxCBcrkpAlXyOCgA = ShLxNDAuNJnTDKEaZHAvIhFLYQDS.hXYiniRQUQgqgoifAoCGkJYkSfKC;
		}
	}

	[MonoPInvokeCallback(typeof(ShLxNDAuNJnTDKEaZHAvIhFLYQDS.lQEVtOJEmvgtlYlUWCRmGoHvjDpJA))]
	private static void FtCAPaEuBHcaScfwnHivaQYLhyWn(int P_0, int P_1, IntPtr P_2)
	{
	}

	public void Dispose()
	{
		UjWKTmRbyfYfjYmMTGQCVvKDONHE(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	protected virtual void AUwFCTGcNcDGEAjabJEwAtLPmWsw()
	{
		try
		{
			UjWKTmRbyfYfjYmMTGQCVvKDONHE(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	protected virtual void UjWKTmRbyfYfjYmMTGQCVvKDONHE(bool P_0)
	{
		if (QAYGpFGzcumqLoxdedPfdFKZHPSA)
		{
			return;
		}
		using (new Locker(QiOyOZlMYxMsOuObqBUfnqVstxz))
		{
			if (P_0)
			{
				ciSbQLLELPGAOigmeUJyIvrAKmqnA.Dispose();
				ObjectInstanceTracker.Default.Unregister(jCcFLYazereWbJjJhqwDlkqWlGYY);
			}
			AUnQWLGsmZuHNzpuyvfDZhHKEJyz();
			QAYGpFGzcumqLoxdedPfdFKZHPSA = true;
		}
	}

	[Conditional("DEBUGTHIS")]
	private void PfaEqTglEaCbARxKtHzrLcdgswhCb(string P_0)
	{
	}
}
