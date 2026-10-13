using System;
using Isto.Core.Data;
using Isto.Core.Items;
using UnityEngine;
using Zenject;

namespace Isto.Core.Automation;

public class AutomationTimedItemPusher : IItemProcessor, IDirectionalItem, IAutomationGridSpaceUser
{
	public class Factory : PlaceholderFactory<AutomationTimedItemPusherParams, AutomationTimedItemPusher>
	{
	}

	[Inject]
	private AutomationSystem _system;

	private Vector3 _forward = Vector3.right;

	private AutomationGridSpace _processorSpace;

	private AutomationCoreItem _targetItem;

	private int _pushDistance;

	private float _pushCoolDownTime;

	private bool _waitingToPush;

	private float _pushTimer;

	public string ProcessorID { get; private set; }

	public bool Visible => true;

	public Vector3 SourceSpacePosition => _processorSpace.position + _forward;

	public float CooldownTimer => _pushTimer;

	public string TargetItemID => _targetItem?.ID ?? "null";

	public string SourceItemID
	{
		get
		{
			if (!_system.DoesSpaceExist(SourceSpacePosition))
			{
				return "null";
			}
			return SourceSpace.ActiveItem?.ID ?? "null";
		}
	}

	public bool WaitingToPush => _waitingToPush;

	private AutomationGridSpace SourceSpace => _system.GetOrCreateGridSpace(SourceSpacePosition);

	private AutomationGridSpace DestinationSpace => _system.GetOrCreateGridSpace(SourceSpacePosition + _forward * _pushDistance);

	public event EventHandler<ItemMoveArgs> ItemPushed;

	public AutomationTimedItemPusher(AutomationTimedItemPusherParams p)
	{
		_pushDistance = p.distance;
		_pushCoolDownTime = p.pushCoolDownTime;
		ProcessorID = p.processorTypeId;
	}

	public void SetGridSpace(AutomationGridSpace space)
	{
		_processorSpace = space;
	}

	public int IsAvailable(AutomationCoreItem movingItem)
	{
		return 0;
	}

	public void SetForwardDirection(Vector3 forward)
	{
		_forward = forward;
	}

	public Vector3 GetDirection()
	{
		return _forward;
	}

	public void Tick(float deltaTime)
	{
		if (_waitingToPush)
		{
			return;
		}
		_pushTimer -= deltaTime;
		AutomationGridSpace automationGridSpace = null;
		if (_system.DoesSpaceExist(SourceSpacePosition))
		{
			automationGridSpace = SourceSpace;
		}
		if (_targetItem == null && automationGridSpace?.ActiveItem != null && ItemMovingToThisSpace(automationGridSpace.ActiveItem))
		{
			_targetItem = automationGridSpace.ActiveItem;
		}
		else if (_targetItem != null)
		{
			if (automationGridSpace?.ActiveItem == null)
			{
				_targetItem = null;
			}
			else if (automationGridSpace.ActiveItem != _targetItem)
			{
				_targetItem.MoveComplete -= OnIncomingMoveComplete;
				_targetItem = automationGridSpace.ActiveItem;
			}
		}
		if (ShouldPush())
		{
			if (_targetItem.IsMoving)
			{
				_targetItem.MoveComplete += OnIncomingMoveComplete;
				_waitingToPush = true;
			}
			else
			{
				TryPushItem();
			}
		}
	}

	private bool ShouldPush()
	{
		if (_targetItem == null)
		{
			return false;
		}
		if (_targetItem.TargetPosition != SourceSpacePosition)
		{
			return false;
		}
		return _pushTimer < 0f;
	}

	private void OnIncomingMoveComplete(object sender, CoreItemMoveEventArgs e)
	{
		_targetItem.MoveComplete -= OnIncomingMoveComplete;
		_waitingToPush = false;
		TryPushItem();
	}

	private bool ItemMovingToThisSpace(AutomationCoreItem item)
	{
		return item.TargetPosition == SourceSpacePosition;
	}

	private bool TryPushItem()
	{
		_pushTimer = _pushCoolDownTime;
		_ = SourceSpace;
		AutomationGridSpace destinationSpace = DestinationSpace;
		if (_system.CanMoveItemToGridSpace(destinationSpace, _targetItem, out var spaceAvailable))
		{
			bool flag = spaceAvailable == _targetItem.count;
			if (AutomationItemMover.TryItemMove(_targetItem, SourceSpace, destinationSpace, spaceAvailable, _system, GetMover, out var createdItemMover))
			{
				ItemPushed?.Invoke(this, new ItemMoveArgs(createdItemMover));
				if (flag)
				{
					_targetItem = null;
				}
				return true;
			}
		}
		return false;
	}

	public IItemMoveType GetMover(AutomationCoreItem item, Vector3 destination, AutomationGridSpace nextSpace)
	{
		return new AutomationLinearMove(_targetItem, destination, _system.ItemMoveTime);
	}

	public AutomationProcessorData GetSaveData()
	{
		return new AutomationItemPusherData
		{
			direction = _forward,
			distance = _pushDistance,
			pushCooldownTime = ((_pushCoolDownTime != 0f) ? _pushCoolDownTime : 1f),
			typeId = ProcessorID
		};
	}

	public void LoadData(AutomationProcessorData data)
	{
		if (data is AutomationItemPusherData automationItemPusherData)
		{
			SetForwardDirection(automationItemPusherData.direction);
			_pushDistance = automationItemPusherData.distance;
			_pushCoolDownTime = automationItemPusherData.pushCooldownTime;
			ProcessorID = automationItemPusherData.typeId;
		}
	}
}
