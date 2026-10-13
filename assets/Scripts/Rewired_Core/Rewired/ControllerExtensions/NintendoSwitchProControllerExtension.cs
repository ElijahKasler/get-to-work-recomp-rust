using Rewired.HID.Drivers;
using Rewired.Interfaces;

namespace Rewired.ControllerExtensions;

[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
public sealed class NintendoSwitchProControllerExtension : NintendoSwitchGamepadExtension, IControllerVibrator, IHIDControllerExtension
{
	private class bnvnVeFpYTBQNTPMbOqDScxYSuqs : ExtSource_Base
	{
		public IDriver_NintendoSwitchProController wiFEqORNpDaByyTwOwRnsIJngwkAA => cqJOFUIPLsnfmxXbTgEaRskzUqMx();

		public IDriver_NintendoSwitchProController cqJOFUIPLsnfmxXbTgEaRskzUqMx()
		{
			return base.driver as IDriver_NintendoSwitchProController;
		}

		public bnvnVeFpYTBQNTPMbOqDScxYSuqs(IDriver_NintendoSwitchProController P_0)
			: base(P_0)
		{
		}
	}

	public int motorIndexLeft;

	public int motorIndexRight = 1;

	private new bnvnVeFpYTBQNTPMbOqDScxYSuqs source => WqfTMceimUiiayENxWflPBWGSyCM();

	private bnvnVeFpYTBQNTPMbOqDScxYSuqs WqfTMceimUiiayENxWflPBWGSyCM()
	{
		return base.source as bnvnVeFpYTBQNTPMbOqDScxYSuqs;
	}

	internal NintendoSwitchProControllerExtension(IDriver_NintendoSwitchProController P_0)
		: base(new bnvnVeFpYTBQNTPMbOqDScxYSuqs(P_0))
	{
	}

	private NintendoSwitchProControllerExtension(NintendoSwitchProControllerExtension P_0)
		: base(P_0)
	{
	}

	internal override Controller.Extension Clone()
	{
		return new NintendoSwitchProControllerExtension(this);
	}
}
