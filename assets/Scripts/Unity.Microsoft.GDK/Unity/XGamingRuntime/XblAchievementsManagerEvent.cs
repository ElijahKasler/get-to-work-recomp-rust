using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime;

[MovedFrom("Unity.GameCore")]
public class XblAchievementsManagerEvent
{
	public XblAchievementProgressChangeEntry progressInfo { get; }

	public ulong xboxUserId { get; }

	public XblAchievementsManagerEventType eventType { get; }

	internal XblAchievementsManagerEvent(Unity.XGamingRuntime.Interop.XblAchievementsManagerEvent interopStruct)
	{
		progressInfo = new XblAchievementProgressChangeEntry(interopStruct.progressInfo);
		xboxUserId = interopStruct.xboxUserId;
		eventType = interopStruct.eventType;
	}
}
