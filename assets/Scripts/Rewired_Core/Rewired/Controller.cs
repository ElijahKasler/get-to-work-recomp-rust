using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Rewired.Config;
using Rewired.Data.Mapping;
using Rewired.Interfaces;
using Rewired.Internal.Localization;
using Rewired.Utils;
using UnityEngine;

namespace Rewired;

public abstract class Controller
{
	public abstract class Element
	{
		internal abstract class HVaCmzenJEpZviDSrzTIsmgjVVKO
		{
			public abstract class WmdFxDRKmnRhoRqVdoQUUoKTDBTO
			{
				public abstract void srPHuWTIiYlHxQlYMTRmZcZdUNXh();
			}

			protected readonly int sJoeVPayZHWVqtPfLzweFKbBdnBGA;

			protected readonly int[] tOzGxjhnjCAEnuEVQIRrIhbnboGQ;

			protected WmdFxDRKmnRhoRqVdoQUUoKTDBTO[] qHIMKRfYkfOIchsnBzruGyDqtXfe;

			public WmdFxDRKmnRhoRqVdoQUUoKTDBTO gxGFQicLBXORlUsOGjTlHwlUPDQqA;

			private int WoJPupkfBdofMTBYzDGOlKFsdnqJ;

			public int JLRfRkCNcsdrlUUfoPyPaXwdGlUPA = -1;

			protected ReadOnlyCollection<WmdFxDRKmnRhoRqVdoQUUoKTDBTO> JYULHUVbtxYTOcLkvhBqCidRXEgvA;

			public IList<WmdFxDRKmnRhoRqVdoQUUoKTDBTO> IPiDvtFpoFcwIGnUlhcNvoXaICrI => WzGMjrWQdSLAOuBFvvLzqySXgAYp();

			public UpdateLoopType JnmrGZWIItijutUwlFKShCvBmASHb
			{
				set
				{
					nMlkfodLycuKedEJdBchxmVGsvpN(updateLoopType);
				}
			}

			public IList<WmdFxDRKmnRhoRqVdoQUUoKTDBTO> WzGMjrWQdSLAOuBFvvLzqySXgAYp()
			{
				return JYULHUVbtxYTOcLkvhBqCidRXEgvA;
			}

			public void nMlkfodLycuKedEJdBchxmVGsvpN(UpdateLoopType P_0)
			{
				if (JLRfRkCNcsdrlUUfoPyPaXwdGlUPA != (int)P_0)
				{
					JLRfRkCNcsdrlUUfoPyPaXwdGlUPA = (int)P_0;
					WoJPupkfBdofMTBYzDGOlKFsdnqJ = tOzGxjhnjCAEnuEVQIRrIhbnboGQ[(int)P_0];
					gxGFQicLBXORlUsOGjTlHwlUPDQqA = qHIMKRfYkfOIchsnBzruGyDqtXfe[WoJPupkfBdofMTBYzDGOlKFsdnqJ];
				}
			}

			public HVaCmzenJEpZviDSrzTIsmgjVVKO(UpdateLoopSetting P_0)
			{
				tOzGxjhnjCAEnuEVQIRrIhbnboGQ = new int[3];
				sJoeVPayZHWVqtPfLzweFKbBdnBGA = 0;
				using (TempListPool.TList<UpdateLoopType> tList = TempListPool.GetTList<UpdateLoopType>(3))
				{
					List<UpdateLoopType> list = tList.list;
					EnumConverter.ToUpdateLoopTypes(P_0, list);
					for (int i = 0; i < list.Count; i++)
					{
						tOzGxjhnjCAEnuEVQIRrIhbnboGQ[(int)list[i]] = sJoeVPayZHWVqtPfLzweFKbBdnBGA;
						sJoeVPayZHWVqtPfLzweFKbBdnBGA++;
					}
				}
				qHIMKRfYkfOIchsnBzruGyDqtXfe = new WmdFxDRKmnRhoRqVdoQUUoKTDBTO[sJoeVPayZHWVqtPfLzweFKbBdnBGA];
				JYULHUVbtxYTOcLkvhBqCidRXEgvA = new ReadOnlyCollection<WmdFxDRKmnRhoRqVdoQUUoKTDBTO>(qHIMKRfYkfOIchsnBzruGyDqtXfe);
			}

			public void qjGzLPcVIkNgpjzoravHLTHNoxzL()
			{
				for (int i = 0; i < sJoeVPayZHWVqtPfLzweFKbBdnBGA; i++)
				{
					qHIMKRfYkfOIchsnBzruGyDqtXfe[i].srPHuWTIiYlHxQlYMTRmZcZdUNXh();
				}
			}

			public WmdFxDRKmnRhoRqVdoQUUoKTDBTO lNSLIckcuuExjlKyYHLVZaaICdtcA(UpdateLoopType P_0)
			{
				return qHIMKRfYkfOIchsnBzruGyDqtXfe[tOzGxjhnjCAEnuEVQIRrIhbnboGQ[(int)P_0]];
			}
		}

		public readonly int id;

		public readonly string name;

		public readonly ControllerElementType type;

		internal HVaCmzenJEpZviDSrzTIsmgjVVKO DdTOJXDMRSyKMkhHBULqqZxplZGB;

		internal int FwNdZKacEHVxcSmzGOlnwqUXCNLs;

		internal Controller bezPiJCxxPkpUZEbBjMGmhxFjvjD;

		internal readonly int GAxcZwbHqTeMSxoiEJZbiyufHrQGA;

		private CompoundElement pOljWShkTUJAjNwrlmwYFcMEToqA;

		public ControllerElementIdentifier elementIdentifier
		{
			get
			{
				if (ReInput._id != GAxcZwbHqTeMSxoiEJZbiyufHrQGA)
				{
					ReInput.CheckInitialized(GAxcZwbHqTeMSxoiEJZbiyufHrQGA);
					return null;
				}
				ControllerElementIdentifier elementIdentifierById = bezPiJCxxPkpUZEbBjMGmhxFjvjD.GetElementIdentifierById(id);
				if (elementIdentifierById == null)
				{
					return ControllerElementIdentifier.BlankReadOnly;
				}
				return elementIdentifierById;
			}
		}

		public bool isMemberElement
		{
			get
			{
				if (ReInput._id != GAxcZwbHqTeMSxoiEJZbiyufHrQGA)
				{
					ReInput.CheckInitialized(GAxcZwbHqTeMSxoiEJZbiyufHrQGA);
					return false;
				}
				return FwNdZKacEHVxcSmzGOlnwqUXCNLs > 0;
			}
		}

		public CompoundElement compoundElement => pOljWShkTUJAjNwrlmwYFcMEToqA;

		internal Element(Controller P_0, int P_1, string P_2, ControllerElementType P_3)
		{
			bezPiJCxxPkpUZEbBjMGmhxFjvjD = P_0;
			id = P_1;
			name = P_2;
			type = P_3;
			GAxcZwbHqTeMSxoiEJZbiyufHrQGA = ReInput.id;
		}

		public void Reset()
		{
			if (ReInput._id != GAxcZwbHqTeMSxoiEJZbiyufHrQGA)
			{
				ReInput.CheckInitialized(GAxcZwbHqTeMSxoiEJZbiyufHrQGA);
			}
			else if (DdTOJXDMRSyKMkhHBULqqZxplZGB != null)
			{
				DdTOJXDMRSyKMkhHBULqqZxplZGB.qjGzLPcVIkNgpjzoravHLTHNoxzL();
			}
		}

		internal void WMhBsxeHGODmfHfvANCWYkEfaqUp(CompoundElement P_0)
		{
			if (FwNdZKacEHVxcSmzGOlnwqUXCNLs > 0)
			{
				Logger.LogWarning("This element is already a member of a compound element! This is not supported. Resulting values may be unpredictable.");
			}
			FwNdZKacEHVxcSmzGOlnwqUXCNLs++;
			if (pOljWShkTUJAjNwrlmwYFcMEToqA == null)
			{
				pOljWShkTUJAjNwrlmwYFcMEToqA = P_0;
			}
		}

		internal void RLMFwJguHCpPwIgpewCzgFhIsohRe(CompoundElement P_0)
		{
			if (FwNdZKacEHVxcSmzGOlnwqUXCNLs == 0)
			{
				Logger.LogWarning("This element is not a member of a compound element!");
				FwNdZKacEHVxcSmzGOlnwqUXCNLs = 0;
				return;
			}
			FwNdZKacEHVxcSmzGOlnwqUXCNLs--;
			if (pOljWShkTUJAjNwrlmwYFcMEToqA == P_0)
			{
				pOljWShkTUJAjNwrlmwYFcMEToqA = null;
			}
		}
	}

	public sealed class Axis : Element
	{
		internal class ONodKmkESMKlbaFxTFpdGfOPfxdpA : HVaCmzenJEpZviDSrzTIsmgjVVKO
		{
			public class FlyaYKvSQslyazpwGobYHBgfiUzH : WmdFxDRKmnRhoRqVdoQUUoKTDBTO
			{
				private const float HGnFKckWLjEUDlVJwNvfFOCwqKvZA = 0.001f;

				public float HTEjknNBSikyYoPimHGUbQbLGuOk;

				public float jcgLZTJCnZzBaUNmRcgXdvWhrnpJ;

				public float IzHxtKmPjIOWarBTiDPmHybyorgJ;

				public float fsntJjeHvQGeJkZFjTazopUzZlULA;

				public float qBCHkXcEicumscsAOHqmniHuKHyTA;

				public float NTPKxEsxGesejPgwldNnGMbyVIqiA;

				public double dZcYgqqFdPLYOOtuOmCgYINjpDhf;

				public double NlVELNKSQClAJqQUqTyaiNQLUrZc;

				public double KIfQhQYCtJFIEtVgSJOaLuVjgihi;

				public double oIlMkLNKOdBDiaakshvXoITmglHhA;

				public double wXkvDzaFjDcpXrKtOuoRhoIPOBjl;

				public double BBvMIoHNbRzoYFIIHhleYhmVclce;

				public double qghYAqxbfLOmTLdFEkYpvJOhvVlm => DZiMrGOoabLVEUUrooFyWYTQypgh();

				public double jsjLTMJTyilqbarEZoINqKOtgdwr => TVSJdToTOnetvdIYIrsZjfgKdqpQ();

				public double AXuHHaWtoTnLflblNBcsrIqvhSmo => ZdntZNSmXbIlqrdsNMlSzljGqbXv();

				public double cRcFAMjibXbBJzISvBiYElcDAnqOB => frgLlIXLYVpmxJJPFohICqxxplVT();

				public double DZiMrGOoabLVEUUrooFyWYTQypgh()
				{
					if ((double)HTEjknNBSikyYoPimHGUbQbLGuOk == 0.0)
					{
						return 0.0;
					}
					return ReInput.unscaledTime - KIfQhQYCtJFIEtVgSJOaLuVjgihi;
				}

				public double TVSJdToTOnetvdIYIrsZjfgKdqpQ()
				{
					if ((double)IzHxtKmPjIOWarBTiDPmHybyorgJ == 0.0)
					{
						return 0.0;
					}
					return ReInput.unscaledTime - oIlMkLNKOdBDiaakshvXoITmglHhA;
				}

				public double ZdntZNSmXbIlqrdsNMlSzljGqbXv()
				{
					if (HTEjknNBSikyYoPimHGUbQbLGuOk != 0f)
					{
						return 0.0;
					}
					return ReInput.unscaledTime - dZcYgqqFdPLYOOtuOmCgYINjpDhf;
				}

				public double frgLlIXLYVpmxJJPFohICqxxplVT()
				{
					if ((double)IzHxtKmPjIOWarBTiDPmHybyorgJ != 0.0)
					{
						return 0.0;
					}
					return ReInput.unscaledTime - NlVELNKSQClAJqQUqTyaiNQLUrZc;
				}

				public void wKhtwtoOTaQTrklkKSjdXuvYUBUb(bool P_0)
				{
					double unscaledTime = ReInput.unscaledTime;
					if (P_0)
					{
						if (!MathTools.Approximately(qBCHkXcEicumscsAOHqmniHuKHyTA, 0f))
						{
							dZcYgqqFdPLYOOtuOmCgYINjpDhf = unscaledTime;
						}
						else
						{
							KIfQhQYCtJFIEtVgSJOaLuVjgihi = unscaledTime;
						}
						if (!MathTools.IsNear(qBCHkXcEicumscsAOHqmniHuKHyTA, NTPKxEsxGesejPgwldNnGMbyVIqiA, 0.001f))
						{
							wXkvDzaFjDcpXrKtOuoRhoIPOBjl = unscaledTime;
						}
					}
					else
					{
						if (!MathTools.Approximately(HTEjknNBSikyYoPimHGUbQbLGuOk, 0f))
						{
							dZcYgqqFdPLYOOtuOmCgYINjpDhf = unscaledTime;
						}
						else
						{
							KIfQhQYCtJFIEtVgSJOaLuVjgihi = unscaledTime;
						}
						if (!MathTools.IsNear(HTEjknNBSikyYoPimHGUbQbLGuOk, jcgLZTJCnZzBaUNmRcgXdvWhrnpJ, 0.001f))
						{
							wXkvDzaFjDcpXrKtOuoRhoIPOBjl = unscaledTime;
						}
					}
					if (!MathTools.Approximately(IzHxtKmPjIOWarBTiDPmHybyorgJ, 0f))
					{
						NlVELNKSQClAJqQUqTyaiNQLUrZc = unscaledTime;
					}
					else
					{
						oIlMkLNKOdBDiaakshvXoITmglHhA = unscaledTime;
					}
					if (!MathTools.IsNear(IzHxtKmPjIOWarBTiDPmHybyorgJ, fsntJjeHvQGeJkZFjTazopUzZlULA, 0.001f))
					{
						BBvMIoHNbRzoYFIIHhleYhmVclce = unscaledTime;
					}
				}

				public void IvdfbrbHSFZVoSipjOvHNPyioaWm(float P_0)
				{
					if (fsntJjeHvQGeJkZFjTazopUzZlULA != IzHxtKmPjIOWarBTiDPmHybyorgJ)
					{
						fsntJjeHvQGeJkZFjTazopUzZlULA = IzHxtKmPjIOWarBTiDPmHybyorgJ;
					}
					if (IzHxtKmPjIOWarBTiDPmHybyorgJ != P_0)
					{
						IzHxtKmPjIOWarBTiDPmHybyorgJ = P_0;
					}
				}

				public virtual void XKbIEsTtIOJBwmGTHyDdxJGTbIUAA()
				{
					HTEjknNBSikyYoPimHGUbQbLGuOk = 0f;
					jcgLZTJCnZzBaUNmRcgXdvWhrnpJ = 0f;
					IzHxtKmPjIOWarBTiDPmHybyorgJ = 0f;
					fsntJjeHvQGeJkZFjTazopUzZlULA = 0f;
					dZcYgqqFdPLYOOtuOmCgYINjpDhf = 0.0;
					NlVELNKSQClAJqQUqTyaiNQLUrZc = 0.0;
					KIfQhQYCtJFIEtVgSJOaLuVjgihi = 0.0;
					oIlMkLNKOdBDiaakshvXoITmglHhA = 0.0;
					wXkvDzaFjDcpXrKtOuoRhoIPOBjl = 0.0;
					BBvMIoHNbRzoYFIIHhleYhmVclce = 0.0;
				}
			}

			public ONodKmkESMKlbaFxTFpdGfOPfxdpA(UpdateLoopSetting P_0)
				: base(P_0)
			{
				for (int i = 0; i < sJoeVPayZHWVqtPfLzweFKbBdnBGA; i++)
				{
					qHIMKRfYkfOIchsnBzruGyDqtXfe[i] = new FlyaYKvSQslyazpwGobYHBgfiUzH();
				}
				gxGFQicLBXORlUsOGjTlHwlUPDQqA = qHIMKRfYkfOIchsnBzruGyDqtXfe[0];
			}
		}

		internal readonly AxisRange GdcJlRiiHwRTeMjHXdfiytTAhDEFA;

		internal readonly HardwareAxisInfo XPJMXvcDLsDoYlwHEhEAofLIBGih;

		public float value
		{
			get
			{
				if (ReInput._id != GAxcZwbHqTeMSxoiEJZbiyufHrQGA)
				{
					ReInput.CheckInitialized(GAxcZwbHqTeMSxoiEJZbiyufHrQGA);
					return 0f;
				}
				if (base.isMemberElement)
				{
					return ((ONodKmkESMKlbaFxTFpdGfOPfxdpA.FlyaYKvSQslyazpwGobYHBgfiUzH)DdTOJXDMRSyKMkhHBULqqZxplZGB.gxGFQicLBXORlUsOGjTlHwlUPDQqA).qBCHkXcEicumscsAOHqmniHuKHyTA;
				}
				return ((ONodKmkESMKlbaFxTFpdGfOPfxdpA.FlyaYKvSQslyazpwGobYHBgfiUzH)DdTOJXDMRSyKMkhHBULqqZxplZGB.gxGFQicLBXORlUsOGjTlHwlUPDQqA).HTEjknNBSikyYoPimHGUbQbLGuOk;
			}
		}

		public float valuePrev
		{
			get
			{
				if (ReInput._id != GAxcZwbHqTeMSxoiEJZbiyufHrQGA)
				{
					ReInput.CheckInitialized(GAxcZwbHqTeMSxoiEJZbiyufHrQGA);
					return 0f;
				}
				if (base.isMemberElement)
				{
					return ((ONodKmkESMKlbaFxTFpdGfOPfxdpA.FlyaYKvSQslyazpwGobYHBgfiUzH)DdTOJXDMRSyKMkhHBULqqZxplZGB.gxGFQicLBXORlUsOGjTlHwlUPDQqA).NTPKxEsxGesejPgwldNnGMbyVIqiA;
				}
				return ((ONodKmkESMKlbaFxTFpdGfOPfxdpA.FlyaYKvSQslyazpwGobYHBgfiUzH)DdTOJXDMRSyKMkhHBULqqZxplZGB.gxGFQicLBXORlUsOGjTlHwlUPDQqA).jcgLZTJCnZzBaUNmRcgXdvWhrnpJ;
			}
		}

		public float valueRaw
		{
			get
			{
				if (ReInput._id != GAxcZwbHqTeMSxoiEJZbiyufHrQGA)
				{
					ReInput.CheckInitialized(GAxcZwbHqTeMSxoiEJZbiyufHrQGA);
					return 0f;
				}
				return ((ONodKmkESMKlbaFxTFpdGfOPfxdpA.FlyaYKvSQslyazpwGobYHBgfiUzH)DdTOJXDMRSyKMkhHBULqqZxplZGB.gxGFQicLBXORlUsOGjTlHwlUPDQqA).IzHxtKmPjIOWarBTiDPmHybyorgJ;
			}
			internal set
			{
				EnPEzrYrNopiLFctMJtttPFiCXcb(num);
			}
		}

		public float valueRawPrev
		{
			get
			{
				if (ReInput._id != GAxcZwbHqTeMSxoiEJZbiyufHrQGA)
				{
					ReInput.CheckInitialized(GAxcZwbHqTeMSxoiEJZbiyufHrQGA);
					return 0f;
				}
				return ((ONodKmkESMKlbaFxTFpdGfOPfxdpA.FlyaYKvSQslyazpwGobYHBgfiUzH)DdTOJXDMRSyKMkhHBULqqZxplZGB.gxGFQicLBXORlUsOGjTlHwlUPDQqA).fsntJjeHvQGeJkZFjTazopUzZlULA;
			}
		}

		public float valueDelta
		{
			get
			{
				if (ReInput._id != GAxcZwbHqTeMSxoiEJZbiyufHrQGA)
				{
					ReInput.CheckInitialized(GAxcZwbHqTeMSxoiEJZbiyufHrQGA);
					return 0f;
				}
				return value - valuePrev;
			}
		}

		public float valueDeltaRaw
		{
			get
			{
				if (ReInput._id != GAxcZwbHqTeMSxoiEJZbiyufHrQGA)
				{
					ReInput.CheckInitialized(GAxcZwbHqTeMSxoiEJZbiyufHrQGA);
					return 0f;
				}
				return ((ONodKmkESMKlbaFxTFpdGfOPfxdpA.FlyaYKvSQslyazpwGobYHBgfiUzH)DdTOJXDMRSyKMkhHBULqqZxplZGB.gxGFQicLBXORlUsOGjTlHwlUPDQqA).IzHxtKmPjIOWarBTiDPmHybyorgJ - ((ONodKmkESMKlbaFxTFpdGfOPfxdpA.FlyaYKvSQslyazpwGobYHBgfiUzH)DdTOJXDMRSyKMkhHBULqqZxplZGB.gxGFQicLBXORlUsOGjTlHwlUPDQqA).fsntJjeHvQGeJkZFjTazopUzZlULA;
			}
		}

		public double lastTimeActive
		{
			get
			{
				if (ReInput._id != GAxcZwbHqTeMSxoiEJZbiyufHrQGA)
				{
					ReInput.CheckInitialized(GAxcZwbHqTeMSxoiEJZbiyufHrQGA);
					return 0.0;
				}
				return ((ONodKmkESMKlbaFxTFpdGfOPfxdpA.FlyaYKvSQslyazpwGobYHBgfiUzH)DdTOJXDMRSyKMkhHBULqqZxplZGB.gxGFQicLBXORlUsOGjTlHwlUPDQqA).dZcYgqqFdPLYOOtuOmCgYINjpDhf;
			}
		}

		public double lastTimeActiveRaw
		{
			get
			{
				if (ReInput._id != GAxcZwbHqTeMSxoiEJZbiyufHrQGA)
				{
					ReInput.CheckInitialized(GAxcZwbHqTeMSxoiEJZbiyufHrQGA);
					return 0.0;
				}
				return ((ONodKmkESMKlbaFxTFpdGfOPfxdpA.FlyaYKvSQslyazpwGobYHBgfiUzH)DdTOJXDMRSyKMkhHBULqqZxplZGB.gxGFQicLBXORlUsOGjTlHwlUPDQqA).NlVELNKSQClAJqQUqTyaiNQLUrZc;
			}
		}

		public double lastTimeInactive
		{
			get
			{
				if (ReInput._id != GAxcZwbHqTeMSxoiEJZbiyufHrQGA)
				{
					ReInput.CheckInitialized(GAxcZwbHqTeMSxoiEJZbiyufHrQGA);
					return 0.0;
				}
				return ((ONodKmkESMKlbaFxTFpdGfOPfxdpA.FlyaYKvSQslyazpwGobYHBgfiUzH)DdTOJXDMRSyKMkhHBULqqZxplZGB.gxGFQicLBXORlUsOGjTlHwlUPDQqA).KIfQhQYCtJFIEtVgSJOaLuVjgihi;
			}
		}

		public double lastTimeInactiveRaw
		{
			get
			{
				if (ReInput._id != GAxcZwbHqTeMSxoiEJZbiyufHrQGA)
				{
					ReInput.CheckInitialized(GAxcZwbHqTeMSxoiEJZbiyufHrQGA);
					return 0.0;
				}
				return ((ONodKmkESMKlbaFxTFpdGfOPfxdpA.FlyaYKvSQslyazpwGobYHBgfiUzH)DdTOJXDMRSyKMkhHBULqqZxplZGB.gxGFQicLBXORlUsOGjTlHwlUPDQqA).oIlMkLNKOdBDiaakshvXoITmglHhA;
			}
		}

		public double lastTimeValueChanged
		{
			get
			{
				if (ReInput._id != GAxcZwbHqTeMSxoiEJZbiyufHrQGA)
				{
					ReInput.CheckInitialized(GAxcZwbHqTeMSxoiEJZbiyufHrQGA);
					return 0.0;
				}
				return ((ONodKmkESMKlbaFxTFpdGfOPfxdpA.FlyaYKvSQslyazpwGobYHBgfiUzH)DdTOJXDMRSyKMkhHBULqqZxplZGB.gxGFQicLBXORlUsOGjTlHwlUPDQqA).wXkvDzaFjDcpXrKtOuoRhoIPOBjl;
			}
		}

		public double lastTimeValueChangedRaw
		{
			get
			{
				if (ReInput._id != GAxcZwbHqTeMSxoiEJZbiyufHrQGA)
				{
					ReInput.CheckInitialized(GAxcZwbHqTeMSxoiEJZbiyufHrQGA);
					return 0.0;
				}
				return ((ONodKmkESMKlbaFxTFpdGfOPfxdpA.FlyaYKvSQslyazpwGobYHBgfiUzH)DdTOJXDMRSyKMkhHBULqqZxplZGB.gxGFQicLBXORlUsOGjTlHwlUPDQqA).BBvMIoHNbRzoYFIIHhleYhmVclce;
			}
		}

		public double timeActive
		{
			get
			{
				if (ReInput._id != GAxcZwbHqTeMSxoiEJZbiyufHrQGA)
				{
					ReInput.CheckInitialized(GAxcZwbHqTeMSxoiEJZbiyufHrQGA);
					return 0.0;
				}
				return ((ONodKmkESMKlbaFxTFpdGfOPfxdpA.FlyaYKvSQslyazpwGobYHBgfiUzH)DdTOJXDMRSyKMkhHBULqqZxplZGB.gxGFQicLBXORlUsOGjTlHwlUPDQqA).DZiMrGOoabLVEUUrooFyWYTQypgh();
			}
		}

		public double timeActiveRaw
		{
			get
			{
				if (ReInput._id != GAxcZwbHqTeMSxoiEJZbiyufHrQGA)
				{
					ReInput.CheckInitialized(GAxcZwbHqTeMSxoiEJZbiyufHrQGA);
					return 0.0;
				}
				return ((ONodKmkESMKlbaFxTFpdGfOPfxdpA.FlyaYKvSQslyazpwGobYHBgfiUzH)DdTOJXDMRSyKMkhHBULqqZxplZGB.gxGFQicLBXORlUsOGjTlHwlUPDQqA).DZiMrGOoabLVEUUrooFyWYTQypgh();
			}
		}

		public double timeInactive
		{
			get
			{
				if (ReInput._id != GAxcZwbHqTeMSxoiEJZbiyufHrQGA)
				{
					ReInput.CheckInitialized(GAxcZwbHqTeMSxoiEJZbiyufHrQGA);
					return 0.0;
				}
				return ((ONodKmkESMKlbaFxTFpdGfOPfxdpA.FlyaYKvSQslyazpwGobYHBgfiUzH)DdTOJXDMRSyKMkhHBULqqZxplZGB.gxGFQicLBXORlUsOGjTlHwlUPDQqA).ZdntZNSmXbIlqrdsNMlSzljGqbXv();
			}
		}

		public double timeInactiveRaw
		{
			get
			{
				if (ReInput._id != GAxcZwbHqTeMSxoiEJZbiyufHrQGA)
				{
					ReInput.CheckInitialized(GAxcZwbHqTeMSxoiEJZbiyufHrQGA);
					return 0.0;
				}
				return ((ONodKmkESMKlbaFxTFpdGfOPfxdpA.FlyaYKvSQslyazpwGobYHBgfiUzH)DdTOJXDMRSyKMkhHBULqqZxplZGB.gxGFQicLBXORlUsOGjTlHwlUPDQqA).frgLlIXLYVpmxJJPFohICqxxplVT();
			}
		}

		public float pollingDeadZone
		{
			get
			{
				if (ReInput._id != GAxcZwbHqTeMSxoiEJZbiyufHrQGA)
				{
					ReInput.CheckInitialized(GAxcZwbHqTeMSxoiEJZbiyufHrQGA);
					return 0f;
				}
				if (XPJMXvcDLsDoYlwHEhEAofLIBGih == null)
				{
					return -1f;
				}
				return XPJMXvcDLsDoYlwHEhEAofLIBGih._pollingDeadZone;
			}
			set
			{
				if (ReInput._id != GAxcZwbHqTeMSxoiEJZbiyufHrQGA)
				{
					ReInput.CheckInitialized(GAxcZwbHqTeMSxoiEJZbiyufHrQGA);
					return;
				}
				if (value < 0f)
				{
					value = -1f;
				}
				if (XPJMXvcDLsDoYlwHEhEAofLIBGih != null)
				{
					XPJMXvcDLsDoYlwHEhEAofLIBGih._pollingDeadZone = value;
				}
			}
		}

		internal float fQaPvQUaaJUIuldKysKfbnfBdqAm => xSjdqqDFPxnDsPHPcPiPQcjcTzWnA();

		internal float cXujuRZQpkWRvENVkhfwZYDZCTAG => ZsxPQLYFmNwSXKLVUEtlkrJYPkeEb();

		internal float hyOyHIIhEPaMTKZZNbTHvsljoWcg => AvbeukGhMeWVdlYXEDPZddcdeFSsA();

		internal void EnPEzrYrNopiLFctMJtttPFiCXcb(float P_0)
		{
			((ONodKmkESMKlbaFxTFpdGfOPfxdpA.FlyaYKvSQslyazpwGobYHBgfiUzH)DdTOJXDMRSyKMkhHBULqqZxplZGB.gxGFQicLBXORlUsOGjTlHwlUPDQqA).IvdfbrbHSFZVoSipjOvHNPyioaWm(P_0);
		}

		internal float xSjdqqDFPxnDsPHPcPiPQcjcTzWnA()
		{
			return ((ONodKmkESMKlbaFxTFpdGfOPfxdpA.FlyaYKvSQslyazpwGobYHBgfiUzH)DdTOJXDMRSyKMkhHBULqqZxplZGB.gxGFQicLBXORlUsOGjTlHwlUPDQqA).HTEjknNBSikyYoPimHGUbQbLGuOk;
		}

		internal float ZsxPQLYFmNwSXKLVUEtlkrJYPkeEb()
		{
			return ((ONodKmkESMKlbaFxTFpdGfOPfxdpA.FlyaYKvSQslyazpwGobYHBgfiUzH)DdTOJXDMRSyKMkhHBULqqZxplZGB.gxGFQicLBXORlUsOGjTlHwlUPDQqA).jcgLZTJCnZzBaUNmRcgXdvWhrnpJ;
		}

		internal void eIKzLOjWhbGPWJwIccMalYOuVgeC(float P_0)
		{
			ONodKmkESMKlbaFxTFpdGfOPfxdpA.FlyaYKvSQslyazpwGobYHBgfiUzH obj = (ONodKmkESMKlbaFxTFpdGfOPfxdpA.FlyaYKvSQslyazpwGobYHBgfiUzH)DdTOJXDMRSyKMkhHBULqqZxplZGB.gxGFQicLBXORlUsOGjTlHwlUPDQqA;
			obj.NTPKxEsxGesejPgwldNnGMbyVIqiA = obj.qBCHkXcEicumscsAOHqmniHuKHyTA;
			obj.qBCHkXcEicumscsAOHqmniHuKHyTA = P_0;
		}

		internal float AvbeukGhMeWVdlYXEDPZddcdeFSsA()
		{
			if (XPJMXvcDLsDoYlwHEhEAofLIBGih == null)
			{
				return ReInput.configuration.defaultAbsoluteAxisPollingDeadZone;
			}
			if (XPJMXvcDLsDoYlwHEhEAofLIBGih._pollingDeadZone >= 0f)
			{
				return XPJMXvcDLsDoYlwHEhEAofLIBGih._pollingDeadZone;
			}
			return XPJMXvcDLsDoYlwHEhEAofLIBGih._dataFormat switch
			{
				AxisCoordinateMode.Absolute => ReInput.configuration.defaultAbsoluteAxisPollingDeadZone, 
				AxisCoordinateMode.Relative => ReInput.configuration.defaultRelativeAxisPollingDeadZone, 
				_ => throw new NotImplementedException(), 
			};
		}

		internal Axis(Controller P_0, int P_1, string P_2, AxisRange P_3, HardwareAxisInfo P_4)
			: base(P_0, P_1, P_2, ControllerElementType.Axis)
		{
			DdTOJXDMRSyKMkhHBULqqZxplZGB = new ONodKmkESMKlbaFxTFpdGfOPfxdpA(ReInput.configVars.updateLoop);
			GdcJlRiiHwRTeMjHXdfiytTAhDEFA = P_3;
			XPJMXvcDLsDoYlwHEhEAofLIBGih = P_4;
		}

		internal void PAFGMCwxOiWxdZXutQtUkfGsgbPD(UpdateLoopType P_0)
		{
			if (DdTOJXDMRSyKMkhHBULqqZxplZGB != null && DdTOJXDMRSyKMkhHBULqqZxplZGB.JLRfRkCNcsdrlUUfoPyPaXwdGlUPA != (int)P_0)
			{
				DdTOJXDMRSyKMkhHBULqqZxplZGB.nMlkfodLycuKedEJdBchxmVGsvpN(P_0);
			}
		}

		internal void fNDBxYpcOHnvawNzUyDDspUqayQDA(AxisCalibration P_0)
		{
			ONodKmkESMKlbaFxTFpdGfOPfxdpA.FlyaYKvSQslyazpwGobYHBgfiUzH flyaYKvSQslyazpwGobYHBgfiUzH = (ONodKmkESMKlbaFxTFpdGfOPfxdpA.FlyaYKvSQslyazpwGobYHBgfiUzH)DdTOJXDMRSyKMkhHBULqqZxplZGB.gxGFQicLBXORlUsOGjTlHwlUPDQqA;
			flyaYKvSQslyazpwGobYHBgfiUzH.jcgLZTJCnZzBaUNmRcgXdvWhrnpJ = flyaYKvSQslyazpwGobYHBgfiUzH.HTEjknNBSikyYoPimHGUbQbLGuOk;
			float hTEjknNBSikyYoPimHGUbQbLGuOk = P_0.GetCalibratedValue(flyaYKvSQslyazpwGobYHBgfiUzH.IzHxtKmPjIOWarBTiDPmHybyorgJ, GdcJlRiiHwRTeMjHXdfiytTAhDEFA);
			if (P_0.applyRangeCalibration)
			{
				hTEjknNBSikyYoPimHGUbQbLGuOk = MathTools.Clamp(hTEjknNBSikyYoPimHGUbQbLGuOk, -1f, 1f);
			}
			flyaYKvSQslyazpwGobYHBgfiUzH.HTEjknNBSikyYoPimHGUbQbLGuOk = hTEjknNBSikyYoPimHGUbQbLGuOk;
		}

		internal void otjGcOpkhmEIaXAdlXcYCpDOfRrs()
		{
			ONodKmkESMKlbaFxTFpdGfOPfxdpA.FlyaYKvSQslyazpwGobYHBgfiUzH obj = (ONodKmkESMKlbaFxTFpdGfOPfxdpA.FlyaYKvSQslyazpwGobYHBgfiUzH)DdTOJXDMRSyKMkhHBULqqZxplZGB.gxGFQicLBXORlUsOGjTlHwlUPDQqA;
			obj.jcgLZTJCnZzBaUNmRcgXdvWhrnpJ = obj.HTEjknNBSikyYoPimHGUbQbLGuOk;
			obj.HTEjknNBSikyYoPimHGUbQbLGuOk = obj.IzHxtKmPjIOWarBTiDPmHybyorgJ;
		}

		internal void qhzRXfLSfSKZQOvifXOhlrmKRQSe()
		{
			ONodKmkESMKlbaFxTFpdGfOPfxdpA.FlyaYKvSQslyazpwGobYHBgfiUzH obj = (ONodKmkESMKlbaFxTFpdGfOPfxdpA.FlyaYKvSQslyazpwGobYHBgfiUzH)DdTOJXDMRSyKMkhHBULqqZxplZGB.gxGFQicLBXORlUsOGjTlHwlUPDQqA;
			obj.jcgLZTJCnZzBaUNmRcgXdvWhrnpJ = obj.HTEjknNBSikyYoPimHGUbQbLGuOk;
			obj.HTEjknNBSikyYoPimHGUbQbLGuOk = 0f;
		}

		internal void RtHLInCemZPWvWSrXSqpvkwWEFFC()
		{
			((ONodKmkESMKlbaFxTFpdGfOPfxdpA.FlyaYKvSQslyazpwGobYHBgfiUzH)DdTOJXDMRSyKMkhHBULqqZxplZGB.gxGFQicLBXORlUsOGjTlHwlUPDQqA).wKhtwtoOTaQTrklkKSjdXuvYUBUb(base.isMemberElement);
		}

		internal void uPMgsHKdxCfbhYamsdKrxKBRQzCj(float P_0)
		{
			for (int i = 0; i < DdTOJXDMRSyKMkhHBULqqZxplZGB.WzGMjrWQdSLAOuBFvvLzqySXgAYp().Count; i++)
			{
				if (DdTOJXDMRSyKMkhHBULqqZxplZGB.WzGMjrWQdSLAOuBFvvLzqySXgAYp()[i] is ONodKmkESMKlbaFxTFpdGfOPfxdpA.FlyaYKvSQslyazpwGobYHBgfiUzH flyaYKvSQslyazpwGobYHBgfiUzH)
				{
					flyaYKvSQslyazpwGobYHBgfiUzH.IvdfbrbHSFZVoSipjOvHNPyioaWm(P_0);
					flyaYKvSQslyazpwGobYHBgfiUzH.jcgLZTJCnZzBaUNmRcgXdvWhrnpJ = flyaYKvSQslyazpwGobYHBgfiUzH.HTEjknNBSikyYoPimHGUbQbLGuOk;
					flyaYKvSQslyazpwGobYHBgfiUzH.HTEjknNBSikyYoPimHGUbQbLGuOk = 0f;
					flyaYKvSQslyazpwGobYHBgfiUzH.wKhtwtoOTaQTrklkKSjdXuvYUBUb(base.isMemberElement);
				}
			}
		}

		internal float shQMclfXTNCRJwihCqGenlxomRNQ(UpdateLoopType P_0, AxisCalibration P_1)
		{
			ONodKmkESMKlbaFxTFpdGfOPfxdpA.FlyaYKvSQslyazpwGobYHBgfiUzH flyaYKvSQslyazpwGobYHBgfiUzH = (ONodKmkESMKlbaFxTFpdGfOPfxdpA.FlyaYKvSQslyazpwGobYHBgfiUzH)DdTOJXDMRSyKMkhHBULqqZxplZGB.lNSLIckcuuExjlKyYHLVZaaICdtcA(P_0);
			float result = P_1.GetCalibratedValue(flyaYKvSQslyazpwGobYHBgfiUzH.IzHxtKmPjIOWarBTiDPmHybyorgJ, GdcJlRiiHwRTeMjHXdfiytTAhDEFA, P_1.deadZone, applySensitivity: false, applyInversion: true);
			if (P_1.applyRangeCalibration)
			{
				result = MathTools.Clamp(result, -1f, 1f);
			}
			return result;
		}
	}

	public sealed class Button : Element
	{
		internal class ZpzuyyQVSArvOCQjtzMTlcPUCJlN : HVaCmzenJEpZviDSrzTIsmgjVVKO
		{
			public class tYFipRbROsPCujECItFiNqyBOGvS : WmdFxDRKmnRhoRqVdoQUUoKTDBTO
			{
				public bool QErghnjAwMILzdPtZKNEaQIlXzDAA;

				public bool NbioomLnVezQJLSvfDWHKYVqWHeb;

				public ButtonStateRecorder wcreJbrsvVkfxtZsWhvhOrBUJzoJ;

				public MhVcTxeuOxJJfafhlERyuCHNydDdA FIveEJJNZBWuZJGjvISBGPcKttxAB;

				public tYFipRbROsPCujECItFiNqyBOGvS()
				{
					wcreJbrsvVkfxtZsWhvhOrBUJzoJ = new ButtonStateRecorder();
					FIveEJJNZBWuZJGjvISBGPcKttxAB = new MhVcTxeuOxJJfafhlERyuCHNydDdA(0.3f);
				}

				public void zdECzQDRfFrnHCFzGmGUqNChgSGPC(bool P_0)
				{
					if (NbioomLnVezQJLSvfDWHKYVqWHeb != QErghnjAwMILzdPtZKNEaQIlXzDAA)
					{
						NbioomLnVezQJLSvfDWHKYVqWHeb = QErghnjAwMILzdPtZKNEaQIlXzDAA;
					}
					if (QErghnjAwMILzdPtZKNEaQIlXzDAA != P_0)
					{
						QErghnjAwMILzdPtZKNEaQIlXzDAA = P_0;
					}
					wcreJbrsvVkfxtZsWhvhOrBUJzoJ.yeoViGcLJxdMqDtvyNmhBCfautPN(P_0 && !NbioomLnVezQJLSvfDWHKYVqWHeb, P_0, ReInput.unscaledTime);
					FIveEJJNZBWuZJGjvISBGPcKttxAB.IWLUPusgzBycnFAPwiTLiPgCckbV(0.3f, P_0 && !NbioomLnVezQJLSvfDWHKYVqWHeb, P_0);
				}

				public virtual void aymGtXXbiLGeRgpOKYsUOYaadiYXA()
				{
					QErghnjAwMILzdPtZKNEaQIlXzDAA = false;
					NbioomLnVezQJLSvfDWHKYVqWHeb = false;
					wcreJbrsvVkfxtZsWhvhOrBUJzoJ.MGjVHEEcDTPJeWYPyUJkyrIZSlcc();
					FIveEJJNZBWuZJGjvISBGPcKttxAB.ryDvPjGrBlfsSJphBuSjIlnPtBWb();
				}
			}

			public class gtCnydrdBKfabBvflDLPLCSAMNAFA : tYFipRbROsPCujECItFiNqyBOGvS
			{
				public float iOVIYymHJloklXxfhFHKXxAADcjw;

				public float CYwhZgwfscfavVMmYaKvmQbZKDLH;

				public void sGiDbItejlumUSwOevyPTQrlwFTJ(float P_0)
				{
					if (CYwhZgwfscfavVMmYaKvmQbZKDLH != iOVIYymHJloklXxfhFHKXxAADcjw)
					{
						CYwhZgwfscfavVMmYaKvmQbZKDLH = iOVIYymHJloklXxfhFHKXxAADcjw;
					}
					if (iOVIYymHJloklXxfhFHKXxAADcjw != P_0)
					{
						iOVIYymHJloklXxfhFHKXxAADcjw = ((P_0 > 0.001f) ? P_0 : 0f);
					}
					zdECzQDRfFrnHCFzGmGUqNChgSGPC(iOVIYymHJloklXxfhFHKXxAADcjw > 0f);
				}

				public virtual void sLGAPgzdnitzylkGuNIYOOeuyJxR()
				{
					aymGtXXbiLGeRgpOKYsUOYaadiYXA();
					iOVIYymHJloklXxfhFHKXxAADcjw = 0f;
					CYwhZgwfscfavVMmYaKvmQbZKDLH = 0f;
				}
			}

			public ZpzuyyQVSArvOCQjtzMTlcPUCJlN(UpdateLoopSetting P_0, bool P_1)
				: base(P_0)
			{
				for (int i = 0; i < sJoeVPayZHWVqtPfLzweFKbBdnBGA; i++)
				{
					if (P_1)
					{
						qHIMKRfYkfOIchsnBzruGyDqtXfe[i] = new gtCnydrdBKfabBvflDLPLCSAMNAFA();
					}
					else
					{
						qHIMKRfYkfOIchsnBzruGyDqtXfe[i] = new tYFipRbROsPCujECItFiNqyBOGvS();
					}
				}
				gxGFQicLBXORlUsOGjTlHwlUPDQqA = qHIMKRfYkfOIchsnBzruGyDqtXfe[0];
			}

			public void zHKUNvnBKSFhIivKFwoQadolyfRi(float P_0)
			{
				for (int i = 0; i < qHIMKRfYkfOIchsnBzruGyDqtXfe.Length; i++)
				{
					((tYFipRbROsPCujECItFiNqyBOGvS)qHIMKRfYkfOIchsnBzruGyDqtXfe[i]).FIveEJJNZBWuZJGjvISBGPcKttxAB.mrdkOOXKetcOXzmtzgIREniIKIzL(P_0);
				}
			}

			public void AuuXMOHqEslvWXtJHoWKESlBKafi()
			{
				for (int i = 0; i < qHIMKRfYkfOIchsnBzruGyDqtXfe.Length; i++)
				{
					((tYFipRbROsPCujECItFiNqyBOGvS)qHIMKRfYkfOIchsnBzruGyDqtXfe[i]).FIveEJJNZBWuZJGjvISBGPcKttxAB.mrdkOOXKetcOXzmtzgIREniIKIzL(0.3f);
				}
			}
		}

		internal readonly bool SAKvIjtYeGnOExEYTqzaGXSoLuCp;

		internal readonly HardwareButtonInfo ZwbvvSboCZTKwwDVZHEoQwJMKeRr;

		public bool valuePrev
		{
			get
			{
				if (ReInput._id != GAxcZwbHqTeMSxoiEJZbiyufHrQGA)
				{
					ReInput.CheckInitialized(GAxcZwbHqTeMSxoiEJZbiyufHrQGA);
					return false;
				}
				return ((ZpzuyyQVSArvOCQjtzMTlcPUCJlN.tYFipRbROsPCujECItFiNqyBOGvS)DdTOJXDMRSyKMkhHBULqqZxplZGB.gxGFQicLBXORlUsOGjTlHwlUPDQqA).NbioomLnVezQJLSvfDWHKYVqWHeb;
			}
		}

		public bool value
		{
			get
			{
				if (ReInput._id != GAxcZwbHqTeMSxoiEJZbiyufHrQGA)
				{
					ReInput.CheckInitialized(GAxcZwbHqTeMSxoiEJZbiyufHrQGA);
					return false;
				}
				return ((ZpzuyyQVSArvOCQjtzMTlcPUCJlN.tYFipRbROsPCujECItFiNqyBOGvS)DdTOJXDMRSyKMkhHBULqqZxplZGB.gxGFQicLBXORlUsOGjTlHwlUPDQqA).QErghnjAwMILzdPtZKNEaQIlXzDAA;
			}
		}

		public float pressure
		{
			get
			{
				if (ReInput._id != GAxcZwbHqTeMSxoiEJZbiyufHrQGA)
				{
					ReInput.CheckInitialized(GAxcZwbHqTeMSxoiEJZbiyufHrQGA);
					return 0f;
				}
				if (!SAKvIjtYeGnOExEYTqzaGXSoLuCp)
				{
					if (!((ZpzuyyQVSArvOCQjtzMTlcPUCJlN.tYFipRbROsPCujECItFiNqyBOGvS)DdTOJXDMRSyKMkhHBULqqZxplZGB.gxGFQicLBXORlUsOGjTlHwlUPDQqA).QErghnjAwMILzdPtZKNEaQIlXzDAA)
					{
						return 0f;
					}
					return 1f;
				}
				return ((ZpzuyyQVSArvOCQjtzMTlcPUCJlN.gtCnydrdBKfabBvflDLPLCSAMNAFA)DdTOJXDMRSyKMkhHBULqqZxplZGB.gxGFQicLBXORlUsOGjTlHwlUPDQqA).iOVIYymHJloklXxfhFHKXxAADcjw;
			}
		}

		public float pressurePrev
		{
			get
			{
				if (ReInput._id != GAxcZwbHqTeMSxoiEJZbiyufHrQGA)
				{
					ReInput.CheckInitialized(GAxcZwbHqTeMSxoiEJZbiyufHrQGA);
					return 0f;
				}
				if (!SAKvIjtYeGnOExEYTqzaGXSoLuCp)
				{
					if (!((ZpzuyyQVSArvOCQjtzMTlcPUCJlN.tYFipRbROsPCujECItFiNqyBOGvS)DdTOJXDMRSyKMkhHBULqqZxplZGB.gxGFQicLBXORlUsOGjTlHwlUPDQqA).NbioomLnVezQJLSvfDWHKYVqWHeb)
					{
						return 0f;
					}
					return 1f;
				}
				return ((ZpzuyyQVSArvOCQjtzMTlcPUCJlN.gtCnydrdBKfabBvflDLPLCSAMNAFA)DdTOJXDMRSyKMkhHBULqqZxplZGB.gxGFQicLBXORlUsOGjTlHwlUPDQqA).CYwhZgwfscfavVMmYaKvmQbZKDLH;
			}
		}

		public bool isPressureSensitive
		{
			get
			{
				if (ReInput._id != GAxcZwbHqTeMSxoiEJZbiyufHrQGA)
				{
					ReInput.CheckInitialized(GAxcZwbHqTeMSxoiEJZbiyufHrQGA);
					return false;
				}
				return SAKvIjtYeGnOExEYTqzaGXSoLuCp;
			}
		}

		public bool justPressed
		{
			get
			{
				if (ReInput._id != GAxcZwbHqTeMSxoiEJZbiyufHrQGA)
				{
					ReInput.CheckInitialized(GAxcZwbHqTeMSxoiEJZbiyufHrQGA);
					return false;
				}
				if (!((ZpzuyyQVSArvOCQjtzMTlcPUCJlN.tYFipRbROsPCujECItFiNqyBOGvS)DdTOJXDMRSyKMkhHBULqqZxplZGB.gxGFQicLBXORlUsOGjTlHwlUPDQqA).NbioomLnVezQJLSvfDWHKYVqWHeb && ((ZpzuyyQVSArvOCQjtzMTlcPUCJlN.tYFipRbROsPCujECItFiNqyBOGvS)DdTOJXDMRSyKMkhHBULqqZxplZGB.gxGFQicLBXORlUsOGjTlHwlUPDQqA).QErghnjAwMILzdPtZKNEaQIlXzDAA)
				{
					return true;
				}
				return false;
			}
		}

		public bool justReleased
		{
			get
			{
				if (ReInput._id != GAxcZwbHqTeMSxoiEJZbiyufHrQGA)
				{
					ReInput.CheckInitialized(GAxcZwbHqTeMSxoiEJZbiyufHrQGA);
					return false;
				}
				if (((ZpzuyyQVSArvOCQjtzMTlcPUCJlN.tYFipRbROsPCujECItFiNqyBOGvS)DdTOJXDMRSyKMkhHBULqqZxplZGB.gxGFQicLBXORlUsOGjTlHwlUPDQqA).NbioomLnVezQJLSvfDWHKYVqWHeb && !((ZpzuyyQVSArvOCQjtzMTlcPUCJlN.tYFipRbROsPCujECItFiNqyBOGvS)DdTOJXDMRSyKMkhHBULqqZxplZGB.gxGFQicLBXORlUsOGjTlHwlUPDQqA).QErghnjAwMILzdPtZKNEaQIlXzDAA)
				{
					return true;
				}
				return false;
			}
		}

		public bool justChangedState
		{
			get
			{
				if (ReInput._id != GAxcZwbHqTeMSxoiEJZbiyufHrQGA)
				{
					ReInput.CheckInitialized(GAxcZwbHqTeMSxoiEJZbiyufHrQGA);
					return false;
				}
				if (((ZpzuyyQVSArvOCQjtzMTlcPUCJlN.tYFipRbROsPCujECItFiNqyBOGvS)DdTOJXDMRSyKMkhHBULqqZxplZGB.gxGFQicLBXORlUsOGjTlHwlUPDQqA).NbioomLnVezQJLSvfDWHKYVqWHeb != ((ZpzuyyQVSArvOCQjtzMTlcPUCJlN.tYFipRbROsPCujECItFiNqyBOGvS)DdTOJXDMRSyKMkhHBULqqZxplZGB.gxGFQicLBXORlUsOGjTlHwlUPDQqA).QErghnjAwMILzdPtZKNEaQIlXzDAA)
				{
					return true;
				}
				return false;
			}
		}

		public bool doublePressedAndHeld
		{
			get
			{
				if (ReInput._id != GAxcZwbHqTeMSxoiEJZbiyufHrQGA)
				{
					ReInput.CheckInitialized(GAxcZwbHqTeMSxoiEJZbiyufHrQGA);
					return false;
				}
				return ((ZpzuyyQVSArvOCQjtzMTlcPUCJlN.tYFipRbROsPCujECItFiNqyBOGvS)DdTOJXDMRSyKMkhHBULqqZxplZGB.gxGFQicLBXORlUsOGjTlHwlUPDQqA).FIveEJJNZBWuZJGjvISBGPcKttxAB.strtgfodNfaaTZmAkmQrvujjZEih();
			}
		}

		public bool justDoublePressed
		{
			get
			{
				if (ReInput._id != GAxcZwbHqTeMSxoiEJZbiyufHrQGA)
				{
					ReInput.CheckInitialized(GAxcZwbHqTeMSxoiEJZbiyufHrQGA);
					return false;
				}
				if (!justPressed)
				{
					return false;
				}
				return ((ZpzuyyQVSArvOCQjtzMTlcPUCJlN.tYFipRbROsPCujECItFiNqyBOGvS)DdTOJXDMRSyKMkhHBULqqZxplZGB.gxGFQicLBXORlUsOGjTlHwlUPDQqA).FIveEJJNZBWuZJGjvISBGPcKttxAB.strtgfodNfaaTZmAkmQrvujjZEih();
			}
		}

		public double timePressed
		{
			get
			{
				if (ReInput._id != GAxcZwbHqTeMSxoiEJZbiyufHrQGA)
				{
					ReInput.CheckInitialized(GAxcZwbHqTeMSxoiEJZbiyufHrQGA);
					return 0.0;
				}
				return ((ZpzuyyQVSArvOCQjtzMTlcPUCJlN.tYFipRbROsPCujECItFiNqyBOGvS)DdTOJXDMRSyKMkhHBULqqZxplZGB.gxGFQicLBXORlUsOGjTlHwlUPDQqA).wcreJbrsvVkfxtZsWhvhOrBUJzoJ.YaeMAnQxhGbYAzCWFiUFIONgBlOHA();
			}
		}

		public double timeUnpressed
		{
			get
			{
				if (ReInput._id != GAxcZwbHqTeMSxoiEJZbiyufHrQGA)
				{
					ReInput.CheckInitialized(GAxcZwbHqTeMSxoiEJZbiyufHrQGA);
					return 0.0;
				}
				return ((ZpzuyyQVSArvOCQjtzMTlcPUCJlN.tYFipRbROsPCujECItFiNqyBOGvS)DdTOJXDMRSyKMkhHBULqqZxplZGB.gxGFQicLBXORlUsOGjTlHwlUPDQqA).wcreJbrsvVkfxtZsWhvhOrBUJzoJ.KVVmYtKOxOfGGHnsXwNGnkLCbbGF();
			}
		}

		public double lastTimePressed
		{
			get
			{
				if (ReInput._id != GAxcZwbHqTeMSxoiEJZbiyufHrQGA)
				{
					ReInput.CheckInitialized(GAxcZwbHqTeMSxoiEJZbiyufHrQGA);
					return 0.0;
				}
				return ((ZpzuyyQVSArvOCQjtzMTlcPUCJlN.tYFipRbROsPCujECItFiNqyBOGvS)DdTOJXDMRSyKMkhHBULqqZxplZGB.gxGFQicLBXORlUsOGjTlHwlUPDQqA).wcreJbrsvVkfxtZsWhvhOrBUJzoJ.EoSUVtLKzuqRbtzJkSGGmnHyWiYI();
			}
		}

		public double lastTimeUnpressed
		{
			get
			{
				if (ReInput._id != GAxcZwbHqTeMSxoiEJZbiyufHrQGA)
				{
					ReInput.CheckInitialized(GAxcZwbHqTeMSxoiEJZbiyufHrQGA);
					return 0.0;
				}
				return ((ZpzuyyQVSArvOCQjtzMTlcPUCJlN.tYFipRbROsPCujECItFiNqyBOGvS)DdTOJXDMRSyKMkhHBULqqZxplZGB.gxGFQicLBXORlUsOGjTlHwlUPDQqA).wcreJbrsvVkfxtZsWhvhOrBUJzoJ.fWbMdrSlmUgzIkpPgDWdYMDcVokn();
			}
		}

		public double lastTimeStateChanged
		{
			get
			{
				if (ReInput._id != GAxcZwbHqTeMSxoiEJZbiyufHrQGA)
				{
					ReInput.CheckInitialized(GAxcZwbHqTeMSxoiEJZbiyufHrQGA);
					return 0.0;
				}
				return ((ZpzuyyQVSArvOCQjtzMTlcPUCJlN.tYFipRbROsPCujECItFiNqyBOGvS)DdTOJXDMRSyKMkhHBULqqZxplZGB.gxGFQicLBXORlUsOGjTlHwlUPDQqA).wcreJbrsvVkfxtZsWhvhOrBUJzoJ.SzjWdvZbDPUpXibrAgskXaxWouWX();
			}
		}

		internal ButtonStateFlags juULaEZnHsAqYbCygfUfBIjBOquTB => vMUPkwNHSPZVxWIOFtIuXYsDsSTu();

		internal ButtonStateFlags vMUPkwNHSPZVxWIOFtIuXYsDsSTu()
		{
			ZpzuyyQVSArvOCQjtzMTlcPUCJlN.tYFipRbROsPCujECItFiNqyBOGvS tYFipRbROsPCujECItFiNqyBOGvS = (ZpzuyyQVSArvOCQjtzMTlcPUCJlN.tYFipRbROsPCujECItFiNqyBOGvS)DdTOJXDMRSyKMkhHBULqqZxplZGB.gxGFQicLBXORlUsOGjTlHwlUPDQqA;
			ButtonStateFlags buttonStateFlags = ButtonStateFlags.Off;
			if (tYFipRbROsPCujECItFiNqyBOGvS.QErghnjAwMILzdPtZKNEaQIlXzDAA)
			{
				buttonStateFlags |= ButtonStateFlags.On;
				if (!tYFipRbROsPCujECItFiNqyBOGvS.NbioomLnVezQJLSvfDWHKYVqWHeb)
				{
					buttonStateFlags |= ButtonStateFlags.Down;
				}
			}
			else if (tYFipRbROsPCujECItFiNqyBOGvS.NbioomLnVezQJLSvfDWHKYVqWHeb)
			{
				buttonStateFlags |= ButtonStateFlags.Up;
			}
			return buttonStateFlags;
		}

		internal Button(Controller P_0, int P_1, string P_2, HardwareButtonInfo P_3)
			: base(P_0, P_1, P_2, ControllerElementType.Button)
		{
			ZwbvvSboCZTKwwDVZHEoQwJMKeRr = P_3;
			DdTOJXDMRSyKMkhHBULqqZxplZGB = new ZpzuyyQVSArvOCQjtzMTlcPUCJlN(ReInput.configVars.updateLoop, false);
		}

		internal Button(Controller P_0, int P_1, string P_2, bool P_3, HardwareButtonInfo P_4)
			: base(P_0, P_1, P_2, ControllerElementType.Button)
		{
			ZwbvvSboCZTKwwDVZHEoQwJMKeRr = P_4;
			SAKvIjtYeGnOExEYTqzaGXSoLuCp = P_3;
			DdTOJXDMRSyKMkhHBULqqZxplZGB = new ZpzuyyQVSArvOCQjtzMTlcPUCJlN(ReInput.configVars.updateLoop, P_3);
		}

		public bool DoublePressedAndHeld(float speed)
		{
			if (ReInput._id != GAxcZwbHqTeMSxoiEJZbiyufHrQGA)
			{
				ReInput.CheckInitialized(GAxcZwbHqTeMSxoiEJZbiyufHrQGA);
				return false;
			}
			if (speed <= 0f)
			{
				return ((ZpzuyyQVSArvOCQjtzMTlcPUCJlN.tYFipRbROsPCujECItFiNqyBOGvS)DdTOJXDMRSyKMkhHBULqqZxplZGB.gxGFQicLBXORlUsOGjTlHwlUPDQqA).FIveEJJNZBWuZJGjvISBGPcKttxAB.strtgfodNfaaTZmAkmQrvujjZEih();
			}
			return ((ZpzuyyQVSArvOCQjtzMTlcPUCJlN.tYFipRbROsPCujECItFiNqyBOGvS)DdTOJXDMRSyKMkhHBULqqZxplZGB.gxGFQicLBXORlUsOGjTlHwlUPDQqA).wcreJbrsvVkfxtZsWhvhOrBUJzoJ.XNywcCbIkQieiRQjIjPvCdxEeAjy(speed);
		}

		public bool JustDoublePressed(float speed)
		{
			if (ReInput._id != GAxcZwbHqTeMSxoiEJZbiyufHrQGA)
			{
				ReInput.CheckInitialized(GAxcZwbHqTeMSxoiEJZbiyufHrQGA);
				return false;
			}
			if (!justPressed)
			{
				return false;
			}
			if (speed <= 0f)
			{
				return ((ZpzuyyQVSArvOCQjtzMTlcPUCJlN.tYFipRbROsPCujECItFiNqyBOGvS)DdTOJXDMRSyKMkhHBULqqZxplZGB.gxGFQicLBXORlUsOGjTlHwlUPDQqA).FIveEJJNZBWuZJGjvISBGPcKttxAB.strtgfodNfaaTZmAkmQrvujjZEih();
			}
			return ((ZpzuyyQVSArvOCQjtzMTlcPUCJlN.tYFipRbROsPCujECItFiNqyBOGvS)DdTOJXDMRSyKMkhHBULqqZxplZGB.gxGFQicLBXORlUsOGjTlHwlUPDQqA).wcreJbrsvVkfxtZsWhvhOrBUJzoJ.XNywcCbIkQieiRQjIjPvCdxEeAjy(speed);
		}

		internal void OnsYqlJnwMAVWAIfTSVljurlKtAhA(UpdateLoopType P_0, int P_1, ControllerDataUpdater P_2)
		{
			if (DdTOJXDMRSyKMkhHBULqqZxplZGB != null && DdTOJXDMRSyKMkhHBULqqZxplZGB.JLRfRkCNcsdrlUUfoPyPaXwdGlUPA != (int)P_0)
			{
				DdTOJXDMRSyKMkhHBULqqZxplZGB.nMlkfodLycuKedEJdBchxmVGsvpN(P_0);
			}
			if (SAKvIjtYeGnOExEYTqzaGXSoLuCp)
			{
				((ZpzuyyQVSArvOCQjtzMTlcPUCJlN.gtCnydrdBKfabBvflDLPLCSAMNAFA)DdTOJXDMRSyKMkhHBULqqZxplZGB.gxGFQicLBXORlUsOGjTlHwlUPDQqA).sGiDbItejlumUSwOevyPTQrlwFTJ(P_2.buttonPressureValues[P_1]);
			}
			else
			{
				((ZpzuyyQVSArvOCQjtzMTlcPUCJlN.tYFipRbROsPCujECItFiNqyBOGvS)DdTOJXDMRSyKMkhHBULqqZxplZGB.gxGFQicLBXORlUsOGjTlHwlUPDQqA).zdECzQDRfFrnHCFzGmGUqNChgSGPC(P_2.buttonValues[P_1]);
			}
		}

		internal void ayoSbTBKdWFDfwETsGdYmfBaQPdi(UpdateLoopType P_0)
		{
			if (DdTOJXDMRSyKMkhHBULqqZxplZGB != null && DdTOJXDMRSyKMkhHBULqqZxplZGB.JLRfRkCNcsdrlUUfoPyPaXwdGlUPA != (int)P_0)
			{
				DdTOJXDMRSyKMkhHBULqqZxplZGB.nMlkfodLycuKedEJdBchxmVGsvpN(P_0);
			}
			if (SAKvIjtYeGnOExEYTqzaGXSoLuCp)
			{
				((ZpzuyyQVSArvOCQjtzMTlcPUCJlN.gtCnydrdBKfabBvflDLPLCSAMNAFA)DdTOJXDMRSyKMkhHBULqqZxplZGB.gxGFQicLBXORlUsOGjTlHwlUPDQqA).sGiDbItejlumUSwOevyPTQrlwFTJ(0f);
			}
			else
			{
				((ZpzuyyQVSArvOCQjtzMTlcPUCJlN.tYFipRbROsPCujECItFiNqyBOGvS)DdTOJXDMRSyKMkhHBULqqZxplZGB.gxGFQicLBXORlUsOGjTlHwlUPDQqA).zdECzQDRfFrnHCFzGmGUqNChgSGPC(false);
			}
		}

		internal void gLprAiHqqovXxhwUIcvcAOfyeHRe()
		{
			for (int i = 0; i < DdTOJXDMRSyKMkhHBULqqZxplZGB.WzGMjrWQdSLAOuBFvvLzqySXgAYp().Count; i++)
			{
				HVaCmzenJEpZviDSrzTIsmgjVVKO.WmdFxDRKmnRhoRqVdoQUUoKTDBTO wmdFxDRKmnRhoRqVdoQUUoKTDBTO = DdTOJXDMRSyKMkhHBULqqZxplZGB.WzGMjrWQdSLAOuBFvvLzqySXgAYp()[i];
				if (wmdFxDRKmnRhoRqVdoQUUoKTDBTO != null)
				{
					if (SAKvIjtYeGnOExEYTqzaGXSoLuCp)
					{
						((ZpzuyyQVSArvOCQjtzMTlcPUCJlN.gtCnydrdBKfabBvflDLPLCSAMNAFA)wmdFxDRKmnRhoRqVdoQUUoKTDBTO).sGiDbItejlumUSwOevyPTQrlwFTJ(0f);
					}
					else
					{
						((ZpzuyyQVSArvOCQjtzMTlcPUCJlN.tYFipRbROsPCujECItFiNqyBOGvS)wmdFxDRKmnRhoRqVdoQUUoKTDBTO).zdECzQDRfFrnHCFzGmGUqNChgSGPC(false);
					}
				}
			}
		}
	}

	public abstract class CompoundElement
	{
		private class WwQVJsHRFxSGJjGYLftIGwCpWAvcA
		{
			public readonly Element IrhOmGzUOmTjvckQumThVAGKOgdD;

			public readonly int ntFFZVNBGNkUiqDDzEavNvgsyCaN;

			public WwQVJsHRFxSGJjGYLftIGwCpWAvcA(Element P_0, int P_1)
			{
				IrhOmGzUOmTjvckQumThVAGKOgdD = P_0;
				ntFFZVNBGNkUiqDDzEavNvgsyCaN = P_1;
			}
		}

		private int KDbBXTOFCyOVacxeRYNUVFaKeqxr;

		private string AkmWjAQgLlcMqbJFtnnnGQWFaxdib;

		private CompoundControllerElementType ScDEmxBzJgTRCIexpqEiIKlbiRWOB;

		private int NSLDtVjPPDWKOZRJJFkFdlyjNOCBb;

		private WwQVJsHRFxSGJjGYLftIGwCpWAvcA[] zHnfdlVZprcCIVLXzeTuMMavfTdFA;

		private Controller hkxrlLNwowEWdXTUiQKxCGFnUiFU;

		internal readonly int LYzEbajOGnkywnCbAtDhNmRiHxxCb;

		public int id
		{
			get
			{
				if (ReInput._id != LYzEbajOGnkywnCbAtDhNmRiHxxCb)
				{
					ReInput.CheckInitialized(LYzEbajOGnkywnCbAtDhNmRiHxxCb);
					return -1;
				}
				return KDbBXTOFCyOVacxeRYNUVFaKeqxr;
			}
		}

		public string name
		{
			get
			{
				if (ReInput._id != LYzEbajOGnkywnCbAtDhNmRiHxxCb)
				{
					ReInput.CheckInitialized(LYzEbajOGnkywnCbAtDhNmRiHxxCb);
					return string.Empty;
				}
				return AkmWjAQgLlcMqbJFtnnnGQWFaxdib;
			}
		}

		public CompoundControllerElementType type
		{
			get
			{
				if (ReInput._id != LYzEbajOGnkywnCbAtDhNmRiHxxCb)
				{
					ReInput.CheckInitialized(LYzEbajOGnkywnCbAtDhNmRiHxxCb);
					return CompoundControllerElementType.Axis2D;
				}
				return ScDEmxBzJgTRCIexpqEiIKlbiRWOB;
			}
		}

		public bool hasElements
		{
			get
			{
				if (ReInput._id != LYzEbajOGnkywnCbAtDhNmRiHxxCb)
				{
					ReInput.CheckInitialized(LYzEbajOGnkywnCbAtDhNmRiHxxCb);
					return false;
				}
				return NSLDtVjPPDWKOZRJJFkFdlyjNOCBb > 0;
			}
		}

		public int elementCount
		{
			get
			{
				if (ReInput._id != LYzEbajOGnkywnCbAtDhNmRiHxxCb)
				{
					ReInput.CheckInitialized(LYzEbajOGnkywnCbAtDhNmRiHxxCb);
					return 0;
				}
				return NSLDtVjPPDWKOZRJJFkFdlyjNOCBb;
			}
		}

		public abstract int elementCapacity { get; }

		public ControllerElementIdentifier elementIdentifier
		{
			get
			{
				if (ReInput._id != LYzEbajOGnkywnCbAtDhNmRiHxxCb)
				{
					ReInput.CheckInitialized(LYzEbajOGnkywnCbAtDhNmRiHxxCb);
					return null;
				}
				ControllerElementIdentifier elementIdentifierById = hkxrlLNwowEWdXTUiQKxCGFnUiFU.GetElementIdentifierById(KDbBXTOFCyOVacxeRYNUVFaKeqxr);
				if (elementIdentifierById == null)
				{
					return ControllerElementIdentifier.BlankReadOnly;
				}
				return elementIdentifierById;
			}
		}

		internal CompoundElement(Controller P_0, int P_1, string P_2, CompoundControllerElementType P_3)
		{
			hkxrlLNwowEWdXTUiQKxCGFnUiFU = P_0;
			KDbBXTOFCyOVacxeRYNUVFaKeqxr = P_1;
			AkmWjAQgLlcMqbJFtnnnGQWFaxdib = P_2;
			ScDEmxBzJgTRCIexpqEiIKlbiRWOB = P_3;
			zHnfdlVZprcCIVLXzeTuMMavfTdFA = new WwQVJsHRFxSGJjGYLftIGwCpWAvcA[elementCapacity];
			LYzEbajOGnkywnCbAtDhNmRiHxxCb = ReInput.id;
		}

		internal Element TfuvoEqzTjlRFoPHoRhtebDcVtaI(int P_0)
		{
			if (P_0 < 0 || P_0 >= zHnfdlVZprcCIVLXzeTuMMavfTdFA.Length)
			{
				return null;
			}
			if (zHnfdlVZprcCIVLXzeTuMMavfTdFA[P_0] == null)
			{
				return null;
			}
			return zHnfdlVZprcCIVLXzeTuMMavfTdFA[P_0].IrhOmGzUOmTjvckQumThVAGKOgdD;
		}

		internal _0001 TfuvoEqzTjlRFoPHoRhtebDcVtaI<_0001>(int P_0) where _0001 : Element
		{
			if (P_0 < 0 || P_0 >= zHnfdlVZprcCIVLXzeTuMMavfTdFA.Length)
			{
				return null;
			}
			if (zHnfdlVZprcCIVLXzeTuMMavfTdFA[P_0] == null)
			{
				return null;
			}
			return zHnfdlVZprcCIVLXzeTuMMavfTdFA[P_0].IrhOmGzUOmTjvckQumThVAGKOgdD as _0001;
		}

		internal _0001 GvTBLeKIfIuasPqBldSpffgfKVaYB<_0001>(int P_0, out int P_1) where _0001 : Element
		{
			P_1 = -1;
			if (P_0 < 0 || P_0 >= zHnfdlVZprcCIVLXzeTuMMavfTdFA.Length)
			{
				return null;
			}
			if (zHnfdlVZprcCIVLXzeTuMMavfTdFA[P_0] == null)
			{
				return null;
			}
			P_1 = zHnfdlVZprcCIVLXzeTuMMavfTdFA[P_0].ntFFZVNBGNkUiqDDzEavNvgsyCaN;
			return zHnfdlVZprcCIVLXzeTuMMavfTdFA[P_0].IrhOmGzUOmTjvckQumThVAGKOgdD as _0001;
		}

		internal bool gVsWoztwNdqhzRbgoHqqplJqELigA(Element P_0, int P_1)
		{
			if (P_0 == null)
			{
				return false;
			}
			if (NSLDtVjPPDWKOZRJJFkFdlyjNOCBb >= elementCapacity)
			{
				Logger.LogWarning("Cannot add element! This Compound Element already contains the maximum number of elements.");
				return false;
			}
			if (P_0.isMemberElement)
			{
				Logger.LogWarning("Cannot add element! The element you are trying to add is already a member of another compound element.");
				return false;
			}
			if (CaULxpsbksbhyibUQXhHuyFZMkdp(P_0) >= 0)
			{
				Logger.LogWarning("Cannot add element! This Compound Element already contains the element you are trying to add.");
				return false;
			}
			int num = oTtxJqRTCGhOanjxhzNesKUVnxLk();
			if (num < 0)
			{
				Logger.LogWarning("Cannot add element! This Compound Element already contains the maximum number of elements.");
				return false;
			}
			return BxQoREtqEYNnoABJxKCZUZlLTTjV(P_0, P_1, num);
		}

		internal bool iUJMePRaEJOJCVoGTZtOrGFxrdFk(Element P_0)
		{
			if (P_0 == null)
			{
				return false;
			}
			if (NSLDtVjPPDWKOZRJJFkFdlyjNOCBb == 0)
			{
				Logger.LogWarning("Cannot remove element! This Compound Element has no elements.");
				return false;
			}
			int num = CaULxpsbksbhyibUQXhHuyFZMkdp(P_0);
			if (num < 0)
			{
				Logger.LogWarning("Cannot remove element! This Compound Element does not contain the element you are trying to remove.");
				return false;
			}
			return vdGitcfyyjJlNrzxjpURNSMdBiSIb(num);
		}

		internal void HKkqOAzRQzMGFhiAvVefXaculgas()
		{
			for (int i = 0; i < zHnfdlVZprcCIVLXzeTuMMavfTdFA.Length; i++)
			{
				vdGitcfyyjJlNrzxjpURNSMdBiSIb(i);
			}
			NSLDtVjPPDWKOZRJJFkFdlyjNOCBb = 0;
		}

		private int CaULxpsbksbhyibUQXhHuyFZMkdp(Element P_0)
		{
			if (P_0 == null)
			{
				return -1;
			}
			for (int i = 0; i < zHnfdlVZprcCIVLXzeTuMMavfTdFA.Length; i++)
			{
				if (zHnfdlVZprcCIVLXzeTuMMavfTdFA[i] != null && zHnfdlVZprcCIVLXzeTuMMavfTdFA[i].IrhOmGzUOmTjvckQumThVAGKOgdD == P_0)
				{
					return i;
				}
			}
			return -1;
		}

		private bool BxQoREtqEYNnoABJxKCZUZlLTTjV(Element P_0, int P_1, int P_2)
		{
			if (P_2 < 0 || P_2 >= zHnfdlVZprcCIVLXzeTuMMavfTdFA.Length)
			{
				return false;
			}
			if (zHnfdlVZprcCIVLXzeTuMMavfTdFA[P_2] != null)
			{
				return false;
			}
			zHnfdlVZprcCIVLXzeTuMMavfTdFA[P_2] = new WwQVJsHRFxSGJjGYLftIGwCpWAvcA(P_0, P_1);
			P_0.WMhBsxeHGODmfHfvANCWYkEfaqUp(this);
			NSLDtVjPPDWKOZRJJFkFdlyjNOCBb++;
			return true;
		}

		private bool vdGitcfyyjJlNrzxjpURNSMdBiSIb(int P_0)
		{
			if (P_0 < 0 || P_0 >= zHnfdlVZprcCIVLXzeTuMMavfTdFA.Length)
			{
				return false;
			}
			if (zHnfdlVZprcCIVLXzeTuMMavfTdFA[P_0] == null)
			{
				return false;
			}
			if (zHnfdlVZprcCIVLXzeTuMMavfTdFA[P_0].IrhOmGzUOmTjvckQumThVAGKOgdD != null)
			{
				zHnfdlVZprcCIVLXzeTuMMavfTdFA[P_0].IrhOmGzUOmTjvckQumThVAGKOgdD.RLMFwJguHCpPwIgpewCzgFhIsohRe(this);
			}
			zHnfdlVZprcCIVLXzeTuMMavfTdFA[P_0] = null;
			NSLDtVjPPDWKOZRJJFkFdlyjNOCBb--;
			return true;
		}

		private int oTtxJqRTCGhOanjxhzNesKUVnxLk()
		{
			for (int i = 0; i < zHnfdlVZprcCIVLXzeTuMMavfTdFA.Length; i++)
			{
				if (zHnfdlVZprcCIVLXzeTuMMavfTdFA[i] == null)
				{
					return i;
				}
			}
			return -1;
		}
	}

	public sealed class Axis2D : CompoundElement
	{
		private const int RTHvRCfGogsgoerkTDtHdkUSNEgA = 2;

		private CalibrationMap INFcBHzLcfNSvlzuUBnGlwtlSwde;

		int CompoundElement.elementCapacity => get_elementCapacity();

		public Axis xAxis
		{
			get
			{
				if (ReInput._id != LYzEbajOGnkywnCbAtDhNmRiHxxCb)
				{
					ReInput.CheckInitialized(LYzEbajOGnkywnCbAtDhNmRiHxxCb);
					return null;
				}
				return TfuvoEqzTjlRFoPHoRhtebDcVtaI<Axis>(0);
			}
		}

		public Axis yAxis
		{
			get
			{
				if (ReInput._id != LYzEbajOGnkywnCbAtDhNmRiHxxCb)
				{
					ReInput.CheckInitialized(LYzEbajOGnkywnCbAtDhNmRiHxxCb);
					return null;
				}
				return TfuvoEqzTjlRFoPHoRhtebDcVtaI<Axis>(1);
			}
		}

		public Vector2 value
		{
			get
			{
				if (ReInput._id != LYzEbajOGnkywnCbAtDhNmRiHxxCb)
				{
					ReInput.CheckInitialized(LYzEbajOGnkywnCbAtDhNmRiHxxCb);
					return Vector2.zero;
				}
				return KewtfdtJBNjwfODqEorXMjtnehnP();
			}
		}

		public Vector2 valuePrev
		{
			get
			{
				if (ReInput._id != LYzEbajOGnkywnCbAtDhNmRiHxxCb)
				{
					ReInput.CheckInitialized(LYzEbajOGnkywnCbAtDhNmRiHxxCb);
					return Vector2.zero;
				}
				return rBMWHZXwHTlKdnCvGXfctrVhkhFi();
			}
		}

		public Vector2 valueRaw
		{
			get
			{
				if (ReInput._id != LYzEbajOGnkywnCbAtDhNmRiHxxCb)
				{
					ReInput.CheckInitialized(LYzEbajOGnkywnCbAtDhNmRiHxxCb);
					return Vector2.zero;
				}
				return new Vector2((xAxis != null) ? xAxis.valueRaw : 0f, (yAxis != null) ? yAxis.valueRaw : 0f);
			}
		}

		public Vector2 valueRawPrev
		{
			get
			{
				if (ReInput._id != LYzEbajOGnkywnCbAtDhNmRiHxxCb)
				{
					ReInput.CheckInitialized(LYzEbajOGnkywnCbAtDhNmRiHxxCb);
					return Vector2.zero;
				}
				return new Vector2((xAxis != null) ? xAxis.valueRawPrev : 0f, (yAxis != null) ? yAxis.valueRawPrev : 0f);
			}
		}

		public int get_elementCapacity()
		{
			return 2;
		}

		internal Axis2D(Controller P_0, int P_1, string P_2, Axis P_3, Axis P_4, int P_5, int P_6, CalibrationMap P_7)
			: base(P_0, P_1, P_2, CompoundControllerElementType.Axis2D)
		{
			gVsWoztwNdqhzRbgoHqqplJqELigA(P_3, P_5);
			gVsWoztwNdqhzRbgoHqqplJqELigA(P_4, P_6);
			INFcBHzLcfNSvlzuUBnGlwtlSwde = P_7;
		}

		internal void RUtFfULuhsgUyClAtfAwvvnERgpL()
		{
			Vector2 vector = value;
			if (xAxis != null)
			{
				xAxis.eIKzLOjWhbGPWJwIccMalYOuVgeC(vector.x);
			}
			if (yAxis != null)
			{
				yAxis.eIKzLOjWhbGPWJwIccMalYOuVgeC(vector.y);
			}
		}

		private Vector2 KewtfdtJBNjwfODqEorXMjtnehnP()
		{
			if (INFcBHzLcfNSvlzuUBnGlwtlSwde == null)
			{
				return default;
			}
			Axis axis = GvTBLeKIfIuasPqBldSpffgfKVaYB<Axis>(0, out var xAxisIndex);
			Axis axis2 = GvTBLeKIfIuasPqBldSpffgfKVaYB<Axis>(1, out var yAxisIndex);
			DeadZone2DType defaultJoystickAxis2DDeadZoneType = ReInput.configVars.defaultJoystickAxis2DDeadZoneType;
			AxisSensitivity2DType defaultJoystickAxis2DSensitivityType = ReInput.configVars.defaultJoystickAxis2DSensitivityType;
			float valueRawX = axis?.valueRaw ?? 0f;
			float valueRawY = axis2?.valueRaw ?? 0f;
			return INFcBHzLcfNSvlzuUBnGlwtlSwde.GetCalibrated2DValue(xAxisIndex, yAxisIndex, valueRawX, valueRawY, defaultJoystickAxis2DDeadZoneType, defaultJoystickAxis2DSensitivityType);
		}

		private Vector2 rBMWHZXwHTlKdnCvGXfctrVhkhFi()
		{
			if (INFcBHzLcfNSvlzuUBnGlwtlSwde == null)
			{
				return default;
			}
			Axis axis = GvTBLeKIfIuasPqBldSpffgfKVaYB<Axis>(0, out var xAxisIndex);
			Axis axis2 = GvTBLeKIfIuasPqBldSpffgfKVaYB<Axis>(1, out var yAxisIndex);
			DeadZone2DType defaultJoystickAxis2DDeadZoneType = ReInput.configVars.defaultJoystickAxis2DDeadZoneType;
			AxisSensitivity2DType defaultJoystickAxis2DSensitivityType = ReInput.configVars.defaultJoystickAxis2DSensitivityType;
			float valueRawX = axis?.valueRawPrev ?? 0f;
			float valueRawY = axis2?.valueRawPrev ?? 0f;
			return INFcBHzLcfNSvlzuUBnGlwtlSwde.GetCalibrated2DValue(xAxisIndex, yAxisIndex, valueRawX, valueRawY, defaultJoystickAxis2DDeadZoneType, defaultJoystickAxis2DSensitivityType);
		}
	}

	public sealed class Hat : CompoundElement
	{
		private const int agIrHQczphqoHYKeDHCGspiVqhUP = 8;

		private const int lDLhkfyqVVQrfhNLqAFKIRQBOAbAA = 0;

		private const int QfeigOOSWSWomIeRZqQvQOKPFIwCA = 1;

		private const int iEuAXXHmuxQjXUGutJKNEcaVHzOA = 2;

		private const int OuqxwuXpDxhNpVGrhJxEKZCSHJGw = 3;

		private const int djCdpKAHXPDcOsEiyJWtaieqBDvKA = 4;

		private const int lbOcotZQNLwkJeFNhDJEaYYxqXQPA = 5;

		private const int qOfForNWhlIFNCHmTFsltFPIPGnDb = 6;

		private const int WNFelckElQlfybNUHshqFCnACYXzB = 7;

		private readonly int hGpblSdzhekFyCAxdlLbmAmkdlhRA;

		private readonly Button[] HAZJYLrJzYKpfqotHgDJfuLvKOLvA;

		private readonly ReadOnlyCollection<Button> eEiVPvktkXuoELOPjiLCCvowMrzE;

		private readonly int[] izdXvucQxxHuFShxWHABTyLYrnBu;

		private bool mWreohhkHcNaYInXkcPXHalydlrac;

		int CompoundElement.elementCapacity => get_elementCapacity();

		public bool force4Way
		{
			get
			{
				if (ReInput._id != LYzEbajOGnkywnCbAtDhNmRiHxxCb)
				{
					ReInput.CheckInitialized(LYzEbajOGnkywnCbAtDhNmRiHxxCb);
					return false;
				}
				return mWreohhkHcNaYInXkcPXHalydlrac;
			}
			set
			{
				if (ReInput._id != LYzEbajOGnkywnCbAtDhNmRiHxxCb)
				{
					ReInput.CheckInitialized(LYzEbajOGnkywnCbAtDhNmRiHxxCb);
				}
				else
				{
					mWreohhkHcNaYInXkcPXHalydlrac = value;
				}
			}
		}

		public int directionCount
		{
			get
			{
				if (ReInput._id != LYzEbajOGnkywnCbAtDhNmRiHxxCb)
				{
					ReInput.CheckInitialized(LYzEbajOGnkywnCbAtDhNmRiHxxCb);
					return 0;
				}
				return hGpblSdzhekFyCAxdlLbmAmkdlhRA;
			}
		}

		public IList<Button> Buttons
		{
			get
			{
				if (ReInput._id != LYzEbajOGnkywnCbAtDhNmRiHxxCb)
				{
					ReInput.CheckInitialized(LYzEbajOGnkywnCbAtDhNmRiHxxCb);
					return EmptyObjects<Button>.EmptyReadOnlyIListT;
				}
				return eEiVPvktkXuoELOPjiLCCvowMrzE;
			}
		}

		public Button buttonUp
		{
			get
			{
				if (ReInput._id != LYzEbajOGnkywnCbAtDhNmRiHxxCb)
				{
					ReInput.CheckInitialized(LYzEbajOGnkywnCbAtDhNmRiHxxCb);
					return null;
				}
				return TfuvoEqzTjlRFoPHoRhtebDcVtaI<Button>(0);
			}
		}

		public Button buttonRight
		{
			get
			{
				if (ReInput._id != LYzEbajOGnkywnCbAtDhNmRiHxxCb)
				{
					ReInput.CheckInitialized(LYzEbajOGnkywnCbAtDhNmRiHxxCb);
					return null;
				}
				return TfuvoEqzTjlRFoPHoRhtebDcVtaI<Button>(2);
			}
		}

		public Button buttonDown
		{
			get
			{
				if (ReInput._id != LYzEbajOGnkywnCbAtDhNmRiHxxCb)
				{
					ReInput.CheckInitialized(LYzEbajOGnkywnCbAtDhNmRiHxxCb);
					return null;
				}
				return TfuvoEqzTjlRFoPHoRhtebDcVtaI<Button>(4);
			}
		}

		public Button buttonLeft
		{
			get
			{
				if (ReInput._id != LYzEbajOGnkywnCbAtDhNmRiHxxCb)
				{
					ReInput.CheckInitialized(LYzEbajOGnkywnCbAtDhNmRiHxxCb);
					return null;
				}
				return TfuvoEqzTjlRFoPHoRhtebDcVtaI<Button>(6);
			}
		}

		public Button buttonUpRight
		{
			get
			{
				if (ReInput._id != LYzEbajOGnkywnCbAtDhNmRiHxxCb)
				{
					ReInput.CheckInitialized(LYzEbajOGnkywnCbAtDhNmRiHxxCb);
					return null;
				}
				return TfuvoEqzTjlRFoPHoRhtebDcVtaI<Button>(1);
			}
		}

		public Button buttonDownRight
		{
			get
			{
				if (ReInput._id != LYzEbajOGnkywnCbAtDhNmRiHxxCb)
				{
					ReInput.CheckInitialized(LYzEbajOGnkywnCbAtDhNmRiHxxCb);
					return null;
				}
				return TfuvoEqzTjlRFoPHoRhtebDcVtaI<Button>(3);
			}
		}

		public Button buttonDownLeft
		{
			get
			{
				if (ReInput._id != LYzEbajOGnkywnCbAtDhNmRiHxxCb)
				{
					ReInput.CheckInitialized(LYzEbajOGnkywnCbAtDhNmRiHxxCb);
					return null;
				}
				return TfuvoEqzTjlRFoPHoRhtebDcVtaI<Button>(5);
			}
		}

		public Button buttonUpLeft
		{
			get
			{
				if (ReInput._id != LYzEbajOGnkywnCbAtDhNmRiHxxCb)
				{
					ReInput.CheckInitialized(LYzEbajOGnkywnCbAtDhNmRiHxxCb);
					return null;
				}
				return TfuvoEqzTjlRFoPHoRhtebDcVtaI<Button>(7);
			}
		}

		public int get_elementCapacity()
		{
			return 8;
		}

		internal Hat(Controller P_0, int P_1, string P_2, Button[] P_3, int[] P_4)
			: base(P_0, P_1, P_2, CompoundControllerElementType.Hat)
		{
			int num = ((P_3 != null) ? P_3.Length : 0);
			if (num != ((P_4 != null) ? P_4.Length : 0))
			{
				throw new ArgumentException("buttons.Length must equal buttonIndices.Length!");
			}
			if (num != 0 && num != 4 && num != 8)
			{
				throw new ArgumentException("buttons.Length must be 0, 4, or 8! Length: " + num);
			}
			for (int i = 0; i < num; i++)
			{
				gVsWoztwNdqhzRbgoHqqplJqELigA(P_3[i], P_4[i]);
			}
			HAZJYLrJzYKpfqotHgDJfuLvKOLvA = P_3;
			izdXvucQxxHuFShxWHABTyLYrnBu = P_4;
			hGpblSdzhekFyCAxdlLbmAmkdlhRA = num;
			eEiVPvktkXuoELOPjiLCCvowMrzE = new ReadOnlyCollection<Button>(P_3);
		}

		internal void bsKPoFpSwgQrfiowLlnCxLxfzgqp(UpdateLoopType P_0, ControllerDataUpdater P_1)
		{
			if (hGpblSdzhekFyCAxdlLbmAmkdlhRA == 0)
			{
				return;
			}
			if (hGpblSdzhekFyCAxdlLbmAmkdlhRA == 8 && (mWreohhkHcNaYInXkcPXHalydlrac || ReInput.configVars.force4WayHats))
			{
				jIUFiiIcGkyvypJJKLlNBmMyFTUAA(HAZJYLrJzYKpfqotHgDJfuLvKOLvA[0], izdXvucQxxHuFShxWHABTyLYrnBu[0], izdXvucQxxHuFShxWHABTyLYrnBu[7], izdXvucQxxHuFShxWHABTyLYrnBu[1], P_0, P_1);
				jIUFiiIcGkyvypJJKLlNBmMyFTUAA(HAZJYLrJzYKpfqotHgDJfuLvKOLvA[2], izdXvucQxxHuFShxWHABTyLYrnBu[2], izdXvucQxxHuFShxWHABTyLYrnBu[1], izdXvucQxxHuFShxWHABTyLYrnBu[3], P_0, P_1);
				jIUFiiIcGkyvypJJKLlNBmMyFTUAA(HAZJYLrJzYKpfqotHgDJfuLvKOLvA[4], izdXvucQxxHuFShxWHABTyLYrnBu[4], izdXvucQxxHuFShxWHABTyLYrnBu[5], izdXvucQxxHuFShxWHABTyLYrnBu[3], P_0, P_1);
				jIUFiiIcGkyvypJJKLlNBmMyFTUAA(HAZJYLrJzYKpfqotHgDJfuLvKOLvA[6], izdXvucQxxHuFShxWHABTyLYrnBu[6], izdXvucQxxHuFShxWHABTyLYrnBu[5], izdXvucQxxHuFShxWHABTyLYrnBu[7], P_0, P_1);
				GYBoOkBiUYbdtZMSEkryyelasMhN(HAZJYLrJzYKpfqotHgDJfuLvKOLvA[1], izdXvucQxxHuFShxWHABTyLYrnBu[1], P_0, P_1);
				GYBoOkBiUYbdtZMSEkryyelasMhN(HAZJYLrJzYKpfqotHgDJfuLvKOLvA[3], izdXvucQxxHuFShxWHABTyLYrnBu[3], P_0, P_1);
				GYBoOkBiUYbdtZMSEkryyelasMhN(HAZJYLrJzYKpfqotHgDJfuLvKOLvA[5], izdXvucQxxHuFShxWHABTyLYrnBu[5], P_0, P_1);
				GYBoOkBiUYbdtZMSEkryyelasMhN(HAZJYLrJzYKpfqotHgDJfuLvKOLvA[7], izdXvucQxxHuFShxWHABTyLYrnBu[7], P_0, P_1);
				return;
			}
			for (int i = 0; i < HAZJYLrJzYKpfqotHgDJfuLvKOLvA.Length; i++)
			{
				if (HAZJYLrJzYKpfqotHgDJfuLvKOLvA[i] != null)
				{
					HAZJYLrJzYKpfqotHgDJfuLvKOLvA[i].OnsYqlJnwMAVWAIfTSVljurlKtAhA(P_0, izdXvucQxxHuFShxWHABTyLYrnBu[i], P_1);
				}
			}
		}

		private void jIUFiiIcGkyvypJJKLlNBmMyFTUAA(Button P_0, int P_1, int P_2, int P_3, UpdateLoopType P_4, ControllerDataUpdater P_5)
		{
			if (P_0 == null || P_1 < 0 || P_1 >= P_5.buttonCount)
			{
				return;
			}
			if (!P_0.isPressureSensitive)
			{
				if (P_2 >= 0 && P_2 < P_5.buttonCount)
				{
					ref bool reference = ref P_5.buttonValues[P_1];
					reference |= P_5.buttonValues[P_2];
				}
				if (P_3 >= 0 && P_3 < P_5.buttonCount)
				{
					ref bool reference2 = ref P_5.buttonValues[P_1];
					reference2 |= P_5.buttonValues[P_3];
				}
			}
			else
			{
				P_5.buttonPressureValues[P_1] = MathTools.MaxMagnitude(P_5.buttonPressureValues[P_1], MathTools.MaxMagnitude((P_2 >= 0 && P_2 < P_5.buttonCount) ? P_5.buttonPressureValues[P_2] : 0f, (P_3 >= 0 && P_3 < P_5.buttonCount) ? P_5.buttonPressureValues[P_3] : 0f));
			}
			P_0.OnsYqlJnwMAVWAIfTSVljurlKtAhA(P_4, P_1, P_5);
		}

		private void GYBoOkBiUYbdtZMSEkryyelasMhN(Button P_0, int P_1, UpdateLoopType P_2, ControllerDataUpdater P_3)
		{
			if (P_0 != null && P_1 >= 0 && P_1 < P_3.buttonCount)
			{
				if (!P_0.isPressureSensitive)
				{
					P_3.buttonValues[P_1] = false;
				}
				else
				{
					P_3.buttonPressureValues[P_1] = 0f;
				}
				P_0.OnsYqlJnwMAVWAIfTSVljurlKtAhA(P_2, P_1, P_3);
			}
		}
	}

	public sealed class DirectionalPad : CompoundElement
	{
		private const int XnhPwhukyeNfMZvzIVmtCFuYJWzj = 4;

		private const int dekpizGluKFxLVdqCNUunLLLxrbG = 0;

		private const int uZmojVfvAyBXhGyEgaLhqaKeMEIG = 1;

		private const int IICMsqSySXQjomEsThuFsiiDNOFt = 2;

		private const int xMbGHwisrqCGpippBwvmRfmVJmjOA = 3;

		private readonly int ZMoiAUYBpkECXTCSegZDYMHKDLGI;

		private readonly Button[] hMNHHBKRsCpaEDFQwUdRCerOhfgh;

		private readonly ReadOnlyCollection<Button> JDCGuivlZAHYdltRmAjwnBjsjwSu;

		private readonly int[] qkQnTbMDvSBzYLgevaDcsYNLxhnt;

		int CompoundElement.elementCapacity => get_elementCapacity();

		public IList<Button> Buttons
		{
			get
			{
				if (ReInput._id != LYzEbajOGnkywnCbAtDhNmRiHxxCb)
				{
					ReInput.CheckInitialized(LYzEbajOGnkywnCbAtDhNmRiHxxCb);
					return EmptyObjects<Button>.EmptyReadOnlyIListT;
				}
				return JDCGuivlZAHYdltRmAjwnBjsjwSu;
			}
		}

		public Button buttonUp
		{
			get
			{
				if (ReInput._id != LYzEbajOGnkywnCbAtDhNmRiHxxCb)
				{
					ReInput.CheckInitialized(LYzEbajOGnkywnCbAtDhNmRiHxxCb);
					return null;
				}
				return TfuvoEqzTjlRFoPHoRhtebDcVtaI<Button>(0);
			}
		}

		public Button buttonRight
		{
			get
			{
				if (ReInput._id != LYzEbajOGnkywnCbAtDhNmRiHxxCb)
				{
					ReInput.CheckInitialized(LYzEbajOGnkywnCbAtDhNmRiHxxCb);
					return null;
				}
				return TfuvoEqzTjlRFoPHoRhtebDcVtaI<Button>(1);
			}
		}

		public Button buttonDown
		{
			get
			{
				if (ReInput._id != LYzEbajOGnkywnCbAtDhNmRiHxxCb)
				{
					ReInput.CheckInitialized(LYzEbajOGnkywnCbAtDhNmRiHxxCb);
					return null;
				}
				return TfuvoEqzTjlRFoPHoRhtebDcVtaI<Button>(2);
			}
		}

		public Button buttonLeft
		{
			get
			{
				if (ReInput._id != LYzEbajOGnkywnCbAtDhNmRiHxxCb)
				{
					ReInput.CheckInitialized(LYzEbajOGnkywnCbAtDhNmRiHxxCb);
					return null;
				}
				return TfuvoEqzTjlRFoPHoRhtebDcVtaI<Button>(3);
			}
		}

		public int get_elementCapacity()
		{
			return 4;
		}

		internal DirectionalPad(Controller P_0, int P_1, string P_2, Button[] P_3, int[] P_4)
			: base(P_0, P_1, P_2, CompoundControllerElementType.DPad)
		{
			int num = ((P_3 != null) ? P_3.Length : 0);
			if (num != ((P_4 != null) ? P_4.Length : 0))
			{
				throw new ArgumentException("buttons.Length must equal buttonIndices.Length!");
			}
			if (num != 0 && num != 4)
			{
				throw new ArgumentException("buttons.Length must be 0 or 4! Length: " + num);
			}
			for (int i = 0; i < num; i++)
			{
				gVsWoztwNdqhzRbgoHqqplJqELigA(P_3[i], P_4[i]);
			}
			hMNHHBKRsCpaEDFQwUdRCerOhfgh = P_3;
			qkQnTbMDvSBzYLgevaDcsYNLxhnt = P_4;
			ZMoiAUYBpkECXTCSegZDYMHKDLGI = num;
			JDCGuivlZAHYdltRmAjwnBjsjwSu = new ReadOnlyCollection<Button>(P_3);
		}

		internal void FwoJacfSTKFrUHEOmJrIENlHpzYZB(UpdateLoopType P_0, ControllerDataUpdater P_1)
		{
			if (ZMoiAUYBpkECXTCSegZDYMHKDLGI == 0)
			{
				return;
			}
			for (int i = 0; i < hMNHHBKRsCpaEDFQwUdRCerOhfgh.Length; i++)
			{
				if (hMNHHBKRsCpaEDFQwUdRCerOhfgh[i] != null)
				{
					hMNHHBKRsCpaEDFQwUdRCerOhfgh[i].OnsYqlJnwMAVWAIfTSVljurlKtAhA(P_0, qkQnTbMDvSBzYLgevaDcsYNLxhnt[i], P_1);
				}
			}
		}
	}

	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	public abstract class Extension
	{
		private Controller UDoKpMkOXMNiknPPCAiNfryTalxe;

		private IControllerExtensionSource IhVAHexidVBzaCZmrfCTiiiBMVVJ;

		internal readonly int _reInputId;

		internal bool isJoystickConnected
		{
			get
			{
				if (UDoKpMkOXMNiknPPCAiNfryTalxe == null)
				{
					return false;
				}
				return UDoKpMkOXMNiknPPCAiNfryTalxe._isConnected;
			}
		}

		internal bool enabled
		{
			get
			{
				if (UDoKpMkOXMNiknPPCAiNfryTalxe == null)
				{
					return false;
				}
				return UDoKpMkOXMNiknPPCAiNfryTalxe.enabled;
			}
		}

		public Controller controller => UDoKpMkOXMNiknPPCAiNfryTalxe;

		internal Extension(IControllerExtensionSource P_0)
		{
			_reInputId = ReInput.id;
			whUDfKHTwRhuIDPTFNGfQbkjzvJVA(P_0);
		}

		internal Extension(Extension P_0)
			: this(P_0.IhVAHexidVBzaCZmrfCTiiiBMVVJ)
		{
			UDoKpMkOXMNiknPPCAiNfryTalxe = P_0.UDoKpMkOXMNiknPPCAiNfryTalxe;
		}

		internal T GetController<T>() where T : Controller
		{
			if (UDoKpMkOXMNiknPPCAiNfryTalxe == null)
			{
				return null;
			}
			return UDoKpMkOXMNiknPPCAiNfryTalxe as T;
		}

		internal void SetController(Controller controller)
		{
			UDoKpMkOXMNiknPPCAiNfryTalxe = controller;
		}

		[CustomObfuscation(rename = false)]
		internal IControllerExtensionSource GetSource()
		{
			return IhVAHexidVBzaCZmrfCTiiiBMVVJ;
		}

		internal void SetSource(Extension extension)
		{
			if (extension == null)
			{
				whUDfKHTwRhuIDPTFNGfQbkjzvJVA(null);
			}
			else
			{
				whUDfKHTwRhuIDPTFNGfQbkjzvJVA(extension.IhVAHexidVBzaCZmrfCTiiiBMVVJ);
			}
		}

		private void whUDfKHTwRhuIDPTFNGfQbkjzvJVA(IControllerExtensionSource P_0)
		{
			IhVAHexidVBzaCZmrfCTiiiBMVVJ = P_0;
			SourceUpdated(IhVAHexidVBzaCZmrfCTiiiBMVVJ);
		}

		internal virtual void Clear()
		{
		}

		internal abstract void SourceUpdated(IControllerExtensionSource source);

		internal abstract void UpdateData(UpdateLoopType updateLoop);

		internal abstract Extension Clone();
	}

	[Serializable]
	private sealed class ddJfGHEXhaagbIOuiLtstmLnzxXWb
	{
		public static readonly ddJfGHEXhaagbIOuiLtstmLnzxXWb _003C_003E9 = new ddJfGHEXhaagbIOuiLtstmLnzxXWb();

		public static Func<Controller, Guid, bool> _003C_003E9__166_0;

		public static Func<Controller, Type, bool> _003C_003E9__169_0;

		internal bool gWfYIjsDkraoSSNAhRzzwJnWbDhy(Controller P_0, Guid P_1)
		{
			return P_0.ImplementsTemplate(P_1);
		}

		internal bool NaKjjtmVsonCmSAOYtPSbaWPESFl(Controller P_0, Type P_1)
		{
			return P_0.ImplementsTemplate(P_1);
		}
	}

	private sealed class ikeGSWtysKCsMrlPQemziQGbjBVb : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
	{
		private int blNprNfeCSrfSBnYLebhesuFWOXS;

		private ControllerPollingInfo hONwVKnElPTKDlXVdXiHJjRKxbQj;

		private int pcuHiIrsgRIkSjgAgzdxPknoEvjj;

		public Controller rbmMDTYFltFtOFqDOBnefelrKSzIA;

		private int RwPScWVViQjVXPTfrSWVguQZiRNy;

		ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
		{
			[DebuggerHidden]
			get
			{
				return hONwVKnElPTKDlXVdXiHJjRKxbQj;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return hONwVKnElPTKDlXVdXiHJjRKxbQj;
			}
		}

		[DebuggerHidden]
		public ikeGSWtysKCsMrlPQemziQGbjBVb(int P_0)
		{
			blNprNfeCSrfSBnYLebhesuFWOXS = P_0;
			pcuHiIrsgRIkSjgAgzdxPknoEvjj = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			int num = blNprNfeCSrfSBnYLebhesuFWOXS;
			Controller controller = rbmMDTYFltFtOFqDOBnefelrKSzIA;
			if (num != 0)
			{
				if (num != 1)
				{
					return false;
				}
				blNprNfeCSrfSBnYLebhesuFWOXS = -1;
				goto IL_00a0;
			}
			blNprNfeCSrfSBnYLebhesuFWOXS = -1;
			if (ReInput._id != controller.qostqwFsdWROzwZYaTyZVeYSeDOM)
			{
				ReInput.CheckInitialized(controller.qostqwFsdWROzwZYaTyZVeYSeDOM);
				return false;
			}
			controller.UpdatePollingFrameTracking();
			RwPScWVViQjVXPTfrSWVguQZiRNy = 0;
			goto IL_00b0;
			IL_00b0:
			if (RwPScWVViQjVXPTfrSWVguQZiRNy < controller._buttonCount)
			{
				if (controller.VVSVZXvBNAAzfnlUaZLKrCWbnCfn(RwPScWVViQjVXPTfrSWVguQZiRNy, out var num2))
				{
					hONwVKnElPTKDlXVdXiHJjRKxbQj = new ControllerPollingInfo(true, -1, controller.id, controller._name, controller._type, ControllerElementType.Button, RwPScWVViQjVXPTfrSWVguQZiRNy, Pole.Positive, controller.aHJMAWzbypGgwCcRCqDEaoqVGwfA.GetElementIdentifierName(num2), num2, KeyCode.None);
					blNprNfeCSrfSBnYLebhesuFWOXS = 1;
					return true;
				}
				goto IL_00a0;
			}
			return false;
			IL_00a0:
			RwPScWVViQjVXPTfrSWVguQZiRNy++;
			goto IL_00b0;
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
		IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
		{
			ikeGSWtysKCsMrlPQemziQGbjBVb ikeGSWtysKCsMrlPQemziQGbjBVb2;
			if (blNprNfeCSrfSBnYLebhesuFWOXS == -2 && pcuHiIrsgRIkSjgAgzdxPknoEvjj == Environment.CurrentManagedThreadId)
			{
				blNprNfeCSrfSBnYLebhesuFWOXS = 0;
				ikeGSWtysKCsMrlPQemziQGbjBVb2 = this;
			}
			else
			{
				ikeGSWtysKCsMrlPQemziQGbjBVb2 = new ikeGSWtysKCsMrlPQemziQGbjBVb(0);
				ikeGSWtysKCsMrlPQemziQGbjBVb2.rbmMDTYFltFtOFqDOBnefelrKSzIA = rbmMDTYFltFtOFqDOBnefelrKSzIA;
			}
			return ikeGSWtysKCsMrlPQemziQGbjBVb2;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
		}
	}

	private sealed class siZdYrfzbjAhMeWmGAJNcKPyTkidc : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
	{
		private int pCfPqMfpUFKJBvgcUpIssrlRCnCe;

		private ControllerPollingInfo qGKFgBcYsgwJCZEKDwYYEenjStDY;

		private int edTVvkzlrxyfiyiAyXVrGApizbSW;

		public Controller ijOMdxBtwRUQkVuNwavottzQmEic;

		private int QDPnziJKSZaIAkwDxJdcAlzhKQJB;

		ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
		{
			[DebuggerHidden]
			get
			{
				return qGKFgBcYsgwJCZEKDwYYEenjStDY;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return qGKFgBcYsgwJCZEKDwYYEenjStDY;
			}
		}

		[DebuggerHidden]
		public siZdYrfzbjAhMeWmGAJNcKPyTkidc(int P_0)
		{
			pCfPqMfpUFKJBvgcUpIssrlRCnCe = P_0;
			edTVvkzlrxyfiyiAyXVrGApizbSW = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			int num = pCfPqMfpUFKJBvgcUpIssrlRCnCe;
			Controller controller = ijOMdxBtwRUQkVuNwavottzQmEic;
			if (num != 0)
			{
				if (num != 1)
				{
					return false;
				}
				pCfPqMfpUFKJBvgcUpIssrlRCnCe = -1;
				goto IL_00a0;
			}
			pCfPqMfpUFKJBvgcUpIssrlRCnCe = -1;
			if (ReInput._id != controller.qostqwFsdWROzwZYaTyZVeYSeDOM)
			{
				ReInput.CheckInitialized(controller.qostqwFsdWROzwZYaTyZVeYSeDOM);
				return false;
			}
			controller.UpdatePollingFrameTracking();
			QDPnziJKSZaIAkwDxJdcAlzhKQJB = 0;
			goto IL_00b0;
			IL_00b0:
			if (QDPnziJKSZaIAkwDxJdcAlzhKQJB < controller._buttonCount)
			{
				if (controller.fwjQLzpEEsbBygZyNQcAsNiIpkSiA(QDPnziJKSZaIAkwDxJdcAlzhKQJB, out var num2))
				{
					qGKFgBcYsgwJCZEKDwYYEenjStDY = new ControllerPollingInfo(true, -1, controller.id, controller._name, controller._type, ControllerElementType.Button, QDPnziJKSZaIAkwDxJdcAlzhKQJB, Pole.Positive, controller.aHJMAWzbypGgwCcRCqDEaoqVGwfA.GetElementIdentifierName(num2), num2, KeyCode.None);
					pCfPqMfpUFKJBvgcUpIssrlRCnCe = 1;
					return true;
				}
				goto IL_00a0;
			}
			return false;
			IL_00a0:
			QDPnziJKSZaIAkwDxJdcAlzhKQJB++;
			goto IL_00b0;
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
		IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
		{
			siZdYrfzbjAhMeWmGAJNcKPyTkidc siZdYrfzbjAhMeWmGAJNcKPyTkidc2;
			if (pCfPqMfpUFKJBvgcUpIssrlRCnCe == -2 && edTVvkzlrxyfiyiAyXVrGApizbSW == Environment.CurrentManagedThreadId)
			{
				pCfPqMfpUFKJBvgcUpIssrlRCnCe = 0;
				siZdYrfzbjAhMeWmGAJNcKPyTkidc2 = this;
			}
			else
			{
				siZdYrfzbjAhMeWmGAJNcKPyTkidc2 = new siZdYrfzbjAhMeWmGAJNcKPyTkidc(0);
				siZdYrfzbjAhMeWmGAJNcKPyTkidc2.ijOMdxBtwRUQkVuNwavottzQmEic = ijOMdxBtwRUQkVuNwavottzQmEic;
			}
			return siZdYrfzbjAhMeWmGAJNcKPyTkidc2;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
		}
	}

	public readonly int id;

	protected string _tag;

	protected string _name;

	private readonly DeviceLocalizationInfo IOvJTkJUoLUFBdOQtBigKgpuzwcuA;

	protected string _hardwareName;

	protected readonly ControllerType _type;

	internal readonly Guid TlKwqXsIXURetJtusBGjLpbJxFcf;

	protected string _hardwareIdentifier;

	protected bool _isConnected;

	private Extension MWiCMZjmzXjuSObvCqDzietdSuqGb;

	private bool asvNSlPOBuvyGHxmyjMJPODtXwcu;

	private ControllerIdentifier OYRcGopRbRDAVgDKrtxIWuXcqvkK;

	internal int qostqwFsdWROzwZYaTyZVeYSeDOM;

	protected readonly int _buttonCount;

	protected readonly Button[] buttons;

	protected readonly ReadOnlyCollection<Button> buttons_readOnly;

	private readonly IList<Element> GYUaOIhaEpeWvBAaeWZkXhENMNHVB;

	private readonly ReadOnlyCollection<Element> KBGwiFbuXuRPcGkEVOMxOVdlzTfc;

	private readonly IList<CompoundElement> fUCpDTJYuPDFGZStccBSicuOgcTbA;

	private readonly ReadOnlyCollection<CompoundElement> TyxfMQybgaAcVJQavFeIsmdwUBGFA;

	[CustomObfuscation(rename = false)]
	internal readonly InputSource inputSource;

	internal readonly ControllerDataUpdater KRqNAliDQUoGilZWSpebheoTCzwBA;

	internal readonly HardwareControllerMap_Game aHJMAWzbypGgwCcRCqDEaoqVGwfA;

	internal uint wpuYxYLINvhobUhrjHsgbKAfRtCM;

	private uint BDyGopVuoRvnZVQkEFHTkumQPWjE;

	private uint tUfYkgXutYDGqHyLjWZpqhfGCMIn;

	private ITryGetLocalizedName mWlhxFgBZPEmuexSmBeyRFTGcRPGA;

	private readonly LocalizedString UIdrwRtMfTMwiHJIGWcXaTAlCkFF;

	private readonly NSbrwSqxkQipOgPUDCHONhtFYAor kTvAOeyHkJpMILHqJsBORnSnAQJA;

	private Action<bool> cBDxuRpbtvngvoPcTJQcgAWoCPRu;

	private IControllerTemplate[] rGStKYYhIIdyOkVxIYAJbGYAsTij;

	private ReadOnlyCollection<IControllerTemplate> DcysKrIniYGUqEDaXaTtaLmFyFOgb;

	private static Func<Controller, Guid, bool> yAMmBWSJjFzehpRxYgxRbjeaRKfp;

	private static Func<Controller, Type, bool> CFIPMfpuIGOnVXcXsOqAYMLrzYv;

	internal bool polfnlHADLNzLoNdlgDrAzROyUIrA => odRupMutWRqSJAgRjaskPLgzZCHl();

	public bool enabled
	{
		get
		{
			if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
			{
				ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
				return false;
			}
			return asvNSlPOBuvyGHxmyjMJPODtXwcu;
		}
		set
		{
			inMOXJxCMugPOHqUhiIifiebgFebc(value);
		}
	}

	public string name
	{
		get
		{
			if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
			{
				ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
				return string.Empty;
			}
			if (!LocalizationManager.isEnabled)
			{
				return _name;
			}
			if (qHtUUBDUOxMDzqwLjvNnoVUskwTh() != null && qHtUUBDUOxMDzqwLjvNnoVUskwTh().TryGetLocalizedName(out var value))
			{
				return value;
			}
			if (_type == ControllerType.Joystick && TlKwqXsIXURetJtusBGjLpbJxFcf == Consts.joystickGuid_unknownController)
			{
				return _name;
			}
			if (IOvJTkJUoLUFBdOQtBigKgpuzwcuA == null || IOvJTkJUoLUFBdOQtBigKgpuzwcuA.parentKeys == null)
			{
				return _name;
			}
			LocalizationManager.GetAndUpdateLocalizedString(UIdrwRtMfTMwiHJIGWcXaTAlCkFF, (IOvJTkJUoLUFBdOQtBigKgpuzwcuA != null) ? IOvJTkJUoLUFBdOQtBigKgpuzwcuA.parentKeys : null, DIFNnnaZcXQLPYxsIZWTkUfgTNzj.fRyvXOfRcxBZOrSkMnHnHSXJkTXV(_type), _name, out value);
			return value;
		}
		internal set
		{
			VJcZsAGCSLQHeGELPHnMczWNUUvPA(text);
		}
	}

	public string tag
	{
		get
		{
			if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
			{
				ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
				return string.Empty;
			}
			return _tag;
		}
		set
		{
			if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
			{
				ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
			}
			else
			{
				_tag = value;
			}
		}
	}

	public string hardwareName
	{
		get
		{
			if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
			{
				ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
				return string.Empty;
			}
			return _hardwareName;
		}
	}

	public ControllerType type
	{
		get
		{
			if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
			{
				ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
				return ControllerType.Keyboard;
			}
			return _type;
		}
	}

	public Guid hardwareTypeGuid
	{
		get
		{
			if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
			{
				ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
				return Guid.Empty;
			}
			return TlKwqXsIXURetJtusBGjLpbJxFcf;
		}
	}

	public abstract Guid deviceInstanceGuid { get; }

	public ControllerIdentifier identifier => OYRcGopRbRDAVgDKrtxIWuXcqvkK;

	public bool isConnected
	{
		get
		{
			if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
			{
				ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
				return false;
			}
			return _isConnected;
		}
		internal set
		{
			fiaCZhvqrdhxedobUMbCPqHaoqSAA(flag);
		}
	}

	public string hardwareIdentifier
	{
		get
		{
			if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
			{
				ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
				return string.Empty;
			}
			return _hardwareIdentifier;
		}
	}

	public string mapTypeString => _type.ToString() + "Map";

	public int elementCount
	{
		get
		{
			if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
			{
				ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
				return 0;
			}
			return GYUaOIhaEpeWvBAaeWZkXhENMNHVB.Count;
		}
	}

	public int buttonCount
	{
		get
		{
			if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
			{
				ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
				return 0;
			}
			return _buttonCount;
		}
	}

	public IList<Element> Elements
	{
		get
		{
			if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
			{
				ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
				return EmptyObjects<Element>.EmptyReadOnlyIListT;
			}
			return KBGwiFbuXuRPcGkEVOMxOVdlzTfc;
		}
	}

	public IList<CompoundElement> CompoundElements
	{
		get
		{
			if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
			{
				ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
				return EmptyObjects<CompoundElement>.EmptyReadOnlyIListT;
			}
			return TyxfMQybgaAcVJQavFeIsmdwUBGFA;
		}
	}

	public IList<Button> Buttons
	{
		get
		{
			if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
			{
				ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
				return EmptyObjects<Button>.EmptyReadOnlyIListT;
			}
			return buttons_readOnly;
		}
	}

	public Extension extension
	{
		get
		{
			if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
			{
				ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
				return null;
			}
			return MWiCMZjmzXjuSObvCqDzietdSuqGb;
		}
	}

	public IList<ControllerElementIdentifier> ElementIdentifiers
	{
		get
		{
			if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
			{
				ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
				return EmptyObjects<ControllerElementIdentifier>.EmptyReadOnlyIListT;
			}
			return aHJMAWzbypGgwCcRCqDEaoqVGwfA.elementIdentifiers_readOnly;
		}
	}

	public IList<ControllerElementIdentifier> ButtonElementIdentifiers
	{
		get
		{
			if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
			{
				ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
				return EmptyObjects<ControllerElementIdentifier>.EmptyReadOnlyIListT;
			}
			return aHJMAWzbypGgwCcRCqDEaoqVGwfA.buttonElementIdentifiers_readOnly;
		}
	}

	internal ITryGetLocalizedName kHbcpQVtEXsshwJVLQacAEeOCjicA
	{
		get
		{
			return qHtUUBDUOxMDzqwLjvNnoVUskwTh();
		}
		set
		{
			LOlfEcDQeqYgremiHvntwLzDYOuvA(tryGetLocalizedName);
		}
	}

	public IList<IControllerTemplate> Templates
	{
		get
		{
			if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
			{
				ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
				return EmptyObjects<IControllerTemplate>.EmptyReadOnlyIListT;
			}
			return DcysKrIniYGUqEDaXaTtaLmFyFOgb;
		}
	}

	public int templateCount
	{
		get
		{
			if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
			{
				ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
				return 0;
			}
			return rGStKYYhIIdyOkVxIYAJbGYAsTij.Length;
		}
	}

	internal static Func<Controller, Guid, bool> nLIoPGZNVwTvDjniShrvvefakven => rfkaHYAdQqwZPLqANfnyfsLkhHWIc();

	internal static Func<Controller, Type, bool> UqMlNJEyfSnZHcdjdGTLimlzaQDP => ZKzfVpKsPvMjAwTtpeymwqHXaFaL();

	internal event Action<bool> aXUPKFsPZEfgcatpylAzqADULmNtA
	{
		add
		{
			cjCjEMGfuzPQfnEVaVjjnGMccqCP(action);
		}
		remove
		{
			KRCjdapZnXLcjyqMRtRoHLyKJtqf(action);
		}
	}

	internal bool odRupMutWRqSJAgRjaskPLgzZCHl()
	{
		return BDyGopVuoRvnZVQkEFHTkumQPWjE == ReInput.previousFrame;
	}

	internal void VJcZsAGCSLQHeGELPHnMczWNUUvPA(string P_0)
	{
		_name = P_0;
	}

	internal void fiaCZhvqrdhxedobUMbCPqHaoqSAA(bool P_0)
	{
		if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
		{
			ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
		}
		else if (!P_0)
		{
			Disconnected();
		}
		else
		{
			Connected();
		}
	}

	internal ITryGetLocalizedName qHtUUBDUOxMDzqwLjvNnoVUskwTh()
	{
		return mWlhxFgBZPEmuexSmBeyRFTGcRPGA;
	}

	internal void LOlfEcDQeqYgremiHvntwLzDYOuvA(ITryGetLocalizedName P_0)
	{
		mWlhxFgBZPEmuexSmBeyRFTGcRPGA = P_0;
	}

	internal void cjCjEMGfuzPQfnEVaVjjnGMccqCP(Action<bool> P_0)
	{
		cBDxuRpbtvngvoPcTJQcgAWoCPRu = (Action<bool>)Delegate.Combine(cBDxuRpbtvngvoPcTJQcgAWoCPRu, P_0);
	}

	internal void KRCjdapZnXLcjyqMRtRoHLyKJtqf(Action<bool> P_0)
	{
		cBDxuRpbtvngvoPcTJQcgAWoCPRu = (Action<bool>)Delegate.Remove(cBDxuRpbtvngvoPcTJQcgAWoCPRu, P_0);
	}

	internal Controller(int P_0, InputSource P_1, string P_2, string P_3, string P_4, ControllerType P_5, Guid P_6, int P_7, bool[] P_8, HardwareButtonInfo[] P_9, HardwareControllerMap_Game P_10, Extension P_11, ControllerDataUpdater P_12)
	{
		id = P_0;
		inputSource = P_1;
		_type = P_5;
		TlKwqXsIXURetJtusBGjLpbJxFcf = P_6;
		_buttonCount = P_7;
		_name = P_2;
		_hardwareName = P_3;
		_hardwareIdentifier = P_4;
		KRqNAliDQUoGilZWSpebheoTCzwBA = P_12;
		aHJMAWzbypGgwCcRCqDEaoqVGwfA = P_10;
		IOvJTkJUoLUFBdOQtBigKgpuzwcuA = P_10.deviceLocalizationInfo;
		asvNSlPOBuvyGHxmyjMJPODtXwcu = true;
		qostqwFsdWROzwZYaTyZVeYSeDOM = ReInput.id;
		UIdrwRtMfTMwiHJIGWcXaTAlCkFF = new LocalizedString();
		kTvAOeyHkJpMILHqJsBORnSnAQJA = new NSbrwSqxkQipOgPUDCHONhtFYAor(() =>
		{
			_ = name;
		});
		yxBmXDsLSAcsJJQBkbrHicXGYnNt(P_11);
		GYUaOIhaEpeWvBAaeWZkXhENMNHVB = new List<Element>(P_7);
		KBGwiFbuXuRPcGkEVOMxOVdlzTfc = new ReadOnlyCollection<Element>(GYUaOIhaEpeWvBAaeWZkXhENMNHVB);
		fUCpDTJYuPDFGZStccBSicuOgcTbA = new List<CompoundElement>();
		TyxfMQybgaAcVJQavFeIsmdwUBGFA = new ReadOnlyCollection<CompoundElement>(fUCpDTJYuPDFGZStccBSicuOgcTbA);
		buttons = new Button[P_7];
		if (P_8 == null || P_8.Length < P_7)
		{
			for (int num = 0; num < P_7; num++)
			{
				buttons[num] = new Button(this, P_10.buttonElementIdentifierIds[num], "Button " + num, false, (P_9 != null) ? P_9[num] : new HardwareButtonInfo());
				zkXRkxAwhqLFVfoSYoVfrkjAcGlp(buttons[num]);
			}
		}
		else
		{
			for (int num2 = 0; num2 < P_7; num2++)
			{
				buttons[num2] = new Button(this, P_10.buttonElementIdentifierIds[num2], "Button " + num2, P_8[num2], (P_9 != null) ? P_9[num2] : new HardwareButtonInfo());
				zkXRkxAwhqLFVfoSYoVfrkjAcGlp(buttons[num2]);
			}
		}
		buttons_readOnly = new ReadOnlyCollection<Button>(buttons);
		rGStKYYhIIdyOkVxIYAJbGYAsTij = EmptyObjects<IControllerTemplate>.array;
		DcysKrIniYGUqEDaXaTtaLmFyFOgb = new ReadOnlyCollection<IControllerTemplate>(rGStKYYhIIdyOkVxIYAJbGYAsTij);
		if (LocalizationManager.isEnabled && LocalizationManager.autoPrefetch)
		{
			((OxefyMfZIgXEzbqjvpxteWerzayF)kTvAOeyHkJpMILHqJsBORnSnAQJA).Localize();
		}
		Connected();
	}

	internal virtual void EMBHjcsxjUDMCsHethyxgQTJtbEg()
	{
		OYRcGopRbRDAVgDKrtxIWuXcqvkK = new ControllerIdentifier(this);
	}

	public virtual Element GetElementById(int elementIdentifierId)
	{
		if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
		{
			ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
			return null;
		}
		if (aHJMAWzbypGgwCcRCqDEaoqVGwfA == null)
		{
			return null;
		}
		int buttonIndex = aHJMAWzbypGgwCcRCqDEaoqVGwfA.GetButtonIndex(elementIdentifierId);
		if (buttonIndex < 0)
		{
			return null;
		}
		return buttons[buttonIndex];
	}

	public virtual CompoundElement GetCompoundElementById(int elementIdentifierId)
	{
		if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
		{
			ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
			return null;
		}
		int count = fUCpDTJYuPDFGZStccBSicuOgcTbA.Count;
		for (int i = 0; i < count; i++)
		{
			if (fUCpDTJYuPDFGZStccBSicuOgcTbA[i] != null && fUCpDTJYuPDFGZStccBSicuOgcTbA[i].id == elementIdentifierId)
			{
				return fUCpDTJYuPDFGZStccBSicuOgcTbA[i];
			}
		}
		return null;
	}

	[Obsolete("This method is deprecated. Use GetCompoundElementById instead.", false)]
	public virtual CompoundElement GetCompundElementById(int elementIdentifierId)
	{
		return GetCompoundElementById(elementIdentifierId);
	}

	public int GetButtonIndexById(int elementIdentifierId)
	{
		if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
		{
			ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
			return -1;
		}
		return aHJMAWzbypGgwCcRCqDEaoqVGwfA.GetButtonIndex(elementIdentifierId);
	}

	public ControllerElementIdentifier GetElementIdentifierById(int elementIdentifierId)
	{
		if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
		{
			ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
			return null;
		}
		return aHJMAWzbypGgwCcRCqDEaoqVGwfA.GetElementIdentifierById(elementIdentifierId);
	}

	public virtual bool GetButton(int index)
	{
		if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
		{
			ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
			return false;
		}
		if (index < 0 || index >= _buttonCount)
		{
			return false;
		}
		return buttons[index].value;
	}

	public virtual bool GetButtonDown(int index)
	{
		if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
		{
			ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
			return false;
		}
		if (index < 0 || index >= _buttonCount)
		{
			return false;
		}
		return buttons[index].justPressed;
	}

	public virtual bool GetButtonUp(int index)
	{
		if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
		{
			ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
			return false;
		}
		if (index < 0 || index >= _buttonCount)
		{
			return false;
		}
		return buttons[index].justReleased;
	}

	public virtual bool GetButtonChanged(int index)
	{
		if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
		{
			ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
			return false;
		}
		if (index < 0 || index >= _buttonCount)
		{
			return false;
		}
		return buttons[index].value != buttons[index].valuePrev;
	}

	public virtual bool GetButtonPrev(int index)
	{
		if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
		{
			ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
			return false;
		}
		if (index < 0 || index >= _buttonCount)
		{
			return false;
		}
		return buttons[index].valuePrev;
	}

	public virtual bool GetButtonDoublePressHold(int index)
	{
		if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
		{
			ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
			return false;
		}
		return GetButtonDoublePressHold(index, 0f);
	}

	public virtual bool GetButtonDoublePressHold(int index, float speed)
	{
		if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
		{
			ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
			return false;
		}
		if (index < 0 || index >= _buttonCount)
		{
			return false;
		}
		return buttons[index].DoublePressedAndHeld(speed);
	}

	public virtual bool GetButtonDoublePressDown(int index)
	{
		if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
		{
			ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
			return false;
		}
		return GetButtonDoublePressDown(index, 0f);
	}

	public virtual bool GetButtonDoublePressDown(int index, float speed)
	{
		if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
		{
			ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
			return false;
		}
		if (index < 0 || index >= _buttonCount)
		{
			return false;
		}
		return buttons[index].JustDoublePressed(speed);
	}

	public virtual double GetButtonTimePressed(int index)
	{
		if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
		{
			ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
			return 0.0;
		}
		if (index < 0 || index >= _buttonCount)
		{
			return 0.0;
		}
		return buttons[index].timePressed;
	}

	public virtual double GetButtonTimeUnpressed(int index)
	{
		if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
		{
			ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
			return 0.0;
		}
		if (index < 0 || index >= _buttonCount)
		{
			return 0.0;
		}
		return buttons[index].timeUnpressed;
	}

	public virtual double GetButtonLastTimePressed(int index)
	{
		if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
		{
			ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
			return 0.0;
		}
		if (index < 0 || index >= _buttonCount)
		{
			return 0.0;
		}
		return buttons[index].lastTimePressed;
	}

	public virtual double GetButtonLastTimeUnpressed(int index)
	{
		if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
		{
			ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
			return 0.0;
		}
		if (index < 0 || index >= _buttonCount)
		{
			return 0.0;
		}
		return buttons[index].lastTimeUnpressed;
	}

	public virtual bool GetAnyButton()
	{
		if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
		{
			ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
			return false;
		}
		for (int i = 0; i < _buttonCount; i++)
		{
			if (buttons[i].value)
			{
				return true;
			}
		}
		return false;
	}

	public virtual bool GetAnyButtonDown()
	{
		if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
		{
			ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
			return false;
		}
		for (int i = 0; i < _buttonCount; i++)
		{
			if (buttons[i].justPressed)
			{
				return true;
			}
		}
		return false;
	}

	public virtual bool GetAnyButtonUp()
	{
		if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
		{
			ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
			return false;
		}
		for (int i = 0; i < _buttonCount; i++)
		{
			if (buttons[i].justReleased)
			{
				return true;
			}
		}
		return false;
	}

	public virtual bool GetAnyButtonPrev()
	{
		if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
		{
			ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
			return false;
		}
		for (int i = 0; i < _buttonCount; i++)
		{
			if (buttons[i].valuePrev)
			{
				return true;
			}
		}
		return false;
	}

	public virtual bool GetAnyButtonChanged()
	{
		if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
		{
			ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
			return false;
		}
		for (int i = 0; i < _buttonCount; i++)
		{
			if (buttons[i].justChangedState)
			{
				return true;
			}
		}
		return false;
	}

	public virtual bool GetButtonById(int elementIdentifierId)
	{
		if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
		{
			ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
			return false;
		}
		int buttonIndex = aHJMAWzbypGgwCcRCqDEaoqVGwfA.GetButtonIndex(elementIdentifierId);
		if (buttonIndex < 0 || buttonIndex >= _buttonCount)
		{
			return false;
		}
		return buttons[buttonIndex].value;
	}

	public virtual bool GetButtonDownById(int elementIdentifierId)
	{
		if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
		{
			ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
			return false;
		}
		int buttonIndex = aHJMAWzbypGgwCcRCqDEaoqVGwfA.GetButtonIndex(elementIdentifierId);
		if (buttonIndex < 0 || buttonIndex >= _buttonCount)
		{
			return false;
		}
		return buttons[buttonIndex].justPressed;
	}

	public virtual bool GetButtonUpById(int elementIdentifierId)
	{
		if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
		{
			ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
			return false;
		}
		int buttonIndex = aHJMAWzbypGgwCcRCqDEaoqVGwfA.GetButtonIndex(elementIdentifierId);
		if (buttonIndex < 0 || buttonIndex >= _buttonCount)
		{
			return false;
		}
		return buttons[buttonIndex].justReleased;
	}

	public virtual bool GetButtonDoublePressHoldById(int elementIdentifierId, float speed)
	{
		if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
		{
			ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
			return false;
		}
		int buttonIndex = aHJMAWzbypGgwCcRCqDEaoqVGwfA.GetButtonIndex(elementIdentifierId);
		if (buttonIndex < 0 || buttonIndex >= _buttonCount)
		{
			return false;
		}
		return buttons[buttonIndex].DoublePressedAndHeld(speed);
	}

	public virtual bool GetButtonDoublePressDownById(int elementIdentifierId, float speed)
	{
		if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
		{
			ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
			return false;
		}
		int buttonIndex = aHJMAWzbypGgwCcRCqDEaoqVGwfA.GetButtonIndex(elementIdentifierId);
		if (buttonIndex < 0 || buttonIndex >= _buttonCount)
		{
			return false;
		}
		return buttons[buttonIndex].JustDoublePressed(speed);
	}

	public virtual bool GetButtonDoublePressHoldById(int elementIdentifierId)
	{
		if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
		{
			ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
			return false;
		}
		int buttonIndex = aHJMAWzbypGgwCcRCqDEaoqVGwfA.GetButtonIndex(elementIdentifierId);
		return GetButtonDoublePressHold(buttonIndex, 0f);
	}

	public virtual bool GetButtonDoublePressDownById(int elementIdentifierId)
	{
		if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
		{
			ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
			return false;
		}
		int buttonIndex = aHJMAWzbypGgwCcRCqDEaoqVGwfA.GetButtonIndex(elementIdentifierId);
		return GetButtonDoublePressDown(buttonIndex, 0f);
	}

	public virtual bool GetButtonPrevById(int elementIdentifierId)
	{
		if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
		{
			ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
			return false;
		}
		int buttonIndex = aHJMAWzbypGgwCcRCqDEaoqVGwfA.GetButtonIndex(elementIdentifierId);
		if (buttonIndex < 0 || buttonIndex >= _buttonCount)
		{
			return false;
		}
		return buttons[buttonIndex].valuePrev;
	}

	public virtual double GetButtonTimePressedById(int elementIdentifierId)
	{
		if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
		{
			ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
			return 0.0;
		}
		int buttonIndex = aHJMAWzbypGgwCcRCqDEaoqVGwfA.GetButtonIndex(elementIdentifierId);
		if (buttonIndex < 0 || buttonIndex >= _buttonCount)
		{
			return 0.0;
		}
		return buttons[buttonIndex].timePressed;
	}

	public virtual double GetButtonTimeUnpressedById(int elementIdentifierId)
	{
		if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
		{
			ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
			return 0.0;
		}
		int buttonIndex = aHJMAWzbypGgwCcRCqDEaoqVGwfA.GetButtonIndex(elementIdentifierId);
		if (buttonIndex < 0 || buttonIndex >= _buttonCount)
		{
			return 0.0;
		}
		return buttons[buttonIndex].timeUnpressed;
	}

	public virtual double GetButtonLastTimePressedById(int elementIdentifierId)
	{
		if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
		{
			ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
			return 0.0;
		}
		int buttonIndex = aHJMAWzbypGgwCcRCqDEaoqVGwfA.GetButtonIndex(elementIdentifierId);
		if (buttonIndex < 0 || buttonIndex >= _buttonCount)
		{
			return 0.0;
		}
		return buttons[buttonIndex].lastTimePressed;
	}

	public virtual double GetButtonLastTimeUnpressedById(int elementIdentifierId)
	{
		if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
		{
			ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
			return 0.0;
		}
		int buttonIndex = aHJMAWzbypGgwCcRCqDEaoqVGwfA.GetButtonIndex(elementIdentifierId);
		if (buttonIndex < 0 || buttonIndex >= _buttonCount)
		{
			return 0.0;
		}
		return buttons[buttonIndex].lastTimeUnpressed;
	}

	public virtual ControllerPollingInfo PollForFirstElement()
	{
		return PollForFirstButton();
	}

	public virtual ControllerPollingInfo PollForFirstElementDown()
	{
		return PollForFirstButtonDown();
	}

	public virtual ControllerPollingInfo PollForFirstButton()
	{
		if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
		{
			ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
			return ControllerPollingInfo.wybtSxBKyoFevDSBzxAFgDtcKhkHA();
		}
		UpdatePollingFrameTracking();
		for (int i = 0; i < _buttonCount; i++)
		{
			if (VVSVZXvBNAAzfnlUaZLKrCWbnCfn(i, out var num))
			{
				return new ControllerPollingInfo(true, -1, id, _name, _type, ControllerElementType.Button, i, Pole.Positive, aHJMAWzbypGgwCcRCqDEaoqVGwfA.GetElementIdentifierName(num), num, KeyCode.None);
			}
		}
		return ControllerPollingInfo.wybtSxBKyoFevDSBzxAFgDtcKhkHA();
	}

	public virtual ControllerPollingInfo PollForFirstButtonDown()
	{
		if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
		{
			ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
			return ControllerPollingInfo.wybtSxBKyoFevDSBzxAFgDtcKhkHA();
		}
		UpdatePollingFrameTracking();
		for (int i = 0; i < _buttonCount; i++)
		{
			if (fwjQLzpEEsbBygZyNQcAsNiIpkSiA(i, out var num))
			{
				return new ControllerPollingInfo(true, -1, id, _name, _type, ControllerElementType.Button, i, Pole.Positive, aHJMAWzbypGgwCcRCqDEaoqVGwfA.GetElementIdentifierName(num), num, KeyCode.None);
			}
		}
		return ControllerPollingInfo.wybtSxBKyoFevDSBzxAFgDtcKhkHA();
	}

	public virtual IEnumerable<ControllerPollingInfo> PollForAllElements()
	{
		return PollForAllButtons();
	}

	public virtual IEnumerable<ControllerPollingInfo> PollForAllElementsDown()
	{
		return PollForAllButtonsDown();
	}

	[IteratorStateMachine(typeof(ikeGSWtysKCsMrlPQemziQGbjBVb))]
	public virtual IEnumerable<ControllerPollingInfo> PollForAllButtons()
	{
		return new ikeGSWtysKCsMrlPQemziQGbjBVb(-2)
		{
			rbmMDTYFltFtOFqDOBnefelrKSzIA = this
		};
	}

	[IteratorStateMachine(typeof(siZdYrfzbjAhMeWmGAJNcKPyTkidc))]
	public virtual IEnumerable<ControllerPollingInfo> PollForAllButtonsDown()
	{
		return new siZdYrfzbjAhMeWmGAJNcKPyTkidc(-2)
		{
			ijOMdxBtwRUQkVuNwavottzQmEic = this
		};
	}

	private bool VVSVZXvBNAAzfnlUaZLKrCWbnCfn(int P_0, out int P_1)
	{
		P_1 = -1;
		if (!buttons[P_0].value || buttons[P_0].ZwbvvSboCZTKwwDVZHEoQwJMKeRr._excludeFromPolling)
		{
			return false;
		}
		P_1 = aHJMAWzbypGgwCcRCqDEaoqVGwfA.buttonElementIdentifierIds[P_0];
		if (P_1 < 0)
		{
			return false;
		}
		return true;
	}

	private bool fwjQLzpEEsbBygZyNQcAsNiIpkSiA(int P_0, out int P_1)
	{
		P_1 = -1;
		if (!buttons[P_0].justPressed || buttons[P_0].ZwbvvSboCZTKwwDVZHEoQwJMKeRr._excludeFromPolling)
		{
			return false;
		}
		P_1 = aHJMAWzbypGgwCcRCqDEaoqVGwfA.buttonElementIdentifierIds[P_0];
		if (P_1 < 0)
		{
			return false;
		}
		return true;
	}

	protected void UpdatePollingFrameTracking()
	{
		if (tUfYkgXutYDGqHyLjWZpqhfGCMIn == ReInput.currentFrame)
		{
			return;
		}
		BDyGopVuoRvnZVQkEFHTkumQPWjE = tUfYkgXutYDGqHyLjWZpqhfGCMIn;
		tUfYkgXutYDGqHyLjWZpqhfGCMIn = ReInput.currentFrame;
		if (!odRupMutWRqSJAgRjaskPLgzZCHl())
		{
			if (wpuYxYLINvhobUhrjHsgbKAfRtCM == uint.MaxValue)
			{
				wpuYxYLINvhobUhrjHsgbKAfRtCM = 0u;
			}
			else
			{
				wpuYxYLINvhobUhrjHsgbKAfRtCM++;
			}
		}
	}

	public virtual double GetLastTimeActive()
	{
		if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
		{
			ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
			return 0.0;
		}
		return GetLastTimeActive(useRawValues: false);
	}

	public virtual double GetLastTimeActive(bool useRawValues)
	{
		if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
		{
			ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
			return 0.0;
		}
		return GetLastTimeAnyButtonPressed();
	}

	public virtual double GetLastTimeAnyElementChanged()
	{
		if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
		{
			ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
			return 0.0;
		}
		return GetLastTimeAnyElementChanged(useRawValues: false);
	}

	public virtual double GetLastTimeAnyElementChanged(bool useRawValues)
	{
		if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
		{
			ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
			return 0.0;
		}
		return GetLastTimeAnyButtonChanged();
	}

	public double GetLastTimeAnyButtonPressed()
	{
		if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
		{
			ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
			return 0.0;
		}
		if (buttons == null)
		{
			return 0.0;
		}
		double num = 0.0;
		for (int i = 0; i < buttons.Length; i++)
		{
			double lastTimePressed = buttons[i].lastTimePressed;
			if (lastTimePressed > num)
			{
				num = lastTimePressed;
			}
		}
		return num;
	}

	public double GetLastTimeAnyButtonChanged()
	{
		if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
		{
			ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
			return 0.0;
		}
		if (buttons == null)
		{
			return 0.0;
		}
		double num = 0.0;
		for (int i = 0; i < buttons.Length; i++)
		{
			double lastTimeStateChanged = buttons[i].lastTimeStateChanged;
			if (lastTimeStateChanged > num)
			{
				num = lastTimeStateChanged;
			}
		}
		return num;
	}

	public T GetExtension<T>() where T : class
	{
		if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
		{
			ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
			return null;
		}
		return MWiCMZjmzXjuSObvCqDzietdSuqGb as T;
	}

	public IControllerTemplate GetTemplate(Guid typeGuid)
	{
		if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
		{
			ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
			return null;
		}
		for (int i = 0; i < rGStKYYhIIdyOkVxIYAJbGYAsTij.Length; i++)
		{
			if (rGStKYYhIIdyOkVxIYAJbGYAsTij[i].typeGuid == typeGuid)
			{
				return rGStKYYhIIdyOkVxIYAJbGYAsTij[i];
			}
		}
		return null;
	}

	public IControllerTemplate GetTemplate(Type type)
	{
		if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
		{
			ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
			return null;
		}
		for (int i = 0; i < rGStKYYhIIdyOkVxIYAJbGYAsTij.Length; i++)
		{
			if (ReflectionTools.DoesTypeImplement(rGStKYYhIIdyOkVxIYAJbGYAsTij[i].GetType(), type))
			{
				return rGStKYYhIIdyOkVxIYAJbGYAsTij[i];
			}
		}
		return null;
	}

	public T GetTemplate<T>() where T : class
	{
		if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
		{
			ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
			return null;
		}
		for (int i = 0; i < rGStKYYhIIdyOkVxIYAJbGYAsTij.Length; i++)
		{
			if (rGStKYYhIIdyOkVxIYAJbGYAsTij[i] as T != null)
			{
				return rGStKYYhIIdyOkVxIYAJbGYAsTij[i] as T;
			}
		}
		return null;
	}

	public bool ImplementsTemplate(Guid typeGuid)
	{
		if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
		{
			ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
			return false;
		}
		for (int i = 0; i < rGStKYYhIIdyOkVxIYAJbGYAsTij.Length; i++)
		{
			if (rGStKYYhIIdyOkVxIYAJbGYAsTij[i].typeGuid == typeGuid)
			{
				return true;
			}
		}
		return false;
	}

	public bool ImplementsTemplate(Type type)
	{
		if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
		{
			ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
			return false;
		}
		if (type == null)
		{
			throw new ArgumentNullException("type");
		}
		for (int i = 0; i < rGStKYYhIIdyOkVxIYAJbGYAsTij.Length; i++)
		{
			if (ReflectionTools.DoesTypeImplement(rGStKYYhIIdyOkVxIYAJbGYAsTij[i].GetType(), type))
			{
				return true;
			}
		}
		return false;
	}

	public bool ImplementsTemplate<T>() where T : class
	{
		return ImplementsTemplate(typeof(T));
	}

	internal void kPsuEDTOdXpQsCoZbbbDeQRSETxeA(IControllerTemplate[] P_0)
	{
		if (P_0 != null)
		{
			rGStKYYhIIdyOkVxIYAJbGYAsTij = P_0;
			DcysKrIniYGUqEDaXaTtaLmFyFOgb = new ReadOnlyCollection<IControllerTemplate>(rGStKYYhIIdyOkVxIYAJbGYAsTij);
		}
	}

	internal virtual void zGxdVtiyTLpxaqKGIAgsfZozxwRZA(UpdateLoopType P_0)
	{
		bool num = ReInput.IsInputAllowed(_type);
		int num2 = _buttonCount;
		if (num)
		{
			for (int i = 0; i < num2; i++)
			{
				if (buttons[i].FwNdZKacEHVxcSmzGOlnwqUXCNLs <= 0)
				{
					buttons[i].OnsYqlJnwMAVWAIfTSVljurlKtAhA(P_0, i, KRqNAliDQUoGilZWSpebheoTCzwBA);
				}
			}
		}
		else
		{
			for (int j = 0; j < num2; j++)
			{
				if (buttons[j].FwNdZKacEHVxcSmzGOlnwqUXCNLs <= 0)
				{
					buttons[j].ayoSbTBKdWFDfwETsGdYmfBaQPdi(P_0);
				}
			}
		}
		if (MWiCMZjmzXjuSObvCqDzietdSuqGb != null)
		{
			MWiCMZjmzXjuSObvCqDzietdSuqGb.UpdateData(P_0);
		}
	}

	internal virtual ButtonStateFlags HtEPdFGEEDRbHfBhLxoPlPNKFngt(int P_0)
	{
		if (P_0 < 0 || P_0 >= _buttonCount)
		{
			return ButtonStateFlags.Off;
		}
		return buttons[P_0].vMUPkwNHSPZVxWIOFtIuXYsDsSTu();
	}

	internal void yxBmXDsLSAcsJJQBkbrHicXGYnNt(Extension P_0)
	{
		if (P_0 == null)
		{
			MWiCMZjmzXjuSObvCqDzietdSuqGb = null;
			return;
		}
		if (MWiCMZjmzXjuSObvCqDzietdSuqGb != null)
		{
			qAPMEdjfBFkaOEGDfbMJJUmTakQgb(P_0);
			return;
		}
		P_0.SetController(this);
		MWiCMZjmzXjuSObvCqDzietdSuqGb = P_0.Clone();
	}

	internal void qAPMEdjfBFkaOEGDfbMJJUmTakQgb(Extension P_0)
	{
		if (MWiCMZjmzXjuSObvCqDzietdSuqGb != null)
		{
			MWiCMZjmzXjuSObvCqDzietdSuqGb.SetSource(P_0);
			MWiCMZjmzXjuSObvCqDzietdSuqGb.SetController(this);
			P_0?.SetController(this);
		}
		else
		{
			yxBmXDsLSAcsJJQBkbrHicXGYnNt(P_0);
		}
	}

	internal virtual void PodVUGvDnUHydzVhCxMAInDDVsXW()
	{
		for (int i = 0; i < _buttonCount; i++)
		{
			if (buttons[i] != null)
			{
				buttons[i].Reset();
			}
		}
		if (KRqNAliDQUoGilZWSpebheoTCzwBA != null)
		{
			KRqNAliDQUoGilZWSpebheoTCzwBA.ClearData();
		}
		if (MWiCMZjmzXjuSObvCqDzietdSuqGb != null)
		{
			MWiCMZjmzXjuSObvCqDzietdSuqGb.Clear();
		}
	}

	internal virtual bool inMOXJxCMugPOHqUhiIifiebgFebc(bool P_0)
	{
		if (asvNSlPOBuvyGHxmyjMJPODtXwcu == P_0)
		{
			return false;
		}
		if (!P_0)
		{
			PodVUGvDnUHydzVhCxMAInDDVsXW();
		}
		asvNSlPOBuvyGHxmyjMJPODtXwcu = P_0;
		if (cBDxuRpbtvngvoPcTJQcgAWoCPRu != null)
		{
			cBDxuRpbtvngvoPcTJQcgAWoCPRu(P_0);
		}
		return true;
	}

	internal virtual void dLKEnXOkLZMBMnjljyrBEBHwOgie(ControllerMap P_0)
	{
		if (P_0 == null)
		{
			return;
		}
		P_0.SOeQiFehSinWlJovdrhlQBwRceWF(id);
		IList<ActionElementMap> buttonMaps = P_0.ButtonMaps;
		for (int i = 0; i < buttonMaps.Count; i++)
		{
			fGQOtKpVEJmrMXNYeONgsnXNwkIC(P_0, buttonMaps[i]);
		}
		for (int num = buttonMaps.Count - 1; num >= 0; num--)
		{
			if (buttonMaps[num].elementIndex < 0)
			{
				P_0.DeleteElementMap(buttonMaps[num].LQceMJAxYgRpolrwLwsLBxilJMmNA);
			}
		}
	}

	internal virtual void fGQOtKpVEJmrMXNYeONgsnXNwkIC(ControllerMap P_0, ActionElementMap P_1)
	{
		if (P_1 != null && P_1._elementType == ControllerElementType.Button)
		{
			P_1.mmPDimdZnoHuGihimrrBmSVsLhfcb(P_0);
		}
	}

	internal bool jypwSAuFOIbgtLQDRpJBjOHqnDCE(ActionElementMap P_0, int P_1, out float P_2, out bool P_3)
	{
		P_3 = false;
		P_2 = 0f;
		if (P_1 != P_0._actionId)
		{
			return false;
		}
		int qFmDebRUzKGSVIJAwVaJJAOkGJANA = P_0.QFmDebRUzKGSVIJAwVaJJAOkGJANA;
		if (qFmDebRUzKGSVIJAwVaJJAOkGJANA < 0 || qFmDebRUzKGSVIJAwVaJJAOkGJANA >= _buttonCount)
		{
			return false;
		}
		P_3 = buttons[qFmDebRUzKGSVIJAwVaJJAOkGJANA].SAKvIjtYeGnOExEYTqzaGXSoLuCp;
		float num = ((!P_3) ? (buttons[qFmDebRUzKGSVIJAwVaJJAOkGJANA].value ? 1f : 0f) : buttons[qFmDebRUzKGSVIJAwVaJJAOkGJANA].pressure);
		if (num > 0f)
		{
			if (P_0._elementType == ControllerElementType.Button)
			{
				if (P_0._axisContribution == Pole.Negative)
				{
					num *= -1f;
				}
			}
			else if (P_0._elementType == ControllerElementType.Axis)
			{
				if (P_0._axisRange == AxisRange.Full)
				{
					if (P_0._invert)
					{
						num *= -1f;
					}
				}
				else if (P_0._axisContribution == Pole.Negative)
				{
					num *= -1f;
				}
			}
		}
		P_2 = num;
		return true;
	}

	internal bool NoHfMpjDjBVsujBHbffpLSKUGLaJ(ActionElementMap P_0, int P_1, bool P_2, out float P_3)
	{
		P_3 = 0f;
		if (P_1 != P_0._actionId)
		{
			return false;
		}
		float num = (P_2 ? 1f : 0f);
		if (num > 0f)
		{
			if (P_0._elementType == ControllerElementType.Button)
			{
				if (P_0._axisContribution == Pole.Negative)
				{
					num *= -1f;
				}
			}
			else if (P_0._elementType == ControllerElementType.Axis)
			{
				if (P_0._axisRange == AxisRange.Full)
				{
					if (P_0._invert)
					{
						num *= -1f;
					}
				}
				else if (P_0._axisContribution == Pole.Negative)
				{
					num *= -1f;
				}
			}
		}
		P_3 = num;
		return true;
	}

	internal void zkXRkxAwhqLFVfoSYoVfrkjAcGlp(Element P_0)
	{
		if (P_0 != null)
		{
			ListTools.AddIfUnique(GYUaOIhaEpeWvBAaeWZkXhENMNHVB, P_0);
		}
	}

	internal void SYaLjMzEtoNlbrCmTQhhELphwWfk(CompoundElement P_0)
	{
		if (P_0 != null)
		{
			ListTools.AddIfUnique(fUCpDTJYuPDFGZStccBSicuOgcTbA, P_0);
		}
	}

	internal virtual Guid KyiwtiWzvsoFTRhpdjgQxSETPShW()
	{
		return Guid.Empty;
	}

	internal virtual void XhWByFCKCpNTbgLDhmyYiIbaeaetb(bool P_0)
	{
		if (!P_0 && !ReInput.IsInputAllowed(_type) && MWiCMZjmzXjuSObvCqDzietdSuqGb != null)
		{
			MWiCMZjmzXjuSObvCqDzietdSuqGb.Clear();
		}
	}

	protected virtual void Connected()
	{
		_isConnected = true;
	}

	protected virtual void Disconnected()
	{
		_isConnected = false;
		if (KRqNAliDQUoGilZWSpebheoTCzwBA != null)
		{
			KRqNAliDQUoGilZWSpebheoTCzwBA.ClearData();
		}
	}

	internal static Func<Controller, Guid, bool> rfkaHYAdQqwZPLqANfnyfsLkhHWIc()
	{
		return ddJfGHEXhaagbIOuiLtstmLnzxXWb._003C_003E9.gWfYIjsDkraoSSNAhRzzwJnWbDhy;
	}

	internal static Func<Controller, Type, bool> ZKzfVpKsPvMjAwTtpeymwqHXaFaL()
	{
		return ddJfGHEXhaagbIOuiLtstmLnzxXWb._003C_003E9.NaKjjtmVsonCmSAOYtPSbaWPESFl;
	}

	[CompilerGenerated]
	private void nKZNzLvrnQsAtgOvKOuPycEWtapo()
	{
		_ = name;
	}
}
