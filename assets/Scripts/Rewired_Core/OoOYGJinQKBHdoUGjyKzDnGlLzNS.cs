using System;
using Rewired;

internal static class OoOYGJinQKBHdoUGjyKzDnGlLzNS
{
	public static EIJabuCGuIkogTgNjoJeTXIEuNcy owBEBEkfEavHlFYmFhYVcctGhNjY(ControllerType P_0)
	{
		return P_0 switch
		{
			ControllerType.Mouse => EIJabuCGuIkogTgNjoJeTXIEuNcy.Mouse, 
			ControllerType.Keyboard => EIJabuCGuIkogTgNjoJeTXIEuNcy.Keyboard, 
			ControllerType.Joystick => EIJabuCGuIkogTgNjoJeTXIEuNcy.Joystick, 
			ControllerType.Custom => EIJabuCGuIkogTgNjoJeTXIEuNcy.CustomController, 
			_ => throw new NotImplementedException(), 
		};
	}
}
