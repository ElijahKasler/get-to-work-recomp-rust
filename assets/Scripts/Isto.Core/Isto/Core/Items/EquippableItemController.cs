using Isto.Core.Beings;
using Isto.Core.Data;
using UnityEngine;
using Zenject;

namespace Isto.Core.Items;

public abstract class EquippableItemController : MonoBehaviour
{
	[Space]
	[SerializeField]
	protected Item item;

	[SerializeField]
	protected bool _consumable;

	protected AutomationPlayerController _player;

	protected bool _active;

	public string ItemID => item?.itemID;

	public bool Consumable => _consumable;

	[Inject]
	public void Inject(AutomationPlayerController playerController)
	{
		_player = playerController;
	}

	public abstract void OnItemEquipped();

	public abstract void OnItemUnequipped();

	public abstract void OnActiveUpdate();

	public abstract EquippableItemData GetSaveData();

	public abstract void LoadData(EquippableItemData data);

	public void ItemEquipped()
	{
		_active = true;
		OnItemEquipped();
	}

	public void Update()
	{
		if (_active)
		{
			OnActiveUpdate();
		}
	}

	public virtual void ItemUnequipped()
	{
		OnItemUnequipped();
		_active = false;
	}

	public virtual void DeactivateItem()
	{
		_active = false;
	}

	public virtual void ActivateItem()
	{
		_active = true;
	}

	public void Toggle()
	{
		if (_active)
		{
			DeactivateItem();
		}
		else
		{
			ActivateItem();
		}
	}
}
