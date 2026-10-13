using System;
using Isto.Core.Data;
using Isto.Core.Game;
using Isto.Core.Items;
using Isto.Core.Pooling;
using UPool;
using UnityEngine;
using Zenject;

namespace Isto.Core.Automation;

public class AutomationCoreItemRegister : MonoBehaviour, IDataLoadCompleteHandler, IActionOnRecycle
{
	[SerializeField]
	private ItemController _itemController;

	[Header("Hacking tools (don't touch)")]
	[Tooltip("Enable this before deleting if you want to delete items from the editor and have them unregister from automation")]
	[SerializeField]
	private bool _editorDeletionSupport;

	private AutomationSystem _autoSystem;

	private AutomationCoreItem.Factory _itemFactory;

	[Inject]
	public void Inject(AutomationSystem automationSystem, AutomationCoreItem.Factory itemFactory, PooledItemFactory pooledItemFactory)
	{
		_autoSystem = automationSystem;
		_itemFactory = itemFactory;
	}

	public void OnDataLoadComplete()
	{
		if (base.gameObject.activeInHierarchy && !GameState.LoadingFromSave)
		{
			AutomationCoreItem item = _itemFactory.Create(new CoreItemParams(_itemController.itemPile.item.itemID, _itemController.itemPile.count, base.transform.position));
			_autoSystem.TryAddCoreItemToSpace(base.transform.position, item);
			PoolableObject component = GetComponent<PoolableObject>();
			PooledInteractableItem component2 = GetComponent<PooledInteractableItem>();
			if (component != null && component2 != null)
			{
				component2.DeconfigurePooling();
			}
			if (component2 != null)
			{
				component2.DestroyGameObject();
				return;
			}
			Debug.LogWarning("Core Item " + base.gameObject.name + " does not have a PooledInteractableItem so it will be destroyed directly.");
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	protected void OnEnable()
	{
		if (!_itemController.HasItemBeenSet)
		{
			_itemController.ItemSet += OnItemSet;
		}
		else if (!_itemController.InitializedInAutomation)
		{
			SetupInAutomation();
		}
	}

	private void OnItemSet(object sender, EventArgs e)
	{
		if (!_itemController.InitializedInAutomation)
		{
			SetupInAutomation();
		}
		_itemController.ItemSet -= OnItemSet;
	}

	public void SetupInAutomation()
	{
		AutomationCoreItem automationCoreItem = null;
		automationCoreItem = ((!_itemController.HasItemBeenSet) ? _itemFactory.Create(new CoreItemParams(_itemController.itemPile.item.itemID, _itemController.itemPile.count, base.transform.position)) : _itemController.AutomationItem);
		_autoSystem.TryAddCoreItemToSpace(base.transform.position, automationCoreItem, autoCollectItem: false, triggerEvent: false);
		_itemController.SetItem(automationCoreItem, _autoSystem);
	}

	private void OnDestroy()
	{
		if (_editorDeletionSupport)
		{
			_itemController.DoPickupAction();
		}
	}

	public void OnRecycle()
	{
		if (!_itemController.HasItemBeenSet)
		{
			_itemController.ItemSet -= OnItemSet;
		}
	}
}
