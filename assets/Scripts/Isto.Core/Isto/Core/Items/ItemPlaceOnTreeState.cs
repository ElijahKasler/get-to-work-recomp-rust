using System.Collections.Generic;
using UnityEngine;

namespace Isto.Core.Items;

public class ItemPlaceOnTreeState : ItemRotateByEnableChildState
{
	public List<HarvestableItem> validItems;

	[SerializeField]
	private bool _allowRotation = true;

	[SerializeField]
	private bool _allowSwapping = true;

	private IItemIdentityProvider _idProvider;

	protected override void Awake()
	{
		_idProvider = GetComponent<IItemIdentityProvider>();
		base.Awake();
	}

	protected override bool AtValidDropPosition()
	{
		if (_autoSystem.TryGetExistingGridSpace(base.transform.position, out var space))
		{
			if (_itemComponent.itemPile.item as AdvancedItem != null)
			{
				Vector3 center = FindItemCenter(_itemComponent);
				LayerMask invalidLayers = placementConditions.invalidLayers;
				if (!_controls.UsingJoystick())
				{
					invalidLayers.value &= ~Layers.PLAYER_MASK;
				}
				if (Physics.OverlapBox(center, _halfExtends * 0.9f, Quaternion.identity, invalidLayers, QueryTriggerInteraction.Collide).Length > 2)
				{
					if (!_allowSwapping)
					{
						return false;
					}
					if (space.itemProcessor != null)
					{
						if (!space.itemProcessor.ProcessorID.Equals(_idProvider.ItemID))
						{
							return false;
						}
						if (space.itemProcessor is IDirectionalItem directionalItem && directionalItem.GetDirection() == _controller.Forward)
						{
							return false;
						}
					}
				}
			}
			if (space.itemProcessor != null)
			{
				if (!space.itemProcessor.ProcessorID.Equals(_idProvider.ItemID))
				{
					return false;
				}
				if (space.itemProcessor is IDirectionalItem directionalItem2 && directionalItem2.GetDirection() == _controller.Forward)
				{
					return false;
				}
			}
			if (space.Resource != null)
			{
				for (int i = 0; i < validItems.Count; i++)
				{
					if (space.Resource.ID == validItems[i].itemID)
					{
						return true;
					}
				}
			}
			return false;
		}
		return false;
	}

	protected override bool OverSwappableItems(Collider[] hits, out List<InteractableItem> swappableItems)
	{
		_controller.SetIsNotOverSwappableItem();
		swappableItems = new List<InteractableItem>();
		if (!_allowSwapping)
		{
			return false;
		}
		bool flag = true;
		for (int i = 0; i < hits.Length; i++)
		{
			InteractableItem componentInParent = hits[i].GetComponentInParent<InteractableItem>();
			if (!(componentInParent != null))
			{
				continue;
			}
			if (componentInParent.itemPile.item == _itemComponent.itemPile.item)
			{
				if (!componentInParent.TryGetComponent<IDirectionalItem>(out var component))
				{
					continue;
				}
				if (component.GetDirection() != _controller.Forward)
				{
					if (!swappableItems.Contains(componentInParent))
					{
						swappableItems.Add(componentInParent);
					}
				}
				else
				{
					_controller.SetIsOverSwappableItem();
				}
			}
			else if (componentInParent is HarvestableController harvestableController && !validItems.Contains(harvestableController.item))
			{
				flag = false;
			}
		}
		if (!flag)
		{
			swappableItems.Clear();
		}
		return flag;
	}

	public override void HandleRotation(int direction)
	{
		if (_allowRotation)
		{
			base.HandleRotation(direction);
		}
	}
}
