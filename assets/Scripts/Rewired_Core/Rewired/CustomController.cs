using System;
using Rewired.Utils;

namespace Rewired;

public sealed class CustomController : ControllerWithAxes
{
	private int EMwfrsVVJifAyujkKcYYBFHlTZut;

	private Func<int, float> LrULnMrIbFaZLrxkUIoZSavWSkHf;

	private Func<int, bool> MEXHyWELxptQUmWWQdUTcfBxDdCZ;

	private bool DAngyjJXUciMYjLpOpfOtMTMWsrh;

	private Guid McVaLprHJDcIrdpuJKUKiGnXIofcb;

	public int sourceControllerId => EMwfrsVVJifAyujkKcYYBFHlTZut;

	Guid Controller.deviceInstanceGuid => get_deviceInstanceGuid();

	public Guid get_deviceInstanceGuid()
	{
		if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
		{
			ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
			return Guid.Empty;
		}
		return McVaLprHJDcIrdpuJKUKiGnXIofcb;
	}

	internal CustomController(PzwBCfxuWqkkCSbfSUVoirirCnBr P_0)
		: this(P_0.JeXxVLjbyIBqMwmbLwVUsNIsEMdL, P_0.XSyXCSYaWEbIQklYxeZnDtqilZMeb, P_0.qPEgCFqjTYPTukGRfbqeJRCnvCBmA, P_0.YKBFIjjwavffEGQoQROkfEyWTPFFA, P_0.nBMGFeRxhFSuEGfKjcFBqBYcPkLW, P_0.ZlXBEgrpbBztECARDGxqfrvyhWlxA, P_0.FWENtMBmCimgVMdAizAVrACbJmwl, P_0.TXUkUipShDqAsHOVPrhKfXvjINcV, P_0.oKRyTyCKJSqaIkabtLhFvqNceSKp, P_0.mpPmNaySUqsItJpQuTugHYRJMYxD, null, new ControllerDataUpdater(P_0.YKBFIjjwavffEGQoQROkfEyWTPFFA, P_0.TXUkUipShDqAsHOVPrhKfXvjINcV, P_0.oKRyTyCKJSqaIkabtLhFvqNceSKp, null))
	{
	}

	private CustomController(int P_0, int P_1, Guid P_2, InputSource P_3, string P_4, string P_5, string P_6, int P_7, int P_8, HardwareControllerMap_Game P_9, Extension P_10, ControllerDataUpdater P_11)
		: base(P_0, P_3, P_4, P_5, P_6, ControllerType.Custom, P_2, P_7, P_8, null, P_9, P_10, P_11)
	{
		EMwfrsVVJifAyujkKcYYBFHlTZut = P_1;
		McVaLprHJDcIrdpuJKUKiGnXIofcb = MiscTools.CreateGuidHashSHA1("CustomController device instance GUID: sourceId = " + EMwfrsVVJifAyujkKcYYBFHlTZut + ", controllerId = " + P_0);
		EMBHjcsxjUDMCsHethyxgQTJtbEg();
	}

	internal void QnkFqudZkXFAhfbdybPovyleWgCGA()
	{
		if (!DAngyjJXUciMYjLpOpfOtMTMWsrh)
		{
			return;
		}
		if (LrULnMrIbFaZLrxkUIoZSavWSkHf != null)
		{
			for (int i = 0; i < _axisCount; i++)
			{
				KRqNAliDQUoGilZWSpebheoTCzwBA.axisValues[i] = LrULnMrIbFaZLrxkUIoZSavWSkHf(i);
			}
		}
		if (MEXHyWELxptQUmWWQdUTcfBxDdCZ != null)
		{
			for (int j = 0; j < _buttonCount; j++)
			{
				KRqNAliDQUoGilZWSpebheoTCzwBA.buttonValues[j] = MEXHyWELxptQUmWWQdUTcfBxDdCZ(j);
			}
		}
	}

	public void SetAxisValue(int index, float value)
	{
		if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
		{
			ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
		}
		else if (base.enabled)
		{
			if (index < 0 || index >= _axisCount)
			{
				Logger.LogWarning(index + " is not a valid Axis index.");
			}
			else
			{
				KRqNAliDQUoGilZWSpebheoTCzwBA.axisValues[index] = value;
			}
		}
	}

	public void SetAxisValue(string elementName, float value)
	{
		if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
		{
			ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
		}
		else if (base.enabled)
		{
			int axisIndex = aHJMAWzbypGgwCcRCqDEaoqVGwfA.GetAxisIndex(elementName);
			if (axisIndex < 0 || axisIndex >= _axisCount)
			{
				Logger.LogWarning("\"" + axisIndex + "\" is not a valid Axis name.");
			}
			else
			{
				KRqNAliDQUoGilZWSpebheoTCzwBA.axisValues[axisIndex] = value;
			}
		}
	}

	public void SetAxisValueById(int elementId, float value)
	{
		if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
		{
			ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
		}
		else if (base.enabled)
		{
			int axisIndex = aHJMAWzbypGgwCcRCqDEaoqVGwfA.GetAxisIndex(elementId);
			if (axisIndex < 0 || axisIndex >= _axisCount)
			{
				Logger.LogWarning(elementId + " is not a valid Axis id.");
			}
			else
			{
				KRqNAliDQUoGilZWSpebheoTCzwBA.axisValues[axisIndex] = value;
			}
		}
	}

	public void SetButtonValue(int index, bool value)
	{
		if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
		{
			ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
		}
		else if (base.enabled)
		{
			if (index < 0 || index >= _buttonCount)
			{
				Logger.LogWarning(index + " is not a valid Button index.");
			}
			else
			{
				KRqNAliDQUoGilZWSpebheoTCzwBA.buttonValues[index] = value;
			}
		}
	}

	public void SetButtonValue(string elementName, bool value)
	{
		if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
		{
			ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
		}
		else if (base.enabled)
		{
			int buttonIndex = aHJMAWzbypGgwCcRCqDEaoqVGwfA.GetButtonIndex(elementName);
			if (buttonIndex < 0 || buttonIndex >= _buttonCount)
			{
				Logger.LogWarning("\"" + buttonIndex + "\" is not a valid Button name.");
			}
			else
			{
				KRqNAliDQUoGilZWSpebheoTCzwBA.buttonValues[buttonIndex] = value;
			}
		}
	}

	public void SetButtonValueById(int elementId, bool value)
	{
		if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
		{
			ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
		}
		else if (base.enabled)
		{
			int buttonIndex = aHJMAWzbypGgwCcRCqDEaoqVGwfA.GetButtonIndex(elementId);
			if (buttonIndex < 0 || buttonIndex >= _buttonCount)
			{
				Logger.LogWarning(elementId + " is not a valid Button id.");
			}
			else
			{
				KRqNAliDQUoGilZWSpebheoTCzwBA.buttonValues[buttonIndex] = value;
			}
		}
	}

	public void SetAxisUpdateCallback(Func<int, float> callback)
	{
		if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
		{
			ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
			return;
		}
		LrULnMrIbFaZLrxkUIoZSavWSkHf = callback;
		if (!DAngyjJXUciMYjLpOpfOtMTMWsrh)
		{
			DAngyjJXUciMYjLpOpfOtMTMWsrh = true;
		}
	}

	public void SetButtonUpdateCallback(Func<int, bool> callback)
	{
		if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
		{
			ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
			return;
		}
		MEXHyWELxptQUmWWQdUTcfBxDdCZ = callback;
		if (!DAngyjJXUciMYjLpOpfOtMTMWsrh)
		{
			DAngyjJXUciMYjLpOpfOtMTMWsrh = true;
		}
	}

	public void ClearAxisValue(int index)
	{
		if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
		{
			ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
		}
		else if (base.enabled)
		{
			if (index < 0 || index >= _axisCount)
			{
				Logger.LogWarning(index + " is not a valid Axis index.");
				return;
			}
			float num = ((_calibrationMap != null) ? _calibrationMap.GetAxis(index).calibratedZero : 0f);
			KRqNAliDQUoGilZWSpebheoTCzwBA.axisValues[index] = num;
		}
	}

	public void ClearAxisValue(string elementName)
	{
		if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
		{
			ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
		}
		else if (base.enabled)
		{
			int axisIndex = aHJMAWzbypGgwCcRCqDEaoqVGwfA.GetAxisIndex(elementName);
			if (axisIndex < 0 || axisIndex >= _axisCount)
			{
				Logger.LogWarning("\"" + axisIndex + "\" is not a valid Axis name.");
			}
			else
			{
				ClearAxisValue(axisIndex);
			}
		}
	}

	public void ClearAxisValueById(int elementId)
	{
		if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
		{
			ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
		}
		else if (base.enabled)
		{
			int axisIndex = aHJMAWzbypGgwCcRCqDEaoqVGwfA.GetAxisIndex(elementId);
			if (axisIndex < 0 || axisIndex >= _axisCount)
			{
				Logger.LogWarning(elementId + " is not a valid Axis id.");
			}
			else
			{
				ClearAxisValue(axisIndex);
			}
		}
	}

	public void ClearButtonValue(int index)
	{
		if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
		{
			ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
		}
		else if (base.enabled)
		{
			if (index < 0 || index >= _buttonCount)
			{
				Logger.LogWarning(index + " is not a valid Button index.");
				return;
			}
			KRqNAliDQUoGilZWSpebheoTCzwBA.buttonValues[index] = false;
			KRqNAliDQUoGilZWSpebheoTCzwBA.buttonPressureValues[index] = 0f;
		}
	}

	public void ClearButtonValue(string elementName)
	{
		if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
		{
			ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
		}
		else if (base.enabled)
		{
			int buttonIndex = aHJMAWzbypGgwCcRCqDEaoqVGwfA.GetButtonIndex(elementName);
			if (buttonIndex < 0 || buttonIndex >= _buttonCount)
			{
				Logger.LogWarning("\"" + buttonIndex + "\" is not a valid Button name.");
			}
			else
			{
				ClearButtonValue(buttonIndex);
			}
		}
	}

	public void ClearButtonValueById(int elementId)
	{
		if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
		{
			ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
		}
		else if (base.enabled)
		{
			int buttonIndex = aHJMAWzbypGgwCcRCqDEaoqVGwfA.GetButtonIndex(elementId);
			if (buttonIndex < 0 || buttonIndex >= _buttonCount)
			{
				Logger.LogWarning(elementId + " is not a valid Button id.");
			}
			else
			{
				ClearButtonValue(buttonIndex);
			}
		}
	}
}
