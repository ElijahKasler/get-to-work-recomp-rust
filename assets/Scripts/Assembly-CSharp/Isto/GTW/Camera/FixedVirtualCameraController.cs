using Cinemachine;
using Isto.GTW.Player;
using UnityEngine;
using Zenject;

namespace Isto.GTW.Camera;

public class FixedVirtualCameraController : MonoBehaviour
{
	[SerializeField]
	private int _activatedCameraPriority = 20;

	[SerializeField]
	private float _cameraSensitivity = 0.5f;

	[SerializeField]
	private float _rotationResetTime = 1f;

	private FixedVirtualCamera _activatedFixedVirtualCamera;

	private Vector3 _currentRotation = Vector3.zero;

	private Vector3 _currentRotationVel = Vector3.zero;

	private float _autoRotateResetTimeLeft = -1f;

	protected PlayerController _playerController;

	protected CinemachineBrain _cinemachineBrain;

	private PlayerVirtualCameraController PlayerVirtualCameraController => _playerController.PlayerVirtualCameraController;

	public FixedVirtualCamera ActivatedFixedVirtualCamera => _activatedFixedVirtualCamera;

	public bool IsFixedCameraActivated => ActivatedFixedVirtualCamera != null;

	[Inject]
	private void Inject(PlayerController playerController, CinemachineBrain cinemachineBrain)
	{
		_playerController = playerController;
		_cinemachineBrain = cinemachineBrain;
	}

	private void Update()
	{
		UpdateFixedCameraRotation(_activatedFixedVirtualCamera);
	}

	private void UpdateFixedCameraRotation(FixedVirtualCamera fixedVirtualCamera)
	{
		if (!(fixedVirtualCamera == null))
		{
			_autoRotateResetTimeLeft -= Time.deltaTime;
			Vector2 cameraInput = PlayerVirtualCameraController.CameraInput;
			float num = (PlayerVirtualCameraController.UsingController ? 0.5f : 1f);
			if (PlayerVirtualCameraController.HasMouseInput)
			{
				_autoRotateResetTimeLeft = 1f;
			}
			else if (PlayerVirtualCameraController.HasControllerInput)
			{
				_autoRotateResetTimeLeft = 1f;
			}
			float num2 = _cameraSensitivity * PlayerVirtualCameraController.InputRotateSpeedMultiplier;
			_currentRotation.y += cameraInput.x * num2 * Time.deltaTime;
			_currentRotation.x += (0f - cameraInput.y) * num2 * Time.deltaTime * num;
			_currentRotation.y = Mathf.Clamp(_currentRotation.y, fixedVirtualCamera.DefaultRotation.y - fixedVirtualCamera.HorizontalLimits, fixedVirtualCamera.DefaultRotation.y + fixedVirtualCamera.HorizontalLimits);
			_currentRotation.x = Mathf.Clamp(_currentRotation.x, fixedVirtualCamera.DefaultRotation.x - fixedVirtualCamera.VerticalLimits, fixedVirtualCamera.DefaultRotation.x + fixedVirtualCamera.VerticalLimits);
			if (_autoRotateResetTimeLeft < 0f)
			{
				_currentRotation = Vector3.SmoothDamp(_currentRotation, fixedVirtualCamera.DefaultRotation, ref _currentRotationVel, _rotationResetTime, float.MaxValue, Time.deltaTime);
			}
			else
			{
				_currentRotationVel = Vector3.zero;
			}
			fixedVirtualCamera.transform.localRotation = Quaternion.Euler(_currentRotation);
		}
	}

	public void ActivateVirtualCamera(FixedVirtualCamera virtualCamera)
	{
		DeactivateVirtualCamera();
		_cinemachineBrain.m_DefaultBlend.m_Time = 0f;
		_activatedFixedVirtualCamera = virtualCamera;
		_activatedFixedVirtualCamera.ResetCameraRotation();
		_currentRotation = virtualCamera.DefaultRotation;
		virtualCamera.VirtualCamera.m_Priority = _activatedCameraPriority;
	}

	public void DeactivateVirtualCamera(FixedVirtualCamera virtualCamera)
	{
		if (!(_activatedFixedVirtualCamera != virtualCamera))
		{
			DeactivateVirtualCamera();
		}
	}

	public void DeactivateVirtualCamera()
	{
		if (!(_activatedFixedVirtualCamera == null))
		{
			_cinemachineBrain.m_DefaultBlend.m_Time = 1f;
			_activatedFixedVirtualCamera.VirtualCamera.m_Priority = 0;
			SetPlayerCamera(_activatedFixedVirtualCamera.transform.position);
			_activatedFixedVirtualCamera = null;
		}
	}

	private void SetPlayerCamera(Vector3 cameraPosition)
	{
		Vector3 vector = _playerController.PlayerVirtualCameraController.AimTarget.position - cameraPosition;
		Vector3 vector2 = new Vector3(vector.x, 0f, vector.z);
		Vector3 axis = Vector3.Cross(vector, vector2);
		float y = Vector3.SignedAngle(Vector3.forward, vector2, Vector3.up);
		float x = Vector3.SignedAngle(vector2, vector, axis);
		_playerController.PlayerVirtualCameraController.SetCameraRotation(new Vector2(x, y));
		_playerController.PlayerVirtualCameraController.SetRotationInputBlockTime(1f);
	}
}
