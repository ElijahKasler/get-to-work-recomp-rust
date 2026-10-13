using System;
using System.Runtime.InteropServices;

internal class igucSXubXtUqWrGtOoZTeYGciMHO : IDisposable
{
	internal enum UZPsaoGOvYSuwUmgolZzqvmxvNNw
	{
		Current = 0,
		All = 1
	}

	private delegate IntPtr JZpvYIsRGalLwfRGlTEEEAtiDYCv(int nCode, IntPtr wParam, IntPtr lParam);

	private const int tNHdjTFkrcOIcwIvyQOfFiaRwdil = 4;

	private IntPtr AKjdlmlcrVjwJzJJhJKNZcOSeFYt = IntPtr.Zero;

	private JZpvYIsRGalLwfRGlTEEEAtiDYCv jKSWkeyeoMsUUOpPknxJahVCkjnB;

	private Action<IntPtr, IntPtr, uint, uint> NyYtoLDEtgxVDvjMjopMDBEkTkHC;

	private bool XOAyhGrloZNlHfNVwxVIkojZjshp;

	public void DCMEHgfVQXMxpgSIFUeDpouEHUVCB(Action<IntPtr, IntPtr, uint, uint> P_0, UZPsaoGOvYSuwUmgolZzqvmxvNNw P_1)
	{
		NyYtoLDEtgxVDvjMjopMDBEkTkHC = P_0;
		jKSWkeyeoMsUUOpPknxJahVCkjnB = qdhVMSqrmzMrXLjtWadrhloBhTye;
		uint num = 0u;
		if (P_1 == UZPsaoGOvYSuwUmgolZzqvmxvNNw.Current)
		{
			num = (uint)AppDomain.GetCurrentThreadId();
		}
		AKjdlmlcrVjwJzJJhJKNZcOSeFYt = JFvvJJpbNbgzNQbddPDnRaVRQQcV(4, jKSWkeyeoMsUUOpPknxJahVCkjnB, IntPtr.Zero, num);
		_ = AKjdlmlcrVjwJzJJhJKNZcOSeFYt == IntPtr.Zero;
	}

	public void PvyUfnXkKrvAefAXNFroOHMUfRHGA()
	{
		if (!(AKjdlmlcrVjwJzJJhJKNZcOSeFYt == IntPtr.Zero) && kAjdZzFOFGFcgRCtAGPxqhMBNsIZA(AKjdlmlcrVjwJzJJhJKNZcOSeFYt))
		{
			AKjdlmlcrVjwJzJJhJKNZcOSeFYt = IntPtr.Zero;
		}
	}

	private IntPtr qdhVMSqrmzMrXLjtWadrhloBhTye(int P_0, IntPtr P_1, IntPtr P_2)
	{
		if (P_0 >= 0)
		{
			int num = 0;
			IntPtr arg = Marshal.ReadIntPtr(P_2, num);
			num += IntPtr.Size;
			IntPtr arg2 = Marshal.ReadIntPtr(P_2, num);
			num += IntPtr.Size;
			uint arg3 = (uint)Marshal.ReadInt32(P_2, num);
			num += 4;
			if (IntPtr.Size == 8)
			{
				num += 4;
			}
			uint arg4 = (uint)Marshal.ReadInt32(P_2, num);
			NyYtoLDEtgxVDvjMjopMDBEkTkHC(arg, arg2, arg3, arg4);
		}
		return wtNELBIIvKQOAJkthJhLmXRmyrhnA(AKjdlmlcrVjwJzJJhJKNZcOSeFYt, P_0, P_1, P_2);
	}

	public void Dispose()
	{
		ScjOmrEpRugJNkgIPOJUdhHXMGol(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	protected virtual void rNZLgCyoUplnrgBeGjzzKnurYaWA()
	{
		try
		{
			ScjOmrEpRugJNkgIPOJUdhHXMGol(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	protected virtual void ScjOmrEpRugJNkgIPOJUdhHXMGol(bool P_0)
	{
		if (!XOAyhGrloZNlHfNVwxVIkojZjshp)
		{
			PvyUfnXkKrvAefAXNFroOHMUfRHGA();
			XOAyhGrloZNlHfNVwxVIkojZjshp = true;
		}
	}

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "SetWindowsHookEx")]
	private static extern IntPtr JFvvJJpbNbgzNQbddPDnRaVRQQcV(int P_0, JZpvYIsRGalLwfRGlTEEEAtiDYCv P_1, IntPtr P_2, uint P_3);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "UnhookWindowsHookEx")]
	private static extern bool kAjdZzFOFGFcgRCtAGPxqhMBNsIZA(IntPtr P_0);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "CallNextHookEx")]
	private static extern IntPtr wtNELBIIvKQOAJkthJhLmXRmyrhnA(IntPtr P_0, int P_1, IntPtr P_2, IntPtr P_3);
}
