using System;
using System.Collections.Generic;
using Rewired.Interfaces;
using Rewired.Internal.Glyphs;
using Rewired.Internal.Localization;
using UnityEngine;

namespace Rewired;

[Serializable]
[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
public sealed class ControllerElementIdentifier : IControllerElementIdentifierCommon_Internal, XllMlgxhLwGZSIuGyCJYDhwKbYtab, JPyUCjMynlgXcSTGrAuSOGxEMeWJ, PJBELdSJSsLkgyPuksQJNLebsJqQ, lhkLrWnhlfHasNgQzbqhGosPUipt, RbTIGwoNbWAtnheIYRRWJRKnTqxqA, MdIaVdZIcZLvNyTteqNnkfKPAaJl
{
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	internal class ThaQNPmIsUvtgdNurUEQZTaCLDVq
	{
		public int id;

		public string name;

		public string positiveName;

		public string negativeName;

		public string key;

		public string positiveKey;

		public string negativeKey;

		public ControllerElementType elementType;

		public CompoundControllerElementType compoundElementType;
	}

	internal sealed class IXUfuJPTYVyUAZoWDNiTgWTMpvLS
	{
		[Serializable]
		private sealed class KaHKFBzqyIqxdZKCEwVqzuRfAfjo
		{
			public static readonly KaHKFBzqyIqxdZKCEwVqzuRfAfjo _003C_003E9 = new KaHKFBzqyIqxdZKCEwVqzuRfAfjo();

			public static Func<ControllerElementIdentifier, ControllerElementIdentifier, bool> _003C_003E9__4_0;

			internal bool zjvGALmUKsELyGZRqCyAObjKIXyEb(ControllerElementIdentifier P_0, ControllerElementIdentifier P_1)
			{
				if (P_0 == null || P_1 == null)
				{
					return false;
				}
				if (P_0 != null && P_1 != null && P_0.get_id() == P_1.get_id() && P_0.elementType == P_1.elementType && P_0.compoundElementType == P_1.compoundElementType)
				{
					return string.Equals(P_0.key, P_1.key, StringComparison.Ordinal);
				}
				return false;
			}
		}

		private static IXUfuJPTYVyUAZoWDNiTgWTMpvLS dwNmofnGIvjYMvwBeqKjFaHMDBkD;

		private readonly global::lVvaRWFpPRDdIEUiIKNGBOwxeQgw<ControllerElementIdentifier> ByDDKXfPMDsYfUgrvIWeVqIPYvBtA;

		private static IXUfuJPTYVyUAZoWDNiTgWTMpvLS msoDRTboVkUlSOljkNrrjpPOurKkA => iTipCLRDRdlzJBNmFbJFVvpumMSE();

		private static IXUfuJPTYVyUAZoWDNiTgWTMpvLS iTipCLRDRdlzJBNmFbJFVvpumMSE()
		{
			if (dwNmofnGIvjYMvwBeqKjFaHMDBkD != null)
			{
				return dwNmofnGIvjYMvwBeqKjFaHMDBkD;
			}
			dwNmofnGIvjYMvwBeqKjFaHMDBkD = new IXUfuJPTYVyUAZoWDNiTgWTMpvLS();
			dwNmofnGIvjYMvwBeqKjFaHMDBkD.UKgbAxpQsQPhLLVlmBrspuhccywt();
			return dwNmofnGIvjYMvwBeqKjFaHMDBkD;
		}

		private IXUfuJPTYVyUAZoWDNiTgWTMpvLS()
		{
			ByDDKXfPMDsYfUgrvIWeVqIPYvBtA = new global::lVvaRWFpPRDdIEUiIKNGBOwxeQgw<ControllerElementIdentifier>(KaHKFBzqyIqxdZKCEwVqzuRfAfjo._003C_003E9.zjvGALmUKsELyGZRqCyAObjKIXyEb);
		}

		private void UKgbAxpQsQPhLLVlmBrspuhccywt()
		{
			ReInput.ShutDownEvent += dwNmofnGIvjYMvwBeqKjFaHMDBkD.zJKMFgSRXcLBUfkZjtUUEvMPSRBG;
		}

		private void zJKMFgSRXcLBUfkZjtUUEvMPSRBG()
		{
			if (dwNmofnGIvjYMvwBeqKjFaHMDBkD == this)
			{
				dwNmofnGIvjYMvwBeqKjFaHMDBkD = null;
			}
			ReInput.ShutDownEvent -= zJKMFgSRXcLBUfkZjtUUEvMPSRBG;
		}

		public static ControllerElementIdentifier EGrGjcfFXiaBlBaHRqEnTneKyGhrA(DeviceLocalizationInfo P_0, ControllerElementIdentifier P_1)
		{
			return iTipCLRDRdlzJBNmFbJFVvpumMSE().ByDDKXfPMDsYfUgrvIWeVqIPYvBtA.KfGfCFQYIBUUThUqDQAwAPjENAiG(P_0.hash, P_1);
		}

		public static bool eOPBIARExkwtzhPRNhivUCqPTUJg(DeviceLocalizationInfo P_0, ControllerElementIdentifier P_1, out ControllerElementIdentifier P_2)
		{
			return iTipCLRDRdlzJBNmFbJFVvpumMSE().ByDDKXfPMDsYfUgrvIWeVqIPYvBtA.elHbnypVRYAnmLgDxxneJfNHjcbfA(P_0.hash, P_1, out P_2);
		}

		public static void opbjoMrKlnhRIcsLWpmJWKgSojdM(DeviceLocalizationInfo P_0, ControllerElementIdentifier P_1)
		{
			iTipCLRDRdlzJBNmFbJFVvpumMSE().ByDDKXfPMDsYfUgrvIWeVqIPYvBtA.RHHrLiuKFpjNWsGCNIVkgVcHmmlzA(P_0.hash, P_1);
		}
	}

	private class WUaJosdFmWNrSVnbweyFXCiBmyAK
	{
		[SerializeField]
		private string esNEMoIaZXNlSOJVeboQthXPEUCm;

		[SerializeField]
		private string wYRDqLjVqrAjKGrEifZFOCtCQWPaA;

		public string ngzrbxOAhmfWUiTBSvSXIYoarCrX
		{
			get
			{
				return UCXvXrUZEXHQtNdgjRstMJxahBLA();
			}
			set
			{
				WFgcLuiWRLgfZLMuiJOTIjXACGdf(text);
			}
		}

		public string ldjBNegQyWpwkIYhkVMSeLbHmmNuA
		{
			get
			{
				return dgvqtXdxROaCPgFiQxpjjgsmfFTi();
			}
			set
			{
				txqsWTOhIUtepcjUyHfUWiPOcYpX(text);
			}
		}

		public string UCXvXrUZEXHQtNdgjRstMJxahBLA()
		{
			return esNEMoIaZXNlSOJVeboQthXPEUCm;
		}

		public void WFgcLuiWRLgfZLMuiJOTIjXACGdf(string P_0)
		{
			esNEMoIaZXNlSOJVeboQthXPEUCm = P_0;
		}

		public string dgvqtXdxROaCPgFiQxpjjgsmfFTi()
		{
			return wYRDqLjVqrAjKGrEifZFOCtCQWPaA;
		}

		public void txqsWTOhIUtepcjUyHfUWiPOcYpX(string P_0)
		{
			wYRDqLjVqrAjKGrEifZFOCtCQWPaA = P_0;
		}

		public WUaJosdFmWNrSVnbweyFXCiBmyAK()
		{
		}

		public WUaJosdFmWNrSVnbweyFXCiBmyAK(WUaJosdFmWNrSVnbweyFXCiBmyAK P_0)
		{
			esNEMoIaZXNlSOJVeboQthXPEUCm = P_0.esNEMoIaZXNlSOJVeboQthXPEUCm;
			wYRDqLjVqrAjKGrEifZFOCtCQWPaA = P_0.wYRDqLjVqrAjKGrEifZFOCtCQWPaA;
		}
	}

	[SerializeField]
	[CustomObfuscation(rename = false)]
	private int _id;

	[SerializeField]
	[CustomObfuscation(rename = false)]
	private string _name;

	[SerializeField]
	[CustomObfuscation(rename = false)]
	private string _positiveName;

	[SerializeField]
	[CustomObfuscation(rename = false)]
	private string _negativeName;

	[SerializeField]
	[CustomObfuscation(rename = false)]
	private string _key;

	[SerializeField]
	[CustomObfuscation(rename = false)]
	private string _positiveKey;

	[SerializeField]
	[CustomObfuscation(rename = false)]
	private string _negativeKey;

	[SerializeField]
	[CustomObfuscation(rename = false)]
	private ControllerElementType _elementType;

	[SerializeField]
	[CustomObfuscation(rename = false)]
	private CompoundControllerElementType _compoundElementType;

	[NonSerialized]
	private bool sBLWsojqxsouMZEfJsHJTsJZRJxQ;

	[NonSerialized]
	private LQtXvKbJmTxxtcVMoxtOkVHKDdXk urRCZSIdQNEdvBuuQJjWmXYNyugX;

	[NonSerialized]
	private aAGDdhnGwWmFccaJOAZAKNefGyZgA eYdAQBqfhHBdAkwLICYceqAeFaTKA;

	[NonSerialized]
	private ypQSALAIAHDQZQMeoLnrlsqLndiM dJhaYFwrygnhUyDNlcbQUnMlRSkx;

	[NonSerialized]
	private sfCgXsMoDxqWKNucNXLXeivVnZrj GOiCWBxcnYbWcXjZbxQANhVZzQuS;

	[NonSerialized]
	private DeviceLocalizationInfo TEDxpGrigahBiZjGnfAHIoIBoJWq;

	[NonSerialized]
	private int kuMVzZseaeqKrPyXecwrvDuyIaUG;

	[NonSerialized]
	private List<WUaJosdFmWNrSVnbweyFXCiBmyAK> hfuiymDHuUdTwCSLUPXpvNQkzwvm;

	[NonSerialized]
	private ControllerType WGOrNiRewQeadcfhGNrFGHjjXDsZ;

	private static ControllerElementIdentifier XRdQdAdxMFMmxYeZawdaulZGtqLA;

	int IControllerElementIdentifierCommon_Internal.id => get_id();

	string IControllerElementIdentifierCommon_Internal.name
	{
		get
		{
			return get_name();
		}
		internal set
		{
			set_name(value);
		}
	}

	string IControllerElementIdentifierCommon_Internal.positiveName
	{
		get
		{
			return get_positiveName();
		}
		internal set
		{
			set_positiveName(value);
		}
	}

	string IControllerElementIdentifierCommon_Internal.negativeName
	{
		get
		{
			return get_negativeName();
		}
		internal set
		{
			set_negativeName(value);
		}
	}

	public ControllerElementType elementType => _elementType;

	public CompoundControllerElementType compoundElementType => _compoundElementType;

	public object glyph
	{
		get
		{
			if (!ReInput.isReady || dJhaYFwrygnhUyDNlcbQUnMlRSkx == null || !GlyphManager.isEnabled)
			{
				return null;
			}
			return dJhaYFwrygnhUyDNlcbQUnMlRSkx.kGpzldgkfThCvAoiWaIMVZlaEKuW();
		}
	}

	public object positiveGlyph
	{
		get
		{
			if (!ReInput.isReady || dJhaYFwrygnhUyDNlcbQUnMlRSkx == null || !GlyphManager.isEnabled)
			{
				return null;
			}
			return dJhaYFwrygnhUyDNlcbQUnMlRSkx.RSfMQptZQMzyPBdAWCLqWVwnoTvB();
		}
	}

	public object negativeGlyph
	{
		get
		{
			if (!ReInput.isReady || dJhaYFwrygnhUyDNlcbQUnMlRSkx == null || !GlyphManager.isEnabled)
			{
				return null;
			}
			return dJhaYFwrygnhUyDNlcbQUnMlRSkx.KDXTtdSwDJHFhXTlpOXEspYximXw();
		}
	}

	private string finalGlyphKey => vzeubUDqxCRukYlVLQnOlAYAspmk();

	private string finalPositiveGlyphKey => ZhUbQtTAIvIeORlojXtYWuGrFPqV();

	private string finalNegativeGlyphKey => YirlWantJxEphsACvGXFiwDgCFpn();

	internal string nonLocalizedName
	{
		get
		{
			return _name;
		}
		set
		{
			_name = value;
			if (ReInput.isReady)
			{
				JaVNCreTldtDtJYwFnEOwEYYHSFY();
				if (urRCZSIdQNEdvBuuQJjWmXYNyugX != null)
				{
					urRCZSIdQNEdvBuuQJjWmXYNyugX.qFSeqqVPfIqnwwFRvTgDucKqgogy();
				}
			}
		}
	}

	internal string nonLocalizedPositiveName
	{
		get
		{
			return _positiveName;
		}
		set
		{
			_positiveName = value;
			if (ReInput.isReady)
			{
				JaVNCreTldtDtJYwFnEOwEYYHSFY();
				if (urRCZSIdQNEdvBuuQJjWmXYNyugX != null)
				{
					urRCZSIdQNEdvBuuQJjWmXYNyugX.XNpaTfyhAhNTxHJiXVjNbdVbSPHt();
				}
			}
		}
	}

	internal string nonLocalizedNegativeName
	{
		get
		{
			return _negativeName;
		}
		set
		{
			_negativeName = value;
			if (ReInput.isReady)
			{
				JaVNCreTldtDtJYwFnEOwEYYHSFY();
				if (urRCZSIdQNEdvBuuQJjWmXYNyugX != null)
				{
					urRCZSIdQNEdvBuuQJjWmXYNyugX.qrcDCChoJyLkCoCgPOHAVlSlEEoib();
				}
			}
		}
	}

	public string key => _key;

	public string positiveKey => _positiveKey;

	public string negativeKey => _negativeKey;

	internal bool isCompoundElement => _elementType == ControllerElementType.CompoundElement;

	string IControllerElementIdentifierCommon_Internal.nonLocalizedName => nonLocalizedName;

	string IControllerElementIdentifierCommon_Internal.nonLocalizedPositiveName => nonLocalizedPositiveName;

	string IControllerElementIdentifierCommon_Internal.nonLocalizedNegativeName => nonLocalizedNegativeName;

	bool IControllerElementIdentifierCommon_Internal.isNonLocalizedPositiveNameAutoGenerated => (kuMVzZseaeqKrPyXecwrvDuyIaUG & 2) != 0;

	bool IControllerElementIdentifierCommon_Internal.isNonLocalizedNegativeNameAutoGenerated => (kuMVzZseaeqKrPyXecwrvDuyIaUG & 4) != 0;

	bool IControllerElementIdentifierCommon_Internal.isPositiveKeyAutoGenerated => (kuMVzZseaeqKrPyXecwrvDuyIaUG & 8) != 0;

	bool IControllerElementIdentifierCommon_Internal.isNegativeKeyAutoGenerated => (kuMVzZseaeqKrPyXecwrvDuyIaUG & 0x10) != 0;

	string IControllerElementIdentifierCommon_Internal.key => _key;

	string IControllerElementIdentifierCommon_Internal.positiveKey => _positiveKey;

	string IControllerElementIdentifierCommon_Internal.negativeKey => _negativeKey;

	DeviceLocalizationInfo IControllerElementIdentifierCommon_Internal.deviceLocalizationInfo => TEDxpGrigahBiZjGnfAHIoIBoJWq;

	object IControllerElementIdentifierCommon_Internal.elementType => _elementType;

	bool IControllerElementIdentifierCommon_Internal.useEditorElementTypeOverride => false;

	ControllerElementType IControllerElementIdentifierCommon_Internal.editorElementTypeOverride => _elementType;

	internal static ControllerElementIdentifier BlankReadOnly
	{
		get
		{
			if (XRdQdAdxMFMmxYeZawdaulZGtqLA == null)
			{
				ControllerElementIdentifier obj = new ControllerElementIdentifier
				{
					_id = -1,
					sBLWsojqxsouMZEfJsHJTsJZRJxQ = true
				};
				XRdQdAdxMFMmxYeZawdaulZGtqLA = obj;
				return obj;
			}
			return XRdQdAdxMFMmxYeZawdaulZGtqLA;
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

	string XllMlgxhLwGZSIuGyCJYDhwKbYtab.nonLocalizedPositiveDescriptiveName
	{
		get
		{
			return Rewired_002EInternal_002ELocalization_002EIAxisNameLocalizerSource_002Eget_nonLocalizedPositiveDescriptiveName();
		}
		set
		{
			Rewired_002EInternal_002ELocalization_002EIAxisNameLocalizerSource_002Eset_nonLocalizedPositiveDescriptiveName(value);
		}
	}

	string XllMlgxhLwGZSIuGyCJYDhwKbYtab.nonLocalizedNegativeDescriptiveName
	{
		get
		{
			return Rewired_002EInternal_002ELocalization_002EIAxisNameLocalizerSource_002Eget_nonLocalizedNegativeDescriptiveName();
		}
		set
		{
			Rewired_002EInternal_002ELocalization_002EIAxisNameLocalizerSource_002Eset_nonLocalizedNegativeDescriptiveName(value);
		}
	}

	string JPyUCjMynlgXcSTGrAuSOGxEMeWJ.key => Rewired_002EInternal_002ELocalization_002EINameLocalizerSource_002Eget_key();

	string XllMlgxhLwGZSIuGyCJYDhwKbYtab.positiveKey
	{
		get
		{
			return Rewired_002EInternal_002ELocalization_002EIAxisNameLocalizerSource_002Eget_positiveKey();
		}
		set
		{
			Rewired_002EInternal_002ELocalization_002EIAxisNameLocalizerSource_002Eset_positiveKey(value);
		}
	}

	string XllMlgxhLwGZSIuGyCJYDhwKbYtab.negativeKey
	{
		get
		{
			return Rewired_002EInternal_002ELocalization_002EIAxisNameLocalizerSource_002Eget_negativeKey();
		}
		set
		{
			Rewired_002EInternal_002ELocalization_002EIAxisNameLocalizerSource_002Eset_negativeKey(value);
		}
	}

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

	string lhkLrWnhlfHasNgQzbqhGosPUipt.keyCategory => Rewired_002EInternal_002EGlyphs_002EIGlyphKeySource_002Eget_keyCategory();

	string lhkLrWnhlfHasNgQzbqhGosPUipt.key => Rewired_002EInternal_002EGlyphs_002EIGlyphKeySource_002Eget_key();

	int lhkLrWnhlfHasNgQzbqhGosPUipt.autoGeneratedValueFlags
	{
		get
		{
			return Rewired_002EInternal_002EGlyphs_002EIGlyphKeySource_002Eget_autoGeneratedValueFlags();
		}
		set
		{
			Rewired_002EInternal_002EGlyphs_002EIGlyphKeySource_002Eset_autoGeneratedValueFlags(value);
		}
	}

	string PJBELdSJSsLkgyPuksQJNLebsJqQ.positiveKey
	{
		get
		{
			return Rewired_002EInternal_002EGlyphs_002EIAxisGlyphKeySource_002Eget_positiveKey();
		}
		set
		{
			Rewired_002EInternal_002EGlyphs_002EIAxisGlyphKeySource_002Eset_positiveKey(value);
		}
	}

	string PJBELdSJSsLkgyPuksQJNLebsJqQ.negativeKey
	{
		get
		{
			return Rewired_002EInternal_002EGlyphs_002EIAxisGlyphKeySource_002Eget_negativeKey();
		}
		set
		{
			Rewired_002EInternal_002EGlyphs_002EIAxisGlyphKeySource_002Eset_negativeKey(value);
		}
	}

	public int get_id()
	{
		return _id;
	}

	public string get_name()
	{
		if (!ReInput.isReady || urRCZSIdQNEdvBuuQJjWmXYNyugX == null || !LocalizationManager.isEnabled)
		{
			return _name;
		}
		return urRCZSIdQNEdvBuuQJjWmXYNyugX.aLsidTWLDaQPOPmyxGbWHeMTGfoEA();
	}

	internal void set_name(string value)
	{
		nonLocalizedName = value;
	}

	public string get_positiveName()
	{
		if (!ReInput.isReady || urRCZSIdQNEdvBuuQJjWmXYNyugX == null || !LocalizationManager.isEnabled)
		{
			return _positiveName;
		}
		return urRCZSIdQNEdvBuuQJjWmXYNyugX.lRFaUAhYFCkkNqWgcrhJwDnyCHJXA();
	}

	internal void set_positiveName(string value)
	{
		nonLocalizedPositiveName = value;
	}

	public string get_negativeName()
	{
		if (!ReInput.isReady || urRCZSIdQNEdvBuuQJjWmXYNyugX == null || !LocalizationManager.isEnabled)
		{
			return _negativeName;
		}
		return urRCZSIdQNEdvBuuQJjWmXYNyugX.vPzaewrFBxaCLxupXxPEsOvRTyqq();
	}

	internal void set_negativeName(string value)
	{
		nonLocalizedNegativeName = value;
	}

	internal string GetCompoundElementSpecialName(int index)
	{
		if (!ReInput.isReady || !LocalizationManager.isEnabled || hfuiymDHuUdTwCSLUPXpvNQkzwvm == null || eYdAQBqfhHBdAkwLICYceqAeFaTKA == null)
		{
			return string.Empty;
		}
		return eYdAQBqfhHBdAkwLICYceqAeFaTKA.atdnnvxDKQqIjPIcaDemULmYXVTC(index);
	}

	private string vzeubUDqxCRukYlVLQnOlAYAspmk()
	{
		if (!ReInput.isReady || dJhaYFwrygnhUyDNlcbQUnMlRSkx == null || !GlyphManager.isEnabled)
		{
			return null;
		}
		return dJhaYFwrygnhUyDNlcbQUnMlRSkx.QmGGcKRfXciKdFBRaKFZnfezonaU();
	}

	private string ZhUbQtTAIvIeORlojXtYWuGrFPqV()
	{
		if (!ReInput.isReady || dJhaYFwrygnhUyDNlcbQUnMlRSkx == null || !GlyphManager.isEnabled)
		{
			return null;
		}
		return dJhaYFwrygnhUyDNlcbQUnMlRSkx.trTJDAavIVtiJPuukcZYOhCoSsBu();
	}

	private string YirlWantJxEphsACvGXFiwDgCFpn()
	{
		if (!ReInput.isReady || dJhaYFwrygnhUyDNlcbQUnMlRSkx == null || !GlyphManager.isEnabled)
		{
			return null;
		}
		return dJhaYFwrygnhUyDNlcbQUnMlRSkx.FUKZBOxUtkBXFQAmWgCXGwqmbFouA();
	}

	internal object GetCompoundElementSpecialGlyph(int index)
	{
		if (!ReInput.isReady || !GlyphManager.isEnabled || hfuiymDHuUdTwCSLUPXpvNQkzwvm == null || GOiCWBxcnYbWcXjZbxQANhVZzQuS == null)
		{
			return null;
		}
		return GOiCWBxcnYbWcXjZbxQANhVZzQuS.lXzeUUMmjVRbMviTqsVwkONaKRvI(index);
	}

	internal string GetCompoundElementSpecialFinalGlyphKey(int index)
	{
		if (!ReInput.isReady || !GlyphManager.isEnabled || hfuiymDHuUdTwCSLUPXpvNQkzwvm == null || GOiCWBxcnYbWcXjZbxQANhVZzQuS == null)
		{
			return null;
		}
		return GOiCWBxcnYbWcXjZbxQANhVZzQuS.vsERvouWOvioQpnbuMJNueMKBZweA(index);
	}

	string IControllerElementIdentifierCommon_Internal.GetSpecialElementNonLocalizedName(int index)
	{
		if (hfuiymDHuUdTwCSLUPXpvNQkzwvm == null || (uint)index >= (uint)hfuiymDHuUdTwCSLUPXpvNQkzwvm.Count)
		{
			return null;
		}
		return hfuiymDHuUdTwCSLUPXpvNQkzwvm[index].dgvqtXdxROaCPgFiQxpjjgsmfFTi();
	}

	string IControllerElementIdentifierCommon_Internal.GetSpecialElementKey(int index)
	{
		if (hfuiymDHuUdTwCSLUPXpvNQkzwvm == null || (uint)index >= (uint)hfuiymDHuUdTwCSLUPXpvNQkzwvm.Count)
		{
			return null;
		}
		return hfuiymDHuUdTwCSLUPXpvNQkzwvm[index].UCXvXrUZEXHQtNdgjRstMJxahBLA();
	}

	public ControllerElementIdentifier()
	{
	}

	public ControllerElementIdentifier(ControllerElementIdentifier P_0)
	{
		_id = P_0._id;
		_name = P_0._name;
		_positiveName = P_0._positiveName;
		_negativeName = P_0._negativeName;
		_key = P_0._key;
		_positiveKey = P_0._positiveKey;
		_negativeKey = P_0._negativeKey;
		_elementType = P_0._elementType;
		_compoundElementType = P_0._compoundElementType;
		if (P_0.hfuiymDHuUdTwCSLUPXpvNQkzwvm != null)
		{
			int count = P_0.hfuiymDHuUdTwCSLUPXpvNQkzwvm.Count;
			hfuiymDHuUdTwCSLUPXpvNQkzwvm = new List<WUaJosdFmWNrSVnbweyFXCiBmyAK>(count);
			for (int i = 0; i < count; i++)
			{
				if (P_0.hfuiymDHuUdTwCSLUPXpvNQkzwvm[i] != null)
				{
					hfuiymDHuUdTwCSLUPXpvNQkzwvm.Add(new WUaJosdFmWNrSVnbweyFXCiBmyAK(P_0.hfuiymDHuUdTwCSLUPXpvNQkzwvm[i]));
				}
			}
		}
		kuMVzZseaeqKrPyXecwrvDuyIaUG = P_0.kuMVzZseaeqKrPyXecwrvDuyIaUG;
		WGOrNiRewQeadcfhGNrFGHjjXDsZ = P_0.WGOrNiRewQeadcfhGNrFGHjjXDsZ;
	}

	internal ControllerElementIdentifier(ThaQNPmIsUvtgdNurUEQZTaCLDVq P_0)
	{
		if (P_0 == null)
		{
			throw new ArgumentNullException("initOptions");
		}
		_id = P_0.id;
		_name = P_0.name;
		_positiveName = P_0.positiveName;
		_negativeName = P_0.negativeName;
		_key = P_0.key;
		_positiveKey = P_0.positiveKey;
		_negativeKey = P_0.negativeKey;
		_elementType = P_0.elementType;
		_compoundElementType = P_0.compoundElementType;
	}

	[Obsolete("Used by plugins for mouse controllers. Left for plugin compatibility. Do not use.", false)]
	internal ControllerElementIdentifier(int P_0, string P_1, string P_2, string P_3, ControllerElementType P_4, CompoundControllerElementType P_5, bool P_6)
	{
		_id = P_0;
		_name = P_1;
		_positiveName = P_2;
		_negativeName = P_3;
		if (P_0 < Consts.commonMouseElementIdentifierInitOptions.Length && string.Equals(Consts.commonMouseElementIdentifierInitOptions[P_0].name, P_1, StringComparison.Ordinal))
		{
			_key = Consts.commonMouseElementIdentifierInitOptions[P_0].key;
			_positiveKey = Consts.commonMouseElementIdentifierInitOptions[P_0].key;
			_negativeKey = Consts.commonMouseElementIdentifierInitOptions[P_0].key;
		}
		_elementType = P_4;
		_compoundElementType = P_5;
	}

	[Obsolete("Used by UnifiedKeyboardSource. Left for plugin compatibility. Do not use.", false)]
	internal ControllerElementIdentifier(int P_0, string P_1, string P_2, string P_3, ControllerElementType P_4, bool P_5)
	{
		_id = P_0;
		_name = P_1;
		_positiveName = P_2;
		_negativeName = P_3;
		if (P_4 == ControllerElementType.Button && P_0 < Consts.keyboardKeyNames.Count && string.Equals(Consts.keyboardKeyNames[P_0], P_1, StringComparison.Ordinal))
		{
			_key = Consts.keyboardKeyKeys[P_0];
		}
		_elementType = P_4;
		_compoundElementType = CompoundControllerElementType.Axis2D;
	}

	internal ControllerElementIdentifier(ControllerElementIdentifier P_0, bool P_1, ControllerElementType P_2)
		: this(P_0)
	{
		_elementType = P_2;
	}

	public ControllerElementIdentifier Clone()
	{
		return new ControllerElementIdentifier(this);
	}

	public string GetDisplayName(ControllerElementType actualElementType, AxisRange axisRange)
	{
		return actualElementType switch
		{
			ControllerElementType.Axis => axisRange switch
			{
				AxisRange.Full => get_name(), 
				AxisRange.Positive => get_positiveName(), 
				AxisRange.Negative => get_negativeName(), 
				_ => throw new NotImplementedException(), 
			}, 
			ControllerElementType.Button => get_name(), 
			ControllerElementType.CompoundElement => get_name(), 
			_ => throw new NotImplementedException(), 
		};
	}

	public string GetDisplayName(AxisRange axisRange)
	{
		return GetDisplayName(_elementType, axisRange);
	}

	public object GetGlyph(ControllerElementType actualElementType, AxisRange axisRange)
	{
		return actualElementType switch
		{
			ControllerElementType.Axis => axisRange switch
			{
				AxisRange.Full => glyph, 
				AxisRange.Positive => positiveGlyph, 
				AxisRange.Negative => negativeGlyph, 
				_ => throw new NotImplementedException(), 
			}, 
			ControllerElementType.Button => glyph, 
			ControllerElementType.CompoundElement => glyph, 
			_ => throw new NotImplementedException(), 
		};
	}

	public object GetGlyph(AxisRange axisRange)
	{
		return GetGlyph(_elementType, axisRange);
	}

	public string GetFinalGlyphKey(ControllerElementType actualElementType, AxisRange axisRange)
	{
		return actualElementType switch
		{
			ControllerElementType.Axis => axisRange switch
			{
				AxisRange.Full => vzeubUDqxCRukYlVLQnOlAYAspmk(), 
				AxisRange.Positive => ZhUbQtTAIvIeORlojXtYWuGrFPqV(), 
				AxisRange.Negative => YirlWantJxEphsACvGXFiwDgCFpn(), 
				_ => throw new NotImplementedException(), 
			}, 
			ControllerElementType.Button => vzeubUDqxCRukYlVLQnOlAYAspmk(), 
			ControllerElementType.CompoundElement => vzeubUDqxCRukYlVLQnOlAYAspmk(), 
			_ => throw new NotImplementedException(), 
		};
	}

	public string GetFinalGlyphKey(AxisRange axisRange)
	{
		return GetFinalGlyphKey(_elementType, axisRange);
	}

	private void JaVNCreTldtDtJYwFnEOwEYYHSFY()
	{
		if (sBLWsojqxsouMZEfJsHJTsJZRJxQ)
		{
			throw new Exception("The object is marked readonly and you are trying to modify its values.");
		}
	}

	internal void FinishRuntimeSetup(DeviceLocalizationInfo deviceLocalizationInfo, ControllerType controllerType)
	{
		WGOrNiRewQeadcfhGNrFGHjjXDsZ = controllerType;
		ToElementNameLocalizerTypes(_elementType, _compoundElementType, out var resultElementType, out var resultCompoundElementType);
		int num = pNZrRihcucynHABMizyaEoIxhqLo.xlWNdmDDMBncSPcgqTPBqAHvYCtI(resultElementType, resultCompoundElementType);
		if (num > 0)
		{
			hfuiymDHuUdTwCSLUPXpvNQkzwvm = new List<WUaJosdFmWNrSVnbweyFXCiBmyAK>(num);
			for (int i = 0; i < num; i++)
			{
				hfuiymDHuUdTwCSLUPXpvNQkzwvm.Add(new WUaJosdFmWNrSVnbweyFXCiBmyAK());
			}
		}
		TEDxpGrigahBiZjGnfAHIoIBoJWq = deviceLocalizationInfo;
		urRCZSIdQNEdvBuuQJjWmXYNyugX = LQtXvKbJmTxxtcVMoxtOkVHKDdXk.SuPZAwgFReDyzWdTCZIXQIDFVAYc(this, OoOYGJinQKBHdoUGjyKzDnGlLzNS.owBEBEkfEavHlFYmFhYVcctGhNjY(controllerType), resultElementType, resultCompoundElementType, _id, deviceLocalizationInfo);
		dJhaYFwrygnhUyDNlcbQUnMlRSkx = ypQSALAIAHDQZQMeoLnrlsqLndiM.sjQBslWwArUXaNDBtIDJWeKSJrvv(this, OoOYGJinQKBHdoUGjyKzDnGlLzNS.owBEBEkfEavHlFYmFhYVcctGhNjY(controllerType), resultElementType, resultCompoundElementType, _id, deviceLocalizationInfo);
		if (_elementType == ControllerElementType.CompoundElement)
		{
			eYdAQBqfhHBdAkwLICYceqAeFaTKA = aAGDdhnGwWmFccaJOAZAKNefGyZgA.JbnVpSNdBYChGjKOaisXRcabQzmS(this, OoOYGJinQKBHdoUGjyKzDnGlLzNS.owBEBEkfEavHlFYmFhYVcctGhNjY(controllerType), resultElementType, resultCompoundElementType, _id, deviceLocalizationInfo);
			GOiCWBxcnYbWcXjZbxQANhVZzQuS = sfCgXsMoDxqWKNucNXLXeivVnZrj.weAoAKGIIYYaljTcGtOyGKcPJDIW(this, OoOYGJinQKBHdoUGjyKzDnGlLzNS.owBEBEkfEavHlFYmFhYVcctGhNjY(controllerType), resultElementType, resultCompoundElementType, _id, deviceLocalizationInfo);
		}
	}

	internal static void ToElementNameLocalizerTypes(ControllerElementType type, CompoundControllerElementType compoundType, out pNZrRihcucynHABMizyaEoIxhqLo.AhhliCUThpTCpJDayBicensRWslA resultElementType, out pNZrRihcucynHABMizyaEoIxhqLo.lGAwloROqSjUpJpzAfJNHgHgvWNeA resultCompoundElementType)
	{
		resultCompoundElementType = pNZrRihcucynHABMizyaEoIxhqLo.lGAwloROqSjUpJpzAfJNHgHgvWNeA.None;
		switch (type)
		{
		case ControllerElementType.Axis:
			resultElementType = pNZrRihcucynHABMizyaEoIxhqLo.AhhliCUThpTCpJDayBicensRWslA.Axis;
			break;
		case ControllerElementType.Button:
			resultElementType = pNZrRihcucynHABMizyaEoIxhqLo.AhhliCUThpTCpJDayBicensRWslA.Button;
			break;
		case ControllerElementType.CompoundElement:
			resultElementType = pNZrRihcucynHABMizyaEoIxhqLo.AhhliCUThpTCpJDayBicensRWslA.CompoundElement;
			switch (compoundType)
			{
			case CompoundControllerElementType.Axis2D:
				resultCompoundElementType = pNZrRihcucynHABMizyaEoIxhqLo.lGAwloROqSjUpJpzAfJNHgHgvWNeA.Axis2D;
				break;
			case CompoundControllerElementType.Hat:
				resultCompoundElementType = pNZrRihcucynHABMizyaEoIxhqLo.lGAwloROqSjUpJpzAfJNHgHgvWNeA.Hat;
				break;
			case CompoundControllerElementType.DPad:
				resultCompoundElementType = pNZrRihcucynHABMizyaEoIxhqLo.lGAwloROqSjUpJpzAfJNHgHgvWNeA.DPad;
				break;
			default:
				resultElementType = pNZrRihcucynHABMizyaEoIxhqLo.AhhliCUThpTCpJDayBicensRWslA.Unknown;
				break;
			}
			break;
		default:
			resultElementType = pNZrRihcucynHABMizyaEoIxhqLo.AhhliCUThpTCpJDayBicensRWslA.Unknown;
			break;
		}
	}

	private string Rewired_002EInternal_002ELocalization_002EINameLocalizerSource_002Eget_keyCategory()
	{
		return "controller/template";
	}

	private string Rewired_002EInternal_002ELocalization_002EINameLocalizerSource_002Eget_scriptingName()
	{
		return _name;
	}

	private string Rewired_002EInternal_002ELocalization_002EINameLocalizerSource_002Eget_nonLocalizedDescriptiveName()
	{
		return _name;
	}

	private void Rewired_002EInternal_002ELocalization_002EINameLocalizerSource_002Eset_nonLocalizedDescriptiveName(string value)
	{
		JaVNCreTldtDtJYwFnEOwEYYHSFY();
		_name = value;
	}

	private string Rewired_002EInternal_002ELocalization_002EIAxisNameLocalizerSource_002Eget_nonLocalizedPositiveDescriptiveName()
	{
		return _positiveName;
	}

	private void Rewired_002EInternal_002ELocalization_002EIAxisNameLocalizerSource_002Eset_nonLocalizedPositiveDescriptiveName(string value)
	{
		JaVNCreTldtDtJYwFnEOwEYYHSFY();
		_positiveName = value;
	}

	private string Rewired_002EInternal_002ELocalization_002EIAxisNameLocalizerSource_002Eget_nonLocalizedNegativeDescriptiveName()
	{
		return _negativeName;
	}

	private void Rewired_002EInternal_002ELocalization_002EIAxisNameLocalizerSource_002Eset_nonLocalizedNegativeDescriptiveName(string value)
	{
		JaVNCreTldtDtJYwFnEOwEYYHSFY();
		_negativeName = value;
	}

	private string Rewired_002EInternal_002ELocalization_002EINameLocalizerSource_002Eget_key()
	{
		return _key;
	}

	private string Rewired_002EInternal_002ELocalization_002EIAxisNameLocalizerSource_002Eget_positiveKey()
	{
		return _positiveKey;
	}

	private void Rewired_002EInternal_002ELocalization_002EIAxisNameLocalizerSource_002Eset_positiveKey(string value)
	{
		JaVNCreTldtDtJYwFnEOwEYYHSFY();
		_positiveKey = value;
	}

	private string Rewired_002EInternal_002ELocalization_002EIAxisNameLocalizerSource_002Eget_negativeKey()
	{
		return _negativeKey;
	}

	private void Rewired_002EInternal_002ELocalization_002EIAxisNameLocalizerSource_002Eset_negativeKey(string value)
	{
		JaVNCreTldtDtJYwFnEOwEYYHSFY();
		_negativeKey = value;
	}

	private int Rewired_002EInternal_002ELocalization_002EINameLocalizerSource_002Eget_autoGeneratedValueFlags()
	{
		return kuMVzZseaeqKrPyXecwrvDuyIaUG;
	}

	private void Rewired_002EInternal_002ELocalization_002EINameLocalizerSource_002Eset_autoGeneratedValueFlags(int value)
	{
		kuMVzZseaeqKrPyXecwrvDuyIaUG = value;
	}

	string RbTIGwoNbWAtnheIYRRWJRKnTqxqA.GetSpecialElementNonLocalizedDescriptiveName(int index)
	{
		if (hfuiymDHuUdTwCSLUPXpvNQkzwvm == null || index >= hfuiymDHuUdTwCSLUPXpvNQkzwvm.Count)
		{
			return null;
		}
		return hfuiymDHuUdTwCSLUPXpvNQkzwvm[index].dgvqtXdxROaCPgFiQxpjjgsmfFTi();
	}

	void RbTIGwoNbWAtnheIYRRWJRKnTqxqA.SetSpecialElementNonLocalizedDescriptiveName(int index, string value)
	{
		if (hfuiymDHuUdTwCSLUPXpvNQkzwvm != null && index < hfuiymDHuUdTwCSLUPXpvNQkzwvm.Count)
		{
			hfuiymDHuUdTwCSLUPXpvNQkzwvm[index].txqsWTOhIUtepcjUyHfUWiPOcYpX(value);
		}
	}

	string RbTIGwoNbWAtnheIYRRWJRKnTqxqA.GetSpecialElementKey(int index)
	{
		if (hfuiymDHuUdTwCSLUPXpvNQkzwvm == null || index >= hfuiymDHuUdTwCSLUPXpvNQkzwvm.Count)
		{
			return null;
		}
		return hfuiymDHuUdTwCSLUPXpvNQkzwvm[index].UCXvXrUZEXHQtNdgjRstMJxahBLA();
	}

	void RbTIGwoNbWAtnheIYRRWJRKnTqxqA.SetSpecialElementKey(int index, string value)
	{
		if (hfuiymDHuUdTwCSLUPXpvNQkzwvm != null && index < hfuiymDHuUdTwCSLUPXpvNQkzwvm.Count)
		{
			hfuiymDHuUdTwCSLUPXpvNQkzwvm[index].WFgcLuiWRLgfZLMuiJOTIjXACGdf(value);
		}
	}

	private string Rewired_002EInternal_002EGlyphs_002EIGlyphKeySource_002Eget_keyCategory()
	{
		return DIFNnnaZcXQLPYxsIZWTkUfgTNzj.fRyvXOfRcxBZOrSkMnHnHSXJkTXV(WGOrNiRewQeadcfhGNrFGHjjXDsZ);
	}

	private string Rewired_002EInternal_002EGlyphs_002EIGlyphKeySource_002Eget_key()
	{
		return _key;
	}

	private int Rewired_002EInternal_002EGlyphs_002EIGlyphKeySource_002Eget_autoGeneratedValueFlags()
	{
		return kuMVzZseaeqKrPyXecwrvDuyIaUG;
	}

	private void Rewired_002EInternal_002EGlyphs_002EIGlyphKeySource_002Eset_autoGeneratedValueFlags(int value)
	{
		kuMVzZseaeqKrPyXecwrvDuyIaUG = value;
	}

	private string Rewired_002EInternal_002EGlyphs_002EIAxisGlyphKeySource_002Eget_positiveKey()
	{
		return _positiveKey;
	}

	private void Rewired_002EInternal_002EGlyphs_002EIAxisGlyphKeySource_002Eset_positiveKey(string value)
	{
		JaVNCreTldtDtJYwFnEOwEYYHSFY();
		_positiveKey = value;
	}

	private string Rewired_002EInternal_002EGlyphs_002EIAxisGlyphKeySource_002Eget_negativeKey()
	{
		return _negativeKey;
	}

	private void Rewired_002EInternal_002EGlyphs_002EIAxisGlyphKeySource_002Eset_negativeKey(string value)
	{
		JaVNCreTldtDtJYwFnEOwEYYHSFY();
		_negativeKey = value;
	}

	string MdIaVdZIcZLvNyTteqNnkfKPAaJl.GetSpecialElementKey(int index)
	{
		if (hfuiymDHuUdTwCSLUPXpvNQkzwvm == null || index >= hfuiymDHuUdTwCSLUPXpvNQkzwvm.Count)
		{
			return null;
		}
		return hfuiymDHuUdTwCSLUPXpvNQkzwvm[index].UCXvXrUZEXHQtNdgjRstMJxahBLA();
	}

	void MdIaVdZIcZLvNyTteqNnkfKPAaJl.SetSpecialElementKey(int index, string value)
	{
		if (hfuiymDHuUdTwCSLUPXpvNQkzwvm != null && index < hfuiymDHuUdTwCSLUPXpvNQkzwvm.Count)
		{
			hfuiymDHuUdTwCSLUPXpvNQkzwvm[index].WFgcLuiWRLgfZLMuiJOTIjXACGdf(value);
		}
	}
}
