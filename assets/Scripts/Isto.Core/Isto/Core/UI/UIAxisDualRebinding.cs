using Isto.Core.Inputs;
using Rewired;
using UnityEngine;

namespace Isto.Core.UI;

public class UIAxisDualRebinding : UIControlRebindingBase
{
	[SerializeField]
	private Controls.MovementAxis _axis;

	public override string InputActionName => _axis.ToString();

	public override bool IsAxis => true;

	public override void RefreshDisplay()
	{
		_actionId = ReInput.mapping.GetActionId(_axis.ToString());
		_map = GetControllerMapForCategory(_category);
		_aem = GetFirstElementMapFromControllerMap(_map, _axis.ToString());
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
				_controlKeyTextbox.text = _aem.keyCode.ToString();
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
}
