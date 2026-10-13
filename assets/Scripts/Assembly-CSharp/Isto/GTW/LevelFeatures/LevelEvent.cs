using System;
using UnityEngine;

namespace Isto.GTW.LevelFeatures;

public abstract class LevelEvent : MonoBehaviour
{
	[SerializeField]
	protected LevelEventTrigger _levelEventTrigger;

	[SerializeField]
	private bool _triggerOnce;

	[SerializeField]
	private bool _wasTriggered;

	public bool IsTriggerEventValid
	{
		get
		{
			if (_triggerOnce)
			{
				return !_wasTriggered;
			}
			return true;
		}
	}

	protected virtual void Awake()
	{
		if (_levelEventTrigger != null)
		{
			LevelEventTrigger levelEventTrigger = _levelEventTrigger;
			levelEventTrigger.OnTriggerEvent = (Action)Delegate.Combine(levelEventTrigger.OnTriggerEvent, new Action(LevelEventTrigger_OnTriggerEvent));
		}
	}

	protected virtual void Reset()
	{
		_levelEventTrigger = GetComponent<LevelEventTrigger>();
	}

	protected virtual void OnDestroy()
	{
		if (_levelEventTrigger != null)
		{
			LevelEventTrigger levelEventTrigger = _levelEventTrigger;
			levelEventTrigger.OnTriggerEvent = (Action)Delegate.Remove(levelEventTrigger.OnTriggerEvent, new Action(LevelEventTrigger_OnTriggerEvent));
		}
	}

	[ContextMenu("Test Trigger")]
	private void LevelEventTrigger_OnTriggerEvent()
	{
		TriggerEvent();
		_wasTriggered = true;
	}

	internal void SetTriggered(bool triggered)
	{
		_wasTriggered = triggered;
	}

	public abstract void TriggerEvent(bool initialization = false);
}
