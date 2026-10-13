using System;
using Rewired.ControllerExtensions;
using Rewired.Utils.Classes.Data;

namespace Rewired.HID.Drivers;

[CustomObfuscation(rename = false)]
[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
internal class RailDriverDriver : HIDDeviceDriver, IDisposable, IDriver_RailDriver, IControllerDriver, IHIDControllerExtension
{
	private enum VKMlGjEfVWXMsNWbmYZFLsFvEDqF
	{
		Speaker = 0,
		LED = 1
	}

	private const int aMRInsuApwydBguXwiPLcksJzqSj = 1523;

	private const int EbFdXgMoScjkjEEkNBhwriVEYIJR = 210;

	private const int OFivauPjBtjBkDxdXVEsAOEABJLw = 50;

	private const int gsomkeiqKEaTebLywSCbXHrYwMNI = 44;

	private const int zZFiwFLVAAtDVBHjQMOAtNVDdhGKA = 6;

	private const int QXQiyjqdMUjghMYeRckiNklFzpdh = 44;

	private const int iOdativbSEZPKuBtCMaCsPemdCqJA = 45;

	private const int LEekwMDinWwGSwITiUzJKJyfcPLX = 46;

	private const int PbuHRLuUqpSJpVpWvgwNapFskzAr = 47;

	private const int TJsgibEuXjTOTThAefWnFWdbIGoX = 48;

	private const int ViRcTzoNNWhIBoTbfLQtpLeaSXmT = 49;

	private const int KZFwnGSyJAwdSEZjSWRwHwiwZeVL = 0;

	private const int DyleOqTfinFBSVEpBPHjHkyibSAd = 15;

	private const int kDwIFAiAiYgNVfFbsKoRiyPAJtlwB = 9;

	private const int WfxcjVNgrOzoPHsfZVpJFVrUKnFm = 1;

	private const int yEYVpYvIKfKIQFRJSMLygfmGFeFi = 2;

	private const int APHtrjxOHDwLllSpujICQsBXqorX = 3;

	private const int kvYemyktuuukbwMGieTGdTlxgbxf = 4;

	private const int IdFCkhYpOXfwTbdcczKtgDiXIGMx = 5;

	private const int fJkGjjCRKXrjznAtmCWIBxHCCoMqB = 6;

	private const int mXpeokiFSnOPEKRVtMrVCQTKKQqoc = 7;

	private const int qvLkSjFGWjKrNCeOYJfhbXCkDfIv = 8;

	private const int afZItSNtpBewGBoOJbToMVrqvJEpA = 14;

	private const int sxYCfVbWSVyFBRQrKmTUDlCDMHynA = 3;

	private const int isxVyrNMHeBoQJyOprSTzypRYDLe = 7;

	private readonly NativeBuffer QSlvbQwHEydLqBdMfqaDZStcXdPQ;

	private readonly NativeBuffer sPuePzIftIrTqUutBSsdDcAGwcYx;

	private bool QfWJLDoCZCfcqgooiRcOHAgjibnpA;

	private byte[] YeKpCDnuQtvSCbWYpeQyuyjlcTmN = new byte[3];

	private readonly IHIDDevice RTFfnmSZRPdNGokWWEvbOzEiNKrQ;

	private readonly HIDProperties pQTMaafMQEcLQJICDYvKIGotlqdv;

	private readonly YgqnhctsoyAiZixKeAsniiZNPqQeA aXKUTlujzfLmlAFJQDdomGCCZgYN;

	bool IDriver_RailDriver.SpeakerEnabled
	{
		get
		{
			return get_SpeakerEnabled();
		}
		set
		{
			set_SpeakerEnabled(value);
		}
	}

	ushort IHIDControllerExtension.vendorId => pQTMaafMQEcLQJICDYvKIGotlqdv.vendorId;

	ushort IHIDControllerExtension.productId => pQTMaafMQEcLQJICDYvKIGotlqdv.productId;

	string IHIDControllerExtension.productName => pQTMaafMQEcLQJICDYvKIGotlqdv.productName;

	string IHIDControllerExtension.manufacturer => pQTMaafMQEcLQJICDYvKIGotlqdv.manufacturer;

	ushort IHIDControllerExtension.usagePage => pQTMaafMQEcLQJICDYvKIGotlqdv.usagePage;

	ushort IHIDControllerExtension.usage => pQTMaafMQEcLQJICDYvKIGotlqdv.usage;

	public bool get_SpeakerEnabled()
	{
		return QfWJLDoCZCfcqgooiRcOHAgjibnpA;
	}

	public void set_SpeakerEnabled(bool value)
	{
		QfWJLDoCZCfcqgooiRcOHAgjibnpA = value;
		ATMPvgGpbLaBdBjtCVQsnNCUNfnJ(VKMlGjEfVWXMsNWbmYZFLsFvEDqF.Speaker, lZZYSzlENjVckJKEzwKsVotVgXhb.Synchronous);
	}

	public void SetLEDDisplay(int digitIndex, byte digitBitValues)
	{
		if (digitIndex >= 0 && digitIndex < 3)
		{
			YeKpCDnuQtvSCbWYpeQyuyjlcTmN[digitIndex] = digitBitValues;
			ATMPvgGpbLaBdBjtCVQsnNCUNfnJ(VKMlGjEfVWXMsNWbmYZFLsFvEDqF.LED, lZZYSzlENjVckJKEzwKsVotVgXhb.Synchronous);
		}
	}

	void IDriver_RailDriver.SetLEDDisplay(int digitIndex, byte digitBitValues)
	{
		//ILSpy generated this explicit interface implementation from .override directive in SetLEDDisplay
		this.SetLEDDisplay(digitIndex, digitBitValues);
	}

	public void SetLEDDisplay(byte digit1BitValues, byte digit2BitValues, byte digit3BitValues)
	{
		YeKpCDnuQtvSCbWYpeQyuyjlcTmN[0] = digit1BitValues;
		YeKpCDnuQtvSCbWYpeQyuyjlcTmN[1] = digit2BitValues;
		YeKpCDnuQtvSCbWYpeQyuyjlcTmN[2] = digit3BitValues;
		ATMPvgGpbLaBdBjtCVQsnNCUNfnJ(VKMlGjEfVWXMsNWbmYZFLsFvEDqF.LED, lZZYSzlENjVckJKEzwKsVotVgXhb.Synchronous);
	}

	void IDriver_RailDriver.SetLEDDisplay(byte digit1BitValues, byte digit2BitValues, byte digit3BitValues)
	{
		//ILSpy generated this explicit interface implementation from .override directive in SetLEDDisplay
		this.SetLEDDisplay(digit1BitValues, digit2BitValues, digit3BitValues);
	}

	public RailDriverDriver(InitArgs P_0)
	{
		if (P_0 == null)
		{
			throw new ArgumentNullException("initArgs");
		}
		RTFfnmSZRPdNGokWWEvbOzEiNKrQ = P_0.hidDevice;
		pQTMaafMQEcLQJICDYvKIGotlqdv = RTFfnmSZRPdNGokWWEvbOzEiNKrQ.properties;
		QSlvbQwHEydLqBdMfqaDZStcXdPQ = new NativeBuffer(15);
		sPuePzIftIrTqUutBSsdDcAGwcYx = new NativeBuffer(9);
		aXKUTlujzfLmlAFJQDdomGCCZgYN = new YgqnhctsoyAiZixKeAsniiZNPqQeA(sPuePzIftIrTqUutBSsdDcAGwcYx.Pointer, sPuePzIftIrTqUutBSsdDcAGwcYx.Length, 9);
		buttons = new zcGvJvonyWXVMOLIHiTlBSzzCQP[50];
		for (int i = 0; i < 50; i++)
		{
			buttons[i] = new zcGvJvonyWXVMOLIHiTlBSzzCQP(0, new xRwbEhgwfqETGQkYCofyzWNojclTA.HIDInfo
			{
				usagePage = 9,
				usage = (ushort)i
			});
		}
		axes = new CZoMFTjfkBKcdHwbjLAHvGhrFKlm[4]
		{
			new CZoMFTjfkBKcdHwbjLAHvGhrFKlm(0, new xRwbEhgwfqETGQkYCofyzWNojclTA.HIDInfo
			{
				usagePage = 1,
				usage = 48,
				dataIndex = 1,
				bitSize = 8,
				logicalMin = 0,
				logicalMax = 255,
				physicalMin = 0,
				physicalMax = 0,
				units = 0u,
				unitsExp = 0u
			}, false, 127),
			new CZoMFTjfkBKcdHwbjLAHvGhrFKlm(0, new xRwbEhgwfqETGQkYCofyzWNojclTA.HIDInfo
			{
				usagePage = 1,
				usage = 49,
				dataIndex = 2,
				bitSize = 8,
				logicalMin = 0,
				logicalMax = 255,
				physicalMin = 0,
				physicalMax = 0,
				units = 0u,
				unitsExp = 0u
			}, false, 127),
			new CZoMFTjfkBKcdHwbjLAHvGhrFKlm(0, new xRwbEhgwfqETGQkYCofyzWNojclTA.HIDInfo
			{
				usagePage = 1,
				usage = 49,
				dataIndex = 3,
				bitSize = 8,
				logicalMin = 0,
				logicalMax = 255,
				physicalMin = 0,
				physicalMax = 0,
				units = 0u,
				unitsExp = 0u
			}, false, 127),
			new CZoMFTjfkBKcdHwbjLAHvGhrFKlm(0, new xRwbEhgwfqETGQkYCofyzWNojclTA.HIDInfo
			{
				usagePage = 1,
				usage = 50,
				dataIndex = 4,
				bitSize = 8,
				logicalMin = 0,
				logicalMax = 255,
				physicalMin = 0,
				physicalMax = 0,
				units = 0u,
				unitsExp = 0u
			}, false, 127)
		};
	}

	public override void Update(UpdateLoopType updateLoop)
	{
	}

	public override bool ParseInputReport(IntPtr inputReportPtr, int inputReportLength, double timestamp)
	{
		if (inputReportPtr == IntPtr.Zero)
		{
			return false;
		}
		if (inputReportLength < QSlvbQwHEydLqBdMfqaDZStcXdPQ.Length)
		{
			return false;
		}
		QSlvbQwHEydLqBdMfqaDZStcXdPQ.Write(inputReportPtr, inputReportLength, QSlvbQwHEydLqBdMfqaDZStcXdPQ.Length);
		BLiMkmkiXZboHiEjXBUXEoYksGadb(QSlvbQwHEydLqBdMfqaDZStcXdPQ, timestamp);
		xRwbEhgwfqETGQkYCofyzWNojclTA[] array = axes;
		MpoaDsMvrzPkupASJqbJrGhQvVDK(array, QSlvbQwHEydLqBdMfqaDZStcXdPQ, timestamp);
		return true;
	}

	public override Controller.Extension CreateControllerExtension()
	{
		return new RailDriverExtension(this);
	}

	private bool ATMPvgGpbLaBdBjtCVQsnNCUNfnJ(VKMlGjEfVWXMsNWbmYZFLsFvEDqF P_0, lZZYSzlENjVckJKEzwKsVotVgXhb P_1)
	{
		gWBDRNweQDfVIesYPpYDFrkRIhnw(P_0);
		return hgFeDuErhBrrEQWLlcbyBStAODUYb(P_1);
	}

	private void gWBDRNweQDfVIesYPpYDFrkRIhnw(VKMlGjEfVWXMsNWbmYZFLsFvEDqF P_0)
	{
		switch (P_0)
		{
		case VKMlGjEfVWXMsNWbmYZFLsFvEDqF.Speaker:
			sPuePzIftIrTqUutBSsdDcAGwcYx.Clear();
			sPuePzIftIrTqUutBSsdDcAGwcYx[1] = 133;
			sPuePzIftIrTqUutBSsdDcAGwcYx[7] = (byte)(QfWJLDoCZCfcqgooiRcOHAgjibnpA ? 1 : 0);
			break;
		case VKMlGjEfVWXMsNWbmYZFLsFvEDqF.LED:
			sPuePzIftIrTqUutBSsdDcAGwcYx.Clear();
			sPuePzIftIrTqUutBSsdDcAGwcYx[1] = 134;
			sPuePzIftIrTqUutBSsdDcAGwcYx[2] = YeKpCDnuQtvSCbWYpeQyuyjlcTmN[0];
			sPuePzIftIrTqUutBSsdDcAGwcYx[3] = YeKpCDnuQtvSCbWYpeQyuyjlcTmN[1];
			sPuePzIftIrTqUutBSsdDcAGwcYx[4] = YeKpCDnuQtvSCbWYpeQyuyjlcTmN[2];
			break;
		default:
			throw new NotImplementedException();
		}
	}

	private bool hgFeDuErhBrrEQWLlcbyBStAODUYb(lZZYSzlENjVckJKEzwKsVotVgXhb P_0)
	{
		switch (P_0)
		{
		case lZZYSzlENjVckJKEzwKsVotVgXhb.Synchronous:
			return RTFfnmSZRPdNGokWWEvbOzEiNKrQ.WriteSync(aXKUTlujzfLmlAFJQDdomGCCZgYN, 0);
		case lZZYSzlENjVckJKEzwKsVotVgXhb.Asynchronous:
			RTFfnmSZRPdNGokWWEvbOzEiNKrQ.WriteAsync(aXKUTlujzfLmlAFJQDdomGCCZgYN, 1000);
			return true;
		default:
			throw new NotImplementedException();
		}
	}

	private void BLiMkmkiXZboHiEjXBUXEoYksGadb(NativeBuffer P_0, double P_1)
	{
		for (int i = 0; i < 6; i++)
		{
			byte b = P_0[8 + i];
			int num = i * 8;
			for (int j = 0; j < 8; j++)
			{
				int num2 = num + j;
				if (num2 >= 44)
				{
					break;
				}
				buttons[num2].bmTWObZDLAHwBwVIFbvrHBOVINETA((b & (1 << j)) != 0, P_1);
			}
		}
		byte b2 = P_0[6];
		buttons[44].bmTWObZDLAHwBwVIFbvrHBOVINETA(b2 < 95, P_1);
		buttons[45].bmTWObZDLAHwBwVIFbvrHBOVINETA(b2 >= 95 && b2 < 161, P_1);
		buttons[46].bmTWObZDLAHwBwVIFbvrHBOVINETA(b2 >= 161, P_1);
		b2 = P_0[7];
		buttons[47].bmTWObZDLAHwBwVIFbvrHBOVINETA(b2 < 95, P_1);
		buttons[48].bmTWObZDLAHwBwVIFbvrHBOVINETA(b2 >= 95 && b2 < 161, P_1);
		buttons[49].bmTWObZDLAHwBwVIFbvrHBOVINETA(b2 >= 161, P_1);
	}

	private void MpoaDsMvrzPkupASJqbJrGhQvVDK(xRwbEhgwfqETGQkYCofyzWNojclTA[] P_0, NativeBuffer P_1, double P_2)
	{
		for (int i = 0; i < P_0.Length; i++)
		{
			P_0[i].GbhSjusArEIYoVADpBQtaLlsuRfPA(P_1, P_2);
		}
	}

	~RailDriverDriver()
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
			if (QSlvbQwHEydLqBdMfqaDZStcXdPQ != null)
			{
				QSlvbQwHEydLqBdMfqaDZStcXdPQ.Dispose();
			}
			if (sPuePzIftIrTqUutBSsdDcAGwcYx != null)
			{
				sPuePzIftIrTqUutBSsdDcAGwcYx.Dispose();
			}
		}
	}

	public static bool Matches(int vid, int pid)
	{
		if (1523 == vid)
		{
			return 210 == pid;
		}
		return false;
	}
}
