using System;
using Rewired.ControllerExtensions;
using Rewired.Interfaces;

namespace Rewired.Platforms.Windows.RawInput;

[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
public sealed class RawInputControllerExtension : Controller.Extension, IHIDControllerExtension
{
	private class yzxIpncwEAPiWpAwqeqTKawLrNzS : IControllerExtensionSource
	{
		private ynlMXxJBAWxSUqlfMBtBGayIwpyh BiCtiFGZXtouQguPlaAKlPKssEAg;

		public ynlMXxJBAWxSUqlfMBtBGayIwpyh ipucbLwbikJsaxDBjzeOlNqzabNe => vZdotGtudycEoMGXlFfNtgcvucrc();

		public ynlMXxJBAWxSUqlfMBtBGayIwpyh vZdotGtudycEoMGXlFfNtgcvucrc()
		{
			return BiCtiFGZXtouQguPlaAKlPKssEAg;
		}

		public yzxIpncwEAPiWpAwqeqTKawLrNzS(ynlMXxJBAWxSUqlfMBtBGayIwpyh P_0)
		{
			BiCtiFGZXtouQguPlaAKlPKssEAg = P_0;
		}
	}

	private yzxIpncwEAPiWpAwqeqTKawLrNzS NBuSBFNGPcAJmdEZXjupEhrrhXaKA;

	private bool ktfJrltkCGnYjvoxqGZKoeeEMIDC;

	private Joystick joystick => CZtBjebElWATfANEQNPqxcYimihl();

	public IntPtr hidDeviceHandle
	{
		get
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return IntPtr.Zero;
			}
			if (!ktfJrltkCGnYjvoxqGZKoeeEMIDC || !base.enabled)
			{
				return IntPtr.Zero;
			}
			if (NBuSBFNGPcAJmdEZXjupEhrrhXaKA.vZdotGtudycEoMGXlFfNtgcvucrc() == null)
			{
				return IntPtr.Zero;
			}
			return NBuSBFNGPcAJmdEZXjupEhrrhXaKA.vZdotGtudycEoMGXlFfNtgcvucrc().HldEROsfjouWslmUEyVAeSKaUtrd().vaRFlAeftfeygrtdFHwbGfAGyLmTB();
		}
	}

	public IntPtr rawInputDeviceHandle
	{
		get
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return IntPtr.Zero;
			}
			if (!ktfJrltkCGnYjvoxqGZKoeeEMIDC || !base.enabled)
			{
				return IntPtr.Zero;
			}
			if (NBuSBFNGPcAJmdEZXjupEhrrhXaKA.vZdotGtudycEoMGXlFfNtgcvucrc() == null)
			{
				return IntPtr.Zero;
			}
			return NBuSBFNGPcAJmdEZXjupEhrrhXaKA.vZdotGtudycEoMGXlFfNtgcvucrc().sJWZsbBicDdFSSTzpPAzmXXtAVgr();
		}
	}

	public string devicePath
	{
		get
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return string.Empty;
			}
			if (!ktfJrltkCGnYjvoxqGZKoeeEMIDC || !base.enabled)
			{
				return string.Empty;
			}
			if (NBuSBFNGPcAJmdEZXjupEhrrhXaKA.vZdotGtudycEoMGXlFfNtgcvucrc() == null)
			{
				return string.Empty;
			}
			return NBuSBFNGPcAJmdEZXjupEhrrhXaKA.vZdotGtudycEoMGXlFfNtgcvucrc().HldEROsfjouWslmUEyVAeSKaUtrd().WFjPceWDyJnucLpfLZOwrGqClgAO();
		}
	}

	string IHIDControllerExtension.productName => get_productName();

	string IHIDControllerExtension.manufacturer => get_manufacturer();

	ushort IHIDControllerExtension.vendorId => get_vendorId();

	ushort IHIDControllerExtension.productId => get_productId();

	public Guid productGuid
	{
		get
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return Guid.Empty;
			}
			if (!ktfJrltkCGnYjvoxqGZKoeeEMIDC || !base.enabled)
			{
				return Guid.Empty;
			}
			if (NBuSBFNGPcAJmdEZXjupEhrrhXaKA.vZdotGtudycEoMGXlFfNtgcvucrc() == null)
			{
				return Guid.Empty;
			}
			return NBuSBFNGPcAJmdEZXjupEhrrhXaKA.vZdotGtudycEoMGXlFfNtgcvucrc().agosVptGdmYKOfzbFbPnoZnubZfb();
		}
	}

	public bool isBluetoothDevice
	{
		get
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return false;
			}
			if (!ktfJrltkCGnYjvoxqGZKoeeEMIDC || !base.enabled)
			{
				return false;
			}
			if (NBuSBFNGPcAJmdEZXjupEhrrhXaKA.vZdotGtudycEoMGXlFfNtgcvucrc() == null)
			{
				return false;
			}
			return NBuSBFNGPcAJmdEZXjupEhrrhXaKA.vZdotGtudycEoMGXlFfNtgcvucrc().MSDFgxmNTZqzpjINLLfOLKzHjFlS();
		}
	}

	public string bluetoothDeviceName
	{
		get
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return string.Empty;
			}
			if (!ktfJrltkCGnYjvoxqGZKoeeEMIDC || !base.enabled)
			{
				return string.Empty;
			}
			if (NBuSBFNGPcAJmdEZXjupEhrrhXaKA.vZdotGtudycEoMGXlFfNtgcvucrc() == null)
			{
				return string.Empty;
			}
			return NBuSBFNGPcAJmdEZXjupEhrrhXaKA.vZdotGtudycEoMGXlFfNtgcvucrc().KtRndMsDSENUeJRDGrPHjrJVqWgN();
		}
	}

	public int hubId
	{
		get
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return -1;
			}
			if (!ktfJrltkCGnYjvoxqGZKoeeEMIDC || !base.enabled)
			{
				return -1;
			}
			if (NBuSBFNGPcAJmdEZXjupEhrrhXaKA.vZdotGtudycEoMGXlFfNtgcvucrc() == null)
			{
				return -1;
			}
			return NBuSBFNGPcAJmdEZXjupEhrrhXaKA.vZdotGtudycEoMGXlFfNtgcvucrc().RlMAvNFJROaIkMNDrTLlrHNWpGhHA();
		}
	}

	public int portId
	{
		get
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return -1;
			}
			if (!ktfJrltkCGnYjvoxqGZKoeeEMIDC || !base.enabled)
			{
				return -1;
			}
			if (NBuSBFNGPcAJmdEZXjupEhrrhXaKA.vZdotGtudycEoMGXlFfNtgcvucrc() == null)
			{
				return -1;
			}
			return NBuSBFNGPcAJmdEZXjupEhrrhXaKA.vZdotGtudycEoMGXlFfNtgcvucrc().MvzeKdLKmsnjAerOvhSZCPHGVwjR();
		}
	}

	ushort IHIDControllerExtension.usagePage => get_usagePage();

	ushort IHIDControllerExtension.usage => get_usage();

	private Joystick CZtBjebElWATfANEQNPqxcYimihl()
	{
		return GetController<Joystick>();
	}

	internal RawInputControllerExtension(ynlMXxJBAWxSUqlfMBtBGayIwpyh P_0)
		: base(new yzxIpncwEAPiWpAwqeqTKawLrNzS(P_0))
	{
	}

	private RawInputControllerExtension(RawInputControllerExtension P_0)
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
		if (!ktfJrltkCGnYjvoxqGZKoeeEMIDC || !base.enabled)
		{
			return string.Empty;
		}
		if (NBuSBFNGPcAJmdEZXjupEhrrhXaKA.vZdotGtudycEoMGXlFfNtgcvucrc() == null)
		{
			return string.Empty;
		}
		return NBuSBFNGPcAJmdEZXjupEhrrhXaKA.vZdotGtudycEoMGXlFfNtgcvucrc().OBosFxHATcRnGpKxwAxrkbwgossk();
	}

	public string get_manufacturer()
	{
		if (ReInput._id != _reInputId)
		{
			ReInput.CheckInitialized(_reInputId);
			return string.Empty;
		}
		if (!ktfJrltkCGnYjvoxqGZKoeeEMIDC || !base.enabled)
		{
			return string.Empty;
		}
		if (NBuSBFNGPcAJmdEZXjupEhrrhXaKA.vZdotGtudycEoMGXlFfNtgcvucrc() == null)
		{
			return string.Empty;
		}
		return NBuSBFNGPcAJmdEZXjupEhrrhXaKA.vZdotGtudycEoMGXlFfNtgcvucrc().mobSWQxTdMerTIAVZviZQbBUDNNY();
	}

	public ushort get_vendorId()
	{
		if (ReInput._id != _reInputId)
		{
			ReInput.CheckInitialized(_reInputId);
			return 0;
		}
		if (!ktfJrltkCGnYjvoxqGZKoeeEMIDC || !base.enabled)
		{
			return 0;
		}
		if (NBuSBFNGPcAJmdEZXjupEhrrhXaKA.vZdotGtudycEoMGXlFfNtgcvucrc() == null)
		{
			return 0;
		}
		return (ushort)NBuSBFNGPcAJmdEZXjupEhrrhXaKA.vZdotGtudycEoMGXlFfNtgcvucrc().XPSCcDiSAwLvvCsQJFSsRyynfPkZA();
	}

	public ushort get_productId()
	{
		if (ReInput._id != _reInputId)
		{
			ReInput.CheckInitialized(_reInputId);
			return 0;
		}
		if (!ktfJrltkCGnYjvoxqGZKoeeEMIDC || !base.enabled)
		{
			return 0;
		}
		if (NBuSBFNGPcAJmdEZXjupEhrrhXaKA.vZdotGtudycEoMGXlFfNtgcvucrc() == null)
		{
			return 0;
		}
		return (ushort)NBuSBFNGPcAJmdEZXjupEhrrhXaKA.vZdotGtudycEoMGXlFfNtgcvucrc().xrMJnJVUEeiwuLWPrubKOBtBduOL();
	}

	public ushort get_usagePage()
	{
		if (ReInput._id != _reInputId)
		{
			ReInput.CheckInitialized(_reInputId);
			return 0;
		}
		if (!ktfJrltkCGnYjvoxqGZKoeeEMIDC || !base.enabled)
		{
			return 0;
		}
		if (NBuSBFNGPcAJmdEZXjupEhrrhXaKA.vZdotGtudycEoMGXlFfNtgcvucrc() == null)
		{
			return 0;
		}
		return (ushort)NBuSBFNGPcAJmdEZXjupEhrrhXaKA.vZdotGtudycEoMGXlFfNtgcvucrc().HldEROsfjouWslmUEyVAeSKaUtrd().DCDITUFElKaxOgCQcaRhktRwtpcSB()
			.aRLFGGePcKXaNuTSHTPRqrMtxAoc();
	}

	public ushort get_usage()
	{
		if (ReInput._id != _reInputId)
		{
			ReInput.CheckInitialized(_reInputId);
			return 0;
		}
		if (!ktfJrltkCGnYjvoxqGZKoeeEMIDC || !base.enabled)
		{
			return 0;
		}
		if (NBuSBFNGPcAJmdEZXjupEhrrhXaKA.vZdotGtudycEoMGXlFfNtgcvucrc() == null)
		{
			return 0;
		}
		return (ushort)NBuSBFNGPcAJmdEZXjupEhrrhXaKA.vZdotGtudycEoMGXlFfNtgcvucrc().HldEROsfjouWslmUEyVAeSKaUtrd().DCDITUFElKaxOgCQcaRhktRwtpcSB()
			.kvBdAOwJYUeRIhyXqCYJtltFTyGTA();
	}

	internal override void UpdateData(UpdateLoopType updateLoop)
	{
		if (ktfJrltkCGnYjvoxqGZKoeeEMIDC)
		{
			_ = base.enabled;
		}
	}

	internal override void SourceUpdated(IControllerExtensionSource source)
	{
		NBuSBFNGPcAJmdEZXjupEhrrhXaKA = source as yzxIpncwEAPiWpAwqeqTKawLrNzS;
		ktfJrltkCGnYjvoxqGZKoeeEMIDC = NBuSBFNGPcAJmdEZXjupEhrrhXaKA != null;
	}

	internal override Controller.Extension Clone()
	{
		return new RawInputControllerExtension(this);
	}
}
