using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using Rewired.Interfaces;

namespace Rewired.Platforms.Custom;

public abstract class CustomInputSource : IDisposable
{
	public abstract class Controller
	{
		protected bool _isConnected;

		protected string _deviceName;

		protected string _customName;

		protected object _customIdentifier;

		protected Guid _persistentGuid;

		private Action<bool> uUFcZIxgSmECnFgRMTrgwwxKBFdy;

		public string customName => _customName;

		public bool isConnected
		{
			get
			{
				return _isConnected;
			}
			set
			{
				if (value == _isConnected)
				{
					return;
				}
				_isConnected = value;
				Action<bool> action = uUFcZIxgSmECnFgRMTrgwwxKBFdy;
				if (action == null)
				{
					return;
				}
				try
				{
					action(value);
				}
				catch (Exception exception)
				{
					ReInput.HandleCallbackException("CustomInputSource.Controller.ConnectedStateChangedEvent", exception);
				}
			}
		}

		public string deviceName => _deviceName;

		public object customIdentifier
		{
			get
			{
				return _customIdentifier;
			}
			set
			{
				_customIdentifier = value;
			}
		}

		public Guid deviceInstanceGuid
		{
			get
			{
				return _persistentGuid;
			}
			set
			{
				_persistentGuid = value;
			}
		}

		public event Action<bool> ConnectedStateChangedEvent
		{
			add
			{
				uUFcZIxgSmECnFgRMTrgwwxKBFdy = (Action<bool>)Delegate.Combine(uUFcZIxgSmECnFgRMTrgwwxKBFdy, value);
			}
			remove
			{
				uUFcZIxgSmECnFgRMTrgwwxKBFdy = (Action<bool>)Delegate.Remove(uUFcZIxgSmECnFgRMTrgwwxKBFdy, value);
			}
		}

		protected Controller(string P_0)
		{
			_deviceName = P_0;
		}

		public void Disconnect()
		{
			if (_isConnected)
			{
				isConnected = false;
			}
		}

		public void Connect()
		{
			if (!_isConnected)
			{
				isConnected = true;
			}
		}

		public abstract void Update();
	}

	public abstract class Joystick : Controller
	{
		private long? feraXieVJSEngroKPksrqHalRfbNA;

		private int RRjUdpERzEOVYKQDSMnYvSCUvCME;

		private readonly Axis[] zhtINpYirgyZikgPrldOgnHEvvWh;

		private readonly Button[] drHWCxbsAoLZxCqCUEkhZdZgEGyaA;

		private readonly ReadOnlyCollection<Axis> EWzWChvoeQqzPdDTUipktvNapsFw;

		private readonly ReadOnlyCollection<Button> vHiAXjcFyghXcGpnbdcYDTrZAJdTB;

		private bool gOigvLAyvFvuDvsTFCwnkdisMEzI;

		private Rewired.Controller.Extension lEusrXBpDPAEIvMOvTucgjxEWzlJ;

		public long? systemId
		{
			get
			{
				return feraXieVJSEngroKPksrqHalRfbNA;
			}
			protected set
			{
				feraXieVJSEngroKPksrqHalRfbNA = value;
			}
		}

		public int unityId
		{
			get
			{
				return RRjUdpERzEOVYKQDSMnYvSCUvCME;
			}
			protected set
			{
				RRjUdpERzEOVYKQDSMnYvSCUvCME = value;
			}
		}

		public IList<Axis> Axes => EWzWChvoeQqzPdDTUipktvNapsFw;

		public IList<Button> Buttons => vHiAXjcFyghXcGpnbdcYDTrZAJdTB;

		public bool supportsVibration
		{
			get
			{
				return gOigvLAyvFvuDvsTFCwnkdisMEzI;
			}
			set
			{
				gOigvLAyvFvuDvsTFCwnkdisMEzI = value;
			}
		}

		public Rewired.Controller.Extension extension
		{
			get
			{
				return lEusrXBpDPAEIvMOvTucgjxEWzlJ;
			}
			set
			{
				lEusrXBpDPAEIvMOvTucgjxEWzlJ = value;
				if (lEusrXBpDPAEIvMOvTucgjxEWzlJ is IControllerVibrator)
				{
					gOigvLAyvFvuDvsTFCwnkdisMEzI = true;
				}
			}
		}

		public int buttonCount => drHWCxbsAoLZxCqCUEkhZdZgEGyaA.Length;

		public int axisCount => zhtINpYirgyZikgPrldOgnHEvvWh.Length;

		protected Joystick(string P_0, long P_1, int P_2, int P_3)
			: this(P_0, P_1, 0, P_2, P_3)
		{
		}

		public Joystick(string P_0, long? P_1, int P_2, int P_3, int P_4)
			: base(P_0)
		{
			if (P_3 < 0)
			{
				P_3 = 0;
			}
			if (P_4 < 0)
			{
				P_4 = 0;
			}
			feraXieVJSEngroKPksrqHalRfbNA = P_1;
			RRjUdpERzEOVYKQDSMnYvSCUvCME = P_2;
			zhtINpYirgyZikgPrldOgnHEvvWh = new Axis[P_3];
			drHWCxbsAoLZxCqCUEkhZdZgEGyaA = new Button[P_4];
			for (int i = 0; i < P_3; i++)
			{
				zhtINpYirgyZikgPrldOgnHEvvWh[i] = new Axis();
			}
			for (int j = 0; j < P_4; j++)
			{
				drHWCxbsAoLZxCqCUEkhZdZgEGyaA[j] = new Button();
			}
			EWzWChvoeQqzPdDTUipktvNapsFw = new ReadOnlyCollection<Axis>(zhtINpYirgyZikgPrldOgnHEvvWh);
			vHiAXjcFyghXcGpnbdcYDTrZAJdTB = new ReadOnlyCollection<Button>(drHWCxbsAoLZxCqCUEkhZdZgEGyaA);
		}

		public virtual float GetAxisValue(int index)
		{
			if (index < 0 || index >= zhtINpYirgyZikgPrldOgnHEvvWh.Length)
			{
				return 0f;
			}
			return zhtINpYirgyZikgPrldOgnHEvvWh[index].value;
		}

		public virtual bool GetButtonValue(int index)
		{
			if (index < 0 || index >= drHWCxbsAoLZxCqCUEkhZdZgEGyaA.Length)
			{
				return false;
			}
			return drHWCxbsAoLZxCqCUEkhZdZgEGyaA[index].boolValue;
		}

		public virtual float GetButtonFloatValue(int index)
		{
			if (index < 0 || index >= drHWCxbsAoLZxCqCUEkhZdZgEGyaA.Length)
			{
				return 0f;
			}
			return drHWCxbsAoLZxCqCUEkhZdZgEGyaA[index].floatValue;
		}

		public virtual void SetAxisValue(int index, float value)
		{
			if (index >= 0 && index < zhtINpYirgyZikgPrldOgnHEvvWh.Length)
			{
				zhtINpYirgyZikgPrldOgnHEvvWh[index].value = value;
			}
		}

		public virtual void SetButtonValue(int index, bool value)
		{
			if (index >= 0 && index < drHWCxbsAoLZxCqCUEkhZdZgEGyaA.Length)
			{
				drHWCxbsAoLZxCqCUEkhZdZgEGyaA[index].boolValue = value;
			}
		}

		public virtual void SetButtonFloatValue(int index, float value)
		{
			if (index >= 0 && index < drHWCxbsAoLZxCqCUEkhZdZgEGyaA.Length)
			{
				drHWCxbsAoLZxCqCUEkhZdZgEGyaA[index].floatValue = value;
			}
		}

		internal void BeyEkyjAUifZSySZdAgvzQouIXYL(int P_0, out bool P_1, out float P_2)
		{
			if (P_0 < 0 || P_0 >= drHWCxbsAoLZxCqCUEkhZdZgEGyaA.Length)
			{
				P_1 = false;
				P_2 = 0f;
			}
			else
			{
				P_1 = drHWCxbsAoLZxCqCUEkhZdZgEGyaA[P_0].kRjfJgIKCdreUAwlgQmgszZyPeWKA();
				P_2 = drHWCxbsAoLZxCqCUEkhZdZgEGyaA[P_0].floatValue;
			}
		}

		internal virtual void OlMxqNLsIInWYKgYqGyzhCpTLUhI()
		{
			for (int i = 0; i < drHWCxbsAoLZxCqCUEkhZdZgEGyaA.Length; i++)
			{
				if (drHWCxbsAoLZxCqCUEkhZdZgEGyaA[i] != null)
				{
					drHWCxbsAoLZxCqCUEkhZdZgEGyaA[i].vLmaWLGQIihyiNXhQdEsQcQbyavAA();
				}
			}
		}
	}

	public abstract class Element
	{
	}

	public sealed class Axis : Element
	{
		public float value;
	}

	public sealed class Button : Element
	{
		[Obsolete("Deprecated. Use boolValue instead.", false)]
		public bool value;

		private float SnrqQroaqWQKStGZurkyYGBBeXce;

		private bool xTdilFrIHFQWClFPDCPromxkcsNFA;

		public bool boolValue
		{
			get
			{
				return value;
			}
			set
			{
				_ = this.value;
				if (!this.value & value)
				{
					xTdilFrIHFQWClFPDCPromxkcsNFA = true;
				}
				this.value = value;
			}
		}

		public float floatValue
		{
			get
			{
				return SnrqQroaqWQKStGZurkyYGBBeXce;
			}
			set
			{
				SnrqQroaqWQKStGZurkyYGBBeXce = value;
			}
		}

		internal bool kelOysOZrXIbgxSsIKAlHLttjpEH => kRjfJgIKCdreUAwlgQmgszZyPeWKA();

		internal bool kRjfJgIKCdreUAwlgQmgszZyPeWKA()
		{
			if (!value)
			{
				return xTdilFrIHFQWClFPDCPromxkcsNFA;
			}
			return true;
		}

		internal void vLmaWLGQIihyiNXhQdEsQcQbyavAA()
		{
			xTdilFrIHFQWClFPDCPromxkcsNFA = false;
		}
	}

	private readonly InputSource CANCQeDbIZeOGmwWQddnfxuhtGuHb;

	private readonly List<Joystick> eThzmTtGzfymUeKQqWENhpDZdaru;

	private readonly ReadOnlyCollection<Joystick> ZqbuKrHtyrQhDPKRAXALymTMfKwV;

	private bool fyGcPgPYEVSdrJBkafWtbqZMcluYA = true;

	private IUnifiedKeyboardSource RdODYQjljLuHnrOTUgBTXqhGaVOAA;

	private IUnifiedMouseSource pcQqwZJNPjGTzikLTCXGivFLlhgjA;

	private Action dmSwSjpoRtKJFrCHBcJsCGzEwBxP__BackingField;

	private Action dBZHcEDRaqQXdluUWvQffFUmQOtU__BackingField;

	private bool TLUkwogdkRiKBmjljLlQGgbFysQB;

	public bool useApproximateMatching
	{
		get
		{
			return fyGcPgPYEVSdrJBkafWtbqZMcluYA;
		}
		protected set
		{
			fyGcPgPYEVSdrJBkafWtbqZMcluYA = value;
		}
	}

	internal InputSource KaSjhjheWeNwQYUdXihBuPozoSFi => mLNIopHNHCrePmiGorNqaDbovQKH();

	public abstract bool isReady { get; }

	private event Action dmSwSjpoRtKJFrCHBcJsCGzEwBxP
	{
		add
		{
			LxuOBsWDbIOUThryLdVRIkwHMIns(action);
		}
		remove
		{
			JZJDCjBaXZjFDVoasRupoZjQFeji(action);
		}
	}

	private event Action dBZHcEDRaqQXdluUWvQffFUmQOtU
	{
		add
		{
			EztVGZsRYfMUMVLvEQfgUNSRnaPR(action);
		}
		remove
		{
			rPiuMLjApegUJCdGkFMnGrUwyrTL(action);
		}
	}

	internal event Action sQkIYkosIVjXEznbMMtFCDCXdSJv
	{
		add
		{
			OJNEWbVCjzctaktWYaxaXdNJNQAw(action);
		}
		remove
		{
			UbDSZCCNZIlirZLOCdhPzZBJpxiQ(action);
		}
	}

	internal event Action WWfGkFwfVYExZKqNzfRwAKVeMffF
	{
		add
		{
			xxHOhxeWWeIvNpXlXFCqMVdJjaPU(action);
		}
		remove
		{
			lgcDembEotBqTWmPHqGurlJgOhtiA(action);
		}
	}

	private void LxuOBsWDbIOUThryLdVRIkwHMIns(Action P_0)
	{
		Action action = dmSwSjpoRtKJFrCHBcJsCGzEwBxP__BackingField;
		Action action2;
		do
		{
			action2 = action;
			Action value = (Action)Delegate.Combine(action2, P_0);
			action = Interlocked.CompareExchange(ref dmSwSjpoRtKJFrCHBcJsCGzEwBxP__BackingField, value, action2);
		}
		while ((object)action != action2);
	}

	private void JZJDCjBaXZjFDVoasRupoZjQFeji(Action P_0)
	{
		Action action = dmSwSjpoRtKJFrCHBcJsCGzEwBxP__BackingField;
		Action action2;
		do
		{
			action2 = action;
			Action value = (Action)Delegate.Remove(action2, P_0);
			action = Interlocked.CompareExchange(ref dmSwSjpoRtKJFrCHBcJsCGzEwBxP__BackingField, value, action2);
		}
		while ((object)action != action2);
	}

	private void EztVGZsRYfMUMVLvEQfgUNSRnaPR(Action P_0)
	{
		Action action = dBZHcEDRaqQXdluUWvQffFUmQOtU__BackingField;
		Action action2;
		do
		{
			action2 = action;
			Action value = (Action)Delegate.Combine(action2, P_0);
			action = Interlocked.CompareExchange(ref dBZHcEDRaqQXdluUWvQffFUmQOtU__BackingField, value, action2);
		}
		while ((object)action != action2);
	}

	private void rPiuMLjApegUJCdGkFMnGrUwyrTL(Action P_0)
	{
		Action action = dBZHcEDRaqQXdluUWvQffFUmQOtU__BackingField;
		Action action2;
		do
		{
			action2 = action;
			Action value = (Action)Delegate.Remove(action2, P_0);
			action = Interlocked.CompareExchange(ref dBZHcEDRaqQXdluUWvQffFUmQOtU__BackingField, value, action2);
		}
		while ((object)action != action2);
	}

	internal void OJNEWbVCjzctaktWYaxaXdNJNQAw(Action P_0)
	{
		LxuOBsWDbIOUThryLdVRIkwHMIns(P_0);
	}

	internal void UbDSZCCNZIlirZLOCdhPzZBJpxiQ(Action P_0)
	{
		JZJDCjBaXZjFDVoasRupoZjQFeji(P_0);
	}

	internal void xxHOhxeWWeIvNpXlXFCqMVdJjaPU(Action P_0)
	{
		EztVGZsRYfMUMVLvEQfgUNSRnaPR(P_0);
	}

	internal void lgcDembEotBqTWmPHqGurlJgOhtiA(Action P_0)
	{
		rPiuMLjApegUJCdGkFMnGrUwyrTL(P_0);
	}

	internal InputSource mLNIopHNHCrePmiGorNqaDbovQKH()
	{
		return CANCQeDbIZeOGmwWQddnfxuhtGuHb;
	}

	internal IUnifiedKeyboardSource yrusJnycTryufNRnTDYdTOocFolh()
	{
		return RdODYQjljLuHnrOTUgBTXqhGaVOAA;
	}

	internal IUnifiedMouseSource zbsTkGFlyWYPVbaeiZAucrajmamK()
	{
		return pcQqwZJNPjGTzikLTCXGivFLlhgjA;
	}

	public CustomInputSource(int P_0)
	{
		if (!Enum.IsDefined(typeof(InputSource), P_0))
		{
			Logger.LogError("Unknown InputSource (" + P_0 + ")!");
		}
		CANCQeDbIZeOGmwWQddnfxuhtGuHb = (InputSource)P_0;
		eThzmTtGzfymUeKQqWENhpDZdaru = new List<Joystick>();
		ZqbuKrHtyrQhDPKRAXALymTMfKwV = new ReadOnlyCollection<Joystick>(eThzmTtGzfymUeKQqWENhpDZdaru);
	}

	internal CustomInputSource(int P_0, IUnifiedKeyboardSource P_1, IUnifiedMouseSource P_2)
		: this(P_0)
	{
		RdODYQjljLuHnrOTUgBTXqhGaVOAA = P_1;
		pcQqwZJNPjGTzikLTCXGivFLlhgjA = P_2;
	}

	internal virtual void vLobTBkoHLkWgGTJFbSLORdclPkfc()
	{
		OnInitialize();
	}

	protected virtual void OnInitialize()
	{
	}

	public void AddJoystick(Joystick joystick)
	{
		if (joystick == null)
		{
			return;
		}
		if (eThzmTtGzfymUeKQqWENhpDZdaru.Contains(joystick))
		{
			Logger.LogWarning("The joystick is already in the list. Cannot add again.");
			return;
		}
		eThzmTtGzfymUeKQqWENhpDZdaru.Add(joystick);
		joystick.ConnectedStateChangedEvent += slYPWRyeptodfENZjtxfKJEuYApm;
		if (joystick.isConnected)
		{
			OnJoystickConnected();
		}
	}

	public void RemoveJoystick(Joystick joystick)
	{
		if (joystick == null)
		{
			return;
		}
		if (!eThzmTtGzfymUeKQqWENhpDZdaru.Contains(joystick))
		{
			Logger.LogWarning("The joystick was not found in the list. Cannot remove.");
			return;
		}
		eThzmTtGzfymUeKQqWENhpDZdaru.Remove(joystick);
		joystick.ConnectedStateChangedEvent -= slYPWRyeptodfENZjtxfKJEuYApm;
		if (joystick.isConnected)
		{
			OnJoystickDisconnected();
		}
	}

	public IList<Joystick> GetJoysticks()
	{
		return ZqbuKrHtyrQhDPKRAXALymTMfKwV;
	}

	protected virtual void OnJoystickConnected()
	{
		if (dmSwSjpoRtKJFrCHBcJsCGzEwBxP__BackingField != null)
		{
			dmSwSjpoRtKJFrCHBcJsCGzEwBxP__BackingField();
		}
	}

	protected virtual void OnJoystickDisconnected()
	{
		if (dBZHcEDRaqQXdluUWvQffFUmQOtU__BackingField != null)
		{
			dBZHcEDRaqQXdluUWvQffFUmQOtU__BackingField();
		}
	}

	private void slYPWRyeptodfENZjtxfKJEuYApm(bool P_0)
	{
		if (P_0)
		{
			OnJoystickConnected();
		}
		else
		{
			OnJoystickDisconnected();
		}
	}

	internal Joystick[] auexoLLSFsCquZmtpUTenKRgFIiCA()
	{
		List<Joystick> list = new List<Joystick>(eThzmTtGzfymUeKQqWENhpDZdaru.Count);
		for (int i = 0; i < eThzmTtGzfymUeKQqWENhpDZdaru.Count; i++)
		{
			Joystick joystick = eThzmTtGzfymUeKQqWENhpDZdaru[i];
			if (joystick != null && joystick.isConnected)
			{
				list.Add(joystick);
			}
		}
		return list.ToArray();
	}

	internal virtual void TiyPlhubPjCWsikbKViAwLnzFcUaA()
	{
	}

	public virtual void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	~CustomInputSource()
	{
		Dispose(disposing: false);
	}

	protected virtual void Dispose(bool disposing)
	{
		if (TLUkwogdkRiKBmjljLlQGgbFysQB)
		{
			return;
		}
		if (disposing)
		{
			if (RdODYQjljLuHnrOTUgBTXqhGaVOAA is IDisposable)
			{
				try
				{
					(RdODYQjljLuHnrOTUgBTXqhGaVOAA as IDisposable).Dispose();
				}
				catch (Exception msg)
				{
					Logger.LogError(msg);
				}
			}
			if (pcQqwZJNPjGTzikLTCXGivFLlhgjA is IDisposable)
			{
				try
				{
					(pcQqwZJNPjGTzikLTCXGivFLlhgjA as IDisposable).Dispose();
				}
				catch (Exception msg2)
				{
					Logger.LogError(msg2);
				}
			}
		}
		TLUkwogdkRiKBmjljLlQGgbFysQB = true;
	}

	public abstract void Update();
}
