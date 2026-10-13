using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;

internal class QmfyCLxqjTNBPaQNgULQEGRQYAss
{
	[CompilerGenerated]
	private DateTime dWzgmZdqIFIbEjBUnpQhCOPcBhToA;

	[CompilerGenerated]
	private WeakReference MdPQSvxgLPeAthoJuIgCBTlIMJVF;

	[CompilerGenerated]
	private string RJqAzMLLnfHYAEYMaLqpuDvdarym;

	public DateTime TKlODXNwEGbynvmzWgjIIGnBmPbF
	{
		get
		{
			return sctZfNZxHMvJIbDgNseWrJGrwVPV();
		}
		private set
		{
			CHseopqMWJzdJCfYXZvmzbADhwox(dateTime);
		}
	}

	public WeakReference EYgPzbdFixsTxbmrNuRvFVzkkItE
	{
		get
		{
			return MsTdxodzeRuuxjvdFtaZBUlAUsHS();
		}
		private set
		{
			GhVaKFvOvecEAdldfUolpYqKGOgKA(weakReference);
		}
	}

	public string EYaGSzTVnVAtdNnWnAVCcaYEoKLy
	{
		get
		{
			return XHrNHCRCBuALPtFHpJOlBPjFmdqE();
		}
		private set
		{
			YEIHRMSmHgGiDlvemJBPELNKcAFI(text);
		}
	}

	public bool XBSLUjXvKTVdFcQzzGqgqgCbHIREA => hXzCQzeQZobXCHDEBjeTawtFwCNfB();

	public QmfyCLxqjTNBPaQNgULQEGRQYAss(DateTime P_0, jxsGnAKqtDjbPAuybcEYsWEZUDsc P_1, string P_2)
	{
		CHseopqMWJzdJCfYXZvmzbADhwox(P_0);
		GhVaKFvOvecEAdldfUolpYqKGOgKA(new WeakReference(P_1, trackResurrection: true));
		YEIHRMSmHgGiDlvemJBPELNKcAFI(P_2);
	}

	public DateTime sctZfNZxHMvJIbDgNseWrJGrwVPV()
	{
		return dWzgmZdqIFIbEjBUnpQhCOPcBhToA;
	}

	private void CHseopqMWJzdJCfYXZvmzbADhwox(DateTime P_0)
	{
		dWzgmZdqIFIbEjBUnpQhCOPcBhToA = P_0;
	}

	public WeakReference MsTdxodzeRuuxjvdFtaZBUlAUsHS()
	{
		return MdPQSvxgLPeAthoJuIgCBTlIMJVF;
	}

	private void GhVaKFvOvecEAdldfUolpYqKGOgKA(WeakReference P_0)
	{
		MdPQSvxgLPeAthoJuIgCBTlIMJVF = P_0;
	}

	public string XHrNHCRCBuALPtFHpJOlBPjFmdqE()
	{
		return RJqAzMLLnfHYAEYMaLqpuDvdarym;
	}

	private void YEIHRMSmHgGiDlvemJBPELNKcAFI(string P_0)
	{
		RJqAzMLLnfHYAEYMaLqpuDvdarym = P_0;
	}

	public bool hXzCQzeQZobXCHDEBjeTawtFwCNfB()
	{
		return MsTdxodzeRuuxjvdFtaZBUlAUsHS().IsAlive;
	}

	public virtual string nWGQnTzfMqcLRTmhdgCCQAHICMjM()
	{
		if (!(MsTdxodzeRuuxjvdFtaZBUlAUsHS().Target is jxsGnAKqtDjbPAuybcEYsWEZUDsc jxsGnAKqtDjbPAuybcEYsWEZUDsc2))
		{
			return "";
		}
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendFormat(CultureInfo.InvariantCulture, "Active COM Object: [0x{0:X}] Class: [{1}] Time [{2}] Stack:\r\n{3}", jxsGnAKqtDjbPAuybcEYsWEZUDsc2.JlPEPpQhdeKwlZzQOhddIQKPYxtg().ToInt64(), jxsGnAKqtDjbPAuybcEYsWEZUDsc2.GetType().FullName, sctZfNZxHMvJIbDgNseWrJGrwVPV(), XHrNHCRCBuALPtFHpJOlBPjFmdqE()).AppendLine();
		return stringBuilder.ToString();
	}
}
