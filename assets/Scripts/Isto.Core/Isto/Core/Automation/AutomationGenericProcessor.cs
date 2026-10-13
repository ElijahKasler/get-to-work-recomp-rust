using Isto.Core.Data;
using Isto.Core.Items;
using UnityEngine;
using Zenject;

namespace Isto.Core.Automation;

public class AutomationGenericProcessor : IItemProcessor
{
	public class Factory : PlaceholderFactory<string, AutomationGenericProcessor>
	{
	}

	public string ProcessorID { get; private set; }

	public bool Visible { get; private set; }

	public Vector3 Direction { get; set; }

	public AutomationGenericProcessor(string itemId)
	{
		Visible = true;
		ProcessorID = itemId;
	}

	public AutomationProcessorData GetSaveData()
	{
		return new AutomationProcessorData
		{
			typeId = ProcessorID,
			direction = Direction
		};
	}

	public void LoadData(AutomationProcessorData data)
	{
		ProcessorID = data.typeId;
		Direction = data.direction;
	}

	public int IsAvailable(AutomationCoreItem movingItem)
	{
		return 0;
	}

	public void Tick(float deltaTime)
	{
	}

	public void SetVisible(bool isVisible)
	{
		Visible = isVisible;
	}
}
