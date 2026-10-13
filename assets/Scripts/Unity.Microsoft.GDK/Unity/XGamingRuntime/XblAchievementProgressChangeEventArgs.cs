using Unity.XGamingRuntime.Interop;

namespace Unity.XGamingRuntime;

public class XblAchievementProgressChangeEventArgs
{
	public XblAchievementProgressChangeEntry[] UpdatedAchievementEntries { get; private set; }

	public ulong EntryCount { get; private set; }

	internal XblAchievementProgressChangeEventArgs(Unity.XGamingRuntime.Interop.XblAchievementProgressChangeEventArgs interopEventArgs)
	{
		UpdatedAchievementEntries = InteropHelpers.MarshalArray(interopEventArgs.updatedAchievementEntries, interopEventArgs.entryCount, (Unity.XGamingRuntime.Interop.XblAchievementProgressChangeEntry entriesInterop) => new XblAchievementProgressChangeEntry(entriesInterop));
		EntryCount = interopEventArgs.entryCount;
	}
}
