using System;
using System.Collections.Generic;
using Isto.GTW.Managers;
using Isto.GTW.Tools;
using UnityEngine;
using Zenject;

namespace Isto.GTW.LevelFeatures.LevelEvents;

[RequireComponent(typeof(LevelEventTrigger))]
public class LevelEventTriggerSerializer : MonoBehaviour
{
	[SerializeField]
	protected string _id = "UNIQUE_ID";

	[Tooltip("These LevelEvents will be triggered on awake if the LevelEventTrigger was triggered previously..")]
	[SerializeField]
	private List<LevelEvent> _initializeEvents = new List<LevelEvent>();

	public static readonly string TRIGGER_SUFFIX = "_Triggered";

	private LevelEventTrigger _levelEventTrigger;

	private LevelVariables _levelVariables;

	private string TriggeredId => _id + TRIGGER_SUFFIX;

	[Inject]
	public void Inject(LevelVariables levelVariables)
	{
		_levelVariables = levelVariables;
	}

	private void Awake()
	{
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
		HandleLevelEventTrigger();
	}

	private void LevelEventTrigger_OnTriggerEvent()
	{
		_levelVariables.SetBool(TriggeredId, value: true);
	}

	protected void SetDirty()
	{
	}

	private void HandleLevelEventTrigger()
	{
		bool flag = _levelVariables.GetBool(TriggeredId);
		_levelEventTrigger.wasTriggered = flag;
		if (!flag)
		{
			return;
		}
		foreach (LevelEvent initializeEvent in _initializeEvents)
		{
			initializeEvent.TriggerEvent();
		}
	}
}
