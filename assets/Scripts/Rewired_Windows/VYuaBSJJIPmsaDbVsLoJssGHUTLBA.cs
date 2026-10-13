internal static class VYuaBSJJIPmsaDbVsLoJssGHUTLBA
{
	private class FTJLtObHHpDBJxmGGBlThgFPOqKfb
	{
		public readonly ushort cgxgJLVENjqLExPWqKgdZHBoait;

		public readonly ushort qvkMFfGsjJWEErnBNYkGcNQVSTJN;

		public readonly string eeWrdJfCmRrEtGHVxGtTuNFKyzst;

		public readonly bool QNMOOZVcUNQfxyCQGEjhamxWoHgxA;

		public readonly int dEyaMTNyMwEWKkFVknRNrCscpRBX;

		public readonly int QvEnskkAmlcxuHXpbqpLfmMZKdsd;

		public readonly int izZNHxviAUhYsXMacHjMxBjyEbUp;

		public readonly float ricrqUQctZJBfDcqHaLejnyHggHEb;

		public FTJLtObHHpDBJxmGGBlThgFPOqKfb(ushort P_0, ushort P_1, string P_2, bool P_3, int P_4, int P_5, int P_6, float P_7)
		{
			cgxgJLVENjqLExPWqKgdZHBoait = P_0;
			qvkMFfGsjJWEErnBNYkGcNQVSTJN = P_1;
			if (string.IsNullOrEmpty(P_2))
			{
				P_2 = string.Empty;
			}
			eeWrdJfCmRrEtGHVxGtTuNFKyzst = P_2;
			QNMOOZVcUNQfxyCQGEjhamxWoHgxA = P_3;
			dEyaMTNyMwEWKkFVknRNrCscpRBX = P_4;
			QvEnskkAmlcxuHXpbqpLfmMZKdsd = P_5;
			izZNHxviAUhYsXMacHjMxBjyEbUp = P_6;
			ricrqUQctZJBfDcqHaLejnyHggHEb = P_7;
		}

		public bool kiIxbkQlsceLRvAjnaFSjRjicZwcb(ushort P_0, ushort P_1)
		{
			if (cgxgJLVENjqLExPWqKgdZHBoait == P_0)
			{
				return qvkMFfGsjJWEErnBNYkGcNQVSTJN == P_1;
			}
			return false;
		}

		public bool xDVXYOmLRRKFFZvNPrBMfedzGPHfA(ushort P_0, ushort P_1, string P_2)
		{
			if (cgxgJLVENjqLExPWqKgdZHBoait != P_0 || qvkMFfGsjJWEErnBNYkGcNQVSTJN != P_1)
			{
				if (!string.IsNullOrEmpty(P_2))
				{
					return eeWrdJfCmRrEtGHVxGtTuNFKyzst == P_2;
				}
				return false;
			}
			return true;
		}

		public bool jtYeIliBdRPxsvTDhHiNoYWQzHst(string P_0)
		{
			if (!string.IsNullOrEmpty(P_0))
			{
				return eeWrdJfCmRrEtGHVxGtTuNFKyzst == P_0;
			}
			return false;
		}
	}

	private const float GciUEIWFLBnyuECnvpHEyuhKwWAJ = 0.034f;

	private static FTJLtObHHpDBJxmGGBlThgFPOqKfb[] WBtJmDIJuPzqAwvRitmsstRRoUky = new FTJLtObHHpDBJxmGGBlThgFPOqKfb[3]
	{
		new FTJLtObHHpDBJxmGGBlThgFPOqKfb(1133, 50726, "SpaceNavigator", true, -350, 350, 0, 0.034f),
		new FTJLtObHHpDBJxmGGBlThgFPOqKfb(1133, 50728, "SpaceNavigator for Notebooks", true, -350, 350, 0, 0.034f),
		new FTJLtObHHpDBJxmGGBlThgFPOqKfb(1133, 50727, "Space Explorer", true, -350, 350, 0, 0.034f)
	};

	public static bool XiYCPJJROGfqSxMqxbyiaZMJrAaOA(ushort P_0, ushort P_1, string P_2 = null)
	{
		return UIQivPTJpJApsXmmFHFlxaHPvVbg(P_0, P_1, P_2)?.QNMOOZVcUNQfxyCQGEjhamxWoHgxA ?? false;
	}

	public static float wlRwcwoERpRuqzmucaxjGcdfGmTHb(ushort P_0, ushort P_1, string P_2 = null)
	{
		return UIQivPTJpJApsXmmFHFlxaHPvVbg(P_0, P_1, P_2)?.ricrqUQctZJBfDcqHaLejnyHggHEb ?? 0f;
	}

	public static bool GOPoescHyYfSfwWfkDmxqAPBYCiG(ushort P_0, ushort P_1, out int P_2, out int P_3, out int P_4)
	{
		return PcIZbympUBEPumxuPrByDhFWIatP(P_0, P_1, null, out P_2, out P_3, out P_4);
	}

	public static bool PcIZbympUBEPumxuPrByDhFWIatP(ushort P_0, ushort P_1, string P_2, out int P_3, out int P_4, out int P_5)
	{
		for (int i = 0; i < WBtJmDIJuPzqAwvRitmsstRRoUky.Length; i++)
		{
			if (WBtJmDIJuPzqAwvRitmsstRRoUky[i].kiIxbkQlsceLRvAjnaFSjRjicZwcb(P_0, P_1) && WBtJmDIJuPzqAwvRitmsstRRoUky[i].QNMOOZVcUNQfxyCQGEjhamxWoHgxA)
			{
				P_3 = WBtJmDIJuPzqAwvRitmsstRRoUky[i].dEyaMTNyMwEWKkFVknRNrCscpRBX;
				P_4 = WBtJmDIJuPzqAwvRitmsstRRoUky[i].QvEnskkAmlcxuHXpbqpLfmMZKdsd;
				P_5 = WBtJmDIJuPzqAwvRitmsstRRoUky[i].izZNHxviAUhYsXMacHjMxBjyEbUp;
				return true;
			}
		}
		P_3 = 0;
		P_4 = 0;
		P_5 = 0;
		return false;
	}

	public static bool BoBbdPySqHbhBXLtuvpPzYWGUnhq(ushort P_0, ushort P_1, string P_2 = null)
	{
		return dhQgKIRLyCmryUQMZmBFxilGreQX(P_0, P_1, P_2);
	}

	private static bool dhQgKIRLyCmryUQMZmBFxilGreQX(ushort P_0, ushort P_1, string P_2 = null)
	{
		for (int i = 0; i < WBtJmDIJuPzqAwvRitmsstRRoUky.Length; i++)
		{
			if (WBtJmDIJuPzqAwvRitmsstRRoUky[i].xDVXYOmLRRKFFZvNPrBMfedzGPHfA(P_0, P_1, P_2))
			{
				return true;
			}
		}
		return false;
	}

	private static FTJLtObHHpDBJxmGGBlThgFPOqKfb UIQivPTJpJApsXmmFHFlxaHPvVbg(ushort P_0, ushort P_1, string P_2 = null)
	{
		for (int i = 0; i < WBtJmDIJuPzqAwvRitmsstRRoUky.Length; i++)
		{
			if (WBtJmDIJuPzqAwvRitmsstRRoUky[i].xDVXYOmLRRKFFZvNPrBMfedzGPHfA(P_0, P_1, P_2))
			{
				return WBtJmDIJuPzqAwvRitmsstRRoUky[i];
			}
		}
		return null;
	}
}
