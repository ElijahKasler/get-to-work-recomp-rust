using System.Text.RegularExpressions;
using Isto.Core.Inputs;
using Rewired;
using UnityEngine;

namespace Isto.Core.UI;

public class UIAxisRebinding : UIControlRebindingBase
{
	[Header("Axis To Rebind")]
	[SerializeField]
	private Controls.MovementAxis _axis;

	[SerializeField]
	private Pole _axisDirection;

	public override string InputActionName => _axis.ToString();

	public override bool IsAxis => true;

	public override AxisRange ActionAxisRange
	{
		get
		{
			if (_aem != null)
			{
				if (_aem.axisContribution != Pole.Positive)
				{
					return AxisRange.Negative;
				}
				return AxisRange.Positive;
			}
			if (_axisDirection != Pole.Negative)
			{
				return AxisRange.Positive;
			}
			return AxisRange.Negative;
		}
	}

	public override Pole AxisDirection => _axisDirection;

	public override void RefreshDisplay()
	{
		_actionId = ReInput.mapping.GetActionId(_axis.ToString());
		_map = GetControllerMapForCategory(_category);
		_aem = GetFirstElementMapFromControllerMap(_map, _axis.ToString(), _axisDirection);
		if (_aem != null)
		{
			Sprite glyphForAction = GetGlyphForAction(_aem);
			if (glyphForAction != null)
			{
				_keyImage.sprite = glyphForAction;
				_keyImage.enabled = true;
				_controlKeyTextbox.enabled = false;
			}
			else
			{
				_keyImage.enabled = false;
				_controlKeyTextbox.text = SplitString(_aem.keyCode.ToString());
				_controlKeyTextbox.enabled = true;
			}
		}
		else
		{
			_keyImage.sprite = null;
			_controlKeyTextbox.text = "";
			_controlKeyTextbox.enabled = true;
		}
		if (_glyphOverride != null)
		{
			_keyImage.sprite = _glyphOverride;
		}
		if (!_isInitialized)
		{
			_cachedSprite = _keyImage.sprite;
			_isInitialized = true;
		}
		else
		{
			base.Button.SetDirtyFlag(_cachedSprite != _keyImage.sprite);
		}
	}

	public string SplitString(string stringToChange)
	{
		if (string.IsNullOrEmpty(stringToChange))
		{
			return "";
		}
		return new Regex("\r\n                (?<=[A-Z])(?=[A-Z][a-z]) |\r\n                 (?<=[^A-Z])(?=[A-Z]) |\r\n                 (?<=[A-Za-z])(?=[^A-Za-z])", RegexOptions.IgnorePatternWhitespace).Replace(stringToChange, " ");
	}
}
