using System;
using System.Collections.Generic;
using Rewired;
using Rewired.Utils;
using Rewired.Utils.Classes.Utility;

internal class HQIsBZzZBZNkXyxgoCGYuklcCJbfA : IDisposable
{
	private class JGCaoJatVVGPaqcAcSwwFuoAaQMp
	{
		public int aDYSQIXnhUEJbfYVmsEGAGZEwMntA;

		public int ilsDOUPuAKqyPuHBljbkiAiPGPPJ;

		public uint VpaLHVinoaJDSHccMaLFXpoIrLTiA;

		public object BhEGjBcdxXEROVLtrqKdhWTOCLXo;

		public void EeiJXofuJQDZQZJwkkctLjttEmzO(int P_0, int P_1, uint P_2, object P_3)
		{
			aDYSQIXnhUEJbfYVmsEGAGZEwMntA = P_0;
			ilsDOUPuAKqyPuHBljbkiAiPGPPJ = P_1;
			VpaLHVinoaJDSHccMaLFXpoIrLTiA = P_2;
			BhEGjBcdxXEROVLtrqKdhWTOCLXo = P_3;
		}

		public void XnrBLEfKAqckWdsKtrekNVyuRiKP()
		{
			BhEGjBcdxXEROVLtrqKdhWTOCLXo = null;
		}
	}

	[Serializable]
	private sealed class sPCuyEVFuoQhqeYKdNlBIaQuTOtx
	{
		public static readonly sPCuyEVFuoQhqeYKdNlBIaQuTOtx _003C_003E9 = new sPCuyEVFuoQhqeYKdNlBIaQuTOtx();

		public static Func<JGCaoJatVVGPaqcAcSwwFuoAaQMp> _003C_003E9__6_0;

		public static Action<JGCaoJatVVGPaqcAcSwwFuoAaQMp> _003C_003E9__6_1;

		internal JGCaoJatVVGPaqcAcSwwFuoAaQMp MQARUUTUPjKHbyKARgzkWbkWgEht()
		{
			return new JGCaoJatVVGPaqcAcSwwFuoAaQMp();
		}

		internal void UEkFpovLnQbtAjYUZeTcMbYVSMbuA(JGCaoJatVVGPaqcAcSwwFuoAaQMp P_0)
		{
			P_0.XnrBLEfKAqckWdsKtrekNVyuRiKP();
		}
	}

	private nGmHJBDkYYdTCONkFlbkXsaMwQZL SsyHpxbGfttSbwUPfGMfQgfuCdUgA;

	private ObjectPool<JGCaoJatVVGPaqcAcSwwFuoAaQMp> gCPrkcopeeWhZbGuDuGaELBEfcgA;

	private Queue<JGCaoJatVVGPaqcAcSwwFuoAaQMp> VGlpRKyGhrPJbBVvemIfmeajiumDA;

	private Action<object> xrknweXemfRGvHydZSrvbVBKFSli;

	private bool SUVNtSIssKAELPdCOuufYCaCNqyl;

	public bool NZURLNdshZPJXNMXgvPdNfmQfujE => kecijzJSLdBByUnQKfmiFqFUNdYj();

	public bool kecijzJSLdBByUnQKfmiFqFUNdYj()
	{
		return QjyQqzURfaiscTHEEKCQrgYsawxR();
	}

	public HQIsBZzZBZNkXyxgoCGYuklcCJbfA(int P_0, int P_1, Action<object> P_2 = null)
	{
		if (P_0 <= 0)
		{
			throw new ArgumentOutOfRangeException("capacity");
		}
		SsyHpxbGfttSbwUPfGMfQgfuCdUgA = new nGmHJBDkYYdTCONkFlbkXsaMwQZL(P_0);
		gCPrkcopeeWhZbGuDuGaELBEfcgA = new ObjectPool<JGCaoJatVVGPaqcAcSwwFuoAaQMp>(P_1, sPCuyEVFuoQhqeYKdNlBIaQuTOtx._003C_003E9.MQARUUTUPjKHbyKARgzkWbkWgEht, sPCuyEVFuoQhqeYKdNlBIaQuTOtx._003C_003E9.UEkFpovLnQbtAjYUZeTcMbYVSMbuA);
		VGlpRKyGhrPJbBVvemIfmeajiumDA = new Queue<JGCaoJatVVGPaqcAcSwwFuoAaQMp>(P_1);
		xrknweXemfRGvHydZSrvbVBKFSli = P_2;
	}

	public unsafe bool OAZpeTIRqEROAxIGcRGPkwFPqzaN(byte* P_0, int P_1, object P_2)
	{
		if (P_0 == null || P_1 <= 0)
		{
			return false;
		}
		if (SsyHpxbGfttSbwUPfGMfQgfuCdUgA.PwlgRXEpacEUsEUMaqUzwZLnrgIeA(P_0, P_1, P_1, out var num, out var num2) < P_1)
		{
			return false;
		}
		JGCaoJatVVGPaqcAcSwwFuoAaQMp jGCaoJatVVGPaqcAcSwwFuoAaQMp = gCPrkcopeeWhZbGuDuGaELBEfcgA.Get();
		jGCaoJatVVGPaqcAcSwwFuoAaQMp.EeiJXofuJQDZQZJwkkctLjttEmzO(num, P_1, num2, P_2);
		VGlpRKyGhrPJbBVvemIfmeajiumDA.Enqueue(jGCaoJatVVGPaqcAcSwwFuoAaQMp);
		return true;
	}

	public unsafe bool dAdITfiExueFJhAWsrrCeUbOoycJ(byte* P_0, int P_1)
	{
		return OAZpeTIRqEROAxIGcRGPkwFPqzaN(P_0, P_1, null);
	}

	public unsafe bool THBqyHGWIXraHycZHnlbXULLIdps(IntPtr P_0, int P_1, object P_2)
	{
		if (P_0 == IntPtr.Zero || P_1 <= 0)
		{
			return false;
		}
		return OAZpeTIRqEROAxIGcRGPkwFPqzaN((byte*)(void*)P_0, P_1, P_2);
	}

	public bool SCcrddKzXvoLxcEaOiOkxleuJPPR(IntPtr P_0, int P_1)
	{
		return THBqyHGWIXraHycZHnlbXULLIdps(P_0, P_1, null);
	}

	public unsafe bool ICghFCeMlLMUYBtWEhcZcRvRrVAhc(byte[] P_0, int P_1, object P_2, int P_3 = 0)
	{
		if (P_0 == null || P_1 > P_0.Length)
		{
			return false;
		}
		if (P_3 < 0)
		{
			P_3 = 0;
		}
		if (P_3 + P_1 > P_0.Length)
		{
			return false;
		}
		fixed (byte* ptr = P_0)
		{
			byte* ptr2 = ptr + P_3;
			return OAZpeTIRqEROAxIGcRGPkwFPqzaN(ptr2, P_1, P_2);
		}
	}

	public bool TubvLbJWxKCnMClOLawLNPfdLXBR(byte[] P_0, int P_1, int P_2 = 0)
	{
		return ICghFCeMlLMUYBtWEhcZcRvRrVAhc(P_0, P_1, null, P_2);
	}

	public unsafe int yttZxooXsHIkeHflizIdJWhWiBwG(byte* P_0, int P_1, out object P_2)
	{
		if (P_0 == null || P_1 <= 0)
		{
			P_2 = null;
			return -1;
		}
		JGCaoJatVVGPaqcAcSwwFuoAaQMp jGCaoJatVVGPaqcAcSwwFuoAaQMp = UJkUjsWPjvXfrPyKMLcpasygxEzK(false);
		if (jGCaoJatVVGPaqcAcSwwFuoAaQMp == null)
		{
			P_2 = null;
			return -1;
		}
		if (P_1 < jGCaoJatVVGPaqcAcSwwFuoAaQMp.ilsDOUPuAKqyPuHBljbkiAiPGPPJ)
		{
			Logger.LogError("The buffer is too small to hold the data. Call PeekDataLength before calling Peek to get the data length.", requiredThreadSafety: true);
			P_2 = null;
			return -1;
		}
		int num = SsyHpxbGfttSbwUPfGMfQgfuCdUgA.zXrCHSEuFcvNWPWVZYYBHxamQAuc(P_0, P_1, jGCaoJatVVGPaqcAcSwwFuoAaQMp.ilsDOUPuAKqyPuHBljbkiAiPGPPJ, jGCaoJatVVGPaqcAcSwwFuoAaQMp.aDYSQIXnhUEJbfYVmsEGAGZEwMntA);
		if (num != jGCaoJatVVGPaqcAcSwwFuoAaQMp.ilsDOUPuAKqyPuHBljbkiAiPGPPJ)
		{
			Logger.LogError("Failure reading data from buffer!", requiredThreadSafety: true);
			num = 0;
			P_2 = null;
			return -1;
		}
		P_2 = jGCaoJatVVGPaqcAcSwwFuoAaQMp.BhEGjBcdxXEROVLtrqKdhWTOCLXo;
		return num;
	}

	public unsafe int uAiMRcElatCOedsFsgOttmTvPIyjA(byte* P_0, int P_1)
	{
		object obj;
		return yttZxooXsHIkeHflizIdJWhWiBwG(P_0, P_1, out obj);
	}

	public unsafe int ggwyCSifruDEHeVtKcoMmYJfKplaA(IntPtr P_0, int P_1, out object P_2)
	{
		if (P_0 == IntPtr.Zero || P_1 <= 0)
		{
			P_2 = null;
			return -1;
		}
		return yttZxooXsHIkeHflizIdJWhWiBwG((byte*)(void*)P_0, P_1, out P_2);
	}

	public int UAbcjmjmTGbiFdybALIAbUaZtaCHb(IntPtr P_0, int P_1)
	{
		object obj;
		return ggwyCSifruDEHeVtKcoMmYJfKplaA(P_0, P_1, out obj);
	}

	public unsafe int obyclzYGeIGHNentIIiNEBpFgHQIc(byte[] P_0, out object P_1)
	{
		if (P_0 == null || P_0.Length == 0)
		{
			P_1 = null;
			return -1;
		}
		fixed (byte* ptr = P_0)
		{
			return yttZxooXsHIkeHflizIdJWhWiBwG(ptr, P_0.Length, out P_1);
		}
	}

	public int UmzhUWIPgtQEioSFLmDbApDuECKL(byte[] P_0)
	{
		object obj;
		return obyclzYGeIGHNentIIiNEBpFgHQIc(P_0, out obj);
	}

	public int ctudhCUcKlKwoKgMrcVnCcAkPlZc()
	{
		return UJkUjsWPjvXfrPyKMLcpasygxEzK(false)?.ilsDOUPuAKqyPuHBljbkiAiPGPPJ ?? (-1);
	}

	public unsafe int euHeKxkvnFcLLAfPHYMbdwaFMWiYc(byte* P_0, int P_1, out object P_2)
	{
		if (P_0 == null || P_1 <= 0)
		{
			P_2 = null;
			return -1;
		}
		JGCaoJatVVGPaqcAcSwwFuoAaQMp jGCaoJatVVGPaqcAcSwwFuoAaQMp = UJkUjsWPjvXfrPyKMLcpasygxEzK(true);
		if (jGCaoJatVVGPaqcAcSwwFuoAaQMp == null)
		{
			P_2 = null;
			return -1;
		}
		if (P_1 < jGCaoJatVVGPaqcAcSwwFuoAaQMp.ilsDOUPuAKqyPuHBljbkiAiPGPPJ)
		{
			Logger.LogError("The buffer is too small to hold the data. Call PeekDataLength before calling Dequeue to get the data length.", requiredThreadSafety: true);
			P_2 = null;
			SFjXKMnGjNXXuxmUncbIvdaEiHIAA(jGCaoJatVVGPaqcAcSwwFuoAaQMp, true);
			return -1;
		}
		int num = SsyHpxbGfttSbwUPfGMfQgfuCdUgA.zXrCHSEuFcvNWPWVZYYBHxamQAuc(P_0, P_1, jGCaoJatVVGPaqcAcSwwFuoAaQMp.ilsDOUPuAKqyPuHBljbkiAiPGPPJ, jGCaoJatVVGPaqcAcSwwFuoAaQMp.aDYSQIXnhUEJbfYVmsEGAGZEwMntA);
		if (num != jGCaoJatVVGPaqcAcSwwFuoAaQMp.ilsDOUPuAKqyPuHBljbkiAiPGPPJ)
		{
			Logger.LogError("Failure reading data from buffer!", requiredThreadSafety: true);
			P_2 = null;
			SFjXKMnGjNXXuxmUncbIvdaEiHIAA(jGCaoJatVVGPaqcAcSwwFuoAaQMp, true);
			return -1;
		}
		P_2 = jGCaoJatVVGPaqcAcSwwFuoAaQMp.BhEGjBcdxXEROVLtrqKdhWTOCLXo;
		SFjXKMnGjNXXuxmUncbIvdaEiHIAA(jGCaoJatVVGPaqcAcSwwFuoAaQMp, false);
		return num;
	}

	public unsafe int SSYnlKyAWePrBWDcORwskANJDYpfA(byte* P_0, int P_1)
	{
		object obj;
		return euHeKxkvnFcLLAfPHYMbdwaFMWiYc(P_0, P_1, out obj);
	}

	public unsafe int EZsnmREVCfLSpvvBBJqzNZlHNcvr(IntPtr P_0, int P_1, out object P_2)
	{
		if (P_0 == IntPtr.Zero || P_1 <= 0)
		{
			P_2 = null;
			return -1;
		}
		return euHeKxkvnFcLLAfPHYMbdwaFMWiYc((byte*)(void*)P_0, P_1, out P_2);
	}

	public int hSdWBOlsDcnMVKmJmiownmawjWVhA(IntPtr P_0, int P_1)
	{
		object obj;
		return EZsnmREVCfLSpvvBBJqzNZlHNcvr(P_0, P_1, out obj);
	}

	public unsafe int AAHGEuGivCzdKwkiICRKgrCwoUtK(byte[] P_0, out object P_1)
	{
		if (P_0 == null || P_0.Length == 0)
		{
			P_1 = null;
			return -1;
		}
		fixed (byte* ptr = P_0)
		{
			return euHeKxkvnFcLLAfPHYMbdwaFMWiYc(ptr, P_0.Length, out P_1);
		}
	}

	public int GnzTmLYbVQfJEDwPUQPPwVYLbzqT(byte[] P_0)
	{
		object obj;
		return AAHGEuGivCzdKwkiICRKgrCwoUtK(P_0, out obj);
	}

	public void aJUeeuIeTbYRmmWIymvuaDdhJWBdA()
	{
		SsyHpxbGfttSbwUPfGMfQgfuCdUgA.vzRCzJdTZSLzBZQvWuOGrGQmpvwF();
		while (VGlpRKyGhrPJbBVvemIfmeajiumDA.Count > 0)
		{
			SFjXKMnGjNXXuxmUncbIvdaEiHIAA(VGlpRKyGhrPJbBVvemIfmeajiumDA.Dequeue(), true);
		}
	}

	private JGCaoJatVVGPaqcAcSwwFuoAaQMp UJkUjsWPjvXfrPyKMLcpasygxEzK(bool P_0)
	{
		while (VGlpRKyGhrPJbBVvemIfmeajiumDA.Count > 0)
		{
			JGCaoJatVVGPaqcAcSwwFuoAaQMp jGCaoJatVVGPaqcAcSwwFuoAaQMp = (P_0 ? VGlpRKyGhrPJbBVvemIfmeajiumDA.Dequeue() : VGlpRKyGhrPJbBVvemIfmeajiumDA.Peek());
			if (SsyHpxbGfttSbwUPfGMfQgfuCdUgA.ETcZJjzSMLfRDnMNOrNknOSXXQrh(jGCaoJatVVGPaqcAcSwwFuoAaQMp.aDYSQIXnhUEJbfYVmsEGAGZEwMntA, jGCaoJatVVGPaqcAcSwwFuoAaQMp.VpaLHVinoaJDSHccMaLFXpoIrLTiA))
			{
				return jGCaoJatVVGPaqcAcSwwFuoAaQMp;
			}
			if (!P_0)
			{
				jGCaoJatVVGPaqcAcSwwFuoAaQMp = VGlpRKyGhrPJbBVvemIfmeajiumDA.Dequeue();
			}
			SFjXKMnGjNXXuxmUncbIvdaEiHIAA(jGCaoJatVVGPaqcAcSwwFuoAaQMp, true);
		}
		return null;
	}

	private bool QjyQqzURfaiscTHEEKCQrgYsawxR()
	{
		return UJkUjsWPjvXfrPyKMLcpasygxEzK(false) != null;
	}

	private void SFjXKMnGjNXXuxmUncbIvdaEiHIAA(JGCaoJatVVGPaqcAcSwwFuoAaQMp P_0, bool P_1)
	{
		if (P_0 != null)
		{
			if (P_1 && xrknweXemfRGvHydZSrvbVBKFSli != null && P_0.BhEGjBcdxXEROVLtrqKdhWTOCLXo != null)
			{
				xrknweXemfRGvHydZSrvbVBKFSli(P_0.BhEGjBcdxXEROVLtrqKdhWTOCLXo);
			}
			gCPrkcopeeWhZbGuDuGaELBEfcgA.Return(P_0);
		}
	}

	public void Dispose()
	{
		xUnlPMWvWBVPtEctwCyZsLdpCDFp(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	protected virtual void EkeEuafGxBgacibgBCvoLeiohGTP()
	{
		try
		{
			xUnlPMWvWBVPtEctwCyZsLdpCDFp(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	protected void xUnlPMWvWBVPtEctwCyZsLdpCDFp(bool P_0)
	{
		if (SUVNtSIssKAELPdCOuufYCaCNqyl)
		{
			return;
		}
		if (P_0)
		{
			aJUeeuIeTbYRmmWIymvuaDdhJWBdA();
			if (SsyHpxbGfttSbwUPfGMfQgfuCdUgA != null)
			{
				SsyHpxbGfttSbwUPfGMfQgfuCdUgA.Dispose();
			}
		}
		SUVNtSIssKAELPdCOuufYCaCNqyl = true;
	}

	public static bool yiGvIiyspoaNQqkqxsPUCMBZYEJe(HQIsBZzZBZNkXyxgoCGYuklcCJbfA P_0, HQIsBZzZBZNkXyxgoCGYuklcCJbfA P_1)
	{
		if (P_0 == null || P_1 == null)
		{
			return false;
		}
		MiscTools.Swap(ref P_0.SsyHpxbGfttSbwUPfGMfQgfuCdUgA, ref P_1.SsyHpxbGfttSbwUPfGMfQgfuCdUgA);
		MiscTools.Swap(ref P_0.gCPrkcopeeWhZbGuDuGaELBEfcgA, ref P_1.gCPrkcopeeWhZbGuDuGaELBEfcgA);
		MiscTools.Swap(ref P_0.VGlpRKyGhrPJbBVvemIfmeajiumDA, ref P_1.VGlpRKyGhrPJbBVvemIfmeajiumDA);
		return true;
	}
}
