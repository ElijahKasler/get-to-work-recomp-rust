using System;
using Rewired.Data.Mapping;
using Rewired.Utils.Classes.Data;

internal abstract class pNZrRihcucynHABMizyaEoIxhqLo : nFrRroCVGuSrkZLdvcHqGWTfiUzrA
{
	public class zvKBRcwOkVTGpBtPXscrAfiCwsyk
	{
		public readonly AxisDirection? HfiWcoVzmkPcAiJEWSSgznFixMBp;

		public zvKBRcwOkVTGpBtPXscrAfiCwsyk(AxisDirection? P_0)
		{
			HfiWcoVzmkPcAiJEWSSgznFixMBp = P_0;
		}
	}

	public class FdKEUIFrKxYxMqJpBtUEHFYNJPLp
	{
		private readonly AList<zvKBRcwOkVTGpBtPXscrAfiCwsyk> oyJxvYkpIimbgpjgVjsngrkGGgUbA;

		public readonly int HidLIBKkpkYjIYotnfRhJuLRxRzqA;

		public FdKEUIFrKxYxMqJpBtUEHFYNJPLp(AList<zvKBRcwOkVTGpBtPXscrAfiCwsyk> P_0)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException();
			}
			for (int i = 0; i < P_0._count; i++)
			{
				if (P_0._items[i] == null)
				{
					throw new ArgumentNullException();
				}
			}
			oyJxvYkpIimbgpjgVjsngrkGGgUbA = P_0;
			HidLIBKkpkYjIYotnfRhJuLRxRzqA = oyJxvYkpIimbgpjgVjsngrkGGgUbA._count;
		}

		public zvKBRcwOkVTGpBtPXscrAfiCwsyk AerpqQiZmNXKCnbxHDLoxbjDIEoy(int P_0)
		{
			return oyJxvYkpIimbgpjgVjsngrkGGgUbA._items[P_0];
		}

		public int CrcMfQmyLXJgOkfFMigDGyrmvMNpA(AxisDirection P_0)
		{
			for (int i = 0; i < oyJxvYkpIimbgpjgVjsngrkGGgUbA._count; i++)
			{
				if (oyJxvYkpIimbgpjgVjsngrkGGgUbA.get_Item(i).HfiWcoVzmkPcAiJEWSSgznFixMBp.HasValue && oyJxvYkpIimbgpjgVjsngrkGGgUbA.get_Item(i).HfiWcoVzmkPcAiJEWSSgznFixMBp.Value == P_0)
				{
					return i;
				}
			}
			return -1;
		}
	}

	public enum SQNzOzJGeDczXPkDWIklXJHcPxDM
	{
		None = 0,
		Names = 1,
		Keys = 2,
		All = -1
	}

	public enum oXFnxSbyQSNMOthcvFNPZPoHDhkL
	{
		None = 0,
		DescriptiveName = 1,
		PositiveDescriptiveName = 2,
		NegativeDescriptiveName = 4,
		PositiveKey = 8,
		NegativeKey = 16,
		SpecialDescrptiveName0 = 16384,
		SpecialDescrptiveName1 = 32768,
		SpecialDescrptiveName2 = 65536,
		SpecialDescrptiveName3 = 131072,
		SpecialDescrptiveName4 = 262144,
		SpecialDescrptiveName5 = 524288,
		SpecialDescrptiveName6 = 1048576,
		SpecialDescrptiveName7 = 2097152,
		SpecialDescrptiveName8 = 4194304,
		SpecialKey0 = 8388608,
		SpecialKey1 = 16777216,
		SpecialKey2 = 33554432,
		SpecialKey3 = 67108864,
		SpecialKey4 = 134217728,
		SpecialKey5 = 268435456,
		SpecialKey6 = 536870912,
		SpecialKey7 = 1073741824,
		SpecialKey8 = int.MinValue,
		All = -1
	}

	public enum AhhliCUThpTCpJDayBicensRWslA
	{
		Axis = 0,
		Button = 1,
		CompoundElement = 100,
		Unknown = int.MaxValue
	}

	public enum lGAwloROqSjUpJpzAfJNHgHgvWNeA
	{
		None = 0,
		Axis2D = 1,
		Hat = 2,
		ThumbStick = 3,
		DPad = 4,
		Stick = 5,
		Stick6D = 6,
		Unknown = int.MaxValue
	}

	private static readonly ADictionary<int, FdKEUIFrKxYxMqJpBtUEHFYNJPLp> oLKBcDqkwSxDNidthMKsPLqUadmo = new ADictionary<int, FdKEUIFrKxYxMqJpBtUEHFYNJPLp>
	{
		{
			4,
			new FdKEUIFrKxYxMqJpBtUEHFYNJPLp(new AList<zvKBRcwOkVTGpBtPXscrAfiCwsyk>
			{
				new zvKBRcwOkVTGpBtPXscrAfiCwsyk(AxisDirection.Horizontal),
				new zvKBRcwOkVTGpBtPXscrAfiCwsyk(AxisDirection.Vertical)
			})
		},
		{
			1,
			new FdKEUIFrKxYxMqJpBtUEHFYNJPLp(new AList<zvKBRcwOkVTGpBtPXscrAfiCwsyk>
			{
				new zvKBRcwOkVTGpBtPXscrAfiCwsyk(AxisDirection.Horizontal),
				new zvKBRcwOkVTGpBtPXscrAfiCwsyk(AxisDirection.Vertical)
			})
		},
		{
			5,
			new FdKEUIFrKxYxMqJpBtUEHFYNJPLp(new AList<zvKBRcwOkVTGpBtPXscrAfiCwsyk>
			{
				new zvKBRcwOkVTGpBtPXscrAfiCwsyk(AxisDirection.Horizontal),
				new zvKBRcwOkVTGpBtPXscrAfiCwsyk(AxisDirection.Vertical)
			})
		},
		{
			3,
			new FdKEUIFrKxYxMqJpBtUEHFYNJPLp(new AList<zvKBRcwOkVTGpBtPXscrAfiCwsyk>
			{
				new zvKBRcwOkVTGpBtPXscrAfiCwsyk(AxisDirection.Horizontal),
				new zvKBRcwOkVTGpBtPXscrAfiCwsyk(AxisDirection.Vertical)
			})
		}
	};

	private AhhliCUThpTCpJDayBicensRWslA AyOjSTUgmAqGRajooWugaiVUFFnU;

	private lGAwloROqSjUpJpzAfJNHgHgvWNeA kBtcEVfZiOpwNijGYwyeSiwElbJV;

	public AhhliCUThpTCpJDayBicensRWslA BiKdYwPezhsKYMHqZDcSUnDoWjoM
	{
		get
		{
			return IMXeFVPIKDxKVoZNARIdIWTGhQtG();
		}
		set
		{
			oeDBNDBzqMsnytUOuXXeRaRsAAFCb(ahhliCUThpTCpJDayBicensRWslA);
		}
	}

	public lGAwloROqSjUpJpzAfJNHgHgvWNeA VwAOtmaXqRMMixxPAqdILqagFgIt
	{
		get
		{
			return RuIhydIEyhbtpHfnyMnVhcotINwJ();
		}
		set
		{
			htXeJkegbigUCViyOgypFbBUCoOXA(lGAwloROqSjUpJpzAfJNHgHgvWNeA2);
		}
	}

	public static bool XvJavjeOWIkNAjwsVfvWcHWDssNGB(lGAwloROqSjUpJpzAfJNHgHgvWNeA P_0, out FdKEUIFrKxYxMqJpBtUEHFYNJPLp P_1)
	{
		return oLKBcDqkwSxDNidthMKsPLqUadmo.TryGetValue((int)P_0, out P_1);
	}

	public static int xlWNdmDDMBncSPcgqTPBqAHvYCtI(AhhliCUThpTCpJDayBicensRWslA P_0, lGAwloROqSjUpJpzAfJNHgHgvWNeA P_1)
	{
		if (P_0 != AhhliCUThpTCpJDayBicensRWslA.CompoundElement)
		{
			return 0;
		}
		if (!oLKBcDqkwSxDNidthMKsPLqUadmo.TryGetValue((int)P_1, out var value))
		{
			return 0;
		}
		return value.HidLIBKkpkYjIYotnfRhJuLRxRzqA;
	}

	public AhhliCUThpTCpJDayBicensRWslA IMXeFVPIKDxKVoZNARIdIWTGhQtG()
	{
		return AyOjSTUgmAqGRajooWugaiVUFFnU;
	}

	public void oeDBNDBzqMsnytUOuXXeRaRsAAFCb(AhhliCUThpTCpJDayBicensRWslA P_0)
	{
		if (P_0 != AyOjSTUgmAqGRajooWugaiVUFFnU)
		{
			AyOjSTUgmAqGRajooWugaiVUFFnU = P_0;
			if (DtVbJqbHWjnOEGgKGqmFXXRulOOcb())
			{
				ZhRpIhzlXGoihOlERHuHJxfchzUL();
			}
		}
	}

	public lGAwloROqSjUpJpzAfJNHgHgvWNeA RuIhydIEyhbtpHfnyMnVhcotINwJ()
	{
		return kBtcEVfZiOpwNijGYwyeSiwElbJV;
	}

	public void htXeJkegbigUCViyOgypFbBUCoOXA(lGAwloROqSjUpJpzAfJNHgHgvWNeA P_0)
	{
		if (P_0 != kBtcEVfZiOpwNijGYwyeSiwElbJV)
		{
			kBtcEVfZiOpwNijGYwyeSiwElbJV = P_0;
			if (DtVbJqbHWjnOEGgKGqmFXXRulOOcb())
			{
				ZhRpIhzlXGoihOlERHuHJxfchzUL();
			}
		}
	}

	protected pNZrRihcucynHABMizyaEoIxhqLo(AhhliCUThpTCpJDayBicensRWslA P_0, lGAwloROqSjUpJpzAfJNHgHgvWNeA P_1)
	{
		AyOjSTUgmAqGRajooWugaiVUFFnU = P_0;
		kBtcEVfZiOpwNijGYwyeSiwElbJV = P_1;
	}

	protected pNZrRihcucynHABMizyaEoIxhqLo(JPyUCjMynlgXcSTGrAuSOGxEMeWJ P_0, AhhliCUThpTCpJDayBicensRWslA P_1, lGAwloROqSjUpJpzAfJNHgHgvWNeA P_2)
		: base(P_0)
	{
		if (P_0 == null)
		{
			throw new ArgumentNullException("dataSource");
		}
		AyOjSTUgmAqGRajooWugaiVUFFnU = P_1;
		kBtcEVfZiOpwNijGYwyeSiwElbJV = P_2;
	}

	protected virtual void czfgOPYppNdWSAxIuWOwbUAQxdGd()
	{
		base.fNFQxyNUpjyrcpyGIVbbpvgVgIzH();
		FpbJQhXALPIpRmwHsGPwjscPwKwH();
	}

	public virtual void atbfuLHpNIpqybduLIQGElMiTPnrA()
	{
		base.OAlKIOycxHDThhuOVdyvlOGUVPeP();
		FpbJQhXALPIpRmwHsGPwjscPwKwH(SQNzOzJGeDczXPkDWIklXJHcPxDM.Names);
	}

	public virtual void UVKeIVcwUXeqFvCEvVeSmDhLvcdaA()
	{
		base.LeEGnLJDYLmYFSwWWbXCbfDSXxTbA();
		FpbJQhXALPIpRmwHsGPwjscPwKwH(SQNzOzJGeDczXPkDWIklXJHcPxDM.Keys);
	}

	public virtual void cIsbiVCBzLnDYGyyAvVLoyGCqFafA()
	{
		base.qFSeqqVPfIqnwwFRvTgDucKqgogy();
		FpbJQhXALPIpRmwHsGPwjscPwKwH(SQNzOzJGeDczXPkDWIklXJHcPxDM.Names);
	}

	public virtual bool bqMlZRCAXGaFCaSVivfavjWWgUSy(nFrRroCVGuSrkZLdvcHqGWTfiUzrA P_0, bool P_1)
	{
		pNZrRihcucynHABMizyaEoIxhqLo pNZrRihcucynHABMizyaEoIxhqLo2 = P_0 as pNZrRihcucynHABMizyaEoIxhqLo;
		if (pNZrRihcucynHABMizyaEoIxhqLo2 != null)
		{
			return false;
		}
		if (!base.tJzJhBQhAipfnbFhrDaLigPGhpaNA(P_0, P_1))
		{
			return false;
		}
		return AyOjSTUgmAqGRajooWugaiVUFFnU == pNZrRihcucynHABMizyaEoIxhqLo2.IMXeFVPIKDxKVoZNARIdIWTGhQtG();
	}

	protected virtual void OizdPrRNkAwmhjHfqRZbvfkQOSXI()
	{
		base.AqvmZxHuMEUqkCCadtBOKSkKfcql();
		oggvaMCWABzPsPHDvtoKaJEwYuZj(oXFnxSbyQSNMOthcvFNPZPoHDhkL.All);
	}

	protected virtual void FpbJQhXALPIpRmwHsGPwjscPwKwH(SQNzOzJGeDczXPkDWIklXJHcPxDM P_0 = SQNzOzJGeDczXPkDWIklXJHcPxDM.None)
	{
		if (P_0 != SQNzOzJGeDczXPkDWIklXJHcPxDM.None)
		{
			bUmEzchMDprfZHNkEzZqRXRMfPyGB(P_0);
		}
		JPyUCjMynlgXcSTGrAuSOGxEMeWJ jPyUCjMynlgXcSTGrAuSOGxEMeWJ = RVRulIqHlqWGfymjJzFUvPQwroHx();
		if (jPyUCjMynlgXcSTGrAuSOGxEMeWJ != null && (jPyUCjMynlgXcSTGrAuSOGxEMeWJ.autoGeneratedValueFlags & 1) == 0 && string.IsNullOrEmpty(jPyUCjMynlgXcSTGrAuSOGxEMeWJ.nonLocalizedDescriptiveName) && !string.IsNullOrEmpty(jPyUCjMynlgXcSTGrAuSOGxEMeWJ.scriptingName))
		{
			jPyUCjMynlgXcSTGrAuSOGxEMeWJ.nonLocalizedDescriptiveName = jPyUCjMynlgXcSTGrAuSOGxEMeWJ.scriptingName;
			jPyUCjMynlgXcSTGrAuSOGxEMeWJ.autoGeneratedValueFlags |= 1;
			qISGEaoCpVaXTIvAyolzFspKnsPW(1);
		}
	}

	protected virtual void RVjCfBabGixvbpcWMJmnZPhkcuaI(int P_0)
	{
		base.RTFmFbQWybMCirLzfJuVCcHeiCwV(P_0);
		oggvaMCWABzPsPHDvtoKaJEwYuZj((oXFnxSbyQSNMOthcvFNPZPoHDhkL)P_0);
	}

	protected virtual void oggvaMCWABzPsPHDvtoKaJEwYuZj(oXFnxSbyQSNMOthcvFNPZPoHDhkL P_0)
	{
		JPyUCjMynlgXcSTGrAuSOGxEMeWJ jPyUCjMynlgXcSTGrAuSOGxEMeWJ = RVRulIqHlqWGfymjJzFUvPQwroHx();
		if (jPyUCjMynlgXcSTGrAuSOGxEMeWJ != null && ((uint)jPyUCjMynlgXcSTGrAuSOGxEMeWJ.autoGeneratedValueFlags & (uint)P_0) != 0 && (P_0 & oXFnxSbyQSNMOthcvFNPZPoHDhkL.DescriptiveName) != oXFnxSbyQSNMOthcvFNPZPoHDhkL.None && (jPyUCjMynlgXcSTGrAuSOGxEMeWJ.autoGeneratedValueFlags & 1) != 0)
		{
			if (RVRulIqHlqWGfymjJzFUvPQwroHx() != null)
			{
				RVRulIqHlqWGfymjJzFUvPQwroHx().nonLocalizedDescriptiveName = null;
			}
			qISGEaoCpVaXTIvAyolzFspKnsPW(1);
			jPyUCjMynlgXcSTGrAuSOGxEMeWJ.autoGeneratedValueFlags &= -2;
		}
	}

	private void bUmEzchMDprfZHNkEzZqRXRMfPyGB(SQNzOzJGeDczXPkDWIklXJHcPxDM P_0)
	{
		oXFnxSbyQSNMOthcvFNPZPoHDhkL oXFnxSbyQSNMOthcvFNPZPoHDhkL2 = oYRknPmitKabzbgJBDQYWZcGjxYq(P_0);
		if (oXFnxSbyQSNMOthcvFNPZPoHDhkL2 != oXFnxSbyQSNMOthcvFNPZPoHDhkL.None)
		{
			oggvaMCWABzPsPHDvtoKaJEwYuZj(oXFnxSbyQSNMOthcvFNPZPoHDhkL2);
		}
	}

	protected virtual oXFnxSbyQSNMOthcvFNPZPoHDhkL oYRknPmitKabzbgJBDQYWZcGjxYq(SQNzOzJGeDczXPkDWIklXJHcPxDM P_0)
	{
		oXFnxSbyQSNMOthcvFNPZPoHDhkL oXFnxSbyQSNMOthcvFNPZPoHDhkL2 = oXFnxSbyQSNMOthcvFNPZPoHDhkL.None;
		if ((P_0 & SQNzOzJGeDczXPkDWIklXJHcPxDM.Names) != SQNzOzJGeDczXPkDWIklXJHcPxDM.None)
		{
			oXFnxSbyQSNMOthcvFNPZPoHDhkL2 |= oXFnxSbyQSNMOthcvFNPZPoHDhkL.DescriptiveName;
		}
		return oXFnxSbyQSNMOthcvFNPZPoHDhkL2;
	}

	protected virtual void aVeFsWuwLJOukPnowFdfTfdSMrIX()
	{
		base.QavZbWXaaglIQCkrGqqoJiHtVkvW();
		IILAngIFhrpLnEpiDoVhbZQvLEKZA(1, new ckpPdPuCBpAmWbgPsVApqJdaDLjIA
		{
			gfbLBBKbLUfXqrNCPBWhleOvXeMd = SDRjcCCTbqMUpsXreYlBLaHNuvOJA
		});
	}
}
