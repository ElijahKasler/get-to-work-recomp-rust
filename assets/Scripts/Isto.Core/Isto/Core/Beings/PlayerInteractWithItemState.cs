using FMODUnity;
using Isto.Core.Audio;
using Isto.Core.Automation;
using Isto.Core.Inputs;
using Isto.Core.Items;
using Isto.Core.StateMachine;
using Isto.Core.UI;
using UnityEngine;
using Zenject;

namespace Isto.Core.Beings;

[CreateAssetMenu(fileName = "New Player Item Interaction State", menuName = "Scriptables/State/Player Item Interaction State")]
public class PlayerInteractWithItemState : State
{
	protected enum InteractionType
	{
		PickUpItem = 0,
		DropItemFromInventory = 1,
		GiveItem = 2,
		MoveToThenInteract = 3
	}

	public float moveSpeed = 15f;

	[Tooltip("Distance from item before it is picked up. Some interactions are collider based however")]
	[SerializeField]
	private float _interactionRange = 1f;

	[Tooltip("Delay between interacting with item again if in range.")]
	public float exitDelay = 0.25f;

	[EventRef]
	public string pickupSoundRef = "event:/SFX/Atrio SFX_Pick up-St";

	protected ItemPile _activeItem;

	protected Vector3 _interactionPosition;

	protected GameObject _interactionObject;

	protected InteractionType _currentActionType;

	protected IItemInteractionCallback _callback;

	private float _nextValidTime;

	private Collider[] _hitBuffer = new Collider[5];

	private float _minStateTime = 0.15f;

	private float _stateTimer;

	private bool _interactionComplete;

	private State _nextState;

	private float _currentInteractionDistance;

	protected AutomationPlayerController _controller;

	protected AutomationPlayerMoveState _moveState;

	protected PlayerInventory _inventory;

	protected IGameSounds _sounds;

	protected IControls _controls;

	protected AutomationSystem _autoSystem;

	protected IUIGameMenu _mainMenu;

	public GameObject InteractionObject => _interactionObject;

	public float InteractionRange => _currentInteractionDistance;

	[Inject]
	public virtual void Inject(AutomationPlayerController playerController, IControls controls, AutomationPlayerMoveState playerMoveState, PlayerInventory playerInventory, IGameSounds sounds, AutomationSystem automationSystem, IUIGameMenu mainMenu)
	{
		_controller = playerController;
		_moveState = playerMoveState;
		_inventory = playerInventory;
		_sounds = sounds;
		_controls = controls;
		_autoSystem = automationSystem;
		_mainMenu = mainMenu;
		_currentInteractionDistance = _interactionRange;
	}

	public override void Enter(ScriptableStateMachine controller)
	{
		_controller = controller as AutomationPlayerController;
		if (_currentActionType != InteractionType.DropItemFromInventory && !IsTargetInInteractionRange())
		{
			SetMovementTowardsItem();
		}
		if (IsTargetInInteractionRange() && _currentActionType == InteractionType.PickUpItem)
		{
			_nextState = InteractWithItem();
			if (_controls.UsingJoystick())
			{
				_controller.ProcessMovementAndInteractions(movement: true, ability: false, itemInteraction: false);
			}
		}
		else
		{
			_interactionComplete = false;
		}
		_nextValidTime = Time.time;
		_stateTimer = 0f;
	}

	public override void Exit(ScriptableStateMachine controller)
	{
		isInterruptable = true;
	}

	public override IState Run(ScriptableStateMachine controller)
	{
		_stateTimer += Time.deltaTime;
		if (_stateTimer > _minStateTime || _interactionComplete)
		{
			bool itemInteraction = _stateTimer > _minStateTime;
			State state = _controller.ProcessMovementAndInteractions(movement: true, ability: true, itemInteraction);
			if (state != null && _stateTimer > _minStateTime && !_interactionComplete)
			{
				return state;
			}
		}
		if (Time.time >= _nextValidTime)
		{
			if (_interactionComplete)
			{
				isInterruptable = true;
				return _nextState;
			}
			if (!IsTargetInInteractionRange())
			{
				return this;
			}
			ResetTimers();
			_nextState = InteractWithItem();
		}
		return this;
	}

	public void SetItemDrop(Vector3 position, ItemPile items, IItemInteractionCallback callback)
	{
		_currentActionType = InteractionType.DropItemFromInventory;
		_interactionPosition = position;
		_activeItem = items;
		_callback = callback;
	}

	public void SetPickupItem(IInteractable targetInteractable)
	{
		UnityUtils.TryGetGameObjectFromInterface(targetInteractable as Component, out var gameObject);
		_interactionObject = gameObject;
		UnityUtils.GetRelativeHorizontalDirection(_controller.transform.position, gameObject.transform.position);
		_interactionPosition = targetInteractable.GetInteractionPosition(_controller.transform.position);
		_currentInteractionDistance = _interactionRange;
		_currentActionType = InteractionType.PickUpItem;
		_interactionComplete = false;
	}

	public void SetGiveItem(ItemPile items, GameObject targetObject, IItemInteractionCallback callback)
	{
		_currentActionType = InteractionType.GiveItem;
		_callback = callback;
		_interactionObject = targetObject;
		_interactionPosition = UnityUtils.GetNearestPositionOnCollider(targetObject, _controller.transform.position, _controller.pickupLayers);
		_currentInteractionDistance = _interactionRange;
		_activeItem = items;
	}

	public void SetInteractWithItem(IInteractable target, float interactionDistanceOverride = 0f)
	{
		_currentInteractionDistance = ((interactionDistanceOverride == 0f) ? _interactionRange : interactionDistanceOverride);
		_currentActionType = InteractionType.MoveToThenInteract;
		UnityUtils.TryGetGameObjectFromInterface(target as Component, out var gameObject);
		_interactionObject = gameObject;
		_interactionPosition = target.GetInteractionPosition(_controller.transform.position);
	}

	private void SetMovementTowardsItem()
	{
		_controller.MoveCharacterToPosition(_interactionPosition, moveSpeed);
	}

	private State InteractWithItem()
	{
		_interactionComplete = true;
		isInterruptable = false;
		switch (_currentActionType)
		{
		case InteractionType.PickUpItem:
			_controller.StopCharacter();
			return PickupItem();
		case InteractionType.DropItemFromInventory:
			DropItem();
			break;
		case InteractionType.GiveItem:
			return GiveItem();
		case InteractionType.MoveToThenInteract:
			_controller.StopCharacter();
			if (_mainMenu.CurrentMenu != GameMenusEnum.CRAFTING)
			{
				_interactionObject.GetComponent<IInteractable>().PlayerInteraction(_controller, UserActions.INTERACT);
				return _moveState;
			}
			break;
		}
		return _moveState;
	}

	protected virtual State PickupItem()
	{
		if (_interactionObject == null)
		{
			return _moveState;
		}
		int layer = _interactionObject.layer;
		if (layer.Equals(Layers.COLLECTABLE) || layer.Equals(Layers.ITEM_ON_GROUND) || layer.Equals(Layers.PROJECTILE))
		{
			InteractableItem component = _interactionObject.GetComponent<InteractableItem>();
			HandlePickupItem(component);
		}
		else if (layer.Equals(Layers.MOB) && !_interactionObject.CompareTag(Tags.STUNNED_MOB) && _interactionObject.CompareTag(Tags.PLAYER_MOB))
		{
			InteractableItem component2 = _interactionObject.GetComponent<InteractableItem>();
			HandlePickupItem(component2);
		}
		return _moveState;
	}

	private void DropItem()
	{
		Vector3 position = _controller.transform.position;
		position.y = 0f;
		if (Physics.OverlapSphereNonAlloc(position, 0.2f, _hitBuffer, Layers.BUILDING_MASK | Layers.COLLECTABLE_MASK) != 0)
		{
			return;
		}
		int num = (_activeItem.item.dropSingle ? 1 : _activeItem.count);
		if (_activeItem.item is AdvancedItem)
		{
			_activeItem.item.DropItem(position, null, num, autoCollect: true);
		}
		else
		{
			AutomationCoreItem automationCoreItem = _autoSystem.CoreItemFactory.Create(new CoreItemParams(_activeItem.item.itemID, num, position));
			if (_activeItem.item.coreItemAssetOverride.RuntimeKeyIsValid())
			{
				automationCoreItem.SetDisplayAsset(_activeItem.item.coreItemAssetOverride);
			}
			_autoSystem.TryAddCoreItemToSpace(position, automationCoreItem);
		}
		if (_callback != null)
		{
			_callback.Success(_activeItem, num);
		}
		_activeItem = null;
	}

	protected virtual State GiveItem()
	{
		_currentActionType = InteractionType.GiveItem;
		ItemContainer component = _interactionObject.GetComponent<ItemContainer>();
		if (component != null)
		{
			int affectedCount = component.Add(_activeItem);
			if (_callback != null)
			{
				_callback.Success(_activeItem, affectedCount);
			}
			_controller.SetCharacterIdle();
		}
		return _moveState;
	}

	private void ResetTimers()
	{
		_nextValidTime = Time.time + exitDelay;
		_stateTimer = _minStateTime - exitDelay;
	}

	private bool IsTargetInInteractionRange()
	{
		InteractionType currentActionType = _currentActionType;
		if ((uint)currentActionType <= 3u)
		{
			return Vector3.Distance(_controller.transform.position, _interactionPosition) < _currentInteractionDistance;
		}
		throw new UnityException("Trying to perform Interaction type that is not expected.");
	}

	public bool HandlePickupItem(InteractableItem itemToPickUp)
	{
		bool result = false;
		int amount = _inventory.Add(itemToPickUp.itemPile);
		itemToPickUp.ReduceCount(amount);
		if (itemToPickUp.itemPile.count == 0)
		{
			_sounds.PlayOneShot(AutomationGameSoundEnum.ITEM_PICKUP, _controller.transform.position);
			itemToPickUp.gameObject.CompletePickupActions();
			_sounds.PlayOneShot(pickupSoundRef, itemToPickUp.transform.position);
			_interactionObject = null;
			result = true;
		}
		return result;
	}
}
