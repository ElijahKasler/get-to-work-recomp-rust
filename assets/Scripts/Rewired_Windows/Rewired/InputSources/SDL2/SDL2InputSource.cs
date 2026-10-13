using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Rewired.Config;
using Rewired.Interfaces;
using Rewired.Platforms;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;

namespace Rewired.InputSources.SDL2;

[CustomObfuscation(rename = false)]
[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
internal class SDL2InputSource : IInputSource, IDisposable
{
	public delegate void rnTZBHyKmffSbbubnITdjqbhcWzaA(int joystickId, byte rewiredElementType, byte elementIndex, short value);

	public delegate void UTceoKkpjdLECBRSPjGbYeMDIEEj(int joystickIndex);

	public delegate void GxpEJDfmblpFKaUnPDzJgEFHLDxiB(int joystickId);

	public delegate void uxSBXVcVXAVFjlyiCLVEWQrmNYjH(int gameControllerId, byte rewiredElementType, byte sdlElementType, short value);

	private const int KQwlazTRzRzBQdGVRcjzhLEBoJtE = 32;

	private bool tiDGELQtUvYtoifFCtgFZJLJagBHA;

	private bool yepdaySCjujxLdKUkzTflacJBMGX;

	private bool uupSiDkmaxTysSuffFqkLkqECDYh;

	private bool xFzFepeYSvmoVPmCYMqSdYDdojSKc;

	private bool cmIzEMUqmvGZiYozdJsWusSyBWEp;

	private ADictionary<int, dytsVkHShkJbMvFUtkNPKrKXFuBT> lfKviHvUyqlmQFnLqdcNruJDafox;

	private ADictionary<int, JxhsHUfRYBGNWThFCnmtsZkLSAjt> JTGYLaUwNaUDcrCBmVQGzRrxNIT;

	private OsfsljBQscacHFbwrLECNQOtLNUYA.RArYYRdoWRcdslABXwCgTHEjAiNb MucTiZYaSFsqXhZdUFQTGIBZtBBh;

	private NativeBuffer xPZSwpjLHmyUCnGKjiKpqxZNCtdG;

	[CompilerGenerated]
	private Action prkhqDzdBOjlGMDHmDNvdewyaNwV;

	private bool TxyliJOEYnjDOMDBvsSaLxxJnDhH;

	public bool initialized => cmIzEMUqmvGZiYozdJsWusSyBWEp;

	private event Action _DeviceChangedEvent
	{
		add
		{
			nexDZrOlYIGKjaQTEMBgIoOLoJRyA(action);
		}
		remove
		{
			CnCbndplXZdlIZlhoHlWbAfvqJVd(action);
		}
	}

	event Action IInputSource.DeviceChangedEvent
	{
		add
		{
			add_DeviceChangedEvent(value);
		}
		remove
		{
			remove_DeviceChangedEvent(value);
		}
	}

	public SDL2InputSource(UpdateLoopSetting P_0, bool P_1, bool P_2, bool P_3, bool P_4)
	{
		tiDGELQtUvYtoifFCtgFZJLJagBHA = P_1;
		yepdaySCjujxLdKUkzTflacJBMGX = P_2;
		uupSiDkmaxTysSuffFqkLkqECDYh = P_3;
		xFzFepeYSvmoVPmCYMqSdYDdojSKc = P_4;
		lfKviHvUyqlmQFnLqdcNruJDafox = new ADictionary<int, dytsVkHShkJbMvFUtkNPKrKXFuBT>();
		JTGYLaUwNaUDcrCBmVQGzRrxNIT = new ADictionary<int, JxhsHUfRYBGNWThFCnmtsZkLSAjt>();
		int num = ((!UnityTools.isEditor || UnityTools.editorPlatform != EditorPlatform.OSX) ? 29184 : 25088);
		try
		{
			OsfsljBQscacHFbwrLECNQOtLNUYA.MudHcPVrJMsCbWqoqiTVkZjplzEoA(UnityTools.effectivePlatform);
			if (OsfsljBQscacHFbwrLECNQOtLNUYA.rTCfohcWfObWOzmiETJOcZPyVdXo((uint)num) < 0)
			{
				throw new Exception("Failed initialize SDL2!");
			}
			cmIzEMUqmvGZiYozdJsWusSyBWEp = true;
			if (P_2)
			{
				klKDwobNYXptLUCITsgouLGtRdUjA();
			}
			kVriaqkgzxqHUGriCRTekQtdAyCx();
			xPZSwpjLHmyUCnGKjiKpqxZNCtdG = new NativeBuffer(56);
		}
		catch
		{
			cmIzEMUqmvGZiYozdJsWusSyBWEp = false;
			Dispose();
			throw;
		}
	}

	private void nexDZrOlYIGKjaQTEMBgIoOLoJRyA(Action P_0)
	{
		Action action = prkhqDzdBOjlGMDHmDNvdewyaNwV;
		Action action2;
		do
		{
			action2 = action;
			Action value = (Action)Delegate.Combine(action2, P_0);
			action = Interlocked.CompareExchange(ref prkhqDzdBOjlGMDHmDNvdewyaNwV, value, action2);
		}
		while ((object)action != action2);
	}

	private void CnCbndplXZdlIZlhoHlWbAfvqJVd(Action P_0)
	{
		Action action = prkhqDzdBOjlGMDHmDNvdewyaNwV;
		Action action2;
		do
		{
			action2 = action;
			Action value = (Action)Delegate.Remove(action2, P_0);
			action = Interlocked.CompareExchange(ref prkhqDzdBOjlGMDHmDNvdewyaNwV, value, action2);
		}
		while ((object)action != action2);
	}

	public void add_DeviceChangedEvent(Action value)
	{
		nexDZrOlYIGKjaQTEMBgIoOLoJRyA(value);
	}

	public void remove_DeviceChangedEvent(Action value)
	{
		CnCbndplXZdlIZlhoHlWbAfvqJVd(value);
	}

	public void SystemDeviceConnected()
	{
		throw new NotImplementedException();
	}

	void IInputSource.SystemDeviceConnected()
	{
		//ILSpy generated this explicit interface implementation from .override directive in SystemDeviceConnected
		this.SystemDeviceConnected();
	}

	public void SystemDeviceDisconnected()
	{
		throw new NotImplementedException();
	}

	void IInputSource.SystemDeviceDisconnected()
	{
		//ILSpy generated this explicit interface implementation from .override directive in SystemDeviceDisconnected
		this.SystemDeviceDisconnected();
	}

	public void Update()
	{
		_ = cmIzEMUqmvGZiYozdJsWusSyBWEp;
	}

	void IInputSource.Update()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Update
		this.Update();
	}

	public void UpdateDevices(UpdateLoopType updateLoop)
	{
		if (cmIzEMUqmvGZiYozdJsWusSyBWEp)
		{
			ByxtSKxWsUldbiWsGcsGmnJKfgykA();
		}
	}

	void IInputSource.UpdateDevices(UpdateLoopType updateLoop)
	{
		//ILSpy generated this explicit interface implementation from .override directive in UpdateDevices
		this.UpdateDevices(updateLoop);
	}

	public void UpdateFinished()
	{
		_ = cmIzEMUqmvGZiYozdJsWusSyBWEp;
	}

	void IInputSource.UpdateFinished()
	{
		//ILSpy generated this explicit interface implementation from .override directive in UpdateFinished
		this.UpdateFinished();
	}

	public IList<T> GetJoysticks<T>() where T : class
	{
		if (!cmIzEMUqmvGZiYozdJsWusSyBWEp)
		{
			return null;
		}
		List<wfXvpNxXWJkwQbGkekNHCgrsJhAN> list = new List<wfXvpNxXWJkwQbGkekNHCgrsJhAN>();
		if (tiDGELQtUvYtoifFCtgFZJLJagBHA)
		{
			using ADictionary<int, dytsVkHShkJbMvFUtkNPKrKXFuBT>.Enumerator enumerator = lfKviHvUyqlmQFnLqdcNruJDafox.GetEnumerator();
			while (enumerator.MoveNext())
			{
				KeyValuePair<int, dytsVkHShkJbMvFUtkNPKrKXFuBT> current = enumerator.get_Current();
				if (current.Value.ZVfclUhbJuDATcnOHytuMFGKnkmib())
				{
					list.Add(current.Value);
				}
			}
		}
		if (yepdaySCjujxLdKUkzTflacJBMGX)
		{
			using ADictionary<int, JxhsHUfRYBGNWThFCnmtsZkLSAjt>.Enumerator enumerator2 = JTGYLaUwNaUDcrCBmVQGzRrxNIT.GetEnumerator();
			while (enumerator2.MoveNext())
			{
				JxhsHUfRYBGNWThFCnmtsZkLSAjt value = enumerator2.get_Current().Value;
				if (value.ZVfclUhbJuDATcnOHytuMFGKnkmib())
				{
					list.Add(value);
				}
			}
		}
		return list as IList<T>;
	}

	IList<T> IInputSource.GetJoysticks<T>()
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetJoysticks
		return this.GetJoysticks<T>();
	}

	private int IXeUejsLbppFpZumqbIPbQHrFoLV()
	{
		if (!cmIzEMUqmvGZiYozdJsWusSyBWEp)
		{
			return 0;
		}
		return Math.Min(OsfsljBQscacHFbwrLECNQOtLNUYA.ERqnhbmsXGrRELjaWQasMVpFcKiK(), 32);
	}

	private int eTyXePDdeEYsNdItjCiKFLqZEfhbb()
	{
		if (!cmIzEMUqmvGZiYozdJsWusSyBWEp)
		{
			return 0;
		}
		int num = IXeUejsLbppFpZumqbIPbQHrFoLV();
		int num2 = 0;
		for (int i = 0; i < num; i++)
		{
			if (!OsfsljBQscacHFbwrLECNQOtLNUYA.zDzlAnNMHRLBvTfijBdGbfloOtdG(i))
			{
				num2++;
			}
		}
		return num2;
	}

	private dytsVkHShkJbMvFUtkNPKrKXFuBT WfLgZaKWjaDOSEpjDMKFvsIWPrNi(int P_0)
	{
		IntPtr intPtr = OsfsljBQscacHFbwrLECNQOtLNUYA.SIEGQhyMbiavliYjfjezdwfhmZoeA(P_0);
		if (intPtr == IntPtr.Zero)
		{
			return null;
		}
		ayyCptEvnVZMHoroVFHzjUCNbdutA ayyCptEvnVZMHoroVFHzjUCNbdutA2 = new ayyCptEvnVZMHoroVFHzjUCNbdutA(intPtr);
		IAAFlLaEmOAKFhJtpjmyFEAAumJI iAAFlLaEmOAKFhJtpjmyFEAAumJI = VOlsLygsKSUKxQiPhhIJJwfgaFstA(P_0, ayyCptEvnVZMHoroVFHzjUCNbdutA2);
		if (iAAFlLaEmOAKFhJtpjmyFEAAumJI == null)
		{
			OsfsljBQscacHFbwrLECNQOtLNUYA.nsOluWejVILDdfSTNwpsoPbpMbyv(intPtr);
			return null;
		}
		return new dytsVkHShkJbMvFUtkNPKrKXFuBT(ayyCptEvnVZMHoroVFHzjUCNbdutA2, iAAFlLaEmOAKFhJtpjmyFEAAumJI);
	}

	private JxhsHUfRYBGNWThFCnmtsZkLSAjt eoGDRhKXvFdvXemPhrrGpoPWvjAxb(int P_0)
	{
		IntPtr intPtr = OsfsljBQscacHFbwrLECNQOtLNUYA.pmuKGEzBnxCwZhmncSQzVsSwatUfA(P_0);
		if (intPtr == IntPtr.Zero)
		{
			return null;
		}
		lxVxMGbKPDZmtJbkuQcNHzYbTkdN lxVxMGbKPDZmtJbkuQcNHzYbTkdN2 = new lxVxMGbKPDZmtJbkuQcNHzYbTkdN(intPtr);
		IAAFlLaEmOAKFhJtpjmyFEAAumJI iAAFlLaEmOAKFhJtpjmyFEAAumJI = kHKDCHBnYLuAxtonDHyrKBKUFTxB(P_0, lxVxMGbKPDZmtJbkuQcNHzYbTkdN2);
		if (iAAFlLaEmOAKFhJtpjmyFEAAumJI == null)
		{
			return null;
		}
		if (!iAAFlLaEmOAKFhJtpjmyFEAAumJI.iVERHwrZfbDAUWkjANBMmkEiSqxx)
		{
			OsfsljBQscacHFbwrLECNQOtLNUYA.lQFnwLlbKdmTJXdeLZycQJuDgJKs(intPtr);
			return null;
		}
		iAAFlLaEmOAKFhJtpjmyFEAAumJI.wfNZNcyaZDKPQzZLgHFiFfMWxqgT = OsfsljBQscacHFbwrLECNQOtLNUYA.nysJxqTyLmHdtRTgtFenNHeMakjp(lxVxMGbKPDZmtJbkuQcNHzYbTkdN2);
		return new JxhsHUfRYBGNWThFCnmtsZkLSAjt(lxVxMGbKPDZmtJbkuQcNHzYbTkdN2, iAAFlLaEmOAKFhJtpjmyFEAAumJI);
	}

	private IAAFlLaEmOAKFhJtpjmyFEAAumJI VOlsLygsKSUKxQiPhhIJJwfgaFstA(int P_0, ayyCptEvnVZMHoroVFHzjUCNbdutA P_1)
	{
		if (!cmIzEMUqmvGZiYozdJsWusSyBWEp)
		{
			return null;
		}
		if (P_0 < 0 || P_0 >= 32)
		{
			return null;
		}
		if (P_1 == null || !P_1.IsValid)
		{
			return null;
		}
		return new IAAFlLaEmOAKFhJtpjmyFEAAumJI
		{
			hEzlGejRlGBJxsasPbkRSaotaZQX = P_0,
			qxgDhgsyoCRCqNHSXsZXNmEWqtjS = OsfsljBQscacHFbwrLECNQOtLNUYA.foTceuglLuAvfecoetHcscxZvkjD(P_1),
			iVERHwrZfbDAUWkjANBMmkEiSqxx = OsfsljBQscacHFbwrLECNQOtLNUYA.zDzlAnNMHRLBvTfijBdGbfloOtdG(P_0),
			GRoCzECVhFaGiGeOjjEKGOwnORzPb = OsfsljBQscacHFbwrLECNQOtLNUYA.EXwDRtEiKNStIWzinAjvebpizlgQ(P_1),
			CRnpgRGEolEOZfWBvbHSdVCGcvGjb = OsfsljBQscacHFbwrLECNQOtLNUYA.RAkhNQerJFzUNapYsaVkQlFRxack(P_1),
			VfzkKeUiiAirYipbHfzJnIbNWzOC = OsfsljBQscacHFbwrLECNQOtLNUYA.istKPIHhvQEZTcWyAraHJAVodHdeb(P_0),
			UcBeMSCqWqTcNgVOxjrCxCNRAuccA = OsfsljBQscacHFbwrLECNQOtLNUYA.rUnTnIoLcPUoggotteEMKxkjrcdJA(P_1),
			cEnICQEqWQasPlVOLRucRdILXlMQ = OsfsljBQscacHFbwrLECNQOtLNUYA.FaBSHloKXbDupOOShSWPTGlBHtof(P_1),
			GtsiCYSTKxlZGRkBETwknYAkjDtT = OsfsljBQscacHFbwrLECNQOtLNUYA.BaOgTKbnUhmPhtHCQHCPcNtgvAUt(P_1),
			oHoKlGhiPBbsWZEKuTwihlJYHXcN = OsfsljBQscacHFbwrLECNQOtLNUYA.TLROPZrQgipkLOwgkFpRGoTRYOaB(P_1)
		};
	}

	private IAAFlLaEmOAKFhJtpjmyFEAAumJI kHKDCHBnYLuAxtonDHyrKBKUFTxB(int P_0, lxVxMGbKPDZmtJbkuQcNHzYbTkdN P_1)
	{
		if (P_1 == null || !P_1.IsValid)
		{
			return null;
		}
		ayyCptEvnVZMHoroVFHzjUCNbdutA ayyCptEvnVZMHoroVFHzjUCNbdutA2 = new ayyCptEvnVZMHoroVFHzjUCNbdutA(OsfsljBQscacHFbwrLECNQOtLNUYA.LMFALPuMuTReMzbjbAMAwaekFsQiA(P_1));
		if (!ayyCptEvnVZMHoroVFHzjUCNbdutA2.IsValid)
		{
			return null;
		}
		return VOlsLygsKSUKxQiPhhIJJwfgaFstA(P_0, ayyCptEvnVZMHoroVFHzjUCNbdutA2);
	}

	private void kVriaqkgzxqHUGriCRTekQtdAyCx()
	{
		for (int i = 0; i < IXeUejsLbppFpZumqbIPbQHrFoLV(); i++)
		{
			if (tiDGELQtUvYtoifFCtgFZJLJagBHA)
			{
				EGXhWOLsORygfYbfpFJfLMONXJGJ(i);
			}
			if (yepdaySCjujxLdKUkzTflacJBMGX)
			{
				tkuhvOCotitNPZZDnVvNxhvXEjvGA(i);
			}
		}
	}

	private void fyftFtBfndFtYAGgDXPiOGRlPnbx()
	{
		if (yepdaySCjujxLdKUkzTflacJBMGX)
		{
			using (ADictionary<int, JxhsHUfRYBGNWThFCnmtsZkLSAjt>.Enumerator enumerator = JTGYLaUwNaUDcrCBmVQGzRrxNIT.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					JxhsHUfRYBGNWThFCnmtsZkLSAjt value = enumerator.get_Current().Value;
					value.tZNfhxwhNnVzzkLTHLkkicSGEMODA();
					value.Dispose();
				}
			}
			JTGYLaUwNaUDcrCBmVQGzRrxNIT.Clear();
		}
		if (!tiDGELQtUvYtoifFCtgFZJLJagBHA)
		{
			return;
		}
		using (ADictionary<int, dytsVkHShkJbMvFUtkNPKrKXFuBT>.Enumerator enumerator2 = lfKviHvUyqlmQFnLqdcNruJDafox.GetEnumerator())
		{
			while (enumerator2.MoveNext())
			{
				dytsVkHShkJbMvFUtkNPKrKXFuBT value2 = enumerator2.get_Current().Value;
				value2.tZNfhxwhNnVzzkLTHLkkicSGEMODA();
				value2.Dispose();
			}
		}
		lfKviHvUyqlmQFnLqdcNruJDafox.Clear();
	}

	private bool EGXhWOLsORygfYbfpFJfLMONXJGJ(int P_0)
	{
		if (P_0 < 0 || P_0 >= 32)
		{
			return false;
		}
		if (yepdaySCjujxLdKUkzTflacJBMGX && OsfsljBQscacHFbwrLECNQOtLNUYA.zDzlAnNMHRLBvTfijBdGbfloOtdG(P_0))
		{
			return false;
		}
		dytsVkHShkJbMvFUtkNPKrKXFuBT dytsVkHShkJbMvFUtkNPKrKXFuBT2 = WfLgZaKWjaDOSEpjDMKFvsIWPrNi(P_0);
		if (dytsVkHShkJbMvFUtkNPKrKXFuBT2 == null)
		{
			return false;
		}
		int snYyacqBSPsYSwGHCYYarWhRImDk = dytsVkHShkJbMvFUtkNPKrKXFuBT2.snYyacqBSPsYSwGHCYYarWhRImDk;
		if (lfKviHvUyqlmQFnLqdcNruJDafox.ContainsKey(snYyacqBSPsYSwGHCYYarWhRImDk))
		{
			lfKviHvUyqlmQFnLqdcNruJDafox.get_Item(snYyacqBSPsYSwGHCYYarWhRImDk).tZNfhxwhNnVzzkLTHLkkicSGEMODA();
			lfKviHvUyqlmQFnLqdcNruJDafox.set_Item(snYyacqBSPsYSwGHCYYarWhRImDk, dytsVkHShkJbMvFUtkNPKrKXFuBT2);
		}
		else
		{
			lfKviHvUyqlmQFnLqdcNruJDafox.Add(snYyacqBSPsYSwGHCYYarWhRImDk, dytsVkHShkJbMvFUtkNPKrKXFuBT2);
		}
		dytsVkHShkJbMvFUtkNPKrKXFuBT2.QahbfsSjWRYETdcGTaJvPUVjtSRT();
		return true;
	}

	private void lmulDpfWtaAYMRFDtGpYdfiWgmiIA(int P_0)
	{
		if (lfKviHvUyqlmQFnLqdcNruJDafox.ContainsKey(P_0))
		{
			lfKviHvUyqlmQFnLqdcNruJDafox.get_Item(P_0).tZNfhxwhNnVzzkLTHLkkicSGEMODA();
			lfKviHvUyqlmQFnLqdcNruJDafox.Remove(P_0);
		}
	}

	private bool tkuhvOCotitNPZZDnVvNxhvXEjvGA(int P_0)
	{
		if (P_0 < 0 || P_0 >= 32)
		{
			return false;
		}
		if (!OsfsljBQscacHFbwrLECNQOtLNUYA.zDzlAnNMHRLBvTfijBdGbfloOtdG(P_0))
		{
			return false;
		}
		JxhsHUfRYBGNWThFCnmtsZkLSAjt jxhsHUfRYBGNWThFCnmtsZkLSAjt = eoGDRhKXvFdvXemPhrrGpoPWvjAxb(P_0);
		if (jxhsHUfRYBGNWThFCnmtsZkLSAjt == null)
		{
			return false;
		}
		int snYyacqBSPsYSwGHCYYarWhRImDk = jxhsHUfRYBGNWThFCnmtsZkLSAjt.snYyacqBSPsYSwGHCYYarWhRImDk;
		if (JTGYLaUwNaUDcrCBmVQGzRrxNIT.ContainsKey(snYyacqBSPsYSwGHCYYarWhRImDk))
		{
			JTGYLaUwNaUDcrCBmVQGzRrxNIT.get_Item(snYyacqBSPsYSwGHCYYarWhRImDk).tZNfhxwhNnVzzkLTHLkkicSGEMODA();
			JTGYLaUwNaUDcrCBmVQGzRrxNIT.set_Item(snYyacqBSPsYSwGHCYYarWhRImDk, jxhsHUfRYBGNWThFCnmtsZkLSAjt);
		}
		else
		{
			JTGYLaUwNaUDcrCBmVQGzRrxNIT.Add(snYyacqBSPsYSwGHCYYarWhRImDk, jxhsHUfRYBGNWThFCnmtsZkLSAjt);
		}
		jxhsHUfRYBGNWThFCnmtsZkLSAjt.QahbfsSjWRYETdcGTaJvPUVjtSRT();
		return true;
	}

	private void FUwHGJApGfYtewURajcUqKVZIerF(int P_0)
	{
		if (JTGYLaUwNaUDcrCBmVQGzRrxNIT.ContainsKey(P_0))
		{
			JTGYLaUwNaUDcrCBmVQGzRrxNIT.get_Item(P_0).tZNfhxwhNnVzzkLTHLkkicSGEMODA();
			JTGYLaUwNaUDcrCBmVQGzRrxNIT.Remove(P_0);
		}
	}

	private dytsVkHShkJbMvFUtkNPKrKXFuBT JYVGnPDIerZANKJmlLXHeVCbQQzZB(int P_0)
	{
		if (!lfKviHvUyqlmQFnLqdcNruJDafox.TryGetValue(P_0, out var value))
		{
			return null;
		}
		return value;
	}

	private JxhsHUfRYBGNWThFCnmtsZkLSAjt QhyZMVGrKmSPXoyUHdMRXnvqpulV(int P_0)
	{
		if (!JTGYLaUwNaUDcrCBmVQGzRrxNIT.TryGetValue(P_0, out var value))
		{
			return null;
		}
		return value;
	}

	private void ByxtSKxWsUldbiWsGcsGmnJKfgykA()
	{
		while (OsfsljBQscacHFbwrLECNQOtLNUYA.OvGFvBikhSPCrflSKNaRXmdTRBgLB(xPZSwpjLHmyUCnGKjiKpqxZNCtdG) != 0)
		{
			MucTiZYaSFsqXhZdUFQTGIBZtBBh.uLmrCpXqaFzUnnwOhHGXhaozjerQ(xPZSwpjLHmyUCnGKjiKpqxZNCtdG);
			OsfsljBQscacHFbwrLECNQOtLNUYA.YIcYcPRrJNeicBXOXGFjVFjlEtgO cqBVdpNgsrQfDlQFfokMWjRWNCXT = MucTiZYaSFsqXhZdUFQTGIBZtBBh.CqBVdpNgsrQfDlQFfokMWjRWNCXT;
			double realTime = ReInput.realTime;
			switch (cqBVdpNgsrQfDlQFfokMWjRWNCXT)
			{
			case OsfsljBQscacHFbwrLECNQOtLNUYA.YIcYcPRrJNeicBXOXGFjVFjlEtgO.SDL_CONTROLLERAXISMOTION:
				SIXhqdWSjsUyePOcMCoxFlKLdCWQ(ref MucTiZYaSFsqXhZdUFQTGIBZtBBh.PSaiwhgGBCrwtWWtkeaOSwLGAXCl, realTime);
				break;
			case OsfsljBQscacHFbwrLECNQOtLNUYA.YIcYcPRrJNeicBXOXGFjVFjlEtgO.SDL_CONTROLLERBUTTONDOWN:
			case OsfsljBQscacHFbwrLECNQOtLNUYA.YIcYcPRrJNeicBXOXGFjVFjlEtgO.SDL_CONTROLLERBUTTONUP:
				jlADVRdBKukysWsvUZIYNrLnWvdNA(ref MucTiZYaSFsqXhZdUFQTGIBZtBBh.GyGTrcJjxPEKjSDovQILvpCrWscA, realTime);
				break;
			case OsfsljBQscacHFbwrLECNQOtLNUYA.YIcYcPRrJNeicBXOXGFjVFjlEtgO.SDL_CONTROLLERDEVICEREMAPPED:
				XXLBmINRphgZuAVfJdBMZobiHyFdb(ref MucTiZYaSFsqXhZdUFQTGIBZtBBh.BrtICyGxoIWQmFgImzderYXqpOHP);
				break;
			case OsfsljBQscacHFbwrLECNQOtLNUYA.YIcYcPRrJNeicBXOXGFjVFjlEtgO.SDL_JOYAXISMOTION:
				VZbUbzyewkAHDUvyvAjGGubKpyWFb(ref MucTiZYaSFsqXhZdUFQTGIBZtBBh.JrqfYVESrlXFmfrzcjbKrHKkJexAb, realTime);
				break;
			case OsfsljBQscacHFbwrLECNQOtLNUYA.YIcYcPRrJNeicBXOXGFjVFjlEtgO.SDL_JOYBUTTONDOWN:
			case OsfsljBQscacHFbwrLECNQOtLNUYA.YIcYcPRrJNeicBXOXGFjVFjlEtgO.SDL_JOYBUTTONUP:
				tILMGEKGEHBSQIOeDEhEjrvghpbjc(ref MucTiZYaSFsqXhZdUFQTGIBZtBBh.IxQLHOVLjdDbngZrLaopotQdPCkSA, realTime);
				break;
			case OsfsljBQscacHFbwrLECNQOtLNUYA.YIcYcPRrJNeicBXOXGFjVFjlEtgO.SDL_JOYHATMOTION:
				RUclgOYAIccxwIXFhIJiiiHhYEyP(ref MucTiZYaSFsqXhZdUFQTGIBZtBBh.HdFMkUYdZgkIJpstaptHRkMPsoCn, realTime);
				break;
			case OsfsljBQscacHFbwrLECNQOtLNUYA.YIcYcPRrJNeicBXOXGFjVFjlEtgO.SDL_JOYBALLMOTION:
				NIWbyyEZrqYOJCppEqBWEHmDPIhJ(ref MucTiZYaSFsqXhZdUFQTGIBZtBBh.hyhmwkhipbsmTLkKMzDebMyuxokM, realTime);
				break;
			case OsfsljBQscacHFbwrLECNQOtLNUYA.YIcYcPRrJNeicBXOXGFjVFjlEtgO.SDL_JOYDEVICEADDED:
				VHIHAhXKBNfqWAlfHAfDjANfmQcXB(ref MucTiZYaSFsqXhZdUFQTGIBZtBBh.zikNLudvfamAkLTptWQTdPQqsWKt);
				break;
			case OsfsljBQscacHFbwrLECNQOtLNUYA.YIcYcPRrJNeicBXOXGFjVFjlEtgO.SDL_JOYDEVICEREMOVED:
				irNlnvQURruuNZdkVPKjWyZVRTUx(ref MucTiZYaSFsqXhZdUFQTGIBZtBBh.zikNLudvfamAkLTptWQTdPQqsWKt);
				break;
			case OsfsljBQscacHFbwrLECNQOtLNUYA.YIcYcPRrJNeicBXOXGFjVFjlEtgO.SDL_CONTROLLERDEVICEADDED:
				xxOOeQToyQyAOTynYbyTFLwPHGKO(ref MucTiZYaSFsqXhZdUFQTGIBZtBBh.BrtICyGxoIWQmFgImzderYXqpOHP);
				break;
			case OsfsljBQscacHFbwrLECNQOtLNUYA.YIcYcPRrJNeicBXOXGFjVFjlEtgO.SDL_CONTROLLERDEVICEREMOVED:
				UDOjtJtWmLnNtTTKxCzsPzPAtnIu(ref MucTiZYaSFsqXhZdUFQTGIBZtBBh.BrtICyGxoIWQmFgImzderYXqpOHP);
				break;
			}
		}
	}

	private void VZbUbzyewkAHDUvyvAjGGubKpyWFb(ref OsfsljBQscacHFbwrLECNQOtLNUYA.pdjRxsQdHVGXrBkfrOFjEWkiFLDPB P_0, double P_1)
	{
		if (tiDGELQtUvYtoifFCtgFZJLJagBHA)
		{
			DjdWeigNIeinxwQTIEHdbEszgdre(P_0.KwvMZwVUyNfQVufnZEdPAPPEhnINA, aNxuBJsykbeIskgYvbekioeaXlGP.Axis, P_0.HEAEyinEbjfzWUWJkjdzDiCLFEDWA, P_0.uaTXrncFGsdiEQlpjfQgeJCqCORAA, P_1);
		}
	}

	private void tILMGEKGEHBSQIOeDEhEjrvghpbjc(ref OsfsljBQscacHFbwrLECNQOtLNUYA.REoFDOHsOglIVOQcnZhahgVRWZJe P_0, double P_1)
	{
		if (tiDGELQtUvYtoifFCtgFZJLJagBHA)
		{
			DjdWeigNIeinxwQTIEHdbEszgdre(P_0.ooZqErJZFFvRULoPVZrXbIEQSsGG, aNxuBJsykbeIskgYvbekioeaXlGP.Button, P_0.MuFNKIEfbhaUUmGpRVsfPqLzpRUP, P_0.fDLDgcbYwgQzUeHkaDbeRYMVNbqlA, P_1);
		}
	}

	private void RUclgOYAIccxwIXFhIJiiiHhYEyP(ref OsfsljBQscacHFbwrLECNQOtLNUYA.EdjbhiBtawwkumBwlvLuTPnlCide P_0, double P_1)
	{
		if (tiDGELQtUvYtoifFCtgFZJLJagBHA)
		{
			DjdWeigNIeinxwQTIEHdbEszgdre(P_0.OLSiLizWyosPwOIIqxWXemNNIODF, aNxuBJsykbeIskgYvbekioeaXlGP.Hat, P_0.euXuEnKmRNnazPJOHOoRHIgLKgqp, P_0.PZDjJRpIyqKTwMZGQhJhqcKezKHD, P_1);
		}
	}

	private void NIWbyyEZrqYOJCppEqBWEHmDPIhJ(ref OsfsljBQscacHFbwrLECNQOtLNUYA.npNLCmAqMrnspRuCaNYIjbdlDJsU P_0, double P_1)
	{
		_ = tiDGELQtUvYtoifFCtgFZJLJagBHA;
	}

	private void VHIHAhXKBNfqWAlfHAfDjANfmQcXB(ref OsfsljBQscacHFbwrLECNQOtLNUYA.BQppLIWYBbAAviAwxhWdGrLWASLd P_0)
	{
		if (tiDGELQtUvYtoifFCtgFZJLJagBHA)
		{
			EGXhWOLsORygfYbfpFJfLMONXJGJ(P_0.JVVAsigLWoQyQAYiwQZpiKkzvwuZ);
			if (prkhqDzdBOjlGMDHmDNvdewyaNwV != null)
			{
				prkhqDzdBOjlGMDHmDNvdewyaNwV();
			}
		}
	}

	private void irNlnvQURruuNZdkVPKjWyZVRTUx(ref OsfsljBQscacHFbwrLECNQOtLNUYA.BQppLIWYBbAAviAwxhWdGrLWASLd P_0)
	{
		if (tiDGELQtUvYtoifFCtgFZJLJagBHA)
		{
			lmulDpfWtaAYMRFDtGpYdfiWgmiIA(P_0.JVVAsigLWoQyQAYiwQZpiKkzvwuZ);
			if (prkhqDzdBOjlGMDHmDNvdewyaNwV != null)
			{
				prkhqDzdBOjlGMDHmDNvdewyaNwV();
			}
		}
	}

	private void SIXhqdWSjsUyePOcMCoxFlKLdCWQ(ref OsfsljBQscacHFbwrLECNQOtLNUYA.lSOjDzHSakxYHyzSjnIQGaqwmJmL P_0, double P_1)
	{
		if (yepdaySCjujxLdKUkzTflacJBMGX && P_0.HWUFcvhHhaGyopsZcTfJHIeQpegzA != 6)
		{
			QuGZgdaickPAVajeYstCDGSQGskkA(P_0.DUwtfYZuMZPgyYKAzKAmpAvmcHUL, aNxuBJsykbeIskgYvbekioeaXlGP.Axis, P_0.HWUFcvhHhaGyopsZcTfJHIeQpegzA, P_0.wpBNVbANGAOwoFdywuwEDRCJJtwQ, P_1);
		}
	}

	private void jlADVRdBKukysWsvUZIYNrLnWvdNA(ref OsfsljBQscacHFbwrLECNQOtLNUYA.KkbcuaBaUZhuqGXoWRJHsuREvlTdA P_0, double P_1)
	{
		if (yepdaySCjujxLdKUkzTflacJBMGX && P_0.HEnBZbvQkBApqqJBDDuQEcerSkCF != 15)
		{
			QuGZgdaickPAVajeYstCDGSQGskkA(P_0.dMvFRLGNtPDBsIHxNoTRKkmUADEP, aNxuBJsykbeIskgYvbekioeaXlGP.Button, P_0.HEnBZbvQkBApqqJBDDuQEcerSkCF, P_0.TjqgrgQnDvwgtGQduOrLQttqomNQ, P_1);
		}
	}

	private void xxOOeQToyQyAOTynYbyTFLwPHGKO(ref OsfsljBQscacHFbwrLECNQOtLNUYA.kLxTiMLQTfNSloGIVbSjtFGkzxhk P_0)
	{
		if (yepdaySCjujxLdKUkzTflacJBMGX)
		{
			tkuhvOCotitNPZZDnVvNxhvXEjvGA(P_0.cwTmXBSyvogioZuclhiMPmqQxGJl);
			if (prkhqDzdBOjlGMDHmDNvdewyaNwV != null)
			{
				prkhqDzdBOjlGMDHmDNvdewyaNwV();
			}
		}
	}

	private void UDOjtJtWmLnNtTTKxCzsPzPAtnIu(ref OsfsljBQscacHFbwrLECNQOtLNUYA.kLxTiMLQTfNSloGIVbSjtFGkzxhk P_0)
	{
		if (yepdaySCjujxLdKUkzTflacJBMGX)
		{
			FUwHGJApGfYtewURajcUqKVZIerF(P_0.cwTmXBSyvogioZuclhiMPmqQxGJl);
			if (prkhqDzdBOjlGMDHmDNvdewyaNwV != null)
			{
				prkhqDzdBOjlGMDHmDNvdewyaNwV();
			}
		}
	}

	private void XXLBmINRphgZuAVfJdBMZobiHyFdb(ref OsfsljBQscacHFbwrLECNQOtLNUYA.kLxTiMLQTfNSloGIVbSjtFGkzxhk P_0)
	{
		_ = yepdaySCjujxLdKUkzTflacJBMGX;
	}

	private void DjdWeigNIeinxwQTIEHdbEszgdre(int P_0, aNxuBJsykbeIskgYvbekioeaXlGP P_1, byte P_2, short P_3, double P_4)
	{
		JYVGnPDIerZANKJmlLXHeVCbQQzZB(P_0)?.ZnHPNCQSCBaltGNrcQlGPIfPXZLE(P_1, P_2, P_3, P_4);
	}

	private void QuGZgdaickPAVajeYstCDGSQGskkA(int P_0, aNxuBJsykbeIskgYvbekioeaXlGP P_1, byte P_2, short P_3, double P_4)
	{
		QhyZMVGrKmSPXoyUHdMRXnvqpulV(P_0)?.ZnHPNCQSCBaltGNrcQlGPIfPXZLE(P_1, P_2, P_3, P_4);
	}

	private void klKDwobNYXptLUCITsgouLGtRdUjA()
	{
		string[] array = MSKBaIRfYTFJPyHSdeWVakZTVmaL.CMUoGeGuclnYcdOsOoDVNhQpAFpJ();
		if (array == null)
		{
			return;
		}
		for (int i = 0; i < array.Length; i++)
		{
			if (!string.IsNullOrEmpty(array[i]) && array[i].Length > 32 && !(OsfsljBQscacHFbwrLECNQOtLNUYA.YEyiGxfuOmURYKdMGVnARFzrdVMh(new Guid(array[i].Substring(0, 32))) != string.Empty))
			{
				OsfsljBQscacHFbwrLECNQOtLNUYA.drBohRFRWItvOEKyvjmUVtEUeuLP(array[i]);
			}
		}
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	~SDL2InputSource()
	{
		Dispose(disposing: false);
	}

	protected virtual void Dispose(bool disposing)
	{
		if (TxyliJOEYnjDOMDBvsSaLxxJnDhH)
		{
			return;
		}
		if (disposing)
		{
			if (xPZSwpjLHmyUCnGKjiKpqxZNCtdG != null)
			{
				xPZSwpjLHmyUCnGKjiKpqxZNCtdG.Dispose();
			}
			fyftFtBfndFtYAGgDXPiOGRlPnbx();
		}
		OsfsljBQscacHFbwrLECNQOtLNUYA.mcHYprGeixBLVjmHZUybGJCaaOiKA();
		cmIzEMUqmvGZiYozdJsWusSyBWEp = false;
		TxyliJOEYnjDOMDBvsSaLxxJnDhH = true;
	}
}
