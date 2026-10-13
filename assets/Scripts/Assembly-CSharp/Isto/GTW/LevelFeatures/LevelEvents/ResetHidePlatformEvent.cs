using System.Collections.Generic;
using UnityEngine;

namespace Isto.GTW.LevelFeatures.LevelEvents;

public class ResetHidePlatformEvent : LevelEvent
{
	[SerializeField]
	private List<HidePlatformEvent> _eventsToReset = new List<HidePlatformEvent>();

	public override void TriggerEvent(bool initialization = false)
	{
		foreach (HidePlatformEvent item in _eventsToReset)
		{
			item.ResetPlatform();
		}
	}
}
