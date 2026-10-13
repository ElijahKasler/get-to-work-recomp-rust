using System;
using Rewired.Data.Mapping;
using Rewired.Interfaces;

namespace Rewired;

[CustomObfuscation(rename = false)]
[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
internal class UnityUnifiedKeyboardSource : IUnifiedKeyboardSource, IGetSetEnabled, IDisposable
{
	private const int eLtoVdeaGJXcbqRIciOMvtMUBIxY = 132;

	private static HardwareControllerMap_Game nDTdIaToWInwPqYbQiiNPbsLEEHn;

	private bool UDzcIjfLXQmUtEUtLgRRAGAEHfDBb;

	private bool GeXYLQMovIeZbKmxWtwadzFYUJlg;

	bool IGetSetEnabled.enabled
	{
		get
		{
			return get_enabled();
		}
		set
		{
			set_enabled(value);
		}
	}

	InputSource IUnifiedKeyboardSource.inputSource => get_inputSource();

	HardwareControllerMap_Game IUnifiedKeyboardSource.hardwareMap => get_hardwareMap();

	int IUnifiedKeyboardSource.buttonCount => get_buttonCount();

	Controller.Extension IUnifiedKeyboardSource.controllerExtension => get_controllerExtension();

	public bool get_enabled()
	{
		return UDzcIjfLXQmUtEUtLgRRAGAEHfDBb;
	}

	public void set_enabled(bool value)
	{
		if (UDzcIjfLXQmUtEUtLgRRAGAEHfDBb != value)
		{
			UDzcIjfLXQmUtEUtLgRRAGAEHfDBb = value;
			Clear();
			ThreadSafeUnityInput.keyboard.Monitor(value);
		}
	}

	public InputSource get_inputSource()
	{
		return InputSource.UnityKeyboardAndMouse;
	}

	public HardwareControllerMap_Game get_hardwareMap()
	{
		if (nDTdIaToWInwPqYbQiiNPbsLEEHn == null)
		{
			nDTdIaToWInwPqYbQiiNPbsLEEHn = CreateHardwareMap();
		}
		return nDTdIaToWInwPqYbQiiNPbsLEEHn;
	}

	public int get_buttonCount()
	{
		return 132;
	}

	public Controller.Extension get_controllerExtension()
	{
		return null;
	}

	public UnityUnifiedKeyboardSource()
	{
		set_enabled(value: true);
	}

	public void UpdateInputData(ControllerDataUpdater dataUpdater)
	{
		if (UDzcIjfLXQmUtEUtLgRRAGAEHfDBb)
		{
			ThreadSafeUnityInput.keyboard.GetKeyValues(dataUpdater.buttonValues);
		}
	}

	void IUnifiedKeyboardSource.UpdateInputData(ControllerDataUpdater dataUpdater)
	{
		//ILSpy generated this explicit interface implementation from .override directive in UpdateInputData
		this.UpdateInputData(dataUpdater);
	}

	public void Clear()
	{
	}

	void IUnifiedKeyboardSource.Clear()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Clear
		this.Clear();
	}

	internal static HardwareControllerMap_Game CreateHardwareMap()
	{
		ControllerElementIdentifier[] array = new ControllerElementIdentifier[132];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = new ControllerElementIdentifier(i, Consts.keyboardKeyNames[i], Consts.keyboardKeyNames[i], string.Empty, ControllerElementType.Button, true);
		}
		int[] array2 = new int[132];
		for (int j = 0; j < 132; j++)
		{
			array2[j] = array[j].get_id();
		}
		HardwareButtonInfo[] array3 = new HardwareButtonInfo[132];
		for (int k = 0; k < 132; k++)
		{
			array3[k] = new HardwareButtonInfo();
		}
		return new HardwareControllerMap_Game("Keyboard", default, array, array2, new int[0], new AxisCalibrationData[0], new AxisRange[0], new HardwareAxisInfo[0], array3, null);
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	~UnityUnifiedKeyboardSource()
	{
		Dispose(disposing: false);
	}

	protected virtual void Dispose(bool disposing)
	{
		if (!GeXYLQMovIeZbKmxWtwadzFYUJlg)
		{
			if (disposing && UDzcIjfLXQmUtEUtLgRRAGAEHfDBb)
			{
				ThreadSafeUnityInput.keyboard.Monitor(state: false);
			}
			GeXYLQMovIeZbKmxWtwadzFYUJlg = true;
		}
	}

	public static ControllerElementType GetHardwareElementType(int elementIdentifierId)
	{
		if (nDTdIaToWInwPqYbQiiNPbsLEEHn == null)
		{
			nDTdIaToWInwPqYbQiiNPbsLEEHn = CreateHardwareMap();
		}
		return nDTdIaToWInwPqYbQiiNPbsLEEHn.GetElementType(elementIdentifierId);
	}
}
