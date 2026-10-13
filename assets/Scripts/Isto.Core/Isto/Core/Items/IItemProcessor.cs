using Isto.Core.Automation;
using Isto.Core.Data;

namespace Isto.Core.Items;

public interface IItemProcessor
{
	string ProcessorID { get; }

	bool Visible { get; }

	int IsAvailable(AutomationCoreItem movingItem);

	void Tick(float deltaTime);

	AutomationProcessorData GetSaveData();

	void LoadData(AutomationProcessorData data);
}
