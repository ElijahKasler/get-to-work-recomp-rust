using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Rewired.Utils.Attributes;
using Rewired.Utils.Classes.Utility;

internal class rjpepHEcPCDRCEiakKxVkrGjBszsB
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	private unsafe delegate int fmnwLBMXjtsCgRAPYAobGOPAzQcHA(void* deviceInstance, IntPtr data);

	private readonly IntPtr bzkdseudThPScfrGLGYWvzcLLSaL;

	private readonly fmnwLBMXjtsCgRAPYAobGOPAzQcHA HJiaaQWOGxeNcdwMAMdocfSBKcWB;

	[CompilerGenerated]
	private List<XdTkrmSnPZqRHLipcnjEiLzLeZek> QxTfjYYvymrguhOkGaxxVNfZfZXI;

	public IntPtr bAcTyXISvucOdNbVMJmXtZxDnTDg => avTdCYAoKffsnipqTfFTEhWjbselc();

	public List<XdTkrmSnPZqRHLipcnjEiLzLeZek> YtdNtOsnjMjUwnZaFOCZiFaqIepbA
	{
		get
		{
			return AHxyoMiDpklMHUmlrFSMGHSGCtyD();
		}
		private set
		{
			KvilIiDIDTnUFMGpDGdlUQftUVRt(list);
		}
	}

	public unsafe rjpepHEcPCDRCEiakKxVkrGjBszsB()
	{
		HJiaaQWOGxeNcdwMAMdocfSBKcWB = jnLtuavhhRbaEkKeIKvvEnPJKWxE;
		bzkdseudThPScfrGLGYWvzcLLSaL = Marshal.GetFunctionPointerForDelegate(HJiaaQWOGxeNcdwMAMdocfSBKcWB);
		KvilIiDIDTnUFMGpDGdlUQftUVRt(new List<XdTkrmSnPZqRHLipcnjEiLzLeZek>());
	}

	public IntPtr avTdCYAoKffsnipqTfFTEhWjbselc()
	{
		return bzkdseudThPScfrGLGYWvzcLLSaL;
	}

	public List<XdTkrmSnPZqRHLipcnjEiLzLeZek> AHxyoMiDpklMHUmlrFSMGHSGCtyD()
	{
		return QxTfjYYvymrguhOkGaxxVNfZfZXI;
	}

	private void KvilIiDIDTnUFMGpDGdlUQftUVRt(List<XdTkrmSnPZqRHLipcnjEiLzLeZek> P_0)
	{
		QxTfjYYvymrguhOkGaxxVNfZfZXI = P_0;
	}

	[MonoPInvokeCallback(typeof(fmnwLBMXjtsCgRAPYAobGOPAzQcHA))]
	private unsafe static int jnLtuavhhRbaEkKeIKvvEnPJKWxE(void* P_0, IntPtr P_1)
	{
		uint instanceId = (uint)P_1.ToInt32();
		if (!ObjectInstanceTracker.Default.TryGetInstance<rjpepHEcPCDRCEiakKxVkrGjBszsB>(instanceId, out var instance))
		{
			return 1;
		}
		XdTkrmSnPZqRHLipcnjEiLzLeZek xdTkrmSnPZqRHLipcnjEiLzLeZek = new XdTkrmSnPZqRHLipcnjEiLzLeZek();
		xdTkrmSnPZqRHLipcnjEiLzLeZek.QdotXuCibZFyCHXDiCbieOOLIZKz(ref *(XdTkrmSnPZqRHLipcnjEiLzLeZek.ijCqWrVapcuaNLhFTMUPYETHffiDA*)P_0);
		instance.AHxyoMiDpklMHUmlrFSMGHSGCtyD().Add(xdTkrmSnPZqRHLipcnjEiLzLeZek);
		return 1;
	}
}
