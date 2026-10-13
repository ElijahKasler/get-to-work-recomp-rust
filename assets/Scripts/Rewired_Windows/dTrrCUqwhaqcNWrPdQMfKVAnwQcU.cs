using System;
using System.Collections.Generic;
using Rewired;
using Rewired.Interfaces;
using Rewired.Internal;
using Rewired.Platforms;
using Rewired.Utils;
using Rewired.Utils.Classes.Utility;
using UnityEngine;

internal sealed class dTrrCUqwhaqcNWrPdQMfKVAnwQcU : IElementIdentifierTool
{
	private Rewired.Internal.GUIText yvSGegkuJhifZYgxrfygEZgRjkJmA;

	private string PcrPVuVszgsqVnkPOzapNjhyxiNo;

	private int olwaZDXqouWAahKsDKQYpcHZgmUB;

	private hWHYtXHqbQDSYkFuTyFtXjkGnJJx OBEcziuLZhSKrPsPxUxYprAccSrM;

	private acNIMEkbdUZflpTVBxiqmIgjMDSMA KNwMvkfRLLxIhMqbdBWRhbvazieBA;

	private Guid WEqeAeiBpJXPcQFcbOFtbdQKMZhQb;

	private IList<cQBxMAHukbVUZQupSRBOiSlaiust> dfkmcfyuoTQfrEWpzKFdTOjiYZVf;

	private IList<cQBxMAHukbVUZQupSRBOiSlaiust> jOTuwxPFuMOayyiuvbInInPRvIfk;

	private bool wyUNhXhCKBINVhbLXdwNewhyScHFA;

	private bool coCtpZRIMLsaBlXKwJhBayxWjWDp;

	private bool qXLAofQMVlaJMCppldWVpUEXApttA;

	private int SElINYtAkflCSBsKBaqYoZfjZkyc;

	private TimerRealTime aaEhgYAjGeZvppVpYLJCDkgBRLqJb;

	public void Initialize(Rewired.Internal.GUIText text)
	{
		yvSGegkuJhifZYgxrfygEZgRjkJmA = text;
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
			Rewired.Logger.LogError("Direct Input cannot be run on this platform. You must be running the editor in Windows.");
		}
		else if (ReInput.currentPlatform != Platform.Windows)
		{
			Rewired.Logger.LogError("Direct Input cannot be run on this build target. Be sure Unity's build target is set to Windows Standalone.");
		}
		else if (ReInput.primaryInputManager.inputSource is InputSourceWrapper<hWHYtXHqbQDSYkFuTyFtXjkGnJJx> { source: not null } inputSourceWrapper)
		{
			OBEcziuLZhSKrPsPxUxYprAccSrM = inputSourceWrapper.source;
			ReInput.primaryInputManager.SystemDeviceConnectedEvent += CtWwwdhDxWypOydPIPrNbGnGyiqd;
			ReInput.primaryInputManager.SystemDeviceDisconnectedEvent += WwthvtuhrcSGgNGmGzaEoWvseKVk;
			aaEhgYAjGeZvppVpYLJCDkgBRLqJb = new TimerRealTime(1.0);
			aaEhgYAjGeZvppVpYLJCDkgBRLqJb.Start();
			UedlGptklirMgXwgPwAWJBgAvhvH();
			qXLAofQMVlaJMCppldWVpUEXApttA = true;
		}
		else
		{
			Rewired.Logger.LogError("Unable to initialize Direct Input! You must add a Rewired Input Manager to the scene and set the input mode to Direct Input.");
		}
	}

	void IElementIdentifierTool.Start()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Start
		this.Start();
	}

	public void Update()
	{
		if (!qXLAofQMVlaJMCppldWVpUEXApttA)
		{
			return;
		}
		PcrPVuVszgsqVnkPOzapNjhyxiNo = "Direct Input Joystick Element Identifier\n\n";
		yvSGegkuJhifZYgxrfygEZgRjkJmA.text = PcrPVuVszgsqVnkPOzapNjhyxiNo;
		if (Input.GetKeyDown(KeyCode.A))
		{
			wyUNhXhCKBINVhbLXdwNewhyScHFA = !wyUNhXhCKBINVhbLXdwNewhyScHFA;
		}
		if (wyUNhXhCKBINVhbLXdwNewhyScHFA)
		{
			yvSGegkuJhifZYgxrfygEZgRjkJmA.text += "All Devices:\n";
			foreach (cQBxMAHukbVUZQupSRBOiSlaiust item in jOTuwxPFuMOayyiuvbInInPRvIfk)
			{
				Rewired.Internal.GUIText gUIText = yvSGegkuJhifZYgxrfygEZgRjkJmA;
				gUIText.text = gUIText.text + item.vHpBTZZIoLIoPnXyKAkSYMVfCxZaA + ", " + item.HNrUNwsTKWScwPOGZxOXFZHPMZyf() + ", " + new PidVid(item.yEXnHNQgkgjqFmjHlzhzLVpNUShG).ToString() + ", " + item.LSjdDFGdiJLJfXCMYjIuTFhKegzb() + ", " + item.GLDqIkElRXDveSDwJWiozEqXCSThA + ", " + item.yjsOHNPhCZganElhGknPCaAdkCiqb + "\n";
			}
			yvSGegkuJhifZYgxrfygEZgRjkJmA.text += "\n";
		}
		int num = olwaZDXqouWAahKsDKQYpcHZgmUB;
		Guid wEqeAeiBpJXPcQFcbOFtbdQKMZhQb = WEqeAeiBpJXPcQFcbOFtbdQKMZhQb;
		if (ReInput.controllers.Keyboard.GetKeyDown(KeyCode.Equals) || ReInput.controllers.Keyboard.GetKeyDown(KeyCode.Plus) || ReInput.controllers.Keyboard.GetKeyDown(KeyCode.KeypadPlus))
		{
			olwaZDXqouWAahKsDKQYpcHZgmUB++;
		}
		if (ReInput.controllers.Keyboard.GetKeyDown(KeyCode.KeypadMinus) || ReInput.controllers.Keyboard.GetKeyDown(KeyCode.Minus))
		{
			olwaZDXqouWAahKsDKQYpcHZgmUB--;
		}
		if (aaEhgYAjGeZvppVpYLJCDkgBRLqJb.Update())
		{
			int num2 = OBEcziuLZhSKrPsPxUxYprAccSrM.KlBKtwQKHQMpgmpWZeXkZpUeGjubA(KwMHHfNTwEYhGoVEiNBaXUMLlAml.All, grafWZdmFPBElhoJiCXQcZctJhNX.AttachedOnly);
			if (num2 != SElINYtAkflCSBsKBaqYoZfjZkyc)
			{
				SElINYtAkflCSBsKBaqYoZfjZkyc = num2;
				coCtpZRIMLsaBlXKwJhBayxWjWDp = true;
			}
			aaEhgYAjGeZvppVpYLJCDkgBRLqJb.Start();
		}
		if (coCtpZRIMLsaBlXKwJhBayxWjWDp)
		{
			UedlGptklirMgXwgPwAWJBgAvhvH();
			coCtpZRIMLsaBlXKwJhBayxWjWDp = false;
		}
		int num3 = ((dfkmcfyuoTQfrEWpzKFdTOjiYZVf != null) ? dfkmcfyuoTQfrEWpzKFdTOjiYZVf.Count : 0);
		if (num3 == 0)
		{
			return;
		}
		if (olwaZDXqouWAahKsDKQYpcHZgmUB < 0)
		{
			olwaZDXqouWAahKsDKQYpcHZgmUB = num3 - 1;
		}
		else if (olwaZDXqouWAahKsDKQYpcHZgmUB >= num3)
		{
			olwaZDXqouWAahKsDKQYpcHZgmUB = 0;
		}
		WEqeAeiBpJXPcQFcbOFtbdQKMZhQb = dfkmcfyuoTQfrEWpzKFdTOjiYZVf[olwaZDXqouWAahKsDKQYpcHZgmUB].OlWJPSagxOemyFmiXRXAAqoAkMpib;
		bool flag = false;
		if (num != olwaZDXqouWAahKsDKQYpcHZgmUB || wEqeAeiBpJXPcQFcbOFtbdQKMZhQb != WEqeAeiBpJXPcQFcbOFtbdQKMZhQb)
		{
			flag = true;
		}
		if ((KNwMvkfRLLxIhMqbdBWRhbvazieBA == null) | flag)
		{
			if (KNwMvkfRLLxIhMqbdBWRhbvazieBA != null)
			{
				KNwMvkfRLLxIhMqbdBWRhbvazieBA.mEmqoSvqSexnhboyTfWnkXezmFsc();
			}
			KNwMvkfRLLxIhMqbdBWRhbvazieBA = new acNIMEkbdUZflpTVBxiqmIgjMDSMA(OBEcziuLZhSKrPsPxUxYprAccSrM, dfkmcfyuoTQfrEWpzKFdTOjiYZVf[olwaZDXqouWAahKsDKQYpcHZgmUB].OlWJPSagxOemyFmiXRXAAqoAkMpib);
			if (KNwMvkfRLLxIhMqbdBWRhbvazieBA == null)
			{
				return;
			}
			IList<XdTkrmSnPZqRHLipcnjEiLzLeZek> list = KNwMvkfRLLxIhMqbdBWRhbvazieBA.aBQUsptJkFuWEMPGXbWCYeBtmPZj();
			if (list != null)
			{
				for (int i = 0; i < list.Count; i++)
				{
					if ((list[i].vMxfCdbrpLTpfZZuSxKADfEWjvtw.NIRMSGpfjJFEcGuJHZTAaNtlyQRKA() & rWezaGflEYhSWijeLCQlsOUkWUZN.Axis) != rWezaGflEYhSWijeLCQlsOUkWUZN.All)
					{
						KNwMvkfRLLxIhMqbdBWRhbvazieBA.XNgCRWFEXAlAiaivgeZScZsgbRKkD().CDerDNBRKENEuDHFHYgovCgLLpNo(new UrYqMljpjmvTgRRFXPSTBEPnMLKn(-65535, 65535));
					}
				}
			}
			KNwMvkfRLLxIhMqbdBWRhbvazieBA.NRLBiBqDROwlvswVRjyZjAGQpKVj();
		}
		YuqGSycdazpjQDmHVuiUuFfOMQsAA yuqGSycdazpjQDmHVuiUuFfOMQsAA;
		try
		{
			yuqGSycdazpjQDmHVuiUuFfOMQsAA = KNwMvkfRLLxIhMqbdBWRhbvazieBA.ODwHMkLeTlJzPGZOpXXuVpwzQlFI();
		}
		catch
		{
			yuqGSycdazpjQDmHVuiUuFfOMQsAA = null;
		}
		if (yuqGSycdazpjQDmHVuiUuFfOMQsAA == null)
		{
			return;
		}
		if (num3 > 0)
		{
			PcrPVuVszgsqVnkPOzapNjhyxiNo = PcrPVuVszgsqVnkPOzapNjhyxiNo + num3 + " connected devices:\n";
		}
		for (int j = 0; j < num3; j++)
		{
			PcrPVuVszgsqVnkPOzapNjhyxiNo = PcrPVuVszgsqVnkPOzapNjhyxiNo + dfkmcfyuoTQfrEWpzKFdTOjiYZVf[j].vHpBTZZIoLIoPnXyKAkSYMVfCxZaA + "\n";
		}
		PcrPVuVszgsqVnkPOzapNjhyxiNo += "\n";
		PcrPVuVszgsqVnkPOzapNjhyxiNo = PcrPVuVszgsqVnkPOzapNjhyxiNo + "Current DI device " + olwaZDXqouWAahKsDKQYpcHZgmUB + ": " + dfkmcfyuoTQfrEWpzKFdTOjiYZVf[olwaZDXqouWAahKsDKQYpcHZgmUB].vHpBTZZIoLIoPnXyKAkSYMVfCxZaA + "\n";
		PcrPVuVszgsqVnkPOzapNjhyxiNo += "(Press + or - to change monitored device id.)\n\n";
		yxCcqPdJzZRkaPIQAtaQfRvGcQNCA("Identifier", new PidVid(KNwMvkfRLLxIhMqbdBWRhbvazieBA.HLSsrxDdoIKaYjqOkHwSBKLobtMJ().yEXnHNQgkgjqFmjHlzhzLVpNUShG));
		yxCcqPdJzZRkaPIQAtaQfRvGcQNCA("Instance GUID", KNwMvkfRLLxIhMqbdBWRhbvazieBA.HLSsrxDdoIKaYjqOkHwSBKLobtMJ().OlWJPSagxOemyFmiXRXAAqoAkMpib);
		yxCcqPdJzZRkaPIQAtaQfRvGcQNCA("Product Id", KNwMvkfRLLxIhMqbdBWRhbvazieBA.XNgCRWFEXAlAiaivgeZScZsgbRKkD().tnfeEXhTjjHXygAIfrrHoViwKtmVb());
		yxCcqPdJzZRkaPIQAtaQfRvGcQNCA("Device Type", KNwMvkfRLLxIhMqbdBWRhbvazieBA.PEwJSkJWMSoSqZezTztTuZDIRWxk().ufhaQjuSLPunnCvPRdrsJYRRYwqK().ToString());
		PcrPVuVszgsqVnkPOzapNjhyxiNo += "\n";
		yxCcqPdJzZRkaPIQAtaQfRvGcQNCA("Axis Count", KNwMvkfRLLxIhMqbdBWRhbvazieBA.PEwJSkJWMSoSqZezTztTuZDIRWxk().UJGVVXnPhfDUuHUzZsmSEAHUxaGz);
		yxCcqPdJzZRkaPIQAtaQfRvGcQNCA("Button Count", KNwMvkfRLLxIhMqbdBWRhbvazieBA.PEwJSkJWMSoSqZezTztTuZDIRWxk().OHYegIVvjHrdtWrbLQKrhxBWGoqV);
		yxCcqPdJzZRkaPIQAtaQfRvGcQNCA("Hat Count", KNwMvkfRLLxIhMqbdBWRhbvazieBA.PEwJSkJWMSoSqZezTztTuZDIRWxk().frHStzqhmpGjbHvmzBdHObKZicqO);
		PcrPVuVszgsqVnkPOzapNjhyxiNo += "\n";
		if (flag)
		{
			Rewired.Logger.Log("Device Name: \"" + dfkmcfyuoTQfrEWpzKFdTOjiYZVf[olwaZDXqouWAahKsDKQYpcHZgmUB].vHpBTZZIoLIoPnXyKAkSYMVfCxZaA + "\"");
			Rewired.Logger.Log("Identifier: " + new PidVid(KNwMvkfRLLxIhMqbdBWRhbvazieBA.HLSsrxDdoIKaYjqOkHwSBKLobtMJ().yEXnHNQgkgjqFmjHlzhzLVpNUShG).ToString());
		}
		for (int k = 0; k < 32; k++)
		{
			int num4 = HbAoXcdqtWtAMarUrRbcZkqvCHVK((DirectInputAxis)k, yuqGSycdazpjQDmHVuiUuFfOMQsAA);
			DirectInputAxis directInputAxis = (DirectInputAxis)k;
			string text = directInputAxis.ToString();
			yxCcqPdJzZRkaPIQAtaQfRvGcQNCA(text, num4 + " (" + AVpctOfCiAAYjBaeNIzYPSnGdliy(num4) + ")");
		}
		int[] array = yuqGSycdazpjQDmHVuiUuFfOMQsAA.VIFemHRsxjGJBymMifWdFGEZfKMi();
		for (int l = 0; l < 4; l++)
		{
			int num5 = array[l];
			string text2 = "Hat " + l;
			yxCcqPdJzZRkaPIQAtaQfRvGcQNCA(text2, num5);
		}
		bool[] array2 = yuqGSycdazpjQDmHVuiUuFfOMQsAA.qErgkiWlApmmOQtkdLMfhzipsdiC();
		string text3 = "";
		for (int m = 0; m < 128; m++)
		{
			if (array2[m])
			{
				if (text3 != "")
				{
					text3 += ", ";
				}
				text3 += m;
			}
		}
		yxCcqPdJzZRkaPIQAtaQfRvGcQNCA("Buttons ", text3);
		yvSGegkuJhifZYgxrfygEZgRjkJmA.text = PcrPVuVszgsqVnkPOzapNjhyxiNo;
	}

	void IElementIdentifierTool.Update()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Update
		this.Update();
	}

	private void UedlGptklirMgXwgPwAWJBgAvhvH()
	{
		dfkmcfyuoTQfrEWpzKFdTOjiYZVf = OBEcziuLZhSKrPsPxUxYprAccSrM.UMlBPabSMDscUAzWvpGCMyWHBsySA(KwMHHfNTwEYhGoVEiNBaXUMLlAml.GameControl, grafWZdmFPBElhoJiCXQcZctJhNX.AttachedOnly);
		jOTuwxPFuMOayyiuvbInInPRvIfk = OBEcziuLZhSKrPsPxUxYprAccSrM.UMlBPabSMDscUAzWvpGCMyWHBsySA(KwMHHfNTwEYhGoVEiNBaXUMLlAml.All, grafWZdmFPBElhoJiCXQcZctJhNX.AttachedOnly);
		SElINYtAkflCSBsKBaqYoZfjZkyc = ((jOTuwxPFuMOayyiuvbInInPRvIfk != null) ? jOTuwxPFuMOayyiuvbInInPRvIfk.Count : 0);
	}

	private void CtWwwdhDxWypOydPIPrNbGnGyiqd()
	{
		abBipTKvXOqYLdzNAfxjfNqUYLLd();
	}

	private void WwthvtuhrcSGgNGmGzaEoWvseKVk()
	{
		abBipTKvXOqYLdzNAfxjfNqUYLLd();
	}

	private void abBipTKvXOqYLdzNAfxjfNqUYLLd()
	{
		ULQhSHAOKTiHLkZlzMtobLwGDpHyA();
		coCtpZRIMLsaBlXKwJhBayxWjWDp = true;
	}

	private void ULQhSHAOKTiHLkZlzMtobLwGDpHyA()
	{
		olwaZDXqouWAahKsDKQYpcHZgmUB = 0;
		KNwMvkfRLLxIhMqbdBWRhbvazieBA = null;
		WEqeAeiBpJXPcQFcbOFtbdQKMZhQb = Guid.Empty;
		dfkmcfyuoTQfrEWpzKFdTOjiYZVf = null;
		jOTuwxPFuMOayyiuvbInInPRvIfk = null;
		wyUNhXhCKBINVhbLXdwNewhyScHFA = false;
		coCtpZRIMLsaBlXKwJhBayxWjWDp = false;
		SElINYtAkflCSBsKBaqYoZfjZkyc = 0;
	}

	private void yxCcqPdJzZRkaPIQAtaQfRvGcQNCA(string P_0, object P_1)
	{
		PcrPVuVszgsqVnkPOzapNjhyxiNo = PcrPVuVszgsqVnkPOzapNjhyxiNo + P_0 + " = " + P_1.ToString() + "\n";
	}

	private int HbAoXcdqtWtAMarUrRbcZkqvCHVK(DirectInputAxis P_0, YuqGSycdazpjQDmHVuiUuFfOMQsAA P_1)
	{
		return P_0 switch
		{
			DirectInputAxis.X => P_1.gxBsFsxYeUvctokfGCURaGsbUyutA(), 
			DirectInputAxis.Y => P_1.EAvyVrLlffIGBCwCKlgkROkiFcxXA(), 
			DirectInputAxis.Z => P_1.UrCOMSWhfcnCYPbVZuYqurcFgmyh(), 
			DirectInputAxis.RotationX => P_1.EYXvsRfzGMJLtDhYQYigKafuCUZH(), 
			DirectInputAxis.RotationY => P_1.dihzeHqQKJKeUpfhRFhZViySmzgu(), 
			DirectInputAxis.RotationZ => P_1.YNpRVxrnJEqVFeuFMCiSzRKeusaD(), 
			DirectInputAxis.Slider0 => P_1.iaXZoZvIFXjytzMBbbmkzbOKNxEO()[0], 
			DirectInputAxis.Slider1 => P_1.iaXZoZvIFXjytzMBbbmkzbOKNxEO()[1], 
			DirectInputAxis.VelocityX => P_1.ECAgwQPifQAHnJYjEsedHOvPkEypA(), 
			DirectInputAxis.VelocityY => P_1.orgIJYsAcoxhqsqULGfAuYvGtJvl(), 
			DirectInputAxis.VelocityZ => P_1.osrqxkLCfXBabdzyrpcxbZMnixYLA(), 
			DirectInputAxis.AngularVelocityX => P_1.mKONMghyjMppaqTTskdRSjjSoaDx(), 
			DirectInputAxis.AngularVelocityY => P_1.BLZHXdOiVSFYbXMOZfisIwjLONyj(), 
			DirectInputAxis.AngularVelocityZ => P_1.sXsmbWsHPnxVtZRQxNHJjlyLkYwi(), 
			DirectInputAxis.VelocitySlider0 => P_1.zwucKPtMFblGsSMOUVQHCHaeOKSl()[0], 
			DirectInputAxis.VelocitySlider1 => P_1.zwucKPtMFblGsSMOUVQHCHaeOKSl()[1], 
			DirectInputAxis.AccelerationX => P_1.hMMoBUXlIebxEIplMkDwVItzdUcR(), 
			DirectInputAxis.AccelerationY => P_1.cAHnZJbuoCjivqDWOTUdcgHJOmsF(), 
			DirectInputAxis.AccelerationZ => P_1.yoXwtLbsxtTPRbovfpwcMyswBhPA(), 
			DirectInputAxis.AngularAccelerationX => P_1.ZFjNvEnNIzOJQjpaKoHqVlcSYgXp(), 
			DirectInputAxis.AngularAccelerationY => P_1.YZkWevoQyAqypxmIuVdetThqUMfL(), 
			DirectInputAxis.AngularAccelerationZ => P_1.oPHkHhlNMhhZmGxWQvmXHZUuMVnbA(), 
			DirectInputAxis.AccelerationSlider0 => P_1.KAjHmViwsLxsNRKHOkAHHFdFmRcFA()[0], 
			DirectInputAxis.AccelerationSlider1 => P_1.KAjHmViwsLxsNRKHOkAHHFdFmRcFA()[1], 
			DirectInputAxis.ForceX => P_1.BPbUNfqSweRpKTKVTYsIHPUPaCzFA(), 
			DirectInputAxis.ForceY => P_1.dDRWBgMSyKkAHmwkNMseVebyutgT(), 
			DirectInputAxis.ForceZ => P_1.eSydsUkDDXBIwUKihnwRcVSFZTlZB(), 
			DirectInputAxis.TorqueX => P_1.mNsyLJeDNbvJAwAigrgyKpIHslpI(), 
			DirectInputAxis.TorqueY => P_1.dmuCofuxFJhCBfVvDINZstogxQNN(), 
			DirectInputAxis.TorqueZ => P_1.ouznYnQQrmmrsleoCCtNmQovpPjV(), 
			DirectInputAxis.ForceSlider0 => P_1.htHdZJmgLWQTrbBlVANIvPPugVIy()[0], 
			DirectInputAxis.ForceSlider1 => P_1.htHdZJmgLWQTrbBlVANIvPPugVIy()[1], 
			_ => 0, 
		};
	}

	private float AVpctOfCiAAYjBaeNIzYPSnGdliy(int P_0)
	{
		if (P_0 == 0)
		{
			return 0f;
		}
		return MathTools.Clamp((float)MathTools.Abs(P_0) / 65535f * (float)MathTools.Sign(P_0), -1f, 1f);
	}

	public void OnDestroy()
	{
		if (KNwMvkfRLLxIhMqbdBWRhbvazieBA != null)
		{
			KNwMvkfRLLxIhMqbdBWRhbvazieBA.mEmqoSvqSexnhboyTfWnkXezmFsc();
		}
	}

	void IElementIdentifierTool.OnDestroy()
	{
		//ILSpy generated this explicit interface implementation from .override directive in OnDestroy
		this.OnDestroy();
	}
}
