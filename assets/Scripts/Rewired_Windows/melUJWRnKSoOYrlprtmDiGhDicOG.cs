using System;
using System.Runtime.InteropServices;
using System.Security;

internal static class melUJWRnKSoOYrlprtmDiGhDicOG
{
	public unsafe static int kMveKvoVMuQbKsHfgyShIxboncDm(int P_0, int P_1, out zYFpxUmfQBxKGXHniUXrrBMwrezX P_2)
	{
		if (INUUMVsygJzZqjuBcRMooeqGdhAl.qRXMdZsElCkPANdGRvFXUbBFyURM() >= QWAIIjTCJtCOEBBTvOMHGNihXtLzA.XINPUT_1_4)
		{
			P_2 = default;
			return 0;
		}
		P_2 = default;
		int result;
		fixed (zYFpxUmfQBxKGXHniUXrrBMwrezX* ptr = &P_2)
		{
			void* ptr2 = ptr;
			result = FqoPrPRwjziBJrBPqfQUuhmtgvwp(P_0, P_1, ptr2);
		}
		return result;
	}

	private unsafe static int FqoPrPRwjziBJrBPqfQUuhmtgvwp(int P_0, int P_1, void* P_2)
	{
		return INUUMVsygJzZqjuBcRMooeqGdhAl.qRXMdZsElCkPANdGRvFXUbBFyURM() switch
		{
			QWAIIjTCJtCOEBBTvOMHGNihXtLzA.XINPUT_1_3 => oQpYaoDdgQfccMPGGgjNjYdVkUhOA(P_0, P_1, P_2), 
			QWAIIjTCJtCOEBBTvOMHGNihXtLzA.XINPUT_1_2 => WQvGDwgenywQFsifyJHxcZOlCWZKA(P_0, P_1, P_2), 
			QWAIIjTCJtCOEBBTvOMHGNihXtLzA.XINPUT_1_1 => nLPANaADyPnmEFkOCsVKCgxntHnn(P_0, P_1, P_2), 
			QWAIIjTCJtCOEBBTvOMHGNihXtLzA.XINPUT_9_1_0 => GbnWpfxXdiWwJkJYXmjUqgVKrjaq(P_0, P_1, P_2), 
			_ => 0, 
		};
	}

	[DllImport("xinput9_1_0.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetKeystroke")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int GbnWpfxXdiWwJkJYXmjUqgVKrjaq(int P_0, int P_1, void* P_2);

	[DllImport("xinput1_1.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetKeystroke")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int nLPANaADyPnmEFkOCsVKCgxntHnn(int P_0, int P_1, void* P_2);

	[DllImport("xinput1_2.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetKeystroke")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int WQvGDwgenywQFsifyJHxcZOlCWZKA(int P_0, int P_1, void* P_2);

	[DllImport("xinput1_3.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetKeystroke")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int oQpYaoDdgQfccMPGGgjNjYdVkUhOA(int P_0, int P_1, void* P_2);

	public unsafe static int anIWwjXFyTQIyyDdrQTnkCEwjqAS(int P_0, EyvMMeJLDLfFqGCRzsLskiZBoyQp P_1)
	{
		return LQsUbXHwVnRRmwyGHAYURHyeUMYH(P_0, &P_1);
	}

	private unsafe static int LQsUbXHwVnRRmwyGHAYURHyeUMYH(int P_0, void* P_1)
	{
		return INUUMVsygJzZqjuBcRMooeqGdhAl.qRXMdZsElCkPANdGRvFXUbBFyURM() switch
		{
			QWAIIjTCJtCOEBBTvOMHGNihXtLzA.XINPUT_1_4 => KhJpECoJMUQfyHdSDdGGVlBnLVSt(P_0, P_1), 
			QWAIIjTCJtCOEBBTvOMHGNihXtLzA.XINPUT_1_3 => cZGfNThEBRDXoafUAqNDNaGrxnpFB(P_0, P_1), 
			QWAIIjTCJtCOEBBTvOMHGNihXtLzA.XINPUT_1_2 => lZLCsuDVJxOlECnfIVDrzrxdYpAJB(P_0, P_1), 
			QWAIIjTCJtCOEBBTvOMHGNihXtLzA.XINPUT_1_1 => OFoouoQbbeZFGtNGqvYXbqgbXLLC(P_0, P_1), 
			QWAIIjTCJtCOEBBTvOMHGNihXtLzA.XINPUT_9_1_0 => QktbrjGNYbMVeXmfrcahEeXVOubyA(P_0, P_1), 
			_ => 0, 
		};
	}

	[DllImport("xinput9_1_0.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputSetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int QktbrjGNYbMVeXmfrcahEeXVOubyA(int P_0, void* P_1);

	[DllImport("xinput1_1.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputSetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int OFoouoQbbeZFGtNGqvYXbqgbXLLC(int P_0, void* P_1);

	[DllImport("xinput1_2.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputSetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int lZLCsuDVJxOlECnfIVDrzrxdYpAJB(int P_0, void* P_1);

	[DllImport("xinput1_3.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputSetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int cZGfNThEBRDXoafUAqNDNaGrxnpFB(int P_0, void* P_1);

	[DllImport("xinput1_4.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputSetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int KhJpECoJMUQfyHdSDdGGVlBnLVSt(int P_0, void* P_1);

	public unsafe static int SIVvLojmsjZlBxDOfGLzahBNnVByA(int P_0, out Guid P_1, out Guid P_2)
	{
		P_1 = default;
		P_2 = default;
		int result;
		fixed (Guid* ptr = &P_1)
		{
			void* ptr2 = ptr;
			fixed (Guid* ptr3 = &P_2)
			{
				void* ptr4 = ptr3;
				result = cQEnoBvFUmzDtDXNnGFFhpIcFEAT(P_0, ptr2, ptr4);
			}
		}
		return result;
	}

	private unsafe static int cQEnoBvFUmzDtDXNnGFFhpIcFEAT(int P_0, void* P_1, void* P_2)
	{
		return INUUMVsygJzZqjuBcRMooeqGdhAl.qRXMdZsElCkPANdGRvFXUbBFyURM() switch
		{
			QWAIIjTCJtCOEBBTvOMHGNihXtLzA.XINPUT_1_3 => NuhoAKjfpSutzvAMJrhiWRWXKajD(P_0, P_1, P_2), 
			QWAIIjTCJtCOEBBTvOMHGNihXtLzA.XINPUT_1_2 => jHMSshOIgPPxIexPwfEzRvpoHaG(P_0, P_1, P_2), 
			QWAIIjTCJtCOEBBTvOMHGNihXtLzA.XINPUT_1_1 => HqWKZvIVkOaBlWDVxmZoThgJfBri(P_0, P_1, P_2), 
			QWAIIjTCJtCOEBBTvOMHGNihXtLzA.XINPUT_9_1_0 => KWEBEhKtWSdANdDxHQEAjzgisJft(P_0, P_1, P_2), 
			_ => 0, 
		};
	}

	[DllImport("xinput9_1_0.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetDSoundAudioDeviceGuids")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int KWEBEhKtWSdANdDxHQEAjzgisJft(int P_0, void* P_1, void* P_2);

	[DllImport("xinput1_1.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetDSoundAudioDeviceGuids")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int HqWKZvIVkOaBlWDVxmZoThgJfBri(int P_0, void* P_1, void* P_2);

	[DllImport("xinput1_2.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetDSoundAudioDeviceGuids")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int jHMSshOIgPPxIexPwfEzRvpoHaG(int P_0, void* P_1, void* P_2);

	[DllImport("xinput1_3.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetDSoundAudioDeviceGuids")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int NuhoAKjfpSutzvAMJrhiWRWXKajD(int P_0, void* P_1, void* P_2);

	[SuppressUnmanagedCodeSecurity]
	public unsafe static int OOPvSonbiEiJNkVbOaASLinZicAvA(int P_0, out RYLkkgImWyYdzAixxdcQbNKPqnGz P_1)
	{
		P_1 = default;
		int result;
		fixed (RYLkkgImWyYdzAixxdcQbNKPqnGz* ptr = &P_1)
		{
			void* ptr2 = ptr;
			result = hNuwjYdBLvbRyqPUgBkRCdlAWVuU(P_0, ptr2);
		}
		return result;
	}

	private unsafe static int hNuwjYdBLvbRyqPUgBkRCdlAWVuU(int P_0, void* P_1)
	{
		if (INUUMVsygJzZqjuBcRMooeqGdhAl.NQXGIKpVNVsXSHfpQcyLqHbBbUbI() && INUUMVsygJzZqjuBcRMooeqGdhAl.PHUmAqWhfIauNskmdcCUkeHSJPao() != null)
		{
			return INUUMVsygJzZqjuBcRMooeqGdhAl.PHUmAqWhfIauNskmdcCUkeHSJPao()(P_0, P_1);
		}
		return INUUMVsygJzZqjuBcRMooeqGdhAl.qRXMdZsElCkPANdGRvFXUbBFyURM() switch
		{
			QWAIIjTCJtCOEBBTvOMHGNihXtLzA.XINPUT_1_4 => XCEppGQbSLTNofyYmoPlpfeNdNpiA(P_0, P_1), 
			QWAIIjTCJtCOEBBTvOMHGNihXtLzA.XINPUT_1_3 => lccdLeFVRldkoeltZeBpTriHgeEAA(P_0, P_1), 
			QWAIIjTCJtCOEBBTvOMHGNihXtLzA.XINPUT_1_2 => TGGAadgcRoQkGvOuXLtLHpzKDMKR(P_0, P_1), 
			QWAIIjTCJtCOEBBTvOMHGNihXtLzA.XINPUT_1_1 => LOYLbNsFGMNxYDmaIbabLagvfLkh(P_0, P_1), 
			QWAIIjTCJtCOEBBTvOMHGNihXtLzA.XINPUT_9_1_0 => bNWgOsImLCAgsFblxartFFqzHYOCb(P_0, P_1), 
			_ => 0, 
		};
	}

	[DllImport("xinput9_1_0.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int bNWgOsImLCAgsFblxartFFqzHYOCb(int P_0, void* P_1);

	[DllImport("xinput1_1.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int LOYLbNsFGMNxYDmaIbabLagvfLkh(int P_0, void* P_1);

	[DllImport("xinput1_2.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int TGGAadgcRoQkGvOuXLtLHpzKDMKR(int P_0, void* P_1);

	[DllImport("xinput1_3.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int lccdLeFVRldkoeltZeBpTriHgeEAA(int P_0, void* P_1);

	[DllImport("xinput1_4.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int XCEppGQbSLTNofyYmoPlpfeNdNpiA(int P_0, void* P_1);

	public unsafe static int OvRBcResGtjQbSFIdGzvFVeRanPyA(int P_0, liDOKlvrxtESUNNgdekFnKBWUPUW P_1, out OoyeOgEaXDemhJzDXAyWLlBqTfCTA P_2)
	{
		P_2 = default;
		int result;
		fixed (OoyeOgEaXDemhJzDXAyWLlBqTfCTA* ptr = &P_2)
		{
			void* ptr2 = ptr;
			result = muBGzaFwThRWfjhjCsIaxzKYDKdgb(P_0, (int)P_1, ptr2);
		}
		return result;
	}

	private unsafe static int muBGzaFwThRWfjhjCsIaxzKYDKdgb(int P_0, int P_1, void* P_2)
	{
		return INUUMVsygJzZqjuBcRMooeqGdhAl.qRXMdZsElCkPANdGRvFXUbBFyURM() switch
		{
			QWAIIjTCJtCOEBBTvOMHGNihXtLzA.XINPUT_1_4 => TUazhbguLJEgOMZKDTQoFKppHcmp(P_0, P_1, P_2), 
			QWAIIjTCJtCOEBBTvOMHGNihXtLzA.XINPUT_1_3 => vryLeDUChWiGDKUDztpamMKHGZGJA(P_0, P_1, P_2), 
			QWAIIjTCJtCOEBBTvOMHGNihXtLzA.XINPUT_1_2 => ipqqtPZKvRBKuCmsVXuCQlxDiWKb(P_0, P_1, P_2), 
			QWAIIjTCJtCOEBBTvOMHGNihXtLzA.XINPUT_1_1 => wTfrkvpMdRTbzlNVGSKRtmZVjZDC(P_0, P_1, P_2), 
			QWAIIjTCJtCOEBBTvOMHGNihXtLzA.XINPUT_9_1_0 => LgEPkZVbcptscriscAdvhMkfyWLLA(P_0, P_1, P_2), 
			_ => 0, 
		};
	}

	[DllImport("xinput9_1_0.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetCapabilities")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int LgEPkZVbcptscriscAdvhMkfyWLLA(int P_0, int P_1, void* P_2);

	[DllImport("xinput1_1.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetCapabilities")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int wTfrkvpMdRTbzlNVGSKRtmZVjZDC(int P_0, int P_1, void* P_2);

	[DllImport("xinput1_2.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetCapabilities")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int ipqqtPZKvRBKuCmsVXuCQlxDiWKb(int P_0, int P_1, void* P_2);

	[DllImport("xinput1_3.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetCapabilities")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int vryLeDUChWiGDKUDztpamMKHGZGJA(int P_0, int P_1, void* P_2);

	[DllImport("xinput1_4.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetCapabilities")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int TUazhbguLJEgOMZKDTQoFKppHcmp(int P_0, int P_1, void* P_2);

	public unsafe static int TwLeAbhFljrwvjcDByYuLjDTZQsF(int P_0, QghYJzbNGrCoorJibjqIgceYWnhRA P_1, out BqtfOHJlobvRtesBBOSneKFUxivG P_2)
	{
		P_2 = default;
		int result;
		fixed (BqtfOHJlobvRtesBBOSneKFUxivG* ptr = &P_2)
		{
			void* ptr2 = ptr;
			result = NMaZAkuCPaMGyFIaZvXxDbAqgjdHA(P_0, (int)P_1, ptr2);
		}
		return result;
	}

	private unsafe static int NMaZAkuCPaMGyFIaZvXxDbAqgjdHA(int P_0, int P_1, void* P_2)
	{
		return INUUMVsygJzZqjuBcRMooeqGdhAl.qRXMdZsElCkPANdGRvFXUbBFyURM() switch
		{
			QWAIIjTCJtCOEBBTvOMHGNihXtLzA.XINPUT_1_3 => ATjfyBsOajXJNLhijpLVpurxgjCc(P_0, P_1, P_2), 
			QWAIIjTCJtCOEBBTvOMHGNihXtLzA.XINPUT_1_2 => sksxiCbFZQaWBvjMSbVCtLeUaYwy(P_0, P_1, P_2), 
			QWAIIjTCJtCOEBBTvOMHGNihXtLzA.XINPUT_1_1 => djbwFCpQgVbNHqotiHlDYIdSsLpN(P_0, P_1, P_2), 
			QWAIIjTCJtCOEBBTvOMHGNihXtLzA.XINPUT_9_1_0 => AgoUApErKTgIqxndTePaHEEnYhirA(P_0, P_1, P_2), 
			_ => 0, 
		};
	}

	[DllImport("xinput9_1_0.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetBatteryInformation")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int AgoUApErKTgIqxndTePaHEEnYhirA(int P_0, int P_1, void* P_2);

	[DllImport("xinput1_1.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetBatteryInformation")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int djbwFCpQgVbNHqotiHlDYIdSsLpN(int P_0, int P_1, void* P_2);

	[DllImport("xinput1_2.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetBatteryInformation")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int sksxiCbFZQaWBvjMSbVCtLeUaYwy(int P_0, int P_1, void* P_2);

	[DllImport("xinput1_3.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetBatteryInformation")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int ATjfyBsOajXJNLhijpLVpurxgjCc(int P_0, int P_1, void* P_2);

	public static void ABxXALopDkiYeFYMMeqyxieTzymD(yIoBtaChIoindKBwciZemWSmKuZR P_0)
	{
		xQFuoNhxNBvcKXHMaeOgFPUtXQJy(P_0);
	}

	private static void xQFuoNhxNBvcKXHMaeOgFPUtXQJy(yIoBtaChIoindKBwciZemWSmKuZR P_0)
	{
		switch (INUUMVsygJzZqjuBcRMooeqGdhAl.qRXMdZsElCkPANdGRvFXUbBFyURM())
		{
		case QWAIIjTCJtCOEBBTvOMHGNihXtLzA.XINPUT_1_3:
			QWvpvfvbpgGOtCmbalvETAtkpVBab(P_0);
			break;
		case QWAIIjTCJtCOEBBTvOMHGNihXtLzA.XINPUT_1_2:
			OOLhihGyEKWjaePAagtLyimJfTjD(P_0);
			break;
		case QWAIIjTCJtCOEBBTvOMHGNihXtLzA.XINPUT_1_1:
			DWsPPWLpwQOpQsHsEixnKATQsEsy(P_0);
			break;
		case QWAIIjTCJtCOEBBTvOMHGNihXtLzA.XINPUT_9_1_0:
			PNwFbUpNhjybRvOHrHifHSzTJRES(P_0);
			break;
		}
	}

	[DllImport("xinput9_1_0.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputEnable")]
	[SuppressUnmanagedCodeSecurity]
	private static extern void PNwFbUpNhjybRvOHrHifHSzTJRES(yIoBtaChIoindKBwciZemWSmKuZR P_0);

	[DllImport("xinput1_1.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputEnable")]
	[SuppressUnmanagedCodeSecurity]
	private static extern void DWsPPWLpwQOpQsHsEixnKATQsEsy(yIoBtaChIoindKBwciZemWSmKuZR P_0);

	[DllImport("xinput1_2.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputEnable")]
	[SuppressUnmanagedCodeSecurity]
	private static extern void OOLhihGyEKWjaePAagtLyimJfTjD(yIoBtaChIoindKBwciZemWSmKuZR P_0);

	[DllImport("xinput1_3.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputEnable")]
	[SuppressUnmanagedCodeSecurity]
	private static extern void QWvpvfvbpgGOtCmbalvETAtkpVBab(yIoBtaChIoindKBwciZemWSmKuZR P_0);
}
