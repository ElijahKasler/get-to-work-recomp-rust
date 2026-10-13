using System;
using Rewired.Platforms.Custom;

internal static class DYXEicTUvpxnVFlTbwIfiujTNpTs
{
	private static CustomPlatformInitOptions UxwCOyJsfkjgBGZMRbaMeWacggMhA;

	public static int mJtuQnpqandChBUOvvkOJwQJfHjhA => XSbLyONHNwqeYxvuTBVWMKHSndSv();

	public static bool qyTslcRaSJqwIpeKAPzLVCkzVntn => ZCGrnntEgTOKZdITtdptDPSiYsuz();

	public static int XSbLyONHNwqeYxvuTBVWMKHSndSv()
	{
		if (UxwCOyJsfkjgBGZMRbaMeWacggMhA == null)
		{
			return -1;
		}
		return UxwCOyJsfkjgBGZMRbaMeWacggMhA.platformId;
	}

	public static bool ZCGrnntEgTOKZdITtdptDPSiYsuz()
	{
		return XSbLyONHNwqeYxvuTBVWMKHSndSv() != -1;
	}

	public static void YJFbOEoruEbekiwzNrSDeDOguozlA(CustomPlatformInitOptions P_0)
	{
		if (P_0 == null)
		{
			throw new ArgumentNullException("options");
		}
		if (ZCGrnntEgTOKZdITtdptDPSiYsuz())
		{
			throw new Exception("Already initialized");
		}
		QFzkZxVZKBlidPLPPhCreLgRkxmM(P_0);
		UxwCOyJsfkjgBGZMRbaMeWacggMhA = P_0;
	}

	public static void XTaFmbCBLnnqwnehfQHABeOCIlFFb()
	{
		UxwCOyJsfkjgBGZMRbaMeWacggMhA = null;
	}

	internal static int fKvDhJhbjCiZyDdoAEAWhBLJTAhQc()
	{
		if (UxwCOyJsfkjgBGZMRbaMeWacggMhA == null)
		{
			return -1;
		}
		return UxwCOyJsfkjgBGZMRbaMeWacggMhA.platformId;
	}

	internal static string tIRBAzhSdLNekUgHfQQffxwfWBLY()
	{
		if (UxwCOyJsfkjgBGZMRbaMeWacggMhA == null)
		{
			return null;
		}
		return UxwCOyJsfkjgBGZMRbaMeWacggMhA.platformIdentifierString;
	}

	internal static IHardwareJoystickMapCustomPlatformMapProvider YDIrRsFjIHjnZjDZXkaWvaZcvrth()
	{
		if (UxwCOyJsfkjgBGZMRbaMeWacggMhA == null)
		{
			return null;
		}
		return UxwCOyJsfkjgBGZMRbaMeWacggMhA.hardwareJoystickMapCustomPlatformMapProvider;
	}

	internal static CustomInputSource ectXnsdbCBpTYMmJvRmxynhQNLbY()
	{
		if (UxwCOyJsfkjgBGZMRbaMeWacggMhA == null)
		{
			return null;
		}
		return UxwCOyJsfkjgBGZMRbaMeWacggMhA.inputSource;
	}

	internal static CustomPlatformConfigVars VgdWdClyHBexvPanNPmQrspvtFRg()
	{
		if (UxwCOyJsfkjgBGZMRbaMeWacggMhA == null)
		{
			return null;
		}
		return UxwCOyJsfkjgBGZMRbaMeWacggMhA.configVars;
	}

	private static void QFzkZxVZKBlidPLPPhCreLgRkxmM(CustomPlatformInitOptions P_0)
	{
		if (P_0.platformId == -1)
		{
			throw new Exception("customPlatformId is invalid.");
		}
		if (string.IsNullOrEmpty(P_0.platformIdentifierString))
		{
			throw new Exception("platformIdentifierString is invalid.");
		}
		if (P_0.inputSource == null)
		{
			throw new Exception("inputSource cannot be null.");
		}
		if (P_0.hardwareJoystickMapCustomPlatformMapProvider == null)
		{
			throw new Exception("hardwareJoystickMapCustomPlatformMapProvider cannot be null.");
		}
	}
}
