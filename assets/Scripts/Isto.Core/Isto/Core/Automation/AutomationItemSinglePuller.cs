using System;
using Isto.Core.Data;
using UnityEngine;
using Zenject;

namespace Isto.Core.Automation;

public class AutomationItemSinglePuller : AutomationItemMover
{
	public new class Factory : PlaceholderFactory<int, MovementType, string, AutomationItemSinglePuller>
	{
	}

	private AutomationCoreItem _erroredItem;

	private AutomationCoreItem _targetItem;

	public Vector3 PositionBehind => base.Position - GetDirection();

	private AutomationGridSpace SpaceBehind
	{
		get
		{
			if (_system.TryGetExistingGridSpace(PositionBehind, out var space))
			{
				return space;
			}
			return null;
		}
	}

	public AutomationItemSinglePuller(int moveDistance, MovementType moveType, string processorTypeId)
		: base(moveDistance, moveType, processorTypeId)
	{
	}

	public override int IsAvailable(AutomationCoreItem movingItem)
	{
		AutomationGridSpace spaceBehind = SpaceBehind;
		if (spaceBehind != null && spaceBehind.ActiveItem != null && (base.ItemFilter == null || base.ItemFilter.IsAccepted(spaceBehind.ActiveItem)) && !spaceBehind.ActiveItem.IsMoving)
		{
			return 0;
		}
		return base.IsAvailable(movingItem);
	}

	public override void Tick(float deltaTime)
	{
		if (CanTick())
		{
			AutomationCoreItem activeItem = GetActiveItem();
			if (!activeItem.IsMoving)
			{
				MoveItem(activeItem);
			}
			else if (GetGridSpace().ActiveItem == null && !(activeItem.TargetPosition != SpaceBehind.position))
			{
				_targetItem = activeItem;
				_targetItem.MoveComplete += OnIncomingMoveComplete;
			}
		}
	}

	protected override AutomationCoreItem GetActiveItem()
	{
		AutomationCoreItem automationCoreItem = GetGridSpace().ActiveItem;
		if (automationCoreItem == null)
		{
			automationCoreItem = SpaceBehind?.ActiveItem;
		}
		return automationCoreItem;
	}

	protected override bool CanTick()
	{
		bool result = true;
		AutomationCoreItem automationCoreItem = GetGridSpace().ActiveItem;
		if (automationCoreItem == null)
		{
			automationCoreItem = SpaceBehind?.ActiveItem;
		}
		if (!GetGridSpace().Powered)
		{
			result = false;
		}
		else if (_targetItem != null)
		{
			if (_targetItem.IsConsumed && _targetItem.IsMoving && _erroredItem != _targetItem)
			{
				Debug.LogError(string.Format("{0} Invalid Item State! {1} is marked as Cosumed but also Moving. Mover:{2}, ", TimeSpan.FromSeconds(Time.timeSinceLevelLoad).ToString("mm\\m\\:ss\\s"), _targetItem.ID, _targetItem.MoveType) + $"Position:{_targetItem.position}, TargetPosition:{_targetItem.TargetPosition}. At grid space: {base.Position}");
				_erroredItem = _targetItem;
				if (_targetItem.GridSpace != null)
				{
					Debug.LogError("Trying to force stuck item back onto space");
					_targetItem.GridSpace.MoveItemToSpace(_targetItem.MoveType);
				}
			}
			result = false;
		}
		else if (!CanTakeItem(automationCoreItem))
		{
			result = false;
		}
		return result;
	}

	private void OnIncomingMoveComplete(object sender, CoreItemMoveEventArgs e)
	{
		if (_targetItem != null)
		{
			AutomationCoreItem targetItem = _targetItem;
			_targetItem = null;
			targetItem.MoveComplete -= OnIncomingMoveComplete;
			if (!targetItem.IsMoving && !targetItem.IsReserved && !targetItem.IsConsumed)
			{
				MoveItem(targetItem);
			}
		}
	}

	public override AutomationProcessorData GetSaveData()
	{
		AutomationItemMoverData automationItemMoverData = base.GetSaveData() as AutomationItemMoverData;
		return new AutomationItemSinglePullerData
		{
			typeId = automationItemMoverData.typeId,
			direction = automationItemMoverData.direction,
			visible = automationItemMoverData.visible,
			distance = automationItemMoverData.distance,
			moveType = automationItemMoverData.moveType
		};
	}

	public override void LoadData(AutomationProcessorData data)
	{
		AutomationItemSinglePullerData data2 = data as AutomationItemSinglePullerData;
		base.LoadData(data2);
	}
}
