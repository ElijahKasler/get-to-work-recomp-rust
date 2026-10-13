using Isto.Core.Data;
using Isto.Core.Items;
using UnityEngine;

namespace Isto.Core.Automation;

public class AutomationResearchBoosterEntrance : IItemProcessor, IAutomationGridSpaceUser, IAutomationInventory
{
	private AutomationGridSpace _space;

	private AutomationResearchBooster _booster;

	public string ProcessorID => "BoosterEntrance";

	public bool Visible => false;

	public AutomationResearchBoosterEntrance(AutomationResearchBooster booster)
	{
		_booster = booster;
	}

	public AutomationProcessorData GetSaveData()
	{
		return null;
	}

	public int IsAvailable(AutomationCoreItem movingItem)
	{
		return _booster.IsAvailable(movingItem);
	}

	public void LoadData(AutomationProcessorData data)
	{
		Debug.LogError("Loading data into AutomationResearchBoosterEntrance, this shouldn't happen");
	}

	public void SetGridSpace(AutomationGridSpace space)
	{
		_space = space;
	}

	public void Tick(float deltaTime)
	{
	}

	public IInventory GetInventory()
	{
		return _booster.GetInventory();
	}
}
