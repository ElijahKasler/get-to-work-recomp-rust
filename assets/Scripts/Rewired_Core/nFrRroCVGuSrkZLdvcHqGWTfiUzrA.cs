using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Rewired.Internal.Localization;
using Rewired.Utils.Classes.Data;

internal abstract class nFrRroCVGuSrkZLdvcHqGWTfiUzrA : OxefyMfZIgXEzbqjvpxteWerzayF
{
	protected struct ckpPdPuCBpAmWbgPsVApqJdaDLjIA(LocalizedString P_0, int P_1) : IEquatable<ckpPdPuCBpAmWbgPsVApqJdaDLjIA>
	{
		public LocalizedString gfbLBBKbLUfXqrNCPBWhleOvXeMd = P_0;

		public int FsgNBDBxpHwhUGiwQoHeGbHJsJHM = P_1;

		public bool hxtYOUHcElaSYnamffFkybayodNM(object P_0)
		{
			if (!(P_0 is ckpPdPuCBpAmWbgPsVApqJdaDLjIA ckpPdPuCBpAmWbgPsVApqJdaDLjIA2))
			{
				return false;
			}
			if (ckpPdPuCBpAmWbgPsVApqJdaDLjIA2.gfbLBBKbLUfXqrNCPBWhleOvXeMd == gfbLBBKbLUfXqrNCPBWhleOvXeMd)
			{
				return ckpPdPuCBpAmWbgPsVApqJdaDLjIA2.FsgNBDBxpHwhUGiwQoHeGbHJsJHM == FsgNBDBxpHwhUGiwQoHeGbHJsJHM;
			}
			return false;
		}

		public int yPIwBYbtDJpUiFYDDseFXFkxjZJj()
		{
			return (17 * 29 + gfbLBBKbLUfXqrNCPBWhleOvXeMd.GetHashCode()) * 29 + FsgNBDBxpHwhUGiwQoHeGbHJsJHM.GetHashCode();
		}

		public bool Equals(ckpPdPuCBpAmWbgPsVApqJdaDLjIA other)
		{
			if (gfbLBBKbLUfXqrNCPBWhleOvXeMd == other.gfbLBBKbLUfXqrNCPBWhleOvXeMd)
			{
				return FsgNBDBxpHwhUGiwQoHeGbHJsJHM == other.FsgNBDBxpHwhUGiwQoHeGbHJsJHM;
			}
			return false;
		}

		bool IEquatable<ckpPdPuCBpAmWbgPsVApqJdaDLjIA>.Equals(ckpPdPuCBpAmWbgPsVApqJdaDLjIA other)
		{
			//ILSpy generated this explicit interface implementation from .override directive in Equals
			return this.Equals(other);
		}

		[SpecialName]
		public static bool yGtzSLleeFcoECiYsLzLzXJXciFdb(ckpPdPuCBpAmWbgPsVApqJdaDLjIA P_0, ckpPdPuCBpAmWbgPsVApqJdaDLjIA P_1)
		{
			return P_0.Equals(P_1);
		}

		[SpecialName]
		public static bool QSuzsBfCNRXpshfFKZAVrKNJlVfn(ckpPdPuCBpAmWbgPsVApqJdaDLjIA P_0, ckpPdPuCBpAmWbgPsVApqJdaDLjIA P_1)
		{
			return !P_0.Equals(P_1);
		}
	}

	private JPyUCjMynlgXcSTGrAuSOGxEMeWJ cWMBQtFVQraOwZJTXhHcliSuVogEA;

	protected readonly LocalizedString SDRjcCCTbqMUpsXreYlBLaHNuvOJA;

	private Id PORCDbKgazrvVgBRweODcmndSWimB;

	private readonly Dictionary<int, List<ckpPdPuCBpAmWbgPsVApqJdaDLjIA>> PRxdAOaFWgLfNnNuVtGoErcGarMgb;

	private bool TAcAQqgvNZEJlkKTzPZbCanKgsTmb;

	protected bool dDqQEabmTdjXsPYSGhVZcxdfHjqU => DtVbJqbHWjnOEGgKGqmFXXRulOOcb();

	public abstract string gmtePaqEaASICZwyKsdbHSdDDaau { get; }

	protected bool DtVbJqbHWjnOEGgKGqmFXXRulOOcb()
	{
		return TAcAQqgvNZEJlkKTzPZbCanKgsTmb;
	}

	public abstract string aLsidTWLDaQPOPmyxGbWHeMTGfoEA();

	protected nFrRroCVGuSrkZLdvcHqGWTfiUzrA()
	{
		SDRjcCCTbqMUpsXreYlBLaHNuvOJA = new LocalizedString();
		PRxdAOaFWgLfNnNuVtGoErcGarMgb = new Dictionary<int, List<ckpPdPuCBpAmWbgPsVApqJdaDLjIA>>();
	}

	protected nFrRroCVGuSrkZLdvcHqGWTfiUzrA(JPyUCjMynlgXcSTGrAuSOGxEMeWJ P_0)
		: this()
	{
		if (P_0 == null)
		{
			throw new ArgumentNullException("dataSource");
		}
		cWMBQtFVQraOwZJTXhHcliSuVogEA = P_0;
	}

	public void ZhRpIhzlXGoihOlERHuHJxfchzUL()
	{
		fNFQxyNUpjyrcpyGIVbbpvgVgIzH();
		if (LocalizationManager.isEnabled && LocalizationManager.autoPrefetch)
		{
			QskKyojfezSMOqIBIqeAbPpkHLMi();
		}
	}

	protected virtual void fNFQxyNUpjyrcpyGIVbbpvgVgIzH()
	{
		dufLvQQGVSByxRKMURUAoMYpPWSQ();
		QavZbWXaaglIQCkrGqqoJiHtVkvW();
		LocalizationManager.Add(this, ref PORCDbKgazrvVgBRweODcmndSWimB);
		TAcAQqgvNZEJlkKTzPZbCanKgsTmb = true;
	}

	public virtual void dufLvQQGVSByxRKMURUAoMYpPWSQ()
	{
		AqvmZxHuMEUqkCCadtBOKSkKfcql();
		LocalizationManager.Remove(ref PORCDbKgazrvVgBRweODcmndSWimB);
		TAcAQqgvNZEJlkKTzPZbCanKgsTmb = false;
	}

	public virtual void rskmUKgGDYEeUeUSytOWbrTrtdUs(JPyUCjMynlgXcSTGrAuSOGxEMeWJ P_0)
	{
		if (P_0 == null)
		{
			throw new ArgumentNullException("value");
		}
		if (P_0 != cWMBQtFVQraOwZJTXhHcliSuVogEA)
		{
			if (cWMBQtFVQraOwZJTXhHcliSuVogEA != null)
			{
				AqvmZxHuMEUqkCCadtBOKSkKfcql();
			}
			cWMBQtFVQraOwZJTXhHcliSuVogEA = P_0;
			ZhRpIhzlXGoihOlERHuHJxfchzUL();
		}
	}

	public virtual void OAlKIOycxHDThhuOVdyvlOGUVPeP()
	{
		SDRjcCCTbqMUpsXreYlBLaHNuvOJA.Clear();
	}

	public virtual void LeEGnLJDYLmYFSwWWbXCbfDSXxTbA()
	{
		SDRjcCCTbqMUpsXreYlBLaHNuvOJA.Clear();
	}

	public virtual void qFSeqqVPfIqnwwFRvTgDucKqgogy()
	{
		SDRjcCCTbqMUpsXreYlBLaHNuvOJA.Clear();
	}

	public virtual bool tJzJhBQhAipfnbFhrDaLigPGhpaNA(nFrRroCVGuSrkZLdvcHqGWTfiUzrA P_0, bool P_1)
	{
		if (P_0 == null)
		{
			return false;
		}
		if (!object.Equals(GetType(), P_0.GetType()))
		{
			return false;
		}
		if (cWMBQtFVQraOwZJTXhHcliSuVogEA == null != (P_0.cWMBQtFVQraOwZJTXhHcliSuVogEA == null))
		{
			return false;
		}
		if (cWMBQtFVQraOwZJTXhHcliSuVogEA != null)
		{
			if (!string.Equals(cWMBQtFVQraOwZJTXhHcliSuVogEA.keyCategory, P_0.cWMBQtFVQraOwZJTXhHcliSuVogEA.keyCategory, StringComparison.Ordinal) || !string.Equals(cWMBQtFVQraOwZJTXhHcliSuVogEA.scriptingName, P_0.cWMBQtFVQraOwZJTXhHcliSuVogEA.scriptingName, StringComparison.Ordinal) || !string.Equals(cWMBQtFVQraOwZJTXhHcliSuVogEA.key, P_0.cWMBQtFVQraOwZJTXhHcliSuVogEA.key, StringComparison.Ordinal))
			{
				return false;
			}
			if (P_1 && !string.Equals(cWMBQtFVQraOwZJTXhHcliSuVogEA.nonLocalizedDescriptiveName, P_0.cWMBQtFVQraOwZJTXhHcliSuVogEA.nonLocalizedDescriptiveName, StringComparison.Ordinal))
			{
				return false;
			}
		}
		return true;
	}

	protected virtual void AqvmZxHuMEUqkCCadtBOKSkKfcql()
	{
		SDRjcCCTbqMUpsXreYlBLaHNuvOJA.Clear();
		PRxdAOaFWgLfNnNuVtGoErcGarMgb.Clear();
	}

	protected JPyUCjMynlgXcSTGrAuSOGxEMeWJ RVRulIqHlqWGfymjJzFUvPQwroHx()
	{
		return cWMBQtFVQraOwZJTXhHcliSuVogEA;
	}

	protected virtual void QskKyojfezSMOqIBIqeAbPpkHLMi()
	{
		aLsidTWLDaQPOPmyxGbWHeMTGfoEA();
	}

	void OxefyMfZIgXEzbqjvpxteWerzayF.Localize()
	{
		QskKyojfezSMOqIBIqeAbPpkHLMi();
	}

	protected virtual void RTFmFbQWybMCirLzfJuVCcHeiCwV(int P_0)
	{
	}

	protected virtual void QavZbWXaaglIQCkrGqqoJiHtVkvW()
	{
	}

	protected virtual void IILAngIFhrpLnEpiDoVhbZQvLEKZA(int P_0, ckpPdPuCBpAmWbgPsVApqJdaDLjIA P_1)
	{
		for (int i = 0; i < 32; i++)
		{
			int num = 1 << i;
			if ((P_0 & num) != 0)
			{
				if (!PRxdAOaFWgLfNnNuVtGoErcGarMgb.TryGetValue(num, out var value))
				{
					value = new List<ckpPdPuCBpAmWbgPsVApqJdaDLjIA>();
					PRxdAOaFWgLfNnNuVtGoErcGarMgb[num] = value;
				}
				if (!value.Contains(P_1))
				{
					value.Add(P_1);
				}
			}
		}
	}

	protected virtual void MePUsRkushCXIxoncQOkYnDtgzfj(int P_0, ckpPdPuCBpAmWbgPsVApqJdaDLjIA P_1)
	{
		for (int i = 0; i < 32; i++)
		{
			int num = 1 << i;
			if ((P_0 & num) == 0 || !PRxdAOaFWgLfNnNuVtGoErcGarMgb.TryGetValue(num, out var value))
			{
				continue;
			}
			for (int num2 = value.Count - 1; num2 >= 0; num2--)
			{
				if (ckpPdPuCBpAmWbgPsVApqJdaDLjIA.yGtzSLleeFcoECiYsLzLzXJXciFdb(value[num2], P_1))
				{
					value.RemoveAt(num2);
				}
			}
		}
	}

	protected virtual void qISGEaoCpVaXTIvAyolzFspKnsPW(int P_0)
	{
		for (int i = 0; i < 32; i++)
		{
			int num = 1 << i;
			if ((P_0 & num) == 0 || !PRxdAOaFWgLfNnNuVtGoErcGarMgb.TryGetValue(num, out var value))
			{
				continue;
			}
			int count = value.Count;
			for (int j = 0; j < count; j++)
			{
				if (value[j].FsgNBDBxpHwhUGiwQoHeGbHJsJHM != 0)
				{
					RTFmFbQWybMCirLzfJuVCcHeiCwV(value[j].FsgNBDBxpHwhUGiwQoHeGbHJsJHM);
				}
				if (value[j].gfbLBBKbLUfXqrNCPBWhleOvXeMd != null)
				{
					value[j].gfbLBBKbLUfXqrNCPBWhleOvXeMd.Clear();
				}
			}
		}
	}
}
