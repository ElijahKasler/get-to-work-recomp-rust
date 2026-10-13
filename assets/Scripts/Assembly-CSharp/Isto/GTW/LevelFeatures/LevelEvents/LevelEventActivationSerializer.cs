using System;
using Isto.GTW.Managers;
using Isto.GTW.Tools;
using UnityEngine;
using Zenject;

namespace Isto.GTW.LevelFeatures.LevelEvents;

[RequireComponent(typeof(LevelEvent))]
[RequireComponent(typeof(LevelEventTrigger))]
public class LevelEventActivationSerializer : MonoBehaviour
{
	[SerializeField]
	protected string _id = "UNIQUE_ID";

	[SerializeField]
	private LevelEvent _monitoredEvent;

	[SerializeField]
	private bool _initializeOnLoad;

	private LevelEvent _levelEvent;

	private LevelEventTrigger _levelEventTrigger;

	private LevelVariables _levelVariables;

	private string TriggeredId => _id + "_Triggered";

	[Inject]
	public void Inject(LevelVariables levelVariables)
	{
		_levelVariables = levelVariables;
	}

	private void Awake()
	{
		_levelEvent = GetComponent<LevelEvent>();
		_levelEventTrigger = GetComponent<LevelEventTrigger>();
		LevelEventTrigger levelEventTrigger = _levelEventTrigger;
		levelEventTrigger.OnTriggerEvent = (Action)Delegate.Combine(levelEventTrigger.OnTriggerEvent, new Action(LevelEventTrigger_OnTriggerEvent));
	}

	protected virtual void Reset()
	{
		_id = GTWExtensions.RandomString(10);
		SetDirty();
	}

	private void Start()
	{
		if (_levelVariables.GetBool(TriggeredId))
		{
			if (_initializeOnLoad)
			{
				_levelEvent.TriggerEvent();
			}
			_levelEvent.SetTriggered(triggered: true);
		}
	}

	private void LevelEventTrigger_OnTriggerEvent()
	{
		_levelVariables.SetBool(TriggeredId, value: true);
	}

	protected void SetDirty()
	{
	}
}
