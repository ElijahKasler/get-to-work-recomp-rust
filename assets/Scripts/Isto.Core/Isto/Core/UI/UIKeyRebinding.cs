using System.Text.RegularExpressions;
using Isto.Core.Enums;
using Isto.Core.Inputs;
using Rewired;
using UnityEngine;
using UnityEngine.Serialization;

namespace Isto.Core.UI;

public class UIKeyRebinding : UIControlRebindingBase
{
	[FormerlySerializedAs("_action")]
	[Header("Action To Rebind")]
	[EnumDropdown(typeof(UserActions))]
	[SerializeField]
	private string _userAction;

	public override string InputActionName => _userAction;

	public override bool IsAxis => false;

	public string SplitString(string stringToChange)
	{
		return new Regex("\r\n                (?<=[A-Z])(?=[A-Z][a-z]) |\r\n                 (?<=[^A-Z])(?=[A-Z]) |\r\n                 (?<=[A-Za-z])(?=[^A-Za-z])", RegexOptions.IgnorePatternWhitespace).Replace(stringToChange, " ");
	}

	public override void RefreshDisplay()
	{
		_actionId = ReInput.mapping.GetActionId(_userAction);
		_map = GetControllerMapForCategory(_category);
		_aem = GetFirstElementMapFromControllerMap(_map, _userAction);
		if (_aem != null)
		{
			SetupControlsWithElementMap();
		}
		else
		{
			SetupControlsWithNoMapping();
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

	private void SetupControlsWithElementMap()
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
			_controlKeyTextbox.text = ((_aem.keyCode != KeyCode.None) ? _aem.keyCode.ToString() : _aem.elementIdentifierName);
			_controlKeyTextbox.enabled = true;
		}
	}

	private void SetupControlsWithNoMapping()
	{
		_keyImage.sprite = ((_glyphOverride != null) ? _glyphOverride : null);
		_controlKeyTextbox.text = "";
		_controlKeyTextbox.enabled = true;
	}
}
