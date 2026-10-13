using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using Rewired;
using Rewired.Config;
using Rewired.Data.Mapping;
using Rewired.Interfaces;
using Rewired.Internal.Localization;
using Rewired.Platforms;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using Rewired.Utils.Classes.Utility;
using UnityEngine;

internal class JRJujyYkIYDcAFcIVJVNsJrvvVWuA : PlatformInputManager
{
	private class AwgAczyGvVFuzTgezjEEuVtNBwtk : IInputManagerJoystick, IInputManagerJoystickPublic
	{
		private int KXJwuSHzwkdvSfPfaqvpNiJObOdFA;

		private int XyCDfaOGEoVKrztRuzsQwTBnQdqI;

		private int BplzXnBIDmCIEjghVOGJzoBsfnLT;

		public Guid xheGVkOtrrwrQjePqbkBnjhrcPhW;

		public string fcpTRCMFluAlCICeguNnuTvMKvNgb;

		public int BjmitrWbYlSzJLLjYTiCEnFLsIdr;

		public string dQccWzEhskovHYFNqNcrGlnQdMQtA;

		public string ddzzvVWlStVlWMekgGJgfNxzZNtvA;

		private int RJntDEgSnEmVAmtPGPleAAWHKNdW = 29;

		private int AWxeSiFleOKkEwkmeKhfmCCiMnypA = 20;

		private float[] FNlwQjEegCnKmTFwKAHruOrXDTTZ;

		private bool[] AtSySfnsGgCCnADdomnZzejpnHQg;

		private bool[] CLNYwAeCAdMBOaQQEfOAKhpUkntMA;

		private float[] LRBAQEjjHjuMBePfKcbOMfSdHsetA;

		private bool[] QkHBSimnKldsHSGJLjJLYLQVdFbgA;

		private HardwareJoystickMap_InputManager AZyEHWzeXLDzNQgjvdSLKlHcstGgA;

		private bool EBtjskGYnqOeOJKiOTPUpbaWlhteA;

		[CustomObfuscation(rename = false)]
		int IInputManagerJoystickPublic.rewiredId
		{
			get
			{
				return get_rewiredId();
			}
			set
			{
				set_rewiredId(value);
			}
		}

		[CustomObfuscation(rename = false)]
		int IInputManagerJoystickPublic.inputManagerId
		{
			get
			{
				return get_inputManagerId();
			}
			set
			{
				set_inputManagerId(value);
			}
		}

		[CustomObfuscation(rename = false)]
		string IInputManagerJoystickPublic.name => get_name();

		[CustomObfuscation(rename = false)]
		long? IInputManagerJoystickPublic.systemId => get_systemId();

		[CustomObfuscation(rename = false)]
		int IInputManagerJoystickPublic.unityId
		{
			get
			{
				return get_unityId();
			}
			set
			{
				set_unityId(value);
			}
		}

		[CustomObfuscation(rename = false)]
		Guid IInputManagerJoystickPublic.instanceGuid => get_instanceGuid();

		[CustomObfuscation(rename = false)]
		Guid IInputManagerJoystickPublic.persistentGuid => get_persistentGuid();

		[CustomObfuscation(rename = false)]
		Controller.Extension IInputManagerJoystickPublic.extension => get_extension();

		public int get_rewiredId()
		{
			return KXJwuSHzwkdvSfPfaqvpNiJObOdFA;
		}

		public void set_rewiredId(int value)
		{
			KXJwuSHzwkdvSfPfaqvpNiJObOdFA = value;
		}

		public int get_inputManagerId()
		{
			return XyCDfaOGEoVKrztRuzsQwTBnQdqI;
		}

		public void set_inputManagerId(int value)
		{
			XyCDfaOGEoVKrztRuzsQwTBnQdqI = value;
		}

		public string get_name()
		{
			if (!(fcpTRCMFluAlCICeguNnuTvMKvNgb != "Unknown Controller"))
			{
				return dQccWzEhskovHYFNqNcrGlnQdMQtA;
			}
			return fcpTRCMFluAlCICeguNnuTvMKvNgb;
		}

		public long? get_systemId()
		{
			if (BplzXnBIDmCIEjghVOGJzoBsfnLT < 1)
			{
				return null;
			}
			return BplzXnBIDmCIEjghVOGJzoBsfnLT;
		}

		public int get_unityId()
		{
			return BplzXnBIDmCIEjghVOGJzoBsfnLT;
		}

		public void set_unityId(int value)
		{
			BplzXnBIDmCIEjghVOGJzoBsfnLT = value;
		}

		public Guid get_instanceGuid()
		{
			if ((ReInput.isWindowsStandaloneWebplayerOrEditorPlatform && !UnityTools.windowsJoystickNamesReturnsEmptyStringsIfJoystickNull) || UnityTools.effectivePlatform == Platform.OSX)
			{
				return MiscTools.CreateGuidHashSHA1(get_name());
			}
			if (UnityTools.isIOSPlatform)
			{
				return MiscTools.CreateGuidHashSHA1(dQccWzEhskovHYFNqNcrGlnQdMQtA);
			}
			return MiscTools.CreateGuidHashSHA1(get_name() + "_" + BplzXnBIDmCIEjghVOGJzoBsfnLT);
		}

		public Guid get_persistentGuid()
		{
			return get_instanceGuid();
		}

		public Controller.Extension get_extension()
		{
			return null;
		}

		[CustomObfuscation(rename = false)]
		public void SetVibration(float amount, int motorIndex)
		{
		}

		void IInputManagerJoystickPublic.SetVibration(float amount, int motorIndex)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetVibration
			this.SetVibration(amount, motorIndex);
		}

		[CustomObfuscation(rename = false)]
		public void StopVibration()
		{
		}

		void IInputManagerJoystickPublic.StopVibration()
		{
			//ILSpy generated this explicit interface implementation from .override directive in StopVibration
			this.StopVibration();
		}

		public AwgAczyGvVFuzTgezjEEuVtNBwtk()
		{
			XyCDfaOGEoVKrztRuzsQwTBnQdqI = -1;
			KXJwuSHzwkdvSfPfaqvpNiJObOdFA = -1;
			BplzXnBIDmCIEjghVOGJzoBsfnLT = 0;
		}

		public void ozhbQRNBLubsaJQaZyDjVVtgRsBe()
		{
			UdglXvdtaTmXHiILHloaYyiQpRPS();
			xheGVkOtrrwrQjePqbkBnjhrcPhW = AZyEHWzeXLDzNQgjvdSLKlHcstGgA.hardwareMapIdentifier.guid;
			fcpTRCMFluAlCICeguNnuTvMKvNgb = AZyEHWzeXLDzNQgjvdSLKlHcstGgA.controllerName;
			FNlwQjEegCnKmTFwKAHruOrXDTTZ = new float[RJntDEgSnEmVAmtPGPleAAWHKNdW];
			AtSySfnsGgCCnADdomnZzejpnHQg = new bool[AWxeSiFleOKkEwkmeKhfmCCiMnypA];
			CLNYwAeCAdMBOaQQEfOAKhpUkntMA = new bool[RJntDEgSnEmVAmtPGPleAAWHKNdW];
			QkHBSimnKldsHSGJLjJLYLQVdFbgA = new bool[29];
			LRBAQEjjHjuMBePfKcbOMfSdHsetA = new float[29];
			Update();
		}

		[CustomObfuscation(rename = false)]
		public void Update()
		{
			if (BplzXnBIDmCIEjghVOGJzoBsfnLT > 0)
			{
				cSbqtdApIRvgAZyQljILZwqdkKJr();
				oQgqwkSGBzJGnSTSLsQYBwvdQdOX();
				cBPwOIsGlOBxHnheIhsDlfXxtLDv();
			}
		}

		void IInputManagerJoystick.Update()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Update
			this.Update();
		}

		public int jfbaSwisAOqRlgnYFlAMTZiSRFlMA(AwgAczyGvVFuzTgezjEEuVtNBwtk P_0)
		{
			if ((!string.IsNullOrEmpty(ddzzvVWlStVlWMekgGJgfNxzZNtvA) || !string.IsNullOrEmpty(P_0.ddzzvVWlStVlWMekgGJgfNxzZNtvA)) && !string.Equals(ddzzvVWlStVlWMekgGJgfNxzZNtvA, P_0.ddzzvVWlStVlWMekgGJgfNxzZNtvA, StringComparison.Ordinal))
			{
				return 0;
			}
			if (P_0.dQccWzEhskovHYFNqNcrGlnQdMQtA == dQccWzEhskovHYFNqNcrGlnQdMQtA && P_0.BjmitrWbYlSzJLLjYTiCEnFLsIdr == BjmitrWbYlSzJLLjYTiCEnFLsIdr)
			{
				return 2;
			}
			if (P_0.dQccWzEhskovHYFNqNcrGlnQdMQtA == dQccWzEhskovHYFNqNcrGlnQdMQtA)
			{
				return 1;
			}
			return 0;
		}

		private void IMkSUDfDhiBJNfpnDxjusgXoFXtXA(BridgedControllerHWInfo P_0)
		{
			P_0.inputManagerSource = InputSource.Fallback;
			P_0.inputSource = fVLEObXelZypttVuPKYAvnFlahJq();
			P_0.hardwareIdentifier = hLhhAcJNwuejtgfmDkEPAelGPiiK();
			P_0.hardwareAxisCount = 0;
			P_0.hardwareButtonCount = 0;
			P_0.hardwareHatCount = 0;
			P_0.hw_productName = dQccWzEhskovHYFNqNcrGlnQdMQtA;
		}

		private void snrycDObMZkcpjdqiiHnUmfknYQc(BridgedController P_0)
		{
			IMkSUDfDhiBJNfpnDxjusgXoFXtXA(P_0);
			P_0.sourceJoystick = this;
			P_0.gameHardwareMap = AZyEHWzeXLDzNQgjvdSLKlHcstGgA.ToGameHardwareControllerMap();
			P_0.instanceName = dQccWzEhskovHYFNqNcrGlnQdMQtA;
			P_0.productName = dQccWzEhskovHYFNqNcrGlnQdMQtA;
			P_0.isXInputDevice = false;
			P_0.axisCount = RJntDEgSnEmVAmtPGPleAAWHKNdW;
			P_0.buttonCount = AWxeSiFleOKkEwkmeKhfmCCiMnypA;
			P_0.controllerTypeGuid = xheGVkOtrrwrQjePqbkBnjhrcPhW;
		}

		[CustomObfuscation(rename = false)]
		public void FillData(ControllerDataUpdater dataUpdater)
		{
			if (RJntDEgSnEmVAmtPGPleAAWHKNdW != dataUpdater.axisCount || AWxeSiFleOKkEwkmeKhfmCCiMnypA != dataUpdater.buttonCount)
			{
				throw new Exception("This controller signature does not match the data object!");
			}
			float[] axisValues = dataUpdater.axisValues;
			bool[] axisHasBeenPressedOSXLinux = dataUpdater.axisHasBeenPressedOSXLinux;
			for (int i = 0; i < RJntDEgSnEmVAmtPGPleAAWHKNdW; i++)
			{
				if (axisValues[i] != FNlwQjEegCnKmTFwKAHruOrXDTTZ[i])
				{
					axisValues[i] = FNlwQjEegCnKmTFwKAHruOrXDTTZ[i];
					if (axisHasBeenPressedOSXLinux[i] != CLNYwAeCAdMBOaQQEfOAKhpUkntMA[i])
					{
						axisHasBeenPressedOSXLinux[i] = CLNYwAeCAdMBOaQQEfOAKhpUkntMA[i];
					}
				}
			}
			bool[] buttonValues = dataUpdater.buttonValues;
			for (int j = 0; j < AWxeSiFleOKkEwkmeKhfmCCiMnypA; j++)
			{
				if (buttonValues[j] != AtSySfnsGgCCnADdomnZzejpnHQg[j])
				{
					buttonValues[j] = AtSySfnsGgCCnADdomnZzejpnHQg[j];
				}
			}
			if (EBtjskGYnqOeOJKiOTPUpbaWlhteA && !dataUpdater.hasReceivedInput)
			{
				dataUpdater.hasReceivedInput = true;
			}
		}

		void IInputManagerJoystick.FillData(ControllerDataUpdater dataUpdater)
		{
			//ILSpy generated this explicit interface implementation from .override directive in FillData
			this.FillData(dataUpdater);
		}

		public void fCqUiRMhDoCEXXWELEbvFuyQXBnh(int P_0)
		{
			if (P_0 >= 1 && P_0 <= 16)
			{
				set_unityId(P_0);
			}
		}

		public void lJxkCOpGAWTKHNmXIBTqqSkynUxJ()
		{
			BplzXnBIDmCIEjghVOGJzoBsfnLT = 0;
			ZFSmgXDrfZUfphdcAmvCzymbEOLM();
		}

		public BridgedControllerHWInfo dcCvLsFZIrLgmjDLhOWIGtHjGDGX()
		{
			BridgedControllerHWInfo bridgedControllerHWInfo = new BridgedControllerHWInfo();
			IMkSUDfDhiBJNfpnDxjusgXoFXtXA(bridgedControllerHWInfo);
			return bridgedControllerHWInfo;
		}

		[CustomObfuscation(rename = false)]
		public BridgedController ToBridgedController()
		{
			BridgedController bridgedController = new BridgedController();
			snrycDObMZkcpjdqiiHnUmfknYQc(bridgedController);
			return bridgedController;
		}

		BridgedController IInputManagerJoystick.ToBridgedController()
		{
			//ILSpy generated this explicit interface implementation from .override directive in ToBridgedController
			return this.ToBridgedController();
		}

		[CustomObfuscation(rename = false)]
		public ControllerDisconnectedEventArgs ToControllerDisconnectedEventArgs()
		{
			return new ControllerDisconnectedEventArgs(KXJwuSHzwkdvSfPfaqvpNiJObOdFA);
		}

		ControllerDisconnectedEventArgs IInputManagerJoystick.ToControllerDisconnectedEventArgs()
		{
			//ILSpy generated this explicit interface implementation from .override directive in ToControllerDisconnectedEventArgs
			return this.ToControllerDisconnectedEventArgs();
		}

		private void cSbqtdApIRvgAZyQljILZwqdkKJr()
		{
			for (int i = 0; i < 29; i++)
			{
				float joystickAxisValueByJoystickId = UnityInputHelper.GetJoystickAxisValueByJoystickId(BplzXnBIDmCIEjghVOGJzoBsfnLT, i);
				if (LRBAQEjjHjuMBePfKcbOMfSdHsetA[i] != joystickAxisValueByJoystickId)
				{
					LRBAQEjjHjuMBePfKcbOMfSdHsetA[i] = joystickAxisValueByJoystickId;
					if (!QkHBSimnKldsHSGJLjJLYLQVdFbgA[i] && joystickAxisValueByJoystickId != 0f)
					{
						QkHBSimnKldsHSGJLjJLYLQVdFbgA[i] = true;
					}
				}
			}
		}

		private void oQgqwkSGBzJGnSTSLsQYBwvdQdOX()
		{
			HardwareJoystickMap.Platform_Fallback_Base.Axis[] axes_orig = ((HardwareJoystickMap.Platform_Fallback_Base)AZyEHWzeXLDzNQgjvdSLKlHcstGgA.map).Axes_orig;
			if (axes_orig == null)
			{
				return;
			}
			for (int i = 0; i < axes_orig.Length; i++)
			{
				if (axes_orig[i] == null)
				{
					continue;
				}
				if (i >= RJntDEgSnEmVAmtPGPleAAWHKNdW)
				{
					throw new Exception("Number of axes in hardware map does not match number of axes found in controller!");
				}
				float num = nVqJkoTpiMkawMjqdXkGThtVvEIT(axes_orig[i]);
				if (FNlwQjEegCnKmTFwKAHruOrXDTTZ[i] == num)
				{
					continue;
				}
				FNlwQjEegCnKmTFwKAHruOrXDTTZ[i] = num;
				if (!CLNYwAeCAdMBOaQQEfOAKhpUkntMA[i])
				{
					if (axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Axis)
					{
						float num2 = RUvviOqcKRDstXbcnDGuTWYFYjZy(axes_orig[i].sourceAxis);
						CLNYwAeCAdMBOaQQEfOAKhpUkntMA[i] = num2 != 0f;
					}
					else
					{
						CLNYwAeCAdMBOaQQEfOAKhpUkntMA[i] = true;
					}
				}
				if (!EBtjskGYnqOeOJKiOTPUpbaWlhteA && FNlwQjEegCnKmTFwKAHruOrXDTTZ[i] != 0f)
				{
					EBtjskGYnqOeOJKiOTPUpbaWlhteA = true;
				}
			}
		}

		private void cBPwOIsGlOBxHnheIhsDlfXxtLDv()
		{
			HardwareJoystickMap.Platform_Fallback_Base.Button[] buttons_orig = ((HardwareJoystickMap.Platform_Fallback_Base)AZyEHWzeXLDzNQgjvdSLKlHcstGgA.map).Buttons_orig;
			if (buttons_orig == null)
			{
				return;
			}
			for (int i = 0; i < buttons_orig.Length; i++)
			{
				if (i >= AWxeSiFleOKkEwkmeKhfmCCiMnypA)
				{
					throw new Exception("Number of buttons in hardware map does not match number of buttons found in controller!");
				}
				bool flag = PMSiEKGZQWLbTQdkvjyFhHHUrujJA(buttons_orig[i]);
				if (AtSySfnsGgCCnADdomnZzejpnHQg[i] != flag)
				{
					AtSySfnsGgCCnADdomnZzejpnHQg[i] = flag;
					if (!EBtjskGYnqOeOJKiOTPUpbaWlhteA && AtSySfnsGgCCnADdomnZzejpnHQg[i])
					{
						EBtjskGYnqOeOJKiOTPUpbaWlhteA = true;
					}
				}
			}
		}

		private bool PMSiEKGZQWLbTQdkvjyFhHHUrujJA(HardwareJoystickMap.Platform_Fallback_Base.Button P_0)
		{
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Button)
			{
				if (P_0.ignoreIfButtonsActive)
				{
					for (int i = 0; i < P_0.ignoreIfButtonsActiveButtons.Length; i++)
					{
						if (ENuKFRvMkQgUkFboSZALEdEZVvwS(P_0.ignoreIfButtonsActiveButtons[i]))
						{
							return false;
						}
					}
				}
				if (P_0.requireMultipleButtons)
				{
					bool flag = false;
					for (int j = 0; j < P_0.requiredButtons.Length; j++)
					{
						if (!ENuKFRvMkQgUkFboSZALEdEZVvwS(P_0.requiredButtons[j]))
						{
							return false;
						}
						flag = true;
					}
					if (flag)
					{
						return true;
					}
					return false;
				}
				if (P_0.sourceButton == UnityButton.None)
				{
					return false;
				}
				return ENuKFRvMkQgUkFboSZALEdEZVvwS(P_0.sourceButton);
			}
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Axis)
			{
				if (P_0.sourceAxis == UnityAxis.None)
				{
					return false;
				}
				float num = RUvviOqcKRDstXbcnDGuTWYFYjZy(P_0.sourceAxis);
				if (MathTools.Abs(num) <= P_0.axisDeadZone)
				{
					return false;
				}
				if (P_0.sourceAxisPole == Pole.Positive && num < 0f)
				{
					return false;
				}
				if (P_0.sourceAxisPole == Pole.Negative && num > 0f)
				{
					return false;
				}
				return true;
			}
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Hat)
			{
				if (P_0.unityHat_sourceAxis1 == UnityAxis.None || P_0.unityHat_sourceAxis2 == UnityAxis.None)
				{
					return false;
				}
				UnityAxis unityHat_sourceAxis = P_0.unityHat_sourceAxis1;
				UnityAxis unityHat_sourceAxis2 = P_0.unityHat_sourceAxis2;
				float num2 = RUvviOqcKRDstXbcnDGuTWYFYjZy(unityHat_sourceAxis);
				float num3 = RUvviOqcKRDstXbcnDGuTWYFYjZy(unityHat_sourceAxis2);
				float x;
				float y;
				if (P_0.unityHat_checkNeverPressed)
				{
					if (yNhJAJVGeDYHtOowDgrkqqckPQXT(unityHat_sourceAxis) || yNhJAJVGeDYHtOowDgrkqqckPQXT(unityHat_sourceAxis2))
					{
						x = P_0.unityHat_zeroValues.x;
						y = P_0.unityHat_zeroValues.y;
					}
					else
					{
						x = P_0.unityHat_neverPressedZeroValues.x;
						y = P_0.unityHat_neverPressedZeroValues.y;
					}
				}
				else
				{
					x = P_0.unityHat_zeroValues.x;
					y = P_0.unityHat_zeroValues.y;
				}
				if (MathTools.Approximately(num2, x) && MathTools.Approximately(num3, y))
				{
					return false;
				}
				if (HwpEFtmkygqxWKAlpDoMeHREjELMA(P_0.unityHat_isActiveAxisValues1.x, num2) && HwpEFtmkygqxWKAlpDoMeHREjELMA(P_0.unityHat_isActiveAxisValues1.y, num3))
				{
					return true;
				}
				if (HwpEFtmkygqxWKAlpDoMeHREjELMA(P_0.unityHat_isActiveAxisValues2.x, num2) && HwpEFtmkygqxWKAlpDoMeHREjELMA(P_0.unityHat_isActiveAxisValues2.y, num3))
				{
					return true;
				}
				if (HwpEFtmkygqxWKAlpDoMeHREjELMA(P_0.unityHat_isActiveAxisValues3.x, num2) && HwpEFtmkygqxWKAlpDoMeHREjELMA(P_0.unityHat_isActiveAxisValues3.y, num3))
				{
					return true;
				}
			}
			else
			{
				if (P_0.sourceType == HardwareElementSourceTypeWithHat.Key)
				{
					if (P_0.sourceKeyCode == KeyCode.None)
					{
						return false;
					}
					return Input.GetKey(P_0.sourceKeyCode);
				}
				if (P_0.sourceType == HardwareElementSourceTypeWithHat.Custom)
				{
					CustomCalculation customCalculation = P_0.customCalculation;
					if (customCalculation == null)
					{
						return false;
					}
					if (customCalculation.ResultType != TypeWrapper.DataType.Single)
					{
						return false;
					}
					HardwareJoystickMap.Platform_Fallback_Base.CustomCalculationSourceData[] customCalculationSourceData = P_0.customCalculationSourceData;
					if (customCalculationSourceData == null)
					{
						return false;
					}
					for (int k = 0; k < customCalculationSourceData.Length; k++)
					{
						if (customCalculationSourceData[k] == null)
						{
							continue;
						}
						switch ((HardwareElementSourceTypeWithHat)customCalculationSourceData[k].sourceType)
						{
						case HardwareElementSourceTypeWithHat.Button:
						{
							if (kmXWOAvPARjtegwkXQMeKBeQUCwFA(customCalculationSourceData[k], out var flag3))
							{
								customCalculation.AddData(flag3 ? 1f : 0f);
							}
							break;
						}
						case HardwareElementSourceTypeWithHat.Axis:
						{
							if (ygBeNWdPBnxVWGkxkpLqffEBtxrAc(customCalculationSourceData[k], out var num4))
							{
								customCalculation.AddData((num4 != 0f) ? 1f : 0f);
							}
							break;
						}
						case HardwareElementSourceTypeWithHat.Key:
						{
							if (nMWlwlTIWUdwgOKoEtPHSaJYKEzD(customCalculationSourceData[k], out var flag2))
							{
								customCalculation.AddData(flag2 ? 1f : 0f);
							}
							break;
						}
						}
					}
					if (!customCalculation.Process())
					{
						return false;
					}
					if (customCalculation.Result.type != TypeWrapper.DataType.Single)
					{
						return false;
					}
					return (float)customCalculation.Result != 0f;
				}
			}
			return false;
		}

		private bool HwpEFtmkygqxWKAlpDoMeHREjELMA(float P_0, float P_1)
		{
			return MathTools.IsNear(P_1, P_0, 0.1f);
		}

		private float nVqJkoTpiMkawMjqdXkGThtVvEIT(HardwareJoystickMap.Platform_Fallback_Base.Axis P_0)
		{
			switch (P_0.sourceType)
			{
			case HardwareElementSourceTypeWithHat.Axis:
				if (P_0.sourceAxis == UnityAxis.None)
				{
					return 0f;
				}
				if (!yNhJAJVGeDYHtOowDgrkqqckPQXT(P_0.sourceAxis))
				{
					return 0f;
				}
				return RUvviOqcKRDstXbcnDGuTWYFYjZy(P_0.sourceAxis);
			case HardwareElementSourceTypeWithHat.Button:
				if (P_0.sourceButton == UnityButton.None)
				{
					return 0f;
				}
				if (!ENuKFRvMkQgUkFboSZALEdEZVvwS(P_0.sourceButton))
				{
					return 0f;
				}
				if (P_0.buttonAxisContribution == Pole.Positive)
				{
					return 1f;
				}
				return -1f;
			case HardwareElementSourceTypeWithHat.Key:
				if (P_0.sourceKeyCode == KeyCode.None)
				{
					return 0f;
				}
				if (!Input.GetKey(P_0.sourceKeyCode))
				{
					return 0f;
				}
				if (P_0.buttonAxisContribution == Pole.Positive)
				{
					return 1f;
				}
				return -1f;
			case HardwareElementSourceTypeWithHat.Custom:
			{
				CustomCalculation customCalculation = P_0.customCalculation;
				if (customCalculation == null)
				{
					return 0f;
				}
				if (customCalculation.ResultType != TypeWrapper.DataType.Single)
				{
					return 0f;
				}
				HardwareJoystickMap.Platform_Fallback_Base.CustomCalculationSourceData[] customCalculationSourceData = P_0.customCalculationSourceData;
				if (customCalculationSourceData == null)
				{
					return 0f;
				}
				for (int i = 0; i < customCalculationSourceData.Length; i++)
				{
					if (customCalculationSourceData[i] != null && customCalculationSourceData[i].sourceType == 1 && ygBeNWdPBnxVWGkxkpLqffEBtxrAc(customCalculationSourceData[i], out var item))
					{
						customCalculation.AddData(item);
					}
				}
				if (!customCalculation.Process())
				{
					return 0f;
				}
				if (customCalculation.Result.type != TypeWrapper.DataType.Single)
				{
					return 0f;
				}
				return customCalculation.Result;
			}
			default:
				return 0f;
			}
		}

		private float RUvviOqcKRDstXbcnDGuTWYFYjZy(UnityAxis P_0)
		{
			if (P_0 == UnityAxis.None)
			{
				return 0f;
			}
			int num = (int)(P_0 - 1);
			return LRBAQEjjHjuMBePfKcbOMfSdHsetA[num];
		}

		private bool ENuKFRvMkQgUkFboSZALEdEZVvwS(UnityButton P_0)
		{
			int buttonIndex = (int)(P_0 - 1);
			return UnityInputHelper.GetJoystickButtonValueByJoystickId(BplzXnBIDmCIEjghVOGJzoBsfnLT, buttonIndex);
		}

		private bool kmXWOAvPARjtegwkXQMeKBeQUCwFA(HardwareJoystickMap.Platform_Fallback_Base.CustomCalculationSourceData P_0, out bool P_1)
		{
			P_1 = false;
			if (P_0.sourceType != 0)
			{
				return false;
			}
			UnityButton sourceElement = (UnityButton)P_0.sourceElement;
			if (sourceElement == UnityButton.None)
			{
				return false;
			}
			P_1 = ENuKFRvMkQgUkFboSZALEdEZVvwS(sourceElement);
			return true;
		}

		private bool nMWlwlTIWUdwgOKoEtPHSaJYKEzD(HardwareJoystickMap.Platform_Fallback_Base.CustomCalculationSourceData P_0, out bool P_1)
		{
			P_1 = false;
			if (P_0.sourceType != 3)
			{
				return false;
			}
			KeyCode sourceElement = (KeyCode)P_0.sourceElement;
			if (sourceElement == KeyCode.None)
			{
				return false;
			}
			P_1 = Input.GetKey(sourceElement);
			return true;
		}

		private bool ygBeNWdPBnxVWGkxkpLqffEBtxrAc(HardwareJoystickMap.Platform_Fallback_Base.CustomCalculationSourceData P_0, out float P_1)
		{
			P_1 = 0f;
			if (P_0.sourceType != 1)
			{
				return false;
			}
			UnityAxis sourceElement = (UnityAxis)P_0.sourceElement;
			if (sourceElement == UnityAxis.None)
			{
				return false;
			}
			P_1 = RUvviOqcKRDstXbcnDGuTWYFYjZy(sourceElement);
			switch (P_0.sourceAxisRange)
			{
			case AxisRange.Negative:
				if (P_1 > 0f)
				{
					P_1 = 0f;
				}
				break;
			case AxisRange.Positive:
				if (P_1 < 0f)
				{
					P_1 = 0f;
				}
				break;
			}
			if (P_0.deadzone > 0f && MathTools.Abs(P_1) <= P_0.deadzone)
			{
				P_1 = 0f;
			}
			if (P_0.invert)
			{
				P_1 *= -1f;
			}
			return true;
		}

		private bool yNhJAJVGeDYHtOowDgrkqqckPQXT(UnityAxis P_0)
		{
			int num = (int)(P_0 - 1);
			return QkHBSimnKldsHSGJLjJLYLQVdFbgA[num];
		}

		private void UdglXvdtaTmXHiILHloaYyiQpRPS()
		{
			BridgedControllerHWInfo bridgedControllerHWInfo = dcCvLsFZIrLgmjDLhOWIGtHjGDGX();
			if (UnityTools.isAndroidPlatform)
			{
				if (Regex.IsMatch(dQccWzEhskovHYFNqNcrGlnQdMQtA, "Xbox Wireless Controller.*"))
				{
					UnityTools.externalTools.GetDeviceVIDPIDs(out var vids, out var pids);
					for (int i = 0; i < vids.Count; i++)
					{
						if (vids[i] == 1118 && pids[i] == 736)
						{
							bridgedControllerHWInfo.definitionMatchTag = "[FW1]";
							break;
						}
					}
				}
				else if (UnityTools.GpetOCgSSPLuwAcsoGSqFUWhWNAWA() != null)
				{
					IAndroidFallbackDS4Helper ds4Helper = UnityTools.GpetOCgSSPLuwAcsoGSqFUWhWNAWA().ds4Helper;
					if (ds4Helper != null && ds4Helper.IsDS4(dQccWzEhskovHYFNqNcrGlnQdMQtA))
					{
						if (ds4Helper.IsDS4KeyMapped(BjmitrWbYlSzJLLjYTiCEnFLsIdr))
						{
							bridgedControllerHWInfo.definitionMatchTag = "[KEYMAP]";
						}
						else
						{
							bridgedControllerHWInfo.definitionMatchTag = "[NOKEYMAP]";
						}
					}
				}
			}
			AZyEHWzeXLDzNQgjvdSLKlHcstGgA = ReInput.GetHardwareJoystickMap_InputManager(bridgedControllerHWInfo);
			if (AZyEHWzeXLDzNQgjvdSLKlHcstGgA == null)
			{
				Rewired.Logger.LogError("Default hardware map not found!");
				return;
			}
			if (UnityTools.isIOSPlatform && AZyEHWzeXLDzNQgjvdSLKlHcstGgA.hardwareMapIdentifier.guid == Consts.joystickGuid_appleMFiController)
			{
				string text = DWIjwyPEkhOMWCjsTXrDJOkiUSfk(dQccWzEhskovHYFNqNcrGlnQdMQtA);
				if (!string.IsNullOrEmpty(text))
				{
					AZyEHWzeXLDzNQgjvdSLKlHcstGgA.controllerName = text;
					if (AZyEHWzeXLDzNQgjvdSLKlHcstGgA.deviceLocalizationInfo.parentKeys.get_Count() > 0 && !string.IsNullOrEmpty(AZyEHWzeXLDzNQgjvdSLKlHcstGgA.deviceLocalizationInfo.parentKeys.get_Item(0)))
					{
						AZyEHWzeXLDzNQgjvdSLKlHcstGgA.deviceLocalizationInfo.InsertParentKey(0, LocalizationManager.AppendToKeyAsPath(AZyEHWzeXLDzNQgjvdSLKlHcstGgA.deviceLocalizationInfo.parentKeys.get_Item(0), text));
					}
					AZyEHWzeXLDzNQgjvdSLKlHcstGgA.deviceLocalizationInfo.additionalIdentifyingInformation = text;
				}
			}
			else if (AZyEHWzeXLDzNQgjvdSLKlHcstGgA.useSystemName && !string.IsNullOrEmpty(dQccWzEhskovHYFNqNcrGlnQdMQtA))
			{
				string text2 = Regex.Replace(dQccWzEhskovHYFNqNcrGlnQdMQtA, "\\s+", " ");
				text2 = text2.Trim();
				if (!string.IsNullOrEmpty(text2))
				{
					AZyEHWzeXLDzNQgjvdSLKlHcstGgA.controllerName = text2;
					if (AZyEHWzeXLDzNQgjvdSLKlHcstGgA.deviceLocalizationInfo.parentKeys.get_Count() > 0 && !string.IsNullOrEmpty(AZyEHWzeXLDzNQgjvdSLKlHcstGgA.deviceLocalizationInfo.parentKeys.get_Item(0)))
					{
						AZyEHWzeXLDzNQgjvdSLKlHcstGgA.deviceLocalizationInfo.InsertParentKey(0, LocalizationManager.AppendToKeyAsPath(AZyEHWzeXLDzNQgjvdSLKlHcstGgA.deviceLocalizationInfo.parentKeys.get_Item(0), text2));
					}
					AZyEHWzeXLDzNQgjvdSLKlHcstGgA.deviceLocalizationInfo.additionalIdentifyingInformation = text2;
				}
			}
			RJntDEgSnEmVAmtPGPleAAWHKNdW = AZyEHWzeXLDzNQgjvdSLKlHcstGgA.axisCount;
			AWxeSiFleOKkEwkmeKhfmCCiMnypA = AZyEHWzeXLDzNQgjvdSLKlHcstGgA.buttonCount;
		}

		private void ZFSmgXDrfZUfphdcAmvCzymbEOLM()
		{
			Array.Clear(AtSySfnsGgCCnADdomnZzejpnHQg, 0, AtSySfnsGgCCnADdomnZzejpnHQg.Length);
			Array.Clear(FNlwQjEegCnKmTFwKAHruOrXDTTZ, 0, FNlwQjEegCnKmTFwKAHruOrXDTTZ.Length);
		}

		private string hLhhAcJNwuejtgfmDkEPAelGPiiK()
		{
			if (ReInput.currentPlatform == Platform.Webplayer)
			{
				return InputTools.FormatHardwareIdentifierString($"{ReInput.currentPlatform.ToString()}{ReInput.webplayerPlatform.ToString()}{fVLEObXelZypttVuPKYAvnFlahJq().ToString()}{dQccWzEhskovHYFNqNcrGlnQdMQtA}");
			}
			if (UnityTools.isIOSPlatform)
			{
				string arg = Regex.Replace(dQccWzEhskovHYFNqNcrGlnQdMQtA, "joystick [0-9]+ by ", "");
				return InputTools.FormatHardwareIdentifierString($"{ReInput.currentPlatform.ToString()}{fVLEObXelZypttVuPKYAvnFlahJq().ToString()}{arg}");
			}
			return InputTools.FormatHardwareIdentifierString($"{ReInput.currentPlatform.ToString()}{fVLEObXelZypttVuPKYAvnFlahJq().ToString()}{dQccWzEhskovHYFNqNcrGlnQdMQtA}");
		}

		private InputSource fVLEObXelZypttVuPKYAvnFlahJq()
		{
			if (UnityTools.platform == Platform.Linux && UnityTools.externalTools.LinuxInput_IsJoystickPreconfigured(dQccWzEhskovHYFNqNcrGlnQdMQtA))
			{
				return InputSource.Fallback_PreConfigured;
			}
			return InputSource.Fallback;
		}

		public static int kKaCMkHtzGNmZNZXYWJZRhJmmDxRA(AwgAczyGvVFuzTgezjEEuVtNBwtk P_0, AwgAczyGvVFuzTgezjEEuVtNBwtk P_1)
		{
			if (P_0.get_inputManagerId() < P_1.get_inputManagerId())
			{
				return -1;
			}
			if (P_0.get_inputManagerId() > P_1.get_inputManagerId())
			{
				return 1;
			}
			return 0;
		}

		public static int TbCiuxGgrgWKpSAmgmlxysSZTiyrA(AwgAczyGvVFuzTgezjEEuVtNBwtk P_0, AwgAczyGvVFuzTgezjEEuVtNBwtk P_1)
		{
			if (P_0.get_unityId() < P_1.get_unityId())
			{
				return -1;
			}
			if (P_0.get_unityId() > P_1.get_unityId())
			{
				return 1;
			}
			return 0;
		}

		private static string DWIjwyPEkhOMWCjsTXrDJOkiUSfk(string P_0)
		{
			string input = Regex.Replace(P_0, "\\[.*\\] joystick [0-9]+ by ", "");
			input = Regex.Replace(input, "\\s+", " ");
			if (!string.IsNullOrEmpty(input))
			{
				input = input.Trim();
			}
			return input;
		}
	}

	private class ZanVHMewlqQpKpjRABISALiADycx
	{
		public enum qKmJvgvTctYNqElyVtvMLJbPQCub
		{
			Exact = 0,
			Approximate = 1
		}

		public class iBgGTrgmdHpXTCgVUBJdfxkXemoCA
		{
			public int rSNNRKtNzrlMNKcNnTADSBvNbZNW;

			public int HeVJzdlLdYiIrpbzFxopIxydJmIe;

			public string JCFTRxLcSWbwVAMUQOHohhdKLNVkc;

			public int MjnDGiTNErDPmspZOGRHJTSBhxuSA;

			public string hIOnkxpOLxfOVDJggEebKHBQGUdsA;

			public bool NuwikvHhLNHjIDkflXWqecJmPQsdb(AwgAczyGvVFuzTgezjEEuVtNBwtk P_0, qKmJvgvTctYNqElyVtvMLJbPQCub P_1)
			{
				if (P_0.get_rewiredId() == rSNNRKtNzrlMNKcNnTADSBvNbZNW)
				{
					return true;
				}
				if ((!string.IsNullOrEmpty(hIOnkxpOLxfOVDJggEebKHBQGUdsA) || !string.IsNullOrEmpty(P_0.ddzzvVWlStVlWMekgGJgfNxzZNtvA)) && !string.Equals(hIOnkxpOLxfOVDJggEebKHBQGUdsA, P_0.ddzzvVWlStVlWMekgGJgfNxzZNtvA, StringComparison.Ordinal))
				{
					return false;
				}
				switch (P_1)
				{
				case qKmJvgvTctYNqElyVtvMLJbPQCub.Exact:
					if (HeVJzdlLdYiIrpbzFxopIxydJmIe == P_0.BjmitrWbYlSzJLLjYTiCEnFLsIdr)
					{
						return JCFTRxLcSWbwVAMUQOHohhdKLNVkc == P_0.dQccWzEhskovHYFNqNcrGlnQdMQtA;
					}
					return false;
				case qKmJvgvTctYNqElyVtvMLJbPQCub.Approximate:
					return JCFTRxLcSWbwVAMUQOHohhdKLNVkc == P_0.dQccWzEhskovHYFNqNcrGlnQdMQtA;
				default:
					throw new NotImplementedException();
				}
			}
		}

		private sealed class hiwGFQIjgrCDtGjxsKenJJzOAjrU : IEnumerable<iBgGTrgmdHpXTCgVUBJdfxkXemoCA>, IEnumerable, IEnumerator<iBgGTrgmdHpXTCgVUBJdfxkXemoCA>, IEnumerator, IDisposable
		{
			private int JQZfPkhEuQfNJSOZBGezcfWjtbjPb;

			private iBgGTrgmdHpXTCgVUBJdfxkXemoCA cYnJeHZdnoiDXeCNjpHNQUSuSPij;

			private int PZcgVpwHUNJZWQFZeyneKbhHJyPj;

			public ZanVHMewlqQpKpjRABISALiADycx YMGOMkdKWDCnPDCDynNVjwlqhQpM;

			private AwgAczyGvVFuzTgezjEEuVtNBwtk YBkNIlQjvXptCgzAgspmKZTtTKlK;

			public AwgAczyGvVFuzTgezjEEuVtNBwtk pSHqJWRuRnjtJcwhlorOOgKnfgyc;

			private qKmJvgvTctYNqElyVtvMLJbPQCub lKCslBaFUkFsXjGgqBxOFUTcXGBJA;

			public qKmJvgvTctYNqElyVtvMLJbPQCub aBjxcDIHPmESRBQluhEvHoooPnkVA;

			private int BzHSFLsyECMThICGqPpmbFLNpTuB;

			private int HhQLeFevibLYLsKpLtGtVWzsRMOU;

			iBgGTrgmdHpXTCgVUBJdfxkXemoCA IEnumerator<iBgGTrgmdHpXTCgVUBJdfxkXemoCA>.Current
			{
				[DebuggerHidden]
				get
				{
					return System_002ECollections_002EGeneric_002EIEnumerator_003CRewired_002EFallbackInputManager_002EJoystickRecords_002ERecord_003E_002Eget_Current();
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return cYnJeHZdnoiDXeCNjpHNQUSuSPij;
				}
			}

			[DebuggerHidden]
			public hiwGFQIjgrCDtGjxsKenJJzOAjrU(int P_0)
			{
				JQZfPkhEuQfNJSOZBGezcfWjtbjPb = P_0;
				PZcgVpwHUNJZWQFZeyneKbhHJyPj = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int jQZfPkhEuQfNJSOZBGezcfWjtbjPb = JQZfPkhEuQfNJSOZBGezcfWjtbjPb;
				ZanVHMewlqQpKpjRABISALiADycx yMGOMkdKWDCnPDCDynNVjwlqhQpM = YMGOMkdKWDCnPDCDynNVjwlqhQpM;
				if (jQZfPkhEuQfNJSOZBGezcfWjtbjPb != 0)
				{
					if (jQZfPkhEuQfNJSOZBGezcfWjtbjPb != 1)
					{
						return false;
					}
					JQZfPkhEuQfNJSOZBGezcfWjtbjPb = -1;
					goto IL_0083;
				}
				JQZfPkhEuQfNJSOZBGezcfWjtbjPb = -1;
				BzHSFLsyECMThICGqPpmbFLNpTuB = yMGOMkdKWDCnPDCDynNVjwlqhQpM.BEOCOCkLwxTKlsYGsMEGdwjbrstcA.Count;
				HhQLeFevibLYLsKpLtGtVWzsRMOU = 0;
				goto IL_0093;
				IL_0083:
				HhQLeFevibLYLsKpLtGtVWzsRMOU++;
				goto IL_0093;
				IL_0093:
				if (HhQLeFevibLYLsKpLtGtVWzsRMOU < BzHSFLsyECMThICGqPpmbFLNpTuB)
				{
					if (yMGOMkdKWDCnPDCDynNVjwlqhQpM.BEOCOCkLwxTKlsYGsMEGdwjbrstcA[HhQLeFevibLYLsKpLtGtVWzsRMOU].NuwikvHhLNHjIDkflXWqecJmPQsdb(YBkNIlQjvXptCgzAgspmKZTtTKlK, lKCslBaFUkFsXjGgqBxOFUTcXGBJA))
					{
						cYnJeHZdnoiDXeCNjpHNQUSuSPij = yMGOMkdKWDCnPDCDynNVjwlqhQpM.BEOCOCkLwxTKlsYGsMEGdwjbrstcA[HhQLeFevibLYLsKpLtGtVWzsRMOU];
						JQZfPkhEuQfNJSOZBGezcfWjtbjPb = 1;
						return true;
					}
					goto IL_0083;
				}
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			private iBgGTrgmdHpXTCgVUBJdfxkXemoCA System_002ECollections_002EGeneric_002EIEnumerator_003CRewired_002EFallbackInputManager_002EJoystickRecords_002ERecord_003E_002Eget_Current()
			{
				return cYnJeHZdnoiDXeCNjpHNQUSuSPij;
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
				throw new NotSupportedException();
			}

			[DebuggerHidden]
			IEnumerator<iBgGTrgmdHpXTCgVUBJdfxkXemoCA> IEnumerable<iBgGTrgmdHpXTCgVUBJdfxkXemoCA>.GetEnumerator()
			{
				hiwGFQIjgrCDtGjxsKenJJzOAjrU hiwGFQIjgrCDtGjxsKenJJzOAjrU2;
				if (JQZfPkhEuQfNJSOZBGezcfWjtbjPb == -2 && PZcgVpwHUNJZWQFZeyneKbhHJyPj == Environment.CurrentManagedThreadId)
				{
					JQZfPkhEuQfNJSOZBGezcfWjtbjPb = 0;
					hiwGFQIjgrCDtGjxsKenJJzOAjrU2 = this;
				}
				else
				{
					hiwGFQIjgrCDtGjxsKenJJzOAjrU2 = new hiwGFQIjgrCDtGjxsKenJJzOAjrU(0);
					hiwGFQIjgrCDtGjxsKenJJzOAjrU2.YMGOMkdKWDCnPDCDynNVjwlqhQpM = YMGOMkdKWDCnPDCDynNVjwlqhQpM;
				}
				hiwGFQIjgrCDtGjxsKenJJzOAjrU2.YBkNIlQjvXptCgzAgspmKZTtTKlK = pSHqJWRuRnjtJcwhlorOOgKnfgyc;
				hiwGFQIjgrCDtGjxsKenJJzOAjrU2.lKCslBaFUkFsXjGgqBxOFUTcXGBJA = aBjxcDIHPmESRBQluhEvHoooPnkVA;
				return hiwGFQIjgrCDtGjxsKenJJzOAjrU2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<iBgGTrgmdHpXTCgVUBJdfxkXemoCA>)this).GetEnumerator();
			}
		}

		private List<iBgGTrgmdHpXTCgVUBJdfxkXemoCA> BEOCOCkLwxTKlsYGsMEGdwjbrstcA;

		public int oHxgFKTpjFKCtQnOdddNgaoOuCLRA => JORlkyOqkKLpnWMTdMNUrfOAEAox();

		public ZanVHMewlqQpKpjRABISALiADycx()
		{
			BEOCOCkLwxTKlsYGsMEGdwjbrstcA = new List<iBgGTrgmdHpXTCgVUBJdfxkXemoCA>();
		}

		public int JORlkyOqkKLpnWMTdMNUrfOAEAox()
		{
			return BEOCOCkLwxTKlsYGsMEGdwjbrstcA.Count;
		}

		public void hvmEZTVDOsgcVQZPaOvHDqBVhxsdA(AwgAczyGvVFuzTgezjEEuVtNBwtk P_0)
		{
			if (P_0 == null)
			{
				return;
			}
			int count = BEOCOCkLwxTKlsYGsMEGdwjbrstcA.Count;
			for (int i = 0; i < count; i++)
			{
				if (BEOCOCkLwxTKlsYGsMEGdwjbrstcA[i].NuwikvHhLNHjIDkflXWqecJmPQsdb(P_0, qKmJvgvTctYNqElyVtvMLJbPQCub.Exact))
				{
					BEOCOCkLwxTKlsYGsMEGdwjbrstcA[i].rSNNRKtNzrlMNKcNnTADSBvNbZNW = P_0.get_rewiredId();
					BEOCOCkLwxTKlsYGsMEGdwjbrstcA[i].JCFTRxLcSWbwVAMUQOHohhdKLNVkc = P_0.dQccWzEhskovHYFNqNcrGlnQdMQtA;
					BEOCOCkLwxTKlsYGsMEGdwjbrstcA[i].HeVJzdlLdYiIrpbzFxopIxydJmIe = P_0.BjmitrWbYlSzJLLjYTiCEnFLsIdr;
					BEOCOCkLwxTKlsYGsMEGdwjbrstcA[i].MjnDGiTNErDPmspZOGRHJTSBhxuSA = P_0.get_inputManagerId();
					BEOCOCkLwxTKlsYGsMEGdwjbrstcA[i].hIOnkxpOLxfOVDJggEebKHBQGUdsA = P_0.ddzzvVWlStVlWMekgGJgfNxzZNtvA;
					vQFkKKQIffIQTDAqfJBoGPsVBdTZA(P_0.get_rewiredId(), i);
					return;
				}
			}
			BEOCOCkLwxTKlsYGsMEGdwjbrstcA.Add(new iBgGTrgmdHpXTCgVUBJdfxkXemoCA
			{
				rSNNRKtNzrlMNKcNnTADSBvNbZNW = P_0.get_rewiredId(),
				JCFTRxLcSWbwVAMUQOHohhdKLNVkc = P_0.dQccWzEhskovHYFNqNcrGlnQdMQtA,
				HeVJzdlLdYiIrpbzFxopIxydJmIe = P_0.BjmitrWbYlSzJLLjYTiCEnFLsIdr,
				MjnDGiTNErDPmspZOGRHJTSBhxuSA = P_0.get_inputManagerId(),
				hIOnkxpOLxfOVDJggEebKHBQGUdsA = P_0.ddzzvVWlStVlWMekgGJgfNxzZNtvA
			});
			vQFkKKQIffIQTDAqfJBoGPsVBdTZA(P_0.get_rewiredId(), BEOCOCkLwxTKlsYGsMEGdwjbrstcA.Count - 1);
		}

		public bool vLdylnoeyNOnFRXDVfFsdLaUpeul(AwgAczyGvVFuzTgezjEEuVtNBwtk P_0, qKmJvgvTctYNqElyVtvMLJbPQCub P_1)
		{
			int count = BEOCOCkLwxTKlsYGsMEGdwjbrstcA.Count;
			for (int i = 0; i < count; i++)
			{
				if (BEOCOCkLwxTKlsYGsMEGdwjbrstcA[i].NuwikvHhLNHjIDkflXWqecJmPQsdb(P_0, P_1))
				{
					return true;
				}
			}
			return false;
		}

		[IteratorStateMachine(typeof(hiwGFQIjgrCDtGjxsKenJJzOAjrU))]
		public IEnumerable<iBgGTrgmdHpXTCgVUBJdfxkXemoCA> HtYGRbaGtqhueWYsLDbcUOskJmKu(AwgAczyGvVFuzTgezjEEuVtNBwtk P_0, qKmJvgvTctYNqElyVtvMLJbPQCub P_1)
		{
			return new hiwGFQIjgrCDtGjxsKenJJzOAjrU(-2)
			{
				YMGOMkdKWDCnPDCDynNVjwlqhQpM = this,
				pSHqJWRuRnjtJcwhlorOOgKnfgyc = P_0,
				aBjxcDIHPmESRBQluhEvHoooPnkVA = P_1
			};
		}

		public int lTMjhUlycbWbmeOUQFVJstEkCXYn(iBgGTrgmdHpXTCgVUBJdfxkXemoCA P_0)
		{
			int count = BEOCOCkLwxTKlsYGsMEGdwjbrstcA.Count;
			for (int i = 0; i < count; i++)
			{
				if (BEOCOCkLwxTKlsYGsMEGdwjbrstcA[i] == P_0)
				{
					return i;
				}
			}
			return -1;
		}

		private void vQFkKKQIffIQTDAqfJBoGPsVBdTZA(int P_0, int P_1)
		{
			for (int num = BEOCOCkLwxTKlsYGsMEGdwjbrstcA.Count - 1; num >= 0; num--)
			{
				if (num != P_1 && BEOCOCkLwxTKlsYGsMEGdwjbrstcA[num].rSNNRKtNzrlMNKcNnTADSBvNbZNW == P_0)
				{
					BEOCOCkLwxTKlsYGsMEGdwjbrstcA.RemoveAt(num);
				}
			}
		}
	}

	private List<AwgAczyGvVFuzTgezjEEuVtNBwtk> EHTqDFCtpvcBnfdVtMHiMUHcLZgSA;

	private int iajuoAZOfiIpeONkhcRpppvZdlIHA;

	private ZanVHMewlqQpKpjRABISALiADycx hyFKMLOuVdxlXEiwtvjuVObrILmL;

	private bool OhUjLtThslNaqsHLympoKabMlEyv;

	private bool LRiGkMwdjylMfkCUMAoKNznQcBBl;

	private UpdateLoopType cSViyIggqHAVBznsFfipNCiKYxQj;

	private UpdateLoopType gHnJDFGPTzgkHJRzwtdCIfAZRBRVA;

	private TimerAbs miBMmxefIZsGWINGfyiqZnnEHCcj;

	private Action<int, ControllerDataUpdater> oKrcpPojANmqXdSmWHUHSNAkJfCX;

	private PlatformInputManager bYUxOCghMRylVgxjMHOKmPrSTnTW;

	private readonly IUnifiedKeyboardSource xaMcmIjOjKhGiNmLbNJxzInvPVFP;

	private readonly IUnifiedMouseSource NBXMWXwfGhvxNMLivshtxWDVUwbj;

	private bool gDKiPecmgKOBSnGzdkvsfwwbasHJB;

	private string[] ludCZYcfvAMobZtyAqoWnVyLiDft;

	[CustomObfuscation(rename = false)]
	int PlatformInputManager.deviceCount => get_deviceCount();

	[CustomObfuscation(rename = false)]
	PlatformInputManager PlatformInputManager.primaryInputManager => get_primaryInputManager();

	[CustomObfuscation(rename = false)]
	IInputSource PlatformInputManager.inputSource => get_inputSource();

	[CustomObfuscation(rename = false)]
	InputSource PlatformInputManager.inputSourceType => get_inputSourceType();

	public JRJujyYkIYDcAFcIVJVNsJrvvVWuA(UpdateLoopSetting P_0)
	{
		bYUxOCghMRylVgxjMHOKmPrSTnTW = this;
		xaMcmIjOjKhGiNmLbNJxzInvPVFP = new UnityUnifiedKeyboardSource();
		NBXMWXwfGhvxNMLivshtxWDVUwbj = new UnityUnifiedMouseSource();
		using (TempListPool.TList<UpdateLoopType> tList = TempListPool.GetTList<UpdateLoopType>(3))
		{
			List<UpdateLoopType> list = tList.list;
			EnumConverter.ToUpdateLoopTypes(P_0, list);
			int num = 0;
			if (num < list.Count)
			{
				gHnJDFGPTzgkHJRzwtdCIfAZRBRVA = list[num];
			}
		}
		ludCZYcfvAMobZtyAqoWnVyLiDft = new string[0];
		oKrcpPojANmqXdSmWHUHSNAkJfCX = UpdateControllerData;
	}

	public virtual int get_deviceCount()
	{
		return iajuoAZOfiIpeONkhcRpppvZdlIHA;
	}

	public virtual PlatformInputManager get_primaryInputManager()
	{
		return bYUxOCghMRylVgxjMHOKmPrSTnTW;
	}

	public virtual IInputSource get_inputSource()
	{
		return null;
	}

	public virtual InputSource get_inputSourceType()
	{
		return InputSource.Fallback;
	}

	[CustomObfuscation(rename = false)]
	public override void Initialize()
	{
		if (UnityTools.isAndroidPlatform && UnityTools.GpetOCgSSPLuwAcsoGSqFUWhWNAWA() != null)
		{
			UnityTools.GpetOCgSSPLuwAcsoGSqFUWhWNAWA().DeviceChangedEvent += KWxdvwUmZlBxxuYRnKlQESVsNkfe;
		}
		miBMmxefIZsGWINGfyiqZnnEHCcj = new TimerAbs(1.0);
		hyFKMLOuVdxlXEiwtvjuVObrILmL = new ZanVHMewlqQpKpjRABISALiADycx();
		ZOkqnyEgsISjRmIblfgEyxyMYmjL();
		OhUjLtThslNaqsHLympoKabMlEyv = true;
		miBMmxefIZsGWINGfyiqZnnEHCcj.Start();
	}

	[CustomObfuscation(rename = false)]
	public override void Update(UpdateLoopType updateLoop)
	{
		cSViyIggqHAVBznsFfipNCiKYxQj = updateLoop;
		AfheWUhmPDDCtHMabnWePoEZawVyb();
		if (OhUjLtThslNaqsHLympoKabMlEyv)
		{
			PiNgBkEfHVzAftEHgjxXqOSLHZYZ();
		}
		xyfdGtaUZKKfddYxJbdiSCuzooaUA(updateLoop);
	}

	[CustomObfuscation(rename = false)]
	public override void OnDestroy()
	{
		if (UnityTools.isAndroidPlatform && UnityTools.GpetOCgSSPLuwAcsoGSqFUWhWNAWA() != null)
		{
			UnityTools.GpetOCgSSPLuwAcsoGSqFUWhWNAWA().DeviceChangedEvent -= KWxdvwUmZlBxxuYRnKlQESVsNkfe;
		}
		(xaMcmIjOjKhGiNmLbNJxzInvPVFP as IDisposable).Dispose();
		(NBXMWXwfGhvxNMLivshtxWDVUwbj as IDisposable).Dispose();
	}

	[CustomObfuscation(rename = false)]
	public override Action<int, ControllerDataUpdater> GetInputDataUpdateDelegate()
	{
		return oKrcpPojANmqXdSmWHUHSNAkJfCX;
	}

	[CustomObfuscation(rename = false)]
	public override void UpdateControllerData(int assignedControllerId, ControllerDataUpdater data)
	{
		for (int i = 0; i < iajuoAZOfiIpeONkhcRpppvZdlIHA; i++)
		{
			if (EHTqDFCtpvcBnfdVtMHiMUHcLZgSA[i].get_inputManagerId() == assignedControllerId)
			{
				EHTqDFCtpvcBnfdVtMHiMUHcLZgSA[i].FillData(data);
				return;
			}
		}
		Rewired.Logger.LogError("Invalid joystick Id " + assignedControllerId + "!");
	}

	[CustomObfuscation(rename = false)]
	public override void SystemDeviceConnected()
	{
		OhUjLtThslNaqsHLympoKabMlEyv = true;
		if (_SystemDeviceConnectedEvent != null)
		{
			_SystemDeviceConnectedEvent();
		}
	}

	[CustomObfuscation(rename = false)]
	public override void SystemDeviceDisconnected()
	{
		OhUjLtThslNaqsHLympoKabMlEyv = true;
		if (_SystemDeviceDisconnectedEvent != null)
		{
			_SystemDeviceDisconnectedEvent();
		}
	}

	private void KWxdvwUmZlBxxuYRnKlQESVsNkfe()
	{
		OhUjLtThslNaqsHLympoKabMlEyv = true;
		LRiGkMwdjylMfkCUMAoKNznQcBBl = true;
	}

	[CustomObfuscation(rename = false)]
	public override void SetUnityJoystickId(int joystickId, int unityJoystickId)
	{
		for (int i = 0; i < EHTqDFCtpvcBnfdVtMHiMUHcLZgSA.Count; i++)
		{
			if (EHTqDFCtpvcBnfdVtMHiMUHcLZgSA[i].get_unityId() == unityJoystickId)
			{
				EHTqDFCtpvcBnfdVtMHiMUHcLZgSA[i].lJxkCOpGAWTKHNmXIBTqqSkynUxJ();
			}
		}
		for (int j = 0; j < EHTqDFCtpvcBnfdVtMHiMUHcLZgSA.Count; j++)
		{
			if (EHTqDFCtpvcBnfdVtMHiMUHcLZgSA[j].get_rewiredId() == joystickId)
			{
				EHTqDFCtpvcBnfdVtMHiMUHcLZgSA[j].fCqUiRMhDoCEXXWELEbvFuyQXBnh(unityJoystickId);
				break;
			}
		}
	}

	[CustomObfuscation(rename = false)]
	public override IUnifiedMouseSource GetUnifiedMouseSource()
	{
		return NBXMWXwfGhvxNMLivshtxWDVUwbj;
	}

	[CustomObfuscation(rename = false)]
	public override IUnifiedKeyboardSource GetUnifiedKeyboardSource()
	{
		return xaMcmIjOjKhGiNmLbNJxzInvPVFP;
	}

	private void ZOkqnyEgsISjRmIblfgEyxyMYmjL()
	{
		CHJqyzGnBgARulTtjfTvjWNvGrvS(Input.GetJoystickNames());
	}

	private void CHJqyzGnBgARulTtjfTvjWNvGrvS(string[] P_0)
	{
		int num = 0;
		List<AwgAczyGvVFuzTgezjEEuVtNBwtk> eHTqDFCtpvcBnfdVtMHiMUHcLZgSA = EHTqDFCtpvcBnfdVtMHiMUHcLZgSA;
		int num2 = iajuoAZOfiIpeONkhcRpppvZdlIHA;
		EHTqDFCtpvcBnfdVtMHiMUHcLZgSA = new List<AwgAczyGvVFuzTgezjEEuVtNBwtk>();
		for (int i = 0; i < P_0.Length; i++)
		{
			string text = StringTools.SanitizeDeviceString(P_0[i]);
			if (UnityTools.IsValidUnityJoystickName(text))
			{
				AwgAczyGvVFuzTgezjEEuVtNBwtk awgAczyGvVFuzTgezjEEuVtNBwtk = new AwgAczyGvVFuzTgezjEEuVtNBwtk();
				awgAczyGvVFuzTgezjEEuVtNBwtk.dQccWzEhskovHYFNqNcrGlnQdMQtA = text;
				awgAczyGvVFuzTgezjEEuVtNBwtk.fcpTRCMFluAlCICeguNnuTvMKvNgb = text;
				awgAczyGvVFuzTgezjEEuVtNBwtk.BjmitrWbYlSzJLLjYTiCEnFLsIdr = i;
				awgAczyGvVFuzTgezjEEuVtNBwtk.set_unityId(i + 1);
				if (UnityTools.isAndroidPlatform && UnityTools.GpetOCgSSPLuwAcsoGSqFUWhWNAWA() != null)
				{
					awgAczyGvVFuzTgezjEEuVtNBwtk.ddzzvVWlStVlWMekgGJgfNxzZNtvA = UnityTools.GpetOCgSSPLuwAcsoGSqFUWhWNAWA().GetUniqueDeviceIdentifier(text, i);
				}
				awgAczyGvVFuzTgezjEEuVtNBwtk.ozhbQRNBLubsaJQaZyDjVVtgRsBe();
				EHTqDFCtpvcBnfdVtMHiMUHcLZgSA.Add(awgAczyGvVFuzTgezjEEuVtNBwtk);
				num++;
			}
		}
		iajuoAZOfiIpeONkhcRpppvZdlIHA = num;
		aoghgCIWbGHwegqOMNMCZHwlgNgP(num2, num, eHTqDFCtpvcBnfdVtMHiMUHcLZgSA, EHTqDFCtpvcBnfdVtMHiMUHcLZgSA);
		for (int j = 0; j < num; j++)
		{
			if (_UpdateControllerInfoEvent != null)
			{
				_UpdateControllerInfoEvent(new UpdateControllerInfoEventArgs(EHTqDFCtpvcBnfdVtMHiMUHcLZgSA[j]));
			}
		}
		vudPpKNPkjhEGiYCcGVfIsPulLEp(eHTqDFCtpvcBnfdVtMHiMUHcLZgSA, EHTqDFCtpvcBnfdVtMHiMUHcLZgSA, false);
		vudPpKNPkjhEGiYCcGVfIsPulLEp(EHTqDFCtpvcBnfdVtMHiMUHcLZgSA, eHTqDFCtpvcBnfdVtMHiMUHcLZgSA, true);
		ludCZYcfvAMobZtyAqoWnVyLiDft = P_0;
	}

	private void xyfdGtaUZKKfddYxJbdiSCuzooaUA(UpdateLoopType P_0)
	{
		int count = EHTqDFCtpvcBnfdVtMHiMUHcLZgSA.Count;
		for (int i = 0; i < count; i++)
		{
			if (EHTqDFCtpvcBnfdVtMHiMUHcLZgSA[i] != null)
			{
				EHTqDFCtpvcBnfdVtMHiMUHcLZgSA[i].Update();
			}
		}
	}

	private void aoghgCIWbGHwegqOMNMCZHwlgNgP(int P_0, int P_1, List<AwgAczyGvVFuzTgezjEEuVtNBwtk> P_2, List<AwgAczyGvVFuzTgezjEEuVtNBwtk> P_3)
	{
		if (P_1 > 0)
		{
			P_3.Sort(AwgAczyGvVFuzTgezjEEuVtNBwtk.TbCiuxGgrgWKpSAmgmlxysSZTiyrA);
		}
		if (P_0 > 0 && P_1 > 0)
		{
			xuLLMDwbNaLXUWsDgvpPjduvwbDf(P_1, P_3, P_0, P_2, ZanVHMewlqQpKpjRABISALiADycx.qKmJvgvTctYNqElyVtvMLJbPQCub.Exact);
			xuLLMDwbNaLXUWsDgvpPjduvwbDf(P_1, P_3, P_0, P_2, ZanVHMewlqQpKpjRABISALiADycx.qKmJvgvTctYNqElyVtvMLJbPQCub.Approximate);
		}
		DhxdcFUepWBMrGNGvMghAYFaSMXs(P_1, P_3, ZanVHMewlqQpKpjRABISALiADycx.qKmJvgvTctYNqElyVtvMLJbPQCub.Exact);
		DhxdcFUepWBMrGNGvMghAYFaSMXs(P_1, P_3, ZanVHMewlqQpKpjRABISALiADycx.qKmJvgvTctYNqElyVtvMLJbPQCub.Approximate);
		for (int i = 0; i < P_1; i++)
		{
			AwgAczyGvVFuzTgezjEEuVtNBwtk awgAczyGvVFuzTgezjEEuVtNBwtk = P_3[i];
			if (awgAczyGvVFuzTgezjEEuVtNBwtk != null && awgAczyGvVFuzTgezjEEuVtNBwtk.get_inputManagerId() < 0)
			{
				awgAczyGvVFuzTgezjEEuVtNBwtk.set_inputManagerId(ZKVgwXdhBkPmFcOKGMNQkoHTEAVdB(P_3));
				awgAczyGvVFuzTgezjEEuVtNBwtk.set_rewiredId(ReInput.GetNewJoystickId());
				hyFKMLOuVdxlXEiwtvjuVObrILmL.hvmEZTVDOsgcVQZPaOvHDqBVhxsdA(awgAczyGvVFuzTgezjEEuVtNBwtk);
			}
		}
		P_3.Sort(AwgAczyGvVFuzTgezjEEuVtNBwtk.kKaCMkHtzGNmZNZXYWJZRhJmmDxRA);
	}

	private void ZBVVicjmuAWxphPFQYjjvIFoBPCH(List<AwgAczyGvVFuzTgezjEEuVtNBwtk> P_0, int P_1, int P_2)
	{
		int count = P_0.Count;
		for (int i = 0; i < count; i++)
		{
			if (i != P_1 && P_0[i] != null && P_0[i].get_inputManagerId() == P_2)
			{
				P_0[i].set_inputManagerId(-1);
			}
		}
	}

	private bool VimgSThUuRzhFxHMQVhLpAJAoTTY(List<AwgAczyGvVFuzTgezjEEuVtNBwtk> P_0, int P_1)
	{
		int count = P_0.Count;
		for (int i = 0; i < count; i++)
		{
			if (P_0[i] != null && P_0[i].get_inputManagerId() == P_1)
			{
				return false;
			}
		}
		return true;
	}

	private int ZKVgwXdhBkPmFcOKGMNQkoHTEAVdB(List<AwgAczyGvVFuzTgezjEEuVtNBwtk> P_0)
	{
		int num = 0;
		while (true)
		{
			bool flag = false;
			int count = P_0.Count;
			for (int i = 0; i < count; i++)
			{
				if (P_0[i] != null && P_0[i].get_inputManagerId() == num)
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				break;
			}
			num++;
		}
		return num;
	}

	private bool eSQzauQTSjeUKWCmuFZyDKDGiNFZ(List<AwgAczyGvVFuzTgezjEEuVtNBwtk> P_0, int P_1)
	{
		if (P_0 == null)
		{
			return false;
		}
		for (int i = 0; i < P_0.Count; i++)
		{
			if (P_0[i].get_rewiredId() == P_1)
			{
				return true;
			}
		}
		return false;
	}

	private void xuLLMDwbNaLXUWsDgvpPjduvwbDf(int P_0, List<AwgAczyGvVFuzTgezjEEuVtNBwtk> P_1, int P_2, List<AwgAczyGvVFuzTgezjEEuVtNBwtk> P_3, ZanVHMewlqQpKpjRABISALiADycx.qKmJvgvTctYNqElyVtvMLJbPQCub P_4)
	{
		int num = ((P_4 != ZanVHMewlqQpKpjRABISALiADycx.qKmJvgvTctYNqElyVtvMLJbPQCub.Exact) ? 1 : 2);
		for (int i = 0; i < P_0; i++)
		{
			AwgAczyGvVFuzTgezjEEuVtNBwtk awgAczyGvVFuzTgezjEEuVtNBwtk = P_1[i];
			if (awgAczyGvVFuzTgezjEEuVtNBwtk == null || awgAczyGvVFuzTgezjEEuVtNBwtk.get_inputManagerId() >= 0)
			{
				continue;
			}
			for (int j = 0; j < P_2; j++)
			{
				AwgAczyGvVFuzTgezjEEuVtNBwtk awgAczyGvVFuzTgezjEEuVtNBwtk2 = P_3[j];
				if (awgAczyGvVFuzTgezjEEuVtNBwtk2 != null && !eSQzauQTSjeUKWCmuFZyDKDGiNFZ(P_1, awgAczyGvVFuzTgezjEEuVtNBwtk2.get_rewiredId()) && awgAczyGvVFuzTgezjEEuVtNBwtk.jfbaSwisAOqRlgnYFlAMTZiSRFlMA(awgAczyGvVFuzTgezjEEuVtNBwtk2) >= num)
				{
					awgAczyGvVFuzTgezjEEuVtNBwtk.set_inputManagerId(awgAczyGvVFuzTgezjEEuVtNBwtk2.get_inputManagerId());
					awgAczyGvVFuzTgezjEEuVtNBwtk.set_rewiredId(awgAczyGvVFuzTgezjEEuVtNBwtk2.get_rewiredId());
					if (ReInput.isWindowsStandaloneWebplayerOrEditorPlatform && !UnityTools.windowsJoystickNamesReturnsEmptyStringsIfJoystickNull)
					{
						awgAczyGvVFuzTgezjEEuVtNBwtk.set_unityId(awgAczyGvVFuzTgezjEEuVtNBwtk2.get_unityId());
					}
					hyFKMLOuVdxlXEiwtvjuVObrILmL.hvmEZTVDOsgcVQZPaOvHDqBVhxsdA(awgAczyGvVFuzTgezjEEuVtNBwtk);
				}
			}
		}
	}

	private void DhxdcFUepWBMrGNGvMghAYFaSMXs(int P_0, List<AwgAczyGvVFuzTgezjEEuVtNBwtk> P_1, ZanVHMewlqQpKpjRABISALiADycx.qKmJvgvTctYNqElyVtvMLJbPQCub P_2)
	{
		for (int i = 0; i < P_0; i++)
		{
			AwgAczyGvVFuzTgezjEEuVtNBwtk awgAczyGvVFuzTgezjEEuVtNBwtk = P_1[i];
			if (awgAczyGvVFuzTgezjEEuVtNBwtk == null || awgAczyGvVFuzTgezjEEuVtNBwtk.get_inputManagerId() >= 0)
			{
				continue;
			}
			ZanVHMewlqQpKpjRABISALiADycx.iBgGTrgmdHpXTCgVUBJdfxkXemoCA iBgGTrgmdHpXTCgVUBJdfxkXemoCA = null;
			foreach (ZanVHMewlqQpKpjRABISALiADycx.iBgGTrgmdHpXTCgVUBJdfxkXemoCA item in hyFKMLOuVdxlXEiwtvjuVObrILmL.HtYGRbaGtqhueWYsLDbcUOskJmKu(awgAczyGvVFuzTgezjEEuVtNBwtk, P_2))
			{
				if (!eSQzauQTSjeUKWCmuFZyDKDGiNFZ(P_1, item.rSNNRKtNzrlMNKcNnTADSBvNbZNW) && item.MjnDGiTNErDPmspZOGRHJTSBhxuSA >= 0)
				{
					iBgGTrgmdHpXTCgVUBJdfxkXemoCA = item;
					break;
				}
			}
			if (iBgGTrgmdHpXTCgVUBJdfxkXemoCA != null)
			{
				int num = iBgGTrgmdHpXTCgVUBJdfxkXemoCA.MjnDGiTNErDPmspZOGRHJTSBhxuSA;
				if (!VimgSThUuRzhFxHMQVhLpAJAoTTY(P_1, num))
				{
					num = (iBgGTrgmdHpXTCgVUBJdfxkXemoCA.MjnDGiTNErDPmspZOGRHJTSBhxuSA = ZKVgwXdhBkPmFcOKGMNQkoHTEAVdB(P_1));
				}
				awgAczyGvVFuzTgezjEEuVtNBwtk.set_inputManagerId(num);
				awgAczyGvVFuzTgezjEEuVtNBwtk.set_rewiredId(iBgGTrgmdHpXTCgVUBJdfxkXemoCA.rSNNRKtNzrlMNKcNnTADSBvNbZNW);
				hyFKMLOuVdxlXEiwtvjuVObrILmL.hvmEZTVDOsgcVQZPaOvHDqBVhxsdA(awgAczyGvVFuzTgezjEEuVtNBwtk);
			}
		}
	}

	private void PiNgBkEfHVzAftEHgjxXqOSLHZYZ()
	{
		string[] joystickNames = Input.GetJoystickNames();
		if (LRiGkMwdjylMfkCUMAoKNznQcBBl || vDFLWiWxUAEjvBPlsQLTRemMllMF(joystickNames))
		{
			CHJqyzGnBgARulTtjfTvjWNvGrvS(joystickNames);
		}
		OhUjLtThslNaqsHLympoKabMlEyv = false;
		if (LRiGkMwdjylMfkCUMAoKNznQcBBl)
		{
			LRiGkMwdjylMfkCUMAoKNznQcBBl = false;
		}
	}

	private bool vDFLWiWxUAEjvBPlsQLTRemMllMF(string[] P_0)
	{
		if (P_0.Length != ludCZYcfvAMobZtyAqoWnVyLiDft.Length)
		{
			return true;
		}
		for (int i = 0; i < P_0.Length; i++)
		{
			if (!string.Equals(P_0[i], ludCZYcfvAMobZtyAqoWnVyLiDft[i], StringComparison.Ordinal))
			{
				return true;
			}
		}
		return false;
	}

	private void vudPpKNPkjhEGiYCcGVfIsPulLEp(List<AwgAczyGvVFuzTgezjEEuVtNBwtk> P_0, List<AwgAczyGvVFuzTgezjEEuVtNBwtk> P_1, bool P_2)
	{
		if (P_0 == null)
		{
			return;
		}
		int num = P_0?.Count ?? 0;
		int num2 = P_1?.Count ?? 0;
		for (int i = 0; i < num; i++)
		{
			AwgAczyGvVFuzTgezjEEuVtNBwtk awgAczyGvVFuzTgezjEEuVtNBwtk = P_0[i];
			if (awgAczyGvVFuzTgezjEEuVtNBwtk == null)
			{
				continue;
			}
			bool flag = false;
			if (P_1 != null)
			{
				for (int j = 0; j < num2; j++)
				{
					AwgAczyGvVFuzTgezjEEuVtNBwtk awgAczyGvVFuzTgezjEEuVtNBwtk2 = P_1[j];
					if (awgAczyGvVFuzTgezjEEuVtNBwtk2 != null && awgAczyGvVFuzTgezjEEuVtNBwtk.get_rewiredId() == awgAczyGvVFuzTgezjEEuVtNBwtk2.get_rewiredId())
					{
						flag = true;
						break;
					}
				}
			}
			if (!flag)
			{
				EfdBHAMNjQcfNDqHbjRGbZvzCvacA(P_0[i], P_2);
			}
		}
	}

	private void EfdBHAMNjQcfNDqHbjRGbZvzCvacA(AwgAczyGvVFuzTgezjEEuVtNBwtk P_0, bool P_1)
	{
		if (P_1)
		{
			if (_DeviceConnectedEvent != null)
			{
				_DeviceConnectedEvent(P_0.ToBridgedController());
			}
		}
		else if (_DeviceDisconnectedEvent != null)
		{
			_DeviceDisconnectedEvent(P_0.ToControllerDisconnectedEventArgs());
		}
	}

	private void AfheWUhmPDDCtHMabnWePoEZawVyb()
	{
		if (cSViyIggqHAVBznsFfipNCiKYxQj == gHnJDFGPTzgkHJRzwtdCIfAZRBRVA && miBMmxefIZsGWINGfyiqZnnEHCcj.Update())
		{
			OhUjLtThslNaqsHLympoKabMlEyv = true;
			miBMmxefIZsGWINGfyiqZnnEHCcj.Start();
		}
	}
}
