using System.Collections.Generic;
using Isto.Core.Beings;
using Isto.Core.Inputs;
using UnityEngine;

namespace Isto.Core.Items;

public class Eraser : PooledInteractableItem
{
	public InteractableItem EraseTarget { get; set; }

	protected override void Update()
	{
	}

	protected override void OnDestroy()
	{
	}

	public override void ShowTooltip(float offset, bool showSelectionhighlight = true)
	{
	}

	public override void ShowTooltip()
	{
	}

	public override void SetInactive()
	{
	}

	public override void PlayerInteraction(AutomationPlayerController player, UserActions action)
	{
		Debug.LogError("Should not be possible to interact on Eraser", this);
	}

	public override string GetItemName()
	{
		Debug.LogError("Eraser item name should not be displayed in the game");
		return itemPile.item.itemName;
	}

	public override string GetToolTip(UserActions action)
	{
		Debug.LogError("Should not be invoking GetToolTip on Eraser", this);
		return "";
	}

	public override List<UserActions> GetValidActions()
	{
		_actionList.Clear();
		return _actionList;
	}

	public static void ReadyObjectForDismantling(GameObject target)
	{
		target.SetColliderState(enabled: false);
		if (target.TryGetComponent<IActionOnReadToDismantle>(out var component))
		{
			component.OnReadyToDismantle();
		}
		if (target.TryGetComponent<ItemSetMaterialState>(out var component2))
		{
			component2.LoadRenderers();
			component2.SetMaterials(component2.placementMaterial, component2.DropMaterial);
		}
	}

	public static void UnreadyObjectForDismantling(GameObject target)
	{
		target.SetColliderState(enabled: true);
		if (target.TryGetComponent<IActionOnDismantleAborted>(out var component))
		{
			component.OnDismantleAborted();
		}
		if (target.TryGetComponent<ItemSetMaterialState>(out var component2))
		{
			component2.RestoreMaterials();
		}
	}
}
