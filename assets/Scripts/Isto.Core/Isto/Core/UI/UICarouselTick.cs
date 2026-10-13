using UnityEngine;
using UnityEngine.UI;

namespace Isto.Core.UI;

public class UICarouselTick : MonoBehaviour
{
	[Header("UI Component Hookups")]
	[SerializeField]
	private Image _carouselTickImage;

	[SerializeField]
	private Color _highlightedColor;

	private Color _defaultColor;

	private void Awake()
	{
		_defaultColor = _carouselTickImage.color;
	}

	public void SetHighlight(bool isHighlighted)
	{
		if (isHighlighted)
		{
			_carouselTickImage.color = _highlightedColor;
		}
		else
		{
			_carouselTickImage.color = _defaultColor;
		}
	}
}
