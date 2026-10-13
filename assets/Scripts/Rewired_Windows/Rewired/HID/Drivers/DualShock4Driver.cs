using System;
using System.Diagnostics;
using Rewired.ControllerExtensions;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using UnityEngine;

namespace Rewired.HID.Drivers;

[CustomObfuscation(rename = false)]
[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
internal class DualShock4Driver : HIDDeviceDriver, IDriver_DualShock4, IControllerDriver, IHIDControllerExtension, IDisposable
{
	private enum DcGGMXFrNQQwHLHtZApLbWAekehGA
	{
		X = 0,
		Y = 1,
		Z = 2
	}

	private enum VTjkRtHfxLRjQrsvpeinFinGHUoO
	{
		None = 0,
		XZ = 1,
		Y = 2
	}

	private static class RrVuaSuBSVqUhLQaZSsbpKVjsLrD
	{
		private const uint HwTtdgqqIQEsCIVNPeJSKfixssQuA = 3988292384u;

		public unsafe static uint NNGYjuYWamgqPFdqfzpTTZKakKMg(byte* P_0, int P_1, uint P_2)
		{
			return ~txoSxvMdHhjWmQTUUiKBJaHfQKSj(txoSxvMdHhjWmQTUUiKBJaHfQKSj(uint.MaxValue, (byte*)(&P_2), 1, 3988292384u), P_0, P_1, 3988292384u);
		}

		public unsafe static uint HmeCaJwBCJgqIdvzpwfFnKwokvMA(uint P_0, byte* P_1, int P_2)
		{
			return txoSxvMdHhjWmQTUUiKBJaHfQKSj(P_0, P_1, P_2, 3988292384u);
		}

		private unsafe static uint txoSxvMdHhjWmQTUUiKBJaHfQKSj(uint P_0, byte* P_1, int P_2, uint P_3)
		{
			for (int i = 0; i < P_2; i++)
			{
				P_0 ^= P_1[i];
				for (int j = 0; j < 8; j++)
				{
					P_0 = (P_0 >> 1) ^ (((P_0 & 1) != 0) ? P_3 : 0);
				}
			}
			return P_0;
		}
	}

	private enum hCkCmewugAAZjOegSAFDJPUvxjnJA
	{
		Discharging = 0,
		Charging = 1,
		Full = 2,
		Unknown = 3
	}

	private const float HcNYruMDEeDocfiCYNaOPWsaqgSEA = 4f;

	private const int LNmqAcykgchrzbZUreBKOgoDDyDQA = 14;

	private const int WmSPkPPepHgbTGbCHezvsLYierhGb = 2;

	private const int lYONdeqBTdjCmPBKAdUzbbvtYxVO = 0;

	private const int wwryTKIAikggKblWtTdNkiGyqgyTA = 1912;

	private const int ZaJkfGBHWbAJShLkQscuSqCHwRSS = 0;

	private const int AZnDxeEOWiBWaEYFlHrXtkPckuhG = 941;

	private const bool jWMMdHFpmCqaPUutByGbmZzWAiP = false;

	private const bool RqaLvcOCPJNGdaGuydMFDKcuiqdZA = true;

	private const float joYBUYJaWVtNJDdEYCHDIkiTArbLA = 2.5f;

	private const int KtCGuINnTgnHRdCvXBwgfhTmWjfRA = 0;

	private const int XTpuuFvRhtimTfTSKmXRDIthYdOQB = 0;

	private const int reoBwjFJsmMDKYroWwjeFFslwrHEA = 1;

	private const int FhzQXqHDdYYHPdedcvJyVnoEpagR = 0;

	private const int hcsEtJBjMXeHOKGpngdSPrmEzhguA = 0;

	private const int ubLfylFCXdnMvBcOlJtBFQEbISlFc = 0;

	private const int cUKOvzCqmKYRlnVPqnpOoFUENFnd = 1;

	private const int lXDGMMwLyINllbwExbaulCtTbQqg = 17;

	private const int rHGAMGbjDiIfJKtgBFhbTIizihzN = 0;

	private const int AJARrFOUxinOPLgEbVbllPxavYMd = 2;

	private const int lHHDjucpQLiPogiRvmYeHMsuAhcs = 64;

	private const int YqYrSFMAcMudJSLtkxcXXEVfxGQe = 78;

	private const byte uSJBPRxwbnyYHWepzTdltacTONjC = 17;

	private const byte QzFUHNjQUimpEJBFhTxBzcHAflTi = 5;

	private const byte sAtuKSIXaYikroQOamVXDcuUOJAQ = 2;

	private const byte dwTjLKcFldiIHXuekCzMfOCXfHYVA = 37;

	private const byte DpjjdmsbOYSxaIeqTccdNmSpIAvT = 5;

	private const byte COSfVLOrbWaVFVwyLqJfFfjbjHcN = 41;

	private const byte wjXrwBlBXfntcQsPvHqeVMtepOvO = 163;

	private const byte vfrakHLJfoEbNJIjyIlvIMTkNetVb = 49;

	private const byte GgVsvIrSlgFEkkKQXIDyWuLBUBjy = 18;

	private const byte bWuglRJxJQrCXreiVwaIsQGOhJkiA = 16;

	private const byte KNbjwgZixToxIGiNaMLRyGBRbkLZ = 161;

	private const byte otkfuNCfshHVMsmILBSwUOVhqxKRA = 162;

	private const byte LtjQCxPmcYDXYgREMPjxhtAKaKNAA = 163;

	private const int QUoQBxeOOgCdWTrkBujnUlrQoMUE = 1;

	private const int HcxPkfGmosLEZepfIDljxwVEofbN = 2;

	private const int UNKuhpQFJbAGfsODQtjxjwfchCWm = 3;

	private const int jUyUKEsdHQsjZoHeEihEgtLkUFbq = 4;

	private const int LKzbQcxjTlusvrzLjEvEOmKvsUmI = 8;

	private const int pmADhFMPxEMUgtMnNwYskxCdVqfw = 9;

	private const int rbvSedtGyQYMcnYrbCKjAJducUbX = 5;

	private const int lcVtBVIrJOWQtKqHGKcbGGqyNOjh = 19;

	private const int YZhYuEiziletOkiLBQDgWMTHUpUV = 13;

	private const int ITEdyneYXREpEejbpmjeeElFkmNpB = 35;

	private const int prJfMgxmcpNeDMvaLMndAoPFeXYdA = 5;

	private const int VvNKAwkioJtokBpMWQMolEqmDcHaA = 6;

	private const int IiudmgxOSgeQSfQmGMHLbXkTAALbA = 7;

	private const int KURltjMXtZUgmFWVZgZleAXrRnpe = 10;

	private const int GXgUwUeCqMbkoxkFUDycQnthobpW = 30;

	private const int XEbJVeksGehWBVHXbSFJRjGveiLgA = 27;

	private const byte XdazHLTwTLOUqCHFUFyMdqtPbvUm = 200;

	private const byte SJpFaccaTRKwhelcFVtmzNthofEX = 53;

	private const byte LPNCrZgVDiDjKienEVeOhxVAFEaGd = byte.MaxValue;

	private const byte RDgHtenWqxNhjQQpCQgvjQQpZlhj = 0;

	private const bool PtJxjVbyQpISdDqbOgzfCvfohraI = true;

	private const int XmlbPYfjxfTOnIoLohYImtegETSBA = 60;

	private const int HkeLqNZJkPliFHPEThcnBHLAqXeOA = 60;

	private const int dSIAtxwJzsrMLkHjmETUihFMyKcI = 187500;

	private const float sfWqATgMoYFSiIBniChHWNUXLjilA = 8192f;

	private const float RYvZvvILhKWPODrHeboqaAKpiWwFA = 0.0010652969f;

	private const float wesPsAGqqbEZDCCkEIlAGRDGzGDEB = 0.06103702f;

	private const bool ctSXngQzvYTBGDrAJMYhwliViwKF = true;

	private const bool monqlmnmWrUZTcLQZZxMwIEVDxVC = true;

	private const bool ZrRqIBnFtUFbebCpBQozzauDBumu = true;

	private const bool tkRkVLUxiePYDzKIvzFnaxEMKruF = true;

	private const float HObfekLuqJFSsmqugJHCzEcCleil = 4096f;

	private const float qesVaFTmJCpWYKVdNXgVpErXghtf = 16384f;

	private const float BCKzBZqbjDxBYPpkoFkNkTAYasOGb = 16777216f;

	private const float JMBzFPQyaUvzTOyEzLvjLeigvJCv = 268435460f;

	private const float wVrlMwaKvOywgiFOpFgxtejixQxr = 0.01999998f;

	private const float CvSKTkeybksizaiMNGksKfoPaZRWA = 8192f;

	private const float cpVKFVvDgIYywHomzYNmsjrjKDWA = 0.98f;

	private const float iMibHtecXVnSTAZJqUQnNqxKvdQkA = 45f;

	private const float xKbjToRQzgKPGeGynVwmlrjjlgsR = 20f;

	private readonly IHIDDevice WKVzqnHQRLwRNdRdePCrfyqkDliw;

	private readonly HIDProperties auYqIHdZoZwqWMQlHVNKJnffpBMX;

	private readonly bool DMbveNeDnMrvBJIOvqPcXWvUCqGC;

	private readonly mcGCOmKmWTEVYWVKfxUduOlekNVWA hnGCdRsrqtpbeBIIaciuajjaxSukA;

	private readonly int WnkoNfacLGpQdMvqxFCXcksVgCUU;

	private readonly int nRvfZcrVWLComWvcwIljdmeOjnAF;

	private readonly bool ysmksdqQTyqUOwInxNKAhJCUjMqZ;

	private readonly byte CdMFeMQgnDhLsNioEXfZnLKeeKFg;

	private readonly int UeBSZOCHZCqfgXMpGXRAMQKHsCHK;

	private readonly int WjLgMOoqeAiSFnJIKBvbymQpaHqz;

	private readonly int ABLieBkVosbNEQGxVYZidLqPglmT;

	private readonly int IsXVgBdtoPlsutElDhtLguSgFqpGb;

	private readonly NativeBuffer XzxLDAOuZRnfPPFkYbtahGMwWvwR;

	private readonly NativeBuffer zbCcgtALNasOxWBWukuxtVZXnYspA;

	private readonly YgqnhctsoyAiZixKeAsniiZNPqQeA nMjvPrwZyTabeKjUSdrrCHzaMKySA;

	private readonly byte[] EyifQUklGtjHzKsMffHOpNXFRYOdA = new byte[1] { 162 };

	private bool aWAmdbkFHoxkeDrDNlcztxTEJoCt;

	private bool sBjoNSFlPZCKcJvWniUhJZqHxkbRA;

	private double SGypoWnGCksqaIqgawZDLsMvWUNf;

	private int VgDarJdaPpzmDyrBqITpDRukEQXdb;

	private hCkCmewugAAZjOegSAFDJPUvxjnJA rPeHSZPCjhxDShSuROCDwAnatGIK = hCkCmewugAAZjOegSAFDJPUvxjnJA.Unknown;

	private Quaternion nHSlXAqmJueLxgGAOxsFyJsudnHcA = Quaternion.identity;

	private ushort CaCkVpuMFwZJGNgXzNQrOvNTPEPG;

	private float RccqYWBLWkqiWUYzrsNXWfVfbYCC;

	private double OGZkTkDjgHMEYUAxlOBFQHzWeAeW;

	private float BLjADqzFIRZqiTPiiZJoYWttYMiA;

	private bool yPoFOsarQMdhpTpxHkXSjOSKmcNXA;

	private bool BRzqTiSwAzVMMKChFToFdfEZRSQ;

	private bool NUpDYHHMANUYBdNjDQOsCXjCstlPc;

	private bool KqPCzcgXjOdlZQvRMMHnmtVoFvXzA;

	private byte SIgLNdnMYFDfvdhEFfGhnKYcZzpn;

	private byte ysGPsaDPsabNpTfYGBfYlgIUBuFC;

	private Quaternion EfVdJWvZGDnVeYZVCGqnPGyrEgPt = Quaternion.identity;

	private Quaternion IiJDvduCMGBtJjrqbXhyQEJwLTOaA = Quaternion.identity;

	private bool hliIESNpxEwbZEnPmElNwoFAAnHI;

	private int RhTYyZMpvjIWhxhwlmXtTwHBlvqm;

	private int[] mOeGgUJlnGjxSpAmzcnNVsqLVdTf = new int[2];

	private int[] doYjlLQiVhpotxozFCyrhhgAVjTTA = new int[2];

	private bool isVibrating => brjLBodnhTagmVKweeivkKilSDHD();

	float IDriver_DualShock4.BatteryLevel => get_BatteryLevel();

	bool IDriver_DualShock4.BatteryCharging => get_BatteryCharging();

	float IDriver_DualShock4.LeftMotor
	{
		get
		{
			return get_LeftMotor();
		}
		set
		{
			set_LeftMotor(value);
		}
	}

	float IDriver_DualShock4.RightMotor
	{
		get
		{
			return get_RightMotor();
		}
		set
		{
			set_RightMotor(value);
		}
	}

	float IDriver_DualShock4.LightColorR
	{
		get
		{
			return get_LightColorR();
		}
		set
		{
			set_LightColorR(value);
		}
	}

	float IDriver_DualShock4.LightColorG
	{
		get
		{
			return get_LightColorG();
		}
		set
		{
			set_LightColorG(value);
		}
	}

	float IDriver_DualShock4.LightColorB
	{
		get
		{
			return get_LightColorB();
		}
		set
		{
			set_LightColorB(value);
		}
	}

	float IDriver_DualShock4.LightFlashOnDuration
	{
		get
		{
			return get_LightFlashOnDuration();
		}
		set
		{
			set_LightFlashOnDuration(value);
		}
	}

	float IDriver_DualShock4.LightFlashOffDuration
	{
		get
		{
			return get_LightFlashOffDuration();
		}
		set
		{
			set_LightFlashOffDuration(value);
		}
	}

	Vector3 IDriver_DualShock4.AccelerometerValue => get_AccelerometerValue();

	Vector3 IDriver_DualShock4.AccelerometerValueRaw => get_AccelerometerValueRaw();

	Vector3 IDriver_DualShock4.GyroscopeValue => get_GyroscopeValue();

	Vector3 IDriver_DualShock4.GyroscopeValueRaw => get_GyroscopeValueRaw();

	Vector3 IDriver_DualShock4.LastGyroscopeValue => get_LastGyroscopeValue();

	Vector3 IDriver_DualShock4.LastGyroscopeValueRaw => get_LastGyroscopeValueRaw();

	Quaternion IDriver_DualShock4.Orientation => get_Orientation();

	int IDriver_DualShock4.MaxTouches => get_MaxTouches();

	ushort IHIDControllerExtension.vendorId => auYqIHdZoZwqWMQlHVNKJnffpBMX.vendorId;

	ushort IHIDControllerExtension.productId => auYqIHdZoZwqWMQlHVNKJnffpBMX.productId;

	string IHIDControllerExtension.productName => auYqIHdZoZwqWMQlHVNKJnffpBMX.productName;

	string IHIDControllerExtension.manufacturer => auYqIHdZoZwqWMQlHVNKJnffpBMX.manufacturer;

	ushort IHIDControllerExtension.usagePage => auYqIHdZoZwqWMQlHVNKJnffpBMX.usagePage;

	ushort IHIDControllerExtension.usage => auYqIHdZoZwqWMQlHVNKJnffpBMX.usage;

	private bool brjLBodnhTagmVKweeivkKilSDHD()
	{
		for (int i = 0; i < get_VibrationMotorCount(); i++)
		{
			if (vibrationMotors[i].DYWGVvmfVdcRhDBgOuJRwnGnXSli() > 0)
			{
				return true;
			}
		}
		return false;
	}

	public float get_BatteryLevel()
	{
		return VgDarJdaPpzmDyrBqITpDRukEQXdb;
	}

	public bool get_BatteryCharging()
	{
		return rPeHSZPCjhxDShSuROCDwAnatGIK == hCkCmewugAAZjOegSAFDJPUvxjnJA.Charging;
	}

	public float get_LeftMotor()
	{
		return vibrationMotors[0].amCmtGfdAUDdaZFcOaPOItQCQwvxA();
	}

	public void set_LeftMotor(float value)
	{
		vibrationMotors[0].PpwdGZtDTfEXYRzvADURwiBhyEjQ(value);
	}

	public float get_RightMotor()
	{
		return vibrationMotors[1].amCmtGfdAUDdaZFcOaPOItQCQwvxA();
	}

	public void set_RightMotor(float value)
	{
		vibrationMotors[1].PpwdGZtDTfEXYRzvADURwiBhyEjQ(value);
	}

	public float get_LightColorR()
	{
		return lights[0].JkOEkXmSevFHHIbHaIPCbPlWahQC();
	}

	public void set_LightColorR(float value)
	{
		lights[0].dmKUYsNgSXMmITOvEWrXLrXwGmvx(value);
	}

	public float get_LightColorG()
	{
		return lights[0].pGhchgeKEMJzEkOggJOWNhBvhEJC();
	}

	public void set_LightColorG(float value)
	{
		lights[0].qoVyMSSfQbOjxsqKXIAwIARRZkFZ(value);
	}

	public float get_LightColorB()
	{
		return lights[0].AJqNhAYOnzCUEbqYvulmqEcmRPcOA();
	}

	public void set_LightColorB(float value)
	{
		lights[0].CYuIGSeGplGAFcqHpZMjSLBFsgxZA(value);
	}

	public float get_LightFlashOnDuration()
	{
		return (int)SIgLNdnMYFDfvdhEFfGhnKYcZzpn;
	}

	public void set_LightFlashOnDuration(float value)
	{
		SIgLNdnMYFDfvdhEFfGhnKYcZzpn = (byte)MathTools.Clamp(MathTools.Clamp(value, 0f, 2.5f) * 100f, 0f, 255f);
		JDGGxglcxbVxKHRxZlBbrkyHColF();
		if (SIgLNdnMYFDfvdhEFfGhnKYcZzpn == 0 && ysGPsaDPsabNpTfYGBfYlgIUBuFC == 0)
		{
			sBjoNSFlPZCKcJvWniUhJZqHxkbRA = true;
		}
	}

	public float get_LightFlashOffDuration()
	{
		return (int)ysGPsaDPsabNpTfYGBfYlgIUBuFC;
	}

	public void set_LightFlashOffDuration(float value)
	{
		ysGPsaDPsabNpTfYGBfYlgIUBuFC = (byte)MathTools.Clamp(MathTools.Clamp(value, 0f, 2.5f) * 100f, 0f, 255f);
		JDGGxglcxbVxKHRxZlBbrkyHColF();
		if (SIgLNdnMYFDfvdhEFfGhnKYcZzpn == 0 && ysGPsaDPsabNpTfYGBfYlgIUBuFC == 0)
		{
			sBjoNSFlPZCKcJvWniUhJZqHxkbRA = true;
		}
	}

	public Vector3 get_AccelerometerValue()
	{
		return yFLDEVkzIUdDgEqwemjCwguLZuaXB(accelerometers[0].kHKNsnXlXktGYBPiLEFMIeDjXJlhA);
	}

	public Vector3 get_AccelerometerValueRaw()
	{
		return new Vector3(accelerometers[0].kHKNsnXlXktGYBPiLEFMIeDjXJlhA[0], accelerometers[0].kHKNsnXlXktGYBPiLEFMIeDjXJlhA[1], accelerometers[0].kHKNsnXlXktGYBPiLEFMIeDjXJlhA[2]);
	}

	public Vector3 get_GyroscopeValue()
	{
		return eMtYDGQEYhPMjpbxKWDEvUFvDQoj(gyroscopes[0].IZXXwacTbRSqzBmoETmswjBBLJKB());
	}

	public Vector3 get_GyroscopeValueRaw()
	{
		return new Vector3(gyroscopes[0].YAYnMednfYBUXhNTdquxcBMJaPTBB()[0], gyroscopes[0].YAYnMednfYBUXhNTdquxcBMJaPTBB()[1], gyroscopes[0].YAYnMednfYBUXhNTdquxcBMJaPTBB()[2]);
	}

	public Vector3 get_LastGyroscopeValue()
	{
		Vector3 vector = new Vector3(gyroscopes[0].lXibhhIpZcFeBrHtdwGikQrKfnMdb[0], gyroscopes[0].lXibhhIpZcFeBrHtdwGikQrKfnMdb[1], gyroscopes[0].lXibhhIpZcFeBrHtdwGikQrKfnMdb[2]);
		return VabwCVwYyCLJOrcDcRoYujncPQbj(vector, RccqYWBLWkqiWUYzrsNXWfVfbYCC);
	}

	public Vector3 get_LastGyroscopeValueRaw()
	{
		return new Vector3(gyroscopes[0].lXibhhIpZcFeBrHtdwGikQrKfnMdb[0], gyroscopes[0].lXibhhIpZcFeBrHtdwGikQrKfnMdb[1], gyroscopes[0].lXibhhIpZcFeBrHtdwGikQrKfnMdb[2]);
	}

	public Quaternion get_Orientation()
	{
		return nHSlXAqmJueLxgGAOxsFyJsudnHcA;
	}

	public void ResetOrientation()
	{
		nHSlXAqmJueLxgGAOxsFyJsudnHcA = Quaternion.identity;
		hliIESNpxEwbZEnPmElNwoFAAnHI = false;
	}

	void IDriver_DualShock4.ResetOrientation()
	{
		//ILSpy generated this explicit interface implementation from .override directive in ResetOrientation
		this.ResetOrientation();
	}

	public int get_MaxTouches()
	{
		return 2;
	}

	public int GetTouchCount()
	{
		int num = 0;
		for (int i = 0; i < 2; i++)
		{
			if (touchpads[0].eRxGPKHfVUSoUvYtfLqInWzRcIsH[i].isTouching)
			{
				num++;
			}
		}
		return num;
	}

	int IDriver_DualShock4.GetTouchCount()
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetTouchCount
		return this.GetTouchCount();
	}

	public bool IsTouchingAtIndex(int index)
	{
		if (index < 0 || index >= 2)
		{
			return false;
		}
		return touchpads[0].eRxGPKHfVUSoUvYtfLqInWzRcIsH[index].isTouching;
	}

	bool IDriver_DualShock4.IsTouchingAtIndex(int index)
	{
		//ILSpy generated this explicit interface implementation from .override directive in IsTouchingAtIndex
		return this.IsTouchingAtIndex(index);
	}

	public bool IsTouchingAtTouchId(int touchId)
	{
		return touchpads[0].nbrtEjncCqmLPUIIxfqKkvPpFsqbb(touchId);
	}

	bool IDriver_DualShock4.IsTouchingAtTouchId(int touchId)
	{
		//ILSpy generated this explicit interface implementation from .override directive in IsTouchingAtTouchId
		return this.IsTouchingAtTouchId(touchId);
	}

	public int GetTouchIdAtIndex(int index)
	{
		if (index < 0 || index >= 2)
		{
			return -1;
		}
		return touchpads[0].eRxGPKHfVUSoUvYtfLqInWzRcIsH[index].touchId;
	}

	int IDriver_DualShock4.GetTouchIdAtIndex(int index)
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetTouchIdAtIndex
		return this.GetTouchIdAtIndex(index);
	}

	public bool GetTouchPositionByIndex(int index, out Vector2 position)
	{
		position = default;
		if (index < 0 || index >= 2)
		{
			return false;
		}
		nLbAcapOagdnNrGGiTONDGTEQuzQ.TouchData[] eRxGPKHfVUSoUvYtfLqInWzRcIsH = touchpads[0].eRxGPKHfVUSoUvYtfLqInWzRcIsH;
		if (!eRxGPKHfVUSoUvYtfLqInWzRcIsH[index].isTouching)
		{
			return false;
		}
		position.x = eRxGPKHfVUSoUvYtfLqInWzRcIsH[index].positionX;
		position.y = eRxGPKHfVUSoUvYtfLqInWzRcIsH[index].positionY;
		return true;
	}

	bool IDriver_DualShock4.GetTouchPositionByIndex(int index, out Vector2 position)
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetTouchPositionByIndex
		return this.GetTouchPositionByIndex(index, out position);
	}

	public bool GetTouchPositionByTouchId(int touchId, out Vector2 position)
	{
		position = default;
		if (!touchpads[0].nbrtEjncCqmLPUIIxfqKkvPpFsqbb(touchId))
		{
			return false;
		}
		nLbAcapOagdnNrGGiTONDGTEQuzQ.TouchData[] eRxGPKHfVUSoUvYtfLqInWzRcIsH = touchpads[0].eRxGPKHfVUSoUvYtfLqInWzRcIsH;
		for (int i = 0; i < eRxGPKHfVUSoUvYtfLqInWzRcIsH.Length; i++)
		{
			if (eRxGPKHfVUSoUvYtfLqInWzRcIsH[i].isTouching)
			{
				position.x = eRxGPKHfVUSoUvYtfLqInWzRcIsH[i].positionX;
				position.y = eRxGPKHfVUSoUvYtfLqInWzRcIsH[i].positionY;
			}
		}
		return true;
	}

	bool IDriver_DualShock4.GetTouchPositionByTouchId(int touchId, out Vector2 position)
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetTouchPositionByTouchId
		return this.GetTouchPositionByTouchId(touchId, out position);
	}

	public bool GetTouchPositionAbsoluteByIndex(int index, out int positionX, out int positionY)
	{
		positionX = 0;
		positionY = 0;
		if (index < 0 || index >= 2)
		{
			return false;
		}
		nLbAcapOagdnNrGGiTONDGTEQuzQ.TouchData[] eRxGPKHfVUSoUvYtfLqInWzRcIsH = touchpads[0].eRxGPKHfVUSoUvYtfLqInWzRcIsH;
		if (!eRxGPKHfVUSoUvYtfLqInWzRcIsH[index].isTouching)
		{
			return false;
		}
		positionX = eRxGPKHfVUSoUvYtfLqInWzRcIsH[index].positionAbsX;
		positionY = eRxGPKHfVUSoUvYtfLqInWzRcIsH[index].positionAbsY;
		return true;
	}

	bool IDriver_DualShock4.GetTouchPositionAbsoluteByIndex(int index, out int positionX, out int positionY)
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetTouchPositionAbsoluteByIndex
		return this.GetTouchPositionAbsoluteByIndex(index, out positionX, out positionY);
	}

	public bool GetTouchPositionAbsoluteByTouchId(int touchId, out int positionX, out int positionY)
	{
		positionX = 0;
		positionY = 0;
		if (!touchpads[0].nbrtEjncCqmLPUIIxfqKkvPpFsqbb(touchId))
		{
			return false;
		}
		nLbAcapOagdnNrGGiTONDGTEQuzQ.TouchData[] eRxGPKHfVUSoUvYtfLqInWzRcIsH = touchpads[0].eRxGPKHfVUSoUvYtfLqInWzRcIsH;
		for (int i = 0; i < eRxGPKHfVUSoUvYtfLqInWzRcIsH.Length; i++)
		{
			if (eRxGPKHfVUSoUvYtfLqInWzRcIsH[i].isTouching)
			{
				positionX = eRxGPKHfVUSoUvYtfLqInWzRcIsH[i].positionAbsX;
				positionY = eRxGPKHfVUSoUvYtfLqInWzRcIsH[i].positionAbsY;
			}
		}
		return true;
	}

	bool IDriver_DualShock4.GetTouchPositionAbsoluteByTouchId(int touchId, out int positionX, out int positionY)
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetTouchPositionAbsoluteByTouchId
		return this.GetTouchPositionAbsoluteByTouchId(touchId, out positionX, out positionY);
	}

	public void StopLightFlash()
	{
		SIgLNdnMYFDfvdhEFfGhnKYcZzpn = 0;
		ysGPsaDPsabNpTfYGBfYlgIUBuFC = 0;
		aWAmdbkFHoxkeDrDNlcztxTEJoCt = true;
		sBjoNSFlPZCKcJvWniUhJZqHxkbRA = true;
		NUpDYHHMANUYBdNjDQOsCXjCstlPc = true;
	}

	void IDriver_DualShock4.StopLightFlash()
	{
		//ILSpy generated this explicit interface implementation from .override directive in StopLightFlash
		this.StopLightFlash();
	}

	public void StopVibration()
	{
		int vibrationMotorCount = get_VibrationMotorCount();
		for (int i = 0; i < vibrationMotorCount; i++)
		{
			vibrationMotors[i].ZzeucWTvdVBzsUkrmxpdrFxcbvgG(0);
		}
	}

	void IDriver_DualShock4.StopVibration()
	{
		//ILSpy generated this explicit interface implementation from .override directive in StopVibration
		this.StopVibration();
	}

	public DualShock4Driver(InitArgs P_0)
	{
		if (P_0 == null)
		{
			throw new ArgumentNullException("initArgs");
		}
		WKVzqnHQRLwRNdRdePCrfyqkDliw = P_0.hidDevice;
		auYqIHdZoZwqWMQlHVNKJnffpBMX = WKVzqnHQRLwRNdRdePCrfyqkDliw.properties;
		WnkoNfacLGpQdMvqxFCXcksVgCUU = P_0.hatZeroValue;
		nRvfZcrVWLComWvcwIljdmeOjnAF = P_0.hatSpan;
		hnGCdRsrqtpbeBIIaciuajjaxSukA = P_0.connectionType;
		DMbveNeDnMrvBJIOvqPcXWvUCqGC = hnGCdRsrqtpbeBIIaciuajjaxSukA == mcGCOmKmWTEVYWVKfxUduOlekNVWA.Bluetooth;
		if (DMbveNeDnMrvBJIOvqPcXWvUCqGC)
		{
			auYqIHdZoZwqWMQlHVNKJnffpBMX.maxOutputReportLength = 78;
		}
		if (auYqIHdZoZwqWMQlHVNKJnffpBMX.maxOutputReportLength < 23)
		{
			auYqIHdZoZwqWMQlHVNKJnffpBMX.maxOutputReportLength = 23;
		}
		XzxLDAOuZRnfPPFkYbtahGMwWvwR = new NativeBuffer(64);
		zbCcgtALNasOxWBWukuxtVZXnYspA = new NativeBuffer(auYqIHdZoZwqWMQlHVNKJnffpBMX.maxOutputReportLength);
		nMjvPrwZyTabeKjUSdrrCHzaMKySA = new YgqnhctsoyAiZixKeAsniiZNPqQeA(zbCcgtALNasOxWBWukuxtVZXnYspA.Pointer, zbCcgtALNasOxWBWukuxtVZXnYspA.Length, auYqIHdZoZwqWMQlHVNKJnffpBMX.maxOutputReportLength);
		lights = new HzYEQAmIRNSiWjhheMaNLEiYjqKH[1]
		{
			new HzYEQAmIRNSiWjhheMaNLEiYjqKH(11, 24, 28)
		};
		lights[0].JsqZEamZPJVwNPTRfoRVPDhHmSeJ(DZkzfJYOwtDvPhTaVZidSghMxLuSA);
		BRzqTiSwAzVMMKChFToFdfEZRSQ = true;
		vibrationMotors = new UJKgOyiCpkBVwnefNmaagmCQWRFGb[2]
		{
			new UJKgOyiCpkBVwnefNmaagmCQWRFGb(0, 255),
			new UJKgOyiCpkBVwnefNmaagmCQWRFGb(0, 255)
		};
		vibrationMotors[0].kaRSfqFlYVGBiBQLpDLehwzBbhMl(UHvbPyEPpOIqoQOwvFWlgqdenawXb);
		vibrationMotors[1].kaRSfqFlYVGBiBQLpDLehwzBbhMl(UHvbPyEPpOIqoQOwvFWlgqdenawXb);
		if (WKVzqnHQRLwRNdRdePCrfyqkDliw.GetHidFeatureData(2, 37, 1000, 3) == null)
		{
			throw new Exception();
		}
		KqPCzcgXjOdlZQvRMMHnmtVoFvXzA = true;
		if (DMbveNeDnMrvBJIOvqPcXWvUCqGC)
		{
			ysmksdqQTyqUOwInxNKAhJCUjMqZ = true;
			nMjvPrwZyTabeKjUSdrrCHzaMKySA.ZkToHalecmNLxzFDOCFImmKVivSU |= KPLqKGrnXdaslTRsOdlOdboDEXAU.WriteDirect;
			ysmksdqQTyqUOwInxNKAhJCUjMqZ = wNFBkCzdLnCfoJTXogwuhPCvBrCD(lZZYSzlENjVckJKEzwKsVotVgXhb.Synchronous);
			if (!ysmksdqQTyqUOwInxNKAhJCUjMqZ)
			{
				nMjvPrwZyTabeKjUSdrrCHzaMKySA.ZkToHalecmNLxzFDOCFImmKVivSU &= ~KPLqKGrnXdaslTRsOdlOdboDEXAU.WriteDirect;
			}
		}
		else
		{
			ysmksdqQTyqUOwInxNKAhJCUjMqZ = wNFBkCzdLnCfoJTXogwuhPCvBrCD(lZZYSzlENjVckJKEzwKsVotVgXhb.Synchronous);
		}
		if (!ysmksdqQTyqUOwInxNKAhJCUjMqZ)
		{
			throw new Exception();
		}
		CdMFeMQgnDhLsNioEXfZnLKeeKFg = 1;
		UeBSZOCHZCqfgXMpGXRAMQKHsCHK = 0;
		if (DMbveNeDnMrvBJIOvqPcXWvUCqGC && ysmksdqQTyqUOwInxNKAhJCUjMqZ)
		{
			CdMFeMQgnDhLsNioEXfZnLKeeKFg = 17;
			UeBSZOCHZCqfgXMpGXRAMQKHsCHK = 2;
		}
		WjLgMOoqeAiSFnJIKBvbymQpaHqz = 5 + UeBSZOCHZCqfgXMpGXRAMQKHsCHK;
		ABLieBkVosbNEQGxVYZidLqPglmT = 6 + UeBSZOCHZCqfgXMpGXRAMQKHsCHK;
		IsXVgBdtoPlsutElDhtLguSgFqpGb = 7 + UeBSZOCHZCqfgXMpGXRAMQKHsCHK;
		buttons = new zcGvJvonyWXVMOLIHiTlBSzzCQP[14];
		for (int i = 0; i < 14; i++)
		{
			buttons[i] = new zcGvJvonyWXVMOLIHiTlBSzzCQP(CdMFeMQgnDhLsNioEXfZnLKeeKFg, new xRwbEhgwfqETGQkYCofyzWNojclTA.HIDInfo
			{
				usagePage = 9,
				usage = (ushort)i
			});
		}
		axes = new CZoMFTjfkBKcdHwbjLAHvGhrFKlm[6]
		{
			new CZoMFTjfkBKcdHwbjLAHvGhrFKlm(CdMFeMQgnDhLsNioEXfZnLKeeKFg, new xRwbEhgwfqETGQkYCofyzWNojclTA.HIDInfo
			{
				usagePage = 1,
				usage = 48,
				dataIndex = 1 + UeBSZOCHZCqfgXMpGXRAMQKHsCHK,
				bitSize = 8,
				logicalMin = 0,
				logicalMax = 255,
				physicalMin = 0,
				physicalMax = 0,
				units = 0u,
				unitsExp = 0u
			}, false, 127),
			new CZoMFTjfkBKcdHwbjLAHvGhrFKlm(CdMFeMQgnDhLsNioEXfZnLKeeKFg, new xRwbEhgwfqETGQkYCofyzWNojclTA.HIDInfo
			{
				usagePage = 1,
				usage = 49,
				dataIndex = 2 + UeBSZOCHZCqfgXMpGXRAMQKHsCHK,
				bitSize = 8,
				logicalMin = 0,
				logicalMax = 255,
				physicalMin = 0,
				physicalMax = 0,
				units = 0u,
				unitsExp = 0u
			}, false, 127),
			new CZoMFTjfkBKcdHwbjLAHvGhrFKlm(CdMFeMQgnDhLsNioEXfZnLKeeKFg, new xRwbEhgwfqETGQkYCofyzWNojclTA.HIDInfo
			{
				usagePage = 1,
				usage = 50,
				dataIndex = 3 + UeBSZOCHZCqfgXMpGXRAMQKHsCHK,
				bitSize = 8,
				logicalMin = 0,
				logicalMax = 255,
				physicalMin = 0,
				physicalMax = 0,
				units = 0u,
				unitsExp = 0u
			}, false, 127),
			new CZoMFTjfkBKcdHwbjLAHvGhrFKlm(CdMFeMQgnDhLsNioEXfZnLKeeKFg, new xRwbEhgwfqETGQkYCofyzWNojclTA.HIDInfo
			{
				usagePage = 1,
				usage = 53,
				dataIndex = 4 + UeBSZOCHZCqfgXMpGXRAMQKHsCHK,
				bitSize = 8,
				logicalMin = 0,
				logicalMax = 255,
				physicalMin = 0,
				physicalMax = 0,
				units = 0u,
				unitsExp = 0u
			}, false, 127),
			new CZoMFTjfkBKcdHwbjLAHvGhrFKlm(CdMFeMQgnDhLsNioEXfZnLKeeKFg, new xRwbEhgwfqETGQkYCofyzWNojclTA.HIDInfo
			{
				usagePage = 1,
				usage = 51,
				dataIndex = 8 + UeBSZOCHZCqfgXMpGXRAMQKHsCHK,
				bitSize = 8,
				logicalMin = 0,
				logicalMax = 255,
				physicalMin = 0,
				physicalMax = 315,
				units = 0u,
				unitsExp = 0u
			}, false, 0),
			new CZoMFTjfkBKcdHwbjLAHvGhrFKlm(CdMFeMQgnDhLsNioEXfZnLKeeKFg, new xRwbEhgwfqETGQkYCofyzWNojclTA.HIDInfo
			{
				usagePage = 1,
				usage = 52,
				dataIndex = 9 + UeBSZOCHZCqfgXMpGXRAMQKHsCHK,
				bitSize = 8,
				logicalMin = 0,
				logicalMax = 255,
				physicalMin = 0,
				physicalMax = 315,
				units = 0u,
				unitsExp = 0u
			}, false, 0)
		};
		hats = new yVtJYaXVmlAkOpMlEdRssBJtGidG[1]
		{
			new yVtJYaXVmlAkOpMlEdRssBJtGidG(CdMFeMQgnDhLsNioEXfZnLKeeKFg, new xRwbEhgwfqETGQkYCofyzWNojclTA.HIDInfo
			{
				usagePage = 1,
				usage = 57,
				dataIndex = 5 + UeBSZOCHZCqfgXMpGXRAMQKHsCHK,
				bitSize = 4,
				logicalMin = 0,
				logicalMax = 7,
				physicalMin = 0,
				physicalMax = 315,
				units = 20u,
				unitsExp = 0u
			}, jAlIylFFWEKNKrhAsRdhIngtjvdRA)
		};
		accelerometers = new PuNiRanhRtGcawmdkdYFXXryaDNI[1]
		{
			new PuNiRanhRtGcawmdkdYFXXryaDNI(CdMFeMQgnDhLsNioEXfZnLKeeKFg, new xRwbEhgwfqETGQkYCofyzWNojclTA.HIDInfo
			{
				usagePage = 1,
				dataIndex = 19 + UeBSZOCHZCqfgXMpGXRAMQKHsCHK,
				bitSize = 48
			}, 3, cLVmwjKstSgwFScdhpQnkWjElUQn)
		};
		gyroscopes = new HzWNjGbJTcqWRFLBLnqFlnsJEvnz[1]
		{
			new HzWNjGbJTcqWRFLBLnqFlnsJEvnz(P_0.updateLoopSetting, CdMFeMQgnDhLsNioEXfZnLKeeKFg, new xRwbEhgwfqETGQkYCofyzWNojclTA.HIDInfo
			{
				usagePage = 1,
				dataIndex = 13 + UeBSZOCHZCqfgXMpGXRAMQKHsCHK,
				bitSize = 48
			}, 3, 60, hnbasXEjrsJSCNgCjSboYaUGWpWg, GRsPJcyocfqVzxugbHdeptgchfMX)
		};
		touchpads = new nLbAcapOagdnNrGGiTONDGTEQuzQ[1]
		{
			new nLbAcapOagdnNrGGiTONDGTEQuzQ(CdMFeMQgnDhLsNioEXfZnLKeeKFg, new nLbAcapOagdnNrGGiTONDGTEQuzQ.TouchpadInfo(2, 0, 1912, 0, 941, false, true), new xRwbEhgwfqETGQkYCofyzWNojclTA.HIDInfo
			{
				usagePage = 1,
				dataIndex = 35 + UeBSZOCHZCqfgXMpGXRAMQKHsCHK,
				bitSize = 48
			}, 60, mOPepbxTbshWejzwYcoqQCMcihXH)
		};
		OGZkTkDjgHMEYUAxlOBFQHzWeAeW = ReInput.realTime;
	}

	public override void Update(UpdateLoopType updateLoop)
	{
		BvbOyCRwhurLdYchVulnKwUNNYpt();
		pKlllFyEANoQEFuyfTMgLqlUXFgR(lZZYSzlENjVckJKEzwKsVotVgXhb.Asynchronous);
	}

	public override bool ParseInputReport(IntPtr inputReportPtr, int inputReportLength, double timestamp)
	{
		if (inputReportPtr == IntPtr.Zero)
		{
			return false;
		}
		if (inputReportLength < XzxLDAOuZRnfPPFkYbtahGMwWvwR.Length)
		{
			return false;
		}
		BLjADqzFIRZqiTPiiZJoYWttYMiA = (float)(timestamp - OGZkTkDjgHMEYUAxlOBFQHzWeAeW);
		OGZkTkDjgHMEYUAxlOBFQHzWeAeW = timestamp;
		XzxLDAOuZRnfPPFkYbtahGMwWvwR.Write(inputReportPtr, inputReportLength, XzxLDAOuZRnfPPFkYbtahGMwWvwR.Length);
		kXpVzfurVCYRHhjXOgVweXkGKjJB(XzxLDAOuZRnfPPFkYbtahGMwWvwR);
		chLhQZLZZxnVcslQYIvthZyXmpxA(XzxLDAOuZRnfPPFkYbtahGMwWvwR, timestamp);
		xRwbEhgwfqETGQkYCofyzWNojclTA[] array = axes;
		SJhIIGGtkroRRCgCPpBpuAbtziZF(array, XzxLDAOuZRnfPPFkYbtahGMwWvwR, timestamp);
		array = hats;
		SJhIIGGtkroRRCgCPpBpuAbtziZF(array, XzxLDAOuZRnfPPFkYbtahGMwWvwR, timestamp);
		array = accelerometers;
		SJhIIGGtkroRRCgCPpBpuAbtziZF(array, XzxLDAOuZRnfPPFkYbtahGMwWvwR, timestamp);
		array = gyroscopes;
		SJhIIGGtkroRRCgCPpBpuAbtziZF(array, XzxLDAOuZRnfPPFkYbtahGMwWvwR, timestamp);
		array = touchpads;
		SJhIIGGtkroRRCgCPpBpuAbtziZF(array, XzxLDAOuZRnfPPFkYbtahGMwWvwR, timestamp);
		byte num = XzxLDAOuZRnfPPFkYbtahGMwWvwR[30 + UeBSZOCHZCqfgXMpGXRAMQKHsCHK];
		byte b = (byte)(num & 0xF);
		if ((num & 0x10) != 0)
		{
			if (b <= 10)
			{
				VgDarJdaPpzmDyrBqITpDRukEQXdb = MathTools.Clamp(b * 10 + 5, 0, 100);
				rPeHSZPCjhxDShSuROCDwAnatGIK = hCkCmewugAAZjOegSAFDJPUvxjnJA.Charging;
			}
			else
			{
				switch (b)
				{
				case 11:
					VgDarJdaPpzmDyrBqITpDRukEQXdb = 100;
					rPeHSZPCjhxDShSuROCDwAnatGIK = hCkCmewugAAZjOegSAFDJPUvxjnJA.Full;
					break;
				case 14:
					VgDarJdaPpzmDyrBqITpDRukEQXdb = 0;
					rPeHSZPCjhxDShSuROCDwAnatGIK = hCkCmewugAAZjOegSAFDJPUvxjnJA.Charging;
					break;
				default:
					VgDarJdaPpzmDyrBqITpDRukEQXdb = 0;
					rPeHSZPCjhxDShSuROCDwAnatGIK = hCkCmewugAAZjOegSAFDJPUvxjnJA.Unknown;
					break;
				}
			}
		}
		else
		{
			switch (MathTools.Clamp((int)b, 0, 8))
			{
			case 0:
				VgDarJdaPpzmDyrBqITpDRukEQXdb = 5;
				break;
			case 1:
				VgDarJdaPpzmDyrBqITpDRukEQXdb = 20;
				break;
			case 2:
				VgDarJdaPpzmDyrBqITpDRukEQXdb = 30;
				break;
			case 3:
				VgDarJdaPpzmDyrBqITpDRukEQXdb = 45;
				break;
			case 4:
				VgDarJdaPpzmDyrBqITpDRukEQXdb = 55;
				break;
			case 5:
				VgDarJdaPpzmDyrBqITpDRukEQXdb = 70;
				break;
			case 6:
				VgDarJdaPpzmDyrBqITpDRukEQXdb = 80;
				break;
			case 7:
				VgDarJdaPpzmDyrBqITpDRukEQXdb = 95;
				break;
			case 8:
				VgDarJdaPpzmDyrBqITpDRukEQXdb = 100;
				break;
			}
			rPeHSZPCjhxDShSuROCDwAnatGIK = hCkCmewugAAZjOegSAFDJPUvxjnJA.Discharging;
		}
		GJkwMNxRSbfreWMDuwKSIrSEQDMN();
		return true;
	}

	public override Controller.Extension CreateControllerExtension()
	{
		return new DualShock4Extension(this);
	}

	private void pKlllFyEANoQEFuyfTMgLqlUXFgR(lZZYSzlENjVckJKEzwKsVotVgXhb P_0)
	{
		if (aWAmdbkFHoxkeDrDNlcztxTEJoCt)
		{
			wNFBkCzdLnCfoJTXogwuhPCvBrCD(P_0);
			aWAmdbkFHoxkeDrDNlcztxTEJoCt = false;
		}
	}

	private bool wNFBkCzdLnCfoJTXogwuhPCvBrCD(lZZYSzlENjVckJKEzwKsVotVgXhb P_0)
	{
		BrEAscJyIlUUOJGEsYGUjzVCYbaR();
		bool result = ixYCPGlFvDbVUfmyVbXcdBHGjBpbb(P_0);
		if (sBjoNSFlPZCKcJvWniUhJZqHxkbRA)
		{
			result = ixYCPGlFvDbVUfmyVbXcdBHGjBpbb(P_0);
			sBjoNSFlPZCKcJvWniUhJZqHxkbRA = false;
		}
		return result;
	}

	private unsafe void BrEAscJyIlUUOJGEsYGUjzVCYbaR()
	{
		byte b = 0;
		b |= 1;
		yPoFOsarQMdhpTpxHkXSjOSKmcNXA = false;
		b |= 2;
		BRzqTiSwAzVMMKChFToFdfEZRSQ = false;
		b |= 4;
		NUpDYHHMANUYBdNjDQOsCXjCstlPc = false;
		byte b2 = 128;
		if (DMbveNeDnMrvBJIOvqPcXWvUCqGC)
		{
			b2 |= 0x40;
		}
		if (KqPCzcgXjOdlZQvRMMHnmtVoFvXzA)
		{
			b2 |= 4;
			KqPCzcgXjOdlZQvRMMHnmtVoFvXzA = false;
		}
		if (DMbveNeDnMrvBJIOvqPcXWvUCqGC && ysmksdqQTyqUOwInxNKAhJCUjMqZ)
		{
			zbCcgtALNasOxWBWukuxtVZXnYspA[0] = 17;
			zbCcgtALNasOxWBWukuxtVZXnYspA[1] = b2;
			zbCcgtALNasOxWBWukuxtVZXnYspA[2] = 0;
			zbCcgtALNasOxWBWukuxtVZXnYspA[3] = b;
			zbCcgtALNasOxWBWukuxtVZXnYspA[4] = 0;
			zbCcgtALNasOxWBWukuxtVZXnYspA[5] = 0;
			zbCcgtALNasOxWBWukuxtVZXnYspA[6] = (byte)vibrationMotors[1].DYWGVvmfVdcRhDBgOuJRwnGnXSli();
			zbCcgtALNasOxWBWukuxtVZXnYspA[7] = (byte)vibrationMotors[0].DYWGVvmfVdcRhDBgOuJRwnGnXSli();
			zbCcgtALNasOxWBWukuxtVZXnYspA[8] = lights[0].fMmsggZOsscOuVMYSBsIqYOBQdqI();
			zbCcgtALNasOxWBWukuxtVZXnYspA[9] = lights[0].JhRteqBJskBczNyyhRGQdGLByHed();
			zbCcgtALNasOxWBWukuxtVZXnYspA[10] = lights[0].AMTRtdCBoICpIfejWgQiwgwDnqyHA();
			zbCcgtALNasOxWBWukuxtVZXnYspA[11] = SIgLNdnMYFDfvdhEFfGhnKYcZzpn;
			zbCcgtALNasOxWBWukuxtVZXnYspA[12] = ysGPsaDPsabNpTfYGBfYlgIUBuFC;
			int mkLceCnSfMCmtvrhnltBZXSmJecI = nMjvPrwZyTabeKjUSdrrCHzaMKySA.mkLceCnSfMCmtvrhnltBZXSmJecI;
			uint bytes = RrVuaSuBSVqUhLQaZSsbpKVjsLrD.NNGYjuYWamgqPFdqfzpTTZKakKMg((byte*)(void*)zbCcgtALNasOxWBWukuxtVZXnYspA.Pointer, mkLceCnSfMCmtvrhnltBZXSmJecI - 4, 162u);
			zbCcgtALNasOxWBWukuxtVZXnYspA.Write(bytes, mkLceCnSfMCmtvrhnltBZXSmJecI - 4);
		}
		else
		{
			zbCcgtALNasOxWBWukuxtVZXnYspA[0] = 5;
			zbCcgtALNasOxWBWukuxtVZXnYspA[1] = b;
			zbCcgtALNasOxWBWukuxtVZXnYspA[2] = 0;
			zbCcgtALNasOxWBWukuxtVZXnYspA[4] = (byte)vibrationMotors[1].DYWGVvmfVdcRhDBgOuJRwnGnXSli();
			zbCcgtALNasOxWBWukuxtVZXnYspA[5] = (byte)vibrationMotors[0].DYWGVvmfVdcRhDBgOuJRwnGnXSli();
			zbCcgtALNasOxWBWukuxtVZXnYspA[6] = lights[0].fMmsggZOsscOuVMYSBsIqYOBQdqI();
			zbCcgtALNasOxWBWukuxtVZXnYspA[7] = lights[0].JhRteqBJskBczNyyhRGQdGLByHed();
			zbCcgtALNasOxWBWukuxtVZXnYspA[8] = lights[0].AMTRtdCBoICpIfejWgQiwgwDnqyHA();
			zbCcgtALNasOxWBWukuxtVZXnYspA[9] = SIgLNdnMYFDfvdhEFfGhnKYcZzpn;
			zbCcgtALNasOxWBWukuxtVZXnYspA[10] = ysGPsaDPsabNpTfYGBfYlgIUBuFC;
		}
	}

	private bool ixYCPGlFvDbVUfmyVbXcdBHGjBpbb(lZZYSzlENjVckJKEzwKsVotVgXhb P_0)
	{
		SGypoWnGCksqaIqgawZDLsMvWUNf = ReInput.realTime + 4.0;
		switch (P_0)
		{
		case lZZYSzlENjVckJKEzwKsVotVgXhb.Synchronous:
			return WKVzqnHQRLwRNdRdePCrfyqkDliw.WriteSync(nMjvPrwZyTabeKjUSdrrCHzaMKySA, 0);
		case lZZYSzlENjVckJKEzwKsVotVgXhb.Asynchronous:
			WKVzqnHQRLwRNdRdePCrfyqkDliw.WriteAsync(nMjvPrwZyTabeKjUSdrrCHzaMKySA, 1000);
			return true;
		default:
			throw new NotImplementedException();
		}
	}

	private void chLhQZLZZxnVcslQYIvthZyXmpxA(NativeBuffer P_0, double P_1)
	{
		byte b = P_0[WjLgMOoqeAiSFnJIKBvbymQpaHqz];
		buttons[0].bmTWObZDLAHwBwVIFbvrHBOVINETA((b & 0x10) != 0, P_1);
		buttons[1].bmTWObZDLAHwBwVIFbvrHBOVINETA((b & 0x20) != 0, P_1);
		buttons[2].bmTWObZDLAHwBwVIFbvrHBOVINETA((b & 0x40) != 0, P_1);
		buttons[3].bmTWObZDLAHwBwVIFbvrHBOVINETA((b & 0x80) != 0, P_1);
		b = P_0[ABLieBkVosbNEQGxVYZidLqPglmT];
		buttons[4].bmTWObZDLAHwBwVIFbvrHBOVINETA((b & 1) != 0, P_1);
		buttons[5].bmTWObZDLAHwBwVIFbvrHBOVINETA((b & 2) != 0, P_1);
		buttons[6].bmTWObZDLAHwBwVIFbvrHBOVINETA((b & 4) != 0, P_1);
		buttons[7].bmTWObZDLAHwBwVIFbvrHBOVINETA((b & 8) != 0, P_1);
		buttons[8].bmTWObZDLAHwBwVIFbvrHBOVINETA((b & 0x10) != 0, P_1);
		buttons[9].bmTWObZDLAHwBwVIFbvrHBOVINETA((b & 0x20) != 0, P_1);
		buttons[10].bmTWObZDLAHwBwVIFbvrHBOVINETA((b & 0x40) != 0, P_1);
		buttons[11].bmTWObZDLAHwBwVIFbvrHBOVINETA((b & 0x80) != 0, P_1);
		b = P_0[IsXVgBdtoPlsutElDhtLguSgFqpGb];
		buttons[12].bmTWObZDLAHwBwVIFbvrHBOVINETA((b & 1) != 0, P_1);
		buttons[13].bmTWObZDLAHwBwVIFbvrHBOVINETA((b & 2) != 0, P_1);
	}

	private void SJhIIGGtkroRRCgCPpBpuAbtziZF(xRwbEhgwfqETGQkYCofyzWNojclTA[] P_0, NativeBuffer P_1, double P_2)
	{
		for (int i = 0; i < P_0.Length; i++)
		{
			P_0[i].GbhSjusArEIYoVADpBQtaLlsuRfPA(P_1, P_2);
		}
	}

	private void BvbOyCRwhurLdYchVulnKwUNNYpt()
	{
		if (brjLBodnhTagmVKweeivkKilSDHD() && ReInput.realTime >= SGypoWnGCksqaIqgawZDLsMvWUNf)
		{
			aWAmdbkFHoxkeDrDNlcztxTEJoCt = true;
			yPoFOsarQMdhpTpxHkXSjOSKmcNXA = true;
		}
	}

	private void kXpVzfurVCYRHhjXOgVweXkGKjJB(NativeBuffer P_0)
	{
		if (ysmksdqQTyqUOwInxNKAhJCUjMqZ)
		{
			ushort num = XzxLDAOuZRnfPPFkYbtahGMwWvwR.ReadUShort(10 + UeBSZOCHZCqfgXMpGXRAMQKHsCHK);
			float rccqYWBLWkqiWUYzrsNXWfVfbYCC;
			if (num != CaCkVpuMFwZJGNgXzNQrOvNTPEPG)
			{
				int num2 = ((num >= CaCkVpuMFwZJGNgXzNQrOvNTPEPG) ? (num - CaCkVpuMFwZJGNgXzNQrOvNTPEPG) : (num + 65535 - CaCkVpuMFwZJGNgXzNQrOvNTPEPG));
				rccqYWBLWkqiWUYzrsNXWfVfbYCC = (float)num2 / 187500f;
			}
			else
			{
				int num2 = 0;
				rccqYWBLWkqiWUYzrsNXWfVfbYCC = 0f;
			}
			CaCkVpuMFwZJGNgXzNQrOvNTPEPG = num;
			RccqYWBLWkqiWUYzrsNXWfVfbYCC = rccqYWBLWkqiWUYzrsNXWfVfbYCC;
		}
	}

	private void GJkwMNxRSbfreWMDuwKSIrSEQDMN()
	{
		if (ysmksdqQTyqUOwInxNKAhJCUjMqZ)
		{
			_ = RccqYWBLWkqiWUYzrsNXWfVfbYCC;
			_ = 0f;
			Vector3 vector = VabwCVwYyCLJOrcDcRoYujncPQbj(new Vector3(gyroscopes[0].lXibhhIpZcFeBrHtdwGikQrKfnMdb[0], gyroscopes[0].lXibhhIpZcFeBrHtdwGikQrKfnMdb[1], gyroscopes[0].lXibhhIpZcFeBrHtdwGikQrKfnMdb[2]), RccqYWBLWkqiWUYzrsNXWfVfbYCC);
			DcPqNLQQvEjtFjQKbFtEauimmbFIA(ref vector);
			Vector3 vector2 = new Vector3(accelerometers[0].kHKNsnXlXktGYBPiLEFMIeDjXJlhA[0] * -1f, accelerometers[0].kHKNsnXlXktGYBPiLEFMIeDjXJlhA[1] * -1f, accelerometers[0].kHKNsnXlXktGYBPiLEFMIeDjXJlhA[2] * -1f);
			TvjEvyxEBvWusAvOZraXCrHcBHct(vector2, vector);
		}
	}

	private static bool DcPqNLQQvEjtFjQKbFtEauimmbFIA(ref Vector3 P_0)
	{
		if (P_0.magnitude < 0.004f)
		{
			P_0.x = 0f;
			P_0.y = 0f;
			P_0.z = 0f;
			return false;
		}
		return true;
	}

	private void TvjEvyxEBvWusAvOZraXCrHcBHct(Vector3 P_0, Vector3 P_1)
	{
		Quaternion quaternion = Quaternion.Euler(P_1);
		float sqrMagnitude = P_0.sqrMagnitude;
		if (sqrMagnitude > 16777216f && sqrMagnitude < 268435460f && quvKrQLIjPGsrPxdptmYXVBFcyUl(P_0, out var vTjkRtHfxLRjQrsvpeinFinGHUoO))
		{
			Quaternion a = nHSlXAqmJueLxgGAOxsFyJsudnHcA * quaternion;
			if (!hliIESNpxEwbZEnPmElNwoFAAnHI)
			{
				hliIESNpxEwbZEnPmElNwoFAAnHI = true;
				EfVdJWvZGDnVeYZVCGqnPGyrEgPt = Quaternion.identity * Quaternion.Euler(new Vector3(90f, 0f, 0f));
				IiJDvduCMGBtJjrqbXhyQEJwLTOaA = nHSlXAqmJueLxgGAOxsFyJsudnHcA;
			}
			EfVdJWvZGDnVeYZVCGqnPGyrEgPt *= quaternion;
			IiJDvduCMGBtJjrqbXhyQEJwLTOaA *= quaternion;
			Quaternion b;
			if ((vTjkRtHfxLRjQrsvpeinFinGHUoO & VTjkRtHfxLRjQrsvpeinFinGHUoO.XZ) != VTjkRtHfxLRjQrsvpeinFinGHUoO.None)
			{
				b = EfCeovhfPupJjWibvZWKJoklTRsf(P_0, a.eulerAngles.y);
			}
			else if ((vTjkRtHfxLRjQrsvpeinFinGHUoO & VTjkRtHfxLRjQrsvpeinFinGHUoO.Y) != VTjkRtHfxLRjQrsvpeinFinGHUoO.None)
			{
				b = EeYpxElTctvDuNGTehCpuAUSRipq(P_0);
				Vector3 vector = IiJDvduCMGBtJjrqbXhyQEJwLTOaA * Vector3.right;
				float y = 0f - MathTools.SignedAngle(new Vector3(vector.x, 0f, vector.z), Vector3.right, Vector3.up);
				b = Quaternion.Euler(0f, y, 0f) * b;
			}
			else
			{
				b = Quaternion.identity;
			}
			nHSlXAqmJueLxgGAOxsFyJsudnHcA = Quaternion.Lerp(a, b, 0.01999998f);
		}
		else
		{
			nHSlXAqmJueLxgGAOxsFyJsudnHcA *= quaternion;
			if (hliIESNpxEwbZEnPmElNwoFAAnHI)
			{
				hliIESNpxEwbZEnPmElNwoFAAnHI = false;
			}
		}
	}

	private static Quaternion XfcRhkGQDJuBLNXRTqaJqeycsLuE(Quaternion P_0, Vector3 P_1)
	{
		Vector3 vector = aydUHSJzmbxhAnDYcavMQtGIrbvp(new Vector3(P_0.x, P_0.y, P_0.z), P_1);
		return new Quaternion(vector.x, vector.y, vector.z, P_0.w);
	}

	private static Vector3 aydUHSJzmbxhAnDYcavMQtGIrbvp(Vector3 P_0, Vector3 P_1)
	{
		float num = Vector3.Dot(P_1, P_1);
		if (num < float.Epsilon)
		{
			return Vector3.zero;
		}
		return P_1 * Vector3.Dot(P_0, P_1) / num;
	}

	private Quaternion teDdWhvFWsTAXtalajZWObIfsVyf(Quaternion P_0, DcGGMXFrNQQwHLHtZApLbWAekehGA P_1)
	{
		Vector4 vector = default;
		if (MathTools.Approximately(P_0.w, 0f) && MathTools.Approximately(P_0[(int)P_1], 0f))
		{
			P_0 = Quaternion.identity;
		}
		else
		{
			float num = P_0[(int)P_1];
			float num2 = MathTools.Sqrt(P_0.w * P_0.w + num * num);
			vector[3] = P_0.w / num2;
			vector[(int)P_1] = num / num2;
			P_0 = new Quaternion(vector[0], vector[1], vector[2], vector[3]);
		}
		return P_0;
	}

	public static Quaternion Inverse(Quaternion quaternion)
	{
		float num = quaternion.x * quaternion.x + quaternion.y * quaternion.y + quaternion.z * quaternion.z + quaternion.w * quaternion.w;
		float num2 = 1f / num;
		Quaternion result = default;
		result.x = (0f - quaternion.x) * num2;
		result.y = (0f - quaternion.y) * num2;
		result.z = (0f - quaternion.z) * num2;
		result.w = quaternion.w * num2;
		return result;
	}

	private float UehdivnLeZWZaWmKUNJqtKGtJlEk(float P_0, float P_1)
	{
		P_0 = MathTools.ClampAngle360(P_0);
		P_1 = MathTools.ClampAngle360(P_1);
		if (P_0 == P_1)
		{
			return 0f;
		}
		if (P_0 >= 180f)
		{
			P_0 -= 360f;
		}
		if (P_1 >= 180f)
		{
			P_1 -= 360f;
		}
		return P_0 - P_1;
	}

	private Vector3 kwLzIbVhXkxJPsMaFIAtjxeQoYZh(Vector3 P_0, float P_1 = 0f)
	{
		float num = MathTools.Atan2(P_0.z, P_0.y);
		float num2 = MathTools.Atan2(x: MathTools.Sqrt(MathTools.Pow(P_0.y, 2f) + MathTools.Pow(P_0.z, 2f)), y: P_0.x);
		float x = num * 57.29578f + 180f;
		float z = (0f - num2) * 57.29578f;
		return new Vector3(x, P_1, z);
	}

	private Quaternion EfCeovhfPupJjWibvZWKJoklTRsf(Vector3 P_0, float P_1 = 0f)
	{
		float num = MathTools.Atan2(P_0.z, P_0.y);
		float num2 = MathTools.Atan2(x: MathTools.Sqrt(MathTools.Pow(P_0.y, 2f) + MathTools.Pow(P_0.z, 2f)), y: P_0.x);
		float x = num * 57.29578f + 180f;
		float z = (0f - num2) * 57.29578f;
		return Quaternion.Euler(x, P_1, z);
	}

	private Quaternion EeYpxElTctvDuNGTehCpuAUSRipq(Vector3 P_0, float P_1 = 0f)
	{
		float num = MathTools.Atan2(P_0.z, P_0.y);
		float x = MathTools.Sqrt(MathTools.Pow(P_0.y, 2f) + MathTools.Pow(P_0.z, 2f));
		float num2 = MathTools.Atan2(P_0.x, x);
		float x2 = num * 57.29578f + 180f;
		float z = (0f - num2) * 57.29578f;
		Quaternion quaternion = Quaternion.Euler(0f, 0f, z) * Quaternion.Euler(x2, 0f, 0f);
		if (P_1 != 0f)
		{
			return quaternion * Quaternion.Euler(0f, P_1, 0f);
		}
		return quaternion;
	}

	private float lEWVgATCGRwWCdWRlecIYogQcqfkA(Vector3 P_0)
	{
		return MathTools.Atan2(P_0.x, P_0.z) * 57.29578f;
	}

	private bool zJkAoAHZJiCkjCcUUNPMeSDvoMQVA(float P_0)
	{
		if (P_0 >= 45f)
		{
			return P_0 <= 70f;
		}
		return false;
	}

	private bool quvKrQLIjPGsrPxdptmYXVBFcyUl(Vector3 P_0, out VTjkRtHfxLRjQrsvpeinFinGHUoO P_1)
	{
		P_0.Normalize();
		P_1 = VTjkRtHfxLRjQrsvpeinFinGHUoO.None;
		bool result = false;
		if (vlbNtpAcValnLMCywFeJeXtKKmb(P_0))
		{
			result = true;
			P_1 |= VTjkRtHfxLRjQrsvpeinFinGHUoO.XZ;
		}
		if (wNEUMQlYYCgIrzzUnQnmFLqdMBNi(P_0))
		{
			result = true;
			P_1 |= VTjkRtHfxLRjQrsvpeinFinGHUoO.Y;
		}
		return result;
	}

	private bool vlbNtpAcValnLMCywFeJeXtKKmb(Vector3 P_0)
	{
		if (P_0.y > 0f)
		{
			return false;
		}
		if (Vector3.Angle(Vector3.down, P_0) > 45f)
		{
			return false;
		}
		return true;
	}

	private bool wNEUMQlYYCgIrzzUnQnmFLqdMBNi(Vector3 P_0)
	{
		if (P_0.z < 0f)
		{
			return false;
		}
		if (Vector3.Angle(new Vector3(0f, 0f, 1f), P_0) > 20f)
		{
			return false;
		}
		return true;
	}

	private Vector3 yFLDEVkzIUdDgEqwemjCwguLZuaXB(float[] P_0)
	{
		return new Vector3(P_0[0] * (1f / 8192f) * -1f, P_0[1] * (1f / 8192f) * -1f, P_0[2] * (1f / 8192f));
	}

	private Vector3 eMtYDGQEYhPMjpbxKWDEvUFvDQoj(RingBuffer<HzWNjGbJTcqWRFLBLnqFlnsJEvnz.TcghcTkzcNarrATcRVAAaJvzzIqhA> P_0)
	{
		Vector3 result = default;
		int count = P_0.Count;
		for (int i = 0; i < count; i++)
		{
			HzWNjGbJTcqWRFLBLnqFlnsJEvnz.TcghcTkzcNarrATcRVAAaJvzzIqhA tcghcTkzcNarrATcRVAAaJvzzIqhA = P_0[i];
			result += VabwCVwYyCLJOrcDcRoYujncPQbj(tcghcTkzcNarrATcRVAAaJvzzIqhA.lPuGxwuWzBbTrDajXKXLGRwQturQ, tcghcTkzcNarrATcRVAAaJvzzIqhA.LmKHhhHGpixLVWWDHRfgAapyJDgI);
		}
		return result;
	}

	private Vector3 VabwCVwYyCLJOrcDcRoYujncPQbj(Vector3 P_0, float P_1)
	{
		P_0.x *= -1f;
		P_0.y *= -1f;
		return P_0 * 0.06103702f * P_1;
	}

	private int jAlIylFFWEKNKrhAsRdhIngtjvdRA(int P_0)
	{
		P_0 &= 0xF;
		return P_0;
	}

	private void cLVmwjKstSgwFScdhpQnkWjElUQn(byte[] P_0, float[] P_1)
	{
		P_1[0] = BitConverter.ToInt16(P_0, 0);
		P_1[1] = BitConverter.ToInt16(P_0, 2);
		P_1[2] = BitConverter.ToInt16(P_0, 4);
	}

	private void hnbasXEjrsJSCNgCjSboYaUGWpWg(byte[] P_0, float[] P_1)
	{
		P_1[0] = BitConverter.ToInt16(P_0, 0);
		P_1[1] = BitConverter.ToInt16(P_0, 2);
		P_1[2] = BitConverter.ToInt16(P_0, 4);
	}

	private float GRsPJcyocfqVzxugbHdeptgchfMX()
	{
		return RccqYWBLWkqiWUYzrsNXWfVfbYCC;
	}

	private void mOPepbxTbshWejzwYcoqQCMcihXH(NativeBuffer P_0, nLbAcapOagdnNrGGiTONDGTEQuzQ.TouchData[] P_1)
	{
		int num = 35 + UeBSZOCHZCqfgXMpGXRAMQKHsCHK;
		int positionRawX = P_0[1 + num] + (P_0[2 + num] & 0xF) * 255;
		int positionRawY = ((P_0[2 + num] & 0xF0) >> 4) + P_0[3 + num] * 16;
		int positionRawX2 = P_0[5 + num] + (P_0[6 + num] & 0xF) * 255;
		int positionRawY2 = ((P_0[6 + num] & 0xF0) >> 4) + P_0[7 + num] * 16;
		byte b = P_0[num];
		bool flag = b < 128;
		byte num2 = P_0[num + 4];
		bool flag2 = num2 < 128;
		int num3 = b & 0x7F;
		int num4 = num2 & 0x7F;
		P_1[0].isTouching = flag;
		P_1[0].touchId = vvnIGYlTsTcrgNXpugjYUgJwLBby(0, flag, num3);
		P_1[0].positionRawX = positionRawX;
		P_1[0].positionRawY = positionRawY;
		P_1[1].isTouching = flag2;
		P_1[1].touchId = vvnIGYlTsTcrgNXpugjYUgJwLBby(1, flag2, num4);
		P_1[1].positionRawX = positionRawX2;
		P_1[1].positionRawY = positionRawY2;
	}

	private int vvnIGYlTsTcrgNXpugjYUgJwLBby(int P_0, bool P_1, int P_2)
	{
		if (!P_1)
		{
			mOeGgUJlnGjxSpAmzcnNVsqLVdTf[P_0] = -1;
			doYjlLQiVhpotxozFCyrhhgAVjTTA[P_0] = P_2;
			return -1;
		}
		if (P_2 != doYjlLQiVhpotxozFCyrhhgAVjTTA[P_0])
		{
			int rhTYyZMpvjIWhxhwlmXtTwHBlvqm = RhTYyZMpvjIWhxhwlmXtTwHBlvqm;
			if (RhTYyZMpvjIWhxhwlmXtTwHBlvqm == int.MaxValue)
			{
				RhTYyZMpvjIWhxhwlmXtTwHBlvqm = 0;
			}
			else
			{
				RhTYyZMpvjIWhxhwlmXtTwHBlvqm++;
			}
			doYjlLQiVhpotxozFCyrhhgAVjTTA[P_0] = P_2;
			mOeGgUJlnGjxSpAmzcnNVsqLVdTf[P_0] = rhTYyZMpvjIWhxhwlmXtTwHBlvqm;
			return rhTYyZMpvjIWhxhwlmXtTwHBlvqm;
		}
		return mOeGgUJlnGjxSpAmzcnNVsqLVdTf[P_0];
	}

	private void DZkzfJYOwtDvPhTaVZidSghMxLuSA()
	{
		BRzqTiSwAzVMMKChFToFdfEZRSQ = true;
		wYDLPzuGIbXNRSvAGeNydyvjgceu();
	}

	private void JDGGxglcxbVxKHRxZlBbrkyHColF()
	{
		NUpDYHHMANUYBdNjDQOsCXjCstlPc = true;
		wYDLPzuGIbXNRSvAGeNydyvjgceu();
	}

	private void UHvbPyEPpOIqoQOwvFWlgqdenawXb()
	{
		yPoFOsarQMdhpTpxHkXSjOSKmcNXA = true;
		wYDLPzuGIbXNRSvAGeNydyvjgceu();
	}

	private void wYDLPzuGIbXNRSvAGeNydyvjgceu()
	{
		aWAmdbkFHoxkeDrDNlcztxTEJoCt = true;
	}

	~DualShock4Driver()
	{
		Dispose(disposing: false);
	}

	protected override void Dispose(bool disposing)
	{
		if (base.disposed)
		{
			return;
		}
		base.Dispose(disposing);
		if (disposing)
		{
			StopVibration();
			pKlllFyEANoQEFuyfTMgLqlUXFgR(lZZYSzlENjVckJKEzwKsVotVgXhb.Synchronous);
			if (XzxLDAOuZRnfPPFkYbtahGMwWvwR != null)
			{
				XzxLDAOuZRnfPPFkYbtahGMwWvwR.Dispose();
			}
			if (zbCcgtALNasOxWBWukuxtVZXnYspA != null)
			{
				zbCcgtALNasOxWBWukuxtVZXnYspA.Dispose();
			}
		}
	}

	public static bool Matches(int vid, int pid)
	{
		for (int i = 0; i < Consts.pidVids_sony_dualShock4.Count; i++)
		{
			if (Consts.pidVids_sony_dualShock4[i].vendorId == vid && Consts.pidVids_sony_dualShock4[i].productId == pid)
			{
				return true;
			}
		}
		return false;
	}

	[Conditional("DEBUG_THIS")]
	private static void MlDNBsyBEJDaKtzZLISHINSItVvt(object P_0)
	{
		Logger.Log(P_0, requiredThreadSafety: true);
	}
}
