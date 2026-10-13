using Isto.Core.Localization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Isto.Core.Speedrun;

public class SpeedRunSingleTime : MonoBehaviour
{
	[SerializeField]
	private Image _chapterIcon;

	[SerializeField]
	private TextMeshProUGUI _chapterName;

	[SerializeField]
	private TextMeshProUGUI _chapterTime;

	[SerializeField]
	private TextMeshProUGUI _chapterTarget;

	[SerializeField]
	private TextMeshProUGUI _timeDiff;

	[SerializeField]
	private Image _backgroundImage;

	private LocTerm _chapterNameLoc;

	public void SetChapterName(LocTerm term)
	{
		_chapterNameLoc = term;
		_chapterNameLoc.LocalizeInto(_chapterName);
	}

	public void SetTimer(string text)
	{
		_chapterTime.text = text;
	}

	public void SetColor(Color c)
	{
		_chapterTime.color = c;
	}

	public void SetColorBG(Color c)
	{
		_backgroundImage.color = c;
	}

	public void SetDiffTimer(string text)
	{
		if (!_timeDiff.gameObject.activeSelf)
		{
			_timeDiff.gameObject.SetActive(value: true);
		}
		_timeDiff.text = text;
	}

	public void SetDiffColor(Color c)
	{
		_timeDiff.color = c;
	}

	public void SetTargetTimer(string text)
	{
		if (!_chapterTarget.gameObject.activeSelf)
		{
			_chapterTarget.gameObject.SetActive(value: true);
			MoveTimers(0f - _chapterTarget.rectTransform.rect.width);
		}
		_chapterTarget.text = text;
	}

	public void SetIcon(Sprite sprite)
	{
		if (sprite != null)
		{
			_chapterIcon.sprite = sprite;
		}
		if (!_chapterIcon.gameObject.activeSelf)
		{
			_chapterIcon.gameObject.SetActive(value: true);
		}
	}

	public float GetContentsWidth()
	{
		float num = 0f;
		num += _chapterName.rectTransform.rect.width;
		num += _chapterTime.rectTransform.rect.width;
		if (_timeDiff.gameObject.activeSelf)
		{
			num += _timeDiff.rectTransform.rect.width;
		}
		if (_chapterTarget.gameObject.activeSelf)
		{
			num += _chapterTarget.rectTransform.rect.width;
		}
		if (_chapterIcon.gameObject.activeSelf)
		{
			num += _chapterIcon.rectTransform.rect.width;
		}
		return num;
	}

	public void HideDiffTimer()
	{
		if (_timeDiff.gameObject.activeSelf)
		{
			_timeDiff.gameObject.SetActive(value: false);
		}
	}

	public void HideTargetTimer()
	{
		if (_chapterTarget.gameObject.activeSelf)
		{
			_chapterTarget.gameObject.SetActive(value: false);
			MoveTimers(_chapterTarget.rectTransform.rect.width);
		}
	}

	private void MoveTimers(float offset)
	{
		Vector3 localPosition = _timeDiff.rectTransform.localPosition;
		localPosition.x += offset;
		_timeDiff.rectTransform.localPosition = localPosition;
		Vector3 localPosition2 = _chapterTime.rectTransform.localPosition;
		localPosition2.x += offset;
		_chapterTime.rectTransform.localPosition = localPosition2;
		Vector3 localPosition3 = _chapterTarget.rectTransform.localPosition;
		localPosition3.x += offset;
		_chapterTarget.rectTransform.localPosition = localPosition3;
	}

	public void HideIcon()
	{
		if (_chapterIcon.gameObject.activeSelf)
		{
			_chapterIcon.gameObject.SetActive(value: false);
		}
	}

	public void ActivateImage()
	{
		if (!_backgroundImage.enabled)
		{
			_backgroundImage.enabled = true;
		}
	}

	public void DeActivateImage()
	{
		if (_backgroundImage.enabled)
		{
			_backgroundImage.enabled = false;
		}
	}
}
