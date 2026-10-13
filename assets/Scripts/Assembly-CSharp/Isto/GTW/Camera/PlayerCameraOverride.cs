using System;
using System.Collections.Generic;
using UnityEngine;

namespace Isto.GTW.Camera;

public class PlayerCameraOverride : MonoBehaviour
{
	[Serializable]
	public class CameraOverride
	{
		[HideInInspector]
		public UnityEngine.Object source;

		public int priority;

		[Space]
		public bool hasPositionOverride;

		public bool hasRotationOverride;

		public Transform positionRotationOverride;

		[Space]
		public bool hasAutoRotateOverride;

		public bool autoRotateOverride = true;

		[Space]
		public bool hasMinVerticalAngleOverride;

		public float minVerticalAngleOverride = -85f;

		[Space]
		public bool hasMaxVerticalAngleOverride;

		public float maxVerticalAngleOverride = 85f;

		[Space]
		public bool hasReactionSpeedOverride;

		public float reactionSpeedOverride = 500f;

		[Space]
		public bool hasMouseAutoRotateResetDelayOverride;

		public float mouseAutoRotateResetDelayOverride = 1f;

		[Space]
		public bool hasFovOverride;

		public float fovOverride = 60f;

		[Space]
		public bool hasDistanceOverride;

		public float distanceOverride = 1.5f;

		[Space]
		public bool hasAimTargetHeightOverride;

		public float aimTargetHeightOverride = 0.3f;

		[Space]
		public bool hasFollowCamHeightOverride;

		public float followCamHeightOverride = 0.5f;

		[Space]
		public bool hasTiltAngleOverride;

		public float tiltAngleOverride = 15f;

		[Space]
		public bool hasCollisionLayerOverride;

		public LayerMask collisionLayerOverride;
	}

	private List<CameraOverride> _cameraOverrides = new List<CameraOverride>();

	public CameraOverride GetOverride()
	{
		if (_cameraOverrides.Count == 0)
		{
			return null;
		}
		return _cameraOverrides[_cameraOverrides.Count - 1];
	}

	public void AddCameraOverride(CameraOverride cameraOverride, bool checkForDouble = false)
	{
		if (!checkForDouble || !_cameraOverrides.Contains(cameraOverride))
		{
			_cameraOverrides.Add(cameraOverride);
			_cameraOverrides.Sort((CameraOverride x, CameraOverride y) => x.priority.CompareTo(y.priority));
		}
	}

	public void RemoveCameraOverride(UnityEngine.Object source)
	{
		_cameraOverrides.RemoveAll((CameraOverride x) => x.source == source);
	}
}
