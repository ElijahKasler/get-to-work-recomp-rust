using Rewired;
using Rewired.Interfaces;
using Rewired.Internal;
using Rewired.Platforms;
using Rewired.Utils;
using UnityEngine;

internal sealed class ZaZakljPCuZqhaGAAJIhKqiAGYyfA : IElementIdentifierTool
{
	private Rewired.Internal.GUIText jhsPUTaetHTtIgIDnqmznMszZgRE;

	private string FxtmZwIBYIFzLBYKYnqIFvhHblKl;

	private int gJbcVDXCIkdpZRnXXfvBgXirpOtS = 1;

	public void Initialize(Rewired.Internal.GUIText text)
	{
		jhsPUTaetHTtIgIDnqmznMszZgRE = text;
	}

	void IElementIdentifierTool.Initialize(Rewired.Internal.GUIText text)
	{
		//ILSpy generated this explicit interface implementation from .override directive in Initialize
		this.Initialize(text);
	}

	public void Start()
	{
		string[] joystickNames = Input.GetJoystickNames();
		string text = "Detected " + joystickNames.Length + " attached joysticks";
		if (joystickNames.Length != 0)
		{
			text += ":\n";
		}
		string[] array = joystickNames;
		foreach (string text2 in array)
		{
			text = text + "\"" + text2 + "\"\n";
		}
		Rewired.Logger.Log(text);
	}

	void IElementIdentifierTool.Start()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Start
		this.Start();
	}

	public void Update()
	{
		if (Input.GetKeyDown(KeyCode.Equals) || Input.GetKeyDown(KeyCode.Plus) || Input.GetKeyDown(KeyCode.KeypadPlus))
		{
			gJbcVDXCIkdpZRnXXfvBgXirpOtS++;
		}
		if (Input.GetKeyDown(KeyCode.KeypadMinus) || Input.GetKeyDown(KeyCode.Minus))
		{
			gJbcVDXCIkdpZRnXXfvBgXirpOtS--;
		}
		if (gJbcVDXCIkdpZRnXXfvBgXirpOtS <= 0)
		{
			gJbcVDXCIkdpZRnXXfvBgXirpOtS = 16;
		}
		else if (gJbcVDXCIkdpZRnXXfvBgXirpOtS > 16)
		{
			gJbcVDXCIkdpZRnXXfvBgXirpOtS = 1;
		}
		FxtmZwIBYIFzLBYKYnqIFvhHblKl = "Unity Joystick Element Identifier:\n\n";
		string[] joystickNames = Input.GetJoystickNames();
		if (joystickNames.Length != 0)
		{
			FxtmZwIBYIFzLBYKYnqIFvhHblKl += "Connected joysticks:\n";
		}
		else
		{
			FxtmZwIBYIFzLBYKYnqIFvhHblKl += "No joysticks detected.\n";
		}
		for (int i = 0; i < joystickNames.Length; i++)
		{
			FxtmZwIBYIFzLBYKYnqIFvhHblKl = FxtmZwIBYIFzLBYKYnqIFvhHblKl + "[" + i + "] \"" + joystickNames[i] + "\"";
			if (UnityTools.platform == Platform.Linux && UnityTools.externalTools.LinuxInput_IsJoystickPreconfigured(joystickNames[i]))
			{
				FxtmZwIBYIFzLBYKYnqIFvhHblKl += " [UNITY PRE-CONFIGURED]";
			}
			FxtmZwIBYIFzLBYKYnqIFvhHblKl += "\n";
		}
		FxtmZwIBYIFzLBYKYnqIFvhHblKl += "\n";
		FxtmZwIBYIFzLBYKYnqIFvhHblKl = FxtmZwIBYIFzLBYKYnqIFvhHblKl + "Current Unity Joystick Id: " + gJbcVDXCIkdpZRnXXfvBgXirpOtS + "\n";
		FxtmZwIBYIFzLBYKYnqIFvhHblKl += "(Press + or - to change monitored joystick id.)\n\n";
		for (int j = 0; j < 29; j++)
		{
			string text = "Axis " + j;
			float joystickAxisValueByJoystickId = UnityInputHelper.GetJoystickAxisValueByJoystickId(gJbcVDXCIkdpZRnXXfvBgXirpOtS, j);
			kVYCKcschenltOfkXEBwuIAWhVls(text, joystickAxisValueByJoystickId);
		}
		for (int k = 0; k < 20; k++)
		{
			string text2 = "Button " + k;
			bool joystickButtonValueByJoystickId = UnityInputHelper.GetJoystickButtonValueByJoystickId(gJbcVDXCIkdpZRnXXfvBgXirpOtS, k);
			kVYCKcschenltOfkXEBwuIAWhVls(text2, joystickButtonValueByJoystickId);
		}
		jhsPUTaetHTtIgIDnqmznMszZgRE.text = FxtmZwIBYIFzLBYKYnqIFvhHblKl;
	}

	void IElementIdentifierTool.Update()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Update
		this.Update();
	}

	public void OnDestroy()
	{
	}

	void IElementIdentifierTool.OnDestroy()
	{
		//ILSpy generated this explicit interface implementation from .override directive in OnDestroy
		this.OnDestroy();
	}

	private void kVYCKcschenltOfkXEBwuIAWhVls(string P_0, object P_1)
	{
		FxtmZwIBYIFzLBYKYnqIFvhHblKl = FxtmZwIBYIFzLBYKYnqIFvhHblKl + P_0 + " = " + P_1.ToString() + "\n";
	}
}
