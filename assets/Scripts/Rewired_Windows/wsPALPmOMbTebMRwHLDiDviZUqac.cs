using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading;
using Rewired;
using Rewired.Interfaces;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using Rewired.Utils.Classes.Utility;

internal class wsPALPmOMbTebMRwHLDiDviZUqac : IDisposable
{
	private abstract class hOwVdXVOMlfkQpBwCyjJNEaRKnDk : IPoolableObject, IDisposable, IPoolableObject_Internal
	{
		[CompilerGenerated]
		private IObjectPool xYrFuOtBulzWIDLiiTSEuOGUgRbp;

		IObjectPool IPoolableObject_Internal.pool
		{
			[CompilerGenerated]
			get
			{
				return xYrFuOtBulzWIDLiiTSEuOGUgRbp;
			}
			[CompilerGenerated]
			set
			{
				xYrFuOtBulzWIDLiiTSEuOGUgRbp = value;
			}
		}

		protected abstract void Clear();

		void IPoolableObject_Internal.Clear()
		{
			Clear();
		}

		void IDisposable.Dispose()
		{
			Return();
		}

		public void Return()
		{
			((IPoolableObject_Internal)this).pool?.Return(this);
		}

		void IPoolableObject.Return()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Return
			this.Return();
		}
	}

	private class AqLxvZWgQmKoWmueUIlKepUIXZoS : hOwVdXVOMlfkQpBwCyjJNEaRKnDk
	{
		public xdVIbvBoDAUiDeiBddhJTIMLUfnL vkeZzbmAHVofIOVycLiHZNcqscLq;

		public WjHeUGFpMfXsDCAZYcTSYZtUWbpTA iyRFcLBKqiFcaXDDcePXGWEGscFgc;

		public double WtSDImaDUIYcuAoPmbTdLmrYvKbL;

		protected virtual void GrgBHqHpNEHTlFTmDINLoMoBHlfsC()
		{
			vkeZzbmAHVofIOVycLiHZNcqscLq = null;
			iyRFcLBKqiFcaXDDcePXGWEGscFgc = default;
			WtSDImaDUIYcuAoPmbTdLmrYvKbL = 0.0;
		}
	}

	private sealed class yoisjZwsEVmyZYWRvBmMSpvYsubm : hOwVdXVOMlfkQpBwCyjJNEaRKnDk
	{
		public xdVIbvBoDAUiDeiBddhJTIMLUfnL mAtofTqeJUuiGLMgIYNurKRvlXEG;

		public LtakCapTpNbmgRDKnDqtPFoLiOVE mZunFopezHznvztGeqUSrtJYZvv;

		protected void IbTDhuJdHZXkowvGZmuWjCoHBkkrA()
		{
			mAtofTqeJUuiGLMgIYNurKRvlXEG = null;
			mZunFopezHznvztGeqUSrtJYZvv = default;
		}
	}

	[Serializable]
	private sealed class rxEmbGemVnvBInJIgAfBmcVSlAmj
	{
		public static readonly rxEmbGemVnvBInJIgAfBmcVSlAmj _003C_003E9 = new rxEmbGemVnvBInJIgAfBmcVSlAmj();

		public static Func<AqLxvZWgQmKoWmueUIlKepUIXZoS> _003C_003E9__19_0;

		public static Func<yoisjZwsEVmyZYWRvBmMSpvYsubm> _003C_003E9__19_1;

		internal AqLxvZWgQmKoWmueUIlKepUIXZoS IypKAEpuvmFdexHEYQRurmuvSrlo()
		{
			return new AqLxvZWgQmKoWmueUIlKepUIXZoS();
		}

		internal yoisjZwsEVmyZYWRvBmMSpvYsubm VflIPCcEftmObGmjCrDCAUNsbMvfc()
		{
			return new yoisjZwsEVmyZYWRvBmMSpvYsubm();
		}
	}

	private readonly List<CfENPjACeuDyUowrFIDWzqlxhXcF> qoAFBketVCXFWnVynXsTqSKGDXzO;

	private readonly ReadOnlyCollection<CfENPjACeuDyUowrFIDWzqlxhXcF> uMcGtEglSEZjQObWEuBlrlGjRKiVA;

	private readonly List<xdVIbvBoDAUiDeiBddhJTIMLUfnL> BAjeKvaTrFqYyFNGstwWsDbLlcVcA;

	private readonly Func<int> uCGLrBUYOqJpmbsAYtSvGBbSoFJg;

	private readonly Rewired.Utils.Classes.Utility.SpinLock FmxCTqFyZGXywrgLGbaqBzsxxiFAb = new Rewired.Utils.Classes.Utility.SpinLock();

	private readonly Rewired.Utils.Classes.Utility.SpinLock qkawONfWOoNsafMjxPLCZTuFpLZu = new Rewired.Utils.Classes.Utility.SpinLock();

	private RingBuffer<AqLxvZWgQmKoWmueUIlKepUIXZoS> atmimruVYNvAPolIbTPWlbNNcgun;

	private RingBuffer<yoisjZwsEVmyZYWRvBmMSpvYsubm> PvUyltxapPHRSoUmAgTYFsQcOIkqA;

	private bool iAIAokGsnAwTKKzkCvnwdXAhrFOsA;

	private readonly ThreadSafeObjectPool<AqLxvZWgQmKoWmueUIlKepUIXZoS> ljDgxdLpBtJufLlypkQRRNBnHBTCA;

	private readonly ThreadSafeObjectPool<yoisjZwsEVmyZYWRvBmMSpvYsubm> zSrgfhbPAetpTFUoGzzLlzcRKkGuA;

	private readonly List<CfENPjACeuDyUowrFIDWzqlxhXcF> nItBWFrYMsQdPnjUluAwJefYhaqW;

	private RingBuffer<AqLxvZWgQmKoWmueUIlKepUIXZoS> DKboBuoLupRRDizVvHmtHGPEKvqk;

	private RingBuffer<yoisjZwsEVmyZYWRvBmMSpvYsubm> wGLdIhcqIYNctIGETNSoPgVOMnNb;

	private bool cFjfPMOeJoWHCCmHJbbCwiYRsENf;

	private Action<xdVIbvBoDAUiDeiBddhJTIMLUfnL, LtakCapTpNbmgRDKnDqtPFoLiOVE> dwUyVreYpCyOQUuhtyssxOUifCff;

	private Action JeUtAacOdAjZMBxQpUHVqqQvbEXHA__BackingField;

	private bool qbdaneQKaILkpDGyhrfRiKmWnrkC;

	private static Guid[] OLNQCBYMuVLKlwFFfBtJiylMHFvG;

	private static string[] xxKtElVsAoHdDAiShSZqdogbvddI;

	private static string[] dPtSrMYViOnhARNhFzUfsSYVsAQ;

	public event Action JeUtAacOdAjZMBxQpUHVqqQvbEXHA
	{
		add
		{
			sKblAtevFiynHOQNFUHdPGlssIRI(action);
		}
		remove
		{
			BBRDZDZOvVQRNESaahBaskSzdMLF(action);
		}
	}

	public void sKblAtevFiynHOQNFUHdPGlssIRI(Action P_0)
	{
		Action action = JeUtAacOdAjZMBxQpUHVqqQvbEXHA__BackingField;
		Action action2;
		do
		{
			action2 = action;
			Action value = (Action)Delegate.Combine(action2, P_0);
			action = Interlocked.CompareExchange(ref JeUtAacOdAjZMBxQpUHVqqQvbEXHA__BackingField, value, action2);
		}
		while ((object)action != action2);
	}

	public void BBRDZDZOvVQRNESaahBaskSzdMLF(Action P_0)
	{
		Action action = JeUtAacOdAjZMBxQpUHVqqQvbEXHA__BackingField;
		Action action2;
		do
		{
			action2 = action;
			Action value = (Action)Delegate.Remove(action2, P_0);
			action = Interlocked.CompareExchange(ref JeUtAacOdAjZMBxQpUHVqqQvbEXHA__BackingField, value, action2);
		}
		while ((object)action != action2);
	}

	public wsPALPmOMbTebMRwHLDiDviZUqac(Func<int> P_0)
	{
		uCGLrBUYOqJpmbsAYtSvGBbSoFJg = P_0;
		dwUyVreYpCyOQUuhtyssxOUifCff = vwCBRLeEFlKIrgeEemmThZMhkWrD;
		qoAFBketVCXFWnVynXsTqSKGDXzO = new List<CfENPjACeuDyUowrFIDWzqlxhXcF>();
		nItBWFrYMsQdPnjUluAwJefYhaqW = new List<CfENPjACeuDyUowrFIDWzqlxhXcF>();
		uMcGtEglSEZjQObWEuBlrlGjRKiVA = new ReadOnlyCollection<CfENPjACeuDyUowrFIDWzqlxhXcF>(qoAFBketVCXFWnVynXsTqSKGDXzO);
		BAjeKvaTrFqYyFNGstwWsDbLlcVcA = new List<xdVIbvBoDAUiDeiBddhJTIMLUfnL>();
		iAIAokGsnAwTKKzkCvnwdXAhrFOsA = ReInput.IsInputAllowed(ControllerType.Joystick);
		int num = (int)(0.5f * (float)hmRdjlkkAraUbAOZelrfFnsoEfpCB.HdYjuOcsUBMbxACBttaMRLoAARlu() * 32f) + 1;
		ljDgxdLpBtJufLlypkQRRNBnHBTCA = new ThreadSafeObjectPool<AqLxvZWgQmKoWmueUIlKepUIXZoS>(num, rxEmbGemVnvBInJIgAfBmcVSlAmj._003C_003E9.IypKAEpuvmFdexHEYQRurmuvSrlo);
		zSrgfhbPAetpTFUoGzzLlzcRKkGuA = new ThreadSafeObjectPool<yoisjZwsEVmyZYWRvBmMSpvYsubm>(128, rxEmbGemVnvBInJIgAfBmcVSlAmj._003C_003E9.VflIPCcEftmObGmjCrDCAUNsbMvfc);
		atmimruVYNvAPolIbTPWlbNNcgun = new RingBuffer<AqLxvZWgQmKoWmueUIlKepUIXZoS>(num);
		PvUyltxapPHRSoUmAgTYFsQcOIkqA = new RingBuffer<yoisjZwsEVmyZYWRvBmMSpvYsubm>(128);
		DKboBuoLupRRDizVvHmtHGPEKvqk = new RingBuffer<AqLxvZWgQmKoWmueUIlKepUIXZoS>(num);
		wGLdIhcqIYNctIGETNSoPgVOMnNb = new RingBuffer<yoisjZwsEVmyZYWRvBmMSpvYsubm>(128);
		xdVIbvBoDAUiDeiBddhJTIMLUfnL.aOfhikocYwIKnjGVHdzaOeqxxSop(KrdTCyughoxdJkYuGHhkQMYQMNoG);
		xdVIbvBoDAUiDeiBddhJTIMLUfnL.bZtfaAvVwOdENIEEfhzHQyJpFYJlA(AZuiroveSmbdkHkqcGKdQNGBxdaUA);
		hmRdjlkkAraUbAOZelrfFnsoEfpCB.ikUrOmsIKNMiTmyUGnratMoHlLVn().ThreadUpdateEvent += vEkdyOArHnjcXbKguYyyNjuAdRHjA;
		hmRdjlkkAraUbAOZelrfFnsoEfpCB.kTOPdpvPqgeEoyxeFuEbAOuEacFu().ThreadUpdateEvent += wukoDrpeSGTLqtrgeMBCvBtPUXas;
		ReInput.ApplicationFocusChangedEvent += dJnvAxngVTwzxCJxjovfZeUClYWJ;
		ReInput.ApplicationPauseChangedEvent += pQNfomyJeLyZPNBBSsrjTdcTloVK;
		xdVIbvBoDAUiDeiBddhJTIMLUfnL.cAdugalrmWwhtofzcLQbWubqWJRm();
		IObruETZDnLESLcQKWooyIEKhbNx();
	}

	public void ltOBriXLEWaAkSUzOOpJIProXWDw()
	{
		bool flag = false;
		using (FmxCTqFyZGXywrgLGbaqBzsxxiFAb.Lock())
		{
			if (cFjfPMOeJoWHCCmHJbbCwiYRsENf)
			{
				cFjfPMOeJoWHCCmHJbbCwiYRsENf = false;
				flag = true;
			}
		}
		if (flag)
		{
			IObruETZDnLESLcQKWooyIEKhbNx();
		}
	}

	public void zPcPMzNPYfwTdlgutUoyEJbtgDu()
	{
		using (FmxCTqFyZGXywrgLGbaqBzsxxiFAb.Lock())
		{
			MiscTools.Swap(ref atmimruVYNvAPolIbTPWlbNNcgun, ref DKboBuoLupRRDizVvHmtHGPEKvqk);
		}
		while (atmimruVYNvAPolIbTPWlbNNcgun.Count > 0)
		{
			AqLxvZWgQmKoWmueUIlKepUIXZoS aqLxvZWgQmKoWmueUIlKepUIXZoS = atmimruVYNvAPolIbTPWlbNNcgun.Dequeue();
			int num = rLYAZSWJNeBbniZAZzBqEcpdaTUFb(qoAFBketVCXFWnVynXsTqSKGDXzO, aqLxvZWgQmKoWmueUIlKepUIXZoS.vkeZzbmAHVofIOVycLiHZNcqscLq);
			if (num >= 0)
			{
				qoAFBketVCXFWnVynXsTqSKGDXzO[num].buiygnVfYnjbNRAUWaCLrtHNRXxg(aqLxvZWgQmKoWmueUIlKepUIXZoS.iyRFcLBKqiFcaXDDcePXGWEGscFgc, aqLxvZWgQmKoWmueUIlKepUIXZoS.WtSDImaDUIYcuAoPmbTdLmrYvKbL);
			}
			aqLxvZWgQmKoWmueUIlKepUIXZoS.Return();
		}
	}

	private void vwCBRLeEFlKIrgeEemmThZMhkWrD(xdVIbvBoDAUiDeiBddhJTIMLUfnL P_0, LtakCapTpNbmgRDKnDqtPFoLiOVE P_1)
	{
		if (!iAIAokGsnAwTKKzkCvnwdXAhrFOsA)
		{
			return;
		}
		using (qkawONfWOoNsafMjxPLCZTuFpLZu.Lock())
		{
			yoisjZwsEVmyZYWRvBmMSpvYsubm yoisjZwsEVmyZYWRvBmMSpvYsubm2 = zSrgfhbPAetpTFUoGzzLlzcRKkGuA.Get();
			yoisjZwsEVmyZYWRvBmMSpvYsubm2.mAtofTqeJUuiGLMgIYNurKRvlXEG = P_0;
			yoisjZwsEVmyZYWRvBmMSpvYsubm2.mZunFopezHznvztGeqUSrtJYZvv = P_1;
			PvUyltxapPHRSoUmAgTYFsQcOIkqA.Enqueue(yoisjZwsEVmyZYWRvBmMSpvYsubm2);
		}
	}

	public IList<CfENPjACeuDyUowrFIDWzqlxhXcF> cWPtsifGuJgwZrfAidaMasbAcAkCA()
	{
		return uMcGtEglSEZjQObWEuBlrlGjRKiVA;
	}

	private void IObruETZDnLESLcQKWooyIEKhbNx()
	{
		bool flag = false;
		List<xdVIbvBoDAUiDeiBddhJTIMLUfnL> bAjeKvaTrFqYyFNGstwWsDbLlcVcA = BAjeKvaTrFqYyFNGstwWsDbLlcVcA;
		using (FmxCTqFyZGXywrgLGbaqBzsxxiFAb.Lock())
		{
			xdVIbvBoDAUiDeiBddhJTIMLUfnL.fXrAxroxrGIchLFzeKNxXUqZjPwg(bAjeKvaTrFqYyFNGstwWsDbLlcVcA);
			for (int num = nItBWFrYMsQdPnjUluAwJefYhaqW.Count - 1; num >= 0; num--)
			{
				if (!JTcBvxPURYcmiidrHAStKnPQhBBCA(bAjeKvaTrFqYyFNGstwWsDbLlcVcA, nItBWFrYMsQdPnjUluAwJefYhaqW[num].xCgTQlybrxIaPNBwebMtalunPNVbA()))
				{
					nItBWFrYMsQdPnjUluAwJefYhaqW[num].xCgTQlybrxIaPNBwebMtalunPNVbA().MgjjQDgztetiXAtlDTtQCqsvoxAm();
					nItBWFrYMsQdPnjUluAwJefYhaqW[num].Dispose();
					nItBWFrYMsQdPnjUluAwJefYhaqW.RemoveAt(num);
					flag = true;
				}
			}
			for (int num2 = bAjeKvaTrFqYyFNGstwWsDbLlcVcA.Count - 1; num2 >= 0; num2--)
			{
				xdVIbvBoDAUiDeiBddhJTIMLUfnL xdVIbvBoDAUiDeiBddhJTIMLUfnL2 = bAjeKvaTrFqYyFNGstwWsDbLlcVcA[num2];
				if (xdVIbvBoDAUiDeiBddhJTIMLUfnL.nJgmfAWddMUvNUvIxrgRdCRlijMQ(xdVIbvBoDAUiDeiBddhJTIMLUfnL2, null))
				{
					bAjeKvaTrFqYyFNGstwWsDbLlcVcA.RemoveAt(num2);
				}
				else
				{
					int num3 = rLYAZSWJNeBbniZAZzBqEcpdaTUFb(nItBWFrYMsQdPnjUluAwJefYhaqW, xdVIbvBoDAUiDeiBddhJTIMLUfnL2);
					if (num3 >= 0)
					{
						bAjeKvaTrFqYyFNGstwWsDbLlcVcA[num2].MgjjQDgztetiXAtlDTtQCqsvoxAm();
						bAjeKvaTrFqYyFNGstwWsDbLlcVcA[num2] = nItBWFrYMsQdPnjUluAwJefYhaqW[num3].xCgTQlybrxIaPNBwebMtalunPNVbA();
					}
					else
					{
						nItBWFrYMsQdPnjUluAwJefYhaqW.Add(new CfENPjACeuDyUowrFIDWzqlxhXcF(xdVIbvBoDAUiDeiBddhJTIMLUfnL2, uCGLrBUYOqJpmbsAYtSvGBbSoFJg(), dwUyVreYpCyOQUuhtyssxOUifCff));
						flag = true;
					}
				}
			}
			for (int num4 = bAjeKvaTrFqYyFNGstwWsDbLlcVcA.Count - 1; num4 >= 0; num4--)
			{
				xdVIbvBoDAUiDeiBddhJTIMLUfnL xdVIbvBoDAUiDeiBddhJTIMLUfnL3 = bAjeKvaTrFqYyFNGstwWsDbLlcVcA[num4];
				int num5 = rLYAZSWJNeBbniZAZzBqEcpdaTUFb(nItBWFrYMsQdPnjUluAwJefYhaqW, xdVIbvBoDAUiDeiBddhJTIMLUfnL3);
				if (num5 >= 0)
				{
					CfENPjACeuDyUowrFIDWzqlxhXcF item = nItBWFrYMsQdPnjUluAwJefYhaqW[num5];
					nItBWFrYMsQdPnjUluAwJefYhaqW.RemoveAt(num5);
					nItBWFrYMsQdPnjUluAwJefYhaqW.Insert(0, item);
				}
			}
			qoAFBketVCXFWnVynXsTqSKGDXzO.Clear();
			for (int i = 0; i < nItBWFrYMsQdPnjUluAwJefYhaqW.Count; i++)
			{
				qoAFBketVCXFWnVynXsTqSKGDXzO.Add(nItBWFrYMsQdPnjUluAwJefYhaqW[i]);
			}
		}
		bAjeKvaTrFqYyFNGstwWsDbLlcVcA.Clear();
		if (flag)
		{
			JeUtAacOdAjZMBxQpUHVqqQvbEXHA__BackingField?.Invoke();
		}
	}

	private void dJnvAxngVTwzxCJxjovfZeUClYWJ(bool P_0)
	{
		iAIAokGsnAwTKKzkCvnwdXAhrFOsA = ReInput.IsInputAllowed(ControllerType.Joystick);
		if (!iAIAokGsnAwTKKzkCvnwdXAhrFOsA)
		{
			using (FmxCTqFyZGXywrgLGbaqBzsxxiFAb.Lock())
			{
				atmimruVYNvAPolIbTPWlbNNcgun.Clear();
			}
		}
	}

	private void pQNfomyJeLyZPNBBSsrjTdcTloVK(bool P_0)
	{
		iAIAokGsnAwTKKzkCvnwdXAhrFOsA = ReInput.IsInputAllowed(ControllerType.Joystick);
		if (!iAIAokGsnAwTKKzkCvnwdXAhrFOsA)
		{
			using (FmxCTqFyZGXywrgLGbaqBzsxxiFAb.Lock())
			{
				atmimruVYNvAPolIbTPWlbNNcgun.Clear();
			}
		}
	}

	private void vEkdyOArHnjcXbKguYyyNjuAdRHjA()
	{
		if (qbdaneQKaILkpDGyhrfRiKmWnrkC || !iAIAokGsnAwTKKzkCvnwdXAhrFOsA)
		{
			return;
		}
		using (FmxCTqFyZGXywrgLGbaqBzsxxiFAb.Lock())
		{
			int count = nItBWFrYMsQdPnjUluAwJefYhaqW.Count;
			for (int i = 0; i < count; i++)
			{
				AqLxvZWgQmKoWmueUIlKepUIXZoS aqLxvZWgQmKoWmueUIlKepUIXZoS = ljDgxdLpBtJufLlypkQRRNBnHBTCA.Get();
				aqLxvZWgQmKoWmueUIlKepUIXZoS.vkeZzbmAHVofIOVycLiHZNcqscLq = nItBWFrYMsQdPnjUluAwJefYhaqW[i].xCgTQlybrxIaPNBwebMtalunPNVbA();
				aqLxvZWgQmKoWmueUIlKepUIXZoS.iyRFcLBKqiFcaXDDcePXGWEGscFgc = aqLxvZWgQmKoWmueUIlKepUIXZoS.vkeZzbmAHVofIOVycLiHZNcqscLq.elzuOfPPGJKaVnGlhcijMqcPbZOF();
				aqLxvZWgQmKoWmueUIlKepUIXZoS.WtSDImaDUIYcuAoPmbTdLmrYvKbL = ReInput.realTime;
				DKboBuoLupRRDizVvHmtHGPEKvqk.Enqueue(aqLxvZWgQmKoWmueUIlKepUIXZoS);
			}
		}
	}

	private void wukoDrpeSGTLqtrgeMBCvBtPUXas()
	{
		if (qbdaneQKaILkpDGyhrfRiKmWnrkC)
		{
			return;
		}
		using (qkawONfWOoNsafMjxPLCZTuFpLZu.Lock())
		{
			MiscTools.Swap(ref PvUyltxapPHRSoUmAgTYFsQcOIkqA, ref wGLdIhcqIYNctIGETNSoPgVOMnNb);
		}
		while (wGLdIhcqIYNctIGETNSoPgVOMnNb.Count > 0)
		{
			yoisjZwsEVmyZYWRvBmMSpvYsubm yoisjZwsEVmyZYWRvBmMSpvYsubm2 = wGLdIhcqIYNctIGETNSoPgVOMnNb.Dequeue();
			try
			{
				yoisjZwsEVmyZYWRvBmMSpvYsubm2.mAtofTqeJUuiGLMgIYNurKRvlXEG.oFjUMwGHMGcnxGkLxYhgTFxuIZEAA(yoisjZwsEVmyZYWRvBmMSpvYsubm2.mZunFopezHznvztGeqUSrtJYZvv);
			}
			catch
			{
			}
			yoisjZwsEVmyZYWRvBmMSpvYsubm2.Return();
		}
	}

	private void KrdTCyughoxdJkYuGHhkQMYQMNoG(xdVIbvBoDAUiDeiBddhJTIMLUfnL P_0)
	{
		P_0.MgjjQDgztetiXAtlDTtQCqsvoxAm();
		if (qbdaneQKaILkpDGyhrfRiKmWnrkC)
		{
			return;
		}
		using (FmxCTqFyZGXywrgLGbaqBzsxxiFAb.Lock())
		{
			cFjfPMOeJoWHCCmHJbbCwiYRsENf = true;
		}
	}

	private void AZuiroveSmbdkHkqcGKdQNGBxdaUA(xdVIbvBoDAUiDeiBddhJTIMLUfnL P_0)
	{
		P_0.MgjjQDgztetiXAtlDTtQCqsvoxAm();
		if (qbdaneQKaILkpDGyhrfRiKmWnrkC)
		{
			return;
		}
		using (FmxCTqFyZGXywrgLGbaqBzsxxiFAb.Lock())
		{
			cFjfPMOeJoWHCCmHJbbCwiYRsENf = true;
		}
	}

	public void Dispose()
	{
		YhNyqZIXgaxhBuLkUeznquKWoBSf(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	protected virtual void wNuwILmuVpmxcXRgiaMZysCPNCg()
	{
		try
		{
			YhNyqZIXgaxhBuLkUeznquKWoBSf(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	protected virtual void YhNyqZIXgaxhBuLkUeznquKWoBSf(bool P_0)
	{
		if (qbdaneQKaILkpDGyhrfRiKmWnrkC)
		{
			return;
		}
		if (P_0)
		{
			ReInput.ApplicationFocusChangedEvent -= dJnvAxngVTwzxCJxjovfZeUClYWJ;
			ReInput.ApplicationPauseChangedEvent -= pQNfomyJeLyZPNBBSsrjTdcTloVK;
			xdVIbvBoDAUiDeiBddhJTIMLUfnL.bowhyGrXZIgGYbZPwlRcYxmYnjYh(KrdTCyughoxdJkYuGHhkQMYQMNoG);
			xdVIbvBoDAUiDeiBddhJTIMLUfnL.tJPDTKwTYRCZDaTLZmrlFkkRMkbC(AZuiroveSmbdkHkqcGKdQNGBxdaUA);
			hmRdjlkkAraUbAOZelrfFnsoEfpCB.ikUrOmsIKNMiTmyUGnratMoHlLVn().ThreadUpdateEvent -= vEkdyOArHnjcXbKguYyyNjuAdRHjA;
			hmRdjlkkAraUbAOZelrfFnsoEfpCB.kTOPdpvPqgeEoyxeFuEbAOuEacFu().ThreadUpdateEvent -= wukoDrpeSGTLqtrgeMBCvBtPUXas;
			using (FmxCTqFyZGXywrgLGbaqBzsxxiFAb.Lock())
			{
				for (int i = 0; i < nItBWFrYMsQdPnjUluAwJefYhaqW.Count; i++)
				{
					try
					{
						nItBWFrYMsQdPnjUluAwJefYhaqW[i].Dispose();
						nItBWFrYMsQdPnjUluAwJefYhaqW[i].xCgTQlybrxIaPNBwebMtalunPNVbA().MgjjQDgztetiXAtlDTtQCqsvoxAm();
					}
					catch
					{
					}
				}
				nItBWFrYMsQdPnjUluAwJefYhaqW.Clear();
				qoAFBketVCXFWnVynXsTqSKGDXzO.Clear();
			}
			try
			{
				xdVIbvBoDAUiDeiBddhJTIMLUfnL.OiuevfZVkoRgAYRZrTfCaKRHgkzDA();
			}
			catch
			{
			}
		}
		qbdaneQKaILkpDGyhrfRiKmWnrkC = true;
	}

	private static bool OoeiuhnipekEDcHPLjXStgPTGHIm(IList<CfENPjACeuDyUowrFIDWzqlxhXcF> P_0, xdVIbvBoDAUiDeiBddhJTIMLUfnL P_1)
	{
		return rLYAZSWJNeBbniZAZzBqEcpdaTUFb(P_0, P_1) >= 0;
	}

	private static bool JTcBvxPURYcmiidrHAStKnPQhBBCA(IList<xdVIbvBoDAUiDeiBddhJTIMLUfnL> P_0, xdVIbvBoDAUiDeiBddhJTIMLUfnL P_1)
	{
		return feNhmIfoQfWMTEKBKMNwIpFYjKVcb(P_0, P_1) >= 0;
	}

	private static int rLYAZSWJNeBbniZAZzBqEcpdaTUFb(IList<CfENPjACeuDyUowrFIDWzqlxhXcF> P_0, xdVIbvBoDAUiDeiBddhJTIMLUfnL P_1)
	{
		if (P_0 == null || xdVIbvBoDAUiDeiBddhJTIMLUfnL.nJgmfAWddMUvNUvIxrgRdCRlijMQ(P_1, null))
		{
			return -1;
		}
		for (int i = 0; i < P_0.Count; i++)
		{
			if (P_0[i] != null && xdVIbvBoDAUiDeiBddhJTIMLUfnL.nJgmfAWddMUvNUvIxrgRdCRlijMQ(P_0[i].xCgTQlybrxIaPNBwebMtalunPNVbA(), P_1))
			{
				return i;
			}
		}
		return -1;
	}

	private static int feNhmIfoQfWMTEKBKMNwIpFYjKVcb(IList<xdVIbvBoDAUiDeiBddhJTIMLUfnL> P_0, xdVIbvBoDAUiDeiBddhJTIMLUfnL P_1)
	{
		if (P_0 == null || xdVIbvBoDAUiDeiBddhJTIMLUfnL.nJgmfAWddMUvNUvIxrgRdCRlijMQ(P_1, null))
		{
			return -1;
		}
		for (int i = 0; i < P_0.Count; i++)
		{
			if (!xdVIbvBoDAUiDeiBddhJTIMLUfnL.nJgmfAWddMUvNUvIxrgRdCRlijMQ(P_0[i], null) && xdVIbvBoDAUiDeiBddhJTIMLUfnL.nJgmfAWddMUvNUvIxrgRdCRlijMQ(P_0[i], P_1))
			{
				return i;
			}
		}
		return -1;
	}

	static wsPALPmOMbTebMRwHLDiDviZUqac()
	{
		OLNQCBYMuVLKlwFFfBtJiylMHFvG = new Guid[1]
		{
			new Guid("02e0045e-0000-0000-0000-504944564944")
		};
		xxKtElVsAoHdDAiShSZqdogbvddI = new string[1] { "Xbox Bluetooth Gamepad" };
		dPtSrMYViOnhARNhFzUfsSYVsAQ = new string[1] { "Xbox Wireless Controller.*" };
	}

	public static bool XBURAkgurEQrTbrhdAkXrKfFGKAR(string P_0, string P_1, ushort P_2, ushort P_3)
	{
		if (string.IsNullOrEmpty(P_0))
		{
			return false;
		}
		if (!string.IsNullOrEmpty(P_1))
		{
			for (int i = 0; i < xxKtElVsAoHdDAiShSZqdogbvddI.Length; i++)
			{
				if (P_1.Equals(xxKtElVsAoHdDAiShSZqdogbvddI[i], StringComparison.OrdinalIgnoreCase))
				{
					return true;
				}
			}
			for (int j = 0; j < dPtSrMYViOnhARNhFzUfsSYVsAQ.Length; j++)
			{
				if (Regex.IsMatch(P_1, dPtSrMYViOnhARNhFzUfsSYVsAQ[j], RegexOptions.IgnoreCase))
				{
					return true;
				}
			}
		}
		string[] array = P_0.Split('#');
		if (array.Length < 2)
		{
			return false;
		}
		for (int k = 0; k < array.Length; k++)
		{
			string text = array[k].ToLower();
			if (text.Contains("pid_"))
			{
				int num = text.IndexOf("vid_");
				if (num >= 0 && text.IndexOf("ig_") >= num)
				{
					return true;
				}
			}
		}
		return false;
	}
}
