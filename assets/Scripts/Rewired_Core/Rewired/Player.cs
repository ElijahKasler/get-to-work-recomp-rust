using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using Rewired.Config;
using Rewired.Internal.Localization;
using Rewired.Utils;
using Rewired.Utils.Classes;
using Rewired.Utils.Classes.Data;
using UnityEngine;

namespace Rewired;

public sealed class Player : JPyUCjMynlgXcSTGrAuSOGxEMeWJ
{
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public sealed class ControllerHelper
	{
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public sealed class ConflictCheckingHelper : CodeHelper
		{
			private sealed class QXQNJwNiPsFdXsXPWglJzEMRbXHZ : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
			{
				private int pmnOEKSGJEdghjbfTlOrHwrOgPNL;

				private ElementAssignmentConflictInfo UnJTKyKdQtrWBeZzsqlYERFQJZvr;

				private int LHATKLBgHvRfoqptoHwjFfrmnByI;

				private int jfBYyhUbQoVLiFJMJHVgrQVMeKyZ;

				public int uRdhXBeCqOOvPDUFOXnwoemyxQxx;

				private CustomControllerMap dQanqYapyApGWwXQNLIjFQsPhEiw;

				public CustomControllerMap XkNLxDLuTYJCZvMAFsEkUGpRMjEv;

				public ConflictCheckingHelper crDlyLqEVkOJcjfsHfoMEaGtNoaGb;

				private bool PPwsDxNGvZwFgmGtjCOrlXaDPSKf;

				public bool fjoULhLKrjHbnuqTbrAOTSzRfdTS;

				private bool ThKbvwOYudAHZrrZLFdXJjiZtnuh;

				public bool sDkbHKDKatKtIhRzjOQtErGxOGcQA;

				private int YXAEebvAxMQrnadsbdzLeGGpJxCb;

				private IEnumerator<ElementAssignmentConflictInfo> MULEUdbENcKqSddWGldbLzFQGezcB;

				ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
				{
					[DebuggerHidden]
					get
					{
						return UnJTKyKdQtrWBeZzsqlYERFQJZvr;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return UnJTKyKdQtrWBeZzsqlYERFQJZvr;
					}
				}

				[DebuggerHidden]
				public QXQNJwNiPsFdXsXPWglJzEMRbXHZ(int P_0)
				{
					pmnOEKSGJEdghjbfTlOrHwrOgPNL = P_0;
					LHATKLBgHvRfoqptoHwjFfrmnByI = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					int num = pmnOEKSGJEdghjbfTlOrHwrOgPNL;
					if (num == -3 || num == 1)
					{
						try
						{
						}
						finally
						{
							hhoooKzvrHECuvswBROxzRBjRjRk();
						}
					}
				}

				private bool MoveNext()
				{
					try
					{
						int num = pmnOEKSGJEdghjbfTlOrHwrOgPNL;
						ConflictCheckingHelper conflictCheckingHelper = crDlyLqEVkOJcjfsHfoMEaGtNoaGb;
						if (num != 0)
						{
							if (num != 1)
							{
								return false;
							}
							pmnOEKSGJEdghjbfTlOrHwrOgPNL = -3;
							goto IL_00eb;
						}
						pmnOEKSGJEdghjbfTlOrHwrOgPNL = -1;
						if (jfBYyhUbQoVLiFJMJHVgrQVMeKyZ < 0 || dQanqYapyApGWwXQNLIjFQsPhEiw == null)
						{
							return false;
						}
						YXAEebvAxMQrnadsbdzLeGGpJxCb = 0;
						goto IL_0117;
						IL_00eb:
						if (MULEUdbENcKqSddWGldbLzFQGezcB.MoveNext())
						{
							ElementAssignmentConflictInfo current = MULEUdbENcKqSddWGldbLzFQGezcB.Current;
							UnJTKyKdQtrWBeZzsqlYERFQJZvr = current;
							pmnOEKSGJEdghjbfTlOrHwrOgPNL = 1;
							return true;
						}
						hhoooKzvrHECuvswBROxzRBjRjRk();
						MULEUdbENcKqSddWGldbLzFQGezcB = null;
						goto IL_0105;
						IL_0117:
						if (YXAEebvAxMQrnadsbdzLeGGpJxCb < conflictCheckingHelper.eiqsZVPHBaSbtbaEQWQevZlaNXhK.QrSKTUzPSjlCKZGLJDqOVrJyplcf().rphZqyUfbdoINyXndGfDbQaiIHFM())
						{
							if (conflictCheckingHelper.eiqsZVPHBaSbtbaEQWQevZlaNXhK.QrSKTUzPSjlCKZGLJDqOVrJyplcf().IqlJUjIBLQbuSkAhcRvowzpPOQIC(YXAEebvAxMQrnadsbdzLeGGpJxCb).vEpnAhSIoVrCnOfAmeqwGuTGoWnB.id == jfBYyhUbQoVLiFJMJHVgrQVMeKyZ)
							{
								MULEUdbENcKqSddWGldbLzFQGezcB = conflictCheckingHelper.PZeHctZEgnZEAlGnDwqoALlTosXv(ControllerType.Custom, jfBYyhUbQoVLiFJMJHVgrQVMeKyZ, dQanqYapyApGWwXQNLIjFQsPhEiw, PPwsDxNGvZwFgmGtjCOrlXaDPSKf, ThKbvwOYudAHZrrZLFdXJjiZtnuh, conflictCheckingHelper.eiqsZVPHBaSbtbaEQWQevZlaNXhK.QrSKTUzPSjlCKZGLJDqOVrJyplcf().IqlJUjIBLQbuSkAhcRvowzpPOQIC(YXAEebvAxMQrnadsbdzLeGGpJxCb).urKiLjIJcqceLbXuNYNvuMSWJkNF).GetEnumerator();
								pmnOEKSGJEdghjbfTlOrHwrOgPNL = -3;
								goto IL_00eb;
							}
							goto IL_0105;
						}
						return false;
						IL_0105:
						YXAEebvAxMQrnadsbdzLeGGpJxCb++;
						goto IL_0117;
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

				private void hhoooKzvrHECuvswBROxzRBjRjRk()
				{
					pmnOEKSGJEdghjbfTlOrHwrOgPNL = -1;
					if (MULEUdbENcKqSddWGldbLzFQGezcB != null)
					{
						MULEUdbENcKqSddWGldbLzFQGezcB.Dispose();
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
					QXQNJwNiPsFdXsXPWglJzEMRbXHZ qXQNJwNiPsFdXsXPWglJzEMRbXHZ;
					if (pmnOEKSGJEdghjbfTlOrHwrOgPNL == -2 && LHATKLBgHvRfoqptoHwjFfrmnByI == Environment.CurrentManagedThreadId)
					{
						pmnOEKSGJEdghjbfTlOrHwrOgPNL = 0;
						qXQNJwNiPsFdXsXPWglJzEMRbXHZ = this;
					}
					else
					{
						qXQNJwNiPsFdXsXPWglJzEMRbXHZ = new QXQNJwNiPsFdXsXPWglJzEMRbXHZ(0);
						qXQNJwNiPsFdXsXPWglJzEMRbXHZ.crDlyLqEVkOJcjfsHfoMEaGtNoaGb = crDlyLqEVkOJcjfsHfoMEaGtNoaGb;
					}
					qXQNJwNiPsFdXsXPWglJzEMRbXHZ.jfBYyhUbQoVLiFJMJHVgrQVMeKyZ = uRdhXBeCqOOvPDUFOXnwoemyxQxx;
					qXQNJwNiPsFdXsXPWglJzEMRbXHZ.dQanqYapyApGWwXQNLIjFQsPhEiw = XkNLxDLuTYJCZvMAFsEkUGpRMjEv;
					qXQNJwNiPsFdXsXPWglJzEMRbXHZ.PPwsDxNGvZwFgmGtjCOrlXaDPSKf = fjoULhLKrjHbnuqTbrAOTSzRfdTS;
					qXQNJwNiPsFdXsXPWglJzEMRbXHZ.ThKbvwOYudAHZrrZLFdXJjiZtnuh = sDkbHKDKatKtIhRzjOQtErGxOGcQA;
					return qXQNJwNiPsFdXsXPWglJzEMRbXHZ;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
				}
			}

			private sealed class MtlEwkFiMKubSScfSrahTslThkGD : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
			{
				private int VlmdvhqnIWLXaiDLBCFpwzeIxSBV;

				private ElementAssignmentConflictInfo QkXrIeeFHyIMefWNPSpiBosYoBEeb;

				private int BhvrRRyRYCScTQjBSfXWhVvlQXUSA;

				private int SCBbnwTzhZZkPPRGHKjlUKQpFVDc;

				public int HrDAZRjKZKOVNPnngDigGsqhCoYe;

				private ActionElementMap ZviJnGRjEhMoYYDGEVWTHYcYAGPi;

				public ActionElementMap aLDnFzuNVtHfUwuQQHUuryJpqkig;

				public ConflictCheckingHelper DExoxtWQIeVPCFnOIPTUcEfngJhD;

				private CustomControllerMap gLgrwrEvwEeiJUxLTICAfCASbdsHA;

				public CustomControllerMap cSwzdQiCHOesahClAfSwPBnqTaxWA;

				private bool nOIopqBOqijVmfdirprEEdAJeaQD;

				public bool mGvwWHZamBxNmGkeSePBLQooQbkR;

				private bool EECXMglARiqsBFuFANWPpAfSXYJj;

				public bool hdDkbMnNczBcmhYfccyjsrMosPYd;

				private int OjppEPtBHIdHTaSUfeexzXebNjPv;

				private IEnumerator<ElementAssignmentConflictInfo> IxFwJTXWDnBtsxflHGGdCKHSuKEuA;

				ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
				{
					[DebuggerHidden]
					get
					{
						return QkXrIeeFHyIMefWNPSpiBosYoBEeb;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return QkXrIeeFHyIMefWNPSpiBosYoBEeb;
					}
				}

				[DebuggerHidden]
				public MtlEwkFiMKubSScfSrahTslThkGD(int P_0)
				{
					VlmdvhqnIWLXaiDLBCFpwzeIxSBV = P_0;
					BhvrRRyRYCScTQjBSfXWhVvlQXUSA = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					int vlmdvhqnIWLXaiDLBCFpwzeIxSBV = VlmdvhqnIWLXaiDLBCFpwzeIxSBV;
					if (vlmdvhqnIWLXaiDLBCFpwzeIxSBV == -3 || vlmdvhqnIWLXaiDLBCFpwzeIxSBV == 1)
					{
						try
						{
						}
						finally
						{
							qvfgXqUFDBDxAOsQMWHXoDSUBotFA();
						}
					}
				}

				private bool MoveNext()
				{
					try
					{
						int vlmdvhqnIWLXaiDLBCFpwzeIxSBV = VlmdvhqnIWLXaiDLBCFpwzeIxSBV;
						ConflictCheckingHelper dExoxtWQIeVPCFnOIPTUcEfngJhD = DExoxtWQIeVPCFnOIPTUcEfngJhD;
						if (vlmdvhqnIWLXaiDLBCFpwzeIxSBV != 0)
						{
							if (vlmdvhqnIWLXaiDLBCFpwzeIxSBV != 1)
							{
								return false;
							}
							VlmdvhqnIWLXaiDLBCFpwzeIxSBV = -3;
							goto IL_00f1;
						}
						VlmdvhqnIWLXaiDLBCFpwzeIxSBV = -1;
						if (SCBbnwTzhZZkPPRGHKjlUKQpFVDc < 0 || ZviJnGRjEhMoYYDGEVWTHYcYAGPi == null)
						{
							return false;
						}
						OjppEPtBHIdHTaSUfeexzXebNjPv = 0;
						goto IL_011d;
						IL_00f1:
						if (IxFwJTXWDnBtsxflHGGdCKHSuKEuA.MoveNext())
						{
							ElementAssignmentConflictInfo current = IxFwJTXWDnBtsxflHGGdCKHSuKEuA.Current;
							QkXrIeeFHyIMefWNPSpiBosYoBEeb = current;
							VlmdvhqnIWLXaiDLBCFpwzeIxSBV = 1;
							return true;
						}
						qvfgXqUFDBDxAOsQMWHXoDSUBotFA();
						IxFwJTXWDnBtsxflHGGdCKHSuKEuA = null;
						goto IL_010b;
						IL_011d:
						if (OjppEPtBHIdHTaSUfeexzXebNjPv < dExoxtWQIeVPCFnOIPTUcEfngJhD.eiqsZVPHBaSbtbaEQWQevZlaNXhK.QrSKTUzPSjlCKZGLJDqOVrJyplcf().rphZqyUfbdoINyXndGfDbQaiIHFM())
						{
							if (dExoxtWQIeVPCFnOIPTUcEfngJhD.eiqsZVPHBaSbtbaEQWQevZlaNXhK.QrSKTUzPSjlCKZGLJDqOVrJyplcf().IqlJUjIBLQbuSkAhcRvowzpPOQIC(OjppEPtBHIdHTaSUfeexzXebNjPv).vEpnAhSIoVrCnOfAmeqwGuTGoWnB.id == SCBbnwTzhZZkPPRGHKjlUKQpFVDc)
							{
								IxFwJTXWDnBtsxflHGGdCKHSuKEuA = dExoxtWQIeVPCFnOIPTUcEfngJhD.nnrAnrmVqGqiiUDbLllpALDTVtBj(ControllerType.Custom, SCBbnwTzhZZkPPRGHKjlUKQpFVDc, gLgrwrEvwEeiJUxLTICAfCASbdsHA, ZviJnGRjEhMoYYDGEVWTHYcYAGPi, nOIopqBOqijVmfdirprEEdAJeaQD, EECXMglARiqsBFuFANWPpAfSXYJj, dExoxtWQIeVPCFnOIPTUcEfngJhD.eiqsZVPHBaSbtbaEQWQevZlaNXhK.QrSKTUzPSjlCKZGLJDqOVrJyplcf().IqlJUjIBLQbuSkAhcRvowzpPOQIC(OjppEPtBHIdHTaSUfeexzXebNjPv).urKiLjIJcqceLbXuNYNvuMSWJkNF).GetEnumerator();
								VlmdvhqnIWLXaiDLBCFpwzeIxSBV = -3;
								goto IL_00f1;
							}
							goto IL_010b;
						}
						return false;
						IL_010b:
						OjppEPtBHIdHTaSUfeexzXebNjPv++;
						goto IL_011d;
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

				private void qvfgXqUFDBDxAOsQMWHXoDSUBotFA()
				{
					VlmdvhqnIWLXaiDLBCFpwzeIxSBV = -1;
					if (IxFwJTXWDnBtsxflHGGdCKHSuKEuA != null)
					{
						IxFwJTXWDnBtsxflHGGdCKHSuKEuA.Dispose();
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
					MtlEwkFiMKubSScfSrahTslThkGD mtlEwkFiMKubSScfSrahTslThkGD;
					if (VlmdvhqnIWLXaiDLBCFpwzeIxSBV == -2 && BhvrRRyRYCScTQjBSfXWhVvlQXUSA == Environment.CurrentManagedThreadId)
					{
						VlmdvhqnIWLXaiDLBCFpwzeIxSBV = 0;
						mtlEwkFiMKubSScfSrahTslThkGD = this;
					}
					else
					{
						mtlEwkFiMKubSScfSrahTslThkGD = new MtlEwkFiMKubSScfSrahTslThkGD(0);
						mtlEwkFiMKubSScfSrahTslThkGD.DExoxtWQIeVPCFnOIPTUcEfngJhD = DExoxtWQIeVPCFnOIPTUcEfngJhD;
					}
					mtlEwkFiMKubSScfSrahTslThkGD.SCBbnwTzhZZkPPRGHKjlUKQpFVDc = HrDAZRjKZKOVNPnngDigGsqhCoYe;
					mtlEwkFiMKubSScfSrahTslThkGD.gLgrwrEvwEeiJUxLTICAfCASbdsHA = cSwzdQiCHOesahClAfSwPBnqTaxWA;
					mtlEwkFiMKubSScfSrahTslThkGD.ZviJnGRjEhMoYYDGEVWTHYcYAGPi = aLDnFzuNVtHfUwuQQHUuryJpqkig;
					mtlEwkFiMKubSScfSrahTslThkGD.nOIopqBOqijVmfdirprEEdAJeaQD = mGvwWHZamBxNmGkeSePBLQooQbkR;
					mtlEwkFiMKubSScfSrahTslThkGD.EECXMglARiqsBFuFANWPpAfSXYJj = hdDkbMnNczBcmhYfccyjsrMosPYd;
					return mtlEwkFiMKubSScfSrahTslThkGD;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
				}
			}

			private sealed class WrIYasTbJUDGDeibqYIVwfIcXLwCA : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
			{
				private int ryPaeOIuwwnGubtBUsNJfOmkFKTU;

				private ElementAssignmentConflictInfo MwHBvUlCCmJEljoqdoISZCQGZMgO;

				private int UrMshWjWPdNuniVqTrWVEDjgoHX;

				private ElementAssignmentConflictCheck rkZdyMzhEFTVPaLHpYWDldeOlvQs;

				public ElementAssignmentConflictCheck tRRgiiuOIrQqeWvGKFHLCyuFsUIW;

				public ConflictCheckingHelper QOJeYJWIUzblKWSSdirypItDZVCM;

				private bool CPxgkBOVCinrgDFIiqJDoBNDBGHt;

				public bool bajcoGhdmcVOmOlnzaUJrVOizvCjA;

				private bool bCLEMDSdzUajkrFMZfDPXBbPffdC;

				public bool qWdHKVFuvDORlgKDtQULVLCndZcj;

				private int bqGKovpYpjBYufypBrPjQMftNxeo;

				private IEnumerator<ElementAssignmentConflictInfo> vXZyEiGSgzUwqHVMxPPtiDxRjbgs;

				ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
				{
					[DebuggerHidden]
					get
					{
						return MwHBvUlCCmJEljoqdoISZCQGZMgO;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return MwHBvUlCCmJEljoqdoISZCQGZMgO;
					}
				}

				[DebuggerHidden]
				public WrIYasTbJUDGDeibqYIVwfIcXLwCA(int P_0)
				{
					ryPaeOIuwwnGubtBUsNJfOmkFKTU = P_0;
					UrMshWjWPdNuniVqTrWVEDjgoHX = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					int num = ryPaeOIuwwnGubtBUsNJfOmkFKTU;
					if (num == -3 || num == 1)
					{
						try
						{
						}
						finally
						{
							fRxCwWecWZYgoPtBedtNoaKsdUOU();
						}
					}
				}

				private bool MoveNext()
				{
					try
					{
						int num = ryPaeOIuwwnGubtBUsNJfOmkFKTU;
						ConflictCheckingHelper qOJeYJWIUzblKWSSdirypItDZVCM = QOJeYJWIUzblKWSSdirypItDZVCM;
						if (num != 0)
						{
							if (num != 1)
							{
								return false;
							}
							ryPaeOIuwwnGubtBUsNJfOmkFKTU = -3;
							goto IL_00f3;
						}
						ryPaeOIuwwnGubtBUsNJfOmkFKTU = -1;
						if (rkZdyMzhEFTVPaLHpYWDldeOlvQs.controllerId < 0 || rkZdyMzhEFTVPaLHpYWDldeOlvQs.elementAssignmentType == ElementAssignmentType.KeyboardKey)
						{
							return false;
						}
						bqGKovpYpjBYufypBrPjQMftNxeo = 0;
						goto IL_011f;
						IL_00f3:
						if (vXZyEiGSgzUwqHVMxPPtiDxRjbgs.MoveNext())
						{
							ElementAssignmentConflictInfo current = vXZyEiGSgzUwqHVMxPPtiDxRjbgs.Current;
							MwHBvUlCCmJEljoqdoISZCQGZMgO = current;
							ryPaeOIuwwnGubtBUsNJfOmkFKTU = 1;
							return true;
						}
						fRxCwWecWZYgoPtBedtNoaKsdUOU();
						vXZyEiGSgzUwqHVMxPPtiDxRjbgs = null;
						goto IL_010d;
						IL_011f:
						if (bqGKovpYpjBYufypBrPjQMftNxeo < qOJeYJWIUzblKWSSdirypItDZVCM.eiqsZVPHBaSbtbaEQWQevZlaNXhK.QrSKTUzPSjlCKZGLJDqOVrJyplcf().rphZqyUfbdoINyXndGfDbQaiIHFM())
						{
							if (qOJeYJWIUzblKWSSdirypItDZVCM.eiqsZVPHBaSbtbaEQWQevZlaNXhK.QrSKTUzPSjlCKZGLJDqOVrJyplcf().IqlJUjIBLQbuSkAhcRvowzpPOQIC(bqGKovpYpjBYufypBrPjQMftNxeo).vEpnAhSIoVrCnOfAmeqwGuTGoWnB.id == rkZdyMzhEFTVPaLHpYWDldeOlvQs.controllerId)
							{
								vXZyEiGSgzUwqHVMxPPtiDxRjbgs = qOJeYJWIUzblKWSSdirypItDZVCM.AaFoiqrRMxwJhqGuYjxGLocMtIft(rkZdyMzhEFTVPaLHpYWDldeOlvQs, CPxgkBOVCinrgDFIiqJDoBNDBGHt, bCLEMDSdzUajkrFMZfDPXBbPffdC, qOJeYJWIUzblKWSSdirypItDZVCM.eiqsZVPHBaSbtbaEQWQevZlaNXhK.QrSKTUzPSjlCKZGLJDqOVrJyplcf().IqlJUjIBLQbuSkAhcRvowzpPOQIC(bqGKovpYpjBYufypBrPjQMftNxeo).urKiLjIJcqceLbXuNYNvuMSWJkNF).GetEnumerator();
								ryPaeOIuwwnGubtBUsNJfOmkFKTU = -3;
								goto IL_00f3;
							}
							goto IL_010d;
						}
						return false;
						IL_010d:
						bqGKovpYpjBYufypBrPjQMftNxeo++;
						goto IL_011f;
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

				private void fRxCwWecWZYgoPtBedtNoaKsdUOU()
				{
					ryPaeOIuwwnGubtBUsNJfOmkFKTU = -1;
					if (vXZyEiGSgzUwqHVMxPPtiDxRjbgs != null)
					{
						vXZyEiGSgzUwqHVMxPPtiDxRjbgs.Dispose();
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
					WrIYasTbJUDGDeibqYIVwfIcXLwCA wrIYasTbJUDGDeibqYIVwfIcXLwCA;
					if (ryPaeOIuwwnGubtBUsNJfOmkFKTU == -2 && UrMshWjWPdNuniVqTrWVEDjgoHX == Environment.CurrentManagedThreadId)
					{
						ryPaeOIuwwnGubtBUsNJfOmkFKTU = 0;
						wrIYasTbJUDGDeibqYIVwfIcXLwCA = this;
					}
					else
					{
						wrIYasTbJUDGDeibqYIVwfIcXLwCA = new WrIYasTbJUDGDeibqYIVwfIcXLwCA(0);
						wrIYasTbJUDGDeibqYIVwfIcXLwCA.QOJeYJWIUzblKWSSdirypItDZVCM = QOJeYJWIUzblKWSSdirypItDZVCM;
					}
					wrIYasTbJUDGDeibqYIVwfIcXLwCA.rkZdyMzhEFTVPaLHpYWDldeOlvQs = tRRgiiuOIrQqeWvGKFHLCyuFsUIW;
					wrIYasTbJUDGDeibqYIVwfIcXLwCA.CPxgkBOVCinrgDFIiqJDoBNDBGHt = bajcoGhdmcVOmOlnzaUJrVOizvCjA;
					wrIYasTbJUDGDeibqYIVwfIcXLwCA.bCLEMDSdzUajkrFMZfDPXBbPffdC = qWdHKVFuvDORlgKDtQULVLCndZcj;
					return wrIYasTbJUDGDeibqYIVwfIcXLwCA;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
				}
			}

			private sealed class zGsFyRIiixeHlkFpbXNOPkOingfYA<_0001> : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable where _0001 : ControllerMap
			{
				private int GbylNbmGQFYnqUcMykxZIdPQeRiL;

				private ElementAssignmentConflictInfo NvljXNHpJBdUHGKHJktDiNPruOVe;

				private int vYGEXviOiYmxliVxQiLZjDDJciPSA;

				private global::rspbeSfkijiKRfPuAyBrBqKNCACZB<_0001> LZrCXgEmpWhUuoUpESrhKwnHTtYn;

				public global::rspbeSfkijiKRfPuAyBrBqKNCACZB<_0001> ccUiqJAOpDxLFtuqxGifiRWbrWbXb;

				private _0001 mOeARdivpfKxPuILvNOleNmSCPDC;

				public _0001 ReoKGwmnCrqdWKzJkPkGXAlxeuYgA;

				private bool KVgqObqoZFvBjzgVejBJBufFKkvk;

				public bool ebYnRSWbTgeXTRULEgrFpMPBDjtAA;

				private bool NdOkAyGwujaXMziaCxOzAKvClLhJ;

				public bool vlFosEWUayzdTROucnjoBPEgVmim;

				public ConflictCheckingHelper RhhRoLqIuQHwQWFLevryMfwRvnPm;

				private ControllerType ukYrHZNbtoJYoloBvCLFzaaSWALc;

				public ControllerType zPaaesIBBVcWlDcLnaFQFPcaKhogc;

				private int PKAQFLdYhXzxucjRAuExyVLpsLFe;

				public int MVvEqOyUyrshSHdRJdQlHnlwLLNq;

				private InputMapCategory TpMCIEBlwxEPgbtIETjpmpUqIRqpb;

				private int dfBYIJhRgJxTvfyCawAlWuncLESS;

				private IEnumerator<ElementAssignmentConflictInfo> WeRmMAEbqjcoVmYmcgznPJbRyacc;

				ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
				{
					[DebuggerHidden]
					get
					{
						return NvljXNHpJBdUHGKHJktDiNPruOVe;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return NvljXNHpJBdUHGKHJktDiNPruOVe;
					}
				}

				[DebuggerHidden]
				public zGsFyRIiixeHlkFpbXNOPkOingfYA(int P_0)
				{
					GbylNbmGQFYnqUcMykxZIdPQeRiL = P_0;
					vYGEXviOiYmxliVxQiLZjDDJciPSA = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					int gbylNbmGQFYnqUcMykxZIdPQeRiL = GbylNbmGQFYnqUcMykxZIdPQeRiL;
					if (gbylNbmGQFYnqUcMykxZIdPQeRiL == -3 || gbylNbmGQFYnqUcMykxZIdPQeRiL == 1)
					{
						try
						{
						}
						finally
						{
							kNOuRjjRzUGoZidlzvxycnsOdjat();
						}
					}
				}

				private bool MoveNext()
				{
					try
					{
						int gbylNbmGQFYnqUcMykxZIdPQeRiL = GbylNbmGQFYnqUcMykxZIdPQeRiL;
						ConflictCheckingHelper rhhRoLqIuQHwQWFLevryMfwRvnPm = RhhRoLqIuQHwQWFLevryMfwRvnPm;
						if (gbylNbmGQFYnqUcMykxZIdPQeRiL != 0)
						{
							if (gbylNbmGQFYnqUcMykxZIdPQeRiL != 1)
							{
								return false;
							}
							GbylNbmGQFYnqUcMykxZIdPQeRiL = -3;
							goto IL_014a;
						}
						GbylNbmGQFYnqUcMykxZIdPQeRiL = -1;
						if (LZrCXgEmpWhUuoUpESrhKwnHTtYn == null || mOeARdivpfKxPuILvNOleNmSCPDC == null)
						{
							return false;
						}
						TpMCIEBlwxEPgbtIETjpmpUqIRqpb = ReInput.mapping.GetMapCategory(mOeARdivpfKxPuILvNOleNmSCPDC.categoryId);
						if (TpMCIEBlwxEPgbtIETjpmpUqIRqpb == null)
						{
							return false;
						}
						dfBYIJhRgJxTvfyCawAlWuncLESS = 0;
						goto IL_0176;
						IL_0176:
						if (dfBYIJhRgJxTvfyCawAlWuncLESS < LZrCXgEmpWhUuoUpESrhKwnHTtYn.ejOOZrUqJLRyRGoRofwTThHfNEkF())
						{
							ControllerMap controllerMap = LZrCXgEmpWhUuoUpESrhKwnHTtYn.xmIhmmDDQdCDzpiurLdyJADZcUhZ(dfBYIJhRgJxTvfyCawAlWuncLESS);
							if ((!KVgqObqoZFvBjzgVejBJBufFKkvk || controllerMap.enabled) && (NdOkAyGwujaXMziaCxOzAKvClLhJ || !rhhRoLqIuQHwQWFLevryMfwRvnPm.pJOlttBqyXtegIpOvYsIZCGBQTiE(TpMCIEBlwxEPgbtIETjpmpUqIRqpb, controllerMap)))
							{
								WeRmMAEbqjcoVmYmcgznPJbRyacc = controllerMap.ElementAssignmentConflicts(mOeARdivpfKxPuILvNOleNmSCPDC, KVgqObqoZFvBjzgVejBJBufFKkvk).GetEnumerator();
								GbylNbmGQFYnqUcMykxZIdPQeRiL = -3;
								goto IL_014a;
							}
							goto IL_0164;
						}
						return false;
						IL_014a:
						if (WeRmMAEbqjcoVmYmcgznPJbRyacc.MoveNext())
						{
							ElementAssignmentConflictInfo current = WeRmMAEbqjcoVmYmcgznPJbRyacc.Current;
							ElementAssignmentConflictInfo nvljXNHpJBdUHGKHJktDiNPruOVe = new ElementAssignmentConflictInfo(current);
							nvljXNHpJBdUHGKHJktDiNPruOVe.bKzpvKwtktjTHYQffDSpfhOhitkeA(rhhRoLqIuQHwQWFLevryMfwRvnPm.TfoucHypqXIoiHkDDwOxTdWZLZEP.CgPagdlzMlCQxkbRTPOoePMzAXof);
							nvljXNHpJBdUHGKHJktDiNPruOVe.EoyQWIWraMCOIRiEZcPMHqupDMpjb(ukYrHZNbtoJYoloBvCLFzaaSWALc);
							nvljXNHpJBdUHGKHJktDiNPruOVe.VEPDjqRWGYvCvlrhGuytJCLJqVBl(PKAQFLdYhXzxucjRAuExyVLpsLFe);
							NvljXNHpJBdUHGKHJktDiNPruOVe = nvljXNHpJBdUHGKHJktDiNPruOVe;
							GbylNbmGQFYnqUcMykxZIdPQeRiL = 1;
							return true;
						}
						kNOuRjjRzUGoZidlzvxycnsOdjat();
						WeRmMAEbqjcoVmYmcgznPJbRyacc = null;
						goto IL_0164;
						IL_0164:
						dfBYIJhRgJxTvfyCawAlWuncLESS++;
						goto IL_0176;
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

				private void kNOuRjjRzUGoZidlzvxycnsOdjat()
				{
					GbylNbmGQFYnqUcMykxZIdPQeRiL = -1;
					if (WeRmMAEbqjcoVmYmcgznPJbRyacc != null)
					{
						WeRmMAEbqjcoVmYmcgznPJbRyacc.Dispose();
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
					zGsFyRIiixeHlkFpbXNOPkOingfYA<_0001> zGsFyRIiixeHlkFpbXNOPkOingfYA2;
					if (GbylNbmGQFYnqUcMykxZIdPQeRiL == -2 && vYGEXviOiYmxliVxQiLZjDDJciPSA == Environment.CurrentManagedThreadId)
					{
						GbylNbmGQFYnqUcMykxZIdPQeRiL = 0;
						zGsFyRIiixeHlkFpbXNOPkOingfYA2 = this;
					}
					else
					{
						zGsFyRIiixeHlkFpbXNOPkOingfYA2 = new zGsFyRIiixeHlkFpbXNOPkOingfYA<_0001>(0);
						zGsFyRIiixeHlkFpbXNOPkOingfYA2.RhhRoLqIuQHwQWFLevryMfwRvnPm = RhhRoLqIuQHwQWFLevryMfwRvnPm;
					}
					zGsFyRIiixeHlkFpbXNOPkOingfYA2.ukYrHZNbtoJYoloBvCLFzaaSWALc = zPaaesIBBVcWlDcLnaFQFPcaKhogc;
					zGsFyRIiixeHlkFpbXNOPkOingfYA2.PKAQFLdYhXzxucjRAuExyVLpsLFe = MVvEqOyUyrshSHdRJdQlHnlwLLNq;
					zGsFyRIiixeHlkFpbXNOPkOingfYA2.mOeARdivpfKxPuILvNOleNmSCPDC = ReoKGwmnCrqdWKzJkPkGXAlxeuYgA;
					zGsFyRIiixeHlkFpbXNOPkOingfYA2.KVgqObqoZFvBjzgVejBJBufFKkvk = ebYnRSWbTgeXTRULEgrFpMPBDjtAA;
					zGsFyRIiixeHlkFpbXNOPkOingfYA2.NdOkAyGwujaXMziaCxOzAKvClLhJ = vlFosEWUayzdTROucnjoBPEgVmim;
					zGsFyRIiixeHlkFpbXNOPkOingfYA2.LZrCXgEmpWhUuoUpESrhKwnHTtYn = ccUiqJAOpDxLFtuqxGifiRWbrWbXb;
					return zGsFyRIiixeHlkFpbXNOPkOingfYA2;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
				}
			}

			private sealed class IhecbtQgULTmMCoXoGbdXVHcDIJt<_0001> : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable where _0001 : ControllerMap
			{
				private int dITakmRExBsBwNEZVAtzeoypHtYMA;

				private ElementAssignmentConflictInfo ssWVKXPiheJULXfTJtnUXVTMpykv;

				private int dlMtiLoghuAlBKdIlqOEwPLzPuHw;

				private global::rspbeSfkijiKRfPuAyBrBqKNCACZB<_0001> DNSaoraJgduwUSxKCYgEsEUpyaTUA;

				public global::rspbeSfkijiKRfPuAyBrBqKNCACZB<_0001> YExDrFoWMLaueidQULMhkSCUMJvhA;

				private ActionElementMap pszfeeAUIjjwEAHJfTQCDTsgqMwCA;

				public ActionElementMap HdBykGauGuGSikRzQxYCMJpAKjQJ;

				private _0001 TKVbWUEwYydvkcpiIdMqpcGQdkjU;

				public _0001 NDFHvcRMgNrQpKuLeHmlNfCbiIos;

				private bool SZGzytxUIHmMuDtHyeejLboIgflu;

				public bool jqnEYoMAwZMOwvOIlrRCWtscUzEM;

				private bool QJNtarZHJzguaMRUeXiXrqWuWVeK;

				public bool WFwXcRRXktrwpieLZxiETywJeLKe;

				public ConflictCheckingHelper ugAbxPbNFnFdzCCtHXctIYeriGXoA;

				private ControllerType OLdoGeFrSjZuiqHqLlalHvXZnPGM;

				public ControllerType qNRvlkYgzXeBUaNktaGsGONFmIdvA;

				private int xHOvMqggqLvmYRNqOWCajGItyzWp;

				public int chcMDPlyqeNuraRaRcmapfOrwmoR;

				private InputMapCategory XMPimXlKuwekIFaRmFdctcUTSLfh;

				private int GHmCCfYXIsMzVIgSqXHgeDFYcnNH;

				private IEnumerator<ElementAssignmentConflictInfo> WGgLBnrPGkbEQIJYizGHDimhFPmzA;

				ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
				{
					[DebuggerHidden]
					get
					{
						return ssWVKXPiheJULXfTJtnUXVTMpykv;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return ssWVKXPiheJULXfTJtnUXVTMpykv;
					}
				}

				[DebuggerHidden]
				public IhecbtQgULTmMCoXoGbdXVHcDIJt(int P_0)
				{
					dITakmRExBsBwNEZVAtzeoypHtYMA = P_0;
					dlMtiLoghuAlBKdIlqOEwPLzPuHw = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					int num = dITakmRExBsBwNEZVAtzeoypHtYMA;
					if (num == -3 || num == 1)
					{
						try
						{
						}
						finally
						{
							AQBYLQVdGcijZVWJfVfCSlDRMTFl();
						}
					}
				}

				private bool MoveNext()
				{
					try
					{
						int num = dITakmRExBsBwNEZVAtzeoypHtYMA;
						ConflictCheckingHelper conflictCheckingHelper = ugAbxPbNFnFdzCCtHXctIYeriGXoA;
						if (num != 0)
						{
							if (num != 1)
							{
								return false;
							}
							dITakmRExBsBwNEZVAtzeoypHtYMA = -3;
							goto IL_0141;
						}
						dITakmRExBsBwNEZVAtzeoypHtYMA = -1;
						if (DNSaoraJgduwUSxKCYgEsEUpyaTUA == null || pszfeeAUIjjwEAHJfTQCDTsgqMwCA == null)
						{
							return false;
						}
						XMPimXlKuwekIFaRmFdctcUTSLfh = ((TKVbWUEwYydvkcpiIdMqpcGQdkjU != null) ? ReInput.mapping.GetMapCategory(TKVbWUEwYydvkcpiIdMqpcGQdkjU.categoryId) : null);
						GHmCCfYXIsMzVIgSqXHgeDFYcnNH = 0;
						goto IL_016d;
						IL_016d:
						if (GHmCCfYXIsMzVIgSqXHgeDFYcnNH < DNSaoraJgduwUSxKCYgEsEUpyaTUA.ejOOZrUqJLRyRGoRofwTThHfNEkF())
						{
							ControllerMap controllerMap = DNSaoraJgduwUSxKCYgEsEUpyaTUA.xmIhmmDDQdCDzpiurLdyJADZcUhZ(GHmCCfYXIsMzVIgSqXHgeDFYcnNH);
							if ((!SZGzytxUIHmMuDtHyeejLboIgflu || controllerMap.enabled) && (QJNtarZHJzguaMRUeXiXrqWuWVeK || !conflictCheckingHelper.pJOlttBqyXtegIpOvYsIZCGBQTiE(XMPimXlKuwekIFaRmFdctcUTSLfh, controllerMap)))
							{
								WGgLBnrPGkbEQIJYizGHDimhFPmzA = controllerMap.ElementAssignmentConflicts(pszfeeAUIjjwEAHJfTQCDTsgqMwCA, SZGzytxUIHmMuDtHyeejLboIgflu).GetEnumerator();
								dITakmRExBsBwNEZVAtzeoypHtYMA = -3;
								goto IL_0141;
							}
							goto IL_015b;
						}
						return false;
						IL_015b:
						GHmCCfYXIsMzVIgSqXHgeDFYcnNH++;
						goto IL_016d;
						IL_0141:
						if (WGgLBnrPGkbEQIJYizGHDimhFPmzA.MoveNext())
						{
							ElementAssignmentConflictInfo current = WGgLBnrPGkbEQIJYizGHDimhFPmzA.Current;
							ElementAssignmentConflictInfo elementAssignmentConflictInfo = new ElementAssignmentConflictInfo(current);
							elementAssignmentConflictInfo.bKzpvKwtktjTHYQffDSpfhOhitkeA(conflictCheckingHelper.TfoucHypqXIoiHkDDwOxTdWZLZEP.CgPagdlzMlCQxkbRTPOoePMzAXof);
							elementAssignmentConflictInfo.EoyQWIWraMCOIRiEZcPMHqupDMpjb(OLdoGeFrSjZuiqHqLlalHvXZnPGM);
							elementAssignmentConflictInfo.VEPDjqRWGYvCvlrhGuytJCLJqVBl(xHOvMqggqLvmYRNqOWCajGItyzWp);
							ssWVKXPiheJULXfTJtnUXVTMpykv = elementAssignmentConflictInfo;
							dITakmRExBsBwNEZVAtzeoypHtYMA = 1;
							return true;
						}
						AQBYLQVdGcijZVWJfVfCSlDRMTFl();
						WGgLBnrPGkbEQIJYizGHDimhFPmzA = null;
						goto IL_015b;
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

				private void AQBYLQVdGcijZVWJfVfCSlDRMTFl()
				{
					dITakmRExBsBwNEZVAtzeoypHtYMA = -1;
					if (WGgLBnrPGkbEQIJYizGHDimhFPmzA != null)
					{
						WGgLBnrPGkbEQIJYizGHDimhFPmzA.Dispose();
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
					IhecbtQgULTmMCoXoGbdXVHcDIJt<_0001> ihecbtQgULTmMCoXoGbdXVHcDIJt;
					if (dITakmRExBsBwNEZVAtzeoypHtYMA == -2 && dlMtiLoghuAlBKdIlqOEwPLzPuHw == Environment.CurrentManagedThreadId)
					{
						dITakmRExBsBwNEZVAtzeoypHtYMA = 0;
						ihecbtQgULTmMCoXoGbdXVHcDIJt = this;
					}
					else
					{
						ihecbtQgULTmMCoXoGbdXVHcDIJt = new IhecbtQgULTmMCoXoGbdXVHcDIJt<_0001>(0);
						ihecbtQgULTmMCoXoGbdXVHcDIJt.ugAbxPbNFnFdzCCtHXctIYeriGXoA = ugAbxPbNFnFdzCCtHXctIYeriGXoA;
					}
					ihecbtQgULTmMCoXoGbdXVHcDIJt.OLdoGeFrSjZuiqHqLlalHvXZnPGM = qNRvlkYgzXeBUaNktaGsGONFmIdvA;
					ihecbtQgULTmMCoXoGbdXVHcDIJt.xHOvMqggqLvmYRNqOWCajGItyzWp = chcMDPlyqeNuraRaRcmapfOrwmoR;
					ihecbtQgULTmMCoXoGbdXVHcDIJt.TKVbWUEwYydvkcpiIdMqpcGQdkjU = NDFHvcRMgNrQpKuLeHmlNfCbiIos;
					ihecbtQgULTmMCoXoGbdXVHcDIJt.pszfeeAUIjjwEAHJfTQCDTsgqMwCA = HdBykGauGuGSikRzQxYCMJpAKjQJ;
					ihecbtQgULTmMCoXoGbdXVHcDIJt.SZGzytxUIHmMuDtHyeejLboIgflu = jqnEYoMAwZMOwvOIlrRCWtscUzEM;
					ihecbtQgULTmMCoXoGbdXVHcDIJt.QJNtarZHJzguaMRUeXiXrqWuWVeK = WFwXcRRXktrwpieLZxiETywJeLKe;
					ihecbtQgULTmMCoXoGbdXVHcDIJt.DNSaoraJgduwUSxKCYgEsEUpyaTUA = YExDrFoWMLaueidQULMhkSCUMJvhA;
					return ihecbtQgULTmMCoXoGbdXVHcDIJt;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
				}
			}

			private sealed class bMsFPTkPLsjnVQzzuRqgFCllBzzSA<_0001> : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable where _0001 : ControllerMap
			{
				private int VuMnFYckBhUOgGFUvYVfeDBjpgRe;

				private ElementAssignmentConflictInfo gECGXKgKPejbPioeyBbffFOutxXc;

				private int koclIJccIDXcevhocTMOvFVJhDiG;

				private global::rspbeSfkijiKRfPuAyBrBqKNCACZB<_0001> biGjbXQRwPpwFGxnUwdFRZrpSqKR;

				public global::rspbeSfkijiKRfPuAyBrBqKNCACZB<_0001> CoRGrjBfRPXLcIjQBIRiIimWGaMbb;

				private ElementAssignmentConflictCheck ENjWPIhnZmcnxzfdvQHJuNMAjXABA;

				public ElementAssignmentConflictCheck WVQgkhVODMSBPZJbYIOyJeNDoEvRA;

				private bool sEIGxOcveefDoOnsoanshIRxFtZr;

				public bool fGVGfuzlKjRqBaAykitMZpVbsbbR;

				private bool jINmDJgBeraszvjWoUVyvYueeGQV;

				public bool VMRLoWpSBPhaDrAxziQcxDnicolR;

				public ConflictCheckingHelper phlxpSpBydXPGCZDAczNvKsOCIjx;

				private InputMapCategory QYQIGmNDycIuyfKhuyMScqbGRFRI;

				private int YTinyuJaYpAfsZJrRGLacvEfsivCb;

				private IEnumerator<ElementAssignmentConflictInfo> NJjugCOcUVXHlBYeBGVqfHiANpPl;

				ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
				{
					[DebuggerHidden]
					get
					{
						return gECGXKgKPejbPioeyBbffFOutxXc;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return gECGXKgKPejbPioeyBbffFOutxXc;
					}
				}

				[DebuggerHidden]
				public bMsFPTkPLsjnVQzzuRqgFCllBzzSA(int P_0)
				{
					VuMnFYckBhUOgGFUvYVfeDBjpgRe = P_0;
					koclIJccIDXcevhocTMOvFVJhDiG = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					int vuMnFYckBhUOgGFUvYVfeDBjpgRe = VuMnFYckBhUOgGFUvYVfeDBjpgRe;
					if (vuMnFYckBhUOgGFUvYVfeDBjpgRe == -3 || vuMnFYckBhUOgGFUvYVfeDBjpgRe == 1)
					{
						try
						{
						}
						finally
						{
							ikUWnibOAwdIsHFsYBHOAmrmsLleA();
						}
					}
				}

				private bool MoveNext()
				{
					try
					{
						int vuMnFYckBhUOgGFUvYVfeDBjpgRe = VuMnFYckBhUOgGFUvYVfeDBjpgRe;
						ConflictCheckingHelper conflictCheckingHelper = phlxpSpBydXPGCZDAczNvKsOCIjx;
						if (vuMnFYckBhUOgGFUvYVfeDBjpgRe != 0)
						{
							if (vuMnFYckBhUOgGFUvYVfeDBjpgRe != 1)
							{
								return false;
							}
							VuMnFYckBhUOgGFUvYVfeDBjpgRe = -3;
							goto IL_01ab;
						}
						VuMnFYckBhUOgGFUvYVfeDBjpgRe = -1;
						if (biGjbXQRwPpwFGxnUwdFRZrpSqKR == null)
						{
							return false;
						}
						Player player = ReInput.players.GetPlayer(ENjWPIhnZmcnxzfdvQHJuNMAjXABA.playerId);
						if (player == null)
						{
							return false;
						}
						ControllerMap map = player.controllers.maps.GetMap(ENjWPIhnZmcnxzfdvQHJuNMAjXABA.controllerType, ENjWPIhnZmcnxzfdvQHJuNMAjXABA.controllerId, ENjWPIhnZmcnxzfdvQHJuNMAjXABA.controllerMapId);
						QYQIGmNDycIuyfKhuyMScqbGRFRI = ((map != null) ? ReInput.mapping.GetMapCategory(map.categoryId) : ReInput.mapping.GetMapCategory(ENjWPIhnZmcnxzfdvQHJuNMAjXABA.controllerMapCategoryId));
						if (QYQIGmNDycIuyfKhuyMScqbGRFRI == null)
						{
							return false;
						}
						YTinyuJaYpAfsZJrRGLacvEfsivCb = 0;
						goto IL_01d7;
						IL_01ab:
						if (NJjugCOcUVXHlBYeBGVqfHiANpPl.MoveNext())
						{
							ElementAssignmentConflictInfo current = NJjugCOcUVXHlBYeBGVqfHiANpPl.Current;
							ElementAssignmentConflictInfo elementAssignmentConflictInfo = new ElementAssignmentConflictInfo(current);
							elementAssignmentConflictInfo.bKzpvKwtktjTHYQffDSpfhOhitkeA(conflictCheckingHelper.TfoucHypqXIoiHkDDwOxTdWZLZEP.CgPagdlzMlCQxkbRTPOoePMzAXof);
							elementAssignmentConflictInfo.EoyQWIWraMCOIRiEZcPMHqupDMpjb(ENjWPIhnZmcnxzfdvQHJuNMAjXABA.controllerType);
							elementAssignmentConflictInfo.VEPDjqRWGYvCvlrhGuytJCLJqVBl(ENjWPIhnZmcnxzfdvQHJuNMAjXABA.controllerId);
							gECGXKgKPejbPioeyBbffFOutxXc = elementAssignmentConflictInfo;
							VuMnFYckBhUOgGFUvYVfeDBjpgRe = 1;
							return true;
						}
						ikUWnibOAwdIsHFsYBHOAmrmsLleA();
						NJjugCOcUVXHlBYeBGVqfHiANpPl = null;
						goto IL_01c5;
						IL_01d7:
						if (YTinyuJaYpAfsZJrRGLacvEfsivCb < biGjbXQRwPpwFGxnUwdFRZrpSqKR.ejOOZrUqJLRyRGoRofwTThHfNEkF())
						{
							ControllerMap controllerMap = biGjbXQRwPpwFGxnUwdFRZrpSqKR.xmIhmmDDQdCDzpiurLdyJADZcUhZ(YTinyuJaYpAfsZJrRGLacvEfsivCb);
							if ((!sEIGxOcveefDoOnsoanshIRxFtZr || controllerMap.enabled) && (jINmDJgBeraszvjWoUVyvYueeGQV || !conflictCheckingHelper.pJOlttBqyXtegIpOvYsIZCGBQTiE(QYQIGmNDycIuyfKhuyMScqbGRFRI, controllerMap)))
							{
								NJjugCOcUVXHlBYeBGVqfHiANpPl = controllerMap.ElementAssignmentConflicts(ENjWPIhnZmcnxzfdvQHJuNMAjXABA, sEIGxOcveefDoOnsoanshIRxFtZr).GetEnumerator();
								VuMnFYckBhUOgGFUvYVfeDBjpgRe = -3;
								goto IL_01ab;
							}
							goto IL_01c5;
						}
						return false;
						IL_01c5:
						YTinyuJaYpAfsZJrRGLacvEfsivCb++;
						goto IL_01d7;
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

				private void ikUWnibOAwdIsHFsYBHOAmrmsLleA()
				{
					VuMnFYckBhUOgGFUvYVfeDBjpgRe = -1;
					if (NJjugCOcUVXHlBYeBGVqfHiANpPl != null)
					{
						NJjugCOcUVXHlBYeBGVqfHiANpPl.Dispose();
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
					bMsFPTkPLsjnVQzzuRqgFCllBzzSA<_0001> bMsFPTkPLsjnVQzzuRqgFCllBzzSA2;
					if (VuMnFYckBhUOgGFUvYVfeDBjpgRe == -2 && koclIJccIDXcevhocTMOvFVJhDiG == Environment.CurrentManagedThreadId)
					{
						VuMnFYckBhUOgGFUvYVfeDBjpgRe = 0;
						bMsFPTkPLsjnVQzzuRqgFCllBzzSA2 = this;
					}
					else
					{
						bMsFPTkPLsjnVQzzuRqgFCllBzzSA2 = new bMsFPTkPLsjnVQzzuRqgFCllBzzSA<_0001>(0);
						bMsFPTkPLsjnVQzzuRqgFCllBzzSA2.phlxpSpBydXPGCZDAczNvKsOCIjx = phlxpSpBydXPGCZDAczNvKsOCIjx;
					}
					bMsFPTkPLsjnVQzzuRqgFCllBzzSA2.ENjWPIhnZmcnxzfdvQHJuNMAjXABA = WVQgkhVODMSBPZJbYIOyJeNDoEvRA;
					bMsFPTkPLsjnVQzzuRqgFCllBzzSA2.sEIGxOcveefDoOnsoanshIRxFtZr = fGVGfuzlKjRqBaAykitMZpVbsbbR;
					bMsFPTkPLsjnVQzzuRqgFCllBzzSA2.jINmDJgBeraszvjWoUVyvYueeGQV = VMRLoWpSBPhaDrAxziQcxDnicolR;
					bMsFPTkPLsjnVQzzuRqgFCllBzzSA2.biGjbXQRwPpwFGxnUwdFRZrpSqKR = CoRGrjBfRPXLcIjQBIRiIimWGaMbb;
					return bMsFPTkPLsjnVQzzuRqgFCllBzzSA2;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
				}
			}

			private sealed class kIRPYmvoSPEYBHqHApIIkozVeqwbA : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
			{
				private int qFqTJBGftbtHTPPbtzLuhMSDBMuy;

				private ElementAssignmentConflictInfo ODIOoJIIwhfsDPiAIBHAFKTIxdjtA;

				private int eKFZlCOeXHtlNJWKohoEkXzjKEAA;

				private int UVWsnYteFNFkAKRzDsNCcTEDBzPSA;

				public int ZCoraMSYRoNaPfinxolwocxWxYDv;

				private JoystickMap evHCrPHlNnwDgUaADwaDfvUsuQvc;

				public JoystickMap MxISvpTKULNGZUJjqJyeBVANjaRC;

				public ConflictCheckingHelper pNCrsfECpwRRTgfpfbIgugPQHexiA;

				private bool JXrhaMaadZdTqiWjWziRUxmCbvdK;

				public bool bmoyzrrZTlYkQxHkUczetGVFBxvh;

				private bool YmYarHqXCOrBSwCAKQOhbBBSInKY;

				public bool kOnSWEfKQMmLPcTCIAhMAmVJUUih;

				private int COZAbDIHrNrhPaYwzKdLNPKMgyeM;

				private IEnumerator<ElementAssignmentConflictInfo> TXROfcrBiiVldXWmCciIJmziAfLBA;

				ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
				{
					[DebuggerHidden]
					get
					{
						return ODIOoJIIwhfsDPiAIBHAFKTIxdjtA;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return ODIOoJIIwhfsDPiAIBHAFKTIxdjtA;
					}
				}

				[DebuggerHidden]
				public kIRPYmvoSPEYBHqHApIIkozVeqwbA(int P_0)
				{
					qFqTJBGftbtHTPPbtzLuhMSDBMuy = P_0;
					eKFZlCOeXHtlNJWKohoEkXzjKEAA = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					int num = qFqTJBGftbtHTPPbtzLuhMSDBMuy;
					if (num == -3 || num == 1)
					{
						try
						{
						}
						finally
						{
							pCSZAFrDOzfnbCJOgGQZZbDPhhjnA();
						}
					}
				}

				private bool MoveNext()
				{
					try
					{
						int num = qFqTJBGftbtHTPPbtzLuhMSDBMuy;
						ConflictCheckingHelper conflictCheckingHelper = pNCrsfECpwRRTgfpfbIgugPQHexiA;
						if (num != 0)
						{
							if (num != 1)
							{
								return false;
							}
							qFqTJBGftbtHTPPbtzLuhMSDBMuy = -3;
							goto IL_00ea;
						}
						qFqTJBGftbtHTPPbtzLuhMSDBMuy = -1;
						if (UVWsnYteFNFkAKRzDsNCcTEDBzPSA < 0 || evHCrPHlNnwDgUaADwaDfvUsuQvc == null)
						{
							return false;
						}
						COZAbDIHrNrhPaYwzKdLNPKMgyeM = 0;
						goto IL_0116;
						IL_00ea:
						if (TXROfcrBiiVldXWmCciIJmziAfLBA.MoveNext())
						{
							ElementAssignmentConflictInfo current = TXROfcrBiiVldXWmCciIJmziAfLBA.Current;
							ODIOoJIIwhfsDPiAIBHAFKTIxdjtA = current;
							qFqTJBGftbtHTPPbtzLuhMSDBMuy = 1;
							return true;
						}
						pCSZAFrDOzfnbCJOgGQZZbDPhhjnA();
						TXROfcrBiiVldXWmCciIJmziAfLBA = null;
						goto IL_0104;
						IL_0116:
						if (COZAbDIHrNrhPaYwzKdLNPKMgyeM < conflictCheckingHelper.eiqsZVPHBaSbtbaEQWQevZlaNXhK.UZODjZPyOKvXiogzadHvXQZXjpbh().rphZqyUfbdoINyXndGfDbQaiIHFM())
						{
							if (conflictCheckingHelper.eiqsZVPHBaSbtbaEQWQevZlaNXhK.UZODjZPyOKvXiogzadHvXQZXjpbh().IqlJUjIBLQbuSkAhcRvowzpPOQIC(COZAbDIHrNrhPaYwzKdLNPKMgyeM).vEpnAhSIoVrCnOfAmeqwGuTGoWnB.id == UVWsnYteFNFkAKRzDsNCcTEDBzPSA)
							{
								TXROfcrBiiVldXWmCciIJmziAfLBA = conflictCheckingHelper.PZeHctZEgnZEAlGnDwqoALlTosXv(ControllerType.Joystick, UVWsnYteFNFkAKRzDsNCcTEDBzPSA, evHCrPHlNnwDgUaADwaDfvUsuQvc, JXrhaMaadZdTqiWjWziRUxmCbvdK, YmYarHqXCOrBSwCAKQOhbBBSInKY, conflictCheckingHelper.eiqsZVPHBaSbtbaEQWQevZlaNXhK.UZODjZPyOKvXiogzadHvXQZXjpbh().IqlJUjIBLQbuSkAhcRvowzpPOQIC(COZAbDIHrNrhPaYwzKdLNPKMgyeM).urKiLjIJcqceLbXuNYNvuMSWJkNF).GetEnumerator();
								qFqTJBGftbtHTPPbtzLuhMSDBMuy = -3;
								goto IL_00ea;
							}
							goto IL_0104;
						}
						return false;
						IL_0104:
						COZAbDIHrNrhPaYwzKdLNPKMgyeM++;
						goto IL_0116;
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

				private void pCSZAFrDOzfnbCJOgGQZZbDPhhjnA()
				{
					qFqTJBGftbtHTPPbtzLuhMSDBMuy = -1;
					if (TXROfcrBiiVldXWmCciIJmziAfLBA != null)
					{
						TXROfcrBiiVldXWmCciIJmziAfLBA.Dispose();
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
					kIRPYmvoSPEYBHqHApIIkozVeqwbA kIRPYmvoSPEYBHqHApIIkozVeqwbA2;
					if (qFqTJBGftbtHTPPbtzLuhMSDBMuy == -2 && eKFZlCOeXHtlNJWKohoEkXzjKEAA == Environment.CurrentManagedThreadId)
					{
						qFqTJBGftbtHTPPbtzLuhMSDBMuy = 0;
						kIRPYmvoSPEYBHqHApIIkozVeqwbA2 = this;
					}
					else
					{
						kIRPYmvoSPEYBHqHApIIkozVeqwbA2 = new kIRPYmvoSPEYBHqHApIIkozVeqwbA(0);
						kIRPYmvoSPEYBHqHApIIkozVeqwbA2.pNCrsfECpwRRTgfpfbIgugPQHexiA = pNCrsfECpwRRTgfpfbIgugPQHexiA;
					}
					kIRPYmvoSPEYBHqHApIIkozVeqwbA2.UVWsnYteFNFkAKRzDsNCcTEDBzPSA = ZCoraMSYRoNaPfinxolwocxWxYDv;
					kIRPYmvoSPEYBHqHApIIkozVeqwbA2.evHCrPHlNnwDgUaADwaDfvUsuQvc = MxISvpTKULNGZUJjqJyeBVANjaRC;
					kIRPYmvoSPEYBHqHApIIkozVeqwbA2.JXrhaMaadZdTqiWjWziRUxmCbvdK = bmoyzrrZTlYkQxHkUczetGVFBxvh;
					kIRPYmvoSPEYBHqHApIIkozVeqwbA2.YmYarHqXCOrBSwCAKQOhbBBSInKY = kOnSWEfKQMmLPcTCIAhMAmVJUUih;
					return kIRPYmvoSPEYBHqHApIIkozVeqwbA2;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
				}
			}

			private sealed class eBvcvrHgbnEzeAKybXozklnrBRuEB : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
			{
				private int UxCVINmEvxdEZsivlDAEUEpkGzcx;

				private ElementAssignmentConflictInfo BbeBtGTDJQCPNEqbeLogCTOiAnJvA;

				private int tmcTlCqDBTkzbicnngXiQiQZeDbt;

				private int JLjKkckErxxcgCFjVyzrcDGmfqbgA;

				public int jQcUxvCPDekppSgtQlmLbkvEAxuQ;

				private ActionElementMap pFpHejmzCAbzCVRClhslvMVbDgiBA;

				public ActionElementMap VxvHUPypMEfnRfxamxwQPhRKZKaY;

				public ConflictCheckingHelper YyZWbmqGkERgDRdyGlYxZANEeHcT;

				private JoystickMap teqsVCSslldDFhtnxAXyqXgldvuR;

				public JoystickMap XVNJGDOLenaksVstBUERcbktjRku;

				private bool idZLNEZZNOVLakARYOAKOYMhwhMq;

				public bool PkUALkPwnkMMJOYdFVJeWwhAkgcv;

				private bool MfYsKscFjzwIISfcUFGbxLRpcNzn;

				public bool AUgtlygnmVUdjnDAjBTDowJKbkMM;

				private int nkFQsYaJLeRLywGPBLsyREcTxfIB;

				private IEnumerator<ElementAssignmentConflictInfo> rZCXsxMrxTdLRuFNbFJfINhlXBdl;

				ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
				{
					[DebuggerHidden]
					get
					{
						return BbeBtGTDJQCPNEqbeLogCTOiAnJvA;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return BbeBtGTDJQCPNEqbeLogCTOiAnJvA;
					}
				}

				[DebuggerHidden]
				public eBvcvrHgbnEzeAKybXozklnrBRuEB(int P_0)
				{
					UxCVINmEvxdEZsivlDAEUEpkGzcx = P_0;
					tmcTlCqDBTkzbicnngXiQiQZeDbt = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					int uxCVINmEvxdEZsivlDAEUEpkGzcx = UxCVINmEvxdEZsivlDAEUEpkGzcx;
					if (uxCVINmEvxdEZsivlDAEUEpkGzcx == -3 || uxCVINmEvxdEZsivlDAEUEpkGzcx == 1)
					{
						try
						{
						}
						finally
						{
							hsIkZMfgbTporpLJHeNqVTAkPPql();
						}
					}
				}

				private bool MoveNext()
				{
					try
					{
						int uxCVINmEvxdEZsivlDAEUEpkGzcx = UxCVINmEvxdEZsivlDAEUEpkGzcx;
						ConflictCheckingHelper yyZWbmqGkERgDRdyGlYxZANEeHcT = YyZWbmqGkERgDRdyGlYxZANEeHcT;
						if (uxCVINmEvxdEZsivlDAEUEpkGzcx != 0)
						{
							if (uxCVINmEvxdEZsivlDAEUEpkGzcx != 1)
							{
								return false;
							}
							UxCVINmEvxdEZsivlDAEUEpkGzcx = -3;
							goto IL_00f0;
						}
						UxCVINmEvxdEZsivlDAEUEpkGzcx = -1;
						if (JLjKkckErxxcgCFjVyzrcDGmfqbgA < 0 || pFpHejmzCAbzCVRClhslvMVbDgiBA == null)
						{
							return false;
						}
						nkFQsYaJLeRLywGPBLsyREcTxfIB = 0;
						goto IL_011c;
						IL_00f0:
						if (rZCXsxMrxTdLRuFNbFJfINhlXBdl.MoveNext())
						{
							ElementAssignmentConflictInfo current = rZCXsxMrxTdLRuFNbFJfINhlXBdl.Current;
							BbeBtGTDJQCPNEqbeLogCTOiAnJvA = current;
							UxCVINmEvxdEZsivlDAEUEpkGzcx = 1;
							return true;
						}
						hsIkZMfgbTporpLJHeNqVTAkPPql();
						rZCXsxMrxTdLRuFNbFJfINhlXBdl = null;
						goto IL_010a;
						IL_011c:
						if (nkFQsYaJLeRLywGPBLsyREcTxfIB < yyZWbmqGkERgDRdyGlYxZANEeHcT.eiqsZVPHBaSbtbaEQWQevZlaNXhK.UZODjZPyOKvXiogzadHvXQZXjpbh().rphZqyUfbdoINyXndGfDbQaiIHFM())
						{
							if (yyZWbmqGkERgDRdyGlYxZANEeHcT.eiqsZVPHBaSbtbaEQWQevZlaNXhK.UZODjZPyOKvXiogzadHvXQZXjpbh().IqlJUjIBLQbuSkAhcRvowzpPOQIC(nkFQsYaJLeRLywGPBLsyREcTxfIB).vEpnAhSIoVrCnOfAmeqwGuTGoWnB.id == JLjKkckErxxcgCFjVyzrcDGmfqbgA)
							{
								rZCXsxMrxTdLRuFNbFJfINhlXBdl = yyZWbmqGkERgDRdyGlYxZANEeHcT.nnrAnrmVqGqiiUDbLllpALDTVtBj(ControllerType.Joystick, JLjKkckErxxcgCFjVyzrcDGmfqbgA, teqsVCSslldDFhtnxAXyqXgldvuR, pFpHejmzCAbzCVRClhslvMVbDgiBA, idZLNEZZNOVLakARYOAKOYMhwhMq, MfYsKscFjzwIISfcUFGbxLRpcNzn, yyZWbmqGkERgDRdyGlYxZANEeHcT.eiqsZVPHBaSbtbaEQWQevZlaNXhK.UZODjZPyOKvXiogzadHvXQZXjpbh().IqlJUjIBLQbuSkAhcRvowzpPOQIC(nkFQsYaJLeRLywGPBLsyREcTxfIB).urKiLjIJcqceLbXuNYNvuMSWJkNF).GetEnumerator();
								UxCVINmEvxdEZsivlDAEUEpkGzcx = -3;
								goto IL_00f0;
							}
							goto IL_010a;
						}
						return false;
						IL_010a:
						nkFQsYaJLeRLywGPBLsyREcTxfIB++;
						goto IL_011c;
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

				private void hsIkZMfgbTporpLJHeNqVTAkPPql()
				{
					UxCVINmEvxdEZsivlDAEUEpkGzcx = -1;
					if (rZCXsxMrxTdLRuFNbFJfINhlXBdl != null)
					{
						rZCXsxMrxTdLRuFNbFJfINhlXBdl.Dispose();
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
					eBvcvrHgbnEzeAKybXozklnrBRuEB eBvcvrHgbnEzeAKybXozklnrBRuEB2;
					if (UxCVINmEvxdEZsivlDAEUEpkGzcx == -2 && tmcTlCqDBTkzbicnngXiQiQZeDbt == Environment.CurrentManagedThreadId)
					{
						UxCVINmEvxdEZsivlDAEUEpkGzcx = 0;
						eBvcvrHgbnEzeAKybXozklnrBRuEB2 = this;
					}
					else
					{
						eBvcvrHgbnEzeAKybXozklnrBRuEB2 = new eBvcvrHgbnEzeAKybXozklnrBRuEB(0);
						eBvcvrHgbnEzeAKybXozklnrBRuEB2.YyZWbmqGkERgDRdyGlYxZANEeHcT = YyZWbmqGkERgDRdyGlYxZANEeHcT;
					}
					eBvcvrHgbnEzeAKybXozklnrBRuEB2.JLjKkckErxxcgCFjVyzrcDGmfqbgA = jQcUxvCPDekppSgtQlmLbkvEAxuQ;
					eBvcvrHgbnEzeAKybXozklnrBRuEB2.teqsVCSslldDFhtnxAXyqXgldvuR = XVNJGDOLenaksVstBUERcbktjRku;
					eBvcvrHgbnEzeAKybXozklnrBRuEB2.pFpHejmzCAbzCVRClhslvMVbDgiBA = VxvHUPypMEfnRfxamxwQPhRKZKaY;
					eBvcvrHgbnEzeAKybXozklnrBRuEB2.idZLNEZZNOVLakARYOAKOYMhwhMq = PkUALkPwnkMMJOYdFVJeWwhAkgcv;
					eBvcvrHgbnEzeAKybXozklnrBRuEB2.MfYsKscFjzwIISfcUFGbxLRpcNzn = AUgtlygnmVUdjnDAjBTDowJKbkMM;
					return eBvcvrHgbnEzeAKybXozklnrBRuEB2;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
				}
			}

			private sealed class hhHvMtqQHulprXJNOHbArByZrLkv : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
			{
				private int ZMDzSJPBTJBufgwQpCvtFGgDiNuOB;

				private ElementAssignmentConflictInfo QqzPcjOdDWsFFLYgJLAIBsDYvzvh;

				private int pMTFBTTUBzJbhMqdilRxqOFUeCtM;

				private ElementAssignmentConflictCheck mchsCOHsVVpoJRpGTWeKINKgqsJq;

				public ElementAssignmentConflictCheck subXudMcCseUuKxVdnWnGsHoqQiA;

				public ConflictCheckingHelper bYAxnMarHNtfJfVceLnbyqSeLJIo;

				private bool KkZbDHUBMDSFbIlrORLDZdIKxwPs;

				public bool bleIPJLoRrKSdtmfkFigCNjhKJXR;

				private bool bHOaFFblMCGeKaZjvIgUwHKYpraPA;

				public bool qRVAytdmtBuLsynxtYVrylVvdCMt;

				private int pQVakoHioSksmzWdlSIWCTheqPvgA;

				private IEnumerator<ElementAssignmentConflictInfo> alHkrILUyTblsPzwQWqJSIxAIYeI;

				ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
				{
					[DebuggerHidden]
					get
					{
						return QqzPcjOdDWsFFLYgJLAIBsDYvzvh;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return QqzPcjOdDWsFFLYgJLAIBsDYvzvh;
					}
				}

				[DebuggerHidden]
				public hhHvMtqQHulprXJNOHbArByZrLkv(int P_0)
				{
					ZMDzSJPBTJBufgwQpCvtFGgDiNuOB = P_0;
					pMTFBTTUBzJbhMqdilRxqOFUeCtM = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					int zMDzSJPBTJBufgwQpCvtFGgDiNuOB = ZMDzSJPBTJBufgwQpCvtFGgDiNuOB;
					if (zMDzSJPBTJBufgwQpCvtFGgDiNuOB == -3 || zMDzSJPBTJBufgwQpCvtFGgDiNuOB == 1)
					{
						try
						{
						}
						finally
						{
							LXEHyurcokgnNdRCnrGYHuBHBqcCA();
						}
					}
				}

				private bool MoveNext()
				{
					try
					{
						int zMDzSJPBTJBufgwQpCvtFGgDiNuOB = ZMDzSJPBTJBufgwQpCvtFGgDiNuOB;
						ConflictCheckingHelper conflictCheckingHelper = bYAxnMarHNtfJfVceLnbyqSeLJIo;
						if (zMDzSJPBTJBufgwQpCvtFGgDiNuOB != 0)
						{
							if (zMDzSJPBTJBufgwQpCvtFGgDiNuOB != 1)
							{
								return false;
							}
							ZMDzSJPBTJBufgwQpCvtFGgDiNuOB = -3;
							goto IL_00f3;
						}
						ZMDzSJPBTJBufgwQpCvtFGgDiNuOB = -1;
						if (mchsCOHsVVpoJRpGTWeKINKgqsJq.controllerId < 0 || mchsCOHsVVpoJRpGTWeKINKgqsJq.elementAssignmentType == ElementAssignmentType.KeyboardKey)
						{
							return false;
						}
						pQVakoHioSksmzWdlSIWCTheqPvgA = 0;
						goto IL_011f;
						IL_00f3:
						if (alHkrILUyTblsPzwQWqJSIxAIYeI.MoveNext())
						{
							ElementAssignmentConflictInfo current = alHkrILUyTblsPzwQWqJSIxAIYeI.Current;
							QqzPcjOdDWsFFLYgJLAIBsDYvzvh = current;
							ZMDzSJPBTJBufgwQpCvtFGgDiNuOB = 1;
							return true;
						}
						LXEHyurcokgnNdRCnrGYHuBHBqcCA();
						alHkrILUyTblsPzwQWqJSIxAIYeI = null;
						goto IL_010d;
						IL_011f:
						if (pQVakoHioSksmzWdlSIWCTheqPvgA < conflictCheckingHelper.eiqsZVPHBaSbtbaEQWQevZlaNXhK.UZODjZPyOKvXiogzadHvXQZXjpbh().rphZqyUfbdoINyXndGfDbQaiIHFM())
						{
							if (conflictCheckingHelper.eiqsZVPHBaSbtbaEQWQevZlaNXhK.UZODjZPyOKvXiogzadHvXQZXjpbh().IqlJUjIBLQbuSkAhcRvowzpPOQIC(pQVakoHioSksmzWdlSIWCTheqPvgA).vEpnAhSIoVrCnOfAmeqwGuTGoWnB.id == mchsCOHsVVpoJRpGTWeKINKgqsJq.controllerId)
							{
								alHkrILUyTblsPzwQWqJSIxAIYeI = conflictCheckingHelper.AaFoiqrRMxwJhqGuYjxGLocMtIft(mchsCOHsVVpoJRpGTWeKINKgqsJq, KkZbDHUBMDSFbIlrORLDZdIKxwPs, bHOaFFblMCGeKaZjvIgUwHKYpraPA, conflictCheckingHelper.eiqsZVPHBaSbtbaEQWQevZlaNXhK.UZODjZPyOKvXiogzadHvXQZXjpbh().IqlJUjIBLQbuSkAhcRvowzpPOQIC(pQVakoHioSksmzWdlSIWCTheqPvgA).urKiLjIJcqceLbXuNYNvuMSWJkNF).GetEnumerator();
								ZMDzSJPBTJBufgwQpCvtFGgDiNuOB = -3;
								goto IL_00f3;
							}
							goto IL_010d;
						}
						return false;
						IL_010d:
						pQVakoHioSksmzWdlSIWCTheqPvgA++;
						goto IL_011f;
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

				private void LXEHyurcokgnNdRCnrGYHuBHBqcCA()
				{
					ZMDzSJPBTJBufgwQpCvtFGgDiNuOB = -1;
					if (alHkrILUyTblsPzwQWqJSIxAIYeI != null)
					{
						alHkrILUyTblsPzwQWqJSIxAIYeI.Dispose();
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
					hhHvMtqQHulprXJNOHbArByZrLkv hhHvMtqQHulprXJNOHbArByZrLkv2;
					if (ZMDzSJPBTJBufgwQpCvtFGgDiNuOB == -2 && pMTFBTTUBzJbhMqdilRxqOFUeCtM == Environment.CurrentManagedThreadId)
					{
						ZMDzSJPBTJBufgwQpCvtFGgDiNuOB = 0;
						hhHvMtqQHulprXJNOHbArByZrLkv2 = this;
					}
					else
					{
						hhHvMtqQHulprXJNOHbArByZrLkv2 = new hhHvMtqQHulprXJNOHbArByZrLkv(0);
						hhHvMtqQHulprXJNOHbArByZrLkv2.bYAxnMarHNtfJfVceLnbyqSeLJIo = bYAxnMarHNtfJfVceLnbyqSeLJIo;
					}
					hhHvMtqQHulprXJNOHbArByZrLkv2.mchsCOHsVVpoJRpGTWeKINKgqsJq = subXudMcCseUuKxVdnWnGsHoqQiA;
					hhHvMtqQHulprXJNOHbArByZrLkv2.KkZbDHUBMDSFbIlrORLDZdIKxwPs = bleIPJLoRrKSdtmfkFigCNjhKJXR;
					hhHvMtqQHulprXJNOHbArByZrLkv2.bHOaFFblMCGeKaZjvIgUwHKYpraPA = qRVAytdmtBuLsynxtYVrylVvdCMt;
					return hhHvMtqQHulprXJNOHbArByZrLkv2;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
				}
			}

			private readonly Player TfoucHypqXIoiHkDDwOxTdWZLZEP;

			private readonly ControllerHelper eiqsZVPHBaSbtbaEQWQevZlaNXhK;

			private readonly int FcKIhGECAPoDpEyufemoHBfzGajQA;

			internal ConflictCheckingHelper(Player P_0, ControllerHelper P_1)
			{
				FcKIhGECAPoDpEyufemoHBfzGajQA = ReInput.id;
				TfoucHypqXIoiHkDDwOxTdWZLZEP = P_0;
				eiqsZVPHBaSbtbaEQWQevZlaNXhK = P_1;
			}

			public bool DoesElementAssignmentConflict(ControllerType controllerType, int controllerId, ControllerMap controllerMap)
			{
				return DoesElementAssignmentConflict(controllerType, controllerId, controllerMap, skipDisabledMaps: false, forceCheckAllCategories: false);
			}

			public bool DoesElementAssignmentConflict(ControllerType controllerType, int controllerId, ControllerMap controllerMap, bool skipDisabledMaps)
			{
				return DoesElementAssignmentConflict(controllerType, controllerId, controllerMap, skipDisabledMaps, forceCheckAllCategories: false);
			}

			public bool DoesElementAssignmentConflict(ControllerType controllerType, int controllerId, ControllerMap controllerMap, bool skipDisabledMaps, bool forceCheckAllCategories)
			{
				if (ReInput._id != FcKIhGECAPoDpEyufemoHBfzGajQA)
				{
					ReInput.CheckInitialized(FcKIhGECAPoDpEyufemoHBfzGajQA);
					return false;
				}
				if (controllerMap == null)
				{
					return false;
				}
				return controllerType switch
				{
					ControllerType.Joystick => MFOlkdspEEUzcXCQgzUBkiaLpcUq(controllerId, controllerMap as JoystickMap, skipDisabledMaps, forceCheckAllCategories), 
					ControllerType.Keyboard => iLGgoNuXsuAVdDpcXWeDYGVRasuZ(controllerMap as KeyboardMap, skipDisabledMaps, forceCheckAllCategories), 
					ControllerType.Mouse => eOrpcDKMtpcNWphbwwTdXMoNlgwu(controllerMap as MouseMap, skipDisabledMaps, forceCheckAllCategories), 
					ControllerType.Custom => RlqvyboFolcpjTWftUtQRbvMPAIJ(controllerId, controllerMap as CustomControllerMap, skipDisabledMaps, forceCheckAllCategories), 
					_ => throw new NotImplementedException(), 
				};
			}

			public bool DoesElementAssignmentConflict(ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap)
			{
				return DoesElementAssignmentConflict(controllerType, controllerId, controllerMap, elementMap, skipDisabledMaps: false, forceCheckAllCategories: false);
			}

			public bool DoesElementAssignmentConflict(ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap, bool skipDisabledMaps)
			{
				return DoesElementAssignmentConflict(controllerType, controllerId, controllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories: false);
			}

			public bool DoesElementAssignmentConflict(ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap, bool skipDisabledMaps, bool forceCheckAllCategories)
			{
				if (ReInput._id != FcKIhGECAPoDpEyufemoHBfzGajQA)
				{
					ReInput.CheckInitialized(FcKIhGECAPoDpEyufemoHBfzGajQA);
					return false;
				}
				if (controllerMap == null || elementMap == null)
				{
					return false;
				}
				return controllerType switch
				{
					ControllerType.Joystick => ZrXpYivODGirEXhhwREJatDjtpzK(controllerId, controllerMap as JoystickMap, elementMap, skipDisabledMaps, forceCheckAllCategories), 
					ControllerType.Keyboard => ATZBOjAyslnXPRwxpvAabAekHkPKA(controllerMap as KeyboardMap, elementMap, skipDisabledMaps, forceCheckAllCategories), 
					ControllerType.Mouse => fjqEDqQvKJPhzYjDWwvQXzDlbDio(controllerMap as MouseMap, elementMap, skipDisabledMaps, forceCheckAllCategories), 
					ControllerType.Custom => jQtfSaoOQvzRqhIBlvTfsJwgvOxW(controllerId, controllerMap as CustomControllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories), 
					_ => throw new NotImplementedException(), 
				};
			}

			public bool DoesElementAssignmentConflict(ElementAssignmentConflictCheck conflictCheck)
			{
				return DoesElementAssignmentConflict(conflictCheck, skipDisabledMaps: false, forceCheckAllCategories: false);
			}

			public bool DoesElementAssignmentConflict(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
			{
				return DoesElementAssignmentConflict(conflictCheck, skipDisabledMaps, forceCheckAllCategories: false);
			}

			public bool DoesElementAssignmentConflict(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps, bool forceCheckAllCategories)
			{
				if (ReInput._id != FcKIhGECAPoDpEyufemoHBfzGajQA)
				{
					ReInput.CheckInitialized(FcKIhGECAPoDpEyufemoHBfzGajQA);
					return false;
				}
				if (conflictCheck.controllerType == ControllerType.Joystick)
				{
					return sKCmyHlEHWBPizLWScgpjZTuQIHE(conflictCheck, skipDisabledMaps, forceCheckAllCategories);
				}
				if (conflictCheck.controllerType == ControllerType.Keyboard)
				{
					return OrRrfGGLWhcaCUvgaSeGDaylYGmR(conflictCheck, skipDisabledMaps, forceCheckAllCategories);
				}
				if (conflictCheck.controllerType == ControllerType.Mouse)
				{
					return obvCPSjQKJEeRHuVKmLHReqjXlbg(conflictCheck, skipDisabledMaps, forceCheckAllCategories);
				}
				if (conflictCheck.controllerType == ControllerType.Custom)
				{
					return GgVQOrEGsllcdjjudKMwlgwAVfUr(conflictCheck, skipDisabledMaps, forceCheckAllCategories);
				}
				throw new NotImplementedException();
			}

			public IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ControllerType controllerType, int controllerId, ControllerMap controllerMap)
			{
				return ElementAssignmentConflicts(controllerType, controllerId, controllerMap, skipDisabledMaps: false, forceCheckAllCategories: false);
			}

			public IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ControllerType controllerType, int controllerId, ControllerMap controllerMap, bool skipDisabledMaps)
			{
				return ElementAssignmentConflicts(controllerType, controllerId, controllerMap, skipDisabledMaps, forceCheckAllCategories: false);
			}

			public IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ControllerType controllerType, int controllerId, ControllerMap controllerMap, bool skipDisabledMaps, bool forceCheckAllCategories)
			{
				if (ReInput._id != FcKIhGECAPoDpEyufemoHBfzGajQA)
				{
					ReInput.CheckInitialized(FcKIhGECAPoDpEyufemoHBfzGajQA);
					return EmptyObjects<ElementAssignmentConflictInfo>.EmptyReadOnlyIListT;
				}
				if (controllerMap == null)
				{
					return new List<ElementAssignmentConflictInfo>();
				}
				return controllerType switch
				{
					ControllerType.Joystick => VRBaDJJnlFDUaEQRHtsYYcKrTgZFb(controllerId, controllerMap as JoystickMap, skipDisabledMaps, forceCheckAllCategories), 
					ControllerType.Keyboard => RTpRgPUMXmfrwsQHhNZtoTAYWAum(controllerMap as KeyboardMap, skipDisabledMaps, forceCheckAllCategories), 
					ControllerType.Mouse => HiuAusQTMPaucEsmxpCOtiLHuMyl(controllerMap as MouseMap, skipDisabledMaps, forceCheckAllCategories), 
					ControllerType.Custom => KsiGgKpKWUaDzSCcGkreOmvDbBEK(controllerId, controllerMap as CustomControllerMap, skipDisabledMaps, forceCheckAllCategories), 
					_ => throw new NotImplementedException(), 
				};
			}

			public IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap)
			{
				return ElementAssignmentConflicts(controllerType, controllerId, controllerMap, elementMap, skipDisabledMaps: false, forceCheckAllCategories: false);
			}

			public IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap, bool skipDisabledMaps)
			{
				return ElementAssignmentConflicts(controllerType, controllerId, controllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories: false);
			}

			public IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap, bool skipDisabledMaps, bool forceCheckAllCategories)
			{
				if (ReInput._id != FcKIhGECAPoDpEyufemoHBfzGajQA)
				{
					ReInput.CheckInitialized(FcKIhGECAPoDpEyufemoHBfzGajQA);
					return EmptyObjects<ElementAssignmentConflictInfo>.EmptyReadOnlyIListT;
				}
				if (controllerMap == null || elementMap == null)
				{
					return new List<ElementAssignmentConflictInfo>();
				}
				return controllerType switch
				{
					ControllerType.Joystick => oIExpgMlZIoTZIcUlDTQThZXDnxJA(controllerId, controllerMap as JoystickMap, elementMap, skipDisabledMaps, forceCheckAllCategories), 
					ControllerType.Keyboard => RlYRkLWCcYiyGKPvjlDQkPfLFzhU(controllerMap as KeyboardMap, elementMap, skipDisabledMaps, forceCheckAllCategories), 
					ControllerType.Mouse => gBzSOlEbiHpeIuxFmnVhlOTQnuni(controllerMap as MouseMap, elementMap, skipDisabledMaps, forceCheckAllCategories), 
					ControllerType.Custom => fjBGPvcEBJmewaMaKnvQDHvPpAOwb(controllerId, controllerMap as CustomControllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories), 
					_ => throw new NotImplementedException(), 
				};
			}

			public IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck)
			{
				return ElementAssignmentConflicts(conflictCheck, skipDisabledMaps: false, forceCheckAllCategories: false);
			}

			public IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
			{
				return ElementAssignmentConflicts(conflictCheck, skipDisabledMaps, forceCheckAllCategories: false);
			}

			public IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps, bool forceCheckAllCategories)
			{
				if (ReInput._id != FcKIhGECAPoDpEyufemoHBfzGajQA)
				{
					ReInput.CheckInitialized(FcKIhGECAPoDpEyufemoHBfzGajQA);
					return EmptyObjects<ElementAssignmentConflictInfo>.EmptyReadOnlyIListT;
				}
				if (conflictCheck.controllerType == ControllerType.Joystick)
				{
					return hqLLBjuhUOeAaMkVmEyvzpscchKb(conflictCheck, skipDisabledMaps, forceCheckAllCategories);
				}
				if (conflictCheck.controllerType == ControllerType.Keyboard)
				{
					return jQibdaDrZmShrFcThrwwXjZREiEO(conflictCheck, skipDisabledMaps, forceCheckAllCategories);
				}
				if (conflictCheck.controllerType == ControllerType.Mouse)
				{
					return YIavCmnzdMaoLmrRsJjdIQdGSqhL(conflictCheck, skipDisabledMaps, forceCheckAllCategories);
				}
				if (conflictCheck.controllerType == ControllerType.Custom)
				{
					return mpFUtesYQkuNHdLknwXcXbJDEFcP(conflictCheck, skipDisabledMaps, forceCheckAllCategories);
				}
				throw new NotImplementedException();
			}

			public int RemoveElementAssignmentConflicts(ControllerType controllerType, int controllerId, ControllerMap controllerMap)
			{
				return RemoveElementAssignmentConflicts(controllerType, controllerId, controllerMap, skipRemovedMaps: false, forceCheckAllCategories: false);
			}

			public int RemoveElementAssignmentConflicts(ControllerType controllerType, int controllerId, ControllerMap controllerMap, bool skipRemovedMaps)
			{
				return RemoveElementAssignmentConflicts(controllerType, controllerId, controllerMap, skipRemovedMaps, forceCheckAllCategories: false);
			}

			public int RemoveElementAssignmentConflicts(ControllerType controllerType, int controllerId, ControllerMap controllerMap, bool skipRemovedMaps, bool forceCheckAllCategories)
			{
				if (ReInput._id != FcKIhGECAPoDpEyufemoHBfzGajQA)
				{
					ReInput.CheckInitialized(FcKIhGECAPoDpEyufemoHBfzGajQA);
					return 0;
				}
				if (controllerMap == null)
				{
					return 0;
				}
				return controllerType switch
				{
					ControllerType.Joystick => yDxWvsTekPxlVpzbTXpsIwsPabbC(controllerId, controllerMap as JoystickMap, skipRemovedMaps, forceCheckAllCategories), 
					ControllerType.Keyboard => wGAwNZbBQDgPywtJpMwRHqDyWpIj(controllerMap as KeyboardMap, skipRemovedMaps, forceCheckAllCategories), 
					ControllerType.Mouse => ixUzXbplTbnxdyCPTzgWndeGXcNI(controllerMap as MouseMap, skipRemovedMaps, forceCheckAllCategories), 
					ControllerType.Custom => RVUiDTDsCROPQWwCfPOYxlZCsVBt(controllerId, controllerMap as CustomControllerMap, skipRemovedMaps, forceCheckAllCategories), 
					_ => throw new NotImplementedException(), 
				};
			}

			public int RemoveElementAssignmentConflicts(ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap)
			{
				return RemoveElementAssignmentConflicts(controllerType, controllerId, controllerMap, elementMap, skipRemovedMaps: false, forceCheckAllCategories: false);
			}

			public int RemoveElementAssignmentConflicts(ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap, bool skipRemovedMaps)
			{
				return RemoveElementAssignmentConflicts(controllerType, controllerId, controllerMap, elementMap, skipRemovedMaps, forceCheckAllCategories: false);
			}

			public int RemoveElementAssignmentConflicts(ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap, bool skipRemovedMaps, bool forceCheckAllCategories)
			{
				if (ReInput._id != FcKIhGECAPoDpEyufemoHBfzGajQA)
				{
					ReInput.CheckInitialized(FcKIhGECAPoDpEyufemoHBfzGajQA);
					return 0;
				}
				if (controllerMap == null || elementMap == null)
				{
					return 0;
				}
				return controllerType switch
				{
					ControllerType.Joystick => yndApDEuSDQKopUyifnixGUUxrMj(controllerId, controllerMap as JoystickMap, elementMap, skipRemovedMaps, forceCheckAllCategories), 
					ControllerType.Keyboard => TAtabxrFgfGMPMvoSPNfPZMLBuxP(controllerMap as KeyboardMap, elementMap, skipRemovedMaps, forceCheckAllCategories), 
					ControllerType.Mouse => JZDcWeFTQvEhdmsBJwFbCewcPhmk(controllerMap as MouseMap, elementMap, skipRemovedMaps, forceCheckAllCategories), 
					ControllerType.Custom => oLtFLiTbjRbkAMLqJcEqIEQzaDLy(controllerId, controllerMap as CustomControllerMap, elementMap, skipRemovedMaps, forceCheckAllCategories), 
					_ => throw new NotImplementedException(), 
				};
			}

			public int RemoveElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck)
			{
				return RemoveElementAssignmentConflicts(conflictCheck, skipRemovedMaps: false, forceCheckAllCategories: false);
			}

			public int RemoveElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipRemovedMaps)
			{
				return RemoveElementAssignmentConflicts(conflictCheck, skipRemovedMaps, forceCheckAllCategories: false);
			}

			public int RemoveElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipRemovedMaps, bool forceCheckAllCategories)
			{
				if (ReInput._id != FcKIhGECAPoDpEyufemoHBfzGajQA)
				{
					ReInput.CheckInitialized(FcKIhGECAPoDpEyufemoHBfzGajQA);
					return 0;
				}
				if (conflictCheck.controllerType == ControllerType.Joystick)
				{
					return XFqUscdwrGukXNrWLYWiLQFeBiqj(conflictCheck, skipRemovedMaps, forceCheckAllCategories);
				}
				if (conflictCheck.controllerType == ControllerType.Keyboard)
				{
					return JgKcrmGjzkvgSUmFoqqVDXLaNxLrB(conflictCheck, skipRemovedMaps, forceCheckAllCategories);
				}
				if (conflictCheck.controllerType == ControllerType.Mouse)
				{
					return OgXBSLKElIMdtAikofQJApmBcGWG(conflictCheck, skipRemovedMaps, forceCheckAllCategories);
				}
				if (conflictCheck.controllerType == ControllerType.Custom)
				{
					return gKDIfKnUPAJZwxMoUFmdBrFfOYMn(conflictCheck, skipRemovedMaps, forceCheckAllCategories);
				}
				throw new NotImplementedException();
			}

			public int DisableElementAssignmentConflicts(ControllerType controllerType, int controllerId, ControllerMap controllerMap)
			{
				return DisableElementAssignmentConflicts(controllerType, controllerId, controllerMap, skipDisabledMaps: false, forceCheckAllCategories: false);
			}

			public int DisableElementAssignmentConflicts(ControllerType controllerType, int controllerId, ControllerMap controllerMap, bool skipDisabledMaps)
			{
				return DisableElementAssignmentConflicts(controllerType, controllerId, controllerMap, skipDisabledMaps, forceCheckAllCategories: false);
			}

			public int DisableElementAssignmentConflicts(ControllerType controllerType, int controllerId, ControllerMap controllerMap, bool skipDisabledMaps, bool forceCheckAllCategories)
			{
				if (ReInput._id != FcKIhGECAPoDpEyufemoHBfzGajQA)
				{
					ReInput.CheckInitialized(FcKIhGECAPoDpEyufemoHBfzGajQA);
					return 0;
				}
				if (controllerMap == null)
				{
					return 0;
				}
				return controllerType switch
				{
					ControllerType.Joystick => IALGVIUMBAeJygxeOHmvMgcDqkzBb(controllerId, controllerMap as JoystickMap, skipDisabledMaps, forceCheckAllCategories), 
					ControllerType.Keyboard => AClARGfazAuGGJvMoMCqjIxzEfPX(controllerMap as KeyboardMap, skipDisabledMaps, forceCheckAllCategories), 
					ControllerType.Mouse => NrmmFzcoVVcTNAFFZDvxzTWDAmycA(controllerMap as MouseMap, skipDisabledMaps, forceCheckAllCategories), 
					ControllerType.Custom => oQmgnogBnYqeFPabBnHVvfpLnioz(controllerId, controllerMap as CustomControllerMap, skipDisabledMaps, forceCheckAllCategories), 
					_ => throw new NotImplementedException(), 
				};
			}

			public int DisableElementAssignmentConflicts(ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap)
			{
				return DisableElementAssignmentConflicts(controllerType, controllerId, controllerMap, elementMap, skipDisabledMaps: false, forceCheckAllCategories: false);
			}

			public int DisableElementAssignmentConflicts(ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap, bool skipDisabledMaps)
			{
				return DisableElementAssignmentConflicts(controllerType, controllerId, controllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories: false);
			}

			public int DisableElementAssignmentConflicts(ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap, bool skipDisabledMaps, bool forceCheckAllCategories)
			{
				if (ReInput._id != FcKIhGECAPoDpEyufemoHBfzGajQA)
				{
					ReInput.CheckInitialized(FcKIhGECAPoDpEyufemoHBfzGajQA);
					return 0;
				}
				if (controllerMap == null || elementMap == null)
				{
					return 0;
				}
				return controllerType switch
				{
					ControllerType.Joystick => GwiAYSRIWuLuiNtzHvKopcwOHdzv(controllerId, controllerMap as JoystickMap, elementMap, skipDisabledMaps, forceCheckAllCategories), 
					ControllerType.Keyboard => ZuGFjWgQBnGbaUdUNBpiVQQSJdmDb(controllerMap as KeyboardMap, elementMap, skipDisabledMaps, forceCheckAllCategories), 
					ControllerType.Mouse => nFehVXqNUOpEdTkosgKaClQtHRoz(controllerMap as MouseMap, elementMap, skipDisabledMaps, forceCheckAllCategories), 
					ControllerType.Custom => TTWXsdexMrEokkMIHsxABszmlGNy(controllerId, controllerMap as CustomControllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories), 
					_ => throw new NotImplementedException(), 
				};
			}

			public int DisableElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck)
			{
				return DisableElementAssignmentConflicts(conflictCheck, skipDisabledMaps: false, forceCheckAllCategories: false);
			}

			public int DisableElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
			{
				return DisableElementAssignmentConflicts(conflictCheck, skipDisabledMaps, forceCheckAllCategories: false);
			}

			public int DisableElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps, bool forceCheckAllCategories)
			{
				if (ReInput._id != FcKIhGECAPoDpEyufemoHBfzGajQA)
				{
					ReInput.CheckInitialized(FcKIhGECAPoDpEyufemoHBfzGajQA);
					return 0;
				}
				if (conflictCheck.controllerType == ControllerType.Joystick)
				{
					return eNsBoeaMwMMeMGdrFdVztDLekzzfA(conflictCheck, skipDisabledMaps, forceCheckAllCategories);
				}
				if (conflictCheck.controllerType == ControllerType.Keyboard)
				{
					return LsWxgWkgyQVvPyAeSawIcmHRmNkeA(conflictCheck, skipDisabledMaps, forceCheckAllCategories);
				}
				if (conflictCheck.controllerType == ControllerType.Mouse)
				{
					return nZHqlDWroFRgCEnOkDkEfFqbgHGo(conflictCheck, skipDisabledMaps, forceCheckAllCategories);
				}
				if (conflictCheck.controllerType == ControllerType.Custom)
				{
					return bSImpSgMJepryHUCCBrqTjMqcPud(conflictCheck, skipDisabledMaps, forceCheckAllCategories);
				}
				throw new NotImplementedException();
			}

			private bool MFOlkdspEEUzcXCQgzUBkiaLpcUq(int P_0, JoystickMap P_1, bool P_2 = false, bool P_3 = false)
			{
				if (P_0 < 0 || P_1 == null)
				{
					return false;
				}
				for (int i = 0; i < eiqsZVPHBaSbtbaEQWQevZlaNXhK.UZODjZPyOKvXiogzadHvXQZXjpbh().rphZqyUfbdoINyXndGfDbQaiIHFM(); i++)
				{
					if (eiqsZVPHBaSbtbaEQWQevZlaNXhK.UZODjZPyOKvXiogzadHvXQZXjpbh().IqlJUjIBLQbuSkAhcRvowzpPOQIC(i).vEpnAhSIoVrCnOfAmeqwGuTGoWnB.id == P_0 && kQHnRJkemRTazZejFAYzTUGqwFLj(ControllerType.Joystick, P_0, P_1, P_2, P_3, eiqsZVPHBaSbtbaEQWQevZlaNXhK.UZODjZPyOKvXiogzadHvXQZXjpbh().IqlJUjIBLQbuSkAhcRvowzpPOQIC(i).urKiLjIJcqceLbXuNYNvuMSWJkNF))
					{
						return true;
					}
				}
				return false;
			}

			private bool ZrXpYivODGirEXhhwREJatDjtpzK(int P_0, JoystickMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false)
			{
				if (P_0 < 0 || P_2 == null)
				{
					return false;
				}
				for (int i = 0; i < eiqsZVPHBaSbtbaEQWQevZlaNXhK.UZODjZPyOKvXiogzadHvXQZXjpbh().rphZqyUfbdoINyXndGfDbQaiIHFM(); i++)
				{
					if (eiqsZVPHBaSbtbaEQWQevZlaNXhK.UZODjZPyOKvXiogzadHvXQZXjpbh().IqlJUjIBLQbuSkAhcRvowzpPOQIC(i).vEpnAhSIoVrCnOfAmeqwGuTGoWnB.id == P_0 && mPKpCFKqpvgaMDQvyOJQcVfuhWsoA(ControllerType.Joystick, P_0, P_1, P_2, P_3, P_4, eiqsZVPHBaSbtbaEQWQevZlaNXhK.UZODjZPyOKvXiogzadHvXQZXjpbh().IqlJUjIBLQbuSkAhcRvowzpPOQIC(i).urKiLjIJcqceLbXuNYNvuMSWJkNF))
					{
						return true;
					}
				}
				return false;
			}

			private bool sKCmyHlEHWBPizLWScgpjZTuQIHE(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false)
			{
				if (P_0.controllerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
				{
					return false;
				}
				for (int i = 0; i < eiqsZVPHBaSbtbaEQWQevZlaNXhK.UZODjZPyOKvXiogzadHvXQZXjpbh().rphZqyUfbdoINyXndGfDbQaiIHFM(); i++)
				{
					if (eiqsZVPHBaSbtbaEQWQevZlaNXhK.UZODjZPyOKvXiogzadHvXQZXjpbh().IqlJUjIBLQbuSkAhcRvowzpPOQIC(i).vEpnAhSIoVrCnOfAmeqwGuTGoWnB.id == P_0.controllerId && XUsaXEgDyrvGPqpqNncSmKoXjcym(P_0, P_1, P_2, eiqsZVPHBaSbtbaEQWQevZlaNXhK.UZODjZPyOKvXiogzadHvXQZXjpbh().IqlJUjIBLQbuSkAhcRvowzpPOQIC(i).urKiLjIJcqceLbXuNYNvuMSWJkNF))
					{
						return true;
					}
				}
				return false;
			}

			private bool iLGgoNuXsuAVdDpcXWeDYGVRasuZ(KeyboardMap P_0, bool P_1 = false, bool P_2 = false)
			{
				return kQHnRJkemRTazZejFAYzTUGqwFLj(ControllerType.Keyboard, 0, P_0, P_1, P_2, eiqsZVPHBaSbtbaEQWQevZlaNXhK.ivRzFyGkRxcFHWceHEDLRMPkSFKl());
			}

			private bool ATZBOjAyslnXPRwxpvAabAekHkPKA(KeyboardMap P_0, ActionElementMap P_1, bool P_2 = false, bool P_3 = false)
			{
				return mPKpCFKqpvgaMDQvyOJQcVfuhWsoA(ControllerType.Keyboard, 0, P_0, P_1, P_2, P_3, eiqsZVPHBaSbtbaEQWQevZlaNXhK.ivRzFyGkRxcFHWceHEDLRMPkSFKl());
			}

			private bool OrRrfGGLWhcaCUvgaSeGDaylYGmR(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false)
			{
				if (P_0.elementAssignmentType != ElementAssignmentType.KeyboardKey)
				{
					return false;
				}
				return XUsaXEgDyrvGPqpqNncSmKoXjcym(P_0, P_1, P_2, eiqsZVPHBaSbtbaEQWQevZlaNXhK.ivRzFyGkRxcFHWceHEDLRMPkSFKl());
			}

			private bool eOrpcDKMtpcNWphbwwTdXMoNlgwu(MouseMap P_0, bool P_1 = false, bool P_2 = false)
			{
				return kQHnRJkemRTazZejFAYzTUGqwFLj(ControllerType.Mouse, 0, P_0, P_1, P_2, eiqsZVPHBaSbtbaEQWQevZlaNXhK.xrSlrNFaWEBGoLerjuoUWlUclEVD());
			}

			private bool fjqEDqQvKJPhzYjDWwvQXzDlbDio(MouseMap P_0, ActionElementMap P_1, bool P_2 = false, bool P_3 = false)
			{
				return mPKpCFKqpvgaMDQvyOJQcVfuhWsoA(ControllerType.Mouse, 0, P_0, P_1, P_2, P_3, eiqsZVPHBaSbtbaEQWQevZlaNXhK.xrSlrNFaWEBGoLerjuoUWlUclEVD());
			}

			private bool obvCPSjQKJEeRHuVKmLHReqjXlbg(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false)
			{
				if (P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
				{
					return false;
				}
				return XUsaXEgDyrvGPqpqNncSmKoXjcym(P_0, P_1, P_2, eiqsZVPHBaSbtbaEQWQevZlaNXhK.xrSlrNFaWEBGoLerjuoUWlUclEVD());
			}

			private bool RlqvyboFolcpjTWftUtQRbvMPAIJ(int P_0, CustomControllerMap P_1, bool P_2 = false, bool P_3 = false)
			{
				if (P_0 < 0 || P_1 == null)
				{
					return false;
				}
				for (int i = 0; i < eiqsZVPHBaSbtbaEQWQevZlaNXhK.QrSKTUzPSjlCKZGLJDqOVrJyplcf().rphZqyUfbdoINyXndGfDbQaiIHFM(); i++)
				{
					if (eiqsZVPHBaSbtbaEQWQevZlaNXhK.QrSKTUzPSjlCKZGLJDqOVrJyplcf().IqlJUjIBLQbuSkAhcRvowzpPOQIC(i).vEpnAhSIoVrCnOfAmeqwGuTGoWnB.id == P_0 && kQHnRJkemRTazZejFAYzTUGqwFLj(ControllerType.Custom, P_0, P_1, P_2, P_3, eiqsZVPHBaSbtbaEQWQevZlaNXhK.QrSKTUzPSjlCKZGLJDqOVrJyplcf().IqlJUjIBLQbuSkAhcRvowzpPOQIC(i).urKiLjIJcqceLbXuNYNvuMSWJkNF))
					{
						return true;
					}
				}
				return false;
			}

			private bool jQtfSaoOQvzRqhIBlvTfsJwgvOxW(int P_0, CustomControllerMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false)
			{
				if (P_0 < 0 || P_2 == null)
				{
					return false;
				}
				for (int i = 0; i < eiqsZVPHBaSbtbaEQWQevZlaNXhK.QrSKTUzPSjlCKZGLJDqOVrJyplcf().rphZqyUfbdoINyXndGfDbQaiIHFM(); i++)
				{
					if (eiqsZVPHBaSbtbaEQWQevZlaNXhK.QrSKTUzPSjlCKZGLJDqOVrJyplcf().IqlJUjIBLQbuSkAhcRvowzpPOQIC(i).vEpnAhSIoVrCnOfAmeqwGuTGoWnB.id == P_0 && mPKpCFKqpvgaMDQvyOJQcVfuhWsoA(ControllerType.Custom, P_0, P_1, P_2, P_3, P_4, eiqsZVPHBaSbtbaEQWQevZlaNXhK.QrSKTUzPSjlCKZGLJDqOVrJyplcf().IqlJUjIBLQbuSkAhcRvowzpPOQIC(i).urKiLjIJcqceLbXuNYNvuMSWJkNF))
					{
						return true;
					}
				}
				return false;
			}

			private bool GgVQOrEGsllcdjjudKMwlgwAVfUr(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false)
			{
				if (P_0.controllerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
				{
					return false;
				}
				for (int i = 0; i < eiqsZVPHBaSbtbaEQWQevZlaNXhK.QrSKTUzPSjlCKZGLJDqOVrJyplcf().rphZqyUfbdoINyXndGfDbQaiIHFM(); i++)
				{
					if (eiqsZVPHBaSbtbaEQWQevZlaNXhK.QrSKTUzPSjlCKZGLJDqOVrJyplcf().IqlJUjIBLQbuSkAhcRvowzpPOQIC(i).vEpnAhSIoVrCnOfAmeqwGuTGoWnB.id == P_0.controllerId && XUsaXEgDyrvGPqpqNncSmKoXjcym(P_0, P_1, P_2, eiqsZVPHBaSbtbaEQWQevZlaNXhK.QrSKTUzPSjlCKZGLJDqOVrJyplcf().IqlJUjIBLQbuSkAhcRvowzpPOQIC(i).urKiLjIJcqceLbXuNYNvuMSWJkNF))
					{
						return true;
					}
				}
				return false;
			}

			[IteratorStateMachine(typeof(kIRPYmvoSPEYBHqHApIIkozVeqwbA))]
			private IEnumerable<ElementAssignmentConflictInfo> VRBaDJJnlFDUaEQRHtsYYcKrTgZFb(int P_0, JoystickMap P_1, bool P_2 = false, bool P_3 = false)
			{
				return new kIRPYmvoSPEYBHqHApIIkozVeqwbA(-2)
				{
					pNCrsfECpwRRTgfpfbIgugPQHexiA = this,
					ZCoraMSYRoNaPfinxolwocxWxYDv = P_0,
					MxISvpTKULNGZUJjqJyeBVANjaRC = P_1,
					bmoyzrrZTlYkQxHkUczetGVFBxvh = P_2,
					kOnSWEfKQMmLPcTCIAhMAmVJUUih = P_3
				};
			}

			[IteratorStateMachine(typeof(eBvcvrHgbnEzeAKybXozklnrBRuEB))]
			private IEnumerable<ElementAssignmentConflictInfo> oIExpgMlZIoTZIcUlDTQThZXDnxJA(int P_0, JoystickMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false)
			{
				return new eBvcvrHgbnEzeAKybXozklnrBRuEB(-2)
				{
					YyZWbmqGkERgDRdyGlYxZANEeHcT = this,
					jQcUxvCPDekppSgtQlmLbkvEAxuQ = P_0,
					XVNJGDOLenaksVstBUERcbktjRku = P_1,
					VxvHUPypMEfnRfxamxwQPhRKZKaY = P_2,
					PkUALkPwnkMMJOYdFVJeWwhAkgcv = P_3,
					AUgtlygnmVUdjnDAjBTDowJKbkMM = P_4
				};
			}

			[IteratorStateMachine(typeof(hhHvMtqQHulprXJNOHbArByZrLkv))]
			private IEnumerable<ElementAssignmentConflictInfo> hqLLBjuhUOeAaMkVmEyvzpscchKb(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false)
			{
				return new hhHvMtqQHulprXJNOHbArByZrLkv(-2)
				{
					bYAxnMarHNtfJfVceLnbyqSeLJIo = this,
					subXudMcCseUuKxVdnWnGsHoqQiA = P_0,
					bleIPJLoRrKSdtmfkFigCNjhKJXR = P_1,
					qRVAytdmtBuLsynxtYVrylVvdCMt = P_2
				};
			}

			private IEnumerable<ElementAssignmentConflictInfo> RTpRgPUMXmfrwsQHhNZtoTAYWAum(KeyboardMap P_0, bool P_1 = false, bool P_2 = false)
			{
				return PZeHctZEgnZEAlGnDwqoALlTosXv(ControllerType.Keyboard, 0, P_0, P_1, P_2, eiqsZVPHBaSbtbaEQWQevZlaNXhK.ivRzFyGkRxcFHWceHEDLRMPkSFKl());
			}

			private IEnumerable<ElementAssignmentConflictInfo> RlYRkLWCcYiyGKPvjlDQkPfLFzhU(KeyboardMap P_0, ActionElementMap P_1, bool P_2 = false, bool P_3 = false)
			{
				return nnrAnrmVqGqiiUDbLllpALDTVtBj(ControllerType.Keyboard, 0, P_0, P_1, P_2, P_3, eiqsZVPHBaSbtbaEQWQevZlaNXhK.ivRzFyGkRxcFHWceHEDLRMPkSFKl());
			}

			private IEnumerable<ElementAssignmentConflictInfo> jQibdaDrZmShrFcThrwwXjZREiEO(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false)
			{
				if (P_0.elementAssignmentType != ElementAssignmentType.KeyboardKey)
				{
					return new List<ElementAssignmentConflictInfo>();
				}
				return AaFoiqrRMxwJhqGuYjxGLocMtIft(P_0, P_1, P_2, eiqsZVPHBaSbtbaEQWQevZlaNXhK.ivRzFyGkRxcFHWceHEDLRMPkSFKl());
			}

			private IEnumerable<ElementAssignmentConflictInfo> HiuAusQTMPaucEsmxpCOtiLHuMyl(MouseMap P_0, bool P_1 = false, bool P_2 = false)
			{
				return PZeHctZEgnZEAlGnDwqoALlTosXv(ControllerType.Mouse, 0, P_0, P_1, P_2, eiqsZVPHBaSbtbaEQWQevZlaNXhK.xrSlrNFaWEBGoLerjuoUWlUclEVD());
			}

			private IEnumerable<ElementAssignmentConflictInfo> gBzSOlEbiHpeIuxFmnVhlOTQnuni(MouseMap P_0, ActionElementMap P_1, bool P_2 = false, bool P_3 = false)
			{
				return nnrAnrmVqGqiiUDbLllpALDTVtBj(ControllerType.Mouse, 0, P_0, P_1, P_2, P_3, eiqsZVPHBaSbtbaEQWQevZlaNXhK.xrSlrNFaWEBGoLerjuoUWlUclEVD());
			}

			private IEnumerable<ElementAssignmentConflictInfo> YIavCmnzdMaoLmrRsJjdIQdGSqhL(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false)
			{
				if (P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
				{
					return new List<ElementAssignmentConflictInfo>();
				}
				return AaFoiqrRMxwJhqGuYjxGLocMtIft(P_0, P_1, P_2, eiqsZVPHBaSbtbaEQWQevZlaNXhK.xrSlrNFaWEBGoLerjuoUWlUclEVD());
			}

			[IteratorStateMachine(typeof(QXQNJwNiPsFdXsXPWglJzEMRbXHZ))]
			private IEnumerable<ElementAssignmentConflictInfo> KsiGgKpKWUaDzSCcGkreOmvDbBEK(int P_0, CustomControllerMap P_1, bool P_2 = false, bool P_3 = false)
			{
				return new QXQNJwNiPsFdXsXPWglJzEMRbXHZ(-2)
				{
					crDlyLqEVkOJcjfsHfoMEaGtNoaGb = this,
					uRdhXBeCqOOvPDUFOXnwoemyxQxx = P_0,
					XkNLxDLuTYJCZvMAFsEkUGpRMjEv = P_1,
					fjoULhLKrjHbnuqTbrAOTSzRfdTS = P_2,
					sDkbHKDKatKtIhRzjOQtErGxOGcQA = P_3
				};
			}

			[IteratorStateMachine(typeof(MtlEwkFiMKubSScfSrahTslThkGD))]
			private IEnumerable<ElementAssignmentConflictInfo> fjBGPvcEBJmewaMaKnvQDHvPpAOwb(int P_0, CustomControllerMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false)
			{
				return new MtlEwkFiMKubSScfSrahTslThkGD(-2)
				{
					DExoxtWQIeVPCFnOIPTUcEfngJhD = this,
					HrDAZRjKZKOVNPnngDigGsqhCoYe = P_0,
					cSwzdQiCHOesahClAfSwPBnqTaxWA = P_1,
					aLDnFzuNVtHfUwuQQHUuryJpqkig = P_2,
					mGvwWHZamBxNmGkeSePBLQooQbkR = P_3,
					hdDkbMnNczBcmhYfccyjsrMosPYd = P_4
				};
			}

			[IteratorStateMachine(typeof(WrIYasTbJUDGDeibqYIVwfIcXLwCA))]
			private IEnumerable<ElementAssignmentConflictInfo> mpFUtesYQkuNHdLknwXcXbJDEFcP(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false)
			{
				return new WrIYasTbJUDGDeibqYIVwfIcXLwCA(-2)
				{
					QOJeYJWIUzblKWSSdirypItDZVCM = this,
					tRRgiiuOIrQqeWvGKFHLCyuFsUIW = P_0,
					bajcoGhdmcVOmOlnzaUJrVOizvCjA = P_1,
					qWdHKVFuvDORlgKDtQULVLCndZcj = P_2
				};
			}

			private int yDxWvsTekPxlVpzbTXpsIwsPabbC(int P_0, JoystickMap P_1, bool P_2 = false, bool P_3 = false)
			{
				if (P_0 < 0 || P_1 == null)
				{
					return 0;
				}
				int num = 0;
				for (int i = 0; i < eiqsZVPHBaSbtbaEQWQevZlaNXhK.UZODjZPyOKvXiogzadHvXQZXjpbh().rphZqyUfbdoINyXndGfDbQaiIHFM(); i++)
				{
					if (eiqsZVPHBaSbtbaEQWQevZlaNXhK.UZODjZPyOKvXiogzadHvXQZXjpbh().IqlJUjIBLQbuSkAhcRvowzpPOQIC(i).vEpnAhSIoVrCnOfAmeqwGuTGoWnB.id == P_0)
					{
						num += sdncgGGCvZbOOuTqJkKVWtXjiYysA(ControllerType.Joystick, P_0, P_1, P_2, P_3, eiqsZVPHBaSbtbaEQWQevZlaNXhK.UZODjZPyOKvXiogzadHvXQZXjpbh().IqlJUjIBLQbuSkAhcRvowzpPOQIC(i).urKiLjIJcqceLbXuNYNvuMSWJkNF);
					}
				}
				return num;
			}

			private int yndApDEuSDQKopUyifnixGUUxrMj(int P_0, JoystickMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false)
			{
				if (P_0 < 0 || P_2 == null)
				{
					return 0;
				}
				int num = 0;
				for (int i = 0; i < eiqsZVPHBaSbtbaEQWQevZlaNXhK.UZODjZPyOKvXiogzadHvXQZXjpbh().rphZqyUfbdoINyXndGfDbQaiIHFM(); i++)
				{
					if (eiqsZVPHBaSbtbaEQWQevZlaNXhK.UZODjZPyOKvXiogzadHvXQZXjpbh().IqlJUjIBLQbuSkAhcRvowzpPOQIC(i).vEpnAhSIoVrCnOfAmeqwGuTGoWnB.id == P_0)
					{
						num += siBxglyIbCyLVUVTywJRsMsqhlBm(ControllerType.Joystick, P_0, P_1, P_2, P_3, P_4, eiqsZVPHBaSbtbaEQWQevZlaNXhK.UZODjZPyOKvXiogzadHvXQZXjpbh().IqlJUjIBLQbuSkAhcRvowzpPOQIC(i).urKiLjIJcqceLbXuNYNvuMSWJkNF);
					}
				}
				return num;
			}

			private int XFqUscdwrGukXNrWLYWiLQFeBiqj(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false)
			{
				if (P_0.controllerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
				{
					return 0;
				}
				int num = 0;
				for (int i = 0; i < eiqsZVPHBaSbtbaEQWQevZlaNXhK.UZODjZPyOKvXiogzadHvXQZXjpbh().rphZqyUfbdoINyXndGfDbQaiIHFM(); i++)
				{
					if (eiqsZVPHBaSbtbaEQWQevZlaNXhK.UZODjZPyOKvXiogzadHvXQZXjpbh().IqlJUjIBLQbuSkAhcRvowzpPOQIC(i).vEpnAhSIoVrCnOfAmeqwGuTGoWnB.id == P_0.controllerId)
					{
						num += TeqEJVofWrdAgpamkMadOHETbMcq(P_0, P_1, P_2, eiqsZVPHBaSbtbaEQWQevZlaNXhK.UZODjZPyOKvXiogzadHvXQZXjpbh().IqlJUjIBLQbuSkAhcRvowzpPOQIC(i).urKiLjIJcqceLbXuNYNvuMSWJkNF);
					}
				}
				return num;
			}

			private int wGAwNZbBQDgPywtJpMwRHqDyWpIj(KeyboardMap P_0, bool P_1 = false, bool P_2 = false)
			{
				return sdncgGGCvZbOOuTqJkKVWtXjiYysA(ControllerType.Keyboard, 0, P_0, P_1, P_2, eiqsZVPHBaSbtbaEQWQevZlaNXhK.ivRzFyGkRxcFHWceHEDLRMPkSFKl());
			}

			private int TAtabxrFgfGMPMvoSPNfPZMLBuxP(KeyboardMap P_0, ActionElementMap P_1, bool P_2 = false, bool P_3 = false)
			{
				return siBxglyIbCyLVUVTywJRsMsqhlBm(ControllerType.Keyboard, 0, P_0, P_1, P_2, P_3, eiqsZVPHBaSbtbaEQWQevZlaNXhK.ivRzFyGkRxcFHWceHEDLRMPkSFKl());
			}

			private int JgKcrmGjzkvgSUmFoqqVDXLaNxLrB(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false)
			{
				if (P_0.elementAssignmentType != ElementAssignmentType.KeyboardKey)
				{
					return 0;
				}
				return TeqEJVofWrdAgpamkMadOHETbMcq(P_0, P_1, P_2, eiqsZVPHBaSbtbaEQWQevZlaNXhK.ivRzFyGkRxcFHWceHEDLRMPkSFKl());
			}

			private int ixUzXbplTbnxdyCPTzgWndeGXcNI(MouseMap P_0, bool P_1 = false, bool P_2 = false)
			{
				return sdncgGGCvZbOOuTqJkKVWtXjiYysA(ControllerType.Mouse, 0, P_0, P_1, P_2, eiqsZVPHBaSbtbaEQWQevZlaNXhK.xrSlrNFaWEBGoLerjuoUWlUclEVD());
			}

			private int JZDcWeFTQvEhdmsBJwFbCewcPhmk(MouseMap P_0, ActionElementMap P_1, bool P_2 = false, bool P_3 = false)
			{
				return siBxglyIbCyLVUVTywJRsMsqhlBm(ControllerType.Mouse, 0, P_0, P_1, P_2, P_3, eiqsZVPHBaSbtbaEQWQevZlaNXhK.xrSlrNFaWEBGoLerjuoUWlUclEVD());
			}

			private int OgXBSLKElIMdtAikofQJApmBcGWG(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false)
			{
				if (P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
				{
					return 0;
				}
				return TeqEJVofWrdAgpamkMadOHETbMcq(P_0, P_1, P_2, eiqsZVPHBaSbtbaEQWQevZlaNXhK.xrSlrNFaWEBGoLerjuoUWlUclEVD());
			}

			private int RVUiDTDsCROPQWwCfPOYxlZCsVBt(int P_0, CustomControllerMap P_1, bool P_2 = false, bool P_3 = false)
			{
				if (P_0 < 0 || P_1 == null)
				{
					return 0;
				}
				int num = 0;
				for (int i = 0; i < eiqsZVPHBaSbtbaEQWQevZlaNXhK.QrSKTUzPSjlCKZGLJDqOVrJyplcf().rphZqyUfbdoINyXndGfDbQaiIHFM(); i++)
				{
					if (eiqsZVPHBaSbtbaEQWQevZlaNXhK.QrSKTUzPSjlCKZGLJDqOVrJyplcf().IqlJUjIBLQbuSkAhcRvowzpPOQIC(i).vEpnAhSIoVrCnOfAmeqwGuTGoWnB.id == P_0)
					{
						num += sdncgGGCvZbOOuTqJkKVWtXjiYysA(ControllerType.Custom, P_0, P_1, P_2, P_3, eiqsZVPHBaSbtbaEQWQevZlaNXhK.QrSKTUzPSjlCKZGLJDqOVrJyplcf().IqlJUjIBLQbuSkAhcRvowzpPOQIC(i).urKiLjIJcqceLbXuNYNvuMSWJkNF);
					}
				}
				return num;
			}

			private int oLtFLiTbjRbkAMLqJcEqIEQzaDLy(int P_0, CustomControllerMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false)
			{
				if (P_0 < 0 || P_2 == null)
				{
					return 0;
				}
				int num = 0;
				for (int i = 0; i < eiqsZVPHBaSbtbaEQWQevZlaNXhK.QrSKTUzPSjlCKZGLJDqOVrJyplcf().rphZqyUfbdoINyXndGfDbQaiIHFM(); i++)
				{
					if (eiqsZVPHBaSbtbaEQWQevZlaNXhK.QrSKTUzPSjlCKZGLJDqOVrJyplcf().IqlJUjIBLQbuSkAhcRvowzpPOQIC(i).vEpnAhSIoVrCnOfAmeqwGuTGoWnB.id == P_0)
					{
						num += siBxglyIbCyLVUVTywJRsMsqhlBm(ControllerType.Custom, P_0, P_1, P_2, P_3, P_4, eiqsZVPHBaSbtbaEQWQevZlaNXhK.QrSKTUzPSjlCKZGLJDqOVrJyplcf().IqlJUjIBLQbuSkAhcRvowzpPOQIC(i).urKiLjIJcqceLbXuNYNvuMSWJkNF);
					}
				}
				return num;
			}

			private int gKDIfKnUPAJZwxMoUFmdBrFfOYMn(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false)
			{
				if (P_0.controllerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
				{
					return 0;
				}
				int num = 0;
				for (int i = 0; i < eiqsZVPHBaSbtbaEQWQevZlaNXhK.QrSKTUzPSjlCKZGLJDqOVrJyplcf().rphZqyUfbdoINyXndGfDbQaiIHFM(); i++)
				{
					if (eiqsZVPHBaSbtbaEQWQevZlaNXhK.QrSKTUzPSjlCKZGLJDqOVrJyplcf().IqlJUjIBLQbuSkAhcRvowzpPOQIC(i).vEpnAhSIoVrCnOfAmeqwGuTGoWnB.id == P_0.controllerId)
					{
						num += TeqEJVofWrdAgpamkMadOHETbMcq(P_0, P_1, P_2, eiqsZVPHBaSbtbaEQWQevZlaNXhK.QrSKTUzPSjlCKZGLJDqOVrJyplcf().IqlJUjIBLQbuSkAhcRvowzpPOQIC(i).urKiLjIJcqceLbXuNYNvuMSWJkNF);
					}
				}
				return num;
			}

			private int IALGVIUMBAeJygxeOHmvMgcDqkzBb(int P_0, JoystickMap P_1, bool P_2 = false, bool P_3 = false, List<ActionElementMap> P_4 = null)
			{
				if (P_0 < 0 || P_1 == null)
				{
					return 0;
				}
				int num = 0;
				for (int i = 0; i < eiqsZVPHBaSbtbaEQWQevZlaNXhK.UZODjZPyOKvXiogzadHvXQZXjpbh().rphZqyUfbdoINyXndGfDbQaiIHFM(); i++)
				{
					if (eiqsZVPHBaSbtbaEQWQevZlaNXhK.UZODjZPyOKvXiogzadHvXQZXjpbh().IqlJUjIBLQbuSkAhcRvowzpPOQIC(i).vEpnAhSIoVrCnOfAmeqwGuTGoWnB.id == P_0)
					{
						num += EYEfpCczaegTbMBgKfwXEuRDkiIwB(ControllerType.Joystick, P_0, P_1, P_2, P_3, eiqsZVPHBaSbtbaEQWQevZlaNXhK.UZODjZPyOKvXiogzadHvXQZXjpbh().IqlJUjIBLQbuSkAhcRvowzpPOQIC(i).urKiLjIJcqceLbXuNYNvuMSWJkNF, P_4);
					}
				}
				return num;
			}

			private int GwiAYSRIWuLuiNtzHvKopcwOHdzv(int P_0, JoystickMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, List<ActionElementMap> P_5 = null)
			{
				if (P_0 < 0 || P_2 == null)
				{
					return 0;
				}
				int num = 0;
				for (int i = 0; i < eiqsZVPHBaSbtbaEQWQevZlaNXhK.UZODjZPyOKvXiogzadHvXQZXjpbh().rphZqyUfbdoINyXndGfDbQaiIHFM(); i++)
				{
					if (eiqsZVPHBaSbtbaEQWQevZlaNXhK.UZODjZPyOKvXiogzadHvXQZXjpbh().IqlJUjIBLQbuSkAhcRvowzpPOQIC(i).vEpnAhSIoVrCnOfAmeqwGuTGoWnB.id == P_0)
					{
						num += RFGmFDeIULBTfEojqjMeUjJYMhmpA(ControllerType.Joystick, P_0, P_1, P_2, P_3, P_4, eiqsZVPHBaSbtbaEQWQevZlaNXhK.UZODjZPyOKvXiogzadHvXQZXjpbh().IqlJUjIBLQbuSkAhcRvowzpPOQIC(i).urKiLjIJcqceLbXuNYNvuMSWJkNF, P_5);
					}
				}
				return num;
			}

			private int eNsBoeaMwMMeMGdrFdVztDLekzzfA(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, List<ActionElementMap> P_3 = null)
			{
				if (P_0.controllerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
				{
					return 0;
				}
				int num = 0;
				for (int i = 0; i < eiqsZVPHBaSbtbaEQWQevZlaNXhK.UZODjZPyOKvXiogzadHvXQZXjpbh().rphZqyUfbdoINyXndGfDbQaiIHFM(); i++)
				{
					if (eiqsZVPHBaSbtbaEQWQevZlaNXhK.UZODjZPyOKvXiogzadHvXQZXjpbh().IqlJUjIBLQbuSkAhcRvowzpPOQIC(i).vEpnAhSIoVrCnOfAmeqwGuTGoWnB.id == P_0.controllerId)
					{
						num += dJUEEiELCOjpkPQDFUzhdhkhlCOE(P_0, P_1, P_2, eiqsZVPHBaSbtbaEQWQevZlaNXhK.UZODjZPyOKvXiogzadHvXQZXjpbh().IqlJUjIBLQbuSkAhcRvowzpPOQIC(i).urKiLjIJcqceLbXuNYNvuMSWJkNF, P_3);
					}
				}
				return num;
			}

			private int AClARGfazAuGGJvMoMCqjIxzEfPX(KeyboardMap P_0, bool P_1 = false, bool P_2 = false, List<ActionElementMap> P_3 = null)
			{
				return EYEfpCczaegTbMBgKfwXEuRDkiIwB(ControllerType.Keyboard, 0, P_0, P_1, P_2, eiqsZVPHBaSbtbaEQWQevZlaNXhK.ivRzFyGkRxcFHWceHEDLRMPkSFKl(), P_3);
			}

			private int ZuGFjWgQBnGbaUdUNBpiVQQSJdmDb(KeyboardMap P_0, ActionElementMap P_1, bool P_2 = false, bool P_3 = false, List<ActionElementMap> P_4 = null)
			{
				return RFGmFDeIULBTfEojqjMeUjJYMhmpA(ControllerType.Keyboard, 0, P_0, P_1, P_2, P_3, eiqsZVPHBaSbtbaEQWQevZlaNXhK.ivRzFyGkRxcFHWceHEDLRMPkSFKl(), P_4);
			}

			private int LsWxgWkgyQVvPyAeSawIcmHRmNkeA(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, List<ActionElementMap> P_3 = null)
			{
				if (P_0.elementAssignmentType != ElementAssignmentType.KeyboardKey)
				{
					return 0;
				}
				return dJUEEiELCOjpkPQDFUzhdhkhlCOE(P_0, P_1, P_2, eiqsZVPHBaSbtbaEQWQevZlaNXhK.ivRzFyGkRxcFHWceHEDLRMPkSFKl(), P_3);
			}

			private int NrmmFzcoVVcTNAFFZDvxzTWDAmycA(MouseMap P_0, bool P_1 = false, bool P_2 = false, List<ActionElementMap> P_3 = null)
			{
				return EYEfpCczaegTbMBgKfwXEuRDkiIwB(ControllerType.Mouse, 0, P_0, P_1, P_2, eiqsZVPHBaSbtbaEQWQevZlaNXhK.xrSlrNFaWEBGoLerjuoUWlUclEVD(), P_3);
			}

			private int nFehVXqNUOpEdTkosgKaClQtHRoz(MouseMap P_0, ActionElementMap P_1, bool P_2 = false, bool P_3 = false, List<ActionElementMap> P_4 = null)
			{
				return RFGmFDeIULBTfEojqjMeUjJYMhmpA(ControllerType.Mouse, 0, P_0, P_1, P_2, P_3, eiqsZVPHBaSbtbaEQWQevZlaNXhK.xrSlrNFaWEBGoLerjuoUWlUclEVD(), P_4);
			}

			private int nZHqlDWroFRgCEnOkDkEfFqbgHGo(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, List<ActionElementMap> P_3 = null)
			{
				if (P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
				{
					return 0;
				}
				return dJUEEiELCOjpkPQDFUzhdhkhlCOE(P_0, P_1, P_2, eiqsZVPHBaSbtbaEQWQevZlaNXhK.xrSlrNFaWEBGoLerjuoUWlUclEVD(), P_3);
			}

			private int oQmgnogBnYqeFPabBnHVvfpLnioz(int P_0, CustomControllerMap P_1, bool P_2 = false, bool P_3 = false, List<ActionElementMap> P_4 = null)
			{
				if (P_0 < 0 || P_1 == null)
				{
					return 0;
				}
				int num = 0;
				for (int i = 0; i < eiqsZVPHBaSbtbaEQWQevZlaNXhK.QrSKTUzPSjlCKZGLJDqOVrJyplcf().rphZqyUfbdoINyXndGfDbQaiIHFM(); i++)
				{
					if (eiqsZVPHBaSbtbaEQWQevZlaNXhK.QrSKTUzPSjlCKZGLJDqOVrJyplcf().IqlJUjIBLQbuSkAhcRvowzpPOQIC(i).vEpnAhSIoVrCnOfAmeqwGuTGoWnB.id == P_0)
					{
						num += EYEfpCczaegTbMBgKfwXEuRDkiIwB(ControllerType.Custom, P_0, P_1, P_2, P_3, eiqsZVPHBaSbtbaEQWQevZlaNXhK.QrSKTUzPSjlCKZGLJDqOVrJyplcf().IqlJUjIBLQbuSkAhcRvowzpPOQIC(i).urKiLjIJcqceLbXuNYNvuMSWJkNF, P_4);
					}
				}
				return num;
			}

			private int TTWXsdexMrEokkMIHsxABszmlGNy(int P_0, CustomControllerMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, List<ActionElementMap> P_5 = null)
			{
				if (P_0 < 0 || P_2 == null)
				{
					return 0;
				}
				int num = 0;
				for (int i = 0; i < eiqsZVPHBaSbtbaEQWQevZlaNXhK.QrSKTUzPSjlCKZGLJDqOVrJyplcf().rphZqyUfbdoINyXndGfDbQaiIHFM(); i++)
				{
					if (eiqsZVPHBaSbtbaEQWQevZlaNXhK.QrSKTUzPSjlCKZGLJDqOVrJyplcf().IqlJUjIBLQbuSkAhcRvowzpPOQIC(i).vEpnAhSIoVrCnOfAmeqwGuTGoWnB.id == P_0)
					{
						num += RFGmFDeIULBTfEojqjMeUjJYMhmpA(ControllerType.Custom, P_0, P_1, P_2, P_3, P_4, eiqsZVPHBaSbtbaEQWQevZlaNXhK.QrSKTUzPSjlCKZGLJDqOVrJyplcf().IqlJUjIBLQbuSkAhcRvowzpPOQIC(i).urKiLjIJcqceLbXuNYNvuMSWJkNF, P_5);
					}
				}
				return num;
			}

			private int bSImpSgMJepryHUCCBrqTjMqcPud(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, List<ActionElementMap> P_3 = null)
			{
				if (P_0.controllerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
				{
					return 0;
				}
				int num = 0;
				for (int i = 0; i < eiqsZVPHBaSbtbaEQWQevZlaNXhK.QrSKTUzPSjlCKZGLJDqOVrJyplcf().rphZqyUfbdoINyXndGfDbQaiIHFM(); i++)
				{
					if (eiqsZVPHBaSbtbaEQWQevZlaNXhK.QrSKTUzPSjlCKZGLJDqOVrJyplcf().IqlJUjIBLQbuSkAhcRvowzpPOQIC(i).vEpnAhSIoVrCnOfAmeqwGuTGoWnB.id == P_0.controllerId)
					{
						num += dJUEEiELCOjpkPQDFUzhdhkhlCOE(P_0, P_1, P_2, eiqsZVPHBaSbtbaEQWQevZlaNXhK.QrSKTUzPSjlCKZGLJDqOVrJyplcf().IqlJUjIBLQbuSkAhcRvowzpPOQIC(i).urKiLjIJcqceLbXuNYNvuMSWJkNF, P_3);
					}
				}
				return num;
			}

			private bool kQHnRJkemRTazZejFAYzTUGqwFLj<_0001>(ControllerType P_0, int P_1, _0001 P_2, bool P_3, bool P_4, global::rspbeSfkijiKRfPuAyBrBqKNCACZB<_0001> P_5) where _0001 : ControllerMap
			{
				if (P_5 == null || P_2 == null)
				{
					return false;
				}
				InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(P_2.categoryId);
				if (mapCategory == null)
				{
					return false;
				}
				for (int i = 0; i < P_5.ejOOZrUqJLRyRGoRofwTThHfNEkF(); i++)
				{
					ControllerMap controllerMap = P_5.xmIhmmDDQdCDzpiurLdyJADZcUhZ(i);
					if ((!P_3 || controllerMap.enabled) && (P_4 || !pJOlttBqyXtegIpOvYsIZCGBQTiE(mapCategory, controllerMap)) && controllerMap.DoesElementAssignmentConflict(P_2, P_3))
					{
						return true;
					}
				}
				return false;
			}

			private bool mPKpCFKqpvgaMDQvyOJQcVfuhWsoA<_0001>(ControllerType P_0, int P_1, _0001 P_2, ActionElementMap P_3, bool P_4, bool P_5, global::rspbeSfkijiKRfPuAyBrBqKNCACZB<_0001> P_6) where _0001 : ControllerMap
			{
				if (P_6 == null || P_3 == null)
				{
					return false;
				}
				InputMapCategory inputMapCategory = ((P_2 != null) ? ReInput.mapping.GetMapCategory(P_2.categoryId) : null);
				for (int i = 0; i < P_6.ejOOZrUqJLRyRGoRofwTThHfNEkF(); i++)
				{
					ControllerMap controllerMap = P_6.xmIhmmDDQdCDzpiurLdyJADZcUhZ(i);
					if ((!P_4 || controllerMap.enabled) && (P_5 || !pJOlttBqyXtegIpOvYsIZCGBQTiE(inputMapCategory, controllerMap)) && controllerMap.DoesElementAssignmentConflict(P_3, P_4))
					{
						return true;
					}
				}
				return false;
			}

			private bool XUsaXEgDyrvGPqpqNncSmKoXjcym<_0001>(ElementAssignmentConflictCheck P_0, bool P_1, bool P_2, global::rspbeSfkijiKRfPuAyBrBqKNCACZB<_0001> P_3) where _0001 : ControllerMap
			{
				if (P_3 == null)
				{
					return false;
				}
				Player player = ReInput.players.GetPlayer(P_0.playerId);
				if (player == null)
				{
					return false;
				}
				ControllerMap map = player.controllers.maps.GetMap(P_0.controllerType, P_0.controllerId, P_0.controllerMapId);
				InputMapCategory inputMapCategory = ((map != null) ? ReInput.mapping.GetMapCategory(map.categoryId) : ReInput.mapping.GetMapCategory(P_0.controllerMapCategoryId));
				if (inputMapCategory == null)
				{
					return false;
				}
				for (int i = 0; i < P_3.ejOOZrUqJLRyRGoRofwTThHfNEkF(); i++)
				{
					ControllerMap controllerMap = P_3.xmIhmmDDQdCDzpiurLdyJADZcUhZ(i);
					if ((!P_1 || controllerMap.enabled) && (P_2 || !pJOlttBqyXtegIpOvYsIZCGBQTiE(inputMapCategory, controllerMap)) && controllerMap.DoesElementAssignmentConflict(P_0, P_1))
					{
						return true;
					}
				}
				return false;
			}

			[IteratorStateMachine(typeof(zGsFyRIiixeHlkFpbXNOPkOingfYA))]
			private IEnumerable<ElementAssignmentConflictInfo> PZeHctZEgnZEAlGnDwqoALlTosXv<_0001>(ControllerType P_0, int P_1, _0001 P_2, bool P_3, bool P_4, global::rspbeSfkijiKRfPuAyBrBqKNCACZB<_0001> P_5) where _0001 : ControllerMap
			{
				return new zGsFyRIiixeHlkFpbXNOPkOingfYA<_0001>(-2)
				{
					RhhRoLqIuQHwQWFLevryMfwRvnPm = this,
					zPaaesIBBVcWlDcLnaFQFPcaKhogc = P_0,
					MVvEqOyUyrshSHdRJdQlHnlwLLNq = P_1,
					ReoKGwmnCrqdWKzJkPkGXAlxeuYgA = P_2,
					ebYnRSWbTgeXTRULEgrFpMPBDjtAA = P_3,
					vlFosEWUayzdTROucnjoBPEgVmim = P_4,
					ccUiqJAOpDxLFtuqxGifiRWbrWbXb = P_5
				};
			}

			[IteratorStateMachine(typeof(IhecbtQgULTmMCoXoGbdXVHcDIJt))]
			private IEnumerable<ElementAssignmentConflictInfo> nnrAnrmVqGqiiUDbLllpALDTVtBj<_0001>(ControllerType P_0, int P_1, _0001 P_2, ActionElementMap P_3, bool P_4, bool P_5, global::rspbeSfkijiKRfPuAyBrBqKNCACZB<_0001> P_6) where _0001 : ControllerMap
			{
				return new IhecbtQgULTmMCoXoGbdXVHcDIJt<_0001>(-2)
				{
					ugAbxPbNFnFdzCCtHXctIYeriGXoA = this,
					qNRvlkYgzXeBUaNktaGsGONFmIdvA = P_0,
					chcMDPlyqeNuraRaRcmapfOrwmoR = P_1,
					NDFHvcRMgNrQpKuLeHmlNfCbiIos = P_2,
					HdBykGauGuGSikRzQxYCMJpAKjQJ = P_3,
					jqnEYoMAwZMOwvOIlrRCWtscUzEM = P_4,
					WFwXcRRXktrwpieLZxiETywJeLKe = P_5,
					YExDrFoWMLaueidQULMhkSCUMJvhA = P_6
				};
			}

			[IteratorStateMachine(typeof(bMsFPTkPLsjnVQzzuRqgFCllBzzSA))]
			private IEnumerable<ElementAssignmentConflictInfo> AaFoiqrRMxwJhqGuYjxGLocMtIft<_0001>(ElementAssignmentConflictCheck P_0, bool P_1, bool P_2, global::rspbeSfkijiKRfPuAyBrBqKNCACZB<_0001> P_3) where _0001 : ControllerMap
			{
				return new bMsFPTkPLsjnVQzzuRqgFCllBzzSA<_0001>(-2)
				{
					phlxpSpBydXPGCZDAczNvKsOCIjx = this,
					WVQgkhVODMSBPZJbYIOyJeNDoEvRA = P_0,
					fGVGfuzlKjRqBaAykitMZpVbsbbR = P_1,
					VMRLoWpSBPhaDrAxziQcxDnicolR = P_2,
					CoRGrjBfRPXLcIjQBIRiIimWGaMbb = P_3
				};
			}

			private int sdncgGGCvZbOOuTqJkKVWtXjiYysA<_0001>(ControllerType P_0, int P_1, _0001 P_2, bool P_3, bool P_4, global::rspbeSfkijiKRfPuAyBrBqKNCACZB<_0001> P_5) where _0001 : ControllerMap
			{
				if (P_5 == null || P_2 == null)
				{
					return 0;
				}
				InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(P_2.categoryId);
				if (mapCategory == null)
				{
					return 0;
				}
				int num = 0;
				for (int i = 0; i < P_5.ejOOZrUqJLRyRGoRofwTThHfNEkF(); i++)
				{
					ControllerMap controllerMap = P_5.xmIhmmDDQdCDzpiurLdyJADZcUhZ(i);
					if ((!P_3 || controllerMap.enabled) && (P_4 || !pJOlttBqyXtegIpOvYsIZCGBQTiE(mapCategory, controllerMap)))
					{
						num += controllerMap.RemoveElementAssignmentConflicts(P_2, P_3);
					}
				}
				return num;
			}

			private int siBxglyIbCyLVUVTywJRsMsqhlBm<_0001>(ControllerType P_0, int P_1, _0001 P_2, ActionElementMap P_3, bool P_4, bool P_5, global::rspbeSfkijiKRfPuAyBrBqKNCACZB<_0001> P_6) where _0001 : ControllerMap
			{
				if (P_6 == null || P_3 == null)
				{
					return 0;
				}
				InputMapCategory inputMapCategory = ((P_2 != null) ? ReInput.mapping.GetMapCategory(P_2.categoryId) : null);
				int num = 0;
				for (int i = 0; i < P_6.ejOOZrUqJLRyRGoRofwTThHfNEkF(); i++)
				{
					ControllerMap controllerMap = P_6.xmIhmmDDQdCDzpiurLdyJADZcUhZ(i);
					if ((!P_4 || controllerMap.enabled) && (P_5 || !pJOlttBqyXtegIpOvYsIZCGBQTiE(inputMapCategory, controllerMap)))
					{
						num += controllerMap.RemoveElementAssignmentConflicts(P_3, P_4);
					}
				}
				return num;
			}

			private int TeqEJVofWrdAgpamkMadOHETbMcq<_0001>(ElementAssignmentConflictCheck P_0, bool P_1, bool P_2, global::rspbeSfkijiKRfPuAyBrBqKNCACZB<_0001> P_3) where _0001 : ControllerMap
			{
				if (P_3 == null)
				{
					return 0;
				}
				Player player = ReInput.players.GetPlayer(P_0.playerId);
				if (player == null)
				{
					return 0;
				}
				ControllerMap map = player.controllers.maps.GetMap(P_0.controllerType, P_0.controllerId, P_0.controllerMapId);
				InputMapCategory inputMapCategory = ((map != null) ? ReInput.mapping.GetMapCategory(map.categoryId) : ReInput.mapping.GetMapCategory(P_0.controllerMapCategoryId));
				if (inputMapCategory == null)
				{
					return 0;
				}
				int num = 0;
				for (int i = 0; i < P_3.ejOOZrUqJLRyRGoRofwTThHfNEkF(); i++)
				{
					ControllerMap controllerMap = P_3.xmIhmmDDQdCDzpiurLdyJADZcUhZ(i);
					if ((!P_1 || controllerMap.enabled) && (P_2 || !pJOlttBqyXtegIpOvYsIZCGBQTiE(inputMapCategory, controllerMap)))
					{
						num += controllerMap.RemoveElementAssignmentConflicts(P_0, P_1);
					}
				}
				return num;
			}

			private int EYEfpCczaegTbMBgKfwXEuRDkiIwB<_0001>(ControllerType P_0, int P_1, _0001 P_2, bool P_3, bool P_4, global::rspbeSfkijiKRfPuAyBrBqKNCACZB<_0001> P_5, List<ActionElementMap> P_6 = null) where _0001 : ControllerMap
			{
				P_6?.Clear();
				if (P_5 == null || P_2 == null)
				{
					return 0;
				}
				InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(P_2.categoryId);
				if (mapCategory == null)
				{
					return 0;
				}
				int num = 0;
				for (int i = 0; i < P_5.ejOOZrUqJLRyRGoRofwTThHfNEkF(); i++)
				{
					ControllerMap controllerMap = P_5.xmIhmmDDQdCDzpiurLdyJADZcUhZ(i);
					if ((!P_3 || controllerMap.enabled) && (P_4 || !pJOlttBqyXtegIpOvYsIZCGBQTiE(mapCategory, controllerMap)))
					{
						num += controllerMap.KQXSSitueJXGlwhxDCvZlKiAkqgh(P_2, P_3, P_6, true);
					}
				}
				return num;
			}

			private int RFGmFDeIULBTfEojqjMeUjJYMhmpA<_0001>(ControllerType P_0, int P_1, _0001 P_2, ActionElementMap P_3, bool P_4, bool P_5, global::rspbeSfkijiKRfPuAyBrBqKNCACZB<_0001> P_6, List<ActionElementMap> P_7 = null) where _0001 : ControllerMap
			{
				P_7?.Clear();
				if (P_6 == null || P_3 == null)
				{
					return 0;
				}
				InputMapCategory inputMapCategory = ((P_2 != null) ? ReInput.mapping.GetMapCategory(P_2.categoryId) : null);
				int num = 0;
				for (int i = 0; i < P_6.ejOOZrUqJLRyRGoRofwTThHfNEkF(); i++)
				{
					ControllerMap controllerMap = P_6.xmIhmmDDQdCDzpiurLdyJADZcUhZ(i);
					if ((!P_4 || controllerMap.enabled) && (P_5 || !pJOlttBqyXtegIpOvYsIZCGBQTiE(inputMapCategory, controllerMap)))
					{
						num += controllerMap.ATkMWznydIsmMYtjoavrhFVKJGcj(P_3, P_4, P_7, true);
					}
				}
				return num;
			}

			private int dJUEEiELCOjpkPQDFUzhdhkhlCOE<_0001>(ElementAssignmentConflictCheck P_0, bool P_1, bool P_2, global::rspbeSfkijiKRfPuAyBrBqKNCACZB<_0001> P_3, List<ActionElementMap> P_4 = null) where _0001 : ControllerMap
			{
				P_4?.Clear();
				if (P_3 == null)
				{
					return 0;
				}
				Player player = ReInput.players.GetPlayer(P_0.playerId);
				if (player == null)
				{
					return 0;
				}
				ControllerMap map = player.controllers.maps.GetMap(P_0.controllerType, P_0.controllerId, P_0.controllerMapId);
				InputMapCategory inputMapCategory = ((map != null) ? ReInput.mapping.GetMapCategory(map.categoryId) : ReInput.mapping.GetMapCategory(P_0.controllerMapCategoryId));
				if (inputMapCategory == null)
				{
					return 0;
				}
				int num = 0;
				for (int i = 0; i < P_3.ejOOZrUqJLRyRGoRofwTThHfNEkF(); i++)
				{
					ControllerMap controllerMap = P_3.xmIhmmDDQdCDzpiurLdyJADZcUhZ(i);
					if ((!P_1 || controllerMap.enabled) && (P_2 || !pJOlttBqyXtegIpOvYsIZCGBQTiE(inputMapCategory, controllerMap)))
					{
						num += controllerMap.slUwgXrcYEXSwNCmAHrYogBZIKCZ(P_0, P_1, P_4, true);
					}
				}
				return num;
			}

			private bool pJOlttBqyXtegIpOvYsIZCGBQTiE(InputMapCategory P_0, ControllerMap P_1)
			{
				if (P_0 == null || P_1 == null)
				{
					return false;
				}
				if (P_0.checkConflictsWithAllCategories)
				{
					return false;
				}
				IList<int> checkConflictsCategoryIds = P_0.checkConflictsCategoryIds;
				if (checkConflictsCategoryIds == null)
				{
					return true;
				}
				for (int i = 0; i < checkConflictsCategoryIds.Count; i++)
				{
					if (checkConflictsCategoryIds[i] == P_1.categoryId)
					{
						return false;
					}
				}
				return true;
			}
		}

		[DefaultMember("Item")]
		internal interface HENtlJpbLTfyvGNBdnYOTBUpGwmPA
		{
			// C# has no syntax for parameterized property 'UnXSGFUrOlPLhXbvLGMGERwEkuXy'.
			AShuyBCharjMzjKIZJtOvccShXtr get_UnXSGFUrOlPLhXbvLGMGERwEkuXy(int P_0);

			ControllerType ahfcJxvsieBIKboydYpuNCCQmVeIA { get; }

			int HTBSlCJEZCFtDlnoBYfsMHKkFxUh { get; }

			AShuyBCharjMzjKIZJtOvccShXtr gmqWnmpZMnASuZpGLEqmJcwgXIqMA(int P_0);

			ControllerType dfCsqzjNkxnRCLjXzSnDwrOkiBYk();

			int rphZqyUfbdoINyXndGfDbQaiIHFM();

			bool oKIhqMxhmkGqyhXzRvaLEUVrBxgxA(Controller P_0);

			bool qeQAZQmgxcHqHizaGnELPEdIYlFN(int P_0);

			void VGyDVwkBtTRddOpvLPQiEkZkOaRk(int P_0);

			void KCkaJkwiEOPhDYmIWKdwbWaGnWJS(Controller P_0);

			void efIhWBBIGFwodHIELLmRiiYFXSzQb(int P_0);

			Controller LfjMQuyzfsNjHNOGJnqsCFAAYMBj(int P_0);

			Controller IDybHFsLNznIXwmYCUieaHGEyevs(string P_0);

			int iOZTbxwPJyQRehSyPrCTkOHEBSkY(Controller P_0);

			int LwDtjAISpvZKUEBiCEPKHyoscvdr(int P_0);

			int vjJUeXuRjCySrJyvoVnseEELAuGK(string P_0);

			void CHDaUwGARteSiOLodcLIyYCDkANd();

			AShuyBCharjMzjKIZJtOvccShXtr EiaJdcLRNPgisAQlXkogBqWdcrPqb(int P_0);

			AShuyBCharjMzjKIZJtOvccShXtr tyclpzZIUUBUPVHZmQIcnazyLDhy(Controller P_0);

			void ezcDNeepWSxgQWKjHyrGpxdUzKgaA(AShuyBCharjMzjKIZJtOvccShXtr P_0);
		}

		internal interface AShuyBCharjMzjKIZJtOvccShXtr
		{
			FsyiqPdJeSfbLIuiSYvjZeDpZMzW gWPGhzSqRISkAejhMZjynSiBFtmP { get; }

			Controller lNzzuFHroJwajAKURYmwhzoMiotg { get; }

			double izEKRHfezeOcPpKHMubvbAZmbyiN { get; }

			FsyiqPdJeSfbLIuiSYvjZeDpZMzW ycfaKniCLOzZqlQviANrBfbEZIlRA();

			Controller hfcnXcmxHjJxWTdCahVjbHZvxlVj();

			double ersRHTHxrHOeGRJSusaWslJcbnWC();
		}

		[DefaultMember("Item")]
		internal sealed class DGwRdGOlPFvMefvreaSvufGXwqlI<_0001, _0002> : HENtlJpbLTfyvGNBdnYOTBUpGwmPA where _0001 : Controller where _0002 : ControllerMap
		{
			public class ULpvOcMrCuZQnwHsGOOZRCagYnur : AShuyBCharjMzjKIZJtOvccShXtr
			{
				public _0001 vEpnAhSIoVrCnOfAmeqwGuTGoWnB;

				public global::rspbeSfkijiKRfPuAyBrBqKNCACZB<_0002> urKiLjIJcqceLbXuNYNvuMSWJkNF;

				public double dJNEqzxmhsgpuXIwdicuchfdbOAB;

				Controller hfcnXcmxHjJxWTdCahVjbHZvxlVj => Rewired_002EPlayer_002EControllerHelper_002EIControllerSetEntry_002Eget_controller();

				FsyiqPdJeSfbLIuiSYvjZeDpZMzW ycfaKniCLOzZqlQviANrBfbEZIlRA => Rewired_002EPlayer_002EControllerHelper_002EIControllerSetEntry_002Eget_mapSet();

				double ersRHTHxrHOeGRJSusaWslJcbnWC => Rewired_002EPlayer_002EControllerHelper_002EIControllerSetEntry_002Eget_lastActiveTime();

				private Controller Rewired_002EPlayer_002EControllerHelper_002EIControllerSetEntry_002Eget_controller()
				{
					return vEpnAhSIoVrCnOfAmeqwGuTGoWnB;
				}

				private FsyiqPdJeSfbLIuiSYvjZeDpZMzW Rewired_002EPlayer_002EControllerHelper_002EIControllerSetEntry_002Eget_mapSet()
				{
					return urKiLjIJcqceLbXuNYNvuMSWJkNF;
				}

				private double Rewired_002EPlayer_002EControllerHelper_002EIControllerSetEntry_002Eget_lastActiveTime()
				{
					return dJNEqzxmhsgpuXIwdicuchfdbOAB;
				}

				public ULpvOcMrCuZQnwHsGOOZRCagYnur(_0001 P_0, global::rspbeSfkijiKRfPuAyBrBqKNCACZB<_0002> P_1)
				{
					vEpnAhSIoVrCnOfAmeqwGuTGoWnB = P_0;
					urKiLjIJcqceLbXuNYNvuMSWJkNF = P_1;
				}

				public void SPyBrPgaASIalGixWiFBOAxqAMxQ()
				{
					dJNEqzxmhsgpuXIwdicuchfdbOAB = ReInput.unscaledTime;
				}
			}

			private List<ULpvOcMrCuZQnwHsGOOZRCagYnur> AZqMYJySFobbUFQzMdeQRazHewbZ;

			private List<_0001> yaqMekDCmhCMWPQLHGdfYINgSRrh;

			private ReadOnlyCollection<_0001> meLOXrMKCDwbdoRDVxpRaSHvAUIQ;

			private readonly ControllerType DMpXTZhOjMnUWwwmksSrRqmCCjos;

			int rphZqyUfbdoINyXndGfDbQaiIHFM => rphZqyUfbdoINyXndGfDbQaiIHFM();

			public IList<_0001> pTFhgKXWOYitHgLpmUmRxVfyzvjH => cmeeIbUCxjHUqdNCBHHJgoMnHEVA();

			// C# has no syntax for parameterized property 'RAMeISIImwzQfvVuaSXXshkbznRhA'.
			public ULpvOcMrCuZQnwHsGOOZRCagYnur get_RAMeISIImwzQfvVuaSXXshkbznRhA(int P_0)
			{
				return IqlJUjIBLQbuSkAhcRvowzpPOQIC(P_0);
			}

			ControllerType dfCsqzjNkxnRCLjXzSnDwrOkiBYk => dfCsqzjNkxnRCLjXzSnDwrOkiBYk();

			// C# has no syntax for parameterized property 'Rewired.Player.ControllerHelper.HENtlJpbLTfyvGNBdnYOTBUpGwmPA.gmqWnmpZMnASuZpGLEqmJcwgXIqMA'.
			AShuyBCharjMzjKIZJtOvccShXtr HENtlJpbLTfyvGNBdnYOTBUpGwmPA.get_gmqWnmpZMnASuZpGLEqmJcwgXIqMA(int index)
			{
				return Rewired_002EPlayer_002EControllerHelper_002EIControllerSet_002Eget_Item(index);
			}

			public int rphZqyUfbdoINyXndGfDbQaiIHFM()
			{
				return AZqMYJySFobbUFQzMdeQRazHewbZ.Count;
			}

			public IList<_0001> cmeeIbUCxjHUqdNCBHHJgoMnHEVA()
			{
				return meLOXrMKCDwbdoRDVxpRaSHvAUIQ;
			}

			public ULpvOcMrCuZQnwHsGOOZRCagYnur IqlJUjIBLQbuSkAhcRvowzpPOQIC(int P_0)
			{
				return AZqMYJySFobbUFQzMdeQRazHewbZ[P_0];
			}

			public ControllerType dfCsqzjNkxnRCLjXzSnDwrOkiBYk()
			{
				return DMpXTZhOjMnUWwwmksSrRqmCCjos;
			}

			public DGwRdGOlPFvMefvreaSvufGXwqlI()
			{
				if ((object)IyPmashUlRgIygDiHFyDZHZmauql.mnyQTmYDFygUonAMLuEUwwISRTTl<_0001>() != typeof(_0002))
				{
					throw new Exception(typeof(_0001).Name + " cannot be used with a map of type " + typeof(_0002).Name);
				}
				DMpXTZhOjMnUWwwmksSrRqmCCjos = IyPmashUlRgIygDiHFyDZHZmauql.viogenbfSYJFlamNuPhNxVygaGnmA(typeof(_0001));
				AZqMYJySFobbUFQzMdeQRazHewbZ = new List<ULpvOcMrCuZQnwHsGOOZRCagYnur>();
				yaqMekDCmhCMWPQLHGdfYINgSRrh = new List<_0001>();
				meLOXrMKCDwbdoRDVxpRaSHvAUIQ = new ReadOnlyCollection<_0001>(yaqMekDCmhCMWPQLHGdfYINgSRrh);
			}

			public ULpvOcMrCuZQnwHsGOOZRCagYnur BcfpteWrBVhewabjMjJgojJvyuIF(int P_0)
			{
				if (DMpXTZhOjMnUWwwmksSrRqmCCjos == ControllerType.Keyboard || DMpXTZhOjMnUWwwmksSrRqmCCjos == ControllerType.Mouse)
				{
					P_0 = 0;
				}
				int num = FQlCGYDMrzjpZioOFCKylxQaRhuk(P_0);
				if (num < 0)
				{
					return null;
				}
				return AZqMYJySFobbUFQzMdeQRazHewbZ[num];
			}

			public ULpvOcMrCuZQnwHsGOOZRCagYnur fVzoOvHVHZsaZcbHogdIFFybCZgEb(_0001 P_0)
			{
				if (P_0 == null)
				{
					return null;
				}
				return BcfpteWrBVhewabjMjJgojJvyuIF(P_0.id);
			}

			public void jHNkJhAZkNtzFbWPCvWFyUgPHiCF(ULpvOcMrCuZQnwHsGOOZRCagYnur P_0)
			{
				if (P_0 != null)
				{
					AZqMYJySFobbUFQzMdeQRazHewbZ.Add(P_0);
					yaqMekDCmhCMWPQLHGdfYINgSRrh.Add(P_0.vEpnAhSIoVrCnOfAmeqwGuTGoWnB);
				}
			}

			public void bKycvwENpqtgdnjKzaxPSHhrGdpOA(int P_0)
			{
				if (DMpXTZhOjMnUWwwmksSrRqmCCjos == ControllerType.Keyboard || DMpXTZhOjMnUWwwmksSrRqmCCjos == ControllerType.Mouse)
				{
					P_0 = 0;
				}
				if (FQlCGYDMrzjpZioOFCKylxQaRhuk(P_0) < 0)
				{
					return;
				}
				for (int i = 0; i < AZqMYJySFobbUFQzMdeQRazHewbZ.Count; i++)
				{
					if (AZqMYJySFobbUFQzMdeQRazHewbZ[i].vEpnAhSIoVrCnOfAmeqwGuTGoWnB.id == P_0)
					{
						QsEWLlSQxDdwplbkDiIeiyPYSCQl(i);
						break;
					}
				}
			}

			void HENtlJpbLTfyvGNBdnYOTBUpGwmPA.VGyDVwkBtTRddOpvLPQiEkZkOaRk(int P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in bKycvwENpqtgdnjKzaxPSHhrGdpOA
				this.bKycvwENpqtgdnjKzaxPSHhrGdpOA(P_0);
			}

			public void unNFMVbzQiMvNlpSCHzbAZvmMHxnA(_0001 P_0)
			{
				if (P_0 != null && P_0.type == DMpXTZhOjMnUWwwmksSrRqmCCjos)
				{
					bKycvwENpqtgdnjKzaxPSHhrGdpOA(P_0.id);
				}
			}

			public void QsEWLlSQxDdwplbkDiIeiyPYSCQl(int P_0)
			{
				if (P_0 >= 0 && P_0 < AZqMYJySFobbUFQzMdeQRazHewbZ.Count)
				{
					AZqMYJySFobbUFQzMdeQRazHewbZ.RemoveAt(P_0);
					yaqMekDCmhCMWPQLHGdfYINgSRrh.RemoveAt(P_0);
				}
			}

			void HENtlJpbLTfyvGNBdnYOTBUpGwmPA.efIhWBBIGFwodHIELLmRiiYFXSzQb(int P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in QsEWLlSQxDdwplbkDiIeiyPYSCQl
				this.QsEWLlSQxDdwplbkDiIeiyPYSCQl(P_0);
			}

			public _0001 ItlmsOroseYUCAODTiImPLXMrYyA(int P_0)
			{
				if (DMpXTZhOjMnUWwwmksSrRqmCCjos == ControllerType.Keyboard || DMpXTZhOjMnUWwwmksSrRqmCCjos == ControllerType.Mouse)
				{
					P_0 = 0;
				}
				int num = FQlCGYDMrzjpZioOFCKylxQaRhuk(P_0);
				if (num < 0)
				{
					return null;
				}
				return AZqMYJySFobbUFQzMdeQRazHewbZ[num].vEpnAhSIoVrCnOfAmeqwGuTGoWnB;
			}

			public bool bjADKiHUATqswnqxIEtaxxTbWreWA(int P_0)
			{
				if (DMpXTZhOjMnUWwwmksSrRqmCCjos == ControllerType.Keyboard || DMpXTZhOjMnUWwwmksSrRqmCCjos == ControllerType.Mouse)
				{
					P_0 = 0;
				}
				if (P_0 < 0)
				{
					return false;
				}
				for (int i = 0; i < AZqMYJySFobbUFQzMdeQRazHewbZ.Count; i++)
				{
					if (AZqMYJySFobbUFQzMdeQRazHewbZ[i].vEpnAhSIoVrCnOfAmeqwGuTGoWnB.id == P_0)
					{
						return true;
					}
				}
				return false;
			}

			bool HENtlJpbLTfyvGNBdnYOTBUpGwmPA.qeQAZQmgxcHqHizaGnELPEdIYlFN(int P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in bjADKiHUATqswnqxIEtaxxTbWreWA
				return this.bjADKiHUATqswnqxIEtaxxTbWreWA(P_0);
			}

			public bool JenWitPftxVWIjDXxesEXrtoZdyB(_0001 P_0)
			{
				if (P_0 == null)
				{
					return false;
				}
				if (P_0.type != DMpXTZhOjMnUWwwmksSrRqmCCjos)
				{
					return false;
				}
				return bjADKiHUATqswnqxIEtaxxTbWreWA(P_0.id);
			}

			public int FQlCGYDMrzjpZioOFCKylxQaRhuk(int P_0)
			{
				if (DMpXTZhOjMnUWwwmksSrRqmCCjos == ControllerType.Keyboard || DMpXTZhOjMnUWwwmksSrRqmCCjos == ControllerType.Mouse)
				{
					P_0 = 0;
				}
				if (P_0 < 0)
				{
					return -1;
				}
				for (int i = 0; i < AZqMYJySFobbUFQzMdeQRazHewbZ.Count; i++)
				{
					if (AZqMYJySFobbUFQzMdeQRazHewbZ[i].vEpnAhSIoVrCnOfAmeqwGuTGoWnB.id == P_0)
					{
						return i;
					}
				}
				return -1;
			}

			int HENtlJpbLTfyvGNBdnYOTBUpGwmPA.LwDtjAISpvZKUEBiCEPKHyoscvdr(int P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in FQlCGYDMrzjpZioOFCKylxQaRhuk
				return this.FQlCGYDMrzjpZioOFCKylxQaRhuk(P_0);
			}

			public int poEJySQIKMLFqYWiWbmKwpiKejedA(_0001 P_0)
			{
				if (P_0 == null)
				{
					return -1;
				}
				if (P_0.type != DMpXTZhOjMnUWwwmksSrRqmCCjos)
				{
					return -1;
				}
				return FQlCGYDMrzjpZioOFCKylxQaRhuk(P_0.id);
			}

			public int qtkUrhgumiMeYYTKzSvctHuAUfQO(string P_0)
			{
				if (P_0 == null || P_0 == string.Empty)
				{
					return -1;
				}
				for (int i = 0; i < AZqMYJySFobbUFQzMdeQRazHewbZ.Count; i++)
				{
					if (AZqMYJySFobbUFQzMdeQRazHewbZ[i].vEpnAhSIoVrCnOfAmeqwGuTGoWnB.tag.Equals(P_0, StringComparison.OrdinalIgnoreCase))
					{
						return i;
					}
				}
				return -1;
			}

			int HENtlJpbLTfyvGNBdnYOTBUpGwmPA.vjJUeXuRjCySrJyvoVnseEELAuGK(string P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in qtkUrhgumiMeYYTKzSvctHuAUfQO
				return this.qtkUrhgumiMeYYTKzSvctHuAUfQO(P_0);
			}

			public void rSRGsGAvokJhebZNcOTLMSLjemeyB()
			{
				AZqMYJySFobbUFQzMdeQRazHewbZ.Clear();
				yaqMekDCmhCMWPQLHGdfYINgSRrh.Clear();
			}

			void HENtlJpbLTfyvGNBdnYOTBUpGwmPA.CHDaUwGARteSiOLodcLIyYCDkANd()
			{
				//ILSpy generated this explicit interface implementation from .override directive in rSRGsGAvokJhebZNcOTLMSLjemeyB
				this.rSRGsGAvokJhebZNcOTLMSLjemeyB();
			}

			private AShuyBCharjMzjKIZJtOvccShXtr Rewired_002EPlayer_002EControllerHelper_002EIControllerSet_002Eget_Item(int index)
			{
				return AZqMYJySFobbUFQzMdeQRazHewbZ[index];
			}

			AShuyBCharjMzjKIZJtOvccShXtr HENtlJpbLTfyvGNBdnYOTBUpGwmPA.GetEntry(int controllerId)
			{
				return BcfpteWrBVhewabjMjJgojJvyuIF(controllerId);
			}

			AShuyBCharjMzjKIZJtOvccShXtr HENtlJpbLTfyvGNBdnYOTBUpGwmPA.GetEntry(Controller controller)
			{
				if (controller as _0001 == null)
				{
					return null;
				}
				return fVzoOvHVHZsaZcbHogdIFFybCZgEb(controller as _0001);
			}

			void HENtlJpbLTfyvGNBdnYOTBUpGwmPA.AddEntry(AShuyBCharjMzjKIZJtOvccShXtr entry)
			{
				jHNkJhAZkNtzFbWPCvWFyUgPHiCF((ULpvOcMrCuZQnwHsGOOZRCagYnur)entry);
			}

			void HENtlJpbLTfyvGNBdnYOTBUpGwmPA.RemoveController(Controller controller)
			{
				unNFMVbzQiMvNlpSCHzbAZvmMHxnA(controller as _0001);
			}

			Controller HENtlJpbLTfyvGNBdnYOTBUpGwmPA.GetController(int controllerId)
			{
				return ItlmsOroseYUCAODTiImPLXMrYyA(controllerId);
			}

			bool HENtlJpbLTfyvGNBdnYOTBUpGwmPA.Contains(Controller controller)
			{
				return JenWitPftxVWIjDXxesEXrtoZdyB(controller as _0001);
			}

			int HENtlJpbLTfyvGNBdnYOTBUpGwmPA.IndexOf(Controller controller)
			{
				return poEJySQIKMLFqYWiWbmKwpiKejedA(controller as _0001);
			}

			Controller HENtlJpbLTfyvGNBdnYOTBUpGwmPA.GetControllerWithTag(string tag)
			{
				int num = qtkUrhgumiMeYYTKzSvctHuAUfQO(tag);
				if (num < 0)
				{
					return null;
				}
				return AZqMYJySFobbUFQzMdeQRazHewbZ[num].vEpnAhSIoVrCnOfAmeqwGuTGoWnB;
			}
		}

		internal class DDMnmwcSVutbFmZAzhkOWZMCBxWv
		{
			public readonly int KzSWyhVFpKvuMAleUEiVntIEyGZD;

			private ControllerType[] cbYblQKBTNxGpOrsEPlphrSyVLxVA;

			private HENtlJpbLTfyvGNBdnYOTBUpGwmPA[] lAdFCDCVHCxHDOylrocwjckOoAEsA;

			public HENtlJpbLTfyvGNBdnYOTBUpGwmPA AMmiEUMJUxmCKCltvrDeLoaPvEGE(int P_0)
			{
				return lAdFCDCVHCxHDOylrocwjckOoAEsA[P_0];
			}

			public ControllerType JZVdeJdqcyVABFyDAQNnnsvkBpKvA(int P_0)
			{
				return cbYblQKBTNxGpOrsEPlphrSyVLxVA[P_0];
			}

			public DDMnmwcSVutbFmZAzhkOWZMCBxWv(int P_0)
			{
				KzSWyhVFpKvuMAleUEiVntIEyGZD = MathTools.Max(0, P_0);
				cbYblQKBTNxGpOrsEPlphrSyVLxVA = new ControllerType[P_0];
				lAdFCDCVHCxHDOylrocwjckOoAEsA = new HENtlJpbLTfyvGNBdnYOTBUpGwmPA[P_0];
			}

			public HENtlJpbLTfyvGNBdnYOTBUpGwmPA AXLlayIlTwJqJNaNzeKccuszIcODb(ControllerType P_0)
			{
				for (int i = 0; i < KzSWyhVFpKvuMAleUEiVntIEyGZD; i++)
				{
					if (P_0 == cbYblQKBTNxGpOrsEPlphrSyVLxVA[i])
					{
						return lAdFCDCVHCxHDOylrocwjckOoAEsA[i];
					}
				}
				throw new Exception("Value is not in the set.");
			}

			public void aJWjxFHrPoEvJuwjmdYgjlqgKoQt(int P_0, ControllerType P_1, HENtlJpbLTfyvGNBdnYOTBUpGwmPA P_2)
			{
				cbYblQKBTNxGpOrsEPlphrSyVLxVA[P_0] = P_1;
				lAdFCDCVHCxHDOylrocwjckOoAEsA[P_0] = P_2;
			}
		}

		private class QHvleXMfQGGsGSDUArrcLeNstTyw
		{
			public class cUmptiDojEDwOqLAhQgbYiyfxeXu
			{
				public int GAbEmPBMsSFNFVBHRVOkKCbbpXmF;

				public global::rspbeSfkijiKRfPuAyBrBqKNCACZB<JoystickMap> zCfbxAiXGysIoVuepKVulKtLysSO;

				public double IqTgzwiXudFILaSboUapIowoZOpmA;

				public cUmptiDojEDwOqLAhQgbYiyfxeXu(int P_0, global::rspbeSfkijiKRfPuAyBrBqKNCACZB<JoystickMap> P_1, double P_2)
				{
					GAbEmPBMsSFNFVBHRVOkKCbbpXmF = P_0;
					zCfbxAiXGysIoVuepKVulKtLysSO = P_1;
					IqTgzwiXudFILaSboUapIowoZOpmA = P_2;
				}
			}

			private readonly List<cUmptiDojEDwOqLAhQgbYiyfxeXu> DWUqwJaHhszTRCTDpftcsdAJnpMl;

			private readonly Player gyyMSuILfVdIRYgfOfAbjiEqoNwjA;

			public QHvleXMfQGGsGSDUArrcLeNstTyw(Player P_0)
			{
				gyyMSuILfVdIRYgfOfAbjiEqoNwjA = P_0;
				DWUqwJaHhszTRCTDpftcsdAJnpMl = new List<cUmptiDojEDwOqLAhQgbYiyfxeXu>();
			}

			public void wVDpLSuRoMxdryDWTBJXycBtTJhA(Joystick P_0, global::rspbeSfkijiKRfPuAyBrBqKNCACZB<JoystickMap> P_1)
			{
				for (int i = 0; i < DWUqwJaHhszTRCTDpftcsdAJnpMl.Count; i++)
				{
					cUmptiDojEDwOqLAhQgbYiyfxeXu cUmptiDojEDwOqLAhQgbYiyfxeXu2 = DWUqwJaHhszTRCTDpftcsdAJnpMl[i];
					if (cUmptiDojEDwOqLAhQgbYiyfxeXu2.GAbEmPBMsSFNFVBHRVOkKCbbpXmF == P_0.id)
					{
						cUmptiDojEDwOqLAhQgbYiyfxeXu2.zCfbxAiXGysIoVuepKVulKtLysSO = P_1;
						cUmptiDojEDwOqLAhQgbYiyfxeXu2.IqTgzwiXudFILaSboUapIowoZOpmA = ReInput.realTime;
						return;
					}
				}
				cUmptiDojEDwOqLAhQgbYiyfxeXu item = new cUmptiDojEDwOqLAhQgbYiyfxeXu(P_0.id, P_1, ReInput.realTime);
				DWUqwJaHhszTRCTDpftcsdAJnpMl.Add(item);
			}

			public void qbixfSsnHwqKeXGuuBbZsxhonLkB(DGwRdGOlPFvMefvreaSvufGXwqlI<Joystick, JoystickMap>.ULpvOcMrCuZQnwHsGOOZRCagYnur P_0)
			{
				wVDpLSuRoMxdryDWTBJXycBtTJhA(P_0.vEpnAhSIoVrCnOfAmeqwGuTGoWnB, P_0.urKiLjIJcqceLbXuNYNvuMSWJkNF);
			}

			public void wdcEZJdkDamVPNMSrbSqFSqsqiQQ()
			{
				for (int i = 0; i < DWUqwJaHhszTRCTDpftcsdAJnpMl.Count; i++)
				{
					if (!gyyMSuILfVdIRYgfOfAbjiEqoNwjA.controllers.ContainsController(ControllerType.Joystick, DWUqwJaHhszTRCTDpftcsdAJnpMl[i].GAbEmPBMsSFNFVBHRVOkKCbbpXmF))
					{
						DWUqwJaHhszTRCTDpftcsdAJnpMl[i].zCfbxAiXGysIoVuepKVulKtLysSO = null;
					}
				}
			}

			public cUmptiDojEDwOqLAhQgbYiyfxeXu rdCVwdZckLhQvWrkFzLfdWrXWFgQ(int P_0)
			{
				int num = kWEgsLJMBFYQLPOrjvsioFZSgKTeA(P_0);
				if (num < 0)
				{
					return null;
				}
				return DWUqwJaHhszTRCTDpftcsdAJnpMl[num];
			}

			public bool FXzrRQWLKnvLYdcrabOIAKkbrlXwA(int P_0)
			{
				for (int i = 0; i < DWUqwJaHhszTRCTDpftcsdAJnpMl.Count; i++)
				{
					if (DWUqwJaHhszTRCTDpftcsdAJnpMl[i].GAbEmPBMsSFNFVBHRVOkKCbbpXmF == P_0)
					{
						return true;
					}
				}
				return false;
			}

			public int kWEgsLJMBFYQLPOrjvsioFZSgKTeA(int P_0)
			{
				for (int i = 0; i < DWUqwJaHhszTRCTDpftcsdAJnpMl.Count; i++)
				{
					if (DWUqwJaHhszTRCTDpftcsdAJnpMl[i].GAbEmPBMsSFNFVBHRVOkKCbbpXmF == P_0)
					{
						return i;
					}
				}
				return -1;
			}

			public void icMhQMavCZQKfCtqPZlfGuvmqILEA()
			{
				DWUqwJaHhszTRCTDpftcsdAJnpMl.Clear();
			}
		}

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public sealed class MapHelper : CodeHelper
		{
			private sealed class vsUITgsSOznaUGQdaMfHnKvmtAdO : IEnumerable<ActionElementMap>, IEnumerable, IEnumerator<ActionElementMap>, IEnumerator, IDisposable
			{
				private int CAxJSqHSTEAnOrJkhAfTGxQeWjHgA;

				private ActionElementMap ahHBmUXJOlQVZfJdjIvByLOTfiD;

				private int lsBafDkrqysnDzBeOEKhFaPLDrin;

				public MapHelper zsoKbYAMxYaopWchKiTVtZfoIgLd;

				private int rGRcpRHDinakBkSqXmmcfNahnIkWB;

				public int TRWvXZQznVyisGxseqYRFDOoBIUi;

				private bool LjbJqeuOBGOqmEBXrxCDeXzKBGOs;

				public bool lUfeVmnxJBMRSNQXvXpLhERHEeJL;

				private int PaFNouhJRwJsGXcmjevwobJygTEGA;

				private int WOzLWKqHqxNOkZfklNNZFzQzKiRy;

				private HENtlJpbLTfyvGNBdnYOTBUpGwmPA sbAQCtFDbseAWJfWjVJkFShywqsqA;

				private int juxpnYiLdsFLaFVhFtZXkXqCgwOjA;

				private int FGRrGFlDbyVklWPGojwrnWSSWvmu;

				private FsyiqPdJeSfbLIuiSYvjZeDpZMzW HaQJgTgGzYJZFIKgiPLZrXphUgRD;

				private int jghGoBqPNoKqcmQtYwCgVQHSwugs;

				private int hjTcebkDMDMrocrzIXYmyrOvEHzFb;

				private IEnumerator<ActionElementMap> uzQNNPxmJKqjvxIQLEzQarKFIssVA;

				ActionElementMap IEnumerator<ActionElementMap>.Current
				{
					[DebuggerHidden]
					get
					{
						return ahHBmUXJOlQVZfJdjIvByLOTfiD;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return ahHBmUXJOlQVZfJdjIvByLOTfiD;
					}
				}

				[DebuggerHidden]
				public vsUITgsSOznaUGQdaMfHnKvmtAdO(int P_0)
				{
					CAxJSqHSTEAnOrJkhAfTGxQeWjHgA = P_0;
					lsBafDkrqysnDzBeOEKhFaPLDrin = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					int cAxJSqHSTEAnOrJkhAfTGxQeWjHgA = CAxJSqHSTEAnOrJkhAfTGxQeWjHgA;
					if (cAxJSqHSTEAnOrJkhAfTGxQeWjHgA == -3 || cAxJSqHSTEAnOrJkhAfTGxQeWjHgA == 1)
					{
						try
						{
						}
						finally
						{
							BXbLvraFUdSegzVnpxxhFcBBsqCl();
						}
					}
				}

				private bool MoveNext()
				{
					try
					{
						int cAxJSqHSTEAnOrJkhAfTGxQeWjHgA = CAxJSqHSTEAnOrJkhAfTGxQeWjHgA;
						MapHelper mapHelper = zsoKbYAMxYaopWchKiTVtZfoIgLd;
						if (cAxJSqHSTEAnOrJkhAfTGxQeWjHgA != 0)
						{
							if (cAxJSqHSTEAnOrJkhAfTGxQeWjHgA != 1)
							{
								return false;
							}
							CAxJSqHSTEAnOrJkhAfTGxQeWjHgA = -3;
							goto IL_0177;
						}
						CAxJSqHSTEAnOrJkhAfTGxQeWjHgA = -1;
						if (ReInput._id != mapHelper.azGvCmHxftPofYbbgHwfQfhmWSgV)
						{
							ReInput.CheckInitialized(mapHelper.azGvCmHxftPofYbbgHwfQfhmWSgV);
							return false;
						}
						if (rGRcpRHDinakBkSqXmmcfNahnIkWB < 0)
						{
							return false;
						}
						PaFNouhJRwJsGXcmjevwobJygTEGA = mapHelper.yfZPVbkoNrPFYlhxRcQrxPzDLvft.QecjgvgRSXuPhnYvNrbSsHRqQwjg.KzSWyhVFpKvuMAleUEiVntIEyGZD;
						WOzLWKqHqxNOkZfklNNZFzQzKiRy = 0;
						goto IL_01f7;
						IL_0177:
						if (uzQNNPxmJKqjvxIQLEzQarKFIssVA.MoveNext())
						{
							ActionElementMap current = uzQNNPxmJKqjvxIQLEzQarKFIssVA.Current;
							ahHBmUXJOlQVZfJdjIvByLOTfiD = current;
							CAxJSqHSTEAnOrJkhAfTGxQeWjHgA = 1;
							return true;
						}
						BXbLvraFUdSegzVnpxxhFcBBsqCl();
						uzQNNPxmJKqjvxIQLEzQarKFIssVA = null;
						goto IL_0191;
						IL_0191:
						hjTcebkDMDMrocrzIXYmyrOvEHzFb++;
						goto IL_01a3;
						IL_01cd:
						if (FGRrGFlDbyVklWPGojwrnWSSWvmu < juxpnYiLdsFLaFVhFtZXkXqCgwOjA)
						{
							HaQJgTgGzYJZFIKgiPLZrXphUgRD = sbAQCtFDbseAWJfWjVJkFShywqsqA.gmqWnmpZMnASuZpGLEqmJcwgXIqMA(FGRrGFlDbyVklWPGojwrnWSSWvmu).ycfaKniCLOzZqlQviANrBfbEZIlRA();
							jghGoBqPNoKqcmQtYwCgVQHSwugs = HaQJgTgGzYJZFIKgiPLZrXphUgRD.ejOOZrUqJLRyRGoRofwTThHfNEkF();
							hjTcebkDMDMrocrzIXYmyrOvEHzFb = 0;
							goto IL_01a3;
						}
						sbAQCtFDbseAWJfWjVJkFShywqsqA = null;
						WOzLWKqHqxNOkZfklNNZFzQzKiRy++;
						goto IL_01f7;
						IL_01a3:
						if (hjTcebkDMDMrocrzIXYmyrOvEHzFb < jghGoBqPNoKqcmQtYwCgVQHSwugs)
						{
							if (HaQJgTgGzYJZFIKgiPLZrXphUgRD.QIeXsLdCiAXGGxCgarjGtHyqkDbM(hjTcebkDMDMrocrzIXYmyrOvEHzFb) is ControllerMapWithAxes controllerMapWithAxes && (!LjbJqeuOBGOqmEBXrxCDeXzKBGOs || controllerMapWithAxes.enabled) && controllerMapWithAxes.ContainsAction(rGRcpRHDinakBkSqXmmcfNahnIkWB))
							{
								uzQNNPxmJKqjvxIQLEzQarKFIssVA = controllerMapWithAxes.AxisMapsWithAction(rGRcpRHDinakBkSqXmmcfNahnIkWB, LjbJqeuOBGOqmEBXrxCDeXzKBGOs).GetEnumerator();
								CAxJSqHSTEAnOrJkhAfTGxQeWjHgA = -3;
								goto IL_0177;
							}
							goto IL_0191;
						}
						HaQJgTgGzYJZFIKgiPLZrXphUgRD = null;
						FGRrGFlDbyVklWPGojwrnWSSWvmu++;
						goto IL_01cd;
						IL_01f7:
						if (WOzLWKqHqxNOkZfklNNZFzQzKiRy < PaFNouhJRwJsGXcmjevwobJygTEGA)
						{
							sbAQCtFDbseAWJfWjVJkFShywqsqA = mapHelper.yfZPVbkoNrPFYlhxRcQrxPzDLvft.QecjgvgRSXuPhnYvNrbSsHRqQwjg.AMmiEUMJUxmCKCltvrDeLoaPvEGE(WOzLWKqHqxNOkZfklNNZFzQzKiRy);
							juxpnYiLdsFLaFVhFtZXkXqCgwOjA = sbAQCtFDbseAWJfWjVJkFShywqsqA.rphZqyUfbdoINyXndGfDbQaiIHFM();
							FGRrGFlDbyVklWPGojwrnWSSWvmu = 0;
							goto IL_01cd;
						}
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

				private void BXbLvraFUdSegzVnpxxhFcBBsqCl()
				{
					CAxJSqHSTEAnOrJkhAfTGxQeWjHgA = -1;
					if (uzQNNPxmJKqjvxIQLEzQarKFIssVA != null)
					{
						uzQNNPxmJKqjvxIQLEzQarKFIssVA.Dispose();
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
					vsUITgsSOznaUGQdaMfHnKvmtAdO vsUITgsSOznaUGQdaMfHnKvmtAdO2;
					if (CAxJSqHSTEAnOrJkhAfTGxQeWjHgA == -2 && lsBafDkrqysnDzBeOEKhFaPLDrin == Environment.CurrentManagedThreadId)
					{
						CAxJSqHSTEAnOrJkhAfTGxQeWjHgA = 0;
						vsUITgsSOznaUGQdaMfHnKvmtAdO2 = this;
					}
					else
					{
						vsUITgsSOznaUGQdaMfHnKvmtAdO2 = new vsUITgsSOznaUGQdaMfHnKvmtAdO(0);
						vsUITgsSOznaUGQdaMfHnKvmtAdO2.zsoKbYAMxYaopWchKiTVtZfoIgLd = zsoKbYAMxYaopWchKiTVtZfoIgLd;
					}
					vsUITgsSOznaUGQdaMfHnKvmtAdO2.rGRcpRHDinakBkSqXmmcfNahnIkWB = TRWvXZQznVyisGxseqYRFDOoBIUi;
					vsUITgsSOznaUGQdaMfHnKvmtAdO2.LjbJqeuOBGOqmEBXrxCDeXzKBGOs = lUfeVmnxJBMRSNQXvXpLhERHEeJL;
					return vsUITgsSOznaUGQdaMfHnKvmtAdO2;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
				}
			}

			private sealed class oDywNiLrsnpTCKUGcRvUVGooIcXM : IEnumerable<ActionElementMap>, IEnumerable, IEnumerator<ActionElementMap>, IEnumerator, IDisposable
			{
				private int TWavztRgomQusBDJTEtZcISeFoFsA;

				private ActionElementMap iysTHTWhZVQcecBaYnBGIQPFGFXV;

				private int GHvMbzYbIhBswJFmBumIqrDKDodgb;

				public MapHelper frCaibBsGENeEpZKfNTNXCvOjWeQ;

				private int vDxNGMfXBuHSNTxQdZMCUKnzNjiH;

				public int xUEamCaOJbHwKYCqrKNjpvmYssOKA;

				private bool znlxeHAXsshusucTEbRzgCBteJyI;

				public bool JgjxqGTgEGErfzqTZbKCADQvzrYl;

				private int SNwhOshITGRvBwwnYDBGMijSYYGh;

				private int PzVmYHnRtdhTSZwVGfNovqvbzzUG;

				private HENtlJpbLTfyvGNBdnYOTBUpGwmPA MuSECYCWseRsyNzLktuMiUSmouMNA;

				private int VsmyqgxjkrtklsDELqazNurIHKgD;

				private int zXvIzqxAHDTqbRnUQnnPhamxKejX;

				private FsyiqPdJeSfbLIuiSYvjZeDpZMzW pGvSzcXuqeAlLhwTsdXViHWRGsdq;

				private int qnJDzHAqkKVsmehNIxPxAcMCzgqi;

				private int PymTHTAxZjbxNDYJNZbuRrKfcmWb;

				private IEnumerator<ActionElementMap> pMAMXMPwieDWwBmzdQYWNFBRQOVp;

				ActionElementMap IEnumerator<ActionElementMap>.Current
				{
					[DebuggerHidden]
					get
					{
						return iysTHTWhZVQcecBaYnBGIQPFGFXV;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return iysTHTWhZVQcecBaYnBGIQPFGFXV;
					}
				}

				[DebuggerHidden]
				public oDywNiLrsnpTCKUGcRvUVGooIcXM(int P_0)
				{
					TWavztRgomQusBDJTEtZcISeFoFsA = P_0;
					GHvMbzYbIhBswJFmBumIqrDKDodgb = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					int tWavztRgomQusBDJTEtZcISeFoFsA = TWavztRgomQusBDJTEtZcISeFoFsA;
					if (tWavztRgomQusBDJTEtZcISeFoFsA == -3 || tWavztRgomQusBDJTEtZcISeFoFsA == 1)
					{
						try
						{
						}
						finally
						{
							msXAaJgpYJywLcgtIAQWPaPlXJOLA();
						}
					}
				}

				private bool MoveNext()
				{
					try
					{
						int tWavztRgomQusBDJTEtZcISeFoFsA = TWavztRgomQusBDJTEtZcISeFoFsA;
						MapHelper mapHelper = frCaibBsGENeEpZKfNTNXCvOjWeQ;
						if (tWavztRgomQusBDJTEtZcISeFoFsA != 0)
						{
							if (tWavztRgomQusBDJTEtZcISeFoFsA != 1)
							{
								return false;
							}
							TWavztRgomQusBDJTEtZcISeFoFsA = -3;
							goto IL_016c;
						}
						TWavztRgomQusBDJTEtZcISeFoFsA = -1;
						if (ReInput._id != mapHelper.azGvCmHxftPofYbbgHwfQfhmWSgV)
						{
							ReInput.CheckInitialized(mapHelper.azGvCmHxftPofYbbgHwfQfhmWSgV);
							return false;
						}
						if (vDxNGMfXBuHSNTxQdZMCUKnzNjiH < 0)
						{
							return false;
						}
						SNwhOshITGRvBwwnYDBGMijSYYGh = mapHelper.yfZPVbkoNrPFYlhxRcQrxPzDLvft.QecjgvgRSXuPhnYvNrbSsHRqQwjg.KzSWyhVFpKvuMAleUEiVntIEyGZD;
						PzVmYHnRtdhTSZwVGfNovqvbzzUG = 0;
						goto IL_01ec;
						IL_016c:
						if (pMAMXMPwieDWwBmzdQYWNFBRQOVp.MoveNext())
						{
							ActionElementMap current = pMAMXMPwieDWwBmzdQYWNFBRQOVp.Current;
							iysTHTWhZVQcecBaYnBGIQPFGFXV = current;
							TWavztRgomQusBDJTEtZcISeFoFsA = 1;
							return true;
						}
						msXAaJgpYJywLcgtIAQWPaPlXJOLA();
						pMAMXMPwieDWwBmzdQYWNFBRQOVp = null;
						goto IL_0186;
						IL_0186:
						PymTHTAxZjbxNDYJNZbuRrKfcmWb++;
						goto IL_0198;
						IL_01c2:
						if (zXvIzqxAHDTqbRnUQnnPhamxKejX < VsmyqgxjkrtklsDELqazNurIHKgD)
						{
							pGvSzcXuqeAlLhwTsdXViHWRGsdq = MuSECYCWseRsyNzLktuMiUSmouMNA.gmqWnmpZMnASuZpGLEqmJcwgXIqMA(zXvIzqxAHDTqbRnUQnnPhamxKejX).ycfaKniCLOzZqlQviANrBfbEZIlRA();
							qnJDzHAqkKVsmehNIxPxAcMCzgqi = pGvSzcXuqeAlLhwTsdXViHWRGsdq.ejOOZrUqJLRyRGoRofwTThHfNEkF();
							PymTHTAxZjbxNDYJNZbuRrKfcmWb = 0;
							goto IL_0198;
						}
						MuSECYCWseRsyNzLktuMiUSmouMNA = null;
						PzVmYHnRtdhTSZwVGfNovqvbzzUG++;
						goto IL_01ec;
						IL_0198:
						if (PymTHTAxZjbxNDYJNZbuRrKfcmWb < qnJDzHAqkKVsmehNIxPxAcMCzgqi)
						{
							ControllerMap controllerMap = pGvSzcXuqeAlLhwTsdXViHWRGsdq.QIeXsLdCiAXGGxCgarjGtHyqkDbM(PymTHTAxZjbxNDYJNZbuRrKfcmWb);
							if ((!znlxeHAXsshusucTEbRzgCBteJyI || controllerMap.enabled) && controllerMap.ContainsAction(vDxNGMfXBuHSNTxQdZMCUKnzNjiH))
							{
								pMAMXMPwieDWwBmzdQYWNFBRQOVp = controllerMap.ButtonMapsWithAction(vDxNGMfXBuHSNTxQdZMCUKnzNjiH, znlxeHAXsshusucTEbRzgCBteJyI).GetEnumerator();
								TWavztRgomQusBDJTEtZcISeFoFsA = -3;
								goto IL_016c;
							}
							goto IL_0186;
						}
						pGvSzcXuqeAlLhwTsdXViHWRGsdq = null;
						zXvIzqxAHDTqbRnUQnnPhamxKejX++;
						goto IL_01c2;
						IL_01ec:
						if (PzVmYHnRtdhTSZwVGfNovqvbzzUG < SNwhOshITGRvBwwnYDBGMijSYYGh)
						{
							MuSECYCWseRsyNzLktuMiUSmouMNA = mapHelper.yfZPVbkoNrPFYlhxRcQrxPzDLvft.QecjgvgRSXuPhnYvNrbSsHRqQwjg.AMmiEUMJUxmCKCltvrDeLoaPvEGE(PzVmYHnRtdhTSZwVGfNovqvbzzUG);
							VsmyqgxjkrtklsDELqazNurIHKgD = MuSECYCWseRsyNzLktuMiUSmouMNA.rphZqyUfbdoINyXndGfDbQaiIHFM();
							zXvIzqxAHDTqbRnUQnnPhamxKejX = 0;
							goto IL_01c2;
						}
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

				private void msXAaJgpYJywLcgtIAQWPaPlXJOLA()
				{
					TWavztRgomQusBDJTEtZcISeFoFsA = -1;
					if (pMAMXMPwieDWwBmzdQYWNFBRQOVp != null)
					{
						pMAMXMPwieDWwBmzdQYWNFBRQOVp.Dispose();
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
					oDywNiLrsnpTCKUGcRvUVGooIcXM oDywNiLrsnpTCKUGcRvUVGooIcXM2;
					if (TWavztRgomQusBDJTEtZcISeFoFsA == -2 && GHvMbzYbIhBswJFmBumIqrDKDodgb == Environment.CurrentManagedThreadId)
					{
						TWavztRgomQusBDJTEtZcISeFoFsA = 0;
						oDywNiLrsnpTCKUGcRvUVGooIcXM2 = this;
					}
					else
					{
						oDywNiLrsnpTCKUGcRvUVGooIcXM2 = new oDywNiLrsnpTCKUGcRvUVGooIcXM(0);
						oDywNiLrsnpTCKUGcRvUVGooIcXM2.frCaibBsGENeEpZKfNTNXCvOjWeQ = frCaibBsGENeEpZKfNTNXCvOjWeQ;
					}
					oDywNiLrsnpTCKUGcRvUVGooIcXM2.vDxNGMfXBuHSNTxQdZMCUKnzNjiH = xUEamCaOJbHwKYCqrKNjpvmYssOKA;
					oDywNiLrsnpTCKUGcRvUVGooIcXM2.znlxeHAXsshusucTEbRzgCBteJyI = JgjxqGTgEGErfzqTZbKCADQvzrYl;
					return oDywNiLrsnpTCKUGcRvUVGooIcXM2;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
				}
			}

			private sealed class lqbGJfbgaHOFbJyprTczOrNAfbaT : IEnumerable<ActionElementMap>, IEnumerable, IEnumerator<ActionElementMap>, IEnumerator, IDisposable
			{
				private int YvOeSQbqCxiDagYpbAVToJuwFyuAB;

				private ActionElementMap LJERZLeFtDSmmhXaBNJlUrFyRPDN;

				private int yNRStmEGokFPIXZurBMTKSHvWRwH;

				private int PeAiqvSlgGqSOvvcSJUjvXLBnhtv;

				public int LiZEpieUOoEFiWEgqfIRgApnPcZY;

				public MapHelper mWrZjBgWWVhKhAuWCHFTxfrvRNbC;

				private ControllerType ZJdJjLBoKareJEXmxJSObsRlWnmo;

				public ControllerType WJWXcsoHqxtaaYKyGckCbFMkeqAfb;

				private bool osgPnJDmZtWaiFbqRcqqaajNFdXJ;

				public bool pPdvykSuDGshUercnlZkJmJkElRR;

				private HENtlJpbLTfyvGNBdnYOTBUpGwmPA nMrgRFfZMmGHzhyHjthedZoAOgUd;

				private int SpicsAnQdtpAXjOrgtVoilzfDKOh;

				private IList<ControllerMap> BIHVXfIdtCCLFSdPIwuPnIvvmcax;

				private int oBxHyuEGSzCcLYIxoCtaZecDczaEb;

				private IEnumerator<ActionElementMap> hzAhwoaxpyIBhsWKYMvniaKCTAWsA;

				ActionElementMap IEnumerator<ActionElementMap>.Current
				{
					[DebuggerHidden]
					get
					{
						return LJERZLeFtDSmmhXaBNJlUrFyRPDN;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return LJERZLeFtDSmmhXaBNJlUrFyRPDN;
					}
				}

				[DebuggerHidden]
				public lqbGJfbgaHOFbJyprTczOrNAfbaT(int P_0)
				{
					YvOeSQbqCxiDagYpbAVToJuwFyuAB = P_0;
					yNRStmEGokFPIXZurBMTKSHvWRwH = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					int yvOeSQbqCxiDagYpbAVToJuwFyuAB = YvOeSQbqCxiDagYpbAVToJuwFyuAB;
					if (yvOeSQbqCxiDagYpbAVToJuwFyuAB == -3 || yvOeSQbqCxiDagYpbAVToJuwFyuAB == 1)
					{
						try
						{
						}
						finally
						{
							RxGyjuAVtjPkfWHNDZlqQTPLZNd();
						}
					}
				}

				private bool MoveNext()
				{
					try
					{
						int yvOeSQbqCxiDagYpbAVToJuwFyuAB = YvOeSQbqCxiDagYpbAVToJuwFyuAB;
						MapHelper mapHelper = mWrZjBgWWVhKhAuWCHFTxfrvRNbC;
						if (yvOeSQbqCxiDagYpbAVToJuwFyuAB != 0)
						{
							if (yvOeSQbqCxiDagYpbAVToJuwFyuAB != 1)
							{
								return false;
							}
							YvOeSQbqCxiDagYpbAVToJuwFyuAB = -3;
							goto IL_0150;
						}
						YvOeSQbqCxiDagYpbAVToJuwFyuAB = -1;
						if (PeAiqvSlgGqSOvvcSJUjvXLBnhtv < 0)
						{
							return false;
						}
						nMrgRFfZMmGHzhyHjthedZoAOgUd = mapHelper.yfZPVbkoNrPFYlhxRcQrxPzDLvft.QecjgvgRSXuPhnYvNrbSsHRqQwjg.AXLlayIlTwJqJNaNzeKccuszIcODb(ZJdJjLBoKareJEXmxJSObsRlWnmo);
						SpicsAnQdtpAXjOrgtVoilzfDKOh = 0;
						goto IL_01ab;
						IL_0150:
						if (hzAhwoaxpyIBhsWKYMvniaKCTAWsA.MoveNext())
						{
							ActionElementMap current = hzAhwoaxpyIBhsWKYMvniaKCTAWsA.Current;
							LJERZLeFtDSmmhXaBNJlUrFyRPDN = current;
							YvOeSQbqCxiDagYpbAVToJuwFyuAB = 1;
							return true;
						}
						RxGyjuAVtjPkfWHNDZlqQTPLZNd();
						hzAhwoaxpyIBhsWKYMvniaKCTAWsA = null;
						goto IL_016a;
						IL_017c:
						if (oBxHyuEGSzCcLYIxoCtaZecDczaEb < BIHVXfIdtCCLFSdPIwuPnIvvmcax.Count)
						{
							if (!(BIHVXfIdtCCLFSdPIwuPnIvvmcax[oBxHyuEGSzCcLYIxoCtaZecDczaEb] is ControllerMapWithAxes))
							{
								return false;
							}
							if ((!osgPnJDmZtWaiFbqRcqqaajNFdXJ || BIHVXfIdtCCLFSdPIwuPnIvvmcax[oBxHyuEGSzCcLYIxoCtaZecDczaEb].enabled) && BIHVXfIdtCCLFSdPIwuPnIvvmcax[oBxHyuEGSzCcLYIxoCtaZecDczaEb].ContainsAction(PeAiqvSlgGqSOvvcSJUjvXLBnhtv))
							{
								hzAhwoaxpyIBhsWKYMvniaKCTAWsA = (BIHVXfIdtCCLFSdPIwuPnIvvmcax[oBxHyuEGSzCcLYIxoCtaZecDczaEb] as ControllerMapWithAxes).AxisMapsWithAction(PeAiqvSlgGqSOvvcSJUjvXLBnhtv, osgPnJDmZtWaiFbqRcqqaajNFdXJ).GetEnumerator();
								YvOeSQbqCxiDagYpbAVToJuwFyuAB = -3;
								goto IL_0150;
							}
							goto IL_016a;
						}
						BIHVXfIdtCCLFSdPIwuPnIvvmcax = null;
						SpicsAnQdtpAXjOrgtVoilzfDKOh++;
						goto IL_01ab;
						IL_016a:
						oBxHyuEGSzCcLYIxoCtaZecDczaEb++;
						goto IL_017c;
						IL_01ab:
						if (SpicsAnQdtpAXjOrgtVoilzfDKOh < nMrgRFfZMmGHzhyHjthedZoAOgUd.rphZqyUfbdoINyXndGfDbQaiIHFM())
						{
							BIHVXfIdtCCLFSdPIwuPnIvvmcax = nMrgRFfZMmGHzhyHjthedZoAOgUd.gmqWnmpZMnASuZpGLEqmJcwgXIqMA(SpicsAnQdtpAXjOrgtVoilzfDKOh).ycfaKniCLOzZqlQviANrBfbEZIlRA().yNPIkhCQyqKjUMKWnmnPppLEAttk();
							oBxHyuEGSzCcLYIxoCtaZecDczaEb = 0;
							goto IL_017c;
						}
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

				private void RxGyjuAVtjPkfWHNDZlqQTPLZNd()
				{
					YvOeSQbqCxiDagYpbAVToJuwFyuAB = -1;
					if (hzAhwoaxpyIBhsWKYMvniaKCTAWsA != null)
					{
						hzAhwoaxpyIBhsWKYMvniaKCTAWsA.Dispose();
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
					lqbGJfbgaHOFbJyprTczOrNAfbaT lqbGJfbgaHOFbJyprTczOrNAfbaT2;
					if (YvOeSQbqCxiDagYpbAVToJuwFyuAB == -2 && yNRStmEGokFPIXZurBMTKSHvWRwH == Environment.CurrentManagedThreadId)
					{
						YvOeSQbqCxiDagYpbAVToJuwFyuAB = 0;
						lqbGJfbgaHOFbJyprTczOrNAfbaT2 = this;
					}
					else
					{
						lqbGJfbgaHOFbJyprTczOrNAfbaT2 = new lqbGJfbgaHOFbJyprTczOrNAfbaT(0);
						lqbGJfbgaHOFbJyprTczOrNAfbaT2.mWrZjBgWWVhKhAuWCHFTxfrvRNbC = mWrZjBgWWVhKhAuWCHFTxfrvRNbC;
					}
					lqbGJfbgaHOFbJyprTczOrNAfbaT2.ZJdJjLBoKareJEXmxJSObsRlWnmo = WJWXcsoHqxtaaYKyGckCbFMkeqAfb;
					lqbGJfbgaHOFbJyprTczOrNAfbaT2.PeAiqvSlgGqSOvvcSJUjvXLBnhtv = LiZEpieUOoEFiWEgqfIRgApnPcZY;
					lqbGJfbgaHOFbJyprTczOrNAfbaT2.osgPnJDmZtWaiFbqRcqqaajNFdXJ = pPdvykSuDGshUercnlZkJmJkElRR;
					return lqbGJfbgaHOFbJyprTczOrNAfbaT2;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
				}
			}

			private sealed class hQMKFYXDhUNlKXlIgbGpjAwoUigx : IEnumerable<ActionElementMap>, IEnumerable, IEnumerator<ActionElementMap>, IEnumerator, IDisposable
			{
				private int BUGvpLaVHRoATROOazKPgreRzbbc;

				private ActionElementMap yvnjaNtqXbXRmlTjFgcTFwWEkkzB;

				private int UvibFWBHkuoCvyBgsihWkQWSfbqY;

				private int gIMzcrdyWKNnxDSqazFGpdONCBNB;

				public int rwdhNZDpjENIkXkHamSkoIbCDoRO;

				public MapHelper WmddBnHHVbhynxYCFeFjgslIpQHKA;

				private ControllerType PpEtNnTUXRuSlkNGahVoTRuPVlhW;

				public ControllerType cZcBdloXvncoKtUYGWHqPwjBKNiG;

				private int EscVIVNsCHmSFuAkSKngOotiwJty;

				public int ZTFezEWRaEYdFAVTeUfFjwbmZEAC;

				private bool NtvbPAgACAONoAIQDMVnBZIkvvqUB;

				public bool qmTAHJaBMFnbhiaVcadcdljrKsnOc;

				private IList<ControllerMap> ZEewsflxUXGHtDtVqJAvnbyIrabP;

				private int ZfuRUccZTKIfuFTTXKsZxBHHVDpW;

				private IEnumerator<ActionElementMap> LrpHcoGmCCbIGJVDsDMihIfMyfRG;

				ActionElementMap IEnumerator<ActionElementMap>.Current
				{
					[DebuggerHidden]
					get
					{
						return yvnjaNtqXbXRmlTjFgcTFwWEkkzB;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return yvnjaNtqXbXRmlTjFgcTFwWEkkzB;
					}
				}

				[DebuggerHidden]
				public hQMKFYXDhUNlKXlIgbGpjAwoUigx(int P_0)
				{
					BUGvpLaVHRoATROOazKPgreRzbbc = P_0;
					UvibFWBHkuoCvyBgsihWkQWSfbqY = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					int bUGvpLaVHRoATROOazKPgreRzbbc = BUGvpLaVHRoATROOazKPgreRzbbc;
					if (bUGvpLaVHRoATROOazKPgreRzbbc == -3 || bUGvpLaVHRoATROOazKPgreRzbbc == 1)
					{
						try
						{
						}
						finally
						{
							AErtbLSinYRZSqIfRkijqKhApigK();
						}
					}
				}

				private bool MoveNext()
				{
					try
					{
						int bUGvpLaVHRoATROOazKPgreRzbbc = BUGvpLaVHRoATROOazKPgreRzbbc;
						MapHelper wmddBnHHVbhynxYCFeFjgslIpQHKA = WmddBnHHVbhynxYCFeFjgslIpQHKA;
						if (bUGvpLaVHRoATROOazKPgreRzbbc != 0)
						{
							if (bUGvpLaVHRoATROOazKPgreRzbbc != 1)
							{
								return false;
							}
							BUGvpLaVHRoATROOazKPgreRzbbc = -3;
							goto IL_014f;
						}
						BUGvpLaVHRoATROOazKPgreRzbbc = -1;
						if (gIMzcrdyWKNnxDSqazFGpdONCBNB < 0)
						{
							return false;
						}
						HENtlJpbLTfyvGNBdnYOTBUpGwmPA hENtlJpbLTfyvGNBdnYOTBUpGwmPA = wmddBnHHVbhynxYCFeFjgslIpQHKA.yfZPVbkoNrPFYlhxRcQrxPzDLvft.QecjgvgRSXuPhnYvNrbSsHRqQwjg.AXLlayIlTwJqJNaNzeKccuszIcODb(PpEtNnTUXRuSlkNGahVoTRuPVlhW);
						int num = hENtlJpbLTfyvGNBdnYOTBUpGwmPA.LwDtjAISpvZKUEBiCEPKHyoscvdr(EscVIVNsCHmSFuAkSKngOotiwJty);
						if (num < 0)
						{
							return false;
						}
						ZEewsflxUXGHtDtVqJAvnbyIrabP = hENtlJpbLTfyvGNBdnYOTBUpGwmPA.gmqWnmpZMnASuZpGLEqmJcwgXIqMA(num).ycfaKniCLOzZqlQviANrBfbEZIlRA().yNPIkhCQyqKjUMKWnmnPppLEAttk();
						ZfuRUccZTKIfuFTTXKsZxBHHVDpW = 0;
						goto IL_017b;
						IL_014f:
						if (LrpHcoGmCCbIGJVDsDMihIfMyfRG.MoveNext())
						{
							ActionElementMap current = LrpHcoGmCCbIGJVDsDMihIfMyfRG.Current;
							yvnjaNtqXbXRmlTjFgcTFwWEkkzB = current;
							BUGvpLaVHRoATROOazKPgreRzbbc = 1;
							return true;
						}
						AErtbLSinYRZSqIfRkijqKhApigK();
						LrpHcoGmCCbIGJVDsDMihIfMyfRG = null;
						goto IL_0169;
						IL_017b:
						if (ZfuRUccZTKIfuFTTXKsZxBHHVDpW < ZEewsflxUXGHtDtVqJAvnbyIrabP.Count)
						{
							if (!(ZEewsflxUXGHtDtVqJAvnbyIrabP[ZfuRUccZTKIfuFTTXKsZxBHHVDpW] is ControllerMapWithAxes))
							{
								return false;
							}
							if ((!NtvbPAgACAONoAIQDMVnBZIkvvqUB || ZEewsflxUXGHtDtVqJAvnbyIrabP[ZfuRUccZTKIfuFTTXKsZxBHHVDpW].enabled) && ZEewsflxUXGHtDtVqJAvnbyIrabP[ZfuRUccZTKIfuFTTXKsZxBHHVDpW].ContainsAction(gIMzcrdyWKNnxDSqazFGpdONCBNB))
							{
								LrpHcoGmCCbIGJVDsDMihIfMyfRG = (ZEewsflxUXGHtDtVqJAvnbyIrabP[ZfuRUccZTKIfuFTTXKsZxBHHVDpW] as ControllerMapWithAxes).AxisMapsWithAction(gIMzcrdyWKNnxDSqazFGpdONCBNB, NtvbPAgACAONoAIQDMVnBZIkvvqUB).GetEnumerator();
								BUGvpLaVHRoATROOazKPgreRzbbc = -3;
								goto IL_014f;
							}
							goto IL_0169;
						}
						return false;
						IL_0169:
						ZfuRUccZTKIfuFTTXKsZxBHHVDpW++;
						goto IL_017b;
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

				private void AErtbLSinYRZSqIfRkijqKhApigK()
				{
					BUGvpLaVHRoATROOazKPgreRzbbc = -1;
					if (LrpHcoGmCCbIGJVDsDMihIfMyfRG != null)
					{
						LrpHcoGmCCbIGJVDsDMihIfMyfRG.Dispose();
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
					hQMKFYXDhUNlKXlIgbGpjAwoUigx hQMKFYXDhUNlKXlIgbGpjAwoUigx2;
					if (BUGvpLaVHRoATROOazKPgreRzbbc == -2 && UvibFWBHkuoCvyBgsihWkQWSfbqY == Environment.CurrentManagedThreadId)
					{
						BUGvpLaVHRoATROOazKPgreRzbbc = 0;
						hQMKFYXDhUNlKXlIgbGpjAwoUigx2 = this;
					}
					else
					{
						hQMKFYXDhUNlKXlIgbGpjAwoUigx2 = new hQMKFYXDhUNlKXlIgbGpjAwoUigx(0);
						hQMKFYXDhUNlKXlIgbGpjAwoUigx2.WmddBnHHVbhynxYCFeFjgslIpQHKA = WmddBnHHVbhynxYCFeFjgslIpQHKA;
					}
					hQMKFYXDhUNlKXlIgbGpjAwoUigx2.PpEtNnTUXRuSlkNGahVoTRuPVlhW = cZcBdloXvncoKtUYGWHqPwjBKNiG;
					hQMKFYXDhUNlKXlIgbGpjAwoUigx2.EscVIVNsCHmSFuAkSKngOotiwJty = ZTFezEWRaEYdFAVTeUfFjwbmZEAC;
					hQMKFYXDhUNlKXlIgbGpjAwoUigx2.gIMzcrdyWKNnxDSqazFGpdONCBNB = rwdhNZDpjENIkXkHamSkoIbCDoRO;
					hQMKFYXDhUNlKXlIgbGpjAwoUigx2.NtvbPAgACAONoAIQDMVnBZIkvvqUB = qmTAHJaBMFnbhiaVcadcdljrKsnOc;
					return hQMKFYXDhUNlKXlIgbGpjAwoUigx2;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
				}
			}

			private sealed class maXBdORCNjomDMKmDAxMxRXBiVvo : IEnumerable<ActionElementMap>, IEnumerable, IEnumerator<ActionElementMap>, IEnumerator, IDisposable
			{
				private int QfojWDeGVWPexWjHsYFZAKwdGEtGb;

				private ActionElementMap gzVaGoEliVKtlohlEZgzkNDcngXcb;

				private int MSoEmvwuUckNvrItXpwKMPYkXPQh;

				private int VrPoOitHLakwopWfKWOjLhpmdWAA;

				public int bLibKxsQEragqIBMdXCQxDwXHxcr;

				public MapHelper PRcLfKxqWvEmDsjJHcMZriwIuzuB;

				private ControllerType xjPtqtFbiHAypcFiFOofxxBDNtdKA;

				public ControllerType WHBogqzTgSYLbrjIpfmJUmrbqQDF;

				private bool LqZEndlIUOXaefpkbsEqEdVZUkci;

				public bool FkPUbRGsXcMkCJFJZiPJjAkocyhqA;

				private HENtlJpbLTfyvGNBdnYOTBUpGwmPA MHcfdwWRBAvGpbnhcqycXiKpyBEA;

				private int NEcpORQazPZovZCWbWBAsXQlPacQ;

				private IList<ControllerMap> JIeeeZRNNYgTEEZRBCzJXZoveaZOA;

				private int AOIecBcahOTrNqFlewhcmnzJNYgA;

				private IEnumerator<ActionElementMap> sBlAZZPSzgSgxBGMYLiHzUzoQxv;

				ActionElementMap IEnumerator<ActionElementMap>.Current
				{
					[DebuggerHidden]
					get
					{
						return gzVaGoEliVKtlohlEZgzkNDcngXcb;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return gzVaGoEliVKtlohlEZgzkNDcngXcb;
					}
				}

				[DebuggerHidden]
				public maXBdORCNjomDMKmDAxMxRXBiVvo(int P_0)
				{
					QfojWDeGVWPexWjHsYFZAKwdGEtGb = P_0;
					MSoEmvwuUckNvrItXpwKMPYkXPQh = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					int qfojWDeGVWPexWjHsYFZAKwdGEtGb = QfojWDeGVWPexWjHsYFZAKwdGEtGb;
					if (qfojWDeGVWPexWjHsYFZAKwdGEtGb == -3 || qfojWDeGVWPexWjHsYFZAKwdGEtGb == 1)
					{
						try
						{
						}
						finally
						{
							shZyQdxiuXTkEVMcHfGdgDxyOhnA();
						}
					}
				}

				private bool MoveNext()
				{
					try
					{
						int qfojWDeGVWPexWjHsYFZAKwdGEtGb = QfojWDeGVWPexWjHsYFZAKwdGEtGb;
						MapHelper pRcLfKxqWvEmDsjJHcMZriwIuzuB = PRcLfKxqWvEmDsjJHcMZriwIuzuB;
						if (qfojWDeGVWPexWjHsYFZAKwdGEtGb != 0)
						{
							if (qfojWDeGVWPexWjHsYFZAKwdGEtGb != 1)
							{
								return false;
							}
							QfojWDeGVWPexWjHsYFZAKwdGEtGb = -3;
							goto IL_012c;
						}
						QfojWDeGVWPexWjHsYFZAKwdGEtGb = -1;
						if (VrPoOitHLakwopWfKWOjLhpmdWAA < 0)
						{
							return false;
						}
						MHcfdwWRBAvGpbnhcqycXiKpyBEA = pRcLfKxqWvEmDsjJHcMZriwIuzuB.yfZPVbkoNrPFYlhxRcQrxPzDLvft.QecjgvgRSXuPhnYvNrbSsHRqQwjg.AXLlayIlTwJqJNaNzeKccuszIcODb(xjPtqtFbiHAypcFiFOofxxBDNtdKA);
						NEcpORQazPZovZCWbWBAsXQlPacQ = 0;
						goto IL_0187;
						IL_012c:
						if (sBlAZZPSzgSgxBGMYLiHzUzoQxv.MoveNext())
						{
							ActionElementMap current = sBlAZZPSzgSgxBGMYLiHzUzoQxv.Current;
							gzVaGoEliVKtlohlEZgzkNDcngXcb = current;
							QfojWDeGVWPexWjHsYFZAKwdGEtGb = 1;
							return true;
						}
						shZyQdxiuXTkEVMcHfGdgDxyOhnA();
						sBlAZZPSzgSgxBGMYLiHzUzoQxv = null;
						goto IL_0146;
						IL_0158:
						if (AOIecBcahOTrNqFlewhcmnzJNYgA < JIeeeZRNNYgTEEZRBCzJXZoveaZOA.Count)
						{
							if ((!LqZEndlIUOXaefpkbsEqEdVZUkci || JIeeeZRNNYgTEEZRBCzJXZoveaZOA[AOIecBcahOTrNqFlewhcmnzJNYgA].enabled) && JIeeeZRNNYgTEEZRBCzJXZoveaZOA[AOIecBcahOTrNqFlewhcmnzJNYgA].ContainsAction(VrPoOitHLakwopWfKWOjLhpmdWAA))
							{
								sBlAZZPSzgSgxBGMYLiHzUzoQxv = JIeeeZRNNYgTEEZRBCzJXZoveaZOA[AOIecBcahOTrNqFlewhcmnzJNYgA].ButtonMapsWithAction(VrPoOitHLakwopWfKWOjLhpmdWAA, LqZEndlIUOXaefpkbsEqEdVZUkci).GetEnumerator();
								QfojWDeGVWPexWjHsYFZAKwdGEtGb = -3;
								goto IL_012c;
							}
							goto IL_0146;
						}
						JIeeeZRNNYgTEEZRBCzJXZoveaZOA = null;
						NEcpORQazPZovZCWbWBAsXQlPacQ++;
						goto IL_0187;
						IL_0146:
						AOIecBcahOTrNqFlewhcmnzJNYgA++;
						goto IL_0158;
						IL_0187:
						if (NEcpORQazPZovZCWbWBAsXQlPacQ < MHcfdwWRBAvGpbnhcqycXiKpyBEA.rphZqyUfbdoINyXndGfDbQaiIHFM())
						{
							JIeeeZRNNYgTEEZRBCzJXZoveaZOA = MHcfdwWRBAvGpbnhcqycXiKpyBEA.gmqWnmpZMnASuZpGLEqmJcwgXIqMA(NEcpORQazPZovZCWbWBAsXQlPacQ).ycfaKniCLOzZqlQviANrBfbEZIlRA().yNPIkhCQyqKjUMKWnmnPppLEAttk();
							AOIecBcahOTrNqFlewhcmnzJNYgA = 0;
							goto IL_0158;
						}
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

				private void shZyQdxiuXTkEVMcHfGdgDxyOhnA()
				{
					QfojWDeGVWPexWjHsYFZAKwdGEtGb = -1;
					if (sBlAZZPSzgSgxBGMYLiHzUzoQxv != null)
					{
						sBlAZZPSzgSgxBGMYLiHzUzoQxv.Dispose();
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
					maXBdORCNjomDMKmDAxMxRXBiVvo maXBdORCNjomDMKmDAxMxRXBiVvo2;
					if (QfojWDeGVWPexWjHsYFZAKwdGEtGb == -2 && MSoEmvwuUckNvrItXpwKMPYkXPQh == Environment.CurrentManagedThreadId)
					{
						QfojWDeGVWPexWjHsYFZAKwdGEtGb = 0;
						maXBdORCNjomDMKmDAxMxRXBiVvo2 = this;
					}
					else
					{
						maXBdORCNjomDMKmDAxMxRXBiVvo2 = new maXBdORCNjomDMKmDAxMxRXBiVvo(0);
						maXBdORCNjomDMKmDAxMxRXBiVvo2.PRcLfKxqWvEmDsjJHcMZriwIuzuB = PRcLfKxqWvEmDsjJHcMZriwIuzuB;
					}
					maXBdORCNjomDMKmDAxMxRXBiVvo2.xjPtqtFbiHAypcFiFOofxxBDNtdKA = WHBogqzTgSYLbrjIpfmJUmrbqQDF;
					maXBdORCNjomDMKmDAxMxRXBiVvo2.VrPoOitHLakwopWfKWOjLhpmdWAA = bLibKxsQEragqIBMdXCQxDwXHxcr;
					maXBdORCNjomDMKmDAxMxRXBiVvo2.LqZEndlIUOXaefpkbsEqEdVZUkci = FkPUbRGsXcMkCJFJZiPJjAkocyhqA;
					return maXBdORCNjomDMKmDAxMxRXBiVvo2;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
				}
			}

			private sealed class XkOQfQWrjdZlPYxiCTPtpBIvJkLm : IEnumerable<ActionElementMap>, IEnumerable, IEnumerator<ActionElementMap>, IEnumerator, IDisposable
			{
				private int BgSAKYbGCunfKcfycqMwJIlUSwNY;

				private ActionElementMap UrHqnDzQBeDspAtAmsigmFWucfsab;

				private int pGcQFkwrCekoCvTioRexWyJIhKhO;

				private int wTmXPgiNxnvQVIhAhBmWlvGcLfdh;

				public int xGbvscBtruudQLrPDULXROjhCyRAA;

				public MapHelper QbtdDIKVOrLGBqtTukKgCUaOgDwI;

				private ControllerType KMeHTuJbgYIzDzvZmFGkPVEQQRpQ;

				public ControllerType VkyBLzlGoKgCoFwEOegleqvwSGPAA;

				private int eyhSOKSFnwUqTHSWyuIpFHJlbqRhA;

				public int CiciTZrqMklbwKKoGGNeyJGSBULo;

				private bool IistRqQvoIZxnpBhpKZjtYpeVCos;

				public bool BojYzLeaElLyUvvkcGoVUugcNaqO;

				private IList<ControllerMap> SjkKVVngNyObLcomGdGygNmvqzXaA;

				private int VgbqRjzFfamQakmANUfFXPzaAzoBA;

				private IEnumerator<ActionElementMap> IJmHrWMgYWqNcDMEwSGUFGYGdaus;

				ActionElementMap IEnumerator<ActionElementMap>.Current
				{
					[DebuggerHidden]
					get
					{
						return UrHqnDzQBeDspAtAmsigmFWucfsab;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return UrHqnDzQBeDspAtAmsigmFWucfsab;
					}
				}

				[DebuggerHidden]
				public XkOQfQWrjdZlPYxiCTPtpBIvJkLm(int P_0)
				{
					BgSAKYbGCunfKcfycqMwJIlUSwNY = P_0;
					pGcQFkwrCekoCvTioRexWyJIhKhO = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					int bgSAKYbGCunfKcfycqMwJIlUSwNY = BgSAKYbGCunfKcfycqMwJIlUSwNY;
					if (bgSAKYbGCunfKcfycqMwJIlUSwNY == -3 || bgSAKYbGCunfKcfycqMwJIlUSwNY == 1)
					{
						try
						{
						}
						finally
						{
							nRdoqZmLabSogjSMLTKUOpVBbjVcA();
						}
					}
				}

				private bool MoveNext()
				{
					try
					{
						int bgSAKYbGCunfKcfycqMwJIlUSwNY = BgSAKYbGCunfKcfycqMwJIlUSwNY;
						MapHelper qbtdDIKVOrLGBqtTukKgCUaOgDwI = QbtdDIKVOrLGBqtTukKgCUaOgDwI;
						if (bgSAKYbGCunfKcfycqMwJIlUSwNY != 0)
						{
							if (bgSAKYbGCunfKcfycqMwJIlUSwNY != 1)
							{
								return false;
							}
							BgSAKYbGCunfKcfycqMwJIlUSwNY = -3;
							goto IL_012b;
						}
						BgSAKYbGCunfKcfycqMwJIlUSwNY = -1;
						if (wTmXPgiNxnvQVIhAhBmWlvGcLfdh < 0)
						{
							return false;
						}
						HENtlJpbLTfyvGNBdnYOTBUpGwmPA hENtlJpbLTfyvGNBdnYOTBUpGwmPA = qbtdDIKVOrLGBqtTukKgCUaOgDwI.yfZPVbkoNrPFYlhxRcQrxPzDLvft.QecjgvgRSXuPhnYvNrbSsHRqQwjg.AXLlayIlTwJqJNaNzeKccuszIcODb(KMeHTuJbgYIzDzvZmFGkPVEQQRpQ);
						int num = hENtlJpbLTfyvGNBdnYOTBUpGwmPA.LwDtjAISpvZKUEBiCEPKHyoscvdr(eyhSOKSFnwUqTHSWyuIpFHJlbqRhA);
						if (num < 0)
						{
							return false;
						}
						SjkKVVngNyObLcomGdGygNmvqzXaA = hENtlJpbLTfyvGNBdnYOTBUpGwmPA.gmqWnmpZMnASuZpGLEqmJcwgXIqMA(num).ycfaKniCLOzZqlQviANrBfbEZIlRA().yNPIkhCQyqKjUMKWnmnPppLEAttk();
						VgbqRjzFfamQakmANUfFXPzaAzoBA = 0;
						goto IL_0157;
						IL_012b:
						if (IJmHrWMgYWqNcDMEwSGUFGYGdaus.MoveNext())
						{
							ActionElementMap current = IJmHrWMgYWqNcDMEwSGUFGYGdaus.Current;
							UrHqnDzQBeDspAtAmsigmFWucfsab = current;
							BgSAKYbGCunfKcfycqMwJIlUSwNY = 1;
							return true;
						}
						nRdoqZmLabSogjSMLTKUOpVBbjVcA();
						IJmHrWMgYWqNcDMEwSGUFGYGdaus = null;
						goto IL_0145;
						IL_0157:
						if (VgbqRjzFfamQakmANUfFXPzaAzoBA < SjkKVVngNyObLcomGdGygNmvqzXaA.Count)
						{
							if ((!IistRqQvoIZxnpBhpKZjtYpeVCos || SjkKVVngNyObLcomGdGygNmvqzXaA[VgbqRjzFfamQakmANUfFXPzaAzoBA].enabled) && SjkKVVngNyObLcomGdGygNmvqzXaA[VgbqRjzFfamQakmANUfFXPzaAzoBA].ContainsAction(wTmXPgiNxnvQVIhAhBmWlvGcLfdh))
							{
								IJmHrWMgYWqNcDMEwSGUFGYGdaus = SjkKVVngNyObLcomGdGygNmvqzXaA[VgbqRjzFfamQakmANUfFXPzaAzoBA].ButtonMapsWithAction(wTmXPgiNxnvQVIhAhBmWlvGcLfdh, IistRqQvoIZxnpBhpKZjtYpeVCos).GetEnumerator();
								BgSAKYbGCunfKcfycqMwJIlUSwNY = -3;
								goto IL_012b;
							}
							goto IL_0145;
						}
						return false;
						IL_0145:
						VgbqRjzFfamQakmANUfFXPzaAzoBA++;
						goto IL_0157;
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

				private void nRdoqZmLabSogjSMLTKUOpVBbjVcA()
				{
					BgSAKYbGCunfKcfycqMwJIlUSwNY = -1;
					if (IJmHrWMgYWqNcDMEwSGUFGYGdaus != null)
					{
						IJmHrWMgYWqNcDMEwSGUFGYGdaus.Dispose();
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
					XkOQfQWrjdZlPYxiCTPtpBIvJkLm xkOQfQWrjdZlPYxiCTPtpBIvJkLm;
					if (BgSAKYbGCunfKcfycqMwJIlUSwNY == -2 && pGcQFkwrCekoCvTioRexWyJIhKhO == Environment.CurrentManagedThreadId)
					{
						BgSAKYbGCunfKcfycqMwJIlUSwNY = 0;
						xkOQfQWrjdZlPYxiCTPtpBIvJkLm = this;
					}
					else
					{
						xkOQfQWrjdZlPYxiCTPtpBIvJkLm = new XkOQfQWrjdZlPYxiCTPtpBIvJkLm(0);
						xkOQfQWrjdZlPYxiCTPtpBIvJkLm.QbtdDIKVOrLGBqtTukKgCUaOgDwI = QbtdDIKVOrLGBqtTukKgCUaOgDwI;
					}
					xkOQfQWrjdZlPYxiCTPtpBIvJkLm.KMeHTuJbgYIzDzvZmFGkPVEQQRpQ = VkyBLzlGoKgCoFwEOegleqvwSGPAA;
					xkOQfQWrjdZlPYxiCTPtpBIvJkLm.eyhSOKSFnwUqTHSWyuIpFHJlbqRhA = CiciTZrqMklbwKKoGGNeyJGSBULo;
					xkOQfQWrjdZlPYxiCTPtpBIvJkLm.wTmXPgiNxnvQVIhAhBmWlvGcLfdh = xGbvscBtruudQLrPDULXROjhCyRAA;
					xkOQfQWrjdZlPYxiCTPtpBIvJkLm.IistRqQvoIZxnpBhpKZjtYpeVCos = BojYzLeaElLyUvvkcGoVUugcNaqO;
					return xkOQfQWrjdZlPYxiCTPtpBIvJkLm;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
				}
			}

			private sealed class NoRaHZrRkapKaXaxOIdFXtoBmWQO : IEnumerable<ActionElementMap>, IEnumerable, IEnumerator<ActionElementMap>, IEnumerator, IDisposable
			{
				private int OYbUQruBjDVPuPfluozFmzulLeVh;

				private ActionElementMap yzcCJlBDoZqDHFsUOcnwfexONtEfb;

				private int sRrfmBJNacgiWEFrCxDTVevhEAdhc;

				private int tyTGpWYiouEsqFsPghWAgjxRYELaA;

				public int ETrXWJbjDwfqBDTaaPKDMVAWRMfm;

				public MapHelper PZggkLPcqnfnQFiaCqoonDuhkxoI;

				private ControllerType nlDUWiRmYrOadtCzxrSHVcLVHJuX;

				public ControllerType hnXeGRcTBscHMhILTngjXGdeFcwY;

				private bool dtqCWXHYGBWoOgjJCgkYAtxaoyTlc;

				public bool YBwYItQpxfBbheltdwpIEAMDzWpGA;

				private HENtlJpbLTfyvGNBdnYOTBUpGwmPA gQIrrAyUDLzqTYcuodsYelfNqrRL;

				private int wQXbErPDnZwklnkbwRHyLblBTFbO;

				private IList<ControllerMap> wWrttDtFIOyYhQFzVaMEiGGYiKFyA;

				private int RMWQUZeweBIGBmORKZVnKRnicGcX;

				private IEnumerator<ActionElementMap> UbrLstLKJRnHitDNIWWzWhBWQAJX;

				ActionElementMap IEnumerator<ActionElementMap>.Current
				{
					[DebuggerHidden]
					get
					{
						return yzcCJlBDoZqDHFsUOcnwfexONtEfb;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return yzcCJlBDoZqDHFsUOcnwfexONtEfb;
					}
				}

				[DebuggerHidden]
				public NoRaHZrRkapKaXaxOIdFXtoBmWQO(int P_0)
				{
					OYbUQruBjDVPuPfluozFmzulLeVh = P_0;
					sRrfmBJNacgiWEFrCxDTVevhEAdhc = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					int oYbUQruBjDVPuPfluozFmzulLeVh = OYbUQruBjDVPuPfluozFmzulLeVh;
					if (oYbUQruBjDVPuPfluozFmzulLeVh == -3 || oYbUQruBjDVPuPfluozFmzulLeVh == 1)
					{
						try
						{
						}
						finally
						{
							XBiBAnXnctGoFzjZXwlIIAlHyJzn();
						}
					}
				}

				private bool MoveNext()
				{
					try
					{
						int oYbUQruBjDVPuPfluozFmzulLeVh = OYbUQruBjDVPuPfluozFmzulLeVh;
						MapHelper pZggkLPcqnfnQFiaCqoonDuhkxoI = PZggkLPcqnfnQFiaCqoonDuhkxoI;
						if (oYbUQruBjDVPuPfluozFmzulLeVh != 0)
						{
							if (oYbUQruBjDVPuPfluozFmzulLeVh != 1)
							{
								return false;
							}
							OYbUQruBjDVPuPfluozFmzulLeVh = -3;
							goto IL_012c;
						}
						OYbUQruBjDVPuPfluozFmzulLeVh = -1;
						if (tyTGpWYiouEsqFsPghWAgjxRYELaA < 0)
						{
							return false;
						}
						gQIrrAyUDLzqTYcuodsYelfNqrRL = pZggkLPcqnfnQFiaCqoonDuhkxoI.yfZPVbkoNrPFYlhxRcQrxPzDLvft.QecjgvgRSXuPhnYvNrbSsHRqQwjg.AXLlayIlTwJqJNaNzeKccuszIcODb(nlDUWiRmYrOadtCzxrSHVcLVHJuX);
						wQXbErPDnZwklnkbwRHyLblBTFbO = 0;
						goto IL_0187;
						IL_012c:
						if (UbrLstLKJRnHitDNIWWzWhBWQAJX.MoveNext())
						{
							ActionElementMap current = UbrLstLKJRnHitDNIWWzWhBWQAJX.Current;
							yzcCJlBDoZqDHFsUOcnwfexONtEfb = current;
							OYbUQruBjDVPuPfluozFmzulLeVh = 1;
							return true;
						}
						XBiBAnXnctGoFzjZXwlIIAlHyJzn();
						UbrLstLKJRnHitDNIWWzWhBWQAJX = null;
						goto IL_0146;
						IL_0158:
						if (RMWQUZeweBIGBmORKZVnKRnicGcX < wWrttDtFIOyYhQFzVaMEiGGYiKFyA.Count)
						{
							if ((!dtqCWXHYGBWoOgjJCgkYAtxaoyTlc || wWrttDtFIOyYhQFzVaMEiGGYiKFyA[RMWQUZeweBIGBmORKZVnKRnicGcX].enabled) && wWrttDtFIOyYhQFzVaMEiGGYiKFyA[RMWQUZeweBIGBmORKZVnKRnicGcX].ContainsAction(tyTGpWYiouEsqFsPghWAgjxRYELaA))
							{
								UbrLstLKJRnHitDNIWWzWhBWQAJX = wWrttDtFIOyYhQFzVaMEiGGYiKFyA[RMWQUZeweBIGBmORKZVnKRnicGcX].ElementMapsWithAction(tyTGpWYiouEsqFsPghWAgjxRYELaA, dtqCWXHYGBWoOgjJCgkYAtxaoyTlc).GetEnumerator();
								OYbUQruBjDVPuPfluozFmzulLeVh = -3;
								goto IL_012c;
							}
							goto IL_0146;
						}
						wWrttDtFIOyYhQFzVaMEiGGYiKFyA = null;
						wQXbErPDnZwklnkbwRHyLblBTFbO++;
						goto IL_0187;
						IL_0146:
						RMWQUZeweBIGBmORKZVnKRnicGcX++;
						goto IL_0158;
						IL_0187:
						if (wQXbErPDnZwklnkbwRHyLblBTFbO < gQIrrAyUDLzqTYcuodsYelfNqrRL.rphZqyUfbdoINyXndGfDbQaiIHFM())
						{
							wWrttDtFIOyYhQFzVaMEiGGYiKFyA = gQIrrAyUDLzqTYcuodsYelfNqrRL.gmqWnmpZMnASuZpGLEqmJcwgXIqMA(wQXbErPDnZwklnkbwRHyLblBTFbO).ycfaKniCLOzZqlQviANrBfbEZIlRA().yNPIkhCQyqKjUMKWnmnPppLEAttk();
							RMWQUZeweBIGBmORKZVnKRnicGcX = 0;
							goto IL_0158;
						}
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

				private void XBiBAnXnctGoFzjZXwlIIAlHyJzn()
				{
					OYbUQruBjDVPuPfluozFmzulLeVh = -1;
					if (UbrLstLKJRnHitDNIWWzWhBWQAJX != null)
					{
						UbrLstLKJRnHitDNIWWzWhBWQAJX.Dispose();
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
					NoRaHZrRkapKaXaxOIdFXtoBmWQO noRaHZrRkapKaXaxOIdFXtoBmWQO;
					if (OYbUQruBjDVPuPfluozFmzulLeVh == -2 && sRrfmBJNacgiWEFrCxDTVevhEAdhc == Environment.CurrentManagedThreadId)
					{
						OYbUQruBjDVPuPfluozFmzulLeVh = 0;
						noRaHZrRkapKaXaxOIdFXtoBmWQO = this;
					}
					else
					{
						noRaHZrRkapKaXaxOIdFXtoBmWQO = new NoRaHZrRkapKaXaxOIdFXtoBmWQO(0);
						noRaHZrRkapKaXaxOIdFXtoBmWQO.PZggkLPcqnfnQFiaCqoonDuhkxoI = PZggkLPcqnfnQFiaCqoonDuhkxoI;
					}
					noRaHZrRkapKaXaxOIdFXtoBmWQO.nlDUWiRmYrOadtCzxrSHVcLVHJuX = hnXeGRcTBscHMhILTngjXGdeFcwY;
					noRaHZrRkapKaXaxOIdFXtoBmWQO.tyTGpWYiouEsqFsPghWAgjxRYELaA = ETrXWJbjDwfqBDTaaPKDMVAWRMfm;
					noRaHZrRkapKaXaxOIdFXtoBmWQO.dtqCWXHYGBWoOgjJCgkYAtxaoyTlc = YBwYItQpxfBbheltdwpIEAMDzWpGA;
					return noRaHZrRkapKaXaxOIdFXtoBmWQO;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
				}
			}

			private sealed class gkAxnNkwnzJIHSllMCthySTXdFey : IEnumerable<ActionElementMap>, IEnumerable, IEnumerator<ActionElementMap>, IEnumerator, IDisposable
			{
				private int zwfsUzCUNAVfmSjwvWpcpwoLlDhc;

				private ActionElementMap LfcDPSFYXOANJSHbOxADfhFhULsk;

				private int ddDvejVHoJdaSYFzHHXQxAknSzTh;

				private int nrskUlatQhTVdBHRNqKzJiTNEkGkA;

				public int vADAOBfSuoqHwooDtzSTBfscxOvL;

				public MapHelper TfbyLhoQvrKaBMxqCmFSXZsYtwGb;

				private ControllerType NPWXnuSpmdGSeKFUEShQBdGbGJSBA;

				public ControllerType lJocabdsddXReHICcQcUdUYaZuAQA;

				private int FeYaLHhpiwWFtddkQqQAKHtDkQeZA;

				public int EkhmKgYwDTWCDOxnYNuAGOeOxHfY;

				private bool hqkjabbfSQEfmowLWAVogfeacJZnA;

				public bool WvRDAmttCpCeNgkMEknPgNdxjDAfb;

				private IList<ControllerMap> TILguyWmdldgdeJkjdnkFsKYPnK;

				private int IyzYHxzqueWUiJMVnPNnytfcloPS;

				private IEnumerator<ActionElementMap> zSCLYNIWqPFBTIYFaOrbOnMcEQEo;

				ActionElementMap IEnumerator<ActionElementMap>.Current
				{
					[DebuggerHidden]
					get
					{
						return LfcDPSFYXOANJSHbOxADfhFhULsk;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return LfcDPSFYXOANJSHbOxADfhFhULsk;
					}
				}

				[DebuggerHidden]
				public gkAxnNkwnzJIHSllMCthySTXdFey(int P_0)
				{
					zwfsUzCUNAVfmSjwvWpcpwoLlDhc = P_0;
					ddDvejVHoJdaSYFzHHXQxAknSzTh = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					int num = zwfsUzCUNAVfmSjwvWpcpwoLlDhc;
					if (num == -3 || num == 1)
					{
						try
						{
						}
						finally
						{
							EkdazxeEnQIrfbFYZJWYZWezkvUnA();
						}
					}
				}

				private bool MoveNext()
				{
					try
					{
						int num = zwfsUzCUNAVfmSjwvWpcpwoLlDhc;
						MapHelper tfbyLhoQvrKaBMxqCmFSXZsYtwGb = TfbyLhoQvrKaBMxqCmFSXZsYtwGb;
						if (num != 0)
						{
							if (num != 1)
							{
								return false;
							}
							zwfsUzCUNAVfmSjwvWpcpwoLlDhc = -3;
							goto IL_012b;
						}
						zwfsUzCUNAVfmSjwvWpcpwoLlDhc = -1;
						if (nrskUlatQhTVdBHRNqKzJiTNEkGkA < 0)
						{
							return false;
						}
						HENtlJpbLTfyvGNBdnYOTBUpGwmPA hENtlJpbLTfyvGNBdnYOTBUpGwmPA = tfbyLhoQvrKaBMxqCmFSXZsYtwGb.yfZPVbkoNrPFYlhxRcQrxPzDLvft.QecjgvgRSXuPhnYvNrbSsHRqQwjg.AXLlayIlTwJqJNaNzeKccuszIcODb(NPWXnuSpmdGSeKFUEShQBdGbGJSBA);
						int num2 = hENtlJpbLTfyvGNBdnYOTBUpGwmPA.LwDtjAISpvZKUEBiCEPKHyoscvdr(FeYaLHhpiwWFtddkQqQAKHtDkQeZA);
						if (num2 < 0)
						{
							return false;
						}
						TILguyWmdldgdeJkjdnkFsKYPnK = hENtlJpbLTfyvGNBdnYOTBUpGwmPA.gmqWnmpZMnASuZpGLEqmJcwgXIqMA(num2).ycfaKniCLOzZqlQviANrBfbEZIlRA().yNPIkhCQyqKjUMKWnmnPppLEAttk();
						IyzYHxzqueWUiJMVnPNnytfcloPS = 0;
						goto IL_0157;
						IL_012b:
						if (zSCLYNIWqPFBTIYFaOrbOnMcEQEo.MoveNext())
						{
							ActionElementMap current = zSCLYNIWqPFBTIYFaOrbOnMcEQEo.Current;
							LfcDPSFYXOANJSHbOxADfhFhULsk = current;
							zwfsUzCUNAVfmSjwvWpcpwoLlDhc = 1;
							return true;
						}
						EkdazxeEnQIrfbFYZJWYZWezkvUnA();
						zSCLYNIWqPFBTIYFaOrbOnMcEQEo = null;
						goto IL_0145;
						IL_0157:
						if (IyzYHxzqueWUiJMVnPNnytfcloPS < TILguyWmdldgdeJkjdnkFsKYPnK.Count)
						{
							if ((!hqkjabbfSQEfmowLWAVogfeacJZnA || TILguyWmdldgdeJkjdnkFsKYPnK[IyzYHxzqueWUiJMVnPNnytfcloPS].enabled) && TILguyWmdldgdeJkjdnkFsKYPnK[IyzYHxzqueWUiJMVnPNnytfcloPS].ContainsAction(nrskUlatQhTVdBHRNqKzJiTNEkGkA))
							{
								zSCLYNIWqPFBTIYFaOrbOnMcEQEo = TILguyWmdldgdeJkjdnkFsKYPnK[IyzYHxzqueWUiJMVnPNnytfcloPS].ElementMapsWithAction(nrskUlatQhTVdBHRNqKzJiTNEkGkA, hqkjabbfSQEfmowLWAVogfeacJZnA).GetEnumerator();
								zwfsUzCUNAVfmSjwvWpcpwoLlDhc = -3;
								goto IL_012b;
							}
							goto IL_0145;
						}
						return false;
						IL_0145:
						IyzYHxzqueWUiJMVnPNnytfcloPS++;
						goto IL_0157;
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

				private void EkdazxeEnQIrfbFYZJWYZWezkvUnA()
				{
					zwfsUzCUNAVfmSjwvWpcpwoLlDhc = -1;
					if (zSCLYNIWqPFBTIYFaOrbOnMcEQEo != null)
					{
						zSCLYNIWqPFBTIYFaOrbOnMcEQEo.Dispose();
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
					gkAxnNkwnzJIHSllMCthySTXdFey gkAxnNkwnzJIHSllMCthySTXdFey2;
					if (zwfsUzCUNAVfmSjwvWpcpwoLlDhc == -2 && ddDvejVHoJdaSYFzHHXQxAknSzTh == Environment.CurrentManagedThreadId)
					{
						zwfsUzCUNAVfmSjwvWpcpwoLlDhc = 0;
						gkAxnNkwnzJIHSllMCthySTXdFey2 = this;
					}
					else
					{
						gkAxnNkwnzJIHSllMCthySTXdFey2 = new gkAxnNkwnzJIHSllMCthySTXdFey(0);
						gkAxnNkwnzJIHSllMCthySTXdFey2.TfbyLhoQvrKaBMxqCmFSXZsYtwGb = TfbyLhoQvrKaBMxqCmFSXZsYtwGb;
					}
					gkAxnNkwnzJIHSllMCthySTXdFey2.NPWXnuSpmdGSeKFUEShQBdGbGJSBA = lJocabdsddXReHICcQcUdUYaZuAQA;
					gkAxnNkwnzJIHSllMCthySTXdFey2.FeYaLHhpiwWFtddkQqQAKHtDkQeZA = EkhmKgYwDTWCDOxnYNuAGOeOxHfY;
					gkAxnNkwnzJIHSllMCthySTXdFey2.nrskUlatQhTVdBHRNqKzJiTNEkGkA = vADAOBfSuoqHwooDtzSTBfscxOvL;
					gkAxnNkwnzJIHSllMCthySTXdFey2.hqkjabbfSQEfmowLWAVogfeacJZnA = WvRDAmttCpCeNgkMEknPgNdxjDAfb;
					return gkAxnNkwnzJIHSllMCthySTXdFey2;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
				}
			}

			private sealed class pVwofaTjyXFriIklDtZrktIXBSWKA : IEnumerable<ControllerMap>, IEnumerable, IEnumerator<ControllerMap>, IEnumerator, IDisposable
			{
				private int GZEnXMdoFPVcuHgzFBStdcdniogfA;

				private ControllerMap nfGXfDHhViBCLivjdPcFeZgWYzMA;

				private int brQBDdzqCtQXrykTxgdUHPclioBk;

				public MapHelper akafSMtCOCGAXoGnXFOTtGwTDdgt;

				private ControllerType AMMWkdWmHZppwOlUmduOGEAetTdoA;

				public ControllerType YSjRNDoIwFhWvKAfTgMWtsqxARPCA;

				private int RVbDpYpkRndaiEBeKDqGrzqMlkZgA;

				public int WpXqyLWiLwDXxbLAeTxTJcNaiPyW;

				private int xTpUCVNEicYYIuUBBrGKKyFpTRbq;

				public int CMPIjzVTKbvcZvlGFCGdBJHmMMdMA;

				private IList<ControllerMap> XtLGwLorCyrIrRIWVflAHeNMxgLw;

				private int IBxfIkFTAXgDxWPYCKwFzajiWrSY;

				ControllerMap IEnumerator<ControllerMap>.Current
				{
					[DebuggerHidden]
					get
					{
						return nfGXfDHhViBCLivjdPcFeZgWYzMA;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return nfGXfDHhViBCLivjdPcFeZgWYzMA;
					}
				}

				[DebuggerHidden]
				public pVwofaTjyXFriIklDtZrktIXBSWKA(int P_0)
				{
					GZEnXMdoFPVcuHgzFBStdcdniogfA = P_0;
					brQBDdzqCtQXrykTxgdUHPclioBk = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int gZEnXMdoFPVcuHgzFBStdcdniogfA = GZEnXMdoFPVcuHgzFBStdcdniogfA;
					MapHelper mapHelper = akafSMtCOCGAXoGnXFOTtGwTDdgt;
					if (gZEnXMdoFPVcuHgzFBStdcdniogfA != 0)
					{
						if (gZEnXMdoFPVcuHgzFBStdcdniogfA != 1)
						{
							return false;
						}
						GZEnXMdoFPVcuHgzFBStdcdniogfA = -1;
						goto IL_00b0;
					}
					GZEnXMdoFPVcuHgzFBStdcdniogfA = -1;
					HENtlJpbLTfyvGNBdnYOTBUpGwmPA hENtlJpbLTfyvGNBdnYOTBUpGwmPA = mapHelper.yfZPVbkoNrPFYlhxRcQrxPzDLvft.QecjgvgRSXuPhnYvNrbSsHRqQwjg.AXLlayIlTwJqJNaNzeKccuszIcODb(AMMWkdWmHZppwOlUmduOGEAetTdoA);
					int num = hENtlJpbLTfyvGNBdnYOTBUpGwmPA.LwDtjAISpvZKUEBiCEPKHyoscvdr(RVbDpYpkRndaiEBeKDqGrzqMlkZgA);
					if (num < 0)
					{
						return false;
					}
					XtLGwLorCyrIrRIWVflAHeNMxgLw = hENtlJpbLTfyvGNBdnYOTBUpGwmPA.gmqWnmpZMnASuZpGLEqmJcwgXIqMA(num).ycfaKniCLOzZqlQviANrBfbEZIlRA().yNPIkhCQyqKjUMKWnmnPppLEAttk();
					IBxfIkFTAXgDxWPYCKwFzajiWrSY = 0;
					goto IL_00c2;
					IL_00c2:
					if (IBxfIkFTAXgDxWPYCKwFzajiWrSY < XtLGwLorCyrIrRIWVflAHeNMxgLw.Count)
					{
						if (XtLGwLorCyrIrRIWVflAHeNMxgLw[IBxfIkFTAXgDxWPYCKwFzajiWrSY].categoryId == xTpUCVNEicYYIuUBBrGKKyFpTRbq)
						{
							nfGXfDHhViBCLivjdPcFeZgWYzMA = XtLGwLorCyrIrRIWVflAHeNMxgLw[IBxfIkFTAXgDxWPYCKwFzajiWrSY];
							GZEnXMdoFPVcuHgzFBStdcdniogfA = 1;
							return true;
						}
						goto IL_00b0;
					}
					return false;
					IL_00b0:
					IBxfIkFTAXgDxWPYCKwFzajiWrSY++;
					goto IL_00c2;
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
				IEnumerator<ControllerMap> IEnumerable<ControllerMap>.GetEnumerator()
				{
					pVwofaTjyXFriIklDtZrktIXBSWKA pVwofaTjyXFriIklDtZrktIXBSWKA2;
					if (GZEnXMdoFPVcuHgzFBStdcdniogfA == -2 && brQBDdzqCtQXrykTxgdUHPclioBk == Environment.CurrentManagedThreadId)
					{
						GZEnXMdoFPVcuHgzFBStdcdniogfA = 0;
						pVwofaTjyXFriIklDtZrktIXBSWKA2 = this;
					}
					else
					{
						pVwofaTjyXFriIklDtZrktIXBSWKA2 = new pVwofaTjyXFriIklDtZrktIXBSWKA(0);
						pVwofaTjyXFriIklDtZrktIXBSWKA2.akafSMtCOCGAXoGnXFOTtGwTDdgt = akafSMtCOCGAXoGnXFOTtGwTDdgt;
					}
					pVwofaTjyXFriIklDtZrktIXBSWKA2.AMMWkdWmHZppwOlUmduOGEAetTdoA = YSjRNDoIwFhWvKAfTgMWtsqxARPCA;
					pVwofaTjyXFriIklDtZrktIXBSWKA2.RVbDpYpkRndaiEBeKDqGrzqMlkZgA = WpXqyLWiLwDXxbLAeTxTJcNaiPyW;
					pVwofaTjyXFriIklDtZrktIXBSWKA2.xTpUCVNEicYYIuUBBrGKKyFpTRbq = CMPIjzVTKbvcZvlGFCGdBJHmMMdMA;
					return pVwofaTjyXFriIklDtZrktIXBSWKA2;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<ControllerMap>)this).GetEnumerator();
				}
			}

			private sealed class QlQREzIGiEqzwqsAupgsMwvzntaV<_0001> : IEnumerable<_0001>, IEnumerable, IEnumerator<_0001>, IEnumerator, IDisposable where _0001 : ControllerMap
			{
				private int iDIsICSSausGjvSPwmoFWWpvqgjl;

				private _0001 OxjwrYTgZCgpbBIrjuFABPEcrqbJA;

				private int HFMCdglmEJetQDtxNjQPgQPaFQjeb;

				public MapHelper LHeeyQQtKOBUJiPpaNbSVcmiaXkWA;

				private int pMrcLzXneywdmEawBYPehUgCArxc;

				public int gFxFxxLoCshxlaGBCqRlCuYqJwKGb;

				private int zxJVIJXBeJylDDgCEVasblZniDDs;

				public int tpHeMwvLFSjwRivBvDLwcvnOEWTD;

				private IList<_0001> xFhULwOpOZPyMxdZtydasoYAwHef;

				private int ZaIUPklKnaAtVaqKpuFwINRIwtyz;

				_0001 IEnumerator<_0001>.Current
				{
					[DebuggerHidden]
					get
					{
						return System_002ECollections_002EGeneric_002EIEnumerator_003CT_003E_002Eget_Current();
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return OxjwrYTgZCgpbBIrjuFABPEcrqbJA;
					}
				}

				[DebuggerHidden]
				public QlQREzIGiEqzwqsAupgsMwvzntaV(int P_0)
				{
					iDIsICSSausGjvSPwmoFWWpvqgjl = P_0;
					HFMCdglmEJetQDtxNjQPgQPaFQjeb = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int num = iDIsICSSausGjvSPwmoFWWpvqgjl;
					MapHelper lHeeyQQtKOBUJiPpaNbSVcmiaXkWA = LHeeyQQtKOBUJiPpaNbSVcmiaXkWA;
					if (num != 0)
					{
						if (num != 1)
						{
							return false;
						}
						iDIsICSSausGjvSPwmoFWWpvqgjl = -1;
						goto IL_00b9;
					}
					iDIsICSSausGjvSPwmoFWWpvqgjl = -1;
					ControllerType controllerType = IyPmashUlRgIygDiHFyDZHZmauql.vBvhRnrsyKoNMsAeKAkRzastNVbp<_0001>();
					HENtlJpbLTfyvGNBdnYOTBUpGwmPA hENtlJpbLTfyvGNBdnYOTBUpGwmPA = lHeeyQQtKOBUJiPpaNbSVcmiaXkWA.yfZPVbkoNrPFYlhxRcQrxPzDLvft.QecjgvgRSXuPhnYvNrbSsHRqQwjg.AXLlayIlTwJqJNaNzeKccuszIcODb(controllerType);
					int num2 = hENtlJpbLTfyvGNBdnYOTBUpGwmPA.LwDtjAISpvZKUEBiCEPKHyoscvdr(pMrcLzXneywdmEawBYPehUgCArxc);
					if (num2 < 0)
					{
						return false;
					}
					xFhULwOpOZPyMxdZtydasoYAwHef = hENtlJpbLTfyvGNBdnYOTBUpGwmPA.gmqWnmpZMnASuZpGLEqmJcwgXIqMA(num2).ycfaKniCLOzZqlQviANrBfbEZIlRA().lEtyaZbfxqQkwhuWxnvKuecgHwtFA<_0001>();
					ZaIUPklKnaAtVaqKpuFwINRIwtyz = 0;
					goto IL_00cb;
					IL_00cb:
					if (ZaIUPklKnaAtVaqKpuFwINRIwtyz < xFhULwOpOZPyMxdZtydasoYAwHef.Count)
					{
						if (xFhULwOpOZPyMxdZtydasoYAwHef[ZaIUPklKnaAtVaqKpuFwINRIwtyz].categoryId == zxJVIJXBeJylDDgCEVasblZniDDs)
						{
							OxjwrYTgZCgpbBIrjuFABPEcrqbJA = xFhULwOpOZPyMxdZtydasoYAwHef[ZaIUPklKnaAtVaqKpuFwINRIwtyz];
							iDIsICSSausGjvSPwmoFWWpvqgjl = 1;
							return true;
						}
						goto IL_00b9;
					}
					return false;
					IL_00b9:
					ZaIUPklKnaAtVaqKpuFwINRIwtyz++;
					goto IL_00cb;
				}

				bool IEnumerator.MoveNext()
				{
					//ILSpy generated this explicit interface implementation from .override directive in MoveNext
					return this.MoveNext();
				}

				[DebuggerHidden]
				private _0001 System_002ECollections_002EGeneric_002EIEnumerator_003CT_003E_002Eget_Current()
				{
					return OxjwrYTgZCgpbBIrjuFABPEcrqbJA;
				}

				[DebuggerHidden]
				void IEnumerator.Reset()
				{
					throw new NotSupportedException();
				}

				[DebuggerHidden]
				IEnumerator<_0001> IEnumerable<_0001>.GetEnumerator()
				{
					QlQREzIGiEqzwqsAupgsMwvzntaV<_0001> qlQREzIGiEqzwqsAupgsMwvzntaV;
					if (iDIsICSSausGjvSPwmoFWWpvqgjl == -2 && HFMCdglmEJetQDtxNjQPgQPaFQjeb == Environment.CurrentManagedThreadId)
					{
						iDIsICSSausGjvSPwmoFWWpvqgjl = 0;
						qlQREzIGiEqzwqsAupgsMwvzntaV = this;
					}
					else
					{
						qlQREzIGiEqzwqsAupgsMwvzntaV = new QlQREzIGiEqzwqsAupgsMwvzntaV<_0001>(0);
						qlQREzIGiEqzwqsAupgsMwvzntaV.LHeeyQQtKOBUJiPpaNbSVcmiaXkWA = LHeeyQQtKOBUJiPpaNbSVcmiaXkWA;
					}
					qlQREzIGiEqzwqsAupgsMwvzntaV.pMrcLzXneywdmEawBYPehUgCArxc = gFxFxxLoCshxlaGBCqRlCuYqJwKGb;
					qlQREzIGiEqzwqsAupgsMwvzntaV.zxJVIJXBeJylDDgCEVasblZniDDs = tpHeMwvLFSjwRivBvDLwcvnOEWTD;
					return qlQREzIGiEqzwqsAupgsMwvzntaV;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<_0001>)this).GetEnumerator();
				}
			}

			private sealed class UpqJxxMTJWtBLnyKstpEAoGxAJVJA : IEnumerable<ActionElementMap>, IEnumerable, IEnumerator<ActionElementMap>, IEnumerator, IDisposable
			{
				private int SBDpcHjhQhGBgDBpeFEaCIhvdoFU;

				private ActionElementMap aWIzixzyqIsCaJurTsVwSNoxeHDo;

				private int gzVgTOFCXUCHobvjIOvcKefgqzTwA;

				public MapHelper QDfGhixisaykEbjkHipWLwAlqpou;

				private int UgIGqEnTaJxCdHEnMYyLEvkjQkgb;

				public int nWdhVBKTZGgYnuzRqQCQtNjeARbh;

				private bool dMBiRaZMJwapQJcPnnKDhwcPNZOSA;

				public bool wlTBceKxCEngMrpVowSALZrsgJGJ;

				private int txeEphHAFhXXwlLpFyXiGLIIXJtcA;

				private int jCBErqoPItnhqLJCnYuyODNggmVL;

				private HENtlJpbLTfyvGNBdnYOTBUpGwmPA ILPmDxIShwAktTDhDxucbJJrUigt;

				private int HqzDyCwWwFXKLVSGhwZwaWmrDjhN;

				private int vwCFFgIgrtebCZYLyaVchlRjWKogA;

				private FsyiqPdJeSfbLIuiSYvjZeDpZMzW McHAOvftiISOAEIgAYxoTtecFYHfb;

				private int PTubZHIHTUGRluNZnyVvZNPwiFldA;

				private int myrekEGoczDfPNpnauaOhVTQJZLI;

				private IEnumerator<ActionElementMap> eQufIUwtILpBybecZaIliCJPXzvz;

				ActionElementMap IEnumerator<ActionElementMap>.Current
				{
					[DebuggerHidden]
					get
					{
						return aWIzixzyqIsCaJurTsVwSNoxeHDo;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return aWIzixzyqIsCaJurTsVwSNoxeHDo;
					}
				}

				[DebuggerHidden]
				public UpqJxxMTJWtBLnyKstpEAoGxAJVJA(int P_0)
				{
					SBDpcHjhQhGBgDBpeFEaCIhvdoFU = P_0;
					gzVgTOFCXUCHobvjIOvcKefgqzTwA = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					int sBDpcHjhQhGBgDBpeFEaCIhvdoFU = SBDpcHjhQhGBgDBpeFEaCIhvdoFU;
					if (sBDpcHjhQhGBgDBpeFEaCIhvdoFU == -3 || sBDpcHjhQhGBgDBpeFEaCIhvdoFU == 1)
					{
						try
						{
						}
						finally
						{
							YHnyxQKvWFnpYlutmhVDQOXqSCds();
						}
					}
				}

				private bool MoveNext()
				{
					try
					{
						int sBDpcHjhQhGBgDBpeFEaCIhvdoFU = SBDpcHjhQhGBgDBpeFEaCIhvdoFU;
						MapHelper qDfGhixisaykEbjkHipWLwAlqpou = QDfGhixisaykEbjkHipWLwAlqpou;
						if (sBDpcHjhQhGBgDBpeFEaCIhvdoFU != 0)
						{
							if (sBDpcHjhQhGBgDBpeFEaCIhvdoFU != 1)
							{
								return false;
							}
							SBDpcHjhQhGBgDBpeFEaCIhvdoFU = -3;
							goto IL_016c;
						}
						SBDpcHjhQhGBgDBpeFEaCIhvdoFU = -1;
						if (ReInput._id != qDfGhixisaykEbjkHipWLwAlqpou.azGvCmHxftPofYbbgHwfQfhmWSgV)
						{
							ReInput.CheckInitialized(qDfGhixisaykEbjkHipWLwAlqpou.azGvCmHxftPofYbbgHwfQfhmWSgV);
							return false;
						}
						if (UgIGqEnTaJxCdHEnMYyLEvkjQkgb < 0)
						{
							return false;
						}
						txeEphHAFhXXwlLpFyXiGLIIXJtcA = qDfGhixisaykEbjkHipWLwAlqpou.yfZPVbkoNrPFYlhxRcQrxPzDLvft.QecjgvgRSXuPhnYvNrbSsHRqQwjg.KzSWyhVFpKvuMAleUEiVntIEyGZD;
						jCBErqoPItnhqLJCnYuyODNggmVL = 0;
						goto IL_01ec;
						IL_016c:
						if (eQufIUwtILpBybecZaIliCJPXzvz.MoveNext())
						{
							ActionElementMap current = eQufIUwtILpBybecZaIliCJPXzvz.Current;
							aWIzixzyqIsCaJurTsVwSNoxeHDo = current;
							SBDpcHjhQhGBgDBpeFEaCIhvdoFU = 1;
							return true;
						}
						YHnyxQKvWFnpYlutmhVDQOXqSCds();
						eQufIUwtILpBybecZaIliCJPXzvz = null;
						goto IL_0186;
						IL_0186:
						myrekEGoczDfPNpnauaOhVTQJZLI++;
						goto IL_0198;
						IL_01c2:
						if (vwCFFgIgrtebCZYLyaVchlRjWKogA < HqzDyCwWwFXKLVSGhwZwaWmrDjhN)
						{
							McHAOvftiISOAEIgAYxoTtecFYHfb = ILPmDxIShwAktTDhDxucbJJrUigt.gmqWnmpZMnASuZpGLEqmJcwgXIqMA(vwCFFgIgrtebCZYLyaVchlRjWKogA).ycfaKniCLOzZqlQviANrBfbEZIlRA();
							PTubZHIHTUGRluNZnyVvZNPwiFldA = McHAOvftiISOAEIgAYxoTtecFYHfb.ejOOZrUqJLRyRGoRofwTThHfNEkF();
							myrekEGoczDfPNpnauaOhVTQJZLI = 0;
							goto IL_0198;
						}
						ILPmDxIShwAktTDhDxucbJJrUigt = null;
						jCBErqoPItnhqLJCnYuyODNggmVL++;
						goto IL_01ec;
						IL_0198:
						if (myrekEGoczDfPNpnauaOhVTQJZLI < PTubZHIHTUGRluNZnyVvZNPwiFldA)
						{
							ControllerMap controllerMap = McHAOvftiISOAEIgAYxoTtecFYHfb.QIeXsLdCiAXGGxCgarjGtHyqkDbM(myrekEGoczDfPNpnauaOhVTQJZLI);
							if ((!dMBiRaZMJwapQJcPnnKDhwcPNZOSA || controllerMap.enabled) && controllerMap.ContainsAction(UgIGqEnTaJxCdHEnMYyLEvkjQkgb))
							{
								eQufIUwtILpBybecZaIliCJPXzvz = controllerMap.ElementMapsWithAction(UgIGqEnTaJxCdHEnMYyLEvkjQkgb, dMBiRaZMJwapQJcPnnKDhwcPNZOSA).GetEnumerator();
								SBDpcHjhQhGBgDBpeFEaCIhvdoFU = -3;
								goto IL_016c;
							}
							goto IL_0186;
						}
						McHAOvftiISOAEIgAYxoTtecFYHfb = null;
						vwCFFgIgrtebCZYLyaVchlRjWKogA++;
						goto IL_01c2;
						IL_01ec:
						if (jCBErqoPItnhqLJCnYuyODNggmVL < txeEphHAFhXXwlLpFyXiGLIIXJtcA)
						{
							ILPmDxIShwAktTDhDxucbJJrUigt = qDfGhixisaykEbjkHipWLwAlqpou.yfZPVbkoNrPFYlhxRcQrxPzDLvft.QecjgvgRSXuPhnYvNrbSsHRqQwjg.AMmiEUMJUxmCKCltvrDeLoaPvEGE(jCBErqoPItnhqLJCnYuyODNggmVL);
							HqzDyCwWwFXKLVSGhwZwaWmrDjhN = ILPmDxIShwAktTDhDxucbJJrUigt.rphZqyUfbdoINyXndGfDbQaiIHFM();
							vwCFFgIgrtebCZYLyaVchlRjWKogA = 0;
							goto IL_01c2;
						}
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

				private void YHnyxQKvWFnpYlutmhVDQOXqSCds()
				{
					SBDpcHjhQhGBgDBpeFEaCIhvdoFU = -1;
					if (eQufIUwtILpBybecZaIliCJPXzvz != null)
					{
						eQufIUwtILpBybecZaIliCJPXzvz.Dispose();
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
					UpqJxxMTJWtBLnyKstpEAoGxAJVJA upqJxxMTJWtBLnyKstpEAoGxAJVJA;
					if (SBDpcHjhQhGBgDBpeFEaCIhvdoFU == -2 && gzVgTOFCXUCHobvjIOvcKefgqzTwA == Environment.CurrentManagedThreadId)
					{
						SBDpcHjhQhGBgDBpeFEaCIhvdoFU = 0;
						upqJxxMTJWtBLnyKstpEAoGxAJVJA = this;
					}
					else
					{
						upqJxxMTJWtBLnyKstpEAoGxAJVJA = new UpqJxxMTJWtBLnyKstpEAoGxAJVJA(0);
						upqJxxMTJWtBLnyKstpEAoGxAJVJA.QDfGhixisaykEbjkHipWLwAlqpou = QDfGhixisaykEbjkHipWLwAlqpou;
					}
					upqJxxMTJWtBLnyKstpEAoGxAJVJA.UgIGqEnTaJxCdHEnMYyLEvkjQkgb = nWdhVBKTZGgYnuzRqQCQtNjeARbh;
					upqJxxMTJWtBLnyKstpEAoGxAJVJA.dMBiRaZMJwapQJcPnnKDhwcPNZOSA = wlTBceKxCEngMrpVowSALZrsgJGJ;
					return upqJxxMTJWtBLnyKstpEAoGxAJVJA;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
				}
			}

			private sealed class tjbDGEecyyhXLrBMocBGihgXqDmqA : IEnumerable<ActionElementMap>, IEnumerable, IEnumerator<ActionElementMap>, IEnumerator, IDisposable
			{
				private int qdniNMKmfrnwDjdodERFVjaubjoy;

				private ActionElementMap NqaAJaZVNuFuTLOYNaTbmOKnKbDw;

				private int NyanqZPPWtoDTFtxpnOcVSXBYXOB;

				private IControllerElementTarget OQNoAQgyQXnofwhCLEhJfmxRKapib;

				public IControllerElementTarget tskWNCmLvMxMDkyyBpoCuBxIVtlF;

				public MapHelper gjzsKoCbCkbpdAHqGmCFCIbAqqZBA;

				private bool MKBTNBWigpDZCzfwAelozASIFGhEA;

				public bool LVntSLbIXqeTzMixLCylBoDuYDrC;

				private bool KyARQBGkcZTwnVounbkaxVgVALfB;

				public bool rNgmlHzspLNBLlxgQMxwSeguwryP;

				private int dHgrzzvqKbPZRBGbzNwPtoLqrbYd;

				public int XpvklkJrwEYQutWuGWwjWYIijYjb;

				private HENtlJpbLTfyvGNBdnYOTBUpGwmPA pNrqAxRXTFHMJFlbYKNUcoJdNCEO;

				private int MHedrGAyamvnLKSUYMadFrxCJmYjA;

				private int rVntRtmsxMCpRNlTfreCeCybieSG;

				private IList<ControllerMap> jmteFaHCyLDGHAQQxdaoImpKAIlbb;

				private int kWfbTLkGBsTkOAqAbxOqREBAObhBA;

				private int SvOijLKlJZUmlsNhFzLPimHQZZOE;

				private TempListPool.TList<ActionElementMap> gGjNhhvCMAfjStnbxmYxfHUKGMvv;

				private List<ActionElementMap>.Enumerator WfdpdKfoCSNAWrGSsArIDlaHyLJE;

				ActionElementMap IEnumerator<ActionElementMap>.Current
				{
					[DebuggerHidden]
					get
					{
						return NqaAJaZVNuFuTLOYNaTbmOKnKbDw;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return NqaAJaZVNuFuTLOYNaTbmOKnKbDw;
					}
				}

				[DebuggerHidden]
				public tjbDGEecyyhXLrBMocBGihgXqDmqA(int P_0)
				{
					qdniNMKmfrnwDjdodERFVjaubjoy = P_0;
					NyanqZPPWtoDTFtxpnOcVSXBYXOB = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					int num = qdniNMKmfrnwDjdodERFVjaubjoy;
					if ((uint)(num - -4) > 1u && num != 1)
					{
						return;
					}
					try
					{
						if (num != -4 && num != 1)
						{
							return;
						}
						try
						{
						}
						finally
						{
							AxgGhKctVrRbuTvxCDTnlmSMFGqgA();
						}
					}
					finally
					{
						PslJnVvrNUIdmxbXbwtEAdhzDKPx();
					}
				}

				private bool MoveNext()
				{
					try
					{
						int num = qdniNMKmfrnwDjdodERFVjaubjoy;
						MapHelper mapHelper = gjzsKoCbCkbpdAHqGmCFCIbAqqZBA;
						if (num != 0)
						{
							if (num != 1)
							{
								return false;
							}
							qdniNMKmfrnwDjdodERFVjaubjoy = -4;
							goto IL_017c;
						}
						qdniNMKmfrnwDjdodERFVjaubjoy = -1;
						if (OQNoAQgyQXnofwhCLEhJfmxRKapib == null)
						{
							return false;
						}
						Controller controller = OQNoAQgyQXnofwhCLEhJfmxRKapib.controller;
						if (controller == null)
						{
							return false;
						}
						pNrqAxRXTFHMJFlbYKNUcoJdNCEO = mapHelper.yfZPVbkoNrPFYlhxRcQrxPzDLvft.QecjgvgRSXuPhnYvNrbSsHRqQwjg.AXLlayIlTwJqJNaNzeKccuszIcODb(controller.type);
						MHedrGAyamvnLKSUYMadFrxCJmYjA = pNrqAxRXTFHMJFlbYKNUcoJdNCEO.rphZqyUfbdoINyXndGfDbQaiIHFM();
						rVntRtmsxMCpRNlTfreCeCybieSG = 0;
						goto IL_01e4;
						IL_017c:
						if (WfdpdKfoCSNAWrGSsArIDlaHyLJE.MoveNext())
						{
							ActionElementMap current = WfdpdKfoCSNAWrGSsArIDlaHyLJE.Current;
							NqaAJaZVNuFuTLOYNaTbmOKnKbDw = current;
							qdniNMKmfrnwDjdodERFVjaubjoy = 1;
							return true;
						}
						AxgGhKctVrRbuTvxCDTnlmSMFGqgA();
						WfdpdKfoCSNAWrGSsArIDlaHyLJE = default;
						PslJnVvrNUIdmxbXbwtEAdhzDKPx();
						gGjNhhvCMAfjStnbxmYxfHUKGMvv = null;
						goto IL_01a8;
						IL_01e4:
						if (rVntRtmsxMCpRNlTfreCeCybieSG < MHedrGAyamvnLKSUYMadFrxCJmYjA)
						{
							FsyiqPdJeSfbLIuiSYvjZeDpZMzW fsyiqPdJeSfbLIuiSYvjZeDpZMzW = pNrqAxRXTFHMJFlbYKNUcoJdNCEO.gmqWnmpZMnASuZpGLEqmJcwgXIqMA(rVntRtmsxMCpRNlTfreCeCybieSG).ycfaKniCLOzZqlQviANrBfbEZIlRA();
							fsyiqPdJeSfbLIuiSYvjZeDpZMzW.ejOOZrUqJLRyRGoRofwTThHfNEkF();
							jmteFaHCyLDGHAQQxdaoImpKAIlbb = fsyiqPdJeSfbLIuiSYvjZeDpZMzW.yNPIkhCQyqKjUMKWnmnPppLEAttk();
							kWfbTLkGBsTkOAqAbxOqREBAObhBA = jmteFaHCyLDGHAQQxdaoImpKAIlbb.Count;
							SvOijLKlJZUmlsNhFzLPimHQZZOE = 0;
							goto IL_01ba;
						}
						return false;
						IL_01ba:
						if (SvOijLKlJZUmlsNhFzLPimHQZZOE < kWfbTLkGBsTkOAqAbxOqREBAObhBA)
						{
							ControllerMap controllerMap = jmteFaHCyLDGHAQQxdaoImpKAIlbb[SvOijLKlJZUmlsNhFzLPimHQZZOE];
							if (!MKBTNBWigpDZCzfwAelozASIFGhEA || controllerMap.enabled)
							{
								gGjNhhvCMAfjStnbxmYxfHUKGMvv = TempListPool.GetTList<ActionElementMap>();
								qdniNMKmfrnwDjdodERFVjaubjoy = -3;
								List<ActionElementMap> list = gGjNhhvCMAfjStnbxmYxfHUKGMvv.list;
								controllerMap.AQsAVNZYhsajiONJBaCUyUaUYtSD(OQNoAQgyQXnofwhCLEhJfmxRKapib, KyARQBGkcZTwnVounbkaxVgVALfB, dHgrzzvqKbPZRBGbzNwPtoLqrbYd, MKBTNBWigpDZCzfwAelozASIFGhEA, list, true, out var _);
								WfdpdKfoCSNAWrGSsArIDlaHyLJE = list.GetEnumerator();
								qdniNMKmfrnwDjdodERFVjaubjoy = -4;
								goto IL_017c;
							}
							goto IL_01a8;
						}
						jmteFaHCyLDGHAQQxdaoImpKAIlbb = null;
						rVntRtmsxMCpRNlTfreCeCybieSG++;
						goto IL_01e4;
						IL_01a8:
						SvOijLKlJZUmlsNhFzLPimHQZZOE++;
						goto IL_01ba;
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

				private void PslJnVvrNUIdmxbXbwtEAdhzDKPx()
				{
					qdniNMKmfrnwDjdodERFVjaubjoy = -1;
					if (gGjNhhvCMAfjStnbxmYxfHUKGMvv != null)
					{
						((IDisposable)gGjNhhvCMAfjStnbxmYxfHUKGMvv).Dispose();
					}
				}

				private void AxgGhKctVrRbuTvxCDTnlmSMFGqgA()
				{
					qdniNMKmfrnwDjdodERFVjaubjoy = -3;
					((IDisposable)WfdpdKfoCSNAWrGSsArIDlaHyLJE/*cast due to constrained. prefix*/).Dispose();
				}

				[DebuggerHidden]
				void IEnumerator.Reset()
				{
					throw new NotSupportedException();
				}

				[DebuggerHidden]
				IEnumerator<ActionElementMap> IEnumerable<ActionElementMap>.GetEnumerator()
				{
					tjbDGEecyyhXLrBMocBGihgXqDmqA tjbDGEecyyhXLrBMocBGihgXqDmqA2;
					if (qdniNMKmfrnwDjdodERFVjaubjoy == -2 && NyanqZPPWtoDTFtxpnOcVSXBYXOB == Environment.CurrentManagedThreadId)
					{
						qdniNMKmfrnwDjdodERFVjaubjoy = 0;
						tjbDGEecyyhXLrBMocBGihgXqDmqA2 = this;
					}
					else
					{
						tjbDGEecyyhXLrBMocBGihgXqDmqA2 = new tjbDGEecyyhXLrBMocBGihgXqDmqA(0);
						tjbDGEecyyhXLrBMocBGihgXqDmqA2.gjzsKoCbCkbpdAHqGmCFCIbAqqZBA = gjzsKoCbCkbpdAHqGmCFCIbAqqZBA;
					}
					tjbDGEecyyhXLrBMocBGihgXqDmqA2.OQNoAQgyQXnofwhCLEhJfmxRKapib = tskWNCmLvMxMDkyyBpoCuBxIVtlF;
					tjbDGEecyyhXLrBMocBGihgXqDmqA2.KyARQBGkcZTwnVounbkaxVgVALfB = rNgmlHzspLNBLlxgQMxwSeguwryP;
					tjbDGEecyyhXLrBMocBGihgXqDmqA2.dHgrzzvqKbPZRBGbzNwPtoLqrbYd = XpvklkJrwEYQutWuGWwjWYIijYjb;
					tjbDGEecyyhXLrBMocBGihgXqDmqA2.MKBTNBWigpDZCzfwAelozASIFGhEA = LVntSLbIXqeTzMixLCylBoDuYDrC;
					return tjbDGEecyyhXLrBMocBGihgXqDmqA2;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
				}
			}

			private sealed class kMKUAWHGtWBqjqGgousCYPsuKfWN : IEnumerable<ControllerMap>, IEnumerable, IEnumerator<ControllerMap>, IEnumerator, IDisposable
			{
				private int XgnFZQblxmYsQbRKZVlvgOavHEfwA;

				private ControllerMap DlLYlyQxxJlaFqeOGFCNjeIyeiCt;

				private int UTACfdMpHjLrWHEqLpEwoGbxeFccA;

				public MapHelper qlXwJMwHhdyQfVTNwGDKYDExtLzM;

				private int bwsECYyTqpOMImexJyajnmxrdbZJ;

				private int IWVKHHtPmKursmuXRFsnyoePbJcQ;

				private HENtlJpbLTfyvGNBdnYOTBUpGwmPA AtbbrbJQxRKIoPeWBtDOLsemlzFjA;

				private int MEbIFgBRPswnYOvfUweHZZccuhBP;

				private int OMOMUVquiuNTSuOOfjKDKAJqyJHh;

				private FsyiqPdJeSfbLIuiSYvjZeDpZMzW IqMQoOxhNOFoAoiVyeKfdWYgRtcAA;

				private int uQNYFJEMRXkTHAEACmDeiAuatnYs;

				private int KDjNVlAddeCeJXtfaoIYxbCiXhtF;

				ControllerMap IEnumerator<ControllerMap>.Current
				{
					[DebuggerHidden]
					get
					{
						return DlLYlyQxxJlaFqeOGFCNjeIyeiCt;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return DlLYlyQxxJlaFqeOGFCNjeIyeiCt;
					}
				}

				[DebuggerHidden]
				public kMKUAWHGtWBqjqGgousCYPsuKfWN(int P_0)
				{
					XgnFZQblxmYsQbRKZVlvgOavHEfwA = P_0;
					UTACfdMpHjLrWHEqLpEwoGbxeFccA = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int xgnFZQblxmYsQbRKZVlvgOavHEfwA = XgnFZQblxmYsQbRKZVlvgOavHEfwA;
					MapHelper mapHelper = qlXwJMwHhdyQfVTNwGDKYDExtLzM;
					if (xgnFZQblxmYsQbRKZVlvgOavHEfwA != 0)
					{
						if (xgnFZQblxmYsQbRKZVlvgOavHEfwA != 1)
						{
							return false;
						}
						XgnFZQblxmYsQbRKZVlvgOavHEfwA = -1;
						KDjNVlAddeCeJXtfaoIYxbCiXhtF++;
						goto IL_0104;
					}
					XgnFZQblxmYsQbRKZVlvgOavHEfwA = -1;
					if (ReInput._id != mapHelper.azGvCmHxftPofYbbgHwfQfhmWSgV)
					{
						ReInput.CheckInitialized(mapHelper.azGvCmHxftPofYbbgHwfQfhmWSgV);
						return false;
					}
					bwsECYyTqpOMImexJyajnmxrdbZJ = mapHelper.yfZPVbkoNrPFYlhxRcQrxPzDLvft.QecjgvgRSXuPhnYvNrbSsHRqQwjg.KzSWyhVFpKvuMAleUEiVntIEyGZD;
					IWVKHHtPmKursmuXRFsnyoePbJcQ = 0;
					goto IL_0151;
					IL_0104:
					if (KDjNVlAddeCeJXtfaoIYxbCiXhtF < uQNYFJEMRXkTHAEACmDeiAuatnYs)
					{
						DlLYlyQxxJlaFqeOGFCNjeIyeiCt = IqMQoOxhNOFoAoiVyeKfdWYgRtcAA.QIeXsLdCiAXGGxCgarjGtHyqkDbM(KDjNVlAddeCeJXtfaoIYxbCiXhtF);
						XgnFZQblxmYsQbRKZVlvgOavHEfwA = 1;
						return true;
					}
					IqMQoOxhNOFoAoiVyeKfdWYgRtcAA = null;
					OMOMUVquiuNTSuOOfjKDKAJqyJHh++;
					goto IL_0129;
					IL_0129:
					if (OMOMUVquiuNTSuOOfjKDKAJqyJHh < MEbIFgBRPswnYOvfUweHZZccuhBP)
					{
						IqMQoOxhNOFoAoiVyeKfdWYgRtcAA = AtbbrbJQxRKIoPeWBtDOLsemlzFjA.gmqWnmpZMnASuZpGLEqmJcwgXIqMA(OMOMUVquiuNTSuOOfjKDKAJqyJHh).ycfaKniCLOzZqlQviANrBfbEZIlRA();
						uQNYFJEMRXkTHAEACmDeiAuatnYs = IqMQoOxhNOFoAoiVyeKfdWYgRtcAA.ejOOZrUqJLRyRGoRofwTThHfNEkF();
						KDjNVlAddeCeJXtfaoIYxbCiXhtF = 0;
						goto IL_0104;
					}
					AtbbrbJQxRKIoPeWBtDOLsemlzFjA = null;
					IWVKHHtPmKursmuXRFsnyoePbJcQ++;
					goto IL_0151;
					IL_0151:
					if (IWVKHHtPmKursmuXRFsnyoePbJcQ < bwsECYyTqpOMImexJyajnmxrdbZJ)
					{
						AtbbrbJQxRKIoPeWBtDOLsemlzFjA = mapHelper.yfZPVbkoNrPFYlhxRcQrxPzDLvft.QecjgvgRSXuPhnYvNrbSsHRqQwjg.AMmiEUMJUxmCKCltvrDeLoaPvEGE(IWVKHHtPmKursmuXRFsnyoePbJcQ);
						MEbIFgBRPswnYOvfUweHZZccuhBP = AtbbrbJQxRKIoPeWBtDOLsemlzFjA.rphZqyUfbdoINyXndGfDbQaiIHFM();
						OMOMUVquiuNTSuOOfjKDKAJqyJHh = 0;
						goto IL_0129;
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
				IEnumerator<ControllerMap> IEnumerable<ControllerMap>.GetEnumerator()
				{
					kMKUAWHGtWBqjqGgousCYPsuKfWN kMKUAWHGtWBqjqGgousCYPsuKfWN2;
					if (XgnFZQblxmYsQbRKZVlvgOavHEfwA == -2 && UTACfdMpHjLrWHEqLpEwoGbxeFccA == Environment.CurrentManagedThreadId)
					{
						XgnFZQblxmYsQbRKZVlvgOavHEfwA = 0;
						kMKUAWHGtWBqjqGgousCYPsuKfWN2 = this;
					}
					else
					{
						kMKUAWHGtWBqjqGgousCYPsuKfWN2 = new kMKUAWHGtWBqjqGgousCYPsuKfWN(0);
						kMKUAWHGtWBqjqGgousCYPsuKfWN2.qlXwJMwHhdyQfVTNwGDKYDExtLzM = qlXwJMwHhdyQfVTNwGDKYDExtLzM;
					}
					return kMKUAWHGtWBqjqGgousCYPsuKfWN2;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<ControllerMap>)this).GetEnumerator();
				}
			}

			private sealed class rPLoRrHprRobINOKhcGnKdEqmWJcb<_0001> : IEnumerable<_0001>, IEnumerable, IEnumerator<_0001>, IEnumerator, IDisposable where _0001 : ControllerMap
			{
				private int QkdEpZZzKmQoXOerscVCaygOmfvT;

				private _0001 GrdAbhMmBxIfabASKjFTPBXcKHqbb;

				private int ZCBvkPgClXFUUSchFRSwhgZFGEqK;

				public MapHelper SHSGCEKqMljccEzDjEPyVjjZSedB;

				private HENtlJpbLTfyvGNBdnYOTBUpGwmPA dzjvzbbEdQHQooeBgjcDKtkYovAeb;

				private int yrNYcYHgKnOJdCCqCTQXbefnCRhiA;

				private int rqXCqACKWsWbIdYxuQorlfezAedb;

				private FsyiqPdJeSfbLIuiSYvjZeDpZMzW EYNbnNuVexESdqXoMeQKIXYmopRq;

				private int ZUlFKVViHUhGypagDpLBoBlcdhWM;

				private int CgiEGWLdwzVuQBWVQpygxtaBYQXE;

				private int ONgBkIzeWFsKyWJaizvxKMkVGoHL;

				private int KucldrAWOaNKgAlNbBwpGwzIZjKCA;

				_0001 IEnumerator<_0001>.Current
				{
					[DebuggerHidden]
					get
					{
						return System_002ECollections_002EGeneric_002EIEnumerator_003CT_003E_002Eget_Current();
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return GrdAbhMmBxIfabASKjFTPBXcKHqbb;
					}
				}

				[DebuggerHidden]
				public rPLoRrHprRobINOKhcGnKdEqmWJcb(int P_0)
				{
					QkdEpZZzKmQoXOerscVCaygOmfvT = P_0;
					ZCBvkPgClXFUUSchFRSwhgZFGEqK = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int qkdEpZZzKmQoXOerscVCaygOmfvT = QkdEpZZzKmQoXOerscVCaygOmfvT;
					MapHelper sHSGCEKqMljccEzDjEPyVjjZSedB = SHSGCEKqMljccEzDjEPyVjjZSedB;
					switch (qkdEpZZzKmQoXOerscVCaygOmfvT)
					{
					default:
						return false;
					case 0:
					{
						QkdEpZZzKmQoXOerscVCaygOmfvT = -1;
						if (ReInput._id != sHSGCEKqMljccEzDjEPyVjjZSedB.azGvCmHxftPofYbbgHwfQfhmWSgV)
						{
							ReInput.CheckInitialized(sHSGCEKqMljccEzDjEPyVjjZSedB.azGvCmHxftPofYbbgHwfQfhmWSgV);
							return false;
						}
						if (IyPmashUlRgIygDiHFyDZHZmauql.ogCvDDYZbiIuQyBzRHlCQIrYWSXb<_0001>(out var controllerType))
						{
							dzjvzbbEdQHQooeBgjcDKtkYovAeb = sHSGCEKqMljccEzDjEPyVjjZSedB.yfZPVbkoNrPFYlhxRcQrxPzDLvft.QecjgvgRSXuPhnYvNrbSsHRqQwjg.AXLlayIlTwJqJNaNzeKccuszIcODb(controllerType);
							yrNYcYHgKnOJdCCqCTQXbefnCRhiA = dzjvzbbEdQHQooeBgjcDKtkYovAeb.rphZqyUfbdoINyXndGfDbQaiIHFM();
							rqXCqACKWsWbIdYxuQorlfezAedb = 0;
							goto IL_011b;
						}
						yrNYcYHgKnOJdCCqCTQXbefnCRhiA = sHSGCEKqMljccEzDjEPyVjjZSedB.yfZPVbkoNrPFYlhxRcQrxPzDLvft.QecjgvgRSXuPhnYvNrbSsHRqQwjg.KzSWyhVFpKvuMAleUEiVntIEyGZD;
						rqXCqACKWsWbIdYxuQorlfezAedb = 0;
						goto IL_0264;
					}
					case 1:
						QkdEpZZzKmQoXOerscVCaygOmfvT = -1;
						CgiEGWLdwzVuQBWVQpygxtaBYQXE++;
						goto IL_00f6;
					case 2:
						{
							QkdEpZZzKmQoXOerscVCaygOmfvT = -1;
							goto IL_0207;
						}
						IL_0207:
						KucldrAWOaNKgAlNbBwpGwzIZjKCA++;
						goto IL_0217;
						IL_0264:
						if (rqXCqACKWsWbIdYxuQorlfezAedb >= yrNYcYHgKnOJdCCqCTQXbefnCRhiA)
						{
							break;
						}
						dzjvzbbEdQHQooeBgjcDKtkYovAeb = sHSGCEKqMljccEzDjEPyVjjZSedB.yfZPVbkoNrPFYlhxRcQrxPzDLvft.QecjgvgRSXuPhnYvNrbSsHRqQwjg.AMmiEUMJUxmCKCltvrDeLoaPvEGE(rqXCqACKWsWbIdYxuQorlfezAedb);
						ZUlFKVViHUhGypagDpLBoBlcdhWM = dzjvzbbEdQHQooeBgjcDKtkYovAeb.rphZqyUfbdoINyXndGfDbQaiIHFM();
						CgiEGWLdwzVuQBWVQpygxtaBYQXE = 0;
						goto IL_023c;
						IL_011b:
						if (rqXCqACKWsWbIdYxuQorlfezAedb < yrNYcYHgKnOJdCCqCTQXbefnCRhiA)
						{
							EYNbnNuVexESdqXoMeQKIXYmopRq = dzjvzbbEdQHQooeBgjcDKtkYovAeb.gmqWnmpZMnASuZpGLEqmJcwgXIqMA(rqXCqACKWsWbIdYxuQorlfezAedb).ycfaKniCLOzZqlQviANrBfbEZIlRA();
							ZUlFKVViHUhGypagDpLBoBlcdhWM = EYNbnNuVexESdqXoMeQKIXYmopRq.ejOOZrUqJLRyRGoRofwTThHfNEkF();
							CgiEGWLdwzVuQBWVQpygxtaBYQXE = 0;
							goto IL_00f6;
						}
						dzjvzbbEdQHQooeBgjcDKtkYovAeb = null;
						break;
						IL_0217:
						if (KucldrAWOaNKgAlNbBwpGwzIZjKCA < ONgBkIzeWFsKyWJaizvxKMkVGoHL)
						{
							if (EYNbnNuVexESdqXoMeQKIXYmopRq.QIeXsLdCiAXGGxCgarjGtHyqkDbM(KucldrAWOaNKgAlNbBwpGwzIZjKCA) is _0001 grdAbhMmBxIfabASKjFTPBXcKHqbb)
							{
								GrdAbhMmBxIfabASKjFTPBXcKHqbb = grdAbhMmBxIfabASKjFTPBXcKHqbb;
								QkdEpZZzKmQoXOerscVCaygOmfvT = 2;
								return true;
							}
							goto IL_0207;
						}
						EYNbnNuVexESdqXoMeQKIXYmopRq = null;
						CgiEGWLdwzVuQBWVQpygxtaBYQXE++;
						goto IL_023c;
						IL_023c:
						if (CgiEGWLdwzVuQBWVQpygxtaBYQXE < ZUlFKVViHUhGypagDpLBoBlcdhWM)
						{
							EYNbnNuVexESdqXoMeQKIXYmopRq = dzjvzbbEdQHQooeBgjcDKtkYovAeb.gmqWnmpZMnASuZpGLEqmJcwgXIqMA(CgiEGWLdwzVuQBWVQpygxtaBYQXE).ycfaKniCLOzZqlQviANrBfbEZIlRA();
							ONgBkIzeWFsKyWJaizvxKMkVGoHL = EYNbnNuVexESdqXoMeQKIXYmopRq.ejOOZrUqJLRyRGoRofwTThHfNEkF();
							KucldrAWOaNKgAlNbBwpGwzIZjKCA = 0;
							goto IL_0217;
						}
						dzjvzbbEdQHQooeBgjcDKtkYovAeb = null;
						rqXCqACKWsWbIdYxuQorlfezAedb++;
						goto IL_0264;
						IL_00f6:
						if (CgiEGWLdwzVuQBWVQpygxtaBYQXE < ZUlFKVViHUhGypagDpLBoBlcdhWM)
						{
							GrdAbhMmBxIfabASKjFTPBXcKHqbb = (_0001)EYNbnNuVexESdqXoMeQKIXYmopRq.QIeXsLdCiAXGGxCgarjGtHyqkDbM(CgiEGWLdwzVuQBWVQpygxtaBYQXE);
							QkdEpZZzKmQoXOerscVCaygOmfvT = 1;
							return true;
						}
						EYNbnNuVexESdqXoMeQKIXYmopRq = null;
						rqXCqACKWsWbIdYxuQorlfezAedb++;
						goto IL_011b;
					}
					return false;
				}

				bool IEnumerator.MoveNext()
				{
					//ILSpy generated this explicit interface implementation from .override directive in MoveNext
					return this.MoveNext();
				}

				[DebuggerHidden]
				private _0001 System_002ECollections_002EGeneric_002EIEnumerator_003CT_003E_002Eget_Current()
				{
					return GrdAbhMmBxIfabASKjFTPBXcKHqbb;
				}

				[DebuggerHidden]
				void IEnumerator.Reset()
				{
					throw new NotSupportedException();
				}

				[DebuggerHidden]
				IEnumerator<_0001> IEnumerable<_0001>.GetEnumerator()
				{
					rPLoRrHprRobINOKhcGnKdEqmWJcb<_0001> rPLoRrHprRobINOKhcGnKdEqmWJcb2;
					if (QkdEpZZzKmQoXOerscVCaygOmfvT == -2 && ZCBvkPgClXFUUSchFRSwhgZFGEqK == Environment.CurrentManagedThreadId)
					{
						QkdEpZZzKmQoXOerscVCaygOmfvT = 0;
						rPLoRrHprRobINOKhcGnKdEqmWJcb2 = this;
					}
					else
					{
						rPLoRrHprRobINOKhcGnKdEqmWJcb2 = new rPLoRrHprRobINOKhcGnKdEqmWJcb<_0001>(0);
						rPLoRrHprRobINOKhcGnKdEqmWJcb2.SHSGCEKqMljccEzDjEPyVjjZSedB = SHSGCEKqMljccEzDjEPyVjjZSedB;
					}
					return rPLoRrHprRobINOKhcGnKdEqmWJcb2;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<_0001>)this).GetEnumerator();
				}
			}

			private sealed class JSPDqcnitJSROqCCdYurSRBRhryh : IEnumerable<ControllerMap>, IEnumerable, IEnumerator<ControllerMap>, IEnumerator, IDisposable
			{
				private int lsdkYlBAZIKLMQiAmutBlfavLmno;

				private ControllerMap mSWERXbgFtPFzQRNbIpFNuUakJxT;

				private int wzAaekemVWwjUNmwSTNRjfglhyrAb;

				public MapHelper HkZcoCjuBCdcLfsibveosObclgJQc;

				private ControllerType ZmVlYRwFRBgtJKIZfdpwvngJqXwi;

				public ControllerType WiDbgEIvTwnHUIkxADWfGCljFLlV;

				private HENtlJpbLTfyvGNBdnYOTBUpGwmPA WObEltCKKvyxvhnkGaCwheFcKULc;

				private int FFwJdamzklkyFaSjJuDnhIXnvJBL;

				private int YKPJhMVJFLqSeyJOtTVehYVzgGWo;

				private FsyiqPdJeSfbLIuiSYvjZeDpZMzW fGgggkgzHmhbfKQoOilexSjoQgipA;

				private int pkZsHYNRWzHPoGoFUScstUTBBhAb;

				private int IhRsMGsEIWdrQCYXGvVDJoOrYBzm;

				ControllerMap IEnumerator<ControllerMap>.Current
				{
					[DebuggerHidden]
					get
					{
						return mSWERXbgFtPFzQRNbIpFNuUakJxT;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return mSWERXbgFtPFzQRNbIpFNuUakJxT;
					}
				}

				[DebuggerHidden]
				public JSPDqcnitJSROqCCdYurSRBRhryh(int P_0)
				{
					lsdkYlBAZIKLMQiAmutBlfavLmno = P_0;
					wzAaekemVWwjUNmwSTNRjfglhyrAb = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int num = lsdkYlBAZIKLMQiAmutBlfavLmno;
					MapHelper hkZcoCjuBCdcLfsibveosObclgJQc = HkZcoCjuBCdcLfsibveosObclgJQc;
					if (num != 0)
					{
						if (num != 1)
						{
							return false;
						}
						lsdkYlBAZIKLMQiAmutBlfavLmno = -1;
						IhRsMGsEIWdrQCYXGvVDJoOrYBzm++;
						goto IL_00e2;
					}
					lsdkYlBAZIKLMQiAmutBlfavLmno = -1;
					if (ReInput._id != hkZcoCjuBCdcLfsibveosObclgJQc.azGvCmHxftPofYbbgHwfQfhmWSgV)
					{
						ReInput.CheckInitialized(hkZcoCjuBCdcLfsibveosObclgJQc.azGvCmHxftPofYbbgHwfQfhmWSgV);
						return false;
					}
					WObEltCKKvyxvhnkGaCwheFcKULc = hkZcoCjuBCdcLfsibveosObclgJQc.yfZPVbkoNrPFYlhxRcQrxPzDLvft.QecjgvgRSXuPhnYvNrbSsHRqQwjg.AXLlayIlTwJqJNaNzeKccuszIcODb(ZmVlYRwFRBgtJKIZfdpwvngJqXwi);
					FFwJdamzklkyFaSjJuDnhIXnvJBL = WObEltCKKvyxvhnkGaCwheFcKULc.rphZqyUfbdoINyXndGfDbQaiIHFM();
					YKPJhMVJFLqSeyJOtTVehYVzgGWo = 0;
					goto IL_0107;
					IL_00e2:
					if (IhRsMGsEIWdrQCYXGvVDJoOrYBzm < pkZsHYNRWzHPoGoFUScstUTBBhAb)
					{
						mSWERXbgFtPFzQRNbIpFNuUakJxT = fGgggkgzHmhbfKQoOilexSjoQgipA.QIeXsLdCiAXGGxCgarjGtHyqkDbM(IhRsMGsEIWdrQCYXGvVDJoOrYBzm);
						lsdkYlBAZIKLMQiAmutBlfavLmno = 1;
						return true;
					}
					fGgggkgzHmhbfKQoOilexSjoQgipA = null;
					YKPJhMVJFLqSeyJOtTVehYVzgGWo++;
					goto IL_0107;
					IL_0107:
					if (YKPJhMVJFLqSeyJOtTVehYVzgGWo < FFwJdamzklkyFaSjJuDnhIXnvJBL)
					{
						fGgggkgzHmhbfKQoOilexSjoQgipA = WObEltCKKvyxvhnkGaCwheFcKULc.gmqWnmpZMnASuZpGLEqmJcwgXIqMA(YKPJhMVJFLqSeyJOtTVehYVzgGWo).ycfaKniCLOzZqlQviANrBfbEZIlRA();
						pkZsHYNRWzHPoGoFUScstUTBBhAb = fGgggkgzHmhbfKQoOilexSjoQgipA.ejOOZrUqJLRyRGoRofwTThHfNEkF();
						IhRsMGsEIWdrQCYXGvVDJoOrYBzm = 0;
						goto IL_00e2;
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
				IEnumerator<ControllerMap> IEnumerable<ControllerMap>.GetEnumerator()
				{
					JSPDqcnitJSROqCCdYurSRBRhryh jSPDqcnitJSROqCCdYurSRBRhryh;
					if (lsdkYlBAZIKLMQiAmutBlfavLmno == -2 && wzAaekemVWwjUNmwSTNRjfglhyrAb == Environment.CurrentManagedThreadId)
					{
						lsdkYlBAZIKLMQiAmutBlfavLmno = 0;
						jSPDqcnitJSROqCCdYurSRBRhryh = this;
					}
					else
					{
						jSPDqcnitJSROqCCdYurSRBRhryh = new JSPDqcnitJSROqCCdYurSRBRhryh(0);
						jSPDqcnitJSROqCCdYurSRBRhryh.HkZcoCjuBCdcLfsibveosObclgJQc = HkZcoCjuBCdcLfsibveosObclgJQc;
					}
					jSPDqcnitJSROqCCdYurSRBRhryh.ZmVlYRwFRBgtJKIZfdpwvngJqXwi = WiDbgEIvTwnHUIkxADWfGCljFLlV;
					return jSPDqcnitJSROqCCdYurSRBRhryh;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<ControllerMap>)this).GetEnumerator();
				}
			}

			private sealed class WlscQYIYWSQGvKeTufwpTGPIVVYnA : IEnumerable<ControllerMap>, IEnumerable, IEnumerator<ControllerMap>, IEnumerator, IDisposable
			{
				private int eddsvrOOVAMPpSQnGZgNezDoLdPd;

				private ControllerMap rdSDBKoQAZIxhApJxFojJudEqSSeA;

				private int kvUWwaVCmpHqupFNlSAGOGfDuHXe;

				public MapHelper zEublVjILcckDAHMdppXdGrsjfGX;

				private int ZVOuNzuMzZyRLkqtnnWDGYubnetu;

				public int zRSiPsUoccgDvmgdxqYTuKxDtRdW;

				private int mhpUAysIQcnFKbkrsMGVJXYiIeqp;

				private int GBgArgjxODIKdjtbBJtFRbMqWFzbA;

				private HENtlJpbLTfyvGNBdnYOTBUpGwmPA LjKEnIndJlCyGtAoxTLzNlxrPJQE;

				private int sbRxmYyfteNnXlGjUFafzRdmGNPIA;

				private int NofRspufNdtTsKfdKatBCmGhOvvpA;

				private FsyiqPdJeSfbLIuiSYvjZeDpZMzW zrupzBXZmEwslFWtiFzyfiMChAbU;

				private int jWBpYDJxNCUPGYVKgwcsGApCmWeB;

				private int YttZYHHwOFEZtWAtitDRCSFkxYAt;

				ControllerMap IEnumerator<ControllerMap>.Current
				{
					[DebuggerHidden]
					get
					{
						return rdSDBKoQAZIxhApJxFojJudEqSSeA;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return rdSDBKoQAZIxhApJxFojJudEqSSeA;
					}
				}

				[DebuggerHidden]
				public WlscQYIYWSQGvKeTufwpTGPIVVYnA(int P_0)
				{
					eddsvrOOVAMPpSQnGZgNezDoLdPd = P_0;
					kvUWwaVCmpHqupFNlSAGOGfDuHXe = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int num = eddsvrOOVAMPpSQnGZgNezDoLdPd;
					MapHelper mapHelper = zEublVjILcckDAHMdppXdGrsjfGX;
					if (num != 0)
					{
						if (num != 1)
						{
							return false;
						}
						eddsvrOOVAMPpSQnGZgNezDoLdPd = -1;
						goto IL_0104;
					}
					eddsvrOOVAMPpSQnGZgNezDoLdPd = -1;
					if (ReInput._id != mapHelper.azGvCmHxftPofYbbgHwfQfhmWSgV)
					{
						ReInput.CheckInitialized(mapHelper.azGvCmHxftPofYbbgHwfQfhmWSgV);
						return false;
					}
					mhpUAysIQcnFKbkrsMGVJXYiIeqp = mapHelper.yfZPVbkoNrPFYlhxRcQrxPzDLvft.QecjgvgRSXuPhnYvNrbSsHRqQwjg.KzSWyhVFpKvuMAleUEiVntIEyGZD;
					GBgArgjxODIKdjtbBJtFRbMqWFzbA = 0;
					goto IL_0161;
					IL_0104:
					YttZYHHwOFEZtWAtitDRCSFkxYAt++;
					goto IL_0114;
					IL_0161:
					if (GBgArgjxODIKdjtbBJtFRbMqWFzbA < mhpUAysIQcnFKbkrsMGVJXYiIeqp)
					{
						LjKEnIndJlCyGtAoxTLzNlxrPJQE = mapHelper.yfZPVbkoNrPFYlhxRcQrxPzDLvft.QecjgvgRSXuPhnYvNrbSsHRqQwjg.AMmiEUMJUxmCKCltvrDeLoaPvEGE(GBgArgjxODIKdjtbBJtFRbMqWFzbA);
						sbRxmYyfteNnXlGjUFafzRdmGNPIA = LjKEnIndJlCyGtAoxTLzNlxrPJQE.rphZqyUfbdoINyXndGfDbQaiIHFM();
						NofRspufNdtTsKfdKatBCmGhOvvpA = 0;
						goto IL_0139;
					}
					return false;
					IL_0114:
					if (YttZYHHwOFEZtWAtitDRCSFkxYAt < jWBpYDJxNCUPGYVKgwcsGApCmWeB)
					{
						ControllerMap controllerMap = zrupzBXZmEwslFWtiFzyfiMChAbU.QIeXsLdCiAXGGxCgarjGtHyqkDbM(YttZYHHwOFEZtWAtitDRCSFkxYAt);
						if (controllerMap.categoryId == ZVOuNzuMzZyRLkqtnnWDGYubnetu)
						{
							rdSDBKoQAZIxhApJxFojJudEqSSeA = controllerMap;
							eddsvrOOVAMPpSQnGZgNezDoLdPd = 1;
							return true;
						}
						goto IL_0104;
					}
					zrupzBXZmEwslFWtiFzyfiMChAbU = null;
					NofRspufNdtTsKfdKatBCmGhOvvpA++;
					goto IL_0139;
					IL_0139:
					if (NofRspufNdtTsKfdKatBCmGhOvvpA < sbRxmYyfteNnXlGjUFafzRdmGNPIA)
					{
						zrupzBXZmEwslFWtiFzyfiMChAbU = LjKEnIndJlCyGtAoxTLzNlxrPJQE.gmqWnmpZMnASuZpGLEqmJcwgXIqMA(NofRspufNdtTsKfdKatBCmGhOvvpA).ycfaKniCLOzZqlQviANrBfbEZIlRA();
						jWBpYDJxNCUPGYVKgwcsGApCmWeB = zrupzBXZmEwslFWtiFzyfiMChAbU.ejOOZrUqJLRyRGoRofwTThHfNEkF();
						YttZYHHwOFEZtWAtitDRCSFkxYAt = 0;
						goto IL_0114;
					}
					LjKEnIndJlCyGtAoxTLzNlxrPJQE = null;
					GBgArgjxODIKdjtbBJtFRbMqWFzbA++;
					goto IL_0161;
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
				IEnumerator<ControllerMap> IEnumerable<ControllerMap>.GetEnumerator()
				{
					WlscQYIYWSQGvKeTufwpTGPIVVYnA wlscQYIYWSQGvKeTufwpTGPIVVYnA;
					if (eddsvrOOVAMPpSQnGZgNezDoLdPd == -2 && kvUWwaVCmpHqupFNlSAGOGfDuHXe == Environment.CurrentManagedThreadId)
					{
						eddsvrOOVAMPpSQnGZgNezDoLdPd = 0;
						wlscQYIYWSQGvKeTufwpTGPIVVYnA = this;
					}
					else
					{
						wlscQYIYWSQGvKeTufwpTGPIVVYnA = new WlscQYIYWSQGvKeTufwpTGPIVVYnA(0);
						wlscQYIYWSQGvKeTufwpTGPIVVYnA.zEublVjILcckDAHMdppXdGrsjfGX = zEublVjILcckDAHMdppXdGrsjfGX;
					}
					wlscQYIYWSQGvKeTufwpTGPIVVYnA.ZVOuNzuMzZyRLkqtnnWDGYubnetu = zRSiPsUoccgDvmgdxqYTuKxDtRdW;
					return wlscQYIYWSQGvKeTufwpTGPIVVYnA;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<ControllerMap>)this).GetEnumerator();
				}
			}

			private sealed class AALJkHCbVyFmfLjqbLGfRgqnQdXs<_0001> : IEnumerable<_0001>, IEnumerable, IEnumerator<_0001>, IEnumerator, IDisposable where _0001 : ControllerMap
			{
				private int aebuIvcOFVuApriNJeyqbKCcFgJx;

				private _0001 GOvbnOzaxNRUlFrDEpuugagqqKwN;

				private int lfQMTnjjEUPWcxCEJgMnvdjnhaxp;

				public MapHelper fkwaXQNmiBhsyobvCRTmGvwVkTpP;

				private int uCKvrUHXDAJtammtFVmmOiPgOKDw;

				public int OMVUUcDliEjVpaDELVKrJWPfLYYeA;

				private HENtlJpbLTfyvGNBdnYOTBUpGwmPA YIrNvkOnmrfaRdrZdhipFWpCbPEOb;

				private int OnCUEFLykmKCwLzHWAMVkKNkERFd;

				private int EoiVTZnZkJkXmqADoTlSmFsXKvGA;

				private FsyiqPdJeSfbLIuiSYvjZeDpZMzW kOJxZLoGwGjFiWrWXpOlLSWPQfwj;

				private int fUACfcYsUaPGuaboHjyIrlzWaCMj;

				private int MCxpFUbiEnDgJEYOgnacVBomxQaPA;

				private int FSVxLjJnJgwMJxYPuHgyvbUoxebg;

				private int KkmKnggonfHxWrlmzHByXbftfGOCA;

				_0001 IEnumerator<_0001>.Current
				{
					[DebuggerHidden]
					get
					{
						return System_002ECollections_002EGeneric_002EIEnumerator_003CT_003E_002Eget_Current();
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return GOvbnOzaxNRUlFrDEpuugagqqKwN;
					}
				}

				[DebuggerHidden]
				public AALJkHCbVyFmfLjqbLGfRgqnQdXs(int P_0)
				{
					aebuIvcOFVuApriNJeyqbKCcFgJx = P_0;
					lfQMTnjjEUPWcxCEJgMnvdjnhaxp = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int num = aebuIvcOFVuApriNJeyqbKCcFgJx;
					MapHelper mapHelper = fkwaXQNmiBhsyobvCRTmGvwVkTpP;
					switch (num)
					{
					default:
						return false;
					case 0:
					{
						aebuIvcOFVuApriNJeyqbKCcFgJx = -1;
						if (ReInput._id != mapHelper.azGvCmHxftPofYbbgHwfQfhmWSgV)
						{
							ReInput.CheckInitialized(mapHelper.azGvCmHxftPofYbbgHwfQfhmWSgV);
							return false;
						}
						if (IyPmashUlRgIygDiHFyDZHZmauql.ogCvDDYZbiIuQyBzRHlCQIrYWSXb<_0001>(out var _))
						{
							YIrNvkOnmrfaRdrZdhipFWpCbPEOb = mapHelper.vjFJSXxeUsObgcxatjFDQDpTwlTs<_0001>();
							OnCUEFLykmKCwLzHWAMVkKNkERFd = YIrNvkOnmrfaRdrZdhipFWpCbPEOb.rphZqyUfbdoINyXndGfDbQaiIHFM();
							EoiVTZnZkJkXmqADoTlSmFsXKvGA = 0;
							goto IL_0124;
						}
						OnCUEFLykmKCwLzHWAMVkKNkERFd = mapHelper.yfZPVbkoNrPFYlhxRcQrxPzDLvft.QecjgvgRSXuPhnYvNrbSsHRqQwjg.KzSWyhVFpKvuMAleUEiVntIEyGZD;
						EoiVTZnZkJkXmqADoTlSmFsXKvGA = 0;
						goto IL_0287;
					}
					case 1:
						aebuIvcOFVuApriNJeyqbKCcFgJx = -1;
						goto IL_00eb;
					case 2:
						{
							aebuIvcOFVuApriNJeyqbKCcFgJx = -1;
							goto IL_0224;
						}
						IL_0224:
						KkmKnggonfHxWrlmzHByXbftfGOCA++;
						goto IL_0236;
						IL_00eb:
						MCxpFUbiEnDgJEYOgnacVBomxQaPA++;
						goto IL_00fd;
						IL_0124:
						if (EoiVTZnZkJkXmqADoTlSmFsXKvGA < OnCUEFLykmKCwLzHWAMVkKNkERFd)
						{
							kOJxZLoGwGjFiWrWXpOlLSWPQfwj = YIrNvkOnmrfaRdrZdhipFWpCbPEOb.gmqWnmpZMnASuZpGLEqmJcwgXIqMA(EoiVTZnZkJkXmqADoTlSmFsXKvGA).ycfaKniCLOzZqlQviANrBfbEZIlRA();
							fUACfcYsUaPGuaboHjyIrlzWaCMj = kOJxZLoGwGjFiWrWXpOlLSWPQfwj.ejOOZrUqJLRyRGoRofwTThHfNEkF();
							MCxpFUbiEnDgJEYOgnacVBomxQaPA = 0;
							goto IL_00fd;
						}
						YIrNvkOnmrfaRdrZdhipFWpCbPEOb = null;
						break;
						IL_0287:
						if (EoiVTZnZkJkXmqADoTlSmFsXKvGA >= OnCUEFLykmKCwLzHWAMVkKNkERFd)
						{
							break;
						}
						YIrNvkOnmrfaRdrZdhipFWpCbPEOb = mapHelper.yfZPVbkoNrPFYlhxRcQrxPzDLvft.QecjgvgRSXuPhnYvNrbSsHRqQwjg.AMmiEUMJUxmCKCltvrDeLoaPvEGE(EoiVTZnZkJkXmqADoTlSmFsXKvGA);
						fUACfcYsUaPGuaboHjyIrlzWaCMj = YIrNvkOnmrfaRdrZdhipFWpCbPEOb.rphZqyUfbdoINyXndGfDbQaiIHFM();
						MCxpFUbiEnDgJEYOgnacVBomxQaPA = 0;
						goto IL_025d;
						IL_0236:
						if (KkmKnggonfHxWrlmzHByXbftfGOCA < FSVxLjJnJgwMJxYPuHgyvbUoxebg)
						{
							if (kOJxZLoGwGjFiWrWXpOlLSWPQfwj.QIeXsLdCiAXGGxCgarjGtHyqkDbM(KkmKnggonfHxWrlmzHByXbftfGOCA) is _0001 val && val.categoryId == uCKvrUHXDAJtammtFVmmOiPgOKDw)
							{
								GOvbnOzaxNRUlFrDEpuugagqqKwN = val;
								aebuIvcOFVuApriNJeyqbKCcFgJx = 2;
								return true;
							}
							goto IL_0224;
						}
						kOJxZLoGwGjFiWrWXpOlLSWPQfwj = null;
						MCxpFUbiEnDgJEYOgnacVBomxQaPA++;
						goto IL_025d;
						IL_00fd:
						if (MCxpFUbiEnDgJEYOgnacVBomxQaPA < fUACfcYsUaPGuaboHjyIrlzWaCMj)
						{
							ControllerMap controllerMap = kOJxZLoGwGjFiWrWXpOlLSWPQfwj.QIeXsLdCiAXGGxCgarjGtHyqkDbM(MCxpFUbiEnDgJEYOgnacVBomxQaPA);
							if (controllerMap.categoryId == uCKvrUHXDAJtammtFVmmOiPgOKDw)
							{
								GOvbnOzaxNRUlFrDEpuugagqqKwN = (_0001)controllerMap;
								aebuIvcOFVuApriNJeyqbKCcFgJx = 1;
								return true;
							}
							goto IL_00eb;
						}
						kOJxZLoGwGjFiWrWXpOlLSWPQfwj = null;
						EoiVTZnZkJkXmqADoTlSmFsXKvGA++;
						goto IL_0124;
						IL_025d:
						if (MCxpFUbiEnDgJEYOgnacVBomxQaPA < fUACfcYsUaPGuaboHjyIrlzWaCMj)
						{
							kOJxZLoGwGjFiWrWXpOlLSWPQfwj = YIrNvkOnmrfaRdrZdhipFWpCbPEOb.gmqWnmpZMnASuZpGLEqmJcwgXIqMA(MCxpFUbiEnDgJEYOgnacVBomxQaPA).ycfaKniCLOzZqlQviANrBfbEZIlRA();
							FSVxLjJnJgwMJxYPuHgyvbUoxebg = kOJxZLoGwGjFiWrWXpOlLSWPQfwj.ejOOZrUqJLRyRGoRofwTThHfNEkF();
							KkmKnggonfHxWrlmzHByXbftfGOCA = 0;
							goto IL_0236;
						}
						YIrNvkOnmrfaRdrZdhipFWpCbPEOb = null;
						EoiVTZnZkJkXmqADoTlSmFsXKvGA++;
						goto IL_0287;
					}
					return false;
				}

				bool IEnumerator.MoveNext()
				{
					//ILSpy generated this explicit interface implementation from .override directive in MoveNext
					return this.MoveNext();
				}

				[DebuggerHidden]
				private _0001 System_002ECollections_002EGeneric_002EIEnumerator_003CT_003E_002Eget_Current()
				{
					return GOvbnOzaxNRUlFrDEpuugagqqKwN;
				}

				[DebuggerHidden]
				void IEnumerator.Reset()
				{
					throw new NotSupportedException();
				}

				[DebuggerHidden]
				IEnumerator<_0001> IEnumerable<_0001>.GetEnumerator()
				{
					AALJkHCbVyFmfLjqbLGfRgqnQdXs<_0001> aALJkHCbVyFmfLjqbLGfRgqnQdXs;
					if (aebuIvcOFVuApriNJeyqbKCcFgJx == -2 && lfQMTnjjEUPWcxCEJgMnvdjnhaxp == Environment.CurrentManagedThreadId)
					{
						aebuIvcOFVuApriNJeyqbKCcFgJx = 0;
						aALJkHCbVyFmfLjqbLGfRgqnQdXs = this;
					}
					else
					{
						aALJkHCbVyFmfLjqbLGfRgqnQdXs = new AALJkHCbVyFmfLjqbLGfRgqnQdXs<_0001>(0);
						aALJkHCbVyFmfLjqbLGfRgqnQdXs.fkwaXQNmiBhsyobvCRTmGvwVkTpP = fkwaXQNmiBhsyobvCRTmGvwVkTpP;
					}
					aALJkHCbVyFmfLjqbLGfRgqnQdXs.uCKvrUHXDAJtammtFVmmOiPgOKDw = OMVUUcDliEjVpaDELVKrJWPfLYYeA;
					return aALJkHCbVyFmfLjqbLGfRgqnQdXs;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<_0001>)this).GetEnumerator();
				}
			}

			private sealed class sVWbKMcAoANFAnHPMLNHAhoWKWTtA : IEnumerable<ControllerMap>, IEnumerable, IEnumerator<ControllerMap>, IEnumerator, IDisposable
			{
				private int OHhbfDaqtDGwjprbCfbCyrrhhXSq;

				private ControllerMap HqvQkUsALyfjCIjLsgGJPnTfLDdzA;

				private int hvyokgGbUsbGLFCBHcaubLrzqfUoA;

				public MapHelper bMOaIznmRhEWMCtTYVBJbDnZEobvA;

				private ControllerType NgOEvRipijoatXOaOYxLZVKyLrBl;

				public ControllerType RdYCxjRtiXOmFTcWnhiQuTnFLGov;

				private int JcUAcEMJqCJmINOVfuXVEeYalRwA;

				public int YQmbVfixNRNiixhHOOqKCkvGkFUXb;

				private HENtlJpbLTfyvGNBdnYOTBUpGwmPA eaBAtLgdzKLKNErqYAOoajHJKvOqB;

				private int UvinFlskrobWrfyFXAJGVaEMyPTKA;

				private int QxQxHGFtxFpIeiUOxwGjRDDuItiP;

				private FsyiqPdJeSfbLIuiSYvjZeDpZMzW eQShdmcHtdqeLQmDHuDqBjvsoFRk;

				private int aYPLfJoUQpVCQPnJwQBzzphrGxGG;

				private int zgJELXTtTeGJYfAlWoLuKMZjpanQ;

				ControllerMap IEnumerator<ControllerMap>.Current
				{
					[DebuggerHidden]
					get
					{
						return HqvQkUsALyfjCIjLsgGJPnTfLDdzA;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return HqvQkUsALyfjCIjLsgGJPnTfLDdzA;
					}
				}

				[DebuggerHidden]
				public sVWbKMcAoANFAnHPMLNHAhoWKWTtA(int P_0)
				{
					OHhbfDaqtDGwjprbCfbCyrrhhXSq = P_0;
					hvyokgGbUsbGLFCBHcaubLrzqfUoA = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int oHhbfDaqtDGwjprbCfbCyrrhhXSq = OHhbfDaqtDGwjprbCfbCyrrhhXSq;
					MapHelper mapHelper = bMOaIznmRhEWMCtTYVBJbDnZEobvA;
					if (oHhbfDaqtDGwjprbCfbCyrrhhXSq != 0)
					{
						if (oHhbfDaqtDGwjprbCfbCyrrhhXSq != 1)
						{
							return false;
						}
						OHhbfDaqtDGwjprbCfbCyrrhhXSq = -1;
						goto IL_00e2;
					}
					OHhbfDaqtDGwjprbCfbCyrrhhXSq = -1;
					if (ReInput._id != mapHelper.azGvCmHxftPofYbbgHwfQfhmWSgV)
					{
						ReInput.CheckInitialized(mapHelper.azGvCmHxftPofYbbgHwfQfhmWSgV);
						return false;
					}
					eaBAtLgdzKLKNErqYAOoajHJKvOqB = mapHelper.yfZPVbkoNrPFYlhxRcQrxPzDLvft.QecjgvgRSXuPhnYvNrbSsHRqQwjg.AXLlayIlTwJqJNaNzeKccuszIcODb(NgOEvRipijoatXOaOYxLZVKyLrBl);
					UvinFlskrobWrfyFXAJGVaEMyPTKA = eaBAtLgdzKLKNErqYAOoajHJKvOqB.rphZqyUfbdoINyXndGfDbQaiIHFM();
					QxQxHGFtxFpIeiUOxwGjRDDuItiP = 0;
					goto IL_0117;
					IL_00f2:
					if (zgJELXTtTeGJYfAlWoLuKMZjpanQ < aYPLfJoUQpVCQPnJwQBzzphrGxGG)
					{
						ControllerMap controllerMap = eQShdmcHtdqeLQmDHuDqBjvsoFRk.QIeXsLdCiAXGGxCgarjGtHyqkDbM(zgJELXTtTeGJYfAlWoLuKMZjpanQ);
						if (controllerMap.categoryId == JcUAcEMJqCJmINOVfuXVEeYalRwA)
						{
							HqvQkUsALyfjCIjLsgGJPnTfLDdzA = controllerMap;
							OHhbfDaqtDGwjprbCfbCyrrhhXSq = 1;
							return true;
						}
						goto IL_00e2;
					}
					eQShdmcHtdqeLQmDHuDqBjvsoFRk = null;
					QxQxHGFtxFpIeiUOxwGjRDDuItiP++;
					goto IL_0117;
					IL_00e2:
					zgJELXTtTeGJYfAlWoLuKMZjpanQ++;
					goto IL_00f2;
					IL_0117:
					if (QxQxHGFtxFpIeiUOxwGjRDDuItiP < UvinFlskrobWrfyFXAJGVaEMyPTKA)
					{
						eQShdmcHtdqeLQmDHuDqBjvsoFRk = eaBAtLgdzKLKNErqYAOoajHJKvOqB.gmqWnmpZMnASuZpGLEqmJcwgXIqMA(QxQxHGFtxFpIeiUOxwGjRDDuItiP).ycfaKniCLOzZqlQviANrBfbEZIlRA();
						aYPLfJoUQpVCQPnJwQBzzphrGxGG = eQShdmcHtdqeLQmDHuDqBjvsoFRk.ejOOZrUqJLRyRGoRofwTThHfNEkF();
						zgJELXTtTeGJYfAlWoLuKMZjpanQ = 0;
						goto IL_00f2;
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
				IEnumerator<ControllerMap> IEnumerable<ControllerMap>.GetEnumerator()
				{
					sVWbKMcAoANFAnHPMLNHAhoWKWTtA sVWbKMcAoANFAnHPMLNHAhoWKWTtA2;
					if (OHhbfDaqtDGwjprbCfbCyrrhhXSq == -2 && hvyokgGbUsbGLFCBHcaubLrzqfUoA == Environment.CurrentManagedThreadId)
					{
						OHhbfDaqtDGwjprbCfbCyrrhhXSq = 0;
						sVWbKMcAoANFAnHPMLNHAhoWKWTtA2 = this;
					}
					else
					{
						sVWbKMcAoANFAnHPMLNHAhoWKWTtA2 = new sVWbKMcAoANFAnHPMLNHAhoWKWTtA(0);
						sVWbKMcAoANFAnHPMLNHAhoWKWTtA2.bMOaIznmRhEWMCtTYVBJbDnZEobvA = bMOaIznmRhEWMCtTYVBJbDnZEobvA;
					}
					sVWbKMcAoANFAnHPMLNHAhoWKWTtA2.JcUAcEMJqCJmINOVfuXVEeYalRwA = YQmbVfixNRNiixhHOOqKCkvGkFUXb;
					sVWbKMcAoANFAnHPMLNHAhoWKWTtA2.NgOEvRipijoatXOaOYxLZVKyLrBl = RdYCxjRtiXOmFTcWnhiQuTnFLGov;
					return sVWbKMcAoANFAnHPMLNHAhoWKWTtA2;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<ControllerMap>)this).GetEnumerator();
				}
			}

			private readonly spMACGdyRGKOkwMouVwTkXeYbAaQ JmxfICjvfCfvkNQSzlOFqdLOKwTiA;

			private Player PuQLxdcCtkdFdIyyRxAOPEXOAQlEA;

			private ControllerHelper yfZPVbkoNrPFYlhxRcQrxPzDLvft;

			private readonly ControllerMapEnabler nmGQCkHeZOXBWIMGVcCoDotNVNsA;

			private readonly ControllerMapLayoutManager dyQwamLeBQtCARIMQybeEfyCBeYGA;

			private readonly int azGvCmHxftPofYbbgHwfQfhmWSgV;

			public ControllerMapLayoutManager layoutManager => dyQwamLeBQtCARIMQybeEfyCBeYGA;

			public ControllerMapEnabler mapEnabler => nmGQCkHeZOXBWIMGVcCoDotNVNsA;

			public IList<InputBehavior> InputBehaviors
			{
				get
				{
					if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
					{
						ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
						return EmptyObjects<InputBehavior>.EmptyReadOnlyIListT;
					}
					return PuQLxdcCtkdFdIyyRxAOPEXOAQlEA.vUXRFQkaqtxZmDdZWniajedetQiF.izqLvkKDlFDzgajxGeteFupmnbXi(PuQLxdcCtkdFdIyyRxAOPEXOAQlEA.CgPagdlzMlCQxkbRTPOoePMzAXof);
				}
			}

			internal MapHelper(Player P_0, ControllerHelper P_1, spMACGdyRGKOkwMouVwTkXeYbAaQ P_2, ControllerMapLayoutManager.cUhsarZCgVkkiQMvHfbBJdlcDTAR P_3, ControllerMapEnabler.myTUEzsWwrinEGyZklokhnLFhKWB P_4)
			{
				azGvCmHxftPofYbbgHwfQfhmWSgV = ReInput.id;
				PuQLxdcCtkdFdIyyRxAOPEXOAQlEA = P_0;
				yfZPVbkoNrPFYlhxRcQrxPzDLvft = P_1;
				JmxfICjvfCfvkNQSzlOFqdLOKwTiA = P_2;
				nmGQCkHeZOXBWIMGVcCoDotNVNsA = new ControllerMapEnabler(P_0, P_4);
				dyQwamLeBQtCARIMQybeEfyCBeYGA = new ControllerMapLayoutManager(P_0, P_3);
				dyQwamLeBQtCARIMQybeEfyCBeYGA.kpNmQoKgmWzBsTcXLarOIjLlkVqo(nmGQCkHeZOXBWIMGVcCoDotNVNsA.Apply);
			}

			public void LoadMap<T>(int controllerId, int categoryId, int layoutId) where T : ControllerMap
			{
				JZHOxduGvNaeMvBROZleaOBhXjli<T>(controllerId, categoryId, layoutId, BoolOption.Default);
			}

			public void LoadMap<T>(int controllerId, string categoryName, string layoutName) where T : ControllerMap
			{
				ZmNCKKtEJReEPQfbhdRZDaoJpcPn<T>(controllerId, categoryName, layoutName, BoolOption.Default);
			}

			public void LoadMap(ControllerType controllerType, int controllerId, int categoryId, int layoutId)
			{
				IsWkCcPqglFizYcarEzvExMpmzwEA(controllerType, controllerId, categoryId, layoutId, BoolOption.Default);
			}

			public void LoadMap(ControllerType controllerType, int controllerId, string categoryName, string layoutName)
			{
				pZiRhBoJeKNdwKDXebDqcDbGpeoWA(controllerType, controllerId, categoryName, layoutName, BoolOption.Default);
			}

			public void LoadMap<T>(int controllerId, int categoryId, int layoutId, bool startEnabled) where T : ControllerMap
			{
				JZHOxduGvNaeMvBROZleaOBhXjli<T>(controllerId, categoryId, layoutId, startEnabled ? BoolOption.True : BoolOption.False);
			}

			public void LoadMap<T>(int controllerId, string categoryName, string layoutName, bool startEnabled) where T : ControllerMap
			{
				ZmNCKKtEJReEPQfbhdRZDaoJpcPn<T>(controllerId, categoryName, layoutName, startEnabled ? BoolOption.True : BoolOption.False);
			}

			public void LoadMap(ControllerType controllerType, int controllerId, int categoryId, int layoutId, bool startEnabled)
			{
				IsWkCcPqglFizYcarEzvExMpmzwEA(controllerType, controllerId, categoryId, layoutId, startEnabled ? BoolOption.True : BoolOption.False);
			}

			public void LoadMap(ControllerType controllerType, int controllerId, string categoryName, string layoutName, bool startEnabled)
			{
				pZiRhBoJeKNdwKDXebDqcDbGpeoWA(controllerType, controllerId, categoryName, layoutName, startEnabled ? BoolOption.True : BoolOption.False);
			}

			private void JZHOxduGvNaeMvBROZleaOBhXjli<_0001>(int P_0, int P_1, int P_2, BoolOption P_3) where _0001 : ControllerMap
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
				}
				else
				{
					iuccFizJavEgbdrjmoChnOppOPYwA(IyPmashUlRgIygDiHFyDZHZmauql.vBvhRnrsyKoNMsAeKAkRzastNVbp<_0001>(), P_0, P_1, P_2, P_3);
				}
			}

			private void ZmNCKKtEJReEPQfbhdRZDaoJpcPn<_0001>(int P_0, string P_1, string P_2, BoolOption P_3) where _0001 : ControllerMap
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
				}
				else
				{
					vfvlWKGDqnPLHETxICuKKwHrncft(IyPmashUlRgIygDiHFyDZHZmauql.vBvhRnrsyKoNMsAeKAkRzastNVbp<_0001>(), P_0, P_1, P_2, P_3);
				}
			}

			private void IsWkCcPqglFizYcarEzvExMpmzwEA(ControllerType P_0, int P_1, int P_2, int P_3, BoolOption P_4)
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
				}
				else
				{
					iuccFizJavEgbdrjmoChnOppOPYwA(P_0, P_1, P_2, P_3, P_4);
				}
			}

			private void pZiRhBoJeKNdwKDXebDqcDbGpeoWA(ControllerType P_0, int P_1, string P_2, string P_3, BoolOption P_4)
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
				}
				else
				{
					vfvlWKGDqnPLHETxICuKKwHrncft(P_0, P_1, P_2, P_3, P_4);
				}
			}

			[IteratorStateMachine(typeof(kMKUAWHGtWBqjqGgousCYPsuKfWN))]
			public IEnumerable<ControllerMap> GetAllMaps()
			{
				return new kMKUAWHGtWBqjqGgousCYPsuKfWN(-2)
				{
					qlXwJMwHhdyQfVTNwGDKYDExtLzM = this
				};
			}

			public int GetAllMaps(List<ControllerMap> results)
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return 0;
				}
				if (results == null)
				{
					throw new ArgumentNullException("results");
				}
				results.Clear();
				int kzSWyhVFpKvuMAleUEiVntIEyGZD = yfZPVbkoNrPFYlhxRcQrxPzDLvft.QecjgvgRSXuPhnYvNrbSsHRqQwjg.KzSWyhVFpKvuMAleUEiVntIEyGZD;
				for (int i = 0; i < kzSWyhVFpKvuMAleUEiVntIEyGZD; i++)
				{
					HENtlJpbLTfyvGNBdnYOTBUpGwmPA hENtlJpbLTfyvGNBdnYOTBUpGwmPA = yfZPVbkoNrPFYlhxRcQrxPzDLvft.QecjgvgRSXuPhnYvNrbSsHRqQwjg.AMmiEUMJUxmCKCltvrDeLoaPvEGE(i);
					int num = hENtlJpbLTfyvGNBdnYOTBUpGwmPA.rphZqyUfbdoINyXndGfDbQaiIHFM();
					for (int j = 0; j < num; j++)
					{
						hENtlJpbLTfyvGNBdnYOTBUpGwmPA.gmqWnmpZMnASuZpGLEqmJcwgXIqMA(j).ycfaKniCLOzZqlQviANrBfbEZIlRA().JYGmfpoOXqDRUbFyWhEQYmZadVNs(results, true);
					}
				}
				return results.Count;
			}

			[IteratorStateMachine(typeof(rPLoRrHprRobINOKhcGnKdEqmWJcb))]
			public IEnumerable<T> GetAllMaps<T>() where T : ControllerMap
			{
				return new rPLoRrHprRobINOKhcGnKdEqmWJcb<T>(-2)
				{
					SHSGCEKqMljccEzDjEPyVjjZSedB = this
				};
			}

			public int GetAllMaps<T>(List<T> results) where T : ControllerMap
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return 0;
				}
				if (results == null)
				{
					throw new ArgumentNullException("results");
				}
				results.Clear();
				if (IyPmashUlRgIygDiHFyDZHZmauql.ogCvDDYZbiIuQyBzRHlCQIrYWSXb<T>(out var controllerType))
				{
					HENtlJpbLTfyvGNBdnYOTBUpGwmPA hENtlJpbLTfyvGNBdnYOTBUpGwmPA = yfZPVbkoNrPFYlhxRcQrxPzDLvft.QecjgvgRSXuPhnYvNrbSsHRqQwjg.AXLlayIlTwJqJNaNzeKccuszIcODb(controllerType);
					int num = hENtlJpbLTfyvGNBdnYOTBUpGwmPA.rphZqyUfbdoINyXndGfDbQaiIHFM();
					for (int i = 0; i < num; i++)
					{
						hENtlJpbLTfyvGNBdnYOTBUpGwmPA.gmqWnmpZMnASuZpGLEqmJcwgXIqMA(i).ycfaKniCLOzZqlQviANrBfbEZIlRA().IsEYBsKlUmhsQLYxzmvZKdCAiZhP(results, true);
					}
				}
				else
				{
					int kzSWyhVFpKvuMAleUEiVntIEyGZD = yfZPVbkoNrPFYlhxRcQrxPzDLvft.QecjgvgRSXuPhnYvNrbSsHRqQwjg.KzSWyhVFpKvuMAleUEiVntIEyGZD;
					for (int j = 0; j < kzSWyhVFpKvuMAleUEiVntIEyGZD; j++)
					{
						HENtlJpbLTfyvGNBdnYOTBUpGwmPA hENtlJpbLTfyvGNBdnYOTBUpGwmPA2 = yfZPVbkoNrPFYlhxRcQrxPzDLvft.QecjgvgRSXuPhnYvNrbSsHRqQwjg.AMmiEUMJUxmCKCltvrDeLoaPvEGE(j);
						int num2 = hENtlJpbLTfyvGNBdnYOTBUpGwmPA2.rphZqyUfbdoINyXndGfDbQaiIHFM();
						for (int k = 0; k < num2; k++)
						{
							hENtlJpbLTfyvGNBdnYOTBUpGwmPA2.gmqWnmpZMnASuZpGLEqmJcwgXIqMA(k).ycfaKniCLOzZqlQviANrBfbEZIlRA().IsEYBsKlUmhsQLYxzmvZKdCAiZhP(results, true);
						}
					}
				}
				return results.Count;
			}

			[IteratorStateMachine(typeof(JSPDqcnitJSROqCCdYurSRBRhryh))]
			public IEnumerable<ControllerMap> GetAllMaps(ControllerType controllerType)
			{
				return new JSPDqcnitJSROqCCdYurSRBRhryh(-2)
				{
					HkZcoCjuBCdcLfsibveosObclgJQc = this,
					WiDbgEIvTwnHUIkxADWfGCljFLlV = controllerType
				};
			}

			public int GetAllMaps(ControllerType controllerType, List<ControllerMap> results)
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return 0;
				}
				if (results == null)
				{
					throw new ArgumentNullException("results");
				}
				results.Clear();
				HENtlJpbLTfyvGNBdnYOTBUpGwmPA hENtlJpbLTfyvGNBdnYOTBUpGwmPA = yfZPVbkoNrPFYlhxRcQrxPzDLvft.QecjgvgRSXuPhnYvNrbSsHRqQwjg.AXLlayIlTwJqJNaNzeKccuszIcODb(controllerType);
				int num = hENtlJpbLTfyvGNBdnYOTBUpGwmPA.rphZqyUfbdoINyXndGfDbQaiIHFM();
				for (int i = 0; i < num; i++)
				{
					hENtlJpbLTfyvGNBdnYOTBUpGwmPA.gmqWnmpZMnASuZpGLEqmJcwgXIqMA(i).ycfaKniCLOzZqlQviANrBfbEZIlRA().JYGmfpoOXqDRUbFyWhEQYmZadVNs(results, true);
				}
				return results.Count;
			}

			public IEnumerable<ControllerMap> GetAllMapsInCategory(string categoryName)
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return EmptyObjects<ControllerMap>.EmptyReadOnlyIListT;
				}
				int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
				if (mapCategoryId < 0)
				{
					return new List<ControllerMap>();
				}
				return GetAllMapsInCategory(mapCategoryId);
			}

			[IteratorStateMachine(typeof(WlscQYIYWSQGvKeTufwpTGPIVVYnA))]
			public IEnumerable<ControllerMap> GetAllMapsInCategory(int categoryId)
			{
				return new WlscQYIYWSQGvKeTufwpTGPIVVYnA(-2)
				{
					zEublVjILcckDAHMdppXdGrsjfGX = this,
					zRSiPsUoccgDvmgdxqYTuKxDtRdW = categoryId
				};
			}

			public IEnumerable<T> GetAllMapsInCategory<T>(string categoryName) where T : ControllerMap
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return EmptyObjects<T>.EmptyReadOnlyIListT;
				}
				int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
				if (mapCategoryId < 0)
				{
					return EmptyObjects<T>.EmptyReadOnlyIListT;
				}
				return GetAllMapsInCategory<T>(mapCategoryId);
			}

			[IteratorStateMachine(typeof(AALJkHCbVyFmfLjqbLGfRgqnQdXs))]
			public IEnumerable<T> GetAllMapsInCategory<T>(int categoryId) where T : ControllerMap
			{
				return new AALJkHCbVyFmfLjqbLGfRgqnQdXs<T>(-2)
				{
					fkwaXQNmiBhsyobvCRTmGvwVkTpP = this,
					OMVUUcDliEjVpaDELVKrJWPfLYYeA = categoryId
				};
			}

			public IEnumerable<ControllerMap> GetAllMapsInCategory(string categoryName, ControllerType controllerType)
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return EmptyObjects<ControllerMap>.EmptyReadOnlyIListT;
				}
				int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
				if (mapCategoryId < 0)
				{
					return new List<ControllerMap>();
				}
				return GetAllMapsInCategory(mapCategoryId, controllerType);
			}

			[IteratorStateMachine(typeof(sVWbKMcAoANFAnHPMLNHAhoWKWTtA))]
			public IEnumerable<ControllerMap> GetAllMapsInCategory(int categoryId, ControllerType controllerType)
			{
				return new sVWbKMcAoANFAnHPMLNHAhoWKWTtA(-2)
				{
					bMOaIznmRhEWMCtTYVBJbDnZEobvA = this,
					YQmbVfixNRNiixhHOOqKCkvGkFUXb = categoryId,
					RdYCxjRtiXOmFTcWnhiQuTnFLGov = controllerType
				};
			}

			public int GetAllMapsInCategory(string categoryName, List<ControllerMap> results)
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return 0;
				}
				int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
				if (mapCategoryId < 0)
				{
					return 0;
				}
				return GetAllMapsInCategory(mapCategoryId, results);
			}

			public int GetAllMapsInCategory(int categoryId, List<ControllerMap> results)
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return 0;
				}
				if (results == null)
				{
					throw new ArgumentNullException("results");
				}
				results.Clear();
				if (ReInput.mapping.GetMapCategory(categoryId) == null)
				{
					return 0;
				}
				int kzSWyhVFpKvuMAleUEiVntIEyGZD = yfZPVbkoNrPFYlhxRcQrxPzDLvft.QecjgvgRSXuPhnYvNrbSsHRqQwjg.KzSWyhVFpKvuMAleUEiVntIEyGZD;
				for (int i = 0; i < kzSWyhVFpKvuMAleUEiVntIEyGZD; i++)
				{
					HENtlJpbLTfyvGNBdnYOTBUpGwmPA hENtlJpbLTfyvGNBdnYOTBUpGwmPA = yfZPVbkoNrPFYlhxRcQrxPzDLvft.QecjgvgRSXuPhnYvNrbSsHRqQwjg.AMmiEUMJUxmCKCltvrDeLoaPvEGE(i);
					int num = hENtlJpbLTfyvGNBdnYOTBUpGwmPA.rphZqyUfbdoINyXndGfDbQaiIHFM();
					for (int j = 0; j < num; j++)
					{
						hENtlJpbLTfyvGNBdnYOTBUpGwmPA.gmqWnmpZMnASuZpGLEqmJcwgXIqMA(j).ycfaKniCLOzZqlQviANrBfbEZIlRA().XrtQuIfXPnNyDQZOsqQJCGMljsyHA(categoryId, results, true);
					}
				}
				return results.Count;
			}

			public int GetAllMapsInCategory<T>(string categoryName, List<T> results) where T : ControllerMap
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return 0;
				}
				int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
				if (mapCategoryId < 0)
				{
					return 0;
				}
				return GetAllMapsInCategory(mapCategoryId, results);
			}

			public int GetAllMapsInCategory<T>(int categoryId, List<T> results) where T : ControllerMap
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return 0;
				}
				if (results == null)
				{
					throw new ArgumentNullException("results");
				}
				results.Clear();
				if (ReInput.mapping.GetMapCategory(categoryId) == null)
				{
					return 0;
				}
				if (IyPmashUlRgIygDiHFyDZHZmauql.ogCvDDYZbiIuQyBzRHlCQIrYWSXb<T>(out var controllerType))
				{
					HENtlJpbLTfyvGNBdnYOTBUpGwmPA hENtlJpbLTfyvGNBdnYOTBUpGwmPA = yfZPVbkoNrPFYlhxRcQrxPzDLvft.QecjgvgRSXuPhnYvNrbSsHRqQwjg.AXLlayIlTwJqJNaNzeKccuszIcODb(controllerType);
					int num = hENtlJpbLTfyvGNBdnYOTBUpGwmPA.rphZqyUfbdoINyXndGfDbQaiIHFM();
					for (int i = 0; i < num; i++)
					{
						hENtlJpbLTfyvGNBdnYOTBUpGwmPA.gmqWnmpZMnASuZpGLEqmJcwgXIqMA(i).ycfaKniCLOzZqlQviANrBfbEZIlRA().kRQcUWsfikVYiqpdoBjkLqAtBohdA(categoryId, results, true);
					}
				}
				else
				{
					int kzSWyhVFpKvuMAleUEiVntIEyGZD = yfZPVbkoNrPFYlhxRcQrxPzDLvft.QecjgvgRSXuPhnYvNrbSsHRqQwjg.KzSWyhVFpKvuMAleUEiVntIEyGZD;
					for (int j = 0; j < kzSWyhVFpKvuMAleUEiVntIEyGZD; j++)
					{
						HENtlJpbLTfyvGNBdnYOTBUpGwmPA hENtlJpbLTfyvGNBdnYOTBUpGwmPA2 = yfZPVbkoNrPFYlhxRcQrxPzDLvft.QecjgvgRSXuPhnYvNrbSsHRqQwjg.AMmiEUMJUxmCKCltvrDeLoaPvEGE(j);
						int num2 = hENtlJpbLTfyvGNBdnYOTBUpGwmPA2.rphZqyUfbdoINyXndGfDbQaiIHFM();
						for (int k = 0; k < num2; k++)
						{
							hENtlJpbLTfyvGNBdnYOTBUpGwmPA2.gmqWnmpZMnASuZpGLEqmJcwgXIqMA(k).ycfaKniCLOzZqlQviANrBfbEZIlRA().kRQcUWsfikVYiqpdoBjkLqAtBohdA(categoryId, results, true);
						}
					}
				}
				return results.Count;
			}

			public int GetAllMapsInCategory(string categoryName, ControllerType controllerType, List<ControllerMap> results)
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return 0;
				}
				int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
				if (mapCategoryId < 0)
				{
					return 0;
				}
				return GetAllMapsInCategory(mapCategoryId, controllerType, results);
			}

			public int GetAllMapsInCategory(int categoryId, ControllerType controllerType, List<ControllerMap> results)
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return 0;
				}
				if (results == null)
				{
					throw new ArgumentNullException("results");
				}
				results.Clear();
				if (ReInput.mapping.GetMapCategory(categoryId) == null)
				{
					return 0;
				}
				HENtlJpbLTfyvGNBdnYOTBUpGwmPA hENtlJpbLTfyvGNBdnYOTBUpGwmPA = yfZPVbkoNrPFYlhxRcQrxPzDLvft.QecjgvgRSXuPhnYvNrbSsHRqQwjg.AXLlayIlTwJqJNaNzeKccuszIcODb(controllerType);
				int num = hENtlJpbLTfyvGNBdnYOTBUpGwmPA.rphZqyUfbdoINyXndGfDbQaiIHFM();
				for (int i = 0; i < num; i++)
				{
					hENtlJpbLTfyvGNBdnYOTBUpGwmPA.gmqWnmpZMnASuZpGLEqmJcwgXIqMA(i).ycfaKniCLOzZqlQviANrBfbEZIlRA().XrtQuIfXPnNyDQZOsqQJCGMljsyHA(categoryId, results, true);
				}
				return results.Count;
			}

			public IList<T> GetMaps<T>(int controllerId) where T : ControllerMap
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return EmptyObjects<T>.EmptyReadOnlyIListT;
				}
				return NZockkAJfoePAXulRwzevheOHKEX<T>(controllerId);
			}

			public IList<ControllerMap> GetMaps(ControllerType controllerType, int controllerId)
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return EmptyObjects<ControllerMap>.EmptyReadOnlyIListT;
				}
				return bxDpnOOiZeoKpBCjiZupiYEmZhLK(controllerType, controllerId);
			}

			public IList<ControllerMap> GetMaps(Controller controller)
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return EmptyObjects<ControllerMap>.EmptyReadOnlyIListT;
				}
				if (controller == null)
				{
					return EmptyObjects<ControllerMap>.EmptyReadOnlyIListT;
				}
				return GetMaps(controller.type, controller.id);
			}

			public IEnumerable<ControllerMap> GetMapsInCategory(ControllerType controllerType, int controllerId, int categoryId)
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return EmptyObjects<ControllerMap>.EmptyReadOnlyIListT;
				}
				if (controllerId < 0 || categoryId < 0)
				{
					return EmptyObjects<ControllerMap>.EmptyReadOnlyIListT;
				}
				if (ReInput.mapping.GetMapCategory(categoryId) == null)
				{
					return EmptyObjects<ControllerMap>.EmptyReadOnlyIListT;
				}
				return DVavlEaGMrOCQKmxpSoRfExhiHTh(controllerType, controllerId, categoryId);
			}

			public IEnumerable<ControllerMap> GetMapsInCategory(ControllerType controllerType, int controllerId, string categoryName)
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return EmptyObjects<ControllerMap>.EmptyReadOnlyIListT;
				}
				int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
				if (mapCategoryId < 0)
				{
					return EmptyObjects<ControllerMap>.EmptyReadOnlyIListT;
				}
				return GetMapsInCategory(controllerType, controllerId, mapCategoryId);
			}

			public IEnumerable<ControllerMap> GetMapsInCategory(Controller controller, int categoryId)
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return EmptyObjects<ControllerMap>.EmptyReadOnlyIListT;
				}
				if (controller == null)
				{
					return EmptyObjects<ControllerMap>.EmptyReadOnlyIListT;
				}
				return GetMapsInCategory(controller.type, controller.id, categoryId);
			}

			public IEnumerable<ControllerMap> GetMapsInCategory(Controller controller, string categoryName)
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return EmptyObjects<ControllerMap>.EmptyReadOnlyIListT;
				}
				if (controller == null)
				{
					return EmptyObjects<ControllerMap>.EmptyReadOnlyIListT;
				}
				int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
				if (mapCategoryId < 0)
				{
					return EmptyObjects<ControllerMap>.EmptyReadOnlyIListT;
				}
				return GetMapsInCategory(controller.type, controller.id, mapCategoryId);
			}

			public int GetMapsInCategory(ControllerType controllerType, int controllerId, int categoryId, List<ControllerMap> results)
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return 0;
				}
				ListTools.TryClear(results);
				if (results == null)
				{
					throw new ArgumentNullException("results");
				}
				if (controllerId < 0 || categoryId < 0)
				{
					return 0;
				}
				if (ReInput.mapping.GetMapCategory(categoryId) == null)
				{
					return 0;
				}
				return yfZPVbkoNrPFYlhxRcQrxPzDLvft.QecjgvgRSXuPhnYvNrbSsHRqQwjg.AXLlayIlTwJqJNaNzeKccuszIcODb(controllerType).EiaJdcLRNPgisAQlXkogBqWdcrPqb(controllerId)?.ycfaKniCLOzZqlQviANrBfbEZIlRA().XrtQuIfXPnNyDQZOsqQJCGMljsyHA(categoryId, results, false) ?? 0;
			}

			public int GetMapsInCategory(ControllerType controllerType, int controllerId, string categoryName, List<ControllerMap> results)
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return 0;
				}
				ListTools.TryClear(results);
				int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
				if (mapCategoryId < 0)
				{
					return 0;
				}
				return GetMapsInCategory(controllerType, controllerId, mapCategoryId, results);
			}

			public int GetMapsInCategory(Controller controller, int categoryId, List<ControllerMap> results)
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return 0;
				}
				ListTools.TryClear(results);
				if (controller == null)
				{
					return 0;
				}
				return GetMapsInCategory(controller.type, controller.id, categoryId, results);
			}

			public int GetMapsInCategory(Controller controller, string categoryName, List<ControllerMap> results)
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return 0;
				}
				ListTools.TryClear(results);
				if (controller == null)
				{
					return 0;
				}
				int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
				if (mapCategoryId < 0)
				{
					return 0;
				}
				return GetMapsInCategory(controller.type, controller.id, mapCategoryId, results);
			}

			public IEnumerable<T> GetMapsInCategory<T>(int controllerId, int categoryId) where T : ControllerMap
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return EmptyObjects<T>.EmptyReadOnlyIListT;
				}
				return oxsGGzgoGfCiRUJyxwneDNyMHMZcb<T>(controllerId, categoryId);
			}

			public IEnumerable<T> GetMapsInCategory<T>(int controllerId, string categoryName) where T : ControllerMap
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return EmptyObjects<T>.EmptyReadOnlyIListT;
				}
				int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
				if (mapCategoryId < 0)
				{
					return EmptyObjects<T>.EmptyReadOnlyIListT;
				}
				return GetMapsInCategory<T>(controllerId, mapCategoryId);
			}

			public int GetMapsInCategory<T>(int controllerId, int categoryId, List<T> results) where T : ControllerMap
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return 0;
				}
				if (results == null)
				{
					throw new ArgumentNullException("results");
				}
				results.Clear();
				if (ReInput.mapping.GetMapCategory(categoryId) == null)
				{
					return 0;
				}
				AShuyBCharjMzjKIZJtOvccShXtr aShuyBCharjMzjKIZJtOvccShXtr = vjFJSXxeUsObgcxatjFDQDpTwlTs<T>().EiaJdcLRNPgisAQlXkogBqWdcrPqb(controllerId);
				if (aShuyBCharjMzjKIZJtOvccShXtr == null)
				{
					return 0;
				}
				aShuyBCharjMzjKIZJtOvccShXtr.ycfaKniCLOzZqlQviANrBfbEZIlRA().kRQcUWsfikVYiqpdoBjkLqAtBohdA(categoryId, results, true);
				return results.Count;
			}

			public int GetMapsInCategory<T>(int controllerId, string categoryName, List<T> results) where T : ControllerMap
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return 0;
				}
				ListTools.TryClear(results);
				int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
				if (mapCategoryId < 0)
				{
					return 0;
				}
				return GetMapsInCategory(controllerId, mapCategoryId, results);
			}

			public T GetMap<T>(int controllerId, int mapId) where T : ControllerMap
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return null;
				}
				if (mapId < 0)
				{
					return null;
				}
				return (T)wlYTjRTwKufhKShPQDUUyuyZMODy(IyPmashUlRgIygDiHFyDZHZmauql.vBvhRnrsyKoNMsAeKAkRzastNVbp<T>(), controllerId, mapId);
			}

			public T GetMap<T>(int controllerId, int categoryId, int layoutId) where T : ControllerMap
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return null;
				}
				if (categoryId < 0 || layoutId < 0)
				{
					return null;
				}
				return (T)zQbEeMxFPAzvSIBXzpimFCAIEIoI(IyPmashUlRgIygDiHFyDZHZmauql.vBvhRnrsyKoNMsAeKAkRzastNVbp<T>(), controllerId, categoryId, layoutId);
			}

			public T GetMap<T>(int controllerId, string categoryName, string layoutName) where T : ControllerMap
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return null;
				}
				return (T)YNZDopBNJmlMrhWmTlzeVdcugPJK(IyPmashUlRgIygDiHFyDZHZmauql.vBvhRnrsyKoNMsAeKAkRzastNVbp<T>(), controllerId, categoryName, layoutName);
			}

			public ControllerMap GetMap(int mapId)
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return null;
				}
				if (mapId < 0)
				{
					return null;
				}
				int kzSWyhVFpKvuMAleUEiVntIEyGZD = yfZPVbkoNrPFYlhxRcQrxPzDLvft.QecjgvgRSXuPhnYvNrbSsHRqQwjg.KzSWyhVFpKvuMAleUEiVntIEyGZD;
				for (int i = 0; i < kzSWyhVFpKvuMAleUEiVntIEyGZD; i++)
				{
					HENtlJpbLTfyvGNBdnYOTBUpGwmPA hENtlJpbLTfyvGNBdnYOTBUpGwmPA = yfZPVbkoNrPFYlhxRcQrxPzDLvft.QecjgvgRSXuPhnYvNrbSsHRqQwjg.AMmiEUMJUxmCKCltvrDeLoaPvEGE(i);
					int num = hENtlJpbLTfyvGNBdnYOTBUpGwmPA.rphZqyUfbdoINyXndGfDbQaiIHFM();
					for (int j = 0; j < num; j++)
					{
						ControllerMap controllerMap = hENtlJpbLTfyvGNBdnYOTBUpGwmPA.gmqWnmpZMnASuZpGLEqmJcwgXIqMA(j).ycfaKniCLOzZqlQviANrBfbEZIlRA().CjGxPiEUXuKQAiReAORsgeKuwFqy(mapId);
						if (controllerMap != null)
						{
							return controllerMap;
						}
					}
				}
				return null;
			}

			public ControllerMap GetMap(ControllerType controllerType, int controllerId, int mapId)
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return null;
				}
				if (mapId < 0)
				{
					return null;
				}
				return wlYTjRTwKufhKShPQDUUyuyZMODy(controllerType, controllerId, mapId);
			}

			public ControllerMap GetMap(ControllerType controllerType, int controllerId, int categoryId, int layoutId)
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return null;
				}
				if (categoryId < 0 || layoutId < 0)
				{
					return null;
				}
				return zQbEeMxFPAzvSIBXzpimFCAIEIoI(controllerType, controllerId, categoryId, layoutId);
			}

			public ControllerMap GetMap(ControllerType controllerType, int controllerId, string categoryName, string layoutName)
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return null;
				}
				return YNZDopBNJmlMrhWmTlzeVdcugPJK(controllerType, controllerId, categoryName, layoutName);
			}

			public ControllerMap GetMap(Controller controller, int mapId)
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return null;
				}
				if (controller == null)
				{
					return null;
				}
				return GetMap(controller.type, controller.id, mapId);
			}

			public ControllerMap GetMap(Controller controller, int categoryId, int layoutId)
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return null;
				}
				if (controller == null)
				{
					return null;
				}
				return GetMap(controller.type, controller.id, categoryId, layoutId);
			}

			public ControllerMap GetMap(Controller controller, string categoryName, string layoutName)
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return null;
				}
				if (controller == null)
				{
					return null;
				}
				return GetMap(controller.type, controller.id, categoryName, layoutName);
			}

			public T GetFirstMapInCategory<T>(int controllerId, string categoryName) where T : ControllerMap
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return null;
				}
				int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
				if (mapCategoryId < 0)
				{
					return null;
				}
				return GetFirstMapInCategory<T>(controllerId, mapCategoryId);
			}

			public T GetFirstMapInCategory<T>(int controllerId, int categoryId) where T : ControllerMap
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return null;
				}
				if (categoryId < 0)
				{
					return null;
				}
				return (T)kSrEOewMyxTNUyAQYmNRKDfockhX(IyPmashUlRgIygDiHFyDZHZmauql.vBvhRnrsyKoNMsAeKAkRzastNVbp<T>(), controllerId, categoryId);
			}

			public ControllerMap GetFirstMapInCategory(ControllerType controllerType, int controllerId, string categoryName)
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return null;
				}
				int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
				if (mapCategoryId < 0)
				{
					return null;
				}
				return GetFirstMapInCategory(controllerType, controllerId, mapCategoryId);
			}

			public ControllerMap GetFirstMapInCategory(ControllerType controllerType, int controllerId, int categoryId)
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return null;
				}
				if (categoryId < 0)
				{
					return null;
				}
				return kSrEOewMyxTNUyAQYmNRKDfockhX(controllerType, controllerId, categoryId);
			}

			public ControllerMap GetFirstMapInCategory(Controller controller, string categoryName)
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return null;
				}
				if (controller == null)
				{
					return null;
				}
				return GetFirstMapInCategory(controller.type, controller.id, categoryName);
			}

			public ControllerMap GetFirstMapInCategory(Controller controller, int categoryId)
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return null;
				}
				if (controller == null)
				{
					return null;
				}
				return GetFirstMapInCategory(controller.type, controller.id, categoryId);
			}

			public void AddMap<T>(int controllerId, ControllerMap map) where T : ControllerMap
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
				}
				else
				{
					kFKHroEQvdCRfBnYuNAjcxtCGyQLB(IyPmashUlRgIygDiHFyDZHZmauql.vBvhRnrsyKoNMsAeKAkRzastNVbp<T>(), controllerId, map, BoolOption.Default);
				}
			}

			public void AddMap(Controller controller, ControllerMap map)
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
				}
				else
				{
					fGSvXEgIfBGIaiFBqVtYLAasdTUX(controller, map, BoolOption.Default);
				}
			}

			public void AddMap(ControllerType controllerType, int controllerId, ControllerMap map)
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
				}
				else
				{
					kFKHroEQvdCRfBnYuNAjcxtCGyQLB(controllerType, controllerId, map, BoolOption.Default);
				}
			}

			public void AddMap<T>(int controllerId, ControllerMap map, bool startEnabled) where T : ControllerMap
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
				}
				else
				{
					kFKHroEQvdCRfBnYuNAjcxtCGyQLB(IyPmashUlRgIygDiHFyDZHZmauql.vBvhRnrsyKoNMsAeKAkRzastNVbp<T>(), controllerId, map, startEnabled ? BoolOption.True : BoolOption.False);
				}
			}

			public void AddMap(Controller controller, ControllerMap map, bool startEnabled)
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
				}
				else
				{
					fGSvXEgIfBGIaiFBqVtYLAasdTUX(controller, map, startEnabled ? BoolOption.True : BoolOption.False);
				}
			}

			public void AddMap(ControllerType controllerType, int controllerId, ControllerMap map, bool startEnabled)
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
				}
				else
				{
					kFKHroEQvdCRfBnYuNAjcxtCGyQLB(controllerType, controllerId, map, startEnabled ? BoolOption.True : BoolOption.False);
				}
			}

			public bool AddMapFromXml<T>(int controllerId, string xmlString) where T : ControllerMap
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return false;
				}
				return kqosTSqNOfeJfDHNisEgcHDBaIcQA(IyPmashUlRgIygDiHFyDZHZmauql.vBvhRnrsyKoNMsAeKAkRzastNVbp<T>(), controllerId, xmlString);
			}

			public bool AddMapFromXml(ControllerType controllerType, int controllerId, string xmlString)
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return false;
				}
				return kqosTSqNOfeJfDHNisEgcHDBaIcQA(controllerType, controllerId, xmlString);
			}

			public int AddMapsFromXml<T>(int controllerId, List<string> xmlStrings) where T : ControllerMap
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return 0;
				}
				if (xmlStrings == null)
				{
					return 0;
				}
				int num = 0;
				for (int i = 0; i < xmlStrings.Count; i++)
				{
					if (AddMapFromXml<T>(controllerId, xmlStrings[i]))
					{
						num++;
					}
				}
				return num;
			}

			public int AddMapsFromXml(ControllerType controllerType, int controllerId, List<string> xmlStrings)
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return 0;
				}
				if (xmlStrings == null)
				{
					return 0;
				}
				int num = 0;
				for (int i = 0; i < xmlStrings.Count; i++)
				{
					if (AddMapFromXml(controllerType, controllerId, xmlStrings[i]))
					{
						num++;
					}
				}
				return num;
			}

			public bool AddMapFromJson<T>(int controllerId, string jsonString) where T : ControllerMap
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return false;
				}
				return rqcwlTjKIizdKDEPLbuEuRbchARx(IyPmashUlRgIygDiHFyDZHZmauql.vBvhRnrsyKoNMsAeKAkRzastNVbp<T>(), controllerId, jsonString);
			}

			public bool AddMapFromJson(ControllerType controllerType, int controllerId, string jsonString)
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return false;
				}
				return rqcwlTjKIizdKDEPLbuEuRbchARx(controllerType, controllerId, jsonString);
			}

			public int AddMapsFromJson<T>(int controllerId, List<string> jsonStrings) where T : ControllerMap
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return 0;
				}
				if (jsonStrings == null)
				{
					return 0;
				}
				int num = 0;
				for (int i = 0; i < jsonStrings.Count; i++)
				{
					if (AddMapFromJson<T>(controllerId, jsonStrings[i]))
					{
						num++;
					}
				}
				return num;
			}

			public int AddMapsFromJson(ControllerType controllerType, int controllerId, List<string> jsonStrings)
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return 0;
				}
				if (jsonStrings == null)
				{
					return 0;
				}
				int num = 0;
				for (int i = 0; i < jsonStrings.Count; i++)
				{
					if (AddMapFromJson(controllerType, controllerId, jsonStrings[i]))
					{
						num++;
					}
				}
				return num;
			}

			public void AddEmptyMap<T>(int controllerId, int categoryId, int layoutId) where T : ControllerMap
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
				}
				else
				{
					pMazRBUVdDyRgTiwaCodmRmictEDA(IyPmashUlRgIygDiHFyDZHZmauql.vBvhRnrsyKoNMsAeKAkRzastNVbp<T>(), controllerId, categoryId, layoutId);
				}
			}

			public void AddEmptyMap<T>(int controllerId, string categoryName, string layoutName) where T : ControllerMap
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
				}
				else
				{
					vpOUjuYJLiIrFiptpNDIZRqeJgMHA(IyPmashUlRgIygDiHFyDZHZmauql.vBvhRnrsyKoNMsAeKAkRzastNVbp<T>(), controllerId, categoryName, layoutName);
				}
			}

			public void AddEmptyMap(ControllerType controllerType, int controllerId, int categoryId, int layoutId)
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
				}
				else
				{
					pMazRBUVdDyRgTiwaCodmRmictEDA(controllerType, controllerId, categoryId, layoutId);
				}
			}

			public void AddEmptyMap(ControllerType controllerType, int controllerId, string categoryName, string layoutName)
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return;
				}
				int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
				int layoutId = ReInput.mapping.GetLayoutId(controllerType, layoutName);
				if (mapCategoryId >= 0 && layoutId >= 0)
				{
					AddEmptyMap(controllerType, controllerId, mapCategoryId, layoutId);
				}
			}

			public void RemoveMap<T>(int controllerId, int mapId) where T : ControllerMap
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
				}
				else if (mapId >= 0)
				{
					MHcoyBAgEYSUHbPJVDpmWAJmScJO(IyPmashUlRgIygDiHFyDZHZmauql.vBvhRnrsyKoNMsAeKAkRzastNVbp<T>(), controllerId, mapId);
				}
			}

			public void RemoveMap<T>(int controllerId, int categoryId, int layoutId) where T : ControllerMap
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
				}
				else if (categoryId >= 0 && layoutId >= 0)
				{
					UjGDIbmjEOxDETkVAYnrNFRHlAkN(IyPmashUlRgIygDiHFyDZHZmauql.vBvhRnrsyKoNMsAeKAkRzastNVbp<T>(), controllerId, categoryId, layoutId);
				}
			}

			public void RemoveMap<T>(int controllerId, string categoryName, string layoutName) where T : ControllerMap
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
				}
				else
				{
					ilnQdIUfxnACDWSmyCcxPQijKvUJ(IyPmashUlRgIygDiHFyDZHZmauql.vBvhRnrsyKoNMsAeKAkRzastNVbp<T>(), controllerId, categoryName, layoutName);
				}
			}

			public void RemoveMap(ControllerType controllerType, int controllerId, int mapId)
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
				}
				else if (mapId >= 0)
				{
					MHcoyBAgEYSUHbPJVDpmWAJmScJO(controllerType, controllerId, mapId);
				}
			}

			public void RemoveMap(ControllerType controllerType, int controllerId, int categoryId, int layoutId)
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
				}
				else if (categoryId >= 0 && layoutId >= 0)
				{
					UjGDIbmjEOxDETkVAYnrNFRHlAkN(controllerType, controllerId, categoryId, layoutId);
				}
			}

			public void RemoveMap(ControllerType controllerType, int controllerId, string categoryName, string layoutName)
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
				}
				else
				{
					ilnQdIUfxnACDWSmyCcxPQijKvUJ(controllerType, controllerId, categoryName, layoutName);
				}
			}

			public void ClearMaps<T>(bool userAssignableOnly) where T : ControllerMap
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
				}
				else
				{
					ClearMaps(IyPmashUlRgIygDiHFyDZHZmauql.vBvhRnrsyKoNMsAeKAkRzastNVbp<T>(), userAssignableOnly);
				}
			}

			public void ClearMaps(ControllerType controllerType, bool userAssignableOnly)
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return;
				}
				HENtlJpbLTfyvGNBdnYOTBUpGwmPA hENtlJpbLTfyvGNBdnYOTBUpGwmPA = yfZPVbkoNrPFYlhxRcQrxPzDLvft.QecjgvgRSXuPhnYvNrbSsHRqQwjg.AXLlayIlTwJqJNaNzeKccuszIcODb(controllerType);
				for (int i = 0; i < hENtlJpbLTfyvGNBdnYOTBUpGwmPA.rphZqyUfbdoINyXndGfDbQaiIHFM(); i++)
				{
					hENtlJpbLTfyvGNBdnYOTBUpGwmPA.gmqWnmpZMnASuZpGLEqmJcwgXIqMA(i).ycfaKniCLOzZqlQviANrBfbEZIlRA().lTfGKFmOGeJawUBoNGSKjKTZfSMfb(userAssignableOnly);
				}
			}

			public void ClearMapsInCategory<T>(int categoryId, bool userAssignableOnly) where T : ControllerMap
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
				}
				else
				{
					ClearMapsInCategory(IyPmashUlRgIygDiHFyDZHZmauql.vBvhRnrsyKoNMsAeKAkRzastNVbp<T>(), categoryId, userAssignableOnly);
				}
			}

			public void ClearMapsInCategory<T>(string categoryName, bool userAssignableOnly) where T : ControllerMap
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return;
				}
				int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
				if (mapCategoryId >= 0)
				{
					ClearMapsInCategory<T>(mapCategoryId, userAssignableOnly);
				}
			}

			public void ClearMapsInCategory<T>(int categoryId, int layoutId, bool userAssignableOnly) where T : ControllerMap
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
				}
				else
				{
					ClearMapsInCategory(IyPmashUlRgIygDiHFyDZHZmauql.vBvhRnrsyKoNMsAeKAkRzastNVbp<T>(), categoryId, layoutId, userAssignableOnly);
				}
			}

			public void ClearMapsInCategory<T>(string categoryName, string layoutName, bool userAssignableOnly) where T : ControllerMap
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return;
				}
				int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
				if (mapCategoryId >= 0)
				{
					int layoutId = ReInput.mapping.GetLayoutId(IyPmashUlRgIygDiHFyDZHZmauql.vBvhRnrsyKoNMsAeKAkRzastNVbp<T>(), layoutName);
					if (layoutId >= 0)
					{
						ClearMapsInCategory<T>(mapCategoryId, layoutId, userAssignableOnly);
					}
				}
			}

			public void ClearMapsInCategory(int categoryId, bool userAssignableOnly)
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return;
				}
				int kzSWyhVFpKvuMAleUEiVntIEyGZD = yfZPVbkoNrPFYlhxRcQrxPzDLvft.QecjgvgRSXuPhnYvNrbSsHRqQwjg.KzSWyhVFpKvuMAleUEiVntIEyGZD;
				for (int i = 0; i < kzSWyhVFpKvuMAleUEiVntIEyGZD; i++)
				{
					HENtlJpbLTfyvGNBdnYOTBUpGwmPA hENtlJpbLTfyvGNBdnYOTBUpGwmPA = yfZPVbkoNrPFYlhxRcQrxPzDLvft.QecjgvgRSXuPhnYvNrbSsHRqQwjg.AXLlayIlTwJqJNaNzeKccuszIcODb(yfZPVbkoNrPFYlhxRcQrxPzDLvft.QecjgvgRSXuPhnYvNrbSsHRqQwjg.JZVdeJdqcyVABFyDAQNnnsvkBpKvA(i));
					for (int j = 0; j < hENtlJpbLTfyvGNBdnYOTBUpGwmPA.rphZqyUfbdoINyXndGfDbQaiIHFM(); j++)
					{
						hENtlJpbLTfyvGNBdnYOTBUpGwmPA.gmqWnmpZMnASuZpGLEqmJcwgXIqMA(j).ycfaKniCLOzZqlQviANrBfbEZIlRA().wQnQUAsbGHdSbplfRXQxpAzGRZDf(categoryId, userAssignableOnly);
					}
				}
			}

			public void ClearMapsInCategory(string categoryName, bool userAssignableOnly)
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return;
				}
				int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
				if (mapCategoryId >= 0)
				{
					ClearMapsInCategory(mapCategoryId, userAssignableOnly);
				}
			}

			public void ClearMapsInCategory(ControllerType controllerType, int categoryId, bool userAssignableOnly)
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return;
				}
				HENtlJpbLTfyvGNBdnYOTBUpGwmPA hENtlJpbLTfyvGNBdnYOTBUpGwmPA = yfZPVbkoNrPFYlhxRcQrxPzDLvft.QecjgvgRSXuPhnYvNrbSsHRqQwjg.AXLlayIlTwJqJNaNzeKccuszIcODb(controllerType);
				for (int i = 0; i < hENtlJpbLTfyvGNBdnYOTBUpGwmPA.rphZqyUfbdoINyXndGfDbQaiIHFM(); i++)
				{
					hENtlJpbLTfyvGNBdnYOTBUpGwmPA.gmqWnmpZMnASuZpGLEqmJcwgXIqMA(i).ycfaKniCLOzZqlQviANrBfbEZIlRA().wQnQUAsbGHdSbplfRXQxpAzGRZDf(categoryId, userAssignableOnly);
				}
			}

			public void ClearMapsInCategory(ControllerType controllerType, string categoryName, bool userAssignableOnly)
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return;
				}
				int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
				if (mapCategoryId >= 0)
				{
					ClearMapsInCategory(controllerType, mapCategoryId, userAssignableOnly);
				}
			}

			public void ClearMapsInCategory(ControllerType controllerType, int categoryId, int layoutId, bool userAssignableOnly)
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return;
				}
				InputCategory mapCategory = ReInput.mapping.GetMapCategory(categoryId);
				if (mapCategory != null && (!userAssignableOnly || mapCategory.userAssignable))
				{
					HENtlJpbLTfyvGNBdnYOTBUpGwmPA hENtlJpbLTfyvGNBdnYOTBUpGwmPA = yfZPVbkoNrPFYlhxRcQrxPzDLvft.QecjgvgRSXuPhnYvNrbSsHRqQwjg.AXLlayIlTwJqJNaNzeKccuszIcODb(controllerType);
					for (int i = 0; i < hENtlJpbLTfyvGNBdnYOTBUpGwmPA.rphZqyUfbdoINyXndGfDbQaiIHFM(); i++)
					{
						hENtlJpbLTfyvGNBdnYOTBUpGwmPA.gmqWnmpZMnASuZpGLEqmJcwgXIqMA(i).ycfaKniCLOzZqlQviANrBfbEZIlRA().opZpdnNQXrhuoaOlohwygiyYsYXMA(categoryId, layoutId);
					}
				}
			}

			public void ClearMapsInCategory(ControllerType controllerType, string categoryName, string layoutName, bool userAssignableOnly)
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return;
				}
				int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
				if (mapCategoryId >= 0)
				{
					int layoutId = ReInput.mapping.GetLayoutId(controllerType, layoutName);
					if (layoutId >= 0)
					{
						ClearMapsInCategory(controllerType, mapCategoryId, layoutId, userAssignableOnly);
					}
				}
			}

			public void ClearMapsInLayout<T>(int layoutId, bool userAssignableOnly) where T : ControllerMap
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
				}
				else
				{
					ClearMapsInLayout(IyPmashUlRgIygDiHFyDZHZmauql.vBvhRnrsyKoNMsAeKAkRzastNVbp<T>(), layoutId, userAssignableOnly);
				}
			}

			public void ClearMapsInLayout<T>(string layoutName, bool userAssignableOnly) where T : ControllerMap
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return;
				}
				int layoutId = ReInput.mapping.GetLayoutId(IyPmashUlRgIygDiHFyDZHZmauql.vBvhRnrsyKoNMsAeKAkRzastNVbp<T>(), layoutName);
				if (layoutId >= 0)
				{
					ClearMapsInLayout<T>(layoutId, userAssignableOnly);
				}
			}

			public void ClearMapsInLayout(ControllerType controllerType, int layoutId, bool userAssignableOnly)
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return;
				}
				HENtlJpbLTfyvGNBdnYOTBUpGwmPA hENtlJpbLTfyvGNBdnYOTBUpGwmPA = yfZPVbkoNrPFYlhxRcQrxPzDLvft.QecjgvgRSXuPhnYvNrbSsHRqQwjg.AXLlayIlTwJqJNaNzeKccuszIcODb(controllerType);
				for (int i = 0; i < hENtlJpbLTfyvGNBdnYOTBUpGwmPA.rphZqyUfbdoINyXndGfDbQaiIHFM(); i++)
				{
					hENtlJpbLTfyvGNBdnYOTBUpGwmPA.gmqWnmpZMnASuZpGLEqmJcwgXIqMA(i).ycfaKniCLOzZqlQviANrBfbEZIlRA().LHBNLdvxpgComlrFVgzujdYCEgEeA(layoutId, userAssignableOnly);
				}
			}

			public void ClearMapsInLayout(ControllerType controllerType, string layoutName, bool userAssignableOnly)
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return;
				}
				int layoutId = ReInput.mapping.GetLayoutId(controllerType, layoutName);
				if (layoutId >= 0)
				{
					ClearMapsInLayout(controllerType, layoutId, userAssignableOnly);
				}
			}

			public void ClearMapsForController<T>(int controllerId, bool userAssignableOnly) where T : ControllerMap
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
				}
				else
				{
					ClearMapsForController(IyPmashUlRgIygDiHFyDZHZmauql.vBvhRnrsyKoNMsAeKAkRzastNVbp<T>(), controllerId, userAssignableOnly);
				}
			}

			public void ClearMapsForController<T>(int controllerId, int categoryId, bool userAssignableOnly) where T : ControllerMap
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
				}
				else
				{
					ClearMapsForController(IyPmashUlRgIygDiHFyDZHZmauql.vBvhRnrsyKoNMsAeKAkRzastNVbp<T>(), controllerId, categoryId, userAssignableOnly);
				}
			}

			public void ClearMapsForController<T>(int controllerId, string categoryName, bool userAssignableOnly) where T : ControllerMap
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return;
				}
				int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
				if (mapCategoryId >= 0)
				{
					ClearMapsForController<T>(controllerId, mapCategoryId, userAssignableOnly);
				}
			}

			public void ClearMapsForController(ControllerType controllerType, int controllerId, bool userAssignableOnly)
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return;
				}
				HENtlJpbLTfyvGNBdnYOTBUpGwmPA hENtlJpbLTfyvGNBdnYOTBUpGwmPA = yfZPVbkoNrPFYlhxRcQrxPzDLvft.QecjgvgRSXuPhnYvNrbSsHRqQwjg.AXLlayIlTwJqJNaNzeKccuszIcODb(controllerType);
				int num = hENtlJpbLTfyvGNBdnYOTBUpGwmPA.LwDtjAISpvZKUEBiCEPKHyoscvdr(controllerId);
				if (num >= 0)
				{
					hENtlJpbLTfyvGNBdnYOTBUpGwmPA.gmqWnmpZMnASuZpGLEqmJcwgXIqMA(num).ycfaKniCLOzZqlQviANrBfbEZIlRA().lTfGKFmOGeJawUBoNGSKjKTZfSMfb(userAssignableOnly);
				}
			}

			public void ClearMapsForController(ControllerType controllerType, int controllerId, int categoryId, bool userAssignableOnly)
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return;
				}
				HENtlJpbLTfyvGNBdnYOTBUpGwmPA hENtlJpbLTfyvGNBdnYOTBUpGwmPA = yfZPVbkoNrPFYlhxRcQrxPzDLvft.QecjgvgRSXuPhnYvNrbSsHRqQwjg.AXLlayIlTwJqJNaNzeKccuszIcODb(controllerType);
				int num = hENtlJpbLTfyvGNBdnYOTBUpGwmPA.LwDtjAISpvZKUEBiCEPKHyoscvdr(controllerId);
				if (num >= 0)
				{
					hENtlJpbLTfyvGNBdnYOTBUpGwmPA.gmqWnmpZMnASuZpGLEqmJcwgXIqMA(num).ycfaKniCLOzZqlQviANrBfbEZIlRA().wQnQUAsbGHdSbplfRXQxpAzGRZDf(categoryId, userAssignableOnly);
				}
			}

			public void ClearMapsForController(ControllerType controllerType, int controllerId, string categoryName, bool userAssignableOnly)
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return;
				}
				int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
				if (mapCategoryId >= 0)
				{
					ClearMapsForController(controllerType, controllerId, mapCategoryId, userAssignableOnly);
				}
			}

			public void ClearMapsForControllerInLayout<T>(int controllerId, int layoutId, bool userAssignableOnly) where T : ControllerMap
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
				}
				else
				{
					ClearMapsForControllerInLayout(IyPmashUlRgIygDiHFyDZHZmauql.vBvhRnrsyKoNMsAeKAkRzastNVbp<T>(), controllerId, layoutId, userAssignableOnly);
				}
			}

			public void ClearMapsForControllerInLayout<T>(int controllerId, string layoutName, bool userAssignableOnly) where T : ControllerMap
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return;
				}
				int layoutId = ReInput.mapping.GetLayoutId(IyPmashUlRgIygDiHFyDZHZmauql.vBvhRnrsyKoNMsAeKAkRzastNVbp<T>(), layoutName);
				if (layoutId >= 0)
				{
					ClearMapsForControllerInLayout<T>(controllerId, layoutId, userAssignableOnly);
				}
			}

			public void ClearMapsForControllerInLayout(ControllerType controllerType, int controllerId, int layoutId, bool userAssignableOnly)
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return;
				}
				HENtlJpbLTfyvGNBdnYOTBUpGwmPA hENtlJpbLTfyvGNBdnYOTBUpGwmPA = yfZPVbkoNrPFYlhxRcQrxPzDLvft.QecjgvgRSXuPhnYvNrbSsHRqQwjg.AXLlayIlTwJqJNaNzeKccuszIcODb(controllerType);
				int num = hENtlJpbLTfyvGNBdnYOTBUpGwmPA.LwDtjAISpvZKUEBiCEPKHyoscvdr(controllerId);
				if (num >= 0)
				{
					hENtlJpbLTfyvGNBdnYOTBUpGwmPA.gmqWnmpZMnASuZpGLEqmJcwgXIqMA(num).ycfaKniCLOzZqlQviANrBfbEZIlRA().LHBNLdvxpgComlrFVgzujdYCEgEeA(layoutId, userAssignableOnly);
				}
			}

			public void ClearMapsForControllerInLayout(ControllerType controllerType, int controllerId, string layoutName, bool userAssignableOnly)
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return;
				}
				int layoutId = ReInput.mapping.GetLayoutId(controllerType, layoutName);
				if (layoutId >= 0)
				{
					ClearMapsForControllerInLayout(controllerType, controllerId, layoutId, userAssignableOnly);
				}
			}

			public void ClearAllMaps(bool userAssignableOnly)
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return;
				}
				for (int i = 0; i < yfZPVbkoNrPFYlhxRcQrxPzDLvft.QecjgvgRSXuPhnYvNrbSsHRqQwjg.KzSWyhVFpKvuMAleUEiVntIEyGZD; i++)
				{
					ClearMaps(yfZPVbkoNrPFYlhxRcQrxPzDLvft.QecjgvgRSXuPhnYvNrbSsHRqQwjg.JZVdeJdqcyVABFyDAQNnnsvkBpKvA(i), userAssignableOnly);
				}
			}

			public ActionElementMap GetFirstButtonMapWithAction(ControllerType controllerType, int controllerId, int actionId, bool skipDisabledMaps)
			{
				return GetFirstButtonMapWithAction(ReInput.controllers.GetController(controllerType, controllerId), actionId, skipDisabledMaps);
			}

			public ActionElementMap GetFirstButtonMapWithAction(ControllerType controllerType, int controllerId, string actionName, bool skipDisabledMaps)
			{
				return GetFirstButtonMapWithAction(ReInput.controllers.GetController(controllerType, controllerId), actionName, skipDisabledMaps);
			}

			public ActionElementMap GetFirstButtonMapWithAction(Controller controller, int actionId, bool skipDisabledMaps)
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return null;
				}
				if (controller == null)
				{
					return null;
				}
				return usRdUVNtlpekviYmKgGlTBAtYhRGA(controller.type, controller.id, actionId, skipDisabledMaps);
			}

			public ActionElementMap GetFirstButtonMapWithAction(Controller controller, string actionName, bool skipDisabledMaps)
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return null;
				}
				int actionId = ReInput.IsSPFehscBAmxtEADWGWuasjDvqf.GhVjGDQeDQmOWTnROakHcfdeCdDd(actionName);
				return GetFirstButtonMapWithAction(controller, actionId, skipDisabledMaps);
			}

			public ActionElementMap GetFirstButtonMapWithAction(ControllerType controllerType, int actionId, bool skipDisabledMaps)
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return null;
				}
				return yLoJdaQtNdSMCfHmRcQyBRUwAUAdb(controllerType, actionId, skipDisabledMaps);
			}

			public ActionElementMap GetFirstButtonMapWithAction(ControllerType controllerType, string actionName, bool skipDisabledMaps)
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return null;
				}
				int actionId = ReInput.IsSPFehscBAmxtEADWGWuasjDvqf.GhVjGDQeDQmOWTnROakHcfdeCdDd(actionName);
				return GetFirstButtonMapWithAction(controllerType, actionId, skipDisabledMaps);
			}

			public ActionElementMap GetFirstButtonMapWithAction(int actionId, bool skipDisabledMaps)
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return null;
				}
				if (actionId < 0)
				{
					return null;
				}
				for (int i = 0; i < yfZPVbkoNrPFYlhxRcQrxPzDLvft.QecjgvgRSXuPhnYvNrbSsHRqQwjg.KzSWyhVFpKvuMAleUEiVntIEyGZD; i++)
				{
					ActionElementMap actionElementMap = yLoJdaQtNdSMCfHmRcQyBRUwAUAdb(yfZPVbkoNrPFYlhxRcQrxPzDLvft.QecjgvgRSXuPhnYvNrbSsHRqQwjg.JZVdeJdqcyVABFyDAQNnnsvkBpKvA(i), actionId, skipDisabledMaps);
					if (actionElementMap != null)
					{
						return actionElementMap;
					}
				}
				return null;
			}

			public ActionElementMap GetFirstButtonMapWithAction(string actionName, bool skipDisabledMaps)
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return null;
				}
				int actionId = ReInput.IsSPFehscBAmxtEADWGWuasjDvqf.GhVjGDQeDQmOWTnROakHcfdeCdDd(actionName);
				return GetFirstButtonMapWithAction(actionId, skipDisabledMaps);
			}

			public IEnumerable<ActionElementMap> ButtonMapsWithAction(ControllerType controllerType, int controllerId, int actionId, bool skipDisabledMaps)
			{
				return ButtonMapsWithAction(ReInput.controllers.GetController(controllerType, controllerId), actionId, skipDisabledMaps);
			}

			public IEnumerable<ActionElementMap> ButtonMapsWithAction(ControllerType controllerType, int controllerId, string actionName, bool skipDisabledMaps)
			{
				return ButtonMapsWithAction(ReInput.controllers.GetController(controllerType, controllerId), actionName, skipDisabledMaps);
			}

			public IEnumerable<ActionElementMap> ButtonMapsWithAction(Controller controller, int actionId, bool skipDisabledMaps)
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
				}
				if (controller == null)
				{
					return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
				}
				return LFfZoDgrOGvkQeMlHdpjHFTIKaAw(controller.type, controller.id, actionId, skipDisabledMaps);
			}

			public IEnumerable<ActionElementMap> ButtonMapsWithAction(Controller controller, string actionName, bool skipDisabledMaps)
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
				}
				int actionId = ReInput.IsSPFehscBAmxtEADWGWuasjDvqf.GhVjGDQeDQmOWTnROakHcfdeCdDd(actionName);
				return ButtonMapsWithAction(controller, actionId, skipDisabledMaps);
			}

			public IEnumerable<ActionElementMap> ButtonMapsWithAction(ControllerType controllerType, int actionId, bool skipDisabledMaps)
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
				}
				return ntPtqlJMDiemaqynptpdOUPEfmic(controllerType, actionId, skipDisabledMaps);
			}

			public IEnumerable<ActionElementMap> ButtonMapsWithAction(ControllerType controllerType, string actionName, bool skipDisabledMaps)
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
				}
				int actionId = ReInput.IsSPFehscBAmxtEADWGWuasjDvqf.GhVjGDQeDQmOWTnROakHcfdeCdDd(actionName);
				return ButtonMapsWithAction(controllerType, actionId, skipDisabledMaps);
			}

			[IteratorStateMachine(typeof(oDywNiLrsnpTCKUGcRvUVGooIcXM))]
			public IEnumerable<ActionElementMap> ButtonMapsWithAction(int actionId, bool skipDisabledMaps)
			{
				return new oDywNiLrsnpTCKUGcRvUVGooIcXM(-2)
				{
					frCaibBsGENeEpZKfNTNXCvOjWeQ = this,
					xUEamCaOJbHwKYCqrKNjpvmYssOKA = actionId,
					JgjxqGTgEGErfzqTZbKCADQvzrYl = skipDisabledMaps
				};
			}

			public IEnumerable<ActionElementMap> ButtonMapsWithAction(string actionName, bool skipDisabledMaps)
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
				}
				int actionId = ReInput.IsSPFehscBAmxtEADWGWuasjDvqf.GhVjGDQeDQmOWTnROakHcfdeCdDd(actionName);
				return ButtonMapsWithAction(actionId, skipDisabledMaps);
			}

			public int GetButtonMapsWithAction(ControllerType controllerType, int controllerId, int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
			{
				return GetButtonMapsWithAction(ReInput.controllers.GetController(controllerType, controllerId), actionId, skipDisabledMaps, results);
			}

			public int GetButtonMapsWithAction(ControllerType controllerType, int controllerId, string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
			{
				return GetButtonMapsWithAction(ReInput.controllers.GetController(controllerType, controllerId), actionName, skipDisabledMaps, results);
			}

			public int GetButtonMapsWithAction(Controller controller, int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return 0;
				}
				if (results == null)
				{
					throw new ArgumentNullException("results");
				}
				if (controller == null)
				{
					results.Clear();
					return 0;
				}
				return fRvraWYGgBYlXMCRcBNxMEzMVDqk(controller.type, controller.id, actionId, skipDisabledMaps, results, false);
			}

			public int GetButtonMapsWithAction(Controller controller, string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return 0;
				}
				int actionId = ReInput.IsSPFehscBAmxtEADWGWuasjDvqf.GhVjGDQeDQmOWTnROakHcfdeCdDd(actionName);
				return GetButtonMapsWithAction(controller, actionId, skipDisabledMaps, results);
			}

			public int GetButtonMapsWithAction(ControllerType controllerType, int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return 0;
				}
				return WgSlUhwJkOpDTPILMhPrMXfCFsEHA(controllerType, actionId, skipDisabledMaps, results, false);
			}

			public int GetButtonMapsWithAction(ControllerType controllerType, string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return 0;
				}
				int actionId = ReInput.IsSPFehscBAmxtEADWGWuasjDvqf.GhVjGDQeDQmOWTnROakHcfdeCdDd(actionName);
				return GetButtonMapsWithAction(controllerType, actionId, skipDisabledMaps, results);
			}

			public int GetButtonMapsWithAction(int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
			{
				return vcLOsrJCMpezNhbtErqdNNKZoAHG(actionId, skipDisabledMaps, results, false);
			}

			public int GetButtonMapsWithAction(string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return 0;
				}
				int actionId = ReInput.IsSPFehscBAmxtEADWGWuasjDvqf.GhVjGDQeDQmOWTnROakHcfdeCdDd(actionName);
				return GetButtonMapsWithAction(actionId, skipDisabledMaps, results);
			}

			public ActionElementMap GetFirstAxisMapWithAction(ControllerType controllerType, int controllerId, int actionId, bool skipDisabledMaps)
			{
				return GetFirstAxisMapWithAction(ReInput.controllers.GetController(controllerType, controllerId), actionId, skipDisabledMaps);
			}

			public ActionElementMap GetFirstAxisMapWithAction(ControllerType controllerType, int controllerId, string actionName, bool skipDisabledMaps)
			{
				return GetFirstAxisMapWithAction(ReInput.controllers.GetController(controllerType, controllerId), actionName, skipDisabledMaps);
			}

			public ActionElementMap GetFirstAxisMapWithAction(Controller controller, int actionId, bool skipDisabledMaps)
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return null;
				}
				if (controller == null)
				{
					return null;
				}
				return CHRDofdHyzyjtvKqlobJXsVKGJlhA(controller.type, controller.id, actionId, skipDisabledMaps);
			}

			public ActionElementMap GetFirstAxisMapWithAction(Controller controller, string actionName, bool skipDisabledMaps)
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return null;
				}
				int actionId = ReInput.IsSPFehscBAmxtEADWGWuasjDvqf.GhVjGDQeDQmOWTnROakHcfdeCdDd(actionName);
				return GetFirstAxisMapWithAction(controller, actionId, skipDisabledMaps);
			}

			public ActionElementMap GetFirstAxisMapWithAction(ControllerType controllerType, int actionId, bool skipDisabledMaps)
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return null;
				}
				return AJWCJtngsczmLwoCkxfjREIDmPhe(controllerType, actionId, skipDisabledMaps);
			}

			public ActionElementMap GetFirstAxisMapWithAction(ControllerType controllerType, string actionName, bool skipDisabledMaps)
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return null;
				}
				int actionId = ReInput.IsSPFehscBAmxtEADWGWuasjDvqf.GhVjGDQeDQmOWTnROakHcfdeCdDd(actionName);
				return GetFirstAxisMapWithAction(controllerType, actionId, skipDisabledMaps);
			}

			public ActionElementMap GetFirstAxisMapWithAction(int actionId, bool skipDisabledMaps)
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return null;
				}
				if (actionId < 0)
				{
					return null;
				}
				for (int i = 0; i < yfZPVbkoNrPFYlhxRcQrxPzDLvft.QecjgvgRSXuPhnYvNrbSsHRqQwjg.KzSWyhVFpKvuMAleUEiVntIEyGZD; i++)
				{
					ActionElementMap actionElementMap = AJWCJtngsczmLwoCkxfjREIDmPhe(yfZPVbkoNrPFYlhxRcQrxPzDLvft.QecjgvgRSXuPhnYvNrbSsHRqQwjg.JZVdeJdqcyVABFyDAQNnnsvkBpKvA(i), actionId, skipDisabledMaps);
					if (actionElementMap != null)
					{
						return actionElementMap;
					}
				}
				return null;
			}

			public ActionElementMap GetFirstAxisMapWithAction(string actionName, bool skipDisabledMaps)
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return null;
				}
				int actionId = ReInput.IsSPFehscBAmxtEADWGWuasjDvqf.GhVjGDQeDQmOWTnROakHcfdeCdDd(actionName);
				return GetFirstAxisMapWithAction(actionId, skipDisabledMaps);
			}

			public IEnumerable<ActionElementMap> AxisMapsWithAction(ControllerType controllerType, int controllerId, int actionId, bool skipDisabledMaps)
			{
				return AxisMapsWithAction(ReInput.controllers.GetController(controllerType, controllerId), actionId, skipDisabledMaps);
			}

			public IEnumerable<ActionElementMap> AxisMapsWithAction(ControllerType controllerType, int controllerId, string actionName, bool skipDisabledMaps)
			{
				return AxisMapsWithAction(ReInput.controllers.GetController(controllerType, controllerId), actionName, skipDisabledMaps);
			}

			public IEnumerable<ActionElementMap> AxisMapsWithAction(Controller controller, int actionId, bool skipDisabledMaps)
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
				}
				if (controller == null)
				{
					return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
				}
				return RhpIuDYeuZAoRkwJPkNNfkELyKcBA(controller.type, controller.id, actionId, skipDisabledMaps);
			}

			public IEnumerable<ActionElementMap> AxisMapsWithAction(Controller controller, string actionName, bool skipDisabledMaps)
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
				}
				int actionId = ReInput.IsSPFehscBAmxtEADWGWuasjDvqf.GhVjGDQeDQmOWTnROakHcfdeCdDd(actionName);
				return AxisMapsWithAction(controller, actionId, skipDisabledMaps);
			}

			public IEnumerable<ActionElementMap> AxisMapsWithAction(ControllerType controllerType, int actionId, bool skipDisabledMaps)
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
				}
				return tRglqBggiWgbJjZlawtGJqRwhGCMA(controllerType, actionId, skipDisabledMaps);
			}

			public IEnumerable<ActionElementMap> AxisMapsWithAction(ControllerType controllerType, string actionName, bool skipDisabledMaps)
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
				}
				int actionId = ReInput.IsSPFehscBAmxtEADWGWuasjDvqf.GhVjGDQeDQmOWTnROakHcfdeCdDd(actionName);
				return AxisMapsWithAction(controllerType, actionId, skipDisabledMaps);
			}

			[IteratorStateMachine(typeof(vsUITgsSOznaUGQdaMfHnKvmtAdO))]
			public IEnumerable<ActionElementMap> AxisMapsWithAction(int actionId, bool skipDisabledMaps)
			{
				return new vsUITgsSOznaUGQdaMfHnKvmtAdO(-2)
				{
					zsoKbYAMxYaopWchKiTVtZfoIgLd = this,
					TRWvXZQznVyisGxseqYRFDOoBIUi = actionId,
					lUfeVmnxJBMRSNQXvXpLhERHEeJL = skipDisabledMaps
				};
			}

			public IEnumerable<ActionElementMap> AxisMapsWithAction(string actionName, bool skipDisabledMaps)
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
				}
				int actionId = ReInput.IsSPFehscBAmxtEADWGWuasjDvqf.GhVjGDQeDQmOWTnROakHcfdeCdDd(actionName);
				return AxisMapsWithAction(actionId, skipDisabledMaps);
			}

			public int GetAxisMapsWithAction(ControllerType controllerType, int controllerId, int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
			{
				return GetAxisMapsWithAction(ReInput.controllers.GetController(controllerType, controllerId), actionId, skipDisabledMaps, results);
			}

			public int GetAxisMapsWithAction(ControllerType controllerType, int controllerId, string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
			{
				return GetAxisMapsWithAction(ReInput.controllers.GetController(controllerType, controllerId), actionName, skipDisabledMaps, results);
			}

			public int GetAxisMapsWithAction(Controller controller, int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return 0;
				}
				if (controller == null)
				{
					return 0;
				}
				return DYRcLiwhMwCsbENjRBapydzPyAVuA(controller.type, controller.id, actionId, skipDisabledMaps, results, false);
			}

			public int GetAxisMapsWithAction(Controller controller, string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return 0;
				}
				int actionId = ReInput.IsSPFehscBAmxtEADWGWuasjDvqf.GhVjGDQeDQmOWTnROakHcfdeCdDd(actionName);
				return GetAxisMapsWithAction(controller, actionId, skipDisabledMaps, results);
			}

			public int GetAxisMapsWithAction(ControllerType controllerType, int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return 0;
				}
				if (results == null)
				{
					throw new ArgumentNullException("results");
				}
				return sNcOltfbTVzJamtVloDmREztcLbW(controllerType, actionId, skipDisabledMaps, results, false);
			}

			public int GetAxisMapsWithAction(ControllerType controllerType, string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return 0;
				}
				int actionId = ReInput.IsSPFehscBAmxtEADWGWuasjDvqf.GhVjGDQeDQmOWTnROakHcfdeCdDd(actionName);
				return GetAxisMapsWithAction(controllerType, actionId, skipDisabledMaps, results);
			}

			public int GetAxisMapsWithAction(int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
			{
				return dkcSkzhUSuysAuoepIjClOLfkCfd(actionId, skipDisabledMaps, results, false);
			}

			public int GetAxisMapsWithAction(string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return 0;
				}
				int actionId = ReInput.IsSPFehscBAmxtEADWGWuasjDvqf.GhVjGDQeDQmOWTnROakHcfdeCdDd(actionName);
				return GetAxisMapsWithAction(actionId, skipDisabledMaps, results);
			}

			public ActionElementMap GetFirstElementMapWithAction(ControllerType controllerType, int controllerId, int actionId, bool skipDisabledMaps)
			{
				return GetFirstElementMapWithAction(ReInput.controllers.GetController(controllerType, controllerId), actionId, skipDisabledMaps);
			}

			public ActionElementMap GetFirstElementMapWithAction(ControllerType controllerType, int controllerId, string actionName, bool skipDisabledMaps)
			{
				return GetFirstElementMapWithAction(ReInput.controllers.GetController(controllerType, controllerId), actionName, skipDisabledMaps);
			}

			public ActionElementMap GetFirstElementMapWithAction(Controller controller, int actionId, bool skipDisabledMaps)
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return null;
				}
				if (controller == null)
				{
					return null;
				}
				return kdArDGRjlYbYjUxerZUCaNQAEHiO(controller.type, controller.id, actionId, skipDisabledMaps);
			}

			public ActionElementMap GetFirstElementMapWithAction(Controller controller, string actionName, bool skipDisabledMaps)
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return null;
				}
				int actionId = ReInput.IsSPFehscBAmxtEADWGWuasjDvqf.GhVjGDQeDQmOWTnROakHcfdeCdDd(actionName);
				return GetFirstElementMapWithAction(controller, actionId, skipDisabledMaps);
			}

			public ActionElementMap GetFirstElementMapWithAction(ControllerType controllerType, int actionId, bool skipDisabledMaps)
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return null;
				}
				return ccweTNqYETnxFaKlVxThBFWqDMEA(controllerType, actionId, skipDisabledMaps);
			}

			public ActionElementMap GetFirstElementMapWithAction(ControllerType controllerType, string actionName, bool skipDisabledMaps)
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return null;
				}
				int actionId = ReInput.IsSPFehscBAmxtEADWGWuasjDvqf.GhVjGDQeDQmOWTnROakHcfdeCdDd(actionName);
				return GetFirstElementMapWithAction(controllerType, actionId, skipDisabledMaps);
			}

			public ActionElementMap GetFirstElementMapWithAction(int actionId, bool skipDisabledMaps)
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return null;
				}
				if (actionId < 0)
				{
					return null;
				}
				for (int i = 0; i < yfZPVbkoNrPFYlhxRcQrxPzDLvft.QecjgvgRSXuPhnYvNrbSsHRqQwjg.KzSWyhVFpKvuMAleUEiVntIEyGZD; i++)
				{
					ActionElementMap actionElementMap = ccweTNqYETnxFaKlVxThBFWqDMEA(yfZPVbkoNrPFYlhxRcQrxPzDLvft.QecjgvgRSXuPhnYvNrbSsHRqQwjg.JZVdeJdqcyVABFyDAQNnnsvkBpKvA(i), actionId, skipDisabledMaps);
					if (actionElementMap != null)
					{
						return actionElementMap;
					}
				}
				return null;
			}

			public ActionElementMap GetFirstElementMapWithAction(string actionName, bool skipDisabledMaps)
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return null;
				}
				int actionId = ReInput.IsSPFehscBAmxtEADWGWuasjDvqf.GhVjGDQeDQmOWTnROakHcfdeCdDd(actionName);
				return GetFirstElementMapWithAction(actionId, skipDisabledMaps);
			}

			public IEnumerable<ActionElementMap> ElementMapsWithAction(ControllerType controllerType, int controllerId, int actionId, bool skipDisabledMaps)
			{
				return ElementMapsWithAction(ReInput.controllers.GetController(controllerType, controllerId), actionId, skipDisabledMaps);
			}

			public IEnumerable<ActionElementMap> ElementMapsWithAction(ControllerType controllerType, int controllerId, string actionName, bool skipDisabledMaps)
			{
				return ElementMapsWithAction(ReInput.controllers.GetController(controllerType, controllerId), actionName, skipDisabledMaps);
			}

			public IEnumerable<ActionElementMap> ElementMapsWithAction(Controller controller, int actionId, bool skipDisabledMaps)
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
				}
				if (controller == null)
				{
					return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
				}
				return RQhrwxjzgUwkwcswpaywGnkAcpNI(controller.type, controller.id, actionId, skipDisabledMaps);
			}

			public IEnumerable<ActionElementMap> ElementMapsWithAction(Controller controller, string actionName, bool skipDisabledMaps)
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
				}
				int actionId = ReInput.IsSPFehscBAmxtEADWGWuasjDvqf.GhVjGDQeDQmOWTnROakHcfdeCdDd(actionName);
				return ElementMapsWithAction(controller, actionId, skipDisabledMaps);
			}

			public IEnumerable<ActionElementMap> ElementMapsWithAction(ControllerType controllerType, int actionId, bool skipDisabledMaps)
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
				}
				return HyvrKAXTuqZdVUMugpAEAFWfwlQA(controllerType, actionId, skipDisabledMaps);
			}

			public IEnumerable<ActionElementMap> ElementMapsWithAction(ControllerType controllerType, string actionName, bool skipDisabledMaps)
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
				}
				int actionId = ReInput.IsSPFehscBAmxtEADWGWuasjDvqf.GhVjGDQeDQmOWTnROakHcfdeCdDd(actionName);
				return ElementMapsWithAction(controllerType, actionId, skipDisabledMaps);
			}

			[IteratorStateMachine(typeof(UpqJxxMTJWtBLnyKstpEAoGxAJVJA))]
			public IEnumerable<ActionElementMap> ElementMapsWithAction(int actionId, bool skipDisabledMaps)
			{
				return new UpqJxxMTJWtBLnyKstpEAoGxAJVJA(-2)
				{
					QDfGhixisaykEbjkHipWLwAlqpou = this,
					nWdhVBKTZGgYnuzRqQCQtNjeARbh = actionId,
					wlTBceKxCEngMrpVowSALZrsgJGJ = skipDisabledMaps
				};
			}

			public IEnumerable<ActionElementMap> ElementMapsWithAction(string actionName, bool skipDisabledMaps)
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
				}
				int actionId = ReInput.IsSPFehscBAmxtEADWGWuasjDvqf.GhVjGDQeDQmOWTnROakHcfdeCdDd(actionName);
				return ElementMapsWithAction(actionId, skipDisabledMaps);
			}

			public int GetElementMapsWithAction(ControllerType controllerType, int controllerId, int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
			{
				return GetElementMapsWithAction(ReInput.controllers.GetController(controllerType, controllerId), actionId, skipDisabledMaps, results);
			}

			public int GetElementMapsWithAction(ControllerType controllerType, int controllerId, string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
			{
				return GetElementMapsWithAction(ReInput.controllers.GetController(controllerType, controllerId), actionName, skipDisabledMaps, results);
			}

			public int GetElementMapsWithAction(Controller controller, int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return 0;
				}
				if (controller == null)
				{
					return 0;
				}
				return TWTojCbaRiqLNeUGhIsovwvzsqLt(controller.type, controller.id, actionId, skipDisabledMaps, results, false);
			}

			public int GetElementMapsWithAction(Controller controller, string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return 0;
				}
				int actionId = ReInput.IsSPFehscBAmxtEADWGWuasjDvqf.GhVjGDQeDQmOWTnROakHcfdeCdDd(actionName);
				return GetElementMapsWithAction(controller, actionId, skipDisabledMaps, results);
			}

			public int GetElementMapsWithAction(ControllerType controllerType, int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return 0;
				}
				return eqBMyUkWIMfTxaNYWgNixcUGbOWz(controllerType, actionId, skipDisabledMaps, results, false);
			}

			public int GetElementMapsWithAction(ControllerType controllerType, string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return 0;
				}
				int actionId = ReInput.IsSPFehscBAmxtEADWGWuasjDvqf.GhVjGDQeDQmOWTnROakHcfdeCdDd(actionName);
				return GetElementMapsWithAction(controllerType, actionId, skipDisabledMaps, results);
			}

			public int GetElementMapsWithAction(int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
			{
				return yoiqMrqtvTnbqBoCrBwDPVRveWpA(actionId, skipDisabledMaps, results, false);
			}

			public int GetElementMapsWithAction(string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return 0;
				}
				int actionId = ReInput.IsSPFehscBAmxtEADWGWuasjDvqf.GhVjGDQeDQmOWTnROakHcfdeCdDd(actionName);
				return GetElementMapsWithAction(actionId, skipDisabledMaps, results);
			}

			public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(ControllerElementTarget elementTarget, bool skipDisabledMaps)
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
				}
				edomyHoabKkWzxLwelGsLkZrDlzw edomyHoabKkWzxLwelGsLkZrDlzw2 = edomyHoabKkWzxLwelGsLkZrDlzw.YrulkGTOzpYsHraDBHAumBfMBGzd(elementTarget);
				IEnumerable<ActionElementMap> result = ElementMapsWithElementTarget(edomyHoabKkWzxLwelGsLkZrDlzw2, skipDisabledMaps);
				edomyHoabKkWzxLwelGsLkZrDlzw.ZQnGowaWMdKIQroVeeRgAzvXTUJX(edomyHoabKkWzxLwelGsLkZrDlzw2);
				return result;
			}

			public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(IControllerElementTarget elementTarget, bool skipDisabledMaps)
			{
				return FCSWvffQAyhCYYvZSwnJYbPdcyac(elementTarget, false, -1, skipDisabledMaps);
			}

			public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(ControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps)
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
				}
				edomyHoabKkWzxLwelGsLkZrDlzw edomyHoabKkWzxLwelGsLkZrDlzw2 = edomyHoabKkWzxLwelGsLkZrDlzw.YrulkGTOzpYsHraDBHAumBfMBGzd(elementTarget);
				IEnumerable<ActionElementMap> result = ElementMapsWithElementTarget(edomyHoabKkWzxLwelGsLkZrDlzw2, actionId, skipDisabledMaps);
				edomyHoabKkWzxLwelGsLkZrDlzw.ZQnGowaWMdKIQroVeeRgAzvXTUJX(edomyHoabKkWzxLwelGsLkZrDlzw2);
				return result;
			}

			public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(ControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps)
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
				}
				int actionId = ReInput.IsSPFehscBAmxtEADWGWuasjDvqf.GhVjGDQeDQmOWTnROakHcfdeCdDd(actionName);
				return ElementMapsWithElementTarget(elementTarget, actionId, skipDisabledMaps);
			}

			public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(IControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps)
			{
				return FCSWvffQAyhCYYvZSwnJYbPdcyac(elementTarget, true, actionId, skipDisabledMaps);
			}

			public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(IControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps)
			{
				int actionId = ReInput.IsSPFehscBAmxtEADWGWuasjDvqf.GhVjGDQeDQmOWTnROakHcfdeCdDd(actionName);
				return ElementMapsWithElementTarget(elementTarget, actionId, skipDisabledMaps);
			}

			public ActionElementMap GetFirstElementMapWithElementTarget(ControllerElementTarget elementTarget, bool skipDisabledMaps)
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return null;
				}
				edomyHoabKkWzxLwelGsLkZrDlzw edomyHoabKkWzxLwelGsLkZrDlzw2 = edomyHoabKkWzxLwelGsLkZrDlzw.YrulkGTOzpYsHraDBHAumBfMBGzd(elementTarget);
				ActionElementMap firstElementMapWithElementTarget = GetFirstElementMapWithElementTarget(edomyHoabKkWzxLwelGsLkZrDlzw2, skipDisabledMaps);
				edomyHoabKkWzxLwelGsLkZrDlzw.ZQnGowaWMdKIQroVeeRgAzvXTUJX(edomyHoabKkWzxLwelGsLkZrDlzw2);
				return firstElementMapWithElementTarget;
			}

			public ActionElementMap GetFirstElementMapWithElementTarget(IControllerElementTarget elementTarget, bool skipDisabledMaps)
			{
				return edvSzOstfCAhDhjsBGBNjOrqpKCuA(elementTarget, false, -1, skipDisabledMaps);
			}

			public ActionElementMap GetFirstElementMapWithElementTarget(ControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps)
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return null;
				}
				edomyHoabKkWzxLwelGsLkZrDlzw edomyHoabKkWzxLwelGsLkZrDlzw2 = edomyHoabKkWzxLwelGsLkZrDlzw.YrulkGTOzpYsHraDBHAumBfMBGzd(elementTarget);
				ActionElementMap firstElementMapWithElementTarget = GetFirstElementMapWithElementTarget(edomyHoabKkWzxLwelGsLkZrDlzw2, actionId, skipDisabledMaps);
				edomyHoabKkWzxLwelGsLkZrDlzw.ZQnGowaWMdKIQroVeeRgAzvXTUJX(edomyHoabKkWzxLwelGsLkZrDlzw2);
				return firstElementMapWithElementTarget;
			}

			public ActionElementMap GetFirstElementMapWithElementTarget(ControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps)
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return null;
				}
				int actionId = ReInput.IsSPFehscBAmxtEADWGWuasjDvqf.GhVjGDQeDQmOWTnROakHcfdeCdDd(actionName);
				return GetFirstElementMapWithElementTarget(elementTarget, actionId, skipDisabledMaps);
			}

			public ActionElementMap GetFirstElementMapWithElementTarget(IControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps)
			{
				return edvSzOstfCAhDhjsBGBNjOrqpKCuA(elementTarget, true, actionId, skipDisabledMaps);
			}

			public ActionElementMap GetFirstElementMapWithElementTarget(IControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps)
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return null;
				}
				int actionId = ReInput.IsSPFehscBAmxtEADWGWuasjDvqf.GhVjGDQeDQmOWTnROakHcfdeCdDd(actionName);
				return GetFirstElementMapWithElementTarget(elementTarget, actionId, skipDisabledMaps);
			}

			public int GetElementMapsWithElementTarget(ControllerElementTarget elementTarget, bool skipDisabledMaps, List<ActionElementMap> results)
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return 0;
				}
				edomyHoabKkWzxLwelGsLkZrDlzw edomyHoabKkWzxLwelGsLkZrDlzw2 = edomyHoabKkWzxLwelGsLkZrDlzw.YrulkGTOzpYsHraDBHAumBfMBGzd(elementTarget);
				int elementMapsWithElementTarget = GetElementMapsWithElementTarget(edomyHoabKkWzxLwelGsLkZrDlzw2, skipDisabledMaps, results);
				edomyHoabKkWzxLwelGsLkZrDlzw.ZQnGowaWMdKIQroVeeRgAzvXTUJX(edomyHoabKkWzxLwelGsLkZrDlzw2);
				return elementMapsWithElementTarget;
			}

			public int GetElementMapsWithElementTarget(IControllerElementTarget elementTarget, bool skipDisabledMaps, List<ActionElementMap> results)
			{
				return GoLytIiqPNbvkEBgVtsXddPDOyCv(elementTarget, false, -1, skipDisabledMaps, results, false);
			}

			public int GetElementMapsWithElementTarget(ControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return 0;
				}
				edomyHoabKkWzxLwelGsLkZrDlzw edomyHoabKkWzxLwelGsLkZrDlzw2 = edomyHoabKkWzxLwelGsLkZrDlzw.YrulkGTOzpYsHraDBHAumBfMBGzd(elementTarget);
				int elementMapsWithElementTarget = GetElementMapsWithElementTarget(edomyHoabKkWzxLwelGsLkZrDlzw2, actionId, skipDisabledMaps, results);
				edomyHoabKkWzxLwelGsLkZrDlzw.ZQnGowaWMdKIQroVeeRgAzvXTUJX(edomyHoabKkWzxLwelGsLkZrDlzw2);
				return elementMapsWithElementTarget;
			}

			public int GetElementMapsWithElementTarget(ControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return 0;
				}
				int actionId = ReInput.IsSPFehscBAmxtEADWGWuasjDvqf.GhVjGDQeDQmOWTnROakHcfdeCdDd(actionName);
				return GetElementMapsWithElementTarget(elementTarget, actionId, skipDisabledMaps, results);
			}

			public int GetElementMapsWithElementTarget(IControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
			{
				return GoLytIiqPNbvkEBgVtsXddPDOyCv(elementTarget, true, actionId, skipDisabledMaps, results, false);
			}

			public int GetElementMapsWithElementTarget(IControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return 0;
				}
				int actionId = ReInput.IsSPFehscBAmxtEADWGWuasjDvqf.GhVjGDQeDQmOWTnROakHcfdeCdDd(actionName);
				return GetElementMapsWithElementTarget(elementTarget, actionId, skipDisabledMaps, results);
			}

			public T[] GetMapSaveData<T>(int controllerId, bool userAssignableMapsOnly) where T : ControllerMapSaveData
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return EmptyObjects<T>.array;
				}
				return UVHdENLjLbffFrtXXukhfyYpTvHw<T>(controllerId, userAssignableMapsOnly);
			}

			public ControllerMapSaveData[] GetMapSaveData(ControllerType controllerType, int controllerId, bool userAssignableMapsOnly)
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return EmptyObjects<ControllerMapSaveData>.array;
				}
				return sdBijFKEPCckQsXvzEERtGVYaLzX(controllerType, controllerId, userAssignableMapsOnly);
			}

			public T[] GetAllMapSaveData<T>(bool userAssignableMapsOnly) where T : ControllerMapSaveData
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return EmptyObjects<T>.array;
				}
				return BtkclxjWILzBcNoowcVYXwgEpIQs<T>(userAssignableMapsOnly);
			}

			public ControllerMapSaveData[] GetAllMapSaveData(ControllerType controllerType, bool userAssignableMapsOnly)
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return EmptyObjects<ControllerMapSaveData>.array;
				}
				return tdpIgdWfusqMpviutmSAumzYgnmj(controllerType, userAssignableMapsOnly);
			}

			public ControllerMapSaveData[] GetAllMapSaveData(bool userAssignableMapsOnly)
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return EmptyObjects<ControllerMapSaveData>.array;
				}
				ControllerMapSaveData[] array = null;
				for (int i = 0; i < yfZPVbkoNrPFYlhxRcQrxPzDLvft.QecjgvgRSXuPhnYvNrbSsHRqQwjg.KzSWyhVFpKvuMAleUEiVntIEyGZD; i++)
				{
					ArrayTools.Combine(ref array, tdpIgdWfusqMpviutmSAumzYgnmj(yfZPVbkoNrPFYlhxRcQrxPzDLvft.QecjgvgRSXuPhnYvNrbSsHRqQwjg.JZVdeJdqcyVABFyDAQNnnsvkBpKvA(i), userAssignableMapsOnly));
				}
				return array;
			}

			public int SetAllMapsEnabled(bool state)
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return 0;
				}
				int num = 0;
				int kzSWyhVFpKvuMAleUEiVntIEyGZD = yfZPVbkoNrPFYlhxRcQrxPzDLvft.QecjgvgRSXuPhnYvNrbSsHRqQwjg.KzSWyhVFpKvuMAleUEiVntIEyGZD;
				for (int i = 0; i < kzSWyhVFpKvuMAleUEiVntIEyGZD; i++)
				{
					HENtlJpbLTfyvGNBdnYOTBUpGwmPA hENtlJpbLTfyvGNBdnYOTBUpGwmPA = yfZPVbkoNrPFYlhxRcQrxPzDLvft.QecjgvgRSXuPhnYvNrbSsHRqQwjg.AMmiEUMJUxmCKCltvrDeLoaPvEGE(i);
					int num2 = hENtlJpbLTfyvGNBdnYOTBUpGwmPA.rphZqyUfbdoINyXndGfDbQaiIHFM();
					for (int j = 0; j < num2; j++)
					{
						num += hENtlJpbLTfyvGNBdnYOTBUpGwmPA.gmqWnmpZMnASuZpGLEqmJcwgXIqMA(j).ycfaKniCLOzZqlQviANrBfbEZIlRA().sjaxFGDNyBijCGaKKblvPrSxHjhs(state);
					}
				}
				return num;
			}

			public int SetAllMapsEnabled(bool state, ControllerType controllerType)
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return 0;
				}
				int num = 0;
				HENtlJpbLTfyvGNBdnYOTBUpGwmPA hENtlJpbLTfyvGNBdnYOTBUpGwmPA = yfZPVbkoNrPFYlhxRcQrxPzDLvft.QecjgvgRSXuPhnYvNrbSsHRqQwjg.AXLlayIlTwJqJNaNzeKccuszIcODb(controllerType);
				int num2 = hENtlJpbLTfyvGNBdnYOTBUpGwmPA.rphZqyUfbdoINyXndGfDbQaiIHFM();
				for (int i = 0; i < num2; i++)
				{
					num += hENtlJpbLTfyvGNBdnYOTBUpGwmPA.gmqWnmpZMnASuZpGLEqmJcwgXIqMA(i).ycfaKniCLOzZqlQviANrBfbEZIlRA().sjaxFGDNyBijCGaKKblvPrSxHjhs(state);
				}
				return num;
			}

			public int SetAllMapsEnabled(bool state, Controller controller)
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return 0;
				}
				if (controller == null)
				{
					return 0;
				}
				return SetAllMapsEnabled(state, controller.type, controller.id);
			}

			public int SetAllMapsEnabled(bool state, ControllerType controllerType, int controllerId)
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return 0;
				}
				return yfZPVbkoNrPFYlhxRcQrxPzDLvft.QecjgvgRSXuPhnYvNrbSsHRqQwjg.AXLlayIlTwJqJNaNzeKccuszIcODb(controllerType).EiaJdcLRNPgisAQlXkogBqWdcrPqb(controllerId)?.ycfaKniCLOzZqlQviANrBfbEZIlRA().sjaxFGDNyBijCGaKKblvPrSxHjhs(state) ?? 0;
			}

			public int SetMapsEnabled(bool state, int categoryId)
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return 0;
				}
				if (categoryId < 0)
				{
					return 0;
				}
				int num = 0;
				int kzSWyhVFpKvuMAleUEiVntIEyGZD = yfZPVbkoNrPFYlhxRcQrxPzDLvft.QecjgvgRSXuPhnYvNrbSsHRqQwjg.KzSWyhVFpKvuMAleUEiVntIEyGZD;
				for (int i = 0; i < kzSWyhVFpKvuMAleUEiVntIEyGZD; i++)
				{
					HENtlJpbLTfyvGNBdnYOTBUpGwmPA hENtlJpbLTfyvGNBdnYOTBUpGwmPA = yfZPVbkoNrPFYlhxRcQrxPzDLvft.QecjgvgRSXuPhnYvNrbSsHRqQwjg.AMmiEUMJUxmCKCltvrDeLoaPvEGE(i);
					int num2 = hENtlJpbLTfyvGNBdnYOTBUpGwmPA.rphZqyUfbdoINyXndGfDbQaiIHFM();
					for (int j = 0; j < num2; j++)
					{
						num += hENtlJpbLTfyvGNBdnYOTBUpGwmPA.gmqWnmpZMnASuZpGLEqmJcwgXIqMA(j).ycfaKniCLOzZqlQviANrBfbEZIlRA().GCexcUhSTjMbOjzZJesLIEkQBKFD(state, categoryId);
					}
				}
				return num;
			}

			public int SetMapsEnabled(bool state, string categoryName)
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return 0;
				}
				int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
				if (mapCategoryId < 0)
				{
					return 0;
				}
				return SetMapsEnabled(state, mapCategoryId);
			}

			public int SetMapsEnabled(bool state, string categoryName, string layoutName)
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return 0;
				}
				int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
				if (mapCategoryId < 0)
				{
					return 0;
				}
				int num = 0;
				int kzSWyhVFpKvuMAleUEiVntIEyGZD = yfZPVbkoNrPFYlhxRcQrxPzDLvft.QecjgvgRSXuPhnYvNrbSsHRqQwjg.KzSWyhVFpKvuMAleUEiVntIEyGZD;
				for (int i = 0; i < kzSWyhVFpKvuMAleUEiVntIEyGZD; i++)
				{
					ControllerType controllerType = yfZPVbkoNrPFYlhxRcQrxPzDLvft.QecjgvgRSXuPhnYvNrbSsHRqQwjg.JZVdeJdqcyVABFyDAQNnnsvkBpKvA(i);
					int layoutId = ReInput.mapping.GetLayoutId(controllerType, layoutName);
					if (layoutId >= 0)
					{
						num += SetMapsEnabled(state, controllerType, mapCategoryId, layoutId);
					}
				}
				return num;
			}

			public int SetMapsEnabled(bool state, ControllerType controllerType, int categoryId)
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return 0;
				}
				if (categoryId < 0)
				{
					return 0;
				}
				int num = 0;
				HENtlJpbLTfyvGNBdnYOTBUpGwmPA hENtlJpbLTfyvGNBdnYOTBUpGwmPA = yfZPVbkoNrPFYlhxRcQrxPzDLvft.QecjgvgRSXuPhnYvNrbSsHRqQwjg.AXLlayIlTwJqJNaNzeKccuszIcODb(controllerType);
				int num2 = hENtlJpbLTfyvGNBdnYOTBUpGwmPA.rphZqyUfbdoINyXndGfDbQaiIHFM();
				for (int i = 0; i < num2; i++)
				{
					num += hENtlJpbLTfyvGNBdnYOTBUpGwmPA.gmqWnmpZMnASuZpGLEqmJcwgXIqMA(i).ycfaKniCLOzZqlQviANrBfbEZIlRA().GCexcUhSTjMbOjzZJesLIEkQBKFD(state, categoryId);
				}
				return num;
			}

			public int SetMapsEnabled(bool state, ControllerType controllerType, string categoryName)
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return 0;
				}
				int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
				if (mapCategoryId < 0)
				{
					return 0;
				}
				return SetMapsEnabled(state, controllerType, mapCategoryId);
			}

			public int SetMapsEnabled(bool state, ControllerType controllerType, int categoryId, int layoutId)
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return 0;
				}
				if (categoryId < 0 || layoutId < 0)
				{
					return 0;
				}
				int num = 0;
				HENtlJpbLTfyvGNBdnYOTBUpGwmPA hENtlJpbLTfyvGNBdnYOTBUpGwmPA = yfZPVbkoNrPFYlhxRcQrxPzDLvft.QecjgvgRSXuPhnYvNrbSsHRqQwjg.AXLlayIlTwJqJNaNzeKccuszIcODb(controllerType);
				int num2 = hENtlJpbLTfyvGNBdnYOTBUpGwmPA.rphZqyUfbdoINyXndGfDbQaiIHFM();
				for (int i = 0; i < num2; i++)
				{
					num += hENtlJpbLTfyvGNBdnYOTBUpGwmPA.gmqWnmpZMnASuZpGLEqmJcwgXIqMA(i).ycfaKniCLOzZqlQviANrBfbEZIlRA().vwaYCbVPKCYRKpALTeferVuCibFq(state, categoryId, layoutId);
				}
				return num;
			}

			public int SetMapsEnabled(bool state, ControllerType controllerType, string categoryName, string layoutName)
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return 0;
				}
				int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
				if (mapCategoryId < 0)
				{
					return 0;
				}
				int layoutId = ReInput.mapping.GetLayoutId(controllerType, layoutName);
				if (layoutId < 0)
				{
					return 0;
				}
				return SetMapsEnabled(state, controllerType, mapCategoryId, layoutId);
			}

			public int SetMapsEnabled(bool state, Controller controller, int categoryId)
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return 0;
				}
				if (controller == null)
				{
					return 0;
				}
				if (categoryId < 0)
				{
					return 0;
				}
				return yfZPVbkoNrPFYlhxRcQrxPzDLvft.QecjgvgRSXuPhnYvNrbSsHRqQwjg.AXLlayIlTwJqJNaNzeKccuszIcODb(controller.type).EiaJdcLRNPgisAQlXkogBqWdcrPqb(controller.id)?.ycfaKniCLOzZqlQviANrBfbEZIlRA().GCexcUhSTjMbOjzZJesLIEkQBKFD(state, categoryId) ?? 0;
			}

			public int SetMapsEnabled(bool state, Controller controller, int categoryId, int layoutId)
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return 0;
				}
				if (controller == null)
				{
					return 0;
				}
				if (categoryId < 0)
				{
					return 0;
				}
				if (layoutId < 0)
				{
					return 0;
				}
				return yfZPVbkoNrPFYlhxRcQrxPzDLvft.QecjgvgRSXuPhnYvNrbSsHRqQwjg.AXLlayIlTwJqJNaNzeKccuszIcODb(controller.type).EiaJdcLRNPgisAQlXkogBqWdcrPqb(controller.id)?.ycfaKniCLOzZqlQviANrBfbEZIlRA().vwaYCbVPKCYRKpALTeferVuCibFq(state, categoryId, layoutId) ?? 0;
			}

			public int SetMapsEnabled(bool state, Controller controller, string categoryName)
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return 0;
				}
				if (controller == null)
				{
					return 0;
				}
				int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
				if (mapCategoryId < 0)
				{
					return 0;
				}
				return SetMapsEnabled(state, controller, mapCategoryId);
			}

			public int SetMapsEnabled(bool state, Controller controller, string categoryName, string layoutName)
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return 0;
				}
				if (controller == null)
				{
					return 0;
				}
				int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
				if (mapCategoryId < 0)
				{
					return 0;
				}
				int layoutId = ReInput.mapping.GetLayoutId(controller.type, layoutName);
				if (layoutId < 0)
				{
					return 0;
				}
				return SetMapsEnabled(state, controller, mapCategoryId, layoutId);
			}

			public void LoadDefaultMaps(ControllerType controllerType)
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return;
				}
				switch (controllerType)
				{
				case ControllerType.Joystick:
					aeNjaRaeHfqbyTFeUCVYPsQyrGJoA(false);
					break;
				case ControllerType.Keyboard:
					ybHgWDGIxfNGDffxKizpDlIevpcOB(false);
					break;
				case ControllerType.Mouse:
					cSsoauzNPjyjndRwzBMgLOhWNjzH(false);
					break;
				case ControllerType.Custom:
					EhcxbbhTafDWFvVbzBJJzLetipIz(false);
					break;
				default:
					throw new NotImplementedException();
				}
			}

			public bool ContainsMapInCategory(InputMapCategory category)
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return false;
				}
				if (category == null)
				{
					return false;
				}
				return ContainsMapInCategory(category.id);
			}

			public bool ContainsMapInCategory(int categoryId)
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return false;
				}
				if (categoryId < 0)
				{
					return false;
				}
				int kzSWyhVFpKvuMAleUEiVntIEyGZD = yfZPVbkoNrPFYlhxRcQrxPzDLvft.QecjgvgRSXuPhnYvNrbSsHRqQwjg.KzSWyhVFpKvuMAleUEiVntIEyGZD;
				for (int i = 0; i < kzSWyhVFpKvuMAleUEiVntIEyGZD; i++)
				{
					HENtlJpbLTfyvGNBdnYOTBUpGwmPA hENtlJpbLTfyvGNBdnYOTBUpGwmPA = yfZPVbkoNrPFYlhxRcQrxPzDLvft.QecjgvgRSXuPhnYvNrbSsHRqQwjg.AMmiEUMJUxmCKCltvrDeLoaPvEGE(i);
					int num = hENtlJpbLTfyvGNBdnYOTBUpGwmPA.rphZqyUfbdoINyXndGfDbQaiIHFM();
					for (int j = 0; j < num; j++)
					{
						if (hENtlJpbLTfyvGNBdnYOTBUpGwmPA.gmqWnmpZMnASuZpGLEqmJcwgXIqMA(j).ycfaKniCLOzZqlQviANrBfbEZIlRA().rsvRpfrLvkwFYECBGNoJUnxWlQHg(categoryId))
						{
							return true;
						}
					}
				}
				return false;
			}

			public bool ContainsMapInCategory(string categoryName)
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return false;
				}
				int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
				if (mapCategoryId < 0)
				{
					return false;
				}
				return ContainsMapInCategory(mapCategoryId);
			}

			public bool ContainsMapInCategory(ControllerType controllerType, int categoryId)
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return false;
				}
				if (categoryId < 0)
				{
					return false;
				}
				HENtlJpbLTfyvGNBdnYOTBUpGwmPA hENtlJpbLTfyvGNBdnYOTBUpGwmPA = yfZPVbkoNrPFYlhxRcQrxPzDLvft.QecjgvgRSXuPhnYvNrbSsHRqQwjg.AXLlayIlTwJqJNaNzeKccuszIcODb(controllerType);
				int num = hENtlJpbLTfyvGNBdnYOTBUpGwmPA.rphZqyUfbdoINyXndGfDbQaiIHFM();
				for (int i = 0; i < num; i++)
				{
					if (hENtlJpbLTfyvGNBdnYOTBUpGwmPA.gmqWnmpZMnASuZpGLEqmJcwgXIqMA(i).ycfaKniCLOzZqlQviANrBfbEZIlRA().rsvRpfrLvkwFYECBGNoJUnxWlQHg(categoryId))
					{
						return true;
					}
				}
				return false;
			}

			public InputBehavior GetInputBehavior(int behaviorId)
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return null;
				}
				return PuQLxdcCtkdFdIyyRxAOPEXOAQlEA.vUXRFQkaqtxZmDdZWniajedetQiF.uyBqFIyZpwLzlzouiLRXfbnAHPne(PuQLxdcCtkdFdIyyRxAOPEXOAQlEA.CgPagdlzMlCQxkbRTPOoePMzAXof, behaviorId);
			}

			public InputBehavior GetInputBehavior(string behaviorName)
			{
				if (ReInput._id != azGvCmHxftPofYbbgHwfQfhmWSgV)
				{
					ReInput.CheckInitialized(azGvCmHxftPofYbbgHwfQfhmWSgV);
					return null;
				}
				return PuQLxdcCtkdFdIyyRxAOPEXOAQlEA.vUXRFQkaqtxZmDdZWniajedetQiF.nTzpCiyaupxejSxqAqKddbAtpDvL(PuQLxdcCtkdFdIyyRxAOPEXOAQlEA.CgPagdlzMlCQxkbRTPOoePMzAXof, behaviorName);
			}

			internal void fNqwtgIrBfdBNJrUBBLIRRTmdRhM()
			{
				nmGQCkHeZOXBWIMGVcCoDotNVNsA.LoadDefaults();
				dyQwamLeBQtCARIMQybeEfyCBeYGA.LoadDefaults();
			}

			internal void aeNjaRaeHfqbyTFeUCVYPsQyrGJoA(bool P_0)
			{
				if (JmxfICjvfCfvkNQSzlOFqdLOKwTiA.gNWcgqfQUTFkJgixjDvjnNHtNdYSB == null)
				{
					return;
				}
				HENtlJpbLTfyvGNBdnYOTBUpGwmPA hENtlJpbLTfyvGNBdnYOTBUpGwmPA = yfZPVbkoNrPFYlhxRcQrxPzDLvft.QecjgvgRSXuPhnYvNrbSsHRqQwjg.AXLlayIlTwJqJNaNzeKccuszIcODb(ControllerType.Joystick);
				yfZPVbkoNrPFYlhxRcQrxPzDLvft.nhsUTPodOQwcYCOQgEAPgJtivczK.wdcEZJdkDamVPNMSrbSqFSqsqiQQ();
				int num = hENtlJpbLTfyvGNBdnYOTBUpGwmPA.rphZqyUfbdoINyXndGfDbQaiIHFM();
				for (int i = 0; i < num; i++)
				{
					DGwRdGOlPFvMefvreaSvufGXwqlI<Joystick, JoystickMap>.ULpvOcMrCuZQnwHsGOOZRCagYnur uLpvOcMrCuZQnwHsGOOZRCagYnur = (DGwRdGOlPFvMefvreaSvufGXwqlI<Joystick, JoystickMap>.ULpvOcMrCuZQnwHsGOOZRCagYnur)hENtlJpbLTfyvGNBdnYOTBUpGwmPA.gmqWnmpZMnASuZpGLEqmJcwgXIqMA(i);
					bool[] array = null;
					if (!P_0)
					{
						int num2 = uLpvOcMrCuZQnwHsGOOZRCagYnur.urKiLjIJcqceLbXuNYNvuMSWJkNF.ejOOZrUqJLRyRGoRofwTThHfNEkF();
						array = new bool[num2];
						for (int j = 0; j < num2; j++)
						{
							array[j] = uLpvOcMrCuZQnwHsGOOZRCagYnur.urKiLjIJcqceLbXuNYNvuMSWJkNF.xmIhmmDDQdCDzpiurLdyJADZcUhZ(j).enabled;
						}
					}
					uLpvOcMrCuZQnwHsGOOZRCagYnur.urKiLjIJcqceLbXuNYNvuMSWJkNF.LbpjBBfTqPQKKRajQTuNrIRyBihc(false);
					for (int k = 0; k < JmxfICjvfCfvkNQSzlOFqdLOKwTiA.gNWcgqfQUTFkJgixjDvjnNHtNdYSB.Length; k++)
					{
						FZwbzYefalpVCeKsJYRsqVjtVirbB(uLpvOcMrCuZQnwHsGOOZRCagYnur.vEpnAhSIoVrCnOfAmeqwGuTGoWnB, uLpvOcMrCuZQnwHsGOOZRCagYnur.urKiLjIJcqceLbXuNYNvuMSWJkNF, JmxfICjvfCfvkNQSzlOFqdLOKwTiA.gNWcgqfQUTFkJgixjDvjnNHtNdYSB[k], P_0);
					}
					if (!P_0)
					{
						int num3 = MathTools.Min(array.Length, uLpvOcMrCuZQnwHsGOOZRCagYnur.urKiLjIJcqceLbXuNYNvuMSWJkNF.ejOOZrUqJLRyRGoRofwTThHfNEkF());
						for (int l = 0; l < num3; l++)
						{
							uLpvOcMrCuZQnwHsGOOZRCagYnur.urKiLjIJcqceLbXuNYNvuMSWJkNF.xmIhmmDDQdCDzpiurLdyJADZcUhZ(l).enabled = array[l];
						}
					}
				}
				bool loadFromUserDataStore = dyQwamLeBQtCARIMQybeEfyCBeYGA.loadFromUserDataStore;
				dyQwamLeBQtCARIMQybeEfyCBeYGA.loadFromUserDataStore = false;
				dyQwamLeBQtCARIMQybeEfyCBeYGA.Apply();
				dyQwamLeBQtCARIMQybeEfyCBeYGA.loadFromUserDataStore = loadFromUserDataStore;
			}

			internal void ybHgWDGIxfNGDffxKizpDlIevpcOB(bool P_0)
			{
				if (JmxfICjvfCfvkNQSzlOFqdLOKwTiA.aOCKzPGJGSeVeeWARNqlTRSLWhkE == null)
				{
					return;
				}
				FsyiqPdJeSfbLIuiSYvjZeDpZMzW fsyiqPdJeSfbLIuiSYvjZeDpZMzW = yfZPVbkoNrPFYlhxRcQrxPzDLvft.QecjgvgRSXuPhnYvNrbSsHRqQwjg.AXLlayIlTwJqJNaNzeKccuszIcODb(ControllerType.Keyboard).EiaJdcLRNPgisAQlXkogBqWdcrPqb(0).ycfaKniCLOzZqlQviANrBfbEZIlRA();
				bool[] array = null;
				if (!P_0)
				{
					int num = fsyiqPdJeSfbLIuiSYvjZeDpZMzW.ejOOZrUqJLRyRGoRofwTThHfNEkF();
					array = new bool[num];
					for (int i = 0; i < num; i++)
					{
						array[i] = fsyiqPdJeSfbLIuiSYvjZeDpZMzW.QIeXsLdCiAXGGxCgarjGtHyqkDbM(i).enabled;
					}
				}
				fsyiqPdJeSfbLIuiSYvjZeDpZMzW.lTfGKFmOGeJawUBoNGSKjKTZfSMfb(false);
				for (int j = 0; j < JmxfICjvfCfvkNQSzlOFqdLOKwTiA.aOCKzPGJGSeVeeWARNqlTRSLWhkE.Length; j++)
				{
					qeyydLmeNikVjhMxBJsnXtijcZJd qeyydLmeNikVjhMxBJsnXtijcZJd2 = JmxfICjvfCfvkNQSzlOFqdLOKwTiA.aOCKzPGJGSeVeeWARNqlTRSLWhkE[j];
					if (qeyydLmeNikVjhMxBJsnXtijcZJd2.eARiULDwnyPbFsEJBmgnsnyESIZOA() >= 0 && qeyydLmeNikVjhMxBJsnXtijcZJd2.VaPPQMgSCXyLesDhXvZeJAcfnZYF() >= 0)
					{
						KeyboardMap keyboardMap = ReInput.UserData.FindKeyboardMap_Game(ReInput.controllers.Keyboard, qeyydLmeNikVjhMxBJsnXtijcZJd2.eARiULDwnyPbFsEJBmgnsnyESIZOA(), qeyydLmeNikVjhMxBJsnXtijcZJd2.VaPPQMgSCXyLesDhXvZeJAcfnZYF());
						if (P_0)
						{
							keyboardMap.enabled = qeyydLmeNikVjhMxBJsnXtijcZJd2.xzGdHtFeSENFsBnboRQDCjVbtdFS();
						}
						kFKHroEQvdCRfBnYuNAjcxtCGyQLB(ControllerType.Keyboard, 0, keyboardMap, BoolOption.Default);
					}
				}
				if (!P_0)
				{
					int num2 = MathTools.Min(array.Length, fsyiqPdJeSfbLIuiSYvjZeDpZMzW.ejOOZrUqJLRyRGoRofwTThHfNEkF());
					for (int k = 0; k < num2; k++)
					{
						fsyiqPdJeSfbLIuiSYvjZeDpZMzW.QIeXsLdCiAXGGxCgarjGtHyqkDbM(k).enabled = array[k];
					}
				}
				bool loadFromUserDataStore = dyQwamLeBQtCARIMQybeEfyCBeYGA.loadFromUserDataStore;
				dyQwamLeBQtCARIMQybeEfyCBeYGA.loadFromUserDataStore = false;
				dyQwamLeBQtCARIMQybeEfyCBeYGA.Apply();
				dyQwamLeBQtCARIMQybeEfyCBeYGA.loadFromUserDataStore = loadFromUserDataStore;
			}

			internal void cSsoauzNPjyjndRwzBMgLOhWNjzH(bool P_0)
			{
				if (JmxfICjvfCfvkNQSzlOFqdLOKwTiA.yQhOJvGGrqjpgGQySiNACbHFjRydA == null)
				{
					return;
				}
				FsyiqPdJeSfbLIuiSYvjZeDpZMzW fsyiqPdJeSfbLIuiSYvjZeDpZMzW = yfZPVbkoNrPFYlhxRcQrxPzDLvft.QecjgvgRSXuPhnYvNrbSsHRqQwjg.AXLlayIlTwJqJNaNzeKccuszIcODb(ControllerType.Mouse).EiaJdcLRNPgisAQlXkogBqWdcrPqb(0).ycfaKniCLOzZqlQviANrBfbEZIlRA();
				bool[] array = null;
				if (!P_0)
				{
					int num = fsyiqPdJeSfbLIuiSYvjZeDpZMzW.ejOOZrUqJLRyRGoRofwTThHfNEkF();
					array = new bool[num];
					for (int i = 0; i < num; i++)
					{
						array[i] = fsyiqPdJeSfbLIuiSYvjZeDpZMzW.QIeXsLdCiAXGGxCgarjGtHyqkDbM(i).enabled;
					}
				}
				fsyiqPdJeSfbLIuiSYvjZeDpZMzW.lTfGKFmOGeJawUBoNGSKjKTZfSMfb(false);
				for (int j = 0; j < JmxfICjvfCfvkNQSzlOFqdLOKwTiA.yQhOJvGGrqjpgGQySiNACbHFjRydA.Length; j++)
				{
					qeyydLmeNikVjhMxBJsnXtijcZJd qeyydLmeNikVjhMxBJsnXtijcZJd2 = JmxfICjvfCfvkNQSzlOFqdLOKwTiA.yQhOJvGGrqjpgGQySiNACbHFjRydA[j];
					if (qeyydLmeNikVjhMxBJsnXtijcZJd2.eARiULDwnyPbFsEJBmgnsnyESIZOA() >= 0 && qeyydLmeNikVjhMxBJsnXtijcZJd2.VaPPQMgSCXyLesDhXvZeJAcfnZYF() >= 0)
					{
						MouseMap mouseMap = ReInput.UserData.FindMouseMap_Game(ReInput.controllers.Mouse, qeyydLmeNikVjhMxBJsnXtijcZJd2.eARiULDwnyPbFsEJBmgnsnyESIZOA(), qeyydLmeNikVjhMxBJsnXtijcZJd2.VaPPQMgSCXyLesDhXvZeJAcfnZYF());
						if (P_0)
						{
							mouseMap.enabled = qeyydLmeNikVjhMxBJsnXtijcZJd2.xzGdHtFeSENFsBnboRQDCjVbtdFS();
						}
						kFKHroEQvdCRfBnYuNAjcxtCGyQLB(ControllerType.Mouse, 0, mouseMap, BoolOption.Default);
					}
				}
				if (!P_0)
				{
					int num2 = MathTools.Min(array.Length, fsyiqPdJeSfbLIuiSYvjZeDpZMzW.ejOOZrUqJLRyRGoRofwTThHfNEkF());
					for (int k = 0; k < num2; k++)
					{
						fsyiqPdJeSfbLIuiSYvjZeDpZMzW.QIeXsLdCiAXGGxCgarjGtHyqkDbM(k).enabled = array[k];
					}
				}
				bool loadFromUserDataStore = dyQwamLeBQtCARIMQybeEfyCBeYGA.loadFromUserDataStore;
				dyQwamLeBQtCARIMQybeEfyCBeYGA.loadFromUserDataStore = false;
				dyQwamLeBQtCARIMQybeEfyCBeYGA.Apply();
				dyQwamLeBQtCARIMQybeEfyCBeYGA.loadFromUserDataStore = loadFromUserDataStore;
			}

			internal void EhcxbbhTafDWFvVbzBJJzLetipIz(bool P_0)
			{
				if (JmxfICjvfCfvkNQSzlOFqdLOKwTiA.CrWBGRRQrgofaRTgqPRAoqRqOHiy == null)
				{
					return;
				}
				HENtlJpbLTfyvGNBdnYOTBUpGwmPA hENtlJpbLTfyvGNBdnYOTBUpGwmPA = yfZPVbkoNrPFYlhxRcQrxPzDLvft.QecjgvgRSXuPhnYvNrbSsHRqQwjg.AXLlayIlTwJqJNaNzeKccuszIcODb(ControllerType.Custom);
				int num = hENtlJpbLTfyvGNBdnYOTBUpGwmPA.rphZqyUfbdoINyXndGfDbQaiIHFM();
				for (int i = 0; i < num; i++)
				{
					DGwRdGOlPFvMefvreaSvufGXwqlI<CustomController, CustomControllerMap>.ULpvOcMrCuZQnwHsGOOZRCagYnur uLpvOcMrCuZQnwHsGOOZRCagYnur = (DGwRdGOlPFvMefvreaSvufGXwqlI<CustomController, CustomControllerMap>.ULpvOcMrCuZQnwHsGOOZRCagYnur)hENtlJpbLTfyvGNBdnYOTBUpGwmPA.gmqWnmpZMnASuZpGLEqmJcwgXIqMA(i);
					bool[] array = null;
					if (!P_0)
					{
						int num2 = uLpvOcMrCuZQnwHsGOOZRCagYnur.urKiLjIJcqceLbXuNYNvuMSWJkNF.ejOOZrUqJLRyRGoRofwTThHfNEkF();
						array = new bool[num2];
						for (int j = 0; j < num2; j++)
						{
							array[j] = uLpvOcMrCuZQnwHsGOOZRCagYnur.urKiLjIJcqceLbXuNYNvuMSWJkNF.xmIhmmDDQdCDzpiurLdyJADZcUhZ(j).enabled;
						}
					}
					uLpvOcMrCuZQnwHsGOOZRCagYnur.urKiLjIJcqceLbXuNYNvuMSWJkNF.LbpjBBfTqPQKKRajQTuNrIRyBihc(false);
					for (int k = 0; k < JmxfICjvfCfvkNQSzlOFqdLOKwTiA.CrWBGRRQrgofaRTgqPRAoqRqOHiy.Length; k++)
					{
						aEKiQxUpxymBNTABejsNTaqVGgvY(uLpvOcMrCuZQnwHsGOOZRCagYnur.vEpnAhSIoVrCnOfAmeqwGuTGoWnB, uLpvOcMrCuZQnwHsGOOZRCagYnur.urKiLjIJcqceLbXuNYNvuMSWJkNF, JmxfICjvfCfvkNQSzlOFqdLOKwTiA.CrWBGRRQrgofaRTgqPRAoqRqOHiy[k], P_0);
					}
					if (!P_0)
					{
						int num3 = MathTools.Min(array.Length, uLpvOcMrCuZQnwHsGOOZRCagYnur.urKiLjIJcqceLbXuNYNvuMSWJkNF.ejOOZrUqJLRyRGoRofwTThHfNEkF());
						for (int l = 0; l < num3; l++)
						{
							uLpvOcMrCuZQnwHsGOOZRCagYnur.urKiLjIJcqceLbXuNYNvuMSWJkNF.xmIhmmDDQdCDzpiurLdyJADZcUhZ(l).enabled = array[l];
						}
					}
				}
				bool loadFromUserDataStore = dyQwamLeBQtCARIMQybeEfyCBeYGA.loadFromUserDataStore;
				dyQwamLeBQtCARIMQybeEfyCBeYGA.loadFromUserDataStore = false;
				dyQwamLeBQtCARIMQybeEfyCBeYGA.Apply();
				dyQwamLeBQtCARIMQybeEfyCBeYGA.loadFromUserDataStore = loadFromUserDataStore;
			}

			private HENtlJpbLTfyvGNBdnYOTBUpGwmPA vjFJSXxeUsObgcxatjFDQDpTwlTs<_0001>() where _0001 : ControllerMap
			{
				return yfZPVbkoNrPFYlhxRcQrxPzDLvft.QecjgvgRSXuPhnYvNrbSsHRqQwjg.AXLlayIlTwJqJNaNzeKccuszIcODb(IyPmashUlRgIygDiHFyDZHZmauql.vBvhRnrsyKoNMsAeKAkRzastNVbp<_0001>());
			}

			internal global::rspbeSfkijiKRfPuAyBrBqKNCACZB<JoystickMap> boAqYpOioIEEpVVksCrXaVjnRZtp(Joystick P_0, bool P_1)
			{
				if (P_0 == null || JmxfICjvfCfvkNQSzlOFqdLOKwTiA.gNWcgqfQUTFkJgixjDvjnNHtNdYSB == null)
				{
					return null;
				}
				global::rspbeSfkijiKRfPuAyBrBqKNCACZB<JoystickMap> rspbeSfkijiKRfPuAyBrBqKNCACZB2 = new global::rspbeSfkijiKRfPuAyBrBqKNCACZB<JoystickMap>(P_0.id);
				for (int i = 0; i < JmxfICjvfCfvkNQSzlOFqdLOKwTiA.gNWcgqfQUTFkJgixjDvjnNHtNdYSB.Length; i++)
				{
					FZwbzYefalpVCeKsJYRsqVjtVirbB(P_0, rspbeSfkijiKRfPuAyBrBqKNCACZB2, JmxfICjvfCfvkNQSzlOFqdLOKwTiA.gNWcgqfQUTFkJgixjDvjnNHtNdYSB[i], P_1);
				}
				if (rspbeSfkijiKRfPuAyBrBqKNCACZB2.ejOOZrUqJLRyRGoRofwTThHfNEkF() == 0)
				{
					return null;
				}
				return rspbeSfkijiKRfPuAyBrBqKNCACZB2;
			}

			private void FZwbzYefalpVCeKsJYRsqVjtVirbB(Joystick P_0, global::rspbeSfkijiKRfPuAyBrBqKNCACZB<JoystickMap> P_1, qeyydLmeNikVjhMxBJsnXtijcZJd P_2, bool P_3)
			{
				if (P_0 != null && P_2 != null && P_2.eARiULDwnyPbFsEJBmgnsnyESIZOA() >= 0 && P_2.VaPPQMgSCXyLesDhXvZeJAcfnZYF() >= 0)
				{
					JoystickMap joystickMap = ReInput.UserData.HSFpDuCYQzabsUTxQTsPcGMueout(P_0, P_2.eARiULDwnyPbFsEJBmgnsnyESIZOA(), P_2.VaPPQMgSCXyLesDhXvZeJAcfnZYF());
					rDfRPZOWEwhiCARLvGxXFLUmCaieb(P_0, joystickMap);
					BoolOption boolOption = BoolOption.Default;
					if (P_3)
					{
						boolOption = (P_2.xzGdHtFeSENFsBnboRQDCjVbtdFS() ? BoolOption.True : BoolOption.False);
					}
					P_1.CrKRnXgcBftccRXYYskdPqpakdnq(joystickMap, boolOption);
				}
			}

			internal global::rspbeSfkijiKRfPuAyBrBqKNCACZB<CustomControllerMap> CAfGhcxwHQfmSNHjCdjSSYGOWBwV(CustomController P_0, bool P_1)
			{
				if (P_0 == null || JmxfICjvfCfvkNQSzlOFqdLOKwTiA.CrWBGRRQrgofaRTgqPRAoqRqOHiy == null)
				{
					return null;
				}
				global::rspbeSfkijiKRfPuAyBrBqKNCACZB<CustomControllerMap> rspbeSfkijiKRfPuAyBrBqKNCACZB2 = new global::rspbeSfkijiKRfPuAyBrBqKNCACZB<CustomControllerMap>(P_0.id);
				for (int i = 0; i < JmxfICjvfCfvkNQSzlOFqdLOKwTiA.CrWBGRRQrgofaRTgqPRAoqRqOHiy.Length; i++)
				{
					aEKiQxUpxymBNTABejsNTaqVGgvY(P_0, rspbeSfkijiKRfPuAyBrBqKNCACZB2, JmxfICjvfCfvkNQSzlOFqdLOKwTiA.CrWBGRRQrgofaRTgqPRAoqRqOHiy[i], P_1);
				}
				if (rspbeSfkijiKRfPuAyBrBqKNCACZB2.ejOOZrUqJLRyRGoRofwTThHfNEkF() == 0)
				{
					return null;
				}
				return rspbeSfkijiKRfPuAyBrBqKNCACZB2;
			}

			private void aEKiQxUpxymBNTABejsNTaqVGgvY(CustomController P_0, global::rspbeSfkijiKRfPuAyBrBqKNCACZB<CustomControllerMap> P_1, qeyydLmeNikVjhMxBJsnXtijcZJd P_2, bool P_3)
			{
				if (P_0 != null && P_2 != null && P_2.eARiULDwnyPbFsEJBmgnsnyESIZOA() >= 0 && P_2.VaPPQMgSCXyLesDhXvZeJAcfnZYF() >= 0)
				{
					CustomControllerMap customControllerMap = ReInput.UserData.kICgImNyfVCgjcsYESaTqSPMJsfH(P_2.eARiULDwnyPbFsEJBmgnsnyESIZOA(), P_0.sourceControllerId, P_2.VaPPQMgSCXyLesDhXvZeJAcfnZYF());
					rDfRPZOWEwhiCARLvGxXFLUmCaieb(P_0, customControllerMap);
					BoolOption boolOption = BoolOption.Default;
					if (P_3)
					{
						boolOption = (P_2.xzGdHtFeSENFsBnboRQDCjVbtdFS() ? BoolOption.True : BoolOption.False);
					}
					P_1.CrKRnXgcBftccRXYYskdPqpakdnq(customControllerMap, boolOption);
				}
			}

			internal void rDfRPZOWEwhiCARLvGxXFLUmCaieb(Controller P_0, ControllerMap P_1)
			{
				if (P_0 != null && P_1 != null)
				{
					P_1.tgCplRFOOvjFEJhHddHKDbDkUHnkB(PuQLxdcCtkdFdIyyRxAOPEXOAQlEA.CgPagdlzMlCQxkbRTPOoePMzAXof);
					P_0.dLKEnXOkLZMBMnjljyrBEBHwOgie(P_1);
				}
			}

			private IList<_0001> NZockkAJfoePAXulRwzevheOHKEX<_0001>(int P_0) where _0001 : ControllerMap
			{
				HENtlJpbLTfyvGNBdnYOTBUpGwmPA hENtlJpbLTfyvGNBdnYOTBUpGwmPA = vjFJSXxeUsObgcxatjFDQDpTwlTs<_0001>();
				int num = hENtlJpbLTfyvGNBdnYOTBUpGwmPA.LwDtjAISpvZKUEBiCEPKHyoscvdr(P_0);
				if (num < 0)
				{
					return EmptyObjects<_0001>.EmptyReadOnlyIListT;
				}
				return hENtlJpbLTfyvGNBdnYOTBUpGwmPA.gmqWnmpZMnASuZpGLEqmJcwgXIqMA(num).ycfaKniCLOzZqlQviANrBfbEZIlRA().lEtyaZbfxqQkwhuWxnvKuecgHwtFA<_0001>();
			}

			private IList<_0001> bjzcUuSlWjpGqzqjYYCwluTWlesD<_0001>(Controller P_0) where _0001 : ControllerMap
			{
				return vjFJSXxeUsObgcxatjFDQDpTwlTs<_0001>().tyclpzZIUUBUPVHZmQIcnazyLDhy(P_0)?.ycfaKniCLOzZqlQviANrBfbEZIlRA().lEtyaZbfxqQkwhuWxnvKuecgHwtFA<_0001>();
			}

			private IList<ControllerMap> bxDpnOOiZeoKpBCjiZupiYEmZhLK(ControllerType P_0, int P_1)
			{
				HENtlJpbLTfyvGNBdnYOTBUpGwmPA hENtlJpbLTfyvGNBdnYOTBUpGwmPA = yfZPVbkoNrPFYlhxRcQrxPzDLvft.QecjgvgRSXuPhnYvNrbSsHRqQwjg.AXLlayIlTwJqJNaNzeKccuszIcODb(P_0);
				int num = hENtlJpbLTfyvGNBdnYOTBUpGwmPA.LwDtjAISpvZKUEBiCEPKHyoscvdr(P_1);
				if (num < 0)
				{
					return EmptyObjects<ControllerMap>.EmptyReadOnlyIListT;
				}
				return hENtlJpbLTfyvGNBdnYOTBUpGwmPA.gmqWnmpZMnASuZpGLEqmJcwgXIqMA(num).ycfaKniCLOzZqlQviANrBfbEZIlRA().yNPIkhCQyqKjUMKWnmnPppLEAttk();
			}

			private IList<ControllerMap> bjzcUuSlWjpGqzqjYYCwluTWlesD(Controller P_0)
			{
				return bxDpnOOiZeoKpBCjiZupiYEmZhLK(P_0.type, P_0.id);
			}

			private void kjAgSwHZJEpdhEYCodFKePKLFIwD(ControllerType P_0, int P_1, int P_2, int P_3)
			{
				iuccFizJavEgbdrjmoChnOppOPYwA(P_0, P_1, P_2, P_3, BoolOption.Default);
			}

			private void HgYqHxHWDURLKhHCDqcVwAhzhFVo(Controller P_0, int P_1, int P_2)
			{
				tVrqVGuYWbhfnOTAGKeMWPcpiIUaA(P_0, P_1, P_2, BoolOption.Default);
			}

			private void JzOgSfuxcHxmRXTPQHNFtmuPWczk(ControllerType P_0, int P_1, string P_2, string P_3)
			{
				vfvlWKGDqnPLHETxICuKKwHrncft(P_0, P_1, P_2, P_3, BoolOption.Default);
			}

			private void tuVcWiXVFrpyMlzskiCLoImyDLgJA(Controller P_0, string P_1, string P_2)
			{
				xrhjMBXzNdcPMAGAoVtPYcrpkJVR(P_0, P_1, P_2, BoolOption.Default);
			}

			private void iuccFizJavEgbdrjmoChnOppOPYwA(ControllerType P_0, int P_1, int P_2, int P_3, BoolOption P_4)
			{
				HENtlJpbLTfyvGNBdnYOTBUpGwmPA hENtlJpbLTfyvGNBdnYOTBUpGwmPA = yfZPVbkoNrPFYlhxRcQrxPzDLvft.QecjgvgRSXuPhnYvNrbSsHRqQwjg.AXLlayIlTwJqJNaNzeKccuszIcODb(P_0);
				int num = hENtlJpbLTfyvGNBdnYOTBUpGwmPA.LwDtjAISpvZKUEBiCEPKHyoscvdr(P_1);
				if (num >= 0)
				{
					Controller controller = hENtlJpbLTfyvGNBdnYOTBUpGwmPA.gmqWnmpZMnASuZpGLEqmJcwgXIqMA(num).hfcnXcmxHjJxWTdCahVjbHZvxlVj();
					ControllerMap controllerMap = ReInput.UserData.AHLAGlhKqFwTnTYyhALfOyZwHEfMA(controller, P_2, P_3);
					kFKHroEQvdCRfBnYuNAjcxtCGyQLB(controller.type, controller.id, controllerMap, P_4);
				}
			}

			private void tVrqVGuYWbhfnOTAGKeMWPcpiIUaA(Controller P_0, int P_1, int P_2, BoolOption P_3)
			{
				iuccFizJavEgbdrjmoChnOppOPYwA(P_0.type, P_0.id, P_1, P_2, P_3);
			}

			private void vfvlWKGDqnPLHETxICuKKwHrncft(ControllerType P_0, int P_1, string P_2, string P_3, BoolOption P_4)
			{
				int mapCategoryId = ReInput.mapping.GetMapCategoryId(P_2);
				int layoutId = ReInput.mapping.GetLayoutId(P_0, P_3);
				if (mapCategoryId >= 0 && layoutId >= 0)
				{
					iuccFizJavEgbdrjmoChnOppOPYwA(P_0, P_1, mapCategoryId, layoutId, P_4);
				}
			}

			private void xrhjMBXzNdcPMAGAoVtPYcrpkJVR(Controller P_0, string P_1, string P_2, BoolOption P_3)
			{
				vfvlWKGDqnPLHETxICuKKwHrncft(P_0.type, P_0.id, P_1, P_2, P_3);
			}

			private void fGSvXEgIfBGIaiFBqVtYLAasdTUX(Controller P_0, ControllerMap P_1, BoolOption P_2)
			{
				if (P_0 != null && P_1 != null)
				{
					HENtlJpbLTfyvGNBdnYOTBUpGwmPA hENtlJpbLTfyvGNBdnYOTBUpGwmPA = yfZPVbkoNrPFYlhxRcQrxPzDLvft.QecjgvgRSXuPhnYvNrbSsHRqQwjg.AXLlayIlTwJqJNaNzeKccuszIcODb(P_0.type);
					int num = hENtlJpbLTfyvGNBdnYOTBUpGwmPA.LwDtjAISpvZKUEBiCEPKHyoscvdr(P_0.id);
					if (num >= 0)
					{
						rDfRPZOWEwhiCARLvGxXFLUmCaieb(P_0, P_1);
						hENtlJpbLTfyvGNBdnYOTBUpGwmPA.gmqWnmpZMnASuZpGLEqmJcwgXIqMA(num).ycfaKniCLOzZqlQviANrBfbEZIlRA().IWSMkVJhcxPmslEPvqPVYpEpYblP(P_1, P_2);
						nmGQCkHeZOXBWIMGVcCoDotNVNsA.Apply();
					}
				}
			}

			private void kFKHroEQvdCRfBnYuNAjcxtCGyQLB(ControllerType P_0, int P_1, ControllerMap P_2, BoolOption P_3)
			{
				Controller controller = ReInput.controllers.GetController(P_0, P_1);
				if (controller != null)
				{
					fGSvXEgIfBGIaiFBqVtYLAasdTUX(controller, P_2, P_3);
				}
			}

			private bool kqosTSqNOfeJfDHNisEgcHDBaIcQA(ControllerType P_0, int P_1, string P_2)
			{
				if (P_2 == null || P_2 == string.Empty)
				{
					return false;
				}
				if (yfZPVbkoNrPFYlhxRcQrxPzDLvft.QecjgvgRSXuPhnYvNrbSsHRqQwjg.AXLlayIlTwJqJNaNzeKccuszIcODb(P_0).LwDtjAISpvZKUEBiCEPKHyoscvdr(P_1) < 0)
				{
					return false;
				}
				ControllerMap controllerMap = ControllerMap.DzOeBfwddcwwENIIeCxWFIebOvPE(P_0);
				if (!controllerMap.gdHGbQKZjfjgtBVKXQKgALHiHuNXA(P_2))
				{
					return false;
				}
				kFKHroEQvdCRfBnYuNAjcxtCGyQLB(P_0, P_1, controllerMap, BoolOption.Default);
				return true;
			}

			private int KxlCscCLLSMXHbmaTrdOtHvEProdb(ControllerType P_0, int P_1, List<string> P_2)
			{
				if (P_2 == null || P_2.Count == 0)
				{
					return 0;
				}
				if (yfZPVbkoNrPFYlhxRcQrxPzDLvft.QecjgvgRSXuPhnYvNrbSsHRqQwjg.AXLlayIlTwJqJNaNzeKccuszIcODb(P_0).LwDtjAISpvZKUEBiCEPKHyoscvdr(P_1) < 0)
				{
					return 0;
				}
				int num = 0;
				for (int i = 0; i < P_2.Count; i++)
				{
					if (kqosTSqNOfeJfDHNisEgcHDBaIcQA(P_0, P_1, P_2[i]))
					{
						num++;
					}
				}
				return num;
			}

			private bool rqcwlTjKIizdKDEPLbuEuRbchARx(ControllerType P_0, int P_1, string P_2)
			{
				if (P_2 == null || P_2 == string.Empty)
				{
					return false;
				}
				if (yfZPVbkoNrPFYlhxRcQrxPzDLvft.QecjgvgRSXuPhnYvNrbSsHRqQwjg.AXLlayIlTwJqJNaNzeKccuszIcODb(P_0).LwDtjAISpvZKUEBiCEPKHyoscvdr(P_1) < 0)
				{
					return false;
				}
				ControllerMap controllerMap = ControllerMap.DzOeBfwddcwwENIIeCxWFIebOvPE(P_0);
				if (!controllerMap.VNMyQDOFwWgRFlcSlmPsLWmMGTSb(P_2))
				{
					return false;
				}
				kFKHroEQvdCRfBnYuNAjcxtCGyQLB(P_0, P_1, controllerMap, BoolOption.Default);
				return true;
			}

			private int GSdcXGykgmgJeMgykfmjKYiKITFuA(ControllerType P_0, int P_1, List<string> P_2)
			{
				if (P_2 == null || P_2.Count == 0)
				{
					return 0;
				}
				if (yfZPVbkoNrPFYlhxRcQrxPzDLvft.QecjgvgRSXuPhnYvNrbSsHRqQwjg.AXLlayIlTwJqJNaNzeKccuszIcODb(P_0).LwDtjAISpvZKUEBiCEPKHyoscvdr(P_1) < 0)
				{
					return 0;
				}
				int num = 0;
				for (int i = 0; i < P_2.Count; i++)
				{
					if (rqcwlTjKIizdKDEPLbuEuRbchARx(P_0, P_1, P_2[i]))
					{
						num++;
					}
				}
				return num;
			}

			private void pMazRBUVdDyRgTiwaCodmRmictEDA(ControllerType P_0, int P_1, int P_2, int P_3)
			{
				HENtlJpbLTfyvGNBdnYOTBUpGwmPA hENtlJpbLTfyvGNBdnYOTBUpGwmPA = yfZPVbkoNrPFYlhxRcQrxPzDLvft.QecjgvgRSXuPhnYvNrbSsHRqQwjg.AXLlayIlTwJqJNaNzeKccuszIcODb(P_0);
				int num = hENtlJpbLTfyvGNBdnYOTBUpGwmPA.LwDtjAISpvZKUEBiCEPKHyoscvdr(P_1);
				if (num >= 0)
				{
					Controller controller = hENtlJpbLTfyvGNBdnYOTBUpGwmPA.gmqWnmpZMnASuZpGLEqmJcwgXIqMA(num).hfcnXcmxHjJxWTdCahVjbHZvxlVj();
					ControllerMap controllerMap = ControllerMap.otvNzBmtghLoMTaGshuqrkxuHQy(controller, P_2, P_3);
					kFKHroEQvdCRfBnYuNAjcxtCGyQLB(controller.type, controller.id, controllerMap, BoolOption.Default);
				}
			}

			private void LSgxijiKKbgbWeqWPIcPYfFZQwNeb(Controller P_0, int P_1, int P_2)
			{
				pMazRBUVdDyRgTiwaCodmRmictEDA(P_0.type, P_0.id, P_1, P_2);
			}

			private void vpOUjuYJLiIrFiptpNDIZRqeJgMHA(ControllerType P_0, int P_1, string P_2, string P_3)
			{
				int mapCategoryId = ReInput.mapping.GetMapCategoryId(P_2);
				int layoutId = ReInput.mapping.GetLayoutId(P_0, P_3);
				if (mapCategoryId >= 0 && layoutId >= 0)
				{
					pMazRBUVdDyRgTiwaCodmRmictEDA(P_0, P_1, mapCategoryId, layoutId);
				}
			}

			private void beoMmcQsAkkEXwFwqIshsDbGUppD(Controller P_0, string P_1, string P_2)
			{
				vpOUjuYJLiIrFiptpNDIZRqeJgMHA(P_0.type, P_0.id, P_1, P_2);
			}

			private void MHcoyBAgEYSUHbPJVDpmWAJmScJO(ControllerType P_0, int P_1, int P_2)
			{
				HENtlJpbLTfyvGNBdnYOTBUpGwmPA hENtlJpbLTfyvGNBdnYOTBUpGwmPA = yfZPVbkoNrPFYlhxRcQrxPzDLvft.QecjgvgRSXuPhnYvNrbSsHRqQwjg.AXLlayIlTwJqJNaNzeKccuszIcODb(P_0);
				int num = hENtlJpbLTfyvGNBdnYOTBUpGwmPA.LwDtjAISpvZKUEBiCEPKHyoscvdr(P_1);
				if (num >= 0)
				{
					hENtlJpbLTfyvGNBdnYOTBUpGwmPA.gmqWnmpZMnASuZpGLEqmJcwgXIqMA(num).ycfaKniCLOzZqlQviANrBfbEZIlRA().tCNwCMwbDJjxidOhgaZumUxXpJZB(P_2);
				}
			}

			private void oSdyWvEhNPbWpzJaJodVQJtwuZAo(Controller P_0, int P_1)
			{
				MHcoyBAgEYSUHbPJVDpmWAJmScJO(P_0.type, P_0.id, P_1);
			}

			private void rwCanreUlUBxhhFLXfVMDlUppZTxA(ControllerType P_0, int P_1, ControllerMap P_2)
			{
				HENtlJpbLTfyvGNBdnYOTBUpGwmPA hENtlJpbLTfyvGNBdnYOTBUpGwmPA = yfZPVbkoNrPFYlhxRcQrxPzDLvft.QecjgvgRSXuPhnYvNrbSsHRqQwjg.AXLlayIlTwJqJNaNzeKccuszIcODb(P_0);
				int num = hENtlJpbLTfyvGNBdnYOTBUpGwmPA.LwDtjAISpvZKUEBiCEPKHyoscvdr(P_1);
				if (num >= 0)
				{
					hENtlJpbLTfyvGNBdnYOTBUpGwmPA.gmqWnmpZMnASuZpGLEqmJcwgXIqMA(num).ycfaKniCLOzZqlQviANrBfbEZIlRA().nxgQlHQMCDFqYoaiMysbpiZnAgfJ(P_2);
				}
			}

			private void XvwjckZkopNEcEdQxcbUFejurALBA(Controller P_0, ControllerMap P_1)
			{
				MHcoyBAgEYSUHbPJVDpmWAJmScJO(P_0.type, P_0.id, P_1.id);
			}

			private void UjGDIbmjEOxDETkVAYnrNFRHlAkN(ControllerType P_0, int P_1, int P_2, int P_3)
			{
				HENtlJpbLTfyvGNBdnYOTBUpGwmPA hENtlJpbLTfyvGNBdnYOTBUpGwmPA = yfZPVbkoNrPFYlhxRcQrxPzDLvft.QecjgvgRSXuPhnYvNrbSsHRqQwjg.AXLlayIlTwJqJNaNzeKccuszIcODb(P_0);
				int num = hENtlJpbLTfyvGNBdnYOTBUpGwmPA.LwDtjAISpvZKUEBiCEPKHyoscvdr(P_1);
				if (num >= 0)
				{
					hENtlJpbLTfyvGNBdnYOTBUpGwmPA.gmqWnmpZMnASuZpGLEqmJcwgXIqMA(num).ycfaKniCLOzZqlQviANrBfbEZIlRA().opZpdnNQXrhuoaOlohwygiyYsYXMA(P_2, P_3);
				}
			}

			private void OFudwXzyZgABbbUFsJCztJvGDTSN(Controller P_0, int P_1, int P_2)
			{
				UjGDIbmjEOxDETkVAYnrNFRHlAkN(P_0.type, P_0.id, P_1, P_2);
			}

			private void ilnQdIUfxnACDWSmyCcxPQijKvUJ(ControllerType P_0, int P_1, string P_2, string P_3)
			{
				HENtlJpbLTfyvGNBdnYOTBUpGwmPA hENtlJpbLTfyvGNBdnYOTBUpGwmPA = yfZPVbkoNrPFYlhxRcQrxPzDLvft.QecjgvgRSXuPhnYvNrbSsHRqQwjg.AXLlayIlTwJqJNaNzeKccuszIcODb(P_0);
				int num = hENtlJpbLTfyvGNBdnYOTBUpGwmPA.LwDtjAISpvZKUEBiCEPKHyoscvdr(P_1);
				if (num >= 0)
				{
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(P_2);
					int layoutId = ReInput.mapping.GetLayoutId(P_0, P_3);
					if (mapCategoryId >= 0 && layoutId >= 0)
					{
						hENtlJpbLTfyvGNBdnYOTBUpGwmPA.gmqWnmpZMnASuZpGLEqmJcwgXIqMA(num).ycfaKniCLOzZqlQviANrBfbEZIlRA().opZpdnNQXrhuoaOlohwygiyYsYXMA(mapCategoryId, layoutId);
					}
				}
			}

			private void UiSaTSgiKZsrfhJzaaAMIYIHAYgWA(Controller P_0, string P_1, string P_2)
			{
				ilnQdIUfxnACDWSmyCcxPQijKvUJ(P_0.type, P_0.id, P_1, P_2);
			}

			private ControllerMap wlYTjRTwKufhKShPQDUUyuyZMODy(ControllerType P_0, int P_1, int P_2)
			{
				HENtlJpbLTfyvGNBdnYOTBUpGwmPA hENtlJpbLTfyvGNBdnYOTBUpGwmPA = yfZPVbkoNrPFYlhxRcQrxPzDLvft.QecjgvgRSXuPhnYvNrbSsHRqQwjg.AXLlayIlTwJqJNaNzeKccuszIcODb(P_0);
				int num = hENtlJpbLTfyvGNBdnYOTBUpGwmPA.LwDtjAISpvZKUEBiCEPKHyoscvdr(P_1);
				if (num < 0)
				{
					return null;
				}
				return hENtlJpbLTfyvGNBdnYOTBUpGwmPA.gmqWnmpZMnASuZpGLEqmJcwgXIqMA(num).ycfaKniCLOzZqlQviANrBfbEZIlRA().CjGxPiEUXuKQAiReAORsgeKuwFqy(P_2);
			}

			private ControllerMap PQIFfGPzOiCyUHmvsJwhQbYFfPjq(Controller P_0, int P_1)
			{
				return wlYTjRTwKufhKShPQDUUyuyZMODy(P_0.type, P_0.id, P_1);
			}

			private ControllerMap zQbEeMxFPAzvSIBXzpimFCAIEIoI(ControllerType P_0, int P_1, int P_2, int P_3)
			{
				HENtlJpbLTfyvGNBdnYOTBUpGwmPA hENtlJpbLTfyvGNBdnYOTBUpGwmPA = yfZPVbkoNrPFYlhxRcQrxPzDLvft.QecjgvgRSXuPhnYvNrbSsHRqQwjg.AXLlayIlTwJqJNaNzeKccuszIcODb(P_0);
				int num = hENtlJpbLTfyvGNBdnYOTBUpGwmPA.LwDtjAISpvZKUEBiCEPKHyoscvdr(P_1);
				if (num < 0)
				{
					return null;
				}
				return hENtlJpbLTfyvGNBdnYOTBUpGwmPA.gmqWnmpZMnASuZpGLEqmJcwgXIqMA(num).ycfaKniCLOzZqlQviANrBfbEZIlRA().IKBSPDrohmzANlhBAFfxdxZDSpbE(P_2, P_3);
			}

			private ControllerMap snGTlUZLyfCaFIzXgTxnedHdWmOGA(Controller P_0, int P_1, int P_2)
			{
				return zQbEeMxFPAzvSIBXzpimFCAIEIoI(P_0.type, P_0.id, P_1, P_2);
			}

			private ControllerMap YNZDopBNJmlMrhWmTlzeVdcugPJK(ControllerType P_0, int P_1, string P_2, string P_3)
			{
				int mapCategoryId = ReInput.mapping.GetMapCategoryId(P_2);
				int layoutId = ReInput.mapping.GetLayoutId(P_0, P_3);
				if (mapCategoryId < 0 || layoutId < 0)
				{
					return null;
				}
				return zQbEeMxFPAzvSIBXzpimFCAIEIoI(P_0, P_1, mapCategoryId, layoutId);
			}

			private ControllerMap lrUwtionxcCkMjEBLFwFBIccpBuGb(Controller P_0, string P_1, string P_2)
			{
				return YNZDopBNJmlMrhWmTlzeVdcugPJK(P_0.type, P_0.id, P_1, P_2);
			}

			private ControllerMap kSrEOewMyxTNUyAQYmNRKDfockhX(ControllerType P_0, int P_1, int P_2)
			{
				HENtlJpbLTfyvGNBdnYOTBUpGwmPA hENtlJpbLTfyvGNBdnYOTBUpGwmPA = yfZPVbkoNrPFYlhxRcQrxPzDLvft.QecjgvgRSXuPhnYvNrbSsHRqQwjg.AXLlayIlTwJqJNaNzeKccuszIcODb(P_0);
				int num = hENtlJpbLTfyvGNBdnYOTBUpGwmPA.LwDtjAISpvZKUEBiCEPKHyoscvdr(P_1);
				if (num < 0)
				{
					return null;
				}
				return hENtlJpbLTfyvGNBdnYOTBUpGwmPA.gmqWnmpZMnASuZpGLEqmJcwgXIqMA(num).ycfaKniCLOzZqlQviANrBfbEZIlRA().DyyatXRGzTDTjvVkpgVCMijDHpLhA(P_2);
			}

			private ControllerMap dKPlSnRsTTtZrQQtXqAMGGCgCylC(Controller P_0, int P_1)
			{
				return kSrEOewMyxTNUyAQYmNRKDfockhX(P_0.type, P_0.id, P_1);
			}

			private ControllerMap ATtHkPksJJauvOVEKpIJkhBoKZCe(ControllerType P_0, int P_1, string P_2)
			{
				int mapCategoryId = ReInput.UserData.GetMapCategoryId(P_2);
				if (mapCategoryId < 0)
				{
					return null;
				}
				return kSrEOewMyxTNUyAQYmNRKDfockhX(P_0, P_1, mapCategoryId);
			}

			private ControllerMap XXRHpPMCWDZiAbwNnlwVYaHcUidO(Controller P_0, string P_1)
			{
				return ATtHkPksJJauvOVEKpIJkhBoKZCe(P_0.type, P_0.id, P_1);
			}

			private ControllerMap[] glUCjPCCokxekWNjdbDJGRZGkUcXA(ControllerType P_0)
			{
				HENtlJpbLTfyvGNBdnYOTBUpGwmPA hENtlJpbLTfyvGNBdnYOTBUpGwmPA = yfZPVbkoNrPFYlhxRcQrxPzDLvft.QecjgvgRSXuPhnYvNrbSsHRqQwjg.AXLlayIlTwJqJNaNzeKccuszIcODb(P_0);
				int num = 0;
				for (int i = 0; i < hENtlJpbLTfyvGNBdnYOTBUpGwmPA.rphZqyUfbdoINyXndGfDbQaiIHFM(); i++)
				{
					num += hENtlJpbLTfyvGNBdnYOTBUpGwmPA.gmqWnmpZMnASuZpGLEqmJcwgXIqMA(i).ycfaKniCLOzZqlQviANrBfbEZIlRA().ejOOZrUqJLRyRGoRofwTThHfNEkF();
				}
				ControllerMap[] array = new ControllerMap[num];
				num = 0;
				for (int j = 0; j < hENtlJpbLTfyvGNBdnYOTBUpGwmPA.rphZqyUfbdoINyXndGfDbQaiIHFM(); j++)
				{
					FsyiqPdJeSfbLIuiSYvjZeDpZMzW fsyiqPdJeSfbLIuiSYvjZeDpZMzW = hENtlJpbLTfyvGNBdnYOTBUpGwmPA.gmqWnmpZMnASuZpGLEqmJcwgXIqMA(j).ycfaKniCLOzZqlQviANrBfbEZIlRA();
					for (int k = 0; k < fsyiqPdJeSfbLIuiSYvjZeDpZMzW.ejOOZrUqJLRyRGoRofwTThHfNEkF(); k++)
					{
						array[num] = fsyiqPdJeSfbLIuiSYvjZeDpZMzW.QIeXsLdCiAXGGxCgarjGtHyqkDbM(k);
						num++;
					}
				}
				return array;
			}

			private ControllerMapSaveData[] sdBijFKEPCckQsXvzEERtGVYaLzX(ControllerType P_0, int P_1, bool P_2)
			{
				HENtlJpbLTfyvGNBdnYOTBUpGwmPA hENtlJpbLTfyvGNBdnYOTBUpGwmPA = yfZPVbkoNrPFYlhxRcQrxPzDLvft.QecjgvgRSXuPhnYvNrbSsHRqQwjg.AXLlayIlTwJqJNaNzeKccuszIcODb(P_0);
				int num = hENtlJpbLTfyvGNBdnYOTBUpGwmPA.LwDtjAISpvZKUEBiCEPKHyoscvdr(P_1);
				if (num < 0)
				{
					return null;
				}
				List<ControllerMapSaveData> list = new List<ControllerMapSaveData>();
				FsyiqPdJeSfbLIuiSYvjZeDpZMzW fsyiqPdJeSfbLIuiSYvjZeDpZMzW = hENtlJpbLTfyvGNBdnYOTBUpGwmPA.gmqWnmpZMnASuZpGLEqmJcwgXIqMA(num).ycfaKniCLOzZqlQviANrBfbEZIlRA();
				for (int i = 0; i < fsyiqPdJeSfbLIuiSYvjZeDpZMzW.ejOOZrUqJLRyRGoRofwTThHfNEkF(); i++)
				{
					ControllerMap controllerMap = fsyiqPdJeSfbLIuiSYvjZeDpZMzW.QIeXsLdCiAXGGxCgarjGtHyqkDbM(i);
					if (P_2)
					{
						InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(controllerMap.categoryId);
						if (mapCategory != null && !mapCategory.userAssignable)
						{
							continue;
						}
					}
					Controller controller = hENtlJpbLTfyvGNBdnYOTBUpGwmPA.gmqWnmpZMnASuZpGLEqmJcwgXIqMA(num).hfcnXcmxHjJxWTdCahVjbHZvxlVj();
					list.Add(ControllerMapSaveData.gCkljfJrKKFTKgywzWxECuyHjteI(controller, controllerMap));
				}
				return list.ToArray();
			}

			private _0001[] UVHdENLjLbffFrtXXukhfyYpTvHw<_0001>(int P_0, bool P_1) where _0001 : ControllerMapSaveData
			{
				ControllerType controllerType = IyPmashUlRgIygDiHFyDZHZmauql.RtpCJVkDeYglOKQzFNAguTNvbmgFA<_0001>();
				HENtlJpbLTfyvGNBdnYOTBUpGwmPA hENtlJpbLTfyvGNBdnYOTBUpGwmPA = yfZPVbkoNrPFYlhxRcQrxPzDLvft.QecjgvgRSXuPhnYvNrbSsHRqQwjg.AXLlayIlTwJqJNaNzeKccuszIcODb(controllerType);
				int num = hENtlJpbLTfyvGNBdnYOTBUpGwmPA.LwDtjAISpvZKUEBiCEPKHyoscvdr(P_0);
				if (num < 0)
				{
					return null;
				}
				List<_0001> list = new List<_0001>();
				FsyiqPdJeSfbLIuiSYvjZeDpZMzW fsyiqPdJeSfbLIuiSYvjZeDpZMzW = hENtlJpbLTfyvGNBdnYOTBUpGwmPA.gmqWnmpZMnASuZpGLEqmJcwgXIqMA(num).ycfaKniCLOzZqlQviANrBfbEZIlRA();
				for (int i = 0; i < fsyiqPdJeSfbLIuiSYvjZeDpZMzW.ejOOZrUqJLRyRGoRofwTThHfNEkF(); i++)
				{
					ControllerMap controllerMap = fsyiqPdJeSfbLIuiSYvjZeDpZMzW.QIeXsLdCiAXGGxCgarjGtHyqkDbM(i);
					if (P_1)
					{
						InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(controllerMap.categoryId);
						if (mapCategory != null && !mapCategory.userAssignable)
						{
							continue;
						}
					}
					Controller controller = hENtlJpbLTfyvGNBdnYOTBUpGwmPA.gmqWnmpZMnASuZpGLEqmJcwgXIqMA(num).hfcnXcmxHjJxWTdCahVjbHZvxlVj();
					list.Add(ControllerMapSaveData.gCkljfJrKKFTKgywzWxECuyHjteI<_0001>(controller, controllerMap));
				}
				return list.ToArray();
			}

			private ControllerMapSaveData[] tdpIgdWfusqMpviutmSAumzYgnmj(ControllerType P_0, bool P_1)
			{
				HENtlJpbLTfyvGNBdnYOTBUpGwmPA hENtlJpbLTfyvGNBdnYOTBUpGwmPA = yfZPVbkoNrPFYlhxRcQrxPzDLvft.QecjgvgRSXuPhnYvNrbSsHRqQwjg.AXLlayIlTwJqJNaNzeKccuszIcODb(P_0);
				List<ControllerMapSaveData> list = new List<ControllerMapSaveData>();
				for (int i = 0; i < hENtlJpbLTfyvGNBdnYOTBUpGwmPA.rphZqyUfbdoINyXndGfDbQaiIHFM(); i++)
				{
					FsyiqPdJeSfbLIuiSYvjZeDpZMzW fsyiqPdJeSfbLIuiSYvjZeDpZMzW = hENtlJpbLTfyvGNBdnYOTBUpGwmPA.gmqWnmpZMnASuZpGLEqmJcwgXIqMA(i).ycfaKniCLOzZqlQviANrBfbEZIlRA();
					for (int j = 0; j < fsyiqPdJeSfbLIuiSYvjZeDpZMzW.ejOOZrUqJLRyRGoRofwTThHfNEkF(); j++)
					{
						ControllerMap controllerMap = fsyiqPdJeSfbLIuiSYvjZeDpZMzW.QIeXsLdCiAXGGxCgarjGtHyqkDbM(j);
						if (P_1)
						{
							InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(controllerMap.categoryId);
							if (mapCategory != null && !mapCategory.userAssignable)
							{
								continue;
							}
						}
						Controller controller = hENtlJpbLTfyvGNBdnYOTBUpGwmPA.gmqWnmpZMnASuZpGLEqmJcwgXIqMA(i).hfcnXcmxHjJxWTdCahVjbHZvxlVj();
						list.Add(ControllerMapSaveData.gCkljfJrKKFTKgywzWxECuyHjteI(controller, controllerMap));
					}
				}
				return list.ToArray();
			}

			private _0001[] BtkclxjWILzBcNoowcVYXwgEpIQs<_0001>(bool P_0) where _0001 : ControllerMapSaveData
			{
				ControllerType controllerType = IyPmashUlRgIygDiHFyDZHZmauql.RtpCJVkDeYglOKQzFNAguTNvbmgFA<_0001>();
				HENtlJpbLTfyvGNBdnYOTBUpGwmPA hENtlJpbLTfyvGNBdnYOTBUpGwmPA = yfZPVbkoNrPFYlhxRcQrxPzDLvft.QecjgvgRSXuPhnYvNrbSsHRqQwjg.AXLlayIlTwJqJNaNzeKccuszIcODb(controllerType);
				List<_0001> list = new List<_0001>();
				for (int i = 0; i < hENtlJpbLTfyvGNBdnYOTBUpGwmPA.rphZqyUfbdoINyXndGfDbQaiIHFM(); i++)
				{
					FsyiqPdJeSfbLIuiSYvjZeDpZMzW fsyiqPdJeSfbLIuiSYvjZeDpZMzW = hENtlJpbLTfyvGNBdnYOTBUpGwmPA.gmqWnmpZMnASuZpGLEqmJcwgXIqMA(i).ycfaKniCLOzZqlQviANrBfbEZIlRA();
					for (int j = 0; j < fsyiqPdJeSfbLIuiSYvjZeDpZMzW.ejOOZrUqJLRyRGoRofwTThHfNEkF(); j++)
					{
						ControllerMap controllerMap = fsyiqPdJeSfbLIuiSYvjZeDpZMzW.QIeXsLdCiAXGGxCgarjGtHyqkDbM(j);
						if (P_0)
						{
							InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(controllerMap.categoryId);
							if (mapCategory != null && !mapCategory.userAssignable)
							{
								continue;
							}
						}
						Controller controller = hENtlJpbLTfyvGNBdnYOTBUpGwmPA.gmqWnmpZMnASuZpGLEqmJcwgXIqMA(i).hfcnXcmxHjJxWTdCahVjbHZvxlVj();
						list.Add(ControllerMapSaveData.gCkljfJrKKFTKgywzWxECuyHjteI<_0001>(controller, controllerMap));
					}
				}
				return list.ToArray();
			}

			private int GYJVEAZaqILxKKfnBtuwxBMynxlq(ControllerType P_0, int P_1, int P_2, List<ControllerMap> P_3)
			{
				HENtlJpbLTfyvGNBdnYOTBUpGwmPA hENtlJpbLTfyvGNBdnYOTBUpGwmPA = yfZPVbkoNrPFYlhxRcQrxPzDLvft.QecjgvgRSXuPhnYvNrbSsHRqQwjg.AXLlayIlTwJqJNaNzeKccuszIcODb(P_0);
				int num = hENtlJpbLTfyvGNBdnYOTBUpGwmPA.LwDtjAISpvZKUEBiCEPKHyoscvdr(P_1);
				if (num < 0)
				{
					return 0;
				}
				return hENtlJpbLTfyvGNBdnYOTBUpGwmPA.gmqWnmpZMnASuZpGLEqmJcwgXIqMA(num).ycfaKniCLOzZqlQviANrBfbEZIlRA().XrtQuIfXPnNyDQZOsqQJCGMljsyHA(P_2, P_3, false);
			}

			private int RKepeiMLVAWjMrHQgmJtGoyEqpCe(Controller P_0, int P_1, List<ControllerMap> P_2)
			{
				return GYJVEAZaqILxKKfnBtuwxBMynxlq(P_0.type, P_0.id, P_1, P_2);
			}

			private int JFOfhUXbDQxVDlVQcznsLZLdVyMG(ControllerType P_0, int P_1, string P_2, List<ControllerMap> P_3)
			{
				int mapCategoryId = ReInput.UserData.GetMapCategoryId(P_2);
				if (mapCategoryId < 0)
				{
					return 0;
				}
				return GYJVEAZaqILxKKfnBtuwxBMynxlq(P_0, P_1, mapCategoryId, P_3);
			}

			private int atTUIJnuizVzOSDaEGilDCQsLWfs(Controller P_0, string P_1, List<ControllerMap> P_2)
			{
				return JFOfhUXbDQxVDlVQcznsLZLdVyMG(P_0.type, P_0.id, P_1, P_2);
			}

			[IteratorStateMachine(typeof(pVwofaTjyXFriIklDtZrktIXBSWKA))]
			private IEnumerable<ControllerMap> DVavlEaGMrOCQKmxpSoRfExhiHTh(ControllerType P_0, int P_1, int P_2)
			{
				return new pVwofaTjyXFriIklDtZrktIXBSWKA(-2)
				{
					akafSMtCOCGAXoGnXFOTtGwTDdgt = this,
					YSjRNDoIwFhWvKAfTgMWtsqxARPCA = P_0,
					WpXqyLWiLwDXxbLAeTxTJcNaiPyW = P_1,
					CMPIjzVTKbvcZvlGFCGdBJHmMMdMA = P_2
				};
			}

			[IteratorStateMachine(typeof(QlQREzIGiEqzwqsAupgsMwvzntaV))]
			private IEnumerable<_0001> oxsGGzgoGfCiRUJyxwneDNyMHMZcb<_0001>(int P_0, int P_1) where _0001 : ControllerMap
			{
				return new QlQREzIGiEqzwqsAupgsMwvzntaV<_0001>(-2)
				{
					LHeeyQQtKOBUJiPpaNbSVcmiaXkWA = this,
					gFxFxxLoCshxlaGBCqRlCuYqJwKGb = P_0,
					tpHeMwvLFSjwRivBvDLwcvnOEWTD = P_1
				};
			}

			private ActionElementMap yLoJdaQtNdSMCfHmRcQyBRUwAUAdb(ControllerType P_0, int P_1, bool P_2)
			{
				if (P_1 < 0)
				{
					return null;
				}
				HENtlJpbLTfyvGNBdnYOTBUpGwmPA hENtlJpbLTfyvGNBdnYOTBUpGwmPA = yfZPVbkoNrPFYlhxRcQrxPzDLvft.QecjgvgRSXuPhnYvNrbSsHRqQwjg.AXLlayIlTwJqJNaNzeKccuszIcODb(P_0);
				for (int i = 0; i < hENtlJpbLTfyvGNBdnYOTBUpGwmPA.rphZqyUfbdoINyXndGfDbQaiIHFM(); i++)
				{
					IList<ControllerMap> list = hENtlJpbLTfyvGNBdnYOTBUpGwmPA.gmqWnmpZMnASuZpGLEqmJcwgXIqMA(i).ycfaKniCLOzZqlQviANrBfbEZIlRA().yNPIkhCQyqKjUMKWnmnPppLEAttk();
					for (int j = 0; j < list.Count; j++)
					{
						if ((!P_2 || list[j].enabled) && list[j].ContainsAction(P_1))
						{
							ActionElementMap firstButtonMapWithAction = list[j].GetFirstButtonMapWithAction(P_1, P_2);
							if (firstButtonMapWithAction != null)
							{
								return firstButtonMapWithAction;
							}
						}
					}
				}
				return null;
			}

			private ActionElementMap JnmaIUCXBIbXSAgRRnhyIRviBKNHc(ControllerType P_0, string P_1, bool P_2)
			{
				int num = ReInput.IsSPFehscBAmxtEADWGWuasjDvqf.GhVjGDQeDQmOWTnROakHcfdeCdDd(P_1);
				return yLoJdaQtNdSMCfHmRcQyBRUwAUAdb(P_0, num, P_2);
			}

			[IteratorStateMachine(typeof(maXBdORCNjomDMKmDAxMxRXBiVvo))]
			private IEnumerable<ActionElementMap> ntPtqlJMDiemaqynptpdOUPEfmic(ControllerType P_0, int P_1, bool P_2)
			{
				return new maXBdORCNjomDMKmDAxMxRXBiVvo(-2)
				{
					PRcLfKxqWvEmDsjJHcMZriwIuzuB = this,
					WHBogqzTgSYLbrjIpfmJUmrbqQDF = P_0,
					bLibKxsQEragqIBMdXCQxDwXHxcr = P_1,
					FkPUbRGsXcMkCJFJZiPJjAkocyhqA = P_2
				};
			}

			private IEnumerable<ActionElementMap> zOyaHwGKoFSJdWuwKuXRdVJQenDcb(ControllerType P_0, string P_1, bool P_2)
			{
				int num = ReInput.IsSPFehscBAmxtEADWGWuasjDvqf.GhVjGDQeDQmOWTnROakHcfdeCdDd(P_1);
				return ntPtqlJMDiemaqynptpdOUPEfmic(P_0, num, P_2);
			}

			private ActionElementMap AJWCJtngsczmLwoCkxfjREIDmPhe(ControllerType P_0, int P_1, bool P_2)
			{
				if (P_1 < 0)
				{
					return null;
				}
				HENtlJpbLTfyvGNBdnYOTBUpGwmPA hENtlJpbLTfyvGNBdnYOTBUpGwmPA = yfZPVbkoNrPFYlhxRcQrxPzDLvft.QecjgvgRSXuPhnYvNrbSsHRqQwjg.AXLlayIlTwJqJNaNzeKccuszIcODb(P_0);
				for (int i = 0; i < hENtlJpbLTfyvGNBdnYOTBUpGwmPA.rphZqyUfbdoINyXndGfDbQaiIHFM(); i++)
				{
					IList<ControllerMap> list = hENtlJpbLTfyvGNBdnYOTBUpGwmPA.gmqWnmpZMnASuZpGLEqmJcwgXIqMA(i).ycfaKniCLOzZqlQviANrBfbEZIlRA().yNPIkhCQyqKjUMKWnmnPppLEAttk();
					for (int j = 0; j < list.Count; j++)
					{
						if (!(list[j] is ControllerMapWithAxes))
						{
							return null;
						}
						if ((!P_2 || list[j].enabled) && list[j].ContainsAction(P_1))
						{
							ActionElementMap firstAxisMapWithAction = (list[j] as ControllerMapWithAxes).GetFirstAxisMapWithAction(P_1, P_2);
							if (firstAxisMapWithAction != null)
							{
								return firstAxisMapWithAction;
							}
						}
					}
				}
				return null;
			}

			private ActionElementMap fYozcfWitniZSHJKTtcHetCoqmK(ControllerType P_0, string P_1, bool P_2)
			{
				int num = ReInput.IsSPFehscBAmxtEADWGWuasjDvqf.GhVjGDQeDQmOWTnROakHcfdeCdDd(P_1);
				return AJWCJtngsczmLwoCkxfjREIDmPhe(P_0, num, P_2);
			}

			[IteratorStateMachine(typeof(lqbGJfbgaHOFbJyprTczOrNAfbaT))]
			private IEnumerable<ActionElementMap> tRglqBggiWgbJjZlawtGJqRwhGCMA(ControllerType P_0, int P_1, bool P_2)
			{
				return new lqbGJfbgaHOFbJyprTczOrNAfbaT(-2)
				{
					mWrZjBgWWVhKhAuWCHFTxfrvRNbC = this,
					WJWXcsoHqxtaaYKyGckCbFMkeqAfb = P_0,
					LiZEpieUOoEFiWEgqfIRgApnPcZY = P_1,
					pPdvykSuDGshUercnlZkJmJkElRR = P_2
				};
			}

			private IEnumerable<ActionElementMap> fIWjVvmxsxdMDdLglzguVFitwwQf(ControllerType P_0, string P_1, bool P_2)
			{
				int num = ReInput.IsSPFehscBAmxtEADWGWuasjDvqf.GhVjGDQeDQmOWTnROakHcfdeCdDd(P_1);
				return tRglqBggiWgbJjZlawtGJqRwhGCMA(P_0, num, P_2);
			}

			private ActionElementMap ccweTNqYETnxFaKlVxThBFWqDMEA(ControllerType P_0, int P_1, bool P_2)
			{
				if (P_1 < 0)
				{
					return null;
				}
				HENtlJpbLTfyvGNBdnYOTBUpGwmPA hENtlJpbLTfyvGNBdnYOTBUpGwmPA = yfZPVbkoNrPFYlhxRcQrxPzDLvft.QecjgvgRSXuPhnYvNrbSsHRqQwjg.AXLlayIlTwJqJNaNzeKccuszIcODb(P_0);
				for (int i = 0; i < hENtlJpbLTfyvGNBdnYOTBUpGwmPA.rphZqyUfbdoINyXndGfDbQaiIHFM(); i++)
				{
					IList<ControllerMap> list = hENtlJpbLTfyvGNBdnYOTBUpGwmPA.gmqWnmpZMnASuZpGLEqmJcwgXIqMA(i).ycfaKniCLOzZqlQviANrBfbEZIlRA().yNPIkhCQyqKjUMKWnmnPppLEAttk();
					for (int j = 0; j < list.Count; j++)
					{
						if ((!P_2 || list[j].enabled) && list[j].ContainsAction(P_1))
						{
							ActionElementMap firstElementMapWithAction = list[j].GetFirstElementMapWithAction(P_1, P_2);
							if (firstElementMapWithAction != null)
							{
								return firstElementMapWithAction;
							}
						}
					}
				}
				return null;
			}

			private ActionElementMap qpYyrWDnueRLcQZScayAQSYlrijk(ControllerType P_0, string P_1, bool P_2)
			{
				int num = ReInput.IsSPFehscBAmxtEADWGWuasjDvqf.GhVjGDQeDQmOWTnROakHcfdeCdDd(P_1);
				return ccweTNqYETnxFaKlVxThBFWqDMEA(P_0, num, P_2);
			}

			[IteratorStateMachine(typeof(NoRaHZrRkapKaXaxOIdFXtoBmWQO))]
			private IEnumerable<ActionElementMap> HyvrKAXTuqZdVUMugpAEAFWfwlQA(ControllerType P_0, int P_1, bool P_2)
			{
				return new NoRaHZrRkapKaXaxOIdFXtoBmWQO(-2)
				{
					PZggkLPcqnfnQFiaCqoonDuhkxoI = this,
					hnXeGRcTBscHMhILTngjXGdeFcwY = P_0,
					ETrXWJbjDwfqBDTaaPKDMVAWRMfm = P_1,
					YBwYItQpxfBbheltdwpIEAMDzWpGA = P_2
				};
			}

			private IEnumerable<ActionElementMap> eHfIfqoLPtHoGfmKztwmoUWFIBsX(ControllerType P_0, string P_1, bool P_2)
			{
				int num = ReInput.IsSPFehscBAmxtEADWGWuasjDvqf.GhVjGDQeDQmOWTnROakHcfdeCdDd(P_1);
				return HyvrKAXTuqZdVUMugpAEAFWfwlQA(P_0, num, P_2);
			}

			private int vcLOsrJCMpezNhbtErqdNNKZoAHG(int P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
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
				int kzSWyhVFpKvuMAleUEiVntIEyGZD = yfZPVbkoNrPFYlhxRcQrxPzDLvft.QecjgvgRSXuPhnYvNrbSsHRqQwjg.KzSWyhVFpKvuMAleUEiVntIEyGZD;
				for (int i = 0; i < kzSWyhVFpKvuMAleUEiVntIEyGZD; i++)
				{
					HENtlJpbLTfyvGNBdnYOTBUpGwmPA hENtlJpbLTfyvGNBdnYOTBUpGwmPA = yfZPVbkoNrPFYlhxRcQrxPzDLvft.QecjgvgRSXuPhnYvNrbSsHRqQwjg.AMmiEUMJUxmCKCltvrDeLoaPvEGE(i);
					int num2 = hENtlJpbLTfyvGNBdnYOTBUpGwmPA.rphZqyUfbdoINyXndGfDbQaiIHFM();
					for (int j = 0; j < num2; j++)
					{
						FsyiqPdJeSfbLIuiSYvjZeDpZMzW fsyiqPdJeSfbLIuiSYvjZeDpZMzW = hENtlJpbLTfyvGNBdnYOTBUpGwmPA.gmqWnmpZMnASuZpGLEqmJcwgXIqMA(j).ycfaKniCLOzZqlQviANrBfbEZIlRA();
						int num3 = fsyiqPdJeSfbLIuiSYvjZeDpZMzW.ejOOZrUqJLRyRGoRofwTThHfNEkF();
						for (int k = 0; k < num3; k++)
						{
							ControllerMap controllerMap = fsyiqPdJeSfbLIuiSYvjZeDpZMzW.QIeXsLdCiAXGGxCgarjGtHyqkDbM(k);
							if ((!P_1 || controllerMap.enabled) && controllerMap.ContainsAction(P_0))
							{
								num += controllerMap.McklfRwAeXVOuqClaWFCiKesBkgI(P_0, P_1, P_2, true);
							}
						}
					}
				}
				return num;
			}

			private int dkcSkzhUSuysAuoepIjClOLfkCfd(int P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
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
				int kzSWyhVFpKvuMAleUEiVntIEyGZD = yfZPVbkoNrPFYlhxRcQrxPzDLvft.QecjgvgRSXuPhnYvNrbSsHRqQwjg.KzSWyhVFpKvuMAleUEiVntIEyGZD;
				for (int i = 0; i < kzSWyhVFpKvuMAleUEiVntIEyGZD; i++)
				{
					HENtlJpbLTfyvGNBdnYOTBUpGwmPA hENtlJpbLTfyvGNBdnYOTBUpGwmPA = yfZPVbkoNrPFYlhxRcQrxPzDLvft.QecjgvgRSXuPhnYvNrbSsHRqQwjg.AMmiEUMJUxmCKCltvrDeLoaPvEGE(i);
					int num2 = hENtlJpbLTfyvGNBdnYOTBUpGwmPA.rphZqyUfbdoINyXndGfDbQaiIHFM();
					for (int j = 0; j < num2; j++)
					{
						FsyiqPdJeSfbLIuiSYvjZeDpZMzW fsyiqPdJeSfbLIuiSYvjZeDpZMzW = hENtlJpbLTfyvGNBdnYOTBUpGwmPA.gmqWnmpZMnASuZpGLEqmJcwgXIqMA(j).ycfaKniCLOzZqlQviANrBfbEZIlRA();
						int num3 = fsyiqPdJeSfbLIuiSYvjZeDpZMzW.ejOOZrUqJLRyRGoRofwTThHfNEkF();
						for (int k = 0; k < num3; k++)
						{
							if (fsyiqPdJeSfbLIuiSYvjZeDpZMzW.QIeXsLdCiAXGGxCgarjGtHyqkDbM(k) is ControllerMapWithAxes controllerMapWithAxes && (!P_1 || controllerMapWithAxes.enabled) && controllerMapWithAxes.ContainsAction(P_0))
							{
								num += controllerMapWithAxes.jYwGpXSGaXGVHUvYLtxyHEAXqYHi(P_0, P_1, P_2, true);
							}
						}
					}
				}
				return num;
			}

			private int yoiqMrqtvTnbqBoCrBwDPVRveWpA(int P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
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
				int kzSWyhVFpKvuMAleUEiVntIEyGZD = yfZPVbkoNrPFYlhxRcQrxPzDLvft.QecjgvgRSXuPhnYvNrbSsHRqQwjg.KzSWyhVFpKvuMAleUEiVntIEyGZD;
				for (int i = 0; i < kzSWyhVFpKvuMAleUEiVntIEyGZD; i++)
				{
					HENtlJpbLTfyvGNBdnYOTBUpGwmPA hENtlJpbLTfyvGNBdnYOTBUpGwmPA = yfZPVbkoNrPFYlhxRcQrxPzDLvft.QecjgvgRSXuPhnYvNrbSsHRqQwjg.AMmiEUMJUxmCKCltvrDeLoaPvEGE(i);
					int num2 = hENtlJpbLTfyvGNBdnYOTBUpGwmPA.rphZqyUfbdoINyXndGfDbQaiIHFM();
					for (int j = 0; j < num2; j++)
					{
						FsyiqPdJeSfbLIuiSYvjZeDpZMzW fsyiqPdJeSfbLIuiSYvjZeDpZMzW = hENtlJpbLTfyvGNBdnYOTBUpGwmPA.gmqWnmpZMnASuZpGLEqmJcwgXIqMA(j).ycfaKniCLOzZqlQviANrBfbEZIlRA();
						int num3 = fsyiqPdJeSfbLIuiSYvjZeDpZMzW.ejOOZrUqJLRyRGoRofwTThHfNEkF();
						for (int k = 0; k < num3; k++)
						{
							ControllerMap controllerMap = fsyiqPdJeSfbLIuiSYvjZeDpZMzW.QIeXsLdCiAXGGxCgarjGtHyqkDbM(k);
							if ((!P_1 || controllerMap.enabled) && controllerMap.ContainsAction(P_0))
							{
								num += controllerMap.udqxaEGIrvufGdIfXccpPRDnNltr(P_0, P_1, P_2, true);
							}
						}
					}
				}
				return num;
			}

			private int WgSlUhwJkOpDTPILMhPrMXfCFsEHA(ControllerType P_0, int P_1, bool P_2, List<ActionElementMap> P_3, bool P_4)
			{
				if (P_3 == null)
				{
					throw new ArgumentNullException("results");
				}
				if (!P_4)
				{
					P_3.Clear();
				}
				if (P_1 < 0)
				{
					return 0;
				}
				int num = 0;
				HENtlJpbLTfyvGNBdnYOTBUpGwmPA hENtlJpbLTfyvGNBdnYOTBUpGwmPA = yfZPVbkoNrPFYlhxRcQrxPzDLvft.QecjgvgRSXuPhnYvNrbSsHRqQwjg.AXLlayIlTwJqJNaNzeKccuszIcODb(P_0);
				for (int i = 0; i < hENtlJpbLTfyvGNBdnYOTBUpGwmPA.rphZqyUfbdoINyXndGfDbQaiIHFM(); i++)
				{
					IList<ControllerMap> list = hENtlJpbLTfyvGNBdnYOTBUpGwmPA.gmqWnmpZMnASuZpGLEqmJcwgXIqMA(i).ycfaKniCLOzZqlQviANrBfbEZIlRA().yNPIkhCQyqKjUMKWnmnPppLEAttk();
					for (int j = 0; j < list.Count; j++)
					{
						if ((!P_2 || list[j].enabled) && list[j].ContainsAction(P_1))
						{
							num += list[j].McklfRwAeXVOuqClaWFCiKesBkgI(P_1, P_2, P_3, true);
						}
					}
				}
				return num;
			}

			private int oTFuTmAlkHGfjAUSURkomvRaCnZgA(ControllerType P_0, string P_1, bool P_2, List<ActionElementMap> P_3, bool P_4)
			{
				int num = ReInput.IsSPFehscBAmxtEADWGWuasjDvqf.GhVjGDQeDQmOWTnROakHcfdeCdDd(P_1);
				return WgSlUhwJkOpDTPILMhPrMXfCFsEHA(P_0, num, P_2, P_3, P_4);
			}

			private int sNcOltfbTVzJamtVloDmREztcLbW(ControllerType P_0, int P_1, bool P_2, List<ActionElementMap> P_3, bool P_4)
			{
				if (P_3 == null)
				{
					throw new ArgumentNullException("results");
				}
				if (!P_4)
				{
					P_3.Clear();
				}
				if (P_1 < 0)
				{
					return 0;
				}
				int num = 0;
				HENtlJpbLTfyvGNBdnYOTBUpGwmPA hENtlJpbLTfyvGNBdnYOTBUpGwmPA = yfZPVbkoNrPFYlhxRcQrxPzDLvft.QecjgvgRSXuPhnYvNrbSsHRqQwjg.AXLlayIlTwJqJNaNzeKccuszIcODb(P_0);
				for (int i = 0; i < hENtlJpbLTfyvGNBdnYOTBUpGwmPA.rphZqyUfbdoINyXndGfDbQaiIHFM(); i++)
				{
					IList<ControllerMap> list = hENtlJpbLTfyvGNBdnYOTBUpGwmPA.gmqWnmpZMnASuZpGLEqmJcwgXIqMA(i).ycfaKniCLOzZqlQviANrBfbEZIlRA().yNPIkhCQyqKjUMKWnmnPppLEAttk();
					for (int j = 0; j < list.Count; j++)
					{
						if (!(list[j] is ControllerMapWithAxes))
						{
							return P_3.Count;
						}
						if ((!P_2 || list[j].enabled) && list[j].ContainsAction(P_1))
						{
							num += (list[j] as ControllerMapWithAxes).jYwGpXSGaXGVHUvYLtxyHEAXqYHi(P_1, P_2, P_3, true);
						}
					}
				}
				return num;
			}

			private int exQmSMpbjqQhGuDqcESaUyucfumT(ControllerType P_0, string P_1, bool P_2, List<ActionElementMap> P_3, bool P_4)
			{
				int num = ReInput.IsSPFehscBAmxtEADWGWuasjDvqf.GhVjGDQeDQmOWTnROakHcfdeCdDd(P_1);
				return sNcOltfbTVzJamtVloDmREztcLbW(P_0, num, P_2, P_3, P_4);
			}

			private int eqBMyUkWIMfTxaNYWgNixcUGbOWz(ControllerType P_0, int P_1, bool P_2, List<ActionElementMap> P_3, bool P_4)
			{
				if (P_3 == null)
				{
					throw new ArgumentNullException("results");
				}
				if (!P_4)
				{
					P_3.Clear();
				}
				if (P_1 < 0)
				{
					return 0;
				}
				int num = 0;
				HENtlJpbLTfyvGNBdnYOTBUpGwmPA hENtlJpbLTfyvGNBdnYOTBUpGwmPA = yfZPVbkoNrPFYlhxRcQrxPzDLvft.QecjgvgRSXuPhnYvNrbSsHRqQwjg.AXLlayIlTwJqJNaNzeKccuszIcODb(P_0);
				for (int i = 0; i < hENtlJpbLTfyvGNBdnYOTBUpGwmPA.rphZqyUfbdoINyXndGfDbQaiIHFM(); i++)
				{
					IList<ControllerMap> list = hENtlJpbLTfyvGNBdnYOTBUpGwmPA.gmqWnmpZMnASuZpGLEqmJcwgXIqMA(i).ycfaKniCLOzZqlQviANrBfbEZIlRA().yNPIkhCQyqKjUMKWnmnPppLEAttk();
					for (int j = 0; j < list.Count; j++)
					{
						if ((!P_2 || list[j].enabled) && list[j].ContainsAction(P_1))
						{
							num += list[j].udqxaEGIrvufGdIfXccpPRDnNltr(P_1, P_2, P_3, true);
						}
					}
				}
				return num;
			}

			private int uSdDfbTnOuRheBwntFvOqflkiFohA(ControllerType P_0, string P_1, bool P_2, List<ActionElementMap> P_3, bool P_4)
			{
				int num = ReInput.IsSPFehscBAmxtEADWGWuasjDvqf.GhVjGDQeDQmOWTnROakHcfdeCdDd(P_1);
				return eqBMyUkWIMfTxaNYWgNixcUGbOWz(P_0, num, P_2, P_3, P_4);
			}

			private ActionElementMap usRdUVNtlpekviYmKgGlTBAtYhRGA(ControllerType P_0, int P_1, int P_2, bool P_3)
			{
				if (P_2 < 0)
				{
					return null;
				}
				HENtlJpbLTfyvGNBdnYOTBUpGwmPA hENtlJpbLTfyvGNBdnYOTBUpGwmPA = yfZPVbkoNrPFYlhxRcQrxPzDLvft.QecjgvgRSXuPhnYvNrbSsHRqQwjg.AXLlayIlTwJqJNaNzeKccuszIcODb(P_0);
				int num = hENtlJpbLTfyvGNBdnYOTBUpGwmPA.LwDtjAISpvZKUEBiCEPKHyoscvdr(P_1);
				if (num < 0)
				{
					return null;
				}
				IList<ControllerMap> list = hENtlJpbLTfyvGNBdnYOTBUpGwmPA.gmqWnmpZMnASuZpGLEqmJcwgXIqMA(num).ycfaKniCLOzZqlQviANrBfbEZIlRA().yNPIkhCQyqKjUMKWnmnPppLEAttk();
				for (int i = 0; i < list.Count; i++)
				{
					if ((!P_3 || list[i].enabled) && list[i].ContainsAction(P_2))
					{
						ActionElementMap firstButtonMapWithAction = list[i].GetFirstButtonMapWithAction(P_2, P_3);
						if (firstButtonMapWithAction != null)
						{
							return firstButtonMapWithAction;
						}
					}
				}
				return null;
			}

			private ActionElementMap uoXvBYuugVwOTIsznUKfjsLKPueV(ControllerType P_0, int P_1, string P_2, bool P_3)
			{
				int num = ReInput.IsSPFehscBAmxtEADWGWuasjDvqf.GhVjGDQeDQmOWTnROakHcfdeCdDd(P_2);
				return usRdUVNtlpekviYmKgGlTBAtYhRGA(P_0, P_1, num, P_3);
			}

			[IteratorStateMachine(typeof(XkOQfQWrjdZlPYxiCTPtpBIvJkLm))]
			private IEnumerable<ActionElementMap> LFfZoDgrOGvkQeMlHdpjHFTIKaAw(ControllerType P_0, int P_1, int P_2, bool P_3)
			{
				return new XkOQfQWrjdZlPYxiCTPtpBIvJkLm(-2)
				{
					QbtdDIKVOrLGBqtTukKgCUaOgDwI = this,
					VkyBLzlGoKgCoFwEOegleqvwSGPAA = P_0,
					CiciTZrqMklbwKKoGGNeyJGSBULo = P_1,
					xGbvscBtruudQLrPDULXROjhCyRAA = P_2,
					BojYzLeaElLyUvvkcGoVUugcNaqO = P_3
				};
			}

			private IEnumerable<ActionElementMap> cMvfoxaHKYEZrfNwLskMFBeCUUxnA(ControllerType P_0, int P_1, string P_2, bool P_3)
			{
				int num = ReInput.IsSPFehscBAmxtEADWGWuasjDvqf.GhVjGDQeDQmOWTnROakHcfdeCdDd(P_2);
				return LFfZoDgrOGvkQeMlHdpjHFTIKaAw(P_0, P_1, num, P_3);
			}

			private ActionElementMap CHRDofdHyzyjtvKqlobJXsVKGJlhA(ControllerType P_0, int P_1, int P_2, bool P_3)
			{
				if (P_2 < 0)
				{
					return null;
				}
				HENtlJpbLTfyvGNBdnYOTBUpGwmPA hENtlJpbLTfyvGNBdnYOTBUpGwmPA = yfZPVbkoNrPFYlhxRcQrxPzDLvft.QecjgvgRSXuPhnYvNrbSsHRqQwjg.AXLlayIlTwJqJNaNzeKccuszIcODb(P_0);
				int num = hENtlJpbLTfyvGNBdnYOTBUpGwmPA.LwDtjAISpvZKUEBiCEPKHyoscvdr(P_1);
				if (num < 0)
				{
					return null;
				}
				IList<ControllerMap> list = hENtlJpbLTfyvGNBdnYOTBUpGwmPA.gmqWnmpZMnASuZpGLEqmJcwgXIqMA(num).ycfaKniCLOzZqlQviANrBfbEZIlRA().yNPIkhCQyqKjUMKWnmnPppLEAttk();
				for (int i = 0; i < list.Count; i++)
				{
					if (!(list[i] is ControllerMapWithAxes))
					{
						return null;
					}
					if ((!P_3 || list[i].enabled) && list[i].ContainsAction(P_2))
					{
						ActionElementMap firstAxisMapWithAction = (list[i] as ControllerMapWithAxes).GetFirstAxisMapWithAction(P_2, P_3);
						if (firstAxisMapWithAction != null)
						{
							return firstAxisMapWithAction;
						}
					}
				}
				return null;
			}

			private ActionElementMap SuFxEhTqIAQFbaFWNpRJttPhHRYl(ControllerType P_0, int P_1, string P_2, bool P_3)
			{
				int num = ReInput.IsSPFehscBAmxtEADWGWuasjDvqf.GhVjGDQeDQmOWTnROakHcfdeCdDd(P_2);
				return CHRDofdHyzyjtvKqlobJXsVKGJlhA(P_0, P_1, num, P_3);
			}

			[IteratorStateMachine(typeof(hQMKFYXDhUNlKXlIgbGpjAwoUigx))]
			private IEnumerable<ActionElementMap> RhpIuDYeuZAoRkwJPkNNfkELyKcBA(ControllerType P_0, int P_1, int P_2, bool P_3)
			{
				return new hQMKFYXDhUNlKXlIgbGpjAwoUigx(-2)
				{
					WmddBnHHVbhynxYCFeFjgslIpQHKA = this,
					cZcBdloXvncoKtUYGWHqPwjBKNiG = P_0,
					ZTFezEWRaEYdFAVTeUfFjwbmZEAC = P_1,
					rwdhNZDpjENIkXkHamSkoIbCDoRO = P_2,
					qmTAHJaBMFnbhiaVcadcdljrKsnOc = P_3
				};
			}

			private IEnumerable<ActionElementMap> FsVErpGqGWhMadzEnxlYPrWZmjhm(ControllerType P_0, int P_1, string P_2, bool P_3)
			{
				int num = ReInput.IsSPFehscBAmxtEADWGWuasjDvqf.GhVjGDQeDQmOWTnROakHcfdeCdDd(P_2);
				return RhpIuDYeuZAoRkwJPkNNfkELyKcBA(P_0, P_1, num, P_3);
			}

			private ActionElementMap kdArDGRjlYbYjUxerZUCaNQAEHiO(ControllerType P_0, int P_1, int P_2, bool P_3)
			{
				if (P_2 < 0)
				{
					return null;
				}
				HENtlJpbLTfyvGNBdnYOTBUpGwmPA hENtlJpbLTfyvGNBdnYOTBUpGwmPA = yfZPVbkoNrPFYlhxRcQrxPzDLvft.QecjgvgRSXuPhnYvNrbSsHRqQwjg.AXLlayIlTwJqJNaNzeKccuszIcODb(P_0);
				int num = hENtlJpbLTfyvGNBdnYOTBUpGwmPA.LwDtjAISpvZKUEBiCEPKHyoscvdr(P_1);
				if (num < 0)
				{
					return null;
				}
				IList<ControllerMap> list = hENtlJpbLTfyvGNBdnYOTBUpGwmPA.gmqWnmpZMnASuZpGLEqmJcwgXIqMA(num).ycfaKniCLOzZqlQviANrBfbEZIlRA().yNPIkhCQyqKjUMKWnmnPppLEAttk();
				for (int i = 0; i < list.Count; i++)
				{
					if ((!P_3 || list[i].enabled) && list[i].ContainsAction(P_2))
					{
						ActionElementMap firstElementMapWithAction = list[i].GetFirstElementMapWithAction(P_2, P_3);
						if (firstElementMapWithAction != null)
						{
							return firstElementMapWithAction;
						}
					}
				}
				return null;
			}

			private ActionElementMap WSJTWTxOZbBknMQbXJPtFFunmhOr(ControllerType P_0, int P_1, string P_2, bool P_3)
			{
				int num = ReInput.IsSPFehscBAmxtEADWGWuasjDvqf.GhVjGDQeDQmOWTnROakHcfdeCdDd(P_2);
				return kdArDGRjlYbYjUxerZUCaNQAEHiO(P_0, P_1, num, P_3);
			}

			[IteratorStateMachine(typeof(gkAxnNkwnzJIHSllMCthySTXdFey))]
			private IEnumerable<ActionElementMap> RQhrwxjzgUwkwcswpaywGnkAcpNI(ControllerType P_0, int P_1, int P_2, bool P_3)
			{
				return new gkAxnNkwnzJIHSllMCthySTXdFey(-2)
				{
					TfbyLhoQvrKaBMxqCmFSXZsYtwGb = this,
					lJocabdsddXReHICcQcUdUYaZuAQA = P_0,
					EkhmKgYwDTWCDOxnYNuAGOeOxHfY = P_1,
					vADAOBfSuoqHwooDtzSTBfscxOvL = P_2,
					WvRDAmttCpCeNgkMEknPgNdxjDAfb = P_3
				};
			}

			private IEnumerable<ActionElementMap> YkroRWPXxuekNzmvkwEUzLEiwsnJ(ControllerType P_0, int P_1, string P_2, bool P_3)
			{
				int num = ReInput.IsSPFehscBAmxtEADWGWuasjDvqf.GhVjGDQeDQmOWTnROakHcfdeCdDd(P_2);
				return RQhrwxjzgUwkwcswpaywGnkAcpNI(P_0, P_1, num, P_3);
			}

			private int fRvraWYGgBYlXMCRcBNxMEzMVDqk(ControllerType P_0, int P_1, int P_2, bool P_3, List<ActionElementMap> P_4, bool P_5)
			{
				if (P_4 == null)
				{
					throw new ArgumentNullException("results");
				}
				if (!P_5)
				{
					P_4.Clear();
				}
				if (P_2 < 0)
				{
					return 0;
				}
				HENtlJpbLTfyvGNBdnYOTBUpGwmPA hENtlJpbLTfyvGNBdnYOTBUpGwmPA = yfZPVbkoNrPFYlhxRcQrxPzDLvft.QecjgvgRSXuPhnYvNrbSsHRqQwjg.AXLlayIlTwJqJNaNzeKccuszIcODb(P_0);
				int num = hENtlJpbLTfyvGNBdnYOTBUpGwmPA.LwDtjAISpvZKUEBiCEPKHyoscvdr(P_1);
				if (num < 0)
				{
					return 0;
				}
				int num2 = 0;
				IList<ControllerMap> list = hENtlJpbLTfyvGNBdnYOTBUpGwmPA.gmqWnmpZMnASuZpGLEqmJcwgXIqMA(num).ycfaKniCLOzZqlQviANrBfbEZIlRA().yNPIkhCQyqKjUMKWnmnPppLEAttk();
				for (int i = 0; i < list.Count; i++)
				{
					ControllerMap controllerMap = list[i];
					if ((!P_3 || controllerMap.enabled) && controllerMap.ContainsAction(P_2))
					{
						num2 += controllerMap.McklfRwAeXVOuqClaWFCiKesBkgI(P_2, P_3, P_4, true);
					}
				}
				return num2;
			}

			private int kpNKCxqdYspbbbWjmCOJZCyhFlUF(ControllerType P_0, int P_1, string P_2, bool P_3, List<ActionElementMap> P_4, bool P_5)
			{
				int num = ReInput.IsSPFehscBAmxtEADWGWuasjDvqf.GhVjGDQeDQmOWTnROakHcfdeCdDd(P_2);
				return fRvraWYGgBYlXMCRcBNxMEzMVDqk(P_0, P_1, num, P_3, P_4, P_5);
			}

			private int DYRcLiwhMwCsbENjRBapydzPyAVuA(ControllerType P_0, int P_1, int P_2, bool P_3, List<ActionElementMap> P_4, bool P_5)
			{
				if (P_4 == null)
				{
					throw new ArgumentNullException("results");
				}
				if (!P_5)
				{
					P_4.Clear();
				}
				if (P_2 < 0)
				{
					return 0;
				}
				HENtlJpbLTfyvGNBdnYOTBUpGwmPA hENtlJpbLTfyvGNBdnYOTBUpGwmPA = yfZPVbkoNrPFYlhxRcQrxPzDLvft.QecjgvgRSXuPhnYvNrbSsHRqQwjg.AXLlayIlTwJqJNaNzeKccuszIcODb(P_0);
				int num = hENtlJpbLTfyvGNBdnYOTBUpGwmPA.LwDtjAISpvZKUEBiCEPKHyoscvdr(P_1);
				if (num < 0)
				{
					return 0;
				}
				int num2 = 0;
				IList<ControllerMap> list = hENtlJpbLTfyvGNBdnYOTBUpGwmPA.gmqWnmpZMnASuZpGLEqmJcwgXIqMA(num).ycfaKniCLOzZqlQviANrBfbEZIlRA().yNPIkhCQyqKjUMKWnmnPppLEAttk();
				for (int i = 0; i < list.Count; i++)
				{
					ControllerMapWithAxes controllerMapWithAxes = list[i] as ControllerMapWithAxes;
					if (list == null)
					{
						return num2;
					}
					if ((!P_3 || controllerMapWithAxes.enabled) && controllerMapWithAxes.ContainsAction(P_2))
					{
						num2 += controllerMapWithAxes.jYwGpXSGaXGVHUvYLtxyHEAXqYHi(P_2, P_3, P_4, true);
					}
				}
				return num2;
			}

			private int NAqWTTThGtdAbDCryWWJkHZXxpGpA(ControllerType P_0, int P_1, string P_2, bool P_3, List<ActionElementMap> P_4, bool P_5)
			{
				int num = ReInput.IsSPFehscBAmxtEADWGWuasjDvqf.GhVjGDQeDQmOWTnROakHcfdeCdDd(P_2);
				return DYRcLiwhMwCsbENjRBapydzPyAVuA(P_0, P_1, num, P_3, P_4, P_5);
			}

			private int TWTojCbaRiqLNeUGhIsovwvzsqLt(ControllerType P_0, int P_1, int P_2, bool P_3, List<ActionElementMap> P_4, bool P_5)
			{
				if (P_4 == null)
				{
					throw new ArgumentNullException("results");
				}
				if (!P_5)
				{
					P_4.Clear();
				}
				if (P_2 < 0)
				{
					return 0;
				}
				HENtlJpbLTfyvGNBdnYOTBUpGwmPA hENtlJpbLTfyvGNBdnYOTBUpGwmPA = yfZPVbkoNrPFYlhxRcQrxPzDLvft.QecjgvgRSXuPhnYvNrbSsHRqQwjg.AXLlayIlTwJqJNaNzeKccuszIcODb(P_0);
				int num = hENtlJpbLTfyvGNBdnYOTBUpGwmPA.LwDtjAISpvZKUEBiCEPKHyoscvdr(P_1);
				if (num < 0)
				{
					return 0;
				}
				int num2 = 0;
				IList<ControllerMap> list = hENtlJpbLTfyvGNBdnYOTBUpGwmPA.gmqWnmpZMnASuZpGLEqmJcwgXIqMA(num).ycfaKniCLOzZqlQviANrBfbEZIlRA().yNPIkhCQyqKjUMKWnmnPppLEAttk();
				for (int i = 0; i < list.Count; i++)
				{
					if ((!P_3 || list[i].enabled) && list[i].ContainsAction(P_2))
					{
						num2 += list[i].udqxaEGIrvufGdIfXccpPRDnNltr(P_2, P_3, P_4, true);
					}
				}
				return num2;
			}

			private int ZhxCavDFMPkbbmWjXujorzlzWSms(ControllerType P_0, int P_1, string P_2, bool P_3, List<ActionElementMap> P_4, bool P_5)
			{
				int num = ReInput.IsSPFehscBAmxtEADWGWuasjDvqf.GhVjGDQeDQmOWTnROakHcfdeCdDd(P_2);
				return TWTojCbaRiqLNeUGhIsovwvzsqLt(P_0, P_1, num, P_3, P_4, P_5);
			}

			private ActionElementMap edvSzOstfCAhDhjsBGBNjOrqpKCuA(IControllerElementTarget P_0, bool P_1, int P_2, bool P_3)
			{
				if (P_0 == null)
				{
					return null;
				}
				Controller controller = P_0.controller;
				if (controller == null)
				{
					return null;
				}
				HENtlJpbLTfyvGNBdnYOTBUpGwmPA hENtlJpbLTfyvGNBdnYOTBUpGwmPA = yfZPVbkoNrPFYlhxRcQrxPzDLvft.QecjgvgRSXuPhnYvNrbSsHRqQwjg.AXLlayIlTwJqJNaNzeKccuszIcODb(controller.type);
				int num = hENtlJpbLTfyvGNBdnYOTBUpGwmPA.rphZqyUfbdoINyXndGfDbQaiIHFM();
				for (int i = 0; i < num; i++)
				{
					FsyiqPdJeSfbLIuiSYvjZeDpZMzW fsyiqPdJeSfbLIuiSYvjZeDpZMzW = hENtlJpbLTfyvGNBdnYOTBUpGwmPA.gmqWnmpZMnASuZpGLEqmJcwgXIqMA(i).ycfaKniCLOzZqlQviANrBfbEZIlRA();
					fsyiqPdJeSfbLIuiSYvjZeDpZMzW.ejOOZrUqJLRyRGoRofwTThHfNEkF();
					IList<ControllerMap> list = fsyiqPdJeSfbLIuiSYvjZeDpZMzW.yNPIkhCQyqKjUMKWnmnPppLEAttk();
					int count = list.Count;
					for (int j = 0; j < count; j++)
					{
						ControllerMap controllerMap = list[j];
						if (!P_3 || controllerMap.enabled)
						{
							ActionElementMap actionElementMap = controllerMap.rWGkzCaHmFroxLHHiILXPuevKYvo(P_0, P_1, P_2, P_3, out var _);
							if (actionElementMap != null)
							{
								return actionElementMap;
							}
						}
					}
				}
				return null;
			}

			[IteratorStateMachine(typeof(tjbDGEecyyhXLrBMocBGihgXqDmqA))]
			private IEnumerable<ActionElementMap> FCSWvffQAyhCYYvZSwnJYbPdcyac(IControllerElementTarget P_0, bool P_1, int P_2, bool P_3)
			{
				return new tjbDGEecyyhXLrBMocBGihgXqDmqA(-2)
				{
					gjzsKoCbCkbpdAHqGmCFCIbAqqZBA = this,
					tskWNCmLvMxMDkyyBpoCuBxIVtlF = P_0,
					rNgmlHzspLNBLlxgQMxwSeguwryP = P_1,
					XpvklkJrwEYQutWuGWwjWYIijYjb = P_2,
					LVntSLbIXqeTzMixLCylBoDuYDrC = P_3
				};
			}

			private int GoLytIiqPNbvkEBgVtsXddPDOyCv(IControllerElementTarget P_0, bool P_1, int P_2, bool P_3, List<ActionElementMap> P_4, bool P_5)
			{
				if (P_4 == null)
				{
					throw new ArgumentNullException("results");
				}
				if (!P_5)
				{
					P_4.Clear();
				}
				if (P_0 == null)
				{
					return 0;
				}
				Controller controller = P_0.controller;
				if (controller == null)
				{
					return 0;
				}
				HENtlJpbLTfyvGNBdnYOTBUpGwmPA hENtlJpbLTfyvGNBdnYOTBUpGwmPA = yfZPVbkoNrPFYlhxRcQrxPzDLvft.QecjgvgRSXuPhnYvNrbSsHRqQwjg.AXLlayIlTwJqJNaNzeKccuszIcODb(controller.type);
				int num = hENtlJpbLTfyvGNBdnYOTBUpGwmPA.rphZqyUfbdoINyXndGfDbQaiIHFM();
				int num2 = 0;
				for (int i = 0; i < num; i++)
				{
					FsyiqPdJeSfbLIuiSYvjZeDpZMzW fsyiqPdJeSfbLIuiSYvjZeDpZMzW = hENtlJpbLTfyvGNBdnYOTBUpGwmPA.gmqWnmpZMnASuZpGLEqmJcwgXIqMA(i).ycfaKniCLOzZqlQviANrBfbEZIlRA();
					fsyiqPdJeSfbLIuiSYvjZeDpZMzW.ejOOZrUqJLRyRGoRofwTThHfNEkF();
					IList<ControllerMap> list = fsyiqPdJeSfbLIuiSYvjZeDpZMzW.yNPIkhCQyqKjUMKWnmnPppLEAttk();
					int count = list.Count;
					for (int j = 0; j < count; j++)
					{
						ControllerMap controllerMap = list[j];
						if (!P_3 || controllerMap.enabled)
						{
							num2 += controllerMap.AQsAVNZYhsajiONJBaCUyUaUYtSD(P_0, P_1, P_2, P_3, P_4, P_5, out var _);
						}
					}
				}
				return num2;
			}
		}

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public sealed class PollingHelper : CodeHelper
		{
			private sealed class yGIXmWQbKjUGlRrXDXtQIObmVYDC : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
			{
				private int pmYUODRjCoVCUUAxBGNJKWQmouUnA;

				private ControllerPollingInfo XrxXEKkJUoHqfyBPKeQUHoHnmAOeb;

				private int JvVYbvVnEetgAHbNEhDqCKIrLmMnA;

				public PollingHelper WYvQNDQefglgvyhsRXZiwNGoHVYR;

				private IList<CustomController> uSfnKfbHjVGlKycUbcWtGxMpBXBXA;

				private int UBUIEWFXvZlzQXJHjsHaoRDgEWXM;

				private int fXyMcQOeYtEIaMyGXwTqpfVDgCYM;

				private IEnumerator<ControllerPollingInfo> HpnnnKPJWZKQMUZyRHFprauWcFmh;

				ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
				{
					[DebuggerHidden]
					get
					{
						return XrxXEKkJUoHqfyBPKeQUHoHnmAOeb;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return XrxXEKkJUoHqfyBPKeQUHoHnmAOeb;
					}
				}

				[DebuggerHidden]
				public yGIXmWQbKjUGlRrXDXtQIObmVYDC(int P_0)
				{
					pmYUODRjCoVCUUAxBGNJKWQmouUnA = P_0;
					JvVYbvVnEetgAHbNEhDqCKIrLmMnA = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					int num = pmYUODRjCoVCUUAxBGNJKWQmouUnA;
					if (num == -3 || num == 1)
					{
						try
						{
						}
						finally
						{
							mMLooUclcNbsIfUXaUycmARbnjFMA();
						}
					}
				}

				private bool MoveNext()
				{
					try
					{
						int num = pmYUODRjCoVCUUAxBGNJKWQmouUnA;
						PollingHelper wYvQNDQefglgvyhsRXZiwNGoHVYR = WYvQNDQefglgvyhsRXZiwNGoHVYR;
						if (num != 0)
						{
							if (num != 1)
							{
								return false;
							}
							pmYUODRjCoVCUUAxBGNJKWQmouUnA = -3;
							goto IL_00c5;
						}
						pmYUODRjCoVCUUAxBGNJKWQmouUnA = -1;
						uSfnKfbHjVGlKycUbcWtGxMpBXBXA = wYvQNDQefglgvyhsRXZiwNGoHVYR.RYrOzLdLhDMcyVDdbzlwvAkCWGA.QrSKTUzPSjlCKZGLJDqOVrJyplcf().cmeeIbUCxjHUqdNCBHHJgoMnHEVA();
						UBUIEWFXvZlzQXJHjsHaoRDgEWXM = uSfnKfbHjVGlKycUbcWtGxMpBXBXA.Count;
						fXyMcQOeYtEIaMyGXwTqpfVDgCYM = 0;
						goto IL_00f1;
						IL_00c5:
						if (HpnnnKPJWZKQMUZyRHFprauWcFmh.MoveNext())
						{
							ControllerPollingInfo current = HpnnnKPJWZKQMUZyRHFprauWcFmh.Current;
							ControllerPollingInfo xrxXEKkJUoHqfyBPKeQUHoHnmAOeb = new ControllerPollingInfo(current);
							xrxXEKkJUoHqfyBPKeQUHoHnmAOeb.haeCbWiQSPlfWqsFZDTLoULYjVYq(wYvQNDQefglgvyhsRXZiwNGoHVYR.omDgqMdNPYOabeAlYvYukkvWREGe.CgPagdlzMlCQxkbRTPOoePMzAXof);
							XrxXEKkJUoHqfyBPKeQUHoHnmAOeb = xrxXEKkJUoHqfyBPKeQUHoHnmAOeb;
							pmYUODRjCoVCUUAxBGNJKWQmouUnA = 1;
							return true;
						}
						mMLooUclcNbsIfUXaUycmARbnjFMA();
						HpnnnKPJWZKQMUZyRHFprauWcFmh = null;
						fXyMcQOeYtEIaMyGXwTqpfVDgCYM++;
						goto IL_00f1;
						IL_00f1:
						if (fXyMcQOeYtEIaMyGXwTqpfVDgCYM < UBUIEWFXvZlzQXJHjsHaoRDgEWXM)
						{
							HpnnnKPJWZKQMUZyRHFprauWcFmh = uSfnKfbHjVGlKycUbcWtGxMpBXBXA[fXyMcQOeYtEIaMyGXwTqpfVDgCYM].PollForAllAxes().GetEnumerator();
							pmYUODRjCoVCUUAxBGNJKWQmouUnA = -3;
							goto IL_00c5;
						}
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

				private void mMLooUclcNbsIfUXaUycmARbnjFMA()
				{
					pmYUODRjCoVCUUAxBGNJKWQmouUnA = -1;
					if (HpnnnKPJWZKQMUZyRHFprauWcFmh != null)
					{
						HpnnnKPJWZKQMUZyRHFprauWcFmh.Dispose();
					}
				}

				[DebuggerHidden]
				void IEnumerator.Reset()
				{
					throw new NotSupportedException();
				}

				[DebuggerHidden]
				IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
				{
					yGIXmWQbKjUGlRrXDXtQIObmVYDC yGIXmWQbKjUGlRrXDXtQIObmVYDC2;
					if (pmYUODRjCoVCUUAxBGNJKWQmouUnA == -2 && JvVYbvVnEetgAHbNEhDqCKIrLmMnA == Environment.CurrentManagedThreadId)
					{
						pmYUODRjCoVCUUAxBGNJKWQmouUnA = 0;
						yGIXmWQbKjUGlRrXDXtQIObmVYDC2 = this;
					}
					else
					{
						yGIXmWQbKjUGlRrXDXtQIObmVYDC2 = new yGIXmWQbKjUGlRrXDXtQIObmVYDC(0);
						yGIXmWQbKjUGlRrXDXtQIObmVYDC2.WYvQNDQefglgvyhsRXZiwNGoHVYR = WYvQNDQefglgvyhsRXZiwNGoHVYR;
					}
					return yGIXmWQbKjUGlRrXDXtQIObmVYDC2;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
				}
			}

			private sealed class WylMZvHrmFJNFrUGIHbKFjUxgCFD : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
			{
				private int kvTESgvhMfGLuFOYzXEASgfTOVExA;

				private ControllerPollingInfo fGqnlsbWEfncZvKSNqABEOlLiPex;

				private int hygrhvLOsJhvzddLdyVanxfcadVX;

				public PollingHelper IVERMdbmXPAQmdUHARfTQotSmSjJ;

				private IList<CustomController> mWZHEpcRIAFDvLijrhzUhTbZeXBo;

				private int SoqEnsSdPDjhhIEMgEZlJnYwTKSBA;

				private int gDhCYWHhMxsctgVdvmIbQqmJsiYpA;

				private IEnumerator<ControllerPollingInfo> LDNtsQbKKeRMfQVPismkrGUsDfQBA;

				ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
				{
					[DebuggerHidden]
					get
					{
						return fGqnlsbWEfncZvKSNqABEOlLiPex;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return fGqnlsbWEfncZvKSNqABEOlLiPex;
					}
				}

				[DebuggerHidden]
				public WylMZvHrmFJNFrUGIHbKFjUxgCFD(int P_0)
				{
					kvTESgvhMfGLuFOYzXEASgfTOVExA = P_0;
					hygrhvLOsJhvzddLdyVanxfcadVX = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					int num = kvTESgvhMfGLuFOYzXEASgfTOVExA;
					if (num == -3 || num == 1)
					{
						try
						{
						}
						finally
						{
							iSaObcEJMEIWZufhJXJMUNRcMDQe();
						}
					}
				}

				private bool MoveNext()
				{
					try
					{
						int num = kvTESgvhMfGLuFOYzXEASgfTOVExA;
						PollingHelper iVERMdbmXPAQmdUHARfTQotSmSjJ = IVERMdbmXPAQmdUHARfTQotSmSjJ;
						if (num != 0)
						{
							if (num != 1)
							{
								return false;
							}
							kvTESgvhMfGLuFOYzXEASgfTOVExA = -3;
							goto IL_00c5;
						}
						kvTESgvhMfGLuFOYzXEASgfTOVExA = -1;
						mWZHEpcRIAFDvLijrhzUhTbZeXBo = iVERMdbmXPAQmdUHARfTQotSmSjJ.RYrOzLdLhDMcyVDdbzlwvAkCWGA.QrSKTUzPSjlCKZGLJDqOVrJyplcf().cmeeIbUCxjHUqdNCBHHJgoMnHEVA();
						SoqEnsSdPDjhhIEMgEZlJnYwTKSBA = mWZHEpcRIAFDvLijrhzUhTbZeXBo.Count;
						gDhCYWHhMxsctgVdvmIbQqmJsiYpA = 0;
						goto IL_00f1;
						IL_00c5:
						if (LDNtsQbKKeRMfQVPismkrGUsDfQBA.MoveNext())
						{
							ControllerPollingInfo current = LDNtsQbKKeRMfQVPismkrGUsDfQBA.Current;
							ControllerPollingInfo controllerPollingInfo = new ControllerPollingInfo(current);
							controllerPollingInfo.haeCbWiQSPlfWqsFZDTLoULYjVYq(iVERMdbmXPAQmdUHARfTQotSmSjJ.omDgqMdNPYOabeAlYvYukkvWREGe.CgPagdlzMlCQxkbRTPOoePMzAXof);
							fGqnlsbWEfncZvKSNqABEOlLiPex = controllerPollingInfo;
							kvTESgvhMfGLuFOYzXEASgfTOVExA = 1;
							return true;
						}
						iSaObcEJMEIWZufhJXJMUNRcMDQe();
						LDNtsQbKKeRMfQVPismkrGUsDfQBA = null;
						gDhCYWHhMxsctgVdvmIbQqmJsiYpA++;
						goto IL_00f1;
						IL_00f1:
						if (gDhCYWHhMxsctgVdvmIbQqmJsiYpA < SoqEnsSdPDjhhIEMgEZlJnYwTKSBA)
						{
							LDNtsQbKKeRMfQVPismkrGUsDfQBA = mWZHEpcRIAFDvLijrhzUhTbZeXBo[gDhCYWHhMxsctgVdvmIbQqmJsiYpA].PollForAllButtons().GetEnumerator();
							kvTESgvhMfGLuFOYzXEASgfTOVExA = -3;
							goto IL_00c5;
						}
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

				private void iSaObcEJMEIWZufhJXJMUNRcMDQe()
				{
					kvTESgvhMfGLuFOYzXEASgfTOVExA = -1;
					if (LDNtsQbKKeRMfQVPismkrGUsDfQBA != null)
					{
						LDNtsQbKKeRMfQVPismkrGUsDfQBA.Dispose();
					}
				}

				[DebuggerHidden]
				void IEnumerator.Reset()
				{
					throw new NotSupportedException();
				}

				[DebuggerHidden]
				IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
				{
					WylMZvHrmFJNFrUGIHbKFjUxgCFD wylMZvHrmFJNFrUGIHbKFjUxgCFD;
					if (kvTESgvhMfGLuFOYzXEASgfTOVExA == -2 && hygrhvLOsJhvzddLdyVanxfcadVX == Environment.CurrentManagedThreadId)
					{
						kvTESgvhMfGLuFOYzXEASgfTOVExA = 0;
						wylMZvHrmFJNFrUGIHbKFjUxgCFD = this;
					}
					else
					{
						wylMZvHrmFJNFrUGIHbKFjUxgCFD = new WylMZvHrmFJNFrUGIHbKFjUxgCFD(0);
						wylMZvHrmFJNFrUGIHbKFjUxgCFD.IVERMdbmXPAQmdUHARfTQotSmSjJ = IVERMdbmXPAQmdUHARfTQotSmSjJ;
					}
					return wylMZvHrmFJNFrUGIHbKFjUxgCFD;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
				}
			}

			private sealed class RcViOjAcDWiLchRpcDeuFMJGiMECE : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
			{
				private int MhUpHHREoYcVthLDLeQEgXbFaObN;

				private ControllerPollingInfo HzAnywTlblpwNgyZLIGoSOMKXpGi;

				private int FeqjTafWsdIuQDiDhNRKNULyxxCkA;

				public PollingHelper ZAHxWGssxWybdISBdjxVWMXFzzdh;

				private IList<CustomController> qNcSYNOLbhBzUerRjvVQUTyHgPHX;

				private int WhbPkdGkAOUJOtBoIbkQqaNfqlzI;

				private int gxXGIcFvoippXpjsbQvOLrNQCIOiA;

				private IEnumerator<ControllerPollingInfo> VBrdsjCywrEGIItYvjhZFJuaElkHB;

				ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
				{
					[DebuggerHidden]
					get
					{
						return HzAnywTlblpwNgyZLIGoSOMKXpGi;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return HzAnywTlblpwNgyZLIGoSOMKXpGi;
					}
				}

				[DebuggerHidden]
				public RcViOjAcDWiLchRpcDeuFMJGiMECE(int P_0)
				{
					MhUpHHREoYcVthLDLeQEgXbFaObN = P_0;
					FeqjTafWsdIuQDiDhNRKNULyxxCkA = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					int mhUpHHREoYcVthLDLeQEgXbFaObN = MhUpHHREoYcVthLDLeQEgXbFaObN;
					if (mhUpHHREoYcVthLDLeQEgXbFaObN == -3 || mhUpHHREoYcVthLDLeQEgXbFaObN == 1)
					{
						try
						{
						}
						finally
						{
							AXsSedlhdJkkynRcjXpskHpUNTce();
						}
					}
				}

				private bool MoveNext()
				{
					try
					{
						int mhUpHHREoYcVthLDLeQEgXbFaObN = MhUpHHREoYcVthLDLeQEgXbFaObN;
						PollingHelper zAHxWGssxWybdISBdjxVWMXFzzdh = ZAHxWGssxWybdISBdjxVWMXFzzdh;
						if (mhUpHHREoYcVthLDLeQEgXbFaObN != 0)
						{
							if (mhUpHHREoYcVthLDLeQEgXbFaObN != 1)
							{
								return false;
							}
							MhUpHHREoYcVthLDLeQEgXbFaObN = -3;
							goto IL_00c5;
						}
						MhUpHHREoYcVthLDLeQEgXbFaObN = -1;
						qNcSYNOLbhBzUerRjvVQUTyHgPHX = zAHxWGssxWybdISBdjxVWMXFzzdh.RYrOzLdLhDMcyVDdbzlwvAkCWGA.QrSKTUzPSjlCKZGLJDqOVrJyplcf().cmeeIbUCxjHUqdNCBHHJgoMnHEVA();
						WhbPkdGkAOUJOtBoIbkQqaNfqlzI = qNcSYNOLbhBzUerRjvVQUTyHgPHX.Count;
						gxXGIcFvoippXpjsbQvOLrNQCIOiA = 0;
						goto IL_00f1;
						IL_00c5:
						if (VBrdsjCywrEGIItYvjhZFJuaElkHB.MoveNext())
						{
							ControllerPollingInfo current = VBrdsjCywrEGIItYvjhZFJuaElkHB.Current;
							ControllerPollingInfo hzAnywTlblpwNgyZLIGoSOMKXpGi = new ControllerPollingInfo(current);
							hzAnywTlblpwNgyZLIGoSOMKXpGi.haeCbWiQSPlfWqsFZDTLoULYjVYq(zAHxWGssxWybdISBdjxVWMXFzzdh.omDgqMdNPYOabeAlYvYukkvWREGe.CgPagdlzMlCQxkbRTPOoePMzAXof);
							HzAnywTlblpwNgyZLIGoSOMKXpGi = hzAnywTlblpwNgyZLIGoSOMKXpGi;
							MhUpHHREoYcVthLDLeQEgXbFaObN = 1;
							return true;
						}
						AXsSedlhdJkkynRcjXpskHpUNTce();
						VBrdsjCywrEGIItYvjhZFJuaElkHB = null;
						gxXGIcFvoippXpjsbQvOLrNQCIOiA++;
						goto IL_00f1;
						IL_00f1:
						if (gxXGIcFvoippXpjsbQvOLrNQCIOiA < WhbPkdGkAOUJOtBoIbkQqaNfqlzI)
						{
							VBrdsjCywrEGIItYvjhZFJuaElkHB = qNcSYNOLbhBzUerRjvVQUTyHgPHX[gxXGIcFvoippXpjsbQvOLrNQCIOiA].PollForAllButtonsDown().GetEnumerator();
							MhUpHHREoYcVthLDLeQEgXbFaObN = -3;
							goto IL_00c5;
						}
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

				private void AXsSedlhdJkkynRcjXpskHpUNTce()
				{
					MhUpHHREoYcVthLDLeQEgXbFaObN = -1;
					if (VBrdsjCywrEGIItYvjhZFJuaElkHB != null)
					{
						VBrdsjCywrEGIItYvjhZFJuaElkHB.Dispose();
					}
				}

				[DebuggerHidden]
				void IEnumerator.Reset()
				{
					throw new NotSupportedException();
				}

				[DebuggerHidden]
				IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
				{
					RcViOjAcDWiLchRpcDeuFMJGiMECE rcViOjAcDWiLchRpcDeuFMJGiMECE;
					if (MhUpHHREoYcVthLDLeQEgXbFaObN == -2 && FeqjTafWsdIuQDiDhNRKNULyxxCkA == Environment.CurrentManagedThreadId)
					{
						MhUpHHREoYcVthLDLeQEgXbFaObN = 0;
						rcViOjAcDWiLchRpcDeuFMJGiMECE = this;
					}
					else
					{
						rcViOjAcDWiLchRpcDeuFMJGiMECE = new RcViOjAcDWiLchRpcDeuFMJGiMECE(0);
						rcViOjAcDWiLchRpcDeuFMJGiMECE.ZAHxWGssxWybdISBdjxVWMXFzzdh = ZAHxWGssxWybdISBdjxVWMXFzzdh;
					}
					return rcViOjAcDWiLchRpcDeuFMJGiMECE;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
				}
			}

			private sealed class yhpdoFeDqLdjvGMKqvvhxAsYMQxN : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
			{
				private int lbUokSUnJEPxyEpBbkvKEjduQCTF;

				private ControllerPollingInfo QaBaxxKaAxXKTmLFVHhGbWCBdftH;

				private int wRxMboThOrBBMgTkHcaPbHSmJpgg;

				public PollingHelper IYhgcKvkIGBZWrGvZionSwIMzKqF;

				private IList<CustomController> DmvAbIIXhgtefqkhPOuRRoYXjntEb;

				private int zfAZiGRxbUqFyhaozSVGjenFOllo;

				private int wFGZRLYRtzTKIrxXLfNGdzLdEsIq;

				private IEnumerator<ControllerPollingInfo> bobiUfwNeauPGFXwDktMzBLTnzgB;

				ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
				{
					[DebuggerHidden]
					get
					{
						return QaBaxxKaAxXKTmLFVHhGbWCBdftH;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return QaBaxxKaAxXKTmLFVHhGbWCBdftH;
					}
				}

				[DebuggerHidden]
				public yhpdoFeDqLdjvGMKqvvhxAsYMQxN(int P_0)
				{
					lbUokSUnJEPxyEpBbkvKEjduQCTF = P_0;
					wRxMboThOrBBMgTkHcaPbHSmJpgg = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					int num = lbUokSUnJEPxyEpBbkvKEjduQCTF;
					if (num == -3 || num == 1)
					{
						try
						{
						}
						finally
						{
							yeLvqMDpxjfWfravFfoCCiQDtABZ();
						}
					}
				}

				private bool MoveNext()
				{
					try
					{
						int num = lbUokSUnJEPxyEpBbkvKEjduQCTF;
						PollingHelper iYhgcKvkIGBZWrGvZionSwIMzKqF = IYhgcKvkIGBZWrGvZionSwIMzKqF;
						if (num != 0)
						{
							if (num != 1)
							{
								return false;
							}
							lbUokSUnJEPxyEpBbkvKEjduQCTF = -3;
							goto IL_00c5;
						}
						lbUokSUnJEPxyEpBbkvKEjduQCTF = -1;
						DmvAbIIXhgtefqkhPOuRRoYXjntEb = iYhgcKvkIGBZWrGvZionSwIMzKqF.RYrOzLdLhDMcyVDdbzlwvAkCWGA.QrSKTUzPSjlCKZGLJDqOVrJyplcf().cmeeIbUCxjHUqdNCBHHJgoMnHEVA();
						zfAZiGRxbUqFyhaozSVGjenFOllo = DmvAbIIXhgtefqkhPOuRRoYXjntEb.Count;
						wFGZRLYRtzTKIrxXLfNGdzLdEsIq = 0;
						goto IL_00f1;
						IL_00c5:
						if (bobiUfwNeauPGFXwDktMzBLTnzgB.MoveNext())
						{
							ControllerPollingInfo current = bobiUfwNeauPGFXwDktMzBLTnzgB.Current;
							ControllerPollingInfo qaBaxxKaAxXKTmLFVHhGbWCBdftH = new ControllerPollingInfo(current);
							qaBaxxKaAxXKTmLFVHhGbWCBdftH.haeCbWiQSPlfWqsFZDTLoULYjVYq(iYhgcKvkIGBZWrGvZionSwIMzKqF.omDgqMdNPYOabeAlYvYukkvWREGe.CgPagdlzMlCQxkbRTPOoePMzAXof);
							QaBaxxKaAxXKTmLFVHhGbWCBdftH = qaBaxxKaAxXKTmLFVHhGbWCBdftH;
							lbUokSUnJEPxyEpBbkvKEjduQCTF = 1;
							return true;
						}
						yeLvqMDpxjfWfravFfoCCiQDtABZ();
						bobiUfwNeauPGFXwDktMzBLTnzgB = null;
						wFGZRLYRtzTKIrxXLfNGdzLdEsIq++;
						goto IL_00f1;
						IL_00f1:
						if (wFGZRLYRtzTKIrxXLfNGdzLdEsIq < zfAZiGRxbUqFyhaozSVGjenFOllo)
						{
							bobiUfwNeauPGFXwDktMzBLTnzgB = DmvAbIIXhgtefqkhPOuRRoYXjntEb[wFGZRLYRtzTKIrxXLfNGdzLdEsIq].PollForAllElements().GetEnumerator();
							lbUokSUnJEPxyEpBbkvKEjduQCTF = -3;
							goto IL_00c5;
						}
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

				private void yeLvqMDpxjfWfravFfoCCiQDtABZ()
				{
					lbUokSUnJEPxyEpBbkvKEjduQCTF = -1;
					if (bobiUfwNeauPGFXwDktMzBLTnzgB != null)
					{
						bobiUfwNeauPGFXwDktMzBLTnzgB.Dispose();
					}
				}

				[DebuggerHidden]
				void IEnumerator.Reset()
				{
					throw new NotSupportedException();
				}

				[DebuggerHidden]
				IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
				{
					yhpdoFeDqLdjvGMKqvvhxAsYMQxN yhpdoFeDqLdjvGMKqvvhxAsYMQxN2;
					if (lbUokSUnJEPxyEpBbkvKEjduQCTF == -2 && wRxMboThOrBBMgTkHcaPbHSmJpgg == Environment.CurrentManagedThreadId)
					{
						lbUokSUnJEPxyEpBbkvKEjduQCTF = 0;
						yhpdoFeDqLdjvGMKqvvhxAsYMQxN2 = this;
					}
					else
					{
						yhpdoFeDqLdjvGMKqvvhxAsYMQxN2 = new yhpdoFeDqLdjvGMKqvvhxAsYMQxN(0);
						yhpdoFeDqLdjvGMKqvvhxAsYMQxN2.IYhgcKvkIGBZWrGvZionSwIMzKqF = IYhgcKvkIGBZWrGvZionSwIMzKqF;
					}
					return yhpdoFeDqLdjvGMKqvvhxAsYMQxN2;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
				}
			}

			private sealed class xjBCOLFODPCAOaRBciDDgSPQQZOBA : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
			{
				private int fQUgUfHcvCKrrCgaJQJabvCswPvE;

				private ControllerPollingInfo LGUBZpsWuaQIaHdJHXoVaqKnNMFf;

				private int ooKiwMxROnsiqEKCaFyEKtyxUuOF;

				public PollingHelper GMlVuaqaYaqWdtiQFHvOcVajuyzA;

				private IList<CustomController> EUjpNXknCzaqMJoThLfJpGNULjykA;

				private int mecjtrbLiVAtZSaodPvjoqymCbyAA;

				private int TGnixWYokZleWvmrcvBXRgKRkUiF;

				private IEnumerator<ControllerPollingInfo> yrQgtbBqseJBLIbDoiaVoJoIVUfP;

				ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
				{
					[DebuggerHidden]
					get
					{
						return LGUBZpsWuaQIaHdJHXoVaqKnNMFf;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return LGUBZpsWuaQIaHdJHXoVaqKnNMFf;
					}
				}

				[DebuggerHidden]
				public xjBCOLFODPCAOaRBciDDgSPQQZOBA(int P_0)
				{
					fQUgUfHcvCKrrCgaJQJabvCswPvE = P_0;
					ooKiwMxROnsiqEKCaFyEKtyxUuOF = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					int num = fQUgUfHcvCKrrCgaJQJabvCswPvE;
					if (num == -3 || num == 1)
					{
						try
						{
						}
						finally
						{
							ogVFlRKruhAUvLZeiJOfEUtyPqjJA();
						}
					}
				}

				private bool MoveNext()
				{
					try
					{
						int num = fQUgUfHcvCKrrCgaJQJabvCswPvE;
						PollingHelper gMlVuaqaYaqWdtiQFHvOcVajuyzA = GMlVuaqaYaqWdtiQFHvOcVajuyzA;
						if (num != 0)
						{
							if (num != 1)
							{
								return false;
							}
							fQUgUfHcvCKrrCgaJQJabvCswPvE = -3;
							goto IL_00c5;
						}
						fQUgUfHcvCKrrCgaJQJabvCswPvE = -1;
						EUjpNXknCzaqMJoThLfJpGNULjykA = gMlVuaqaYaqWdtiQFHvOcVajuyzA.RYrOzLdLhDMcyVDdbzlwvAkCWGA.QrSKTUzPSjlCKZGLJDqOVrJyplcf().cmeeIbUCxjHUqdNCBHHJgoMnHEVA();
						mecjtrbLiVAtZSaodPvjoqymCbyAA = EUjpNXknCzaqMJoThLfJpGNULjykA.Count;
						TGnixWYokZleWvmrcvBXRgKRkUiF = 0;
						goto IL_00f1;
						IL_00c5:
						if (yrQgtbBqseJBLIbDoiaVoJoIVUfP.MoveNext())
						{
							ControllerPollingInfo current = yrQgtbBqseJBLIbDoiaVoJoIVUfP.Current;
							ControllerPollingInfo lGUBZpsWuaQIaHdJHXoVaqKnNMFf = new ControllerPollingInfo(current);
							lGUBZpsWuaQIaHdJHXoVaqKnNMFf.haeCbWiQSPlfWqsFZDTLoULYjVYq(gMlVuaqaYaqWdtiQFHvOcVajuyzA.omDgqMdNPYOabeAlYvYukkvWREGe.CgPagdlzMlCQxkbRTPOoePMzAXof);
							LGUBZpsWuaQIaHdJHXoVaqKnNMFf = lGUBZpsWuaQIaHdJHXoVaqKnNMFf;
							fQUgUfHcvCKrrCgaJQJabvCswPvE = 1;
							return true;
						}
						ogVFlRKruhAUvLZeiJOfEUtyPqjJA();
						yrQgtbBqseJBLIbDoiaVoJoIVUfP = null;
						TGnixWYokZleWvmrcvBXRgKRkUiF++;
						goto IL_00f1;
						IL_00f1:
						if (TGnixWYokZleWvmrcvBXRgKRkUiF < mecjtrbLiVAtZSaodPvjoqymCbyAA)
						{
							yrQgtbBqseJBLIbDoiaVoJoIVUfP = EUjpNXknCzaqMJoThLfJpGNULjykA[TGnixWYokZleWvmrcvBXRgKRkUiF].PollForAllElementsDown().GetEnumerator();
							fQUgUfHcvCKrrCgaJQJabvCswPvE = -3;
							goto IL_00c5;
						}
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

				private void ogVFlRKruhAUvLZeiJOfEUtyPqjJA()
				{
					fQUgUfHcvCKrrCgaJQJabvCswPvE = -1;
					if (yrQgtbBqseJBLIbDoiaVoJoIVUfP != null)
					{
						yrQgtbBqseJBLIbDoiaVoJoIVUfP.Dispose();
					}
				}

				[DebuggerHidden]
				void IEnumerator.Reset()
				{
					throw new NotSupportedException();
				}

				[DebuggerHidden]
				IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
				{
					xjBCOLFODPCAOaRBciDDgSPQQZOBA xjBCOLFODPCAOaRBciDDgSPQQZOBA2;
					if (fQUgUfHcvCKrrCgaJQJabvCswPvE == -2 && ooKiwMxROnsiqEKCaFyEKtyxUuOF == Environment.CurrentManagedThreadId)
					{
						fQUgUfHcvCKrrCgaJQJabvCswPvE = 0;
						xjBCOLFODPCAOaRBciDDgSPQQZOBA2 = this;
					}
					else
					{
						xjBCOLFODPCAOaRBciDDgSPQQZOBA2 = new xjBCOLFODPCAOaRBciDDgSPQQZOBA(0);
						xjBCOLFODPCAOaRBciDDgSPQQZOBA2.GMlVuaqaYaqWdtiQFHvOcVajuyzA = GMlVuaqaYaqWdtiQFHvOcVajuyzA;
					}
					return xjBCOLFODPCAOaRBciDDgSPQQZOBA2;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
				}
			}

			private sealed class jmzwnWnzmSTfYaXQCtJFtCCnFqlD : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
			{
				private int zUwqesUsDHOYwONMzgEhPlvwEtTU;

				private ControllerPollingInfo UcipYKYqsiaBOOnHFGOACaAhRiYAA;

				private int SHJzBTgVMLPbmzgfJhYcdxjbpmKTA;

				public PollingHelper WXuxeUiDCJXRvXYiQgfjvJsYhQAe;

				private IList<Joystick> jAScdsGqvJTkHRJknLaWsQMQlweMA;

				private int lZxBFDXRRNbzZWNIPByugWnBTHiH;

				private int MoDJztJkGOevoAhVggiEDwYTdNGib;

				private IEnumerator<ControllerPollingInfo> trtnlclJKftjyileNGvvasiCXvnR;

				ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
				{
					[DebuggerHidden]
					get
					{
						return UcipYKYqsiaBOOnHFGOACaAhRiYAA;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return UcipYKYqsiaBOOnHFGOACaAhRiYAA;
					}
				}

				[DebuggerHidden]
				public jmzwnWnzmSTfYaXQCtJFtCCnFqlD(int P_0)
				{
					zUwqesUsDHOYwONMzgEhPlvwEtTU = P_0;
					SHJzBTgVMLPbmzgfJhYcdxjbpmKTA = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					int num = zUwqesUsDHOYwONMzgEhPlvwEtTU;
					if (num == -3 || num == 1)
					{
						try
						{
						}
						finally
						{
							wxDNCrxgLToFZarrxRULBfCXmibU();
						}
					}
				}

				private bool MoveNext()
				{
					try
					{
						int num = zUwqesUsDHOYwONMzgEhPlvwEtTU;
						PollingHelper wXuxeUiDCJXRvXYiQgfjvJsYhQAe = WXuxeUiDCJXRvXYiQgfjvJsYhQAe;
						if (num != 0)
						{
							if (num != 1)
							{
								return false;
							}
							zUwqesUsDHOYwONMzgEhPlvwEtTU = -3;
							goto IL_00c5;
						}
						zUwqesUsDHOYwONMzgEhPlvwEtTU = -1;
						jAScdsGqvJTkHRJknLaWsQMQlweMA = wXuxeUiDCJXRvXYiQgfjvJsYhQAe.RYrOzLdLhDMcyVDdbzlwvAkCWGA.UZODjZPyOKvXiogzadHvXQZXjpbh().cmeeIbUCxjHUqdNCBHHJgoMnHEVA();
						lZxBFDXRRNbzZWNIPByugWnBTHiH = jAScdsGqvJTkHRJknLaWsQMQlweMA.Count;
						MoDJztJkGOevoAhVggiEDwYTdNGib = 0;
						goto IL_00f1;
						IL_00c5:
						if (trtnlclJKftjyileNGvvasiCXvnR.MoveNext())
						{
							ControllerPollingInfo current = trtnlclJKftjyileNGvvasiCXvnR.Current;
							ControllerPollingInfo ucipYKYqsiaBOOnHFGOACaAhRiYAA = new ControllerPollingInfo(current);
							ucipYKYqsiaBOOnHFGOACaAhRiYAA.haeCbWiQSPlfWqsFZDTLoULYjVYq(wXuxeUiDCJXRvXYiQgfjvJsYhQAe.omDgqMdNPYOabeAlYvYukkvWREGe.CgPagdlzMlCQxkbRTPOoePMzAXof);
							UcipYKYqsiaBOOnHFGOACaAhRiYAA = ucipYKYqsiaBOOnHFGOACaAhRiYAA;
							zUwqesUsDHOYwONMzgEhPlvwEtTU = 1;
							return true;
						}
						wxDNCrxgLToFZarrxRULBfCXmibU();
						trtnlclJKftjyileNGvvasiCXvnR = null;
						MoDJztJkGOevoAhVggiEDwYTdNGib++;
						goto IL_00f1;
						IL_00f1:
						if (MoDJztJkGOevoAhVggiEDwYTdNGib < lZxBFDXRRNbzZWNIPByugWnBTHiH)
						{
							trtnlclJKftjyileNGvvasiCXvnR = jAScdsGqvJTkHRJknLaWsQMQlweMA[MoDJztJkGOevoAhVggiEDwYTdNGib].PollForAllAxes().GetEnumerator();
							zUwqesUsDHOYwONMzgEhPlvwEtTU = -3;
							goto IL_00c5;
						}
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

				private void wxDNCrxgLToFZarrxRULBfCXmibU()
				{
					zUwqesUsDHOYwONMzgEhPlvwEtTU = -1;
					if (trtnlclJKftjyileNGvvasiCXvnR != null)
					{
						trtnlclJKftjyileNGvvasiCXvnR.Dispose();
					}
				}

				[DebuggerHidden]
				void IEnumerator.Reset()
				{
					throw new NotSupportedException();
				}

				[DebuggerHidden]
				IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
				{
					jmzwnWnzmSTfYaXQCtJFtCCnFqlD jmzwnWnzmSTfYaXQCtJFtCCnFqlD2;
					if (zUwqesUsDHOYwONMzgEhPlvwEtTU == -2 && SHJzBTgVMLPbmzgfJhYcdxjbpmKTA == Environment.CurrentManagedThreadId)
					{
						zUwqesUsDHOYwONMzgEhPlvwEtTU = 0;
						jmzwnWnzmSTfYaXQCtJFtCCnFqlD2 = this;
					}
					else
					{
						jmzwnWnzmSTfYaXQCtJFtCCnFqlD2 = new jmzwnWnzmSTfYaXQCtJFtCCnFqlD(0);
						jmzwnWnzmSTfYaXQCtJFtCCnFqlD2.WXuxeUiDCJXRvXYiQgfjvJsYhQAe = WXuxeUiDCJXRvXYiQgfjvJsYhQAe;
					}
					return jmzwnWnzmSTfYaXQCtJFtCCnFqlD2;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
				}
			}

			private sealed class BnRpMmDunfpxeaxtAZSbtulmGNMm : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
			{
				private int PjBXIgkORvAjjWZSSjuAzwOkKwOT;

				private ControllerPollingInfo AsGgnpyIWLANCCathjdUaOhxcezk;

				private int FvtljXEuIkClVUIENbqgTuSbjTLw;

				public PollingHelper iLSVBQKGEKWUBNPQXzcsdJLAPpfS;

				private IList<Joystick> uBDkOuPSCeAQrlvlzIhWPxCiGKDo;

				private int PzBabtLPWwaCAvpfgnoGgVWMkqFY;

				private int TISyOMWbQQAGnYHKCnAITjXqgTsv;

				private IEnumerator<ControllerPollingInfo> XnUGtliNPfnVfGnthpohFhIqfsnw;

				ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
				{
					[DebuggerHidden]
					get
					{
						return AsGgnpyIWLANCCathjdUaOhxcezk;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return AsGgnpyIWLANCCathjdUaOhxcezk;
					}
				}

				[DebuggerHidden]
				public BnRpMmDunfpxeaxtAZSbtulmGNMm(int P_0)
				{
					PjBXIgkORvAjjWZSSjuAzwOkKwOT = P_0;
					FvtljXEuIkClVUIENbqgTuSbjTLw = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					int pjBXIgkORvAjjWZSSjuAzwOkKwOT = PjBXIgkORvAjjWZSSjuAzwOkKwOT;
					if (pjBXIgkORvAjjWZSSjuAzwOkKwOT == -3 || pjBXIgkORvAjjWZSSjuAzwOkKwOT == 1)
					{
						try
						{
						}
						finally
						{
							oXxZiTDElJXfOHrsVOGjeMVeZtAC();
						}
					}
				}

				private bool MoveNext()
				{
					try
					{
						int pjBXIgkORvAjjWZSSjuAzwOkKwOT = PjBXIgkORvAjjWZSSjuAzwOkKwOT;
						PollingHelper pollingHelper = iLSVBQKGEKWUBNPQXzcsdJLAPpfS;
						if (pjBXIgkORvAjjWZSSjuAzwOkKwOT != 0)
						{
							if (pjBXIgkORvAjjWZSSjuAzwOkKwOT != 1)
							{
								return false;
							}
							PjBXIgkORvAjjWZSSjuAzwOkKwOT = -3;
							goto IL_00c5;
						}
						PjBXIgkORvAjjWZSSjuAzwOkKwOT = -1;
						uBDkOuPSCeAQrlvlzIhWPxCiGKDo = pollingHelper.RYrOzLdLhDMcyVDdbzlwvAkCWGA.UZODjZPyOKvXiogzadHvXQZXjpbh().cmeeIbUCxjHUqdNCBHHJgoMnHEVA();
						PzBabtLPWwaCAvpfgnoGgVWMkqFY = uBDkOuPSCeAQrlvlzIhWPxCiGKDo.Count;
						TISyOMWbQQAGnYHKCnAITjXqgTsv = 0;
						goto IL_00f1;
						IL_00c5:
						if (XnUGtliNPfnVfGnthpohFhIqfsnw.MoveNext())
						{
							ControllerPollingInfo current = XnUGtliNPfnVfGnthpohFhIqfsnw.Current;
							ControllerPollingInfo asGgnpyIWLANCCathjdUaOhxcezk = new ControllerPollingInfo(current);
							asGgnpyIWLANCCathjdUaOhxcezk.haeCbWiQSPlfWqsFZDTLoULYjVYq(pollingHelper.omDgqMdNPYOabeAlYvYukkvWREGe.CgPagdlzMlCQxkbRTPOoePMzAXof);
							AsGgnpyIWLANCCathjdUaOhxcezk = asGgnpyIWLANCCathjdUaOhxcezk;
							PjBXIgkORvAjjWZSSjuAzwOkKwOT = 1;
							return true;
						}
						oXxZiTDElJXfOHrsVOGjeMVeZtAC();
						XnUGtliNPfnVfGnthpohFhIqfsnw = null;
						TISyOMWbQQAGnYHKCnAITjXqgTsv++;
						goto IL_00f1;
						IL_00f1:
						if (TISyOMWbQQAGnYHKCnAITjXqgTsv < PzBabtLPWwaCAvpfgnoGgVWMkqFY)
						{
							XnUGtliNPfnVfGnthpohFhIqfsnw = uBDkOuPSCeAQrlvlzIhWPxCiGKDo[TISyOMWbQQAGnYHKCnAITjXqgTsv].PollForAllButtons().GetEnumerator();
							PjBXIgkORvAjjWZSSjuAzwOkKwOT = -3;
							goto IL_00c5;
						}
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

				private void oXxZiTDElJXfOHrsVOGjeMVeZtAC()
				{
					PjBXIgkORvAjjWZSSjuAzwOkKwOT = -1;
					if (XnUGtliNPfnVfGnthpohFhIqfsnw != null)
					{
						XnUGtliNPfnVfGnthpohFhIqfsnw.Dispose();
					}
				}

				[DebuggerHidden]
				void IEnumerator.Reset()
				{
					throw new NotSupportedException();
				}

				[DebuggerHidden]
				IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
				{
					BnRpMmDunfpxeaxtAZSbtulmGNMm bnRpMmDunfpxeaxtAZSbtulmGNMm;
					if (PjBXIgkORvAjjWZSSjuAzwOkKwOT == -2 && FvtljXEuIkClVUIENbqgTuSbjTLw == Environment.CurrentManagedThreadId)
					{
						PjBXIgkORvAjjWZSSjuAzwOkKwOT = 0;
						bnRpMmDunfpxeaxtAZSbtulmGNMm = this;
					}
					else
					{
						bnRpMmDunfpxeaxtAZSbtulmGNMm = new BnRpMmDunfpxeaxtAZSbtulmGNMm(0);
						bnRpMmDunfpxeaxtAZSbtulmGNMm.iLSVBQKGEKWUBNPQXzcsdJLAPpfS = iLSVBQKGEKWUBNPQXzcsdJLAPpfS;
					}
					return bnRpMmDunfpxeaxtAZSbtulmGNMm;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
				}
			}

			private sealed class aCJfJaECpytQREmEvZwAvnWALOLd : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
			{
				private int QwavSyFzuXxzZtKYuIfsIWtWlzkA;

				private ControllerPollingInfo lTBFWHAGzdBQERGfMicvHdZJTQyNA;

				private int mMufzUDujLIwOjwkOCFFcNCuJfen;

				public PollingHelper qMMCZlFhAtLvmJLMuIMQkSsqvDepA;

				private IList<Joystick> CqJctpjpQOjYoBJsnpGixZxvYCB;

				private int RYOoKURYNhMxflCxeztyPfgYKZaS;

				private int izcEkZkJYNvSgliWdaHvdvwxBeUEA;

				private IEnumerator<ControllerPollingInfo> NLCBHKoyWZavtQyfAJIMkbBUnASG;

				ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
				{
					[DebuggerHidden]
					get
					{
						return lTBFWHAGzdBQERGfMicvHdZJTQyNA;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return lTBFWHAGzdBQERGfMicvHdZJTQyNA;
					}
				}

				[DebuggerHidden]
				public aCJfJaECpytQREmEvZwAvnWALOLd(int P_0)
				{
					QwavSyFzuXxzZtKYuIfsIWtWlzkA = P_0;
					mMufzUDujLIwOjwkOCFFcNCuJfen = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					int qwavSyFzuXxzZtKYuIfsIWtWlzkA = QwavSyFzuXxzZtKYuIfsIWtWlzkA;
					if (qwavSyFzuXxzZtKYuIfsIWtWlzkA == -3 || qwavSyFzuXxzZtKYuIfsIWtWlzkA == 1)
					{
						try
						{
						}
						finally
						{
							AzrmVWTkJVshHAnCXMMgcrQSamGL();
						}
					}
				}

				private bool MoveNext()
				{
					try
					{
						int qwavSyFzuXxzZtKYuIfsIWtWlzkA = QwavSyFzuXxzZtKYuIfsIWtWlzkA;
						PollingHelper pollingHelper = qMMCZlFhAtLvmJLMuIMQkSsqvDepA;
						if (qwavSyFzuXxzZtKYuIfsIWtWlzkA != 0)
						{
							if (qwavSyFzuXxzZtKYuIfsIWtWlzkA != 1)
							{
								return false;
							}
							QwavSyFzuXxzZtKYuIfsIWtWlzkA = -3;
							goto IL_00c5;
						}
						QwavSyFzuXxzZtKYuIfsIWtWlzkA = -1;
						CqJctpjpQOjYoBJsnpGixZxvYCB = pollingHelper.RYrOzLdLhDMcyVDdbzlwvAkCWGA.UZODjZPyOKvXiogzadHvXQZXjpbh().cmeeIbUCxjHUqdNCBHHJgoMnHEVA();
						RYOoKURYNhMxflCxeztyPfgYKZaS = CqJctpjpQOjYoBJsnpGixZxvYCB.Count;
						izcEkZkJYNvSgliWdaHvdvwxBeUEA = 0;
						goto IL_00f1;
						IL_00c5:
						if (NLCBHKoyWZavtQyfAJIMkbBUnASG.MoveNext())
						{
							ControllerPollingInfo current = NLCBHKoyWZavtQyfAJIMkbBUnASG.Current;
							ControllerPollingInfo controllerPollingInfo = new ControllerPollingInfo(current);
							controllerPollingInfo.haeCbWiQSPlfWqsFZDTLoULYjVYq(pollingHelper.omDgqMdNPYOabeAlYvYukkvWREGe.CgPagdlzMlCQxkbRTPOoePMzAXof);
							lTBFWHAGzdBQERGfMicvHdZJTQyNA = controllerPollingInfo;
							QwavSyFzuXxzZtKYuIfsIWtWlzkA = 1;
							return true;
						}
						AzrmVWTkJVshHAnCXMMgcrQSamGL();
						NLCBHKoyWZavtQyfAJIMkbBUnASG = null;
						izcEkZkJYNvSgliWdaHvdvwxBeUEA++;
						goto IL_00f1;
						IL_00f1:
						if (izcEkZkJYNvSgliWdaHvdvwxBeUEA < RYOoKURYNhMxflCxeztyPfgYKZaS)
						{
							NLCBHKoyWZavtQyfAJIMkbBUnASG = CqJctpjpQOjYoBJsnpGixZxvYCB[izcEkZkJYNvSgliWdaHvdvwxBeUEA].PollForAllButtonsDown().GetEnumerator();
							QwavSyFzuXxzZtKYuIfsIWtWlzkA = -3;
							goto IL_00c5;
						}
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

				private void AzrmVWTkJVshHAnCXMMgcrQSamGL()
				{
					QwavSyFzuXxzZtKYuIfsIWtWlzkA = -1;
					if (NLCBHKoyWZavtQyfAJIMkbBUnASG != null)
					{
						NLCBHKoyWZavtQyfAJIMkbBUnASG.Dispose();
					}
				}

				[DebuggerHidden]
				void IEnumerator.Reset()
				{
					throw new NotSupportedException();
				}

				[DebuggerHidden]
				IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
				{
					aCJfJaECpytQREmEvZwAvnWALOLd aCJfJaECpytQREmEvZwAvnWALOLd2;
					if (QwavSyFzuXxzZtKYuIfsIWtWlzkA == -2 && mMufzUDujLIwOjwkOCFFcNCuJfen == Environment.CurrentManagedThreadId)
					{
						QwavSyFzuXxzZtKYuIfsIWtWlzkA = 0;
						aCJfJaECpytQREmEvZwAvnWALOLd2 = this;
					}
					else
					{
						aCJfJaECpytQREmEvZwAvnWALOLd2 = new aCJfJaECpytQREmEvZwAvnWALOLd(0);
						aCJfJaECpytQREmEvZwAvnWALOLd2.qMMCZlFhAtLvmJLMuIMQkSsqvDepA = qMMCZlFhAtLvmJLMuIMQkSsqvDepA;
					}
					return aCJfJaECpytQREmEvZwAvnWALOLd2;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
				}
			}

			private sealed class YAGdHiAkmvlFJUzdVBbAmQFfHSitA : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
			{
				private int ZucFVCFrPDqmOdhkysiBNXuccAoTA;

				private ControllerPollingInfo OKpDoCLstlEwMeAwbjqmtvbvaodrA;

				private int ZRygiNWdZwRewlXEswgQwiNrTMue;

				public PollingHelper UkgbjqDyLCUpcsTVxLobGeNDhlQPB;

				private IList<Joystick> DZSELtshUkgRMsAYqcbgEQCcuqsd;

				private int jbBvSAvQjJWznHwNxMZbHXVfPWBp;

				private int wToxAhRfdFtrWgSoQuELqZLYJvYp;

				private IEnumerator<ControllerPollingInfo> kReMpQKsdnklzjzUcliIemptZFKy;

				ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
				{
					[DebuggerHidden]
					get
					{
						return OKpDoCLstlEwMeAwbjqmtvbvaodrA;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return OKpDoCLstlEwMeAwbjqmtvbvaodrA;
					}
				}

				[DebuggerHidden]
				public YAGdHiAkmvlFJUzdVBbAmQFfHSitA(int P_0)
				{
					ZucFVCFrPDqmOdhkysiBNXuccAoTA = P_0;
					ZRygiNWdZwRewlXEswgQwiNrTMue = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					int zucFVCFrPDqmOdhkysiBNXuccAoTA = ZucFVCFrPDqmOdhkysiBNXuccAoTA;
					if (zucFVCFrPDqmOdhkysiBNXuccAoTA == -3 || zucFVCFrPDqmOdhkysiBNXuccAoTA == 1)
					{
						try
						{
						}
						finally
						{
							PvCwrZbBLAACVCqwONtsAsIcZOHPA();
						}
					}
				}

				private bool MoveNext()
				{
					try
					{
						int zucFVCFrPDqmOdhkysiBNXuccAoTA = ZucFVCFrPDqmOdhkysiBNXuccAoTA;
						PollingHelper ukgbjqDyLCUpcsTVxLobGeNDhlQPB = UkgbjqDyLCUpcsTVxLobGeNDhlQPB;
						if (zucFVCFrPDqmOdhkysiBNXuccAoTA != 0)
						{
							if (zucFVCFrPDqmOdhkysiBNXuccAoTA != 1)
							{
								return false;
							}
							ZucFVCFrPDqmOdhkysiBNXuccAoTA = -3;
							goto IL_00c5;
						}
						ZucFVCFrPDqmOdhkysiBNXuccAoTA = -1;
						DZSELtshUkgRMsAYqcbgEQCcuqsd = ukgbjqDyLCUpcsTVxLobGeNDhlQPB.RYrOzLdLhDMcyVDdbzlwvAkCWGA.UZODjZPyOKvXiogzadHvXQZXjpbh().cmeeIbUCxjHUqdNCBHHJgoMnHEVA();
						jbBvSAvQjJWznHwNxMZbHXVfPWBp = DZSELtshUkgRMsAYqcbgEQCcuqsd.Count;
						wToxAhRfdFtrWgSoQuELqZLYJvYp = 0;
						goto IL_00f1;
						IL_00c5:
						if (kReMpQKsdnklzjzUcliIemptZFKy.MoveNext())
						{
							ControllerPollingInfo current = kReMpQKsdnklzjzUcliIemptZFKy.Current;
							ControllerPollingInfo oKpDoCLstlEwMeAwbjqmtvbvaodrA = new ControllerPollingInfo(current);
							oKpDoCLstlEwMeAwbjqmtvbvaodrA.haeCbWiQSPlfWqsFZDTLoULYjVYq(ukgbjqDyLCUpcsTVxLobGeNDhlQPB.omDgqMdNPYOabeAlYvYukkvWREGe.CgPagdlzMlCQxkbRTPOoePMzAXof);
							OKpDoCLstlEwMeAwbjqmtvbvaodrA = oKpDoCLstlEwMeAwbjqmtvbvaodrA;
							ZucFVCFrPDqmOdhkysiBNXuccAoTA = 1;
							return true;
						}
						PvCwrZbBLAACVCqwONtsAsIcZOHPA();
						kReMpQKsdnklzjzUcliIemptZFKy = null;
						wToxAhRfdFtrWgSoQuELqZLYJvYp++;
						goto IL_00f1;
						IL_00f1:
						if (wToxAhRfdFtrWgSoQuELqZLYJvYp < jbBvSAvQjJWznHwNxMZbHXVfPWBp)
						{
							kReMpQKsdnklzjzUcliIemptZFKy = DZSELtshUkgRMsAYqcbgEQCcuqsd[wToxAhRfdFtrWgSoQuELqZLYJvYp].PollForAllElements().GetEnumerator();
							ZucFVCFrPDqmOdhkysiBNXuccAoTA = -3;
							goto IL_00c5;
						}
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

				private void PvCwrZbBLAACVCqwONtsAsIcZOHPA()
				{
					ZucFVCFrPDqmOdhkysiBNXuccAoTA = -1;
					if (kReMpQKsdnklzjzUcliIemptZFKy != null)
					{
						kReMpQKsdnklzjzUcliIemptZFKy.Dispose();
					}
				}

				[DebuggerHidden]
				void IEnumerator.Reset()
				{
					throw new NotSupportedException();
				}

				[DebuggerHidden]
				IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
				{
					YAGdHiAkmvlFJUzdVBbAmQFfHSitA yAGdHiAkmvlFJUzdVBbAmQFfHSitA;
					if (ZucFVCFrPDqmOdhkysiBNXuccAoTA == -2 && ZRygiNWdZwRewlXEswgQwiNrTMue == Environment.CurrentManagedThreadId)
					{
						ZucFVCFrPDqmOdhkysiBNXuccAoTA = 0;
						yAGdHiAkmvlFJUzdVBbAmQFfHSitA = this;
					}
					else
					{
						yAGdHiAkmvlFJUzdVBbAmQFfHSitA = new YAGdHiAkmvlFJUzdVBbAmQFfHSitA(0);
						yAGdHiAkmvlFJUzdVBbAmQFfHSitA.UkgbjqDyLCUpcsTVxLobGeNDhlQPB = UkgbjqDyLCUpcsTVxLobGeNDhlQPB;
					}
					return yAGdHiAkmvlFJUzdVBbAmQFfHSitA;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
				}
			}

			private sealed class gBwYIWrHBWhMOEhacdHNKEKSefuOA : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
			{
				private int fQyvibrfzpeGngsviIpDYhUXYYYe;

				private ControllerPollingInfo TAFQZmeFThXdoUXLuPaJCBtnjJWQ;

				private int YZBxFLyUgeWXjZSROqeoKejfWJeV;

				public PollingHelper eZCYNRxpKDeTkibClcbuQKQQvaHbA;

				private IList<Joystick> yKVyotGzisSptGdHjNqjJlZZbTko;

				private int DjSAWXPmznTBrryhutrJgKBzOKCu;

				private int SUnTNLZlpDSVJKzQywBWHqDzJwob;

				private IEnumerator<ControllerPollingInfo> rOAGGUaeyepFLlLKZgoOigSAaIZLA;

				ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
				{
					[DebuggerHidden]
					get
					{
						return TAFQZmeFThXdoUXLuPaJCBtnjJWQ;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return TAFQZmeFThXdoUXLuPaJCBtnjJWQ;
					}
				}

				[DebuggerHidden]
				public gBwYIWrHBWhMOEhacdHNKEKSefuOA(int P_0)
				{
					fQyvibrfzpeGngsviIpDYhUXYYYe = P_0;
					YZBxFLyUgeWXjZSROqeoKejfWJeV = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					int num = fQyvibrfzpeGngsviIpDYhUXYYYe;
					if (num == -3 || num == 1)
					{
						try
						{
						}
						finally
						{
							rgxRkubAnCOhoOfqmSirGfIXjgbGA();
						}
					}
				}

				private bool MoveNext()
				{
					try
					{
						int num = fQyvibrfzpeGngsviIpDYhUXYYYe;
						PollingHelper pollingHelper = eZCYNRxpKDeTkibClcbuQKQQvaHbA;
						if (num != 0)
						{
							if (num != 1)
							{
								return false;
							}
							fQyvibrfzpeGngsviIpDYhUXYYYe = -3;
							goto IL_00c5;
						}
						fQyvibrfzpeGngsviIpDYhUXYYYe = -1;
						yKVyotGzisSptGdHjNqjJlZZbTko = pollingHelper.RYrOzLdLhDMcyVDdbzlwvAkCWGA.UZODjZPyOKvXiogzadHvXQZXjpbh().cmeeIbUCxjHUqdNCBHHJgoMnHEVA();
						DjSAWXPmznTBrryhutrJgKBzOKCu = yKVyotGzisSptGdHjNqjJlZZbTko.Count;
						SUnTNLZlpDSVJKzQywBWHqDzJwob = 0;
						goto IL_00f1;
						IL_00c5:
						if (rOAGGUaeyepFLlLKZgoOigSAaIZLA.MoveNext())
						{
							ControllerPollingInfo current = rOAGGUaeyepFLlLKZgoOigSAaIZLA.Current;
							ControllerPollingInfo tAFQZmeFThXdoUXLuPaJCBtnjJWQ = new ControllerPollingInfo(current);
							tAFQZmeFThXdoUXLuPaJCBtnjJWQ.haeCbWiQSPlfWqsFZDTLoULYjVYq(pollingHelper.omDgqMdNPYOabeAlYvYukkvWREGe.CgPagdlzMlCQxkbRTPOoePMzAXof);
							TAFQZmeFThXdoUXLuPaJCBtnjJWQ = tAFQZmeFThXdoUXLuPaJCBtnjJWQ;
							fQyvibrfzpeGngsviIpDYhUXYYYe = 1;
							return true;
						}
						rgxRkubAnCOhoOfqmSirGfIXjgbGA();
						rOAGGUaeyepFLlLKZgoOigSAaIZLA = null;
						SUnTNLZlpDSVJKzQywBWHqDzJwob++;
						goto IL_00f1;
						IL_00f1:
						if (SUnTNLZlpDSVJKzQywBWHqDzJwob < DjSAWXPmznTBrryhutrJgKBzOKCu)
						{
							rOAGGUaeyepFLlLKZgoOigSAaIZLA = yKVyotGzisSptGdHjNqjJlZZbTko[SUnTNLZlpDSVJKzQywBWHqDzJwob].PollForAllElementsDown().GetEnumerator();
							fQyvibrfzpeGngsviIpDYhUXYYYe = -3;
							goto IL_00c5;
						}
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

				private void rgxRkubAnCOhoOfqmSirGfIXjgbGA()
				{
					fQyvibrfzpeGngsviIpDYhUXYYYe = -1;
					if (rOAGGUaeyepFLlLKZgoOigSAaIZLA != null)
					{
						rOAGGUaeyepFLlLKZgoOigSAaIZLA.Dispose();
					}
				}

				[DebuggerHidden]
				void IEnumerator.Reset()
				{
					throw new NotSupportedException();
				}

				[DebuggerHidden]
				IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
				{
					gBwYIWrHBWhMOEhacdHNKEKSefuOA gBwYIWrHBWhMOEhacdHNKEKSefuOA2;
					if (fQyvibrfzpeGngsviIpDYhUXYYYe == -2 && YZBxFLyUgeWXjZSROqeoKejfWJeV == Environment.CurrentManagedThreadId)
					{
						fQyvibrfzpeGngsviIpDYhUXYYYe = 0;
						gBwYIWrHBWhMOEhacdHNKEKSefuOA2 = this;
					}
					else
					{
						gBwYIWrHBWhMOEhacdHNKEKSefuOA2 = new gBwYIWrHBWhMOEhacdHNKEKSefuOA(0);
						gBwYIWrHBWhMOEhacdHNKEKSefuOA2.eZCYNRxpKDeTkibClcbuQKQQvaHbA = eZCYNRxpKDeTkibClcbuQKQQvaHbA;
					}
					return gBwYIWrHBWhMOEhacdHNKEKSefuOA2;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
				}
			}

			private sealed class FkacEtvzcktjBxDvGtMmVuSeXkoc : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
			{
				private int jGdKxpCkmloQshzayPEfXAWoXCal;

				private ControllerPollingInfo KXrOoBUqSXciYJcNEhHGQGfbYLDiA;

				private int AIHKkhGASpZDLCqrGhBVXkqTVgR;

				private int pVXBjPGpmmnobyjHrrwattTscnDT;

				public int hwregSfvEMQSMvNFuCPjGdnXXmdIA;

				public PollingHelper nPFICexkYuPvOYlEkidcTqgSGuoF;

				private IEnumerator<ControllerPollingInfo> HULAUZcRwVorZItFEeVTUMXxfCEaA;

				ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
				{
					[DebuggerHidden]
					get
					{
						return KXrOoBUqSXciYJcNEhHGQGfbYLDiA;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return KXrOoBUqSXciYJcNEhHGQGfbYLDiA;
					}
				}

				[DebuggerHidden]
				public FkacEtvzcktjBxDvGtMmVuSeXkoc(int P_0)
				{
					jGdKxpCkmloQshzayPEfXAWoXCal = P_0;
					AIHKkhGASpZDLCqrGhBVXkqTVgR = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					int num = jGdKxpCkmloQshzayPEfXAWoXCal;
					if (num == -3 || num == 1)
					{
						try
						{
						}
						finally
						{
							jglGQNIPjqGCFSJGgkNmABCwheLo();
						}
					}
				}

				private bool MoveNext()
				{
					try
					{
						int num = jGdKxpCkmloQshzayPEfXAWoXCal;
						PollingHelper pollingHelper = nPFICexkYuPvOYlEkidcTqgSGuoF;
						switch (num)
						{
						default:
							return false;
						case 0:
						{
							jGdKxpCkmloQshzayPEfXAWoXCal = -1;
							if (pVXBjPGpmmnobyjHrrwattTscnDT < 0)
							{
								return false;
							}
							CustomController customController = pollingHelper.RYrOzLdLhDMcyVDdbzlwvAkCWGA.QrSKTUzPSjlCKZGLJDqOVrJyplcf().ItlmsOroseYUCAODTiImPLXMrYyA(pVXBjPGpmmnobyjHrrwattTscnDT);
							if (customController == null)
							{
								return false;
							}
							HULAUZcRwVorZItFEeVTUMXxfCEaA = customController.PollForAllAxes().GetEnumerator();
							jGdKxpCkmloQshzayPEfXAWoXCal = -3;
							break;
						}
						case 1:
							jGdKxpCkmloQshzayPEfXAWoXCal = -3;
							break;
						}
						if (HULAUZcRwVorZItFEeVTUMXxfCEaA.MoveNext())
						{
							ControllerPollingInfo current = HULAUZcRwVorZItFEeVTUMXxfCEaA.Current;
							ControllerPollingInfo kXrOoBUqSXciYJcNEhHGQGfbYLDiA = new ControllerPollingInfo(current);
							kXrOoBUqSXciYJcNEhHGQGfbYLDiA.haeCbWiQSPlfWqsFZDTLoULYjVYq(pollingHelper.omDgqMdNPYOabeAlYvYukkvWREGe.CgPagdlzMlCQxkbRTPOoePMzAXof);
							KXrOoBUqSXciYJcNEhHGQGfbYLDiA = kXrOoBUqSXciYJcNEhHGQGfbYLDiA;
							jGdKxpCkmloQshzayPEfXAWoXCal = 1;
							return true;
						}
						jglGQNIPjqGCFSJGgkNmABCwheLo();
						HULAUZcRwVorZItFEeVTUMXxfCEaA = null;
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

				private void jglGQNIPjqGCFSJGgkNmABCwheLo()
				{
					jGdKxpCkmloQshzayPEfXAWoXCal = -1;
					if (HULAUZcRwVorZItFEeVTUMXxfCEaA != null)
					{
						HULAUZcRwVorZItFEeVTUMXxfCEaA.Dispose();
					}
				}

				[DebuggerHidden]
				void IEnumerator.Reset()
				{
					throw new NotSupportedException();
				}

				[DebuggerHidden]
				IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
				{
					FkacEtvzcktjBxDvGtMmVuSeXkoc fkacEtvzcktjBxDvGtMmVuSeXkoc;
					if (jGdKxpCkmloQshzayPEfXAWoXCal == -2 && AIHKkhGASpZDLCqrGhBVXkqTVgR == Environment.CurrentManagedThreadId)
					{
						jGdKxpCkmloQshzayPEfXAWoXCal = 0;
						fkacEtvzcktjBxDvGtMmVuSeXkoc = this;
					}
					else
					{
						fkacEtvzcktjBxDvGtMmVuSeXkoc = new FkacEtvzcktjBxDvGtMmVuSeXkoc(0);
						fkacEtvzcktjBxDvGtMmVuSeXkoc.nPFICexkYuPvOYlEkidcTqgSGuoF = nPFICexkYuPvOYlEkidcTqgSGuoF;
					}
					fkacEtvzcktjBxDvGtMmVuSeXkoc.pVXBjPGpmmnobyjHrrwattTscnDT = hwregSfvEMQSMvNFuCPjGdnXXmdIA;
					return fkacEtvzcktjBxDvGtMmVuSeXkoc;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
				}
			}

			private sealed class pJkDTFwtwBANTlpXrpepdBPvGcmaA : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
			{
				private int lsGIYGsnweNYBEPVMOASjjOffUDb;

				private ControllerPollingInfo KxWulezbaQdynGgtTKInrpJlAreWA;

				private int qMVeJUgbXgPCmALuAnGiVOBEEajjb;

				private int TlghZrqCVtEcwaOnPmcVDzFTvBqrA;

				public int RnLdLyAzbJnwmhTRySsZkCGYGcfab;

				public PollingHelper VwELjzpSYWDIBDXEGKFAKaACteHW;

				private IEnumerator<ControllerPollingInfo> LQoEuNmqsimBAvJOVLZmfWarNBAj;

				ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
				{
					[DebuggerHidden]
					get
					{
						return KxWulezbaQdynGgtTKInrpJlAreWA;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return KxWulezbaQdynGgtTKInrpJlAreWA;
					}
				}

				[DebuggerHidden]
				public pJkDTFwtwBANTlpXrpepdBPvGcmaA(int P_0)
				{
					lsGIYGsnweNYBEPVMOASjjOffUDb = P_0;
					qMVeJUgbXgPCmALuAnGiVOBEEajjb = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					int num = lsGIYGsnweNYBEPVMOASjjOffUDb;
					if (num == -3 || num == 1)
					{
						try
						{
						}
						finally
						{
							qRBfwmDzTEQdubMKfXeCcpzykYDFb();
						}
					}
				}

				private bool MoveNext()
				{
					try
					{
						int num = lsGIYGsnweNYBEPVMOASjjOffUDb;
						PollingHelper vwELjzpSYWDIBDXEGKFAKaACteHW = VwELjzpSYWDIBDXEGKFAKaACteHW;
						switch (num)
						{
						default:
							return false;
						case 0:
						{
							lsGIYGsnweNYBEPVMOASjjOffUDb = -1;
							if (TlghZrqCVtEcwaOnPmcVDzFTvBqrA < 0)
							{
								return false;
							}
							CustomController customController = vwELjzpSYWDIBDXEGKFAKaACteHW.RYrOzLdLhDMcyVDdbzlwvAkCWGA.QrSKTUzPSjlCKZGLJDqOVrJyplcf().ItlmsOroseYUCAODTiImPLXMrYyA(TlghZrqCVtEcwaOnPmcVDzFTvBqrA);
							if (customController == null)
							{
								return false;
							}
							LQoEuNmqsimBAvJOVLZmfWarNBAj = customController.PollForAllButtons().GetEnumerator();
							lsGIYGsnweNYBEPVMOASjjOffUDb = -3;
							break;
						}
						case 1:
							lsGIYGsnweNYBEPVMOASjjOffUDb = -3;
							break;
						}
						if (LQoEuNmqsimBAvJOVLZmfWarNBAj.MoveNext())
						{
							ControllerPollingInfo current = LQoEuNmqsimBAvJOVLZmfWarNBAj.Current;
							ControllerPollingInfo kxWulezbaQdynGgtTKInrpJlAreWA = new ControllerPollingInfo(current);
							kxWulezbaQdynGgtTKInrpJlAreWA.haeCbWiQSPlfWqsFZDTLoULYjVYq(vwELjzpSYWDIBDXEGKFAKaACteHW.omDgqMdNPYOabeAlYvYukkvWREGe.CgPagdlzMlCQxkbRTPOoePMzAXof);
							KxWulezbaQdynGgtTKInrpJlAreWA = kxWulezbaQdynGgtTKInrpJlAreWA;
							lsGIYGsnweNYBEPVMOASjjOffUDb = 1;
							return true;
						}
						qRBfwmDzTEQdubMKfXeCcpzykYDFb();
						LQoEuNmqsimBAvJOVLZmfWarNBAj = null;
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

				private void qRBfwmDzTEQdubMKfXeCcpzykYDFb()
				{
					lsGIYGsnweNYBEPVMOASjjOffUDb = -1;
					if (LQoEuNmqsimBAvJOVLZmfWarNBAj != null)
					{
						LQoEuNmqsimBAvJOVLZmfWarNBAj.Dispose();
					}
				}

				[DebuggerHidden]
				void IEnumerator.Reset()
				{
					throw new NotSupportedException();
				}

				[DebuggerHidden]
				IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
				{
					pJkDTFwtwBANTlpXrpepdBPvGcmaA pJkDTFwtwBANTlpXrpepdBPvGcmaA2;
					if (lsGIYGsnweNYBEPVMOASjjOffUDb == -2 && qMVeJUgbXgPCmALuAnGiVOBEEajjb == Environment.CurrentManagedThreadId)
					{
						lsGIYGsnweNYBEPVMOASjjOffUDb = 0;
						pJkDTFwtwBANTlpXrpepdBPvGcmaA2 = this;
					}
					else
					{
						pJkDTFwtwBANTlpXrpepdBPvGcmaA2 = new pJkDTFwtwBANTlpXrpepdBPvGcmaA(0);
						pJkDTFwtwBANTlpXrpepdBPvGcmaA2.VwELjzpSYWDIBDXEGKFAKaACteHW = VwELjzpSYWDIBDXEGKFAKaACteHW;
					}
					pJkDTFwtwBANTlpXrpepdBPvGcmaA2.TlghZrqCVtEcwaOnPmcVDzFTvBqrA = RnLdLyAzbJnwmhTRySsZkCGYGcfab;
					return pJkDTFwtwBANTlpXrpepdBPvGcmaA2;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
				}
			}

			private sealed class UZybrTQuWwATJOsErATrfbsLNuw : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
			{
				private int wUXogXZODMRZqFUfNRNeSaNgUVrk;

				private ControllerPollingInfo whjazJHbpzkXjglYDVOnbMZDDAite;

				private int CFfpIpfvpifEsXwhMzEZTKwOwejf;

				private int HaDWnuBqMWdQzArBQlQGDQRrEFnHb;

				public int ImesGcdCWlahdrZncVzcPcLcvrnL;

				public PollingHelper MwpENrIJoNSlwUIsQYCCJmiLOqavA;

				private IEnumerator<ControllerPollingInfo> niVbFDdgGAnzkFlxLgDDDweHeauHc;

				ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
				{
					[DebuggerHidden]
					get
					{
						return whjazJHbpzkXjglYDVOnbMZDDAite;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return whjazJHbpzkXjglYDVOnbMZDDAite;
					}
				}

				[DebuggerHidden]
				public UZybrTQuWwATJOsErATrfbsLNuw(int P_0)
				{
					wUXogXZODMRZqFUfNRNeSaNgUVrk = P_0;
					CFfpIpfvpifEsXwhMzEZTKwOwejf = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					int num = wUXogXZODMRZqFUfNRNeSaNgUVrk;
					if (num == -3 || num == 1)
					{
						try
						{
						}
						finally
						{
							RBtkfSoCBQahghjOFmEecDgGAvRgA();
						}
					}
				}

				private bool MoveNext()
				{
					try
					{
						int num = wUXogXZODMRZqFUfNRNeSaNgUVrk;
						PollingHelper mwpENrIJoNSlwUIsQYCCJmiLOqavA = MwpENrIJoNSlwUIsQYCCJmiLOqavA;
						switch (num)
						{
						default:
							return false;
						case 0:
						{
							wUXogXZODMRZqFUfNRNeSaNgUVrk = -1;
							if (HaDWnuBqMWdQzArBQlQGDQRrEFnHb < 0)
							{
								return false;
							}
							CustomController customController = mwpENrIJoNSlwUIsQYCCJmiLOqavA.RYrOzLdLhDMcyVDdbzlwvAkCWGA.QrSKTUzPSjlCKZGLJDqOVrJyplcf().ItlmsOroseYUCAODTiImPLXMrYyA(HaDWnuBqMWdQzArBQlQGDQRrEFnHb);
							if (customController == null)
							{
								return false;
							}
							niVbFDdgGAnzkFlxLgDDDweHeauHc = customController.PollForAllButtonsDown().GetEnumerator();
							wUXogXZODMRZqFUfNRNeSaNgUVrk = -3;
							break;
						}
						case 1:
							wUXogXZODMRZqFUfNRNeSaNgUVrk = -3;
							break;
						}
						if (niVbFDdgGAnzkFlxLgDDDweHeauHc.MoveNext())
						{
							ControllerPollingInfo current = niVbFDdgGAnzkFlxLgDDDweHeauHc.Current;
							ControllerPollingInfo controllerPollingInfo = new ControllerPollingInfo(current);
							controllerPollingInfo.haeCbWiQSPlfWqsFZDTLoULYjVYq(mwpENrIJoNSlwUIsQYCCJmiLOqavA.omDgqMdNPYOabeAlYvYukkvWREGe.CgPagdlzMlCQxkbRTPOoePMzAXof);
							whjazJHbpzkXjglYDVOnbMZDDAite = controllerPollingInfo;
							wUXogXZODMRZqFUfNRNeSaNgUVrk = 1;
							return true;
						}
						RBtkfSoCBQahghjOFmEecDgGAvRgA();
						niVbFDdgGAnzkFlxLgDDDweHeauHc = null;
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

				private void RBtkfSoCBQahghjOFmEecDgGAvRgA()
				{
					wUXogXZODMRZqFUfNRNeSaNgUVrk = -1;
					if (niVbFDdgGAnzkFlxLgDDDweHeauHc != null)
					{
						niVbFDdgGAnzkFlxLgDDDweHeauHc.Dispose();
					}
				}

				[DebuggerHidden]
				void IEnumerator.Reset()
				{
					throw new NotSupportedException();
				}

				[DebuggerHidden]
				IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
				{
					UZybrTQuWwATJOsErATrfbsLNuw uZybrTQuWwATJOsErATrfbsLNuw;
					if (wUXogXZODMRZqFUfNRNeSaNgUVrk == -2 && CFfpIpfvpifEsXwhMzEZTKwOwejf == Environment.CurrentManagedThreadId)
					{
						wUXogXZODMRZqFUfNRNeSaNgUVrk = 0;
						uZybrTQuWwATJOsErATrfbsLNuw = this;
					}
					else
					{
						uZybrTQuWwATJOsErATrfbsLNuw = new UZybrTQuWwATJOsErATrfbsLNuw(0);
						uZybrTQuWwATJOsErATrfbsLNuw.MwpENrIJoNSlwUIsQYCCJmiLOqavA = MwpENrIJoNSlwUIsQYCCJmiLOqavA;
					}
					uZybrTQuWwATJOsErATrfbsLNuw.HaDWnuBqMWdQzArBQlQGDQRrEFnHb = ImesGcdCWlahdrZncVzcPcLcvrnL;
					return uZybrTQuWwATJOsErATrfbsLNuw;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
				}
			}

			private sealed class ImAsSUxIhuWACTcXeDLFGOWhKhOgA : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
			{
				private int vcQjvLwMCJLWUbcwVtiuvUlyeiIp;

				private ControllerPollingInfo BlvEdTehzbhXfMOHOhRLTtZObNxgA;

				private int xiLPfJZWNDZUHosZoEzPiiJILFIl;

				private int mMsuIHWtrVsAiXcqOTphCHkDYJxD;

				public int wsnAOHhmNSdxxOqfWzQFbnDbuOHwA;

				public PollingHelper IrezdTkIOYFDlIigZcOADTGkgxpKA;

				private IEnumerator<ControllerPollingInfo> hIDYiyeADiORZuNsIJgmBgzKoQLm;

				ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
				{
					[DebuggerHidden]
					get
					{
						return BlvEdTehzbhXfMOHOhRLTtZObNxgA;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return BlvEdTehzbhXfMOHOhRLTtZObNxgA;
					}
				}

				[DebuggerHidden]
				public ImAsSUxIhuWACTcXeDLFGOWhKhOgA(int P_0)
				{
					vcQjvLwMCJLWUbcwVtiuvUlyeiIp = P_0;
					xiLPfJZWNDZUHosZoEzPiiJILFIl = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					int num = vcQjvLwMCJLWUbcwVtiuvUlyeiIp;
					if (num == -3 || num == 1)
					{
						try
						{
						}
						finally
						{
							iYJfNfffuxMMxuIyTXBEGzxGpTGB();
						}
					}
				}

				private bool MoveNext()
				{
					try
					{
						int num = vcQjvLwMCJLWUbcwVtiuvUlyeiIp;
						PollingHelper irezdTkIOYFDlIigZcOADTGkgxpKA = IrezdTkIOYFDlIigZcOADTGkgxpKA;
						switch (num)
						{
						default:
							return false;
						case 0:
						{
							vcQjvLwMCJLWUbcwVtiuvUlyeiIp = -1;
							if (mMsuIHWtrVsAiXcqOTphCHkDYJxD < 0)
							{
								return false;
							}
							CustomController customController = irezdTkIOYFDlIigZcOADTGkgxpKA.RYrOzLdLhDMcyVDdbzlwvAkCWGA.QrSKTUzPSjlCKZGLJDqOVrJyplcf().ItlmsOroseYUCAODTiImPLXMrYyA(mMsuIHWtrVsAiXcqOTphCHkDYJxD);
							if (customController == null)
							{
								return false;
							}
							hIDYiyeADiORZuNsIJgmBgzKoQLm = customController.PollForAllElements().GetEnumerator();
							vcQjvLwMCJLWUbcwVtiuvUlyeiIp = -3;
							break;
						}
						case 1:
							vcQjvLwMCJLWUbcwVtiuvUlyeiIp = -3;
							break;
						}
						if (hIDYiyeADiORZuNsIJgmBgzKoQLm.MoveNext())
						{
							ControllerPollingInfo current = hIDYiyeADiORZuNsIJgmBgzKoQLm.Current;
							ControllerPollingInfo blvEdTehzbhXfMOHOhRLTtZObNxgA = new ControllerPollingInfo(current);
							blvEdTehzbhXfMOHOhRLTtZObNxgA.haeCbWiQSPlfWqsFZDTLoULYjVYq(irezdTkIOYFDlIigZcOADTGkgxpKA.omDgqMdNPYOabeAlYvYukkvWREGe.CgPagdlzMlCQxkbRTPOoePMzAXof);
							BlvEdTehzbhXfMOHOhRLTtZObNxgA = blvEdTehzbhXfMOHOhRLTtZObNxgA;
							vcQjvLwMCJLWUbcwVtiuvUlyeiIp = 1;
							return true;
						}
						iYJfNfffuxMMxuIyTXBEGzxGpTGB();
						hIDYiyeADiORZuNsIJgmBgzKoQLm = null;
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

				private void iYJfNfffuxMMxuIyTXBEGzxGpTGB()
				{
					vcQjvLwMCJLWUbcwVtiuvUlyeiIp = -1;
					if (hIDYiyeADiORZuNsIJgmBgzKoQLm != null)
					{
						hIDYiyeADiORZuNsIJgmBgzKoQLm.Dispose();
					}
				}

				[DebuggerHidden]
				void IEnumerator.Reset()
				{
					throw new NotSupportedException();
				}

				[DebuggerHidden]
				IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
				{
					ImAsSUxIhuWACTcXeDLFGOWhKhOgA imAsSUxIhuWACTcXeDLFGOWhKhOgA;
					if (vcQjvLwMCJLWUbcwVtiuvUlyeiIp == -2 && xiLPfJZWNDZUHosZoEzPiiJILFIl == Environment.CurrentManagedThreadId)
					{
						vcQjvLwMCJLWUbcwVtiuvUlyeiIp = 0;
						imAsSUxIhuWACTcXeDLFGOWhKhOgA = this;
					}
					else
					{
						imAsSUxIhuWACTcXeDLFGOWhKhOgA = new ImAsSUxIhuWACTcXeDLFGOWhKhOgA(0);
						imAsSUxIhuWACTcXeDLFGOWhKhOgA.IrezdTkIOYFDlIigZcOADTGkgxpKA = IrezdTkIOYFDlIigZcOADTGkgxpKA;
					}
					imAsSUxIhuWACTcXeDLFGOWhKhOgA.mMsuIHWtrVsAiXcqOTphCHkDYJxD = wsnAOHhmNSdxxOqfWzQFbnDbuOHwA;
					return imAsSUxIhuWACTcXeDLFGOWhKhOgA;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
				}
			}

			private sealed class LVGBUXNETyxyYbkChEqgFYqcdTc : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
			{
				private int RsbowjVJGMDyppnxDpozUpLlUUPc;

				private ControllerPollingInfo yWfJsDAwiYRZKXDOmnskEiGbNduV;

				private int yeGandtdMHyDCMBDVAJjKNsURotPA;

				private int fFQHBqOmQAJGdDJOOfpoKRTvtSqM;

				public int PCJHDOMjDVKoaaSAAiuraqEDbHUNA;

				public PollingHelper YzcUHwDEsydATVAKlObQUOgEgZWQ;

				private IEnumerator<ControllerPollingInfo> aNOIscnpjdgWdWQpeSQZcxUHSniq;

				ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
				{
					[DebuggerHidden]
					get
					{
						return yWfJsDAwiYRZKXDOmnskEiGbNduV;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return yWfJsDAwiYRZKXDOmnskEiGbNduV;
					}
				}

				[DebuggerHidden]
				public LVGBUXNETyxyYbkChEqgFYqcdTc(int P_0)
				{
					RsbowjVJGMDyppnxDpozUpLlUUPc = P_0;
					yeGandtdMHyDCMBDVAJjKNsURotPA = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					int rsbowjVJGMDyppnxDpozUpLlUUPc = RsbowjVJGMDyppnxDpozUpLlUUPc;
					if (rsbowjVJGMDyppnxDpozUpLlUUPc == -3 || rsbowjVJGMDyppnxDpozUpLlUUPc == 1)
					{
						try
						{
						}
						finally
						{
							KFkcrbROeafCZZjOqZqUuiOwWKgc();
						}
					}
				}

				private bool MoveNext()
				{
					try
					{
						int rsbowjVJGMDyppnxDpozUpLlUUPc = RsbowjVJGMDyppnxDpozUpLlUUPc;
						PollingHelper yzcUHwDEsydATVAKlObQUOgEgZWQ = YzcUHwDEsydATVAKlObQUOgEgZWQ;
						switch (rsbowjVJGMDyppnxDpozUpLlUUPc)
						{
						default:
							return false;
						case 0:
						{
							RsbowjVJGMDyppnxDpozUpLlUUPc = -1;
							if (fFQHBqOmQAJGdDJOOfpoKRTvtSqM < 0)
							{
								return false;
							}
							CustomController customController = yzcUHwDEsydATVAKlObQUOgEgZWQ.RYrOzLdLhDMcyVDdbzlwvAkCWGA.QrSKTUzPSjlCKZGLJDqOVrJyplcf().ItlmsOroseYUCAODTiImPLXMrYyA(fFQHBqOmQAJGdDJOOfpoKRTvtSqM);
							if (customController == null)
							{
								return false;
							}
							aNOIscnpjdgWdWQpeSQZcxUHSniq = customController.PollForAllElementsDown().GetEnumerator();
							RsbowjVJGMDyppnxDpozUpLlUUPc = -3;
							break;
						}
						case 1:
							RsbowjVJGMDyppnxDpozUpLlUUPc = -3;
							break;
						}
						if (aNOIscnpjdgWdWQpeSQZcxUHSniq.MoveNext())
						{
							ControllerPollingInfo current = aNOIscnpjdgWdWQpeSQZcxUHSniq.Current;
							ControllerPollingInfo controllerPollingInfo = new ControllerPollingInfo(current);
							controllerPollingInfo.haeCbWiQSPlfWqsFZDTLoULYjVYq(yzcUHwDEsydATVAKlObQUOgEgZWQ.omDgqMdNPYOabeAlYvYukkvWREGe.CgPagdlzMlCQxkbRTPOoePMzAXof);
							yWfJsDAwiYRZKXDOmnskEiGbNduV = controllerPollingInfo;
							RsbowjVJGMDyppnxDpozUpLlUUPc = 1;
							return true;
						}
						KFkcrbROeafCZZjOqZqUuiOwWKgc();
						aNOIscnpjdgWdWQpeSQZcxUHSniq = null;
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

				private void KFkcrbROeafCZZjOqZqUuiOwWKgc()
				{
					RsbowjVJGMDyppnxDpozUpLlUUPc = -1;
					if (aNOIscnpjdgWdWQpeSQZcxUHSniq != null)
					{
						aNOIscnpjdgWdWQpeSQZcxUHSniq.Dispose();
					}
				}

				[DebuggerHidden]
				void IEnumerator.Reset()
				{
					throw new NotSupportedException();
				}

				[DebuggerHidden]
				IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
				{
					LVGBUXNETyxyYbkChEqgFYqcdTc lVGBUXNETyxyYbkChEqgFYqcdTc;
					if (RsbowjVJGMDyppnxDpozUpLlUUPc == -2 && yeGandtdMHyDCMBDVAJjKNsURotPA == Environment.CurrentManagedThreadId)
					{
						RsbowjVJGMDyppnxDpozUpLlUUPc = 0;
						lVGBUXNETyxyYbkChEqgFYqcdTc = this;
					}
					else
					{
						lVGBUXNETyxyYbkChEqgFYqcdTc = new LVGBUXNETyxyYbkChEqgFYqcdTc(0);
						lVGBUXNETyxyYbkChEqgFYqcdTc.YzcUHwDEsydATVAKlObQUOgEgZWQ = YzcUHwDEsydATVAKlObQUOgEgZWQ;
					}
					lVGBUXNETyxyYbkChEqgFYqcdTc.fFQHBqOmQAJGdDJOOfpoKRTvtSqM = PCJHDOMjDVKoaaSAAiuraqEDbHUNA;
					return lVGBUXNETyxyYbkChEqgFYqcdTc;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
				}
			}

			private sealed class vaqYJEsARRIJfyEZTBLuOxBzBYAC : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
			{
				private int pDAwieNSCVgbVnXvbDCnKGqIOdnRA;

				private ControllerPollingInfo hvBPFftoKIRIIJcCyqLUcEneCXzCA;

				private int aInkQFdtPEIiStBkGumexqenlWHo;

				private int QVdwKcMcakdwbloJdZzMqNTkdIZg;

				public int XbUwgEIaNoDvrsYfRnmIJPJKfZCc;

				public PollingHelper UuvnORaLpYclvHoBDihLgkypAlSb;

				private IEnumerator<ControllerPollingInfo> ujoYZCVOcFQbMaCsJHkLfhwgCNCP;

				ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
				{
					[DebuggerHidden]
					get
					{
						return hvBPFftoKIRIIJcCyqLUcEneCXzCA;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return hvBPFftoKIRIIJcCyqLUcEneCXzCA;
					}
				}

				[DebuggerHidden]
				public vaqYJEsARRIJfyEZTBLuOxBzBYAC(int P_0)
				{
					pDAwieNSCVgbVnXvbDCnKGqIOdnRA = P_0;
					aInkQFdtPEIiStBkGumexqenlWHo = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					int num = pDAwieNSCVgbVnXvbDCnKGqIOdnRA;
					if (num == -3 || num == 1)
					{
						try
						{
						}
						finally
						{
							BzOBtHrdLJqlMaFGabUpcHLQCkJab();
						}
					}
				}

				private bool MoveNext()
				{
					try
					{
						int num = pDAwieNSCVgbVnXvbDCnKGqIOdnRA;
						PollingHelper uuvnORaLpYclvHoBDihLgkypAlSb = UuvnORaLpYclvHoBDihLgkypAlSb;
						switch (num)
						{
						default:
							return false;
						case 0:
						{
							pDAwieNSCVgbVnXvbDCnKGqIOdnRA = -1;
							if (QVdwKcMcakdwbloJdZzMqNTkdIZg < 0)
							{
								return false;
							}
							Joystick joystick = uuvnORaLpYclvHoBDihLgkypAlSb.RYrOzLdLhDMcyVDdbzlwvAkCWGA.UZODjZPyOKvXiogzadHvXQZXjpbh().ItlmsOroseYUCAODTiImPLXMrYyA(QVdwKcMcakdwbloJdZzMqNTkdIZg);
							if (joystick == null)
							{
								return false;
							}
							ujoYZCVOcFQbMaCsJHkLfhwgCNCP = joystick.PollForAllAxes().GetEnumerator();
							pDAwieNSCVgbVnXvbDCnKGqIOdnRA = -3;
							break;
						}
						case 1:
							pDAwieNSCVgbVnXvbDCnKGqIOdnRA = -3;
							break;
						}
						if (ujoYZCVOcFQbMaCsJHkLfhwgCNCP.MoveNext())
						{
							ControllerPollingInfo current = ujoYZCVOcFQbMaCsJHkLfhwgCNCP.Current;
							ControllerPollingInfo controllerPollingInfo = new ControllerPollingInfo(current);
							controllerPollingInfo.haeCbWiQSPlfWqsFZDTLoULYjVYq(uuvnORaLpYclvHoBDihLgkypAlSb.omDgqMdNPYOabeAlYvYukkvWREGe.CgPagdlzMlCQxkbRTPOoePMzAXof);
							hvBPFftoKIRIIJcCyqLUcEneCXzCA = controllerPollingInfo;
							pDAwieNSCVgbVnXvbDCnKGqIOdnRA = 1;
							return true;
						}
						BzOBtHrdLJqlMaFGabUpcHLQCkJab();
						ujoYZCVOcFQbMaCsJHkLfhwgCNCP = null;
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

				private void BzOBtHrdLJqlMaFGabUpcHLQCkJab()
				{
					pDAwieNSCVgbVnXvbDCnKGqIOdnRA = -1;
					if (ujoYZCVOcFQbMaCsJHkLfhwgCNCP != null)
					{
						ujoYZCVOcFQbMaCsJHkLfhwgCNCP.Dispose();
					}
				}

				[DebuggerHidden]
				void IEnumerator.Reset()
				{
					throw new NotSupportedException();
				}

				[DebuggerHidden]
				IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
				{
					vaqYJEsARRIJfyEZTBLuOxBzBYAC vaqYJEsARRIJfyEZTBLuOxBzBYAC2;
					if (pDAwieNSCVgbVnXvbDCnKGqIOdnRA == -2 && aInkQFdtPEIiStBkGumexqenlWHo == Environment.CurrentManagedThreadId)
					{
						pDAwieNSCVgbVnXvbDCnKGqIOdnRA = 0;
						vaqYJEsARRIJfyEZTBLuOxBzBYAC2 = this;
					}
					else
					{
						vaqYJEsARRIJfyEZTBLuOxBzBYAC2 = new vaqYJEsARRIJfyEZTBLuOxBzBYAC(0);
						vaqYJEsARRIJfyEZTBLuOxBzBYAC2.UuvnORaLpYclvHoBDihLgkypAlSb = UuvnORaLpYclvHoBDihLgkypAlSb;
					}
					vaqYJEsARRIJfyEZTBLuOxBzBYAC2.QVdwKcMcakdwbloJdZzMqNTkdIZg = XbUwgEIaNoDvrsYfRnmIJPJKfZCc;
					return vaqYJEsARRIJfyEZTBLuOxBzBYAC2;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
				}
			}

			private sealed class qgacGOeOZSRJcUbbIVucbhouZDNSA : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
			{
				private int jpnorFpuhukrnOVwQscPrKnlgpJJ;

				private ControllerPollingInfo qsvRJRViXVrKTrWDtBaFIoKKeXRH;

				private int azIQYsjKJoGYLPoJvQRSpSoizOEg;

				private int JmwJEyzZmzQjhvxKQSOKaldlsyJV;

				public int LLoXuaqNSoWTCyTnzPaFzDcWhTOy;

				public PollingHelper dEEzQtemViEwMaCcUmGGhGfJskeB;

				private IEnumerator<ControllerPollingInfo> uzENTchZqQAXESQEmOVszUuFgZBA;

				ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
				{
					[DebuggerHidden]
					get
					{
						return qsvRJRViXVrKTrWDtBaFIoKKeXRH;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return qsvRJRViXVrKTrWDtBaFIoKKeXRH;
					}
				}

				[DebuggerHidden]
				public qgacGOeOZSRJcUbbIVucbhouZDNSA(int P_0)
				{
					jpnorFpuhukrnOVwQscPrKnlgpJJ = P_0;
					azIQYsjKJoGYLPoJvQRSpSoizOEg = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					int num = jpnorFpuhukrnOVwQscPrKnlgpJJ;
					if (num == -3 || num == 1)
					{
						try
						{
						}
						finally
						{
							kLqZoAmDOkYHloIsKjAJszyJvCxi();
						}
					}
				}

				private bool MoveNext()
				{
					try
					{
						int num = jpnorFpuhukrnOVwQscPrKnlgpJJ;
						PollingHelper pollingHelper = dEEzQtemViEwMaCcUmGGhGfJskeB;
						switch (num)
						{
						default:
							return false;
						case 0:
						{
							jpnorFpuhukrnOVwQscPrKnlgpJJ = -1;
							if (JmwJEyzZmzQjhvxKQSOKaldlsyJV < 0)
							{
								return false;
							}
							Joystick joystick = pollingHelper.RYrOzLdLhDMcyVDdbzlwvAkCWGA.UZODjZPyOKvXiogzadHvXQZXjpbh().ItlmsOroseYUCAODTiImPLXMrYyA(JmwJEyzZmzQjhvxKQSOKaldlsyJV);
							if (joystick == null)
							{
								return false;
							}
							uzENTchZqQAXESQEmOVszUuFgZBA = joystick.PollForAllButtons().GetEnumerator();
							jpnorFpuhukrnOVwQscPrKnlgpJJ = -3;
							break;
						}
						case 1:
							jpnorFpuhukrnOVwQscPrKnlgpJJ = -3;
							break;
						}
						if (uzENTchZqQAXESQEmOVszUuFgZBA.MoveNext())
						{
							ControllerPollingInfo current = uzENTchZqQAXESQEmOVszUuFgZBA.Current;
							ControllerPollingInfo controllerPollingInfo = new ControllerPollingInfo(current);
							controllerPollingInfo.haeCbWiQSPlfWqsFZDTLoULYjVYq(pollingHelper.omDgqMdNPYOabeAlYvYukkvWREGe.CgPagdlzMlCQxkbRTPOoePMzAXof);
							qsvRJRViXVrKTrWDtBaFIoKKeXRH = controllerPollingInfo;
							jpnorFpuhukrnOVwQscPrKnlgpJJ = 1;
							return true;
						}
						kLqZoAmDOkYHloIsKjAJszyJvCxi();
						uzENTchZqQAXESQEmOVszUuFgZBA = null;
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

				private void kLqZoAmDOkYHloIsKjAJszyJvCxi()
				{
					jpnorFpuhukrnOVwQscPrKnlgpJJ = -1;
					if (uzENTchZqQAXESQEmOVszUuFgZBA != null)
					{
						uzENTchZqQAXESQEmOVszUuFgZBA.Dispose();
					}
				}

				[DebuggerHidden]
				void IEnumerator.Reset()
				{
					throw new NotSupportedException();
				}

				[DebuggerHidden]
				IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
				{
					qgacGOeOZSRJcUbbIVucbhouZDNSA qgacGOeOZSRJcUbbIVucbhouZDNSA2;
					if (jpnorFpuhukrnOVwQscPrKnlgpJJ == -2 && azIQYsjKJoGYLPoJvQRSpSoizOEg == Environment.CurrentManagedThreadId)
					{
						jpnorFpuhukrnOVwQscPrKnlgpJJ = 0;
						qgacGOeOZSRJcUbbIVucbhouZDNSA2 = this;
					}
					else
					{
						qgacGOeOZSRJcUbbIVucbhouZDNSA2 = new qgacGOeOZSRJcUbbIVucbhouZDNSA(0);
						qgacGOeOZSRJcUbbIVucbhouZDNSA2.dEEzQtemViEwMaCcUmGGhGfJskeB = dEEzQtemViEwMaCcUmGGhGfJskeB;
					}
					qgacGOeOZSRJcUbbIVucbhouZDNSA2.JmwJEyzZmzQjhvxKQSOKaldlsyJV = LLoXuaqNSoWTCyTnzPaFzDcWhTOy;
					return qgacGOeOZSRJcUbbIVucbhouZDNSA2;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
				}
			}

			private sealed class RahVTJgxWIIylYIJKSqYFFjJbXGj : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
			{
				private int MgNCzZNNzdcWczTTVIQxwBDeFligA;

				private ControllerPollingInfo kHfcoRBnbSoPZcULaVTbmRHfNDmjc;

				private int ZCQxaudAzpnffjIBLZqDFbIHaGckA;

				private int JcLzwnUKzMAgNzfykFIeeviiKcqaA;

				public int zmQvOBRZKCbbqGksSKcvXexgpDIl;

				public PollingHelper bDhAQtdXSomYYiUoPqRcMEnNplaab;

				private IEnumerator<ControllerPollingInfo> lUWPZBtzOloCdeAKcicEzUIMRIBR;

				ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
				{
					[DebuggerHidden]
					get
					{
						return kHfcoRBnbSoPZcULaVTbmRHfNDmjc;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return kHfcoRBnbSoPZcULaVTbmRHfNDmjc;
					}
				}

				[DebuggerHidden]
				public RahVTJgxWIIylYIJKSqYFFjJbXGj(int P_0)
				{
					MgNCzZNNzdcWczTTVIQxwBDeFligA = P_0;
					ZCQxaudAzpnffjIBLZqDFbIHaGckA = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					int mgNCzZNNzdcWczTTVIQxwBDeFligA = MgNCzZNNzdcWczTTVIQxwBDeFligA;
					if (mgNCzZNNzdcWczTTVIQxwBDeFligA == -3 || mgNCzZNNzdcWczTTVIQxwBDeFligA == 1)
					{
						try
						{
						}
						finally
						{
							oeXvcrNckOtsanBMPtSJcCnRBAQjA();
						}
					}
				}

				private bool MoveNext()
				{
					try
					{
						int mgNCzZNNzdcWczTTVIQxwBDeFligA = MgNCzZNNzdcWczTTVIQxwBDeFligA;
						PollingHelper pollingHelper = bDhAQtdXSomYYiUoPqRcMEnNplaab;
						switch (mgNCzZNNzdcWczTTVIQxwBDeFligA)
						{
						default:
							return false;
						case 0:
						{
							MgNCzZNNzdcWczTTVIQxwBDeFligA = -1;
							if (JcLzwnUKzMAgNzfykFIeeviiKcqaA < 0)
							{
								return false;
							}
							Joystick joystick = pollingHelper.RYrOzLdLhDMcyVDdbzlwvAkCWGA.UZODjZPyOKvXiogzadHvXQZXjpbh().ItlmsOroseYUCAODTiImPLXMrYyA(JcLzwnUKzMAgNzfykFIeeviiKcqaA);
							if (joystick == null)
							{
								return false;
							}
							lUWPZBtzOloCdeAKcicEzUIMRIBR = joystick.PollForAllButtonsDown().GetEnumerator();
							MgNCzZNNzdcWczTTVIQxwBDeFligA = -3;
							break;
						}
						case 1:
							MgNCzZNNzdcWczTTVIQxwBDeFligA = -3;
							break;
						}
						if (lUWPZBtzOloCdeAKcicEzUIMRIBR.MoveNext())
						{
							ControllerPollingInfo current = lUWPZBtzOloCdeAKcicEzUIMRIBR.Current;
							ControllerPollingInfo controllerPollingInfo = new ControllerPollingInfo(current);
							controllerPollingInfo.haeCbWiQSPlfWqsFZDTLoULYjVYq(pollingHelper.omDgqMdNPYOabeAlYvYukkvWREGe.CgPagdlzMlCQxkbRTPOoePMzAXof);
							kHfcoRBnbSoPZcULaVTbmRHfNDmjc = controllerPollingInfo;
							MgNCzZNNzdcWczTTVIQxwBDeFligA = 1;
							return true;
						}
						oeXvcrNckOtsanBMPtSJcCnRBAQjA();
						lUWPZBtzOloCdeAKcicEzUIMRIBR = null;
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

				private void oeXvcrNckOtsanBMPtSJcCnRBAQjA()
				{
					MgNCzZNNzdcWczTTVIQxwBDeFligA = -1;
					if (lUWPZBtzOloCdeAKcicEzUIMRIBR != null)
					{
						lUWPZBtzOloCdeAKcicEzUIMRIBR.Dispose();
					}
				}

				[DebuggerHidden]
				void IEnumerator.Reset()
				{
					throw new NotSupportedException();
				}

				[DebuggerHidden]
				IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
				{
					RahVTJgxWIIylYIJKSqYFFjJbXGj rahVTJgxWIIylYIJKSqYFFjJbXGj;
					if (MgNCzZNNzdcWczTTVIQxwBDeFligA == -2 && ZCQxaudAzpnffjIBLZqDFbIHaGckA == Environment.CurrentManagedThreadId)
					{
						MgNCzZNNzdcWczTTVIQxwBDeFligA = 0;
						rahVTJgxWIIylYIJKSqYFFjJbXGj = this;
					}
					else
					{
						rahVTJgxWIIylYIJKSqYFFjJbXGj = new RahVTJgxWIIylYIJKSqYFFjJbXGj(0);
						rahVTJgxWIIylYIJKSqYFFjJbXGj.bDhAQtdXSomYYiUoPqRcMEnNplaab = bDhAQtdXSomYYiUoPqRcMEnNplaab;
					}
					rahVTJgxWIIylYIJKSqYFFjJbXGj.JcLzwnUKzMAgNzfykFIeeviiKcqaA = zmQvOBRZKCbbqGksSKcvXexgpDIl;
					return rahVTJgxWIIylYIJKSqYFFjJbXGj;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
				}
			}

			private sealed class hWCeZzhDnqOVbzPbWQPDoTswOYjP : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
			{
				private int MddtmzBxFWJDDMlXpRsXjIMlkOSm;

				private ControllerPollingInfo USVQGiICtACWuGmSueZEbioHPKaSb;

				private int cLvGNtHrxPjoYVFfioyJlsmfzecT;

				private int jaAPtdDZVjSewmSpEQHUVTDWmdMe;

				public int hpUyncVoVzTFdlWvmndteWjfpZbH;

				public PollingHelper CczaYlnseUbUTdjCsvfJODDqiyBJA;

				private IEnumerator<ControllerPollingInfo> OcRHZIrSFUbduEmbpnvjDyeUOdAX;

				ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
				{
					[DebuggerHidden]
					get
					{
						return USVQGiICtACWuGmSueZEbioHPKaSb;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return USVQGiICtACWuGmSueZEbioHPKaSb;
					}
				}

				[DebuggerHidden]
				public hWCeZzhDnqOVbzPbWQPDoTswOYjP(int P_0)
				{
					MddtmzBxFWJDDMlXpRsXjIMlkOSm = P_0;
					cLvGNtHrxPjoYVFfioyJlsmfzecT = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					int mddtmzBxFWJDDMlXpRsXjIMlkOSm = MddtmzBxFWJDDMlXpRsXjIMlkOSm;
					if (mddtmzBxFWJDDMlXpRsXjIMlkOSm == -3 || mddtmzBxFWJDDMlXpRsXjIMlkOSm == 1)
					{
						try
						{
						}
						finally
						{
							HiuPajcLBksFkQguUetGRYpDDjFw();
						}
					}
				}

				private bool MoveNext()
				{
					try
					{
						int mddtmzBxFWJDDMlXpRsXjIMlkOSm = MddtmzBxFWJDDMlXpRsXjIMlkOSm;
						PollingHelper cczaYlnseUbUTdjCsvfJODDqiyBJA = CczaYlnseUbUTdjCsvfJODDqiyBJA;
						switch (mddtmzBxFWJDDMlXpRsXjIMlkOSm)
						{
						default:
							return false;
						case 0:
						{
							MddtmzBxFWJDDMlXpRsXjIMlkOSm = -1;
							if (jaAPtdDZVjSewmSpEQHUVTDWmdMe < 0)
							{
								return false;
							}
							Joystick joystick = cczaYlnseUbUTdjCsvfJODDqiyBJA.RYrOzLdLhDMcyVDdbzlwvAkCWGA.UZODjZPyOKvXiogzadHvXQZXjpbh().ItlmsOroseYUCAODTiImPLXMrYyA(jaAPtdDZVjSewmSpEQHUVTDWmdMe);
							if (joystick == null)
							{
								return false;
							}
							OcRHZIrSFUbduEmbpnvjDyeUOdAX = joystick.PollForAllElements().GetEnumerator();
							MddtmzBxFWJDDMlXpRsXjIMlkOSm = -3;
							break;
						}
						case 1:
							MddtmzBxFWJDDMlXpRsXjIMlkOSm = -3;
							break;
						}
						if (OcRHZIrSFUbduEmbpnvjDyeUOdAX.MoveNext())
						{
							ControllerPollingInfo current = OcRHZIrSFUbduEmbpnvjDyeUOdAX.Current;
							ControllerPollingInfo uSVQGiICtACWuGmSueZEbioHPKaSb = new ControllerPollingInfo(current);
							uSVQGiICtACWuGmSueZEbioHPKaSb.haeCbWiQSPlfWqsFZDTLoULYjVYq(cczaYlnseUbUTdjCsvfJODDqiyBJA.omDgqMdNPYOabeAlYvYukkvWREGe.CgPagdlzMlCQxkbRTPOoePMzAXof);
							USVQGiICtACWuGmSueZEbioHPKaSb = uSVQGiICtACWuGmSueZEbioHPKaSb;
							MddtmzBxFWJDDMlXpRsXjIMlkOSm = 1;
							return true;
						}
						HiuPajcLBksFkQguUetGRYpDDjFw();
						OcRHZIrSFUbduEmbpnvjDyeUOdAX = null;
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

				private void HiuPajcLBksFkQguUetGRYpDDjFw()
				{
					MddtmzBxFWJDDMlXpRsXjIMlkOSm = -1;
					if (OcRHZIrSFUbduEmbpnvjDyeUOdAX != null)
					{
						OcRHZIrSFUbduEmbpnvjDyeUOdAX.Dispose();
					}
				}

				[DebuggerHidden]
				void IEnumerator.Reset()
				{
					throw new NotSupportedException();
				}

				[DebuggerHidden]
				IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
				{
					hWCeZzhDnqOVbzPbWQPDoTswOYjP hWCeZzhDnqOVbzPbWQPDoTswOYjP2;
					if (MddtmzBxFWJDDMlXpRsXjIMlkOSm == -2 && cLvGNtHrxPjoYVFfioyJlsmfzecT == Environment.CurrentManagedThreadId)
					{
						MddtmzBxFWJDDMlXpRsXjIMlkOSm = 0;
						hWCeZzhDnqOVbzPbWQPDoTswOYjP2 = this;
					}
					else
					{
						hWCeZzhDnqOVbzPbWQPDoTswOYjP2 = new hWCeZzhDnqOVbzPbWQPDoTswOYjP(0);
						hWCeZzhDnqOVbzPbWQPDoTswOYjP2.CczaYlnseUbUTdjCsvfJODDqiyBJA = CczaYlnseUbUTdjCsvfJODDqiyBJA;
					}
					hWCeZzhDnqOVbzPbWQPDoTswOYjP2.jaAPtdDZVjSewmSpEQHUVTDWmdMe = hpUyncVoVzTFdlWvmndteWjfpZbH;
					return hWCeZzhDnqOVbzPbWQPDoTswOYjP2;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
				}
			}

			private sealed class oYChKaIWtgHrwqtBILIFZAVlCDTbA : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
			{
				private int RvpBpdPcgWmQOxxqsHDAmsEXYlmn;

				private ControllerPollingInfo TqICtVUvzQmORwJkQkUdnYVVDvVj;

				private int FLmGlmdbJxKrvXXWVeLdizRNotFB;

				private int TtVexcYDjhjCNjYuKJyCXDXZGSeQ;

				public int EMGoYGSbLTRVFesKpOqgKgHAXJYf;

				public PollingHelper scsYMnphlRspIhgTIaxxLjfpRvEk;

				private IEnumerator<ControllerPollingInfo> VWxeherpxczDuIYnJGafeXkBIimn;

				ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
				{
					[DebuggerHidden]
					get
					{
						return TqICtVUvzQmORwJkQkUdnYVVDvVj;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return TqICtVUvzQmORwJkQkUdnYVVDvVj;
					}
				}

				[DebuggerHidden]
				public oYChKaIWtgHrwqtBILIFZAVlCDTbA(int P_0)
				{
					RvpBpdPcgWmQOxxqsHDAmsEXYlmn = P_0;
					FLmGlmdbJxKrvXXWVeLdizRNotFB = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					int rvpBpdPcgWmQOxxqsHDAmsEXYlmn = RvpBpdPcgWmQOxxqsHDAmsEXYlmn;
					if (rvpBpdPcgWmQOxxqsHDAmsEXYlmn == -3 || rvpBpdPcgWmQOxxqsHDAmsEXYlmn == 1)
					{
						try
						{
						}
						finally
						{
							kitgaXVyaCuIdjdLGLnRohtLDIaP();
						}
					}
				}

				private bool MoveNext()
				{
					try
					{
						int rvpBpdPcgWmQOxxqsHDAmsEXYlmn = RvpBpdPcgWmQOxxqsHDAmsEXYlmn;
						PollingHelper pollingHelper = scsYMnphlRspIhgTIaxxLjfpRvEk;
						switch (rvpBpdPcgWmQOxxqsHDAmsEXYlmn)
						{
						default:
							return false;
						case 0:
						{
							RvpBpdPcgWmQOxxqsHDAmsEXYlmn = -1;
							if (TtVexcYDjhjCNjYuKJyCXDXZGSeQ < 0)
							{
								return false;
							}
							Joystick joystick = pollingHelper.RYrOzLdLhDMcyVDdbzlwvAkCWGA.UZODjZPyOKvXiogzadHvXQZXjpbh().ItlmsOroseYUCAODTiImPLXMrYyA(TtVexcYDjhjCNjYuKJyCXDXZGSeQ);
							if (joystick == null)
							{
								return false;
							}
							VWxeherpxczDuIYnJGafeXkBIimn = joystick.PollForAllElementsDown().GetEnumerator();
							RvpBpdPcgWmQOxxqsHDAmsEXYlmn = -3;
							break;
						}
						case 1:
							RvpBpdPcgWmQOxxqsHDAmsEXYlmn = -3;
							break;
						}
						if (VWxeherpxczDuIYnJGafeXkBIimn.MoveNext())
						{
							ControllerPollingInfo current = VWxeherpxczDuIYnJGafeXkBIimn.Current;
							ControllerPollingInfo tqICtVUvzQmORwJkQkUdnYVVDvVj = new ControllerPollingInfo(current);
							tqICtVUvzQmORwJkQkUdnYVVDvVj.haeCbWiQSPlfWqsFZDTLoULYjVYq(pollingHelper.omDgqMdNPYOabeAlYvYukkvWREGe.CgPagdlzMlCQxkbRTPOoePMzAXof);
							TqICtVUvzQmORwJkQkUdnYVVDvVj = tqICtVUvzQmORwJkQkUdnYVVDvVj;
							RvpBpdPcgWmQOxxqsHDAmsEXYlmn = 1;
							return true;
						}
						kitgaXVyaCuIdjdLGLnRohtLDIaP();
						VWxeherpxczDuIYnJGafeXkBIimn = null;
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

				private void kitgaXVyaCuIdjdLGLnRohtLDIaP()
				{
					RvpBpdPcgWmQOxxqsHDAmsEXYlmn = -1;
					if (VWxeherpxczDuIYnJGafeXkBIimn != null)
					{
						VWxeherpxczDuIYnJGafeXkBIimn.Dispose();
					}
				}

				[DebuggerHidden]
				void IEnumerator.Reset()
				{
					throw new NotSupportedException();
				}

				[DebuggerHidden]
				IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
				{
					oYChKaIWtgHrwqtBILIFZAVlCDTbA oYChKaIWtgHrwqtBILIFZAVlCDTbA2;
					if (RvpBpdPcgWmQOxxqsHDAmsEXYlmn == -2 && FLmGlmdbJxKrvXXWVeLdizRNotFB == Environment.CurrentManagedThreadId)
					{
						RvpBpdPcgWmQOxxqsHDAmsEXYlmn = 0;
						oYChKaIWtgHrwqtBILIFZAVlCDTbA2 = this;
					}
					else
					{
						oYChKaIWtgHrwqtBILIFZAVlCDTbA2 = new oYChKaIWtgHrwqtBILIFZAVlCDTbA(0);
						oYChKaIWtgHrwqtBILIFZAVlCDTbA2.scsYMnphlRspIhgTIaxxLjfpRvEk = scsYMnphlRspIhgTIaxxLjfpRvEk;
					}
					oYChKaIWtgHrwqtBILIFZAVlCDTbA2.TtVexcYDjhjCNjYuKJyCXDXZGSeQ = EMGoYGSbLTRVFesKpOqgKgHAXJYf;
					return oYChKaIWtgHrwqtBILIFZAVlCDTbA2;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
				}
			}

			private readonly Player omDgqMdNPYOabeAlYvYukkvWREGe;

			private readonly ControllerHelper RYrOzLdLhDMcyVDdbzlwvAkCWGA;

			private readonly int rCJotBZWwyeUvArrkFPeiPyJcdeW;

			internal PollingHelper(Player P_0, ControllerHelper P_1)
			{
				rCJotBZWwyeUvArrkFPeiPyJcdeW = ReInput.id;
				omDgqMdNPYOabeAlYvYukkvWREGe = P_0;
				RYrOzLdLhDMcyVDdbzlwvAkCWGA = P_1;
			}

			public ControllerPollingInfo PollControllerForFirstElement(ControllerType controllerType, int controllerId)
			{
				if (ReInput._id != rCJotBZWwyeUvArrkFPeiPyJcdeW)
				{
					ReInput.CheckInitialized(rCJotBZWwyeUvArrkFPeiPyJcdeW);
					return ControllerPollingInfo.wybtSxBKyoFevDSBzxAFgDtcKhkHA();
				}
				return controllerType switch
				{
					ControllerType.Keyboard => uwCKAXyLhCahldUjOugYwEPIrlPt(), 
					ControllerType.Joystick => CIrwiZTsgCLdRNVkcYHpUyoUoOuI(controllerId), 
					ControllerType.Mouse => QKQEeWGJjBDfPqNRqyJpPnPiThVoA(), 
					ControllerType.Custom => aJyYDRROsiDnFOnerdWgRhnucWRi(controllerId), 
					_ => throw new NotImplementedException(), 
				};
			}

			public ControllerPollingInfo PollControllerForFirstElementDown(ControllerType controllerType, int controllerId)
			{
				if (ReInput._id != rCJotBZWwyeUvArrkFPeiPyJcdeW)
				{
					ReInput.CheckInitialized(rCJotBZWwyeUvArrkFPeiPyJcdeW);
					return ControllerPollingInfo.wybtSxBKyoFevDSBzxAFgDtcKhkHA();
				}
				return controllerType switch
				{
					ControllerType.Keyboard => IuECksaOgipCAKiIzmcnDGdPHjXGA(), 
					ControllerType.Joystick => MQYVuBjWLYYDLKBQWUvMMYAxOEJA(controllerId), 
					ControllerType.Mouse => tkVkWkJmHaxtcbYWqMbiXXBuefEI(), 
					ControllerType.Custom => gKpkHARIKYGrgdUEBhuxRGAUNvleb(controllerId), 
					_ => throw new NotImplementedException(), 
				};
			}

			public ControllerPollingInfo PollControllerForFirstButton(ControllerType controllerType, int controllerId)
			{
				if (ReInput._id != rCJotBZWwyeUvArrkFPeiPyJcdeW)
				{
					ReInput.CheckInitialized(rCJotBZWwyeUvArrkFPeiPyJcdeW);
					return ControllerPollingInfo.wybtSxBKyoFevDSBzxAFgDtcKhkHA();
				}
				return controllerType switch
				{
					ControllerType.Keyboard => uwCKAXyLhCahldUjOugYwEPIrlPt(), 
					ControllerType.Joystick => YcMVBokKgvciPkFZLIxWGbYGsKYT(controllerId), 
					ControllerType.Mouse => nXFnrYLqlTPsQHjTuvlIjHQcBpwk(), 
					ControllerType.Custom => GJvEROkFxVwyKKIteijtajaqjARd(controllerId), 
					_ => throw new NotImplementedException(), 
				};
			}

			public ControllerPollingInfo PollControllerForFirstButtonDown(ControllerType controllerType, int controllerId)
			{
				if (ReInput._id != rCJotBZWwyeUvArrkFPeiPyJcdeW)
				{
					ReInput.CheckInitialized(rCJotBZWwyeUvArrkFPeiPyJcdeW);
					return ControllerPollingInfo.wybtSxBKyoFevDSBzxAFgDtcKhkHA();
				}
				return controllerType switch
				{
					ControllerType.Keyboard => IuECksaOgipCAKiIzmcnDGdPHjXGA(), 
					ControllerType.Joystick => YZilPFCrDwEIAoqYTKFWcppQfJeZ(controllerId), 
					ControllerType.Mouse => qiMlYJgCFOVperkjRxAKzmoywrzI(), 
					ControllerType.Custom => FTkSbVEPhSvMXtlBzFKJksViVENQA(controllerId), 
					_ => throw new NotImplementedException(), 
				};
			}

			public ControllerPollingInfo PollControllerForFirstAxis(ControllerType controllerType, int controllerId)
			{
				if (ReInput._id != rCJotBZWwyeUvArrkFPeiPyJcdeW)
				{
					ReInput.CheckInitialized(rCJotBZWwyeUvArrkFPeiPyJcdeW);
					return ControllerPollingInfo.wybtSxBKyoFevDSBzxAFgDtcKhkHA();
				}
				return controllerType switch
				{
					ControllerType.Keyboard => ControllerPollingInfo.wybtSxBKyoFevDSBzxAFgDtcKhkHA(), 
					ControllerType.Joystick => aQPqlEEQbklOjDjrlMkCLCDyIPYF(controllerId), 
					ControllerType.Mouse => eFASpiTrmzDSBLcZUrLVNgfYxRgr(), 
					ControllerType.Custom => vFfrbZBCMgMAbSNrlQjdNDwnsRQj(controllerId), 
					_ => throw new NotImplementedException(), 
				};
			}

			public IEnumerable<ControllerPollingInfo> PollControllerForAllElements(ControllerType controllerType, int controllerId)
			{
				if (ReInput._id != rCJotBZWwyeUvArrkFPeiPyJcdeW)
				{
					ReInput.CheckInitialized(rCJotBZWwyeUvArrkFPeiPyJcdeW);
					return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
				}
				return controllerType switch
				{
					ControllerType.Keyboard => jdsaFCcusjjwOBpcaIOYAMCMdnGI(), 
					ControllerType.Joystick => JwricBPftLvDtmgFAiZyAifTasnLA(controllerId), 
					ControllerType.Mouse => gHBvEbiAyRZiNInQzVWnwyVlgLaD(), 
					ControllerType.Custom => gWyTIkGHybTxqUhuXpJTGqgMpndp(controllerId), 
					_ => throw new NotImplementedException(), 
				};
			}

			public IEnumerable<ControllerPollingInfo> PollControllerForAllElementsDown(ControllerType controllerType, int controllerId)
			{
				if (ReInput._id != rCJotBZWwyeUvArrkFPeiPyJcdeW)
				{
					ReInput.CheckInitialized(rCJotBZWwyeUvArrkFPeiPyJcdeW);
					return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
				}
				return controllerType switch
				{
					ControllerType.Keyboard => WFxAdWnGMnipQMCjieGobRwVhYUm(), 
					ControllerType.Joystick => bShDkyQuXJgWzIJuXMHMQClesxum(controllerId), 
					ControllerType.Mouse => mdJTiDsmvsWVJfsfhLtKQKqKpiLf(), 
					ControllerType.Custom => iWSUXiuOANUGbQREjFfjcxLxtjpPA(controllerId), 
					_ => throw new NotImplementedException(), 
				};
			}

			public IEnumerable<ControllerPollingInfo> PollControllerForAllButtons(ControllerType controllerType, int controllerId)
			{
				if (ReInput._id != rCJotBZWwyeUvArrkFPeiPyJcdeW)
				{
					ReInput.CheckInitialized(rCJotBZWwyeUvArrkFPeiPyJcdeW);
					return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
				}
				return controllerType switch
				{
					ControllerType.Keyboard => jdsaFCcusjjwOBpcaIOYAMCMdnGI(), 
					ControllerType.Joystick => scceBKUhiVLIjYGfjosACsMMqLQt(controllerId), 
					ControllerType.Mouse => rGVKqFPjZhPDgZMVkdHDCXNgrheIA(), 
					ControllerType.Custom => xyJmniarqqSrqRhpRiIYbQwysSXC(controllerId), 
					_ => throw new NotImplementedException(), 
				};
			}

			public IEnumerable<ControllerPollingInfo> PollControllerForAllButtonsDown(ControllerType controllerType, int controllerId)
			{
				if (ReInput._id != rCJotBZWwyeUvArrkFPeiPyJcdeW)
				{
					ReInput.CheckInitialized(rCJotBZWwyeUvArrkFPeiPyJcdeW);
					return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
				}
				return controllerType switch
				{
					ControllerType.Keyboard => WFxAdWnGMnipQMCjieGobRwVhYUm(), 
					ControllerType.Joystick => ZlYebtacnKmzFlmtJpuPPiJwjOIAb(controllerId), 
					ControllerType.Mouse => EwlNsuyCjyZloIuqLKhiXioweRJS(), 
					ControllerType.Custom => iKgeezZCLRBINBKwqcGdiOGLSRPV(controllerId), 
					_ => throw new NotImplementedException(), 
				};
			}

			public IEnumerable<ControllerPollingInfo> PollControllerForAllAxes(ControllerType controllerType, int controllerId)
			{
				if (ReInput._id != rCJotBZWwyeUvArrkFPeiPyJcdeW)
				{
					ReInput.CheckInitialized(rCJotBZWwyeUvArrkFPeiPyJcdeW);
					return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
				}
				return controllerType switch
				{
					ControllerType.Keyboard => new List<ControllerPollingInfo>(), 
					ControllerType.Joystick => pLWIECQlXFFjnXJRoBJbEYgMbNeG(controllerId), 
					ControllerType.Mouse => HZluYtrrnuAPSnbWUrMCzrTGkytE(), 
					ControllerType.Custom => YOmxPQPjGOxtDOSopzKoeHZHKPyr(controllerId), 
					_ => throw new NotImplementedException(), 
				};
			}

			public ControllerPollingInfo PollAllControllersOfTypeForFirstElement(ControllerType controllerType)
			{
				if (ReInput._id != rCJotBZWwyeUvArrkFPeiPyJcdeW)
				{
					ReInput.CheckInitialized(rCJotBZWwyeUvArrkFPeiPyJcdeW);
					return ControllerPollingInfo.wybtSxBKyoFevDSBzxAFgDtcKhkHA();
				}
				return controllerType switch
				{
					ControllerType.Keyboard => uwCKAXyLhCahldUjOugYwEPIrlPt(), 
					ControllerType.Joystick => KBXDBnDLHQrEXgySkzqlZJhzzCTw(), 
					ControllerType.Mouse => QKQEeWGJjBDfPqNRqyJpPnPiThVoA(), 
					ControllerType.Custom => eqOgAlKsgoGXcQsyGJcWFwGTveQv(), 
					_ => throw new NotImplementedException(), 
				};
			}

			public ControllerPollingInfo PollAllControllersOfTypeForFirstButton(ControllerType controllerType)
			{
				if (ReInput._id != rCJotBZWwyeUvArrkFPeiPyJcdeW)
				{
					ReInput.CheckInitialized(rCJotBZWwyeUvArrkFPeiPyJcdeW);
					return ControllerPollingInfo.wybtSxBKyoFevDSBzxAFgDtcKhkHA();
				}
				return controllerType switch
				{
					ControllerType.Keyboard => uwCKAXyLhCahldUjOugYwEPIrlPt(), 
					ControllerType.Joystick => MZuGJhMIhXBSVKdfxkoEOwWJqwYGA(), 
					ControllerType.Mouse => nXFnrYLqlTPsQHjTuvlIjHQcBpwk(), 
					ControllerType.Custom => JnYpTFFPlBnouCKQxCRaPSCtnKbk(), 
					_ => throw new NotImplementedException(), 
				};
			}

			public ControllerPollingInfo PollAllControllersOfTypeForFirstButtonDown(ControllerType controllerType)
			{
				if (ReInput._id != rCJotBZWwyeUvArrkFPeiPyJcdeW)
				{
					ReInput.CheckInitialized(rCJotBZWwyeUvArrkFPeiPyJcdeW);
					return ControllerPollingInfo.wybtSxBKyoFevDSBzxAFgDtcKhkHA();
				}
				return controllerType switch
				{
					ControllerType.Keyboard => IuECksaOgipCAKiIzmcnDGdPHjXGA(), 
					ControllerType.Joystick => dDqItzGmaNTvLXNjXMFnwZEAfDux(), 
					ControllerType.Mouse => qiMlYJgCFOVperkjRxAKzmoywrzI(), 
					ControllerType.Custom => gqqDwFwbbFBxJMsGJiJCFQGkBzEq(), 
					_ => throw new NotImplementedException(), 
				};
			}

			public ControllerPollingInfo PollAllControllersOfTypeForFirstAxis(ControllerType controllerType)
			{
				if (ReInput._id != rCJotBZWwyeUvArrkFPeiPyJcdeW)
				{
					ReInput.CheckInitialized(rCJotBZWwyeUvArrkFPeiPyJcdeW);
					return ControllerPollingInfo.wybtSxBKyoFevDSBzxAFgDtcKhkHA();
				}
				return controllerType switch
				{
					ControllerType.Keyboard => ControllerPollingInfo.wybtSxBKyoFevDSBzxAFgDtcKhkHA(), 
					ControllerType.Joystick => xKfefSmJggVEwzKVhARNuEFxnmam(), 
					ControllerType.Mouse => eFASpiTrmzDSBLcZUrLVNgfYxRgr(), 
					ControllerType.Custom => fbwCgkKTYyFdajcLBghgcbhGgkaAd(), 
					_ => throw new NotImplementedException(), 
				};
			}

			public IEnumerable<ControllerPollingInfo> PollAllControllersOfTypeForAllElements(ControllerType controllerType)
			{
				if (ReInput._id != rCJotBZWwyeUvArrkFPeiPyJcdeW)
				{
					ReInput.CheckInitialized(rCJotBZWwyeUvArrkFPeiPyJcdeW);
					return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
				}
				return controllerType switch
				{
					ControllerType.Keyboard => jdsaFCcusjjwOBpcaIOYAMCMdnGI(), 
					ControllerType.Joystick => qDOvJNjmhFVfAWkmeMxLOJwEGsYC(), 
					ControllerType.Mouse => gHBvEbiAyRZiNInQzVWnwyVlgLaD(), 
					ControllerType.Custom => gWpTHKLZLCUEzKNpBkYztIXqqpME(), 
					_ => throw new NotImplementedException(), 
				};
			}

			public IEnumerable<ControllerPollingInfo> PollAllControllersOfTypeForAllElementsDown(ControllerType controllerType)
			{
				if (ReInput._id != rCJotBZWwyeUvArrkFPeiPyJcdeW)
				{
					ReInput.CheckInitialized(rCJotBZWwyeUvArrkFPeiPyJcdeW);
					return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
				}
				return controllerType switch
				{
					ControllerType.Keyboard => WFxAdWnGMnipQMCjieGobRwVhYUm(), 
					ControllerType.Joystick => OQmNxeRqQAIkepyeJCsichNpKtYv(), 
					ControllerType.Mouse => mdJTiDsmvsWVJfsfhLtKQKqKpiLf(), 
					ControllerType.Custom => ysKPmpqSDrClJIyGWHxohQEpdXem(), 
					_ => throw new NotImplementedException(), 
				};
			}

			public IEnumerable<ControllerPollingInfo> PollAllControllersOfTypeForAllButtons(ControllerType controllerType)
			{
				if (ReInput._id != rCJotBZWwyeUvArrkFPeiPyJcdeW)
				{
					ReInput.CheckInitialized(rCJotBZWwyeUvArrkFPeiPyJcdeW);
					return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
				}
				return controllerType switch
				{
					ControllerType.Keyboard => jdsaFCcusjjwOBpcaIOYAMCMdnGI(), 
					ControllerType.Joystick => ohlKiJEOfZifaIRVDPjIJYlSbwafb(), 
					ControllerType.Mouse => rGVKqFPjZhPDgZMVkdHDCXNgrheIA(), 
					ControllerType.Custom => TKgTmOBFDVNUQrfGKRwyLPRMeOUg(), 
					_ => throw new NotImplementedException(), 
				};
			}

			public IEnumerable<ControllerPollingInfo> PollAllControllersOfTypeForAllButtonsDown(ControllerType controllerType)
			{
				if (ReInput._id != rCJotBZWwyeUvArrkFPeiPyJcdeW)
				{
					ReInput.CheckInitialized(rCJotBZWwyeUvArrkFPeiPyJcdeW);
					return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
				}
				return controllerType switch
				{
					ControllerType.Keyboard => WFxAdWnGMnipQMCjieGobRwVhYUm(), 
					ControllerType.Joystick => SKqyKpYGlWPpDAosshotdfEOMacP(), 
					ControllerType.Mouse => EwlNsuyCjyZloIuqLKhiXioweRJS(), 
					ControllerType.Custom => wVGRLDxQHNhFCvZradEasKmQkAOU(), 
					_ => throw new NotImplementedException(), 
				};
			}

			public IEnumerable<ControllerPollingInfo> PollAllControllersOfTypeForAllAxes(ControllerType controllerType)
			{
				if (ReInput._id != rCJotBZWwyeUvArrkFPeiPyJcdeW)
				{
					ReInput.CheckInitialized(rCJotBZWwyeUvArrkFPeiPyJcdeW);
					return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
				}
				return controllerType switch
				{
					ControllerType.Keyboard => new List<ControllerPollingInfo>(), 
					ControllerType.Joystick => JYVlNfpXQGvzdcGlbBDSgJlvPKWk(), 
					ControllerType.Mouse => HZluYtrrnuAPSnbWUrMCzrTGkytE(), 
					ControllerType.Custom => aZtIkVAshlZLmHkWgIySTtJObsYH(), 
					_ => throw new NotImplementedException(), 
				};
			}

			private ControllerPollingInfo CIrwiZTsgCLdRNVkcYHpUyoUoOuI(int P_0)
			{
				if (P_0 < 0)
				{
					return ControllerPollingInfo.wybtSxBKyoFevDSBzxAFgDtcKhkHA();
				}
				Joystick joystick = RYrOzLdLhDMcyVDdbzlwvAkCWGA.UZODjZPyOKvXiogzadHvXQZXjpbh().ItlmsOroseYUCAODTiImPLXMrYyA(P_0);
				if (joystick == null)
				{
					return ControllerPollingInfo.wybtSxBKyoFevDSBzxAFgDtcKhkHA();
				}
				ControllerPollingInfo result = joystick.PollForFirstElement();
				if (result.success)
				{
					result.haeCbWiQSPlfWqsFZDTLoULYjVYq(omDgqMdNPYOabeAlYvYukkvWREGe.CgPagdlzMlCQxkbRTPOoePMzAXof);
				}
				return result;
			}

			private ControllerPollingInfo MQYVuBjWLYYDLKBQWUvMMYAxOEJA(int P_0)
			{
				if (P_0 < 0)
				{
					return ControllerPollingInfo.wybtSxBKyoFevDSBzxAFgDtcKhkHA();
				}
				Joystick joystick = RYrOzLdLhDMcyVDdbzlwvAkCWGA.UZODjZPyOKvXiogzadHvXQZXjpbh().ItlmsOroseYUCAODTiImPLXMrYyA(P_0);
				if (joystick == null)
				{
					return ControllerPollingInfo.wybtSxBKyoFevDSBzxAFgDtcKhkHA();
				}
				ControllerPollingInfo result = joystick.PollForFirstElementDown();
				if (result.success)
				{
					result.haeCbWiQSPlfWqsFZDTLoULYjVYq(omDgqMdNPYOabeAlYvYukkvWREGe.CgPagdlzMlCQxkbRTPOoePMzAXof);
				}
				return result;
			}

			private ControllerPollingInfo YcMVBokKgvciPkFZLIxWGbYGsKYT(int P_0)
			{
				if (P_0 < 0)
				{
					return ControllerPollingInfo.wybtSxBKyoFevDSBzxAFgDtcKhkHA();
				}
				Joystick joystick = RYrOzLdLhDMcyVDdbzlwvAkCWGA.UZODjZPyOKvXiogzadHvXQZXjpbh().ItlmsOroseYUCAODTiImPLXMrYyA(P_0);
				if (joystick == null)
				{
					return ControllerPollingInfo.wybtSxBKyoFevDSBzxAFgDtcKhkHA();
				}
				ControllerPollingInfo result = joystick.PollForFirstButton();
				if (result.success)
				{
					result.haeCbWiQSPlfWqsFZDTLoULYjVYq(omDgqMdNPYOabeAlYvYukkvWREGe.CgPagdlzMlCQxkbRTPOoePMzAXof);
				}
				return result;
			}

			private ControllerPollingInfo YZilPFCrDwEIAoqYTKFWcppQfJeZ(int P_0)
			{
				if (P_0 < 0)
				{
					return ControllerPollingInfo.wybtSxBKyoFevDSBzxAFgDtcKhkHA();
				}
				Joystick joystick = RYrOzLdLhDMcyVDdbzlwvAkCWGA.UZODjZPyOKvXiogzadHvXQZXjpbh().ItlmsOroseYUCAODTiImPLXMrYyA(P_0);
				if (joystick == null)
				{
					return ControllerPollingInfo.wybtSxBKyoFevDSBzxAFgDtcKhkHA();
				}
				ControllerPollingInfo result = joystick.PollForFirstButtonDown();
				if (result.success)
				{
					result.haeCbWiQSPlfWqsFZDTLoULYjVYq(omDgqMdNPYOabeAlYvYukkvWREGe.CgPagdlzMlCQxkbRTPOoePMzAXof);
				}
				return result;
			}

			private ControllerPollingInfo aQPqlEEQbklOjDjrlMkCLCDyIPYF(int P_0)
			{
				if (P_0 < 0)
				{
					return ControllerPollingInfo.wybtSxBKyoFevDSBzxAFgDtcKhkHA();
				}
				Joystick joystick = RYrOzLdLhDMcyVDdbzlwvAkCWGA.UZODjZPyOKvXiogzadHvXQZXjpbh().ItlmsOroseYUCAODTiImPLXMrYyA(P_0);
				if (joystick == null)
				{
					return ControllerPollingInfo.wybtSxBKyoFevDSBzxAFgDtcKhkHA();
				}
				ControllerPollingInfo result = joystick.PollForFirstAxis();
				if (result.success)
				{
					result.haeCbWiQSPlfWqsFZDTLoULYjVYq(omDgqMdNPYOabeAlYvYukkvWREGe.CgPagdlzMlCQxkbRTPOoePMzAXof);
				}
				return result;
			}

			[IteratorStateMachine(typeof(hWCeZzhDnqOVbzPbWQPDoTswOYjP))]
			private IEnumerable<ControllerPollingInfo> JwricBPftLvDtmgFAiZyAifTasnLA(int P_0)
			{
				return new hWCeZzhDnqOVbzPbWQPDoTswOYjP(-2)
				{
					CczaYlnseUbUTdjCsvfJODDqiyBJA = this,
					hpUyncVoVzTFdlWvmndteWjfpZbH = P_0
				};
			}

			[IteratorStateMachine(typeof(oYChKaIWtgHrwqtBILIFZAVlCDTbA))]
			private IEnumerable<ControllerPollingInfo> bShDkyQuXJgWzIJuXMHMQClesxum(int P_0)
			{
				return new oYChKaIWtgHrwqtBILIFZAVlCDTbA(-2)
				{
					scsYMnphlRspIhgTIaxxLjfpRvEk = this,
					EMGoYGSbLTRVFesKpOqgKgHAXJYf = P_0
				};
			}

			[IteratorStateMachine(typeof(qgacGOeOZSRJcUbbIVucbhouZDNSA))]
			private IEnumerable<ControllerPollingInfo> scceBKUhiVLIjYGfjosACsMMqLQt(int P_0)
			{
				return new qgacGOeOZSRJcUbbIVucbhouZDNSA(-2)
				{
					dEEzQtemViEwMaCcUmGGhGfJskeB = this,
					LLoXuaqNSoWTCyTnzPaFzDcWhTOy = P_0
				};
			}

			[IteratorStateMachine(typeof(RahVTJgxWIIylYIJKSqYFFjJbXGj))]
			private IEnumerable<ControllerPollingInfo> ZlYebtacnKmzFlmtJpuPPiJwjOIAb(int P_0)
			{
				return new RahVTJgxWIIylYIJKSqYFFjJbXGj(-2)
				{
					bDhAQtdXSomYYiUoPqRcMEnNplaab = this,
					zmQvOBRZKCbbqGksSKcvXexgpDIl = P_0
				};
			}

			[IteratorStateMachine(typeof(vaqYJEsARRIJfyEZTBLuOxBzBYAC))]
			private IEnumerable<ControllerPollingInfo> pLWIECQlXFFjnXJRoBJbEYgMbNeG(int P_0)
			{
				return new vaqYJEsARRIJfyEZTBLuOxBzBYAC(-2)
				{
					UuvnORaLpYclvHoBDihLgkypAlSb = this,
					XbUwgEIaNoDvrsYfRnmIJPJKfZCc = P_0
				};
			}

			private ControllerPollingInfo KBXDBnDLHQrEXgySkzqlZJhzzCTw()
			{
				IList<Joystick> list = RYrOzLdLhDMcyVDdbzlwvAkCWGA.UZODjZPyOKvXiogzadHvXQZXjpbh().cmeeIbUCxjHUqdNCBHHJgoMnHEVA();
				int count = list.Count;
				for (int i = 0; i < count; i++)
				{
					ControllerPollingInfo result = list[i].PollForFirstElement();
					if (result.success)
					{
						result.haeCbWiQSPlfWqsFZDTLoULYjVYq(omDgqMdNPYOabeAlYvYukkvWREGe.CgPagdlzMlCQxkbRTPOoePMzAXof);
						return result;
					}
				}
				return ControllerPollingInfo.wybtSxBKyoFevDSBzxAFgDtcKhkHA();
			}

			private ControllerPollingInfo rXTevaLPeSXGtvNZxjTaDilWwDny()
			{
				IList<Joystick> list = RYrOzLdLhDMcyVDdbzlwvAkCWGA.UZODjZPyOKvXiogzadHvXQZXjpbh().cmeeIbUCxjHUqdNCBHHJgoMnHEVA();
				int count = list.Count;
				for (int i = 0; i < count; i++)
				{
					ControllerPollingInfo result = list[i].PollForFirstElementDown();
					if (result.success)
					{
						result.haeCbWiQSPlfWqsFZDTLoULYjVYq(omDgqMdNPYOabeAlYvYukkvWREGe.CgPagdlzMlCQxkbRTPOoePMzAXof);
						return result;
					}
				}
				return ControllerPollingInfo.wybtSxBKyoFevDSBzxAFgDtcKhkHA();
			}

			private ControllerPollingInfo MZuGJhMIhXBSVKdfxkoEOwWJqwYGA()
			{
				IList<Joystick> list = RYrOzLdLhDMcyVDdbzlwvAkCWGA.UZODjZPyOKvXiogzadHvXQZXjpbh().cmeeIbUCxjHUqdNCBHHJgoMnHEVA();
				int count = list.Count;
				for (int i = 0; i < count; i++)
				{
					ControllerPollingInfo result = list[i].PollForFirstButton();
					if (result.success)
					{
						result.haeCbWiQSPlfWqsFZDTLoULYjVYq(omDgqMdNPYOabeAlYvYukkvWREGe.CgPagdlzMlCQxkbRTPOoePMzAXof);
						return result;
					}
				}
				return ControllerPollingInfo.wybtSxBKyoFevDSBzxAFgDtcKhkHA();
			}

			private ControllerPollingInfo dDqItzGmaNTvLXNjXMFnwZEAfDux()
			{
				IList<Joystick> list = RYrOzLdLhDMcyVDdbzlwvAkCWGA.UZODjZPyOKvXiogzadHvXQZXjpbh().cmeeIbUCxjHUqdNCBHHJgoMnHEVA();
				int count = list.Count;
				for (int i = 0; i < count; i++)
				{
					ControllerPollingInfo result = list[i].PollForFirstButtonDown();
					if (result.success)
					{
						result.haeCbWiQSPlfWqsFZDTLoULYjVYq(omDgqMdNPYOabeAlYvYukkvWREGe.CgPagdlzMlCQxkbRTPOoePMzAXof);
						return result;
					}
				}
				return ControllerPollingInfo.wybtSxBKyoFevDSBzxAFgDtcKhkHA();
			}

			private ControllerPollingInfo xKfefSmJggVEwzKVhARNuEFxnmam()
			{
				IList<Joystick> list = RYrOzLdLhDMcyVDdbzlwvAkCWGA.UZODjZPyOKvXiogzadHvXQZXjpbh().cmeeIbUCxjHUqdNCBHHJgoMnHEVA();
				int count = list.Count;
				for (int i = 0; i < count; i++)
				{
					ControllerPollingInfo result = list[i].PollForFirstAxis();
					if (result.success)
					{
						result.haeCbWiQSPlfWqsFZDTLoULYjVYq(omDgqMdNPYOabeAlYvYukkvWREGe.CgPagdlzMlCQxkbRTPOoePMzAXof);
						return result;
					}
				}
				return ControllerPollingInfo.wybtSxBKyoFevDSBzxAFgDtcKhkHA();
			}

			[IteratorStateMachine(typeof(YAGdHiAkmvlFJUzdVBbAmQFfHSitA))]
			private IEnumerable<ControllerPollingInfo> qDOvJNjmhFVfAWkmeMxLOJwEGsYC()
			{
				return new YAGdHiAkmvlFJUzdVBbAmQFfHSitA(-2)
				{
					UkgbjqDyLCUpcsTVxLobGeNDhlQPB = this
				};
			}

			[IteratorStateMachine(typeof(gBwYIWrHBWhMOEhacdHNKEKSefuOA))]
			private IEnumerable<ControllerPollingInfo> OQmNxeRqQAIkepyeJCsichNpKtYv()
			{
				return new gBwYIWrHBWhMOEhacdHNKEKSefuOA(-2)
				{
					eZCYNRxpKDeTkibClcbuQKQQvaHbA = this
				};
			}

			[IteratorStateMachine(typeof(BnRpMmDunfpxeaxtAZSbtulmGNMm))]
			private IEnumerable<ControllerPollingInfo> ohlKiJEOfZifaIRVDPjIJYlSbwafb()
			{
				return new BnRpMmDunfpxeaxtAZSbtulmGNMm(-2)
				{
					iLSVBQKGEKWUBNPQXzcsdJLAPpfS = this
				};
			}

			[IteratorStateMachine(typeof(aCJfJaECpytQREmEvZwAvnWALOLd))]
			private IEnumerable<ControllerPollingInfo> SKqyKpYGlWPpDAosshotdfEOMacP()
			{
				return new aCJfJaECpytQREmEvZwAvnWALOLd(-2)
				{
					qMMCZlFhAtLvmJLMuIMQkSsqvDepA = this
				};
			}

			[IteratorStateMachine(typeof(jmzwnWnzmSTfYaXQCtJFtCCnFqlD))]
			private IEnumerable<ControllerPollingInfo> JYVlNfpXQGvzdcGlbBDSgJlvPKWk()
			{
				return new jmzwnWnzmSTfYaXQCtJFtCCnFqlD(-2)
				{
					WXuxeUiDCJXRvXYiQgfjvJsYhQAe = this
				};
			}

			private ControllerPollingInfo uwCKAXyLhCahldUjOugYwEPIrlPt()
			{
				if (!RYrOzLdLhDMcyVDdbzlwvAkCWGA.TlbyyHkskWZrSZcTJCoiWBTwNtSg)
				{
					return ControllerPollingInfo.wybtSxBKyoFevDSBzxAFgDtcKhkHA();
				}
				return RYrOzLdLhDMcyVDdbzlwvAkCWGA.Keyboard.PollForFirstKey();
			}

			private ControllerPollingInfo IuECksaOgipCAKiIzmcnDGdPHjXGA()
			{
				if (!RYrOzLdLhDMcyVDdbzlwvAkCWGA.TlbyyHkskWZrSZcTJCoiWBTwNtSg)
				{
					return ControllerPollingInfo.wybtSxBKyoFevDSBzxAFgDtcKhkHA();
				}
				return RYrOzLdLhDMcyVDdbzlwvAkCWGA.Keyboard.PollForFirstKeyDown();
			}

			private IEnumerable<ControllerPollingInfo> jdsaFCcusjjwOBpcaIOYAMCMdnGI()
			{
				if (!RYrOzLdLhDMcyVDdbzlwvAkCWGA.TlbyyHkskWZrSZcTJCoiWBTwNtSg)
				{
					return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
				}
				return RYrOzLdLhDMcyVDdbzlwvAkCWGA.Keyboard.PollForAllKeys();
			}

			private IEnumerable<ControllerPollingInfo> WFxAdWnGMnipQMCjieGobRwVhYUm()
			{
				if (!RYrOzLdLhDMcyVDdbzlwvAkCWGA.TlbyyHkskWZrSZcTJCoiWBTwNtSg)
				{
					return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
				}
				return RYrOzLdLhDMcyVDdbzlwvAkCWGA.Keyboard.PollForAllKeysDown();
			}

			private ControllerPollingInfo QKQEeWGJjBDfPqNRqyJpPnPiThVoA()
			{
				if (!RYrOzLdLhDMcyVDdbzlwvAkCWGA.lRGGFcEsxqLxQrnylLUfDadxvkQX)
				{
					return ControllerPollingInfo.wybtSxBKyoFevDSBzxAFgDtcKhkHA();
				}
				return RYrOzLdLhDMcyVDdbzlwvAkCWGA.Mouse.PollForFirstElement();
			}

			private ControllerPollingInfo tkVkWkJmHaxtcbYWqMbiXXBuefEI()
			{
				if (!RYrOzLdLhDMcyVDdbzlwvAkCWGA.lRGGFcEsxqLxQrnylLUfDadxvkQX)
				{
					return ControllerPollingInfo.wybtSxBKyoFevDSBzxAFgDtcKhkHA();
				}
				return RYrOzLdLhDMcyVDdbzlwvAkCWGA.Mouse.PollForFirstElementDown();
			}

			private ControllerPollingInfo nXFnrYLqlTPsQHjTuvlIjHQcBpwk()
			{
				if (!RYrOzLdLhDMcyVDdbzlwvAkCWGA.lRGGFcEsxqLxQrnylLUfDadxvkQX)
				{
					return ControllerPollingInfo.wybtSxBKyoFevDSBzxAFgDtcKhkHA();
				}
				return RYrOzLdLhDMcyVDdbzlwvAkCWGA.Mouse.PollForFirstButton();
			}

			private ControllerPollingInfo qiMlYJgCFOVperkjRxAKzmoywrzI()
			{
				if (!RYrOzLdLhDMcyVDdbzlwvAkCWGA.lRGGFcEsxqLxQrnylLUfDadxvkQX)
				{
					return ControllerPollingInfo.wybtSxBKyoFevDSBzxAFgDtcKhkHA();
				}
				return RYrOzLdLhDMcyVDdbzlwvAkCWGA.Mouse.PollForFirstButtonDown();
			}

			private ControllerPollingInfo eFASpiTrmzDSBLcZUrLVNgfYxRgr()
			{
				if (!RYrOzLdLhDMcyVDdbzlwvAkCWGA.lRGGFcEsxqLxQrnylLUfDadxvkQX)
				{
					return ControllerPollingInfo.wybtSxBKyoFevDSBzxAFgDtcKhkHA();
				}
				return RYrOzLdLhDMcyVDdbzlwvAkCWGA.Mouse.PollForFirstAxis();
			}

			private IEnumerable<ControllerPollingInfo> gHBvEbiAyRZiNInQzVWnwyVlgLaD()
			{
				if (!RYrOzLdLhDMcyVDdbzlwvAkCWGA.lRGGFcEsxqLxQrnylLUfDadxvkQX)
				{
					return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
				}
				return RYrOzLdLhDMcyVDdbzlwvAkCWGA.Mouse.PollForAllElements();
			}

			private IEnumerable<ControllerPollingInfo> mdJTiDsmvsWVJfsfhLtKQKqKpiLf()
			{
				if (!RYrOzLdLhDMcyVDdbzlwvAkCWGA.lRGGFcEsxqLxQrnylLUfDadxvkQX)
				{
					return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
				}
				return RYrOzLdLhDMcyVDdbzlwvAkCWGA.Mouse.PollForAllElementsDown();
			}

			private IEnumerable<ControllerPollingInfo> rGVKqFPjZhPDgZMVkdHDCXNgrheIA()
			{
				if (!RYrOzLdLhDMcyVDdbzlwvAkCWGA.lRGGFcEsxqLxQrnylLUfDadxvkQX)
				{
					return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
				}
				return RYrOzLdLhDMcyVDdbzlwvAkCWGA.Mouse.PollForAllButtons();
			}

			private IEnumerable<ControllerPollingInfo> EwlNsuyCjyZloIuqLKhiXioweRJS()
			{
				if (!RYrOzLdLhDMcyVDdbzlwvAkCWGA.lRGGFcEsxqLxQrnylLUfDadxvkQX)
				{
					return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
				}
				return RYrOzLdLhDMcyVDdbzlwvAkCWGA.Mouse.PollForAllButtonsDown();
			}

			private IEnumerable<ControllerPollingInfo> HZluYtrrnuAPSnbWUrMCzrTGkytE()
			{
				if (!RYrOzLdLhDMcyVDdbzlwvAkCWGA.lRGGFcEsxqLxQrnylLUfDadxvkQX)
				{
					return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
				}
				return RYrOzLdLhDMcyVDdbzlwvAkCWGA.Mouse.PollForAllAxes();
			}

			private ControllerPollingInfo aJyYDRROsiDnFOnerdWgRhnucWRi(int P_0)
			{
				if (P_0 < 0)
				{
					return ControllerPollingInfo.wybtSxBKyoFevDSBzxAFgDtcKhkHA();
				}
				CustomController customController = RYrOzLdLhDMcyVDdbzlwvAkCWGA.QrSKTUzPSjlCKZGLJDqOVrJyplcf().ItlmsOroseYUCAODTiImPLXMrYyA(P_0);
				if (customController == null)
				{
					return ControllerPollingInfo.wybtSxBKyoFevDSBzxAFgDtcKhkHA();
				}
				ControllerPollingInfo result = customController.PollForFirstElement();
				if (result.success)
				{
					result.haeCbWiQSPlfWqsFZDTLoULYjVYq(omDgqMdNPYOabeAlYvYukkvWREGe.CgPagdlzMlCQxkbRTPOoePMzAXof);
				}
				return result;
			}

			private ControllerPollingInfo gKpkHARIKYGrgdUEBhuxRGAUNvleb(int P_0)
			{
				if (P_0 < 0)
				{
					return ControllerPollingInfo.wybtSxBKyoFevDSBzxAFgDtcKhkHA();
				}
				CustomController customController = RYrOzLdLhDMcyVDdbzlwvAkCWGA.QrSKTUzPSjlCKZGLJDqOVrJyplcf().ItlmsOroseYUCAODTiImPLXMrYyA(P_0);
				if (customController == null)
				{
					return ControllerPollingInfo.wybtSxBKyoFevDSBzxAFgDtcKhkHA();
				}
				ControllerPollingInfo result = customController.PollForFirstElementDown();
				if (result.success)
				{
					result.haeCbWiQSPlfWqsFZDTLoULYjVYq(omDgqMdNPYOabeAlYvYukkvWREGe.CgPagdlzMlCQxkbRTPOoePMzAXof);
				}
				return result;
			}

			private ControllerPollingInfo GJvEROkFxVwyKKIteijtajaqjARd(int P_0)
			{
				if (P_0 < 0)
				{
					return ControllerPollingInfo.wybtSxBKyoFevDSBzxAFgDtcKhkHA();
				}
				CustomController customController = RYrOzLdLhDMcyVDdbzlwvAkCWGA.QrSKTUzPSjlCKZGLJDqOVrJyplcf().ItlmsOroseYUCAODTiImPLXMrYyA(P_0);
				if (customController == null)
				{
					return ControllerPollingInfo.wybtSxBKyoFevDSBzxAFgDtcKhkHA();
				}
				ControllerPollingInfo result = customController.PollForFirstButton();
				if (result.success)
				{
					result.haeCbWiQSPlfWqsFZDTLoULYjVYq(omDgqMdNPYOabeAlYvYukkvWREGe.CgPagdlzMlCQxkbRTPOoePMzAXof);
				}
				return result;
			}

			private ControllerPollingInfo FTkSbVEPhSvMXtlBzFKJksViVENQA(int P_0)
			{
				if (P_0 < 0)
				{
					return ControllerPollingInfo.wybtSxBKyoFevDSBzxAFgDtcKhkHA();
				}
				CustomController customController = RYrOzLdLhDMcyVDdbzlwvAkCWGA.QrSKTUzPSjlCKZGLJDqOVrJyplcf().ItlmsOroseYUCAODTiImPLXMrYyA(P_0);
				if (customController == null)
				{
					return ControllerPollingInfo.wybtSxBKyoFevDSBzxAFgDtcKhkHA();
				}
				ControllerPollingInfo result = customController.PollForFirstButtonDown();
				if (result.success)
				{
					result.haeCbWiQSPlfWqsFZDTLoULYjVYq(omDgqMdNPYOabeAlYvYukkvWREGe.CgPagdlzMlCQxkbRTPOoePMzAXof);
				}
				return result;
			}

			private ControllerPollingInfo vFfrbZBCMgMAbSNrlQjdNDwnsRQj(int P_0)
			{
				if (P_0 < 0)
				{
					return ControllerPollingInfo.wybtSxBKyoFevDSBzxAFgDtcKhkHA();
				}
				CustomController customController = RYrOzLdLhDMcyVDdbzlwvAkCWGA.QrSKTUzPSjlCKZGLJDqOVrJyplcf().ItlmsOroseYUCAODTiImPLXMrYyA(P_0);
				if (customController == null)
				{
					return ControllerPollingInfo.wybtSxBKyoFevDSBzxAFgDtcKhkHA();
				}
				ControllerPollingInfo result = customController.PollForFirstAxis();
				if (result.success)
				{
					result.haeCbWiQSPlfWqsFZDTLoULYjVYq(omDgqMdNPYOabeAlYvYukkvWREGe.CgPagdlzMlCQxkbRTPOoePMzAXof);
				}
				return result;
			}

			[IteratorStateMachine(typeof(ImAsSUxIhuWACTcXeDLFGOWhKhOgA))]
			private IEnumerable<ControllerPollingInfo> gWyTIkGHybTxqUhuXpJTGqgMpndp(int P_0)
			{
				return new ImAsSUxIhuWACTcXeDLFGOWhKhOgA(-2)
				{
					IrezdTkIOYFDlIigZcOADTGkgxpKA = this,
					wsnAOHhmNSdxxOqfWzQFbnDbuOHwA = P_0
				};
			}

			[IteratorStateMachine(typeof(LVGBUXNETyxyYbkChEqgFYqcdTc))]
			private IEnumerable<ControllerPollingInfo> iWSUXiuOANUGbQREjFfjcxLxtjpPA(int P_0)
			{
				return new LVGBUXNETyxyYbkChEqgFYqcdTc(-2)
				{
					YzcUHwDEsydATVAKlObQUOgEgZWQ = this,
					PCJHDOMjDVKoaaSAAiuraqEDbHUNA = P_0
				};
			}

			[IteratorStateMachine(typeof(pJkDTFwtwBANTlpXrpepdBPvGcmaA))]
			private IEnumerable<ControllerPollingInfo> xyJmniarqqSrqRhpRiIYbQwysSXC(int P_0)
			{
				return new pJkDTFwtwBANTlpXrpepdBPvGcmaA(-2)
				{
					VwELjzpSYWDIBDXEGKFAKaACteHW = this,
					RnLdLyAzbJnwmhTRySsZkCGYGcfab = P_0
				};
			}

			[IteratorStateMachine(typeof(UZybrTQuWwATJOsErATrfbsLNuw))]
			private IEnumerable<ControllerPollingInfo> iKgeezZCLRBINBKwqcGdiOGLSRPV(int P_0)
			{
				return new UZybrTQuWwATJOsErATrfbsLNuw(-2)
				{
					MwpENrIJoNSlwUIsQYCCJmiLOqavA = this,
					ImesGcdCWlahdrZncVzcPcLcvrnL = P_0
				};
			}

			[IteratorStateMachine(typeof(FkacEtvzcktjBxDvGtMmVuSeXkoc))]
			private IEnumerable<ControllerPollingInfo> YOmxPQPjGOxtDOSopzKoeHZHKPyr(int P_0)
			{
				return new FkacEtvzcktjBxDvGtMmVuSeXkoc(-2)
				{
					nPFICexkYuPvOYlEkidcTqgSGuoF = this,
					hwregSfvEMQSMvNFuCPjGdnXXmdIA = P_0
				};
			}

			private ControllerPollingInfo eqOgAlKsgoGXcQsyGJcWFwGTveQv()
			{
				IList<CustomController> list = RYrOzLdLhDMcyVDdbzlwvAkCWGA.QrSKTUzPSjlCKZGLJDqOVrJyplcf().cmeeIbUCxjHUqdNCBHHJgoMnHEVA();
				int count = list.Count;
				for (int i = 0; i < count; i++)
				{
					ControllerPollingInfo result = list[i].PollForFirstElement();
					if (result.success)
					{
						result.haeCbWiQSPlfWqsFZDTLoULYjVYq(omDgqMdNPYOabeAlYvYukkvWREGe.CgPagdlzMlCQxkbRTPOoePMzAXof);
						return result;
					}
				}
				return ControllerPollingInfo.wybtSxBKyoFevDSBzxAFgDtcKhkHA();
			}

			private ControllerPollingInfo WipIdLskGHzDODDTbZWgQyOKKYGN()
			{
				IList<CustomController> list = RYrOzLdLhDMcyVDdbzlwvAkCWGA.QrSKTUzPSjlCKZGLJDqOVrJyplcf().cmeeIbUCxjHUqdNCBHHJgoMnHEVA();
				int count = list.Count;
				for (int i = 0; i < count; i++)
				{
					ControllerPollingInfo result = list[i].PollForFirstElementDown();
					if (result.success)
					{
						result.haeCbWiQSPlfWqsFZDTLoULYjVYq(omDgqMdNPYOabeAlYvYukkvWREGe.CgPagdlzMlCQxkbRTPOoePMzAXof);
						return result;
					}
				}
				return ControllerPollingInfo.wybtSxBKyoFevDSBzxAFgDtcKhkHA();
			}

			private ControllerPollingInfo JnYpTFFPlBnouCKQxCRaPSCtnKbk()
			{
				IList<CustomController> list = RYrOzLdLhDMcyVDdbzlwvAkCWGA.QrSKTUzPSjlCKZGLJDqOVrJyplcf().cmeeIbUCxjHUqdNCBHHJgoMnHEVA();
				int count = list.Count;
				for (int i = 0; i < count; i++)
				{
					ControllerPollingInfo result = list[i].PollForFirstButton();
					if (result.success)
					{
						result.haeCbWiQSPlfWqsFZDTLoULYjVYq(omDgqMdNPYOabeAlYvYukkvWREGe.CgPagdlzMlCQxkbRTPOoePMzAXof);
						return result;
					}
				}
				return ControllerPollingInfo.wybtSxBKyoFevDSBzxAFgDtcKhkHA();
			}

			private ControllerPollingInfo gqqDwFwbbFBxJMsGJiJCFQGkBzEq()
			{
				IList<CustomController> list = RYrOzLdLhDMcyVDdbzlwvAkCWGA.QrSKTUzPSjlCKZGLJDqOVrJyplcf().cmeeIbUCxjHUqdNCBHHJgoMnHEVA();
				int count = list.Count;
				for (int i = 0; i < count; i++)
				{
					ControllerPollingInfo result = list[i].PollForFirstButtonDown();
					if (result.success)
					{
						result.haeCbWiQSPlfWqsFZDTLoULYjVYq(omDgqMdNPYOabeAlYvYukkvWREGe.CgPagdlzMlCQxkbRTPOoePMzAXof);
						return result;
					}
				}
				return ControllerPollingInfo.wybtSxBKyoFevDSBzxAFgDtcKhkHA();
			}

			private ControllerPollingInfo fbwCgkKTYyFdajcLBghgcbhGgkaAd()
			{
				IList<CustomController> list = RYrOzLdLhDMcyVDdbzlwvAkCWGA.QrSKTUzPSjlCKZGLJDqOVrJyplcf().cmeeIbUCxjHUqdNCBHHJgoMnHEVA();
				int count = list.Count;
				for (int i = 0; i < count; i++)
				{
					ControllerPollingInfo result = list[i].PollForFirstAxis();
					if (result.success)
					{
						result.haeCbWiQSPlfWqsFZDTLoULYjVYq(omDgqMdNPYOabeAlYvYukkvWREGe.CgPagdlzMlCQxkbRTPOoePMzAXof);
						return result;
					}
				}
				return ControllerPollingInfo.wybtSxBKyoFevDSBzxAFgDtcKhkHA();
			}

			[IteratorStateMachine(typeof(yhpdoFeDqLdjvGMKqvvhxAsYMQxN))]
			private IEnumerable<ControllerPollingInfo> gWpTHKLZLCUEzKNpBkYztIXqqpME()
			{
				return new yhpdoFeDqLdjvGMKqvvhxAsYMQxN(-2)
				{
					IYhgcKvkIGBZWrGvZionSwIMzKqF = this
				};
			}

			[IteratorStateMachine(typeof(xjBCOLFODPCAOaRBciDDgSPQQZOBA))]
			private IEnumerable<ControllerPollingInfo> ysKPmpqSDrClJIyGWHxohQEpdXem()
			{
				return new xjBCOLFODPCAOaRBciDDgSPQQZOBA(-2)
				{
					GMlVuaqaYaqWdtiQFHvOcVajuyzA = this
				};
			}

			[IteratorStateMachine(typeof(WylMZvHrmFJNFrUGIHbKFjUxgCFD))]
			private IEnumerable<ControllerPollingInfo> TKgTmOBFDVNUQrfGKRwyLPRMeOUg()
			{
				return new WylMZvHrmFJNFrUGIHbKFjUxgCFD(-2)
				{
					IVERMdbmXPAQmdUHARfTQotSmSjJ = this
				};
			}

			[IteratorStateMachine(typeof(RcViOjAcDWiLchRpcDeuFMJGiMECE))]
			private IEnumerable<ControllerPollingInfo> wVGRLDxQHNhFCvZradEasKmQkAOU()
			{
				return new RcViOjAcDWiLchRpcDeuFMJGiMECE(-2)
				{
					ZAHxWGssxWybdISBdjxVWMXFzzdh = this
				};
			}

			[IteratorStateMachine(typeof(yGIXmWQbKjUGlRrXDXtQIObmVYDC))]
			private IEnumerable<ControllerPollingInfo> aZtIkVAshlZLmHkWgIySTtJObsYH()
			{
				return new yGIXmWQbKjUGlRrXDXtQIObmVYDC(-2)
				{
					WYvQNDQefglgvyhsRXZiwNGoHVYR = this
				};
			}
		}

		[Serializable]
		private sealed class CuBpsqhZKHfdbNpmMyRfsCEuKlFQ
		{
			public static readonly CuBpsqhZKHfdbNpmMyRfsCEuKlFQ _003C_003E9 = new CuBpsqhZKHfdbNpmMyRfsCEuKlFQ();

			public static Action<Exception> _003C_003E9__23_0;

			public static Action<Exception> _003C_003E9__23_1;

			internal void YODGOSyyJJhGDotauJzHMfEflPIx(Exception P_0)
			{
				ReInput.HandleCallbackException("Player.ControllerHelper.ControllerAddedEvent", P_0);
			}

			internal void IiQnquSijqaoDxHkzJoXnhpYGIde(Exception P_0)
			{
				ReInput.HandleCallbackException("Player.ControllerHelper.ControllerRemovedEvent", P_0);
			}
		}

		private sealed class GiSkvoQxIhLOpDFkruxIwdskUlUG : IEnumerable<Controller>, IEnumerable, IEnumerator<Controller>, IEnumerator, IDisposable
		{
			private int TtRAopaXAskwEVulSeWVeYAGULIA;

			private Controller RBksKtgCYEgnnYeDrBOHOGefOYXL;

			private int suXazNagdiEpchTdPGUjRxsEhSyc;

			public ControllerHelper nlsNTnIQrUjgNXDiXVQcYMIGfHNq;

			private int mgwhzqWTElbnDldJmCpkFWrUQJUfA;

			private IList<Joystick> upqGDyTxiiisecMIabngYnmotnId;

			private int pdPEPBifHvygvASRqLhQycnuSvBr;

			private IList<CustomController> zlzmvZTYkXvnrAjoOUwVxWwRKFAH;

			private int bjKogiotEkEQZQiMepqpiRcGaUVt;

			Controller IEnumerator<Controller>.Current
			{
				[DebuggerHidden]
				get
				{
					return RBksKtgCYEgnnYeDrBOHOGefOYXL;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return RBksKtgCYEgnnYeDrBOHOGefOYXL;
				}
			}

			[DebuggerHidden]
			public GiSkvoQxIhLOpDFkruxIwdskUlUG(int P_0)
			{
				TtRAopaXAskwEVulSeWVeYAGULIA = P_0;
				suXazNagdiEpchTdPGUjRxsEhSyc = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int ttRAopaXAskwEVulSeWVeYAGULIA = TtRAopaXAskwEVulSeWVeYAGULIA;
				ControllerHelper controllerHelper = nlsNTnIQrUjgNXDiXVQcYMIGfHNq;
				switch (ttRAopaXAskwEVulSeWVeYAGULIA)
				{
				default:
					return false;
				case 0:
					TtRAopaXAskwEVulSeWVeYAGULIA = -1;
					if (ReInput._id != controllerHelper.iIxaEilBvUeVKsTMaFGATylPeNXS)
					{
						ReInput.CheckInitialized(controllerHelper.iIxaEilBvUeVKsTMaFGATylPeNXS);
						return false;
					}
					if (controllerHelper.lRGGFcEsxqLxQrnylLUfDadxvkQX)
					{
						RBksKtgCYEgnnYeDrBOHOGefOYXL = controllerHelper.Mouse;
						TtRAopaXAskwEVulSeWVeYAGULIA = 1;
						return true;
					}
					goto IL_0070;
				case 1:
					TtRAopaXAskwEVulSeWVeYAGULIA = -1;
					goto IL_0070;
				case 2:
					TtRAopaXAskwEVulSeWVeYAGULIA = -1;
					goto IL_0094;
				case 3:
					TtRAopaXAskwEVulSeWVeYAGULIA = -1;
					bjKogiotEkEQZQiMepqpiRcGaUVt++;
					goto IL_00ec;
				case 4:
					{
						TtRAopaXAskwEVulSeWVeYAGULIA = -1;
						bjKogiotEkEQZQiMepqpiRcGaUVt++;
						break;
					}
					IL_0094:
					mgwhzqWTElbnDldJmCpkFWrUQJUfA = controllerHelper.joystickCount;
					upqGDyTxiiisecMIabngYnmotnId = controllerHelper.Joysticks;
					bjKogiotEkEQZQiMepqpiRcGaUVt = 0;
					goto IL_00ec;
					IL_00ec:
					if (bjKogiotEkEQZQiMepqpiRcGaUVt < mgwhzqWTElbnDldJmCpkFWrUQJUfA)
					{
						RBksKtgCYEgnnYeDrBOHOGefOYXL = upqGDyTxiiisecMIabngYnmotnId[bjKogiotEkEQZQiMepqpiRcGaUVt];
						TtRAopaXAskwEVulSeWVeYAGULIA = 3;
						return true;
					}
					pdPEPBifHvygvASRqLhQycnuSvBr = controllerHelper.customControllerCount;
					zlzmvZTYkXvnrAjoOUwVxWwRKFAH = controllerHelper.CustomControllers;
					bjKogiotEkEQZQiMepqpiRcGaUVt = 0;
					break;
					IL_0070:
					if (controllerHelper.TlbyyHkskWZrSZcTJCoiWBTwNtSg)
					{
						RBksKtgCYEgnnYeDrBOHOGefOYXL = controllerHelper.Keyboard;
						TtRAopaXAskwEVulSeWVeYAGULIA = 2;
						return true;
					}
					goto IL_0094;
				}
				if (bjKogiotEkEQZQiMepqpiRcGaUVt < pdPEPBifHvygvASRqLhQycnuSvBr)
				{
					RBksKtgCYEgnnYeDrBOHOGefOYXL = zlzmvZTYkXvnrAjoOUwVxWwRKFAH[bjKogiotEkEQZQiMepqpiRcGaUVt];
					TtRAopaXAskwEVulSeWVeYAGULIA = 4;
					return true;
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
			IEnumerator<Controller> IEnumerable<Controller>.GetEnumerator()
			{
				GiSkvoQxIhLOpDFkruxIwdskUlUG giSkvoQxIhLOpDFkruxIwdskUlUG;
				if (TtRAopaXAskwEVulSeWVeYAGULIA == -2 && suXazNagdiEpchTdPGUjRxsEhSyc == Environment.CurrentManagedThreadId)
				{
					TtRAopaXAskwEVulSeWVeYAGULIA = 0;
					giSkvoQxIhLOpDFkruxIwdskUlUG = this;
				}
				else
				{
					giSkvoQxIhLOpDFkruxIwdskUlUG = new GiSkvoQxIhLOpDFkruxIwdskUlUG(0);
					giSkvoQxIhLOpDFkruxIwdskUlUG.nlsNTnIQrUjgNXDiXVQcYMIGfHNq = nlsNTnIQrUjgNXDiXVQcYMIGfHNq;
				}
				return giSkvoQxIhLOpDFkruxIwdskUlUG;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<Controller>)this).GetEnumerator();
			}
		}

		private readonly DDMnmwcSVutbFmZAzhkOWZMCBxWv QecjgvgRSXuPhnYvNrbSsHRqQwjg;

		private bool lRGGFcEsxqLxQrnylLUfDadxvkQX;

		private bool TlbyyHkskWZrSZcTJCoiWBTwNtSg;

		private bool zhyfSwSeXhXfMnaWzqzRURncguzI;

		private double KnSGhRgJIVDtKkrPQrWCJccLdAEb;

		private double OjmYEDXBLsFzpKGzcCiBiDFbugUMA;

		private SafeAction<ControllerAssignmentChangedEventArgs> JCvKtqRTmshFtkQqoOXrAblMeKIo = new SafeAction<ControllerAssignmentChangedEventArgs>(CuBpsqhZKHfdbNpmMyRfsCEuKlFQ._003C_003E9.YODGOSyyJJhGDotauJzHMfEflPIx);

		private SafeAction<ControllerAssignmentChangedEventArgs> pXdBLcevqBiBlWzRdLgftOwWzIIZ = new SafeAction<ControllerAssignmentChangedEventArgs>(CuBpsqhZKHfdbNpmMyRfsCEuKlFQ._003C_003E9.IiQnquSijqaoDxHkzJoXnhpYGIde);

		private readonly QHvleXMfQGGsGSDUArrcLeNstTyw nhsUTPodOQwcYCOQgEAPgJtivczK;

		private readonly Player bGWZlHEJQyGZSKuNhdAkKHdjnKdU;

		private readonly nROoOyYVcGhAjqHnmScNrfHojVwE GCIETMFbrLtFWbjmhJJzLsuxEbWB;

		private readonly int iIxaEilBvUeVKsTMaFGATylPeNXS;

		public readonly MapHelper maps;

		public readonly ConflictCheckingHelper conflictChecking;

		public readonly PollingHelper polling;

		private DGwRdGOlPFvMefvreaSvufGXwqlI<Joystick, JoystickMap> lUnvVySmnHrIONokkXMrlpAmGWkV => UZODjZPyOKvXiogzadHvXQZXjpbh();

		private global::rspbeSfkijiKRfPuAyBrBqKNCACZB<KeyboardMap> eTyrYnwjeFRpgrzrfVvAezJVqLPW => ivRzFyGkRxcFHWceHEDLRMPkSFKl();

		private global::rspbeSfkijiKRfPuAyBrBqKNCACZB<MouseMap> ZbzDGHkgsWRzEBagAlwUDbPJsEyL => xrSlrNFaWEBGoLerjuoUWlUclEVD();

		private DGwRdGOlPFvMefvreaSvufGXwqlI<CustomController, CustomControllerMap> QCGtAkgNMHKfcCpOJVbqYwkOeMls => QrSKTUzPSjlCKZGLJDqOVrJyplcf();

		public bool hasMouse
		{
			get
			{
				if (ReInput._id != iIxaEilBvUeVKsTMaFGATylPeNXS)
				{
					ReInput.CheckInitialized(iIxaEilBvUeVKsTMaFGATylPeNXS);
					return false;
				}
				return lRGGFcEsxqLxQrnylLUfDadxvkQX;
			}
			set
			{
				if (ReInput._id != iIxaEilBvUeVKsTMaFGATylPeNXS)
				{
					ReInput.CheckInitialized(iIxaEilBvUeVKsTMaFGATylPeNXS);
				}
				else
				{
					if (lRGGFcEsxqLxQrnylLUfDadxvkQX == value)
					{
						return;
					}
					lRGGFcEsxqLxQrnylLUfDadxvkQX = value;
					if (value)
					{
						GCIETMFbrLtFWbjmhJJzLsuxEbWB.NwCwRIqaKzXsvjtkBWSnlYNaVrQU(Mouse);
					}
					else
					{
						GCIETMFbrLtFWbjmhJJzLsuxEbWB.wUdFOsjHwFtryZkSuYDfCgLNwGrj(Mouse);
					}
					if (value)
					{
						maps.layoutManager.Apply();
						if (JCvKtqRTmshFtkQqoOXrAblMeKIo.Count > 0)
						{
							JCvKtqRTmshFtkQqoOXrAblMeKIo.Invoke(new ControllerAssignmentChangedEventArgs(bGWZlHEJQyGZSKuNhdAkKHdjnKdU.id, ReInput.controllers.Mouse.id, ControllerType.Mouse, value));
						}
					}
					else if (pXdBLcevqBiBlWzRdLgftOwWzIIZ.Count > 0)
					{
						pXdBLcevqBiBlWzRdLgftOwWzIIZ.Invoke(new ControllerAssignmentChangedEventArgs(bGWZlHEJQyGZSKuNhdAkKHdjnKdU.id, ReInput.controllers.Mouse.id, ControllerType.Mouse, value));
					}
				}
			}
		}

		public bool hasKeyboard
		{
			get
			{
				if (ReInput._id != iIxaEilBvUeVKsTMaFGATylPeNXS)
				{
					ReInput.CheckInitialized(iIxaEilBvUeVKsTMaFGATylPeNXS);
					return false;
				}
				return TlbyyHkskWZrSZcTJCoiWBTwNtSg;
			}
			set
			{
				if (ReInput._id != iIxaEilBvUeVKsTMaFGATylPeNXS)
				{
					ReInput.CheckInitialized(iIxaEilBvUeVKsTMaFGATylPeNXS);
				}
				else
				{
					if (TlbyyHkskWZrSZcTJCoiWBTwNtSg == value)
					{
						return;
					}
					TlbyyHkskWZrSZcTJCoiWBTwNtSg = value;
					if (value)
					{
						GCIETMFbrLtFWbjmhJJzLsuxEbWB.NwCwRIqaKzXsvjtkBWSnlYNaVrQU(Keyboard);
					}
					else
					{
						GCIETMFbrLtFWbjmhJJzLsuxEbWB.wUdFOsjHwFtryZkSuYDfCgLNwGrj(Keyboard);
					}
					if (value)
					{
						maps.layoutManager.Apply();
						if (JCvKtqRTmshFtkQqoOXrAblMeKIo.Count > 0)
						{
							JCvKtqRTmshFtkQqoOXrAblMeKIo.Invoke(new ControllerAssignmentChangedEventArgs(bGWZlHEJQyGZSKuNhdAkKHdjnKdU.id, ReInput.controllers.Keyboard.id, ControllerType.Keyboard, value));
						}
					}
					else if (pXdBLcevqBiBlWzRdLgftOwWzIIZ.Count > 0)
					{
						pXdBLcevqBiBlWzRdLgftOwWzIIZ.Invoke(new ControllerAssignmentChangedEventArgs(bGWZlHEJQyGZSKuNhdAkKHdjnKdU.id, ReInput.controllers.Keyboard.id, ControllerType.Keyboard, value));
					}
				}
			}
		}

		public bool excludeFromControllerAutoAssignment
		{
			get
			{
				if (ReInput._id != iIxaEilBvUeVKsTMaFGATylPeNXS)
				{
					ReInput.CheckInitialized(iIxaEilBvUeVKsTMaFGATylPeNXS);
					return false;
				}
				return zhyfSwSeXhXfMnaWzqzRURncguzI;
			}
			set
			{
				if (ReInput._id != iIxaEilBvUeVKsTMaFGATylPeNXS)
				{
					ReInput.CheckInitialized(iIxaEilBvUeVKsTMaFGATylPeNXS);
				}
				else
				{
					zhyfSwSeXhXfMnaWzqzRURncguzI = value;
				}
			}
		}

		public Keyboard Keyboard
		{
			get
			{
				if (ReInput._id != iIxaEilBvUeVKsTMaFGATylPeNXS)
				{
					ReInput.CheckInitialized(iIxaEilBvUeVKsTMaFGATylPeNXS);
					return null;
				}
				return ReInput.controllers.Keyboard;
			}
		}

		public Mouse Mouse
		{
			get
			{
				if (ReInput._id != iIxaEilBvUeVKsTMaFGATylPeNXS)
				{
					ReInput.CheckInitialized(iIxaEilBvUeVKsTMaFGATylPeNXS);
					return null;
				}
				return ReInput.controllers.Mouse;
			}
		}

		public int joystickCount
		{
			get
			{
				if (ReInput._id != iIxaEilBvUeVKsTMaFGATylPeNXS)
				{
					ReInput.CheckInitialized(iIxaEilBvUeVKsTMaFGATylPeNXS);
					return 0;
				}
				return QecjgvgRSXuPhnYvNrbSsHRqQwjg.AXLlayIlTwJqJNaNzeKccuszIcODb(ControllerType.Joystick).rphZqyUfbdoINyXndGfDbQaiIHFM();
			}
		}

		public IList<Joystick> Joysticks
		{
			get
			{
				if (ReInput._id != iIxaEilBvUeVKsTMaFGATylPeNXS)
				{
					ReInput.CheckInitialized(iIxaEilBvUeVKsTMaFGATylPeNXS);
					return EmptyObjects<Joystick>.EmptyReadOnlyIListT;
				}
				return (QecjgvgRSXuPhnYvNrbSsHRqQwjg.AXLlayIlTwJqJNaNzeKccuszIcODb(ControllerType.Joystick) as DGwRdGOlPFvMefvreaSvufGXwqlI<Joystick, JoystickMap>).cmeeIbUCxjHUqdNCBHHJgoMnHEVA();
			}
		}

		public int customControllerCount
		{
			get
			{
				if (ReInput._id != iIxaEilBvUeVKsTMaFGATylPeNXS)
				{
					ReInput.CheckInitialized(iIxaEilBvUeVKsTMaFGATylPeNXS);
					return 0;
				}
				return QecjgvgRSXuPhnYvNrbSsHRqQwjg.AXLlayIlTwJqJNaNzeKccuszIcODb(ControllerType.Custom).rphZqyUfbdoINyXndGfDbQaiIHFM();
			}
		}

		public IList<CustomController> CustomControllers
		{
			get
			{
				if (ReInput._id != iIxaEilBvUeVKsTMaFGATylPeNXS)
				{
					ReInput.CheckInitialized(iIxaEilBvUeVKsTMaFGATylPeNXS);
					return EmptyObjects<CustomController>.EmptyReadOnlyIListT;
				}
				return (QecjgvgRSXuPhnYvNrbSsHRqQwjg.AXLlayIlTwJqJNaNzeKccuszIcODb(ControllerType.Custom) as DGwRdGOlPFvMefvreaSvufGXwqlI<CustomController, CustomControllerMap>).cmeeIbUCxjHUqdNCBHHJgoMnHEVA();
			}
		}

		public IEnumerable<Controller> Controllers
		{
			[IteratorStateMachine(typeof(GiSkvoQxIhLOpDFkruxIwdskUlUG))]
			get
			{
				return new GiSkvoQxIhLOpDFkruxIwdskUlUG(-2)
				{
					nlsNTnIQrUjgNXDiXVQcYMIGfHNq = this
				};
			}
		}

		public event Action<ControllerAssignmentChangedEventArgs> ControllerAddedEvent
		{
			add
			{
				JCvKtqRTmshFtkQqoOXrAblMeKIo.AddDelegate(value);
			}
			remove
			{
				JCvKtqRTmshFtkQqoOXrAblMeKIo.RemoveDelegate(value);
			}
		}

		public event Action<ControllerAssignmentChangedEventArgs> ControllerRemovedEvent
		{
			add
			{
				pXdBLcevqBiBlWzRdLgftOwWzIIZ.AddDelegate(value);
			}
			remove
			{
				pXdBLcevqBiBlWzRdLgftOwWzIIZ.RemoveDelegate(value);
			}
		}

		private DGwRdGOlPFvMefvreaSvufGXwqlI<Joystick, JoystickMap> UZODjZPyOKvXiogzadHvXQZXjpbh()
		{
			return (DGwRdGOlPFvMefvreaSvufGXwqlI<Joystick, JoystickMap>)QecjgvgRSXuPhnYvNrbSsHRqQwjg.AXLlayIlTwJqJNaNzeKccuszIcODb(ControllerType.Joystick);
		}

		private global::rspbeSfkijiKRfPuAyBrBqKNCACZB<KeyboardMap> ivRzFyGkRxcFHWceHEDLRMPkSFKl()
		{
			return (global::rspbeSfkijiKRfPuAyBrBqKNCACZB<KeyboardMap>)QecjgvgRSXuPhnYvNrbSsHRqQwjg.AXLlayIlTwJqJNaNzeKccuszIcODb(ControllerType.Keyboard).EiaJdcLRNPgisAQlXkogBqWdcrPqb(0).ycfaKniCLOzZqlQviANrBfbEZIlRA();
		}

		private global::rspbeSfkijiKRfPuAyBrBqKNCACZB<MouseMap> xrSlrNFaWEBGoLerjuoUWlUclEVD()
		{
			return (global::rspbeSfkijiKRfPuAyBrBqKNCACZB<MouseMap>)QecjgvgRSXuPhnYvNrbSsHRqQwjg.AXLlayIlTwJqJNaNzeKccuszIcODb(ControllerType.Mouse).EiaJdcLRNPgisAQlXkogBqWdcrPqb(0).ycfaKniCLOzZqlQviANrBfbEZIlRA();
		}

		private DGwRdGOlPFvMefvreaSvufGXwqlI<CustomController, CustomControllerMap> QrSKTUzPSjlCKZGLJDqOVrJyplcf()
		{
			return (DGwRdGOlPFvMefvreaSvufGXwqlI<CustomController, CustomControllerMap>)QecjgvgRSXuPhnYvNrbSsHRqQwjg.AXLlayIlTwJqJNaNzeKccuszIcODb(ControllerType.Custom);
		}

		internal ControllerHelper(Player P_0, spMACGdyRGKOkwMouVwTkXeYbAaQ P_1, ControllerMapLayoutManager.cUhsarZCgVkkiQMvHfbBJdlcDTAR P_2, ControllerMapEnabler.myTUEzsWwrinEGyZklokhnLFhKWB P_3)
		{
			iIxaEilBvUeVKsTMaFGATylPeNXS = ReInput.id;
			bGWZlHEJQyGZSKuNhdAkKHdjnKdU = P_0;
			maps = new MapHelper(P_0, this, P_1, P_2, P_3);
			polling = new PollingHelper(P_0, this);
			conflictChecking = new ConflictCheckingHelper(P_0, this);
			QecjgvgRSXuPhnYvNrbSsHRqQwjg = new DDMnmwcSVutbFmZAzhkOWZMCBxWv(4);
			QecjgvgRSXuPhnYvNrbSsHRqQwjg.aJWjxFHrPoEvJuwjmdYgjlqgKoQt(0, ControllerType.Joystick, new DGwRdGOlPFvMefvreaSvufGXwqlI<Joystick, JoystickMap>());
			QecjgvgRSXuPhnYvNrbSsHRqQwjg.aJWjxFHrPoEvJuwjmdYgjlqgKoQt(1, ControllerType.Keyboard, new DGwRdGOlPFvMefvreaSvufGXwqlI<Keyboard, KeyboardMap>());
			QecjgvgRSXuPhnYvNrbSsHRqQwjg.aJWjxFHrPoEvJuwjmdYgjlqgKoQt(2, ControllerType.Mouse, new DGwRdGOlPFvMefvreaSvufGXwqlI<Mouse, MouseMap>());
			QecjgvgRSXuPhnYvNrbSsHRqQwjg.aJWjxFHrPoEvJuwjmdYgjlqgKoQt(3, ControllerType.Custom, new DGwRdGOlPFvMefvreaSvufGXwqlI<CustomController, CustomControllerMap>());
			nhsUTPodOQwcYCOQgEAPgJtivczK = new QHvleXMfQGGsGSDUArrcLeNstTyw(P_0);
			GCIETMFbrLtFWbjmhJJzLsuxEbWB = new nROoOyYVcGhAjqHnmScNrfHojVwE(UnityTools.externalTools.GetControllerTemplateTypes(), UnityTools.externalTools.GetControllerTemplateInterfaceTypes());
		}

		public T GetController<T>(int controllerId) where T : Controller
		{
			if (ReInput._id != iIxaEilBvUeVKsTMaFGATylPeNXS)
			{
				ReInput.CheckInitialized(iIxaEilBvUeVKsTMaFGATylPeNXS);
				return null;
			}
			return (T)QecjgvgRSXuPhnYvNrbSsHRqQwjg.AXLlayIlTwJqJNaNzeKccuszIcODb(IyPmashUlRgIygDiHFyDZHZmauql.GtGNsJnddAaIOBVymBmDiqWMLSbvA<T>()).LfjMQuyzfsNjHNOGJnqsCFAAYMBj(controllerId);
		}

		public Controller GetController(ControllerType controllerType, int controllerId)
		{
			if (ReInput._id != iIxaEilBvUeVKsTMaFGATylPeNXS)
			{
				ReInput.CheckInitialized(iIxaEilBvUeVKsTMaFGATylPeNXS);
				return null;
			}
			return QecjgvgRSXuPhnYvNrbSsHRqQwjg.AXLlayIlTwJqJNaNzeKccuszIcODb(controllerType).LfjMQuyzfsNjHNOGJnqsCFAAYMBj(controllerId);
		}

		public T GetControllerWithTag<T>(string tag) where T : Controller
		{
			if (ReInput._id != iIxaEilBvUeVKsTMaFGATylPeNXS)
			{
				ReInput.CheckInitialized(iIxaEilBvUeVKsTMaFGATylPeNXS);
				return null;
			}
			return (T)QecjgvgRSXuPhnYvNrbSsHRqQwjg.AXLlayIlTwJqJNaNzeKccuszIcODb(IyPmashUlRgIygDiHFyDZHZmauql.GtGNsJnddAaIOBVymBmDiqWMLSbvA<T>()).IDybHFsLNznIXwmYCUieaHGEyevs(tag);
		}

		public Controller GetControllerWithTag(ControllerType controllerType, string tag)
		{
			if (ReInput._id != iIxaEilBvUeVKsTMaFGATylPeNXS)
			{
				ReInput.CheckInitialized(iIxaEilBvUeVKsTMaFGATylPeNXS);
				return null;
			}
			return QecjgvgRSXuPhnYvNrbSsHRqQwjg.AXLlayIlTwJqJNaNzeKccuszIcODb(controllerType).IDybHFsLNznIXwmYCUieaHGEyevs(tag);
		}

		public void AddController<T>(int controllerId, bool removeFromOtherPlayers) where T : Controller
		{
			if (ReInput._id != iIxaEilBvUeVKsTMaFGATylPeNXS)
			{
				ReInput.CheckInitialized(iIxaEilBvUeVKsTMaFGATylPeNXS);
				return;
			}
			Type typeFromHandle = typeof(T);
			if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Joystick)))
			{
				lGPhcmVsVJOoplnqbMmdmMfIapml(controllerId, removeFromOtherPlayers);
				return;
			}
			if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Keyboard)))
			{
				AddController(ControllerType.Keyboard, controllerId, removeFromOtherPlayers);
				return;
			}
			if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Mouse)))
			{
				AddController(ControllerType.Mouse, controllerId, removeFromOtherPlayers);
				return;
			}
			if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(CustomController)))
			{
				KZmBTSSqpAAknwgmTUmepIwjRMPL(controllerId, removeFromOtherPlayers);
				return;
			}
			throw new NotImplementedException();
		}

		public void AddController(Controller controller, bool removeFromOtherPlayers)
		{
			if (ReInput._id != iIxaEilBvUeVKsTMaFGATylPeNXS)
			{
				ReInput.CheckInitialized(iIxaEilBvUeVKsTMaFGATylPeNXS);
			}
			else if (controller != null)
			{
				switch (controller.type)
				{
				case ControllerType.Joystick:
					VuyGldiugjtXAeHaagwQSjnHJLwfA(controller as Joystick, removeFromOtherPlayers);
					break;
				case ControllerType.Keyboard:
					AddController(controller.type, controller.id, removeFromOtherPlayers);
					break;
				case ControllerType.Mouse:
					AddController(controller.type, controller.id, removeFromOtherPlayers);
					break;
				case ControllerType.Custom:
					MXQGAlxTWPRnRxzEisMghMTBgLmp(controller as CustomController, removeFromOtherPlayers);
					break;
				default:
					throw new NotImplementedException();
				}
			}
		}

		public void AddController(ControllerType controllerType, int controllerId, bool removeFromOtherPlayers)
		{
			if (ReInput._id != iIxaEilBvUeVKsTMaFGATylPeNXS)
			{
				ReInput.CheckInitialized(iIxaEilBvUeVKsTMaFGATylPeNXS);
				return;
			}
			switch (controllerType)
			{
			case ControllerType.Joystick:
				VuyGldiugjtXAeHaagwQSjnHJLwfA(ReInput.controllers.GetController(controllerType, controllerId) as Joystick, removeFromOtherPlayers);
				break;
			case ControllerType.Keyboard:
				if (removeFromOtherPlayers)
				{
					ReInput.controllers.RemoveControllerFromAllPlayers(controllerType, controllerId);
				}
				hasKeyboard = true;
				break;
			case ControllerType.Mouse:
				if (removeFromOtherPlayers)
				{
					ReInput.controllers.RemoveControllerFromAllPlayers(controllerType, controllerId);
				}
				hasMouse = true;
				break;
			case ControllerType.Custom:
				MXQGAlxTWPRnRxzEisMghMTBgLmp(ReInput.controllers.GetController(controllerType, controllerId) as CustomController, removeFromOtherPlayers);
				break;
			default:
				throw new NotImplementedException();
			}
		}

		public void RemoveController<T>(int controllerId) where T : Controller
		{
			if (ReInput._id != iIxaEilBvUeVKsTMaFGATylPeNXS)
			{
				ReInput.CheckInitialized(iIxaEilBvUeVKsTMaFGATylPeNXS);
				return;
			}
			Type typeFromHandle = typeof(T);
			if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Joystick)))
			{
				RsDUJgqmoRRNGXaYVNveumbuRvvS(controllerId);
				return;
			}
			if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Keyboard)))
			{
				RemoveController(ControllerType.Keyboard, 0);
				return;
			}
			if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Mouse)))
			{
				RemoveController(ControllerType.Mouse, 0);
				return;
			}
			if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(CustomController)))
			{
				huGblDFtlsgFtHJhEOzWTVmbxksi(controllerId);
				return;
			}
			throw new NotImplementedException();
		}

		public void RemoveController(ControllerType controllerType, int controllerId)
		{
			if (ReInput._id != iIxaEilBvUeVKsTMaFGATylPeNXS)
			{
				ReInput.CheckInitialized(iIxaEilBvUeVKsTMaFGATylPeNXS);
				return;
			}
			switch (controllerType)
			{
			case ControllerType.Joystick:
				RsDUJgqmoRRNGXaYVNveumbuRvvS(controllerId);
				break;
			case ControllerType.Keyboard:
				hasKeyboard = false;
				break;
			case ControllerType.Mouse:
				hasMouse = false;
				break;
			case ControllerType.Custom:
				huGblDFtlsgFtHJhEOzWTVmbxksi(controllerId);
				break;
			default:
				throw new NotImplementedException();
			}
		}

		public void RemoveController(Controller controller)
		{
			if (ReInput._id != iIxaEilBvUeVKsTMaFGATylPeNXS)
			{
				ReInput.CheckInitialized(iIxaEilBvUeVKsTMaFGATylPeNXS);
			}
			else if (controller != null)
			{
				switch (controller.type)
				{
				case ControllerType.Joystick:
					cyVGrkRfGgSHMlENCMQojMfWVtZj(controller as Joystick);
					break;
				case ControllerType.Keyboard:
					hasKeyboard = false;
					break;
				case ControllerType.Mouse:
					hasMouse = false;
					break;
				case ControllerType.Custom:
					YhsbofBlHeceHtebbDOGxILgZimjA(controller as CustomController);
					break;
				default:
					throw new NotImplementedException();
				}
			}
		}

		public bool ContainsController<T>(int controllerId) where T : Controller
		{
			if (ReInput._id != iIxaEilBvUeVKsTMaFGATylPeNXS)
			{
				ReInput.CheckInitialized(iIxaEilBvUeVKsTMaFGATylPeNXS);
				return false;
			}
			Type typeFromHandle = typeof(T);
			if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Joystick)))
			{
				return ContainsController(ControllerType.Joystick, controllerId);
			}
			if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Keyboard)))
			{
				return TlbyyHkskWZrSZcTJCoiWBTwNtSg;
			}
			if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Mouse)))
			{
				return lRGGFcEsxqLxQrnylLUfDadxvkQX;
			}
			if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(CustomController)))
			{
				return ContainsController(ControllerType.Custom, controllerId);
			}
			throw new NotImplementedException();
		}

		public bool ContainsController(ControllerType controllerType, int controllerId)
		{
			if (ReInput._id != iIxaEilBvUeVKsTMaFGATylPeNXS)
			{
				ReInput.CheckInitialized(iIxaEilBvUeVKsTMaFGATylPeNXS);
				return false;
			}
			return controllerType switch
			{
				ControllerType.Joystick => QecjgvgRSXuPhnYvNrbSsHRqQwjg.AXLlayIlTwJqJNaNzeKccuszIcODb(ControllerType.Joystick).qeQAZQmgxcHqHizaGnELPEdIYlFN(controllerId), 
				ControllerType.Keyboard => TlbyyHkskWZrSZcTJCoiWBTwNtSg, 
				ControllerType.Mouse => lRGGFcEsxqLxQrnylLUfDadxvkQX, 
				ControllerType.Custom => QecjgvgRSXuPhnYvNrbSsHRqQwjg.AXLlayIlTwJqJNaNzeKccuszIcODb(ControllerType.Custom).qeQAZQmgxcHqHizaGnELPEdIYlFN(controllerId), 
				_ => throw new NotImplementedException(), 
			};
		}

		public bool ContainsController(Controller controller)
		{
			if (ReInput._id != iIxaEilBvUeVKsTMaFGATylPeNXS)
			{
				ReInput.CheckInitialized(iIxaEilBvUeVKsTMaFGATylPeNXS);
				return false;
			}
			if (controller == null)
			{
				return false;
			}
			return ContainsController(controller.type, controller.id);
		}

		public void ClearControllersOfType<T>() where T : Controller
		{
			if (ReInput._id != iIxaEilBvUeVKsTMaFGATylPeNXS)
			{
				ReInput.CheckInitialized(iIxaEilBvUeVKsTMaFGATylPeNXS);
				return;
			}
			Type typeFromHandle = typeof(T);
			if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Joystick)))
			{
				dCHAdodjbHMfNRTeMIGTgKSDTQXnB();
				return;
			}
			if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Keyboard)))
			{
				hasKeyboard = false;
				return;
			}
			if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Mouse)))
			{
				hasMouse = false;
				return;
			}
			if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(CustomController)))
			{
				IQRZFobxGnMmWqXokkTwaShiOehX();
				return;
			}
			if ((object)typeFromHandle == typeof(Controller))
			{
				ClearAllControllers();
				return;
			}
			throw new NotImplementedException();
		}

		public void ClearControllersOfType(ControllerType controllerType)
		{
			if (ReInput._id != iIxaEilBvUeVKsTMaFGATylPeNXS)
			{
				ReInput.CheckInitialized(iIxaEilBvUeVKsTMaFGATylPeNXS);
				return;
			}
			switch (controllerType)
			{
			case ControllerType.Joystick:
				dCHAdodjbHMfNRTeMIGTgKSDTQXnB();
				break;
			case ControllerType.Keyboard:
				hasKeyboard = false;
				break;
			case ControllerType.Mouse:
				hasMouse = false;
				break;
			case ControllerType.Custom:
				IQRZFobxGnMmWqXokkTwaShiOehX();
				break;
			default:
				throw new NotImplementedException();
			}
		}

		public void ClearAllControllers()
		{
			if (ReInput._id != iIxaEilBvUeVKsTMaFGATylPeNXS)
			{
				ReInput.CheckInitialized(iIxaEilBvUeVKsTMaFGATylPeNXS);
				return;
			}
			dCHAdodjbHMfNRTeMIGTgKSDTQXnB();
			IQRZFobxGnMmWqXokkTwaShiOehX();
			hasMouse = false;
			hasKeyboard = false;
		}

		public Controller GetLastActiveController()
		{
			if (ReInput._id != iIxaEilBvUeVKsTMaFGATylPeNXS)
			{
				ReInput.CheckInitialized(iIxaEilBvUeVKsTMaFGATylPeNXS);
				return null;
			}
			Controller result = null;
			double num = 0.0;
			BtUtttpiPXFtPekChLVEkEdIaCEfb(ControllerType.Joystick, ref result, ref num);
			if (lRGGFcEsxqLxQrnylLUfDadxvkQX && KnSGhRgJIVDtKkrPQrWCJccLdAEb > num)
			{
				result = Mouse;
				num = KnSGhRgJIVDtKkrPQrWCJccLdAEb;
			}
			if (TlbyyHkskWZrSZcTJCoiWBTwNtSg && OjmYEDXBLsFzpKGzcCiBiDFbugUMA > num)
			{
				result = Keyboard;
				num = OjmYEDXBLsFzpKGzcCiBiDFbugUMA;
			}
			BtUtttpiPXFtPekChLVEkEdIaCEfb(ControllerType.Custom, ref result, ref num);
			return result;
		}

		public Controller GetLastActiveController(ControllerType controllerType)
		{
			if (ReInput._id != iIxaEilBvUeVKsTMaFGATylPeNXS)
			{
				ReInput.CheckInitialized(iIxaEilBvUeVKsTMaFGATylPeNXS);
				return null;
			}
			Controller result = null;
			double num = 0.0;
			switch (controllerType)
			{
			case ControllerType.Joystick:
			case ControllerType.Custom:
				BtUtttpiPXFtPekChLVEkEdIaCEfb(controllerType, ref result, ref num);
				break;
			case ControllerType.Keyboard:
				if (TlbyyHkskWZrSZcTJCoiWBTwNtSg && OjmYEDXBLsFzpKGzcCiBiDFbugUMA > 0.0)
				{
					result = Keyboard;
				}
				break;
			case ControllerType.Mouse:
				if (lRGGFcEsxqLxQrnylLUfDadxvkQX && KnSGhRgJIVDtKkrPQrWCJccLdAEb > 0.0)
				{
					result = Mouse;
				}
				break;
			default:
				throw new NotImplementedException();
			}
			return result;
		}

		private void BtUtttpiPXFtPekChLVEkEdIaCEfb(ControllerType P_0, ref Controller P_1, ref double P_2)
		{
			HENtlJpbLTfyvGNBdnYOTBUpGwmPA hENtlJpbLTfyvGNBdnYOTBUpGwmPA = QecjgvgRSXuPhnYvNrbSsHRqQwjg.AXLlayIlTwJqJNaNzeKccuszIcODb(P_0);
			int num = hENtlJpbLTfyvGNBdnYOTBUpGwmPA.rphZqyUfbdoINyXndGfDbQaiIHFM();
			for (int i = 0; i < num; i++)
			{
				double num2 = hENtlJpbLTfyvGNBdnYOTBUpGwmPA.gmqWnmpZMnASuZpGLEqmJcwgXIqMA(i).ersRHTHxrHOeGRJSusaWslJcbnWC();
				if (!(num2 <= P_2))
				{
					P_1 = hENtlJpbLTfyvGNBdnYOTBUpGwmPA.gmqWnmpZMnASuZpGLEqmJcwgXIqMA(i).hfcnXcmxHjJxWTdCahVjbHZvxlVj();
					P_2 = num2;
				}
			}
		}

		public Controller GetLastActiveController<T>() where T : Controller
		{
			return GetLastActiveController(IyPmashUlRgIygDiHFyDZHZmauql.GtGNsJnddAaIOBVymBmDiqWMLSbvA<T>());
		}

		public void AddLastActiveControllerChangedDelegate(PlayerActiveControllerChangedDelegate callback)
		{
			if (ReInput.isReady)
			{
				if (ReInput._id != iIxaEilBvUeVKsTMaFGATylPeNXS)
				{
					ReInput.CheckInitialized(iIxaEilBvUeVKsTMaFGATylPeNXS);
				}
				else
				{
					bGWZlHEJQyGZSKuNhdAkKHdjnKdU.vUXRFQkaqtxZmDdZWniajedetQiF.sRfXCxFticxHgQpQVOGMWxlPoVPH(bGWZlHEJQyGZSKuNhdAkKHdjnKdU.CgPagdlzMlCQxkbRTPOoePMzAXof, callback);
				}
			}
		}

		public void AddLastActiveControllerChangedDelegate(PlayerActiveControllerChangedDelegate callback, ControllerType controllerType)
		{
			if (ReInput.isReady)
			{
				if (ReInput._id != iIxaEilBvUeVKsTMaFGATylPeNXS)
				{
					ReInput.CheckInitialized(iIxaEilBvUeVKsTMaFGATylPeNXS);
				}
				else
				{
					bGWZlHEJQyGZSKuNhdAkKHdjnKdU.vUXRFQkaqtxZmDdZWniajedetQiF.ZzECphoYogepvFqidROMecRyXEHV(bGWZlHEJQyGZSKuNhdAkKHdjnKdU.CgPagdlzMlCQxkbRTPOoePMzAXof, callback, controllerType);
				}
			}
		}

		public void RemoveLastActiveControllerChangedDelegate(PlayerActiveControllerChangedDelegate callback)
		{
			if (ReInput.isReady)
			{
				if (ReInput._id != iIxaEilBvUeVKsTMaFGATylPeNXS)
				{
					ReInput.CheckInitialized(iIxaEilBvUeVKsTMaFGATylPeNXS);
				}
				else
				{
					bGWZlHEJQyGZSKuNhdAkKHdjnKdU.vUXRFQkaqtxZmDdZWniajedetQiF.jJewTxfgtYtmlILFFixjDAVfNquOA(bGWZlHEJQyGZSKuNhdAkKHdjnKdU.CgPagdlzMlCQxkbRTPOoePMzAXof, callback);
				}
			}
		}

		public void RemoveLastActiveControllerChangedDelegate(PlayerActiveControllerChangedDelegate callback, ControllerType controllerType)
		{
			if (ReInput.isReady)
			{
				if (ReInput._id != iIxaEilBvUeVKsTMaFGATylPeNXS)
				{
					ReInput.CheckInitialized(iIxaEilBvUeVKsTMaFGATylPeNXS);
				}
				else
				{
					bGWZlHEJQyGZSKuNhdAkKHdjnKdU.vUXRFQkaqtxZmDdZWniajedetQiF.hAnYRKUUclFijTHSaRqqoLqYlINc(bGWZlHEJQyGZSKuNhdAkKHdjnKdU.CgPagdlzMlCQxkbRTPOoePMzAXof, callback, controllerType);
				}
			}
		}

		public void ClearLastActiveControllerChangedDelegates()
		{
			if (ReInput.isReady)
			{
				if (ReInput._id != iIxaEilBvUeVKsTMaFGATylPeNXS)
				{
					ReInput.CheckInitialized(iIxaEilBvUeVKsTMaFGATylPeNXS);
				}
				else
				{
					bGWZlHEJQyGZSKuNhdAkKHdjnKdU.vUXRFQkaqtxZmDdZWniajedetQiF.aqcrjUaSwwpOpeYKtlcZbjyGUiRe(bGWZlHEJQyGZSKuNhdAkKHdjnKdU.CgPagdlzMlCQxkbRTPOoePMzAXof);
				}
			}
		}

		public Controller GetFirstControllerWithTemplate(Guid templateTypeGuid)
		{
			if (ReInput._id != iIxaEilBvUeVKsTMaFGATylPeNXS)
			{
				ReInput.CheckInitialized(iIxaEilBvUeVKsTMaFGATylPeNXS);
				return null;
			}
			int kzSWyhVFpKvuMAleUEiVntIEyGZD = QecjgvgRSXuPhnYvNrbSsHRqQwjg.KzSWyhVFpKvuMAleUEiVntIEyGZD;
			for (int i = 0; i < kzSWyhVFpKvuMAleUEiVntIEyGZD; i++)
			{
				Controller controller = RjwhoutfdrDDHeNUqfedxRColJFt(QecjgvgRSXuPhnYvNrbSsHRqQwjg.AMmiEUMJUxmCKCltvrDeLoaPvEGE(i).dfCsqzjNkxnRCLjXzSnDwrOkiBYk(), Controller.rfkaHYAdQqwZPLqANfnyfsLkhHWIc(), templateTypeGuid);
				if (controller != null)
				{
					return controller;
				}
			}
			return null;
		}

		public Controller GetFirstControllerWithTemplate(Type templateType)
		{
			if (ReInput._id != iIxaEilBvUeVKsTMaFGATylPeNXS)
			{
				ReInput.CheckInitialized(iIxaEilBvUeVKsTMaFGATylPeNXS);
				return null;
			}
			int kzSWyhVFpKvuMAleUEiVntIEyGZD = QecjgvgRSXuPhnYvNrbSsHRqQwjg.KzSWyhVFpKvuMAleUEiVntIEyGZD;
			for (int i = 0; i < kzSWyhVFpKvuMAleUEiVntIEyGZD; i++)
			{
				Controller controller = RjwhoutfdrDDHeNUqfedxRColJFt(QecjgvgRSXuPhnYvNrbSsHRqQwjg.AMmiEUMJUxmCKCltvrDeLoaPvEGE(i).dfCsqzjNkxnRCLjXzSnDwrOkiBYk(), Controller.ZKzfVpKsPvMjAwTtpeymwqHXaFaL(), templateType);
				if (controller != null)
				{
					return controller;
				}
			}
			return null;
		}

		public Controller GetFirstControllerWithTemplate<T>() where T : class
		{
			return GetFirstControllerWithTemplate(typeof(T));
		}

		public IList<TInterface> GetControllerTemplates<TInterface>() where TInterface : IControllerTemplate
		{
			if (ReInput._id != iIxaEilBvUeVKsTMaFGATylPeNXS)
			{
				ReInput.CheckInitialized(iIxaEilBvUeVKsTMaFGATylPeNXS);
				return EmptyObjects<TInterface>.EmptyReadOnlyIListT;
			}
			return GCIETMFbrLtFWbjmhJJzLsuxEbWB.bpzHUQyiYjpOkNEdpYqviVucnLDW<TInterface>();
		}

		private Controller RjwhoutfdrDDHeNUqfedxRColJFt<_0001>(ControllerType P_0, Func<Controller, _0001, bool> P_1, _0001 P_2)
		{
			switch (P_0)
			{
			case ControllerType.Joystick:
			{
				int num2 = joystickCount;
				IList<Joystick> joysticks = Joysticks;
				for (int j = 0; j < num2; j++)
				{
					if (P_1(joysticks[j], P_2))
					{
						return joysticks[j];
					}
				}
				return null;
			}
			case ControllerType.Keyboard:
				if (TlbyyHkskWZrSZcTJCoiWBTwNtSg && P_1(Keyboard, P_2))
				{
					return Keyboard;
				}
				return null;
			case ControllerType.Mouse:
				if (lRGGFcEsxqLxQrnylLUfDadxvkQX && P_1(Mouse, P_2))
				{
					return Mouse;
				}
				return null;
			case ControllerType.Custom:
			{
				int num = customControllerCount;
				IList<CustomController> customControllers = CustomControllers;
				for (int i = 0; i < num; i++)
				{
					if (P_1(customControllers[i], P_2))
					{
						return customControllers[i];
					}
				}
				return null;
			}
			default:
				throw new NotImplementedException();
			}
		}

		internal void uXeROrvefFFKRFVEgMyTdZygxxPNB()
		{
			for (int i = 0; i < QecjgvgRSXuPhnYvNrbSsHRqQwjg.KzSWyhVFpKvuMAleUEiVntIEyGZD; i++)
			{
				QecjgvgRSXuPhnYvNrbSsHRqQwjg.AMmiEUMJUxmCKCltvrDeLoaPvEGE(i).CHDaUwGARteSiOLodcLIyYCDkANd();
			}
			QecjgvgRSXuPhnYvNrbSsHRqQwjg.AXLlayIlTwJqJNaNzeKccuszIcODb(ControllerType.Keyboard).ezcDNeepWSxgQWKjHyrGpxdUzKgaA(new DGwRdGOlPFvMefvreaSvufGXwqlI<Keyboard, KeyboardMap>.ULpvOcMrCuZQnwHsGOOZRCagYnur(ReInput.jCkgZLcnXoMycBxzcMXWvnUfSROEb.CJDSMKuYTmJFQKoQSdBfaFNyeDGkA(), new global::rspbeSfkijiKRfPuAyBrBqKNCACZB<KeyboardMap>(0)));
			QecjgvgRSXuPhnYvNrbSsHRqQwjg.AXLlayIlTwJqJNaNzeKccuszIcODb(ControllerType.Mouse).ezcDNeepWSxgQWKjHyrGpxdUzKgaA(new DGwRdGOlPFvMefvreaSvufGXwqlI<Mouse, MouseMap>.ULpvOcMrCuZQnwHsGOOZRCagYnur(ReInput.jCkgZLcnXoMycBxzcMXWvnUfSROEb.QEiqHFnLLZJSkuwNvWvNEjeQXMlT(), new global::rspbeSfkijiKRfPuAyBrBqKNCACZB<MouseMap>(0)));
			nhsUTPodOQwcYCOQgEAPgJtivczK.icMhQMavCZQKfCtqPZlfGuvmqILEA();
			OjmYEDXBLsFzpKGzcCiBiDFbugUMA = 0.0;
			KnSGhRgJIVDtKkrPQrWCJccLdAEb = 0.0;
			maps.fNqwtgIrBfdBNJrUBBLIRRTmdRhM();
		}

		internal double YucZUrFwzwzUOLylRVLfAjQlnuCC(int P_0)
		{
			return nhsUTPodOQwcYCOQgEAPgJtivczK.rdCVwdZckLhQvWrkFzLfdWrXWFgQ(P_0)?.IqTgzwiXudFILaSboUapIowoZOpmA ?? (-1.0);
		}

		internal void VuyGldiugjtXAeHaagwQSjnHJLwfA(Joystick P_0, bool P_1)
		{
			if (P_0 == null)
			{
				return;
			}
			HENtlJpbLTfyvGNBdnYOTBUpGwmPA hENtlJpbLTfyvGNBdnYOTBUpGwmPA = QecjgvgRSXuPhnYvNrbSsHRqQwjg.AXLlayIlTwJqJNaNzeKccuszIcODb(ControllerType.Joystick);
			if (hENtlJpbLTfyvGNBdnYOTBUpGwmPA.qeQAZQmgxcHqHizaGnELPEdIYlFN(P_0.id))
			{
				return;
			}
			if (P_1)
			{
				ReInput.controllers.RemoveJoystickFromAllPlayers(P_0);
			}
			QHvleXMfQGGsGSDUArrcLeNstTyw.cUmptiDojEDwOqLAhQgbYiyfxeXu cUmptiDojEDwOqLAhQgbYiyfxeXu = nhsUTPodOQwcYCOQgEAPgJtivczK.rdCVwdZckLhQvWrkFzLfdWrXWFgQ(P_0.id);
			DGwRdGOlPFvMefvreaSvufGXwqlI<Joystick, JoystickMap>.ULpvOcMrCuZQnwHsGOOZRCagYnur uLpvOcMrCuZQnwHsGOOZRCagYnur;
			if (cUmptiDojEDwOqLAhQgbYiyfxeXu != null && cUmptiDojEDwOqLAhQgbYiyfxeXu.zCfbxAiXGysIoVuepKVulKtLysSO != null)
			{
				uLpvOcMrCuZQnwHsGOOZRCagYnur = new DGwRdGOlPFvMefvreaSvufGXwqlI<Joystick, JoystickMap>.ULpvOcMrCuZQnwHsGOOZRCagYnur(P_0, cUmptiDojEDwOqLAhQgbYiyfxeXu.zCfbxAiXGysIoVuepKVulKtLysSO);
			}
			else
			{
				global::rspbeSfkijiKRfPuAyBrBqKNCACZB<JoystickMap> rspbeSfkijiKRfPuAyBrBqKNCACZB2 = maps.boAqYpOioIEEpVVksCrXaVjnRZtp(P_0, true);
				if (rspbeSfkijiKRfPuAyBrBqKNCACZB2 == null)
				{
					rspbeSfkijiKRfPuAyBrBqKNCACZB2 = new global::rspbeSfkijiKRfPuAyBrBqKNCACZB<JoystickMap>(P_0.id);
				}
				uLpvOcMrCuZQnwHsGOOZRCagYnur = new DGwRdGOlPFvMefvreaSvufGXwqlI<Joystick, JoystickMap>.ULpvOcMrCuZQnwHsGOOZRCagYnur(P_0, rspbeSfkijiKRfPuAyBrBqKNCACZB2);
			}
			hENtlJpbLTfyvGNBdnYOTBUpGwmPA.ezcDNeepWSxgQWKjHyrGpxdUzKgaA(uLpvOcMrCuZQnwHsGOOZRCagYnur);
			nhsUTPodOQwcYCOQgEAPgJtivczK.qbixfSsnHwqKeXGuuBbZsxhonLkB(uLpvOcMrCuZQnwHsGOOZRCagYnur);
			GCIETMFbrLtFWbjmhJJzLsuxEbWB.NwCwRIqaKzXsvjtkBWSnlYNaVrQU(P_0);
			maps.layoutManager.Apply();
			if (JCvKtqRTmshFtkQqoOXrAblMeKIo.Count > 0)
			{
				JCvKtqRTmshFtkQqoOXrAblMeKIo.Invoke(new ControllerAssignmentChangedEventArgs(bGWZlHEJQyGZSKuNhdAkKHdjnKdU.id, P_0.id, ControllerType.Joystick, true));
			}
		}

		internal void lGPhcmVsVJOoplnqbMmdmMfIapml(int P_0, bool P_1)
		{
			Joystick joystick = ReInput.controllers.GetJoystick(P_0);
			if (joystick != null)
			{
				VuyGldiugjtXAeHaagwQSjnHJLwfA(joystick, P_1);
			}
		}

		internal void RsDUJgqmoRRNGXaYVNveumbuRvvS(int P_0)
		{
			HENtlJpbLTfyvGNBdnYOTBUpGwmPA hENtlJpbLTfyvGNBdnYOTBUpGwmPA = QecjgvgRSXuPhnYvNrbSsHRqQwjg.AXLlayIlTwJqJNaNzeKccuszIcODb(ControllerType.Joystick);
			if (hENtlJpbLTfyvGNBdnYOTBUpGwmPA.qeQAZQmgxcHqHizaGnELPEdIYlFN(P_0))
			{
				if (hENtlJpbLTfyvGNBdnYOTBUpGwmPA.EiaJdcLRNPgisAQlXkogBqWdcrPqb(P_0) is DGwRdGOlPFvMefvreaSvufGXwqlI<Joystick, JoystickMap>.ULpvOcMrCuZQnwHsGOOZRCagYnur uLpvOcMrCuZQnwHsGOOZRCagYnur)
				{
					nhsUTPodOQwcYCOQgEAPgJtivczK.qbixfSsnHwqKeXGuuBbZsxhonLkB(uLpvOcMrCuZQnwHsGOOZRCagYnur);
				}
				hENtlJpbLTfyvGNBdnYOTBUpGwmPA.VGyDVwkBtTRddOpvLPQiEkZkOaRk(P_0);
				Joystick joystick = ReInput.controllers.GetJoystick(P_0);
				GCIETMFbrLtFWbjmhJJzLsuxEbWB.wUdFOsjHwFtryZkSuYDfCgLNwGrj(joystick);
				if (pXdBLcevqBiBlWzRdLgftOwWzIIZ.Count > 0)
				{
					pXdBLcevqBiBlWzRdLgftOwWzIIZ.Invoke(new ControllerAssignmentChangedEventArgs(bGWZlHEJQyGZSKuNhdAkKHdjnKdU.id, joystick.id, ControllerType.Joystick, false));
				}
			}
		}

		internal void cyVGrkRfGgSHMlENCMQojMfWVtZj(Joystick P_0)
		{
			if (P_0 != null)
			{
				RsDUJgqmoRRNGXaYVNveumbuRvvS(P_0.id);
			}
		}

		internal void dCHAdodjbHMfNRTeMIGTgKSDTQXnB()
		{
			HENtlJpbLTfyvGNBdnYOTBUpGwmPA hENtlJpbLTfyvGNBdnYOTBUpGwmPA = QecjgvgRSXuPhnYvNrbSsHRqQwjg.AXLlayIlTwJqJNaNzeKccuszIcODb(ControllerType.Joystick);
			for (int num = hENtlJpbLTfyvGNBdnYOTBUpGwmPA.rphZqyUfbdoINyXndGfDbQaiIHFM() - 1; num >= 0; num--)
			{
				nhsUTPodOQwcYCOQgEAPgJtivczK.qbixfSsnHwqKeXGuuBbZsxhonLkB(hENtlJpbLTfyvGNBdnYOTBUpGwmPA.gmqWnmpZMnASuZpGLEqmJcwgXIqMA(num) as DGwRdGOlPFvMefvreaSvufGXwqlI<Joystick, JoystickMap>.ULpvOcMrCuZQnwHsGOOZRCagYnur);
				GCIETMFbrLtFWbjmhJJzLsuxEbWB.wUdFOsjHwFtryZkSuYDfCgLNwGrj(hENtlJpbLTfyvGNBdnYOTBUpGwmPA.gmqWnmpZMnASuZpGLEqmJcwgXIqMA(num).hfcnXcmxHjJxWTdCahVjbHZvxlVj());
				int id = hENtlJpbLTfyvGNBdnYOTBUpGwmPA.gmqWnmpZMnASuZpGLEqmJcwgXIqMA(num).hfcnXcmxHjJxWTdCahVjbHZvxlVj().id;
				hENtlJpbLTfyvGNBdnYOTBUpGwmPA.efIhWBBIGFwodHIELLmRiiYFXSzQb(num);
				if (pXdBLcevqBiBlWzRdLgftOwWzIIZ.Count > 0)
				{
					pXdBLcevqBiBlWzRdLgftOwWzIIZ.Invoke(new ControllerAssignmentChangedEventArgs(bGWZlHEJQyGZSKuNhdAkKHdjnKdU.id, id, ControllerType.Joystick, false));
				}
			}
			hENtlJpbLTfyvGNBdnYOTBUpGwmPA.CHDaUwGARteSiOLodcLIyYCDkANd();
		}

		internal void MXQGAlxTWPRnRxzEisMghMTBgLmp(CustomController P_0, bool P_1)
		{
			if (P_0 == null)
			{
				return;
			}
			HENtlJpbLTfyvGNBdnYOTBUpGwmPA hENtlJpbLTfyvGNBdnYOTBUpGwmPA = QecjgvgRSXuPhnYvNrbSsHRqQwjg.AXLlayIlTwJqJNaNzeKccuszIcODb(ControllerType.Custom);
			if (!hENtlJpbLTfyvGNBdnYOTBUpGwmPA.qeQAZQmgxcHqHizaGnELPEdIYlFN(P_0.id))
			{
				if (P_1)
				{
					ReInput.controllers.RemoveCustomControllerFromAllPlayers(P_0);
				}
				global::rspbeSfkijiKRfPuAyBrBqKNCACZB<CustomControllerMap> rspbeSfkijiKRfPuAyBrBqKNCACZB2 = maps.CAfGhcxwHQfmSNHjCdjSSYGOWBwV(P_0, true);
				if (rspbeSfkijiKRfPuAyBrBqKNCACZB2 == null)
				{
					rspbeSfkijiKRfPuAyBrBqKNCACZB2 = new global::rspbeSfkijiKRfPuAyBrBqKNCACZB<CustomControllerMap>(P_0.id);
				}
				DGwRdGOlPFvMefvreaSvufGXwqlI<CustomController, CustomControllerMap>.ULpvOcMrCuZQnwHsGOOZRCagYnur uLpvOcMrCuZQnwHsGOOZRCagYnur = new DGwRdGOlPFvMefvreaSvufGXwqlI<CustomController, CustomControllerMap>.ULpvOcMrCuZQnwHsGOOZRCagYnur(P_0, rspbeSfkijiKRfPuAyBrBqKNCACZB2);
				hENtlJpbLTfyvGNBdnYOTBUpGwmPA.ezcDNeepWSxgQWKjHyrGpxdUzKgaA(uLpvOcMrCuZQnwHsGOOZRCagYnur);
				GCIETMFbrLtFWbjmhJJzLsuxEbWB.NwCwRIqaKzXsvjtkBWSnlYNaVrQU(P_0);
				maps.layoutManager.Apply();
				if (JCvKtqRTmshFtkQqoOXrAblMeKIo.Count > 0)
				{
					JCvKtqRTmshFtkQqoOXrAblMeKIo.Invoke(new ControllerAssignmentChangedEventArgs(bGWZlHEJQyGZSKuNhdAkKHdjnKdU.id, P_0.id, ControllerType.Custom, true));
				}
			}
		}

		internal void KZmBTSSqpAAknwgmTUmepIwjRMPL(int P_0, bool P_1)
		{
			CustomController customController = ReInput.controllers.GetCustomController(P_0);
			if (customController != null)
			{
				MXQGAlxTWPRnRxzEisMghMTBgLmp(customController, P_1);
			}
		}

		internal void huGblDFtlsgFtHJhEOzWTVmbxksi(int P_0)
		{
			HENtlJpbLTfyvGNBdnYOTBUpGwmPA hENtlJpbLTfyvGNBdnYOTBUpGwmPA = QecjgvgRSXuPhnYvNrbSsHRqQwjg.AXLlayIlTwJqJNaNzeKccuszIcODb(ControllerType.Custom);
			if (hENtlJpbLTfyvGNBdnYOTBUpGwmPA.qeQAZQmgxcHqHizaGnELPEdIYlFN(P_0))
			{
				hENtlJpbLTfyvGNBdnYOTBUpGwmPA.EiaJdcLRNPgisAQlXkogBqWdcrPqb(P_0);
				hENtlJpbLTfyvGNBdnYOTBUpGwmPA.VGyDVwkBtTRddOpvLPQiEkZkOaRk(P_0);
				CustomController customController = ReInput.controllers.GetCustomController(P_0);
				GCIETMFbrLtFWbjmhJJzLsuxEbWB.wUdFOsjHwFtryZkSuYDfCgLNwGrj(customController);
				if (pXdBLcevqBiBlWzRdLgftOwWzIIZ.Count > 0)
				{
					pXdBLcevqBiBlWzRdLgftOwWzIIZ.Invoke(new ControllerAssignmentChangedEventArgs(bGWZlHEJQyGZSKuNhdAkKHdjnKdU.id, customController.id, ControllerType.Custom, false));
				}
			}
		}

		internal void YhsbofBlHeceHtebbDOGxILgZimjA(CustomController P_0)
		{
			if (P_0 != null)
			{
				huGblDFtlsgFtHJhEOzWTVmbxksi(P_0.id);
			}
		}

		internal void IQRZFobxGnMmWqXokkTwaShiOehX()
		{
			HENtlJpbLTfyvGNBdnYOTBUpGwmPA hENtlJpbLTfyvGNBdnYOTBUpGwmPA = QecjgvgRSXuPhnYvNrbSsHRqQwjg.AXLlayIlTwJqJNaNzeKccuszIcODb(ControllerType.Custom);
			for (int num = hENtlJpbLTfyvGNBdnYOTBUpGwmPA.rphZqyUfbdoINyXndGfDbQaiIHFM() - 1; num >= 0; num--)
			{
				GCIETMFbrLtFWbjmhJJzLsuxEbWB.wUdFOsjHwFtryZkSuYDfCgLNwGrj(hENtlJpbLTfyvGNBdnYOTBUpGwmPA.gmqWnmpZMnASuZpGLEqmJcwgXIqMA(num).hfcnXcmxHjJxWTdCahVjbHZvxlVj());
				int id = hENtlJpbLTfyvGNBdnYOTBUpGwmPA.gmqWnmpZMnASuZpGLEqmJcwgXIqMA(num).hfcnXcmxHjJxWTdCahVjbHZvxlVj().id;
				hENtlJpbLTfyvGNBdnYOTBUpGwmPA.efIhWBBIGFwodHIELLmRiiYFXSzQb(num);
				if (pXdBLcevqBiBlWzRdLgftOwWzIIZ.Count > 0)
				{
					pXdBLcevqBiBlWzRdLgftOwWzIIZ.Invoke(new ControllerAssignmentChangedEventArgs(bGWZlHEJQyGZSKuNhdAkKHdjnKdU.id, id, ControllerType.Custom, false));
				}
			}
			hENtlJpbLTfyvGNBdnYOTBUpGwmPA.CHDaUwGARteSiOLodcLIyYCDkANd();
		}

		internal CustomController WMSjJLPnBeehZIaSZRTNmYYVULYPA(int P_0)
		{
			CustomController customController = bGWZlHEJQyGZSKuNhdAkKHdjnKdU.vUXRFQkaqtxZmDdZWniajedetQiF.oaWEUwQBJYSYwzCbnvEfgAPDfPNDA(P_0);
			if (customController == null)
			{
				return null;
			}
			MXQGAlxTWPRnRxzEisMghMTBgLmp(customController, false);
			return customController;
		}

		internal void TCIyxsRUzhjACqutHFgzfbhjHzPA(Action<bool, int, int> P_0)
		{
			huTumsIDsvkxwwIwHJAaVGhQCSXI<Joystick, JoystickMap>(ControllerType.Joystick, P_0);
		}

		internal void mnweXxcHtmDtTINFeirDUFpdvuEmA(Keyboard P_0, CsuWQDIPMTIxKfmbavtLlqKTIzLM P_1, Action<bool, int, int> P_2)
		{
			if (!TlbyyHkskWZrSZcTJCoiWBTwNtSg || !P_0.enabled)
			{
				return;
			}
			rnHMBPYpsqutWTXFhuflEMRSJeND tlVbUEFZvHpkWbdMldVYtEFmvFQU = QZWOxJToNpPZTYJKdjKDNrZDcbAQ.tlVbUEFZvHpkWbdMldVYtEFmvFQU;
			bool flag = false;
			FsyiqPdJeSfbLIuiSYvjZeDpZMzW fsyiqPdJeSfbLIuiSYvjZeDpZMzW = QecjgvgRSXuPhnYvNrbSsHRqQwjg.AXLlayIlTwJqJNaNzeKccuszIcODb(ControllerType.Keyboard).EiaJdcLRNPgisAQlXkogBqWdcrPqb(0).ycfaKniCLOzZqlQviANrBfbEZIlRA();
			int num = fsyiqPdJeSfbLIuiSYvjZeDpZMzW.ejOOZrUqJLRyRGoRofwTThHfNEkF();
			KeyCombinationOverrideMode keyCombinationOverrideMode = ReInput.configVars.keyCombinationOverrideMode;
			bool flag2 = keyCombinationOverrideMode == KeyCombinationOverrideMode.None;
			CsuWQDIPMTIxKfmbavtLlqKTIzLM.hheoAHILbEbaXrRjztLcIAXiBsyfA hheoAHILbEbaXrRjztLcIAXiBsyfA = ((keyCombinationOverrideMode == KeyCombinationOverrideMode.Overlap) ? CsuWQDIPMTIxKfmbavtLlqKTIzLM.hheoAHILbEbaXrRjztLcIAXiBsyfA.OverlapModifiers : CsuWQDIPMTIxKfmbavtLlqKTIzLM.hheoAHILbEbaXrRjztLcIAXiBsyfA.Normal);
			aDUCqjsWGxDXIwuIpmtzILnQOsNU.QqSgYOWdZnQFGGSkquHvzqsuZNsj qqSgYOWdZnQFGGSkquHvzqsuZNsj = new aDUCqjsWGxDXIwuIpmtzILnQOsNU.QqSgYOWdZnQFGGSkquHvzqsuZNsj
			{
				ibFCRyhghkARJpZnLBpjSRhOjoVRA = ReInput.configVars.generateKeyEventsOnKeyCombinationOverride
			};
			for (int i = 0; i < num; i++)
			{
				KeyboardMap keyboardMap = (KeyboardMap)fsyiqPdJeSfbLIuiSYvjZeDpZMzW.QIeXsLdCiAXGGxCgarjGtHyqkDbM(i);
				if (!keyboardMap.enabled)
				{
					continue;
				}
				AList<ActionElementMap> aList = keyboardMap.hycZGsxqYWqTYWkWVVCDVrvexwwT();
				int count = aList._count;
				for (int j = 0; j < count; j++)
				{
					ActionElementMap actionElementMap = aList._items[j];
					if (!actionElementMap.YbgQyWQdQcTTSlKYNScpqBbjmQQo)
					{
						continue;
					}
					int actionId = actionElementMap._actionId;
					KeyboardKeyCode keyboardKeyCode = actionElementMap._keyboardKeyCode;
					ModifierKeyFlags modifierKeyFlags = actionElementMap.modifierKeyFlags;
					bool flag3 = false;
					bool flag4 = false;
					ButtonStateFlags buttonStateFlags;
					bool flag5;
					if (modifierKeyFlags != ModifierKeyFlags.None)
					{
						buttonStateFlags = (P_0.DbSOkpYFUKHZTIVwRZLUnRZcAxZb(keyboardKeyCode, modifierKeyFlags) ? ButtonStateFlags.On : ButtonStateFlags.Off);
						flag5 = buttonStateFlags != ButtonStateFlags.Off;
						if (!flag5)
						{
							aDUCqjsWGxDXIwuIpmtzILnQOsNU aDUCqjsWGxDXIwuIpmtzILnQOsNU2 = aDUCqjsWGxDXIwuIpmtzILnQOsNU.XwRyTksJzqYYxmCPxRSBhVUpgmdr(actionElementMap.LQceMJAxYgRpolrwLwsLBxilJMmNA);
							if (aDUCqjsWGxDXIwuIpmtzILnQOsNU2 != null && aDUCqjsWGxDXIwuIpmtzILnQOsNU2.ZQsbdMorGuRtmeFmXBrsodfTimOg(true) != ButtonStateFlags.Off)
							{
								flag5 = true;
							}
						}
					}
					else
					{
						buttonStateFlags = P_0.HtEPdFGEEDRbHfBhLxoPlPNKFngt(actionElementMap.QFmDebRUzKGSVIJAwVaJJAOkGJANA);
						flag5 = buttonStateFlags != ButtonStateFlags.Off;
					}
					if (flag5)
					{
						if (!flag2)
						{
							flag3 = P_1.iLrGMmeeaZpLsqbHQuWrqKbMDUYDb(keyboardKeyCode, modifierKeyFlags, hheoAHILbEbaXrRjztLcIAXiBsyfA, out flag4);
						}
						if (flag4 || modifierKeyFlags != ModifierKeyFlags.None)
						{
							qqSgYOWdZnQFGGSkquHvzqsuZNsj.zuRCwOuZzjOIuFFNEgzifviEJDhl = flag3;
							aDUCqjsWGxDXIwuIpmtzILnQOsNU aDUCqjsWGxDXIwuIpmtzILnQOsNU2 = aDUCqjsWGxDXIwuIpmtzILnQOsNU.jINDQHrRKJzHKYFAuIzfWuflMMYt(actionElementMap.LQceMJAxYgRpolrwLwsLBxilJMmNA, qqSgYOWdZnQFGGSkquHvzqsuZNsj);
							if (keyCombinationOverrideMode == KeyCombinationOverrideMode.Pause)
							{
								aDUCqjsWGxDXIwuIpmtzILnQOsNU2.mcsbuZcCdaJYsSbHaCsJDLJBvxQNB(flag3);
							}
							else if (flag3)
							{
								aDUCqjsWGxDXIwuIpmtzILnQOsNU2.mcsbuZcCdaJYsSbHaCsJDLJBvxQNB(true);
							}
							aDUCqjsWGxDXIwuIpmtzILnQOsNU2.vCNTahVJpmsRyMVMqQQEksdVewhQ(ReInput.currentUpdateLoop, buttonStateFlags, true);
							buttonStateFlags = aDUCqjsWGxDXIwuIpmtzILnQOsNU2.ZQsbdMorGuRtmeFmXBrsodfTimOg(true);
						}
					}
					if (buttonStateFlags != ButtonStateFlags.Off)
					{
						ppleeAwRcdDSIkuyUfNshNMbqdbkc(P_0, keyboardMap, actionElementMap, tlVbUEFZvHpkWbdMldVYtEFmvFQU, buttonStateFlags);
						P_2(arg1: true, bGWZlHEJQyGZSKuNhdAkKHdjnKdU.CgPagdlzMlCQxkbRTPOoePMzAXof, actionId);
						flag = true;
						continue;
					}
					if (tlVbUEFZvHpkWbdMldVYtEFmvFQU.GVDFEqngZwhITfmywEFnaWxkfuIj != 0f)
					{
						tlVbUEFZvHpkWbdMldVYtEFmvFQU.GVDFEqngZwhITfmywEFnaWxkfuIj = 0f;
					}
					if (tlVbUEFZvHpkWbdMldVYtEFmvFQU.GYVVVrHzwlIAcIcvDqoxpxpCaVcR != ButtonStateFlags.Off)
					{
						tlVbUEFZvHpkWbdMldVYtEFmvFQU.GYVVVrHzwlIAcIcvDqoxpxpCaVcR = ButtonStateFlags.Off;
					}
					P_2(arg1: false, bGWZlHEJQyGZSKuNhdAkKHdjnKdU.CgPagdlzMlCQxkbRTPOoePMzAXof, actionId);
				}
			}
			if (flag)
			{
				OjmYEDXBLsFzpKGzcCiBiDFbugUMA = ReInput.unscaledTime;
			}
		}

		private static void ppleeAwRcdDSIkuyUfNshNMbqdbkc(Keyboard P_0, ControllerMap P_1, ActionElementMap P_2, rnHMBPYpsqutWTXFhuflEMRSJeND P_3, ButtonStateFlags P_4)
		{
			float num = (((P_4 & ButtonStateFlags.On) != ButtonStateFlags.Off) ? 1f : 0f);
			if (num != 0f && P_2._axisContribution == Pole.Negative)
			{
				num *= -1f;
			}
			P_3.GVDFEqngZwhITfmywEFnaWxkfuIj = num;
			P_3.GYVVVrHzwlIAcIcvDqoxpxpCaVcR = P_4;
			P_3.VPJMQTBETVcQRQbIaqsLjclrDPKU = P_0;
			P_3.bkAevtucDYbLRKBlEtWBEHoXmmhl = ControllerType.Keyboard;
			P_3.BbGeFKXgfIHGHvufZKIoHbwcnLEE = ControllerElementType.Button;
			P_3.VCmQrtbvKuWXKVTbqrzbzwQqppqE = P_2;
			P_3.GrzDQSZGWijLGIMsJdFEHcELITXc = P_1;
			if (P_3.ZpuNVftERwNPwyXMGuuddBSPOSLA)
			{
				P_3.ZpuNVftERwNPwyXMGuuddBSPOSLA = false;
			}
			if (P_3.xquXmtHaraoXmZXpWZpJOigVHVCt)
			{
				P_3.xquXmtHaraoXmZXpWZpJOigVHVCt = false;
			}
		}

		internal void qccwBfIvrVoMwBEKbBZkFVUWlBFB(Mouse P_0, Action<bool, int, int> P_1)
		{
			if (!lRGGFcEsxqLxQrnylLUfDadxvkQX || !P_0.enabled)
			{
				return;
			}
			FsyiqPdJeSfbLIuiSYvjZeDpZMzW fsyiqPdJeSfbLIuiSYvjZeDpZMzW = QecjgvgRSXuPhnYvNrbSsHRqQwjg.AXLlayIlTwJqJNaNzeKccuszIcODb(ControllerType.Mouse).EiaJdcLRNPgisAQlXkogBqWdcrPqb(0).ycfaKniCLOzZqlQviANrBfbEZIlRA();
			rnHMBPYpsqutWTXFhuflEMRSJeND tlVbUEFZvHpkWbdMldVYtEFmvFQU = QZWOxJToNpPZTYJKdjKDNrZDcbAQ.tlVbUEFZvHpkWbdMldVYtEFmvFQU;
			bool flag = false;
			int num = fsyiqPdJeSfbLIuiSYvjZeDpZMzW.ejOOZrUqJLRyRGoRofwTThHfNEkF();
			for (int i = 0; i < num; i++)
			{
				MouseMap mouseMap = (MouseMap)fsyiqPdJeSfbLIuiSYvjZeDpZMzW.QIeXsLdCiAXGGxCgarjGtHyqkDbM(i);
				if (!mouseMap.enabled)
				{
					continue;
				}
				AList<ActionElementMap> aList = mouseMap.JpUeYJtbpkbbatKXpctUbIMGJOCyA();
				if (aList != null)
				{
					int count = aList._count;
					for (int j = 0; j < count; j++)
					{
						ActionElementMap actionElementMap = aList._items[j];
						if (!actionElementMap.YbgQyWQdQcTTSlKYNScpqBbjmQQo || actionElementMap._elementType != ControllerElementType.Axis)
						{
							continue;
						}
						int actionId = actionElementMap._actionId;
						if (!P_0.HewsLcYVWspnnafbvCZAwXWnAcXZ(actionElementMap, actionId, true, false, out var num2))
						{
							continue;
						}
						if (num2 == 0f)
						{
							P_0.HewsLcYVWspnnafbvCZAwXWnAcXZ(actionElementMap, actionId, true, true, out var num3);
							if (num3 == 0f)
							{
								P_1(arg1: false, bGWZlHEJQyGZSKuNhdAkKHdjnKdU.CgPagdlzMlCQxkbRTPOoePMzAXof, actionId);
								continue;
							}
						}
						tlVbUEFZvHpkWbdMldVYtEFmvFQU.GVDFEqngZwhITfmywEFnaWxkfuIj = num2;
						tlVbUEFZvHpkWbdMldVYtEFmvFQU.VPJMQTBETVcQRQbIaqsLjclrDPKU = P_0;
						tlVbUEFZvHpkWbdMldVYtEFmvFQU.bkAevtucDYbLRKBlEtWBEHoXmmhl = ControllerType.Mouse;
						tlVbUEFZvHpkWbdMldVYtEFmvFQU.BbGeFKXgfIHGHvufZKIoHbwcnLEE = ControllerElementType.Axis;
						tlVbUEFZvHpkWbdMldVYtEFmvFQU.VCmQrtbvKuWXKVTbqrzbzwQqppqE = actionElementMap;
						tlVbUEFZvHpkWbdMldVYtEFmvFQU.GrzDQSZGWijLGIMsJdFEHcELITXc = mouseMap;
						if (tlVbUEFZvHpkWbdMldVYtEFmvFQU.xquXmtHaraoXmZXpWZpJOigVHVCt)
						{
							tlVbUEFZvHpkWbdMldVYtEFmvFQU.xquXmtHaraoXmZXpWZpJOigVHVCt = false;
						}
						if (tlVbUEFZvHpkWbdMldVYtEFmvFQU.FaPaeazVzporamyzRoNXYHoPKgBM != AxisCoordinateMode.Relative)
						{
							tlVbUEFZvHpkWbdMldVYtEFmvFQU.FaPaeazVzporamyzRoNXYHoPKgBM = AxisCoordinateMode.Relative;
						}
						P_1(arg1: true, bGWZlHEJQyGZSKuNhdAkKHdjnKdU.CgPagdlzMlCQxkbRTPOoePMzAXof, actionId);
						flag = true;
					}
				}
				AList<ActionElementMap> aList2 = mouseMap.hycZGsxqYWqTYWkWVVCDVrvexwwT();
				if (aList2 == null)
				{
					continue;
				}
				int count2 = aList2._count;
				for (int k = 0; k < count2; k++)
				{
					ActionElementMap actionElementMap2 = aList2._items[k];
					if (!actionElementMap2.YbgQyWQdQcTTSlKYNScpqBbjmQQo || actionElementMap2._elementType != ControllerElementType.Button)
					{
						continue;
					}
					int actionId2 = actionElementMap2._actionId;
					if (!P_0.jypwSAuFOIbgtLQDRpJBjOHqnDCE(actionElementMap2, actionId2, out var gVDFEqngZwhITfmywEFnaWxkfuIj, out tlVbUEFZvHpkWbdMldVYtEFmvFQU.ZpuNVftERwNPwyXMGuuddBSPOSLA))
					{
						continue;
					}
					ButtonStateFlags buttonStateFlags = P_0.HtEPdFGEEDRbHfBhLxoPlPNKFngt(actionElementMap2.QFmDebRUzKGSVIJAwVaJJAOkGJANA);
					if (buttonStateFlags == ButtonStateFlags.Off)
					{
						P_1(arg1: false, bGWZlHEJQyGZSKuNhdAkKHdjnKdU.CgPagdlzMlCQxkbRTPOoePMzAXof, actionId2);
						continue;
					}
					tlVbUEFZvHpkWbdMldVYtEFmvFQU.GVDFEqngZwhITfmywEFnaWxkfuIj = gVDFEqngZwhITfmywEFnaWxkfuIj;
					tlVbUEFZvHpkWbdMldVYtEFmvFQU.GYVVVrHzwlIAcIcvDqoxpxpCaVcR = buttonStateFlags;
					tlVbUEFZvHpkWbdMldVYtEFmvFQU.VPJMQTBETVcQRQbIaqsLjclrDPKU = P_0;
					tlVbUEFZvHpkWbdMldVYtEFmvFQU.bkAevtucDYbLRKBlEtWBEHoXmmhl = ControllerType.Mouse;
					tlVbUEFZvHpkWbdMldVYtEFmvFQU.BbGeFKXgfIHGHvufZKIoHbwcnLEE = ControllerElementType.Button;
					tlVbUEFZvHpkWbdMldVYtEFmvFQU.VCmQrtbvKuWXKVTbqrzbzwQqppqE = actionElementMap2;
					tlVbUEFZvHpkWbdMldVYtEFmvFQU.GrzDQSZGWijLGIMsJdFEHcELITXc = mouseMap;
					if (tlVbUEFZvHpkWbdMldVYtEFmvFQU.ZpuNVftERwNPwyXMGuuddBSPOSLA)
					{
						tlVbUEFZvHpkWbdMldVYtEFmvFQU.ZpuNVftERwNPwyXMGuuddBSPOSLA = false;
					}
					if (tlVbUEFZvHpkWbdMldVYtEFmvFQU.xquXmtHaraoXmZXpWZpJOigVHVCt)
					{
						tlVbUEFZvHpkWbdMldVYtEFmvFQU.xquXmtHaraoXmZXpWZpJOigVHVCt = false;
					}
					P_1(arg1: true, bGWZlHEJQyGZSKuNhdAkKHdjnKdU.CgPagdlzMlCQxkbRTPOoePMzAXof, actionId2);
					flag = true;
				}
			}
			if (flag)
			{
				KnSGhRgJIVDtKkrPQrWCJccLdAEb = ReInput.unscaledTime;
			}
		}

		internal void itsVoRinRQZGDWyRbddweJGTPvPU(Action<bool, int, int> P_0)
		{
			huTumsIDsvkxwwIwHJAaVGhQCSXI<CustomController, CustomControllerMap>(ControllerType.Custom, P_0);
		}

		private void huTumsIDsvkxwwIwHJAaVGhQCSXI<_0001, _0002>(ControllerType P_0, Action<bool, int, int> P_1) where _0001 : ControllerWithAxes where _0002 : ControllerMapWithAxes
		{
			DGwRdGOlPFvMefvreaSvufGXwqlI<_0001, _0002> dGwRdGOlPFvMefvreaSvufGXwqlI = (DGwRdGOlPFvMefvreaSvufGXwqlI<_0001, _0002>)QecjgvgRSXuPhnYvNrbSsHRqQwjg.AXLlayIlTwJqJNaNzeKccuszIcODb(P_0);
			rnHMBPYpsqutWTXFhuflEMRSJeND tlVbUEFZvHpkWbdMldVYtEFmvFQU = QZWOxJToNpPZTYJKdjKDNrZDcbAQ.tlVbUEFZvHpkWbdMldVYtEFmvFQU;
			int num = dGwRdGOlPFvMefvreaSvufGXwqlI.rphZqyUfbdoINyXndGfDbQaiIHFM();
			for (int i = 0; i < num; i++)
			{
				DGwRdGOlPFvMefvreaSvufGXwqlI<_0001, _0002>.ULpvOcMrCuZQnwHsGOOZRCagYnur uLpvOcMrCuZQnwHsGOOZRCagYnur = dGwRdGOlPFvMefvreaSvufGXwqlI.IqlJUjIBLQbuSkAhcRvowzpPOQIC(i);
				_0001 vEpnAhSIoVrCnOfAmeqwGuTGoWnB = uLpvOcMrCuZQnwHsGOOZRCagYnur.vEpnAhSIoVrCnOfAmeqwGuTGoWnB;
				if (!vEpnAhSIoVrCnOfAmeqwGuTGoWnB.enabled)
				{
					continue;
				}
				global::rspbeSfkijiKRfPuAyBrBqKNCACZB<_0002> urKiLjIJcqceLbXuNYNvuMSWJkNF = uLpvOcMrCuZQnwHsGOOZRCagYnur.urKiLjIJcqceLbXuNYNvuMSWJkNF;
				bool flag = false;
				int num2 = urKiLjIJcqceLbXuNYNvuMSWJkNF.ejOOZrUqJLRyRGoRofwTThHfNEkF();
				for (int j = 0; j < num2; j++)
				{
					_0002 val = urKiLjIJcqceLbXuNYNvuMSWJkNF.xmIhmmDDQdCDzpiurLdyJADZcUhZ(j);
					if (!val.enabled)
					{
						continue;
					}
					AList<ActionElementMap> aList = val.JpUeYJtbpkbbatKXpctUbIMGJOCyA();
					if (aList != null)
					{
						int count = aList._count;
						for (int k = 0; k < count; k++)
						{
							ActionElementMap actionElementMap = aList._items[k];
							if (!actionElementMap.YbgQyWQdQcTTSlKYNScpqBbjmQQo || actionElementMap._elementType != ControllerElementType.Axis)
							{
								continue;
							}
							int actionId = actionElementMap._actionId;
							if (!vEpnAhSIoVrCnOfAmeqwGuTGoWnB.HewsLcYVWspnnafbvCZAwXWnAcXZ(actionElementMap, actionId, false, false, out var num3))
							{
								continue;
							}
							if (num3 == 0f)
							{
								vEpnAhSIoVrCnOfAmeqwGuTGoWnB.HewsLcYVWspnnafbvCZAwXWnAcXZ(actionElementMap, actionId, false, true, out var num4);
								if (num4 == 0f)
								{
									P_1(arg1: false, bGWZlHEJQyGZSKuNhdAkKHdjnKdU.CgPagdlzMlCQxkbRTPOoePMzAXof, actionId);
									continue;
								}
							}
							tlVbUEFZvHpkWbdMldVYtEFmvFQU.GVDFEqngZwhITfmywEFnaWxkfuIj = num3;
							tlVbUEFZvHpkWbdMldVYtEFmvFQU.VPJMQTBETVcQRQbIaqsLjclrDPKU = vEpnAhSIoVrCnOfAmeqwGuTGoWnB;
							tlVbUEFZvHpkWbdMldVYtEFmvFQU.bkAevtucDYbLRKBlEtWBEHoXmmhl = P_0;
							tlVbUEFZvHpkWbdMldVYtEFmvFQU.BbGeFKXgfIHGHvufZKIoHbwcnLEE = ControllerElementType.Axis;
							tlVbUEFZvHpkWbdMldVYtEFmvFQU.VCmQrtbvKuWXKVTbqrzbzwQqppqE = actionElementMap;
							tlVbUEFZvHpkWbdMldVYtEFmvFQU.GrzDQSZGWijLGIMsJdFEHcELITXc = val;
							tlVbUEFZvHpkWbdMldVYtEFmvFQU.xquXmtHaraoXmZXpWZpJOigVHVCt = vEpnAhSIoVrCnOfAmeqwGuTGoWnB.calibrationMap.Axes[actionElementMap.QFmDebRUzKGSVIJAwVaJJAOkGJANA].applyRangeCalibration;
							tlVbUEFZvHpkWbdMldVYtEFmvFQU.FaPaeazVzporamyzRoNXYHoPKgBM = vEpnAhSIoVrCnOfAmeqwGuTGoWnB.Axes[actionElementMap.elementIndex].XPJMXvcDLsDoYlwHEhEAofLIBGih?._dataFormat ?? AxisCoordinateMode.Absolute;
							P_1(arg1: true, bGWZlHEJQyGZSKuNhdAkKHdjnKdU.CgPagdlzMlCQxkbRTPOoePMzAXof, actionId);
							flag = true;
						}
					}
					AList<ActionElementMap> aList2 = val.hycZGsxqYWqTYWkWVVCDVrvexwwT();
					if (aList2 != null)
					{
						int count2 = aList2._count;
						for (int l = 0; l < count2; l++)
						{
							ActionElementMap actionElementMap2 = aList2._items[l];
							if (!actionElementMap2.YbgQyWQdQcTTSlKYNScpqBbjmQQo || actionElementMap2._elementType != ControllerElementType.Button)
							{
								continue;
							}
							int actionId2 = actionElementMap2._actionId;
							float gVDFEqngZwhITfmywEFnaWxkfuIj = 0f;
							int qFmDebRUzKGSVIJAwVaJJAOkGJANA = actionElementMap2.QFmDebRUzKGSVIJAwVaJJAOkGJANA;
							if (!ZoxdHujwUPbqmPZFyIkmnygBpiqB(vEpnAhSIoVrCnOfAmeqwGuTGoWnB, i, qFmDebRUzKGSVIJAwVaJJAOkGJANA, actionElementMap2, urKiLjIJcqceLbXuNYNvuMSWJkNF, actionId2, ref gVDFEqngZwhITfmywEFnaWxkfuIj) && !vEpnAhSIoVrCnOfAmeqwGuTGoWnB.jypwSAuFOIbgtLQDRpJBjOHqnDCE(actionElementMap2, actionId2, out gVDFEqngZwhITfmywEFnaWxkfuIj, out tlVbUEFZvHpkWbdMldVYtEFmvFQU.ZpuNVftERwNPwyXMGuuddBSPOSLA))
							{
								continue;
							}
							ButtonStateFlags buttonStateFlags = vEpnAhSIoVrCnOfAmeqwGuTGoWnB.HtEPdFGEEDRbHfBhLxoPlPNKFngt(actionElementMap2.QFmDebRUzKGSVIJAwVaJJAOkGJANA);
							if (buttonStateFlags == ButtonStateFlags.Off)
							{
								P_1(arg1: false, bGWZlHEJQyGZSKuNhdAkKHdjnKdU.CgPagdlzMlCQxkbRTPOoePMzAXof, actionId2);
								continue;
							}
							tlVbUEFZvHpkWbdMldVYtEFmvFQU.GVDFEqngZwhITfmywEFnaWxkfuIj = gVDFEqngZwhITfmywEFnaWxkfuIj;
							tlVbUEFZvHpkWbdMldVYtEFmvFQU.GYVVVrHzwlIAcIcvDqoxpxpCaVcR = buttonStateFlags;
							tlVbUEFZvHpkWbdMldVYtEFmvFQU.VPJMQTBETVcQRQbIaqsLjclrDPKU = vEpnAhSIoVrCnOfAmeqwGuTGoWnB;
							tlVbUEFZvHpkWbdMldVYtEFmvFQU.bkAevtucDYbLRKBlEtWBEHoXmmhl = P_0;
							tlVbUEFZvHpkWbdMldVYtEFmvFQU.BbGeFKXgfIHGHvufZKIoHbwcnLEE = ControllerElementType.Button;
							tlVbUEFZvHpkWbdMldVYtEFmvFQU.VCmQrtbvKuWXKVTbqrzbzwQqppqE = actionElementMap2;
							tlVbUEFZvHpkWbdMldVYtEFmvFQU.GrzDQSZGWijLGIMsJdFEHcELITXc = val;
							if (tlVbUEFZvHpkWbdMldVYtEFmvFQU.xquXmtHaraoXmZXpWZpJOigVHVCt)
							{
								tlVbUEFZvHpkWbdMldVYtEFmvFQU.xquXmtHaraoXmZXpWZpJOigVHVCt = false;
							}
							P_1(arg1: true, bGWZlHEJQyGZSKuNhdAkKHdjnKdU.CgPagdlzMlCQxkbRTPOoePMzAXof, actionId2);
							flag = true;
						}
					}
					if (flag)
					{
						uLpvOcMrCuZQnwHsGOOZRCagYnur.SPyBrPgaASIalGixWiFBOAxqAMxQ();
					}
				}
			}
		}

		private bool ZoxdHujwUPbqmPZFyIkmnygBpiqB<_0001>(ControllerWithAxes P_0, int P_1, int P_2, ActionElementMap P_3, global::rspbeSfkijiKRfPuAyBrBqKNCACZB<_0001> P_4, int P_5, ref float P_6) where _0001 : ControllerMapWithAxes
		{
			if (!P_0.KRqNAliDQUoGilZWSpebheoTCzwBA.IsUnknownHatCardinal(P_2))
			{
				return false;
			}
			UnknownControllerHat.HatButtons unknownHatButtons = P_0.KRqNAliDQUoGilZWSpebheoTCzwBA.GetUnknownHatButtons(P_2);
			if (vgUVJSxPaXtvXrTkQTqpvSJZrsT(unknownHatButtons, P_1, P_4))
			{
				unknownHatButtons.GetNeighbors(P_2, out var neighbor, out var neighbor2);
				if (P_0.GetButton(neighbor) || P_0.GetButton(neighbor2))
				{
					if (!P_0.NoHfMpjDjBVsujBHbffpLSKUGLaJ(P_3, P_5, true, out P_6))
					{
						return false;
					}
					return true;
				}
			}
			return false;
		}

		private bool vgUVJSxPaXtvXrTkQTqpvSJZrsT<_0001>(UnknownControllerHat.HatButtons P_0, int P_1, global::rspbeSfkijiKRfPuAyBrBqKNCACZB<_0001> P_2) where _0001 : ControllerMapWithAxes
		{
			if (P_0 == null)
			{
				return false;
			}
			if (ReInput.configVars.force4WayHats)
			{
				return true;
			}
			if (BLTaHaqXebArNqCAsIjQUpbYhFPDA(P_0, P_1, P_2))
			{
				return false;
			}
			return true;
		}

		private bool BLTaHaqXebArNqCAsIjQUpbYhFPDA<_0001>(UnknownControllerHat.HatButtons P_0, int P_1, global::rspbeSfkijiKRfPuAyBrBqKNCACZB<_0001> P_2) where _0001 : ControllerMapWithAxes
		{
			if (P_2 == null)
			{
				return false;
			}
			int num = P_2.ejOOZrUqJLRyRGoRofwTThHfNEkF();
			for (int i = 0; i < num; i++)
			{
				IList<ActionElementMap> buttonMaps = P_2.xmIhmmDDQdCDzpiurLdyJADZcUhZ(i).ButtonMaps;
				if (buttonMaps == null)
				{
					continue;
				}
				int count = buttonMaps.Count;
				for (int j = 0; j < count; j++)
				{
					int qFmDebRUzKGSVIJAwVaJJAOkGJANA = buttonMaps[j].QFmDebRUzKGSVIJAwVaJJAOkGJANA;
					if (buttonMaps[j]._actionId >= 0 && P_0.IsCorner(qFmDebRUzKGSVIJAwVaJJAOkGJANA))
					{
						return true;
					}
				}
			}
			return false;
		}
	}

	private const string YGrSpTEZLEdmMxDEGshWEDrVLjBH = "player";

	private readonly rrNUAxqqEizlnWVKRaqVmKdJebkM vUXRFQkaqtxZmDdZWniajedetQiF;

	private bool PHKXYkgGSXkUnPlxPcfSpxjNGNtm;

	private int CgPagdlzMlCQxkbRTPOoePMzAXof;

	private string yKFVjyDGKcomwspxjDzFtHKPHTAD;

	private string RbwdENJmjKNKEXzRYPJHjHWNfQuf;

	private readonly string nvhJezCzKlMIZSSUhuJtaSeZTZjt;

	private bool nlQfaOUQEOypRgVArWSgAzwXYGAA;

	private readonly int cJIHaPRbmurRvOwLumpIEntTbHmu;

	private readonly IrUdJNwpbYbfRTthWbFTKoJUwPss cKifhOaUXvphNajXfMFxCvtoAGKu;

	private int bbCdBpHqOFMapFmjGbHLaZGqrJIHb;

	public readonly ControllerHelper controllers;

	public int id
	{
		get
		{
			if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
			{
				ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
				return -1;
			}
			return CgPagdlzMlCQxkbRTPOoePMzAXof;
		}
		internal set
		{
			cKgHFwzPBZHnmdSQnpTDGGjWnsNwA(num);
		}
	}

	public string name
	{
		get
		{
			if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
			{
				ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
				return string.Empty;
			}
			return yKFVjyDGKcomwspxjDzFtHKPHTAD;
		}
		internal set
		{
			SdUbBHhFXPOIBMsXbURkevvTfgjv(text);
		}
	}

	public string descriptiveName
	{
		get
		{
			if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
			{
				ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
				return string.Empty;
			}
			if (!LocalizationManager.isEnabled)
			{
				return RbwdENJmjKNKEXzRYPJHjHWNfQuf;
			}
			return cKifhOaUXvphNajXfMFxCvtoAGKu.aLsidTWLDaQPOPmyxGbWHeMTGfoEA();
		}
		internal set
		{
			RlWERwWzkcMkufYWVTscyKKhMLlg(text);
		}
	}

	public bool isPlaying
	{
		get
		{
			if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
			{
				ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
				return false;
			}
			return nlQfaOUQEOypRgVArWSgAzwXYGAA;
		}
		set
		{
			nlQfaOUQEOypRgVArWSgAzwXYGAA = value;
		}
	}

	internal string nonLocalizedDescriptiveName
	{
		get
		{
			return RbwdENJmjKNKEXzRYPJHjHWNfQuf;
		}
		set
		{
			RbwdENJmjKNKEXzRYPJHjHWNfQuf = value;
			cKifhOaUXvphNajXfMFxCvtoAGKu.qFSeqqVPfIqnwwFRvTgDucKqgogy();
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

	internal Player(bool P_0, int P_1, string P_2, string P_3, string P_4, spMACGdyRGKOkwMouVwTkXeYbAaQ P_5, ControllerMapLayoutManager.cUhsarZCgVkkiQMvHfbBJdlcDTAR P_6, ControllerMapEnabler.myTUEzsWwrinEGyZklokhnLFhKWB P_7)
	{
		PHKXYkgGSXkUnPlxPcfSpxjNGNtm = P_0;
		CgPagdlzMlCQxkbRTPOoePMzAXof = P_1;
		yKFVjyDGKcomwspxjDzFtHKPHTAD = P_2;
		RbwdENJmjKNKEXzRYPJHjHWNfQuf = P_3;
		nvhJezCzKlMIZSSUhuJtaSeZTZjt = P_4;
		cJIHaPRbmurRvOwLumpIEntTbHmu = ReInput.id;
		cKifhOaUXvphNajXfMFxCvtoAGKu = IrUdJNwpbYbfRTthWbFTKoJUwPss.egIgsRAtxYduPLAEXxfeJATQfeVg(this);
		controllers = new ControllerHelper(this, P_5, P_6, P_7);
		vUXRFQkaqtxZmDdZWniajedetQiF = ReInput.jCkgZLcnXoMycBxzcMXWvnUfSROEb;
		kfEsCAAFejRZmDDBjGXfKAhlhtGkA();
	}

	internal void cKgHFwzPBZHnmdSQnpTDGGjWnsNwA(int P_0)
	{
		CgPagdlzMlCQxkbRTPOoePMzAXof = P_0;
	}

	internal void SdUbBHhFXPOIBMsXbURkevvTfgjv(string P_0)
	{
		yKFVjyDGKcomwspxjDzFtHKPHTAD = P_0;
	}

	internal void RlWERwWzkcMkufYWVTscyKKhMLlg(string P_0)
	{
		nonLocalizedDescriptiveName = P_0;
	}

	private string Rewired_002EInternal_002ELocalization_002EINameLocalizerSource_002Eget_keyCategory()
	{
		return "player";
	}

	private string Rewired_002EInternal_002ELocalization_002EINameLocalizerSource_002Eget_scriptingName()
	{
		return yKFVjyDGKcomwspxjDzFtHKPHTAD;
	}

	private string Rewired_002EInternal_002ELocalization_002EINameLocalizerSource_002Eget_nonLocalizedDescriptiveName()
	{
		return RbwdENJmjKNKEXzRYPJHjHWNfQuf;
	}

	private void Rewired_002EInternal_002ELocalization_002EINameLocalizerSource_002Eset_nonLocalizedDescriptiveName(string value)
	{
		RbwdENJmjKNKEXzRYPJHjHWNfQuf = value;
	}

	private string Rewired_002EInternal_002ELocalization_002EINameLocalizerSource_002Eget_key()
	{
		return nvhJezCzKlMIZSSUhuJtaSeZTZjt;
	}

	private int Rewired_002EInternal_002ELocalization_002EINameLocalizerSource_002Eget_autoGeneratedValueFlags()
	{
		return bbCdBpHqOFMapFmjGbHLaZGqrJIHb;
	}

	private void Rewired_002EInternal_002ELocalization_002EINameLocalizerSource_002Eset_autoGeneratedValueFlags(int value)
	{
		bbCdBpHqOFMapFmjGbHLaZGqrJIHb = value;
	}

	public PlayerSaveData GetSaveData(bool userAssignableMapsOnly)
	{
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return default;
		}
		return new PlayerSaveData(controllers.maps.GetAllMapSaveData<JoystickMapSaveData>(userAssignableMapsOnly), controllers.maps.GetAllMapSaveData<KeyboardMapSaveData>(userAssignableMapsOnly), controllers.maps.GetAllMapSaveData<MouseMapSaveData>(userAssignableMapsOnly), controllers.maps.GetAllMapSaveData<CustomControllerMapSaveData>(userAssignableMapsOnly), ReInput.mapping.GetInputBehaviors(CgPagdlzMlCQxkbRTPOoePMzAXof));
	}

	public bool GetButton(string actionName)
	{
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return false;
		}
		return vUXRFQkaqtxZmDdZWniajedetQiF.PKzDxdNXFVjWIeVjZiJxNOwUmSLU(CgPagdlzMlCQxkbRTPOoePMzAXof, actionName, true)?.xKqYQOpLsGFmaoEFKYQRCnKaaWcQ() ?? false;
	}

	public bool GetButton(int actionId)
	{
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return false;
		}
		return vUXRFQkaqtxZmDdZWniajedetQiF.tfgFiWTAWZlOVgeKFIvByhHrMtkg(CgPagdlzMlCQxkbRTPOoePMzAXof, actionId, true)?.xKqYQOpLsGFmaoEFKYQRCnKaaWcQ() ?? false;
	}

	public bool GetButtonDown(string actionName)
	{
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return false;
		}
		return vUXRFQkaqtxZmDdZWniajedetQiF.PKzDxdNXFVjWIeVjZiJxNOwUmSLU(CgPagdlzMlCQxkbRTPOoePMzAXof, actionName, true)?.SlBphyvwWgvIxeNaguzhFBDTfHoJ() ?? false;
	}

	public bool GetButtonDown(int actionId)
	{
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return false;
		}
		return vUXRFQkaqtxZmDdZWniajedetQiF.tfgFiWTAWZlOVgeKFIvByhHrMtkg(CgPagdlzMlCQxkbRTPOoePMzAXof, actionId, true)?.SlBphyvwWgvIxeNaguzhFBDTfHoJ() ?? false;
	}

	public bool GetButtonUp(string actionName)
	{
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return false;
		}
		return vUXRFQkaqtxZmDdZWniajedetQiF.PKzDxdNXFVjWIeVjZiJxNOwUmSLU(CgPagdlzMlCQxkbRTPOoePMzAXof, actionName, true)?.AfBRHgbDIxDSwAMNQBOuTkhxmJQqA() ?? false;
	}

	public bool GetButtonUp(int actionId)
	{
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return false;
		}
		return vUXRFQkaqtxZmDdZWniajedetQiF.tfgFiWTAWZlOVgeKFIvByhHrMtkg(CgPagdlzMlCQxkbRTPOoePMzAXof, actionId, true)?.AfBRHgbDIxDSwAMNQBOuTkhxmJQqA() ?? false;
	}

	public bool GetButtonPrev(string actionName)
	{
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return false;
		}
		return vUXRFQkaqtxZmDdZWniajedetQiF.PKzDxdNXFVjWIeVjZiJxNOwUmSLU(CgPagdlzMlCQxkbRTPOoePMzAXof, actionName, true)?.EnSiNuXtEgmFXWEsIzPJTGnkSqBU() ?? false;
	}

	public bool GetButtonPrev(int actionId)
	{
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return false;
		}
		return vUXRFQkaqtxZmDdZWniajedetQiF.tfgFiWTAWZlOVgeKFIvByhHrMtkg(CgPagdlzMlCQxkbRTPOoePMzAXof, actionId, true)?.EnSiNuXtEgmFXWEsIzPJTGnkSqBU() ?? false;
	}

	public bool GetButtonSinglePressHold(int actionId)
	{
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return false;
		}
		return vUXRFQkaqtxZmDdZWniajedetQiF.tfgFiWTAWZlOVgeKFIvByhHrMtkg(CgPagdlzMlCQxkbRTPOoePMzAXof, actionId, true)?.taSMMuYrnbSumUxwpcrTCCyAtuSX() ?? false;
	}

	public bool GetButtonSinglePressHold(string actionName)
	{
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return false;
		}
		return vUXRFQkaqtxZmDdZWniajedetQiF.PKzDxdNXFVjWIeVjZiJxNOwUmSLU(CgPagdlzMlCQxkbRTPOoePMzAXof, actionName, true)?.taSMMuYrnbSumUxwpcrTCCyAtuSX() ?? false;
	}

	public bool GetButtonSinglePressDown(int actionId)
	{
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return false;
		}
		return vUXRFQkaqtxZmDdZWniajedetQiF.tfgFiWTAWZlOVgeKFIvByhHrMtkg(CgPagdlzMlCQxkbRTPOoePMzAXof, actionId, true)?.tTJcOxzNCiiLiMUKpxjdpmtCQKSJ() ?? false;
	}

	public bool GetButtonSinglePressDown(string actionName)
	{
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return false;
		}
		return vUXRFQkaqtxZmDdZWniajedetQiF.PKzDxdNXFVjWIeVjZiJxNOwUmSLU(CgPagdlzMlCQxkbRTPOoePMzAXof, actionName, true)?.tTJcOxzNCiiLiMUKpxjdpmtCQKSJ() ?? false;
	}

	public bool GetButtonSinglePressUp(int actionId)
	{
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return false;
		}
		return vUXRFQkaqtxZmDdZWniajedetQiF.tfgFiWTAWZlOVgeKFIvByhHrMtkg(CgPagdlzMlCQxkbRTPOoePMzAXof, actionId, true)?.poPBIMJHlRUiMXmwfxMlaldXdztT() ?? false;
	}

	public bool GetButtonSinglePressUp(string actionName)
	{
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return false;
		}
		return vUXRFQkaqtxZmDdZWniajedetQiF.PKzDxdNXFVjWIeVjZiJxNOwUmSLU(CgPagdlzMlCQxkbRTPOoePMzAXof, actionName, true)?.poPBIMJHlRUiMXmwfxMlaldXdztT() ?? false;
	}

	public bool GetButtonDoublePressHold(string actionName, float speed)
	{
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return false;
		}
		return vUXRFQkaqtxZmDdZWniajedetQiF.PKzDxdNXFVjWIeVjZiJxNOwUmSLU(CgPagdlzMlCQxkbRTPOoePMzAXof, actionName, true)?.QsNvsLyEjKJflAGPVqYdaUgqbBtP(speed) ?? false;
	}

	public bool GetButtonDoublePressHold(int actionId, float speed)
	{
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return false;
		}
		return vUXRFQkaqtxZmDdZWniajedetQiF.tfgFiWTAWZlOVgeKFIvByhHrMtkg(CgPagdlzMlCQxkbRTPOoePMzAXof, actionId, true)?.QsNvsLyEjKJflAGPVqYdaUgqbBtP(speed) ?? false;
	}

	public bool GetButtonDoublePressHold(string actionName)
	{
		return GetButtonDoublePressHold(actionName, 0f);
	}

	public bool GetButtonDoublePressHold(int actionId)
	{
		return GetButtonDoublePressHold(actionId, 0f);
	}

	public bool GetButtonDoublePressDown(string actionName, float speed)
	{
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return false;
		}
		return vUXRFQkaqtxZmDdZWniajedetQiF.PKzDxdNXFVjWIeVjZiJxNOwUmSLU(CgPagdlzMlCQxkbRTPOoePMzAXof, actionName, true)?.TxpFIpCXbAUGsbVTpDsFxkyYzcW(speed) ?? false;
	}

	public bool GetButtonDoublePressDown(int actionId, float speed)
	{
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return false;
		}
		return vUXRFQkaqtxZmDdZWniajedetQiF.tfgFiWTAWZlOVgeKFIvByhHrMtkg(CgPagdlzMlCQxkbRTPOoePMzAXof, actionId, true)?.TxpFIpCXbAUGsbVTpDsFxkyYzcW(speed) ?? false;
	}

	public bool GetButtonDoublePressDown(string actionName)
	{
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return false;
		}
		return GetButtonDoublePressDown(actionName, 0f);
	}

	public bool GetButtonDoublePressDown(int actionId)
	{
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return false;
		}
		return GetButtonDoublePressDown(actionId, 0f);
	}

	public bool GetButtonDoublePressUp(string actionName, float speed)
	{
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return false;
		}
		return vUXRFQkaqtxZmDdZWniajedetQiF.PKzDxdNXFVjWIeVjZiJxNOwUmSLU(CgPagdlzMlCQxkbRTPOoePMzAXof, actionName, true)?.dwHlpMtarpWlenpesLjlxnUTFMUs(speed) ?? false;
	}

	public bool GetButtonDoublePressUp(int actionId, float speed)
	{
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return false;
		}
		return vUXRFQkaqtxZmDdZWniajedetQiF.tfgFiWTAWZlOVgeKFIvByhHrMtkg(CgPagdlzMlCQxkbRTPOoePMzAXof, actionId, true)?.dwHlpMtarpWlenpesLjlxnUTFMUs(speed) ?? false;
	}

	public bool GetButtonDoublePressUp(string actionName)
	{
		return GetButtonDoublePressUp(actionName, 0f);
	}

	public bool GetButtonDoublePressUp(int actionId)
	{
		return GetButtonDoublePressUp(actionId, 0f);
	}

	public bool GetButtonTimedPress(string actionName, float time)
	{
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return false;
		}
		return vUXRFQkaqtxZmDdZWniajedetQiF.PKzDxdNXFVjWIeVjZiJxNOwUmSLU(CgPagdlzMlCQxkbRTPOoePMzAXof, actionName, true)?.FdRbXuPyMOBrWhPPtLbONRCWRNDF(time, 0f) ?? false;
	}

	public bool GetButtonTimedPress(int actionId, float time)
	{
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return false;
		}
		return vUXRFQkaqtxZmDdZWniajedetQiF.tfgFiWTAWZlOVgeKFIvByhHrMtkg(CgPagdlzMlCQxkbRTPOoePMzAXof, actionId, true)?.FdRbXuPyMOBrWhPPtLbONRCWRNDF(time, 0f) ?? false;
	}

	public bool GetButtonTimedPress(string actionName, float time, float expireIn)
	{
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return false;
		}
		return vUXRFQkaqtxZmDdZWniajedetQiF.PKzDxdNXFVjWIeVjZiJxNOwUmSLU(CgPagdlzMlCQxkbRTPOoePMzAXof, actionName, true)?.FdRbXuPyMOBrWhPPtLbONRCWRNDF(time, expireIn) ?? false;
	}

	public bool GetButtonTimedPress(int actionId, float time, float expireIn)
	{
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return false;
		}
		return vUXRFQkaqtxZmDdZWniajedetQiF.tfgFiWTAWZlOVgeKFIvByhHrMtkg(CgPagdlzMlCQxkbRTPOoePMzAXof, actionId, true)?.FdRbXuPyMOBrWhPPtLbONRCWRNDF(time, expireIn) ?? false;
	}

	public bool GetButtonTimedPressDown(string actionName, float time)
	{
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return false;
		}
		return vUXRFQkaqtxZmDdZWniajedetQiF.PKzDxdNXFVjWIeVjZiJxNOwUmSLU(CgPagdlzMlCQxkbRTPOoePMzAXof, actionName, true)?.OiNKbcEeqwSpZVHNmRVnqogRDLbe(time) ?? false;
	}

	public bool GetButtonTimedPressDown(int actionId, float time)
	{
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return false;
		}
		return vUXRFQkaqtxZmDdZWniajedetQiF.tfgFiWTAWZlOVgeKFIvByhHrMtkg(CgPagdlzMlCQxkbRTPOoePMzAXof, actionId, true)?.OiNKbcEeqwSpZVHNmRVnqogRDLbe(time) ?? false;
	}

	public bool GetButtonTimedPressUp(string actionName, float time)
	{
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return false;
		}
		return vUXRFQkaqtxZmDdZWniajedetQiF.PKzDxdNXFVjWIeVjZiJxNOwUmSLU(CgPagdlzMlCQxkbRTPOoePMzAXof, actionName, true)?.xHYWeZwAVSdqPEUcyxvqXirtXpaF(time, 0f) ?? false;
	}

	public bool GetButtonTimedPressUp(int actionId, float time)
	{
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return false;
		}
		return vUXRFQkaqtxZmDdZWniajedetQiF.tfgFiWTAWZlOVgeKFIvByhHrMtkg(CgPagdlzMlCQxkbRTPOoePMzAXof, actionId, true)?.xHYWeZwAVSdqPEUcyxvqXirtXpaF(time, 0f) ?? false;
	}

	public bool GetButtonTimedPressUp(string actionName, float time, float expireIn)
	{
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return false;
		}
		return vUXRFQkaqtxZmDdZWniajedetQiF.PKzDxdNXFVjWIeVjZiJxNOwUmSLU(CgPagdlzMlCQxkbRTPOoePMzAXof, actionName, true)?.xHYWeZwAVSdqPEUcyxvqXirtXpaF(time, expireIn) ?? false;
	}

	public bool GetButtonTimedPressUp(int actionId, float time, float expireIn)
	{
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return false;
		}
		return vUXRFQkaqtxZmDdZWniajedetQiF.tfgFiWTAWZlOVgeKFIvByhHrMtkg(CgPagdlzMlCQxkbRTPOoePMzAXof, actionId, true)?.xHYWeZwAVSdqPEUcyxvqXirtXpaF(time, expireIn) ?? false;
	}

	public bool GetButtonShortPress(string actionName)
	{
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return false;
		}
		return vUXRFQkaqtxZmDdZWniajedetQiF.PKzDxdNXFVjWIeVjZiJxNOwUmSLU(CgPagdlzMlCQxkbRTPOoePMzAXof, actionName, true)?.hSsQhormxBPLsPmcTUQqJowtLVbv() ?? false;
	}

	public bool GetButtonShortPress(int actionId)
	{
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return false;
		}
		return vUXRFQkaqtxZmDdZWniajedetQiF.tfgFiWTAWZlOVgeKFIvByhHrMtkg(CgPagdlzMlCQxkbRTPOoePMzAXof, actionId, true)?.hSsQhormxBPLsPmcTUQqJowtLVbv() ?? false;
	}

	public bool GetButtonShortPressDown(string actionName)
	{
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return false;
		}
		return vUXRFQkaqtxZmDdZWniajedetQiF.PKzDxdNXFVjWIeVjZiJxNOwUmSLU(CgPagdlzMlCQxkbRTPOoePMzAXof, actionName, true)?.beWJzLeKilWrFrbfQEhsbIPicKVTA() ?? false;
	}

	public bool GetButtonShortPressDown(int actionId)
	{
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return false;
		}
		return vUXRFQkaqtxZmDdZWniajedetQiF.tfgFiWTAWZlOVgeKFIvByhHrMtkg(CgPagdlzMlCQxkbRTPOoePMzAXof, actionId, true)?.beWJzLeKilWrFrbfQEhsbIPicKVTA() ?? false;
	}

	public bool GetButtonShortPressUp(string actionName)
	{
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return false;
		}
		return vUXRFQkaqtxZmDdZWniajedetQiF.PKzDxdNXFVjWIeVjZiJxNOwUmSLU(CgPagdlzMlCQxkbRTPOoePMzAXof, actionName, true)?.TSceslrzwUjYnpGunBFAMFHVIyNT() ?? false;
	}

	public bool GetButtonShortPressUp(int actionId)
	{
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return false;
		}
		return vUXRFQkaqtxZmDdZWniajedetQiF.tfgFiWTAWZlOVgeKFIvByhHrMtkg(CgPagdlzMlCQxkbRTPOoePMzAXof, actionId, true)?.TSceslrzwUjYnpGunBFAMFHVIyNT() ?? false;
	}

	public bool GetButtonLongPress(string actionName)
	{
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return false;
		}
		return vUXRFQkaqtxZmDdZWniajedetQiF.PKzDxdNXFVjWIeVjZiJxNOwUmSLU(CgPagdlzMlCQxkbRTPOoePMzAXof, actionName, true)?.aSXXpPPIRQYKEURuUelgSsXLZrbF() ?? false;
	}

	public bool GetButtonLongPress(int actionId)
	{
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return false;
		}
		return vUXRFQkaqtxZmDdZWniajedetQiF.tfgFiWTAWZlOVgeKFIvByhHrMtkg(CgPagdlzMlCQxkbRTPOoePMzAXof, actionId, true)?.aSXXpPPIRQYKEURuUelgSsXLZrbF() ?? false;
	}

	public bool GetButtonLongPressDown(string actionName)
	{
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return false;
		}
		return vUXRFQkaqtxZmDdZWniajedetQiF.PKzDxdNXFVjWIeVjZiJxNOwUmSLU(CgPagdlzMlCQxkbRTPOoePMzAXof, actionName, true)?.YhuZEIfeXBBkEwXAHNwLlIliaSbB() ?? false;
	}

	public bool GetButtonLongPressDown(int actionId)
	{
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return false;
		}
		return vUXRFQkaqtxZmDdZWniajedetQiF.tfgFiWTAWZlOVgeKFIvByhHrMtkg(CgPagdlzMlCQxkbRTPOoePMzAXof, actionId, true)?.YhuZEIfeXBBkEwXAHNwLlIliaSbB() ?? false;
	}

	public bool GetButtonLongPressUp(string actionName)
	{
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return false;
		}
		return vUXRFQkaqtxZmDdZWniajedetQiF.PKzDxdNXFVjWIeVjZiJxNOwUmSLU(CgPagdlzMlCQxkbRTPOoePMzAXof, actionName, true)?.HVQjefdnnZPmDpLqjeASIlsubdmnA() ?? false;
	}

	public bool GetButtonLongPressUp(int actionId)
	{
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return false;
		}
		return vUXRFQkaqtxZmDdZWniajedetQiF.tfgFiWTAWZlOVgeKFIvByhHrMtkg(CgPagdlzMlCQxkbRTPOoePMzAXof, actionId, true)?.HVQjefdnnZPmDpLqjeASIlsubdmnA() ?? false;
	}

	public bool GetButtonRepeating(string actionName)
	{
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return false;
		}
		return vUXRFQkaqtxZmDdZWniajedetQiF.PKzDxdNXFVjWIeVjZiJxNOwUmSLU(CgPagdlzMlCQxkbRTPOoePMzAXof, actionName, true)?.BrDddvTgykgmePaGTLJtXINQIFtK() ?? false;
	}

	public bool GetButtonRepeating(int actionId)
	{
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return false;
		}
		return vUXRFQkaqtxZmDdZWniajedetQiF.tfgFiWTAWZlOVgeKFIvByhHrMtkg(CgPagdlzMlCQxkbRTPOoePMzAXof, actionId, true)?.BrDddvTgykgmePaGTLJtXINQIFtK() ?? false;
	}

	public bool GetAnyButton()
	{
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return false;
		}
		return vUXRFQkaqtxZmDdZWniajedetQiF.TYfmtoqzwmGLovKrlGfhkLtTcHV(CgPagdlzMlCQxkbRTPOoePMzAXof);
	}

	public bool GetAnyButtonDown()
	{
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return false;
		}
		return vUXRFQkaqtxZmDdZWniajedetQiF.JayFxUzYSsNACMPTCIKTtTOLeKoB(CgPagdlzMlCQxkbRTPOoePMzAXof);
	}

	public bool GetAnyButtonUp()
	{
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return false;
		}
		return vUXRFQkaqtxZmDdZWniajedetQiF.MLIcWmYiqirxnSOsuerLkNIitMoP(CgPagdlzMlCQxkbRTPOoePMzAXof);
	}

	public bool GetAnyButtonPrev()
	{
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return false;
		}
		return vUXRFQkaqtxZmDdZWniajedetQiF.CyOZxMQAbAJMWqjHtGpNDZCxJPHFA(CgPagdlzMlCQxkbRTPOoePMzAXof);
	}

	public double GetButtonTimePressed(string actionName)
	{
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return 0.0;
		}
		return vUXRFQkaqtxZmDdZWniajedetQiF.PKzDxdNXFVjWIeVjZiJxNOwUmSLU(CgPagdlzMlCQxkbRTPOoePMzAXof, actionName, true)?.KDOaClPYRQtUROFmmEQqHnNzmOFdA() ?? 0.0;
	}

	public double GetButtonTimePressed(int actionId)
	{
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return 0.0;
		}
		return vUXRFQkaqtxZmDdZWniajedetQiF.tfgFiWTAWZlOVgeKFIvByhHrMtkg(CgPagdlzMlCQxkbRTPOoePMzAXof, actionId, true)?.KDOaClPYRQtUROFmmEQqHnNzmOFdA() ?? 0.0;
	}

	public double GetButtonTimeUnpressed(string actionName)
	{
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return 0.0;
		}
		return vUXRFQkaqtxZmDdZWniajedetQiF.PKzDxdNXFVjWIeVjZiJxNOwUmSLU(CgPagdlzMlCQxkbRTPOoePMzAXof, actionName, true)?.jOizjZLpppGnIDmOFHgQCWzakrlC() ?? 0.0;
	}

	public double GetButtonTimeUnpressed(int actionId)
	{
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return 0.0;
		}
		return vUXRFQkaqtxZmDdZWniajedetQiF.tfgFiWTAWZlOVgeKFIvByhHrMtkg(CgPagdlzMlCQxkbRTPOoePMzAXof, actionId, true)?.jOizjZLpppGnIDmOFHgQCWzakrlC() ?? 0.0;
	}

	public bool GetNegativeButton(string actionName)
	{
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return false;
		}
		return vUXRFQkaqtxZmDdZWniajedetQiF.PKzDxdNXFVjWIeVjZiJxNOwUmSLU(CgPagdlzMlCQxkbRTPOoePMzAXof, actionName, true)?.xTmTABHXjJsoVMuVRKriyrGRgzRH() ?? false;
	}

	public bool GetNegativeButton(int actionId)
	{
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return false;
		}
		return vUXRFQkaqtxZmDdZWniajedetQiF.tfgFiWTAWZlOVgeKFIvByhHrMtkg(CgPagdlzMlCQxkbRTPOoePMzAXof, actionId, true)?.xTmTABHXjJsoVMuVRKriyrGRgzRH() ?? false;
	}

	public bool GetNegativeButtonDown(string actionName)
	{
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return false;
		}
		return vUXRFQkaqtxZmDdZWniajedetQiF.PKzDxdNXFVjWIeVjZiJxNOwUmSLU(CgPagdlzMlCQxkbRTPOoePMzAXof, actionName, true)?.jkWaFrQGPlyFMdhMpGwpqkrDEFHI() ?? false;
	}

	public bool GetNegativeButtonDown(int actionId)
	{
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return false;
		}
		return vUXRFQkaqtxZmDdZWniajedetQiF.tfgFiWTAWZlOVgeKFIvByhHrMtkg(CgPagdlzMlCQxkbRTPOoePMzAXof, actionId, true)?.jkWaFrQGPlyFMdhMpGwpqkrDEFHI() ?? false;
	}

	public bool GetNegativeButtonUp(string actionName)
	{
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return false;
		}
		return vUXRFQkaqtxZmDdZWniajedetQiF.PKzDxdNXFVjWIeVjZiJxNOwUmSLU(CgPagdlzMlCQxkbRTPOoePMzAXof, actionName, true)?.sgYTmFGalnrYFfIBPOUYeCxEwbSH() ?? false;
	}

	public bool GetNegativeButtonUp(int actionId)
	{
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return false;
		}
		return vUXRFQkaqtxZmDdZWniajedetQiF.tfgFiWTAWZlOVgeKFIvByhHrMtkg(CgPagdlzMlCQxkbRTPOoePMzAXof, actionId, true)?.sgYTmFGalnrYFfIBPOUYeCxEwbSH() ?? false;
	}

	public bool GetNegativeButtonPrev(string actionName)
	{
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return false;
		}
		return vUXRFQkaqtxZmDdZWniajedetQiF.PKzDxdNXFVjWIeVjZiJxNOwUmSLU(CgPagdlzMlCQxkbRTPOoePMzAXof, actionName, true)?.BiXjczSVhafaeneuyfuougxOQCYu() ?? false;
	}

	public bool GetNegativeButtonPrev(int actionId)
	{
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return false;
		}
		return vUXRFQkaqtxZmDdZWniajedetQiF.tfgFiWTAWZlOVgeKFIvByhHrMtkg(CgPagdlzMlCQxkbRTPOoePMzAXof, actionId, true)?.BiXjczSVhafaeneuyfuougxOQCYu() ?? false;
	}

	public bool GetNegativeButtonSinglePressHold(int actionId)
	{
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return false;
		}
		return vUXRFQkaqtxZmDdZWniajedetQiF.tfgFiWTAWZlOVgeKFIvByhHrMtkg(CgPagdlzMlCQxkbRTPOoePMzAXof, actionId, true)?.OLBrnTxTzSPFYiaIRhtvoTtlUkku() ?? false;
	}

	public bool GetNegativeButtonSinglePressHold(string actionName)
	{
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return false;
		}
		return vUXRFQkaqtxZmDdZWniajedetQiF.PKzDxdNXFVjWIeVjZiJxNOwUmSLU(CgPagdlzMlCQxkbRTPOoePMzAXof, actionName, true)?.OLBrnTxTzSPFYiaIRhtvoTtlUkku() ?? false;
	}

	public bool GetNegativeButtonSinglePressDown(int actionId)
	{
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return false;
		}
		return vUXRFQkaqtxZmDdZWniajedetQiF.tfgFiWTAWZlOVgeKFIvByhHrMtkg(CgPagdlzMlCQxkbRTPOoePMzAXof, actionId, true)?.yeRGNIvOuNmOdrntRledlybJAbWR() ?? false;
	}

	public bool GetNegativeButtonSinglePressDown(string actionName)
	{
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return false;
		}
		return vUXRFQkaqtxZmDdZWniajedetQiF.PKzDxdNXFVjWIeVjZiJxNOwUmSLU(CgPagdlzMlCQxkbRTPOoePMzAXof, actionName, true)?.yeRGNIvOuNmOdrntRledlybJAbWR() ?? false;
	}

	public bool GetNegativeButtonSinglePressUp(int actionId)
	{
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return false;
		}
		return vUXRFQkaqtxZmDdZWniajedetQiF.tfgFiWTAWZlOVgeKFIvByhHrMtkg(CgPagdlzMlCQxkbRTPOoePMzAXof, actionId, true)?.ivrolhhvFjVTtpjOzHpLymGcfxTw() ?? false;
	}

	public bool GetNegativeButtonSinglePressUp(string actionName)
	{
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return false;
		}
		return vUXRFQkaqtxZmDdZWniajedetQiF.PKzDxdNXFVjWIeVjZiJxNOwUmSLU(CgPagdlzMlCQxkbRTPOoePMzAXof, actionName, true)?.ivrolhhvFjVTtpjOzHpLymGcfxTw() ?? false;
	}

	public bool GetNegativeButtonDoublePressHold(string actionName, float speed)
	{
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return false;
		}
		return vUXRFQkaqtxZmDdZWniajedetQiF.PKzDxdNXFVjWIeVjZiJxNOwUmSLU(CgPagdlzMlCQxkbRTPOoePMzAXof, actionName, true)?.hbektbuDvlfxTouCRZgDkkmxTxeL(speed) ?? false;
	}

	public bool GetNegativeButtonDoublePressHold(int actionId, float speed)
	{
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return false;
		}
		return vUXRFQkaqtxZmDdZWniajedetQiF.tfgFiWTAWZlOVgeKFIvByhHrMtkg(CgPagdlzMlCQxkbRTPOoePMzAXof, actionId, true)?.hbektbuDvlfxTouCRZgDkkmxTxeL(speed) ?? false;
	}

	public bool GetNegativeButtonDoublePressHold(string actionName)
	{
		return GetNegativeButtonDoublePressHold(actionName, 0f);
	}

	public bool GetNegativeButtonDoublePressHold(int actionId)
	{
		return GetNegativeButtonDoublePressHold(actionId, 0f);
	}

	public bool GetNegativeButtonDoublePressDown(string actionName, float speed)
	{
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return false;
		}
		return vUXRFQkaqtxZmDdZWniajedetQiF.PKzDxdNXFVjWIeVjZiJxNOwUmSLU(CgPagdlzMlCQxkbRTPOoePMzAXof, actionName, true)?.tmopxnyFMesBLwfGALpxzHifBmgJA(speed) ?? false;
	}

	public bool GetNegativeButtonDoublePressDown(int actionId, float speed)
	{
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return false;
		}
		return vUXRFQkaqtxZmDdZWniajedetQiF.tfgFiWTAWZlOVgeKFIvByhHrMtkg(CgPagdlzMlCQxkbRTPOoePMzAXof, actionId, true)?.tmopxnyFMesBLwfGALpxzHifBmgJA(speed) ?? false;
	}

	public bool GetNegativeButtonDoublePressDown(string actionName)
	{
		return GetNegativeButtonDoublePressDown(actionName, 0f);
	}

	public bool GetNegativeButtonDoublePressDown(int actionId)
	{
		return GetNegativeButtonDoublePressDown(actionId, 0f);
	}

	public bool GetNegativeButtonDoublePressUp(string actionName, float speed)
	{
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return false;
		}
		return vUXRFQkaqtxZmDdZWniajedetQiF.PKzDxdNXFVjWIeVjZiJxNOwUmSLU(CgPagdlzMlCQxkbRTPOoePMzAXof, actionName, true)?.BwfldKcyKYMrqJeNqAnbJCnEQlno(speed) ?? false;
	}

	public bool GetNegativeButtonDoublePressUp(int actionId, float speed)
	{
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return false;
		}
		return vUXRFQkaqtxZmDdZWniajedetQiF.tfgFiWTAWZlOVgeKFIvByhHrMtkg(CgPagdlzMlCQxkbRTPOoePMzAXof, actionId, true)?.BwfldKcyKYMrqJeNqAnbJCnEQlno(speed) ?? false;
	}

	public bool GetNegativeButtonDoublePressUp(string actionName)
	{
		return GetNegativeButtonDoublePressUp(actionName, 0f);
	}

	public bool GetNegativeButtonDoublePressUp(int actionId)
	{
		return GetNegativeButtonDoublePressUp(actionId, 0f);
	}

	public bool GetNegativeButtonTimedPress(string actionName, float time)
	{
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return false;
		}
		return vUXRFQkaqtxZmDdZWniajedetQiF.PKzDxdNXFVjWIeVjZiJxNOwUmSLU(CgPagdlzMlCQxkbRTPOoePMzAXof, actionName, true)?.ziADzwgaBUtBwGHVrdTTRHuRRjVv(time, 0f) ?? false;
	}

	public bool GetNegativeButtonTimedPress(int actionId, float time)
	{
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return false;
		}
		return vUXRFQkaqtxZmDdZWniajedetQiF.tfgFiWTAWZlOVgeKFIvByhHrMtkg(CgPagdlzMlCQxkbRTPOoePMzAXof, actionId, true)?.ziADzwgaBUtBwGHVrdTTRHuRRjVv(time, 0f) ?? false;
	}

	public bool GetNegativeButtonTimedPress(string actionName, float time, float expireIn)
	{
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return false;
		}
		return vUXRFQkaqtxZmDdZWniajedetQiF.PKzDxdNXFVjWIeVjZiJxNOwUmSLU(CgPagdlzMlCQxkbRTPOoePMzAXof, actionName, true)?.ziADzwgaBUtBwGHVrdTTRHuRRjVv(time, expireIn) ?? false;
	}

	public bool GetNegativeButtonTimedPress(int actionId, float time, float expireIn)
	{
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return false;
		}
		return vUXRFQkaqtxZmDdZWniajedetQiF.tfgFiWTAWZlOVgeKFIvByhHrMtkg(CgPagdlzMlCQxkbRTPOoePMzAXof, actionId, true)?.ziADzwgaBUtBwGHVrdTTRHuRRjVv(time, expireIn) ?? false;
	}

	public bool GetNegativeButtonTimedPressDown(string actionName, float time)
	{
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return false;
		}
		return vUXRFQkaqtxZmDdZWniajedetQiF.PKzDxdNXFVjWIeVjZiJxNOwUmSLU(CgPagdlzMlCQxkbRTPOoePMzAXof, actionName, true)?.MXpiuUDTKdbHFrOefQLevbJtSLAn(time) ?? false;
	}

	public bool GetNegativeButtonTimedPressDown(int actionId, float time)
	{
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return false;
		}
		return vUXRFQkaqtxZmDdZWniajedetQiF.tfgFiWTAWZlOVgeKFIvByhHrMtkg(CgPagdlzMlCQxkbRTPOoePMzAXof, actionId, true)?.MXpiuUDTKdbHFrOefQLevbJtSLAn(time) ?? false;
	}

	public bool GetNegativeButtonTimedPressUp(string actionName, float time)
	{
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return false;
		}
		return vUXRFQkaqtxZmDdZWniajedetQiF.PKzDxdNXFVjWIeVjZiJxNOwUmSLU(CgPagdlzMlCQxkbRTPOoePMzAXof, actionName, true)?.thuqLozprJgAEhQQpMrdgxdFaLXHb(time, 0f) ?? false;
	}

	public bool GetNegativeButtonTimedPressUp(int actionId, float time)
	{
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return false;
		}
		return vUXRFQkaqtxZmDdZWniajedetQiF.tfgFiWTAWZlOVgeKFIvByhHrMtkg(CgPagdlzMlCQxkbRTPOoePMzAXof, actionId, true)?.thuqLozprJgAEhQQpMrdgxdFaLXHb(time, 0f) ?? false;
	}

	public bool GetNegativeButtonTimedPressUp(string actionName, float time, float expireIn)
	{
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return false;
		}
		return vUXRFQkaqtxZmDdZWniajedetQiF.PKzDxdNXFVjWIeVjZiJxNOwUmSLU(CgPagdlzMlCQxkbRTPOoePMzAXof, actionName, true)?.thuqLozprJgAEhQQpMrdgxdFaLXHb(time, expireIn) ?? false;
	}

	public bool GetNegativeButtonTimedPressUp(int actionId, float time, float expireIn)
	{
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return false;
		}
		return vUXRFQkaqtxZmDdZWniajedetQiF.tfgFiWTAWZlOVgeKFIvByhHrMtkg(CgPagdlzMlCQxkbRTPOoePMzAXof, actionId, true)?.thuqLozprJgAEhQQpMrdgxdFaLXHb(time, expireIn) ?? false;
	}

	public bool GetNegativeButtonShortPress(string actionName)
	{
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return false;
		}
		return vUXRFQkaqtxZmDdZWniajedetQiF.PKzDxdNXFVjWIeVjZiJxNOwUmSLU(CgPagdlzMlCQxkbRTPOoePMzAXof, actionName, true)?.QlWFjPVnWqModMBeBYnxLikAKDpK() ?? false;
	}

	public bool GetNegativeButtonShortPress(int actionId)
	{
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return false;
		}
		return vUXRFQkaqtxZmDdZWniajedetQiF.tfgFiWTAWZlOVgeKFIvByhHrMtkg(CgPagdlzMlCQxkbRTPOoePMzAXof, actionId, true)?.QlWFjPVnWqModMBeBYnxLikAKDpK() ?? false;
	}

	public bool GetNegativeButtonShortPressDown(string actionName)
	{
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return false;
		}
		return vUXRFQkaqtxZmDdZWniajedetQiF.PKzDxdNXFVjWIeVjZiJxNOwUmSLU(CgPagdlzMlCQxkbRTPOoePMzAXof, actionName, true)?.AfxupzobmupXNHrRGlGIelaZDFwJ() ?? false;
	}

	public bool GetNegativeButtonShortPressDown(int actionId)
	{
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return false;
		}
		return vUXRFQkaqtxZmDdZWniajedetQiF.tfgFiWTAWZlOVgeKFIvByhHrMtkg(CgPagdlzMlCQxkbRTPOoePMzAXof, actionId, true)?.AfxupzobmupXNHrRGlGIelaZDFwJ() ?? false;
	}

	public bool GetNegativeButtonShortPressUp(string actionName)
	{
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return false;
		}
		return vUXRFQkaqtxZmDdZWniajedetQiF.PKzDxdNXFVjWIeVjZiJxNOwUmSLU(CgPagdlzMlCQxkbRTPOoePMzAXof, actionName, true)?.vIAohwnKWdpbfnavFyHTrtDrBpsH() ?? false;
	}

	public bool GetNegativeButtonShortPressUp(int actionId)
	{
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return false;
		}
		return vUXRFQkaqtxZmDdZWniajedetQiF.tfgFiWTAWZlOVgeKFIvByhHrMtkg(CgPagdlzMlCQxkbRTPOoePMzAXof, actionId, true)?.vIAohwnKWdpbfnavFyHTrtDrBpsH() ?? false;
	}

	public bool GetNegativeButtonLongPress(string actionName)
	{
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return false;
		}
		return vUXRFQkaqtxZmDdZWniajedetQiF.PKzDxdNXFVjWIeVjZiJxNOwUmSLU(CgPagdlzMlCQxkbRTPOoePMzAXof, actionName, true)?.qYurVkNFOBRmWJkExbIOmfDSrXlB() ?? false;
	}

	public bool GetNegativeButtonLongPress(int actionId)
	{
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return false;
		}
		return vUXRFQkaqtxZmDdZWniajedetQiF.tfgFiWTAWZlOVgeKFIvByhHrMtkg(CgPagdlzMlCQxkbRTPOoePMzAXof, actionId, true)?.qYurVkNFOBRmWJkExbIOmfDSrXlB() ?? false;
	}

	public bool GetNegativeButtonLongPressDown(string actionName)
	{
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return false;
		}
		return vUXRFQkaqtxZmDdZWniajedetQiF.PKzDxdNXFVjWIeVjZiJxNOwUmSLU(CgPagdlzMlCQxkbRTPOoePMzAXof, actionName, true)?.UdkkgdfwCMgOXaDSEbjwMaueXKry() ?? false;
	}

	public bool GetNegativeButtonLongPressDown(int actionId)
	{
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return false;
		}
		return vUXRFQkaqtxZmDdZWniajedetQiF.tfgFiWTAWZlOVgeKFIvByhHrMtkg(CgPagdlzMlCQxkbRTPOoePMzAXof, actionId, true)?.UdkkgdfwCMgOXaDSEbjwMaueXKry() ?? false;
	}

	public bool GetNegativeButtonLongPressUp(string actionName)
	{
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return false;
		}
		return vUXRFQkaqtxZmDdZWniajedetQiF.PKzDxdNXFVjWIeVjZiJxNOwUmSLU(CgPagdlzMlCQxkbRTPOoePMzAXof, actionName, true)?.dOHvDRsAISqcocjczVGkDIoPpjIO() ?? false;
	}

	public bool GetNegativeButtonLongPressUp(int actionId)
	{
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return false;
		}
		return vUXRFQkaqtxZmDdZWniajedetQiF.tfgFiWTAWZlOVgeKFIvByhHrMtkg(CgPagdlzMlCQxkbRTPOoePMzAXof, actionId, true)?.dOHvDRsAISqcocjczVGkDIoPpjIO() ?? false;
	}

	public bool GetNegativeButtonRepeating(string actionName)
	{
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return false;
		}
		return vUXRFQkaqtxZmDdZWniajedetQiF.PKzDxdNXFVjWIeVjZiJxNOwUmSLU(CgPagdlzMlCQxkbRTPOoePMzAXof, actionName, true)?.UTcPrzFZoDBChEyJmzoNpyZmvAqk() ?? false;
	}

	public bool GetNegativeButtonRepeating(int actionId)
	{
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return false;
		}
		return vUXRFQkaqtxZmDdZWniajedetQiF.tfgFiWTAWZlOVgeKFIvByhHrMtkg(CgPagdlzMlCQxkbRTPOoePMzAXof, actionId, true)?.UTcPrzFZoDBChEyJmzoNpyZmvAqk() ?? false;
	}

	public bool GetAnyNegativeButton()
	{
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return false;
		}
		return vUXRFQkaqtxZmDdZWniajedetQiF.GwZCsoRjIfCpkvodaDKXjKhRswQF(CgPagdlzMlCQxkbRTPOoePMzAXof);
	}

	public bool GetAnyNegativeButtonDown()
	{
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return false;
		}
		return vUXRFQkaqtxZmDdZWniajedetQiF.FIabJtePHtDbnIevNTREtFumqHQj(CgPagdlzMlCQxkbRTPOoePMzAXof);
	}

	public bool GetAnyNegativeButtonUp()
	{
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return false;
		}
		return vUXRFQkaqtxZmDdZWniajedetQiF.XKEAMnEbDlcunwPOPWwRJLqreMrLA(CgPagdlzMlCQxkbRTPOoePMzAXof);
	}

	public bool GetAnyNegativeButtonPrev()
	{
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return false;
		}
		return vUXRFQkaqtxZmDdZWniajedetQiF.ufPOaWZtrRFChoFxIPvhSFfkqXuj(CgPagdlzMlCQxkbRTPOoePMzAXof);
	}

	public double GetNegativeButtonTimePressed(string actionName)
	{
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return 0.0;
		}
		return vUXRFQkaqtxZmDdZWniajedetQiF.PKzDxdNXFVjWIeVjZiJxNOwUmSLU(CgPagdlzMlCQxkbRTPOoePMzAXof, actionName, true)?.WGFuhoUGGnsDVUmOuiJBlOfzhxGgA() ?? 0.0;
	}

	public double GetNegativeButtonTimePressed(int actionId)
	{
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return 0.0;
		}
		return vUXRFQkaqtxZmDdZWniajedetQiF.tfgFiWTAWZlOVgeKFIvByhHrMtkg(CgPagdlzMlCQxkbRTPOoePMzAXof, actionId, true)?.WGFuhoUGGnsDVUmOuiJBlOfzhxGgA() ?? 0.0;
	}

	public double GetNegativeButtonTimeUnpressed(string actionName)
	{
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return 0.0;
		}
		return vUXRFQkaqtxZmDdZWniajedetQiF.PKzDxdNXFVjWIeVjZiJxNOwUmSLU(CgPagdlzMlCQxkbRTPOoePMzAXof, actionName, true)?.qjSstIdrUpxTgURnIqiyHOeurdte() ?? 0.0;
	}

	public double GetNegativeButtonTimeUnpressed(int actionId)
	{
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return 0.0;
		}
		return vUXRFQkaqtxZmDdZWniajedetQiF.tfgFiWTAWZlOVgeKFIvByhHrMtkg(CgPagdlzMlCQxkbRTPOoePMzAXof, actionId, true)?.qjSstIdrUpxTgURnIqiyHOeurdte() ?? 0.0;
	}

	public float GetAxis(string actionName)
	{
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return 0f;
		}
		return vUXRFQkaqtxZmDdZWniajedetQiF.PKzDxdNXFVjWIeVjZiJxNOwUmSLU(CgPagdlzMlCQxkbRTPOoePMzAXof, actionName, true)?.lcLDFNWcRGBkJyxvUaCBCdQiMbZEb() ?? 0f;
	}

	public float GetAxis(int actionId)
	{
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return 0f;
		}
		return vUXRFQkaqtxZmDdZWniajedetQiF.tfgFiWTAWZlOVgeKFIvByhHrMtkg(CgPagdlzMlCQxkbRTPOoePMzAXof, actionId, true)?.lcLDFNWcRGBkJyxvUaCBCdQiMbZEb() ?? 0f;
	}

	public float GetAxisRaw(string actionName)
	{
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return 0f;
		}
		return vUXRFQkaqtxZmDdZWniajedetQiF.PKzDxdNXFVjWIeVjZiJxNOwUmSLU(CgPagdlzMlCQxkbRTPOoePMzAXof, actionName, true)?.cWteTyHrjPGhfmxcPfIvYekmLaOoA() ?? 0f;
	}

	public float GetAxisRaw(int actionId)
	{
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return 0f;
		}
		return vUXRFQkaqtxZmDdZWniajedetQiF.tfgFiWTAWZlOVgeKFIvByhHrMtkg(CgPagdlzMlCQxkbRTPOoePMzAXof, actionId, true)?.cWteTyHrjPGhfmxcPfIvYekmLaOoA() ?? 0f;
	}

	public float GetAxisPrev(string actionName)
	{
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return 0f;
		}
		return vUXRFQkaqtxZmDdZWniajedetQiF.PKzDxdNXFVjWIeVjZiJxNOwUmSLU(CgPagdlzMlCQxkbRTPOoePMzAXof, actionName, true)?.FomBExaZtEkQRHdfJkkbIXNFXhfm() ?? 0f;
	}

	public float GetAxisPrev(int actionId)
	{
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return 0f;
		}
		return vUXRFQkaqtxZmDdZWniajedetQiF.tfgFiWTAWZlOVgeKFIvByhHrMtkg(CgPagdlzMlCQxkbRTPOoePMzAXof, actionId, true)?.FomBExaZtEkQRHdfJkkbIXNFXhfm() ?? 0f;
	}

	public float GetAxisRawPrev(string actionName)
	{
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return 0f;
		}
		return vUXRFQkaqtxZmDdZWniajedetQiF.PKzDxdNXFVjWIeVjZiJxNOwUmSLU(CgPagdlzMlCQxkbRTPOoePMzAXof, actionName, true)?.xfRmaCvfMrhVhcNUFLrbYbmFBqcw() ?? 0f;
	}

	public float GetAxisRawPrev(int actionId)
	{
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return 0f;
		}
		return vUXRFQkaqtxZmDdZWniajedetQiF.tfgFiWTAWZlOVgeKFIvByhHrMtkg(CgPagdlzMlCQxkbRTPOoePMzAXof, actionId, true)?.xfRmaCvfMrhVhcNUFLrbYbmFBqcw() ?? 0f;
	}

	public float GetAxisDelta(string actionName)
	{
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return 0f;
		}
		return vUXRFQkaqtxZmDdZWniajedetQiF.PKzDxdNXFVjWIeVjZiJxNOwUmSLU(CgPagdlzMlCQxkbRTPOoePMzAXof, actionName, true)?.fmKaxGzgbrFSVtTFySstiqkHgFgh() ?? 0f;
	}

	public float GetAxisDelta(int actionId)
	{
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return 0f;
		}
		return vUXRFQkaqtxZmDdZWniajedetQiF.tfgFiWTAWZlOVgeKFIvByhHrMtkg(CgPagdlzMlCQxkbRTPOoePMzAXof, actionId, true)?.fmKaxGzgbrFSVtTFySstiqkHgFgh() ?? 0f;
	}

	public float GetAxisRawDelta(string actionName)
	{
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return 0f;
		}
		return vUXRFQkaqtxZmDdZWniajedetQiF.PKzDxdNXFVjWIeVjZiJxNOwUmSLU(CgPagdlzMlCQxkbRTPOoePMzAXof, actionName, true)?.qODMnhSIKHrRltjVNxJRRmvepmmy() ?? 0f;
	}

	public float GetAxisRawDelta(int actionId)
	{
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return 0f;
		}
		return vUXRFQkaqtxZmDdZWniajedetQiF.tfgFiWTAWZlOVgeKFIvByhHrMtkg(CgPagdlzMlCQxkbRTPOoePMzAXof, actionId, true)?.qODMnhSIKHrRltjVNxJRRmvepmmy() ?? 0f;
	}

	public Vector2 GetAxis2D(string xAxisActionName, string yAxisActionName)
	{
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return Vector2.zero;
		}
		Vector2 result = default;
		QZWOxJToNpPZTYJKdjKDNrZDcbAQ qZWOxJToNpPZTYJKdjKDNrZDcbAQ = vUXRFQkaqtxZmDdZWniajedetQiF.PKzDxdNXFVjWIeVjZiJxNOwUmSLU(CgPagdlzMlCQxkbRTPOoePMzAXof, xAxisActionName, true);
		if (qZWOxJToNpPZTYJKdjKDNrZDcbAQ != null)
		{
			result.x = qZWOxJToNpPZTYJKdjKDNrZDcbAQ.lcLDFNWcRGBkJyxvUaCBCdQiMbZEb();
		}
		qZWOxJToNpPZTYJKdjKDNrZDcbAQ = vUXRFQkaqtxZmDdZWniajedetQiF.PKzDxdNXFVjWIeVjZiJxNOwUmSLU(CgPagdlzMlCQxkbRTPOoePMzAXof, yAxisActionName, true);
		if (qZWOxJToNpPZTYJKdjKDNrZDcbAQ != null)
		{
			result.y = qZWOxJToNpPZTYJKdjKDNrZDcbAQ.lcLDFNWcRGBkJyxvUaCBCdQiMbZEb();
		}
		return result;
	}

	public Vector2 GetAxis2D(int xAxisActionId, int yAxisActionId)
	{
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return Vector2.zero;
		}
		Vector2 result = default;
		QZWOxJToNpPZTYJKdjKDNrZDcbAQ qZWOxJToNpPZTYJKdjKDNrZDcbAQ = vUXRFQkaqtxZmDdZWniajedetQiF.tfgFiWTAWZlOVgeKFIvByhHrMtkg(CgPagdlzMlCQxkbRTPOoePMzAXof, xAxisActionId, true);
		if (qZWOxJToNpPZTYJKdjKDNrZDcbAQ != null)
		{
			result.x = qZWOxJToNpPZTYJKdjKDNrZDcbAQ.lcLDFNWcRGBkJyxvUaCBCdQiMbZEb();
		}
		qZWOxJToNpPZTYJKdjKDNrZDcbAQ = vUXRFQkaqtxZmDdZWniajedetQiF.tfgFiWTAWZlOVgeKFIvByhHrMtkg(CgPagdlzMlCQxkbRTPOoePMzAXof, yAxisActionId, true);
		if (qZWOxJToNpPZTYJKdjKDNrZDcbAQ != null)
		{
			result.y = qZWOxJToNpPZTYJKdjKDNrZDcbAQ.lcLDFNWcRGBkJyxvUaCBCdQiMbZEb();
		}
		return result;
	}

	public Vector2 GetAxis2DPrev(string xAxisActionName, string yAxisActionName)
	{
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return Vector2.zero;
		}
		Vector2 result = default;
		QZWOxJToNpPZTYJKdjKDNrZDcbAQ qZWOxJToNpPZTYJKdjKDNrZDcbAQ = vUXRFQkaqtxZmDdZWniajedetQiF.PKzDxdNXFVjWIeVjZiJxNOwUmSLU(CgPagdlzMlCQxkbRTPOoePMzAXof, xAxisActionName, true);
		if (qZWOxJToNpPZTYJKdjKDNrZDcbAQ != null)
		{
			result.x = qZWOxJToNpPZTYJKdjKDNrZDcbAQ.FomBExaZtEkQRHdfJkkbIXNFXhfm();
		}
		qZWOxJToNpPZTYJKdjKDNrZDcbAQ = vUXRFQkaqtxZmDdZWniajedetQiF.PKzDxdNXFVjWIeVjZiJxNOwUmSLU(CgPagdlzMlCQxkbRTPOoePMzAXof, yAxisActionName, true);
		if (qZWOxJToNpPZTYJKdjKDNrZDcbAQ != null)
		{
			result.y = qZWOxJToNpPZTYJKdjKDNrZDcbAQ.FomBExaZtEkQRHdfJkkbIXNFXhfm();
		}
		return result;
	}

	public Vector2 GetAxis2DPrev(int xAxisActionId, int yAxisActionId)
	{
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return Vector2.zero;
		}
		Vector2 result = default;
		QZWOxJToNpPZTYJKdjKDNrZDcbAQ qZWOxJToNpPZTYJKdjKDNrZDcbAQ = vUXRFQkaqtxZmDdZWniajedetQiF.tfgFiWTAWZlOVgeKFIvByhHrMtkg(CgPagdlzMlCQxkbRTPOoePMzAXof, xAxisActionId, true);
		if (qZWOxJToNpPZTYJKdjKDNrZDcbAQ != null)
		{
			result.x = qZWOxJToNpPZTYJKdjKDNrZDcbAQ.FomBExaZtEkQRHdfJkkbIXNFXhfm();
		}
		qZWOxJToNpPZTYJKdjKDNrZDcbAQ = vUXRFQkaqtxZmDdZWniajedetQiF.tfgFiWTAWZlOVgeKFIvByhHrMtkg(CgPagdlzMlCQxkbRTPOoePMzAXof, yAxisActionId, true);
		if (qZWOxJToNpPZTYJKdjKDNrZDcbAQ != null)
		{
			result.y = qZWOxJToNpPZTYJKdjKDNrZDcbAQ.FomBExaZtEkQRHdfJkkbIXNFXhfm();
		}
		return result;
	}

	public Vector2 GetAxis2DRaw(string xAxisActionName, string yAxisActionName)
	{
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return Vector2.zero;
		}
		Vector2 result = default;
		QZWOxJToNpPZTYJKdjKDNrZDcbAQ qZWOxJToNpPZTYJKdjKDNrZDcbAQ = vUXRFQkaqtxZmDdZWniajedetQiF.PKzDxdNXFVjWIeVjZiJxNOwUmSLU(CgPagdlzMlCQxkbRTPOoePMzAXof, xAxisActionName, true);
		if (qZWOxJToNpPZTYJKdjKDNrZDcbAQ != null)
		{
			result.x = qZWOxJToNpPZTYJKdjKDNrZDcbAQ.cWteTyHrjPGhfmxcPfIvYekmLaOoA();
		}
		qZWOxJToNpPZTYJKdjKDNrZDcbAQ = vUXRFQkaqtxZmDdZWniajedetQiF.PKzDxdNXFVjWIeVjZiJxNOwUmSLU(CgPagdlzMlCQxkbRTPOoePMzAXof, yAxisActionName, true);
		if (qZWOxJToNpPZTYJKdjKDNrZDcbAQ != null)
		{
			result.y = qZWOxJToNpPZTYJKdjKDNrZDcbAQ.cWteTyHrjPGhfmxcPfIvYekmLaOoA();
		}
		return result;
	}

	public Vector2 GetAxis2DRaw(int xAxisActionId, int yAxisActionId)
	{
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return Vector2.zero;
		}
		Vector2 result = default;
		QZWOxJToNpPZTYJKdjKDNrZDcbAQ qZWOxJToNpPZTYJKdjKDNrZDcbAQ = vUXRFQkaqtxZmDdZWniajedetQiF.tfgFiWTAWZlOVgeKFIvByhHrMtkg(CgPagdlzMlCQxkbRTPOoePMzAXof, xAxisActionId, true);
		if (qZWOxJToNpPZTYJKdjKDNrZDcbAQ != null)
		{
			result.x = qZWOxJToNpPZTYJKdjKDNrZDcbAQ.cWteTyHrjPGhfmxcPfIvYekmLaOoA();
		}
		qZWOxJToNpPZTYJKdjKDNrZDcbAQ = vUXRFQkaqtxZmDdZWniajedetQiF.tfgFiWTAWZlOVgeKFIvByhHrMtkg(CgPagdlzMlCQxkbRTPOoePMzAXof, yAxisActionId, true);
		if (qZWOxJToNpPZTYJKdjKDNrZDcbAQ != null)
		{
			result.y = qZWOxJToNpPZTYJKdjKDNrZDcbAQ.cWteTyHrjPGhfmxcPfIvYekmLaOoA();
		}
		return result;
	}

	public Vector2 GetAxis2DRawPrev(string xAxisActionName, string yAxisActionName)
	{
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return Vector2.zero;
		}
		Vector2 result = default;
		QZWOxJToNpPZTYJKdjKDNrZDcbAQ qZWOxJToNpPZTYJKdjKDNrZDcbAQ = vUXRFQkaqtxZmDdZWniajedetQiF.PKzDxdNXFVjWIeVjZiJxNOwUmSLU(CgPagdlzMlCQxkbRTPOoePMzAXof, xAxisActionName, true);
		if (qZWOxJToNpPZTYJKdjKDNrZDcbAQ != null)
		{
			result.x = qZWOxJToNpPZTYJKdjKDNrZDcbAQ.xfRmaCvfMrhVhcNUFLrbYbmFBqcw();
		}
		qZWOxJToNpPZTYJKdjKDNrZDcbAQ = vUXRFQkaqtxZmDdZWniajedetQiF.PKzDxdNXFVjWIeVjZiJxNOwUmSLU(CgPagdlzMlCQxkbRTPOoePMzAXof, yAxisActionName, true);
		if (qZWOxJToNpPZTYJKdjKDNrZDcbAQ != null)
		{
			result.y = qZWOxJToNpPZTYJKdjKDNrZDcbAQ.xfRmaCvfMrhVhcNUFLrbYbmFBqcw();
		}
		return result;
	}

	public Vector2 GetAxis2DRawPrev(int xAxisActionId, int yAxisActionId)
	{
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return Vector2.zero;
		}
		Vector2 result = default;
		QZWOxJToNpPZTYJKdjKDNrZDcbAQ qZWOxJToNpPZTYJKdjKDNrZDcbAQ = vUXRFQkaqtxZmDdZWniajedetQiF.tfgFiWTAWZlOVgeKFIvByhHrMtkg(CgPagdlzMlCQxkbRTPOoePMzAXof, xAxisActionId, true);
		if (qZWOxJToNpPZTYJKdjKDNrZDcbAQ != null)
		{
			result.x = qZWOxJToNpPZTYJKdjKDNrZDcbAQ.xfRmaCvfMrhVhcNUFLrbYbmFBqcw();
		}
		qZWOxJToNpPZTYJKdjKDNrZDcbAQ = vUXRFQkaqtxZmDdZWniajedetQiF.tfgFiWTAWZlOVgeKFIvByhHrMtkg(CgPagdlzMlCQxkbRTPOoePMzAXof, yAxisActionId, true);
		if (qZWOxJToNpPZTYJKdjKDNrZDcbAQ != null)
		{
			result.y = qZWOxJToNpPZTYJKdjKDNrZDcbAQ.xfRmaCvfMrhVhcNUFLrbYbmFBqcw();
		}
		return result;
	}

	public double GetAxisTimeActive(string actionName)
	{
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return 0.0;
		}
		return vUXRFQkaqtxZmDdZWniajedetQiF.PKzDxdNXFVjWIeVjZiJxNOwUmSLU(CgPagdlzMlCQxkbRTPOoePMzAXof, actionName, true)?.aevYRIdbCXgvMgEWIqWRDeBRDmZF() ?? 0.0;
	}

	public double GetAxisTimeActive(int actionId)
	{
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return 0.0;
		}
		return vUXRFQkaqtxZmDdZWniajedetQiF.tfgFiWTAWZlOVgeKFIvByhHrMtkg(CgPagdlzMlCQxkbRTPOoePMzAXof, actionId, true)?.aevYRIdbCXgvMgEWIqWRDeBRDmZF() ?? 0.0;
	}

	public double GetAxisTimeInactive(string actionName)
	{
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return 0.0;
		}
		return vUXRFQkaqtxZmDdZWniajedetQiF.PKzDxdNXFVjWIeVjZiJxNOwUmSLU(CgPagdlzMlCQxkbRTPOoePMzAXof, actionName, true)?.evtBaUVlRoumvztXgKcRKDkqnGTy() ?? 0.0;
	}

	public double GetAxisTimeInactive(int actionId)
	{
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return 0.0;
		}
		return vUXRFQkaqtxZmDdZWniajedetQiF.tfgFiWTAWZlOVgeKFIvByhHrMtkg(CgPagdlzMlCQxkbRTPOoePMzAXof, actionId, true)?.evtBaUVlRoumvztXgKcRKDkqnGTy() ?? 0.0;
	}

	public double GetAxisRawTimeActive(string actionName)
	{
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return 0.0;
		}
		return vUXRFQkaqtxZmDdZWniajedetQiF.PKzDxdNXFVjWIeVjZiJxNOwUmSLU(CgPagdlzMlCQxkbRTPOoePMzAXof, actionName, true)?.rSERnkLcjopHjuOEBmkUeqkLPyrr() ?? 0.0;
	}

	public double GetAxisRawTimeActive(int actionId)
	{
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return 0.0;
		}
		return vUXRFQkaqtxZmDdZWniajedetQiF.tfgFiWTAWZlOVgeKFIvByhHrMtkg(CgPagdlzMlCQxkbRTPOoePMzAXof, actionId, true)?.rSERnkLcjopHjuOEBmkUeqkLPyrr() ?? 0.0;
	}

	public double GetAxisRawTimeInactive(string actionName)
	{
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return 0.0;
		}
		return vUXRFQkaqtxZmDdZWniajedetQiF.PKzDxdNXFVjWIeVjZiJxNOwUmSLU(CgPagdlzMlCQxkbRTPOoePMzAXof, actionName, true)?.GyiGXqqOUBoQsvvmdSaKIrdHxtKE() ?? 0.0;
	}

	public double GetAxisRawTimeInactive(int actionId)
	{
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return 0.0;
		}
		return vUXRFQkaqtxZmDdZWniajedetQiF.tfgFiWTAWZlOVgeKFIvByhHrMtkg(CgPagdlzMlCQxkbRTPOoePMzAXof, actionId, true)?.GyiGXqqOUBoQsvvmdSaKIrdHxtKE() ?? 0.0;
	}

	public AxisCoordinateMode GetAxisCoordinateMode(string actionName)
	{
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return AxisCoordinateMode.Absolute;
		}
		return vUXRFQkaqtxZmDdZWniajedetQiF.PKzDxdNXFVjWIeVjZiJxNOwUmSLU(CgPagdlzMlCQxkbRTPOoePMzAXof, actionName, true)?.iANlwdzjObBoJzvXimKIrCGgjzLF() ?? AxisCoordinateMode.Absolute;
	}

	public AxisCoordinateMode GetAxisCoordinateMode(int actionId)
	{
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return AxisCoordinateMode.Absolute;
		}
		return vUXRFQkaqtxZmDdZWniajedetQiF.tfgFiWTAWZlOVgeKFIvByhHrMtkg(CgPagdlzMlCQxkbRTPOoePMzAXof, actionId, true)?.iANlwdzjObBoJzvXimKIrCGgjzLF() ?? AxisCoordinateMode.Absolute;
	}

	public AxisCoordinateMode GetAxisRawCoordinateMode(string actionName)
	{
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return AxisCoordinateMode.Absolute;
		}
		return vUXRFQkaqtxZmDdZWniajedetQiF.PKzDxdNXFVjWIeVjZiJxNOwUmSLU(CgPagdlzMlCQxkbRTPOoePMzAXof, actionName, true)?.WNDgfdAArCnnYBTcsfqIMxWGtKuP() ?? AxisCoordinateMode.Absolute;
	}

	public AxisCoordinateMode GetAxisRawCoordinateMode(int actionId)
	{
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return AxisCoordinateMode.Absolute;
		}
		return vUXRFQkaqtxZmDdZWniajedetQiF.tfgFiWTAWZlOVgeKFIvByhHrMtkg(CgPagdlzMlCQxkbRTPOoePMzAXof, actionId, true)?.WNDgfdAArCnnYBTcsfqIMxWGtKuP() ?? AxisCoordinateMode.Absolute;
	}

	public AxisCoordinateMode GetAxisCoordinateModePrev(string actionName)
	{
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return AxisCoordinateMode.Absolute;
		}
		return vUXRFQkaqtxZmDdZWniajedetQiF.PKzDxdNXFVjWIeVjZiJxNOwUmSLU(CgPagdlzMlCQxkbRTPOoePMzAXof, actionName, true)?.wvnBxsmdfKqoYJNWKMRppFIrzIGs() ?? AxisCoordinateMode.Absolute;
	}

	public AxisCoordinateMode GetAxisCoordinateModePrev(int actionId)
	{
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return AxisCoordinateMode.Absolute;
		}
		return vUXRFQkaqtxZmDdZWniajedetQiF.tfgFiWTAWZlOVgeKFIvByhHrMtkg(CgPagdlzMlCQxkbRTPOoePMzAXof, actionId, true)?.wvnBxsmdfKqoYJNWKMRppFIrzIGs() ?? AxisCoordinateMode.Absolute;
	}

	public AxisCoordinateMode GetAxisRawCoordinateModePrev(string actionName)
	{
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return AxisCoordinateMode.Absolute;
		}
		return vUXRFQkaqtxZmDdZWniajedetQiF.PKzDxdNXFVjWIeVjZiJxNOwUmSLU(CgPagdlzMlCQxkbRTPOoePMzAXof, actionName, true)?.MjAGUJfQgKreoThKBlsUSxKLWLMO() ?? AxisCoordinateMode.Absolute;
	}

	public AxisCoordinateMode GetAxisRawCoordinateModePrev(int actionId)
	{
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return AxisCoordinateMode.Absolute;
		}
		return vUXRFQkaqtxZmDdZWniajedetQiF.tfgFiWTAWZlOVgeKFIvByhHrMtkg(CgPagdlzMlCQxkbRTPOoePMzAXof, actionId, true)?.MjAGUJfQgKreoThKBlsUSxKLWLMO() ?? AxisCoordinateMode.Absolute;
	}

	public IList<InputActionSourceData> GetCurrentInputSources(string actionName)
	{
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return EmptyObjects<InputActionSourceData>.EmptyReadOnlyIListT;
		}
		return vUXRFQkaqtxZmDdZWniajedetQiF.PKzDxdNXFVjWIeVjZiJxNOwUmSLU(CgPagdlzMlCQxkbRTPOoePMzAXof, actionName, true)?.FkvQUzWkpTMYvnzWaUlppZhTtfNd();
	}

	public IList<InputActionSourceData> GetCurrentInputSources(int actionId)
	{
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return EmptyObjects<InputActionSourceData>.EmptyReadOnlyIListT;
		}
		return vUXRFQkaqtxZmDdZWniajedetQiF.tfgFiWTAWZlOVgeKFIvByhHrMtkg(CgPagdlzMlCQxkbRTPOoePMzAXof, actionId, true)?.FkvQUzWkpTMYvnzWaUlppZhTtfNd();
	}

	public bool IsCurrentInputSource(string actionName, ControllerType controllerType)
	{
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return false;
		}
		return vUXRFQkaqtxZmDdZWniajedetQiF.PKzDxdNXFVjWIeVjZiJxNOwUmSLU(CgPagdlzMlCQxkbRTPOoePMzAXof, actionName, true)?.WUrYmiQJbKUthJEWccecckCIxCvV(controllerType) ?? false;
	}

	public bool IsCurrentInputSource(int actionId, ControllerType controllerType)
	{
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return false;
		}
		return vUXRFQkaqtxZmDdZWniajedetQiF.tfgFiWTAWZlOVgeKFIvByhHrMtkg(CgPagdlzMlCQxkbRTPOoePMzAXof, actionId, true)?.WUrYmiQJbKUthJEWccecckCIxCvV(controllerType) ?? false;
	}

	public bool IsCurrentInputSource(string actionName, ControllerType controllerType, int controllerId)
	{
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return false;
		}
		return vUXRFQkaqtxZmDdZWniajedetQiF.PKzDxdNXFVjWIeVjZiJxNOwUmSLU(CgPagdlzMlCQxkbRTPOoePMzAXof, actionName, true)?.WivOHtUlNraTJAxthhKGJRgzkWKt(controllerType, controllerId) ?? false;
	}

	public bool IsCurrentInputSource(int actionId, ControllerType controllerType, int controllerId)
	{
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return false;
		}
		return vUXRFQkaqtxZmDdZWniajedetQiF.tfgFiWTAWZlOVgeKFIvByhHrMtkg(CgPagdlzMlCQxkbRTPOoePMzAXof, actionId, true)?.WivOHtUlNraTJAxthhKGJRgzkWKt(controllerType, controllerId) ?? false;
	}

	public bool IsCurrentInputSource(string actionName, Controller controller)
	{
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return false;
		}
		return vUXRFQkaqtxZmDdZWniajedetQiF.PKzDxdNXFVjWIeVjZiJxNOwUmSLU(CgPagdlzMlCQxkbRTPOoePMzAXof, actionName, true)?.XrIYiQKvgIGwnqhZEKXESXIusUoL(controller) ?? false;
	}

	public bool IsCurrentInputSource(int actionId, Controller controller)
	{
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return false;
		}
		return vUXRFQkaqtxZmDdZWniajedetQiF.tfgFiWTAWZlOVgeKFIvByhHrMtkg(CgPagdlzMlCQxkbRTPOoePMzAXof, actionId, true)?.XrIYiQKvgIGwnqhZEKXESXIusUoL(controller) ?? false;
	}

	public void AddInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop)
	{
		if (ReInput.isReady)
		{
			if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
			{
				ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			}
			else
			{
				vUXRFQkaqtxZmDdZWniajedetQiF.VEDeIKbNmpKpVHoyErOovBGffhwub(CgPagdlzMlCQxkbRTPOoePMzAXof, callback, updateLoop);
			}
		}
	}

	public void AddInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop, int actionId)
	{
		if (ReInput.isReady)
		{
			if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
			{
				ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			}
			else
			{
				vUXRFQkaqtxZmDdZWniajedetQiF.dqFdaJHbrcgaWEqXPMIHZsBkkhJGb(CgPagdlzMlCQxkbRTPOoePMzAXof, callback, updateLoop, actionId);
			}
		}
	}

	public void AddInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop, string actionName)
	{
		if (!ReInput.isReady)
		{
			return;
		}
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return;
		}
		int num = ReInput.IsSPFehscBAmxtEADWGWuasjDvqf.GhVjGDQeDQmOWTnROakHcfdeCdDd(actionName);
		if (num >= 0)
		{
			AddInputEventDelegate(callback, updateLoop, num);
		}
	}

	public void AddInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop, InputActionEventType eventType)
	{
		AddInputEventDelegate(callback, updateLoop, eventType, (object[])null);
	}

	public void AddInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop, InputActionEventType eventType, int actionId)
	{
		AddInputEventDelegate(callback, updateLoop, eventType, actionId, null);
	}

	public void AddInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop, InputActionEventType eventType, string actionName)
	{
		AddInputEventDelegate(callback, updateLoop, eventType, actionName, null);
	}

	public void AddInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop, InputActionEventType eventType, object[] arguments)
	{
		if (ReInput.isReady)
		{
			if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
			{
				ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			}
			else
			{
				vUXRFQkaqtxZmDdZWniajedetQiF.hjzokbvniROewDSLtnhGBmcDPqcJ(CgPagdlzMlCQxkbRTPOoePMzAXof, callback, updateLoop, eventType, arguments);
			}
		}
	}

	public void AddInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop, InputActionEventType eventType, int actionId, object[] arguments)
	{
		if (ReInput.isReady)
		{
			if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
			{
				ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			}
			else
			{
				vUXRFQkaqtxZmDdZWniajedetQiF.ymIhpVqHueudVoZxQPMzyyWySVI(CgPagdlzMlCQxkbRTPOoePMzAXof, callback, updateLoop, eventType, actionId, arguments);
			}
		}
	}

	public void AddInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop, InputActionEventType eventType, string actionName, object[] arguments)
	{
		if (!ReInput.isReady)
		{
			return;
		}
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return;
		}
		int num = ReInput.IsSPFehscBAmxtEADWGWuasjDvqf.GhVjGDQeDQmOWTnROakHcfdeCdDd(actionName, true);
		if (num >= 0)
		{
			AddInputEventDelegate(callback, updateLoop, eventType, num, arguments);
		}
	}

	public void RemoveInputEventDelegate(Action<InputActionEventData> callback)
	{
		if (ReInput.isReady)
		{
			if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
			{
				ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			}
			else
			{
				vUXRFQkaqtxZmDdZWniajedetQiF.dLaypZmXtKbCvQusacZnpBqPvznI(CgPagdlzMlCQxkbRTPOoePMzAXof, callback);
			}
		}
	}

	public void RemoveInputEventDelegate(Action<InputActionEventData> callback, int actionId)
	{
		if (ReInput.isReady)
		{
			if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
			{
				ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			}
			else
			{
				vUXRFQkaqtxZmDdZWniajedetQiF.zVGItQgmvBjdZEJeldlFIhlNyGMx(CgPagdlzMlCQxkbRTPOoePMzAXof, callback, actionId);
			}
		}
	}

	public void RemoveInputEventDelegate(Action<InputActionEventData> callback, string actionName)
	{
		if (!ReInput.isReady)
		{
			return;
		}
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return;
		}
		int num = ReInput.IsSPFehscBAmxtEADWGWuasjDvqf.GhVjGDQeDQmOWTnROakHcfdeCdDd(actionName);
		if (num >= 0)
		{
			RemoveInputEventDelegate(callback, num);
		}
	}

	public void RemoveInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop)
	{
		if (ReInput.isReady)
		{
			if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
			{
				ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			}
			else
			{
				vUXRFQkaqtxZmDdZWniajedetQiF.NIxAKIifeuvMaGfLNQvPiqEeyPmA(CgPagdlzMlCQxkbRTPOoePMzAXof, callback, updateLoop);
			}
		}
	}

	public void RemoveInputEventDelegate(Action<InputActionEventData> callback, InputActionEventType eventType)
	{
		if (ReInput.isReady)
		{
			if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
			{
				ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			}
			else
			{
				vUXRFQkaqtxZmDdZWniajedetQiF.CYfsLPBBqxnjNAtfkkEqDopgoGWX(CgPagdlzMlCQxkbRTPOoePMzAXof, callback, eventType);
			}
		}
	}

	public void RemoveInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop, int actionId)
	{
		if (ReInput.isReady)
		{
			if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
			{
				ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			}
			else
			{
				vUXRFQkaqtxZmDdZWniajedetQiF.wQItxeeZXyHRKVevThnXNoRyXrDC(CgPagdlzMlCQxkbRTPOoePMzAXof, callback, updateLoop, actionId);
			}
		}
	}

	public void RemoveInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop, string actionName)
	{
		if (!ReInput.isReady)
		{
			return;
		}
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return;
		}
		int num = ReInput.IsSPFehscBAmxtEADWGWuasjDvqf.GhVjGDQeDQmOWTnROakHcfdeCdDd(actionName);
		if (num >= 0)
		{
			RemoveInputEventDelegate(callback, updateLoop, num);
		}
	}

	public void RemoveInputEventDelegate(Action<InputActionEventData> callback, InputActionEventType eventType, int actionId)
	{
		if (ReInput.isReady)
		{
			if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
			{
				ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			}
			else
			{
				vUXRFQkaqtxZmDdZWniajedetQiF.IvzIewfdqqZrjOrKxuabVLduarZeA(CgPagdlzMlCQxkbRTPOoePMzAXof, callback, eventType, actionId);
			}
		}
	}

	public void RemoveInputEventDelegate(Action<InputActionEventData> callback, InputActionEventType eventType, string actionName)
	{
		if (!ReInput.isReady)
		{
			return;
		}
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return;
		}
		int num = ReInput.IsSPFehscBAmxtEADWGWuasjDvqf.GhVjGDQeDQmOWTnROakHcfdeCdDd(actionName);
		if (num >= 0)
		{
			RemoveInputEventDelegate(callback, eventType, num);
		}
	}

	public void RemoveInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop, InputActionEventType eventType)
	{
		if (ReInput.isReady)
		{
			if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
			{
				ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			}
			else
			{
				vUXRFQkaqtxZmDdZWniajedetQiF.MKYMpHdEcJBwjyeCLgpxfJwrkwvcA(CgPagdlzMlCQxkbRTPOoePMzAXof, callback, updateLoop, eventType);
			}
		}
	}

	public void RemoveInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop, InputActionEventType eventType, int actionId)
	{
		if (ReInput.isReady)
		{
			if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
			{
				ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			}
			else
			{
				vUXRFQkaqtxZmDdZWniajedetQiF.KdDfQJSOpAGxGiGjxDHRiALsfAPaA(CgPagdlzMlCQxkbRTPOoePMzAXof, callback, updateLoop, eventType, actionId);
			}
		}
	}

	public void RemoveInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop, InputActionEventType eventType, string actionName)
	{
		if (!ReInput.isReady)
		{
			return;
		}
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return;
		}
		int num = ReInput.IsSPFehscBAmxtEADWGWuasjDvqf.GhVjGDQeDQmOWTnROakHcfdeCdDd(actionName);
		if (num >= 0)
		{
			RemoveInputEventDelegate(callback, updateLoop, eventType, num);
		}
	}

	public void ClearInputEventDelegates()
	{
		if (ReInput.isReady)
		{
			if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
			{
				ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			}
			else
			{
				vUXRFQkaqtxZmDdZWniajedetQiF.utSCGVpMvVvXlFlReVxWoXjJttQk(CgPagdlzMlCQxkbRTPOoePMzAXof);
			}
		}
	}

	public void SetVibration(int motorIndex, float motorLevel)
	{
		SetVibration(motorIndex, motorLevel, 0f, stopOtherMotors: false);
	}

	public void SetVibration(int motorIndex, float motorLevel, float duration)
	{
		SetVibration(motorIndex, motorLevel, duration, stopOtherMotors: false);
	}

	public void SetVibration(int motorIndex, float motorLevel, bool stopOtherMotors)
	{
		SetVibration(motorIndex, motorLevel, 0f, stopOtherMotors);
	}

	public void SetVibration(int motorIndex, float motorLevel, float duration, bool stopOtherMotors)
	{
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return;
		}
		IList<Joystick> joysticks = controllers.Joysticks;
		int count = joysticks.Count;
		for (int i = 0; i < count; i++)
		{
			Joystick joystick = joysticks[i];
			if (joystick.supportsVibration)
			{
				joystick.SetVibration(motorIndex, motorLevel, duration, stopOtherMotors);
			}
		}
	}

	public float GetVibration(int motorIndex)
	{
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return 0f;
		}
		IList<Joystick> joysticks = controllers.Joysticks;
		int count = joysticks.Count;
		float num = 0f;
		for (int i = 0; i < count; i++)
		{
			Joystick joystick = joysticks[i];
			if (joystick.supportsVibration)
			{
				num = MathTools.Max(joystick.GetVibration(motorIndex), num);
			}
		}
		return num;
	}

	public void StopVibration()
	{
		if (ReInput._id != cJIHaPRbmurRvOwLumpIEntTbHmu)
		{
			ReInput.CheckInitialized(cJIHaPRbmurRvOwLumpIEntTbHmu);
			return;
		}
		IList<Joystick> joysticks = controllers.Joysticks;
		int count = joysticks.Count;
		for (int i = 0; i < count; i++)
		{
			Joystick joystick = joysticks[i];
			if (joystick.supportsVibration)
			{
				joystick.StopVibration();
			}
		}
	}

	internal void MzVPAHDZISDqZBJQFGyACkeOBWFCA()
	{
		kfEsCAAFejRZmDDBjGXfKAhlhtGkA();
	}

	private void kfEsCAAFejRZmDDBjGXfKAhlhtGkA()
	{
		controllers.uXeROrvefFFKRFVEgMyTdZygxxPNB();
		nlQfaOUQEOypRgVArWSgAzwXYGAA = false;
	}
}
