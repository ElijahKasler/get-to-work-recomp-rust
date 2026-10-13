using System.Collections.Generic;
using System.ComponentModel;

namespace Rewired.Utils.Classes.Data;

[Browsable(false)]
[EditorBrowsable(EditorBrowsableState.Never)]
public sealed class InspectorListValue<T>
{
	private IList<T> sLspPzNqUMXiDHyyMLGcnsLrufuq;

	private readonly List<T> FVDBfDDTazgfMfDKpHIsjmkFEJLob = new List<T>();

	private bool bGXfewjhifyIdROmJfmOARmPNuVuA;

	public bool isSet => bGXfewjhifyIdROmJfmOARmPNuVuA;

	public IList<T> value
	{
		get
		{
			return sLspPzNqUMXiDHyyMLGcnsLrufuq;
		}
		set
		{
			sLspPzNqUMXiDHyyMLGcnsLrufuq = value;
			bGXfewjhifyIdROmJfmOARmPNuVuA = true;
			FVDBfDDTazgfMfDKpHIsjmkFEJLob.Clear();
			if (sLspPzNqUMXiDHyyMLGcnsLrufuq != null)
			{
				FVDBfDDTazgfMfDKpHIsjmkFEJLob.AddRange(sLspPzNqUMXiDHyyMLGcnsLrufuq);
			}
		}
	}

	public bool SetIfChanged(IList<T> value)
	{
		if (!bGXfewjhifyIdROmJfmOARmPNuVuA)
		{
			this.value = value;
			return false;
		}
		if (sLspPzNqUMXiDHyyMLGcnsLrufuq != value)
		{
			this.value = value;
			return true;
		}
		if (!FZHugcnNkQQSepYchAiISaZcDokF(value, FVDBfDDTazgfMfDKpHIsjmkFEJLob))
		{
			this.value = value;
			return true;
		}
		return false;
	}

	public void Clear()
	{
		bGXfewjhifyIdROmJfmOARmPNuVuA = false;
		sLspPzNqUMXiDHyyMLGcnsLrufuq = null;
		FVDBfDDTazgfMfDKpHIsjmkFEJLob.Clear();
	}

	private static bool FZHugcnNkQQSepYchAiISaZcDokF(IList<T> P_0, IList<T> P_1)
	{
		if (P_0 == P_1)
		{
			return true;
		}
		if (P_0 == null != (P_1 == null))
		{
			return false;
		}
		if (P_0.Count != P_1.Count)
		{
			return false;
		}
		for (int i = 0; i < P_0.Count; i++)
		{
			if (!EqualityComparer<T>.Default.Equals(P_0[i], P_1[i]))
			{
				return false;
			}
		}
		return true;
	}
}
