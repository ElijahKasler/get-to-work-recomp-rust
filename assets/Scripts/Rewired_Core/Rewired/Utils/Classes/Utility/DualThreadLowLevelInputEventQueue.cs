using System;

namespace Rewired.Utils.Classes.Utility;

[CustomObfuscation(rename = false)]
[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
internal class DualThreadLowLevelInputEventQueue : IDisposable
{
	private class eRapPMnUrIxvevMLgildUIPsVpuy : LockedObject<LowLevelInputEvent>, INewEventWrapper, IDisposable
	{
		LowLevelInputEvent INewEventWrapper.Event
		{
			get
			{
				return get_Event();
			}
			set
			{
				set_Event(value);
			}
		}

		public LowLevelInputEvent get_Event()
		{
			return item;
		}

		public void set_Event(LowLevelInputEvent value)
		{
			item = value;
		}

		public eRapPMnUrIxvevMLgildUIPsVpuy(object P_0)
			: base(P_0)
		{
		}
	}

	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	public interface INewEventWrapper : IDisposable
	{
		LowLevelInputEvent Event { get; set; }
	}

	private readonly LowLevelInputEventQueue TVOuryXRVzXKeIEsRUbTcARZYkcJ;

	private readonly LowLevelInputEventQueue bPejfVYKjcoPlDiZTnyUgotNgKwN;

	private readonly object XKoGHaSIolNOPTNqlQzYbLyWKzbB;

	private uint pLnPancrWCguafxfjHYPsutYRUPH;

	private bool peMADebvpHEPZRyRGgYbDlFyzWtT;

	private int kGHeOEFuEjdWEadoeSyophaaoTiCA;

	private int iLSseqzFlXzzlRuGxWFNpaHjrQdp;

	private eRapPMnUrIxvevMLgildUIPsVpuy aQtunIuTnOVgcBQnHNzXDehbFCjcA;

	public LowLevelInputEvent currentEvent;

	private bool KKxeBTnEECjHrbKoYOCpMDYidKYx;

	public uint lastProcessedEventId => pLnPancrWCguafxfjHYPsutYRUPH;

	public int count
	{
		get
		{
			lock (XKoGHaSIolNOPTNqlQzYbLyWKzbB)
			{
				return TVOuryXRVzXKeIEsRUbTcARZYkcJ.Count;
			}
		}
	}

	public DualThreadLowLevelInputEventQueue(int P_0, int P_1, int P_2, int P_3)
	{
		TVOuryXRVzXKeIEsRUbTcARZYkcJ = new LowLevelInputEventQueue(P_0, P_1, P_2, P_3);
		bPejfVYKjcoPlDiZTnyUgotNgKwN = new LowLevelInputEventQueue(P_0, P_1, P_2, P_3);
		XKoGHaSIolNOPTNqlQzYbLyWKzbB = new object();
		aQtunIuTnOVgcBQnHNzXDehbFCjcA = new eRapPMnUrIxvevMLgildUIPsVpuy(XKoGHaSIolNOPTNqlQzYbLyWKzbB);
	}

	public INewEventWrapper T_CreateEvent()
	{
		aQtunIuTnOVgcBQnHNzXDehbFCjcA.Lock();
		aQtunIuTnOVgcBQnHNzXDehbFCjcA.item = bPejfVYKjcoPlDiZTnyUgotNgKwN.CreateEvent();
		return aQtunIuTnOVgcBQnHNzXDehbFCjcA;
	}

	public void Update()
	{
		lock (XKoGHaSIolNOPTNqlQzYbLyWKzbB)
		{
			TVOuryXRVzXKeIEsRUbTcARZYkcJ.CopyNewEventsFrom(bPejfVYKjcoPlDiZTnyUgotNgKwN);
		}
	}

	public void Clear()
	{
		lock (XKoGHaSIolNOPTNqlQzYbLyWKzbB)
		{
			StopProcessingEvents();
			TVOuryXRVzXKeIEsRUbTcARZYkcJ.Clear();
			bPejfVYKjcoPlDiZTnyUgotNgKwN.Clear();
		}
	}

	public bool ProcessNewEvents()
	{
		if (iLSseqzFlXzzlRuGxWFNpaHjrQdp == 0)
		{
			Update();
			int num = TVOuryXRVzXKeIEsRUbTcARZYkcJ.FindNextIndex(pLnPancrWCguafxfjHYPsutYRUPH);
			if (num < 0)
			{
				currentEvent = default;
				return false;
			}
			iLSseqzFlXzzlRuGxWFNpaHjrQdp = num;
			peMADebvpHEPZRyRGgYbDlFyzWtT = true;
			kGHeOEFuEjdWEadoeSyophaaoTiCA = TVOuryXRVzXKeIEsRUbTcARZYkcJ.Count;
		}
		if (iLSseqzFlXzzlRuGxWFNpaHjrQdp >= kGHeOEFuEjdWEadoeSyophaaoTiCA)
		{
			currentEvent = default;
			peMADebvpHEPZRyRGgYbDlFyzWtT = false;
			iLSseqzFlXzzlRuGxWFNpaHjrQdp = 0;
			return false;
		}
		if (TVOuryXRVzXKeIEsRUbTcARZYkcJ.TryGetNext(iLSseqzFlXzzlRuGxWFNpaHjrQdp, out currentEvent))
		{
			pLnPancrWCguafxfjHYPsutYRUPH = currentEvent.GetId();
			iLSseqzFlXzzlRuGxWFNpaHjrQdp++;
			return true;
		}
		currentEvent = default;
		peMADebvpHEPZRyRGgYbDlFyzWtT = false;
		iLSseqzFlXzzlRuGxWFNpaHjrQdp = 0;
		return false;
	}

	public void StopProcessingEvents()
	{
		peMADebvpHEPZRyRGgYbDlFyzWtT = false;
		iLSseqzFlXzzlRuGxWFNpaHjrQdp = 0;
	}

	public void ImportAll(DualThreadLowLevelInputEventQueue other)
	{
		if (other == null)
		{
			throw new ArgumentNullException("other");
		}
		if (other == this)
		{
			return;
		}
		lock (XKoGHaSIolNOPTNqlQzYbLyWKzbB)
		{
			lock (other.XKoGHaSIolNOPTNqlQzYbLyWKzbB)
			{
				TVOuryXRVzXKeIEsRUbTcARZYkcJ.CopyAllFrom(other.TVOuryXRVzXKeIEsRUbTcARZYkcJ);
				bPejfVYKjcoPlDiZTnyUgotNgKwN.CopyAllFrom(other.bPejfVYKjcoPlDiZTnyUgotNgKwN);
				pLnPancrWCguafxfjHYPsutYRUPH = other.pLnPancrWCguafxfjHYPsutYRUPH;
				peMADebvpHEPZRyRGgYbDlFyzWtT = other.peMADebvpHEPZRyRGgYbDlFyzWtT;
				kGHeOEFuEjdWEadoeSyophaaoTiCA = other.kGHeOEFuEjdWEadoeSyophaaoTiCA;
				iLSseqzFlXzzlRuGxWFNpaHjrQdp = other.iLSseqzFlXzzlRuGxWFNpaHjrQdp;
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

	~DualThreadLowLevelInputEventQueue()
	{
		Dispose(disposing: false);
	}

	protected void Dispose(bool disposing)
	{
		if (KKxeBTnEECjHrbKoYOCpMDYidKYx)
		{
			return;
		}
		if (disposing)
		{
			lock (XKoGHaSIolNOPTNqlQzYbLyWKzbB)
			{
				TVOuryXRVzXKeIEsRUbTcARZYkcJ.Dispose();
				bPejfVYKjcoPlDiZTnyUgotNgKwN.Dispose();
			}
		}
		KKxeBTnEECjHrbKoYOCpMDYidKYx = true;
	}
}
