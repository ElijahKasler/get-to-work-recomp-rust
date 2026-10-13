using System;
using Rewired;

internal static class lvBLlyyqGuOQBPOhtgAdicoRkrYcb
{
	public enum tXlmDqjqVcNvqdloWUetwbRoGEux
	{
		None = 0,
		CombinedTriggers = 1,
		SplitTriggers = 2
	}

	private struct BPZOyXtHFfWuMvKrQDSvijZiPmKLA(PidVid P_0, XUjlvHZDpakxOFkyIDmXRjHmiElFA P_1, BPZOyXtHFfWuMvKrQDSvijZiPmKLA.XhqUHhhyJnThJYvDplGkrCIUjNnO P_2)
	{
		public enum XhqUHhhyJnThJYvDplGkrCIUjNnO
		{
			MatchAnyOption = 0,
			MatchAllOptions = 1,
			IgnoreOptions = 2
		}

		public PidVid CxTOuXoEkXbpGZZlsIMCNnWTzMnx = P_0;

		public XUjlvHZDpakxOFkyIDmXRjHmiElFA KWgrdNwqAUhTFpMLMLboxfNZBmXQ = P_1;

		public XhqUHhhyJnThJYvDplGkrCIUjNnO cwCaLbobgXMIrJrqBZwQzHoVSvib = P_2;

		public bool yKByVMnUQipEFPIXRsdZGTVIMNly(ushort P_0, ushort P_1, XUjlvHZDpakxOFkyIDmXRjHmiElFA P_2)
		{
			if (CxTOuXoEkXbpGZZlsIMCNnWTzMnx.vendorId != P_0)
			{
				return false;
			}
			if (CxTOuXoEkXbpGZZlsIMCNnWTzMnx.productId != P_1)
			{
				return false;
			}
			return cwCaLbobgXMIrJrqBZwQzHoVSvib switch
			{
				XhqUHhhyJnThJYvDplGkrCIUjNnO.MatchAnyOption => (KWgrdNwqAUhTFpMLMLboxfNZBmXQ & P_2) != 0, 
				XhqUHhhyJnThJYvDplGkrCIUjNnO.MatchAllOptions => KWgrdNwqAUhTFpMLMLboxfNZBmXQ == P_2, 
				XhqUHhhyJnThJYvDplGkrCIUjNnO.IgnoreOptions => true, 
				_ => throw new NotImplementedException(), 
			};
		}
	}

	public enum XUjlvHZDpakxOFkyIDmXRjHmiElFA
	{
		None = 0,
		Bluetooth = 1,
		USB = 2
	}

	private static Guid[] pGXZiCnsqzOonrxBuCjAyjNuScMj = new Guid[6]
	{
		new Guid("02D1045E-0000-0000-0000-504944564944"),
		new Guid("02DD045E-0000-0000-0000-504944564944"),
		new Guid("02E3045E-0000-0000-0000-504944564944"),
		new Guid("DEEF045E-0000-0000-0000-504944564944"),
		new Guid("02e0045e-0000-0000-0000-504944564944"),
		new Guid("02ff045e-0000-0000-0000-504944564944")
	};

	private static string[] AKLAxcbfSodmhHDAdGzGDiozylcOB = new string[4] { "Controller (XBOX One For Windows)", "XBOX One For Windows (Controller)", "XBOX One Controller", "Xbox Bluetooth Gamepad" };

	private const string ouHrrstbqcZvTxSqNdWgzSuGQTGX = ".*xbox[ \\-]one.*";

	private static readonly BPZOyXtHFfWuMvKrQDSvijZiPmKLA[] TIqFlVjrQkGDbilxpWnYBwlOMNfgb = new BPZOyXtHFfWuMvKrQDSvijZiPmKLA[1]
	{
		new BPZOyXtHFfWuMvKrQDSvijZiPmKLA(new PidVid(8201, 1406), XUjlvHZDpakxOFkyIDmXRjHmiElFA.USB, BPZOyXtHFfWuMvKrQDSvijZiPmKLA.XhqUHhhyJnThJYvDplGkrCIUjNnO.MatchAnyOption)
	};

	public static string GyvGoeHCHQQdWtsEOOqaqyZmBTTMA(UjfFJagRWmzCLelDMFkwHkECaNKIB P_0, Guid P_1, string P_2, string P_3)
	{
		if (P_0 == null)
		{
			return string.Empty;
		}
		return BkDwLVeIglozpjBgDJZamQPSiuIx(P_0.hSKdZzAvUoaufhblnRJOmkKfSfNu(), P_1, P_2, P_3) switch
		{
			tXlmDqjqVcNvqdloWUetwbRoGEux.CombinedTriggers => "[CombinedTriggers]", 
			tXlmDqjqVcNvqdloWUetwbRoGEux.SplitTriggers => "[SplitTriggers]", 
			_ => string.Empty, 
		};
	}

	public static tXlmDqjqVcNvqdloWUetwbRoGEux BkDwLVeIglozpjBgDJZamQPSiuIx(PdfAqamcmCtcqUOoEkGdViEMjvPj[] P_0, Guid P_1, string P_2, string P_3)
	{
		if (!ecxdEVbHxLiHXoxVjCPGXfHgyJGP(P_1, P_2, P_3))
		{
			return tXlmDqjqVcNvqdloWUetwbRoGEux.None;
		}
		for (int i = 0; i < P_0.Length; i++)
		{
			if (P_0[i].iGzSvNefYlJxXndLecuwWCmwveEk() == 1 && !P_0[i].xmDrToNaImAPhGgGLZSVIwYnxsfEA() && P_0[i].TaKehabkchTKYmswLOZXzzBZwMVOA().yUQEpaObPoQVwVOEyFQQsUwBkgzE() == 53)
			{
				return tXlmDqjqVcNvqdloWUetwbRoGEux.SplitTriggers;
			}
		}
		return tXlmDqjqVcNvqdloWUetwbRoGEux.CombinedTriggers;
	}

	public static bool ecxdEVbHxLiHXoxVjCPGXfHgyJGP(Guid P_0, string P_1, string P_2)
	{
		if (Array.IndexOf(pGXZiCnsqzOonrxBuCjAyjNuScMj, P_0) >= 0)
		{
			return true;
		}
		if (UVDVYGmjnbDTeLPIZSXgVyPMfDif(P_1))
		{
			return true;
		}
		if (UVDVYGmjnbDTeLPIZSXgVyPMfDif(P_2))
		{
			return true;
		}
		return false;
	}

	private static bool UVDVYGmjnbDTeLPIZSXgVyPMfDif(string P_0)
	{
		if (string.IsNullOrEmpty(P_0))
		{
			return false;
		}
		for (int i = 0; i < AKLAxcbfSodmhHDAdGzGDiozylcOB.Length; i++)
		{
			if (AKLAxcbfSodmhHDAdGzGDiozylcOB[i].Equals(P_0, StringComparison.OrdinalIgnoreCase))
			{
				return true;
			}
		}
		return false;
	}

	public static bool BDrkzqgzmHeQgxGnATWRFiAJQAUb(InputSource P_0, ushort P_1, ushort P_2, XUjlvHZDpakxOFkyIDmXRjHmiElFA P_3)
	{
		if (P_0 == InputSource.DirectInput || P_0 == InputSource.RawInput)
		{
			for (int i = 0; i < TIqFlVjrQkGDbilxpWnYBwlOMNfgb.Length; i++)
			{
				if (TIqFlVjrQkGDbilxpWnYBwlOMNfgb[i].yKByVMnUQipEFPIXRsdZGTVIMNly(P_1, P_2, P_3))
				{
					return true;
				}
			}
		}
		return false;
	}
}
