using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime;

[MovedFrom("Unity.GameCore")]
public class XblAchievementMediaAsset
{
	public string Name { get; private set; }

	public XblAchievementMediaAssetType MediaAssetType { get; private set; }

	public string Url { get; private set; }

	internal XblAchievementMediaAsset(Unity.XGamingRuntime.Interop.XblAchievementMediaAsset mediaAsset)
	{
		Name = mediaAsset.name.GetString();
		MediaAssetType = mediaAsset.mediaAssetType;
		Url = mediaAsset.url.GetString();
	}
}
