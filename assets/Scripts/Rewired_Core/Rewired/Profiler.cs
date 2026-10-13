using System.Diagnostics;
using UnityEngine;

namespace Rewired;

[CustomObfuscation(rename = false)]
[CustomClassObfuscation(renamePubIntMembers = false)]
internal static class Profiler
{
	private const string yCBMIXwmBchRwMHrrMaTAmgkLZEA = "ENABLE_PROFILER must be set in Rewired Core to use the profiler.";

	public static bool enableBinaryLog
	{
		get
		{
			cwvOBlSniBgxCHEqoYcqRgYtfTRA();
			return false;
		}
		set
		{
			cwvOBlSniBgxCHEqoYcqRgYtfTRA();
		}
	}

	public static bool enabled
	{
		get
		{
			cwvOBlSniBgxCHEqoYcqRgYtfTRA();
			return false;
		}
		set
		{
			cwvOBlSniBgxCHEqoYcqRgYtfTRA();
		}
	}

	public static string logFile
	{
		get
		{
			cwvOBlSniBgxCHEqoYcqRgYtfTRA();
			return string.Empty;
		}
		set
		{
			cwvOBlSniBgxCHEqoYcqRgYtfTRA();
		}
	}

	public static bool supported
	{
		get
		{
			cwvOBlSniBgxCHEqoYcqRgYtfTRA();
			return false;
		}
	}

	public static uint usedHeapSize
	{
		get
		{
			cwvOBlSniBgxCHEqoYcqRgYtfTRA();
			return 0u;
		}
	}

	public static long usedHeapSizeLong
	{
		get
		{
			cwvOBlSniBgxCHEqoYcqRgYtfTRA();
			return 0L;
		}
	}

	private static void cwvOBlSniBgxCHEqoYcqRgYtfTRA()
	{
		Logger.Log("ENABLE_PROFILER must be set in Rewired Core to use the profiler.");
	}

	[Conditional("ENABLE_PROFILER")]
	public static void AddFramesFromFile(string file)
	{
		cwvOBlSniBgxCHEqoYcqRgYtfTRA();
	}

	[Conditional("ENABLE_PROFILER")]
	public static void BeginSample(string name)
	{
		cwvOBlSniBgxCHEqoYcqRgYtfTRA();
	}

	[Conditional("ENABLE_PROFILER")]
	public static void BeginSample(string name, Object targetObject)
	{
		cwvOBlSniBgxCHEqoYcqRgYtfTRA();
	}

	[Conditional("ENABLE_PROFILER")]
	public static void EndSample()
	{
		cwvOBlSniBgxCHEqoYcqRgYtfTRA();
	}

	public static uint GetMonoHeapSize()
	{
		cwvOBlSniBgxCHEqoYcqRgYtfTRA();
		return 0u;
	}

	public static long GetMonoHeapSizeLong()
	{
		return 0L;
	}

	public static uint GetMonoUsedSize()
	{
		cwvOBlSniBgxCHEqoYcqRgYtfTRA();
		return 0u;
	}

	public static long GetMonoUsedSizeLong()
	{
		return 0L;
	}

	public static int GetRuntimeMemorySize(Object o)
	{
		cwvOBlSniBgxCHEqoYcqRgYtfTRA();
		return 0;
	}

	public static long GetRuntimeMemorySizeLong(Object o)
	{
		return 0L;
	}

	public static uint GetTotalAllocatedMemory()
	{
		cwvOBlSniBgxCHEqoYcqRgYtfTRA();
		return 0u;
	}

	public static long GetTotalAllocatedMemoryLong()
	{
		return 0L;
	}

	public static uint GetTotalReservedMemory()
	{
		return 0u;
	}

	public static long GetTotalReservedMemoryLong()
	{
		return 0L;
	}

	public static uint GetTotalUnusedReservedMemory()
	{
		return 0u;
	}

	public static long GetTotalUnusedReservedMemoryLong()
	{
		return 0L;
	}
}
