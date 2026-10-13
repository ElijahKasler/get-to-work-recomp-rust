using System;
using System.Collections.Generic;
using Isto.GTW.Player;
using UnityEngine;
using Zenject;

namespace Isto.GTW.LevelFeatures.LevelEventTriggers;

public class PlayerGrabEventTrigger : LevelEventTrigger
{
	private enum TriggerType
	{
		START = 0,
		RELEASE = 1,
		WHILE_GRABING = 2,
		WHILE_NOT_GRABING = 3
	}

	[Space]
	[SerializeField]
	private TriggerType triggerOn;

	[SerializeField]
	private List<Collider> _grabColliders = new List<Collider>();

	protected PlayerController _playerController;

	private bool _colliderCondition;

	private bool _isGrabbing;

	[Inject]
	public void Inject(PlayerController playerController)
	{
		_playerController = playerController;
	}

	private void Awake()
	{
		PlayerController playerController = _playerController;
		playerController.OnActivateGrab = (Action)Delegate.Combine(playerController.OnActivateGrab, new Action(PlayerController_OnActivateGrab));
		PlayerController playerController2 = _playerController;
		playerController2.OnDeactivateGrab = (Action)Delegate.Combine(playerController2.OnDeactivateGrab, new Action(PlayerController_OnDeactivateGrab));
	}

	private void Update()
	{
		if (triggerOn == TriggerType.WHILE_GRABING || triggerOn == TriggerType.WHILE_NOT_GRABING)
		{
			_colliderCondition = ColliderCondition();
			if (_isGrabbing && triggerOn == TriggerType.WHILE_GRABING && _colliderCondition)
			{
				TriggerEvent();
			}
			else if (!_isGrabbing && triggerOn == TriggerType.WHILE_NOT_GRABING)
			{
				TriggerEvent();
			}
		}
	}

	private void OnDestroy()
	{
		PlayerController playerController = _playerController;
		playerController.OnActivateGrab = (Action)Delegate.Remove(playerController.OnActivateGrab, new Action(PlayerController_OnActivateGrab));
		PlayerController playerController2 = _playerController;
		playerController2.OnDeactivateGrab = (Action)Delegate.Remove(playerController2.OnDeactivateGrab, new Action(PlayerController_OnDeactivateGrab));
	}

	private void PlayerController_OnActivateGrab()
	{
		_isGrabbing = true;
		_colliderCondition = ColliderCondition();
		if (triggerOn == TriggerType.START && _colliderCondition)
		{
			TriggerEvent();
		}
	}

	private void PlayerController_OnDeactivateGrab()
	{
		_isGrabbing = false;
		if (triggerOn == TriggerType.RELEASE && _colliderCondition)
		{
			TriggerEvent();
		}
		_colliderCondition = false;
	}

	private bool ColliderCondition()
	{
		return _grabColliders.Contains(_playerController.GrabLinkCollider);
	}
}
