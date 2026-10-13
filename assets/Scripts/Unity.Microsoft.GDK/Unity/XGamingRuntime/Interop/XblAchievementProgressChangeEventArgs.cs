using System;

namespace Unity.XGamingRuntime.Interop;

internal struct XblAchievementProgressChangeEventArgs
{
	internal readonly IntPtr updatedAchievementEntries;

	internal readonly uint entryCount;
}
