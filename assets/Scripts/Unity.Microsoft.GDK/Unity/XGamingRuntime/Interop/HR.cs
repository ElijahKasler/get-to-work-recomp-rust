namespace Unity.XGamingRuntime.Interop;

public class HR
{
	public const int S_OK = 0;

	public const int E_NOTIMPL = -2147467263;

	public const int E_NOINTERFACE = -2147467262;

	public const int E_POINTER = -2147467261;

	public const int E_ABORT = -2147467260;

	public const int E_ACCESSDENIED = -2147024891;

	public const int E_OUTOFMEMORY = -2147024882;

	public const int E_INVALIDARG = -2147024809;

	public const int E_PENDING = -2147483638;

	public const int E_UNEXPECTED = -2147418113;

	public const int E_NOT_SUPPORTED = -2147024846;

	public const int E_TIME_CRITICAL_THREAD = -2147024480;

	public const int E_NO_TASK_QUEUE = -2147024469;

	public const int E_NOT_SUFFICIENT_BUFFER = -2147024774;

	public const int E_BOUNDS = -2147483637;

	public static bool SUCCEEDED(int hr)
	{
		return hr >= 0;
	}

	public static bool FAILED(int hr)
	{
		return hr < 0;
	}
}
