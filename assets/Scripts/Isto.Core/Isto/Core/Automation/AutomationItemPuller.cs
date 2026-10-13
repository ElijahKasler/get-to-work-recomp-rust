using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Isto.Core.Data;
using Isto.Core.Items;
using UnityEngine;
using Zenject;

namespace Isto.Core.Automation;

public class AutomationItemPuller : IItemProcessor, IDirectionalItem, IAutomationGridSpaceUser
{
	public class Factory : PlaceholderFactory<AutomationItemPullerParams, AutomationItemPuller>
	{
	}

	[Inject]
	private AutomationSystem _autoSystem;

	private AutomationGridSpace _space;

	private Vector3 _forward;

	private float _timeBetweenPulls = 15f;

	private float _pullTimer;

	private int _pullDistance = 5;

	private List<string> _validResourcesToHarvest;

	private List<Vector3> _affectedPositions = new List<Vector3>();

	private AutomationGridSpace _itemHoldingSpace;

	public string ProcessorID { get; private set; }

	public bool DestinationBlocked { get; private set; }

	public bool Visible { get; private set; }

	public AutomationGridSpace Space => _space;

	public event EventHandler<AutomationPullEventArgs> PullStart;

	public event EventHandler PullEnd;

	private bool CanHarvest(string s)
	{
		return _validResourcesToHarvest.Contains(s);
	}

	public AutomationItemPuller(AutomationItemPullerParams pullerParams)
	{
		Visible = true;
		ProcessorID = pullerParams.ID;
		_validResourcesToHarvest = new List<string>();
		for (int i = 0; i < pullerParams.validResources.Count; i++)
		{
			_validResourcesToHarvest.Add(pullerParams.validResources[i]);
		}
		_forward = pullerParams.forward;
		_pullDistance = pullerParams.pullDistance;
		if (pullerParams.pullWhenPlaced)
		{
			_pullTimer = _timeBetweenPulls;
		}
	}

	private void SetupAffectedPositionsList()
	{
		AddPositions(_space.position + _forward, _pullDistance, _forward, _affectedPositions);
	}

	private void AddPositions(Vector3 startPosition, int distance, Vector3 forward, List<Vector3> positionList)
	{
		for (int i = 1; i <= distance; i++)
		{
			positionList.Add(startPosition + forward * i);
		}
	}

	public Vector3 GetDirection()
	{
		return _forward;
	}

	public int IsAvailable(AutomationCoreItem movingItem)
	{
		return 0;
	}

	public AutomationProcessorData GetSaveData()
	{
		return new AutomationItemPullerData
		{
			typeId = ProcessorID,
			direction = _forward,
			pullDistance = _pullDistance,
			timeBetweenPulls = _timeBetweenPulls,
			affectedHarvestableItemIDs = _validResourcesToHarvest.ToArray(),
			visible = Visible
		};
	}

	public void LoadData(AutomationProcessorData data)
	{
		if (data is AutomationItemPullerData automationItemPullerData)
		{
			ProcessorID = automationItemPullerData.typeId;
			_forward = automationItemPullerData.direction;
			_pullDistance = automationItemPullerData.pullDistance;
			_timeBetweenPulls = automationItemPullerData.timeBetweenPulls;
			_validResourcesToHarvest = new List<string>(automationItemPullerData.affectedHarvestableItemIDs);
			Visible = automationItemPullerData.visible;
		}
	}

	public void SetForwardDirection(Vector3 forward)
	{
		_forward = forward;
	}

	public void SetGridSpace(AutomationGridSpace space)
	{
		_space = space;
		_itemHoldingSpace = new AutomationGridSpace(_space.position + _forward);
		SetupAffectedPositionsList();
	}

	public void Tick(float deltaTime)
	{
		_pullTimer += deltaTime;
		if (_pullTimer >= _timeBetweenPulls)
		{
			if (CanPull())
			{
				DestinationBlocked = false;
				PerformPull();
				_pullTimer = 0f;
			}
			else
			{
				DestinationBlocked = true;
				_pullTimer -= _autoSystem.ItemMoveTime;
			}
		}
	}

	public void DisableVisualCulling()
	{
		Visible = false;
	}

	private bool CanPull()
	{
		if (_autoSystem.GetOrCreateGridSpace(_space.position + _forward).AllItemsOnSpace.Count > 0)
		{
			return false;
		}
		return true;
	}

	private async void PerformPull()
	{
		Vector3 directionOfPull = new Vector3(0f - _forward.x, 0f, 0f - _forward.z);
		PullStart?.Invoke(this, new AutomationPullEventArgs(directionOfPull));
		await Task.Delay(Mathf.RoundToInt(1000f / Time.timeScale));
		_affectedPositions.Add(_space.position + _forward);
		NotifyAffectedItems(start: true, directionOfPull);
		while (Time.timeScale == 0f)
		{
			await Task.Delay(100);
		}
		await Task.Delay(Mathf.RoundToInt(1500f / Time.timeScale));
		HarvestItemsInRange();
		_affectedPositions.Remove(_space.position + _forward);
		MoveItemsToPuller();
		PullEnd?.Invoke(this, EventArgs.Empty);
		await Task.Delay(Mathf.RoundToInt(_autoSystem.ItemMoveTime / 2f));
		AutomationGridSpace orCreateGridSpace = _autoSystem.GetOrCreateGridSpace(_space.position + _forward);
		for (int i = 0; i < orCreateGridSpace.AllItemsOnSpace.Count; i++)
		{
			orCreateGridSpace.AllItemsOnSpace[i].IsReserved = false;
		}
	}

	private void NotifyAffectedItems(bool start, Vector3 directionOfPull)
	{
		for (int i = 0; i < _affectedPositions.Count; i++)
		{
			Vector3 vector = _affectedPositions[i];
			if (_autoSystem.DoesSpaceExist(vector))
			{
				AutomationGridSpace orCreateGridSpace = _autoSystem.GetOrCreateGridSpace(vector);
				if (orCreateGridSpace.Resource != null && orCreateGridSpace.Resource.IsFullyGrown && CanHarvest(orCreateGridSpace.Resource.ID) && start)
				{
					orCreateGridSpace.Resource.StartTornatoadPull(directionOfPull);
				}
			}
		}
	}

	private void HarvestItemsInRange()
	{
		Queue<AutomationCoreItem> droppedItems = new Queue<AutomationCoreItem>();
		for (int i = 0; i < _affectedPositions.Count; i++)
		{
			Vector3 vector = _affectedPositions[i];
			if (!_autoSystem.DoesSpaceExist(vector))
			{
				continue;
			}
			AutomationGridSpace orCreateGridSpace = _autoSystem.GetOrCreateGridSpace(vector);
			if (orCreateGridSpace.Resource != null && orCreateGridSpace.Resource.IsFullyGrown && CanHarvest(orCreateGridSpace.Resource.ID) && orCreateGridSpace.Resource.TakeDamage(orCreateGridSpace.Resource.Health, ref droppedItems))
			{
				while (droppedItems.Count > 0)
				{
					AutomationCoreItem automationCoreItem = droppedItems.Dequeue();
					automationCoreItem.position = orCreateGridSpace.position;
					_autoSystem.TryAddCoreItemToSpace(_itemHoldingSpace, automationCoreItem);
				}
			}
			if (orCreateGridSpace.ActiveItem != null && IsItemMover(orCreateGridSpace))
			{
				orCreateGridSpace.ActiveItem.IsReserved = true;
				orCreateGridSpace.CancelItemMove(orCreateGridSpace.ActiveItem);
			}
		}
	}

	private void MoveItemsToPuller()
	{
		AutomationGridSpace orCreateGridSpace = _autoSystem.GetOrCreateGridSpace(_space.position + _forward);
		for (int i = 0; i < _itemHoldingSpace.AllItemsOnSpace.Count; i++)
		{
			AutomationCoreItem automationCoreItem = _itemHoldingSpace.AllItemsOnSpace[i];
			Vector3 position = automationCoreItem.position;
			if (orCreateGridSpace.TrySetItem(automationCoreItem, ignoreProcessor: true))
			{
				automationCoreItem.position = position;
				IItemMoveType moveType = new AutomationLinearMove(automationCoreItem, orCreateGridSpace.position, _autoSystem.ItemMoveTime / 2f);
				orCreateGridSpace.MoveItemToSpace(moveType);
			}
		}
		_itemHoldingSpace.ClearAllItems();
		for (int j = 0; j < _affectedPositions.Count; j++)
		{
			Vector3 vector = _affectedPositions[j];
			if (!_autoSystem.DoesSpaceExist(vector))
			{
				continue;
			}
			AutomationGridSpace orCreateGridSpace2 = _autoSystem.GetOrCreateGridSpace(vector);
			if (IsItemMover(orCreateGridSpace2))
			{
				orCreateGridSpace2.CancelAllMoves();
			}
			AutomationCoreItem[] array = orCreateGridSpace2.AllItemsOnSpace.ToArray();
			foreach (AutomationCoreItem automationCoreItem2 in array)
			{
				if (!automationCoreItem2.IsMoving)
				{
					Vector3 position2 = automationCoreItem2.position;
					if (orCreateGridSpace.TrySetItem(automationCoreItem2, ignoreProcessor: true))
					{
						orCreateGridSpace2.ClearItem(automationCoreItem2);
						automationCoreItem2.position = position2;
						IItemMoveType moveType2 = new AutomationLinearMove(automationCoreItem2, orCreateGridSpace.position, _autoSystem.ItemMoveTime / 2f);
						orCreateGridSpace.MoveItemToSpace(moveType2);
					}
				}
			}
		}
	}

	private bool IsItemMover(AutomationGridSpace space)
	{
		if (space.itemProcessor is AutomationItemMover)
		{
			return true;
		}
		return false;
	}
}
