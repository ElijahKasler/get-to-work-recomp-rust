using System;
using System.Collections.Generic;
using Rewired.Config;
using Rewired.Utils;

namespace Rewired;

[CustomObfuscation(rename = false)]
[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
internal class UpdateLoopDataSet<T> where T : class
{
	private class bzaAuyAjWfirDixdxfZXGCjibRKVb
	{
		public readonly UpdateLoopType KObcKyrgENmanXaEZxHLMZVGcRje;

		public T fpXJXLOYyaCtjOSEJrfOaOaWFITl;

		public bzaAuyAjWfirDixdxfZXGCjibRKVb(UpdateLoopType P_0)
		{
			KObcKyrgENmanXaEZxHLMZVGcRje = P_0;
		}
	}

	private const int QhPUZRXKgxJhSMEPKQHvSeeWgYHF = 0;

	private bzaAuyAjWfirDixdxfZXGCjibRKVb yCgPBqTawZTNfXFNnGqiIWVAToVh;

	private int gUZTqvRVjygasqTaSsKpMKMLnCKG;

	public readonly int fixedUpdateSetIndex = -1;

	private readonly int[] hAXtZsYRQKHGMoYBxAMRulckmlCi;

	private readonly bzaAuyAjWfirDixdxfZXGCjibRKVb[] iLTYpXQKfmerKXDkYShfvfytGzWM;

	private UpdateLoopType YYSIXBRJBoZVDBdEVRbyCFnqQwh = (UpdateLoopType)(-1);

	public T Current => yCgPBqTawZTNfXFNnGqiIWVAToVh.fpXJXLOYyaCtjOSEJrfOaOaWFITl;

	public int Count => gUZTqvRVjygasqTaSsKpMKMLnCKG;

	public T this[int index]
	{
		get
		{
			if (index < 0 || index >= gUZTqvRVjygasqTaSsKpMKMLnCKG)
			{
				throw new IndexOutOfRangeException();
			}
			return iLTYpXQKfmerKXDkYShfvfytGzWM[index].fpXJXLOYyaCtjOSEJrfOaOaWFITl;
		}
		set
		{
			if (index < 0 || index >= gUZTqvRVjygasqTaSsKpMKMLnCKG)
			{
				throw new IndexOutOfRangeException();
			}
			iLTYpXQKfmerKXDkYShfvfytGzWM[index].fpXJXLOYyaCtjOSEJrfOaOaWFITl = value;
		}
	}

	public UpdateLoopDataSet(UpdateLoopSetting P_0)
		: this(P_0, (Func<T>)null)
	{
	}

	public UpdateLoopDataSet(UpdateLoopSetting P_0, Func<T> P_1)
	{
		hAXtZsYRQKHGMoYBxAMRulckmlCi = new int[3];
		ArrayTools.Fill(hAXtZsYRQKHGMoYBxAMRulckmlCi, -1);
		List<bzaAuyAjWfirDixdxfZXGCjibRKVb> list = new List<bzaAuyAjWfirDixdxfZXGCjibRKVb>();
		int num = 0;
		using (TempListPool.TList<UpdateLoopType> tList = TempListPool.GetTList<UpdateLoopType>(3))
		{
			List<UpdateLoopType> list2 = tList.list;
			EnumConverter.ToUpdateLoopTypes(P_0, list2);
			for (int i = 0; i < list2.Count; i++)
			{
				bzaAuyAjWfirDixdxfZXGCjibRKVb bzaAuyAjWfirDixdxfZXGCjibRKVb2 = new bzaAuyAjWfirDixdxfZXGCjibRKVb(list2[i]);
				if (P_1 != null)
				{
					T fpXJXLOYyaCtjOSEJrfOaOaWFITl = P_1();
					bzaAuyAjWfirDixdxfZXGCjibRKVb2.fpXJXLOYyaCtjOSEJrfOaOaWFITl = fpXJXLOYyaCtjOSEJrfOaOaWFITl;
				}
				list.Add(bzaAuyAjWfirDixdxfZXGCjibRKVb2);
				hAXtZsYRQKHGMoYBxAMRulckmlCi[(int)list2[i]] = num;
				if (list2[i] == UpdateLoopType.FixedUpdate)
				{
					fixedUpdateSetIndex = num;
				}
				num++;
			}
		}
		iLTYpXQKfmerKXDkYShfvfytGzWM = list.ToArray();
		gUZTqvRVjygasqTaSsKpMKMLnCKG = iLTYpXQKfmerKXDkYShfvfytGzWM.Length;
		SetUpdateLoop(iLTYpXQKfmerKXDkYShfvfytGzWM[0].KObcKyrgENmanXaEZxHLMZVGcRje);
	}

	public void SetUpdateLoop(UpdateLoopType updateLoop)
	{
		if (YYSIXBRJBoZVDBdEVRbyCFnqQwh != updateLoop)
		{
			YYSIXBRJBoZVDBdEVRbyCFnqQwh = updateLoop;
			yCgPBqTawZTNfXFNnGqiIWVAToVh = iLTYpXQKfmerKXDkYShfvfytGzWM[hAXtZsYRQKHGMoYBxAMRulckmlCi[(int)updateLoop]];
		}
	}

	public T Get(int index)
	{
		if (index < 0 || index >= gUZTqvRVjygasqTaSsKpMKMLnCKG)
		{
			throw new IndexOutOfRangeException();
		}
		return iLTYpXQKfmerKXDkYShfvfytGzWM[index].fpXJXLOYyaCtjOSEJrfOaOaWFITl;
	}

	public T Get(UpdateLoopType updateLoop)
	{
		return iLTYpXQKfmerKXDkYShfvfytGzWM[hAXtZsYRQKHGMoYBxAMRulckmlCi[(int)updateLoop]].fpXJXLOYyaCtjOSEJrfOaOaWFITl;
	}

	public void Set(int index, T item)
	{
		if (index < 0 || index >= gUZTqvRVjygasqTaSsKpMKMLnCKG)
		{
			throw new IndexOutOfRangeException();
		}
		iLTYpXQKfmerKXDkYShfvfytGzWM[index].fpXJXLOYyaCtjOSEJrfOaOaWFITl = item;
	}

	public UpdateLoopType GetUpdateLoopType(int index)
	{
		if (index < 0 || index >= gUZTqvRVjygasqTaSsKpMKMLnCKG)
		{
			throw new ArgumentOutOfRangeException("index");
		}
		return iLTYpXQKfmerKXDkYShfvfytGzWM[index].KObcKyrgENmanXaEZxHLMZVGcRje;
	}
}
