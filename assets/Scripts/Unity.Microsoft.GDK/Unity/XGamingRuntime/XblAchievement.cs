using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime;

[MovedFrom("Unity.GameCore")]
public class XblAchievement
{
	public string Id { get; private set; }

	public string ServiceConfigurationId { get; private set; }

	public string Name { get; private set; }

	public XblAchievementTitleAssociation[] TitleAssociations { get; private set; }

	public XblAchievementProgressState ProgressState { get; private set; }

	public XblAchievementProgression Progression { get; private set; }

	public XblAchievementMediaAsset[] MediaAssets { get; private set; }

	public string[] PlatformsAvailableOn { get; private set; }

	public bool IsSecret { get; private set; }

	public string UnlockedDescription { get; private set; }

	public string LockedDescription { get; private set; }

	public string ProductId { get; private set; }

	public XblAchievementType Type { get; private set; }

	public XblAchievementParticipationType ParticipationType { get; private set; }

	public XblAchievementTimeWindow Available { get; private set; }

	public XblAchievementReward[] Rewards { get; private set; }

	public ulong EstimatedUnlockTime { get; private set; }

	public string DeepLink { get; private set; }

	public bool IsRevoked { get; private set; }

	internal XblAchievement(Unity.XGamingRuntime.Interop.XblAchievement interopAchievement)
	{
		Id = interopAchievement.id.GetString();
		ServiceConfigurationId = interopAchievement.serviceConfigurationId.GetString();
		Name = interopAchievement.name.GetString();
		TitleAssociations = interopAchievement.GetTitleAssociations((Unity.XGamingRuntime.Interop.XblAchievementTitleAssociation ta) => new XblAchievementTitleAssociation(ta));
		ProgressState = interopAchievement.progressState;
		Progression = new XblAchievementProgression(interopAchievement.progression);
		MediaAssets = interopAchievement.GetMediaAssets((Unity.XGamingRuntime.Interop.XblAchievementMediaAsset ma) => new XblAchievementMediaAsset(ma));
		PlatformsAvailableOn = interopAchievement.GetPlatformsAvailableOn();
		IsSecret = interopAchievement.isSecret;
		UnlockedDescription = interopAchievement.unlockedDescription.GetString();
		LockedDescription = interopAchievement.lockedDescription.GetString();
		ProductId = interopAchievement.productId.GetString();
		Type = interopAchievement.type;
		ParticipationType = interopAchievement.participationType;
		Available = new XblAchievementTimeWindow(interopAchievement.available);
		Rewards = interopAchievement.GetRewards((Unity.XGamingRuntime.Interop.XblAchievementReward reward) => new XblAchievementReward(reward));
		EstimatedUnlockTime = interopAchievement.estimatedUnlockTime;
		DeepLink = interopAchievement.deepLink.GetString();
		IsRevoked = interopAchievement.isRevoked;
	}
}
