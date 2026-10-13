using Isto.GTW.Managers;
using UnityEngine;
using Zenject;

namespace Isto.GTW.LevelFeatures.LevelEvents;

public class BoolSwitchTriggerEvent : LevelEvent
{
	[SerializeField]
	private string _id = "BOOL_VARIABLE_ID";

	[Space]
	[SerializeField]
	private LevelEvent _falseLevelEvent;

	[SerializeField]
	private LevelEvent _trueLevelEvent;

	private LevelVariables _levelVariables;

	[Inject]
	public void Inject(LevelVariables levelVariables)
	{
		_levelVariables = levelVariables;
	}

	public override void TriggerEvent(bool initialization = false)
	{
		bool flag = _levelVariables.GetBool(_id);
		if (!flag && _falseLevelEvent != null)
		{
			_falseLevelEvent.TriggerEvent();
			_falseLevelEvent.SetTriggered(triggered: true);
		}
		else if (flag && _trueLevelEvent != null)
		{
			_trueLevelEvent.TriggerEvent();
			_trueLevelEvent.SetTriggered(triggered: true);
		}
	}
}
