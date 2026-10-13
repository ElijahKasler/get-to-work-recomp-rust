namespace Isto.Core.Automation;

public class AutomationItemPusherParams
{
	public int distance;

	public int pushInterval;

	public int currentCount;

	public string processorTypeId;

	public AutomationItemPusherParams(int distance, int pushInterval, int currentCount, string processorTypeId)
	{
		this.distance = distance;
		this.pushInterval = pushInterval;
		this.currentCount = currentCount;
		this.processorTypeId = processorTypeId;
	}
}
