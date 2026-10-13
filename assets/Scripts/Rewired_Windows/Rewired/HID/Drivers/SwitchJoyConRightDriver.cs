using Rewired.ControllerExtensions;
using Rewired.Utils.Classes.Data;

namespace Rewired.HID.Drivers;

[CustomObfuscation(rename = false)]
[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
internal sealed class SwitchJoyConRightDriver : NintendoSwitchJoyConDriver
{
	private const int cxgByDXGnEYKEcLQSDpgYWtknyfq = 3;

	private const int sfXokTLJTOQyocUFUUwXmgQCplYJ = 9;

	int NintendoSwitchJoyConDriver.byteIndexStartSticks => get_byteIndexStartSticks();

	protected int get_byteIndexStartSticks()
	{
		return 9;
	}

	public SwitchJoyConRightDriver(InitArgs P_0)
		: base(P_0, eBJeJyFgStXbLxxnXTUKFCvncgku.JoyConRight)
	{
	}

	protected override void UpdateButtons(NativeBuffer inputReport, double timestamp)
	{
		byte[] array = base.buttonAxisReadBuffer;
		inputReport.Read(array, 2, 3);
		byte b = array[0];
		buttons[0].bmTWObZDLAHwBwVIFbvrHBOVINETA((b & 8) != 0, timestamp);
		buttons[1].bmTWObZDLAHwBwVIFbvrHBOVINETA((b & 2) != 0, timestamp);
		buttons[2].bmTWObZDLAHwBwVIFbvrHBOVINETA((b & 4) != 0, timestamp);
		buttons[3].bmTWObZDLAHwBwVIFbvrHBOVINETA((b & 1) != 0, timestamp);
		buttons[4].bmTWObZDLAHwBwVIFbvrHBOVINETA((b & 0x20) != 0, timestamp);
		buttons[5].bmTWObZDLAHwBwVIFbvrHBOVINETA((b & 0x10) != 0, timestamp);
		buttons[6].bmTWObZDLAHwBwVIFbvrHBOVINETA((b & 0x40) != 0, timestamp);
		buttons[7].bmTWObZDLAHwBwVIFbvrHBOVINETA((b & 0x80) != 0, timestamp);
		b = array[1];
		buttons[8].bmTWObZDLAHwBwVIFbvrHBOVINETA((b & 2) != 0, timestamp);
		buttons[9].bmTWObZDLAHwBwVIFbvrHBOVINETA((b & 0x10) != 0, timestamp);
		buttons[10].bmTWObZDLAHwBwVIFbvrHBOVINETA((b & 4) != 0, timestamp);
	}

	protected override void HandleGripStyleStickAxisSwap(ref ushort stickX, ref ushort stickY)
	{
		if (get_joyConGripStyle() == NintendoSwitchJoyConGripStyle.Horizontal)
		{
			ushort num = stickY;
			stickY = (ushort)(65535 - stickX);
			stickX = num;
		}
	}

	~SwitchJoyConRightDriver()
	{
		Dispose(disposing: false);
	}

	protected override void Dispose(bool disposing)
	{
		if (!base.disposed)
		{
			base.Dispose(disposing);
		}
	}

	public static bool Matches(int vid, int pid)
	{
		if (vid == 1406)
		{
			return pid == 8199;
		}
		return false;
	}
}
