using System.Collections.Generic;
using Isto.Core.StateMachine;
using UnityEngine;

namespace Isto.Core.AI;

public abstract class AIAction : MonoBehaviour
{
	[Header("Properties")]
	public Sprite activeIcon;

	public bool isInteruptable;

	public bool isRunning;

	[Tooltip("Bonus given to this actions weighting if it is currently running.")]
	public float interia;

	[Header("Considerations")]
	public List<AIConsideration> considerations = new List<AIConsideration>();

	protected MobStateMachine _controller;

	protected float _lastRunTime;

	public float LastRunTime => _lastRunTime;

	public virtual void StartAction(MobStateMachine controller)
	{
		isRunning = true;
		if (controller.actionIcon != null)
		{
			controller.actionIcon.sprite = activeIcon;
		}
		_controller = controller;
	}

	public virtual void StopAction()
	{
		_controller.actionIcon.sprite = null;
		isRunning = false;
		_lastRunTime = Time.time;
	}

	public abstract void UpdateAction();
}
