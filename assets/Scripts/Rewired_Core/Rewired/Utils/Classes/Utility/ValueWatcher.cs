using System;
using System.Collections.Generic;

namespace Rewired.Utils.Classes.Utility;

[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
[CustomObfuscation(rename = false)]
internal abstract class ValueWatcher
{
	public enum TFlwGnKsNnFwjMpHIErSxwucRcGK
	{
		ValueChanged = 0
	}

	public abstract bool changed { get; }

	public abstract bool autoTriggerEvent { get; set; }

	public abstract bool Update();

	public abstract bool Use();

	public abstract bool TriggerEvent();

	public abstract void AddEventListener(TFlwGnKsNnFwjMpHIErSxwucRcGK eventType, Delegate listener);

	public abstract void RemoveEventListener(TFlwGnKsNnFwjMpHIErSxwucRcGK eventType, Delegate listener);
}
[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
[CustomObfuscation(rename = false)]
internal sealed class ValueWatcher<T> : ValueWatcher
{
	private static IEqualityComparer<T> cHEHeHERVbbrOsvBVsmiXmyPPDqT = EqualityComparerNoAlloc<T>.Default;

	private bool oRuUxlQTIKnuMalraVlYVdwrpMjc;

	private T wQULQeZbmcquNBycIcxWqqbMKfeJ;

	private bool izFDYjDTOfIZTwYDzbgZSUddJKhU;

	private Func<T> xrPENMimsGxKWFeYwLdTiJygvQRXA;

	private Action<T> rURYFzdPHAWaayispFjLcUPFIhmG;

	bool ValueWatcher.changed => get_changed();

	bool ValueWatcher.autoTriggerEvent
	{
		get
		{
			return get_autoTriggerEvent();
		}
		set
		{
			set_autoTriggerEvent(value);
		}
	}

	public Func<T> getValueDelegate
	{
		get
		{
			return xrPENMimsGxKWFeYwLdTiJygvQRXA;
		}
		set
		{
			xrPENMimsGxKWFeYwLdTiJygvQRXA = value;
		}
	}

	public T value => wQULQeZbmcquNBycIcxWqqbMKfeJ;

	public event Action<T> ChangedEvent
	{
		add
		{
			rURYFzdPHAWaayispFjLcUPFIhmG = (Action<T>)Delegate.Combine(rURYFzdPHAWaayispFjLcUPFIhmG, value);
		}
		remove
		{
			rURYFzdPHAWaayispFjLcUPFIhmG = (Action<T>)Delegate.Remove(rURYFzdPHAWaayispFjLcUPFIhmG, value);
		}
	}

	public bool get_changed()
	{
		return oRuUxlQTIKnuMalraVlYVdwrpMjc;
	}

	public bool get_autoTriggerEvent()
	{
		return izFDYjDTOfIZTwYDzbgZSUddJKhU;
	}

	public void set_autoTriggerEvent(bool value)
	{
		izFDYjDTOfIZTwYDzbgZSUddJKhU = value;
	}

	public ValueWatcher(T P_0, bool P_1)
	{
		wQULQeZbmcquNBycIcxWqqbMKfeJ = P_0;
		izFDYjDTOfIZTwYDzbgZSUddJKhU = P_1;
	}

	public ValueWatcher(T P_0, Func<T> P_1, bool P_2)
		: this(P_0, P_2)
	{
		xrPENMimsGxKWFeYwLdTiJygvQRXA = P_1;
	}

	public override bool Update()
	{
		if (xrPENMimsGxKWFeYwLdTiJygvQRXA == null)
		{
			return false;
		}
		try
		{
			return Set(xrPENMimsGxKWFeYwLdTiJygvQRXA());
		}
		catch (Exception ex)
		{
			Logger.LogError("An exception was thrown by getValueDelegate.\n" + ex);
			return false;
		}
	}

	public override bool Use()
	{
		if (!oRuUxlQTIKnuMalraVlYVdwrpMjc)
		{
			return false;
		}
		oRuUxlQTIKnuMalraVlYVdwrpMjc = false;
		return true;
	}

	public override bool TriggerEvent()
	{
		if (!oRuUxlQTIKnuMalraVlYVdwrpMjc)
		{
			return false;
		}
		if (rURYFzdPHAWaayispFjLcUPFIhmG == null)
		{
			return true;
		}
		try
		{
			Use();
			rURYFzdPHAWaayispFjLcUPFIhmG(wQULQeZbmcquNBycIcxWqqbMKfeJ);
			return true;
		}
		catch (Exception ex)
		{
			Logger.LogError("An exception was thrown by ValueChangedEvent handler.\n" + ex);
			return false;
		}
	}

	public bool Set(T value)
	{
		if (cHEHeHERVbbrOsvBVsmiXmyPPDqT.Equals(wQULQeZbmcquNBycIcxWqqbMKfeJ, value))
		{
			return false;
		}
		wQULQeZbmcquNBycIcxWqqbMKfeJ = value;
		oRuUxlQTIKnuMalraVlYVdwrpMjc = true;
		if (izFDYjDTOfIZTwYDzbgZSUddJKhU)
		{
			TriggerEvent();
		}
		return true;
	}

	public override void AddEventListener(TFlwGnKsNnFwjMpHIErSxwucRcGK eventType, Delegate listener)
	{
		if (eventType == TFlwGnKsNnFwjMpHIErSxwucRcGK.ValueChanged)
		{
			if (!(listener is Action<T>))
			{
				throw new ArgumentException("listener must be of type Action<" + typeof(T).Name + ">");
			}
			ChangedEvent += (Action<T>)listener;
			return;
		}
		throw new NotImplementedException();
	}

	public override void RemoveEventListener(TFlwGnKsNnFwjMpHIErSxwucRcGK eventType, Delegate listener)
	{
		if (eventType == TFlwGnKsNnFwjMpHIErSxwucRcGK.ValueChanged)
		{
			if (!(listener is Action<T>))
			{
				throw new ArgumentException("listener must be of type Action<" + typeof(T).Name + ">");
			}
			ChangedEvent -= (Action<T>)listener;
			return;
		}
		throw new NotImplementedException();
	}
}
