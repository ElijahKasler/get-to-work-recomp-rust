using Rewired.HID.Drivers;
using Rewired.Interfaces;

namespace Rewired.ControllerExtensions;

[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
public sealed class NintendoSwitchJoyConExtension : NintendoSwitchGamepadExtension, IControllerVibrator, IHIDControllerExtension, IAxisCalibrationIndexMap
{
	private class MGklUXXuWubFTigkdZdhfRUfIRXs : ExtSource_Base
	{
		public IDriver_NintendoSwitchJoyCon aGKfOlCoUaOJhYYSczujNElNLVZqA => yTorTfoVLARDmvbHRHoWgRZjutuhA();

		public IDriver_NintendoSwitchJoyCon yTorTfoVLARDmvbHRHoWgRZjutuhA()
		{
			return base.driver as IDriver_NintendoSwitchJoyCon;
		}

		public MGklUXXuWubFTigkdZdhfRUfIRXs(IDriver_NintendoSwitchJoyCon P_0)
			: base(P_0)
		{
		}
	}

	private new MGklUXXuWubFTigkdZdhfRUfIRXs source => fBZQrnvKbUEZFUxFGdkmFMvwCiVW();

	public NintendoSwitchJoyConType joyConType
	{
		get
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return NintendoSwitchJoyConType.Right;
			}
			if (!base.isValid)
			{
				return NintendoSwitchJoyConType.Left;
			}
			return fBZQrnvKbUEZFUxFGdkmFMvwCiVW().yTorTfoVLARDmvbHRHoWgRZjutuhA().joyConType;
		}
	}

	public NintendoSwitchJoyConGripStyle joyConGripStyle
	{
		get
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return NintendoSwitchJoyConGripStyle.Horizontal;
			}
			if (!base.isValid)
			{
				return NintendoSwitchJoyConGripStyle.Horizontal;
			}
			return fBZQrnvKbUEZFUxFGdkmFMvwCiVW().yTorTfoVLARDmvbHRHoWgRZjutuhA().joyConGripStyle;
		}
		set
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else if (base.isValid)
			{
				fBZQrnvKbUEZFUxFGdkmFMvwCiVW().yTorTfoVLARDmvbHRHoWgRZjutuhA().joyConGripStyle = value;
			}
		}
	}

	private MGklUXXuWubFTigkdZdhfRUfIRXs fBZQrnvKbUEZFUxFGdkmFMvwCiVW()
	{
		return base.source as MGklUXXuWubFTigkdZdhfRUfIRXs;
	}

	internal NintendoSwitchJoyConExtension(IDriver_NintendoSwitchJoyCon P_0)
		: base(new MGklUXXuWubFTigkdZdhfRUfIRXs(P_0))
	{
	}

	private NintendoSwitchJoyConExtension(NintendoSwitchJoyConExtension P_0)
		: base(P_0)
	{
	}

	private int zqGqhAxLdJBsAvRXNYoAwYyEVewg(int P_0)
	{
		if (ReInput._id != _reInputId)
		{
			ReInput.CheckInitialized(_reInputId);
			return P_0;
		}
		if (!base.isValid)
		{
			return P_0;
		}
		return fBZQrnvKbUEZFUxFGdkmFMvwCiVW().yTorTfoVLARDmvbHRHoWgRZjutuhA().GetMappedAxisIndex(P_0);
	}

	int IAxisCalibrationIndexMap.GetMappedAxisIndex(int P_0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in zqGqhAxLdJBsAvRXNYoAwYyEVewg
		return this.zqGqhAxLdJBsAvRXNYoAwYyEVewg(P_0);
	}

	internal override Controller.Extension Clone()
	{
		return new NintendoSwitchJoyConExtension(this);
	}
}
