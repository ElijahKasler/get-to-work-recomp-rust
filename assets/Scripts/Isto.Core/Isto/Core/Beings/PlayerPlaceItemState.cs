using System;
using Isto.Core.Automation;
using Isto.Core.Inputs;
using Isto.Core.Items;
using Isto.Core.StateMachine;
using UnityEngine;

namespace Isto.Core.Beings;

[CreateAssetMenu(fileName = "New Player Place Item State", menuName = "Scriptables/State/Player Place Item State")]
public class PlayerPlaceItemState : PlayerPlaceItemBaseState
{
	public enum PlacementDirection
	{
		None = 0,
		UpRight = 1,
		DownLeft = 2,
		UpLeft = 3,
		DownRight = 4
	}

	public enum MovementDirection
	{
		None = 0,
		Up = 1,
		Down = 2,
		Left = 3,
		Right = 4,
		UpRight = 5,
		UpLeft = 6,
		DownRight = 7,
		DownLeft = 8
	}

	private Vector3 _lastForwardDirection;

	private bool _settingDistance;

	private float _placementIndicatorFadeoutTimer;

	[SerializeField]
	private Transform _placementIndicatorPrefab;

	[Header("Prototype Settings =========================================")]
	[Tooltip("The logic we chose is kept for comparison but it will be removed soon. Activate this flag to use the prorotype logic.")]
	public bool useOriginalPrototypeLogic;

	public bool useDeadZoneForRememberPosition = true;

	[Tooltip("Using this scheme, the movement is always 0 under the deadzone and 1 above it.")]
	public float rememberPositionDeadzone = 0.45f;

	public float movementSpeed = 2f;

	private int _placementRange = 2;

	private Vector3 _itemAnchorPosition = Vector3.zero;

	private SpriteRenderer[] _placementIndicatorRenderers;

	private static readonly PlacementDirection DEFAULT_PLACEMENT_DIRECTION = PlacementDirection.UpLeft;

	[Header("New Placement Settings =========================================")]
	[SerializeField]
	private int _maxTilesToIgnoreForSnap = 3;

	[SerializeField]
	private float _rightStickDeadzone = 0.35f;

	private PlacementDirection _lastUsedDirection;

	private Vector3 _lastUsedPosition = Vector3.zero;

	private Vector3 _lastHintDirection = Vector3.left;

	private Transform _placementPreview;

	private static float quarterPI = MathF.PI / 4f;

	private float cosQuarterPI = Mathf.Cos(quarterPI);

	private float sinQuarterPI = Mathf.Sin(quarterPI);

	public static event Action OnPlacementModeEntered;

	public static event Action OnPlacementModeExited;

	public override void Enter(ScriptableStateMachine playerController)
	{
		base.Enter(playerController);
		_lastForwardDirection = Vector3.zero;
		_lastHintDirection = Vector3.left;
		if (_placementPreview == null && _controls.UsingJoystick())
		{
			Transform placementPreview = UnityEngine.Object.Instantiate(_placementIndicatorPrefab);
			_placementPreview = placementPreview;
			_placementIndicatorRenderers = _placementPreview.GetComponentsInChildren<SpriteRenderer>();
			_placementIndicatorFadeoutTimer = Time.time;
		}
		else
		{
			_placementIndicatorRenderers = new SpriteRenderer[0];
		}
		OnPlacementModeEntered?.Invoke();
	}

	public override void Exit(ScriptableStateMachine playerController)
	{
		OnPlacementModeExited?.Invoke();
		if (_placementPreview != null)
		{
			UnityEngine.Object.Destroy(_placementPreview.gameObject);
			_placementIndicatorRenderers = null;
		}
		base.Exit(playerController);
	}

	public override IState Run(ScriptableStateMachine playerController)
	{
		if (Time.time - _placementIndicatorFadeoutTimer > 2f && !_controls.GetButton(UserActions.INTERACT) && _placementIndicatorRenderers != null)
		{
			SpriteRenderer[] placementIndicatorRenderers = _placementIndicatorRenderers;
			foreach (SpriteRenderer spriteRenderer in placementIndicatorRenderers)
			{
				spriteRenderer.color = spriteRenderer.color.WithAlpha(Mathf.Clamp(spriteRenderer.color.a - Time.deltaTime * 0.5f, 0.2f, 1f));
			}
		}
		UpdatePlayerMovement();
		if (base.IsSpawning)
		{
			return this;
		}
		SetObjectPosition();
		_playerController.ItemInteraction.ProcessInputForEquippedItems();
		State state = _playerController.ProcessMovementAndInteractions(movement: false, ability: true, itemInteraction: false);
		if (!(state != null))
		{
			return _playerController.CurrentState;
		}
		return state;
	}

	public override void SetupItemDrop(CoreItem dropItem)
	{
		if (base.IsRunning)
		{
			_placementControl?.CancelDrop(exitFromPlacement: false);
			if (_itemToDrop != dropItem)
			{
				_itemToDrop = dropItem as AdvancedItem;
				StartNewDrop();
				return;
			}
		}
		base.SetupItemDrop(dropItem);
	}

	protected override void CompleteItemInitialization(GameObject createdObject)
	{
		base.CompleteItemInitialization(createdObject);
		if (_lastForwardDirection == Vector3.zero)
		{
			_lastForwardDirection = _placementControl.Forward;
		}
		_placementControl.SetStartRotation(_lastForwardDirection);
		_placementControl.enabled = true;
		if (!createdObject.activeSelf)
		{
			createdObject.SetActive(value: true);
		}
		if (_currentFlowState != PlacementFlowStates.Inactive)
		{
			ActivateItem();
		}
	}

	public override void SetDropComplete(bool stopDropping, bool wasCancelled = false)
	{
		_settingDistance = false;
		if (!wasCancelled)
		{
			SendItemPlacedEvent();
		}
		base.SetDropComplete(stopDropping);
	}

	public override void SetMovementState(bool active)
	{
		base.SetMovementState(active);
		if (!active)
		{
			_settingDistance = true;
		}
	}

	protected override void StartNewDrop()
	{
		if (_playerInventory.GetCountOfItem(_itemToDrop) > 0)
		{
			_lastForwardDirection = ((_placementControl != null) ? _placementControl.Forward : Vector3.right);
			_placementControl = null;
			_dropItemTrans = null;
			SetupItemDrop(_itemToDrop);
		}
		else
		{
			SetDropComplete(stopDropping: true, wasCancelled: true);
		}
	}

	protected override Vector3 GetStartingPositionForDrop()
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
				_lastDropPosition = ComputeObjectPositionFromControllerInput(forceUpdate: true);
			}
		}
		return _lastDropPosition.Value;
	}

	protected override void SetObjectPosition()
	{
		if (!_settingDistance)
		{
			base.SetObjectPosition();
		}
	}

	protected override void SetObjectPositionWithMouse()
	{
		if (_controls.GetPointerOverUI() || _dropItemTrans == null)
		{
			return;
		}
		Vector3 vector = _controls.GetPointerPositionOnGround() + pointerOffset;
		if (base.IsPlacingInitialized)
		{
			if (_controls.GetButton(UserActions.INTERACT))
			{
				SetObjectPositionWithMouseDrag(vector);
			}
			else
			{
				SetFlowState(PlacementFlowStates.Inactive);
			}
		}
		else
		{
			_lastdragDirection = Vector3.zero;
			_dropItemTrans.position = vector.GetSnappedPosition(_itemToDrop.gridSnapSize);
		}
	}

	private void SetObjectPositionWithMouseDrag(Vector3 groundPosition)
	{
		if (_lastdragDirection == Vector3.zero)
		{
			_currentMouseObjectPosition = groundPosition;
			Vector3 mouseGroundDragDirection = GetMouseGroundDragDirection(groundPosition);
			if (mouseGroundDragDirection != Vector3.zero)
			{
				_lastdragDirection = mouseGroundDragDirection;
			}
			if (_dropItemTrans.position.x == 0f && _dropItemTrans.position.z == 0f)
			{
				_dropItemTrans.position = _currentMouseObjectPosition.GetSnappedPosition(_itemToDrop.gridSnapSize);
			}
		}
		else
		{
			Vector3 vector = Vector3.Project(groundPosition - _lastDropPosition.Value, _lastdragDirection);
			float num = ((!(base.CurrentItem.Forward == _lastdragDirection) && !(base.CurrentItem.Forward == -_lastdragDirection)) ? _itemToDrop.width : _itemToDrop.depth);
			Vector3 currentMouseObjectPosition = ((!(vector.sqrMagnitude < Mathf.Pow(num, 2f))) ? (_lastDropPosition.Value + vector.normalized * num) : _lastDropPosition.Value);
			_currentMouseObjectPosition = currentMouseObjectPosition;
			_dropItemTrans.position = _currentMouseObjectPosition.GetSnappedPosition(_itemToDrop.gridSnapSize);
			if (_placementControl.OverSwappableItem)
			{
				_lastDropPosition = _dropItemTrans.position;
			}
		}
	}

	protected override void SetObjectPositionWithController()
	{
		if (base.IsPlacingInitialized)
		{
			if (_controls.GetButton(UserActions.INTERACT))
			{
				SetObjectPositionWithControllerDrag();
				return;
			}
			SetFlowState(PlacementFlowStates.Inactive);
			if (_placementIndicatorRenderers != null)
			{
				SpriteRenderer[] placementIndicatorRenderers = _placementIndicatorRenderers;
				foreach (SpriteRenderer obj in placementIndicatorRenderers)
				{
					obj.color = obj.color.WithAlpha(1f);
				}
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
		if (_placementRange < 0)
		{
			_placementRange = -_placementRange;
		}
		bool forceUpdate = CheckForRangeChange();
		Vector3 position = ComputeObjectPositionFromControllerInput(forceUpdate);
		_dropItemTrans.position = position;
	}

	protected void SetObjectPositionWithControllerDrag()
	{
		if (_placementIndicatorRenderers != null)
		{
			SpriteRenderer[] placementIndicatorRenderers = _placementIndicatorRenderers;
			foreach (SpriteRenderer obj in placementIndicatorRenderers)
			{
				obj.color = obj.color.WithAlpha(0f);
			}
		}
		float axis = _controls.GetAxis(Controls.MovementAxis.MoveHorizontal);
		float axis2 = _controls.GetAxis(Controls.MovementAxis.MoveVertical);
		Vector3 nearestAxisDirection = UnityUtils.GetNearestAxisDirection(UnityUtils.ConvertScreenVectorToIsometric(axis, axis2));
		Vector3 vector = ComputeObjectPositionFromControllerInput();
		if (_lastdragDirection == Vector3.zero)
		{
			_currentMouseObjectPosition = vector;
			if (nearestAxisDirection != Vector3.zero)
			{
				_lastdragDirection = nearestAxisDirection;
			}
			if (_dropItemTrans.position.x == 0f && _dropItemTrans.position.z == 0f)
			{
				_dropItemTrans.position = _currentMouseObjectPosition.GetSnappedPosition(_itemToDrop.gridSnapSize);
			}
			return;
		}
		Vector3 vector2 = Vector3.Project(vector - _lastDropPosition.Value, _lastdragDirection);
		float num = ((!(base.CurrentItem.Forward == _lastdragDirection) && !(base.CurrentItem.Forward == -_lastdragDirection)) ? _itemToDrop.width : _itemToDrop.depth);
		Vector3 currentMouseObjectPosition = ((!(vector2.sqrMagnitude < Mathf.Pow(num, 2f))) ? (_lastDropPosition.Value + vector2.normalized * num) : _lastDropPosition.Value);
		_currentMouseObjectPosition = currentMouseObjectPosition;
		_dropItemTrans.position = _currentMouseObjectPosition.GetSnappedPosition(_itemToDrop.gridSnapSize);
		if (_placementControl.OverSwappableItem)
		{
			_lastDropPosition = _dropItemTrans.position;
		}
	}

	private bool CheckForRangeChange()
	{
		bool result = false;
		float num = Mathf.Max(_itemToDrop.width, _itemToDrop.depth);
		int num2 = Mathf.CeilToInt(0.5f * num) + 1;
		if (_placementRange != num2)
		{
			_placementRange = num2;
			result = true;
		}
		return result;
	}

	private Vector3 ComputeObjectPositionFromControllerInput(bool forceUpdate = false)
	{
		if (useOriginalPrototypeLogic)
		{
			return ComputeObjectPositionFromControllerInputA(forceUpdate);
		}
		return ComputeObjectPositionFromControllerInputB(forceUpdate);
	}

	private Vector3 ComputeObjectPositionFromControllerInputA(bool forceUpdate)
	{
		float axis = _controls.GetAxis(Controls.MovementAxis.SecondaryHorizontal);
		float axis2 = _controls.GetAxis(Controls.MovementAxis.SecondaryVertical);
		bool flag = !axis.Approx(0f, 0.01f) || !axis2.Approx(0f, 0.01f);
		float axis3 = _controls.GetAxis(Controls.MovementAxis.SecondaryHorizontal);
		float axis4 = _controls.GetAxis(Controls.MovementAxis.SecondaryVertical);
		Vector3 vector = ScreenVectorToWorldVector(axis3, axis4);
		if (forceUpdate && !flag)
		{
			vector = _itemRelativePosition.normalized;
		}
		if ((new Vector2(axis3, axis4).magnitude * movementSpeed > rememberPositionDeadzone) | forceUpdate)
		{
			_itemRelativePosition = vector * _placementRange;
		}
		_itemAnchorPosition = _playerController.transform.position;
		AutomationGridSpace orCreateGridSpace = _automation.GetOrCreateGridSpace(_itemAnchorPosition);
		_itemAnchorPosition = orCreateGridSpace.position;
		return (_itemAnchorPosition + _itemRelativePosition).GetSnappedPosition(_itemToDrop.gridSnapSize);
	}

	private Vector3 ComputeObjectPositionFromControllerInputB(bool forceUpdate)
	{
		float axis = _controls.GetAxis(Controls.MovementAxis.SecondaryHorizontal);
		float axis2 = _controls.GetAxis(Controls.MovementAxis.SecondaryVertical);
		bool flag = !axis.Approx(0f, 0.01f) || !axis2.Approx(0f, 0.01f);
		float axis3 = _controls.GetAxis(Controls.MovementAxis.MoveHorizontal);
		float axis4 = _controls.GetAxis(Controls.MovementAxis.MoveVertical);
		bool flag2 = !axis3.Approx(0f, 0.01f) || !axis4.Approx(0f, 0.01f);
		if (!flag && !flag2 && !forceUpdate)
		{
			if (_placementPreview != null)
			{
				_placementPreview.rotation = Quaternion.FromToRotation(Vector3.forward, _lastHintDirection);
				Vector3 vector = _lastUsedPosition - _lastHintDirection * _placementRange;
				_placementPreview.position = vector - new Vector3(0.5f, -0.02f, -0.5f);
			}
			return _lastUsedPosition;
		}
		PlacementDirection placementDirection = ((!forceUpdate || flag) ? ScreenVectorToPlacementDirection(axis, axis2) : ((_lastUsedDirection != PlacementDirection.None) ? _lastUsedDirection : DEFAULT_PLACEMENT_DIRECTION));
		Vector3 vector2 = PlacementDirectionToWorldVector(placementDirection);
		if (((new Vector2(axis, axis2).magnitude > _rightStickDeadzone) | forceUpdate) || _itemRelativePosition == Vector3.zero)
		{
			_itemRelativePosition = vector2 * _placementRange;
			if (_placementPreview != null)
			{
				_placementPreview.rotation = Quaternion.FromToRotation(Vector3.forward, vector2);
				_lastHintDirection = vector2;
			}
		}
		MovementDirection movementDirection = (flag2 ? ScreenVectorToMovementDirection(axis3, axis4) : MovementDirection.None);
		_itemAnchorPosition = _automation.GetOrCreateGridSpace(_playerController.transform.position).position;
		Vector3 snappedPosition = (_itemAnchorPosition + _itemRelativePosition).GetSnappedPosition(_itemToDrop.gridSnapSize);
		Vector3 vector3;
		if (((placementDirection != _lastUsedDirection) | forceUpdate) || movementDirection == MovementDirection.None || movementDirection == MovementDirection.UpLeft || movementDirection == MovementDirection.UpRight || movementDirection == MovementDirection.DownLeft || movementDirection == MovementDirection.DownRight)
		{
			vector3 = snappedPosition;
		}
		else
		{
			Vector3 vector4 = Vector3.zero;
			switch (movementDirection)
			{
			case MovementDirection.Up:
				vector4 = Vector3.forward + Vector3.left;
				break;
			case MovementDirection.Down:
				vector4 = Vector3.back + Vector3.right;
				break;
			case MovementDirection.Left:
				vector4 = Vector3.left + Vector3.back;
				break;
			case MovementDirection.Right:
				vector4 = Vector3.right + Vector3.forward;
				break;
			}
			Vector3 vector5 = _lastUsedPosition + vector4;
			Vector3 vector6 = snappedPosition - _lastUsedPosition;
			float num = Mathf.Abs(vector6.x) + Mathf.Abs(vector6.z);
			vector3 = ((!(snappedPosition == vector5) && !(num >= (float)_maxTilesToIgnoreForSnap)) ? _lastUsedPosition : snappedPosition);
		}
		if (_placementPreview != null)
		{
			_placementPreview.rotation = Quaternion.FromToRotation(Vector3.forward, _lastHintDirection);
			Vector3 vector7 = vector3 - _lastHintDirection * _placementRange;
			_placementPreview.position = vector7 - new Vector3(0.5f, -0.02f, -0.5f);
		}
		_lastUsedPosition = vector3;
		return vector3;
	}

	private Vector3 ScreenVectorToWorldVector(float x, float y)
	{
		Vector3 zero = Vector3.zero;
		if (!x.Approx(0f, 0.05f) || !y.Approx(0f, 0.05f))
		{
			Vector2 vector = new Vector2(x * cosQuarterPI - y * sinQuarterPI, y * cosQuarterPI + x * sinQuarterPI);
			if (Mathf.Abs(vector.x) > Mathf.Abs(vector.y))
			{
				zero.x = Mathf.Sign(vector.x);
			}
			else
			{
				zero.z = Mathf.Sign(vector.y);
			}
		}
		return zero;
	}

	private PlacementDirection ScreenVectorToPlacementDirection(float x, float y)
	{
		PlacementDirection result = PlacementDirection.None;
		if (!x.Approx(0f, 0.05f) || !y.Approx(0f, 0.05f))
		{
			Vector2 vector = new Vector2(x * cosQuarterPI - y * sinQuarterPI, y * cosQuarterPI + x * sinQuarterPI);
			result = ((Mathf.Abs(vector.x) > Mathf.Abs(vector.y)) ? ((!(vector.x > 0f)) ? PlacementDirection.UpLeft : PlacementDirection.DownRight) : ((vector.y > 0f) ? PlacementDirection.UpRight : PlacementDirection.DownLeft));
		}
		return result;
	}

	private Vector3 PlacementDirectionToWorldVector(PlacementDirection dir)
	{
		Vector3 result = Vector3.zero;
		switch (dir)
		{
		case PlacementDirection.UpRight:
			result = Vector3.forward;
			break;
		case PlacementDirection.DownLeft:
			result = Vector3.back;
			break;
		case PlacementDirection.UpLeft:
			result = Vector3.left;
			break;
		case PlacementDirection.DownRight:
			result = Vector3.right;
			break;
		}
		return result;
	}

	private MovementDirection ScreenVectorToMovementDirection(float x, float y)
	{
		MovementDirection result = MovementDirection.None;
		Vector3 nearestOctoDirection = UnityUtils.GetNearestOctoDirection(UnityUtils.ConvertScreenVectorToIsometric(x, y));
		if (nearestOctoDirection == Vector3.forward)
		{
			result = MovementDirection.UpRight;
		}
		else if (nearestOctoDirection == Vector3.back)
		{
			result = MovementDirection.DownLeft;
		}
		else if (nearestOctoDirection == Vector3.left)
		{
			result = MovementDirection.UpLeft;
		}
		else if (nearestOctoDirection == Vector3.right)
		{
			result = MovementDirection.DownRight;
		}
		else if (nearestOctoDirection == Constants.BACKLEFT_NORMALIZED)
		{
			result = MovementDirection.Left;
		}
		else if (nearestOctoDirection == Constants.BACKRIGHT_NORMALIZED)
		{
			result = MovementDirection.Down;
		}
		else if (nearestOctoDirection == Constants.FRONTLEFT_NORMALIZED)
		{
			result = MovementDirection.Up;
		}
		else if (nearestOctoDirection == Constants.FRONTRIGHT_NORMALIZED)
		{
			result = MovementDirection.Right;
		}
		else
		{
			Debug.LogError("Due to what must be floating point innacuracies, none of the axes from GetNearestOctoDirection seem to correspond to its return value, despite an allowance of 1e-5");
		}
		return result;
	}

	private void ActivateItem()
	{
		SetObjectPosition();
		_dropItemTrans.gameObject.SetActive(value: true);
	}
}
