using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Rewired.Internal;
using Rewired.Internal.Glyphs;
using Rewired.Utils.Classes.Data;

internal abstract class pPzlYxeYqAdRVXQDRtGmpEsNcFoM : IPrefetch
{
	protected struct riHyuAKFKhwSybHIJUsaRPvpPwjP(KeyedGlyph P_0, int P_1) : IEquatable<riHyuAKFKhwSybHIJUsaRPvpPwjP>
	{
		public KeyedGlyph PcqKEZGlfuQyvsLBgGoCdVWWFLjf = P_0;

		public int tiFBfsANrkovfttHKLFUGaIMiKWCb = P_1;

		public bool yGgTrtRAnskSbIIKLjcUFkNhcltgb(object P_0)
		{
			if (!(P_0 is riHyuAKFKhwSybHIJUsaRPvpPwjP riHyuAKFKhwSybHIJUsaRPvpPwjP2))
			{
				return false;
			}
			if (riHyuAKFKhwSybHIJUsaRPvpPwjP2.PcqKEZGlfuQyvsLBgGoCdVWWFLjf == PcqKEZGlfuQyvsLBgGoCdVWWFLjf)
			{
				return riHyuAKFKhwSybHIJUsaRPvpPwjP2.tiFBfsANrkovfttHKLFUGaIMiKWCb == tiFBfsANrkovfttHKLFUGaIMiKWCb;
			}
			return false;
		}

		public int beHjNxzQNLbrQkPdcIkFjxXtPLaV()
		{
			return (17 * 29 + PcqKEZGlfuQyvsLBgGoCdVWWFLjf.GetHashCode()) * 29 + tiFBfsANrkovfttHKLFUGaIMiKWCb.GetHashCode();
		}

		public bool Equals(riHyuAKFKhwSybHIJUsaRPvpPwjP other)
		{
			if (PcqKEZGlfuQyvsLBgGoCdVWWFLjf == other.PcqKEZGlfuQyvsLBgGoCdVWWFLjf)
			{
				return tiFBfsANrkovfttHKLFUGaIMiKWCb == other.tiFBfsANrkovfttHKLFUGaIMiKWCb;
			}
			return false;
		}

		bool IEquatable<riHyuAKFKhwSybHIJUsaRPvpPwjP>.Equals(riHyuAKFKhwSybHIJUsaRPvpPwjP other)
		{
			//ILSpy generated this explicit interface implementation from .override directive in Equals
			return this.Equals(other);
		}

		[SpecialName]
		public static bool JvZHKYfQqpVBcEBgDpiBuxcuPDUq(riHyuAKFKhwSybHIJUsaRPvpPwjP P_0, riHyuAKFKhwSybHIJUsaRPvpPwjP P_1)
		{
			return P_0.Equals(P_1);
		}

		[SpecialName]
		public static bool nlKbqybKDaHjyIcIjhJVQxgjTwhj(riHyuAKFKhwSybHIJUsaRPvpPwjP P_0, riHyuAKFKhwSybHIJUsaRPvpPwjP P_1)
		{
			return !P_0.Equals(P_1);
		}
	}

	private lhkLrWnhlfHasNgQzbqhGosPUipt bdjAHMbFEmgVQFfGYXqPHcEqptzf;

	protected readonly KeyedGlyph bJHiYcGAJFSKmkmlfNYLPNcCHTCr;

	private Id LKMAPOiQxYmBfAyiWLyNiMXciRjL;

	private readonly Dictionary<int, List<riHyuAKFKhwSybHIJUsaRPvpPwjP>> TEBXVcbePSYUIKwMkhTxtIGAcYLb;

	private bool jTJlrspbdTpxEImUzMbRglbaFxlC;

	protected bool DWcbJLsOxxWuhVubaHCRUHxXCUhL => kvZDquevjjwEHPDXxkAAeUFAPMElA();

	public abstract object baGawTqHEQjViWUSGohLTPFfiCEO { get; }

	public abstract string wQSCOEZpJEcANBwKXCeyvUdcRKuRA { get; }

	protected bool kvZDquevjjwEHPDXxkAAeUFAPMElA()
	{
		return jTJlrspbdTpxEImUzMbRglbaFxlC;
	}

	public abstract object kGpzldgkfThCvAoiWaIMVZlaEKuW();

	public abstract string QmGGcKRfXciKdFBRaKFZnfezonaU();

	protected pPzlYxeYqAdRVXQDRtGmpEsNcFoM()
	{
		bJHiYcGAJFSKmkmlfNYLPNcCHTCr = new KeyedGlyph();
		TEBXVcbePSYUIKwMkhTxtIGAcYLb = new Dictionary<int, List<riHyuAKFKhwSybHIJUsaRPvpPwjP>>();
	}

	protected pPzlYxeYqAdRVXQDRtGmpEsNcFoM(lhkLrWnhlfHasNgQzbqhGosPUipt P_0)
		: this()
	{
		if (P_0 == null)
		{
			throw new ArgumentNullException("dataSource");
		}
		bdjAHMbFEmgVQFfGYXqPHcEqptzf = P_0;
	}

	public void raDHrMnOGsjxLTuUNFtPcmcYBcbh()
	{
		opSLHOMyAGFQosguuRMqyuymsJKC();
		if (GlyphManager.isEnabled && GlyphManager.autoPrefetch)
		{
			JUusVFipWRPVkxDLgyCRLePVYlMh();
		}
	}

	protected virtual void opSLHOMyAGFQosguuRMqyuymsJKC()
	{
		fLbAcBoPKTKVHOqlOjmMfaZwkzDWA();
		OGafzzvVtLWvmBqOMptiZdtyoZCn();
		GlyphManager.Add(this, ref LKMAPOiQxYmBfAyiWLyNiMXciRjL);
		jTJlrspbdTpxEImUzMbRglbaFxlC = true;
	}

	public virtual void fLbAcBoPKTKVHOqlOjmMfaZwkzDWA()
	{
		ByMFmhnZVzibSbqRGuZDluTIXdld();
		GlyphManager.Remove(ref LKMAPOiQxYmBfAyiWLyNiMXciRjL);
		jTJlrspbdTpxEImUzMbRglbaFxlC = false;
	}

	public virtual void wnYrMIjQwJwMsnEHCpqvqGtkNrOH(lhkLrWnhlfHasNgQzbqhGosPUipt P_0)
	{
		if (P_0 == null)
		{
			throw new ArgumentNullException("value");
		}
		if (P_0 != bdjAHMbFEmgVQFfGYXqPHcEqptzf)
		{
			if (bdjAHMbFEmgVQFfGYXqPHcEqptzf != null)
			{
				ByMFmhnZVzibSbqRGuZDluTIXdld();
			}
			bdjAHMbFEmgVQFfGYXqPHcEqptzf = P_0;
			raDHrMnOGsjxLTuUNFtPcmcYBcbh();
		}
	}

	public virtual void BRNdoOTHHumnYVMeHbnHepfIpxIiA()
	{
		bJHiYcGAJFSKmkmlfNYLPNcCHTCr.Clear();
	}

	public virtual bool OJJaafSyRQOTEoaDzgviglWPBHCyA(pPzlYxeYqAdRVXQDRtGmpEsNcFoM P_0)
	{
		if (P_0 == null)
		{
			return false;
		}
		if (!object.Equals(GetType(), P_0.GetType()))
		{
			return false;
		}
		if (bdjAHMbFEmgVQFfGYXqPHcEqptzf == null != (P_0.bdjAHMbFEmgVQFfGYXqPHcEqptzf == null))
		{
			return false;
		}
		if (bdjAHMbFEmgVQFfGYXqPHcEqptzf != null && (!string.Equals(bdjAHMbFEmgVQFfGYXqPHcEqptzf.keyCategory, P_0.bdjAHMbFEmgVQFfGYXqPHcEqptzf.keyCategory, StringComparison.Ordinal) || !string.Equals(bdjAHMbFEmgVQFfGYXqPHcEqptzf.key, P_0.bdjAHMbFEmgVQFfGYXqPHcEqptzf.key, StringComparison.Ordinal)))
		{
			return false;
		}
		return true;
	}

	protected virtual void ByMFmhnZVzibSbqRGuZDluTIXdld()
	{
		bJHiYcGAJFSKmkmlfNYLPNcCHTCr.Clear();
		TEBXVcbePSYUIKwMkhTxtIGAcYLb.Clear();
	}

	protected lhkLrWnhlfHasNgQzbqhGosPUipt IfFhGdKUEySLqjNPHoTIhpoaCwIm()
	{
		return bdjAHMbFEmgVQFfGYXqPHcEqptzf;
	}

	protected virtual void JUusVFipWRPVkxDLgyCRLePVYlMh()
	{
		kGpzldgkfThCvAoiWaIMVZlaEKuW();
	}

	void IPrefetch.Prefetch()
	{
		JUusVFipWRPVkxDLgyCRLePVYlMh();
	}

	protected virtual void IwKyNwcBkhYnpyRewSIjLmQheYdBA(int P_0)
	{
	}

	protected virtual void OGafzzvVtLWvmBqOMptiZdtyoZCn()
	{
	}

	protected virtual void LRwyGwfjffDmuCOTEkuVgNqJwqijB(int P_0, riHyuAKFKhwSybHIJUsaRPvpPwjP P_1)
	{
		for (int i = 0; i < 32; i++)
		{
			int num = 1 << i;
			if ((P_0 & num) != 0)
			{
				if (!TEBXVcbePSYUIKwMkhTxtIGAcYLb.TryGetValue(num, out var value))
				{
					value = new List<riHyuAKFKhwSybHIJUsaRPvpPwjP>();
					TEBXVcbePSYUIKwMkhTxtIGAcYLb[num] = value;
				}
				if (!value.Contains(P_1))
				{
					value.Add(P_1);
				}
			}
		}
	}

	protected virtual void rcVUVPQqVvSxxCNAGryaxgVcKumC(int P_0, riHyuAKFKhwSybHIJUsaRPvpPwjP P_1)
	{
		for (int i = 0; i < 32; i++)
		{
			int num = 1 << i;
			if ((P_0 & num) == 0 || !TEBXVcbePSYUIKwMkhTxtIGAcYLb.TryGetValue(num, out var value))
			{
				continue;
			}
			for (int num2 = value.Count - 1; num2 >= 0; num2--)
			{
				if (riHyuAKFKhwSybHIJUsaRPvpPwjP.JvZHKYfQqpVBcEBgDpiBuxcuPDUq(value[num2], P_1))
				{
					value.RemoveAt(num2);
				}
			}
		}
	}

	protected virtual void yDYKbnhbIbRbnXDbipuWnFhJhszg(int P_0)
	{
		for (int i = 0; i < 32; i++)
		{
			int num = 1 << i;
			if ((P_0 & num) == 0 || !TEBXVcbePSYUIKwMkhTxtIGAcYLb.TryGetValue(num, out var value))
			{
				continue;
			}
			int count = value.Count;
			for (int j = 0; j < count; j++)
			{
				if (value[j].tiFBfsANrkovfttHKLFUGaIMiKWCb != 0)
				{
					IwKyNwcBkhYnpyRewSIjLmQheYdBA(value[j].tiFBfsANrkovfttHKLFUGaIMiKWCb);
				}
				if (value[j].PcqKEZGlfuQyvsLBgGoCdVWWFLjf != null)
				{
					value[j].PcqKEZGlfuQyvsLBgGoCdVWWFLjf.Clear();
				}
			}
		}
	}
}
