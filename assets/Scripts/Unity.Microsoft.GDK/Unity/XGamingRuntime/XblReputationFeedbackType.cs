using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime;

[MovedFrom("Unity.GameCore")]
public enum XblReputationFeedbackType : uint
{
	FairPlayKillsTeammates = 0u,
	FairPlayCheater = 1u,
	FairPlayTampering = 2u,
	FairPlayQuitter = 3u,
	FairPlayKicked = 4u,
	CommunicationsInappropriateVideo = 5u,
	CommunicationsAbusiveVoice = 6u,
	InappropriateUserGeneratedContent = 7u,
	PositiveSkilledPlayer = 8u,
	PositiveHelpfulPlayer = 9u,
	PositiveHighQualityUserGeneratedContent = 10u,
	CommsPhishing = 11u,
	CommsPictureMessage = 12u,
	CommsSpam = 13u,
	CommsTextMessage = 14u,
	CommsVoiceMessage = 15u,
	FairPlayConsoleBanRequest = 16u,
	FairPlayIdler = 17u,
	FairPlayUserBanRequest = 18u,
	UserContentGamerpic = 19u,
	UserContentPersonalInfo = 20u,
	FairPlayUnsporting = 21u,
	FairPlayLeaderboardCheater = 22u
}
