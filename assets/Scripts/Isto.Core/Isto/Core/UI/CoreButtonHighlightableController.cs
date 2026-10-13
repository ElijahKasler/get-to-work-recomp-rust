using Isto.Core.UI.ButtonStyles;
using UnityEngine;

namespace Isto.Core.UI;

public class CoreButtonHighlightableController : CoreButtonController
{
	[Header("Text Options")]
	[SerializeField]
	private CoreButtonTMPColor _coreButtonTMPColor;

	[SerializeField]
	private ColorStyle _textColorStyle;

	[Header("Underline Image Options")]
	[SerializeField]
	private CoreButtonRectScale _coreButtonRectScale;

	[SerializeField]
	private Vector3Style _vector3DataObjectUnderline;

	private IStyle _previousTextStyle;

	private IStyle _previousRectScaleStyle;

	private IStyle _highlightedRectScaleStyle;

	protected override void Awake()
	{
		base.Awake();
		_previousTextStyle = _coreButtonTMPColor.style;
		_previousRectScaleStyle = _coreButtonRectScale.style;
		_highlightedRectScaleStyle = _vector3DataObjectUnderline;
	}

	public void SetHighlighted(bool isHighlighted)
	{
		if (!(GetSelectable() == null))
		{
			if (isHighlighted)
			{
				HighlightStyle();
			}
			else
			{
				UnhighlightStyle();
			}
		}
	}

	[ContextMenu("HighlightStyle")]
	private void HighlightStyle()
	{
		_coreButtonTMPColor.SetStyle(_textColorStyle);
		_coreButtonRectScale.SetStyle(_highlightedRectScaleStyle);
	}

	[ContextMenu("UnhighlightStyle")]
	private void UnhighlightStyle()
	{
		_coreButtonTMPColor.SetStyle(_previousTextStyle);
		_coreButtonRectScale.SetStyle(_previousRectScaleStyle);
	}
}
