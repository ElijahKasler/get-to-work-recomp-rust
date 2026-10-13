using System;

namespace Rewired.Utils;

[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
[CustomObfuscation(rename = false)]
internal sealed class SafeAction : SafeDelegate<Action>
{
	private static Action<object, Action> MBsNUlkrlCGhkBlUtpbsfnibedKv;

	private static Action<object, Action> invokeDelegate => cpLrcogKyWiUFeOwoItNZtDmHwad();

	public SafeAction()
	{
	}

	public SafeAction(Action<Exception> P_0)
		: base(P_0)
	{
	}

	private SafeAction(SafeAction P_0)
		: base((SafeDelegate<Action>)P_0)
	{
	}

	public void Invoke()
	{
		try
		{
			Invoke(cpLrcogKyWiUFeOwoItNZtDmHwad());
		}
		catch (Exception ex)
		{
			Logger.LogError("Error invoking SafeAction base class.\n" + ex);
		}
	}

	public override object Clone()
	{
		return new SafeAction(this);
	}

	private static Action<object, Action> cpLrcogKyWiUFeOwoItNZtDmHwad()
	{
		return eJHUTarmEUbhzvJgaNFwRzvbbAgX;
	}

	private static void eJHUTarmEUbhzvJgaNFwRzvbbAgX(object P_0, Action P_1)
	{
		P_1?.Invoke();
	}

	public static SafeAction operator +(SafeAction eventList, Action listener)
	{
		if (eventList == null)
		{
			eventList = new SafeAction();
		}
		eventList.AddDelegate(listener);
		return eventList;
	}

	public static SafeAction operator -(SafeAction eventList, Action listener)
	{
		if (eventList == null)
		{
			return null;
		}
		eventList.RemoveDelegate(listener);
		return eventList;
	}

	public static implicit operator Action(SafeAction obj)
	{
		return obj?.GetCombinedDelegate();
	}

	public static implicit operator SafeAction(Action obj)
	{
		if (obj == null)
		{
			return null;
		}
		SafeAction safeAction = new SafeAction();
		safeAction.AddDelegate(obj);
		return safeAction;
	}
}
[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
[CustomObfuscation(rename = false)]
internal sealed class SafeAction<T> : SafeDelegate<Action<T>>
{
	private T BGPSBUQVdkpuupDHPAZykeJCPXfg;

	private static Action<object, Action<T>> rirDkvhDYkQEJdhFYFPShxDckmjo;

	private static Action<object, Action<T>> invokeDelegate => qZVRKEyYLTpvJEIxxZFbDMHIRBYS();

	public SafeAction()
	{
	}

	public SafeAction(Action<Exception> P_0)
		: base(P_0)
	{
	}

	protected SafeAction(SafeAction<T> P_0)
		: base((SafeDelegate<Action<T>>)P_0)
	{
	}

	public void Invoke(T arg0)
	{
		BGPSBUQVdkpuupDHPAZykeJCPXfg = arg0;
		try
		{
			Invoke(qZVRKEyYLTpvJEIxxZFbDMHIRBYS());
		}
		catch
		{
			Logger.LogError("Error invoking SafeAction base class.");
		}
		BGPSBUQVdkpuupDHPAZykeJCPXfg = default;
	}

	public override object Clone()
	{
		return new SafeAction<T>(this);
	}

	private static Action<object, Action<T>> qZVRKEyYLTpvJEIxxZFbDMHIRBYS()
	{
		return zXItAZEQbMcduVfbNIkebrfuLEvm;
	}

	private static void zXItAZEQbMcduVfbNIkebrfuLEvm(object P_0, Action<T> P_1)
	{
		if (P_1 != null && P_0 is SafeAction<T> safeAction)
		{
			P_1(safeAction.BGPSBUQVdkpuupDHPAZykeJCPXfg);
		}
	}

	public static SafeAction<T> operator +(SafeAction<T> eventList, Action<T> listener)
	{
		if (eventList == null)
		{
			eventList = new SafeAction<T>();
		}
		eventList.AddDelegate(listener);
		return eventList;
	}

	public static SafeAction<T> operator -(SafeAction<T> eventList, Action<T> listener)
	{
		if (eventList == null)
		{
			return null;
		}
		eventList.RemoveDelegate(listener);
		return eventList;
	}

	public static implicit operator Action<T>(SafeAction<T> obj)
	{
		return obj?.GetCombinedDelegate();
	}

	public static implicit operator SafeAction<T>(Action<T> obj)
	{
		if (obj == null)
		{
			return null;
		}
		SafeAction<T> safeAction = new SafeAction<T>();
		safeAction.AddDelegate(obj);
		return safeAction;
	}
}
[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
[CustomObfuscation(rename = false)]
internal sealed class SafeAction<T, T2> : SafeDelegate<Action<T, T2>>
{
	private T NoCgoBArjtuDGGJUBKlTqMUzeTqR;

	private T2 ejCwsujpndPDFEIuDDdADdsJNOduA;

	private static Action<object, Action<T, T2>> thYOAWeIIgKKOGwDDnzQcoVQNriL;

	private static Action<object, Action<T, T2>> invokeDelegate => ikpUwNwMcEFkzEnOSrHoKmORXjiB();

	public SafeAction()
	{
	}

	public SafeAction(Action<Exception> P_0)
		: base(P_0)
	{
	}

	protected SafeAction(SafeAction<T, T2> P_0)
		: base((SafeDelegate<Action<T, T2>>)P_0)
	{
	}

	public void Invoke(T arg0, T2 arg1)
	{
		NoCgoBArjtuDGGJUBKlTqMUzeTqR = arg0;
		ejCwsujpndPDFEIuDDdADdsJNOduA = arg1;
		try
		{
			Invoke(ikpUwNwMcEFkzEnOSrHoKmORXjiB());
		}
		catch
		{
			Logger.LogError("Error invoking SafeAction base class.");
		}
		NoCgoBArjtuDGGJUBKlTqMUzeTqR = default;
		ejCwsujpndPDFEIuDDdADdsJNOduA = default;
	}

	public override object Clone()
	{
		return new SafeAction<T, T2>(this);
	}

	private static Action<object, Action<T, T2>> ikpUwNwMcEFkzEnOSrHoKmORXjiB()
	{
		return GFoCZpVikHHUqBAuQYuLtVIOdYpk;
	}

	private static void GFoCZpVikHHUqBAuQYuLtVIOdYpk(object P_0, Action<T, T2> P_1)
	{
		if (P_1 != null && P_0 is SafeAction<T, T2> safeAction)
		{
			P_1(safeAction.NoCgoBArjtuDGGJUBKlTqMUzeTqR, safeAction.ejCwsujpndPDFEIuDDdADdsJNOduA);
		}
	}

	public static SafeAction<T, T2> operator +(SafeAction<T, T2> eventList, Action<T, T2> listener)
	{
		if (eventList == null)
		{
			eventList = new SafeAction<T, T2>();
		}
		eventList.AddDelegate(listener);
		return eventList;
	}

	public static SafeAction<T, T2> operator -(SafeAction<T, T2> eventList, Action<T, T2> listener)
	{
		if (eventList == null)
		{
			return null;
		}
		eventList.RemoveDelegate(listener);
		return eventList;
	}

	public static implicit operator Action<T, T2>(SafeAction<T, T2> obj)
	{
		return obj?.GetCombinedDelegate();
	}

	public static implicit operator SafeAction<T, T2>(Action<T, T2> obj)
	{
		if (obj == null)
		{
			return null;
		}
		SafeAction<T, T2> safeAction = new SafeAction<T, T2>();
		safeAction.AddDelegate(obj);
		return safeAction;
	}
}
