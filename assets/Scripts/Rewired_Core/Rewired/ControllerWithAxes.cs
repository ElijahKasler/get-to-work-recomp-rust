using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Rewired.Data.Mapping;
using Rewired.Interfaces;
using Rewired.Utils;
using UnityEngine;

namespace Rewired;

public abstract class ControllerWithAxes : ControllerWithMap
{
	private sealed class lrhUTEFCFYiDFdasGCFbaBVAENVQA : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
	{
		private int VcZcOqIEiWOowYWLjIpoOYJVWZRuA;

		private ControllerPollingInfo bNBHSyFjlGNRtWyZQKbyjCfYCEedA;

		private int iJVqOzwYRFuOCBksbocFwapLeTnR;

		public ControllerWithAxes ZgUlhXVFxHDuRFSpkYwlstprSRNoA;

		private int eemEncrAcBGAlUfACvnWdHzTbPgDA;

		ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
		{
			[DebuggerHidden]
			get
			{
				return bNBHSyFjlGNRtWyZQKbyjCfYCEedA;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return bNBHSyFjlGNRtWyZQKbyjCfYCEedA;
			}
		}

		[DebuggerHidden]
		public lrhUTEFCFYiDFdasGCFbaBVAENVQA(int P_0)
		{
			VcZcOqIEiWOowYWLjIpoOYJVWZRuA = P_0;
			iJVqOzwYRFuOCBksbocFwapLeTnR = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			int vcZcOqIEiWOowYWLjIpoOYJVWZRuA = VcZcOqIEiWOowYWLjIpoOYJVWZRuA;
			ControllerWithAxes zgUlhXVFxHDuRFSpkYwlstprSRNoA = ZgUlhXVFxHDuRFSpkYwlstprSRNoA;
			if (vcZcOqIEiWOowYWLjIpoOYJVWZRuA != 0)
			{
				if (vcZcOqIEiWOowYWLjIpoOYJVWZRuA != 1)
				{
					return false;
				}
				VcZcOqIEiWOowYWLjIpoOYJVWZRuA = -1;
				goto IL_00a8;
			}
			VcZcOqIEiWOowYWLjIpoOYJVWZRuA = -1;
			if (ReInput._id != zgUlhXVFxHDuRFSpkYwlstprSRNoA.qostqwFsdWROzwZYaTyZVeYSeDOM)
			{
				ReInput.CheckInitialized(zgUlhXVFxHDuRFSpkYwlstprSRNoA.qostqwFsdWROzwZYaTyZVeYSeDOM);
				return false;
			}
			zgUlhXVFxHDuRFSpkYwlstprSRNoA.UpdatePollingFrameTracking();
			zgUlhXVFxHDuRFSpkYwlstprSRNoA.nXsSyCSCRjABGjgYTQBmncdrdjznA();
			eemEncrAcBGAlUfACvnWdHzTbPgDA = 0;
			goto IL_00ba;
			IL_00ba:
			if (eemEncrAcBGAlUfACvnWdHzTbPgDA < zgUlhXVFxHDuRFSpkYwlstprSRNoA._axisCount)
			{
				if (zgUlhXVFxHDuRFSpkYwlstprSRNoA.IsPolledAxisActive(eemEncrAcBGAlUfACvnWdHzTbPgDA, out var pole, out var elementIdentifierId))
				{
					bNBHSyFjlGNRtWyZQKbyjCfYCEedA = new ControllerPollingInfo(true, -1, zgUlhXVFxHDuRFSpkYwlstprSRNoA.id, zgUlhXVFxHDuRFSpkYwlstprSRNoA._name, zgUlhXVFxHDuRFSpkYwlstprSRNoA._type, ControllerElementType.Axis, eemEncrAcBGAlUfACvnWdHzTbPgDA, pole, zgUlhXVFxHDuRFSpkYwlstprSRNoA.aHJMAWzbypGgwCcRCqDEaoqVGwfA.GetElementIdentifierName(elementIdentifierId), elementIdentifierId, KeyCode.None);
					VcZcOqIEiWOowYWLjIpoOYJVWZRuA = 1;
					return true;
				}
				goto IL_00a8;
			}
			return false;
			IL_00a8:
			eemEncrAcBGAlUfACvnWdHzTbPgDA++;
			goto IL_00ba;
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
			lrhUTEFCFYiDFdasGCFbaBVAENVQA lrhUTEFCFYiDFdasGCFbaBVAENVQA2;
			if (VcZcOqIEiWOowYWLjIpoOYJVWZRuA == -2 && iJVqOzwYRFuOCBksbocFwapLeTnR == Environment.CurrentManagedThreadId)
			{
				VcZcOqIEiWOowYWLjIpoOYJVWZRuA = 0;
				lrhUTEFCFYiDFdasGCFbaBVAENVQA2 = this;
			}
			else
			{
				lrhUTEFCFYiDFdasGCFbaBVAENVQA2 = new lrhUTEFCFYiDFdasGCFbaBVAENVQA(0);
				lrhUTEFCFYiDFdasGCFbaBVAENVQA2.ZgUlhXVFxHDuRFSpkYwlstprSRNoA = ZgUlhXVFxHDuRFSpkYwlstprSRNoA;
			}
			return lrhUTEFCFYiDFdasGCFbaBVAENVQA2;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
		}
	}

	private sealed class lMzGrDcOoBhvvaWOTcRyVlLCFxrYA : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
	{
		private int DAtxycFQRDKapKwPGRByujwubfEEA;

		private ControllerPollingInfo JDmwNRFdnXKCCCTBqeVDNHOIHcVG;

		private int PUAXODFsEIROMnQPOIEKNbpawgzr;

		public ControllerWithAxes OGlamHLgbfSYXoQNmyxtLBxYueee;

		private IEnumerator<ControllerPollingInfo> YzyDCjCSbGpMLbgNEWIwluhhQRGnA;

		ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
		{
			[DebuggerHidden]
			get
			{
				return JDmwNRFdnXKCCCTBqeVDNHOIHcVG;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return JDmwNRFdnXKCCCTBqeVDNHOIHcVG;
			}
		}

		[DebuggerHidden]
		public lMzGrDcOoBhvvaWOTcRyVlLCFxrYA(int P_0)
		{
			DAtxycFQRDKapKwPGRByujwubfEEA = P_0;
			PUAXODFsEIROMnQPOIEKNbpawgzr = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			switch (DAtxycFQRDKapKwPGRByujwubfEEA)
			{
			case -3:
			case 1:
				try
				{
					break;
				}
				finally
				{
					sGKckeEemMaJhXzfRmuGGkhOQBwoA();
				}
			case -4:
			case 2:
				try
				{
					break;
				}
				finally
				{
					SujiSxklMphomgmHKsqhsxUQwWbJA();
				}
			case -2:
			case -1:
			case 0:
				break;
			}
		}

		private bool MoveNext()
		{
			try
			{
				int dAtxycFQRDKapKwPGRByujwubfEEA = DAtxycFQRDKapKwPGRByujwubfEEA;
				ControllerWithAxes oGlamHLgbfSYXoQNmyxtLBxYueee = OGlamHLgbfSYXoQNmyxtLBxYueee;
				switch (dAtxycFQRDKapKwPGRByujwubfEEA)
				{
				default:
					return false;
				case 0:
					DAtxycFQRDKapKwPGRByujwubfEEA = -1;
					if (ReInput._id != oGlamHLgbfSYXoQNmyxtLBxYueee.qostqwFsdWROzwZYaTyZVeYSeDOM)
					{
						ReInput.CheckInitialized(oGlamHLgbfSYXoQNmyxtLBxYueee.qostqwFsdWROzwZYaTyZVeYSeDOM);
						return false;
					}
					YzyDCjCSbGpMLbgNEWIwluhhQRGnA = ((Controller)oGlamHLgbfSYXoQNmyxtLBxYueee).PollForAllElements().GetEnumerator();
					DAtxycFQRDKapKwPGRByujwubfEEA = -3;
					goto IL_0092;
				case 1:
					DAtxycFQRDKapKwPGRByujwubfEEA = -3;
					goto IL_0092;
				case 2:
					{
						DAtxycFQRDKapKwPGRByujwubfEEA = -4;
						break;
					}
					IL_0092:
					if (YzyDCjCSbGpMLbgNEWIwluhhQRGnA.MoveNext())
					{
						ControllerPollingInfo current = YzyDCjCSbGpMLbgNEWIwluhhQRGnA.Current;
						JDmwNRFdnXKCCCTBqeVDNHOIHcVG = current;
						DAtxycFQRDKapKwPGRByujwubfEEA = 1;
						return true;
					}
					sGKckeEemMaJhXzfRmuGGkhOQBwoA();
					YzyDCjCSbGpMLbgNEWIwluhhQRGnA = null;
					YzyDCjCSbGpMLbgNEWIwluhhQRGnA = oGlamHLgbfSYXoQNmyxtLBxYueee.PollForAllAxes().GetEnumerator();
					DAtxycFQRDKapKwPGRByujwubfEEA = -4;
					break;
				}
				if (YzyDCjCSbGpMLbgNEWIwluhhQRGnA.MoveNext())
				{
					ControllerPollingInfo current2 = YzyDCjCSbGpMLbgNEWIwluhhQRGnA.Current;
					JDmwNRFdnXKCCCTBqeVDNHOIHcVG = current2;
					DAtxycFQRDKapKwPGRByujwubfEEA = 2;
					return true;
				}
				SujiSxklMphomgmHKsqhsxUQwWbJA();
				YzyDCjCSbGpMLbgNEWIwluhhQRGnA = null;
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

		private void sGKckeEemMaJhXzfRmuGGkhOQBwoA()
		{
			DAtxycFQRDKapKwPGRByujwubfEEA = -1;
			if (YzyDCjCSbGpMLbgNEWIwluhhQRGnA != null)
			{
				YzyDCjCSbGpMLbgNEWIwluhhQRGnA.Dispose();
			}
		}

		private void SujiSxklMphomgmHKsqhsxUQwWbJA()
		{
			DAtxycFQRDKapKwPGRByujwubfEEA = -1;
			if (YzyDCjCSbGpMLbgNEWIwluhhQRGnA != null)
			{
				YzyDCjCSbGpMLbgNEWIwluhhQRGnA.Dispose();
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
			lMzGrDcOoBhvvaWOTcRyVlLCFxrYA lMzGrDcOoBhvvaWOTcRyVlLCFxrYA2;
			if (DAtxycFQRDKapKwPGRByujwubfEEA == -2 && PUAXODFsEIROMnQPOIEKNbpawgzr == Environment.CurrentManagedThreadId)
			{
				DAtxycFQRDKapKwPGRByujwubfEEA = 0;
				lMzGrDcOoBhvvaWOTcRyVlLCFxrYA2 = this;
			}
			else
			{
				lMzGrDcOoBhvvaWOTcRyVlLCFxrYA2 = new lMzGrDcOoBhvvaWOTcRyVlLCFxrYA(0);
				lMzGrDcOoBhvvaWOTcRyVlLCFxrYA2.OGlamHLgbfSYXoQNmyxtLBxYueee = OGlamHLgbfSYXoQNmyxtLBxYueee;
			}
			return lMzGrDcOoBhvvaWOTcRyVlLCFxrYA2;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
		}
	}

	private sealed class HSyfqQOoTgbWWdSnjwwPcErBOoBP : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
	{
		private int rtmCnPZDijqHUJzHVgfGkNQMtHnW;

		private ControllerPollingInfo gIXFYlqHvZbPnsFaignwCYFsZJWHA;

		private int WlenCeRHITevUiawObquMRVvVkNP;

		public ControllerWithAxes HnhBjRdDbeWCRWWQJDMJAinAvelZA;

		private IEnumerator<ControllerPollingInfo> PtWphnNqwlBojKLCuOWkonHDXGTUA;

		ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
		{
			[DebuggerHidden]
			get
			{
				return gIXFYlqHvZbPnsFaignwCYFsZJWHA;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return gIXFYlqHvZbPnsFaignwCYFsZJWHA;
			}
		}

		[DebuggerHidden]
		public HSyfqQOoTgbWWdSnjwwPcErBOoBP(int P_0)
		{
			rtmCnPZDijqHUJzHVgfGkNQMtHnW = P_0;
			WlenCeRHITevUiawObquMRVvVkNP = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			switch (rtmCnPZDijqHUJzHVgfGkNQMtHnW)
			{
			case -3:
			case 1:
				try
				{
					break;
				}
				finally
				{
					mWuWQvHoYfHyVSkLidpXSlXnAAYp();
				}
			case -4:
			case 2:
				try
				{
					break;
				}
				finally
				{
					OmWDMuDquNZKwcwtNitRTCGFQBtk();
				}
			case -2:
			case -1:
			case 0:
				break;
			}
		}

		private bool MoveNext()
		{
			try
			{
				int num = rtmCnPZDijqHUJzHVgfGkNQMtHnW;
				ControllerWithAxes hnhBjRdDbeWCRWWQJDMJAinAvelZA = HnhBjRdDbeWCRWWQJDMJAinAvelZA;
				switch (num)
				{
				default:
					return false;
				case 0:
					rtmCnPZDijqHUJzHVgfGkNQMtHnW = -1;
					if (ReInput._id != hnhBjRdDbeWCRWWQJDMJAinAvelZA.qostqwFsdWROzwZYaTyZVeYSeDOM)
					{
						ReInput.CheckInitialized(hnhBjRdDbeWCRWWQJDMJAinAvelZA.qostqwFsdWROzwZYaTyZVeYSeDOM);
						return false;
					}
					PtWphnNqwlBojKLCuOWkonHDXGTUA = ((Controller)hnhBjRdDbeWCRWWQJDMJAinAvelZA).PollForAllElementsDown().GetEnumerator();
					rtmCnPZDijqHUJzHVgfGkNQMtHnW = -3;
					goto IL_0092;
				case 1:
					rtmCnPZDijqHUJzHVgfGkNQMtHnW = -3;
					goto IL_0092;
				case 2:
					{
						rtmCnPZDijqHUJzHVgfGkNQMtHnW = -4;
						break;
					}
					IL_0092:
					if (PtWphnNqwlBojKLCuOWkonHDXGTUA.MoveNext())
					{
						ControllerPollingInfo current = PtWphnNqwlBojKLCuOWkonHDXGTUA.Current;
						gIXFYlqHvZbPnsFaignwCYFsZJWHA = current;
						rtmCnPZDijqHUJzHVgfGkNQMtHnW = 1;
						return true;
					}
					mWuWQvHoYfHyVSkLidpXSlXnAAYp();
					PtWphnNqwlBojKLCuOWkonHDXGTUA = null;
					PtWphnNqwlBojKLCuOWkonHDXGTUA = hnhBjRdDbeWCRWWQJDMJAinAvelZA.PollForAllAxes().GetEnumerator();
					rtmCnPZDijqHUJzHVgfGkNQMtHnW = -4;
					break;
				}
				if (PtWphnNqwlBojKLCuOWkonHDXGTUA.MoveNext())
				{
					ControllerPollingInfo current2 = PtWphnNqwlBojKLCuOWkonHDXGTUA.Current;
					gIXFYlqHvZbPnsFaignwCYFsZJWHA = current2;
					rtmCnPZDijqHUJzHVgfGkNQMtHnW = 2;
					return true;
				}
				OmWDMuDquNZKwcwtNitRTCGFQBtk();
				PtWphnNqwlBojKLCuOWkonHDXGTUA = null;
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

		private void mWuWQvHoYfHyVSkLidpXSlXnAAYp()
		{
			rtmCnPZDijqHUJzHVgfGkNQMtHnW = -1;
			if (PtWphnNqwlBojKLCuOWkonHDXGTUA != null)
			{
				PtWphnNqwlBojKLCuOWkonHDXGTUA.Dispose();
			}
		}

		private void OmWDMuDquNZKwcwtNitRTCGFQBtk()
		{
			rtmCnPZDijqHUJzHVgfGkNQMtHnW = -1;
			if (PtWphnNqwlBojKLCuOWkonHDXGTUA != null)
			{
				PtWphnNqwlBojKLCuOWkonHDXGTUA.Dispose();
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
			HSyfqQOoTgbWWdSnjwwPcErBOoBP hSyfqQOoTgbWWdSnjwwPcErBOoBP;
			if (rtmCnPZDijqHUJzHVgfGkNQMtHnW == -2 && WlenCeRHITevUiawObquMRVvVkNP == Environment.CurrentManagedThreadId)
			{
				rtmCnPZDijqHUJzHVgfGkNQMtHnW = 0;
				hSyfqQOoTgbWWdSnjwwPcErBOoBP = this;
			}
			else
			{
				hSyfqQOoTgbWWdSnjwwPcErBOoBP = new HSyfqQOoTgbWWdSnjwwPcErBOoBP(0);
				hSyfqQOoTgbWWdSnjwwPcErBOoBP.HnhBjRdDbeWCRWWQJDMJAinAvelZA = HnhBjRdDbeWCRWWQJDMJAinAvelZA;
			}
			return hSyfqQOoTgbWWdSnjwwPcErBOoBP;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
		}
	}

	protected readonly int _axisCount;

	protected readonly int _axis2DCount;

	protected readonly Axis[] axes;

	protected readonly ReadOnlyCollection<Axis> axes_readOnly;

	protected readonly Axis2D[] axes2D;

	protected readonly ReadOnlyCollection<Axis2D> axes2D_readOnly;

	protected readonly CalibrationMap _calibrationMap;

	private float[] ufBAQDUYetDudZhEubfpCzjeCZqS;

	private uint tzdqVJjcIeDMjNymLDIqhjohzdxJ = uint.MaxValue;

	private Func<int, int> jkFhRlNLcumxchAepFKXIYxNsKgFA;

	public int axisCount
	{
		get
		{
			if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
			{
				ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
				return 0;
			}
			return _axisCount;
		}
	}

	public int axis2DCount
	{
		get
		{
			if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
			{
				ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
				return 0;
			}
			return _axis2DCount;
		}
	}

	public IList<Axis> Axes
	{
		get
		{
			if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
			{
				ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
				return EmptyObjects<Axis>.EmptyReadOnlyIListT;
			}
			return axes_readOnly;
		}
	}

	public IList<Axis2D> Axes2D
	{
		get
		{
			if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
			{
				ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
				return EmptyObjects<Axis2D>.EmptyReadOnlyIListT;
			}
			return axes2D_readOnly;
		}
	}

	public CalibrationMap calibrationMap
	{
		get
		{
			if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
			{
				ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
				return null;
			}
			return _calibrationMap;
		}
	}

	public IList<ControllerElementIdentifier> AxisElementIdentifiers
	{
		get
		{
			if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
			{
				ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
				return EmptyObjects<ControllerElementIdentifier>.EmptyReadOnlyIListT;
			}
			return aHJMAWzbypGgwCcRCqDEaoqVGwfA.axisElementIdentifiers_readOnly;
		}
	}

	internal ControllerWithAxes(int P_0, InputSource P_1, string P_2, string P_3, string P_4, ControllerType P_5, Guid P_6, int P_7, int P_8, bool[] P_9, HardwareControllerMap_Game P_10, Extension P_11, ControllerDataUpdater P_12)
		: base(P_0, P_1, P_2, P_3, P_4, P_5, P_6, P_8, P_9, P_10, P_11, P_12)
	{
		_axisCount = P_7;
		axes = new Axis[P_7];
		for (int i = 0; i < P_7; i++)
		{
			axes[i] = new Axis(this, P_10.axisElementIdentifierIds[i], "Axis " + i, P_10.hwAxisRanges[i], P_10.hwAxisInfo[i]);
			zkXRkxAwhqLFVfoSYoVfrkjAcGlp(axes[i]);
		}
		axes_readOnly = new ReadOnlyCollection<Axis>(axes);
		Func<int, int> func = null;
		if (base.extension is IAxisCalibrationIndexMap)
		{
			func = (int num2) => (base.extension is IAxisCalibrationIndexMap axisCalibrationIndexMap) ? axisCalibrationIndexMap.GetMappedAxisIndex(num2) : num2;
		}
		_calibrationMap = new CalibrationMap(P_10.hwAxisCalibrationData, func);
		_axis2DCount = P_10.axis2DCount;
		axes2D = new Axis2D[_axis2DCount];
		for (int num = 0; num < _axis2DCount; num++)
		{
			try
			{
				HardwareJoystickMap.CompoundElement axis2DData = P_10.GetAxis2DData(num);
				if (axis2DData == null)
				{
					Logger.LogError("Error creating Axis2D from hardware map! CompoundElement is null!");
					axes2D[num] = new Axis2D(this, axis2DData.elementIdentifier, "Axis 2D " + num, null, null, 0, 0, null);
					continue;
				}
				int axisIndex = P_10.GetAxisIndex(axis2DData.componentElementIdentifiers[0]);
				int axisIndex2 = P_10.GetAxisIndex(axis2DData.componentElementIdentifiers[1]);
				if (axisIndex < 0 || axisIndex >= _axisCount || axisIndex2 < 0 || axisIndex2 >= _axisCount)
				{
					axes2D[num] = new Axis2D(this, axis2DData.elementIdentifier, "Axis 2D " + num, null, null, 0, 0, null);
				}
				else
				{
					axes2D[num] = new Axis2D(this, axis2DData.elementIdentifier, "Axis 2D " + num, axes[axisIndex], axes[axisIndex2], axisIndex, axisIndex2, _calibrationMap);
				}
			}
			catch
			{
				Logger.LogError("Error creating Axis2D from hardware map! An exception was thrown.");
				axes2D[num] = new Axis2D(this, -1, "Axis 2D " + num, null, null, 0, 0, null);
			}
			finally
			{
				SYaLjMzEtoNlbrCmTQhhELphwWfk(axes2D[num]);
			}
		}
		axes2D_readOnly = new ReadOnlyCollection<Axis2D>(axes2D);
		CeXdgYVkmVgqUePqRxHGliplnGz();
		jkFhRlNLcumxchAepFKXIYxNsKgFA = P_10.GetAxisIndex;
	}

	public override Element GetElementById(int elementIdentifierId)
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
		Element elementById = base.GetElementById(elementIdentifierId);
		if (elementById != null)
		{
			return elementById;
		}
		int axisIndex = aHJMAWzbypGgwCcRCqDEaoqVGwfA.GetAxisIndex(elementIdentifierId);
		if (axisIndex < 0)
		{
			return null;
		}
		return axes[axisIndex];
	}

	public int GetAxisIndexById(int elementIdentifierId)
	{
		if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
		{
			ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
			return -1;
		}
		return aHJMAWzbypGgwCcRCqDEaoqVGwfA.GetAxisIndex(elementIdentifierId);
	}

	public float GetAxis(int index)
	{
		if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
		{
			ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
			return 0f;
		}
		if (index < 0 || index >= _axisCount)
		{
			return 0f;
		}
		return axes[index].value;
	}

	public float GetAxisPrev(int index)
	{
		if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
		{
			ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
			return 0f;
		}
		if (index < 0 || index >= _axisCount)
		{
			return 0f;
		}
		return axes[index].valuePrev;
	}

	public float GetAxisRaw(int index)
	{
		if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
		{
			ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
			return 0f;
		}
		if (index < 0 || index >= _axisCount)
		{
			return 0f;
		}
		return axes[index].valueRaw;
	}

	public float GetAxisRawPrev(int index)
	{
		if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
		{
			ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
			return 0f;
		}
		if (index < 0 || index >= _axisCount)
		{
			return 0f;
		}
		return axes[index].valueRawPrev;
	}

	public double GetAxisTimeActive(int index)
	{
		if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
		{
			ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
			return 0.0;
		}
		if (index < 0 || index >= _axisCount)
		{
			return 0.0;
		}
		return axes[index].timeActive;
	}

	public double GetAxisTimeInactive(int index)
	{
		if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
		{
			ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
			return 0.0;
		}
		if (index < 0 || index >= _axisCount)
		{
			return 0.0;
		}
		return axes[index].timeInactive;
	}

	public double GetAxisLastTimeActive(int index)
	{
		if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
		{
			ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
			return 0.0;
		}
		if (index < 0 || index >= _axisCount)
		{
			return 0.0;
		}
		return axes[index].lastTimeActive;
	}

	public double GetAxisLastTimeInactive(int index)
	{
		if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
		{
			ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
			return 0.0;
		}
		if (index < 0 || index >= _axisCount)
		{
			return 0.0;
		}
		return axes[index].lastTimeInactive;
	}

	public double GetAxisRawTimeActive(int index)
	{
		if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
		{
			ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
			return 0.0;
		}
		if (index < 0 || index >= _axisCount)
		{
			return 0.0;
		}
		return axes[index].timeActiveRaw;
	}

	public double GetAxisRawTimeInactive(int index)
	{
		if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
		{
			ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
			return 0.0;
		}
		if (index < 0 || index >= _axisCount)
		{
			return 0.0;
		}
		return axes[index].timeInactiveRaw;
	}

	public double GetAxisRawLastTimeActive(int index)
	{
		if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
		{
			ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
			return 0.0;
		}
		if (index < 0 || index >= _axisCount)
		{
			return 0.0;
		}
		return axes[index].lastTimeActiveRaw;
	}

	public double GetAxisRawLastTimeInactive(int index)
	{
		if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
		{
			ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
			return 0.0;
		}
		if (index < 0 || index >= _axisCount)
		{
			return 0.0;
		}
		return axes[index].lastTimeInactiveRaw;
	}

	public float GetAxisById(int elementIdentifierId)
	{
		if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
		{
			ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
			return 0f;
		}
		int axisIndex = aHJMAWzbypGgwCcRCqDEaoqVGwfA.GetAxisIndex(elementIdentifierId);
		if (axisIndex < 0 || axisIndex >= _axisCount)
		{
			return 0f;
		}
		return axes[axisIndex].value;
	}

	public float GetAxisPrevById(int elementIdentifierId)
	{
		if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
		{
			ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
			return 0f;
		}
		int axisIndex = aHJMAWzbypGgwCcRCqDEaoqVGwfA.GetAxisIndex(elementIdentifierId);
		if (axisIndex < 0 || axisIndex >= _axisCount)
		{
			return 0f;
		}
		return axes[axisIndex].valuePrev;
	}

	public float GetAxisRawById(int elementIdentifierId)
	{
		if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
		{
			ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
			return 0f;
		}
		int axisIndex = aHJMAWzbypGgwCcRCqDEaoqVGwfA.GetAxisIndex(elementIdentifierId);
		if (axisIndex < 0 || axisIndex >= _axisCount)
		{
			return 0f;
		}
		return axes[axisIndex].valueRaw;
	}

	public float GetAxisRawPrevById(int elementIdentifierId)
	{
		if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
		{
			ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
			return 0f;
		}
		int axisIndex = aHJMAWzbypGgwCcRCqDEaoqVGwfA.GetAxisIndex(elementIdentifierId);
		if (axisIndex < 0 || axisIndex >= _axisCount)
		{
			return 0f;
		}
		return axes[axisIndex].valueRawPrev;
	}

	public double GetAxisTimeActiveById(int elementIdentifierId)
	{
		if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
		{
			ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
			return 0.0;
		}
		int axisIndex = aHJMAWzbypGgwCcRCqDEaoqVGwfA.GetAxisIndex(elementIdentifierId);
		if (axisIndex < 0 || axisIndex >= _axisCount)
		{
			return 0.0;
		}
		return axes[axisIndex].timeActive;
	}

	public double GetAxisTimeInactiveById(int elementIdentifierId)
	{
		if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
		{
			ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
			return 0.0;
		}
		int axisIndex = aHJMAWzbypGgwCcRCqDEaoqVGwfA.GetAxisIndex(elementIdentifierId);
		if (axisIndex < 0 || axisIndex >= _axisCount)
		{
			return 0.0;
		}
		return axes[axisIndex].timeInactive;
	}

	public double GetAxisLastTimeActiveById(int elementIdentifierId)
	{
		if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
		{
			ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
			return 0.0;
		}
		int axisIndex = aHJMAWzbypGgwCcRCqDEaoqVGwfA.GetAxisIndex(elementIdentifierId);
		if (axisIndex < 0 || axisIndex >= _axisCount)
		{
			return 0.0;
		}
		return axes[axisIndex].lastTimeActive;
	}

	public double GetAxisLastTimeInactiveById(int elementIdentifierId)
	{
		if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
		{
			ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
			return 0.0;
		}
		int axisIndex = aHJMAWzbypGgwCcRCqDEaoqVGwfA.GetAxisIndex(elementIdentifierId);
		if (axisIndex < 0 || axisIndex >= _axisCount)
		{
			return 0.0;
		}
		return axes[axisIndex].lastTimeInactive;
	}

	public double GetAxisRawTimeActiveById(int elementIdentifierId)
	{
		if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
		{
			ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
			return 0.0;
		}
		int axisIndex = aHJMAWzbypGgwCcRCqDEaoqVGwfA.GetAxisIndex(elementIdentifierId);
		if (axisIndex < 0 || axisIndex >= _axisCount)
		{
			return 0.0;
		}
		return axes[axisIndex].timeActiveRaw;
	}

	public double GetAxisRawTimeInactiveById(int elementIdentifierId)
	{
		if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
		{
			ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
			return 0.0;
		}
		int axisIndex = aHJMAWzbypGgwCcRCqDEaoqVGwfA.GetAxisIndex(elementIdentifierId);
		if (axisIndex < 0 || axisIndex >= _axisCount)
		{
			return 0.0;
		}
		return axes[axisIndex].timeInactiveRaw;
	}

	public double GetAxisRawLastTimeActiveById(int elementIdentifierId)
	{
		if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
		{
			ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
			return 0.0;
		}
		int axisIndex = aHJMAWzbypGgwCcRCqDEaoqVGwfA.GetAxisIndex(elementIdentifierId);
		if (axisIndex < 0 || axisIndex >= _axisCount)
		{
			return 0.0;
		}
		return axes[axisIndex].lastTimeActiveRaw;
	}

	public double GetAxisRawLastTimeInactiveById(int elementIdentifierId)
	{
		if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
		{
			ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
			return 0.0;
		}
		int axisIndex = aHJMAWzbypGgwCcRCqDEaoqVGwfA.GetAxisIndex(elementIdentifierId);
		if (axisIndex < 0 || axisIndex >= _axisCount)
		{
			return 0.0;
		}
		return axes[axisIndex].lastTimeInactiveRaw;
	}

	public Vector2 GetAxis2D(int index)
	{
		if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
		{
			ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
			return Vector2.zero;
		}
		if (index < 0 || index >= _axis2DCount)
		{
			return default;
		}
		return axes2D[index].value;
	}

	public Vector2 GetAxis2DPrev(int index)
	{
		if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
		{
			ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
			return Vector2.zero;
		}
		if (index < 0 || index >= _axis2DCount)
		{
			return default;
		}
		return axes2D[index].valuePrev;
	}

	public Vector2 GetAxis2DRaw(int index)
	{
		if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
		{
			ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
			return Vector2.zero;
		}
		if (index < 0 || index >= _axis2DCount)
		{
			return default;
		}
		return axes2D[index].valueRaw;
	}

	public Vector2 GetAxis2DRawPrev(int index)
	{
		if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
		{
			ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
			return Vector2.zero;
		}
		if (index < 0 || index >= _axis2DCount)
		{
			return default;
		}
		return axes2D[index].valueRawPrev;
	}

	public override double GetLastTimeActive()
	{
		if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
		{
			ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
			return 0.0;
		}
		return GetLastTimeActive(useRawValues: false);
	}

	public override double GetLastTimeActive(bool useRawValues)
	{
		if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
		{
			ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
			return 0.0;
		}
		return MathTools.Max(base.GetLastTimeActive(useRawValues), GetLastTimeAnyAxisActive(useRawValues));
	}

	public override double GetLastTimeAnyElementChanged()
	{
		return GetLastTimeAnyElementChanged(useRawValues: false);
	}

	public override double GetLastTimeAnyElementChanged(bool useRawValues)
	{
		if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
		{
			ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
			return 0.0;
		}
		return MathTools.Max(base.GetLastTimeAnyElementChanged(useRawValues), GetLastTimeAnyAxisChanged(useRawValues));
	}

	public double GetLastTimeAnyAxisActive()
	{
		return GetLastTimeAnyAxisActive(useRawValues: false);
	}

	public double GetLastTimeAnyAxisActive(bool useRawValues)
	{
		if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
		{
			ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
			return 0.0;
		}
		if (axes == null)
		{
			return 0.0;
		}
		double num = 0.0;
		for (int i = 0; i < axes.Length; i++)
		{
			double num2 = (useRawValues ? axes[i].lastTimeActiveRaw : axes[i].lastTimeActive);
			if (num2 > num)
			{
				num = num2;
			}
		}
		return num;
	}

	public double GetLastTimeAnyAxisChanged()
	{
		return GetLastTimeAnyAxisChanged(useRawValues: false);
	}

	public double GetLastTimeAnyAxisChanged(bool useRawValues)
	{
		if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
		{
			ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
			return 0.0;
		}
		if (axes == null)
		{
			return 0.0;
		}
		double num = 0.0;
		for (int i = 0; i < axes.Length; i++)
		{
			double num2 = (useRawValues ? axes[i].lastTimeValueChangedRaw : axes[i].lastTimeValueChanged);
			if (num2 > num)
			{
				num = num2;
			}
		}
		return num;
	}

	public override ControllerPollingInfo PollForFirstElement()
	{
		if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
		{
			ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
			return ControllerPollingInfo.wybtSxBKyoFevDSBzxAFgDtcKhkHA();
		}
		ControllerPollingInfo result = base.PollForFirstElement();
		if (result.success)
		{
			return result;
		}
		return PollForFirstAxis();
	}

	public override ControllerPollingInfo PollForFirstElementDown()
	{
		if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
		{
			ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
			return ControllerPollingInfo.wybtSxBKyoFevDSBzxAFgDtcKhkHA();
		}
		ControllerPollingInfo result = base.PollForFirstElementDown();
		if (result.success)
		{
			return result;
		}
		return PollForFirstAxis();
	}

	public ControllerPollingInfo PollForFirstAxis()
	{
		if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
		{
			ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
			return ControllerPollingInfo.wybtSxBKyoFevDSBzxAFgDtcKhkHA();
		}
		UpdatePollingFrameTracking();
		nXsSyCSCRjABGjgYTQBmncdrdjznA();
		for (int i = 0; i < _axisCount; i++)
		{
			if (IsPolledAxisActive(i, out var pole, out var elementIdentifierId))
			{
				return new ControllerPollingInfo(true, -1, id, _name, _type, ControllerElementType.Axis, i, pole, aHJMAWzbypGgwCcRCqDEaoqVGwfA.GetElementIdentifierName(elementIdentifierId), elementIdentifierId, KeyCode.None);
			}
		}
		return ControllerPollingInfo.wybtSxBKyoFevDSBzxAFgDtcKhkHA();
	}

	[IteratorStateMachine(typeof(lMzGrDcOoBhvvaWOTcRyVlLCFxrYA))]
	public override IEnumerable<ControllerPollingInfo> PollForAllElements()
	{
		return new lMzGrDcOoBhvvaWOTcRyVlLCFxrYA(-2)
		{
			OGlamHLgbfSYXoQNmyxtLBxYueee = this
		};
	}

	[IteratorStateMachine(typeof(HSyfqQOoTgbWWdSnjwwPcErBOoBP))]
	public override IEnumerable<ControllerPollingInfo> PollForAllElementsDown()
	{
		return new HSyfqQOoTgbWWdSnjwwPcErBOoBP(-2)
		{
			HnhBjRdDbeWCRWWQJDMJAinAvelZA = this
		};
	}

	[IteratorStateMachine(typeof(lrhUTEFCFYiDFdasGCFbaBVAENVQA))]
	public IEnumerable<ControllerPollingInfo> PollForAllAxes()
	{
		return new lrhUTEFCFYiDFdasGCFbaBVAENVQA(-2)
		{
			ZgUlhXVFxHDuRFSpkYwlstprSRNoA = this
		};
	}

	private void nXsSyCSCRjABGjgYTQBmncdrdjznA()
	{
		if (ufBAQDUYetDudZhEubfpCzjeCZqS == null)
		{
			ufBAQDUYetDudZhEubfpCzjeCZqS = new float[_axisCount];
		}
		if (wpuYxYLINvhobUhrjHsgbKAfRtCM != tzdqVJjcIeDMjNymLDIqhjohzdxJ)
		{
			tzdqVJjcIeDMjNymLDIqhjohzdxJ = wpuYxYLINvhobUhrjHsgbKAfRtCM;
			UpdateLoopType currentUpdateLoop = ReInput.currentUpdateLoop;
			for (int i = 0; i < _axisCount; i++)
			{
				ufBAQDUYetDudZhEubfpCzjeCZqS[i] = axes[i].shQMclfXTNCRJwihCqGenlxomRNQ(currentUpdateLoop, _calibrationMap.GetAxis(i));
			}
		}
	}

	protected virtual bool IsPolledAxisActive(int index, out Pole pole, out int elementIdentifierId)
	{
		pole = Pole.Positive;
		elementIdentifierId = -1;
		if (axes[index].XPJMXvcDLsDoYlwHEhEAofLIBGih != null)
		{
			if (axes[index].XPJMXvcDLsDoYlwHEhEAofLIBGih._excludeFromPolling)
			{
				return false;
			}
			if (axes[index].XPJMXvcDLsDoYlwHEhEAofLIBGih._dataFormat == AxisCoordinateMode.Relative)
			{
				return false;
			}
		}
		float value = axes[index].shQMclfXTNCRJwihCqGenlxomRNQ(ReInput.currentUpdateLoop, _calibrationMap.GetAxis(index)) - ufBAQDUYetDudZhEubfpCzjeCZqS[index];
		if (MathTools.Abs(value) <= axes[index].AvbeukGhMeWVdlYXEDPZddcdeFSsA())
		{
			return false;
		}
		pole = ((!(MathTools.Sign(value) >= 0f)) ? Pole.Negative : Pole.Positive);
		elementIdentifierId = aHJMAWzbypGgwCcRCqDEaoqVGwfA.axisElementIdentifierIds[index];
		if (elementIdentifierId < 0)
		{
			return false;
		}
		return true;
	}

	public bool ImportCalibrationMapFromXmlString(string xmlString)
	{
		if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
		{
			ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
			return false;
		}
		return calibrationMap.ImportXmlString(xmlString);
	}

	public bool ImportCalibrationMapFromJsonString(string jsonString)
	{
		if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
		{
			ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
			return false;
		}
		return calibrationMap.ImportJsonString(jsonString);
	}

	internal virtual void biQoETeEqDdqkhVmbcHhOaDmWZxfA(UpdateLoopType P_0)
	{
		base.zGxdVtiyTLpxaqKGIAgsfZozxwRZA(P_0);
		bool flag = ReInput.IsInputAllowed(_type);
		bool flag2 = _type == ControllerType.Joystick || _type == ControllerType.Custom;
		bool flag3 = _type == ControllerType.Joystick && ReInput.checkNeverPressed;
		bool flag4 = _type == ControllerType.Joystick && !KRqNAliDQUoGilZWSpebheoTCzwBA.hasReceivedInput;
		for (int i = 0; i < _axisCount; i++)
		{
			axes[i].PAFGMCwxOiWxdZXutQtUkfGsgbPD(P_0);
			if ((!flag | flag4) || (flag3 && !KRqNAliDQUoGilZWSpebheoTCzwBA.axisHasBeenPressedOSXLinux[i]))
			{
				axes[i].EnPEzrYrNopiLFctMJtttPFiCXcb(_calibrationMap.GetAxis(i).calibratedZero);
				axes[i].qhzRXfLSfSKZQOvifXOhlrmKRQSe();
				continue;
			}
			axes[i].EnPEzrYrNopiLFctMJtttPFiCXcb(KRqNAliDQUoGilZWSpebheoTCzwBA.axisValues[i]);
			if (flag2)
			{
				axes[i].fNDBxYpcOHnvawNzUyDDspUqayQDA(_calibrationMap.GetAxis(i));
			}
			else
			{
				axes[i].otjGcOpkhmEIaXAdlXcYCpDOfRrs();
			}
		}
		for (int j = 0; j < _axis2DCount; j++)
		{
			axes2D[j].RUtFfULuhsgUyClAtfAwvvnERgpL();
		}
		for (int k = 0; k < _axisCount; k++)
		{
			axes[k].RtHLInCemZPWvWSrXSqpvkwWEFFC();
		}
	}

	internal bool HewsLcYVWspnnafbvCZAwXWnAcXZ(ActionElementMap P_0, int P_1, bool P_2, bool P_3, out float P_4)
	{
		P_4 = 0f;
		ControllerElementType elementType = P_0._elementType;
		if (P_1 != P_0._actionId)
		{
			return false;
		}
		int qFmDebRUzKGSVIJAwVaJJAOkGJANA = P_0.QFmDebRUzKGSVIJAwVaJJAOkGJANA;
		if (qFmDebRUzKGSVIJAwVaJJAOkGJANA < 0 || qFmDebRUzKGSVIJAwVaJJAOkGJANA >= _axisCount)
		{
			return false;
		}
		float num = ((!P_3) ? (P_2 ? axes[qFmDebRUzKGSVIJAwVaJJAOkGJANA].valueRaw : axes[qFmDebRUzKGSVIJAwVaJJAOkGJANA].value) : (P_2 ? axes[qFmDebRUzKGSVIJAwVaJJAOkGJANA].valueRawPrev : axes[qFmDebRUzKGSVIJAwVaJJAOkGJANA].valuePrev));
		if (MathTools.Approximately(num, 0f))
		{
			return true;
		}
		switch (elementType)
		{
		case ControllerElementType.Axis:
		{
			if (P_0._axisRange == AxisRange.Full)
			{
				if (P_0._invert)
				{
					num *= -1f;
				}
				break;
			}
			bool flag = MathTools.Sign(num) > 0f;
			if (flag && P_0._axisRange == AxisRange.Positive)
			{
				num = ((num >= 0f) ? num : 0f);
				if (P_0._axisContribution == Pole.Negative)
				{
					num *= -1f;
				}
			}
			else if (!flag && P_0._axisRange == AxisRange.Negative)
			{
				num = ((num <= 0f) ? num : 0f);
				if (P_0._axisContribution == Pole.Positive)
				{
					num *= -1f;
				}
			}
			else
			{
				num = 0f;
			}
			break;
		}
		case ControllerElementType.Button:
			if (P_0._axisContribution == Pole.Negative)
			{
				num *= -1f;
			}
			break;
		}
		P_4 = num;
		return true;
	}

	internal virtual void KIbELqqrmqDVXiRGqYavKDasSxXxA(ControllerMap P_0)
	{
		if (P_0 == null)
		{
			return;
		}
		if (!(P_0 is ControllerMapWithAxes controllerMapWithAxes))
		{
			Logger.LogWarning("Map type must inherit from ControllerMapWithAxes!");
			return;
		}
		base.dLKEnXOkLZMBMnjljyrBEBHwOgie(P_0);
		IList<ActionElementMap> axisMaps = controllerMapWithAxes.AxisMaps;
		for (int i = 0; i < axisMaps.Count; i++)
		{
			fGQOtKpVEJmrMXNYeONgsnXNwkIC(P_0, axisMaps[i]);
		}
		for (int num = axisMaps.Count - 1; num >= 0; num--)
		{
			if (axisMaps[num].elementIndex < 0)
			{
				P_0.DeleteElementMap(axisMaps[num].LQceMJAxYgRpolrwLwsLBxilJMmNA);
			}
		}
	}

	internal virtual void eDVtWZUYGQLlxspPAHmFBjTzzWrHA(ControllerMap P_0, ActionElementMap P_1)
	{
		if (P_1 != null)
		{
			base.fGQOtKpVEJmrMXNYeONgsnXNwkIC(P_0, P_1);
			if (P_1._elementType == ControllerElementType.Axis)
			{
				P_1.mmPDimdZnoHuGihimrrBmSVsLhfcb(P_0);
			}
		}
	}

	internal void CeXdgYVkmVgqUePqRxHGliplnGz()
	{
		for (int i = 0; i < axisCount; i++)
		{
			switch (axes[i].XPJMXvcDLsDoYlwHEhEAofLIBGih._specialAxisType)
			{
			case SpecialAxisType.None:
				_calibrationMap.Axes[i].calibrationMode = AlternateAxisCalibrationType.Default;
				break;
			case SpecialAxisType.Throttle:
				_calibrationMap.Axes[i].calibrationMode = EnumConverter.ToAlternateAxisCalibrationType(ReInput.configVars.throttleCalibrationMode);
				break;
			default:
				throw new NotImplementedException();
			}
		}
	}

	internal virtual void HZEaHvyGlMIsZbNXPCzRBwmikPyR()
	{
		base.PodVUGvDnUHydzVhCxMAInDDVsXW();
		for (int i = 0; i < _axisCount; i++)
		{
			if (axes[i] != null)
			{
				axes[i].Reset();
			}
		}
	}

	[CompilerGenerated]
	private int czHrkZPdkjgbWJOiinPouddcaoufA(int P_0)
	{
		if (base.extension is IAxisCalibrationIndexMap axisCalibrationIndexMap)
		{
			return axisCalibrationIndexMap.GetMappedAxisIndex(P_0);
		}
		return P_0;
	}

	[CompilerGenerated]
	[DebuggerHidden]
	private IEnumerable<ControllerPollingInfo> bImpRpmHacSxQMfNRJJhjqQbmSmE()
	{
		return base.PollForAllElements();
	}

	[CompilerGenerated]
	[DebuggerHidden]
	private IEnumerable<ControllerPollingInfo> EiMYSFQlyzhUDcmwgqheOMOJPcDg()
	{
		return base.PollForAllElementsDown();
	}
}
