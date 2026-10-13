using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using Rewired;
using Rewired.Data;
using Rewired.Data.Mapping;
using Rewired.InputSources.SDL2;
using Rewired.Interfaces;
using Rewired.Internal.Localization;
using Rewired.Utils;

internal class QTMrFJnvXCFHNDKQVmcIvGDUKQOG : PlatformInputManager
{
	private class gEkAlBetTyTJTStTskBnWuobEWQjA : IInputManagerJoystick, IInputManagerJoystickPublic
	{
		private int BNxekKJFsVgfsFVrIQVDrwrzwZmDA;

		private int ewJEmceTOCUMtxvkGtGGiTEBAVHb;

		public Guid uiKqASkaAZQktWEvmlpbpxpiEEcB;

		public string GGnFbbytaLOxdWcspzsDpoOOekIIA;

		public wfXvpNxXWJkwQbGkekNHCgrsJhAN LahAkGtJiZxAjTcliiOkmEqzhIjs;

		public QjbGhnqBRCdfATtVFynSOZBkFBzV XEjbSoDBtAUGYKoSgbwvrNysdCqUA;

		public string WrtpAoXwWETrUZTtJhtetHLsIHHn;

		public string nicrENHFqXKlVdkXFNvPSMjaOUsT;

		public int RQWAPKZFrfgEvhBxudBcdTEpMeQpA;

		public int UjLWVWLYPhhbPjqwKIcOmSoPTYag;

		public Guid rPPRgAgSJtpIocaNdDJwlRQCrzDB;

		public PidVid MRsubxMOGRFOyjhiPSdWcoTdBSlB;

		public Guid RekqLcxtbuhdnKNgkZREtMrBZZDf;

		public int ibJLgibNXxHCcZLMJuOdMmpGbwVAA;

		public int HHZlNXNqGaCiCXKQUiaFBOJdEqrJA;

		public int efTMucZlTDGRvMsGdGhrBBCYRHoY;

		public int hjEYFJEzBaDrosOXeqWCWoWnqWhs;

		public int xMEaREoWNcSGzYiYqfrkkivsuWGG;

		public int ftWEOiHRGsvUtgJSPCLVIuDcJoYCb;

		public bool SaFtroSEuHAgybkOcMvhIbgQUqvR;

		public bool bZoOOpSEoENenWtIXpTiPEqqpgoq;

		public int ebvKFLbQnTzHdKVCxwlBoRBOSnJb;

		private float[] ahHeraGgWUliikSOXpUoUqobEAXf;

		private bool[] kbuuMziZHgndRBEycAbAbVxFGnlf;

		private HardwareJoystickMap_InputManager HKuVpwSviKyiEvhPQTGnkdHJUjQK;

		private Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> quLWSAAKRKXgPsxQmuatlwQtlLRb;

		private bool RFtICkRhwuWLmBPGeDeFbFRIfyJfA;

		private bool ANyAkYUIClUdqszsWVyemZOsfWG;

		[CompilerGenerated]
		private Controller.Extension VzkQwRsUFEWUHxhlkEpkjgDXKkXgA;

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
		int IInputManagerJoystickPublic.unityId => get_unityId();

		[CustomObfuscation(rename = false)]
		Guid IInputManagerJoystickPublic.instanceGuid => get_instanceGuid();

		[CustomObfuscation(rename = false)]
		Guid IInputManagerJoystickPublic.persistentGuid => get_persistentGuid();

		[CustomObfuscation(rename = false)]
		Controller.Extension IInputManagerJoystickPublic.extension
		{
			get
			{
				return get_extension();
			}
			set
			{
				set_extension(value);
			}
		}

		public int get_rewiredId()
		{
			return BNxekKJFsVgfsFVrIQVDrwrzwZmDA;
		}

		public void set_rewiredId(int value)
		{
			BNxekKJFsVgfsFVrIQVDrwrzwZmDA = value;
		}

		public int get_inputManagerId()
		{
			return ewJEmceTOCUMtxvkGtGGiTEBAVHb;
		}

		public void set_inputManagerId(int value)
		{
			ewJEmceTOCUMtxvkGtGGiTEBAVHb = value;
		}

		public string get_name()
		{
			return GGnFbbytaLOxdWcspzsDpoOOekIIA;
		}

		public long? get_systemId()
		{
			if (ewJEmceTOCUMtxvkGtGGiTEBAVHb < 0)
			{
				return null;
			}
			return ewJEmceTOCUMtxvkGtGGiTEBAVHb;
		}

		public int get_unityId()
		{
			return 0;
		}

		public Guid get_instanceGuid()
		{
			return rPPRgAgSJtpIocaNdDJwlRQCrzDB;
		}

		public Guid get_persistentGuid()
		{
			return get_instanceGuid();
		}

		public Controller.Extension get_extension()
		{
			return VzkQwRsUFEWUHxhlkEpkjgDXKkXgA;
		}

		public void set_extension(Controller.Extension value)
		{
			VzkQwRsUFEWUHxhlkEpkjgDXKkXgA = value;
		}

		[CustomObfuscation(rename = false)]
		public void SetVibration(float amount, int motorIndex)
		{
			LahAkGtJiZxAjTcliiOkmEqzhIjs.xVjdiSKkJXcgPQxFKpxiVXDneKaO(motorIndex, amount, false);
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

		public gEkAlBetTyTJTStTskBnWuobEWQjA(Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> P_0)
		{
			quLWSAAKRKXgPsxQmuatlwQtlLRb = P_0;
			ewJEmceTOCUMtxvkGtGGiTEBAVHb = -1;
			BNxekKJFsVgfsFVrIQVDrwrzwZmDA = -1;
		}

		public void SGscNXSdUFkFGnxkVjcvEDLtufAN()
		{
			RekqLcxtbuhdnKNgkZREtMrBZZDf = MiscTools.CreateGuidHashSHA1(WrtpAoXwWETrUZTtJhtetHLsIHHn + MRsubxMOGRFOyjhiPSdWcoTdBSlB.ToProductGuid().ToString());
			HHZlNXNqGaCiCXKQUiaFBOJdEqrJA = hjEYFJEzBaDrosOXeqWCWoWnqWhs;
			efTMucZlTDGRvMsGdGhrBBCYRHoY = xMEaREoWNcSGzYiYqfrkkivsuWGG + ftWEOiHRGsvUtgJSPCLVIuDcJoYCb * 8;
			yFvGQualYZctsMliCPBksUQmIqRN();
			uiKqASkaAZQktWEvmlpbpxpiEEcB = HKuVpwSviKyiEvhPQTGnkdHJUjQK.hardwareMapIdentifier.guid;
			GGnFbbytaLOxdWcspzsDpoOOekIIA = HKuVpwSviKyiEvhPQTGnkdHJUjQK.controllerName;
			RFtICkRhwuWLmBPGeDeFbFRIfyJfA = ((uiKqASkaAZQktWEvmlpbpxpiEEcB == Guid.Empty) ? true : false);
			ahHeraGgWUliikSOXpUoUqobEAXf = new float[HHZlNXNqGaCiCXKQUiaFBOJdEqrJA];
			kbuuMziZHgndRBEycAbAbVxFGnlf = new bool[efTMucZlTDGRvMsGdGhrBBCYRHoY];
			Update();
		}

		public void ekanoaDsUPAgTgtWHacfMXMwLHMM(gEkAlBetTyTJTStTskBnWuobEWQjA P_0)
		{
			if (P_0 != null)
			{
				ewJEmceTOCUMtxvkGtGGiTEBAVHb = P_0.ewJEmceTOCUMtxvkGtGGiTEBAVHb;
				BNxekKJFsVgfsFVrIQVDrwrzwZmDA = P_0.BNxekKJFsVgfsFVrIQVDrwrzwZmDA;
				for (int i = 0; i < MathTools.Min(kbuuMziZHgndRBEycAbAbVxFGnlf.Length, P_0.kbuuMziZHgndRBEycAbAbVxFGnlf.Length); i++)
				{
					kbuuMziZHgndRBEycAbAbVxFGnlf[i] = P_0.kbuuMziZHgndRBEycAbAbVxFGnlf[i];
				}
				for (int j = 0; j < MathTools.Min(ahHeraGgWUliikSOXpUoUqobEAXf.Length, P_0.ahHeraGgWUliikSOXpUoUqobEAXf.Length); j++)
				{
					ahHeraGgWUliikSOXpUoUqobEAXf[j] = P_0.ahHeraGgWUliikSOXpUoUqobEAXf[j];
				}
				ANyAkYUIClUdqszsWVyemZOsfWG = P_0.ANyAkYUIClUdqszsWVyemZOsfWG;
			}
		}

		[CustomObfuscation(rename = false)]
		public void Update()
		{
			eGAiVpsbTQptbcsHoGhPhdZzmVvU();
			pJvRCUcVZRcKqymhlRrWZBzFQqay();
			if (!ANyAkYUIClUdqszsWVyemZOsfWG && LahAkGtJiZxAjTcliiOkmEqzhIjs.YuJbcWtawZdyKaeUyBmIwsOsQbKsA())
			{
				ANyAkYUIClUdqszsWVyemZOsfWG = true;
			}
		}

		void IInputManagerJoystick.Update()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Update
			this.Update();
		}

		[CustomObfuscation(rename = false)]
		public void FillData(ControllerDataUpdater dataUpdater)
		{
			if (HHZlNXNqGaCiCXKQUiaFBOJdEqrJA != dataUpdater.axisCount || efTMucZlTDGRvMsGdGhrBBCYRHoY != dataUpdater.buttonCount)
			{
				throw new Exception("This controller signature does not match the data object!");
			}
			for (int i = 0; i < HHZlNXNqGaCiCXKQUiaFBOJdEqrJA; i++)
			{
				dataUpdater.axisValues[i] = ahHeraGgWUliikSOXpUoUqobEAXf[i];
			}
			for (int j = 0; j < efTMucZlTDGRvMsGdGhrBBCYRHoY; j++)
			{
				dataUpdater.buttonValues[j] = kbuuMziZHgndRBEycAbAbVxFGnlf[j];
			}
			if (ANyAkYUIClUdqszsWVyemZOsfWG && !dataUpdater.hasReceivedInput)
			{
				dataUpdater.hasReceivedInput = true;
			}
		}

		void IInputManagerJoystick.FillData(ControllerDataUpdater dataUpdater)
		{
			//ILSpy generated this explicit interface implementation from .override directive in FillData
			this.FillData(dataUpdater);
		}

		public int CgpjdIMxBaAlHZGxnIitvQKuRNwW(gEkAlBetTyTJTStTskBnWuobEWQjA P_0)
		{
			if (P_0.BNxekKJFsVgfsFVrIQVDrwrzwZmDA == BNxekKJFsVgfsFVrIQVDrwrzwZmDA)
			{
				return 2;
			}
			if (hjEYFJEzBaDrosOXeqWCWoWnqWhs != P_0.hjEYFJEzBaDrosOXeqWCWoWnqWhs)
			{
				return 0;
			}
			if (xMEaREoWNcSGzYiYqfrkkivsuWGG != P_0.xMEaREoWNcSGzYiYqfrkkivsuWGG)
			{
				return 0;
			}
			if (ftWEOiHRGsvUtgJSPCLVIuDcJoYCb != P_0.ftWEOiHRGsvUtgJSPCLVIuDcJoYCb)
			{
				return 0;
			}
			if (P_0.rPPRgAgSJtpIocaNdDJwlRQCrzDB == rPPRgAgSJtpIocaNdDJwlRQCrzDB)
			{
				return 2;
			}
			if (P_0.RekqLcxtbuhdnKNgkZREtMrBZZDf == RekqLcxtbuhdnKNgkZREtMrBZZDf)
			{
				return 1;
			}
			return 0;
		}

		private BridgedControllerHWInfo cimpVopqtQvynvtkznCgDnWjHuaR()
		{
			BridgedControllerHWInfo bridgedControllerHWInfo = new BridgedControllerHWInfo();
			FZuLxBbciTBekHcRJBWzCrcJvREPA(bridgedControllerHWInfo);
			return bridgedControllerHWInfo;
		}

		[CustomObfuscation(rename = false)]
		public BridgedController ToBridgedController()
		{
			BridgedController bridgedController = new BridgedController();
			pxGdePbkakPoeRtyJjEycAxdLqZic(bridgedController);
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
			return new ControllerDisconnectedEventArgs(BNxekKJFsVgfsFVrIQVDrwrzwZmDA);
		}

		ControllerDisconnectedEventArgs IInputManagerJoystick.ToControllerDisconnectedEventArgs()
		{
			//ILSpy generated this explicit interface implementation from .override directive in ToControllerDisconnectedEventArgs
			return this.ToControllerDisconnectedEventArgs();
		}

		private void eGAiVpsbTQptbcsHoGhPhdZzmVvU()
		{
			if (HHZlNXNqGaCiCXKQUiaFBOJdEqrJA <= 0 || HKuVpwSviKyiEvhPQTGnkdHJUjQK.map.platform != InputPlatform.SDL2)
			{
				return;
			}
			HardwareJoystickMap.Platform_SDL2_Base.Axis[] axes_orig = ((HardwareJoystickMap.Platform_SDL2_Base)HKuVpwSviKyiEvhPQTGnkdHJUjQK.map).Axes_orig;
			if (axes_orig != null)
			{
				for (int i = 0; i < axes_orig.Length; i++)
				{
					oxZkLOYAiKzIPNNAbGqqVFaZEcgu(axes_orig[i], i);
				}
			}
		}

		private void pJvRCUcVZRcKqymhlRrWZBzFQqay()
		{
			if (efTMucZlTDGRvMsGdGhrBBCYRHoY <= 0)
			{
				return;
			}
			HardwareJoystickMap.Platform_SDL2_Base.Button[] buttons_orig = ((HardwareJoystickMap.Platform_SDL2_Base)HKuVpwSviKyiEvhPQTGnkdHJUjQK.map).Buttons_orig;
			if (buttons_orig != null)
			{
				for (int i = 0; i < buttons_orig.Length; i++)
				{
					HEbPdDbIgBofgIWNGtIKtHZKaJNw(buttons_orig[i], i);
				}
			}
		}

		private void oxZkLOYAiKzIPNNAbGqqVFaZEcgu(HardwareJoystickMap.Platform_SDL2_Base.Axis P_0, int P_1)
		{
			if (P_1 >= HHZlNXNqGaCiCXKQUiaFBOJdEqrJA)
			{
				throw new Exception("Number of axes in hardware map does not match number of axes found in controller!");
			}
			ahHeraGgWUliikSOXpUoUqobEAXf[P_1] = gBXMCIzmoFgwUHFZTTgdAFuCfZfZA(P_0);
		}

		private void HEbPdDbIgBofgIWNGtIKtHZKaJNw(HardwareJoystickMap.Platform_SDL2_Base.Button P_0, int P_1)
		{
			if (P_1 >= efTMucZlTDGRvMsGdGhrBBCYRHoY)
			{
				throw new Exception("Number of buttons in hardware map does not match number of buttons found in controller!");
			}
			kbuuMziZHgndRBEycAbAbVxFGnlf[P_1] = tIizqpECrXXDlCAaZNmZHNDLfpBeA(P_0);
		}

		private float gBXMCIzmoFgwUHFZTTgdAFuCfZfZA(HardwareJoystickMap.Platform_SDL2_Base.Axis P_0)
		{
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Axis)
			{
				int sourceAxis = P_0.sourceAxis;
				if (sourceAxis < 0 || sourceAxis >= hjEYFJEzBaDrosOXeqWCWoWnqWhs || sourceAxis >= 56)
				{
					return 0f;
				}
				return LahAkGtJiZxAjTcliiOkmEqzhIjs.JmJyPyvQUZYXAKxYHpXQyQoPRAGJ(sourceAxis);
			}
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Button)
			{
				int sourceButton = P_0.sourceButton;
				if (sourceButton < 0 || sourceButton >= xMEaREoWNcSGzYiYqfrkkivsuWGG || sourceButton >= 256)
				{
					return 0f;
				}
				if (!LahAkGtJiZxAjTcliiOkmEqzhIjs.XHUxQTfMKjVTxqsuMiMwdgGZGnzEA(sourceButton))
				{
					return 0f;
				}
				if (P_0.buttonAxisContribution == Pole.Positive)
				{
					return 1f;
				}
				return -1f;
			}
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Hat)
			{
				int sourceHat = P_0.sourceHat;
				if (sourceHat < 0 || sourceHat >= ftWEOiHRGsvUtgJSPCLVIuDcJoYCb || sourceHat >= 4)
				{
					return 0f;
				}
				int num = LahAkGtJiZxAjTcliiOkmEqzhIjs.hGNfrgiOhXmYsnRnkakWheHDwAyFB(sourceHat);
				if (num < 0)
				{
					return 0f;
				}
				float num2;
				if (P_0.sourceHatDirection == AxisDirection.Horizontal)
				{
					num2 = YGVSuolFHYUITXwDfFjvGddQTkKq(num, AxisDirection.Horizontal);
					if (P_0.sourceHatRange != AxisRange.Full)
					{
						if (P_0.sourceHatRange == AxisRange.Positive)
						{
							if (num2 < 0f)
							{
								return 0f;
							}
						}
						else if (num2 > 0f)
						{
							return 0f;
						}
					}
				}
				else
				{
					num2 = YGVSuolFHYUITXwDfFjvGddQTkKq(num, AxisDirection.Vertical);
					if (P_0.sourceHatRange != AxisRange.Full)
					{
						if (P_0.sourceHatRange == AxisRange.Positive)
						{
							if (num2 < 0f)
							{
								return 0f;
							}
						}
						else if (num2 > 0f)
						{
							return 0f;
						}
					}
				}
				if (P_0.invert)
				{
					num2 *= -1f;
				}
				return num2;
			}
			return 0f;
		}

		private bool tIizqpECrXXDlCAaZNmZHNDLfpBeA(HardwareJoystickMap.Platform_SDL2_Base.Button P_0)
		{
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Button)
			{
				if (P_0.ignoreIfButtonsActive)
				{
					for (int i = 0; i < P_0.ignoreIfButtonsActiveButtons.Length; i++)
					{
						if (LahAkGtJiZxAjTcliiOkmEqzhIjs.XHUxQTfMKjVTxqsuMiMwdgGZGnzEA(P_0.ignoreIfButtonsActiveButtons[i]))
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
						if (!LahAkGtJiZxAjTcliiOkmEqzhIjs.XHUxQTfMKjVTxqsuMiMwdgGZGnzEA(P_0.requiredButtons[j]))
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
				int sourceButton = P_0.sourceButton;
				if (sourceButton < 0 || sourceButton >= xMEaREoWNcSGzYiYqfrkkivsuWGG || sourceButton >= 256)
				{
					return false;
				}
				return LahAkGtJiZxAjTcliiOkmEqzhIjs.XHUxQTfMKjVTxqsuMiMwdgGZGnzEA(sourceButton);
			}
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Axis)
			{
				int sourceAxis = P_0.sourceAxis;
				if (sourceAxis <= 0 || sourceAxis >= hjEYFJEzBaDrosOXeqWCWoWnqWhs || sourceAxis >= 56)
				{
					return false;
				}
				float num = LahAkGtJiZxAjTcliiOkmEqzhIjs.JmJyPyvQUZYXAKxYHpXQyQoPRAGJ(sourceAxis);
				if (MathTools.Abs(num) <= P_0.axisDeadZone)
				{
					return false;
				}
				if (P_0.sourceAxisPole == Pole.Positive)
				{
					if (num < 0f)
					{
						return false;
					}
				}
				else if (num > 0f)
				{
					return false;
				}
				return true;
			}
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Hat)
			{
				int sourceHat = P_0.sourceHat;
				if (sourceHat < 0 || sourceHat >= ftWEOiHRGsvUtgJSPCLVIuDcJoYCb || sourceHat >= 4)
				{
					return false;
				}
				switch (P_0.sourceHatDirection)
				{
				case HatDirection.Up:
					return VvWUgjNkfqcScEPKHoSNfRXcQIPDb(LahAkGtJiZxAjTcliiOkmEqzhIjs.hGNfrgiOhXmYsnRnkakWheHDwAyFB(sourceHat), 0, P_0.sourceHatType);
				case HatDirection.UpRight:
					return VvWUgjNkfqcScEPKHoSNfRXcQIPDb(LahAkGtJiZxAjTcliiOkmEqzhIjs.hGNfrgiOhXmYsnRnkakWheHDwAyFB(sourceHat), 1, P_0.sourceHatType);
				case HatDirection.Right:
					return VvWUgjNkfqcScEPKHoSNfRXcQIPDb(LahAkGtJiZxAjTcliiOkmEqzhIjs.hGNfrgiOhXmYsnRnkakWheHDwAyFB(sourceHat), 2, P_0.sourceHatType);
				case HatDirection.DownRight:
					return VvWUgjNkfqcScEPKHoSNfRXcQIPDb(LahAkGtJiZxAjTcliiOkmEqzhIjs.hGNfrgiOhXmYsnRnkakWheHDwAyFB(sourceHat), 3, P_0.sourceHatType);
				case HatDirection.Down:
					return VvWUgjNkfqcScEPKHoSNfRXcQIPDb(LahAkGtJiZxAjTcliiOkmEqzhIjs.hGNfrgiOhXmYsnRnkakWheHDwAyFB(sourceHat), 4, P_0.sourceHatType);
				case HatDirection.DownLeft:
					return VvWUgjNkfqcScEPKHoSNfRXcQIPDb(LahAkGtJiZxAjTcliiOkmEqzhIjs.hGNfrgiOhXmYsnRnkakWheHDwAyFB(sourceHat), 5, P_0.sourceHatType);
				case HatDirection.Left:
					return VvWUgjNkfqcScEPKHoSNfRXcQIPDb(LahAkGtJiZxAjTcliiOkmEqzhIjs.hGNfrgiOhXmYsnRnkakWheHDwAyFB(sourceHat), 6, P_0.sourceHatType);
				case HatDirection.UpLeft:
					return VvWUgjNkfqcScEPKHoSNfRXcQIPDb(LahAkGtJiZxAjTcliiOkmEqzhIjs.hGNfrgiOhXmYsnRnkakWheHDwAyFB(sourceHat), 7, P_0.sourceHatType);
				}
			}
			return false;
		}

		private bool VvWUgjNkfqcScEPKHoSNfRXcQIPDb(int P_0, int P_1, HatType P_2)
		{
			if (P_0 < 0)
			{
				return false;
			}
			if (HKuVpwSviKyiEvhPQTGnkdHJUjQK.isUnknownController && !InputTools.HandleForced4WayHatsOnUnknownControllers(P_1, ref P_2))
			{
				return false;
			}
			int num = 4500 * P_1;
			if (P_2 == HatType.EightWay && P_0 != num)
			{
				return false;
			}
			int num2;
			int num3;
			if (P_2 == HatType.EightWay)
			{
				num2 = 31500;
				num3 = 4500;
			}
			else
			{
				num2 = 27000;
				num3 = 9000;
			}
			if (P_1 == 0 && P_0 > num2)
			{
				P_0 -= 36000;
			}
			if (P_0 < num + num3 && P_0 > num - num3)
			{
				return true;
			}
			return false;
		}

		private float YGVSuolFHYUITXwDfFjvGddQTkKq(int P_0, AxisDirection P_1)
		{
			if (P_0 < 0)
			{
				return 0f;
			}
			if (P_1 == AxisDirection.Vertical)
			{
				if (P_0 > 27000 || P_0 < 9000)
				{
					return 1f;
				}
				if (P_0 < 27000 && P_0 > 9000)
				{
					return -1f;
				}
				return 0f;
			}
			if (P_0 > 0 && P_0 < 18000)
			{
				return 1f;
			}
			if (P_0 > 18000)
			{
				return -1f;
			}
			return 0f;
		}

		private ControlDeviceType omSXwzBHpqHnWJlFzeoUJaqASDsLA(QjbGhnqBRCdfATtVFynSOZBkFBzV P_0)
		{
			return P_0 switch
			{
				QjbGhnqBRCdfATtVFynSOZBkFBzV.Joystick => ControlDeviceType.Joystick, 
				QjbGhnqBRCdfATtVFynSOZBkFBzV.Gamepad => ControlDeviceType.Gamepad, 
				QjbGhnqBRCdfATtVFynSOZBkFBzV.Keyboard => ControlDeviceType.Keyboard, 
				QjbGhnqBRCdfATtVFynSOZBkFBzV.Mouse => ControlDeviceType.Mouse, 
				_ => ControlDeviceType.Unknown, 
			};
		}

		private void yFvGQualYZctsMliCPBksUQmIqRN()
		{
			HKuVpwSviKyiEvhPQTGnkdHJUjQK = quLWSAAKRKXgPsxQmuatlwQtlLRb(cimpVopqtQvynvtkznCgDnWjHuaR());
			if (HKuVpwSviKyiEvhPQTGnkdHJUjQK == null)
			{
				Logger.LogError("Default hardware map not found!");
				return;
			}
			if (HKuVpwSviKyiEvhPQTGnkdHJUjQK.useSystemName)
			{
				if (!string.IsNullOrEmpty(nicrENHFqXKlVdkXFNvPSMjaOUsT))
				{
					string text = Regex.Replace(nicrENHFqXKlVdkXFNvPSMjaOUsT, "\\s+", " ");
					text = text.Trim();
					if (!string.IsNullOrEmpty(text))
					{
						HKuVpwSviKyiEvhPQTGnkdHJUjQK.controllerName = text;
					}
				}
				if (HKuVpwSviKyiEvhPQTGnkdHJUjQK.deviceLocalizationInfo.parentKeys.get_Count() > 0 && !string.IsNullOrEmpty(HKuVpwSviKyiEvhPQTGnkdHJUjQK.deviceLocalizationInfo.parentKeys.get_Item(0)))
				{
					string a = HKuVpwSviKyiEvhPQTGnkdHJUjQK.deviceLocalizationInfo.parentKeys.get_Item(0);
					string text2 = string.Format("{0}:{1}", LahAkGtJiZxAjTcliiOkmEqzhIjs.qUgwVyLLmLcUUBerKKbjcJDexDJRb().vendorId.ToString("x4"), LahAkGtJiZxAjTcliiOkmEqzhIjs.qUgwVyLLmLcUUBerKKbjcJDexDJRb().productId.ToString("x4"));
					HKuVpwSviKyiEvhPQTGnkdHJUjQK.deviceLocalizationInfo.InsertParentKey(0, LocalizationManager.AppendToKeyAsPath(a, text2));
					if (!string.IsNullOrEmpty(LahAkGtJiZxAjTcliiOkmEqzhIjs.dGLILdbmHNoHyMXNMxkRowrIAszb()))
					{
						HKuVpwSviKyiEvhPQTGnkdHJUjQK.deviceLocalizationInfo.InsertParentKey(1, LocalizationManager.AppendToKeyAsPath(a, LahAkGtJiZxAjTcliiOkmEqzhIjs.dGLILdbmHNoHyMXNMxkRowrIAszb()));
					}
					if (!string.IsNullOrEmpty(LahAkGtJiZxAjTcliiOkmEqzhIjs.dGLILdbmHNoHyMXNMxkRowrIAszb()))
					{
						HKuVpwSviKyiEvhPQTGnkdHJUjQK.deviceLocalizationInfo.additionalIdentifyingInformation = $"{LahAkGtJiZxAjTcliiOkmEqzhIjs.dGLILdbmHNoHyMXNMxkRowrIAszb()} [{text2}]";
					}
					else
					{
						HKuVpwSviKyiEvhPQTGnkdHJUjQK.deviceLocalizationInfo.additionalIdentifyingInformation = $"[{text2}]";
					}
				}
			}
			HHZlNXNqGaCiCXKQUiaFBOJdEqrJA = HKuVpwSviKyiEvhPQTGnkdHJUjQK.axisCount;
			efTMucZlTDGRvMsGdGhrBBCYRHoY = HKuVpwSviKyiEvhPQTGnkdHJUjQK.buttonCount;
		}

		private string gWtzvwGgLcHAAzGLwVMHBIxnvdKW()
		{
			return InputTools.FormatHardwareIdentifierString($"{ReInput.currentPlatform.ToString()}{LahAkGtJiZxAjTcliiOkmEqzhIjs.ZjVuQuqTNNOFWFlEPWQDCrnSNvgp()}{WrtpAoXwWETrUZTtJhtetHLsIHHn}{RQWAPKZFrfgEvhBxudBcdTEpMeQpA}{MRsubxMOGRFOyjhiPSdWcoTdBSlB.ToProductGuid()}");
		}

		private void FZuLxBbciTBekHcRJBWzCrcJvREPA(BridgedControllerHWInfo P_0)
		{
			P_0.inputManagerSource = InputSource.SDL2;
			P_0.inputSource = LahAkGtJiZxAjTcliiOkmEqzhIjs.ZjVuQuqTNNOFWFlEPWQDCrnSNvgp();
			P_0.deviceType = omSXwzBHpqHnWJlFzeoUJaqASDsLA(XEjbSoDBtAUGYKoSgbwvrNysdCqUA);
			P_0.hardwareIdentifier = gWtzvwGgLcHAAzGLwVMHBIxnvdKW();
			P_0.hardwareAxisCount = hjEYFJEzBaDrosOXeqWCWoWnqWhs;
			P_0.hardwareButtonCount = xMEaREoWNcSGzYiYqfrkkivsuWGG;
			P_0.hardwareHatCount = ftWEOiHRGsvUtgJSPCLVIuDcJoYCb;
			P_0.hw_productName = WrtpAoXwWETrUZTtJhtetHLsIHHn;
			P_0.hw_deviceGuid = rPPRgAgSJtpIocaNdDJwlRQCrzDB;
			P_0.hw_productId = RQWAPKZFrfgEvhBxudBcdTEpMeQpA;
			P_0.hw_pidVid = MRsubxMOGRFOyjhiPSdWcoTdBSlB;
			P_0.hw_isBluetoothDevice = SaFtroSEuHAgybkOcMvhIbgQUqvR;
			P_0.hw_bluetoothDeviceName = WrtpAoXwWETrUZTtJhtetHLsIHHn;
			P_0.hw_systemDeviceName = WrtpAoXwWETrUZTtJhtetHLsIHHn;
			P_0.hw_supportsVibration = bZoOOpSEoENenWtIXpTiPEqqpgoq;
			P_0.hw_isSDL2Gamepad = LahAkGtJiZxAjTcliiOkmEqzhIjs.MwWGIFVJNWdQrhQHyBFYbWdhAmtzB() == QjbGhnqBRCdfATtVFynSOZBkFBzV.Gamepad;
			P_0.hw_localVibrationMotorCount = ebvKFLbQnTzHdKVCxwlBoRBOSnJb;
		}

		private void pxGdePbkakPoeRtyJjEycAxdLqZic(BridgedController P_0)
		{
			FZuLxBbciTBekHcRJBWzCrcJvREPA(P_0);
			P_0.sourceJoystick = this;
			P_0.gameHardwareMap = HKuVpwSviKyiEvhPQTGnkdHJUjQK.ToGameHardwareControllerMap();
			P_0.instanceName = WrtpAoXwWETrUZTtJhtetHLsIHHn;
			P_0.productName = WrtpAoXwWETrUZTtJhtetHLsIHHn;
			P_0.axisCount = HHZlNXNqGaCiCXKQUiaFBOJdEqrJA;
			P_0.buttonCount = efTMucZlTDGRvMsGdGhrBBCYRHoY;
			P_0.unknownControllerHats = qNEdBTEuvexPzJbLPEEYKAvIXHkLA();
			P_0.controllerTypeGuid = uiKqASkaAZQktWEvmlpbpxpiEEcB;
			P_0.controllerExtension = get_extension();
		}

		private void RoQdwSvlbUtLTxnqvybVQbwvHznb()
		{
			for (int i = 0; i < efTMucZlTDGRvMsGdGhrBBCYRHoY; i++)
			{
				kbuuMziZHgndRBEycAbAbVxFGnlf[i] = false;
			}
			for (int j = 0; j < HHZlNXNqGaCiCXKQUiaFBOJdEqrJA; j++)
			{
				ahHeraGgWUliikSOXpUoUqobEAXf[j] = 0f;
			}
		}

		private UnknownControllerHat[] qNEdBTEuvexPzJbLPEEYKAvIXHkLA()
		{
			if (!RFtICkRhwuWLmBPGeDeFbFRIfyJfA)
			{
				return null;
			}
			UnknownControllerHat[] array = new UnknownControllerHat[2];
			for (int i = 0; i < 2; i++)
			{
				int num = 128 + i * 8;
				UnknownControllerHat.HatButtons hatButtons = new UnknownControllerHat.HatButtons(new int[8]
				{
					num,
					num + 1,
					num + 2,
					num + 3,
					num + 4,
					num + 5,
					num + 6,
					num + 7
				});
				array[i] = new UnknownControllerHat(hatButtons);
			}
			return array;
		}

		public static int RTbcvDToxXKmnybfysJGtTHdeoYF(gEkAlBetTyTJTStTskBnWuobEWQjA P_0, gEkAlBetTyTJTStTskBnWuobEWQjA P_1)
		{
			if (P_0.ewJEmceTOCUMtxvkGtGGiTEBAVHb < P_1.ewJEmceTOCUMtxvkGtGGiTEBAVHb)
			{
				return -1;
			}
			if (P_0.ewJEmceTOCUMtxvkGtGGiTEBAVHb > P_1.ewJEmceTOCUMtxvkGtGGiTEBAVHb)
			{
				return 1;
			}
			return 0;
		}

		public static int qjRKmPhIzzGBOzoBMYSKDSmwiHox(gEkAlBetTyTJTStTskBnWuobEWQjA P_0, gEkAlBetTyTJTStTskBnWuobEWQjA P_1)
		{
			if (P_0.ibJLgibNXxHCcZLMJuOdMmpGbwVAA < P_1.ibJLgibNXxHCcZLMJuOdMmpGbwVAA)
			{
				return -1;
			}
			if (P_0.ibJLgibNXxHCcZLMJuOdMmpGbwVAA > P_1.ibJLgibNXxHCcZLMJuOdMmpGbwVAA)
			{
				return 1;
			}
			return 0;
		}
	}

	private class alSEZIFZjZkyrzPCiYrvOIkxdAiI
	{
		public enum CzAkcycEKKCRweMupXOcalJwZdfS
		{
			Exact = 0,
			Approximate = 1
		}

		public class RGfIExesvIxrOQpmrsqZcKucuqfh
		{
			public int nUKDaFgUmTSBwwqvYZrOENPhdtFeA;

			public Guid gTYTRNLcFePJbPIXXLtzntUzpNR;

			public Guid ViUebKYNILJTQNVVxGwzFNCmqbUP;

			public int GLpWCpJucowAlwlfaEnESaNDCLAbA;

			public int SAXFssJkpxEoplUJNauRavnVoKEnA;

			public int VbBGpBEYWWwJVihataYFaswxipZO;

			public int QvsfEvGSyOkEgynebcLxGCYapHwK;

			public bool HdShtocEkSOSFeXCEMesMGPzmIPAc(gEkAlBetTyTJTStTskBnWuobEWQjA P_0, CzAkcycEKKCRweMupXOcalJwZdfS P_1)
			{
				if (P_0.get_rewiredId() == nUKDaFgUmTSBwwqvYZrOENPhdtFeA)
				{
					return true;
				}
				if (SAXFssJkpxEoplUJNauRavnVoKEnA != P_0.hjEYFJEzBaDrosOXeqWCWoWnqWhs)
				{
					return false;
				}
				if (VbBGpBEYWWwJVihataYFaswxipZO != P_0.xMEaREoWNcSGzYiYqfrkkivsuWGG)
				{
					return false;
				}
				if (QvsfEvGSyOkEgynebcLxGCYapHwK != P_0.ftWEOiHRGsvUtgJSPCLVIuDcJoYCb)
				{
					return false;
				}
				return P_1 switch
				{
					CzAkcycEKKCRweMupXOcalJwZdfS.Exact => gTYTRNLcFePJbPIXXLtzntUzpNR == P_0.rPPRgAgSJtpIocaNdDJwlRQCrzDB, 
					CzAkcycEKKCRweMupXOcalJwZdfS.Approximate => ViUebKYNILJTQNVVxGwzFNCmqbUP == P_0.RekqLcxtbuhdnKNgkZREtMrBZZDf, 
					_ => throw new NotImplementedException(), 
				};
			}
		}

		private sealed class wyitwnRYoqSLlgLMwqgoowBeRcAo : IEnumerable<RGfIExesvIxrOQpmrsqZcKucuqfh>, IEnumerable, IEnumerator<RGfIExesvIxrOQpmrsqZcKucuqfh>, IEnumerator, IDisposable
		{
			private int lVJmlrzIbEOATTrnHuGSYeQGPwAC;

			private RGfIExesvIxrOQpmrsqZcKucuqfh JwnCPnfYQOfqulNeONBBfSgcdTgB;

			private int NOtDcveiIjdOEUqLobiJJXRKyeNNA;

			public alSEZIFZjZkyrzPCiYrvOIkxdAiI qvjjaCHPheBwsgLRisaLqhSidkoKA;

			private gEkAlBetTyTJTStTskBnWuobEWQjA DUPadGIApPUXsbQSIHxvPTLygPYIA;

			public gEkAlBetTyTJTStTskBnWuobEWQjA DGEWezyYjatmdmwkohTrOaseiNQc;

			private CzAkcycEKKCRweMupXOcalJwZdfS OmmYsYKRVpQIzvefybLIpllOBbzj;

			public CzAkcycEKKCRweMupXOcalJwZdfS rXDLfHLCWtsTCHrwZfscxpGIrQjE;

			private int IVuxqsvJkNGCIKIVqhvndfUBmPbOb;

			private int LyEFOpPxLFWOepDLoYrqCORrdTLP;

			RGfIExesvIxrOQpmrsqZcKucuqfh IEnumerator<RGfIExesvIxrOQpmrsqZcKucuqfh>.Current
			{
				[DebuggerHidden]
				get
				{
					return System_002ECollections_002EGeneric_002EIEnumerator_003CRewired_002EInputSources_002ESDL2_002ESDL2InputManager_002EJoystickRecords_002ERecord_003E_002Eget_Current();
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return JwnCPnfYQOfqulNeONBBfSgcdTgB;
				}
			}

			[DebuggerHidden]
			public wyitwnRYoqSLlgLMwqgoowBeRcAo(int P_0)
			{
				lVJmlrzIbEOATTrnHuGSYeQGPwAC = P_0;
				NOtDcveiIjdOEUqLobiJJXRKyeNNA = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int num = lVJmlrzIbEOATTrnHuGSYeQGPwAC;
				alSEZIFZjZkyrzPCiYrvOIkxdAiI alSEZIFZjZkyrzPCiYrvOIkxdAiI2 = qvjjaCHPheBwsgLRisaLqhSidkoKA;
				if (num != 0)
				{
					if (num != 1)
					{
						return false;
					}
					lVJmlrzIbEOATTrnHuGSYeQGPwAC = -1;
					goto IL_0083;
				}
				lVJmlrzIbEOATTrnHuGSYeQGPwAC = -1;
				IVuxqsvJkNGCIKIVqhvndfUBmPbOb = alSEZIFZjZkyrzPCiYrvOIkxdAiI2.OUmwuvMWLHmXWDsxeNcMCaeHWasb.Count;
				LyEFOpPxLFWOepDLoYrqCORrdTLP = 0;
				goto IL_0093;
				IL_0083:
				LyEFOpPxLFWOepDLoYrqCORrdTLP++;
				goto IL_0093;
				IL_0093:
				if (LyEFOpPxLFWOepDLoYrqCORrdTLP < IVuxqsvJkNGCIKIVqhvndfUBmPbOb)
				{
					if (alSEZIFZjZkyrzPCiYrvOIkxdAiI2.OUmwuvMWLHmXWDsxeNcMCaeHWasb[LyEFOpPxLFWOepDLoYrqCORrdTLP].HdShtocEkSOSFeXCEMesMGPzmIPAc(DUPadGIApPUXsbQSIHxvPTLygPYIA, OmmYsYKRVpQIzvefybLIpllOBbzj))
					{
						JwnCPnfYQOfqulNeONBBfSgcdTgB = alSEZIFZjZkyrzPCiYrvOIkxdAiI2.OUmwuvMWLHmXWDsxeNcMCaeHWasb[LyEFOpPxLFWOepDLoYrqCORrdTLP];
						lVJmlrzIbEOATTrnHuGSYeQGPwAC = 1;
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
			private RGfIExesvIxrOQpmrsqZcKucuqfh System_002ECollections_002EGeneric_002EIEnumerator_003CRewired_002EInputSources_002ESDL2_002ESDL2InputManager_002EJoystickRecords_002ERecord_003E_002Eget_Current()
			{
				return JwnCPnfYQOfqulNeONBBfSgcdTgB;
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
				throw new NotSupportedException();
			}

			[DebuggerHidden]
			IEnumerator<RGfIExesvIxrOQpmrsqZcKucuqfh> IEnumerable<RGfIExesvIxrOQpmrsqZcKucuqfh>.GetEnumerator()
			{
				wyitwnRYoqSLlgLMwqgoowBeRcAo wyitwnRYoqSLlgLMwqgoowBeRcAo2;
				if (lVJmlrzIbEOATTrnHuGSYeQGPwAC == -2 && NOtDcveiIjdOEUqLobiJJXRKyeNNA == Environment.CurrentManagedThreadId)
				{
					lVJmlrzIbEOATTrnHuGSYeQGPwAC = 0;
					wyitwnRYoqSLlgLMwqgoowBeRcAo2 = this;
				}
				else
				{
					wyitwnRYoqSLlgLMwqgoowBeRcAo2 = new wyitwnRYoqSLlgLMwqgoowBeRcAo(0);
					wyitwnRYoqSLlgLMwqgoowBeRcAo2.qvjjaCHPheBwsgLRisaLqhSidkoKA = qvjjaCHPheBwsgLRisaLqhSidkoKA;
				}
				wyitwnRYoqSLlgLMwqgoowBeRcAo2.DUPadGIApPUXsbQSIHxvPTLygPYIA = DGEWezyYjatmdmwkohTrOaseiNQc;
				wyitwnRYoqSLlgLMwqgoowBeRcAo2.OmmYsYKRVpQIzvefybLIpllOBbzj = rXDLfHLCWtsTCHrwZfscxpGIrQjE;
				return wyitwnRYoqSLlgLMwqgoowBeRcAo2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<RGfIExesvIxrOQpmrsqZcKucuqfh>)this).GetEnumerator();
			}
		}

		private List<RGfIExesvIxrOQpmrsqZcKucuqfh> OUmwuvMWLHmXWDsxeNcMCaeHWasb;

		public alSEZIFZjZkyrzPCiYrvOIkxdAiI()
		{
			OUmwuvMWLHmXWDsxeNcMCaeHWasb = new List<RGfIExesvIxrOQpmrsqZcKucuqfh>();
		}

		public void aiFcdcmHdkhEZgfxAcFNAnvwOeagb(gEkAlBetTyTJTStTskBnWuobEWQjA P_0)
		{
			if (P_0 == null)
			{
				return;
			}
			int count = OUmwuvMWLHmXWDsxeNcMCaeHWasb.Count;
			for (int i = 0; i < count; i++)
			{
				if (OUmwuvMWLHmXWDsxeNcMCaeHWasb[i].HdShtocEkSOSFeXCEMesMGPzmIPAc(P_0, CzAkcycEKKCRweMupXOcalJwZdfS.Exact))
				{
					OUmwuvMWLHmXWDsxeNcMCaeHWasb[i].nUKDaFgUmTSBwwqvYZrOENPhdtFeA = P_0.get_rewiredId();
					OUmwuvMWLHmXWDsxeNcMCaeHWasb[i].gTYTRNLcFePJbPIXXLtzntUzpNR = P_0.rPPRgAgSJtpIocaNdDJwlRQCrzDB;
					OUmwuvMWLHmXWDsxeNcMCaeHWasb[i].ViUebKYNILJTQNVVxGwzFNCmqbUP = P_0.RekqLcxtbuhdnKNgkZREtMrBZZDf;
					OUmwuvMWLHmXWDsxeNcMCaeHWasb[i].GLpWCpJucowAlwlfaEnESaNDCLAbA = P_0.get_inputManagerId();
					OUmwuvMWLHmXWDsxeNcMCaeHWasb[i].SAXFssJkpxEoplUJNauRavnVoKEnA = P_0.hjEYFJEzBaDrosOXeqWCWoWnqWhs;
					OUmwuvMWLHmXWDsxeNcMCaeHWasb[i].VbBGpBEYWWwJVihataYFaswxipZO = P_0.xMEaREoWNcSGzYiYqfrkkivsuWGG;
					OUmwuvMWLHmXWDsxeNcMCaeHWasb[i].QvsfEvGSyOkEgynebcLxGCYapHwK = P_0.ftWEOiHRGsvUtgJSPCLVIuDcJoYCb;
					IvQmUbXIdkpnitMKBQElRjfzNKCK(P_0.get_rewiredId(), P_0.rPPRgAgSJtpIocaNdDJwlRQCrzDB, i);
					return;
				}
			}
			OUmwuvMWLHmXWDsxeNcMCaeHWasb.Add(new RGfIExesvIxrOQpmrsqZcKucuqfh
			{
				nUKDaFgUmTSBwwqvYZrOENPhdtFeA = P_0.get_rewiredId(),
				gTYTRNLcFePJbPIXXLtzntUzpNR = P_0.rPPRgAgSJtpIocaNdDJwlRQCrzDB,
				ViUebKYNILJTQNVVxGwzFNCmqbUP = P_0.RekqLcxtbuhdnKNgkZREtMrBZZDf,
				GLpWCpJucowAlwlfaEnESaNDCLAbA = P_0.get_inputManagerId(),
				SAXFssJkpxEoplUJNauRavnVoKEnA = P_0.hjEYFJEzBaDrosOXeqWCWoWnqWhs,
				VbBGpBEYWWwJVihataYFaswxipZO = P_0.xMEaREoWNcSGzYiYqfrkkivsuWGG,
				QvsfEvGSyOkEgynebcLxGCYapHwK = P_0.ftWEOiHRGsvUtgJSPCLVIuDcJoYCb
			});
			IvQmUbXIdkpnitMKBQElRjfzNKCK(P_0.get_rewiredId(), P_0.rPPRgAgSJtpIocaNdDJwlRQCrzDB, OUmwuvMWLHmXWDsxeNcMCaeHWasb.Count - 1);
		}

		public bool wWSzqmTuuARgJeiSNjETUnngDXtC(gEkAlBetTyTJTStTskBnWuobEWQjA P_0, CzAkcycEKKCRweMupXOcalJwZdfS P_1)
		{
			int count = OUmwuvMWLHmXWDsxeNcMCaeHWasb.Count;
			for (int i = 0; i < count; i++)
			{
				if (OUmwuvMWLHmXWDsxeNcMCaeHWasb[i].HdShtocEkSOSFeXCEMesMGPzmIPAc(P_0, P_1))
				{
					return true;
				}
			}
			return false;
		}

		[IteratorStateMachine(typeof(wyitwnRYoqSLlgLMwqgoowBeRcAo))]
		public IEnumerable<RGfIExesvIxrOQpmrsqZcKucuqfh> WnnRLljJUMyIBdcreMSuQdvCtRYL(gEkAlBetTyTJTStTskBnWuobEWQjA P_0, CzAkcycEKKCRweMupXOcalJwZdfS P_1)
		{
			return new wyitwnRYoqSLlgLMwqgoowBeRcAo(-2)
			{
				qvjjaCHPheBwsgLRisaLqhSidkoKA = this,
				DGEWezyYjatmdmwkohTrOaseiNQc = P_0,
				rXDLfHLCWtsTCHrwZfscxpGIrQjE = P_1
			};
		}

		private void IvQmUbXIdkpnitMKBQElRjfzNKCK(int P_0, Guid P_1, int P_2)
		{
			for (int num = OUmwuvMWLHmXWDsxeNcMCaeHWasb.Count - 1; num >= 0; num--)
			{
				if (num != P_2 && (OUmwuvMWLHmXWDsxeNcMCaeHWasb[num].nUKDaFgUmTSBwwqvYZrOENPhdtFeA == P_0 || OUmwuvMWLHmXWDsxeNcMCaeHWasb[num].gTYTRNLcFePJbPIXXLtzntUzpNR == P_1))
				{
					OUmwuvMWLHmXWDsxeNcMCaeHWasb.RemoveAt(num);
				}
			}
		}
	}

	internal const bool RMzHqbGXllEgMmktyTLePNcVfPNC = true;

	private IInputSource iDHZcJIzakoEMdXzpzfIDXLmhEuE;

	private List<gEkAlBetTyTJTStTskBnWuobEWQjA> nlyXuLcpvaRiFyGPmrPeeGRqowiC;

	private int bKMzsaPPTNvweARgnhrTxHrsgDzaA;

	private alSEZIFZjZkyrzPCiYrvOIkxdAiI VcHfjHGuxyfVtAwtrHHxIhvIxBbJ;

	private bool wZmBNeEKXbNqepvRHBzpdmjgdCSqB;

	private Action<int, ControllerDataUpdater> elNBhEPZNMpOrekBFbAgjmhrZlwQA;

	private PlatformInputManager oBwfLcbofIQbBKNiBKCmzCfhZByb;

	private readonly bool NTKWYcCkznITfQGyFXDADfrIPXrI;

	private readonly bool HkHKlObujnILDcTMFniXggGsBWYu;

	private readonly bool TXGwujwQsOFtRuHIwyvibzBxCQkc;

	private readonly Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> wZkRkukEVqZQltvDvMKJFrMffOPc;

	private readonly Func<int> woIuxuYARKhQjmplvgBTBEsfeOjdb;

	[CustomObfuscation(rename = false)]
	int PlatformInputManager.deviceCount => get_deviceCount();

	[CustomObfuscation(rename = false)]
	PlatformInputManager PlatformInputManager.primaryInputManager => get_primaryInputManager();

	[CustomObfuscation(rename = false)]
	IInputSource PlatformInputManager.inputSource => get_inputSource();

	[CustomObfuscation(rename = false)]
	InputSource PlatformInputManager.inputSourceType => get_inputSourceType();

	public QTMrFJnvXCFHNDKQVmcIvGDUKQOG(ConfigVars P_0, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> P_1, Func<int> P_2, bool P_3, bool P_4, bool P_5)
	{
		try
		{
			wZkRkukEVqZQltvDvMKJFrMffOPc = P_1;
			woIuxuYARKhQjmplvgBTBEsfeOjdb = P_2;
			NTKWYcCkznITfQGyFXDADfrIPXrI = P_3;
			HkHKlObujnILDcTMFniXggGsBWYu = P_4;
			TXGwujwQsOFtRuHIwyvibzBxCQkc = P_5;
			oBwfLcbofIQbBKNiBKCmzCfhZByb = this;
			iDHZcJIzakoEMdXzpzfIDXLmhEuE = new SDL2InputSource(P_0.updateLoop, P_3, P_3, P_4, P_5);
			elNBhEPZNMpOrekBFbAgjmhrZlwQA = UpdateControllerData;
			iDHZcJIzakoEMdXzpzfIDXLmhEuE.DeviceChangedEvent += QxUzcPhCTNcneYytINxvZqAuwfji;
		}
		catch (Exception)
		{
			OnDestroy();
			throw;
		}
	}

	public virtual int get_deviceCount()
	{
		return bKMzsaPPTNvweARgnhrTxHrsgDzaA;
	}

	public virtual PlatformInputManager get_primaryInputManager()
	{
		return oBwfLcbofIQbBKNiBKCmzCfhZByb;
	}

	public virtual IInputSource get_inputSource()
	{
		return iDHZcJIzakoEMdXzpzfIDXLmhEuE;
	}

	public virtual InputSource get_inputSourceType()
	{
		return InputSource.SDL2;
	}

	[CustomObfuscation(rename = false)]
	public override void Initialize()
	{
		if (NTKWYcCkznITfQGyFXDADfrIPXrI)
		{
			VcHfjHGuxyfVtAwtrHHxIhvIxBbJ = new alSEZIFZjZkyrzPCiYrvOIkxdAiI();
			IiSeDAHgEABMEEuJMfVHLYydgtxhA();
		}
	}

	[CustomObfuscation(rename = false)]
	public override void Update(UpdateLoopType updateLoop)
	{
		if (iDHZcJIzakoEMdXzpzfIDXLmhEuE != null)
		{
			iDHZcJIzakoEMdXzpzfIDXLmhEuE.Update();
		}
		if (NTKWYcCkznITfQGyFXDADfrIPXrI)
		{
			if (wZmBNeEKXbNqepvRHBzpdmjgdCSqB)
			{
				boSbYTHXwZdUJosoRCUyTWthkuse();
			}
			if (iDHZcJIzakoEMdXzpzfIDXLmhEuE != null)
			{
				for (int i = 0; i < bKMzsaPPTNvweARgnhrTxHrsgDzaA; i++)
				{
					nlyXuLcpvaRiFyGPmrPeeGRqowiC[i]?.LahAkGtJiZxAjTcliiOkmEqzhIjs.jWgbigWLOCDzGXDeFkaCjjcwtgVE(updateLoop);
				}
				iDHZcJIzakoEMdXzpzfIDXLmhEuE.UpdateDevices(updateLoop);
			}
			XRlVMqkkLbBggbwxFTbiPTAqiufw();
			if (iDHZcJIzakoEMdXzpzfIDXLmhEuE != null)
			{
				iDHZcJIzakoEMdXzpzfIDXLmhEuE.UpdateFinished();
				for (int j = 0; j < bKMzsaPPTNvweARgnhrTxHrsgDzaA; j++)
				{
					nlyXuLcpvaRiFyGPmrPeeGRqowiC[j]?.LahAkGtJiZxAjTcliiOkmEqzhIjs.PVdboezfikBRRHAFDxmhSfeqYbUeA();
				}
			}
		}
		_ = HkHKlObujnILDcTMFniXggGsBWYu;
	}

	[CustomObfuscation(rename = false)]
	public override void OnDestroy()
	{
		if (nlyXuLcpvaRiFyGPmrPeeGRqowiC != null)
		{
			int count = nlyXuLcpvaRiFyGPmrPeeGRqowiC.Count;
			for (int i = 0; i < count; i++)
			{
				if (nlyXuLcpvaRiFyGPmrPeeGRqowiC[i] != null)
				{
					nlyXuLcpvaRiFyGPmrPeeGRqowiC[i].LahAkGtJiZxAjTcliiOkmEqzhIjs?.atHmHczhDAEpiCpTIobHHWUDGeijA();
				}
			}
		}
		if (iDHZcJIzakoEMdXzpzfIDXLmhEuE != null)
		{
			iDHZcJIzakoEMdXzpzfIDXLmhEuE.Dispose();
		}
	}

	[CustomObfuscation(rename = false)]
	public override Action<int, ControllerDataUpdater> GetInputDataUpdateDelegate()
	{
		return elNBhEPZNMpOrekBFbAgjmhrZlwQA;
	}

	[CustomObfuscation(rename = false)]
	public override void UpdateControllerData(int inputManagerId, ControllerDataUpdater data)
	{
		if (!NTKWYcCkznITfQGyFXDADfrIPXrI)
		{
			return;
		}
		for (int i = 0; i < bKMzsaPPTNvweARgnhrTxHrsgDzaA; i++)
		{
			if (nlyXuLcpvaRiFyGPmrPeeGRqowiC[i].get_inputManagerId() == inputManagerId)
			{
				nlyXuLcpvaRiFyGPmrPeeGRqowiC[i].FillData(data);
				break;
			}
		}
	}

	[CustomObfuscation(rename = false)]
	public override void SystemDeviceConnected()
	{
		if (NTKWYcCkznITfQGyFXDADfrIPXrI)
		{
			wZmBNeEKXbNqepvRHBzpdmjgdCSqB = true;
		}
		if (_SystemDeviceConnectedEvent != null)
		{
			_SystemDeviceConnectedEvent();
		}
	}

	[CustomObfuscation(rename = false)]
	public override void SystemDeviceDisconnected()
	{
		if (NTKWYcCkznITfQGyFXDADfrIPXrI)
		{
			wZmBNeEKXbNqepvRHBzpdmjgdCSqB = true;
		}
		if (_SystemDeviceDisconnectedEvent != null)
		{
			_SystemDeviceDisconnectedEvent();
		}
	}

	[CustomObfuscation(rename = false)]
	public override void SetUnityJoystickId(int joystickId, int unityJoystickId)
	{
		_ = NTKWYcCkznITfQGyFXDADfrIPXrI;
	}

	[CustomObfuscation(rename = false)]
	public override IUnifiedMouseSource GetUnifiedMouseSource()
	{
		return null;
	}

	[CustomObfuscation(rename = false)]
	public override IUnifiedKeyboardSource GetUnifiedKeyboardSource()
	{
		return null;
	}

	private void IiSeDAHgEABMEEuJMfVHLYydgtxhA()
	{
		uzXjfsbCdGiKZENnhKmOIAjatCiQb(JVRSrlLcLBHJOWiSqxtJtweMOsRF());
	}

	private void uzXjfsbCdGiKZENnhKmOIAjatCiQb(IList<wfXvpNxXWJkwQbGkekNHCgrsJhAN> P_0)
	{
		int num = 0;
		List<gEkAlBetTyTJTStTskBnWuobEWQjA> list = nlyXuLcpvaRiFyGPmrPeeGRqowiC;
		int num2 = bKMzsaPPTNvweARgnhrTxHrsgDzaA;
		nlyXuLcpvaRiFyGPmrPeeGRqowiC = new List<gEkAlBetTyTJTStTskBnWuobEWQjA>();
		int count = P_0.Count;
		for (int i = 0; i < count; i++)
		{
			if (P_0[i] != null)
			{
				wfXvpNxXWJkwQbGkekNHCgrsJhAN wfXvpNxXWJkwQbGkekNHCgrsJhAN2 = P_0[i];
				gEkAlBetTyTJTStTskBnWuobEWQjA gEkAlBetTyTJTStTskBnWuobEWQjA2 = new gEkAlBetTyTJTStTskBnWuobEWQjA(wZkRkukEVqZQltvDvMKJFrMffOPc);
				gEkAlBetTyTJTStTskBnWuobEWQjA2.LahAkGtJiZxAjTcliiOkmEqzhIjs = wfXvpNxXWJkwQbGkekNHCgrsJhAN2;
				gEkAlBetTyTJTStTskBnWuobEWQjA2.rPPRgAgSJtpIocaNdDJwlRQCrzDB = wfXvpNxXWJkwQbGkekNHCgrsJhAN2.XJreFUOKwAuuiHjzkeBdhqsrqtQpA();
				gEkAlBetTyTJTStTskBnWuobEWQjA2.WrtpAoXwWETrUZTtJhtetHLsIHHn = wfXvpNxXWJkwQbGkekNHCgrsJhAN2.dGLILdbmHNoHyMXNMxkRowrIAszb();
				gEkAlBetTyTJTStTskBnWuobEWQjA2.nicrENHFqXKlVdkXFNvPSMjaOUsT = wfXvpNxXWJkwQbGkekNHCgrsJhAN2.TAoZJvkIyXAdHkaxEKrGvYbvBTHAA();
				gEkAlBetTyTJTStTskBnWuobEWQjA2.MRsubxMOGRFOyjhiPSdWcoTdBSlB = wfXvpNxXWJkwQbGkekNHCgrsJhAN2.qUgwVyLLmLcUUBerKKbjcJDexDJRb();
				gEkAlBetTyTJTStTskBnWuobEWQjA2.RQWAPKZFrfgEvhBxudBcdTEpMeQpA = wfXvpNxXWJkwQbGkekNHCgrsJhAN2.vkHCzyGdiwDEVFzLQnmvQkIGDqtD();
				gEkAlBetTyTJTStTskBnWuobEWQjA2.UjLWVWLYPhhbPjqwKIcOmSoPTYag = wfXvpNxXWJkwQbGkekNHCgrsJhAN2.kfISYvMxxuQNHGCDoaaIAmXSmCTdb();
				gEkAlBetTyTJTStTskBnWuobEWQjA2.XEjbSoDBtAUGYKoSgbwvrNysdCqUA = wfXvpNxXWJkwQbGkekNHCgrsJhAN2.MwWGIFVJNWdQrhQHyBFYbWdhAmtzB();
				gEkAlBetTyTJTStTskBnWuobEWQjA2.ibJLgibNXxHCcZLMJuOdMmpGbwVAA = wfXvpNxXWJkwQbGkekNHCgrsJhAN2.TzTdCpBUKOmImHYDcQcMxTCMNNfbb();
				gEkAlBetTyTJTStTskBnWuobEWQjA2.hjEYFJEzBaDrosOXeqWCWoWnqWhs = wfXvpNxXWJkwQbGkekNHCgrsJhAN2.YkrDFFNAmEnPpwLFVnMpAeVMOXdi();
				gEkAlBetTyTJTStTskBnWuobEWQjA2.xMEaREoWNcSGzYiYqfrkkivsuWGG = wfXvpNxXWJkwQbGkekNHCgrsJhAN2.paxilWhHWQeQVFOrDIunZXyFYUYhA();
				gEkAlBetTyTJTStTskBnWuobEWQjA2.ftWEOiHRGsvUtgJSPCLVIuDcJoYCb = wfXvpNxXWJkwQbGkekNHCgrsJhAN2.ZTbqASFOCnHdvOqwsqsNHIcgkzac();
				gEkAlBetTyTJTStTskBnWuobEWQjA2.SaFtroSEuHAgybkOcMvhIbgQUqvR = wfXvpNxXWJkwQbGkekNHCgrsJhAN2.TwqoYVQAYcpwFlEXhtZyhhsoKXeb();
				gEkAlBetTyTJTStTskBnWuobEWQjA2.bZoOOpSEoENenWtIXpTiPEqqpgoq = wfXvpNxXWJkwQbGkekNHCgrsJhAN2.WHvTnevjsmuCXBRnJmZgSVjQsPqV();
				gEkAlBetTyTJTStTskBnWuobEWQjA2.ebvKFLbQnTzHdKVCxwlBoRBOSnJb = wfXvpNxXWJkwQbGkekNHCgrsJhAN2.AJSSHDIJnERcoMlgXQodWfoNgQPX();
				gEkAlBetTyTJTStTskBnWuobEWQjA2.set_extension(wfXvpNxXWJkwQbGkekNHCgrsJhAN2.nAgnwKGceZKFTwZghGCyOUCfwwCS());
				wfXvpNxXWJkwQbGkekNHCgrsJhAN2.eqJjBkXpYVuwehoATwkvhlXVesoaA();
				gEkAlBetTyTJTStTskBnWuobEWQjA2.SGscNXSdUFkFGnxkVjcvEDLtufAN();
				nlyXuLcpvaRiFyGPmrPeeGRqowiC.Add(gEkAlBetTyTJTStTskBnWuobEWQjA2);
				num++;
			}
		}
		bKMzsaPPTNvweARgnhrTxHrsgDzaA = num;
		nTQLVzzfjcESHKvMdwYnhXnxnNWdA(num2, num, list, nlyXuLcpvaRiFyGPmrPeeGRqowiC);
		for (int j = 0; j < num; j++)
		{
			if (_UpdateControllerInfoEvent != null)
			{
				_UpdateControllerInfoEvent(new UpdateControllerInfoEventArgs(nlyXuLcpvaRiFyGPmrPeeGRqowiC[j]));
			}
		}
		NiYoEDXoQQcltrGrBdPUXknEtSeu(list, nlyXuLcpvaRiFyGPmrPeeGRqowiC, false);
		NiYoEDXoQQcltrGrBdPUXknEtSeu(nlyXuLcpvaRiFyGPmrPeeGRqowiC, list, true);
	}

	private void XRlVMqkkLbBggbwxFTbiPTAqiufw()
	{
		for (int i = 0; i < bKMzsaPPTNvweARgnhrTxHrsgDzaA; i++)
		{
			nlyXuLcpvaRiFyGPmrPeeGRqowiC[i]?.Update();
		}
	}

	private bool pmLJPktCUsKqoGWJTeOjudvKFCFkA(KHRsiVwnPBmtKUAjQcQZdcvJcMjkA P_0)
	{
		try
		{
			return P_0.xvOEXcocHrgiXhCksEkyzrbqswVTA();
		}
		catch
		{
			return false;
		}
	}

	private IList<wfXvpNxXWJkwQbGkekNHCgrsJhAN> JVRSrlLcLBHJOWiSqxtJtweMOsRF()
	{
		return iDHZcJIzakoEMdXzpzfIDXLmhEuE.GetJoysticks<wfXvpNxXWJkwQbGkekNHCgrsJhAN>();
	}

	private void nTQLVzzfjcESHKvMdwYnhXnxnNWdA(int P_0, int P_1, List<gEkAlBetTyTJTStTskBnWuobEWQjA> P_2, List<gEkAlBetTyTJTStTskBnWuobEWQjA> P_3)
	{
		if (P_1 > 0)
		{
			P_3.Sort(gEkAlBetTyTJTStTskBnWuobEWQjA.qjRKmPhIzzGBOzoBMYSKDSmwiHox);
		}
		if (P_0 > 0 && P_1 > 0)
		{
			vqOOHPrNjnJLAKCKICCPZvAcbegF(P_1, P_3, P_0, P_2, alSEZIFZjZkyrzPCiYrvOIkxdAiI.CzAkcycEKKCRweMupXOcalJwZdfS.Exact);
			vqOOHPrNjnJLAKCKICCPZvAcbegF(P_1, P_3, P_0, P_2, alSEZIFZjZkyrzPCiYrvOIkxdAiI.CzAkcycEKKCRweMupXOcalJwZdfS.Approximate);
		}
		CadDARBgApiHbeFyioPswxQTijtQb(P_1, P_3, alSEZIFZjZkyrzPCiYrvOIkxdAiI.CzAkcycEKKCRweMupXOcalJwZdfS.Exact);
		CadDARBgApiHbeFyioPswxQTijtQb(P_1, P_3, alSEZIFZjZkyrzPCiYrvOIkxdAiI.CzAkcycEKKCRweMupXOcalJwZdfS.Approximate);
		for (int i = 0; i < P_1; i++)
		{
			gEkAlBetTyTJTStTskBnWuobEWQjA gEkAlBetTyTJTStTskBnWuobEWQjA2 = P_3[i];
			if (gEkAlBetTyTJTStTskBnWuobEWQjA2 != null && gEkAlBetTyTJTStTskBnWuobEWQjA2.get_inputManagerId() < 0)
			{
				gEkAlBetTyTJTStTskBnWuobEWQjA2.set_inputManagerId(KjtvJXBJpSLhFEPDYnyhximhLvkJ(P_3));
				gEkAlBetTyTJTStTskBnWuobEWQjA2.set_rewiredId(woIuxuYARKhQjmplvgBTBEsfeOjdb());
				VcHfjHGuxyfVtAwtrHHxIhvIxBbJ.aiFcdcmHdkhEZgfxAcFNAnvwOeagb(gEkAlBetTyTJTStTskBnWuobEWQjA2);
			}
		}
		P_3.Sort(gEkAlBetTyTJTStTskBnWuobEWQjA.RTbcvDToxXKmnybfysJGtTHdeoYF);
	}

	private void VAjoThajnsRVMQufQQyksLdYXWGf(List<gEkAlBetTyTJTStTskBnWuobEWQjA> P_0, int P_1, int P_2)
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

	private bool oODTrZafxAQVbkErTUBrsooBtjVc(List<gEkAlBetTyTJTStTskBnWuobEWQjA> P_0, int P_1)
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

	private int KjtvJXBJpSLhFEPDYnyhximhLvkJ(List<gEkAlBetTyTJTStTskBnWuobEWQjA> P_0)
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

	private bool TWnnHgWUMtLuqXXvWMTUMEsHIfng(List<gEkAlBetTyTJTStTskBnWuobEWQjA> P_0, int P_1)
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

	private void vqOOHPrNjnJLAKCKICCPZvAcbegF(int P_0, List<gEkAlBetTyTJTStTskBnWuobEWQjA> P_1, int P_2, List<gEkAlBetTyTJTStTskBnWuobEWQjA> P_3, alSEZIFZjZkyrzPCiYrvOIkxdAiI.CzAkcycEKKCRweMupXOcalJwZdfS P_4)
	{
		int num = ((P_4 != alSEZIFZjZkyrzPCiYrvOIkxdAiI.CzAkcycEKKCRweMupXOcalJwZdfS.Exact) ? 1 : 2);
		for (int i = 0; i < P_0; i++)
		{
			gEkAlBetTyTJTStTskBnWuobEWQjA gEkAlBetTyTJTStTskBnWuobEWQjA2 = P_1[i];
			if (gEkAlBetTyTJTStTskBnWuobEWQjA2 == null || gEkAlBetTyTJTStTskBnWuobEWQjA2.get_inputManagerId() >= 0)
			{
				continue;
			}
			for (int j = 0; j < P_2; j++)
			{
				gEkAlBetTyTJTStTskBnWuobEWQjA gEkAlBetTyTJTStTskBnWuobEWQjA3 = P_3[j];
				if (gEkAlBetTyTJTStTskBnWuobEWQjA3 != null && !TWnnHgWUMtLuqXXvWMTUMEsHIfng(P_1, gEkAlBetTyTJTStTskBnWuobEWQjA3.get_rewiredId()) && gEkAlBetTyTJTStTskBnWuobEWQjA2.CgpjdIMxBaAlHZGxnIitvQKuRNwW(gEkAlBetTyTJTStTskBnWuobEWQjA3) >= num)
				{
					gEkAlBetTyTJTStTskBnWuobEWQjA2.ekanoaDsUPAgTgtWHacfMXMwLHMM(gEkAlBetTyTJTStTskBnWuobEWQjA3);
					VcHfjHGuxyfVtAwtrHHxIhvIxBbJ.aiFcdcmHdkhEZgfxAcFNAnvwOeagb(gEkAlBetTyTJTStTskBnWuobEWQjA2);
				}
			}
		}
	}

	private void CadDARBgApiHbeFyioPswxQTijtQb(int P_0, List<gEkAlBetTyTJTStTskBnWuobEWQjA> P_1, alSEZIFZjZkyrzPCiYrvOIkxdAiI.CzAkcycEKKCRweMupXOcalJwZdfS P_2)
	{
		for (int i = 0; i < P_0; i++)
		{
			gEkAlBetTyTJTStTskBnWuobEWQjA gEkAlBetTyTJTStTskBnWuobEWQjA2 = P_1[i];
			if (gEkAlBetTyTJTStTskBnWuobEWQjA2 == null || gEkAlBetTyTJTStTskBnWuobEWQjA2.get_inputManagerId() >= 0)
			{
				continue;
			}
			alSEZIFZjZkyrzPCiYrvOIkxdAiI.RGfIExesvIxrOQpmrsqZcKucuqfh rGfIExesvIxrOQpmrsqZcKucuqfh = null;
			foreach (alSEZIFZjZkyrzPCiYrvOIkxdAiI.RGfIExesvIxrOQpmrsqZcKucuqfh item in VcHfjHGuxyfVtAwtrHHxIhvIxBbJ.WnnRLljJUMyIBdcreMSuQdvCtRYL(gEkAlBetTyTJTStTskBnWuobEWQjA2, P_2))
			{
				if (!TWnnHgWUMtLuqXXvWMTUMEsHIfng(P_1, item.nUKDaFgUmTSBwwqvYZrOENPhdtFeA) && item.GLpWCpJucowAlwlfaEnESaNDCLAbA >= 0)
				{
					rGfIExesvIxrOQpmrsqZcKucuqfh = item;
					break;
				}
			}
			if (rGfIExesvIxrOQpmrsqZcKucuqfh != null)
			{
				int num = rGfIExesvIxrOQpmrsqZcKucuqfh.GLpWCpJucowAlwlfaEnESaNDCLAbA;
				if (!oODTrZafxAQVbkErTUBrsooBtjVc(P_1, num))
				{
					num = (rGfIExesvIxrOQpmrsqZcKucuqfh.GLpWCpJucowAlwlfaEnESaNDCLAbA = KjtvJXBJpSLhFEPDYnyhximhLvkJ(P_1));
				}
				gEkAlBetTyTJTStTskBnWuobEWQjA2.set_inputManagerId(num);
				gEkAlBetTyTJTStTskBnWuobEWQjA2.set_rewiredId(rGfIExesvIxrOQpmrsqZcKucuqfh.nUKDaFgUmTSBwwqvYZrOENPhdtFeA);
				VcHfjHGuxyfVtAwtrHHxIhvIxBbJ.aiFcdcmHdkhEZgfxAcFNAnvwOeagb(gEkAlBetTyTJTStTskBnWuobEWQjA2);
			}
		}
	}

	private void boSbYTHXwZdUJosoRCUyTWthkuse()
	{
		IList<wfXvpNxXWJkwQbGkekNHCgrsJhAN> list = JVRSrlLcLBHJOWiSqxtJtweMOsRF();
		uzXjfsbCdGiKZENnhKmOIAjatCiQb(list);
		wZmBNeEKXbNqepvRHBzpdmjgdCSqB = false;
	}

	private bool WjFZfcrLsLKpwcLQIrFUSVZkprqS(IList<wfXvpNxXWJkwQbGkekNHCgrsJhAN> P_0)
	{
		int count = P_0.Count;
		for (int i = 0; i < count; i++)
		{
			if (P_0[i] != null && !svpKItkwnOiQPkuZgKFGWxCfMQiI(P_0[i].XJreFUOKwAuuiHjzkeBdhqsrqtQpA()))
			{
				return true;
			}
		}
		int count2 = nlyXuLcpvaRiFyGPmrPeeGRqowiC.Count;
		for (int j = 0; j < count2; j++)
		{
			if (nlyXuLcpvaRiFyGPmrPeeGRqowiC[j] != null && !LMGBidIErKQLfETbHbiZKMHTqQVP(P_0, nlyXuLcpvaRiFyGPmrPeeGRqowiC[j].rPPRgAgSJtpIocaNdDJwlRQCrzDB))
			{
				return true;
			}
		}
		return false;
	}

	private bool svpKItkwnOiQPkuZgKFGWxCfMQiI(Guid P_0)
	{
		int count = nlyXuLcpvaRiFyGPmrPeeGRqowiC.Count;
		for (int i = 0; i < count; i++)
		{
			if (nlyXuLcpvaRiFyGPmrPeeGRqowiC[i] != null && nlyXuLcpvaRiFyGPmrPeeGRqowiC[i].rPPRgAgSJtpIocaNdDJwlRQCrzDB == P_0)
			{
				return true;
			}
		}
		return false;
	}

	private bool LMGBidIErKQLfETbHbiZKMHTqQVP(IList<wfXvpNxXWJkwQbGkekNHCgrsJhAN> P_0, Guid P_1)
	{
		int count = P_0.Count;
		for (int i = 0; i < count; i++)
		{
			if (P_0[i] != null && P_0[i].XJreFUOKwAuuiHjzkeBdhqsrqtQpA() == P_1)
			{
				return true;
			}
		}
		return false;
	}

	private void NiYoEDXoQQcltrGrBdPUXknEtSeu(List<gEkAlBetTyTJTStTskBnWuobEWQjA> P_0, List<gEkAlBetTyTJTStTskBnWuobEWQjA> P_1, bool P_2)
	{
		if (P_0 == null)
		{
			return;
		}
		int num = P_0?.Count ?? 0;
		int num2 = P_1?.Count ?? 0;
		for (int i = 0; i < num; i++)
		{
			gEkAlBetTyTJTStTskBnWuobEWQjA gEkAlBetTyTJTStTskBnWuobEWQjA2 = P_0[i];
			if (gEkAlBetTyTJTStTskBnWuobEWQjA2 == null)
			{
				continue;
			}
			bool flag = false;
			if (P_1 != null)
			{
				for (int j = 0; j < num2; j++)
				{
					gEkAlBetTyTJTStTskBnWuobEWQjA gEkAlBetTyTJTStTskBnWuobEWQjA3 = P_1[j];
					if (gEkAlBetTyTJTStTskBnWuobEWQjA3 != null && gEkAlBetTyTJTStTskBnWuobEWQjA2.rPPRgAgSJtpIocaNdDJwlRQCrzDB == gEkAlBetTyTJTStTskBnWuobEWQjA3.rPPRgAgSJtpIocaNdDJwlRQCrzDB)
					{
						flag = true;
						break;
					}
				}
			}
			if (!flag)
			{
				cxDHmKfYThkcSzsNuataocWYFprS(P_0[i], P_2);
			}
		}
	}

	private void cxDHmKfYThkcSzsNuataocWYFprS(gEkAlBetTyTJTStTskBnWuobEWQjA P_0, bool P_1)
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

	private void QxUzcPhCTNcneYytINxvZqAuwfji()
	{
		if (NTKWYcCkznITfQGyFXDADfrIPXrI)
		{
			wZmBNeEKXbNqepvRHBzpdmjgdCSqB = true;
		}
		SystemDeviceConnected();
	}
}
