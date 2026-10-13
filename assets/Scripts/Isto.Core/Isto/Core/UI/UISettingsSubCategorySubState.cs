using UnityEngine;
using UnityEngine.UI;

namespace Isto.Core.UI;

public class UISettingsSubCategorySubState : UISettingsBaseSubState
{
	[Header("Substate Tab Button")]
	[SerializeField]
	protected CoreButtonHighlightableController _substateTabButtonHighlighter;

	public override bool HasChanges { get; }

	public override Selectable FirstSelectable { get; }

	public override Selectable DefaultSelectable { get; }

	public override SettingsSubMenusEnum SettingsSubMenu { get; }

	public CoreButton SubTabButton => _substateTabButtonHighlighter.GetButton();

	private CoreButtonHighlightableController SubTabButtonHighlighter => _substateTabButtonHighlighter;

	public override void ResetToDefaults()
	{
	}
}
