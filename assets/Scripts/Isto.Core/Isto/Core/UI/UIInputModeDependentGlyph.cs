using Isto.Core.Inputs;
using UnityEngine;
using UnityEngine.UI;

namespace Isto.Core.UI;

public class UIInputModeDependentGlyph : MonoBehaviour
{
	[Header("Control Image")]
	[SerializeField]
	private Image _controlImage;

	[Header("Rect Transform")]
	[SerializeField]
	private RectTransform _rectTransform;

	[Header("Input Glyphs")]
	[SerializeField]
	private Sprite _gamepadGlyph;

	[SerializeField]
	private Sprite _keyboardMouseGlyph;

	[Header("Image Sizes")]
	[SerializeField]
	private Vector2 _keyboardMouseSize;

	[SerializeField]
	private Vector2 _gamepadSize;

	private void OnEnable()
	{
		UpdateMenuGlyphs();
		Events.Subscribe("InputChanged", UpdateMenuGlyphs);
	}

	private void OnDisable()
	{
		Events.UnSubscribe("InputChanged", UpdateMenuGlyphs);
	}

	private void UpdateMenuGlyphs()
	{
		_controlImage.sprite = (Controls.UsingController ? _gamepadGlyph : _keyboardMouseGlyph);
		AdjustImageSize();
	}

	public void AdjustImageSize()
	{
		if (_controlImage.sprite != null)
		{
			_rectTransform.sizeDelta = (Controls.UsingController ? _gamepadSize : _keyboardMouseSize);
		}
	}
}
