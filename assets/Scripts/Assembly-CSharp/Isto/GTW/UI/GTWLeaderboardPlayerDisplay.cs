using Isto.GTW.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Isto.GTW.UI;

public class GTWLeaderboardPlayerDisplay : MonoBehaviour
{
	[Header("UI References (assign in inspector)")]
	[SerializeField]
	private TextMeshProUGUI _rankText;

	[SerializeField]
	private TextMeshProUGUI _nameText;

	[SerializeField]
	private TextMeshProUGUI _scoreText;

	[SerializeField]
	private Image _avatarImage;

	public void Setup(LeaderboardEntryData data, bool isFriendsMode)
	{
		if (_rankText != null)
		{
			_rankText.text = (isFriendsMode ? data.LocalRank : data.GlobalRank).ToString();
		}
		if (_nameText != null)
		{
			_nameText.text = data.PlayerName;
		}
		if (_scoreText != null)
		{
			_scoreText.text = data.HighestCheckpoint.ToString();
		}
		if (_avatarImage != null && data.AvatarTexture != null)
		{
			_avatarImage.sprite = Sprite.Create(data.AvatarTexture, new Rect(0f, 0f, data.AvatarTexture.width, data.AvatarTexture.height), new Vector2(0.5f, 0.5f));
		}
		else
		{
			_avatarImage.gameObject.SetActive(value: false);
		}
	}
}
