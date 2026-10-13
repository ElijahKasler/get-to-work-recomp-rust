using Rewired.ControllerExtensions;
using Rewired.Utils.Classes.Data;

namespace Rewired.HID.Drivers;

[CustomObfuscation(rename = false)]
[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
internal sealed class NintendoSwitchJoyConLeftDriver : NintendoSwitchJoyConDriver
{
	private const int KKGOevElGlGOCBPJNuigFFrsZiR = 4;

	private const int CsegVSSlvYcMpizXbBpQLJcutMxQA = 6;

	int NintendoSwitchJoyConDriver.byteIndexStartSticks => get_byteIndexStartSticks();

	protected int get_byteIndexStartSticks()
	{
		return 6;
	}

	public NintendoSwitchJoyConLeftDriver(InitArgs P_0)
		: base(P_0, eBJeJyFgStXbLxxnXTUKFCvncgku.JoyConLeft)
	{
	}

	protected override void UpdateButtons(NativeBuffer inputReport, double timestamp)
	{
		byte[] array = base.buttonAxisReadBuffer;
		inputReport.Read(array, 2, 4);
		byte b = array[1];
		if (get_joyConGripStyle() == NintendoSwitchJoyConGripStyle.Horizontal)
		{
			buttons[0].bmTWObZDLAHwBwVIFbvrHBOVINETA((b & 8) != 0, timestamp);
			buttons[1].bmTWObZDLAHwBwVIFbvrHBOVINETA((b & 1) != 0, timestamp);
			buttons[2].bmTWObZDLAHwBwVIFbvrHBOVINETA((b & 2) != 0, timestamp);
			buttons[3].bmTWObZDLAHwBwVIFbvrHBOVINETA((b & 4) != 0, timestamp);
		}
		else
		{
			buttons[0].bmTWObZDLAHwBwVIFbvrHBOVINETA((b & 1) != 0, timestamp);
			buttons[1].bmTWObZDLAHwBwVIFbvrHBOVINETA((b & 4) != 0, timestamp);
			buttons[2].bmTWObZDLAHwBwVIFbvrHBOVINETA((b & 8) != 0, timestamp);
			buttons[3].bmTWObZDLAHwBwVIFbvrHBOVINETA((b & 2) != 0, timestamp);
		}
		buttons[4].bmTWObZDLAHwBwVIFbvrHBOVINETA((b & 0x20) != 0, timestamp);
		buttons[5].bmTWObZDLAHwBwVIFbvrHBOVINETA((b & 0x10) != 0, timestamp);
		buttons[6].bmTWObZDLAHwBwVIFbvrHBOVINETA((b & 0x40) != 0, timestamp);
		buttons[7].bmTWObZDLAHwBwVIFbvrHBOVINETA((b & 0x80) != 0, timestamp);
		b = array[0];
		buttons[8].bmTWObZDLAHwBwVIFbvrHBOVINETA((b & 1) != 0, timestamp);
		buttons[9].bmTWObZDLAHwBwVIFbvrHBOVINETA((b & 0x20) != 0, timestamp);
		buttons[10].bmTWObZDLAHwBwVIFbvrHBOVINETA((b & 8) != 0, timestamp);
	}

	protected override void HandleGripStyleStickAxisSwap(ref ushort stickX, ref ushort stickY)
	{
		if (get_joyConGripStyle() == NintendoSwitchJoyConGripStyle.Horizontal)
		{
			ushort num = stickY;
			stickY = stickX;
			stickX = (ushort)(65535 - num);
		}
	}

	~NintendoSwitchJoyConLeftDriver()
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
			return pid == 8198;
		}
		return false;
	}
}
