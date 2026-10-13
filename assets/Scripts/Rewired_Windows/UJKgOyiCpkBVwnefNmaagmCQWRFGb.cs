using System;
using System.Threading;
using Rewired.Utils;

internal class UJKgOyiCpkBVwnefNmaagmCQWRFGb
{
	private int LvydwDfGlSheoaHqqBMeEeEDbjEHA;

	private int MRhgQUSZlbfbJpiLugxQiFyOGnlfA;

	private int tjmrNSfWmBmKsPqOwJoOPKbZPBiq;

	private Action vOaERuCMeGKmgELtkiOgdgWwJHKeb__BackingField;

	public float aJPLhDRpepLqXeIMDrYinbeCKKvj
	{
		get
		{
			return amCmtGfdAUDdaZFcOaPOItQCQwvxA();
		}
		set
		{
			PpwdGZtDTfEXYRzvADURwiBhyEjQ(num);
		}
	}

	public int xnYOkqjVvWkRyfFUexKCxXRqgSHi
	{
		get
		{
			return DYWGVvmfVdcRhDBgOuJRwnGnXSli();
		}
		set
		{
			ZzeucWTvdVBzsUkrmxpdrFxcbvgG(num);
		}
	}

	public event Action vOaERuCMeGKmgELtkiOgdgWwJHKeb
	{
		add
		{
			kaRSfqFlYVGBiBQLpDLehwzBbhMl(action);
		}
		remove
		{
			IUFnDAtNwHfZnKkBlsOFoRAYzGqG(action);
		}
	}

	public void kaRSfqFlYVGBiBQLpDLehwzBbhMl(Action P_0)
	{
		Action action = vOaERuCMeGKmgELtkiOgdgWwJHKeb__BackingField;
		Action action2;
		do
		{
			action2 = action;
			Action value = (Action)Delegate.Combine(action2, P_0);
			action = Interlocked.CompareExchange(ref vOaERuCMeGKmgELtkiOgdgWwJHKeb__BackingField, value, action2);
		}
		while ((object)action != action2);
	}

	public void IUFnDAtNwHfZnKkBlsOFoRAYzGqG(Action P_0)
	{
		Action action = vOaERuCMeGKmgELtkiOgdgWwJHKeb__BackingField;
		Action action2;
		do
		{
			action2 = action;
			Action value = (Action)Delegate.Remove(action2, P_0);
			action = Interlocked.CompareExchange(ref vOaERuCMeGKmgELtkiOgdgWwJHKeb__BackingField, value, action2);
		}
		while ((object)action != action2);
	}

	public float amCmtGfdAUDdaZFcOaPOItQCQwvxA()
	{
		return uaMPMaLtyuNGJKpEJZfGSYNcFt(LvydwDfGlSheoaHqqBMeEeEDbjEHA);
	}

	public void PpwdGZtDTfEXYRzvADURwiBhyEjQ(float P_0)
	{
		LvydwDfGlSheoaHqqBMeEeEDbjEHA = zyXdrYhrIHilTBkaCirxnTNshgFHc(P_0);
		if (vOaERuCMeGKmgELtkiOgdgWwJHKeb__BackingField != null)
		{
			vOaERuCMeGKmgELtkiOgdgWwJHKeb__BackingField();
		}
	}

	public int DYWGVvmfVdcRhDBgOuJRwnGnXSli()
	{
		return LvydwDfGlSheoaHqqBMeEeEDbjEHA;
	}

	public void ZzeucWTvdVBzsUkrmxpdrFxcbvgG(int P_0)
	{
		LvydwDfGlSheoaHqqBMeEeEDbjEHA = P_0;
		if (vOaERuCMeGKmgELtkiOgdgWwJHKeb__BackingField != null)
		{
			vOaERuCMeGKmgELtkiOgdgWwJHKeb__BackingField();
		}
	}

	public UJKgOyiCpkBVwnefNmaagmCQWRFGb(int P_0, int P_1)
	{
		MRhgQUSZlbfbJpiLugxQiFyOGnlfA = P_0;
		tjmrNSfWmBmKsPqOwJoOPKbZPBiq = P_1;
	}

	private float uaMPMaLtyuNGJKpEJZfGSYNcFt(int P_0)
	{
		return MathTools.Clamp((float)P_0 / (float)tjmrNSfWmBmKsPqOwJoOPKbZPBiq, 0f, 1f);
	}

	private int zyXdrYhrIHilTBkaCirxnTNshgFHc(float P_0)
	{
		return MathTools.Clamp((int)(P_0 * (float)tjmrNSfWmBmKsPqOwJoOPKbZPBiq), MRhgQUSZlbfbJpiLugxQiFyOGnlfA, tjmrNSfWmBmKsPqOwJoOPKbZPBiq);
	}
}
