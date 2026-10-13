using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

internal class RhLZYjZyaIarVnNGpyTXnPaZhfKeA
{
	private readonly List<Delegate> WijpwraSgMSVLWYoUnQOSduptJzQ;

	private readonly IntPtr vJIcKphMmfdWAyrRSjuytVruhIdab;

	public IntPtr CvkkJXmZrmoaiHAsSTIclXKsmQqX => FzkEuqCJgvQOBgepRzhbxNsgFOJFA();

	public RhLZYjZyaIarVnNGpyTXnPaZhfKeA(int P_0)
	{
		vJIcKphMmfdWAyrRSjuytVruhIdab = Marshal.AllocHGlobal(IntPtr.Size * P_0);
		WijpwraSgMSVLWYoUnQOSduptJzQ = new List<Delegate>();
	}

	public IntPtr FzkEuqCJgvQOBgepRzhbxNsgFOJFA()
	{
		return vJIcKphMmfdWAyrRSjuytVruhIdab;
	}

	public unsafe void aMFYvpZonrPfFkjmbkBJlqSBlJIH(Delegate P_0)
	{
		int count = WijpwraSgMSVLWYoUnQOSduptJzQ.Count;
		WijpwraSgMSVLWYoUnQOSduptJzQ.Add(P_0);
		((IntPtr*)(void*)vJIcKphMmfdWAyrRSjuytVruhIdab)[count] = Marshal.GetFunctionPointerForDelegate(P_0);
	}
}
