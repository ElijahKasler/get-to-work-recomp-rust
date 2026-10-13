using System;
using System.Diagnostics;
using UnityEngine;

namespace Isto.Core;

public static class DebugUtils
{
	public static void LogWatch(string message, Stopwatch s)
	{
		TimeSpan elapsed = s.Elapsed;
		string text = $"{elapsed.Hours:00}:{elapsed.Minutes:00}:{elapsed.Seconds:00}.{elapsed.Milliseconds / 10:00}";
		UnityEngine.Debug.LogError(message + ", time=" + text);
	}
}
