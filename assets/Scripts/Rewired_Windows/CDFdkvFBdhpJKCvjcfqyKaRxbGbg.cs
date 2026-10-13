using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using Rewired;
using Rewired.Data;
using Rewired.Interfaces;

internal class CDFdkvFBdhpJKCvjcfqyKaRxbGbg : IInputSource, IDisposable
{
	private static wsPALPmOMbTebMRwHLDiDviZUqac ycsYPuqcSjGqRKqLyoieSiejxJaZ;

	private List<gmzcmYbFSNucJXQyYRMseSdXxgyb> GpnscUyctNWkHvvTzCqwvSngqWPf;

	private ReadOnlyCollection<gmzcmYbFSNucJXQyYRMseSdXxgyb> opfJMJVAPCXsoojVqXxelnfsDngp;

	private ConfigVars BBecVrLHIrUmelgfNjSaghoxIsrq;

	private readonly bool ierxwKhLheXvpaMSlaSfgRHvHuHB;

	private readonly bool laVicCALJOHvKJgPleKVMmfgOIrM;

	private readonly bool dJPsLcQNXpKOoWBVvFdHJrRQBIdc;

	private bool XKbbyOTPACxOzRgrdMaupGtJaBsB;

	private Action zeOXcZAyJWPFBjeuoTeNOrXplhmv__BackingField;

	private readonly bool pSDWpbrGIWKYeQBfbXIwDxFRGcnx;

	private readonly bool hrwIWvHdnSLzZImRVliIBXxKLfEh;

	private readonly bool oUqGRIEBowfVQqFVdsCBQbTBVOjR;

	private bool ItZhjZNxoDdsYPsEQpNEZepQidRcA;

	private double NaMAnsYDJphojIpYghbrgSsCKQxhb;

	private int ozEOSEFoMYPDLVhjjCoIzRXtekwFA;

	private bool ANpGxMNRjlKIrOcuvCNBTQgoapEFA;

	private static readonly string HmlUhedrguMbyaxWkhTAdMAKpEpE = "Rewired Windows Gaming Input support is not available on this system.";

	private bool dxkkeuJoeuTyQVDuioGFufhxsAKx;

	public IUnifiedKeyboardSource ilxfjRXoAcOVMjWzCEAjnyLSPsTn => pymenyEzuwwYMpVOeVqjrkEmYGAbA();

	public IUnifiedMouseSource jhAVLuERmQvRfzCMMdfjgmecwqZcA => iZMGyRILyHctZxzPCaGjLknkFTPx();

	private event Action zeOXcZAyJWPFBjeuoTeNOrXplhmv
	{
		add
		{
			jOMXrXFhGDJqcMjqpkaeEjUfKZYt(action);
		}
		remove
		{
			sNXFMIRTtHgvCAhwSNRhomppQNOtA(action);
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

	private void jOMXrXFhGDJqcMjqpkaeEjUfKZYt(Action P_0)
	{
		Action action = zeOXcZAyJWPFBjeuoTeNOrXplhmv__BackingField;
		Action action2;
		do
		{
			action2 = action;
			Action value = (Action)Delegate.Combine(action2, P_0);
			action = Interlocked.CompareExchange(ref zeOXcZAyJWPFBjeuoTeNOrXplhmv__BackingField, value, action2);
		}
		while ((object)action != action2);
	}

	private void sNXFMIRTtHgvCAhwSNRhomppQNOtA(Action P_0)
	{
		Action action = zeOXcZAyJWPFBjeuoTeNOrXplhmv__BackingField;
		Action action2;
		do
		{
			action2 = action;
			Action value = (Action)Delegate.Remove(action2, P_0);
			action = Interlocked.CompareExchange(ref zeOXcZAyJWPFBjeuoTeNOrXplhmv__BackingField, value, action2);
		}
		while ((object)action != action2);
	}

	public CDFdkvFBdhpJKCvjcfqyKaRxbGbg(ConfigVars P_0, bool P_1, bool P_2, bool P_3)
	{
		try
		{
			BBecVrLHIrUmelgfNjSaghoxIsrq = P_0;
			ierxwKhLheXvpaMSlaSfgRHvHuHB = P_1;
			laVicCALJOHvKJgPleKVMmfgOIrM = P_2;
			dJPsLcQNXpKOoWBVvFdHJrRQBIdc = P_3;
			if (P_2)
			{
				throw new NotImplementedException("WGI mouse input not implemented.");
			}
			if (P_3)
			{
				throw new NotImplementedException("WGI keyboard input not implemented.");
			}
			try
			{
				if (!GyZRfqoFeNpsmfpARcxriLBnNneI.RaGWRWClfEKCyIYTCRBLxcJqAWLeA())
				{
					Logger.LogWarning(HmlUhedrguMbyaxWkhTAdMAKpEpE + " Requires " + GyZRfqoFeNpsmfpARcxriLBnNneI.ztfaiUEtXcRzxKewivCthgESWhGs() + " or greater.");
					throw new Exception();
				}
			}
			catch (DllNotFoundException)
			{
				Logger.LogWarning(HmlUhedrguMbyaxWkhTAdMAKpEpE + " Either Rewired_WindowsGamingInput.dll is missing or this version of Windows does not meet the minimum version requirements for Windows Gaming Input support.");
				throw new Exception();
			}
			catch
			{
				Logger.LogWarning(HmlUhedrguMbyaxWkhTAdMAKpEpE);
				throw new Exception();
			}
			pSDWpbrGIWKYeQBfbXIwDxFRGcnx = true;
			if (oUqGRIEBowfVQqFVdsCBQbTBVOjR)
			{
				hrwIWvHdnSLzZImRVliIBXxKLfEh = false;
			}
			if (pSDWpbrGIWKYeQBfbXIwDxFRGcnx)
			{
				ycsYPuqcSjGqRKqLyoieSiejxJaZ = new wsPALPmOMbTebMRwHLDiDviZUqac(CuoyPQlAkVbibfzvDYUYzqWaFpXK);
			}
			GpnscUyctNWkHvvTzCqwvSngqWPf = new List<gmzcmYbFSNucJXQyYRMseSdXxgyb>();
			opfJMJVAPCXsoojVqXxelnfsDngp = new ReadOnlyCollection<gmzcmYbFSNucJXQyYRMseSdXxgyb>(GpnscUyctNWkHvvTzCqwvSngqWPf);
			if (pSDWpbrGIWKYeQBfbXIwDxFRGcnx)
			{
				ycsYPuqcSjGqRKqLyoieSiejxJaZ.sKblAtevFiynHOQNFUHdPGlssIRI(MSiVjdAasYxNXLNodSplGSiKgrxI);
			}
			if (P_1)
			{
				oYtOPwwkuwchpHrMverScJdSxFpKA(true);
			}
			ReInput.ApplicationFocusChangedEvent += LogElxvHebPRwLqNgfoCwpkeumUv;
		}
		catch (Exception)
		{
			Dispose();
			throw;
		}
	}

	public void BHFphUSqDVtWvQOCItKDuaOqebfCA()
	{
		XKbbyOTPACxOzRgrdMaupGtJaBsB = false;
		oYtOPwwkuwchpHrMverScJdSxFpKA(false);
	}

	public IUnifiedKeyboardSource pymenyEzuwwYMpVOeVqjrkEmYGAbA()
	{
		return null;
	}

	public IUnifiedMouseSource iZMGyRILyHctZxzPCaGjLknkFTPx()
	{
		return null;
	}

	public bool QUXfsGXHpUheQdxuFDKdWyXBgOvo(PidVid P_0)
	{
		if (pSDWpbrGIWKYeQBfbXIwDxFRGcnx && xdVIbvBoDAUiDeiBddhJTIMLUfnL.xqogzmTVlOHwfTERimDpAguyGRwhA(P_0.vendorId, P_0.productId))
		{
			return true;
		}
		return false;
	}

	public void add_DeviceChangedEvent(Action value)
	{
		jOMXrXFhGDJqcMjqpkaeEjUfKZYt(value);
	}

	public void remove_DeviceChangedEvent(Action value)
	{
		sNXFMIRTtHgvCAhwSNRhomppQNOtA(value);
	}

	public void SystemDeviceDisconnected()
	{
		MSiVjdAasYxNXLNodSplGSiKgrxI();
	}

	void IInputSource.SystemDeviceDisconnected()
	{
		//ILSpy generated this explicit interface implementation from .override directive in SystemDeviceDisconnected
		this.SystemDeviceDisconnected();
	}

	public void SystemDeviceConnected()
	{
		MSiVjdAasYxNXLNodSplGSiKgrxI();
	}

	void IInputSource.SystemDeviceConnected()
	{
		//ILSpy generated this explicit interface implementation from .override directive in SystemDeviceConnected
		this.SystemDeviceConnected();
	}

	public void Update()
	{
		if (ANpGxMNRjlKIrOcuvCNBTQgoapEFA)
		{
			MSiVjdAasYxNXLNodSplGSiKgrxI();
		}
		if (pSDWpbrGIWKYeQBfbXIwDxFRGcnx)
		{
			ycsYPuqcSjGqRKqLyoieSiejxJaZ.ltOBriXLEWaAkSUzOOpJIProXWDw();
		}
	}

	void IInputSource.Update()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Update
		this.Update();
	}

	public void UpdateDevices(UpdateLoopType updateLoop)
	{
		if (ierxwKhLheXvpaMSlaSfgRHvHuHB)
		{
			for (int i = 0; i < GpnscUyctNWkHvvTzCqwvSngqWPf.Count; i++)
			{
				GpnscUyctNWkHvvTzCqwvSngqWPf[i]?.ZXzMJxUabwfskaDuIMCoIqHNiIohb(updateLoop);
			}
			if (pSDWpbrGIWKYeQBfbXIwDxFRGcnx)
			{
				ycsYPuqcSjGqRKqLyoieSiejxJaZ.zPcPMzNPYfwTdlgutUoyEJbtgDu();
			}
		}
	}

	void IInputSource.UpdateDevices(UpdateLoopType updateLoop)
	{
		//ILSpy generated this explicit interface implementation from .override directive in UpdateDevices
		this.UpdateDevices(updateLoop);
	}

	public void UpdateFinished()
	{
		for (int i = 0; i < GpnscUyctNWkHvvTzCqwvSngqWPf.Count; i++)
		{
			GpnscUyctNWkHvvTzCqwvSngqWPf[i]?.PvuGjrJeXqoLFEVsBrAaNPYwHCHZ();
		}
	}

	void IInputSource.UpdateFinished()
	{
		//ILSpy generated this explicit interface implementation from .override directive in UpdateFinished
		this.UpdateFinished();
	}

	public IList<T> GetJoysticks<T>() where T : class
	{
		return opfJMJVAPCXsoojVqXxelnfsDngp as IList<T>;
	}

	IList<T> IInputSource.GetJoysticks<T>()
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetJoysticks
		return this.GetJoysticks<T>();
	}

	private void oYtOPwwkuwchpHrMverScJdSxFpKA(bool P_0)
	{
		if (ANpGxMNRjlKIrOcuvCNBTQgoapEFA)
		{
			ANpGxMNRjlKIrOcuvCNBTQgoapEFA = false;
		}
		List<gmzcmYbFSNucJXQyYRMseSdXxgyb> list = new List<gmzcmYbFSNucJXQyYRMseSdXxgyb>();
		int num = 0;
		if (pSDWpbrGIWKYeQBfbXIwDxFRGcnx)
		{
			IList<CfENPjACeuDyUowrFIDWzqlxhXcF> list2 = ycsYPuqcSjGqRKqLyoieSiejxJaZ.cWPtsifGuJgwZrfAidaMasbAcAkCA();
			for (int i = 0; i < list2.Count; i++)
			{
				CfENPjACeuDyUowrFIDWzqlxhXcF cfENPjACeuDyUowrFIDWzqlxhXcF = list2[i];
				if (cfENPjACeuDyUowrFIDWzqlxhXcF != null)
				{
					list.Add(cfENPjACeuDyUowrFIDWzqlxhXcF);
					num++;
				}
			}
		}
		if (list.Count == 0)
		{
			GpnscUyctNWkHvvTzCqwvSngqWPf.Clear();
			return;
		}
		int count = list.Count;
		int count2 = GpnscUyctNWkHvvTzCqwvSngqWPf.Count;
		gmzcmYbFSNucJXQyYRMseSdXxgyb[] array = new gmzcmYbFSNucJXQyYRMseSdXxgyb[count];
		for (int j = 0; j < count; j++)
		{
			bool flag = false;
			for (int k = 0; k < count2; k++)
			{
				if (list[j] != null && GpnscUyctNWkHvvTzCqwvSngqWPf[k] != null && list[j].oUZdQCDRbHeXQqUNlgKsyHIQARfu() == GpnscUyctNWkHvvTzCqwvSngqWPf[k].oUZdQCDRbHeXQqUNlgKsyHIQARfu())
				{
					array[j] = GpnscUyctNWkHvvTzCqwvSngqWPf[k];
					array[j].kueKcMmnzBMisbVAZHAxhJkHbEPn(list[j]);
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				array[j] = list[j];
			}
		}
		GpnscUyctNWkHvvTzCqwvSngqWPf.Clear();
		for (int l = 0; l < count; l++)
		{
			if (array[l] != null)
			{
				GpnscUyctNWkHvvTzCqwvSngqWPf.Add(array[l]);
			}
		}
	}

	private void MSiVjdAasYxNXLNodSplGSiKgrxI()
	{
		if (ierxwKhLheXvpaMSlaSfgRHvHuHB)
		{
			XKbbyOTPACxOzRgrdMaupGtJaBsB = true;
		}
		if (zeOXcZAyJWPFBjeuoTeNOrXplhmv__BackingField != null)
		{
			zeOXcZAyJWPFBjeuoTeNOrXplhmv__BackingField();
		}
	}

	private int CuoyPQlAkVbibfzvDYUYzqWaFpXK()
	{
		int result = ozEOSEFoMYPDLVhjjCoIzRXtekwFA;
		if (ozEOSEFoMYPDLVhjjCoIzRXtekwFA == int.MaxValue)
		{
			ozEOSEFoMYPDLVhjjCoIzRXtekwFA = 0;
			return result;
		}
		ozEOSEFoMYPDLVhjjCoIzRXtekwFA++;
		return result;
	}

	private void LogElxvHebPRwLqNgfoCwpkeumUv(bool P_0)
	{
		if (ierxwKhLheXvpaMSlaSfgRHvHuHB && P_0)
		{
			ANpGxMNRjlKIrOcuvCNBTQgoapEFA = true;
		}
	}

	public void Dispose()
	{
		HMNsOWwsKXUfFjEVaJFyrizHkpeW(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	protected virtual void dyZaVtlheIbNhktYKkxdeJvXCnBs()
	{
		try
		{
			HMNsOWwsKXUfFjEVaJFyrizHkpeW(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	protected virtual void HMNsOWwsKXUfFjEVaJFyrizHkpeW(bool P_0)
	{
		if (dxkkeuJoeuTyQVDuioGFufhxsAKx)
		{
			return;
		}
		if (P_0)
		{
			ReInput.ApplicationFocusChangedEvent -= LogElxvHebPRwLqNgfoCwpkeumUv;
			if (ycsYPuqcSjGqRKqLyoieSiejxJaZ != null)
			{
				ycsYPuqcSjGqRKqLyoieSiejxJaZ.Dispose();
			}
			if (GpnscUyctNWkHvvTzCqwvSngqWPf != null)
			{
				for (int i = 0; i < GpnscUyctNWkHvvTzCqwvSngqWPf.Count; i++)
				{
					if (GpnscUyctNWkHvvTzCqwvSngqWPf[i] != null)
					{
						GpnscUyctNWkHvvTzCqwvSngqWPf[i].Dispose();
					}
				}
			}
		}
		dxkkeuJoeuTyQVDuioGFufhxsAKx = true;
	}
}
