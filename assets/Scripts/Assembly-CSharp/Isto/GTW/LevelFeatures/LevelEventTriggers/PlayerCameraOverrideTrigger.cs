using System.Collections.Generic;
using Isto.GTW.Camera;
using Isto.GTW.Player;
using UnityEngine;
using Zenject;

namespace Isto.GTW.LevelFeatures.LevelEventTriggers;

[RequireComponent(typeof(BoxCollider))]
public class PlayerCameraOverrideTrigger : LevelEventTrigger
{
	[Space]
	[SerializeField]
	private PlayerCameraOverride.CameraOverride _cameraOverride;

	[Space]
	[SerializeField]
	private List<Collider> _grabColliders = new List<Collider>();

	protected PlayerController _playerController;

	private int _insideColliderCount;

	private bool _isInsideCollider;

	private bool _overrideActive;

	public PlayerCameraOverride PlayerCameraOverride => _playerController.PlayerVirtualCameraController.PlayerCameraOverride;

	private bool HasGrabColliderCondition => _grabColliders.Count > 0;

	public bool IsGrabbing => _playerController.IsGrabLinkActive;

	[Inject]
	public void Inject(PlayerController playerController)
	{
		_playerController = playerController;
	}

	private void Update()
	{
		if (HasGrabColliderCondition)
		{
			SetOverride(_isInsideCollider && GrabColliderCondition());
		}
	}

	private void OnDestroy()
	{
		PlayerCameraOverride.RemoveCameraOverride(this);
	}

	private void OnTriggerEnter(Collider other)
	{
		_insideColliderCount++;
		_isInsideCollider = _insideColliderCount > 0;
		if (!HasGrabColliderCondition)
		{
			SetOverride(_isInsideCollider);
		}
	}

	private void OnTriggerExit(Collider other)
	{
		_insideColliderCount--;
		_isInsideCollider = _insideColliderCount > 0;
		if (!HasGrabColliderCondition)
		{
			SetOverride(_isInsideCollider);
		}
	}

	private void SetOverride(bool isActive)
	{
		if (isActive != _overrideActive)
		{
			if (isActive)
			{
				_cameraOverride.source = this;
				PlayerCameraOverride.AddCameraOverride(_cameraOverride, checkForDouble: true);
			}
			else
			{
				PlayerCameraOverride.RemoveCameraOverride(this);
			}
			_overrideActive = isActive;
		}
	}

	private bool GrabColliderCondition()
	{
		if (IsGrabbing)
		{
			return _grabColliders.Contains(_playerController.GrabLinkCollider);
		}
		return false;
	}
}
