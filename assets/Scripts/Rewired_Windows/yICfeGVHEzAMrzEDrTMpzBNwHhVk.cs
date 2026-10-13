using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Rewired.Utils.Attributes;
using Rewired.Utils.Classes.Utility;

internal class yICfeGVHEzAMrzEDrTMpzBNwHhVk
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	private unsafe delegate int PbbQIVClEoioHYNbvfOMuGUjyWVq(void* deviceInstance, IntPtr data);

	private readonly IntPtr JeoftKknzhhDBHirQaCUIJyGSShjA;

	private readonly PbbQIVClEoioHYNbvfOMuGUjyWVq XWuKOszsWxjNioBmLEtYJJluFjuL;

	[CompilerGenerated]
	private List<cQBxMAHukbVUZQupSRBOiSlaiust> eaDBZfPXOPjeeiCjIfueaGDkGakcc;

	public IntPtr sXfSjuwvHqWXAOcJmRhwofmWFzqg => yTSvScsEOCbQEIqRXttyuifAFbhcA();

	public List<cQBxMAHukbVUZQupSRBOiSlaiust> SjktABjbvzVfkNemRduASaSdtoHw
	{
		get
		{
			return WQWDndYNEFFCEknaoOmkkLwRXkSAA();
		}
		private set
		{
			EXGhOcDyWujoCmpUDhOHdndKykIo(list);
		}
	}

	public unsafe yICfeGVHEzAMrzEDrTMpzBNwHhVk()
	{
		XWuKOszsWxjNioBmLEtYJJluFjuL = fOpZRUwoREaNmQfWzODQgAoAPNtQ;
		JeoftKknzhhDBHirQaCUIJyGSShjA = Marshal.GetFunctionPointerForDelegate(XWuKOszsWxjNioBmLEtYJJluFjuL);
		EXGhOcDyWujoCmpUDhOHdndKykIo(new List<cQBxMAHukbVUZQupSRBOiSlaiust>());
	}

	public IntPtr yTSvScsEOCbQEIqRXttyuifAFbhcA()
	{
		return JeoftKknzhhDBHirQaCUIJyGSShjA;
	}

	public List<cQBxMAHukbVUZQupSRBOiSlaiust> WQWDndYNEFFCEknaoOmkkLwRXkSAA()
	{
		return eaDBZfPXOPjeeiCjIfueaGDkGakcc;
	}

	private void EXGhOcDyWujoCmpUDhOHdndKykIo(List<cQBxMAHukbVUZQupSRBOiSlaiust> P_0)
	{
		eaDBZfPXOPjeeiCjIfueaGDkGakcc = P_0;
	}

	[MonoPInvokeCallback(typeof(PbbQIVClEoioHYNbvfOMuGUjyWVq))]
	private unsafe static int fOpZRUwoREaNmQfWzODQgAoAPNtQ(void* P_0, IntPtr P_1)
	{
		uint instanceId = (uint)P_1.ToInt32();
		if (!ObjectInstanceTracker.Default.TryGetInstance<yICfeGVHEzAMrzEDrTMpzBNwHhVk>(instanceId, out var instance))
		{
			return 1;
		}
		cQBxMAHukbVUZQupSRBOiSlaiust cQBxMAHukbVUZQupSRBOiSlaiust2 = new cQBxMAHukbVUZQupSRBOiSlaiust();
		cQBxMAHukbVUZQupSRBOiSlaiust2.oXinphXqVEXQOBKPZvpKSqEiwIie(ref *(cQBxMAHukbVUZQupSRBOiSlaiust.fsvopWPdeEvqeNbiQhjWRQDrPWPh*)P_0);
		instance.WQWDndYNEFFCEknaoOmkkLwRXkSAA().Add(cQBxMAHukbVUZQupSRBOiSlaiust2);
		return 1;
	}
}
