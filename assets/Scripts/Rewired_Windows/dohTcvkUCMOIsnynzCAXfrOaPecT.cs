using System;
using System.Runtime.InteropServices;
using System.Security;

internal static class dohTcvkUCMOIsnynzCAXfrOaPecT
{
	public unsafe static int pLafLLAnyEbvmdCbPXWyfkoMKFLu(GTQdVghnWDnIPcrqGRsZNdYFjWhId[] P_0, ref int P_1, int P_2)
	{
		int result;
		fixed (GTQdVghnWDnIPcrqGRsZNdYFjWhId* ptr = P_0)
		{
			void* ptr2 = ptr;
			fixed (int* ptr3 = &P_1)
			{
				void* ptr4 = ptr3;
				result = kpoDGQaEigMMJaaxcNmOwAoSWEFy(ptr2, ptr4, P_2);
			}
		}
		return result;
	}

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetRawInputDeviceList")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int kpoDGQaEigMMJaaxcNmOwAoSWEFy(void* P_0, void* P_1, int P_2);

	public unsafe static int frXXdVrYsYGNmjDnGibebsLBTSBw(MwjQsnvXXYeXiHydklqJjvuEiWfP[] P_0, ref int P_1, int P_2)
	{
		int result;
		fixed (MwjQsnvXXYeXiHydklqJjvuEiWfP* ptr = P_0)
		{
			void* ptr2 = ptr;
			fixed (int* ptr3 = &P_1)
			{
				void* ptr4 = ptr3;
				result = HQBOmkRmkFqsUhAMhdAgBPwTNpGbb(ptr2, ptr4, P_2);
			}
		}
		return result;
	}

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetRegisteredRawInputDevices")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int HQBOmkRmkFqsUhAMhdAgBPwTNpGbb(void* P_0, void* P_1, int P_2);

	public unsafe static int nNAApyHnCCzvbfVknDModMZoFHCc(IntPtr P_0, ukBWgERvbAmjwXLCWGBEAfrNgSzwA P_1, IntPtr P_2, ref int P_3)
	{
		int result;
		fixed (int* ptr = &P_3)
		{
			void* ptr2 = ptr;
			result = NbVJYAEvUITSNyUPzBZxDlhLHswR((void*)P_0, (int)P_1, (void*)P_2, ptr2);
		}
		return result;
	}

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetRawInputDeviceInfoW")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int NbVJYAEvUITSNyUPzBZxDlhLHswR(void* P_0, int P_1, void* P_2, void* P_3);

	public unsafe static yIoBtaChIoindKBwciZemWSmKuZR qapUsQdbZLKsMBKhccjpqHfPHdeC(MwjQsnvXXYeXiHydklqJjvuEiWfP[] P_0, int P_1, int P_2)
	{
		yIoBtaChIoindKBwciZemWSmKuZR result;
		fixed (MwjQsnvXXYeXiHydklqJjvuEiWfP* ptr = P_0)
		{
			void* ptr2 = ptr;
			result = rjSbQdTsWwUsBbYtNjkSnPGliSiB(ptr2, P_1, P_2);
		}
		return result;
	}

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "RegisterRawInputDevices")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern yIoBtaChIoindKBwciZemWSmKuZR rjSbQdTsWwUsBbYtNjkSnPGliSiB(void* P_0, int P_1, int P_2);

	public unsafe static int BsdPKDOBsuNyujKHLCrJjCuemtor(srUGftHhORhBwqHOhsdRhrxIdZTaA[] P_0, ref int P_1, int P_2)
	{
		int result;
		fixed (srUGftHhORhBwqHOhsdRhrxIdZTaA* ptr = P_0)
		{
			void* ptr2 = ptr;
			fixed (int* ptr3 = &P_1)
			{
				void* ptr4 = ptr3;
				result = bkDaLrixWvkKsuFNJcNfdFwcPbErc(ptr2, ptr4, P_2);
			}
		}
		return result;
	}

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetRawInputBuffer")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int bkDaLrixWvkKsuFNJcNfdFwcPbErc(void* P_0, void* P_1, int P_2);

	public unsafe static int ewpUmQslGZoMlMnZqWqpIGFQfwtp(IntPtr P_0, tFiJECdaxuqVggNEuFwxTQoxDqiI P_1, IntPtr P_2, ref int P_3, int P_4)
	{
		int result;
		fixed (int* ptr = &P_3)
		{
			void* ptr2 = ptr;
			result = NoYZiNOitUYujOBlyhhgYKCSkYAA((void*)P_0, (int)P_1, (void*)P_2, ptr2, P_4);
		}
		return result;
	}

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetRawInputData")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int NoYZiNOitUYujOBlyhhgYKCSkYAA(void* P_0, int P_1, void* P_2, void* P_3, int P_4);
}
