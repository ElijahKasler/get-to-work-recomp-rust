using Isto.GTW.Player;
using PixelCrushers.DialogueSystem;
using UnityEngine;

namespace Isto.GTW.LevelFeatures.LevelEventTriggers;

public class PlayerCollisionFailureEventTrigger : LevelEventTrigger
{
	[Space]
	[SerializeField]
	private Condition _dialogueCondition = new Condition();

	[Header("Failure conditions")]
	[SerializeField]
	private float _delayBeforeTrigger;

	[SerializeField]
	private float _speedKPHLoss;

	private float _entrySpeed;

	private bool _isInsideCollider;

	private bool _readyToTrigger;

	private float _timeInside;

	private PlayerController PlayerController => PlayerController.CurrentPlayer;

	protected override void Reset()
	{
		base.Reset();
		_dialogueCondition.acceptedTags = new string[1] { "PlayerEventTrigger" };
	}

	private void OnTriggerEnter(Collider other)
	{
		if (IsPlayerEventTrigger(other))
		{
			_isInsideCollider = true;
			_timeInside = 0f;
			_entrySpeed = PlayerController.CurrentSpeedKPH;
			_readyToTrigger = true;
		}
	}

	private void OnTriggerStay(Collider other)
	{
		if (IsPlayerEventTrigger(other))
		{
			bool flag = false;
			_timeInside += Time.deltaTime;
			if (_delayBeforeTrigger > 0f && _timeInside > _delayBeforeTrigger)
			{
				flag = true;
			}
			float num = Mathf.Abs(_speedKPHLoss);
			if (num > 0f && _entrySpeed > num && PlayerController.CurrentSpeedKPH < _entrySpeed - num)
			{
				flag = true;
			}
			if (flag)
			{
				OnTrigger(other);
			}
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (IsPlayerEventTrigger(other))
		{
			_isInsideCollider = false;
			_timeInside = 0f;
			_readyToTrigger = false;
		}
	}

	private void OnTrigger(Collider other)
	{
		if (_readyToTrigger)
		{
			if (_dialogueCondition.IsTrue(other.transform))
			{
				TriggerEvent();
			}
			_readyToTrigger = false;
		}
	}

	private bool IsPlayerEventTrigger(Collider other)
	{
		return other.gameObject.GetComponentInParent<PlayerEventTrigger>() != null;
	}
}
