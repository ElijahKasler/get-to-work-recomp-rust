using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Rewired.Platforms;
using Rewired.Utils;
using UnityEngine;

namespace Rewired.Dev.Tools;

public class DebugInformation : MonoBehaviour
{
	private class ZOleBpQBDPKbvuUhjSPabaYrCsjZ : IDisposable
	{
		public readonly bool WAyeTACitBLRzRlrBpnKHQReGTZjc;

		public ZOleBpQBDPKbvuUhjSPabaYrCsjZ(string P_0, string P_1, IDictionary<string, bool> P_2)
		{
			WAyeTACitBLRzRlrBpnKHQReGTZjc = LAOyqrvBReYHCtrinopcGLmjRXCD(P_0, P_1, P_2);
			XTwvIjnPmBwuZIreqQMONOechNlfA.qftcbsenDOlohtEcgsseQxcPbTZgb(XTwvIjnPmBwuZIreqQMONOechNlfA.TtocDbzjSdpARVfOvVmQWKGsBoFy() + 1);
		}

		private bool LAOyqrvBReYHCtrinopcGLmjRXCD(string P_0, string P_1, IDictionary<string, bool> P_2)
		{
			return kYwyUtXLBNDmMaHBqwUVcFmRHrYLA(P_1, GUILayout.Toggle(pGsUWFNQxVeyfZMMbCipDevKGgsFA(P_1, P_2), new GUIContent(P_0, P_0), GetToggleStyle()), P_2);
		}

		private bool pGsUWFNQxVeyfZMMbCipDevKGgsFA(string P_0, IDictionary<string, bool> P_1)
		{
			if (!P_1.ContainsKey(P_0))
			{
				P_1.Add(P_0, value: false);
			}
			return P_1[P_0];
		}

		private bool kYwyUtXLBNDmMaHBqwUVcFmRHrYLA(string P_0, bool P_1, IDictionary<string, bool> P_2)
		{
			if (!P_2.ContainsKey(P_0))
			{
				P_2.Add(P_0, P_1);
			}
			else
			{
				P_2[P_0] = P_1;
			}
			return P_1;
		}

		public void Dispose()
		{
			XTwvIjnPmBwuZIreqQMONOechNlfA.qftcbsenDOlohtEcgsseQxcPbTZgb(XTwvIjnPmBwuZIreqQMONOechNlfA.TtocDbzjSdpARVfOvVmQWKGsBoFy() - 1);
		}

		void IDisposable.Dispose()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Dispose
			this.Dispose();
		}
	}

	private static class XTwvIjnPmBwuZIreqQMONOechNlfA
	{
		private static int gQZLciLpfHLFJUgMBdJRBtSCSbdJA;

		public static int HkGlKtzitirOblKKNBjTaLsNiNkcA
		{
			get
			{
				return TtocDbzjSdpARVfOvVmQWKGsBoFy();
			}
			set
			{
				qftcbsenDOlohtEcgsseQxcPbTZgb(num);
			}
		}

		public static int TtocDbzjSdpARVfOvVmQWKGsBoFy()
		{
			return gQZLciLpfHLFJUgMBdJRBtSCSbdJA;
		}

		public static void qftcbsenDOlohtEcgsseQxcPbTZgb(int P_0)
		{
			gQZLciLpfHLFJUgMBdJRBtSCSbdJA = Mathf.Max(0, P_0);
		}
	}

	private static class ODamYsBvIrppZTfOxwvNniVIDSXgA
	{
		public static void GHYerIxQfkgGTVwaiZooTEYNESbt()
		{
			GUILayout.BeginHorizontal();
		}

		public static void bpPQWIuffDRiVrDfHUStQuXfkFkB()
		{
			GUILayout.EndHorizontal();
		}

		public static void nfhhaszRbdlBKBOoJhQVwPpvfmzA()
		{
			GUILayout.BeginVertical();
		}

		public static void jXygkpIDsXnQjXJBaWbgDiHlehOzA()
		{
			GUILayout.EndVertical();
		}

		public static void RNofFrhaywxsMeGWPhApCEjKBCwhc(string P_0, KTSSvHAZKWMVPYgKzzAGhyTDjIfV P_1)
		{
			GUILayout.Label(P_0, QMjmuhwMXMJrbgpeHBqVlyCeVWGe());
		}

		public static void pIztTgpXiwcxOQglMlvtVSQDhJtp(string P_0, string P_1)
		{
			GUILayout.Label(P_0 + ": " + P_1, QMjmuhwMXMJrbgpeHBqVlyCeVWGe());
		}

		public static void PGWgoVdvhARnAXnOrnihOLnkPGH(string P_0, AnimationCurve P_1)
		{
			GUILayout.Label(P_0 + ": Curves are not visualized by this tool.");
		}

		public static bool RPcDNfxpsrLoqPnHgjiTCwZHTZBm(string P_0, bool P_1)
		{
			return GUILayout.Toggle(P_1, P_0, QMjmuhwMXMJrbgpeHBqVlyCeVWGe());
		}
	}

	private static class yVQKTlNppKZTLqxXNungSCuoYiIv
	{
		[CompilerGenerated]
		private static float pXZSFZCScbnOQtKrBhrPJmyADfpAb;

		[CompilerGenerated]
		private static float rimNHSDpWKxyaVILoOaESthEPjjO;

		public static float dqoCrTXqyEqOCpZmaqZEvPpZgWMr
		{
			get
			{
				return DrAgxgOCMnXGFXSBlEJosSpPqTeY();
			}
			set
			{
				vgWTXVtDDgdZDGJkmikYxEqJPUXvA(num);
			}
		}

		public static float QWAQbyTBZLHkoFLWKJUEvlatBENG
		{
			get
			{
				return tJfBJrJFhlLqpRDmvyKhGbTIqLrbb();
			}
			set
			{
				DfKmrzvIUPEJecfFZSNcytAnEfOCb(num);
			}
		}

		public static float DrAgxgOCMnXGFXSBlEJosSpPqTeY()
		{
			return pXZSFZCScbnOQtKrBhrPJmyADfpAb;
		}

		public static void vgWTXVtDDgdZDGJkmikYxEqJPUXvA(float P_0)
		{
			pXZSFZCScbnOQtKrBhrPJmyADfpAb = P_0;
		}

		public static float tJfBJrJFhlLqpRDmvyKhGbTIqLrbb()
		{
			return rimNHSDpWKxyaVILoOaESthEPjjO;
		}

		public static void DfKmrzvIUPEJecfFZSNcytAnEfOCb(float P_0)
		{
			rimNHSDpWKxyaVILoOaESthEPjjO = P_0;
		}
	}

	internal enum KTSSvHAZKWMVPYgKzzAGhyTDjIfV
	{
		None = 0,
		Info = 1,
		Warning = 2,
		Error = 3
	}

	[Serializable]
	private sealed class IlxSaLNgaVqbsDMvUEMVRqSNsFLm
	{
		public static readonly IlxSaLNgaVqbsDMvUEMVRqSNsFLm _003C_003E9 = new IlxSaLNgaVqbsDMvUEMVRqSNsFLm();

		public static Comparison<InputAction> _003C_003E9__17_0;

		internal int GpodNQApsjoQzGkIAhefEsYBBQdXc(InputAction P_0, InputAction P_1)
		{
			return P_0.name.CompareTo(P_1.name);
		}
	}

	private sealed class NLWUhNVPnPbaIUWrJmkFSesrOmiX
	{
		public InputCategory ujdMGuKttiBpXDmuPJfORfBydigfA;

		internal bool VkUXghrFsGUzwZIpOSsdjDIcnYmo(InputAction P_0)
		{
			return P_0.categoryId == ujdMGuKttiBpXDmuPJfORfBydigfA.id;
		}
	}

	[CustomObfuscation(rename = false)]
	[SerializeField]
	private int _fontSize = 13;

	private static DebugInformation FuEXgLuieehllyvcAYbRgRRSyvag;

	private IDictionary<string, bool> rgOGCbIzjiKoaQjoNablctiEQQXAc = new Dictionary<string, bool>();

	private static Vector2 GxSNdcVgAJtuxKLVqudjyjBnIOHi;

	private const string IYGqEZzRRgDyUlDHfMeuiSuQhcfp = "Rewired_DebugInformation";

	private const string duRDfujjIDdiXWjzUgewjTuWqiqyA = "Rewired Debug Information";

	private const int KscXerjnbdCXGbCchQWSOgbuzXatA = 20;

	[CustomObfuscation(rename = false)]
	private void OnEnable()
	{
		FuEXgLuieehllyvcAYbRgRRSyvag = this;
		if (rgOGCbIzjiKoaQjoNablctiEQQXAc.Count == 0)
		{
			rgOGCbIzjiKoaQjoNablctiEQQXAc.Add("Rewired_DebugInformation", value: true);
		}
	}

	[CustomObfuscation(rename = false)]
	private void OnDisable()
	{
		if (FuEXgLuieehllyvcAYbRgRRSyvag == this)
		{
			FuEXgLuieehllyvcAYbRgRRSyvag = null;
		}
	}

	[CustomObfuscation(rename = false)]
	private void OnGUI()
	{
		XTwvIjnPmBwuZIreqQMONOechNlfA.qftcbsenDOlohtEcgsseQxcPbTZgb(0);
		GUILayout.BeginArea(new Rect(0f, 0f, Screen.width, Screen.height));
		GxSNdcVgAJtuxKLVqudjyjBnIOHi = GUILayout.BeginScrollView(GxSNdcVgAJtuxKLVqudjyjBnIOHi, GUILayout.ExpandWidth(expand: true), GUILayout.ExpandHeight(expand: true));
		DrawDebugInformation(enabled: true, rgOGCbIzjiKoaQjoNablctiEQQXAc);
		GUILayout.EndScrollView();
		GUILayout.EndArea();
	}

	public static void DrawDebugInformation(bool enabled, IDictionary<string, bool> foldouts)
	{
		bool num = GUI.enabled;
		if (!ReInput.isReady || !enabled)
		{
			GUI.enabled = false;
		}
		ODamYsBvIrppZTfOxwvNniVIDSXgA.GHYerIxQfkgGTVwaiZooTEYNESbt();
		GUILayout.FlexibleSpace();
		ODamYsBvIrppZTfOxwvNniVIDSXgA.bpPQWIuffDRiVrDfHUStQuXfkFkB();
		Rect lastRect = GUILayoutUtility.GetLastRect();
		float num2 = lastRect.width / 3f;
		yVQKTlNppKZTLqxXNungSCuoYiIv.vgWTXVtDDgdZDGJkmikYxEqJPUXvA(lastRect.width - num2);
		yVQKTlNppKZTLqxXNungSCuoYiIv.DfKmrzvIUPEJecfFZSNcytAnEfOCb(num2);
		BctjiTHBbjvALAmqcUCgHATKqQNfb(enabled, foldouts);
		GUI.enabled = num;
		yVQKTlNppKZTLqxXNungSCuoYiIv.vgWTXVtDDgdZDGJkmikYxEqJPUXvA(0f);
		yVQKTlNppKZTLqxXNungSCuoYiIv.DfKmrzvIUPEJecfFZSNcytAnEfOCb(0f);
	}

	private static void BctjiTHBbjvALAmqcUCgHATKqQNfb(bool P_0, IDictionary<string, bool> P_1)
	{
		using ZOleBpQBDPKbvuUhjSPabaYrCsjZ zOleBpQBDPKbvuUhjSPabaYrCsjZ = new ZOleBpQBDPKbvuUhjSPabaYrCsjZ("Rewired Debug Information", "Rewired_DebugInformation", P_1);
		if (!ReInput.isReady || !P_0)
		{
			GUILayout.Label("There is no active Rewired Input Manager in the scene.");
		}
		else
		{
			if (!zOleBpQBDPKbvuUhjSPabaYrCsjZ.WAyeTACitBLRzRlrBpnKHQReGTZjc)
			{
				return;
			}
			xpNYKfHjyyzeQQXhOwlJyTChNOSC(P_1, "Rewired_DebugInformation");
			bool flag = ReInput.configuration.disableNativeInput;
			if (!flag && (ReInput.currentPlatform == Platform.Windows || ReInput.currentPlatform == Platform.OSX) && ReInput.primaryInputManager.inputSourceType == InputSource.Fallback)
			{
				flag = true;
			}
			if (flag)
			{
				ODamYsBvIrppZTfOxwvNniVIDSXgA.RNofFrhaywxsMeGWPhApCEjKBCwhc("Native input is disabled. Many special features are unavailable without native input.", KTSSvHAZKWMVPYgKzzAGhyTDjIfV.Warning);
			}
			KbfAGuGrawfLDcnbEsSDBVpoystX(P_1, "Rewired_DebugInformation");
			string text = "Rewired_DebugInformation_controllers";
			using ZOleBpQBDPKbvuUhjSPabaYrCsjZ zOleBpQBDPKbvuUhjSPabaYrCsjZ2 = new ZOleBpQBDPKbvuUhjSPabaYrCsjZ("Controllers", text, P_1);
			if (zOleBpQBDPKbvuUhjSPabaYrCsjZ2.WAyeTACitBLRzRlrBpnKHQReGTZjc)
			{
				jThCfQAMLnWFBUJeHhajBEIaNhXf(ReInput.controllers.Joysticks, P_1, text);
				lSxxQnUhAPPwFoOCwjolMAZHHIGd(ReInput.controllers.CustomControllers, P_1, text);
				vrtGjWeBQFcZTDzqTrcFasLZYUu(P_1, "Rewired_DebugInformation");
				IPDJxnmefsDzPuqCHZjUmnFzWjWl(P_1, "Rewired_DebugInformation");
			}
			return;
		}
	}

	private static void xpNYKfHjyyzeQQXhOwlJyTChNOSC(IDictionary<string, bool> P_0, string P_1)
	{
		string text = P_1 + "_info";
		using ZOleBpQBDPKbvuUhjSPabaYrCsjZ zOleBpQBDPKbvuUhjSPabaYrCsjZ = new ZOleBpQBDPKbvuUhjSPabaYrCsjZ("Info", text, P_0);
		if (zOleBpQBDPKbvuUhjSPabaYrCsjZ.WAyeTACitBLRzRlrBpnKHQReGTZjc)
		{
			ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Rewired Version", ReInput.programVersion);
			ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Platform", ReInput.currentPlatform.ToString());
			ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Primary Input Source", ReInput.primaryInputManager.inputSourceType.ToString());
			if (ReInput.currentPlatform == Platform.Windows)
			{
				ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Use Windows Gaming Input", ReInput.configuration.useWindowsGamingInput.ToString());
				ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Use XInput", ReInput.configuration.useXInput.ToString());
			}
			else if (ReInput.currentPlatform == Platform.WindowsUWP)
			{
				ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Support HID Devices", ReInput.configuration.windowsUWPSupportHIDDevices.ToString());
				ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Support Gamepads", ReInput.configuration.windowsUWPSupportGamepads.ToString());
			}
			else if (ReInput.currentPlatform == Platform.OSX)
			{
				ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Use Game Controller Framework", ReInput.configuration.useAppleGameControllerFramework.ToString());
			}
			ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Enhanced Device Support", ReInput.configuration.enhancedDeviceSupport.ToString());
			ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Native Keyboard Handling", ReInput.configuration.nativeKeyboardSupport.ToString());
			ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Physical Key Mapping", ReInput.configVars.unityUsePhysicalKeys.ToString());
			ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Native Mouse Handling", ReInput.configuration.nativeMouseSupport.ToString());
			ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Ignore Input When App Not in Focus", ReInput.configuration.ignoreInputWhenAppNotInFocus.ToString());
		}
	}

	private static void KbfAGuGrawfLDcnbEsSDBVpoystX(IDictionary<string, bool> P_0, string P_1)
	{
		string text = P_1 + "_players";
		using ZOleBpQBDPKbvuUhjSPabaYrCsjZ zOleBpQBDPKbvuUhjSPabaYrCsjZ = new ZOleBpQBDPKbvuUhjSPabaYrCsjZ("Players (" + ReInput.players.allPlayerCount + ")", text, P_0);
		if (zOleBpQBDPKbvuUhjSPabaYrCsjZ.WAyeTACitBLRzRlrBpnKHQReGTZjc)
		{
			int playerCount = ReInput.players.playerCount;
			for (int i = 0; i < playerCount; i++)
			{
				gBLOZyyZwfTgvDGZulSaMUWBtOrJ(ReInput.players.GetPlayer(i), i, P_0, text);
			}
			gBLOZyyZwfTgvDGZulSaMUWBtOrJ(ReInput.players.SystemPlayer, -1, P_0, text);
		}
	}

	private static void jThCfQAMLnWFBUJeHhajBEIaNhXf(IList<Joystick> P_0, IDictionary<string, bool> P_1, string P_2)
	{
		int num = P_0?.Count ?? 0;
		using ZOleBpQBDPKbvuUhjSPabaYrCsjZ zOleBpQBDPKbvuUhjSPabaYrCsjZ = new ZOleBpQBDPKbvuUhjSPabaYrCsjZ("Joysticks (" + num + ")", P_2 + "_joysticks", P_1);
		if (!zOleBpQBDPKbvuUhjSPabaYrCsjZ.WAyeTACitBLRzRlrBpnKHQReGTZjc)
		{
			return;
		}
		for (int i = 0; i < num; i++)
		{
			Joystick joystick = P_0[i];
			int id = joystick.id;
			string text = P_2 + "_joystick" + id;
			using ZOleBpQBDPKbvuUhjSPabaYrCsjZ zOleBpQBDPKbvuUhjSPabaYrCsjZ2 = new ZOleBpQBDPKbvuUhjSPabaYrCsjZ(i + ": " + ((joystick.name == "Unknown Controller") ? joystick.hardwareName : joystick.name), text, P_1);
			if (!zOleBpQBDPKbvuUhjSPabaYrCsjZ2.WAyeTACitBLRzRlrBpnKHQReGTZjc)
			{
				continue;
			}
			id = joystick.id;
			ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Id (unique id)", id.ToString());
			ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Name", joystick.name);
			ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Hardware Name", joystick.hardwareName);
			ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Is Recognized", (joystick.hardwareTypeGuid != Guid.Empty).ToString());
			ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Enabled", joystick.enabled.ToString());
			string text2 = string.Empty;
			for (int j = 0; j < ReInput.players.allPlayerCount; j++)
			{
				Player player = ReInput.players.AllPlayers[j];
				if (ReInput.controllers.IsJoystickAssignedToPlayer(joystick.id, player.id))
				{
					if (text2 != string.Empty)
					{
						text2 += ", ";
					}
					text2 += ((player.id == 9999999) ? "System" : player.id.ToString());
				}
			}
			ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Assigned to Players", (!string.IsNullOrEmpty(text2)) ? text2 : "None");
			ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("System Id", joystick.systemId.ToString());
			ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Unity Id", ReInput.usingUnityInput ? joystick.unityId.ToString() : "--");
			ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Hardware Type Guid", joystick.hardwareTypeGuid.ToString());
			ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Hardware Identifier", joystick.hardwareIdentifier);
			ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Device Instance Guid", joystick.deviceInstanceGuid.ToString());
			ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Tag", joystick.tag);
			vhDyGrJioNbkVHEpWcdDBolKPZJQ(joystick.Axes, P_1, text);
			mxymFuqxmxDvxgpwOASPusMcYlrI(joystick.Buttons, ControllerType.Joystick, P_1, text);
			ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Axis2D Count", joystick.axis2DCount.ToString());
			ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Hat Count", joystick.hatCount.ToString());
			ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("D-Pad Count", joystick.directionalPadCount.ToString());
			dfMbbJbSAHKkIidmChbuvTvlaxoeA(joystick, P_1, text);
			CalibrationMap calibrationMap = joystick.calibrationMap;
			using (ZOleBpQBDPKbvuUhjSPabaYrCsjZ zOleBpQBDPKbvuUhjSPabaYrCsjZ3 = new ZOleBpQBDPKbvuUhjSPabaYrCsjZ("Calibration Map", text + "_calibrationMap", P_1))
			{
				if (zOleBpQBDPKbvuUhjSPabaYrCsjZ3.WAyeTACitBLRzRlrBpnKHQReGTZjc)
				{
					int axisCount = calibrationMap.axisCount;
					for (int k = 0; k < axisCount; k++)
					{
						AxisCalibration axisCalibration = calibrationMap.Axes[k];
						using ZOleBpQBDPKbvuUhjSPabaYrCsjZ zOleBpQBDPKbvuUhjSPabaYrCsjZ4 = new ZOleBpQBDPKbvuUhjSPabaYrCsjZ(k + ": Axis Calibration (" + (axisCalibration.enabled ? "Enabled" : "Disabled") + ")", text + "_AxisCalibration" + k, P_1);
						if (zOleBpQBDPKbvuUhjSPabaYrCsjZ4.WAyeTACitBLRzRlrBpnKHQReGTZjc)
						{
							ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Enabled", axisCalibration.enabled.ToString());
							ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Apply Range Calibration", axisCalibration.applyRangeCalibration.ToString());
							ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Calibrated Max", axisCalibration.calibratedMax.ToString());
							ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Calibrated Min", axisCalibration.calibratedMin.ToString());
							ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Calibrated Zero", axisCalibration.calibratedZero.ToString());
							ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Dead Zone", axisCalibration.deadZone.ToString());
							ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Invert", axisCalibration.invert.ToString());
							ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Sensitivity Type", axisCalibration.sensitivityType.ToString());
							ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Sensitivity", axisCalibration.sensitivity.ToString());
							if (axisCalibration.sensitivityCurve != null)
							{
								bool num2 = GUI.enabled;
								GUI.enabled = false;
								ODamYsBvIrppZTfOxwvNniVIDSXgA.PGWgoVdvhARnAXnOrnihOLnkPGH("Sensitivity Curve", axisCalibration.sensitivityCurve);
								GUI.enabled = num2;
							}
							else
							{
								ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Sensitivity Curve", "--");
							}
						}
					}
				}
			}
			ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Supports Vibration", joystick.supportsVibration.ToString());
			ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Vibration Motor Count", joystick.vibrationMotorCount.ToString());
			ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Has Extension", (joystick.extension != null).ToString());
			ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Extension Type", (joystick.extension != null) ? joystick.extension.GetType().Name : "--");
			HsTPYzosyktiPKKWpYtkxklDEHcM(joystick, P_1, text);
		}
	}

	private static void vrtGjWeBQFcZTDzqTrcFasLZYUu(IDictionary<string, bool> P_0, string P_1)
	{
		string text = P_1 + "_mouse";
		using ZOleBpQBDPKbvuUhjSPabaYrCsjZ zOleBpQBDPKbvuUhjSPabaYrCsjZ = new ZOleBpQBDPKbvuUhjSPabaYrCsjZ("Mouse", text, P_0);
		if (!zOleBpQBDPKbvuUhjSPabaYrCsjZ.WAyeTACitBLRzRlrBpnKHQReGTZjc)
		{
			return;
		}
		Mouse mouse = ReInput.controllers.Mouse;
		ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Enabled", mouse.enabled.ToString());
		string text2 = string.Empty;
		for (int i = 0; i < ReInput.players.allPlayerCount; i++)
		{
			Player player = ReInput.players.AllPlayers[i];
			if (player.controllers.hasMouse)
			{
				if (text2 != string.Empty)
				{
					text2 += ", ";
				}
				text2 += ((player.id == 9999999) ? "System" : player.id.ToString());
			}
		}
		ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Assigned to Players", (!string.IsNullOrEmpty(text2)) ? text2 : "None");
		ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Screen Position", mouse.screenPosition.ToString());
		ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Screen Position Prev", mouse.screenPositionPrev.ToString());
		ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Screen Position Delta", mouse.screenPositionDelta.ToString());
		vhDyGrJioNbkVHEpWcdDBolKPZJQ(mouse.Axes, P_0, text);
		mxymFuqxmxDvxgpwOASPusMcYlrI(mouse.Buttons, ControllerType.Mouse, P_0, text);
		dfMbbJbSAHKkIidmChbuvTvlaxoeA(mouse, P_0, text);
		HsTPYzosyktiPKKWpYtkxklDEHcM(mouse, P_0, text);
	}

	private static void IPDJxnmefsDzPuqCHZjUmnFzWjWl(IDictionary<string, bool> P_0, string P_1)
	{
		string text = P_1 + "_keyboard";
		using ZOleBpQBDPKbvuUhjSPabaYrCsjZ zOleBpQBDPKbvuUhjSPabaYrCsjZ = new ZOleBpQBDPKbvuUhjSPabaYrCsjZ("Keyboard", text, P_0);
		if (!zOleBpQBDPKbvuUhjSPabaYrCsjZ.WAyeTACitBLRzRlrBpnKHQReGTZjc)
		{
			return;
		}
		Keyboard keyboard = ReInput.controllers.Keyboard;
		ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Enabled", keyboard.enabled.ToString());
		string text2 = string.Empty;
		for (int i = 0; i < ReInput.players.allPlayerCount; i++)
		{
			Player player = ReInput.players.AllPlayers[i];
			if (player.controllers.hasKeyboard)
			{
				if (text2 != string.Empty)
				{
					text2 += ", ";
				}
				text2 += ((player.id == 9999999) ? "System" : player.id.ToString());
			}
		}
		ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Assigned to Players", (!string.IsNullOrEmpty(text2)) ? text2 : "None");
		mxymFuqxmxDvxgpwOASPusMcYlrI(keyboard.Buttons, ControllerType.Keyboard, P_0, text);
		dfMbbJbSAHKkIidmChbuvTvlaxoeA(keyboard, P_0, text);
		HsTPYzosyktiPKKWpYtkxklDEHcM(keyboard, P_0, text);
	}

	private static void lSxxQnUhAPPwFoOCwjolMAZHHIGd(IList<CustomController> P_0, IDictionary<string, bool> P_1, string P_2)
	{
		int num = P_0?.Count ?? 0;
		using ZOleBpQBDPKbvuUhjSPabaYrCsjZ zOleBpQBDPKbvuUhjSPabaYrCsjZ = new ZOleBpQBDPKbvuUhjSPabaYrCsjZ("Custom Controllers (" + num + ")", P_2 + "_customControllers", P_1);
		if (!zOleBpQBDPKbvuUhjSPabaYrCsjZ.WAyeTACitBLRzRlrBpnKHQReGTZjc)
		{
			return;
		}
		for (int i = 0; i < num; i++)
		{
			CustomController customController = P_0[i];
			int id = customController.id;
			string text = P_2 + "_customController" + id;
			using ZOleBpQBDPKbvuUhjSPabaYrCsjZ zOleBpQBDPKbvuUhjSPabaYrCsjZ2 = new ZOleBpQBDPKbvuUhjSPabaYrCsjZ(i + ": " + customController.name, text, P_1);
			if (!zOleBpQBDPKbvuUhjSPabaYrCsjZ2.WAyeTACitBLRzRlrBpnKHQReGTZjc)
			{
				continue;
			}
			id = customController.id;
			ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Id", id.ToString());
			ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Name", customController.name);
			ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Hardware Name", customController.hardwareName);
			ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Tag", customController.tag);
			ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Hardware Identifier", customController.hardwareIdentifier);
			ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Enabled", customController.enabled.ToString());
			string text2 = string.Empty;
			for (int j = 0; j < ReInput.players.allPlayerCount; j++)
			{
				Player player = ReInput.players.AllPlayers[j];
				if (ReInput.controllers.IsCustomControllerAssignedToPlayer(customController.id, player.id))
				{
					if (text2 != string.Empty)
					{
						text2 += ", ";
					}
					text2 += ((player.id == 9999999) ? "System" : player.id.ToString());
				}
			}
			ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Assigned to Players", (!string.IsNullOrEmpty(text2)) ? text2 : "None");
			vhDyGrJioNbkVHEpWcdDBolKPZJQ(customController.Axes, P_1, text);
			mxymFuqxmxDvxgpwOASPusMcYlrI(customController.Buttons, ControllerType.Custom, P_1, text);
			ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Axis2D Count", customController.axis2DCount.ToString());
			using (ZOleBpQBDPKbvuUhjSPabaYrCsjZ zOleBpQBDPKbvuUhjSPabaYrCsjZ3 = new ZOleBpQBDPKbvuUhjSPabaYrCsjZ("Element Identifiers", text + "_elementIdentifiers", P_1))
			{
				if (zOleBpQBDPKbvuUhjSPabaYrCsjZ3.WAyeTACitBLRzRlrBpnKHQReGTZjc)
				{
					int num2 = ((customController.AxisElementIdentifiers != null) ? customController.AxisElementIdentifiers.Count : 0);
					using (ZOleBpQBDPKbvuUhjSPabaYrCsjZ zOleBpQBDPKbvuUhjSPabaYrCsjZ4 = new ZOleBpQBDPKbvuUhjSPabaYrCsjZ("Axis Element Identifiers (" + num2 + ")", text + "_axisEIs", P_1))
					{
						if (zOleBpQBDPKbvuUhjSPabaYrCsjZ4.WAyeTACitBLRzRlrBpnKHQReGTZjc)
						{
							for (int k = 0; k < num2; k++)
							{
								ControllerElementIdentifier controllerElementIdentifier = customController.AxisElementIdentifiers[k];
								using ZOleBpQBDPKbvuUhjSPabaYrCsjZ zOleBpQBDPKbvuUhjSPabaYrCsjZ5 = new ZOleBpQBDPKbvuUhjSPabaYrCsjZ(k + ": " + controllerElementIdentifier.get_name() + " (id: " + controllerElementIdentifier.get_id() + ")", text + "_AxisEI" + k + "_" + controllerElementIdentifier.get_name(), P_1);
								if (zOleBpQBDPKbvuUhjSPabaYrCsjZ5.WAyeTACitBLRzRlrBpnKHQReGTZjc)
								{
									ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Id", controllerElementIdentifier.get_id().ToString());
									ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Name", controllerElementIdentifier.get_name());
								}
							}
						}
					}
					num2 = ((customController.ButtonElementIdentifiers != null) ? customController.ButtonElementIdentifiers.Count : 0);
					using ZOleBpQBDPKbvuUhjSPabaYrCsjZ zOleBpQBDPKbvuUhjSPabaYrCsjZ6 = new ZOleBpQBDPKbvuUhjSPabaYrCsjZ("Button Element Identifiers (" + num2 + ")", text + "_buttonEIs", P_1);
					if (zOleBpQBDPKbvuUhjSPabaYrCsjZ6.WAyeTACitBLRzRlrBpnKHQReGTZjc)
					{
						for (int l = 0; l < num2; l++)
						{
							ControllerElementIdentifier controllerElementIdentifier2 = customController.ButtonElementIdentifiers[l];
							using ZOleBpQBDPKbvuUhjSPabaYrCsjZ zOleBpQBDPKbvuUhjSPabaYrCsjZ7 = new ZOleBpQBDPKbvuUhjSPabaYrCsjZ(l + ": " + controllerElementIdentifier2.get_name() + " (id: " + controllerElementIdentifier2.get_id() + ")", text + "_ButtonEI" + l + "_" + controllerElementIdentifier2.get_name(), P_1);
							if (zOleBpQBDPKbvuUhjSPabaYrCsjZ7.WAyeTACitBLRzRlrBpnKHQReGTZjc)
							{
								ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Id", controllerElementIdentifier2.get_id().ToString());
								ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Name", controllerElementIdentifier2.get_name());
							}
						}
					}
				}
			}
			CalibrationMap calibrationMap = customController.calibrationMap;
			using (ZOleBpQBDPKbvuUhjSPabaYrCsjZ zOleBpQBDPKbvuUhjSPabaYrCsjZ8 = new ZOleBpQBDPKbvuUhjSPabaYrCsjZ("Calibration Map", text + "_calibrationMap", P_1))
			{
				if (zOleBpQBDPKbvuUhjSPabaYrCsjZ8.WAyeTACitBLRzRlrBpnKHQReGTZjc)
				{
					int num2 = calibrationMap.axisCount;
					for (int m = 0; m < num2; m++)
					{
						AxisCalibration axisCalibration = calibrationMap.Axes[m];
						using ZOleBpQBDPKbvuUhjSPabaYrCsjZ zOleBpQBDPKbvuUhjSPabaYrCsjZ9 = new ZOleBpQBDPKbvuUhjSPabaYrCsjZ(m + ": Axis Calibration (" + (axisCalibration.enabled ? "Enabled" : "Disabled") + ")", text + "_AxisCalibration" + m, P_1);
						if (zOleBpQBDPKbvuUhjSPabaYrCsjZ9.WAyeTACitBLRzRlrBpnKHQReGTZjc)
						{
							ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Enabled", axisCalibration.enabled.ToString());
							ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Apply Range Calibration", axisCalibration.applyRangeCalibration.ToString());
							ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Calibrated Max", axisCalibration.calibratedMax.ToString());
							ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Calibrated Min", axisCalibration.calibratedMin.ToString());
							ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Calibrated Zero", axisCalibration.calibratedZero.ToString());
							ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Dead Zone", axisCalibration.deadZone.ToString());
							ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Invert", axisCalibration.invert.ToString());
							ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Sensitivity Type", axisCalibration.sensitivityType.ToString());
							ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Sensitivity", axisCalibration.sensitivity.ToString());
							if (axisCalibration.sensitivityCurve != null)
							{
								bool num3 = GUI.enabled;
								GUI.enabled = false;
								ODamYsBvIrppZTfOxwvNniVIDSXgA.PGWgoVdvhARnAXnOrnihOLnkPGH("Sensitivity Curve", axisCalibration.sensitivityCurve);
								GUI.enabled = num3;
							}
							else
							{
								ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Sensitivity Curve", "--");
							}
						}
					}
				}
			}
			ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Has Extension", (customController.extension != null).ToString());
			ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Extension Type", (customController.extension != null) ? customController.extension.GetType().Name : "--");
			HsTPYzosyktiPKKWpYtkxklDEHcM(customController, P_1, text);
		}
	}

	private static void gBLOZyyZwfTgvDGZulSaMUWBtOrJ(Player P_0, int P_1, IDictionary<string, bool> P_2, string P_3)
	{
		string text = P_3 + "_player" + P_0.id;
		using ZOleBpQBDPKbvuUhjSPabaYrCsjZ zOleBpQBDPKbvuUhjSPabaYrCsjZ = new ZOleBpQBDPKbvuUhjSPabaYrCsjZ((P_0.id == 9999999) ? "System Player" : (P_1 + ": " + P_0.name), text, P_2);
		if (!zOleBpQBDPKbvuUhjSPabaYrCsjZ.WAyeTACitBLRzRlrBpnKHQReGTZjc)
		{
			return;
		}
		ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Player Id", P_0.id.ToString());
		ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Name", P_0.name);
		ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Descriptive Name", P_0.descriptiveName);
		ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Is Playing", P_0.isPlaying.ToString());
		using (ZOleBpQBDPKbvuUhjSPabaYrCsjZ zOleBpQBDPKbvuUhjSPabaYrCsjZ2 = new ZOleBpQBDPKbvuUhjSPabaYrCsjZ("Controllers", text + "_controllers", P_2))
		{
			if (zOleBpQBDPKbvuUhjSPabaYrCsjZ2.WAyeTACitBLRzRlrBpnKHQReGTZjc)
			{
				Player.ControllerHelper controllers = P_0.controllers;
				jThCfQAMLnWFBUJeHhajBEIaNhXf(controllers.Joysticks, P_2, text);
				lSxxQnUhAPPwFoOCwjolMAZHHIGd(controllers.CustomControllers, P_2, text);
				ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Has Mouse", controllers.hasMouse.ToString());
				ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Has Keyboard", controllers.hasKeyboard.ToString());
				ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Exclude From Controller Auto Assignment", controllers.excludeFromControllerAutoAssignment.ToString());
				ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Last Active Controller", (controllers.GetLastActiveController() != null) ? controllers.GetLastActiveController().name.ToString() : "NULL");
			}
		}
		string text2 = text + "_controllerMaps";
		using (ZOleBpQBDPKbvuUhjSPabaYrCsjZ zOleBpQBDPKbvuUhjSPabaYrCsjZ3 = new ZOleBpQBDPKbvuUhjSPabaYrCsjZ("Controller Maps", text2, P_2))
		{
			if (zOleBpQBDPKbvuUhjSPabaYrCsjZ3.WAyeTACitBLRzRlrBpnKHQReGTZjc)
			{
				LppsvpzDgvVUwKTUtOXznPQNrBZO(ControllerType.Keyboard, P_0.controllers.maps.GetMaps<KeyboardMap>(0), "Keyboard Maps", P_2, text2 + "_keyboard");
				LppsvpzDgvVUwKTUtOXznPQNrBZO(ControllerType.Mouse, P_0.controllers.maps.GetMaps<MouseMap>(0), "Mouse Maps", P_2, text2 + "_mouse");
				string text3 = text2 + "_joystickMaps";
				using (ZOleBpQBDPKbvuUhjSPabaYrCsjZ zOleBpQBDPKbvuUhjSPabaYrCsjZ4 = new ZOleBpQBDPKbvuUhjSPabaYrCsjZ("Joystick Maps (" + P_0.controllers.joystickCount + ")", text3, P_2))
				{
					if (zOleBpQBDPKbvuUhjSPabaYrCsjZ4.WAyeTACitBLRzRlrBpnKHQReGTZjc)
					{
						for (int i = 0; i < P_0.controllers.joystickCount; i++)
						{
							Joystick joystick = P_0.controllers.Joysticks[i];
							IList<JoystickMap> maps = P_0.controllers.maps.GetMaps<JoystickMap>(joystick.id);
							string text4 = text3;
							int id = joystick.id;
							text3 = text4 + "_joystickId" + id;
							LppsvpzDgvVUwKTUtOXznPQNrBZO(ControllerType.Joystick, maps, (joystick.name != "Unknown Controller") ? joystick.name : joystick.hardwareName, P_2, text3);
						}
					}
				}
				text3 = text2 + "_customControllerMaps";
				using ZOleBpQBDPKbvuUhjSPabaYrCsjZ zOleBpQBDPKbvuUhjSPabaYrCsjZ5 = new ZOleBpQBDPKbvuUhjSPabaYrCsjZ("Custom Controller Maps (" + P_0.controllers.customControllerCount + ")", text3, P_2);
				if (zOleBpQBDPKbvuUhjSPabaYrCsjZ5.WAyeTACitBLRzRlrBpnKHQReGTZjc)
				{
					for (int j = 0; j < P_0.controllers.customControllerCount; j++)
					{
						CustomController customController = P_0.controllers.CustomControllers[j];
						IList<CustomControllerMap> maps2 = P_0.controllers.maps.GetMaps<CustomControllerMap>(customController.id);
						string text5 = text3;
						int id = customController.id;
						text3 = text5 + "_customControllerId" + id;
						LppsvpzDgvVUwKTUtOXznPQNrBZO(ControllerType.Custom, maps2, customController.name, P_2, text3);
					}
				}
			}
		}
		text2 = text + "_controllerMapLayoutManager";
		using (ZOleBpQBDPKbvuUhjSPabaYrCsjZ zOleBpQBDPKbvuUhjSPabaYrCsjZ6 = new ZOleBpQBDPKbvuUhjSPabaYrCsjZ("Layout Manager", text2, P_2))
		{
			if (zOleBpQBDPKbvuUhjSPabaYrCsjZ6.WAyeTACitBLRzRlrBpnKHQReGTZjc)
			{
				vVUmRHsJaMguJfUyyzWLvDRLYUJE(P_0.controllers.maps.layoutManager, P_2, text2);
			}
		}
		text2 = text + "_controllerMapEnabler";
		using (ZOleBpQBDPKbvuUhjSPabaYrCsjZ zOleBpQBDPKbvuUhjSPabaYrCsjZ7 = new ZOleBpQBDPKbvuUhjSPabaYrCsjZ("Map Enabler", text2, P_2))
		{
			if (zOleBpQBDPKbvuUhjSPabaYrCsjZ7.WAyeTACitBLRzRlrBpnKHQReGTZjc)
			{
				SKQslzfDVnFBlabSQWmcOUdlMPYvA(P_0.controllers.maps.mapEnabler, P_2, text2);
			}
		}
		text2 = text + "_inputBehaviors";
		rtcgijNcEqbgrJJSpxUpRlmKDeebb(P_0.controllers.maps.InputBehaviors, P_2, text2);
		text2 = text + "_actions";
		List<InputAction> list = new List<InputAction>(ReInput.mapping.Actions);
		list.Sort(IlxSaLNgaVqbsDMvUEMVRqSNsFLm._003C_003E9.GpodNQApsjoQzGkIAhefEsYBBQdXc);
		IList<InputCategory> actionCategories = ReInput.mapping.ActionCategories;
		using ZOleBpQBDPKbvuUhjSPabaYrCsjZ zOleBpQBDPKbvuUhjSPabaYrCsjZ8 = new ZOleBpQBDPKbvuUhjSPabaYrCsjZ("Actions (" + list.Count + ")", text2, P_2);
		if (!zOleBpQBDPKbvuUhjSPabaYrCsjZ8.WAyeTACitBLRzRlrBpnKHQReGTZjc)
		{
			return;
		}
		for (int k = 0; k < actionCategories.Count; k++)
		{
			NLWUhNVPnPbaIUWrJmkFSesrOmiX nLWUhNVPnPbaIUWrJmkFSesrOmiX = new NLWUhNVPnPbaIUWrJmkFSesrOmiX();
			nLWUhNVPnPbaIUWrJmkFSesrOmiX.ujdMGuKttiBpXDmuPJfORfBydigfA = actionCategories[k];
			string text6 = text2 + "_actionCat" + nLWUhNVPnPbaIUWrJmkFSesrOmiX.ujdMGuKttiBpXDmuPJfORfBydigfA.id;
			int num = ListTools.Count(list, nLWUhNVPnPbaIUWrJmkFSesrOmiX.VkUXghrFsGUzwZIpOSsdjDIcnYmo);
			using ZOleBpQBDPKbvuUhjSPabaYrCsjZ zOleBpQBDPKbvuUhjSPabaYrCsjZ9 = new ZOleBpQBDPKbvuUhjSPabaYrCsjZ("id " + nLWUhNVPnPbaIUWrJmkFSesrOmiX.ujdMGuKttiBpXDmuPJfORfBydigfA.id + ": " + nLWUhNVPnPbaIUWrJmkFSesrOmiX.ujdMGuKttiBpXDmuPJfORfBydigfA.name + " (" + num + ")", text6, P_2);
			if (!zOleBpQBDPKbvuUhjSPabaYrCsjZ9.WAyeTACitBLRzRlrBpnKHQReGTZjc)
			{
				continue;
			}
			for (int l = 0; l < list.Count; l++)
			{
				InputAction inputAction = list[l];
				if (inputAction.categoryId != nLWUhNVPnPbaIUWrJmkFSesrOmiX.ujdMGuKttiBpXDmuPJfORfBydigfA.id)
				{
					continue;
				}
				string text7 = text6 + "_actionId" + inputAction.id;
				using ZOleBpQBDPKbvuUhjSPabaYrCsjZ zOleBpQBDPKbvuUhjSPabaYrCsjZ10 = new ZOleBpQBDPKbvuUhjSPabaYrCsjZ("id " + inputAction.id + ": " + inputAction.name + ": " + P_0.GetAxis(inputAction.id).ToString("f3"), text7, P_2);
				if (zOleBpQBDPKbvuUhjSPabaYrCsjZ10.WAyeTACitBLRzRlrBpnKHQReGTZjc)
				{
					ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Axis Value", P_0.GetAxis(inputAction.id).ToString());
					ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Axis Raw Value", P_0.GetAxisRaw(inputAction.id).ToString());
					ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Button Value", P_0.GetButton(inputAction.id).ToString());
					ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Button Double Press Value", P_0.GetButtonDoublePressHold(inputAction.id).ToString());
					ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Button Short Press Value", P_0.GetButtonShortPress(inputAction.id).ToString());
					ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Button Long Press Value", P_0.GetButtonLongPress(inputAction.id).ToString());
					ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Button Repeating Value", P_0.GetButtonRepeating(inputAction.id).ToString());
					ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Negative Button Value", P_0.GetNegativeButton(inputAction.id).ToString());
					ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Negative Button Double Press Value", P_0.GetNegativeButtonDoublePressHold(inputAction.id).ToString());
					ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Negative Button Short Press Value", P_0.GetNegativeButtonShortPress(inputAction.id).ToString());
					ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Negative Button Long Press Value", P_0.GetNegativeButtonLongPress(inputAction.id).ToString());
					ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Negative Button Repeating Value", P_0.GetNegativeButtonRepeating(inputAction.id).ToString());
					ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Axis Time Active", P_0.GetAxisTimeActive(inputAction.id).ToString());
					ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Axis Time Inactive", P_0.GetAxisTimeInactive(inputAction.id).ToString());
					ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Axis Raw Time Active", P_0.GetAxisRawTimeActive(inputAction.id).ToString());
					ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Axis Raw Time Inactive", P_0.GetAxisRawTimeInactive(inputAction.id).ToString());
					ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Button Time Pressed", P_0.GetButtonTimePressed(inputAction.id).ToString());
					ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Button Time Unpressed", P_0.GetButtonTimeUnpressed(inputAction.id).ToString());
					ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Negative Button Time Pressed", P_0.GetNegativeButtonTimePressed(inputAction.id).ToString());
					ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Negative Button Time Unpressed", P_0.GetNegativeButtonTimeUnpressed(inputAction.id).ToString());
				}
			}
		}
	}

	private static void rtcgijNcEqbgrJJSpxUpRlmKDeebb(IList<InputBehavior> P_0, IDictionary<string, bool> P_1, string P_2)
	{
		int num = P_0?.Count ?? 0;
		using ZOleBpQBDPKbvuUhjSPabaYrCsjZ zOleBpQBDPKbvuUhjSPabaYrCsjZ = new ZOleBpQBDPKbvuUhjSPabaYrCsjZ("Input Behaviors (" + num + ")", P_2 + "_inputBehaviors", P_1);
		if (zOleBpQBDPKbvuUhjSPabaYrCsjZ.WAyeTACitBLRzRlrBpnKHQReGTZjc)
		{
			for (int i = 0; i < num; i++)
			{
				EMpBlXgzohimtofopOnvDdRfLqQMB(P_0[i], i, P_1, P_2);
			}
		}
	}

	private static void EMpBlXgzohimtofopOnvDdRfLqQMB(InputBehavior P_0, int P_1, IDictionary<string, bool> P_2, string P_3)
	{
		string text = P_3 + "_inputBehavior" + P_0.id;
		using ZOleBpQBDPKbvuUhjSPabaYrCsjZ zOleBpQBDPKbvuUhjSPabaYrCsjZ = new ZOleBpQBDPKbvuUhjSPabaYrCsjZ(P_1 + ": " + P_0.name, text, P_2);
		if (zOleBpQBDPKbvuUhjSPabaYrCsjZ.WAyeTACitBLRzRlrBpnKHQReGTZjc)
		{
			ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Id", P_0.id.ToString());
			ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Name", P_0.name);
			ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Digital Axis Gravity", P_0.digitalAxisGravity.ToString());
			ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Digital Axis Instant Reverse", P_0.digitalAxisInstantReverse.ToString());
			ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Digital Axis Sensitivity", P_0.digitalAxisSensitivity.ToString());
			ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Digital Axis Snap", P_0.digitalAxisSnap.ToString());
			ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Joystick Axis Sensitivity", P_0.joystickAxisSensitivity.ToString());
			ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Custom Controller Axis Sensitivity", P_0.customControllerAxisSensitivity.ToString());
			ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Mouse XY Axis Mode", P_0.mouseXYAxisMode.ToString());
			ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Mouse XY Axis Sensitivity", P_0.mouseXYAxisSensitivity.ToString());
			ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Mouse XY Axis Delta Calc", P_0.mouseXYAxisDeltaCalc.ToString());
			ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Mouse Other Axis Mode", P_0.mouseOtherAxisMode.ToString());
			ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Mouse Other Axis Sensitivity", P_0.mouseOtherAxisSensitivity.ToString());
			ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Button Dead Zone", P_0.buttonDeadZone.ToString());
			ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Button Double Press Speed", P_0.buttonDoublePressSpeed.ToString());
			ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Button Short Press Time", P_0.buttonShortPressTime.ToString());
			ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Button Short Press Expires In", P_0.buttonShortPressExpiresIn.ToString());
			ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Button Long Press Time", P_0.buttonLongPressTime.ToString());
			ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Button Long Press Expires In", P_0.buttonLongPressExpiresIn.ToString());
			ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Button Down Buffer", P_0.buttonDownBuffer.ToString());
		}
	}

	private static void dfMbbJbSAHKkIidmChbuvTvlaxoeA(Controller P_0, IDictionary<string, bool> P_1, string P_2)
	{
		using ZOleBpQBDPKbvuUhjSPabaYrCsjZ zOleBpQBDPKbvuUhjSPabaYrCsjZ = new ZOleBpQBDPKbvuUhjSPabaYrCsjZ("Element Identifiers", P_2 + "_elementIdentifiers", P_1);
		if (!zOleBpQBDPKbvuUhjSPabaYrCsjZ.WAyeTACitBLRzRlrBpnKHQReGTZjc)
		{
			return;
		}
		int num;
		if (P_0 is ControllerWithAxes)
		{
			ControllerWithAxes controllerWithAxes = P_0 as ControllerWithAxes;
			num = ((controllerWithAxes.AxisElementIdentifiers != null) ? controllerWithAxes.AxisElementIdentifiers.Count : 0);
			using ZOleBpQBDPKbvuUhjSPabaYrCsjZ zOleBpQBDPKbvuUhjSPabaYrCsjZ2 = new ZOleBpQBDPKbvuUhjSPabaYrCsjZ("Axis Element Identifiers (" + num + ")", P_2 + "_axisEIs", P_1);
			if (zOleBpQBDPKbvuUhjSPabaYrCsjZ2.WAyeTACitBLRzRlrBpnKHQReGTZjc)
			{
				for (int i = 0; i < num; i++)
				{
					ControllerElementIdentifier controllerElementIdentifier = controllerWithAxes.AxisElementIdentifiers[i];
					using ZOleBpQBDPKbvuUhjSPabaYrCsjZ zOleBpQBDPKbvuUhjSPabaYrCsjZ3 = new ZOleBpQBDPKbvuUhjSPabaYrCsjZ(i + ": " + controllerElementIdentifier.get_name() + " (id: " + controllerElementIdentifier.get_id() + ")", P_2 + "_AxisEI" + i + "_" + controllerElementIdentifier.get_name(), P_1);
					if (zOleBpQBDPKbvuUhjSPabaYrCsjZ3.WAyeTACitBLRzRlrBpnKHQReGTZjc)
					{
						ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Id", controllerElementIdentifier.get_id().ToString());
						ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Name", controllerElementIdentifier.get_name());
					}
				}
			}
		}
		if (P_0 == null)
		{
			return;
		}
		num = ((P_0.ButtonElementIdentifiers != null) ? P_0.ButtonElementIdentifiers.Count : 0);
		using ZOleBpQBDPKbvuUhjSPabaYrCsjZ zOleBpQBDPKbvuUhjSPabaYrCsjZ4 = new ZOleBpQBDPKbvuUhjSPabaYrCsjZ("Button Element Identifiers (" + num + ")", P_2 + "_buttonEIs", P_1);
		if (!zOleBpQBDPKbvuUhjSPabaYrCsjZ4.WAyeTACitBLRzRlrBpnKHQReGTZjc)
		{
			return;
		}
		for (int j = 0; j < num; j++)
		{
			ControllerElementIdentifier controllerElementIdentifier2 = P_0.ButtonElementIdentifiers[j];
			using ZOleBpQBDPKbvuUhjSPabaYrCsjZ zOleBpQBDPKbvuUhjSPabaYrCsjZ5 = new ZOleBpQBDPKbvuUhjSPabaYrCsjZ(j + ": " + controllerElementIdentifier2.get_name() + " (id: " + controllerElementIdentifier2.get_id() + ")", P_2 + "_ButtonEI" + j + "_" + controllerElementIdentifier2.get_name(), P_1);
			if (zOleBpQBDPKbvuUhjSPabaYrCsjZ5.WAyeTACitBLRzRlrBpnKHQReGTZjc)
			{
				ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Id", controllerElementIdentifier2.get_id().ToString());
				ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Name", controllerElementIdentifier2.get_name());
			}
		}
	}

	private static void mxymFuqxmxDvxgpwOASPusMcYlrI(IList<Controller.Button> P_0, ControllerType P_1, IDictionary<string, bool> P_2, string P_3)
	{
		string obj = ((P_1 == ControllerType.Keyboard) ? "Key" : "Button");
		int num = P_0?.Count ?? 0;
		using ZOleBpQBDPKbvuUhjSPabaYrCsjZ zOleBpQBDPKbvuUhjSPabaYrCsjZ = new ZOleBpQBDPKbvuUhjSPabaYrCsjZ(obj + "s (" + num + ")", P_3 + "_Buttons", P_2);
		if (!zOleBpQBDPKbvuUhjSPabaYrCsjZ.WAyeTACitBLRzRlrBpnKHQReGTZjc)
		{
			return;
		}
		for (int i = 0; i < num; i++)
		{
			Controller.Button button = P_0[i];
			using ZOleBpQBDPKbvuUhjSPabaYrCsjZ zOleBpQBDPKbvuUhjSPabaYrCsjZ2 = new ZOleBpQBDPKbvuUhjSPabaYrCsjZ(i + ": " + ((P_1 == ControllerType.Keyboard) ? (Keyboard.GetKeyboardKeyCodeByButtonIndex(i).ToString() + " (" + Keyboard.GetKeyName((KeyCode)Keyboard.GetKeyboardKeyCodeByButtonIndex(i)) + ")") : button.elementIdentifier.get_name()) + ": " + (button.value ? "Pressed" : "") + " (" + button.pressure.ToString("f3") + ")", P_3 + "_" + button.name, P_2);
			if (zOleBpQBDPKbvuUhjSPabaYrCsjZ2.WAyeTACitBLRzRlrBpnKHQReGTZjc)
			{
				ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Is Member Element", button.isMemberElement.ToString());
				ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Is Pressure Sensitive", button.isPressureSensitive.ToString());
				ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Value", button.value.ToString());
				ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Value Prev", button.valuePrev.ToString());
				ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Pressure", button.pressure.ToString());
				ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Pressure Prev", button.pressurePrev.ToString());
				ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Just Pressed", button.justPressed.ToString());
				ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Just Released", button.justReleased.ToString());
				ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Just Double Pressed", button.justDoublePressed.ToString());
				ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Double Pressed And Held", button.doublePressedAndHeld.ToString());
				ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Time Pressed", button.timePressed.ToString());
				ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Time Unpressed", button.timeUnpressed.ToString());
				ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Last Time Pressed", button.lastTimePressed.ToString());
				ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Last Time Unpressed", button.lastTimeUnpressed.ToString());
			}
		}
	}

	private static void vhDyGrJioNbkVHEpWcdDBolKPZJQ(IList<Controller.Axis> P_0, IDictionary<string, bool> P_1, string P_2)
	{
		int num = P_0?.Count ?? 0;
		using ZOleBpQBDPKbvuUhjSPabaYrCsjZ zOleBpQBDPKbvuUhjSPabaYrCsjZ = new ZOleBpQBDPKbvuUhjSPabaYrCsjZ("Axes (" + num + ")", P_2 + "_Axes", P_1);
		if (!zOleBpQBDPKbvuUhjSPabaYrCsjZ.WAyeTACitBLRzRlrBpnKHQReGTZjc)
		{
			return;
		}
		for (int i = 0; i < num; i++)
		{
			Controller.Axis axis = P_0[i];
			using ZOleBpQBDPKbvuUhjSPabaYrCsjZ zOleBpQBDPKbvuUhjSPabaYrCsjZ2 = new ZOleBpQBDPKbvuUhjSPabaYrCsjZ(i + ": " + axis.elementIdentifier.get_name() + ": " + axis.value.ToString("f3") + " (" + axis.valueRaw.ToString("f3") + ")", P_2 + "_" + axis.name, P_1);
			if (zOleBpQBDPKbvuUhjSPabaYrCsjZ2.WAyeTACitBLRzRlrBpnKHQReGTZjc)
			{
				ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Is Member Element", axis.isMemberElement.ToString());
				ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Value", axis.value.ToString());
				ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Value Raw", axis.valueRaw.ToString());
				ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Value Prev", axis.valuePrev.ToString());
				ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Value Raw Prev", axis.valueRawPrev.ToString());
				ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Value Delta", axis.valueDelta.ToString());
				ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Value Delta Raw", axis.valueDeltaRaw.ToString());
				ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Time Active", axis.timeActive.ToString());
				ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Time Active Raw", axis.timeActiveRaw.ToString());
				ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Time Inactive", axis.timeInactive.ToString());
				ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Time Inactive Raw", axis.timeInactiveRaw.ToString());
				ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Last Time Active", axis.lastTimeActive.ToString());
				ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Last Time Active Raw", axis.lastTimeActiveRaw.ToString());
				ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Last Time Inactive", axis.lastTimeInactive.ToString());
				ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Last Time Inactive Raw", axis.lastTimeInactiveRaw.ToString());
			}
		}
	}

	private static void LppsvpzDgvVUwKTUtOXznPQNrBZO<_0001>(ControllerType P_0, IList<_0001> P_1, string P_2, IDictionary<string, bool> P_3, string P_4) where _0001 : ControllerMap
	{
		string text = P_4 + "_controllerMaps";
		int num = P_1?.Count ?? 0;
		using ZOleBpQBDPKbvuUhjSPabaYrCsjZ zOleBpQBDPKbvuUhjSPabaYrCsjZ = new ZOleBpQBDPKbvuUhjSPabaYrCsjZ(P_2 + " (" + num + ")", text, P_3);
		if (!zOleBpQBDPKbvuUhjSPabaYrCsjZ.WAyeTACitBLRzRlrBpnKHQReGTZjc)
		{
			return;
		}
		for (int i = 0; i < num; i++)
		{
			string text2 = (P_1[i].enabled ? "Enabled" : "Disabled");
			InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(P_1[i].categoryId);
			InputLayout layout = ReInput.mapping.GetLayout(P_0, P_1[i].layoutId);
			string text3 = ((mapCategory != null) ? mapCategory.name : "n/a");
			string text4 = ((layout != null) ? layout.name : "n/a");
			using ZOleBpQBDPKbvuUhjSPabaYrCsjZ zOleBpQBDPKbvuUhjSPabaYrCsjZ2 = new ZOleBpQBDPKbvuUhjSPabaYrCsjZ(i + ": " + text3 + ", " + text4 + ": " + text2, P_4 + "_index" + i, P_3);
			if (zOleBpQBDPKbvuUhjSPabaYrCsjZ2.WAyeTACitBLRzRlrBpnKHQReGTZjc)
			{
				if (P_1[i] is ControllerMapWithAxes)
				{
					zkkyJLyVkoTGLQejHSKPhjvYDXnY(P_1[i] as ControllerMapWithAxes, P_3, text + i);
				}
				else
				{
					SbsxpplKLQjBwTlSsBHAZUtjdyZGA(P_1[i], P_3, text + i);
				}
			}
		}
	}

	private static void SbsxpplKLQjBwTlSsBHAZUtjdyZGA(ControllerMap P_0, IDictionary<string, bool> P_1, string P_2)
	{
		ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Id (unique id)", P_0.id.ToString());
		ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Source Map Id", P_0.sourceMapId.ToString());
		ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Enabled", P_0.enabled.ToString());
		ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Controller Type", P_0.controllerType.ToString());
		if (P_0.controllerType == ControllerType.Joystick || P_0.controllerType == ControllerType.Custom)
		{
			ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Controller Id", P_0.controllerId.ToString());
		}
		string text = P_0.categoryId.ToString();
		if (P_0.categoryId >= 0)
		{
			try
			{
				InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(P_0.categoryId);
				if (mapCategory != null)
				{
					text = text + " (" + mapCategory.name + ")";
				}
			}
			catch
			{
			}
		}
		ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Category Id", text);
		string text2 = P_0.layoutId.ToString();
		if (P_0.layoutId >= 0)
		{
			try
			{
				InputLayout layout = ReInput.mapping.GetLayout(P_0.controllerType, P_0.layoutId);
				if (layout != null)
				{
					text2 = text2 + " (" + layout.name + ")";
				}
			}
			catch
			{
			}
		}
		ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Layout Id", text2);
		int buttonMapCount = P_0.buttonMapCount;
		string text3 = P_2 + "_buttonMaps";
		using ZOleBpQBDPKbvuUhjSPabaYrCsjZ zOleBpQBDPKbvuUhjSPabaYrCsjZ = new ZOleBpQBDPKbvuUhjSPabaYrCsjZ("Button Maps (" + buttonMapCount + ")", text3, P_1);
		if (zOleBpQBDPKbvuUhjSPabaYrCsjZ.WAyeTACitBLRzRlrBpnKHQReGTZjc)
		{
			for (int i = 0; i < buttonMapCount; i++)
			{
				uuqDhsitcGZeKGGSaMsZptiussQb(P_0.controllerType, P_0.ButtonMaps[i], i, P_1, text3 + i);
			}
		}
	}

	private static void zkkyJLyVkoTGLQejHSKPhjvYDXnY(ControllerMapWithAxes P_0, IDictionary<string, bool> P_1, string P_2)
	{
		SbsxpplKLQjBwTlSsBHAZUtjdyZGA(P_0, P_1, P_2);
		string text = P_2 + "_axisMaps";
		int axisMapCount = P_0.axisMapCount;
		using ZOleBpQBDPKbvuUhjSPabaYrCsjZ zOleBpQBDPKbvuUhjSPabaYrCsjZ = new ZOleBpQBDPKbvuUhjSPabaYrCsjZ("Axis Maps (" + axisMapCount + ")", text, P_1);
		if (zOleBpQBDPKbvuUhjSPabaYrCsjZ.WAyeTACitBLRzRlrBpnKHQReGTZjc)
		{
			for (int i = 0; i < axisMapCount; i++)
			{
				uuqDhsitcGZeKGGSaMsZptiussQb(P_0.controllerType, P_0.AxisMaps[i], i, P_1, text + i);
			}
		}
	}

	private static void uuqDhsitcGZeKGGSaMsZptiussQb(ControllerType P_0, ActionElementMap P_1, int P_2, IDictionary<string, bool> P_3, string P_4)
	{
		string text = "Action Element Map";
		InputAction action = ReInput.mapping.GetAction(P_1.actionId);
		string text2 = ((action != null) ? action.name : string.Empty);
		string text3 = DBMDWdlyZcupeUrfJhJCloFNUcxL(P_1);
		if (!string.IsNullOrEmpty(text3))
		{
			text = P_1.elementIdentifierName + " (" + text3 + ")";
		}
		using ZOleBpQBDPKbvuUhjSPabaYrCsjZ zOleBpQBDPKbvuUhjSPabaYrCsjZ = new ZOleBpQBDPKbvuUhjSPabaYrCsjZ(P_2 + ": " + text, P_4 + "_" + P_2, P_3);
		if (!zOleBpQBDPKbvuUhjSPabaYrCsjZ.WAyeTACitBLRzRlrBpnKHQReGTZjc)
		{
			return;
		}
		ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Id (unique id)", P_1.id.ToString());
		ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Enabled", P_1.enabled.ToString());
		ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Element Type", P_1.elementType.ToString());
		ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Action Id", P_1.actionId + " " + ((action != null) ? ("(" + text2 + ")") : ""));
		ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Element Identifier Id", P_1.elementIdentifierId.ToString());
		ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Element Identifier Name", P_1.elementIdentifierName);
		if (P_1.elementType == ControllerElementType.Axis)
		{
			ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Element Index", P_1.elementIndex.ToString());
			ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Axis Range", P_1.axisRange.ToString());
			ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Axis Type", P_1.axisType.ToString());
			ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Invert", P_1.invert.ToString());
		}
		else if (P_1.elementType == ControllerElementType.Button)
		{
			ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Element Index", P_1.elementIndex.ToString());
			if (P_0 == ControllerType.Keyboard)
			{
				ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Key Code", P_1.keyCode.ToString());
				ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Keyboard Key Code", P_1.keyboardKeyCode.ToString());
				ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Has Modifiers", P_1.hasModifiers.ToString());
				ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Modifier Key 1", P_1.modifierKey1.ToString());
				ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Modifier Key 2", P_1.modifierKey2.ToString());
				ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Modifier Key 3", P_1.modifierKey3.ToString());
			}
		}
		ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Axis Contribution", P_1.axisContribution.ToString());
	}

	private static string DBMDWdlyZcupeUrfJhJCloFNUcxL(ActionElementMap P_0)
	{
		InputAction action = ReInput.mapping.GetAction(P_0.actionId);
		if (action == null)
		{
			return string.Empty;
		}
		string text = string.Empty;
		if (P_0.elementType == ControllerElementType.Button || (P_0.elementType == ControllerElementType.Axis && P_0.axisType == AxisType.Split))
		{
			if (P_0.axisContribution == Pole.Positive)
			{
				text = action.positiveDescriptiveName;
				if (string.IsNullOrEmpty(text))
				{
					text = ((!string.IsNullOrEmpty(action.descriptiveName)) ? (action.descriptiveName + " +") : (action.name + " +"));
				}
			}
			else
			{
				text = action.negativeDescriptiveName;
				if (string.IsNullOrEmpty(text))
				{
					text = ((!string.IsNullOrEmpty(action.descriptiveName)) ? (action.descriptiveName + " -") : (action.name + " -"));
				}
			}
		}
		else if (P_0.elementType == ControllerElementType.Axis && P_0.axisType == AxisType.Normal)
		{
			text = ((!string.IsNullOrEmpty(action.descriptiveName)) ? action.descriptiveName : action.name);
		}
		return text;
	}

	private static void vVUmRHsJaMguJfUyyzWLvDRLYUJE(ControllerMapLayoutManager P_0, IDictionary<string, bool> P_1, string P_2)
	{
		if (HrGIQrMYKzSGiQPnjFRNPSAicKyu("Enabled", P_0.enabled))
		{
			P_0.enabled = !P_0.enabled;
		}
		ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Load from User Data Store", P_0.loadFromUserDataStore.ToString());
		string text = P_2 + "_ruleSets";
		int count = P_0.ruleSets.Count;
		using ZOleBpQBDPKbvuUhjSPabaYrCsjZ zOleBpQBDPKbvuUhjSPabaYrCsjZ = new ZOleBpQBDPKbvuUhjSPabaYrCsjZ("Rule Sets (" + count + ")", text, P_1);
		if (zOleBpQBDPKbvuUhjSPabaYrCsjZ.WAyeTACitBLRzRlrBpnKHQReGTZjc)
		{
			for (int i = 0; i < count; i++)
			{
				lOdCszSBsUqVdhHtvgUVBcXHnHXFA(P_0.ruleSets[i], i, P_1, text + i);
			}
		}
	}

	private static void lOdCszSBsUqVdhHtvgUVBcXHnHXFA(ControllerMapLayoutManager.RuleSet P_0, int P_1, IDictionary<string, bool> P_2, string P_3)
	{
		int num = P_0?.get_Count() ?? 0;
		using ZOleBpQBDPKbvuUhjSPabaYrCsjZ zOleBpQBDPKbvuUhjSPabaYrCsjZ = new ZOleBpQBDPKbvuUhjSPabaYrCsjZ(P_1 + ": " + ((!string.IsNullOrEmpty(P_0.tag)) ? (P_0.tag + ", ") : "") + (P_0.enabled ? "Enabled" : "Disabled"), P_3, P_2);
		if (!zOleBpQBDPKbvuUhjSPabaYrCsjZ.WAyeTACitBLRzRlrBpnKHQReGTZjc)
		{
			return;
		}
		if (HrGIQrMYKzSGiQPnjFRNPSAicKyu("Enabled", P_0.enabled))
		{
			P_0.enabled = !P_0.enabled;
		}
		ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Tag", P_0.tag);
		string text = P_3 + "_rules";
		using ZOleBpQBDPKbvuUhjSPabaYrCsjZ zOleBpQBDPKbvuUhjSPabaYrCsjZ2 = new ZOleBpQBDPKbvuUhjSPabaYrCsjZ("Rules (" + P_0.get_Count() + ")", text, P_2);
		if (!zOleBpQBDPKbvuUhjSPabaYrCsjZ2.WAyeTACitBLRzRlrBpnKHQReGTZjc)
		{
			return;
		}
		for (int i = 0; i < num; i++)
		{
			ControllerMapLayoutManager.Rule rule = P_0.get_Item(i);
			string text2 = text + i;
			using ZOleBpQBDPKbvuUhjSPabaYrCsjZ zOleBpQBDPKbvuUhjSPabaYrCsjZ3 = new ZOleBpQBDPKbvuUhjSPabaYrCsjZ(i + ": " + ((!string.IsNullOrEmpty(rule.tag)) ? rule.tag : ""), text2, P_2);
			if (!zOleBpQBDPKbvuUhjSPabaYrCsjZ3.WAyeTACitBLRzRlrBpnKHQReGTZjc)
			{
				continue;
			}
			ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Tag", rule.tag);
			liIcwNBurDfuyPHlRokZiHiTZOnkA(rule.controllerSetSelector, P_2, text2);
			int[] categoryIds = rule.categoryIds;
			int num2 = ((categoryIds != null) ? categoryIds.Length : 0);
			using (ZOleBpQBDPKbvuUhjSPabaYrCsjZ zOleBpQBDPKbvuUhjSPabaYrCsjZ4 = new ZOleBpQBDPKbvuUhjSPabaYrCsjZ("Map Categories (" + num2 + ")", text2 + "_categoryIds", P_2))
			{
				if (zOleBpQBDPKbvuUhjSPabaYrCsjZ4.WAyeTACitBLRzRlrBpnKHQReGTZjc)
				{
					if (num2 == 0)
					{
						ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Category", "All Map Categories");
					}
					else
					{
						for (int j = 0; j < categoryIds.Length; j++)
						{
							InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(categoryIds[j]);
							string text3 = ((mapCategory != null) ? (mapCategory.name + " (" + mapCategory.id + ")") : "[INVALID]");
							ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Category " + j, text3);
						}
					}
				}
			}
			InputLayout layout = ReInput.mapping.GetLayout(rule.controllerSetSelector.controllerType, rule.layoutId);
			ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp(rule.controllerSetSelector.controllerType.ToString() + " Layout", (layout != null) ? (layout.name + " (" + layout.id + ")") : "[INVALID]");
		}
	}

	private static void SKQslzfDVnFBlabSQWmcOUdlMPYvA(ControllerMapEnabler P_0, IDictionary<string, bool> P_1, string P_2)
	{
		if (HrGIQrMYKzSGiQPnjFRNPSAicKyu("Enabled", P_0.enabled))
		{
			P_0.enabled = !P_0.enabled;
		}
		string text = P_2 + "_ruleSets";
		int count = P_0.ruleSets.Count;
		using ZOleBpQBDPKbvuUhjSPabaYrCsjZ zOleBpQBDPKbvuUhjSPabaYrCsjZ = new ZOleBpQBDPKbvuUhjSPabaYrCsjZ("Rule Sets (" + count + ")", text, P_1);
		if (zOleBpQBDPKbvuUhjSPabaYrCsjZ.WAyeTACitBLRzRlrBpnKHQReGTZjc)
		{
			for (int i = 0; i < count; i++)
			{
				BkqIRBCtGMmKZFnUeFknIMsnnGEJA(P_0.ruleSets[i], i, P_1, text + i);
			}
		}
	}

	private static void BkqIRBCtGMmKZFnUeFknIMsnnGEJA(ControllerMapEnabler.RuleSet P_0, int P_1, IDictionary<string, bool> P_2, string P_3)
	{
		int num = P_0?.get_Count() ?? 0;
		using ZOleBpQBDPKbvuUhjSPabaYrCsjZ zOleBpQBDPKbvuUhjSPabaYrCsjZ = new ZOleBpQBDPKbvuUhjSPabaYrCsjZ(P_1 + ": " + ((!string.IsNullOrEmpty(P_0.tag)) ? (P_0.tag + ", ") : "") + (P_0.enabled ? "Enabled" : "Disabled"), P_3, P_2);
		if (!zOleBpQBDPKbvuUhjSPabaYrCsjZ.WAyeTACitBLRzRlrBpnKHQReGTZjc)
		{
			return;
		}
		if (HrGIQrMYKzSGiQPnjFRNPSAicKyu("Enabled", P_0.enabled))
		{
			P_0.enabled = !P_0.enabled;
		}
		ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Tag", P_0.tag);
		string text = P_3 + "_rules";
		using ZOleBpQBDPKbvuUhjSPabaYrCsjZ zOleBpQBDPKbvuUhjSPabaYrCsjZ2 = new ZOleBpQBDPKbvuUhjSPabaYrCsjZ("Rules (" + P_0.get_Count() + ")", text, P_2);
		if (!zOleBpQBDPKbvuUhjSPabaYrCsjZ2.WAyeTACitBLRzRlrBpnKHQReGTZjc)
		{
			return;
		}
		for (int i = 0; i < num; i++)
		{
			ControllerMapEnabler.Rule rule = P_0.get_Item(i);
			string text2 = text + i;
			using ZOleBpQBDPKbvuUhjSPabaYrCsjZ zOleBpQBDPKbvuUhjSPabaYrCsjZ3 = new ZOleBpQBDPKbvuUhjSPabaYrCsjZ(i + ": " + ((!string.IsNullOrEmpty(rule.tag)) ? rule.tag : ""), text2, P_2);
			if (!zOleBpQBDPKbvuUhjSPabaYrCsjZ3.WAyeTACitBLRzRlrBpnKHQReGTZjc)
			{
				continue;
			}
			if (HrGIQrMYKzSGiQPnjFRNPSAicKyu("Enable", rule.enable))
			{
				rule.enable = !rule.enable;
			}
			ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Tag", rule.tag);
			liIcwNBurDfuyPHlRokZiHiTZOnkA(rule.controllerSetSelector, P_2, text2);
			int[] categoryIds = rule.categoryIds;
			int num2 = ((categoryIds != null) ? categoryIds.Length : 0);
			using (ZOleBpQBDPKbvuUhjSPabaYrCsjZ zOleBpQBDPKbvuUhjSPabaYrCsjZ4 = new ZOleBpQBDPKbvuUhjSPabaYrCsjZ("Map Categories (" + num2 + ")", text2 + "_categoryIds", P_2))
			{
				if (zOleBpQBDPKbvuUhjSPabaYrCsjZ4.WAyeTACitBLRzRlrBpnKHQReGTZjc)
				{
					if (num2 == 0)
					{
						ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Category", "All Map Categories");
					}
					else
					{
						for (int j = 0; j < categoryIds.Length; j++)
						{
							InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(categoryIds[j]);
							string text3 = ((mapCategory != null) ? (mapCategory.name + " (" + mapCategory.id + ")") : "[INVALID]");
							ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Category " + j, text3);
						}
					}
				}
			}
			int[] layoutIds = rule.layoutIds;
			int num3 = ((layoutIds != null) ? layoutIds.Length : 0);
			using ZOleBpQBDPKbvuUhjSPabaYrCsjZ zOleBpQBDPKbvuUhjSPabaYrCsjZ5 = new ZOleBpQBDPKbvuUhjSPabaYrCsjZ("Layouts (" + num3 + ")", text2 + "_layoutIds", P_2);
			if (!zOleBpQBDPKbvuUhjSPabaYrCsjZ5.WAyeTACitBLRzRlrBpnKHQReGTZjc)
			{
				continue;
			}
			if (num3 == 0)
			{
				ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Layout", (rule.controllerSetSelector.type == ControllerSetSelector.Type.All) ? "All Layouts" : ("All " + rule.controllerSetSelector.controllerType.ToString() + " Layouts"));
				continue;
			}
			for (int k = 0; k < layoutIds.Length; k++)
			{
				InputLayout layout = ReInput.mapping.GetLayout(rule.controllerSetSelector.controllerType, layoutIds[k]);
				string text4 = ((layout != null) ? (layout.name + " (" + layout.id + ")") : "[INVALID]");
				ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp(rule.controllerSetSelector.controllerType.ToString() + " Layout " + k, text4);
			}
		}
	}

	private static void liIcwNBurDfuyPHlRokZiHiTZOnkA(ControllerSetSelector P_0, IDictionary<string, bool> P_1, string P_2)
	{
		string text = P_2 + "_controllerSetSelector";
		using ZOleBpQBDPKbvuUhjSPabaYrCsjZ zOleBpQBDPKbvuUhjSPabaYrCsjZ = new ZOleBpQBDPKbvuUhjSPabaYrCsjZ("Controller Set Selector", text, P_1);
		if (zOleBpQBDPKbvuUhjSPabaYrCsjZ.WAyeTACitBLRzRlrBpnKHQReGTZjc)
		{
			ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Type", StringTools.AddSpacesToSentence(P_0.type.ToString(), preserveAcronyms: false));
			if (P_0.type != ControllerSetSelector.Type.All)
			{
				ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Controller Type", P_0.controllerType.ToString());
			}
			if (P_0.type == ControllerSetSelector.Type.HardwareType)
			{
				ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Hardware Type Guid", P_0.hardwareTypeGuid.ToString());
				ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Hardware Identifier", P_0.hardwareIdentifier);
			}
			if (P_0.type == ControllerSetSelector.Type.ControllerTemplateType)
			{
				ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Controller Template Type Guid", P_0.controllerTemplateTypeGuid.ToString());
			}
			if (P_0.type == ControllerSetSelector.Type.PersistentControllerInstance)
			{
				ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Device Instance Guid", P_0.deviceInstanceGuid.ToString());
			}
			if (P_0.type == ControllerSetSelector.Type.SessionControllerInstance)
			{
				ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Controller Id", P_0.controllerId.ToString());
			}
		}
	}

	private static void HsTPYzosyktiPKKWpYtkxklDEHcM(Controller P_0, IDictionary<string, bool> P_1, string P_2)
	{
		P_2 += "_templates";
		using ZOleBpQBDPKbvuUhjSPabaYrCsjZ zOleBpQBDPKbvuUhjSPabaYrCsjZ = new ZOleBpQBDPKbvuUhjSPabaYrCsjZ("Templates (" + P_0.templateCount + ")", P_2, P_1);
		if (zOleBpQBDPKbvuUhjSPabaYrCsjZ.WAyeTACitBLRzRlrBpnKHQReGTZjc)
		{
			for (int i = 0; i < P_0.templateCount; i++)
			{
				gBTcPIFvFirhFUlOAcTSpvGFudLMA(P_0.Templates[i], i, P_2, P_1);
			}
		}
	}

	private static void gBTcPIFvFirhFUlOAcTSpvGFudLMA(IControllerTemplate P_0, int P_1, string P_2, IDictionary<string, bool> P_3)
	{
		P_2 += ((P_1 >= 0) ? ("_" + P_1) : "");
		using ZOleBpQBDPKbvuUhjSPabaYrCsjZ zOleBpQBDPKbvuUhjSPabaYrCsjZ = new ZOleBpQBDPKbvuUhjSPabaYrCsjZ(((P_1 >= 0) ? (P_1 + ": ") : "") + P_0.name, P_2, P_3);
		if (!zOleBpQBDPKbvuUhjSPabaYrCsjZ.WAyeTACitBLRzRlrBpnKHQReGTZjc)
		{
			return;
		}
		ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Type GUID", P_0.typeGuid.ToString());
		ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Class Type", P_0.GetType().ToString());
		P_2 += "_elements";
		using ZOleBpQBDPKbvuUhjSPabaYrCsjZ zOleBpQBDPKbvuUhjSPabaYrCsjZ2 = new ZOleBpQBDPKbvuUhjSPabaYrCsjZ("Elements (" + P_0.elementCount + ")", P_2, P_3);
		if (zOleBpQBDPKbvuUhjSPabaYrCsjZ2.WAyeTACitBLRzRlrBpnKHQReGTZjc)
		{
			for (int i = 0; i < P_0.elementCount; i++)
			{
				kUWJtqftNiPamLcEuLRZlwdcovEf(P_0.elements[i], i, P_2, P_3);
			}
		}
	}

	private static void kUWJtqftNiPamLcEuLRZlwdcovEf(IControllerTemplateElement P_0, int P_1, string P_2, IDictionary<string, bool> P_3)
	{
		P_2 += ((P_1 >= 0) ? ("_" + P_1) : "");
		using ZOleBpQBDPKbvuUhjSPabaYrCsjZ zOleBpQBDPKbvuUhjSPabaYrCsjZ = new ZOleBpQBDPKbvuUhjSPabaYrCsjZ(((P_1 >= 0) ? ": " : "") + P_0.descriptiveName + " (id: " + P_0.id + ")", P_2, P_3);
		if (zOleBpQBDPKbvuUhjSPabaYrCsjZ.WAyeTACitBLRzRlrBpnKHQReGTZjc)
		{
			ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Id", P_0.id.ToString());
			ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Name", P_0.descriptiveName.ToString());
			ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Type", P_0.type.ToString());
			ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Exists", P_0.exists.ToString());
			if (P_0.type == ControllerTemplateElementType.Button)
			{
				hXPmNuWiJQoDeFklozqOTcTsKiwF(P_0 as IControllerTemplateButton, P_2, P_3);
			}
			else if (P_0.type == ControllerTemplateElementType.Axis)
			{
				eJfUUmBCZNCQXddUlSLSuKxlENWMA(P_0 as IControllerTemplateAxis, P_2, P_3);
			}
			else if (P_0.type == ControllerTemplateElementType.DPad)
			{
				IControllerTemplateDPad controllerTemplateDPad = P_0 as IControllerTemplateDPad;
				ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Value", controllerTemplateDPad.value.ToString());
				ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Value Prev", controllerTemplateDPad.valuePrev.ToString());
				qdREQngFiViJDVNNdFthVWQdFMcN(controllerTemplateDPad.up, "Up", P_2, P_3);
				qdREQngFiViJDVNNdFthVWQdFMcN(controllerTemplateDPad.right, "Right", P_2, P_3);
				qdREQngFiViJDVNNdFthVWQdFMcN(controllerTemplateDPad.down, "Down", P_2, P_3);
				qdREQngFiViJDVNNdFthVWQdFMcN(controllerTemplateDPad.left, "Left", P_2, P_3);
			}
			else if (P_0.type == ControllerTemplateElementType.Hat)
			{
				IControllerTemplateHat controllerTemplateHat = P_0 as IControllerTemplateHat;
				ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Value", controllerTemplateHat.value.ToString());
				ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Value Prev", controllerTemplateHat.valuePrev.ToString());
				qdREQngFiViJDVNNdFthVWQdFMcN(controllerTemplateHat.up, "up", P_2, P_3);
				qdREQngFiViJDVNNdFthVWQdFMcN(controllerTemplateHat.upRight, "upRight", P_2, P_3);
				qdREQngFiViJDVNNdFthVWQdFMcN(controllerTemplateHat.right, "right", P_2, P_3);
				qdREQngFiViJDVNNdFthVWQdFMcN(controllerTemplateHat.downRight, "downRight", P_2, P_3);
				qdREQngFiViJDVNNdFthVWQdFMcN(controllerTemplateHat.down, "down", P_2, P_3);
				qdREQngFiViJDVNNdFthVWQdFMcN(controllerTemplateHat.downLeft, "downLeft", P_2, P_3);
				qdREQngFiViJDVNNdFthVWQdFMcN(controllerTemplateHat.left, "left", P_2, P_3);
				qdREQngFiViJDVNNdFthVWQdFMcN(controllerTemplateHat.upLeft, "upLeft", P_2, P_3);
			}
			else if (P_0.type == ControllerTemplateElementType.Stick)
			{
				IControllerTemplateStick controllerTemplateStick = P_0 as IControllerTemplateStick;
				ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Value", controllerTemplateStick.value.ToString());
				ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Value Prev", controllerTemplateStick.valuePrev.ToString());
				biKunRUdvpbiIWGvMcIvaCsSAhwKA(controllerTemplateStick.horizontal, "horizontal", P_2, P_3);
				biKunRUdvpbiIWGvMcIvaCsSAhwKA(controllerTemplateStick.vertical, "vertical", P_2, P_3);
				biKunRUdvpbiIWGvMcIvaCsSAhwKA(controllerTemplateStick.rotation, "rotation", P_2, P_3);
			}
			else if (P_0.type == ControllerTemplateElementType.Throttle)
			{
				IControllerTemplateThrottle controllerTemplateThrottle = P_0 as IControllerTemplateThrottle;
				ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Value", controllerTemplateThrottle.value.ToString());
				ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Value Prev", controllerTemplateThrottle.valuePrev.ToString());
				biKunRUdvpbiIWGvMcIvaCsSAhwKA(controllerTemplateThrottle.throttle, "throttle", P_2, P_3);
				qdREQngFiViJDVNNdFthVWQdFMcN(controllerTemplateThrottle.minDetent, "zeroDetent", P_2, P_3);
			}
			else if (P_0.type == ControllerTemplateElementType.ThumbStick)
			{
				IControllerTemplateThumbStick controllerTemplateThumbStick = P_0 as IControllerTemplateThumbStick;
				ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Value", controllerTemplateThumbStick.value.ToString());
				ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Value Prev", controllerTemplateThumbStick.valuePrev.ToString());
				biKunRUdvpbiIWGvMcIvaCsSAhwKA(controllerTemplateThumbStick.horizontal, "horizontal", P_2, P_3);
				biKunRUdvpbiIWGvMcIvaCsSAhwKA(controllerTemplateThumbStick.vertical, "vertical", P_2, P_3);
				qdREQngFiViJDVNNdFthVWQdFMcN(controllerTemplateThumbStick.press, "press", P_2, P_3);
			}
			else if (P_0.type == ControllerTemplateElementType.Yoke)
			{
				IControllerTemplateYoke controllerTemplateYoke = P_0 as IControllerTemplateYoke;
				ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Value", controllerTemplateYoke.value.ToString());
				ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Value Prev", controllerTemplateYoke.valuePrev.ToString());
				biKunRUdvpbiIWGvMcIvaCsSAhwKA(controllerTemplateYoke.rotation, "rotation", P_2, P_3);
				biKunRUdvpbiIWGvMcIvaCsSAhwKA(controllerTemplateYoke.pushPull, "pushPull", P_2, P_3);
			}
			else if (P_0.type == ControllerTemplateElementType.Stick6D)
			{
				IControllerTemplateStick6D controllerTemplateStick6D = P_0 as IControllerTemplateStick6D;
				ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Position", controllerTemplateStick6D.position.ToString());
				ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Position Prev", controllerTemplateStick6D.positionPrev.ToString());
				ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Rotation", controllerTemplateStick6D.rotation.ToString());
				ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Rotation Prev", controllerTemplateStick6D.rotationPrev.ToString());
				biKunRUdvpbiIWGvMcIvaCsSAhwKA(controllerTemplateStick6D.positionX, "PositionX", P_2, P_3);
				biKunRUdvpbiIWGvMcIvaCsSAhwKA(controllerTemplateStick6D.positionY, "PositionY", P_2, P_3);
				biKunRUdvpbiIWGvMcIvaCsSAhwKA(controllerTemplateStick6D.positionZ, "PositionZ", P_2, P_3);
				biKunRUdvpbiIWGvMcIvaCsSAhwKA(controllerTemplateStick6D.rotationX, "RotationX", P_2, P_3);
				biKunRUdvpbiIWGvMcIvaCsSAhwKA(controllerTemplateStick6D.rotationY, "RotationY", P_2, P_3);
				biKunRUdvpbiIWGvMcIvaCsSAhwKA(controllerTemplateStick6D.rotationZ, "RotationZ", P_2, P_3);
			}
			else
			{
				ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Unknown element type", P_0.type.ToString());
			}
		}
	}

	private static void biKunRUdvpbiIWGvMcIvaCsSAhwKA(IControllerTemplateAxis P_0, string P_1, string P_2, IDictionary<string, bool> P_3)
	{
		P_2 = P_2 + "_" + P_1;
		using ZOleBpQBDPKbvuUhjSPabaYrCsjZ zOleBpQBDPKbvuUhjSPabaYrCsjZ = new ZOleBpQBDPKbvuUhjSPabaYrCsjZ(StringTools.VariableNameToDisplayName(P_1), P_2, P_3);
		if (zOleBpQBDPKbvuUhjSPabaYrCsjZ.WAyeTACitBLRzRlrBpnKHQReGTZjc)
		{
			eJfUUmBCZNCQXddUlSLSuKxlENWMA(P_0, P_2, P_3);
		}
	}

	private static void qdREQngFiViJDVNNdFthVWQdFMcN(IControllerTemplateButton P_0, string P_1, string P_2, IDictionary<string, bool> P_3)
	{
		P_2 = P_2 + "_" + P_1;
		using ZOleBpQBDPKbvuUhjSPabaYrCsjZ zOleBpQBDPKbvuUhjSPabaYrCsjZ = new ZOleBpQBDPKbvuUhjSPabaYrCsjZ(StringTools.VariableNameToDisplayName(P_1), P_2, P_3);
		if (zOleBpQBDPKbvuUhjSPabaYrCsjZ.WAyeTACitBLRzRlrBpnKHQReGTZjc)
		{
			hXPmNuWiJQoDeFklozqOTcTsKiwF(P_0, P_2, P_3);
		}
	}

	private static void eJfUUmBCZNCQXddUlSLSuKxlENWMA(IControllerTemplateAxis P_0, string P_1, IDictionary<string, bool> P_2)
	{
		ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Value", P_0.value.ToString());
		ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Value Prev", P_0.valuePrev.ToString());
		IxctAJocEPlwzgaGhniXYajFPIpU(P_0.source, "target", P_1, P_2);
	}

	private static void hXPmNuWiJQoDeFklozqOTcTsKiwF(IControllerTemplateButton P_0, string P_1, IDictionary<string, bool> P_2)
	{
		ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Value", P_0.value.ToString());
		ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Value Prev", P_0.valuePrev.ToString());
		ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Pressure", P_0.pressure.ToString());
		ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Pressure Prev", P_0.pressurePrev.ToString());
		ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Just Pressed", P_0.justPressed.ToString());
		ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Just Released", P_0.justReleased.ToString());
		XeKUYJoxCBeSAuXEHJfLeNdBGDkN(P_0.source, "target", P_1, P_2);
	}

	private static void IxctAJocEPlwzgaGhniXYajFPIpU(IControllerTemplateAxisSource P_0, string P_1, string P_2, IDictionary<string, bool> P_3)
	{
		P_2 = P_2 + "_" + P_1;
		using ZOleBpQBDPKbvuUhjSPabaYrCsjZ zOleBpQBDPKbvuUhjSPabaYrCsjZ = new ZOleBpQBDPKbvuUhjSPabaYrCsjZ("Axis Target", P_2, P_3);
		if (zOleBpQBDPKbvuUhjSPabaYrCsjZ.WAyeTACitBLRzRlrBpnKHQReGTZjc)
		{
			ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Split Axis", P_0.splitAxis.ToString());
			ttueIPWfYvDFCbryMeMsuuuOxJpDA(P_0.fullTarget, "target", P_2, P_3);
			ttueIPWfYvDFCbryMeMsuuuOxJpDA(P_0.positiveTarget, "positiveTarget", P_2, P_3);
			ttueIPWfYvDFCbryMeMsuuuOxJpDA(P_0.negativeTarget, "negativeTarget", P_2, P_3);
		}
	}

	private static void XeKUYJoxCBeSAuXEHJfLeNdBGDkN(IControllerTemplateButtonSource P_0, string P_1, string P_2, IDictionary<string, bool> P_3)
	{
		P_2 = P_2 + "_" + P_1;
		ttueIPWfYvDFCbryMeMsuuuOxJpDA(P_0.target, "target", P_2, P_3);
	}

	private static void ttueIPWfYvDFCbryMeMsuuuOxJpDA(IControllerElementTarget P_0, string P_1, string P_2, IDictionary<string, bool> P_3)
	{
		P_2 = P_2 + "_" + P_1;
		using ZOleBpQBDPKbvuUhjSPabaYrCsjZ zOleBpQBDPKbvuUhjSPabaYrCsjZ = new ZOleBpQBDPKbvuUhjSPabaYrCsjZ(StringTools.VariableNameToDisplayName(P_1), P_2, P_3);
		if (zOleBpQBDPKbvuUhjSPabaYrCsjZ.WAyeTACitBLRzRlrBpnKHQReGTZjc)
		{
			ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Element Identifier Id", P_0.elementIdentifierId.ToString());
			ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Axis Range", P_0.axisRange.ToString());
			ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Has Target", P_0.hasTarget.ToString());
			if (P_0.hasTarget)
			{
				ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp("Target Element", P_0.descriptiveName);
			}
		}
	}

	private static bool HrGIQrMYKzSGiQPnjFRNPSAicKyu(string P_0, bool P_1)
	{
		ODamYsBvIrppZTfOxwvNniVIDSXgA.pIztTgpXiwcxOQglMlvtVSQDhJtp(P_0, P_1.ToString());
		return false;
	}

	private static GUIStyle QMjmuhwMXMJrbgpeHBqVlyCeVWGe()
	{
		return VWBgCflowLdkPEENYDYGqYUsAEdsA(new GUIStyle(GUI.skin.label)
		{
			margin = 
			{
				top = 1,
				bottom = 1
			},
			fontSize = FuEXgLuieehllyvcAYbRgRRSyvag._fontSize
		});
	}

	public static GUIStyle GetToggleStyle()
	{
		GUIStyle gUIStyle = VWBgCflowLdkPEENYDYGqYUsAEdsA(new GUIStyle(GUI.skin.toggle)
		{
			margin = 
			{
				top = 0,
				bottom = 0
			}
		});
		gUIStyle.fontSize = FuEXgLuieehllyvcAYbRgRRSyvag._fontSize;
		return gUIStyle;
	}

	private static GUIStyle VWBgCflowLdkPEENYDYGqYUsAEdsA(GUIStyle P_0)
	{
		P_0 = new GUIStyle(P_0);
		P_0.margin.left = XTwvIjnPmBwuZIreqQMONOechNlfA.TtocDbzjSdpARVfOvVmQWKGsBoFy() * 20;
		return P_0;
	}
}
