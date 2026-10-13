using System;
using Rewired.ControllerExtensions;
using Rewired.Interfaces;
using Rewired.Utils.Classes.Data;

namespace Rewired.HID.Drivers;

[CustomObfuscation(rename = false)]
[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
internal abstract class NintendoSwitchJoyConDriver : NintendoSwitchGamepadDriver, IDriver_NintendoSwitchJoyCon, IDriver_NintendoSwitchController, IControllerDriver, IHIDControllerExtension, IAxisCalibrationIndexMap
{
	private const int mAPIVQMzSzHBCPPqROqJuNgkQtjm = 11;

	private const int kmIDCsAyZzCIlbbtztXRvnqtMYIw = 2;

	private const int RuRIUeTssLzebztBgAcQaBOLdzteA = 1;

	private const int eZZkGNIdClopZpFYKefolDcLhnWJ = 1;

	private const int aluylepHSkyJVXVXJTpPJdYNtNhT = 3;

	private readonly NativeBuffer tGzqAnfxikxlqWjOQDqFmZxMrmSC;

	private readonly NintendoSwitchJoyConType IGjgIVHkxROWhPrclmMFWekZSrJn;

	private NintendoSwitchJoyConGripStyle HwcdCkVlrIALAJYjcAlCmfhEnIyGA;

	private readonly byte[] tZEffLyDDIQURaerjcyaZLDjXhCS = new byte[3];

	protected byte[] buttonAxisReadBuffer => tZEffLyDDIQURaerjcyaZLDjXhCS;

	protected abstract int byteIndexStartSticks { get; }

	NintendoSwitchJoyConType IDriver_NintendoSwitchJoyCon.joyConType => get_joyConType();

	NintendoSwitchJoyConGripStyle IDriver_NintendoSwitchJoyCon.joyConGripStyle
	{
		get
		{
			return get_joyConGripStyle();
		}
		set
		{
			set_joyConGripStyle(value);
		}
	}

	public NintendoSwitchJoyConType get_joyConType()
	{
		return IGjgIVHkxROWhPrclmMFWekZSrJn;
	}

	public NintendoSwitchJoyConGripStyle get_joyConGripStyle()
	{
		return HwcdCkVlrIALAJYjcAlCmfhEnIyGA;
	}

	public void set_joyConGripStyle(NintendoSwitchJoyConGripStyle value)
	{
		HwcdCkVlrIALAJYjcAlCmfhEnIyGA = value;
	}

	int IAxisCalibrationIndexMap.GetMappedAxisIndex(int elementIndex)
	{
		if (elementIndex < 0 || elementIndex > 1)
		{
			return elementIndex;
		}
		if (HwcdCkVlrIALAJYjcAlCmfhEnIyGA == NintendoSwitchJoyConGripStyle.Vertical)
		{
			if (elementIndex == 0)
			{
				return 1;
			}
			return 0;
		}
		return elementIndex;
	}

	protected NintendoSwitchJoyConDriver(InitArgs P_0, eBJeJyFgStXbLxxnXTUKFCvncgku P_1)
		: base(P_0, P_1, 11, 2, 1)
	{
		if (P_1 != eBJeJyFgStXbLxxnXTUKFCvncgku.JoyConLeft && P_1 != eBJeJyFgStXbLxxnXTUKFCvncgku.JoyConRight)
		{
			throw new ArgumentException("controllerType");
		}
		IGjgIVHkxROWhPrclmMFWekZSrJn = ((P_1 != eBJeJyFgStXbLxxnXTUKFCvncgku.JoyConLeft) ? NintendoSwitchJoyConType.Right : NintendoSwitchJoyConType.Left);
		HwcdCkVlrIALAJYjcAlCmfhEnIyGA = NintendoSwitchJoyConGripStyle.Horizontal;
		tGzqAnfxikxlqWjOQDqFmZxMrmSC = new NativeBuffer(5);
		axes = new CZoMFTjfkBKcdHwbjLAHvGhrFKlm[2]
		{
			new CZoMFTjfkBKcdHwbjLAHvGhrFKlm(33, new xRwbEhgwfqETGQkYCofyzWNojclTA.HIDInfo
			{
				usagePage = 1,
				usage = 48,
				dataIndex = 1,
				bitSize = 16,
				logicalMin = 0,
				logicalMax = 65535,
				physicalMin = 0,
				physicalMax = 0,
				units = 0u,
				unitsExp = 0u
			}, false, 32767),
			new CZoMFTjfkBKcdHwbjLAHvGhrFKlm(33, new xRwbEhgwfqETGQkYCofyzWNojclTA.HIDInfo
			{
				usagePage = 1,
				usage = 49,
				dataIndex = 3,
				bitSize = 16,
				logicalMin = 0,
				logicalMax = 65535,
				physicalMin = 0,
				physicalMax = 0,
				units = 0u,
				unitsExp = 0u
			}, false, 32767)
		};
		Initialize();
	}

	public override Controller.Extension CreateControllerExtension()
	{
		return new NintendoSwitchJoyConExtension(this);
	}

	protected override void UpdateElements(xRwbEhgwfqETGQkYCofyzWNojclTA[] elements, NativeBuffer inputReport, double timestamp)
	{
		byte[] array = tZEffLyDDIQURaerjcyaZLDjXhCS;
		inputReport.Read(array, 3, byteIndexStartSticks);
		ushort valueX = (ushort)(array[0] | ((array[1] & 0xF) << 8));
		ushort valueY = (ushort)((array[1] >> 4) | (array[2] << 4));
		GetCalibratedStickValue(valueX, valueY, GetAxisCalibration(0), GetAxisCalibration(1), out var calibratedX, out var calibratedY);
		HandleGripStyleStickAxisSwap(ref calibratedX, ref calibratedY);
		tGzqAnfxikxlqWjOQDqFmZxMrmSC.Write((byte)33, 0);
		tGzqAnfxikxlqWjOQDqFmZxMrmSC.Write(calibratedX, 1);
		tGzqAnfxikxlqWjOQDqFmZxMrmSC.Write(calibratedY, 3);
		for (int i = 0; i < elements.Length; i++)
		{
			elements[i].GbhSjusArEIYoVADpBQtaLlsuRfPA(tGzqAnfxikxlqWjOQDqFmZxMrmSC, timestamp);
		}
	}

	protected abstract void HandleGripStyleStickAxisSwap(ref ushort stickX, ref ushort stickY);

	~NintendoSwitchJoyConDriver()
	{
		Dispose(disposing: false);
	}

	protected override void Dispose(bool disposing)
	{
		if (!base.disposed)
		{
			if (disposing && tGzqAnfxikxlqWjOQDqFmZxMrmSC != null)
			{
				tGzqAnfxikxlqWjOQDqFmZxMrmSC.Dispose();
			}
			base.Dispose(disposing);
		}
	}
}
