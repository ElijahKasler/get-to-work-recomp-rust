using System;
using System.Collections.Generic;
using UnityEngine;

namespace Rewired.Utils;

[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
[CustomObfuscation(rename = false)]
internal abstract class SafeDelegate : ICloneable
{
	private static Action<Exception> ysMpIJrGcENKhyYPDfygZxQUorYw;

	internal abstract int Count { get; }

	internal abstract Action<Exception> ExceptionHandler { get; set; }

	internal static Action<Exception> S_ExceptionHandler
	{
		get
		{
			return ysMpIJrGcENKhyYPDfygZxQUorYw;
		}
		set
		{
			ysMpIJrGcENKhyYPDfygZxQUorYw = value;
		}
	}

	internal abstract void RemoveDelegateOrAllDelegatesFromAnObject(object obj);

	internal abstract void Clear();

	public abstract object Clone();
}
[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
[CustomObfuscation(rename = false)]
internal abstract class SafeDelegate<T> : SafeDelegate where T : class
{
	private class TQYptdtfnXtOzgsxlMDkGfoSJATc
	{
		public readonly T PUbEQJsmpGUQxUfgJWkkJqUTbVOk;

		public readonly object RjtpTMnuDqMewbssCAMawYdCkYPe;

		public readonly object eeXuWtmqoFjjJjiBVsCvLAxdnETH;

		public readonly bool TkfXHdxWTCBNzozggQMZeRcxxilG;

		public TQYptdtfnXtOzgsxlMDkGfoSJATc(T P_0)
		{
			PUbEQJsmpGUQxUfgJWkkJqUTbVOk = P_0;
			RjtpTMnuDqMewbssCAMawYdCkYPe = ((Delegate)(object)P_0).Target;
			try
			{
				eeXuWtmqoFjjJjiBVsCvLAxdnETH = ReflectionTools.GetMethodInfo((Delegate)(object)P_0);
			}
			catch
			{
				eeXuWtmqoFjjJjiBVsCvLAxdnETH = null;
			}
			TkfXHdxWTCBNzozggQMZeRcxxilG = RjtpTMnuDqMewbssCAMawYdCkYPe != null && RjtpTMnuDqMewbssCAMawYdCkYPe is UnityEngine.Object;
		}

		public TQYptdtfnXtOzgsxlMDkGfoSJATc(TQYptdtfnXtOzgsxlMDkGfoSJATc P_0)
			: this(MiscTools.Clone((object)P_0.PUbEQJsmpGUQxUfgJWkkJqUTbVOk) as T)
		{
		}

		public bool bThiQPpVqBKcZlpgkGJMAidRgxVr()
		{
			if (RjtpTMnuDqMewbssCAMawYdCkYPe != null)
			{
				if (RjtpTMnuDqMewbssCAMawYdCkYPe is UnityEngine.Object)
				{
					return (UnityEngine.Object)RjtpTMnuDqMewbssCAMawYdCkYPe == null;
				}
				return false;
			}
			return true;
		}
	}

	private Action<Exception> CLAMMIIyCqbrDarjpyKxEyqJsQyt;

	private readonly List<TQYptdtfnXtOzgsxlMDkGfoSJATc> vVGWpNECaTEjaMhUMAgMokCMeYXHA;

	private readonly List<TQYptdtfnXtOzgsxlMDkGfoSJATc> xBygpXJeKrpHSMLIWAlBFZeizwXLB;

	int SafeDelegate.Count => get_Count();

	Action<Exception> SafeDelegate.ExceptionHandler
	{
		get
		{
			return get_ExceptionHandler();
		}
		set
		{
			set_ExceptionHandler(value);
		}
	}

	internal virtual int get_Count()
	{
		return vVGWpNECaTEjaMhUMAgMokCMeYXHA.Count;
	}

	internal virtual Action<Exception> get_ExceptionHandler()
	{
		return CLAMMIIyCqbrDarjpyKxEyqJsQyt;
	}

	internal virtual void set_ExceptionHandler(Action<Exception> value)
	{
		CLAMMIIyCqbrDarjpyKxEyqJsQyt = value;
	}

	protected SafeDelegate()
	{
		if (!ReflectionTools.DoesTypeImplement(typeof(T), typeof(Delegate)))
		{
			throw new Exception(typeof(T).Name + " is not a delegate type! SafeDelegate only works with delegate types.");
		}
		vVGWpNECaTEjaMhUMAgMokCMeYXHA = new List<TQYptdtfnXtOzgsxlMDkGfoSJATc>();
		xBygpXJeKrpHSMLIWAlBFZeizwXLB = new List<TQYptdtfnXtOzgsxlMDkGfoSJATc>();
		if (CLAMMIIyCqbrDarjpyKxEyqJsQyt == null)
		{
			CLAMMIIyCqbrDarjpyKxEyqJsQyt = SafeDelegate.S_ExceptionHandler;
		}
	}

	protected SafeDelegate(Action<Exception> P_0)
		: this()
	{
		if (P_0 == null)
		{
			throw new ArgumentNullException("exceptionHandler");
		}
		CLAMMIIyCqbrDarjpyKxEyqJsQyt = P_0;
	}

	protected SafeDelegate(SafeDelegate<T> P_0)
		: this()
	{
		if (P_0 == null)
		{
			throw new ArgumentNullException("source");
		}
		if (P_0.CLAMMIIyCqbrDarjpyKxEyqJsQyt != null)
		{
			CLAMMIIyCqbrDarjpyKxEyqJsQyt = P_0.CLAMMIIyCqbrDarjpyKxEyqJsQyt;
		}
		for (int i = 0; i < P_0.vVGWpNECaTEjaMhUMAgMokCMeYXHA.Count; i++)
		{
			vVGWpNECaTEjaMhUMAgMokCMeYXHA.Add(new TQYptdtfnXtOzgsxlMDkGfoSJATc(P_0.vVGWpNECaTEjaMhUMAgMokCMeYXHA[i]));
		}
	}

	public void AddDelegate(T @delegate)
	{
		if (@delegate == null)
		{
			return;
		}
		List<Delegate> list = PnUhecgtrIyKGYBeBsWCDHhKIewV((Delegate)(object)@delegate);
		if (list == null || list.Count == 0)
		{
			return;
		}
		for (int i = 0; i < list.Count; i++)
		{
			T val = (T)(object)list[i];
			if (!dzKRubKYBHlxuGNTBjxEFlzFQYMl(val))
			{
				vVGWpNECaTEjaMhUMAgMokCMeYXHA.Add(new TQYptdtfnXtOzgsxlMDkGfoSJATc(val));
			}
		}
	}

	public void RemoveDelegate(T @delegate)
	{
		if (@delegate == null)
		{
			return;
		}
		List<Delegate> list = PnUhecgtrIyKGYBeBsWCDHhKIewV((Delegate)(object)@delegate);
		if (list == null || list.Count == 0)
		{
			return;
		}
		int count = vVGWpNECaTEjaMhUMAgMokCMeYXHA.Count;
		for (int i = 0; i < list.Count; i++)
		{
			for (int num = count - 1; num >= 0; num--)
			{
				if (EqualityComparer<T>.Default.Equals(vVGWpNECaTEjaMhUMAgMokCMeYXHA[num].PUbEQJsmpGUQxUfgJWkkJqUTbVOk, (T)(object)list[i]))
				{
					vVGWpNECaTEjaMhUMAgMokCMeYXHA.RemoveAt(num);
				}
			}
		}
	}

	internal override void RemoveDelegateOrAllDelegatesFromAnObject(object obj)
	{
		for (int num = vVGWpNECaTEjaMhUMAgMokCMeYXHA.Count - 1; num >= 0; num--)
		{
			Delegate obj2 = AqKvAnmzBfagwrIkqkeDRvBEElgM(obj, (Delegate)(object)vVGWpNECaTEjaMhUMAgMokCMeYXHA[num].PUbEQJsmpGUQxUfgJWkkJqUTbVOk);
			if (JHYCmyGAxFUIOHrgiqlzDwKhdhoc(obj2) == 0)
			{
				vVGWpNECaTEjaMhUMAgMokCMeYXHA.RemoveAt(num);
			}
			else
			{
				vVGWpNECaTEjaMhUMAgMokCMeYXHA[num] = new TQYptdtfnXtOzgsxlMDkGfoSJATc((T)(object)obj2);
			}
		}
	}

	internal override void Clear()
	{
		vVGWpNECaTEjaMhUMAgMokCMeYXHA.Clear();
	}

	protected void Invoke(Action<object, T> invokeCallback)
	{
		if (invokeCallback == null)
		{
			throw new ArgumentNullException("invokeCallback");
		}
		int count = vVGWpNECaTEjaMhUMAgMokCMeYXHA.Count;
		if (count == 0)
		{
			return;
		}
		xBygpXJeKrpHSMLIWAlBFZeizwXLB.Clear();
		for (int i = 0; i < count; i++)
		{
			xBygpXJeKrpHSMLIWAlBFZeizwXLB.Add(vVGWpNECaTEjaMhUMAgMokCMeYXHA[i]);
		}
		List<int> list = null;
		for (int j = 0; j < count; j++)
		{
			TQYptdtfnXtOzgsxlMDkGfoSJATc tQYptdtfnXtOzgsxlMDkGfoSJATc = xBygpXJeKrpHSMLIWAlBFZeizwXLB[j];
			if (tQYptdtfnXtOzgsxlMDkGfoSJATc.TkfXHdxWTCBNzozggQMZeRcxxilG && tQYptdtfnXtOzgsxlMDkGfoSJATc.bThiQPpVqBKcZlpgkGJMAidRgxVr())
			{
				if (list == null)
				{
					list = TempListPool.Get<int>();
				}
				list.Add(j);
				continue;
			}
			try
			{
				invokeCallback(this, tQYptdtfnXtOzgsxlMDkGfoSJATc.PUbEQJsmpGUQxUfgJWkkJqUTbVOk);
			}
			catch (Exception ex)
			{
				if (CLAMMIIyCqbrDarjpyKxEyqJsQyt != null)
				{
					CLAMMIIyCqbrDarjpyKxEyqJsQyt(ex);
				}
				else if (ex.InnerException != null)
				{
					Logger.LogError(ex.InnerException, requiredThreadSafety: true);
				}
				if (list == null)
				{
					list = TempListPool.Get<int>();
				}
				list.Add(j);
			}
		}
		if (list != null)
		{
			for (int num = list.Count - 1; num >= 0; num--)
			{
				vVGWpNECaTEjaMhUMAgMokCMeYXHA.RemoveAt(list[num]);
			}
			TempListPool.Return(list);
		}
		if (count > 0)
		{
			xBygpXJeKrpHSMLIWAlBFZeizwXLB.Clear();
		}
	}

	protected T GetCombinedDelegate()
	{
		if (vVGWpNECaTEjaMhUMAgMokCMeYXHA == null)
		{
			return null;
		}
		T val = null;
		for (int i = 0; i < vVGWpNECaTEjaMhUMAgMokCMeYXHA.Count; i++)
		{
			T pUbEQJsmpGUQxUfgJWkkJqUTbVOk = vVGWpNECaTEjaMhUMAgMokCMeYXHA[i].PUbEQJsmpGUQxUfgJWkkJqUTbVOk;
			if (val == null)
			{
				val = pUbEQJsmpGUQxUfgJWkkJqUTbVOk;
				continue;
			}
			try
			{
				val = (T)(object)Delegate.Combine((Delegate)(object)val, (Delegate)(object)pUbEQJsmpGUQxUfgJWkkJqUTbVOk);
			}
			catch
			{
			}
		}
		return val;
	}

	private bool dzKRubKYBHlxuGNTBjxEFlzFQYMl(T P_0)
	{
		return eFAGWjeQLCnLHYGXGhoRSlauPiSOA(P_0) >= 0;
	}

	private int eFAGWjeQLCnLHYGXGhoRSlauPiSOA(T P_0)
	{
		int count = vVGWpNECaTEjaMhUMAgMokCMeYXHA.Count;
		for (int i = 0; i < count; i++)
		{
			if (EqualityComparer<T>.Default.Equals(vVGWpNECaTEjaMhUMAgMokCMeYXHA[i].PUbEQJsmpGUQxUfgJWkkJqUTbVOk, P_0))
			{
				return i;
			}
		}
		return -1;
	}

	private static Delegate AqKvAnmzBfagwrIkqkeDRvBEElgM(object P_0, Delegate P_1)
	{
		if ((object)P_1 == null || P_0 == null)
		{
			return P_1;
		}
		if (P_0 is Delegate)
		{
			return FTcEgmHYPyuHcbrBKmXdQZzZuFuR((Delegate)P_0, P_1);
		}
		try
		{
			Delegate[] invocationList = P_1.GetInvocationList();
			for (int i = 0; i < invocationList.Length; i++)
			{
				if (invocationList[i].Target == P_0 || ReflectionTools.GetMethodInfo(invocationList[i]) == P_0)
				{
					if ((object)P_1 == null)
					{
						return P_1;
					}
					P_1 = Delegate.RemoveAll(P_1, invocationList[i]);
				}
			}
		}
		catch (Exception ex)
		{
			Logger.LogError("Exception caught while removing delegates from list (1):\n" + ex);
		}
		return P_1;
	}

	private static Delegate FTcEgmHYPyuHcbrBKmXdQZzZuFuR(Delegate P_0, Delegate P_1)
	{
		if ((object)P_0 == null || (object)P_1 == null)
		{
			return P_1;
		}
		if ((object)P_0.GetType() != P_0.GetType())
		{
			return P_1;
		}
		try
		{
			Delegate[] invocationList = P_0.GetInvocationList();
			Delegate[] invocationList2 = P_1.GetInvocationList();
			for (int i = 0; i < invocationList.Length; i++)
			{
				object methodInfo = ReflectionTools.GetMethodInfo(invocationList[i]);
				foreach (Delegate obj in invocationList2)
				{
					object methodInfo2 = ReflectionTools.GetMethodInfo(obj);
					if (methodInfo == methodInfo2)
					{
						if ((object)P_1 == null)
						{
							return P_1;
						}
						P_1 = Delegate.RemoveAll(P_1, obj);
					}
				}
			}
		}
		catch (Exception ex)
		{
			Logger.LogError("Exception caught while removing delegates from list (2):\n" + ex);
		}
		return P_1;
	}

	private static int JHYCmyGAxFUIOHrgiqlzDwKhdhoc(Delegate P_0)
	{
		if ((object)P_0 == null)
		{
			return 0;
		}
		Delegate[] invocationList = P_0.GetInvocationList();
		if (invocationList == null)
		{
			return 0;
		}
		return invocationList.Length;
	}

	private static List<Delegate> PnUhecgtrIyKGYBeBsWCDHhKIewV(Delegate P_0)
	{
		if ((object)P_0 == null)
		{
			return null;
		}
		Delegate[] invocationList = P_0.GetInvocationList();
		if (invocationList == null)
		{
			return null;
		}
		List<Delegate> list = new List<Delegate>(invocationList.Length);
		for (int i = 0; i < invocationList.Length; i++)
		{
			list.Add(invocationList[i]);
		}
		return list;
	}
}
