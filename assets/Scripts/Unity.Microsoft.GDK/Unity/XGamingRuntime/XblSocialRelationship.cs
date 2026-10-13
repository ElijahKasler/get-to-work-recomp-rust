using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime;

[MovedFrom("Unity.GameCore")]
public class XblSocialRelationship
{
	private bool m_isFriend;

	public ulong XboxUserId { get; }

	public bool IsFavourite { get; }

	public bool IsFriend
	{
		get
		{
			return m_isFriend;
		}
		private set
		{
			m_isFriend = value;
		}
	}

	public bool IsFollowingCaller { get; }

	public string[] SocialNetworks { get; }

	internal XblSocialRelationship(Unity.XGamingRuntime.Interop.XblSocialRelationship interopHandle)
	{
		XboxUserId = interopHandle.xboxUserId;
		IsFavourite = interopHandle.isFavorite;
		IsFriend = false;
		IsFollowingCaller = interopHandle.isFollowingCaller;
		SocialNetworks = interopHandle.GetSocialNetworks();
	}

	internal XblSocialRelationship(XblSocialRelationship2 interopHandle)
	{
		XboxUserId = interopHandle.xboxUserId;
		IsFavourite = interopHandle.isFavorite;
		IsFriend = interopHandle.isFriend;
		IsFollowingCaller = interopHandle.isFollowingCaller;
		SocialNetworks = interopHandle.GetSocialNetworks();
	}
}
