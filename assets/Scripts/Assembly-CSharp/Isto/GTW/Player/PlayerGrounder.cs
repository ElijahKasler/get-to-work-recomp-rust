using System;
using Isto.GTW.DebugTools;
using RootMotion.Demos;
using RootMotion.FinalIK;
using UnityEngine;

namespace Isto.GTW.Player;

[RequireComponent(typeof(PlayerIkController))]
public class PlayerGrounder : MonoBehaviour
{
	[Tooltip("How quickly the hands/feet will return to a resting position after releasing a surface.\nUsually happens when the player leaves the ground.\n- Value is in m/s (the value multiplied by the delta time)")]
	[SerializeField]
	private float _memberResetSpeed = 5f;

	[Tooltip("The radius of each members spherecast used to detect surfaces.\nNote that the sphere cast only casts straight down")]
	[SerializeField]
	private float _grounderRaycastRadius = 0.2f;

	[Tooltip("Changes how far the down the spherecast can check.\nAffects how far from the resting position the hands are allowed to move.\n\nUsed to avoid overextending or lifting too high above head.\nNote that the spherecast only casts straight down.\n- A value of 0 would not cast a ray")]
	[SerializeField]
	private float _handVerticalOffsetLimit = 0.2f;

	[Tooltip("Changes how far the down the spherecast can check.\nAffects how far from the resting position the feet are allowed to move.\n\nUsed to avoid overextending or lifting too high above head.\nNote that the spherecast only casts straight down.\n- A value of 0 would not cast a ray")]
	[SerializeField]
	private float _feetVerticalOffsetLimit = 0.2f;

	private PlayerController _playerController;

	private PlayerIkController _playerIkController;

	private float _leftHandHeight;

	private float _rightHandHeight;

	private float _leftFootHeight;

	private float _rightFootHeight;

	public PlayerIkController PlayerIkController => _playerIkController;

	public PlayerController PlayerController => _playerController;

	public PlayerCollisionHandler PlayerCollisionHandler => PlayerController.PlayerCollisionHandler;

	public PlayerModelController PlayerModelController => PlayerController.PlayerModelController;

	public bool LeftHandGrounded { get; private set; }

	public bool RightHandGrounded { get; private set; }

	public bool LeftFootGrounded { get; private set; }

	public bool RightFootGrounded { get; private set; }

	private void Awake()
	{
		_playerController = GetComponentInParent<PlayerController>();
		_playerIkController = GetComponent<PlayerIkController>();
		UpdateMembersHeight();
		IKSolverFullBodyBiped solver = PlayerIkController.FullBodyBipedIK.solver;
		solver.OnPreUpdate = (IKSolver.UpdateDelegate)Delegate.Combine(solver.OnPreUpdate, new IKSolver.UpdateDelegate(FullBodyBiped_OnPreUpdate));
	}

	private void OnDestroy()
	{
		IKSolverFullBodyBiped solver = PlayerIkController.FullBodyBipedIK.solver;
		solver.OnPreUpdate = (IKSolver.UpdateDelegate)Delegate.Remove(solver.OnPreUpdate, new IKSolver.UpdateDelegate(FullBodyBiped_OnPreUpdate));
	}

	private void FullBodyBiped_OnPreUpdate()
	{
		UpdateMembersHeight();
		UpdateGrounder();
	}

	private void UpdateMembersHeight()
	{
		Transform modelRoot = PlayerController.PlayerModelController.ModelRoot;
		Plane plane = new Plane(modelRoot.up, modelRoot.position);
		_leftHandHeight = plane.GetDistanceToPoint(PlayerIkController.LeftHand.anchor.position);
		_rightHandHeight = plane.GetDistanceToPoint(PlayerIkController.RightHand.anchor.position);
		_leftFootHeight = plane.GetDistanceToPoint(PlayerIkController.LeftFoot.anchor.position);
		_rightFootHeight = plane.GetDistanceToPoint(PlayerIkController.RightFoot.anchor.position);
	}

	public void UpdateGrounder()
	{
		LeftHandGrounded = UpdateGrounderMember(PlayerIkController.LeftHand, _leftHandHeight, _handVerticalOffsetLimit);
		RightHandGrounded = UpdateGrounderMember(PlayerIkController.RightHand, _rightHandHeight, _handVerticalOffsetLimit);
		LeftFootGrounded = UpdateGrounderMember(PlayerIkController.LeftFoot, _leftFootHeight, _feetVerticalOffsetLimit);
		RightFootGrounded = UpdateGrounderMember(PlayerIkController.RightFoot, _rightFootHeight, _feetVerticalOffsetLimit);
	}

	private bool UpdateGrounderMember(OffsetEffector offsetEffector, float memberHeight, float maxVerticalOffset)
	{
		bool flag = true;
		bool result = false;
		float grounderRaycastRadius = _grounderRaycastRadius;
		Vector3 up = PlayerModelController.transform.up;
		Vector3 position = offsetEffector.anchor.position;
		Vector3 vector = position + up * maxVerticalOffset;
		bool flag2 = false;
		flag2 = Physics.Raycast(vector, -up, out var hitInfo, maxVerticalOffset * 2f, PlayerCollisionHandler.GroundLayerMask);
		if (!flag2)
		{
			flag2 = Physics.SphereCast(vector, grounderRaycastRadius, -up, out hitInfo, maxVerticalOffset * 2f, PlayerCollisionHandler.GroundLayerMask);
		}
		if (PlayerModelController.ShowDebug)
		{
			DebugExtensions.DrawArrow(vector, vector - up * (maxVerticalOffset * 2f), Color.blue);
		}
		if (flag2 && Vector3.Magnitude(Vector3.Project(hitInfo.point - position, -up)) < maxVerticalOffset)
		{
			if (PlayerModelController.ShowDebug)
			{
				DebugExtensions.DrawLocator(hitInfo.point, Color.blue);
			}
			flag = false;
			result = true;
			Vector3 target = offsetEffector.transform.parent.InverseTransformPoint(hitInfo.point + up * memberHeight);
			offsetEffector.transform.localPosition = Vector3.MoveTowards(offsetEffector.transform.localPosition, target, Time.deltaTime * _memberResetSpeed);
		}
		if (flag)
		{
			offsetEffector.transform.position = Vector3.MoveTowards(offsetEffector.transform.position, offsetEffector.anchor.position, Time.deltaTime * _memberResetSpeed);
		}
		return result;
	}
}
