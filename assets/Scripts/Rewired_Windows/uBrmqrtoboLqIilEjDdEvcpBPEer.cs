using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Rewired;
using Rewired.Utils;
using Rewired.Utils.Classes.Utility;

internal sealed class uBrmqrtoboLqIilEjDdEvcpBPEer : UjfFJagRWmzCLelDMFkwHkECaNKIB, IDisposable
{
	private delegate YPXdjQKCWfIAfUTGZOwYMqzQnnaBA nNBhuQpfnEGKuGCNpKZDhZDRDlGnA(int timeout);

	private delegate vkHQVZflUwCnErmdIHutDievbIce JdNUtHisPdOWxRjOjBhrTPrCBTJu(int timeout);

	private delegate bool XTNGDCDpmzbqZPtJZEFjtDWhClLB(byte[] data, int timeout);

	private delegate bool aZvzdkrrTSWRakjaQgQvwnEVHHiV(byte[] data, int timeout, bool setOutputReportDirectly);

	private delegate bool INdEGNJaxOTfHeuYjXHdOhJpOyVyA(vkHQVZflUwCnErmdIHutDievbIce report, int timeout);

	private enum IRUTLHaKkXikYewvXkRTDnWUFQXpA
	{
		Closed = 0,
		Read = 1,
		Write = 2
	}

	private enum PcsonntHfWInNqaYZMPANOLqQWcC
	{
		Success = 0,
		ReadError = 1,
		BufferTooSmall = 2,
		DeviceNotOpen = 3
	}

	private struct xVTqCnuAvObcqAgojFZRMvKYdgbMA
	{
		public bool NvScqeYwAppcQFVYljxRxbUkKlXB;

		public int weSbFvNdEMUnYJfdONQjpCrNPDnv;

		public int aRPPtFeIHuApuFTNCbhgTBudLwrS;
	}

	public const int zSTiDMCfNBFaHbGUoyChtskrDKKeA = 255;

	[CompilerGenerated]
	private VvyZyfPYzwIxVzGlWQUiszMUjDel hREGrTgPdMslamuGMrQkszHDGMrfA;

	[CompilerGenerated]
	private KbImCtgqUtTBuHALlYAdjdKTHMeI SSUdRJkvOCLQQlLcfJEwcJGbyZBnb;

	private readonly string ycaEJUyrLACJGGprowGcqbRxONzB;

	private readonly string tzQWAcMmnUlXPWzFcgtVztjAIkbi;

	private readonly string rzssJmUjKDFhZNgCASlUOBFlDCjKA;

	private readonly string GwpgMpeJmHcGgZvTfpvFmkCsFjwE;

	private readonly xRdvJrjnuAKDcrZmDYbIabxCedKX PrNzHBLlyjGjWiAiQjOKxasiylKNA;

	private readonly string DMGgnoxUkhvwYLwMYbMDmZUzoWq;

	private readonly int pJSIRFDDUhFFFYBtofQTCqLsbVjPA;

	private readonly int asAIfURkKvZuIVDzmUQbzFQWrLjO;

	private readonly bool ZdzAiHDPeZVQCTMuAkQowrcSDQvQA;

	private readonly string LeByTnpLXWuozYjFRRhlNvrzeseR;

	private readonly uint uwgSBHuzNZGSdSrCXwLaTvDrkEcu;

	private readonly NqTosaasjQkHHuLirCdfKTHVvRdf SQLLdjgoUifADgbWVoEgGHeMCdVfb;

	private readonly wxlHCDILRVcoBHEmujveTRxbstif[] SaAjFlfnyrUMaMKkIGrSYnuQXWDI;

	private readonly PdfAqamcmCtcqUOoEkGdViEMjvPj[] qekFYBGyjAPKMmGPZDeXOQHnyDwA;

	private ctOFTJFVBKiuzGJBAAphUVuqjMxQ fDrjawoBrsqdtDBbxUiPMGOhdhfv;

	private ctOFTJFVBKiuzGJBAAphUVuqjMxQ CIqrWPNQdKQiQlosZohKNmVIehik;

	private hKqNTnjGuYYhXibhfhIzNpZPKuhD sfBZSwBBYBcEgMSwAHaapleDxmRG = hKqNTnjGuYYhXibhfhIzNpZPKuhD.ShareRead | hKqNTnjGuYYhXibhfhIzNpZPKuhD.ShareWrite;

	private readonly LcooAthyCAZKYltIcZeoddlzInnn ttZnMVjgIEeiHSuasQJHaXWUcitS;

	private bool XkcdYTHwKpZtZPVipWSmMINsSfRdA;

	private global::ObqXgUUqhavcGIoFqIXpOyTOjTCP<ShLxNDAuNJnTDKEaZHAvIhFLYQDS.xeNSalaogCBYWePkykAFqDDAiyIg> wwgPdgFdpnDQIebrZMoiJiETvrTp;

	private global::ObqXgUUqhavcGIoFqIXpOyTOjTCP<ShLxNDAuNJnTDKEaZHAvIhFLYQDS.SApgQYHIDWDqrfeOlHCjwjtAOodt> RgDlNfgSpfenddKufXDQKMEKepxF;

	private readonly Rewired.Utils.Classes.Utility.SpinLock pVeYldnHjDCiTtkbcuMLOkLLUgxx = new Rewired.Utils.Classes.Utility.SpinLock();

	private readonly Rewired.Utils.Classes.Utility.SpinLock USRgnwgxtBXHUBoNCYwDcafJHxAsA = new Rewired.Utils.Classes.Utility.SpinLock();

	private IntPtr aYgIULzxVqvrjPizFiDgtSXKNWjB;

	private IntPtr PHbSpyWRDwVpTwBDFldLQnmQItiS;

	private IRUTLHaKkXikYewvXkRTDnWUFQXpA GaJUdgoEcMcedKzAylDUNQBvAMad;

	private bool rqTRpwiNcnAdmCJLMAnGOjvoEljwA;

	IntPtr vaRFlAeftfeygrtdFHwbGfAGyLmTB => vaRFlAeftfeygrtdFHwbGfAGyLmTB();

	IntPtr VfOtclgtTWHotvIXNjmnRIonOyaS => VfOtclgtTWHotvIXNjmnRIonOyaS();

	bool SwdZZXItdAxqXkaFGXYNYTwJNGzA => SwdZZXItdAxqXkaFGXYNYTwJNGzA();

	bool DDsnoKnuxGMCedoTbtddmSvEcQd => DDsnoKnuxGMCedoTbtddmSvEcQd();

	string dOXwUcbecPBhSzWZgEhNILhrishdb => dOXwUcbecPBhSzWZgEhNILhrishdb();

	NqTosaasjQkHHuLirCdfKTHVvRdf DCDITUFElKaxOgCQcaRhktRwtpcSB => DCDITUFElKaxOgCQcaRhktRwtpcSB();

	wxlHCDILRVcoBHEmujveTRxbstif[] mEfAvTGrCcnzyHvBbcuZCophePEX => mEfAvTGrCcnzyHvBbcuZCophePEX();

	PdfAqamcmCtcqUOoEkGdViEMjvPj[] hSKdZzAvUoaufhblnRJOmkKfSfNu => hSKdZzAvUoaufhblnRJOmkKfSfNu();

	xRdvJrjnuAKDcrZmDYbIabxCedKX TBoecGyQrYspnUDeIhekQaWBMhqu => TBoecGyQrYspnUDeIhekQaWBMhqu();

	string WFjPceWDyJnucLpfLZOwrGqClgAO => WFjPceWDyJnucLpfLZOwrGqClgAO();

	string kLVwMGeYdkDlwQQNUafKYLiJhIfw => kLVwMGeYdkDlwQQNUafKYLiJhIfw();

	string WcZVAqvLVobpMATEcPpokdXNLJZm => WcZVAqvLVobpMATEcPpokdXNLJZm();

	string adPKeIVinSjsHFZCbIMtbpQLrxtb => adPKeIVinSjsHFZCbIMtbpQLrxtb();

	int OgWbqpynwGbCQvOGtHHLSzZxtuRD => OgWbqpynwGbCQvOGtHHLSzZxtuRD();

	int cPmBfxDCbfnDrqqIYoNIcfwbMkWrA => cPmBfxDCbfnDrqqIYoNIcfwbMkWrA();

	bool iuUBqEHRKPcdgdCWAXiJEkVtJJFab => iuUBqEHRKPcdgdCWAXiJEkVtJJFab();

	string rxifAziAOBcmNmfelsmhEqmsQBKlA => rxifAziAOBcmNmfelsmhEqmsQBKlA();

	bool xLLEgQpYBAxizikKumbQzNYiOTdE => xLLEgQpYBAxizikKumbQzNYiOTdE();

	bool yZxdcdxWCaJNIVGylivVNYepXyMj
	{
		get
		{
			return yZxdcdxWCaJNIVGylivVNYepXyMj();
		}
		set
		{
			DvWyHPMimvZDwjgcgLoTrtOjTSjw(flag);
		}
	}

	event VvyZyfPYzwIxVzGlWQUiszMUjDel dUCAgtaKEJUDwWkbBiZGDySKQtWEb
	{
		add
		{
			dUCAgtaKEJUDwWkbBiZGDySKQtWEb(vvyZyfPYzwIxVzGlWQUiszMUjDel);
		}
		remove
		{
			cMJfUbqIBSjRIoNErflgeqaTOPdCA(vvyZyfPYzwIxVzGlWQUiszMUjDel);
		}
	}

	event KbImCtgqUtTBuHALlYAdjdKTHMeI aHbCQiSDnLEqetHuErkJbCIvYvav
	{
		add
		{
			aHbCQiSDnLEqetHuErkJbCIvYvav(kbImCtgqUtTBuHALlYAdjdKTHMeI);
		}
		remove
		{
			PJWHHNgACgwDocyBhyrKIwMybFej(kbImCtgqUtTBuHALlYAdjdKTHMeI);
		}
	}

	public void dUCAgtaKEJUDwWkbBiZGDySKQtWEb(VvyZyfPYzwIxVzGlWQUiszMUjDel P_0)
	{
		VvyZyfPYzwIxVzGlWQUiszMUjDel vvyZyfPYzwIxVzGlWQUiszMUjDel = hREGrTgPdMslamuGMrQkszHDGMrfA;
		VvyZyfPYzwIxVzGlWQUiszMUjDel vvyZyfPYzwIxVzGlWQUiszMUjDel2;
		do
		{
			vvyZyfPYzwIxVzGlWQUiszMUjDel2 = vvyZyfPYzwIxVzGlWQUiszMUjDel;
			VvyZyfPYzwIxVzGlWQUiszMUjDel value = (VvyZyfPYzwIxVzGlWQUiszMUjDel)Delegate.Combine(vvyZyfPYzwIxVzGlWQUiszMUjDel2, P_0);
			vvyZyfPYzwIxVzGlWQUiszMUjDel = Interlocked.CompareExchange(ref hREGrTgPdMslamuGMrQkszHDGMrfA, value, vvyZyfPYzwIxVzGlWQUiszMUjDel2);
		}
		while ((object)vvyZyfPYzwIxVzGlWQUiszMUjDel != vvyZyfPYzwIxVzGlWQUiszMUjDel2);
	}

	public void cMJfUbqIBSjRIoNErflgeqaTOPdCA(VvyZyfPYzwIxVzGlWQUiszMUjDel P_0)
	{
		VvyZyfPYzwIxVzGlWQUiszMUjDel vvyZyfPYzwIxVzGlWQUiszMUjDel = hREGrTgPdMslamuGMrQkszHDGMrfA;
		VvyZyfPYzwIxVzGlWQUiszMUjDel vvyZyfPYzwIxVzGlWQUiszMUjDel2;
		do
		{
			vvyZyfPYzwIxVzGlWQUiszMUjDel2 = vvyZyfPYzwIxVzGlWQUiszMUjDel;
			VvyZyfPYzwIxVzGlWQUiszMUjDel value = (VvyZyfPYzwIxVzGlWQUiszMUjDel)Delegate.Remove(vvyZyfPYzwIxVzGlWQUiszMUjDel2, P_0);
			vvyZyfPYzwIxVzGlWQUiszMUjDel = Interlocked.CompareExchange(ref hREGrTgPdMslamuGMrQkszHDGMrfA, value, vvyZyfPYzwIxVzGlWQUiszMUjDel2);
		}
		while ((object)vvyZyfPYzwIxVzGlWQUiszMUjDel != vvyZyfPYzwIxVzGlWQUiszMUjDel2);
	}

	public void aHbCQiSDnLEqetHuErkJbCIvYvav(KbImCtgqUtTBuHALlYAdjdKTHMeI P_0)
	{
		KbImCtgqUtTBuHALlYAdjdKTHMeI kbImCtgqUtTBuHALlYAdjdKTHMeI = SSUdRJkvOCLQQlLcfJEwcJGbyZBnb;
		KbImCtgqUtTBuHALlYAdjdKTHMeI kbImCtgqUtTBuHALlYAdjdKTHMeI2;
		do
		{
			kbImCtgqUtTBuHALlYAdjdKTHMeI2 = kbImCtgqUtTBuHALlYAdjdKTHMeI;
			KbImCtgqUtTBuHALlYAdjdKTHMeI value = (KbImCtgqUtTBuHALlYAdjdKTHMeI)Delegate.Combine(kbImCtgqUtTBuHALlYAdjdKTHMeI2, P_0);
			kbImCtgqUtTBuHALlYAdjdKTHMeI = Interlocked.CompareExchange(ref SSUdRJkvOCLQQlLcfJEwcJGbyZBnb, value, kbImCtgqUtTBuHALlYAdjdKTHMeI2);
		}
		while ((object)kbImCtgqUtTBuHALlYAdjdKTHMeI != kbImCtgqUtTBuHALlYAdjdKTHMeI2);
	}

	public void PJWHHNgACgwDocyBhyrKIwMybFej(KbImCtgqUtTBuHALlYAdjdKTHMeI P_0)
	{
		KbImCtgqUtTBuHALlYAdjdKTHMeI kbImCtgqUtTBuHALlYAdjdKTHMeI = SSUdRJkvOCLQQlLcfJEwcJGbyZBnb;
		KbImCtgqUtTBuHALlYAdjdKTHMeI kbImCtgqUtTBuHALlYAdjdKTHMeI2;
		do
		{
			kbImCtgqUtTBuHALlYAdjdKTHMeI2 = kbImCtgqUtTBuHALlYAdjdKTHMeI;
			KbImCtgqUtTBuHALlYAdjdKTHMeI value = (KbImCtgqUtTBuHALlYAdjdKTHMeI)Delegate.Remove(kbImCtgqUtTBuHALlYAdjdKTHMeI2, P_0);
			kbImCtgqUtTBuHALlYAdjdKTHMeI = Interlocked.CompareExchange(ref SSUdRJkvOCLQQlLcfJEwcJGbyZBnb, value, kbImCtgqUtTBuHALlYAdjdKTHMeI2);
		}
		while ((object)kbImCtgqUtTBuHALlYAdjdKTHMeI != kbImCtgqUtTBuHALlYAdjdKTHMeI2);
	}

	public IntPtr vaRFlAeftfeygrtdFHwbGfAGyLmTB()
	{
		return aYgIULzxVqvrjPizFiDgtSXKNWjB;
	}

	public IntPtr VfOtclgtTWHotvIXNjmnRIonOyaS()
	{
		return PHbSpyWRDwVpTwBDFldLQnmQItiS;
	}

	public bool SwdZZXItdAxqXkaFGXYNYTwJNGzA()
	{
		using (pVeYldnHjDCiTtkbcuMLOkLLUgxx.Lock())
		{
			using (USRgnwgxtBXHUBoNCYwDcafJHxAsA.Lock())
			{
				return GaJUdgoEcMcedKzAylDUNQBvAMad != IRUTLHaKkXikYewvXkRTDnWUFQXpA.Closed;
			}
		}
	}

	public bool DDsnoKnuxGMCedoTbtddmSvEcQd()
	{
		return jJVMeOSGFiWvYXFSLLMERjkQCZOv.TLqMDQefyqSrEEltqOfbmKGXgxSZ(tzQWAcMmnUlXPWzFcgtVztjAIkbi);
	}

	public string dOXwUcbecPBhSzWZgEhNILhrishdb()
	{
		return ycaEJUyrLACJGGprowGcqbRxONzB;
	}

	public NqTosaasjQkHHuLirCdfKTHVvRdf DCDITUFElKaxOgCQcaRhktRwtpcSB()
	{
		return SQLLdjgoUifADgbWVoEgGHeMCdVfb;
	}

	public wxlHCDILRVcoBHEmujveTRxbstif[] mEfAvTGrCcnzyHvBbcuZCophePEX()
	{
		return SaAjFlfnyrUMaMKkIGrSYnuQXWDI;
	}

	public PdfAqamcmCtcqUOoEkGdViEMjvPj[] hSKdZzAvUoaufhblnRJOmkKfSfNu()
	{
		return qekFYBGyjAPKMmGPZDeXOQHnyDwA;
	}

	public xRdvJrjnuAKDcrZmDYbIabxCedKX TBoecGyQrYspnUDeIhekQaWBMhqu()
	{
		return PrNzHBLlyjGjWiAiQjOKxasiylKNA;
	}

	public string WFjPceWDyJnucLpfLZOwrGqClgAO()
	{
		return tzQWAcMmnUlXPWzFcgtVztjAIkbi;
	}

	public string kLVwMGeYdkDlwQQNUafKYLiJhIfw()
	{
		return rzssJmUjKDFhZNgCASlUOBFlDCjKA;
	}

	public string WcZVAqvLVobpMATEcPpokdXNLJZm()
	{
		return GwpgMpeJmHcGgZvTfpvFmkCsFjwE;
	}

	public string adPKeIVinSjsHFZCbIMtbpQLrxtb()
	{
		return DMGgnoxUkhvwYLwMYbMDmZUzoWq;
	}

	public int OgWbqpynwGbCQvOGtHHLSzZxtuRD()
	{
		return pJSIRFDDUhFFFYBtofQTCqLsbVjPA;
	}

	public int cPmBfxDCbfnDrqqIYoNIcfwbMkWrA()
	{
		return asAIfURkKvZuIVDzmUQbzFQWrLjO;
	}

	public bool iuUBqEHRKPcdgdCWAXiJEkVtJJFab()
	{
		return ZdzAiHDPeZVQCTMuAkQowrcSDQvQA;
	}

	public string rxifAziAOBcmNmfelsmhEqmsQBKlA()
	{
		return LeByTnpLXWuozYjFRRhlNvrzeseR;
	}

	public bool xLLEgQpYBAxizikKumbQzNYiOTdE()
	{
		if (asAIfURkKvZuIVDzmUQbzFQWrLjO >= 0)
		{
			return pJSIRFDDUhFFFYBtofQTCqLsbVjPA >= 0;
		}
		return false;
	}

	public bool yZxdcdxWCaJNIVGylivVNYepXyMj()
	{
		return XkcdYTHwKpZtZPVipWSmMINsSfRdA;
	}

	public void DvWyHPMimvZDwjgcgLoTrtOjTSjw(bool P_0)
	{
		if (P_0 & !XkcdYTHwKpZtZPVipWSmMINsSfRdA)
		{
			ttZnMVjgIEeiHSuasQJHaXWUcitS.GgcrayjCsGloINSDWnSEMgtMxEYn();
		}
		XkcdYTHwKpZtZPVipWSmMINsSfRdA = P_0;
	}

	[CustomObfuscation(rename = false)]
	private uBrmqrtoboLqIilEjDdEvcpBPEer()
	{
		uwgSBHuzNZGSdSrCXwLaTvDrkEcu = ObjectInstanceTracker.Default.Register(this);
		RgDlNfgSpfenddKufXDQKMEKepxF = new global::ObqXgUUqhavcGIoFqIXpOyTOjTCP<ShLxNDAuNJnTDKEaZHAvIhFLYQDS.SApgQYHIDWDqrfeOlHCjwjtAOodt>();
		wwgPdgFdpnDQIebrZMoiJiETvrTp = new global::ObqXgUUqhavcGIoFqIXpOyTOjTCP<ShLxNDAuNJnTDKEaZHAvIhFLYQDS.xeNSalaogCBYWePkykAFqDDAiyIg>();
	}

	[CustomObfuscation(rename = false)]
	internal uBrmqrtoboLqIilEjDdEvcpBPEer(string P_0, string P_1, string P_2, string P_3, int P_4, int P_5, bool P_6, string P_7)
		: this()
	{
		ttZnMVjgIEeiHSuasQJHaXWUcitS = new LcooAthyCAZKYltIcZeoddlzInnn(this);
		ttZnMVjgIEeiHSuasQJHaXWUcitS.QZBesuJLrwbeIrKetFyoKMEvEYlKA(EYBbxRICJjTqfEYBpwWPCXjOxwtB);
		ttZnMVjgIEeiHSuasQJHaXWUcitS.jFMACZWTDOjsQccTxJOjrEHnkimxA(PCpLRGqoijnTJhFeIJtgVGqPXvDi);
		tzQWAcMmnUlXPWzFcgtVztjAIkbi = P_0;
		rzssJmUjKDFhZNgCASlUOBFlDCjKA = OxKeauxLUpOkqzUbEfAbQPUKOxxA.zyOhEyYnzUZnWEITNEfwzUcFUSyx(P_0);
		GwpgMpeJmHcGgZvTfpvFmkCsFjwE = P_1;
		ycaEJUyrLACJGGprowGcqbRxONzB = StringTools.SanitizeDeviceString(P_2);
		DMGgnoxUkhvwYLwMYbMDmZUzoWq = StringTools.SanitizeDeviceString(P_3);
		pJSIRFDDUhFFFYBtofQTCqLsbVjPA = P_4;
		asAIfURkKvZuIVDzmUQbzFQWrLjO = P_5;
		ZdzAiHDPeZVQCTMuAkQowrcSDQvQA = P_6;
		LeByTnpLXWuozYjFRRhlNvrzeseR = StringTools.SanitizeDeviceString(P_7);
		IntPtr intPtr = IntPtr.Zero;
		try
		{
			intPtr = gWjGJUhMvvfdSztdGkHOvFhFxUtv(tzQWAcMmnUlXPWzFcgtVztjAIkbi, fDrjawoBrsqdtDBbxUiPMGOhdhfv, 0u, sfBZSwBBYBcEgMSwAHaapleDxmRG);
			PrNzHBLlyjGjWiAiQjOKxasiylKNA = dXsQQeFIwWEMYUSTwANCOgjRamlR(intPtr);
			SQLLdjgoUifADgbWVoEgGHeMCdVfb = FpPExrBxktREmNOUDfQaIdpFEQjl(intPtr);
			SaAjFlfnyrUMaMKkIGrSYnuQXWDI = hadyVWcKuGFUzZyLjLSGQPXZQjlu(intPtr, 0, SQLLdjgoUifADgbWVoEgGHeMCdVfb.GFMZjQRFCyahzuPVbSyMRMYMTBZI());
			qekFYBGyjAPKMmGPZDeXOQHnyDwA = aJtwmwijQyueiVzaHWwwuWpxWtEH(intPtr, 0, SQLLdjgoUifADgbWVoEgGHeMCdVfb.eMIZiBZtRZbrQbMxodDfErlqrAw());
			loNBgHHnJJMkGKStYGscmBCMLcfeA(intPtr);
			intPtr = IntPtr.Zero;
		}
		catch (Exception ex)
		{
			throw new Exception($"Error querying HID device \"{P_0}\" at location {intPtr}.\nException Message: {ex.Message}\nStack Trace: {ex.StackTrace}", ex);
		}
		finally
		{
			if (intPtr != IntPtr.Zero)
			{
				try
				{
					loNBgHHnJJMkGKStYGscmBCMLcfeA(intPtr);
				}
				catch
				{
				}
			}
		}
	}

	private uBrmqrtoboLqIilEjDdEvcpBPEer(xRdvJrjnuAKDcrZmDYbIabxCedKX P_0, NqTosaasjQkHHuLirCdfKTHVvRdf P_1, wxlHCDILRVcoBHEmujveTRxbstif[] P_2, PdfAqamcmCtcqUOoEkGdViEMjvPj[] P_3)
		: this()
	{
		string text = "SIMULATED DEVICE";
		string text2 = "MANUFACTURER";
		string text3 = "SIMULATED";
		string gwpgMpeJmHcGgZvTfpvFmkCsFjwE = "SIMULATED";
		tzQWAcMmnUlXPWzFcgtVztjAIkbi = text3;
		rzssJmUjKDFhZNgCASlUOBFlDCjKA = OxKeauxLUpOkqzUbEfAbQPUKOxxA.zyOhEyYnzUZnWEITNEfwzUcFUSyx(text3);
		GwpgMpeJmHcGgZvTfpvFmkCsFjwE = gwpgMpeJmHcGgZvTfpvFmkCsFjwE;
		ycaEJUyrLACJGGprowGcqbRxONzB = StringTools.SanitizeDeviceString(text);
		DMGgnoxUkhvwYLwMYbMDmZUzoWq = StringTools.SanitizeDeviceString(text2);
		pJSIRFDDUhFFFYBtofQTCqLsbVjPA = 0;
		asAIfURkKvZuIVDzmUQbzFQWrLjO = 0;
		ZdzAiHDPeZVQCTMuAkQowrcSDQvQA = false;
		LeByTnpLXWuozYjFRRhlNvrzeseR = StringTools.SanitizeDeviceString(text);
		PrNzHBLlyjGjWiAiQjOKxasiylKNA = P_0;
		SQLLdjgoUifADgbWVoEgGHeMCdVfb = P_1;
		SaAjFlfnyrUMaMKkIGrSYnuQXWDI = P_2;
		qekFYBGyjAPKMmGPZDeXOQHnyDwA = P_3;
	}

	public bool NEohrMEIpFqFNIbxBYfQpmDvpXWTb(bool P_0, ctOFTJFVBKiuzGJBAAphUVuqjMxQ P_1, bool P_2, ctOFTJFVBKiuzGJBAAphUVuqjMxQ P_3, hKqNTnjGuYYhXibhfhIzNpZPKuhD P_4)
	{
		using (pVeYldnHjDCiTtkbcuMLOkLLUgxx.Lock())
		{
			using (USRgnwgxtBXHUBoNCYwDcafJHxAsA.Lock())
			{
				if (!P_0 && !P_2)
				{
					LvRlIxhKrJdRFAKZOMGYPEYUysEL();
					return false;
				}
				if (GaJUdgoEcMcedKzAylDUNQBvAMad != IRUTLHaKkXikYewvXkRTDnWUFQXpA.Closed)
				{
					if ((GaJUdgoEcMcedKzAylDUNQBvAMad & IRUTLHaKkXikYewvXkRTDnWUFQXpA.Read) != 0 == P_0 && (GaJUdgoEcMcedKzAylDUNQBvAMad & IRUTLHaKkXikYewvXkRTDnWUFQXpA.Write) != 0 == P_2 && fDrjawoBrsqdtDBbxUiPMGOhdhfv == P_1 && CIqrWPNQdKQiQlosZohKNmVIehik == P_3 && sfBZSwBBYBcEgMSwAHaapleDxmRG == P_4)
					{
						return true;
					}
					LvRlIxhKrJdRFAKZOMGYPEYUysEL();
				}
				fDrjawoBrsqdtDBbxUiPMGOhdhfv = P_1;
				CIqrWPNQdKQiQlosZohKNmVIehik = P_3;
				sfBZSwBBYBcEgMSwAHaapleDxmRG = P_4;
				if (P_0)
				{
					try
					{
						aYgIULzxVqvrjPizFiDgtSXKNWjB = gWjGJUhMvvfdSztdGkHOvFhFxUtv(tzQWAcMmnUlXPWzFcgtVztjAIkbi, P_1, 2147483648u, P_4);
						if (aYgIULzxVqvrjPizFiDgtSXKNWjB.ToInt32() == -1)
						{
							aYgIULzxVqvrjPizFiDgtSXKNWjB = IntPtr.Zero;
							throw new Exception("Invalid File Handle");
						}
						GaJUdgoEcMcedKzAylDUNQBvAMad |= IRUTLHaKkXikYewvXkRTDnWUFQXpA.Read;
					}
					catch (Exception innerException)
					{
						GaJUdgoEcMcedKzAylDUNQBvAMad &= (IRUTLHaKkXikYewvXkRTDnWUFQXpA)(-2);
						LvRlIxhKrJdRFAKZOMGYPEYUysEL();
						throw new Exception("Error opening HID device for reading.", innerException);
					}
				}
				if (P_2)
				{
					try
					{
						PHbSpyWRDwVpTwBDFldLQnmQItiS = gWjGJUhMvvfdSztdGkHOvFhFxUtv(tzQWAcMmnUlXPWzFcgtVztjAIkbi, P_3, 1073741824u, P_4);
						if (PHbSpyWRDwVpTwBDFldLQnmQItiS.ToInt32() == -1)
						{
							PHbSpyWRDwVpTwBDFldLQnmQItiS = IntPtr.Zero;
							throw new Exception("Invalid File Handle");
						}
						GaJUdgoEcMcedKzAylDUNQBvAMad |= IRUTLHaKkXikYewvXkRTDnWUFQXpA.Write;
					}
					catch (Exception innerException2)
					{
						GaJUdgoEcMcedKzAylDUNQBvAMad &= (IRUTLHaKkXikYewvXkRTDnWUFQXpA)(-3);
						LvRlIxhKrJdRFAKZOMGYPEYUysEL();
						throw new Exception("Error opening HID device for writing.", innerException2);
					}
				}
				return true;
			}
		}
	}

	bool UjfFJagRWmzCLelDMFkwHkECaNKIB.mrqDsDKhYwCSXKvmOyKZcHxJmJslA(bool P_0, ctOFTJFVBKiuzGJBAAphUVuqjMxQ P_1, bool P_2, ctOFTJFVBKiuzGJBAAphUVuqjMxQ P_3, hKqNTnjGuYYhXibhfhIzNpZPKuhD P_4)
	{
		//ILSpy generated this explicit interface implementation from .override directive in NEohrMEIpFqFNIbxBYfQpmDvpXWTb
		return this.NEohrMEIpFqFNIbxBYfQpmDvpXWTb(P_0, P_1, P_2, P_3, P_4);
	}

	public void poeaOpaXspkJIohHiQXecHxwZrrsA()
	{
		using (pVeYldnHjDCiTtkbcuMLOkLLUgxx.Lock())
		{
			using (USRgnwgxtBXHUBoNCYwDcafJHxAsA.Lock())
			{
				LvRlIxhKrJdRFAKZOMGYPEYUysEL();
			}
		}
	}

	void UjfFJagRWmzCLelDMFkwHkECaNKIB.RYzgVNiIOSunKpvHuDSjBYXipMdB()
	{
		//ILSpy generated this explicit interface implementation from .override directive in poeaOpaXspkJIohHiQXecHxwZrrsA
		this.poeaOpaXspkJIohHiQXecHxwZrrsA();
	}

	private void LvRlIxhKrJdRFAKZOMGYPEYUysEL()
	{
		if (GaJUdgoEcMcedKzAylDUNQBvAMad != IRUTLHaKkXikYewvXkRTDnWUFQXpA.Closed)
		{
			if (aYgIULzxVqvrjPizFiDgtSXKNWjB != IntPtr.Zero)
			{
				loNBgHHnJJMkGKStYGscmBCMLcfeA(aYgIULzxVqvrjPizFiDgtSXKNWjB);
				aYgIULzxVqvrjPizFiDgtSXKNWjB = IntPtr.Zero;
			}
			if (PHbSpyWRDwVpTwBDFldLQnmQItiS != IntPtr.Zero)
			{
				loNBgHHnJJMkGKStYGscmBCMLcfeA(PHbSpyWRDwVpTwBDFldLQnmQItiS);
				PHbSpyWRDwVpTwBDFldLQnmQItiS = IntPtr.Zero;
			}
			GaJUdgoEcMcedKzAylDUNQBvAMad = IRUTLHaKkXikYewvXkRTDnWUFQXpA.Closed;
		}
	}

	public YPXdjQKCWfIAfUTGZOwYMqzQnnaBA zFatEFrdSpNURLSPnLpAmUbBzVKm()
	{
		return hgfqyTVCjBbFUCuWWknRwwalmFHhA(0);
	}

	YPXdjQKCWfIAfUTGZOwYMqzQnnaBA UjfFJagRWmzCLelDMFkwHkECaNKIB.niNVHhglxvKOtnHpPUToaDNmLjiG()
	{
		//ILSpy generated this explicit interface implementation from .override directive in zFatEFrdSpNURLSPnLpAmUbBzVKm
		return this.zFatEFrdSpNURLSPnLpAmUbBzVKm();
	}

	public YPXdjQKCWfIAfUTGZOwYMqzQnnaBA hgfqyTVCjBbFUCuWWknRwwalmFHhA(int P_0)
	{
		YPXdjQKCWfIAfUTGZOwYMqzQnnaBA yPXdjQKCWfIAfUTGZOwYMqzQnnaBA = new YPXdjQKCWfIAfUTGZOwYMqzQnnaBA(RoIJcESLnhlVvQrnuDqUkUbJOPTc(), YPXdjQKCWfIAfUTGZOwYMqzQnnaBA.IZwYQbxyZfpFLOxoUvRgjDDjOlZl.NoDataRead);
		AyGiYJXzFTxfpHBEvcJViisFciPZ(yPXdjQKCWfIAfUTGZOwYMqzQnnaBA, P_0);
		return yPXdjQKCWfIAfUTGZOwYMqzQnnaBA;
	}

	YPXdjQKCWfIAfUTGZOwYMqzQnnaBA UjfFJagRWmzCLelDMFkwHkECaNKIB.anZIRfqsgSjadhmHkQtyMsOeNMsZA(int P_0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in hgfqyTVCjBbFUCuWWknRwwalmFHhA
		return this.hgfqyTVCjBbFUCuWWknRwwalmFHhA(P_0);
	}

	public unsafe bool AyGiYJXzFTxfpHBEvcJViisFciPZ(YPXdjQKCWfIAfUTGZOwYMqzQnnaBA P_0, int P_1)
	{
		try
		{
			byte[] array = P_0.fQKPetIdKqlklGfBVdFgjyibbQsS();
			fixed (byte* ptr = array)
			{
				YPXdjQKCWfIAfUTGZOwYMqzQnnaBA.IZwYQbxyZfpFLOxoUvRgjDDjOlZl zwYQbxyZfpFLOxoUvRgjDDjOlZl;
				return wDUgCIfjlbXEKPmPfFzAryieFrPt((IntPtr)ptr, array.Length, P_1, out zwYQbxyZfpFLOxoUvRgjDDjOlZl) == PcsonntHfWInNqaYZMPANOLqQWcC.Success;
			}
		}
		catch (Exception)
		{
			P_0.BiDiNWXHNzquNqLJheYhTJyFIScI(P_0.fQKPetIdKqlklGfBVdFgjyibbQsS(), YPXdjQKCWfIAfUTGZOwYMqzQnnaBA.IZwYQbxyZfpFLOxoUvRgjDDjOlZl.ReadError);
			return false;
		}
	}

	bool UjfFJagRWmzCLelDMFkwHkECaNKIB.dFdFEufYqhIEpDkvsjNBTrUwfveyA(YPXdjQKCWfIAfUTGZOwYMqzQnnaBA P_0, int P_1)
	{
		//ILSpy generated this explicit interface implementation from .override directive in AyGiYJXzFTxfpHBEvcJViisFciPZ
		return this.AyGiYJXzFTxfpHBEvcJViisFciPZ(P_0, P_1);
	}

	public bool OUsccHovzTBwHwogFGHGicrNdCBgb(out byte[] P_0, int P_1, byte P_2 = 0)
	{
		if (P_1 <= 0)
		{
			P_0 = EmptyObjects<byte>.array;
			return false;
		}
		using (pVeYldnHjDCiTtkbcuMLOkLLUgxx.Lock())
		{
			if ((GaJUdgoEcMcedKzAylDUNQBvAMad & IRUTLHaKkXikYewvXkRTDnWUFQXpA.Read) == 0)
			{
				P_0 = EmptyObjects<byte>.array;
				return false;
			}
			P_0 = new byte[P_1];
			byte[] array = JmbAmNISbJcALNJbZnqwrliUPJuRA(P_1);
			array[0] = P_2;
			bool flag = false;
			try
			{
				flag = ShLxNDAuNJnTDKEaZHAvIhFLYQDS.rWfZyHrhKyrTTFyOKMNERhHBSX(aYgIULzxVqvrjPizFiDgtSXKNWjB, array, array.Length);
				if (flag)
				{
					Array.Copy(array, 0, P_0, 0, Math.Min(P_0.Length, P_1));
				}
			}
			catch (Exception innerException)
			{
				throw new Exception($"Error accessing HID device '{tzQWAcMmnUlXPWzFcgtVztjAIkbi}'.", innerException);
			}
			return flag;
		}
	}

	bool UjfFJagRWmzCLelDMFkwHkECaNKIB.JlfENTHdWpgJHcdOKquJNZyLtdYib(out byte[] P_0, int P_1, byte P_2 = 0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in OUsccHovzTBwHwogFGHGicrNdCBgb
		return this.OUsccHovzTBwHwogFGHGicrNdCBgb(out P_0, P_1, P_2);
	}

	public string wNUMYZCUftpTgYiUddOmjoPeLbmzA()
	{
		try
		{
			if (!SGeAwLQBnWHMmykmXQTHeAAQCLim(out var bytes))
			{
				return string.Empty;
			}
			return StringTools.SanitizeDeviceString(StringTools.GetNullTerminatedUnicodeString(bytes));
		}
		catch (Exception)
		{
			return string.Empty;
		}
	}

	string UjfFJagRWmzCLelDMFkwHkECaNKIB.eYGtcuKowZBlbRykXEtCUlBeUkpR()
	{
		//ILSpy generated this explicit interface implementation from .override directive in wNUMYZCUftpTgYiUddOmjoPeLbmzA
		return this.wNUMYZCUftpTgYiUddOmjoPeLbmzA();
	}

	public unsafe bool SGeAwLQBnWHMmykmXQTHeAAQCLim(out byte[] P_0)
	{
		using (pVeYldnHjDCiTtkbcuMLOkLLUgxx.Lock())
		{
			if ((GaJUdgoEcMcedKzAylDUNQBvAMad & IRUTLHaKkXikYewvXkRTDnWUFQXpA.Read) == 0)
			{
				P_0 = EmptyObjects<byte>.array;
				return false;
			}
			P_0 = new byte[255];
			bool result = false;
			try
			{
				fixed (byte* ptr = P_0)
				{
					void* ptr2 = ptr;
					result = ShLxNDAuNJnTDKEaZHAvIhFLYQDS.lCQgolivLcnBoyilWobSkXiDHECD(aYgIULzxVqvrjPizFiDgtSXKNWjB, (IntPtr)ptr2, P_0.Length);
				}
			}
			catch (Exception innerException)
			{
				throw new Exception($"Error accessing HID device '{tzQWAcMmnUlXPWzFcgtVztjAIkbi}'.", innerException);
			}
			return result;
		}
	}

	bool UjfFJagRWmzCLelDMFkwHkECaNKIB.KiCBQCtMZXFiUZxIEgpWoJVTyCVy(out byte[] P_0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in SGeAwLQBnWHMmykmXQTHeAAQCLim
		return this.SGeAwLQBnWHMmykmXQTHeAAQCLim(out P_0);
	}

	public string kQtEeeBqLqihKLWhYGWfgiZTAlPH()
	{
		vQreHrqpjFPxmcCMYiAxJhkaIODQA(out var bytes);
		return StringTools.SanitizeDeviceString(StringTools.GetNullTerminatedUnicodeString(bytes));
	}

	string UjfFJagRWmzCLelDMFkwHkECaNKIB.EypFfBYROkAfueCLSTtThKxDpeyqA()
	{
		//ILSpy generated this explicit interface implementation from .override directive in kQtEeeBqLqihKLWhYGWfgiZTAlPH
		return this.kQtEeeBqLqihKLWhYGWfgiZTAlPH();
	}

	public bool vQreHrqpjFPxmcCMYiAxJhkaIODQA(out byte[] P_0)
	{
		using (pVeYldnHjDCiTtkbcuMLOkLLUgxx.Lock())
		{
			if ((GaJUdgoEcMcedKzAylDUNQBvAMad & IRUTLHaKkXikYewvXkRTDnWUFQXpA.Read) == 0)
			{
				P_0 = EmptyObjects<byte>.array;
				return false;
			}
			P_0 = new byte[255];
			bool flag = false;
			try
			{
				GCHandle gCHandle = GCHandle.Alloc(P_0, GCHandleType.Pinned);
				flag = ShLxNDAuNJnTDKEaZHAvIhFLYQDS.qidbnTpfLKGDxEYJwRrdxzOzqDTt(aYgIULzxVqvrjPizFiDgtSXKNWjB, gCHandle.AddrOfPinnedObject(), P_0.Length);
				GC.KeepAlive(gCHandle);
				gCHandle.Free();
			}
			catch (Exception innerException)
			{
				throw new Exception($"Error accessing HID device '{tzQWAcMmnUlXPWzFcgtVztjAIkbi}'.", innerException);
			}
			return flag;
		}
	}

	bool UjfFJagRWmzCLelDMFkwHkECaNKIB.mBflmoalIucFQgwSvWvWeEVjoTyz(out byte[] P_0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in vQreHrqpjFPxmcCMYiAxJhkaIODQA
		return this.vQreHrqpjFPxmcCMYiAxJhkaIODQA(out P_0);
	}

	public string EIUzYyOaPnjkMyBppNdgomOeLFLi()
	{
		ZlxISaAAktENTxScFTVLNMMSJMUD(out var bytes);
		return StringTools.SanitizeDeviceString(StringTools.GetNullTerminatedUnicodeString(bytes));
	}

	string UjfFJagRWmzCLelDMFkwHkECaNKIB.JHOXWqSOwoOwxbRAokZfigeNNNot()
	{
		//ILSpy generated this explicit interface implementation from .override directive in EIUzYyOaPnjkMyBppNdgomOeLFLi
		return this.EIUzYyOaPnjkMyBppNdgomOeLFLi();
	}

	public bool ZlxISaAAktENTxScFTVLNMMSJMUD(out byte[] P_0)
	{
		using (pVeYldnHjDCiTtkbcuMLOkLLUgxx.Lock())
		{
			if ((GaJUdgoEcMcedKzAylDUNQBvAMad & IRUTLHaKkXikYewvXkRTDnWUFQXpA.Read) == 0)
			{
				P_0 = EmptyObjects<byte>.array;
				return false;
			}
			bool flag = false;
			try
			{
				flag = HdzMEGwsQYTvOOnTFRbawzmreUkB(aYgIULzxVqvrjPizFiDgtSXKNWjB, out P_0);
			}
			catch (Exception innerException)
			{
				throw new Exception($"Error accessing HID device '{tzQWAcMmnUlXPWzFcgtVztjAIkbi}'.", innerException);
			}
			return flag;
		}
	}

	bool UjfFJagRWmzCLelDMFkwHkECaNKIB.MQuxKRLvAwIQgUGSoPaUkbjigZsK(out byte[] P_0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in ZlxISaAAktENTxScFTVLNMMSJMUD
		return this.ZlxISaAAktENTxScFTVLNMMSJMUD(out P_0);
	}

	public string FFxLuCuDPqaGAXizKEfdsFSyPVAE()
	{
		zcaHGaoAUqGloCBhqELnRAjIxcuI(out var bytes);
		return StringTools.SanitizeDeviceString(StringTools.GetNullTerminatedUnicodeString(bytes));
	}

	string UjfFJagRWmzCLelDMFkwHkECaNKIB.cAUuRpNmgIHupGNgecqrCLpMFOtS()
	{
		//ILSpy generated this explicit interface implementation from .override directive in FFxLuCuDPqaGAXizKEfdsFSyPVAE
		return this.FFxLuCuDPqaGAXizKEfdsFSyPVAE();
	}

	public bool zcaHGaoAUqGloCBhqELnRAjIxcuI(out byte[] P_0)
	{
		using (pVeYldnHjDCiTtkbcuMLOkLLUgxx.Lock())
		{
			if ((GaJUdgoEcMcedKzAylDUNQBvAMad & IRUTLHaKkXikYewvXkRTDnWUFQXpA.Read) == 0)
			{
				P_0 = EmptyObjects<byte>.array;
				return false;
			}
			P_0 = new byte[255];
			bool flag = false;
			try
			{
				GCHandle gCHandle = GCHandle.Alloc(P_0, GCHandleType.Pinned);
				flag = ShLxNDAuNJnTDKEaZHAvIhFLYQDS.CHdTMnsdFYmfbaWFnvyGzDGmhqrw(aYgIULzxVqvrjPizFiDgtSXKNWjB, gCHandle.AddrOfPinnedObject(), (uint)P_0.Length);
				GC.KeepAlive(gCHandle);
				gCHandle.Free();
			}
			catch (Exception innerException)
			{
				throw new Exception($"Error accessing HID device '{tzQWAcMmnUlXPWzFcgtVztjAIkbi}'.", innerException);
			}
			return flag;
		}
	}

	bool UjfFJagRWmzCLelDMFkwHkECaNKIB.WwxwpUHecFAmUDQwqAJYANWiwZpwb(out byte[] P_0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in zcaHGaoAUqGloCBhqELnRAjIxcuI
		return this.zcaHGaoAUqGloCBhqELnRAjIxcuI(out P_0);
	}

	public bool ZKrKnESFtbPVsGHZvhIrUkPWUZlj(byte[] P_0)
	{
		return NijAsZRTxBkhWRvUpcOTGauHgWRdA(P_0, 0);
	}

	bool UjfFJagRWmzCLelDMFkwHkECaNKIB.MpKYoaPKljbKvECjkHgrArWNPNqhA(byte[] P_0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in ZKrKnESFtbPVsGHZvhIrUkPWUZlj
		return this.ZKrKnESFtbPVsGHZvhIrUkPWUZlj(P_0);
	}

	public unsafe bool NijAsZRTxBkhWRvUpcOTGauHgWRdA(byte[] P_0, int P_1)
	{
		fixed (byte* ptr = P_0)
		{
			return JlpvjYiNMNbfwHdbWsLnVgATILvV((IntPtr)ptr, P_0.Length, P_1, KPLqKGrnXdaslTRsOdlOdboDEXAU.None, false);
		}
	}

	bool UjfFJagRWmzCLelDMFkwHkECaNKIB.yApJxiuRkcNFYVaTCatmipahyATT(byte[] P_0, int P_1)
	{
		//ILSpy generated this explicit interface implementation from .override directive in NijAsZRTxBkhWRvUpcOTGauHgWRdA
		return this.NijAsZRTxBkhWRvUpcOTGauHgWRdA(P_0, P_1);
	}

	public bool rxqIQNNUATuVPJLJmCFSCgzgjJZV(IntPtr P_0, int P_1, int P_2, KPLqKGrnXdaslTRsOdlOdboDEXAU P_3)
	{
		return JlpvjYiNMNbfwHdbWsLnVgATILvV(P_0, P_1, P_2, P_3, true);
	}

	public bool vCkkTTNiLFkuIsmfqlwUPeLKIplH(YgqnhctsoyAiZixKeAsniiZNPqQeA P_0, int P_1)
	{
		return rxqIQNNUATuVPJLJmCFSCgzgjJZV(P_0.YzEHBmNoiKBdThInLQRVqiblMevEb, P_0.mkLceCnSfMCmtvrhnltBZXSmJecI, P_1, P_0.ZkToHalecmNLxzFDOCFImmKVivSU);
	}

	bool UjfFJagRWmzCLelDMFkwHkECaNKIB.PxnayLQCCXFpzHeiKeoCWZoEwwAf(YgqnhctsoyAiZixKeAsniiZNPqQeA P_0, int P_1)
	{
		//ILSpy generated this explicit interface implementation from .override directive in vCkkTTNiLFkuIsmfqlwUPeLKIplH
		return this.vCkkTTNiLFkuIsmfqlwUPeLKIplH(P_0, P_1);
	}

	public vkHQVZflUwCnErmdIHutDievbIce tzglOwYvQghSdCiEXJPleGdOzEQC()
	{
		return new vkHQVZflUwCnErmdIHutDievbIce(DCDITUFElKaxOgCQcaRhktRwtpcSB().ILVkOedxQVhvUSaAqeflvdAkHnxf());
	}

	vkHQVZflUwCnErmdIHutDievbIce UjfFJagRWmzCLelDMFkwHkECaNKIB.sWNmhKbsHVdpgDVHcpzOxsBHSaNM()
	{
		//ILSpy generated this explicit interface implementation from .override directive in tzglOwYvQghSdCiEXJPleGdOzEQC
		return this.tzglOwYvQghSdCiEXJPleGdOzEQC();
	}

	public bool sTuwXCEOUNcpEInpiKnfHcoRnKrj(byte[] P_0, int P_1)
	{
		using (USRgnwgxtBXHUBoNCYwDcafJHxAsA.Lock())
		{
			if ((GaJUdgoEcMcedKzAylDUNQBvAMad & IRUTLHaKkXikYewvXkRTDnWUFQXpA.Write) == 0)
			{
				return false;
			}
			if (SQLLdjgoUifADgbWVoEgGHeMCdVfb.JzSjGOjNDIPElpCNVVpczkyegBzb() <= 0)
			{
				return false;
			}
			byte[] array = JmbAmNISbJcALNJbZnqwrliUPJuRA(P_1);
			Array.Copy(P_0, 0, array, 0, Math.Min(P_0.Length, P_1));
			try
			{
				return ShLxNDAuNJnTDKEaZHAvIhFLYQDS.lFLSmPhMceIzHRUVdFmTPlhsboRq(PHbSpyWRDwVpTwBDFldLQnmQItiS, array, P_1);
			}
			catch (Exception innerException)
			{
				throw new Exception($"Error accessing HID device '{tzQWAcMmnUlXPWzFcgtVztjAIkbi}'.", innerException);
			}
		}
	}

	bool UjfFJagRWmzCLelDMFkwHkECaNKIB.vYZZWTkPSmyOWanxbUxHoHtMDIZK(byte[] P_0, int P_1)
	{
		//ILSpy generated this explicit interface implementation from .override directive in sTuwXCEOUNcpEInpiKnfHcoRnKrj
		return this.sTuwXCEOUNcpEInpiKnfHcoRnKrj(P_0, P_1);
	}

	private byte[] RoIJcESLnhlVvQrnuDqUkUbJOPTc()
	{
		return hVmWkLoRkOmMnVHEUVVAwKrqDdBI(DCDITUFElKaxOgCQcaRhktRwtpcSB().sdhsGNgNQUrALibvBDofkoQXaSOW() - 1);
	}

	private byte[] eyBwgvkqALROtScNmmxExTwXHKsS()
	{
		return hVmWkLoRkOmMnVHEUVVAwKrqDdBI(DCDITUFElKaxOgCQcaRhktRwtpcSB().ILVkOedxQVhvUSaAqeflvdAkHnxf() - 1);
	}

	private static byte[] JmbAmNISbJcALNJbZnqwrliUPJuRA(int P_0)
	{
		return hVmWkLoRkOmMnVHEUVVAwKrqDdBI(P_0 - 1);
	}

	private unsafe YPXdjQKCWfIAfUTGZOwYMqzQnnaBA LQyhoxEwmktplLuYLccJVjexcIFCA(int P_0)
	{
		byte[] array = RoIJcESLnhlVvQrnuDqUkUbJOPTc();
		YPXdjQKCWfIAfUTGZOwYMqzQnnaBA.IZwYQbxyZfpFLOxoUvRgjDDjOlZl zwYQbxyZfpFLOxoUvRgjDDjOlZl;
		fixed (byte* ptr = array)
		{
			wDUgCIfjlbXEKPmPfFzAryieFrPt((IntPtr)ptr, array.Length, P_0, out zwYQbxyZfpFLOxoUvRgjDDjOlZl);
		}
		return new YPXdjQKCWfIAfUTGZOwYMqzQnnaBA(array, zwYQbxyZfpFLOxoUvRgjDDjOlZl);
	}

	private PcsonntHfWInNqaYZMPANOLqQWcC wDUgCIfjlbXEKPmPfFzAryieFrPt(IntPtr P_0, int P_1, int P_2, out YPXdjQKCWfIAfUTGZOwYMqzQnnaBA.IZwYQbxyZfpFLOxoUvRgjDDjOlZl P_3)
	{
		using (pVeYldnHjDCiTtkbcuMLOkLLUgxx.Lock())
		{
			if ((GaJUdgoEcMcedKzAylDUNQBvAMad & IRUTLHaKkXikYewvXkRTDnWUFQXpA.Read) == 0)
			{
				P_3 = YPXdjQKCWfIAfUTGZOwYMqzQnnaBA.IZwYQbxyZfpFLOxoUvRgjDDjOlZl.NotConnected;
				return PcsonntHfWInNqaYZMPANOLqQWcC.DeviceNotOpen;
			}
			P_3 = YPXdjQKCWfIAfUTGZOwYMqzQnnaBA.IZwYQbxyZfpFLOxoUvRgjDDjOlZl.NoDataRead;
			if (P_1 < DCDITUFElKaxOgCQcaRhktRwtpcSB().sdhsGNgNQUrALibvBDofkoQXaSOW())
			{
				return PcsonntHfWInNqaYZMPANOLqQWcC.BufferTooSmall;
			}
			if (SQLLdjgoUifADgbWVoEgGHeMCdVfb.sdhsGNgNQUrALibvBDofkoQXaSOW() > 0)
			{
				uint num = 0u;
				if (fDrjawoBrsqdtDBbxUiPMGOhdhfv == ctOFTJFVBKiuzGJBAAphUVuqjMxQ.Overlapped)
				{
					int num2 = ((P_2 <= 0) ? 65535 : P_2);
					ShLxNDAuNJnTDKEaZHAvIhFLYQDS.xeNSalaogCBYWePkykAFqDDAiyIg xeNSalaogCBYWePkykAFqDDAiyIg = new ShLxNDAuNJnTDKEaZHAvIhFLYQDS.xeNSalaogCBYWePkykAFqDDAiyIg
					{
						SnogffYFCMfCCkKszPfCkWVLmPSPA = IntPtr.Zero,
						BlNmjFmZbFpDanIpOXBqmTuaFfjr = true,
						HgxwubtcbbFQmLNFzBexCAEJMYqVA = ShLxNDAuNJnTDKEaZHAvIhFLYQDS.xeNSalaogCBYWePkykAFqDDAiyIg.pzwoHHQfPUXRMUqpObunRsNSGZfe
					};
					wwgPdgFdpnDQIebrZMoiJiETvrTp.qgXcjcONdntCoXdHpYFklYrLmQsm(xeNSalaogCBYWePkykAFqDDAiyIg);
					IntPtr intPtr = ShLxNDAuNJnTDKEaZHAvIhFLYQDS.QfVIzwMaXEoeeBFsJDiWzgEyOdMm(zPYtRvRddGYtyjvCeSHFiOzocDBi.LBmhHOATglrnrMJyhDckXAWXTXYLA(wwgPdgFdpnDQIebrZMoiJiETvrTp.mwSEgQGUOFjwVgCqBoHNLVnkJQTEA()), Convert.ToInt32(value: false), Convert.ToInt32(value: true), IntPtr.Zero);
					if (intPtr == IntPtr.Zero)
					{
						return PcsonntHfWInNqaYZMPANOLqQWcC.ReadError;
					}
					ShLxNDAuNJnTDKEaZHAvIhFLYQDS.SApgQYHIDWDqrfeOlHCjwjtAOodt sApgQYHIDWDqrfeOlHCjwjtAOodt = new ShLxNDAuNJnTDKEaZHAvIhFLYQDS.SApgQYHIDWDqrfeOlHCjwjtAOodt
					{
						ByyKSVVZzeJHUnlkMTpDdEdocynF = 0,
						KjKhGKusMPbdeOZZhsCLLTNSlobS = 0,
						JUuPIAsTcHPMbJaypPLicSsTtoky = intPtr
					};
					RgDlNfgSpfenddKufXDQKMEKepxF.qgXcjcONdntCoXdHpYFklYrLmQsm(sApgQYHIDWDqrfeOlHCjwjtAOodt);
					try
					{
						if (ShLxNDAuNJnTDKEaZHAvIhFLYQDS.nBVeHWVqSeDEdcYEmkJbrEMTOTOeA(aYgIULzxVqvrjPizFiDgtSXKNWjB, P_0, (uint)P_1, out num, zPYtRvRddGYtyjvCeSHFiOzocDBi.LBmhHOATglrnrMJyhDckXAWXTXYLA(RgDlNfgSpfenddKufXDQKMEKepxF.mwSEgQGUOFjwVgCqBoHNLVnkJQTEA())))
						{
							P_3 = YPXdjQKCWfIAfUTGZOwYMqzQnnaBA.IZwYQbxyZfpFLOxoUvRgjDDjOlZl.Success;
						}
						else if ((long)Marshal.GetLastWin32Error() == 997)
						{
							switch (ShLxNDAuNJnTDKEaZHAvIhFLYQDS.pxEmavXSRFasOelzANchgFfPEPMEA(RgDlNfgSpfenddKufXDQKMEKepxF.RabisIhhjAWXkrDdLSlZljsLmVovA().JUuPIAsTcHPMbJaypPLicSsTtoky, num2))
							{
							case 0u:
							case 192u:
								if (iZtZloELsoaMBDRDTiszzpwtPjDd.VWrkJaumJqfNFSVsNAsKbIteKXow(aYgIULzxVqvrjPizFiDgtSXKNWjB, zPYtRvRddGYtyjvCeSHFiOzocDBi.LBmhHOATglrnrMJyhDckXAWXTXYLA(RgDlNfgSpfenddKufXDQKMEKepxF.mwSEgQGUOFjwVgCqBoHNLVnkJQTEA()), out num, false))
								{
									if (num != 0)
									{
										P_3 = YPXdjQKCWfIAfUTGZOwYMqzQnnaBA.IZwYQbxyZfpFLOxoUvRgjDDjOlZl.Success;
									}
									else
									{
										P_3 = YPXdjQKCWfIAfUTGZOwYMqzQnnaBA.IZwYQbxyZfpFLOxoUvRgjDDjOlZl.NoDataRead;
									}
								}
								else
								{
									P_3 = YPXdjQKCWfIAfUTGZOwYMqzQnnaBA.IZwYQbxyZfpFLOxoUvRgjDDjOlZl.ReadError;
								}
								break;
							case 258u:
								P_3 = YPXdjQKCWfIAfUTGZOwYMqzQnnaBA.IZwYQbxyZfpFLOxoUvRgjDDjOlZl.WaitTimedOut;
								break;
							case uint.MaxValue:
								P_3 = YPXdjQKCWfIAfUTGZOwYMqzQnnaBA.IZwYQbxyZfpFLOxoUvRgjDDjOlZl.WaitFail;
								break;
							case 128u:
								P_3 = YPXdjQKCWfIAfUTGZOwYMqzQnnaBA.IZwYQbxyZfpFLOxoUvRgjDDjOlZl.WaitAbandoned;
								break;
							default:
								P_3 = YPXdjQKCWfIAfUTGZOwYMqzQnnaBA.IZwYQbxyZfpFLOxoUvRgjDDjOlZl.NoDataRead;
								break;
							}
						}
						else
						{
							P_3 = YPXdjQKCWfIAfUTGZOwYMqzQnnaBA.IZwYQbxyZfpFLOxoUvRgjDDjOlZl.ReadError;
						}
					}
					catch
					{
						P_3 = YPXdjQKCWfIAfUTGZOwYMqzQnnaBA.IZwYQbxyZfpFLOxoUvRgjDDjOlZl.ReadError;
					}
					finally
					{
						ShLxNDAuNJnTDKEaZHAvIhFLYQDS.KXCgoeJNtsERxFNRwLdtANGBgMGhB(aYgIULzxVqvrjPizFiDgtSXKNWjB);
						IntPtr jUuPIAsTcHPMbJaypPLicSsTtoky = RgDlNfgSpfenddKufXDQKMEKepxF.RabisIhhjAWXkrDdLSlZljsLmVovA().JUuPIAsTcHPMbJaypPLicSsTtoky;
						if (jUuPIAsTcHPMbJaypPLicSsTtoky != IntPtr.Zero)
						{
							SFDBjgCRXVatSzdsxbuenixppbbM(jUuPIAsTcHPMbJaypPLicSsTtoky);
						}
					}
				}
				else
				{
					try
					{
						if (ShLxNDAuNJnTDKEaZHAvIhFLYQDS.nBVeHWVqSeDEdcYEmkJbrEMTOTOeA(aYgIULzxVqvrjPizFiDgtSXKNWjB, P_0, (uint)P_1, out num, IntPtr.Zero))
						{
							P_3 = YPXdjQKCWfIAfUTGZOwYMqzQnnaBA.IZwYQbxyZfpFLOxoUvRgjDDjOlZl.Success;
						}
						else
						{
							P_3 = YPXdjQKCWfIAfUTGZOwYMqzQnnaBA.IZwYQbxyZfpFLOxoUvRgjDDjOlZl.Success;
							P_3 = YPXdjQKCWfIAfUTGZOwYMqzQnnaBA.IZwYQbxyZfpFLOxoUvRgjDDjOlZl.ReadError;
						}
					}
					catch
					{
						P_3 = YPXdjQKCWfIAfUTGZOwYMqzQnnaBA.IZwYQbxyZfpFLOxoUvRgjDDjOlZl.ReadError;
					}
				}
			}
			return (P_3 != YPXdjQKCWfIAfUTGZOwYMqzQnnaBA.IZwYQbxyZfpFLOxoUvRgjDDjOlZl.Success) ? PcsonntHfWInNqaYZMPANOLqQWcC.ReadError : PcsonntHfWInNqaYZMPANOLqQWcC.Success;
		}
	}

	private bool JlpvjYiNMNbfwHdbWsLnVgATILvV(IntPtr P_0, int P_1, int P_2, KPLqKGrnXdaslTRsOdlOdboDEXAU P_3, bool P_4)
	{
		using (USRgnwgxtBXHUBoNCYwDcafJHxAsA.Lock())
		{
			if ((GaJUdgoEcMcedKzAylDUNQBvAMad & IRUTLHaKkXikYewvXkRTDnWUFQXpA.Write) == 0)
			{
				return false;
			}
			if (P_0 == IntPtr.Zero || P_1 <= 0)
			{
				return false;
			}
			if (!P_4)
			{
				if (SQLLdjgoUifADgbWVoEgGHeMCdVfb.ILVkOedxQVhvUSaAqeflvdAkHnxf() <= 0)
				{
					return false;
				}
				P_1 = Math.Min(P_1, SQLLdjgoUifADgbWVoEgGHeMCdVfb.ILVkOedxQVhvUSaAqeflvdAkHnxf());
			}
			uint num = 0u;
			if (CIqrWPNQdKQiQlosZohKNmVIehik == ctOFTJFVBKiuzGJBAAphUVuqjMxQ.Overlapped)
			{
				try
				{
					if ((P_3 & KPLqKGrnXdaslTRsOdlOdboDEXAU.WriteDirect) != KPLqKGrnXdaslTRsOdlOdboDEXAU.None)
					{
						return ShLxNDAuNJnTDKEaZHAvIhFLYQDS.hhmBmkqfipkeJtBMwluLcjijFOPAA(PHbSpyWRDwVpTwBDFldLQnmQItiS, P_0, P_1);
					}
				}
				catch (Exception)
				{
					return false;
				}
				int num2 = ((P_2 <= 0) ? 65535 : P_2);
				ShLxNDAuNJnTDKEaZHAvIhFLYQDS.xeNSalaogCBYWePkykAFqDDAiyIg xeNSalaogCBYWePkykAFqDDAiyIg = new ShLxNDAuNJnTDKEaZHAvIhFLYQDS.xeNSalaogCBYWePkykAFqDDAiyIg
				{
					SnogffYFCMfCCkKszPfCkWVLmPSPA = IntPtr.Zero,
					BlNmjFmZbFpDanIpOXBqmTuaFfjr = true,
					HgxwubtcbbFQmLNFzBexCAEJMYqVA = ShLxNDAuNJnTDKEaZHAvIhFLYQDS.xeNSalaogCBYWePkykAFqDDAiyIg.pzwoHHQfPUXRMUqpObunRsNSGZfe
				};
				wwgPdgFdpnDQIebrZMoiJiETvrTp.qgXcjcONdntCoXdHpYFklYrLmQsm(xeNSalaogCBYWePkykAFqDDAiyIg);
				IntPtr intPtr = ShLxNDAuNJnTDKEaZHAvIhFLYQDS.QfVIzwMaXEoeeBFsJDiWzgEyOdMm(zPYtRvRddGYtyjvCeSHFiOzocDBi.LBmhHOATglrnrMJyhDckXAWXTXYLA(wwgPdgFdpnDQIebrZMoiJiETvrTp.mwSEgQGUOFjwVgCqBoHNLVnkJQTEA()), Convert.ToInt32(value: false), Convert.ToInt32(value: true), IntPtr.Zero);
				if (intPtr == IntPtr.Zero)
				{
					return false;
				}
				ShLxNDAuNJnTDKEaZHAvIhFLYQDS.SApgQYHIDWDqrfeOlHCjwjtAOodt sApgQYHIDWDqrfeOlHCjwjtAOodt = new ShLxNDAuNJnTDKEaZHAvIhFLYQDS.SApgQYHIDWDqrfeOlHCjwjtAOodt
				{
					ByyKSVVZzeJHUnlkMTpDdEdocynF = 0,
					KjKhGKusMPbdeOZZhsCLLTNSlobS = 0,
					JUuPIAsTcHPMbJaypPLicSsTtoky = intPtr
				};
				RgDlNfgSpfenddKufXDQKMEKepxF.qgXcjcONdntCoXdHpYFklYrLmQsm(sApgQYHIDWDqrfeOlHCjwjtAOodt);
				try
				{
					if (ShLxNDAuNJnTDKEaZHAvIhFLYQDS.OvIJpHrLTTYdyBefylDRkTkXcSEE(PHbSpyWRDwVpTwBDFldLQnmQItiS, P_0, (uint)P_1, IntPtr.Zero, zPYtRvRddGYtyjvCeSHFiOzocDBi.LBmhHOATglrnrMJyhDckXAWXTXYLA(RgDlNfgSpfenddKufXDQKMEKepxF.mwSEgQGUOFjwVgCqBoHNLVnkJQTEA())))
					{
						return true;
					}
					if ((long)Marshal.GetLastWin32Error() == 997)
					{
						switch (ShLxNDAuNJnTDKEaZHAvIhFLYQDS.pxEmavXSRFasOelzANchgFfPEPMEA(RgDlNfgSpfenddKufXDQKMEKepxF.RabisIhhjAWXkrDdLSlZljsLmVovA().JUuPIAsTcHPMbJaypPLicSsTtoky, num2))
						{
						case 0u:
						case 192u:
							if (iZtZloELsoaMBDRDTiszzpwtPjDd.VWrkJaumJqfNFSVsNAsKbIteKXow(PHbSpyWRDwVpTwBDFldLQnmQItiS, zPYtRvRddGYtyjvCeSHFiOzocDBi.LBmhHOATglrnrMJyhDckXAWXTXYLA(RgDlNfgSpfenddKufXDQKMEKepxF.mwSEgQGUOFjwVgCqBoHNLVnkJQTEA()), out num, false))
							{
								return true;
							}
							return false;
						case 258u:
							return false;
						case uint.MaxValue:
							return false;
						case 128u:
							return false;
						default:
							return false;
						}
					}
					return false;
				}
				catch
				{
					return false;
				}
				finally
				{
					ShLxNDAuNJnTDKEaZHAvIhFLYQDS.KXCgoeJNtsERxFNRwLdtANGBgMGhB(PHbSpyWRDwVpTwBDFldLQnmQItiS);
					IntPtr jUuPIAsTcHPMbJaypPLicSsTtoky = RgDlNfgSpfenddKufXDQKMEKepxF.RabisIhhjAWXkrDdLSlZljsLmVovA().JUuPIAsTcHPMbJaypPLicSsTtoky;
					if (jUuPIAsTcHPMbJaypPLicSsTtoky != IntPtr.Zero)
					{
						SFDBjgCRXVatSzdsxbuenixppbbM(jUuPIAsTcHPMbJaypPLicSsTtoky);
					}
				}
			}
			try
			{
				if ((P_3 & KPLqKGrnXdaslTRsOdlOdboDEXAU.WriteDirect) != KPLqKGrnXdaslTRsOdlOdboDEXAU.None)
				{
					return ShLxNDAuNJnTDKEaZHAvIhFLYQDS.hhmBmkqfipkeJtBMwluLcjijFOPAA(PHbSpyWRDwVpTwBDFldLQnmQItiS, P_0, P_1);
				}
				return ShLxNDAuNJnTDKEaZHAvIhFLYQDS.hhAKWaWpNUFarKJAVxBqHlyKcWcu(PHbSpyWRDwVpTwBDFldLQnmQItiS, P_0, (uint)P_1, out num, IntPtr.Zero);
			}
			catch (Exception)
			{
				return false;
			}
		}
	}

	private void EYBbxRICJjTqfEYBpwWPCXjOxwtB()
	{
	}

	private void PCpLRGqoijnTJhFeIJtgVGqPXvDi()
	{
		using (pVeYldnHjDCiTtkbcuMLOkLLUgxx.Lock())
		{
			using (USRgnwgxtBXHUBoNCYwDcafJHxAsA.Lock())
			{
				LvRlIxhKrJdRFAKZOMGYPEYUysEL();
				if (SSUdRJkvOCLQQlLcfJEwcJGbyZBnb != null)
				{
					SSUdRJkvOCLQQlLcfJEwcJGbyZBnb();
				}
			}
		}
	}

	public void Dispose()
	{
		NNLDTBCtsLxSdmkXGBhcZRvmSjuh(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	protected void gROemxWHLoAzbOdXRzVqzqLuiAXX()
	{
		try
		{
			NNLDTBCtsLxSdmkXGBhcZRvmSjuh(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	private void NNLDTBCtsLxSdmkXGBhcZRvmSjuh(bool P_0)
	{
		if (rqTRpwiNcnAdmCJLMAnGOjvoEljwA)
		{
			return;
		}
		using (pVeYldnHjDCiTtkbcuMLOkLLUgxx.Lock())
		{
			using (USRgnwgxtBXHUBoNCYwDcafJHxAsA.Lock())
			{
				if (yZxdcdxWCaJNIVGylivVNYepXyMj())
				{
					DvWyHPMimvZDwjgcgLoTrtOjTSjw(false);
				}
				if (GaJUdgoEcMcedKzAylDUNQBvAMad != IRUTLHaKkXikYewvXkRTDnWUFQXpA.Closed)
				{
					LvRlIxhKrJdRFAKZOMGYPEYUysEL();
				}
				ObjectInstanceTracker.Default.Unregister(uwgSBHuzNZGSdSrCXwLaTvDrkEcu);
				if (RgDlNfgSpfenddKufXDQKMEKepxF != null)
				{
					RgDlNfgSpfenddKufXDQKMEKepxF.Dispose();
				}
				if (wwgPdgFdpnDQIebrZMoiJiETvrTp != null)
				{
					wwgPdgFdpnDQIebrZMoiJiETvrTp.Dispose();
				}
			}
		}
		rqTRpwiNcnAdmCJLMAnGOjvoEljwA = true;
	}

	public static bool HdzMEGwsQYTvOOnTFRbawzmreUkB(IntPtr P_0, out byte[] P_1)
	{
		P_1 = new byte[255];
		_ = string.Empty;
		bool flag = false;
		GCHandle gCHandle = GCHandle.Alloc(P_1, GCHandleType.Pinned);
		try
		{
			flag = ShLxNDAuNJnTDKEaZHAvIhFLYQDS.yMUslXlXOiOREfvlBVrjxcJTRoYm(P_0, gCHandle.AddrOfPinnedObject(), P_1.Length);
			GC.KeepAlive(gCHandle);
			if (flag)
			{
				StringTools.SanitizeDeviceString(StringTools.GetNullTerminatedUnicodeString(P_1));
			}
		}
		catch (Exception innerException)
		{
			throw new Exception($"Error accessing HID device at handle '{P_0}'.", innerException);
		}
		finally
		{
			gCHandle.Free();
		}
		return flag;
	}

	public static string actNIZYCokKTrIMXllTyqlkjtHnR(IntPtr P_0)
	{
		HdzMEGwsQYTvOOnTFRbawzmreUkB(P_0, out var bytes);
		return StringTools.SanitizeDeviceString(StringTools.GetNullTerminatedUnicodeString(bytes));
	}

	public static bool orxbhAgQETJjaTKKBaUuemFQipPnA(IntPtr P_0, IntPtr P_1, int P_2)
	{
		if (P_2 < 255)
		{
			throw new Exception("Buffer length must be at least " + 255 + " bytes!");
		}
		try
		{
			return ShLxNDAuNJnTDKEaZHAvIhFLYQDS.yMUslXlXOiOREfvlBVrjxcJTRoYm(P_0, P_1, P_2);
		}
		catch (Exception innerException)
		{
			throw new Exception($"Error accessing HID device at handle '{P_0}'.", innerException);
		}
	}

	public static IntPtr gWjGJUhMvvfdSztdGkHOvFhFxUtv(string P_0, ctOFTJFVBKiuzGJBAAphUVuqjMxQ P_1, uint P_2, hKqNTnjGuYYhXibhfhIzNpZPKuhD P_3)
	{
		ShLxNDAuNJnTDKEaZHAvIhFLYQDS.xeNSalaogCBYWePkykAFqDDAiyIg xeNSalaogCBYWePkykAFqDDAiyIg = default;
		int num = 0;
		if (P_1 == ctOFTJFVBKiuzGJBAAphUVuqjMxQ.Overlapped)
		{
			num = 1073741824;
		}
		xeNSalaogCBYWePkykAFqDDAiyIg.SnogffYFCMfCCkKszPfCkWVLmPSPA = IntPtr.Zero;
		xeNSalaogCBYWePkykAFqDDAiyIg.BlNmjFmZbFpDanIpOXBqmTuaFfjr = true;
		xeNSalaogCBYWePkykAFqDDAiyIg.HgxwubtcbbFQmLNFzBexCAEJMYqVA = ShLxNDAuNJnTDKEaZHAvIhFLYQDS.xeNSalaogCBYWePkykAFqDDAiyIg.pzwoHHQfPUXRMUqpObunRsNSGZfe;
		return ShLxNDAuNJnTDKEaZHAvIhFLYQDS.oxDEwCDsNviabifvVgjNaeMaYGpSB(P_0, P_2, (int)P_3, ref xeNSalaogCBYWePkykAFqDDAiyIg, 3, num, 0);
	}

	public static void loNBgHHnJJMkGKStYGscmBCMLcfeA(IntPtr P_0)
	{
		ljvlnjOUneRUYSpzsYjNaHWeomZK(P_0);
		ShLxNDAuNJnTDKEaZHAvIhFLYQDS.NOfaSaWaefCTDmJzDKjAPteqSIPS(P_0);
	}

	public static void ljvlnjOUneRUYSpzsYjNaHWeomZK(IntPtr P_0)
	{
		if (Environment.OSVersion.Version.Major > 5)
		{
			ShLxNDAuNJnTDKEaZHAvIhFLYQDS.uevyJKaQAhsRjWkvJBGgDXyZhCdu(P_0, IntPtr.Zero);
		}
		else
		{
			ShLxNDAuNJnTDKEaZHAvIhFLYQDS.KXCgoeJNtsERxFNRwLdtANGBgMGhB(P_0);
		}
	}

	private static void SFDBjgCRXVatSzdsxbuenixppbbM(IntPtr P_0)
	{
		ShLxNDAuNJnTDKEaZHAvIhFLYQDS.KXCgoeJNtsERxFNRwLdtANGBgMGhB(P_0);
		ShLxNDAuNJnTDKEaZHAvIhFLYQDS.NOfaSaWaefCTDmJzDKjAPteqSIPS(P_0);
	}

	internal static uBrmqrtoboLqIilEjDdEvcpBPEer ipNjIgFWEEllTJKLlNptxJOIFncjA(int P_0, int P_1, int P_2, int P_3, int P_4)
	{
		wxlHCDILRVcoBHEmujveTRxbstif[] array = new wxlHCDILRVcoBHEmujveTRxbstif[P_3];
		for (int i = 0; i < P_3; i++)
		{
			ShLxNDAuNJnTDKEaZHAvIhFLYQDS.DVgYSclMFDtZYIvLCHXbYLrTvDwQ.mWqAuqhYPnfUUslbVAcIYTxTxjLP ohwJpxneazBbvILeACikVTcRwxBuA = new ShLxNDAuNJnTDKEaZHAvIhFLYQDS.DVgYSclMFDtZYIvLCHXbYLrTvDwQ.mWqAuqhYPnfUUslbVAcIYTxTxjLP
			{
				vQtRUcEEFQBhBDtqZLFiDKfVmtwyA = new ushort[8]
			};
			ohwJpxneazBbvILeACikVTcRwxBuA.vQtRUcEEFQBhBDtqZLFiDKfVmtwyA[0] = (ushort)i;
			array[i] = new wxlHCDILRVcoBHEmujveTRxbstif(new ShLxNDAuNJnTDKEaZHAvIhFLYQDS.DVgYSclMFDtZYIvLCHXbYLrTvDwQ
			{
				wjvKfdPFLezigrJKovPyfSnxwoMu = 9,
				OhwJpxneazBbvILeACikVTcRwxBuA = ohwJpxneazBbvILeACikVTcRwxBuA
			});
		}
		int num = P_2 + P_4;
		PdfAqamcmCtcqUOoEkGdViEMjvPj[] array2 = new PdfAqamcmCtcqUOoEkGdViEMjvPj[num];
		for (int j = 0; j < num; j++)
		{
			ShLxNDAuNJnTDKEaZHAvIhFLYQDS.mNVaJLjJJApCPTfPmGgmwciubkUHb.bIGQDdchPTcYhdyTEYUVEpefcIKlA cXLLXXFZXKPmXvtNLvkrMqirggDdA = new ShLxNDAuNJnTDKEaZHAvIhFLYQDS.mNVaJLjJJApCPTfPmGgmwciubkUHb.bIGQDdchPTcYhdyTEYUVEpefcIKlA
			{
				VzdFOLTNXEtsFfpzKUodxsRBWPVT = new ushort[8]
			};
			if (j < P_2)
			{
				cXLLXXFZXKPmXvtNLvkrMqirggDdA.VzdFOLTNXEtsFfpzKUodxsRBWPVT[0] = 48;
			}
			else
			{
				cXLLXXFZXKPmXvtNLvkrMqirggDdA.VzdFOLTNXEtsFfpzKUodxsRBWPVT[0] = 57;
			}
			array2[j] = new PdfAqamcmCtcqUOoEkGdViEMjvPj(new ShLxNDAuNJnTDKEaZHAvIhFLYQDS.mNVaJLjJJApCPTfPmGgmwciubkUHb
			{
				FDTZvmKpvBBUEekspVzkOHEyeLNM = 1,
				cXLLXXFZXKPmXvtNLvkrMqirggDdA = cXLLXXFZXKPmXvtNLvkrMqirggDdA
			});
		}
		return new uBrmqrtoboLqIilEjDdEvcpBPEer(new xRdvJrjnuAKDcrZmDYbIabxCedKX(new ShLxNDAuNJnTDKEaZHAvIhFLYQDS.CzLYjTNGKFReTjXWzGrDquGuXSoc
		{
			IlYWYMuKSWGXikcFzceavlkRZKSx = (ushort)P_1,
			rqDNZzzKBcVTskhbOhpxQQljhqAhA = (ushort)P_0
		}), new NqTosaasjQkHHuLirCdfKTHVvRdf(new ShLxNDAuNJnTDKEaZHAvIhFLYQDS.uluRdPyaVZecGDITYmfOItfVMapfb
		{
			yBaAGgBchXiuCCdyjcvunvPwezNvb = (short)P_3,
			nOJaEMgLYGNbXYgnGBylYLbLceZSA = (short)P_2
		}), array, array2);
	}

	private static byte[] hVmWkLoRkOmMnVHEUVVAwKrqDdBI(int P_0)
	{
		byte[] array = null;
		Array.Resize(ref array, P_0 + 1);
		return array;
	}

	public static xRdvJrjnuAKDcrZmDYbIabxCedKX dXsQQeFIwWEMYUSTwANCOgjRamlR(IntPtr P_0)
	{
		ShLxNDAuNJnTDKEaZHAvIhFLYQDS.CzLYjTNGKFReTjXWzGrDquGuXSoc czLYjTNGKFReTjXWzGrDquGuXSoc = default;
		czLYjTNGKFReTjXWzGrDquGuXSoc.ODhkazWJKBFfKTbrmWRzdBSLdQNjA = Marshal.SizeOf(czLYjTNGKFReTjXWzGrDquGuXSoc);
		ShLxNDAuNJnTDKEaZHAvIhFLYQDS.lVZiiyZbqeXafirulSDxhztYIuMy(P_0, ref czLYjTNGKFReTjXWzGrDquGuXSoc);
		return new xRdvJrjnuAKDcrZmDYbIabxCedKX(czLYjTNGKFReTjXWzGrDquGuXSoc);
	}

	public static NqTosaasjQkHHuLirCdfKTHVvRdf FpPExrBxktREmNOUDfQaIdpFEQjl(IntPtr P_0)
	{
		ShLxNDAuNJnTDKEaZHAvIhFLYQDS.uluRdPyaVZecGDITYmfOItfVMapfb uluRdPyaVZecGDITYmfOItfVMapfb = default;
		IntPtr zero = IntPtr.Zero;
		try
		{
			if (ShLxNDAuNJnTDKEaZHAvIhFLYQDS.glqieqUFVyNTOLCOaIlljJsgpClab(P_0, ref zero))
			{
				ShLxNDAuNJnTDKEaZHAvIhFLYQDS.ZwYYoGPIXxVUZoPbDGeBEkXrdPdW(zero, ref uluRdPyaVZecGDITYmfOItfVMapfb);
			}
		}
		catch
		{
		}
		finally
		{
			try
			{
				if (zero != IntPtr.Zero)
				{
					ShLxNDAuNJnTDKEaZHAvIhFLYQDS.reTUDYMitdaTURSyxDgtUjVAZWCv(zero);
				}
			}
			catch
			{
			}
		}
		return new NqTosaasjQkHHuLirCdfKTHVvRdf(uluRdPyaVZecGDITYmfOItfVMapfb);
	}

	public static wxlHCDILRVcoBHEmujveTRxbstif[] hadyVWcKuGFUzZyLjLSGQPXZQjlu(IntPtr P_0, short P_1, short P_2)
	{
		wxlHCDILRVcoBHEmujveTRxbstif[] array = new wxlHCDILRVcoBHEmujveTRxbstif[P_2];
		if (P_2 <= 0)
		{
			return array;
		}
		short num = P_2;
		IntPtr zero = IntPtr.Zero;
		try
		{
			if (ShLxNDAuNJnTDKEaZHAvIhFLYQDS.glqieqUFVyNTOLCOaIlljJsgpClab(P_0, ref zero))
			{
				int num2 = 72 * P_2;
				IntPtr intPtr = IntPtr.Zero;
				try
				{
					intPtr = Marshal.AllocHGlobal(num2);
					IntPtr intPtr2 = intPtr;
					ShLxNDAuNJnTDKEaZHAvIhFLYQDS.hLlQRsWqYCUazQjGmazmlHJJKSPK(intPtr, num2);
					ShLxNDAuNJnTDKEaZHAvIhFLYQDS.iuvOzHeveSnXbZyFktAArXUFPlIh(P_1, intPtr, ref num, zero);
					if (num > 0)
					{
						ShLxNDAuNJnTDKEaZHAvIhFLYQDS.DVgYSclMFDtZYIvLCHXbYLrTvDwQ[] array2 = new ShLxNDAuNJnTDKEaZHAvIhFLYQDS.DVgYSclMFDtZYIvLCHXbYLrTvDwQ[num];
						for (int i = 0; i < num; i++)
						{
							array2[i] = (ShLxNDAuNJnTDKEaZHAvIhFLYQDS.DVgYSclMFDtZYIvLCHXbYLrTvDwQ)Marshal.PtrToStructure(intPtr2, typeof(ShLxNDAuNJnTDKEaZHAvIhFLYQDS.DVgYSclMFDtZYIvLCHXbYLrTvDwQ));
							intPtr2 = NativeTools.OffsetIntPtr(intPtr2, 72);
							array[i] = new wxlHCDILRVcoBHEmujveTRxbstif(array2[i]);
						}
					}
				}
				catch
				{
					throw;
				}
				finally
				{
					if (intPtr != IntPtr.Zero)
					{
						Marshal.FreeHGlobal(intPtr);
					}
				}
			}
		}
		catch
		{
		}
		finally
		{
			try
			{
				if (zero != IntPtr.Zero)
				{
					ShLxNDAuNJnTDKEaZHAvIhFLYQDS.reTUDYMitdaTURSyxDgtUjVAZWCv(zero);
				}
			}
			catch
			{
			}
		}
		for (int j = 0; j < P_2; j++)
		{
			if (array[j] == null)
			{
				array[j] = null;
			}
		}
		return array;
	}

	public static PdfAqamcmCtcqUOoEkGdViEMjvPj[] aJtwmwijQyueiVzaHWwwuWpxWtEH(IntPtr P_0, short P_1, short P_2)
	{
		PdfAqamcmCtcqUOoEkGdViEMjvPj[] array = new PdfAqamcmCtcqUOoEkGdViEMjvPj[P_2];
		if (P_2 <= 0)
		{
			return array;
		}
		short num = P_2;
		IntPtr zero = IntPtr.Zero;
		try
		{
			if (ShLxNDAuNJnTDKEaZHAvIhFLYQDS.glqieqUFVyNTOLCOaIlljJsgpClab(P_0, ref zero))
			{
				int num2 = 72 * P_2;
				IntPtr intPtr = IntPtr.Zero;
				try
				{
					intPtr = Marshal.AllocHGlobal(num2);
					IntPtr intPtr2 = intPtr;
					ShLxNDAuNJnTDKEaZHAvIhFLYQDS.hLlQRsWqYCUazQjGmazmlHJJKSPK(intPtr, num2);
					ShLxNDAuNJnTDKEaZHAvIhFLYQDS.esyEblDPSujYpFWKsgCQfvSkZUkE(P_1, intPtr, ref num, zero);
					if (num > 0)
					{
						ShLxNDAuNJnTDKEaZHAvIhFLYQDS.mNVaJLjJJApCPTfPmGgmwciubkUHb[] array2 = new ShLxNDAuNJnTDKEaZHAvIhFLYQDS.mNVaJLjJJApCPTfPmGgmwciubkUHb[num];
						for (int i = 0; i < num; i++)
						{
							array2[i] = (ShLxNDAuNJnTDKEaZHAvIhFLYQDS.mNVaJLjJJApCPTfPmGgmwciubkUHb)Marshal.PtrToStructure(intPtr2, typeof(ShLxNDAuNJnTDKEaZHAvIhFLYQDS.mNVaJLjJJApCPTfPmGgmwciubkUHb));
							intPtr2 = NativeTools.OffsetIntPtr(intPtr2, 72);
							array[i] = new PdfAqamcmCtcqUOoEkGdViEMjvPj(array2[i]);
						}
					}
				}
				catch
				{
					throw;
				}
				finally
				{
					if (intPtr != IntPtr.Zero)
					{
						Marshal.FreeHGlobal(intPtr);
					}
				}
			}
		}
		catch
		{
		}
		finally
		{
			try
			{
				if (zero != IntPtr.Zero)
				{
					ShLxNDAuNJnTDKEaZHAvIhFLYQDS.reTUDYMitdaTURSyxDgtUjVAZWCv(zero);
				}
			}
			catch
			{
			}
		}
		for (int j = 0; j < P_2; j++)
		{
			if (array[j] == null)
			{
				array[j] = null;
			}
		}
		return array;
	}
}
