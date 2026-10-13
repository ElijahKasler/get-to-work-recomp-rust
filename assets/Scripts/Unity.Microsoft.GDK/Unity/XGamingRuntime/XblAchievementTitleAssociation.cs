using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime;

[MovedFrom("Unity.GameCore")]
public class XblAchievementTitleAssociation
{
	public string Name { get; private set; }

	public uint TitleId { get; private set; }

	internal XblAchievementTitleAssociation(Unity.XGamingRuntime.Interop.XblAchievementTitleAssociation interopTitleAssociation)
	{
		Name = interopTitleAssociation.name.GetString();
		TitleId = interopTitleAssociation.titleId;
	}
}
