using System;
using System.Collections;
using Isto.Core.Automation;
using Isto.Core.Beings;
using Isto.Core.Inputs;
using Isto.Core.Localization;
using Isto.Core.Pooling;
using Isto.Core.StateMachine;
using Isto.Core.UI;
using UPool;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Serialization;
using Zenject;

namespace Isto.Core.Items;

public class ItemPlacementController : MonoPushdownStateMachine, IDirectionalItem, IActionOnSpawn, IActionOnRecycle
{
	[Tooltip("If true, only one item will be placed and then will exit from placement state, if false, multiple items can be placed without leaving state")]
	public bool singlePlacement;

	[SerializeField]
	private Vector3 _forward;

	[Header("Optional item overlap stuff")]
	[SerializeField]
	private ConnectToNeighbours _neighbourConnector;

	[Tooltip("Only need this if item can create connections to neighbouring items")]
	[SerializeField]
	[FormerlySerializedAs("connectableConditions")]
	private PlacementConditions _connectableConditions;

	[SerializeField]
	private GameObject _upRightDropPosition;

	[SerializeField]
	private GameObject _upLeftDropPosition;

	[SerializeField]
	private GameObject _downLeftDropPosition;

	[SerializeField]
	private GameObject _downRightDropPosition;

	protected UIToolTip _activeTooltip;

	private bool _injected;

	private bool _started;

	private AutomationPlayerController _player;

	private IControls _controls;

	protected UIToolTip.Pool _toolTipPool;

	private Vector3 _toolTipOffset;

	private AutomationSystem _automation;

	public ItemPile CurrentItem { get; private set; }

	public Vector3 Forward => _forward;

	public bool OverSwappableItem { get; private set; }

	public bool IsFirstOfFastPlacement { get; set; }

	private bool IsEraser => base.gameObject.GetComponent<Eraser>() != null;

	[Inject]
	public void Inject(AutomationPlayerController player, IControls controls, UIToolTip.Pool toolTipPool, [Inject(Id = "PlacementToolTipOffset")] Vector3 toolTipOffset, AutomationSystem automation)
	{
		_player = player;
		_controls = controls;
		_toolTipPool = toolTipPool;
		_toolTipOffset = toolTipOffset;
		_injected = true;
		_automation = automation;
	}

	protected override void Awake()
	{
		InteractableItem component = GetComponent<InteractableItem>();
		CurrentItem = component.itemPile;
		base.Awake();
	}

	protected override void Start()
	{
		if (IsEraser)
		{
			_controls.SetControlMode(Controls.Mode.Dismantling);
		}
		else
		{
			_controls.SetControlMode(Controls.Mode.Building);
		}
		Invoke("ActivateToolTipInvoked", Constants.BUTTON_SPAM_DELAY * 2f);
		base.Start();
		_started = true;
	}

	private void OnEnable()
	{
		if (_started && _injected && GetComponent<PoolableObject>() != null)
		{
			StartCoroutine(StartWithDelay());
		}
	}

	private IEnumerator StartWithDelay()
	{
		yield return new WaitForEndOfFrame();
		if (!base.gameObject.IsNullOrDestroyed())
		{
			Start();
		}
	}

	private void OnDisable()
	{
	}

	protected override void Update()
	{
		MoveToolTip();
		if ((bool)_neighbourConnector)
		{
			_neighbourConnector.UpdateNeighbourItemOverlaps(placementMode: true);
		}
		base.Update();
	}

	public override void ExitSubState()
	{
		if (_stateStack.Count == 1)
		{
			CompletePlacement();
		}
		else if (_stateStack.Count > 1)
		{
			base.ExitSubState();
		}
		else
		{
			Debug.LogWarning("Error - ExitSubState cannot work if placement state is empty. But if this is a playmode test we ignore it. GameObject:" + base.gameObject.name);
		}
	}

	public void CancelDrop(bool exitFromPlacement = true)
	{
		if (exitFromPlacement)
		{
			_player.SetDropCancelled(stopDropping: true);
		}
		RemoveToolTip();
		_player.SetMovementEnabled(active: true);
		if (exitFromPlacement)
		{
			_controls.SetControlMode(Controls.Mode.Gameplay);
		}
		while (_stateStack.Count > 0)
		{
			PopState();
		}
		RemoveItem();
		base.enabled = false;
	}

	private void RemoveItem()
	{
		PooledInteractableItem component = base.gameObject.GetComponent<PooledInteractableItem>();
		if (component != null)
		{
			component.DestroyGameObject();
		}
		else if (!Addressables.ReleaseInstance(base.gameObject))
		{
			Debug.LogError("ItemPlacementController.RemoveItem on unpooled item that is not an addressable instance, this is unexpected");
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	public void SetStartRotation(float angle)
	{
		if (angle % 90f != 0f)
		{
			Debug.LogError("Angle passed to set start rotation should be a multiple of 90. Angle: " + angle, base.gameObject);
			return;
		}
		int num = Math.Abs((int)(angle / 90f));
		ItemRotateState component = GetComponent<ItemRotateState>();
		if (component != null)
		{
			for (int i = 0; i < num; i++)
			{
				component.HandleRotation(-1 * Math.Sign(angle));
			}
		}
	}

	public void SetStartRotation(Vector3 startDirection)
	{
		float currentSnappedAngle = GetCurrentSnappedAngle(startDirection, Forward);
		SetStartRotation(currentSnappedAngle);
	}

	private static float GetCurrentSnappedAngle(Vector3 rotationDirection, Vector3 forward)
	{
		float num = Vector3.SignedAngle(rotationDirection, forward, Vector3.up);
		float num2 = 90f;
		return Mathf.Round(num / num2) * num2;
	}

	private void CompletePlacement()
	{
		_currentState.Exit(this);
		RemoveToolTip();
		base.enabled = false;
	}

	public void SetForwardDirection(Vector3 forward)
	{
		if (_neighbourConnector != null)
		{
			_neighbourConnector.ResetDirection();
		}
		_forward = forward;
	}

	public void DoSpawnAction()
	{
		base.enabled = true;
	}

	public void OnRecycle()
	{
		while (_stateStack.Count > 0)
		{
			_stateStack.Pop();
		}
		if (_neighbourConnector != null)
		{
			_neighbourConnector.ResetDirection();
		}
		SetIsNotOverSwappableItem();
		IsFirstOfFastPlacement = false;
		if (TryGetComponent<ItemSetMaterialState>(out var component))
		{
			component.RestoreMaterials();
		}
	}

	public Vector3 GetDirection()
	{
		return _forward;
	}

	private void MoveToolTip()
	{
		if (_activeTooltip != null)
		{
			_activeTooltip.transform.position = UnityUtils.TransformWorldToCanvasPoint(base.transform.position + _toolTipOffset, _activeTooltip.Canvas);
		}
	}

	private void ActivateToolTipInvoked()
	{
		if (_activeTooltip != null)
		{
			return;
		}
		if (IsEraser)
		{
			_activeTooltip = _toolTipPool.Spawn(Loc.GetString(Constants.TOOLTIP_DISMANTLING));
			_activeTooltip.AddRow(_controls.GetIconForAction(UserActions.DISMANTLE), Loc.GetString(Constants.USER_ACTION_DISMANTLE));
			_activeTooltip.AddRow(_controls.GetIconForAction(UserActions.CANCELDISMANTLING), Loc.GetString(Constants.USER_ACTION_CANCEL));
			return;
		}
		_activeTooltip = _toolTipPool.Spawn(CurrentItem.item.itemName);
		_activeTooltip.AddRow(_controls.GetIconForAction(UserActions.INTERACT), Loc.GetString(Constants.USER_ACTION_PLACE));
		_activeTooltip.AddRow(_controls.GetIconForAction(UserActions.CANCELBUILDING), Loc.GetString(Constants.USER_ACTION_CANCEL));
		if (GetComponent<ItemRotateState>() != null)
		{
			_activeTooltip.AddRow(_controls.GetIconForAction(UserActions.ROTATELEFT), Loc.GetString(Constants.USER_ACTION_ROTATE), _controls.GetIconForAction(UserActions.ROTATERIGHT));
		}
	}

	public void RemoveToolTip()
	{
		if (_activeTooltip != null)
		{
			_toolTipPool.Despawn(_activeTooltip);
			_activeTooltip = null;
			return;
		}
		if (base.gameObject == null)
		{
			Debug.LogWarning("GameObject Null, this must be in cleanup?");
		}
		CancelInvoke("ActivateToolTipInvoked");
	}

	public void SetIsOverSwappableItem()
	{
		OverSwappableItem = true;
	}

	public void SetIsNotOverSwappableItem()
	{
		OverSwappableItem = false;
	}
}
