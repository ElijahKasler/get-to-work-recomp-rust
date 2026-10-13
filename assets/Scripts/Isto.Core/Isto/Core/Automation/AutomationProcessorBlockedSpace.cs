using Isto.Core.Data;
using Isto.Core.Items;

namespace Isto.Core.Automation;

public class AutomationProcessorBlockedSpace : IItemProcessor
{
	private IItemProcessor _linkedProcessor;

	public string ProcessorID => "ProcessorBlockedSpace";

	public string LinkedProcessorID
	{
		get
		{
			if (_linkedProcessor == null)
			{
				return "Empty";
			}
			return _linkedProcessor.ProcessorID;
		}
	}

	public IItemProcessor LinkedProcessor => _linkedProcessor;

	public bool Visible => false;

	public AutomationProcessorBlockedSpace(IItemProcessor linkedProcessor)
	{
		_linkedProcessor = linkedProcessor;
	}

	public void Tick(float deltaTime)
	{
	}

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
}
