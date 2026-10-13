using System;
using Isto.Core.Data;
using Isto.Core.Items;
using UnityEngine;
using Zenject;

namespace Isto.Core.Automation;

public class AutomationItemPusher : IItemProcessor, IDirectionalItem, IAutomationGridSpaceUser
{
	public class Factory : PlaceholderFactory<AutomationItemPusherParams, AutomationItemPusher>
	{
	}

	[Inject]
	private AutomationSystem _system;

	private Vector3 _forward = Vector3.right;

	private AutomationGridSpace _processorSpace;

	private AutomationCoreItem _targetItem;

	private int _pushDistance;

	private int _pushInterval;

	private int _intervalCounter;

	private bool _waitingToPush;

	private float _stuckTimer;

	public string ProcessorID { get; private set; }

	public bool Visible => true;

	public int CurrentCount => _intervalCounter;

	public Vector3 SourceSpacePosition => _processorSpace.position + _forward;

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

	public AutomationItemPusher(AutomationItemPusherParams p)
	{
		_pushDistance = p.distance;
		_pushInterval = p.pushInterval;
		_intervalCounter = p.currentCount;
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
		AutomationGridSpace automationGridSpace = null;
		if (_system.DoesSpaceExist(SourceSpacePosition))
		{
			automationGridSpace = SourceSpace;
		}
		if (_targetItem == null && automationGridSpace?.ActiveItem != null && ItemMovingToThisSpace(automationGridSpace.ActiveItem))
		{
			_targetItem = automationGridSpace.ActiveItem;
			_intervalCounter++;
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
				_intervalCounter++;
			}
		}
		if (ShouldPush(deltaTime))
		{
			_stuckTimer = 0f;
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

	private bool ShouldPush(float deltaTime)
	{
		if (_intervalCounter == 0 || _targetItem == null)
		{
			return false;
		}
		if (_targetItem.TargetPosition != SourceSpacePosition)
		{
			return false;
		}
		if (_targetItem.IsReserved || _targetItem.IsConsumed)
		{
			return false;
		}
		if (_pushInterval == 0)
		{
			return true;
		}
		if (_intervalCounter % _pushInterval == 0)
		{
			return true;
		}
		_stuckTimer += deltaTime;
		if (_stuckTimer > _system.ItemMoveTime * 2f)
		{
			return true;
		}
		return false;
	}

	private void OnIncomingMoveComplete(object sender, CoreItemMoveEventArgs e)
	{
		_waitingToPush = false;
		_targetItem.MoveComplete -= OnIncomingMoveComplete;
		if (!_targetItem.IsMoving && !_targetItem.IsReserved && !_targetItem.IsConsumed)
		{
			TryPushItem();
		}
	}

	private bool ItemMovingToThisSpace(AutomationCoreItem item)
	{
		return item.TargetPosition == SourceSpacePosition;
	}

	private bool TryPushItem()
	{
		bool flag = false;
		_ = SourceSpace;
		AutomationGridSpace destinationSpace = DestinationSpace;
		if (_system.CanMoveItemToGridSpace(destinationSpace, _targetItem, out var spaceAvailable))
		{
			_targetItem.IsReserved = true;
			bool flag2 = spaceAvailable == _targetItem.count;
			flag = AutomationItemMover.TryItemMove(_targetItem, SourceSpace, destinationSpace, spaceAvailable, _system, GetMover, out var createdItemMover);
			_targetItem.IsReserved = false;
			if (flag)
			{
				ItemPushed?.Invoke(this, new ItemMoveArgs(createdItemMover));
				_intervalCounter = 0;
				if (flag2)
				{
					_targetItem = null;
				}
			}
		}
		return flag;
	}

	public IItemMoveType GetMover(AutomationCoreItem item, Vector3 destination, AutomationGridSpace nextSpace)
	{
		return new AutomationLinearMove(_targetItem, destination, _system.ItemMoveTime);
	}

	private bool ItemReadyToBePushed()
	{
		if (_targetItem == null || _targetItem.IsMoving)
		{
			return false;
		}
		if (_targetItem.position == SourceSpacePosition)
		{
			return _waitingToPush;
		}
		return false;
	}

	public AutomationProcessorData GetSaveData()
	{
		return new AutomationItemPusherData
		{
			direction = _forward,
			distance = _pushDistance,
			pushInterval = _pushInterval,
			currentCount = _intervalCounter,
			typeId = ProcessorID
		};
	}

	public void LoadData(AutomationProcessorData data)
	{
		if (data is AutomationItemPusherData automationItemPusherData)
		{
			SetForwardDirection(automationItemPusherData.direction);
			_pushDistance = automationItemPusherData.distance;
			_pushInterval = automationItemPusherData.pushInterval;
			_intervalCounter = automationItemPusherData.currentCount;
			ProcessorID = automationItemPusherData.typeId;
			if (_pushInterval == 0)
			{
				_pushInterval = 2;
			}
		}
	}
}
