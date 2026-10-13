using Isto.Core.Localization;
using TMPro;
using UnityEngine;

namespace Isto.Core.UI;

public class UISettingsOptionLabel : UISettingsSelectable
{
	[Header("Settings Hookup")]
	[SerializeField]
	private TextMeshProUGUI _label;

	public void SetLabel(string newLabel)
	{
		_label.text = newLabel;
	}

	public void SetLabel(LocExpression locTermString)
	{
		locTermString.LocalizeInto(_label);
	}
}
