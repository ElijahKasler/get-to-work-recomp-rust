using System;
using System.Runtime.InteropServices;
using System.Security;
using System.Threading;
using Rewired.Utils;

internal static class iZtZloELsoaMBDRDTiszzpwtPjDd
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	private delegate bool bmIExdjcSBFQmAPCfpPyjcpiULseA(IntPtr hwnd, IntPtr lParam);

	private static IntPtr LIwPhtUeasWnoLwviIbjvjBMuBkl = IntPtr.Zero;

	private static int AlOcVoMgICgHRhgalsLUmfLPOJhRA;

	[DllImport("Kernel32.dll", EntryPoint = "GetLastError")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int TIGrjRwGZOzOeQxaNuzzcXpURWSu();

	[DllImport("Kernel32.dll", EntryPoint = "GetCurrentProcess")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr cdykjPieVjohVAwxvzJwfCMzYcDA();

	[DllImport("Kernel32.dll", EntryPoint = "GetCurrentProcessId")]
	[SuppressUnmanagedCodeSecurity]
	public static extern uint UTBVNwdbQVkduJXVxZxoUdgxhqrG();

	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "WaitNamedPipe")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int NBJXSscfLyNnFNqoScYhFvFyGTwr(string P_0, int P_1);

	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "SetNamedPipeHandleState")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int hQaXjgImnYNgqLRoDhrdtPWkVOkg(IntPtr P_0, ref int P_1, ref int P_2, ref int P_3);

	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "SetNamedPipeHandleState")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int eTxEMHaiEnhOweEjOyNfMXMZIdbGA(IntPtr P_0, ref int P_1, IntPtr P_2, IntPtr P_3);

	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "PeekNamedPipe")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool NCYjzSeTgGCxAhPUbRIEqfsKFjrLb(IntPtr P_0, byte[] P_1, int P_2, out int P_3, out int P_4, out int P_5);

	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "HeapAlloc")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr foleXXBembuuyjRcVtaRSgsNHATZ(IntPtr P_0, int P_1, UIntPtr P_2);

	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "HeapFree")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr jKegVNxYtUrhtWdQkEUrvJRVZuYJ(IntPtr P_0, int P_1, IntPtr P_2);

	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "GetProcessHeap")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr ACQYJehXgFmLrAMBKGxekyzNOfeh();

	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "GlobalAlloc")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr SWBbhsnCtxtnsAAOIZrGXOibfBnJ(uint P_0, UIntPtr P_1);

	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "GlobalLock")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr vUDTBpbBjsfVyXORKpVlxpppBNJ(IntPtr P_0);

	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "GlobalUnlock")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool HHqlyHrLBCiIAiBNByYnahdclPJt(IntPtr P_0);

	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "GlobalFree")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr FJsGjnfSmqshwLvvAyKoexNTRGWMA(IntPtr P_0);

	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "GetCurrentThreadId")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int EzOkSVokLLddMbsuOHHJvPkkNDDxA();

	[DllImport("Kernel32.dll", EntryPoint = "IsWow64Process")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool GXiDqdIqDEGmiAaHuVIrUejvCud(IntPtr P_0, out bool P_1);

	[DllImport("kernel32.dll", EntryPoint = "GetOverlappedResult", SetLastError = true)]
	[SuppressUnmanagedCodeSecurity]
	internal static extern bool gXOPVpAgFInhDRiKaxeGCHnvYDHv(IntPtr P_0, [In] ref NativeOverlapped P_1, out uint P_2, bool P_3);

	[DllImport("kernel32.dll", EntryPoint = "GetOverlappedResult", SetLastError = true)]
	[SuppressUnmanagedCodeSecurity]
	internal static extern bool VWrkJaumJqfNFSVsNAsKbIteKXow(IntPtr P_0, IntPtr P_1, out uint P_2, bool P_3);

	[DllImport("user32.dll", CharSet = CharSet.Ansi, EntryPoint = "CreateWindowEx")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr hVvxPOrOXHeVUyuWKgFbNWDNHaBc(int P_0, string P_1, string P_2, int P_3, int P_4, int P_5, int P_6, int P_7, IntPtr P_8, IntPtr P_9, IntPtr P_10, IntPtr P_11);

	[DllImport("user32.dll", EntryPoint = "DestroyWindow")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr qddXvGUHZdYrqSbqteoAWaRglFPV(IntPtr P_0);

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "CallWindowProc")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr mLKoqAbNvVVrAUNTzlBQxUCtruuf(IntPtr P_0, IntPtr P_1, uint P_2, IntPtr P_3, IntPtr P_4);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "IsWindow")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool ByXvMirblrCeqBIFjIanKgSzoFIjA(IntPtr P_0);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetActiveWindow")]
	[SuppressUnmanagedCodeSecurity]
	private static extern IntPtr uzBthoOzzPsVbcLtgdwKAOOQOaqz();

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetFocus")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr eBwksmWRHcQmGRlSMvzpxuHTVQNM();

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetForegroundWindow")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr mXEkaNcGmWKTpdexOWkopORPRUhj();

	public static IntPtr VHhhdrwvXdMYfGOaVZvPTAZOrdoi(IntPtr P_0, int P_1)
	{
		if (IntPtr.Size == 4)
		{
			return KUqqpmtDJXEqpEVGicBgBhtcNUdrb(P_0, P_1);
		}
		return CKmHLOQaqBVXmpDLpHxJMGaKExad(P_0, P_1);
	}

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWindowLongW")]
	[SuppressUnmanagedCodeSecurity]
	private static extern IntPtr KUqqpmtDJXEqpEVGicBgBhtcNUdrb(IntPtr P_0, int P_1);

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWindowLongPtrW")]
	[SuppressUnmanagedCodeSecurity]
	private static extern IntPtr CKmHLOQaqBVXmpDLpHxJMGaKExad(IntPtr P_0, int P_1);

	public static IntPtr IQyiaepMIpAUzuUjfEtCBzAjRQbaA(IntPtr P_0, int P_1, IntPtr P_2)
	{
		if (IntPtr.Size == 4)
		{
			return HcUBKCAtckwAjvLJyCuTNqlpGfeaA(P_0, P_1, P_2);
		}
		return sRLAwVdXHdwlkYvEqMwFzqdSNuWH(P_0, P_1, P_2);
	}

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetWindowLongPtrW")]
	[SuppressUnmanagedCodeSecurity]
	private static extern IntPtr sRLAwVdXHdwlkYvEqMwFzqdSNuWH(IntPtr P_0, int P_1, IntPtr P_2);

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetWindowLongW")]
	[SuppressUnmanagedCodeSecurity]
	private static extern IntPtr HcUBKCAtckwAjvLJyCuTNqlpGfeaA(IntPtr P_0, int P_1, IntPtr P_2);

	[DllImport("user32.dll", EntryPoint = "DefWindowProcW", SetLastError = true)]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr eDpPpFIBUWUlfcncFGINcwPVkmpu(IntPtr P_0, uint P_1, IntPtr P_2, IntPtr P_3);

	[DllImport("User32.dll", EntryPoint = "EnumWindows")]
	[SuppressUnmanagedCodeSecurity]
	private static extern bool OnmipAMEtrvqNrdfnySBuExGTtID(IntPtr P_0, IntPtr P_1);

	[DllImport("User32.dll", EntryPoint = "GetWindowThreadProcessId")]
	[SuppressUnmanagedCodeSecurity]
	private static extern uint DLduKTbwocJzgfsUaIASWaIjtRSV(IntPtr P_0, out uint P_1);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetRawInputDeviceList")]
	[SuppressUnmanagedCodeSecurity]
	public static extern uint yqmAAQhZTtclMjQZTMAWbofgHnLbA(IntPtr P_0, ref uint P_1, uint P_2);

	[DllImport("User32.dll", EntryPoint = "GetRegisteredRawInputDevices")]
	[SuppressUnmanagedCodeSecurity]
	public static extern uint xoLbbmWBgtzoOVlDgbFxdfgwkIabA(IntPtr P_0, ref uint P_1, uint P_2);

	[DllImport("User32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetRawInputDeviceInfoW")]
	[SuppressUnmanagedCodeSecurity]
	public static extern uint wlmBAsCbIKItpDenLqrCELBEmlFRA(IntPtr P_0, uint P_1, IntPtr P_2, out uint P_3);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetRawInputData")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int eKbhtuSHcmrrPnZhvFZTyoUaHRJs(IntPtr P_0, uint P_1, IntPtr P_2, out uint P_3, uint P_4);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetRawInputBuffer")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int uneCjufpNESfKwuhUlbttutnCyUc(IntPtr P_0, ref uint P_1, uint P_2);

	[DllImport("User32.dll", EntryPoint = "SwapMouseButton")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool oxqhswpzvGeBZdRFkhEPFnluEkbh(bool P_0);

	[DllImport("User32.dll", EntryPoint = "SystemParametersInfo")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool dMDQtsHVqNljrQviWgxSQwXQEdhB(uint P_0, uint P_1, ref int P_2, uint P_3);

	[DllImport("User32.dll", EntryPoint = "GetSystemMetrics")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int IZogZeXadZkmTWhjTfNFMlnTMyIH(int P_0);

	[DllImport("User32.dll", EntryPoint = "GetMessageW")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool NUWDxsbEFldBOBEOQhDybSTUayAA(IntPtr P_0, IntPtr P_1, uint P_2, uint P_3);

	[DllImport("User32.dll", EntryPoint = "GetMessageW")]
	[SuppressUnmanagedCodeSecurity]
	public unsafe static extern bool xKMpaRqDPWBRjvIbTFpmYTaZRwzR(void* P_0, void* P_1, uint P_2, uint P_3);

	[DllImport("User32.dll", EntryPoint = "PeekMessageW")]
	[SuppressUnmanagedCodeSecurity]
	[return: MarshalAs(UnmanagedType.Bool)]
	public unsafe static extern bool WoKFiMJraUUIMrkoUwMNFpMuYDJ(void* P_0, IntPtr P_1, uint P_2, uint P_3, uint P_4);

	[DllImport("User32.dll", EntryPoint = "PeekMessageW")]
	[SuppressUnmanagedCodeSecurity]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool orulNObfQSFuMyvkRJAgGOkeodeX(byte[] P_0, IntPtr P_1, uint P_2, uint P_3, uint P_4);

	[DllImport("User32.dll", EntryPoint = "DispatchMessage")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr KlByGiaxQYfgugoZAyTtllEpVwpE(byte[] P_0);

	[DllImport("User32.dll", EntryPoint = "DispatchMessage")]
	[SuppressUnmanagedCodeSecurity]
	public unsafe static extern IntPtr CNfNsoHfiBbvwmBvQGSahpOxbMuD(void* P_0);

	[DllImport("User32.dll", EntryPoint = "TranslateMessage")]
	[SuppressUnmanagedCodeSecurity]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool IZMaNGKrzIpXNdWPrHrplVSLvMcG(byte[] P_0);

	[DllImport("User32.dll", EntryPoint = "TranslateMessage")]
	[SuppressUnmanagedCodeSecurity]
	[return: MarshalAs(UnmanagedType.Bool)]
	public unsafe static extern bool DYpFJqEqLlFiNKDFPbupKGUtGgGhA(void* P_0);

	[DllImport("User32.dll", EntryPoint = "SendMessage")]
	[SuppressUnmanagedCodeSecurity]
	public unsafe static extern void* CmOynDroxZIIPHdOjDiMvuGYofmH(void* P_0, uint P_1, void* P_2, void* P_3);

	[DllImport("User32.dll", EntryPoint = "SendMessage")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr etFeoTvvYOqzCwxvQLexPnIVsjQM(IntPtr P_0, uint P_1, IntPtr P_2, IntPtr P_3);

	[DllImport("User32.dll", EntryPoint = "SendMessageTimeout")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr gtnHsVEcVMCOUVhxqcsNPAMiXMkr(IntPtr P_0, uint P_1, IntPtr P_2, IntPtr P_3, uint P_4, uint P_5, IntPtr P_6);

	[DllImport("User32.dll", EntryPoint = "PostMessage")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool DxJaqNFnuwknBAeTdcNdCuAkqknh(IntPtr P_0, uint P_1, IntPtr P_2, IntPtr P_3);

	[DllImport("User32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "PostThreadMessage")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool eGmZwZruKwVKulnFaWOOqnFFWqQd(int P_0, uint P_1, IntPtr P_2, IntPtr P_3);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "SetCursorPos")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool mfnAmhGLGiLwLJyyNyqHrhwZDWFF(int P_0, int P_1);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetCursorPos")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool BXCtyoeWbgHpfdHmZvvsIomWckPT(out YHFgydabfVKogEplJlUPbsQAUVwsc P_0);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "OpenInputDesktop")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr wrxZVgqMCjHWLFSZtjLzifJtJHrQ(uint P_0, bool P_1, uint P_2);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetKeyState")]
	[SuppressUnmanagedCodeSecurity]
	public static extern short YcQtqcLlVmEQWxHUUbeCSoWjUVns(int P_0);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetAsyncKeyState")]
	[SuppressUnmanagedCodeSecurity]
	public static extern short DLQSTlMqxEMkxqBIPsXWMrIkpQiq(int P_0);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetKeyboardState")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool trFPpFjavMojFPgnyjYUTxYrIHYi(IntPtr P_0);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "ClientToScreen")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool NNpcYKSRsUCOJGNLyUFkwFLCIwAV(IntPtr P_0, out YHFgydabfVKogEplJlUPbsQAUVwsc P_1);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetClientRect")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool QmXdYYEzfvudwwDgiWmmLxshZNmX(IntPtr P_0, out VLEvDeFTjHAGRxCkIDxktnhuApPw P_1);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetWindowRect")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool oppLtzorEHLhosdyJGVjaOrSNUQe(IntPtr P_0, out VLEvDeFTjHAGRxCkIDxktnhuApPw P_1);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "MapVirtualKeyW")]
	[SuppressUnmanagedCodeSecurity]
	public static extern uint iIDLNpZYIpfRDsnSnPxLNWiSDeEO(uint P_0, uint P_1);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "MapVirtualKeyExW")]
	[SuppressUnmanagedCodeSecurity]
	public static extern uint gTxaClagTVafAlObyPeTdojfUsXQA(uint P_0, uint P_1, IntPtr P_2);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetKeyboardLayout")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr RjoXDcMjCNublPPbGDlXcFARuaxmA(int P_0);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode, EntryPoint = "GetKeyboardLayoutNameW")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool LSiDqlpxPIaijfxmjpcuRSCVBCluA(IntPtr P_0);

	[DllImport("msvcrt.dll", EntryPoint = "memcpy")]
	[SuppressUnmanagedCodeSecurity]
	public unsafe static extern bool dgNhgEkRseJcdUEVnMKYqSqJgOJR(void* P_0, void* P_1, UIntPtr P_2);

	public unsafe static bool EnGKcUpjRDhIrfnTroBwaAqqNiOO(void* P_0, void* P_1, int P_2)
	{
		return dgNhgEkRseJcdUEVnMKYqSqJgOJR(P_0, P_1, new UIntPtr((uint)P_2));
	}

	public static IntPtr ZHebZlPknMWIRGDCJrAPSeRLEbvp()
	{
		if (!UnityTools.isEditor && LIwPhtUeasWnoLwviIbjvjBMuBkl != IntPtr.Zero)
		{
			return LIwPhtUeasWnoLwviIbjvjBMuBkl;
		}
		return LIwPhtUeasWnoLwviIbjvjBMuBkl = uzBthoOzzPsVbcLtgdwKAOOQOaqz();
	}

	public static bool bbVFnKnZjNUKutuVQBaHiQlHicmd()
	{
		try
		{
			if (AlOcVoMgICgHRhgalsLUmfLPOJhRA == 0)
			{
				bool flag;
				if (IntPtr.Size == 8)
				{
					AlOcVoMgICgHRhgalsLUmfLPOJhRA = 2;
				}
				else if (GXiDqdIqDEGmiAaHuVIrUejvCud(cdykjPieVjohVAwxvzJwfCMzYcDA(), out flag))
				{
					if (flag)
					{
						AlOcVoMgICgHRhgalsLUmfLPOJhRA = 2;
					}
					else
					{
						AlOcVoMgICgHRhgalsLUmfLPOJhRA = 1;
					}
				}
			}
		}
		catch
		{
			AlOcVoMgICgHRhgalsLUmfLPOJhRA = 1;
		}
		return AlOcVoMgICgHRhgalsLUmfLPOJhRA == 2;
	}
}
