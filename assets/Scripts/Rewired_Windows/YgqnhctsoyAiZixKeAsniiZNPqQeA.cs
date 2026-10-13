using System;
using System.Runtime.InteropServices;

internal struct YgqnhctsoyAiZixKeAsniiZNPqQeA
{
	public IntPtr YzEHBmNoiKBdThInLQRVqiblMevEb;

	public int GpXRPAxFpeZmLyrpCLPdBLXifbfd;

	public int mkLceCnSfMCmtvrhnltBZXSmJecI;

	public KPLqKGrnXdaslTRsOdlOdboDEXAU ZkToHalecmNLxzFDOCFImmKVivSU;

	public bool lXmUSoiiNonKcMnyJuviqoLGMEcV => ZkenIYyafOVRoFlofduBjtUBqXbE();

	public bool ZkenIYyafOVRoFlofduBjtUBqXbE()
	{
		if (YzEHBmNoiKBdThInLQRVqiblMevEb != IntPtr.Zero && GpXRPAxFpeZmLyrpCLPdBLXifbfd > 0)
		{
			return mkLceCnSfMCmtvrhnltBZXSmJecI > 0;
		}
		return false;
	}

	public YgqnhctsoyAiZixKeAsniiZNPqQeA(IntPtr P_0, int P_1, int P_2)
	{
		YzEHBmNoiKBdThInLQRVqiblMevEb = P_0;
		GpXRPAxFpeZmLyrpCLPdBLXifbfd = P_1;
		mkLceCnSfMCmtvrhnltBZXSmJecI = P_2;
		ZkToHalecmNLxzFDOCFImmKVivSU = KPLqKGrnXdaslTRsOdlOdboDEXAU.None;
	}

	public void ogjaKaNlopMNcixHbEaAijxLRSsg()
	{
		YzEHBmNoiKBdThInLQRVqiblMevEb = IntPtr.Zero;
		GpXRPAxFpeZmLyrpCLPdBLXifbfd = 0;
		mkLceCnSfMCmtvrhnltBZXSmJecI = 0;
		ZkToHalecmNLxzFDOCFImmKVivSU = KPLqKGrnXdaslTRsOdlOdboDEXAU.None;
	}

	public string OPnXRwzcaieCtXBURuTFAxfJjutJ()
	{
		string text = "OutputReport:\n";
		text = text + "buffer = " + ((YzEHBmNoiKBdThInLQRVqiblMevEb == IntPtr.Zero) ? "NULL" : ("Is Valid (" + YzEHBmNoiKBdThInLQRVqiblMevEb + ")")) + "\n";
		text = text + "bufferLength = " + GpXRPAxFpeZmLyrpCLPdBLXifbfd + "\n";
		text = text + "reportLength = " + mkLceCnSfMCmtvrhnltBZXSmJecI + "\n";
		string text2 = text;
		int zkToHalecmNLxzFDOCFImmKVivSU = (int)ZkToHalecmNLxzFDOCFImmKVivSU;
		text = text2 + "options = " + zkToHalecmNLxzFDOCFImmKVivSU + "\n";
		if (YzEHBmNoiKBdThInLQRVqiblMevEb != IntPtr.Zero)
		{
			text += "Buffer data:\n";
			for (int i = 0; i < mkLceCnSfMCmtvrhnltBZXSmJecI; i++)
			{
				text += Marshal.ReadByte(YzEHBmNoiKBdThInLQRVqiblMevEb, i).ToString("X2");
				if (i < mkLceCnSfMCmtvrhnltBZXSmJecI - 1)
				{
					text += ", ";
				}
			}
		}
		return text;
	}
}
