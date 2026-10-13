using System;
using System.Collections.Generic;
using Isto.Core.Automation;
using Isto.Core.Inputs;
using UnityEngine;

namespace Isto.Core.Items;

[SelectionBase]
public class ItemController : PooledInteractableItem, IItemTopmostParent, IInteractable, IActivatable, IAutomationItemDisplay, IActionOnPickup
{
	public SpriteRenderer spriteRend;

	protected AutomationSystem _autoSystem;

	protected AutomationCoreItem _item;

	public bool InitializedInAutomation => _item != null;

	public bool HasItemBeenSet { get; private set; }

	public AutomationCoreItem AutomationItem => _item;

	public event EventHandler ItemSet;

	protected override void Awake()
	{
		base.Awake();
		InitializeRenderer();
		_actionList.Clear();
		_actionList.Add(UserActions.INTERACT);
	}

	protected override void Update()
	{
		base.Update();
		if (_item != null)
		{
			itemPile.count = _item.count;
		}
	}

	protected override void OnDestroy()
	{
		if (_item != null)
		{
			_item.Consumed -= OnItemConsumed;
			_item = null;
		}
		base.OnDestroy();
	}

	public void SetItem(CoreItem itemType, int count)
	{
		itemPile = new ItemPile(itemType, count);
		InitializeRenderer();
		HasItemBeenSet = true;
		ItemSet?.Invoke(this, EventArgs.Empty);
	}

	public virtual void SetItem(AutomationCoreItem item, AutomationSystem system)
	{
		_autoSystem = system;
		_item = item;
		if (_masterItemList.TryGetItemByID<CoreItem>(item.ID, out var item2))
		{
			SetItem(item2, item.count);
		}
		item.Consumed += OnItemConsumed;
	}

	public void InitializeRenderer()
	{
		if (spriteRend != null && itemPile != null && itemPile.item != null)
		{
			spriteRend.sprite = itemPile.item.gameplaySprite;
		}
	}

	public void SetPropertyBlockSet(Texture emissionSprite, float emissionFactor, Color emissionTint)
	{
		if (!(spriteRend == null))
		{
			CoreSpritePropertyBlockSet component = spriteRend.GetComponent<CoreSpritePropertyBlockSet>();
			if (component != null)
			{
				component.emissionMap = emissionSprite;
				component.emissionFactor = emissionFactor;
				component.emissionTint = emissionTint;
				component.disableEmissionInDark = false;
			}
			if (component != null)
			{
				component.SetPropertyBlock();
			}
			else
			{
				Debug.LogError("No Sprite Property Block set on gameobject with SpriteRenderer.  Object: " + base.gameObject.name);
			}
		}
	}

	public GameObject GetGameObject()
	{
		return base.gameObject;
	}

	public override List<UserActions> GetValidActions()
	{
		if (!_interactive)
		{
			return new List<UserActions>();
		}
		return _actionList;
	}

	public override Vector3 GetInteractionPosition(Vector3 playerPosition)
	{
		Vector3 vector = ((UnityUtils.GetRelativeHorizontalDirection(playerPosition, base.transform.position) > 0f) ? Constants.ITEM_PICKUP_ALIGN_RIGHT : Constants.ITEM_PICKUP_ALIGN_LEFT);
		return base.transform.position + vector;
	}

	public override string GetToolTip(UserActions action)
	{
		if (action.Name == "INTERACT")
		{
			return itemPile.item.GetToolTip();
		}
		return "";
	}

	public override string GetItemName()
	{
		if (itemPile.count <= 1)
		{
			return itemPile.item.itemName;
		}
		return itemPile.item.itemName + "  x" + itemPile.count;
	}

	public virtual void Activate()
	{
		base.enabled = true;
		base.gameObject.SetColliderState(enabled: true);
	}

	protected virtual void OnItemConsumed(object sender, EventArgs e)
	{
		if (_item != null)
		{
			_item.Consumed -= OnItemConsumed;
		}
	}

	public virtual void DoPickupAction()
	{
		if (_autoSystem != null && _item != null && !_autoSystem.DeleteCoreItem(_item))
		{
			DestroyGameObject();
		}
	}

	public override void ReduceCount(int amount)
	{
		if (InitializedInAutomation)
		{
			_item.count -= amount;
		}
		base.ReduceCount(amount);
	}

	public override void OnAllocate()
	{
		base.OnAllocate();
	}

	public override void OnDeallocate()
	{
		if (_item != null)
		{
			_item.Consumed -= OnItemConsumed;
		}
		_item = null;
		HasItemBeenSet = false;
		base.OnDeallocate();
	}
}
