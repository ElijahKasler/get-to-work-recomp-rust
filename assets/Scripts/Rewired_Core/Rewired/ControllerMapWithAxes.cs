using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;

namespace Rewired;

public abstract class ControllerMapWithAxes : ControllerMap
{
	private sealed class HobnldBbVQUvuyNyAuzfwyuVrvEG : IEnumerable<ActionElementMap>, IEnumerable, IEnumerator<ActionElementMap>, IEnumerator, IDisposable
	{
		private int bzjZScKzrzVosLpncLWPxchJiTRfA;

		private ActionElementMap CYjveUBYSENNrziRZleZJFxRHcbf;

		private int NhdDzjiSPrjApHRdgLpbXEVTwYsAb;

		public ControllerMapWithAxes IbOuevbPWZAlMuMtgUUvyRHPGDvx;

		private int dCTzzsEBzqqAiyohOmuxUIUKHkaE;

		public int ANiTvSoMaYeRKjYuQeXbJKglKZStA;

		private bool PgqnaDvVrUIjmIuxQiEOexzAnev;

		public bool COOAjgDOwFxQoexsbJRCxHhJPkMl;

		private IEnumerator<ActionElementMap> bMIMaIVsrYFmOVRfBtROEKiHuKS;

		ActionElementMap IEnumerator<ActionElementMap>.Current
		{
			[DebuggerHidden]
			get
			{
				return CYjveUBYSENNrziRZleZJFxRHcbf;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return CYjveUBYSENNrziRZleZJFxRHcbf;
			}
		}

		[DebuggerHidden]
		public HobnldBbVQUvuyNyAuzfwyuVrvEG(int P_0)
		{
			bzjZScKzrzVosLpncLWPxchJiTRfA = P_0;
			NhdDzjiSPrjApHRdgLpbXEVTwYsAb = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			int num = bzjZScKzrzVosLpncLWPxchJiTRfA;
			if (num == -3 || num == 1)
			{
				try
				{
				}
				finally
				{
					NZdOjVlEvnTtKGfQhQfFcSYuaaCaA();
				}
			}
		}

		private bool MoveNext()
		{
			try
			{
				int num = bzjZScKzrzVosLpncLWPxchJiTRfA;
				ControllerMapWithAxes ibOuevbPWZAlMuMtgUUvyRHPGDvx = IbOuevbPWZAlMuMtgUUvyRHPGDvx;
				switch (num)
				{
				default:
					return false;
				case 0:
					bzjZScKzrzVosLpncLWPxchJiTRfA = -1;
					if (ReInput._id != ibOuevbPWZAlMuMtgUUvyRHPGDvx.XTCjmLKuHDyBHCdnAHQddPuHUPTo)
					{
						ReInput.CheckInitialized(ibOuevbPWZAlMuMtgUUvyRHPGDvx.XTCjmLKuHDyBHCdnAHQddPuHUPTo);
						return false;
					}
					if (dCTzzsEBzqqAiyohOmuxUIUKHkaE < 0)
					{
						return false;
					}
					bMIMaIVsrYFmOVRfBtROEKiHuKS = ibOuevbPWZAlMuMtgUUvyRHPGDvx.AxisMaps.GetEnumerator();
					bzjZScKzrzVosLpncLWPxchJiTRfA = -3;
					break;
				case 1:
					bzjZScKzrzVosLpncLWPxchJiTRfA = -3;
					break;
				}
				while (bMIMaIVsrYFmOVRfBtROEKiHuKS.MoveNext())
				{
					ActionElementMap current = bMIMaIVsrYFmOVRfBtROEKiHuKS.Current;
					if (current._actionId == dCTzzsEBzqqAiyohOmuxUIUKHkaE && (!PgqnaDvVrUIjmIuxQiEOexzAnev || current.YbgQyWQdQcTTSlKYNScpqBbjmQQo))
					{
						CYjveUBYSENNrziRZleZJFxRHcbf = current;
						bzjZScKzrzVosLpncLWPxchJiTRfA = 1;
						return true;
					}
				}
				NZdOjVlEvnTtKGfQhQfFcSYuaaCaA();
				bMIMaIVsrYFmOVRfBtROEKiHuKS = null;
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

		private void NZdOjVlEvnTtKGfQhQfFcSYuaaCaA()
		{
			bzjZScKzrzVosLpncLWPxchJiTRfA = -1;
			if (bMIMaIVsrYFmOVRfBtROEKiHuKS != null)
			{
				bMIMaIVsrYFmOVRfBtROEKiHuKS.Dispose();
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
			HobnldBbVQUvuyNyAuzfwyuVrvEG hobnldBbVQUvuyNyAuzfwyuVrvEG;
			if (bzjZScKzrzVosLpncLWPxchJiTRfA == -2 && NhdDzjiSPrjApHRdgLpbXEVTwYsAb == Environment.CurrentManagedThreadId)
			{
				bzjZScKzrzVosLpncLWPxchJiTRfA = 0;
				hobnldBbVQUvuyNyAuzfwyuVrvEG = this;
			}
			else
			{
				hobnldBbVQUvuyNyAuzfwyuVrvEG = new HobnldBbVQUvuyNyAuzfwyuVrvEG(0);
				hobnldBbVQUvuyNyAuzfwyuVrvEG.IbOuevbPWZAlMuMtgUUvyRHPGDvx = IbOuevbPWZAlMuMtgUUvyRHPGDvx;
			}
			hobnldBbVQUvuyNyAuzfwyuVrvEG.dCTzzsEBzqqAiyohOmuxUIUKHkaE = ANiTvSoMaYeRKjYuQeXbJKglKZStA;
			hobnldBbVQUvuyNyAuzfwyuVrvEG.PgqnaDvVrUIjmIuxQiEOexzAnev = COOAjgDOwFxQoexsbJRCxHhJPkMl;
			return hobnldBbVQUvuyNyAuzfwyuVrvEG;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
		}
	}

	private sealed class FmqRLxhXKLUZfijNJnwlsYYOtixs : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
	{
		private int JoYqfqWiHkDtHFuaIjaDIiDXneeoA;

		private ElementAssignmentConflictInfo sfwCJOCwQajlSLAJkPruhwyjoXGU;

		private int YvWGuSNPPptwCwQrmEQRfvRXnhjm;

		public ControllerMapWithAxes LZqLqimmzgdWMXgPDrlqANPqGiYkA;

		private ControllerMap fWCXQZBtZMMmIOZJWeDDvTOoHiEW;

		public ControllerMap OOAGpHRpKOmJFIFYQPPVdgFhBIXq;

		private bool RyVIojOcOFjZzbmgOcqeCdjtCPbq;

		public bool yiWgPZxdtqqKbHjDwasYNrBikSCB;

		private IList<ActionElementMap> OXLieiseqfkCmaBYBrJNNYzsdwz;

		private int ZLlcwmGauhmvOxzqjzvoygHRaNqD;

		private IEnumerator<ElementAssignmentConflictInfo> FyLYSvufojbsARmwgcKtfajugTlZA;

		private int aeOtMzCYYBBwOfXDToQGPsAaGsZX;

		private ActionElementMap sJYmWEbSFYmBeotvkzRhUEyJwfpF;

		private int WDZUAsdRnSAzgeRvOmmguwoZstWt;

		ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
		{
			[DebuggerHidden]
			get
			{
				return sfwCJOCwQajlSLAJkPruhwyjoXGU;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return sfwCJOCwQajlSLAJkPruhwyjoXGU;
			}
		}

		[DebuggerHidden]
		public FmqRLxhXKLUZfijNJnwlsYYOtixs(int P_0)
		{
			JoYqfqWiHkDtHFuaIjaDIiDXneeoA = P_0;
			YvWGuSNPPptwCwQrmEQRfvRXnhjm = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			int joYqfqWiHkDtHFuaIjaDIiDXneeoA = JoYqfqWiHkDtHFuaIjaDIiDXneeoA;
			if (joYqfqWiHkDtHFuaIjaDIiDXneeoA == -3 || joYqfqWiHkDtHFuaIjaDIiDXneeoA == 1)
			{
				try
				{
				}
				finally
				{
					OxWdYamSOYHtJHTRUdOeHTTIFQDWB();
				}
			}
		}

		private bool MoveNext()
		{
			try
			{
				int joYqfqWiHkDtHFuaIjaDIiDXneeoA = JoYqfqWiHkDtHFuaIjaDIiDXneeoA;
				ControllerMapWithAxes lZqLqimmzgdWMXgPDrlqANPqGiYkA = LZqLqimmzgdWMXgPDrlqANPqGiYkA;
				switch (joYqfqWiHkDtHFuaIjaDIiDXneeoA)
				{
				default:
					return false;
				case 0:
					JoYqfqWiHkDtHFuaIjaDIiDXneeoA = -1;
					if (ReInput._id != lZqLqimmzgdWMXgPDrlqANPqGiYkA.XTCjmLKuHDyBHCdnAHQddPuHUPTo)
					{
						ReInput.CheckInitialized(lZqLqimmzgdWMXgPDrlqANPqGiYkA.XTCjmLKuHDyBHCdnAHQddPuHUPTo);
						return false;
					}
					if (fWCXQZBtZMMmIOZJWeDDvTOoHiEW == null)
					{
						return false;
					}
					FyLYSvufojbsARmwgcKtfajugTlZA = ((ControllerMap)lZqLqimmzgdWMXgPDrlqANPqGiYkA).ElementAssignmentConflicts(fWCXQZBtZMMmIOZJWeDDvTOoHiEW, RyVIojOcOFjZzbmgOcqeCdjtCPbq).GetEnumerator();
					JoYqfqWiHkDtHFuaIjaDIiDXneeoA = -3;
					goto IL_00af;
				case 1:
					JoYqfqWiHkDtHFuaIjaDIiDXneeoA = -3;
					goto IL_00af;
				case 2:
					{
						JoYqfqWiHkDtHFuaIjaDIiDXneeoA = -1;
						goto IL_0232;
					}
					IL_0244:
					if (WDZUAsdRnSAzgeRvOmmguwoZstWt < ZLlcwmGauhmvOxzqjzvoygHRaNqD)
					{
						ActionElementMap actionElementMap = OXLieiseqfkCmaBYBrJNNYzsdwz[WDZUAsdRnSAzgeRvOmmguwoZstWt];
						if ((!RyVIojOcOFjZzbmgOcqeCdjtCPbq || actionElementMap.YbgQyWQdQcTTSlKYNScpqBbjmQQo) && sJYmWEbSFYmBeotvkzRhUEyJwfpF.CheckForAssignmentConflict(actionElementMap))
						{
							sfwCJOCwQajlSLAJkPruhwyjoXGU = new ElementAssignmentConflictInfo(true, ReInput.mapping.GetMapCategory(lZqLqimmzgdWMXgPDrlqANPqGiYkA._categoryId).userAssignable, -1, lZqLqimmzgdWMXgPDrlqANPqGiYkA._controllerType, lZqLqimmzgdWMXgPDrlqANPqGiYkA._controllerId, lZqLqimmzgdWMXgPDrlqANPqGiYkA._id, sJYmWEbSFYmBeotvkzRhUEyJwfpF.LQceMJAxYgRpolrwLwsLBxilJMmNA, sJYmWEbSFYmBeotvkzRhUEyJwfpF._actionId, sJYmWEbSFYmBeotvkzRhUEyJwfpF._elementType, sJYmWEbSFYmBeotvkzRhUEyJwfpF._elementIdentifierId, sJYmWEbSFYmBeotvkzRhUEyJwfpF.keyCode, sJYmWEbSFYmBeotvkzRhUEyJwfpF.modifierKeyFlags);
							JoYqfqWiHkDtHFuaIjaDIiDXneeoA = 2;
							return true;
						}
						goto IL_0232;
					}
					sJYmWEbSFYmBeotvkzRhUEyJwfpF = null;
					goto IL_025c;
					IL_0232:
					WDZUAsdRnSAzgeRvOmmguwoZstWt++;
					goto IL_0244;
					IL_026e:
					if (aeOtMzCYYBBwOfXDToQGPsAaGsZX < lZqLqimmzgdWMXgPDrlqANPqGiYkA.xcxDlZIoeuhvFHVWmLEUTwGyxkKZ.Count)
					{
						sJYmWEbSFYmBeotvkzRhUEyJwfpF = lZqLqimmzgdWMXgPDrlqANPqGiYkA.xcxDlZIoeuhvFHVWmLEUTwGyxkKZ[aeOtMzCYYBBwOfXDToQGPsAaGsZX];
						if (!RyVIojOcOFjZzbmgOcqeCdjtCPbq || sJYmWEbSFYmBeotvkzRhUEyJwfpF.YbgQyWQdQcTTSlKYNScpqBbjmQQo)
						{
							WDZUAsdRnSAzgeRvOmmguwoZstWt = 0;
							goto IL_0244;
						}
						goto IL_025c;
					}
					return false;
					IL_00af:
					if (FyLYSvufojbsARmwgcKtfajugTlZA.MoveNext())
					{
						ElementAssignmentConflictInfo current = FyLYSvufojbsARmwgcKtfajugTlZA.Current;
						sfwCJOCwQajlSLAJkPruhwyjoXGU = current;
						JoYqfqWiHkDtHFuaIjaDIiDXneeoA = 1;
						return true;
					}
					OxWdYamSOYHtJHTRUdOeHTTIFQDWB();
					FyLYSvufojbsARmwgcKtfajugTlZA = null;
					if (!(fWCXQZBtZMMmIOZJWeDDvTOoHiEW is ControllerMapWithAxes controllerMapWithAxes))
					{
						return false;
					}
					if (RyVIojOcOFjZzbmgOcqeCdjtCPbq && (!lZqLqimmzgdWMXgPDrlqANPqGiYkA._enabled || !controllerMapWithAxes._enabled))
					{
						return false;
					}
					OXLieiseqfkCmaBYBrJNNYzsdwz = controllerMapWithAxes.AxisMaps;
					if (OXLieiseqfkCmaBYBrJNNYzsdwz == null)
					{
						return false;
					}
					ZLlcwmGauhmvOxzqjzvoygHRaNqD = OXLieiseqfkCmaBYBrJNNYzsdwz.Count;
					aeOtMzCYYBBwOfXDToQGPsAaGsZX = 0;
					goto IL_026e;
					IL_025c:
					aeOtMzCYYBBwOfXDToQGPsAaGsZX++;
					goto IL_026e;
				}
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

		private void OxWdYamSOYHtJHTRUdOeHTTIFQDWB()
		{
			JoYqfqWiHkDtHFuaIjaDIiDXneeoA = -1;
			if (FyLYSvufojbsARmwgcKtfajugTlZA != null)
			{
				FyLYSvufojbsARmwgcKtfajugTlZA.Dispose();
			}
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		IEnumerator<ElementAssignmentConflictInfo> IEnumerable<ElementAssignmentConflictInfo>.GetEnumerator()
		{
			FmqRLxhXKLUZfijNJnwlsYYOtixs fmqRLxhXKLUZfijNJnwlsYYOtixs;
			if (JoYqfqWiHkDtHFuaIjaDIiDXneeoA == -2 && YvWGuSNPPptwCwQrmEQRfvRXnhjm == Environment.CurrentManagedThreadId)
			{
				JoYqfqWiHkDtHFuaIjaDIiDXneeoA = 0;
				fmqRLxhXKLUZfijNJnwlsYYOtixs = this;
			}
			else
			{
				fmqRLxhXKLUZfijNJnwlsYYOtixs = new FmqRLxhXKLUZfijNJnwlsYYOtixs(0);
				fmqRLxhXKLUZfijNJnwlsYYOtixs.LZqLqimmzgdWMXgPDrlqANPqGiYkA = LZqLqimmzgdWMXgPDrlqANPqGiYkA;
			}
			fmqRLxhXKLUZfijNJnwlsYYOtixs.fWCXQZBtZMMmIOZJWeDDvTOoHiEW = OOAGpHRpKOmJFIFYQPPVdgFhBIXq;
			fmqRLxhXKLUZfijNJnwlsYYOtixs.RyVIojOcOFjZzbmgOcqeCdjtCPbq = yiWgPZxdtqqKbHjDwasYNrBikSCB;
			return fmqRLxhXKLUZfijNJnwlsYYOtixs;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
		}
	}

	private sealed class AJvSZYdsSYctACwCmZfqkKJGjjCJ : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
	{
		private int vYiSjHIoMPMnbFAhZdIxlPJAAjeH;

		private ElementAssignmentConflictInfo LPYQDPMNAKfqGpGqISIdPGljsHd;

		private int QjPTlzLaPHBOAapxzzRqopAAdsBFA;

		public ControllerMapWithAxes aIdxGQPYerxijgojPFBspdQgazNh;

		private ActionElementMap OHuVIjQvpKkRPboXamLecMfoDfkL;

		public ActionElementMap sOkTTUaevBtdaMoYnJibwwroqYbT;

		private bool hPeDnqOuWnocfEMfZNNwhmDjQLTb;

		public bool riACltzoZNjFCkcflGfBsELqkZje;

		private IEnumerator<ElementAssignmentConflictInfo> UllfMWMDcezvhYuNFaxWcrFhmVZE;

		private int llVGOBptOrJOBAZqXDobSyPBmNEG;

		ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
		{
			[DebuggerHidden]
			get
			{
				return LPYQDPMNAKfqGpGqISIdPGljsHd;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return LPYQDPMNAKfqGpGqISIdPGljsHd;
			}
		}

		[DebuggerHidden]
		public AJvSZYdsSYctACwCmZfqkKJGjjCJ(int P_0)
		{
			vYiSjHIoMPMnbFAhZdIxlPJAAjeH = P_0;
			QjPTlzLaPHBOAapxzzRqopAAdsBFA = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			int num = vYiSjHIoMPMnbFAhZdIxlPJAAjeH;
			if (num == -3 || num == 1)
			{
				try
				{
				}
				finally
				{
					CXOaFoPDDwaKqXKiZjMqzXxSsVli();
				}
			}
		}

		private bool MoveNext()
		{
			try
			{
				int num = vYiSjHIoMPMnbFAhZdIxlPJAAjeH;
				ControllerMapWithAxes controllerMapWithAxes = aIdxGQPYerxijgojPFBspdQgazNh;
				switch (num)
				{
				default:
					return false;
				case 0:
					vYiSjHIoMPMnbFAhZdIxlPJAAjeH = -1;
					if (ReInput._id != controllerMapWithAxes.XTCjmLKuHDyBHCdnAHQddPuHUPTo)
					{
						ReInput.CheckInitialized(controllerMapWithAxes.XTCjmLKuHDyBHCdnAHQddPuHUPTo);
						return false;
					}
					if (OHuVIjQvpKkRPboXamLecMfoDfkL == null)
					{
						return false;
					}
					UllfMWMDcezvhYuNFaxWcrFhmVZE = ((ControllerMap)controllerMapWithAxes).ElementAssignmentConflicts(OHuVIjQvpKkRPboXamLecMfoDfkL, hPeDnqOuWnocfEMfZNNwhmDjQLTb).GetEnumerator();
					vYiSjHIoMPMnbFAhZdIxlPJAAjeH = -3;
					goto IL_00ad;
				case 1:
					vYiSjHIoMPMnbFAhZdIxlPJAAjeH = -3;
					goto IL_00ad;
				case 2:
					{
						vYiSjHIoMPMnbFAhZdIxlPJAAjeH = -1;
						goto IL_01a9;
					}
					IL_00ad:
					if (UllfMWMDcezvhYuNFaxWcrFhmVZE.MoveNext())
					{
						ElementAssignmentConflictInfo current = UllfMWMDcezvhYuNFaxWcrFhmVZE.Current;
						LPYQDPMNAKfqGpGqISIdPGljsHd = current;
						vYiSjHIoMPMnbFAhZdIxlPJAAjeH = 1;
						return true;
					}
					CXOaFoPDDwaKqXKiZjMqzXxSsVli();
					UllfMWMDcezvhYuNFaxWcrFhmVZE = null;
					if (hPeDnqOuWnocfEMfZNNwhmDjQLTb && (!controllerMapWithAxes._enabled || !OHuVIjQvpKkRPboXamLecMfoDfkL.YbgQyWQdQcTTSlKYNScpqBbjmQQo))
					{
						return false;
					}
					if (controllerMapWithAxes.xcxDlZIoeuhvFHVWmLEUTwGyxkKZ == null)
					{
						return false;
					}
					llVGOBptOrJOBAZqXDobSyPBmNEG = 0;
					goto IL_01bb;
					IL_01bb:
					if (llVGOBptOrJOBAZqXDobSyPBmNEG < controllerMapWithAxes.xcxDlZIoeuhvFHVWmLEUTwGyxkKZ.Count)
					{
						ActionElementMap actionElementMap = controllerMapWithAxes.xcxDlZIoeuhvFHVWmLEUTwGyxkKZ[llVGOBptOrJOBAZqXDobSyPBmNEG];
						if ((!hPeDnqOuWnocfEMfZNNwhmDjQLTb || actionElementMap.YbgQyWQdQcTTSlKYNScpqBbjmQQo) && actionElementMap.CheckForAssignmentConflict(OHuVIjQvpKkRPboXamLecMfoDfkL))
						{
							LPYQDPMNAKfqGpGqISIdPGljsHd = new ElementAssignmentConflictInfo(true, ReInput.mapping.GetMapCategory(controllerMapWithAxes._categoryId).userAssignable, -1, controllerMapWithAxes._controllerType, controllerMapWithAxes._controllerId, controllerMapWithAxes._id, actionElementMap.LQceMJAxYgRpolrwLwsLBxilJMmNA, actionElementMap._actionId, actionElementMap._elementType, actionElementMap._elementIdentifierId, actionElementMap.keyCode, actionElementMap.modifierKeyFlags);
							vYiSjHIoMPMnbFAhZdIxlPJAAjeH = 2;
							return true;
						}
						goto IL_01a9;
					}
					return false;
					IL_01a9:
					llVGOBptOrJOBAZqXDobSyPBmNEG++;
					goto IL_01bb;
				}
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

		private void CXOaFoPDDwaKqXKiZjMqzXxSsVli()
		{
			vYiSjHIoMPMnbFAhZdIxlPJAAjeH = -1;
			if (UllfMWMDcezvhYuNFaxWcrFhmVZE != null)
			{
				UllfMWMDcezvhYuNFaxWcrFhmVZE.Dispose();
			}
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		IEnumerator<ElementAssignmentConflictInfo> IEnumerable<ElementAssignmentConflictInfo>.GetEnumerator()
		{
			AJvSZYdsSYctACwCmZfqkKJGjjCJ aJvSZYdsSYctACwCmZfqkKJGjjCJ;
			if (vYiSjHIoMPMnbFAhZdIxlPJAAjeH == -2 && QjPTlzLaPHBOAapxzzRqopAAdsBFA == Environment.CurrentManagedThreadId)
			{
				vYiSjHIoMPMnbFAhZdIxlPJAAjeH = 0;
				aJvSZYdsSYctACwCmZfqkKJGjjCJ = this;
			}
			else
			{
				aJvSZYdsSYctACwCmZfqkKJGjjCJ = new AJvSZYdsSYctACwCmZfqkKJGjjCJ(0);
				aJvSZYdsSYctACwCmZfqkKJGjjCJ.aIdxGQPYerxijgojPFBspdQgazNh = aIdxGQPYerxijgojPFBspdQgazNh;
			}
			aJvSZYdsSYctACwCmZfqkKJGjjCJ.OHuVIjQvpKkRPboXamLecMfoDfkL = sOkTTUaevBtdaMoYnJibwwroqYbT;
			aJvSZYdsSYctACwCmZfqkKJGjjCJ.hPeDnqOuWnocfEMfZNNwhmDjQLTb = riACltzoZNjFCkcflGfBsELqkZje;
			return aJvSZYdsSYctACwCmZfqkKJGjjCJ;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
		}
	}

	private sealed class eFIBNATmRbljewGICepNMXCqBJJp : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
	{
		private int suewKBmNVEhnTgBTVqRYwDkBfAkt;

		private ElementAssignmentConflictInfo nRRdcjCRQcQhxVXuucLHyneUMhqK;

		private int glBGCFCkOatycTcBJMYBQtUifKQr;

		public ControllerMapWithAxes JdiitgCnxsnmhitPJaUqEIYhmDcEd;

		private ElementAssignmentConflictCheck vcccUBGSXnQQzMfCCUKTUSRcVpcs;

		public ElementAssignmentConflictCheck tbwnDfoFmWpMyHRrjxvdlgImTHuI;

		private bool VNMSuzybqLbAjcePLCVxCYdLsiuw;

		public bool XcqMWysGPfsJDGXkpvKxBKMvdjEIA;

		private ElementAssignment rBLfktUvodbzQFMYtNspPjEDCNbzA;

		private IEnumerator<ElementAssignmentConflictInfo> vOZnWqkKlVcauEsYrdQExidpjtnV;

		private int nAiYDzAwQwGrzQNJPeMeRPbphKWc;

		ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
		{
			[DebuggerHidden]
			get
			{
				return nRRdcjCRQcQhxVXuucLHyneUMhqK;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return nRRdcjCRQcQhxVXuucLHyneUMhqK;
			}
		}

		[DebuggerHidden]
		public eFIBNATmRbljewGICepNMXCqBJJp(int P_0)
		{
			suewKBmNVEhnTgBTVqRYwDkBfAkt = P_0;
			glBGCFCkOatycTcBJMYBQtUifKQr = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			int num = suewKBmNVEhnTgBTVqRYwDkBfAkt;
			if (num == -3 || num == 1)
			{
				try
				{
				}
				finally
				{
					oNUYgwowJqLbLLqLWeUdgnlZZMIo();
				}
			}
		}

		private bool MoveNext()
		{
			try
			{
				int num = suewKBmNVEhnTgBTVqRYwDkBfAkt;
				ControllerMapWithAxes jdiitgCnxsnmhitPJaUqEIYhmDcEd = JdiitgCnxsnmhitPJaUqEIYhmDcEd;
				switch (num)
				{
				default:
					return false;
				case 0:
					suewKBmNVEhnTgBTVqRYwDkBfAkt = -1;
					if (ReInput._id != jdiitgCnxsnmhitPJaUqEIYhmDcEd.XTCjmLKuHDyBHCdnAHQddPuHUPTo)
					{
						ReInput.CheckInitialized(jdiitgCnxsnmhitPJaUqEIYhmDcEd.XTCjmLKuHDyBHCdnAHQddPuHUPTo);
						return false;
					}
					vOZnWqkKlVcauEsYrdQExidpjtnV = ((ControllerMap)jdiitgCnxsnmhitPJaUqEIYhmDcEd).ElementAssignmentConflicts(vcccUBGSXnQQzMfCCUKTUSRcVpcs, VNMSuzybqLbAjcePLCVxCYdLsiuw).GetEnumerator();
					suewKBmNVEhnTgBTVqRYwDkBfAkt = -3;
					goto IL_009e;
				case 1:
					suewKBmNVEhnTgBTVqRYwDkBfAkt = -3;
					goto IL_009e;
				case 2:
					{
						suewKBmNVEhnTgBTVqRYwDkBfAkt = -1;
						goto IL_01b5;
					}
					IL_01c7:
					if (nAiYDzAwQwGrzQNJPeMeRPbphKWc < jdiitgCnxsnmhitPJaUqEIYhmDcEd.xcxDlZIoeuhvFHVWmLEUTwGyxkKZ.Count)
					{
						ActionElementMap actionElementMap = jdiitgCnxsnmhitPJaUqEIYhmDcEd.xcxDlZIoeuhvFHVWmLEUTwGyxkKZ[nAiYDzAwQwGrzQNJPeMeRPbphKWc];
						if ((!VNMSuzybqLbAjcePLCVxCYdLsiuw || actionElementMap.YbgQyWQdQcTTSlKYNScpqBbjmQQo) && actionElementMap.LQceMJAxYgRpolrwLwsLBxilJMmNA != vcccUBGSXnQQzMfCCUKTUSRcVpcs.elementMapId && actionElementMap.CheckForAssignmentConflict(rBLfktUvodbzQFMYtNspPjEDCNbzA))
						{
							nRRdcjCRQcQhxVXuucLHyneUMhqK = new ElementAssignmentConflictInfo(true, ReInput.mapping.GetMapCategory(jdiitgCnxsnmhitPJaUqEIYhmDcEd._categoryId).userAssignable, -1, jdiitgCnxsnmhitPJaUqEIYhmDcEd._controllerType, jdiitgCnxsnmhitPJaUqEIYhmDcEd._controllerId, jdiitgCnxsnmhitPJaUqEIYhmDcEd._id, actionElementMap.LQceMJAxYgRpolrwLwsLBxilJMmNA, actionElementMap._actionId, actionElementMap._elementType, actionElementMap._elementIdentifierId, actionElementMap.keyCode, actionElementMap.modifierKeyFlags);
							suewKBmNVEhnTgBTVqRYwDkBfAkt = 2;
							return true;
						}
						goto IL_01b5;
					}
					return false;
					IL_009e:
					if (vOZnWqkKlVcauEsYrdQExidpjtnV.MoveNext())
					{
						ElementAssignmentConflictInfo current = vOZnWqkKlVcauEsYrdQExidpjtnV.Current;
						nRRdcjCRQcQhxVXuucLHyneUMhqK = current;
						suewKBmNVEhnTgBTVqRYwDkBfAkt = 1;
						return true;
					}
					oNUYgwowJqLbLLqLWeUdgnlZZMIo();
					vOZnWqkKlVcauEsYrdQExidpjtnV = null;
					if (VNMSuzybqLbAjcePLCVxCYdLsiuw && !jdiitgCnxsnmhitPJaUqEIYhmDcEd._enabled)
					{
						return false;
					}
					if (jdiitgCnxsnmhitPJaUqEIYhmDcEd.xcxDlZIoeuhvFHVWmLEUTwGyxkKZ == null)
					{
						return false;
					}
					rBLfktUvodbzQFMYtNspPjEDCNbzA = vcccUBGSXnQQzMfCCUKTUSRcVpcs.ToElementAssignment();
					nAiYDzAwQwGrzQNJPeMeRPbphKWc = 0;
					goto IL_01c7;
					IL_01b5:
					nAiYDzAwQwGrzQNJPeMeRPbphKWc++;
					goto IL_01c7;
				}
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

		private void oNUYgwowJqLbLLqLWeUdgnlZZMIo()
		{
			suewKBmNVEhnTgBTVqRYwDkBfAkt = -1;
			if (vOZnWqkKlVcauEsYrdQExidpjtnV != null)
			{
				vOZnWqkKlVcauEsYrdQExidpjtnV.Dispose();
			}
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		IEnumerator<ElementAssignmentConflictInfo> IEnumerable<ElementAssignmentConflictInfo>.GetEnumerator()
		{
			eFIBNATmRbljewGICepNMXCqBJJp eFIBNATmRbljewGICepNMXCqBJJp2;
			if (suewKBmNVEhnTgBTVqRYwDkBfAkt == -2 && glBGCFCkOatycTcBJMYBQtUifKQr == Environment.CurrentManagedThreadId)
			{
				suewKBmNVEhnTgBTVqRYwDkBfAkt = 0;
				eFIBNATmRbljewGICepNMXCqBJJp2 = this;
			}
			else
			{
				eFIBNATmRbljewGICepNMXCqBJJp2 = new eFIBNATmRbljewGICepNMXCqBJJp(0);
				eFIBNATmRbljewGICepNMXCqBJJp2.JdiitgCnxsnmhitPJaUqEIYhmDcEd = JdiitgCnxsnmhitPJaUqEIYhmDcEd;
			}
			eFIBNATmRbljewGICepNMXCqBJJp2.vcccUBGSXnQQzMfCCUKTUSRcVpcs = tbwnDfoFmWpMyHRrjxvdlgImTHuI;
			eFIBNATmRbljewGICepNMXCqBJJp2.VNMSuzybqLbAjcePLCVxCYdLsiuw = XcqMWysGPfsJDGXkpvKxBKMvdjEIA;
			return eFIBNATmRbljewGICepNMXCqBJJp2;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
		}
	}

	private readonly IList<ActionElementMap> xcxDlZIoeuhvFHVWmLEUTwGyxkKZ;

	private readonly ReadOnlyCollection<ActionElementMap> VNdLOkkIDLpOXtfpjKSnUaNkexbJ;

	public int axisMapCount
	{
		get
		{
			if (ReInput._id != XTCjmLKuHDyBHCdnAHQddPuHUPTo)
			{
				ReInput.CheckInitialized(XTCjmLKuHDyBHCdnAHQddPuHUPTo);
				return 0;
			}
			if (xcxDlZIoeuhvFHVWmLEUTwGyxkKZ == null)
			{
				return 0;
			}
			return xcxDlZIoeuhvFHVWmLEUTwGyxkKZ.Count;
		}
	}

	public IList<ActionElementMap> AxisMaps
	{
		get
		{
			if (ReInput._id != XTCjmLKuHDyBHCdnAHQddPuHUPTo)
			{
				ReInput.CheckInitialized(XTCjmLKuHDyBHCdnAHQddPuHUPTo);
				return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
			}
			return VNdLOkkIDLpOXtfpjKSnUaNkexbJ;
		}
	}

	internal AList<ActionElementMap> XzoNFseDOIJpHhDDeHIWjjcRoTxSA => JpUeYJtbpkbbatKXpctUbIMGJOCyA();

	public ControllerMapWithAxes()
	{
		xcxDlZIoeuhvFHVWmLEUTwGyxkKZ = new AList<ActionElementMap>();
		VNdLOkkIDLpOXtfpjKSnUaNkexbJ = new ReadOnlyCollection<ActionElementMap>(xcxDlZIoeuhvFHVWmLEUTwGyxkKZ);
	}

	public ControllerMapWithAxes(ControllerMapWithAxes P_0)
		: base(P_0)
	{
		xcxDlZIoeuhvFHVWmLEUTwGyxkKZ = new AList<ActionElementMap>();
		VNdLOkkIDLpOXtfpjKSnUaNkexbJ = new ReadOnlyCollection<ActionElementMap>(xcxDlZIoeuhvFHVWmLEUTwGyxkKZ);
		if (P_0.xcxDlZIoeuhvFHVWmLEUTwGyxkKZ != null)
		{
			int count = P_0.xcxDlZIoeuhvFHVWmLEUTwGyxkKZ.Count;
			for (int i = 0; i < count; i++)
			{
				xDYgfdsGASInnbCNqHQBgKxLpzIb(new ActionElementMap(P_0.xcxDlZIoeuhvFHVWmLEUTwGyxkKZ[i]));
			}
		}
	}

	public override bool ContainsAction(int actionId)
	{
		if (ReInput._id != XTCjmLKuHDyBHCdnAHQddPuHUPTo)
		{
			ReInput.CheckInitialized(XTCjmLKuHDyBHCdnAHQddPuHUPTo);
			return false;
		}
		if (base.ContainsAction(actionId))
		{
			return true;
		}
		if (xcxDlZIoeuhvFHVWmLEUTwGyxkKZ == null)
		{
			return false;
		}
		int count = xcxDlZIoeuhvFHVWmLEUTwGyxkKZ.Count;
		for (int i = 0; i < count; i++)
		{
			if (xcxDlZIoeuhvFHVWmLEUTwGyxkKZ[i]._actionId == actionId)
			{
				return true;
			}
		}
		return false;
	}

	public override bool CreateElementMap(int actionId, Pole axisContribution, int elementIdentifierId, ControllerElementType elementType, AxisRange axisRange, bool invert, out ActionElementMap result)
	{
		if (ReInput._id != XTCjmLKuHDyBHCdnAHQddPuHUPTo)
		{
			ReInput.CheckInitialized(XTCjmLKuHDyBHCdnAHQddPuHUPTo);
			result = null;
			return false;
		}
		if (base.CreateElementMap(actionId, axisContribution, elementIdentifierId, elementType, axisRange, invert, out result))
		{
			return true;
		}
		if (!yIxyWYIcyGilnzBfcZCyuqyiGwtm(elementType))
		{
			return false;
		}
		ActionElementMap actionElementMap = new ActionElementMap(actionId, elementType, elementIdentifierId, axisContribution, axisRange, invert);
		BakeElementMap(actionElementMap);
		xDYgfdsGASInnbCNqHQBgKxLpzIb(actionElementMap);
		result = actionElementMap;
		return true;
	}

	public override bool ReplaceElementMap(int elementMapId, int actionId, Pole axisContribution, int elementIdentifierId, ControllerElementType elementType, AxisRange axisRange, bool invert, out ActionElementMap result)
	{
		if (ReInput._id != XTCjmLKuHDyBHCdnAHQddPuHUPTo)
		{
			ReInput.CheckInitialized(XTCjmLKuHDyBHCdnAHQddPuHUPTo);
			result = null;
			return false;
		}
		if (base.ReplaceElementMap(elementMapId, actionId, axisContribution, elementIdentifierId, elementType, axisRange, invert, out result))
		{
			return true;
		}
		if (!yIxyWYIcyGilnzBfcZCyuqyiGwtm(elementType))
		{
			return false;
		}
		ActionElementMap elementMap = GetElementMap(elementMapId);
		if (elementMap == null)
		{
			return false;
		}
		if (!yIxyWYIcyGilnzBfcZCyuqyiGwtm(elementMap._elementType))
		{
			DeleteElementMap(elementMapId);
			elementMap._elementType = ControllerElementType.Axis;
			xDYgfdsGASInnbCNqHQBgKxLpzIb(elementMap);
		}
		if (sptHkNZGmMVgqEQejXPbAHZlhPYp(elementMapId) < 0)
		{
			return false;
		}
		ControllerMap.bscxZCAoNJMLdkUKriUgtlzjeUaS(elementMap, actionId, axisContribution, elementIdentifierId, elementType, axisRange, invert);
		BakeElementMap(elementMap);
		result = elementMap;
		return true;
	}

	public override bool DeleteElementMap(int elementMapId)
	{
		if (ReInput._id != XTCjmLKuHDyBHCdnAHQddPuHUPTo)
		{
			ReInput.CheckInitialized(XTCjmLKuHDyBHCdnAHQddPuHUPTo);
			return false;
		}
		if (base.DeleteElementMap(elementMapId))
		{
			return true;
		}
		int num = sptHkNZGmMVgqEQejXPbAHZlhPYp(elementMapId);
		if (num < 0)
		{
			return false;
		}
		FldzoUNEtpOurmQvHOKibxpXrMRX(elementMapId, num);
		return true;
	}

	public override bool DeleteElementMapsWithAction(string actionName)
	{
		if (ReInput._id != XTCjmLKuHDyBHCdnAHQddPuHUPTo)
		{
			ReInput.CheckInitialized(XTCjmLKuHDyBHCdnAHQddPuHUPTo);
			return false;
		}
		return DeleteElementMapsWithAction(ReInput.IsSPFehscBAmxtEADWGWuasjDvqf.GhVjGDQeDQmOWTnROakHcfdeCdDd(actionName));
	}

	public override bool DeleteElementMapsWithAction(int actionId)
	{
		if (ReInput._id != XTCjmLKuHDyBHCdnAHQddPuHUPTo)
		{
			ReInput.CheckInitialized(XTCjmLKuHDyBHCdnAHQddPuHUPTo);
			return false;
		}
		return base.DeleteElementMapsWithAction(actionId) | DeleteAxisMapsWithAction(actionId);
	}

	public override ActionElementMap GetElementMap(int elementMapId)
	{
		if (ReInput._id != XTCjmLKuHDyBHCdnAHQddPuHUPTo)
		{
			ReInput.CheckInitialized(XTCjmLKuHDyBHCdnAHQddPuHUPTo);
			return null;
		}
		ActionElementMap elementMap = base.GetElementMap(elementMapId);
		if (elementMap != null)
		{
			return elementMap;
		}
		if (xcxDlZIoeuhvFHVWmLEUTwGyxkKZ == null)
		{
			return null;
		}
		int count = xcxDlZIoeuhvFHVWmLEUTwGyxkKZ.Count;
		for (int i = 0; i < count; i++)
		{
			if (xcxDlZIoeuhvFHVWmLEUTwGyxkKZ[i].LQceMJAxYgRpolrwLwsLBxilJMmNA == elementMapId)
			{
				return xcxDlZIoeuhvFHVWmLEUTwGyxkKZ[i];
			}
		}
		return null;
	}

	public override ActionElementMap GetFirstElementMapWithAction(int actionId)
	{
		return GetFirstElementMapWithAction(actionId, skipDisabledMaps: false);
	}

	public override ActionElementMap GetFirstElementMapWithAction(int actionId, bool skipDisabledMaps)
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
		ActionElementMap firstElementMapWithAction = base.GetFirstElementMapWithAction(actionId, skipDisabledMaps);
		if (firstElementMapWithAction != null)
		{
			return firstElementMapWithAction;
		}
		int count = xcxDlZIoeuhvFHVWmLEUTwGyxkKZ.Count;
		for (int i = 0; i < count; i++)
		{
			ActionElementMap actionElementMap = xcxDlZIoeuhvFHVWmLEUTwGyxkKZ[i];
			if (actionElementMap._actionId == actionId && (!skipDisabledMaps || actionElementMap.YbgQyWQdQcTTSlKYNScpqBbjmQQo))
			{
				return actionElementMap;
			}
		}
		return null;
	}

	internal virtual ActionElementMap gQRUTCOzVxsadAJaZIwpYltKEJuM(Predicate<ActionElementMap> P_0, bool P_1)
	{
		ActionElementMap actionElementMap = base.NVzgxKrqOfDMcDwhzoluufJpIYodb(P_0, P_1);
		if (actionElementMap != null)
		{
			return actionElementMap;
		}
		return YYFBCpcaztLMNjCyznvRUjpHoDSs(P_0, P_1);
	}

	internal virtual int pbfcsurVxjzFwordpuOMAwCtLrOo(Predicate<ActionElementMap> P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
	{
		return base.RySnNfmkfVFFiPuhOdrfvbeGhwzGA(P_0, P_1, P_2, P_3) + JmcBYyBEtNxqUsoNPFixcwKHiYnKb(P_0, P_1, P_2, true);
	}

	public override void ClearElementMaps()
	{
		if (ReInput._id != XTCjmLKuHDyBHCdnAHQddPuHUPTo)
		{
			ReInput.CheckInitialized(XTCjmLKuHDyBHCdnAHQddPuHUPTo);
			return;
		}
		base.ClearElementMaps();
		xcxDlZIoeuhvFHVWmLEUTwGyxkKZ.Clear();
	}

	public ActionElementMap GetAxisMap(int index)
	{
		if (ReInput._id != XTCjmLKuHDyBHCdnAHQddPuHUPTo)
		{
			ReInput.CheckInitialized(XTCjmLKuHDyBHCdnAHQddPuHUPTo);
			return null;
		}
		if (xcxDlZIoeuhvFHVWmLEUTwGyxkKZ == null || index < 0 || index >= xcxDlZIoeuhvFHVWmLEUTwGyxkKZ.Count)
		{
			return null;
		}
		return xcxDlZIoeuhvFHVWmLEUTwGyxkKZ[index];
	}

	public ActionElementMap[] GetAxisMaps()
	{
		if (ReInput._id != XTCjmLKuHDyBHCdnAHQddPuHUPTo)
		{
			ReInput.CheckInitialized(XTCjmLKuHDyBHCdnAHQddPuHUPTo);
			return EmptyObjects<ActionElementMap>.array;
		}
		return GetAxisMaps(skipDisabledMaps: false);
	}

	public ActionElementMap[] GetAxisMaps(bool skipDisabledMaps)
	{
		if (ReInput._id != XTCjmLKuHDyBHCdnAHQddPuHUPTo)
		{
			ReInput.CheckInitialized(XTCjmLKuHDyBHCdnAHQddPuHUPTo);
			return EmptyObjects<ActionElementMap>.array;
		}
		if (!skipDisabledMaps)
		{
			return ListTools.ToArray(xcxDlZIoeuhvFHVWmLEUTwGyxkKZ);
		}
		int num = axisMapCount;
		List<ActionElementMap> list = new List<ActionElementMap>(num);
		for (int i = 0; i < num; i++)
		{
			ActionElementMap actionElementMap = xcxDlZIoeuhvFHVWmLEUTwGyxkKZ[i];
			if (actionElementMap.YbgQyWQdQcTTSlKYNScpqBbjmQQo)
			{
				list.Add(actionElementMap);
			}
		}
		return list.ToArray();
	}

	public int GetAxisMaps(bool skipDisabledMaps, List<ActionElementMap> results)
	{
		if (ReInput._id != XTCjmLKuHDyBHCdnAHQddPuHUPTo)
		{
			ReInput.CheckInitialized(XTCjmLKuHDyBHCdnAHQddPuHUPTo);
			return 0;
		}
		return SRWIAdXqsHyNQGLwArFtNcwDdIsHA(skipDisabledMaps, results, false);
	}

	public ActionElementMap[] GetAxisMapsWithAction(string actionName)
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
		return GetAxisMapsWithAction(inputAction.id);
	}

	public ActionElementMap[] GetAxisMapsWithAction(int actionId)
	{
		return GetAxisMapsWithAction(actionId, skipDisabledMaps: false);
	}

	public ActionElementMap[] GetAxisMapsWithAction(string actionName, bool skipDisabledMaps)
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
		return GetAxisMapsWithAction(inputAction.id, skipDisabledMaps);
	}

	public ActionElementMap[] GetAxisMapsWithAction(int actionId, bool skipDisabledMaps)
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
		int num = axisMapCount;
		if (num == 0)
		{
			return EmptyObjects<ActionElementMap>.array;
		}
		int num2 = 0;
		for (int i = 0; i < num; i++)
		{
			ActionElementMap actionElementMap = xcxDlZIoeuhvFHVWmLEUTwGyxkKZ[i];
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
			ActionElementMap actionElementMap2 = xcxDlZIoeuhvFHVWmLEUTwGyxkKZ[j];
			if (actionElementMap2._actionId == actionId && (!skipDisabledMaps || actionElementMap2.YbgQyWQdQcTTSlKYNScpqBbjmQQo))
			{
				array[num3] = actionElementMap2;
				num3++;
			}
		}
		return array;
	}

	public int GetAxisMapsWithAction(string actionName, List<ActionElementMap> results)
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
		return GetAxisMapsWithAction(inputAction.id, results);
	}

	public int GetAxisMapsWithAction(int actionId, List<ActionElementMap> results)
	{
		return GetAxisMapsWithAction(actionId, skipDisabledMaps: false, results);
	}

	public int GetAxisMapsWithAction(string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
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
		return GetAxisMapsWithAction(inputAction.id, skipDisabledMaps, results);
	}

	public int GetAxisMapsWithAction(int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
	{
		if (ReInput._id != XTCjmLKuHDyBHCdnAHQddPuHUPTo)
		{
			ReInput.CheckInitialized(XTCjmLKuHDyBHCdnAHQddPuHUPTo);
			return 0;
		}
		return jYwGpXSGaXGVHUvYLtxyHEAXqYHi(actionId, skipDisabledMaps, results, false);
	}

	public IEnumerable<ActionElementMap> AxisMapsWithAction(string actionName)
	{
		if (ReInput._id != XTCjmLKuHDyBHCdnAHQddPuHUPTo)
		{
			ReInput.CheckInitialized(XTCjmLKuHDyBHCdnAHQddPuHUPTo);
			return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
		}
		int actionId = ReInput.IsSPFehscBAmxtEADWGWuasjDvqf.GhVjGDQeDQmOWTnROakHcfdeCdDd(actionName);
		return AxisMapsWithAction(actionId);
	}

	public IEnumerable<ActionElementMap> AxisMapsWithAction(int actionId)
	{
		return AxisMapsWithAction(actionId, skipDisabledMaps: false);
	}

	public IEnumerable<ActionElementMap> AxisMapsWithAction(string actionName, bool skipDisabledMaps)
	{
		int actionId = ReInput.IsSPFehscBAmxtEADWGWuasjDvqf.GhVjGDQeDQmOWTnROakHcfdeCdDd(actionName);
		return AxisMapsWithAction(actionId, skipDisabledMaps);
	}

	[IteratorStateMachine(typeof(HobnldBbVQUvuyNyAuzfwyuVrvEG))]
	public IEnumerable<ActionElementMap> AxisMapsWithAction(int actionId, bool skipDisabledMaps)
	{
		return new HobnldBbVQUvuyNyAuzfwyuVrvEG(-2)
		{
			IbOuevbPWZAlMuMtgUUvyRHPGDvx = this,
			ANiTvSoMaYeRKjYuQeXbJKglKZStA = actionId,
			COOAjgDOwFxQoexsbJRCxHhJPkMl = skipDisabledMaps
		};
	}

	public ActionElementMap GetFirstAxisMapWithAction(int actionId)
	{
		if (ReInput._id != XTCjmLKuHDyBHCdnAHQddPuHUPTo)
		{
			ReInput.CheckInitialized(XTCjmLKuHDyBHCdnAHQddPuHUPTo);
			return null;
		}
		return GetFirstAxisMapWithAction(actionId, skipDisabledMaps: false);
	}

	public ActionElementMap GetFirstAxisMapWithAction(string actionName)
	{
		if (ReInput._id != XTCjmLKuHDyBHCdnAHQddPuHUPTo)
		{
			ReInput.CheckInitialized(XTCjmLKuHDyBHCdnAHQddPuHUPTo);
			return null;
		}
		int actionId = ReInput.IsSPFehscBAmxtEADWGWuasjDvqf.GhVjGDQeDQmOWTnROakHcfdeCdDd(actionName);
		return GetFirstAxisMapWithAction(actionId);
	}

	public ActionElementMap GetFirstAxisMapWithAction(int actionId, bool skipDisabledMaps)
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
		IList<ActionElementMap> axisMaps = AxisMaps;
		int count = axisMaps.Count;
		for (int i = 0; i < count; i++)
		{
			ActionElementMap actionElementMap = axisMaps[i];
			if (actionElementMap._actionId == actionId && (!skipDisabledMaps || actionElementMap.YbgQyWQdQcTTSlKYNScpqBbjmQQo))
			{
				return actionElementMap;
			}
		}
		return null;
	}

	public ActionElementMap GetFirstAxisMapWithAction(string actionName, bool skipDisabledMaps)
	{
		if (ReInput._id != XTCjmLKuHDyBHCdnAHQddPuHUPTo)
		{
			ReInput.CheckInitialized(XTCjmLKuHDyBHCdnAHQddPuHUPTo);
			return null;
		}
		int actionId = ReInput.IsSPFehscBAmxtEADWGWuasjDvqf.GhVjGDQeDQmOWTnROakHcfdeCdDd(actionName);
		return GetFirstAxisMapWithAction(actionId, skipDisabledMaps);
	}

	public ActionElementMap GetFirstAxisMapMatch(Predicate<ActionElementMap> predicate)
	{
		if (ReInput._id != XTCjmLKuHDyBHCdnAHQddPuHUPTo)
		{
			ReInput.CheckInitialized(XTCjmLKuHDyBHCdnAHQddPuHUPTo);
			return null;
		}
		return YYFBCpcaztLMNjCyznvRUjpHoDSs(predicate, false);
	}

	internal ActionElementMap YYFBCpcaztLMNjCyznvRUjpHoDSs(Predicate<ActionElementMap> P_0, bool P_1)
	{
		if (P_0 == null)
		{
			throw new ArgumentNullException("predicate");
		}
		IList<ActionElementMap> axisMaps = AxisMaps;
		int num = axisMapCount;
		try
		{
			for (int i = 0; i < num; i++)
			{
				ActionElementMap actionElementMap = axisMaps[i];
				if ((!P_1 || actionElementMap.enabled) && P_0(actionElementMap))
				{
					return actionElementMap;
				}
			}
		}
		catch (Exception exception)
		{
			ReInput.HandleCallbackException("ControllerMap.GetFirstAxisMapMatch", exception);
		}
		return null;
	}

	public int GetAxisMapMatches(Predicate<ActionElementMap> predicate, List<ActionElementMap> results)
	{
		if (ReInput._id != XTCjmLKuHDyBHCdnAHQddPuHUPTo)
		{
			ReInput.CheckInitialized(XTCjmLKuHDyBHCdnAHQddPuHUPTo);
			return 0;
		}
		return JmcBYyBEtNxqUsoNPFixcwKHiYnKb(predicate, false, results, false);
	}

	internal int JmcBYyBEtNxqUsoNPFixcwKHiYnKb(Predicate<ActionElementMap> P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
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
		IList<ActionElementMap> axisMaps = AxisMaps;
		int num2 = axisMapCount;
		try
		{
			for (int i = 0; i < num2; i++)
			{
				ActionElementMap actionElementMap = axisMaps[i];
				if ((!P_1 || actionElementMap.enabled) && P_0(actionElementMap))
				{
					P_2.Add(actionElementMap);
				}
			}
		}
		catch (Exception exception)
		{
			ReInput.HandleCallbackException("ControllerMap.GetAxisMapMatches", exception);
		}
		return P_2.Count - num;
	}

	public void ForEachAxisMapMatch(Predicate<ActionElementMap> predicate, Action<ActionElementMap> actionToPerform)
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
		int count = xcxDlZIoeuhvFHVWmLEUTwGyxkKZ.Count;
		try
		{
			for (int i = 0; i < count; i++)
			{
				ActionElementMap obj = xcxDlZIoeuhvFHVWmLEUTwGyxkKZ[i];
				if (predicate(obj))
				{
					actionToPerform(obj);
				}
			}
		}
		catch (Exception exception)
		{
			ReInput.HandleCallbackException("ControllerMap.ForEachAxisMapMatch", exception);
		}
	}

	public bool DeleteAxisMapsWithAction(string actionName)
	{
		return DeleteAxisMapsWithAction(ReInput.IsSPFehscBAmxtEADWGWuasjDvqf.GhVjGDQeDQmOWTnROakHcfdeCdDd(actionName));
	}

	public bool DeleteAxisMapsWithAction(int actionId)
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
		int num = axisMapCount;
		if (num == 0)
		{
			return false;
		}
		bool result = false;
		for (int num2 = num - 1; num2 >= 0; num2--)
		{
			if (xcxDlZIoeuhvFHVWmLEUTwGyxkKZ[num2] != null && xcxDlZIoeuhvFHVWmLEUTwGyxkKZ[num2]._actionId == actionId)
			{
				FldzoUNEtpOurmQvHOKibxpXrMRX(xcxDlZIoeuhvFHVWmLEUTwGyxkKZ[num2].LQceMJAxYgRpolrwLwsLBxilJMmNA, num2);
				result = true;
			}
		}
		return result;
	}

	public int SetAllAxisMapsEnabled(bool state)
	{
		if (ReInput._id != XTCjmLKuHDyBHCdnAHQddPuHUPTo)
		{
			ReInput.CheckInitialized(XTCjmLKuHDyBHCdnAHQddPuHUPTo);
			return 0;
		}
		int num = 0;
		int count = xcxDlZIoeuhvFHVWmLEUTwGyxkKZ.Count;
		for (int i = 0; i < count; i++)
		{
			ActionElementMap actionElementMap = xcxDlZIoeuhvFHVWmLEUTwGyxkKZ[i];
			if (actionElementMap.YbgQyWQdQcTTSlKYNScpqBbjmQQo != state)
			{
				actionElementMap.YbgQyWQdQcTTSlKYNScpqBbjmQQo = state;
				num++;
			}
		}
		return num;
	}

	public override bool DoesElementAssignmentConflict(ControllerMap controllerMap, bool skipDisabledMaps)
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
		if (base.DoesElementAssignmentConflict(controllerMap, skipDisabledMaps))
		{
			return true;
		}
		if (!(controllerMap is ControllerMapWithAxes controllerMapWithAxes))
		{
			return false;
		}
		if (skipDisabledMaps && (!_enabled || !controllerMapWithAxes._enabled))
		{
			return false;
		}
		if (xcxDlZIoeuhvFHVWmLEUTwGyxkKZ == null)
		{
			return false;
		}
		IList<ActionElementMap> axisMaps = controllerMapWithAxes.AxisMaps;
		if (axisMaps == null)
		{
			return false;
		}
		int count = xcxDlZIoeuhvFHVWmLEUTwGyxkKZ.Count;
		int count2 = axisMaps.Count;
		for (int i = 0; i < count; i++)
		{
			ActionElementMap actionElementMap = xcxDlZIoeuhvFHVWmLEUTwGyxkKZ[i];
			if (skipDisabledMaps && !actionElementMap.YbgQyWQdQcTTSlKYNScpqBbjmQQo)
			{
				continue;
			}
			for (int j = 0; j < count2; j++)
			{
				ActionElementMap actionElementMap2 = axisMaps[j];
				if ((!skipDisabledMaps || actionElementMap2.YbgQyWQdQcTTSlKYNScpqBbjmQQo) && actionElementMap.CheckForAssignmentConflict(actionElementMap2))
				{
					return true;
				}
			}
		}
		return false;
	}

	public override bool DoesElementAssignmentConflict(ActionElementMap actionElementMap, bool skipDisabledMaps)
	{
		if (ReInput._id != XTCjmLKuHDyBHCdnAHQddPuHUPTo)
		{
			ReInput.CheckInitialized(XTCjmLKuHDyBHCdnAHQddPuHUPTo);
			return false;
		}
		if (actionElementMap == null)
		{
			return false;
		}
		if (base.DoesElementAssignmentConflict(actionElementMap, skipDisabledMaps))
		{
			return true;
		}
		if (skipDisabledMaps && (!_enabled || !actionElementMap.YbgQyWQdQcTTSlKYNScpqBbjmQQo))
		{
			return false;
		}
		if (xcxDlZIoeuhvFHVWmLEUTwGyxkKZ == null)
		{
			return false;
		}
		for (int i = 0; i < xcxDlZIoeuhvFHVWmLEUTwGyxkKZ.Count; i++)
		{
			ActionElementMap actionElementMap2 = xcxDlZIoeuhvFHVWmLEUTwGyxkKZ[i];
			if ((!skipDisabledMaps || actionElementMap2.YbgQyWQdQcTTSlKYNScpqBbjmQQo) && actionElementMap2.CheckForAssignmentConflict(actionElementMap))
			{
				return true;
			}
		}
		return false;
	}

	public override bool DoesElementAssignmentConflict(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
	{
		if (ReInput._id != XTCjmLKuHDyBHCdnAHQddPuHUPTo)
		{
			ReInput.CheckInitialized(XTCjmLKuHDyBHCdnAHQddPuHUPTo);
			return false;
		}
		if (base.DoesElementAssignmentConflict(conflictCheck, skipDisabledMaps))
		{
			return true;
		}
		if (skipDisabledMaps && !_enabled)
		{
			return false;
		}
		if (conflictCheck.elementAssignmentType != ElementAssignmentType.FullAxis && conflictCheck.elementAssignmentType != ElementAssignmentType.SplitAxis)
		{
			return false;
		}
		if (xcxDlZIoeuhvFHVWmLEUTwGyxkKZ == null)
		{
			return false;
		}
		ElementAssignment elementAssignment = conflictCheck.ToElementAssignment();
		for (int i = 0; i < xcxDlZIoeuhvFHVWmLEUTwGyxkKZ.Count; i++)
		{
			ActionElementMap actionElementMap = xcxDlZIoeuhvFHVWmLEUTwGyxkKZ[i];
			if ((!skipDisabledMaps || actionElementMap.YbgQyWQdQcTTSlKYNScpqBbjmQQo) && actionElementMap.LQceMJAxYgRpolrwLwsLBxilJMmNA != conflictCheck.elementMapId && actionElementMap.CheckForAssignmentConflict(elementAssignment))
			{
				return true;
			}
		}
		return false;
	}

	[IteratorStateMachine(typeof(FmqRLxhXKLUZfijNJnwlsYYOtixs))]
	public override IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ControllerMap controllerMap, bool skipDisabledMaps)
	{
		return new FmqRLxhXKLUZfijNJnwlsYYOtixs(-2)
		{
			LZqLqimmzgdWMXgPDrlqANPqGiYkA = this,
			OOAGpHRpKOmJFIFYQPPVdgFhBIXq = controllerMap,
			yiWgPZxdtqqKbHjDwasYNrBikSCB = skipDisabledMaps
		};
	}

	[IteratorStateMachine(typeof(AJvSZYdsSYctACwCmZfqkKJGjjCJ))]
	public override IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ActionElementMap actionElementMap, bool skipDisabledMaps)
	{
		return new AJvSZYdsSYctACwCmZfqkKJGjjCJ(-2)
		{
			aIdxGQPYerxijgojPFBspdQgazNh = this,
			sOkTTUaevBtdaMoYnJibwwroqYbT = actionElementMap,
			riACltzoZNjFCkcflGfBsELqkZje = skipDisabledMaps
		};
	}

	[IteratorStateMachine(typeof(eFIBNATmRbljewGICepNMXCqBJJp))]
	public override IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
	{
		return new eFIBNATmRbljewGICepNMXCqBJJp(-2)
		{
			JdiitgCnxsnmhitPJaUqEIYhmDcEd = this,
			tbwnDfoFmWpMyHRrjxvdlgImTHuI = conflictCheck,
			XcqMWysGPfsJDGXkpvKxBKMvdjEIA = skipDisabledMaps
		};
	}

	public override int RemoveElementAssignmentConflicts(ControllerMap controllerMap, bool skipDisabledMaps)
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
		int num = base.RemoveElementAssignmentConflicts(controllerMap, skipDisabledMaps);
		if (!(controllerMap is ControllerMapWithAxes controllerMapWithAxes))
		{
			return num;
		}
		if (skipDisabledMaps && (!_enabled || !controllerMapWithAxes._enabled))
		{
			return num;
		}
		if (xcxDlZIoeuhvFHVWmLEUTwGyxkKZ == null)
		{
			return num;
		}
		IList<ActionElementMap> axisMaps = controllerMapWithAxes.AxisMaps;
		if (axisMaps == null)
		{
			return num;
		}
		InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(_categoryId);
		if (mapCategory != null && !mapCategory.userAssignable)
		{
			return num;
		}
		_ = xcxDlZIoeuhvFHVWmLEUTwGyxkKZ.Count;
		int count = axisMaps.Count;
		for (int num2 = xcxDlZIoeuhvFHVWmLEUTwGyxkKZ.Count - 1; num2 >= 0; num2--)
		{
			ActionElementMap actionElementMap = xcxDlZIoeuhvFHVWmLEUTwGyxkKZ[num2];
			if (!skipDisabledMaps || actionElementMap.YbgQyWQdQcTTSlKYNScpqBbjmQQo)
			{
				for (int i = 0; i < count; i++)
				{
					ActionElementMap actionElementMap2 = axisMaps[i];
					if ((!skipDisabledMaps || actionElementMap2.YbgQyWQdQcTTSlKYNScpqBbjmQQo) && actionElementMap.CheckForAssignmentConflict(actionElementMap2))
					{
						FldzoUNEtpOurmQvHOKibxpXrMRX(actionElementMap.LQceMJAxYgRpolrwLwsLBxilJMmNA, num2);
						num++;
						break;
					}
				}
			}
		}
		return num;
	}

	public override int RemoveElementAssignmentConflicts(ActionElementMap actionElementMap, bool skipDisabledMaps)
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
		int num = base.RemoveElementAssignmentConflicts(actionElementMap, skipDisabledMaps);
		if (skipDisabledMaps && (!_enabled || !actionElementMap.YbgQyWQdQcTTSlKYNScpqBbjmQQo))
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
		if (xcxDlZIoeuhvFHVWmLEUTwGyxkKZ == null)
		{
			return num;
		}
		for (int num2 = xcxDlZIoeuhvFHVWmLEUTwGyxkKZ.Count - 1; num2 >= 0; num2--)
		{
			ActionElementMap actionElementMap2 = xcxDlZIoeuhvFHVWmLEUTwGyxkKZ[num2];
			if ((!skipDisabledMaps || actionElementMap2.YbgQyWQdQcTTSlKYNScpqBbjmQQo) && actionElementMap2.CheckForAssignmentConflict(actionElementMap))
			{
				FldzoUNEtpOurmQvHOKibxpXrMRX(actionElementMap2.LQceMJAxYgRpolrwLwsLBxilJMmNA, num2);
				num++;
			}
		}
		return num;
	}

	public override int RemoveElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
	{
		if (ReInput._id != XTCjmLKuHDyBHCdnAHQddPuHUPTo)
		{
			ReInput.CheckInitialized(XTCjmLKuHDyBHCdnAHQddPuHUPTo);
			return 0;
		}
		int num = base.RemoveElementAssignmentConflicts(conflictCheck, skipDisabledMaps);
		if (skipDisabledMaps && !_enabled)
		{
			return num;
		}
		if (xcxDlZIoeuhvFHVWmLEUTwGyxkKZ == null)
		{
			return num;
		}
		if (conflictCheck.elementAssignmentType != ElementAssignmentType.FullAxis && conflictCheck.elementAssignmentType != ElementAssignmentType.SplitAxis)
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
		ElementAssignment elementAssignment = conflictCheck.ToElementAssignment();
		for (int num2 = xcxDlZIoeuhvFHVWmLEUTwGyxkKZ.Count - 1; num2 >= 0; num2--)
		{
			ActionElementMap actionElementMap = xcxDlZIoeuhvFHVWmLEUTwGyxkKZ[num2];
			if ((!skipDisabledMaps || actionElementMap.YbgQyWQdQcTTSlKYNScpqBbjmQQo) && actionElementMap.LQceMJAxYgRpolrwLwsLBxilJMmNA != conflictCheck.elementMapId && actionElementMap.CheckForAssignmentConflict(elementAssignment))
			{
				FldzoUNEtpOurmQvHOKibxpXrMRX(actionElementMap.LQceMJAxYgRpolrwLwsLBxilJMmNA, num2);
				num++;
			}
		}
		return num;
	}

	internal virtual int pJikVRjjneyFRHOgUNczeMCAuddu(ControllerMap P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
	{
		int num = base.KQXSSitueJXGlwhxDCvZlKiAkqgh(P_0, P_1, P_2, P_3);
		if (!(P_0 is ControllerMapWithAxes controllerMapWithAxes))
		{
			return num;
		}
		if (P_1 && (!_enabled || !controllerMapWithAxes._enabled))
		{
			return num;
		}
		if (xcxDlZIoeuhvFHVWmLEUTwGyxkKZ == null)
		{
			return num;
		}
		IList<ActionElementMap> axisMaps = controllerMapWithAxes.AxisMaps;
		if (axisMaps == null)
		{
			return num;
		}
		InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(_categoryId);
		if (mapCategory != null && !mapCategory.userAssignable)
		{
			return num;
		}
		int count = xcxDlZIoeuhvFHVWmLEUTwGyxkKZ.Count;
		int count2 = axisMaps.Count;
		for (int i = 0; i < count; i++)
		{
			ActionElementMap actionElementMap = xcxDlZIoeuhvFHVWmLEUTwGyxkKZ[i];
			if (!actionElementMap.YbgQyWQdQcTTSlKYNScpqBbjmQQo)
			{
				continue;
			}
			for (int j = 0; j < count2; j++)
			{
				ActionElementMap actionElementMap2 = axisMaps[j];
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

	internal virtual int JaiYNuskMBKNQaDgpPIHeyJySCeX(ActionElementMap P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
	{
		int num = base.ATkMWznydIsmMYtjoavrhFVKJGcj(P_0, P_1, P_2, P_3);
		if (P_0 == null)
		{
			return num;
		}
		if (P_1 && (!_enabled || !P_0.YbgQyWQdQcTTSlKYNScpqBbjmQQo))
		{
			return num;
		}
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
		int num2 = axisMapCount;
		for (int i = 0; i < num2; i++)
		{
			ActionElementMap actionElementMap = xcxDlZIoeuhvFHVWmLEUTwGyxkKZ[i];
			if (actionElementMap.YbgQyWQdQcTTSlKYNScpqBbjmQQo && P_0.CheckForAssignmentConflict(actionElementMap))
			{
				actionElementMap.enabled = false;
				P_2?.Add(actionElementMap);
				num++;
			}
		}
		return num;
	}

	internal virtual int oLKxDwGlSJKmvyuRAlRJRhNTtkkF(ElementAssignmentConflictCheck P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
	{
		int num = base.slUwgXrcYEXSwNCmAHrYogBZIKCZ(P_0, P_1, P_2, P_3);
		if (P_1 && !_enabled)
		{
			return num;
		}
		if (xcxDlZIoeuhvFHVWmLEUTwGyxkKZ == null)
		{
			return num;
		}
		if (P_0.elementAssignmentType != ElementAssignmentType.FullAxis && P_0.elementAssignmentType != ElementAssignmentType.SplitAxis)
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
		ElementAssignment elementAssignment = P_0.ToElementAssignment();
		int count = xcxDlZIoeuhvFHVWmLEUTwGyxkKZ.Count;
		for (int i = 0; i < count; i++)
		{
			ActionElementMap actionElementMap = xcxDlZIoeuhvFHVWmLEUTwGyxkKZ[i];
			if (actionElementMap.YbgQyWQdQcTTSlKYNScpqBbjmQQo && actionElementMap.LQceMJAxYgRpolrwLwsLBxilJMmNA != P_0.elementMapId && actionElementMap.CheckForAssignmentConflict(elementAssignment))
			{
				actionElementMap.enabled = false;
				P_2?.Add(actionElementMap);
				num++;
			}
		}
		return num;
	}

	public string[] GetAxisNames()
	{
		if (ReInput._id != XTCjmLKuHDyBHCdnAHQddPuHUPTo)
		{
			ReInput.CheckInitialized(XTCjmLKuHDyBHCdnAHQddPuHUPTo);
			return EmptyObjects<string>.array;
		}
		int num = axisMapCount;
		if (num == 0)
		{
			return null;
		}
		string[] array = new string[num];
		for (int i = 0; i < num; i++)
		{
			array[i] = xcxDlZIoeuhvFHVWmLEUTwGyxkKZ[i].elementIdentifierName;
		}
		return array;
	}

	internal AList<ActionElementMap> JpUeYJtbpkbbatKXpctUbIMGJOCyA()
	{
		return (AList<ActionElementMap>)xcxDlZIoeuhvFHVWmLEUTwGyxkKZ;
	}

	internal virtual bool DRLINtmLWnUBSxhqXutTLqwImbKI(ActionElementMap P_0)
	{
		if (base.gJwAODjSUWHoAFipcrtCuEWnsrOyb(P_0))
		{
			return true;
		}
		ControllerElementType elementType = P_0._elementType;
		if (!yIxyWYIcyGilnzBfcZCyuqyiGwtm(elementType))
		{
			return false;
		}
		xDYgfdsGASInnbCNqHQBgKxLpzIb(P_0);
		return true;
	}

	internal virtual int vuJyVtPpfLelLfawQSvXdxFCnNxUA(List<ActionElementMap> P_0, bool P_1)
	{
		base.ElNffPfXNwpFTQXfZcqhRXnLVlPu(P_0, P_1);
		int count = P_0.Count;
		int count2 = xcxDlZIoeuhvFHVWmLEUTwGyxkKZ.Count;
		for (int i = 0; i < count2; i++)
		{
			if (!P_1 || xcxDlZIoeuhvFHVWmLEUTwGyxkKZ[i].YbgQyWQdQcTTSlKYNScpqBbjmQQo)
			{
				P_0.Add(xcxDlZIoeuhvFHVWmLEUTwGyxkKZ[i]);
			}
		}
		return P_0.Count - count;
	}

	internal virtual ActionElementMap POLusHIjqIjTegUNALgyZMPAAxFU(int P_0, int P_1, ControllerElementType P_2)
	{
		ActionElementMap actionElementMap = base.fCvSNupNTfBFLaimCMmXxnYJuVwM(P_0, P_1, P_2);
		if (actionElementMap != null)
		{
			return actionElementMap;
		}
		if (!yIxyWYIcyGilnzBfcZCyuqyiGwtm(P_2))
		{
			return null;
		}
		int num = TQbDoqoefRtDhbCuyEEOjiBmeLiB(P_0, P_1, P_2);
		if (num < 0)
		{
			return null;
		}
		if (P_2 == ControllerElementType.Axis)
		{
			return xcxDlZIoeuhvFHVWmLEUTwGyxkKZ[num];
		}
		throw new NotImplementedException();
	}

	internal virtual int TWfGUMgMdztgkQumUqgdCCWIaRsf(int P_0, List<ActionElementMap> P_1, bool P_2)
	{
		if (P_1 == null)
		{
			throw new ArgumentNullException("results");
		}
		int num = (P_2 ? P_1.Count : 0);
		base.QhQSwEziCmAqgVrQqfOqIbjphfbS(P_0, P_1, P_2);
		if (xcxDlZIoeuhvFHVWmLEUTwGyxkKZ == null)
		{
			return P_1.Count - num;
		}
		int count = xcxDlZIoeuhvFHVWmLEUTwGyxkKZ.Count;
		for (int i = 0; i < count; i++)
		{
			if (xcxDlZIoeuhvFHVWmLEUTwGyxkKZ[i]._elementIdentifierId == P_0)
			{
				P_1.Add(xcxDlZIoeuhvFHVWmLEUTwGyxkKZ[i]);
			}
		}
		return P_1.Count - num;
	}

	internal virtual bool PGCAKwOPELaYbPQEedfsoOwlCKQb(int P_0, int P_1, ControllerElementType P_2)
	{
		if (base.HIETAHIdGnhJitAYIcswwoDpiFsC(P_0, P_1, P_2))
		{
			return true;
		}
		if (!yIxyWYIcyGilnzBfcZCyuqyiGwtm(P_2))
		{
			return false;
		}
		if (P_2 == ControllerElementType.Axis)
		{
			int count = xcxDlZIoeuhvFHVWmLEUTwGyxkKZ.Count;
			for (int i = 0; i < count; i++)
			{
				if (xcxDlZIoeuhvFHVWmLEUTwGyxkKZ[i]._elementIdentifierId == P_0 && xcxDlZIoeuhvFHVWmLEUTwGyxkKZ[i]._actionId == P_1)
				{
					return true;
				}
			}
			return false;
		}
		throw new NotImplementedException();
	}

	internal virtual int HRAogLvbqoplmuLUilKKqjGRadeX(int P_0, int P_1, ControllerElementType P_2)
	{
		int num = base.TQbDoqoefRtDhbCuyEEOjiBmeLiB(P_0, P_1, P_2);
		if (num >= 0)
		{
			return num;
		}
		if (!yIxyWYIcyGilnzBfcZCyuqyiGwtm(P_2))
		{
			return -1;
		}
		if (xcxDlZIoeuhvFHVWmLEUTwGyxkKZ == null)
		{
			return -1;
		}
		if (P_2 == ControllerElementType.Axis)
		{
			int count = xcxDlZIoeuhvFHVWmLEUTwGyxkKZ.Count;
			for (int i = 0; i < count; i++)
			{
				if (xcxDlZIoeuhvFHVWmLEUTwGyxkKZ[i]._elementIdentifierId == P_0 && xcxDlZIoeuhvFHVWmLEUTwGyxkKZ[i]._actionId == P_1)
				{
					return i;
				}
			}
			return -1;
		}
		throw new NotImplementedException();
	}

	internal int sptHkNZGmMVgqEQejXPbAHZlhPYp(int P_0)
	{
		if (xcxDlZIoeuhvFHVWmLEUTwGyxkKZ == null)
		{
			return -1;
		}
		int count = xcxDlZIoeuhvFHVWmLEUTwGyxkKZ.Count;
		for (int i = 0; i < count; i++)
		{
			if (xcxDlZIoeuhvFHVWmLEUTwGyxkKZ[i].LQceMJAxYgRpolrwLwsLBxilJMmNA == P_0)
			{
				return i;
			}
		}
		return -1;
	}

	internal int SRWIAdXqsHyNQGLwArFtNcwDdIsHA(bool P_0, List<ActionElementMap> P_1, bool P_2)
	{
		if (P_1 == null)
		{
			throw new ArgumentNullException("results");
		}
		if (!P_2)
		{
			P_1.Clear();
		}
		int num = axisMapCount;
		int num2 = 0;
		for (int i = 0; i < num; i++)
		{
			ActionElementMap actionElementMap = xcxDlZIoeuhvFHVWmLEUTwGyxkKZ[i];
			if (!P_0 || actionElementMap.YbgQyWQdQcTTSlKYNScpqBbjmQQo)
			{
				P_1.Add(actionElementMap);
				num2++;
			}
		}
		return num2;
	}

	internal int jYwGpXSGaXGVHUvYLtxyHEAXqYHi(int P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
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
		int num = axisMapCount;
		int num2 = 0;
		for (int i = 0; i < num; i++)
		{
			ActionElementMap actionElementMap = xcxDlZIoeuhvFHVWmLEUTwGyxkKZ[i];
			if (actionElementMap._actionId == P_0 && (!P_1 || actionElementMap.YbgQyWQdQcTTSlKYNScpqBbjmQQo))
			{
				P_2.Add(actionElementMap);
				num2++;
			}
		}
		return num2;
	}

	internal virtual int qdQjmNtYJujAcmEKvKqAcoaIEMIr(int P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
	{
		int num = base.udqxaEGIrvufGdIfXccpPRDnNltr(P_0, P_1, P_2, P_3);
		if (P_0 < 0)
		{
			return num;
		}
		int num2 = axisMapCount;
		for (int i = 0; i < num2; i++)
		{
			ActionElementMap actionElementMap = xcxDlZIoeuhvFHVWmLEUTwGyxkKZ[i];
			if (actionElementMap._actionId == P_0 && (!P_1 || actionElementMap.YbgQyWQdQcTTSlKYNScpqBbjmQQo))
			{
				P_2.Add(actionElementMap);
				num++;
			}
		}
		return num;
	}

	internal virtual ActionElementMap PUfLBjXaPYQFdwmCzMoAbSaXBxQn(IControllerElementTarget P_0, bool P_1, int P_2, bool P_3, out bool P_4)
	{
		ActionElementMap actionElementMap = base.rWGkzCaHmFroxLHHiILXPuevKYvo(P_0, P_1, P_2, P_3, out P_4);
		if (actionElementMap != null)
		{
			return actionElementMap;
		}
		if (P_4)
		{
			return null;
		}
		if (!yIxyWYIcyGilnzBfcZCyuqyiGwtm(P_0.elementType))
		{
			return null;
		}
		int num = axisMapCount;
		_ = P_0.elementIdentifierId;
		for (int i = 0; i < num; i++)
		{
			if ((!P_1 || xcxDlZIoeuhvFHVWmLEUTwGyxkKZ[i]._actionId == P_2) && (!P_3 || xcxDlZIoeuhvFHVWmLEUTwGyxkKZ[i].YbgQyWQdQcTTSlKYNScpqBbjmQQo) && xcxDlZIoeuhvFHVWmLEUTwGyxkKZ[i].IsTarget(P_0))
			{
				return xcxDlZIoeuhvFHVWmLEUTwGyxkKZ[i];
			}
		}
		return null;
	}

	internal virtual int PewjNkhSNfbSxBLFUzKOcbdpVhAT(IControllerElementTarget P_0, bool P_1, int P_2, bool P_3, List<ActionElementMap> P_4, bool P_5, out bool P_6)
	{
		int num = base.AQsAVNZYhsajiONJBaCUyUaUYtSD(P_0, P_1, P_2, P_3, P_4, P_5, out P_6);
		if (P_6)
		{
			return num;
		}
		if (!yIxyWYIcyGilnzBfcZCyuqyiGwtm(P_0.elementType))
		{
			return num;
		}
		int num2 = axisMapCount;
		_ = P_0.elementIdentifierId;
		for (int i = 0; i < num2; i++)
		{
			if ((!P_1 || xcxDlZIoeuhvFHVWmLEUTwGyxkKZ[i]._actionId == P_2) && (!P_3 || xcxDlZIoeuhvFHVWmLEUTwGyxkKZ[i].YbgQyWQdQcTTSlKYNScpqBbjmQQo) && xcxDlZIoeuhvFHVWmLEUTwGyxkKZ[i].IsTarget(P_0))
			{
				P_4.Add(xcxDlZIoeuhvFHVWmLEUTwGyxkKZ[i]);
				num++;
			}
		}
		return num;
	}

	internal virtual bool UNUUDjanziCMUJqXRmxoMPiTAHQv(ActionElementMap P_0)
	{
		if (base.deQaZFBOpCgNWqniRMdLrzJdixNM(P_0))
		{
			return true;
		}
		if (P_0 == null)
		{
			return false;
		}
		if (!yIxyWYIcyGilnzBfcZCyuqyiGwtm(P_0._elementType))
		{
			return false;
		}
		xcxDlZIoeuhvFHVWmLEUTwGyxkKZ.Add(P_0);
		nQzXEGXyrsNYEgyMbuxNvTkiZloL(P_0);
		return true;
	}

	private bool yIxyWYIcyGilnzBfcZCyuqyiGwtm(ControllerElementType P_0)
	{
		if (P_0 != ControllerElementType.Axis)
		{
			return false;
		}
		return true;
	}

	private void FldzoUNEtpOurmQvHOKibxpXrMRX(int P_0, int P_1)
	{
		dTxetHHpwSYSVITeJpRmHqGvpYKC(P_0);
		if (P_1 >= 0 && P_1 < axisMapCount)
		{
			xcxDlZIoeuhvFHVWmLEUTwGyxkKZ.RemoveAt(P_1);
		}
	}

	private void xDYgfdsGASInnbCNqHQBgKxLpzIb(ActionElementMap P_0)
	{
		if (P_0 != null)
		{
			xcxDlZIoeuhvFHVWmLEUTwGyxkKZ.Add(P_0);
			nQzXEGXyrsNYEgyMbuxNvTkiZloL(P_0);
		}
	}

	private void lkexkgDkalnESADbOCAXbbOrkRjwA(ActionElementMap P_0, int P_1)
	{
		if (P_0 != null && P_1 >= 0 && P_1 < axisMapCount)
		{
			DabGVqGkjVCrAaZUoMmtihRKqztiA(xcxDlZIoeuhvFHVWmLEUTwGyxkKZ[P_1].LQceMJAxYgRpolrwLwsLBxilJMmNA, P_0);
			xcxDlZIoeuhvFHVWmLEUTwGyxkKZ[P_1] = P_0;
		}
	}

	internal virtual void uZnXGMBlsZKfgCjiiAcgHrVhDLup(SerializedObject P_0)
	{
		base.BNpIdecNpOvclDkjTvyqXJeXbzNe(P_0);
		int num = axisMapCount;
		List<object> list = new List<object>();
		P_0.Add("axisMaps", list);
		for (int i = 0; i < num; i++)
		{
			if (xcxDlZIoeuhvFHVWmLEUTwGyxkKZ[i] != null)
			{
				list.Add(xcxDlZIoeuhvFHVWmLEUTwGyxkKZ[i].PZscFcCQiIyEnvscKrVjbjPwaven());
			}
		}
	}

	internal virtual bool aHrBLyaMwMbIuJiqViFfpwrjFqOh(SerializedObject P_0)
	{
		bool flag = base.uqZbaxHuqiqBimqckBuyQZOOGZv(P_0);
		if (!flag)
		{
			ClearElementMaps();
			flag = true;
		}
		SerializedObject value = null;
		if (P_0.TryGetDeserializedValueByRef("axisMaps", ref value) && value != null)
		{
			for (int i = 0; i < value.count; i++)
			{
				if (value.TryGetDeserializedValue<SerializedObject>(i, out var value2) || value2 == null)
				{
					ActionElementMap actionElementMap = new ActionElementMap();
					actionElementMap.TuhwQSoJBLXzpOCVRndSVrhfkUhT(value2);
					if (ActionElementMap.RduNEuGTbuBDPjdvcnEmZyZvhVty(actionElementMap))
					{
						xDYgfdsGASInnbCNqHQBgKxLpzIb(actionElementMap);
					}
				}
			}
		}
		return flag;
	}

	[CompilerGenerated]
	[DebuggerHidden]
	private IEnumerable<ElementAssignmentConflictInfo> PUzOirenxzKETOQWIEidPxmiFzEd(ControllerMap P_0, bool P_1)
	{
		return base.ElementAssignmentConflicts(P_0, P_1);
	}

	[CompilerGenerated]
	[DebuggerHidden]
	private IEnumerable<ElementAssignmentConflictInfo> utotNZDJpUzEPvuQuYqrJNEcIdCH(ActionElementMap P_0, bool P_1)
	{
		return base.ElementAssignmentConflicts(P_0, P_1);
	}

	[CompilerGenerated]
	[DebuggerHidden]
	private IEnumerable<ElementAssignmentConflictInfo> kOrvGYKVSekTmBwBtKMqYHOsXXMi(ElementAssignmentConflictCheck P_0, bool P_1)
	{
		return base.ElementAssignmentConflicts(P_0, P_1);
	}
}
