using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security;

internal class uWKQlxTIFCTIAOHYxAWaiOjCWvmH
{
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	internal class wyXSQSaaFxEoIjHlWFDzzURGDquNA
	{
		public int ZYWCvwJPxERTfQjomuWOGkSWdWgs;

		public int HgIcIsLAUShECWuSgbvAIJAvnavx;

		public int aEYVtrJjTofnhXIuvRpBvAbTdSly;

		public int XPGbpDEgTmBVxZLwxOLQnzNBPxvGA;

		public int JytlsOMKqaWceJHaTqWKPgRMpakw;

		public byte yMiVJGVqBkMJSNonQMOpxoGtAtFB;

		public byte izadJSffaIKLgQmiUPuTvCDqdMKG;

		public byte KuZyDICXuAHqUTAeBEWJDHjsqfhyA;

		public byte uTiNTdpyUvmmHlIbYuTCYulmXWCB;

		public byte KPZAGqtYYxDmgHHGDjkARDrRnqpk;

		public byte dDXZKrEMvCXFaWBUaLfBrlGQhDMo;

		public byte fheueMZUuGuXobBIPnYXlBCrvguC;

		public byte ZlFbDBCSEYeoUaZdcruxUQgvvKacA;

		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
		public string UuyHBcMoxGmpIGtMalEEROXcGaIV;
	}

	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	internal struct TcaxlOKIEDIkQSEsAwePrlqZgGRK
	{
		public int lHNzcNSITGMFuTnLMuvOVAsUlZhQ;

		public int VhAhPDWKsoOqjxZJigaCEJdSexFU;

		public int YTeWlNnmnqrbDhYgnSLJdbGAfaNc;

		public int YiggsgauYNdoGlGdQrOAJwIjutos;

		public int bQHEqFQOHpKbrfgvrkMfWCFEEPN;

		public int DUFKlOIvgdJbycmimQfqFnfNPXYB;

		public int QkhpMfpPqWDPUDFJZJTHIGFOwwVjA;

		public int awLZvvJoYGZQGvczWsxrVVthOUki;

		public int LUkmcNAsAHnpxcbfZdRDfDabGEbMA;

		public int kGkXiMvJKlPnumllgtlSVkJAaIwj;

		public int AwgDudRPCiZkwnDJABxyBkhfTeDBA;

		public char TCUbGemjVXflWGciQCHdWFblaCDJA;

		public char vbBTgvkDezXIaHAZFKYvspLZzTac;

		public char NEHLqRyGXWcsvQwrHeXIVnElrnTQ;

		public char ubYWtUMvaXoMisRpruNhxsJJroJp;

		public byte NnFFPAfHGmlNfJDwxqvLBotsIzbGA;

		public byte BtgJdvWMJxILUbFmBzSARGOycEjJ;

		public byte eSIbYBQsCEIxEPzyxHMIuYfnhSFG;

		public byte SoSAcJgEDabClIwHKZJRosFFkThV;

		public byte aKEbuMDsDmowjMAtBjqeXsxVDHC;
	}

	internal enum RigAhMHytGlcvTpkZwKNenSztmQkA
	{
		WndProc = -4,
		HInstance = -6,
		HwndParent = -8,
		Style = -16,
		ExtendedStyle = -20,
		UserData = -21,
		Id = -12
	}

	internal delegate IntPtr QDVVOVjVsrpxVMurbAgcOQNfTXVH(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);

	private delegate bool qFAHpgDldTFzvblLudcshCVdCqrec(IntPtr hwnd, IntPtr lParam);

	private static IntPtr iQCZzMLafRFzZKRZRdkOWiKlxDwR = IntPtr.Zero;

	private static List<IntPtr> HCmpgdthDRvixtghEooDlBHlGqLg;

	[DllImport("user32.dll", EntryPoint = "PeekMessage")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int vrXLJqkvfSwOGFDylAEFotNUZhNf(out pqhEiHqYuGQjHmbtbmuuukCSWAlg P_0, IntPtr P_1, int P_2, int P_3, int P_4);

	[DllImport("user32.dll", EntryPoint = "GetMessage")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int TfdXcQDdfgKsYiTNxfaVjHuyeSbR(out pqhEiHqYuGQjHmbtbmuuukCSWAlg P_0, IntPtr P_1, int P_2, int P_3);

	[DllImport("user32.dll", EntryPoint = "TranslateMessage")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int GuSbBFnneoDAfCRXhiUyRlfZkLXl(ref pqhEiHqYuGQjHmbtbmuuukCSWAlg P_0);

	[DllImport("user32.dll", EntryPoint = "DispatchMessage")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int HYGaXfhuEswJxKgmhqgQyRAjbPEhA(ref pqhEiHqYuGQjHmbtbmuuukCSWAlg P_0);

	public static IntPtr hbnUYTGIoSIIhbnmHHltGOzdnPPyA(HandleRef P_0, RigAhMHytGlcvTpkZwKNenSztmQkA P_1)
	{
		if (IntPtr.Size == 4)
		{
			return wHAeAqBOOyLZdbLofVgGwVxGubrrB(P_0, P_1);
		}
		return RCFibPbAqhJmOqHwRDRxgRSGDiKKA(P_0, P_1);
	}

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetFocus")]
	public static extern IntPtr MsgOgMMuzoFTVWsqcaRyrAHYamvz();

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWindowLong")]
	private static extern IntPtr wHAeAqBOOyLZdbLofVgGwVxGubrrB(HandleRef P_0, RigAhMHytGlcvTpkZwKNenSztmQkA P_1);

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWindowLongPtr")]
	private static extern IntPtr RCFibPbAqhJmOqHwRDRxgRSGDiKKA(HandleRef P_0, RigAhMHytGlcvTpkZwKNenSztmQkA P_1);

	public static IntPtr xBSbLxIPZZmtajpvkiGIdfgwTykIA(HandleRef P_0, RigAhMHytGlcvTpkZwKNenSztmQkA P_1, IntPtr P_2)
	{
		if (IntPtr.Size == 4)
		{
			return vXInbschBrAQjQYWkskVBpyRLLRh(P_0, P_1, P_2);
		}
		return vWNIGWKaUjgOwUIbiCnkMsKdEhfH(P_0, P_1, P_2);
	}

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetParent")]
	public static extern IntPtr OCIqYfiTFBdUqiCvVrALjtinUFbI(HandleRef P_0, IntPtr P_1);

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetWindowLong")]
	private static extern IntPtr vXInbschBrAQjQYWkskVBpyRLLRh(HandleRef P_0, RigAhMHytGlcvTpkZwKNenSztmQkA P_1, IntPtr P_2);

	public static bool tPNFjFKINrUhCAmGQLeHUOBTOiMi(HandleRef P_0, bool P_1)
	{
		return hvmEOheWcFsBgsnTweICFrEdMpBgA(P_0, P_1 ? 1 : 0);
	}

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "ShowWindow")]
	private static extern bool hvmEOheWcFsBgsnTweICFrEdMpBgA(HandleRef P_0, int P_1);

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetWindowLongPtr")]
	private static extern IntPtr vWNIGWKaUjgOwUIbiCnkMsKdEhfH(HandleRef P_0, RigAhMHytGlcvTpkZwKNenSztmQkA P_1, IntPtr P_2);

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "CallWindowProc")]
	public static extern IntPtr MMpnVRwNjbSquCjSHQMlFGRXMtPS(IntPtr P_0, IntPtr P_1, int P_2, IntPtr P_3, IntPtr P_4);

	[DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetModuleHandle")]
	public static extern IntPtr hJXgpHGsnyVanzHkfhIMPJIlUeQy(string P_0);

	public static IntPtr PxebMbZMBIQAXkxYetmxYMjsvOgP(IntPtr P_0, RigAhMHytGlcvTpkZwKNenSztmQkA P_1)
	{
		if (IntPtr.Size == 4)
		{
			return MxjfHJuTUJbTYebhHCKVmBnKoQlRA(P_0, P_1);
		}
		return DIVifDAftKSivBndlOzbfCEFiFYJA(P_0, P_1);
	}

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWindowLong")]
	private static extern IntPtr MxjfHJuTUJbTYebhHCKVmBnKoQlRA(IntPtr P_0, RigAhMHytGlcvTpkZwKNenSztmQkA P_1);

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWindowLongPtr")]
	private static extern IntPtr DIVifDAftKSivBndlOzbfCEFiFYJA(IntPtr P_0, RigAhMHytGlcvTpkZwKNenSztmQkA P_1);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "IsWindow")]
	public static extern bool FwIOTlatiXHiiMzVQbeIrVZzjwhF(IntPtr P_0);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetActiveWindow")]
	private static extern IntPtr EJkbvjgSjTulcOPEVLEYQNpQXyCx();

	[DllImport("Kernel32", EntryPoint = "GetCurrentProcessId")]
	private static extern uint jxeyLXoipORRXllyMcYwToZQGlwd();

	[DllImport("User32.dll", EntryPoint = "EnumWindows")]
	private static extern bool VdaHSdjQSMauGTGpyMmzSKZkyXGr(IntPtr P_0, IntPtr P_1);

	private static bool JAVcCFtEKXUJKzzsQNuseKbYhjTIA(IntPtr P_0, IntPtr P_1)
	{
		lock (HCmpgdthDRvixtghEooDlBHlGqLg)
		{
			HCmpgdthDRvixtghEooDlBHlGqLg.Add(P_0);
		}
		return true;
	}

	[DllImport("User32.dll", EntryPoint = "GetWindowThreadProcessId")]
	private static extern uint VyhEGxOpoFxXTIfGFoLKBiLBfFoF(IntPtr P_0, out uint P_1);

	public static IntPtr xNFDbymBlXmIGZyFXaHdFkpABeHfA()
	{
		if (iQCZzMLafRFzZKRZRdkOWiKlxDwR != IntPtr.Zero)
		{
			return iQCZzMLafRFzZKRZRdkOWiKlxDwR;
		}
		HCmpgdthDRvixtghEooDlBHlGqLg = new List<IntPtr>();
		uint num = jxeyLXoipORRXllyMcYwToZQGlwd();
		qFAHpgDldTFzvblLudcshCVdCqrec obj = JAVcCFtEKXUJKzzsQNuseKbYhjTIA;
		IntPtr functionPointerForDelegate = Marshal.GetFunctionPointerForDelegate(obj);
		VdaHSdjQSMauGTGpyMmzSKZkyXGr(functionPointerForDelegate, IntPtr.Zero);
		GC.KeepAlive(obj);
		GC.KeepAlive(functionPointerForDelegate);
		for (int i = 0; i < HCmpgdthDRvixtghEooDlBHlGqLg.Count; i++)
		{
			if (FwIOTlatiXHiiMzVQbeIrVZzjwhF(HCmpgdthDRvixtghEooDlBHlGqLg[i]))
			{
				VyhEGxOpoFxXTIfGFoLKBiLBfFoF(HCmpgdthDRvixtghEooDlBHlGqLg[i], out var num2);
				if (num2 == num)
				{
					iQCZzMLafRFzZKRZRdkOWiKlxDwR = HCmpgdthDRvixtghEooDlBHlGqLg[i];
					HCmpgdthDRvixtghEooDlBHlGqLg.Clear();
					return iQCZzMLafRFzZKRZRdkOWiKlxDwR;
				}
			}
		}
		return EJkbvjgSjTulcOPEVLEYQNpQXyCx();
	}
}
