using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using System.Threading;

internal static class XtQMfhavrBqNtVjPZWWsTKSchQsl
{
	private static Dictionary<IntPtr, List<QmfyCLxqjTNBPaQNgULQEGRQYAss>> zdhMhccyOhEFFMCgzJJBDPjOhscq;

	[ThreadStatic]
	private static Dictionary<IntPtr, List<QmfyCLxqjTNBPaQNgULQEGRQYAss>> bFEYVTQOLVDsjoZyatEFjsjHUVcG;

	private static EventHandler<uGjnJOiMkmDeFkRJBhtPrFubmgnm> fMEEFtlIhzFWvijhrEGdFxBimQVNc__BackingField;

	private static EventHandler<uGjnJOiMkmDeFkRJBhtPrFubmgnm> iOEtUDxceTFQMgpylQvtydKjjYEv__BackingField;

	private static Dictionary<IntPtr, List<QmfyCLxqjTNBPaQNgULQEGRQYAss>> oZvQqayDsdFYidnHOLJFerVHtCPoA => gbtwlquzhvDxswEjqRQuAKIbjWZf();

	public static event EventHandler<uGjnJOiMkmDeFkRJBhtPrFubmgnm> fMEEFtlIhzFWvijhrEGdFxBimQVNc
	{
		add
		{
			WkIbYZfcZMSlptrjlNNNmTJtNgtC(eventHandler);
		}
		remove
		{
			qixyXtiDgGFvluTWmividswflSOS(eventHandler);
		}
	}

	public static event EventHandler<uGjnJOiMkmDeFkRJBhtPrFubmgnm> iOEtUDxceTFQMgpylQvtydKjjYEv
	{
		add
		{
			kVpxWOhDQxleZJqnFlUyvWuAdpyd(eventHandler);
		}
		remove
		{
			qYoedBDJrZwbXrQFLMoNHYJOZunIA(eventHandler);
		}
	}

	public static void WkIbYZfcZMSlptrjlNNNmTJtNgtC(EventHandler<uGjnJOiMkmDeFkRJBhtPrFubmgnm> P_0)
	{
		EventHandler<uGjnJOiMkmDeFkRJBhtPrFubmgnm> eventHandler = fMEEFtlIhzFWvijhrEGdFxBimQVNc__BackingField;
		EventHandler<uGjnJOiMkmDeFkRJBhtPrFubmgnm> eventHandler2;
		do
		{
			eventHandler2 = eventHandler;
			EventHandler<uGjnJOiMkmDeFkRJBhtPrFubmgnm> value = (EventHandler<uGjnJOiMkmDeFkRJBhtPrFubmgnm>)Delegate.Combine(eventHandler2, P_0);
			eventHandler = Interlocked.CompareExchange(ref fMEEFtlIhzFWvijhrEGdFxBimQVNc__BackingField, value, eventHandler2);
		}
		while ((object)eventHandler != eventHandler2);
	}

	public static void qixyXtiDgGFvluTWmividswflSOS(EventHandler<uGjnJOiMkmDeFkRJBhtPrFubmgnm> P_0)
	{
		EventHandler<uGjnJOiMkmDeFkRJBhtPrFubmgnm> eventHandler = fMEEFtlIhzFWvijhrEGdFxBimQVNc__BackingField;
		EventHandler<uGjnJOiMkmDeFkRJBhtPrFubmgnm> eventHandler2;
		do
		{
			eventHandler2 = eventHandler;
			EventHandler<uGjnJOiMkmDeFkRJBhtPrFubmgnm> value = (EventHandler<uGjnJOiMkmDeFkRJBhtPrFubmgnm>)Delegate.Remove(eventHandler2, P_0);
			eventHandler = Interlocked.CompareExchange(ref fMEEFtlIhzFWvijhrEGdFxBimQVNc__BackingField, value, eventHandler2);
		}
		while ((object)eventHandler != eventHandler2);
	}

	public static void kVpxWOhDQxleZJqnFlUyvWuAdpyd(EventHandler<uGjnJOiMkmDeFkRJBhtPrFubmgnm> P_0)
	{
		EventHandler<uGjnJOiMkmDeFkRJBhtPrFubmgnm> eventHandler = iOEtUDxceTFQMgpylQvtydKjjYEv__BackingField;
		EventHandler<uGjnJOiMkmDeFkRJBhtPrFubmgnm> eventHandler2;
		do
		{
			eventHandler2 = eventHandler;
			EventHandler<uGjnJOiMkmDeFkRJBhtPrFubmgnm> value = (EventHandler<uGjnJOiMkmDeFkRJBhtPrFubmgnm>)Delegate.Combine(eventHandler2, P_0);
			eventHandler = Interlocked.CompareExchange(ref iOEtUDxceTFQMgpylQvtydKjjYEv__BackingField, value, eventHandler2);
		}
		while ((object)eventHandler != eventHandler2);
	}

	public static void qYoedBDJrZwbXrQFLMoNHYJOZunIA(EventHandler<uGjnJOiMkmDeFkRJBhtPrFubmgnm> P_0)
	{
		EventHandler<uGjnJOiMkmDeFkRJBhtPrFubmgnm> eventHandler = iOEtUDxceTFQMgpylQvtydKjjYEv__BackingField;
		EventHandler<uGjnJOiMkmDeFkRJBhtPrFubmgnm> eventHandler2;
		do
		{
			eventHandler2 = eventHandler;
			EventHandler<uGjnJOiMkmDeFkRJBhtPrFubmgnm> value = (EventHandler<uGjnJOiMkmDeFkRJBhtPrFubmgnm>)Delegate.Remove(eventHandler2, P_0);
			eventHandler = Interlocked.CompareExchange(ref iOEtUDxceTFQMgpylQvtydKjjYEv__BackingField, value, eventHandler2);
		}
		while ((object)eventHandler != eventHandler2);
	}

	static XtQMfhavrBqNtVjPZWWsTKSchQsl()
	{
		AppDomain.CurrentDomain.DomainUnload += VdpJGFBkvxUzqNlFppRqhKKSSRNQ;
		AppDomain.CurrentDomain.ProcessExit += VdpJGFBkvxUzqNlFppRqhKKSSRNQ;
	}

	private static void VdpJGFBkvxUzqNlFppRqhKKSSRNQ(object P_0, EventArgs P_1)
	{
		if (JACCfJFatUJYPRnNJjnefIgoRSeFb.sChPYkgrUtvceOjVXrfBmPOjtoPJ)
		{
			string value = JqGvnOmwSLNsFtjLAdWiGFMToWlVA();
			if (!string.IsNullOrEmpty(value))
			{
				Console.WriteLine(value);
			}
		}
	}

	private static Dictionary<IntPtr, List<QmfyCLxqjTNBPaQNgULQEGRQYAss>> gbtwlquzhvDxswEjqRQuAKIbjWZf()
	{
		if (JACCfJFatUJYPRnNJjnefIgoRSeFb.NNkaaZETgAFThrfdpJBnRKPnlCHfb)
		{
			if (bFEYVTQOLVDsjoZyatEFjsjHUVcG == null)
			{
				bFEYVTQOLVDsjoZyatEFjsjHUVcG = new Dictionary<IntPtr, List<QmfyCLxqjTNBPaQNgULQEGRQYAss>>(mtwRuGtFpTHoUyxxKnRaxkGEKLUu.TnEBAnhbyUODAHcHJDWRPBWPTVRlB);
			}
			return bFEYVTQOLVDsjoZyatEFjsjHUVcG;
		}
		if (zdhMhccyOhEFFMCgzJJBDPjOhscq == null)
		{
			zdhMhccyOhEFFMCgzJJBDPjOhscq = new Dictionary<IntPtr, List<QmfyCLxqjTNBPaQNgULQEGRQYAss>>(mtwRuGtFpTHoUyxxKnRaxkGEKLUu.TnEBAnhbyUODAHcHJDWRPBWPTVRlB);
		}
		return zdhMhccyOhEFFMCgzJJBDPjOhscq;
	}

	public static void ooGsKMMqIYORJBpegewzZnenJlug(jxsGnAKqtDjbPAuybcEYsWEZUDsc P_0)
	{
		if (P_0 == null || P_0.JlPEPpQhdeKwlZzQOhddIQKPYxtg() == IntPtr.Zero)
		{
			return;
		}
		lock (gbtwlquzhvDxswEjqRQuAKIbjWZf())
		{
			if (!gbtwlquzhvDxswEjqRQuAKIbjWZf().TryGetValue(P_0.JlPEPpQhdeKwlZzQOhddIQKPYxtg(), out var value))
			{
				value = new List<QmfyCLxqjTNBPaQNgULQEGRQYAss>();
				gbtwlquzhvDxswEjqRQuAKIbjWZf().Add(P_0.JlPEPpQhdeKwlZzQOhddIQKPYxtg(), value);
			}
			StringBuilder stringBuilder = new StringBuilder();
			StackFrame[] frames = new StackTrace(3, fNeedFileInfo: true).GetFrames();
			foreach (StackFrame stackFrame in frames)
			{
				if (stackFrame.GetFileLineNumber() != 0)
				{
					stringBuilder.AppendFormat(CultureInfo.InvariantCulture, "\t{0}({1},{2}) : {3}", stackFrame.GetFileName(), stackFrame.GetFileLineNumber(), stackFrame.GetFileColumnNumber(), stackFrame.GetMethod()).AppendLine();
				}
			}
			value.Add(new QmfyCLxqjTNBPaQNgULQEGRQYAss(DateTime.Now, P_0, stringBuilder.ToString()));
			DjGFIOvJWCOwTtMzKhIQJUWbaarg(P_0);
		}
	}

	public static List<QmfyCLxqjTNBPaQNgULQEGRQYAss> aBTOrDOGvvYXZYikMjUQGQhUMYaf(IntPtr P_0)
	{
		lock (gbtwlquzhvDxswEjqRQuAKIbjWZf())
		{
			if (gbtwlquzhvDxswEjqRQuAKIbjWZf().TryGetValue(P_0, out var value))
			{
				return new List<QmfyCLxqjTNBPaQNgULQEGRQYAss>(value);
			}
		}
		return new List<QmfyCLxqjTNBPaQNgULQEGRQYAss>();
	}

	public static QmfyCLxqjTNBPaQNgULQEGRQYAss EqlerPAyyYmirjocsPXpRONGfeyf(jxsGnAKqtDjbPAuybcEYsWEZUDsc P_0)
	{
		lock (gbtwlquzhvDxswEjqRQuAKIbjWZf())
		{
			if (gbtwlquzhvDxswEjqRQuAKIbjWZf().TryGetValue(P_0.JlPEPpQhdeKwlZzQOhddIQKPYxtg(), out var value))
			{
				foreach (QmfyCLxqjTNBPaQNgULQEGRQYAss item in value)
				{
					if (item.MsTdxodzeRuuxjvdFtaZBUlAUsHS().Target == P_0)
					{
						return item;
					}
				}
			}
		}
		return null;
	}

	public static void sqoLfWnmnMBivpJcyNelQAXLMaPg(jxsGnAKqtDjbPAuybcEYsWEZUDsc P_0)
	{
		if (P_0 == null || P_0.JlPEPpQhdeKwlZzQOhddIQKPYxtg() == IntPtr.Zero)
		{
			return;
		}
		lock (gbtwlquzhvDxswEjqRQuAKIbjWZf())
		{
			if (!gbtwlquzhvDxswEjqRQuAKIbjWZf().TryGetValue(P_0.JlPEPpQhdeKwlZzQOhddIQKPYxtg(), out var value))
			{
				return;
			}
			for (int num = value.Count - 1; num >= 0; num--)
			{
				QmfyCLxqjTNBPaQNgULQEGRQYAss qmfyCLxqjTNBPaQNgULQEGRQYAss = value[num];
				if (qmfyCLxqjTNBPaQNgULQEGRQYAss.MsTdxodzeRuuxjvdFtaZBUlAUsHS().Target == P_0)
				{
					value.RemoveAt(num);
				}
				else if (!qmfyCLxqjTNBPaQNgULQEGRQYAss.hXzCQzeQZobXCHDEBjeTawtFwCNfB())
				{
					value.RemoveAt(num);
				}
			}
			if (value.Count == 0)
			{
				gbtwlquzhvDxswEjqRQuAKIbjWZf().Remove(P_0.JlPEPpQhdeKwlZzQOhddIQKPYxtg());
			}
			QOBOnEhugGRzNJTcvIRKBBVFoTkI(P_0);
		}
	}

	public static List<QmfyCLxqjTNBPaQNgULQEGRQYAss> TzioqsnyytnaGVLokzqllIbzkVag()
	{
		List<QmfyCLxqjTNBPaQNgULQEGRQYAss> list = new List<QmfyCLxqjTNBPaQNgULQEGRQYAss>();
		lock (gbtwlquzhvDxswEjqRQuAKIbjWZf())
		{
			foreach (List<QmfyCLxqjTNBPaQNgULQEGRQYAss> value in gbtwlquzhvDxswEjqRQuAKIbjWZf().Values)
			{
				foreach (QmfyCLxqjTNBPaQNgULQEGRQYAss item in value)
				{
					if (item.hXzCQzeQZobXCHDEBjeTawtFwCNfB())
					{
						list.Add(item);
					}
				}
			}
			return list;
		}
	}

	public static string JqGvnOmwSLNsFtjLAdWiGFMToWlVA()
	{
		StringBuilder stringBuilder = new StringBuilder();
		int num = 0;
		Dictionary<string, int> dictionary = new Dictionary<string, int>();
		foreach (QmfyCLxqjTNBPaQNgULQEGRQYAss item in TzioqsnyytnaGVLokzqllIbzkVag())
		{
			string text = item.ToString();
			if (!string.IsNullOrEmpty(text))
			{
				stringBuilder.AppendFormat("[{0}]: {1}", num, text);
				object target = item.MsTdxodzeRuuxjvdFtaZBUlAUsHS().Target;
				if (target != null)
				{
					string name = target.GetType().Name;
					if (!dictionary.TryGetValue(name, out var value))
					{
						dictionary[name] = 0;
					}
					dictionary[name] = value + 1;
				}
			}
			num++;
		}
		List<string> list = new List<string>(dictionary.Keys);
		list.Sort();
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("Count per Type:");
		foreach (string item2 in list)
		{
			stringBuilder.AppendFormat("{0} : {1}", item2, dictionary[item2]);
			stringBuilder.AppendLine();
		}
		return stringBuilder.ToString();
	}

	private static void DjGFIOvJWCOwTtMzKhIQJUWbaarg(jxsGnAKqtDjbPAuybcEYsWEZUDsc P_0)
	{
		fMEEFtlIhzFWvijhrEGdFxBimQVNc__BackingField?.Invoke(null, new uGjnJOiMkmDeFkRJBhtPrFubmgnm(P_0));
	}

	private static void QOBOnEhugGRzNJTcvIRKBBVFoTkI(jxsGnAKqtDjbPAuybcEYsWEZUDsc P_0)
	{
		iOEtUDxceTFQMgpylQvtydKjjYEv__BackingField?.Invoke(null, new uGjnJOiMkmDeFkRJBhtPrFubmgnm(P_0));
	}
}
