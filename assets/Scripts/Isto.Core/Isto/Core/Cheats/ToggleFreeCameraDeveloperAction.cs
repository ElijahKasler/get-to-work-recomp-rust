using Cinemachine;
using Isto.Core.Beings;
using Isto.Core.Cameras;
using UnityEngine;

namespace Isto.Core.Cheats;

[CreateAssetMenu(fileName = "New Toggle Free Camera Action", menuName = "Scriptables/Dev Mode Actions/Toggle Free Camera Action")]
public class ToggleFreeCameraDeveloperAction : CheatAction
{
	[Tooltip("Only applies to keyboard arrow movement during FreeCamera mode")]
	public float freeCameraMoveSpeed = 0.2f;

	[Tooltip("Only applies to keypad +/- zoom during FreeCamera mode")]
	public float freeCameraZoomSpeed = 100f;

	public float minCamDistance = 105f;

	public float maxCamDistance = 959f;

	[SerializeField]
	private Transform _cheatCameraPrefab;

	private AutomationPlayerController _player;

	private CameraController _camera;

	private Transform _cheatCameraRoot;

	private CinemachineVirtualCamera _virtualCamera;

	private CinemachineFramingTransposer _transposer;

	public override void Activate(params object[] args)
	{
		if (_cheatCameraPrefab == null)
		{
			throw new UnityException("The FreeCamera DevMode action needs the camera prefab assigned from the inspector.");
		}
		_player = Object.FindObjectOfType<AutomationPlayerController>();
		_camera = Object.FindObjectOfType<CameraController>();
		_cheatCameraRoot = Object.Instantiate(_cheatCameraPrefab);
		if ((bool)_cheatCameraRoot)
		{
			_virtualCamera = _cheatCameraRoot.GetComponentInChildren<CinemachineVirtualCamera>();
		}
		GameObject gameObject = GameObject.Find("Virtual Cameras");
		if ((bool)gameObject)
		{
			_cheatCameraRoot.parent = gameObject.transform;
		}
		if (!_player || !_camera || !_cheatCameraRoot || !_virtualCamera)
		{
			throw new UnityException("Can't find the required components in the scene.");
		}
		_cheatCameraRoot.transform.position = _cheatCameraRoot.transform.position + _player.transform.position;
		_camera.SwitchToCamera(_virtualCamera);
	}

	public override void Deactivate()
	{
		_camera.SetCameraFollowPlayer();
		if (_cheatCameraRoot.gameObject != null)
		{
			Object.Destroy(_cheatCameraRoot.gameObject);
			_cheatCameraRoot = null;
		}
	}

	public override void OnUpdate()
	{
		Vector3 position = _cheatCameraRoot.transform.position;
		if (Input.GetKey(KeyCode.UpArrow))
		{
			position += new Vector3(-1f, 0f, 1f) * freeCameraMoveSpeed;
		}
		if (Input.GetKey(KeyCode.DownArrow))
		{
			position += new Vector3(1f, 0f, -1f) * freeCameraMoveSpeed;
		}
		if (Input.GetKey(KeyCode.RightArrow))
		{
			position += new Vector3(1f, 0f, 1f) * freeCameraMoveSpeed;
		}
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			position += new Vector3(-1f, 0f, -1f) * freeCameraMoveSpeed;
		}
		_cheatCameraRoot.transform.SetPositionAndRotation(position, _cheatCameraRoot.transform.rotation);
		if (Input.GetKey(KeyCode.KeypadPlus))
		{
			UpdateZoom(0f - freeCameraZoomSpeed);
		}
		else if (Input.GetKey(KeyCode.KeypadMinus))
		{
			UpdateZoom(freeCameraZoomSpeed);
		}
	}

	private void UpdateZoom(float distance)
	{
		if (_transposer == null)
		{
			_transposer = _virtualCamera.GetCinemachineComponent<CinemachineFramingTransposer>();
		}
		if (_transposer != null)
		{
			_transposer.m_CameraDistance += distance * Time.deltaTime;
			_transposer.m_CameraDistance = Mathf.Clamp(_transposer.m_CameraDistance, minCamDistance, maxCamDistance);
		}
	}

	public override bool TryAutoCompleteParameters(string[] inputs, out string output)
	{
		return TryAutoCompleteBoolean(inputs, out output);
	}
}
