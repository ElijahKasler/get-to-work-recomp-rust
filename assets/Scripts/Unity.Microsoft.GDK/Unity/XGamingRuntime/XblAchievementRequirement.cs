using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime;

[MovedFrom("Unity.GameCore")]
public class XblAchievementRequirement
{
	public string Id { get; private set; }

	public string CurrentProgressValue { get; private set; }

	public string TargetProgressValue { get; private set; }

	internal XblAchievementRequirement(Unity.XGamingRuntime.Interop.XblAchievementRequirement interopRequirement)
	{
		Id = interopRequirement.id.GetString();
		CurrentProgressValue = interopRequirement.currentProgressValue.GetString();
		TargetProgressValue = interopRequirement.targetProgressValue.GetString();
	}
}
