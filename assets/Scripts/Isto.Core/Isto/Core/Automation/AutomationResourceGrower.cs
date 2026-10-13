using System;
using Isto.Core.Data;
using Isto.Core.Items;
using UnityEngine;
using Zenject;

namespace Isto.Core.Automation;

public class AutomationResourceGrower : IItemProcessor
{
	public class Factory : PlaceholderFactory<AutomationResourceGrowerParams, string, AutomationResourceGrower>
	{
	}

	[Inject]
	private MasterItemList _masteritemList;

	[Inject]
	private AutomationSystem _system;

	[Inject]
	private AutomationResource.Factory _resourceFactory;

	private AutomationResourceGrowerParams _params;

	public string ProcessorID { get; private set; }

	public float GrowPoints { get; private set; }

	public bool Visible => false;

	public event EventHandler GrowingCompleted;

	public AutomationResourceGrower(AutomationResourceGrowerParams growParams, string processorTypeID)
	{
		_params = growParams;
		ProcessorID = processorTypeID;
	}

	public AutomationProcessorData GetSaveData()
	{
		return new AutomationProcessorData
		{
			typeId = ProcessorID
		};
	}

	public int IsAvailable(AutomationCoreItem movingItem)
	{
		if (movingItem == null)
		{
			return 0;
		}
		if (!movingItem.ID.Equals(_params.seedItemID, StringComparison.CurrentCultureIgnoreCase))
		{
			return 0;
		}
		return 1;
	}

	public void LoadData(AutomationProcessorData data)
	{
		Debug.LogError("NOT IMPLEMENTED");
	}

	public void Tick(float deltaTime)
	{
		GrowPoints += _params.growthRate * Time.deltaTime;
		if (GrowPoints > _params.growthRequired)
		{
			if (_system.TryRemoveResource(_params.worldPosition))
			{
				HarvestableItem itemByID = _masteritemList.GetItemByID<HarvestableItem>(_params.readyItemID);
				_system.TryAddResource(_params.worldPosition, itemByID);
				_system.TryRemoveProcessor(_params.worldPosition);
				GrowingCompleted?.Invoke(this, EventArgs.Empty);
			}
			else
			{
				Vector3 worldPosition = _params.worldPosition;
				Debug.LogError("Couldn't remove AutomationResourceGrower from world position " + worldPosition.ToString());
			}
		}
	}
}
