using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Rewired.Data.Mapping;
using Rewired.Interfaces;
using Rewired.Internal.Localization;
using Rewired.Utils;
using Rewired.Utils.Classes.Utility;

namespace Rewired;

public class Joystick : ControllerWithAxes
{
	private const int WTSMQVoXMmzUPbcQTnoxYUXUOmsC = 0;

	private const int prXWRrpKKeUDFbtdUsiRIBldaRDA = 1;

	private IInputManagerJoystickPublic vMAAlAbdRHDNCUyPYDeCJXuSWhZN;

	private readonly JoystickType[] bbKIKbLHRnjasGjbibRfmPPGHWMDA;

	private readonly ReadOnlyCollection<JoystickType> NHwZzRGWOJMLCahYpbXvlijRpqkO;

	private readonly bool ejmmDncMmieFwhlBHSXPKmjbXzonA;

	private readonly bool pJBlDgeHBPXHhaoVzVxjGVKBrkiM;

	private readonly bool KhvCmOiwOaANkiTSbcozdWZsBowMB;

	private readonly int fOnYUlKyOLyrIkePkJLqAoypRiip;

	private readonly float[] QZmkJDqAHibmQsuPAHIcHGToLozAb;

	private readonly TimerAbs[] vAbumtfmjyRKKxmxyGxiFoBwDfBUA;

	private readonly int rrQhrYWjpGIczfVkfEHAyyUxahyn;

	private readonly Hat[] zegLkddinuapANSgshzBfarNDkwLA;

	private readonly ReadOnlyCollection<Hat> mtJMWsXwzTHMxePZMwRdoAwefQaD;

	private readonly int xAyJsmwUxxbypZZMRJhseVAiRqXI;

	private readonly DirectionalPad[] LyrqUmfnclHmpbzigGyORStehjyvA;

	private readonly ReadOnlyCollection<DirectionalPad> KEtgMdormzAzJGFuHGIRFFLBPbiJc;

	internal IList<JoystickType> eFhSwsPqIYykkPBvZcmAothTpjqQ => rUQeByfSvBIYUsCfpOuAVzusBzynA();

	public long? systemId
	{
		get
		{
			if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
			{
				ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
				return -1L;
			}
			return vMAAlAbdRHDNCUyPYDeCJXuSWhZN.systemId;
		}
	}

	public int unityId
	{
		get
		{
			if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
			{
				ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
				return -1;
			}
			return vMAAlAbdRHDNCUyPYDeCJXuSWhZN.unityId;
		}
	}

	Guid Controller.deviceInstanceGuid => get_deviceInstanceGuid();

	public bool supportsVibration
	{
		get
		{
			if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
			{
				ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
				return false;
			}
			return ejmmDncMmieFwhlBHSXPKmjbXzonA;
		}
	}

	public float vibrationLeftMotor
	{
		get
		{
			if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
			{
				ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
				return 0f;
			}
			if (!ejmmDncMmieFwhlBHSXPKmjbXzonA)
			{
				return 0f;
			}
			if (base.extension is IControllerVibrator { vibrationMotorCount: >0 } controllerVibrator)
			{
				return controllerVibrator.GetVibration(0);
			}
			if (!pJBlDgeHBPXHhaoVzVxjGVKBrkiM)
			{
				return 0f;
			}
			if (fOnYUlKyOLyrIkePkJLqAoypRiip > 0)
			{
				return QZmkJDqAHibmQsuPAHIcHGToLozAb[0];
			}
			return 0f;
		}
		set
		{
			if (ejmmDncMmieFwhlBHSXPKmjbXzonA)
			{
				value = MathTools.Clamp(value, 0f, 1f);
				if (base.extension is IControllerVibrator { vibrationMotorCount: >0 } controllerVibrator)
				{
					controllerVibrator.SetVibration(0, value);
				}
				else if (pJBlDgeHBPXHhaoVzVxjGVKBrkiM && 0 < fOnYUlKyOLyrIkePkJLqAoypRiip)
				{
					urkgpLmjJbChFUgPvOHAobcBjrax(0, value, 0f, false, true);
				}
			}
		}
	}

	public float vibrationRightMotor
	{
		get
		{
			if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
			{
				ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
				return 0f;
			}
			if (!ejmmDncMmieFwhlBHSXPKmjbXzonA)
			{
				return 0f;
			}
			if (base.extension is IControllerVibrator { vibrationMotorCount: >1 } controllerVibrator)
			{
				return controllerVibrator.GetVibration(1);
			}
			if (!pJBlDgeHBPXHhaoVzVxjGVKBrkiM)
			{
				return 0f;
			}
			if (fOnYUlKyOLyrIkePkJLqAoypRiip > 1)
			{
				return QZmkJDqAHibmQsuPAHIcHGToLozAb[1];
			}
			return 0f;
		}
		set
		{
			if (ejmmDncMmieFwhlBHSXPKmjbXzonA)
			{
				value = MathTools.Clamp(value, 0f, 1f);
				if (base.extension is IControllerVibrator { vibrationMotorCount: >1 } controllerVibrator)
				{
					controllerVibrator.SetVibration(1, value);
				}
				else if (pJBlDgeHBPXHhaoVzVxjGVKBrkiM && 1 < fOnYUlKyOLyrIkePkJLqAoypRiip)
				{
					urkgpLmjJbChFUgPvOHAobcBjrax(1, value, 0f, false, true);
				}
			}
		}
	}

	public int vibrationMotorCount
	{
		get
		{
			if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
			{
				ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
				return 0;
			}
			if (base.extension is IControllerVibrator)
			{
				return (base.extension as IControllerVibrator).vibrationMotorCount;
			}
			return fOnYUlKyOLyrIkePkJLqAoypRiip;
		}
	}

	public int hatCount
	{
		get
		{
			if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
			{
				ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
				return 0;
			}
			return rrQhrYWjpGIczfVkfEHAyyUxahyn;
		}
	}

	public IList<Hat> Hats
	{
		get
		{
			if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
			{
				ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
				return EmptyObjects<Hat>.EmptyReadOnlyIListT;
			}
			return mtJMWsXwzTHMxePZMwRdoAwefQaD;
		}
	}

	public int directionalPadCount
	{
		get
		{
			if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
			{
				ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
				return 0;
			}
			return xAyJsmwUxxbypZZMRJhseVAiRqXI;
		}
	}

	public IList<DirectionalPad> DirectionalPads
	{
		get
		{
			if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
			{
				ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
				return EmptyObjects<DirectionalPad>.EmptyReadOnlyIListT;
			}
			return KEtgMdormzAzJGFuHGIRFFLBPbiJc;
		}
	}

	internal int hKnjKiuAoWQNYFjiBHGccuxbPaEib => tkMDUYSxBMjfChsmavQDxxhWgYlRA();

	internal HardwareControllerMapIdentifier bKmNunZqJaJTqidznXOJOReaJbAI => dkWkceWksRAnFAbRFfHBYhiZMOMbb();

	internal IList<JoystickType> rUQeByfSvBIYUsCfpOuAVzusBzynA()
	{
		if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
		{
			ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
			return EmptyObjects<JoystickType>.EmptyReadOnlyIListT;
		}
		return NHwZzRGWOJMLCahYpbXvlijRpqkO;
	}

	public virtual Guid get_deviceInstanceGuid()
	{
		if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
		{
			ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
			return Guid.Empty;
		}
		return vMAAlAbdRHDNCUyPYDeCJXuSWhZN.persistentGuid;
	}

	internal int tkMDUYSxBMjfChsmavQDxxhWgYlRA()
	{
		return vMAAlAbdRHDNCUyPYDeCJXuSWhZN.inputManagerId;
	}

	internal HardwareControllerMapIdentifier dkWkceWksRAnFAbRFfHBYhiZMOMbb()
	{
		if (aHJMAWzbypGgwCcRCqDEaoqVGwfA == null)
		{
			return default;
		}
		return aHJMAWzbypGgwCcRCqDEaoqVGwfA.hardwareMapIdentifier;
	}

	internal Joystick(BridgedController P_0)
		: this(P_0.sourceJoystick.rewiredId, P_0.inputSource, P_0.sourceJoystick.name, (P_0.hw_isBluetoothDevice && !string.IsNullOrEmpty(P_0.hw_bluetoothDeviceName)) ? P_0.hw_bluetoothDeviceName : P_0.productName, P_0.hardwareIdentifier, P_0.controllerTypeGuid, P_0.axisCount, P_0.buttonCount, P_0.isButtonPressureSensitive, P_0.gameHardwareMap, P_0.controllerExtension, new ControllerDataUpdater(P_0.inputManagerSource, P_0.axisCount, P_0.buttonCount, P_0.unknownControllerHats))
	{
		vMAAlAbdRHDNCUyPYDeCJXuSWhZN = P_0.sourceJoystick;
		LOlfEcDQeqYgremiHvntwLzDYOuvA(vMAAlAbdRHDNCUyPYDeCJXuSWhZN as ITryGetLocalizedName);
		ejmmDncMmieFwhlBHSXPKmjbXzonA = P_0.hw_supportsVibration;
		KhvCmOiwOaANkiTSbcozdWZsBowMB = P_0.hw_supportsVoice;
		fOnYUlKyOLyrIkePkJLqAoypRiip = ((!(P_0.controllerExtension is IControllerVibrator)) ? P_0.hw_localVibrationMotorCount : 0);
		if (ejmmDncMmieFwhlBHSXPKmjbXzonA && fOnYUlKyOLyrIkePkJLqAoypRiip > 0)
		{
			QZmkJDqAHibmQsuPAHIcHGToLozAb = new float[fOnYUlKyOLyrIkePkJLqAoypRiip];
			vAbumtfmjyRKKxmxyGxiFoBwDfBUA = new TimerAbs[fOnYUlKyOLyrIkePkJLqAoypRiip];
			ArrayTools.Populate(vAbumtfmjyRKKxmxyGxiFoBwDfBUA, 0, fOnYUlKyOLyrIkePkJLqAoypRiip);
			pJBlDgeHBPXHhaoVzVxjGVKBrkiM = true;
		}
		if (TlKwqXsIXURetJtusBGjLpbJxFcf != Guid.Empty)
		{
			IList<iaIUVVeHlIHTbKHbIuOgJotHxcqD> list = ReInput.pFqEuDuQTUHBlUazWTWXPbWylRbu(TlKwqXsIXURetJtusBGjLpbJxFcf);
			if (list != null)
			{
				List<IControllerTemplate> list2 = null;
				for (int i = 0; i < list.Count; i++)
				{
					iaIUVVeHlIHTbKHbIuOgJotHxcqD iaIUVVeHlIHTbKHbIuOgJotHxcqD2 = list[i];
					if (iaIUVVeHlIHTbKHbIuOgJotHxcqD2 == null)
					{
						continue;
					}
					IControllerTemplate controllerTemplate;
					try
					{
						controllerTemplate = UnityTools.externalTools.CreateControllerTemplate(iaIUVVeHlIHTbKHbIuOgJotHxcqD2.VmVQWcbrYhIXbgEtaxgfwAgaIMbkA(), new ControllerTemplate.sMQxzzTcyzGuaGuucQpiGSFNjmqib(this, iaIUVVeHlIHTbKHbIuOgJotHxcqD2));
						if (controllerTemplate == null)
						{
							throw new Exception("Controller Template for guid " + iaIUVVeHlIHTbKHbIuOgJotHxcqD2.VmVQWcbrYhIXbgEtaxgfwAgaIMbkA().ToString() + " was not found. If you are using custom Controller Templates, did you export the Controller Templates from the Controller Data Files inspector?");
						}
					}
					catch (Exception ex)
					{
						Logger.LogErrorEditor(ex.Message);
						continue;
					}
					if (list2 == null)
					{
						list2 = new List<IControllerTemplate>();
					}
					list2.Add(controllerTemplate);
				}
				if (list2 != null)
				{
					kPsuEDTOdXpQsCoZbbbDeQRSETxeA(list2.ToArray());
				}
			}
		}
		EMBHjcsxjUDMCsHethyxgQTJtbEg();
	}

	private Joystick(int P_0, InputSource P_1, string P_2, string P_3, string P_4, Guid P_5, int P_6, int P_7, bool[] P_8, HardwareControllerMap_Game P_9, Extension P_10, ControllerDataUpdater P_11)
		: base(P_0, P_1, P_2, P_3, P_4, ControllerType.Joystick, P_5, P_6, P_7, P_8, P_9, P_10, P_11)
	{
		if (P_9 == null || P_9.joystickTypes == null || P_9.joystickTypes.Length == 0)
		{
			bbKIKbLHRnjasGjbibRfmPPGHWMDA = new JoystickType[1];
		}
		else
		{
			bbKIKbLHRnjasGjbibRfmPPGHWMDA = P_9.joystickTypes;
		}
		NHwZzRGWOJMLCahYpbXvlijRpqkO = new ReadOnlyCollection<JoystickType>(bbKIKbLHRnjasGjbibRfmPPGHWMDA);
		rrQhrYWjpGIczfVkfEHAyyUxahyn = P_9.hatCount;
		zegLkddinuapANSgshzBfarNDkwLA = new Hat[rrQhrYWjpGIczfVkfEHAyyUxahyn];
		for (int i = 0; i < rrQhrYWjpGIczfVkfEHAyyUxahyn; i++)
		{
			HardwareJoystickMap.CompoundElement hatData = P_9.GetHatData(i);
			try
			{
				if (hatData == null)
				{
					Logger.LogError("Error creating Hat from hardware map! CompoundElement is null!");
					zegLkddinuapANSgshzBfarNDkwLA[i] = new Hat(this, hatData.elementIdentifier, "Hat " + i, new Button[0], new int[0]);
					continue;
				}
				List<Button> list = new List<Button>();
				List<int> list2 = new List<int>();
				for (int j = 0; j < hatData.elementCount; j++)
				{
					int componentElementIdentifierId = hatData.GetComponentElementIdentifierId(j);
					if (!ArrayTools.Contains(P_9.buttonElementIdentifierIds, componentElementIdentifierId))
					{
						list.Add(null);
						list2.Add(-1);
						continue;
					}
					int buttonIndex = P_9.GetButtonIndex(componentElementIdentifierId);
					if (buttonIndex < 0)
					{
						list.Add(null);
						list2.Add(-1);
					}
					else
					{
						list.Add(buttons[buttonIndex]);
						list2.Add(buttonIndex);
					}
				}
				try
				{
					zegLkddinuapANSgshzBfarNDkwLA[i] = new Hat(this, hatData.elementIdentifier, "Hat " + i, list.ToArray(), list2.ToArray());
				}
				catch
				{
					Logger.LogError("Error creating Hat from hardware map! Exception thrown when creating Hat.");
					zegLkddinuapANSgshzBfarNDkwLA[i] = new Hat(this, hatData.elementIdentifier, "Hat " + i, new Button[0], new int[0]);
				}
			}
			finally
			{
				SYaLjMzEtoNlbrCmTQhhELphwWfk(zegLkddinuapANSgshzBfarNDkwLA[i]);
			}
		}
		mtJMWsXwzTHMxePZMwRdoAwefQaD = new ReadOnlyCollection<Hat>(zegLkddinuapANSgshzBfarNDkwLA);
		xAyJsmwUxxbypZZMRJhseVAiRqXI = P_9.dpadCount;
		LyrqUmfnclHmpbzigGyORStehjyvA = new DirectionalPad[xAyJsmwUxxbypZZMRJhseVAiRqXI];
		for (int k = 0; k < xAyJsmwUxxbypZZMRJhseVAiRqXI; k++)
		{
			HardwareJoystickMap.CompoundElement dPadData = P_9.GetDPadData(k);
			try
			{
				if (dPadData == null)
				{
					Logger.LogError("Error creating D-Pad from hardware map! CompoundElement is null!");
					LyrqUmfnclHmpbzigGyORStehjyvA[k] = new DirectionalPad(this, dPadData.elementIdentifier, "D-Pad " + k, new Button[0], new int[0]);
					continue;
				}
				List<Button> list3 = new List<Button>();
				List<int> list4 = new List<int>();
				for (int l = 0; l < dPadData.elementCount; l++)
				{
					int componentElementIdentifierId2 = dPadData.GetComponentElementIdentifierId(l);
					if (!ArrayTools.Contains(P_9.buttonElementIdentifierIds, componentElementIdentifierId2))
					{
						list3.Add(null);
						list4.Add(-1);
						continue;
					}
					int buttonIndex2 = P_9.GetButtonIndex(componentElementIdentifierId2);
					if (buttonIndex2 < 0)
					{
						list3.Add(null);
						list4.Add(-1);
					}
					else
					{
						list3.Add(buttons[buttonIndex2]);
						list4.Add(buttonIndex2);
					}
				}
				try
				{
					LyrqUmfnclHmpbzigGyORStehjyvA[k] = new DirectionalPad(this, dPadData.elementIdentifier, "D-Pad " + k, list3.ToArray(), list4.ToArray());
				}
				catch
				{
					Logger.LogError("Error creating D-Pad from hardware map! Exception thrown when creating D-Pad.");
					LyrqUmfnclHmpbzigGyORStehjyvA[k] = new DirectionalPad(this, dPadData.elementIdentifier, "D-Pad " + k, new Button[0], new int[0]);
				}
			}
			finally
			{
				SYaLjMzEtoNlbrCmTQhhELphwWfk(LyrqUmfnclHmpbzigGyORStehjyvA[k]);
			}
		}
		KEtgMdormzAzJGFuHGIRFFLBPbiJc = new ReadOnlyCollection<DirectionalPad>(LyrqUmfnclHmpbzigGyORStehjyvA);
	}

	internal bool lJxScuwXbEWBbvBrYgCzegNaqEbHA(JoystickType P_0)
	{
		if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
		{
			ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
			return false;
		}
		int num = bbKIKbLHRnjasGjbibRfmPPGHWMDA.Length;
		for (int i = 0; i < num; i++)
		{
			if (bbKIKbLHRnjasGjbibRfmPPGHWMDA[i] == P_0)
			{
				return true;
			}
		}
		return false;
	}

	public JoystickCalibrationMapSaveData GetCalibrationMapSaveData()
	{
		if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
		{
			ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
			return null;
		}
		return new JoystickCalibrationMapSaveData(base.calibrationMap, _type, _hardwareIdentifier, base.hardwareTypeGuid);
	}

	public void SetVibration(float leftMotorLevel, float rightMotorLevel)
	{
		if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
		{
			ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
		}
		else
		{
			SetVibration(leftMotorLevel, rightMotorLevel, 0f, 0f);
		}
	}

	public void SetVibration(float leftMotorLevel, float rightMotorLevel, float leftMotorDuration, float rightMotorDuration)
	{
		if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
		{
			ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
		}
		else
		{
			if (!ejmmDncMmieFwhlBHSXPKmjbXzonA)
			{
				return;
			}
			if (base.extension is IControllerVibrator { vibrationMotorCount: var num } controllerVibrator)
			{
				if (num > 0)
				{
					controllerVibrator.SetVibration(0, leftMotorLevel, leftMotorDuration);
				}
				if (num > 1)
				{
					controllerVibrator.SetVibration(1, rightMotorLevel, rightMotorDuration);
				}
			}
			if (pJBlDgeHBPXHhaoVzVxjGVKBrkiM)
			{
				if (fOnYUlKyOLyrIkePkJLqAoypRiip > 0)
				{
					urkgpLmjJbChFUgPvOHAobcBjrax(0, leftMotorLevel, leftMotorDuration, false, false);
				}
				if (fOnYUlKyOLyrIkePkJLqAoypRiip > 1)
				{
					urkgpLmjJbChFUgPvOHAobcBjrax(1, rightMotorLevel, rightMotorDuration, false, false);
				}
				YAZBavYBsEQVamypZgrgRVetRKdj();
			}
		}
	}

	public void SetVibration(int motorIndex, float motorLevel)
	{
		SetVibration(motorIndex, motorLevel, 0f, stopOtherMotors: false);
	}

	public void SetVibration(int motorIndex, float motorLevel, float duration)
	{
		SetVibration(motorIndex, motorLevel, duration, stopOtherMotors: false);
	}

	public void SetVibration(int motorIndex, float motorLevel, bool stopOtherMotors)
	{
		SetVibration(motorIndex, motorLevel, 0f, stopOtherMotors);
	}

	public void SetVibration(int motorIndex, float motorLevel, float duration, bool stopOtherMotors)
	{
		if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
		{
			ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
		}
		else if (ejmmDncMmieFwhlBHSXPKmjbXzonA && motorIndex >= 0)
		{
			if (base.extension is IControllerVibrator controllerVibrator)
			{
				controllerVibrator.SetVibration(motorIndex, motorLevel, duration, stopOtherMotors);
			}
			if (pJBlDgeHBPXHhaoVzVxjGVKBrkiM && motorIndex < fOnYUlKyOLyrIkePkJLqAoypRiip)
			{
				urkgpLmjJbChFUgPvOHAobcBjrax(motorIndex, motorLevel, duration, stopOtherMotors, true);
			}
		}
	}

	public float GetVibration(int motorIndex)
	{
		if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
		{
			ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
			return 0f;
		}
		if (!ejmmDncMmieFwhlBHSXPKmjbXzonA || motorIndex < 0)
		{
			return 0f;
		}
		if (base.extension is IControllerVibrator controllerVibrator && motorIndex < controllerVibrator.vibrationMotorCount)
		{
			return controllerVibrator.GetVibration(motorIndex);
		}
		if (!pJBlDgeHBPXHhaoVzVxjGVKBrkiM)
		{
			return 0f;
		}
		if (motorIndex >= fOnYUlKyOLyrIkePkJLqAoypRiip)
		{
			return 0f;
		}
		return QZmkJDqAHibmQsuPAHIcHGToLozAb[motorIndex];
	}

	public void StopVibration()
	{
		if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
		{
			ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
		}
		else
		{
			if (!ejmmDncMmieFwhlBHSXPKmjbXzonA)
			{
				return;
			}
			if (base.extension is IControllerVibrator controllerVibrator)
			{
				controllerVibrator.StopVibration();
			}
			if (pJBlDgeHBPXHhaoVzVxjGVKBrkiM)
			{
				Array.Clear(QZmkJDqAHibmQsuPAHIcHGToLozAb, 0, QZmkJDqAHibmQsuPAHIcHGToLozAb.Length);
				for (int i = 0; i < fOnYUlKyOLyrIkePkJLqAoypRiip; i++)
				{
					vAbumtfmjyRKKxmxyGxiFoBwDfBUA[i].Clear();
				}
			}
			if (vMAAlAbdRHDNCUyPYDeCJXuSWhZN != null)
			{
				vMAAlAbdRHDNCUyPYDeCJXuSWhZN.StopVibration();
			}
		}
	}

	internal virtual void kukTquwyDntMnqImMpqZLalwcsMiA(UpdateLoopType P_0)
	{
		biQoETeEqDdqkhVmbcHhOaDmWZxfA(P_0);
		for (int i = 0; i < rrQhrYWjpGIczfVkfEHAyyUxahyn; i++)
		{
			if (zegLkddinuapANSgshzBfarNDkwLA[i] != null)
			{
				zegLkddinuapANSgshzBfarNDkwLA[i].bsKPoFpSwgQrfiowLlnCxLxfzgqp(P_0, KRqNAliDQUoGilZWSpebheoTCzwBA);
			}
		}
		for (int j = 0; j < xAyJsmwUxxbypZZMRJhseVAiRqXI; j++)
		{
			if (LyrqUmfnclHmpbzigGyORStehjyvA[j] != null)
			{
				LyrqUmfnclHmpbzigGyORStehjyvA[j].FwoJacfSTKFrUHEOmJrIENlHpzYZB(P_0, KRqNAliDQUoGilZWSpebheoTCzwBA);
			}
		}
		DjOSZKELYCDFOialFyDHJuMZeJUU();
	}

	internal void kiuZSNAruXRwuGThZtaieGgLiusl(UpdateControllerInfoEventArgs P_0)
	{
		if (P_0 != null)
		{
			SDWuNFNoscoZUyViCLxHCDXPzZwr(P_0.sourceJoystick);
		}
	}

	internal void nqNMzVmolTElXvFKtbhndBoUXqYw(BridgedController P_0)
	{
		if (P_0 != null)
		{
			SDWuNFNoscoZUyViCLxHCDXPzZwr(P_0.sourceJoystick);
		}
	}

	private void SDWuNFNoscoZUyViCLxHCDXPzZwr(IInputManagerJoystickPublic P_0)
	{
		vMAAlAbdRHDNCUyPYDeCJXuSWhZN = P_0;
		LOlfEcDQeqYgremiHvntwLzDYOuvA(P_0 as ITryGetLocalizedName);
		if (P_0 != null)
		{
			if (base.extension != null)
			{
				qAPMEdjfBFkaOEGDfbMJJUmTakQgb(P_0.extension);
			}
			else
			{
				yxBmXDsLSAcsJJQBkbrHicXGYnNt(P_0.extension);
			}
			if (P_0.name != string.Empty)
			{
				_name = P_0.name;
			}
		}
	}

	internal virtual void cbnDKGGGRFRbUjVaLiyAZOvvYUtrA()
	{
		HZEaHvyGlMIsZbNXPCzRBwmikPyR();
		StopVibration();
	}

	internal virtual void eSqsZsDfIomqgzLuqNBsweSWsPex(bool P_0)
	{
		base.XhWByFCKCpNTbgLDhmyYiIbaeaetb(P_0);
		if (!P_0 && !ReInput.applicationRunInBackground)
		{
			StopVibration();
		}
	}

	protected override void Disconnected()
	{
		base.Disconnected();
		if (pJBlDgeHBPXHhaoVzVxjGVKBrkiM)
		{
			Array.Clear(QZmkJDqAHibmQsuPAHIcHGToLozAb, 0, QZmkJDqAHibmQsuPAHIcHGToLozAb.Length);
			for (int i = 0; i < fOnYUlKyOLyrIkePkJLqAoypRiip; i++)
			{
				vAbumtfmjyRKKxmxyGxiFoBwDfBUA[i].Clear();
			}
		}
		if (base.extension is IControllerVibrator controllerVibrator)
		{
			controllerVibrator.StopVibration();
		}
	}

	private void DjOSZKELYCDFOialFyDHJuMZeJUU()
	{
		if (!ejmmDncMmieFwhlBHSXPKmjbXzonA || !pJBlDgeHBPXHhaoVzVxjGVKBrkiM)
		{
			return;
		}
		for (int i = 0; i < fOnYUlKyOLyrIkePkJLqAoypRiip; i++)
		{
			if (vAbumtfmjyRKKxmxyGxiFoBwDfBUA[i].Update())
			{
				SetVibration(i, 0f, stopOtherMotors: false);
			}
		}
	}

	private void urkgpLmjJbChFUgPvOHAobcBjrax(int P_0, float P_1, float P_2, bool P_3, bool P_4)
	{
		if (!pJBlDgeHBPXHhaoVzVxjGVKBrkiM || P_0 < 0 || P_0 >= fOnYUlKyOLyrIkePkJLqAoypRiip)
		{
			return;
		}
		if (P_3)
		{
			Array.Clear(QZmkJDqAHibmQsuPAHIcHGToLozAb, 0, QZmkJDqAHibmQsuPAHIcHGToLozAb.Length);
			for (int i = 0; i < fOnYUlKyOLyrIkePkJLqAoypRiip; i++)
			{
				vAbumtfmjyRKKxmxyGxiFoBwDfBUA[i].Clear();
			}
		}
		QZmkJDqAHibmQsuPAHIcHGToLozAb[P_0] = MathTools.Clamp01(P_1);
		if (P_1 <= 0f || P_2 <= 0f)
		{
			vAbumtfmjyRKKxmxyGxiFoBwDfBUA[P_0].Clear();
		}
		else
		{
			vAbumtfmjyRKKxmxyGxiFoBwDfBUA[P_0].Start(P_2);
		}
		if (P_4)
		{
			YAZBavYBsEQVamypZgrgRVetRKdj();
		}
	}

	private void YAZBavYBsEQVamypZgrgRVetRKdj()
	{
		if (ejmmDncMmieFwhlBHSXPKmjbXzonA && pJBlDgeHBPXHhaoVzVxjGVKBrkiM && vMAAlAbdRHDNCUyPYDeCJXuSWhZN != null)
		{
			for (int i = 0; i < QZmkJDqAHibmQsuPAHIcHGToLozAb.Length; i++)
			{
				vMAAlAbdRHDNCUyPYDeCJXuSWhZN.SetVibration(QZmkJDqAHibmQsuPAHIcHGToLozAb[i], i);
			}
		}
	}

	private void qWfaKRxmHHpadHjhuNDMasFPLozQ()
	{
	}

	internal static int EnnYlDQzdjWlCbYxmGgHVeCFesJfA(Joystick P_0, Joystick P_1)
	{
		if (P_0.tkMDUYSxBMjfChsmavQDxxhWgYlRA() < P_1.tkMDUYSxBMjfChsmavQDxxhWgYlRA())
		{
			return -1;
		}
		if (P_0.tkMDUYSxBMjfChsmavQDxxhWgYlRA() > P_1.tkMDUYSxBMjfChsmavQDxxhWgYlRA())
		{
			return 1;
		}
		return 0;
	}
}
