using System;
using System.Collections.Generic;
using Rewired.Config;
using Rewired.Platforms;
using Rewired.Utils;

namespace Rewired.HID.Drivers;

[CustomObfuscation(rename = false)]
[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
internal abstract class HIDDeviceDriver : IControllerDriver, IDisposable
{
	[CustomObfuscation(rename = false)]
	public enum DriverType
	{
		None = 0,
		DualShock4 = 1,
		DualSense = 2,
		RailDriver = 3,
		SwitchJoyConLeft = 4,
		SwitchJoyConRight = 5,
		SwitchProController = 6
	}

	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal struct HIDProperties(ushort P_0, ushort P_1, string P_2, string P_3, ushort P_4, ushort P_5, int P_6, int P_7, int P_8)
	{
		public ushort vendorId = P_0;

		public ushort productId = P_1;

		public string productName = P_2;

		public string manufacturer = P_3;

		public ushort usagePage = P_4;

		public ushort usage = P_5;

		public int maxInputReportLength = P_6;

		public int maxOutputReportLength = P_7;

		public int maxFeatureReportLength = P_8;
	}

	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal interface IHIDDevice
	{
		HIDProperties properties { get; }

		bool WriteSync(YgqnhctsoyAiZixKeAsniiZNPqQeA outputReport, int timeoutMs);

		void WriteAsync(YgqnhctsoyAiZixKeAsniiZNPqQeA outputReport, int timeoutMs);

		bool ReadSync(IntPtr buffer, int bytesToRead, int timeoutMs);

		byte[] GetHidFeatureData(byte reportId, int reportLength, int timeoutMs, int retryCount);
	}

	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class InitArgs
	{
		public readonly UpdateLoopSetting updateLoopSetting;

		public readonly mcGCOmKmWTEVYWVKfxUduOlekNVWA connectionType;

		public readonly int minAxisValue;

		public readonly int maxAxisValue;

		public readonly int hatZeroValue;

		public readonly int hatSpan;

		public readonly IHIDDevice hidDevice;

		public InitArgs(UpdateLoopSetting P_0, mcGCOmKmWTEVYWVKfxUduOlekNVWA P_1, int P_2, int P_3, int P_4, int P_5, IHIDDevice P_6)
		{
			updateLoopSetting = P_0;
			connectionType = P_1;
			minAxisValue = P_2;
			maxAxisValue = P_3;
			hatZeroValue = P_4;
			hatSpan = P_5;
			hidDevice = P_6;
		}
	}

	public CZoMFTjfkBKcdHwbjLAHvGhrFKlm[] axes;

	public zcGvJvonyWXVMOLIHiTlBSzzCQP[] buttons;

	public yVtJYaXVmlAkOpMlEdRssBJtGidG[] hats;

	public PuNiRanhRtGcawmdkdYFXXryaDNI[] accelerometers;

	public HzWNjGbJTcqWRFLBLnqFlnsJEvnz[] gyroscopes;

	public nLbAcapOagdnNrGGiTONDGTEQuzQ[] touchpads;

	public UJKgOyiCpkBVwnefNmaagmCQWRFGb[] vibrationMotors;

	public HzYEQAmIRNSiWjhheMaNLEiYjqKH[] lights;

	private bool huEqLpNbGUQYigoPeVPRDkirCgBn;

	int IControllerDriver.AxisCount => get_AxisCount();

	int IControllerDriver.ButtonCount => get_ButtonCount();

	int IControllerDriver.HatCount => get_HatCount();

	int IControllerDriver.AccelerometerCount => get_AccelerometerCount();

	int IControllerDriver.GyroscopeCount => get_GyroscopeCount();

	int IControllerDriver.TouchpadCount => get_TouchpadCount();

	int IControllerDriver.LightCount => get_LightCount();

	int IControllerDriver.VibrationMotorCount => get_VibrationMotorCount();

	protected bool disposed => huEqLpNbGUQYigoPeVPRDkirCgBn;

	public int get_AxisCount()
	{
		if (axes == null)
		{
			return 0;
		}
		return axes.Length;
	}

	public int get_ButtonCount()
	{
		if (buttons == null)
		{
			return 0;
		}
		return buttons.Length;
	}

	public int get_HatCount()
	{
		if (hats == null)
		{
			return 0;
		}
		return hats.Length;
	}

	public int get_AccelerometerCount()
	{
		if (accelerometers == null)
		{
			return 0;
		}
		return accelerometers.Length;
	}

	public int get_GyroscopeCount()
	{
		if (gyroscopes == null)
		{
			return 0;
		}
		return gyroscopes.Length;
	}

	public int get_TouchpadCount()
	{
		if (touchpads == null)
		{
			return 0;
		}
		return touchpads.Length;
	}

	public int get_LightCount()
	{
		if (lights == null)
		{
			return 0;
		}
		return lights.Length;
	}

	public int get_VibrationMotorCount()
	{
		if (vibrationMotors == null)
		{
			return 0;
		}
		return vibrationMotors.Length;
	}

	public HIDDeviceDriver()
	{
	}

	public abstract void Update(UpdateLoopType updateLoop);

	public abstract bool ParseInputReport(IntPtr inputReportPtr, int inputReportLength, double timestamp);

	public abstract Controller.Extension CreateControllerExtension();

	public static HIDDeviceDriver GetDriver(DriverType driverId, InitArgs hidDriverInitArgs)
	{
		if (hidDriverInitArgs == null)
		{
			return null;
		}
		switch (driverId)
		{
		case DriverType.DualShock4:
			if (UnityTools.effectivePlatform == Platform.Linux)
			{
				return null;
			}
			return new DualShock4Driver(hidDriverInitArgs);
		case DriverType.DualSense:
			return new DualSenseDriver(hidDriverInitArgs);
		case DriverType.RailDriver:
			return new RailDriverDriver(hidDriverInitArgs);
		case DriverType.SwitchJoyConLeft:
			return new NintendoSwitchJoyConLeftDriver(hidDriverInitArgs);
		case DriverType.SwitchJoyConRight:
			return new SwitchJoyConRightDriver(hidDriverInitArgs);
		case DriverType.SwitchProController:
			if (hidDriverInitArgs.connectionType != mcGCOmKmWTEVYWVKfxUduOlekNVWA.Bluetooth)
			{
				return null;
			}
			return new NintendoSwitchProControllerDriver(hidDriverInitArgs);
		default:
			return null;
		}
	}

	public static DriverType FindDriverId(int vendorId, int productId, IList<EnhancedDeviceSupportDeviceType> exclusions)
	{
		if (DualShock4Driver.Matches(vendorId, productId))
		{
			if (exclusions != null && exclusions.Contains(EnhancedDeviceSupportDeviceType.SonyDualShock4))
			{
				return DriverType.None;
			}
			return DriverType.DualShock4;
		}
		if (DualSenseDriver.Matches(vendorId, productId))
		{
			if (exclusions != null && exclusions.Contains(EnhancedDeviceSupportDeviceType.SonyDualSense))
			{
				return DriverType.None;
			}
			return DriverType.DualSense;
		}
		if (RailDriverDriver.Matches(vendorId, productId))
		{
			if (exclusions != null && exclusions.Contains(EnhancedDeviceSupportDeviceType.PIEngineeringRailDriver))
			{
				return DriverType.None;
			}
			return DriverType.RailDriver;
		}
		if (NintendoSwitchJoyConLeftDriver.Matches(vendorId, productId))
		{
			if (exclusions != null && exclusions.Contains(EnhancedDeviceSupportDeviceType.NintendoSwitchJoyConLeft))
			{
				return DriverType.None;
			}
			return DriverType.SwitchJoyConLeft;
		}
		if (SwitchJoyConRightDriver.Matches(vendorId, productId))
		{
			if (exclusions != null && exclusions.Contains(EnhancedDeviceSupportDeviceType.NintendoSwitchJoyConRight))
			{
				return DriverType.None;
			}
			return DriverType.SwitchJoyConRight;
		}
		if (NintendoSwitchProControllerDriver.Matches(vendorId, productId))
		{
			if (exclusions != null && exclusions.Contains(EnhancedDeviceSupportDeviceType.NintendoSwitchProController))
			{
				return DriverType.None;
			}
			return DriverType.SwitchProController;
		}
		return DriverType.None;
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

	~HIDDeviceDriver()
	{
		Dispose(disposing: false);
	}

	protected virtual void Dispose(bool disposing)
	{
		if (!huEqLpNbGUQYigoPeVPRDkirCgBn)
		{
			huEqLpNbGUQYigoPeVPRDkirCgBn = true;
		}
	}
}
