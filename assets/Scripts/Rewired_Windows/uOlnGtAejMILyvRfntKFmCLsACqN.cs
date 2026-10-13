using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Rewired.Utils.Attributes;
using Rewired.Utils.Classes.Utility;

internal class uOlnGtAejMILyvRfntKFmCLsACqN
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	private unsafe delegate int qDoSStEpXsaADBVGMgGlhPUNhEvn(void* deviceInstance, IntPtr data);

	private readonly IntPtr klWdEPyxiQWCQaAEZDMUfLyeyZBNA;

	private readonly qDoSStEpXsaADBVGMgGlhPUNhEvn nBYqGcDTAdnzCCEtXlkJPeuIGMrA;

	[CompilerGenerated]
	private List<jItGMdftcdRhRCaufAIQvFQKDLfcb> kUTiJzJQkqenPWmWsWRkSQYnjYZv;

	public IntPtr DMxcACefiPmzNphkcEarCOlamKVjB => NNGDXsMWqPgLajZnrAWCjShNTlMIA();

	public List<jItGMdftcdRhRCaufAIQvFQKDLfcb> oFtNiOPeCgkjurhkAXmeyulRJXWl
	{
		get
		{
			return SRxOFhpphrHtoDtSDsmKfzWRfZkc();
		}
		private set
		{
			NWjXBEfdqHFeqcPKqBOfAnnENZzZb(list);
		}
	}

	public unsafe uOlnGtAejMILyvRfntKFmCLsACqN()
	{
		nBYqGcDTAdnzCCEtXlkJPeuIGMrA = XJtwLdHOGQaJslwmxglKfoFFWXrM;
		klWdEPyxiQWCQaAEZDMUfLyeyZBNA = Marshal.GetFunctionPointerForDelegate(nBYqGcDTAdnzCCEtXlkJPeuIGMrA);
		NWjXBEfdqHFeqcPKqBOfAnnENZzZb(new List<jItGMdftcdRhRCaufAIQvFQKDLfcb>());
	}

	public IntPtr NNGDXsMWqPgLajZnrAWCjShNTlMIA()
	{
		return klWdEPyxiQWCQaAEZDMUfLyeyZBNA;
	}

	public List<jItGMdftcdRhRCaufAIQvFQKDLfcb> SRxOFhpphrHtoDtSDsmKfzWRfZkc()
	{
		return kUTiJzJQkqenPWmWsWRkSQYnjYZv;
	}

	private void NWjXBEfdqHFeqcPKqBOfAnnENZzZb(List<jItGMdftcdRhRCaufAIQvFQKDLfcb> P_0)
	{
		kUTiJzJQkqenPWmWsWRkSQYnjYZv = P_0;
	}

	[MonoPInvokeCallback(typeof(qDoSStEpXsaADBVGMgGlhPUNhEvn))]
	private unsafe static int XJtwLdHOGQaJslwmxglKfoFFWXrM(void* P_0, IntPtr P_1)
	{
		uint instanceId = (uint)P_1.ToInt32();
		if (!ObjectInstanceTracker.Default.TryGetInstance<uOlnGtAejMILyvRfntKFmCLsACqN>(instanceId, out var instance))
		{
			return 1;
		}
		jItGMdftcdRhRCaufAIQvFQKDLfcb jItGMdftcdRhRCaufAIQvFQKDLfcb2 = new jItGMdftcdRhRCaufAIQvFQKDLfcb();
		jItGMdftcdRhRCaufAIQvFQKDLfcb2.NrLDdIQbTlTLXBenqljDGoBoDJWR(ref *(jItGMdftcdRhRCaufAIQvFQKDLfcb.JVDaKfEoKfapdqrtYNvQbaHjUChsb*)P_0);
		instance.SRxOFhpphrHtoDtSDsmKfzWRfZkc().Add(jItGMdftcdRhRCaufAIQvFQKDLfcb2);
		return 1;
	}
}
