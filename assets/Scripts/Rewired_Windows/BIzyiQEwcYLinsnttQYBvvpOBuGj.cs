using System;
using System.Collections.Generic;
using Rewired;
using Rewired.Config;
using Rewired.Data.Mapping;
using Rewired.Interfaces;
using Rewired.Utils;
using Rewired.Utils.Classes.Utility;
using UnityEngine;

internal class BIzyiQEwcYLinsnttQYBvvpOBuGj : IUnifiedMouseSource, IGetSetEnabled, IDisposable
{
	private class EoRQfDJjqevdgQiWxwwcPUzUVpLj
	{
		private enum ZHlWBRgjoCoNisndJoYqnypreGCQ
		{
			None = 0,
			Down = 1,
			Up = 2,
			DownAndUp = 3
		}

		private const int RYHQUhrLkLiTuQwuIvhFunenucKF = 120;

		private const int zpcxXdrVnRCtdHOOcuFPAOcMCjjt = 2048;

		public readonly UpdateLoopType tkMZsffBZbBjNwKUGOoXUAQOezxN;

		public uint DMunZLYPhxNIcjhyfDRFhZzqHkdJ;

		public uint NyUGJKDouJNCpQexdkwmfzqvnmaM;

		public lwjtiAdHkKgQWaCfnTGfaaGsJZct XatFHOxOBeenTBVDxDKACTuZEsAFA;

		public float OatCXLesoxAbZzSDisPfTFIewQuFA;

		public float nRnioyzYmQuNXEGiTQtQhtiHiymf;

		public float jhQpBrnGWKzPSCnyBWsbOpVcIYCd;

		public float FuRZTOnHHwVDGzHeqtyursInBEMJ;

		private bool[] JxMRwIOXGggBcmlDHfltdEWYulcgA;

		private bool[] rfAZcaEhhNoJgryfpbBScpshhqKj;

		private ZVmCEmeaNnkiCGDsGSMXkYApDzGpb vfHNGNCdkYXxEVSIWFGuxyLKKrDU;

		private uint DkFymymSAjAmuNjNWAPsqvMjODaK;

		private int irlRyNiebGPcfZuWMyqEjhNuuMCf;

		private int BUwQiFgoMVCMzISxGUTtbysJprxC;

		private bool ZEjxPZKkFozFpNAwwvIIlzoWTMsK;

		public EoRQfDJjqevdgQiWxwwcPUzUVpLj(ZVmCEmeaNnkiCGDsGSMXkYApDzGpb P_0, UpdateLoopType P_1)
		{
			vfHNGNCdkYXxEVSIWFGuxyLKKrDU = P_0;
			tkMZsffBZbBjNwKUGOoXUAQOezxN = P_1;
			JxMRwIOXGggBcmlDHfltdEWYulcgA = new bool[5];
			rfAZcaEhhNoJgryfpbBScpshhqKj = new bool[5];
		}

		public void pUVSpUuMpazVfmWynGVCMdhhXLOe(hgdFADROZeRoloFIwqQBhNJiOdEJ P_0)
		{
			qfOwMFUhPVeGZDVVWvpJmcSVCyiZ qfOwMFUhPVeGZDVVWvpJmcSVCyiZ2 = P_0.AdpjYoCzaZXPOlxLOhvkpVyhZSTN;
			if (qfOwMFUhPVeGZDVVWvpJmcSVCyiZ2 != qfOwMFUhPVeGZDVVWvpJmcSVCyiZ.None)
			{
				if ((qfOwMFUhPVeGZDVVWvpJmcSVCyiZ2 & qfOwMFUhPVeGZDVVWvpJmcSVCyiZ.LeftButtonDown) != qfOwMFUhPVeGZDVVWvpJmcSVCyiZ.None || (qfOwMFUhPVeGZDVVWvpJmcSVCyiZ2 & qfOwMFUhPVeGZDVVWvpJmcSVCyiZ.RightButtonDown) != qfOwMFUhPVeGZDVVWvpJmcSVCyiZ.None)
				{
					IntPtr intPtr = iZtZloELsoaMBDRDTiszzpwtPjDd.ZHebZlPknMWIRGDCJrAPSeRLEbvp();
					if (iZtZloELsoaMBDRDTiszzpwtPjDd.mXEkaNcGmWKTpdexOWkopORPRUhj() == intPtr && YbVmzZhKuVTkUelWxhRxvxyrbgNy(intPtr))
					{
						qfOwMFUhPVeGZDVVWvpJmcSVCyiZ2 &= ~qfOwMFUhPVeGZDVVWvpJmcSVCyiZ.LeftButtonDown;
						qfOwMFUhPVeGZDVVWvpJmcSVCyiZ2 &= ~qfOwMFUhPVeGZDVVWvpJmcSVCyiZ.RightButtonDown;
					}
				}
				int num = (int)qfOwMFUhPVeGZDVVWvpJmcSVCyiZ2;
				if (vfHNGNCdkYXxEVSIWFGuxyLKKrDU.apMEYMbIJZXsoHoBfONbMjOdsnEe() && vfHNGNCdkYXxEVSIWFGuxyLKKrDU.SQsZWIWlPXPhQVjHYCgCTudUvbUm())
				{
					KpSNysfDIecnFwAiqLxKoBbsgDTg(1, num, 1, 2);
					KpSNysfDIecnFwAiqLxKoBbsgDTg(0, num, 4, 8);
				}
				else
				{
					KpSNysfDIecnFwAiqLxKoBbsgDTg(0, num, 1, 2);
					KpSNysfDIecnFwAiqLxKoBbsgDTg(1, num, 4, 8);
				}
				KpSNysfDIecnFwAiqLxKoBbsgDTg(2, num, 16, 32);
				KpSNysfDIecnFwAiqLxKoBbsgDTg(3, num, 64, 128);
				KpSNysfDIecnFwAiqLxKoBbsgDTg(4, num, 256, 512);
			}
			DMunZLYPhxNIcjhyfDRFhZzqHkdJ = P_0.RfKwTECATluMOFESoCbKIsbyqeXtA;
			NyUGJKDouJNCpQexdkwmfzqvnmaM = P_0.rAZnCFdifwvJbtIOcGIizvoRhyNU;
			lwjtiAdHkKgQWaCfnTGfaaGsJZct xatFHOxOBeenTBVDxDKACTuZEsAFA = XatFHOxOBeenTBVDxDKACTuZEsAFA;
			XatFHOxOBeenTBVDxDKACTuZEsAFA = P_0.qKbMQxuZuEBpKUhcduTqJFreWRlP;
			if (XatFHOxOBeenTBVDxDKACTuZEsAFA != xatFHOxOBeenTBVDxDKACTuZEsAFA)
			{
				ZEjxPZKkFozFpNAwwvIIlzoWTMsK = false;
			}
			if (XatFHOxOBeenTBVDxDKACTuZEsAFA == lwjtiAdHkKgQWaCfnTGfaaGsJZct.MoveRelative)
			{
				OatCXLesoxAbZzSDisPfTFIewQuFA += (float)P_0.mEsNhmgLhZAalvaUKxSfLRcQebPA * 0.5f;
				nRnioyzYmQuNXEGiTQtQhtiHiymf += (float)P_0.DvIGOWCqXoNImNJUlcPYFoufuffEb * 0.5f * -1f;
			}
			else if ((XatFHOxOBeenTBVDxDKACTuZEsAFA & lwjtiAdHkKgQWaCfnTGfaaGsJZct.MoveAbsolute) != lwjtiAdHkKgQWaCfnTGfaaGsJZct.MoveRelative)
			{
				bool num2 = (XatFHOxOBeenTBVDxDKACTuZEsAFA & lwjtiAdHkKgQWaCfnTGfaaGsJZct.VirtualDesktop) != 0;
				int num3 = iZtZloELsoaMBDRDTiszzpwtPjDd.IZogZeXadZkmTWhjTfNFMlnTMyIH(num2 ? WEJzDPEhNQNZrfcPrLAlSuuEoShk.DoWvnhsnyqzWqeCdHlERajPlrqNF : WEJzDPEhNQNZrfcPrLAlSuuEoShk.VwCGrlqdSrorsFLYYGRdJBscNRRU);
				int num4 = iZtZloELsoaMBDRDTiszzpwtPjDd.IZogZeXadZkmTWhjTfNFMlnTMyIH(num2 ? WEJzDPEhNQNZrfcPrLAlSuuEoShk.ADtiNDFvxaPRTVZxNlzPOTRBlOfpA : WEJzDPEhNQNZrfcPrLAlSuuEoShk.DQwPVbjWvGKvalqPlMOgwciLRMVw);
				int num5 = (int)((float)P_0.mEsNhmgLhZAalvaUKxSfLRcQebPA / 65535f * (float)num3);
				int num6 = (int)((65535f - (float)P_0.DvIGOWCqXoNImNJUlcPYFoufuffEb) / 65535f * (float)num4);
				if (!ZEjxPZKkFozFpNAwwvIIlzoWTMsK)
				{
					irlRyNiebGPcfZuWMyqEjhNuuMCf = num5;
					BUwQiFgoMVCMzISxGUTtbysJprxC = num6;
					ZEjxPZKkFozFpNAwwvIIlzoWTMsK = true;
				}
				OatCXLesoxAbZzSDisPfTFIewQuFA += num5 - irlRyNiebGPcfZuWMyqEjhNuuMCf;
				nRnioyzYmQuNXEGiTQtQhtiHiymf += num6 - BUwQiFgoMVCMzISxGUTtbysJprxC;
				irlRyNiebGPcfZuWMyqEjhNuuMCf = num5;
				BUwQiFgoMVCMzISxGUTtbysJprxC = num6;
			}
			else
			{
				OatCXLesoxAbZzSDisPfTFIewQuFA = P_0.mEsNhmgLhZAalvaUKxSfLRcQebPA;
				nRnioyzYmQuNXEGiTQtQhtiHiymf = P_0.DvIGOWCqXoNImNJUlcPYFoufuffEb;
			}
			if (P_0.FNGAhosONURkFDjPpwhDjzwDCPJu != 0)
			{
				int num7 = ((MathTools.Abs(P_0.FNGAhosONURkFDjPpwhDjzwDCPJu) < 120) ? MathTools.Sign(P_0.FNGAhosONURkFDjPpwhDjzwDCPJu) : (P_0.FNGAhosONURkFDjPpwhDjzwDCPJu / 120));
				if ((qfOwMFUhPVeGZDVVWvpJmcSVCyiZ2 & qfOwMFUhPVeGZDVVWvpJmcSVCyiZ.MouseWheel) != qfOwMFUhPVeGZDVVWvpJmcSVCyiZ.None)
				{
					jhQpBrnGWKzPSCnyBWsbOpVcIYCd += num7;
				}
				else if ((qfOwMFUhPVeGZDVVWvpJmcSVCyiZ2 & (qfOwMFUhPVeGZDVVWvpJmcSVCyiZ)0x800) != qfOwMFUhPVeGZDVVWvpJmcSVCyiZ.None)
				{
					FuRZTOnHHwVDGzHeqtyursInBEMJ += num7;
				}
			}
		}

		public void qeQgoeUOPoWJopkgXrAYxBUbcDyT(ControllerDataUpdater P_0)
		{
			float[] axisValues = P_0.axisValues;
			axisValues[0] = OatCXLesoxAbZzSDisPfTFIewQuFA;
			axisValues[1] = nRnioyzYmQuNXEGiTQtQhtiHiymf;
			axisValues[2] = jhQpBrnGWKzPSCnyBWsbOpVcIYCd;
			axisValues[3] = FuRZTOnHHwVDGzHeqtyursInBEMJ;
			bool[] buttonValues = P_0.buttonValues;
			for (int i = 0; i < 5; i++)
			{
				buttonValues[i] = JxMRwIOXGggBcmlDHfltdEWYulcgA[i] || rfAZcaEhhNoJgryfpbBScpshhqKj[i];
			}
			mdhBNbFrXdoFcrFMTiGaCFaYVDeg();
		}

		public void GEbkRdcbNfIGfyCxhwOCQzKzMJIT()
		{
			mdhBNbFrXdoFcrFMTiGaCFaYVDeg();
		}

		private void mdhBNbFrXdoFcrFMTiGaCFaYVDeg()
		{
			if (DkFymymSAjAmuNjNWAPsqvMjODaK != ReInput.absFrame)
			{
				srWkjJCkFWiszWYwFDytSATdBJtFA();
				DkFymymSAjAmuNjNWAPsqvMjODaK = ReInput.absFrame;
			}
		}

		public void pjJkvSnyqoPqkdQvbdHHOUoweTzn()
		{
			OatCXLesoxAbZzSDisPfTFIewQuFA = 0f;
			nRnioyzYmQuNXEGiTQtQhtiHiymf = 0f;
			NyUGJKDouJNCpQexdkwmfzqvnmaM = 0u;
			XatFHOxOBeenTBVDxDKACTuZEsAFA = lwjtiAdHkKgQWaCfnTGfaaGsJZct.MoveRelative;
			jhQpBrnGWKzPSCnyBWsbOpVcIYCd = 0f;
			FuRZTOnHHwVDGzHeqtyursInBEMJ = 0f;
			Array.Clear(JxMRwIOXGggBcmlDHfltdEWYulcgA, 0, 5);
			Array.Clear(rfAZcaEhhNoJgryfpbBScpshhqKj, 0, 5);
			ZEjxPZKkFozFpNAwwvIIlzoWTMsK = false;
		}

		public void srWkjJCkFWiszWYwFDytSATdBJtFA()
		{
			OatCXLesoxAbZzSDisPfTFIewQuFA = 0f;
			nRnioyzYmQuNXEGiTQtQhtiHiymf = 0f;
			jhQpBrnGWKzPSCnyBWsbOpVcIYCd = 0f;
			FuRZTOnHHwVDGzHeqtyursInBEMJ = 0f;
			Array.Clear(rfAZcaEhhNoJgryfpbBScpshhqKj, 0, 5);
		}

		private void KpSNysfDIecnFwAiqLxKoBbsgDTg(int P_0, int P_1, int P_2, int P_3)
		{
			ZHlWBRgjoCoNisndJoYqnypreGCQ zHlWBRgjoCoNisndJoYqnypreGCQ = QXFSXACaZmXQiBWAtejMuqzIvMly(P_1, P_2, P_3);
			if (JxMRwIOXGggBcmlDHfltdEWYulcgA[P_0])
			{
				if (zHlWBRgjoCoNisndJoYqnypreGCQ == ZHlWBRgjoCoNisndJoYqnypreGCQ.Up || zHlWBRgjoCoNisndJoYqnypreGCQ == ZHlWBRgjoCoNisndJoYqnypreGCQ.DownAndUp)
				{
					JxMRwIOXGggBcmlDHfltdEWYulcgA[P_0] = false;
				}
			}
			else if (zHlWBRgjoCoNisndJoYqnypreGCQ == ZHlWBRgjoCoNisndJoYqnypreGCQ.Down)
			{
				JxMRwIOXGggBcmlDHfltdEWYulcgA[P_0] = true;
			}
			if (zHlWBRgjoCoNisndJoYqnypreGCQ == ZHlWBRgjoCoNisndJoYqnypreGCQ.Down || zHlWBRgjoCoNisndJoYqnypreGCQ == ZHlWBRgjoCoNisndJoYqnypreGCQ.DownAndUp)
			{
				rfAZcaEhhNoJgryfpbBScpshhqKj[P_0] = true;
			}
		}

		private static ZHlWBRgjoCoNisndJoYqnypreGCQ QXFSXACaZmXQiBWAtejMuqzIvMly(int P_0, int P_1, int P_2)
		{
			if ((P_0 & P_1) == P_1)
			{
				if ((P_0 & P_2) == P_2)
				{
					return ZHlWBRgjoCoNisndJoYqnypreGCQ.DownAndUp;
				}
				return ZHlWBRgjoCoNisndJoYqnypreGCQ.Down;
			}
			if ((P_0 & P_2) == P_2)
			{
				return ZHlWBRgjoCoNisndJoYqnypreGCQ.Up;
			}
			return ZHlWBRgjoCoNisndJoYqnypreGCQ.None;
		}

		private static bool YbVmzZhKuVTkUelWxhRxvxyrbgNy(IntPtr P_0)
		{
			if (iZtZloELsoaMBDRDTiszzpwtPjDd.wrxZVgqMCjHWLFSZtjLzifJtJHrQ(0u, false, 0u) == IntPtr.Zero)
			{
				return false;
			}
			if (!iZtZloELsoaMBDRDTiszzpwtPjDd.NNpcYKSRsUCOJGNLyUFkwFLCIwAV(P_0, out var yHFgydabfVKogEplJlUPbsQAUVwsc))
			{
				return false;
			}
			if (!iZtZloELsoaMBDRDTiszzpwtPjDd.BXCtyoeWbgHpfdHmZvvsIomWckPT(out var yHFgydabfVKogEplJlUPbsQAUVwsc2))
			{
				return false;
			}
			if (!iZtZloELsoaMBDRDTiszzpwtPjDd.QmXdYYEzfvudwwDgiWmmLxshZNmX(P_0, out var vLEvDeFTjHAGRxCkIDxktnhuApPw))
			{
				return false;
			}
			int num = yHFgydabfVKogEplJlUPbsQAUVwsc2.TereRVixAbIrZEXAHCQMfFBsMVdU - yHFgydabfVKogEplJlUPbsQAUVwsc.TereRVixAbIrZEXAHCQMfFBsMVdU;
			int num2 = yHFgydabfVKogEplJlUPbsQAUVwsc2.sbvQCigJMThWTHnrhHroDBvyzAjj - yHFgydabfVKogEplJlUPbsQAUVwsc.sbvQCigJMThWTHnrhHroDBvyzAjj;
			if (num >= 0 && num2 >= 0 && num <= vLEvDeFTjHAGRxCkIDxktnhuApPw.xNFXYUWquaXANtTimFeNVnFiLAEi && num2 <= vLEvDeFTjHAGRxCkIDxktnhuApPw.aRbOsYSDKoDbSdDVCRHNHBnBsQYR)
			{
				return false;
			}
			if (!iZtZloELsoaMBDRDTiszzpwtPjDd.oppLtzorEHLhosdyJGVjaOrSNUQe(P_0, out var vLEvDeFTjHAGRxCkIDxktnhuApPw2))
			{
				return false;
			}
			if (yHFgydabfVKogEplJlUPbsQAUVwsc2.TereRVixAbIrZEXAHCQMfFBsMVdU >= vLEvDeFTjHAGRxCkIDxktnhuApPw2.IWkYUGpGnTjpPySmRDxUqnVSbaNI && yHFgydabfVKogEplJlUPbsQAUVwsc2.TereRVixAbIrZEXAHCQMfFBsMVdU <= vLEvDeFTjHAGRxCkIDxktnhuApPw2.xNFXYUWquaXANtTimFeNVnFiLAEi && yHFgydabfVKogEplJlUPbsQAUVwsc2.sbvQCigJMThWTHnrhHroDBvyzAjj >= vLEvDeFTjHAGRxCkIDxktnhuApPw2.MJHAsaybdHKHmXIIsAAAIZtLgymi)
			{
				return yHFgydabfVKogEplJlUPbsQAUVwsc2.sbvQCigJMThWTHnrhHroDBvyzAjj <= vLEvDeFTjHAGRxCkIDxktnhuApPw2.aRbOsYSDKoDbSdDVCRHNHBnBsQYR;
			}
			return false;
		}
	}

	private class ZVmCEmeaNnkiCGDsGSMXkYApDzGpb
	{
		private bool nYUBgIaDCNGJJLpVgGEgKCxthVqC;

		private bool raRInUQYkTOYyVkyEqLzlSgXJqZN;

		private bool VJOuXJWjlwWxKJcuLmBLHfyLQENG;

		private int msDExrGtgkgEnbNcNFxJHmxmEqbiA = 10;

		private readonly float NbiVIwChGEclUBJyFhTmfKEyNnagb;

		private double hwonkHGEXBpTNlUERuFlifSsXDYe;

		public bool ELHCjPJJsCfcZQSpZvJUNsEDPZxwA
		{
			get
			{
				return apMEYMbIJZXsoHoBfONbMjOdsnEe();
			}
			set
			{
				wWdIqocbnHWGIBnggkfqWeJDDKQAA(flag);
			}
		}

		public bool DYofjrZxutoAdZBjmlBPtgopOiJN => SQsZWIWlPXPhQVjHYCgCTudUvbUm();

		public bool ZuKLhHgxTiXamvlLvgwZePWHchKb
		{
			get
			{
				return OTjfbACEvhKSdFqSxHMYUvpRJpwJA();
			}
			set
			{
				SyDJFRWsbGJcVOSwrBXybqiFekKE(flag);
			}
		}

		public int mzrPrgpWjqcAZYxgxaLkLGdwDmJJ => pEVctZBruaGBdNxRlHMCmDKCGdzl();

		public bool apMEYMbIJZXsoHoBfONbMjOdsnEe()
		{
			return nYUBgIaDCNGJJLpVgGEgKCxthVqC;
		}

		public void wWdIqocbnHWGIBnggkfqWeJDDKQAA(bool P_0)
		{
			if (P_0 != nYUBgIaDCNGJJLpVgGEgKCxthVqC)
			{
				dgmGojacosSFWfeFAHTWAXEiCtkDA(true);
			}
		}

		public bool SQsZWIWlPXPhQVjHYCgCTudUvbUm()
		{
			return raRInUQYkTOYyVkyEqLzlSgXJqZN;
		}

		public bool OTjfbACEvhKSdFqSxHMYUvpRJpwJA()
		{
			return VJOuXJWjlwWxKJcuLmBLHfyLQENG;
		}

		public void SyDJFRWsbGJcVOSwrBXybqiFekKE(bool P_0)
		{
			if (VJOuXJWjlwWxKJcuLmBLHfyLQENG != P_0)
			{
				VJOuXJWjlwWxKJcuLmBLHfyLQENG = P_0;
				dgmGojacosSFWfeFAHTWAXEiCtkDA(true);
			}
		}

		public int pEVctZBruaGBdNxRlHMCmDKCGdzl()
		{
			return msDExrGtgkgEnbNcNFxJHmxmEqbiA;
		}

		public ZVmCEmeaNnkiCGDsGSMXkYApDzGpb(bool P_0, float P_1)
		{
			nYUBgIaDCNGJJLpVgGEgKCxthVqC = P_0;
			NbiVIwChGEclUBJyFhTmfKEyNnagb = P_1;
			dgmGojacosSFWfeFAHTWAXEiCtkDA(false);
		}

		public void NfDcEpEKNgmaUzLvEgKHAGMaTempb()
		{
			if (nYUBgIaDCNGJJLpVgGEgKCxthVqC && !(ReInput.realTime < hwonkHGEXBpTNlUERuFlifSsXDYe))
			{
				dgmGojacosSFWfeFAHTWAXEiCtkDA(true);
			}
		}

		private void dgmGojacosSFWfeFAHTWAXEiCtkDA(bool P_0)
		{
			if (VJOuXJWjlwWxKJcuLmBLHfyLQENG)
			{
				iZtZloELsoaMBDRDTiszzpwtPjDd.dMDQtsHVqNljrQviWgxSQwXQEdhB(112u, 0u, ref msDExrGtgkgEnbNcNFxJHmxmEqbiA, 0u);
			}
			raRInUQYkTOYyVkyEqLzlSgXJqZN = iZtZloELsoaMBDRDTiszzpwtPjDd.IZogZeXadZkmTWhjTfNFMlnTMyIH(WEJzDPEhNQNZrfcPrLAlSuuEoShk.IFNKQyWxwcncKUrkImYgtvdYngDm) > 0;
			if (P_0)
			{
				hwonkHGEXBpTNlUERuFlifSsXDYe = ReInput.realTime + (double)NbiVIwChGEclUBJyFhTmfKEyNnagb;
			}
		}
	}

	private const int kFUscoTblGlLNqKDNSjDQAdGMfRb = 5;

	private const int splbhVdROzPQvngoiylFblnpMyTZ = 4;

	private readonly SpinLock DvldfmUMbymBWODXeGtsRTDGDjOA = new SpinLock();

	private UpdateLoopDataSet<EoRQfDJjqevdgQiWxwwcPUzUVpLj> bTdQEFZbxJckquVWdeaHbdLyHLYfA;

	private HardwareControllerMap_Game tvRWkAzZcdtxJDyvqpmibckoDaEFA;

	private ZVmCEmeaNnkiCGDsGSMXkYApDzGpb SgHHzPQyFHQGRiRsiIDHvcPZfzaW;

	private bool PtDPwGZHHEzLJDzXIbBHgMoqdgQJ;

	private int aatbiLeIbDCuLofQWPdyxEXcTuWf;

	private bool zDjFJHFRRhVlHuAplhFrpBzXBrtvA;

	private const bool YZgRZgdqZVuupdhtHNBSXNOWIZsw = true;

	private const float RijoSHzSgAAABZhFyETTdSohUtEN = 2f;

	private bool PEKdQVCpjrMfYgRCfkfChICAwvLcc;

	bool IGetSetEnabled.enabled
	{
		get
		{
			return get_enabled();
		}
		set
		{
			set_enabled(value);
		}
	}

	InputSource IUnifiedMouseSource.inputSource => get_inputSource();

	HardwareControllerMap_Game IUnifiedMouseSource.hardwareMap => get_hardwareMap();

	int IUnifiedMouseSource.buttonCount => get_buttonCount();

	int IUnifiedMouseSource.axisCount => get_axisCount();

	Vector2 IUnifiedMouseSource.mousePosition => get_mousePosition();

	Controller.Extension IUnifiedMouseSource.controllerExtension => get_controllerExtension();

	public BIzyiQEwcYLinsnttQYBvvpOBuGj(UpdateLoopSetting P_0)
	{
		gsnCNeABzKTJhadVlORqrdybQHJlA();
		SgHHzPQyFHQGRiRsiIDHvcPZfzaW = new ZVmCEmeaNnkiCGDsGSMXkYApDzGpb(true, 2f);
		bTdQEFZbxJckquVWdeaHbdLyHLYfA = new UpdateLoopDataSet<EoRQfDJjqevdgQiWxwwcPUzUVpLj>(P_0);
		using (TempListPool.TList<UpdateLoopType> tList = TempListPool.GetTList<UpdateLoopType>(3))
		{
			List<UpdateLoopType> list = tList.list;
			EnumConverter.ToUpdateLoopTypes(P_0, list);
			for (int i = 0; i < list.Count; i++)
			{
				bTdQEFZbxJckquVWdeaHbdLyHLYfA[i] = new EoRQfDJjqevdgQiWxwwcPUzUVpLj(SgHHzPQyFHQGRiRsiIDHvcPZfzaW, list[i]);
			}
		}
		PtDPwGZHHEzLJDzXIbBHgMoqdgQJ = ReInput.IsInputAllowed(ControllerType.Mouse);
		ReInput.ApplicationFocusChangedEvent += MZBVDTVTjaxPdsTaDCRfPKNIdmiK;
		ReInput.ApplicationPauseChangedEvent += yEKIkZEXniSwdHheMaOqhgtVAGKh;
		set_enabled(value: true);
		ReInput.EditorPauseChangedEvent += NCNMEsLdBuylfvJpHSecePSQrolL;
		ReInput.TimeScalePauseChangedEvent += fPTkxaDfdgWXULyjYDIOyJYhohoN;
		ReInput.UpdateEndedEvent += kXuKkHiEgXiaRvkcvpQFmErpCcMh;
	}

	public void PezIzVGJqmdvExBTtRwSqfwEhUykA(UpdateLoopType P_0)
	{
		bTdQEFZbxJckquVWdeaHbdLyHLYfA.SetUpdateLoop(P_0);
		SgHHzPQyFHQGRiRsiIDHvcPZfzaW.NfDcEpEKNgmaUzLvEgKHAGMaTempb();
		PtDPwGZHHEzLJDzXIbBHgMoqdgQJ = ReInput.IsInputAllowed(ControllerType.Mouse);
	}

	public void fdOItvHfwbYUhGsbHhVAiZNFcbFs(hgdFADROZeRoloFIwqQBhNJiOdEJ P_0)
	{
		if (!PtDPwGZHHEzLJDzXIbBHgMoqdgQJ)
		{
			return;
		}
		using (DvldfmUMbymBWODXeGtsRTDGDjOA.Lock())
		{
			int count = bTdQEFZbxJckquVWdeaHbdLyHLYfA.Count;
			for (int i = 0; i < count; i++)
			{
				bTdQEFZbxJckquVWdeaHbdLyHLYfA[i].pUVSpUuMpazVfmWynGVCMdhhXLOe(P_0);
			}
		}
	}

	public void PPLAejSqlEaRpEsCbNtZbkzUXUgGA(bool P_0)
	{
		YldBAOWNMzGWDisNxLSCZIskenBhA();
	}

	public void DiWgiNImzUAERFJSTbiZsEpStgYW(bool P_0)
	{
		if (gsnCNeABzKTJhadVlORqrdybQHJlA() < 0)
		{
			YldBAOWNMzGWDisNxLSCZIskenBhA();
		}
	}

	private int gsnCNeABzKTJhadVlORqrdybQHJlA()
	{
		int num = aatbiLeIbDCuLofQWPdyxEXcTuWf;
		if (ojlzQfWcOYdhEdoUtpjHLTuXXVeX.PrhQPfZPCSnABdKWTATcEZPQTiwJ(KMtSgETdNvgXUrUlDrAtelwyuiPp.Mouse, out var num2))
		{
			aatbiLeIbDCuLofQWPdyxEXcTuWf = num2;
		}
		else
		{
			aatbiLeIbDCuLofQWPdyxEXcTuWf = ((iZtZloELsoaMBDRDTiszzpwtPjDd.IZogZeXadZkmTWhjTfNFMlnTMyIH(WEJzDPEhNQNZrfcPrLAlSuuEoShk.JTKVhpdNuCanPemCyrrFPhQzJFnz) != 0) ? 1 : 0);
		}
		return aatbiLeIbDCuLofQWPdyxEXcTuWf - num;
	}

	private void MZBVDTVTjaxPdsTaDCRfPKNIdmiK(bool P_0)
	{
		PtDPwGZHHEzLJDzXIbBHgMoqdgQJ = ReInput.IsInputAllowed(ControllerType.Mouse);
		if (!P_0 && !PtDPwGZHHEzLJDzXIbBHgMoqdgQJ)
		{
			YldBAOWNMzGWDisNxLSCZIskenBhA();
		}
	}

	private void yEKIkZEXniSwdHheMaOqhgtVAGKh(bool P_0)
	{
		PtDPwGZHHEzLJDzXIbBHgMoqdgQJ = ReInput.IsInputAllowed(ControllerType.Mouse);
		if (!PtDPwGZHHEzLJDzXIbBHgMoqdgQJ)
		{
			YldBAOWNMzGWDisNxLSCZIskenBhA();
		}
	}

	private void NCNMEsLdBuylfvJpHSecePSQrolL(bool P_0)
	{
	}

	private void fPTkxaDfdgWXULyjYDIOyJYhohoN(bool P_0)
	{
		if ((ReInput.configVars.updateLoop & UpdateLoopSetting.FixedUpdate) == 0)
		{
			return;
		}
		PtDPwGZHHEzLJDzXIbBHgMoqdgQJ = ReInput.IsInputAllowed(ControllerType.Mouse);
		using (DvldfmUMbymBWODXeGtsRTDGDjOA.Lock())
		{
			bTdQEFZbxJckquVWdeaHbdLyHLYfA[bTdQEFZbxJckquVWdeaHbdLyHLYfA.fixedUpdateSetIndex].srWkjJCkFWiszWYwFDytSATdBJtFA();
		}
	}

	private void kXuKkHiEgXiaRvkcvpQFmErpCcMh(UpdateLoopType P_0)
	{
		using (DvldfmUMbymBWODXeGtsRTDGDjOA.Lock())
		{
			bTdQEFZbxJckquVWdeaHbdLyHLYfA.Get(P_0).GEbkRdcbNfIGfyCxhwOCQzKzMJIT();
		}
	}

	private void YldBAOWNMzGWDisNxLSCZIskenBhA()
	{
		using (DvldfmUMbymBWODXeGtsRTDGDjOA.Lock())
		{
			int count = bTdQEFZbxJckquVWdeaHbdLyHLYfA.Count;
			for (int i = 0; i < count; i++)
			{
				bTdQEFZbxJckquVWdeaHbdLyHLYfA[i].pjJkvSnyqoPqkdQvbdHHOUoweTzn();
			}
		}
	}

	public bool get_enabled()
	{
		return zDjFJHFRRhVlHuAplhFrpBzXBrtvA;
	}

	public void set_enabled(bool value)
	{
		if (zDjFJHFRRhVlHuAplhFrpBzXBrtvA != value)
		{
			zDjFJHFRRhVlHuAplhFrpBzXBrtvA = value;
			Clear();
			ThreadSafeUnityInput.mouse.Monitor(value);
		}
	}

	public InputSource get_inputSource()
	{
		return InputSource.RawInput;
	}

	public HardwareControllerMap_Game get_hardwareMap()
	{
		if (tvRWkAzZcdtxJDyvqpmibckoDaEFA == null)
		{
			tvRWkAzZcdtxJDyvqpmibckoDaEFA = ZittdbQAaGKaVrMxiZIRaWGcKCam();
		}
		return tvRWkAzZcdtxJDyvqpmibckoDaEFA;
	}

	public int get_buttonCount()
	{
		return 5;
	}

	public int get_axisCount()
	{
		return 4;
	}

	public Vector2 get_mousePosition()
	{
		if (!zDjFJHFRRhVlHuAplhFrpBzXBrtvA)
		{
			return default;
		}
		return ThreadSafeUnityInput.mouse.mousePosition;
	}

	public Controller.Extension get_controllerExtension()
	{
		return null;
	}

	public void UpdateInputData(ControllerDataUpdater dataUpdater)
	{
		bTdQEFZbxJckquVWdeaHbdLyHLYfA.Current.qeQgoeUOPoWJopkgXrAYxBUbcDyT(dataUpdater);
	}

	void IUnifiedMouseSource.UpdateInputData(ControllerDataUpdater dataUpdater)
	{
		//ILSpy generated this explicit interface implementation from .override directive in UpdateInputData
		this.UpdateInputData(dataUpdater);
	}

	public void Clear()
	{
		YldBAOWNMzGWDisNxLSCZIskenBhA();
	}

	void IUnifiedMouseSource.Clear()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Clear
		this.Clear();
	}

	private HardwareControllerMap_Game ZittdbQAaGKaVrMxiZIRaWGcKCam()
	{
		ControllerElementIdentifier[] array = new ControllerElementIdentifier[Consts.rawInputUnifiedMouseElementIdentifiers.Count];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = new ControllerElementIdentifier(Consts.rawInputUnifiedMouseElementIdentifiers[i]);
		}
		int[] array2 = new int[5];
		int[] array3 = new int[4];
		int num = 0;
		int num2 = 0;
		for (int j = 0; j < array.Length; j++)
		{
			if (array[j].elementType == ControllerElementType.Axis)
			{
				array3[num2++] = array[j].get_id();
			}
			else if (array[j].elementType == ControllerElementType.Button)
			{
				array2[num++] = array[j].get_id();
			}
		}
		AxisCalibrationData[] array4 = new AxisCalibrationData[4];
		AxisRange[] array5 = new AxisRange[4];
		HardwareAxisInfo[] array6 = new HardwareAxisInfo[4];
		HardwareButtonInfo[] array7 = new HardwareButtonInfo[5];
		for (int k = 0; k < 4; k++)
		{
			array4[k] = AxisCalibrationData.Raw;
			array5[k] = AxisRange.Full;
			float num3 = (((uint)k > 1u) ? 2f : 100f);
			array6[k] = new HardwareAxisInfo(AxisCoordinateMode.Relative, false, num3, SpecialAxisType.None);
		}
		for (int l = 0; l < 5; l++)
		{
			array7[l] = new HardwareButtonInfo();
		}
		return new HardwareControllerMap_Game("Mouse", default, array, array2, array3, array4, array5, array6, array7, null);
	}

	public void Dispose()
	{
		awFNSHDsvwpROLtRYwPnVylRqBJc(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	protected virtual void kksDKJfqBAoSwacRasxhPHdLSGnkA()
	{
		try
		{
			awFNSHDsvwpROLtRYwPnVylRqBJc(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	protected virtual void awFNSHDsvwpROLtRYwPnVylRqBJc(bool P_0)
	{
		if (!PEKdQVCpjrMfYgRCfkfChICAwvLcc)
		{
			ReInput.ApplicationFocusChangedEvent -= MZBVDTVTjaxPdsTaDCRfPKNIdmiK;
			ReInput.ApplicationPauseChangedEvent -= yEKIkZEXniSwdHheMaOqhgtVAGKh;
			ReInput.EditorPauseChangedEvent -= NCNMEsLdBuylfvJpHSecePSQrolL;
			ReInput.TimeScalePauseChangedEvent -= fPTkxaDfdgWXULyjYDIOyJYhohoN;
			ReInput.UpdateEndedEvent -= kXuKkHiEgXiaRvkcvpQFmErpCcMh;
			if (P_0 && zDjFJHFRRhVlHuAplhFrpBzXBrtvA)
			{
				ThreadSafeUnityInput.mouse.Monitor(state: false);
			}
			PEKdQVCpjrMfYgRCfkfChICAwvLcc = true;
		}
	}
}
