using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Rewired;
using Rewired.Config;
using Rewired.Data.Mapping;
using Rewired.Interfaces;
using Rewired.Internal.Localization;
using Rewired.Libraries.SharpDX.XInput;
using Rewired.Platforms;
using Rewired.Platforms.Windows.XInput;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using Rewired.Utils.Classes.Utility;
using UnityEngine;

internal class fXHRBPluCVlFmVyDTJoQUtqLlMxB : PlatformInputManager, lqpQxMQBnMKtcyVNasPoQMoNTuAx
{
	private class gFyYDvnzMpDQpRdqCVRzJQTUBTLG : IInputManagerJoystick, IInputManagerJoystickPublic, ITryGetLocalizedName, IDisposable
	{
		private bool hnIMUsPausDHfdozWgOaegNuZkmNA;

		private int AvhcyDHgFqKZaqtSKqxdGeyqmsulA;

		private readonly int rDgWfmtQYwhHMKlDsolBmVCtYieJ;

		public Guid maMpZxxNiqoOVukIODoTqaEHgUfp;

		public string rpuDXXeAmxYWwPqUBmuixjPyQgZfA;

		public string hMVUQNDhyvYrWrXqUZNujNXGsRDg;

		public Guid rpHyANJTpZyIwqMiREJIZayaeZMC;

		public Rewired.Libraries.SharpDX.XInput.DeviceType uoOKYBuXpwjKxGyVaNXugloEVIUq;

		public XInputDeviceSubType JdvsyMzBLFVKfinmKzjidanpvtlr;

		public bool oCjAkdMFcuILjArDRdMXUoWQMeGwA;

		public bool rLBAnqRqZNUYUoURyvYJdyTMAxtp;

		public bool iSUnsiQLochUsDVDrlpEiGZHCzWr;

		public bool uVYMFuWMXHcbSnyKDXesbexNfsSb;

		private int FVsMlAkcnbTtPNkPDwBxPHDXUAVi;

		private int AnToBLUDgZLKreKbADjgACsfrDJv;

		private int xAJreYomUOyTjihkShULTWHctdRq;

		private int oxXsNzLtgvTADQBaPcnRBTLLXrnQ;

		private readonly float[] mXFnihSCgZaTwHFgeDOHqvUuIovgA;

		private readonly bool[] eFtHkUBswGlnmIgoDYAeREdbRhtac;

		private HardwareJoystickMap_InputManager QzsqGxMRVksVHiYbznTNvRTfWexI;

		public readonly mYfrdbcireBcNJFrWedHlySfZSdOA mFKBGosAemYkqpiMHzApAAgPvOGt;

		private Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> LywOMeJClRIrnjunATjwwFHapJrC;

		private Action aKVYWNZwKkPekRZVrsDNKiCmffDC;

		private readonly LocalizedString fiqcOnFJjYvZASQrYVvzoAUqztbAA;

		private bool UCsGfPBywJDdEUDJnpXycQJuvfShA;

		private bool USdmvQxDYxabMIPuOQXqCOZqqxulA;

		private bool moVupBnHSiMuxrwRxyuXxIUlGfGm;

		public string swMCDXzXhjfThhfmCTzWtITbGjOWA => IEcEPkemfwJfqFJKgTwJIlniWBBA();

		public string GtBVvpiXlCBfoDRSoilVWSpvcAOn => FTyhzyPtsgPKyqoEYdWYVWdxgVFO();

		public bool PWLKVQSVJjrsyACjygqWnkdCDlfhA => GUujVoQhDxDGoqOhXupKaJOWRjtJ();

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
		int IInputManagerJoystickPublic.inputManagerId => get_inputManagerId();

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

		public string IEcEPkemfwJfqFJKgTwJIlniWBBA()
		{
			string text = FTyhzyPtsgPKyqoEYdWYVWdxgVFO();
			if (text == string.Empty)
			{
				return string.Empty;
			}
			int num = rDgWfmtQYwhHMKlDsolBmVCtYieJ;
			return text + " " + num;
		}

		public string FTyhzyPtsgPKyqoEYdWYVWdxgVFO()
		{
			if (!GUujVoQhDxDGoqOhXupKaJOWRjtJ())
			{
				return string.Empty;
			}
			return JdvsyMzBLFVKfinmKzjidanpvtlr.ToString();
		}

		public bool GUujVoQhDxDGoqOhXupKaJOWRjtJ()
		{
			if (mFKBGosAemYkqpiMHzApAAgPvOGt == null || !uVYMFuWMXHcbSnyKDXesbexNfsSb)
			{
				return false;
			}
			if (UCsGfPBywJDdEUDJnpXycQJuvfShA && !koOWFHzyOEbnQdPKCvVUSfBTwOZM(bCmkcsFvCcAVyQUFvmznhNAPsUCK.Asynchronous))
			{
				DCyHoSoAZAxfeLVFmjjbMaFTMVuH();
			}
			return UCsGfPBywJDdEUDJnpXycQJuvfShA;
		}

		public int get_rewiredId()
		{
			return AvhcyDHgFqKZaqtSKqxdGeyqmsulA;
		}

		public void set_rewiredId(int value)
		{
			AvhcyDHgFqKZaqtSKqxdGeyqmsulA = value;
		}

		public int get_inputManagerId()
		{
			return rDgWfmtQYwhHMKlDsolBmVCtYieJ;
		}

		public string get_name()
		{
			return hMVUQNDhyvYrWrXqUZNujNXGsRDg;
		}

		public long? get_systemId()
		{
			return rDgWfmtQYwhHMKlDsolBmVCtYieJ;
		}

		public int get_unityId()
		{
			return 0;
		}

		public Controller.Extension get_extension()
		{
			if (mFKBGosAemYkqpiMHzApAAgPvOGt == null)
			{
				return null;
			}
			return mFKBGosAemYkqpiMHzApAAgPvOGt.velbXRVvMACnZLSsoyQATJzQgIqF();
		}

		public Guid get_instanceGuid()
		{
			return rpHyANJTpZyIwqMiREJIZayaeZMC;
		}

		public Guid get_persistentGuid()
		{
			return get_instanceGuid();
		}

		[CustomObfuscation(rename = false)]
		public void SetVibration(float amount, int motorIndex)
		{
			mFKBGosAemYkqpiMHzApAAgPvOGt.JPtkqRUPCLknWsgzGaqsDigagnOTA(amount, motorIndex);
		}

		void IInputManagerJoystickPublic.SetVibration(float amount, int motorIndex)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetVibration
			this.SetVibration(amount, motorIndex);
		}

		[CustomObfuscation(rename = false)]
		public void StopVibration()
		{
			mFKBGosAemYkqpiMHzApAAgPvOGt.NUZZLsblGkUdPANMIURxSmLMdNvW();
		}

		void IInputManagerJoystickPublic.StopVibration()
		{
			//ILSpy generated this explicit interface implementation from .override directive in StopVibration
			this.StopVibration();
		}

		bool ITryGetLocalizedName.TryGetLocalizedName(out string value)
		{
			if ((LocalizationManager.GetAndUpdateLocalizedString(fiqcOnFJjYvZASQrYVvzoAUqztbAA, QzsqGxMRVksVHiYbznTNvRTfWexI.deviceLocalizationInfo.parentKeys, "controller", rpuDXXeAmxYWwPqUBmuixjPyQgZfA, out value) & LocalizationManager.GetAndUpdateLocalizedStringResultFlags.Changed) != LocalizationManager.GetAndUpdateLocalizedStringResultFlags.None)
			{
				value = $"{value} {(rDgWfmtQYwhHMKlDsolBmVCtYieJ + 1).ToString()}";
				fiqcOnFJjYvZASQrYVvzoAUqztbAA.cachedValue = value;
			}
			return true;
		}

		public gFyYDvnzMpDQpRdqCVRzJQTUBTLG(int P_0, bool P_1, mYfrdbcireBcNJFrWedHlySfZSdOA P_2, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> P_3, Action P_4)
		{
			mFKBGosAemYkqpiMHzApAAgPvOGt = P_2;
			hnIMUsPausDHfdozWgOaegNuZkmNA = P_1;
			rDgWfmtQYwhHMKlDsolBmVCtYieJ = P_0;
			LywOMeJClRIrnjunATjwwFHapJrC = P_3;
			aKVYWNZwKkPekRZVrsDNKiCmffDC = P_4;
			AvhcyDHgFqKZaqtSKqxdGeyqmsulA = -1;
			FVsMlAkcnbTtPNkPDwBxPHDXUAVi = 6;
			AnToBLUDgZLKreKbADjgACsfrDJv = 15;
			xAJreYomUOyTjihkShULTWHctdRq = FVsMlAkcnbTtPNkPDwBxPHDXUAVi;
			oxXsNzLtgvTADQBaPcnRBTLLXrnQ = AnToBLUDgZLKreKbADjgACsfrDJv;
			mXFnihSCgZaTwHFgeDOHqvUuIovgA = new float[FVsMlAkcnbTtPNkPDwBxPHDXUAVi];
			eFtHkUBswGlnmIgoDYAeREdbRhtac = new bool[AnToBLUDgZLKreKbADjgACsfrDJv];
			fiqcOnFJjYvZASQrYVvzoAUqztbAA = new LocalizedString();
			xCcMajnCRiQXzoFRSZkyibrSiLht();
		}

		[CustomObfuscation(rename = false)]
		public void Update()
		{
			mFKBGosAemYkqpiMHzApAAgPvOGt.QnHFVTlNpeaUseGMZtBbHFHVmkYM();
			bool[] array = mFKBGosAemYkqpiMHzApAAgPvOGt.ozmoHLGyyMYriQdodJbioMkCxNWQ();
			bdrijuBDsxwISkbEOSugsvogxsBp(array, ref mFKBGosAemYkqpiMHzApAAgPvOGt.qOIaQPjTafimqmQrkpRkwGHPOyVk);
			PGseTZwfYQxDNjbadDWXYpiVLOn(array, ref mFKBGosAemYkqpiMHzApAAgPvOGt.qOIaQPjTafimqmQrkpRkwGHPOyVk);
			mFKBGosAemYkqpiMHzApAAgPvOGt.fVSTOKYCyDgucRDhbfJTfRWoSonz();
		}

		void IInputManagerJoystick.Update()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Update
			this.Update();
		}

		public void cYyQLfuJQfakeUPvQuSftpEthJxf(bool P_0)
		{
			if (mFKBGosAemYkqpiMHzApAAgPvOGt != null)
			{
				iSUnsiQLochUsDVDrlpEiGZHCzWr = P_0;
			}
		}

		public bool koOWFHzyOEbnQdPKCvVUSfBTwOZM(bCmkcsFvCcAVyQUFvmznhNAPsUCK P_0)
		{
			wxhyTpFzWBLMrcoDiqzDAfiZIfzS(yPucXGRkwwcGSQMAuCADyZrziVhO(P_0));
			return UCsGfPBywJDdEUDJnpXycQJuvfShA;
		}

		public bool yPucXGRkwwcGSQMAuCADyZrziVhO(bCmkcsFvCcAVyQUFvmznhNAPsUCK P_0)
		{
			if (mFKBGosAemYkqpiMHzApAAgPvOGt == null)
			{
				return false;
			}
			return mFKBGosAemYkqpiMHzApAAgPvOGt.hQuAHmSbwrpBtgAUHGzUgsoIpDBJA(P_0);
		}

		public void wxhyTpFzWBLMrcoDiqzDAfiZIfzS(bool P_0)
		{
			UCsGfPBywJDdEUDJnpXycQJuvfShA = P_0;
		}

		public void tupeeTizUyfhRUJzHhNpUpphTOUM()
		{
			if (!uVYMFuWMXHcbSnyKDXesbexNfsSb || OjHDgwLYKRNLesOsoTTfkIINlJjp())
			{
				xCcMajnCRiQXzoFRSZkyibrSiLht();
			}
			if (uVYMFuWMXHcbSnyKDXesbexNfsSb && UCsGfPBywJDdEUDJnpXycQJuvfShA)
			{
				mFKBGosAemYkqpiMHzApAAgPvOGt.AXrtbShIyLyWkdWaxMdcqvwSPSaJ();
			}
		}

		public void qKVhYAflQhLCnFUnNaWIGsdYHeEV()
		{
			AvhcyDHgFqKZaqtSKqxdGeyqmsulA = -1;
			uVYMFuWMXHcbSnyKDXesbexNfsSb = false;
			mFKBGosAemYkqpiMHzApAAgPvOGt.aBMZecBxjbElXxhesIWIvoeqAwbEA();
			Array.Clear(mXFnihSCgZaTwHFgeDOHqvUuIovgA, 0, mXFnihSCgZaTwHFgeDOHqvUuIovgA.Length);
			Array.Clear(eFtHkUBswGlnmIgoDYAeREdbRhtac, 0, eFtHkUBswGlnmIgoDYAeREdbRhtac.Length);
		}

		[CustomObfuscation(rename = false)]
		public void FillData(ControllerDataUpdater dataUpdater)
		{
			if (FVsMlAkcnbTtPNkPDwBxPHDXUAVi != dataUpdater.axisCount || AnToBLUDgZLKreKbADjgACsfrDJv != dataUpdater.buttonCount)
			{
				throw new Exception("This controller signature does not match the data object!");
			}
			for (int i = 0; i < FVsMlAkcnbTtPNkPDwBxPHDXUAVi; i++)
			{
				dataUpdater.axisValues[i] = mXFnihSCgZaTwHFgeDOHqvUuIovgA[i];
			}
			for (int j = 0; j < AnToBLUDgZLKreKbADjgACsfrDJv; j++)
			{
				dataUpdater.buttonValues[j] = eFtHkUBswGlnmIgoDYAeREdbRhtac[j];
			}
			if (USdmvQxDYxabMIPuOQXqCOZqqxulA && !dataUpdater.hasReceivedInput)
			{
				dataUpdater.hasReceivedInput = true;
			}
		}

		void IInputManagerJoystick.FillData(ControllerDataUpdater dataUpdater)
		{
			//ILSpy generated this explicit interface implementation from .override directive in FillData
			this.FillData(dataUpdater);
		}

		public BridgedControllerHWInfo qCnuPrkQjePBlHoVuwVhowEXhgIE()
		{
			BridgedControllerHWInfo bridgedControllerHWInfo = new BridgedControllerHWInfo();
			wlBrDsNvTfsLkhWZBgYdjZmclZDO(bridgedControllerHWInfo);
			return bridgedControllerHWInfo;
		}

		[CustomObfuscation(rename = false)]
		public BridgedController ToBridgedController()
		{
			BridgedController bridgedController = new BridgedController();
			TWrJiUtkMJHelHmkooXpMpciIMKhA(bridgedController);
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
			return new ControllerDisconnectedEventArgs(AvhcyDHgFqKZaqtSKqxdGeyqmsulA);
		}

		ControllerDisconnectedEventArgs IInputManagerJoystick.ToControllerDisconnectedEventArgs()
		{
			//ILSpy generated this explicit interface implementation from .override directive in ToControllerDisconnectedEventArgs
			return this.ToControllerDisconnectedEventArgs();
		}

		private void xCcMajnCRiQXzoFRSZkyibrSiLht()
		{
			if (mFKBGosAemYkqpiMHzApAAgPvOGt == null || !koOWFHzyOEbnQdPKCvVUSfBTwOZM(bCmkcsFvCcAVyQUFvmznhNAPsUCK.Synchronous))
			{
				return;
			}
			try
			{
				baPXnNrTTGlZTTZGQxyKyhlqcCGm();
				OoyeOgEaXDemhJzDXAyWLlBqTfCTA ooyeOgEaXDemhJzDXAyWLlBqTfCTA = mFKBGosAemYkqpiMHzApAAgPvOGt.IIQkJXcSDiDmPtCKIvdJqLpNIWsHA.QOeAcQCgliPrgXvdENyhZVUBDJff(liDOKlvrxtESUNNgdekFnKBWUPUW.Any);
				uoOKYBuXpwjKxGyVaNXugloEVIUq = ooyeOgEaXDemhJzDXAyWLlBqTfCTA.zMhyDnmNoJUdoJFqQauXlTqxBKak;
				JdvsyMzBLFVKfinmKzjidanpvtlr = (XInputDeviceSubType)ooyeOgEaXDemhJzDXAyWLlBqTfCTA.CZIEkLbWIghXoMhjFSEJQuaJFNjeb;
				if (mFKBGosAemYkqpiMHzApAAgPvOGt.IIQkJXcSDiDmPtCKIvdJqLpNIWsHA.UwMsOMMJppZpmQRLAvzhISJaobJD(default).TnuwHzdSUgRZRzmxOawsHWvBtzlT())
				{
					oCjAkdMFcuILjArDRdMXUoWQMeGwA = true;
				}
				rLBAnqRqZNUYUoURyvYJdyTMAxtp = (ooyeOgEaXDemhJzDXAyWLlBqTfCTA.FoPYlDlRNMphMcpTwdbdTBkTxGbj & yarCqZZdsTYKudUWjKmnkqrpdjZf.VoiceSupported) == yarCqZZdsTYKudUWjKmnkqrpdjZf.VoiceSupported;
				REWVDypnWFNONBUOgIAgKrIeeqrI();
				maMpZxxNiqoOVukIODoTqaEHgUfp = QzsqGxMRVksVHiYbznTNvRTfWexI.hardwareMapIdentifier.guid;
				if (hnIMUsPausDHfdozWgOaegNuZkmNA)
				{
					rpuDXXeAmxYWwPqUBmuixjPyQgZfA = StringTools.AddSpacesToCamelCase(JdvsyMzBLFVKfinmKzjidanpvtlr.ToString());
				}
				else
				{
					rpuDXXeAmxYWwPqUBmuixjPyQgZfA = "XInput " + JdvsyMzBLFVKfinmKzjidanpvtlr;
				}
				hMVUQNDhyvYrWrXqUZNujNXGsRDg = $"{rpuDXXeAmxYWwPqUBmuixjPyQgZfA} {(rDgWfmtQYwhHMKlDsolBmVCtYieJ + 1).ToString()}";
				string additionalIdentifyingInformation = LocalizationManager.FormatKey(JdvsyMzBLFVKfinmKzjidanpvtlr.ToString());
				QzsqGxMRVksVHiYbznTNvRTfWexI.deviceLocalizationInfo.additionalIdentifyingInformation = additionalIdentifyingInformation;
				fiqcOnFJjYvZASQrYVvzoAUqztbAA.Clear();
				mFKBGosAemYkqpiMHzApAAgPvOGt.AXrtbShIyLyWkdWaxMdcqvwSPSaJ();
				rpHyANJTpZyIwqMiREJIZayaeZMC = MiscTools.CreateGuidHashSHA1(string.Concat(uoOKYBuXpwjKxGyVaNXugloEVIUq, JdvsyMzBLFVKfinmKzjidanpvtlr, rDgWfmtQYwhHMKlDsolBmVCtYieJ));
				uVYMFuWMXHcbSnyKDXesbexNfsSb = true;
			}
			catch (Exception)
			{
				uVYMFuWMXHcbSnyKDXesbexNfsSb = false;
				UCsGfPBywJDdEUDJnpXycQJuvfShA = false;
				rpHyANJTpZyIwqMiREJIZayaeZMC = Guid.Empty;
			}
		}

		private bool OjHDgwLYKRNLesOsoTTfkIINlJjp()
		{
			try
			{
				if (JdvsyMzBLFVKfinmKzjidanpvtlr != (XInputDeviceSubType)mFKBGosAemYkqpiMHzApAAgPvOGt.IIQkJXcSDiDmPtCKIvdJqLpNIWsHA.QOeAcQCgliPrgXvdENyhZVUBDJff(liDOKlvrxtESUNNgdekFnKBWUPUW.Any).CZIEkLbWIghXoMhjFSEJQuaJFNjeb)
				{
					return true;
				}
			}
			catch
			{
			}
			return false;
		}

		private void baPXnNrTTGlZTTZGQxyKyhlqcCGm()
		{
			rLBAnqRqZNUYUoURyvYJdyTMAxtp = false;
			oCjAkdMFcuILjArDRdMXUoWQMeGwA = false;
			iSUnsiQLochUsDVDrlpEiGZHCzWr = false;
			uVYMFuWMXHcbSnyKDXesbexNfsSb = false;
		}

		private void DCyHoSoAZAxfeLVFmjjbMaFTMVuH()
		{
			if (aKVYWNZwKkPekRZVrsDNKiCmffDC != null)
			{
				aKVYWNZwKkPekRZVrsDNKiCmffDC();
			}
			mFKBGosAemYkqpiMHzApAAgPvOGt.aBMZecBxjbElXxhesIWIvoeqAwbEA();
		}

		private void bdrijuBDsxwISkbEOSugsvogxsBp(bool[] P_0, ref hYyFCqkVkEvJcLockdleIRkAceWCB P_1)
		{
			HardwareJoystickMap.Platform_XInput_Base.Axis[] axes_orig = ((HardwareJoystickMap.Platform_XInput_Base)QzsqGxMRVksVHiYbznTNvRTfWexI.map).Axes_orig;
			if (axes_orig == null)
			{
				return;
			}
			for (int i = 0; i < axes_orig.Length; i++)
			{
				if (i >= FVsMlAkcnbTtPNkPDwBxPHDXUAVi)
				{
					throw new Exception("Number of axes in hardware map does not match number of axes found in controller!");
				}
				mXFnihSCgZaTwHFgeDOHqvUuIovgA[i] = BkgcxpoWWaIgZdpwQeSPBwdLPOb(axes_orig[i], P_0, ref P_1);
				if (!USdmvQxDYxabMIPuOQXqCOZqqxulA && mXFnihSCgZaTwHFgeDOHqvUuIovgA[i] != 0f)
				{
					USdmvQxDYxabMIPuOQXqCOZqqxulA = true;
				}
			}
		}

		private void PGseTZwfYQxDNjbadDWXYpiVLOn(bool[] P_0, ref hYyFCqkVkEvJcLockdleIRkAceWCB P_1)
		{
			HardwareJoystickMap.Platform_XInput_Base.Button[] buttons_orig = ((HardwareJoystickMap.Platform_XInput_Base)QzsqGxMRVksVHiYbznTNvRTfWexI.map).Buttons_orig;
			if (buttons_orig == null)
			{
				return;
			}
			for (int i = 0; i < buttons_orig.Length; i++)
			{
				if (i >= AnToBLUDgZLKreKbADjgACsfrDJv)
				{
					throw new Exception("Number of buttons in hardware map does not match number of buttons found in controller!");
				}
				eFtHkUBswGlnmIgoDYAeREdbRhtac[i] = pygPwEFHNnrscBBIVkHezEDDJOgb(buttons_orig[i], P_0, ref P_1);
				if (!USdmvQxDYxabMIPuOQXqCOZqqxulA && eFtHkUBswGlnmIgoDYAeREdbRhtac[i])
				{
					USdmvQxDYxabMIPuOQXqCOZqqxulA = true;
				}
			}
		}

		private float BkgcxpoWWaIgZdpwQeSPBwdLPOb(HardwareJoystickMap.Platform_XInput_Base.Axis P_0, bool[] P_1, ref hYyFCqkVkEvJcLockdleIRkAceWCB P_2)
		{
			if (P_0.sourceType == HardwareElementSourceType.Axis)
			{
				if (P_0.sourceAxis == XInputAxis.None)
				{
					return 0f;
				}
				return nOkmNKBBVOmmAYKpcemnSmNEUKOt(P_0.sourceAxis, ref P_2);
			}
			if (P_0.sourceType == HardwareElementSourceType.Button)
			{
				if (P_0.sourceButton == XInputButton.None)
				{
					return 0f;
				}
				if (!BaGvfAFTzQbeaGWPHfxkKTskcdyI(P_0.sourceButton, P_1))
				{
					return 0f;
				}
				if (P_0.buttonAxisContribution == Pole.Positive)
				{
					return 1f;
				}
				return -1f;
			}
			return 0f;
		}

		private float nOkmNKBBVOmmAYKpcemnSmNEUKOt(XInputAxis P_0, ref hYyFCqkVkEvJcLockdleIRkAceWCB P_1)
		{
			return P_0 switch
			{
				XInputAxis.LeftThumbX => mYfrdbcireBcNJFrWedHlySfZSdOA.dgcxklUzVSWHTLBnmABQRATdpamN(P_1.MBfFFyhMBhdCKMUZmgZjznvsSsGcA), 
				XInputAxis.LeftThumbY => mYfrdbcireBcNJFrWedHlySfZSdOA.dgcxklUzVSWHTLBnmABQRATdpamN(P_1.dGsMSiIzBdsRNreqSJtiEHBNkifj), 
				XInputAxis.RightThumbX => mYfrdbcireBcNJFrWedHlySfZSdOA.dgcxklUzVSWHTLBnmABQRATdpamN(P_1.MPmfEOjCaCXvdSbDqsHifmDhlBKtB), 
				XInputAxis.RightThumbY => mYfrdbcireBcNJFrWedHlySfZSdOA.dgcxklUzVSWHTLBnmABQRATdpamN(P_1.ihvAireSCpqdlgrQDjwdiSGTPJRA), 
				XInputAxis.LeftTrigger => mYfrdbcireBcNJFrWedHlySfZSdOA.YkuGFwfXoDVtGJiAwScUjmMhydkMA(P_1.SPPVcsAqMytPoSJdVdzcGxHRjHxX), 
				XInputAxis.RightTrigger => mYfrdbcireBcNJFrWedHlySfZSdOA.YkuGFwfXoDVtGJiAwScUjmMhydkMA(P_1.HfsiepIQddOtqokzWvIKlzhuAlaxA), 
				_ => 0f, 
			};
		}

		private bool pygPwEFHNnrscBBIVkHezEDDJOgb(HardwareJoystickMap.Platform_XInput_Base.Button P_0, bool[] P_1, ref hYyFCqkVkEvJcLockdleIRkAceWCB P_2)
		{
			if (P_0.sourceType == HardwareElementSourceType.Button)
			{
				if (P_0.sourceButton == XInputButton.None)
				{
					return false;
				}
				return BaGvfAFTzQbeaGWPHfxkKTskcdyI(P_0.sourceButton, P_1);
			}
			if (P_0.sourceType == HardwareElementSourceType.Axis)
			{
				if (P_0.sourceAxis == XInputAxis.None)
				{
					return false;
				}
				float num = nOkmNKBBVOmmAYKpcemnSmNEUKOt(P_0.sourceAxis, ref P_2);
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
			return false;
		}

		private bool BaGvfAFTzQbeaGWPHfxkKTskcdyI(XInputButton P_0, bool[] P_1)
		{
			return P_0 switch
			{
				XInputButton.DPadUp => P_1[0], 
				XInputButton.DPadDown => P_1[1], 
				XInputButton.DPadLeft => P_1[2], 
				XInputButton.DPadRight => P_1[3], 
				XInputButton.Start => P_1[4], 
				XInputButton.Back => P_1[5], 
				XInputButton.LeftThumb => P_1[6], 
				XInputButton.RightThumb => P_1[7], 
				XInputButton.LeftShoulder => P_1[8], 
				XInputButton.RightShoulder => P_1[9], 
				XInputButton.Guide => P_1[10], 
				XInputButton.A => P_1[11], 
				XInputButton.B => P_1[12], 
				XInputButton.X => P_1[13], 
				XInputButton.Y => P_1[14], 
				_ => false, 
			};
		}

		private void REWVDypnWFNONBUOgIAgKrIeeqrI()
		{
			QzsqGxMRVksVHiYbznTNvRTfWexI = LywOMeJClRIrnjunATjwwFHapJrC(qCnuPrkQjePBlHoVuwVhowEXhgIE());
			if (QzsqGxMRVksVHiYbznTNvRTfWexI == null)
			{
				Rewired.Logger.LogError("Default hardware map not found!");
				return;
			}
			FVsMlAkcnbTtPNkPDwBxPHDXUAVi = QzsqGxMRVksVHiYbznTNvRTfWexI.axisCount;
			AnToBLUDgZLKreKbADjgACsfrDJv = QzsqGxMRVksVHiYbznTNvRTfWexI.buttonCount;
		}

		private bool lExrsNTbredmiTklcQKpqztGmBDx(ref EyvMMeJLDLfFqGCRzsLskiZBoyQp P_0)
		{
			if (P_0.WFnGBEMPjxHezJReSeTyKKgyQIJBA > 0 || P_0.NPJfEOEObhfvhvffkyHzRvUQXcGvA > 0)
			{
				return true;
			}
			return false;
		}

		private void FrNfQffrprEVFnVrPqsPRabvRlaU(ref EyvMMeJLDLfFqGCRzsLskiZBoyQp P_0)
		{
			P_0.WFnGBEMPjxHezJReSeTyKKgyQIJBA = 0;
			P_0.NPJfEOEObhfvhvffkyHzRvUQXcGvA = 0;
		}

		private void kiRYYfaoiHqByxGRpJeblYbxotIp(ref EyvMMeJLDLfFqGCRzsLskiZBoyQp P_0, ref EyvMMeJLDLfFqGCRzsLskiZBoyQp P_1)
		{
			P_1.WFnGBEMPjxHezJReSeTyKKgyQIJBA = P_0.WFnGBEMPjxHezJReSeTyKKgyQIJBA;
			P_1.NPJfEOEObhfvhvffkyHzRvUQXcGvA = P_0.NPJfEOEObhfvhvffkyHzRvUQXcGvA;
		}

		private string COBCOzrNeLUSYHdtoOtwwKpeTDmO()
		{
			return InputTools.FormatHardwareIdentifierString($"{ReInput.currentPlatform.ToString()}{InputSource.XInput.ToString()}{uoOKYBuXpwjKxGyVaNXugloEVIUq.ToString()}{JdvsyMzBLFVKfinmKzjidanpvtlr.ToString()}");
		}

		private void wlBrDsNvTfsLkhWZBgYdjZmclZDO(BridgedControllerHWInfo P_0)
		{
			P_0.inputManagerSource = InputSource.XInput;
			P_0.inputSource = P_0.inputManagerSource;
			P_0.deviceType = ControlDeviceType.Unknown;
			P_0.hardwareIdentifier = COBCOzrNeLUSYHdtoOtwwKpeTDmO();
			P_0.hardwareAxisCount = xAJreYomUOyTjihkShULTWHctdRq;
			P_0.hardwareButtonCount = oxXsNzLtgvTADQBaPcnRBTLLXrnQ;
			P_0.hardwareHatCount = 0;
			P_0.hw_productName = FTyhzyPtsgPKyqoEYdWYVWdxgVFO();
			P_0.hw_supportsVoice = rLBAnqRqZNUYUoURyvYJdyTMAxtp;
			P_0.hw_supportsVibration = oCjAkdMFcuILjArDRdMXUoWQMeGwA;
			P_0.hw_localVibrationMotorCount = (oCjAkdMFcuILjArDRdMXUoWQMeGwA ? 2 : 0);
			P_0.hw_xInputSubType = JdvsyMzBLFVKfinmKzjidanpvtlr;
		}

		private void TWrJiUtkMJHelHmkooXpMpciIMKhA(BridgedController P_0)
		{
			wlBrDsNvTfsLkhWZBgYdjZmclZDO(P_0);
			P_0.sourceJoystick = this;
			P_0.gameHardwareMap = QzsqGxMRVksVHiYbznTNvRTfWexI.ToGameHardwareControllerMap();
			P_0.instanceName = "XInput " + IEcEPkemfwJfqFJKgTwJIlniWBBA();
			P_0.productName = "XInput " + FTyhzyPtsgPKyqoEYdWYVWdxgVFO();
			P_0.isXInputDevice = true;
			P_0.axisCount = FVsMlAkcnbTtPNkPDwBxPHDXUAVi;
			P_0.buttonCount = AnToBLUDgZLKreKbADjgACsfrDJv;
			P_0.controllerTypeGuid = maMpZxxNiqoOVukIODoTqaEHgUfp;
			P_0.controllerExtension = get_extension();
		}

		public void Dispose()
		{
			vFcFkPhGtpCwVdfAFaNLYwNBinkrA(true);
			GC.SuppressFinalize(this);
		}

		void IDisposable.Dispose()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Dispose
			this.Dispose();
		}

		protected virtual void mIReafRTXsbOxRpfyrYgpLTdkKEc()
		{
			try
			{
				vFcFkPhGtpCwVdfAFaNLYwNBinkrA(false);
			}
			finally
			{
				base.Finalize();
			}
		}

		protected virtual void vFcFkPhGtpCwVdfAFaNLYwNBinkrA(bool P_0)
		{
			if (moVupBnHSiMuxrwRxyuXxIUlGfGm)
			{
				return;
			}
			if (P_0)
			{
				if (GUujVoQhDxDGoqOhXupKaJOWRjtJ())
				{
					mFKBGosAemYkqpiMHzApAAgPvOGt.WFSimFODJEjlWBivqRubwWOKpePC();
				}
				if (mFKBGosAemYkqpiMHzApAAgPvOGt != null)
				{
					mFKBGosAemYkqpiMHzApAAgPvOGt.Dispose();
				}
			}
			moVupBnHSiMuxrwRxyuXxIUlGfGm = true;
		}
	}

	private class uVjVfKRpeAKAvolZTGywVAQXfSAZ
	{
		private class WKUcrTqddtilrokPNemFHQxHemytA
		{
			public bool GcvLWLtzYHNUOPmCAtuXNuouIDIe;

			public int rVkceNciuRhQNgbHWbwlfIeyiTeZ;

			public XInputDeviceSubType sLtxMWLYThpSfwhjDbxsfkidoKps;

			public void ZWApssqyYkYjzizzWakUukOCjjhJ(gFyYDvnzMpDQpRdqCVRzJQTUBTLG P_0, bool P_1)
			{
				GcvLWLtzYHNUOPmCAtuXNuouIDIe = P_1;
				rVkceNciuRhQNgbHWbwlfIeyiTeZ = P_0.get_rewiredId();
				sLtxMWLYThpSfwhjDbxsfkidoKps = P_0.JdvsyMzBLFVKfinmKzjidanpvtlr;
			}

			public WKUcrTqddtilrokPNemFHQxHemytA(int P_0, XInputDeviceSubType P_1)
			{
				rVkceNciuRhQNgbHWbwlfIeyiTeZ = P_0;
				sLtxMWLYThpSfwhjDbxsfkidoKps = P_1;
			}
		}

		private List<WKUcrTqddtilrokPNemFHQxHemytA> sSBNNLstJONuIaKxZHoyroNvXUxm;

		public uVjVfKRpeAKAvolZTGywVAQXfSAZ()
		{
			sSBNNLstJONuIaKxZHoyroNvXUxm = new List<WKUcrTqddtilrokPNemFHQxHemytA>();
		}

		public void ZeOeiCCTfuYYdDVpGfxKXvwHCSAB(gFyYDvnzMpDQpRdqCVRzJQTUBTLG P_0, bool P_1)
		{
			if (xNjXNPojlzUiTdPCjAkSjGjVrrYD(P_0.get_rewiredId(), P_0.JdvsyMzBLFVKfinmKzjidanpvtlr, true) < 0)
			{
				WKUcrTqddtilrokPNemFHQxHemytA wKUcrTqddtilrokPNemFHQxHemytA = new WKUcrTqddtilrokPNemFHQxHemytA(P_0.get_rewiredId(), P_0.JdvsyMzBLFVKfinmKzjidanpvtlr);
				wKUcrTqddtilrokPNemFHQxHemytA.GcvLWLtzYHNUOPmCAtuXNuouIDIe = P_1;
				sSBNNLstJONuIaKxZHoyroNvXUxm.Add(wKUcrTqddtilrokPNemFHQxHemytA);
			}
		}

		public void KPFtxMWYuVlFsYPcxXrNnmABDUtF(int P_0, gFyYDvnzMpDQpRdqCVRzJQTUBTLG P_1, bool P_2)
		{
			if (P_0 >= 0 && P_0 < sSBNNLstJONuIaKxZHoyroNvXUxm.Count)
			{
				sSBNNLstJONuIaKxZHoyroNvXUxm[P_0].ZWApssqyYkYjzizzWakUukOCjjhJ(P_1, P_2);
			}
		}

		public int mjWqEfhNHPUdQadKePgBqHFKtvJi(XInputDeviceSubType P_0, bool P_1)
		{
			int count = sSBNNLstJONuIaKxZHoyroNvXUxm.Count;
			for (int i = 0; i < count; i++)
			{
				if ((P_1 || !sSBNNLstJONuIaKxZHoyroNvXUxm[i].GcvLWLtzYHNUOPmCAtuXNuouIDIe) && sSBNNLstJONuIaKxZHoyroNvXUxm[i].sLtxMWLYThpSfwhjDbxsfkidoKps == P_0)
				{
					return i;
				}
			}
			return -1;
		}

		public int xNjXNPojlzUiTdPCjAkSjGjVrrYD(int P_0, XInputDeviceSubType P_1, bool P_2)
		{
			int count = sSBNNLstJONuIaKxZHoyroNvXUxm.Count;
			for (int i = 0; i < count; i++)
			{
				if ((P_2 || !sSBNNLstJONuIaKxZHoyroNvXUxm[i].GcvLWLtzYHNUOPmCAtuXNuouIDIe) && sSBNNLstJONuIaKxZHoyroNvXUxm[i].rVkceNciuRhQNgbHWbwlfIeyiTeZ == P_0 && sSBNNLstJONuIaKxZHoyroNvXUxm[i].sLtxMWLYThpSfwhjDbxsfkidoKps == P_1)
				{
					return i;
				}
			}
			return -1;
		}

		public int mGfNfreyvNAmMQjVjcmdFhXmrTdoA(int P_0)
		{
			if (P_0 < 0 || P_0 >= sSBNNLstJONuIaKxZHoyroNvXUxm.Count)
			{
				throw new ArgumentOutOfRangeException();
			}
			return sSBNNLstJONuIaKxZHoyroNvXUxm[P_0].rVkceNciuRhQNgbHWbwlfIeyiTeZ;
		}

		public void jUITJfJFqWBDZBWfLOwyEXnlcNeeb(int P_0, bool P_1)
		{
			if (P_0 >= 0 && P_0 < sSBNNLstJONuIaKxZHoyroNvXUxm.Count)
			{
				sSBNNLstJONuIaKxZHoyroNvXUxm[P_0].GcvLWLtzYHNUOPmCAtuXNuouIDIe = P_1;
			}
		}
	}

	private class SGhbtxKOBOHbBucTSldBsMcZuTKH
	{
		public bool keRcaGzjlISRKgWfKUrnfugConci;

		private double ejJBEgtaggfOLgQEsiSrJdTzSxAi;

		public float BhMFckXGLTTQIgoKxtjvXJPOfOwT;

		public SGhbtxKOBOHbBucTSldBsMcZuTKH()
		{
		}

		public SGhbtxKOBOHbBucTSldBsMcZuTKH(float P_0)
		{
			BhMFckXGLTTQIgoKxtjvXJPOfOwT = P_0;
		}

		public void RDUQcxVIUEzPtoXojbWqhOzXcHW()
		{
			keRcaGzjlISRKgWfKUrnfugConci = true;
			ejJBEgtaggfOLgQEsiSrJdTzSxAi = (double)BhMFckXGLTTQIgoKxtjvXJPOfOwT + ReInput.unscaledTime;
		}

		public void UgIhBgTTkWmrNoHHiyXUltgPNxFf(float P_0)
		{
			keRcaGzjlISRKgWfKUrnfugConci = true;
			BhMFckXGLTTQIgoKxtjvXJPOfOwT = P_0;
			ejJBEgtaggfOLgQEsiSrJdTzSxAi = (double)BhMFckXGLTTQIgoKxtjvXJPOfOwT + ReInput.unscaledTime;
		}

		public bool sUnHPNHUthqrvVNCeVtVwhlHpAdH()
		{
			if (!keRcaGzjlISRKgWfKUrnfugConci)
			{
				return false;
			}
			if (ReInput.unscaledTime >= ejJBEgtaggfOLgQEsiSrJdTzSxAi)
			{
				keRcaGzjlISRKgWfKUrnfugConci = false;
				return true;
			}
			return false;
		}

		public void vZWcuVCPRakUhcNwxCphxYRgYSJEA()
		{
			keRcaGzjlISRKgWfKUrnfugConci = false;
			ejJBEgtaggfOLgQEsiSrJdTzSxAi = 0.0;
		}

		public void HABOrFmqtpavetsTqIKOrPZeVwEQ(float P_0)
		{
			BhMFckXGLTTQIgoKxtjvXJPOfOwT = P_0;
		}

		public SGhbtxKOBOHbBucTSldBsMcZuTKH GOagGacMzZJlYAIcFCuWzzvPFFEWb()
		{
			return (SGhbtxKOBOHbBucTSldBsMcZuTKH)MemberwiseClone();
		}
	}

	public class mYfrdbcireBcNJFrWedHlySfZSdOA : IDisposable
	{
		public readonly zSemIiGfKoAsdCxlcxZOJaEAArel IIQkJXcSDiDmPtCKIvdJqLpNIWsHA;

		private readonly Controller.Extension WryjPuClfGNYNIsUWXjOcQCZrMGm;

		public hYyFCqkVkEvJcLockdleIRkAceWCB qOIaQPjTafimqmQrkpRkwGHPOyVk;

		private bool WTFbRmusupsLyYEqEcSFjaSdrachA;

		private readonly ButtonLoopSet tEjMvRVSkhaWWUaNwMojkuSvMBtX;

		private hYyFCqkVkEvJcLockdleIRkAceWCB hMBrDObxerOqWRHvLdlpbKlYNczE;

		private bool dpSAHGrzzgKbkbDWkReSGXhDdlvp;

		private DualThreadLowLevelInputEventQueue MDebNuNXwxvQsBrouUastceWtEmE;

		private readonly object aKbsSwQpHXRbZYxspbslLCqxlUPs;

		private RingBuffer<EyvMMeJLDLfFqGCRzsLskiZBoyQp> jJwmEwsGgULqxYpregvRaAUQGLObA = new RingBuffer<EyvMMeJLDLfFqGCRzsLskiZBoyQp>(5);

		private RingBuffer<EyvMMeJLDLfFqGCRzsLskiZBoyQp> JnxPxALEmjMVjfWIfZffOwdRemE = new RingBuffer<EyvMMeJLDLfFqGCRzsLskiZBoyQp>(5);

		private readonly object FyvEegtoHPWMNqtpadSVBmHPRLfb = new object();

		private readonly object isVHaNVHvooZUrBXHrXeOfMPNLrw = new object();

		private EyvMMeJLDLfFqGCRzsLskiZBoyQp WKpfoWuKoPnwHYSKMJtRLJFGFTFH;

		private double ANpAkcJhnbIdOFTAXhGTnQBWaOej;

		private bool vFWgPEYKzVBduqGneBPUAbDMOaPab;

		public Controller.Extension dQOhceuhSGRtmIFXOLXOuDRFEzku => velbXRVvMACnZLSsoyQATJzQgIqF();

		public bool[] oVkfLoZuiWZgkvXQcCIgMWACwodj => ozmoHLGyyMYriQdodJbioMkCxNWQ();

		public Controller.Extension velbXRVvMACnZLSsoyQATJzQgIqF()
		{
			return WryjPuClfGNYNIsUWXjOcQCZrMGm;
		}

		public bool[] ozmoHLGyyMYriQdodJbioMkCxNWQ()
		{
			return tEjMvRVSkhaWWUaNwMojkuSvMBtX.Current.effectiveValue;
		}

		public mYfrdbcireBcNJFrWedHlySfZSdOA(int P_0, UpdateLoopSetting P_1)
		{
			IIQkJXcSDiDmPtCKIvdJqLpNIWsHA = new zSemIiGfKoAsdCxlcxZOJaEAArel((NFuGZkvTxCExBhUKPPIGcGnAREeLA)P_0);
			tEjMvRVSkhaWWUaNwMojkuSvMBtX = new ButtonLoopSet(P_1, 15);
			aKbsSwQpHXRbZYxspbslLCqxlUPs = new object();
			MDebNuNXwxvQsBrouUastceWtEmE = new DualThreadLowLevelInputEventQueue((int)((float)hmRdjlkkAraUbAOZelrfFnsoEfpCB.HdYjuOcsUBMbxACBttaMRLoAARlu() * 0.25f), 15, 6, 0);
			WryjPuClfGNYNIsUWXjOcQCZrMGm = new XInputControllerExtension(this);
		}

		public void QnHFVTlNpeaUseGMZtBbHFHVmkYM()
		{
			tEjMvRVSkhaWWUaNwMojkuSvMBtX.SetUpdateLoop(ReInput.currentUpdateLoop);
			hCyZmNlktDewgVRJXOstrDFdGyBP(ref qOIaQPjTafimqmQrkpRkwGHPOyVk);
		}

		public void fVSTOKYCyDgucRDhbfJTfRWoSonz()
		{
			KiHeZraKkfAXduvXIhAfdFcrGkLeb();
			tEjMvRVSkhaWWUaNwMojkuSvMBtX.Current.ClearWasTrueThisFrame();
		}

		public void AXrtbShIyLyWkdWaxMdcqvwSPSaJ()
		{
			OZYnbUhAQDXkOIptwueJXHvwWZVs();
			WTFbRmusupsLyYEqEcSFjaSdrachA = true;
			dpSAHGrzzgKbkbDWkReSGXhDdlvp = IIQkJXcSDiDmPtCKIvdJqLpNIWsHA.elsudCwfzAdctgGqPDhrSXPmTyEh();
		}

		public void aBMZecBxjbElXxhesIWIvoeqAwbEA()
		{
			WTFbRmusupsLyYEqEcSFjaSdrachA = false;
			dpSAHGrzzgKbkbDWkReSGXhDdlvp = false;
			OZYnbUhAQDXkOIptwueJXHvwWZVs();
		}

		public bool hQuAHmSbwrpBtgAUHGzUgsoIpDBJA(bCmkcsFvCcAVyQUFvmznhNAPsUCK P_0)
		{
			return P_0 switch
			{
				bCmkcsFvCcAVyQUFvmznhNAPsUCK.Synchronous => dpSAHGrzzgKbkbDWkReSGXhDdlvp = IIQkJXcSDiDmPtCKIvdJqLpNIWsHA.elsudCwfzAdctgGqPDhrSXPmTyEh(), 
				bCmkcsFvCcAVyQUFvmznhNAPsUCK.Asynchronous => dpSAHGrzzgKbkbDWkReSGXhDdlvp, 
				_ => throw new NotImplementedException(), 
			};
		}

		public void JPtkqRUPCLknWsgzGaqsDigagnOTA(float P_0, int P_1)
		{
			switch (P_1)
			{
			case 0:
				WKpfoWuKoPnwHYSKMJtRLJFGFTFH.WFnGBEMPjxHezJReSeTyKKgyQIJBA = (ushort)(MathTools.Clamp01(P_0) * 65535f);
				break;
			case 1:
				WKpfoWuKoPnwHYSKMJtRLJFGFTFH.NPJfEOEObhfvhvffkyHzRvUQXcGvA = (ushort)(MathTools.Clamp01(P_0) * 65535f);
				break;
			}
			uCOiLwqJIHNXzxXBKHlkzhSTayed();
		}

		public void NUZZLsblGkUdPANMIURxSmLMdNvW()
		{
			WKpfoWuKoPnwHYSKMJtRLJFGFTFH.WFnGBEMPjxHezJReSeTyKKgyQIJBA = 0;
			WKpfoWuKoPnwHYSKMJtRLJFGFTFH.NPJfEOEObhfvhvffkyHzRvUQXcGvA = 0;
			uCOiLwqJIHNXzxXBKHlkzhSTayed();
		}

		public void WFSimFODJEjlWBivqRubwWOKpePC()
		{
			WKpfoWuKoPnwHYSKMJtRLJFGFTFH.WFnGBEMPjxHezJReSeTyKKgyQIJBA = 0;
			WKpfoWuKoPnwHYSKMJtRLJFGFTFH.NPJfEOEObhfvhvffkyHzRvUQXcGvA = 0;
			lock (isVHaNVHvooZUrBXHrXeOfMPNLrw)
			{
				lock (FyvEegtoHPWMNqtpadSVBmHPRLfb)
				{
					jJwmEwsGgULqxYpregvRaAUQGLObA.Clear();
					JnxPxALEmjMVjfWIfZffOwdRemE.Clear();
					loferYXKSmlNXWeoClEFWDrOyVge(IIQkJXcSDiDmPtCKIvdJqLpNIWsHA, WKpfoWuKoPnwHYSKMJtRLJFGFTFH, ref ANpAkcJhnbIdOFTAXhGTnQBWaOej);
				}
			}
		}

		public void BkZfFMdLluQMXGRUHZENKRLticggA()
		{
			if (!WTFbRmusupsLyYEqEcSFjaSdrachA || !dpSAHGrzzgKbkbDWkReSGXhDdlvp)
			{
				return;
			}
			RYLkkgImWyYdzAixxdcQbNKPqnGz rYLkkgImWyYdzAixxdcQbNKPqnGz;
			double realTime;
			try
			{
				if (!IIQkJXcSDiDmPtCKIvdJqLpNIWsHA.JitGnxjihUQvlzGMlRhBmDshETkCA(out rYLkkgImWyYdzAixxdcQbNKPqnGz))
				{
					dpSAHGrzzgKbkbDWkReSGXhDdlvp = false;
					return;
				}
				realTime = ReInput.realTime;
			}
			catch
			{
				dpSAHGrzzgKbkbDWkReSGXhDdlvp = false;
				return;
			}
			lock (aKbsSwQpHXRbZYxspbslLCqxlUPs)
			{
				if (!jtXaYPGtcLSizsXOLXiskThzrixQA(rYLkkgImWyYdzAixxdcQbNKPqnGz.dftovXwqzxBLXXHVLoflbFoOeJIk, hMBrDObxerOqWRHvLdlpbKlYNczE))
				{
					using (DualThreadLowLevelInputEventQueue.INewEventWrapper newEventWrapper = MDebNuNXwxvQsBrouUastceWtEmE.T_CreateEvent())
					{
						ZJWVgDshAwQweaxeQUiyLEFXRCJh(ref rYLkkgImWyYdzAixxdcQbNKPqnGz.dftovXwqzxBLXXHVLoflbFoOeJIk, realTime, newEventWrapper.Event);
					}
					hMBrDObxerOqWRHvLdlpbKlYNczE = rYLkkgImWyYdzAixxdcQbNKPqnGz.dftovXwqzxBLXXHVLoflbFoOeJIk;
				}
			}
		}

		public void PcRgSPWcGRjwxKZyefhyJPZlpfch()
		{
			if (!WTFbRmusupsLyYEqEcSFjaSdrachA || !dpSAHGrzzgKbkbDWkReSGXhDdlvp || ReInput.realTime < ANpAkcJhnbIdOFTAXhGTnQBWaOej + 0.009999999776482582)
			{
				return;
			}
			lock (isVHaNVHvooZUrBXHrXeOfMPNLrw)
			{
				lock (FyvEegtoHPWMNqtpadSVBmHPRLfb)
				{
					MiscTools.Swap(ref jJwmEwsGgULqxYpregvRaAUQGLObA, ref JnxPxALEmjMVjfWIfZffOwdRemE);
				}
				LgJCNvuSGfXUTtmFYvIYBoeVOZqN(JnxPxALEmjMVjfWIfZffOwdRemE, IIQkJXcSDiDmPtCKIvdJqLpNIWsHA, ref ANpAkcJhnbIdOFTAXhGTnQBWaOej);
			}
		}

		private void KiHeZraKkfAXduvXIhAfdFcrGkLeb()
		{
			PoEEutDPfxkaMnQMcuoiWCPTulsC();
		}

		private void PoEEutDPfxkaMnQMcuoiWCPTulsC()
		{
			if (!(ReInput.realTime < ANpAkcJhnbIdOFTAXhGTnQBWaOej + 1.5) && (!Mathf.Approximately((int)WKpfoWuKoPnwHYSKMJtRLJFGFTFH.WFnGBEMPjxHezJReSeTyKKgyQIJBA, 0f) || !Mathf.Approximately((int)WKpfoWuKoPnwHYSKMJtRLJFGFTFH.NPJfEOEObhfvhvffkyHzRvUQXcGvA, 0f)))
			{
				uCOiLwqJIHNXzxXBKHlkzhSTayed();
			}
		}

		private void uCOiLwqJIHNXzxXBKHlkzhSTayed()
		{
			lock (FyvEegtoHPWMNqtpadSVBmHPRLfb)
			{
				jJwmEwsGgULqxYpregvRaAUQGLObA.Enqueue(WKpfoWuKoPnwHYSKMJtRLJFGFTFH);
			}
		}

		private static void LgJCNvuSGfXUTtmFYvIYBoeVOZqN(RingBuffer<EyvMMeJLDLfFqGCRzsLskiZBoyQp> P_0, zSemIiGfKoAsdCxlcxZOJaEAArel P_1, ref double P_2)
		{
			if (P_0.Count > 0)
			{
				loferYXKSmlNXWeoClEFWDrOyVge(P_1, P_0[P_0.Count - 1], ref P_2);
				P_0.Clear();
			}
		}

		private static void loferYXKSmlNXWeoClEFWDrOyVge(zSemIiGfKoAsdCxlcxZOJaEAArel P_0, EyvMMeJLDLfFqGCRzsLskiZBoyQp P_1, ref double P_2)
		{
			try
			{
				P_0.UwMsOMMJppZpmQRLAvzhISJaobJD(P_1);
			}
			catch
			{
			}
			P_2 = ReInput.realTime;
		}

		private void hCyZmNlktDewgVRJXOstrDFdGyBP(ref hYyFCqkVkEvJcLockdleIRkAceWCB P_0)
		{
			while (MDebNuNXwxvQsBrouUastceWtEmE.ProcessNewEvents())
			{
				LHpLcTJJHNqMISfIaCEYAgxvNuJyA(ref P_0, ref MDebNuNXwxvQsBrouUastceWtEmE.currentEvent);
				for (int i = 0; i < 15; i++)
				{
					tEjMvRVSkhaWWUaNwMojkuSvMBtX.SetValue(i, BHPOLKIajfEqMHrtgAqdEcioxutz((int)P_0.eCnRaZanOxrIIOihwFNbFkwyCoDp, i), MDebNuNXwxvQsBrouUastceWtEmE.currentEvent.GetTimestamp());
				}
			}
		}

		private void ZJWVgDshAwQweaxeQUiyLEFXRCJh(ref hYyFCqkVkEvJcLockdleIRkAceWCB P_0, double P_1, LowLevelInputEvent P_2)
		{
			P_2.SetTimestamp(P_1);
			int eCnRaZanOxrIIOihwFNbFkwyCoDp = (int)P_0.eCnRaZanOxrIIOihwFNbFkwyCoDp;
			P_2.SetButtonsBitMask((eCnRaZanOxrIIOihwFNbFkwyCoDp & 0x7FF) | ((eCnRaZanOxrIIOihwFNbFkwyCoDp & (eCnRaZanOxrIIOihwFNbFkwyCoDp & -4096)) >> 1), 0);
			P_2.SetAxisValue(0, dgcxklUzVSWHTLBnmABQRATdpamN(P_0.MBfFFyhMBhdCKMUZmgZjznvsSsGcA));
			P_2.SetAxisValue(1, dgcxklUzVSWHTLBnmABQRATdpamN(P_0.dGsMSiIzBdsRNreqSJtiEHBNkifj));
			P_2.SetAxisValue(2, dgcxklUzVSWHTLBnmABQRATdpamN(P_0.MPmfEOjCaCXvdSbDqsHifmDhlBKtB));
			P_2.SetAxisValue(3, dgcxklUzVSWHTLBnmABQRATdpamN(P_0.ihvAireSCpqdlgrQDjwdiSGTPJRA));
			P_2.SetAxisValue(4, YkuGFwfXoDVtGJiAwScUjmMhydkMA(P_0.SPPVcsAqMytPoSJdVdzcGxHRjHxX));
			P_2.SetAxisValue(5, YkuGFwfXoDVtGJiAwScUjmMhydkMA(P_0.HfsiepIQddOtqokzWvIKlzhuAlaxA));
		}

		private void LHpLcTJJHNqMISfIaCEYAgxvNuJyA(ref hYyFCqkVkEvJcLockdleIRkAceWCB P_0, ref LowLevelInputEvent P_1)
		{
			int buttonsBitMask = P_1.GetButtonsBitMask(0);
			P_0.eCnRaZanOxrIIOihwFNbFkwyCoDp = (aLsOMTnnyUraQCGOYHMYijDusXPiA)((buttonsBitMask & 0x7FF) | ((buttonsBitMask & (buttonsBitMask & -2048)) << 1));
			P_0.MBfFFyhMBhdCKMUZmgZjznvsSsGcA = (short)(P_1.GetAxisValue(0) * 32768f);
			P_0.dGsMSiIzBdsRNreqSJtiEHBNkifj = (short)(P_1.GetAxisValue(1) * 32768f);
			P_0.MPmfEOjCaCXvdSbDqsHifmDhlBKtB = (short)(P_1.GetAxisValue(2) * 32768f);
			P_0.ihvAireSCpqdlgrQDjwdiSGTPJRA = (short)(P_1.GetAxisValue(3) * 32768f);
			P_0.SPPVcsAqMytPoSJdVdzcGxHRjHxX = (byte)(P_1.GetAxisValue(4) * 255f);
			P_0.HfsiepIQddOtqokzWvIKlzhuAlaxA = (byte)(P_1.GetAxisValue(5) * 255f);
		}

		private static bool BHPOLKIajfEqMHrtgAqdEcioxutz(int P_0, int P_1)
		{
			if (P_1 > 10)
			{
				P_1++;
			}
			return (P_0 & (1 << P_1)) != 0;
		}

		private void OZYnbUhAQDXkOIptwueJXHvwWZVs()
		{
			lock (aKbsSwQpHXRbZYxspbslLCqxlUPs)
			{
				qOIaQPjTafimqmQrkpRkwGHPOyVk = default;
				hMBrDObxerOqWRHvLdlpbKlYNczE = default;
				tEjMvRVSkhaWWUaNwMojkuSvMBtX.Clear();
				MDebNuNXwxvQsBrouUastceWtEmE.Clear();
			}
		}

		public void Dispose()
		{
			fZYpobRNgFwSvjeQvfLVSBgWbLfJ(true);
			GC.SuppressFinalize(this);
		}

		void IDisposable.Dispose()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Dispose
			this.Dispose();
		}

		protected virtual void IlGOhxUKpIsHnmGrYYgqUJgicXeeA()
		{
			try
			{
				fZYpobRNgFwSvjeQvfLVSBgWbLfJ(false);
			}
			finally
			{
				base.Finalize();
			}
		}

		protected virtual void fZYpobRNgFwSvjeQvfLVSBgWbLfJ(bool P_0)
		{
			if (!vFWgPEYKzVBduqGneBPUAbDMOaPab)
			{
				if (P_0)
				{
					MDebNuNXwxvQsBrouUastceWtEmE.Dispose();
				}
				vFWgPEYKzVBduqGneBPUAbDMOaPab = true;
			}
		}

		public static float dgcxklUzVSWHTLBnmABQRATdpamN(int P_0)
		{
			if (P_0 == 0)
			{
				return 0f;
			}
			return MathTools.Clamp((float)MathTools.Abs(P_0) / 32768f * (float)MathTools.Sign(P_0), -1f, 1f);
		}

		public static float YkuGFwfXoDVtGJiAwScUjmMhydkMA(int P_0)
		{
			if (P_0 == 0)
			{
				return 0f;
			}
			return MathTools.Clamp((float)MathTools.Abs(P_0) / 255f * (float)MathTools.Sign(P_0), -1f, 1f);
		}

		private static bool jtXaYPGtcLSizsXOLXiskThzrixQA(hYyFCqkVkEvJcLockdleIRkAceWCB P_0, hYyFCqkVkEvJcLockdleIRkAceWCB P_1)
		{
			if (P_0.eCnRaZanOxrIIOihwFNbFkwyCoDp == P_1.eCnRaZanOxrIIOihwFNbFkwyCoDp && P_0.SPPVcsAqMytPoSJdVdzcGxHRjHxX == P_1.SPPVcsAqMytPoSJdVdzcGxHRjHxX && P_0.HfsiepIQddOtqokzWvIKlzhuAlaxA == P_1.HfsiepIQddOtqokzWvIKlzhuAlaxA && P_0.MBfFFyhMBhdCKMUZmgZjznvsSsGcA == P_1.MBfFFyhMBhdCKMUZmgZjznvsSsGcA && P_0.dGsMSiIzBdsRNreqSJtiEHBNkifj == P_1.dGsMSiIzBdsRNreqSJtiEHBNkifj && P_0.MPmfEOjCaCXvdSbDqsHifmDhlBKtB == P_1.MPmfEOjCaCXvdSbDqsHifmDhlBKtB)
			{
				return P_0.ihvAireSCpqdlgrQDjwdiSGTPJRA == P_1.ihvAireSCpqdlgrQDjwdiSGTPJRA;
			}
			return false;
		}
	}

	public enum bCmkcsFvCcAVyQUFvmznhNAPsUCK
	{
		Synchronous = 0,
		Asynchronous = 1
	}

	public const int gXQsYztniqWLWDqdNHetvCUWKnSS = 4;

	public const int CKGvQopkWdcDZDuChFlyfdJaEMxE = 32768;

	public const int YDmhRYusfIXJXSTxdelFIjTiBGnJA = -32768;

	public const int XXKOUizFhtfltNnODlwJwMBRcAKO = 255;

	public const int wjznUGeeNiIJkpaHwAECExsTrvwNA = 0;

	public const int PVjvFFCjedAWUQGcajfOEqqLmsGOA = 18;

	public const int KhEBatsTJRcDJerAglSCtFxUtEwbA = 14;

	public const int ZHFgbgOzdMkDJxzadielQjdsSdnu = 6;

	public const int yXaedGgaMSPZmJChQkIDtWLREgIk = 15;

	private gFyYDvnzMpDQpRdqCVRzJQTUBTLG[] HNlEDIXHlBlqLuVoDxTyFUHQtMXH;

	private bool YqSlaXqkEFnLCCuROUrUubqzxjlH;

	private SGhbtxKOBOHbBucTSldBsMcZuTKH oNdczxozegJPaHdZdjREMboDWfQc;

	private uVjVfKRpeAKAvolZTGywVAQXfSAZ WGibpHdwJodcPBszAfwmZXlcdOJGb;

	private global::YmPrvkdvDmQKYqkyPerBWAzuraMJ<bool> WfZuwpTfvMSDaYJDVHjNMOikGfnaA;

	private bool[] ooxQOshQQwqleVsPPXHLVuajthrR;

	private bool[] gafyJWSkyQLiKRiSpZlwkamkiypQ;

	private bool MwHaCQtmCXIJIjhtaaojhQpEIyMe;

	private readonly bool PUWArbdQuicBvJGnxPFnlAptaaRU;

	private readonly UpdateLoopSetting qqKCZgIqhDoCohVchfPICCXCCXtr;

	private UpdateLoopType OPeMHVHYcpQIArIDIfULgAmBoRiuA;

	private UpdateLoopType XlaUvcLmFuciBNHlzDsQAPPfLQuBb;

	private Action<int, ControllerDataUpdater> YIdYiOhFPRigzSGFGFQbsDAMCjgp;

	private bool rsoCisrbUgEuuRuxYchKKCCybRYZ;

	private Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> TdgGXNbxHZLufOfMdCEtwDrLDjocb;

	private Func<int> spYcBfzXJPeKpCJkatuYNbgcMXWTA;

	private Func<PidVid, bool> xjVAXhavMIfiiMSuGkxrqThmMlaDA;

	private static Guid[] pKTCOZaTARDhPkCUQMAPVMoIwYlgA;

	private static string[] pQhmayYNXiIezuUXBxoFeNsZxIoC;

	private static string[] ofSNxNiVwRCCytTnaQwLgaBZJtnK;

	[CustomObfuscation(rename = false)]
	int PlatformInputManager.deviceCount => get_deviceCount();

	[CustomObfuscation(rename = false)]
	PlatformInputManager PlatformInputManager.primaryInputManager => get_primaryInputManager();

	[CustomObfuscation(rename = false)]
	IInputSource PlatformInputManager.inputSource => get_inputSource();

	[CustomObfuscation(rename = false)]
	InputSource PlatformInputManager.inputSourceType => get_inputSourceType();

	XAWRDcWKMfgkHrgJeYMwQTZapuvQ JqKNlvkcgJmKzUKsMOMqlPmWJSJT => Rewired_002EPlatforms_002EWindows_002EISecondaryInputSourceProvider_002Eget_secondaryInputSourceType();

	public fXHRBPluCVlFmVyDTJoQUtqLlMxB(bool P_0, UpdateLoopSetting P_1, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> P_2, Func<int> P_3, Func<PidVid, bool> P_4)
	{
		PUWArbdQuicBvJGnxPFnlAptaaRU = P_0;
		qqKCZgIqhDoCohVchfPICCXCCXtr = P_1;
		xjVAXhavMIfiiMSuGkxrqThmMlaDA = P_4;
		rsoCisrbUgEuuRuxYchKKCCybRYZ = true;
		try
		{
			if (!INUUMVsygJzZqjuBcRMooeqGdhAl.HGlfWckRvQkbtpTSfOfpfZmzBEHr(out var qWAIIjTCJtCOEBBTvOMHGNihXtLzA, out var text, out var _))
			{
				throw new Exception("XInput is not available.");
			}
			if (qWAIIjTCJtCOEBBTvOMHGNihXtLzA < QWAIIjTCJtCOEBBTvOMHGNihXtLzA.XINPUT_1_3)
			{
				Rewired.Logger.LogWarning("The version of XInput (" + text + ") detected on your system is out of date. Please update to the latest version of XInput. Input will still function, but all features may not be available. See the documentation for required dependencies.");
			}
			else
			{
				_ = 4;
			}
			TdgGXNbxHZLufOfMdCEtwDrLDjocb = P_2;
			spYcBfzXJPeKpCJkatuYNbgcMXWTA = P_3;
			MwHaCQtmCXIJIjhtaaojhQpEIyMe = UnityTools.platform == Platform.WindowsAppStore;
			using (TempListPool.TList<UpdateLoopType> tList = TempListPool.GetTList<UpdateLoopType>(3))
			{
				List<UpdateLoopType> list = tList.list;
				EnumConverter.ToUpdateLoopTypes(qqKCZgIqhDoCohVchfPICCXCCXtr, list);
				int num2 = 0;
				if (num2 < list.Count)
				{
					XlaUvcLmFuciBNHlzDsQAPPfLQuBb = list[num2];
				}
			}
			WfZuwpTfvMSDaYJDVHjNMOikGfnaA = new global::YmPrvkdvDmQKYqkyPerBWAzuraMJ<bool>(true, TjHxrPKkDaxXgboxJmgDRepfqyTE);
			ooxQOshQQwqleVsPPXHLVuajthrR = new bool[4];
			gafyJWSkyQLiKRiSpZlwkamkiypQ = new bool[4];
			YIdYiOhFPRigzSGFGFQbsDAMCjgp = UpdateControllerData;
			if (MwHaCQtmCXIJIjhtaaojhQpEIyMe)
			{
				nWiLFfUwriHDhpheyVtttMLshzTeA();
			}
		}
		catch (Exception)
		{
			OnDestroy();
			throw;
		}
	}

	public virtual int get_deviceCount()
	{
		int num = 0;
		for (int i = 0; i < 4; i++)
		{
			if (HNlEDIXHlBlqLuVoDxTyFUHQtMXH[i].GUujVoQhDxDGoqOhXupKaJOWRjtJ())
			{
				num++;
			}
		}
		return num;
	}

	public virtual PlatformInputManager get_primaryInputManager()
	{
		return this;
	}

	public virtual IInputSource get_inputSource()
	{
		return null;
	}

	public virtual InputSource get_inputSourceType()
	{
		return InputSource.XInput;
	}

	[CustomObfuscation(rename = false)]
	public override void Initialize()
	{
		if (rsoCisrbUgEuuRuxYchKKCCybRYZ)
		{
			oNdczxozegJPaHdZdjREMboDWfQc = new SGhbtxKOBOHbBucTSldBsMcZuTKH(1f);
		}
		WGibpHdwJodcPBszAfwmZXlcdOJGb = new uVjVfKRpeAKAvolZTGywVAQXfSAZ();
		if (HNlEDIXHlBlqLuVoDxTyFUHQtMXH == null)
		{
			HNlEDIXHlBlqLuVoDxTyFUHQtMXH = new gFyYDvnzMpDQpRdqCVRzJQTUBTLG[4];
			for (int i = 0; i < 4; i++)
			{
				mYfrdbcireBcNJFrWedHlySfZSdOA mYfrdbcireBcNJFrWedHlySfZSdOA2 = new mYfrdbcireBcNJFrWedHlySfZSdOA(i, qqKCZgIqhDoCohVchfPICCXCCXtr);
				hmRdjlkkAraUbAOZelrfFnsoEfpCB.ikUrOmsIKNMiTmyUGnratMoHlLVn().ThreadUpdateEvent += mYfrdbcireBcNJFrWedHlySfZSdOA2.BkZfFMdLluQMXGRUHZENKRLticggA;
				hmRdjlkkAraUbAOZelrfFnsoEfpCB.kTOPdpvPqgeEoyxeFuEbAOuEacFu().ThreadUpdateEvent += mYfrdbcireBcNJFrWedHlySfZSdOA2.PcRgSPWcGRjwxKZyefhyJPZlpfch;
				HNlEDIXHlBlqLuVoDxTyFUHQtMXH[i] = new gFyYDvnzMpDQpRdqCVRzJQTUBTLG(i, MwHaCQtmCXIJIjhtaaojhQpEIyMe, mYfrdbcireBcNJFrWedHlySfZSdOA2, TdgGXNbxHZLufOfMdCEtwDrLDjocb, SystemDeviceDisconnected);
			}
		}
		zuotQHsautOMqoadQkXPecmwcPHI(true);
		Update(UpdateLoopType.Update);
	}

	[CustomObfuscation(rename = false)]
	public override void Update(UpdateLoopType currentUpdateLoop)
	{
		OPeMHVHYcpQIArIDIfULgAmBoRiuA = currentUpdateLoop;
		cBAhJHwhtJCwyjQeYmBlxRxzGwpT();
		for (int i = 0; i < 4; i++)
		{
			if (HNlEDIXHlBlqLuVoDxTyFUHQtMXH[i] != null && HNlEDIXHlBlqLuVoDxTyFUHQtMXH[i].GUujVoQhDxDGoqOhXupKaJOWRjtJ())
			{
				HNlEDIXHlBlqLuVoDxTyFUHQtMXH[i].Update();
			}
		}
	}

	[CustomObfuscation(rename = false)]
	public override void OnDestroy()
	{
		if (WfZuwpTfvMSDaYJDVHjNMOikGfnaA != null)
		{
			WfZuwpTfvMSDaYJDVHjNMOikGfnaA.ayepQoWiuxMOqMBzgIggIDNbAPap();
		}
		if (HNlEDIXHlBlqLuVoDxTyFUHQtMXH != null)
		{
			for (int i = 0; i < 4; i++)
			{
				if (HNlEDIXHlBlqLuVoDxTyFUHQtMXH[i] != null)
				{
					if (hmRdjlkkAraUbAOZelrfFnsoEfpCB.ikUrOmsIKNMiTmyUGnratMoHlLVn() != null)
					{
						hmRdjlkkAraUbAOZelrfFnsoEfpCB.ikUrOmsIKNMiTmyUGnratMoHlLVn().ThreadUpdateEvent -= HNlEDIXHlBlqLuVoDxTyFUHQtMXH[i].mFKBGosAemYkqpiMHzApAAgPvOGt.BkZfFMdLluQMXGRUHZENKRLticggA;
					}
					if (hmRdjlkkAraUbAOZelrfFnsoEfpCB.kTOPdpvPqgeEoyxeFuEbAOuEacFu() != null)
					{
						hmRdjlkkAraUbAOZelrfFnsoEfpCB.kTOPdpvPqgeEoyxeFuEbAOuEacFu().ThreadUpdateEvent -= HNlEDIXHlBlqLuVoDxTyFUHQtMXH[i].mFKBGosAemYkqpiMHzApAAgPvOGt.PcRgSPWcGRjwxKZyefhyJPZlpfch;
					}
					HNlEDIXHlBlqLuVoDxTyFUHQtMXH[i].Dispose();
				}
			}
		}
		INUUMVsygJzZqjuBcRMooeqGdhAl.WrnDjwFsLwoPFjjOXAyMOmWSJJzi();
	}

	[CustomObfuscation(rename = false)]
	public override Action<int, ControllerDataUpdater> GetInputDataUpdateDelegate()
	{
		return YIdYiOhFPRigzSGFGFQbsDAMCjgp;
	}

	[CustomObfuscation(rename = false)]
	public override void UpdateControllerData(int assignedControllerId, ControllerDataUpdater data)
	{
		HNlEDIXHlBlqLuVoDxTyFUHQtMXH[assignedControllerId].FillData(data);
	}

	[CustomObfuscation(rename = false)]
	public override void SystemDeviceConnected()
	{
		zuotQHsautOMqoadQkXPecmwcPHI(true);
		diOKVMocSAbqvglvIdzOFxUeOxvNA();
		if (_SystemDeviceConnectedEvent != null)
		{
			_SystemDeviceConnectedEvent();
		}
	}

	[CustomObfuscation(rename = false)]
	public override void SystemDeviceDisconnected()
	{
		zuotQHsautOMqoadQkXPecmwcPHI(true);
		diOKVMocSAbqvglvIdzOFxUeOxvNA();
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

	private XAWRDcWKMfgkHrgJeYMwQTZapuvQ Rewired_002EPlatforms_002EWindows_002EISecondaryInputSourceProvider_002Eget_secondaryInputSourceType()
	{
		return XAWRDcWKMfgkHrgJeYMwQTZapuvQ.XInput;
	}

	bool lqpQxMQBnMKtcyVNasPoQMoNTuAx.MT_HandlesController(string devicePath, string productName, string bluetoothName, PidVid pidVid)
	{
		if (xjVAXhavMIfiiMSuGkxrqThmMlaDA(pidVid))
		{
			return false;
		}
		return tNGmdYeWTIFMuRyKhjxwxXKUCViG(devicePath, productName, bluetoothName, MiscTools.CreateHIDProductGuid(pidVid.vendorId, pidVid.productId));
	}

	private bool XwMTbaznijYUrpUWFslTJcnjfPkB()
	{
		if (OPeMHVHYcpQIArIDIfULgAmBoRiuA != XlaUvcLmFuciBNHlzDsQAPPfLQuBb)
		{
			return false;
		}
		bool num = oNdczxozegJPaHdZdjREMboDWfQc.sUnHPNHUthqrvVNCeVtVwhlHpAdH();
		if (num)
		{
			zuotQHsautOMqoadQkXPecmwcPHI(true);
		}
		return num;
	}

	private void zuotQHsautOMqoadQkXPecmwcPHI(bool P_0)
	{
		YqSlaXqkEFnLCCuROUrUubqzxjlH = P_0;
		if (rsoCisrbUgEuuRuxYchKKCCybRYZ)
		{
			oNdczxozegJPaHdZdjREMboDWfQc.RDUQcxVIUEzPtoXojbWqhOzXcHW();
		}
	}

	private void diOKVMocSAbqvglvIdzOFxUeOxvNA()
	{
		if (WfZuwpTfvMSDaYJDVHjNMOikGfnaA != null)
		{
			WfZuwpTfvMSDaYJDVHjNMOikGfnaA.hsPbiHSrnPbpgEvRSoRtcHgHVNpib();
		}
	}

	private void nWiLFfUwriHDhpheyVtttMLshzTeA()
	{
		new zSemIiGfKoAsdCxlcxZOJaEAArel().elsudCwfzAdctgGqPDhrSXPmTyEh();
	}

	private void cBAhJHwhtJCwyjQeYmBlxRxzGwpT()
	{
		bool flag = false;
		if (rsoCisrbUgEuuRuxYchKKCCybRYZ)
		{
			flag = XwMTbaznijYUrpUWFslTJcnjfPkB();
		}
		if (!flag && YqSlaXqkEFnLCCuROUrUubqzxjlH)
		{
			kbWggBFpavrnYqJSDmjBwugApvWwA(uRloVIrBXFySfAINZsdXnXMauQoU());
			zuotQHsautOMqoadQkXPecmwcPHI(false);
			diOKVMocSAbqvglvIdzOFxUeOxvNA();
			return;
		}
		if (YqSlaXqkEFnLCCuROUrUubqzxjlH)
		{
			PhfqWDkPjukTeAARvvzLeMMIVWPK();
		}
		if (WfZuwpTfvMSDaYJDVHjNMOikGfnaA.WPvaYiDQVIYOIzrVogafDyizCCwab() && WfZuwpTfvMSDaYJDVHjNMOikGfnaA.lDhzHQHlypMVlvNJXJYXaTpmInRJ())
		{
			VhRFzfBXNMjUZhJqcMqjfZIncOLr();
		}
	}

	private void PhfqWDkPjukTeAARvvzLeMMIVWPK()
	{
		YqSlaXqkEFnLCCuROUrUubqzxjlH = false;
		if (!WfZuwpTfvMSDaYJDVHjNMOikGfnaA.WPvaYiDQVIYOIzrVogafDyizCCwab())
		{
			WfZuwpTfvMSDaYJDVHjNMOikGfnaA.NXdyoJYyGKTPsFkwZEZMxMIDBxdK();
		}
	}

	private void VhRFzfBXNMjUZhJqcMqjfZIncOLr()
	{
		lock (ooxQOshQQwqleVsPPXHLVuajthrR)
		{
			Array.Copy(ooxQOshQQwqleVsPPXHLVuajthrR, gafyJWSkyQLiKRiSpZlwkamkiypQ, 4);
		}
		kbWggBFpavrnYqJSDmjBwugApvWwA(gafyJWSkyQLiKRiSpZlwkamkiypQ);
	}

	private bool TjHxrPKkDaxXgboxJmgDRepfqyTE()
	{
		lock (ooxQOshQQwqleVsPPXHLVuajthrR)
		{
			for (int i = 0; i < 4; i++)
			{
				if (HNlEDIXHlBlqLuVoDxTyFUHQtMXH[i] != null)
				{
					ooxQOshQQwqleVsPPXHLVuajthrR[i] = HNlEDIXHlBlqLuVoDxTyFUHQtMXH[i].yPucXGRkwwcGSQMAuCADyZrziVhO(bCmkcsFvCcAVyQUFvmznhNAPsUCK.Synchronous);
				}
			}
		}
		return true;
	}

	private bool[] uRloVIrBXFySfAINZsdXnXMauQoU()
	{
		for (int i = 0; i < 4; i++)
		{
			gafyJWSkyQLiKRiSpZlwkamkiypQ[i] = HNlEDIXHlBlqLuVoDxTyFUHQtMXH[i].yPucXGRkwwcGSQMAuCADyZrziVhO(bCmkcsFvCcAVyQUFvmznhNAPsUCK.Synchronous);
		}
		return gafyJWSkyQLiKRiSpZlwkamkiypQ;
	}

	private void kbWggBFpavrnYqJSDmjBwugApvWwA(bool[] P_0)
	{
		int num = 0;
		for (int i = 0; i < 4; i++)
		{
			if (HNlEDIXHlBlqLuVoDxTyFUHQtMXH[i] != null && HNlEDIXHlBlqLuVoDxTyFUHQtMXH[i].iSUnsiQLochUsDVDrlpEiGZHCzWr)
			{
				bool flag = P_0[i];
				HNlEDIXHlBlqLuVoDxTyFUHQtMXH[i].wxhyTpFzWBLMrcoDiqzDAfiZIfzS(flag);
				if (!flag)
				{
					WDuBeHjgNuabbQAPnWpRUiwzBSaDb(HNlEDIXHlBlqLuVoDxTyFUHQtMXH[i], false);
				}
			}
		}
		for (int j = 0; j < 4; j++)
		{
			if (HNlEDIXHlBlqLuVoDxTyFUHQtMXH[j] != null && !HNlEDIXHlBlqLuVoDxTyFUHQtMXH[j].iSUnsiQLochUsDVDrlpEiGZHCzWr)
			{
				bool flag2 = P_0[j];
				HNlEDIXHlBlqLuVoDxTyFUHQtMXH[j].wxhyTpFzWBLMrcoDiqzDAfiZIfzS(flag2);
				if (flag2 && !WDuBeHjgNuabbQAPnWpRUiwzBSaDb(HNlEDIXHlBlqLuVoDxTyFUHQtMXH[j], true))
				{
					num |= ((j == 0) ? 1 : (1 << j));
				}
			}
		}
		for (int k = 0; k < 4; k++)
		{
			if (HNlEDIXHlBlqLuVoDxTyFUHQtMXH[k] != null)
			{
				int num2 = ((k == 0) ? 1 : (1 << k));
				if ((num & num2) != 1 << k)
				{
					HNlEDIXHlBlqLuVoDxTyFUHQtMXH[k].cYyQLfuJQfakeUPvQuSftpEthJxf(P_0[k]);
				}
			}
		}
	}

	private bool WDuBeHjgNuabbQAPnWpRUiwzBSaDb(gFyYDvnzMpDQpRdqCVRzJQTUBTLG P_0, bool P_1)
	{
		if (P_1)
		{
			P_0.tupeeTizUyfhRUJzHhNpUpphTOUM();
			if (!P_0.uVYMFuWMXHcbSnyKDXesbexNfsSb)
			{
				return false;
			}
			int num = WGibpHdwJodcPBszAfwmZXlcdOJGb.mjWqEfhNHPUdQadKePgBqHFKtvJi(P_0.JdvsyMzBLFVKfinmKzjidanpvtlr, false);
			if (num >= 0)
			{
				P_0.set_rewiredId(WGibpHdwJodcPBszAfwmZXlcdOJGb.mGfNfreyvNAmMQjVjcmdFhXmrTdoA(num));
				WGibpHdwJodcPBszAfwmZXlcdOJGb.KPFtxMWYuVlFsYPcxXrNnmABDUtF(num, P_0, true);
			}
			else
			{
				P_0.set_rewiredId(spYcBfzXJPeKpCJkatuYNbgcMXWTA());
				WGibpHdwJodcPBszAfwmZXlcdOJGb.ZeOeiCCTfuYYdDVpGfxKXvwHCSAB(P_0, true);
			}
			if (_UpdateControllerInfoEvent != null)
			{
				_UpdateControllerInfoEvent(new UpdateControllerInfoEventArgs(P_0));
			}
			BridgedController obj = P_0.ToBridgedController();
			if (_DeviceConnectedEvent != null)
			{
				_DeviceConnectedEvent(obj);
			}
		}
		else
		{
			int num2 = WGibpHdwJodcPBszAfwmZXlcdOJGb.xNjXNPojlzUiTdPCjAkSjGjVrrYD(P_0.get_rewiredId(), P_0.JdvsyMzBLFVKfinmKzjidanpvtlr, true);
			if (num2 >= 0)
			{
				WGibpHdwJodcPBszAfwmZXlcdOJGb.jUITJfJFqWBDZBWfLOwyEXnlcNeeb(num2, false);
			}
			ControllerDisconnectedEventArgs obj2 = P_0.ToControllerDisconnectedEventArgs();
			P_0.qKVhYAflQhLCnFUnNaWIGsdYHeEV();
			if (_DeviceDisconnectedEvent != null)
			{
				_DeviceDisconnectedEvent(obj2);
			}
		}
		return true;
	}

	static fXHRBPluCVlFmVyDTJoQUtqLlMxB()
	{
		pKTCOZaTARDhPkCUQMAPVMoIwYlgA = new Guid[2]
		{
			new Guid("72100955-0000-0000-0000-504944564944"),
			new Guid("02e0045e-0000-0000-0000-504944564944")
		};
		pQhmayYNXiIezuUXBxoFeNsZxIoC = new string[1] { "Xbox Bluetooth Gamepad" };
		ofSNxNiVwRCCytTnaQwLgaBZJtnK = new string[1] { "Xbox Wireless Controller.*" };
	}

	public static bool tNGmdYeWTIFMuRyKhjxwxXKUCViG(string P_0, string P_1, string P_2, Guid P_3)
	{
		if (ArrayTools.Contains(pKTCOZaTARDhPkCUQMAPVMoIwYlgA, P_3))
		{
			return true;
		}
		if (!string.IsNullOrEmpty(P_1))
		{
			for (int i = 0; i < pQhmayYNXiIezuUXBxoFeNsZxIoC.Length; i++)
			{
				if (P_1.Equals(pQhmayYNXiIezuUXBxoFeNsZxIoC[i], StringComparison.OrdinalIgnoreCase))
				{
					return true;
				}
			}
		}
		if (!string.IsNullOrEmpty(P_2))
		{
			for (int j = 0; j < ofSNxNiVwRCCytTnaQwLgaBZJtnK.Length; j++)
			{
				if (Regex.IsMatch(P_2, ofSNxNiVwRCCytTnaQwLgaBZJtnK[j], RegexOptions.IgnoreCase))
				{
					return true;
				}
			}
		}
		P_0 = P_0.ToLower();
		int num = P_0.IndexOf("vid_");
		if (num < 0)
		{
			return false;
		}
		if (P_0.IndexOf("ig_") < num)
		{
			return false;
		}
		return true;
	}
}
