using System;
using Rewired.ControllerExtensions;
using Rewired.Interfaces;

namespace Rewired.Platforms.Microsoft.WindowsGamingInput;

[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
public sealed class WindowsGamingInputControllerExtension : Controller.Extension, IHIDControllerExtension
{
	private class DHdQyFLqtGTgEaNFRLoYFMDqDBlCA : IControllerExtensionSource
	{
		private gmzcmYbFSNucJXQyYRMseSdXxgyb yUJXqVeFfxkUGsnyCEtogBjKrXXl;

		public gmzcmYbFSNucJXQyYRMseSdXxgyb DETjlpWRyLFFNWExZkfZzfUVtaQU => PmxHlYKOPmcRIjLNJQEVJgKqOmTpA();

		public gmzcmYbFSNucJXQyYRMseSdXxgyb PmxHlYKOPmcRIjLNJQEVJgKqOmTpA()
		{
			return yUJXqVeFfxkUGsnyCEtogBjKrXXl;
		}

		public DHdQyFLqtGTgEaNFRLoYFMDqDBlCA(gmzcmYbFSNucJXQyYRMseSdXxgyb P_0)
		{
			yUJXqVeFfxkUGsnyCEtogBjKrXXl = P_0;
		}
	}

	private DHdQyFLqtGTgEaNFRLoYFMDqDBlCA HzlNIXkIoPHOEAPBvmwSbGDzLRIyA;

	private bool BTmoceUhmDjiiIsTuzcPKdzWOQFSA;

	private Joystick joystick => RvfDtWGoYYHUcwdTkgTMiqTlrHXKA();

	public DeviceType deviceType => (DeviceType)HzlNIXkIoPHOEAPBvmwSbGDzLRIyA.PmxHlYKOPmcRIjLNJQEVJgKqOmTpA().KRRKBFVIVgyjSpRuqlaaKloYnnWr();

	public IntPtr nativePointer
	{
		get
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return IntPtr.Zero;
			}
			if (!BTmoceUhmDjiiIsTuzcPKdzWOQFSA || !base.enabled)
			{
				return IntPtr.Zero;
			}
			if (HzlNIXkIoPHOEAPBvmwSbGDzLRIyA.PmxHlYKOPmcRIjLNJQEVJgKqOmTpA() == null)
			{
				return IntPtr.Zero;
			}
			return HzlNIXkIoPHOEAPBvmwSbGDzLRIyA.PmxHlYKOPmcRIjLNJQEVJgKqOmTpA().PBceVzZRGZgmOiUfWxhSvaWNODaRA();
		}
	}

	public string nonRoamableId
	{
		get
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return string.Empty;
			}
			if (!BTmoceUhmDjiiIsTuzcPKdzWOQFSA || !base.enabled)
			{
				return string.Empty;
			}
			if (HzlNIXkIoPHOEAPBvmwSbGDzLRIyA.PmxHlYKOPmcRIjLNJQEVJgKqOmTpA() == null)
			{
				return string.Empty;
			}
			return HzlNIXkIoPHOEAPBvmwSbGDzLRIyA.PmxHlYKOPmcRIjLNJQEVJgKqOmTpA().zotkALoWdOQyaalZUQVCbOoJykpR();
		}
	}

	public bool isWireless
	{
		get
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return false;
			}
			if (!BTmoceUhmDjiiIsTuzcPKdzWOQFSA || !base.enabled)
			{
				return false;
			}
			if (HzlNIXkIoPHOEAPBvmwSbGDzLRIyA.PmxHlYKOPmcRIjLNJQEVJgKqOmTpA() == null)
			{
				return false;
			}
			return HzlNIXkIoPHOEAPBvmwSbGDzLRIyA.PmxHlYKOPmcRIjLNJQEVJgKqOmTpA().PlAzTKMsuKnskdwdTQWBPMFHzwLf();
		}
	}

	string IHIDControllerExtension.productName => get_productName();

	string IHIDControllerExtension.manufacturer => string.Empty;

	ushort IHIDControllerExtension.vendorId => get_vendorId();

	ushort IHIDControllerExtension.productId => get_productId();

	ushort IHIDControllerExtension.usagePage
	{
		get
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return 0;
			}
			if (!BTmoceUhmDjiiIsTuzcPKdzWOQFSA || !base.enabled)
			{
				return 0;
			}
			if (HzlNIXkIoPHOEAPBvmwSbGDzLRIyA.PmxHlYKOPmcRIjLNJQEVJgKqOmTpA() == null)
			{
				return 0;
			}
			return HzlNIXkIoPHOEAPBvmwSbGDzLRIyA.PmxHlYKOPmcRIjLNJQEVJgKqOmTpA().ChPybxtlFDOChqSstBqlZbpQjlqU();
		}
	}

	ushort IHIDControllerExtension.usage
	{
		get
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return 0;
			}
			if (!BTmoceUhmDjiiIsTuzcPKdzWOQFSA || !base.enabled)
			{
				return 0;
			}
			if (HzlNIXkIoPHOEAPBvmwSbGDzLRIyA.PmxHlYKOPmcRIjLNJQEVJgKqOmTpA() == null)
			{
				return 0;
			}
			return HzlNIXkIoPHOEAPBvmwSbGDzLRIyA.PmxHlYKOPmcRIjLNJQEVJgKqOmTpA().BFNbwYYytNOIKEJxzpMquJehkwXT();
		}
	}

	private Joystick RvfDtWGoYYHUcwdTkgTMiqTlrHXKA()
	{
		return GetController<Joystick>();
	}

	internal WindowsGamingInputControllerExtension(gmzcmYbFSNucJXQyYRMseSdXxgyb P_0)
		: base(new DHdQyFLqtGTgEaNFRLoYFMDqDBlCA(P_0))
	{
	}

	private WindowsGamingInputControllerExtension(WindowsGamingInputControllerExtension P_0)
		: base(P_0)
	{
	}

	public string get_productName()
	{
		if (ReInput._id != _reInputId)
		{
			ReInput.CheckInitialized(_reInputId);
			return string.Empty;
		}
		if (!BTmoceUhmDjiiIsTuzcPKdzWOQFSA || !base.enabled)
		{
			return string.Empty;
		}
		if (HzlNIXkIoPHOEAPBvmwSbGDzLRIyA.PmxHlYKOPmcRIjLNJQEVJgKqOmTpA() == null)
		{
			return string.Empty;
		}
		return HzlNIXkIoPHOEAPBvmwSbGDzLRIyA.PmxHlYKOPmcRIjLNJQEVJgKqOmTpA().tHeJWtPcoYzbOKNvRudWvqJzVxBL();
	}

	public ushort get_vendorId()
	{
		if (ReInput._id != _reInputId)
		{
			ReInput.CheckInitialized(_reInputId);
			return 0;
		}
		if (!BTmoceUhmDjiiIsTuzcPKdzWOQFSA || !base.enabled)
		{
			return 0;
		}
		if (HzlNIXkIoPHOEAPBvmwSbGDzLRIyA.PmxHlYKOPmcRIjLNJQEVJgKqOmTpA() == null)
		{
			return 0;
		}
		return HzlNIXkIoPHOEAPBvmwSbGDzLRIyA.PmxHlYKOPmcRIjLNJQEVJgKqOmTpA().hHlgCDjMNCWLvUrtCbYKwUcrWpcn().vendorId;
	}

	public ushort get_productId()
	{
		if (ReInput._id != _reInputId)
		{
			ReInput.CheckInitialized(_reInputId);
			return 0;
		}
		if (!BTmoceUhmDjiiIsTuzcPKdzWOQFSA || !base.enabled)
		{
			return 0;
		}
		if (HzlNIXkIoPHOEAPBvmwSbGDzLRIyA.PmxHlYKOPmcRIjLNJQEVJgKqOmTpA() == null)
		{
			return 0;
		}
		return HzlNIXkIoPHOEAPBvmwSbGDzLRIyA.PmxHlYKOPmcRIjLNJQEVJgKqOmTpA().hHlgCDjMNCWLvUrtCbYKwUcrWpcn().productId;
	}

	internal override void UpdateData(UpdateLoopType updateLoop)
	{
		if (BTmoceUhmDjiiIsTuzcPKdzWOQFSA)
		{
			_ = base.enabled;
		}
	}

	internal override void SourceUpdated(IControllerExtensionSource source)
	{
		HzlNIXkIoPHOEAPBvmwSbGDzLRIyA = source as DHdQyFLqtGTgEaNFRLoYFMDqDBlCA;
		BTmoceUhmDjiiIsTuzcPKdzWOQFSA = HzlNIXkIoPHOEAPBvmwSbGDzLRIyA != null;
	}

	internal override Controller.Extension Clone()
	{
		return new WindowsGamingInputControllerExtension(this);
	}
}
