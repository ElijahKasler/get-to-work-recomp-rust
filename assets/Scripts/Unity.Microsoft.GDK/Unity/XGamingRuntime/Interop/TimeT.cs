using System;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime.Interop;

[MovedFrom("Unity.GameCore.Interop")]
public struct TimeT
{
	private static DateTime UnixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

	internal readonly long SecondsSinceUnixEpoch;

	public DateTime DateTime
	{
		get
		{
			try
			{
				if (SecondsSinceUnixEpoch == -1)
				{
					return DateTime.MaxValue;
				}
				return UnixEpoch.AddSeconds(SecondsSinceUnixEpoch);
			}
			catch (ArgumentOutOfRangeException)
			{
				return DateTime.MaxValue;
			}
		}
	}

	internal TimeT(long secondsSinceUnixEpoch)
	{
		SecondsSinceUnixEpoch = secondsSinceUnixEpoch;
	}

	public TimeT(DateTime dateTime)
	{
		if (dateTime.Kind != DateTimeKind.Utc)
		{
			throw new ArgumentException("Supplied DateTime must be UTC");
		}
		SecondsSinceUnixEpoch = (long)dateTime.Subtract(UnixEpoch).TotalSeconds;
	}
}
