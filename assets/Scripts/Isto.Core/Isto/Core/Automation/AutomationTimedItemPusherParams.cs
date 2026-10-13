namespace Isto.Core.Automation;

public class AutomationTimedItemPusherParams
{
	public int distance;

	public string processorTypeId;

	public float pushCoolDownTime;

	public AutomationTimedItemPusherParams(int distance, float pushCoolDownTime, string processorTypeId)
	{
		this.distance = distance;
		this.pushCoolDownTime = pushCoolDownTime;
		this.processorTypeId = processorTypeId;
	}
}
