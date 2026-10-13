using System;
using System.Runtime.InteropServices;
using System.Security;

internal static class ISopwlrhXPuQCOnGHxwbDybLMbMA
{
	public const int dhOGEYuGUxCwbenlWupYynBFykSb = 2048;

	public unsafe static void qQegUKzwEjxnHnQtfWOETfKGBKdn(IntPtr P_0, int P_1, Guid P_2, out IntPtr P_3, jxsGnAKqtDjbPAuybcEYsWEZUDsc P_4)
	{
		cyeRwRQimnlFRCrRuvSCMjHMEFiiA cyeRwRQimnlFRCrRuvSCMjHMEFiiA2;
		fixed (IntPtr* ptr = &P_3)
		{
			void* ptr2 = ptr;
			cyeRwRQimnlFRCrRuvSCMjHMEFiiA2 = cyeRwRQimnlFRCrRuvSCMjHMEFiiA.AagUuoQZvrQoYZGBgiajFTiakGmbb(xdYgbSMyYitutCvnfbHWtpWhATSK((void*)P_0, P_1, &P_2, ptr2, (void*)(P_4?.JlPEPpQhdeKwlZzQOhddIQKPYxtg() ?? IntPtr.Zero)));
		}
		cyeRwRQimnlFRCrRuvSCMjHMEFiiA2.eiACjXTbaXANqerBIPoExvaskTRYA();
	}

	[DllImport("Rewired_DirectInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "DirectInput8_Create")]
	[SuppressUnmanagedCodeSecurity]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int xdYgbSMyYitutCvnfbHWtpWhATSK(void* P_0, int P_1, void* P_2, void* P_3, void* P_4);
}
