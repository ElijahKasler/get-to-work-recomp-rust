using System;
using Rewired.Utils;
using UnityEngine;

namespace Rewired;

[CustomObfuscation(rename = false)]
[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
internal static class ThreadSafeUnityInput
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	public sealed class Keyboard
	{
		private const int IjwHaDByXBnigSyOJKAbnCXFmNJs = 132;

		public static readonly int keyValueIndex_Escape;

		public static readonly int keyValueIndex_Menu;

		public static readonly int keyValueIndex_F2;

		public static readonly int keyValueIndex_UpArrow;

		public static readonly int keyValueIndex_RightArrow;

		public static readonly int keyValueIndex_DownArrow;

		public static readonly int keyValueIndex_LeftArrow;

		private static readonly int[] GQQjroBhoCMRgvOdLSUtGEXddLfJA;

		private readonly int vCFJJxWivbDMrkTDJDomVaGujKpm;

		private readonly int[] CEVQJwBBLhizeeKXJBeeKdWTBfwhA;

		private readonly bool[] fPXpgQzTcwMTvkvqHMaRGCOOZIec;

		private bool dqXJMUKhRKsBfsqhyyyMSSeAqJLu;

		private int CMuJaZdCApJcPoKtIvdwkaepfQBfA;

		private readonly bool gLBvigJIMeHJqjbjvtDUgXmQReOJA;

		private bool KhmZqWJNWPdQJBwMWUKwNAeoXUTqA;

		public bool enabled
		{
			get
			{
				return dqXJMUKhRKsBfsqhyyyMSSeAqJLu;
			}
			set
			{
				if (value != dqXJMUKhRKsBfsqhyyyMSSeAqJLu)
				{
					dqXJMUKhRKsBfsqhyyyMSSeAqJLu = value;
					if (!dqXJMUKhRKsBfsqhyyyMSSeAqJLu)
					{
						Clear();
					}
				}
			}
		}

		public bool monitoring => CMuJaZdCApJcPoKtIvdwkaepfQBfA > 0;

		public int keyCount => 132;

		static Keyboard()
		{
			if (UnityTools.isAndroidPlatform)
			{
				int[] keyboardKeyValues = Consts._keyboardKeyValues;
				GQQjroBhoCMRgvOdLSUtGEXddLfJA = new int[7]
				{
					(keyValueIndex_Escape = ArrayTools.IndexOf(keyboardKeyValues, 27)),
					(keyValueIndex_Menu = ArrayTools.IndexOf(keyboardKeyValues, 319)),
					(keyValueIndex_F2 = ArrayTools.IndexOf(keyboardKeyValues, 283)),
					(keyValueIndex_UpArrow = ArrayTools.IndexOf(keyboardKeyValues, 273)),
					(keyValueIndex_RightArrow = ArrayTools.IndexOf(keyboardKeyValues, 275)),
					(keyValueIndex_DownArrow = ArrayTools.IndexOf(keyboardKeyValues, 274)),
					(keyValueIndex_LeftArrow = ArrayTools.IndexOf(keyboardKeyValues, 276))
				};
			}
		}

		public Keyboard()
		{
			fPXpgQzTcwMTvkvqHMaRGCOOZIec = new bool[132];
			int[] keyboardKeyValues = Consts._keyboardKeyValues;
			int num = keyboardKeyValues.Length;
			for (int i = 0; i < num; i++)
			{
				if (keyboardKeyValues[i] > vCFJJxWivbDMrkTDJDomVaGujKpm)
				{
					vCFJJxWivbDMrkTDJDomVaGujKpm = keyboardKeyValues[i];
				}
			}
			CEVQJwBBLhizeeKXJBeeKdWTBfwhA = new int[vCFJJxWivbDMrkTDJDomVaGujKpm + 1];
			ArrayTools.Fill(CEVQJwBBLhizeeKXJBeeKdWTBfwhA, -1);
			for (int j = 0; j < num; j++)
			{
				CEVQJwBBLhizeeKXJBeeKdWTBfwhA[keyboardKeyValues[j]] = j;
			}
		}

		public void Initialize()
		{
			if (CMuJaZdCApJcPoKtIvdwkaepfQBfA != 0)
			{
				ATPRndmKdbCueiEJfNNnejNodAJQA();
			}
			xNUgSbKKXZJnSOCSjTNPsUgmxWTeA();
		}

		public void PostInitialize()
		{
			Update();
		}

		public void Update()
		{
			if (CMuJaZdCApJcPoKtIvdwkaepfQBfA == 0)
			{
				return;
			}
			if (Input.anyKey)
			{
				KhmZqWJNWPdQJBwMWUKwNAeoXUTqA = true;
				if (dqXJMUKhRKsBfsqhyyyMSSeAqJLu)
				{
					int[] keyboardKeyValues = Consts._keyboardKeyValues;
					for (int i = 0; i < 132; i++)
					{
						fPXpgQzTcwMTvkvqHMaRGCOOZIec[i] = Input.GetKey((KeyCode)keyboardKeyValues[i]);
					}
				}
				else if (gLBvigJIMeHJqjbjvtDUgXmQReOJA)
				{
					fPXpgQzTcwMTvkvqHMaRGCOOZIec[keyValueIndex_Escape] = GetKey(KeyCode.Escape);
					fPXpgQzTcwMTvkvqHMaRGCOOZIec[keyValueIndex_Menu] = GetKey(KeyCode.Menu);
					fPXpgQzTcwMTvkvqHMaRGCOOZIec[keyValueIndex_F2] = GetKey(KeyCode.F2);
					fPXpgQzTcwMTvkvqHMaRGCOOZIec[keyValueIndex_UpArrow] = GetKey(KeyCode.UpArrow);
					fPXpgQzTcwMTvkvqHMaRGCOOZIec[keyValueIndex_RightArrow] = GetKey(KeyCode.RightArrow);
					fPXpgQzTcwMTvkvqHMaRGCOOZIec[keyValueIndex_DownArrow] = GetKey(KeyCode.DownArrow);
					fPXpgQzTcwMTvkvqHMaRGCOOZIec[keyValueIndex_LeftArrow] = GetKey(KeyCode.LeftArrow);
				}
			}
			else if (KhmZqWJNWPdQJBwMWUKwNAeoXUTqA)
			{
				Array.Clear(fPXpgQzTcwMTvkvqHMaRGCOOZIec, 0, fPXpgQzTcwMTvkvqHMaRGCOOZIec.Length);
			}
		}

		public void Monitor(bool state)
		{
			if (state)
			{
				CMuJaZdCApJcPoKtIvdwkaepfQBfA++;
				if (CMuJaZdCApJcPoKtIvdwkaepfQBfA == 1)
				{
					vQZgZUZIGbfvxmnaZVDSQedCbcPo();
				}
				return;
			}
			CMuJaZdCApJcPoKtIvdwkaepfQBfA--;
			if (CMuJaZdCApJcPoKtIvdwkaepfQBfA < 0)
			{
				CMuJaZdCApJcPoKtIvdwkaepfQBfA = 0;
				VIVExlnkovmbXKMubfwUpfDqzqil();
			}
			if (CMuJaZdCApJcPoKtIvdwkaepfQBfA == 0)
			{
				LYfSIUhGEohFZSzuZIQlqFaCmavR();
			}
		}

		public bool GetKey(KeyCode keyCode)
		{
			if (CMuJaZdCApJcPoKtIvdwkaepfQBfA == 0)
			{
				IbJXxamoNDEEFpIaWXNzUQFefinO();
				return false;
			}
			if ((uint)keyCode > (uint)vCFJJxWivbDMrkTDJDomVaGujKpm)
			{
				return false;
			}
			return fPXpgQzTcwMTvkvqHMaRGCOOZIec[CEVQJwBBLhizeeKXJBeeKdWTBfwhA[(int)keyCode]];
		}

		public void GetKeyValues(bool[] values)
		{
			if (CMuJaZdCApJcPoKtIvdwkaepfQBfA == 0)
			{
				IbJXxamoNDEEFpIaWXNzUQFefinO();
			}
			else if (values != null && values.Length >= 132)
			{
				Array.Copy(fPXpgQzTcwMTvkvqHMaRGCOOZIec, values, 132);
			}
		}

		public void Clear()
		{
			if (gLBvigJIMeHJqjbjvtDUgXmQReOJA)
			{
				for (int i = 0; i < 132; i++)
				{
					if (Array.IndexOf(GQQjroBhoCMRgvOdLSUtGEXddLfJA, i) < 0)
					{
						fPXpgQzTcwMTvkvqHMaRGCOOZIec[i] = false;
					}
				}
			}
			else
			{
				Array.Clear(fPXpgQzTcwMTvkvqHMaRGCOOZIec, 0, 132);
			}
		}

		private void ATPRndmKdbCueiEJfNNnejNodAJQA()
		{
			Array.Clear(fPXpgQzTcwMTvkvqHMaRGCOOZIec, 0, 132);
		}

		private void xNUgSbKKXZJnSOCSjTNPsUgmxWTeA()
		{
			CMuJaZdCApJcPoKtIvdwkaepfQBfA = 0;
			dqXJMUKhRKsBfsqhyyyMSSeAqJLu = true;
		}

		private void vQZgZUZIGbfvxmnaZVDSQedCbcPo()
		{
		}

		private void LYfSIUhGEohFZSzuZIQlqFaCmavR()
		{
			ATPRndmKdbCueiEJfNNnejNodAJQA();
		}

		private void IbJXxamoNDEEFpIaWXNzUQFefinO()
		{
			Logger.LogWarning("You are trying to use Keyboard without incrementing the monitor count.", requiredThreadSafety: true);
		}

		private void VIVExlnkovmbXKMubfwUpfDqzqil()
		{
			Logger.LogWarning("You are decrementing the Keyboard monitor count more than you are incrementing it.", requiredThreadSafety: true);
		}
	}

	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	public sealed class Mouse
	{
		private const int iAnVpOcdnSLYUpFpzjtVGpQEmkvU = 7;

		private const int eeCkeZPMEzCIaKpyUeJfzabuVIpAA = 4;

		private readonly bool[] PhgqufyvFJcWXgKiCtpPIEnHEIUL;

		private readonly float[] kRqpTtCJIlUFTpayfzRYfAtUkBNG;

		private int ieFaAqAyYSDWUGgoPomArhXSdJNIb;

		private Vector3 rNxssfJajsulMsLThMXqCrAmVxnc;

		private bool uwVLKLnEFMOYNnDmIpCIbEwVoqCN;

		private bool brHbrOqiJmEgUJtYYWMnPVUQurBRA;

		public bool monitoring => ieFaAqAyYSDWUGgoPomArhXSdJNIb > 0;

		public Vector3 mousePosition => rNxssfJajsulMsLThMXqCrAmVxnc;

		public bool mousePresent => uwVLKLnEFMOYNnDmIpCIbEwVoqCN;

		public Mouse()
		{
			PhgqufyvFJcWXgKiCtpPIEnHEIUL = new bool[7];
			kRqpTtCJIlUFTpayfzRYfAtUkBNG = new float[4];
			KhJhTMVEuxYAqbDghOJbgcPogvLd();
		}

		public void PostInitialize()
		{
			Update();
		}

		public void Update()
		{
			if (ieFaAqAyYSDWUGgoPomArhXSdJNIb == 0)
			{
				return;
			}
			if (!brHbrOqiJmEgUJtYYWMnPVUQurBRA)
			{
				try
				{
					for (int i = 0; i < 7; i++)
					{
						PhgqufyvFJcWXgKiCtpPIEnHEIUL[i] = Input.GetButton(Consts.mouseButtonUnityNames[i]);
					}
					for (int j = 0; j < 3; j++)
					{
						kRqpTtCJIlUFTpayfzRYfAtUkBNG[j] = Input.GetAxisRaw(Consts.mouseAxisUnityNames[j]);
					}
				}
				catch
				{
					Logger.LogError("Unity Input Manager mouse entries are missing. Rewired was not installed properly or was canceled during installation, preventing it from installing the necessary Unity Input Manager entries for mouse input or the input manager entries may have been overwritten by another package installed in your project. Mouse input will not function if native mouse input is disabled or is unavailable on this platform.");
					brHbrOqiJmEgUJtYYWMnPVUQurBRA = true;
				}
			}
			kRqpTtCJIlUFTpayfzRYfAtUkBNG[3] = Input.mouseScrollDelta.x;
			rNxssfJajsulMsLThMXqCrAmVxnc = Input.mousePosition;
			uwVLKLnEFMOYNnDmIpCIbEwVoqCN = Input.mousePresent;
		}

		public void Monitor(bool state)
		{
			if (state)
			{
				ieFaAqAyYSDWUGgoPomArhXSdJNIb++;
				if (ieFaAqAyYSDWUGgoPomArhXSdJNIb == 1)
				{
					SbzBbjRsVobdScFEIvmmDHeZGVIF();
				}
				return;
			}
			ieFaAqAyYSDWUGgoPomArhXSdJNIb--;
			if (ieFaAqAyYSDWUGgoPomArhXSdJNIb < 0)
			{
				ieFaAqAyYSDWUGgoPomArhXSdJNIb = 0;
				qcrViHXesxKPFRONerSUhZpuqdry();
			}
			if (ieFaAqAyYSDWUGgoPomArhXSdJNIb == 0)
			{
				oZlHnAaRqfjxMQGVGTfJEbPAyMt();
			}
		}

		public bool GetButton(int index)
		{
			if (ieFaAqAyYSDWUGgoPomArhXSdJNIb == 0)
			{
				xivzBtzNSMwmAREFQDnNebfcQTTAA();
				return false;
			}
			if ((uint)index >= 7u)
			{
				return false;
			}
			return PhgqufyvFJcWXgKiCtpPIEnHEIUL[index];
		}

		public float GetAxisRaw(int index)
		{
			if (ieFaAqAyYSDWUGgoPomArhXSdJNIb == 0)
			{
				xivzBtzNSMwmAREFQDnNebfcQTTAA();
				return 0f;
			}
			if ((uint)index >= 4u)
			{
				return 0f;
			}
			return kRqpTtCJIlUFTpayfzRYfAtUkBNG[index];
		}

		public void GetButtonValues(bool[] buttons)
		{
			if (ieFaAqAyYSDWUGgoPomArhXSdJNIb == 0)
			{
				xivzBtzNSMwmAREFQDnNebfcQTTAA();
			}
			else if (buttons != null && buttons.Length >= 7)
			{
				Array.Copy(PhgqufyvFJcWXgKiCtpPIEnHEIUL, buttons, 7);
			}
		}

		public void GetAxisRawValues(float[] axes)
		{
			if (ieFaAqAyYSDWUGgoPomArhXSdJNIb == 0)
			{
				xivzBtzNSMwmAREFQDnNebfcQTTAA();
			}
			else if (axes != null && axes.Length >= 4)
			{
				Array.Copy(kRqpTtCJIlUFTpayfzRYfAtUkBNG, axes, 4);
			}
		}

		private void qwdXkuJBilOsmanXrldaCncyOYEw()
		{
			Array.Clear(PhgqufyvFJcWXgKiCtpPIEnHEIUL, 0, 7);
			Array.Clear(kRqpTtCJIlUFTpayfzRYfAtUkBNG, 0, 4);
		}

		private void KhJhTMVEuxYAqbDghOJbgcPogvLd()
		{
			ieFaAqAyYSDWUGgoPomArhXSdJNIb = 0;
			rNxssfJajsulMsLThMXqCrAmVxnc = Vector3.zero;
			uwVLKLnEFMOYNnDmIpCIbEwVoqCN = false;
		}

		private void SbzBbjRsVobdScFEIvmmDHeZGVIF()
		{
		}

		private void oZlHnAaRqfjxMQGVGTfJEbPAyMt()
		{
			qwdXkuJBilOsmanXrldaCncyOYEw();
		}

		private void xivzBtzNSMwmAREFQDnNebfcQTTAA()
		{
			Logger.LogWarning("You are trying to use Mouse without incrementing the monitor count.", requiredThreadSafety: true);
		}

		private void qcrViHXesxKPFRONerSUhZpuqdry()
		{
			Logger.LogWarning("You are decrementing the Mouse monitor count more than you are incrementing it.", requiredThreadSafety: true);
		}
	}

	private static Mouse ULCjhhRNOMCwATnBRhWbeybyfpWzA;

	private static Keyboard kbPSjKBdebbrbfSwMsgGQikIsqvz;

	public static Mouse mouse => ULCjhhRNOMCwATnBRhWbeybyfpWzA ?? (ULCjhhRNOMCwATnBRhWbeybyfpWzA = new Mouse());

	public static Keyboard keyboard => kbPSjKBdebbrbfSwMsgGQikIsqvz ?? (kbPSjKBdebbrbfSwMsgGQikIsqvz = new Keyboard());

	public static void Initialize()
	{
	}

	public static void PostInitialize()
	{
		if (kbPSjKBdebbrbfSwMsgGQikIsqvz != null)
		{
			kbPSjKBdebbrbfSwMsgGQikIsqvz.PostInitialize();
		}
		if (ULCjhhRNOMCwATnBRhWbeybyfpWzA != null)
		{
			ULCjhhRNOMCwATnBRhWbeybyfpWzA.PostInitialize();
		}
	}

	public static void PostInitialize2()
	{
	}

	public static void Deinitialize()
	{
		if (kbPSjKBdebbrbfSwMsgGQikIsqvz != null)
		{
			kbPSjKBdebbrbfSwMsgGQikIsqvz = null;
		}
		if (ULCjhhRNOMCwATnBRhWbeybyfpWzA != null)
		{
			ULCjhhRNOMCwATnBRhWbeybyfpWzA = null;
		}
	}

	public static void Update()
	{
		if (kbPSjKBdebbrbfSwMsgGQikIsqvz != null)
		{
			kbPSjKBdebbrbfSwMsgGQikIsqvz.enabled = ReInput.controllers.Keyboard.enabled;
			kbPSjKBdebbrbfSwMsgGQikIsqvz.Update();
		}
		if (ULCjhhRNOMCwATnBRhWbeybyfpWzA != null)
		{
			ULCjhhRNOMCwATnBRhWbeybyfpWzA.Update();
		}
	}
}
