using UnityEngine;

namespace Isto.GTW.LevelFeatures.LevelEvents;

public class DelayTriggerEvent : LevelEvent
{
	[SerializeField]
	public LevelEvent _levelEvent;

	[SerializeField]
	[Tooltip("Delay to trigger level event in seconds.")]
	public float _delay = 3f;

	private float _time;

	private bool _triggerDelayStarted;

	private void Update()
	{
		if (_triggerDelayStarted)
		{
			_time += Time.deltaTime;
			if (_time >= _delay)
			{
				_triggerDelayStarted = false;
				_levelEvent.TriggerEvent();
				_levelEvent.SetTriggered(triggered: true);
			}
		}
	}

	public override void TriggerEvent(bool initialization = false)
	{
		if (initialization)
		{
			_levelEvent.TriggerEvent(initialization);
			_levelEvent.TriggerEvent(initialization: true);
		}
		else if (!_triggerDelayStarted)
		{
			_triggerDelayStarted = true;
			_time = 0f;
		}
	}
}
