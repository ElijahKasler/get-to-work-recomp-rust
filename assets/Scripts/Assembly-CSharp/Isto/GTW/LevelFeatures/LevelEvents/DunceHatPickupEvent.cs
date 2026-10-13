using Isto.Core;

namespace Isto.GTW.LevelFeatures.LevelEvents;

public class DunceHatPickupEvent : WearablePickupEvent
{
	public override void TriggerEvent(bool initialization = false)
	{
		base.TriggerEvent(initialization);
		Events.RaiseEvent(GTWEvents.DUNCE_HAT_PICKUP);
	}
}
