using System;
using Rewired;
using Rewired.Utils.Classes.Utility;

internal static class hmRdjlkkAraUbAOZelrfFnsoEfpCB
{
	private const bool tbwLjoZRnUMBpWwyWCRgyDOBsoLK = false;

	private static int SRYuZzbvlGqPSgXPohhOJfbSengg;

	private static ThreadHelper XKlEaSakwxQWwazdKHANGPqUfOPab;

	private static ThreadHelper znJCgoGTJodeKHIAvTRGADVbXdbwb;

	public static int twHagkybsNjhnHHRdJuZnWLiKxMB => HdYjuOcsUBMbxACBttaMRLoAARlu();

	public static ThreadHelper IsBbEgMmmixwnyQiwkDpfcLYsxRJ => RjiBinnoUHaSdqeXdNPUedWVxPJF();

	public static ThreadHelper rmsbMhgmXppVROBLWNOSrrupCvPJA => ybXSdyCOKahPxefGjbCVGxQvFrAAb();

	public static ThreadHelper JzzNJVhPerUBueDJayuiFuzZlpAk => ikUrOmsIKNMiTmyUGnratMoHlLVn();

	public static ThreadHelper MUrcEEisnzFtOjnntSBLToDNbTZBb => kTOPdpvPqgeEoyxeFuEbAOuEacFu();

	public static ThreadHelper wDFDNNtOhRTwHkAYhzrRxeHZHXvi => gyTDgEYeoZoFXSAoxGLxqNHFOSMf();

	public static ThreadHelper lXmxJZjARQcgNXWnusciSTtJNAXn => FOhwJyxNNrDDosccyqMcYsscGuJBA();

	public static bool SHimhTuwnknduxaVuQTACUPhiFmN => CvPbtrNUCJywWTMNsBYrbJwnOrJe();

	public static int HdYjuOcsUBMbxACBttaMRLoAARlu()
	{
		return SRYuZzbvlGqPSgXPohhOJfbSengg;
	}

	public static ThreadHelper RjiBinnoUHaSdqeXdNPUedWVxPJF()
	{
		return XKlEaSakwxQWwazdKHANGPqUfOPab;
	}

	public static ThreadHelper ybXSdyCOKahPxefGjbCVGxQvFrAAb()
	{
		return znJCgoGTJodeKHIAvTRGADVbXdbwb;
	}

	public static ThreadHelper ikUrOmsIKNMiTmyUGnratMoHlLVn()
	{
		return XKlEaSakwxQWwazdKHANGPqUfOPab;
	}

	public static ThreadHelper kTOPdpvPqgeEoyxeFuEbAOuEacFu()
	{
		return znJCgoGTJodeKHIAvTRGADVbXdbwb;
	}

	public static ThreadHelper gyTDgEYeoZoFXSAoxGLxqNHFOSMf()
	{
		return XKlEaSakwxQWwazdKHANGPqUfOPab;
	}

	public static ThreadHelper FOhwJyxNNrDDosccyqMcYsscGuJBA()
	{
		return XKlEaSakwxQWwazdKHANGPqUfOPab;
	}

	public static bool CvPbtrNUCJywWTMNsBYrbJwnOrJe()
	{
		if (XKlEaSakwxQWwazdKHANGPqUfOPab != null)
		{
			return XKlEaSakwxQWwazdKHANGPqUfOPab.isRunning;
		}
		return false;
	}

	public static void yjHGPJbwHWVIZspTmMOUavakCDLK(bool P_0)
	{
		SRYuZzbvlGqPSgXPohhOJfbSengg = ReInput.configVars.GetPlatformVar_joystickRefreshRate();
		if (XKlEaSakwxQWwazdKHANGPqUfOPab != null)
		{
			throw new Exception("Input Thread Manager is already initialized.");
		}
		XKlEaSakwxQWwazdKHANGPqUfOPab = ThreadHelper.CreateFixedTimeStep(SRYuZzbvlGqPSgXPohhOJfbSengg);
		XKlEaSakwxQWwazdKHANGPqUfOPab.Start(wait: true);
		if (P_0)
		{
			znJCgoGTJodeKHIAvTRGADVbXdbwb = ThreadHelper.CreateFixedTimeStep(100);
			znJCgoGTJodeKHIAvTRGADVbXdbwb.Start(wait: true);
		}
		ReInput.UpdateStartedEvent += NOtTBnQTnKDlJknikClQHmhomRz;
	}

	private static void NOtTBnQTnKDlJknikClQHmhomRz(UpdateLoopType P_0)
	{
		if (P_0 == UpdateLoopType.Update)
		{
			int platformVar_joystickRefreshRate = ReInput.configVars.GetPlatformVar_joystickRefreshRate();
			if (SRYuZzbvlGqPSgXPohhOJfbSengg != platformVar_joystickRefreshRate)
			{
				SRYuZzbvlGqPSgXPohhOJfbSengg = platformVar_joystickRefreshRate;
				XKlEaSakwxQWwazdKHANGPqUfOPab.fixedTimeStepFPS = platformVar_joystickRefreshRate;
			}
		}
	}

	public static void KOnwyEovHmoEZalpYSkBCiXsRTpA()
	{
		ReInput.UpdateStartedEvent -= NOtTBnQTnKDlJknikClQHmhomRz;
		if (XKlEaSakwxQWwazdKHANGPqUfOPab != null)
		{
			XKlEaSakwxQWwazdKHANGPqUfOPab.WaitForActionQueueToFinish();
			XKlEaSakwxQWwazdKHANGPqUfOPab.Dispose();
			XKlEaSakwxQWwazdKHANGPqUfOPab = null;
		}
		if (znJCgoGTJodeKHIAvTRGADVbXdbwb != null)
		{
			znJCgoGTJodeKHIAvTRGADVbXdbwb.WaitForActionQueueToFinish();
			znJCgoGTJodeKHIAvTRGADVbXdbwb.Dispose();
			znJCgoGTJodeKHIAvTRGADVbXdbwb = null;
		}
	}
}
