using System;
using System.Collections;
using DG.Tweening;
using Isto.GTW.Audio;
using Isto.GTW.Player;
using UnityEngine;
using Zenject;

namespace Isto.GTW.LevelFeatures;

public class MovingObject : MonoBehaviour
{
	[Serializable]
	public class MoveStep
	{
		public Transform targetTransform;

		[Space]
		[Tooltip("Duration to reach this position.")]
		public float moveTime = 1f;

		public Ease easeType = Ease.Linear;

		[Tooltip("Hold this position for this amount of time.")]
		public float delay;

		public bool forceHoldGrab;

		public bool forceDeactivateGrab;

		public Vector3 TargetPosition => targetTransform.position;

		public Vector3 TargetRotation => targetTransform.rotation.eulerAngles;
	}

	public enum LoopType
	{
		LOOP = 0,
		STOP_AT_FIRST = 1,
		STOP_AT_LAST = 2
	}

	public Rigidbody objectToMove;

	public bool startOnAwake = true;

	public LoopType loop;

	[Space]
	public bool exitLaunch;

	public Transform launchDirection;

	public float launchVelocity = 20f;

	public MoveStep[] moveSteps = new MoveStep[0];

	[Space]
	[Header("Sound Effect")]
	[SerializeField]
	private ObstacleAudioOneShot _obstacleAudioOneShot;

	private bool _isExecuting;

	private int _currentPositionIndex;

	private Sequence _sequenceTween;

	private Collider[] _colliders = new Collider[0];

	public Action<int> OnMoveStep;

	private PlayerController _playerController;

	private Vector3 _currentBodyDirection = Vector3.zero;

	public bool IsPlaying
	{
		get
		{
			if (_sequenceTween != null)
			{
				return _sequenceTween.IsPlaying();
			}
			return false;
		}
	}

	public bool IsExecuting
	{
		get
		{
			return _isExecuting;
		}
		set
		{
			_isExecuting = value;
		}
	}

	public bool IsGrabbingMovingObject => _playerController.GrabLinkParentRigidbody == objectToMove;

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
		objectToMove.isKinematic = true;
		objectToMove.useGravity = false;
		objectToMove.collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
		_colliders = GetComponentsInChildren<Collider>();
		InitializeToFirstPosition();
		if (startOnAwake)
		{
			Play();
		}
	}

	public void OnDestroy()
	{
		PlayerController playerController = _playerController;
		playerController.OnActivateGrab = (Action)Delegate.Remove(playerController.OnActivateGrab, new Action(PlayerController_OnActivateGrab));
		PlayerController playerController2 = _playerController;
		playerController2.OnDeactivateGrab = (Action)Delegate.Remove(playerController2.OnDeactivateGrab, new Action(PlayerController_OnDeactivateGrab));
		if (_sequenceTween != null)
		{
			_sequenceTween.Kill();
			_sequenceTween = null;
		}
	}

	private void OnValidate()
	{
		if (objectToMove != null)
		{
			objectToMove.isKinematic = true;
			objectToMove.useGravity = false;
			objectToMove.collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
		}
	}

	private void PlayerController_OnActivateGrab()
	{
		if (moveSteps[_currentPositionIndex].forceHoldGrab && IsGrabbingMovingObject)
		{
			_playerController.ForceHoldGrab = true;
		}
	}

	private void PlayerController_OnDeactivateGrab()
	{
		if (exitLaunch && moveSteps[_currentPositionIndex].forceDeactivateGrab && _playerController.GrabLinkParentRigidbody == objectToMove)
		{
			StartCoroutine(DisableColliders(0.5f));
			Vector3 vector = _currentBodyDirection;
			if (_playerController.Velocity.sqrMagnitude > 0.001f)
			{
				vector = _playerController.Velocity.normalized;
			}
			_playerController.SetVelocity(vector * launchVelocity, Vector3.zero);
		}
	}

	public void InitializeToFirstPosition()
	{
		MoveStep moveStep = moveSteps[0];
		objectToMove.transform.position = moveStep.TargetPosition;
		objectToMove.transform.rotation = Quaternion.Euler(moveStep.TargetRotation);
	}

	public void Play()
	{
		if (_obstacleAudioOneShot != null && !_isExecuting && !IsPlaying)
		{
			_obstacleAudioOneShot.PlaySound();
		}
		if (!_isExecuting && !IsPlaying)
		{
			_isExecuting = true;
			MoveToNextPoint();
		}
	}

	public void Stop()
	{
		_isExecuting = false;
	}

	public void MoveToNextPoint()
	{
		if (moveSteps.Length == 0)
		{
			Debug.LogError("_movePositions is empty!", base.gameObject);
		}
		else
		{
			if (!_isExecuting || IsPlaying)
			{
				return;
			}
			if (_currentPositionIndex == moveSteps.Length - 1 && loop == LoopType.STOP_AT_LAST)
			{
				_isExecuting = false;
				return;
			}
			_currentPositionIndex++;
			_currentPositionIndex %= moveSteps.Length;
			MoveStep moveStep = moveSteps[_currentPositionIndex];
			if (_sequenceTween != null)
			{
				_sequenceTween.Kill();
				_sequenceTween = null;
			}
			_sequenceTween = DOTween.Sequence();
			if (_currentPositionIndex == 0 && loop == LoopType.STOP_AT_FIRST)
			{
				_sequenceTween = CreateSequence(moveStep);
				_isExecuting = false;
			}
			else
			{
				_sequenceTween = CreateSequence(moveStep);
				_sequenceTween.OnComplete(MoveToNextPoint);
			}
		}
	}

	public Sequence CreateSequence(MoveStep moveStep)
	{
		return DOTween.Sequence().Join(objectToMove.DOMove(moveStep.TargetPosition, moveStep.moveTime).SetEase(moveStep.easeType)).Join(objectToMove.DORotate(moveStep.TargetRotation, moveStep.moveTime).SetEase(moveStep.easeType))
			.AppendCallback(MoveStepFinished)
			.AppendInterval(moveStep.delay);
	}

	private void MoveStepFinished()
	{
		if (OnMoveStep != null)
		{
			OnMoveStep(_currentPositionIndex);
		}
		if (_playerController.IsGrabLinkActive && moveSteps[_currentPositionIndex].forceDeactivateGrab && (_playerController.GrabLinkParentRigidbody == objectToMove || _playerController.GrabLinkParentRigidbody.transform.IsChildOf(objectToMove.transform)))
		{
			bool flag = false;
			if (launchDirection != null && new Plane(launchDirection.forward, _playerController.PlayerModelController.transform.position).GetDistanceToPoint(_playerController.Rigidbody.position) < 0f)
			{
				flag = true;
			}
			_playerController.ForceHoldGrab = false;
			_currentBodyDirection = _playerController.Direction;
			if ((launchDirection != null) & flag)
			{
				_currentBodyDirection = launchDirection.forward;
				_playerController.TeleportCharacter(_playerController.PlayerModelController.transform.position);
			}
			_playerController.DeactivateGrabLink(0.5f);
			if (exitLaunch)
			{
				_playerController.SetVelocity(_currentBodyDirection * launchVelocity, Vector3.zero);
			}
		}
	}

	private IEnumerator DisableColliders(float duration)
	{
		Collider[] colliders = _colliders;
		for (int i = 0; i < colliders.Length; i++)
		{
			colliders[i].enabled = false;
		}
		yield return new WaitForSeconds(duration);
		colliders = _colliders;
		for (int i = 0; i < colliders.Length; i++)
		{
			colliders[i].enabled = true;
		}
	}
}
