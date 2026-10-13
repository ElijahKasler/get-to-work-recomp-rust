using System;
using System.Collections.Generic;
using Isto.Core.Automation;
using Isto.Core.Cameras;
using Isto.Core.Inputs;
using Isto.Core.Items;
using Isto.Core.Pooling;
using Isto.Core.StateMachine;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceLocations;
using Zenject;

namespace Isto.Core.Beings;

public abstract class PlayerPlaceItemBaseState : State
{
	protected enum PlacementFlowStates
	{
		Inactive = 0,
		WaitingForFirstSpawn = 1,
		PlacingFirstItem = 2,
		WaitingForNextSpawn = 3,
		PlacingNextItem = 4
	}

	public float moveSpeed;

	[Tooltip("Time per grid move when moving item with the controller")]
	public float controllerItemMoveDelay = 0.1f;

	public float controllerAxisDeadZone = 0.25f;

	[Tooltip("Offset to center object in grid space with mouse")]
	public Vector3 pointerOffset = new Vector3(-0.75f, 0f, 0.75f);

	public float itemMoveDelta = 0.75f;

	public float minDragThreshold = 0.75f;

	[Range(0f, 1f)]
	[Tooltip("How far the mouse can go before a drag gets recorded")]
	public float minDragScreenHeightPercent = 0.05f;

	public static int PlacementCount;

	protected ItemPlacementController _placementControl;

	protected Vector3 _lastdragDirection;

	protected Vector3 _itemRelativePosition = Vector3.zero;

	protected Vector3 _currentMouseObjectPosition;

	protected Vector3? _lastDropPosition;

	protected Vector3? _lastClickPosition;

	protected Vector3 _lastClickWorldPosition;

	protected ItemPlacement _placement;

	protected AdvancedItem _itemToDrop;

	protected Transform _dropItemTrans;

	protected PlacementFlowStates _currentFlowState;

	protected bool _dropComplete;

	protected IControls _controls;

	protected PlayerItemInteraction _playerInteraction;

	protected PlayerInventory _playerInventory;

	protected CameraController _camControl;

	protected DiContainer _diContainer;

	protected PooledItemFactory _pooledItemFactory;

	protected AutomationSystem _automation;

	protected AutomationPlayerController _playerController;

	public bool IsDragging => _lastdragDirection != Vector3.zero;

	public bool IsRunning { get; private set; }

	public bool IsSpawning
	{
		get
		{
			if (_currentFlowState != PlacementFlowStates.WaitingForFirstSpawn)
			{
				return _currentFlowState == PlacementFlowStates.WaitingForNextSpawn;
			}
			return true;
		}
	}

	protected bool IsFirstDrop => _currentFlowState < PlacementFlowStates.WaitingForNextSpawn;

	protected bool IsPlacingInitialized => _currentFlowState >= PlacementFlowStates.PlacingFirstItem;

	public ItemPlacementController CurrentItem => _placementControl;

	public event EventHandler<ItemEventArgs> ItemPlaced;

	[Inject]
	public void Inject(IControls controls, PlayerItemInteraction interaction, PlayerInventory playerInventory, AutomationPlayerController playerController, CameraController camControl, DiContainer diContainer, [InjectOptional] PooledItemFactory pooledItemFactory, AutomationSystem automation)
	{
		_controls = controls;
		_playerInteraction = interaction;
		_playerInventory = playerInventory;
		_camControl = camControl;
		_diContainer = diContainer;
		_pooledItemFactory = pooledItemFactory;
		_automation = automation;
		_playerController = playerController;
		IsRunning = false;
	}

	public override void Enter(ScriptableStateMachine controller)
	{
		IsRunning = true;
		_playerController.SetMoveSpeed(moveSpeed);
		_playerInteraction.AllowInteractions(allow: false);
	}

	public override void Exit(ScriptableStateMachine controller)
	{
		IsRunning = false;
		SetFlowState(PlacementFlowStates.Inactive);
		_placementControl?.CancelDrop(exitFromPlacement: false);
		_placementControl = null;
		_dropItemTrans = null;
		_lastDropPosition = null;
		_lastClickPosition = null;
		_controls.SetControlMode(Controls.Mode.Gameplay);
		_controls.DisableControls(Constants.BUTTON_SPAM_DELAY);
		_playerInteraction.AllowInteractions(allow: true);
		_lastdragDirection = Vector3.zero;
		_lastClickPosition = null;
	}

	protected void UpdatePlayerMovement()
	{
		if (!_playerController.IsMoving)
		{
			_playerController.SetCharacterIdle();
		}
		MovePlayer();
	}

	private void MovePlayer()
	{
		float axis = _controls.GetAxis(Controls.MovementAxis.MoveHorizontal);
		float axis2 = _controls.GetAxis(Controls.MovementAxis.MoveVertical);
		if (axis != 0f || axis2 != 0f)
		{
			_playerController.MoveCharacter(axis, axis2);
		}
	}

	public virtual void SetupItemDrop(CoreItem dropItem)
	{
		switch (_currentFlowState)
		{
		case PlacementFlowStates.Inactive:
			SetFlowState(PlacementFlowStates.WaitingForFirstSpawn);
			break;
		case PlacementFlowStates.PlacingFirstItem:
		case PlacementFlowStates.PlacingNextItem:
			SetFlowState(PlacementFlowStates.WaitingForNextSpawn);
			break;
		default:
			Debug.LogError($"Unexpected PlacementFlowState {_currentFlowState} during SetupItemDrop");
			_playerController.ChangeToMoveState();
			break;
		case PlacementFlowStates.WaitingForFirstSpawn:
			break;
		}
		_itemToDrop = dropItem as AdvancedItem;
		_dropItemTrans = null;
		Vector3 dropPosition = GetStartingPositionForDrop();
		GameObject gameObject = _pooledItemFactory?.GetPooledItem(_itemToDrop);
		if (gameObject != null)
		{
			AdvancedItem.InitializeNewItem(gameObject, activateNow: false);
			CompleteItemInitialization(gameObject);
		}
		else if (!string.IsNullOrEmpty(dropItem.addressableAsset.AssetGUID))
		{
			AsyncOperationHandle<IList<IResourceLocation>> asyncOperationHandle = Addressables.LoadResourceLocationsAsync(dropItem.addressableAsset);
			asyncOperationHandle.Completed += (AsyncOperationHandle<IList<IResourceLocation>> op) =>
			{
				if (op.Result != null && op.Result.Count > 0)
				{
					AsyncOperationHandle<GameObject> asyncOperationHandle2 = dropItem.addressableAsset.InstantiateAsync(dropPosition + Vector3.up * 1000f, Quaternion.identity);
					asyncOperationHandle2.Completed += (AsyncOperationHandle<GameObject> asyncOperationHandle3) =>
					{
						if (asyncOperationHandle3.Status == AsyncOperationStatus.Succeeded)
						{
							GameObject result = asyncOperationHandle3.Result;
							result.name += $"{PlacementCount++:D4}";
							if (PlacementCount > 9999)
							{
								PlacementCount = 0;
							}
							AdvancedItem.InitializeNewItem(result, activateNow: false);
							CompleteItemInitialization(result);
						}
					};
				}
				else
				{
					Debug.LogError("Cannot find item " + dropItem.itemID + " with key " + dropItem.addressableAsset.RuntimeKey.ToString());
				}
			};
		}
		else
		{
			Debug.LogWarning("No valid AddressableAsset GUID for " + dropItem.itemName + ". Cannot drop");
		}
	}

	protected virtual Vector3 GetStartingPositionForDrop()
	{
		if (!_lastDropPosition.HasValue)
		{
			if (!_controls.UsingJoystick())
			{
				Vector3 valueOrDefault = _lastClickPosition.GetValueOrDefault();
				if (!_lastClickPosition.HasValue)
				{
					valueOrDefault = _controls.GetPointerPosition();
					_lastClickPosition = valueOrDefault;
				}
				if (Physics.Raycast(Camera.main.ScreenPointToRay(_lastClickPosition.Value), out var hitInfo, 2000f, Layers.GROUND_LAYERS_MASK))
				{
					_lastClickWorldPosition = hitInfo.point;
				}
				_lastDropPosition = _controls.GetPointerPositionOnGround() + pointerOffset;
			}
			else
			{
				_lastDropPosition = _playerInteraction.ActiveInteractableGameObject.transform.position;
			}
		}
		return _lastDropPosition.Value;
	}

	protected virtual void CompleteItemInitialization(GameObject createdObject)
	{
		_dropItemTrans = createdObject.transform;
		_placementControl = createdObject.GetComponent<ItemPlacementController>();
		if (_placementControl == null)
		{
			Debug.LogError("Trying to drop " + createdObject.name + " advanced item that does not have a ItemPlacement component.  Please correct this");
			return;
		}
		switch (_currentFlowState)
		{
		case PlacementFlowStates.WaitingForFirstSpawn:
		{
			_placementControl.IsFirstOfFastPlacement = true;
			_lastdragDirection = Vector3.zero;
			Vector3 startingPositionForDrop = GetStartingPositionForDrop();
			_dropItemTrans.position = startingPositionForDrop.GetSnappedPosition(_itemToDrop.gridSnapSize);
			SetFlowState(PlacementFlowStates.PlacingFirstItem);
			break;
		}
		case PlacementFlowStates.WaitingForNextSpawn:
			SetFlowState(PlacementFlowStates.PlacingNextItem);
			break;
		default:
			Debug.LogError($"Unexpected PlacementFlowState {_currentFlowState} during CompleteItemInitialization");
			break;
		}
	}

	public void SendItemPlacedEvent()
	{
		ItemPlaced?.Invoke(this, new ItemEventArgs(null, _itemToDrop, 1, _placementControl));
	}

	public virtual void SetDropComplete(bool stopDropping, bool wasCancelled = false)
	{
		if (stopDropping)
		{
			_placementControl = null;
			_dropItemTrans = null;
			_lastDropPosition = null;
			_lastClickPosition = null;
			_controls.SetControlMode(Controls.Mode.Gameplay);
			_playerController.ChangeToMoveState();
		}
		else
		{
			_lastDropPosition = Vector3.Scale(_dropItemTrans.position, new Vector3(1f, 0f, 1f));
			StartNewDrop();
		}
	}

	protected abstract void StartNewDrop();

	public virtual void SetMovementState(bool active)
	{
		_playerController.SetPlayerPauseState(!active);
	}

	[ContextMenu("Force Cancel Drop")]
	public void ForceCancelDrop()
	{
		if (IsRunning && _placementControl != null)
		{
			_placementControl.CancelDrop();
		}
	}

	protected virtual void SetObjectPosition()
	{
		if (!_controls.UsingJoystick())
		{
			SetObjectPositionWithMouse();
		}
		else
		{
			SetObjectPositionWithController();
		}
	}

	protected abstract void SetObjectPositionWithMouse();

	protected abstract void SetObjectPositionWithController();

	protected Vector3 GetMouseGroundDragDirection(Vector3 mouseGroundPosition)
	{
		Vector3 direction = mouseGroundPosition - _lastDropPosition.Value;
		if (direction.sqrMagnitude < Mathf.Pow(minDragThreshold, 2f))
		{
			return Vector3.zero;
		}
		return UnityUtils.GetNearestAxisDirection(direction);
	}

	protected Vector3 GetMouseScreenDragDirection()
	{
		Vector2 vector = (Vector3)_controls.GetPointerPosition() - _lastClickPosition.Value;
		float f = (float)Screen.height * minDragScreenHeightPercent;
		if (vector.sqrMagnitude < Mathf.Pow(f, 2f))
		{
			return Vector3.zero;
		}
		return UnityUtils.GetNearestAxisDirection(_camControl.MainCamera.cameraToWorldMatrix.MultiplyVector(vector));
	}

	protected void SetFlowState(PlacementFlowStates nextState)
	{
		_currentFlowState = nextState;
	}

	protected void TryTransitionFlowState(PlacementFlowStates from, PlacementFlowStates to)
	{
		if (_currentFlowState == from)
		{
			SetFlowState(to);
		}
	}
}
