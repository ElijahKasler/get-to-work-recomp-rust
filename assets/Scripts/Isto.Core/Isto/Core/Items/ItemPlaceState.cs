using System.Collections.Generic;
using Isto.Core.Automation;
using Isto.Core.Beings;
using Isto.Core.Configuration;
using Isto.Core.Inputs;
using Isto.Core.StateMachine;
using Isto.Core.Tiles;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace Isto.Core.Items;

public class ItemPlaceState : MonoState
{
	public MonoState nextState;

	[Header("Placement Checks")]
	[Tooltip("Layers that the object cannot be placed over.")]
	public bool allowContinuousPlacement;

	public bool allowForwardSwapOnSelf;

	[SerializeField]
	protected PlacementConditions placementConditions;

	[Header("Item Bounds")]
	[SerializeField]
	protected BoxCollider[] boundingColliders;

	[Header("Placement Behaviour")]
	public float placementDelay = Constants.BUTTON_SPAM_DELAY;

	protected ItemPlacementController _controller;

	protected IControls _controls;

	protected Settings _settings;

	protected AutomationSystem _autoSystem;

	protected AutomationPlayerController _playerController;

	protected TilemapGlobalController _tilemapController;

	protected InteractableItem _itemComponent;

	protected Vector3 _halfExtends;

	protected float _spamTimer;

	protected ItemSetMaterialState _setMaterialState;

	protected bool _validPosition = true;

	protected Collider[] _itemsAtOurPosition;

	protected List<InteractableItem> _existingItemsAtOurPosition = new List<InteractableItem>();

	private List<NavMeshObstacle> _navMeshObstacles;

	private InteractableItem _delayedItemToPickUp;

	private HashSet<GameObject> _checkedObjects = new HashSet<GameObject>();

	[Inject]
	public void Inject(IControls controls, Settings settings, AutomationSystem automationSystem, AutomationPlayerController playerController, [Inject(Optional = true)] TilemapGlobalController tilemapCulling)
	{
		_controls = controls;
		_settings = settings;
		_autoSystem = automationSystem;
		_playerController = playerController;
		_tilemapController = tilemapCulling;
	}

	protected virtual void Awake()
	{
		_itemComponent = GetComponent<InteractableItem>();
		_setMaterialState = GetComponent<ItemSetMaterialState>();
		_controller = GetComponent<ItemPlacementController>();
		if (placementConditions == null)
		{
			Debug.LogError("No placement conditions set for item : " + base.gameObject.name);
		}
	}

	public override void Enter(MonoStateMachine controller)
	{
		_controller = controller as ItemPlacementController;
		_navMeshObstacles = new List<NavMeshObstacle>();
		NavMeshObstacle component = base.gameObject.GetComponent<NavMeshObstacle>();
		if (component != null)
		{
			_navMeshObstacles.Add(component);
		}
		NavMeshObstacle[] componentsInChildren = base.gameObject.GetComponentsInChildren<NavMeshObstacle>(includeInactive: true);
		if (componentsInChildren.Length != 0)
		{
			_navMeshObstacles.AddRange(componentsInChildren);
		}
		foreach (NavMeshObstacle navMeshObstacle in _navMeshObstacles)
		{
			navMeshObstacle.enabled = false;
		}
		_spamTimer = 0f;
	}

	public override void Exit(MonoStateMachine controller)
	{
		foreach (NavMeshObstacle navMeshObstacle in _navMeshObstacles)
		{
			navMeshObstacle.enabled = true;
		}
	}

	public override void ReturnFromSubState(MonoStateMachine controller, MonoState previousState)
	{
	}

	public override MonoState Run(MonoStateMachine controller)
	{
		UpdateItemsUnderPosition();
		bool validPosition = AtValidDropPosition();
		UpdateMaterialColors(validPosition);
		ProcessInputsFromUser(validPosition);
		return this;
	}

	private void UpdateMaterialColors(bool validPosition)
	{
		if (validPosition != _validPosition && _setMaterialState != null)
		{
			if (validPosition)
			{
				_setMaterialState.RestoreMaterialTint();
			}
			else
			{
				_setMaterialState.SetMaterialTint(_setMaterialState.invalidPlaceTint, _setMaterialState.invalidPlaceEmission);
			}
			_validPosition = validPosition;
		}
	}

	protected void ProcessInputsFromUser(bool validPosition)
	{
		_spamTimer += Time.deltaTime;
		if (!(_spamTimer > placementDelay))
		{
			return;
		}
		bool flag = _controls.GetButtonDown(UserActions.INTERACT);
		if (allowContinuousPlacement)
		{
			flag = _controls.GetButton(UserActions.INTERACT);
		}
		if (flag & validPosition)
		{
			_spamTimer = 0f;
			if (_existingItemsAtOurPosition.Count > 0)
			{
				if (CanRemoveAllItems(_existingItemsAtOurPosition))
				{
					RemoveExistingItems(_existingItemsAtOurPosition);
					_controller.ChangeState(nextState);
				}
			}
			else
			{
				_controller.ChangeState(nextState);
			}
		}
		else if (_controls.GetButton(UserActions.CANCELBUILDING))
		{
			_spamTimer = 0f;
			if (_existingItemsAtOurPosition.Count > 0)
			{
				UnhideItems(_existingItemsAtOurPosition);
			}
			_controller.CancelDrop();
		}
	}

	protected virtual bool AtValidDropPosition()
	{
		if (_itemComponent.itemPile.item as AdvancedItem != null)
		{
			Collider[] itemsAtOurPosition = _itemsAtOurPosition;
			int num = 0;
			_checkedObjects.Clear();
			for (int i = 0; i < itemsAtOurPosition.Length; i++)
			{
				InteractableItem componentInParent = itemsAtOurPosition[i].GetComponentInParent<InteractableItem>();
				if (IsSameItem(componentInParent, _checkedObjects))
				{
					num++;
				}
				if (!IsSwappableItem(componentInParent))
				{
					return false;
				}
			}
			List<Vector3> allPositionsUnderItem = GetAllPositionsUnderItem();
			if (AtValidGroundTile(allPositionsUnderItem))
			{
				for (int j = 0; j < allPositionsUnderItem.Count; j++)
				{
					if (IsOverBlockedAutomationSpace(allPositionsUnderItem[j]))
					{
						return false;
					}
				}
				return num < 2;
			}
			return false;
		}
		return true;
	}

	protected bool AtValidGroundTile(List<Vector3> positionsUnderItem)
	{
		if (_tilemapController == null)
		{
			return true;
		}
		for (int i = 0; i < positionsUnderItem.Count; i++)
		{
			if (!_tilemapController.IsTileNavigatable(positionsUnderItem[i]))
			{
				return false;
			}
		}
		return true;
	}

	private bool IsSameItem(InteractableItem otherItem, HashSet<GameObject> previousCheckedObjects)
	{
		if (otherItem == null)
		{
			return false;
		}
		if (otherItem.itemPile == null)
		{
			return false;
		}
		if (otherItem.gameObject == base.gameObject)
		{
			return false;
		}
		if (previousCheckedObjects.Contains(otherItem.gameObject))
		{
			return false;
		}
		previousCheckedObjects.Add(otherItem.gameObject);
		return otherItem.itemPile.item == _itemComponent.itemPile.item;
	}

	public virtual Vector3 FindItemCenter(InteractableItem interactableItem)
	{
		AdvancedItem advancedItem = interactableItem.itemPile.item as AdvancedItem;
		if (TryGetActiveBoundingCollider(out var boundingCollider))
		{
			_halfExtends = GetExtendsFromCollider(boundingCollider);
			return boundingCollider.bounds.center;
		}
		if (_controller.Forward.z != 0f)
		{
			_halfExtends.Set(advancedItem.width / 2f, 0.5f, advancedItem.depth / 2f);
		}
		else
		{
			_halfExtends.Set(advancedItem.depth / 2f, 0.5f, advancedItem.width / 2f);
		}
		Vector3 position = base.transform.position;
		if (_controller.Forward.z == 1f)
		{
			position.z++;
		}
		if (_controller.Forward.x == -1f)
		{
			position.x--;
		}
		position.x += _halfExtends.x * ((_controller.Forward.x == 0f) ? (-1f) : (0f - _controller.Forward.x));
		position.z += _halfExtends.z * ((_controller.Forward.z == 0f) ? 1f : (0f - _controller.Forward.z));
		return position;
	}

	protected Vector3 GetExtendsFromCollider(BoxCollider box)
	{
		Vector3 result = box.transform.rotation * Vector3.Scale(box.size, box.transform.lossyScale) / 2f;
		result.Set(Mathf.Abs(result.x), Mathf.Abs(result.y), Mathf.Abs(result.z));
		return result;
	}

	protected void HideItems(List<InteractableItem> exisitingItems)
	{
	}

	protected void UnhideItems(List<InteractableItem> exisitingItems)
	{
	}

	protected virtual bool OverSwappableItems(Collider[] hits, out List<InteractableItem> swappableItems)
	{
		_controller.SetIsNotOverSwappableItem();
		swappableItems = new List<InteractableItem>();
		bool flag = true;
		for (int i = 0; i < hits.Length; i++)
		{
			InteractableItem componentInParent = hits[i].GetComponentInParent<InteractableItem>();
			if (componentInParent != null)
			{
				if (IsSwappableItem(componentInParent))
				{
					if (!(componentInParent.GetComponentInParent<ItemPlaceState>() == this) && !swappableItems.Contains(componentInParent))
					{
						swappableItems.Add(componentInParent);
					}
				}
				else
				{
					flag = false;
				}
			}
			else
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

	public List<Vector3> GetAllPositionsUnderItem()
	{
		if (TryGetActiveBoundingCollider(out var boundingCollider))
		{
			return GetAllPositionsUnderCollider(boundingCollider);
		}
		return new List<Vector3> { (FindItemCenter(_itemComponent) - Constants.GRID_CENTERING_OFFSET).GetSnappedPosition(1f) };
	}

	protected bool TryGetActiveBoundingCollider(out BoxCollider boundingCollider)
	{
		for (int i = 0; i < boundingColliders.Length; i++)
		{
			if (boundingColliders[i].gameObject.activeInHierarchy)
			{
				boundingCollider = boundingColliders[i];
				boundingCollider.enabled = true;
				return true;
			}
		}
		if (boundingColliders.Length != 0)
		{
			Debug.LogError("Error: " + base.gameObject.name + " has bounding colliders set but none are active.  This is wrong");
		}
		boundingCollider = null;
		return false;
	}

	protected List<Vector3> GetAllPositionsUnderCollider(BoxCollider boundingCollider)
	{
		List<Vector3> list = new List<Vector3>();
		Vector3 vector = boundingCollider.transform.TransformVector(boundingCollider.size);
		int num = Mathf.Abs(Mathf.RoundToInt(vector.x));
		int num2 = Mathf.Abs(Mathf.RoundToInt(vector.z));
		Vector3 position = boundingCollider.transform.TransformPoint(boundingCollider.center) - Constants.GRID_CENTERING_OFFSET * 0.9f;
		position.x -= num / 2;
		position.z -= num2 / 2;
		position.y = 0f;
		position = position.GetSnappedPosition(1f);
		for (int i = 0; i < num; i++)
		{
			for (int j = 0; j < num2; j++)
			{
				Vector3 item = new Vector3(i, 0f, j) + position;
				list.Add(item);
			}
		}
		return list;
	}

	protected bool IsOverBlockedAutomationSpace(Vector3 position)
	{
		if (_autoSystem.TryGetExistingGridSpace(position, out var space) && space.itemProcessor is AutomationBlockedSpace)
		{
			return true;
		}
		return false;
	}

	protected bool IsOverReplaceableResource(Vector3 position)
	{
		if (_autoSystem.TryGetExistingGridSpace(position, out var space))
		{
			for (int i = 0; i < placementConditions.validResourcesToReplace.Count; i++)
			{
				HarvestableItem harvestableItem = placementConditions.validResourcesToReplace[i];
				if (space.Resource != null && space.Resource.ID == harvestableItem.itemID)
				{
					return true;
				}
			}
		}
		return false;
	}

	protected bool IsSwappableItem(InteractableItem interactable)
	{
		if (interactable == null)
		{
			return false;
		}
		if (interactable.GetComponentInParent<ItemPlaceState>() == this)
		{
			return true;
		}
		if (interactable.TryGetComponent<ItemPlaceCompleteState>(out var component) && !component.PlaceAnimationComplete)
		{
			return false;
		}
		if (interactable.itemPile.item == _itemComponent.itemPile.item && !allowForwardSwapOnSelf)
		{
			if (interactable.TryGetComponent<IDirectionalItem>(out var component2))
			{
				if (component2.GetDirection() != _controller.Forward)
				{
					return true;
				}
				return false;
			}
			return false;
		}
		Item item = ((!(interactable is HarvestableController harvestableController)) ? ((Item)(interactable.itemPile?.item)) : ((Item)harvestableController.item));
		if (item is AdvancedItem item2)
		{
			return placementConditions.validItemsToReplace.Contains(item2);
		}
		if (item is HarvestableItem harvestableItem)
		{
			for (int i = 0; i < placementConditions.validResourcesToReplace.Count; i++)
			{
				if (harvestableItem.itemID == placementConditions.validResourcesToReplace[i].itemID)
				{
					return true;
				}
			}
		}
		return false;
	}

	protected virtual Collider[] GetPhysicsItemsAtOurPosition()
	{
		if (_itemComponent.itemPile.item as AdvancedItem != null)
		{
			Vector3 center = FindItemCenter(_itemComponent);
			LayerMask invalidLayers = placementConditions.invalidLayers;
			if (!_controls.UsingJoystick())
			{
				invalidLayers.value &= ~Layers.PLAYER_MASK;
			}
			return Physics.OverlapBox(center, _halfExtends * 0.9f, Quaternion.identity, invalidLayers, QueryTriggerInteraction.Collide);
		}
		return new Collider[0];
	}

	protected void UpdateOverlappedItems(Collider[] itemsAtOurPosition)
	{
		if (OverSwappableItems(itemsAtOurPosition, out var swappableItems))
		{
			UnhideItems(_existingItemsAtOurPosition);
			HideItems(swappableItems);
			_existingItemsAtOurPosition = swappableItems;
			return;
		}
		if (_existingItemsAtOurPosition.Count > 0)
		{
			UnhideItems(_existingItemsAtOurPosition);
		}
		_existingItemsAtOurPosition.Clear();
	}

	protected void UpdateItemsUnderPosition()
	{
		_itemsAtOurPosition = GetPhysicsItemsAtOurPosition();
		UpdateOverlappedItems(_itemsAtOurPosition);
	}

	protected void RemoveExistingItems(List<InteractableItem> existingItems)
	{
		for (int i = 0; i < existingItems.Count; i++)
		{
			if (existingItems[i] is HarvestableController harvestableController)
			{
				if (_autoSystem.TryGetExistingGridSpace(harvestableController.transform.position, out var space))
				{
					space.ClearResource();
				}
				else
				{
					Debug.LogWarning($"No automation grid space found at {harvestableController.transform.position} for item {harvestableController.gameObject.name}");
				}
			}
			else if (_playerController.Inventory.GetSpaceAvailable(existingItems[i].itemPile.item) == 0)
			{
				_delayedItemToPickUp = existingItems[i];
				_playerController.PlaceAdvItemState.ItemPlaced += OnItemPlaced;
			}
			else
			{
				_playerController.InteractionState.HandlePickupItem(existingItems[i]);
			}
		}
		existingItems.Clear();
	}

	private bool CanRemoveAllItems(List<InteractableItem> existingItems)
	{
		Dictionary<CoreItem, int> dictionary = new Dictionary<CoreItem, int>();
		for (int i = 0; i < existingItems.Count; i++)
		{
			ItemPile itemPile = existingItems[i].itemPile;
			if (!(existingItems[i] is HarvestableController) && !(itemPile.item == null))
			{
				if (dictionary.ContainsKey(itemPile.item))
				{
					dictionary[itemPile.item] += itemPile.count;
				}
				else
				{
					dictionary.Add(itemPile.item, itemPile.count);
				}
				if (!(itemPile.item == _itemComponent.itemPile.item) && _playerController.Inventory.GetSpaceAvailable(itemPile.item) < dictionary[itemPile.item])
				{
					_playerController.Inventory.InventoryFull();
					return false;
				}
			}
		}
		return true;
	}

	private void OnItemPlaced(object sender, ItemEventArgs e)
	{
		_playerController.InteractionState.HandlePickupItem(_delayedItemToPickUp);
		_delayedItemToPickUp = null;
		_playerController.PlaceAdvItemState.ItemPlaced -= OnItemPlaced;
	}
}
