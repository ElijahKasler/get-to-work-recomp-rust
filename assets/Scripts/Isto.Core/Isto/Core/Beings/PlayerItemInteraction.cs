using System;
using System.Collections.Generic;
using System.Linq;
using Isto.Core.Automation;
using Isto.Core.Inputs;
using Isto.Core.Items;
using UnityEngine;
using Zenject;

namespace Isto.Core.Beings;

public class PlayerItemInteraction : MonoBehaviour, IItemInteractionCallback
{
	[Serializable]
	public class InteractibleMetaData
	{
		public string name;

		public GameObject gameObject;

		public IInteractable interactable;

		public float distance;

		public int priority;

		public void Set(GameObject gameObject, IInteractable interactableScript, float distance)
		{
			this.gameObject = gameObject;
			name = gameObject.name;
			interactable = interactableScript;
			this.distance = distance;
			priority = GetPriority(gameObject);
		}
	}

	[Tooltip("Search range to look for item when pickup button is pressed.  Will move towards item.")]
	public float searchRange = 4f;

	[Tooltip("Adjusts the position of the search in the forward direction of the player this distance.  Causes items in front of player to be closer than ones behind.  ONLY WITH CONTROLLER")]
	public float forwardSearchBias = 1f;

	[Tooltip("How big of a circle around the mouse will be considered under the mouse.")]
	public float mouseSearchRadius = 1f;

	public EventHandler<ItemEventArgs> EquipppedItemUsed;

	[SerializeField]
	private List<InteractibleMetaData> _interactablesAtSelectionPosition = new List<InteractibleMetaData>();

	private int bufferSize = 16;

	private float _spamTimer;

	private Collider[] _hitBuffer;

	private RaycastHit[] _raycastHitBuffer;

	private IInteractable _selectedInteractable;

	private List<UserActions> _actionList;

	private bool _showToolTips = true;

	private bool _allowInteractions = true;

	private LayerMask _interactionLayers;

	private bool _interactionOccured;

	private IControls _controls;

	private AutomationPlayerController _player;

	private PlayerInventory _inventory;

	private Transform _selectionHighlight;

	private AutomationSystem _automationSystem;

	private Vector3 forwardDirection = Vector3.zero;

	public GameObject NearestInteractableGameObject
	{
		get
		{
			UnityUtils.TryGetGameObjectFromInterface(_selectedInteractable as Component, out var result);
			return result;
		}
	}

	public IInteractable NearestInteractable => _selectedInteractable;

	public GameObject ActiveInteractableGameObject
	{
		get
		{
			UnityUtils.TryGetGameObjectFromInterface(ActiveInteractable as Component, out var result);
			return result;
		}
	}

	public IInteractable ActiveInteractable { get; private set; }

	public GameObject ActiveObject { get; private set; }

	public int CurrentEquippedItemSlot { get; set; }

	[Inject]
	public void Inject(IControls controls, AutomationPlayerController playerController, PlayerInventory inventory, [InjectOptional(Id = "SelectionHighlight")] Transform selectionHighlight, AutomationSystem automationSystem)
	{
		_controls = controls;
		_player = playerController;
		_inventory = inventory;
		_selectionHighlight = selectionHighlight;
		_automationSystem = automationSystem;
	}

	private void Awake()
	{
		_hitBuffer = new Collider[bufferSize];
		_raycastHitBuffer = new RaycastHit[bufferSize];
		_interactionLayers = _player.pickupLayers;
		_selectionHighlight?.gameObject.SetActive(value: false);
	}

	private void OnEnable()
	{
		Events.Subscribe("PlayerInventoryChanged", OnPlayerInventoryChanged);
	}

	private void OnDisable()
	{
		Events.UnSubscribe("PlayerInventoryChanged", OnPlayerInventoryChanged);
	}

	private void Update()
	{
		_spamTimer += Time.deltaTime;
		if (_controls.GetControlMode() == Controls.Mode.Gameplay && _allowInteractions)
		{
			UpdateInteractableAndSetActive();
		}
	}

	public bool ProcessInput()
	{
		_interactionOccured = false;
		for (int i = 0; i < _interactablesAtSelectionPosition.Count; i++)
		{
			IInteractable interactable = _interactablesAtSelectionPosition[i].interactable;
			_actionList = interactable.GetValidActions();
			for (int j = 0; j < _actionList.Count; j++)
			{
				_interactionOccured = (_controls.UsingJoystick() ? CheckControllerInput(_actionList[j], interactable) : HandleKeyboardInput(_actionList[j], interactable));
				if (_interactionOccured)
				{
					break;
				}
			}
			if (_interactionOccured)
			{
				break;
			}
		}
		ProcessInputForEquippedItems();
		return _interactionOccured;
	}

	public void ProcessInputForEquippedItems()
	{
		if (_controls.UsingJoystick())
		{
			_interactionOccured |= CheckControllerInput(UserActions.USEMAINEQUIPPEDITEM, null);
			_interactionOccured |= CheckControllerInput(UserActions.USESECONDARYEQUIPPEDITEM, null);
			return;
		}
		_interactionOccured |= HandleKeyboardInput(UserActions.USEEQUIPPEDITEM1, null);
		_interactionOccured |= HandleKeyboardInput(UserActions.USEEQUIPPEDITEM2, null);
		_interactionOccured |= HandleKeyboardInput(UserActions.USEEQUIPPEDITEM3, null);
		_interactionOccured |= HandleKeyboardInput(UserActions.USEEQUIPPEDITEM4, null);
		_interactionOccured |= HandleKeyboardInput(UserActions.USEEQUIPPEDITEM5, null);
		_interactionOccured |= HandleKeyboardInput(UserActions.USEEQUIPPEDITEM6, null);
		_interactionOccured |= HandleKeyboardInput(UserActions.USEEQUIPPEDITEM7, null);
		_interactionOccured |= HandleKeyboardInput(UserActions.USEEQUIPPEDITEM8, null);
	}

	private void UpdateInteractableAndSetActive()
	{
		if (!_controls.UsingJoystick() || !_controls.GetButton(UserActions.INTERACT) || _selectedInteractable.IsNullOrDestroyed())
		{
			IInteractable interactable = ((!_controls.UsingJoystick()) ? GetItemUnderMouse() : GetNearestItem());
			if (!_selectedInteractable.IsNullOrDestroyed() && _selectedInteractable != interactable)
			{
				_selectedInteractable.SetInactive();
			}
			_selectedInteractable = interactable;
			if (!_selectedInteractable.IsNullOrDestroyed() && _showToolTips)
			{
				_selectedInteractable.ShowTooltip();
			}
		}
	}

	private bool CheckControllerInput(UserActions action, IInteractable interactable)
	{
		if (_spamTimer > 0f && _controls.GetButton(action))
		{
			switch (action.Name)
			{
			case "INTERACT":
				if (_controls.GetButtonDown(action))
				{
					interactable.PlayerInteraction(_player, action);
				}
				break;
			case "DISMANTLE":
				if (_controls.GetButtonDown(action))
				{
					ActiveInteractable = interactable;
					EnterDismantlingMode();
				}
				break;
			case "GIVEITEM":
				ActiveInteractable = interactable;
				ActiveObject = ((MonoBehaviour)interactable).GetComponentInParent<IItemTopmostParent>().GetGameObject();
				interactable.PlayerInteraction(_player, action);
				break;
			case "USEMAINEQUIPPEDITEM":
			case "USESECONDARYEQUIPPEDITEM":
				if (_controls.GetButtonDown(action))
				{
					HandleUseEquippedItem(action);
				}
				break;
			default:
				Debug.LogWarning("No handler in HandleControllerInput for action: " + action);
				break;
			case "USEITEM":
			case "DROPITEM":
				break;
			}
			_spamTimer = 0f - Constants.BUTTON_SPAM_DELAY;
			return true;
		}
		return false;
	}

	private bool HandleKeyboardInput(UserActions action, IInteractable interactable)
	{
		if (_controls.GetButtonDown(action))
		{
			ActiveInteractable = interactable;
			switch (action.Name)
			{
			case "USEEQUIPPEDITEM1":
			case "USEEQUIPPEDITEM2":
			case "USEEQUIPPEDITEM3":
			case "USEEQUIPPEDITEM4":
			case "USEEQUIPPEDITEM5":
			case "USEEQUIPPEDITEM6":
			case "USEEQUIPPEDITEM7":
			case "USEEQUIPPEDITEM8":
				if (_spamTimer > 0f)
				{
					HandleUseEquippedItem(action);
				}
				break;
			case "DISMANTLE":
				EnterDismantlingMode();
				break;
			case "INTERACT":
				interactable.PlayerInteraction(_player, action);
				break;
			case "GIVEITEM":
				interactable.PlayerInteraction(_player, action);
				break;
			}
			_spamTimer = 0f - Constants.BUTTON_SPAM_DELAY;
			return true;
		}
		return false;
	}

	private void EnterDismantlingMode()
	{
		_player.StartDismantling();
	}

	private IInteractable GetNearestItem()
	{
		if (IsMovingTowardsItemAlready())
		{
			return _selectedInteractable;
		}
		Vector3 forward = _player.Forward;
		float axis = _controls.GetAxis(Controls.MovementAxis.MoveHorizontal);
		float axis2 = _controls.GetAxis(Controls.MovementAxis.MoveVertical);
		float num = 0.4f;
		if (Mathf.Abs(axis) > num || Mathf.Abs(axis2) > num)
		{
			Vector3 normalized = UnityUtils.ConvertScreenVectorToIsometric(axis, axis2).normalized;
			forwardDirection = normalized;
		}
		forward = forwardDirection;
		Vector3 vector = _player.transform.position + forward * forwardSearchBias;
		int hitCount = Physics.OverlapSphereNonAlloc(vector, searchRange, _hitBuffer, _interactionLayers);
		return UpdateNearestInteracables(hitCount, vector);
	}

	private bool IsMovingTowardsItemAlready()
	{
		if (_player.CurrentState is PlayerInteractWithItemState)
		{
			return true;
		}
		if (_player.CurrentState is PlayerHarvestState)
		{
			return true;
		}
		return false;
	}

	private IInteractable GetItemUnderMouse()
	{
		Ray rayToPointerPosition = _controls.GetRayToPointerPosition();
		Vector3 fromPosition = ((!Physics.Raycast(rayToPointerPosition, out var hitInfo, 600f, _interactionLayers)) ? _controls.GetPointerPositionOnGround() : hitInfo.point);
		int num = Physics.SphereCastNonAlloc(rayToPointerPosition, mouseSearchRadius, _raycastHitBuffer, 600f, _interactionLayers);
		for (int i = 0; i < num; i++)
		{
			_hitBuffer[i] = _raycastHitBuffer[i].collider;
		}
		return UpdateNearestInteracables(num, fromPosition);
	}

	private IInteractable UpdateNearestInteracables(int hitCount, Vector3 fromPosition)
	{
		_interactablesAtSelectionPosition.Clear();
		if (hitCount == 0)
		{
			return null;
		}
		for (int i = 0; i < hitCount; i++)
		{
			IInteractable interactableScript = _hitBuffer[i].GetComponentInParent<IInteractable>();
			MonoBehaviour monoBehaviour = interactableScript as MonoBehaviour;
			if (!monoBehaviour.IsNullOrDestroyed() && monoBehaviour.enabled)
			{
				GameObject gameObject = monoBehaviour.gameObject;
				float distance = Vector3.Distance(fromPosition, _hitBuffer[i].ClosestPoint(fromPosition));
				if (!_interactablesAtSelectionPosition.Any((InteractibleMetaData x) => x.interactable == interactableScript))
				{
					InteractibleMetaData interactibleMetaData = new InteractibleMetaData();
					interactibleMetaData.Set(gameObject, interactableScript, distance);
					_interactablesAtSelectionPosition.Add(interactibleMetaData);
				}
			}
		}
		if (_interactablesAtSelectionPosition.Count > 0)
		{
			bool flag = _interactablesAtSelectionPosition.Any((InteractibleMetaData x) => x.priority == 1);
			IOrderedEnumerable<InteractibleMetaData> source = ((!(Controls.UsingController | flag)) ? (from x in _interactablesAtSelectionPosition
				orderby x.distance, x.priority
				select x) : (from x in _interactablesAtSelectionPosition
				orderby x.priority, x.distance
				select x));
			_interactablesAtSelectionPosition = source.ToList();
		}
		InteractibleMetaData interactibleMetaData2 = _interactablesAtSelectionPosition.FirstOrDefault();
		if (hitCount > 1 && interactibleMetaData2 != null)
		{
			Vector3 snappedPosition = interactibleMetaData2.gameObject.transform.position.GetSnappedPosition(1f);
			for (int num = _interactablesAtSelectionPosition.Count - 1; num >= 0; num--)
			{
				if (_interactablesAtSelectionPosition[num].gameObject.transform.position.GetSnappedPosition(1f) != snappedPosition)
				{
					_interactablesAtSelectionPosition.RemoveAt(num);
				}
			}
		}
		return interactibleMetaData2?.interactable;
	}

	public void SetShowToolTips(bool show)
	{
		_showToolTips = show;
		if (show && !_selectedInteractable.IsNullOrDestroyed())
		{
			_selectedInteractable.ShowTooltip();
		}
	}

	public void Success(ItemPile interactionItem, int affectedCount)
	{
		if (_inventory.Remove(interactionItem.item, affectedCount) != affectedCount)
		{
			throw new UnityException("Can't remove enough items from inventory as required from item interaction.  This shouldn't happen");
		}
	}

	public void DelayInteraction(float time)
	{
		_spamTimer = 0f - time;
	}

	public void AllowInteractions(bool allow)
	{
		_allowInteractions = allow;
		if (!allow)
		{
			if (_selectedInteractable != null)
			{
				_selectedInteractable.SetInactive();
			}
			_selectedInteractable = null;
		}
	}

	private static bool IsHigherPriority(GameObject newItem, GameObject oldItem)
	{
		if (oldItem == null)
		{
			return true;
		}
		if (newItem == null)
		{
			return false;
		}
		int layer = newItem.layer;
		int layer2 = oldItem.layer;
		if (layer2 == Layers.COLLECTABLE)
		{
			return false;
		}
		if (layer == Layers.COLLECTABLE)
		{
			return true;
		}
		if (layer2 == Layers.HARVESTABLE && IsHarvestableOnPlanter(oldItem))
		{
			return false;
		}
		if (layer == Layers.HARVESTABLE && IsHarvestableOnPlanter(newItem))
		{
			return true;
		}
		if (layer2 == Layers.MOB)
		{
			return false;
		}
		if (layer == Layers.MOB && newItem.CompareTag(Tags.PLAYER_MOB))
		{
			return true;
		}
		if (layer2 == Layers.ITEM_ON_GROUND)
		{
			return false;
		}
		if (layer == Layers.ITEM_ON_GROUND)
		{
			return true;
		}
		if (layer2 == Layers.HARVESTABLE)
		{
			return false;
		}
		if (layer == Layers.HARVESTABLE)
		{
			return true;
		}
		return false;
	}

	private static int GetPriority(GameObject go)
	{
		if (go == null)
		{
			return 7;
		}
		int layer = go.layer;
		if (layer == Layers.HARVESTABLE && IsHarvestableOnPlanter(go))
		{
			return 1;
		}
		if (layer == Layers.COLLECTABLE)
		{
			return 2;
		}
		if (layer == Layers.MOB && go.CompareTag(Tags.PLAYER_MOB))
		{
			return 3;
		}
		if (layer == Layers.ITEM_ON_GROUND)
		{
			return 4;
		}
		if (layer == Layers.HARVESTABLE)
		{
			return 5;
		}
		return 6;
	}

	private static bool IsHarvestableOnPlanter(GameObject go)
	{
		GrowingHarvestableVisuals component = go.GetComponent<GrowingHarvestableVisuals>();
		if (component == null)
		{
			return false;
		}
		return component.IsOnPlanter();
	}

	private void OnPlayerInventoryChanged()
	{
	}

	public void HandleUseEquippedItem(UserActions action)
	{
		if (_controls.GetControlMode() == Controls.Mode.UI)
		{
			return;
		}
		int slotNumber;
		switch (action.Name)
		{
		case "USEEQUIPPEDITEM1":
		case "USEMAINEQUIPPEDITEM":
			slotNumber = 0;
			break;
		case "USEEQUIPPEDITEM2":
			slotNumber = 1;
			break;
		case "USEEQUIPPEDITEM3":
			slotNumber = 2;
			break;
		case "USEEQUIPPEDITEM4":
			slotNumber = 3;
			break;
		case "USEEQUIPPEDITEM5":
			slotNumber = 4;
			break;
		case "USEEQUIPPEDITEM6":
			slotNumber = 5;
			break;
		case "USEEQUIPPEDITEM7":
			slotNumber = 6;
			break;
		case "USEEQUIPPEDITEM8":
			slotNumber = 7;
			break;
		case "USESECONDARYEQUIPPEDITEM":
			slotNumber = CurrentEquippedItemSlot;
			break;
		default:
			throw new UnityException("Invalid UserAction passed to HandleUseEquippedItem.  Action: " + action.ToString());
		}
		ItemPile equippedPile = _inventory.GetEquippedPile(slotNumber);
		if (equippedPile == null || !equippedPile.HasItems() || _inventory.GetCountOfItem(equippedPile.item) <= 0)
		{
			return;
		}
		if (equippedPile.item is AdvancedItem advancedItem)
		{
			if (advancedItem.equipToPlayer)
			{
				_player.EquipItemOnPlayer(advancedItem);
			}
			else
			{
				_player.UseEquippedItem(base.transform.position, equippedPile, this);
			}
		}
		else if (equippedPile.item is UseableItem useableItem)
		{
			useableItem.UseItem(_player.gameObject);
			_inventory.Remove(useableItem);
		}
		else
		{
			_player.UseEquippedItem(base.transform.position, equippedPile, this);
		}
		EquipppedItemUsed?.Invoke(this, new ItemEventArgs(_inventory, equippedPile.item));
	}

	public void OnDrawGizmos()
	{
	}
}
