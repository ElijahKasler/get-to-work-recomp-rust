using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Rewired.Utils.Attributes;
using Rewired.Utils.Classes.Utility;

internal class KypgjXyzKYxawlhuKtHyrsQSeujI
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	private unsafe delegate int LiGtmEHcoHjhvDPGEQZlCfnaIkhic(void* deviceInstance, IntPtr data);

	private readonly IntPtr SFcPZEmSjVqOvPmSZWieasiNxlBJ;

	private readonly LiGtmEHcoHjhvDPGEQZlCfnaIkhic qNifscBJHFuTdrkthkVMERSodiMLA;

	[CompilerGenerated]
	private List<oBkRncnjVlBLGVwpoqxFVzQGbAb> AmuRbClwUDdpDtEZfoDOzxGCQqIr;

	public IntPtr ubbLrHrVcgArFukkJTqhYXHAxxyR => sJZONIyoInuTndFCcUQHRzlFGQob();

	public List<oBkRncnjVlBLGVwpoqxFVzQGbAb> LMNxFlCbATibHXtVrmcChLeCHXyG
	{
		get
		{
			return xaSHObgjnPESLqvtwcfKiHMKZKybB();
		}
		private set
		{
			pZjKBZZdKEuXzzEHGLJPzKfoEKPKA(list);
		}
	}

	public unsafe KypgjXyzKYxawlhuKtHyrsQSeujI()
	{
		qNifscBJHFuTdrkthkVMERSodiMLA = PevgAqtwvlHCtozcWJpyhhpsoEJi;
		SFcPZEmSjVqOvPmSZWieasiNxlBJ = Marshal.GetFunctionPointerForDelegate(qNifscBJHFuTdrkthkVMERSodiMLA);
		pZjKBZZdKEuXzzEHGLJPzKfoEKPKA(new List<oBkRncnjVlBLGVwpoqxFVzQGbAb>());
	}

	public IntPtr sJZONIyoInuTndFCcUQHRzlFGQob()
	{
		return SFcPZEmSjVqOvPmSZWieasiNxlBJ;
	}

	public List<oBkRncnjVlBLGVwpoqxFVzQGbAb> xaSHObgjnPESLqvtwcfKiHMKZKybB()
	{
		return AmuRbClwUDdpDtEZfoDOzxGCQqIr;
	}

	private void pZjKBZZdKEuXzzEHGLJPzKfoEKPKA(List<oBkRncnjVlBLGVwpoqxFVzQGbAb> P_0)
	{
		AmuRbClwUDdpDtEZfoDOzxGCQqIr = P_0;
	}

	[MonoPInvokeCallback(typeof(LiGtmEHcoHjhvDPGEQZlCfnaIkhic))]
	private unsafe static int PevgAqtwvlHCtozcWJpyhhpsoEJi(void* P_0, IntPtr P_1)
	{
		uint instanceId = (uint)P_1.ToInt32();
		if (!ObjectInstanceTracker.Default.TryGetInstance<KypgjXyzKYxawlhuKtHyrsQSeujI>(instanceId, out var instance))
		{
			return 1;
		}
		oBkRncnjVlBLGVwpoqxFVzQGbAb oBkRncnjVlBLGVwpoqxFVzQGbAb2 = new oBkRncnjVlBLGVwpoqxFVzQGbAb();
		oBkRncnjVlBLGVwpoqxFVzQGbAb2.DXzblnGeTBNIKvMHbgBoCAsFQkaEA(ref *(oBkRncnjVlBLGVwpoqxFVzQGbAb.tBzbZzZhgHQMZGDltKuUPHUOjouF*)P_0);
		instance.xaSHObgjnPESLqvtwcfKiHMKZKybB().Add(oBkRncnjVlBLGVwpoqxFVzQGbAb2);
		return 1;
	}
}
