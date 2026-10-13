using Rewired.Interfaces;

namespace Rewired.Platforms.Windows.XInput;

[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
public sealed class XInputControllerExtension : Controller.Extension
{
	private class zsfbCiYmFCYuPOMqzXWDsBjTySkd : IControllerExtensionSource
	{
		private fXHRBPluCVlFmVyDTJoQUtqLlMxB.mYfrdbcireBcNJFrWedHlySfZSdOA NMMDiEmBIXnlHaATCcVmUngKSUmN;

		public fXHRBPluCVlFmVyDTJoQUtqLlMxB.mYfrdbcireBcNJFrWedHlySfZSdOA KLhUTmEkhBGdycDopsjdTsDKSIsCA => KKySeOIUPglNLCbSqqDXhFGJLQEh();

		public fXHRBPluCVlFmVyDTJoQUtqLlMxB.mYfrdbcireBcNJFrWedHlySfZSdOA KKySeOIUPglNLCbSqqDXhFGJLQEh()
		{
			return NMMDiEmBIXnlHaATCcVmUngKSUmN;
		}

		public zsfbCiYmFCYuPOMqzXWDsBjTySkd(fXHRBPluCVlFmVyDTJoQUtqLlMxB.mYfrdbcireBcNJFrWedHlySfZSdOA P_0)
		{
			NMMDiEmBIXnlHaATCcVmUngKSUmN = P_0;
		}
	}

	private zsfbCiYmFCYuPOMqzXWDsBjTySkd oQsNUPhqChiDQJQooylTWLqxaxIM;

	private bool CIjIgLrhxOKLdYFWUFTmAzSHLZyT;

	private Joystick joystick => lEgCloXLKbiTZdMPJDmukFQtAwGD();

	public int userIndex
	{
		get
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return 0;
			}
			if (!CIjIgLrhxOKLdYFWUFTmAzSHLZyT || !base.enabled)
			{
				return 0;
			}
			if (oQsNUPhqChiDQJQooylTWLqxaxIM.KKySeOIUPglNLCbSqqDXhFGJLQEh() == null)
			{
				return 0;
			}
			return (int)oQsNUPhqChiDQJQooylTWLqxaxIM.KKySeOIUPglNLCbSqqDXhFGJLQEh().IIQkJXcSDiDmPtCKIvdJqLpNIWsHA.ENtLDysnadtEniDtwZEiiymtEjSV();
		}
	}

	public CapabilityFlags capabilityFlags
	{
		get
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return CapabilityFlags.None;
			}
			if (!CIjIgLrhxOKLdYFWUFTmAzSHLZyT || !base.enabled)
			{
				return CapabilityFlags.None;
			}
			if (oQsNUPhqChiDQJQooylTWLqxaxIM.KKySeOIUPglNLCbSqqDXhFGJLQEh() == null)
			{
				return CapabilityFlags.None;
			}
			oQsNUPhqChiDQJQooylTWLqxaxIM.KKySeOIUPglNLCbSqqDXhFGJLQEh().IIQkJXcSDiDmPtCKIvdJqLpNIWsHA.nUIVFditXdrDHjHtilSBbTDxRHvt(liDOKlvrxtESUNNgdekFnKBWUPUW.Any, out var ooyeOgEaXDemhJzDXAyWLlBqTfCTA);
			return (CapabilityFlags)ooyeOgEaXDemhJzDXAyWLlBqTfCTA.FoPYlDlRNMphMcpTwdbdTBkTxGbj;
		}
	}

	public DeviceType deviceType
	{
		get
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return (DeviceType)0;
			}
			if (!CIjIgLrhxOKLdYFWUFTmAzSHLZyT || !base.enabled)
			{
				return (DeviceType)0;
			}
			if (oQsNUPhqChiDQJQooylTWLqxaxIM.KKySeOIUPglNLCbSqqDXhFGJLQEh() == null)
			{
				return (DeviceType)0;
			}
			oQsNUPhqChiDQJQooylTWLqxaxIM.KKySeOIUPglNLCbSqqDXhFGJLQEh().IIQkJXcSDiDmPtCKIvdJqLpNIWsHA.nUIVFditXdrDHjHtilSBbTDxRHvt(liDOKlvrxtESUNNgdekFnKBWUPUW.Any, out var ooyeOgEaXDemhJzDXAyWLlBqTfCTA);
			return (DeviceType)ooyeOgEaXDemhJzDXAyWLlBqTfCTA.zMhyDnmNoJUdoJFqQauXlTqxBKak;
		}
	}

	public DeviceSubType deviceSubType
	{
		get
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return (DeviceSubType)0;
			}
			if (!CIjIgLrhxOKLdYFWUFTmAzSHLZyT || !base.enabled)
			{
				return (DeviceSubType)0;
			}
			if (oQsNUPhqChiDQJQooylTWLqxaxIM.KKySeOIUPglNLCbSqqDXhFGJLQEh() == null)
			{
				return (DeviceSubType)0;
			}
			oQsNUPhqChiDQJQooylTWLqxaxIM.KKySeOIUPglNLCbSqqDXhFGJLQEh().IIQkJXcSDiDmPtCKIvdJqLpNIWsHA.nUIVFditXdrDHjHtilSBbTDxRHvt(liDOKlvrxtESUNNgdekFnKBWUPUW.Any, out var ooyeOgEaXDemhJzDXAyWLlBqTfCTA);
			return (DeviceSubType)ooyeOgEaXDemhJzDXAyWLlBqTfCTA.CZIEkLbWIghXoMhjFSEJQuaJFNjeb;
		}
	}

	private Joystick lEgCloXLKbiTZdMPJDmukFQtAwGD()
	{
		return GetController<Joystick>();
	}

	internal XInputControllerExtension(fXHRBPluCVlFmVyDTJoQUtqLlMxB.mYfrdbcireBcNJFrWedHlySfZSdOA P_0)
		: base(new zsfbCiYmFCYuPOMqzXWDsBjTySkd(P_0))
	{
	}

	private XInputControllerExtension(XInputControllerExtension P_0)
		: base(P_0)
	{
	}

	internal override void UpdateData(UpdateLoopType updateLoop)
	{
		if (CIjIgLrhxOKLdYFWUFTmAzSHLZyT)
		{
			_ = base.enabled;
		}
	}

	internal override void SourceUpdated(IControllerExtensionSource source)
	{
		oQsNUPhqChiDQJQooylTWLqxaxIM = source as zsfbCiYmFCYuPOMqzXWDsBjTySkd;
		CIjIgLrhxOKLdYFWUFTmAzSHLZyT = oQsNUPhqChiDQJQooylTWLqxaxIM != null;
	}

	internal override Controller.Extension Clone()
	{
		return new XInputControllerExtension(this);
	}
}
