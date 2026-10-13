using System;
using System.Collections;
using System.Collections.Generic;
using Isto.GTW.Tools;
using RootMotion.Demos;
using RootMotion.FinalIK;
using UnityEngine;

namespace Isto.GTW.Player;

public class PlayerIkController : MonoBehaviour
{
	[SerializeField]
	private FullBodyBipedIK _fullBodyBipedIK;

	[Space]
	[SerializeField]
	private Transform _pelvisBone;

	[Header("Effectors")]
	[SerializeField]
	private OffsetEffector _pelvisEffector;

	[SerializeField]
	private OffsetEffector _leftShoulderEffector;

	[SerializeField]
	private OffsetEffector _rightShoulderEffector;

	[SerializeField]
	private OffsetEffector _leftHandEffector;

	[SerializeField]
	private OffsetEffector _rightHandEffector;

	[SerializeField]
	private OffsetEffector _leftFootEffector;

	[SerializeField]
	private OffsetEffector _rightFootEffector;

	[Space]
	[Header("Body Swing")]
	[Tooltip("Affects how quickly the torso swings/bounces when touching an objects (ground or wall).\n\ni.e. when you land on the ground, we apply a lag on pelvis to add a secondary motion to the animation. Makes the character feel less rigid\nA low value won't have any swing or bounce, a larger value with increase how far you swing/bounce up and down.")]
	[SerializeField]
	private float _bodyGroundedSwingVelocityCoefficient = 0.03f;

	[Tooltip("How far we lift the IK effector of the pelvis when leaving a jump. \n\nBy lifting the pelvis when taking off from a jump, it makes the character slightly bounce so it looks like hes jumps with his arms and legs.\nThis gives the character a subtle movement when leaving jumps that feels good.\nA low value won't have any swing or bounce, a larger value, the more pelvis and chest will lift.")]
	[SerializeField]
	private float _bodyAirSwingVelocityCoefficient = 0.1f;

	[Tooltip("Hard limits on how far we can swing the pelvis/shoulders. \n- 0 is the resting position of the body. \n- Used to avoid having the model overextending arms and legs and also clipping into the ground.\n- Values are determined based on the character size.")]
	[SerializeField]
	private float _bodySwingMinHeight = -0.1f;

	[Tooltip("Hard limits on how far we can swing the pelvis/shoulders. \n- 0 is the resting position of the body. \n- Used to avoid having the model overextending arms and legs and also clipping into the ground.\n- Values are determined based on the character size.")]
	[SerializeField]
	private float _bodySwingMaxHeight = 0.3f;

	[Tooltip("How quickly or slowly the IK Spring (that controls the bodies swing/bounce) slows down\n- A lower value means takes longer to slow down\n- A higher value will slow down the spring more\n")]
	[SerializeField]
	private float _bodySwingDamp = 30f;

	[Tooltip("How much the IK Spring (that controls the bodies swing/bounce) can compress.\n- Higher makes the spring harder to compress.\n- Lower makes the spring more easily compressed")]
	[SerializeField]
	private float _bodySwingStiffness = 500f;

	private PlayerController _playerController;

	private PlayerModelController _playerModelController;

	private PlayerRagdoll _playerRagdoll;

	private Dictionary<OffsetEffector, Coroutine> _effectorWeightChangeCoroutines = new Dictionary<OffsetEffector, Coroutine>();

	private float _bodyVerticalOffset;

	private float _bodyVerticalOffsetVelocity;

	private Vector3 _bodyHorizontalOffset = Vector3.zero;

	private Vector3 _bodyHorizontalOffsetVelocity = Vector3.zero;

	private float _timeGrounded;

	private float _timeInAir;

	private float _landedTime = -1f;

	private float _jumpingTime = -1f;

	private Vector3 _horizontalOffsetTarget = Vector3.zero;

	public PlayerController PlayerController => _playerController;

	public PlayerCollisionHandler PlayerCollisionHandler => _playerController.PlayerCollisionHandler;

	public FullBodyBipedIK FullBodyBipedIK => _fullBodyBipedIK;

	public PlayerRagdoll PlayerRagdoll => _playerRagdoll;

	public Transform PelvisBone => _pelvisBone;

	public OffsetEffector Pelvis => _pelvisEffector;

	public OffsetEffector LeftShoulder => _leftShoulderEffector;

	public OffsetEffector RightShoulder => _rightShoulderEffector;

	public OffsetEffector LeftHand => _leftHandEffector;

	public OffsetEffector RightHand => _rightHandEffector;

	public OffsetEffector LeftFoot => _leftFootEffector;

	public OffsetEffector RightFoot => _rightFootEffector;

	private void Awake()
	{
		_playerController = GetComponentInParent<PlayerController>();
		_playerModelController = GetComponent<PlayerModelController>();
		_playerRagdoll = GetComponent<PlayerRagdoll>();
		PlayerController playerController = _playerController;
		playerController.OnResetVelocity = (Action)Delegate.Combine(playerController.OnResetVelocity, new Action(PlayerController_OnResetVelocity));
		IKSolverFullBodyBiped solver = _fullBodyBipedIK.solver;
		solver.OnPreUpdate = (IKSolver.UpdateDelegate)Delegate.Combine(solver.OnPreUpdate, new IKSolver.UpdateDelegate(FullBodyBiped_OnPreUpdate));
		Collider[] componentsInChildren = GetComponentsInChildren<Collider>();
		foreach (Collider collider in componentsInChildren)
		{
			Physics.IgnoreCollision(_playerController.MainBallCollider, collider);
		}
	}

	private void OnDestroy()
	{
		PlayerController playerController = _playerController;
		playerController.OnResetVelocity = (Action)Delegate.Remove(playerController.OnResetVelocity, new Action(PlayerController_OnResetVelocity));
		IKSolverFullBodyBiped solver = _fullBodyBipedIK.solver;
		solver.OnPreUpdate = (IKSolver.UpdateDelegate)Delegate.Remove(solver.OnPreUpdate, new IKSolver.UpdateDelegate(FullBodyBiped_OnPreUpdate));
	}

	private void FullBodyBiped_OnPreUpdate()
	{
		if (!_playerRagdoll.IsRagdollEnabled)
		{
			UpdateBodyVerticalSwing();
			UpdateBodyHorizontalSwing();
		}
	}

	public void SetEffectorWeight(OffsetEffector effector, float weight, float duration = 0f)
	{
		if (_effectorWeightChangeCoroutines.TryGetValue(effector, out var value))
		{
			StopCoroutine(value);
			_effectorWeightChangeCoroutines.Remove(effector);
		}
		if (duration <= 0f)
		{
			effector.weight = weight;
		}
		else
		{
			_effectorWeightChangeCoroutines.Add(effector, StartCoroutine(ChangeEffectorWeight(effector, weight, duration)));
		}
	}

	public void SetSameWeightForAllEffectors(float weight, float duration = 0f)
	{
		SetEffectorWeight(Pelvis, weight, duration);
		SetEffectorWeight(LeftShoulder, weight, duration);
		SetEffectorWeight(RightShoulder, weight, duration);
		SetEffectorWeight(LeftHand, weight, duration);
		SetEffectorWeight(RightHand, weight, duration);
		SetEffectorWeight(LeftFoot, weight, duration);
		SetEffectorWeight(RightFoot, weight, duration);
	}

	private IEnumerator ChangeEffectorWeight(OffsetEffector effector, float targetWeight, float duration)
	{
		float time = 0f;
		float initialWeight = effector.weight;
		do
		{
			time = Mathf.Min(Time.deltaTime + time, duration);
			effector.weight = Mathf.Lerp(initialWeight, targetWeight, time / duration);
			yield return null;
		}
		while (time < duration);
		_effectorWeightChangeCoroutines.Remove(effector);
	}

	private void UpdateBodyVerticalSwing()
	{
		_landedTime -= Time.deltaTime;
		_jumpingTime -= Time.deltaTime;
		if (_playerController.PlayerCollisionHandler.IsGrounded)
		{
			_timeGrounded += Time.deltaTime;
			if (_timeInAir > 0.15f)
			{
				_landedTime = 1f;
			}
			_timeInAir = 0f;
			_jumpingTime = -1f;
		}
		else
		{
			if (_timeGrounded > 0.25f)
			{
				_jumpingTime = 1f;
			}
			_timeGrounded = 0f;
			_timeInAir += Time.deltaTime;
		}
		float num = 0f;
		float num2 = 0f;
		if (float.IsNaN(_bodyVerticalOffsetVelocity))
		{
			Debug.LogWarning("NaN detected in body vertical velocity offset");
			_bodyVerticalOffsetVelocity = 0f;
		}
		if (_jumpingTime > 0f || (!_playerController.PlayerCollisionHandler.IsGrounded && _landedTime < 0f))
		{
			num = ((!(_jumpingTime > 0f)) ? 0f : ((0f - Mathf.Max(0f, _playerController.Velocity.y)) * _bodyAirSwingVelocityCoefficient));
			num2 = Mathf.Clamp(0f - num, _bodySwingMinHeight, _bodySwingMaxHeight);
			_bodyVerticalOffset = Mathf.SmoothDamp(_bodyVerticalOffset, num2, ref _bodyVerticalOffsetVelocity, 0.1f);
		}
		else
		{
			if (_landedTime > 0f)
			{
				num = _playerController.Velocity.y * _bodyGroundedSwingVelocityCoefficient;
			}
			num2 = Mathf.Clamp(0f - num, _bodySwingMinHeight, _bodySwingMaxHeight);
			_bodyVerticalOffset = GTWExtensions.Spring(_bodyVerticalOffset, num2, ref _bodyVerticalOffsetVelocity, Time.deltaTime, _bodySwingDamp, _bodySwingStiffness);
		}
		Pelvis.transform.position = Pelvis.anchor.position + new Vector3(0f, _bodyVerticalOffset, 0f);
		Pelvis.transform.rotation = Pelvis.anchor.rotation;
		LeftShoulder.transform.position = LeftShoulder.anchor.position + new Vector3(0f, _bodyVerticalOffset, 0f);
		LeftShoulder.transform.rotation = LeftShoulder.anchor.rotation;
		RightShoulder.transform.position = RightShoulder.anchor.position + new Vector3(0f, _bodyVerticalOffset, 0f);
		RightShoulder.transform.rotation = RightShoulder.anchor.rotation;
	}

	private void UpdateBodyHorizontalSwing()
	{
		_bodyHorizontalOffset.x = GTWExtensions.Spring(_bodyHorizontalOffset.x, _horizontalOffsetTarget.x, ref _bodyHorizontalOffsetVelocity.x, Time.deltaTime, _bodySwingDamp, _bodySwingStiffness);
		_bodyHorizontalOffset.y = GTWExtensions.Spring(_bodyHorizontalOffset.y, _horizontalOffsetTarget.y, ref _bodyHorizontalOffsetVelocity.y, Time.deltaTime, _bodySwingDamp, _bodySwingStiffness);
		_bodyHorizontalOffset.z = GTWExtensions.Spring(_bodyHorizontalOffset.z, _horizontalOffsetTarget.z, ref _bodyHorizontalOffsetVelocity.z, Time.deltaTime, _bodySwingDamp, _bodySwingStiffness);
		_horizontalOffsetTarget = Vector3.zero;
		Pelvis.transform.position += _bodyHorizontalOffset;
		LeftShoulder.transform.position += _bodyHorizontalOffset;
		RightShoulder.transform.position += _bodyHorizontalOffset;
	}

	public void SetBodyHorizontalForce(Vector3 force, bool velocityChange = false)
	{
		_horizontalOffsetTarget = force;
		if (velocityChange)
		{
			_bodyHorizontalOffsetVelocity = force;
		}
	}

	private void PlayerController_OnResetVelocity()
	{
		_bodyVerticalOffset = 0f;
		_bodyVerticalOffsetVelocity = 0f;
		_timeGrounded = 0f;
	}

	[ContextMenu("Move effectors to anchors")]
	private void MoveEffectorsToAnchors()
	{
		_pelvisEffector.transform.position = _pelvisEffector.anchor.position;
		_pelvisEffector.transform.rotation = _pelvisEffector.anchor.rotation;
		_leftShoulderEffector.transform.position = _leftShoulderEffector.anchor.position;
		_leftShoulderEffector.transform.rotation = _leftShoulderEffector.anchor.rotation;
		_rightShoulderEffector.transform.position = _rightShoulderEffector.anchor.position;
		_rightShoulderEffector.transform.rotation = _rightShoulderEffector.anchor.rotation;
		_leftHandEffector.transform.position = _leftHandEffector.anchor.position;
		_leftHandEffector.transform.rotation = _leftHandEffector.anchor.rotation;
		_rightHandEffector.transform.position = _rightHandEffector.anchor.position;
		_rightHandEffector.transform.rotation = _rightHandEffector.anchor.rotation;
		_leftFootEffector.transform.position = _leftFootEffector.anchor.position;
		_leftFootEffector.transform.rotation = _leftFootEffector.anchor.rotation;
		_rightFootEffector.transform.position = _rightFootEffector.anchor.position;
		_rightFootEffector.transform.rotation = _rightFootEffector.anchor.rotation;
		SetDirtyIfNotPlaying();
	}

	private void SetDirtyIfNotPlaying()
	{
	}
}
