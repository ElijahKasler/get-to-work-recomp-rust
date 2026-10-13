using System;
using System.Runtime.InteropServices;

internal class sPhwUvvAOXpYZihNQCncKESLZfos : IDisposable
{
	private int bwQKNxHHWCrZeyAExYpgNDVFWNXF;

	private uint vkfeheKzagJuqaBHPVIbGdEQtnFqA;

	private IntPtr WhvHaToNswDJWAChUFaVvLZgOTYvA;

	private bool xAqqikAFDwaToluHBylYtPRVyJGG;

	public sPhwUvvAOXpYZihNQCncKESLZfos(uint P_0)
	{
		if (P_0 == 0)
		{
			throw new Exception("size must be > 0!");
		}
		vkfeheKzagJuqaBHPVIbGdEQtnFqA = P_0;
		bwQKNxHHWCrZeyAExYpgNDVFWNXF = 0;
		try
		{
			WhvHaToNswDJWAChUFaVvLZgOTYvA = Marshal.AllocHGlobal((int)P_0);
			if (WhvHaToNswDJWAChUFaVvLZgOTYvA == IntPtr.Zero)
			{
				throw new Exception("Could not allocate native memory.");
			}
		}
		catch
		{
			throw;
		}
	}

	public unsafe IntPtr zInAWcfXfpNISXMSGqPgdXOcYGTF(uint P_0, void* P_1)
	{
		if (xAqqikAFDwaToluHBylYtPRVyJGG)
		{
			return IntPtr.Zero;
		}
		if (P_0 == 0)
		{
			return IntPtr.Zero;
		}
		if (P_0 > vkfeheKzagJuqaBHPVIbGdEQtnFqA)
		{
			return IntPtr.Zero;
		}
		if (bwQKNxHHWCrZeyAExYpgNDVFWNXF + P_0 >= vkfeheKzagJuqaBHPVIbGdEQtnFqA)
		{
			bwQKNxHHWCrZeyAExYpgNDVFWNXF = 0;
		}
		IntPtr intPtr = new IntPtr(WhvHaToNswDJWAChUFaVvLZgOTYvA.ToInt64() + bwQKNxHHWCrZeyAExYpgNDVFWNXF);
		RhoSDdlPwZIYTHXfVerjMzvHNyu.dWlelPvDnffEDkNcpycixCsIwBxD(intPtr, (IntPtr)P_1, (int)P_0);
		bwQKNxHHWCrZeyAExYpgNDVFWNXF += (int)P_0;
		return intPtr;
	}

	public void Dispose()
	{
		YbpKmtrzcedcrrOuEIUkXBRsvyIT(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	protected virtual void HqhjeduhjQfMSeYHBqKEibkkwNgMA()
	{
		try
		{
			YbpKmtrzcedcrrOuEIUkXBRsvyIT(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	protected virtual void YbpKmtrzcedcrrOuEIUkXBRsvyIT(bool P_0)
	{
		if (!xAqqikAFDwaToluHBylYtPRVyJGG)
		{
			xAqqikAFDwaToluHBylYtPRVyJGG = true;
			if (WhvHaToNswDJWAChUFaVvLZgOTYvA != IntPtr.Zero)
			{
				Marshal.FreeHGlobal(WhvHaToNswDJWAChUFaVvLZgOTYvA);
			}
		}
	}
}
