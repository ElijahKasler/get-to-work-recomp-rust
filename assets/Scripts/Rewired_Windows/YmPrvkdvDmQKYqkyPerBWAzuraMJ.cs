using System;
using System.Collections.Generic;
using System.Threading;
using Rewired;
using Rewired.Utils;

internal class YmPrvkdvDmQKYqkyPerBWAzuraMJ<_0001>
{
	private enum POSGRXjgOSsfeEbzmtiVDsDdvPjJA
	{
		Idle = 0,
		AwaitingResult = 1,
		ResultReceived = 2
	}

	private sealed class NXSDwiQpBaiAKKvaGgzQrIxJfOgh
	{
		private class VNJskNaqcVHEPaEomXAbKBeWHHAgb : IDisposable
		{
			private sealed class TlAjEdWkwXUyeWeVQFTabdMrbmVP
			{
				public VNJskNaqcVHEPaEomXAbKBeWHHAgb NTulbnhhvTBGTdCRMzKyPzQVSlJNA;

				public ManualResetEvent dsLFOkbyPtWQgMXbZKrxGxfeBrKVA;

				internal void lAMevMsxdyscraSZhRLsvNgHqOCG()
				{
					dsLFOkbyPtWQgMXbZKrxGxfeBrKVA.Set();
					NTulbnhhvTBGTdCRMzKyPzQVSlJNA.FsbTEcuQRXqlVDDZBhBUfDyajKtL();
				}
			}

			private readonly object nXiisgkdcAhMifhOyXnZgZheMtAtA;

			private List<WaitCallback> kprhGzdWIlGzfQwlDhzZuZQvwFVH;

			private List<WaitCallback> bWkbjdYZtpQBsVGkoBbczpIhzJow;

			private Thread xZtDMIseYKLreBCleiYtbjbpqzrFA;

			private AutoResetEvent tLPdIMBKReniEicHETpsoqaHbtOiA;

			private bool IYaNVlXmFZhhnuzhUHATeFzlhUdS;

			private bool wqJGVjwRphrBbNePGNGlCEegwyQt;

			private bool RJinvEmIelkNnJCbyallCbMubqTl;

			private bool JIWSnMkGKXQjetaJdTRVyxMYkKxL;

			public VNJskNaqcVHEPaEomXAbKBeWHHAgb()
			{
				nXiisgkdcAhMifhOyXnZgZheMtAtA = new object();
				kprhGzdWIlGzfQwlDhzZuZQvwFVH = new List<WaitCallback>();
				bWkbjdYZtpQBsVGkoBbczpIhzJow = new List<WaitCallback>();
				tLPdIMBKReniEicHETpsoqaHbtOiA = new AutoResetEvent(initialState: false);
			}

			public void vyurPNvvXRQHlNxGXwPDAHZBtIQP(WaitCallback P_0)
			{
				if (zlckTfwtpYcoHrgYhJCthtEtcyrE())
				{
					if (P_0 == null)
					{
						throw new ArgumentNullException("waitCallback");
					}
					lock (nXiisgkdcAhMifhOyXnZgZheMtAtA)
					{
						kprhGzdWIlGzfQwlDhzZuZQvwFVH.Add(P_0);
					}
					tLPdIMBKReniEicHETpsoqaHbtOiA.Set();
				}
			}

			public void HEpmcZkCmDCyhullgcwbexqiJeph()
			{
				AlxzYBkcWGbmwiXYawVgjSIgIMKZA();
			}

			public bool wOBZOkUjHsuSkuaVTpWCOhsBEPDm()
			{
				return zlckTfwtpYcoHrgYhJCthtEtcyrE();
			}

			private bool zlckTfwtpYcoHrgYhJCthtEtcyrE()
			{
				if (RJinvEmIelkNnJCbyallCbMubqTl)
				{
					return false;
				}
				if (wqJGVjwRphrBbNePGNGlCEegwyQt)
				{
					return false;
				}
				if (IYaNVlXmFZhhnuzhUHATeFzlhUdS)
				{
					return true;
				}
				if (xZtDMIseYKLreBCleiYtbjbpqzrFA != null)
				{
					return true;
				}
				return DjqlySvCvEXpSadbmEaOkBvlZJcrA();
			}

			private bool DjqlySvCvEXpSadbmEaOkBvlZJcrA()
			{
				TlAjEdWkwXUyeWeVQFTabdMrbmVP tlAjEdWkwXUyeWeVQFTabdMrbmVP = new TlAjEdWkwXUyeWeVQFTabdMrbmVP();
				tlAjEdWkwXUyeWeVQFTabdMrbmVP.NTulbnhhvTBGTdCRMzKyPzQVSlJNA = this;
				try
				{
					tlAjEdWkwXUyeWeVQFTabdMrbmVP.dsLFOkbyPtWQgMXbZKrxGxfeBrKVA = new ManualResetEvent(initialState: false);
					xZtDMIseYKLreBCleiYtbjbpqzrFA = new Thread(tlAjEdWkwXUyeWeVQFTabdMrbmVP.lAMevMsxdyscraSZhRLsvNgHqOCG);
					xZtDMIseYKLreBCleiYtbjbpqzrFA.Start();
					tlAjEdWkwXUyeWeVQFTabdMrbmVP.dsLFOkbyPtWQgMXbZKrxGxfeBrKVA.WaitOne();
					return true;
				}
				catch (Exception ex)
				{
					Logger.LogError("An exception occurred trying to initialize the thread pool.\n" + ex, requiredThreadSafety: true);
					xZtDMIseYKLreBCleiYtbjbpqzrFA = null;
					RJinvEmIelkNnJCbyallCbMubqTl = true;
					return false;
				}
			}

			private void FsbTEcuQRXqlVDDZBhBUfDyajKtL()
			{
				IYaNVlXmFZhhnuzhUHATeFzlhUdS = true;
				while (!wqJGVjwRphrBbNePGNGlCEegwyQt)
				{
					tLPdIMBKReniEicHETpsoqaHbtOiA.WaitOne();
					if (wqJGVjwRphrBbNePGNGlCEegwyQt)
					{
						break;
					}
					lock (nXiisgkdcAhMifhOyXnZgZheMtAtA)
					{
						MiscTools.Swap(ref kprhGzdWIlGzfQwlDhzZuZQvwFVH, ref bWkbjdYZtpQBsVGkoBbczpIhzJow);
					}
					List<WaitCallback> list = bWkbjdYZtpQBsVGkoBbczpIhzJow;
					int count = list.Count;
					if (count == 0)
					{
						continue;
					}
					for (int i = 0; i < count; i++)
					{
						try
						{
							list[i](null);
						}
						catch (Exception ex)
						{
							Logger.LogError("Exception occurred in thread pool callback.\n" + ex, requiredThreadSafety: true);
						}
					}
					list.Clear();
				}
				lock (nXiisgkdcAhMifhOyXnZgZheMtAtA)
				{
					kprhGzdWIlGzfQwlDhzZuZQvwFVH.Clear();
					bWkbjdYZtpQBsVGkoBbczpIhzJow.Clear();
				}
				wqJGVjwRphrBbNePGNGlCEegwyQt = false;
				IYaNVlXmFZhhnuzhUHATeFzlhUdS = false;
			}

			private void IWjMbSUsvgWwaZfqLYPNqwvGkkiE()
			{
				xZtDMIseYKLreBCleiYtbjbpqzrFA = null;
				RJinvEmIelkNnJCbyallCbMubqTl = false;
				wqJGVjwRphrBbNePGNGlCEegwyQt = true;
			}

			private void AlxzYBkcWGbmwiXYawVgjSIgIMKZA()
			{
				IWjMbSUsvgWwaZfqLYPNqwvGkkiE();
				try
				{
					tLPdIMBKReniEicHETpsoqaHbtOiA.Set();
				}
				catch (ObjectDisposedException)
				{
				}
			}

			public void Dispose()
			{
				bUTJgjnCERHbeTBNmquireSKtdZf(true);
				GC.SuppressFinalize(this);
			}

			void IDisposable.Dispose()
			{
				//ILSpy generated this explicit interface implementation from .override directive in Dispose
				this.Dispose();
			}

			protected virtual void bQFXPgEDcSguSsxaikqECUnwAuCK()
			{
				try
				{
					bUTJgjnCERHbeTBNmquireSKtdZf(false);
				}
				finally
				{
					base.Finalize();
				}
			}

			protected virtual void bUTJgjnCERHbeTBNmquireSKtdZf(bool P_0)
			{
				if (!JIWSnMkGKXQjetaJdTRVyxMYkKxL)
				{
					AlxzYBkcWGbmwiXYawVgjSIgIMKZA();
					JIWSnMkGKXQjetaJdTRVyxMYkKxL = true;
				}
			}
		}

		private static NXSDwiQpBaiAKKvaGgzQrIxJfOgh gUKspPGYwTXIHuSUzlvMpRFsPAtE;

		private VNJskNaqcVHEPaEomXAbKBeWHHAgb lyeqtddbSipwMZEHfBvRRqIUSZqh;

		private int zIwwJBkkIaQnDciwUPiCeOHpxLNx;

		private bool mhQGQbuqQxnbGuCEAxmrVtPrdvLp;

		private static NXSDwiQpBaiAKKvaGgzQrIxJfOgh LxWroQUdFVhaRuMlguduqEAuXfWl => pZiZSjaGNMSFUZSGKeGcuzIoCwRf();

		private VNJskNaqcVHEPaEomXAbKBeWHHAgb xxmcomCIJWZtGhRDywcrUpmwLDWtA => LbejRoMKRrOpazhnAWpWethPLXpE();

		private static NXSDwiQpBaiAKKvaGgzQrIxJfOgh pZiZSjaGNMSFUZSGKeGcuzIoCwRf()
		{
			return gUKspPGYwTXIHuSUzlvMpRFsPAtE ?? new NXSDwiQpBaiAKKvaGgzQrIxJfOgh();
		}

		private VNJskNaqcVHEPaEomXAbKBeWHHAgb LbejRoMKRrOpazhnAWpWethPLXpE()
		{
			return lyeqtddbSipwMZEHfBvRRqIUSZqh ?? (lyeqtddbSipwMZEHfBvRRqIUSZqh = new VNJskNaqcVHEPaEomXAbKBeWHHAgb());
		}

		private NXSDwiQpBaiAKKvaGgzQrIxJfOgh()
		{
			gUKspPGYwTXIHuSUzlvMpRFsPAtE?.NPAhVQmrydfnjhGLTdwcHORVMBnM();
			gUKspPGYwTXIHuSUzlvMpRFsPAtE = this;
		}

		private void EwMEQdHNFtguWoMqFmfUvCHlpBtbb()
		{
			zIwwJBkkIaQnDciwUPiCeOHpxLNx++;
		}

		private void HBxHSwjasGPDzDuedxpBdBdQBCRic()
		{
			zIwwJBkkIaQnDciwUPiCeOHpxLNx--;
			if (zIwwJBkkIaQnDciwUPiCeOHpxLNx < 0)
			{
				Logger.LogError("SharedThread: Too many calls to Unregister.", requiredThreadSafety: true);
			}
			if (zIwwJBkkIaQnDciwUPiCeOHpxLNx == 0)
			{
				NPAhVQmrydfnjhGLTdwcHORVMBnM();
			}
		}

		private void zlouBdURLDjCHinNygYgwCNvwQedA(WaitCallback P_0)
		{
			LbejRoMKRrOpazhnAWpWethPLXpE().vyurPNvvXRQHlNxGXwPDAHZBtIQP(P_0);
		}

		private void bHmyUIWuFSLVGElnVwlFZNatbakIA()
		{
			LbejRoMKRrOpazhnAWpWethPLXpE().HEpmcZkCmDCyhullgcwbexqiJeph();
		}

		private bool ocgBdNYZdiHEbloabivHYUIzpBBQ()
		{
			return LbejRoMKRrOpazhnAWpWethPLXpE().wOBZOkUjHsuSkuaVTpWCOhsBEPDm();
		}

		private void NPAhVQmrydfnjhGLTdwcHORVMBnM()
		{
			RCCEmbbTqimRFAWdgelDBHDyBKxwA(true);
			GC.SuppressFinalize(this);
		}

		protected void ZOhbzlklfvqETFLLgMoypgUnXdXp()
		{
			try
			{
				RCCEmbbTqimRFAWdgelDBHDyBKxwA(false);
			}
			finally
			{
				base.Finalize();
			}
		}

		private void RCCEmbbTqimRFAWdgelDBHDyBKxwA(bool P_0)
		{
			if (!mhQGQbuqQxnbGuCEAxmrVtPrdvLp)
			{
				if (P_0 && lyeqtddbSipwMZEHfBvRRqIUSZqh != null)
				{
					lyeqtddbSipwMZEHfBvRRqIUSZqh.Dispose();
					lyeqtddbSipwMZEHfBvRRqIUSZqh = null;
				}
				zIwwJBkkIaQnDciwUPiCeOHpxLNx = 0;
				if (gUKspPGYwTXIHuSUzlvMpRFsPAtE == this)
				{
					gUKspPGYwTXIHuSUzlvMpRFsPAtE = null;
				}
				mhQGQbuqQxnbGuCEAxmrVtPrdvLp = true;
			}
		}

		public static void VBrwNdMZthAvZKXNNeVcGKubHssG()
		{
			pZiZSjaGNMSFUZSGKeGcuzIoCwRf().EwMEQdHNFtguWoMqFmfUvCHlpBtbb();
		}

		public static void XQCYabyryPlKxaiGxzyZkbMBDxjE()
		{
			gUKspPGYwTXIHuSUzlvMpRFsPAtE?.HBxHSwjasGPDzDuedxpBdBdQBCRic();
		}

		public static void ZrsiQQySvztkSRMBYgIMjHuWjlGt(WaitCallback P_0)
		{
			pZiZSjaGNMSFUZSGKeGcuzIoCwRf().zlouBdURLDjCHinNygYgwCNvwQedA(P_0);
		}
	}

	private POSGRXjgOSsfeEbzmtiVDsDdvPjJA gXLxkFIGZpISInJbcpRkcQagyKqF;

	private _0001 pVFMPFZLoDulxatBFrpYJKtiIvuL;

	private WaitCallback cMPuLqAnPEcOOBBNspLLlpvkaYZt;

	private object xTkljHOEMxPrRwYvQNnBqZCMDTHJ;

	private Func<_0001> WrxaFqOphgxXeAeMLwkQDvKphgMs;

	private bool uTKiAGmpxehdFLGmiZrujzbjyjSd;

	private bool GDvgoQGVAnqEhqudJAutLWlNytgbA;

	public bool dlNSVmMPiWZdnQHsaJjpICOXHuLgA => WPvaYiDQVIYOIzrVogafDyizCCwab();

	public _0001 tEvqHqsMVYrbNLmPKilxgfZlcUVT => HqfMILYtqQfppDbQVFmQiUncDlYEA();

	public bool WPvaYiDQVIYOIzrVogafDyizCCwab()
	{
		if (gXLxkFIGZpISInJbcpRkcQagyKqF != POSGRXjgOSsfeEbzmtiVDsDdvPjJA.AwaitingResult)
		{
			return gXLxkFIGZpISInJbcpRkcQagyKqF == POSGRXjgOSsfeEbzmtiVDsDdvPjJA.ResultReceived;
		}
		return true;
	}

	public bool lDhzHQHlypMVlvNJXJYXaTpmInRJ()
	{
		bool num = gXLxkFIGZpISInJbcpRkcQagyKqF == POSGRXjgOSsfeEbzmtiVDsDdvPjJA.ResultReceived;
		if (num)
		{
			gXLxkFIGZpISInJbcpRkcQagyKqF = POSGRXjgOSsfeEbzmtiVDsDdvPjJA.Idle;
		}
		return num;
	}

	public _0001 HqfMILYtqQfppDbQVFmQiUncDlYEA()
	{
		return pVFMPFZLoDulxatBFrpYJKtiIvuL;
	}

	public YmPrvkdvDmQKYqkyPerBWAzuraMJ(bool P_0, Func<_0001> P_1)
	{
		uTKiAGmpxehdFLGmiZrujzbjyjSd = P_0;
		if (P_1 == null)
		{
			throw new ArgumentNullException("resultDelegate");
		}
		WrxaFqOphgxXeAeMLwkQDvKphgMs = P_1;
		cMPuLqAnPEcOOBBNspLLlpvkaYZt = sAHwKBeyYvKMzhvuonSGzFRheNdW;
		xTkljHOEMxPrRwYvQNnBqZCMDTHJ = new object();
		gXLxkFIGZpISInJbcpRkcQagyKqF = POSGRXjgOSsfeEbzmtiVDsDdvPjJA.Idle;
		if (P_0)
		{
			NXSDwiQpBaiAKKvaGgzQrIxJfOgh.VBrwNdMZthAvZKXNNeVcGKubHssG();
		}
	}

	public bool NXdyoJYyGKTPsFkwZEZMxMIDBxdK()
	{
		lock (xTkljHOEMxPrRwYvQNnBqZCMDTHJ)
		{
			if (gXLxkFIGZpISInJbcpRkcQagyKqF == POSGRXjgOSsfeEbzmtiVDsDdvPjJA.AwaitingResult)
			{
				return false;
			}
			pVFMPFZLoDulxatBFrpYJKtiIvuL = default;
			gXLxkFIGZpISInJbcpRkcQagyKqF = POSGRXjgOSsfeEbzmtiVDsDdvPjJA.AwaitingResult;
		}
		if (uTKiAGmpxehdFLGmiZrujzbjyjSd)
		{
			NXSDwiQpBaiAKKvaGgzQrIxJfOgh.ZrsiQQySvztkSRMBYgIMjHuWjlGt(cMPuLqAnPEcOOBBNspLLlpvkaYZt);
		}
		else
		{
			ThreadPool.QueueUserWorkItem(cMPuLqAnPEcOOBBNspLLlpvkaYZt, this);
		}
		return true;
	}

	public void hsPbiHSrnPbpgEvRSoRtcHgHVNpib()
	{
		lock (xTkljHOEMxPrRwYvQNnBqZCMDTHJ)
		{
			pVFMPFZLoDulxatBFrpYJKtiIvuL = default;
			gXLxkFIGZpISInJbcpRkcQagyKqF = POSGRXjgOSsfeEbzmtiVDsDdvPjJA.Idle;
		}
	}

	private void sAHwKBeyYvKMzhvuonSGzFRheNdW(object P_0)
	{
		lock (xTkljHOEMxPrRwYvQNnBqZCMDTHJ)
		{
			if (gXLxkFIGZpISInJbcpRkcQagyKqF == POSGRXjgOSsfeEbzmtiVDsDdvPjJA.AwaitingResult)
			{
				pVFMPFZLoDulxatBFrpYJKtiIvuL = WrxaFqOphgxXeAeMLwkQDvKphgMs();
				gXLxkFIGZpISInJbcpRkcQagyKqF = POSGRXjgOSsfeEbzmtiVDsDdvPjJA.ResultReceived;
			}
		}
	}

	public void ayepQoWiuxMOqMBzgIggIDNbAPap()
	{
		hgPlyLPGxTjRdhqVLLIIyvuqNjeA(true);
		GC.SuppressFinalize(this);
	}

	protected virtual void BwXNlmbbSnMlwwALbECQehiVjzRiA()
	{
		try
		{
			hgPlyLPGxTjRdhqVLLIIyvuqNjeA(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	protected virtual void hgPlyLPGxTjRdhqVLLIIyvuqNjeA(bool P_0)
	{
		if (!GDvgoQGVAnqEhqudJAutLWlNytgbA)
		{
			if (P_0)
			{
				hsPbiHSrnPbpgEvRSoRtcHgHVNpib();
			}
			if (uTKiAGmpxehdFLGmiZrujzbjyjSd)
			{
				NXSDwiQpBaiAKKvaGgzQrIxJfOgh.XQCYabyryPlKxaiGxzyZkbMBDxjE();
			}
			GDvgoQGVAnqEhqudJAutLWlNytgbA = true;
		}
	}
}
