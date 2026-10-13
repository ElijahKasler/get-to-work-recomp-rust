using UnityEngine;

namespace Isto.GTW.LevelFeatures.LevelEventTriggers;

public class ApplicationQuitEventTrigger : LevelEventTrigger
{
	[SerializeField]
	private bool _triggerOnApplicationQuit = true;

	[SerializeField]
	private bool _triggerOnLoseFocus;

	[SerializeField]
	private bool _triggerOnFocus;

	private void OnApplicationQuit()
	{
		if (_triggerOnApplicationQuit)
		{
			TriggerEvent();
		}
	}

	private void OnApplicationFocus(bool hasFocus)
	{
		if (hasFocus && _triggerOnFocus)
		{
			TriggerEvent();
		}
		else if (!hasFocus && _triggerOnLoseFocus)
		{
			TriggerEvent();
		}
	}
}
