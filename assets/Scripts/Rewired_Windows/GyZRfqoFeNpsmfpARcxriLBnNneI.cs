using System;
using System.Runtime.InteropServices;
using Rewired.Platforms.Microsoft.WindowsGamingInput;

internal static class GyZRfqoFeNpsmfpARcxriLBnNneI
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	public delegate void iXHjlMeEBjzwJPqERARLcaCoxowl(jPwrKcWHtUKPlQDeQIZEtHKcaSTp pGamepad);

	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	public delegate void PUTuEqfteeeksfPHNFhrBvNGnICEA(jPwrKcWHtUKPlQDeQIZEtHKcaSTp pGamepad);

	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	public delegate void mIFDSXegVjduYshVyqQlxhWGBXhn(jPwrKcWHtUKPlQDeQIZEtHKcaSTp pRawGameController);

	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	public delegate void eVjfsbRrKMXNPTKleCZOcXdRFPgHb(jPwrKcWHtUKPlQDeQIZEtHKcaSTp pRawGameController);

	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	public delegate void cCDqnDjMEunMMShmrvVqPMbMKjXG(jPwrKcWHtUKPlQDeQIZEtHKcaSTp coreWindow, jPwrKcWHtUKPlQDeQIZEtHKcaSTp keyEventArgs);

	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	public delegate void VdVxprJFGQcOVpKamGUEaOprPoDSA(jPwrKcWHtUKPlQDeQIZEtHKcaSTp coreDispatcher, jPwrKcWHtUKPlQDeQIZEtHKcaSTp acceleratorKeyEventArgs);

	public const string sOjEdrKsDdkDUEkshdKoGbkcwsCme = "Rewired_WindowsGamingInput";

	private const CallingConvention mYWhIbqUqWqdPDtOCRYWDBRQhifH = CallingConvention.StdCall;

	private const CallingConvention ZofgQLOPWlONpPLCGEMzviTOmIiP = CallingConvention.StdCall;

	private const UnmanagedType rPlcybzWtMeqcCfubctlgKnbAinob = UnmanagedType.LPWStr;

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "IUnknown_Release")]
	private static extern ulong CIqymJTVuEBLhqPTXwFGBnlsNvbT(IntPtr P_0);

	public static ulong KoTqRWIaZiOgzTfGIKNBWRRwSjhJ(IntPtr P_0)
	{
		if (P_0 == IntPtr.Zero)
		{
			return 0uL;
		}
		return CIqymJTVuEBLhqPTXwFGBnlsNvbT(P_0);
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "IUnknown_AddRef")]
	private static extern ulong bZSISxIVmHObumNaTwcpmdyNhtqo(IntPtr P_0);

	public static ulong ukiqHseFYWgSUgfpCGwBPBPwdfRO(IntPtr P_0)
	{
		if (P_0 == IntPtr.Zero)
		{
			return 0uL;
		}
		return bZSISxIVmHObumNaTwcpmdyNhtqo(P_0);
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "Core_IsAPISupported")]
	[return: MarshalAs(UnmanagedType.I1)]
	public static extern bool RaGWRWClfEKCyIYTCRBLxcJqAWLeA();

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "Core_GetMinimumRequiredWindowsVersionString")]
	private static extern IntPtr JLSOrOncruInGPJeyiSIKapnXQlO();

	public static string ztfaiUEtXcRzxKewivCthgESWhGs()
	{
		IntPtr intPtr = JLSOrOncruInGPJeyiSIKapnXQlO();
		if (intPtr == IntPtr.Zero)
		{
			return null;
		}
		return Marshal.PtrToStringUni(intPtr);
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "Gamepad_GetGamepads")]
	public static extern jPwrKcWHtUKPlQDeQIZEtHKcaSTp jCxWFKNGXwPlqDzBNIVqJjVcpqcJ();

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "Gamepad_GetGamepadCount")]
	public static extern uint exCikMNqYuqESItgadmTMMqbfrVn(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "Gamepad_GetGamepad")]
	public static extern jPwrKcWHtUKPlQDeQIZEtHKcaSTp tuxhAIfjQIPeSqqooaDFTdgWfxGF(IntPtr P_0, uint P_1);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "Gamepad_GetCurrentReading")]
	public static extern bool QNBeWiPFyVzFyLxXCZjsfkcLCNzh(IntPtr P_0, ref WjHeUGFpMfXsDCAZYcTSYZtUWbpTA P_1);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "Gamepad_GetVibration")]
	public static extern bool ohQCOuMYCKMMYFnlOILWIBylmmufA(IntPtr P_0, ref LtakCapTpNbmgRDKnDqtPFoLiOVE P_1);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "Gamepad_SetVibration")]
	public static extern void dIXRppaFGXeVqVbamGajcSkftkjfA(IntPtr P_0, [In][MarshalAs(UnmanagedType.Struct)] LtakCapTpNbmgRDKnDqtPFoLiOVE P_1);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "Gamepad_GetUser")]
	private static extern IntPtr selNZoWexfkIWEDGSnElzqNNOVEP(IntPtr P_0);

	public static jTuOLgoiBGUkTrgwbFOdMLLxKRqo afRRrbQalBaYoioevqNUZrTXhVsMA(IntPtr P_0)
	{
		IntPtr intPtr = selNZoWexfkIWEDGSnElzqNNOVEP(P_0);
		if (intPtr == IntPtr.Zero)
		{
			return null;
		}
		return new jTuOLgoiBGUkTrgwbFOdMLLxKRqo(new OiIxXJaWHgywcVCbFIsRHGrTvjHG(intPtr));
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "Gamepad_IsGamepad")]
	public static extern bool IELsUwDPMRMLgoqZLnrbiQYfFOeX(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "Gamepad_FromGameController")]
	public static extern jPwrKcWHtUKPlQDeQIZEtHKcaSTp cQuMjLsCRtXFFKLuvkRVogzwBvUN(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "Gamepad_GetButtonLabel")]
	public static extern fLnbLbehLGApFKnFDNFFPlafMaOGb XXsvxLPlPilIgZFbdUxfIcfOZZWE(IntPtr P_0, GamepadButtons P_1);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "Gamepad_ListenForEvents")]
	public static extern void WqPBpQWjqqPAVunNnlCHazpJGpEr();

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "Gamepad_StopListeningForEvents")]
	public static extern void hvEVgpnbURLAOxDYbIBGsewMDWGI();

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "Gamepad_SetEventListener_GamepadAdded")]
	public static extern void bNDwggIPWRWstzmYzVMXqGHGXPeS(iXHjlMeEBjzwJPqERARLcaCoxowl P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "Gamepad_SetEventListener_GamepadRemoved")]
	public static extern void KlJuEecCKdNcBwFOKBRGDOKFkJfmA(PUTuEqfteeeksfPHNFhrBvNGnICEA P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetRawGameControllerCount")]
	public static extern uint FvspDoVAHThBeGDIOMHoglBTbuGx(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetRawGameControllers")]
	public static extern jPwrKcWHtUKPlQDeQIZEtHKcaSTp rTAGhkfpVgJoldJBUaDRNERbYOVy();

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetRawGameController")]
	public static extern jPwrKcWHtUKPlQDeQIZEtHKcaSTp AQVayOrqbfdJHZqhrzZPknqtISgP(IntPtr P_0, uint P_1);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetCurrentReading")]
	private static extern ulong oWwFYVUPGDRVnceWabiAIgGpgYyDA(IntPtr P_0, bool[] P_1, uint P_2, RENqIYsokjptzjVvxBiQDoTioCfP[] P_3, uint P_4, double[] P_5, uint P_6);

	public static ulong bqPITWRAgYUwoHcLgiBWlaTqKnNA(IntPtr P_0, bool[] P_1, RENqIYsokjptzjVvxBiQDoTioCfP[] P_2, double[] P_3)
	{
		return oWwFYVUPGDRVnceWabiAIgGpgYyDA(P_0, P_1, (uint)P_1.Length, P_2, (uint)P_2.Length, P_3, (uint)P_3.Length);
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetIsWireless")]
	public static extern bool gmPeQyZRstFBiFypMbhTGxEhSyhpb(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetSimpleHapticsControllers")]
	public static extern jPwrKcWHtUKPlQDeQIZEtHKcaSTp bLYDTMGNpoZYIMrlfTiklaVTsUfd(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetSimpleHapticsControllerCount")]
	public static extern uint ludvaAijvLfydtdTwbXGEOGvyCXz(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetUser")]
	public static extern jPwrKcWHtUKPlQDeQIZEtHKcaSTp XMHALRcZzobyGNriZaoEGufdeCtHA(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetButtonCount")]
	public static extern int aILanCNgSmSepSqOFGshOgitwPVN(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetSwitchCount")]
	public static extern int GDbfpeektcMbSgEBtNCgjYZAHJvlb(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetAxisCount")]
	public static extern int aVpOHeqqxFTaDplLQUOwIomCGPBr(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetDisplayName")]
	private static extern IntPtr vfTzPuPaZjdEUgSdxjHZwGsHeuCF(IntPtr P_0);

	public static string zxIUeqOvNJsrVCAgKjMLbgjJtxaT(IntPtr P_0)
	{
		IntPtr intPtr = vfTzPuPaZjdEUgSdxjHZwGsHeuCF(P_0);
		if (intPtr == IntPtr.Zero)
		{
			return null;
		}
		return Marshal.PtrToStringUni(intPtr);
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetForceFeedbackMotors")]
	public static extern jPwrKcWHtUKPlQDeQIZEtHKcaSTp kjsTgoqEgzqxgTlhYKtqcssmeTWj(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetForceFeedbackMotorCount")]
	public static extern uint wlkAaRsUmdLLBbaByPMWpJXgbMQBA(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetButtonLabel")]
	public static extern fLnbLbehLGApFKnFDNFFPlafMaOGb cexhKabvPiIWpAURmvYihiuIjZdv(IntPtr P_0, int P_1);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetSwitchKind")]
	public static extern gWISGcMEQRAmKcxYzszuqlfdpeJBb AeRMJPhSAwgdjCXxCdDOwnQJgpoaA(IntPtr P_0, int P_1);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetHardwareVendorId")]
	public static extern ushort rsoKtsGsAadsilytvjszIqyZUgVf(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetHardwareProductId")]
	public static extern ushort FFEZyiWamsEEfwGXuCmiZPemXGXp(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_TryGetBatteryReport")]
	public static extern jPwrKcWHtUKPlQDeQIZEtHKcaSTp enRRvAEhEIAzWoLxEvbKWzdYtjYL(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetNonRoamableId")]
	public static extern IntPtr ALIrRbOqGfPekEnhmjwEGBOvawybb(IntPtr P_0);

	public static string MvFFRcDuulLnnwJTtISZweeeQMNF(IntPtr P_0)
	{
		IntPtr intPtr = ALIrRbOqGfPekEnhmjwEGBOvawybb(P_0);
		if (intPtr == IntPtr.Zero)
		{
			return null;
		}
		return Marshal.PtrToStringUni(intPtr);
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetHeadset")]
	public static extern jPwrKcWHtUKPlQDeQIZEtHKcaSTp IKBpsVMfxTcJcXOMBDfekmHxtcMQ(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_IsRawGameController")]
	public static extern bool PflfaPqWUPfUPawCQemCxBzFtBWNA(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_FromGameController")]
	public static extern jPwrKcWHtUKPlQDeQIZEtHKcaSTp DQRkalUheczoAuUKuUqfqvpInMMI(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_ListenForEvents")]
	public static extern void mPkyAopzdoPWdTXppUnigqlxUoDg();

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_StopListeningForEvents")]
	public static extern void CcOCowHIEPHcGOHZVZtNEbnVuYzQ();

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_SetEventListener_RawGameControllerAdded")]
	public static extern void UFhpzqHaryfHaUnBHYfPnWdMdyHj(mIFDSXegVjduYshVyqQlxhWGBXhn P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_SetEventListener_RawGameControllerRemoved")]
	public static extern void GGRArhFVVmTwniOeXZbBIIBSNckhb(eVjfsbRrKMXNPTKleCZOcXdRFPgHb P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "User_GetType")]
	private static extern int anzbYuEStETwyjzmQauDXVYWODxFb(IntPtr P_0);

	public static PAHAdRkNVexwxKLawEuCkxqsVdbq BHkjGZcQYzsJWTAwIGWCncmBlSkv(IntPtr P_0)
	{
		if (P_0 == IntPtr.Zero)
		{
			return PAHAdRkNVexwxKLawEuCkxqsVdbq.LocalUser;
		}
		return (PAHAdRkNVexwxKLawEuCkxqsVdbq)anzbYuEStETwyjzmQauDXVYWODxFb(P_0);
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "User_GetNonRoamableId")]
	private static extern IntPtr hnTDOkgjsXsDrGXrGpKHNHotCRzt(IntPtr P_0);

	public static string ZwgSgBPPnybkVhvqjQplJjqcqIrvA(IntPtr P_0)
	{
		IntPtr intPtr = hnTDOkgjsXsDrGXrGpKHNHotCRzt(P_0);
		if (intPtr == IntPtr.Zero)
		{
			return null;
		}
		return Marshal.PtrToStringUni(intPtr);
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "CoreWindow_GetMainCoreWindow")]
	private static extern jPwrKcWHtUKPlQDeQIZEtHKcaSTp VaUPeAlnTmfvvdPaUJtqMgPftEtCA();

	public static jPwrKcWHtUKPlQDeQIZEtHKcaSTp WmWjSPkvvnkOBUniQnnkWEXBwDDK()
	{
		return VaUPeAlnTmfvvdPaUJtqMgPftEtCA();
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "CoreWindow_AddEventListener_KeyUp")]
	private static extern IntPtr xgqJqzaiVdYRolaXDeCorixAUxVN(IntPtr P_0);

	public static SVPTFvyeouPWVvjKaoPBTZvtWQZD ogXoMxclmaUsvpyKPhIcuaKGGCpd(IntPtr P_0)
	{
		if (P_0 == IntPtr.Zero)
		{
			return null;
		}
		try
		{
			IntPtr intPtr = xgqJqzaiVdYRolaXDeCorixAUxVN(P_0);
			if (intPtr == IntPtr.Zero)
			{
				return null;
			}
			return new SVPTFvyeouPWVvjKaoPBTZvtWQZD(intPtr);
		}
		catch (Exception)
		{
			return null;
		}
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "CoreWindow_AddEventListener_KeyDown")]
	private static extern IntPtr VlSzkMOuxgTMxhBnkAibJexJcaZQA(IntPtr P_0);

	public static SVPTFvyeouPWVvjKaoPBTZvtWQZD KOkQpBaNflAjmgiwNAizSwMqmXkJA(IntPtr P_0)
	{
		if (P_0 == IntPtr.Zero)
		{
			return null;
		}
		try
		{
			IntPtr intPtr = VlSzkMOuxgTMxhBnkAibJexJcaZQA(P_0);
			if (intPtr == IntPtr.Zero)
			{
				return null;
			}
			return new SVPTFvyeouPWVvjKaoPBTZvtWQZD(intPtr);
		}
		catch (Exception)
		{
			return null;
		}
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "CoreWindow_RemoveEventListener_KeyUp")]
	private static extern void TDDBlEenJopRadbLwmEQyBBIqYCcb(IntPtr P_0, IntPtr P_1);

	public static void mtLKDKJHAslAegRDnUnbVeJIbYbBA(IntPtr P_0, SVPTFvyeouPWVvjKaoPBTZvtWQZD P_1)
	{
		if (!(P_0 == IntPtr.Zero) && !WNQSxHPFFezHqWMSROkeimBHgEVI.mHsiPLmFFWSEEGUlhHPRtNxKiWeD(P_1, null))
		{
			TDDBlEenJopRadbLwmEQyBBIqYCcb(P_0, P_1.ykmgEpIhpMSGFOhDIxsEGNunpZXK());
		}
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "CoreWindow_RemoveEventListener_KeyDown")]
	private static extern void JocBYQieudyeGQAVYNVujZAcAwHcA(IntPtr P_0, IntPtr P_1);

	public static void ZguzWRsvpfOyvgcLPsOiiUnrAlOh(IntPtr P_0, SVPTFvyeouPWVvjKaoPBTZvtWQZD P_1)
	{
		if (!(P_0 == IntPtr.Zero) && !WNQSxHPFFezHqWMSROkeimBHgEVI.mHsiPLmFFWSEEGUlhHPRtNxKiWeD(P_1, null))
		{
			JocBYQieudyeGQAVYNVujZAcAwHcA(P_0, P_1.ykmgEpIhpMSGFOhDIxsEGNunpZXK());
		}
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "CoreWindow_SetUniversalEventListener_KeyUp")]
	private static extern void tUqNBOYBfiOoWIzrDpBiCkhCgFoV(cCDqnDjMEunMMShmrvVqPMbMKjXG P_0);

	public static void GmXpEaizDLuNvtzDLDNFfhyfeFLeA(cCDqnDjMEunMMShmrvVqPMbMKjXG P_0)
	{
		tUqNBOYBfiOoWIzrDpBiCkhCgFoV(P_0);
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "CoreWindow_ClearUniversalEventListener_KeyUp")]
	private static extern void NkMAJdOvkMhtPkURxPnAuEWYKCDnA();

	public static void NsaaSOjLQRAcZFPOyefkRFrNaoct()
	{
		NkMAJdOvkMhtPkURxPnAuEWYKCDnA();
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "CoreWindow_SetUniversalEventListener_KeyDown")]
	private static extern void FyduYsNTXDbnsVWqFoLBtGlqqnOq(cCDqnDjMEunMMShmrvVqPMbMKjXG P_0);

	public static void rGATFnJuKZGwZEWnOghlGaWWbJOE(cCDqnDjMEunMMShmrvVqPMbMKjXG P_0)
	{
		FyduYsNTXDbnsVWqFoLBtGlqqnOq(P_0);
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "CoreWindow_ClearUniversalEventListener_KeyDown")]
	private static extern void xnichVGsIdkSOYtjCJaHuFNQPRHYA();

	public static void XjUHnlvUjAHkHVzkBjtytyVRNuwV()
	{
		xnichVGsIdkSOYtjCJaHuFNQPRHYA();
	}

	public static kvJtkRuSwaqBtfRdEcMcbOzcEGIZ CqwSmJoSyCtohovkUWAGRPgBHFgJ(IntPtr P_0)
	{
		if (P_0 == IntPtr.Zero)
		{
			return default;
		}
		return new kvJtkRuSwaqBtfRdEcMcbOzcEGIZ(CLirXpEaomCxylidkGbLBREwljMeb(P_0), BmxbceOeddFsQJoGwmwdFHUkQXBAB(P_0), RfXcrPEtszdCOECTBmMiuUBkEVYs(P_0));
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "KeyEventArgs_GetHandled")]
	private static extern bool CLirXpEaomCxylidkGbLBREwljMeb(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "KeyEventArgs_GetVirtualKey")]
	private static extern DkqSjPBjDKhRChjQDXVSfZlOLOCZ RfXcrPEtszdCOECTBmMiuUBkEVYs(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "KeyEventArgs_GetKeyStatus")]
	private static extern IntPtr JvdrNWXvHGWKyAnHeYKrFlTqWNHH(IntPtr P_0);

	private static yArHHGsHcxVgdWXAysvxtPGcHPpF BmxbceOeddFsQJoGwmwdFHUkQXBAB(IntPtr P_0)
	{
		if (P_0 == IntPtr.Zero)
		{
			return default;
		}
		IntPtr intPtr = JvdrNWXvHGWKyAnHeYKrFlTqWNHH(P_0);
		if (intPtr == IntPtr.Zero)
		{
			return default;
		}
		yArHHGsHcxVgdWXAysvxtPGcHPpF result = RGFDCBkCaLjIEiJmhVsCJZdkgkmxB(intPtr);
		obAJzfHdlgdspTIrNoTjRqvUwlvmA(intPtr);
		return result;
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "CoreDispatcher_GetMainCoreDispatcher")]
	private static extern jPwrKcWHtUKPlQDeQIZEtHKcaSTp tZiMZxQbypJeopdzGjRlseutWbss();

	public static jPwrKcWHtUKPlQDeQIZEtHKcaSTp NBMRpjDrSWzTSwjyDBClOeNVxsEj()
	{
		return tZiMZxQbypJeopdzGjRlseutWbss();
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "CoreDispatcher_AddEventListener_AcceleratorKeyActivated")]
	private static extern IntPtr rTHRhVKyVDMGEbYTjEacDvQVwKPN(IntPtr P_0);

	public static SVPTFvyeouPWVvjKaoPBTZvtWQZD mnJYsZcslCVUyZfnixdVRdbsphBe(IntPtr P_0)
	{
		try
		{
			IntPtr intPtr = rTHRhVKyVDMGEbYTjEacDvQVwKPN(P_0);
			if (intPtr == IntPtr.Zero)
			{
				return null;
			}
			return new SVPTFvyeouPWVvjKaoPBTZvtWQZD(intPtr);
		}
		catch (Exception)
		{
			return null;
		}
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "CoreDispatcher_RemoveEventListener_AcceleratorKeyActivated")]
	private static extern void iBIzdHNVhHsLrHPlvlXJiTGYFDHC(IntPtr P_0, IntPtr P_1);

	public static void bdlNAfOyVHJJVbSBQDbgsDaqmlv(IntPtr P_0, SVPTFvyeouPWVvjKaoPBTZvtWQZD P_1)
	{
		if (!WNQSxHPFFezHqWMSROkeimBHgEVI.mHsiPLmFFWSEEGUlhHPRtNxKiWeD(P_1, null))
		{
			iBIzdHNVhHsLrHPlvlXJiTGYFDHC(P_0, P_1.ykmgEpIhpMSGFOhDIxsEGNunpZXK());
		}
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "CoreDispatcher_SetUniversalEventListener_AcceleratorKeyActivated")]
	private static extern void bkbaLSkcFXAvaXPKIGqYrlMtdbXb(VdVxprJFGQcOVpKamGUEaOprPoDSA P_0);

	public static void UgireauhcFSADSdoiVFrbMBRerYI(VdVxprJFGQcOVpKamGUEaOprPoDSA P_0)
	{
		bkbaLSkcFXAvaXPKIGqYrlMtdbXb(P_0);
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "CoreDispatcher_ClearUniversalEventListener_AcceleratorKeyActivated")]
	private static extern void OTAXGNDfnWvZHgQamJvjrgRNmHdP();

	public static void DHNZjsGnVnRWmYiDkgKOFIbjgEhb()
	{
		OTAXGNDfnWvZHgQamJvjrgRNmHdP();
	}

	public static PiMkmmtZVhsozZRFxCTOWJLuxbyR smNyzqIofonfLbUFwahejTRyMOZW(IntPtr P_0)
	{
		if (P_0 == IntPtr.Zero)
		{
			return default;
		}
		return new PiMkmmtZVhsozZRFxCTOWJLuxbyR(NhwWRNrUuVqSkvMHFDAfNinrMZrH(P_0), JuKTDwGmgeOAeFLJLfqpgjnbLwYDb(P_0), JPQTYTPldeATTQhTZnjHmBTSmvxq(P_0), kUNdAMQRWyozavFxZRMBDgVONevo(P_0));
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "AcceleratorKeyEventArgs_GetEventType")]
	private static extern PyzySkXQsgJISnAMutmCHdWsayYbA NhwWRNrUuVqSkvMHFDAfNinrMZrH(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "AcceleratorKeyEventArgs_GetHandled")]
	private static extern bool JuKTDwGmgeOAeFLJLfqpgjnbLwYDb(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "AcceleratorKeyEventArgs_GetVirtualKey")]
	private static extern DkqSjPBjDKhRChjQDXVSfZlOLOCZ kUNdAMQRWyozavFxZRMBDgVONevo(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "AcceleratorKeyEventArgs_GetKeyStatus")]
	private static extern IntPtr usNNItZDOBbgDqstCHIgNGZfhfYq(IntPtr P_0);

	private static yArHHGsHcxVgdWXAysvxtPGcHPpF JPQTYTPldeATTQhTZnjHmBTSmvxq(IntPtr P_0)
	{
		if (P_0 == IntPtr.Zero)
		{
			return default;
		}
		IntPtr intPtr = usNNItZDOBbgDqstCHIgNGZfhfYq(P_0);
		if (intPtr == IntPtr.Zero)
		{
			return default;
		}
		yArHHGsHcxVgdWXAysvxtPGcHPpF result = RGFDCBkCaLjIEiJmhVsCJZdkgkmxB(intPtr);
		obAJzfHdlgdspTIrNoTjRqvUwlvmA(intPtr);
		return result;
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "SCorePhysicalKeyStatus_Free")]
	private static extern jPwrKcWHtUKPlQDeQIZEtHKcaSTp obAJzfHdlgdspTIrNoTjRqvUwlvmA(IntPtr P_0);

	private static yArHHGsHcxVgdWXAysvxtPGcHPpF RGFDCBkCaLjIEiJmhVsCJZdkgkmxB(IntPtr P_0)
	{
		if (P_0 == IntPtr.Zero)
		{
			return default;
		}
		return new yArHHGsHcxVgdWXAysvxtPGcHPpF
		{
			aBYOPwVvznDhcxlWVfEpglYnzjKvA = (Marshal.ReadByte(P_0, 0) > 0),
			HfcCSUZaKqFXQDxvprCwUnAhAAgKA = (Marshal.ReadByte(P_0, 1) > 0),
			zNvtjErAhLLzNeOQHpazPCFoyllj = (Marshal.ReadByte(P_0, 2) > 0),
			yfXnyxtAdIPjXkhfDjTgCAmLTcwEA = (uint)Marshal.ReadInt32(P_0, 4),
			EuPmsTgMhTKHLhRTvLjFQprfGnXIA = (uint)Marshal.ReadInt32(P_0, 8),
			HKzGPZEGwmOjFxCQnMFupJadtOcjb = (Marshal.ReadByte(P_0, 12) > 0)
		};
	}
}
