using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Rewired.Data.Mapping;
using Rewired.Interfaces;
using Rewired.Internal.Localization;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using UnityEngine;

namespace Rewired;

public abstract class ControllerTemplate : IControllerTemplate, IControllerTemplate_Internal, JPyUCjMynlgXcSTGrAuSOGxEMeWJ
{
	internal abstract class vCSckBDWTefTIHAuQdyMtgfxPwdeb : IControllerTemplateElement, IControllerTemplateElement_Internal
	{
		private readonly IControllerTemplate ICpahtjOEvDZmjMObOKwWPFHQoBn;

		private readonly int HhAmsTPNILoFhvvLXiUaywTPrFwr;

		private readonly ControllerTemplateElementType BmlTanLSMZvNcoKHeVLSTAsdQdNQ;

		protected readonly int OHlHwXwyfreIswnUvPMrEwLWiLWD;

		protected readonly fDxEaPJRzBYVTBJLRZuBiXQfXsyKA DxhXWaJWgUjqrWEmljpvYzcauiTq;

		int IControllerTemplateElement.id => get_id();

		string IControllerTemplateElement.descriptiveName => get_descriptiveName();

		internal string RMNAlYZpobTkrspknBeNKegAPTBU => PkzXVQSzeQqcyavWcUivsoIHFbyEA();

		ControllerTemplateElementType IControllerTemplateElement.type => get_type();

		IControllerTemplate IControllerTemplateElement_Internal.parent => get_parent();

		public abstract int elementCount { get; }

		public abstract IControllerTemplateElementSource source { get; }

		public abstract bool exists { get; }

		protected vCSckBDWTefTIHAuQdyMtgfxPwdeb(IControllerTemplate P_0, int P_1, ControllerTemplateElementType P_2, fDxEaPJRzBYVTBJLRZuBiXQfXsyKA P_3)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("parent");
			}
			if (P_3 == null)
			{
				throw new ArgumentNullException("localizedElement");
			}
			ICpahtjOEvDZmjMObOKwWPFHQoBn = P_0;
			HhAmsTPNILoFhvvLXiUaywTPrFwr = P_1;
			BmlTanLSMZvNcoKHeVLSTAsdQdNQ = P_2;
			OHlHwXwyfreIswnUvPMrEwLWiLWD = ReInput.id;
			DxhXWaJWgUjqrWEmljpvYzcauiTq = P_3;
		}

		public int get_id()
		{
			if (ReInput._id != OHlHwXwyfreIswnUvPMrEwLWiLWD)
			{
				ReInput.CheckInitialized(OHlHwXwyfreIswnUvPMrEwLWiLWD);
				return -1;
			}
			return HhAmsTPNILoFhvvLXiUaywTPrFwr;
		}

		public string get_descriptiveName()
		{
			if (ReInput._id != OHlHwXwyfreIswnUvPMrEwLWiLWD)
			{
				ReInput.CheckInitialized(OHlHwXwyfreIswnUvPMrEwLWiLWD);
				return null;
			}
			return DxhXWaJWgUjqrWEmljpvYzcauiTq.wJSaidLYIbFfvypVFagGHdYhSJmsA();
		}

		internal string PkzXVQSzeQqcyavWcUivsoIHFbyEA()
		{
			return DxhXWaJWgUjqrWEmljpvYzcauiTq.nonLocalizedDescriptiveName;
		}

		public ControllerTemplateElementType get_type()
		{
			if (ReInput._id != OHlHwXwyfreIswnUvPMrEwLWiLWD)
			{
				ReInput.CheckInitialized(OHlHwXwyfreIswnUvPMrEwLWiLWD);
				return ControllerTemplateElementType.Axis;
			}
			return BmlTanLSMZvNcoKHeVLSTAsdQdNQ;
		}

		public IControllerTemplate get_parent()
		{
			return ICpahtjOEvDZmjMObOKwWPFHQoBn;
		}

		public abstract IControllerTemplateElement GetElement(int index);

		public abstract int GetElementTargets(ControllerElementTarget find, ref IList<ControllerTemplateElementTarget> list);

		protected static fDxEaPJRzBYVTBJLRZuBiXQfXsyKA BvnMuvMLgRfIZCTPDMyDOgUCkiuSA(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3)
		{
			return XPIXCvEWlHzEaVUSYOrktDWScXoe.lZiHQAskUcfYVbVnzAgaWKkbvxBz(new fDxEaPJRzBYVTBJLRZuBiXQfXsyKA(NtegfVEpjhCPjIKQDKtGQwLhlCadb.QmbaXxHkyfkmisZtxVVhlKfzcJxuA(EIJabuCGuIkogTgNjoJeTXIEuNcy.ControllerTemplate, pNZrRihcucynHABMizyaEoIxhqLo.AhhliCUThpTCpJDayBicensRWslA.Unknown, pNZrRihcucynHABMizyaEoIxhqLo.lGAwloROqSjUpJpzAfJNHgHgvWNeA.None, P_1, P_0.deviceLocalizationInfo), "controller/template", string.Empty, P_2, P_3));
		}
	}

	internal abstract class dEZoRQHmsBszCjQeHMGIMEYCBGmjA : vCSckBDWTefTIHAuQdyMtgfxPwdeb
	{
		protected readonly int AlZDLBCcEHaLdKuClzZpoHmNAZmaA;

		protected readonly CiSbSfhgauKBAosHqvPypWbhRysEA[] rAbEVVedwYlDWNiVOTupVGysvWjQ;

		bool vCSckBDWTefTIHAuQdyMtgfxPwdeb.exists => get_exists();

		protected dEZoRQHmsBszCjQeHMGIMEYCBGmjA(IControllerTemplate P_0, int P_1, ControllerTemplateElementType P_2, IList<CiSbSfhgauKBAosHqvPypWbhRysEA> P_3, fDxEaPJRzBYVTBJLRZuBiXQfXsyKA P_4)
			: base(P_0, P_1, P_2, P_4)
		{
			rAbEVVedwYlDWNiVOTupVGysvWjQ = ((P_3 != null) ? ListTools.ToArray(P_3) : null);
			AlZDLBCcEHaLdKuClzZpoHmNAZmaA = ((rAbEVVedwYlDWNiVOTupVGysvWjQ != null) ? rAbEVVedwYlDWNiVOTupVGysvWjQ.Length : 0);
		}

		public virtual bool get_exists()
		{
			if (ReInput._id != OHlHwXwyfreIswnUvPMrEwLWiLWD)
			{
				ReInput.CheckInitialized(OHlHwXwyfreIswnUvPMrEwLWiLWD);
				return false;
			}
			if (rAbEVVedwYlDWNiVOTupVGysvWjQ == null)
			{
				return false;
			}
			for (int i = 0; i < rAbEVVedwYlDWNiVOTupVGysvWjQ.Length; i++)
			{
				if (rAbEVVedwYlDWNiVOTupVGysvWjQ[i].FzVDVkSKSNvwUKnEwGKwZvpOGapL != null)
				{
					return true;
				}
			}
			return false;
		}
	}

	internal abstract class dPNudSCSIZEEYyzhsbwFYmHFxnIP : dEZoRQHmsBszCjQeHMGIMEYCBGmjA, IControllerTemplateAxis, IControllerTemplateElement, IControllerTemplateButton
	{
		private NxexmFcztmkjMTmmeibTdDSlWuxt jATJPbmDeVBMpfEImBVLggiKVoGxB;

		public float tkOwkoFVZbBQaTGeqcvOMhcmKlYQ => NzPxNtkThgEYuwsAMNDvVlKzBCJw();

		public float bJGpDfBmSjBDxjXaAaQtjRDXcwtBA => cuFPToOlLJGLtBIZoiinXFMEWRIB();

		public bool FRXOJWAyeeverCrSkpVqUioJvMPB => sHGYIvRxVtuZfrrHExOkrNWfJDZX();

		public bool oIcAeXHDEjboayHbnzoJuztIGduY => ZVbtiXZnOwPAwNpbRZqLhzqWrwCE();

		string IControllerTemplateAxis.positiveDescriptiveName
		{
			get
			{
				if (ReInput._id != OHlHwXwyfreIswnUvPMrEwLWiLWD)
				{
					ReInput.CheckInitialized(OHlHwXwyfreIswnUvPMrEwLWiLWD);
					return null;
				}
				return qoQhpCSoVvikAqiIDtHFdSfkhcxeA().KHZmiPiyIoEadWBLxzFyUKtwName();
			}
		}

		string IControllerTemplateAxis.negativeDescriptiveName
		{
			get
			{
				if (ReInput._id != OHlHwXwyfreIswnUvPMrEwLWiLWD)
				{
					ReInput.CheckInitialized(OHlHwXwyfreIswnUvPMrEwLWiLWD);
					return null;
				}
				return qoQhpCSoVvikAqiIDtHFdSfkhcxeA().cvYrQPQeqyhxobFbjJFwkojgOjeB();
			}
		}

		float IControllerTemplateAxis.value
		{
			get
			{
				if (ReInput._id != OHlHwXwyfreIswnUvPMrEwLWiLWD)
				{
					ReInput.CheckInitialized(OHlHwXwyfreIswnUvPMrEwLWiLWD);
					return 0f;
				}
				return NzPxNtkThgEYuwsAMNDvVlKzBCJw();
			}
		}

		float IControllerTemplateAxis.valuePrev
		{
			get
			{
				if (ReInput._id != OHlHwXwyfreIswnUvPMrEwLWiLWD)
				{
					ReInput.CheckInitialized(OHlHwXwyfreIswnUvPMrEwLWiLWD);
					return 0f;
				}
				return cuFPToOlLJGLtBIZoiinXFMEWRIB();
			}
		}

		IControllerTemplateAxisSource IControllerTemplateAxis.source
		{
			get
			{
				if (ReInput._id != OHlHwXwyfreIswnUvPMrEwLWiLWD)
				{
					ReInput.CheckInitialized(OHlHwXwyfreIswnUvPMrEwLWiLWD);
					return null;
				}
				return jATJPbmDeVBMpfEImBVLggiKVoGxB;
			}
		}

		bool IControllerTemplateButton.value
		{
			get
			{
				if (ReInput._id != OHlHwXwyfreIswnUvPMrEwLWiLWD)
				{
					ReInput.CheckInitialized(OHlHwXwyfreIswnUvPMrEwLWiLWD);
					return false;
				}
				return sHGYIvRxVtuZfrrHExOkrNWfJDZX();
			}
		}

		bool IControllerTemplateButton.valuePrev
		{
			get
			{
				if (ReInput._id != OHlHwXwyfreIswnUvPMrEwLWiLWD)
				{
					ReInput.CheckInitialized(OHlHwXwyfreIswnUvPMrEwLWiLWD);
					return false;
				}
				return ZVbtiXZnOwPAwNpbRZqLhzqWrwCE();
			}
		}

		bool IControllerTemplateButton.justPressed
		{
			get
			{
				if (ReInput._id != OHlHwXwyfreIswnUvPMrEwLWiLWD)
				{
					ReInput.CheckInitialized(OHlHwXwyfreIswnUvPMrEwLWiLWD);
					return false;
				}
				if (AlZDLBCcEHaLdKuClzZpoHmNAZmaA == 1)
				{
					return rAbEVVedwYlDWNiVOTupVGysvWjQ[0].uuVtTjRfYuGBKaSejiOHzefBmaun();
				}
				if (AlZDLBCcEHaLdKuClzZpoHmNAZmaA == 2)
				{
					if (!rAbEVVedwYlDWNiVOTupVGysvWjQ[0].uuVtTjRfYuGBKaSejiOHzefBmaun() || rAbEVVedwYlDWNiVOTupVGysvWjQ[1].ZZtCcRxcjZwYrnxbsMKyGUnDbdID())
					{
						if (rAbEVVedwYlDWNiVOTupVGysvWjQ[1].uuVtTjRfYuGBKaSejiOHzefBmaun())
						{
							return !rAbEVVedwYlDWNiVOTupVGysvWjQ[0].ZZtCcRxcjZwYrnxbsMKyGUnDbdID();
						}
						return false;
					}
					return true;
				}
				return false;
			}
		}

		bool IControllerTemplateButton.justReleased
		{
			get
			{
				if (ReInput._id != OHlHwXwyfreIswnUvPMrEwLWiLWD)
				{
					ReInput.CheckInitialized(OHlHwXwyfreIswnUvPMrEwLWiLWD);
					return false;
				}
				if (AlZDLBCcEHaLdKuClzZpoHmNAZmaA == 1)
				{
					return rAbEVVedwYlDWNiVOTupVGysvWjQ[0].wZBpNCbaAtvoQSNKomdvazNLpgRq();
				}
				if (AlZDLBCcEHaLdKuClzZpoHmNAZmaA == 2)
				{
					if (!rAbEVVedwYlDWNiVOTupVGysvWjQ[0].wZBpNCbaAtvoQSNKomdvazNLpgRq() || rAbEVVedwYlDWNiVOTupVGysvWjQ[1].fSbYrkjGCUUfQQzxlxGLgPpRVmgC())
					{
						if (rAbEVVedwYlDWNiVOTupVGysvWjQ[1].wZBpNCbaAtvoQSNKomdvazNLpgRq())
						{
							return !rAbEVVedwYlDWNiVOTupVGysvWjQ[0].fSbYrkjGCUUfQQzxlxGLgPpRVmgC();
						}
						return false;
					}
					return true;
				}
				return false;
			}
		}

		bool IControllerTemplateButton.justChangedState
		{
			get
			{
				if (ReInput._id != OHlHwXwyfreIswnUvPMrEwLWiLWD)
				{
					ReInput.CheckInitialized(OHlHwXwyfreIswnUvPMrEwLWiLWD);
					return false;
				}
				return sHGYIvRxVtuZfrrHExOkrNWfJDZX() != ZVbtiXZnOwPAwNpbRZqLhzqWrwCE();
			}
		}

		float IControllerTemplateButton.pressure
		{
			get
			{
				if (ReInput._id != OHlHwXwyfreIswnUvPMrEwLWiLWD)
				{
					ReInput.CheckInitialized(OHlHwXwyfreIswnUvPMrEwLWiLWD);
					return 0f;
				}
				return NzPxNtkThgEYuwsAMNDvVlKzBCJw();
			}
		}

		float IControllerTemplateButton.pressurePrev
		{
			get
			{
				if (ReInput._id != OHlHwXwyfreIswnUvPMrEwLWiLWD)
				{
					ReInput.CheckInitialized(OHlHwXwyfreIswnUvPMrEwLWiLWD);
					return 0f;
				}
				return cuFPToOlLJGLtBIZoiinXFMEWRIB();
			}
		}

		IControllerTemplateButtonSource IControllerTemplateButton.source
		{
			get
			{
				if (ReInput._id != OHlHwXwyfreIswnUvPMrEwLWiLWD)
				{
					ReInput.CheckInitialized(OHlHwXwyfreIswnUvPMrEwLWiLWD);
					return null;
				}
				return jATJPbmDeVBMpfEImBVLggiKVoGxB;
			}
		}

		IControllerTemplateElementSource vCSckBDWTefTIHAuQdyMtgfxPwdeb.source => get_source();

		int vCSckBDWTefTIHAuQdyMtgfxPwdeb.elementCount => get_elementCount();

		IControllerTemplateAxis IControllerTemplateButton.AsAxis => get_AsAxis();

		IControllerTemplateButton IControllerTemplateAxis.AsButton => get_AsButton();

		protected xnHCafhUamNGOffzAdlmbgnRiYTbb JSUObglmlulkFTskesEnuQEObRrB => qoQhpCSoVvikAqiIDtHFdSfkhcxeA();

		protected dPNudSCSIZEEYyzhsbwFYmHFxnIP(IControllerTemplate P_0, int P_1, ControllerTemplateElementType P_2, NxexmFcztmkjMTmmeibTdDSlWuxt P_3, IList<CiSbSfhgauKBAosHqvPypWbhRysEA> P_4, xnHCafhUamNGOffzAdlmbgnRiYTbb P_5)
			: base(P_0, P_1, P_2, P_4, P_5)
		{
			if (P_4 != null && P_4.Count > 2)
			{
				throw new ArgumentOutOfRangeException("sourceElements.Count must be <= 2.");
			}
			if (P_3 == null)
			{
				throw new ArgumentNullException("target");
			}
			jATJPbmDeVBMpfEImBVLggiKVoGxB = P_3;
		}

		public float NzPxNtkThgEYuwsAMNDvVlKzBCJw()
		{
			if (ReInput._id != OHlHwXwyfreIswnUvPMrEwLWiLWD)
			{
				ReInput.CheckInitialized(OHlHwXwyfreIswnUvPMrEwLWiLWD);
				return 0f;
			}
			if (AlZDLBCcEHaLdKuClzZpoHmNAZmaA == 1)
			{
				return rAbEVVedwYlDWNiVOTupVGysvWjQ[0].oOlGqJTAGplVKSfpauIiHUnZworG();
			}
			if (AlZDLBCcEHaLdKuClzZpoHmNAZmaA == 2)
			{
				float num = rAbEVVedwYlDWNiVOTupVGysvWjQ[0].oOlGqJTAGplVKSfpauIiHUnZworG();
				float num2 = rAbEVVedwYlDWNiVOTupVGysvWjQ[1].oOlGqJTAGplVKSfpauIiHUnZworG();
				return MathTools.Clamp(num + num2, -1f, 1f);
			}
			return 0f;
		}

		public float cuFPToOlLJGLtBIZoiinXFMEWRIB()
		{
			if (ReInput._id != OHlHwXwyfreIswnUvPMrEwLWiLWD)
			{
				ReInput.CheckInitialized(OHlHwXwyfreIswnUvPMrEwLWiLWD);
				return 0f;
			}
			if (AlZDLBCcEHaLdKuClzZpoHmNAZmaA == 1)
			{
				return rAbEVVedwYlDWNiVOTupVGysvWjQ[0].PvZHNcXWSiXsDVOQKgaszvlFSWED();
			}
			if (AlZDLBCcEHaLdKuClzZpoHmNAZmaA == 2)
			{
				float num = rAbEVVedwYlDWNiVOTupVGysvWjQ[0].PvZHNcXWSiXsDVOQKgaszvlFSWED();
				float num2 = rAbEVVedwYlDWNiVOTupVGysvWjQ[1].PvZHNcXWSiXsDVOQKgaszvlFSWED();
				return MathTools.Clamp(num + num2, -1f, 1f);
			}
			return 0f;
		}

		public bool sHGYIvRxVtuZfrrHExOkrNWfJDZX()
		{
			if (ReInput._id != OHlHwXwyfreIswnUvPMrEwLWiLWD)
			{
				ReInput.CheckInitialized(OHlHwXwyfreIswnUvPMrEwLWiLWD);
				return false;
			}
			if (AlZDLBCcEHaLdKuClzZpoHmNAZmaA == 1)
			{
				return rAbEVVedwYlDWNiVOTupVGysvWjQ[0].fSbYrkjGCUUfQQzxlxGLgPpRVmgC();
			}
			if (AlZDLBCcEHaLdKuClzZpoHmNAZmaA == 2)
			{
				if (!rAbEVVedwYlDWNiVOTupVGysvWjQ[0].fSbYrkjGCUUfQQzxlxGLgPpRVmgC())
				{
					return rAbEVVedwYlDWNiVOTupVGysvWjQ[1].fSbYrkjGCUUfQQzxlxGLgPpRVmgC();
				}
				return true;
			}
			return false;
		}

		public bool ZVbtiXZnOwPAwNpbRZqLhzqWrwCE()
		{
			if (ReInput._id != OHlHwXwyfreIswnUvPMrEwLWiLWD)
			{
				ReInput.CheckInitialized(OHlHwXwyfreIswnUvPMrEwLWiLWD);
				return false;
			}
			if (AlZDLBCcEHaLdKuClzZpoHmNAZmaA == 1)
			{
				return rAbEVVedwYlDWNiVOTupVGysvWjQ[0].ZZtCcRxcjZwYrnxbsMKyGUnDbdID();
			}
			if (AlZDLBCcEHaLdKuClzZpoHmNAZmaA == 2)
			{
				if (!rAbEVVedwYlDWNiVOTupVGysvWjQ[0].ZZtCcRxcjZwYrnxbsMKyGUnDbdID())
				{
					return rAbEVVedwYlDWNiVOTupVGysvWjQ[1].ZZtCcRxcjZwYrnxbsMKyGUnDbdID();
				}
				return true;
			}
			return false;
		}

		string IControllerTemplateAxis.GetDescriptiveName(AxisRange axisRange)
		{
			if (ReInput._id != OHlHwXwyfreIswnUvPMrEwLWiLWD)
			{
				ReInput.CheckInitialized(OHlHwXwyfreIswnUvPMrEwLWiLWD);
				return null;
			}
			return axisRange switch
			{
				AxisRange.Full => get_descriptiveName(), 
				AxisRange.Positive => ((IControllerTemplateAxis)this).positiveDescriptiveName, 
				AxisRange.Negative => ((IControllerTemplateAxis)this).negativeDescriptiveName, 
				_ => throw new NotImplementedException(), 
			};
		}

		public virtual IControllerTemplateElementSource get_source()
		{
			if (ReInput._id != OHlHwXwyfreIswnUvPMrEwLWiLWD)
			{
				ReInput.CheckInitialized(OHlHwXwyfreIswnUvPMrEwLWiLWD);
				return null;
			}
			return jATJPbmDeVBMpfEImBVLggiKVoGxB;
		}

		public virtual int get_elementCount()
		{
			return 0;
		}

		public override IControllerTemplateElement GetElement(int index)
		{
			return null;
		}

		public override int GetElementTargets(ControllerElementTarget find, ref IList<ControllerTemplateElementTarget> list)
		{
			if (find.elementIdentifierId < 0)
			{
				return 0;
			}
			int num = 0;
			switch (get_type())
			{
			case ControllerTemplateElementType.Axis:
			{
				IControllerTemplateAxisSource controllerTemplateAxisSource = jATJPbmDeVBMpfEImBVLggiKVoGxB;
				if (controllerTemplateAxisSource.splitAxis)
				{
					if (qDSNrmJKujbllSdomGaRJwDVpXJN(find, controllerTemplateAxisSource.positiveTarget))
					{
						ListTools.AddAndCreateList(ref list, new ControllerTemplateElementTarget(this, AxisRange.Positive));
						num++;
					}
					if (qDSNrmJKujbllSdomGaRJwDVpXJN(find, controllerTemplateAxisSource.negativeTarget))
					{
						ListTools.AddAndCreateList(ref list, new ControllerTemplateElementTarget(this, AxisRange.Negative));
						num++;
					}
				}
				else if (qDSNrmJKujbllSdomGaRJwDVpXJN(find, controllerTemplateAxisSource.fullTarget))
				{
					ListTools.AddAndCreateList(ref list, new ControllerTemplateElementTarget(this, find.axisRange));
					num++;
				}
				break;
			}
			case ControllerTemplateElementType.Button:
				if (qDSNrmJKujbllSdomGaRJwDVpXJN(find, ((IControllerTemplateButtonSource)jATJPbmDeVBMpfEImBVLggiKVoGxB).target))
				{
					ListTools.AddAndCreateList(ref list, new ControllerTemplateElementTarget(this, AxisRange.Full));
					num++;
				}
				break;
			default:
				throw new NotImplementedException();
			}
			return num;
		}

		public IControllerTemplateAxis get_AsAxis()
		{
			if (ReInput._id != OHlHwXwyfreIswnUvPMrEwLWiLWD)
			{
				ReInput.CheckInitialized(OHlHwXwyfreIswnUvPMrEwLWiLWD);
				return null;
			}
			return this;
		}

		public IControllerTemplateButton get_AsButton()
		{
			if (ReInput._id != OHlHwXwyfreIswnUvPMrEwLWiLWD)
			{
				ReInput.CheckInitialized(OHlHwXwyfreIswnUvPMrEwLWiLWD);
				return null;
			}
			return this;
		}

		protected xnHCafhUamNGOffzAdlmbgnRiYTbb qoQhpCSoVvikAqiIDtHFdSfkhcxeA()
		{
			return (xnHCafhUamNGOffzAdlmbgnRiYTbb)DxhXWaJWgUjqrWEmljpvYzcauiTq;
		}

		private static bool qDSNrmJKujbllSdomGaRJwDVpXJN(ControllerElementTarget P_0, IControllerElementTarget P_1)
		{
			if (P_1.elementIdentifierId != P_0.elementIdentifierId)
			{
				return false;
			}
			switch (P_1.elementType)
			{
			case ControllerElementType.Axis:
			{
				AxisRange axisRange = P_1.axisRange;
				if (axisRange == AxisRange.Full)
				{
					return true;
				}
				if (axisRange == P_0.axisRange)
				{
					return true;
				}
				return false;
			}
			case ControllerElementType.Button:
				return true;
			default:
				throw new NotImplementedException();
			}
		}
	}

	internal sealed class EORxWzhjnxSHEOFrXHdOtmhKSPXU : dPNudSCSIZEEYyzhsbwFYmHFxnIP
	{
		public EORxWzhjnxSHEOFrXHdOtmhKSPXU(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, string P_4, string P_5, string P_6, string P_7, NxexmFcztmkjMTmmeibTdDSlWuxt P_8, IList<CiSbSfhgauKBAosHqvPypWbhRysEA> P_9)
			: base(P_0, P_1, ControllerTemplateElementType.Axis, P_8, P_9, (xnHCafhUamNGOffzAdlmbgnRiYTbb)XPIXCvEWlHzEaVUSYOrktDWScXoe.lZiHQAskUcfYVbVnzAgaWKkbvxBz(new xnHCafhUamNGOffzAdlmbgnRiYTbb(LQtXvKbJmTxxtcVMoxtOkVHKDdXk.uhfQBGaVNbDbbuZwmYjNIpspUgcE(EIJabuCGuIkogTgNjoJeTXIEuNcy.ControllerTemplate, pNZrRihcucynHABMizyaEoIxhqLo.AhhliCUThpTCpJDayBicensRWslA.Axis, pNZrRihcucynHABMizyaEoIxhqLo.lGAwloROqSjUpJpzAfJNHgHgvWNeA.None, P_1, P_0.deviceLocalizationInfo), "controller/template", string.Empty, P_2, P_3, P_4, P_5, P_6, P_7)))
		{
			if (P_9 != null && P_9.Count > 2)
			{
				throw new ArgumentOutOfRangeException("sourceElements.Count must be <= 2.");
			}
		}

		internal static EORxWzhjnxSHEOFrXHdOtmhKSPXU VVkGaaXHjJHrqubARBzSmYODNOCL(IControllerTemplate_Internal P_0)
		{
			return new EORxWzhjnxSHEOFrXHdOtmhKSPXU(P_0, -1, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, NxexmFcztmkjMTmmeibTdDSlWuxt.AwJyFZSwQefPsVvLcjELYDJqdsFB(ControllerTemplateElementType.Axis), null);
		}
	}

	internal sealed class lSxoJayIKzvoXJqfGbfmKtxXqIGF : dPNudSCSIZEEYyzhsbwFYmHFxnIP
	{
		public lSxoJayIKzvoXJqfGbfmKtxXqIGF(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, string P_4, string P_5, string P_6, string P_7, NxexmFcztmkjMTmmeibTdDSlWuxt P_8, IList<CiSbSfhgauKBAosHqvPypWbhRysEA> P_9)
			: base(P_0, P_1, ControllerTemplateElementType.Button, P_8, P_9, (xnHCafhUamNGOffzAdlmbgnRiYTbb)XPIXCvEWlHzEaVUSYOrktDWScXoe.lZiHQAskUcfYVbVnzAgaWKkbvxBz(new xnHCafhUamNGOffzAdlmbgnRiYTbb(LQtXvKbJmTxxtcVMoxtOkVHKDdXk.uhfQBGaVNbDbbuZwmYjNIpspUgcE(EIJabuCGuIkogTgNjoJeTXIEuNcy.ControllerTemplate, pNZrRihcucynHABMizyaEoIxhqLo.AhhliCUThpTCpJDayBicensRWslA.Button, pNZrRihcucynHABMizyaEoIxhqLo.lGAwloROqSjUpJpzAfJNHgHgvWNeA.None, P_1, P_0.deviceLocalizationInfo), "controller/template", string.Empty, P_2, P_3, P_4, P_5, P_6, P_7)))
		{
			if (P_9 != null && P_9.Count > 1)
			{
				throw new ArgumentOutOfRangeException("sourceElements.Count must be <= 1.");
			}
		}

		internal static lSxoJayIKzvoXJqfGbfmKtxXqIGF cSKcSMcdxoxvVekTGubjqXSztIpeA(IControllerTemplate_Internal P_0)
		{
			return new lSxoJayIKzvoXJqfGbfmKtxXqIGF(P_0, -1, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, NxexmFcztmkjMTmmeibTdDSlWuxt.AwJyFZSwQefPsVvLcjELYDJqdsFB(ControllerTemplateElementType.Button), null);
		}
	}

	internal abstract class HCxXKvUTXAeGAZyvMSAbcsxNPsSm : vCSckBDWTefTIHAuQdyMtgfxPwdeb
	{
		protected readonly int uARGixFxVZLWnbFodMbEGoyFrDKKb;

		protected readonly vCSckBDWTefTIHAuQdyMtgfxPwdeb[] uyYgOXTBypkgjXAiXShUQiNtdMrHA;

		bool vCSckBDWTefTIHAuQdyMtgfxPwdeb.exists => get_exists();

		IControllerTemplateElementSource vCSckBDWTefTIHAuQdyMtgfxPwdeb.source => get_source();

		int vCSckBDWTefTIHAuQdyMtgfxPwdeb.elementCount => get_elementCount();

		protected HCxXKvUTXAeGAZyvMSAbcsxNPsSm(IControllerTemplate P_0, int P_1, ControllerTemplateElementType P_2, vCSckBDWTefTIHAuQdyMtgfxPwdeb[] P_3, fDxEaPJRzBYVTBJLRZuBiXQfXsyKA P_4)
			: base(P_0, P_1, P_2, P_4)
		{
			if (P_3 == null)
			{
				throw new ArgumentNullException("elements");
			}
			if (P_3.Length == 0)
			{
				throw new ArgumentException("elements.Length is zero.");
			}
			for (int i = 0; i < P_3.Length; i++)
			{
				if (P_3[i] == null)
				{
					throw new ArgumentNullException("elements contains a null entry.");
				}
			}
			uyYgOXTBypkgjXAiXShUQiNtdMrHA = P_3;
			uARGixFxVZLWnbFodMbEGoyFrDKKb = P_3.Length;
		}

		public virtual bool get_exists()
		{
			if (ReInput._id != OHlHwXwyfreIswnUvPMrEwLWiLWD)
			{
				ReInput.CheckInitialized(OHlHwXwyfreIswnUvPMrEwLWiLWD);
				return false;
			}
			for (int i = 0; i < uARGixFxVZLWnbFodMbEGoyFrDKKb; i++)
			{
				if (uyYgOXTBypkgjXAiXShUQiNtdMrHA[i].exists)
				{
					return true;
				}
			}
			return false;
		}

		public virtual IControllerTemplateElementSource get_source()
		{
			if (ReInput._id != OHlHwXwyfreIswnUvPMrEwLWiLWD)
			{
				ReInput.CheckInitialized(OHlHwXwyfreIswnUvPMrEwLWiLWD);
				return null;
			}
			return null;
		}

		public virtual int get_elementCount()
		{
			return uARGixFxVZLWnbFodMbEGoyFrDKKb;
		}

		public virtual IControllerTemplateElement gKtkkmVppXCOaGPGvPtvVGUVYtgv(int P_0)
		{
			return uyYgOXTBypkgjXAiXShUQiNtdMrHA[P_0];
		}

		public virtual int UauRvkKoYuPNbURqbMWEirfudxbn(ControllerElementTarget P_0, ref IList<ControllerTemplateElementTarget> P_1)
		{
			int num = 0;
			for (int i = 0; i < uyYgOXTBypkgjXAiXShUQiNtdMrHA.Length; i++)
			{
				num += uyYgOXTBypkgjXAiXShUQiNtdMrHA[i].GetElementTargets(P_0, ref P_1);
			}
			return num;
		}
	}

	internal abstract class tYSTuJVgrpnDhvSLkSrhWHnsvTmL : HCxXKvUTXAeGAZyvMSAbcsxNPsSm, IControllerTemplateAxis2D, IControllerTemplateElement
	{
		protected const int pFQyfGfINItUBjJBSiWEzDHSDJujA = 0;

		protected const int GeisvWIYnsJCUfCIXYfOtXCfoJUM = 1;

		protected const int hOzoIITWioCHmgoHqTNiLRfUWvGg = 2;

		Vector2 IControllerTemplateAxis2D.value => get_value();

		Vector2 IControllerTemplateAxis2D.valuePrev => get_valuePrev();

		IControllerTemplateAxis IControllerTemplateAxis2D.horizontal => get_horizontal();

		IControllerTemplateAxis IControllerTemplateAxis2D.vertical => get_vertical();

		protected tYSTuJVgrpnDhvSLkSrhWHnsvTmL(IControllerTemplate P_0, int P_1, ControllerTemplateElementType P_2, vCSckBDWTefTIHAuQdyMtgfxPwdeb[] P_3, fDxEaPJRzBYVTBJLRZuBiXQfXsyKA P_4)
			: base(P_0, P_1, P_2, P_3, P_4)
		{
		}

		public Vector2 get_value()
		{
			if (ReInput._id != OHlHwXwyfreIswnUvPMrEwLWiLWD)
			{
				ReInput.CheckInitialized(OHlHwXwyfreIswnUvPMrEwLWiLWD);
				return Vector2.zero;
			}
			return new Vector2((uARGixFxVZLWnbFodMbEGoyFrDKKb > 0) ? ((dPNudSCSIZEEYyzhsbwFYmHFxnIP)uyYgOXTBypkgjXAiXShUQiNtdMrHA[0]).NzPxNtkThgEYuwsAMNDvVlKzBCJw() : 0f, (uARGixFxVZLWnbFodMbEGoyFrDKKb > 1) ? ((dPNudSCSIZEEYyzhsbwFYmHFxnIP)uyYgOXTBypkgjXAiXShUQiNtdMrHA[1]).NzPxNtkThgEYuwsAMNDvVlKzBCJw() : 0f);
		}

		public Vector2 get_valuePrev()
		{
			if (ReInput._id != OHlHwXwyfreIswnUvPMrEwLWiLWD)
			{
				ReInput.CheckInitialized(OHlHwXwyfreIswnUvPMrEwLWiLWD);
				return Vector2.zero;
			}
			return new Vector2((uARGixFxVZLWnbFodMbEGoyFrDKKb > 0) ? ((dPNudSCSIZEEYyzhsbwFYmHFxnIP)uyYgOXTBypkgjXAiXShUQiNtdMrHA[0]).cuFPToOlLJGLtBIZoiinXFMEWRIB() : 0f, (uARGixFxVZLWnbFodMbEGoyFrDKKb > 1) ? ((dPNudSCSIZEEYyzhsbwFYmHFxnIP)uyYgOXTBypkgjXAiXShUQiNtdMrHA[1]).cuFPToOlLJGLtBIZoiinXFMEWRIB() : 0f);
		}

		public IControllerTemplateAxis get_horizontal()
		{
			if (ReInput._id != OHlHwXwyfreIswnUvPMrEwLWiLWD)
			{
				ReInput.CheckInitialized(OHlHwXwyfreIswnUvPMrEwLWiLWD);
				return null;
			}
			return (IControllerTemplateAxis)uyYgOXTBypkgjXAiXShUQiNtdMrHA[0];
		}

		public IControllerTemplateAxis get_vertical()
		{
			if (ReInput._id != OHlHwXwyfreIswnUvPMrEwLWiLWD)
			{
				ReInput.CheckInitialized(OHlHwXwyfreIswnUvPMrEwLWiLWD);
				return null;
			}
			return (IControllerTemplateAxis)uyYgOXTBypkgjXAiXShUQiNtdMrHA[1];
		}
	}

	internal abstract class xcWxBgfLYXMTMSIOoRyUIPrxEEZF : HCxXKvUTXAeGAZyvMSAbcsxNPsSm, IControllerTemplateAxis3D, IControllerTemplateElement
	{
		protected const int ksFnOvckBfPqthlGGeWkEfaGuHmNA = 0;

		protected const int SEzfFJCnMxiJDvOewIzuBQXAKDLgc = 1;

		protected const int uTeGzIhPFeXYgdixlvCbIDpJpWAH = 2;

		protected const int zBtKEKBhamWMaoieAiJMrufDhctjA = 3;

		Vector3 IControllerTemplateAxis3D.value => get_value();

		Vector3 IControllerTemplateAxis3D.valuePrev => get_valuePrev();

		IControllerTemplateAxis IControllerTemplateAxis3D.horizontal => get_horizontal();

		IControllerTemplateAxis IControllerTemplateAxis3D.vertical => get_vertical();

		IControllerTemplateAxis IControllerTemplateAxis3D.depth => get_depth();

		protected xcWxBgfLYXMTMSIOoRyUIPrxEEZF(IControllerTemplate_Internal P_0, int P_1, ControllerTemplateElementType P_2, vCSckBDWTefTIHAuQdyMtgfxPwdeb[] P_3, fDxEaPJRzBYVTBJLRZuBiXQfXsyKA P_4)
			: base(P_0, P_1, P_2, P_3, P_4)
		{
		}

		public Vector3 get_value()
		{
			if (ReInput._id != OHlHwXwyfreIswnUvPMrEwLWiLWD)
			{
				ReInput.CheckInitialized(OHlHwXwyfreIswnUvPMrEwLWiLWD);
				return Vector3.zero;
			}
			return new Vector3((uARGixFxVZLWnbFodMbEGoyFrDKKb > 0) ? ((dPNudSCSIZEEYyzhsbwFYmHFxnIP)uyYgOXTBypkgjXAiXShUQiNtdMrHA[0]).NzPxNtkThgEYuwsAMNDvVlKzBCJw() : 0f, (uARGixFxVZLWnbFodMbEGoyFrDKKb > 1) ? ((dPNudSCSIZEEYyzhsbwFYmHFxnIP)uyYgOXTBypkgjXAiXShUQiNtdMrHA[1]).NzPxNtkThgEYuwsAMNDvVlKzBCJw() : 0f, (uARGixFxVZLWnbFodMbEGoyFrDKKb > 2) ? ((dPNudSCSIZEEYyzhsbwFYmHFxnIP)uyYgOXTBypkgjXAiXShUQiNtdMrHA[2]).NzPxNtkThgEYuwsAMNDvVlKzBCJw() : 0f);
		}

		public Vector3 get_valuePrev()
		{
			if (ReInput._id != OHlHwXwyfreIswnUvPMrEwLWiLWD)
			{
				ReInput.CheckInitialized(OHlHwXwyfreIswnUvPMrEwLWiLWD);
				return Vector3.zero;
			}
			return new Vector3((uARGixFxVZLWnbFodMbEGoyFrDKKb > 0) ? ((dPNudSCSIZEEYyzhsbwFYmHFxnIP)uyYgOXTBypkgjXAiXShUQiNtdMrHA[0]).cuFPToOlLJGLtBIZoiinXFMEWRIB() : 0f, (uARGixFxVZLWnbFodMbEGoyFrDKKb > 1) ? ((dPNudSCSIZEEYyzhsbwFYmHFxnIP)uyYgOXTBypkgjXAiXShUQiNtdMrHA[1]).cuFPToOlLJGLtBIZoiinXFMEWRIB() : 0f, (uARGixFxVZLWnbFodMbEGoyFrDKKb > 2) ? ((dPNudSCSIZEEYyzhsbwFYmHFxnIP)uyYgOXTBypkgjXAiXShUQiNtdMrHA[2]).cuFPToOlLJGLtBIZoiinXFMEWRIB() : 0f);
		}

		public IControllerTemplateAxis get_horizontal()
		{
			if (ReInput._id != OHlHwXwyfreIswnUvPMrEwLWiLWD)
			{
				ReInput.CheckInitialized(OHlHwXwyfreIswnUvPMrEwLWiLWD);
				return null;
			}
			return (IControllerTemplateAxis)uyYgOXTBypkgjXAiXShUQiNtdMrHA[0];
		}

		public IControllerTemplateAxis get_vertical()
		{
			if (ReInput._id != OHlHwXwyfreIswnUvPMrEwLWiLWD)
			{
				ReInput.CheckInitialized(OHlHwXwyfreIswnUvPMrEwLWiLWD);
				return null;
			}
			return (IControllerTemplateAxis)uyYgOXTBypkgjXAiXShUQiNtdMrHA[1];
		}

		public IControllerTemplateAxis get_depth()
		{
			if (ReInput._id != OHlHwXwyfreIswnUvPMrEwLWiLWD)
			{
				ReInput.CheckInitialized(OHlHwXwyfreIswnUvPMrEwLWiLWD);
				return null;
			}
			return (IControllerTemplateAxis)uyYgOXTBypkgjXAiXShUQiNtdMrHA[2];
		}
	}

	internal abstract class ZJwCcwWuPrhMAiJCDAofFYIfHJVsB : HCxXKvUTXAeGAZyvMSAbcsxNPsSm, IControllerTemplateAxis6D, IControllerTemplateElement
	{
		protected const int AdbplKYvZDnVOjAyNaBZgfhZOEWDb = 0;

		protected const int fDrncfgGlGRVdCRmQHcIUJQcPrUc = 1;

		protected const int RTqGpCASEYOreSnvXHuNVirqPQaH = 2;

		protected const int kZsZLIZenhZJusLwRjFRLIVxaEwD = 3;

		protected const int lhyLuvgcqkVieGqQuuddRpmxIsJQ = 4;

		protected const int oOLLShferFAdNZQBAmEdtQjrQYtr = 5;

		protected const int ScuEAccivlMQfDEqCxwVxIOTPQCB = 6;

		Vector3 IControllerTemplateAxis6D.position => get_position();

		Vector3 IControllerTemplateAxis6D.positionPrev => get_positionPrev();

		Vector3 IControllerTemplateAxis6D.rotation => get_rotation();

		Vector3 IControllerTemplateAxis6D.rotationPrev => get_rotationPrev();

		IControllerTemplateAxis IControllerTemplateAxis6D.positionX => get_positionX();

		IControllerTemplateAxis IControllerTemplateAxis6D.positionY => get_positionY();

		IControllerTemplateAxis IControllerTemplateAxis6D.positionZ => get_positionZ();

		IControllerTemplateAxis IControllerTemplateAxis6D.rotationX => get_rotationX();

		IControllerTemplateAxis IControllerTemplateAxis6D.rotationY => get_rotationY();

		IControllerTemplateAxis IControllerTemplateAxis6D.rotationZ => get_rotationZ();

		protected ZJwCcwWuPrhMAiJCDAofFYIfHJVsB(IControllerTemplate P_0, int P_1, ControllerTemplateElementType P_2, vCSckBDWTefTIHAuQdyMtgfxPwdeb[] P_3, fDxEaPJRzBYVTBJLRZuBiXQfXsyKA P_4)
			: base(P_0, P_1, P_2, P_3, P_4)
		{
		}

		public Vector3 get_position()
		{
			if (ReInput._id != OHlHwXwyfreIswnUvPMrEwLWiLWD)
			{
				ReInput.CheckInitialized(OHlHwXwyfreIswnUvPMrEwLWiLWD);
				return Vector3.zero;
			}
			return new Vector3((uARGixFxVZLWnbFodMbEGoyFrDKKb > 0) ? ((dPNudSCSIZEEYyzhsbwFYmHFxnIP)uyYgOXTBypkgjXAiXShUQiNtdMrHA[0]).NzPxNtkThgEYuwsAMNDvVlKzBCJw() : 0f, (uARGixFxVZLWnbFodMbEGoyFrDKKb > 1) ? ((dPNudSCSIZEEYyzhsbwFYmHFxnIP)uyYgOXTBypkgjXAiXShUQiNtdMrHA[1]).NzPxNtkThgEYuwsAMNDvVlKzBCJw() : 0f, (uARGixFxVZLWnbFodMbEGoyFrDKKb > 2) ? ((dPNudSCSIZEEYyzhsbwFYmHFxnIP)uyYgOXTBypkgjXAiXShUQiNtdMrHA[2]).NzPxNtkThgEYuwsAMNDvVlKzBCJw() : 0f);
		}

		public Vector3 get_positionPrev()
		{
			if (ReInput._id != OHlHwXwyfreIswnUvPMrEwLWiLWD)
			{
				ReInput.CheckInitialized(OHlHwXwyfreIswnUvPMrEwLWiLWD);
				return Vector3.zero;
			}
			return new Vector3((uARGixFxVZLWnbFodMbEGoyFrDKKb > 0) ? ((dPNudSCSIZEEYyzhsbwFYmHFxnIP)uyYgOXTBypkgjXAiXShUQiNtdMrHA[0]).cuFPToOlLJGLtBIZoiinXFMEWRIB() : 0f, (uARGixFxVZLWnbFodMbEGoyFrDKKb > 1) ? ((dPNudSCSIZEEYyzhsbwFYmHFxnIP)uyYgOXTBypkgjXAiXShUQiNtdMrHA[1]).cuFPToOlLJGLtBIZoiinXFMEWRIB() : 0f, (uARGixFxVZLWnbFodMbEGoyFrDKKb > 2) ? ((dPNudSCSIZEEYyzhsbwFYmHFxnIP)uyYgOXTBypkgjXAiXShUQiNtdMrHA[2]).cuFPToOlLJGLtBIZoiinXFMEWRIB() : 0f);
		}

		public Vector3 get_rotation()
		{
			if (ReInput._id != OHlHwXwyfreIswnUvPMrEwLWiLWD)
			{
				ReInput.CheckInitialized(OHlHwXwyfreIswnUvPMrEwLWiLWD);
				return Vector3.zero;
			}
			return new Vector3((uARGixFxVZLWnbFodMbEGoyFrDKKb > 3) ? ((dPNudSCSIZEEYyzhsbwFYmHFxnIP)uyYgOXTBypkgjXAiXShUQiNtdMrHA[3]).NzPxNtkThgEYuwsAMNDvVlKzBCJw() : 0f, (uARGixFxVZLWnbFodMbEGoyFrDKKb > 4) ? ((dPNudSCSIZEEYyzhsbwFYmHFxnIP)uyYgOXTBypkgjXAiXShUQiNtdMrHA[4]).NzPxNtkThgEYuwsAMNDvVlKzBCJw() : 0f, (uARGixFxVZLWnbFodMbEGoyFrDKKb > 5) ? ((dPNudSCSIZEEYyzhsbwFYmHFxnIP)uyYgOXTBypkgjXAiXShUQiNtdMrHA[5]).NzPxNtkThgEYuwsAMNDvVlKzBCJw() : 0f);
		}

		public Vector3 get_rotationPrev()
		{
			if (ReInput._id != OHlHwXwyfreIswnUvPMrEwLWiLWD)
			{
				ReInput.CheckInitialized(OHlHwXwyfreIswnUvPMrEwLWiLWD);
				return Vector3.zero;
			}
			return new Vector3((uARGixFxVZLWnbFodMbEGoyFrDKKb > 3) ? ((dPNudSCSIZEEYyzhsbwFYmHFxnIP)uyYgOXTBypkgjXAiXShUQiNtdMrHA[3]).cuFPToOlLJGLtBIZoiinXFMEWRIB() : 0f, (uARGixFxVZLWnbFodMbEGoyFrDKKb > 4) ? ((dPNudSCSIZEEYyzhsbwFYmHFxnIP)uyYgOXTBypkgjXAiXShUQiNtdMrHA[4]).cuFPToOlLJGLtBIZoiinXFMEWRIB() : 0f, (uARGixFxVZLWnbFodMbEGoyFrDKKb > 5) ? ((dPNudSCSIZEEYyzhsbwFYmHFxnIP)uyYgOXTBypkgjXAiXShUQiNtdMrHA[5]).cuFPToOlLJGLtBIZoiinXFMEWRIB() : 0f);
		}

		public IControllerTemplateAxis get_positionX()
		{
			if (ReInput._id != OHlHwXwyfreIswnUvPMrEwLWiLWD)
			{
				ReInput.CheckInitialized(OHlHwXwyfreIswnUvPMrEwLWiLWD);
				return null;
			}
			return (IControllerTemplateAxis)uyYgOXTBypkgjXAiXShUQiNtdMrHA[0];
		}

		public IControllerTemplateAxis get_positionY()
		{
			if (ReInput._id != OHlHwXwyfreIswnUvPMrEwLWiLWD)
			{
				ReInput.CheckInitialized(OHlHwXwyfreIswnUvPMrEwLWiLWD);
				return null;
			}
			return (IControllerTemplateAxis)uyYgOXTBypkgjXAiXShUQiNtdMrHA[1];
		}

		public IControllerTemplateAxis get_positionZ()
		{
			if (ReInput._id != OHlHwXwyfreIswnUvPMrEwLWiLWD)
			{
				ReInput.CheckInitialized(OHlHwXwyfreIswnUvPMrEwLWiLWD);
				return null;
			}
			return (IControllerTemplateAxis)uyYgOXTBypkgjXAiXShUQiNtdMrHA[2];
		}

		public IControllerTemplateAxis get_rotationX()
		{
			if (ReInput._id != OHlHwXwyfreIswnUvPMrEwLWiLWD)
			{
				ReInput.CheckInitialized(OHlHwXwyfreIswnUvPMrEwLWiLWD);
				return null;
			}
			return (IControllerTemplateAxis)uyYgOXTBypkgjXAiXShUQiNtdMrHA[3];
		}

		public IControllerTemplateAxis get_rotationY()
		{
			if (ReInput._id != OHlHwXwyfreIswnUvPMrEwLWiLWD)
			{
				ReInput.CheckInitialized(OHlHwXwyfreIswnUvPMrEwLWiLWD);
				return null;
			}
			return (IControllerTemplateAxis)uyYgOXTBypkgjXAiXShUQiNtdMrHA[4];
		}

		public IControllerTemplateAxis get_rotationZ()
		{
			if (ReInput._id != OHlHwXwyfreIswnUvPMrEwLWiLWD)
			{
				ReInput.CheckInitialized(OHlHwXwyfreIswnUvPMrEwLWiLWD);
				return null;
			}
			return (IControllerTemplateAxis)uyYgOXTBypkgjXAiXShUQiNtdMrHA[5];
		}
	}

	internal sealed class RwwLviKhqHfLUwdnvhRvHjvObsWbb : xcWxBgfLYXMTMSIOoRyUIPrxEEZF, IControllerTemplateStick, IControllerTemplateElement
	{
		private const int iupqHDIaminxRcyogRIJhxsXUMNH = 3;

		IControllerTemplateAxis IControllerTemplateStick.rotation => get_rotation();

		private RwwLviKhqHfLUwdnvhRvHjvObsWbb(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, vCSckBDWTefTIHAuQdyMtgfxPwdeb[] P_4)
			: base(P_0, P_1, ControllerTemplateElementType.Stick, P_4, vCSckBDWTefTIHAuQdyMtgfxPwdeb.BvnMuvMLgRfIZCTPDMyDOgUCkiuSA(P_0, P_1, P_2, P_3))
		{
			if (P_4.Length != 3)
			{
				throw new ArgumentException("elements.Length must be " + 3);
			}
		}

		public RwwLviKhqHfLUwdnvhRvHjvObsWbb(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, dPNudSCSIZEEYyzhsbwFYmHFxnIP P_4, dPNudSCSIZEEYyzhsbwFYmHFxnIP P_5, dPNudSCSIZEEYyzhsbwFYmHFxnIP P_6)
			: this(P_0, P_1, P_2, P_3, new vCSckBDWTefTIHAuQdyMtgfxPwdeb[3] { P_4, P_5, P_6 })
		{
		}

		public IControllerTemplateAxis get_rotation()
		{
			if (ReInput._id != OHlHwXwyfreIswnUvPMrEwLWiLWD)
			{
				ReInput.CheckInitialized(OHlHwXwyfreIswnUvPMrEwLWiLWD);
				return null;
			}
			return (IControllerTemplateAxis)uyYgOXTBypkgjXAiXShUQiNtdMrHA[2];
		}
	}

	internal sealed class UQJfqUhkNknnupBWUKieFeMFNrnNb : tYSTuJVgrpnDhvSLkSrhWHnsvTmL, IControllerTemplateThumbStick, IControllerTemplateElement
	{
		private const int djchIAbcLOGRJeWGDxJSfRtyGVXm = 2;

		private const int xLObbXhJUGSdjwaLSBOfncuBHcvhA = 3;

		IControllerTemplateButton IControllerTemplateThumbStick.press => get_press();

		private UQJfqUhkNknnupBWUKieFeMFNrnNb(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, vCSckBDWTefTIHAuQdyMtgfxPwdeb[] P_4)
			: base(P_0, P_1, ControllerTemplateElementType.ThumbStick, P_4, vCSckBDWTefTIHAuQdyMtgfxPwdeb.BvnMuvMLgRfIZCTPDMyDOgUCkiuSA(P_0, P_1, P_2, P_3))
		{
			if (P_4.Length != 3)
			{
				throw new ArgumentException("elements.Length must be " + 3);
			}
		}

		internal UQJfqUhkNknnupBWUKieFeMFNrnNb(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, dPNudSCSIZEEYyzhsbwFYmHFxnIP P_4, dPNudSCSIZEEYyzhsbwFYmHFxnIP P_5, dPNudSCSIZEEYyzhsbwFYmHFxnIP P_6)
			: this(P_0, P_1, P_2, P_3, new vCSckBDWTefTIHAuQdyMtgfxPwdeb[3] { P_4, P_5, P_6 })
		{
		}

		public IControllerTemplateButton get_press()
		{
			if (ReInput._id != OHlHwXwyfreIswnUvPMrEwLWiLWD)
			{
				ReInput.CheckInitialized(OHlHwXwyfreIswnUvPMrEwLWiLWD);
				return null;
			}
			return (IControllerTemplateButton)uyYgOXTBypkgjXAiXShUQiNtdMrHA[2];
		}
	}

	internal sealed class oEoXqXJFkhUePHthqrBrvLAycBxM : HCxXKvUTXAeGAZyvMSAbcsxNPsSm, IControllerTemplateDPad, IControllerTemplateElement
	{
		private const int PnUKGBJxBbdQgRPjiUjdHCBiSblg = 0;

		private const int DStFllJRSKAiczMhuALBlxbhEmWhA = 1;

		private const int pFxhcdIvPQajdqKWDHAvuibHZviX = 2;

		private const int wIYRXGaUwertrfUosDoHoLeaHjQJA = 3;

		private const int LjBxrZCNvTDHQFnDISfdGQXghliIA = 4;

		private const int YvRhsMJtudxttGEHGbLfEFYEeqBt = 5;

		Vector2 IControllerTemplateDPad.value => get_value();

		Vector2 IControllerTemplateDPad.valuePrev => get_valuePrev();

		IControllerTemplateButton IControllerTemplateDPad.up => get_up();

		IControllerTemplateButton IControllerTemplateDPad.right => get_right();

		IControllerTemplateButton IControllerTemplateDPad.down => get_down();

		IControllerTemplateButton IControllerTemplateDPad.left => get_left();

		IControllerTemplateButton IControllerTemplateDPad.press => get_press();

		private oEoXqXJFkhUePHthqrBrvLAycBxM(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, vCSckBDWTefTIHAuQdyMtgfxPwdeb[] P_4)
			: base(P_0, P_1, ControllerTemplateElementType.DPad, P_4, vCSckBDWTefTIHAuQdyMtgfxPwdeb.BvnMuvMLgRfIZCTPDMyDOgUCkiuSA(P_0, P_1, P_2, P_3))
		{
			if (P_4.Length != 5)
			{
				throw new ArgumentException("elements.Length must be " + 5);
			}
		}

		internal oEoXqXJFkhUePHthqrBrvLAycBxM(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, dPNudSCSIZEEYyzhsbwFYmHFxnIP P_4, dPNudSCSIZEEYyzhsbwFYmHFxnIP P_5, dPNudSCSIZEEYyzhsbwFYmHFxnIP P_6, dPNudSCSIZEEYyzhsbwFYmHFxnIP P_7, dPNudSCSIZEEYyzhsbwFYmHFxnIP P_8)
			: this(P_0, P_1, P_2, P_3, new vCSckBDWTefTIHAuQdyMtgfxPwdeb[5] { P_4, P_5, P_6, P_7, P_8 })
		{
		}

		public Vector2 get_value()
		{
			if (ReInput._id != OHlHwXwyfreIswnUvPMrEwLWiLWD)
			{
				ReInput.CheckInitialized(OHlHwXwyfreIswnUvPMrEwLWiLWD);
				return Vector2.zero;
			}
			return new Vector2(MathTools.Clamp(((dPNudSCSIZEEYyzhsbwFYmHFxnIP)uyYgOXTBypkgjXAiXShUQiNtdMrHA[0]).NzPxNtkThgEYuwsAMNDvVlKzBCJw() + ((dPNudSCSIZEEYyzhsbwFYmHFxnIP)uyYgOXTBypkgjXAiXShUQiNtdMrHA[2]).NzPxNtkThgEYuwsAMNDvVlKzBCJw() * -1f, -1f, 1f), MathTools.Clamp(((dPNudSCSIZEEYyzhsbwFYmHFxnIP)uyYgOXTBypkgjXAiXShUQiNtdMrHA[3]).NzPxNtkThgEYuwsAMNDvVlKzBCJw() * -1f + ((dPNudSCSIZEEYyzhsbwFYmHFxnIP)uyYgOXTBypkgjXAiXShUQiNtdMrHA[1]).NzPxNtkThgEYuwsAMNDvVlKzBCJw(), -1f, 1f));
		}

		public Vector2 get_valuePrev()
		{
			if (ReInput._id != OHlHwXwyfreIswnUvPMrEwLWiLWD)
			{
				ReInput.CheckInitialized(OHlHwXwyfreIswnUvPMrEwLWiLWD);
				return Vector2.zero;
			}
			return new Vector2(MathTools.Clamp(((dPNudSCSIZEEYyzhsbwFYmHFxnIP)uyYgOXTBypkgjXAiXShUQiNtdMrHA[0]).cuFPToOlLJGLtBIZoiinXFMEWRIB() + ((dPNudSCSIZEEYyzhsbwFYmHFxnIP)uyYgOXTBypkgjXAiXShUQiNtdMrHA[2]).cuFPToOlLJGLtBIZoiinXFMEWRIB() * -1f, -1f, 1f), MathTools.Clamp(((dPNudSCSIZEEYyzhsbwFYmHFxnIP)uyYgOXTBypkgjXAiXShUQiNtdMrHA[3]).cuFPToOlLJGLtBIZoiinXFMEWRIB() * -1f + ((dPNudSCSIZEEYyzhsbwFYmHFxnIP)uyYgOXTBypkgjXAiXShUQiNtdMrHA[1]).cuFPToOlLJGLtBIZoiinXFMEWRIB(), -1f, 1f));
		}

		public IControllerTemplateButton get_up()
		{
			if (ReInput._id != OHlHwXwyfreIswnUvPMrEwLWiLWD)
			{
				ReInput.CheckInitialized(OHlHwXwyfreIswnUvPMrEwLWiLWD);
				return null;
			}
			return (IControllerTemplateButton)uyYgOXTBypkgjXAiXShUQiNtdMrHA[0];
		}

		public IControllerTemplateButton get_right()
		{
			if (ReInput._id != OHlHwXwyfreIswnUvPMrEwLWiLWD)
			{
				ReInput.CheckInitialized(OHlHwXwyfreIswnUvPMrEwLWiLWD);
				return null;
			}
			return (IControllerTemplateButton)uyYgOXTBypkgjXAiXShUQiNtdMrHA[1];
		}

		public IControllerTemplateButton get_down()
		{
			if (ReInput._id != OHlHwXwyfreIswnUvPMrEwLWiLWD)
			{
				ReInput.CheckInitialized(OHlHwXwyfreIswnUvPMrEwLWiLWD);
				return null;
			}
			return (IControllerTemplateButton)uyYgOXTBypkgjXAiXShUQiNtdMrHA[2];
		}

		public IControllerTemplateButton get_left()
		{
			if (ReInput._id != OHlHwXwyfreIswnUvPMrEwLWiLWD)
			{
				ReInput.CheckInitialized(OHlHwXwyfreIswnUvPMrEwLWiLWD);
				return null;
			}
			return (IControllerTemplateButton)uyYgOXTBypkgjXAiXShUQiNtdMrHA[3];
		}

		public IControllerTemplateButton get_press()
		{
			if (ReInput._id != OHlHwXwyfreIswnUvPMrEwLWiLWD)
			{
				ReInput.CheckInitialized(OHlHwXwyfreIswnUvPMrEwLWiLWD);
				return null;
			}
			return (IControllerTemplateButton)uyYgOXTBypkgjXAiXShUQiNtdMrHA[4];
		}
	}

	internal sealed class fDEnEdOvEvHxarlVCzWgwmFwyMVF : HCxXKvUTXAeGAZyvMSAbcsxNPsSm, IControllerTemplateThrottle, IControllerTemplateElement
	{
		private const int LlFCrqGGWrkrgfqzDXgFVrnNsxjDc = 0;

		private const int DbyRxIpqkeKxTvwdDMTsesBXtamN = 1;

		private const int JEcFYbZLDRFHJsHHbrpAFDPnAxuBA = 2;

		float IControllerTemplateThrottle.value => get_value();

		float IControllerTemplateThrottle.valuePrev => get_valuePrev();

		IControllerTemplateAxis IControllerTemplateThrottle.throttle => get_throttle();

		IControllerTemplateButton IControllerTemplateThrottle.minDetent => get_minDetent();

		private fDEnEdOvEvHxarlVCzWgwmFwyMVF(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, vCSckBDWTefTIHAuQdyMtgfxPwdeb[] P_4)
			: base(P_0, P_1, ControllerTemplateElementType.Throttle, P_4, vCSckBDWTefTIHAuQdyMtgfxPwdeb.BvnMuvMLgRfIZCTPDMyDOgUCkiuSA(P_0, P_1, P_2, P_3))
		{
			if (P_4.Length != 2)
			{
				throw new ArgumentException("elements.Length must be " + 2);
			}
		}

		internal fDEnEdOvEvHxarlVCzWgwmFwyMVF(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, dPNudSCSIZEEYyzhsbwFYmHFxnIP P_4, dPNudSCSIZEEYyzhsbwFYmHFxnIP P_5)
			: this(P_0, P_1, P_2, P_3, new vCSckBDWTefTIHAuQdyMtgfxPwdeb[2] { P_4, P_5 })
		{
		}

		public float get_value()
		{
			if (ReInput._id != OHlHwXwyfreIswnUvPMrEwLWiLWD)
			{
				ReInput.CheckInitialized(OHlHwXwyfreIswnUvPMrEwLWiLWD);
				return 0f;
			}
			return ((dPNudSCSIZEEYyzhsbwFYmHFxnIP)uyYgOXTBypkgjXAiXShUQiNtdMrHA[0]).NzPxNtkThgEYuwsAMNDvVlKzBCJw();
		}

		public float get_valuePrev()
		{
			if (ReInput._id != OHlHwXwyfreIswnUvPMrEwLWiLWD)
			{
				ReInput.CheckInitialized(OHlHwXwyfreIswnUvPMrEwLWiLWD);
				return 0f;
			}
			return ((dPNudSCSIZEEYyzhsbwFYmHFxnIP)uyYgOXTBypkgjXAiXShUQiNtdMrHA[0]).cuFPToOlLJGLtBIZoiinXFMEWRIB();
		}

		public IControllerTemplateAxis get_throttle()
		{
			if (ReInput._id != OHlHwXwyfreIswnUvPMrEwLWiLWD)
			{
				ReInput.CheckInitialized(OHlHwXwyfreIswnUvPMrEwLWiLWD);
				return null;
			}
			return (IControllerTemplateAxis)uyYgOXTBypkgjXAiXShUQiNtdMrHA[0];
		}

		public IControllerTemplateButton get_minDetent()
		{
			if (ReInput._id != OHlHwXwyfreIswnUvPMrEwLWiLWD)
			{
				ReInput.CheckInitialized(OHlHwXwyfreIswnUvPMrEwLWiLWD);
				return null;
			}
			return (IControllerTemplateButton)uyYgOXTBypkgjXAiXShUQiNtdMrHA[1];
		}
	}

	internal sealed class YckzJrjhEBQTzUonJUxNYhTtSSzF : HCxXKvUTXAeGAZyvMSAbcsxNPsSm, IControllerTemplateHat, IControllerTemplateElement
	{
		private const int SfHiydMnzxOfrlewCHJrrScWeWVS = 0;

		private const int qroeWsVvFAuKcVMoxcYCemfyqjboA = 1;

		private const int ePghkuZVbyQOKDjMilkGoLcqIDiAA = 2;

		private const int vACzVAdFRUPRnFvipjtHVBWTQeds = 3;

		private const int NBPFSjdmyTtiAlpuBIRMBwngtEVCA = 4;

		private const int fbUQFHCGbozhMlPKtAoNKxJXPtlNA = 5;

		private const int zdfJIovYjkWsNwbUVWjpaqEywWcq = 6;

		private const int IZVDfQcRJovHefftIRPDHKdtTnMeA = 7;

		private const int nbLPCxurckccQfvYnAvkWrnwNPni = 8;

		Vector2 IControllerTemplateHat.value => get_value();

		Vector2 IControllerTemplateHat.valuePrev => get_valuePrev();

		IControllerTemplateButton IControllerTemplateHat.up => get_up();

		IControllerTemplateButton IControllerTemplateHat.upRight => get_upRight();

		IControllerTemplateButton IControllerTemplateHat.right => get_right();

		IControllerTemplateButton IControllerTemplateHat.downRight => get_downRight();

		IControllerTemplateButton IControllerTemplateHat.down => get_down();

		IControllerTemplateButton IControllerTemplateHat.downLeft => get_downLeft();

		IControllerTemplateButton IControllerTemplateHat.left => get_left();

		IControllerTemplateButton IControllerTemplateHat.upLeft => get_upLeft();

		private YckzJrjhEBQTzUonJUxNYhTtSSzF(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, vCSckBDWTefTIHAuQdyMtgfxPwdeb[] P_4)
			: base(P_0, P_1, ControllerTemplateElementType.Hat, P_4, vCSckBDWTefTIHAuQdyMtgfxPwdeb.BvnMuvMLgRfIZCTPDMyDOgUCkiuSA(P_0, P_1, P_2, P_3))
		{
			if (P_4.Length != 8)
			{
				throw new ArgumentException("elements.Length must be " + 8);
			}
		}

		internal YckzJrjhEBQTzUonJUxNYhTtSSzF(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, dPNudSCSIZEEYyzhsbwFYmHFxnIP P_4, dPNudSCSIZEEYyzhsbwFYmHFxnIP P_5, dPNudSCSIZEEYyzhsbwFYmHFxnIP P_6, dPNudSCSIZEEYyzhsbwFYmHFxnIP P_7, dPNudSCSIZEEYyzhsbwFYmHFxnIP P_8, dPNudSCSIZEEYyzhsbwFYmHFxnIP P_9, dPNudSCSIZEEYyzhsbwFYmHFxnIP P_10, dPNudSCSIZEEYyzhsbwFYmHFxnIP P_11)
			: this(P_0, P_1, P_2, P_3, new vCSckBDWTefTIHAuQdyMtgfxPwdeb[8] { P_4, P_5, P_6, P_7, P_8, P_9, P_10, P_11 })
		{
		}

		public Vector2 get_value()
		{
			if (ReInput._id != OHlHwXwyfreIswnUvPMrEwLWiLWD)
			{
				ReInput.CheckInitialized(OHlHwXwyfreIswnUvPMrEwLWiLWD);
				return Vector2.zero;
			}
			Vector2 result = default;
			result.y += ((dPNudSCSIZEEYyzhsbwFYmHFxnIP)uyYgOXTBypkgjXAiXShUQiNtdMrHA[0]).NzPxNtkThgEYuwsAMNDvVlKzBCJw();
			result.x += ((dPNudSCSIZEEYyzhsbwFYmHFxnIP)uyYgOXTBypkgjXAiXShUQiNtdMrHA[2]).NzPxNtkThgEYuwsAMNDvVlKzBCJw();
			result.y -= ((dPNudSCSIZEEYyzhsbwFYmHFxnIP)uyYgOXTBypkgjXAiXShUQiNtdMrHA[4]).NzPxNtkThgEYuwsAMNDvVlKzBCJw();
			result.x -= ((dPNudSCSIZEEYyzhsbwFYmHFxnIP)uyYgOXTBypkgjXAiXShUQiNtdMrHA[6]).NzPxNtkThgEYuwsAMNDvVlKzBCJw();
			float num = ((dPNudSCSIZEEYyzhsbwFYmHFxnIP)uyYgOXTBypkgjXAiXShUQiNtdMrHA[1]).NzPxNtkThgEYuwsAMNDvVlKzBCJw();
			float num2 = ((dPNudSCSIZEEYyzhsbwFYmHFxnIP)uyYgOXTBypkgjXAiXShUQiNtdMrHA[3]).NzPxNtkThgEYuwsAMNDvVlKzBCJw();
			float num3 = ((dPNudSCSIZEEYyzhsbwFYmHFxnIP)uyYgOXTBypkgjXAiXShUQiNtdMrHA[5]).NzPxNtkThgEYuwsAMNDvVlKzBCJw();
			float num4 = ((dPNudSCSIZEEYyzhsbwFYmHFxnIP)uyYgOXTBypkgjXAiXShUQiNtdMrHA[7]).NzPxNtkThgEYuwsAMNDvVlKzBCJw();
			result.x += num + num2 - num3 - num4;
			result.y += num + num4 - num2 - num3;
			result.x = MathTools.Clamp(result.x, -1f, 1f);
			result.y = MathTools.Clamp(result.y, -1f, 1f);
			return result;
		}

		public Vector2 get_valuePrev()
		{
			if (ReInput._id != OHlHwXwyfreIswnUvPMrEwLWiLWD)
			{
				ReInput.CheckInitialized(OHlHwXwyfreIswnUvPMrEwLWiLWD);
				return Vector2.zero;
			}
			Vector2 result = default;
			result.y += ((dPNudSCSIZEEYyzhsbwFYmHFxnIP)uyYgOXTBypkgjXAiXShUQiNtdMrHA[0]).cuFPToOlLJGLtBIZoiinXFMEWRIB();
			result.x += ((dPNudSCSIZEEYyzhsbwFYmHFxnIP)uyYgOXTBypkgjXAiXShUQiNtdMrHA[2]).cuFPToOlLJGLtBIZoiinXFMEWRIB();
			result.y -= ((dPNudSCSIZEEYyzhsbwFYmHFxnIP)uyYgOXTBypkgjXAiXShUQiNtdMrHA[4]).cuFPToOlLJGLtBIZoiinXFMEWRIB();
			result.x -= ((dPNudSCSIZEEYyzhsbwFYmHFxnIP)uyYgOXTBypkgjXAiXShUQiNtdMrHA[6]).cuFPToOlLJGLtBIZoiinXFMEWRIB();
			float num = ((dPNudSCSIZEEYyzhsbwFYmHFxnIP)uyYgOXTBypkgjXAiXShUQiNtdMrHA[1]).cuFPToOlLJGLtBIZoiinXFMEWRIB();
			float num2 = ((dPNudSCSIZEEYyzhsbwFYmHFxnIP)uyYgOXTBypkgjXAiXShUQiNtdMrHA[3]).cuFPToOlLJGLtBIZoiinXFMEWRIB();
			float num3 = ((dPNudSCSIZEEYyzhsbwFYmHFxnIP)uyYgOXTBypkgjXAiXShUQiNtdMrHA[5]).cuFPToOlLJGLtBIZoiinXFMEWRIB();
			float num4 = ((dPNudSCSIZEEYyzhsbwFYmHFxnIP)uyYgOXTBypkgjXAiXShUQiNtdMrHA[7]).cuFPToOlLJGLtBIZoiinXFMEWRIB();
			result.x += num + num2 - num3 - num4;
			result.y += num + num4 - num2 - num3;
			result.x = MathTools.Clamp(result.x, -1f, 1f);
			result.y = MathTools.Clamp(result.y, -1f, 1f);
			return result;
		}

		public IControllerTemplateButton get_up()
		{
			if (ReInput._id != OHlHwXwyfreIswnUvPMrEwLWiLWD)
			{
				ReInput.CheckInitialized(OHlHwXwyfreIswnUvPMrEwLWiLWD);
				return null;
			}
			return (IControllerTemplateButton)uyYgOXTBypkgjXAiXShUQiNtdMrHA[0];
		}

		public IControllerTemplateButton get_upRight()
		{
			if (ReInput._id != OHlHwXwyfreIswnUvPMrEwLWiLWD)
			{
				ReInput.CheckInitialized(OHlHwXwyfreIswnUvPMrEwLWiLWD);
				return null;
			}
			return (IControllerTemplateButton)uyYgOXTBypkgjXAiXShUQiNtdMrHA[1];
		}

		public IControllerTemplateButton get_right()
		{
			if (ReInput._id != OHlHwXwyfreIswnUvPMrEwLWiLWD)
			{
				ReInput.CheckInitialized(OHlHwXwyfreIswnUvPMrEwLWiLWD);
				return null;
			}
			return (IControllerTemplateButton)uyYgOXTBypkgjXAiXShUQiNtdMrHA[2];
		}

		public IControllerTemplateButton get_downRight()
		{
			if (ReInput._id != OHlHwXwyfreIswnUvPMrEwLWiLWD)
			{
				ReInput.CheckInitialized(OHlHwXwyfreIswnUvPMrEwLWiLWD);
				return null;
			}
			return (IControllerTemplateButton)uyYgOXTBypkgjXAiXShUQiNtdMrHA[3];
		}

		public IControllerTemplateButton get_down()
		{
			if (ReInput._id != OHlHwXwyfreIswnUvPMrEwLWiLWD)
			{
				ReInput.CheckInitialized(OHlHwXwyfreIswnUvPMrEwLWiLWD);
				return null;
			}
			return (IControllerTemplateButton)uyYgOXTBypkgjXAiXShUQiNtdMrHA[4];
		}

		public IControllerTemplateButton get_downLeft()
		{
			if (ReInput._id != OHlHwXwyfreIswnUvPMrEwLWiLWD)
			{
				ReInput.CheckInitialized(OHlHwXwyfreIswnUvPMrEwLWiLWD);
				return null;
			}
			return (IControllerTemplateButton)uyYgOXTBypkgjXAiXShUQiNtdMrHA[5];
		}

		public IControllerTemplateButton get_left()
		{
			if (ReInput._id != OHlHwXwyfreIswnUvPMrEwLWiLWD)
			{
				ReInput.CheckInitialized(OHlHwXwyfreIswnUvPMrEwLWiLWD);
				return null;
			}
			return (IControllerTemplateButton)uyYgOXTBypkgjXAiXShUQiNtdMrHA[6];
		}

		public IControllerTemplateButton get_upLeft()
		{
			if (ReInput._id != OHlHwXwyfreIswnUvPMrEwLWiLWD)
			{
				ReInput.CheckInitialized(OHlHwXwyfreIswnUvPMrEwLWiLWD);
				return null;
			}
			return (IControllerTemplateButton)uyYgOXTBypkgjXAiXShUQiNtdMrHA[7];
		}
	}

	internal sealed class OnppmIhfzYiXeqLtscnTcGOzNAIs : tYSTuJVgrpnDhvSLkSrhWHnsvTmL, IControllerTemplateYoke, IControllerTemplateElement
	{
		private const int JOetLxhtZudwDUVNFeXIeeyjdBEIA = 2;

		IControllerTemplateAxis IControllerTemplateYoke.rotation => get_rotation();

		IControllerTemplateAxis IControllerTemplateYoke.pushPull => get_pushPull();

		private OnppmIhfzYiXeqLtscnTcGOzNAIs(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, vCSckBDWTefTIHAuQdyMtgfxPwdeb[] P_4)
			: base(P_0, P_1, ControllerTemplateElementType.Yoke, P_4, vCSckBDWTefTIHAuQdyMtgfxPwdeb.BvnMuvMLgRfIZCTPDMyDOgUCkiuSA(P_0, P_1, P_2, P_3))
		{
		}

		internal OnppmIhfzYiXeqLtscnTcGOzNAIs(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, dPNudSCSIZEEYyzhsbwFYmHFxnIP P_4, dPNudSCSIZEEYyzhsbwFYmHFxnIP P_5)
			: this(P_0, P_1, P_2, P_3, new vCSckBDWTefTIHAuQdyMtgfxPwdeb[2] { P_4, P_5 })
		{
		}

		public IControllerTemplateAxis get_rotation()
		{
			if (ReInput._id != OHlHwXwyfreIswnUvPMrEwLWiLWD)
			{
				ReInput.CheckInitialized(OHlHwXwyfreIswnUvPMrEwLWiLWD);
				return null;
			}
			return (IControllerTemplateAxis)uyYgOXTBypkgjXAiXShUQiNtdMrHA[0];
		}

		public IControllerTemplateAxis get_pushPull()
		{
			if (ReInput._id != OHlHwXwyfreIswnUvPMrEwLWiLWD)
			{
				ReInput.CheckInitialized(OHlHwXwyfreIswnUvPMrEwLWiLWD);
				return null;
			}
			return (IControllerTemplateAxis)uyYgOXTBypkgjXAiXShUQiNtdMrHA[1];
		}
	}

	internal sealed class aGiUJBXoMxyAubSQgkIUekePbdXg : ZJwCcwWuPrhMAiJCDAofFYIfHJVsB, IControllerTemplateStick6D, IControllerTemplateElement
	{
		private const int xoCDWHYHmvgeDwLCYzlXfaaNSGnM = 6;

		private aGiUJBXoMxyAubSQgkIUekePbdXg(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, vCSckBDWTefTIHAuQdyMtgfxPwdeb[] P_4)
			: base(P_0, P_1, ControllerTemplateElementType.Stick6D, P_4, vCSckBDWTefTIHAuQdyMtgfxPwdeb.BvnMuvMLgRfIZCTPDMyDOgUCkiuSA(P_0, P_1, P_2, P_3))
		{
		}

		internal aGiUJBXoMxyAubSQgkIUekePbdXg(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, dPNudSCSIZEEYyzhsbwFYmHFxnIP P_4, dPNudSCSIZEEYyzhsbwFYmHFxnIP P_5, dPNudSCSIZEEYyzhsbwFYmHFxnIP P_6, dPNudSCSIZEEYyzhsbwFYmHFxnIP P_7, dPNudSCSIZEEYyzhsbwFYmHFxnIP P_8, dPNudSCSIZEEYyzhsbwFYmHFxnIP P_9)
			: this(P_0, P_1, P_2, P_3, new vCSckBDWTefTIHAuQdyMtgfxPwdeb[6] { P_4, P_5, P_6, P_7, P_8, P_9 })
		{
		}
	}

	internal class CiSbSfhgauKBAosHqvPypWbhRysEA
	{
		public readonly Controller.Element FzVDVkSKSNvwUKnEwGKwZvpOGapL;

		public readonly IControllerElementTarget GPgFzeHFohBcucHdqqwEQCgPFnqUA;

		public bool AuntwDlLwUZjjjmEeIgNEIWyzVzg => fSbYrkjGCUUfQQzxlxGLgPpRVmgC();

		public bool McOleYHcJkneBGMQYhUfUkFICuty => ZZtCcRxcjZwYrnxbsMKyGUnDbdID();

		public bool nEzBuFJKqtnOyGElbYjSnDBhNUvj => uuVtTjRfYuGBKaSejiOHzefBmaun();

		public bool ArwkNTxSLMdskGlqiOtbGYWpuDWr => wZBpNCbaAtvoQSNKomdvazNLpgRq();

		public float KNXlOKgTyHgMdhWmgfpzYeFazVBY => oOlGqJTAGplVKSfpauIiHUnZworG();

		public float cGDjFfWEyrppPQlzbzioWSobNbvJ => PvZHNcXWSiXsDVOQKgaszvlFSWED();

		public CiSbSfhgauKBAosHqvPypWbhRysEA(IControllerElementTarget P_0, Controller.Element P_1)
		{
			FzVDVkSKSNvwUKnEwGKwZvpOGapL = P_1;
			GPgFzeHFohBcucHdqqwEQCgPFnqUA = P_0;
		}

		public bool fSbYrkjGCUUfQQzxlxGLgPpRVmgC()
		{
			if (FzVDVkSKSNvwUKnEwGKwZvpOGapL == null)
			{
				return false;
			}
			switch (FzVDVkSKSNvwUKnEwGKwZvpOGapL.type)
			{
			case ControllerElementType.Button:
				return (FzVDVkSKSNvwUKnEwGKwZvpOGapL as Controller.Button).value;
			case ControllerElementType.Axis:
			{
				float value = (FzVDVkSKSNvwUKnEwGKwZvpOGapL as Controller.Axis).value;
				switch (GPgFzeHFohBcucHdqqwEQCgPFnqUA.axisRange)
				{
				case AxisRange.Full:
					if (value > 0.01f)
					{
						return true;
					}
					if (value < -0.01f)
					{
						return true;
					}
					break;
				case AxisRange.Positive:
					if (value > 0.01f)
					{
						return true;
					}
					break;
				case AxisRange.Negative:
					if (value < -0.01f)
					{
						return true;
					}
					break;
				}
				break;
			}
			}
			return false;
		}

		public bool ZZtCcRxcjZwYrnxbsMKyGUnDbdID()
		{
			if (FzVDVkSKSNvwUKnEwGKwZvpOGapL == null)
			{
				return false;
			}
			switch (FzVDVkSKSNvwUKnEwGKwZvpOGapL.type)
			{
			case ControllerElementType.Button:
				return (FzVDVkSKSNvwUKnEwGKwZvpOGapL as Controller.Button).valuePrev;
			case ControllerElementType.Axis:
			{
				float valuePrev = (FzVDVkSKSNvwUKnEwGKwZvpOGapL as Controller.Axis).valuePrev;
				switch (GPgFzeHFohBcucHdqqwEQCgPFnqUA.axisRange)
				{
				case AxisRange.Full:
					if (valuePrev > 0.01f)
					{
						return true;
					}
					if (valuePrev < -0.01f)
					{
						return true;
					}
					break;
				case AxisRange.Positive:
					if (valuePrev > 0.01f)
					{
						return true;
					}
					break;
				case AxisRange.Negative:
					if (valuePrev < -0.01f)
					{
						return true;
					}
					break;
				}
				break;
			}
			}
			return false;
		}

		public bool uuVtTjRfYuGBKaSejiOHzefBmaun()
		{
			if (FzVDVkSKSNvwUKnEwGKwZvpOGapL == null)
			{
				return false;
			}
			switch (FzVDVkSKSNvwUKnEwGKwZvpOGapL.type)
			{
			case ControllerElementType.Button:
				return (FzVDVkSKSNvwUKnEwGKwZvpOGapL as Controller.Button).justPressed;
			case ControllerElementType.Axis:
				if (MathTools.Abs(oOlGqJTAGplVKSfpauIiHUnZworG()) > 0.01f && MathTools.Abs(PvZHNcXWSiXsDVOQKgaszvlFSWED()) <= 0.01f)
				{
					return true;
				}
				break;
			}
			return false;
		}

		public bool wZBpNCbaAtvoQSNKomdvazNLpgRq()
		{
			if (FzVDVkSKSNvwUKnEwGKwZvpOGapL == null)
			{
				return false;
			}
			switch (FzVDVkSKSNvwUKnEwGKwZvpOGapL.type)
			{
			case ControllerElementType.Button:
				return (FzVDVkSKSNvwUKnEwGKwZvpOGapL as Controller.Button).justReleased;
			case ControllerElementType.Axis:
				if (MathTools.Abs(oOlGqJTAGplVKSfpauIiHUnZworG()) <= 0.01f && MathTools.Abs(PvZHNcXWSiXsDVOQKgaszvlFSWED()) > 0.01f)
				{
					return true;
				}
				break;
			}
			return false;
		}

		public float oOlGqJTAGplVKSfpauIiHUnZworG()
		{
			if (FzVDVkSKSNvwUKnEwGKwZvpOGapL == null)
			{
				return 0f;
			}
			switch (FzVDVkSKSNvwUKnEwGKwZvpOGapL.type)
			{
			case ControllerElementType.Button:
				if (!(FzVDVkSKSNvwUKnEwGKwZvpOGapL as Controller.Button).value)
				{
					return 0f;
				}
				return 1f;
			case ControllerElementType.Axis:
			{
				float value = (FzVDVkSKSNvwUKnEwGKwZvpOGapL as Controller.Axis).value;
				switch (GPgFzeHFohBcucHdqqwEQCgPFnqUA.axisRange)
				{
				case AxisRange.Full:
					return value;
				case AxisRange.Positive:
					if (value > 0f)
					{
						return value;
					}
					break;
				case AxisRange.Negative:
					if (value < 0f)
					{
						return value;
					}
					break;
				}
				break;
			}
			}
			return 0f;
		}

		public float PvZHNcXWSiXsDVOQKgaszvlFSWED()
		{
			if (FzVDVkSKSNvwUKnEwGKwZvpOGapL == null)
			{
				return 0f;
			}
			switch (FzVDVkSKSNvwUKnEwGKwZvpOGapL.type)
			{
			case ControllerElementType.Button:
				if (!(FzVDVkSKSNvwUKnEwGKwZvpOGapL as Controller.Button).valuePrev)
				{
					return 0f;
				}
				return 1f;
			case ControllerElementType.Axis:
			{
				float valuePrev = (FzVDVkSKSNvwUKnEwGKwZvpOGapL as Controller.Axis).valuePrev;
				switch (GPgFzeHFohBcucHdqqwEQCgPFnqUA.axisRange)
				{
				case AxisRange.Full:
					return valuePrev;
				case AxisRange.Positive:
					if (valuePrev > 0f)
					{
						return valuePrev;
					}
					break;
				case AxisRange.Negative:
					if (valuePrev < 0f)
					{
						return valuePrev;
					}
					break;
				}
				break;
			}
			}
			return 0f;
		}

		public static CiSbSfhgauKBAosHqvPypWbhRysEA jppzvWBMpuhCGosZHgKwiPZSLzfK()
		{
			return new CiSbSfhgauKBAosHqvPypWbhRysEA(edomyHoabKkWzxLwelGsLkZrDlzw.mHYNZIULtvOBtTVRcToMsSDSvYEJ(), null);
		}
	}

	internal class sMQxzzTcyzGuaGuucQpiGSFNjmqib
	{
		public readonly Controller yaqFyJcqxGYTfTMqLcbDiSFkkQKkB;

		public readonly IHardwareControllerTemplateMap_Internal HLajHbinBbIuounFoEQLqYPsoAH;

		public sMQxzzTcyzGuaGuucQpiGSFNjmqib(Controller P_0, IHardwareControllerTemplateMap_Internal P_1)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("controller");
			}
			if (P_1 == null)
			{
				throw new ArgumentNullException("templateMap");
			}
			yaqFyJcqxGYTfTMqLcbDiSFkkQKkB = P_0;
			HLajHbinBbIuounFoEQLqYPsoAH = P_1;
		}
	}

	private sealed class XPIXCvEWlHzEaVUSYOrktDWScXoe
	{
		[Serializable]
		private sealed class LcczUSmVHGNsbRMOhiiTKJuHDAAk
		{
			public static readonly LcczUSmVHGNsbRMOhiiTKJuHDAAk _003C_003E9 = new LcczUSmVHGNsbRMOhiiTKJuHDAAk();

			public static Func<fDxEaPJRzBYVTBJLRZuBiXQfXsyKA, fDxEaPJRzBYVTBJLRZuBiXQfXsyKA, bool> _003C_003E9__4_0;

			internal bool dfdTovOuGeIxlcxrdPfbbFiDlZnp(fDxEaPJRzBYVTBJLRZuBiXQfXsyKA P_0, fDxEaPJRzBYVTBJLRZuBiXQfXsyKA P_1)
			{
				if (P_0 == null || P_1 == null)
				{
					return false;
				}
				return P_0.jegMjpuXXGxKUGMrDuXUkQXMmGTF(P_1, false);
			}
		}

		private static XPIXCvEWlHzEaVUSYOrktDWScXoe JszleCnjPuLAZxuRORESZGjPtxmo;

		private readonly global::lVvaRWFpPRDdIEUiIKNGBOwxeQgw<fDxEaPJRzBYVTBJLRZuBiXQfXsyKA> EPOmtWjetbZRLfYVoNnQWOcOzvLB;

		private static XPIXCvEWlHzEaVUSYOrktDWScXoe PkdXAMoLkWDTUVjgvnyvHPNePZzr => xDVIIQfOVVMyINMFWrZshVLdgFGcb();

		private static XPIXCvEWlHzEaVUSYOrktDWScXoe xDVIIQfOVVMyINMFWrZshVLdgFGcb()
		{
			if (JszleCnjPuLAZxuRORESZGjPtxmo != null)
			{
				return JszleCnjPuLAZxuRORESZGjPtxmo;
			}
			JszleCnjPuLAZxuRORESZGjPtxmo = new XPIXCvEWlHzEaVUSYOrktDWScXoe();
			JszleCnjPuLAZxuRORESZGjPtxmo.qMZOFmHlBrpaMDSubdoupGxRdgNe();
			return JszleCnjPuLAZxuRORESZGjPtxmo;
		}

		private XPIXCvEWlHzEaVUSYOrktDWScXoe()
		{
			EPOmtWjetbZRLfYVoNnQWOcOzvLB = new global::lVvaRWFpPRDdIEUiIKNGBOwxeQgw<fDxEaPJRzBYVTBJLRZuBiXQfXsyKA>(LcczUSmVHGNsbRMOhiiTKJuHDAAk._003C_003E9.dfdTovOuGeIxlcxrdPfbbFiDlZnp);
		}

		private void qMZOFmHlBrpaMDSubdoupGxRdgNe()
		{
			ReInput.ShutDownEvent += JszleCnjPuLAZxuRORESZGjPtxmo.TxMIEnRrQxIkyUIDLsfnenBDjHtR;
		}

		private void TxMIEnRrQxIkyUIDLsfnenBDjHtR()
		{
			if (JszleCnjPuLAZxuRORESZGjPtxmo == this)
			{
				JszleCnjPuLAZxuRORESZGjPtxmo = null;
			}
			ReInput.ShutDownEvent -= TxMIEnRrQxIkyUIDLsfnenBDjHtR;
		}

		public static fDxEaPJRzBYVTBJLRZuBiXQfXsyKA lZiHQAskUcfYVbVnzAgaWKkbvxBz(fDxEaPJRzBYVTBJLRZuBiXQfXsyKA P_0)
		{
			Bytes20 bytes = ((P_0.EdMrySDrbXqgjQAsHkxdSjxEQmVq() is SKruZTfSnctDlegjlMOpeHZBhOtA sKruZTfSnctDlegjlMOpeHZBhOtA) ? sKruZTfSnctDlegjlMOpeHZBhOtA.yjEEoGnRCQmYrUhVNVDeuOjlULWL().hash : default(Bytes20));
			return xDVIIQfOVVMyINMFWrZshVLdgFGcb().EPOmtWjetbZRLfYVoNnQWOcOzvLB.KfGfCFQYIBUUThUqDQAwAPjENAiG(bytes, P_0);
		}

		public static bool baoWxWMkxWNcfKAIXjdhGOSqcsebA(fDxEaPJRzBYVTBJLRZuBiXQfXsyKA P_0, out fDxEaPJRzBYVTBJLRZuBiXQfXsyKA P_1)
		{
			Bytes20 bytes = ((P_0.EdMrySDrbXqgjQAsHkxdSjxEQmVq() is SKruZTfSnctDlegjlMOpeHZBhOtA sKruZTfSnctDlegjlMOpeHZBhOtA) ? sKruZTfSnctDlegjlMOpeHZBhOtA.yjEEoGnRCQmYrUhVNVDeuOjlULWL().hash : default(Bytes20));
			return xDVIIQfOVVMyINMFWrZshVLdgFGcb().EPOmtWjetbZRLfYVoNnQWOcOzvLB.elHbnypVRYAnmLgDxxneJfNHjcbfA(bytes, P_0, out P_1);
		}

		public static void FzuDIXepPnMycBGJduWzMcgaGELjb(fDxEaPJRzBYVTBJLRZuBiXQfXsyKA P_0)
		{
			Bytes20 bytes = ((P_0.EdMrySDrbXqgjQAsHkxdSjxEQmVq() is SKruZTfSnctDlegjlMOpeHZBhOtA sKruZTfSnctDlegjlMOpeHZBhOtA) ? sKruZTfSnctDlegjlMOpeHZBhOtA.yjEEoGnRCQmYrUhVNVDeuOjlULWL().hash : default(Bytes20));
			xDVIIQfOVVMyINMFWrZshVLdgFGcb().EPOmtWjetbZRLfYVoNnQWOcOzvLB.RHHrLiuKFpjNWsGCNIVkgVcHmmlzA(bytes, P_0);
		}
	}

	private const string WLSgylFonoqTVQkNetJajDfrOtuHA = "controller/template";

	private string gpIQMPpusghFdEZxKBZSIgOeDbtF;

	private string qfPBxBnjaNjayOjmDciiGwYjaEnA;

	private int TNHxlTbeVZXyywLAYONNmFPVjmVy;

	private readonly Guid KYdeZpcCWjRiRAMFSicssPbyoUrab;

	private readonly DeviceLocalizationInfo NuObjPjOUlLJbYLesxnuNMcDXyudA;

	private readonly Controller IKjnnbSpgsmFItZfbZwBXWawgIAF;

	private readonly ADictionary<int, IControllerTemplateElement> kMOXsVNNpxuVaRSUpkRXusoWptQT;

	private readonly ADictionary<string, IControllerTemplateElement> NqtNaNOBnBqHjvlcwRNeWnhPUKhK;

	private IControllerTemplateElement[] EtjMknpmGGlpcYDcuZaXduTJZrYg;

	private ReadOnlyCollection<IControllerTemplateElement> oHlsRwEAEzJhavnyAoUKZUnHvNZc;

	private readonly IrUdJNwpbYbfRTthWbFTKoJUwPss mJXGtLcyjStZXhtTKHJCcrkycHhxA;

	private readonly int fvrvnzDPUhVAqIZwUGvIEDtdVqan;

	internal DeviceLocalizationInfo xiMoyCGTiCfopcyUTtSFtSoyuUYf => AcvaHBMPSDJBYoLJqgMzcjguJrCL();

	DeviceLocalizationInfo IControllerTemplate_Internal.deviceLocalizationInfo => NuObjPjOUlLJbYLesxnuNMcDXyudA;

	Controller IControllerTemplate.controller
	{
		get
		{
			if (ReInput._id != fvrvnzDPUhVAqIZwUGvIEDtdVqan)
			{
				ReInput.CheckInitialized(fvrvnzDPUhVAqIZwUGvIEDtdVqan);
				return null;
			}
			return IKjnnbSpgsmFItZfbZwBXWawgIAF;
		}
	}

	string IControllerTemplate.name
	{
		get
		{
			if (ReInput._id != fvrvnzDPUhVAqIZwUGvIEDtdVqan)
			{
				ReInput.CheckInitialized(fvrvnzDPUhVAqIZwUGvIEDtdVqan);
				return null;
			}
			if (!LocalizationManager.isEnabled)
			{
				return gpIQMPpusghFdEZxKBZSIgOeDbtF;
			}
			return mJXGtLcyjStZXhtTKHJCcrkycHhxA.aLsidTWLDaQPOPmyxGbWHeMTGfoEA();
		}
	}

	Guid IControllerTemplate.typeGuid
	{
		get
		{
			if (ReInput._id != fvrvnzDPUhVAqIZwUGvIEDtdVqan)
			{
				ReInput.CheckInitialized(fvrvnzDPUhVAqIZwUGvIEDtdVqan);
				return Guid.Empty;
			}
			return KYdeZpcCWjRiRAMFSicssPbyoUrab;
		}
	}

	IList<IControllerTemplateElement> IControllerTemplate.elements
	{
		get
		{
			if (ReInput._id != fvrvnzDPUhVAqIZwUGvIEDtdVqan)
			{
				ReInput.CheckInitialized(fvrvnzDPUhVAqIZwUGvIEDtdVqan);
				return null;
			}
			return oHlsRwEAEzJhavnyAoUKZUnHvNZc;
		}
	}

	int IControllerTemplate.elementCount
	{
		get
		{
			if (ReInput._id != fvrvnzDPUhVAqIZwUGvIEDtdVqan)
			{
				ReInput.CheckInitialized(fvrvnzDPUhVAqIZwUGvIEDtdVqan);
				return 0;
			}
			return EtjMknpmGGlpcYDcuZaXduTJZrYg.Length;
		}
	}

	string JPyUCjMynlgXcSTGrAuSOGxEMeWJ.keyCategory => Rewired_002EInternal_002ELocalization_002EINameLocalizerSource_002Eget_keyCategory();

	string JPyUCjMynlgXcSTGrAuSOGxEMeWJ.scriptingName => Rewired_002EInternal_002ELocalization_002EINameLocalizerSource_002Eget_scriptingName();

	string JPyUCjMynlgXcSTGrAuSOGxEMeWJ.nonLocalizedDescriptiveName
	{
		get
		{
			return Rewired_002EInternal_002ELocalization_002EINameLocalizerSource_002Eget_nonLocalizedDescriptiveName();
		}
		set
		{
			Rewired_002EInternal_002ELocalization_002EINameLocalizerSource_002Eset_nonLocalizedDescriptiveName(value);
		}
	}

	string JPyUCjMynlgXcSTGrAuSOGxEMeWJ.key => Rewired_002EInternal_002ELocalization_002EINameLocalizerSource_002Eget_key();

	int JPyUCjMynlgXcSTGrAuSOGxEMeWJ.autoGeneratedValueFlags
	{
		get
		{
			return Rewired_002EInternal_002ELocalization_002EINameLocalizerSource_002Eget_autoGeneratedValueFlags();
		}
		set
		{
			Rewired_002EInternal_002ELocalization_002EINameLocalizerSource_002Eset_autoGeneratedValueFlags(value);
		}
	}

	protected ControllerTemplate(object P_0)
		: this((sMQxzzTcyzGuaGuucQpiGSFNjmqib)P_0)
	{
	}

	private ControllerTemplate(sMQxzzTcyzGuaGuucQpiGSFNjmqib P_0)
	{
		if (P_0 == null)
		{
			throw new ArgumentNullException("initializer");
		}
		if (P_0.yaqFyJcqxGYTfTMqLcbDiSFkkQKkB == null)
		{
			throw new ArgumentNullException("initializer.controller");
		}
		if (P_0.HLajHbinBbIuounFoEQLqYPsoAH == null)
		{
			throw new ArgumentNullException("initializer.templateMap");
		}
		fvrvnzDPUhVAqIZwUGvIEDtdVqan = ReInput.id;
		IKjnnbSpgsmFItZfbZwBXWawgIAF = P_0.yaqFyJcqxGYTfTMqLcbDiSFkkQKkB;
		IHardwareControllerTemplateMap_Internal hLajHbinBbIuounFoEQLqYPsoAH = P_0.HLajHbinBbIuounFoEQLqYPsoAH;
		gpIQMPpusghFdEZxKBZSIgOeDbtF = hLajHbinBbIuounFoEQLqYPsoAH.name;
		qfPBxBnjaNjayOjmDciiGwYjaEnA = hLajHbinBbIuounFoEQLqYPsoAH.typeKey;
		KYdeZpcCWjRiRAMFSicssPbyoUrab = hLajHbinBbIuounFoEQLqYPsoAH.typeGuid;
		NuObjPjOUlLJbYLesxnuNMcDXyudA = new DeviceLocalizationInfo(IKjnnbSpgsmFItZfbZwBXWawgIAF.type, true, KYdeZpcCWjRiRAMFSicssPbyoUrab, new List<string> { hLajHbinBbIuounFoEQLqYPsoAH.typeKey }, null);
		NuObjPjOUlLJbYLesxnuNMcDXyudA.FinishRuntimeSetup();
		mJXGtLcyjStZXhtTKHJCcrkycHhxA = IrUdJNwpbYbfRTthWbFTKoJUwPss.egIgsRAtxYduPLAEXxfeJATQfeVg(this);
		int elementIdentifierCount = hLajHbinBbIuounFoEQLqYPsoAH.GetElementIdentifierCount();
		ADictionary<int, IControllerTemplateElement> aDictionary = new ADictionary<int, IControllerTemplateElement>();
		List<IControllerTemplateElement> list = new List<IControllerTemplateElement>();
		List<IControllerTemplateAxis> list2 = new List<IControllerTemplateAxis>();
		List<IControllerTemplateButton> list3 = new List<IControllerTemplateButton>();
		List<IControllerTemplateElement> list4 = new List<IControllerTemplateElement>();
		for (int i = 0; i < elementIdentifierCount; i++)
		{
			IControllerTemplateElementIdentifier templateElementIdentifier = hLajHbinBbIuounFoEQLqYPsoAH.GetTemplateElementIdentifier(i);
			if (templateElementIdentifier != null && InputTools.IsMappableType(templateElementIdentifier.elementType))
			{
				switch (templateElementIdentifier.elementType)
				{
				case ControllerTemplateElementType.Axis:
				{
					NxexmFcztmkjMTmmeibTdDSlWuxt nxexmFcztmkjMTmmeibTdDSlWuxt2 = hLajHbinBbIuounFoEQLqYPsoAH.GetAxisTarget(IKjnnbSpgsmFItZfbZwBXWawgIAF, templateElementIdentifier.id) ?? NxexmFcztmkjMTmmeibTdDSlWuxt.AwJyFZSwQefPsVvLcjELYDJqdsFB(ControllerTemplateElementType.Axis);
					EORxWzhjnxSHEOFrXHdOtmhKSPXU item2 = new EORxWzhjnxSHEOFrXHdOtmhKSPXU(this, templateElementIdentifier.id, templateElementIdentifier.nonLocalizedName, (!templateElementIdentifier.isNonLocalizedPositiveNameAutoGenerated) ? templateElementIdentifier.nonLocalizedPositiveName : string.Empty, (!templateElementIdentifier.isNonLocalizedNegativeNameAutoGenerated) ? templateElementIdentifier.nonLocalizedNegativeName : string.Empty, templateElementIdentifier.key, (!templateElementIdentifier.isPositiveKeyAutoGenerated) ? templateElementIdentifier.positiveKey : string.Empty, (!templateElementIdentifier.isNegativeKeyAutoGenerated) ? templateElementIdentifier.negativeKey : string.Empty, nxexmFcztmkjMTmmeibTdDSlWuxt2, ckQTsCDUUVCXpZtfBvQYzAemMvZc(IKjnnbSpgsmFItZfbZwBXWawgIAF, nxexmFcztmkjMTmmeibTdDSlWuxt2));
					list2.Add(item2);
					break;
				}
				case ControllerTemplateElementType.Button:
				{
					NxexmFcztmkjMTmmeibTdDSlWuxt nxexmFcztmkjMTmmeibTdDSlWuxt = hLajHbinBbIuounFoEQLqYPsoAH.GetButtonTarget(IKjnnbSpgsmFItZfbZwBXWawgIAF, templateElementIdentifier.id) ?? NxexmFcztmkjMTmmeibTdDSlWuxt.AwJyFZSwQefPsVvLcjELYDJqdsFB(ControllerTemplateElementType.Button);
					lSxoJayIKzvoXJqfGbfmKtxXqIGF item = new lSxoJayIKzvoXJqfGbfmKtxXqIGF(this, templateElementIdentifier.id, templateElementIdentifier.nonLocalizedName, (!templateElementIdentifier.isNonLocalizedPositiveNameAutoGenerated) ? templateElementIdentifier.nonLocalizedPositiveName : string.Empty, (!templateElementIdentifier.isNonLocalizedNegativeNameAutoGenerated) ? templateElementIdentifier.nonLocalizedNegativeName : string.Empty, templateElementIdentifier.key, (!templateElementIdentifier.isPositiveKeyAutoGenerated) ? templateElementIdentifier.positiveKey : string.Empty, (!templateElementIdentifier.isNegativeKeyAutoGenerated) ? templateElementIdentifier.negativeKey : string.Empty, nxexmFcztmkjMTmmeibTdDSlWuxt, xZQGYnzjBEsQgLRBoAtrcnlpiKVh(IKjnnbSpgsmFItZfbZwBXWawgIAF, nxexmFcztmkjMTmmeibTdDSlWuxt));
					list3.Add(item);
					break;
				}
				default:
					throw new NotImplementedException();
				}
			}
		}
		for (int j = 0; j < list2.Count; j++)
		{
			list.Add(list2[j]);
		}
		for (int k = 0; k < list3.Count; k++)
		{
			list.Add(list3[k]);
		}
		for (int l = 0; l < list.Count; l++)
		{
			aDictionary.Add(list[l].id, list[l]);
		}
		for (int m = 0; m < elementIdentifierCount; m++)
		{
			IControllerTemplateElementIdentifier templateElementIdentifier2 = hLajHbinBbIuounFoEQLqYPsoAH.GetTemplateElementIdentifier(m);
			if (templateElementIdentifier2 == null || InputTools.IsMappableType(templateElementIdentifier2.elementType))
			{
				continue;
			}
			IControllerTemplateMapSpecialElement_Internal specialTemplateElementByElementIdentifierId = hLajHbinBbIuounFoEQLqYPsoAH.GetSpecialTemplateElementByElementIdentifierId(templateElementIdentifier2.id);
			vCSckBDWTefTIHAuQdyMtgfxPwdeb vCSckBDWTefTIHAuQdyMtgfxPwdeb2;
			switch (templateElementIdentifier2.elementType)
			{
			case ControllerTemplateElementType.ThumbStick:
			{
				if (specialTemplateElementByElementIdentifierId == null)
				{
					Logger.LogError(templateElementIdentifier2.elementType.ToString() + " element missing for Element Identifier Id " + templateElementIdentifier2.id);
				}
				ControllerTemplateThumbStickMapping mapping5 = specialTemplateElementByElementIdentifierId.GetMapping<ControllerTemplateThumbStickMapping>();
				vCSckBDWTefTIHAuQdyMtgfxPwdeb2 = new UQJfqUhkNknnupBWUKieFeMFNrnNb(this, templateElementIdentifier2.id, templateElementIdentifier2.nonLocalizedName, templateElementIdentifier2.key, (mapping5 != null) ? ZQqgcUlsAYmjbswGcGCEICZWmqfI(this, aDictionary, mapping5.eid_axisX) : EORxWzhjnxSHEOFrXHdOtmhKSPXU.VVkGaaXHjJHrqubARBzSmYODNOCL(this), (mapping5 != null) ? ZQqgcUlsAYmjbswGcGCEICZWmqfI(this, aDictionary, mapping5.eid_axisY) : EORxWzhjnxSHEOFrXHdOtmhKSPXU.VVkGaaXHjJHrqubARBzSmYODNOCL(this), (mapping5 != null) ? zxUYjsPkWuphbwikswjnGzkwMVMR(this, aDictionary, mapping5.eid_button) : lSxoJayIKzvoXJqfGbfmKtxXqIGF.cSKcSMcdxoxvVekTGubjqXSztIpeA(this));
				break;
			}
			case ControllerTemplateElementType.DPad:
			{
				if (specialTemplateElementByElementIdentifierId == null)
				{
					Logger.LogError(templateElementIdentifier2.elementType.ToString() + " element missing for Element Identifier Id " + templateElementIdentifier2.id);
				}
				ControllerTemplateDPadMapping mapping3 = specialTemplateElementByElementIdentifierId.GetMapping<ControllerTemplateDPadMapping>();
				vCSckBDWTefTIHAuQdyMtgfxPwdeb2 = new oEoXqXJFkhUePHthqrBrvLAycBxM(this, templateElementIdentifier2.id, templateElementIdentifier2.nonLocalizedName, templateElementIdentifier2.key, (mapping3 != null) ? zxUYjsPkWuphbwikswjnGzkwMVMR(this, aDictionary, mapping3.eid_up) : lSxoJayIKzvoXJqfGbfmKtxXqIGF.cSKcSMcdxoxvVekTGubjqXSztIpeA(this), (mapping3 != null) ? zxUYjsPkWuphbwikswjnGzkwMVMR(this, aDictionary, mapping3.eid_right) : lSxoJayIKzvoXJqfGbfmKtxXqIGF.cSKcSMcdxoxvVekTGubjqXSztIpeA(this), (mapping3 != null) ? zxUYjsPkWuphbwikswjnGzkwMVMR(this, aDictionary, mapping3.eid_down) : lSxoJayIKzvoXJqfGbfmKtxXqIGF.cSKcSMcdxoxvVekTGubjqXSztIpeA(this), (mapping3 != null) ? zxUYjsPkWuphbwikswjnGzkwMVMR(this, aDictionary, mapping3.eid_left) : lSxoJayIKzvoXJqfGbfmKtxXqIGF.cSKcSMcdxoxvVekTGubjqXSztIpeA(this), (mapping3 != null) ? zxUYjsPkWuphbwikswjnGzkwMVMR(this, aDictionary, mapping3.eid_press) : lSxoJayIKzvoXJqfGbfmKtxXqIGF.cSKcSMcdxoxvVekTGubjqXSztIpeA(this));
				break;
			}
			case ControllerTemplateElementType.Stick:
			{
				if (specialTemplateElementByElementIdentifierId == null)
				{
					Logger.LogError(templateElementIdentifier2.elementType.ToString() + " element missing for Element Identifier Id " + templateElementIdentifier2.id);
				}
				ControllerTemplateStickMapping mapping2 = specialTemplateElementByElementIdentifierId.GetMapping<ControllerTemplateStickMapping>();
				vCSckBDWTefTIHAuQdyMtgfxPwdeb2 = new RwwLviKhqHfLUwdnvhRvHjvObsWbb(this, templateElementIdentifier2.id, templateElementIdentifier2.nonLocalizedName, templateElementIdentifier2.key, (mapping2 != null) ? ZQqgcUlsAYmjbswGcGCEICZWmqfI(this, aDictionary, mapping2.eid_axisX) : EORxWzhjnxSHEOFrXHdOtmhKSPXU.VVkGaaXHjJHrqubARBzSmYODNOCL(this), (mapping2 != null) ? ZQqgcUlsAYmjbswGcGCEICZWmqfI(this, aDictionary, mapping2.eid_axisY) : EORxWzhjnxSHEOFrXHdOtmhKSPXU.VVkGaaXHjJHrqubARBzSmYODNOCL(this), (mapping2 != null) ? ZQqgcUlsAYmjbswGcGCEICZWmqfI(this, aDictionary, mapping2.eid_axisZ) : EORxWzhjnxSHEOFrXHdOtmhKSPXU.VVkGaaXHjJHrqubARBzSmYODNOCL(this));
				break;
			}
			case ControllerTemplateElementType.Throttle:
			{
				if (specialTemplateElementByElementIdentifierId == null)
				{
					Logger.LogError(templateElementIdentifier2.elementType.ToString() + " element missing for Element Identifier Id " + templateElementIdentifier2.id);
				}
				ControllerTemplateThrottleMapping mapping6 = specialTemplateElementByElementIdentifierId.GetMapping<ControllerTemplateThrottleMapping>();
				vCSckBDWTefTIHAuQdyMtgfxPwdeb2 = new fDEnEdOvEvHxarlVCzWgwmFwyMVF(this, templateElementIdentifier2.id, templateElementIdentifier2.nonLocalizedName, templateElementIdentifier2.key, (mapping6 != null) ? ZQqgcUlsAYmjbswGcGCEICZWmqfI(this, aDictionary, mapping6.eid_axis) : EORxWzhjnxSHEOFrXHdOtmhKSPXU.VVkGaaXHjJHrqubARBzSmYODNOCL(this), (mapping6 != null) ? zxUYjsPkWuphbwikswjnGzkwMVMR(this, aDictionary, mapping6.eid_minDetent) : lSxoJayIKzvoXJqfGbfmKtxXqIGF.cSKcSMcdxoxvVekTGubjqXSztIpeA(this));
				break;
			}
			case ControllerTemplateElementType.Hat:
			{
				if (specialTemplateElementByElementIdentifierId == null)
				{
					Logger.LogError(templateElementIdentifier2.elementType.ToString() + " element missing for Element Identifier Id " + templateElementIdentifier2.id);
				}
				ControllerTemplateHatMapping mapping7 = specialTemplateElementByElementIdentifierId.GetMapping<ControllerTemplateHatMapping>();
				vCSckBDWTefTIHAuQdyMtgfxPwdeb2 = new YckzJrjhEBQTzUonJUxNYhTtSSzF(this, templateElementIdentifier2.id, templateElementIdentifier2.nonLocalizedName, templateElementIdentifier2.key, (mapping7 != null) ? zxUYjsPkWuphbwikswjnGzkwMVMR(this, aDictionary, mapping7.eid_up) : lSxoJayIKzvoXJqfGbfmKtxXqIGF.cSKcSMcdxoxvVekTGubjqXSztIpeA(this), (mapping7 != null) ? zxUYjsPkWuphbwikswjnGzkwMVMR(this, aDictionary, mapping7.eid_upRight) : lSxoJayIKzvoXJqfGbfmKtxXqIGF.cSKcSMcdxoxvVekTGubjqXSztIpeA(this), (mapping7 != null) ? zxUYjsPkWuphbwikswjnGzkwMVMR(this, aDictionary, mapping7.eid_right) : lSxoJayIKzvoXJqfGbfmKtxXqIGF.cSKcSMcdxoxvVekTGubjqXSztIpeA(this), (mapping7 != null) ? zxUYjsPkWuphbwikswjnGzkwMVMR(this, aDictionary, mapping7.eid_downRight) : lSxoJayIKzvoXJqfGbfmKtxXqIGF.cSKcSMcdxoxvVekTGubjqXSztIpeA(this), (mapping7 != null) ? zxUYjsPkWuphbwikswjnGzkwMVMR(this, aDictionary, mapping7.eid_down) : lSxoJayIKzvoXJqfGbfmKtxXqIGF.cSKcSMcdxoxvVekTGubjqXSztIpeA(this), (mapping7 != null) ? zxUYjsPkWuphbwikswjnGzkwMVMR(this, aDictionary, mapping7.eid_downLeft) : lSxoJayIKzvoXJqfGbfmKtxXqIGF.cSKcSMcdxoxvVekTGubjqXSztIpeA(this), (mapping7 != null) ? zxUYjsPkWuphbwikswjnGzkwMVMR(this, aDictionary, mapping7.eid_left) : lSxoJayIKzvoXJqfGbfmKtxXqIGF.cSKcSMcdxoxvVekTGubjqXSztIpeA(this), (mapping7 != null) ? zxUYjsPkWuphbwikswjnGzkwMVMR(this, aDictionary, mapping7.eid_upLeft) : lSxoJayIKzvoXJqfGbfmKtxXqIGF.cSKcSMcdxoxvVekTGubjqXSztIpeA(this));
				break;
			}
			case ControllerTemplateElementType.Yoke:
			{
				if (specialTemplateElementByElementIdentifierId == null)
				{
					Logger.LogError(templateElementIdentifier2.elementType.ToString() + " element missing for Element Identifier Id " + templateElementIdentifier2.id);
				}
				ControllerTemplateYokeMapping mapping4 = specialTemplateElementByElementIdentifierId.GetMapping<ControllerTemplateYokeMapping>();
				vCSckBDWTefTIHAuQdyMtgfxPwdeb2 = new OnppmIhfzYiXeqLtscnTcGOzNAIs(this, templateElementIdentifier2.id, templateElementIdentifier2.nonLocalizedName, templateElementIdentifier2.key, (mapping4 != null) ? ZQqgcUlsAYmjbswGcGCEICZWmqfI(this, aDictionary, mapping4.eid_axisX) : EORxWzhjnxSHEOFrXHdOtmhKSPXU.VVkGaaXHjJHrqubARBzSmYODNOCL(this), (mapping4 != null) ? ZQqgcUlsAYmjbswGcGCEICZWmqfI(this, aDictionary, mapping4.eid_axisZ) : EORxWzhjnxSHEOFrXHdOtmhKSPXU.VVkGaaXHjJHrqubARBzSmYODNOCL(this));
				break;
			}
			case ControllerTemplateElementType.Stick6D:
			{
				if (specialTemplateElementByElementIdentifierId == null)
				{
					Logger.LogError(templateElementIdentifier2.elementType.ToString() + " element missing for Element Identifier Id " + templateElementIdentifier2.id);
				}
				ControllerTemplateStick6DMapping mapping = specialTemplateElementByElementIdentifierId.GetMapping<ControllerTemplateStick6DMapping>();
				vCSckBDWTefTIHAuQdyMtgfxPwdeb2 = new aGiUJBXoMxyAubSQgkIUekePbdXg(this, templateElementIdentifier2.id, templateElementIdentifier2.nonLocalizedName, templateElementIdentifier2.key, (mapping != null) ? ZQqgcUlsAYmjbswGcGCEICZWmqfI(this, aDictionary, mapping.eid_positionX) : EORxWzhjnxSHEOFrXHdOtmhKSPXU.VVkGaaXHjJHrqubARBzSmYODNOCL(this), (mapping != null) ? ZQqgcUlsAYmjbswGcGCEICZWmqfI(this, aDictionary, mapping.eid_positionY) : EORxWzhjnxSHEOFrXHdOtmhKSPXU.VVkGaaXHjJHrqubARBzSmYODNOCL(this), (mapping != null) ? ZQqgcUlsAYmjbswGcGCEICZWmqfI(this, aDictionary, mapping.eid_positionZ) : EORxWzhjnxSHEOFrXHdOtmhKSPXU.VVkGaaXHjJHrqubARBzSmYODNOCL(this), (mapping != null) ? ZQqgcUlsAYmjbswGcGCEICZWmqfI(this, aDictionary, mapping.eid_rotationX) : EORxWzhjnxSHEOFrXHdOtmhKSPXU.VVkGaaXHjJHrqubARBzSmYODNOCL(this), (mapping != null) ? ZQqgcUlsAYmjbswGcGCEICZWmqfI(this, aDictionary, mapping.eid_rotationY) : EORxWzhjnxSHEOFrXHdOtmhKSPXU.VVkGaaXHjJHrqubARBzSmYODNOCL(this), (mapping != null) ? ZQqgcUlsAYmjbswGcGCEICZWmqfI(this, aDictionary, mapping.eid_rotationZ) : EORxWzhjnxSHEOFrXHdOtmhKSPXU.VVkGaaXHjJHrqubARBzSmYODNOCL(this));
				break;
			}
			default:
				throw new NotImplementedException();
			}
			if (vCSckBDWTefTIHAuQdyMtgfxPwdeb2 != null)
			{
				list4.Add(vCSckBDWTefTIHAuQdyMtgfxPwdeb2);
			}
		}
		for (int n = 0; n < list4.Count; n++)
		{
			list.Add(list4[n]);
			aDictionary.Add(list4[n].id, list4[n]);
		}
		EtjMknpmGGlpcYDcuZaXduTJZrYg = list.ToArray();
		kMOXsVNNpxuVaRSUpkRXusoWptQT = aDictionary;
		NqtNaNOBnBqHjvlcwRNeWnhPUKhK = new ADictionary<string, IControllerTemplateElement>();
		for (int num = 0; num < EtjMknpmGGlpcYDcuZaXduTJZrYg.Length; num++)
		{
			if (!(hLajHbinBbIuounFoEQLqYPsoAH.GetTemplateElementIdentifierById(EtjMknpmGGlpcYDcuZaXduTJZrYg[num].id) is IControllerTemplateElementIdentifier_Editor controllerTemplateElementIdentifier_Editor))
			{
				continue;
			}
			for (int num2 = 0; num2 < 2; num2++)
			{
				string text = ((num2 != 0) ? controllerTemplateElementIdentifier_Editor.alternateScriptingName : controllerTemplateElementIdentifier_Editor.scriptingName);
				if (!string.IsNullOrEmpty(text))
				{
					try
					{
						NqtNaNOBnBqHjvlcwRNeWnhPUKhK.Add(text, EtjMknpmGGlpcYDcuZaXduTJZrYg[num]);
					}
					catch
					{
						Logger.LogError("A duplicate Controller Template element scripting name (" + text + ") was found in template " + gpIQMPpusghFdEZxKBZSIgOeDbtF + ". This element should be renamed to a unique name.");
					}
				}
			}
		}
		oHlsRwEAEzJhavnyAoUKZUnHvNZc = new ReadOnlyCollection<IControllerTemplateElement>(EtjMknpmGGlpcYDcuZaXduTJZrYg);
	}

	protected IControllerTemplateElement GetElement(int id)
	{
		if (!kMOXsVNNpxuVaRSUpkRXusoWptQT.TryGetValue(id, out var value))
		{
			Logger.LogWarning("There is no element with the id \"" + id + "\" in the " + GetType().ToString() + ".");
		}
		return value;
	}

	protected T GetElement<T>(int id) where T : class, IControllerTemplateElement
	{
		return GetElement(id) as T;
	}

	internal DeviceLocalizationInfo AcvaHBMPSDJBYoLJqgMzcjguJrCL()
	{
		return NuObjPjOUlLJbYLesxnuNMcDXyudA;
	}

	IControllerTemplateElement IControllerTemplate.GetElement(int id)
	{
		if (ReInput._id != fvrvnzDPUhVAqIZwUGvIEDtdVqan)
		{
			ReInput.CheckInitialized(fvrvnzDPUhVAqIZwUGvIEDtdVqan);
			return null;
		}
		return GetElement(id);
	}

	T IControllerTemplate.GetElement<T>(int id)
	{
		if (ReInput._id != fvrvnzDPUhVAqIZwUGvIEDtdVqan)
		{
			ReInput.CheckInitialized(fvrvnzDPUhVAqIZwUGvIEDtdVqan);
			return null;
		}
		return GetElement<T>(id);
	}

	int IControllerTemplate.GetElementTargets(ControllerElementTarget find, IList<ControllerTemplateElementTarget> results)
	{
		if (ReInput._id != fvrvnzDPUhVAqIZwUGvIEDtdVqan)
		{
			ReInput.CheckInitialized(fvrvnzDPUhVAqIZwUGvIEDtdVqan);
			return 0;
		}
		if (results == null)
		{
			throw new ArgumentNullException("results");
		}
		return GetElementTargets(find, ref results);
	}

	private string Rewired_002EInternal_002ELocalization_002EINameLocalizerSource_002Eget_keyCategory()
	{
		return "controller/template";
	}

	private string Rewired_002EInternal_002ELocalization_002EINameLocalizerSource_002Eget_scriptingName()
	{
		return string.Empty;
	}

	private string Rewired_002EInternal_002ELocalization_002EINameLocalizerSource_002Eget_nonLocalizedDescriptiveName()
	{
		return gpIQMPpusghFdEZxKBZSIgOeDbtF;
	}

	private void Rewired_002EInternal_002ELocalization_002EINameLocalizerSource_002Eset_nonLocalizedDescriptiveName(string value)
	{
		gpIQMPpusghFdEZxKBZSIgOeDbtF = value;
	}

	private string Rewired_002EInternal_002ELocalization_002EINameLocalizerSource_002Eget_key()
	{
		return qfPBxBnjaNjayOjmDciiGwYjaEnA;
	}

	private int Rewired_002EInternal_002ELocalization_002EINameLocalizerSource_002Eget_autoGeneratedValueFlags()
	{
		return TNHxlTbeVZXyywLAYONNmFPVjmVy;
	}

	private void Rewired_002EInternal_002ELocalization_002EINameLocalizerSource_002Eset_autoGeneratedValueFlags(int value)
	{
		TNHxlTbeVZXyywLAYONNmFPVjmVy = value;
	}

	private int GetElementTargets(ControllerElementTarget find, ref IList<ControllerTemplateElementTarget> results)
	{
		if (results != null)
		{
			results.Clear();
		}
		int num = 0;
		for (int i = 0; i < EtjMknpmGGlpcYDcuZaXduTJZrYg.Length; i++)
		{
			if (InputTools.IsMappableType(EtjMknpmGGlpcYDcuZaXduTJZrYg[i].type))
			{
				num += (EtjMknpmGGlpcYDcuZaXduTJZrYg[i] as IControllerTemplateElement_Internal).GetElementTargets(find, ref results);
			}
		}
		return num;
	}

	[CustomObfuscation(rename = false)]
	internal static Type GetInterfaceType(ControllerTemplateElementType elementType)
	{
		return elementType switch
		{
			ControllerTemplateElementType.Axis => typeof(IControllerTemplateAxis), 
			ControllerTemplateElementType.Button => typeof(IControllerTemplateButton), 
			ControllerTemplateElementType.ThumbStick => typeof(IControllerTemplateThumbStick), 
			ControllerTemplateElementType.DPad => typeof(IControllerTemplateDPad), 
			ControllerTemplateElementType.Stick => typeof(IControllerTemplateStick), 
			ControllerTemplateElementType.Throttle => typeof(IControllerTemplateThrottle), 
			ControllerTemplateElementType.Hat => typeof(IControllerTemplateHat), 
			ControllerTemplateElementType.Yoke => typeof(IControllerTemplateYoke), 
			ControllerTemplateElementType.Stick6D => typeof(IControllerTemplateStick6D), 
			_ => throw new NotImplementedException(), 
		};
	}

	private static IList<CiSbSfhgauKBAosHqvPypWbhRysEA> ckQTsCDUUVCXpZtfBvQYzAemMvZc(Controller P_0, IControllerTemplateAxisSource P_1)
	{
		if (P_1 == null)
		{
			return null;
		}
		if (P_1.splitAxis)
		{
			IList<CiSbSfhgauKBAosHqvPypWbhRysEA> list = null;
			bool flag = false;
			if (P_1.positiveTarget != null)
			{
				Controller.Element elementById = P_0.GetElementById(P_1.positiveTarget.elementIdentifierId);
				if (elementById != null)
				{
					ListTools.AddAndCreateList(ref list, new CiSbSfhgauKBAosHqvPypWbhRysEA(P_1.positiveTarget, elementById));
					flag = true;
				}
			}
			if (!flag)
			{
				ListTools.AddAndCreateList(ref list, CiSbSfhgauKBAosHqvPypWbhRysEA.jppzvWBMpuhCGosZHgKwiPZSLzfK());
			}
			flag = false;
			if (P_1.negativeTarget != null)
			{
				Controller.Element elementById2 = P_0.GetElementById(P_1.negativeTarget.elementIdentifierId);
				if (elementById2 != null)
				{
					ListTools.AddAndCreateList(ref list, new CiSbSfhgauKBAosHqvPypWbhRysEA(P_1.negativeTarget, elementById2));
					flag = true;
				}
			}
			if (!flag)
			{
				ListTools.AddAndCreateList(ref list, CiSbSfhgauKBAosHqvPypWbhRysEA.jppzvWBMpuhCGosZHgKwiPZSLzfK());
			}
			return list;
		}
		return IApFdGaiAmNNmXHVeNWENNSbeRem(P_0, P_1.fullTarget);
	}

	private static IList<CiSbSfhgauKBAosHqvPypWbhRysEA> xZQGYnzjBEsQgLRBoAtrcnlpiKVh(Controller P_0, IControllerTemplateButtonSource P_1)
	{
		if (P_1 == null)
		{
			return null;
		}
		return IApFdGaiAmNNmXHVeNWENNSbeRem(P_0, P_1.target);
	}

	private static IList<CiSbSfhgauKBAosHqvPypWbhRysEA> IApFdGaiAmNNmXHVeNWENNSbeRem(Controller P_0, IControllerElementTarget P_1)
	{
		if (P_1 == null)
		{
			return null;
		}
		Controller.Element elementById = P_0.GetElementById(P_1.elementIdentifierId);
		if (elementById == null)
		{
			return null;
		}
		return new List<CiSbSfhgauKBAosHqvPypWbhRysEA>
		{
			new CiSbSfhgauKBAosHqvPypWbhRysEA(P_1, elementById)
		};
	}

	private static IControllerTemplateElement vmQfnzyIxqVWdtcgepSIKcFqBJTeA(List<IControllerTemplateElement> P_0, int P_1)
	{
		int count = P_0.Count;
		for (int i = 0; i < count; i++)
		{
			if (P_0[i].id == P_1)
			{
				return P_0[i];
			}
		}
		return null;
	}

	private static dPNudSCSIZEEYyzhsbwFYmHFxnIP ZQqgcUlsAYmjbswGcGCEICZWmqfI(IControllerTemplate_Internal P_0, ADictionary<int, IControllerTemplateElement> P_1, int P_2)
	{
		if (!(P_1.GetValueSafe(P_2) is dPNudSCSIZEEYyzhsbwFYmHFxnIP result))
		{
			return EORxWzhjnxSHEOFrXHdOtmhKSPXU.VVkGaaXHjJHrqubARBzSmYODNOCL(P_0);
		}
		return result;
	}

	private static dPNudSCSIZEEYyzhsbwFYmHFxnIP zxUYjsPkWuphbwikswjnGzkwMVMR(IControllerTemplate_Internal P_0, ADictionary<int, IControllerTemplateElement> P_1, int P_2)
	{
		if (!(P_1.GetValueSafe(P_2) is dPNudSCSIZEEYyzhsbwFYmHFxnIP result))
		{
			return lSxoJayIKzvoXJqfGbfmKtxXqIGF.cSKcSMcdxoxvVekTGubjqXSztIpeA(P_0);
		}
		return result;
	}
}
