using System.Collections.Generic;
using Isto.Core.Inputs;
using Isto.Core.Items;
using Isto.Core.StateMachine;
using UnityEngine;

namespace Isto.Core.Beings;

[CreateAssetMenu(fileName = "New Player Dismantle State", menuName = "Scriptables/State/Player Dismantle State")]
public class PlayerDismantleState : PlayerPlaceItemBaseState
{
	public static readonly UserActions DismantleInput = UserActions.DISMANTLE;

	[Range(0.5f, 3f)]
	[Tooltip("Magic number to line up perceived mouse travel with displacement line progression. 1 is neutral.")]
	public float dragAggressivity = 2f;

	private Stack<ItemPlacementController> _placedErasersChain;

	private Vector3 _groundPosition;

	private Vector3 _mouseWorldPosition;

	private Vector3 _dragDelta;

	private Vector3 _projectionOnPlacementDirection;

	private Vector3 _playerStartOfDragPos = Vector3.zero;

	public override void Enter(ScriptableStateMachine playerController)
	{
		base.Enter(playerController);
		if (_placedErasersChain == null)
		{
			_placedErasersChain = new Stack<ItemPlacementController>();
		}
	}

	public override void Exit(ScriptableStateMachine playerController)
	{
		if (_placedErasersChain.Count == 0 && _placementControl != null && _placementControl.GetComponent<Eraser>().EraseTarget != null)
		{
			_placedErasersChain.Push(_placementControl);
		}
		ApplyEraserToSelection();
		base.Exit(playerController);
	}

	public override IState Run(ScriptableStateMachine playerController)
	{
		UpdatePlayerMovement();
		if (base.IsSpawning)
		{
			return this;
		}
		SetObjectPosition();
		_playerController.ItemInteraction.ProcessInputForEquippedItems();
		return _playerController.CurrentState;
	}

	public override void SetupItemDrop(CoreItem dropItem)
	{
		if (base.IsRunning)
		{
			_placementControl?.CancelDrop(exitFromPlacement: false);
		}
		base.SetupItemDrop(dropItem);
	}

	protected override Vector3 GetStartingPositionForDrop()
	{
		Vector3 result = base.GetStartingPositionForDrop();
		GameObject activeInteractableGameObject = _playerInteraction.ActiveInteractableGameObject;
		if (!activeInteractableGameObject.IsNullOrDestroyed() && (base.IsFirstDrop || Controls.UsingController))
		{
			ISpecialPositioning component = activeInteractableGameObject.GetComponent<ISpecialPositioning>();
			if (component != null)
			{
				Vector3 positionOffset = component.GetPositionOffset();
				result = activeInteractableGameObject.transform.position + positionOffset;
			}
			else
			{
				result = activeInteractableGameObject.transform.position;
			}
		}
		return result;
	}

	protected override void CompleteItemInitialization(GameObject createdObject)
	{
		base.CompleteItemInitialization(createdObject);
		_placementControl.enabled = true;
		if (!createdObject.activeSelf)
		{
			createdObject.SetActive(value: true);
		}
	}

	public override void SetDropComplete(bool stopDropping, bool wasCancelled = false)
	{
		if (_placementControl != null)
		{
			_placedErasersChain.Push(_placementControl);
		}
		if (!_controls.GetButton(DismantleInput))
		{
			stopDropping = true;
		}
		base.SetDropComplete(stopDropping);
	}

	protected override void StartNewDrop()
	{
		_placementControl = null;
		_dropItemTrans = null;
		SetupItemDrop(_itemToDrop);
	}

	protected override void SetObjectPositionWithMouse()
	{
		if (_controls.GetPointerOverUI() || _dropItemTrans == null)
		{
			return;
		}
		if (base.IsFirstDrop)
		{
			_groundPosition = _playerInteraction.ActiveInteractableGameObject.transform.position;
			ISpecialPositioning component = _playerInteraction.ActiveInteractableGameObject.GetComponent<ISpecialPositioning>();
			if (component != null)
			{
				Vector3 positionOffset = component.GetPositionOffset();
				_groundPosition += positionOffset;
			}
			_lastdragDirection = Vector3.zero;
			_dropItemTrans.position = _groundPosition.GetSnappedPosition(_itemToDrop.gridSnapSize);
		}
		else if (_controls.GetButton(DismantleInput) && base.IsPlacingInitialized)
		{
			SetObjectPositionWithMouseDrag();
		}
		else
		{
			_lastdragDirection = Vector3.zero;
			_groundPosition = _controls.GetPointerPositionOnGround() + pointerOffset;
			_dropItemTrans.position = _groundPosition.GetSnappedPosition(_itemToDrop.gridSnapSize);
		}
	}

	private void SetObjectPositionWithMouseDrag()
	{
		if (_lastdragDirection == Vector3.zero)
		{
			_currentMouseObjectPosition = _groundPosition;
			Vector3 mouseScreenDragDirection = GetMouseScreenDragDirection();
			if (mouseScreenDragDirection != Vector3.zero)
			{
				_lastdragDirection = mouseScreenDragDirection;
			}
			return;
		}
		_mouseWorldPosition = _controls.GetPointerPositionOnGround();
		_dragDelta = _mouseWorldPosition - _lastClickWorldPosition;
		_projectionOnPlacementDirection = Vector3.Project(_dragDelta, _lastdragDirection) * dragAggressivity;
		Vector3 vector;
		if (_projectionOnPlacementDirection.sqrMagnitude < 1f)
		{
			vector = _lastDropPosition.Value;
		}
		else
		{
			vector = _lastDropPosition.Value + _projectionOnPlacementDirection.normalized;
			Vector3 vector2 = _camControl.MainCamera.WorldToScreenPoint(_lastDropPosition.Value);
			vector2.z = 0f;
			Vector3 vector3 = _camControl.MainCamera.WorldToScreenPoint(vector);
			vector3.z = 0f;
			Vector3 value = vector3 - vector2;
			_lastClickPosition += value;
			_lastClickWorldPosition += _projectionOnPlacementDirection.normalized;
		}
		_currentMouseObjectPosition = vector;
		_dropItemTrans.position = _currentMouseObjectPosition.GetSnappedPosition(_itemToDrop.gridSnapSize);
		_lastDropPosition = _dropItemTrans.position;
	}

	protected override void SetObjectPositionWithController()
	{
		if (base.IsPlacingInitialized)
		{
			if (_controls.GetButton(DismantleInput))
			{
				SetObjectPositionWithControllerDrag();
			}
			else
			{
				SetFlowState(PlacementFlowStates.Inactive);
			}
		}
		else
		{
			_lastdragDirection = Vector3.zero;
			SetObjectPositionWithControllerNormal();
		}
	}

	protected void SetObjectPositionWithControllerNormal()
	{
		Vector3 position = ComputeObjectPositionFromControllerInput();
		_dropItemTrans.position = position;
	}

	private void SetObjectPositionWithControllerDrag()
	{
		float axis = _controls.GetAxis(Controls.MovementAxis.MoveHorizontal);
		float axis2 = _controls.GetAxis(Controls.MovementAxis.MoveVertical);
		Vector3 nearestAxisDirection = UnityUtils.GetNearestAxisDirection(UnityUtils.ConvertScreenVectorToIsometric(axis, axis2));
		ComputeObjectPositionFromControllerInput();
		if (_lastdragDirection == Vector3.zero)
		{
			if (nearestAxisDirection != Vector3.zero)
			{
				_lastdragDirection = nearestAxisDirection;
			}
			ISpecialPositioning component = _playerInteraction.ActiveInteractableGameObject.GetComponent<ISpecialPositioning>();
			if (component != null)
			{
				Vector3 positionOffset = component.GetPositionOffset();
				_lastDropPosition += positionOffset;
				Vector3 automationPosition = component.GetAutomationPosition();
				Debug.Log($"PlayerDismantleState: Is Pushback, eraser A is at {_lastDropPosition}");
				Debug.Log($"PlayerDismantleState: Is Pushback, eraser B is at {automationPosition}");
			}
			else
			{
				Debug.Log($"PlayerDismantleState: Is nonp, eraser A is at {_lastDropPosition.Value}");
			}
			_dropItemTrans.position = _lastDropPosition.Value;
			_playerStartOfDragPos = _playerController.transform.position;
			_automation.GetOrCreateGridSpace(_playerStartOfDragPos);
			_automation.GetOrCreateGridSpace(_dropItemTrans.position);
		}
		else
		{
			Vector3 vector = Vector3.Project(_playerController.transform.position - _playerStartOfDragPos, _lastdragDirection);
			Vector3 position;
			if (vector.sqrMagnitude < 1f)
			{
				position = _lastDropPosition.Value;
			}
			else
			{
				position = _lastDropPosition.Value + vector.normalized;
				_playerStartOfDragPos = _playerController.transform.position;
			}
			_dropItemTrans.position = position.GetSnappedPosition(_itemToDrop.gridSnapSize);
			_lastDropPosition = _dropItemTrans.position;
		}
	}

	private Vector3 ComputeObjectPositionFromControllerInput()
	{
		if (_dropItemTrans.position == Vector3.zero)
		{
			_dropItemTrans.position = _lastDropPosition.Value;
		}
		if (_dropItemTrans.position == Vector3.zero)
		{
			Debug.LogError("_dropItemTrans.position is zero!");
		}
		return _dropItemTrans.position;
	}

	private void ApplyEraserToSelection()
	{
		Eraser eraser = null;
		foreach (ItemPlacementController item in _placedErasersChain)
		{
			if (!item.IsNullOrDestroyed())
			{
				Eraser component = item.GetComponent<Eraser>();
				if (!(component == null) && !(component.EraseTarget == null) && (eraser == null || (component.transform.position - _playerController.transform.position).sqrMagnitude < (eraser.transform.position - _playerController.transform.position).sqrMagnitude))
				{
					eraser = component;
				}
			}
		}
		foreach (ItemPlacementController item2 in _placedErasersChain)
		{
			if (!item2.IsNullOrDestroyed())
			{
				Eraser component2 = item2.GetComponent<Eraser>();
				if (!(component2 == null) && !(component2.EraseTarget == null))
				{
					item2.GetComponent<EraseCompleteState>().FinishRemoval(component2 != eraser);
				}
			}
		}
		_placedErasersChain.Clear();
	}

	public void TryPartialDismantleRollback(ItemPlacementController targetRecoverPosition)
	{
		if (_placedErasersChain.Contains(targetRecoverPosition))
		{
			while (_placedErasersChain.Peek() != targetRecoverPosition)
			{
				ItemPlacementController itemPlacementController = _placedErasersChain.Pop();
				Eraser.UnreadyObjectForDismantling(itemPlacementController.GetComponent<Eraser>().EraseTarget.gameObject);
				_pooledItemFactory?.ReturnPooledAdvancedItem(itemPlacementController.GetComponent<PooledInteractableItem>());
				_lastDropPosition = Vector3.Scale(targetRecoverPosition.transform.position, new Vector3(1f, 0f, 1f));
			}
		}
		else
		{
			Debug.LogWarning("TryPartialDismantleRollback couldn't find proposed target in the eraser stack");
		}
	}

	public void AbortAllDismantling()
	{
		if (_placementControl != null)
		{
			if (_placementControl.GetComponent<Eraser>().EraseTarget != null)
			{
				_placedErasersChain.Push(_placementControl);
			}
			else
			{
				_placementControl.CancelDrop(exitFromPlacement: false);
			}
			_placementControl = null;
		}
		foreach (ItemPlacementController item in _placedErasersChain)
		{
			Eraser component = item.GetComponent<Eraser>();
			if (!component.EraseTarget.IsNullOrDestroyed())
			{
				Eraser.UnreadyObjectForDismantling(component.EraseTarget.gameObject);
				_pooledItemFactory?.ReturnPooledAdvancedItem(item.GetComponent<PooledInteractableItem>());
			}
		}
		_placedErasersChain.Clear();
	}

	public void DrawGizmos()
	{
		if (base.IsRunning && !(_lastdragDirection == Vector3.zero))
		{
			Gizmos.color = Color.cyan;
			Gizmos.DrawLine(_lastClickWorldPosition, _mouseWorldPosition);
			Gizmos.color = Color.red;
			Gizmos.DrawLine(_lastDropPosition.Value, _groundPosition);
			Gizmos.color = Color.white;
			Gizmos.DrawLine(_lastDropPosition.Value, _lastDropPosition.Value + _projectionOnPlacementDirection);
		}
	}
}
