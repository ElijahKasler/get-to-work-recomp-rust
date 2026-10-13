using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Rewired;
using Rewired.Config;
using Rewired.Data.Mapping;
using Rewired.Interfaces;
using Rewired.Platforms;
using Rewired.Platforms.Windows.DirectInput;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using Rewired.Utils.Classes.Utility;

internal class CjBwBKlcXyHERByOVbSKItkOzASJ : PlatformInputManager, veDKOByjfMbRGPFxWAoNvUWwrpDO
{
	private class WivuQsnnBaGilaFGOHquRRJlDRWW : IInputManagerJoystick, IInputManagerJoystickPublic
	{
		private int RFWmObcZfTsICRkuJfeDoxqlGFdW;

		private int wIMcRKIzZpHCJWjZtHENiPrRQPAL;

		public Guid CxYyZVIkwOdebDhNsNNzjMmcRlRe;

		public string pKdImPqGhTFgIIJMGWLupELSGELE;

		public readonly mxyNLHmDPnGdTytmKVWDUPaQCKgj pvKABDSqYwdOGqvZIZRnMixmzQSI;

		public cQBxMAHukbVUZQupSRBOiSlaiust mQqeDlcfEtvBEvceImluITFdpIPeb;

		public hHFsfajLRZYSFHbHIkRhPCzLqfpc cHYXOJPMZNDzwEaoluawxVJoGwAn;

		public string dMcTpkiaKMGxyBHYaopQCSanAHhab;

		public string WGczDimTElblVmKxHkqEOWbGHsUk;

		public int rWmfRVnWKZnVOwgDFjNDsqgfaPjo;

		public Guid JSIHxngvZKuKQvFPQGVSlUafGFoN;

		public Guid lNjEKKHDCuCIOkaBEMYrTDFIwJkp;

		public Guid RdfZwQEqNImGfQAiGYeZstvjrJOf;

		public int xRsDGLUfLgKtrglCMigEcHZyvNzz;

		public bool EGdfQrHXBnPlvsPfyipeRkIQgPIeb;

		public string zjdBMWFLbeOBJSmHchUrBbXymdme;

		public string rgKCXruzSHuufzyRJskULveijUgD;

		public int jDGDiCkOxkDvtBmuyqpQdfIxrDzg;

		public int UuJRnHXPDBsGeYyCbxnxyNToQsFJ;

		public int JCjrxAHJuJFYVfsnTfwfNbjiyMe;

		public int RUkFvDetMFtMNabRhsHrynrUFKuw;

		public int YVLiGPIPRedKYahelzxhHOgiKQIQ;

		public bool hOttLjwYdgpqXujkQiiiLjxLMKOC;

		public Controller.Extension VyFnjjGMCUzFpibbfapgVexfeMLP;

		private float[] iANswChLutkGsTiJObPmBoILDyyD;

		private bool[] JGkstKLEJgeJrJJqozFGsJlsmkGU;

		private HardwareJoystickMap_InputManager dGcoAdahuzlghqyzyrIIBgRGCqaCA;

		private Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> udHhkFCTDXJHGHYSANwyMflXpbvEc;

		private bool SmrSQmRRsoSzQhEgQgFkuoexYQsk;

		private bool cbbHZrvZtxknVrKRDHHIPPVgUoTp;

		private bool sFThTjYSAtxcFAqFIPlpcvCQVUYk;

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
		Controller.Extension IInputManagerJoystickPublic.extension => get_extension();

		[CustomObfuscation(rename = false)]
		Guid IInputManagerJoystickPublic.instanceGuid => get_instanceGuid();

		[CustomObfuscation(rename = false)]
		Guid IInputManagerJoystickPublic.persistentGuid => get_persistentGuid();

		public int get_rewiredId()
		{
			return RFWmObcZfTsICRkuJfeDoxqlGFdW;
		}

		public void set_rewiredId(int value)
		{
			RFWmObcZfTsICRkuJfeDoxqlGFdW = value;
		}

		public int get_inputManagerId()
		{
			return wIMcRKIzZpHCJWjZtHENiPrRQPAL;
		}

		public void set_inputManagerId(int value)
		{
			wIMcRKIzZpHCJWjZtHENiPrRQPAL = value;
		}

		public string get_name()
		{
			if (pKdImPqGhTFgIIJMGWLupELSGELE != "Unknown Controller")
			{
				return pKdImPqGhTFgIIJMGWLupELSGELE;
			}
			if (EGdfQrHXBnPlvsPfyipeRkIQgPIeb && !string.IsNullOrEmpty(zjdBMWFLbeOBJSmHchUrBbXymdme))
			{
				return zjdBMWFLbeOBJSmHchUrBbXymdme;
			}
			return WGczDimTElblVmKxHkqEOWbGHsUk;
		}

		public long? get_systemId()
		{
			if (wIMcRKIzZpHCJWjZtHENiPrRQPAL < 0)
			{
				return null;
			}
			return wIMcRKIzZpHCJWjZtHENiPrRQPAL;
		}

		public int get_unityId()
		{
			return 0;
		}

		public Controller.Extension get_extension()
		{
			return VyFnjjGMCUzFpibbfapgVexfeMLP;
		}

		public Guid get_instanceGuid()
		{
			return JSIHxngvZKuKQvFPQGVSlUafGFoN;
		}

		public Guid get_persistentGuid()
		{
			return get_instanceGuid();
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

		public WivuQsnnBaGilaFGOHquRRJlDRWW(mxyNLHmDPnGdTytmKVWDUPaQCKgj P_0, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> P_1)
		{
			pvKABDSqYwdOGqvZIZRnMixmzQSI = P_0;
			udHhkFCTDXJHGHYSANwyMflXpbvEc = P_1;
			wIMcRKIzZpHCJWjZtHENiPrRQPAL = -1;
			RFWmObcZfTsICRkuJfeDoxqlGFdW = -1;
		}

		public void vFixfAiDwLNjAaaBuVpMHEZabxdW()
		{
			string wGczDimTElblVmKxHkqEOWbGHsUk = WGczDimTElblVmKxHkqEOWbGHsUk;
			Guid guid = lNjEKKHDCuCIOkaBEMYrTDFIwJkp;
			RdfZwQEqNImGfQAiGYeZstvjrJOf = MiscTools.CreateGuidHashSHA1(wGczDimTElblVmKxHkqEOWbGHsUk + guid.ToString());
			jDGDiCkOxkDvtBmuyqpQdfIxrDzg = JCjrxAHJuJFYVfsnTfwfNbjiyMe;
			UuJRnHXPDBsGeYyCbxnxyNToQsFJ = RUkFvDetMFtMNabRhsHrynrUFKuw + YVLiGPIPRedKYahelzxhHOgiKQIQ * 8;
			ORtuXyqpXsKWpbzWkLbEdPduaAmhA();
			CxYyZVIkwOdebDhNsNNzjMmcRlRe = dGcoAdahuzlghqyzyrIIBgRGCqaCA.hardwareMapIdentifier.guid;
			pKdImPqGhTFgIIJMGWLupELSGELE = dGcoAdahuzlghqyzyrIIBgRGCqaCA.controllerName;
			SmrSQmRRsoSzQhEgQgFkuoexYQsk = ((CxYyZVIkwOdebDhNsNNzjMmcRlRe == Guid.Empty) ? true : false);
			iANswChLutkGsTiJObPmBoILDyyD = new float[jDGDiCkOxkDvtBmuyqpQdfIxrDzg];
			JGkstKLEJgeJrJJqozFGsJlsmkGU = new bool[UuJRnHXPDBsGeYyCbxnxyNToQsFJ];
			pvKABDSqYwdOGqvZIZRnMixmzQSI.IHlijJlPUAiCHRoeNBjjolJtCcSR();
			Update();
		}

		public void IhBoNIdgGUoVoweYZIPbPLvoeJut(WivuQsnnBaGilaFGOHquRRJlDRWW P_0)
		{
			if (P_0 != null)
			{
				wIMcRKIzZpHCJWjZtHENiPrRQPAL = P_0.wIMcRKIzZpHCJWjZtHENiPrRQPAL;
				RFWmObcZfTsICRkuJfeDoxqlGFdW = P_0.RFWmObcZfTsICRkuJfeDoxqlGFdW;
				for (int i = 0; i < MathTools.Min(JGkstKLEJgeJrJJqozFGsJlsmkGU.Length, P_0.JGkstKLEJgeJrJJqozFGsJlsmkGU.Length); i++)
				{
					JGkstKLEJgeJrJJqozFGsJlsmkGU[i] = P_0.JGkstKLEJgeJrJJqozFGsJlsmkGU[i];
				}
				for (int j = 0; j < MathTools.Min(iANswChLutkGsTiJObPmBoILDyyD.Length, P_0.iANswChLutkGsTiJObPmBoILDyyD.Length); j++)
				{
					iANswChLutkGsTiJObPmBoILDyyD[j] = P_0.iANswChLutkGsTiJObPmBoILDyyD[j];
				}
				cbbHZrvZtxknVrKRDHHIPPVgUoTp = P_0.cbbHZrvZtxknVrKRDHHIPPVgUoTp;
				pvKABDSqYwdOGqvZIZRnMixmzQSI.GmbQFymCsOMTgrUXhvEoRHhsJVjL(P_0.pvKABDSqYwdOGqvZIZRnMixmzQSI);
			}
		}

		[CustomObfuscation(rename = false)]
		public void Update()
		{
			pvKABDSqYwdOGqvZIZRnMixmzQSI.vSigOeirBmRMvhvhhLsGdZsRddTPb();
			bool[] array = pvKABDSqYwdOGqvZIZRnMixmzQSI.vmAFruJiynFnzgtkmeOnlJiaoMwlA();
			int[] aFeyRJwCJKIvYooPUwaauNBljqic = pvKABDSqYwdOGqvZIZRnMixmzQSI.LiOPZRMCoMUrnpKWTiYqdEtkpLjW().AFeyRJwCJKIvYooPUwaauNBljqic;
			RvwypkVfBLaKOYRyoftoANxcAhZk(array, aFeyRJwCJKIvYooPUwaauNBljqic);
			AanpUsyxYQBfvbvAPyTwYBUuCzZo(array, aFeyRJwCJKIvYooPUwaauNBljqic);
			pvKABDSqYwdOGqvZIZRnMixmzQSI.HsMPsLseJdKDRSTyNjGRRxEgVzMb();
		}

		void IInputManagerJoystick.Update()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Update
			this.Update();
		}

		[CustomObfuscation(rename = false)]
		public void FillData(ControllerDataUpdater dataUpdater)
		{
			if (jDGDiCkOxkDvtBmuyqpQdfIxrDzg != dataUpdater.axisCount || UuJRnHXPDBsGeYyCbxnxyNToQsFJ != dataUpdater.buttonCount)
			{
				throw new Exception("This controller signature does not match the data object!");
			}
			for (int i = 0; i < jDGDiCkOxkDvtBmuyqpQdfIxrDzg; i++)
			{
				dataUpdater.axisValues[i] = iANswChLutkGsTiJObPmBoILDyyD[i];
			}
			for (int j = 0; j < UuJRnHXPDBsGeYyCbxnxyNToQsFJ; j++)
			{
				dataUpdater.buttonValues[j] = JGkstKLEJgeJrJJqozFGsJlsmkGU[j];
			}
			if (cbbHZrvZtxknVrKRDHHIPPVgUoTp && !dataUpdater.hasReceivedInput)
			{
				dataUpdater.hasReceivedInput = true;
			}
		}

		void IInputManagerJoystick.FillData(ControllerDataUpdater dataUpdater)
		{
			//ILSpy generated this explicit interface implementation from .override directive in FillData
			this.FillData(dataUpdater);
		}

		public int oCsDYSCyvHombbBLWPbfoNhleeMAb(WivuQsnnBaGilaFGOHquRRJlDRWW P_0)
		{
			if (P_0.RFWmObcZfTsICRkuJfeDoxqlGFdW == RFWmObcZfTsICRkuJfeDoxqlGFdW)
			{
				return 2;
			}
			if (JCjrxAHJuJFYVfsnTfwfNbjiyMe != P_0.JCjrxAHJuJFYVfsnTfwfNbjiyMe)
			{
				return 0;
			}
			if (RUkFvDetMFtMNabRhsHrynrUFKuw != P_0.RUkFvDetMFtMNabRhsHrynrUFKuw)
			{
				return 0;
			}
			if (YVLiGPIPRedKYahelzxhHOgiKQIQ != P_0.YVLiGPIPRedKYahelzxhHOgiKQIQ)
			{
				return 0;
			}
			if (P_0.get_instanceGuid() == get_instanceGuid())
			{
				return 2;
			}
			if (P_0.RdfZwQEqNImGfQAiGYeZstvjrJOf == RdfZwQEqNImGfQAiGYeZstvjrJOf)
			{
				return 1;
			}
			return 0;
		}

		private BridgedControllerHWInfo ZENSwSHtrgUyyoQleFewoWaxercQ()
		{
			BridgedControllerHWInfo bridgedControllerHWInfo = new BridgedControllerHWInfo();
			MLzZUvyIfjEmhLzgivhUzjfFuaFc(bridgedControllerHWInfo);
			return bridgedControllerHWInfo;
		}

		[CustomObfuscation(rename = false)]
		public BridgedController ToBridgedController()
		{
			BridgedController bridgedController = new BridgedController();
			PZuXYqDaNycJGYkQkPwwYRssviJm(bridgedController);
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
			return new ControllerDisconnectedEventArgs(RFWmObcZfTsICRkuJfeDoxqlGFdW);
		}

		ControllerDisconnectedEventArgs IInputManagerJoystick.ToControllerDisconnectedEventArgs()
		{
			//ILSpy generated this explicit interface implementation from .override directive in ToControllerDisconnectedEventArgs
			return this.ToControllerDisconnectedEventArgs();
		}

		public bool lDGzsKKTqDICJTBvxfgBpcRTReTm()
		{
			try
			{
				pvKABDSqYwdOGqvZIZRnMixmzQSI.GEoeNkUyEAnoWoaHezTHrqBHFKiB.lsPNPLUVezemoQnLefWoGQXYeUvlA();
				return true;
			}
			catch
			{
				return false;
			}
		}

		public void SSYvDbDSOOEWKXRsUCZOFAqkcEtA()
		{
			try
			{
				if (pvKABDSqYwdOGqvZIZRnMixmzQSI.GEoeNkUyEAnoWoaHezTHrqBHFKiB != null)
				{
					pvKABDSqYwdOGqvZIZRnMixmzQSI.GEoeNkUyEAnoWoaHezTHrqBHFKiB.NRLBiBqDROwlvswVRjyZjAGQpKVj();
				}
			}
			catch
			{
			}
		}

		public void dHQZRizRWNfGkiyEfsIkNeECiTwy()
		{
			try
			{
				if (pvKABDSqYwdOGqvZIZRnMixmzQSI.GEoeNkUyEAnoWoaHezTHrqBHFKiB != null)
				{
					pvKABDSqYwdOGqvZIZRnMixmzQSI.GEoeNkUyEAnoWoaHezTHrqBHFKiB.mEmqoSvqSexnhboyTfWnkXezmFsc();
				}
			}
			catch
			{
			}
		}

		private void RvwypkVfBLaKOYRyoftoANxcAhZk(bool[] P_0, int[] P_1)
		{
			if (jDGDiCkOxkDvtBmuyqpQdfIxrDzg <= 0)
			{
				return;
			}
			switch (dGcoAdahuzlghqyzyrIIBgRGCqaCA.map.platform)
			{
			case InputPlatform.WindowsRawInput:
			{
				HardwareJoystickMap.Platform_RawInput_Base.Axis[] axes_orig2 = ((HardwareJoystickMap.Platform_RawInput_Base)dGcoAdahuzlghqyzyrIIBgRGCqaCA.map).Axes_orig;
				if (axes_orig2 != null)
				{
					for (int j = 0; j < axes_orig2.Length; j++)
					{
						hHSgwwHbGTAMZioJocGotxqhaUagb(axes_orig2[j], j, P_0, P_1);
					}
				}
				break;
			}
			case InputPlatform.WindowsDirectInput:
			{
				HardwareJoystickMap.Platform_DirectInput_Base.Axis[] axes_orig = ((HardwareJoystickMap.Platform_DirectInput_Base)dGcoAdahuzlghqyzyrIIBgRGCqaCA.map).Axes_orig;
				if (axes_orig != null)
				{
					for (int i = 0; i < axes_orig.Length; i++)
					{
						hHSgwwHbGTAMZioJocGotxqhaUagb(axes_orig[i], i, P_0, P_1);
					}
				}
				break;
			}
			}
		}

		private void AanpUsyxYQBfvbvAPyTwYBUuCzZo(bool[] P_0, int[] P_1)
		{
			if (UuJRnHXPDBsGeYyCbxnxyNToQsFJ <= 0)
			{
				return;
			}
			switch (dGcoAdahuzlghqyzyrIIBgRGCqaCA.map.platform)
			{
			case InputPlatform.WindowsRawInput:
			{
				HardwareJoystickMap.Platform_RawInput_Base.Button[] buttons_orig2 = ((HardwareJoystickMap.Platform_RawInput_Base)dGcoAdahuzlghqyzyrIIBgRGCqaCA.map).Buttons_orig;
				if (buttons_orig2 != null)
				{
					for (int j = 0; j < buttons_orig2.Length; j++)
					{
						YhMiamEPPKNTVOWGjurTlOQdYyHp(buttons_orig2[j], j, P_0, P_1);
					}
				}
				break;
			}
			case InputPlatform.WindowsDirectInput:
			{
				HardwareJoystickMap.Platform_DirectInput_Base.Button[] buttons_orig = ((HardwareJoystickMap.Platform_DirectInput_Base)dGcoAdahuzlghqyzyrIIBgRGCqaCA.map).Buttons_orig;
				if (buttons_orig != null)
				{
					for (int i = 0; i < buttons_orig.Length; i++)
					{
						YhMiamEPPKNTVOWGjurTlOQdYyHp(buttons_orig[i], i, P_0, P_1);
					}
				}
				break;
			}
			}
		}

		private void hHSgwwHbGTAMZioJocGotxqhaUagb(HardwareJoystickMap.Platform_RawOrDirectInput.Axis_Base P_0, int P_1, bool[] P_2, int[] P_3)
		{
			if (P_1 >= jDGDiCkOxkDvtBmuyqpQdfIxrDzg)
			{
				throw new Exception("Number of axes in hardware map does not match number of axes found in controller!");
			}
			iANswChLutkGsTiJObPmBoILDyyD[P_1] = IDsBfAiozAcOkhdoAhwxovYgEpptb(P_0, P_2, P_3);
			if (!cbbHZrvZtxknVrKRDHHIPPVgUoTp && iANswChLutkGsTiJObPmBoILDyyD[P_1] != 0f)
			{
				cbbHZrvZtxknVrKRDHHIPPVgUoTp = true;
			}
		}

		private void YhMiamEPPKNTVOWGjurTlOQdYyHp(HardwareJoystickMap.Platform_RawOrDirectInput.Button_Base P_0, int P_1, bool[] P_2, int[] P_3)
		{
			if (P_1 >= UuJRnHXPDBsGeYyCbxnxyNToQsFJ)
			{
				throw new Exception("Number of buttons in hardware map does not match number of buttons found in controller!");
			}
			JGkstKLEJgeJrJJqozFGsJlsmkGU[P_1] = VfthrAFiyyClRBoBHiBiyHnPlxgD(P_0, P_2, P_3);
			if (!cbbHZrvZtxknVrKRDHHIPPVgUoTp && JGkstKLEJgeJrJJqozFGsJlsmkGU[P_1])
			{
				cbbHZrvZtxknVrKRDHHIPPVgUoTp = true;
			}
		}

		private float IDsBfAiozAcOkhdoAhwxovYgEpptb(HardwareJoystickMap.Platform_RawOrDirectInput.Axis_Base P_0, bool[] P_1, int[] P_2)
		{
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Axis)
			{
				if (P_0.sourceAxis <= 0 || P_0.sourceAxis >= 32)
				{
					return 0f;
				}
				return gljvCPLImufCzelOdxitmNGTjYsR((DirectInputAxis)P_0.sourceAxis);
			}
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Button)
			{
				int sourceButton = P_0.sourceButton;
				if (sourceButton < 0 || sourceButton >= RUkFvDetMFtMNabRhsHrynrUFKuw || sourceButton >= 128)
				{
					return 0f;
				}
				if (!P_1[sourceButton])
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
				if (sourceHat < 0 || sourceHat >= YVLiGPIPRedKYahelzxhHOgiKQIQ || sourceHat >= 4)
				{
					return 0f;
				}
				int num = P_2[sourceHat];
				if (num < 0)
				{
					return 0f;
				}
				float num2;
				if (P_0.sourceHatDirection == AxisDirection.Horizontal)
				{
					num2 = JWCsQKmXKXAANQxkthfrpaHdCRPP(num, AxisDirection.Horizontal);
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
					num2 = JWCsQKmXKXAANQxkthfrpaHdCRPP(num, AxisDirection.Vertical);
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
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Custom)
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
				HardwareJoystickMap.Platform_RawOrDirectInput.CustomCalculationSourceData[] customCalculationSourceData = P_0.customCalculationSourceData;
				if (customCalculationSourceData == null)
				{
					return 0f;
				}
				for (int i = 0; i < customCalculationSourceData.Length; i++)
				{
					if (customCalculationSourceData[i] != null && customCalculationSourceData[i].sourceType == 1 && YCqsNXgSeflLmxzvodgQNzqRENJN(customCalculationSourceData[i], out var item))
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
			return 0f;
		}

		private float gljvCPLImufCzelOdxitmNGTjYsR(DirectInputAxis P_0)
		{
			return P_0 switch
			{
				DirectInputAxis.X => pvKABDSqYwdOGqvZIZRnMixmzQSI.LiOPZRMCoMUrnpKWTiYqdEtkpLjW().eniOQvUgCaxCkjMnvcsCKNMkkFkn, 
				DirectInputAxis.Y => pvKABDSqYwdOGqvZIZRnMixmzQSI.LiOPZRMCoMUrnpKWTiYqdEtkpLjW().LqkaZBiLUHMqDpLxPqnNdYcSDrVGb, 
				DirectInputAxis.Z => pvKABDSqYwdOGqvZIZRnMixmzQSI.LiOPZRMCoMUrnpKWTiYqdEtkpLjW().WAdGvfgxOZfAIqypJIzYRXdSMZlNA, 
				DirectInputAxis.RotationX => pvKABDSqYwdOGqvZIZRnMixmzQSI.LiOPZRMCoMUrnpKWTiYqdEtkpLjW().caarlfikKHFwfhVSobEDsDmroOLzA, 
				DirectInputAxis.RotationY => pvKABDSqYwdOGqvZIZRnMixmzQSI.LiOPZRMCoMUrnpKWTiYqdEtkpLjW().VYbeaTgVJSGENvEsNHRCZRFCDMJCA, 
				DirectInputAxis.RotationZ => pvKABDSqYwdOGqvZIZRnMixmzQSI.LiOPZRMCoMUrnpKWTiYqdEtkpLjW().ulcdRKfNPBFDoKuDDCqVoGlERsDr, 
				DirectInputAxis.Slider0 => pvKABDSqYwdOGqvZIZRnMixmzQSI.LiOPZRMCoMUrnpKWTiYqdEtkpLjW().RKplkmPgWJZyQZwghRysBSodLPCY[0], 
				DirectInputAxis.Slider1 => pvKABDSqYwdOGqvZIZRnMixmzQSI.LiOPZRMCoMUrnpKWTiYqdEtkpLjW().RKplkmPgWJZyQZwghRysBSodLPCY[1], 
				DirectInputAxis.VelocityX => pvKABDSqYwdOGqvZIZRnMixmzQSI.LiOPZRMCoMUrnpKWTiYqdEtkpLjW().TTMAvtnRDxKwlCGLhpimPVaPqJQy, 
				DirectInputAxis.VelocityY => pvKABDSqYwdOGqvZIZRnMixmzQSI.LiOPZRMCoMUrnpKWTiYqdEtkpLjW().uZyGWkDMwHDVJUsTIdVsKDkqDckcA, 
				DirectInputAxis.VelocityZ => pvKABDSqYwdOGqvZIZRnMixmzQSI.LiOPZRMCoMUrnpKWTiYqdEtkpLjW().uSmIzzCttvgKlINnGwEIBSAvtThp, 
				DirectInputAxis.AngularVelocityX => pvKABDSqYwdOGqvZIZRnMixmzQSI.LiOPZRMCoMUrnpKWTiYqdEtkpLjW().YPPRwBZQCqoNuVUudiTYdCPpxUYf, 
				DirectInputAxis.AngularVelocityY => pvKABDSqYwdOGqvZIZRnMixmzQSI.LiOPZRMCoMUrnpKWTiYqdEtkpLjW().iLXRTlCWfLYgleHtyamUbeopJCjU, 
				DirectInputAxis.AngularVelocityZ => pvKABDSqYwdOGqvZIZRnMixmzQSI.LiOPZRMCoMUrnpKWTiYqdEtkpLjW().NcQgbsyJlZInXGmxrLslvUaaTaet, 
				DirectInputAxis.VelocitySlider0 => pvKABDSqYwdOGqvZIZRnMixmzQSI.LiOPZRMCoMUrnpKWTiYqdEtkpLjW().EZiSBBoIOCEOlmPjiZZDCUiAaUNV[0], 
				DirectInputAxis.VelocitySlider1 => pvKABDSqYwdOGqvZIZRnMixmzQSI.LiOPZRMCoMUrnpKWTiYqdEtkpLjW().EZiSBBoIOCEOlmPjiZZDCUiAaUNV[1], 
				DirectInputAxis.AccelerationX => pvKABDSqYwdOGqvZIZRnMixmzQSI.LiOPZRMCoMUrnpKWTiYqdEtkpLjW().fmmBJLkcLDkEEyELaQovvuLwFphW, 
				DirectInputAxis.AccelerationY => pvKABDSqYwdOGqvZIZRnMixmzQSI.LiOPZRMCoMUrnpKWTiYqdEtkpLjW().nrehdBQGbcJDKyIfJITwxkRiHkwW, 
				DirectInputAxis.AccelerationZ => pvKABDSqYwdOGqvZIZRnMixmzQSI.LiOPZRMCoMUrnpKWTiYqdEtkpLjW().OqYjiUwXWOIGmqZGdOlGceEKYbdK, 
				DirectInputAxis.AngularAccelerationX => pvKABDSqYwdOGqvZIZRnMixmzQSI.LiOPZRMCoMUrnpKWTiYqdEtkpLjW().elJqCaXXUjAnTbZiWibSypvxdqLx, 
				DirectInputAxis.AngularAccelerationY => pvKABDSqYwdOGqvZIZRnMixmzQSI.LiOPZRMCoMUrnpKWTiYqdEtkpLjW().MZPfPuUvrkAHHAcwTYcqeurbKgxjb, 
				DirectInputAxis.AngularAccelerationZ => pvKABDSqYwdOGqvZIZRnMixmzQSI.LiOPZRMCoMUrnpKWTiYqdEtkpLjW().sWDyxXuciPzURUQVgvrGcXdNYJSe, 
				DirectInputAxis.AccelerationSlider0 => pvKABDSqYwdOGqvZIZRnMixmzQSI.LiOPZRMCoMUrnpKWTiYqdEtkpLjW().PMsfVLgBZsRIMOmmnaOjyVbeLLgO[0], 
				DirectInputAxis.AccelerationSlider1 => pvKABDSqYwdOGqvZIZRnMixmzQSI.LiOPZRMCoMUrnpKWTiYqdEtkpLjW().PMsfVLgBZsRIMOmmnaOjyVbeLLgO[1], 
				DirectInputAxis.ForceX => pvKABDSqYwdOGqvZIZRnMixmzQSI.LiOPZRMCoMUrnpKWTiYqdEtkpLjW().XNtciUWSsebsqUhIggGTIufCZHfk, 
				DirectInputAxis.ForceY => pvKABDSqYwdOGqvZIZRnMixmzQSI.LiOPZRMCoMUrnpKWTiYqdEtkpLjW().TFOXPIhgNEfexgLJqdOvsuZDFCxfb, 
				DirectInputAxis.ForceZ => pvKABDSqYwdOGqvZIZRnMixmzQSI.LiOPZRMCoMUrnpKWTiYqdEtkpLjW().uTceOhBypUmzIHlYTTkKtmolsAfp, 
				DirectInputAxis.TorqueX => pvKABDSqYwdOGqvZIZRnMixmzQSI.LiOPZRMCoMUrnpKWTiYqdEtkpLjW().ENGaWwSIPAuQMLPqVDvVFzeUerVyA, 
				DirectInputAxis.TorqueY => pvKABDSqYwdOGqvZIZRnMixmzQSI.LiOPZRMCoMUrnpKWTiYqdEtkpLjW().OyHTivCqxLeTWJOLJDhgVPJLRNCmA, 
				DirectInputAxis.TorqueZ => pvKABDSqYwdOGqvZIZRnMixmzQSI.LiOPZRMCoMUrnpKWTiYqdEtkpLjW().mkSrNaGNbGPrpXgjbKLwpcRLGwzE, 
				DirectInputAxis.ForceSlider0 => pvKABDSqYwdOGqvZIZRnMixmzQSI.LiOPZRMCoMUrnpKWTiYqdEtkpLjW().jWLOZZddeTrmIwocPFrmPKlWOCCN[0], 
				DirectInputAxis.ForceSlider1 => pvKABDSqYwdOGqvZIZRnMixmzQSI.LiOPZRMCoMUrnpKWTiYqdEtkpLjW().jWLOZZddeTrmIwocPFrmPKlWOCCN[1], 
				_ => 0f, 
			};
		}

		private bool VfthrAFiyyClRBoBHiBiyHnPlxgD(HardwareJoystickMap.Platform_RawOrDirectInput.Button_Base P_0, bool[] P_1, int[] P_2)
		{
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Button)
			{
				if (P_0.ignoreIfButtonsActive)
				{
					for (int i = 0; i < P_0.ignoreIfButtonsActiveButtons.Length; i++)
					{
						if (P_1[P_0.ignoreIfButtonsActiveButtons[i]])
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
						if (!P_1[P_0.requiredButtons[j]])
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
				if (sourceButton < 0 || sourceButton >= RUkFvDetMFtMNabRhsHrynrUFKuw || sourceButton >= 128)
				{
					return false;
				}
				return P_1[sourceButton];
			}
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Axis)
			{
				if (P_0.sourceAxis <= 0 || P_0.sourceAxis > 32)
				{
					return false;
				}
				float num = gljvCPLImufCzelOdxitmNGTjYsR((DirectInputAxis)P_0.sourceAxis);
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
				if (sourceHat < 0 || sourceHat >= YVLiGPIPRedKYahelzxhHOgiKQIQ || sourceHat >= 4)
				{
					return false;
				}
				switch (P_0.sourceHatDirection)
				{
				case HatDirection.Up:
					return TquGvsfglxXhgZmedpOlalGucjvgA(P_2[sourceHat], 0, P_0.sourceHatType);
				case HatDirection.UpRight:
					return TquGvsfglxXhgZmedpOlalGucjvgA(P_2[sourceHat], 1, P_0.sourceHatType);
				case HatDirection.Right:
					return TquGvsfglxXhgZmedpOlalGucjvgA(P_2[sourceHat], 2, P_0.sourceHatType);
				case HatDirection.DownRight:
					return TquGvsfglxXhgZmedpOlalGucjvgA(P_2[sourceHat], 3, P_0.sourceHatType);
				case HatDirection.Down:
					return TquGvsfglxXhgZmedpOlalGucjvgA(P_2[sourceHat], 4, P_0.sourceHatType);
				case HatDirection.DownLeft:
					return TquGvsfglxXhgZmedpOlalGucjvgA(P_2[sourceHat], 5, P_0.sourceHatType);
				case HatDirection.Left:
					return TquGvsfglxXhgZmedpOlalGucjvgA(P_2[sourceHat], 6, P_0.sourceHatType);
				case HatDirection.UpLeft:
					return TquGvsfglxXhgZmedpOlalGucjvgA(P_2[sourceHat], 7, P_0.sourceHatType);
				}
			}
			else if (P_0.sourceType == HardwareElementSourceTypeWithHat.Custom)
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
				HardwareJoystickMap.Platform_RawOrDirectInput.CustomCalculationSourceData[] customCalculationSourceData = P_0.customCalculationSourceData;
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
						if (whCJSmSZVdiZuSkkJBfqimlrJUTN(customCalculationSourceData[k], P_1, out var flag2))
						{
							customCalculation.AddData(flag2 ? 1f : 0f);
						}
						break;
					}
					case HardwareElementSourceTypeWithHat.Axis:
					{
						if (YCqsNXgSeflLmxzvodgQNzqRENJN(customCalculationSourceData[k], out var num2))
						{
							customCalculation.AddData((num2 != 0f) ? 1f : 0f);
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
			return false;
		}

		private bool TquGvsfglxXhgZmedpOlalGucjvgA(int P_0, int P_1, HatType P_2)
		{
			if (P_0 < 0)
			{
				return false;
			}
			if (dGcoAdahuzlghqyzyrIIBgRGCqaCA.isUnknownController && !InputTools.HandleForced4WayHatsOnUnknownControllers(P_1, ref P_2))
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

		private float JWCsQKmXKXAANQxkthfrpaHdCRPP(int P_0, AxisDirection P_1)
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

		private bool whCJSmSZVdiZuSkkJBfqimlrJUTN(HardwareJoystickMap.Platform_RawOrDirectInput.CustomCalculationSourceData P_0, bool[] P_1, out bool P_2)
		{
			P_2 = false;
			if (P_0.sourceType != 0)
			{
				return false;
			}
			int sourceButton = P_0.sourceButton;
			if (sourceButton < 0 || sourceButton >= RUkFvDetMFtMNabRhsHrynrUFKuw || sourceButton >= 128)
			{
				return false;
			}
			P_2 = P_1[sourceButton];
			return true;
		}

		private bool YCqsNXgSeflLmxzvodgQNzqRENJN(HardwareJoystickMap.Platform_RawOrDirectInput.CustomCalculationSourceData P_0, out float P_1)
		{
			P_1 = 0f;
			if (P_0.sourceType != 1)
			{
				return false;
			}
			if (P_0.sourceAxis <= 0 || P_0.sourceAxis >= 32)
			{
				return false;
			}
			P_1 = gljvCPLImufCzelOdxitmNGTjYsR((DirectInputAxis)P_0.sourceAxis);
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
			if (P_0.axisCalibrationType == AxisCalibrationType.Default)
			{
				P_1 = InputTools.GetCalibratedAxisValueClamped(P_1, P_0.axisZero, -1f, 1f, P_0.axisDeadZone, P_0.invert, applySensitivity: false, AxisSensitivityType.Multiplier, 1f, null);
			}
			else if (P_0.axisCalibrationType == AxisCalibrationType.Custom)
			{
				P_1 = InputTools.GetCalibratedAxisValueClamped(P_1, P_0.axisZero, P_0.axisMin, P_0.axisMax, P_0.axisDeadZone, P_0.invert, applySensitivity: false, AxisSensitivityType.Multiplier, 1f, null);
			}
			else if (P_0.axisCalibrationType == AxisCalibrationType.Uncalibrated && P_0.axisDeadZone > 0f && MathTools.Abs(P_1) <= P_0.axisDeadZone)
			{
				P_1 = 0f;
			}
			return true;
		}

		private ControlDeviceType nwFGXubRKMONhlIDSNtVUhljYrPlA(hHFsfajLRZYSFHbHIkRhPCzLqfpc P_0)
		{
			return P_0 switch
			{
				hHFsfajLRZYSFHbHIkRhPCzLqfpc.Keyboard => ControlDeviceType.Keyboard, 
				hHFsfajLRZYSFHbHIkRhPCzLqfpc.Joystick => ControlDeviceType.Joystick, 
				hHFsfajLRZYSFHbHIkRhPCzLqfpc.Gamepad => ControlDeviceType.Gamepad, 
				hHFsfajLRZYSFHbHIkRhPCzLqfpc.Mouse => ControlDeviceType.Mouse, 
				hHFsfajLRZYSFHbHIkRhPCzLqfpc.Flight => ControlDeviceType.Flight, 
				hHFsfajLRZYSFHbHIkRhPCzLqfpc.Driving => ControlDeviceType.Wheel, 
				_ => ControlDeviceType.Unknown, 
			};
		}

		private void ORtuXyqpXsKWpbzWkLbEdPduaAmhA()
		{
			dGcoAdahuzlghqyzyrIIBgRGCqaCA = udHhkFCTDXJHGHYSANwyMflXpbvEc(ZENSwSHtrgUyyoQleFewoWaxercQ());
			if (dGcoAdahuzlghqyzyrIIBgRGCqaCA == null)
			{
				Logger.LogError("Default hardware map not found!");
				return;
			}
			jDGDiCkOxkDvtBmuyqpQdfIxrDzg = dGcoAdahuzlghqyzyrIIBgRGCqaCA.axisCount;
			UuJRnHXPDBsGeYyCbxnxyNToQsFJ = dGcoAdahuzlghqyzyrIIBgRGCqaCA.buttonCount;
		}

		private void qsvNEMnSwrAcIEOauvvQsqGoiICX()
		{
		}

		private string lldlkoOYKUsoNDkuRNckRMLMQXdG()
		{
			return InputTools.FormatHardwareIdentifierString(string.Format("{0}{1}{2}{3}{4}", ReInput.currentPlatform.ToString(), InputSource.DirectInput, (EGdfQrHXBnPlvsPfyipeRkIQgPIeb && !string.IsNullOrEmpty(zjdBMWFLbeOBJSmHchUrBbXymdme)) ? zjdBMWFLbeOBJSmHchUrBbXymdme : WGczDimTElblVmKxHkqEOWbGHsUk, rWmfRVnWKZnVOwgDFjNDsqgfaPjo.ToString("X4"), new PidVid(lNjEKKHDCuCIOkaBEMYrTDFIwJkp).vendorId.ToString("X4")));
		}

		private void MLzZUvyIfjEmhLzgivhUzjfFuaFc(BridgedControllerHWInfo P_0)
		{
			P_0.inputManagerSource = InputSource.DirectInput;
			P_0.inputSource = P_0.inputManagerSource;
			P_0.deviceType = nwFGXubRKMONhlIDSNtVUhljYrPlA(cHYXOJPMZNDzwEaoluawxVJoGwAn);
			P_0.hardwareIdentifier = lldlkoOYKUsoNDkuRNckRMLMQXdG();
			P_0.hardwareAxisCount = JCjrxAHJuJFYVfsnTfwfNbjiyMe;
			P_0.hardwareButtonCount = RUkFvDetMFtMNabRhsHrynrUFKuw;
			P_0.hardwareHatCount = YVLiGPIPRedKYahelzxhHOgiKQIQ;
			P_0.hw_productName = WGczDimTElblVmKxHkqEOWbGHsUk;
			P_0.hw_deviceGuid = get_instanceGuid();
			P_0.hw_productId = rWmfRVnWKZnVOwgDFjNDsqgfaPjo;
			P_0.hw_pidVid = new PidVid(lNjEKKHDCuCIOkaBEMYrTDFIwJkp);
			P_0.hw_isBluetoothDevice = EGdfQrHXBnPlvsPfyipeRkIQgPIeb;
			P_0.hw_bluetoothDeviceName = ((!string.IsNullOrEmpty(zjdBMWFLbeOBJSmHchUrBbXymdme)) ? zjdBMWFLbeOBJSmHchUrBbXymdme : string.Empty);
			P_0.definitionMatchTag = rgKCXruzSHuufzyRJskULveijUgD;
		}

		private void PZuXYqDaNycJGYkQkPwwYRssviJm(BridgedController P_0)
		{
			MLzZUvyIfjEmhLzgivhUzjfFuaFc(P_0);
			P_0.sourceJoystick = this;
			P_0.gameHardwareMap = dGcoAdahuzlghqyzyrIIBgRGCqaCA.ToGameHardwareControllerMap();
			P_0.instanceName = dMcTpkiaKMGxyBHYaopQCSanAHhab;
			P_0.productName = WGczDimTElblVmKxHkqEOWbGHsUk;
			P_0.isXInputDevice = hOttLjwYdgpqXujkQiiiLjxLMKOC;
			P_0.axisCount = jDGDiCkOxkDvtBmuyqpQdfIxrDzg;
			P_0.buttonCount = UuJRnHXPDBsGeYyCbxnxyNToQsFJ;
			P_0.unknownControllerHats = giempHbWFWtPnfAzzyjWXiHYBoBIA();
			P_0.controllerTypeGuid = CxYyZVIkwOdebDhNsNNzjMmcRlRe;
			P_0.controllerExtension = get_extension();
		}

		private void FasalZJbiEXosUInwcmvDdRRjrjd()
		{
			for (int i = 0; i < UuJRnHXPDBsGeYyCbxnxyNToQsFJ; i++)
			{
				JGkstKLEJgeJrJJqozFGsJlsmkGU[i] = false;
			}
			for (int j = 0; j < jDGDiCkOxkDvtBmuyqpQdfIxrDzg; j++)
			{
				iANswChLutkGsTiJObPmBoILDyyD[j] = 0f;
			}
		}

		private UnknownControllerHat[] giempHbWFWtPnfAzzyjWXiHYBoBIA()
		{
			if (!SmrSQmRRsoSzQhEgQgFkuoexYQsk)
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

		public void botWiBpjJJbejOgoEjqvvTeXULxv()
		{
			PJHRPIWgBvKNQdpEagIdmRbyGYEu(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void MoMdgBZDpgoIssDxgOespqfzxIAe()
		{
			try
			{
				PJHRPIWgBvKNQdpEagIdmRbyGYEu(false);
			}
			finally
			{
				base.Finalize();
			}
		}

		protected virtual void PJHRPIWgBvKNQdpEagIdmRbyGYEu(bool P_0)
		{
			if (!sFThTjYSAtxcFAqFIPlpcvCQVUYk)
			{
				if (P_0 && pvKABDSqYwdOGqvZIZRnMixmzQSI != null)
				{
					pvKABDSqYwdOGqvZIZRnMixmzQSI.Dispose();
				}
				sFThTjYSAtxcFAqFIPlpcvCQVUYk = true;
			}
		}

		public static int fQafhMUYZDccLYLgkYvkQrhXpBWe(WivuQsnnBaGilaFGOHquRRJlDRWW P_0, WivuQsnnBaGilaFGOHquRRJlDRWW P_1)
		{
			if (P_0.wIMcRKIzZpHCJWjZtHENiPrRQPAL < P_1.wIMcRKIzZpHCJWjZtHENiPrRQPAL)
			{
				return -1;
			}
			if (P_0.wIMcRKIzZpHCJWjZtHENiPrRQPAL > P_1.wIMcRKIzZpHCJWjZtHENiPrRQPAL)
			{
				return 1;
			}
			return 0;
		}

		public static int kkkXBXqHwiRcKUqikiLgBkAPOPmbA(WivuQsnnBaGilaFGOHquRRJlDRWW P_0, WivuQsnnBaGilaFGOHquRRJlDRWW P_1)
		{
			if (P_0.xRsDGLUfLgKtrglCMigEcHZyvNzz < P_1.xRsDGLUfLgKtrglCMigEcHZyvNzz)
			{
				return -1;
			}
			if (P_0.xRsDGLUfLgKtrglCMigEcHZyvNzz > P_1.xRsDGLUfLgKtrglCMigEcHZyvNzz)
			{
				return 1;
			}
			return 0;
		}
	}

	private class mxyNLHmDPnGdTytmKVWDUPaQCKgj : IDisposable
	{
		public class mFqcGlIoDNpGGawMXZlbdnPyokvW
		{
			public float eniOQvUgCaxCkjMnvcsCKNMkkFkn;

			public float LqkaZBiLUHMqDpLxPqnNdYcSDrVGb;

			public float WAdGvfgxOZfAIqypJIzYRXdSMZlNA;

			public float caarlfikKHFwfhVSobEDsDmroOLzA;

			public float VYbeaTgVJSGENvEsNHRCZRFCDMJCA;

			public float ulcdRKfNPBFDoKuDDCqVoGlERsDr;

			public float[] RKplkmPgWJZyQZwghRysBSodLPCY;

			public readonly int[] AFeyRJwCJKIvYooPUwaauNBljqic;

			public readonly bool[] wLWolgipGooaLnizXtLOWnHATdEf;

			public float TTMAvtnRDxKwlCGLhpimPVaPqJQy;

			public float uZyGWkDMwHDVJUsTIdVsKDkqDckcA;

			public float uSmIzzCttvgKlINnGwEIBSAvtThp;

			public float YPPRwBZQCqoNuVUudiTYdCPpxUYf;

			public float iLXRTlCWfLYgleHtyamUbeopJCjU;

			public float NcQgbsyJlZInXGmxrLslvUaaTaet;

			public readonly float[] EZiSBBoIOCEOlmPjiZZDCUiAaUNV;

			public float fmmBJLkcLDkEEyELaQovvuLwFphW;

			public float nrehdBQGbcJDKyIfJITwxkRiHkwW;

			public float OqYjiUwXWOIGmqZGdOlGceEKYbdK;

			public float elJqCaXXUjAnTbZiWibSypvxdqLx;

			public float MZPfPuUvrkAHHAcwTYcqeurbKgxjb;

			public float sWDyxXuciPzURUQVgvrGcXdNYJSe;

			public readonly float[] PMsfVLgBZsRIMOmmnaOjyVbeLLgO;

			public float XNtciUWSsebsqUhIggGTIufCZHfk;

			public float TFOXPIhgNEfexgLJqdOvsuZDFCxfb;

			public float uTceOhBypUmzIHlYTTkKtmolsAfp;

			public float ENGaWwSIPAuQMLPqVDvVFzeUerVyA;

			public float OyHTivCqxLeTWJOLJDhgVPJLRNCmA;

			public float mkSrNaGNbGPrpXgjbKLwpcRLGwzE;

			public readonly float[] jWLOZZddeTrmIwocPFrmPKlWOCCN;

			public mFqcGlIoDNpGGawMXZlbdnPyokvW()
			{
				RKplkmPgWJZyQZwghRysBSodLPCY = new float[2];
				AFeyRJwCJKIvYooPUwaauNBljqic = new int[4];
				wLWolgipGooaLnizXtLOWnHATdEf = new bool[128];
				EZiSBBoIOCEOlmPjiZZDCUiAaUNV = new float[2];
				PMsfVLgBZsRIMOmmnaOjyVbeLLgO = new float[2];
				jWLOZZddeTrmIwocPFrmPKlWOCCN = new float[2];
			}

			public void cFdiSnWvZyemVwBPoCPScgWQCaVHA()
			{
				eniOQvUgCaxCkjMnvcsCKNMkkFkn = 0f;
				LqkaZBiLUHMqDpLxPqnNdYcSDrVGb = 0f;
				WAdGvfgxOZfAIqypJIzYRXdSMZlNA = 0f;
				caarlfikKHFwfhVSobEDsDmroOLzA = 0f;
				VYbeaTgVJSGENvEsNHRCZRFCDMJCA = 0f;
				ulcdRKfNPBFDoKuDDCqVoGlERsDr = 0f;
				for (int i = 0; i < RKplkmPgWJZyQZwghRysBSodLPCY.Length; i++)
				{
					RKplkmPgWJZyQZwghRysBSodLPCY[i] = 0f;
				}
				for (int j = 0; j < AFeyRJwCJKIvYooPUwaauNBljqic.Length; j++)
				{
					AFeyRJwCJKIvYooPUwaauNBljqic[j] = 0;
				}
				for (int k = 0; k < wLWolgipGooaLnizXtLOWnHATdEf.Length; k++)
				{
					wLWolgipGooaLnizXtLOWnHATdEf[k] = false;
				}
				TTMAvtnRDxKwlCGLhpimPVaPqJQy = 0f;
				uZyGWkDMwHDVJUsTIdVsKDkqDckcA = 0f;
				uSmIzzCttvgKlINnGwEIBSAvtThp = 0f;
				YPPRwBZQCqoNuVUudiTYdCPpxUYf = 0f;
				iLXRTlCWfLYgleHtyamUbeopJCjU = 0f;
				NcQgbsyJlZInXGmxrLslvUaaTaet = 0f;
				for (int l = 0; l < EZiSBBoIOCEOlmPjiZZDCUiAaUNV.Length; l++)
				{
					EZiSBBoIOCEOlmPjiZZDCUiAaUNV[l] = 0f;
				}
				fmmBJLkcLDkEEyELaQovvuLwFphW = 0f;
				nrehdBQGbcJDKyIfJITwxkRiHkwW = 0f;
				OqYjiUwXWOIGmqZGdOlGceEKYbdK = 0f;
				elJqCaXXUjAnTbZiWibSypvxdqLx = 0f;
				MZPfPuUvrkAHHAcwTYcqeurbKgxjb = 0f;
				sWDyxXuciPzURUQVgvrGcXdNYJSe = 0f;
				for (int m = 0; m < PMsfVLgBZsRIMOmmnaOjyVbeLLgO.Length; m++)
				{
					PMsfVLgBZsRIMOmmnaOjyVbeLLgO[m] = 0f;
				}
				XNtciUWSsebsqUhIggGTIufCZHfk = 0f;
				TFOXPIhgNEfexgLJqdOvsuZDFCxfb = 0f;
				uTceOhBypUmzIHlYTTkKtmolsAfp = 0f;
				ENGaWwSIPAuQMLPqVDvVFzeUerVyA = 0f;
				OyHTivCqxLeTWJOLJDhgVPJLRNCmA = 0f;
				mkSrNaGNbGPrpXgjbKLwpcRLGwzE = 0f;
				for (int n = 0; n < jWLOZZddeTrmIwocPFrmPKlWOCCN.Length; n++)
				{
					jWLOZZddeTrmIwocPFrmPKlWOCCN[n] = 0f;
				}
			}

			public void KqYdyIXFpEAbTeualcnGYpeGoslJA(mFqcGlIoDNpGGawMXZlbdnPyokvW P_0)
			{
				eniOQvUgCaxCkjMnvcsCKNMkkFkn = P_0.eniOQvUgCaxCkjMnvcsCKNMkkFkn;
				LqkaZBiLUHMqDpLxPqnNdYcSDrVGb = P_0.LqkaZBiLUHMqDpLxPqnNdYcSDrVGb;
				WAdGvfgxOZfAIqypJIzYRXdSMZlNA = P_0.WAdGvfgxOZfAIqypJIzYRXdSMZlNA;
				caarlfikKHFwfhVSobEDsDmroOLzA = P_0.caarlfikKHFwfhVSobEDsDmroOLzA;
				VYbeaTgVJSGENvEsNHRCZRFCDMJCA = P_0.VYbeaTgVJSGENvEsNHRCZRFCDMJCA;
				ulcdRKfNPBFDoKuDDCqVoGlERsDr = P_0.ulcdRKfNPBFDoKuDDCqVoGlERsDr;
				for (int i = 0; i < RKplkmPgWJZyQZwghRysBSodLPCY.Length; i++)
				{
					RKplkmPgWJZyQZwghRysBSodLPCY[i] = P_0.RKplkmPgWJZyQZwghRysBSodLPCY[i];
				}
				for (int j = 0; j < AFeyRJwCJKIvYooPUwaauNBljqic.Length; j++)
				{
					AFeyRJwCJKIvYooPUwaauNBljqic[j] = P_0.AFeyRJwCJKIvYooPUwaauNBljqic[j];
				}
				for (int k = 0; k < wLWolgipGooaLnizXtLOWnHATdEf.Length; k++)
				{
					wLWolgipGooaLnizXtLOWnHATdEf[k] = P_0.wLWolgipGooaLnizXtLOWnHATdEf[k];
				}
				TTMAvtnRDxKwlCGLhpimPVaPqJQy = P_0.TTMAvtnRDxKwlCGLhpimPVaPqJQy;
				uZyGWkDMwHDVJUsTIdVsKDkqDckcA = P_0.uZyGWkDMwHDVJUsTIdVsKDkqDckcA;
				uSmIzzCttvgKlINnGwEIBSAvtThp = P_0.uSmIzzCttvgKlINnGwEIBSAvtThp;
				YPPRwBZQCqoNuVUudiTYdCPpxUYf = P_0.YPPRwBZQCqoNuVUudiTYdCPpxUYf;
				iLXRTlCWfLYgleHtyamUbeopJCjU = P_0.iLXRTlCWfLYgleHtyamUbeopJCjU;
				NcQgbsyJlZInXGmxrLslvUaaTaet = P_0.NcQgbsyJlZInXGmxrLslvUaaTaet;
				for (int l = 0; l < EZiSBBoIOCEOlmPjiZZDCUiAaUNV.Length; l++)
				{
					EZiSBBoIOCEOlmPjiZZDCUiAaUNV[l] = P_0.EZiSBBoIOCEOlmPjiZZDCUiAaUNV[l];
				}
				fmmBJLkcLDkEEyELaQovvuLwFphW = P_0.fmmBJLkcLDkEEyELaQovvuLwFphW;
				nrehdBQGbcJDKyIfJITwxkRiHkwW = P_0.nrehdBQGbcJDKyIfJITwxkRiHkwW;
				OqYjiUwXWOIGmqZGdOlGceEKYbdK = P_0.OqYjiUwXWOIGmqZGdOlGceEKYbdK;
				elJqCaXXUjAnTbZiWibSypvxdqLx = P_0.elJqCaXXUjAnTbZiWibSypvxdqLx;
				MZPfPuUvrkAHHAcwTYcqeurbKgxjb = P_0.MZPfPuUvrkAHHAcwTYcqeurbKgxjb;
				sWDyxXuciPzURUQVgvrGcXdNYJSe = P_0.sWDyxXuciPzURUQVgvrGcXdNYJSe;
				for (int m = 0; m < PMsfVLgBZsRIMOmmnaOjyVbeLLgO.Length; m++)
				{
					PMsfVLgBZsRIMOmmnaOjyVbeLLgO[m] = P_0.PMsfVLgBZsRIMOmmnaOjyVbeLLgO[m];
				}
				XNtciUWSsebsqUhIggGTIufCZHfk = P_0.XNtciUWSsebsqUhIggGTIufCZHfk;
				TFOXPIhgNEfexgLJqdOvsuZDFCxfb = P_0.TFOXPIhgNEfexgLJqdOvsuZDFCxfb;
				uTceOhBypUmzIHlYTTkKtmolsAfp = P_0.uTceOhBypUmzIHlYTTkKtmolsAfp;
				ENGaWwSIPAuQMLPqVDvVFzeUerVyA = P_0.ENGaWwSIPAuQMLPqVDvVFzeUerVyA;
				OyHTivCqxLeTWJOLJDhgVPJLRNCmA = P_0.OyHTivCqxLeTWJOLJDhgVPJLRNCmA;
				mkSrNaGNbGPrpXgjbKLwpcRLGwzE = P_0.mkSrNaGNbGPrpXgjbKLwpcRLGwzE;
				for (int n = 0; n < jWLOZZddeTrmIwocPFrmPKlWOCCN.Length; n++)
				{
					jWLOZZddeTrmIwocPFrmPKlWOCCN[n] = P_0.jWLOZZddeTrmIwocPFrmPKlWOCCN[n];
				}
			}

			public unsafe void GIPpuCkRYkJtdjGQLmnLsbXOVkcU(ref LowLevelInputEvent P_0)
			{
				for (int i = 0; i < 4; i++)
				{
					int num = *(int*)((byte*)(void*)P_0._buffer + P_0.byteIndex_buttonsStart + i * 4);
					for (int j = 0; j < 32; j++)
					{
						wLWolgipGooaLnizXtLOWnHATdEf[i * 32 + j] = (num & (1 << j)) != 0;
					}
				}
				float* ptr = (float*)((byte*)(void*)P_0._buffer + P_0.byteIndex_axesStart);
				for (int k = 0; k < 2; k++)
				{
					PMsfVLgBZsRIMOmmnaOjyVbeLLgO[k] = *ptr;
					ptr++;
				}
				fmmBJLkcLDkEEyELaQovvuLwFphW = *ptr;
				ptr++;
				nrehdBQGbcJDKyIfJITwxkRiHkwW = *ptr;
				ptr++;
				OqYjiUwXWOIGmqZGdOlGceEKYbdK = *ptr;
				ptr++;
				elJqCaXXUjAnTbZiWibSypvxdqLx = *ptr;
				ptr++;
				MZPfPuUvrkAHHAcwTYcqeurbKgxjb = *ptr;
				ptr++;
				sWDyxXuciPzURUQVgvrGcXdNYJSe = *ptr;
				ptr++;
				YPPRwBZQCqoNuVUudiTYdCPpxUYf = *ptr;
				ptr++;
				iLXRTlCWfLYgleHtyamUbeopJCjU = *ptr;
				ptr++;
				NcQgbsyJlZInXGmxrLslvUaaTaet = *ptr;
				ptr++;
				for (int l = 0; l < 2; l++)
				{
					jWLOZZddeTrmIwocPFrmPKlWOCCN[l] = *ptr;
					ptr++;
				}
				XNtciUWSsebsqUhIggGTIufCZHfk = *ptr;
				ptr++;
				TFOXPIhgNEfexgLJqdOvsuZDFCxfb = *ptr;
				ptr++;
				uTceOhBypUmzIHlYTTkKtmolsAfp = *ptr;
				ptr++;
				caarlfikKHFwfhVSobEDsDmroOLzA = *ptr;
				ptr++;
				VYbeaTgVJSGENvEsNHRCZRFCDMJCA = *ptr;
				ptr++;
				ulcdRKfNPBFDoKuDDCqVoGlERsDr = *ptr;
				ptr++;
				for (int m = 0; m < 2; m++)
				{
					RKplkmPgWJZyQZwghRysBSodLPCY[m] = *ptr;
					ptr++;
				}
				ENGaWwSIPAuQMLPqVDvVFzeUerVyA = *ptr;
				ptr++;
				OyHTivCqxLeTWJOLJDhgVPJLRNCmA = *ptr;
				ptr++;
				mkSrNaGNbGPrpXgjbKLwpcRLGwzE = *ptr;
				ptr++;
				for (int n = 0; n < 2; n++)
				{
					EZiSBBoIOCEOlmPjiZZDCUiAaUNV[n] = *ptr;
					ptr++;
				}
				TTMAvtnRDxKwlCGLhpimPVaPqJQy = *ptr;
				ptr++;
				uZyGWkDMwHDVJUsTIdVsKDkqDckcA = *ptr;
				ptr++;
				uSmIzzCttvgKlINnGwEIBSAvtThp = *ptr;
				ptr++;
				eniOQvUgCaxCkjMnvcsCKNMkkFkn = *ptr;
				ptr++;
				LqkaZBiLUHMqDpLxPqnNdYcSDrVGb = *ptr;
				ptr++;
				WAdGvfgxOZfAIqypJIzYRXdSMZlNA = *ptr;
				ptr++;
				int* ptr2 = (int*)((byte*)(void*)P_0._buffer + P_0.byteIndex_hatsStart);
				for (int num2 = 0; num2 < 2; num2++)
				{
					AFeyRJwCJKIvYooPUwaauNBljqic[num2] = *ptr2;
					ptr2++;
				}
			}

			public unsafe static void SdvXhbHXYlSENkAehNLDhIwijOQw(YuqGSycdazpjQDmHVuiUuFfOMQsAA P_0, double P_1, LowLevelInputEvent P_2)
			{
				int[] array = P_0.VIFemHRsxjGJBymMifWdFGEZfKMi();
				int[] array2 = P_0.KAjHmViwsLxsNRKHOkAHHFdFmRcFA();
				int[] array3 = P_0.htHdZJmgLWQTrbBlVANIvPPugVIy();
				int[] array4 = P_0.iaXZoZvIFXjytzMBbbmkzbOKNxEO();
				int[] array5 = P_0.zwucKPtMFblGsSMOUVQHCHaeOKSl();
				*(double*)((byte*)(void*)P_2._buffer + 4) = P_1;
				int num = 0;
				int num2 = 0;
				int num3 = 0;
				for (int i = 0; i < 128; i++)
				{
					if (P_0.qErgkiWlApmmOQtkdLMfhzipsdiC()[i])
					{
						num |= 1 << num3;
					}
					num3++;
					if (num3 == 32)
					{
						*(int*)((byte*)(void*)P_2._buffer + P_2.byteIndex_buttonsStart + num2 * 4) = num;
						num3 = 0;
						num = 0;
						num2++;
					}
				}
				float* ptr = (float*)((byte*)(void*)P_2._buffer + P_2.byteIndex_axesStart);
				for (int j = 0; j < 2; j++)
				{
					*ptr = bqSumMLNXxQrYfDrDmkzcdhyxiOg(array2[j]);
					ptr++;
				}
				*ptr = bqSumMLNXxQrYfDrDmkzcdhyxiOg(P_0.hMMoBUXlIebxEIplMkDwVItzdUcR());
				ptr++;
				*ptr = bqSumMLNXxQrYfDrDmkzcdhyxiOg(P_0.cAHnZJbuoCjivqDWOTUdcgHJOmsF());
				ptr++;
				*ptr = bqSumMLNXxQrYfDrDmkzcdhyxiOg(P_0.yoXwtLbsxtTPRbovfpwcMyswBhPA());
				ptr++;
				*ptr = bqSumMLNXxQrYfDrDmkzcdhyxiOg(P_0.ZFjNvEnNIzOJQjpaKoHqVlcSYgXp());
				ptr++;
				*ptr = bqSumMLNXxQrYfDrDmkzcdhyxiOg(P_0.YZkWevoQyAqypxmIuVdetThqUMfL());
				ptr++;
				*ptr = bqSumMLNXxQrYfDrDmkzcdhyxiOg(P_0.oPHkHhlNMhhZmGxWQvmXHZUuMVnbA());
				ptr++;
				*ptr = bqSumMLNXxQrYfDrDmkzcdhyxiOg(P_0.mKONMghyjMppaqTTskdRSjjSoaDx());
				ptr++;
				*ptr = bqSumMLNXxQrYfDrDmkzcdhyxiOg(P_0.BLZHXdOiVSFYbXMOZfisIwjLONyj());
				ptr++;
				*ptr = bqSumMLNXxQrYfDrDmkzcdhyxiOg(P_0.sXsmbWsHPnxVtZRQxNHJjlyLkYwi());
				ptr++;
				for (int k = 0; k < 2; k++)
				{
					*ptr = bqSumMLNXxQrYfDrDmkzcdhyxiOg(array3[k]);
					ptr++;
				}
				*ptr = bqSumMLNXxQrYfDrDmkzcdhyxiOg(P_0.BPbUNfqSweRpKTKVTYsIHPUPaCzFA());
				ptr++;
				*ptr = bqSumMLNXxQrYfDrDmkzcdhyxiOg(P_0.dDRWBgMSyKkAHmwkNMseVebyutgT());
				ptr++;
				*ptr = bqSumMLNXxQrYfDrDmkzcdhyxiOg(P_0.eSydsUkDDXBIwUKihnwRcVSFZTlZB());
				ptr++;
				*ptr = bqSumMLNXxQrYfDrDmkzcdhyxiOg(P_0.EYXvsRfzGMJLtDhYQYigKafuCUZH());
				ptr++;
				*ptr = bqSumMLNXxQrYfDrDmkzcdhyxiOg(P_0.dihzeHqQKJKeUpfhRFhZViySmzgu());
				ptr++;
				*ptr = bqSumMLNXxQrYfDrDmkzcdhyxiOg(P_0.YNpRVxrnJEqVFeuFMCiSzRKeusaD());
				ptr++;
				for (int l = 0; l < 2; l++)
				{
					*ptr = bqSumMLNXxQrYfDrDmkzcdhyxiOg(array4[l]);
					ptr++;
				}
				*ptr = bqSumMLNXxQrYfDrDmkzcdhyxiOg(P_0.mNsyLJeDNbvJAwAigrgyKpIHslpI());
				ptr++;
				*ptr = bqSumMLNXxQrYfDrDmkzcdhyxiOg(P_0.dmuCofuxFJhCBfVvDINZstogxQNN());
				ptr++;
				*ptr = bqSumMLNXxQrYfDrDmkzcdhyxiOg(P_0.ouznYnQQrmmrsleoCCtNmQovpPjV());
				ptr++;
				for (int m = 0; m < 2; m++)
				{
					*ptr = bqSumMLNXxQrYfDrDmkzcdhyxiOg(array5[m]);
					ptr++;
				}
				*ptr = bqSumMLNXxQrYfDrDmkzcdhyxiOg(P_0.ECAgwQPifQAHnJYjEsedHOvPkEypA());
				ptr++;
				*ptr = bqSumMLNXxQrYfDrDmkzcdhyxiOg(P_0.orgIJYsAcoxhqsqULGfAuYvGtJvl());
				ptr++;
				*ptr = bqSumMLNXxQrYfDrDmkzcdhyxiOg(P_0.osrqxkLCfXBabdzyrpcxbZMnixYLA());
				ptr++;
				*ptr = bqSumMLNXxQrYfDrDmkzcdhyxiOg(P_0.gxBsFsxYeUvctokfGCURaGsbUyutA());
				ptr++;
				*ptr = bqSumMLNXxQrYfDrDmkzcdhyxiOg(P_0.EAvyVrLlffIGBCwCKlgkROkiFcxXA());
				ptr++;
				*ptr = bqSumMLNXxQrYfDrDmkzcdhyxiOg(P_0.UrCOMSWhfcnCYPbVZuYqurcFgmyh());
				ptr++;
				int* ptr2 = (int*)((byte*)(void*)P_2._buffer + P_2.byteIndex_hatsStart);
				for (int n = 0; n < 2; n++)
				{
					*ptr2 = array[n];
					ptr2++;
				}
			}
		}

		private const int NZIzcnKxKLtREcnSZKkFsKfKkTVq = 2;

		private const int wWKiqEwhyoHgzOKjteWpXDGwojPi = 2;

		private const int gHrBbriYLTTeeQzlmUbPErOZbkhM = 128;

		private const int EegEkBiRraOfUJvlRmjIeQPnQfTXA = 32;

		private const int tZLZKvYPHeDmbmcrnpKCtgDUTzRf = 0;

		private const int oqYTIVcFBMiQbuhLIBHRcbRPRRRHA = 264;

		private const int UbpvAvfGxDEWXaVCWVnFpBIuCTTZA = 272;

		private readonly int RfECykiYiPGLsuqWvPPblYLpPduz;

		private readonly ButtonLoopSet VqmSjYRCONiDssxrvObZOhFJzTrH;

		private readonly DualThreadLowLevelInputEventQueue jiCOpKzwccINZWzdWsBZOVolhpWb;

		private VjfuHeFygffLuqAipbnIvtIFlrzX GlmJXxaXJqRajDOGXLQrdqQUYsHt;

		private readonly YuqGSycdazpjQDmHVuiUuFfOMQsAA PWVlXwJiXmUMvzYEJHKeZtRhTZPv;

		private readonly YuqGSycdazpjQDmHVuiUuFfOMQsAA xxDjsNhFPHqeFPwqdzAnUaaWRReL;

		private readonly object EWzMEqImzhRiVyifyGofKhbZJDNw;

		private bool gVVVyQOaGPHxPqXzKCsVfMyJShvpA;

		public readonly acNIMEkbdUZflpTVBxiqmIgjMDSMA GEoeNkUyEAnoWoaHezTHrqBHFKiB;

		private readonly mFqcGlIoDNpGGawMXZlbdnPyokvW mYtYHhjSOXNfNqWYmNtFzitClZxS;

		private bool XBYcBPdvRgIYCuNObPNJWOmtscBlA;

		public bool[] PaigFPdhANmgddGTjbhFNyagwiiVb => vmAFruJiynFnzgtkmeOnlJiaoMwlA();

		public mFqcGlIoDNpGGawMXZlbdnPyokvW umpYJMkqhmuJvBAMjDsvwXJXQkMm => LiOPZRMCoMUrnpKWTiYqdEtkpLjW();

		public bool[] vmAFruJiynFnzgtkmeOnlJiaoMwlA()
		{
			return VqmSjYRCONiDssxrvObZOhFJzTrH.Current.effectiveValue;
		}

		public mFqcGlIoDNpGGawMXZlbdnPyokvW LiOPZRMCoMUrnpKWTiYqdEtkpLjW()
		{
			return mYtYHhjSOXNfNqWYmNtFzitClZxS;
		}

		public mxyNLHmDPnGdTytmKVWDUPaQCKgj(acNIMEkbdUZflpTVBxiqmIgjMDSMA P_0, UpdateLoopSetting P_1)
		{
			GEoeNkUyEAnoWoaHezTHrqBHFKiB = P_0;
			RfECykiYiPGLsuqWvPPblYLpPduz = P_0.PEwJSkJWMSoSqZezTztTuZDIRWxk().OHYegIVvjHrdtWrbLQKrhxBWGoqV;
			VqmSjYRCONiDssxrvObZOhFJzTrH = new ButtonLoopSet(P_1, RfECykiYiPGLsuqWvPPblYLpPduz);
			jiCOpKzwccINZWzdWsBZOVolhpWb = new DualThreadLowLevelInputEventQueue((int)((float)hmRdjlkkAraUbAOZelrfFnsoEfpCB.HdYjuOcsUBMbxACBttaMRLoAARlu() * 0.25f), 128, 32, 2);
			mYtYHhjSOXNfNqWYmNtFzitClZxS = new mFqcGlIoDNpGGawMXZlbdnPyokvW();
			PWVlXwJiXmUMvzYEJHKeZtRhTZPv = new YuqGSycdazpjQDmHVuiUuFfOMQsAA();
			xxDjsNhFPHqeFPwqdzAnUaaWRReL = new YuqGSycdazpjQDmHVuiUuFfOMQsAA();
			EWzMEqImzhRiVyifyGofKhbZJDNw = new object();
			if (hmRdjlkkAraUbAOZelrfFnsoEfpCB.ikUrOmsIKNMiTmyUGnratMoHlLVn() != null)
			{
				hmRdjlkkAraUbAOZelrfFnsoEfpCB.ikUrOmsIKNMiTmyUGnratMoHlLVn().ThreadUpdateEvent += ELSCLNXoPqdvzbqYyqQhbZCpBKksA;
			}
		}

		public void vSigOeirBmRMvhvhhLsGdZsRddTPb()
		{
			VqmSjYRCONiDssxrvObZOhFJzTrH.SetUpdateLoop(ReInput.currentUpdateLoop);
			vuHiVnyqpmygxeILizTXZMTkedqH();
		}

		public void HsMPsLseJdKDRSTyNjGRRxEgVzMb()
		{
			VqmSjYRCONiDssxrvObZOhFJzTrH.Current.ClearWasTrueThisFrame();
		}

		public void IHlijJlPUAiCHRoeNBjjolJtCcSR()
		{
			UIazagbdawALWHebbxBmpGfLBmYA();
			gVVVyQOaGPHxPqXzKCsVfMyJShvpA = true;
		}

		public void fexkNDCWZfSMkBNEIOmmvIsvUMcl()
		{
			gVVVyQOaGPHxPqXzKCsVfMyJShvpA = false;
			UIazagbdawALWHebbxBmpGfLBmYA();
		}

		public void GmbQFymCsOMTgrUXhvEoRHhsJVjL(mxyNLHmDPnGdTytmKVWDUPaQCKgj P_0)
		{
			if (P_0 == null || P_0 == this || P_0.RfECykiYiPGLsuqWvPPblYLpPduz != RfECykiYiPGLsuqWvPPblYLpPduz)
			{
				return;
			}
			_ = ReInput.realTime;
			lock (EWzMEqImzhRiVyifyGofKhbZJDNw)
			{
				lock (P_0.EWzMEqImzhRiVyifyGofKhbZJDNw)
				{
					VqmSjYRCONiDssxrvObZOhFJzTrH.Import(P_0.VqmSjYRCONiDssxrvObZOhFJzTrH);
					mYtYHhjSOXNfNqWYmNtFzitClZxS.KqYdyIXFpEAbTeualcnGYpeGoslJA(P_0.mYtYHhjSOXNfNqWYmNtFzitClZxS);
					PWVlXwJiXmUMvzYEJHKeZtRhTZPv.wjqAZxGnVLDwllgZNpfbIFjYBzHv(P_0.PWVlXwJiXmUMvzYEJHKeZtRhTZPv);
					xxDjsNhFPHqeFPwqdzAnUaaWRReL.wjqAZxGnVLDwllgZNpfbIFjYBzHv(P_0.xxDjsNhFPHqeFPwqdzAnUaaWRReL);
					jiCOpKzwccINZWzdWsBZOVolhpWb.ImportAll(P_0.jiCOpKzwccINZWzdWsBZOVolhpWb);
					GlmJXxaXJqRajDOGXLQrdqQUYsHt = VjfuHeFygffLuqAipbnIvtIFlrzX.JEwETIFdqZEDMgipaiglVwgUuQqQ(P_0.GlmJXxaXJqRajDOGXLQrdqQUYsHt, PWVlXwJiXmUMvzYEJHKeZtRhTZPv);
					gVVVyQOaGPHxPqXzKCsVfMyJShvpA = P_0.gVVVyQOaGPHxPqXzKCsVfMyJShvpA;
				}
			}
		}

		public void xQvZxzEyadmZMSQMbaxlnmsxNtuT(int P_0, int P_1, int P_2, float P_3)
		{
			lock (EWzMEqImzhRiVyifyGofKhbZJDNw)
			{
				GlmJXxaXJqRajDOGXLQrdqQUYsHt = new VjfuHeFygffLuqAipbnIvtIFlrzX(PWVlXwJiXmUMvzYEJHKeZtRhTZPv, P_0, P_1, P_2, P_3);
			}
		}

		private void ELSCLNXoPqdvzbqYyqQhbZCpBKksA()
		{
			if (!gVVVyQOaGPHxPqXzKCsVfMyJShvpA)
			{
				return;
			}
			double realTime;
			try
			{
				GEoeNkUyEAnoWoaHezTHrqBHFKiB.iAGRPQSwcwVoPrZacOrKRsuzvKxL(PWVlXwJiXmUMvzYEJHKeZtRhTZPv);
				realTime = ReInput.realTime;
			}
			catch
			{
				return;
			}
			lock (EWzMEqImzhRiVyifyGofKhbZJDNw)
			{
				if (GlmJXxaXJqRajDOGXLQrdqQUYsHt != null)
				{
					GlmJXxaXJqRajDOGXLQrdqQUYsHt.AHEgGkeLHrjZahzpDxssAfOamVZDc(realTime);
				}
				if (!PWVlXwJiXmUMvzYEJHKeZtRhTZPv.GFSbljyWeHISjvuNPloWMnqfZPxm(xxDjsNhFPHqeFPwqdzAnUaaWRReL))
				{
					using (DualThreadLowLevelInputEventQueue.INewEventWrapper newEventWrapper = jiCOpKzwccINZWzdWsBZOVolhpWb.T_CreateEvent())
					{
						mFqcGlIoDNpGGawMXZlbdnPyokvW.SdvXhbHXYlSENkAehNLDhIwijOQw(PWVlXwJiXmUMvzYEJHKeZtRhTZPv, realTime, newEventWrapper.Event);
					}
					xxDjsNhFPHqeFPwqdzAnUaaWRReL.wjqAZxGnVLDwllgZNpfbIFjYBzHv(PWVlXwJiXmUMvzYEJHKeZtRhTZPv);
				}
			}
		}

		private void vuHiVnyqpmygxeILizTXZMTkedqH()
		{
			while (jiCOpKzwccINZWzdWsBZOVolhpWb.ProcessNewEvents())
			{
				mYtYHhjSOXNfNqWYmNtFzitClZxS.GIPpuCkRYkJtdjGQLmnLsbXOVkcU(ref jiCOpKzwccINZWzdWsBZOVolhpWb.currentEvent);
				for (int i = 0; i < RfECykiYiPGLsuqWvPPblYLpPduz; i++)
				{
					VqmSjYRCONiDssxrvObZOhFJzTrH.SetValue(i, mYtYHhjSOXNfNqWYmNtFzitClZxS.wLWolgipGooaLnizXtLOWnHATdEf[i], jiCOpKzwccINZWzdWsBZOVolhpWb.currentEvent.GetTimestamp());
				}
			}
		}

		private void UIazagbdawALWHebbxBmpGfLBmYA()
		{
			mYtYHhjSOXNfNqWYmNtFzitClZxS.cFdiSnWvZyemVwBPoCPScgWQCaVHA();
			lock (EWzMEqImzhRiVyifyGofKhbZJDNw)
			{
				PWVlXwJiXmUMvzYEJHKeZtRhTZPv.lVORcKdQVVLPWsjZxBrJrmsMQxwd();
				xxDjsNhFPHqeFPwqdzAnUaaWRReL.lVORcKdQVVLPWsjZxBrJrmsMQxwd();
				jiCOpKzwccINZWzdWsBZOVolhpWb.Clear();
			}
			VqmSjYRCONiDssxrvObZOhFJzTrH.Clear();
		}

		public void Dispose()
		{
			DTVUlUgmPUkxoqJIcAzcqKRTCKIM(true);
			GC.SuppressFinalize(this);
		}

		void IDisposable.Dispose()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Dispose
			this.Dispose();
		}

		protected virtual void QnAhDGuatyivCEfLazYdkmHtIQJD()
		{
			try
			{
				DTVUlUgmPUkxoqJIcAzcqKRTCKIM(false);
			}
			finally
			{
				base.Finalize();
			}
		}

		protected virtual void DTVUlUgmPUkxoqJIcAzcqKRTCKIM(bool P_0)
		{
			if (!XBYcBPdvRgIYCuNObPNJWOmtscBlA)
			{
				if (P_0)
				{
					fexkNDCWZfSMkBNEIOmmvIsvUMcl();
					jiCOpKzwccINZWzdWsBZOVolhpWb.Dispose();
				}
				if (hmRdjlkkAraUbAOZelrfFnsoEfpCB.ikUrOmsIKNMiTmyUGnratMoHlLVn() != null)
				{
					hmRdjlkkAraUbAOZelrfFnsoEfpCB.ikUrOmsIKNMiTmyUGnratMoHlLVn().ThreadUpdateEvent -= ELSCLNXoPqdvzbqYyqQhbZCpBKksA;
				}
				XBYcBPdvRgIYCuNObPNJWOmtscBlA = true;
			}
		}

		private static float bqSumMLNXxQrYfDrDmkzcdhyxiOg(int P_0)
		{
			if (P_0 == 0)
			{
				return 0f;
			}
			return MathTools.Clamp((float)MathTools.Abs(P_0) / 65535f * (float)MathTools.Sign(P_0), -1f, 1f);
		}
	}

	private class VjfuHeFygffLuqAipbnIvtIFlrzX
	{
		private YuqGSycdazpjQDmHVuiUuFfOMQsAA BZNDtikWKcEUabQGczeYUemkJkQAA;

		private ioIqXdyJRxxIaGIrjFdVGZUtgIqg DpjyBCmXNcrVytmZoaVGEYOkUfXm;

		private int SCeDefJoXMdNmWrekfBqwtVKIOWAA;

		private int MTfoeitoIfGpWbVdyHrnBKXviFVPA;

		private int XzflbfqdQwRYRYTMtKaQGlFzARTiA;

		private float dLYMhgZJDZceifMTEklghfhlUVrC;

		public YuqGSycdazpjQDmHVuiUuFfOMQsAA jDLMlwjEnTcvRmEiIEHRJmLatqSO => nYtPxpzsongvsglNdkOsLCmrIiBH();

		public YuqGSycdazpjQDmHVuiUuFfOMQsAA nYtPxpzsongvsglNdkOsLCmrIiBH()
		{
			return BZNDtikWKcEUabQGczeYUemkJkQAA;
		}

		public static VjfuHeFygffLuqAipbnIvtIFlrzX JEwETIFdqZEDMgipaiglVwgUuQqQ(VjfuHeFygffLuqAipbnIvtIFlrzX P_0, YuqGSycdazpjQDmHVuiUuFfOMQsAA P_1)
		{
			if (P_0 == null || P_1 == null)
			{
				return null;
			}
			return new VjfuHeFygffLuqAipbnIvtIFlrzX(P_0, P_1);
		}

		public VjfuHeFygffLuqAipbnIvtIFlrzX(YuqGSycdazpjQDmHVuiUuFfOMQsAA P_0, int P_1, int P_2, int P_3, float P_4)
			: this(P_1, P_2, P_3, P_4)
		{
			DpjyBCmXNcrVytmZoaVGEYOkUfXm = new ioIqXdyJRxxIaGIrjFdVGZUtgIqg(P_0);
			BZNDtikWKcEUabQGczeYUemkJkQAA = new YuqGSycdazpjQDmHVuiUuFfOMQsAA();
		}

		private VjfuHeFygffLuqAipbnIvtIFlrzX(VjfuHeFygffLuqAipbnIvtIFlrzX P_0, YuqGSycdazpjQDmHVuiUuFfOMQsAA P_1)
			: this(P_1, P_0.SCeDefJoXMdNmWrekfBqwtVKIOWAA, P_0.MTfoeitoIfGpWbVdyHrnBKXviFVPA, P_0.XzflbfqdQwRYRYTMtKaQGlFzARTiA, P_0.dLYMhgZJDZceifMTEklghfhlUVrC)
		{
			UFYdKIkVyQYWxLCpdbbOauSffKqZB(P_0);
		}

		private VjfuHeFygffLuqAipbnIvtIFlrzX(int P_0, int P_1, int P_2, float P_3)
		{
			SCeDefJoXMdNmWrekfBqwtVKIOWAA = P_0;
			MTfoeitoIfGpWbVdyHrnBKXviFVPA = P_1;
			XzflbfqdQwRYRYTMtKaQGlFzARTiA = P_2;
			dLYMhgZJDZceifMTEklghfhlUVrC = P_3;
		}

		public void AHEgGkeLHrjZahzpDxssAfOamVZDc(double P_0)
		{
			DpjyBCmXNcrVytmZoaVGEYOkUfXm.IeLzKjjozATUPllpQncILOqnarRJA(P_0);
			if (!DpjyBCmXNcrVytmZoaVGEYOkUfXm.AXvrVAhnFyTjnteEizwgyrPWXLIh())
			{
				if (P_0 >= DpjyBCmXNcrVytmZoaVGEYOkUfXm.AbWALNfgqulEgnNdXvwpGPKCFkcKA() + (double)dLYMhgZJDZceifMTEklghfhlUVrC)
				{
					BZNDtikWKcEUabQGczeYUemkJkQAA.lVORcKdQVVLPWsjZxBrJrmsMQxwd();
				}
				return;
			}
			YuqGSycdazpjQDmHVuiUuFfOMQsAA yuqGSycdazpjQDmHVuiUuFfOMQsAA = DpjyBCmXNcrVytmZoaVGEYOkUfXm.ITVUFjEKDyqwhjhZWHNQSWoUBhKf();
			YuqGSycdazpjQDmHVuiUuFfOMQsAA yuqGSycdazpjQDmHVuiUuFfOMQsAA2 = DpjyBCmXNcrVytmZoaVGEYOkUfXm.QXLzAaMzCJHPBNYNvptLwBDRbptE();
			BZNDtikWKcEUabQGczeYUemkJkQAA.gVGRUQcMighyPhWaDIkmCJvFGyBw(JQEzpbrKZOUIPzgUIYyoxHgICzTr(yuqGSycdazpjQDmHVuiUuFfOMQsAA.gxBsFsxYeUvctokfGCURaGsbUyutA()));
			BZNDtikWKcEUabQGczeYUemkJkQAA.hqCnngQbBRFrZhkjkllRjfLAbgfUA(JQEzpbrKZOUIPzgUIYyoxHgICzTr(yuqGSycdazpjQDmHVuiUuFfOMQsAA.EAvyVrLlffIGBCwCKlgkROkiFcxXA()));
			BZNDtikWKcEUabQGczeYUemkJkQAA.uCANnogNTsLSmjmxGLThriOckHRU(JQEzpbrKZOUIPzgUIYyoxHgICzTr(yuqGSycdazpjQDmHVuiUuFfOMQsAA.UrCOMSWhfcnCYPbVZuYqurcFgmyh()));
			BZNDtikWKcEUabQGczeYUemkJkQAA.adUXlANyOrBwgVfYqtXWfEtQBUur(JQEzpbrKZOUIPzgUIYyoxHgICzTr(yuqGSycdazpjQDmHVuiUuFfOMQsAA.EYXvsRfzGMJLtDhYQYigKafuCUZH()));
			BZNDtikWKcEUabQGczeYUemkJkQAA.sRtpCnhbIbGVPcnsuVCBVBNPjRmO(JQEzpbrKZOUIPzgUIYyoxHgICzTr(yuqGSycdazpjQDmHVuiUuFfOMQsAA.dihzeHqQKJKeUpfhRFhZViySmzgu()));
			BZNDtikWKcEUabQGczeYUemkJkQAA.KEwbFZlzXieGfqIBzIjRhIlAgvMf(JQEzpbrKZOUIPzgUIYyoxHgICzTr(yuqGSycdazpjQDmHVuiUuFfOMQsAA.YNpRVxrnJEqVFeuFMCiSzRKeusaD()));
			for (int i = 0; i < BZNDtikWKcEUabQGczeYUemkJkQAA.iaXZoZvIFXjytzMBbbmkzbOKNxEO().Length; i++)
			{
				BZNDtikWKcEUabQGczeYUemkJkQAA.iaXZoZvIFXjytzMBbbmkzbOKNxEO()[i] = JQEzpbrKZOUIPzgUIYyoxHgICzTr(yuqGSycdazpjQDmHVuiUuFfOMQsAA.iaXZoZvIFXjytzMBbbmkzbOKNxEO()[i]);
			}
			for (int j = 0; j < BZNDtikWKcEUabQGczeYUemkJkQAA.VIFemHRsxjGJBymMifWdFGEZfKMi().Length; j++)
			{
				BZNDtikWKcEUabQGczeYUemkJkQAA.VIFemHRsxjGJBymMifWdFGEZfKMi()[j] = JQEzpbrKZOUIPzgUIYyoxHgICzTr(yuqGSycdazpjQDmHVuiUuFfOMQsAA.VIFemHRsxjGJBymMifWdFGEZfKMi()[j]);
			}
			for (int k = 0; k < BZNDtikWKcEUabQGczeYUemkJkQAA.qErgkiWlApmmOQtkdLMfhzipsdiC().Length; k++)
			{
				BZNDtikWKcEUabQGczeYUemkJkQAA.qErgkiWlApmmOQtkdLMfhzipsdiC()[k] = yuqGSycdazpjQDmHVuiUuFfOMQsAA2.qErgkiWlApmmOQtkdLMfhzipsdiC()[k];
			}
			BZNDtikWKcEUabQGczeYUemkJkQAA.bxXMIOARUxfKHqGuVXYMiyPlQJtr(JQEzpbrKZOUIPzgUIYyoxHgICzTr(yuqGSycdazpjQDmHVuiUuFfOMQsAA.ECAgwQPifQAHnJYjEsedHOvPkEypA()));
			BZNDtikWKcEUabQGczeYUemkJkQAA.noNbptBMdJCNTewrApbCqnnHpBit(JQEzpbrKZOUIPzgUIYyoxHgICzTr(yuqGSycdazpjQDmHVuiUuFfOMQsAA.orgIJYsAcoxhqsqULGfAuYvGtJvl()));
			BZNDtikWKcEUabQGczeYUemkJkQAA.JVGlJlJGLhLReeNFKyziJBNhDNweA(JQEzpbrKZOUIPzgUIYyoxHgICzTr(yuqGSycdazpjQDmHVuiUuFfOMQsAA.osrqxkLCfXBabdzyrpcxbZMnixYLA()));
			BZNDtikWKcEUabQGczeYUemkJkQAA.LZHDTBGTGJBvHpxjtLuaMeLwoBYBb(JQEzpbrKZOUIPzgUIYyoxHgICzTr(yuqGSycdazpjQDmHVuiUuFfOMQsAA.mKONMghyjMppaqTTskdRSjjSoaDx()));
			BZNDtikWKcEUabQGczeYUemkJkQAA.dApOlPteWLAjRuSBVQUEPkSRRHZy(JQEzpbrKZOUIPzgUIYyoxHgICzTr(yuqGSycdazpjQDmHVuiUuFfOMQsAA.BLZHXdOiVSFYbXMOZfisIwjLONyj()));
			BZNDtikWKcEUabQGczeYUemkJkQAA.bFUAAAkutuMRXXDeMKeooBfXcricb(JQEzpbrKZOUIPzgUIYyoxHgICzTr(yuqGSycdazpjQDmHVuiUuFfOMQsAA.sXsmbWsHPnxVtZRQxNHJjlyLkYwi()));
			for (int l = 0; l < BZNDtikWKcEUabQGczeYUemkJkQAA.zwucKPtMFblGsSMOUVQHCHaeOKSl().Length; l++)
			{
				BZNDtikWKcEUabQGczeYUemkJkQAA.zwucKPtMFblGsSMOUVQHCHaeOKSl()[l] = JQEzpbrKZOUIPzgUIYyoxHgICzTr(yuqGSycdazpjQDmHVuiUuFfOMQsAA.zwucKPtMFblGsSMOUVQHCHaeOKSl()[l]);
			}
			BZNDtikWKcEUabQGczeYUemkJkQAA.jJNcvzBHUSebijLXdZQVXmXTLvlTA(JQEzpbrKZOUIPzgUIYyoxHgICzTr(yuqGSycdazpjQDmHVuiUuFfOMQsAA.hMMoBUXlIebxEIplMkDwVItzdUcR()));
			BZNDtikWKcEUabQGczeYUemkJkQAA.CLDaKpEuhnSEdGqAPGGKdUMtCsFt(JQEzpbrKZOUIPzgUIYyoxHgICzTr(yuqGSycdazpjQDmHVuiUuFfOMQsAA.cAHnZJbuoCjivqDWOTUdcgHJOmsF()));
			BZNDtikWKcEUabQGczeYUemkJkQAA.CVCqlbfrLcROvwocrFPiyKpPDnPH(JQEzpbrKZOUIPzgUIYyoxHgICzTr(yuqGSycdazpjQDmHVuiUuFfOMQsAA.yoXwtLbsxtTPRbovfpwcMyswBhPA()));
			BZNDtikWKcEUabQGczeYUemkJkQAA.JWktXkzDOKqOVAFemWirUecheDWDA(JQEzpbrKZOUIPzgUIYyoxHgICzTr(yuqGSycdazpjQDmHVuiUuFfOMQsAA.ZFjNvEnNIzOJQjpaKoHqVlcSYgXp()));
			BZNDtikWKcEUabQGczeYUemkJkQAA.bmwDTUcZdzhHqRrAUsGaHGVyNffEA(JQEzpbrKZOUIPzgUIYyoxHgICzTr(yuqGSycdazpjQDmHVuiUuFfOMQsAA.YZkWevoQyAqypxmIuVdetThqUMfL()));
			BZNDtikWKcEUabQGczeYUemkJkQAA.frxLzrUxjgFvGEIGQQBFdfgUNuVW(JQEzpbrKZOUIPzgUIYyoxHgICzTr(yuqGSycdazpjQDmHVuiUuFfOMQsAA.oPHkHhlNMhhZmGxWQvmXHZUuMVnbA()));
			for (int m = 0; m < BZNDtikWKcEUabQGczeYUemkJkQAA.KAjHmViwsLxsNRKHOkAHHFdFmRcFA().Length; m++)
			{
				BZNDtikWKcEUabQGczeYUemkJkQAA.KAjHmViwsLxsNRKHOkAHHFdFmRcFA()[m] = JQEzpbrKZOUIPzgUIYyoxHgICzTr(yuqGSycdazpjQDmHVuiUuFfOMQsAA.KAjHmViwsLxsNRKHOkAHHFdFmRcFA()[m]);
			}
			BZNDtikWKcEUabQGczeYUemkJkQAA.jqPZwrXKWDMJKWLcxVCcsYOJsIb(JQEzpbrKZOUIPzgUIYyoxHgICzTr(yuqGSycdazpjQDmHVuiUuFfOMQsAA.BPbUNfqSweRpKTKVTYsIHPUPaCzFA()));
			BZNDtikWKcEUabQGczeYUemkJkQAA.TDrIZzkzrWVdnvgXJdHyhZCUDuIb(JQEzpbrKZOUIPzgUIYyoxHgICzTr(yuqGSycdazpjQDmHVuiUuFfOMQsAA.dDRWBgMSyKkAHmwkNMseVebyutgT()));
			BZNDtikWKcEUabQGczeYUemkJkQAA.sJbNswVnImaRUKFOMWJLpisGtnSlA(JQEzpbrKZOUIPzgUIYyoxHgICzTr(yuqGSycdazpjQDmHVuiUuFfOMQsAA.eSydsUkDDXBIwUKihnwRcVSFZTlZB()));
			BZNDtikWKcEUabQGczeYUemkJkQAA.xxckuZZTVdSiEOIFLwQCgSbUbyyH(JQEzpbrKZOUIPzgUIYyoxHgICzTr(yuqGSycdazpjQDmHVuiUuFfOMQsAA.mNsyLJeDNbvJAwAigrgyKpIHslpI()));
			BZNDtikWKcEUabQGczeYUemkJkQAA.HRFztwnJJIQvyjVXdeyLvqftbEwO(JQEzpbrKZOUIPzgUIYyoxHgICzTr(yuqGSycdazpjQDmHVuiUuFfOMQsAA.dmuCofuxFJhCBfVvDINZstogxQNN()));
			BZNDtikWKcEUabQGczeYUemkJkQAA.iZszwVbXcdZXbKOSrNTcnHZRrhzH(JQEzpbrKZOUIPzgUIYyoxHgICzTr(yuqGSycdazpjQDmHVuiUuFfOMQsAA.ouznYnQQrmmrsleoCCtNmQovpPjV()));
			for (int n = 0; n < BZNDtikWKcEUabQGczeYUemkJkQAA.htHdZJmgLWQTrbBlVANIvPPugVIy().Length; n++)
			{
				BZNDtikWKcEUabQGczeYUemkJkQAA.htHdZJmgLWQTrbBlVANIvPPugVIy()[n] = JQEzpbrKZOUIPzgUIYyoxHgICzTr(yuqGSycdazpjQDmHVuiUuFfOMQsAA.htHdZJmgLWQTrbBlVANIvPPugVIy()[n]);
			}
		}

		public void UFYdKIkVyQYWxLCpdbbOauSffKqZB(VjfuHeFygffLuqAipbnIvtIFlrzX P_0)
		{
			BZNDtikWKcEUabQGczeYUemkJkQAA.wjqAZxGnVLDwllgZNpfbIFjYBzHv(P_0.BZNDtikWKcEUabQGczeYUemkJkQAA);
			DpjyBCmXNcrVytmZoaVGEYOkUfXm.vtakmScSNYeOjoEfnhChsrnXHOGAA(P_0.DpjyBCmXNcrVytmZoaVGEYOkUfXm);
			SCeDefJoXMdNmWrekfBqwtVKIOWAA = P_0.SCeDefJoXMdNmWrekfBqwtVKIOWAA;
			MTfoeitoIfGpWbVdyHrnBKXviFVPA = P_0.MTfoeitoIfGpWbVdyHrnBKXviFVPA;
			XzflbfqdQwRYRYTMtKaQGlFzARTiA = P_0.XzflbfqdQwRYRYTMtKaQGlFzARTiA;
			dLYMhgZJDZceifMTEklghfhlUVrC = P_0.dLYMhgZJDZceifMTEklghfhlUVrC;
		}

		private int JQEzpbrKZOUIPzgUIYyoxHgICzTr(int P_0)
		{
			return MathTools.ValueInNewRange(P_0, SCeDefJoXMdNmWrekfBqwtVKIOWAA, MTfoeitoIfGpWbVdyHrnBKXviFVPA, -65535, 65535);
		}
	}

	private class ioIqXdyJRxxIaGIrjFdVGZUtgIqg
	{
		private double JfySfjeInkhadImQyqXydIHGUVlEA;

		private YuqGSycdazpjQDmHVuiUuFfOMQsAA LsitRWqnnQBCFMyhuNRHujjSaGau;

		private YuqGSycdazpjQDmHVuiUuFfOMQsAA YcJWQcvBczXvHGAzrcxUGuHePFZtA;

		private YuqGSycdazpjQDmHVuiUuFfOMQsAA qqeuWXaELsSbdNOWtBeApGJuuLuE;

		private bool nifAMAnzFAFfOKQrWASgGzHoYgjA;

		private double zDpIbfhFiUrlBXAPBabFhUaZnSoFb;

		public YuqGSycdazpjQDmHVuiUuFfOMQsAA rnTXghsnwlKIxocamDwLwjmYyIEv => QXLzAaMzCJHPBNYNvptLwBDRbptE();

		public YuqGSycdazpjQDmHVuiUuFfOMQsAA UvNzfDuarzXvQiJLtwobJlwPLGdk => ITVUFjEKDyqwhjhZWHNQSWoUBhKf();

		public bool OPzJcWVdQjafQsCWaaUtqnTuhdkC => AXvrVAhnFyTjnteEizwgyrPWXLIh();

		public double XbsvkfVfuvhLJVNzAgwwkLHrAmwy => AbWALNfgqulEgnNdXvwpGPKCFkcKA();

		public YuqGSycdazpjQDmHVuiUuFfOMQsAA QXLzAaMzCJHPBNYNvptLwBDRbptE()
		{
			return LsitRWqnnQBCFMyhuNRHujjSaGau;
		}

		public YuqGSycdazpjQDmHVuiUuFfOMQsAA ITVUFjEKDyqwhjhZWHNQSWoUBhKf()
		{
			return qqeuWXaELsSbdNOWtBeApGJuuLuE;
		}

		public bool AXvrVAhnFyTjnteEizwgyrPWXLIh()
		{
			return nifAMAnzFAFfOKQrWASgGzHoYgjA;
		}

		public double AbWALNfgqulEgnNdXvwpGPKCFkcKA()
		{
			return zDpIbfhFiUrlBXAPBabFhUaZnSoFb;
		}

		public ioIqXdyJRxxIaGIrjFdVGZUtgIqg(YuqGSycdazpjQDmHVuiUuFfOMQsAA P_0)
		{
			LsitRWqnnQBCFMyhuNRHujjSaGau = P_0;
			YcJWQcvBczXvHGAzrcxUGuHePFZtA = new YuqGSycdazpjQDmHVuiUuFfOMQsAA();
			qqeuWXaELsSbdNOWtBeApGJuuLuE = new YuqGSycdazpjQDmHVuiUuFfOMQsAA();
		}

		public void IeLzKjjozATUPllpQncILOqnarRJA(double P_0)
		{
			JfySfjeInkhadImQyqXydIHGUVlEA = P_0;
			qqeuWXaELsSbdNOWtBeApGJuuLuE.gVGRUQcMighyPhWaDIkmCJvFGyBw(LsitRWqnnQBCFMyhuNRHujjSaGau.gxBsFsxYeUvctokfGCURaGsbUyutA() - YcJWQcvBczXvHGAzrcxUGuHePFZtA.gxBsFsxYeUvctokfGCURaGsbUyutA());
			qqeuWXaELsSbdNOWtBeApGJuuLuE.hqCnngQbBRFrZhkjkllRjfLAbgfUA(LsitRWqnnQBCFMyhuNRHujjSaGau.EAvyVrLlffIGBCwCKlgkROkiFcxXA() - YcJWQcvBczXvHGAzrcxUGuHePFZtA.EAvyVrLlffIGBCwCKlgkROkiFcxXA());
			qqeuWXaELsSbdNOWtBeApGJuuLuE.uCANnogNTsLSmjmxGLThriOckHRU(LsitRWqnnQBCFMyhuNRHujjSaGau.UrCOMSWhfcnCYPbVZuYqurcFgmyh() - YcJWQcvBczXvHGAzrcxUGuHePFZtA.UrCOMSWhfcnCYPbVZuYqurcFgmyh());
			qqeuWXaELsSbdNOWtBeApGJuuLuE.adUXlANyOrBwgVfYqtXWfEtQBUur(LsitRWqnnQBCFMyhuNRHujjSaGau.EYXvsRfzGMJLtDhYQYigKafuCUZH() - YcJWQcvBczXvHGAzrcxUGuHePFZtA.EYXvsRfzGMJLtDhYQYigKafuCUZH());
			qqeuWXaELsSbdNOWtBeApGJuuLuE.sRtpCnhbIbGVPcnsuVCBVBNPjRmO(LsitRWqnnQBCFMyhuNRHujjSaGau.dihzeHqQKJKeUpfhRFhZViySmzgu() - YcJWQcvBczXvHGAzrcxUGuHePFZtA.dihzeHqQKJKeUpfhRFhZViySmzgu());
			qqeuWXaELsSbdNOWtBeApGJuuLuE.KEwbFZlzXieGfqIBzIjRhIlAgvMf(LsitRWqnnQBCFMyhuNRHujjSaGau.YNpRVxrnJEqVFeuFMCiSzRKeusaD() - YcJWQcvBczXvHGAzrcxUGuHePFZtA.YNpRVxrnJEqVFeuFMCiSzRKeusaD());
			for (int i = 0; i < LsitRWqnnQBCFMyhuNRHujjSaGau.iaXZoZvIFXjytzMBbbmkzbOKNxEO().Length; i++)
			{
				qqeuWXaELsSbdNOWtBeApGJuuLuE.iaXZoZvIFXjytzMBbbmkzbOKNxEO()[i] = LsitRWqnnQBCFMyhuNRHujjSaGau.iaXZoZvIFXjytzMBbbmkzbOKNxEO()[i] - YcJWQcvBczXvHGAzrcxUGuHePFZtA.iaXZoZvIFXjytzMBbbmkzbOKNxEO()[i];
			}
			for (int j = 0; j < LsitRWqnnQBCFMyhuNRHujjSaGau.VIFemHRsxjGJBymMifWdFGEZfKMi().Length; j++)
			{
				qqeuWXaELsSbdNOWtBeApGJuuLuE.VIFemHRsxjGJBymMifWdFGEZfKMi()[j] = LsitRWqnnQBCFMyhuNRHujjSaGau.VIFemHRsxjGJBymMifWdFGEZfKMi()[j] - YcJWQcvBczXvHGAzrcxUGuHePFZtA.VIFemHRsxjGJBymMifWdFGEZfKMi()[j];
			}
			for (int k = 0; k < LsitRWqnnQBCFMyhuNRHujjSaGau.qErgkiWlApmmOQtkdLMfhzipsdiC().Length; k++)
			{
				qqeuWXaELsSbdNOWtBeApGJuuLuE.qErgkiWlApmmOQtkdLMfhzipsdiC()[k] = LsitRWqnnQBCFMyhuNRHujjSaGau.qErgkiWlApmmOQtkdLMfhzipsdiC()[k] != YcJWQcvBczXvHGAzrcxUGuHePFZtA.qErgkiWlApmmOQtkdLMfhzipsdiC()[k];
			}
			qqeuWXaELsSbdNOWtBeApGJuuLuE.bxXMIOARUxfKHqGuVXYMiyPlQJtr(LsitRWqnnQBCFMyhuNRHujjSaGau.ECAgwQPifQAHnJYjEsedHOvPkEypA() - YcJWQcvBczXvHGAzrcxUGuHePFZtA.ECAgwQPifQAHnJYjEsedHOvPkEypA());
			qqeuWXaELsSbdNOWtBeApGJuuLuE.noNbptBMdJCNTewrApbCqnnHpBit(LsitRWqnnQBCFMyhuNRHujjSaGau.orgIJYsAcoxhqsqULGfAuYvGtJvl() - YcJWQcvBczXvHGAzrcxUGuHePFZtA.orgIJYsAcoxhqsqULGfAuYvGtJvl());
			qqeuWXaELsSbdNOWtBeApGJuuLuE.JVGlJlJGLhLReeNFKyziJBNhDNweA(LsitRWqnnQBCFMyhuNRHujjSaGau.osrqxkLCfXBabdzyrpcxbZMnixYLA() - YcJWQcvBczXvHGAzrcxUGuHePFZtA.osrqxkLCfXBabdzyrpcxbZMnixYLA());
			qqeuWXaELsSbdNOWtBeApGJuuLuE.LZHDTBGTGJBvHpxjtLuaMeLwoBYBb(LsitRWqnnQBCFMyhuNRHujjSaGau.mKONMghyjMppaqTTskdRSjjSoaDx() - YcJWQcvBczXvHGAzrcxUGuHePFZtA.mKONMghyjMppaqTTskdRSjjSoaDx());
			qqeuWXaELsSbdNOWtBeApGJuuLuE.dApOlPteWLAjRuSBVQUEPkSRRHZy(LsitRWqnnQBCFMyhuNRHujjSaGau.BLZHXdOiVSFYbXMOZfisIwjLONyj() - YcJWQcvBczXvHGAzrcxUGuHePFZtA.BLZHXdOiVSFYbXMOZfisIwjLONyj());
			qqeuWXaELsSbdNOWtBeApGJuuLuE.bFUAAAkutuMRXXDeMKeooBfXcricb(LsitRWqnnQBCFMyhuNRHujjSaGau.sXsmbWsHPnxVtZRQxNHJjlyLkYwi() - YcJWQcvBczXvHGAzrcxUGuHePFZtA.sXsmbWsHPnxVtZRQxNHJjlyLkYwi());
			for (int l = 0; l < LsitRWqnnQBCFMyhuNRHujjSaGau.zwucKPtMFblGsSMOUVQHCHaeOKSl().Length; l++)
			{
				qqeuWXaELsSbdNOWtBeApGJuuLuE.zwucKPtMFblGsSMOUVQHCHaeOKSl()[l] = LsitRWqnnQBCFMyhuNRHujjSaGau.zwucKPtMFblGsSMOUVQHCHaeOKSl()[l] - YcJWQcvBczXvHGAzrcxUGuHePFZtA.zwucKPtMFblGsSMOUVQHCHaeOKSl()[l];
			}
			qqeuWXaELsSbdNOWtBeApGJuuLuE.jJNcvzBHUSebijLXdZQVXmXTLvlTA(LsitRWqnnQBCFMyhuNRHujjSaGau.hMMoBUXlIebxEIplMkDwVItzdUcR() - YcJWQcvBczXvHGAzrcxUGuHePFZtA.hMMoBUXlIebxEIplMkDwVItzdUcR());
			qqeuWXaELsSbdNOWtBeApGJuuLuE.CLDaKpEuhnSEdGqAPGGKdUMtCsFt(LsitRWqnnQBCFMyhuNRHujjSaGau.cAHnZJbuoCjivqDWOTUdcgHJOmsF() - YcJWQcvBczXvHGAzrcxUGuHePFZtA.cAHnZJbuoCjivqDWOTUdcgHJOmsF());
			qqeuWXaELsSbdNOWtBeApGJuuLuE.CVCqlbfrLcROvwocrFPiyKpPDnPH(LsitRWqnnQBCFMyhuNRHujjSaGau.yoXwtLbsxtTPRbovfpwcMyswBhPA() - YcJWQcvBczXvHGAzrcxUGuHePFZtA.yoXwtLbsxtTPRbovfpwcMyswBhPA());
			qqeuWXaELsSbdNOWtBeApGJuuLuE.JWktXkzDOKqOVAFemWirUecheDWDA(LsitRWqnnQBCFMyhuNRHujjSaGau.ZFjNvEnNIzOJQjpaKoHqVlcSYgXp() - YcJWQcvBczXvHGAzrcxUGuHePFZtA.ZFjNvEnNIzOJQjpaKoHqVlcSYgXp());
			qqeuWXaELsSbdNOWtBeApGJuuLuE.bmwDTUcZdzhHqRrAUsGaHGVyNffEA(LsitRWqnnQBCFMyhuNRHujjSaGau.YZkWevoQyAqypxmIuVdetThqUMfL() - YcJWQcvBczXvHGAzrcxUGuHePFZtA.YZkWevoQyAqypxmIuVdetThqUMfL());
			qqeuWXaELsSbdNOWtBeApGJuuLuE.frxLzrUxjgFvGEIGQQBFdfgUNuVW(LsitRWqnnQBCFMyhuNRHujjSaGau.oPHkHhlNMhhZmGxWQvmXHZUuMVnbA() - YcJWQcvBczXvHGAzrcxUGuHePFZtA.oPHkHhlNMhhZmGxWQvmXHZUuMVnbA());
			for (int m = 0; m < LsitRWqnnQBCFMyhuNRHujjSaGau.KAjHmViwsLxsNRKHOkAHHFdFmRcFA().Length; m++)
			{
				qqeuWXaELsSbdNOWtBeApGJuuLuE.KAjHmViwsLxsNRKHOkAHHFdFmRcFA()[m] = LsitRWqnnQBCFMyhuNRHujjSaGau.KAjHmViwsLxsNRKHOkAHHFdFmRcFA()[m] - YcJWQcvBczXvHGAzrcxUGuHePFZtA.KAjHmViwsLxsNRKHOkAHHFdFmRcFA()[m];
			}
			qqeuWXaELsSbdNOWtBeApGJuuLuE.jqPZwrXKWDMJKWLcxVCcsYOJsIb(LsitRWqnnQBCFMyhuNRHujjSaGau.BPbUNfqSweRpKTKVTYsIHPUPaCzFA() - YcJWQcvBczXvHGAzrcxUGuHePFZtA.BPbUNfqSweRpKTKVTYsIHPUPaCzFA());
			qqeuWXaELsSbdNOWtBeApGJuuLuE.TDrIZzkzrWVdnvgXJdHyhZCUDuIb(LsitRWqnnQBCFMyhuNRHujjSaGau.dDRWBgMSyKkAHmwkNMseVebyutgT() - YcJWQcvBczXvHGAzrcxUGuHePFZtA.dDRWBgMSyKkAHmwkNMseVebyutgT());
			qqeuWXaELsSbdNOWtBeApGJuuLuE.sJbNswVnImaRUKFOMWJLpisGtnSlA(LsitRWqnnQBCFMyhuNRHujjSaGau.eSydsUkDDXBIwUKihnwRcVSFZTlZB() - YcJWQcvBczXvHGAzrcxUGuHePFZtA.eSydsUkDDXBIwUKihnwRcVSFZTlZB());
			qqeuWXaELsSbdNOWtBeApGJuuLuE.xxckuZZTVdSiEOIFLwQCgSbUbyyH(LsitRWqnnQBCFMyhuNRHujjSaGau.mNsyLJeDNbvJAwAigrgyKpIHslpI() - YcJWQcvBczXvHGAzrcxUGuHePFZtA.mNsyLJeDNbvJAwAigrgyKpIHslpI());
			qqeuWXaELsSbdNOWtBeApGJuuLuE.HRFztwnJJIQvyjVXdeyLvqftbEwO(LsitRWqnnQBCFMyhuNRHujjSaGau.dmuCofuxFJhCBfVvDINZstogxQNN() - YcJWQcvBczXvHGAzrcxUGuHePFZtA.dmuCofuxFJhCBfVvDINZstogxQNN());
			qqeuWXaELsSbdNOWtBeApGJuuLuE.iZszwVbXcdZXbKOSrNTcnHZRrhzH(LsitRWqnnQBCFMyhuNRHujjSaGau.ouznYnQQrmmrsleoCCtNmQovpPjV() - YcJWQcvBczXvHGAzrcxUGuHePFZtA.ouznYnQQrmmrsleoCCtNmQovpPjV());
			for (int n = 0; n < LsitRWqnnQBCFMyhuNRHujjSaGau.htHdZJmgLWQTrbBlVANIvPPugVIy().Length; n++)
			{
				qqeuWXaELsSbdNOWtBeApGJuuLuE.htHdZJmgLWQTrbBlVANIvPPugVIy()[n] = LsitRWqnnQBCFMyhuNRHujjSaGau.htHdZJmgLWQTrbBlVANIvPPugVIy()[n] - YcJWQcvBczXvHGAzrcxUGuHePFZtA.htHdZJmgLWQTrbBlVANIvPPugVIy()[n];
			}
			nifAMAnzFAFfOKQrWASgGzHoYgjA = rbdXOGCxqGSqVAotsrCXKyFtxEmB();
			if (nifAMAnzFAFfOKQrWASgGzHoYgjA)
			{
				zDpIbfhFiUrlBXAPBabFhUaZnSoFb = P_0;
				YcJWQcvBczXvHGAzrcxUGuHePFZtA.wjqAZxGnVLDwllgZNpfbIFjYBzHv(LsitRWqnnQBCFMyhuNRHujjSaGau);
			}
		}

		public void vtakmScSNYeOjoEfnhChsrnXHOGAA(ioIqXdyJRxxIaGIrjFdVGZUtgIqg P_0)
		{
			JfySfjeInkhadImQyqXydIHGUVlEA = P_0.JfySfjeInkhadImQyqXydIHGUVlEA;
			YcJWQcvBczXvHGAzrcxUGuHePFZtA.wjqAZxGnVLDwllgZNpfbIFjYBzHv(P_0.YcJWQcvBczXvHGAzrcxUGuHePFZtA);
			qqeuWXaELsSbdNOWtBeApGJuuLuE.wjqAZxGnVLDwllgZNpfbIFjYBzHv(P_0.qqeuWXaELsSbdNOWtBeApGJuuLuE);
		}

		private bool rbdXOGCxqGSqVAotsrCXKyFtxEmB()
		{
			if (qqeuWXaELsSbdNOWtBeApGJuuLuE.EAvyVrLlffIGBCwCKlgkROkiFcxXA() != 0)
			{
				return true;
			}
			if (qqeuWXaELsSbdNOWtBeApGJuuLuE.UrCOMSWhfcnCYPbVZuYqurcFgmyh() != 0)
			{
				return true;
			}
			if (qqeuWXaELsSbdNOWtBeApGJuuLuE.EYXvsRfzGMJLtDhYQYigKafuCUZH() != 0)
			{
				return true;
			}
			if (qqeuWXaELsSbdNOWtBeApGJuuLuE.dihzeHqQKJKeUpfhRFhZViySmzgu() != 0)
			{
				return true;
			}
			if (qqeuWXaELsSbdNOWtBeApGJuuLuE.YNpRVxrnJEqVFeuFMCiSzRKeusaD() != 0)
			{
				return true;
			}
			for (int i = 0; i < LsitRWqnnQBCFMyhuNRHujjSaGau.iaXZoZvIFXjytzMBbbmkzbOKNxEO().Length; i++)
			{
				if (qqeuWXaELsSbdNOWtBeApGJuuLuE.iaXZoZvIFXjytzMBbbmkzbOKNxEO()[i] != 0)
				{
					return true;
				}
			}
			for (int j = 0; j < LsitRWqnnQBCFMyhuNRHujjSaGau.VIFemHRsxjGJBymMifWdFGEZfKMi().Length; j++)
			{
				if (qqeuWXaELsSbdNOWtBeApGJuuLuE.VIFemHRsxjGJBymMifWdFGEZfKMi()[j] != 0)
				{
					return true;
				}
			}
			for (int k = 0; k < LsitRWqnnQBCFMyhuNRHujjSaGau.qErgkiWlApmmOQtkdLMfhzipsdiC().Length; k++)
			{
				if (qqeuWXaELsSbdNOWtBeApGJuuLuE.qErgkiWlApmmOQtkdLMfhzipsdiC()[k])
				{
					return true;
				}
			}
			if (qqeuWXaELsSbdNOWtBeApGJuuLuE.ECAgwQPifQAHnJYjEsedHOvPkEypA() != 0)
			{
				return true;
			}
			if (qqeuWXaELsSbdNOWtBeApGJuuLuE.orgIJYsAcoxhqsqULGfAuYvGtJvl() != 0)
			{
				return true;
			}
			if (qqeuWXaELsSbdNOWtBeApGJuuLuE.osrqxkLCfXBabdzyrpcxbZMnixYLA() != 0)
			{
				return true;
			}
			if (qqeuWXaELsSbdNOWtBeApGJuuLuE.mKONMghyjMppaqTTskdRSjjSoaDx() != 0)
			{
				return true;
			}
			if (qqeuWXaELsSbdNOWtBeApGJuuLuE.BLZHXdOiVSFYbXMOZfisIwjLONyj() != 0)
			{
				return true;
			}
			if (qqeuWXaELsSbdNOWtBeApGJuuLuE.sXsmbWsHPnxVtZRQxNHJjlyLkYwi() != 0)
			{
				return true;
			}
			for (int l = 0; l < LsitRWqnnQBCFMyhuNRHujjSaGau.zwucKPtMFblGsSMOUVQHCHaeOKSl().Length; l++)
			{
				if (qqeuWXaELsSbdNOWtBeApGJuuLuE.zwucKPtMFblGsSMOUVQHCHaeOKSl()[l] != 0)
				{
					return true;
				}
			}
			if (qqeuWXaELsSbdNOWtBeApGJuuLuE.hMMoBUXlIebxEIplMkDwVItzdUcR() != 0)
			{
				return true;
			}
			if (qqeuWXaELsSbdNOWtBeApGJuuLuE.cAHnZJbuoCjivqDWOTUdcgHJOmsF() != 0)
			{
				return true;
			}
			if (qqeuWXaELsSbdNOWtBeApGJuuLuE.yoXwtLbsxtTPRbovfpwcMyswBhPA() != 0)
			{
				return true;
			}
			if (qqeuWXaELsSbdNOWtBeApGJuuLuE.ZFjNvEnNIzOJQjpaKoHqVlcSYgXp() != 0)
			{
				return true;
			}
			if (qqeuWXaELsSbdNOWtBeApGJuuLuE.YZkWevoQyAqypxmIuVdetThqUMfL() != 0)
			{
				return true;
			}
			if (qqeuWXaELsSbdNOWtBeApGJuuLuE.oPHkHhlNMhhZmGxWQvmXHZUuMVnbA() != 0)
			{
				return true;
			}
			for (int m = 0; m < LsitRWqnnQBCFMyhuNRHujjSaGau.KAjHmViwsLxsNRKHOkAHHFdFmRcFA().Length; m++)
			{
				qqeuWXaELsSbdNOWtBeApGJuuLuE.KAjHmViwsLxsNRKHOkAHHFdFmRcFA()[m] = LsitRWqnnQBCFMyhuNRHujjSaGau.KAjHmViwsLxsNRKHOkAHHFdFmRcFA()[m] - YcJWQcvBczXvHGAzrcxUGuHePFZtA.KAjHmViwsLxsNRKHOkAHHFdFmRcFA()[m];
			}
			if (qqeuWXaELsSbdNOWtBeApGJuuLuE.BPbUNfqSweRpKTKVTYsIHPUPaCzFA() != 0)
			{
				return true;
			}
			if (qqeuWXaELsSbdNOWtBeApGJuuLuE.dDRWBgMSyKkAHmwkNMseVebyutgT() != 0)
			{
				return true;
			}
			if (qqeuWXaELsSbdNOWtBeApGJuuLuE.eSydsUkDDXBIwUKihnwRcVSFZTlZB() != 0)
			{
				return true;
			}
			if (qqeuWXaELsSbdNOWtBeApGJuuLuE.mNsyLJeDNbvJAwAigrgyKpIHslpI() != 0)
			{
				return true;
			}
			if (qqeuWXaELsSbdNOWtBeApGJuuLuE.dmuCofuxFJhCBfVvDINZstogxQNN() != 0)
			{
				return true;
			}
			if (qqeuWXaELsSbdNOWtBeApGJuuLuE.ouznYnQQrmmrsleoCCtNmQovpPjV() != 0)
			{
				return true;
			}
			for (int n = 0; n < LsitRWqnnQBCFMyhuNRHujjSaGau.htHdZJmgLWQTrbBlVANIvPPugVIy().Length; n++)
			{
				if (qqeuWXaELsSbdNOWtBeApGJuuLuE.htHdZJmgLWQTrbBlVANIvPPugVIy()[n] != 0)
				{
					return true;
				}
			}
			return false;
		}
	}

	private class oddkCxrFVeCGPDjioghPlbFIwcNgA
	{
		public enum MhkPqBZJgWcoJTchZBUKEFShOeFy
		{
			Exact = 0,
			Approximate = 1
		}

		public class qBLziUtnPMSCWLoQRPgjuMWokgzn
		{
			public int GsftiOrcPMfUIdWgBGQtOEkrDgpFb;

			public Guid WJhcAhUQSJhwzcyvghBNglhBYKNx;

			public Guid UsFFzmIgYujLtQTEnuCVaZxSQGSy;

			public int LJmujwnzMgCgcVWpEOgeafJpDPJq;

			public int QsmzAxkBYPDPPDYUdEjZnWIJfXgKA;

			public int huMtXurjOTRslWFlOAvYvFcDvtWM;

			public int CbRmhrFhqRKUmbzyVKMlOqLLDEjD;

			public bool FCimjMEhhewArDdCSpnreAPcMpJp(WivuQsnnBaGilaFGOHquRRJlDRWW P_0, MhkPqBZJgWcoJTchZBUKEFShOeFy P_1)
			{
				if (P_0.get_rewiredId() == GsftiOrcPMfUIdWgBGQtOEkrDgpFb)
				{
					return true;
				}
				if (QsmzAxkBYPDPPDYUdEjZnWIJfXgKA != P_0.JCjrxAHJuJFYVfsnTfwfNbjiyMe)
				{
					return false;
				}
				if (huMtXurjOTRslWFlOAvYvFcDvtWM != P_0.RUkFvDetMFtMNabRhsHrynrUFKuw)
				{
					return false;
				}
				if (CbRmhrFhqRKUmbzyVKMlOqLLDEjD != P_0.YVLiGPIPRedKYahelzxhHOgiKQIQ)
				{
					return false;
				}
				return P_1 switch
				{
					MhkPqBZJgWcoJTchZBUKEFShOeFy.Exact => WJhcAhUQSJhwzcyvghBNglhBYKNx == P_0.get_instanceGuid(), 
					MhkPqBZJgWcoJTchZBUKEFShOeFy.Approximate => UsFFzmIgYujLtQTEnuCVaZxSQGSy == P_0.RdfZwQEqNImGfQAiGYeZstvjrJOf, 
					_ => throw new NotImplementedException(), 
				};
			}

			public virtual string EgaeIfqkbYvUqRYcdBnwZqQAaVKD()
			{
				string text = "" + "rewiredId = " + GsftiOrcPMfUIdWgBGQtOEkrDgpFb + "\n";
				Guid wJhcAhUQSJhwzcyvghBNglhBYKNx = WJhcAhUQSJhwzcyvghBNglhBYKNx;
				string text2 = text + "instanceGuid = " + wJhcAhUQSJhwzcyvghBNglhBYKNx.ToString() + "\n";
				wJhcAhUQSJhwzcyvghBNglhBYKNx = UsFFzmIgYujLtQTEnuCVaZxSQGSy;
				return string.Concat(string.Concat(string.Concat(string.Concat(text2 + "typeIdentifierGuid = " + wJhcAhUQSJhwzcyvghBNglhBYKNx.ToString() + "\n", "lastInputManagerId = ", LJmujwnzMgCgcVWpEOgeafJpDPJq.ToString(), "\n"), "hardwareAxisCount = ", QsmzAxkBYPDPPDYUdEjZnWIJfXgKA.ToString(), "\n"), "hardwareButtonCount = ", huMtXurjOTRslWFlOAvYvFcDvtWM.ToString(), "\n"), "hardwareHatCount = ", CbRmhrFhqRKUmbzyVKMlOqLLDEjD.ToString(), "\n");
			}
		}

		private sealed class WcCfwIfobqwXSEibgOVzJZsqcBPOA : IEnumerable<qBLziUtnPMSCWLoQRPgjuMWokgzn>, IEnumerable, IEnumerator<qBLziUtnPMSCWLoQRPgjuMWokgzn>, IEnumerator, IDisposable
		{
			private int WkSxkwQtPRaFjmEuGUKWGfOjtkQy;

			private qBLziUtnPMSCWLoQRPgjuMWokgzn OQXimraVDpJtoZUzjvlYAfLUqgVB;

			private int JYQgRJvsRwbQhhMRRFCODciQxZuX;

			public oddkCxrFVeCGPDjioghPlbFIwcNgA faqtmfmhxCxyJQInWEnLKXbIHRRX;

			private WivuQsnnBaGilaFGOHquRRJlDRWW ZmyOJuNbzyahCJIqmmUfikimCqXf;

			public WivuQsnnBaGilaFGOHquRRJlDRWW crtHLXsHWifWcniigHSFvUjazFpd;

			private MhkPqBZJgWcoJTchZBUKEFShOeFy OZOaGJZeDGIQwdBUQXtBqheQqZLPA;

			public MhkPqBZJgWcoJTchZBUKEFShOeFy NGxJxmwVvNWHoMyQCTiLoPxsRVHF;

			private int JaYdZuAlYwrrGRDKoAYzzBkxfBMq;

			private int msMvEclNzrzRuWhpqYQtsAyvbNnAA;

			qBLziUtnPMSCWLoQRPgjuMWokgzn IEnumerator<qBLziUtnPMSCWLoQRPgjuMWokgzn>.Current
			{
				[DebuggerHidden]
				get
				{
					return System_002ECollections_002EGeneric_002EIEnumerator_003CRewired_002EPlatforms_002EWindows_002EDirectInputManager_002EJoystickRecords_002ERecord_003E_002Eget_Current();
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return OQXimraVDpJtoZUzjvlYAfLUqgVB;
				}
			}

			[DebuggerHidden]
			public WcCfwIfobqwXSEibgOVzJZsqcBPOA(int P_0)
			{
				WkSxkwQtPRaFjmEuGUKWGfOjtkQy = P_0;
				JYQgRJvsRwbQhhMRRFCODciQxZuX = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int wkSxkwQtPRaFjmEuGUKWGfOjtkQy = WkSxkwQtPRaFjmEuGUKWGfOjtkQy;
				oddkCxrFVeCGPDjioghPlbFIwcNgA oddkCxrFVeCGPDjioghPlbFIwcNgA2 = faqtmfmhxCxyJQInWEnLKXbIHRRX;
				if (wkSxkwQtPRaFjmEuGUKWGfOjtkQy != 0)
				{
					if (wkSxkwQtPRaFjmEuGUKWGfOjtkQy != 1)
					{
						return false;
					}
					WkSxkwQtPRaFjmEuGUKWGfOjtkQy = -1;
					goto IL_0083;
				}
				WkSxkwQtPRaFjmEuGUKWGfOjtkQy = -1;
				JaYdZuAlYwrrGRDKoAYzzBkxfBMq = oddkCxrFVeCGPDjioghPlbFIwcNgA2.DeGIUDbZdfwQKotthccpetvJHehdc.Count;
				msMvEclNzrzRuWhpqYQtsAyvbNnAA = 0;
				goto IL_0093;
				IL_0083:
				msMvEclNzrzRuWhpqYQtsAyvbNnAA++;
				goto IL_0093;
				IL_0093:
				if (msMvEclNzrzRuWhpqYQtsAyvbNnAA < JaYdZuAlYwrrGRDKoAYzzBkxfBMq)
				{
					if (oddkCxrFVeCGPDjioghPlbFIwcNgA2.DeGIUDbZdfwQKotthccpetvJHehdc[msMvEclNzrzRuWhpqYQtsAyvbNnAA].FCimjMEhhewArDdCSpnreAPcMpJp(ZmyOJuNbzyahCJIqmmUfikimCqXf, OZOaGJZeDGIQwdBUQXtBqheQqZLPA))
					{
						OQXimraVDpJtoZUzjvlYAfLUqgVB = oddkCxrFVeCGPDjioghPlbFIwcNgA2.DeGIUDbZdfwQKotthccpetvJHehdc[msMvEclNzrzRuWhpqYQtsAyvbNnAA];
						WkSxkwQtPRaFjmEuGUKWGfOjtkQy = 1;
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
			private qBLziUtnPMSCWLoQRPgjuMWokgzn System_002ECollections_002EGeneric_002EIEnumerator_003CRewired_002EPlatforms_002EWindows_002EDirectInputManager_002EJoystickRecords_002ERecord_003E_002Eget_Current()
			{
				return OQXimraVDpJtoZUzjvlYAfLUqgVB;
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
				throw new NotSupportedException();
			}

			[DebuggerHidden]
			IEnumerator<qBLziUtnPMSCWLoQRPgjuMWokgzn> IEnumerable<qBLziUtnPMSCWLoQRPgjuMWokgzn>.GetEnumerator()
			{
				WcCfwIfobqwXSEibgOVzJZsqcBPOA wcCfwIfobqwXSEibgOVzJZsqcBPOA;
				if (WkSxkwQtPRaFjmEuGUKWGfOjtkQy == -2 && JYQgRJvsRwbQhhMRRFCODciQxZuX == Environment.CurrentManagedThreadId)
				{
					WkSxkwQtPRaFjmEuGUKWGfOjtkQy = 0;
					wcCfwIfobqwXSEibgOVzJZsqcBPOA = this;
				}
				else
				{
					wcCfwIfobqwXSEibgOVzJZsqcBPOA = new WcCfwIfobqwXSEibgOVzJZsqcBPOA(0);
					wcCfwIfobqwXSEibgOVzJZsqcBPOA.faqtmfmhxCxyJQInWEnLKXbIHRRX = faqtmfmhxCxyJQInWEnLKXbIHRRX;
				}
				wcCfwIfobqwXSEibgOVzJZsqcBPOA.ZmyOJuNbzyahCJIqmmUfikimCqXf = crtHLXsHWifWcniigHSFvUjazFpd;
				wcCfwIfobqwXSEibgOVzJZsqcBPOA.OZOaGJZeDGIQwdBUQXtBqheQqZLPA = NGxJxmwVvNWHoMyQCTiLoPxsRVHF;
				return wcCfwIfobqwXSEibgOVzJZsqcBPOA;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<qBLziUtnPMSCWLoQRPgjuMWokgzn>)this).GetEnumerator();
			}
		}

		private List<qBLziUtnPMSCWLoQRPgjuMWokgzn> DeGIUDbZdfwQKotthccpetvJHehdc;

		public oddkCxrFVeCGPDjioghPlbFIwcNgA()
		{
			DeGIUDbZdfwQKotthccpetvJHehdc = new List<qBLziUtnPMSCWLoQRPgjuMWokgzn>();
		}

		public void OBUgBTBilDpiwabrBfVzNsuDVRMPB(WivuQsnnBaGilaFGOHquRRJlDRWW P_0)
		{
			if (P_0 == null)
			{
				return;
			}
			int count = DeGIUDbZdfwQKotthccpetvJHehdc.Count;
			for (int i = 0; i < count; i++)
			{
				if (DeGIUDbZdfwQKotthccpetvJHehdc[i].FCimjMEhhewArDdCSpnreAPcMpJp(P_0, MhkPqBZJgWcoJTchZBUKEFShOeFy.Exact))
				{
					DeGIUDbZdfwQKotthccpetvJHehdc[i].GsftiOrcPMfUIdWgBGQtOEkrDgpFb = P_0.get_rewiredId();
					DeGIUDbZdfwQKotthccpetvJHehdc[i].WJhcAhUQSJhwzcyvghBNglhBYKNx = P_0.get_instanceGuid();
					DeGIUDbZdfwQKotthccpetvJHehdc[i].UsFFzmIgYujLtQTEnuCVaZxSQGSy = P_0.RdfZwQEqNImGfQAiGYeZstvjrJOf;
					DeGIUDbZdfwQKotthccpetvJHehdc[i].LJmujwnzMgCgcVWpEOgeafJpDPJq = P_0.get_inputManagerId();
					DeGIUDbZdfwQKotthccpetvJHehdc[i].QsmzAxkBYPDPPDYUdEjZnWIJfXgKA = P_0.JCjrxAHJuJFYVfsnTfwfNbjiyMe;
					DeGIUDbZdfwQKotthccpetvJHehdc[i].huMtXurjOTRslWFlOAvYvFcDvtWM = P_0.RUkFvDetMFtMNabRhsHrynrUFKuw;
					DeGIUDbZdfwQKotthccpetvJHehdc[i].CbRmhrFhqRKUmbzyVKMlOqLLDEjD = P_0.YVLiGPIPRedKYahelzxhHOgiKQIQ;
					EhaGSzBdTikZdNaHlleCfTBUTEXZA(P_0.get_rewiredId(), P_0.get_instanceGuid(), i);
					return;
				}
			}
			DeGIUDbZdfwQKotthccpetvJHehdc.Add(new qBLziUtnPMSCWLoQRPgjuMWokgzn
			{
				GsftiOrcPMfUIdWgBGQtOEkrDgpFb = P_0.get_rewiredId(),
				WJhcAhUQSJhwzcyvghBNglhBYKNx = P_0.get_instanceGuid(),
				UsFFzmIgYujLtQTEnuCVaZxSQGSy = P_0.RdfZwQEqNImGfQAiGYeZstvjrJOf,
				LJmujwnzMgCgcVWpEOgeafJpDPJq = P_0.get_inputManagerId(),
				QsmzAxkBYPDPPDYUdEjZnWIJfXgKA = P_0.JCjrxAHJuJFYVfsnTfwfNbjiyMe,
				huMtXurjOTRslWFlOAvYvFcDvtWM = P_0.RUkFvDetMFtMNabRhsHrynrUFKuw,
				CbRmhrFhqRKUmbzyVKMlOqLLDEjD = P_0.YVLiGPIPRedKYahelzxhHOgiKQIQ
			});
			EhaGSzBdTikZdNaHlleCfTBUTEXZA(P_0.get_rewiredId(), P_0.get_instanceGuid(), DeGIUDbZdfwQKotthccpetvJHehdc.Count - 1);
		}

		public bool RZuqoWFHMvwpyRYtzoPAcjeldKnY(WivuQsnnBaGilaFGOHquRRJlDRWW P_0, MhkPqBZJgWcoJTchZBUKEFShOeFy P_1)
		{
			int count = DeGIUDbZdfwQKotthccpetvJHehdc.Count;
			for (int i = 0; i < count; i++)
			{
				if (DeGIUDbZdfwQKotthccpetvJHehdc[i].FCimjMEhhewArDdCSpnreAPcMpJp(P_0, P_1))
				{
					return true;
				}
			}
			return false;
		}

		[IteratorStateMachine(typeof(WcCfwIfobqwXSEibgOVzJZsqcBPOA))]
		public IEnumerable<qBLziUtnPMSCWLoQRPgjuMWokgzn> grgEMEnBsQOuAtSZKVELdwWxgvkT(WivuQsnnBaGilaFGOHquRRJlDRWW P_0, MhkPqBZJgWcoJTchZBUKEFShOeFy P_1)
		{
			return new WcCfwIfobqwXSEibgOVzJZsqcBPOA(-2)
			{
				faqtmfmhxCxyJQInWEnLKXbIHRRX = this,
				crtHLXsHWifWcniigHSFvUjazFpd = P_0,
				NGxJxmwVvNWHoMyQCTiLoPxsRVHF = P_1
			};
		}

		private void EhaGSzBdTikZdNaHlleCfTBUTEXZA(int P_0, Guid P_1, int P_2)
		{
			for (int num = DeGIUDbZdfwQKotthccpetvJHehdc.Count - 1; num >= 0; num--)
			{
				if (num != P_2 && (DeGIUDbZdfwQKotthccpetvJHehdc[num].GsftiOrcPMfUIdWgBGQtOEkrDgpFb == P_0 || DeGIUDbZdfwQKotthccpetvJHehdc[num].WJhcAhUQSJhwzcyvghBNglhBYKNx == P_1))
				{
					DeGIUDbZdfwQKotthccpetvJHehdc.RemoveAt(num);
				}
			}
		}

		public virtual string cCFOJHZbQdOLUCqtJBlmQmFDqefA()
		{
			string text = "";
			text = text + "Joystick records: " + DeGIUDbZdfwQKotthccpetvJHehdc.Count + "\n";
			for (int i = 0; i < DeGIUDbZdfwQKotthccpetvJHehdc.Count; i++)
			{
				text = text + "Record " + i + ":\n";
				text = text + DeGIUDbZdfwQKotthccpetvJHehdc[i].ToString() + "\n\n";
			}
			return text;
		}
	}

	private class wOtjejUGdxefShXSCASSpSvjFcbK
	{
		public WivuQsnnBaGilaFGOHquRRJlDRWW mJVfRrfUfzKEVCosIqTWXLklfFvxA;

		public cQBxMAHukbVUZQupSRBOiSlaiust iQBiwEWyVUgyRbsOQUJuzhuvSJbS;

		public bool fVUPfIBhjQZFUGXetgitfJDxwZqN => pSTFXxkcFEcUcwOQVOUuCNUbpABe();

		public bool pSTFXxkcFEcUcwOQVOUuCNUbpABe()
		{
			if (mJVfRrfUfzKEVCosIqTWXLklfFvxA != null)
			{
				return iQBiwEWyVUgyRbsOQUJuzhuvSJbS != null;
			}
			return false;
		}

		public wOtjejUGdxefShXSCASSpSvjFcbK(WivuQsnnBaGilaFGOHquRRJlDRWW P_0, cQBxMAHukbVUZQupSRBOiSlaiust P_1)
		{
			mJVfRrfUfzKEVCosIqTWXLklfFvxA = P_0;
			iQBiwEWyVUgyRbsOQUJuzhuvSJbS = P_1;
		}

		public static List<cQBxMAHukbVUZQupSRBOiSlaiust> mHmeEhkLVGkDDvSBHHtjplipCoaf(List<wOtjejUGdxefShXSCASSpSvjFcbK> P_0)
		{
			if (P_0 == null)
			{
				return new List<cQBxMAHukbVUZQupSRBOiSlaiust>();
			}
			List<cQBxMAHukbVUZQupSRBOiSlaiust> list = new List<cQBxMAHukbVUZQupSRBOiSlaiust>();
			for (int i = 0; i < P_0.Count; i++)
			{
				if (P_0[i].pSTFXxkcFEcUcwOQVOUuCNUbpABe())
				{
					list.Add(P_0[i].iQBiwEWyVUgyRbsOQUJuzhuvSJbS);
				}
			}
			return list;
		}
	}

	private class xaIhfRajJUmVIflWxWUoNurJZIyC
	{
		public acNIMEkbdUZflpTVBxiqmIgjMDSMA GcmpeFWYJUhkrwAyMgjzbSuqjGSUA;

		public xaIhfRajJUmVIflWxWUoNurJZIyC(acNIMEkbdUZflpTVBxiqmIgjMDSMA P_0)
		{
			GcmpeFWYJUhkrwAyMgjzbSuqjGSUA = P_0;
		}
	}

	private class ZtTETUjJrfKnSFImDFkakFchWgzWb
	{
		private inSocxvHKcZuXfpzClQDwKpOeRyG.EYplVEDfYwsknPzJQOJEStQVlZzU pCXEEfIeeTNDDHujdCcxmPdHbAJSb;

		private inSocxvHKcZuXfpzClQDwKpOeRyG.jtYBDCTEfrsSgiQOZocMsRpCMuDk tEvrImJoibbtsVxYZheXPJKPdibo;

		private NativeBuffer THrBuVlifnhLtNLfvaoFqgVrnUGc;

		private int aOvxJgmfefVfLxTWPhusMHmmFdXg;

		public ZtTETUjJrfKnSFImDFkakFchWgzWb()
		{
			pCXEEfIeeTNDDHujdCcxmPdHbAJSb = new inSocxvHKcZuXfpzClQDwKpOeRyG.EYplVEDfYwsknPzJQOJEStQVlZzU
			{
				EhawlsEwgWsppyoxwXKXqMvajsMO = (uint)Marshal.SizeOf(typeof(inSocxvHKcZuXfpzClQDwKpOeRyG.EYplVEDfYwsknPzJQOJEStQVlZzU)),
				YEeKDTZplqNxEikgfglsyPHWsinp = true,
				OorkOTLIpzCLfIQGzUJdsDLnbTLdb = true,
				MHvOxBEQPvEYnvXLAvQaIOpfihrbA = false,
				WcEopOeCjCxHhNospKYJTKCBIlJb = true,
				PIJalHGQLagcEnCbPvknJXhldTCV = IntPtr.Zero
			};
			tEvrImJoibbtsVxYZheXPJKPdibo = inSocxvHKcZuXfpzClQDwKpOeRyG.jtYBDCTEfrsSgiQOZocMsRpCMuDk.asOIsAYLRZiTNwaSYesZYJVaChecA();
			THrBuVlifnhLtNLfvaoFqgVrnUGc = new NativeBuffer((int)tEvrImJoibbtsVxYZheXPJKPdibo.XtmLNHfjpuBKOnQJBEVBUcriyoef);
			THrBuVlifnhLtNLfvaoFqgVrnUGc.Write(tEvrImJoibbtsVxYZheXPJKPdibo.XtmLNHfjpuBKOnQJBEVBUcriyoef, 0);
		}

		public bool TgEFiwsDTsJBuLhFiaLplpTuGVbq()
		{
			int num = aiagNuOvCZBKHvhClbFjXxbQDPJR();
			if (num == aOvxJgmfefVfLxTWPhusMHmmFdXg)
			{
				return false;
			}
			aOvxJgmfefVfLxTWPhusMHmmFdXg = num;
			return true;
		}

		public void JSRrMFzVbTGXcsyEQRPrqEKlgKpG(int P_0)
		{
			aOvxJgmfefVfLxTWPhusMHmmFdXg = P_0;
		}

		private int aiagNuOvCZBKHvhClbFjXxbQDPJR()
		{
			try
			{
				return jJVMeOSGFiWvYXFSLLMERjkQCZOv.ongelNwPCnzGBBczbBgaQjlpEuZo(ref pCXEEfIeeTNDDHujdCcxmPdHbAJSb, THrBuVlifnhLtNLfvaoFqgVrnUGc);
			}
			catch
			{
				return 0;
			}
		}
	}

	private enum hHFsfajLRZYSFHbHIkRhPCzLqfpc
	{
		Device = 17,
		Mouse = 18,
		Keyboard = 19,
		Joystick = 20,
		Gamepad = 21,
		Driving = 22,
		Flight = 23,
		FirstPerson = 24,
		ControlDevice = 25,
		ScreenPointer = 26,
		Remote = 27,
		Supplemental = 28
	}

	private const KwMHHfNTwEYhGoVEiNBaXUMLlAml WkfYzBUmlolIEHsqIjIuNELOFVdw = KwMHHfNTwEYhGoVEiNBaXUMLlAml.GameControl;

	private const grafWZdmFPBElhoJiCXQcZctJhNX wJJtoILoZlTRbsGsiINMxgMTtjAx = grafWZdmFPBElhoJiCXQcZctJhNX.AttachedOnly;

	private IntPtr wSEfBMeKywOkcIaGVjZDznwELQDuA;

	private hWHYtXHqbQDSYkFuTyFtXjkGnJJx ItDHHJQXHtjpIxxjhZoxOKbLEOzd;

	private List<WivuQsnnBaGilaFGOHquRRJlDRWW> pCQiPopqzCFjkDfcXSWAObCObPTq;

	private int DzjPfPgVPjKjnRHISCNWcQawPdJbA;

	private oddkCxrFVeCGPDjioghPlbFIwcNgA dSQaOTmepbZwCSLSkpIfSXnUbOoT;

	private bool FeImvbMocvyncljJCyNAdVICDpVP;

	private lqpQxMQBnMKtcyVNasPoQMoNTuAx esuNIqwdWpgIfzbQhZICYslonOXV;

	private UpdateLoopSetting ZxycCiFieSgkEhzBUiqhbLKAXKDFA;

	private Action<int, ControllerDataUpdater> PyMGTUmeMOuoyANbnEyHzXENzilp;

	private PlatformInputManager VhmnyZIFCsJvCFQrFeVuJJuUDFsBA;

	private TimerRealTime rqHfHACJTJbSJPlXAdonzOhZzUkEA;

	private global::YmPrvkdvDmQKYqkyPerBWAzuraMJ<bool> fFFnSsqhaRGUQNmIgxlzhDookuLI;

	private ZtTETUjJrfKnSFImDFkakFchWgzWb lLleVwLCyQxzcxsOhxDQtyNOTjfk;

	private int ZpYAgsdUHyRMzoGyPqBzYNDphIHSA;

	private int SWQImlxFcsFxLhKkizXvAuTAEDIk;

	private global::YmPrvkdvDmQKYqkyPerBWAzuraMJ<List<wOtjejUGdxefShXSCASSpSvjFcbK>> oDggpbulHhNjKwksRYiPCvdndDIM;

	private readonly object eIhSCCQLmDsFofRnwxZBJfCPSFkL = new object();

	private Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> CueCjSoiaiESZjYnphnbORMRgpUG;

	private Func<int> bRFMCApQWYhfFNvUFjQPcXfbMnru;

	lqpQxMQBnMKtcyVNasPoQMoNTuAx laAVmpydykZoloUrxIfSCUfKPqfV
	{
		get
		{
			return laAVmpydykZoloUrxIfSCUfKPqfV();
		}
		set
		{
			kyMBajFBsNSFQjYcWHaSOoFWRIgVA(lqpQxMQBnMKtcyVNasPoQMoNTuAx2);
		}
	}

	[CustomObfuscation(rename = false)]
	int PlatformInputManager.deviceCount => get_deviceCount();

	[CustomObfuscation(rename = false)]
	PlatformInputManager PlatformInputManager.primaryInputManager => get_primaryInputManager();

	[CustomObfuscation(rename = false)]
	IInputSource PlatformInputManager.inputSource => get_inputSource();

	[CustomObfuscation(rename = false)]
	InputSource PlatformInputManager.inputSourceType => get_inputSourceType();

	public lqpQxMQBnMKtcyVNasPoQMoNTuAx laAVmpydykZoloUrxIfSCUfKPqfV()
	{
		return esuNIqwdWpgIfzbQhZICYslonOXV;
	}

	public void kyMBajFBsNSFQjYcWHaSOoFWRIgVA(lqpQxMQBnMKtcyVNasPoQMoNTuAx P_0)
	{
		esuNIqwdWpgIfzbQhZICYslonOXV = P_0;
	}

	public CjBwBKlcXyHERByOVbSKItkOzASJ(UpdateLoopSetting P_0, lqpQxMQBnMKtcyVNasPoQMoNTuAx P_1, IntPtr P_2, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> P_3, Func<int> P_4)
	{
		try
		{
			ZxycCiFieSgkEhzBUiqhbLKAXKDFA = P_0;
			esuNIqwdWpgIfzbQhZICYslonOXV = P_1;
			wSEfBMeKywOkcIaGVjZDznwELQDuA = P_2;
			CueCjSoiaiESZjYnphnbORMRgpUG = P_3;
			bRFMCApQWYhfFNvUFjQPcXfbMnru = P_4;
			VhmnyZIFCsJvCFQrFeVuJJuUDFsBA = this;
			ItDHHJQXHtjpIxxjhZoxOKbLEOzd = new hWHYtXHqbQDSYkFuTyFtXjkGnJJx();
			PyMGTUmeMOuoyANbnEyHzXENzilp = UpdateControllerData;
			lLleVwLCyQxzcxsOhxDQtyNOTjfk = new ZtTETUjJrfKnSFImDFkakFchWgzWb();
			fFFnSsqhaRGUQNmIgxlzhDookuLI = new global::YmPrvkdvDmQKYqkyPerBWAzuraMJ<bool>(true, mTKBzqMtPMAJmpeCXluEQzxWlvjX);
			oDggpbulHhNjKwksRYiPCvdndDIM = new global::YmPrvkdvDmQKYqkyPerBWAzuraMJ<List<wOtjejUGdxefShXSCASSpSvjFcbK>>(true, () => zjiuTBlWjvCDrqrLWcpYCUcebzZR());
			hsWEtaJXQDAJfYxlDUbyYKpvbvuFA();
		}
		catch (Exception)
		{
			OnDestroy();
			throw;
		}
	}

	public virtual int get_deviceCount()
	{
		return DzjPfPgVPjKjnRHISCNWcQawPdJbA;
	}

	public virtual PlatformInputManager get_primaryInputManager()
	{
		return VhmnyZIFCsJvCFQrFeVuJJuUDFsBA;
	}

	public virtual IInputSource get_inputSource()
	{
		return new InputSourceWrapper<hWHYtXHqbQDSYkFuTyFtXjkGnJJx>(ItDHHJQXHtjpIxxjhZoxOKbLEOzd);
	}

	public virtual InputSource get_inputSourceType()
	{
		return InputSource.DirectInput;
	}

	[CustomObfuscation(rename = false)]
	public override void Initialize()
	{
		dSQaOTmepbZwCSLSkpIfSXnUbOoT = new oddkCxrFVeCGPDjioghPlbFIwcNgA();
		rqHfHACJTJbSJPlXAdonzOhZzUkEA = new TimerRealTime(1.0);
		rqHfHACJTJbSJPlXAdonzOhZzUkEA.Start();
		FKbRaUOjbqAJbXraMuBbtIoGfUuM();
	}

	[CustomObfuscation(rename = false)]
	public override void Update(UpdateLoopType updateLoop)
	{
		CzNITHeiLatsZYZzPoCVzflJuuQw();
		tdBqbYhGykMTFxIespbdfqVYbsEB();
		uWCKIbKIUTSSipOxbjTAGLMtVqGB();
	}

	[CustomObfuscation(rename = false)]
	public override void OnDestroy()
	{
		if (oDggpbulHhNjKwksRYiPCvdndDIM != null)
		{
			oDggpbulHhNjKwksRYiPCvdndDIM.ayepQoWiuxMOqMBzgIggIDNbAPap();
		}
		if (fFFnSsqhaRGUQNmIgxlzhDookuLI != null)
		{
			fFFnSsqhaRGUQNmIgxlzhDookuLI.ayepQoWiuxMOqMBzgIggIDNbAPap();
		}
		if (pCQiPopqzCFjkDfcXSWAObCObPTq == null)
		{
			return;
		}
		lock (eIhSCCQLmDsFofRnwxZBJfCPSFkL)
		{
			for (int i = 0; i < pCQiPopqzCFjkDfcXSWAObCObPTq.Count; i++)
			{
				if (pCQiPopqzCFjkDfcXSWAObCObPTq[i] != null)
				{
					pCQiPopqzCFjkDfcXSWAObCObPTq[i].dHQZRizRWNfGkiyEfsIkNeECiTwy();
					pCQiPopqzCFjkDfcXSWAObCObPTq[i].botWiBpjJJbejOgoEjqvvTeXULxv();
				}
			}
		}
	}

	[CustomObfuscation(rename = false)]
	public override Action<int, ControllerDataUpdater> GetInputDataUpdateDelegate()
	{
		return PyMGTUmeMOuoyANbnEyHzXENzilp;
	}

	[CustomObfuscation(rename = false)]
	public override void UpdateControllerData(int inputManagerId, ControllerDataUpdater data)
	{
		lock (eIhSCCQLmDsFofRnwxZBJfCPSFkL)
		{
			for (int i = 0; i < DzjPfPgVPjKjnRHISCNWcQawPdJbA; i++)
			{
				if (pCQiPopqzCFjkDfcXSWAObCObPTq[i].get_inputManagerId() == inputManagerId)
				{
					pCQiPopqzCFjkDfcXSWAObCObPTq[i].FillData(data);
					return;
				}
			}
		}
		Logger.LogError("Invalid joystick Id " + inputManagerId + "!");
	}

	[CustomObfuscation(rename = false)]
	public override void SystemDeviceConnected()
	{
		FeImvbMocvyncljJCyNAdVICDpVP = true;
		rqHfHACJTJbSJPlXAdonzOhZzUkEA.Start();
		if (_SystemDeviceConnectedEvent != null)
		{
			_SystemDeviceConnectedEvent();
		}
	}

	[CustomObfuscation(rename = false)]
	public override void SystemDeviceDisconnected()
	{
		FeImvbMocvyncljJCyNAdVICDpVP = true;
		rqHfHACJTJbSJPlXAdonzOhZzUkEA.Start();
		if (_SystemDeviceDisconnectedEvent != null)
		{
			_SystemDeviceDisconnectedEvent();
		}
	}

	[CustomObfuscation(rename = false)]
	public override void SetUnityJoystickId(int joystickId, int unityJoystickId)
	{
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

	private void CzNITHeiLatsZYZzPoCVzflJuuQw()
	{
		if (fFFnSsqhaRGUQNmIgxlzhDookuLI.WPvaYiDQVIYOIzrVogafDyizCCwab())
		{
			if (fFFnSsqhaRGUQNmIgxlzhDookuLI.lDhzHQHlypMVlvNJXJYXaTpmInRJ() && !rqHfHACJTJbSJPlXAdonzOhZzUkEA.running && !oDggpbulHhNjKwksRYiPCvdndDIM.WPvaYiDQVIYOIzrVogafDyizCCwab())
			{
				if (fFFnSsqhaRGUQNmIgxlzhDookuLI.HqfMILYtqQfppDbQVFmQiUncDlYEA())
				{
					FeImvbMocvyncljJCyNAdVICDpVP = true;
				}
				rqHfHACJTJbSJPlXAdonzOhZzUkEA.Start();
			}
		}
		else if (!rqHfHACJTJbSJPlXAdonzOhZzUkEA.running)
		{
			rqHfHACJTJbSJPlXAdonzOhZzUkEA.Start();
		}
		else if (rqHfHACJTJbSJPlXAdonzOhZzUkEA.Update())
		{
			fFFnSsqhaRGUQNmIgxlzhDookuLI.NXdyoJYyGKTPsFkwZEZMxMIDBxdK();
		}
	}

	private List<wOtjejUGdxefShXSCASSpSvjFcbK> zjiuTBlWjvCDrqrLWcpYCUcebzZR()
	{
		List<wOtjejUGdxefShXSCASSpSvjFcbK> list = new List<wOtjejUGdxefShXSCASSpSvjFcbK>();
		IList<cQBxMAHukbVUZQupSRBOiSlaiust> list2 = QwxvvDeHEnYviKUxklewVUDdIqck();
		int count = list2.Count;
		for (int i = 0; i < count; i++)
		{
			if (list2[i] == null)
			{
				continue;
			}
			try
			{
				cQBxMAHukbVUZQupSRBOiSlaiust cQBxMAHukbVUZQupSRBOiSlaiust2 = list2[i];
				Guid olWJPSagxOemyFmiXRXAAqoAkMpib = cQBxMAHukbVUZQupSRBOiSlaiust2.OlWJPSagxOemyFmiXRXAAqoAkMpib;
				acNIMEkbdUZflpTVBxiqmIgjMDSMA acNIMEkbdUZflpTVBxiqmIgjMDSMA2 = new acNIMEkbdUZflpTVBxiqmIgjMDSMA(ItDHHJQXHtjpIxxjhZoxOKbLEOzd, olWJPSagxOemyFmiXRXAAqoAkMpib);
				JicCdQoDTokPeeoVDEduFzfgDpnq jicCdQoDTokPeeoVDEduFzfgDpnq = acNIMEkbdUZflpTVBxiqmIgjMDSMA2.XNgCRWFEXAlAiaivgeZScZsgbRKkD();
				if (esuNIqwdWpgIfzbQhZICYslonOXV == null)
				{
					goto IL_00bd;
				}
				string text = cQBxMAHukbVUZQupSRBOiSlaiust2.yEXnHNQgkgjqFmjHlzhzLVpNUShG.ToString();
				if (!esuNIqwdWpgIfzbQhZICYslonOXV.RDuozChQZcBOEwCjOiuZOAhpKQjc(jicCdQoDTokPeeoVDEduFzfgDpnq.pVlpwcLGBkbikAgmSLUYelnbGRAHB(), StringTools.SanitizeDeviceString(cQBxMAHukbVUZQupSRBOiSlaiust2.vHpBTZZIoLIoPnXyKAkSYMVfCxZaA), string.Empty, new PidVid(Convert.ToUInt16(text.Substring(0, 4), 16), Convert.ToUInt16(text.Substring(4, 4), 16))))
				{
					goto IL_00bd;
				}
				goto end_IL_0028;
				IL_00bd:
				if (lvBLlyyqGuOQBPOhtgAdicoRkrYcb.BDrkzqgzmHeQgxGnATWRFiAJQAUb(InputSource.DirectInput, (ushort)jicCdQoDTokPeeoVDEduFzfgDpnq.dXSBBTgYtKKIKhVDWlMQvdvAVtddA(), (ushort)jicCdQoDTokPeeoVDEduFzfgDpnq.tnfeEXhTjjHXygAIfrrHoViwKtmVb(), (lvBLlyyqGuOQBPOhtgAdicoRkrYcb.XUjlvHZDpakxOFkyIDmXRjHmiElFA)3))
				{
					continue;
				}
				Guid guid = ((!string.IsNullOrEmpty(jicCdQoDTokPeeoVDEduFzfgDpnq.pVlpwcLGBkbikAgmSLUYelnbGRAHB())) ? MiscTools.CreateGuidHashSHA256(jicCdQoDTokPeeoVDEduFzfgDpnq.pVlpwcLGBkbikAgmSLUYelnbGRAHB()) : cQBxMAHukbVUZQupSRBOiSlaiust2.OlWJPSagxOemyFmiXRXAAqoAkMpib);
				bool flag = false;
				lock (eIhSCCQLmDsFofRnwxZBJfCPSFkL)
				{
					if (pCQiPopqzCFjkDfcXSWAObCObPTq != null)
					{
						for (int j = 0; j < pCQiPopqzCFjkDfcXSWAObCObPTq.Count; j++)
						{
							if (pCQiPopqzCFjkDfcXSWAObCObPTq[j] != null && pCQiPopqzCFjkDfcXSWAObCObPTq[j].JSIHxngvZKuKQvFPQGVSlUafGFoN == guid)
							{
								acNIMEkbdUZflpTVBxiqmIgjMDSMA2 = pCQiPopqzCFjkDfcXSWAObCObPTq[j].pvKABDSqYwdOGqvZIZRnMixmzQSI.GEoeNkUyEAnoWoaHezTHrqBHFKiB;
								flag = true;
								break;
							}
						}
					}
				}
				WivuQsnnBaGilaFGOHquRRJlDRWW wivuQsnnBaGilaFGOHquRRJlDRWW = new WivuQsnnBaGilaFGOHquRRJlDRWW(new mxyNLHmDPnGdTytmKVWDUPaQCKgj(acNIMEkbdUZflpTVBxiqmIgjMDSMA2, ZxycCiFieSgkEhzBUiqhbLKAXKDFA), CueCjSoiaiESZjYnphnbORMRgpUG);
				wivuQsnnBaGilaFGOHquRRJlDRWW.mQqeDlcfEtvBEvceImluITFdpIPeb = cQBxMAHukbVUZQupSRBOiSlaiust2;
				wivuQsnnBaGilaFGOHquRRJlDRWW.dMcTpkiaKMGxyBHYaopQCSanAHhab = cQBxMAHukbVUZQupSRBOiSlaiust2.pPMFjlXVbInRTvTqUSITDjuTCJcd;
				wivuQsnnBaGilaFGOHquRRJlDRWW.JSIHxngvZKuKQvFPQGVSlUafGFoN = guid;
				wivuQsnnBaGilaFGOHquRRJlDRWW.WGczDimTElblVmKxHkqEOWbGHsUk = StringTools.SanitizeDeviceString(cQBxMAHukbVUZQupSRBOiSlaiust2.vHpBTZZIoLIoPnXyKAkSYMVfCxZaA);
				wivuQsnnBaGilaFGOHquRRJlDRWW.lNjEKKHDCuCIOkaBEMYrTDFIwJkp = cQBxMAHukbVUZQupSRBOiSlaiust2.yEXnHNQgkgjqFmjHlzhzLVpNUShG;
				wivuQsnnBaGilaFGOHquRRJlDRWW.cHYXOJPMZNDzwEaoluawxVJoGwAn = (hHFsfajLRZYSFHbHIkRhPCzLqfpc)cQBxMAHukbVUZQupSRBOiSlaiust2.wFWVbBjhNmWDaykSmdMXvaaUMdEQ();
				acyaiojiPXAXGKVtvUaYCWaoSJQcA acyaiojiPXAXGKVtvUaYCWaoSJQcA2 = acNIMEkbdUZflpTVBxiqmIgjMDSMA2.PEwJSkJWMSoSqZezTztTuZDIRWxk();
				wivuQsnnBaGilaFGOHquRRJlDRWW.rWmfRVnWKZnVOwgDFjNDsqgfaPjo = jicCdQoDTokPeeoVDEduFzfgDpnq.tnfeEXhTjjHXygAIfrrHoViwKtmVb();
				wivuQsnnBaGilaFGOHquRRJlDRWW.hOttLjwYdgpqXujkQiiiLjxLMKOC = false;
				try
				{
					wivuQsnnBaGilaFGOHquRRJlDRWW.xRsDGLUfLgKtrglCMigEcHZyvNzz = jicCdQoDTokPeeoVDEduFzfgDpnq.aqweBiaNWbIMmSsWSHDKpHSybhBFb();
				}
				catch (Exception)
				{
					wivuQsnnBaGilaFGOHquRRJlDRWW.xRsDGLUfLgKtrglCMigEcHZyvNzz = 0;
				}
				wivuQsnnBaGilaFGOHquRRJlDRWW.JCjrxAHJuJFYVfsnTfwfNbjiyMe = acyaiojiPXAXGKVtvUaYCWaoSJQcA2.UJGVVXnPhfDUuHUzZsmSEAHUxaGz;
				wivuQsnnBaGilaFGOHquRRJlDRWW.RUkFvDetMFtMNabRhsHrynrUFKuw = acyaiojiPXAXGKVtvUaYCWaoSJQcA2.OHYegIVvjHrdtWrbLQKrhxBWGoqV;
				wivuQsnnBaGilaFGOHquRRJlDRWW.YVLiGPIPRedKYahelzxhHOgiKQIQ = acyaiojiPXAXGKVtvUaYCWaoSJQcA2.frHStzqhmpGjbHvmzBdHObKZicqO;
				wivuQsnnBaGilaFGOHquRRJlDRWW.VyFnjjGMCUzFpibbfapgVexfeMLP = new DirectInputControllerExtension(cQBxMAHukbVUZQupSRBOiSlaiust2, acNIMEkbdUZflpTVBxiqmIgjMDSMA2);
				kfYBYMccOQoBxmBJkDdIWJRBxSnI(wivuQsnnBaGilaFGOHquRRJlDRWW, jicCdQoDTokPeeoVDEduFzfgDpnq, out wivuQsnnBaGilaFGOHquRRJlDRWW.rgKCXruzSHuufzyRJskULveijUgD);
				try
				{
					string text2;
					try
					{
						text2 = jicCdQoDTokPeeoVDEduFzfgDpnq.UgrfKhLfUMgNWbUHIgHTpJtddlcVA();
					}
					catch
					{
						text2 = wivuQsnnBaGilaFGOHquRRJlDRWW.WGczDimTElblVmKxHkqEOWbGHsUk;
					}
					if (VYuaBSJJIPmsaDbVsLoJssGHUTLBA.XiYCPJJROGfqSxMqxbyiaZMJrAaOA((ushort)jicCdQoDTokPeeoVDEduFzfgDpnq.dXSBBTgYtKKIKhVDWlMQvdvAVtddA(), (ushort)jicCdQoDTokPeeoVDEduFzfgDpnq.tnfeEXhTjjHXygAIfrrHoViwKtmVb(), text2) && VYuaBSJJIPmsaDbVsLoJssGHUTLBA.PcIZbympUBEPumxuPrByDhFWIatP((ushort)jicCdQoDTokPeeoVDEduFzfgDpnq.dXSBBTgYtKKIKhVDWlMQvdvAVtddA(), (ushort)jicCdQoDTokPeeoVDEduFzfgDpnq.tnfeEXhTjjHXygAIfrrHoViwKtmVb(), text2, out var num, out var num2, out var num3))
					{
						wivuQsnnBaGilaFGOHquRRJlDRWW.pvKABDSqYwdOGqvZIZRnMixmzQSI.xQvZxzEyadmZMSQMbaxlnmsxNtuT(num, num2, num3, VYuaBSJJIPmsaDbVsLoJssGHUTLBA.wlRwcwoERpRuqzmucaxjGcdfGmTHb((ushort)jicCdQoDTokPeeoVDEduFzfgDpnq.dXSBBTgYtKKIKhVDWlMQvdvAVtddA(), (ushort)jicCdQoDTokPeeoVDEduFzfgDpnq.tnfeEXhTjjHXygAIfrrHoViwKtmVb(), text2));
					}
				}
				catch (Exception)
				{
				}
				if (!flag)
				{
					IList<XdTkrmSnPZqRHLipcnjEiLzLeZek> list3 = acNIMEkbdUZflpTVBxiqmIgjMDSMA2.aBQUsptJkFuWEMPGXbWCYeBtmPZj();
					if (list3 != null)
					{
						for (int k = 0; k < list3.Count; k++)
						{
							if ((list3[k].vMxfCdbrpLTpfZZuSxKADfEWjvtw.NIRMSGpfjJFEcGuJHZTAaNtlyQRKA() & rWezaGflEYhSWijeLCQlsOUkWUZN.Axis) != rWezaGflEYhSWijeLCQlsOUkWUZN.All)
							{
								acNIMEkbdUZflpTVBxiqmIgjMDSMA2.XNgCRWFEXAlAiaivgeZScZsgbRKkD().CDerDNBRKENEuDHFHYgovCgLLpNo(new UrYqMljpjmvTgRRFXPSTBEPnMLKn(-65535, 65535));
							}
						}
					}
					acNIMEkbdUZflpTVBxiqmIgjMDSMA2.XNgCRWFEXAlAiaivgeZScZsgbRKkD().WXfiUKWGzogGVEiCHeAMOjxIcHCM(AgBHvfPhBdxqajbYqzmajCASMhzt.Absolute);
					acNIMEkbdUZflpTVBxiqmIgjMDSMA2.LLhBZdGDLpjRsEaAFKykQlkRrlWIc(wSEfBMeKywOkcIaGVjZDznwELQDuA, diRaOcTZVajXRYhzLKNNMFQrXPNw.NonExclusive | diRaOcTZVajXRYhzLKNNMFQrXPNw.Background);
					acNIMEkbdUZflpTVBxiqmIgjMDSMA2.NRLBiBqDROwlvswVRjyZjAGQpKVj();
				}
				list.Add(new wOtjejUGdxefShXSCASSpSvjFcbK(wivuQsnnBaGilaFGOHquRRJlDRWW, cQBxMAHukbVUZQupSRBOiSlaiust2));
				end_IL_0028:;
			}
			catch (Exception)
			{
			}
		}
		return list;
	}

	private void FKbRaUOjbqAJbXraMuBbtIoGfUuM()
	{
		tGQoAIfIhBgrSCgOaEodGoRiMtyf(zjiuTBlWjvCDrqrLWcpYCUcebzZR());
	}

	private void tGQoAIfIhBgrSCgOaEodGoRiMtyf(List<wOtjejUGdxefShXSCASSpSvjFcbK> P_0)
	{
		List<WivuQsnnBaGilaFGOHquRRJlDRWW> list = new List<WivuQsnnBaGilaFGOHquRRJlDRWW>();
		ZpYAgsdUHyRMzoGyPqBzYNDphIHSA = 0;
		int num = P_0?.Count ?? 0;
		for (int i = 0; i < num; i++)
		{
			if (P_0[i] == null || !P_0[i].pSTFXxkcFEcUcwOQVOUuCNUbpABe())
			{
				continue;
			}
			try
			{
				WivuQsnnBaGilaFGOHquRRJlDRWW mJVfRrfUfzKEVCosIqTWXLklfFvxA = P_0[i].mJVfRrfUfzKEVCosIqTWXLklfFvxA;
				mJVfRrfUfzKEVCosIqTWXLklfFvxA.vFixfAiDwLNjAaaBuVpMHEZabxdW();
				if (mJVfRrfUfzKEVCosIqTWXLklfFvxA.EGdfQrHXBnPlvsPfyipeRkIQgPIeb)
				{
					ZpYAgsdUHyRMzoGyPqBzYNDphIHSA++;
				}
				list.Add(mJVfRrfUfzKEVCosIqTWXLklfFvxA);
			}
			catch (Exception)
			{
			}
		}
		lLleVwLCyQxzcxsOhxDQtyNOTjfk.JSRrMFzVbTGXcsyEQRPrqEKlgKpG(ZpYAgsdUHyRMzoGyPqBzYNDphIHSA);
		lock (eIhSCCQLmDsFofRnwxZBJfCPSFkL)
		{
			List<WivuQsnnBaGilaFGOHquRRJlDRWW> list2 = pCQiPopqzCFjkDfcXSWAObCObPTq;
			int dzjPfPgVPjKjnRHISCNWcQawPdJbA = DzjPfPgVPjKjnRHISCNWcQawPdJbA;
			int count = list.Count;
			ZQBkxusYnLhrSLhjfdObuZugAgSU(dzjPfPgVPjKjnRHISCNWcQawPdJbA, count, list2, list);
			for (int j = 0; j < count; j++)
			{
				if (_UpdateControllerInfoEvent != null)
				{
					_UpdateControllerInfoEvent(new UpdateControllerInfoEventArgs(list[j]));
				}
			}
			LCaAGccmwGklIFuIRhXSGfNAXWmxb(list2, list, false);
			LCaAGccmwGklIFuIRhXSGfNAXWmxb(list, list2, true);
			OfSCwcbsoMXikFjjFYkDzJiKZQkC(list, list2);
			pCQiPopqzCFjkDfcXSWAObCObPTq = list;
			DzjPfPgVPjKjnRHISCNWcQawPdJbA = list.Count;
		}
	}

	private void kfYBYMccOQoBxmBJkDdIWJRBxSnI(WivuQsnnBaGilaFGOHquRRJlDRWW P_0, JicCdQoDTokPeeoVDEduFzfgDpnq P_1, out string P_2)
	{
		P_2 = string.Empty;
		if (P_0 == null || P_1 == null)
		{
			return;
		}
		string text = OxKeauxLUpOkqzUbEfAbQPUKOxxA.zyOhEyYnzUZnWEITNEfwzUcFUSyx(P_1.pVlpwcLGBkbikAgmSLUYelnbGRAHB());
		if (string.IsNullOrEmpty(text))
		{
			return;
		}
		try
		{
			uBrmqrtoboLqIilEjDdEvcpBPEer uBrmqrtoboLqIilEjDdEvcpBPEer2 = jJVMeOSGFiWvYXFSLLMERjkQCZOv.dWSJFHwpTFFeoJMJZFWqCZgeIfiUB(text.ToLower(CultureInfo.InvariantCulture));
			if (uBrmqrtoboLqIilEjDdEvcpBPEer2 != null)
			{
				P_0.EGdfQrHXBnPlvsPfyipeRkIQgPIeb = uBrmqrtoboLqIilEjDdEvcpBPEer2.iuUBqEHRKPcdgdCWAXiJEkVtJJFab();
				P_0.zjdBMWFLbeOBJSmHchUrBbXymdme = uBrmqrtoboLqIilEjDdEvcpBPEer2.rxifAziAOBcmNmfelsmhEqmsQBKlA();
				P_2 = lvBLlyyqGuOQBPOhtgAdicoRkrYcb.GyvGoeHCHQQdWtsEOOqaqyZmBTTMA(uBrmqrtoboLqIilEjDdEvcpBPEer2, P_0.lNjEKKHDCuCIOkaBEMYrTDFIwJkp, P_0.WGczDimTElblVmKxHkqEOWbGHsUk, P_0.zjdBMWFLbeOBJSmHchUrBbXymdme);
				uBrmqrtoboLqIilEjDdEvcpBPEer2.Dispose();
			}
		}
		catch (Exception)
		{
		}
	}

	private void uWCKIbKIUTSSipOxbjTAGLMtVqGB()
	{
		lock (eIhSCCQLmDsFofRnwxZBJfCPSFkL)
		{
			for (int i = 0; i < DzjPfPgVPjKjnRHISCNWcQawPdJbA; i++)
			{
				try
				{
					WivuQsnnBaGilaFGOHquRRJlDRWW wivuQsnnBaGilaFGOHquRRJlDRWW = pCQiPopqzCFjkDfcXSWAObCObPTq[i];
					if (wivuQsnnBaGilaFGOHquRRJlDRWW != null && wivuQsnnBaGilaFGOHquRRJlDRWW.lDGzsKKTqDICJTBvxfgBpcRTReTm() && (laAVmpydykZoloUrxIfSCUfKPqfV() == null || !wivuQsnnBaGilaFGOHquRRJlDRWW.hOttLjwYdgpqXujkQiiiLjxLMKOC))
					{
						wivuQsnnBaGilaFGOHquRRJlDRWW.Update();
					}
				}
				catch
				{
				}
			}
		}
	}

	private IList<cQBxMAHukbVUZQupSRBOiSlaiust> QwxvvDeHEnYviKUxklewVUDdIqck()
	{
		try
		{
			IList<cQBxMAHukbVUZQupSRBOiSlaiust> list = ItDHHJQXHtjpIxxjhZoxOKbLEOzd.UMlBPabSMDscUAzWvpGCMyWHBsySA(KwMHHfNTwEYhGoVEiNBaXUMLlAml.GameControl, grafWZdmFPBElhoJiCXQcZctJhNX.AttachedOnly);
			SWQImlxFcsFxLhKkizXvAuTAEDIk = list?.Count ?? 0;
			return list;
		}
		catch
		{
			Logger.LogError("Error getting devices from Direct Input!");
			SWQImlxFcsFxLhKkizXvAuTAEDIk = 0;
			return EmptyObjects<cQBxMAHukbVUZQupSRBOiSlaiust>.EmptyReadOnlyIListT;
		}
	}

	private void hsWEtaJXQDAJfYxlDUbyYKpvbvuFA()
	{
		ItDHHJQXHtjpIxxjhZoxOKbLEOzd.ybwSEaFhfrSyrMTxuMppyHqcGFuDA();
	}

	private void ZQBkxusYnLhrSLhjfdObuZugAgSU(int P_0, int P_1, List<WivuQsnnBaGilaFGOHquRRJlDRWW> P_2, List<WivuQsnnBaGilaFGOHquRRJlDRWW> P_3)
	{
		if (P_1 > 0)
		{
			P_3.Sort(WivuQsnnBaGilaFGOHquRRJlDRWW.kkkXBXqHwiRcKUqikiLgBkAPOPmbA);
		}
		if (P_0 > 0 && P_1 > 0)
		{
			uEQEWRYnWEGAqCHnGJJgesIPQKfRA(P_1, P_3, P_0, P_2, oddkCxrFVeCGPDjioghPlbFIwcNgA.MhkPqBZJgWcoJTchZBUKEFShOeFy.Exact);
		}
		UCUeYMfcNuKnsYEFrTtyxcSvDsJL(P_1, P_3, oddkCxrFVeCGPDjioghPlbFIwcNgA.MhkPqBZJgWcoJTchZBUKEFShOeFy.Exact);
		for (int i = 0; i < P_1; i++)
		{
			WivuQsnnBaGilaFGOHquRRJlDRWW wivuQsnnBaGilaFGOHquRRJlDRWW = P_3[i];
			if (wivuQsnnBaGilaFGOHquRRJlDRWW != null && wivuQsnnBaGilaFGOHquRRJlDRWW.get_inputManagerId() < 0)
			{
				wivuQsnnBaGilaFGOHquRRJlDRWW.set_inputManagerId(hCXdBRaILiRqtUnsLByHHZTgXTiy(P_3));
				wivuQsnnBaGilaFGOHquRRJlDRWW.set_rewiredId(bRFMCApQWYhfFNvUFjQPcXfbMnru());
				dSQaOTmepbZwCSLSkpIfSXnUbOoT.OBUgBTBilDpiwabrBfVzNsuDVRMPB(wivuQsnnBaGilaFGOHquRRJlDRWW);
			}
		}
		P_3.Sort(WivuQsnnBaGilaFGOHquRRJlDRWW.fQafhMUYZDccLYLgkYvkQrhXpBWe);
	}

	private void JaGInCngMDJsdjnVZkBMspxRTIJU(List<WivuQsnnBaGilaFGOHquRRJlDRWW> P_0, int P_1, int P_2)
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

	private bool sdSDKmALAduLKAAWgVcltqJKtoiX(List<WivuQsnnBaGilaFGOHquRRJlDRWW> P_0, int P_1)
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

	private int hCXdBRaILiRqtUnsLByHHZTgXTiy(List<WivuQsnnBaGilaFGOHquRRJlDRWW> P_0)
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

	private bool AaVVQLPBfZzgiNnYdYBSYMAStaeR(List<WivuQsnnBaGilaFGOHquRRJlDRWW> P_0, int P_1)
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

	private void uEQEWRYnWEGAqCHnGJJgesIPQKfRA(int P_0, List<WivuQsnnBaGilaFGOHquRRJlDRWW> P_1, int P_2, List<WivuQsnnBaGilaFGOHquRRJlDRWW> P_3, oddkCxrFVeCGPDjioghPlbFIwcNgA.MhkPqBZJgWcoJTchZBUKEFShOeFy P_4)
	{
		int num = ((P_4 != oddkCxrFVeCGPDjioghPlbFIwcNgA.MhkPqBZJgWcoJTchZBUKEFShOeFy.Exact) ? 1 : 2);
		for (int i = 0; i < P_0; i++)
		{
			WivuQsnnBaGilaFGOHquRRJlDRWW wivuQsnnBaGilaFGOHquRRJlDRWW = P_1[i];
			if (wivuQsnnBaGilaFGOHquRRJlDRWW == null || wivuQsnnBaGilaFGOHquRRJlDRWW.get_inputManagerId() >= 0)
			{
				continue;
			}
			for (int j = 0; j < P_2; j++)
			{
				WivuQsnnBaGilaFGOHquRRJlDRWW wivuQsnnBaGilaFGOHquRRJlDRWW2 = P_3[j];
				if (wivuQsnnBaGilaFGOHquRRJlDRWW2 != null && !AaVVQLPBfZzgiNnYdYBSYMAStaeR(P_1, wivuQsnnBaGilaFGOHquRRJlDRWW2.get_rewiredId()) && wivuQsnnBaGilaFGOHquRRJlDRWW.oCsDYSCyvHombbBLWPbfoNhleeMAb(wivuQsnnBaGilaFGOHquRRJlDRWW2) >= num)
				{
					wivuQsnnBaGilaFGOHquRRJlDRWW.IhBoNIdgGUoVoweYZIPbPLvoeJut(wivuQsnnBaGilaFGOHquRRJlDRWW2);
					dSQaOTmepbZwCSLSkpIfSXnUbOoT.OBUgBTBilDpiwabrBfVzNsuDVRMPB(wivuQsnnBaGilaFGOHquRRJlDRWW);
				}
			}
		}
	}

	private void UCUeYMfcNuKnsYEFrTtyxcSvDsJL(int P_0, List<WivuQsnnBaGilaFGOHquRRJlDRWW> P_1, oddkCxrFVeCGPDjioghPlbFIwcNgA.MhkPqBZJgWcoJTchZBUKEFShOeFy P_2)
	{
		for (int i = 0; i < P_0; i++)
		{
			WivuQsnnBaGilaFGOHquRRJlDRWW wivuQsnnBaGilaFGOHquRRJlDRWW = P_1[i];
			if (wivuQsnnBaGilaFGOHquRRJlDRWW == null || wivuQsnnBaGilaFGOHquRRJlDRWW.get_inputManagerId() >= 0)
			{
				continue;
			}
			oddkCxrFVeCGPDjioghPlbFIwcNgA.qBLziUtnPMSCWLoQRPgjuMWokgzn qBLziUtnPMSCWLoQRPgjuMWokgzn = null;
			foreach (oddkCxrFVeCGPDjioghPlbFIwcNgA.qBLziUtnPMSCWLoQRPgjuMWokgzn item in dSQaOTmepbZwCSLSkpIfSXnUbOoT.grgEMEnBsQOuAtSZKVELdwWxgvkT(wivuQsnnBaGilaFGOHquRRJlDRWW, P_2))
			{
				if (!AaVVQLPBfZzgiNnYdYBSYMAStaeR(P_1, item.GsftiOrcPMfUIdWgBGQtOEkrDgpFb) && item.LJmujwnzMgCgcVWpEOgeafJpDPJq >= 0)
				{
					qBLziUtnPMSCWLoQRPgjuMWokgzn = item;
					break;
				}
			}
			if (qBLziUtnPMSCWLoQRPgjuMWokgzn != null)
			{
				int num = qBLziUtnPMSCWLoQRPgjuMWokgzn.LJmujwnzMgCgcVWpEOgeafJpDPJq;
				if (!sdSDKmALAduLKAAWgVcltqJKtoiX(P_1, num))
				{
					num = (qBLziUtnPMSCWLoQRPgjuMWokgzn.LJmujwnzMgCgcVWpEOgeafJpDPJq = hCXdBRaILiRqtUnsLByHHZTgXTiy(P_1));
				}
				wivuQsnnBaGilaFGOHquRRJlDRWW.set_inputManagerId(num);
				wivuQsnnBaGilaFGOHquRRJlDRWW.set_rewiredId(qBLziUtnPMSCWLoQRPgjuMWokgzn.GsftiOrcPMfUIdWgBGQtOEkrDgpFb);
				dSQaOTmepbZwCSLSkpIfSXnUbOoT.OBUgBTBilDpiwabrBfVzNsuDVRMPB(wivuQsnnBaGilaFGOHquRRJlDRWW);
			}
		}
	}

	private void tdBqbYhGykMTFxIespbdfqVYbsEB()
	{
		if (FeImvbMocvyncljJCyNAdVICDpVP)
		{
			vFqJuvSuwyCnyYvvdEorlgvlCkzFA();
		}
		if (oDggpbulHhNjKwksRYiPCvdndDIM.WPvaYiDQVIYOIzrVogafDyizCCwab() && oDggpbulHhNjKwksRYiPCvdndDIM.lDhzHQHlypMVlvNJXJYXaTpmInRJ())
		{
			APBvckhoSiBfhBIISRoKQOAPnjoKA(oDggpbulHhNjKwksRYiPCvdndDIM.HqfMILYtqQfppDbQVFmQiUncDlYEA());
		}
	}

	private void vFqJuvSuwyCnyYvvdEorlgvlCkzFA()
	{
		FeImvbMocvyncljJCyNAdVICDpVP = false;
		if (!oDggpbulHhNjKwksRYiPCvdndDIM.WPvaYiDQVIYOIzrVogafDyizCCwab())
		{
			oDggpbulHhNjKwksRYiPCvdndDIM.NXdyoJYyGKTPsFkwZEZMxMIDBxdK();
		}
	}

	private void APBvckhoSiBfhBIISRoKQOAPnjoKA(List<wOtjejUGdxefShXSCASSpSvjFcbK> P_0)
	{
		if (BkjBrDhuljizEQybFAwldmxDCwcUb(wOtjejUGdxefShXSCASSpSvjFcbK.mHmeEhkLVGkDDvSBHHtjplipCoaf(P_0)))
		{
			tGQoAIfIhBgrSCgOaEodGoRiMtyf(P_0);
		}
	}

	private bool BkjBrDhuljizEQybFAwldmxDCwcUb(IList<cQBxMAHukbVUZQupSRBOiSlaiust> P_0)
	{
		lock (eIhSCCQLmDsFofRnwxZBJfCPSFkL)
		{
			int count = P_0.Count;
			for (int i = 0; i < count; i++)
			{
				if (P_0[i] != null && !FyygKJTjsfQoLEiKVIMTdOkkpsMmA(P_0[i].OlWJPSagxOemyFmiXRXAAqoAkMpib))
				{
					return true;
				}
			}
			int count2 = pCQiPopqzCFjkDfcXSWAObCObPTq.Count;
			for (int j = 0; j < count2; j++)
			{
				if (pCQiPopqzCFjkDfcXSWAObCObPTq[j] != null && !ELYrWZJXirKpiOWjFVLcboeEDcdbA(P_0, pCQiPopqzCFjkDfcXSWAObCObPTq[j].get_instanceGuid()))
				{
					return true;
				}
			}
		}
		return false;
	}

	private bool FyygKJTjsfQoLEiKVIMTdOkkpsMmA(Guid P_0)
	{
		lock (eIhSCCQLmDsFofRnwxZBJfCPSFkL)
		{
			int count = pCQiPopqzCFjkDfcXSWAObCObPTq.Count;
			for (int i = 0; i < count; i++)
			{
				if (pCQiPopqzCFjkDfcXSWAObCObPTq[i] != null && pCQiPopqzCFjkDfcXSWAObCObPTq[i].get_instanceGuid() == P_0)
				{
					return true;
				}
			}
		}
		return false;
	}

	private bool ELYrWZJXirKpiOWjFVLcboeEDcdbA(IList<cQBxMAHukbVUZQupSRBOiSlaiust> P_0, Guid P_1)
	{
		int count = P_0.Count;
		for (int i = 0; i < count; i++)
		{
			if (P_0[i] != null && P_0[i].OlWJPSagxOemyFmiXRXAAqoAkMpib == P_1)
			{
				return true;
			}
		}
		return false;
	}

	private void LCaAGccmwGklIFuIRhXSGfNAXWmxb(List<WivuQsnnBaGilaFGOHquRRJlDRWW> P_0, List<WivuQsnnBaGilaFGOHquRRJlDRWW> P_1, bool P_2)
	{
		if (P_0 == null)
		{
			return;
		}
		int num = P_0?.Count ?? 0;
		int num2 = P_1?.Count ?? 0;
		for (int i = 0; i < num; i++)
		{
			WivuQsnnBaGilaFGOHquRRJlDRWW wivuQsnnBaGilaFGOHquRRJlDRWW = P_0[i];
			if (wivuQsnnBaGilaFGOHquRRJlDRWW == null)
			{
				continue;
			}
			bool flag = false;
			if (P_1 != null)
			{
				for (int j = 0; j < num2; j++)
				{
					WivuQsnnBaGilaFGOHquRRJlDRWW wivuQsnnBaGilaFGOHquRRJlDRWW2 = P_1[j];
					if (wivuQsnnBaGilaFGOHquRRJlDRWW2 != null && wivuQsnnBaGilaFGOHquRRJlDRWW.get_instanceGuid() == wivuQsnnBaGilaFGOHquRRJlDRWW2.get_instanceGuid())
					{
						flag = true;
						break;
					}
				}
			}
			if (!flag)
			{
				JGdWAAPcbRCvCaIATOxQrjSfBXNEb(P_0[i], P_2);
			}
		}
	}

	private void JGdWAAPcbRCvCaIATOxQrjSfBXNEb(WivuQsnnBaGilaFGOHquRRJlDRWW P_0, bool P_1)
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

	private bool mTKBzqMtPMAJmpeCXluEQzxWlvjX()
	{
		int num = ItDHHJQXHtjpIxxjhZoxOKbLEOzd.KlBKtwQKHQMpgmpWZeXkZpUeGjubA(KwMHHfNTwEYhGoVEiNBaXUMLlAml.GameControl, grafWZdmFPBElhoJiCXQcZctJhNX.AttachedOnly);
		if (SWQImlxFcsFxLhKkizXvAuTAEDIk != num)
		{
			SWQImlxFcsFxLhKkizXvAuTAEDIk = num;
			return true;
		}
		if (ZpYAgsdUHyRMzoGyPqBzYNDphIHSA > 0 && lLleVwLCyQxzcxsOhxDQtyNOTjfk.TgEFiwsDTsJBuLhFiaLplpTuGVbq())
		{
			return true;
		}
		return false;
	}

	private void OfSCwcbsoMXikFjjFYkDzJiKZQkC(List<WivuQsnnBaGilaFGOHquRRJlDRWW> P_0, List<WivuQsnnBaGilaFGOHquRRJlDRWW> P_1)
	{
		if (P_1 == null)
		{
			return;
		}
		for (int i = 0; i < P_1.Count; i++)
		{
			if (P_1[i] != null && (P_0 == null || !P_0.Contains(P_1[i])))
			{
				P_1[i].botWiBpjJJbejOgoEjqvvTeXULxv();
			}
		}
	}

	[Conditional("DEBUGTHIS")]
	private void rJYBiinhnQutAUTkOoibvMKtUtSQ(string P_0)
	{
		Logger.Log(P_0);
	}

	[CompilerGenerated]
	private List<wOtjejUGdxefShXSCASSpSvjFcbK> SlxOWEtCgiscHWLkjtVpgTusGOSR()
	{
		return zjiuTBlWjvCDrqrLWcpYCUcebzZR();
	}
}
