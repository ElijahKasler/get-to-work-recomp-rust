using System;
using Rewired.ControllerExtensions;
using Rewired.Interfaces;

namespace Rewired.Platforms.Windows.DirectInput;

[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
public sealed class DirectInputControllerExtension : Controller.Extension, IHIDControllerExtension
{
	private class BpSBthHLJsrNsRRLfuxVPGpREjJbb : IControllerExtensionSource
	{
		private cQBxMAHukbVUZQupSRBOiSlaiust bRRBYoucXLrmGjkLmcSXMFHAhXtCA;

		private LVhCuZyklhtvrivECnmEWeidvpmW UKhBncqxflxzHjIfgveotbODjCJIA;

		public cQBxMAHukbVUZQupSRBOiSlaiust PINEAWhDlSGSIEQoUAJFwLxxXRsKA => kVkiqBLwmvjbzCqJMsyWpAPfCEyEA();

		public LVhCuZyklhtvrivECnmEWeidvpmW OcIBRYBNlSsDCPKblKWtoBwouVSj => IACaYwEhrosVtMlcQOlqHNYJpGbbA();

		public cQBxMAHukbVUZQupSRBOiSlaiust kVkiqBLwmvjbzCqJMsyWpAPfCEyEA()
		{
			return bRRBYoucXLrmGjkLmcSXMFHAhXtCA;
		}

		public LVhCuZyklhtvrivECnmEWeidvpmW IACaYwEhrosVtMlcQOlqHNYJpGbbA()
		{
			return UKhBncqxflxzHjIfgveotbODjCJIA;
		}

		public BpSBthHLJsrNsRRLfuxVPGpREjJbb(cQBxMAHukbVUZQupSRBOiSlaiust P_0, LVhCuZyklhtvrivECnmEWeidvpmW P_1)
		{
			bRRBYoucXLrmGjkLmcSXMFHAhXtCA = P_0;
			UKhBncqxflxzHjIfgveotbODjCJIA = P_1;
		}
	}

	private BpSBthHLJsrNsRRLfuxVPGpREjJbb rNFquZKbPCpAzvLNAWfwpGNCYMEX;

	private bool ZaUrCBNzcVfIghDWXUlfsuBNyuVl;

	private Joystick joystick => LfFuLUIJLWCeTIIljWYGiWARGaKCA();

	public Guid instanceGuid
	{
		get
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return Guid.Empty;
			}
			if (!ZaUrCBNzcVfIghDWXUlfsuBNyuVl || !base.enabled)
			{
				return Guid.Empty;
			}
			if (rNFquZKbPCpAzvLNAWfwpGNCYMEX.IACaYwEhrosVtMlcQOlqHNYJpGbbA() == null)
			{
				return Guid.Empty;
			}
			return rNFquZKbPCpAzvLNAWfwpGNCYMEX.kVkiqBLwmvjbzCqJMsyWpAPfCEyEA().OlWJPSagxOemyFmiXRXAAqoAkMpib;
		}
	}

	public Guid productGuid
	{
		get
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return Guid.Empty;
			}
			if (!ZaUrCBNzcVfIghDWXUlfsuBNyuVl || !base.enabled)
			{
				return Guid.Empty;
			}
			if (rNFquZKbPCpAzvLNAWfwpGNCYMEX.IACaYwEhrosVtMlcQOlqHNYJpGbbA() == null)
			{
				return Guid.Empty;
			}
			return rNFquZKbPCpAzvLNAWfwpGNCYMEX.kVkiqBLwmvjbzCqJMsyWpAPfCEyEA().yEXnHNQgkgjqFmjHlzhzLVpNUShG;
		}
	}

	public string instanceName
	{
		get
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return string.Empty;
			}
			if (!ZaUrCBNzcVfIghDWXUlfsuBNyuVl || !base.enabled)
			{
				return string.Empty;
			}
			return rNFquZKbPCpAzvLNAWfwpGNCYMEX.IACaYwEhrosVtMlcQOlqHNYJpGbbA().XNgCRWFEXAlAiaivgeZScZsgbRKkD().pLdHLRUbbbFwcveyuljjrUuvnWNB();
		}
	}

	string IHIDControllerExtension.productName => get_productName();

	public Guid forceFeedbackDriverGuid
	{
		get
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return Guid.Empty;
			}
			if (!ZaUrCBNzcVfIghDWXUlfsuBNyuVl || !base.enabled)
			{
				return Guid.Empty;
			}
			if (rNFquZKbPCpAzvLNAWfwpGNCYMEX.IACaYwEhrosVtMlcQOlqHNYJpGbbA() == null)
			{
				return Guid.Empty;
			}
			return rNFquZKbPCpAzvLNAWfwpGNCYMEX.kVkiqBLwmvjbzCqJMsyWpAPfCEyEA().TYcDeHQXdIWPGhlAMMZOCcZhDzZeA;
		}
	}

	ushort IHIDControllerExtension.usagePage => get_usagePage();

	ushort IHIDControllerExtension.usage => get_usage();

	public DirectInputDeviceType deviceType
	{
		get
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return DirectInputDeviceType.Device;
			}
			if (!ZaUrCBNzcVfIghDWXUlfsuBNyuVl || !base.enabled)
			{
				return DirectInputDeviceType.Device;
			}
			if (rNFquZKbPCpAzvLNAWfwpGNCYMEX.IACaYwEhrosVtMlcQOlqHNYJpGbbA() == null)
			{
				return DirectInputDeviceType.Device;
			}
			return (DirectInputDeviceType)rNFquZKbPCpAzvLNAWfwpGNCYMEX.kVkiqBLwmvjbzCqJMsyWpAPfCEyEA().wFWVbBjhNmWDaykSmdMXvaaUMdEQ();
		}
	}

	public int deviceSubtype
	{
		get
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return 0;
			}
			if (!ZaUrCBNzcVfIghDWXUlfsuBNyuVl || !base.enabled)
			{
				return 0;
			}
			if (rNFquZKbPCpAzvLNAWfwpGNCYMEX.IACaYwEhrosVtMlcQOlqHNYJpGbbA() == null)
			{
				return 0;
			}
			return rNFquZKbPCpAzvLNAWfwpGNCYMEX.kVkiqBLwmvjbzCqJMsyWpAPfCEyEA().LSjdDFGdiJLJfXCMYjIuTFhKegzb();
		}
	}

	public int rawType
	{
		get
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return 0;
			}
			if (!ZaUrCBNzcVfIghDWXUlfsuBNyuVl || !base.enabled)
			{
				return 0;
			}
			if (rNFquZKbPCpAzvLNAWfwpGNCYMEX.IACaYwEhrosVtMlcQOlqHNYJpGbbA() == null)
			{
				return 0;
			}
			return rNFquZKbPCpAzvLNAWfwpGNCYMEX.kVkiqBLwmvjbzCqJMsyWpAPfCEyEA().WlrtbpjbRsuEHCIDZgoLOMAzoeQp;
		}
	}

	public bool isHumanInterfaceDevice
	{
		get
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return false;
			}
			if (!ZaUrCBNzcVfIghDWXUlfsuBNyuVl || !base.enabled)
			{
				return false;
			}
			if (rNFquZKbPCpAzvLNAWfwpGNCYMEX.IACaYwEhrosVtMlcQOlqHNYJpGbbA() == null)
			{
				return false;
			}
			return rNFquZKbPCpAzvLNAWfwpGNCYMEX.kVkiqBLwmvjbzCqJMsyWpAPfCEyEA().HNrUNwsTKWScwPOGZxOXFZHPMZyf();
		}
	}

	public DirectInputDeviceAxisMode axisMode
	{
		get
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return DirectInputDeviceAxisMode.Absolute;
			}
			if (!ZaUrCBNzcVfIghDWXUlfsuBNyuVl || !base.enabled)
			{
				return DirectInputDeviceAxisMode.Absolute;
			}
			return (DirectInputDeviceAxisMode)rNFquZKbPCpAzvLNAWfwpGNCYMEX.IACaYwEhrosVtMlcQOlqHNYJpGbbA().XNgCRWFEXAlAiaivgeZScZsgbRKkD().BYbGDmhRtRXVdBdlhysyjOeCYmaH();
		}
	}

	public int bufferSize
	{
		get
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return 0;
			}
			if (!ZaUrCBNzcVfIghDWXUlfsuBNyuVl || !base.enabled)
			{
				return 0;
			}
			return rNFquZKbPCpAzvLNAWfwpGNCYMEX.IACaYwEhrosVtMlcQOlqHNYJpGbbA().XNgCRWFEXAlAiaivgeZScZsgbRKkD().IHHdhoySFzKgkrZXuPTvEIkZRpcB();
		}
	}

	public Guid classGuid
	{
		get
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return Guid.Empty;
			}
			if (!ZaUrCBNzcVfIghDWXUlfsuBNyuVl || !base.enabled)
			{
				return Guid.Empty;
			}
			return rNFquZKbPCpAzvLNAWfwpGNCYMEX.IACaYwEhrosVtMlcQOlqHNYJpGbbA().XNgCRWFEXAlAiaivgeZScZsgbRKkD().wptiNKTTfsAeghVQSFhZnktvmjnl();
		}
	}

	public int forceFeedbackGain
	{
		get
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return 0;
			}
			if (!ZaUrCBNzcVfIghDWXUlfsuBNyuVl || !base.enabled)
			{
				return 0;
			}
			return rNFquZKbPCpAzvLNAWfwpGNCYMEX.IACaYwEhrosVtMlcQOlqHNYJpGbbA().XNgCRWFEXAlAiaivgeZScZsgbRKkD().KgODvZXHyytjpisHqBBdZjeXFBCU();
		}
		set
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else if (ZaUrCBNzcVfIghDWXUlfsuBNyuVl && base.enabled)
			{
				rNFquZKbPCpAzvLNAWfwpGNCYMEX.IACaYwEhrosVtMlcQOlqHNYJpGbbA().XNgCRWFEXAlAiaivgeZScZsgbRKkD().hNxygQtypOABvaPWwmAanPPRJacO(value);
			}
		}
	}

	public string interfacePath
	{
		get
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return string.Empty;
			}
			if (!ZaUrCBNzcVfIghDWXUlfsuBNyuVl || !base.enabled)
			{
				return string.Empty;
			}
			return rNFquZKbPCpAzvLNAWfwpGNCYMEX.IACaYwEhrosVtMlcQOlqHNYJpGbbA().XNgCRWFEXAlAiaivgeZScZsgbRKkD().pVlpwcLGBkbikAgmSLUYelnbGRAHB();
		}
	}

	public int joystickId
	{
		get
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return 0;
			}
			if (!ZaUrCBNzcVfIghDWXUlfsuBNyuVl || !base.enabled)
			{
				return 0;
			}
			return rNFquZKbPCpAzvLNAWfwpGNCYMEX.IACaYwEhrosVtMlcQOlqHNYJpGbbA().XNgCRWFEXAlAiaivgeZScZsgbRKkD().aqweBiaNWbIMmSsWSHDKpHSybhBFb();
		}
	}

	ushort IHIDControllerExtension.productId => get_productId();

	ushort IHIDControllerExtension.vendorId => get_vendorId();

	string IHIDControllerExtension.manufacturer => string.Empty;

	private Joystick LfFuLUIJLWCeTIIljWYGiWARGaKCA()
	{
		return GetController<Joystick>();
	}

	internal DirectInputControllerExtension(cQBxMAHukbVUZQupSRBOiSlaiust P_0, LVhCuZyklhtvrivECnmEWeidvpmW P_1)
		: base(new BpSBthHLJsrNsRRLfuxVPGpREjJbb(P_0, P_1))
	{
	}

	private DirectInputControllerExtension(DirectInputControllerExtension P_0)
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
		if (!ZaUrCBNzcVfIghDWXUlfsuBNyuVl || !base.enabled)
		{
			return string.Empty;
		}
		return rNFquZKbPCpAzvLNAWfwpGNCYMEX.IACaYwEhrosVtMlcQOlqHNYJpGbbA().XNgCRWFEXAlAiaivgeZScZsgbRKkD().UgrfKhLfUMgNWbUHIgHTpJtddlcVA();
	}

	public ushort get_usagePage()
	{
		if (ReInput._id != _reInputId)
		{
			ReInput.CheckInitialized(_reInputId);
			return 0;
		}
		if (!ZaUrCBNzcVfIghDWXUlfsuBNyuVl || !base.enabled)
		{
			return 0;
		}
		if (rNFquZKbPCpAzvLNAWfwpGNCYMEX.IACaYwEhrosVtMlcQOlqHNYJpGbbA() == null)
		{
			return 0;
		}
		return rNFquZKbPCpAzvLNAWfwpGNCYMEX.kVkiqBLwmvjbzCqJMsyWpAPfCEyEA().yjsOHNPhCZganElhGknPCaAdkCiqb;
	}

	public ushort get_usage()
	{
		if (ReInput._id != _reInputId)
		{
			ReInput.CheckInitialized(_reInputId);
			return 0;
		}
		if (!ZaUrCBNzcVfIghDWXUlfsuBNyuVl || !base.enabled)
		{
			return 0;
		}
		if (rNFquZKbPCpAzvLNAWfwpGNCYMEX.IACaYwEhrosVtMlcQOlqHNYJpGbbA() == null)
		{
			return 0;
		}
		return rNFquZKbPCpAzvLNAWfwpGNCYMEX.kVkiqBLwmvjbzCqJMsyWpAPfCEyEA().GLDqIkElRXDveSDwJWiozEqXCSThA;
	}

	public ushort get_productId()
	{
		if (ReInput._id != _reInputId)
		{
			ReInput.CheckInitialized(_reInputId);
			return 0;
		}
		if (!ZaUrCBNzcVfIghDWXUlfsuBNyuVl || !base.enabled)
		{
			return 0;
		}
		return (ushort)rNFquZKbPCpAzvLNAWfwpGNCYMEX.IACaYwEhrosVtMlcQOlqHNYJpGbbA().XNgCRWFEXAlAiaivgeZScZsgbRKkD().tnfeEXhTjjHXygAIfrrHoViwKtmVb();
	}

	public ushort get_vendorId()
	{
		if (ReInput._id != _reInputId)
		{
			ReInput.CheckInitialized(_reInputId);
			return 0;
		}
		if (!ZaUrCBNzcVfIghDWXUlfsuBNyuVl || !base.enabled)
		{
			return 0;
		}
		return (ushort)rNFquZKbPCpAzvLNAWfwpGNCYMEX.IACaYwEhrosVtMlcQOlqHNYJpGbbA().XNgCRWFEXAlAiaivgeZScZsgbRKkD().dXSBBTgYtKKIKhVDWlMQvdvAVtddA();
	}

	internal override void UpdateData(UpdateLoopType updateLoop)
	{
		if (ZaUrCBNzcVfIghDWXUlfsuBNyuVl)
		{
			_ = base.enabled;
		}
	}

	internal override void SourceUpdated(IControllerExtensionSource source)
	{
		rNFquZKbPCpAzvLNAWfwpGNCYMEX = source as BpSBthHLJsrNsRRLfuxVPGpREjJbb;
		ZaUrCBNzcVfIghDWXUlfsuBNyuVl = rNFquZKbPCpAzvLNAWfwpGNCYMEX != null;
	}

	internal override Controller.Extension Clone()
	{
		return new DirectInputControllerExtension(this);
	}
}
