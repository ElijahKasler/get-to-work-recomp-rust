using System;
using Rewired.Internal.Localization;
using UnityEngine;

namespace Rewired;

[Serializable]
public sealed class InputAction : XllMlgxhLwGZSIuGyCJYDhwKbYtab, JPyUCjMynlgXcSTGrAuSOGxEMeWJ
{
	private const string keyCategory = "action";

	[SerializeField]
	[CustomObfuscation(rename = false)]
	private int _id;

	[SerializeField]
	[CustomObfuscation(rename = false)]
	private string _name;

	[SerializeField]
	[CustomObfuscation(rename = false)]
	private InputActionType _type;

	[SerializeField]
	[CustomObfuscation(rename = false)]
	private string _descriptiveName;

	[SerializeField]
	[CustomObfuscation(rename = false)]
	private string _positiveDescriptiveName;

	[SerializeField]
	[CustomObfuscation(rename = false)]
	private string _negativeDescriptiveName;

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
	private int _behaviorId;

	[SerializeField]
	[CustomObfuscation(rename = false)]
	private bool _userAssignable;

	[SerializeField]
	[CustomObfuscation(rename = false)]
	private int _categoryId;

	[NonSerialized]
	private PKRdDUAstMBavDtLUceRhHVgLLzOc huFZyEKtFdJyTmYQMmRqlgAXskwv;

	[NonSerialized]
	private int mBgTyWAycpBARKLyeTvJWqNAnKhn;

	public int id
	{
		get
		{
			return _id;
		}
		internal set
		{
			AMAIZfInlMSYYmanVNuUfsJDsYjb(num);
		}
	}

	public string name
	{
		get
		{
			return _name;
		}
		internal set
		{
			WUHHsrTAElkhpWiNqDYhmjbqOeWL(text);
		}
	}

	public InputActionType type
	{
		get
		{
			return _type;
		}
		internal set
		{
			UhsLadNucvFrEnUMjLPcGIOTrRGJ(inputActionType);
		}
	}

	public string descriptiveName
	{
		get
		{
			if (!ReInput.isReady || !LocalizationManager.isEnabled || huFZyEKtFdJyTmYQMmRqlgAXskwv == null)
			{
				return _descriptiveName;
			}
			return huFZyEKtFdJyTmYQMmRqlgAXskwv.aLsidTWLDaQPOPmyxGbWHeMTGfoEA();
		}
		internal set
		{
			vOyOrTASWGfRrTkMPhSeLaBoARuhA(text);
		}
	}

	public string positiveDescriptiveName
	{
		get
		{
			if (!ReInput.isReady || !LocalizationManager.isEnabled || huFZyEKtFdJyTmYQMmRqlgAXskwv == null)
			{
				return _positiveDescriptiveName;
			}
			return huFZyEKtFdJyTmYQMmRqlgAXskwv.lRFaUAhYFCkkNqWgcrhJwDnyCHJXA();
		}
		internal set
		{
			czxCNFIZMOKPvRKPMOMLwLpcnTRG(text);
		}
	}

	public string negativeDescriptiveName
	{
		get
		{
			if (!ReInput.isReady || !LocalizationManager.isEnabled || huFZyEKtFdJyTmYQMmRqlgAXskwv == null)
			{
				return _negativeDescriptiveName;
			}
			return huFZyEKtFdJyTmYQMmRqlgAXskwv.vPzaewrFBxaCLxupXxPEsOvRTyqq();
		}
		internal set
		{
			mEUinnimIdZLvnQgZuDCNKsYKliH(text);
		}
	}

	public int behaviorId
	{
		get
		{
			return _behaviorId;
		}
		internal set
		{
			PiUFsDNerYNrnOuphGYyaUCZBwQk(num);
		}
	}

	public int categoryId
	{
		get
		{
			return _categoryId;
		}
		internal set
		{
			lqxUlhffEKUJrRHeHYZDDZrcIOVq(num);
		}
	}

	public bool userAssignable
	{
		get
		{
			return _userAssignable;
		}
		internal set
		{
			RJRENmwlYMGUXgUeHdFiLvedFNsJ(flag);
		}
	}

	[CustomObfuscation(rename = false)]
	internal string key
	{
		get
		{
			return _key;
		}
		set
		{
			_key = value;
			if (ReInput.isReady && huFZyEKtFdJyTmYQMmRqlgAXskwv != null)
			{
				huFZyEKtFdJyTmYQMmRqlgAXskwv.LeEGnLJDYLmYFSwWWbXCbfDSXxTbA();
			}
		}
	}

	[CustomObfuscation(rename = false)]
	internal string positiveKey
	{
		get
		{
			return _positiveKey;
		}
		set
		{
			_positiveKey = value;
			if (ReInput.isReady && huFZyEKtFdJyTmYQMmRqlgAXskwv != null)
			{
				huFZyEKtFdJyTmYQMmRqlgAXskwv.PPGUFJUjcOnQNVDkeQiJhxbWeQow();
			}
		}
	}

	[CustomObfuscation(rename = false)]
	internal string negativeKey
	{
		get
		{
			return _negativeKey;
		}
		set
		{
			_negativeKey = value;
			if (ReInput.isReady && huFZyEKtFdJyTmYQMmRqlgAXskwv != null)
			{
				huFZyEKtFdJyTmYQMmRqlgAXskwv.yhSxfMCqvFILHdJAJfzOuLdtJosS();
			}
		}
	}

	[CustomObfuscation(rename = false)]
	internal string nonLocalizedDescriptiveName
	{
		get
		{
			return _descriptiveName;
		}
		set
		{
			_descriptiveName = value;
			if (ReInput.isReady && huFZyEKtFdJyTmYQMmRqlgAXskwv != null)
			{
				huFZyEKtFdJyTmYQMmRqlgAXskwv.qFSeqqVPfIqnwwFRvTgDucKqgogy();
			}
		}
	}

	[CustomObfuscation(rename = false)]
	internal string nonLocalizedPositiveDescriptiveName
	{
		get
		{
			return _positiveDescriptiveName;
		}
		set
		{
			_positiveDescriptiveName = value;
			if (ReInput.isReady && huFZyEKtFdJyTmYQMmRqlgAXskwv != null)
			{
				huFZyEKtFdJyTmYQMmRqlgAXskwv.XNpaTfyhAhNTxHJiXVjNbdVbSPHt();
			}
		}
	}

	[CustomObfuscation(rename = false)]
	internal string nonLocalizedNegativeDescriptiveName
	{
		get
		{
			return _negativeDescriptiveName;
		}
		set
		{
			_negativeDescriptiveName = value;
			if (ReInput.isReady && huFZyEKtFdJyTmYQMmRqlgAXskwv != null)
			{
				huFZyEKtFdJyTmYQMmRqlgAXskwv.qrcDCChoJyLkCoCgPOHAVlSlEEoib();
			}
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

	internal void AMAIZfInlMSYYmanVNuUfsJDsYjb(int P_0)
	{
		_id = P_0;
	}

	internal void WUHHsrTAElkhpWiNqDYhmjbqOeWL(string P_0)
	{
		_name = P_0;
		if (ReInput.isReady && huFZyEKtFdJyTmYQMmRqlgAXskwv != null)
		{
			huFZyEKtFdJyTmYQMmRqlgAXskwv.OAlKIOycxHDThhuOVdyvlOGUVPeP();
		}
	}

	internal void UhsLadNucvFrEnUMjLPcGIOTrRGJ(InputActionType P_0)
	{
		_type = P_0;
		if (ReInput.isReady && huFZyEKtFdJyTmYQMmRqlgAXskwv != null)
		{
			huFZyEKtFdJyTmYQMmRqlgAXskwv.oeDBNDBzqMsnytUOuXXeRaRsAAFCb(AWygYsGSbwRCtjCffVNRqlHmhBfhc(_type));
		}
	}

	internal void vOyOrTASWGfRrTkMPhSeLaBoARuhA(string P_0)
	{
		nonLocalizedDescriptiveName = P_0;
	}

	internal void czxCNFIZMOKPvRKPMOMLwLpcnTRG(string P_0)
	{
		nonLocalizedPositiveDescriptiveName = P_0;
	}

	internal void mEUinnimIdZLvnQgZuDCNKsYKliH(string P_0)
	{
		nonLocalizedNegativeDescriptiveName = P_0;
	}

	internal void PiUFsDNerYNrnOuphGYyaUCZBwQk(int P_0)
	{
		_behaviorId = P_0;
	}

	internal void lqxUlhffEKUJrRHeHYZDDZrcIOVq(int P_0)
	{
		_categoryId = P_0;
	}

	internal void RJRENmwlYMGUXgUeHdFiLvedFNsJ(bool P_0)
	{
		_userAssignable = P_0;
	}

	public InputAction()
	{
	}

	public InputAction(InputAction P_0)
	{
		_id = P_0._id;
		_name = P_0._name;
		_type = P_0._type;
		_descriptiveName = P_0._descriptiveName;
		_positiveDescriptiveName = P_0._positiveDescriptiveName;
		_negativeDescriptiveName = P_0._negativeDescriptiveName;
		_key = P_0._key;
		_positiveKey = P_0._positiveKey;
		_negativeKey = P_0._negativeKey;
		_behaviorId = P_0._behaviorId;
		_userAssignable = P_0._userAssignable;
		_categoryId = P_0.categoryId;
		mBgTyWAycpBARKLyeTvJWqNAnKhn = P_0.mBgTyWAycpBARKLyeTvJWqNAnKhn;
	}

	public InputAction Clone()
	{
		return new InputAction(this);
	}

	public string GetDisplayName(AxisRange axisRange)
	{
		return axisRange switch
		{
			AxisRange.Full => descriptiveName, 
			AxisRange.Positive => positiveDescriptiveName, 
			AxisRange.Negative => negativeDescriptiveName, 
			_ => throw new NotImplementedException(), 
		};
	}

	internal void qVwYUHfbXDNqnRRcbywHCtpMBJaK()
	{
		if (huFZyEKtFdJyTmYQMmRqlgAXskwv == null)
		{
			huFZyEKtFdJyTmYQMmRqlgAXskwv = PKRdDUAstMBavDtLUceRhHVgLLzOc.vQkCJlCfctEJdaNQhGHOUeNawqOeA(this, AWygYsGSbwRCtjCffVNRqlHmhBfhc(_type), pNZrRihcucynHABMizyaEoIxhqLo.lGAwloROqSjUpJpzAfJNHgHgvWNeA.None);
		}
	}

	internal void FEKktiNBCjXncAwCqgszEAKXrarJ()
	{
		if (huFZyEKtFdJyTmYQMmRqlgAXskwv != null)
		{
			huFZyEKtFdJyTmYQMmRqlgAXskwv = null;
		}
	}

	private static pNZrRihcucynHABMizyaEoIxhqLo.AhhliCUThpTCpJDayBicensRWslA AWygYsGSbwRCtjCffVNRqlHmhBfhc(InputActionType P_0)
	{
		return P_0 switch
		{
			InputActionType.Axis => pNZrRihcucynHABMizyaEoIxhqLo.AhhliCUThpTCpJDayBicensRWslA.Axis, 
			InputActionType.Button => pNZrRihcucynHABMizyaEoIxhqLo.AhhliCUThpTCpJDayBicensRWslA.Button, 
			_ => throw new NotImplementedException(), 
		};
	}

	private string Rewired_002EInternal_002ELocalization_002EINameLocalizerSource_002Eget_keyCategory()
	{
		return "action";
	}

	private string Rewired_002EInternal_002ELocalization_002EINameLocalizerSource_002Eget_scriptingName()
	{
		return _name;
	}

	private string Rewired_002EInternal_002ELocalization_002EINameLocalizerSource_002Eget_nonLocalizedDescriptiveName()
	{
		return _descriptiveName;
	}

	private void Rewired_002EInternal_002ELocalization_002EINameLocalizerSource_002Eset_nonLocalizedDescriptiveName(string value)
	{
		_descriptiveName = value;
	}

	private string Rewired_002EInternal_002ELocalization_002EIAxisNameLocalizerSource_002Eget_nonLocalizedPositiveDescriptiveName()
	{
		return _positiveDescriptiveName;
	}

	private void Rewired_002EInternal_002ELocalization_002EIAxisNameLocalizerSource_002Eset_nonLocalizedPositiveDescriptiveName(string value)
	{
		_positiveDescriptiveName = value;
	}

	private string Rewired_002EInternal_002ELocalization_002EIAxisNameLocalizerSource_002Eget_nonLocalizedNegativeDescriptiveName()
	{
		return _negativeDescriptiveName;
	}

	private void Rewired_002EInternal_002ELocalization_002EIAxisNameLocalizerSource_002Eset_nonLocalizedNegativeDescriptiveName(string value)
	{
		_negativeDescriptiveName = value;
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
		return mBgTyWAycpBARKLyeTvJWqNAnKhn;
	}

	private void Rewired_002EInternal_002ELocalization_002EINameLocalizerSource_002Eset_autoGeneratedValueFlags(int value)
	{
		mBgTyWAycpBARKLyeTvJWqNAnKhn = value;
	}
}
