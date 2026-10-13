using UnityEngine;

namespace Rewired;

public struct ElementAssignmentConflictInfo
{
	private bool yaRTkYscAcCOcIAyJNDeAlSHGyPzB;

	private bool igFBhBQhNEbAErrDJrRwSjKHwOMT;

	private int SGyDmtlGzdKaDgehOEvlGjXQfjVO;

	private ControllerType zHWAizCbZgyETomFsKNlBxhkURRgA;

	private int aONjcGDQKUpghunNWbUpMgzfPtJo;

	private int DexbMGeyoqjEemSFlMdiBZIOgItj;

	private int WfxWkOWZASAMWBnjVHfrqUgRAyMN;

	private ControllerElementType VMznulBvpuJDlVxULNrAipbJFhhJA;

	private int OcxCrlaSjcVmRImbQQsvMkeDToIn;

	private KeyCode XPgkcpElKWrNDyGIUKfoLBDxcaqe;

	private ModifierKeyFlags ZXEeyLCsVffnlfsAiiQUDPKLAEuQA;

	private int PbnnAmOHtAfioIOuYTSlZxBhcsXh;

	public bool isConflict
	{
		get
		{
			return yaRTkYscAcCOcIAyJNDeAlSHGyPzB;
		}
		internal set
		{
			DIANkJqSfAWPdqqoctaREALAieNaA(flag);
		}
	}

	public bool isUserAssignable
	{
		get
		{
			return igFBhBQhNEbAErrDJrRwSjKHwOMT;
		}
		internal set
		{
			TZBETVTSUmJgOtJgTzwtyRoYQAJX(flag);
		}
	}

	public int playerId
	{
		get
		{
			return SGyDmtlGzdKaDgehOEvlGjXQfjVO;
		}
		internal set
		{
			bKzpvKwtktjTHYQffDSpfhOhitkeA(num);
		}
	}

	public ControllerType controllerType
	{
		get
		{
			return zHWAizCbZgyETomFsKNlBxhkURRgA;
		}
		internal set
		{
			EoyQWIWraMCOIRiEZcPMHqupDMpjb(controllerType);
		}
	}

	public int controllerId
	{
		get
		{
			return aONjcGDQKUpghunNWbUpMgzfPtJo;
		}
		internal set
		{
			VEPDjqRWGYvCvlrhGuytJCLJqVBl(num);
		}
	}

	public int controllerMapId
	{
		get
		{
			return DexbMGeyoqjEemSFlMdiBZIOgItj;
		}
		internal set
		{
			JLNwRNgPapgrHnJxgJDNvEMFXDaG(num);
		}
	}

	public int elementMapId
	{
		get
		{
			return WfxWkOWZASAMWBnjVHfrqUgRAyMN;
		}
		internal set
		{
			hicGAoIPJoeobmpEdPCMXzHDkXMMA(num);
		}
	}

	public ControllerElementType elementType
	{
		get
		{
			return VMznulBvpuJDlVxULNrAipbJFhhJA;
		}
		internal set
		{
			DLaDUgMeSmdRswHcJpRUDNKtjCat(controllerElementType);
		}
	}

	public int elementIdentifierId
	{
		get
		{
			return OcxCrlaSjcVmRImbQQsvMkeDToIn;
		}
		internal set
		{
			wyBlqdoQOgEYUUbHbDBjVINequdn(num);
		}
	}

	public KeyCode keyCode
	{
		get
		{
			return XPgkcpElKWrNDyGIUKfoLBDxcaqe;
		}
		internal set
		{
			iMgbELZgSJrKBTGwVjaQaZnmbeHV(keyCode);
		}
	}

	public ModifierKeyFlags modifierKeyFlags
	{
		get
		{
			return ZXEeyLCsVffnlfsAiiQUDPKLAEuQA;
		}
		internal set
		{
			aDGcDUjUNOrhmdCuQRMkKVhdsIIeA(modifierKeyFlags);
		}
	}

	public int actionId
	{
		get
		{
			return PbnnAmOHtAfioIOuYTSlZxBhcsXh;
		}
		internal set
		{
			ChFYAJgrlIghhdZjRWtVMPZyNgVf(num);
		}
	}

	public Player player
	{
		get
		{
			if (!ReInput.isReady)
			{
				return null;
			}
			return ReInput.players.GetPlayer(SGyDmtlGzdKaDgehOEvlGjXQfjVO);
		}
	}

	public InputAction action
	{
		get
		{
			if (!ReInput.isReady)
			{
				return null;
			}
			return ReInput.mapping.GetAction(PbnnAmOHtAfioIOuYTSlZxBhcsXh);
		}
	}

	public Controller controller
	{
		get
		{
			if (!ReInput.isReady)
			{
				return null;
			}
			return ReInput.controllers.GetController(zHWAizCbZgyETomFsKNlBxhkURRgA, aONjcGDQKUpghunNWbUpMgzfPtJo);
		}
	}

	public ControllerMap controllerMap
	{
		get
		{
			if (player == null)
			{
				return null;
			}
			return player.controllers.maps.GetMap(zHWAizCbZgyETomFsKNlBxhkURRgA, aONjcGDQKUpghunNWbUpMgzfPtJo, DexbMGeyoqjEemSFlMdiBZIOgItj);
		}
	}

	public ControllerElementIdentifier elementIdentifier
	{
		get
		{
			if (controller == null)
			{
				return null;
			}
			return controller.GetElementIdentifierById(OcxCrlaSjcVmRImbQQsvMkeDToIn);
		}
	}

	public ActionElementMap elementMap
	{
		get
		{
			if (controllerMap == null)
			{
				return null;
			}
			return controllerMap.GetElementMap(WfxWkOWZASAMWBnjVHfrqUgRAyMN);
		}
	}

	public string elementDisplayName
	{
		get
		{
			if (zHWAizCbZgyETomFsKNlBxhkURRgA == ControllerType.Keyboard)
			{
				return Keyboard.GetKeyName(XPgkcpElKWrNDyGIUKfoLBDxcaqe, ZXEeyLCsVffnlfsAiiQUDPKLAEuQA);
			}
			if (controller == null)
			{
				return string.Empty;
			}
			ControllerElementIdentifier elementIdentifierById = controller.GetElementIdentifierById(OcxCrlaSjcVmRImbQQsvMkeDToIn);
			if (elementIdentifierById == null)
			{
				return string.Empty;
			}
			return elementIdentifierById.get_name();
		}
	}

	internal void DIANkJqSfAWPdqqoctaREALAieNaA(bool P_0)
	{
		yaRTkYscAcCOcIAyJNDeAlSHGyPzB = P_0;
	}

	internal void TZBETVTSUmJgOtJgTzwtyRoYQAJX(bool P_0)
	{
		igFBhBQhNEbAErrDJrRwSjKHwOMT = P_0;
	}

	internal void bKzpvKwtktjTHYQffDSpfhOhitkeA(int P_0)
	{
		SGyDmtlGzdKaDgehOEvlGjXQfjVO = P_0;
	}

	internal void EoyQWIWraMCOIRiEZcPMHqupDMpjb(ControllerType P_0)
	{
		zHWAizCbZgyETomFsKNlBxhkURRgA = P_0;
	}

	internal void VEPDjqRWGYvCvlrhGuytJCLJqVBl(int P_0)
	{
		aONjcGDQKUpghunNWbUpMgzfPtJo = P_0;
	}

	internal void JLNwRNgPapgrHnJxgJDNvEMFXDaG(int P_0)
	{
		DexbMGeyoqjEemSFlMdiBZIOgItj = P_0;
	}

	internal void hicGAoIPJoeobmpEdPCMXzHDkXMMA(int P_0)
	{
		WfxWkOWZASAMWBnjVHfrqUgRAyMN = P_0;
	}

	internal void DLaDUgMeSmdRswHcJpRUDNKtjCat(ControllerElementType P_0)
	{
		VMznulBvpuJDlVxULNrAipbJFhhJA = P_0;
	}

	internal void wyBlqdoQOgEYUUbHbDBjVINequdn(int P_0)
	{
		OcxCrlaSjcVmRImbQQsvMkeDToIn = P_0;
	}

	internal void iMgbELZgSJrKBTGwVjaQaZnmbeHV(KeyCode P_0)
	{
		XPgkcpElKWrNDyGIUKfoLBDxcaqe = P_0;
	}

	internal void aDGcDUjUNOrhmdCuQRMkKVhdsIIeA(ModifierKeyFlags P_0)
	{
		ZXEeyLCsVffnlfsAiiQUDPKLAEuQA = P_0;
	}

	internal void ChFYAJgrlIghhdZjRWtVMPZyNgVf(int P_0)
	{
		PbnnAmOHtAfioIOuYTSlZxBhcsXh = P_0;
	}

	public ElementAssignmentConflictInfo(bool P_0, bool P_1, int P_2, ControllerType P_3, int P_4, int P_5, int P_6, int P_7, ControllerElementType P_8, int P_9, KeyCode P_10, ModifierKeyFlags P_11)
	{
		yaRTkYscAcCOcIAyJNDeAlSHGyPzB = P_0;
		igFBhBQhNEbAErrDJrRwSjKHwOMT = P_1;
		SGyDmtlGzdKaDgehOEvlGjXQfjVO = P_2;
		zHWAizCbZgyETomFsKNlBxhkURRgA = P_3;
		aONjcGDQKUpghunNWbUpMgzfPtJo = P_4;
		DexbMGeyoqjEemSFlMdiBZIOgItj = P_5;
		WfxWkOWZASAMWBnjVHfrqUgRAyMN = P_6;
		PbnnAmOHtAfioIOuYTSlZxBhcsXh = P_7;
		VMznulBvpuJDlVxULNrAipbJFhhJA = P_8;
		OcxCrlaSjcVmRImbQQsvMkeDToIn = P_9;
		XPgkcpElKWrNDyGIUKfoLBDxcaqe = P_10;
		ZXEeyLCsVffnlfsAiiQUDPKLAEuQA = P_11;
	}

	public ElementAssignmentConflictInfo(ElementAssignmentConflictInfo P_0)
	{
		yaRTkYscAcCOcIAyJNDeAlSHGyPzB = P_0.yaRTkYscAcCOcIAyJNDeAlSHGyPzB;
		igFBhBQhNEbAErrDJrRwSjKHwOMT = P_0.igFBhBQhNEbAErrDJrRwSjKHwOMT;
		SGyDmtlGzdKaDgehOEvlGjXQfjVO = P_0.SGyDmtlGzdKaDgehOEvlGjXQfjVO;
		zHWAizCbZgyETomFsKNlBxhkURRgA = P_0.zHWAizCbZgyETomFsKNlBxhkURRgA;
		aONjcGDQKUpghunNWbUpMgzfPtJo = P_0.aONjcGDQKUpghunNWbUpMgzfPtJo;
		DexbMGeyoqjEemSFlMdiBZIOgItj = P_0.DexbMGeyoqjEemSFlMdiBZIOgItj;
		WfxWkOWZASAMWBnjVHfrqUgRAyMN = P_0.WfxWkOWZASAMWBnjVHfrqUgRAyMN;
		PbnnAmOHtAfioIOuYTSlZxBhcsXh = P_0.PbnnAmOHtAfioIOuYTSlZxBhcsXh;
		VMznulBvpuJDlVxULNrAipbJFhhJA = P_0.VMznulBvpuJDlVxULNrAipbJFhhJA;
		OcxCrlaSjcVmRImbQQsvMkeDToIn = P_0.OcxCrlaSjcVmRImbQQsvMkeDToIn;
		XPgkcpElKWrNDyGIUKfoLBDxcaqe = P_0.XPgkcpElKWrNDyGIUKfoLBDxcaqe;
		ZXEeyLCsVffnlfsAiiQUDPKLAEuQA = P_0.ZXEeyLCsVffnlfsAiiQUDPKLAEuQA;
	}
}
