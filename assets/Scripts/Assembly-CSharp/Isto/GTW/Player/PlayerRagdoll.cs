using System;
using Isto.Core;
using Isto.GTW.Inputs;
using Isto.GTW.Player.States;
using Isto.GTW.Tools;
using RootMotion.Demos;
using RootMotion.FinalIK;
using UnityEngine;

namespace Isto.GTW.Player;

public class PlayerRagdoll : MonoBehaviour
{
	private struct FixedJointMember(Joint fixedJoint, OffsetEffector offsetEffector, Transform modelTransform)
	{
		public Joint fixedJoint = fixedJoint;

		public OffsetEffector offsetEffector = offsetEffector;

		public Rigidbody rigidbody = fixedJoint.GetComponent<Rigidbody>();

		public GTWExtensions.Location localLocation = new GTWExtensions.Location
		{
			Position = modelTransform.InverseTransformPoint(offsetEffector.anchor.position),
			Rotation = Quaternion.Inverse(offsetEffector.anchor.rotation) * modelTransform.rotation
		};
	}

	[SerializeField]
	private RagdollUtility _ragdollUtility;

	[Space]
	[SerializeField]
	private Rigidbody _pelvisRigidBody;

	[SerializeField]
	private Rigidbody _leftUpperLegRigidBody;

	[SerializeField]
	private Rigidbody _leftLowerLegRigidBody;

	[SerializeField]
	private Rigidbody _rightUpperLegRigidBody;

	[SerializeField]
	private Rigidbody _rightLowerLegRigidBody;

	[Space]
	[SerializeField]
	private Transform _ragdollBallTarget;

	[SerializeField]
	private Joint _leftHandFixedJoint;

	[SerializeField]
	private Joint _rightHandFixedJoint;

	[SerializeField]
	private Joint _leftFootFixedJoint;

	[SerializeField]
	private Joint _rightFootFixedJoint;

	[SerializeField]
	private Rigidbody[] _ragdollRigidbodies;

	[Space]
	[SerializeField]
	private float _ragdollMinHorizontalImpulse = 10000f;

	[SerializeField]
	private float _ragdollMinVerticalImpulse = 15000f;

	[Space]
	[SerializeField]
	private float _ragdollToAnimationTime = 0.3f;

	private PlayerIkController _playerIkController;

	private bool _isRagdollEnabled;

	private FixedJointMember _leftHandMember;

	private FixedJointMember _rightHandMember;

	private FixedJointMember _leftFootMember;

	private FixedJointMember _rightFootMember;

	private Transform _grabParent;

	public Action<Vector3, Transform> OnRagdollCollisionHit;

	private bool _ragdollPending;

	private bool _ragdollAbort;

	public RagdollUtility RagdollUtility => _ragdollUtility;

	public PlayerIkController PlayerIkController => _playerIkController;

	public PlayerController PlayerController => PlayerIkController.PlayerController;

	public PlayerModelController PlayerModelController => PlayerController.PlayerModelController;

	public bool IsRagdollEnabled => _isRagdollEnabled;

	public Rigidbody PelvisRigidBody => _pelvisRigidBody;

	public Rigidbody LeftUpperLegRigidBody => _leftUpperLegRigidBody;

	public Rigidbody LeftLowerLegRigidBody => _leftLowerLegRigidBody;

	public Rigidbody RightUpperLegRigidBody => _rightUpperLegRigidBody;

	public Rigidbody RightLowerLegRigidBody => _rightLowerLegRigidBody;

	public Transform RagdollBallTarget => _ragdollBallTarget;

	public Joint LeftHandFixedJoint => _leftHandFixedJoint;

	public Joint RightHandFixedJoint => _rightHandFixedJoint;

	public Joint LeftFootFixedJoint => _leftFootFixedJoint;

	public Joint RightFootFixedJoint => _rightFootFixedJoint;

	public Transform GrabParent => _grabParent;

	private void Awake()
	{
		_playerIkController = GetComponent<PlayerIkController>();
		_leftHandMember = new FixedJointMember(_leftHandFixedJoint, _playerIkController.LeftHand, base.transform);
		_rightHandMember = new FixedJointMember(_rightHandFixedJoint, _playerIkController.RightHand, base.transform);
		_leftFootMember = new FixedJointMember(_leftFootFixedJoint, _playerIkController.LeftFoot, base.transform);
		_rightFootMember = new FixedJointMember(_rightFootFixedJoint, _playerIkController.RightFoot, base.transform);
	}

	private void Update()
	{
		if (!_ragdollPending || !_ragdollUtility.isRagdoll)
		{
			return;
		}
		_ragdollPending = false;
		if (_ragdollAbort)
		{
			if (IsRagdollEnabled)
			{
				Debug.LogWarning("Ragdoll was cancelled during enable delay but state is clean, aborting ragdoll normally.");
				SetRagdollActive(isActive: false);
			}
			else
			{
				Debug.Log("Ragdoll was cancelled during enable delay. Now aborting ragdoll by force.");
				_ragdollUtility.DisableRagdoll();
			}
			_ragdollAbort = false;
		}
	}

	public void ActivateHandFixedJoints(Transform grabParent)
	{
		_grabParent = grabParent;
		ActivateFixedJoint(ref _leftHandMember);
		ActivateFixedJoint(ref _rightHandMember);
	}

	private void ActivateFixedJoint(ref FixedJointMember fixedJointMember)
	{
		fixedJointMember.rigidbody.transform.position = fixedJointMember.fixedJoint.connectedBody.position;
		fixedJointMember.rigidbody.transform.rotation = fixedJointMember.fixedJoint.connectedBody.rotation;
		fixedJointMember.fixedJoint.gameObject.SetActive(value: true);
		fixedJointMember.rigidbody.transform.position = fixedJointMember.offsetEffector.transform.position;
		fixedJointMember.rigidbody.transform.rotation = fixedJointMember.offsetEffector.transform.rotation;
		if (_grabParent != null)
		{
			fixedJointMember.localLocation.Position = _grabParent.InverseTransformPoint(fixedJointMember.fixedJoint.transform.position);
			fixedJointMember.localLocation.Rotation = Quaternion.Inverse(_grabParent.rotation) * fixedJointMember.rigidbody.rotation;
		}
	}

	public void DeactivateHandFixedJoints()
	{
		LeftHandFixedJoint.gameObject.SetActive(value: false);
		RightHandFixedJoint.gameObject.SetActive(value: false);
		LeftFootFixedJoint.gameObject.SetActive(value: false);
		RightFootFixedJoint.gameObject.SetActive(value: false);
	}

	public void UpdateHandFixedJoints()
	{
		if (_grabParent != null)
		{
			UpdateHandFixedJoint(_leftHandMember);
			UpdateHandFixedJoint(_rightHandMember);
			UpdateHandFixedJoint(_leftFootMember);
			UpdateHandFixedJoint(_rightFootMember);
		}
	}

	private void UpdateHandFixedJoint(FixedJointMember fixedJointMember)
	{
		if (_grabParent != null)
		{
			fixedJointMember.rigidbody.transform.position = _grabParent.TransformPoint(fixedJointMember.localLocation.Position);
			fixedJointMember.rigidbody.transform.rotation = _grabParent.rotation * fixedJointMember.localLocation.Rotation;
		}
	}

	public void SetRagdollActive(bool isActive, bool instant = false)
	{
		if (isActive && !IsRagdollEnabled)
		{
			_isRagdollEnabled = true;
			_ragdollUtility.ragdollToAnimationTime = (instant ? 0f : _ragdollToAnimationTime);
			PlayerIkController.SetSameWeightForAllEffectors(0f);
			Vector3 velocity = PlayerIkController.PlayerController.Velocity;
			Vector3 angularVelocity = PlayerIkController.PlayerController.Rigidbody.angularVelocity;
			Rigidbody[] ragdollRigidbodies = _ragdollRigidbodies;
			foreach (Rigidbody obj in ragdollRigidbodies)
			{
				obj.isKinematic = false;
				obj.linearVelocity = velocity;
				obj.angularVelocity = angularVelocity;
			}
			_ragdollAbort = false;
			if (!_ragdollPending)
			{
				_ragdollUtility.EnableRagdoll();
				_ragdollPending = true;
			}
		}
		else if (!isActive && IsRagdollEnabled)
		{
			_isRagdollEnabled = false;
			_ragdollUtility.ragdollToAnimationTime = (instant ? 0f : _ragdollToAnimationTime);
			PlayerIkController.SetSameWeightForAllEffectors(1f, _ragdollUtility.ragdollToAnimationTime);
			Transform transform = PlayerModelController.transform;
			Vector3 vector = PlayerController.PlayerPosition - transform.position;
			transform.position += vector;
			PlayerIkController.PelvisBone.transform.position -= vector;
			if (_ragdollPending)
			{
				_ragdollAbort = true;
			}
			else
			{
				_ragdollUtility.DisableRagdoll();
			}
		}
	}

	[ContextMenu("TestEnableRagdoll")]
	private void TestEnableRagdoll()
	{
		SetRagdollActive(isActive: true);
	}

	[ContextMenu("TestDisableRagdoll")]
	private void TestDisableRagdoll()
	{
		SetRagdollActive(isActive: false);
	}

	public void CollisionHit(Vector3 impulse)
	{
		float y = impulse.y;
		float magnitude = new Vector2(impulse.x, impulse.z).magnitude;
		if (!PlayerController.IsGrabLinkActive && !PlayerController.InputControls.GetButton(GTWUserActions.GRAB) && (impulse.y > _ragdollMinVerticalImpulse || magnitude > _ragdollMinHorizontalImpulse))
		{
			Debug.Log("Horizontal impact:" + magnitude + "  Vertical impact:" + y);
			if (PlayerController.IsRagdollState)
			{
				((GTWPlayerRagdollState)PlayerController.CurrentState).ResetRagdollTime();
			}
			else
			{
				PlayerController._ragdollState.AutoReset = true;
				PlayerController.ChangeToRagdollState();
			}
			Events.RaiseEvent(GTWEvents.HARD_CRASH);
		}
	}

	public void RagdollCollisionHit(Vector3 impulse, Transform bodyPart)
	{
		OnRagdollCollisionHit?.Invoke(impulse, bodyPart);
	}
}
