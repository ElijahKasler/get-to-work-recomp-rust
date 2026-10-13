using System;
using System.Collections.Generic;
using Isto.GTW.Managers;
using UnityEngine;
using Zenject;

namespace Isto.GTW.LevelFeatures.LevelEvents;

public class IntSwitchTriggerEvent : LevelEvent
{
	[Serializable]
	private class EventSwitchCase
	{
		public int _value;

		public LevelEvent _levelEvent;
	}

	[SerializeField]
	private string _id = "INT_VARIABLE_ID";

	[Space]
	[SerializeField]
	private List<EventSwitchCase> _eventSwitchCases = new List<EventSwitchCase>();

	private LevelVariables _levelVariables;

	[Inject]
	public void Inject(LevelVariables levelVariables)
	{
		_levelVariables = levelVariables;
	}

	public override void TriggerEvent(bool initialization = false)
	{
		int num = _levelVariables.GetInt(_id);
		for (int i = 0; i < _eventSwitchCases.Count; i++)
		{
			if (_eventSwitchCases[i]._value == num && _eventSwitchCases[i]._levelEvent != null && _eventSwitchCases[i]._levelEvent.IsTriggerEventValid)
			{
				_eventSwitchCases[i]._levelEvent.TriggerEvent();
				_eventSwitchCases[i]._levelEvent.SetTriggered(triggered: true);
			}
		}
	}
}
