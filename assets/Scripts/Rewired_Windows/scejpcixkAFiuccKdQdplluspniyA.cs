using System;
using System.Runtime.InteropServices;
using Rewired;
using Rewired.Utils.Attributes;

internal class scejpcixkAFiuccKdQdplluspniyA : IDisposable
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	private delegate IntPtr TTrXGqutJYDOnigOzncWDhkUFuJGA(int nCode, IntPtr wParam, IntPtr lParam);

	private struct WmOIzUXcKSaNyBnwQKYcaLEGJRzZb
	{
		public IntPtr NqGpvoabqAOkElVWptYReAQgYqbs;

		public IntPtr nrFBoUyeZVFPSMroLGTKPSxMxRyr;

		public uint ZjAvgEZZqBVtfxCyNDRtDZOSJnvH;

		public IntPtr dCfPlQbFsCkfyJsBScmQJlssYwKR;
	}

	private const int CKTROedtfhpmkpPjUigVJkrtrcSiA = 4;

	private static scejpcixkAFiuccKdQdplluspniyA qkUTOCvvDoQrEiTKDKjQfxPJjMCh;

	private IntPtr kADZhscQRxgnPhHHmYAMJfCTFonK = IntPtr.Zero;

	private TTrXGqutJYDOnigOzncWDhkUFuJGA DwSOqPDRzwvbprskzdcgUETMKOJL;

	private Action<koCuNclHbmFkvdKYFTAxiYZNnDUl, pAUvFzSdLOnVbevHysnEIlbHhQvR, uint, IntPtr> eGleltabFOXuCMGzfZoplBwMBdFB;

	private byte[] oMaGdzeBvaECQXnVnhtGkEPrbkXuA;

	private readonly bool keIgfevHioYbbNbOoxmIJEgonnpw;

	private WmOIzUXcKSaNyBnwQKYcaLEGJRzZb dILlzGMChTTuYawdWfvBqcHckkoy;

	private bool cvxaUeDgVbXPvtfKxsoWjAHHIPDFA;

	public scejpcixkAFiuccKdQdplluspniyA()
	{
		if (qkUTOCvvDoQrEiTKDKjQfxPJjMCh != null)
		{
			throw new Exception("Singleton instance already exists!");
		}
		qkUTOCvvDoQrEiTKDKjQfxPJjMCh = this;
		keIgfevHioYbbNbOoxmIJEgonnpw = IntPtr.Size == 8;
		oMaGdzeBvaECQXnVnhtGkEPrbkXuA = new byte[IntPtr.Size * 3 + 4];
	}

	public void tiBiLLsUfeKYOZBiFEzqMsNPajhjA(Action<koCuNclHbmFkvdKYFTAxiYZNnDUl, pAUvFzSdLOnVbevHysnEIlbHhQvR, uint, IntPtr> P_0, bool P_1)
	{
		eGleltabFOXuCMGzfZoplBwMBdFB = P_0;
		DwSOqPDRzwvbprskzdcgUETMKOJL = MyJjTRGmMfTmMSeXhUIOvIXOZqMr;
		uint num = 0u;
		if (P_1)
		{
			num = (uint)AppDomain.GetCurrentThreadId();
		}
		kADZhscQRxgnPhHHmYAMJfCTFonK = AvCxtxkLmxSHCZiPYDJoEUQQuLbE(4, DwSOqPDRzwvbprskzdcgUETMKOJL, IntPtr.Zero, num);
		if (kADZhscQRxgnPhHHmYAMJfCTFonK == IntPtr.Zero)
		{
			Logger.LogError("SetWindowsHookEx Failed");
		}
	}

	public void FUKeZrTADriDHJZgRgTqnvnxiOvs()
	{
		if (!(kADZhscQRxgnPhHHmYAMJfCTFonK == IntPtr.Zero))
		{
			if (!HChsLrvjVsGHiiRchPjNPKnODYkc(kADZhscQRxgnPhHHmYAMJfCTFonK))
			{
				Logger.LogError("UnhookWindowsHookEx Failed");
			}
			else
			{
				kADZhscQRxgnPhHHmYAMJfCTFonK = IntPtr.Zero;
			}
		}
	}

	[MonoPInvokeCallback(typeof(TTrXGqutJYDOnigOzncWDhkUFuJGA))]
	private static IntPtr MyJjTRGmMfTmMSeXhUIOvIXOZqMr(int P_0, IntPtr P_1, IntPtr P_2)
	{
		Marshal.Copy(P_2, qkUTOCvvDoQrEiTKDKjQfxPJjMCh.oMaGdzeBvaECQXnVnhtGkEPrbkXuA, 0, qkUTOCvvDoQrEiTKDKjQfxPJjMCh.oMaGdzeBvaECQXnVnhtGkEPrbkXuA.Length);
		int num = 0;
		qkUTOCvvDoQrEiTKDKjQfxPJjMCh.dILlzGMChTTuYawdWfvBqcHckkoy.NqGpvoabqAOkElVWptYReAQgYqbs = koCuNclHbmFkvdKYFTAxiYZNnDUl.WligOvACaqidkPgygAWPyXtfnpPUA(koCuNclHbmFkvdKYFTAxiYZNnDUl.DdkCLlMMLoZPVuGfhpWHKxSPSsge(qkUTOCvvDoQrEiTKDKjQfxPJjMCh.oMaGdzeBvaECQXnVnhtGkEPrbkXuA, num));
		num += koCuNclHbmFkvdKYFTAxiYZNnDUl.wCtKDKxaCCIEwjnuZTgmRthnYslqA;
		qkUTOCvvDoQrEiTKDKjQfxPJjMCh.dILlzGMChTTuYawdWfvBqcHckkoy.nrFBoUyeZVFPSMroLGTKPSxMxRyr = pAUvFzSdLOnVbevHysnEIlbHhQvR.ZvEPgFvcMARrqoNruBgBOVWNnEYW(pAUvFzSdLOnVbevHysnEIlbHhQvR.cONfOlFBruRRezuAueAYdyiFnOCnA(qkUTOCvvDoQrEiTKDKjQfxPJjMCh.oMaGdzeBvaECQXnVnhtGkEPrbkXuA, num));
		num += pAUvFzSdLOnVbevHysnEIlbHhQvR.VxparQtdwLOgaAoqOoAqfgzdUvQC;
		qkUTOCvvDoQrEiTKDKjQfxPJjMCh.dILlzGMChTTuYawdWfvBqcHckkoy.ZjAvgEZZqBVtfxCyNDRtDZOSJnvH = BitConverter.ToUInt32(qkUTOCvvDoQrEiTKDKjQfxPJjMCh.oMaGdzeBvaECQXnVnhtGkEPrbkXuA, num);
		num += 4;
		if (qkUTOCvvDoQrEiTKDKjQfxPJjMCh.keIgfevHioYbbNbOoxmIJEgonnpw)
		{
			qkUTOCvvDoQrEiTKDKjQfxPJjMCh.dILlzGMChTTuYawdWfvBqcHckkoy.dCfPlQbFsCkfyJsBScmQJlssYwKR = new IntPtr(BitConverter.ToInt32(qkUTOCvvDoQrEiTKDKjQfxPJjMCh.oMaGdzeBvaECQXnVnhtGkEPrbkXuA, num + 4));
		}
		else
		{
			qkUTOCvvDoQrEiTKDKjQfxPJjMCh.dILlzGMChTTuYawdWfvBqcHckkoy.dCfPlQbFsCkfyJsBScmQJlssYwKR = new IntPtr(BitConverter.ToInt32(qkUTOCvvDoQrEiTKDKjQfxPJjMCh.oMaGdzeBvaECQXnVnhtGkEPrbkXuA, num));
		}
		if (P_0 >= 0)
		{
			qkUTOCvvDoQrEiTKDKjQfxPJjMCh.eGleltabFOXuCMGzfZoplBwMBdFB(koCuNclHbmFkvdKYFTAxiYZNnDUl.MiXgrCPvkdWTEeppHHIfIdlkaUSr(qkUTOCvvDoQrEiTKDKjQfxPJjMCh.dILlzGMChTTuYawdWfvBqcHckkoy.NqGpvoabqAOkElVWptYReAQgYqbs), pAUvFzSdLOnVbevHysnEIlbHhQvR.kFtnUfoVkfEDhtNemdyZxjJrIKVIA(qkUTOCvvDoQrEiTKDKjQfxPJjMCh.dILlzGMChTTuYawdWfvBqcHckkoy.nrFBoUyeZVFPSMroLGTKPSxMxRyr), qkUTOCvvDoQrEiTKDKjQfxPJjMCh.dILlzGMChTTuYawdWfvBqcHckkoy.ZjAvgEZZqBVtfxCyNDRtDZOSJnvH, qkUTOCvvDoQrEiTKDKjQfxPJjMCh.dILlzGMChTTuYawdWfvBqcHckkoy.dCfPlQbFsCkfyJsBScmQJlssYwKR);
		}
		return qEsYLMtMQwewuyGjvWeGaHYadvnBA(qkUTOCvvDoQrEiTKDKjQfxPJjMCh.kADZhscQRxgnPhHHmYAMJfCTFonK, P_0, P_1, P_2);
	}

	public void Dispose()
	{
		cSAgyPIiKcecZFJcvAVIAsrKGHBQA(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	protected virtual void DeZhlBnWJhmTKkQyobAwyqvmzbDj()
	{
		try
		{
			cSAgyPIiKcecZFJcvAVIAsrKGHBQA(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	protected virtual void cSAgyPIiKcecZFJcvAVIAsrKGHBQA(bool P_0)
	{
		if (!cvxaUeDgVbXPvtfKxsoWjAHHIPDFA)
		{
			FUKeZrTADriDHJZgRgTqnvnxiOvs();
			if (qkUTOCvvDoQrEiTKDKjQfxPJjMCh == this)
			{
				qkUTOCvvDoQrEiTKDKjQfxPJjMCh = null;
			}
			cvxaUeDgVbXPvtfKxsoWjAHHIPDFA = true;
		}
	}

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode, EntryPoint = "SetWindowsHookEx")]
	private static extern IntPtr AvCxtxkLmxSHCZiPYDJoEUQQuLbE(int P_0, TTrXGqutJYDOnigOzncWDhkUFuJGA P_1, IntPtr P_2, uint P_3);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode, EntryPoint = "UnhookWindowsHookEx")]
	private static extern bool HChsLrvjVsGHiiRchPjNPKnODYkc(IntPtr P_0);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode, EntryPoint = "CallNextHookEx")]
	private static extern IntPtr qEsYLMtMQwewuyGjvWeGaHYadvnBA(IntPtr P_0, int P_1, IntPtr P_2, IntPtr P_3);
}
