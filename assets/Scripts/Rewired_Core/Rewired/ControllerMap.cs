using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using UnityEngine;

namespace Rewired;

public abstract class ControllerMap
{
	private class wDWpAgKhmAHViWLIVRwrZXKHdOjF : IComparer<ActionElementMap>
	{
		public static wDWpAgKhmAHViWLIVRwrZXKHdOjF dsUbBMGfnVmKZxtOTkIVppMchgcJA;

		public static wDWpAgKhmAHViWLIVRwrZXKHdOjF cDbkngVifzbZmdRNzbjADLopmcKv => qUrHDdPSLOgGvPzcqwjCxMRVGMCFA();

		public static wDWpAgKhmAHViWLIVRwrZXKHdOjF qUrHDdPSLOgGvPzcqwjCxMRVGMCFA()
		{
			return dsUbBMGfnVmKZxtOTkIVppMchgcJA ?? (dsUbBMGfnVmKZxtOTkIVppMchgcJA = new wDWpAgKhmAHViWLIVRwrZXKHdOjF());
		}

		public int Compare(ActionElementMap x, ActionElementMap y)
		{
			if (x == null)
			{
				if (y == null)
				{
					return 0;
				}
				return -1;
			}
			if (y == null)
			{
				return 1;
			}
			if (x._elementType == y._elementType)
			{
				return x.id.CompareTo(y.id);
			}
			if (x._elementType switch
			{
				ControllerElementType.Button => 0, 
				ControllerElementType.Axis => 1, 
				ControllerElementType.CompoundElement => 2, 
				_ => throw new NotImplementedException(), 
			} <= y._elementType switch
			{
				ControllerElementType.Button => 0, 
				ControllerElementType.Axis => 1, 
				ControllerElementType.CompoundElement => 2, 
				_ => throw new NotImplementedException(), 
			})
			{
				return -1;
			}
			return 1;
		}

		int IComparer<ActionElementMap>.Compare(ActionElementMap x, ActionElementMap y)
		{
			//ILSpy generated this explicit interface implementation from .override directive in Compare
			return this.Compare(x, y);
		}
	}

	private sealed class VrxOlbyIWRqpsSLgBUAEPheRMuOl : IEnumerable<ActionElementMap>, IEnumerable, IEnumerator<ActionElementMap>, IEnumerator, IDisposable
	{
		private int aCjtOQHYppxAjBRNVOiBNioAZQbE;

		private ActionElementMap EZcFduGRIuWLxNJeThnAdNeibXoWB;

		private int ZKmNvBkFczMstzmKCQBetAmTmbPc;

		public ControllerMap MKvoNOqakyixVFOZHnEulohNdHuI;

		private int uNHsbyTPbKrIgeqKuPCzaOvNErmiA;

		public int RbsxpNtYiBaPCWWEIxmMrbNcOaNE;

		private bool LrXpqxGpANeNOEbqiVwnewaoJWZCA;

		public bool FpbLPVLHrQZPSkcXEXqqIXWnoLBd;

		private IList<ActionElementMap> fbsqAAnMnyzRbQnlkpZUAAoBRYEw;

		private int sSgeiKaBaZmTQmUITybmPKiXGJax;

		private int lfCwecLkEUpmiVbtqQtLienKMFgW;

		ActionElementMap IEnumerator<ActionElementMap>.Current
		{
			[DebuggerHidden]
			get
			{
				return EZcFduGRIuWLxNJeThnAdNeibXoWB;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return EZcFduGRIuWLxNJeThnAdNeibXoWB;
			}
		}

		[DebuggerHidden]
		public VrxOlbyIWRqpsSLgBUAEPheRMuOl(int P_0)
		{
			aCjtOQHYppxAjBRNVOiBNioAZQbE = P_0;
			ZKmNvBkFczMstzmKCQBetAmTmbPc = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			int num = aCjtOQHYppxAjBRNVOiBNioAZQbE;
			ControllerMap mKvoNOqakyixVFOZHnEulohNdHuI = MKvoNOqakyixVFOZHnEulohNdHuI;
			if (num != 0)
			{
				if (num != 1)
				{
					return false;
				}
				aCjtOQHYppxAjBRNVOiBNioAZQbE = -1;
				goto IL_00af;
			}
			aCjtOQHYppxAjBRNVOiBNioAZQbE = -1;
			if (ReInput._id != mKvoNOqakyixVFOZHnEulohNdHuI.XTCjmLKuHDyBHCdnAHQddPuHUPTo)
			{
				ReInput.CheckInitialized(mKvoNOqakyixVFOZHnEulohNdHuI.XTCjmLKuHDyBHCdnAHQddPuHUPTo);
				return false;
			}
			if (uNHsbyTPbKrIgeqKuPCzaOvNErmiA < 0)
			{
				return false;
			}
			fbsqAAnMnyzRbQnlkpZUAAoBRYEw = mKvoNOqakyixVFOZHnEulohNdHuI.ButtonMaps;
			sSgeiKaBaZmTQmUITybmPKiXGJax = mKvoNOqakyixVFOZHnEulohNdHuI.buttonMapCount;
			lfCwecLkEUpmiVbtqQtLienKMFgW = 0;
			goto IL_00bf;
			IL_00bf:
			if (lfCwecLkEUpmiVbtqQtLienKMFgW < sSgeiKaBaZmTQmUITybmPKiXGJax)
			{
				ActionElementMap actionElementMap = fbsqAAnMnyzRbQnlkpZUAAoBRYEw[lfCwecLkEUpmiVbtqQtLienKMFgW];
				if (actionElementMap._actionId == uNHsbyTPbKrIgeqKuPCzaOvNErmiA && (!LrXpqxGpANeNOEbqiVwnewaoJWZCA || actionElementMap.YbgQyWQdQcTTSlKYNScpqBbjmQQo))
				{
					EZcFduGRIuWLxNJeThnAdNeibXoWB = actionElementMap;
					aCjtOQHYppxAjBRNVOiBNioAZQbE = 1;
					return true;
				}
				goto IL_00af;
			}
			return false;
			IL_00af:
			lfCwecLkEUpmiVbtqQtLienKMFgW++;
			goto IL_00bf;
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
		IEnumerator<ActionElementMap> IEnumerable<ActionElementMap>.GetEnumerator()
		{
			VrxOlbyIWRqpsSLgBUAEPheRMuOl vrxOlbyIWRqpsSLgBUAEPheRMuOl;
			if (aCjtOQHYppxAjBRNVOiBNioAZQbE == -2 && ZKmNvBkFczMstzmKCQBetAmTmbPc == Environment.CurrentManagedThreadId)
			{
				aCjtOQHYppxAjBRNVOiBNioAZQbE = 0;
				vrxOlbyIWRqpsSLgBUAEPheRMuOl = this;
			}
			else
			{
				vrxOlbyIWRqpsSLgBUAEPheRMuOl = new VrxOlbyIWRqpsSLgBUAEPheRMuOl(0);
				vrxOlbyIWRqpsSLgBUAEPheRMuOl.MKvoNOqakyixVFOZHnEulohNdHuI = MKvoNOqakyixVFOZHnEulohNdHuI;
			}
			vrxOlbyIWRqpsSLgBUAEPheRMuOl.uNHsbyTPbKrIgeqKuPCzaOvNErmiA = RbsxpNtYiBaPCWWEIxmMrbNcOaNE;
			vrxOlbyIWRqpsSLgBUAEPheRMuOl.LrXpqxGpANeNOEbqiVwnewaoJWZCA = FpbLPVLHrQZPSkcXEXqqIXWnoLBd;
			return vrxOlbyIWRqpsSLgBUAEPheRMuOl;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
		}
	}

	private sealed class eRFHQorYBSRLfwumqWTbSiUmijbv : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
	{
		private int FcbFTKWnjfrnfVoqfhuwXWpnmyMO;

		private ElementAssignmentConflictInfo RiHKWjWWctofPlqunAFuKsNzmCBVA;

		private int RiiBrmJCpPvljAyHDAxQcwUGhAdFc;

		public ControllerMap DjtUiRvZYvVBPybdjiBYRekPaShKA;

		private ControllerMap aRagaoBKyPTpIEhOOBwTgoIFOwVr;

		public ControllerMap SqkiqeXcZMBkJtNDqVTrSGyPmhnW;

		private bool AXqEVEsYXJIGVKIzDiRDgUKVJIZc;

		public bool DOORVRQeSVGkbKtlzpdJJxljyMoc;

		private IList<ActionElementMap> UcjcgCJXzvcuWotJytyxrQDWHLxib;

		private int jZdlzCMEBceRlaGqZRCBiOCLwgeLA;

		private int LHuEFLBBtDNFGFkDGsIzvDlfnnZLb;

		private ActionElementMap FRvfFKTMmADeZKZtYFbPbbbTlayG;

		private int WNffrzbDHeawmhaURxHQMhDbAiscb;

		ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
		{
			[DebuggerHidden]
			get
			{
				return RiHKWjWWctofPlqunAFuKsNzmCBVA;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return RiHKWjWWctofPlqunAFuKsNzmCBVA;
			}
		}

		[DebuggerHidden]
		public eRFHQorYBSRLfwumqWTbSiUmijbv(int P_0)
		{
			FcbFTKWnjfrnfVoqfhuwXWpnmyMO = P_0;
			RiiBrmJCpPvljAyHDAxQcwUGhAdFc = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			int fcbFTKWnjfrnfVoqfhuwXWpnmyMO = FcbFTKWnjfrnfVoqfhuwXWpnmyMO;
			ControllerMap djtUiRvZYvVBPybdjiBYRekPaShKA = DjtUiRvZYvVBPybdjiBYRekPaShKA;
			if (fcbFTKWnjfrnfVoqfhuwXWpnmyMO != 0)
			{
				if (fcbFTKWnjfrnfVoqfhuwXWpnmyMO != 1)
				{
					return false;
				}
				FcbFTKWnjfrnfVoqfhuwXWpnmyMO = -1;
				goto IL_019c;
			}
			FcbFTKWnjfrnfVoqfhuwXWpnmyMO = -1;
			if (ReInput._id != djtUiRvZYvVBPybdjiBYRekPaShKA.XTCjmLKuHDyBHCdnAHQddPuHUPTo)
			{
				ReInput.CheckInitialized(djtUiRvZYvVBPybdjiBYRekPaShKA.XTCjmLKuHDyBHCdnAHQddPuHUPTo);
				return false;
			}
			if (aRagaoBKyPTpIEhOOBwTgoIFOwVr == null || djtUiRvZYvVBPybdjiBYRekPaShKA.fsfgfURoXdRGlcXBSbnalDeYMNiB == null)
			{
				return false;
			}
			if (AXqEVEsYXJIGVKIzDiRDgUKVJIZc && (!djtUiRvZYvVBPybdjiBYRekPaShKA._enabled || !aRagaoBKyPTpIEhOOBwTgoIFOwVr._enabled))
			{
				return false;
			}
			UcjcgCJXzvcuWotJytyxrQDWHLxib = aRagaoBKyPTpIEhOOBwTgoIFOwVr.ButtonMaps;
			if (UcjcgCJXzvcuWotJytyxrQDWHLxib == null)
			{
				return false;
			}
			jZdlzCMEBceRlaGqZRCBiOCLwgeLA = UcjcgCJXzvcuWotJytyxrQDWHLxib.Count;
			LHuEFLBBtDNFGFkDGsIzvDlfnnZLb = 0;
			goto IL_01d4;
			IL_01d4:
			if (LHuEFLBBtDNFGFkDGsIzvDlfnnZLb < djtUiRvZYvVBPybdjiBYRekPaShKA.fsfgfURoXdRGlcXBSbnalDeYMNiB.get_Count())
			{
				FRvfFKTMmADeZKZtYFbPbbbTlayG = djtUiRvZYvVBPybdjiBYRekPaShKA.fsfgfURoXdRGlcXBSbnalDeYMNiB.get_Item(LHuEFLBBtDNFGFkDGsIzvDlfnnZLb);
				if (!AXqEVEsYXJIGVKIzDiRDgUKVJIZc || FRvfFKTMmADeZKZtYFbPbbbTlayG.YbgQyWQdQcTTSlKYNScpqBbjmQQo)
				{
					WNffrzbDHeawmhaURxHQMhDbAiscb = 0;
					goto IL_01ac;
				}
				goto IL_01c4;
			}
			return false;
			IL_01ac:
			if (WNffrzbDHeawmhaURxHQMhDbAiscb < jZdlzCMEBceRlaGqZRCBiOCLwgeLA)
			{
				ActionElementMap actionElementMap = UcjcgCJXzvcuWotJytyxrQDWHLxib[WNffrzbDHeawmhaURxHQMhDbAiscb];
				if ((!AXqEVEsYXJIGVKIzDiRDgUKVJIZc || actionElementMap.YbgQyWQdQcTTSlKYNScpqBbjmQQo) && FRvfFKTMmADeZKZtYFbPbbbTlayG.CheckForAssignmentConflict(actionElementMap))
				{
					RiHKWjWWctofPlqunAFuKsNzmCBVA = new ElementAssignmentConflictInfo(true, ReInput.mapping.GetMapCategory(djtUiRvZYvVBPybdjiBYRekPaShKA._categoryId).userAssignable, -1, djtUiRvZYvVBPybdjiBYRekPaShKA._controllerType, djtUiRvZYvVBPybdjiBYRekPaShKA._controllerId, djtUiRvZYvVBPybdjiBYRekPaShKA._id, FRvfFKTMmADeZKZtYFbPbbbTlayG.LQceMJAxYgRpolrwLwsLBxilJMmNA, FRvfFKTMmADeZKZtYFbPbbbTlayG._actionId, FRvfFKTMmADeZKZtYFbPbbbTlayG._elementType, FRvfFKTMmADeZKZtYFbPbbbTlayG._elementIdentifierId, FRvfFKTMmADeZKZtYFbPbbbTlayG.keyCode, FRvfFKTMmADeZKZtYFbPbbbTlayG.modifierKeyFlags);
					FcbFTKWnjfrnfVoqfhuwXWpnmyMO = 1;
					return true;
				}
				goto IL_019c;
			}
			FRvfFKTMmADeZKZtYFbPbbbTlayG = null;
			goto IL_01c4;
			IL_01c4:
			LHuEFLBBtDNFGFkDGsIzvDlfnnZLb++;
			goto IL_01d4;
			IL_019c:
			WNffrzbDHeawmhaURxHQMhDbAiscb++;
			goto IL_01ac;
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
		IEnumerator<ElementAssignmentConflictInfo> IEnumerable<ElementAssignmentConflictInfo>.GetEnumerator()
		{
			eRFHQorYBSRLfwumqWTbSiUmijbv eRFHQorYBSRLfwumqWTbSiUmijbv2;
			if (FcbFTKWnjfrnfVoqfhuwXWpnmyMO == -2 && RiiBrmJCpPvljAyHDAxQcwUGhAdFc == Environment.CurrentManagedThreadId)
			{
				FcbFTKWnjfrnfVoqfhuwXWpnmyMO = 0;
				eRFHQorYBSRLfwumqWTbSiUmijbv2 = this;
			}
			else
			{
				eRFHQorYBSRLfwumqWTbSiUmijbv2 = new eRFHQorYBSRLfwumqWTbSiUmijbv(0);
				eRFHQorYBSRLfwumqWTbSiUmijbv2.DjtUiRvZYvVBPybdjiBYRekPaShKA = DjtUiRvZYvVBPybdjiBYRekPaShKA;
			}
			eRFHQorYBSRLfwumqWTbSiUmijbv2.aRagaoBKyPTpIEhOOBwTgoIFOwVr = SqkiqeXcZMBkJtNDqVTrSGyPmhnW;
			eRFHQorYBSRLfwumqWTbSiUmijbv2.AXqEVEsYXJIGVKIzDiRDgUKVJIZc = DOORVRQeSVGkbKtlzpdJJxljyMoc;
			return eRFHQorYBSRLfwumqWTbSiUmijbv2;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
		}
	}

	private sealed class igDPRBeolHFHrPYzhHHFayQiIwLU : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
	{
		private int CRHDjgKdBAdHeBCKEnzHZTYSgoRG;

		private ElementAssignmentConflictInfo hEwiCPuUIajfMMMaoGHprQyFBlYhA;

		private int lOzeqKUFMfjioDtaIjvxWRZODRbhA;

		public ControllerMap XLMCJCTDLAIwnBEUVAlSsfywkkFZ;

		private ActionElementMap UrDEagAMlRSVvEapStWrPTvBxeZm;

		public ActionElementMap WCRGplpgslKoeQpsLkmxEQDjcuRI;

		private bool HueGNVmOCQSJuOWEMbWKRAfNMdah;

		public bool RUZcFtHRNJjuEHoXOrpbCFUKOvzD;

		private int jOuQFOizWTAqHiBiNOAmxxBceqkQ;

		ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
		{
			[DebuggerHidden]
			get
			{
				return hEwiCPuUIajfMMMaoGHprQyFBlYhA;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return hEwiCPuUIajfMMMaoGHprQyFBlYhA;
			}
		}

		[DebuggerHidden]
		public igDPRBeolHFHrPYzhHHFayQiIwLU(int P_0)
		{
			CRHDjgKdBAdHeBCKEnzHZTYSgoRG = P_0;
			lOzeqKUFMfjioDtaIjvxWRZODRbhA = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			int cRHDjgKdBAdHeBCKEnzHZTYSgoRG = CRHDjgKdBAdHeBCKEnzHZTYSgoRG;
			ControllerMap xLMCJCTDLAIwnBEUVAlSsfywkkFZ = XLMCJCTDLAIwnBEUVAlSsfywkkFZ;
			if (cRHDjgKdBAdHeBCKEnzHZTYSgoRG != 0)
			{
				if (cRHDjgKdBAdHeBCKEnzHZTYSgoRG != 1)
				{
					return false;
				}
				CRHDjgKdBAdHeBCKEnzHZTYSgoRG = -1;
				goto IL_0111;
			}
			CRHDjgKdBAdHeBCKEnzHZTYSgoRG = -1;
			if (ReInput._id != xLMCJCTDLAIwnBEUVAlSsfywkkFZ.XTCjmLKuHDyBHCdnAHQddPuHUPTo)
			{
				ReInput.CheckInitialized(xLMCJCTDLAIwnBEUVAlSsfywkkFZ.XTCjmLKuHDyBHCdnAHQddPuHUPTo);
				return false;
			}
			if (UrDEagAMlRSVvEapStWrPTvBxeZm == null || xLMCJCTDLAIwnBEUVAlSsfywkkFZ.fsfgfURoXdRGlcXBSbnalDeYMNiB == null)
			{
				return false;
			}
			if (HueGNVmOCQSJuOWEMbWKRAfNMdah && (!xLMCJCTDLAIwnBEUVAlSsfywkkFZ._enabled || !UrDEagAMlRSVvEapStWrPTvBxeZm.YbgQyWQdQcTTSlKYNScpqBbjmQQo))
			{
				return false;
			}
			jOuQFOizWTAqHiBiNOAmxxBceqkQ = 0;
			goto IL_0121;
			IL_0111:
			jOuQFOizWTAqHiBiNOAmxxBceqkQ++;
			goto IL_0121;
			IL_0121:
			if (jOuQFOizWTAqHiBiNOAmxxBceqkQ < xLMCJCTDLAIwnBEUVAlSsfywkkFZ.fsfgfURoXdRGlcXBSbnalDeYMNiB.get_Count())
			{
				ActionElementMap actionElementMap = xLMCJCTDLAIwnBEUVAlSsfywkkFZ.fsfgfURoXdRGlcXBSbnalDeYMNiB.get_Item(jOuQFOizWTAqHiBiNOAmxxBceqkQ);
				if ((!HueGNVmOCQSJuOWEMbWKRAfNMdah || actionElementMap.YbgQyWQdQcTTSlKYNScpqBbjmQQo) && actionElementMap.CheckForAssignmentConflict(UrDEagAMlRSVvEapStWrPTvBxeZm))
				{
					hEwiCPuUIajfMMMaoGHprQyFBlYhA = new ElementAssignmentConflictInfo(true, ReInput.mapping.GetMapCategory(xLMCJCTDLAIwnBEUVAlSsfywkkFZ._categoryId).userAssignable, -1, xLMCJCTDLAIwnBEUVAlSsfywkkFZ._controllerType, xLMCJCTDLAIwnBEUVAlSsfywkkFZ._controllerId, xLMCJCTDLAIwnBEUVAlSsfywkkFZ._id, actionElementMap.LQceMJAxYgRpolrwLwsLBxilJMmNA, actionElementMap._actionId, actionElementMap._elementType, actionElementMap._elementIdentifierId, actionElementMap.keyCode, actionElementMap.modifierKeyFlags);
					CRHDjgKdBAdHeBCKEnzHZTYSgoRG = 1;
					return true;
				}
				goto IL_0111;
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
		IEnumerator<ElementAssignmentConflictInfo> IEnumerable<ElementAssignmentConflictInfo>.GetEnumerator()
		{
			igDPRBeolHFHrPYzhHHFayQiIwLU igDPRBeolHFHrPYzhHHFayQiIwLU2;
			if (CRHDjgKdBAdHeBCKEnzHZTYSgoRG == -2 && lOzeqKUFMfjioDtaIjvxWRZODRbhA == Environment.CurrentManagedThreadId)
			{
				CRHDjgKdBAdHeBCKEnzHZTYSgoRG = 0;
				igDPRBeolHFHrPYzhHHFayQiIwLU2 = this;
			}
			else
			{
				igDPRBeolHFHrPYzhHHFayQiIwLU2 = new igDPRBeolHFHrPYzhHHFayQiIwLU(0);
				igDPRBeolHFHrPYzhHHFayQiIwLU2.XLMCJCTDLAIwnBEUVAlSsfywkkFZ = XLMCJCTDLAIwnBEUVAlSsfywkkFZ;
			}
			igDPRBeolHFHrPYzhHHFayQiIwLU2.UrDEagAMlRSVvEapStWrPTvBxeZm = WCRGplpgslKoeQpsLkmxEQDjcuRI;
			igDPRBeolHFHrPYzhHHFayQiIwLU2.HueGNVmOCQSJuOWEMbWKRAfNMdah = RUZcFtHRNJjuEHoXOrpbCFUKOvzD;
			return igDPRBeolHFHrPYzhHHFayQiIwLU2;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
		}
	}

	private sealed class inHjaHkNRGJgKFziSMIFRFgLIcdJA : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
	{
		private int ywDjGncSTJSAmvBkYDUtcYGSwqZH;

		private ElementAssignmentConflictInfo AvxsBrRoWUnJhZljOFoeqlzcpwdB;

		private int PcyeUpoKYKEJXFKwCSqReqBxkXlo;

		public ControllerMap kUessGviNrPvgRzslDVdEHNvklwL;

		private bool nULKhycjAPrjKPfOWNOJfdeLiztN;

		public bool TJjFSgScYdtBqktObjXCyQjIvlEF;

		private ElementAssignmentConflictCheck ihyENDwAweLRnjxJTjLisckXMKhB;

		public ElementAssignmentConflictCheck mkpfSwaPiWcWldMdAhSdOekGBiewB;

		private ElementAssignment rpchebFcdYlwrDLkbEqRKrbPfwFEA;

		private int WArBbuXZYMeZFPjmzCHDUKZSfkqKA;

		ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
		{
			[DebuggerHidden]
			get
			{
				return AvxsBrRoWUnJhZljOFoeqlzcpwdB;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return AvxsBrRoWUnJhZljOFoeqlzcpwdB;
			}
		}

		[DebuggerHidden]
		public inHjaHkNRGJgKFziSMIFRFgLIcdJA(int P_0)
		{
			ywDjGncSTJSAmvBkYDUtcYGSwqZH = P_0;
			PcyeUpoKYKEJXFKwCSqReqBxkXlo = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			int num = ywDjGncSTJSAmvBkYDUtcYGSwqZH;
			ControllerMap controllerMap = kUessGviNrPvgRzslDVdEHNvklwL;
			if (num != 0)
			{
				if (num != 1)
				{
					return false;
				}
				ywDjGncSTJSAmvBkYDUtcYGSwqZH = -1;
				goto IL_0123;
			}
			ywDjGncSTJSAmvBkYDUtcYGSwqZH = -1;
			if (ReInput._id != controllerMap.XTCjmLKuHDyBHCdnAHQddPuHUPTo)
			{
				ReInput.CheckInitialized(controllerMap.XTCjmLKuHDyBHCdnAHQddPuHUPTo);
				return false;
			}
			if (nULKhycjAPrjKPfOWNOJfdeLiztN && !controllerMap._enabled)
			{
				return false;
			}
			if (controllerMap.fsfgfURoXdRGlcXBSbnalDeYMNiB == null)
			{
				return false;
			}
			rpchebFcdYlwrDLkbEqRKrbPfwFEA = ihyENDwAweLRnjxJTjLisckXMKhB.ToElementAssignment();
			WArBbuXZYMeZFPjmzCHDUKZSfkqKA = 0;
			goto IL_0133;
			IL_0133:
			if (WArBbuXZYMeZFPjmzCHDUKZSfkqKA < controllerMap.fsfgfURoXdRGlcXBSbnalDeYMNiB.get_Count())
			{
				ActionElementMap actionElementMap = controllerMap.fsfgfURoXdRGlcXBSbnalDeYMNiB.get_Item(WArBbuXZYMeZFPjmzCHDUKZSfkqKA);
				if ((!nULKhycjAPrjKPfOWNOJfdeLiztN || actionElementMap.YbgQyWQdQcTTSlKYNScpqBbjmQQo) && actionElementMap.LQceMJAxYgRpolrwLwsLBxilJMmNA != ihyENDwAweLRnjxJTjLisckXMKhB.elementMapId && actionElementMap.CheckForAssignmentConflict(rpchebFcdYlwrDLkbEqRKrbPfwFEA))
				{
					AvxsBrRoWUnJhZljOFoeqlzcpwdB = new ElementAssignmentConflictInfo(true, ReInput.mapping.GetMapCategory(controllerMap._categoryId).userAssignable, -1, controllerMap._controllerType, controllerMap._controllerId, controllerMap._id, actionElementMap.LQceMJAxYgRpolrwLwsLBxilJMmNA, actionElementMap._actionId, actionElementMap._elementType, actionElementMap._elementIdentifierId, actionElementMap.keyCode, actionElementMap.modifierKeyFlags);
					ywDjGncSTJSAmvBkYDUtcYGSwqZH = 1;
					return true;
				}
				goto IL_0123;
			}
			return false;
			IL_0123:
			WArBbuXZYMeZFPjmzCHDUKZSfkqKA++;
			goto IL_0133;
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
		IEnumerator<ElementAssignmentConflictInfo> IEnumerable<ElementAssignmentConflictInfo>.GetEnumerator()
		{
			inHjaHkNRGJgKFziSMIFRFgLIcdJA inHjaHkNRGJgKFziSMIFRFgLIcdJA2;
			if (ywDjGncSTJSAmvBkYDUtcYGSwqZH == -2 && PcyeUpoKYKEJXFKwCSqReqBxkXlo == Environment.CurrentManagedThreadId)
			{
				ywDjGncSTJSAmvBkYDUtcYGSwqZH = 0;
				inHjaHkNRGJgKFziSMIFRFgLIcdJA2 = this;
			}
			else
			{
				inHjaHkNRGJgKFziSMIFRFgLIcdJA2 = new inHjaHkNRGJgKFziSMIFRFgLIcdJA(0);
				inHjaHkNRGJgKFziSMIFRFgLIcdJA2.kUessGviNrPvgRzslDVdEHNvklwL = kUessGviNrPvgRzslDVdEHNvklwL;
			}
			inHjaHkNRGJgKFziSMIFRFgLIcdJA2.ihyENDwAweLRnjxJTjLisckXMKhB = mkpfSwaPiWcWldMdAhSdOekGBiewB;
			inHjaHkNRGJgKFziSMIFRFgLIcdJA2.nULKhycjAPrjKPfOWNOJfdeLiztN = TJjFSgScYdtBqktObjXCyQjIvlEF;
			return inHjaHkNRGJgKFziSMIFRFgLIcdJA2;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
		}
	}

	private sealed class YdOcJzJPajVVEeOKrVajIrcHJylKA : IEnumerable<ActionElementMap>, IEnumerable, IEnumerator<ActionElementMap>, IEnumerator, IDisposable
	{
		private int nPYBaYSPHEgoydKxZsRPTuTNfwrg;

		private ActionElementMap hkJxnJVazNwIPfIYGvnvNpURaZLFA;

		private int aYFsfhdqMaEctaxKFZNrvIAWLWcLA;

		public ControllerMap cVaujgOGXKRHaJyQOiLBcRExySQG;

		private int CwWiMOAxCBkGPQPmqtTtOTUbRjcj;

		public int aEEAZIDgvirZeOCpSHKqGDjBRiiFB;

		private bool ThQNzmazsivvEXKLjGChNksyuaQi;

		public bool AHmBGXCWWFgoiUJjPiEPXFaQBJNAA;

		private IEnumerator<ActionElementMap> jgqBTxffihYXAugycqRXHqJXJrIoA;

		ActionElementMap IEnumerator<ActionElementMap>.Current
		{
			[DebuggerHidden]
			get
			{
				return hkJxnJVazNwIPfIYGvnvNpURaZLFA;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return hkJxnJVazNwIPfIYGvnvNpURaZLFA;
			}
		}

		[DebuggerHidden]
		public YdOcJzJPajVVEeOKrVajIrcHJylKA(int P_0)
		{
			nPYBaYSPHEgoydKxZsRPTuTNfwrg = P_0;
			aYFsfhdqMaEctaxKFZNrvIAWLWcLA = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			int num = nPYBaYSPHEgoydKxZsRPTuTNfwrg;
			if (num == -3 || num == 1)
			{
				try
				{
				}
				finally
				{
					YgpIqXXgtgJopiFNyUJzliTKjeMK();
				}
			}
		}

		private bool MoveNext()
		{
			try
			{
				int num = nPYBaYSPHEgoydKxZsRPTuTNfwrg;
				ControllerMap controllerMap = cVaujgOGXKRHaJyQOiLBcRExySQG;
				switch (num)
				{
				default:
					return false;
				case 0:
					nPYBaYSPHEgoydKxZsRPTuTNfwrg = -1;
					if (ReInput._id != controllerMap.XTCjmLKuHDyBHCdnAHQddPuHUPTo)
					{
						ReInput.CheckInitialized(controllerMap.XTCjmLKuHDyBHCdnAHQddPuHUPTo);
						return false;
					}
					jgqBTxffihYXAugycqRXHqJXJrIoA = controllerMap.AllMaps.GetEnumerator();
					nPYBaYSPHEgoydKxZsRPTuTNfwrg = -3;
					break;
				case 1:
					nPYBaYSPHEgoydKxZsRPTuTNfwrg = -3;
					break;
				}
				while (jgqBTxffihYXAugycqRXHqJXJrIoA.MoveNext())
				{
					ActionElementMap current = jgqBTxffihYXAugycqRXHqJXJrIoA.Current;
					if (current._actionId == CwWiMOAxCBkGPQPmqtTtOTUbRjcj && (!ThQNzmazsivvEXKLjGChNksyuaQi || current.YbgQyWQdQcTTSlKYNScpqBbjmQQo))
					{
						hkJxnJVazNwIPfIYGvnvNpURaZLFA = current;
						nPYBaYSPHEgoydKxZsRPTuTNfwrg = 1;
						return true;
					}
				}
				YgpIqXXgtgJopiFNyUJzliTKjeMK();
				jgqBTxffihYXAugycqRXHqJXJrIoA = null;
				return false;
			}
			catch
			{
				//try-fault
				((IDisposable)this).Dispose();
				throw;
			}
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		private void YgpIqXXgtgJopiFNyUJzliTKjeMK()
		{
			nPYBaYSPHEgoydKxZsRPTuTNfwrg = -1;
			if (jgqBTxffihYXAugycqRXHqJXJrIoA != null)
			{
				jgqBTxffihYXAugycqRXHqJXJrIoA.Dispose();
			}
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		IEnumerator<ActionElementMap> IEnumerable<ActionElementMap>.GetEnumerator()
		{
			YdOcJzJPajVVEeOKrVajIrcHJylKA ydOcJzJPajVVEeOKrVajIrcHJylKA;
			if (nPYBaYSPHEgoydKxZsRPTuTNfwrg == -2 && aYFsfhdqMaEctaxKFZNrvIAWLWcLA == Environment.CurrentManagedThreadId)
			{
				nPYBaYSPHEgoydKxZsRPTuTNfwrg = 0;
				ydOcJzJPajVVEeOKrVajIrcHJylKA = this;
			}
			else
			{
				ydOcJzJPajVVEeOKrVajIrcHJylKA = new YdOcJzJPajVVEeOKrVajIrcHJylKA(0);
				ydOcJzJPajVVEeOKrVajIrcHJylKA.cVaujgOGXKRHaJyQOiLBcRExySQG = cVaujgOGXKRHaJyQOiLBcRExySQG;
			}
			ydOcJzJPajVVEeOKrVajIrcHJylKA.CwWiMOAxCBkGPQPmqtTtOTUbRjcj = aEEAZIDgvirZeOCpSHKqGDjBRiiFB;
			ydOcJzJPajVVEeOKrVajIrcHJylKA.ThQNzmazsivvEXKLjGChNksyuaQi = AHmBGXCWWFgoiUJjPiEPXFaQBJNAA;
			return ydOcJzJPajVVEeOKrVajIrcHJylKA;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
		}
	}

	private sealed class ZeYCKTaOIxdyFJOPFuEMdhcmIbQuA : IEnumerable<ActionElementMap>, IEnumerable, IEnumerator<ActionElementMap>, IEnumerator, IDisposable
	{
		private int ZMxHTfstJyhqDcUdclUPbkxnVRmM;

		private ActionElementMap JwNpHWsMJAIqekrHYpFUzZxASXHdA;

		private int PspEAEzBimCjUJeesGhGuAMzHlXfA;

		public ControllerMap bUXUVnpmqssLvvEPmQPDcaHJEJRH;

		private IControllerElementTarget CZCdALoUTMyIcPNqJbTpigFCVQaB;

		public IControllerElementTarget sUUQrbKQAjCspqPIaFfGOrZhzZyd;

		private bool GuSikKyiaYgznCeWxvgJbsTheTon;

		public bool OHzHEFlQBuVhIHydWiYmyTrtfNcW;

		private TempListPool.TList<ActionElementMap> IdDsKjpFjlrqekkgJDRUJTgfFIDJ;

		private List<ActionElementMap>.Enumerator aELWbgfplyFaGosMDkRvbLAiCwdA;

		ActionElementMap IEnumerator<ActionElementMap>.Current
		{
			[DebuggerHidden]
			get
			{
				return JwNpHWsMJAIqekrHYpFUzZxASXHdA;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return JwNpHWsMJAIqekrHYpFUzZxASXHdA;
			}
		}

		[DebuggerHidden]
		public ZeYCKTaOIxdyFJOPFuEMdhcmIbQuA(int P_0)
		{
			ZMxHTfstJyhqDcUdclUPbkxnVRmM = P_0;
			PspEAEzBimCjUJeesGhGuAMzHlXfA = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			int zMxHTfstJyhqDcUdclUPbkxnVRmM = ZMxHTfstJyhqDcUdclUPbkxnVRmM;
			if ((uint)(zMxHTfstJyhqDcUdclUPbkxnVRmM - -4) > 1u && zMxHTfstJyhqDcUdclUPbkxnVRmM != 1)
			{
				return;
			}
			try
			{
				if (zMxHTfstJyhqDcUdclUPbkxnVRmM != -4 && zMxHTfstJyhqDcUdclUPbkxnVRmM != 1)
				{
					return;
				}
				try
				{
				}
				finally
				{
					mAVYOadTjfRogbZubbiFueOlnCYV();
				}
			}
			finally
			{
				FSXzAOuNiuWooMbtMwswfbjIwPWg();
			}
		}

		private bool MoveNext()
		{
			try
			{
				int zMxHTfstJyhqDcUdclUPbkxnVRmM = ZMxHTfstJyhqDcUdclUPbkxnVRmM;
				ControllerMap controllerMap = bUXUVnpmqssLvvEPmQPDcaHJEJRH;
				switch (zMxHTfstJyhqDcUdclUPbkxnVRmM)
				{
				default:
					return false;
				case 0:
				{
					ZMxHTfstJyhqDcUdclUPbkxnVRmM = -1;
					if (ReInput._id != controllerMap.XTCjmLKuHDyBHCdnAHQddPuHUPTo)
					{
						ReInput.CheckInitialized(controllerMap.XTCjmLKuHDyBHCdnAHQddPuHUPTo);
						return false;
					}
					IdDsKjpFjlrqekkgJDRUJTgfFIDJ = TempListPool.GetTList<ActionElementMap>();
					ZMxHTfstJyhqDcUdclUPbkxnVRmM = -3;
					List<ActionElementMap> list = IdDsKjpFjlrqekkgJDRUJTgfFIDJ.list;
					controllerMap.AQsAVNZYhsajiONJBaCUyUaUYtSD(CZCdALoUTMyIcPNqJbTpigFCVQaB, false, -1, GuSikKyiaYgznCeWxvgJbsTheTon, list, false, out var _);
					aELWbgfplyFaGosMDkRvbLAiCwdA = list.GetEnumerator();
					ZMxHTfstJyhqDcUdclUPbkxnVRmM = -4;
					break;
				}
				case 1:
					ZMxHTfstJyhqDcUdclUPbkxnVRmM = -4;
					break;
				}
				if (aELWbgfplyFaGosMDkRvbLAiCwdA.MoveNext())
				{
					ActionElementMap current = aELWbgfplyFaGosMDkRvbLAiCwdA.Current;
					JwNpHWsMJAIqekrHYpFUzZxASXHdA = current;
					ZMxHTfstJyhqDcUdclUPbkxnVRmM = 1;
					return true;
				}
				mAVYOadTjfRogbZubbiFueOlnCYV();
				aELWbgfplyFaGosMDkRvbLAiCwdA = default;
				FSXzAOuNiuWooMbtMwswfbjIwPWg();
				IdDsKjpFjlrqekkgJDRUJTgfFIDJ = null;
				return false;
			}
			catch
			{
				//try-fault
				((IDisposable)this).Dispose();
				throw;
			}
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		private void FSXzAOuNiuWooMbtMwswfbjIwPWg()
		{
			ZMxHTfstJyhqDcUdclUPbkxnVRmM = -1;
			if (IdDsKjpFjlrqekkgJDRUJTgfFIDJ != null)
			{
				((IDisposable)IdDsKjpFjlrqekkgJDRUJTgfFIDJ).Dispose();
			}
		}

		private void mAVYOadTjfRogbZubbiFueOlnCYV()
		{
			ZMxHTfstJyhqDcUdclUPbkxnVRmM = -3;
			((IDisposable)aELWbgfplyFaGosMDkRvbLAiCwdA/*cast due to constrained. prefix*/).Dispose();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		IEnumerator<ActionElementMap> IEnumerable<ActionElementMap>.GetEnumerator()
		{
			ZeYCKTaOIxdyFJOPFuEMdhcmIbQuA zeYCKTaOIxdyFJOPFuEMdhcmIbQuA;
			if (ZMxHTfstJyhqDcUdclUPbkxnVRmM == -2 && PspEAEzBimCjUJeesGhGuAMzHlXfA == Environment.CurrentManagedThreadId)
			{
				ZMxHTfstJyhqDcUdclUPbkxnVRmM = 0;
				zeYCKTaOIxdyFJOPFuEMdhcmIbQuA = this;
			}
			else
			{
				zeYCKTaOIxdyFJOPFuEMdhcmIbQuA = new ZeYCKTaOIxdyFJOPFuEMdhcmIbQuA(0);
				zeYCKTaOIxdyFJOPFuEMdhcmIbQuA.bUXUVnpmqssLvvEPmQPDcaHJEJRH = bUXUVnpmqssLvvEPmQPDcaHJEJRH;
			}
			zeYCKTaOIxdyFJOPFuEMdhcmIbQuA.CZCdALoUTMyIcPNqJbTpigFCVQaB = sUUQrbKQAjCspqPIaFfGOrZhzZyd;
			zeYCKTaOIxdyFJOPFuEMdhcmIbQuA.GuSikKyiaYgznCeWxvgJbsTheTon = OHzHEFlQBuVhIHydWiYmyTrtfNcW;
			return zeYCKTaOIxdyFJOPFuEMdhcmIbQuA;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
		}
	}

	private sealed class vWeoxIOfYgQGafQsiGCMFBUAVnGBA : IEnumerable<ActionElementMap>, IEnumerable, IEnumerator<ActionElementMap>, IEnumerator, IDisposable
	{
		private int DHVzSuzAWSegXHkvxJUyecKiNoxLb;

		private ActionElementMap XBUdWBnJkgkKNBpYwBTdOpXQPrql;

		private int MSxSDCJQCyEcRdhqstXTkczEuYhjA;

		public ControllerMap hRzUiANsaythsOlrgOLKblsNZPqy;

		private IControllerElementTarget uuBfFIIeDtTDHMgkGECGHCJfjQosb;

		public IControllerElementTarget hgMVajkImCTvSBmUbpvPtdXDDWrV;

		private int JLoJweVcrdzJaXcicSgILIMkYGCX;

		public int gyFdjDlVkvGPlXiRsXUsSsYGsJEu;

		private bool epUfzmYJQGZTDOQWufItfCavxuHT;

		public bool bvgbdNgbXGhxjpPCpcrDRCumWOew;

		private TempListPool.TList<ActionElementMap> pPsJhCarYKMZQVgtRPILmURbGGTU;

		private List<ActionElementMap>.Enumerator nykMmMmuLevPQmPYZSLVYQKjAuMO;

		ActionElementMap IEnumerator<ActionElementMap>.Current
		{
			[DebuggerHidden]
			get
			{
				return XBUdWBnJkgkKNBpYwBTdOpXQPrql;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return XBUdWBnJkgkKNBpYwBTdOpXQPrql;
			}
		}

		[DebuggerHidden]
		public vWeoxIOfYgQGafQsiGCMFBUAVnGBA(int P_0)
		{
			DHVzSuzAWSegXHkvxJUyecKiNoxLb = P_0;
			MSxSDCJQCyEcRdhqstXTkczEuYhjA = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			int dHVzSuzAWSegXHkvxJUyecKiNoxLb = DHVzSuzAWSegXHkvxJUyecKiNoxLb;
			if ((uint)(dHVzSuzAWSegXHkvxJUyecKiNoxLb - -4) > 1u && dHVzSuzAWSegXHkvxJUyecKiNoxLb != 1)
			{
				return;
			}
			try
			{
				if (dHVzSuzAWSegXHkvxJUyecKiNoxLb != -4 && dHVzSuzAWSegXHkvxJUyecKiNoxLb != 1)
				{
					return;
				}
				try
				{
				}
				finally
				{
					hJUWPaahxTvZLAXsqxbHUXZEKmkD();
				}
			}
			finally
			{
				EerqHHFHPTKzGjqmQOQouaMMScEb();
			}
		}

		private bool MoveNext()
		{
			try
			{
				int dHVzSuzAWSegXHkvxJUyecKiNoxLb = DHVzSuzAWSegXHkvxJUyecKiNoxLb;
				ControllerMap controllerMap = hRzUiANsaythsOlrgOLKblsNZPqy;
				switch (dHVzSuzAWSegXHkvxJUyecKiNoxLb)
				{
				default:
					return false;
				case 0:
				{
					DHVzSuzAWSegXHkvxJUyecKiNoxLb = -1;
					if (ReInput._id != controllerMap.XTCjmLKuHDyBHCdnAHQddPuHUPTo)
					{
						ReInput.CheckInitialized(controllerMap.XTCjmLKuHDyBHCdnAHQddPuHUPTo);
						return false;
					}
					pPsJhCarYKMZQVgtRPILmURbGGTU = TempListPool.GetTList<ActionElementMap>();
					DHVzSuzAWSegXHkvxJUyecKiNoxLb = -3;
					List<ActionElementMap> list = pPsJhCarYKMZQVgtRPILmURbGGTU.list;
					controllerMap.AQsAVNZYhsajiONJBaCUyUaUYtSD(uuBfFIIeDtTDHMgkGECGHCJfjQosb, true, JLoJweVcrdzJaXcicSgILIMkYGCX, epUfzmYJQGZTDOQWufItfCavxuHT, list, false, out var _);
					nykMmMmuLevPQmPYZSLVYQKjAuMO = list.GetEnumerator();
					DHVzSuzAWSegXHkvxJUyecKiNoxLb = -4;
					break;
				}
				case 1:
					DHVzSuzAWSegXHkvxJUyecKiNoxLb = -4;
					break;
				}
				if (nykMmMmuLevPQmPYZSLVYQKjAuMO.MoveNext())
				{
					ActionElementMap current = nykMmMmuLevPQmPYZSLVYQKjAuMO.Current;
					XBUdWBnJkgkKNBpYwBTdOpXQPrql = current;
					DHVzSuzAWSegXHkvxJUyecKiNoxLb = 1;
					return true;
				}
				hJUWPaahxTvZLAXsqxbHUXZEKmkD();
				nykMmMmuLevPQmPYZSLVYQKjAuMO = default;
				EerqHHFHPTKzGjqmQOQouaMMScEb();
				pPsJhCarYKMZQVgtRPILmURbGGTU = null;
				return false;
			}
			catch
			{
				//try-fault
				((IDisposable)this).Dispose();
				throw;
			}
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		private void EerqHHFHPTKzGjqmQOQouaMMScEb()
		{
			DHVzSuzAWSegXHkvxJUyecKiNoxLb = -1;
			if (pPsJhCarYKMZQVgtRPILmURbGGTU != null)
			{
				((IDisposable)pPsJhCarYKMZQVgtRPILmURbGGTU).Dispose();
			}
		}

		private void hJUWPaahxTvZLAXsqxbHUXZEKmkD()
		{
			DHVzSuzAWSegXHkvxJUyecKiNoxLb = -3;
			((IDisposable)nykMmMmuLevPQmPYZSLVYQKjAuMO/*cast due to constrained. prefix*/).Dispose();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		IEnumerator<ActionElementMap> IEnumerable<ActionElementMap>.GetEnumerator()
		{
			vWeoxIOfYgQGafQsiGCMFBUAVnGBA vWeoxIOfYgQGafQsiGCMFBUAVnGBA2;
			if (DHVzSuzAWSegXHkvxJUyecKiNoxLb == -2 && MSxSDCJQCyEcRdhqstXTkczEuYhjA == Environment.CurrentManagedThreadId)
			{
				DHVzSuzAWSegXHkvxJUyecKiNoxLb = 0;
				vWeoxIOfYgQGafQsiGCMFBUAVnGBA2 = this;
			}
			else
			{
				vWeoxIOfYgQGafQsiGCMFBUAVnGBA2 = new vWeoxIOfYgQGafQsiGCMFBUAVnGBA(0);
				vWeoxIOfYgQGafQsiGCMFBUAVnGBA2.hRzUiANsaythsOlrgOLKblsNZPqy = hRzUiANsaythsOlrgOLKblsNZPqy;
			}
			vWeoxIOfYgQGafQsiGCMFBUAVnGBA2.uuBfFIIeDtTDHMgkGECGHCJfjQosb = hgMVajkImCTvSBmUbpvPtdXDDWrV;
			vWeoxIOfYgQGafQsiGCMFBUAVnGBA2.JLoJweVcrdzJaXcicSgILIMkYGCX = gyFdjDlVkvGPlXiRsXUsSsYGsJEu;
			vWeoxIOfYgQGafQsiGCMFBUAVnGBA2.epUfzmYJQGZTDOQWufItfCavxuHT = bvgbdNgbXGhxjpPCpcrDRCumWOew;
			return vWeoxIOfYgQGafQsiGCMFBUAVnGBA2;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
		}
	}

	protected int _id;

	protected int _sourceMapId;

	protected int _categoryId;

	protected int _layoutId;

	protected string _name = string.Empty;

	protected Guid _hardwareGuid;

	protected bool _enabled;

	internal readonly int XTCjmLKuHDyBHCdnAHQddPuHUPTo;

	private readonly AList<ActionElementMap> fsfgfURoXdRGlcXBSbnalDeYMNiB;

	private readonly ReadOnlyCollection<ActionElementMap> kjKtKaPVKdGDEGwAkhMrvErinmxk;

	private readonly AList<ActionElementMap> QbAaitvGUaSWYrRcFrSSnhbxlRiu;

	private readonly ReadOnlyCollection<ActionElementMap> HqggABoKLjhdxOdjaiVNJlmgGOBIA;

	protected int _playerId = -1;

	protected int _controllerId = -1;

	protected ControllerType _controllerType;

	private static int lOueWTGDHMSRIrrspIbWSCtaFARKA;

	private static int orxTbbYkssbOxrbXNbNJDOzmhaAq => oUHkREsFNAvwdazdWAQzBVHytdjp();

	public int id
	{
		get
		{
			if (ReInput._id != XTCjmLKuHDyBHCdnAHQddPuHUPTo)
			{
				ReInput.CheckInitialized(XTCjmLKuHDyBHCdnAHQddPuHUPTo);
				return -1;
			}
			return _id;
		}
	}

	public int sourceMapId
	{
		get
		{
			if (ReInput._id != XTCjmLKuHDyBHCdnAHQddPuHUPTo)
			{
				ReInput.CheckInitialized(XTCjmLKuHDyBHCdnAHQddPuHUPTo);
				return -1;
			}
			return _sourceMapId;
		}
		internal set
		{
			MbMmassluZIHjVGbBjKxGpevPuGz(num);
		}
	}

	public int categoryId
	{
		get
		{
			if (ReInput._id != XTCjmLKuHDyBHCdnAHQddPuHUPTo)
			{
				ReInput.CheckInitialized(XTCjmLKuHDyBHCdnAHQddPuHUPTo);
				return -1;
			}
			return _categoryId;
		}
		internal set
		{
			hdVcseJAMUIVzNShcxnTQtiYhLhaA(num);
		}
	}

	public int layoutId
	{
		get
		{
			if (ReInput._id != XTCjmLKuHDyBHCdnAHQddPuHUPTo)
			{
				ReInput.CheckInitialized(XTCjmLKuHDyBHCdnAHQddPuHUPTo);
				return -1;
			}
			return _layoutId;
		}
		internal set
		{
			SJAGFjjphrIzvKECmGTWpnbeduqo(num);
		}
	}

	public string name
	{
		get
		{
			if (ReInput._id != XTCjmLKuHDyBHCdnAHQddPuHUPTo)
			{
				ReInput.CheckInitialized(XTCjmLKuHDyBHCdnAHQddPuHUPTo);
				return string.Empty;
			}
			return _name;
		}
		internal set
		{
			OEhBZBxiUPfmghOCGFSYOITTXkIQA(text);
		}
	}

	public Guid hardwareGuid
	{
		get
		{
			if (ReInput._id != XTCjmLKuHDyBHCdnAHQddPuHUPTo)
			{
				ReInput.CheckInitialized(XTCjmLKuHDyBHCdnAHQddPuHUPTo);
				return Guid.Empty;
			}
			return _hardwareGuid;
		}
		internal set
		{
			lVdqrgFjWeEhzHZkzHqpOWGoTKWrA(guid);
		}
	}

	public bool enabled
	{
		get
		{
			if (ReInput._id != XTCjmLKuHDyBHCdnAHQddPuHUPTo)
			{
				ReInput.CheckInitialized(XTCjmLKuHDyBHCdnAHQddPuHUPTo);
				return false;
			}
			return _enabled;
		}
		set
		{
			_enabled = value;
		}
	}

	public int playerId
	{
		get
		{
			if (ReInput._id != XTCjmLKuHDyBHCdnAHQddPuHUPTo)
			{
				ReInput.CheckInitialized(XTCjmLKuHDyBHCdnAHQddPuHUPTo);
				return -1;
			}
			return _playerId;
		}
		internal set
		{
			tgCplRFOOvjFEJhHddHKDbDkUHnkB(num);
		}
	}

	public int controllerId
	{
		get
		{
			if (ReInput._id != XTCjmLKuHDyBHCdnAHQddPuHUPTo)
			{
				ReInput.CheckInitialized(XTCjmLKuHDyBHCdnAHQddPuHUPTo);
				return -1;
			}
			return _controllerId;
		}
		internal set
		{
			SOeQiFehSinWlJovdrhlQBwRceWF(num);
		}
	}

	public Controller controller
	{
		get
		{
			if (ReInput._id != XTCjmLKuHDyBHCdnAHQddPuHUPTo)
			{
				ReInput.CheckInitialized(XTCjmLKuHDyBHCdnAHQddPuHUPTo);
				return null;
			}
			return ReInput.controllers.GetController(_controllerType, _controllerId);
		}
	}

	public ControllerType controllerType
	{
		get
		{
			if (ReInput._id != XTCjmLKuHDyBHCdnAHQddPuHUPTo)
			{
				ReInput.CheckInitialized(XTCjmLKuHDyBHCdnAHQddPuHUPTo);
				return ControllerType.Keyboard;
			}
			return _controllerType;
		}
	}

	public Player player
	{
		get
		{
			if (ReInput._id != XTCjmLKuHDyBHCdnAHQddPuHUPTo)
			{
				ReInput.CheckInitialized(XTCjmLKuHDyBHCdnAHQddPuHUPTo);
				return null;
			}
			return ReInput.players.GetPlayer(_playerId);
		}
	}

	public int elementMapCount
	{
		get
		{
			if (ReInput._id != XTCjmLKuHDyBHCdnAHQddPuHUPTo)
			{
				ReInput.CheckInitialized(XTCjmLKuHDyBHCdnAHQddPuHUPTo);
				return 0;
			}
			return QbAaitvGUaSWYrRcFrSSnhbxlRiu.get_Count();
		}
	}

	public int buttonMapCount
	{
		get
		{
			if (ReInput._id != XTCjmLKuHDyBHCdnAHQddPuHUPTo)
			{
				ReInput.CheckInitialized(XTCjmLKuHDyBHCdnAHQddPuHUPTo);
				return 0;
			}
			return fsfgfURoXdRGlcXBSbnalDeYMNiB.get_Count();
		}
	}

	public IList<ActionElementMap> AllMaps
	{
		get
		{
			if (ReInput._id != XTCjmLKuHDyBHCdnAHQddPuHUPTo)
			{
				ReInput.CheckInitialized(XTCjmLKuHDyBHCdnAHQddPuHUPTo);
				return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
			}
			return HqggABoKLjhdxOdjaiVNJlmgGOBIA;
		}
	}

	public IList<ActionElementMap> ElementMaps
	{
		get
		{
			if (ReInput._id != XTCjmLKuHDyBHCdnAHQddPuHUPTo)
			{
				ReInput.CheckInitialized(XTCjmLKuHDyBHCdnAHQddPuHUPTo);
				return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
			}
			return HqggABoKLjhdxOdjaiVNJlmgGOBIA;
		}
	}

	public IList<ActionElementMap> ButtonMaps
	{
		get
		{
			if (ReInput._id != XTCjmLKuHDyBHCdnAHQddPuHUPTo)
			{
				ReInput.CheckInitialized(XTCjmLKuHDyBHCdnAHQddPuHUPTo);
				return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
			}
			return kjKtKaPVKdGDEGwAkhMrvErinmxk;
		}
	}

	internal AList<ActionElementMap> dXQDBztCdwAxlgKNMGXxJbRMnXxfA => hycZGsxqYWqTYWkWVVCDVrvexwwT();

	private static int oUHkREsFNAvwdazdWAQzBVHytdjp()
	{
		int result = lOueWTGDHMSRIrrspIbWSCtaFARKA;
		if (lOueWTGDHMSRIrrspIbWSCtaFARKA == int.MaxValue)
		{
			lOueWTGDHMSRIrrspIbWSCtaFARKA = 0;
			return result;
		}
		lOueWTGDHMSRIrrspIbWSCtaFARKA++;
		return result;
	}

	public ControllerMap()
	{
		_id = oUHkREsFNAvwdazdWAQzBVHytdjp();
		_sourceMapId = -1;
		fsfgfURoXdRGlcXBSbnalDeYMNiB = new AList<ActionElementMap>();
		kjKtKaPVKdGDEGwAkhMrvErinmxk = new ReadOnlyCollection<ActionElementMap>(fsfgfURoXdRGlcXBSbnalDeYMNiB);
		QbAaitvGUaSWYrRcFrSSnhbxlRiu = new AList<ActionElementMap>();
		HqggABoKLjhdxOdjaiVNJlmgGOBIA = new ReadOnlyCollection<ActionElementMap>(QbAaitvGUaSWYrRcFrSSnhbxlRiu);
		XTCjmLKuHDyBHCdnAHQddPuHUPTo = ReInput.id;
	}

	public ControllerMap(ControllerMap P_0)
		: this()
	{
		_id = oUHkREsFNAvwdazdWAQzBVHytdjp();
		_sourceMapId = P_0._sourceMapId;
		_categoryId = P_0._categoryId;
		_layoutId = P_0._layoutId;
		_name = P_0._name;
		_hardwareGuid = P_0._hardwareGuid;
		_enabled = P_0._enabled;
		_playerId = P_0._playerId;
		_controllerId = P_0._controllerId;
		_controllerType = P_0._controllerType;
		if (P_0.fsfgfURoXdRGlcXBSbnalDeYMNiB != null)
		{
			int count = P_0.fsfgfURoXdRGlcXBSbnalDeYMNiB.get_Count();
			for (int i = 0; i < count; i++)
			{
				tVtLzuBzPyphVHDgadSpbMqQILHLA(new ActionElementMap(P_0.fsfgfURoXdRGlcXBSbnalDeYMNiB.get_Item(i)));
			}
		}
	}

	internal void MbMmassluZIHjVGbBjKxGpevPuGz(int P_0)
	{
		_sourceMapId = P_0;
	}

	internal void hdVcseJAMUIVzNShcxnTQtiYhLhaA(int P_0)
	{
		_categoryId = P_0;
	}

	internal void SJAGFjjphrIzvKECmGTWpnbeduqo(int P_0)
	{
		_layoutId = P_0;
	}

	internal void OEhBZBxiUPfmghOCGFSYOITTXkIQA(string P_0)
	{
		_name = P_0;
	}

	internal void lVdqrgFjWeEhzHZkzHqpOWGoTKWrA(Guid P_0)
	{
		_hardwareGuid = P_0;
	}

	internal void tgCplRFOOvjFEJhHddHKDbDkUHnkB(int P_0)
	{
		_playerId = P_0;
	}

	internal void SOeQiFehSinWlJovdrhlQBwRceWF(int P_0)
	{
		_controllerId = P_0;
	}

	public bool ContainsAction(string actionName)
	{
		if (ReInput._id != XTCjmLKuHDyBHCdnAHQddPuHUPTo)
		{
			ReInput.CheckInitialized(XTCjmLKuHDyBHCdnAHQddPuHUPTo);
			return false;
		}
		InputAction inputAction = ReInput.IsSPFehscBAmxtEADWGWuasjDvqf.pxqIwEDqxMKXOCayUJiZFLWEOTiW(actionName, true);
		if (inputAction == null)
		{
			return false;
		}
		return ContainsAction(inputAction.id);
	}

	public virtual bool ContainsAction(int actionId)
	{
		if (ReInput._id != XTCjmLKuHDyBHCdnAHQddPuHUPTo)
		{
			ReInput.CheckInitialized(XTCjmLKuHDyBHCdnAHQddPuHUPTo);
			return false;
		}
		if (actionId < 0)
		{
			return false;
		}
		int num = buttonMapCount;
		for (int i = 0; i < num; i++)
		{
			if (fsfgfURoXdRGlcXBSbnalDeYMNiB.get_Item(i)._actionId == actionId)
			{
				return true;
			}
		}
		return false;
	}

	public bool ContainsElementIdentifier(int elementIdentifierId)
	{
		if (ReInput._id != XTCjmLKuHDyBHCdnAHQddPuHUPTo)
		{
			ReInput.CheckInitialized(XTCjmLKuHDyBHCdnAHQddPuHUPTo);
			return false;
		}
		AList<ActionElementMap> qbAaitvGUaSWYrRcFrSSnhbxlRiu = QbAaitvGUaSWYrRcFrSSnhbxlRiu;
		for (int i = 0; i < qbAaitvGUaSWYrRcFrSSnhbxlRiu.get_Count(); i++)
		{
			if (QbAaitvGUaSWYrRcFrSSnhbxlRiu.get_Item(i).elementIdentifierId == elementIdentifierId)
			{
				return true;
			}
		}
		return false;
	}

	public bool ContainsKeyboardKey(KeyCode keyCode, ModifierKeyFlags modifierKeys)
	{
		if (ReInput._id != XTCjmLKuHDyBHCdnAHQddPuHUPTo)
		{
			ReInput.CheckInitialized(XTCjmLKuHDyBHCdnAHQddPuHUPTo);
			return false;
		}
		AList<ActionElementMap> qbAaitvGUaSWYrRcFrSSnhbxlRiu = QbAaitvGUaSWYrRcFrSSnhbxlRiu;
		for (int i = 0; i < qbAaitvGUaSWYrRcFrSSnhbxlRiu.get_Count(); i++)
		{
			if (QbAaitvGUaSWYrRcFrSSnhbxlRiu.get_Item(i).keyCode == keyCode && QbAaitvGUaSWYrRcFrSSnhbxlRiu.get_Item(i).modifierKeyFlags == modifierKeys)
			{
				return true;
			}
		}
		return false;
	}

	public bool ContainsElementMap(ActionElementMap elementMap)
	{
		if (ReInput._id != XTCjmLKuHDyBHCdnAHQddPuHUPTo)
		{
			ReInput.CheckInitialized(XTCjmLKuHDyBHCdnAHQddPuHUPTo);
			return false;
		}
		if (elementMap == null)
		{
			return false;
		}
		AList<ActionElementMap> qbAaitvGUaSWYrRcFrSSnhbxlRiu = QbAaitvGUaSWYrRcFrSSnhbxlRiu;
		for (int i = 0; i < qbAaitvGUaSWYrRcFrSSnhbxlRiu.get_Count(); i++)
		{
			if (QbAaitvGUaSWYrRcFrSSnhbxlRiu.get_Item(i).LQceMJAxYgRpolrwLwsLBxilJMmNA == elementMap.id)
			{
				return true;
			}
		}
		return false;
	}

	public bool ContainsElementMap(int elementMapId)
	{
		if (ReInput._id != XTCjmLKuHDyBHCdnAHQddPuHUPTo)
		{
			ReInput.CheckInitialized(XTCjmLKuHDyBHCdnAHQddPuHUPTo);
			return false;
		}
		AList<ActionElementMap> qbAaitvGUaSWYrRcFrSSnhbxlRiu = QbAaitvGUaSWYrRcFrSSnhbxlRiu;
		for (int i = 0; i < qbAaitvGUaSWYrRcFrSSnhbxlRiu.get_Count(); i++)
		{
			if (QbAaitvGUaSWYrRcFrSSnhbxlRiu.get_Item(i).LQceMJAxYgRpolrwLwsLBxilJMmNA == elementMapId)
			{
				return true;
			}
		}
		return false;
	}

	public bool ReplaceOrCreateElementMap(ElementAssignment elementAssignment)
	{
		if (ReInput._id != XTCjmLKuHDyBHCdnAHQddPuHUPTo)
		{
			ReInput.CheckInitialized(XTCjmLKuHDyBHCdnAHQddPuHUPTo);
			return false;
		}
		ActionElementMap result;
		return ReplaceOrCreateElementMap(elementAssignment, out result);
	}

	public bool ReplaceOrCreateElementMap(ElementAssignment elementAssignment, out ActionElementMap result)
	{
		if (ReInput._id != XTCjmLKuHDyBHCdnAHQddPuHUPTo)
		{
			ReInput.CheckInitialized(XTCjmLKuHDyBHCdnAHQddPuHUPTo);
			result = null;
			return false;
		}
		if (GetElementMap(elementAssignment.elementMapId) == null)
		{
			return CreateElementMap(elementAssignment, out result);
		}
		return ReplaceElementMap(elementAssignment, out result);
	}

	public bool CreateElementMap(ElementAssignment elementAssignment)
	{
		if (ReInput._id != XTCjmLKuHDyBHCdnAHQddPuHUPTo)
		{
			ReInput.CheckInitialized(XTCjmLKuHDyBHCdnAHQddPuHUPTo);
			return false;
		}
		ActionElementMap result;
		return CreateElementMap(elementAssignment, out result);
	}

	public bool CreateElementMap(ElementAssignment elementAssignment, out ActionElementMap result)
	{
		if (ReInput._id != XTCjmLKuHDyBHCdnAHQddPuHUPTo)
		{
			ReInput.CheckInitialized(XTCjmLKuHDyBHCdnAHQddPuHUPTo);
			result = null;
			return false;
		}
		if (_controllerType == ControllerType.Keyboard)
		{
			return CreateElementMap(elementAssignment.actionId, elementAssignment.axisContribution, elementAssignment.keyboardKey, elementAssignment.modifierKeyFlags, out result);
		}
		if (_controllerType == ControllerType.Joystick || _controllerType == ControllerType.Mouse || _controllerType == ControllerType.Custom)
		{
			return CreateElementMap(elementAssignment.actionId, elementAssignment.axisContribution, elementAssignment.elementIdentifierId, IyPmashUlRgIygDiHFyDZHZmauql.GHSLwwyYQJsHZwAGrasLDiACdKRib(elementAssignment.type), elementAssignment.axisRange, elementAssignment.invert, out result);
		}
		throw new NotImplementedException();
	}

	public bool CreateElementMap(int actionId, Pole axisContribution, KeyCode keyCode, ModifierKey modifierKey1, ModifierKey modifierKey2, ModifierKey modifierKey3)
	{
		ActionElementMap result;
		return CreateElementMap(actionId, axisContribution, keyCode, modifierKey1, modifierKey2, modifierKey3, out result);
	}

	public bool CreateElementMap(int actionId, Pole axisContribution, KeyCode keyCode, ModifierKey modifierKey1, ModifierKey modifierKey2, ModifierKey modifierKey3, out ActionElementMap result)
	{
		if (ReInput._id != XTCjmLKuHDyBHCdnAHQddPuHUPTo)
		{
			ReInput.CheckInitialized(XTCjmLKuHDyBHCdnAHQddPuHUPTo);
			result = null;
			return false;
		}
		ActionElementMap actionElementMap = new ActionElementMap(actionId, ControllerElementType.Button, axisContribution, (KeyboardKeyCode)keyCode, modifierKey1, modifierKey2, modifierKey3);
		ReInput.controllers.Keyboard.fGQOtKpVEJmrMXNYeONgsnXNwkIC(this, actionElementMap);
		tVtLzuBzPyphVHDgadSpbMqQILHLA(actionElementMap);
		result = actionElementMap;
		return true;
	}

	public bool CreateElementMap(int actionId, Pole axisContribution, KeyCode keyCode, ModifierKeyFlags modifierKeyFlags)
	{
		ActionElementMap result;
		return CreateElementMap(actionId, axisContribution, keyCode, modifierKeyFlags, out result);
	}

	public bool CreateElementMap(int actionId, Pole axisContribution, KeyCode keyCode, ModifierKeyFlags modifierKeyFlags, out ActionElementMap result)
	{
		if (ReInput._id != XTCjmLKuHDyBHCdnAHQddPuHUPTo)
		{
			ReInput.CheckInitialized(XTCjmLKuHDyBHCdnAHQddPuHUPTo);
			result = null;
			return false;
		}
		ocfrwxWbnSaLXaGytCBoiksAzeUp ocfrwxWbnSaLXaGytCBoiksAzeUp2 = ocfrwxWbnSaLXaGytCBoiksAzeUp.zweiqmUGMTpdJvZBdjaHWVsAsLpN(modifierKeyFlags);
		return CreateElementMap(actionId, axisContribution, keyCode, ocfrwxWbnSaLXaGytCBoiksAzeUp2.xDgQhPfegHAVfGakqTqMUJrQfHRiA, ocfrwxWbnSaLXaGytCBoiksAzeUp2.YZFdBqXgyFXHWssASMlsAAJSBPDFA, ocfrwxWbnSaLXaGytCBoiksAzeUp2.jZGXhmUoslJRSDvkzPBGQEmgNqcE, out result);
	}

	public bool CreateElementMap(int actionId, Pole axisContribution, int elementIdentifierId, ControllerElementType elementType, AxisRange axisRange, bool invert)
	{
		ActionElementMap result;
		return CreateElementMap(actionId, axisContribution, elementIdentifierId, elementType, axisRange, invert, out result);
	}

	public virtual bool CreateElementMap(int actionId, Pole axisContribution, int elementIdentifierId, ControllerElementType elementType, AxisRange axisRange, bool invert, out ActionElementMap result)
	{
		if (ReInput._id != XTCjmLKuHDyBHCdnAHQddPuHUPTo)
		{
			ReInput.CheckInitialized(XTCjmLKuHDyBHCdnAHQddPuHUPTo);
			result = null;
			return false;
		}
		if (!aODoMkHKRRYelZwmsAjLTtAJKbWb(elementType))
		{
			result = null;
			return false;
		}
		ActionElementMap actionElementMap = new ActionElementMap(actionId, elementType, elementIdentifierId, axisContribution, axisRange);
		BakeElementMap(actionElementMap);
		tVtLzuBzPyphVHDgadSpbMqQILHLA(actionElementMap);
		result = actionElementMap;
		return true;
	}

	public bool ReplaceElementMap(ElementAssignment elementAssignment)
	{
		ActionElementMap result;
		return ReplaceElementMap(elementAssignment, out result);
	}

	public bool ReplaceElementMap(ElementAssignment elementAssignment, out ActionElementMap result)
	{
		if (ReInput._id != XTCjmLKuHDyBHCdnAHQddPuHUPTo)
		{
			ReInput.CheckInitialized(XTCjmLKuHDyBHCdnAHQddPuHUPTo);
			result = null;
			return false;
		}
		if (_controllerType == ControllerType.Keyboard)
		{
			return ReplaceElementMap(elementAssignment.elementMapId, elementAssignment.actionId, elementAssignment.axisContribution, elementAssignment.keyboardKey, elementAssignment.modifierKeyFlags, out result);
		}
		if (_controllerType == ControllerType.Joystick || _controllerType == ControllerType.Mouse || _controllerType == ControllerType.Custom)
		{
			return ReplaceElementMap(elementAssignment.elementMapId, elementAssignment.actionId, elementAssignment.axisContribution, elementAssignment.elementIdentifierId, IyPmashUlRgIygDiHFyDZHZmauql.GHSLwwyYQJsHZwAGrasLDiACdKRib(elementAssignment.type), elementAssignment.axisRange, elementAssignment.invert, out result);
		}
		throw new NotImplementedException();
	}

	public bool ReplaceElementMap(int elementMapId, int actionId, Pole axisContribution, KeyCode keyCode, ModifierKey modifierKey1, ModifierKey modifierKey2, ModifierKey modifierKey3)
	{
		ActionElementMap result;
		return ReplaceElementMap(elementMapId, actionId, axisContribution, keyCode, modifierKey1, modifierKey2, modifierKey3, out result);
	}

	public bool ReplaceElementMap(int elementMapId, int actionId, Pole axisContribution, KeyCode keyCode, ModifierKey modifierKey1, ModifierKey modifierKey2, ModifierKey modifierKey3, out ActionElementMap result)
	{
		if (ReInput._id != XTCjmLKuHDyBHCdnAHQddPuHUPTo)
		{
			ReInput.CheckInitialized(XTCjmLKuHDyBHCdnAHQddPuHUPTo);
			result = null;
			return false;
		}
		ActionElementMap elementMap = GetElementMap(elementMapId);
		if (elementMap == null)
		{
			result = null;
			return false;
		}
		if (sWNZoKRUStTTVbUqDZSHArqAahEF(elementMapId) < 0)
		{
			DeleteElementMap(elementMapId);
			elementMap._elementType = ControllerElementType.Button;
			tVtLzuBzPyphVHDgadSpbMqQILHLA(elementMap);
		}
		if (sWNZoKRUStTTVbUqDZSHArqAahEF(elementMapId) < 0)
		{
			result = null;
			return false;
		}
		elementMap.HqYMVTpUQlRYCgKqNbTFekEMDmBc();
		elementMap._actionId = actionId;
		elementMap._elementType = ControllerElementType.Button;
		elementMap._axisContribution = axisContribution;
		elementMap._keyboardKeyCode = (KeyboardKeyCode)keyCode;
		elementMap._modifierKey1 = modifierKey1;
		elementMap._modifierKey2 = modifierKey2;
		elementMap._modifierKey3 = modifierKey3;
		ReInput.controllers.Keyboard.fGQOtKpVEJmrMXNYeONgsnXNwkIC(this, elementMap);
		result = elementMap;
		return true;
	}

	public bool ReplaceElementMap(int elementMapId, int actionId, Pole axisContribution, KeyCode keyCode, ModifierKeyFlags modifierKeyFlags)
	{
		ActionElementMap result;
		return ReplaceElementMap(elementMapId, actionId, axisContribution, keyCode, modifierKeyFlags, out result);
	}

	public bool ReplaceElementMap(int elementMapId, int actionId, Pole axisContribution, KeyCode keyCode, ModifierKeyFlags modifierKeyFlags, out ActionElementMap result)
	{
		ocfrwxWbnSaLXaGytCBoiksAzeUp ocfrwxWbnSaLXaGytCBoiksAzeUp2 = ocfrwxWbnSaLXaGytCBoiksAzeUp.zweiqmUGMTpdJvZBdjaHWVsAsLpN(modifierKeyFlags);
		return ReplaceElementMap(elementMapId, actionId, axisContribution, keyCode, ocfrwxWbnSaLXaGytCBoiksAzeUp2.xDgQhPfegHAVfGakqTqMUJrQfHRiA, ocfrwxWbnSaLXaGytCBoiksAzeUp2.YZFdBqXgyFXHWssASMlsAAJSBPDFA, ocfrwxWbnSaLXaGytCBoiksAzeUp2.jZGXhmUoslJRSDvkzPBGQEmgNqcE, out result);
	}

	public bool ReplaceElementMap(int elementMapId, int actionId, Pole axisContribution, int elementIdentifierId, ControllerElementType elementType, AxisRange axisRange, bool invert)
	{
		ActionElementMap result;
		return ReplaceElementMap(elementMapId, actionId, axisContribution, elementIdentifierId, elementType, axisRange, invert, out result);
	}

	public virtual bool ReplaceElementMap(int elementMapId, int actionId, Pole axisContribution, int elementIdentifierId, ControllerElementType elementType, AxisRange axisRange, bool invert, out ActionElementMap result)
	{
		if (ReInput._id != XTCjmLKuHDyBHCdnAHQddPuHUPTo)
		{
			ReInput.CheckInitialized(XTCjmLKuHDyBHCdnAHQddPuHUPTo);
			result = null;
			return false;
		}
		if (!aODoMkHKRRYelZwmsAjLTtAJKbWb(elementType))
		{
			result = null;
			return false;
		}
		ActionElementMap elementMap = GetElementMap(elementMapId);
		if (elementMap == null)
		{
			result = null;
			return false;
		}
		if (!aODoMkHKRRYelZwmsAjLTtAJKbWb(elementMap._elementType))
		{
			DeleteElementMap(elementMapId);
			elementMap._elementType = ControllerElementType.Button;
			tVtLzuBzPyphVHDgadSpbMqQILHLA(elementMap);
		}
		if (sWNZoKRUStTTVbUqDZSHArqAahEF(elementMapId) < 0)
		{
			result = null;
			return false;
		}
		bscxZCAoNJMLdkUKriUgtlzjeUaS(elementMap, actionId, axisContribution, elementIdentifierId, elementType, axisRange, invert);
		BakeElementMap(elementMap);
		result = elementMap;
		return true;
	}

	public virtual bool DeleteElementMap(int elementMapId)
	{
		if (ReInput._id != XTCjmLKuHDyBHCdnAHQddPuHUPTo)
		{
			ReInput.CheckInitialized(XTCjmLKuHDyBHCdnAHQddPuHUPTo);
			return false;
		}
		int num = sWNZoKRUStTTVbUqDZSHArqAahEF(elementMapId);
		if (num < 0)
		{
			return false;
		}
		xPDpwubZeRwFkRocGwDPfBgdGxHY(elementMapId, num);
		return true;
	}

	public virtual bool DeleteElementMapsWithAction(string actionName)
	{
		return DeleteElementMapsWithAction(ReInput.IsSPFehscBAmxtEADWGWuasjDvqf.GhVjGDQeDQmOWTnROakHcfdeCdDd(actionName));
	}

	public virtual bool DeleteElementMapsWithAction(int actionId)
	{
		return DeleteButtonMapsWithAction(actionId);
	}

	public virtual ActionElementMap GetElementMap(int elementMapId)
	{
		if (ReInput._id != XTCjmLKuHDyBHCdnAHQddPuHUPTo)
		{
			ReInput.CheckInitialized(XTCjmLKuHDyBHCdnAHQddPuHUPTo);
			return null;
		}
		if (elementMapId < 0)
		{
			return null;
		}
		int num = buttonMapCount;
		for (int i = 0; i < num; i++)
		{
			if (fsfgfURoXdRGlcXBSbnalDeYMNiB.get_Item(i).LQceMJAxYgRpolrwLwsLBxilJMmNA == elementMapId)
			{
				return fsfgfURoXdRGlcXBSbnalDeYMNiB.get_Item(i);
			}
		}
		return null;
	}

	public ActionElementMap[] GetElementMaps()
	{
		return GetElementMaps(skipDisabledMaps: false);
	}

	public ActionElementMap[] GetElementMaps(bool skipDisabledMaps)
	{
		if (ReInput._id != XTCjmLKuHDyBHCdnAHQddPuHUPTo)
		{
			ReInput.CheckInitialized(XTCjmLKuHDyBHCdnAHQddPuHUPTo);
			return EmptyObjects<ActionElementMap>.array;
		}
		int num = elementMapCount;
		if (num == 0)
		{
			return EmptyObjects<ActionElementMap>.array;
		}
		List<ActionElementMap> list = new List<ActionElementMap>(num);
		foreach (ActionElementMap allMap in AllMaps)
		{
			if (!skipDisabledMaps || allMap.YbgQyWQdQcTTSlKYNScpqBbjmQQo)
			{
				list.Add(allMap);
			}
		}
		return list.ToArray();
	}

	public int GetElementMaps(List<ActionElementMap> results)
	{
		return GetElementMaps(skipDisabledMaps: false, results);
	}

	public int GetElementMaps(bool skipDisabledMaps, List<ActionElementMap> results)
	{
		if (ReInput._id != XTCjmLKuHDyBHCdnAHQddPuHUPTo)
		{
			ReInput.CheckInitialized(XTCjmLKuHDyBHCdnAHQddPuHUPTo);
			return 0;
		}
		if (results == null)
		{
			throw new ArgumentNullException("results");
		}
		results.Clear();
		return ElNffPfXNwpFTQXfZcqhRXnLVlPu(results, skipDisabledMaps);
	}

	public ActionElementMap[] GetElementMapsWithAction(string actionName)
	{
		if (ReInput._id != XTCjmLKuHDyBHCdnAHQddPuHUPTo)
		{
			ReInput.CheckInitialized(XTCjmLKuHDyBHCdnAHQddPuHUPTo);
			return EmptyObjects<ActionElementMap>.array;
		}
		int actionId = ReInput.IsSPFehscBAmxtEADWGWuasjDvqf.GhVjGDQeDQmOWTnROakHcfdeCdDd(actionName);
		return GetElementMapsWithAction(actionId);
	}

	public ActionElementMap[] GetElementMapsWithAction(int actionId)
	{
		return GetElementMapsWithAction(actionId, skipDisabledMaps: false);
	}

	public ActionElementMap[] GetElementMapsWithAction(string actionName, bool skipDisabledMaps)
	{
		if (ReInput._id != XTCjmLKuHDyBHCdnAHQddPuHUPTo)
		{
			ReInput.CheckInitialized(XTCjmLKuHDyBHCdnAHQddPuHUPTo);
			return EmptyObjects<ActionElementMap>.array;
		}
		int actionId = ReInput.IsSPFehscBAmxtEADWGWuasjDvqf.GhVjGDQeDQmOWTnROakHcfdeCdDd(actionName);
		return GetElementMapsWithAction(actionId, skipDisabledMaps);
	}

	public ActionElementMap[] GetElementMapsWithAction(int actionId, bool skipDisabledMaps)
	{
		if (ReInput._id != XTCjmLKuHDyBHCdnAHQddPuHUPTo)
		{
			ReInput.CheckInitialized(XTCjmLKuHDyBHCdnAHQddPuHUPTo);
			return EmptyObjects<ActionElementMap>.array;
		}
		if (actionId < 0)
		{
			return EmptyObjects<ActionElementMap>.array;
		}
		if (elementMapCount == 0)
		{
			return EmptyObjects<ActionElementMap>.array;
		}
		int num = 0;
		foreach (ActionElementMap allMap in AllMaps)
		{
			if (allMap._actionId == actionId && (!skipDisabledMaps || allMap.YbgQyWQdQcTTSlKYNScpqBbjmQQo))
			{
				num++;
			}
		}
		if (num == 0)
		{
			return EmptyObjects<ActionElementMap>.array;
		}
		ActionElementMap[] array = new ActionElementMap[num];
		int num2 = 0;
		foreach (ActionElementMap allMap2 in AllMaps)
		{
			if (allMap2._actionId == actionId && (!skipDisabledMaps || allMap2.YbgQyWQdQcTTSlKYNScpqBbjmQQo))
			{
				array[num2] = allMap2;
				num2++;
			}
		}
		return array;
	}

	public int GetElementMapsWithAction(string actionName, List<ActionElementMap> results)
	{
		if (ReInput._id != XTCjmLKuHDyBHCdnAHQddPuHUPTo)
		{
			ReInput.CheckInitialized(XTCjmLKuHDyBHCdnAHQddPuHUPTo);
			return 0;
		}
		int actionId = ReInput.IsSPFehscBAmxtEADWGWuasjDvqf.GhVjGDQeDQmOWTnROakHcfdeCdDd(actionName);
		return GetElementMapsWithAction(actionId, results);
	}

	public int GetElementMapsWithAction(int actionId, List<ActionElementMap> results)
	{
		return GetElementMapsWithAction(actionId, skipDisabledMaps: false, results);
	}

	public int GetElementMapsWithAction(string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
	{
		if (ReInput._id != XTCjmLKuHDyBHCdnAHQddPuHUPTo)
		{
			ReInput.CheckInitialized(XTCjmLKuHDyBHCdnAHQddPuHUPTo);
			return 0;
		}
		int actionId = ReInput.IsSPFehscBAmxtEADWGWuasjDvqf.GhVjGDQeDQmOWTnROakHcfdeCdDd(actionName);
		return GetElementMapsWithAction(actionId, skipDisabledMaps, results);
	}

	public int GetElementMapsWithAction(int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
	{
		return udqxaEGIrvufGdIfXccpPRDnNltr(actionId, skipDisabledMaps, results, false);
	}

	public IEnumerable<ActionElementMap> ElementMapsWithAction(string actionName)
	{
		if (ReInput._id != XTCjmLKuHDyBHCdnAHQddPuHUPTo)
		{
			ReInput.CheckInitialized(XTCjmLKuHDyBHCdnAHQddPuHUPTo);
			return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
		}
		int actionId = ReInput.IsSPFehscBAmxtEADWGWuasjDvqf.GhVjGDQeDQmOWTnROakHcfdeCdDd(actionName);
		return ElementMapsWithAction(actionId);
	}

	public IEnumerable<ActionElementMap> ElementMapsWithAction(int actionId)
	{
		return ElementMapsWithAction(actionId, skipDisabledMaps: false);
	}

	public IEnumerable<ActionElementMap> ElementMapsWithAction(string actionName, bool skipDisabledMaps)
	{
		if (ReInput._id != XTCjmLKuHDyBHCdnAHQddPuHUPTo)
		{
			ReInput.CheckInitialized(XTCjmLKuHDyBHCdnAHQddPuHUPTo);
			return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
		}
		int actionId = ReInput.IsSPFehscBAmxtEADWGWuasjDvqf.GhVjGDQeDQmOWTnROakHcfdeCdDd(actionName);
		return ElementMapsWithAction(actionId, skipDisabledMaps);
	}

	[IteratorStateMachine(typeof(YdOcJzJPajVVEeOKrVajIrcHJylKA))]
	public IEnumerable<ActionElementMap> ElementMapsWithAction(int actionId, bool skipDisabledMaps)
	{
		return new YdOcJzJPajVVEeOKrVajIrcHJylKA(-2)
		{
			cVaujgOGXKRHaJyQOiLBcRExySQG = this,
			aEEAZIDgvirZeOCpSHKqGDjBRiiFB = actionId,
			AHmBGXCWWFgoiUJjPiEPXFaQBJNAA = skipDisabledMaps
		};
	}

	public virtual ActionElementMap GetFirstElementMapWithAction(int actionId)
	{
		return GetFirstElementMapWithAction(actionId, skipDisabledMaps: false);
	}

	public virtual ActionElementMap GetFirstElementMapWithAction(string actionName)
	{
		if (ReInput._id != XTCjmLKuHDyBHCdnAHQddPuHUPTo)
		{
			ReInput.CheckInitialized(XTCjmLKuHDyBHCdnAHQddPuHUPTo);
			return null;
		}
		int actionId = ReInput.IsSPFehscBAmxtEADWGWuasjDvqf.GhVjGDQeDQmOWTnROakHcfdeCdDd(actionName);
		return GetFirstElementMapWithAction(actionId);
	}

	public virtual ActionElementMap GetFirstElementMapWithAction(int actionId, bool skipDisabledMaps)
	{
		if (ReInput._id != XTCjmLKuHDyBHCdnAHQddPuHUPTo)
		{
			ReInput.CheckInitialized(XTCjmLKuHDyBHCdnAHQddPuHUPTo);
			return null;
		}
		if (actionId < 0)
		{
			return null;
		}
		int num = buttonMapCount;
		for (int i = 0; i < num; i++)
		{
			if (fsfgfURoXdRGlcXBSbnalDeYMNiB.get_Item(i)._actionId == actionId && (!skipDisabledMaps || fsfgfURoXdRGlcXBSbnalDeYMNiB.get_Item(i).YbgQyWQdQcTTSlKYNScpqBbjmQQo))
			{
				return fsfgfURoXdRGlcXBSbnalDeYMNiB.get_Item(i);
			}
		}
		return null;
	}

	public ActionElementMap GetFirstElementMapWithAction(string actionName, bool skipDisabledMaps)
	{
		if (ReInput._id != XTCjmLKuHDyBHCdnAHQddPuHUPTo)
		{
			ReInput.CheckInitialized(XTCjmLKuHDyBHCdnAHQddPuHUPTo);
			return null;
		}
		int actionId = ReInput.IsSPFehscBAmxtEADWGWuasjDvqf.GhVjGDQeDQmOWTnROakHcfdeCdDd(actionName);
		return GetFirstElementMapWithAction(actionId, skipDisabledMaps);
	}

	public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(ControllerElementTarget elementTarget, bool skipDisabledMaps)
	{
		if (ReInput._id != XTCjmLKuHDyBHCdnAHQddPuHUPTo)
		{
			ReInput.CheckInitialized(XTCjmLKuHDyBHCdnAHQddPuHUPTo);
			return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
		}
		edomyHoabKkWzxLwelGsLkZrDlzw edomyHoabKkWzxLwelGsLkZrDlzw2 = edomyHoabKkWzxLwelGsLkZrDlzw.YrulkGTOzpYsHraDBHAumBfMBGzd(elementTarget);
		IEnumerable<ActionElementMap> result = ElementMapsWithElementTarget(edomyHoabKkWzxLwelGsLkZrDlzw2, skipDisabledMaps);
		edomyHoabKkWzxLwelGsLkZrDlzw.ZQnGowaWMdKIQroVeeRgAzvXTUJX(edomyHoabKkWzxLwelGsLkZrDlzw2);
		return result;
	}

	[IteratorStateMachine(typeof(ZeYCKTaOIxdyFJOPFuEMdhcmIbQuA))]
	public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(IControllerElementTarget elementTarget, bool skipDisabledMaps)
	{
		return new ZeYCKTaOIxdyFJOPFuEMdhcmIbQuA(-2)
		{
			bUXUVnpmqssLvvEPmQPDcaHJEJRH = this,
			sUUQrbKQAjCspqPIaFfGOrZhzZyd = elementTarget,
			OHzHEFlQBuVhIHydWiYmyTrtfNcW = skipDisabledMaps
		};
	}

	public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(ControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps)
	{
		if (ReInput._id != XTCjmLKuHDyBHCdnAHQddPuHUPTo)
		{
			ReInput.CheckInitialized(XTCjmLKuHDyBHCdnAHQddPuHUPTo);
			return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
		}
		edomyHoabKkWzxLwelGsLkZrDlzw edomyHoabKkWzxLwelGsLkZrDlzw2 = edomyHoabKkWzxLwelGsLkZrDlzw.YrulkGTOzpYsHraDBHAumBfMBGzd(elementTarget);
		IEnumerable<ActionElementMap> result = ElementMapsWithElementTarget(edomyHoabKkWzxLwelGsLkZrDlzw2, actionId, skipDisabledMaps);
		edomyHoabKkWzxLwelGsLkZrDlzw.ZQnGowaWMdKIQroVeeRgAzvXTUJX(edomyHoabKkWzxLwelGsLkZrDlzw2);
		return result;
	}

	public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(ControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps)
	{
		if (ReInput._id != XTCjmLKuHDyBHCdnAHQddPuHUPTo)
		{
			ReInput.CheckInitialized(XTCjmLKuHDyBHCdnAHQddPuHUPTo);
			return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
		}
		int actionId = ReInput.IsSPFehscBAmxtEADWGWuasjDvqf.GhVjGDQeDQmOWTnROakHcfdeCdDd(actionName);
		return ElementMapsWithElementTarget(elementTarget, actionId, skipDisabledMaps);
	}

	[IteratorStateMachine(typeof(vWeoxIOfYgQGafQsiGCMFBUAVnGBA))]
	public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(IControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps)
	{
		return new vWeoxIOfYgQGafQsiGCMFBUAVnGBA(-2)
		{
			hRzUiANsaythsOlrgOLKblsNZPqy = this,
			hgMVajkImCTvSBmUbpvPtdXDDWrV = elementTarget,
			gyFdjDlVkvGPlXiRsXUsSsYGsJEu = actionId,
			bvgbdNgbXGhxjpPCpcrDRCumWOew = skipDisabledMaps
		};
	}

	public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(IControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps)
	{
		if (ReInput._id != XTCjmLKuHDyBHCdnAHQddPuHUPTo)
		{
			ReInput.CheckInitialized(XTCjmLKuHDyBHCdnAHQddPuHUPTo);
			return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
		}
		int actionId = ReInput.IsSPFehscBAmxtEADWGWuasjDvqf.GhVjGDQeDQmOWTnROakHcfdeCdDd(actionName);
		return ElementMapsWithElementTarget(elementTarget, actionId, skipDisabledMaps);
	}

	public ActionElementMap GetFirstElementMapWithElementTarget(ControllerElementTarget elementTarget, bool skipDisabledMaps)
	{
		if (ReInput._id != XTCjmLKuHDyBHCdnAHQddPuHUPTo)
		{
			ReInput.CheckInitialized(XTCjmLKuHDyBHCdnAHQddPuHUPTo);
			return null;
		}
		edomyHoabKkWzxLwelGsLkZrDlzw edomyHoabKkWzxLwelGsLkZrDlzw2 = edomyHoabKkWzxLwelGsLkZrDlzw.YrulkGTOzpYsHraDBHAumBfMBGzd(elementTarget);
		ActionElementMap firstElementMapWithElementTarget = GetFirstElementMapWithElementTarget(edomyHoabKkWzxLwelGsLkZrDlzw2, skipDisabledMaps);
		edomyHoabKkWzxLwelGsLkZrDlzw.ZQnGowaWMdKIQroVeeRgAzvXTUJX(edomyHoabKkWzxLwelGsLkZrDlzw2);
		return firstElementMapWithElementTarget;
	}

	public ActionElementMap GetFirstElementMapWithElementTarget(IControllerElementTarget elementTarget, bool skipDisabledMaps)
	{
		if (ReInput._id != XTCjmLKuHDyBHCdnAHQddPuHUPTo)
		{
			ReInput.CheckInitialized(XTCjmLKuHDyBHCdnAHQddPuHUPTo);
			return null;
		}
		bool flag;
		return rWGkzCaHmFroxLHHiILXPuevKYvo(elementTarget, false, -1, skipDisabledMaps, out flag);
	}

	public ActionElementMap GetFirstElementMapWithElementTarget(ControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps)
	{
		if (ReInput._id != XTCjmLKuHDyBHCdnAHQddPuHUPTo)
		{
			ReInput.CheckInitialized(XTCjmLKuHDyBHCdnAHQddPuHUPTo);
			return null;
		}
		edomyHoabKkWzxLwelGsLkZrDlzw edomyHoabKkWzxLwelGsLkZrDlzw2 = edomyHoabKkWzxLwelGsLkZrDlzw.YrulkGTOzpYsHraDBHAumBfMBGzd(elementTarget);
		ActionElementMap firstElementMapWithElementTarget = GetFirstElementMapWithElementTarget(edomyHoabKkWzxLwelGsLkZrDlzw2, actionId, skipDisabledMaps);
		edomyHoabKkWzxLwelGsLkZrDlzw.ZQnGowaWMdKIQroVeeRgAzvXTUJX(edomyHoabKkWzxLwelGsLkZrDlzw2);
		return firstElementMapWithElementTarget;
	}

	public ActionElementMap GetFirstElementMapWithElementTarget(ControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps)
	{
		if (ReInput._id != XTCjmLKuHDyBHCdnAHQddPuHUPTo)
		{
			ReInput.CheckInitialized(XTCjmLKuHDyBHCdnAHQddPuHUPTo);
			return null;
		}
		int actionId = ReInput.IsSPFehscBAmxtEADWGWuasjDvqf.GhVjGDQeDQmOWTnROakHcfdeCdDd(actionName);
		return GetFirstElementMapWithElementTarget(elementTarget, actionId, skipDisabledMaps);
	}

	public ActionElementMap GetFirstElementMapWithElementTarget(IControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps)
	{
		if (ReInput._id != XTCjmLKuHDyBHCdnAHQddPuHUPTo)
		{
			ReInput.CheckInitialized(XTCjmLKuHDyBHCdnAHQddPuHUPTo);
			return null;
		}
		bool flag;
		return rWGkzCaHmFroxLHHiILXPuevKYvo(elementTarget, true, actionId, skipDisabledMaps, out flag);
	}

	public ActionElementMap GetFirstElementMapWithElementTarget(IControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps)
	{
		if (ReInput._id != XTCjmLKuHDyBHCdnAHQddPuHUPTo)
		{
			ReInput.CheckInitialized(XTCjmLKuHDyBHCdnAHQddPuHUPTo);
			return null;
		}
		int actionId = ReInput.IsSPFehscBAmxtEADWGWuasjDvqf.GhVjGDQeDQmOWTnROakHcfdeCdDd(actionName);
		return GetFirstElementMapWithElementTarget(elementTarget, actionId, skipDisabledMaps);
	}

	public int GetElementMapsWithElementTarget(ControllerElementTarget elementTarget, bool skipDisabledMaps, List<ActionElementMap> results)
	{
		if (ReInput._id != XTCjmLKuHDyBHCdnAHQddPuHUPTo)
		{
			ReInput.CheckInitialized(XTCjmLKuHDyBHCdnAHQddPuHUPTo);
			return 0;
		}
		edomyHoabKkWzxLwelGsLkZrDlzw edomyHoabKkWzxLwelGsLkZrDlzw2 = edomyHoabKkWzxLwelGsLkZrDlzw.YrulkGTOzpYsHraDBHAumBfMBGzd(elementTarget);
		int elementMapsWithElementTarget = GetElementMapsWithElementTarget(edomyHoabKkWzxLwelGsLkZrDlzw2, skipDisabledMaps, results);
		edomyHoabKkWzxLwelGsLkZrDlzw.ZQnGowaWMdKIQroVeeRgAzvXTUJX(edomyHoabKkWzxLwelGsLkZrDlzw2);
		return elementMapsWithElementTarget;
	}

	public int GetElementMapsWithElementTarget(IControllerElementTarget elementTarget, bool skipDisabledMaps, List<ActionElementMap> results)
	{
		if (ReInput._id != XTCjmLKuHDyBHCdnAHQddPuHUPTo)
		{
			ReInput.CheckInitialized(XTCjmLKuHDyBHCdnAHQddPuHUPTo);
			return 0;
		}
		bool flag;
		return AQsAVNZYhsajiONJBaCUyUaUYtSD(elementTarget, false, -1, skipDisabledMaps, results, false, out flag);
	}

	public int GetElementMapsWithElementTarget(ControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
	{
		if (ReInput._id != XTCjmLKuHDyBHCdnAHQddPuHUPTo)
		{
			ReInput.CheckInitialized(XTCjmLKuHDyBHCdnAHQddPuHUPTo);
			return 0;
		}
		edomyHoabKkWzxLwelGsLkZrDlzw edomyHoabKkWzxLwelGsLkZrDlzw2 = edomyHoabKkWzxLwelGsLkZrDlzw.YrulkGTOzpYsHraDBHAumBfMBGzd(elementTarget);
		int elementMapsWithElementTarget = GetElementMapsWithElementTarget(edomyHoabKkWzxLwelGsLkZrDlzw2, actionId, skipDisabledMaps, results);
		edomyHoabKkWzxLwelGsLkZrDlzw.ZQnGowaWMdKIQroVeeRgAzvXTUJX(edomyHoabKkWzxLwelGsLkZrDlzw2);
		return elementMapsWithElementTarget;
	}

	public int GetElementMapsWithElementTarget(ControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
	{
		if (ReInput._id != XTCjmLKuHDyBHCdnAHQddPuHUPTo)
		{
			ReInput.CheckInitialized(XTCjmLKuHDyBHCdnAHQddPuHUPTo);
			return 0;
		}
		int actionId = ReInput.IsSPFehscBAmxtEADWGWuasjDvqf.GhVjGDQeDQmOWTnROakHcfdeCdDd(actionName);
		return GetElementMapsWithElementTarget(elementTarget, actionId, skipDisabledMaps, results);
	}

	public int GetElementMapsWithElementTarget(IControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
	{
		if (ReInput._id != XTCjmLKuHDyBHCdnAHQddPuHUPTo)
		{
			ReInput.CheckInitialized(XTCjmLKuHDyBHCdnAHQddPuHUPTo);
			return 0;
		}
		bool flag;
		return AQsAVNZYhsajiONJBaCUyUaUYtSD(elementTarget, true, actionId, skipDisabledMaps, results, false, out flag);
	}

	public int GetElementMapsWithElementTarget(IControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
	{
		if (ReInput._id != XTCjmLKuHDyBHCdnAHQddPuHUPTo)
		{
			ReInput.CheckInitialized(XTCjmLKuHDyBHCdnAHQddPuHUPTo);
			return 0;
		}
		int actionId = ReInput.IsSPFehscBAmxtEADWGWuasjDvqf.GhVjGDQeDQmOWTnROakHcfdeCdDd(actionName);
		return GetElementMapsWithElementTarget(elementTarget, actionId, skipDisabledMaps, results);
	}

	public ActionElementMap GetFirstElementMapMatch(Predicate<ActionElementMap> predicate)
	{
		if (ReInput._id != XTCjmLKuHDyBHCdnAHQddPuHUPTo)
		{
			ReInput.CheckInitialized(XTCjmLKuHDyBHCdnAHQddPuHUPTo);
			return null;
		}
		return NVzgxKrqOfDMcDwhzoluufJpIYodb(predicate, false);
	}

	internal virtual ActionElementMap NVzgxKrqOfDMcDwhzoluufJpIYodb(Predicate<ActionElementMap> P_0, bool P_1)
	{
		return hVBKFZxwzerrqoxQXSHSfvTgHaKA(P_0, P_1);
	}

	public int GetElementMapMatches(Predicate<ActionElementMap> predicate, List<ActionElementMap> results)
	{
		if (ReInput._id != XTCjmLKuHDyBHCdnAHQddPuHUPTo)
		{
			ReInput.CheckInitialized(XTCjmLKuHDyBHCdnAHQddPuHUPTo);
			return 0;
		}
		return RySnNfmkfVFFiPuhOdrfvbeGhwzGA(predicate, false, results, false);
	}

	internal virtual int RySnNfmkfVFFiPuhOdrfvbeGhwzGA(Predicate<ActionElementMap> P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
	{
		return sXGkUIMPgxrJDLTPHtLvbjddeTKK(P_0, P_1, P_2, P_3);
	}

	public void ForEachElementMapMatch(Predicate<ActionElementMap> predicate, Action<ActionElementMap> actionToPerform)
	{
		if (ReInput._id != XTCjmLKuHDyBHCdnAHQddPuHUPTo)
		{
			ReInput.CheckInitialized(XTCjmLKuHDyBHCdnAHQddPuHUPTo);
			return;
		}
		if (predicate == null)
		{
			throw new ArgumentNullException("predicate");
		}
		if (actionToPerform == null)
		{
			throw new ArgumentNullException("actionToPerform");
		}
		int count = QbAaitvGUaSWYrRcFrSSnhbxlRiu.get_Count();
		try
		{
			for (int i = 0; i < count; i++)
			{
				ActionElementMap obj = QbAaitvGUaSWYrRcFrSSnhbxlRiu.get_Item(i);
				if (predicate(obj))
				{
					actionToPerform(obj);
				}
			}
		}
		catch (Exception exception)
		{
			ReInput.HandleCallbackException("ControllerMap.ForEachElementMapMatch", exception);
		}
	}

	public virtual void ClearElementMaps()
	{
		if (ReInput._id != XTCjmLKuHDyBHCdnAHQddPuHUPTo)
		{
			ReInput.CheckInitialized(XTCjmLKuHDyBHCdnAHQddPuHUPTo);
			return;
		}
		fsfgfURoXdRGlcXBSbnalDeYMNiB.Clear();
		QbAaitvGUaSWYrRcFrSSnhbxlRiu.Clear();
	}

	public int SetAllElementMapsEnabled(bool state)
	{
		if (ReInput._id != XTCjmLKuHDyBHCdnAHQddPuHUPTo)
		{
			ReInput.CheckInitialized(XTCjmLKuHDyBHCdnAHQddPuHUPTo);
			return 0;
		}
		int num = 0;
		int count = QbAaitvGUaSWYrRcFrSSnhbxlRiu.get_Count();
		for (int i = 0; i < count; i++)
		{
			ActionElementMap actionElementMap = QbAaitvGUaSWYrRcFrSSnhbxlRiu.get_Item(i);
			if (actionElementMap.YbgQyWQdQcTTSlKYNScpqBbjmQQo != state)
			{
				actionElementMap.YbgQyWQdQcTTSlKYNScpqBbjmQQo = state;
				num++;
			}
		}
		return num;
	}

	public ActionElementMap GetButtonMap(int index)
	{
		if (ReInput._id != XTCjmLKuHDyBHCdnAHQddPuHUPTo)
		{
			ReInput.CheckInitialized(XTCjmLKuHDyBHCdnAHQddPuHUPTo);
			return null;
		}
		if (fsfgfURoXdRGlcXBSbnalDeYMNiB == null || index < 0 || index >= fsfgfURoXdRGlcXBSbnalDeYMNiB.get_Count())
		{
			return null;
		}
		return fsfgfURoXdRGlcXBSbnalDeYMNiB.get_Item(index);
	}

	public ActionElementMap[] GetButtonMaps()
	{
		if (ReInput._id != XTCjmLKuHDyBHCdnAHQddPuHUPTo)
		{
			ReInput.CheckInitialized(XTCjmLKuHDyBHCdnAHQddPuHUPTo);
			return EmptyObjects<ActionElementMap>.array;
		}
		return ListTools.ToArray(fsfgfURoXdRGlcXBSbnalDeYMNiB);
	}

	public ActionElementMap[] GetButtonMaps(bool skipDisabledMaps)
	{
		if (ReInput._id != XTCjmLKuHDyBHCdnAHQddPuHUPTo)
		{
			ReInput.CheckInitialized(XTCjmLKuHDyBHCdnAHQddPuHUPTo);
			return EmptyObjects<ActionElementMap>.array;
		}
		int count = fsfgfURoXdRGlcXBSbnalDeYMNiB.get_Count();
		List<ActionElementMap> list = new List<ActionElementMap>(count);
		for (int i = 0; i < count; i++)
		{
			ActionElementMap actionElementMap = fsfgfURoXdRGlcXBSbnalDeYMNiB.get_Item(i);
			if (!skipDisabledMaps || actionElementMap.YbgQyWQdQcTTSlKYNScpqBbjmQQo)
			{
				list.Add(actionElementMap);
			}
		}
		return list.ToArray();
	}

	public int GetButtonMaps(bool skipDisabledMaps, List<ActionElementMap> results)
	{
		if (ReInput._id != XTCjmLKuHDyBHCdnAHQddPuHUPTo)
		{
			ReInput.CheckInitialized(XTCjmLKuHDyBHCdnAHQddPuHUPTo);
			return 0;
		}
		return GqmiSQTLexTrgoMnXjZdwXCPbqPAA(skipDisabledMaps, results, false);
	}

	public ActionElementMap[] GetButtonMapsWithAction(string actionName)
	{
		if (ReInput._id != XTCjmLKuHDyBHCdnAHQddPuHUPTo)
		{
			ReInput.CheckInitialized(XTCjmLKuHDyBHCdnAHQddPuHUPTo);
			return EmptyObjects<ActionElementMap>.array;
		}
		InputAction inputAction = ReInput.IsSPFehscBAmxtEADWGWuasjDvqf.pxqIwEDqxMKXOCayUJiZFLWEOTiW(actionName, true);
		if (inputAction == null)
		{
			return EmptyObjects<ActionElementMap>.array;
		}
		return GetButtonMapsWithAction(inputAction.id);
	}

	public ActionElementMap[] GetButtonMapsWithAction(int actionId)
	{
		return GetButtonMapsWithAction(actionId, skipDisabledMaps: false);
	}

	public ActionElementMap[] GetButtonMapsWithAction(string actionName, bool skipDisabledMaps)
	{
		if (ReInput._id != XTCjmLKuHDyBHCdnAHQddPuHUPTo)
		{
			ReInput.CheckInitialized(XTCjmLKuHDyBHCdnAHQddPuHUPTo);
			return EmptyObjects<ActionElementMap>.array;
		}
		InputAction inputAction = ReInput.IsSPFehscBAmxtEADWGWuasjDvqf.pxqIwEDqxMKXOCayUJiZFLWEOTiW(actionName, true);
		if (inputAction == null)
		{
			return EmptyObjects<ActionElementMap>.array;
		}
		return GetButtonMapsWithAction(inputAction.id, skipDisabledMaps);
	}

	public ActionElementMap[] GetButtonMapsWithAction(int actionId, bool skipDisabledMaps)
	{
		if (ReInput._id != XTCjmLKuHDyBHCdnAHQddPuHUPTo)
		{
			ReInput.CheckInitialized(XTCjmLKuHDyBHCdnAHQddPuHUPTo);
			return EmptyObjects<ActionElementMap>.array;
		}
		int num = buttonMapCount;
		if (num == 0)
		{
			return EmptyObjects<ActionElementMap>.array;
		}
		int num2 = 0;
		for (int i = 0; i < num; i++)
		{
			ActionElementMap actionElementMap = fsfgfURoXdRGlcXBSbnalDeYMNiB.get_Item(i);
			if (actionElementMap._actionId == actionId && (!skipDisabledMaps || actionElementMap.YbgQyWQdQcTTSlKYNScpqBbjmQQo))
			{
				num2++;
			}
		}
		if (num2 == 0)
		{
			return EmptyObjects<ActionElementMap>.array;
		}
		ActionElementMap[] array = new ActionElementMap[num2];
		int num3 = 0;
		for (int j = 0; j < num; j++)
		{
			ActionElementMap actionElementMap2 = fsfgfURoXdRGlcXBSbnalDeYMNiB.get_Item(j);
			if (actionElementMap2._actionId == actionId && (!skipDisabledMaps || actionElementMap2.YbgQyWQdQcTTSlKYNScpqBbjmQQo))
			{
				array[num3] = actionElementMap2;
				num3++;
			}
		}
		return array;
	}

	public int GetButtonMapsWithAction(string actionName, List<ActionElementMap> results)
	{
		if (ReInput._id != XTCjmLKuHDyBHCdnAHQddPuHUPTo)
		{
			ReInput.CheckInitialized(XTCjmLKuHDyBHCdnAHQddPuHUPTo);
			return 0;
		}
		InputAction inputAction = ReInput.IsSPFehscBAmxtEADWGWuasjDvqf.pxqIwEDqxMKXOCayUJiZFLWEOTiW(actionName, true);
		if (inputAction == null)
		{
			ListTools.TryClear(results);
			return 0;
		}
		return GetButtonMapsWithAction(inputAction.id, results);
	}

	public int GetButtonMapsWithAction(int actionId, List<ActionElementMap> results)
	{
		return GetButtonMapsWithAction(actionId, skipDisabledMaps: false, results);
	}

	public int GetButtonMapsWithAction(string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
	{
		if (ReInput._id != XTCjmLKuHDyBHCdnAHQddPuHUPTo)
		{
			ReInput.CheckInitialized(XTCjmLKuHDyBHCdnAHQddPuHUPTo);
			return 0;
		}
		InputAction inputAction = ReInput.IsSPFehscBAmxtEADWGWuasjDvqf.pxqIwEDqxMKXOCayUJiZFLWEOTiW(actionName, true);
		if (inputAction == null)
		{
			ListTools.TryClear(results);
			return 0;
		}
		return GetButtonMapsWithAction(inputAction.id, skipDisabledMaps, results);
	}

	public int GetButtonMapsWithAction(int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
	{
		if (ReInput._id != XTCjmLKuHDyBHCdnAHQddPuHUPTo)
		{
			ReInput.CheckInitialized(XTCjmLKuHDyBHCdnAHQddPuHUPTo);
			return 0;
		}
		return McklfRwAeXVOuqClaWFCiKesBkgI(actionId, skipDisabledMaps, results, false);
	}

	public IEnumerable<ActionElementMap> ButtonMapsWithAction(int actionId)
	{
		return ButtonMapsWithAction(actionId, skipDisabledMaps: false);
	}

	public IEnumerable<ActionElementMap> ButtonMapsWithAction(string actionName)
	{
		if (ReInput._id != XTCjmLKuHDyBHCdnAHQddPuHUPTo)
		{
			ReInput.CheckInitialized(XTCjmLKuHDyBHCdnAHQddPuHUPTo);
			return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
		}
		int actionId = ReInput.IsSPFehscBAmxtEADWGWuasjDvqf.GhVjGDQeDQmOWTnROakHcfdeCdDd(actionName);
		return ButtonMapsWithAction(actionId);
	}

	[IteratorStateMachine(typeof(VrxOlbyIWRqpsSLgBUAEPheRMuOl))]
	public IEnumerable<ActionElementMap> ButtonMapsWithAction(int actionId, bool skipDisabledMaps)
	{
		return new VrxOlbyIWRqpsSLgBUAEPheRMuOl(-2)
		{
			MKvoNOqakyixVFOZHnEulohNdHuI = this,
			RbsxpNtYiBaPCWWEIxmMrbNcOaNE = actionId,
			FpbLPVLHrQZPSkcXEXqqIXWnoLBd = skipDisabledMaps
		};
	}

	public IEnumerable<ActionElementMap> ButtonMapsWithAction(string actionName, bool skipDisabledMaps)
	{
		if (ReInput._id != XTCjmLKuHDyBHCdnAHQddPuHUPTo)
		{
			ReInput.CheckInitialized(XTCjmLKuHDyBHCdnAHQddPuHUPTo);
			return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
		}
		int actionId = ReInput.IsSPFehscBAmxtEADWGWuasjDvqf.GhVjGDQeDQmOWTnROakHcfdeCdDd(actionName);
		return ButtonMapsWithAction(actionId, skipDisabledMaps);
	}

	public ActionElementMap GetFirstButtonMapWithAction(int actionId)
	{
		return GetFirstButtonMapWithAction(actionId, skipDisabledMaps: false);
	}

	public ActionElementMap GetFirstButtonMapWithAction(string actionName)
	{
		if (ReInput._id != XTCjmLKuHDyBHCdnAHQddPuHUPTo)
		{
			ReInput.CheckInitialized(XTCjmLKuHDyBHCdnAHQddPuHUPTo);
			return null;
		}
		int actionId = ReInput.IsSPFehscBAmxtEADWGWuasjDvqf.GhVjGDQeDQmOWTnROakHcfdeCdDd(actionName);
		return GetFirstButtonMapWithAction(actionId);
	}

	public ActionElementMap GetFirstButtonMapWithAction(int actionId, bool skipDisabledMaps)
	{
		if (ReInput._id != XTCjmLKuHDyBHCdnAHQddPuHUPTo)
		{
			ReInput.CheckInitialized(XTCjmLKuHDyBHCdnAHQddPuHUPTo);
			return null;
		}
		if (actionId < 0)
		{
			return null;
		}
		IList<ActionElementMap> buttonMaps = ButtonMaps;
		int num = buttonMapCount;
		for (int i = 0; i < num; i++)
		{
			ActionElementMap actionElementMap = buttonMaps[i];
			if (actionElementMap._actionId == actionId && (!skipDisabledMaps || actionElementMap.enabled))
			{
				return actionElementMap;
			}
		}
		return null;
	}

	public ActionElementMap GetFirstButtonMapWithAction(string actionName, bool skipDisabledMaps)
	{
		if (ReInput._id != XTCjmLKuHDyBHCdnAHQddPuHUPTo)
		{
			ReInput.CheckInitialized(XTCjmLKuHDyBHCdnAHQddPuHUPTo);
			return null;
		}
		int actionId = ReInput.IsSPFehscBAmxtEADWGWuasjDvqf.GhVjGDQeDQmOWTnROakHcfdeCdDd(actionName);
		return GetFirstButtonMapWithAction(actionId, skipDisabledMaps);
	}

	public ActionElementMap GetFirstButtonMapMatch(Predicate<ActionElementMap> predicate)
	{
		if (ReInput._id != XTCjmLKuHDyBHCdnAHQddPuHUPTo)
		{
			ReInput.CheckInitialized(XTCjmLKuHDyBHCdnAHQddPuHUPTo);
			return null;
		}
		return hVBKFZxwzerrqoxQXSHSfvTgHaKA(predicate, false);
	}

	internal ActionElementMap hVBKFZxwzerrqoxQXSHSfvTgHaKA(Predicate<ActionElementMap> P_0, bool P_1)
	{
		if (ReInput._id != XTCjmLKuHDyBHCdnAHQddPuHUPTo)
		{
			ReInput.CheckInitialized(XTCjmLKuHDyBHCdnAHQddPuHUPTo);
			return null;
		}
		if (P_0 == null)
		{
			throw new ArgumentNullException("predicate");
		}
		IList<ActionElementMap> buttonMaps = ButtonMaps;
		int num = buttonMapCount;
		try
		{
			for (int i = 0; i < num; i++)
			{
				ActionElementMap actionElementMap = buttonMaps[i];
				if ((!P_1 || actionElementMap.enabled) && P_0(actionElementMap))
				{
					return actionElementMap;
				}
			}
		}
		catch (Exception exception)
		{
			ReInput.HandleCallbackException("ControllerMap.GetFirstButtonMapMatch", exception);
		}
		return null;
	}

	public int GetButtonMapMatches(Predicate<ActionElementMap> predicate, List<ActionElementMap> results)
	{
		if (ReInput._id != XTCjmLKuHDyBHCdnAHQddPuHUPTo)
		{
			ReInput.CheckInitialized(XTCjmLKuHDyBHCdnAHQddPuHUPTo);
			return 0;
		}
		return sXGkUIMPgxrJDLTPHtLvbjddeTKK(predicate, false, results, false);
	}

	internal int sXGkUIMPgxrJDLTPHtLvbjddeTKK(Predicate<ActionElementMap> P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
	{
		if (P_0 == null)
		{
			throw new ArgumentNullException("predicate");
		}
		if (P_2 == null)
		{
			throw new ArgumentNullException("results");
		}
		int num = 0;
		if (!P_3)
		{
			P_2.Clear();
		}
		else
		{
			num = P_2.Count;
		}
		IList<ActionElementMap> buttonMaps = ButtonMaps;
		int num2 = buttonMapCount;
		try
		{
			for (int i = 0; i < num2; i++)
			{
				ActionElementMap actionElementMap = buttonMaps[i];
				if ((!P_1 || actionElementMap.enabled) && P_0(actionElementMap))
				{
					P_2.Add(actionElementMap);
				}
			}
		}
		catch (Exception exception)
		{
			ReInput.HandleCallbackException("ControllerMap.GetButtonMapMatches", exception);
		}
		return P_2.Count - num;
	}

	public void ForEachButtonMapMatch(Predicate<ActionElementMap> predicate, Action<ActionElementMap> actionToPerform)
	{
		if (ReInput._id != XTCjmLKuHDyBHCdnAHQddPuHUPTo)
		{
			ReInput.CheckInitialized(XTCjmLKuHDyBHCdnAHQddPuHUPTo);
			return;
		}
		if (predicate == null)
		{
			throw new ArgumentNullException("predicate");
		}
		if (actionToPerform == null)
		{
			throw new ArgumentNullException("actionToPerform");
		}
		int count = fsfgfURoXdRGlcXBSbnalDeYMNiB.get_Count();
		try
		{
			for (int i = 0; i < count; i++)
			{
				ActionElementMap obj = fsfgfURoXdRGlcXBSbnalDeYMNiB.get_Item(i);
				if (predicate(obj))
				{
					actionToPerform(obj);
				}
			}
		}
		catch (Exception exception)
		{
			ReInput.HandleCallbackException("ControllerMap.GetButtonMapMatches", exception);
		}
	}

	public bool DeleteButtonMapsWithAction(string actionName)
	{
		return DeleteButtonMapsWithAction(ReInput.IsSPFehscBAmxtEADWGWuasjDvqf.GhVjGDQeDQmOWTnROakHcfdeCdDd(actionName));
	}

	public bool DeleteButtonMapsWithAction(int actionId)
	{
		if (ReInput._id != XTCjmLKuHDyBHCdnAHQddPuHUPTo)
		{
			ReInput.CheckInitialized(XTCjmLKuHDyBHCdnAHQddPuHUPTo);
			return false;
		}
		if (actionId < 0)
		{
			return false;
		}
		int num = buttonMapCount;
		if (num == 0)
		{
			return false;
		}
		bool result = false;
		for (int num2 = num - 1; num2 >= 0; num2--)
		{
			ActionElementMap actionElementMap = fsfgfURoXdRGlcXBSbnalDeYMNiB.get_Item(num2);
			if (actionElementMap != null && actionElementMap._actionId == actionId)
			{
				xPDpwubZeRwFkRocGwDPfBgdGxHY(actionElementMap.LQceMJAxYgRpolrwLwsLBxilJMmNA, num2);
				result = true;
			}
		}
		return result;
	}

	public int SetAllButtonMapsEnabled(bool state)
	{
		if (ReInput._id != XTCjmLKuHDyBHCdnAHQddPuHUPTo)
		{
			ReInput.CheckInitialized(XTCjmLKuHDyBHCdnAHQddPuHUPTo);
			return 0;
		}
		int num = 0;
		int count = fsfgfURoXdRGlcXBSbnalDeYMNiB.get_Count();
		for (int i = 0; i < count; i++)
		{
			ActionElementMap actionElementMap = fsfgfURoXdRGlcXBSbnalDeYMNiB.get_Item(i);
			if (actionElementMap.YbgQyWQdQcTTSlKYNScpqBbjmQQo != state)
			{
				actionElementMap.YbgQyWQdQcTTSlKYNScpqBbjmQQo = state;
				num++;
			}
		}
		return num;
	}

	public bool DoesElementAssignmentConflict(ControllerMap controllerMap)
	{
		return DoesElementAssignmentConflict(controllerMap, skipDisabledMaps: false);
	}

	public bool DoesElementAssignmentConflict(ActionElementMap actionElementMap)
	{
		return DoesElementAssignmentConflict(actionElementMap, skipDisabledMaps: false);
	}

	public bool DoesElementAssignmentConflict(ElementAssignmentConflictCheck conflictCheck)
	{
		return DoesElementAssignmentConflict(conflictCheck, skipDisabledMaps: false);
	}

	public virtual bool DoesElementAssignmentConflict(ControllerMap controllerMap, bool skipDisabledMaps)
	{
		if (ReInput._id != XTCjmLKuHDyBHCdnAHQddPuHUPTo)
		{
			ReInput.CheckInitialized(XTCjmLKuHDyBHCdnAHQddPuHUPTo);
			return false;
		}
		if (controllerMap == null)
		{
			return false;
		}
		if (skipDisabledMaps && (!_enabled || !controllerMap._enabled))
		{
			return false;
		}
		if (fsfgfURoXdRGlcXBSbnalDeYMNiB == null)
		{
			return false;
		}
		IList<ActionElementMap> buttonMaps = controllerMap.ButtonMaps;
		if (buttonMaps == null)
		{
			return false;
		}
		int num = buttonMapCount;
		int count = buttonMaps.Count;
		for (int i = 0; i < num; i++)
		{
			ActionElementMap actionElementMap = fsfgfURoXdRGlcXBSbnalDeYMNiB.get_Item(i);
			if (skipDisabledMaps && !actionElementMap.YbgQyWQdQcTTSlKYNScpqBbjmQQo)
			{
				continue;
			}
			for (int j = 0; j < count; j++)
			{
				ActionElementMap actionElementMap2 = buttonMaps[j];
				if ((!skipDisabledMaps || actionElementMap2.YbgQyWQdQcTTSlKYNScpqBbjmQQo) && actionElementMap != actionElementMap2 && actionElementMap.CheckForAssignmentConflict(actionElementMap2))
				{
					return true;
				}
			}
		}
		return false;
	}

	public virtual bool DoesElementAssignmentConflict(ActionElementMap actionElementMap, bool skipDisabledMaps)
	{
		if (ReInput._id != XTCjmLKuHDyBHCdnAHQddPuHUPTo)
		{
			ReInput.CheckInitialized(XTCjmLKuHDyBHCdnAHQddPuHUPTo);
			return false;
		}
		if (actionElementMap == null || fsfgfURoXdRGlcXBSbnalDeYMNiB == null)
		{
			return false;
		}
		if (skipDisabledMaps && (!_enabled || !actionElementMap.YbgQyWQdQcTTSlKYNScpqBbjmQQo))
		{
			return false;
		}
		for (int i = 0; i < fsfgfURoXdRGlcXBSbnalDeYMNiB.get_Count(); i++)
		{
			ActionElementMap actionElementMap2 = fsfgfURoXdRGlcXBSbnalDeYMNiB.get_Item(i);
			if ((!skipDisabledMaps || actionElementMap2.YbgQyWQdQcTTSlKYNScpqBbjmQQo) && actionElementMap2 != actionElementMap && actionElementMap2.CheckForAssignmentConflict(actionElementMap))
			{
				return true;
			}
		}
		return false;
	}

	public virtual bool DoesElementAssignmentConflict(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
	{
		if (ReInput._id != XTCjmLKuHDyBHCdnAHQddPuHUPTo)
		{
			ReInput.CheckInitialized(XTCjmLKuHDyBHCdnAHQddPuHUPTo);
			return false;
		}
		if (fsfgfURoXdRGlcXBSbnalDeYMNiB == null)
		{
			return false;
		}
		if (skipDisabledMaps && !_enabled)
		{
			return false;
		}
		if (conflictCheck.elementAssignmentType != ElementAssignmentType.Button && conflictCheck.elementAssignmentType != ElementAssignmentType.KeyboardKey)
		{
			return false;
		}
		ElementAssignment elementAssignment = conflictCheck.ToElementAssignment();
		for (int i = 0; i < fsfgfURoXdRGlcXBSbnalDeYMNiB.get_Count(); i++)
		{
			ActionElementMap actionElementMap = fsfgfURoXdRGlcXBSbnalDeYMNiB.get_Item(i);
			if ((!skipDisabledMaps || actionElementMap.YbgQyWQdQcTTSlKYNScpqBbjmQQo) && actionElementMap.LQceMJAxYgRpolrwLwsLBxilJMmNA != conflictCheck.elementMapId && actionElementMap.CheckForAssignmentConflict(elementAssignment))
			{
				return true;
			}
		}
		return false;
	}

	public IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ControllerMap controllerMap)
	{
		return ElementAssignmentConflicts(controllerMap, skipDisabledMaps: false);
	}

	public IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ActionElementMap actionElementMap)
	{
		return ElementAssignmentConflicts(actionElementMap, skipDisabledMaps: false);
	}

	public IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck)
	{
		return ElementAssignmentConflicts(conflictCheck, skipDisabledMaps: false);
	}

	[IteratorStateMachine(typeof(eRFHQorYBSRLfwumqWTbSiUmijbv))]
	public virtual IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ControllerMap controllerMap, bool skipDisabledMaps)
	{
		return new eRFHQorYBSRLfwumqWTbSiUmijbv(-2)
		{
			DjtUiRvZYvVBPybdjiBYRekPaShKA = this,
			SqkiqeXcZMBkJtNDqVTrSGyPmhnW = controllerMap,
			DOORVRQeSVGkbKtlzpdJJxljyMoc = skipDisabledMaps
		};
	}

	[IteratorStateMachine(typeof(igDPRBeolHFHrPYzhHHFayQiIwLU))]
	public virtual IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ActionElementMap actionElementMap, bool skipDisabledMaps)
	{
		return new igDPRBeolHFHrPYzhHHFayQiIwLU(-2)
		{
			XLMCJCTDLAIwnBEUVAlSsfywkkFZ = this,
			WCRGplpgslKoeQpsLkmxEQDjcuRI = actionElementMap,
			RUZcFtHRNJjuEHoXOrpbCFUKOvzD = skipDisabledMaps
		};
	}

	[IteratorStateMachine(typeof(inHjaHkNRGJgKFziSMIFRFgLIcdJA))]
	public virtual IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
	{
		return new inHjaHkNRGJgKFziSMIFRFgLIcdJA(-2)
		{
			kUessGviNrPvgRzslDVdEHNvklwL = this,
			mkpfSwaPiWcWldMdAhSdOekGBiewB = conflictCheck,
			TJjFSgScYdtBqktObjXCyQjIvlEF = skipDisabledMaps
		};
	}

	public int RemoveElementAssignmentConflicts(ControllerMap controllerMap)
	{
		return RemoveElementAssignmentConflicts(controllerMap, skipDisabledMaps: false);
	}

	public int RemoveElementAssignmentConflicts(ActionElementMap actionElementMap)
	{
		return RemoveElementAssignmentConflicts(actionElementMap, skipDisabledMaps: false);
	}

	public int RemoveElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck)
	{
		return RemoveElementAssignmentConflicts(conflictCheck, skipDisabledMaps: false);
	}

	public virtual int RemoveElementAssignmentConflicts(ControllerMap controllerMap, bool skipDisabledMaps)
	{
		if (ReInput._id != XTCjmLKuHDyBHCdnAHQddPuHUPTo)
		{
			ReInput.CheckInitialized(XTCjmLKuHDyBHCdnAHQddPuHUPTo);
			return 0;
		}
		if (controllerMap == null)
		{
			return 0;
		}
		if (skipDisabledMaps && (!_enabled || !controllerMap._enabled))
		{
			return 0;
		}
		int num = 0;
		if (fsfgfURoXdRGlcXBSbnalDeYMNiB == null)
		{
			return num;
		}
		IList<ActionElementMap> list = controllerMap.fsfgfURoXdRGlcXBSbnalDeYMNiB;
		if (list == null)
		{
			return num;
		}
		InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(_categoryId);
		if (mapCategory != null && !mapCategory.userAssignable)
		{
			return num;
		}
		_ = buttonMapCount;
		int count = list.Count;
		for (int num2 = fsfgfURoXdRGlcXBSbnalDeYMNiB.get_Count() - 1; num2 >= 0; num2--)
		{
			ActionElementMap actionElementMap = fsfgfURoXdRGlcXBSbnalDeYMNiB.get_Item(num2);
			if (!skipDisabledMaps || actionElementMap.YbgQyWQdQcTTSlKYNScpqBbjmQQo)
			{
				for (int i = 0; i < count; i++)
				{
					if ((!skipDisabledMaps || list[i].YbgQyWQdQcTTSlKYNScpqBbjmQQo) && actionElementMap.CheckForAssignmentConflict(list[i]))
					{
						xPDpwubZeRwFkRocGwDPfBgdGxHY(actionElementMap.LQceMJAxYgRpolrwLwsLBxilJMmNA, num2);
						num++;
						break;
					}
				}
			}
		}
		return num;
	}

	public virtual int RemoveElementAssignmentConflicts(ActionElementMap actionElementMap, bool skipDisabledMaps)
	{
		if (ReInput._id != XTCjmLKuHDyBHCdnAHQddPuHUPTo)
		{
			ReInput.CheckInitialized(XTCjmLKuHDyBHCdnAHQddPuHUPTo);
			return 0;
		}
		if (actionElementMap == null)
		{
			return 0;
		}
		if (skipDisabledMaps && (!_enabled || !actionElementMap.YbgQyWQdQcTTSlKYNScpqBbjmQQo))
		{
			return 0;
		}
		int num = 0;
		InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(_categoryId);
		if (mapCategory == null)
		{
			return num;
		}
		if (!mapCategory.userAssignable)
		{
			return num;
		}
		if (fsfgfURoXdRGlcXBSbnalDeYMNiB == null)
		{
			return num;
		}
		for (int num2 = fsfgfURoXdRGlcXBSbnalDeYMNiB.get_Count() - 1; num2 >= 0; num2--)
		{
			ActionElementMap actionElementMap2 = fsfgfURoXdRGlcXBSbnalDeYMNiB.get_Item(num2);
			if ((!skipDisabledMaps || actionElementMap2.YbgQyWQdQcTTSlKYNScpqBbjmQQo) && actionElementMap2.CheckForAssignmentConflict(actionElementMap))
			{
				xPDpwubZeRwFkRocGwDPfBgdGxHY(actionElementMap2.LQceMJAxYgRpolrwLwsLBxilJMmNA, num2);
				num++;
			}
		}
		return num;
	}

	public virtual int RemoveElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
	{
		if (ReInput._id != XTCjmLKuHDyBHCdnAHQddPuHUPTo)
		{
			ReInput.CheckInitialized(XTCjmLKuHDyBHCdnAHQddPuHUPTo);
			return 0;
		}
		if (skipDisabledMaps && !_enabled)
		{
			return 0;
		}
		if (fsfgfURoXdRGlcXBSbnalDeYMNiB == null)
		{
			return 0;
		}
		if (conflictCheck.elementAssignmentType != ElementAssignmentType.Button && conflictCheck.elementAssignmentType != ElementAssignmentType.KeyboardKey)
		{
			return 0;
		}
		InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(_categoryId);
		if (mapCategory == null)
		{
			return 0;
		}
		if (!mapCategory.userAssignable)
		{
			return 0;
		}
		ElementAssignment elementAssignment = conflictCheck.ToElementAssignment();
		int num = 0;
		for (int num2 = fsfgfURoXdRGlcXBSbnalDeYMNiB.get_Count() - 1; num2 >= 0; num2--)
		{
			ActionElementMap actionElementMap = fsfgfURoXdRGlcXBSbnalDeYMNiB.get_Item(num2);
			if ((!skipDisabledMaps || actionElementMap.YbgQyWQdQcTTSlKYNScpqBbjmQQo) && actionElementMap.LQceMJAxYgRpolrwLwsLBxilJMmNA != conflictCheck.elementMapId && actionElementMap.CheckForAssignmentConflict(elementAssignment))
			{
				xPDpwubZeRwFkRocGwDPfBgdGxHY(actionElementMap.LQceMJAxYgRpolrwLwsLBxilJMmNA, num2);
				num++;
			}
		}
		return num;
	}

	public int DisableElementAssignmentConflicts(ControllerMap controllerMap)
	{
		if (ReInput._id != XTCjmLKuHDyBHCdnAHQddPuHUPTo)
		{
			ReInput.CheckInitialized(XTCjmLKuHDyBHCdnAHQddPuHUPTo);
			return 0;
		}
		return KQXSSitueJXGlwhxDCvZlKiAkqgh(controllerMap, false, null, false);
	}

	public int DisableElementAssignmentConflicts(ActionElementMap actionElementMap)
	{
		if (ReInput._id != XTCjmLKuHDyBHCdnAHQddPuHUPTo)
		{
			ReInput.CheckInitialized(XTCjmLKuHDyBHCdnAHQddPuHUPTo);
			return 0;
		}
		return ATkMWznydIsmMYtjoavrhFVKJGcj(actionElementMap, false, null, false);
	}

	public int DisableElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck)
	{
		if (ReInput._id != XTCjmLKuHDyBHCdnAHQddPuHUPTo)
		{
			ReInput.CheckInitialized(XTCjmLKuHDyBHCdnAHQddPuHUPTo);
			return 0;
		}
		return slUwgXrcYEXSwNCmAHrYogBZIKCZ(conflictCheck, false, null, false);
	}

	public int DisableElementAssignmentConflicts(ControllerMap controllerMap, bool skipDisabledMaps)
	{
		if (ReInput._id != XTCjmLKuHDyBHCdnAHQddPuHUPTo)
		{
			ReInput.CheckInitialized(XTCjmLKuHDyBHCdnAHQddPuHUPTo);
			return 0;
		}
		return KQXSSitueJXGlwhxDCvZlKiAkqgh(controllerMap, skipDisabledMaps, null, false);
	}

	public int DisableElementAssignmentConflicts(ActionElementMap actionElementMap, bool skipDisabledMaps)
	{
		if (ReInput._id != XTCjmLKuHDyBHCdnAHQddPuHUPTo)
		{
			ReInput.CheckInitialized(XTCjmLKuHDyBHCdnAHQddPuHUPTo);
			return 0;
		}
		return ATkMWznydIsmMYtjoavrhFVKJGcj(actionElementMap, skipDisabledMaps, null, false);
	}

	public int DisableElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
	{
		if (ReInput._id != XTCjmLKuHDyBHCdnAHQddPuHUPTo)
		{
			ReInput.CheckInitialized(XTCjmLKuHDyBHCdnAHQddPuHUPTo);
			return 0;
		}
		return slUwgXrcYEXSwNCmAHrYogBZIKCZ(conflictCheck, skipDisabledMaps, null, false);
	}

	internal virtual int KQXSSitueJXGlwhxDCvZlKiAkqgh(ControllerMap P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
	{
		if (P_2 != null && !P_3)
		{
			P_2.Clear();
		}
		if (P_0 == null)
		{
			return 0;
		}
		if (P_1 && (!_enabled || !P_0._enabled))
		{
			return 0;
		}
		int num = 0;
		if (fsfgfURoXdRGlcXBSbnalDeYMNiB == null)
		{
			return num;
		}
		IList<ActionElementMap> list = P_0.fsfgfURoXdRGlcXBSbnalDeYMNiB;
		if (list == null)
		{
			return num;
		}
		InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(_categoryId);
		if (mapCategory != null && !mapCategory.userAssignable)
		{
			return num;
		}
		int num2 = buttonMapCount;
		int count = list.Count;
		for (int i = 0; i < num2; i++)
		{
			ActionElementMap actionElementMap = fsfgfURoXdRGlcXBSbnalDeYMNiB.get_Item(i);
			if (!actionElementMap.YbgQyWQdQcTTSlKYNScpqBbjmQQo)
			{
				continue;
			}
			for (int j = 0; j < count; j++)
			{
				ActionElementMap actionElementMap2 = list[j];
				if ((!P_1 || actionElementMap2.YbgQyWQdQcTTSlKYNScpqBbjmQQo) && actionElementMap.CheckForAssignmentConflict(actionElementMap2))
				{
					actionElementMap.enabled = false;
					P_2?.Add(actionElementMap);
					num++;
					break;
				}
			}
		}
		return num;
	}

	internal virtual int ATkMWznydIsmMYtjoavrhFVKJGcj(ActionElementMap P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
	{
		if (P_2 != null && !P_3)
		{
			P_2.Clear();
		}
		if (P_0 == null)
		{
			return 0;
		}
		if (P_1 && (!_enabled || !P_0.YbgQyWQdQcTTSlKYNScpqBbjmQQo))
		{
			return 0;
		}
		int num = 0;
		if (P_0.elementIdentifierId < 0)
		{
			return num;
		}
		InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(_categoryId);
		if (mapCategory == null)
		{
			return num;
		}
		if (!mapCategory.userAssignable)
		{
			return num;
		}
		int num2 = buttonMapCount;
		for (int i = 0; i < num2; i++)
		{
			ActionElementMap actionElementMap = fsfgfURoXdRGlcXBSbnalDeYMNiB.get_Item(i);
			if (actionElementMap.YbgQyWQdQcTTSlKYNScpqBbjmQQo && P_0.CheckForAssignmentConflict(actionElementMap))
			{
				actionElementMap.enabled = false;
				P_2?.Add(actionElementMap);
				num++;
			}
		}
		return num;
	}

	internal virtual int slUwgXrcYEXSwNCmAHrYogBZIKCZ(ElementAssignmentConflictCheck P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
	{
		if (P_2 != null && !P_3)
		{
			P_2.Clear();
		}
		if (P_1 && !_enabled)
		{
			return 0;
		}
		if (fsfgfURoXdRGlcXBSbnalDeYMNiB == null)
		{
			return 0;
		}
		if (P_0.elementAssignmentType != ElementAssignmentType.Button && P_0.elementAssignmentType != ElementAssignmentType.KeyboardKey)
		{
			return 0;
		}
		InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(_categoryId);
		if (mapCategory == null)
		{
			return 0;
		}
		if (!mapCategory.userAssignable)
		{
			return 0;
		}
		ElementAssignment elementAssignment = P_0.ToElementAssignment();
		int num = 0;
		int num2 = buttonMapCount;
		for (int i = 0; i < num2; i++)
		{
			ActionElementMap actionElementMap = fsfgfURoXdRGlcXBSbnalDeYMNiB.get_Item(i);
			if (actionElementMap.YbgQyWQdQcTTSlKYNScpqBbjmQQo && actionElementMap.LQceMJAxYgRpolrwLwsLBxilJMmNA != P_0.elementMapId && actionElementMap.CheckForAssignmentConflict(elementAssignment))
			{
				actionElementMap.enabled = false;
				P_2?.Add(actionElementMap);
				num++;
			}
		}
		return num;
	}

	public int ForEachElementAssignmentConflict(ControllerMap controllerMap, Action<ActionElementMap> actionToPerform)
	{
		return ForEachElementAssignmentConflict(controllerMap, actionToPerform, skipDisabledMaps: false);
	}

	public int ForEachElementAssignmentConflict(ActionElementMap actionElementMap, Action<ActionElementMap> actionToPerform)
	{
		return ForEachElementAssignmentConflict(actionElementMap, actionToPerform, skipDisabledMaps: false);
	}

	public int ForEachElementAssignmentConflict(ElementAssignmentConflictCheck conflictCheck, Action<ActionElementMap> actionToPerform)
	{
		return ForEachElementAssignmentConflict(conflictCheck, actionToPerform, skipDisabledMaps: false);
	}

	public int ForEachElementAssignmentConflict(ControllerMap controllerMap, Action<ActionElementMap> actionToPerform, bool skipDisabledMaps)
	{
		if (ReInput._id != XTCjmLKuHDyBHCdnAHQddPuHUPTo)
		{
			ReInput.CheckInitialized(XTCjmLKuHDyBHCdnAHQddPuHUPTo);
			return 0;
		}
		if (actionToPerform == null)
		{
			throw new ArgumentNullException("actionToPerform");
		}
		if (controllerMap == null)
		{
			return 0;
		}
		if (skipDisabledMaps && (!_enabled || !controllerMap._enabled))
		{
			return 0;
		}
		int num = 0;
		if (QbAaitvGUaSWYrRcFrSSnhbxlRiu == null)
		{
			return num;
		}
		IList<ActionElementMap> qbAaitvGUaSWYrRcFrSSnhbxlRiu = controllerMap.QbAaitvGUaSWYrRcFrSSnhbxlRiu;
		if (qbAaitvGUaSWYrRcFrSSnhbxlRiu == null)
		{
			return num;
		}
		InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(_categoryId);
		if (mapCategory != null && !mapCategory.userAssignable)
		{
			return num;
		}
		int count = qbAaitvGUaSWYrRcFrSSnhbxlRiu.Count;
		for (int num2 = QbAaitvGUaSWYrRcFrSSnhbxlRiu.get_Count() - 1; num2 >= 0; num2--)
		{
			ActionElementMap actionElementMap = QbAaitvGUaSWYrRcFrSSnhbxlRiu.get_Item(num2);
			if (!skipDisabledMaps || actionElementMap.YbgQyWQdQcTTSlKYNScpqBbjmQQo)
			{
				for (int i = 0; i < count; i++)
				{
					if ((!skipDisabledMaps || qbAaitvGUaSWYrRcFrSSnhbxlRiu[i].YbgQyWQdQcTTSlKYNScpqBbjmQQo) && actionElementMap.CheckForAssignmentConflict(qbAaitvGUaSWYrRcFrSSnhbxlRiu[i]))
					{
						try
						{
							actionToPerform(actionElementMap);
						}
						catch (Exception exception)
						{
							ReInput.HandleCallbackException("ControllerMap.ForEachElementAssignmentConflict", exception);
							return num;
						}
						num++;
						break;
					}
				}
			}
		}
		return num;
	}

	public int ForEachElementAssignmentConflict(ActionElementMap actionElementMap, Action<ActionElementMap> actionToPerform, bool skipDisabledMaps)
	{
		if (ReInput._id != XTCjmLKuHDyBHCdnAHQddPuHUPTo)
		{
			ReInput.CheckInitialized(XTCjmLKuHDyBHCdnAHQddPuHUPTo);
			return 0;
		}
		if (actionToPerform == null)
		{
			throw new ArgumentNullException("actionToPerform");
		}
		if (actionElementMap == null)
		{
			return 0;
		}
		if (skipDisabledMaps && (!_enabled || !actionElementMap.YbgQyWQdQcTTSlKYNScpqBbjmQQo))
		{
			return 0;
		}
		int num = 0;
		InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(_categoryId);
		if (mapCategory == null)
		{
			return num;
		}
		if (!mapCategory.userAssignable)
		{
			return num;
		}
		if (QbAaitvGUaSWYrRcFrSSnhbxlRiu == null)
		{
			return num;
		}
		for (int num2 = QbAaitvGUaSWYrRcFrSSnhbxlRiu.get_Count() - 1; num2 >= 0; num2--)
		{
			ActionElementMap actionElementMap2 = QbAaitvGUaSWYrRcFrSSnhbxlRiu.get_Item(num2);
			if ((!skipDisabledMaps || actionElementMap2.YbgQyWQdQcTTSlKYNScpqBbjmQQo) && actionElementMap2.CheckForAssignmentConflict(actionElementMap))
			{
				try
				{
					actionToPerform(actionElementMap2);
				}
				catch (Exception exception)
				{
					ReInput.HandleCallbackException("ControllerMap.ForEachElementAssignmentConflict", exception);
					return num;
				}
				num++;
			}
		}
		return num;
	}

	public int ForEachElementAssignmentConflict(ElementAssignmentConflictCheck conflictCheck, Action<ActionElementMap> actionToPerform, bool skipDisabledMaps)
	{
		if (ReInput._id != XTCjmLKuHDyBHCdnAHQddPuHUPTo)
		{
			ReInput.CheckInitialized(XTCjmLKuHDyBHCdnAHQddPuHUPTo);
			return 0;
		}
		if (actionToPerform == null)
		{
			throw new ArgumentNullException("actionToPerform");
		}
		if (skipDisabledMaps && !_enabled)
		{
			return 0;
		}
		if (QbAaitvGUaSWYrRcFrSSnhbxlRiu == null)
		{
			return 0;
		}
		if (conflictCheck.elementAssignmentType != ElementAssignmentType.Button && conflictCheck.elementAssignmentType != ElementAssignmentType.KeyboardKey)
		{
			return 0;
		}
		InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(_categoryId);
		if (mapCategory == null)
		{
			return 0;
		}
		if (!mapCategory.userAssignable)
		{
			return 0;
		}
		ElementAssignment elementAssignment = conflictCheck.ToElementAssignment();
		int num = 0;
		for (int num2 = QbAaitvGUaSWYrRcFrSSnhbxlRiu.get_Count() - 1; num2 >= 0; num2--)
		{
			ActionElementMap actionElementMap = QbAaitvGUaSWYrRcFrSSnhbxlRiu.get_Item(num2);
			if ((!skipDisabledMaps || actionElementMap.YbgQyWQdQcTTSlKYNScpqBbjmQQo) && actionElementMap.LQceMJAxYgRpolrwLwsLBxilJMmNA != conflictCheck.elementMapId && actionElementMap.CheckForAssignmentConflict(elementAssignment))
			{
				try
				{
					actionToPerform(actionElementMap);
				}
				catch (Exception exception)
				{
					ReInput.HandleCallbackException("ControllerMap.ForEachElementAssignmentConflict", exception);
					return num;
				}
				num++;
			}
		}
		return num;
	}

	public string[] GetButtonNames()
	{
		if (ReInput._id != XTCjmLKuHDyBHCdnAHQddPuHUPTo)
		{
			ReInput.CheckInitialized(XTCjmLKuHDyBHCdnAHQddPuHUPTo);
			return EmptyObjects<string>.array;
		}
		int num = buttonMapCount;
		if (num == 0)
		{
			return new string[0];
		}
		string[] array = new string[num];
		for (int i = 0; i < num; i++)
		{
			array[i] = fsfgfURoXdRGlcXBSbnalDeYMNiB.get_Item(i).elementIdentifierName;
		}
		return array;
	}

	public string ToXmlString()
	{
		if (ReInput._id != XTCjmLKuHDyBHCdnAHQddPuHUPTo)
		{
			ReInput.CheckInitialized(XTCjmLKuHDyBHCdnAHQddPuHUPTo);
			return string.Empty;
		}
		try
		{
			return TsDSXqnoFXrRznuSLFntRDZamGSe().ToXmlString(writeDocumentTag: true);
		}
		catch (Exception ex)
		{
			Logger.LogWarning("Error writing " + GetType().Name + " to XML. " + ex.Message);
			return string.Empty;
		}
	}

	public string ToJsonString()
	{
		if (ReInput._id != XTCjmLKuHDyBHCdnAHQddPuHUPTo)
		{
			ReInput.CheckInitialized(XTCjmLKuHDyBHCdnAHQddPuHUPTo);
			return string.Empty;
		}
		try
		{
			return TsDSXqnoFXrRznuSLFntRDZamGSe().ToJsonString();
		}
		catch (Exception ex)
		{
			Logger.LogWarning("Error writing " + GetType().Name + " to JSON. " + ex.Message);
			return string.Empty;
		}
	}

	public ControllerTemplateMap ToControllerTemplateMap(Guid templateTypeGuid)
	{
		if (ReInput._id != XTCjmLKuHDyBHCdnAHQddPuHUPTo)
		{
			ReInput.CheckInitialized(XTCjmLKuHDyBHCdnAHQddPuHUPTo);
			return null;
		}
		if (controller == null)
		{
			Logger.LogError("The Controller Map is not associated with a Controller. This method can only be used with a Controller Map that is associated with a Controller.", requiredThreadSafety: true);
			return null;
		}
		IControllerTemplate controllerTemplate = controller.GetTemplate(templateTypeGuid) ?? (controller.GetTemplate(templateTypeGuid) as ControllerTemplate);
		if (controllerTemplate == null)
		{
			iaIUVVeHlIHTbKHbIuOgJotHxcqD iaIUVVeHlIHTbKHbIuOgJotHxcqD2 = ReInput.XtiXdGauTVLmWDzraWhhHISljycG(templateTypeGuid);
			string text = ((iaIUVVeHlIHTbKHbIuOgJotHxcqD2 != null) ? iaIUVVeHlIHTbKHbIuOgJotHxcqD2.KstOxEjzNrBKlglxBqQZWoKoCmqR() : templateTypeGuid.ToString());
			Logger.LogError("The Controller does not implement " + text + ".", requiredThreadSafety: true);
			return null;
		}
		return ControllerTemplateMap.CjBzsfUiVEzUcOKspuVkWojfQfmr(controllerTemplate, this);
	}

	public ControllerTemplateMap ToControllerTemplateMap<T>() where T : class
	{
		return ToControllerTemplateMap(typeof(T));
	}

	public ControllerTemplateMap ToControllerTemplateMap(Type templateInterfaceType)
	{
		if (ReInput._id != XTCjmLKuHDyBHCdnAHQddPuHUPTo)
		{
			ReInput.CheckInitialized(XTCjmLKuHDyBHCdnAHQddPuHUPTo);
			return null;
		}
		if (templateInterfaceType == null)
		{
			throw new ArgumentNullException("templateInterfaceType");
		}
		if (controller == null)
		{
			Logger.LogError("The Controller Map is not associated with a Controller. This method can only be used with a Controller Map that is associated with a Controller.", requiredThreadSafety: true);
			return null;
		}
		IControllerTemplate controllerTemplate = controller.GetTemplate(templateInterfaceType) ?? (controller.GetTemplate(templateInterfaceType) as ControllerTemplate);
		if (controllerTemplate == null)
		{
			Logger.LogError("The Controller does not implement " + templateInterfaceType.Name + ".", requiredThreadSafety: true);
			return null;
		}
		return ControllerTemplateMap.CjBzsfUiVEzUcOKspuVkWojfQfmr(controllerTemplate, this);
	}

	private ControllerTemplateMap lJXhDaDNHTljWXTmsLkYGMnVdLCe(IControllerTemplate P_0)
	{
		if (ReInput._id != XTCjmLKuHDyBHCdnAHQddPuHUPTo)
		{
			ReInput.CheckInitialized(XTCjmLKuHDyBHCdnAHQddPuHUPTo);
			return null;
		}
		if (P_0 == null)
		{
			throw new ArgumentNullException("controllerTemplate");
		}
		return ControllerTemplateMap.CjBzsfUiVEzUcOKspuVkWojfQfmr(P_0, this);
	}

	internal AList<ActionElementMap> hycZGsxqYWqTYWkWVVCDVrvexwwT()
	{
		return fsfgfURoXdRGlcXBSbnalDeYMNiB;
	}

	internal virtual bool gJwAODjSUWHoAFipcrtCuEWnsrOyb(ActionElementMap P_0)
	{
		if (!aODoMkHKRRYelZwmsAjLTtAJKbWb(P_0._elementType))
		{
			return false;
		}
		tVtLzuBzPyphVHDgadSpbMqQILHLA(P_0);
		return true;
	}

	internal virtual int ElNffPfXNwpFTQXfZcqhRXnLVlPu(List<ActionElementMap> P_0, bool P_1)
	{
		if (P_0 == null)
		{
			throw new ArgumentNullException("results");
		}
		int count = P_0.Count;
		int count2 = fsfgfURoXdRGlcXBSbnalDeYMNiB.get_Count();
		for (int i = 0; i < count2; i++)
		{
			if (!P_1 || fsfgfURoXdRGlcXBSbnalDeYMNiB.get_Item(i).YbgQyWQdQcTTSlKYNScpqBbjmQQo)
			{
				P_0.Add(fsfgfURoXdRGlcXBSbnalDeYMNiB.get_Item(i));
			}
		}
		return P_0.Count - count;
	}

	internal virtual ActionElementMap fCvSNupNTfBFLaimCMmXxnYJuVwM(int P_0, int P_1, ControllerElementType P_2)
	{
		if (!aODoMkHKRRYelZwmsAjLTtAJKbWb(P_2))
		{
			return null;
		}
		int num = TQbDoqoefRtDhbCuyEEOjiBmeLiB(P_0, P_1, P_2);
		if (num < 0)
		{
			return null;
		}
		return fsfgfURoXdRGlcXBSbnalDeYMNiB.get_Item(num);
	}

	internal virtual int QhQSwEziCmAqgVrQqfOqIbjphfbS(int P_0, List<ActionElementMap> P_1, bool P_2)
	{
		if (P_1 == null)
		{
			throw new ArgumentNullException("results");
		}
		int num = 0;
		if (!P_2)
		{
			P_1.Clear();
		}
		else
		{
			num = P_1.Count;
		}
		if (fsfgfURoXdRGlcXBSbnalDeYMNiB == null)
		{
			return 0;
		}
		int num2 = buttonMapCount;
		for (int i = 0; i < num2; i++)
		{
			if (fsfgfURoXdRGlcXBSbnalDeYMNiB.get_Item(i)._elementIdentifierId == P_0)
			{
				P_1.Add(fsfgfURoXdRGlcXBSbnalDeYMNiB.get_Item(i));
			}
		}
		return P_1.Count - num;
	}

	internal virtual bool HIETAHIdGnhJitAYIcswwoDpiFsC(int P_0, int P_1, ControllerElementType P_2)
	{
		if (!aODoMkHKRRYelZwmsAjLTtAJKbWb(P_2))
		{
			return false;
		}
		int num = buttonMapCount;
		for (int i = 0; i < num; i++)
		{
			if (fsfgfURoXdRGlcXBSbnalDeYMNiB.get_Item(i)._elementIdentifierId == P_0 && fsfgfURoXdRGlcXBSbnalDeYMNiB.get_Item(i)._actionId == P_1)
			{
				return true;
			}
		}
		return false;
	}

	internal virtual int TQbDoqoefRtDhbCuyEEOjiBmeLiB(int P_0, int P_1, ControllerElementType P_2)
	{
		if (!aODoMkHKRRYelZwmsAjLTtAJKbWb(P_2))
		{
			return -1;
		}
		if (fsfgfURoXdRGlcXBSbnalDeYMNiB == null)
		{
			return -1;
		}
		int num = buttonMapCount;
		for (int i = 0; i < num; i++)
		{
			if (fsfgfURoXdRGlcXBSbnalDeYMNiB.get_Item(i)._elementIdentifierId == P_0 && fsfgfURoXdRGlcXBSbnalDeYMNiB.get_Item(i)._actionId == P_1)
			{
				return i;
			}
		}
		return -1;
	}

	internal int sWNZoKRUStTTVbUqDZSHArqAahEF(int P_0)
	{
		if (fsfgfURoXdRGlcXBSbnalDeYMNiB == null)
		{
			return -1;
		}
		int num = buttonMapCount;
		for (int i = 0; i < num; i++)
		{
			if (fsfgfURoXdRGlcXBSbnalDeYMNiB.get_Item(i).LQceMJAxYgRpolrwLwsLBxilJMmNA == P_0)
			{
				return i;
			}
		}
		return -1;
	}

	internal int GqmiSQTLexTrgoMnXjZdwXCPbqPAA(bool P_0, List<ActionElementMap> P_1, bool P_2)
	{
		if (P_1 == null)
		{
			throw new ArgumentNullException("results");
		}
		if (!P_2)
		{
			P_1.Clear();
		}
		int num = buttonMapCount;
		int num2 = 0;
		for (int i = 0; i < num; i++)
		{
			ActionElementMap actionElementMap = fsfgfURoXdRGlcXBSbnalDeYMNiB.get_Item(i);
			if (!P_0 || actionElementMap.YbgQyWQdQcTTSlKYNScpqBbjmQQo)
			{
				P_1.Add(actionElementMap);
				num2++;
			}
		}
		return num2;
	}

	internal int McklfRwAeXVOuqClaWFCiKesBkgI(int P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
	{
		if (P_2 == null)
		{
			throw new ArgumentNullException("results");
		}
		if (!P_3)
		{
			P_2.Clear();
		}
		int num = buttonMapCount;
		if (num == 0)
		{
			return 0;
		}
		int num2 = 0;
		for (int i = 0; i < num; i++)
		{
			ActionElementMap actionElementMap = fsfgfURoXdRGlcXBSbnalDeYMNiB.get_Item(i);
			if (actionElementMap._actionId == P_0 && (!P_1 || actionElementMap.YbgQyWQdQcTTSlKYNScpqBbjmQQo))
			{
				P_2.Add(actionElementMap);
				num2++;
			}
		}
		return num2;
	}

	internal virtual int udqxaEGIrvufGdIfXccpPRDnNltr(int P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
	{
		if (P_2 == null)
		{
			throw new ArgumentNullException("results");
		}
		if (!P_3)
		{
			P_2.Clear();
		}
		if (P_0 < 0)
		{
			return 0;
		}
		int num = 0;
		int num2 = buttonMapCount;
		for (int i = 0; i < num2; i++)
		{
			ActionElementMap actionElementMap = fsfgfURoXdRGlcXBSbnalDeYMNiB.get_Item(i);
			if (actionElementMap._actionId == P_0 && (!P_1 || actionElementMap.YbgQyWQdQcTTSlKYNScpqBbjmQQo))
			{
				P_2.Add(actionElementMap);
				num++;
			}
		}
		return num;
	}

	internal virtual ActionElementMap rWGkzCaHmFroxLHHiILXPuevKYvo(IControllerElementTarget P_0, bool P_1, int P_2, bool P_3, out bool P_4)
	{
		P_4 = false;
		if (P_1 && P_2 < 0)
		{
			P_4 = true;
			return null;
		}
		if (!aiAhiudYWGgrpSNkdVFoWOpROJxMA(P_0))
		{
			P_4 = true;
			return null;
		}
		if (!aODoMkHKRRYelZwmsAjLTtAJKbWb(P_0.elementType))
		{
			return null;
		}
		int num = buttonMapCount;
		_ = P_0.elementIdentifierId;
		for (int i = 0; i < num; i++)
		{
			if ((!P_1 || fsfgfURoXdRGlcXBSbnalDeYMNiB.get_Item(i)._actionId == P_2) && (!P_3 || fsfgfURoXdRGlcXBSbnalDeYMNiB.get_Item(i).YbgQyWQdQcTTSlKYNScpqBbjmQQo) && fsfgfURoXdRGlcXBSbnalDeYMNiB.get_Item(i).IsTarget(P_0))
			{
				return fsfgfURoXdRGlcXBSbnalDeYMNiB.get_Item(i);
			}
		}
		return null;
	}

	internal virtual int AQsAVNZYhsajiONJBaCUyUaUYtSD(IControllerElementTarget P_0, bool P_1, int P_2, bool P_3, List<ActionElementMap> P_4, bool P_5, out bool P_6)
	{
		if (P_4 == null)
		{
			throw new ArgumentNullException("results");
		}
		int num = 0;
		if (!P_5)
		{
			P_4.Clear();
		}
		P_6 = false;
		if (P_1 && P_2 < 0)
		{
			P_6 = true;
			return num;
		}
		if (!aiAhiudYWGgrpSNkdVFoWOpROJxMA(P_0))
		{
			P_6 = true;
			return num;
		}
		if (!aODoMkHKRRYelZwmsAjLTtAJKbWb(P_0.elementType))
		{
			return num;
		}
		int num2 = buttonMapCount;
		_ = P_0.elementIdentifierId;
		for (int i = 0; i < num2; i++)
		{
			if ((!P_1 || fsfgfURoXdRGlcXBSbnalDeYMNiB.get_Item(i)._actionId == P_2) && (!P_3 || fsfgfURoXdRGlcXBSbnalDeYMNiB.get_Item(i).YbgQyWQdQcTTSlKYNScpqBbjmQQo) && fsfgfURoXdRGlcXBSbnalDeYMNiB.get_Item(i).IsTarget(P_0))
			{
				P_4.Add(fsfgfURoXdRGlcXBSbnalDeYMNiB.get_Item(i));
				num++;
			}
		}
		return num;
	}

	internal void pMJpISGNYrPwmItXVyxnSbnhxSrD(int P_0, ControllerElementType P_1)
	{
		ActionElementMap elementMap = GetElementMap(P_0);
		if (elementMap != null && elementMap._elementType != P_1)
		{
			elementMap._elementType = P_1;
			if (P_1 == ControllerElementType.Button)
			{
				elementMap._axisRange = AxisRange.Full;
				elementMap._invert = false;
			}
			DeleteElementMap(P_0);
			deQaZFBOpCgNWqniRMdLrzJdixNM(elementMap);
		}
	}

	internal virtual bool deQaZFBOpCgNWqniRMdLrzJdixNM(ActionElementMap P_0)
	{
		if (P_0 == null)
		{
			return false;
		}
		if (!aODoMkHKRRYelZwmsAjLTtAJKbWb(P_0._elementType))
		{
			return false;
		}
		fsfgfURoXdRGlcXBSbnalDeYMNiB.Add(P_0);
		nQzXEGXyrsNYEgyMbuxNvTkiZloL(P_0);
		return true;
	}

	internal bool aiAhiudYWGgrpSNkdVFoWOpROJxMA(IControllerElementTarget P_0)
	{
		if (P_0 == null)
		{
			return false;
		}
		Controller controller = P_0.controller;
		if (controller == null || controller.type != _controllerType || controller.id != _controllerId)
		{
			return false;
		}
		return true;
	}

	internal bool gdHGbQKZjfjgtBVKXQKgALHiHuNXA(string P_0)
	{
		try
		{
			uqZbaxHuqiqBimqckBuyQZOOGZv(SerializedObject.FromXml(GetType(), P_0));
			return true;
		}
		catch (Exception ex)
		{
			Logger.LogError("Error creating  " + GetType().Name + "  from XML. " + ex.Message);
			return false;
		}
	}

	internal bool VNMyQDOFwWgRFlcSlmPsLWmMGTSb(string P_0)
	{
		try
		{
			uqZbaxHuqiqBimqckBuyQZOOGZv(SerializedObject.FromJson(GetType(), P_0));
			return true;
		}
		catch (Exception ex)
		{
			Logger.LogError("Error creating  " + GetType().Name + "  from JSON. " + ex.Message);
			return false;
		}
	}

	internal void nQzXEGXyrsNYEgyMbuxNvTkiZloL(ActionElementMap P_0)
	{
		if (P_0 != null)
		{
			QbAaitvGUaSWYrRcFrSSnhbxlRiu.Add(P_0);
			QbAaitvGUaSWYrRcFrSSnhbxlRiu.Sort(wDWpAgKhmAHViWLIVRwrZXKHdOjF.qUrHDdPSLOgGvPzcqwjCxMRVGMCFA());
		}
	}

	internal void dTxetHHpwSYSVITeJpRmHqGvpYKC(int P_0)
	{
		int num = yxezxNEIjpwoDWzeihoLtjQubimdA(P_0);
		if (num >= 0)
		{
			QbAaitvGUaSWYrRcFrSSnhbxlRiu.RemoveAt(num);
		}
	}

	internal void DabGVqGkjVCrAaZUoMmtihRKqztiA(int P_0, ActionElementMap P_1)
	{
		if (P_1 != null)
		{
			int num = yxezxNEIjpwoDWzeihoLtjQubimdA(P_0);
			if (num >= 0)
			{
				QbAaitvGUaSWYrRcFrSSnhbxlRiu.set_Item(num, P_1);
				QbAaitvGUaSWYrRcFrSSnhbxlRiu.Sort(wDWpAgKhmAHViWLIVRwrZXKHdOjF.qUrHDdPSLOgGvPzcqwjCxMRVGMCFA());
			}
		}
	}

	internal static void bscxZCAoNJMLdkUKriUgtlzjeUaS(ActionElementMap P_0, int P_1, Pole P_2, int P_3, ControllerElementType P_4, AxisRange P_5, bool P_6)
	{
		P_0.HqYMVTpUQlRYCgKqNbTFekEMDmBc();
		P_0._actionId = P_1;
		P_0._elementType = P_4;
		P_0._elementIdentifierId = P_3;
		P_0._axisContribution = P_2;
		P_0._axisRange = P_5;
		if (P_4 == ControllerElementType.Axis)
		{
			P_0._invert = P_6;
		}
	}

	protected void BakeElementMap(ActionElementMap map)
	{
		if (map != null)
		{
			ReInput.controllers.GetController(_controllerType, _controllerId)?.fGQOtKpVEJmrMXNYeONgsnXNwkIC(this, map);
		}
	}

	internal virtual bool uqZbaxHuqiqBimqckBuyQZOOGZv(SerializedObject P_0)
	{
		bool flag = false;
		_sourceMapId = -1;
		_categoryId = -1;
		_layoutId = -1;
		_name = string.Empty;
		_hardwareGuid = Guid.Empty;
		_enabled = true;
		P_0.TryGetDeserializedValueByRef("sourceMapId", ref _sourceMapId);
		P_0.TryGetDeserializedValueByRef("categoryId", ref _categoryId);
		P_0.TryGetDeserializedValueByRef("layoutId", ref _layoutId);
		P_0.TryGetDeserializedValueByRef("name", ref _name);
		P_0.TryGetDeserializedValueByRef("hardwareGuid", ref _hardwareGuid);
		P_0.TryGetDeserializedValueByRef("enabled", ref _enabled);
		if (!flag)
		{
			ClearElementMaps();
			flag = true;
		}
		SerializedObject value = null;
		if (P_0.TryGetDeserializedValueByRef("buttonMaps", ref value) && value != null)
		{
			for (int i = 0; i < value.count; i++)
			{
				if (value.TryGetDeserializedValue<SerializedObject>(i, out var value2) || value2 == null)
				{
					ActionElementMap actionElementMap = new ActionElementMap();
					actionElementMap.TuhwQSoJBLXzpOCVRndSVrhfkUhT(value2);
					if (ActionElementMap.RduNEuGTbuBDPjdvcnEmZyZvhVty(actionElementMap))
					{
						tVtLzuBzPyphVHDgadSpbMqQILHLA(actionElementMap);
					}
				}
			}
		}
		return flag;
	}

	internal virtual void BNpIdecNpOvclDkjTvyqXJeXbzNe(SerializedObject P_0)
	{
		if (P_0.xmlInfo == null)
		{
			P_0.xmlInfo = new SerializedObject.XmlInfo();
		}
		P_0.Add("dataVersion", 2, SerializedObject.FieldOptions.ExculdeFromXml);
		P_0.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.hDUwNfLYRsDfBMVYhNNeoTRkzGbG
		{
			MutqyAFuCjIZnSTNtUBAVEJnuQVU = "dataVersion",
			TGWZwlpMZfNRNCdsoptLnolSpctw = 2.ToString()
		});
		if ((object)GetType() == typeof(JoystickMap))
		{
			Joystick joystick = ReInput.controllers.GetJoystick(_controllerId);
			Guid guid = joystick?.hardwareTypeGuid ?? Guid.Empty;
			string tGWZwlpMZfNRNCdsoptLnolSpctw = ((joystick != null) ? SerializationTools.CleanInvalidXmlChars(joystick.hardwareName) : "Unknown");
			P_0.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.hDUwNfLYRsDfBMVYhNNeoTRkzGbG
			{
				MutqyAFuCjIZnSTNtUBAVEJnuQVU = "hardwareGuid",
				TGWZwlpMZfNRNCdsoptLnolSpctw = guid.ToString()
			});
			P_0.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.hDUwNfLYRsDfBMVYhNNeoTRkzGbG
			{
				MutqyAFuCjIZnSTNtUBAVEJnuQVU = "hardwareName",
				TGWZwlpMZfNRNCdsoptLnolSpctw = tGWZwlpMZfNRNCdsoptLnolSpctw
			});
		}
		P_0.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.hDUwNfLYRsDfBMVYhNNeoTRkzGbG
		{
			lzZvWcSBFLIaPeQCcDYWrLhMPUfsA = "xmlns",
			MutqyAFuCjIZnSTNtUBAVEJnuQVU = "xsi",
			afJFISBmEARIUnwOMVvxEtRhSwGz = null,
			TGWZwlpMZfNRNCdsoptLnolSpctw = "http://www.w3.org/2001/XMLSchema-instance"
		});
		P_0.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.hDUwNfLYRsDfBMVYhNNeoTRkzGbG
		{
			lzZvWcSBFLIaPeQCcDYWrLhMPUfsA = "xsi",
			MutqyAFuCjIZnSTNtUBAVEJnuQVU = "schemaLocation",
			afJFISBmEARIUnwOMVvxEtRhSwGz = null,
			TGWZwlpMZfNRNCdsoptLnolSpctw = string.Format("{0} {1}{2}{3}{4}{5}", "http://guavaman.com/rewired", "http://guavaman.com/schemas/rewired/", "1.1", "/", GetType().Name, ".xsd")
		});
		P_0.Add("sourceMapId", _sourceMapId);
		P_0.Add("categoryId", _categoryId);
		P_0.Add("layoutId", _layoutId);
		P_0.Add("name", _name);
		P_0.Add("hardwareGuid", _hardwareGuid);
		P_0.Add("enabled", _enabled);
		int num = buttonMapCount;
		List<object> list = new List<object>();
		P_0.Add("buttonMaps", list);
		for (int i = 0; i < num; i++)
		{
			if (fsfgfURoXdRGlcXBSbnalDeYMNiB.get_Item(i) != null)
			{
				list.Add(fsfgfURoXdRGlcXBSbnalDeYMNiB.get_Item(i).PZscFcCQiIyEnvscKrVjbjPwaven());
			}
		}
	}

	private bool aODoMkHKRRYelZwmsAjLTtAJKbWb(ControllerElementType P_0)
	{
		if (P_0 != ControllerElementType.Button)
		{
			return false;
		}
		return true;
	}

	private void xPDpwubZeRwFkRocGwDPfBgdGxHY(int P_0, int P_1)
	{
		dTxetHHpwSYSVITeJpRmHqGvpYKC(P_0);
		if (P_1 >= 0 && P_1 < buttonMapCount)
		{
			fsfgfURoXdRGlcXBSbnalDeYMNiB.RemoveAt(P_1);
		}
	}

	private void tVtLzuBzPyphVHDgadSpbMqQILHLA(ActionElementMap P_0)
	{
		if (P_0 != null)
		{
			fsfgfURoXdRGlcXBSbnalDeYMNiB.Add(P_0);
			nQzXEGXyrsNYEgyMbuxNvTkiZloL(P_0);
		}
	}

	private void ElvEtuHRXwtOBtXnjcWpvmyeuGjhA(ActionElementMap P_0, int P_1)
	{
		if (P_0 != null && P_1 >= 0 && P_1 < buttonMapCount)
		{
			DabGVqGkjVCrAaZUoMmtihRKqztiA(fsfgfURoXdRGlcXBSbnalDeYMNiB.get_Item(P_1).LQceMJAxYgRpolrwLwsLBxilJMmNA, P_0);
			fsfgfURoXdRGlcXBSbnalDeYMNiB.set_Item(P_1, P_0);
		}
	}

	private int yxezxNEIjpwoDWzeihoLtjQubimdA(int P_0)
	{
		if (QbAaitvGUaSWYrRcFrSSnhbxlRiu == null)
		{
			return -1;
		}
		int count = QbAaitvGUaSWYrRcFrSSnhbxlRiu.get_Count();
		for (int i = 0; i < count; i++)
		{
			if (QbAaitvGUaSWYrRcFrSSnhbxlRiu.get_Item(i).LQceMJAxYgRpolrwLwsLBxilJMmNA == P_0)
			{
				return i;
			}
		}
		return -1;
	}

	private SerializedObject TsDSXqnoFXrRznuSLFntRDZamGSe()
	{
		SerializedObject serializedObject = new SerializedObject(GetType(), SerializedObject.ObjectType.Object);
		BNpIdecNpOvclDkjTvyqXJeXbzNe(serializedObject);
		return serializedObject;
	}

	internal static ControllerMap DzOeBfwddcwwENIIeCxWFIebOvPE(ControllerType P_0)
	{
		return P_0 switch
		{
			ControllerType.Keyboard => new KeyboardMap(), 
			ControllerType.Mouse => new MouseMap(), 
			ControllerType.Joystick => new JoystickMap(), 
			ControllerType.Custom => new CustomControllerMap(), 
			_ => throw new NotImplementedException(), 
		};
	}

	internal static ControllerMap otvNzBmtghLoMTaGshuqrkxuHQy(Controller P_0, int P_1, int P_2)
	{
		if (P_0 == null)
		{
			return null;
		}
		return P_0.type switch
		{
			ControllerType.Keyboard => KeyboardMap.fRSVATzHkdCdhhcKeooAqWYqhxldA(P_0.hardwareTypeGuid, P_1, P_2), 
			ControllerType.Mouse => MouseMap.dcKtXifClTEovMYRHgGHohQtjlSW(P_0.hardwareTypeGuid, P_1, P_2), 
			ControllerType.Joystick => JoystickMap.tOvGYsbvbFtBBpUsNFknIToZXDoSA(P_0.hardwareTypeGuid, P_1, P_2), 
			ControllerType.Custom => CustomControllerMap.eGZluOOwUVDgGSnbBOXNpfAeERvg(P_0.hardwareTypeGuid, ((CustomController)P_0).sourceControllerId, P_1, P_2), 
			_ => throw new NotImplementedException(), 
		};
	}

	public static ControllerMap CreateFromXml(ControllerType controllerType, string xmlString)
	{
		if (string.IsNullOrEmpty(xmlString))
		{
			return null;
		}
		ControllerMap controllerMap = DzOeBfwddcwwENIIeCxWFIebOvPE(controllerType);
		try
		{
			controllerMap.gdHGbQKZjfjgtBVKXQKgALHiHuNXA(xmlString);
			return controllerMap;
		}
		catch
		{
			return null;
		}
	}

	public static ControllerMap CreateFromJson(ControllerType controllerType, string jsonString)
	{
		if (string.IsNullOrEmpty(jsonString))
		{
			return null;
		}
		ControllerMap controllerMap = DzOeBfwddcwwENIIeCxWFIebOvPE(controllerType);
		try
		{
			controllerMap.VNMyQDOFwWgRFlcSlmPsLWmMGTSb(jsonString);
			return controllerMap;
		}
		catch
		{
			return null;
		}
	}
}
