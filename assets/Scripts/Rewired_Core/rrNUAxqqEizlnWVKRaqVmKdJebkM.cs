using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Rewired;
using Rewired.Config;
using Rewired.Data;
using Rewired.Data.Mapping;
using Rewired.Interfaces;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;

internal sealed class rrNUAxqqEizlnWVKRaqVmKdJebkM : IDisposable
{
	public enum arueCAfDhShXXupeWRlAfckKNHxqB
	{
		Connected = 0,
		Disconnected = 1
	}

	private class rHuEjstEJqkQNHFJVauuaBRzTxpkA
	{
		public ADictionary<int, InputBehavior> muegPxSWknJYxxIrZrPgaPCBYLnE;

		public List<InputBehavior> AnNRgdsEvXxUHJepofbYoXaHpiHH;

		public IList<InputBehavior> TAEhACgWeBYyRIYZCMDFWBREJTPOA;

		public rHuEjstEJqkQNHFJVauuaBRzTxpkA(List<InputBehavior> P_0)
		{
			AnNRgdsEvXxUHJepofbYoXaHpiHH = new List<InputBehavior>(P_0.Count);
			muegPxSWknJYxxIrZrPgaPCBYLnE = new ADictionary<int, InputBehavior>();
			int num = 0;
			for (int i = 0; i < P_0.Count; i++)
			{
				InputBehavior inputBehavior = P_0[i].Clone();
				muegPxSWknJYxxIrZrPgaPCBYLnE.Add(P_0[i].id, inputBehavior);
				AnNRgdsEvXxUHJepofbYoXaHpiHH.Add(inputBehavior);
				num++;
			}
			TAEhACgWeBYyRIYZCMDFWBREJTPOA = new ReadOnlyCollection<InputBehavior>(AnNRgdsEvXxUHJepofbYoXaHpiHH);
		}

		public InputBehavior YFuxoysITtForgfxlHNdnLwuMcWz(int P_0)
		{
			if (AnNRgdsEvXxUHJepofbYoXaHpiHH.Count == 0)
			{
				return null;
			}
			muegPxSWknJYxxIrZrPgaPCBYLnE.TryGetValue(P_0, out var value);
			if (value == null)
			{
				return AnNRgdsEvXxUHJepofbYoXaHpiHH[0];
			}
			return value;
		}
	}

	private sealed class hoaGcxtrcqTIyckFUDLusXCAIJlV : IEnumerable<CustomController>, IEnumerable, IEnumerator<CustomController>, IEnumerator, IDisposable
	{
		private int bVSEMiWoSkdEFAbafllwzeozGALkA;

		private CustomController PrNkLgtDBZVisjYtHBczjKnIbkNP;

		private int pvJjSXMyvfbdPWjqNdLhjzdfASFDA;

		public rrNUAxqqEizlnWVKRaqVmKdJebkM aGuCqClLnwAjSOPmjMGWhBudRiDC;

		private int BmNhOaTLKQtAJXxsZeMFkCzCokJQ;

		public int agTfLIJmiSgYFGAKNVJqxLQBNZPK;

		private int JQoWPmbwUpAjEqcvmLbaCfDvvatH;

		private int fxFDIqmzVKpfKyqHPhyUFYVJPYW;

		CustomController IEnumerator<CustomController>.Current
		{
			[DebuggerHidden]
			get
			{
				return PrNkLgtDBZVisjYtHBczjKnIbkNP;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return PrNkLgtDBZVisjYtHBczjKnIbkNP;
			}
		}

		[DebuggerHidden]
		public hoaGcxtrcqTIyckFUDLusXCAIJlV(int P_0)
		{
			bVSEMiWoSkdEFAbafllwzeozGALkA = P_0;
			pvJjSXMyvfbdPWjqNdLhjzdfASFDA = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			int num = bVSEMiWoSkdEFAbafllwzeozGALkA;
			rrNUAxqqEizlnWVKRaqVmKdJebkM rrNUAxqqEizlnWVKRaqVmKdJebkM2 = aGuCqClLnwAjSOPmjMGWhBudRiDC;
			if (num != 0)
			{
				if (num != 1)
				{
					return false;
				}
				bVSEMiWoSkdEFAbafllwzeozGALkA = -1;
				goto IL_007d;
			}
			bVSEMiWoSkdEFAbafllwzeozGALkA = -1;
			JQoWPmbwUpAjEqcvmLbaCfDvvatH = rrNUAxqqEizlnWVKRaqVmKdJebkM2.oOJzaJuUNptKoxPEGGGmWLhvxyhV.Count;
			fxFDIqmzVKpfKyqHPhyUFYVJPYW = 0;
			goto IL_008d;
			IL_007d:
			fxFDIqmzVKpfKyqHPhyUFYVJPYW++;
			goto IL_008d;
			IL_008d:
			if (fxFDIqmzVKpfKyqHPhyUFYVJPYW < JQoWPmbwUpAjEqcvmLbaCfDvvatH)
			{
				if (rrNUAxqqEizlnWVKRaqVmKdJebkM2.oOJzaJuUNptKoxPEGGGmWLhvxyhV[fxFDIqmzVKpfKyqHPhyUFYVJPYW].sourceControllerId == BmNhOaTLKQtAJXxsZeMFkCzCokJQ)
				{
					PrNkLgtDBZVisjYtHBczjKnIbkNP = rrNUAxqqEizlnWVKRaqVmKdJebkM2.oOJzaJuUNptKoxPEGGGmWLhvxyhV[fxFDIqmzVKpfKyqHPhyUFYVJPYW];
					bVSEMiWoSkdEFAbafllwzeozGALkA = 1;
					return true;
				}
				goto IL_007d;
			}
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		IEnumerator<CustomController> IEnumerable<CustomController>.GetEnumerator()
		{
			hoaGcxtrcqTIyckFUDLusXCAIJlV hoaGcxtrcqTIyckFUDLusXCAIJlV2;
			if (bVSEMiWoSkdEFAbafllwzeozGALkA == -2 && pvJjSXMyvfbdPWjqNdLhjzdfASFDA == Environment.CurrentManagedThreadId)
			{
				bVSEMiWoSkdEFAbafllwzeozGALkA = 0;
				hoaGcxtrcqTIyckFUDLusXCAIJlV2 = this;
			}
			else
			{
				hoaGcxtrcqTIyckFUDLusXCAIJlV2 = new hoaGcxtrcqTIyckFUDLusXCAIJlV(0);
				hoaGcxtrcqTIyckFUDLusXCAIJlV2.aGuCqClLnwAjSOPmjMGWhBudRiDC = aGuCqClLnwAjSOPmjMGWhBudRiDC;
			}
			hoaGcxtrcqTIyckFUDLusXCAIJlV2.BmNhOaTLKQtAJXxsZeMFkCzCokJQ = agTfLIJmiSgYFGAKNVJqxLQBNZPK;
			return hoaGcxtrcqTIyckFUDLusXCAIJlV2;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<CustomController>)this).GetEnumerator();
		}
	}

	private sealed class hdeiiwdWnHEZCdglcqjgjNafcNQqc : IEnumerable<CustomController>, IEnumerable, IEnumerator<CustomController>, IEnumerator, IDisposable
	{
		private int ICxjMKFttASPucPfqTEtyxrVTokG;

		private CustomController wpsBDvBwXTwkOaTHNlHKbnDHlAjlB;

		private int vveYVFpWaSQlXzfwtwLtcLoDIkFjA;

		public rrNUAxqqEizlnWVKRaqVmKdJebkM OQnNpncfYfpkpHaDSHXtOxjWDzxZ;

		private string vVhTzvjmGUkxbIyMIPSaEQlEoJqM;

		public string MZPSXolYOIMFTObRRYSRLUUBOMox;

		private int ZWzgDjiIUBkWcKvXrOsohOFIKEnGA;

		private int DvTtdKzXFWkzzvqjkaTXkLIivajL;

		CustomController IEnumerator<CustomController>.Current
		{
			[DebuggerHidden]
			get
			{
				return wpsBDvBwXTwkOaTHNlHKbnDHlAjlB;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return wpsBDvBwXTwkOaTHNlHKbnDHlAjlB;
			}
		}

		[DebuggerHidden]
		public hdeiiwdWnHEZCdglcqjgjNafcNQqc(int P_0)
		{
			ICxjMKFttASPucPfqTEtyxrVTokG = P_0;
			vveYVFpWaSQlXzfwtwLtcLoDIkFjA = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			int iCxjMKFttASPucPfqTEtyxrVTokG = ICxjMKFttASPucPfqTEtyxrVTokG;
			rrNUAxqqEizlnWVKRaqVmKdJebkM oQnNpncfYfpkpHaDSHXtOxjWDzxZ = OQnNpncfYfpkpHaDSHXtOxjWDzxZ;
			if (iCxjMKFttASPucPfqTEtyxrVTokG != 0)
			{
				if (iCxjMKFttASPucPfqTEtyxrVTokG != 1)
				{
					return false;
				}
				ICxjMKFttASPucPfqTEtyxrVTokG = -1;
				goto IL_0083;
			}
			ICxjMKFttASPucPfqTEtyxrVTokG = -1;
			ZWzgDjiIUBkWcKvXrOsohOFIKEnGA = oQnNpncfYfpkpHaDSHXtOxjWDzxZ.oOJzaJuUNptKoxPEGGGmWLhvxyhV.Count;
			DvTtdKzXFWkzzvqjkaTXkLIivajL = 0;
			goto IL_0093;
			IL_0083:
			DvTtdKzXFWkzzvqjkaTXkLIivajL++;
			goto IL_0093;
			IL_0093:
			if (DvTtdKzXFWkzzvqjkaTXkLIivajL < ZWzgDjiIUBkWcKvXrOsohOFIKEnGA)
			{
				if (oQnNpncfYfpkpHaDSHXtOxjWDzxZ.oOJzaJuUNptKoxPEGGGmWLhvxyhV[DvTtdKzXFWkzzvqjkaTXkLIivajL].tag.Equals(vVhTzvjmGUkxbIyMIPSaEQlEoJqM, StringComparison.OrdinalIgnoreCase))
				{
					wpsBDvBwXTwkOaTHNlHKbnDHlAjlB = oQnNpncfYfpkpHaDSHXtOxjWDzxZ.oOJzaJuUNptKoxPEGGGmWLhvxyhV[DvTtdKzXFWkzzvqjkaTXkLIivajL];
					ICxjMKFttASPucPfqTEtyxrVTokG = 1;
					return true;
				}
				goto IL_0083;
			}
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		IEnumerator<CustomController> IEnumerable<CustomController>.GetEnumerator()
		{
			hdeiiwdWnHEZCdglcqjgjNafcNQqc hdeiiwdWnHEZCdglcqjgjNafcNQqc2;
			if (ICxjMKFttASPucPfqTEtyxrVTokG == -2 && vveYVFpWaSQlXzfwtwLtcLoDIkFjA == Environment.CurrentManagedThreadId)
			{
				ICxjMKFttASPucPfqTEtyxrVTokG = 0;
				hdeiiwdWnHEZCdglcqjgjNafcNQqc2 = this;
			}
			else
			{
				hdeiiwdWnHEZCdglcqjgjNafcNQqc2 = new hdeiiwdWnHEZCdglcqjgjNafcNQqc(0);
				hdeiiwdWnHEZCdglcqjgjNafcNQqc2.OQnNpncfYfpkpHaDSHXtOxjWDzxZ = OQnNpncfYfpkpHaDSHXtOxjWDzxZ;
			}
			hdeiiwdWnHEZCdglcqjgjNafcNQqc2.vVhTzvjmGUkxbIyMIPSaEQlEoJqM = MZPSXolYOIMFTObRRYSRLUUBOMox;
			return hdeiiwdWnHEZCdglcqjgjNafcNQqc2;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<CustomController>)this).GetEnumerator();
		}
	}

	private List<Joystick> oTIRSXwUOjVATBmccAzgFcTLhMNHA;

	private List<Joystick> ZaMUkTRBLXjTIUyOIrKXnzfNCuCo;

	private List<CustomController> oOJzaJuUNptKoxPEGGGmWLhvxyhV;

	private List<Controller> ObZPdSqKwwFwuAIVGCSnIxqnTNaB;

	private ReadOnlyCollection<Controller> MTpUrErBFlCcWHUrSZaNOMtBAcAIA;

	private Keyboard gtwrzRxKKsEjVlkbmBHrjBQtgkhxA;

	private Mouse TcXjdodExmGIMmvhgFqpjWPQzPMh;

	private ConfigVars tenMcSdqgzcnnjnEuNcnUTMiTgtKA;

	private QZWOxJToNpPZTYJKdjKDNrZDcbAQ[] HRpKxCgSCbzEccxrgCFMHMQFkGjC;

	private QZWOxJToNpPZTYJKdjKDNrZDcbAQ[] uXqIzqbxeCcEAqPLTyGCxllYinoB;

	private QZWOxJToNpPZTYJKdjKDNrZDcbAQ[,] rMlgDkOFFIXQqmNUWVhoaJsGOxZU;

	private CsuWQDIPMTIxKfmbavtLlqKTIzLM tqFIKahxXBNpyqlEjLNobyZXOuiG;

	private eOMcJCIodUuhCXeTEELrjrrqoFOTA IgmotzKhDDNEBmgJmeqdSIfbQBtF;

	private eOMcJCIodUuhCXeTEELrjrrqoFOTA[] QUYGGhIgnnnZUxhMFlIWfwiArqDjb;

	private global::GBxMQBzhoNzsKdLTURAnaIYqVJBS<ActiveControllerChangedDelegate> lPVUxHOiFiBThYCxQhMKDGieEGqAA;

	private global::GBxMQBzhoNzsKdLTURAnaIYqVJBS<PlayerActiveControllerChangedDelegate> URBRHYjQQUjTpYqvFydrGvDqtLDp;

	private global::GBxMQBzhoNzsKdLTURAnaIYqVJBS<PlayerActiveControllerChangedDelegate>[] WHXUgVDJwQUJvCNRrXBoKuOaaZxD;

	private ADictionary<int, rHuEjstEJqkQNHFJVauuaBRzTxpkA> bCXbwMDntUHypdRbcOpadcdHJPPl;

	private readonly nROoOyYVcGhAjqHnmScNrfHojVwE YuhSkoozRptQpIaqbACpDbzqnbGfb;

	private IList<Joystick> JAIDkmBmnMkfYXxJEJjYJKjoXiiQA;

	private IList<CustomController> RBcAsxfAVFFWYeEJBxoUduhawCuOc;

	private int GaKVoXjTGzlJLvxBUiQxjjUBLElj;

	private bool gKYejNFAmMjckjBhffaBtowqsZsv;

	private bool zinTNGHABDEdNGzbPDMOUnlnWrOf;

	private bool feAiUkdOABwprDKlbTDHQZJxJSLl;

	private IUnifiedKeyboardSource NjnNWIimpWqUqzrIDUTAJkinpGSr;

	private IUnifiedMouseSource RZvInilekGqrOqJRGmFPmkxCSYAC;

	private int lNIqyQiRHBZwAHeugkjRHrmBeVLD;

	private lQoAAQNPpFWyUNnFoiTjITGTmsQh PeugHLgavxVRyikNdZaUSCVbDplab;

	private PZIrFQmTYjOFmeiRPrMzBSOSvuwD InQdDIoPiLCppctRCEVYaZXCnFOAA;

	private int IuRfooLVUFdktOdFMYGlZwQfoAkk;

	private int vWWtcElEsXEtcJGPQydRMxGrXRbO;

	private Action<int, ControllerDataUpdater> WBHdBDkdWaXIAafJqgRfjFzUzABl;

	private Action<bool, int, int> zyYXGfDmfueAspJyRIHspSKxCOod;

	private Action<ControllerStatusChangedEventArgs> FzYTwXRdbcZjYErpvwwlmUFobKmH;

	private Action<ControllerType, int> zlSbRgBGndjVBXGjQjitgElRhXEBA;

	private bool VgOkyMzeqDFrEjWFWBgBVEWtpcAR;

	public IList<Joystick> XSgpEjLqlHEJZBOnBPWLgdjgPqad => EEbcrLiEhnvUlDgBBWavPqjmOUJZA();

	public List<Joystick> TFySqeYprKLJuvIGacJOjobbKAbeA => lUUvhGcwGnPyjgrGmbTdKKchIINw();

	public int TggAgzYaTxBOYmNxDAyvMgusWSWs => DgWkEwMpXTtCniXaqphVZqoNpNah();

	public Mouse dZKWEgbNlpGsNlyoomhwEhivuQcH => QEiqHFnLLZJSkuwNvWvNEjeQXMlT();

	public Keyboard xfIRxeAbZJFMpzIkZOTpRgtloPcA => CJDSMKuYTmJFQKoQSdBfaFNyeDGkA();

	public IList<CustomController> vruhLMdvfQDqPSGpGdzlxLZpCSQiA => oEBCyTxQXibzLFYTdcadMQGimPZS();

	public List<CustomController> JrprwqmpQTEjPuKnrALfIvTLekrGb => ykALPpOVkSEyMStpICgxuBddfhfq();

	public int udIIsZkRQkUxAtOPBULvRYXiXcOeA => iRWLoJbnOgesrOMvmrqqhNPmZYLV();

	public IList<Controller> MDOhjRjDjCqlLiamHfTLFnCbigpUA => YetqXxUEGPeQRCqyyCXaVhfrClnN();

	public int KPpGrvoZoJvkkNTnXpFinRSGaWIK => pOFmLNpHHlXSdmUtdhorPuqYdUpI();

	private int iACkUHMbnpTEQbNJoAxbuyctyvCD => YYXeiOgVFvAcwgWSngmPHTBMYgEfA();

	public event Action<ControllerStatusChangedEventArgs> NnCbJyMPlIbpdmckJqQxeWkXqWed
	{
		add
		{
			vsNscyxBZOhEpbDKCYkLRAiUHcml(action);
		}
		remove
		{
			KLVbOoMinGVzoAafOlrcFLTKrqbO(action);
		}
	}

	public event Action<ControllerType, int> bAfnhsYBFRWHhGuFEiAZGAZyxFPx
	{
		add
		{
			LTMeRkwEVNEJBVjAeirnVOQnbnEKA(action);
		}
		remove
		{
			qQcHyQWlRPFmJYnSgYLErpUkBUqaA(action);
		}
	}

	public void vsNscyxBZOhEpbDKCYkLRAiUHcml(Action<ControllerStatusChangedEventArgs> P_0)
	{
		FzYTwXRdbcZjYErpvwwlmUFobKmH = (Action<ControllerStatusChangedEventArgs>)Delegate.Combine(FzYTwXRdbcZjYErpvwwlmUFobKmH, P_0);
	}

	public void KLVbOoMinGVzoAafOlrcFLTKrqbO(Action<ControllerStatusChangedEventArgs> P_0)
	{
		FzYTwXRdbcZjYErpvwwlmUFobKmH = (Action<ControllerStatusChangedEventArgs>)Delegate.Remove(FzYTwXRdbcZjYErpvwwlmUFobKmH, P_0);
	}

	public void LTMeRkwEVNEJBVjAeirnVOQnbnEKA(Action<ControllerType, int> P_0)
	{
		zlSbRgBGndjVBXGjQjitgElRhXEBA = (Action<ControllerType, int>)Delegate.Combine(zlSbRgBGndjVBXGjQjitgElRhXEBA, P_0);
	}

	public void qQcHyQWlRPFmJYnSgYLErpUkBUqaA(Action<ControllerType, int> P_0)
	{
		zlSbRgBGndjVBXGjQjitgElRhXEBA = (Action<ControllerType, int>)Delegate.Remove(zlSbRgBGndjVBXGjQjitgElRhXEBA, P_0);
	}

	public rrNUAxqqEizlnWVKRaqVmKdJebkM(ConfigVars P_0, PlatformInputManager P_1)
	{
		tenMcSdqgzcnnjnEuNcnUTMiTgtKA = P_0;
		GaKVoXjTGzlJLvxBUiQxjjUBLElj = 0;
		gKYejNFAmMjckjBhffaBtowqsZsv = UnityTools.isAndroidPlatform;
		ObZPdSqKwwFwuAIVGCSnIxqnTNaB = new List<Controller>(10);
		MTpUrErBFlCcWHUrSZaNOMtBAcAIA = new ReadOnlyCollection<Controller>(ObZPdSqKwwFwuAIVGCSnIxqnTNaB);
		IUnifiedKeyboardSource unifiedKeyboardSource = P_1.GetUnifiedKeyboardSource();
		if (unifiedKeyboardSource == null)
		{
			unifiedKeyboardSource = (NjnNWIimpWqUqzrIDUTAJkinpGSr = new UnityUnifiedKeyboardSource());
		}
		gtwrzRxKKsEjVlkbmBHrjBQtgkhxA = new Keyboard("Keyboard", unifiedKeyboardSource);
		ObZPdSqKwwFwuAIVGCSnIxqnTNaB.Add(gtwrzRxKKsEjVlkbmBHrjBQtgkhxA);
		IUnifiedMouseSource unifiedMouseSource = P_1.GetUnifiedMouseSource();
		if (unifiedMouseSource == null)
		{
			unifiedMouseSource = (RZvInilekGqrOqJRGmFPmkxCSYAC = new UnityUnifiedMouseSource());
		}
		TcXjdodExmGIMmvhgFqpjWPQzPMh = new Mouse("Mouse", unifiedMouseSource);
		ObZPdSqKwwFwuAIVGCSnIxqnTNaB.Add(TcXjdodExmGIMmvhgFqpjWPQzPMh);
		tqFIKahxXBNpyqlEjLNobyZXOuiG = new CsuWQDIPMTIxKfmbavtLlqKTIzLM(P_0.updateLoop, gtwrzRxKKsEjVlkbmBHrjBQtgkhxA);
		gtwrzRxKKsEjVlkbmBHrjBQtgkhxA.cjCjEMGfuzPQfnEVaVjjnGMccqCP(kxYXOczGbGYovRKhRmtTknTLOQki);
		gtwrzRxKKsEjVlkbmBHrjBQtgkhxA.enabled = !P_0.GetPlatformVar_disableKeyboard();
		TcXjdodExmGIMmvhgFqpjWPQzPMh.enabled = !P_0.GetPlatformVar_disableMouse();
		aDUCqjsWGxDXIwuIpmtzILnQOsNU.ehpRDIFFjLggLXgPiiCqHwXXiTuP();
		YuhSkoozRptQpIaqbACpDbzqnbGfb = new nROoOyYVcGhAjqHnmScNrfHojVwE(UnityTools.externalTools.GetControllerTemplateTypes(), UnityTools.externalTools.GetControllerTemplateInterfaceTypes());
		YuhSkoozRptQpIaqbACpDbzqnbGfb.NwCwRIqaKzXsvjtkBWSnlYNaVrQU(gtwrzRxKKsEjVlkbmBHrjBQtgkhxA);
		YuhSkoozRptQpIaqbACpDbzqnbGfb.NwCwRIqaKzXsvjtkBWSnlYNaVrQU(TcXjdodExmGIMmvhgFqpjWPQzPMh);
		ReInput.ApplicationFocusChangedEvent += wvficJCHzdjANZlZgBkKcQPtVPNc;
	}

	public IList<Joystick> EEbcrLiEhnvUlDgBBWavPqjmOUJZA()
	{
		return JAIDkmBmnMkfYXxJEJjYJKjoXiiQA;
	}

	public List<Joystick> lUUvhGcwGnPyjgrGmbTdKKchIINw()
	{
		return oTIRSXwUOjVATBmccAzgFcTLhMNHA;
	}

	public int DgWkEwMpXTtCniXaqphVZqoNpNah()
	{
		return oTIRSXwUOjVATBmccAzgFcTLhMNHA.Count;
	}

	public Mouse QEiqHFnLLZJSkuwNvWvNEjeQXMlT()
	{
		return TcXjdodExmGIMmvhgFqpjWPQzPMh;
	}

	public Keyboard CJDSMKuYTmJFQKoQSdBfaFNyeDGkA()
	{
		return gtwrzRxKKsEjVlkbmBHrjBQtgkhxA;
	}

	public IList<CustomController> oEBCyTxQXibzLFYTdcadMQGimPZS()
	{
		return RBcAsxfAVFFWYeEJBxoUduhawCuOc;
	}

	public List<CustomController> ykALPpOVkSEyMStpICgxuBddfhfq()
	{
		return oOJzaJuUNptKoxPEGGGmWLhvxyhV;
	}

	public int iRWLoJbnOgesrOMvmrqqhNPmZYLV()
	{
		return oOJzaJuUNptKoxPEGGGmWLhvxyhV.Count;
	}

	public void CoffVmbmnIFbLiPsHFTYPoKcelCPD(Action<int, ControllerDataUpdater> P_0, List<InputBehavior> P_1)
	{
		WBHdBDkdWaXIAafJqgRfjFzUzABl = P_0;
		ytcgKyhhjrujQnbacaxXdaFqZELeA(P_1);
	}

	public void qxOhWFAsFIAojJSQpPYYmbIBYsiJ(UpdateLoopType P_0)
	{
		aDUCqjsWGxDXIwuIpmtzILnQOsNU.xggZiVEAkgrxjxEQESKEagoiJQzq(P_0);
		if (gtwrzRxKKsEjVlkbmBHrjBQtgkhxA.enabled)
		{
			tqFIKahxXBNpyqlEjLNobyZXOuiG.ufwustrwRTFIBFUbNvAwjKpnagS(P_0);
		}
		GIvgoZEFPabbzFzhgzwnNxXpCkjub(P_0);
		yqqPKpYmVpquOcdeRIGvaGIGJxKEb(P_0);
		aDUCqjsWGxDXIwuIpmtzILnQOsNU.dKVhHtzJibGYJaTbVmBVNUnvZeeT(P_0, ReInput.currentFrame);
		if (feAiUkdOABwprDKlbTDHQZJxJSLl)
		{
			bZhtiAqMSYVQzLyNUPbiEvwXzwCL();
		}
	}

	public QZWOxJToNpPZTYJKdjKDNrZDcbAQ PKzDxdNXFVjWIeVjZiJxNOwUmSLU(int P_0, string P_1, bool P_2)
	{
		int num = PeugHLgavxVRyikNdZaUSCVbDplab.vCinmjnHPaVfEgIwLuJwdcpFgEfBA(P_1, P_2);
		if (num < 0)
		{
			return null;
		}
		if (P_0 == 9999999)
		{
			return uXqIzqbxeCcEAqPLTyGCxllYinoB[num];
		}
		if (P_0 < 0 || P_0 >= IuRfooLVUFdktOdFMYGlZwQfoAkk)
		{
			return null;
		}
		return rMlgDkOFFIXQqmNUWVhoaJsGOxZU[P_0, num];
	}

	public QZWOxJToNpPZTYJKdjKDNrZDcbAQ tfgFiWTAWZlOVgeKFIvByhHrMtkg(int P_0, int P_1, bool P_2)
	{
		int num = PeugHLgavxVRyikNdZaUSCVbDplab.ePMNZIYbjJltQRETydtleyDTFxII(P_1, P_2);
		if (num < 0)
		{
			return null;
		}
		if (P_0 == 9999999)
		{
			return uXqIzqbxeCcEAqPLTyGCxllYinoB[num];
		}
		return rMlgDkOFFIXQqmNUWVhoaJsGOxZU[P_0, num];
	}

	public void qIJKvNxZaquKrbzVxYfTtMmoiMbj(UpdateControllerInfoEventArgs P_0)
	{
		if (P_0 != null && P_0.sourceJoystick != null)
		{
			arueCAfDhShXXupeWRlAfckKNHxqB arueCAfDhShXXupeWRlAfckKNHxqB2 = arueCAfDhShXXupeWRlAfckKNHxqB.Connected;
			int num = dNmavkfMEsDwETVXZEzxvnXdWvVoA(P_0.sourceJoystick.rewiredId, arueCAfDhShXXupeWRlAfckKNHxqB2);
			if (num < 0)
			{
				arueCAfDhShXXupeWRlAfckKNHxqB2 = arueCAfDhShXXupeWRlAfckKNHxqB.Disconnected;
				num = dNmavkfMEsDwETVXZEzxvnXdWvVoA(P_0.sourceJoystick.rewiredId, arueCAfDhShXXupeWRlAfckKNHxqB2);
			}
			if (num >= 0)
			{
				((arueCAfDhShXXupeWRlAfckKNHxqB2 == arueCAfDhShXXupeWRlAfckKNHxqB.Connected) ? oTIRSXwUOjVATBmccAzgFcTLhMNHA[num] : ZaMUkTRBLXjTIUyOIrKXnzfNCuCo[num]).kiuZSNAruXRwuGThZtaieGgLiusl(P_0);
			}
		}
	}

	public bool eSSlmAAsQWRuajbZWapHGJPOuLQo(int P_0, arueCAfDhShXXupeWRlAfckKNHxqB P_1)
	{
		if (dNmavkfMEsDwETVXZEzxvnXdWvVoA(P_0, P_1) < 0)
		{
			return false;
		}
		return true;
	}

	public int dNmavkfMEsDwETVXZEzxvnXdWvVoA(int P_0, arueCAfDhShXXupeWRlAfckKNHxqB P_1)
	{
		switch (P_1)
		{
		case arueCAfDhShXXupeWRlAfckKNHxqB.Connected:
		{
			int count2 = oTIRSXwUOjVATBmccAzgFcTLhMNHA.Count;
			for (int j = 0; j < count2; j++)
			{
				if (oTIRSXwUOjVATBmccAzgFcTLhMNHA[j].id == P_0)
				{
					return j;
				}
			}
			break;
		}
		case arueCAfDhShXXupeWRlAfckKNHxqB.Disconnected:
		{
			int count = ZaMUkTRBLXjTIUyOIrKXnzfNCuCo.Count;
			for (int i = 0; i < count; i++)
			{
				if (ZaMUkTRBLXjTIUyOIrKXnzfNCuCo[i].id == P_0)
				{
					return i;
				}
			}
			break;
		}
		}
		return -1;
	}

	public int oVXKZfwVMVEohUcmThVEpLeADtqo(Guid P_0, arueCAfDhShXXupeWRlAfckKNHxqB P_1)
	{
		switch (P_1)
		{
		case arueCAfDhShXXupeWRlAfckKNHxqB.Connected:
		{
			int count2 = oTIRSXwUOjVATBmccAzgFcTLhMNHA.Count;
			for (int j = 0; j < count2; j++)
			{
				if (oTIRSXwUOjVATBmccAzgFcTLhMNHA[j].deviceInstanceGuid == P_0)
				{
					return j;
				}
			}
			break;
		}
		case arueCAfDhShXXupeWRlAfckKNHxqB.Disconnected:
		{
			int count = ZaMUkTRBLXjTIUyOIrKXnzfNCuCo.Count;
			for (int i = 0; i < count; i++)
			{
				if (ZaMUkTRBLXjTIUyOIrKXnzfNCuCo[i].deviceInstanceGuid == P_0)
				{
					return i;
				}
			}
			break;
		}
		}
		return -1;
	}

	public bool fhvsllVbAaATsCZsWPEVmbllObzo(int P_0)
	{
		if (tRrJygWpLbqktblZlmKxZHsMGVtiA(P_0) < 0)
		{
			return false;
		}
		return true;
	}

	public int tRrJygWpLbqktblZlmKxZHsMGVtiA(int P_0)
	{
		int count = oOJzaJuUNptKoxPEGGGmWLhvxyhV.Count;
		for (int i = 0; i < count; i++)
		{
			if (oOJzaJuUNptKoxPEGGGmWLhvxyhV[i].id == P_0)
			{
				return i;
			}
		}
		return -1;
	}

	public int iUovLljphMFYncBcnolbpREmxXRY(Guid P_0)
	{
		int count = oOJzaJuUNptKoxPEGGGmWLhvxyhV.Count;
		for (int i = 0; i < count; i++)
		{
			if (oOJzaJuUNptKoxPEGGGmWLhvxyhV[i].deviceInstanceGuid == P_0)
			{
				return i;
			}
		}
		return -1;
	}

	public void MZSqepAMvCGEUUSWPaGzYVtZfzkX(BridgedController P_0)
	{
		FstiZLOkEtgKdwOvIkveNSJyICrl(P_0);
	}

	public void HxsXeHbHIrEZowOGaGQrtmzDaWNT(int P_0)
	{
		int num = dNmavkfMEsDwETVXZEzxvnXdWvVoA(P_0, arueCAfDhShXXupeWRlAfckKNHxqB.Connected);
		CHBThrgmQqHDmLGNzWjSTJJBcgQJ(num);
	}

	public int wbLVUZcAndPoAHjIMjDACtdSNktG()
	{
		return GaKVoXjTGzlJLvxBUiQxjjUBLElj++;
	}

	public IList<InputBehavior> izqLvkKDlFDzgajxGeteFupmnbXi(int P_0)
	{
		if (!bCXbwMDntUHypdRbcOpadcdHJPPl.ContainsKey(P_0))
		{
			return new List<InputBehavior>();
		}
		return bCXbwMDntUHypdRbcOpadcdHJPPl.get_Item(P_0).TAEhACgWeBYyRIYZCMDFWBREJTPOA;
	}

	public InputBehavior nTzpCiyaupxejSxqAqKddbAtpDvL(int P_0, string P_1)
	{
		if (P_1 == null || P_1 == string.Empty)
		{
			return null;
		}
		int inputBehaviorId = ReInput.mapping.GetInputBehaviorId(P_1);
		return uyBqFIyZpwLzlzouiLRXfbnAHPne(P_0, inputBehaviorId);
	}

	public InputBehavior uyBqFIyZpwLzlzouiLRXfbnAHPne(int P_0, int P_1)
	{
		if (!bCXbwMDntUHypdRbcOpadcdHJPPl.ContainsKey(P_0))
		{
			return null;
		}
		IList<InputBehavior> tAEhACgWeBYyRIYZCMDFWBREJTPOA = bCXbwMDntUHypdRbcOpadcdHJPPl.get_Item(P_0).TAEhACgWeBYyRIYZCMDFWBREJTPOA;
		for (int i = 0; i < tAEhACgWeBYyRIYZCMDFWBREJTPOA.Count; i++)
		{
			if (tAEhACgWeBYyRIYZCMDFWBREJTPOA[i].id == P_1)
			{
				return tAEhACgWeBYyRIYZCMDFWBREJTPOA[i];
			}
		}
		return null;
	}

	public Joystick YYiuqUYQXVQfqAVVHuCdeZVvlDuO(int P_0, bool P_1 = false)
	{
		int num = dNmavkfMEsDwETVXZEzxvnXdWvVoA(P_0, arueCAfDhShXXupeWRlAfckKNHxqB.Connected);
		if (num >= 0)
		{
			return oTIRSXwUOjVATBmccAzgFcTLhMNHA[num];
		}
		if (P_1)
		{
			num = dNmavkfMEsDwETVXZEzxvnXdWvVoA(P_0, arueCAfDhShXXupeWRlAfckKNHxqB.Disconnected);
			if (num >= 0)
			{
				return ZaMUkTRBLXjTIUyOIrKXnzfNCuCo[num];
			}
		}
		return null;
	}

	public Joystick VTQKWwlMSwIJyOvKYGuJZCfpbTbx(Guid P_0, bool P_1 = false)
	{
		int num = oVXKZfwVMVEohUcmThVEpLeADtqo(P_0, arueCAfDhShXXupeWRlAfckKNHxqB.Connected);
		if (num >= 0)
		{
			return oTIRSXwUOjVATBmccAzgFcTLhMNHA[num];
		}
		if (P_1)
		{
			num = oVXKZfwVMVEohUcmThVEpLeADtqo(P_0, arueCAfDhShXXupeWRlAfckKNHxqB.Disconnected);
			if (num >= 0)
			{
				return ZaMUkTRBLXjTIUyOIrKXnzfNCuCo[num];
			}
		}
		return null;
	}

	public Joystick[] OlTVyyKrYbhIthgmlhMjBGqpgQLkA()
	{
		int count = oTIRSXwUOjVATBmccAzgFcTLhMNHA.Count;
		if (count == 0)
		{
			return EmptyObjects<Joystick>.array;
		}
		Joystick[] array = new Joystick[count];
		for (int i = 0; i < count; i++)
		{
			array[i] = oTIRSXwUOjVATBmccAzgFcTLhMNHA[i];
		}
		return array;
	}

	public string[] PSvkQmuCvkwjUMJYCqiGWFVcjwcB()
	{
		int count = oTIRSXwUOjVATBmccAzgFcTLhMNHA.Count;
		if (count == 0)
		{
			return EmptyObjects<string>.array;
		}
		string[] array = new string[count];
		for (int i = 0; i < count; i++)
		{
			array[i] = oTIRSXwUOjVATBmccAzgFcTLhMNHA[i].name;
		}
		return array;
	}

	public CustomController cNvGhiLhBqBkMjstwPCFpIgHOEJPA(int P_0)
	{
		int num = tRrJygWpLbqktblZlmKxZHsMGVtiA(P_0);
		if (num < 0)
		{
			return null;
		}
		return oOJzaJuUNptKoxPEGGGmWLhvxyhV[num];
	}

	public CustomController prpCDUShsFQWavtVFweRxyeawbce(Guid P_0)
	{
		int num = iUovLljphMFYncBcnolbpREmxXRY(P_0);
		if (num < 0)
		{
			return null;
		}
		return oOJzaJuUNptKoxPEGGGmWLhvxyhV[num];
	}

	public CustomController[] dpzWurkNAYaGurHoUPRvylHcBkoc()
	{
		int count = oOJzaJuUNptKoxPEGGGmWLhvxyhV.Count;
		if (count == 0)
		{
			return EmptyObjects<CustomController>.array;
		}
		CustomController[] array = new CustomController[count];
		for (int i = 0; i < count; i++)
		{
			array[i] = oOJzaJuUNptKoxPEGGGmWLhvxyhV[i];
		}
		return array;
	}

	public string[] IzqWIAEvFXrjaSNXLlvongQnbgKU()
	{
		int count = oOJzaJuUNptKoxPEGGGmWLhvxyhV.Count;
		if (count == 0)
		{
			return EmptyObjects<string>.array;
		}
		string[] array = new string[count];
		for (int i = 0; i < count; i++)
		{
			array[i] = oOJzaJuUNptKoxPEGGGmWLhvxyhV[i].name;
		}
		return array;
	}

	public CustomController oaWEUwQBJYSYwzCbnvEfgAPDfPNDA(int P_0)
	{
		CustomController_Editor customControllerById = ReInput.UserData.GetCustomControllerById(P_0);
		if (customControllerById == null)
		{
			return null;
		}
		int jeXxVLjbyIBqMwmbLwVUsNIsEMdL = YYXeiOgVFvAcwgWSngmPHTBMYgEfA();
		CustomController customController = new CustomController(new PzwBCfxuWqkkCSbfSUVoirirCnBr
		{
			YKBFIjjwavffEGQoQROkfEyWTPFFA = InputSource.Custom,
			nBMGFeRxhFSuEGfKjcFBqBYcPkLW = customControllerById.descriptiveName,
			ZlXBEgrpbBztECARDGxqfrvyhWlxA = customControllerById.name,
			TXUkUipShDqAsHOVPrhKfXvjINcV = customControllerById.axisCount,
			oKRyTyCKJSqaIkabtLhFvqNceSKp = customControllerById.buttonCount,
			JeXxVLjbyIBqMwmbLwVUsNIsEMdL = jeXxVLjbyIBqMwmbLwVUsNIsEMdL,
			XSyXCSYaWEbIQklYxeZnDtqilZMeb = customControllerById.id,
			qPEgCFqjTYPTukGRfbqeJRCnvCBmA = customControllerById.typeGuid,
			FWENtMBmCimgVMdAizAVrACbJmwl = customControllerById.id.ToString(),
			mpPmNaySUqsItJpQuTugHYRJMYxD = customControllerById.CreateGameHardwareMap()
		});
		yliapdHomTdeInAYAWPJlSqwpTLl(customController);
		return customController;
	}

	public bool TfgIHSqQsObdHhgJlJbYDvPtGznq(CustomController P_0)
	{
		if (P_0 == null)
		{
			return false;
		}
		return slAKJRZqmuWgxXVCWAfvybXVRuvn(P_0);
	}

	public CustomController ZReYteTbCRHDzfhYIAYCGBSAabcdb(int P_0)
	{
		int count = oOJzaJuUNptKoxPEGGGmWLhvxyhV.Count;
		for (int i = 0; i < count; i++)
		{
			if (oOJzaJuUNptKoxPEGGGmWLhvxyhV[i].sourceControllerId == P_0)
			{
				return oOJzaJuUNptKoxPEGGGmWLhvxyhV[i];
			}
		}
		return null;
	}

	public CustomController coyYsFjtpyMjvGJMHYBJfJddaTdP(string P_0)
	{
		int count = oOJzaJuUNptKoxPEGGGmWLhvxyhV.Count;
		for (int i = 0; i < count; i++)
		{
			if (oOJzaJuUNptKoxPEGGGmWLhvxyhV[i].tag.Equals(P_0, StringComparison.OrdinalIgnoreCase))
			{
				return oOJzaJuUNptKoxPEGGGmWLhvxyhV[i];
			}
		}
		return null;
	}

	[IteratorStateMachine(typeof(hoaGcxtrcqTIyckFUDLusXCAIJlV))]
	public IEnumerable<CustomController> MinawsELaisjszvkgzDelEepVYWy(int P_0)
	{
		return new hoaGcxtrcqTIyckFUDLusXCAIJlV(-2)
		{
			aGuCqClLnwAjSOPmjMGWhBudRiDC = this,
			agTfLIJmiSgYFGAKNVJqxLQBNZPK = P_0
		};
	}

	[IteratorStateMachine(typeof(hdeiiwdWnHEZCdglcqjgjNafcNQqc))]
	public IEnumerable<CustomController> VxMEqFMbwvBFyrrIjLKlGcpDyDoI(string P_0)
	{
		return new hdeiiwdWnHEZCdglcqjgjNafcNQqc(-2)
		{
			OQnNpncfYfpkpHaDSHXtOxjWDzxZ = this,
			MZPSXolYOIMFTObRRYSRLUUBOMox = P_0
		};
	}

	public IList<Controller> YetqXxUEGPeQRCqyyCXaVhfrClnN()
	{
		return MTpUrErBFlCcWHUrSZaNOMtBAcAIA;
	}

	public int pOFmLNpHHlXSdmUtdhorPuqYdUpI()
	{
		return ObZPdSqKwwFwuAIVGCSnIxqnTNaB.Count;
	}

	public Controller qLXmBGgOrsBKkXyijYLMvlwfrnKd(ControllerType P_0, int P_1, bool P_2 = false)
	{
		return P_0 switch
		{
			ControllerType.Joystick => YYiuqUYQXVQfqAVVHuCdeZVvlDuO(P_1, P_2), 
			ControllerType.Keyboard => gtwrzRxKKsEjVlkbmBHrjBQtgkhxA, 
			ControllerType.Mouse => TcXjdodExmGIMmvhgFqpjWPQzPMh, 
			ControllerType.Custom => cNvGhiLhBqBkMjstwPCFpIgHOEJPA(P_1), 
			_ => throw new NotImplementedException(), 
		};
	}

	public Controller yFVHNGFipkTnAhiniBHCFElVkRXm(ControllerIdentifier P_0, bool P_1 = false)
	{
		if (P_0.deviceInstanceGuid != Guid.Empty)
		{
			return JhijaIdQzsoNAakyjkcAFslxbgIc(P_0.deviceInstanceGuid);
		}
		if (P_0.controllerId >= 0)
		{
			return qLXmBGgOrsBKkXyijYLMvlwfrnKd(P_0.controllerType, P_0.controllerId, P_1);
		}
		return null;
	}

	public Controller JhijaIdQzsoNAakyjkcAFslxbgIc(Guid P_0, bool P_1 = false)
	{
		if (P_0 == Guid.Empty)
		{
			return null;
		}
		if (gtwrzRxKKsEjVlkbmBHrjBQtgkhxA.deviceInstanceGuid == P_0)
		{
			return gtwrzRxKKsEjVlkbmBHrjBQtgkhxA;
		}
		if (TcXjdodExmGIMmvhgFqpjWPQzPMh.deviceInstanceGuid == P_0)
		{
			return TcXjdodExmGIMmvhgFqpjWPQzPMh;
		}
		Controller result;
		if ((result = VTQKWwlMSwIJyOvKYGuJZCfpbTbx(P_0, P_1)) != null)
		{
			return result;
		}
		if ((result = prpCDUShsFQWavtVFweRxyeawbce(P_0)) != null)
		{
			return result;
		}
		return null;
	}

	public Controller[] TteiMHtSpVSPKPfmPaMamFMlYEGW(ControllerType P_0)
	{
		return P_0 switch
		{
			ControllerType.Joystick => OlTVyyKrYbhIthgmlhMjBGqpgQLkA(), 
			ControllerType.Keyboard => new Controller[1] { gtwrzRxKKsEjVlkbmBHrjBQtgkhxA }, 
			ControllerType.Mouse => new Controller[1] { TcXjdodExmGIMmvhgFqpjWPQzPMh }, 
			ControllerType.Custom => dpzWurkNAYaGurHoUPRvylHcBkoc(), 
			_ => throw new NotImplementedException(), 
		};
	}

	public string[] FCawKZuaMNERONyyHTItVhQCqZPB(ControllerType P_0)
	{
		return P_0 switch
		{
			ControllerType.Joystick => PSvkQmuCvkwjUMJYCqiGWFVcjwcB(), 
			ControllerType.Keyboard => new string[1] { gtwrzRxKKsEjVlkbmBHrjBQtgkhxA.name }, 
			ControllerType.Mouse => new string[1] { TcXjdodExmGIMmvhgFqpjWPQzPMh.name }, 
			ControllerType.Custom => IzqWIAEvFXrjaSNXLlvongQnbgKU(), 
			_ => throw new NotImplementedException(), 
		};
	}

	public void VEDeIKbNmpKpVHoyErOovBGffhwub(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2)
	{
		if (!zinTNGHABDEdNGzbPDMOUnlnWrOf)
		{
			zinTNGHABDEdNGzbPDMOUnlnWrOf = true;
		}
		BDFIZuioLTscknOWXNwkqCJsbrFuA(P_0)?.FEBcZbkXiTESCIkJazItmlapfendA(P_1, P_2, InputActionEventType.Update, null);
	}

	public void dqFdaJHbrcgaWEqXPMIHZsBkkhJGb(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2, int P_3)
	{
		if (!zinTNGHABDEdNGzbPDMOUnlnWrOf)
		{
			zinTNGHABDEdNGzbPDMOUnlnWrOf = true;
		}
		BDFIZuioLTscknOWXNwkqCJsbrFuA(P_0)?.dpxvLRbbnXcLfzYhQvPFeAhSWGTV(P_1, P_2, InputActionEventType.Update, P_3, null);
	}

	public void hYfdYSPNSRdUaFpjCCSUwAyacyid(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2, string P_3)
	{
		if (!zinTNGHABDEdNGzbPDMOUnlnWrOf)
		{
			zinTNGHABDEdNGzbPDMOUnlnWrOf = true;
		}
		int num = ReInput.IsSPFehscBAmxtEADWGWuasjDvqf.GhVjGDQeDQmOWTnROakHcfdeCdDd(P_3);
		if (num >= 0)
		{
			dqFdaJHbrcgaWEqXPMIHZsBkkhJGb(P_0, P_1, P_2, num);
		}
	}

	public void hjzokbvniROewDSLtnhGBmcDPqcJ(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2, InputActionEventType P_3, object[] P_4)
	{
		if (!zinTNGHABDEdNGzbPDMOUnlnWrOf)
		{
			zinTNGHABDEdNGzbPDMOUnlnWrOf = true;
		}
		BDFIZuioLTscknOWXNwkqCJsbrFuA(P_0)?.FEBcZbkXiTESCIkJazItmlapfendA(P_1, P_2, P_3, P_4);
	}

	public void ymIhpVqHueudVoZxQPMzyyWySVI(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2, InputActionEventType P_3, int P_4, object[] P_5)
	{
		if (!zinTNGHABDEdNGzbPDMOUnlnWrOf)
		{
			zinTNGHABDEdNGzbPDMOUnlnWrOf = true;
		}
		BDFIZuioLTscknOWXNwkqCJsbrFuA(P_0)?.dpxvLRbbnXcLfzYhQvPFeAhSWGTV(P_1, P_2, P_3, P_4, P_5);
	}

	public void jSwJxgczCPLmavKgwVoJRTHfaaIh(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2, InputActionEventType P_3, string P_4, object[] P_5)
	{
		if (!zinTNGHABDEdNGzbPDMOUnlnWrOf)
		{
			zinTNGHABDEdNGzbPDMOUnlnWrOf = true;
		}
		int num = ReInput.IsSPFehscBAmxtEADWGWuasjDvqf.GhVjGDQeDQmOWTnROakHcfdeCdDd(P_4);
		if (num >= 0)
		{
			ymIhpVqHueudVoZxQPMzyyWySVI(P_0, P_1, P_2, P_3, num, P_5);
		}
	}

	public void dLaypZmXtKbCvQusacZnpBqPvznI(int P_0, Action<InputActionEventData> P_1)
	{
		BDFIZuioLTscknOWXNwkqCJsbrFuA(P_0)?.CfHlHrXglScxffaiOdmnINGFrpai(P_1);
	}

	public void zVGItQgmvBjdZEJeldlFIhlNyGMx(int P_0, Action<InputActionEventData> P_1, int P_2)
	{
		BDFIZuioLTscknOWXNwkqCJsbrFuA(P_0)?.UakGciaDIxJUYGBibsrdZluwrjMpc(P_1, P_2);
	}

	public void QvmQgwenKTqylxysPYlCqveQUEzb(int P_0, Action<InputActionEventData> P_1, string P_2)
	{
		int num = ReInput.IsSPFehscBAmxtEADWGWuasjDvqf.GhVjGDQeDQmOWTnROakHcfdeCdDd(P_2);
		if (num >= 0)
		{
			zVGItQgmvBjdZEJeldlFIhlNyGMx(P_0, P_1, num);
		}
	}

	public void NIxAKIifeuvMaGfLNQvPiqEeyPmA(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2)
	{
		BDFIZuioLTscknOWXNwkqCJsbrFuA(P_0)?.KhoaUzgQxvYRLwqngLXoKKpicCog(P_1, P_2);
	}

	public void CYfsLPBBqxnjNAtfkkEqDopgoGWX(int P_0, Action<InputActionEventData> P_1, InputActionEventType P_2)
	{
		BDFIZuioLTscknOWXNwkqCJsbrFuA(P_0)?.HFKtXNemLsEbenqpidjWJXHGHqPu(P_1, P_2);
	}

	public void wQItxeeZXyHRKVevThnXNoRyXrDC(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2, int P_3)
	{
		BDFIZuioLTscknOWXNwkqCJsbrFuA(P_0)?.ZSMxKhkKYwNbtrubxodqzfzZNvIC(P_1, P_2, P_3);
	}

	public void NUQxytSvcgJjBnrJrycTweWxblBCA(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2, string P_3)
	{
		int num = ReInput.IsSPFehscBAmxtEADWGWuasjDvqf.GhVjGDQeDQmOWTnROakHcfdeCdDd(P_3);
		if (num >= 0)
		{
			wQItxeeZXyHRKVevThnXNoRyXrDC(P_0, P_1, P_2, num);
		}
	}

	public void IvzIewfdqqZrjOrKxuabVLduarZeA(int P_0, Action<InputActionEventData> P_1, InputActionEventType P_2, int P_3)
	{
		BDFIZuioLTscknOWXNwkqCJsbrFuA(P_0)?.zrbCfNDxCZydSaBcniMDkOCFTrJDA(P_1, P_2, P_3);
	}

	public void BcVKTMXYtkLQwKEsMBdjELbIKjOA(int P_0, Action<InputActionEventData> P_1, InputActionEventType P_2, string P_3)
	{
		int num = ReInput.IsSPFehscBAmxtEADWGWuasjDvqf.GhVjGDQeDQmOWTnROakHcfdeCdDd(P_3);
		if (num >= 0)
		{
			IvzIewfdqqZrjOrKxuabVLduarZeA(P_0, P_1, P_2, num);
		}
	}

	public void MKYMpHdEcJBwjyeCLgpxfJwrkwvcA(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2, InputActionEventType P_3)
	{
		BDFIZuioLTscknOWXNwkqCJsbrFuA(P_0)?.hGxtqJLfVrHaXpSjqltxVMlofUoA(P_1, P_2, P_3);
	}

	public void KdDfQJSOpAGxGiGjxDHRiALsfAPaA(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2, InputActionEventType P_3, int P_4)
	{
		BDFIZuioLTscknOWXNwkqCJsbrFuA(P_0)?.TgcMlamNDgixscUEOOcMGDabRovnB(P_1, P_2, P_3, P_4);
	}

	public void mKahBUNBMZqGcjKBpdvQAgLFdnZp(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2, InputActionEventType P_3, string P_4)
	{
		int num = ReInput.IsSPFehscBAmxtEADWGWuasjDvqf.GhVjGDQeDQmOWTnROakHcfdeCdDd(P_4);
		if (num >= 0)
		{
			KdDfQJSOpAGxGiGjxDHRiALsfAPaA(P_0, P_1, P_2, P_3, num);
		}
	}

	public void utSCGVpMvVvXlFlReVxWoXjJttQk(int P_0)
	{
		BDFIZuioLTscknOWXNwkqCJsbrFuA(P_0)?.caLfklwmPmDEYLrHxotcRQUWWAVv();
	}

	public bool TYfmtoqzwmGLovKrlGfhkLtTcHV(int P_0)
	{
		if (P_0 == 9999999)
		{
			for (int i = 0; i < uXqIzqbxeCcEAqPLTyGCxllYinoB.Length; i++)
			{
				if (uXqIzqbxeCcEAqPLTyGCxllYinoB[i].xKqYQOpLsGFmaoEFKYQRCnKaaWcQ())
				{
					return true;
				}
			}
			return false;
		}
		if (P_0 < 0 || P_0 >= IuRfooLVUFdktOdFMYGlZwQfoAkk)
		{
			return false;
		}
		int num = PeugHLgavxVRyikNdZaUSCVbDplab.OSSfzqtTCBwONcbrXxdGyIDiCXCB();
		for (int j = 0; j < num; j++)
		{
			if (rMlgDkOFFIXQqmNUWVhoaJsGOxZU[P_0, j].xKqYQOpLsGFmaoEFKYQRCnKaaWcQ())
			{
				return true;
			}
		}
		return false;
	}

	public bool JayFxUzYSsNACMPTCIKTtTOLeKoB(int P_0)
	{
		if (P_0 == 9999999)
		{
			for (int i = 0; i < uXqIzqbxeCcEAqPLTyGCxllYinoB.Length; i++)
			{
				if (uXqIzqbxeCcEAqPLTyGCxllYinoB[i].SlBphyvwWgvIxeNaguzhFBDTfHoJ())
				{
					return true;
				}
			}
			return false;
		}
		if (P_0 < 0 || P_0 >= IuRfooLVUFdktOdFMYGlZwQfoAkk)
		{
			return false;
		}
		int num = PeugHLgavxVRyikNdZaUSCVbDplab.OSSfzqtTCBwONcbrXxdGyIDiCXCB();
		for (int j = 0; j < num; j++)
		{
			if (rMlgDkOFFIXQqmNUWVhoaJsGOxZU[P_0, j].SlBphyvwWgvIxeNaguzhFBDTfHoJ())
			{
				return true;
			}
		}
		return false;
	}

	public bool MLIcWmYiqirxnSOsuerLkNIitMoP(int P_0)
	{
		if (P_0 == 9999999)
		{
			for (int i = 0; i < uXqIzqbxeCcEAqPLTyGCxllYinoB.Length; i++)
			{
				if (uXqIzqbxeCcEAqPLTyGCxllYinoB[i].AfBRHgbDIxDSwAMNQBOuTkhxmJQqA())
				{
					return true;
				}
			}
			return false;
		}
		if (P_0 < 0 || P_0 >= IuRfooLVUFdktOdFMYGlZwQfoAkk)
		{
			return false;
		}
		int num = PeugHLgavxVRyikNdZaUSCVbDplab.OSSfzqtTCBwONcbrXxdGyIDiCXCB();
		for (int j = 0; j < num; j++)
		{
			if (rMlgDkOFFIXQqmNUWVhoaJsGOxZU[P_0, j].AfBRHgbDIxDSwAMNQBOuTkhxmJQqA())
			{
				return true;
			}
		}
		return false;
	}

	public bool CyOZxMQAbAJMWqjHtGpNDZCxJPHFA(int P_0)
	{
		if (P_0 == 9999999)
		{
			for (int i = 0; i < uXqIzqbxeCcEAqPLTyGCxllYinoB.Length; i++)
			{
				if (uXqIzqbxeCcEAqPLTyGCxllYinoB[i].EnSiNuXtEgmFXWEsIzPJTGnkSqBU())
				{
					return true;
				}
			}
			return false;
		}
		if (P_0 < 0 || P_0 >= IuRfooLVUFdktOdFMYGlZwQfoAkk)
		{
			return false;
		}
		int num = PeugHLgavxVRyikNdZaUSCVbDplab.OSSfzqtTCBwONcbrXxdGyIDiCXCB();
		for (int j = 0; j < num; j++)
		{
			if (rMlgDkOFFIXQqmNUWVhoaJsGOxZU[P_0, j].EnSiNuXtEgmFXWEsIzPJTGnkSqBU())
			{
				return true;
			}
		}
		return false;
	}

	public bool GwZCsoRjIfCpkvodaDKXjKhRswQF(int P_0)
	{
		if (P_0 == 9999999)
		{
			for (int i = 0; i < uXqIzqbxeCcEAqPLTyGCxllYinoB.Length; i++)
			{
				if (uXqIzqbxeCcEAqPLTyGCxllYinoB[i].xTmTABHXjJsoVMuVRKriyrGRgzRH())
				{
					return true;
				}
			}
			return false;
		}
		if (P_0 < 0 || P_0 >= IuRfooLVUFdktOdFMYGlZwQfoAkk)
		{
			return false;
		}
		int num = PeugHLgavxVRyikNdZaUSCVbDplab.OSSfzqtTCBwONcbrXxdGyIDiCXCB();
		for (int j = 0; j < num; j++)
		{
			if (rMlgDkOFFIXQqmNUWVhoaJsGOxZU[P_0, j].xTmTABHXjJsoVMuVRKriyrGRgzRH())
			{
				return true;
			}
		}
		return false;
	}

	public bool FIabJtePHtDbnIevNTREtFumqHQj(int P_0)
	{
		if (P_0 == 9999999)
		{
			for (int i = 0; i < uXqIzqbxeCcEAqPLTyGCxllYinoB.Length; i++)
			{
				if (uXqIzqbxeCcEAqPLTyGCxllYinoB[i].jkWaFrQGPlyFMdhMpGwpqkrDEFHI())
				{
					return true;
				}
			}
			return false;
		}
		if (P_0 < 0 || P_0 >= IuRfooLVUFdktOdFMYGlZwQfoAkk)
		{
			return false;
		}
		int num = PeugHLgavxVRyikNdZaUSCVbDplab.OSSfzqtTCBwONcbrXxdGyIDiCXCB();
		for (int j = 0; j < num; j++)
		{
			if (rMlgDkOFFIXQqmNUWVhoaJsGOxZU[P_0, j].jkWaFrQGPlyFMdhMpGwpqkrDEFHI())
			{
				return true;
			}
		}
		return false;
	}

	public bool XKEAMnEbDlcunwPOPWwRJLqreMrLA(int P_0)
	{
		if (P_0 == 9999999)
		{
			for (int i = 0; i < uXqIzqbxeCcEAqPLTyGCxllYinoB.Length; i++)
			{
				if (uXqIzqbxeCcEAqPLTyGCxllYinoB[i].sgYTmFGalnrYFfIBPOUYeCxEwbSH())
				{
					return true;
				}
			}
			return false;
		}
		if (P_0 < 0 || P_0 >= IuRfooLVUFdktOdFMYGlZwQfoAkk)
		{
			return false;
		}
		int num = PeugHLgavxVRyikNdZaUSCVbDplab.OSSfzqtTCBwONcbrXxdGyIDiCXCB();
		for (int j = 0; j < num; j++)
		{
			if (rMlgDkOFFIXQqmNUWVhoaJsGOxZU[P_0, j].sgYTmFGalnrYFfIBPOUYeCxEwbSH())
			{
				return true;
			}
		}
		return false;
	}

	public bool ufPOaWZtrRFChoFxIPvhSFfkqXuj(int P_0)
	{
		if (P_0 == 9999999)
		{
			for (int i = 0; i < uXqIzqbxeCcEAqPLTyGCxllYinoB.Length; i++)
			{
				if (uXqIzqbxeCcEAqPLTyGCxllYinoB[i].BiXjczSVhafaeneuyfuougxOQCYu())
				{
					return true;
				}
			}
			return false;
		}
		if (P_0 < 0 || P_0 >= IuRfooLVUFdktOdFMYGlZwQfoAkk)
		{
			return false;
		}
		int num = PeugHLgavxVRyikNdZaUSCVbDplab.OSSfzqtTCBwONcbrXxdGyIDiCXCB();
		for (int j = 0; j < num; j++)
		{
			if (rMlgDkOFFIXQqmNUWVhoaJsGOxZU[P_0, j].BiXjczSVhafaeneuyfuougxOQCYu())
			{
				return true;
			}
		}
		return false;
	}

	public bool nYvJgOkjCCMLqIFxktJXOGmmBYvG()
	{
		if (!WnnINfoDXoDzJCdpxLxydNrjMJuUb(TcXjdodExmGIMmvhgFqpjWPQzPMh) && !gAWscJoozwbhLJFWDICiGBJOBkOAA(oTIRSXwUOjVATBmccAzgFcTLhMNHA) && !WnnINfoDXoDzJCdpxLxydNrjMJuUb(gtwrzRxKKsEjVlkbmBHrjBQtgkhxA))
		{
			return gAWscJoozwbhLJFWDICiGBJOBkOAA(oOJzaJuUNptKoxPEGGGmWLhvxyhV);
		}
		return true;
	}

	public bool GwOKLpnICKITidiDcUOOMDpxXbMmA(ControllerType P_0)
	{
		return P_0 switch
		{
			ControllerType.Joystick => gAWscJoozwbhLJFWDICiGBJOBkOAA(oTIRSXwUOjVATBmccAzgFcTLhMNHA), 
			ControllerType.Keyboard => WnnINfoDXoDzJCdpxLxydNrjMJuUb(gtwrzRxKKsEjVlkbmBHrjBQtgkhxA), 
			ControllerType.Mouse => WnnINfoDXoDzJCdpxLxydNrjMJuUb(TcXjdodExmGIMmvhgFqpjWPQzPMh), 
			ControllerType.Custom => gAWscJoozwbhLJFWDICiGBJOBkOAA(oOJzaJuUNptKoxPEGGGmWLhvxyhV), 
			_ => throw new NotImplementedException(), 
		};
	}

	public bool IUqghlOmQmFTTfrOwKcSbNbDKPYmB()
	{
		if (!IrdiTGMbRxzEdDljzRAzgRqNfbYs(TcXjdodExmGIMmvhgFqpjWPQzPMh) && !YnPmYDTENgUyrIbtPkTsHvvwLhtw(oTIRSXwUOjVATBmccAzgFcTLhMNHA) && !IrdiTGMbRxzEdDljzRAzgRqNfbYs(gtwrzRxKKsEjVlkbmBHrjBQtgkhxA))
		{
			return YnPmYDTENgUyrIbtPkTsHvvwLhtw(oOJzaJuUNptKoxPEGGGmWLhvxyhV);
		}
		return true;
	}

	public bool HvBYIfDOZcrvaBiYactrcffoxInb(ControllerType P_0)
	{
		return P_0 switch
		{
			ControllerType.Joystick => YnPmYDTENgUyrIbtPkTsHvvwLhtw(oTIRSXwUOjVATBmccAzgFcTLhMNHA), 
			ControllerType.Keyboard => IrdiTGMbRxzEdDljzRAzgRqNfbYs(gtwrzRxKKsEjVlkbmBHrjBQtgkhxA), 
			ControllerType.Mouse => IrdiTGMbRxzEdDljzRAzgRqNfbYs(TcXjdodExmGIMmvhgFqpjWPQzPMh), 
			ControllerType.Custom => YnPmYDTENgUyrIbtPkTsHvvwLhtw(oOJzaJuUNptKoxPEGGGmWLhvxyhV), 
			_ => throw new NotImplementedException(), 
		};
	}

	public bool fiMbFYkLxEuvoNCowKkiFBmMRHFDb()
	{
		if (!KWJIdVhcMyeOclQyaIngWLBwbcMi(TcXjdodExmGIMmvhgFqpjWPQzPMh) && !zkLpwzuyrifOCTeCBjQhfDcULczu(oTIRSXwUOjVATBmccAzgFcTLhMNHA) && !KWJIdVhcMyeOclQyaIngWLBwbcMi(gtwrzRxKKsEjVlkbmBHrjBQtgkhxA))
		{
			return zkLpwzuyrifOCTeCBjQhfDcULczu(oOJzaJuUNptKoxPEGGGmWLhvxyhV);
		}
		return true;
	}

	public bool LsnPcfHCSwHBPpAlCfeibMcQRxvPA(ControllerType P_0)
	{
		return P_0 switch
		{
			ControllerType.Joystick => zkLpwzuyrifOCTeCBjQhfDcULczu(oTIRSXwUOjVATBmccAzgFcTLhMNHA), 
			ControllerType.Keyboard => KWJIdVhcMyeOclQyaIngWLBwbcMi(gtwrzRxKKsEjVlkbmBHrjBQtgkhxA), 
			ControllerType.Mouse => KWJIdVhcMyeOclQyaIngWLBwbcMi(TcXjdodExmGIMmvhgFqpjWPQzPMh), 
			ControllerType.Custom => zkLpwzuyrifOCTeCBjQhfDcULczu(oOJzaJuUNptKoxPEGGGmWLhvxyhV), 
			_ => throw new NotImplementedException(), 
		};
	}

	public bool sNeRFNHzldSwOvacSdXSZIgyIenr()
	{
		if (!eXGtrozPTxZQFZJXbukCXebvGVAE(TcXjdodExmGIMmvhgFqpjWPQzPMh) && !KwlsfWiAzJriCEKEcaCgFDjrqTPM(oTIRSXwUOjVATBmccAzgFcTLhMNHA) && !eXGtrozPTxZQFZJXbukCXebvGVAE(gtwrzRxKKsEjVlkbmBHrjBQtgkhxA))
		{
			return KwlsfWiAzJriCEKEcaCgFDjrqTPM(oOJzaJuUNptKoxPEGGGmWLhvxyhV);
		}
		return true;
	}

	public bool xpUWrBEtCkSMDQEvSWBJoTMKwMvT(ControllerType P_0)
	{
		return P_0 switch
		{
			ControllerType.Joystick => KwlsfWiAzJriCEKEcaCgFDjrqTPM(oTIRSXwUOjVATBmccAzgFcTLhMNHA), 
			ControllerType.Keyboard => eXGtrozPTxZQFZJXbukCXebvGVAE(gtwrzRxKKsEjVlkbmBHrjBQtgkhxA), 
			ControllerType.Mouse => eXGtrozPTxZQFZJXbukCXebvGVAE(TcXjdodExmGIMmvhgFqpjWPQzPMh), 
			ControllerType.Custom => KwlsfWiAzJriCEKEcaCgFDjrqTPM(oOJzaJuUNptKoxPEGGGmWLhvxyhV), 
			_ => throw new NotImplementedException(), 
		};
	}

	public bool DrMOrdTzJptTLshRDGKymsEEbyIFA()
	{
		if (!LtDXgbeVGbtcDHOndKBzUIlxKdCJ(TcXjdodExmGIMmvhgFqpjWPQzPMh) && !vOKxeRzJKyylsMIAtiXqHNUtYrji(oTIRSXwUOjVATBmccAzgFcTLhMNHA) && !LtDXgbeVGbtcDHOndKBzUIlxKdCJ(gtwrzRxKKsEjVlkbmBHrjBQtgkhxA))
		{
			return vOKxeRzJKyylsMIAtiXqHNUtYrji(oOJzaJuUNptKoxPEGGGmWLhvxyhV);
		}
		return true;
	}

	public bool QswDmmYOjhFMFQMFMXFcxCwYVrSE(ControllerType P_0)
	{
		return P_0 switch
		{
			ControllerType.Joystick => vOKxeRzJKyylsMIAtiXqHNUtYrji(oTIRSXwUOjVATBmccAzgFcTLhMNHA), 
			ControllerType.Keyboard => LtDXgbeVGbtcDHOndKBzUIlxKdCJ(gtwrzRxKKsEjVlkbmBHrjBQtgkhxA), 
			ControllerType.Mouse => LtDXgbeVGbtcDHOndKBzUIlxKdCJ(TcXjdodExmGIMmvhgFqpjWPQzPMh), 
			ControllerType.Custom => vOKxeRzJKyylsMIAtiXqHNUtYrji(oOJzaJuUNptKoxPEGGGmWLhvxyhV), 
			_ => throw new NotImplementedException(), 
		};
	}

	private bool gAWscJoozwbhLJFWDICiGBJOBkOAA<_0001>(IList<_0001> P_0) where _0001 : Controller
	{
		if (P_0 == null)
		{
			return false;
		}
		int count = P_0.Count;
		for (int i = 0; i < count; i++)
		{
			_0001 val = P_0[i];
			if (val != null && val.GetAnyButton())
			{
				return true;
			}
		}
		return false;
	}

	private bool WnnINfoDXoDzJCdpxLxydNrjMJuUb(Controller P_0)
	{
		return P_0?.GetAnyButton() ?? false;
	}

	private bool YnPmYDTENgUyrIbtPkTsHvvwLhtw<_0001>(IList<_0001> P_0) where _0001 : Controller
	{
		if (P_0 == null)
		{
			return false;
		}
		int count = P_0.Count;
		for (int i = 0; i < count; i++)
		{
			_0001 val = P_0[i];
			if (val != null && val.GetAnyButtonDown())
			{
				return true;
			}
		}
		return false;
	}

	private bool IrdiTGMbRxzEdDljzRAzgRqNfbYs(Controller P_0)
	{
		return P_0?.GetAnyButtonDown() ?? false;
	}

	private bool zkLpwzuyrifOCTeCBjQhfDcULczu<_0001>(IList<_0001> P_0) where _0001 : Controller
	{
		if (P_0 == null)
		{
			return false;
		}
		int count = P_0.Count;
		for (int i = 0; i < count; i++)
		{
			_0001 val = P_0[i];
			if (val != null && val.GetAnyButtonUp())
			{
				return true;
			}
		}
		return false;
	}

	private bool KWJIdVhcMyeOclQyaIngWLBwbcMi(Controller P_0)
	{
		return P_0?.GetAnyButtonUp() ?? false;
	}

	private bool KwlsfWiAzJriCEKEcaCgFDjrqTPM<_0001>(IList<_0001> P_0) where _0001 : Controller
	{
		if (P_0 == null)
		{
			return false;
		}
		int count = P_0.Count;
		for (int i = 0; i < count; i++)
		{
			_0001 val = P_0[i];
			if (val != null && val.GetAnyButtonChanged())
			{
				return true;
			}
		}
		return false;
	}

	private bool eXGtrozPTxZQFZJXbukCXebvGVAE(Controller P_0)
	{
		return P_0?.GetAnyButtonChanged() ?? false;
	}

	private bool vOKxeRzJKyylsMIAtiXqHNUtYrji<_0001>(IList<_0001> P_0) where _0001 : Controller
	{
		if (P_0 == null)
		{
			return false;
		}
		int count = P_0.Count;
		for (int i = 0; i < count; i++)
		{
			_0001 val = P_0[i];
			if (val != null && val.GetAnyButtonPrev())
			{
				return true;
			}
		}
		return false;
	}

	private bool LtDXgbeVGbtcDHOndKBzUIlxKdCJ(Controller P_0)
	{
		return P_0?.GetAnyButtonPrev() ?? false;
	}

	public Controller ueaTKiPRuPiTOchGFBOpIIIInKSYA()
	{
		Controller lastController = null;
		double lastTime = 0.0;
		InputTools.CompareLastActiveController(TcXjdodExmGIMmvhgFqpjWPQzPMh, ref lastController, ref lastTime);
		InputTools.CompareLastActiveController(gtwrzRxKKsEjVlkbmBHrjBQtgkhxA, ref lastController, ref lastTime);
		IList<Joystick> list = oTIRSXwUOjVATBmccAzgFcTLhMNHA;
		for (int i = 0; i < DgWkEwMpXTtCniXaqphVZqoNpNah(); i++)
		{
			InputTools.CompareLastActiveController(list[i], ref lastController, ref lastTime);
		}
		IList<CustomController> list2 = oOJzaJuUNptKoxPEGGGmWLhvxyhV;
		for (int j = 0; j < iRWLoJbnOgesrOMvmrqqhNPmZYLV(); j++)
		{
			InputTools.CompareLastActiveController(list2[j], ref lastController, ref lastTime);
		}
		if (lastController == null)
		{
			lastController = gtwrzRxKKsEjVlkbmBHrjBQtgkhxA;
		}
		return lastController;
	}

	public Controller UWMvVlrEwXOGXYrVvAnQboMCavFX(ControllerType P_0)
	{
		Controller lastController = null;
		double lastTime = 0.0;
		switch (P_0)
		{
		case ControllerType.Joystick:
		{
			int count = oTIRSXwUOjVATBmccAzgFcTLhMNHA.Count;
			for (int j = 0; j < count; j++)
			{
				InputTools.CompareLastActiveController(oTIRSXwUOjVATBmccAzgFcTLhMNHA[j], ref lastController, ref lastTime);
			}
			break;
		}
		case ControllerType.Keyboard:
			return CJDSMKuYTmJFQKoQSdBfaFNyeDGkA();
		case ControllerType.Mouse:
			return QEiqHFnLLZJSkuwNvWvNEjeQXMlT();
		case ControllerType.Custom:
		{
			int count = oOJzaJuUNptKoxPEGGGmWLhvxyhV.Count;
			for (int i = 0; i < count; i++)
			{
				InputTools.CompareLastActiveController(oOJzaJuUNptKoxPEGGGmWLhvxyhV[i], ref lastController, ref lastTime);
			}
			break;
		}
		default:
			throw new NotImplementedException();
		}
		return lastController;
	}

	public _0001 ueaTKiPRuPiTOchGFBOpIIIInKSYA<_0001>() where _0001 : Controller
	{
		Type typeFromHandle = typeof(_0001);
		if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Joystick)))
		{
			return UWMvVlrEwXOGXYrVvAnQboMCavFX(ControllerType.Joystick) as _0001;
		}
		if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Keyboard)))
		{
			return UWMvVlrEwXOGXYrVvAnQboMCavFX(ControllerType.Keyboard) as _0001;
		}
		if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(CustomController)))
		{
			return UWMvVlrEwXOGXYrVvAnQboMCavFX(ControllerType.Custom) as _0001;
		}
		if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Mouse)))
		{
			return UWMvVlrEwXOGXYrVvAnQboMCavFX(ControllerType.Mouse) as _0001;
		}
		throw new NotImplementedException();
	}

	public ControllerType QYuDVUqDNXMdWyVBlAqOaraomLJw()
	{
		return ueaTKiPRuPiTOchGFBOpIIIInKSYA()?.type ?? ControllerType.Keyboard;
	}

	public void IYykcTAARAgvwBfmoPUHirUsKBwEA(ActiveControllerChangedDelegate P_0)
	{
		if (P_0 != null)
		{
			feAiUkdOABwprDKlbTDHQZJxJSLl = true;
			lPVUxHOiFiBThYCxQhMKDGieEGqAA.bJUzLdpnawlEGEouVlKDxFhsJZnU(P_0);
		}
	}

	public void itPCDGQNCMUpxUNFoYTUQtGpvKgC(ActiveControllerChangedDelegate P_0, ControllerType P_1)
	{
		if (P_0 != null)
		{
			feAiUkdOABwprDKlbTDHQZJxJSLl = true;
			lPVUxHOiFiBThYCxQhMKDGieEGqAA.guRSJmBGHqBxrnvcuuziKWfkKFye(P_0, P_1);
		}
	}

	public void dKTNOqWFTGeLEmKboHtmHsgyIurAA(ActiveControllerChangedDelegate P_0)
	{
		if (P_0 != null)
		{
			lPVUxHOiFiBThYCxQhMKDGieEGqAA.MYMtISVEswcQZhPaSPBLsJIbwfGk(P_0);
		}
	}

	public void sstcjkQjOrWpFkatZvVWsvttrnZQ(ActiveControllerChangedDelegate P_0, ControllerType P_1)
	{
		if (P_0 != null)
		{
			lPVUxHOiFiBThYCxQhMKDGieEGqAA.HYDjEWaneeHPuGkUQuwastdunOABb(P_0, P_1);
		}
	}

	public void KHuHXIoZMmfDeGmjaoGhoBdZagpy()
	{
		lPVUxHOiFiBThYCxQhMKDGieEGqAA.IrsFPbuINNMpbMeqtfgmtkFmnKRk();
	}

	public void sRfXCxFticxHgQpQVOGMWxlPoVPH(int P_0, PlayerActiveControllerChangedDelegate P_1)
	{
		if (P_1 == null)
		{
			return;
		}
		if (P_0 == 9999999)
		{
			URBRHYjQQUjTpYqvFydrGvDqtLDp.bJUzLdpnawlEGEouVlKDxFhsJZnU(P_1);
		}
		else
		{
			if ((uint)P_0 >= (uint)IuRfooLVUFdktOdFMYGlZwQfoAkk)
			{
				return;
			}
			WHXUgVDJwQUJvCNRrXBoKuOaaZxD[P_0].bJUzLdpnawlEGEouVlKDxFhsJZnU(P_1);
		}
		feAiUkdOABwprDKlbTDHQZJxJSLl = true;
	}

	public void ZzECphoYogepvFqidROMecRyXEHV(int P_0, PlayerActiveControllerChangedDelegate P_1, ControllerType P_2)
	{
		if (P_1 == null)
		{
			return;
		}
		if (P_0 == 9999999)
		{
			URBRHYjQQUjTpYqvFydrGvDqtLDp.guRSJmBGHqBxrnvcuuziKWfkKFye(P_1, P_2);
		}
		else
		{
			if ((uint)P_0 >= (uint)IuRfooLVUFdktOdFMYGlZwQfoAkk)
			{
				return;
			}
			WHXUgVDJwQUJvCNRrXBoKuOaaZxD[P_0].guRSJmBGHqBxrnvcuuziKWfkKFye(P_1, P_2);
		}
		feAiUkdOABwprDKlbTDHQZJxJSLl = true;
	}

	public void jJewTxfgtYtmlILFFixjDAVfNquOA(int P_0, PlayerActiveControllerChangedDelegate P_1)
	{
		if (P_1 != null)
		{
			if (P_0 == 9999999)
			{
				URBRHYjQQUjTpYqvFydrGvDqtLDp.MYMtISVEswcQZhPaSPBLsJIbwfGk(P_1);
			}
			else if ((uint)P_0 < (uint)IuRfooLVUFdktOdFMYGlZwQfoAkk)
			{
				WHXUgVDJwQUJvCNRrXBoKuOaaZxD[P_0].MYMtISVEswcQZhPaSPBLsJIbwfGk(P_1);
			}
		}
	}

	public void hAnYRKUUclFijTHSaRqqoLqYlINc(int P_0, PlayerActiveControllerChangedDelegate P_1, ControllerType P_2)
	{
		if (P_1 != null)
		{
			if (P_0 == 9999999)
			{
				URBRHYjQQUjTpYqvFydrGvDqtLDp.HYDjEWaneeHPuGkUQuwastdunOABb(P_1, P_2);
			}
			else if ((uint)P_0 < (uint)IuRfooLVUFdktOdFMYGlZwQfoAkk)
			{
				WHXUgVDJwQUJvCNRrXBoKuOaaZxD[P_0].HYDjEWaneeHPuGkUQuwastdunOABb(P_1, P_2);
			}
		}
	}

	public void aqcrjUaSwwpOpeYKtlcZbjyGUiRe(int P_0)
	{
		if (P_0 == 9999999)
		{
			URBRHYjQQUjTpYqvFydrGvDqtLDp.IrsFPbuINNMpbMeqtfgmtkFmnKRk();
		}
		else if ((uint)P_0 < (uint)IuRfooLVUFdktOdFMYGlZwQfoAkk)
		{
			WHXUgVDJwQUJvCNRrXBoKuOaaZxD[P_0].IrsFPbuINNMpbMeqtfgmtkFmnKRk();
		}
	}

	private void bZhtiAqMSYVQzLyNUPbiEvwXzwCL()
	{
		if (lPVUxHOiFiBThYCxQhMKDGieEGqAA.hWWJuvVnzOGfXYPabgrDnzbLgRgP > 0)
		{
			lPVUxHOiFiBThYCxQhMKDGieEGqAA.bFaZfPGnHRwheHbYOQzCfoMrwzeB(-1, ueaTKiPRuPiTOchGFBOpIIIInKSYA(), UWMvVlrEwXOGXYrVvAnQboMCavFX(ControllerType.Joystick), UWMvVlrEwXOGXYrVvAnQboMCavFX(ControllerType.Custom));
		}
		if (URBRHYjQQUjTpYqvFydrGvDqtLDp.hWWJuvVnzOGfXYPabgrDnzbLgRgP > 0)
		{
			Player.ControllerHelper controllers = InQdDIoPiLCppctRCEVYaZXCnFOAA.aIWEWBhJOdPKbObSWugNVHKhlmbjA().controllers;
			URBRHYjQQUjTpYqvFydrGvDqtLDp.bFaZfPGnHRwheHbYOQzCfoMrwzeB(9999999, controllers.GetLastActiveController(), controllers.GetLastActiveController(ControllerType.Joystick), controllers.GetLastActiveController(ControllerType.Custom));
		}
		for (int i = 0; i < IuRfooLVUFdktOdFMYGlZwQfoAkk; i++)
		{
			if (WHXUgVDJwQUJvCNRrXBoKuOaaZxD[i].hWWJuvVnzOGfXYPabgrDnzbLgRgP != 0)
			{
				Player.ControllerHelper controllers2 = InQdDIoPiLCppctRCEVYaZXCnFOAA.hbLpqlVcmtGUecdXnmNXWJxICZtSA()[i].controllers;
				WHXUgVDJwQUJvCNRrXBoKuOaaZxD[i].bFaZfPGnHRwheHbYOQzCfoMrwzeB(i, controllers2.GetLastActiveController(), controllers2.GetLastActiveController(ControllerType.Joystick), controllers2.GetLastActiveController(ControllerType.Custom));
			}
		}
	}

	public void FeAoZeUixIJBomShUTykHxGLLRYy(ThrottleCalibrationMode P_0)
	{
		for (int i = 0; i < oTIRSXwUOjVATBmccAzgFcTLhMNHA.Count; i++)
		{
			if (oTIRSXwUOjVATBmccAzgFcTLhMNHA[i] != null)
			{
				sROkLLIetidJzreoFyYkhhyjQbYA(oTIRSXwUOjVATBmccAzgFcTLhMNHA[i], P_0);
			}
		}
		for (int j = 0; j < ZaMUkTRBLXjTIUyOIrKXnzfNCuCo.Count; j++)
		{
			if (ZaMUkTRBLXjTIUyOIrKXnzfNCuCo[j] != null)
			{
				sROkLLIetidJzreoFyYkhhyjQbYA(ZaMUkTRBLXjTIUyOIrKXnzfNCuCo[j], P_0);
			}
		}
		for (int k = 0; k < iRWLoJbnOgesrOMvmrqqhNPmZYLV(); k++)
		{
			if (oOJzaJuUNptKoxPEGGGmWLhvxyhV[k] != null)
			{
				sROkLLIetidJzreoFyYkhhyjQbYA(oOJzaJuUNptKoxPEGGGmWLhvxyhV[k], P_0);
			}
		}
		sROkLLIetidJzreoFyYkhhyjQbYA(TcXjdodExmGIMmvhgFqpjWPQzPMh, P_0);
	}

	private void sROkLLIetidJzreoFyYkhhyjQbYA(ControllerWithAxes P_0, ThrottleCalibrationMode P_1)
	{
		IList<Controller.Axis> axes = P_0.Axes;
		for (int i = 0; i < P_0.axisCount; i++)
		{
			if (axes[i].XPJMXvcDLsDoYlwHEhEAofLIBGih._specialAxisType == SpecialAxisType.Throttle)
			{
				P_0.calibrationMap.Axes[i].calibrationMode = EnumConverter.ToAlternateAxisCalibrationType(P_1);
			}
		}
	}

	public IList<_0001> yXYcmRWjoOVbDBydITFCFBQJYLPL<_0001>() where _0001 : IControllerTemplate
	{
		return YuhSkoozRptQpIaqbACpDbzqnbGfb.bpzHUQyiYjpOkNEdpYqviVucnLDW<_0001>();
	}

	private int YYXeiOgVFvAcwgWSngmPHTBMYgEfA()
	{
		int result = lNIqyQiRHBZwAHeugkjRHrmBeVLD;
		lNIqyQiRHBZwAHeugkjRHrmBeVLD++;
		if (lNIqyQiRHBZwAHeugkjRHrmBeVLD >= int.MaxValue)
		{
			lNIqyQiRHBZwAHeugkjRHrmBeVLD = 0;
		}
		return result;
	}

	private void ytcgKyhhjrujQnbacaxXdaFqZELeA(List<InputBehavior> P_0)
	{
		PeugHLgavxVRyikNdZaUSCVbDplab = ReInput.IsSPFehscBAmxtEADWGWuasjDvqf;
		InQdDIoPiLCppctRCEVYaZXCnFOAA = ReInput.iJRGiWfOZRwVGgOxWlHrWBzdJmvdA;
		oTIRSXwUOjVATBmccAzgFcTLhMNHA = new List<Joystick>();
		ZaMUkTRBLXjTIUyOIrKXnzfNCuCo = new List<Joystick>();
		oOJzaJuUNptKoxPEGGGmWLhvxyhV = new List<CustomController>();
		vWWtcElEsXEtcJGPQydRMxGrXRbO = PeugHLgavxVRyikNdZaUSCVbDplab.OSSfzqtTCBwONcbrXxdGyIDiCXCB();
		IuRfooLVUFdktOdFMYGlZwQfoAkk = InQdDIoPiLCppctRCEVYaZXCnFOAA.hUvGgieeUHPERTuNwsrVwxUSzbGsA();
		zyYXGfDmfueAspJyRIHspSKxCOod = bWxLGQtoDACrAhqJJMLujCXTTL;
		lNIqyQiRHBZwAHeugkjRHrmBeVLD = 0;
		bCXbwMDntUHypdRbcOpadcdHJPPl = new ADictionary<int, rHuEjstEJqkQNHFJVauuaBRzTxpkA>();
		bCXbwMDntUHypdRbcOpadcdHJPPl.Add(ReInput.players.GetSystemPlayer().id, new rHuEjstEJqkQNHFJVauuaBRzTxpkA(P_0));
		IList<Player> players = ReInput.players.Players;
		for (int i = 0; i < players.Count; i++)
		{
			bCXbwMDntUHypdRbcOpadcdHJPPl.Add(players[i].id, new rHuEjstEJqkQNHFJVauuaBRzTxpkA(P_0));
		}
		JAIDkmBmnMkfYXxJEJjYJKjoXiiQA = new ReadOnlyCollection<Joystick>(oTIRSXwUOjVATBmccAzgFcTLhMNHA);
		RBcAsxfAVFFWYeEJBxoUduhawCuOc = new ReadOnlyCollection<CustomController>(oOJzaJuUNptKoxPEGGGmWLhvxyhV);
		QZWOxJToNpPZTYJKdjKDNrZDcbAQ.sEBuTHTwCFqyHbcqDXJRqYLplKf(tenMcSdqgzcnnjnEuNcnUTMiTgtKA);
		HRpKxCgSCbzEccxrgCFMHMQFkGjC = new QZWOxJToNpPZTYJKdjKDNrZDcbAQ[(IuRfooLVUFdktOdFMYGlZwQfoAkk + 1) * vWWtcElEsXEtcJGPQydRMxGrXRbO];
		int num = 0;
		uXqIzqbxeCcEAqPLTyGCxllYinoB = new QZWOxJToNpPZTYJKdjKDNrZDcbAQ[vWWtcElEsXEtcJGPQydRMxGrXRbO];
		for (int j = 0; j < vWWtcElEsXEtcJGPQydRMxGrXRbO; j++)
		{
			InputAction inputAction = PeugHLgavxVRyikNdZaUSCVbDplab.TyzxFiDXrmXQDwSlqYMfUEgoAVaQ(j);
			InputBehavior inputBehavior = bCXbwMDntUHypdRbcOpadcdHJPPl.get_Item(9999999).YFuxoysITtForgfxlHNdnLwuMcWz(inputAction.behaviorId);
			QZWOxJToNpPZTYJKdjKDNrZDcbAQ qZWOxJToNpPZTYJKdjKDNrZDcbAQ = new QZWOxJToNpPZTYJKdjKDNrZDcbAQ(9999999, inputAction, inputBehavior, tenMcSdqgzcnnjnEuNcnUTMiTgtKA);
			uXqIzqbxeCcEAqPLTyGCxllYinoB[j] = qZWOxJToNpPZTYJKdjKDNrZDcbAQ;
			HRpKxCgSCbzEccxrgCFMHMQFkGjC[num] = qZWOxJToNpPZTYJKdjKDNrZDcbAQ;
			num++;
		}
		rMlgDkOFFIXQqmNUWVhoaJsGOxZU = new QZWOxJToNpPZTYJKdjKDNrZDcbAQ[IuRfooLVUFdktOdFMYGlZwQfoAkk, vWWtcElEsXEtcJGPQydRMxGrXRbO];
		for (int k = 0; k < IuRfooLVUFdktOdFMYGlZwQfoAkk; k++)
		{
			for (int l = 0; l < vWWtcElEsXEtcJGPQydRMxGrXRbO; l++)
			{
				InputAction inputAction2 = PeugHLgavxVRyikNdZaUSCVbDplab.TyzxFiDXrmXQDwSlqYMfUEgoAVaQ(l);
				InputBehavior inputBehavior2 = bCXbwMDntUHypdRbcOpadcdHJPPl.get_Item(players[k].id).YFuxoysITtForgfxlHNdnLwuMcWz(inputAction2.behaviorId);
				QZWOxJToNpPZTYJKdjKDNrZDcbAQ qZWOxJToNpPZTYJKdjKDNrZDcbAQ2 = new QZWOxJToNpPZTYJKdjKDNrZDcbAQ(k, inputAction2, inputBehavior2, tenMcSdqgzcnnjnEuNcnUTMiTgtKA);
				rMlgDkOFFIXQqmNUWVhoaJsGOxZU[k, l] = qZWOxJToNpPZTYJKdjKDNrZDcbAQ2;
				HRpKxCgSCbzEccxrgCFMHMQFkGjC[num] = qZWOxJToNpPZTYJKdjKDNrZDcbAQ2;
				num++;
			}
		}
		IList<Player_Editor> list = ReInput.UserData.XSrhHLLZWmMFQNHbTwQlcvQyDugK();
		if (list == null)
		{
			throw new ArgumentNullException("Players cannot be null!");
		}
		for (int m = 0; m < list.Count; m++)
		{
			List<Player_Editor.CreateControllerInfo> startingCustomControllers = list[m].startingCustomControllers;
			if (startingCustomControllers == null)
			{
				continue;
			}
			for (int n = 0; n < startingCustomControllers.Count; n++)
			{
				CustomController customController = oaWEUwQBJYSYwzCbnvEfgAPDfPNDA(startingCustomControllers[n].sourceId);
				if (customController != null)
				{
					customController.tag = startingCustomControllers[n].tag;
					int num2 = ((m == 0) ? 9999999 : (m - 1));
					InQdDIoPiLCppctRCEVYaZXCnFOAA.fucJiwJzRsWBBQakvQMUMarJaFob(num2)?.controllers.MXQGAlxTWPRnRxzEisMghMTBgLmp(customController, false);
				}
			}
		}
		IgmotzKhDDNEBmgJmeqdSIfbQBtF = new eOMcJCIodUuhCXeTEELrjrrqoFOTA();
		QUYGGhIgnnnZUxhMFlIWfwiArqDjb = new eOMcJCIodUuhCXeTEELrjrrqoFOTA[IuRfooLVUFdktOdFMYGlZwQfoAkk];
		for (int num3 = 0; num3 < IuRfooLVUFdktOdFMYGlZwQfoAkk; num3++)
		{
			QUYGGhIgnnnZUxhMFlIWfwiArqDjb[num3] = new eOMcJCIodUuhCXeTEELrjrrqoFOTA();
		}
		lPVUxHOiFiBThYCxQhMKDGieEGqAA = new global::GBxMQBzhoNzsKdLTURAnaIYqVJBS<ActiveControllerChangedDelegate>();
		URBRHYjQQUjTpYqvFydrGvDqtLDp = new global::GBxMQBzhoNzsKdLTURAnaIYqVJBS<PlayerActiveControllerChangedDelegate>();
		WHXUgVDJwQUJvCNRrXBoKuOaaZxD = new global::GBxMQBzhoNzsKdLTURAnaIYqVJBS<PlayerActiveControllerChangedDelegate>[InQdDIoPiLCppctRCEVYaZXCnFOAA.hUvGgieeUHPERTuNwsrVwxUSzbGsA()];
		ArrayTools.Populate(WHXUgVDJwQUJvCNRrXBoKuOaaZxD);
	}

	private void GIvgoZEFPabbzFzhgzwnNxXpCkjub(UpdateLoopType P_0)
	{
		int count = oTIRSXwUOjVATBmccAzgFcTLhMNHA.Count;
		for (int i = 0; i < count; i++)
		{
			Joystick joystick = oTIRSXwUOjVATBmccAzgFcTLhMNHA[i];
			if (joystick.enabled)
			{
				WBHdBDkdWaXIAafJqgRfjFzUzABl(joystick.tkMDUYSxBMjfChsmavQDxxhWgYlRA(), joystick.KRqNAliDQUoGilZWSpebheoTCzwBA);
				joystick.zGxdVtiyTLpxaqKGIAgsfZozxwRZA(P_0);
			}
		}
		if (gtwrzRxKKsEjVlkbmBHrjBQtgkhxA.enabled)
		{
			gtwrzRxKKsEjVlkbmBHrjBQtgkhxA.zGxdVtiyTLpxaqKGIAgsfZozxwRZA(P_0);
		}
		else if (gKYejNFAmMjckjBhffaBtowqsZsv)
		{
			gtwrzRxKKsEjVlkbmBHrjBQtgkhxA.whmbFkkYvbhlMqPYTZWvHwGLHVwy(P_0);
		}
		if (TcXjdodExmGIMmvhgFqpjWPQzPMh.enabled)
		{
			TcXjdodExmGIMmvhgFqpjWPQzPMh.zGxdVtiyTLpxaqKGIAgsfZozxwRZA(P_0);
		}
		int count2 = oOJzaJuUNptKoxPEGGGmWLhvxyhV.Count;
		for (int j = 0; j < count2; j++)
		{
			CustomController customController = oOJzaJuUNptKoxPEGGGmWLhvxyhV[j];
			if (customController.enabled)
			{
				customController.QnkFqudZkXFAhfbdybPovyleWgCGA();
				customController.zGxdVtiyTLpxaqKGIAgsfZozxwRZA(P_0);
			}
		}
	}

	private void yqqPKpYmVpquOcdeRIGvaGIGJxKEb(UpdateLoopType P_0)
	{
		QZWOxJToNpPZTYJKdjKDNrZDcbAQ.OWuLIYTRJkowfkrsCyjbwHwSSjqA(P_0);
		Player[] array = InQdDIoPiLCppctRCEVYaZXCnFOAA.qamCCihAizQaxMAZMYFcKDIMVPfwA();
		int num = array.Length;
		bool enabled = gtwrzRxKKsEjVlkbmBHrjBQtgkhxA.enabled;
		if (enabled)
		{
			for (int i = 0; i < num; i++)
			{
				IList<KeyboardMap> maps = array[i].controllers.maps.GetMaps<KeyboardMap>(0);
				int count = maps.Count;
				for (int j = 0; j < count; j++)
				{
					if (maps[j].enabled)
					{
						tqFIKahxXBNpyqlEjLNobyZXOuiG.nZyKNLkbSwNzlXuUHhsnCsqCNhoS(maps[j]);
					}
				}
			}
		}
		bool enabled2 = TcXjdodExmGIMmvhgFqpjWPQzPMh.enabled;
		for (int k = 0; k < num; k++)
		{
			Player.ControllerHelper controllers = array[k].controllers;
			controllers.TCIyxsRUzhjACqutHFgzfbhjHzPA(zyYXGfDmfueAspJyRIHspSKxCOod);
			if (enabled || gKYejNFAmMjckjBhffaBtowqsZsv)
			{
				controllers.mnweXxcHtmDtTINFeirDUFpdvuEmA(gtwrzRxKKsEjVlkbmBHrjBQtgkhxA, tqFIKahxXBNpyqlEjLNobyZXOuiG, zyYXGfDmfueAspJyRIHspSKxCOod);
			}
			if (enabled2)
			{
				controllers.qccwBfIvrVoMwBEKbBZkFVUWlBFB(TcXjdodExmGIMmvhgFqpjWPQzPMh, zyYXGfDmfueAspJyRIHspSKxCOod);
			}
			controllers.itsVoRinRQZGDWyRbddweJGTPvPU(zyYXGfDmfueAspJyRIHspSKxCOod);
		}
		for (int l = 0; l < HRpKxCgSCbzEccxrgCFMHMQFkGjC.Length; l++)
		{
			if (HRpKxCgSCbzEccxrgCFMHMQFkGjC[l].seWeYJIhYIvxqRNbNCdGhcZZwbTU != QZWOxJToNpPZTYJKdjKDNrZDcbAQ.rFZTetZeRBFlVjmtbZFKkrxlLEuN.Disabled)
			{
				HRpKxCgSCbzEccxrgCFMHMQFkGjC[l].kwSfuDvwomhsouUGbUAcXsplFLDC();
			}
		}
		QZWOxJToNpPZTYJKdjKDNrZDcbAQ.AGWLOePsRWbCVFwjpgmPzJPqFLOI();
		if (!zinTNGHABDEdNGzbPDMOUnlnWrOf)
		{
			return;
		}
		if (IgmotzKhDDNEBmgJmeqdSIfbQBtF.LaBtRfyqYivCLXprgIvCggAAYmuV > 0)
		{
			for (int m = 0; m < vWWtcElEsXEtcJGPQydRMxGrXRbO; m++)
			{
				QZWOxJToNpPZTYJKdjKDNrZDcbAQ qZWOxJToNpPZTYJKdjKDNrZDcbAQ = uXqIzqbxeCcEAqPLTyGCxllYinoB[m];
				if (qZWOxJToNpPZTYJKdjKDNrZDcbAQ.seWeYJIhYIvxqRNbNCdGhcZZwbTU != QZWOxJToNpPZTYJKdjKDNrZDcbAQ.rFZTetZeRBFlVjmtbZFKkrxlLEuN.Disabled)
				{
					IgmotzKhDDNEBmgJmeqdSIfbQBtF.YRHUaYIrhHjowZlNbRJsaHJEDUvGA(qZWOxJToNpPZTYJKdjKDNrZDcbAQ, P_0);
				}
			}
		}
		for (int n = 0; n < IuRfooLVUFdktOdFMYGlZwQfoAkk; n++)
		{
			eOMcJCIodUuhCXeTEELrjrrqoFOTA eOMcJCIodUuhCXeTEELrjrrqoFOTA2 = QUYGGhIgnnnZUxhMFlIWfwiArqDjb[n];
			if (eOMcJCIodUuhCXeTEELrjrrqoFOTA2.LaBtRfyqYivCLXprgIvCggAAYmuV == 0)
			{
				continue;
			}
			for (int num2 = 0; num2 < vWWtcElEsXEtcJGPQydRMxGrXRbO; num2++)
			{
				QZWOxJToNpPZTYJKdjKDNrZDcbAQ qZWOxJToNpPZTYJKdjKDNrZDcbAQ2 = rMlgDkOFFIXQqmNUWVhoaJsGOxZU[n, num2];
				if (qZWOxJToNpPZTYJKdjKDNrZDcbAQ2.seWeYJIhYIvxqRNbNCdGhcZZwbTU != QZWOxJToNpPZTYJKdjKDNrZDcbAQ.rFZTetZeRBFlVjmtbZFKkrxlLEuN.Disabled)
				{
					eOMcJCIodUuhCXeTEELrjrrqoFOTA2.YRHUaYIrhHjowZlNbRJsaHJEDUvGA(qZWOxJToNpPZTYJKdjKDNrZDcbAQ2, P_0);
				}
			}
		}
	}

	private void bWxLGQtoDACrAhqJJMLujCXTTL(bool P_0, int P_1, int P_2)
	{
		int num = PeugHLgavxVRyikNdZaUSCVbDplab.ePMNZIYbjJltQRETydtleyDTFxII(P_2);
		if (num >= 0)
		{
			if (P_1 == 9999999)
			{
				uXqIzqbxeCcEAqPLTyGCxllYinoB[num].LMCXkVnVUVCgdejxvpRFLVWWXPOL(P_0);
			}
			else
			{
				rMlgDkOFFIXQqmNUWVhoaJsGOxZU[P_1, num].LMCXkVnVUVCgdejxvpRFLVWWXPOL(P_0);
			}
		}
	}

	private void FstiZLOkEtgKdwOvIkveNSJyICrl(BridgedController P_0)
	{
		int num = dNmavkfMEsDwETVXZEzxvnXdWvVoA(P_0.sourceJoystick.rewiredId, arueCAfDhShXXupeWRlAfckKNHxqB.Connected);
		if (num >= 0)
		{
			Logger.LogError("Controller was already in connected list!");
			return;
		}
		num = dNmavkfMEsDwETVXZEzxvnXdWvVoA(P_0.sourceJoystick.rewiredId, arueCAfDhShXXupeWRlAfckKNHxqB.Disconnected);
		Joystick joystick;
		if (num >= 0)
		{
			joystick = ZaMUkTRBLXjTIUyOIrKXnzfNCuCo[num];
			ZaMUkTRBLXjTIUyOIrKXnzfNCuCo.RemoveAt(num);
			joystick.nqNMzVmolTElXvFKtbhndBoUXqYw(P_0);
			joystick.fiaCZhvqrdhxedobUMbCPqHaoqSAA(true);
		}
		else
		{
			joystick = new Joystick(P_0);
		}
		oTIRSXwUOjVATBmccAzgFcTLhMNHA.Add(joystick);
		ObZPdSqKwwFwuAIVGCSnIxqnTNaB.Add(joystick);
		oTIRSXwUOjVATBmccAzgFcTLhMNHA.Sort(Joystick.EnnYlDQzdjWlCbYxmGgHVeCFesJfA);
		YuhSkoozRptQpIaqbACpDbzqnbGfb.NwCwRIqaKzXsvjtkBWSnlYNaVrQU(joystick);
	}

	private void CHBThrgmQqHDmLGNzWjSTJJBcgQJ(int P_0)
	{
		if (P_0 < 0)
		{
			throw new ArgumentOutOfRangeException();
		}
		if (P_0 >= oTIRSXwUOjVATBmccAzgFcTLhMNHA.Count)
		{
			Logger.LogError("Device was not in connected list! Cannot remove!");
			return;
		}
		Joystick joystick = oTIRSXwUOjVATBmccAzgFcTLhMNHA[P_0];
		joystick.fiaCZhvqrdhxedobUMbCPqHaoqSAA(false);
		if (FzYTwXRdbcZjYErpvwwlmUFobKmH != null)
		{
			FzYTwXRdbcZjYErpvwwlmUFobKmH(new ControllerStatusChangedEventArgs(joystick.name, joystick.id, joystick.type));
		}
		if (zlSbRgBGndjVBXGjQjitgElRhXEBA != null)
		{
			zlSbRgBGndjVBXGjQjitgElRhXEBA(joystick.type, joystick.id);
		}
		oTIRSXwUOjVATBmccAzgFcTLhMNHA.RemoveAt(P_0);
		ZaMUkTRBLXjTIUyOIrKXnzfNCuCo.Add(joystick);
		ObZPdSqKwwFwuAIVGCSnIxqnTNaB.Remove(joystick);
		YuhSkoozRptQpIaqbACpDbzqnbGfb.wUdFOsjHwFtryZkSuYDfCgLNwGrj(joystick);
		joystick.PodVUGvDnUHydzVhCxMAInDDVsXW();
	}

	private void DLhEBhygQMJFbPxljIYTtadWHukq()
	{
		for (int num = oTIRSXwUOjVATBmccAzgFcTLhMNHA.Count - 1; num >= 0; num--)
		{
			CHBThrgmQqHDmLGNzWjSTJJBcgQJ(num);
		}
	}

	private bool yliapdHomTdeInAYAWPJlSqwpTLl(CustomController P_0)
	{
		if (P_0 == null)
		{
			return false;
		}
		for (int i = 0; i < oOJzaJuUNptKoxPEGGGmWLhvxyhV.Count; i++)
		{
			if (oOJzaJuUNptKoxPEGGGmWLhvxyhV[i] == P_0)
			{
				return true;
			}
		}
		oOJzaJuUNptKoxPEGGGmWLhvxyhV.Add(P_0);
		ObZPdSqKwwFwuAIVGCSnIxqnTNaB.Add(P_0);
		YuhSkoozRptQpIaqbACpDbzqnbGfb.NwCwRIqaKzXsvjtkBWSnlYNaVrQU(P_0);
		return true;
	}

	private bool slAKJRZqmuWgxXVCWAfvybXVRuvn(CustomController P_0)
	{
		if (P_0 == null)
		{
			return false;
		}
		YuhSkoozRptQpIaqbACpDbzqnbGfb.wUdFOsjHwFtryZkSuYDfCgLNwGrj(P_0);
		ObZPdSqKwwFwuAIVGCSnIxqnTNaB.Remove(P_0);
		return oOJzaJuUNptKoxPEGGGmWLhvxyhV.Remove(P_0);
	}

	private eOMcJCIodUuhCXeTEELrjrrqoFOTA BDFIZuioLTscknOWXNwkqCJsbrFuA(int P_0)
	{
		if (P_0 == 9999999)
		{
			return IgmotzKhDDNEBmgJmeqdSIfbQBtF;
		}
		if (P_0 < 0 || P_0 >= ReInput.iJRGiWfOZRwVGgOxWlHrWBzdJmvdA.hUvGgieeUHPERTuNwsrVwxUSzbGsA())
		{
			return null;
		}
		return QUYGGhIgnnnZUxhMFlIWfwiArqDjb[P_0];
	}

	private void kxYXOczGbGYovRKhRmtTknTLOQki(bool P_0)
	{
		if (!P_0)
		{
			tqFIKahxXBNpyqlEjLNobyZXOuiG.DbzeXaFmlDiXbEKUydxrwvLYFtxB();
		}
	}

	private void wvficJCHzdjANZlZgBkKcQPtVPNc(bool P_0)
	{
		gtwrzRxKKsEjVlkbmBHrjBQtgkhxA.XhWByFCKCpNTbgLDhmyYiIbaeaetb(P_0);
		TcXjdodExmGIMmvhgFqpjWPQzPMh.XhWByFCKCpNTbgLDhmyYiIbaeaetb(P_0);
		for (int i = 0; i < oTIRSXwUOjVATBmccAzgFcTLhMNHA.Count; i++)
		{
			oTIRSXwUOjVATBmccAzgFcTLhMNHA[i].XhWByFCKCpNTbgLDhmyYiIbaeaetb(P_0);
		}
		for (int j = 0; j < oOJzaJuUNptKoxPEGGGmWLhvxyhV.Count; j++)
		{
			oOJzaJuUNptKoxPEGGGmWLhvxyhV[j].XhWByFCKCpNTbgLDhmyYiIbaeaetb(P_0);
		}
	}

	public void Dispose()
	{
		YfROkfKEfTMajafkjfebjtiBQmuiA(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	protected void gbGXJXTvlLBkXtbSGcSIqjZHfSCC()
	{
		try
		{
			YfROkfKEfTMajafkjfebjtiBQmuiA(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	private void YfROkfKEfTMajafkjfebjtiBQmuiA(bool P_0)
	{
		if (VgOkyMzeqDFrEjWFWBgBVEWtpcAR)
		{
			return;
		}
		if (P_0)
		{
			if (NjnNWIimpWqUqzrIDUTAJkinpGSr is IDisposable)
			{
				(NjnNWIimpWqUqzrIDUTAJkinpGSr as IDisposable).Dispose();
			}
			if (RZvInilekGqrOqJRGmFPmkxCSYAC is IDisposable)
			{
				(RZvInilekGqrOqJRGmFPmkxCSYAC as IDisposable).Dispose();
			}
		}
		VgOkyMzeqDFrEjWFWBgBVEWtpcAR = true;
	}
}
