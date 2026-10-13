using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Rewired.Utils.Attributes;
using Rewired.Utils.Classes.Utility;

internal class bUzZKhUHacsGDCqEBHHemZcOeifu
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	private unsafe delegate int kAOBdBaufClKJQBTRWjgkHoomMSxA(void* deviceInstance, IntPtr data);

	private readonly IntPtr xdEhxidHgzjnZfTSdjuZMRqAvFOLA;

	private readonly kAOBdBaufClKJQBTRWjgkHoomMSxA vXFUcjlKEkVJtpRBnoRVirAILEHN;

	[CompilerGenerated]
	private List<qbBcwCKqmnXYLbhYenfqbxSzmmXx> gcGBfrEVZvDDEKNRbGMXXRHClzKU;

	public IntPtr DAxIafyxZbCABdDNWbwJPBBaSUhL => nrWFCARAJpfAtUkiiDiBlghwmDhX();

	public List<qbBcwCKqmnXYLbhYenfqbxSzmmXx> kaqYBxetVBTILllEpSuupLkOUOyp
	{
		get
		{
			return FYjkWLdhDmSxBhvlglZzZCubZBNf();
		}
		private set
		{
			gDQkDCWpTXFNlZFfRCYuyQLwjuOp(list);
		}
	}

	public unsafe bUzZKhUHacsGDCqEBHHemZcOeifu()
	{
		vXFUcjlKEkVJtpRBnoRVirAILEHN = KckzXECEwobrFDZdnfRJBNMptZSvA;
		xdEhxidHgzjnZfTSdjuZMRqAvFOLA = Marshal.GetFunctionPointerForDelegate(vXFUcjlKEkVJtpRBnoRVirAILEHN);
		gDQkDCWpTXFNlZFfRCYuyQLwjuOp(new List<qbBcwCKqmnXYLbhYenfqbxSzmmXx>());
	}

	public IntPtr nrWFCARAJpfAtUkiiDiBlghwmDhX()
	{
		return xdEhxidHgzjnZfTSdjuZMRqAvFOLA;
	}

	public List<qbBcwCKqmnXYLbhYenfqbxSzmmXx> FYjkWLdhDmSxBhvlglZzZCubZBNf()
	{
		return gcGBfrEVZvDDEKNRbGMXXRHClzKU;
	}

	private void gDQkDCWpTXFNlZFfRCYuyQLwjuOp(List<qbBcwCKqmnXYLbhYenfqbxSzmmXx> P_0)
	{
		gcGBfrEVZvDDEKNRbGMXXRHClzKU = P_0;
	}

	[MonoPInvokeCallback(typeof(kAOBdBaufClKJQBTRWjgkHoomMSxA))]
	private unsafe static int KckzXECEwobrFDZdnfRJBNMptZSvA(void* P_0, IntPtr P_1)
	{
		uint instanceId = (uint)P_1.ToInt32();
		if (!ObjectInstanceTracker.Default.TryGetInstance<bUzZKhUHacsGDCqEBHHemZcOeifu>(instanceId, out var instance))
		{
			return 1;
		}
		qbBcwCKqmnXYLbhYenfqbxSzmmXx item = new qbBcwCKqmnXYLbhYenfqbxSzmmXx((IntPtr)P_0);
		instance.FYjkWLdhDmSxBhvlglZzZCubZBNf().Add(item);
		return 1;
	}
}
