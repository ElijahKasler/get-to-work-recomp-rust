using Isto.Core.Data;
using Isto.Core.Items;

namespace Isto.Core.Automation;

public class AutomationProcessorProxy : IItemProcessor
{
	private IItemProcessor _linkedProcessor;

	public string ProcessorID => "ProcessorProxy";

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

	public AutomationProcessorProxy(IItemProcessor linkedProcessor)
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
		return _linkedProcessor.IsAvailable(movingItem);
	}

	public void LoadData(AutomationProcessorData data)
	{
	}
}
