using System;
using System.Collections.Generic;
using Rewired.Data.Mapping;
using Rewired.Interfaces;
using Rewired.Internal.Glyphs;
using Rewired.Internal.Localization;
using UnityEngine;

namespace Rewired;

[Serializable]
[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
public class ControllerTemplateElementIdentifier : IControllerElementIdentifierCommon_Internal, IControllerTemplateElementIdentifier, XllMlgxhLwGZSIuGyCJYDhwKbYtab, JPyUCjMynlgXcSTGrAuSOGxEMeWJ, PJBELdSJSsLkgyPuksQJNLebsJqQ, lhkLrWnhlfHasNgQzbqhGosPUipt, RbTIGwoNbWAtnheIYRRWJRKnTqxqA, MdIaVdZIcZLvNyTteqNnkfKPAaJl
{
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	internal class TEfaDlhsVumXKovDSACxEsjVlPkeb
	{
		public int id;

		public string name;

		public string positiveName;

		public string negativeName;

		public string key;

		public string positiveKey;

		public string negativeKey;

		public ControllerTemplateElementType elementType;
	}

	internal sealed class yJSKCHSgVArGxOCqeFfXMNhxIytgA
	{
		[Serializable]
		private sealed class olzNRoHFwDIqBWQqFYNEDiNtLQAU
		{
			public static readonly olzNRoHFwDIqBWQqFYNEDiNtLQAU _003C_003E9 = new olzNRoHFwDIqBWQqFYNEDiNtLQAU();

			public static Func<ControllerTemplateElementIdentifier, ControllerTemplateElementIdentifier, bool> _003C_003E9__4_0;

			internal bool OHncMWLIpQErrTCtmhdvxQMYHEzE(ControllerTemplateElementIdentifier P_0, ControllerTemplateElementIdentifier P_1)
			{
				if (P_0 == null || P_1 == null)
				{
					return false;
				}
				if (P_0 != null && P_1 != null && P_0.get_id() == P_1.get_id() && P_0.get_elementType() == P_1.get_elementType())
				{
					return string.Equals(P_0.key, P_1.key, StringComparison.Ordinal);
				}
				return false;
			}
		}

		private static yJSKCHSgVArGxOCqeFfXMNhxIytgA fYvcdrUMaFUFBsfdHATMfnksXWPdA;

		private readonly global::lVvaRWFpPRDdIEUiIKNGBOwxeQgw<ControllerTemplateElementIdentifier> FjKrhbImdJFZrfWeJDYKjSTMqEyB;

		private static yJSKCHSgVArGxOCqeFfXMNhxIytgA idBtTcsqktJENsUYIKBhmUFcqYqB => nXLnpQOoZPLowblyfgxlJMSRmanC();

		private static yJSKCHSgVArGxOCqeFfXMNhxIytgA nXLnpQOoZPLowblyfgxlJMSRmanC()
		{
			if (fYvcdrUMaFUFBsfdHATMfnksXWPdA != null)
			{
				return fYvcdrUMaFUFBsfdHATMfnksXWPdA;
			}
			fYvcdrUMaFUFBsfdHATMfnksXWPdA = new yJSKCHSgVArGxOCqeFfXMNhxIytgA();
			fYvcdrUMaFUFBsfdHATMfnksXWPdA.sPrgZtaAsjMFShkbXglddqydABlGc();
			return fYvcdrUMaFUFBsfdHATMfnksXWPdA;
		}

		private yJSKCHSgVArGxOCqeFfXMNhxIytgA()
		{
			FjKrhbImdJFZrfWeJDYKjSTMqEyB = new global::lVvaRWFpPRDdIEUiIKNGBOwxeQgw<ControllerTemplateElementIdentifier>(olzNRoHFwDIqBWQqFYNEDiNtLQAU._003C_003E9.OHncMWLIpQErrTCtmhdvxQMYHEzE);
		}

		private void sPrgZtaAsjMFShkbXglddqydABlGc()
		{
			ReInput.ShutDownEvent += fYvcdrUMaFUFBsfdHATMfnksXWPdA.qdbbSgbJRPYuFcrqfmUuuKqJuSWh;
		}

		private void qdbbSgbJRPYuFcrqfmUuuKqJuSWh()
		{
			if (fYvcdrUMaFUFBsfdHATMfnksXWPdA == this)
			{
				fYvcdrUMaFUFBsfdHATMfnksXWPdA = null;
			}
			ReInput.ShutDownEvent -= qdbbSgbJRPYuFcrqfmUuuKqJuSWh;
		}

		public static ControllerTemplateElementIdentifier sArabQfStmVDmDXhlgUIlBlcFMxsA(DeviceLocalizationInfo P_0, ControllerTemplateElementIdentifier P_1)
		{
			return nXLnpQOoZPLowblyfgxlJMSRmanC().FjKrhbImdJFZrfWeJDYKjSTMqEyB.KfGfCFQYIBUUThUqDQAwAPjENAiG(P_0.hash, P_1);
		}

		public static bool ZIsORwQGXMDiwIvXegfyiggIPWPr(DeviceLocalizationInfo P_0, ControllerTemplateElementIdentifier P_1, out ControllerTemplateElementIdentifier P_2)
		{
			return nXLnpQOoZPLowblyfgxlJMSRmanC().FjKrhbImdJFZrfWeJDYKjSTMqEyB.elHbnypVRYAnmLgDxxneJfNHjcbfA(P_0.hash, P_1, out P_2);
		}

		public static void ANQPteaFQlpgNHJCzibqYdVCOdOn(DeviceLocalizationInfo P_0, ControllerTemplateElementIdentifier P_1)
		{
			nXLnpQOoZPLowblyfgxlJMSRmanC().FjKrhbImdJFZrfWeJDYKjSTMqEyB.RHHrLiuKFpjNWsGCNIVkgVcHmmlzA(P_0.hash, P_1);
		}
	}

	private class kAyAWXbcTkkaGjQLAhQxOyybPJkcb
	{
		[SerializeField]
		private string QDNQudDyeYHIWFyriWtPKKaplTCL;

		[SerializeField]
		private string pTssWodQYfVsjOPoRLwhzHEYhmah;

		public string InSWPpkVXkdeFpuAoHhwrmauJiwj
		{
			get
			{
				return TjPwsYjlxSApiHaFutMlvCqgfNSmA();
			}
			set
			{
				oViDktqweFugmRCArYYyOgYMNJUI(text);
			}
		}

		public string phCcDTjUiWJOiuOxBgPwHAKvTdxXA
		{
			get
			{
				return iXCrmSYnOFHhbCmVLluroslIhtNWA();
			}
			set
			{
				kEMCtnTvssvkmFULLTWQjduzBZIA(text);
			}
		}

		public string TjPwsYjlxSApiHaFutMlvCqgfNSmA()
		{
			return QDNQudDyeYHIWFyriWtPKKaplTCL;
		}

		public void oViDktqweFugmRCArYYyOgYMNJUI(string P_0)
		{
			QDNQudDyeYHIWFyriWtPKKaplTCL = P_0;
		}

		public string iXCrmSYnOFHhbCmVLluroslIhtNWA()
		{
			return pTssWodQYfVsjOPoRLwhzHEYhmah;
		}

		public void kEMCtnTvssvkmFULLTWQjduzBZIA(string P_0)
		{
			pTssWodQYfVsjOPoRLwhzHEYhmah = P_0;
		}

		public kAyAWXbcTkkaGjQLAhQxOyybPJkcb()
		{
		}

		public kAyAWXbcTkkaGjQLAhQxOyybPJkcb(kAyAWXbcTkkaGjQLAhQxOyybPJkcb P_0)
		{
			QDNQudDyeYHIWFyriWtPKKaplTCL = P_0.QDNQudDyeYHIWFyriWtPKKaplTCL;
			pTssWodQYfVsjOPoRLwhzHEYhmah = P_0.pTssWodQYfVsjOPoRLwhzHEYhmah;
		}
	}

	private const string SQEmkGhSazXVfEPEcIbPkaNaBkIi = "controller/template";

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
	public string _key;

	[SerializeField]
	[CustomObfuscation(rename = false)]
	public string _positiveKey;

	[SerializeField]
	[CustomObfuscation(rename = false)]
	public string _negativeKey;

	[SerializeField]
	[CustomObfuscation(rename = false)]
	private ControllerTemplateElementType _elementType;

	[NonSerialized]
	private LQtXvKbJmTxxtcVMoxtOkVHKDdXk gJmquWWoDgyvgiaAwEOJdEuYHaVzA;

	[NonSerialized]
	private aAGDdhnGwWmFccaJOAZAKNefGyZgA yCkFnwTqgqflGysmuAoPwbkLRQPj;

	[NonSerialized]
	private ypQSALAIAHDQZQMeoLnrlsqLndiM irRfoYansPGDCAFYLvFvTxQdDdfb;

	[NonSerialized]
	private sfCgXsMoDxqWKNucNXLXeivVnZrj VCKraZhjRFFSkIAaHIulpcVZGFWD;

	[NonSerialized]
	private DeviceLocalizationInfo MTTeQTJWAOOqWUkrgeLOiZjbDKrs;

	[NonSerialized]
	private int ZRrldOsPeTASmAhxHFXBPiEDFdtK;

	[NonSerialized]
	private List<kAyAWXbcTkkaGjQLAhQxOyybPJkcb> eFBhGQXSHjWiNdMqwfvsrjdjFmTO;

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

	ControllerTemplateElementType IControllerTemplateElementIdentifier.elementType => get_elementType();

	internal virtual bool useEditorElementTypeOverride => false;

	internal virtual ControllerElementType editorElementTypeOverride
	{
		get
		{
			throw new NotImplementedException();
		}
	}

	public object glyph
	{
		get
		{
			if (!ReInput.isReady || irRfoYansPGDCAFYLvFvTxQdDdfb == null || !GlyphManager.isEnabled)
			{
				return null;
			}
			return irRfoYansPGDCAFYLvFvTxQdDdfb.kGpzldgkfThCvAoiWaIMVZlaEKuW();
		}
	}

	public object positiveGlyph
	{
		get
		{
			if (!ReInput.isReady || irRfoYansPGDCAFYLvFvTxQdDdfb == null || !GlyphManager.isEnabled)
			{
				return null;
			}
			return irRfoYansPGDCAFYLvFvTxQdDdfb.RSfMQptZQMzyPBdAWCLqWVwnoTvB();
		}
	}

	public object negativeGlyph
	{
		get
		{
			if (!ReInput.isReady || irRfoYansPGDCAFYLvFvTxQdDdfb == null || !GlyphManager.isEnabled)
			{
				return null;
			}
			return irRfoYansPGDCAFYLvFvTxQdDdfb.KDXTtdSwDJHFhXTlpOXEspYximXw();
		}
	}

	private string finalGlyphKey => hOGZuJfqHiPQBuxKqztGICWakiwl();

	private string finalPositiveGlyphKey => XRuzfQNqTlRCdzeooXFfurWcbEHU();

	private string finalNegativeGlyphKey => uIQPHpButxfSDrrriwFTcqjnnACM();

	internal string nonLocalizedName
	{
		get
		{
			return _name;
		}
		set
		{
			_name = value;
			if (ReInput.isReady && gJmquWWoDgyvgiaAwEOJdEuYHaVzA != null)
			{
				gJmquWWoDgyvgiaAwEOJdEuYHaVzA.qFSeqqVPfIqnwwFRvTgDucKqgogy();
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
			if (ReInput.isReady && gJmquWWoDgyvgiaAwEOJdEuYHaVzA != null)
			{
				gJmquWWoDgyvgiaAwEOJdEuYHaVzA.XNpaTfyhAhNTxHJiXVjNbdVbSPHt();
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
			if (ReInput.isReady && gJmquWWoDgyvgiaAwEOJdEuYHaVzA != null)
			{
				gJmquWWoDgyvgiaAwEOJdEuYHaVzA.qrcDCChoJyLkCoCgPOHAVlSlEEoib();
			}
		}
	}

	public string key => _key;

	public string positiveKey => _positiveKey;

	public string negativeKey => _negativeKey;

	string IControllerElementIdentifierCommon_Internal.nonLocalizedName => nonLocalizedName;

	string IControllerElementIdentifierCommon_Internal.nonLocalizedPositiveName => nonLocalizedPositiveName;

	string IControllerElementIdentifierCommon_Internal.nonLocalizedNegativeName => nonLocalizedNegativeName;

	bool IControllerElementIdentifierCommon_Internal.isNonLocalizedPositiveNameAutoGenerated => (ZRrldOsPeTASmAhxHFXBPiEDFdtK & 2) != 0;

	bool IControllerElementIdentifierCommon_Internal.isNonLocalizedNegativeNameAutoGenerated => (ZRrldOsPeTASmAhxHFXBPiEDFdtK & 4) != 0;

	bool IControllerElementIdentifierCommon_Internal.isPositiveKeyAutoGenerated => (ZRrldOsPeTASmAhxHFXBPiEDFdtK & 8) != 0;

	bool IControllerElementIdentifierCommon_Internal.isNegativeKeyAutoGenerated => (ZRrldOsPeTASmAhxHFXBPiEDFdtK & 0x10) != 0;

	string IControllerElementIdentifierCommon_Internal.key => _key;

	string IControllerElementIdentifierCommon_Internal.positiveKey => _positiveKey;

	string IControllerElementIdentifierCommon_Internal.negativeKey => _negativeKey;

	DeviceLocalizationInfo IControllerElementIdentifierCommon_Internal.deviceLocalizationInfo => MTTeQTJWAOOqWUkrgeLOiZjbDKrs;

	object IControllerElementIdentifierCommon_Internal.elementType => _elementType;

	bool IControllerElementIdentifierCommon_Internal.useEditorElementTypeOverride => useEditorElementTypeOverride;

	ControllerElementType IControllerElementIdentifierCommon_Internal.editorElementTypeOverride => editorElementTypeOverride;

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
		if (!ReInput.isReady || gJmquWWoDgyvgiaAwEOJdEuYHaVzA == null || !LocalizationManager.isEnabled)
		{
			return _name;
		}
		return gJmquWWoDgyvgiaAwEOJdEuYHaVzA.aLsidTWLDaQPOPmyxGbWHeMTGfoEA();
	}

	internal void set_name(string value)
	{
		nonLocalizedName = value;
	}

	public string get_positiveName()
	{
		if (!ReInput.isReady || gJmquWWoDgyvgiaAwEOJdEuYHaVzA == null || !LocalizationManager.isEnabled)
		{
			return _positiveName;
		}
		return gJmquWWoDgyvgiaAwEOJdEuYHaVzA.lRFaUAhYFCkkNqWgcrhJwDnyCHJXA();
	}

	internal void set_positiveName(string value)
	{
		nonLocalizedPositiveName = value;
	}

	public string get_negativeName()
	{
		if (!ReInput.isReady || gJmquWWoDgyvgiaAwEOJdEuYHaVzA == null || !LocalizationManager.isEnabled)
		{
			return _negativeName;
		}
		return gJmquWWoDgyvgiaAwEOJdEuYHaVzA.vPzaewrFBxaCLxupXxPEsOvRTyqq();
	}

	internal void set_negativeName(string value)
	{
		nonLocalizedNegativeName = value;
	}

	internal string GetCompoundElementSpecialName(int index)
	{
		if (!ReInput.isReady || !LocalizationManager.isEnabled || eFBhGQXSHjWiNdMqwfvsrjdjFmTO == null || yCkFnwTqgqflGysmuAoPwbkLRQPj == null)
		{
			return string.Empty;
		}
		return yCkFnwTqgqflGysmuAoPwbkLRQPj.atdnnvxDKQqIjPIcaDemULmYXVTC(index);
	}

	public ControllerTemplateElementType get_elementType()
	{
		return _elementType;
	}

	private string hOGZuJfqHiPQBuxKqztGICWakiwl()
	{
		if (!ReInput.isReady || irRfoYansPGDCAFYLvFvTxQdDdfb == null || !GlyphManager.isEnabled)
		{
			return null;
		}
		return irRfoYansPGDCAFYLvFvTxQdDdfb.QmGGcKRfXciKdFBRaKFZnfezonaU();
	}

	private string XRuzfQNqTlRCdzeooXFfurWcbEHU()
	{
		if (!ReInput.isReady || irRfoYansPGDCAFYLvFvTxQdDdfb == null || !GlyphManager.isEnabled)
		{
			return null;
		}
		return irRfoYansPGDCAFYLvFvTxQdDdfb.trTJDAavIVtiJPuukcZYOhCoSsBu();
	}

	private string uIQPHpButxfSDrrriwFTcqjnnACM()
	{
		if (!ReInput.isReady || irRfoYansPGDCAFYLvFvTxQdDdfb == null || !GlyphManager.isEnabled)
		{
			return null;
		}
		return irRfoYansPGDCAFYLvFvTxQdDdfb.FUKZBOxUtkBXFQAmWgCXGwqmbFouA();
	}

	internal object GetCompoundElementSpecialGlyph(int index)
	{
		if (!ReInput.isReady || !GlyphManager.isEnabled || eFBhGQXSHjWiNdMqwfvsrjdjFmTO == null || VCKraZhjRFFSkIAaHIulpcVZGFWD == null)
		{
			return null;
		}
		return VCKraZhjRFFSkIAaHIulpcVZGFWD.lXzeUUMmjVRbMviTqsVwkONaKRvI(index);
	}

	string IControllerElementIdentifierCommon_Internal.GetSpecialElementNonLocalizedName(int index)
	{
		if (eFBhGQXSHjWiNdMqwfvsrjdjFmTO == null || (uint)index >= (uint)eFBhGQXSHjWiNdMqwfvsrjdjFmTO.Count)
		{
			return null;
		}
		return eFBhGQXSHjWiNdMqwfvsrjdjFmTO[index].iXCrmSYnOFHhbCmVLluroslIhtNWA();
	}

	string IControllerElementIdentifierCommon_Internal.GetSpecialElementKey(int index)
	{
		if (eFBhGQXSHjWiNdMqwfvsrjdjFmTO == null || (uint)index >= (uint)eFBhGQXSHjWiNdMqwfvsrjdjFmTO.Count)
		{
			return null;
		}
		return eFBhGQXSHjWiNdMqwfvsrjdjFmTO[index].TjPwsYjlxSApiHaFutMlvCqgfNSmA();
	}

	public ControllerTemplateElementIdentifier()
	{
	}

	public ControllerTemplateElementIdentifier(ControllerTemplateElementIdentifier P_0)
	{
		_id = P_0._id;
		_name = P_0._name;
		_positiveName = P_0._positiveName;
		_negativeName = P_0._negativeName;
		_key = P_0._key;
		_positiveKey = P_0._positiveKey;
		_negativeKey = P_0._negativeKey;
		_elementType = P_0._elementType;
		if (P_0.eFBhGQXSHjWiNdMqwfvsrjdjFmTO != null)
		{
			int count = P_0.eFBhGQXSHjWiNdMqwfvsrjdjFmTO.Count;
			eFBhGQXSHjWiNdMqwfvsrjdjFmTO = new List<kAyAWXbcTkkaGjQLAhQxOyybPJkcb>(count);
			for (int i = 0; i < count; i++)
			{
				if (P_0.eFBhGQXSHjWiNdMqwfvsrjdjFmTO[i] != null)
				{
					eFBhGQXSHjWiNdMqwfvsrjdjFmTO.Add(new kAyAWXbcTkkaGjQLAhQxOyybPJkcb(P_0.eFBhGQXSHjWiNdMqwfvsrjdjFmTO[i]));
				}
			}
		}
		ZRrldOsPeTASmAhxHFXBPiEDFdtK = P_0.ZRrldOsPeTASmAhxHFXBPiEDFdtK;
	}

	internal ControllerTemplateElementIdentifier(TEfaDlhsVumXKovDSACxEsjVlPkeb P_0)
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
	}

	internal ControllerTemplateElementIdentifier(ControllerTemplateElementIdentifier P_0, ControllerTemplateElementType P_1, bool P_2)
		: this(P_0)
	{
		_elementType = P_1;
	}

	public virtual ControllerTemplateElementIdentifier Clone()
	{
		return new ControllerTemplateElementIdentifier(this);
	}

	public string GetDisplayName(AxisRange axisRange)
	{
		return _elementType switch
		{
			ControllerTemplateElementType.Axis => axisRange switch
			{
				AxisRange.Full => get_name(), 
				AxisRange.Positive => get_positiveName(), 
				AxisRange.Negative => get_negativeName(), 
				_ => throw new NotImplementedException(), 
			}, 
			_ => get_name(), 
		};
	}

	public object GetGlyph(AxisRange axisRange)
	{
		return _elementType switch
		{
			ControllerTemplateElementType.Axis => axisRange switch
			{
				AxisRange.Full => glyph, 
				AxisRange.Positive => positiveGlyph, 
				AxisRange.Negative => negativeGlyph, 
				_ => throw new NotImplementedException(), 
			}, 
			_ => glyph, 
		};
	}

	public string GetFinalGlyphKey(AxisRange axisRange)
	{
		return _elementType switch
		{
			ControllerTemplateElementType.Axis => axisRange switch
			{
				AxisRange.Full => hOGZuJfqHiPQBuxKqztGICWakiwl(), 
				AxisRange.Positive => XRuzfQNqTlRCdzeooXFfurWcbEHU(), 
				AxisRange.Negative => uIQPHpButxfSDrrriwFTcqjnnACM(), 
				_ => throw new NotImplementedException(), 
			}, 
			_ => hOGZuJfqHiPQBuxKqztGICWakiwl(), 
		};
	}

	internal ControllerElementIdentifier ToControllerElementIdentifier(IHardwareControllerMap_Internal hardwareControllerMap)
	{
		ControllerElementIdentifier controllerElementIdentifier = new ControllerElementIdentifier(new ControllerElementIdentifier.ThaQNPmIsUvtgdNurUEQZTaCLDVq
		{
			id = _id,
			name = _name,
			positiveName = _positiveName,
			negativeName = _negativeName,
			key = _key,
			positiveKey = _positiveKey,
			negativeKey = _negativeKey,
			elementType = IyPmashUlRgIygDiHFyDZHZmauql.VngApvZSxBENhafXxFbkGfCtKhbeb(_elementType),
			compoundElementType = CompoundControllerElementType.Axis2D
		});
		if (ReInput.isReady && MTTeQTJWAOOqWUkrgeLOiZjbDKrs != null && hardwareControllerMap != null)
		{
			DeviceLocalizationInfo deviceLocalizationInfo = new DeviceLocalizationInfo(hardwareControllerMap.controllerType, false, hardwareControllerMap.typeGuid, new List<string> { hardwareControllerMap.typeKey }, null);
			deviceLocalizationInfo.FinishRuntimeSetup();
			controllerElementIdentifier.FinishRuntimeSetup(deviceLocalizationInfo, hardwareControllerMap.controllerType);
		}
		return controllerElementIdentifier;
	}

	internal void FinishRuntimeSetup(DeviceLocalizationInfo deviceLocalizationInfo)
	{
		TYLDyKGyTlagrhCUAmhcAekQTluFB(_elementType, out var ahhliCUThpTCpJDayBicensRWslA, out var lGAwloROqSjUpJpzAfJNHgHgvWNeA);
		int num = pNZrRihcucynHABMizyaEoIxhqLo.xlWNdmDDMBncSPcgqTPBqAHvYCtI(ahhliCUThpTCpJDayBicensRWslA, lGAwloROqSjUpJpzAfJNHgHgvWNeA);
		if (num > 0)
		{
			eFBhGQXSHjWiNdMqwfvsrjdjFmTO = new List<kAyAWXbcTkkaGjQLAhQxOyybPJkcb>(num);
			for (int i = 0; i < num; i++)
			{
				eFBhGQXSHjWiNdMqwfvsrjdjFmTO.Add(new kAyAWXbcTkkaGjQLAhQxOyybPJkcb());
			}
		}
		MTTeQTJWAOOqWUkrgeLOiZjbDKrs = deviceLocalizationInfo;
		if (gJmquWWoDgyvgiaAwEOJdEuYHaVzA == null)
		{
			gJmquWWoDgyvgiaAwEOJdEuYHaVzA = LQtXvKbJmTxxtcVMoxtOkVHKDdXk.SuPZAwgFReDyzWdTCZIXQIDFVAYc(this, EIJabuCGuIkogTgNjoJeTXIEuNcy.ControllerTemplate, ahhliCUThpTCpJDayBicensRWslA, lGAwloROqSjUpJpzAfJNHgHgvWNeA, _id, deviceLocalizationInfo);
		}
		if (irRfoYansPGDCAFYLvFvTxQdDdfb == null)
		{
			irRfoYansPGDCAFYLvFvTxQdDdfb = ypQSALAIAHDQZQMeoLnrlsqLndiM.sjQBslWwArUXaNDBtIDJWeKSJrvv(this, EIJabuCGuIkogTgNjoJeTXIEuNcy.ControllerTemplate, ahhliCUThpTCpJDayBicensRWslA, lGAwloROqSjUpJpzAfJNHgHgvWNeA, _id, deviceLocalizationInfo);
		}
		if (ahhliCUThpTCpJDayBicensRWslA == pNZrRihcucynHABMizyaEoIxhqLo.AhhliCUThpTCpJDayBicensRWslA.CompoundElement)
		{
			yCkFnwTqgqflGysmuAoPwbkLRQPj = aAGDdhnGwWmFccaJOAZAKNefGyZgA.JbnVpSNdBYChGjKOaisXRcabQzmS(this, EIJabuCGuIkogTgNjoJeTXIEuNcy.ControllerTemplate, ahhliCUThpTCpJDayBicensRWslA, lGAwloROqSjUpJpzAfJNHgHgvWNeA, _id, deviceLocalizationInfo);
			VCKraZhjRFFSkIAaHIulpcVZGFWD = sfCgXsMoDxqWKNucNXLXeivVnZrj.weAoAKGIIYYaljTcGtOyGKcPJDIW(this, EIJabuCGuIkogTgNjoJeTXIEuNcy.ControllerTemplate, ahhliCUThpTCpJDayBicensRWslA, lGAwloROqSjUpJpzAfJNHgHgvWNeA, _id, deviceLocalizationInfo);
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
		_name = value;
	}

	private string Rewired_002EInternal_002ELocalization_002EIAxisNameLocalizerSource_002Eget_nonLocalizedPositiveDescriptiveName()
	{
		return _positiveName;
	}

	private void Rewired_002EInternal_002ELocalization_002EIAxisNameLocalizerSource_002Eset_nonLocalizedPositiveDescriptiveName(string value)
	{
		_positiveName = value;
	}

	private string Rewired_002EInternal_002ELocalization_002EIAxisNameLocalizerSource_002Eget_nonLocalizedNegativeDescriptiveName()
	{
		return _negativeName;
	}

	private void Rewired_002EInternal_002ELocalization_002EIAxisNameLocalizerSource_002Eset_nonLocalizedNegativeDescriptiveName(string value)
	{
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
		_positiveKey = value;
	}

	private string Rewired_002EInternal_002ELocalization_002EIAxisNameLocalizerSource_002Eget_negativeKey()
	{
		return _negativeKey;
	}

	private void Rewired_002EInternal_002ELocalization_002EIAxisNameLocalizerSource_002Eset_negativeKey(string value)
	{
		_negativeKey = value;
	}

	private int Rewired_002EInternal_002ELocalization_002EINameLocalizerSource_002Eget_autoGeneratedValueFlags()
	{
		return ZRrldOsPeTASmAhxHFXBPiEDFdtK;
	}

	private void Rewired_002EInternal_002ELocalization_002EINameLocalizerSource_002Eset_autoGeneratedValueFlags(int value)
	{
		ZRrldOsPeTASmAhxHFXBPiEDFdtK = value;
	}

	string RbTIGwoNbWAtnheIYRRWJRKnTqxqA.GetSpecialElementNonLocalizedDescriptiveName(int index)
	{
		if (eFBhGQXSHjWiNdMqwfvsrjdjFmTO == null || index >= eFBhGQXSHjWiNdMqwfvsrjdjFmTO.Count)
		{
			return null;
		}
		return eFBhGQXSHjWiNdMqwfvsrjdjFmTO[index].iXCrmSYnOFHhbCmVLluroslIhtNWA();
	}

	void RbTIGwoNbWAtnheIYRRWJRKnTqxqA.SetSpecialElementNonLocalizedDescriptiveName(int index, string value)
	{
		if (eFBhGQXSHjWiNdMqwfvsrjdjFmTO != null && index < eFBhGQXSHjWiNdMqwfvsrjdjFmTO.Count)
		{
			eFBhGQXSHjWiNdMqwfvsrjdjFmTO[index].kEMCtnTvssvkmFULLTWQjduzBZIA(value);
		}
	}

	string RbTIGwoNbWAtnheIYRRWJRKnTqxqA.GetSpecialElementKey(int index)
	{
		if (eFBhGQXSHjWiNdMqwfvsrjdjFmTO == null || index >= eFBhGQXSHjWiNdMqwfvsrjdjFmTO.Count)
		{
			return null;
		}
		return eFBhGQXSHjWiNdMqwfvsrjdjFmTO[index].TjPwsYjlxSApiHaFutMlvCqgfNSmA();
	}

	void RbTIGwoNbWAtnheIYRRWJRKnTqxqA.SetSpecialElementKey(int index, string value)
	{
		if (eFBhGQXSHjWiNdMqwfvsrjdjFmTO != null && index < eFBhGQXSHjWiNdMqwfvsrjdjFmTO.Count)
		{
			eFBhGQXSHjWiNdMqwfvsrjdjFmTO[index].oViDktqweFugmRCArYYyOgYMNJUI(value);
		}
	}

	private string Rewired_002EInternal_002EGlyphs_002EIGlyphKeySource_002Eget_keyCategory()
	{
		return "controller/template";
	}

	private string Rewired_002EInternal_002EGlyphs_002EIGlyphKeySource_002Eget_key()
	{
		return _key;
	}

	private int Rewired_002EInternal_002EGlyphs_002EIGlyphKeySource_002Eget_autoGeneratedValueFlags()
	{
		return ZRrldOsPeTASmAhxHFXBPiEDFdtK;
	}

	private void Rewired_002EInternal_002EGlyphs_002EIGlyphKeySource_002Eset_autoGeneratedValueFlags(int value)
	{
		ZRrldOsPeTASmAhxHFXBPiEDFdtK = value;
	}

	private string Rewired_002EInternal_002EGlyphs_002EIAxisGlyphKeySource_002Eget_positiveKey()
	{
		return _positiveKey;
	}

	private void Rewired_002EInternal_002EGlyphs_002EIAxisGlyphKeySource_002Eset_positiveKey(string value)
	{
		_positiveKey = value;
	}

	private string Rewired_002EInternal_002EGlyphs_002EIAxisGlyphKeySource_002Eget_negativeKey()
	{
		return _negativeKey;
	}

	private void Rewired_002EInternal_002EGlyphs_002EIAxisGlyphKeySource_002Eset_negativeKey(string value)
	{
		_negativeKey = value;
	}

	string MdIaVdZIcZLvNyTteqNnkfKPAaJl.GetSpecialElementKey(int index)
	{
		if (eFBhGQXSHjWiNdMqwfvsrjdjFmTO == null || index >= eFBhGQXSHjWiNdMqwfvsrjdjFmTO.Count)
		{
			return null;
		}
		return eFBhGQXSHjWiNdMqwfvsrjdjFmTO[index].TjPwsYjlxSApiHaFutMlvCqgfNSmA();
	}

	void MdIaVdZIcZLvNyTteqNnkfKPAaJl.SetSpecialElementKey(int index, string value)
	{
		if (eFBhGQXSHjWiNdMqwfvsrjdjFmTO != null && index < eFBhGQXSHjWiNdMqwfvsrjdjFmTO.Count)
		{
			eFBhGQXSHjWiNdMqwfvsrjdjFmTO[index].oViDktqweFugmRCArYYyOgYMNJUI(value);
		}
	}

	private static void TYLDyKGyTlagrhCUAmhcAekQTluFB(ControllerTemplateElementType P_0, out pNZrRihcucynHABMizyaEoIxhqLo.AhhliCUThpTCpJDayBicensRWslA P_1, out pNZrRihcucynHABMizyaEoIxhqLo.lGAwloROqSjUpJpzAfJNHgHgvWNeA P_2)
	{
		P_2 = pNZrRihcucynHABMizyaEoIxhqLo.lGAwloROqSjUpJpzAfJNHgHgvWNeA.None;
		switch (P_0)
		{
		case ControllerTemplateElementType.Axis:
			P_1 = pNZrRihcucynHABMizyaEoIxhqLo.AhhliCUThpTCpJDayBicensRWslA.Axis;
			break;
		case ControllerTemplateElementType.Button:
			P_1 = pNZrRihcucynHABMizyaEoIxhqLo.AhhliCUThpTCpJDayBicensRWslA.Button;
			break;
		case ControllerTemplateElementType.Hat:
			P_1 = pNZrRihcucynHABMizyaEoIxhqLo.AhhliCUThpTCpJDayBicensRWslA.CompoundElement;
			P_2 = pNZrRihcucynHABMizyaEoIxhqLo.lGAwloROqSjUpJpzAfJNHgHgvWNeA.Hat;
			break;
		case ControllerTemplateElementType.DPad:
			P_1 = pNZrRihcucynHABMizyaEoIxhqLo.AhhliCUThpTCpJDayBicensRWslA.CompoundElement;
			P_2 = pNZrRihcucynHABMizyaEoIxhqLo.lGAwloROqSjUpJpzAfJNHgHgvWNeA.DPad;
			break;
		case ControllerTemplateElementType.ThumbStick:
			P_1 = pNZrRihcucynHABMizyaEoIxhqLo.AhhliCUThpTCpJDayBicensRWslA.CompoundElement;
			break;
		case ControllerTemplateElementType.Yoke:
			P_1 = pNZrRihcucynHABMizyaEoIxhqLo.AhhliCUThpTCpJDayBicensRWslA.Unknown;
			break;
		case ControllerTemplateElementType.Throttle:
			P_1 = pNZrRihcucynHABMizyaEoIxhqLo.AhhliCUThpTCpJDayBicensRWslA.Unknown;
			break;
		case ControllerTemplateElementType.Stick:
			P_1 = pNZrRihcucynHABMizyaEoIxhqLo.AhhliCUThpTCpJDayBicensRWslA.CompoundElement;
			P_2 = pNZrRihcucynHABMizyaEoIxhqLo.lGAwloROqSjUpJpzAfJNHgHgvWNeA.Stick;
			break;
		case ControllerTemplateElementType.Stick6D:
			P_1 = pNZrRihcucynHABMizyaEoIxhqLo.AhhliCUThpTCpJDayBicensRWslA.CompoundElement;
			P_2 = pNZrRihcucynHABMizyaEoIxhqLo.lGAwloROqSjUpJpzAfJNHgHgvWNeA.Stick6D;
			break;
		default:
			P_1 = pNZrRihcucynHABMizyaEoIxhqLo.AhhliCUThpTCpJDayBicensRWslA.Unknown;
			break;
		}
	}
}
