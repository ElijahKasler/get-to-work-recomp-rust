using UnityEngine;

namespace Rewired;

public struct ControllerPollingInfo
{
	private bool RtHfCRqzcXgmbMWHeLAvjMjQSddK;

	private int ltxHxwBUrnSobqDEUHZoXwvhDfnh;

	private int PeseSUhOylkNbDQhahhiorWEKQSuA;

	private string LMAJkuDAoggtOLebTuZpTyHesdle;

	private ControllerType ibjWmdQhbEVrlheXUZTLlxwjGzKM;

	private ControllerElementType TwSaSqtPZmTyMrcQdcACAUuBMIADb;

	private int LyhmMeSnDoaPFDgFpqTlKxJqfvCE;

	private Pole AiogYzKymGgUhlpZUvimrIvedIUT;

	private string MpxRipPInCcZznSGSWSIaaJCZHQC;

	private int qZUhfBqqenaDaiaXpMiyjSzDtevSc;

	private KeyCode OpdLfgUvuPrHXAyVBeUVlkuBhVCk;

	public bool success
	{
		get
		{
			return RtHfCRqzcXgmbMWHeLAvjMjQSddK;
		}
		internal set
		{
			YDSEHAYySzsOKlgHmgtGJcwSiGJHA(flag);
		}
	}

	public int playerId
	{
		get
		{
			return ltxHxwBUrnSobqDEUHZoXwvhDfnh;
		}
		internal set
		{
			haeCbWiQSPlfWqsFZDTLoULYjVYq(num);
		}
	}

	public int controllerId
	{
		get
		{
			return PeseSUhOylkNbDQhahhiorWEKQSuA;
		}
		internal set
		{
			LeujjUFonPZyEJqtISLMiYXrGXBuA(num);
		}
	}

	public string controllerName
	{
		get
		{
			return LMAJkuDAoggtOLebTuZpTyHesdle;
		}
		internal set
		{
			JZCTDuXqzLBugCRfohAnleAJDCAUA(text);
		}
	}

	public ControllerType controllerType
	{
		get
		{
			return ibjWmdQhbEVrlheXUZTLlxwjGzKM;
		}
		internal set
		{
			LZNjISnDiRJbzueFceixrRWrIZzc(controllerType);
		}
	}

	public ControllerElementType elementType
	{
		get
		{
			return TwSaSqtPZmTyMrcQdcACAUuBMIADb;
		}
		internal set
		{
			NhIDmYFLmRVjgkBcGsAlSOLfVgRoA(controllerElementType);
		}
	}

	public int elementIndex
	{
		get
		{
			return LyhmMeSnDoaPFDgFpqTlKxJqfvCE;
		}
		internal set
		{
			zyaKJXlgaQdzZoonHBDSyokrPZmb(num);
		}
	}

	public Pole axisPole
	{
		get
		{
			return AiogYzKymGgUhlpZUvimrIvedIUT;
		}
		internal set
		{
			TvRwpyIMNoqPkYMShAJNrQJkUijo(pole);
		}
	}

	public string elementIdentifierName
	{
		get
		{
			return MpxRipPInCcZznSGSWSIaaJCZHQC;
		}
		internal set
		{
			irEoEWQtjoNkJQjaRTLJVZjFrvWI(text);
		}
	}

	public int elementIdentifierId
	{
		get
		{
			return qZUhfBqqenaDaiaXpMiyjSzDtevSc;
		}
		internal set
		{
			EldEnwbJrVGRsgTFjpyHHLqqkrkVb(num);
		}
	}

	public KeyCode keyboardKey
	{
		get
		{
			return OpdLfgUvuPrHXAyVBeUVlkuBhVCk;
		}
		internal set
		{
			AbKjvHFxsvmZRkOBJookINTdUDfc(keyCode);
		}
	}

	public Player player
	{
		get
		{
			if (!ReInput.isReady)
			{
				return null;
			}
			if (!ReInput.iJRGiWfOZRwVGgOxWlHrWBzdJmvdA.jpUdRWBxFHbifDILmpuwKTgxgTJg(ltxHxwBUrnSobqDEUHZoXwvhDfnh))
			{
				return null;
			}
			return ReInput.iJRGiWfOZRwVGgOxWlHrWBzdJmvdA.fucJiwJzRsWBBQakvQMUMarJaFob(ltxHxwBUrnSobqDEUHZoXwvhDfnh);
		}
	}

	public Controller controller
	{
		get
		{
			if (!ReInput.isReady)
			{
				return null;
			}
			return ReInput.controllers.GetController(ibjWmdQhbEVrlheXUZTLlxwjGzKM, PeseSUhOylkNbDQhahhiorWEKQSuA);
		}
	}

	public ControllerElementIdentifier elementIdentifier
	{
		get
		{
			if (!ReInput.isReady)
			{
				return null;
			}
			return controller?.GetElementIdentifierById(qZUhfBqqenaDaiaXpMiyjSzDtevSc);
		}
	}

	internal void YDSEHAYySzsOKlgHmgtGJcwSiGJHA(bool P_0)
	{
		RtHfCRqzcXgmbMWHeLAvjMjQSddK = P_0;
	}

	internal void haeCbWiQSPlfWqsFZDTLoULYjVYq(int P_0)
	{
		ltxHxwBUrnSobqDEUHZoXwvhDfnh = P_0;
	}

	internal void LeujjUFonPZyEJqtISLMiYXrGXBuA(int P_0)
	{
		PeseSUhOylkNbDQhahhiorWEKQSuA = P_0;
	}

	internal void JZCTDuXqzLBugCRfohAnleAJDCAUA(string P_0)
	{
		LMAJkuDAoggtOLebTuZpTyHesdle = P_0;
	}

	internal void LZNjISnDiRJbzueFceixrRWrIZzc(ControllerType P_0)
	{
		ibjWmdQhbEVrlheXUZTLlxwjGzKM = P_0;
	}

	internal void NhIDmYFLmRVjgkBcGsAlSOLfVgRoA(ControllerElementType P_0)
	{
		TwSaSqtPZmTyMrcQdcACAUuBMIADb = P_0;
	}

	internal void zyaKJXlgaQdzZoonHBDSyokrPZmb(int P_0)
	{
		LyhmMeSnDoaPFDgFpqTlKxJqfvCE = P_0;
	}

	internal void TvRwpyIMNoqPkYMShAJNrQJkUijo(Pole P_0)
	{
		AiogYzKymGgUhlpZUvimrIvedIUT = P_0;
	}

	internal void irEoEWQtjoNkJQjaRTLJVZjFrvWI(string P_0)
	{
		MpxRipPInCcZznSGSWSIaaJCZHQC = P_0;
	}

	internal void EldEnwbJrVGRsgTFjpyHHLqqkrkVb(int P_0)
	{
		qZUhfBqqenaDaiaXpMiyjSzDtevSc = P_0;
	}

	internal void AbKjvHFxsvmZRkOBJookINTdUDfc(KeyCode P_0)
	{
		OpdLfgUvuPrHXAyVBeUVlkuBhVCk = P_0;
	}

	internal ControllerPollingInfo(bool P_0, int P_1, int P_2, string P_3, ControllerType P_4, ControllerElementType P_5, int P_6, Pole P_7, string P_8, int P_9, KeyCode P_10)
	{
		RtHfCRqzcXgmbMWHeLAvjMjQSddK = P_0;
		ltxHxwBUrnSobqDEUHZoXwvhDfnh = P_1;
		PeseSUhOylkNbDQhahhiorWEKQSuA = P_2;
		LMAJkuDAoggtOLebTuZpTyHesdle = P_3;
		ibjWmdQhbEVrlheXUZTLlxwjGzKM = P_4;
		TwSaSqtPZmTyMrcQdcACAUuBMIADb = P_5;
		LyhmMeSnDoaPFDgFpqTlKxJqfvCE = P_6;
		AiogYzKymGgUhlpZUvimrIvedIUT = P_7;
		MpxRipPInCcZznSGSWSIaaJCZHQC = P_8;
		qZUhfBqqenaDaiaXpMiyjSzDtevSc = P_9;
		OpdLfgUvuPrHXAyVBeUVlkuBhVCk = P_10;
	}

	internal ControllerPollingInfo(ControllerPollingInfo P_0)
	{
		RtHfCRqzcXgmbMWHeLAvjMjQSddK = P_0.RtHfCRqzcXgmbMWHeLAvjMjQSddK;
		ltxHxwBUrnSobqDEUHZoXwvhDfnh = P_0.ltxHxwBUrnSobqDEUHZoXwvhDfnh;
		PeseSUhOylkNbDQhahhiorWEKQSuA = P_0.PeseSUhOylkNbDQhahhiorWEKQSuA;
		LMAJkuDAoggtOLebTuZpTyHesdle = P_0.LMAJkuDAoggtOLebTuZpTyHesdle;
		ibjWmdQhbEVrlheXUZTLlxwjGzKM = P_0.ibjWmdQhbEVrlheXUZTLlxwjGzKM;
		TwSaSqtPZmTyMrcQdcACAUuBMIADb = P_0.TwSaSqtPZmTyMrcQdcACAUuBMIADb;
		LyhmMeSnDoaPFDgFpqTlKxJqfvCE = P_0.LyhmMeSnDoaPFDgFpqTlKxJqfvCE;
		AiogYzKymGgUhlpZUvimrIvedIUT = P_0.AiogYzKymGgUhlpZUvimrIvedIUT;
		MpxRipPInCcZznSGSWSIaaJCZHQC = P_0.MpxRipPInCcZznSGSWSIaaJCZHQC;
		qZUhfBqqenaDaiaXpMiyjSzDtevSc = P_0.qZUhfBqqenaDaiaXpMiyjSzDtevSc;
		OpdLfgUvuPrHXAyVBeUVlkuBhVCk = P_0.OpdLfgUvuPrHXAyVBeUVlkuBhVCk;
	}

	internal static ControllerPollingInfo wybtSxBKyoFevDSBzxAFgDtcKhkHA()
	{
		return new ControllerPollingInfo(false, -1, -1, string.Empty, ControllerType.Keyboard, ControllerElementType.Axis, -1, Pole.Positive, string.Empty, -1, KeyCode.None);
	}
}
