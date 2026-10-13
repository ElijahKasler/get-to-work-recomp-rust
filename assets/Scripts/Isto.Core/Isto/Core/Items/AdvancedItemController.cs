using Isto.Core.Inputs;
using Isto.Core.Localization;
using UnityEngine;

namespace Isto.Core.Items;

[SelectionBase]
public class AdvancedItemController : ItemController
{
	[Tooltip("If set to true, when created, will tell all ItemOverlap components to check for overlap")]
	public bool checkOverlap;

	public GameObject floatingDirectionArrow;

	protected override void Awake()
	{
		base.Awake();
		_actionList.Clear();
		_actionList.Add(UserActions.DISMANTLE);
	}

	public override string GetToolTip(UserActions action)
	{
		if (action.Name == "DISMANTLE")
		{
			return Loc.GetString(Constants.USER_ACTION_DISMANTLE);
		}
		return "";
	}

	public override void ShowTooltip()
	{
		base.ShowTooltip();
		if (floatingDirectionArrow != null)
		{
			floatingDirectionArrow.SetActive(value: true);
		}
	}

	public override void SetInactive()
	{
		base.SetInactive();
		if (floatingDirectionArrow != null)
		{
			floatingDirectionArrow.SetActive(value: false);
		}
	}

	public override void OnAllocate()
	{
		base.OnAllocate();
		base.gameObject.SetColliderState(enabled: false);
		itemPile.count = 1;
		if (floatingDirectionArrow != null)
		{
			floatingDirectionArrow.SetActive(value: false);
		}
	}
}
