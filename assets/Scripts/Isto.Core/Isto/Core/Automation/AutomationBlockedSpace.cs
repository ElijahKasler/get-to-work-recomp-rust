using Isto.Core.Data;
using Isto.Core.Items;

namespace Isto.Core.Automation;

public class AutomationBlockedSpace : IItemProcessor
{
	public string ProcessorID => "";

	public bool Visible => false;

	public AutomationProcessorData GetSaveData()
	{
		return null;
	}

	public int IsAvailable(AutomationCoreItem movingItem)
	{
		return 0;
	}

	public void LoadData(AutomationProcessorData data)
	{
	}

	public void Tick(float deltaTime)
	{
	}
}
