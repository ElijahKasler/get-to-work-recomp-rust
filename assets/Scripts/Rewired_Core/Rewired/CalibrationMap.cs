using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using UnityEngine;

namespace Rewired;

[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
public sealed class CalibrationMap
{
	private AxisCalibration[] lmYplIPHebFJmSBtMVyxcJWAAiKK;

	private MappedArray<AxisCalibration> RARhIlVjlcqRyMYLTQZiMqQZUjfe;

	private IList<AxisCalibration> FCqAIBGeHvOGNVxlZelgdRDENibxA;

	private readonly int ecBSxmPTHEUAYINFSmJQXSqvyjhB;

	public IList<AxisCalibration> Axes => FCqAIBGeHvOGNVxlZelgdRDENibxA;

	public int axisCount
	{
		get
		{
			if (lmYplIPHebFJmSBtMVyxcJWAAiKK == null)
			{
				return 0;
			}
			return lmYplIPHebFJmSBtMVyxcJWAAiKK.Length;
		}
	}

	private CalibrationMap()
	{
		ecBSxmPTHEUAYINFSmJQXSqvyjhB = ReInput.id;
	}

	internal CalibrationMap(AxisCalibrationData[] P_0, Func<int, int> P_1)
		: this()
	{
		int num = ((P_0 != null) ? P_0.Length : 0);
		lmYplIPHebFJmSBtMVyxcJWAAiKK = new AxisCalibration[num];
		RARhIlVjlcqRyMYLTQZiMqQZUjfe = new MappedArray<AxisCalibration>(lmYplIPHebFJmSBtMVyxcJWAAiKK, P_1);
		for (int i = 0; i < num; i++)
		{
			lmYplIPHebFJmSBtMVyxcJWAAiKK[i] = new AxisCalibration(P_0[i]);
		}
		FCqAIBGeHvOGNVxlZelgdRDENibxA = new ReadOnlyCollection<AxisCalibration>(RARhIlVjlcqRyMYLTQZiMqQZUjfe);
	}

	public CalibrationMap(AxisCalibration[] P_0)
		: this()
	{
		lmYplIPHebFJmSBtMVyxcJWAAiKK = P_0;
		RARhIlVjlcqRyMYLTQZiMqQZUjfe = new MappedArray<AxisCalibration>(lmYplIPHebFJmSBtMVyxcJWAAiKK, null);
		FCqAIBGeHvOGNVxlZelgdRDENibxA = new ReadOnlyCollection<AxisCalibration>(RARhIlVjlcqRyMYLTQZiMqQZUjfe);
	}

	public void Reset()
	{
		if (ReInput._id != ecBSxmPTHEUAYINFSmJQXSqvyjhB)
		{
			ReInput.CheckInitialized(ecBSxmPTHEUAYINFSmJQXSqvyjhB);
			return;
		}
		for (int i = 0; i < lmYplIPHebFJmSBtMVyxcJWAAiKK.Length; i++)
		{
			lmYplIPHebFJmSBtMVyxcJWAAiKK[i].Reset();
		}
	}

	public AxisCalibration GetAxis(int index)
	{
		if (ReInput._id != ecBSxmPTHEUAYINFSmJQXSqvyjhB)
		{
			ReInput.CheckInitialized(ecBSxmPTHEUAYINFSmJQXSqvyjhB);
			return null;
		}
		if (index < 0 || index >= lmYplIPHebFJmSBtMVyxcJWAAiKK.Length)
		{
			return null;
		}
		return RARhIlVjlcqRyMYLTQZiMqQZUjfe.get_Item(index);
	}

	public float GetCalibratedValue(int axisIndex, float value)
	{
		if (ReInput._id != ecBSxmPTHEUAYINFSmJQXSqvyjhB)
		{
			ReInput.CheckInitialized(ecBSxmPTHEUAYINFSmJQXSqvyjhB);
			return 0f;
		}
		if (axisIndex < 0 || axisIndex >= lmYplIPHebFJmSBtMVyxcJWAAiKK.Length)
		{
			return value;
		}
		return RARhIlVjlcqRyMYLTQZiMqQZUjfe.get_Item(axisIndex).GetCalibratedValue(value);
	}

	public bool SetAxisData(int index, AxisCalibrationData data)
	{
		if (ReInput._id != ecBSxmPTHEUAYINFSmJQXSqvyjhB)
		{
			ReInput.CheckInitialized(ecBSxmPTHEUAYINFSmJQXSqvyjhB);
			return false;
		}
		if (index < 0 || index >= lmYplIPHebFJmSBtMVyxcJWAAiKK.Length)
		{
			return false;
		}
		RARhIlVjlcqRyMYLTQZiMqQZUjfe.get_Item(index).SetData(data);
		return true;
	}

	public AxisCalibrationData GetAxisData(int index)
	{
		if (ReInput._id != ecBSxmPTHEUAYINFSmJQXSqvyjhB)
		{
			ReInput.CheckInitialized(ecBSxmPTHEUAYINFSmJQXSqvyjhB);
			return default;
		}
		if (index < 0 || index >= lmYplIPHebFJmSBtMVyxcJWAAiKK.Length)
		{
			return default;
		}
		return RARhIlVjlcqRyMYLTQZiMqQZUjfe.get_Item(index).GetData();
	}

	internal void CopyFrom(CalibrationMap map, bool copyHardwareDeadzone)
	{
		if (map == null)
		{
			return;
		}
		if (map.lmYplIPHebFJmSBtMVyxcJWAAiKK.Length != lmYplIPHebFJmSBtMVyxcJWAAiKK.Length)
		{
			Logger.LogError("Calibration map data does not match the number of elements in the hardware!");
			return;
		}
		for (int i = 0; i < lmYplIPHebFJmSBtMVyxcJWAAiKK.Length; i++)
		{
			lmYplIPHebFJmSBtMVyxcJWAAiKK[i].CopyFrom(map.lmYplIPHebFJmSBtMVyxcJWAAiKK[i], copyHardwareDeadzone);
		}
	}

	public string ToXmlString()
	{
		if (ReInput._id != ecBSxmPTHEUAYINFSmJQXSqvyjhB)
		{
			ReInput.CheckInitialized(ecBSxmPTHEUAYINFSmJQXSqvyjhB);
			return string.Empty;
		}
		string empty = string.Empty;
		try
		{
			return uPMKTEOiACWexziZvnCKspbgQcuD().ToXmlString(writeDocumentTag: true);
		}
		catch (Exception ex)
		{
			Logger.LogWarning("Error writing CalibrationMap to XML! " + ex.Message);
			return empty;
		}
	}

	public string ToJsonString()
	{
		if (ReInput._id != ecBSxmPTHEUAYINFSmJQXSqvyjhB)
		{
			ReInput.CheckInitialized(ecBSxmPTHEUAYINFSmJQXSqvyjhB);
			return string.Empty;
		}
		try
		{
			return uPMKTEOiACWexziZvnCKspbgQcuD().ToJsonString();
		}
		catch (Exception ex)
		{
			Logger.LogWarning("Error writing CalibrationMap to JSON! " + ex.Message);
		}
		return string.Empty;
	}

	public bool ImportXmlString(string xmlString)
	{
		if (ReInput._id != ecBSxmPTHEUAYINFSmJQXSqvyjhB)
		{
			ReInput.CheckInitialized(ecBSxmPTHEUAYINFSmJQXSqvyjhB);
			return false;
		}
		if (string.IsNullOrEmpty(xmlString))
		{
			return false;
		}
		try
		{
			ceQFpfiXWvZxZjVXZNPzPDRyNrEiA(SerializedObject.FromXml(GetType(), xmlString));
			return true;
		}
		catch (Exception ex)
		{
			Logger.LogWarning("Error creating CalibrationMap from XML! " + ex.Message);
		}
		return false;
	}

	public bool ImportJsonString(string jsonString)
	{
		if (ReInput._id != ecBSxmPTHEUAYINFSmJQXSqvyjhB)
		{
			ReInput.CheckInitialized(ecBSxmPTHEUAYINFSmJQXSqvyjhB);
			return false;
		}
		if (string.IsNullOrEmpty(jsonString))
		{
			return false;
		}
		try
		{
			ceQFpfiXWvZxZjVXZNPzPDRyNrEiA(SerializedObject.FromJson(GetType(), jsonString));
			return true;
		}
		catch (Exception ex)
		{
			Logger.LogWarning("Error creating CalibrationMap from JSON! " + ex.Message);
		}
		return false;
	}

	private SerializedObject uPMKTEOiACWexziZvnCKspbgQcuD()
	{
		SerializedObject serializedObject = new SerializedObject(GetType(), SerializedObject.ObjectType.Object);
		serializedObject.Add("dataVersion", 4, SerializedObject.FieldOptions.ExculdeFromXml);
		serializedObject.xmlInfo = new SerializedObject.XmlInfo();
		serializedObject.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.hDUwNfLYRsDfBMVYhNNeoTRkzGbG
		{
			MutqyAFuCjIZnSTNtUBAVEJnuQVU = "dataVersion",
			TGWZwlpMZfNRNCdsoptLnolSpctw = 4.ToString()
		});
		serializedObject.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.hDUwNfLYRsDfBMVYhNNeoTRkzGbG
		{
			lzZvWcSBFLIaPeQCcDYWrLhMPUfsA = "xmlns",
			MutqyAFuCjIZnSTNtUBAVEJnuQVU = "xsi",
			afJFISBmEARIUnwOMVvxEtRhSwGz = null,
			TGWZwlpMZfNRNCdsoptLnolSpctw = "http://www.w3.org/2001/XMLSchema-instance"
		});
		serializedObject.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.hDUwNfLYRsDfBMVYhNNeoTRkzGbG
		{
			lzZvWcSBFLIaPeQCcDYWrLhMPUfsA = "xsi",
			MutqyAFuCjIZnSTNtUBAVEJnuQVU = "schemaLocation",
			afJFISBmEARIUnwOMVvxEtRhSwGz = null,
			TGWZwlpMZfNRNCdsoptLnolSpctw = string.Format("{0} {1}{2}{3}{4}{5}", "http://guavaman.com/rewired", "http://guavaman.com/schemas/rewired/", "1.3", "/", GetType().Name, ".xsd")
		});
		List<object> list = new List<object>();
		serializedObject.Add("axes", list);
		int num = ((lmYplIPHebFJmSBtMVyxcJWAAiKK != null) ? lmYplIPHebFJmSBtMVyxcJWAAiKK.Length : 0);
		for (int i = 0; i < num; i++)
		{
			if (lmYplIPHebFJmSBtMVyxcJWAAiKK[i] != null)
			{
				list.Add(lmYplIPHebFJmSBtMVyxcJWAAiKK[i].ExportData());
			}
		}
		return serializedObject;
	}

	private void ceQFpfiXWvZxZjVXZNPzPDRyNrEiA(SerializedObject P_0)
	{
		SerializedObject value = null;
		if (!P_0.TryGetDeserializedValueByRef("axes", ref value))
		{
			return;
		}
		int num = MathTools.Min(value.count, lmYplIPHebFJmSBtMVyxcJWAAiKK.Length);
		for (int i = 0; i < num; i++)
		{
			if (value[i].value is SerializedObject && lmYplIPHebFJmSBtMVyxcJWAAiKK[i] != null)
			{
				lmYplIPHebFJmSBtMVyxcJWAAiKK[i].Import((SerializedObject)value[i].value);
			}
		}
	}

	internal Vector2 GetCalibrated2DValue(int xAxisIndex, int yAxisIndex, float valueRawX, float valueRawY, DeadZone2DType deadZoneType, AxisSensitivity2DType sensitivityType)
	{
		return Axis2DCalibration.GetCalibrated2DValue(valueRawX, valueRawY, GetAxis(xAxisIndex), GetAxis(yAxisIndex), deadZoneType, sensitivityType);
	}
}
