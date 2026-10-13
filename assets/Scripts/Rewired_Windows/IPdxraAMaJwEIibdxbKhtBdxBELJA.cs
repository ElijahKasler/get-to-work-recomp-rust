using System;
using System.Collections.Generic;
using Rewired;
using Rewired.Config;
using Rewired.Data;
using Rewired.Interfaces;
using Rewired.Internal.Localization;
using Rewired.Platforms;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;

internal class IPdxraAMaJwEIibdxbKhtBdxBELJA : PlatformInputManager, INativePlatformHelper
{
	private class LAbYodZzHGCNHXOitKbTHIFBeZUZ
	{
		private class qxLmIqqvMHDfqKCvxDtIhlRTLTfn
		{
			public int zExIMLJShqcmPGYdDQdcmvqyLVzbA;

			public int BKMvtbkNpmVCmBvrnrqTwydJxedk;

			public int yUpeFZEgaAojrwPcswlhWeryDsRM;

			public InputSource XgVrPxPoWofFDDpUqkgAjtCThvsaA;

			public qxLmIqqvMHDfqKCvxDtIhlRTLTfn(int P_0, int P_1, int P_2, InputSource P_3)
			{
				zExIMLJShqcmPGYdDQdcmvqyLVzbA = P_0;
				BKMvtbkNpmVCmBvrnrqTwydJxedk = P_1;
				yUpeFZEgaAojrwPcswlhWeryDsRM = P_2;
				XgVrPxPoWofFDDpUqkgAjtCThvsaA = P_3;
			}

			public void yaMMnwoeiaWiklCLfiQhPkapxpTg(int P_0)
			{
				BKMvtbkNpmVCmBvrnrqTwydJxedk = P_0;
			}

			public TUKrFrfqXtiSNrykTMlufGiSDbYjA tkySNAzxeLtAFgNvpUYONQTBkuJh()
			{
				return new TUKrFrfqXtiSNrykTMlufGiSDbYjA(zExIMLJShqcmPGYdDQdcmvqyLVzbA, BKMvtbkNpmVCmBvrnrqTwydJxedk, XgVrPxPoWofFDDpUqkgAjtCThvsaA);
			}

			public static int KAYCGZiUgZgHkusPDmgaIDKWWBEN(qxLmIqqvMHDfqKCvxDtIhlRTLTfn P_0, qxLmIqqvMHDfqKCvxDtIhlRTLTfn P_1)
			{
				if (P_0.zExIMLJShqcmPGYdDQdcmvqyLVzbA < P_1.zExIMLJShqcmPGYdDQdcmvqyLVzbA)
				{
					return -1;
				}
				if (P_0.zExIMLJShqcmPGYdDQdcmvqyLVzbA > P_1.zExIMLJShqcmPGYdDQdcmvqyLVzbA)
				{
					return 1;
				}
				return 0;
			}
		}

		public struct TUKrFrfqXtiSNrykTMlufGiSDbYjA(int P_0, int P_1, InputSource P_2)
		{
			public int oMuyONMhZBSMeqmPJtgxOTmKBVWJ = P_0;

			public int sFVFZuBLRQzsCrcwJSFxMOPjRctVA = P_1;

			public InputSource lYatLDQTfcQcawAndOscuKYBILVJ = P_2;
		}

		public enum UjZooOmuOQawXYLsilOJdoYtGMNfA
		{
			Connected = 0,
			Disconnected = 1
		}

		private List<qxLmIqqvMHDfqKCvxDtIhlRTLTfn> UWpyfLmSkzRPdgcUDFuTtSLrfsIaA;

		private List<qxLmIqqvMHDfqKCvxDtIhlRTLTfn> kFJdQZobaIMYXhBsJPdDIVGXDjYV;

		public int mvhkZfTJzuzfDgCbTluYGQRyDqB => gthuahZvDpULFjESmaXXBFfopRuT();

		public int gthuahZvDpULFjESmaXXBFfopRuT()
		{
			return kFJdQZobaIMYXhBsJPdDIVGXDjYV.Count;
		}

		public LAbYodZzHGCNHXOitKbTHIFBeZUZ()
		{
			kFJdQZobaIMYXhBsJPdDIVGXDjYV = new List<qxLmIqqvMHDfqKCvxDtIhlRTLTfn>();
			UWpyfLmSkzRPdgcUDFuTtSLrfsIaA = new List<qxLmIqqvMHDfqKCvxDtIhlRTLTfn>();
		}

		public void GjYAgcsgyVvEDZKaOAzhzvPrqkLF(BridgedController P_0)
		{
			if (P_0 == null || P_0.sourceJoystick == null)
			{
				return;
			}
			IInputManagerJoystickPublic sourceJoystick = P_0.sourceJoystick;
			int num = agSbyQDCdPzJASgHNCApXYUxCuyjA(sourceJoystick.rewiredId, UjZooOmuOQawXYLsilOJdoYtGMNfA.Connected);
			qxLmIqqvMHDfqKCvxDtIhlRTLTfn qxLmIqqvMHDfqKCvxDtIhlRTLTfn2;
			if (num >= 0)
			{
				qxLmIqqvMHDfqKCvxDtIhlRTLTfn2 = kFJdQZobaIMYXhBsJPdDIVGXDjYV[num];
				qxLmIqqvMHDfqKCvxDtIhlRTLTfn2.yaMMnwoeiaWiklCLfiQhPkapxpTg(sourceJoystick.inputManagerId);
				P_0.sourceJoystick = new KqCTMbyNrKlMXZszQEIljCtPuBYj(sourceJoystick, qxLmIqqvMHDfqKCvxDtIhlRTLTfn2.zExIMLJShqcmPGYdDQdcmvqyLVzbA);
				return;
			}
			num = agSbyQDCdPzJASgHNCApXYUxCuyjA(sourceJoystick.rewiredId, UjZooOmuOQawXYLsilOJdoYtGMNfA.Disconnected);
			if (num >= 0)
			{
				qxLmIqqvMHDfqKCvxDtIhlRTLTfn2 = UWpyfLmSkzRPdgcUDFuTtSLrfsIaA[num];
				UWpyfLmSkzRPdgcUDFuTtSLrfsIaA.RemoveAt(num);
				int zExIMLJShqcmPGYdDQdcmvqyLVzbA = gJraHEPDjeafKpLJkprKDHjWSrmS(qxLmIqqvMHDfqKCvxDtIhlRTLTfn2.zExIMLJShqcmPGYdDQdcmvqyLVzbA);
				qxLmIqqvMHDfqKCvxDtIhlRTLTfn2.zExIMLJShqcmPGYdDQdcmvqyLVzbA = zExIMLJShqcmPGYdDQdcmvqyLVzbA;
			}
			else
			{
				qxLmIqqvMHDfqKCvxDtIhlRTLTfn2 = new qxLmIqqvMHDfqKCvxDtIhlRTLTfn(AInTvCIRfSdfqKrMcdSwZWlqYnxTA(), sourceJoystick.inputManagerId, sourceJoystick.rewiredId, P_0.inputManagerSource);
			}
			P_0.sourceJoystick = new KqCTMbyNrKlMXZszQEIljCtPuBYj(sourceJoystick, qxLmIqqvMHDfqKCvxDtIhlRTLTfn2.zExIMLJShqcmPGYdDQdcmvqyLVzbA);
			kFJdQZobaIMYXhBsJPdDIVGXDjYV.Add(qxLmIqqvMHDfqKCvxDtIhlRTLTfn2);
			kFJdQZobaIMYXhBsJPdDIVGXDjYV.Sort(qxLmIqqvMHDfqKCvxDtIhlRTLTfn.KAYCGZiUgZgHkusPDmgaIDKWWBEN);
		}

		public void bSIFKnjrkAqfyuvLufYvhcrMdWqV(ControllerDisconnectedEventArgs P_0)
		{
			if (P_0 != null)
			{
				int num = agSbyQDCdPzJASgHNCApXYUxCuyjA(P_0.rewiredId, UjZooOmuOQawXYLsilOJdoYtGMNfA.Connected);
				if (num < 0)
				{
					Logger.LogError("Device was not in connected list! Cannot remove!");
					return;
				}
				qxLmIqqvMHDfqKCvxDtIhlRTLTfn item = kFJdQZobaIMYXhBsJPdDIVGXDjYV[num];
				kFJdQZobaIMYXhBsJPdDIVGXDjYV.RemoveAt(num);
				UWpyfLmSkzRPdgcUDFuTtSLrfsIaA.Add(item);
			}
		}

		public void LfGRCbsQVqGgDtnffsJREdUAWHIK(int P_0, int P_1)
		{
			int num = agSbyQDCdPzJASgHNCApXYUxCuyjA(P_0, UjZooOmuOQawXYLsilOJdoYtGMNfA.Connected);
			if (num >= 0)
			{
				kFJdQZobaIMYXhBsJPdDIVGXDjYV[num].yaMMnwoeiaWiklCLfiQhPkapxpTg(P_1);
				return;
			}
			num = agSbyQDCdPzJASgHNCApXYUxCuyjA(P_0, UjZooOmuOQawXYLsilOJdoYtGMNfA.Disconnected);
			if (num >= 0)
			{
				UWpyfLmSkzRPdgcUDFuTtSLrfsIaA[num].yaMMnwoeiaWiklCLfiQhPkapxpTg(P_1);
			}
		}

		public bool nvbnoDbeTrdlCYUsjOQnZGMkjoNi(int P_0, UjZooOmuOQawXYLsilOJdoYtGMNfA P_1)
		{
			if (agSbyQDCdPzJASgHNCApXYUxCuyjA(P_0, P_1) < 0)
			{
				return false;
			}
			return true;
		}

		public int agSbyQDCdPzJASgHNCApXYUxCuyjA(int P_0, UjZooOmuOQawXYLsilOJdoYtGMNfA P_1)
		{
			switch (P_1)
			{
			case UjZooOmuOQawXYLsilOJdoYtGMNfA.Connected:
			{
				int count2 = kFJdQZobaIMYXhBsJPdDIVGXDjYV.Count;
				for (int j = 0; j < count2; j++)
				{
					if (kFJdQZobaIMYXhBsJPdDIVGXDjYV[j].yUpeFZEgaAojrwPcswlhWeryDsRM == P_0)
					{
						return j;
					}
				}
				break;
			}
			case UjZooOmuOQawXYLsilOJdoYtGMNfA.Disconnected:
			{
				int count = UWpyfLmSkzRPdgcUDFuTtSLrfsIaA.Count;
				for (int i = 0; i < count; i++)
				{
					if (UWpyfLmSkzRPdgcUDFuTtSLrfsIaA[i].yUpeFZEgaAojrwPcswlhWeryDsRM == P_0)
					{
						return i;
					}
				}
				break;
			}
			}
			return -1;
		}

		public int MqctUwwYqtISDKmcMVODwLHGdOom(int P_0, InputSource P_1, UjZooOmuOQawXYLsilOJdoYtGMNfA P_2)
		{
			switch (P_2)
			{
			case UjZooOmuOQawXYLsilOJdoYtGMNfA.Connected:
			{
				int count2 = kFJdQZobaIMYXhBsJPdDIVGXDjYV.Count;
				for (int j = 0; j < count2; j++)
				{
					if (kFJdQZobaIMYXhBsJPdDIVGXDjYV[j].zExIMLJShqcmPGYdDQdcmvqyLVzbA == P_0 && kFJdQZobaIMYXhBsJPdDIVGXDjYV[j].XgVrPxPoWofFDDpUqkgAjtCThvsaA == P_1)
					{
						return j;
					}
				}
				break;
			}
			case UjZooOmuOQawXYLsilOJdoYtGMNfA.Disconnected:
			{
				int count = UWpyfLmSkzRPdgcUDFuTtSLrfsIaA.Count;
				for (int i = 0; i < count; i++)
				{
					if (UWpyfLmSkzRPdgcUDFuTtSLrfsIaA[i].zExIMLJShqcmPGYdDQdcmvqyLVzbA == P_0 && UWpyfLmSkzRPdgcUDFuTtSLrfsIaA[i].XgVrPxPoWofFDDpUqkgAjtCThvsaA == P_1)
					{
						return i;
					}
				}
				break;
			}
			}
			return -1;
		}

		public TUKrFrfqXtiSNrykTMlufGiSDbYjA lCVZJHGSjvNciNSZWzgrfCouHLTG(int P_0, UjZooOmuOQawXYLsilOJdoYtGMNfA P_1)
		{
			if (P_1 == UjZooOmuOQawXYLsilOJdoYtGMNfA.Connected)
			{
				if (P_0 < 0 || P_0 >= kFJdQZobaIMYXhBsJPdDIVGXDjYV.Count)
				{
					throw new ArgumentOutOfRangeException();
				}
				return kFJdQZobaIMYXhBsJPdDIVGXDjYV[P_0].tkySNAzxeLtAFgNvpUYONQTBkuJh();
			}
			if (P_0 < 0 || P_0 >= UWpyfLmSkzRPdgcUDFuTtSLrfsIaA.Count)
			{
				throw new ArgumentOutOfRangeException();
			}
			return UWpyfLmSkzRPdgcUDFuTtSLrfsIaA[P_0].tkySNAzxeLtAFgNvpUYONQTBkuJh();
		}

		public int wWgICzdHlMyxlJfUmlrPNzzbYBdb(int P_0, InputSource P_1, UjZooOmuOQawXYLsilOJdoYtGMNfA P_2)
		{
			int num = MqctUwwYqtISDKmcMVODwLHGdOom(P_0, P_1, P_2);
			if (num < 0)
			{
				return -1;
			}
			return P_2 switch
			{
				UjZooOmuOQawXYLsilOJdoYtGMNfA.Connected => kFJdQZobaIMYXhBsJPdDIVGXDjYV[num].BKMvtbkNpmVCmBvrnrqTwydJxedk, 
				UjZooOmuOQawXYLsilOJdoYtGMNfA.Disconnected => UWpyfLmSkzRPdgcUDFuTtSLrfsIaA[num].BKMvtbkNpmVCmBvrnrqTwydJxedk, 
				_ => -1, 
			};
		}

		private int gJraHEPDjeafKpLJkprKDHjWSrmS(int P_0)
		{
			int count = kFJdQZobaIMYXhBsJPdDIVGXDjYV.Count;
			for (int i = 0; i < count; i++)
			{
				if (kFJdQZobaIMYXhBsJPdDIVGXDjYV[i].zExIMLJShqcmPGYdDQdcmvqyLVzbA == P_0)
				{
					return AInTvCIRfSdfqKrMcdSwZWlqYnxTA();
				}
			}
			return P_0;
		}

		private int AInTvCIRfSdfqKrMcdSwZWlqYnxTA()
		{
			int count = kFJdQZobaIMYXhBsJPdDIVGXDjYV.Count;
			int num = 0;
			while (true)
			{
				bool flag = false;
				for (int i = 0; i < count; i++)
				{
					if (kFJdQZobaIMYXhBsJPdDIVGXDjYV[i].zExIMLJShqcmPGYdDQdcmvqyLVzbA == num)
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
	}

	private class KqCTMbyNrKlMXZszQEIljCtPuBYj : IInputManagerJoystickPublic, ITryGetLocalizedName
	{
		private IInputManagerJoystickPublic BFgJgpoTLZpGmDfhgfAXUmkVzGjo;

		private int NXiZsqWPINkfUxIQsMFZSANJHUHhA;

		int IInputManagerJoystickPublic.rewiredId => get_rewiredId();

		int IInputManagerJoystickPublic.inputManagerId => get_inputManagerId();

		string IInputManagerJoystickPublic.name => get_name();

		long? IInputManagerJoystickPublic.systemId => get_systemId();

		int IInputManagerJoystickPublic.unityId => get_unityId();

		Guid IInputManagerJoystickPublic.instanceGuid => get_instanceGuid();

		Guid IInputManagerJoystickPublic.persistentGuid => get_persistentGuid();

		Controller.Extension IInputManagerJoystickPublic.extension => get_extension();

		public KqCTMbyNrKlMXZszQEIljCtPuBYj(IInputManagerJoystickPublic P_0, int P_1)
		{
			BFgJgpoTLZpGmDfhgfAXUmkVzGjo = P_0;
			NXiZsqWPINkfUxIQsMFZSANJHUHhA = P_1;
		}

		public int get_rewiredId()
		{
			return BFgJgpoTLZpGmDfhgfAXUmkVzGjo.rewiredId;
		}

		public int get_inputManagerId()
		{
			return NXiZsqWPINkfUxIQsMFZSANJHUHhA;
		}

		public string get_name()
		{
			return BFgJgpoTLZpGmDfhgfAXUmkVzGjo.name;
		}

		public long? get_systemId()
		{
			return BFgJgpoTLZpGmDfhgfAXUmkVzGjo.systemId;
		}

		public int get_unityId()
		{
			return BFgJgpoTLZpGmDfhgfAXUmkVzGjo.unityId;
		}

		public Guid get_instanceGuid()
		{
			return BFgJgpoTLZpGmDfhgfAXUmkVzGjo.instanceGuid;
		}

		public Guid get_persistentGuid()
		{
			return get_instanceGuid();
		}

		public Controller.Extension get_extension()
		{
			return BFgJgpoTLZpGmDfhgfAXUmkVzGjo.extension;
		}

		public void SetVibration(float amount, int motorIndex)
		{
			BFgJgpoTLZpGmDfhgfAXUmkVzGjo.SetVibration(amount, motorIndex);
		}

		void IInputManagerJoystickPublic.SetVibration(float amount, int motorIndex)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetVibration
			this.SetVibration(amount, motorIndex);
		}

		public void StopVibration()
		{
			BFgJgpoTLZpGmDfhgfAXUmkVzGjo.StopVibration();
		}

		void IInputManagerJoystickPublic.StopVibration()
		{
			//ILSpy generated this explicit interface implementation from .override directive in StopVibration
			this.StopVibration();
		}

		bool ITryGetLocalizedName.TryGetLocalizedName(out string value)
		{
			if (BFgJgpoTLZpGmDfhgfAXUmkVzGjo is ITryGetLocalizedName tryGetLocalizedName)
			{
				return tryGetLocalizedName.TryGetLocalizedName(out value);
			}
			value = null;
			return false;
		}
	}

	[Serializable]
	private sealed class dhiXTBkmPPzjBagRdQmPhcXMfEiI
	{
		public static readonly dhiXTBkmPPzjBagRdQmPhcXMfEiI _003C_003E9 = new dhiXTBkmPPzjBagRdQmPhcXMfEiI();

		public static Func<PidVid, bool> _003C_003E9__17_0;

		internal bool XgVlkTasViNjyjwVnHJkSMqRkbhU(PidVid P_0)
		{
			return false;
		}
	}

	private sealed class MNaeYvDmEYpCfXkCQeOUjYOSmPdq
	{
		public int xLnlaCLsyJiMputEzlpKwqUuijPQ;

		internal int KIQqGhOTKQrGzxTTNHCVQyFQHvVw()
		{
			return xLnlaCLsyJiMputEzlpKwqUuijPQ++;
		}
	}

	private const bool NbapeWsrASSJdNosNDIguCpgCMwhA = false;

	private const bool ZDoskTTbTYTzhlPJupqvJIEEFaXk = false;

	private const bool qzFivYsImMLyIkHvWaSfLiHrmwfk = false;

	private const bool mgqaKkfTAZBNeBafcURkyQUtIRtcb = false;

	private const bool WPtBbtJIiWLiySxgyWaTnZZsgmuHA = false;

	private const bool WKJGykfzUzHCTxzizQHgKPrKEolaA = false;

	private bool KnZcmQnLjUbPElhflvXoMHqFUUZm;

	private EyqAVKNFdILdFVrVoDFhxrwsTYzL ifQoEwrgxZJMnpoFLbCxWjKJjOel;

	private IndexedDictionary<int, PlatformInputManager> RMgjoVzFWTlHFShEVsWFcpcyihBr;

	private LAbYodZzHGCNHXOitKbTHIFBeZUZ YHIzNhiiTTzajXwsTjWzQbmyQqKG;

	private Action<int, ControllerDataUpdater> GFsGHGSxsrVyZmmANmCHqIUWzmrc;

	private WindowsStandalonePrimaryInputSource WeCyIkuUlMETUBjqPgbkDPOtiQjo;

	private PlatformInputManager lqsVVzFzvUJogedEbUKLzvvdNfAy;

	private bool UqfFqeukhnXQDQETzaiFuxEbRpI;

	private Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> mFysooBDnintkjenedQcidKDFQgI;

	private Func<int> HctHkHcGDQMimivORtYREmNMMIJEb;

	private Func<PidVid, bool> RwXGaNfGQTJprIjVggUsIjwqboHoA;

	[CustomObfuscation(rename = false)]
	private int counter;

	bool INativePlatformHelper.isApplicationFocused
	{
		get
		{
			IntPtr intPtr = iZtZloELsoaMBDRDTiszzpwtPjDd.mXEkaNcGmWKTpdexOWkopORPRUhj();
			IntPtr intPtr2 = iZtZloELsoaMBDRDTiszzpwtPjDd.ZHebZlPknMWIRGDCJrAPSeRLEbvp();
			if (intPtr2 != IntPtr.Zero)
			{
				return intPtr == intPtr2;
			}
			return false;
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

	public IPdxraAMaJwEIibdxbKhtBdxBELJA(ConfigVars P_0, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> P_1, Func<int> P_2)
	{
		try
		{
			WeCyIkuUlMETUBjqPgbkDPOtiQjo = P_0.windowsStandalonePrimaryInputSource;
			RwXGaNfGQTJprIjVggUsIjwqboHoA = dhiXTBkmPPzjBagRdQmPhcXMfEiI._003C_003E9.XgVlkTasViNjyjwVnHJkSMqRkbhU;
			bool flag = UnityTools.platform == Platform.WindowsAppStore || UnityTools.platform == Platform.Windows81Store || UnityTools.platform == Platform.WindowsPhone8;
			bool flag2 = UnityTools.platform == Platform.Windows && (WeCyIkuUlMETUBjqPgbkDPOtiQjo == WindowsStandalonePrimaryInputSource.DirectInput || WeCyIkuUlMETUBjqPgbkDPOtiQjo == WindowsStandalonePrimaryInputSource.RawInput);
			XAWRDcWKMfgkHrgJeYMwQTZapuvQ xAWRDcWKMfgkHrgJeYMwQTZapuvQ = XAWRDcWKMfgkHrgJeYMwQTZapuvQ.None;
			if (flag2)
			{
				xAWRDcWKMfgkHrgJeYMwQTZapuvQ = (P_0.GetPlatformVar_useWindowsGamingInput() ? XAWRDcWKMfgkHrgJeYMwQTZapuvQ.WindowsGamingInput : (P_0.useXInput ? XAWRDcWKMfgkHrgJeYMwQTZapuvQ.XInput : XAWRDcWKMfgkHrgJeYMwQTZapuvQ.None));
			}
			bool flag3 = xAWRDcWKMfgkHrgJeYMwQTZapuvQ == XAWRDcWKMfgkHrgJeYMwQTZapuvQ.WindowsGamingInput || xAWRDcWKMfgkHrgJeYMwQTZapuvQ == XAWRDcWKMfgkHrgJeYMwQTZapuvQ.XInput || WeCyIkuUlMETUBjqPgbkDPOtiQjo == WindowsStandalonePrimaryInputSource.XInput || WeCyIkuUlMETUBjqPgbkDPOtiQjo == WindowsStandalonePrimaryInputSource.WindowsGamingInput;
			mFysooBDnintkjenedQcidKDFQgI = P_1;
			HctHkHcGDQMimivORtYREmNMMIJEb = P_2;
			bool flag4 = false;
			RMgjoVzFWTlHFShEVsWFcpcyihBr = new IndexedDictionary<int, PlatformInputManager>();
			PlatformInputManager platformInputManager = null;
			if (UnityTools.platform != Platform.WindowsAppStore)
			{
				try
				{
					hmRdjlkkAraUbAOZelrfFnsoEfpCB.yjHGPJbwHWVIZspTmMOUavakCDLK(flag3);
				}
				catch (Exception ex)
				{
					OnDestroy();
					Logger.LogWarning("Unable to initialize input source!\n" + ex.Message);
					throw;
				}
			}
			if (flag2)
			{
				switch (xAWRDcWKMfgkHrgJeYMwQTZapuvQ)
				{
				case XAWRDcWKMfgkHrgJeYMwQTZapuvQ.XInput:
					if (SWAfDoKqYaEYRZTWsXEvQYbHAdIfb(P_0, false, out platformInputManager))
					{
						flag4 = true;
					}
					else
					{
						P_0.useXInput = false;
					}
					break;
				case XAWRDcWKMfgkHrgJeYMwQTZapuvQ.WindowsGamingInput:
					if (BrKQPWzSMZBZHiEJpiafvwDNhEuFA(P_0, false, out platformInputManager))
					{
						break;
					}
					P_0.SetPlatformVar_useWindowsGamingInput(value: false);
					if (P_0.useXInput && !flag4)
					{
						Logger.Log("Attempting to fallback to XInput...");
						if (SWAfDoKqYaEYRZTWsXEvQYbHAdIfb(P_0, false, out platformInputManager))
						{
							flag4 = true;
							Logger.Log("XInput initialized.");
						}
						else
						{
							P_0.useXInput = false;
						}
					}
					break;
				}
			}
			if (flag)
			{
				if (!flag4 && !SWAfDoKqYaEYRZTWsXEvQYbHAdIfb(P_0, true, out lqsVVzFzvUJogedEbUKLzvvdNfAy))
				{
					throw new Exception();
				}
			}
			else if (UnityTools.platform != Platform.WindowsAppStore)
			{
				ifQoEwrgxZJMnpoFLbCxWjKJjOel = new EyqAVKNFdILdFVrVoDFhxrwsTYzL();
				bool flag5 = false;
				if (WeCyIkuUlMETUBjqPgbkDPOtiQjo == WindowsStandalonePrimaryInputSource.DirectInput)
				{
					flag5 = JlZEUTuZJLMIXYVDlCsidaVEjBeL(P_0, ifQoEwrgxZJMnpoFLbCxWjKJjOel, platformInputManager as lqpQxMQBnMKtcyVNasPoQMoNTuAx);
					if (!flag5)
					{
						Logger.Log("Attempting to fallback to Raw Input...");
						flag5 = mcGRYEFltdMWQtGdmsiCdXRUrEiD(P_0, ifQoEwrgxZJMnpoFLbCxWjKJjOel, platformInputManager as lqpQxMQBnMKtcyVNasPoQMoNTuAx);
						if (flag5)
						{
							P_0.windowsStandalonePrimaryInputSource = WindowsStandalonePrimaryInputSource.RawInput;
							WeCyIkuUlMETUBjqPgbkDPOtiQjo = P_0.windowsStandalonePrimaryInputSource;
							Logger.Log("Raw Input initialized.");
						}
					}
				}
				else if (WeCyIkuUlMETUBjqPgbkDPOtiQjo == WindowsStandalonePrimaryInputSource.RawInput)
				{
					flag5 = mcGRYEFltdMWQtGdmsiCdXRUrEiD(P_0, ifQoEwrgxZJMnpoFLbCxWjKJjOel, platformInputManager as lqpQxMQBnMKtcyVNasPoQMoNTuAx);
					if (!flag5)
					{
						Logger.Log("Attempting to fallback to Direct Input...");
						flag5 = JlZEUTuZJLMIXYVDlCsidaVEjBeL(P_0, ifQoEwrgxZJMnpoFLbCxWjKJjOel, platformInputManager as lqpQxMQBnMKtcyVNasPoQMoNTuAx);
						if (flag5)
						{
							P_0.windowsStandalonePrimaryInputSource = WindowsStandalonePrimaryInputSource.DirectInput;
							WeCyIkuUlMETUBjqPgbkDPOtiQjo = P_0.windowsStandalonePrimaryInputSource;
							Logger.Log("Direct Input initialized.");
						}
					}
				}
				else if (WeCyIkuUlMETUBjqPgbkDPOtiQjo == WindowsStandalonePrimaryInputSource.XInput)
				{
					P_0.SetPlatformVar_useWindowsGamingInput(value: false);
					flag5 = SWAfDoKqYaEYRZTWsXEvQYbHAdIfb(P_0, true, out lqsVVzFzvUJogedEbUKLzvvdNfAy);
					flag4 = flag5;
					if (flag5)
					{
						LyRGQDHRgNgXZEDiRLJBIkVMYyVd(P_0, ifQoEwrgxZJMnpoFLbCxWjKJjOel);
					}
					else
					{
						P_0.useXInput = false;
						Logger.Log("Attempting to fallback to Raw Input...");
						flag5 = mcGRYEFltdMWQtGdmsiCdXRUrEiD(P_0, ifQoEwrgxZJMnpoFLbCxWjKJjOel, null);
						if (flag5)
						{
							P_0.windowsStandalonePrimaryInputSource = WindowsStandalonePrimaryInputSource.RawInput;
							WeCyIkuUlMETUBjqPgbkDPOtiQjo = P_0.windowsStandalonePrimaryInputSource;
							Logger.Log("Raw Input initialized.");
						}
					}
				}
				else if (WeCyIkuUlMETUBjqPgbkDPOtiQjo == WindowsStandalonePrimaryInputSource.WindowsGamingInput)
				{
					bool flag6 = true;
					flag5 = BrKQPWzSMZBZHiEJpiafvwDNhEuFA(P_0, true, out lqsVVzFzvUJogedEbUKLzvvdNfAy);
					if (!flag5)
					{
						P_0.SetPlatformVar_useWindowsGamingInput(value: false);
						if (P_0.useXInput && !flag4)
						{
							Logger.Log("Attempting to fallback to XInput...");
							flag5 = SWAfDoKqYaEYRZTWsXEvQYbHAdIfb(P_0, true, out lqsVVzFzvUJogedEbUKLzvvdNfAy);
							flag4 = flag5;
							if (flag5)
							{
								P_0.windowsStandalonePrimaryInputSource = WindowsStandalonePrimaryInputSource.XInput;
								Logger.Log("XInput initialized.");
							}
							else
							{
								P_0.useXInput = false;
							}
						}
						if (!flag5)
						{
							Logger.Log("Attempting to fallback to Raw Input...");
							flag5 = mcGRYEFltdMWQtGdmsiCdXRUrEiD(P_0, ifQoEwrgxZJMnpoFLbCxWjKJjOel, null);
							if (flag5)
							{
								flag6 = false;
								P_0.windowsStandalonePrimaryInputSource = WindowsStandalonePrimaryInputSource.RawInput;
								WeCyIkuUlMETUBjqPgbkDPOtiQjo = P_0.windowsStandalonePrimaryInputSource;
								Logger.Log("Raw Input initialized.");
							}
						}
					}
					if (flag5 & flag6)
					{
						LyRGQDHRgNgXZEDiRLJBIkVMYyVd(P_0, ifQoEwrgxZJMnpoFLbCxWjKJjOel);
					}
				}
				if (!flag5)
				{
					throw new Exception();
				}
				ifQoEwrgxZJMnpoFLbCxWjKJjOel.GMNZdmrELSBTWcwkqDOaNKJvmNkmA(uyEVgOQgnTcHNSxBBvTMnWyMngLC);
				ifQoEwrgxZJMnpoFLbCxWjKJjOel.sVEokdZVYamCQCMiXLYTuFGcGDpx(WnqjNjXqrphwwzapbOMGCLzyauTY);
			}
			if (lqsVVzFzvUJogedEbUKLzvvdNfAy == null)
			{
				throw new Exception("No primary input manager could be initialized.");
			}
			GFsGHGSxsrVyZmmANmCHqIUWzmrc = UpdateControllerData;
		}
		catch (Exception ex2)
		{
			OnDestroy();
			Logger.LogWarning("Unable to initialize input source!\n" + ex2.Message);
			throw;
		}
	}

	private bool JlZEUTuZJLMIXYVDlCsidaVEjBeL(ConfigVars P_0, EyqAVKNFdILdFVrVoDFhxrwsTYzL P_1, lqpQxMQBnMKtcyVNasPoQMoNTuAx P_2)
	{
		ICmcGjxBNfvDxrhZrqBEYaJZLTEe cmcGjxBNfvDxrhZrqBEYaJZLTEe = null;
		CjBwBKlcXyHERByOVbSKItkOzASJ cjBwBKlcXyHERByOVbSKItkOzASJ = null;
		try
		{
			cmcGjxBNfvDxrhZrqBEYaJZLTEe = new ICmcGjxBNfvDxrhZrqBEYaJZLTEe(P_0, null, null, null, false, P_0.GetPlatformVar_useNativeMouse(), P_0.GetPlatformVar_useNativeKeyboard(), P_0.GetPlatformVar_useEnhancedDeviceSupport());
			cjBwBKlcXyHERByOVbSKItkOzASJ = (CjBwBKlcXyHERByOVbSKItkOzASJ)(lqsVVzFzvUJogedEbUKLzvvdNfAy = new CjBwBKlcXyHERByOVbSKItkOzASJ(P_0.updateLoop, P_2, P_1.AJherrZBMBpmRcnzZCDlOLznUqfx(), mFysooBDnintkjenedQcidKDFQgI, HctHkHcGDQMimivORtYREmNMMIJEb));
			RMgjoVzFWTlHFShEVsWFcpcyihBr.Add(5, cmcGjxBNfvDxrhZrqBEYaJZLTEe);
			RMgjoVzFWTlHFShEVsWFcpcyihBr.Add(1, lqsVVzFzvUJogedEbUKLzvvdNfAy);
			P_1.dOauVvhaiFYastmRSgFyElkTZSkS(cmcGjxBNfvDxrhZrqBEYaJZLTEe.fzwfqARXARYAHHmTBZhqwhtxEMSb);
			cmcGjxBNfvDxrhZrqBEYaJZLTEe.DeviceConnectedEvent += dgYlFixFyuUQKEtMEuinEgvCOPsw;
			cmcGjxBNfvDxrhZrqBEYaJZLTEe.DeviceDisconnectedEvent += jaIEzseFxyOKzSUyJZJePQYZFWRqA;
			cmcGjxBNfvDxrhZrqBEYaJZLTEe.UpdateControllerInfoEvent += WRCdMWzMShKZLjttQBXFAQKlHkon;
			cjBwBKlcXyHERByOVbSKItkOzASJ.DeviceConnectedEvent += dgYlFixFyuUQKEtMEuinEgvCOPsw;
			cjBwBKlcXyHERByOVbSKItkOzASJ.DeviceDisconnectedEvent += jaIEzseFxyOKzSUyJZJePQYZFWRqA;
			cjBwBKlcXyHERByOVbSKItkOzASJ.UpdateControllerInfoEvent += WRCdMWzMShKZLjttQBXFAQKlHkon;
			return true;
		}
		catch (Exception)
		{
			cjBwBKlcXyHERByOVbSKItkOzASJ?.OnDestroy();
			cmcGjxBNfvDxrhZrqBEYaJZLTEe?.OnDestroy();
			Logger.LogWarning("Unable to initialize Direct Input! ");
		}
		return false;
	}

	private bool mcGRYEFltdMWQtGdmsiCdXRUrEiD(ConfigVars P_0, EyqAVKNFdILdFVrVoDFhxrwsTYzL P_1, lqpQxMQBnMKtcyVNasPoQMoNTuAx P_2)
	{
		ICmcGjxBNfvDxrhZrqBEYaJZLTEe cmcGjxBNfvDxrhZrqBEYaJZLTEe = null;
		try
		{
			cmcGjxBNfvDxrhZrqBEYaJZLTEe = new ICmcGjxBNfvDxrhZrqBEYaJZLTEe(P_0, P_2, mFysooBDnintkjenedQcidKDFQgI, HctHkHcGDQMimivORtYREmNMMIJEb, true, P_0.GetPlatformVar_useNativeMouse(), P_0.GetPlatformVar_useNativeKeyboard(), P_0.GetPlatformVar_useEnhancedDeviceSupport());
			RMgjoVzFWTlHFShEVsWFcpcyihBr.Add(5, cmcGjxBNfvDxrhZrqBEYaJZLTEe);
			P_1.dOauVvhaiFYastmRSgFyElkTZSkS(cmcGjxBNfvDxrhZrqBEYaJZLTEe.fzwfqARXARYAHHmTBZhqwhtxEMSb);
			lqsVVzFzvUJogedEbUKLzvvdNfAy = cmcGjxBNfvDxrhZrqBEYaJZLTEe;
			cmcGjxBNfvDxrhZrqBEYaJZLTEe.DeviceConnectedEvent += dgYlFixFyuUQKEtMEuinEgvCOPsw;
			cmcGjxBNfvDxrhZrqBEYaJZLTEe.DeviceDisconnectedEvent += jaIEzseFxyOKzSUyJZJePQYZFWRqA;
			cmcGjxBNfvDxrhZrqBEYaJZLTEe.UpdateControllerInfoEvent += WRCdMWzMShKZLjttQBXFAQKlHkon;
			return true;
		}
		catch (Exception)
		{
			Logger.LogWarning("Unable to initialize Raw Input! This error can be caused by running Unity sandboxed.");
			cmcGjxBNfvDxrhZrqBEYaJZLTEe?.OnDestroy();
		}
		return false;
	}

	private bool LyRGQDHRgNgXZEDiRLJBIkVMYyVd(ConfigVars P_0, EyqAVKNFdILdFVrVoDFhxrwsTYzL P_1)
	{
		bool platformVar_useNativeMouse = P_0.GetPlatformVar_useNativeMouse();
		bool platformVar_useNativeKeyboard = P_0.GetPlatformVar_useNativeKeyboard();
		if (!platformVar_useNativeMouse && !platformVar_useNativeKeyboard)
		{
			return false;
		}
		ICmcGjxBNfvDxrhZrqBEYaJZLTEe cmcGjxBNfvDxrhZrqBEYaJZLTEe = null;
		try
		{
			cmcGjxBNfvDxrhZrqBEYaJZLTEe = new ICmcGjxBNfvDxrhZrqBEYaJZLTEe(P_0, null, null, null, false, platformVar_useNativeMouse, platformVar_useNativeKeyboard, P_0.GetPlatformVar_useEnhancedDeviceSupport());
			P_1.dOauVvhaiFYastmRSgFyElkTZSkS(cmcGjxBNfvDxrhZrqBEYaJZLTEe.fzwfqARXARYAHHmTBZhqwhtxEMSb);
			RMgjoVzFWTlHFShEVsWFcpcyihBr.Add(5, cmcGjxBNfvDxrhZrqBEYaJZLTEe);
			cmcGjxBNfvDxrhZrqBEYaJZLTEe.DeviceConnectedEvent += dgYlFixFyuUQKEtMEuinEgvCOPsw;
			cmcGjxBNfvDxrhZrqBEYaJZLTEe.DeviceDisconnectedEvent += jaIEzseFxyOKzSUyJZJePQYZFWRqA;
			cmcGjxBNfvDxrhZrqBEYaJZLTEe.UpdateControllerInfoEvent += WRCdMWzMShKZLjttQBXFAQKlHkon;
			return true;
		}
		catch
		{
			Logger.LogWarning("Unable to initialize Raw Input for native mouse handling! Unity mouse input will be used instead.");
			cmcGjxBNfvDxrhZrqBEYaJZLTEe?.OnDestroy();
			cmcGjxBNfvDxrhZrqBEYaJZLTEe = null;
			return false;
		}
	}

	private bool SWAfDoKqYaEYRZTWsXEvQYbHAdIfb(ConfigVars P_0, bool P_1, out PlatformInputManager P_2)
	{
		UpdateLoopSetting updateLoop = P_0.updateLoop;
		bool flag = false;
		try
		{
			if (flag)
			{
				MNaeYvDmEYpCfXkCQeOUjYOSmPdq mNaeYvDmEYpCfXkCQeOUjYOSmPdq = new MNaeYvDmEYpCfXkCQeOUjYOSmPdq();
				mNaeYvDmEYpCfXkCQeOUjYOSmPdq.xLnlaCLsyJiMputEzlpKwqUuijPQ = 0;
				P_2 = new fXHRBPluCVlFmVyDTJoQUtqLlMxB(flag, updateLoop, mFysooBDnintkjenedQcidKDFQgI, mNaeYvDmEYpCfXkCQeOUjYOSmPdq.KIQqGhOTKQrGzxTTNHCVQyFQHvVw, RwXGaNfGQTJprIjVggUsIjwqboHoA);
				RMgjoVzFWTlHFShEVsWFcpcyihBr.Add(2, P_2);
			}
			else
			{
				P_2 = new fXHRBPluCVlFmVyDTJoQUtqLlMxB(flag, updateLoop, mFysooBDnintkjenedQcidKDFQgI, HctHkHcGDQMimivORtYREmNMMIJEb, RwXGaNfGQTJprIjVggUsIjwqboHoA);
				RMgjoVzFWTlHFShEVsWFcpcyihBr.Add(2, P_2);
				P_2.DeviceConnectedEvent += dgYlFixFyuUQKEtMEuinEgvCOPsw;
				P_2.DeviceDisconnectedEvent += jaIEzseFxyOKzSUyJZJePQYZFWRqA;
				P_2.UpdateControllerInfoEvent += WRCdMWzMShKZLjttQBXFAQKlHkon;
			}
			return true;
		}
		catch
		{
			P_2 = null;
			if (P_1)
			{
				Logger.LogWarning("Unable to initialize XInput!");
			}
			else if (!flag)
			{
				P_0.useXInput = false;
				for (int i = 0; i < RMgjoVzFWTlHFShEVsWFcpcyihBr.get_Count(); i++)
				{
					if (RMgjoVzFWTlHFShEVsWFcpcyihBr[i] != null && RMgjoVzFWTlHFShEVsWFcpcyihBr[i] is veDKOByjfMbRGPFxWAoNvUWwrpDO veDKOByjfMbRGPFxWAoNvUWwrpDO2 && veDKOByjfMbRGPFxWAoNvUWwrpDO2.laAVmpydykZoloUrxIfSCUfKPqfV() != null && veDKOByjfMbRGPFxWAoNvUWwrpDO2.laAVmpydykZoloUrxIfSCUfKPqfV().JqKNlvkcgJmKzUKsMOMqlPmWJSJT() == XAWRDcWKMfgkHrgJeYMwQTZapuvQ.XInput)
					{
						veDKOByjfMbRGPFxWAoNvUWwrpDO2.kyMBajFBsNSFQjYcWHaSOoFWRIgVA(null);
					}
				}
				Logger.LogWarning("Unable to initialize XInput! XInput controllers will be handled by " + WeCyIkuUlMETUBjqPgbkDPOtiQjo.ToString() + " instead. Vibration is not supported and the L/R triggers are treated as a single axis and input cannot be detected when both are pressed simultaneously. ");
			}
			return false;
		}
	}

	private bool BrKQPWzSMZBZHiEJpiafvwDNhEuFA(ConfigVars P_0, bool P_1, out PlatformInputManager P_2)
	{
		_ = P_0.updateLoop;
		if (!(P_0.GetPlatformVar_useWindowsGamingInput() | P_1))
		{
			P_2 = null;
			return false;
		}
		try
		{
			P_2 = new lsJGfThJlvSyvBFmkipsOcDxinbXA(P_0, mFysooBDnintkjenedQcidKDFQgI, HctHkHcGDQMimivORtYREmNMMIJEb, RwXGaNfGQTJprIjVggUsIjwqboHoA);
			if (P_1)
			{
				lqsVVzFzvUJogedEbUKLzvvdNfAy = P_2;
			}
			RMgjoVzFWTlHFShEVsWFcpcyihBr.Add(30, P_2);
			P_2.DeviceConnectedEvent += dgYlFixFyuUQKEtMEuinEgvCOPsw;
			P_2.DeviceDisconnectedEvent += jaIEzseFxyOKzSUyJZJePQYZFWRqA;
			P_2.UpdateControllerInfoEvent += WRCdMWzMShKZLjttQBXFAQKlHkon;
			return true;
		}
		catch (Exception)
		{
			P_2 = null;
			if (!P_1)
			{
				P_0.SetPlatformVar_useWindowsGamingInput(value: false);
				for (int i = 0; i < RMgjoVzFWTlHFShEVsWFcpcyihBr.get_Count(); i++)
				{
					if (RMgjoVzFWTlHFShEVsWFcpcyihBr[i] != null && RMgjoVzFWTlHFShEVsWFcpcyihBr[i] is veDKOByjfMbRGPFxWAoNvUWwrpDO veDKOByjfMbRGPFxWAoNvUWwrpDO2 && veDKOByjfMbRGPFxWAoNvUWwrpDO2.laAVmpydykZoloUrxIfSCUfKPqfV() != null && veDKOByjfMbRGPFxWAoNvUWwrpDO2.laAVmpydykZoloUrxIfSCUfKPqfV().JqKNlvkcgJmKzUKsMOMqlPmWJSJT() == XAWRDcWKMfgkHrgJeYMwQTZapuvQ.WindowsGamingInput)
					{
						veDKOByjfMbRGPFxWAoNvUWwrpDO2.kyMBajFBsNSFQjYcWHaSOoFWRIgVA(null);
					}
				}
			}
			Logger.LogWarning("Unable to initialize Windows Gaming Input! ");
			return false;
		}
	}

	public virtual int get_deviceCount()
	{
		return YHIzNhiiTTzajXwsTjWzQbmyQqKG.gthuahZvDpULFjESmaXXBFfopRuT();
	}

	public virtual PlatformInputManager get_primaryInputManager()
	{
		return lqsVVzFzvUJogedEbUKLzvvdNfAy;
	}

	public virtual IInputSource get_inputSource()
	{
		return lqsVVzFzvUJogedEbUKLzvvdNfAy.inputSource;
	}

	public virtual InputSource get_inputSourceType()
	{
		if (lqsVVzFzvUJogedEbUKLzvvdNfAy == null)
		{
			return InputSource.None;
		}
		return lqsVVzFzvUJogedEbUKLzvvdNfAy.inputSourceType;
	}

	[CustomObfuscation(rename = false)]
	public override void Initialize()
	{
		KnZcmQnLjUbPElhflvXoMHqFUUZm = true;
		YHIzNhiiTTzajXwsTjWzQbmyQqKG = new LAbYodZzHGCNHXOitKbTHIFBeZUZ();
		for (int i = 0; i < RMgjoVzFWTlHFShEVsWFcpcyihBr.get_Count(); i++)
		{
			RMgjoVzFWTlHFShEVsWFcpcyihBr[i].Initialize();
		}
	}

	public virtual void biJyGRTGyfHKuUMxqkYUSXrAexov(UpdateLoopType P_0)
	{
		for (int i = 0; i < RMgjoVzFWTlHFShEVsWFcpcyihBr.get_Count(); i++)
		{
			RMgjoVzFWTlHFShEVsWFcpcyihBr[i].Update(P_0);
		}
	}

	[CustomObfuscation(rename = false)]
	public override void OnDestroy()
	{
		for (int num = RMgjoVzFWTlHFShEVsWFcpcyihBr.get_Count() - 1; num >= 0; num--)
		{
			RMgjoVzFWTlHFShEVsWFcpcyihBr[num].OnDestroy();
		}
		RMgjoVzFWTlHFShEVsWFcpcyihBr.Clear();
		if (ifQoEwrgxZJMnpoFLbCxWjKJjOel != null)
		{
			ifQoEwrgxZJMnpoFLbCxWjKJjOel.NMGYqfXAGoPdNSaoivoxIePmbgce();
			ifQoEwrgxZJMnpoFLbCxWjKJjOel = null;
		}
		hmRdjlkkAraUbAOZelrfFnsoEfpCB.KOnwyEovHmoEZalpYSkBCiXsRTpA();
	}

	[CustomObfuscation(rename = false)]
	public override Action<int, ControllerDataUpdater> GetInputDataUpdateDelegate()
	{
		return GFsGHGSxsrVyZmmANmCHqIUWzmrc;
	}

	[CustomObfuscation(rename = false)]
	public override void UpdateControllerData(int controllerId, ControllerDataUpdater data)
	{
		RMgjoVzFWTlHFShEVsWFcpcyihBr.GetValue((int)data.source).UpdateControllerData(YHIzNhiiTTzajXwsTjWzQbmyQqKG.wWgICzdHlMyxlJfUmlrPNzzbYBdb(controllerId, data.source, LAbYodZzHGCNHXOitKbTHIFBeZUZ.UjZooOmuOQawXYLsilOJdoYtGMNfA.Connected), data);
	}

	[CustomObfuscation(rename = false)]
	public override void SystemDeviceConnected()
	{
	}

	[CustomObfuscation(rename = false)]
	public override void SystemDeviceDisconnected()
	{
	}

	[CustomObfuscation(rename = false)]
	public override void SetUnityJoystickId(int joystickId, int unityJoystickId)
	{
	}

	[CustomObfuscation(rename = false)]
	public override IUnifiedMouseSource GetUnifiedMouseSource()
	{
		for (int i = 0; i < RMgjoVzFWTlHFShEVsWFcpcyihBr.get_Count(); i++)
		{
			IUnifiedMouseSource unifiedMouseSource = RMgjoVzFWTlHFShEVsWFcpcyihBr[i].GetUnifiedMouseSource();
			if (unifiedMouseSource != null)
			{
				return unifiedMouseSource;
			}
		}
		return null;
	}

	[CustomObfuscation(rename = false)]
	public override IUnifiedKeyboardSource GetUnifiedKeyboardSource()
	{
		for (int i = 0; i < RMgjoVzFWTlHFShEVsWFcpcyihBr.get_Count(); i++)
		{
			IUnifiedKeyboardSource unifiedKeyboardSource = RMgjoVzFWTlHFShEVsWFcpcyihBr[i].GetUnifiedKeyboardSource();
			if (unifiedKeyboardSource != null)
			{
				return unifiedKeyboardSource;
			}
		}
		return null;
	}

	private void dgYlFixFyuUQKEtMEuinEgvCOPsw(BridgedController P_0)
	{
		if (P_0 != null)
		{
			YHIzNhiiTTzajXwsTjWzQbmyQqKG.GjYAgcsgyVvEDZKaOAzhzvPrqkLF(P_0);
			if (_DeviceConnectedEvent != null)
			{
				_DeviceConnectedEvent(P_0);
			}
		}
	}

	private void jaIEzseFxyOKzSUyJZJePQYZFWRqA(ControllerDisconnectedEventArgs P_0)
	{
		if (P_0 != null)
		{
			YHIzNhiiTTzajXwsTjWzQbmyQqKG.bSIFKnjrkAqfyuvLufYvhcrMdWqV(P_0);
			if (_DeviceDisconnectedEvent != null)
			{
				_DeviceDisconnectedEvent(P_0);
			}
		}
	}

	private void uyEVgOQgnTcHNSxBBvTMnWyMngLC(EventArgs P_0)
	{
		if (KnZcmQnLjUbPElhflvXoMHqFUUZm)
		{
			for (int i = 0; i < RMgjoVzFWTlHFShEVsWFcpcyihBr.get_Count(); i++)
			{
				RMgjoVzFWTlHFShEVsWFcpcyihBr[i].SystemDeviceConnected();
			}
		}
	}

	private void WnqjNjXqrphwwzapbOMGCLzyauTY(EventArgs P_0)
	{
		if (KnZcmQnLjUbPElhflvXoMHqFUUZm)
		{
			for (int i = 0; i < RMgjoVzFWTlHFShEVsWFcpcyihBr.get_Count(); i++)
			{
				RMgjoVzFWTlHFShEVsWFcpcyihBr[i].SystemDeviceDisconnected();
			}
		}
	}

	private void WRCdMWzMShKZLjttQBXFAQKlHkon(UpdateControllerInfoEventArgs P_0)
	{
		if (P_0 == null || P_0.sourceJoystick == null)
		{
			return;
		}
		YHIzNhiiTTzajXwsTjWzQbmyQqKG.LfGRCbsQVqGgDtnffsJREdUAWHIK(P_0.sourceJoystick.rewiredId, P_0.sourceJoystick.inputManagerId);
		LAbYodZzHGCNHXOitKbTHIFBeZUZ.UjZooOmuOQawXYLsilOJdoYtGMNfA ujZooOmuOQawXYLsilOJdoYtGMNfA = LAbYodZzHGCNHXOitKbTHIFBeZUZ.UjZooOmuOQawXYLsilOJdoYtGMNfA.Connected;
		int num = YHIzNhiiTTzajXwsTjWzQbmyQqKG.agSbyQDCdPzJASgHNCApXYUxCuyjA(P_0.sourceJoystick.rewiredId, ujZooOmuOQawXYLsilOJdoYtGMNfA);
		if (num < 0)
		{
			ujZooOmuOQawXYLsilOJdoYtGMNfA = LAbYodZzHGCNHXOitKbTHIFBeZUZ.UjZooOmuOQawXYLsilOJdoYtGMNfA.Disconnected;
			num = YHIzNhiiTTzajXwsTjWzQbmyQqKG.agSbyQDCdPzJASgHNCApXYUxCuyjA(P_0.sourceJoystick.rewiredId, ujZooOmuOQawXYLsilOJdoYtGMNfA);
		}
		if (num >= 0)
		{
			LAbYodZzHGCNHXOitKbTHIFBeZUZ.TUKrFrfqXtiSNrykTMlufGiSDbYjA tUKrFrfqXtiSNrykTMlufGiSDbYjA = YHIzNhiiTTzajXwsTjWzQbmyQqKG.lCVZJHGSjvNciNSZWzgrfCouHLTG(num, ujZooOmuOQawXYLsilOJdoYtGMNfA);
			if (_UpdateControllerInfoEvent != null)
			{
				_UpdateControllerInfoEvent(new UpdateControllerInfoEventArgs(new KqCTMbyNrKlMXZszQEIljCtPuBYj(P_0.sourceJoystick, tUKrFrfqXtiSNrykTMlufGiSDbYjA.oMuyONMhZBSMeqmPJtgxOTmKBVWJ)));
			}
		}
	}
}
