using System;
using System.Text;
using Rewired.Data.Mapping;
using Rewired.Interfaces;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using Rewired.Utils.Interfaces;

namespace Rewired.Internal.Localization;

[CustomObfuscation(rename = false)]
[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
internal static class LocalizationManager
{
	private sealed class rfWAFtgCAfGmBkKfECUPpEpyEynr
	{
		[Serializable]
		private sealed class lKhAlkglpfrFpwyCFzOMJPFxtDgb
		{
			public static readonly lKhAlkglpfrFpwyCFzOMJPFxtDgb _003C_003E9 = new lKhAlkglpfrFpwyCFzOMJPFxtDgb();

			public static Action<OxefyMfZIgXEzbqjvpxteWerzayF> _003C_003E9__7_0;

			internal void NgEslxFADToxgqBpAWnUrygUUese(OxefyMfZIgXEzbqjvpxteWerzayF P_0)
			{
				P_0.Localize();
			}
		}

		private const float jMMpnItmhfMsRaSXNIRwogIkAHTKA = 60f;

		private readonly global::ryIhzsVlAEsLECaOCXNjQXaqFkgN<OxefyMfZIgXEzbqjvpxteWerzayF> yRnQOHPELnXJATbZtzJCYHDDPLtX;

		public bool LbKHlXZcltBEACaVIVeMXtmnXqut;

		public ILocalizedStringProvider nZGkvHrmxzZybzFNqdkJItQVvuxz;

		public uint XPCyUJXUbRceDqrAjRuhjeHsaGsO;

		private Action<OxefyMfZIgXEzbqjvpxteWerzayF> yyXRAglNdVuleZlVrDftYlNAaQdl = lKhAlkglpfrFpwyCFzOMJPFxtDgb._003C_003E9.NgEslxFADToxgqBpAWnUrygUUese;

		private Id ZEDCtLbQFHJUyCHOuSwZgfIGaXHZ;

		public rfWAFtgCAfGmBkKfECUPpEpyEynr()
		{
			yRnQOHPELnXJATbZtzJCYHDDPLtX = new global::ryIhzsVlAEsLECaOCXNjQXaqFkgN<OxefyMfZIgXEzbqjvpxteWerzayF>(60f);
			XPCyUJXUbRceDqrAjRuhjeHsaGsO = 0u;
			ZEDCtLbQFHJUyCHOuSwZgfIGaXHZ = 1u;
		}

		public void ERUKPpWzHavgcFgHihImAKbiiSjPA(ILocalizedStringProvider P_0)
		{
			nZGkvHrmxzZybzFNqdkJItQVvuxz = P_0;
			if (P_0 != null)
			{
				XPCyUJXUbRceDqrAjRuhjeHsaGsO = ZEDCtLbQFHJUyCHOuSwZgfIGaXHZ.id;
				ZEDCtLbQFHJUyCHOuSwZgfIGaXHZ.Increment();
			}
			else
			{
				XPCyUJXUbRceDqrAjRuhjeHsaGsO = 0u;
			}
			fxABgbFrQcJwUlFJJbtXgjqAxPxQB();
		}

		public void xmlAzRQaLRDdLYUcEexCdFoIMBWG(bool P_0)
		{
			if (P_0 != LbKHlXZcltBEACaVIVeMXtmnXqut)
			{
				LbKHlXZcltBEACaVIVeMXtmnXqut = P_0;
				if (P_0)
				{
					uNyIBWGGpPkCoCkkydTgrAwUYjeh();
				}
			}
		}

		public void uNyIBWGGpPkCoCkkydTgrAwUYjeh()
		{
			if (nZGkvHrmxzZybzFNqdkJItQVvuxz != null)
			{
				yRnQOHPELnXJATbZtzJCYHDDPLtX.ZTfkwBcCbmWdTftlvIeaWRYDhlLDA(yyXRAglNdVuleZlVrDftYlNAaQdl);
			}
		}

		public void MVilijccJLtEDrJouwwsSRZpuiAi()
		{
			if (nZGkvHrmxzZybzFNqdkJItQVvuxz != null)
			{
				XPCyUJXUbRceDqrAjRuhjeHsaGsO = ZEDCtLbQFHJUyCHOuSwZgfIGaXHZ.id;
				ZEDCtLbQFHJUyCHOuSwZgfIGaXHZ.Increment();
				if (LbKHlXZcltBEACaVIVeMXtmnXqut)
				{
					uNyIBWGGpPkCoCkkydTgrAwUYjeh();
				}
				else
				{
					fxABgbFrQcJwUlFJJbtXgjqAxPxQB();
				}
			}
		}

		public uint jQUzIPkHuESuEjbVMdXlfAFiSVSZ(OxefyMfZIgXEzbqjvpxteWerzayF P_0)
		{
			return yRnQOHPELnXJATbZtzJCYHDDPLtX.CdQZufWqAaySgdITWKgIsAFgeFnC(P_0);
		}

		public bool yowGbDuLvLkrmVzPMxNxxxXsynye(uint P_0)
		{
			return yRnQOHPELnXJATbZtzJCYHDDPLtX.XYjegXfbbJnPwpUsUjiFhfTEYDxgB(P_0);
		}

		public void fxABgbFrQcJwUlFJJbtXgjqAxPxQB()
		{
			yRnQOHPELnXJATbZtzJCYHDDPLtX.dPkGFrUOlaXtNURVumddsygcZGBF();
		}
	}

	[CustomObfuscation(rename = false)]
	public enum GetAndUpdateLocalizedStringResultFlags
	{
		None = 0,
		Failed = 1,
		IsCachedValue = 2,
		Changed = 4,
		JustLocalized = 8
	}

	private const char fzojBvLzePlYFawavTuxFtXKFmPb = '_';

	private const char TCXkHnIjoTnEWxykqyrGNnDIGdfI = '/';

	private const string qmkyZAVuoLHREFSeHIZoaAfztOcOA = "/";

	internal const string hardwareTypeKey_universalKeyboard = "keyboard";

	internal const string hardwareTypeKey_universalMouse = "mouse";

	internal const string hardwareTypeKey_unknownController = "unknown_controller";

	internal const string localizationKeyAxisPoleSuffix_positive = "positive";

	internal const string localizationKeyAxisPoleSuffix_negative = "negative";

	internal const string localizationKeyAxisDirectionSuffix_horizontal = "horizontal";

	internal const string localizationKeyAxisDirectionSuffix_vertical = "vertical";

	internal const string localizationAndGlyphKeyCategory_controller = "controller";

	internal const string localizationAndGlyphKeyCategory_customController = "controller/custom";

	internal const string localizationAndGlyphKeyCategory_controllerTemplate = "controller/template";

	internal const string localizationAndGlyphKeyCategory_action = "action";

	internal const string localizationAndGlyphKeyCategory_inputActionCategory = "action/category";

	internal const string localizationAndGlyphKeyCategory_controllerMap = "controller_map";

	internal const string localizationAndGlyphKeyCategory_controllerMapCategory = "controller_map/category";

	internal const string localizationAndGlyphKeyCategory_layout = "controller_map/layout";

	internal const string localizationAndGlyphKeyCategory_player = "player";

	internal const string localizationAndGlyphKeyCategory_controllerElement = "controller/element";

	internal const string nonLocalizedDisplayNameAxisDirectionSuffix_horizontal = "Horizontal";

	internal const string nonLocalizedDisplayNameAxisDirectionSuffix_vertical = "Vertical";

	private static rfWAFtgCAfGmBkKfECUPpEpyEynr gBFRGzwIGqTpnQQFmvELSQaISGap;

	private static StringBuilder JISPzBxQqKdarmOcMgyYqDPNVRoK;

	public static bool isEnabled
	{
		get
		{
			if (gBFRGzwIGqTpnQQFmvELSQaISGap == null)
			{
				return false;
			}
			return gBFRGzwIGqTpnQQFmvELSQaISGap.nZGkvHrmxzZybzFNqdkJItQVvuxz != null;
		}
	}

	public static uint version
	{
		get
		{
			YPmvWrVwIZsmcuHpgLNNgzFKYleG();
			return gBFRGzwIGqTpnQQFmvELSQaISGap.XPCyUJXUbRceDqrAjRuhjeHsaGsO;
		}
	}

	public static ILocalizedStringProvider localizedStringProvider
	{
		get
		{
			YPmvWrVwIZsmcuHpgLNNgzFKYleG();
			return gBFRGzwIGqTpnQQFmvELSQaISGap.nZGkvHrmxzZybzFNqdkJItQVvuxz;
		}
		set
		{
			YPmvWrVwIZsmcuHpgLNNgzFKYleG();
			gBFRGzwIGqTpnQQFmvELSQaISGap.ERUKPpWzHavgcFgHihImAKbiiSjPA(value);
		}
	}

	public static bool autoPrefetch
	{
		get
		{
			YPmvWrVwIZsmcuHpgLNNgzFKYleG();
			return gBFRGzwIGqTpnQQFmvELSQaISGap.LbKHlXZcltBEACaVIVeMXtmnXqut;
		}
		set
		{
			YPmvWrVwIZsmcuHpgLNNgzFKYleG();
			gBFRGzwIGqTpnQQFmvELSQaISGap.xmlAzRQaLRDdLYUcEexCdFoIMBWG(value);
		}
	}

	public static void Initialize()
	{
		if (gBFRGzwIGqTpnQQFmvELSQaISGap != null)
		{
			throw new Exception("Already initialized");
		}
		gBFRGzwIGqTpnQQFmvELSQaISGap = new rfWAFtgCAfGmBkKfECUPpEpyEynr();
	}

	public static void Deinitialize()
	{
		if (gBFRGzwIGqTpnQQFmvELSQaISGap != null)
		{
			gBFRGzwIGqTpnQQFmvELSQaISGap = null;
		}
	}

	public static void Add(OxefyMfZIgXEzbqjvpxteWerzayF obj, ref Id id)
	{
		YPmvWrVwIZsmcuHpgLNNgzFKYleG();
		id = gBFRGzwIGqTpnQQFmvELSQaISGap.jQUzIPkHuESuEjbVMdXlfAFiSVSZ(obj);
	}

	public static bool Remove(ref Id id)
	{
		YPmvWrVwIZsmcuHpgLNNgzFKYleG();
		bool result = gBFRGzwIGqTpnQQFmvELSQaISGap.yowGbDuLvLkrmVzPMxNxxxXsynye(id);
		id = 0u;
		return result;
	}

	public static void Prefetch()
	{
		YPmvWrVwIZsmcuHpgLNNgzFKYleG();
		gBFRGzwIGqTpnQQFmvELSQaISGap.uNyIBWGGpPkCoCkkydTgrAwUYjeh();
	}

	public static void Reload()
	{
		YPmvWrVwIZsmcuHpgLNNgzFKYleG();
		gBFRGzwIGqTpnQQFmvELSQaISGap.MVilijccJLtEDrJouwwsSRZpuiAi();
	}

	private static void YPmvWrVwIZsmcuHpgLNNgzFKYleG()
	{
		if (gBFRGzwIGqTpnQQFmvELSQaISGap == null)
		{
			throw new Exception(typeof(LocalizationManager).Name + " is not initialized.");
		}
	}

	public static bool TryGetCachedLocalizedString(LocalizedString localizedString, string fallback, uint localizationVersion, uint dependenciesVersion, out bool localizationVersionChanged, out string result)
	{
		if (gBFRGzwIGqTpnQQFmvELSQaISGap.nZGkvHrmxzZybzFNqdkJItQVvuxz != null)
		{
			if (localizedString.TryGetLocalizedValue(null, gBFRGzwIGqTpnQQFmvELSQaISGap.nZGkvHrmxzZybzFNqdkJItQVvuxz, gBFRGzwIGqTpnQQFmvELSQaISGap.XPCyUJXUbRceDqrAjRuhjeHsaGsO, dependenciesVersion, out localizationVersionChanged, out result))
			{
				return true;
			}
			result = fallback;
			return false;
		}
		result = fallback;
		localizationVersionChanged = false;
		return false;
	}

	public static bool TryLocalizeString(LocalizedString localizedString, string key, uint localizationVersion, uint dependenciesVersion, out string result)
	{
		if (gBFRGzwIGqTpnQQFmvELSQaISGap.nZGkvHrmxzZybzFNqdkJItQVvuxz != null)
		{
			localizedString.Clear();
			bool versionChanged;
			return localizedString.TryGetLocalizedValue(key, gBFRGzwIGqTpnQQFmvELSQaISGap.nZGkvHrmxzZybzFNqdkJItQVvuxz, gBFRGzwIGqTpnQQFmvELSQaISGap.XPCyUJXUbRceDqrAjRuhjeHsaGsO, dependenciesVersion, out versionChanged, out result);
		}
		result = null;
		return false;
	}

	public static GetAndUpdateLocalizedStringResultFlags GetAndUpdateLocalizedString(LocalizedString localizedString, IReadOnlyList<string> parentKeys, string keyCategory, string fallback, out string result)
	{
		if (gBFRGzwIGqTpnQQFmvELSQaISGap.nZGkvHrmxzZybzFNqdkJItQVvuxz == null)
		{
			result = fallback;
			return GetAndUpdateLocalizedStringResultFlags.Failed;
		}
		GetAndUpdateLocalizedStringResultFlags getAndUpdateLocalizedStringResultFlags = ((!TryGetCachedLocalizedString(localizedString, fallback, gBFRGzwIGqTpnQQFmvELSQaISGap.XPCyUJXUbRceDqrAjRuhjeHsaGsO, 0u, out var localizationVersionChanged, out result)) ? GetAndUpdateLocalizedStringResultFlags.Failed : GetAndUpdateLocalizedStringResultFlags.IsCachedValue);
		if (!localizedString.hasCachedValue | localizationVersionChanged)
		{
			getAndUpdateLocalizedStringResultFlags |= GetAndUpdateLocalizedStringResultFlags.Changed;
			if (tygiUxoETxknalBmkclvclMDCaUaA(localizedString, parentKeys, keyCategory, fallback, out result))
			{
				getAndUpdateLocalizedStringResultFlags |= GetAndUpdateLocalizedStringResultFlags.JustLocalized;
				getAndUpdateLocalizedStringResultFlags &= (GetAndUpdateLocalizedStringResultFlags)(-2);
			}
			else
			{
				getAndUpdateLocalizedStringResultFlags |= GetAndUpdateLocalizedStringResultFlags.Failed;
			}
		}
		return getAndUpdateLocalizedStringResultFlags;
	}

	public static GetAndUpdateLocalizedStringResultFlags GetAndUpdateLocalizedString(LocalizedString localizedString, string key, string keyCategory, IReadOnlyList<string> parentKeys, string fallback, out string result)
	{
		if (gBFRGzwIGqTpnQQFmvELSQaISGap.nZGkvHrmxzZybzFNqdkJItQVvuxz == null)
		{
			result = fallback;
			return GetAndUpdateLocalizedStringResultFlags.Failed;
		}
		GetAndUpdateLocalizedStringResultFlags getAndUpdateLocalizedStringResultFlags = ((!TryGetCachedLocalizedString(localizedString, fallback, gBFRGzwIGqTpnQQFmvELSQaISGap.XPCyUJXUbRceDqrAjRuhjeHsaGsO, 0u, out var localizationVersionChanged, out result)) ? GetAndUpdateLocalizedStringResultFlags.Failed : GetAndUpdateLocalizedStringResultFlags.IsCachedValue);
		if (!localizedString.hasCachedValue | localizationVersionChanged)
		{
			getAndUpdateLocalizedStringResultFlags |= GetAndUpdateLocalizedStringResultFlags.Changed;
			if (HIjKmsPPKDBcBDQXRqstQdJylcTe(localizedString, key, keyCategory, fallback, parentKeys, out result))
			{
				getAndUpdateLocalizedStringResultFlags |= GetAndUpdateLocalizedStringResultFlags.JustLocalized;
				getAndUpdateLocalizedStringResultFlags &= (GetAndUpdateLocalizedStringResultFlags)(-2);
			}
			else
			{
				getAndUpdateLocalizedStringResultFlags |= GetAndUpdateLocalizedStringResultFlags.Failed;
			}
		}
		return getAndUpdateLocalizedStringResultFlags;
	}

	private static bool tygiUxoETxknalBmkclvclMDCaUaA(LocalizedString P_0, IReadOnlyList<string> P_1, string P_2, string P_3, out string P_4)
	{
		if (P_1 == null)
		{
			P_4 = P_3;
			return false;
		}
		bool result = false;
		bool flag = !string.IsNullOrEmpty(P_2);
		StringBuilder sharedStringBuilder = GetSharedStringBuilder();
		int num = 0;
		while (true)
		{
			if (num < P_1.Count)
			{
				if (!string.IsNullOrEmpty(P_1[num]))
				{
					sharedStringBuilder.Length = 0;
					if (flag)
					{
						sharedStringBuilder.Append(P_2);
					}
					AppendToKeyAsPath(sharedStringBuilder, P_1[num]);
					if (TryLocalizeString(P_0, sharedStringBuilder.ToString(), gBFRGzwIGqTpnQQFmvELSQaISGap.XPCyUJXUbRceDqrAjRuhjeHsaGsO, 0u, out P_4))
					{
						result = true;
						break;
					}
				}
				num++;
				continue;
			}
			P_4 = P_3;
			break;
		}
		P_0.cachedValue = P_4;
		return result;
	}

	private static bool HIjKmsPPKDBcBDQXRqstQdJylcTe(LocalizedString P_0, string P_1, string P_2, string P_3, IReadOnlyList<string> P_4, out string P_5)
	{
		if (string.IsNullOrEmpty(P_1))
		{
			P_5 = P_3;
			return false;
		}
		bool result = false;
		uint dependenciesVersion = 0u;
		bool flag = !string.IsNullOrEmpty(P_2);
		StringBuilder sharedStringBuilder = GetSharedStringBuilder();
		if (P_4 != null)
		{
			for (int i = 0; i < P_4.Count; i++)
			{
				if (string.IsNullOrEmpty(P_4[i]))
				{
					continue;
				}
				sharedStringBuilder.Length = 0;
				if (flag)
				{
					sharedStringBuilder.Append(P_2);
				}
				AppendToKeyAsPath(sharedStringBuilder, P_4[i]);
				AppendToKeyAsPath(sharedStringBuilder, P_1);
				if (!TryLocalizeString(P_0, sharedStringBuilder.ToString(), gBFRGzwIGqTpnQQFmvELSQaISGap.XPCyUJXUbRceDqrAjRuhjeHsaGsO, dependenciesVersion, out P_5))
				{
					continue;
				}
				goto IL_0080;
			}
		}
		if (P_4 == null || P_4.Count == 0)
		{
			sharedStringBuilder.Length = 0;
			if (flag)
			{
				sharedStringBuilder.Append(P_2);
			}
			AppendToKeyAsPath(sharedStringBuilder, P_1);
			if (TryLocalizeString(P_0, sharedStringBuilder.ToString(), gBFRGzwIGqTpnQQFmvELSQaISGap.XPCyUJXUbRceDqrAjRuhjeHsaGsO, dependenciesVersion, out P_5))
			{
				result = true;
				goto IL_00df;
			}
		}
		P_5 = P_3;
		goto IL_00df;
		IL_00df:
		P_0.cachedValue = P_5;
		return result;
		IL_0080:
		result = true;
		goto IL_00df;
	}

	public static string ConcatenateKeyStrings(string a, string b)
	{
		if (string.IsNullOrEmpty(a))
		{
			return b;
		}
		if (string.IsNullOrEmpty(b))
		{
			return a;
		}
		StringBuilder sharedStringBuilder = GetSharedStringBuilder();
		sharedStringBuilder.Append(a);
		sharedStringBuilder.Append('_');
		sharedStringBuilder.Append(b);
		return sharedStringBuilder.ToString();
	}

	public static string AppendToKeyAsPath(string a, string b)
	{
		if (string.IsNullOrEmpty(a))
		{
			return b;
		}
		if (string.IsNullOrEmpty(b))
		{
			return a;
		}
		StringBuilder sharedStringBuilder = GetSharedStringBuilder();
		sharedStringBuilder.Append(a);
		sharedStringBuilder.Append('/');
		sharedStringBuilder.Append(b);
		return sharedStringBuilder.ToString();
	}

	public static StringBuilder AppendToKeyAsPath(StringBuilder sb, string value)
	{
		if (string.IsNullOrEmpty(value))
		{
			return sb;
		}
		if (sb.Length > 0)
		{
			sb.Append('/');
		}
		sb.Append(value);
		return sb;
	}

	public static string AppendToKeyAxisPole(string a, Pole pole)
	{
		if (string.IsNullOrEmpty(a))
		{
			return string.Empty;
		}
		return AppendToKeyAsPath(a, (pole == Pole.Positive) ? "positive" : "negative");
	}

	public static string AppendToNameAxisPole(string text, Pole pole)
	{
		return pole switch
		{
			Pole.Positive => text + " +", 
			Pole.Negative => text + " -", 
			_ => text, 
		};
	}

	public static string AppendToKeyAxisDirection(string a, AxisDirection direction)
	{
		if (string.IsNullOrEmpty(a))
		{
			return string.Empty;
		}
		return AppendToKeyAsPath(a, (direction == AxisDirection.Vertical) ? "vertical" : "horizontal");
	}

	public static string AppendToNameAxisDirection(string a, AxisDirection direction)
	{
		if (string.IsNullOrEmpty(a))
		{
			return string.Empty;
		}
		return a + " " + ((direction == AxisDirection.Vertical) ? "Vertical" : "Horizontal");
	}

	public static string FormatKey(string text)
	{
		if (string.IsNullOrEmpty(text))
		{
			return text;
		}
		return StringTools.AddSpacesToCamelCase(text).Replace(' ', '_').ToLowerInvariant();
	}

	[CustomObfuscation(rename = false)]
	public static StringBuilder GetSharedStringBuilder()
	{
		if (JISPzBxQqKdarmOcMgyYqDPNVRoK != null)
		{
			JISPzBxQqKdarmOcMgyYqDPNVRoK.Length = 0;
			return JISPzBxQqKdarmOcMgyYqDPNVRoK;
		}
		return JISPzBxQqKdarmOcMgyYqDPNVRoK = new StringBuilder();
	}
}
