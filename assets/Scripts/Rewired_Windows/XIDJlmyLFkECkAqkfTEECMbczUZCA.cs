using System;
using System.Collections.Generic;
using Rewired;
using Rewired.Interfaces;
using Rewired.Internal;
using Rewired.Platforms;
using Rewired.Utils;
using UnityEngine;

internal sealed class XIDJlmyLFkECkAqkfTEECMbczUZCA : IElementIdentifierTool
{
	private Rewired.Internal.GUIText RmIEfagqwuNNImrWrrTsgRPFoFjr;

	private string MOzDsEUALMXdRJGjRfZIGidYYcpjA;

	private int RXuGgwWHVeknvlIdZiZOahpguNWC;

	private ojlzQfWcOYdhEdoUtpjHLTuXXVeX hGOfBefMpJEuDgwIfuTkcRJHHUji;

	private hAqIKBCgLbWxaUEriKlSsXEPBcNeA bqZGqBIzNTyYxMylsiHGVgYHbYnY;

	private Guid beRpESdzmQufBWxTPHmRLwALraQn;

	private IList<hAqIKBCgLbWxaUEriKlSsXEPBcNeA> kJfVUIHTZWqyrRKfDvTHrpSjAWCbA;

	private bool wVLDXtacOtwCkOwQvlTTZoVvDOsM;

	private bool gVTNMePuaxhoaUnncEpRkPsxtJKF;

	private bool iaWdNyFcyIyXIlyeNDbnDabuaZYFA;

	private string[] wYFbnpCSOnriIJINtEvnBkxPiOTr;

	private int[] PqqCdaPPgDJOyvyaKMmGPutdLWgw;

	public void Initialize(Rewired.Internal.GUIText text)
	{
		RmIEfagqwuNNImrWrrTsgRPFoFjr = text;
		wYFbnpCSOnriIJINtEvnBkxPiOTr = Enum.GetNames(typeof(RawInputAxis));
		PqqCdaPPgDJOyvyaKMmGPutdLWgw = (int[])Enum.GetValues(typeof(RawInputAxis));
	}

	void IElementIdentifierTool.Initialize(Rewired.Internal.GUIText text)
	{
		//ILSpy generated this explicit interface implementation from .override directive in Initialize
		this.Initialize(text);
	}

	public void Start()
	{
		if (ReInput.isEditor && ReInput.editorPlatform != EditorPlatform.Windows)
		{
			Rewired.Logger.LogError("Raw Input cannot be run on this platform. You must be running the editor in Windows.");
			return;
		}
		if (ReInput.currentPlatform != Platform.Windows)
		{
			Rewired.Logger.LogError("Raw Input cannot be run on this build target. Be sure Unity's build target is set to Windows Standalone.");
			return;
		}
		hGOfBefMpJEuDgwIfuTkcRJHHUji = ReInput.primaryInputManager.inputSource as ojlzQfWcOYdhEdoUtpjHLTuXXVeX;
		if (hGOfBefMpJEuDgwIfuTkcRJHHUji == null)
		{
			Rewired.Logger.LogError("Unable to initialize Raw Input! You must add a Rewired Input Manager to the scene and set the input mode to Raw Input.");
			return;
		}
		ReInput.primaryInputManager.SystemDeviceConnectedEvent += iWSrqUXsxsiRKyQdQIgFDuYbeurj;
		ReInput.primaryInputManager.SystemDeviceDisconnectedEvent += zEEtcxgBcOSHxdVYKvAMwKJpdvKd;
		PNZFazqSnWdiqZFYuWXPSrRAaSSj();
		iaWdNyFcyIyXIlyeNDbnDabuaZYFA = true;
	}

	void IElementIdentifierTool.Start()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Start
		this.Start();
	}

	public void Update()
	{
		if (!iaWdNyFcyIyXIlyeNDbnDabuaZYFA)
		{
			return;
		}
		MOzDsEUALMXdRJGjRfZIGidYYcpjA = "Raw Input Joystick Element Identifier\n\n";
		RmIEfagqwuNNImrWrrTsgRPFoFjr.text = MOzDsEUALMXdRJGjRfZIGidYYcpjA;
		int rXuGgwWHVeknvlIdZiZOahpguNWC = RXuGgwWHVeknvlIdZiZOahpguNWC;
		Guid guid = beRpESdzmQufBWxTPHmRLwALraQn;
		if (ReInput.controllers.Keyboard.GetKeyDown(KeyCode.Equals) || ReInput.controllers.Keyboard.GetKeyDown(KeyCode.Plus) || ReInput.controllers.Keyboard.GetKeyDown(KeyCode.KeypadPlus))
		{
			RXuGgwWHVeknvlIdZiZOahpguNWC++;
		}
		if (ReInput.controllers.Keyboard.GetKeyDown(KeyCode.KeypadMinus) || ReInput.controllers.Keyboard.GetKeyDown(KeyCode.Minus))
		{
			RXuGgwWHVeknvlIdZiZOahpguNWC--;
		}
		if (gVTNMePuaxhoaUnncEpRkPsxtJKF)
		{
			PNZFazqSnWdiqZFYuWXPSrRAaSSj();
			gVTNMePuaxhoaUnncEpRkPsxtJKF = false;
		}
		int num = ((kJfVUIHTZWqyrRKfDvTHrpSjAWCbA != null) ? kJfVUIHTZWqyrRKfDvTHrpSjAWCbA.Count : 0);
		if (num == 0)
		{
			return;
		}
		if (RXuGgwWHVeknvlIdZiZOahpguNWC < 0)
		{
			RXuGgwWHVeknvlIdZiZOahpguNWC = num - 1;
		}
		else if (RXuGgwWHVeknvlIdZiZOahpguNWC >= num)
		{
			RXuGgwWHVeknvlIdZiZOahpguNWC = 0;
		}
		beRpESdzmQufBWxTPHmRLwALraQn = kJfVUIHTZWqyrRKfDvTHrpSjAWCbA[RXuGgwWHVeknvlIdZiZOahpguNWC].ZvmvsWMlTmAJPVXKTPszaswtXGqE();
		bool flag = false;
		if (rXuGgwWHVeknvlIdZiZOahpguNWC != RXuGgwWHVeknvlIdZiZOahpguNWC || guid != beRpESdzmQufBWxTPHmRLwALraQn)
		{
			flag = true;
		}
		if ((bqZGqBIzNTyYxMylsiHGVgYHbYnY == null) | flag)
		{
			if (bqZGqBIzNTyYxMylsiHGVgYHbYnY != null)
			{
				bqZGqBIzNTyYxMylsiHGVgYHbYnY.gRbxFvYAscjLGemQyuFKOgfdIHZX();
			}
			bqZGqBIzNTyYxMylsiHGVgYHbYnY = kJfVUIHTZWqyrRKfDvTHrpSjAWCbA[RXuGgwWHVeknvlIdZiZOahpguNWC];
			if (bqZGqBIzNTyYxMylsiHGVgYHbYnY == null)
			{
				return;
			}
			bqZGqBIzNTyYxMylsiHGVgYHbYnY.MoZJSdTeUrnIGdICtVjSlWsnTsbS();
		}
		bool flag2 = false;
		if (bqZGqBIzNTyYxMylsiHGVgYHbYnY.KhXXBBjOlshVCrpGqLhiGQybfefk() is NAVKjTwkoXIYvQetesNxWnxqTxls)
		{
			flag2 = true;
		}
		else if (!(bqZGqBIzNTyYxMylsiHGVgYHbYnY.KhXXBBjOlshVCrpGqLhiGQybfefk() is IvdCrhIRctFmprzkMGAOwhyqGmSAA))
		{
			return;
		}
		if (num > 0)
		{
			MOzDsEUALMXdRJGjRfZIGidYYcpjA = MOzDsEUALMXdRJGjRfZIGidYYcpjA + num + " connected devices:\n";
		}
		for (int i = 0; i < num; i++)
		{
			MOzDsEUALMXdRJGjRfZIGidYYcpjA = MOzDsEUALMXdRJGjRfZIGidYYcpjA + kJfVUIHTZWqyrRKfDvTHrpSjAWCbA[i].OBosFxHATcRnGpKxwAxrkbwgossk() + "\n";
		}
		MOzDsEUALMXdRJGjRfZIGidYYcpjA += "\n";
		MOzDsEUALMXdRJGjRfZIGidYYcpjA = MOzDsEUALMXdRJGjRfZIGidYYcpjA + "Current RI device " + RXuGgwWHVeknvlIdZiZOahpguNWC + ": \"" + bqZGqBIzNTyYxMylsiHGVgYHbYnY.OBosFxHATcRnGpKxwAxrkbwgossk() + "\"\n";
		MOzDsEUALMXdRJGjRfZIGidYYcpjA += "(Press + or - to change monitored device id.)\n\n";
		uTbsLoPGmmolXWegmxjOIKQQmodq("Product Name", "\"" + bqZGqBIzNTyYxMylsiHGVgYHbYnY.OBosFxHATcRnGpKxwAxrkbwgossk() + "\"");
		uTbsLoPGmmolXWegmxjOIKQQmodq("Is Bluetooth Device", bqZGqBIzNTyYxMylsiHGVgYHbYnY.MSDFgxmNTZqzpjINLLfOLKzHjFlS());
		if (bqZGqBIzNTyYxMylsiHGVgYHbYnY.MSDFgxmNTZqzpjINLLfOLKzHjFlS())
		{
			uTbsLoPGmmolXWegmxjOIKQQmodq("Bluetooth Device Name", "\"" + bqZGqBIzNTyYxMylsiHGVgYHbYnY.KtRndMsDSENUeJRDGrPHjrJVqWgN() + "\"");
		}
		if (flag2)
		{
			uTbsLoPGmmolXWegmxjOIKQQmodq("Using Custom Driver", "TRUE");
		}
		uTbsLoPGmmolXWegmxjOIKQQmodq("Device Type", bqZGqBIzNTyYxMylsiHGVgYHbYnY.ypfdLwGUxwUPInJtAHgNrXNWJvm().ToString());
		uTbsLoPGmmolXWegmxjOIKQQmodq("Identifier", new PidVid(bqZGqBIzNTyYxMylsiHGVgYHbYnY.agosVptGdmYKOfzbFbPnoZnubZfb()));
		uTbsLoPGmmolXWegmxjOIKQQmodq("Product Id", bqZGqBIzNTyYxMylsiHGVgYHbYnY.xrMJnJVUEeiwuLWPrubKOBtBduOL());
		uTbsLoPGmmolXWegmxjOIKQQmodq("Vendor Id", bqZGqBIzNTyYxMylsiHGVgYHbYnY.XPSCcDiSAwLvvCsQJFSsRyynfPkZA());
		MOzDsEUALMXdRJGjRfZIGidYYcpjA += "\n";
		uTbsLoPGmmolXWegmxjOIKQQmodq("Axis Count", bqZGqBIzNTyYxMylsiHGVgYHbYnY.rvkkznfpWmWwhFicBJhBjddbeCucA());
		uTbsLoPGmmolXWegmxjOIKQQmodq("Button Count", bqZGqBIzNTyYxMylsiHGVgYHbYnY.geJdHZkcbotbNrDprJombxKAMHBuB());
		uTbsLoPGmmolXWegmxjOIKQQmodq("Hat Count", bqZGqBIzNTyYxMylsiHGVgYHbYnY.IHmZfslFCnqjuXZqjBxihbmxAmxm());
		MOzDsEUALMXdRJGjRfZIGidYYcpjA += "\n";
		if (flag)
		{
			string text = "";
			text = text + "Device Name: \"" + kJfVUIHTZWqyrRKfDvTHrpSjAWCbA[RXuGgwWHVeknvlIdZiZOahpguNWC].OBosFxHATcRnGpKxwAxrkbwgossk() + "\"\n";
			if (bqZGqBIzNTyYxMylsiHGVgYHbYnY.MSDFgxmNTZqzpjINLLfOLKzHjFlS())
			{
				text = text + "Bluetooth Device Name: \"" + bqZGqBIzNTyYxMylsiHGVgYHbYnY.KtRndMsDSENUeJRDGrPHjrJVqWgN() + "\"\n";
			}
			text = text + "Identifier: " + new PidVid(bqZGqBIzNTyYxMylsiHGVgYHbYnY.agosVptGdmYKOfzbFbPnoZnubZfb()).ToString() + "\n";
			Rewired.Logger.Log(text);
		}
		if (!flag2)
		{
			IvdCrhIRctFmprzkMGAOwhyqGmSAA ivdCrhIRctFmprzkMGAOwhyqGmSAA = bqZGqBIzNTyYxMylsiHGVgYHbYnY.KhXXBBjOlshVCrpGqLhiGQybfefk() as IvdCrhIRctFmprzkMGAOwhyqGmSAA;
			for (int j = 1; j < wYFbnpCSOnriIJINtEvnBkxPiOTr.Length - 1; j++)
			{
				int num2 = eYqOgpCpsEWtWsnWwVeEVhVWkuXF((RawInputAxis)PqqCdaPPgDJOyvyaKMmGPutdLWgw[j], 0, ivdCrhIRctFmprzkMGAOwhyqGmSAA);
				string text2 = wYFbnpCSOnriIJINtEvnBkxPiOTr[j];
				try
				{
					uTbsLoPGmmolXWegmxjOIKQQmodq(text2, num2 + " (" + GCVFDATOHAXbqUbVTUJVIWgJjdqv(num2) + ")");
				}
				catch
				{
					uTbsLoPGmmolXWegmxjOIKQQmodq(text2, "FAILED! Axis value = " + num2);
				}
			}
			if (ivdCrhIRctFmprzkMGAOwhyqGmSAA.AxPcVkANTwlOyLKJXBsgCIfJWqYx() > 0)
			{
				for (int k = 0; k < ivdCrhIRctFmprzkMGAOwhyqGmSAA.AxPcVkANTwlOyLKJXBsgCIfJWqYx(); k++)
				{
					int num3 = eYqOgpCpsEWtWsnWwVeEVhVWkuXF(RawInputAxis.Other, k, ivdCrhIRctFmprzkMGAOwhyqGmSAA);
					string text3 = "Other Axis " + k;
					try
					{
						uTbsLoPGmmolXWegmxjOIKQQmodq(text3, num3 + " (" + GCVFDATOHAXbqUbVTUJVIWgJjdqv(num3) + ")");
					}
					catch
					{
						uTbsLoPGmmolXWegmxjOIKQQmodq(text3, "FAILED! Axis value = " + num3);
					}
				}
			}
			int[] array = bqZGqBIzNTyYxMylsiHGVgYHbYnY.wqqhVIKRoIiRTAuiKrobCDAsBWDu();
			for (int l = 0; l < array.Length; l++)
			{
				int num4 = array[l];
				string text4 = "Hat " + l;
				uTbsLoPGmmolXWegmxjOIKQQmodq(text4, num4);
			}
			bool[] array2 = bqZGqBIzNTyYxMylsiHGVgYHbYnY.lvKgHNsSDCusvSMYvDMlCbpmruMIA();
			string text5 = "";
			for (int m = 0; m < array2.Length; m++)
			{
				if (array2[m])
				{
					if (text5 != "")
					{
						text5 += ", ";
					}
					text5 += m;
				}
			}
			uTbsLoPGmmolXWegmxjOIKQQmodq("Buttons ", text5);
		}
		else
		{
			NAVKjTwkoXIYvQetesNxWnxqTxls nAVKjTwkoXIYvQetesNxWnxqTxls = bqZGqBIzNTyYxMylsiHGVgYHbYnY.KhXXBBjOlshVCrpGqLhiGQybfefk() as NAVKjTwkoXIYvQetesNxWnxqTxls;
			for (int n = 0; n < bqZGqBIzNTyYxMylsiHGVgYHbYnY.rvkkznfpWmWwhFicBJhBjddbeCucA(); n++)
			{
				float num5 = nAVKjTwkoXIYvQetesNxWnxqTxls.eRlHXvAvTlOnQwIaNelFvRYqPthR(n);
				string text6 = n.ToString();
				try
				{
					uTbsLoPGmmolXWegmxjOIKQQmodq(text6, num5 + " (" + nAVKjTwkoXIYvQetesNxWnxqTxls.NRXaxuCHNrJeVwbLCzhzXJsmCZLu(n) + ")");
				}
				catch
				{
					uTbsLoPGmmolXWegmxjOIKQQmodq(text6, "FAILED! Axis value = " + num5);
				}
			}
			int[] array3 = bqZGqBIzNTyYxMylsiHGVgYHbYnY.wqqhVIKRoIiRTAuiKrobCDAsBWDu();
			for (int num6 = 0; num6 < bqZGqBIzNTyYxMylsiHGVgYHbYnY.IHmZfslFCnqjuXZqjBxihbmxAmxm(); num6++)
			{
				int num7 = array3[num6];
				string text7 = "Hat " + num6;
				uTbsLoPGmmolXWegmxjOIKQQmodq(text7, num7);
			}
			for (int num8 = 0; num8 < bqZGqBIzNTyYxMylsiHGVgYHbYnY.gcrJTHvOoqAbpNfYzwKSOiCeMPnw().get_GyroscopeCount(); num8++)
			{
				int wZSQuylCyoEekKiHKBdAEgzrWoHnA = bqZGqBIzNTyYxMylsiHGVgYHbYnY.gcrJTHvOoqAbpNfYzwKSOiCeMPnw().gyroscopes[num8].WZSQuylCyoEekKiHKBdAEgzrWoHnA;
				string text8 = "";
				for (int num9 = 0; num9 < wZSQuylCyoEekKiHKBdAEgzrWoHnA; num9++)
				{
					float num10 = bqZGqBIzNTyYxMylsiHGVgYHbYnY.gcrJTHvOoqAbpNfYzwKSOiCeMPnw().gyroscopes[num8].YAYnMednfYBUXhNTdquxcBMJaPTBB()[num9];
					text8 = text8 + "[" + num9 + "]: " + num10.ToString("f3");
					if (num9 < wZSQuylCyoEekKiHKBdAEgzrWoHnA - 1)
					{
						text8 += " ";
					}
				}
				uTbsLoPGmmolXWegmxjOIKQQmodq("Gyro " + num8, text8);
			}
			for (int num11 = 0; num11 < bqZGqBIzNTyYxMylsiHGVgYHbYnY.gcrJTHvOoqAbpNfYzwKSOiCeMPnw().get_AccelerometerCount(); num11++)
			{
				int lqrjHOrYQIwCeTxhjbjUgPeLGwOh = bqZGqBIzNTyYxMylsiHGVgYHbYnY.gcrJTHvOoqAbpNfYzwKSOiCeMPnw().accelerometers[num11].lqrjHOrYQIwCeTxhjbjUgPeLGwOh;
				string text9 = "";
				for (int num12 = 0; num12 < lqrjHOrYQIwCeTxhjbjUgPeLGwOh; num12++)
				{
					float num13 = bqZGqBIzNTyYxMylsiHGVgYHbYnY.gcrJTHvOoqAbpNfYzwKSOiCeMPnw().accelerometers[num11].kHKNsnXlXktGYBPiLEFMIeDjXJlhA[num12];
					text9 = text9 + "[" + num12 + "]: " + num13.ToString("f3");
					if (num12 < lqrjHOrYQIwCeTxhjbjUgPeLGwOh - 1)
					{
						text9 += " ";
					}
				}
				uTbsLoPGmmolXWegmxjOIKQQmodq("Accelerometer " + num11, text9);
			}
			for (int num14 = 0; num14 < bqZGqBIzNTyYxMylsiHGVgYHbYnY.gcrJTHvOoqAbpNfYzwKSOiCeMPnw().get_TouchpadCount(); num14++)
			{
				nLbAcapOagdnNrGGiTONDGTEQuzQ nLbAcapOagdnNrGGiTONDGTEQuzQ2 = bqZGqBIzNTyYxMylsiHGVgYHbYnY.gcrJTHvOoqAbpNfYzwKSOiCeMPnw().touchpads[num14];
				int num15 = nLbAcapOagdnNrGGiTONDGTEQuzQ2.eRxGPKHfVUSoUvYtfLqInWzRcIsH.Length;
				string text10 = "";
				for (int num16 = 0; num16 < num15; num16++)
				{
					nLbAcapOagdnNrGGiTONDGTEQuzQ.TouchData touchData = nLbAcapOagdnNrGGiTONDGTEQuzQ2.eRxGPKHfVUSoUvYtfLqInWzRcIsH[num16];
					text10 = text10 + "Touch " + num16 + ": Is Touching = " + touchData.isTouching + "\n";
					text10 = text10 + "Touch " + num16 + ": Touch Id = " + touchData.touchId + "\n";
					text10 = text10 + "Touch " + num16 + ": Position = " + touchData.positionX + ", " + touchData.positionY + "\n";
					text10 = text10 + "Touch " + num16 + ": Abs Position = " + touchData.positionAbsX + ", " + touchData.positionAbsY + " (" + touchData.positionRawX + ", " + touchData.positionRawY + ")\n";
				}
				WSRjBGHkTjfxgFNDzpiYbfWYlkzfA("Touchpad " + num14, text10);
			}
			bool[] array4 = bqZGqBIzNTyYxMylsiHGVgYHbYnY.lvKgHNsSDCusvSMYvDMlCbpmruMIA();
			string text11 = "";
			for (int num17 = 0; num17 < array4.Length; num17++)
			{
				if (array4[num17])
				{
					if (text11 != "")
					{
						text11 += ", ";
					}
					text11 += num17;
				}
			}
			uTbsLoPGmmolXWegmxjOIKQQmodq("Buttons ", text11);
		}
		RmIEfagqwuNNImrWrrTsgRPFoFjr.text = MOzDsEUALMXdRJGjRfZIGidYYcpjA;
	}

	void IElementIdentifierTool.Update()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Update
		this.Update();
	}

	public void OnDestroy()
	{
		if (bqZGqBIzNTyYxMylsiHGVgYHbYnY != null)
		{
			bqZGqBIzNTyYxMylsiHGVgYHbYnY.gRbxFvYAscjLGemQyuFKOgfdIHZX();
		}
	}

	void IElementIdentifierTool.OnDestroy()
	{
		//ILSpy generated this explicit interface implementation from .override directive in OnDestroy
		this.OnDestroy();
	}

	private void PNZFazqSnWdiqZFYuWXPSrRAaSSj()
	{
		kJfVUIHTZWqyrRKfDvTHrpSjAWCbA = hGOfBefMpJEuDgwIfuTkcRJHHUji.GetJoysticks<hAqIKBCgLbWxaUEriKlSsXEPBcNeA>();
	}

	private void iWSrqUXsxsiRKyQdQIgFDuYbeurj()
	{
		ABbtrbblpSFTAGBuhfjSKoJOHmMf();
	}

	private void zEEtcxgBcOSHxdVYKvAMwKJpdvKd()
	{
		ABbtrbblpSFTAGBuhfjSKoJOHmMf();
	}

	private void ABbtrbblpSFTAGBuhfjSKoJOHmMf()
	{
		EjMpVGEJnYajtGbRTjqmFJrLmQhbb();
		gVTNMePuaxhoaUnncEpRkPsxtJKF = true;
	}

	private void EjMpVGEJnYajtGbRTjqmFJrLmQhbb()
	{
		RXuGgwWHVeknvlIdZiZOahpguNWC = 0;
		bqZGqBIzNTyYxMylsiHGVgYHbYnY = null;
		beRpESdzmQufBWxTPHmRLwALraQn = Guid.Empty;
		kJfVUIHTZWqyrRKfDvTHrpSjAWCbA = null;
		wVLDXtacOtwCkOwQvlTTZoVvDOsM = false;
		gVTNMePuaxhoaUnncEpRkPsxtJKF = false;
	}

	private void uTbsLoPGmmolXWegmxjOIKQQmodq(string P_0, object P_1)
	{
		MOzDsEUALMXdRJGjRfZIGidYYcpjA = MOzDsEUALMXdRJGjRfZIGidYYcpjA + P_0 + " = " + P_1.ToString() + "\n";
	}

	private void WSRjBGHkTjfxgFNDzpiYbfWYlkzfA(string P_0, object P_1)
	{
		MOzDsEUALMXdRJGjRfZIGidYYcpjA = MOzDsEUALMXdRJGjRfZIGidYYcpjA + P_0 + ":\n" + P_1.ToString() + "\n";
	}

	private int eYqOgpCpsEWtWsnWwVeEVhVWkuXF(RawInputAxis P_0, int P_1, IvdCrhIRctFmprzkMGAOwhyqGmSAA P_2)
	{
		return P_2.QXnalpglVNeJlmdHUfjdvevqwStm(P_0, P_1);
	}

	private float GCVFDATOHAXbqUbVTUJVIWgJjdqv(int P_0)
	{
		if (P_0 == 0)
		{
			return 0f;
		}
		return MathTools.Clamp((float)MathTools.Abs(P_0) / 65535f * (float)MathTools.Sign(P_0), -1f, 1f);
	}
}
