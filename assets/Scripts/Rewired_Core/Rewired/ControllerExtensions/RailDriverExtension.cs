using Rewired.HID.Drivers;
using Rewired.Interfaces;

namespace Rewired.ControllerExtensions;

[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
public sealed class RailDriverExtension : Controller.Extension, IHIDControllerExtension
{
	private class tXHdPPGAxJDYwvZONesyHipsStjJ : IControllerExtensionSource
	{
		public readonly IDriver_RailDriver EovUFirYcxhBCrjtnYHVwPEeHIZS;

		public tXHdPPGAxJDYwvZONesyHipsStjJ(IDriver_RailDriver P_0)
		{
			EovUFirYcxhBCrjtnYHVwPEeHIZS = P_0;
		}
	}

	private tXHdPPGAxJDYwvZONesyHipsStjJ aUrOChHPxoJCvPkYLNEVpGhGibqZ;

	private Joystick joystick => DtdyAvKRximKfKVqKmxnWOMJMddu();

	public bool speakerEnabled
	{
		get
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return false;
			}
			if (aUrOChHPxoJCvPkYLNEVpGhGibqZ.EovUFirYcxhBCrjtnYHVwPEeHIZS == null)
			{
				return false;
			}
			return aUrOChHPxoJCvPkYLNEVpGhGibqZ.EovUFirYcxhBCrjtnYHVwPEeHIZS.SpeakerEnabled;
		}
		set
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else if (aUrOChHPxoJCvPkYLNEVpGhGibqZ.EovUFirYcxhBCrjtnYHVwPEeHIZS != null)
			{
				aUrOChHPxoJCvPkYLNEVpGhGibqZ.EovUFirYcxhBCrjtnYHVwPEeHIZS.SpeakerEnabled = value;
			}
		}
	}

	ushort IHIDControllerExtension.vendorId
	{
		get
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return 0;
			}
			return aUrOChHPxoJCvPkYLNEVpGhGibqZ.EovUFirYcxhBCrjtnYHVwPEeHIZS.vendorId;
		}
	}

	ushort IHIDControllerExtension.productId
	{
		get
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return 0;
			}
			return aUrOChHPxoJCvPkYLNEVpGhGibqZ.EovUFirYcxhBCrjtnYHVwPEeHIZS.productId;
		}
	}

	string IHIDControllerExtension.productName
	{
		get
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return string.Empty;
			}
			return aUrOChHPxoJCvPkYLNEVpGhGibqZ.EovUFirYcxhBCrjtnYHVwPEeHIZS.productName;
		}
	}

	string IHIDControllerExtension.manufacturer
	{
		get
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return string.Empty;
			}
			return aUrOChHPxoJCvPkYLNEVpGhGibqZ.EovUFirYcxhBCrjtnYHVwPEeHIZS.manufacturer;
		}
	}

	ushort IHIDControllerExtension.usagePage
	{
		get
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return 0;
			}
			return aUrOChHPxoJCvPkYLNEVpGhGibqZ.EovUFirYcxhBCrjtnYHVwPEeHIZS.usagePage;
		}
	}

	ushort IHIDControllerExtension.usage
	{
		get
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return 0;
			}
			return aUrOChHPxoJCvPkYLNEVpGhGibqZ.EovUFirYcxhBCrjtnYHVwPEeHIZS.usage;
		}
	}

	private Joystick DtdyAvKRximKfKVqKmxnWOMJMddu()
	{
		return GetController<Joystick>();
	}

	internal RailDriverExtension(IDriver_RailDriver P_0)
		: base(new tXHdPPGAxJDYwvZONesyHipsStjJ(P_0))
	{
	}

	private RailDriverExtension(RailDriverExtension P_0)
		: base(P_0)
	{
	}

	public void SetLEDDisplay(int digitIndex, byte digitBitValues)
	{
		if (ReInput._id != _reInputId)
		{
			ReInput.CheckInitialized(_reInputId);
		}
		else if (aUrOChHPxoJCvPkYLNEVpGhGibqZ.EovUFirYcxhBCrjtnYHVwPEeHIZS != null && base.enabled)
		{
			aUrOChHPxoJCvPkYLNEVpGhGibqZ.EovUFirYcxhBCrjtnYHVwPEeHIZS.SetLEDDisplay(digitIndex, digitBitValues);
		}
	}

	public void SetLEDDisplay(byte digit1BitValues, byte digit2BitValues, byte digit3BitValues)
	{
		if (ReInput._id != _reInputId)
		{
			ReInput.CheckInitialized(_reInputId);
		}
		else if (aUrOChHPxoJCvPkYLNEVpGhGibqZ.EovUFirYcxhBCrjtnYHVwPEeHIZS != null && base.enabled)
		{
			aUrOChHPxoJCvPkYLNEVpGhGibqZ.EovUFirYcxhBCrjtnYHVwPEeHIZS.SetLEDDisplay(digit1BitValues, digit2BitValues, digit3BitValues);
		}
	}

	internal override void UpdateData(UpdateLoopType updateLoop)
	{
	}

	internal override void SourceUpdated(IControllerExtensionSource source)
	{
		aUrOChHPxoJCvPkYLNEVpGhGibqZ = source as tXHdPPGAxJDYwvZONesyHipsStjJ;
	}

	internal override Controller.Extension Clone()
	{
		return new RailDriverExtension(this);
	}
}
