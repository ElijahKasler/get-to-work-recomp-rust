using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Isto.Core.Beings;
using Isto.Core.Configuration;
using Isto.Core.Inputs;
using Isto.Core.UI;
using UnityEngine;
using UnityEngine.PostProcessing;
using Zenject;

namespace Isto.Core.Cameras;

public class CameraController : MonoBehaviour
{
	public enum CameraShakeTriggers
	{
		none = 0,
		shakeNormal = 1,
		shakeLight = 2,
		shakeVeryLight = 3,
		shakeHeavy = 4
	}

	public class CameraShakeParams
	{
		public float duration;

		public float amplitude;

		public CameraShakeParams(float duration, float amplitude)
		{
			this.duration = duration;
			this.amplitude = amplitude;
		}
	}

	[SerializeField]
	private float _defaultCameraDistance = 325f;

	[SerializeField]
	private float _minCameraZoom = 200f;

	[SerializeField]
	private float _maxCameraZoom = 500f;

	[Tooltip("How fast the camera zooms when controlled by the player")]
	[SerializeField]
	private float _playerCameraZoomSpeed = 50f;

	[SerializeField]
	private float _defaultZoomSpeed = 50f;

	[SerializeField]
	private Camera _screenCapCamera;

	[SerializeField]
	private PostProcessingBehaviour _screenCapPostProcessing;

	[SerializeField]
	private Camera _mainCamera;

	[SerializeField]
	private LayerMask _layersToHide;

	private Dictionary<CameraShakeTriggers, CameraShakeParams> _shakeParams = new Dictionary<CameraShakeTriggers, CameraShakeParams>
	{
		{
			CameraShakeTriggers.none,
			new CameraShakeParams(0f, 0f)
		},
		{
			CameraShakeTriggers.shakeNormal,
			new CameraShakeParams(0.2f, 0.5f)
		},
		{
			CameraShakeTriggers.shakeLight,
			new CameraShakeParams(0.15f, 0.25f)
		},
		{
			CameraShakeTriggers.shakeVeryLight,
			new CameraShakeParams(0.05f, 0.05f)
		},
		{
			CameraShakeTriggers.shakeHeavy,
			new CameraShakeParams(0.3f, 2f)
		}
	};

	private CinemachineVirtualCamera _followPlayerCamera;

	private IControls _controls;

	private AutomationPlayerController _player;

	private IPlayerStartPointProvider _spawnInfo;

	private CinemachineVirtualCamera _currentCamera;

	private CinemachineBasicMultiChannelPerlin _cameraNoise;

	private int _defaultCameraCullingLayers;

	private int _defaultWaterCameraCullingLayers;

	public Camera MainCamera => _mainCamera;

	public float DefaultCameraDistance => _defaultCameraDistance;

	public float MinZoomDistance => _minCameraZoom;

	public float MaxZoomDistance => _maxCameraZoom;

	public bool AreLayersHidden => _mainCamera.cullingMask != _defaultCameraCullingLayers;

	[Inject]
	public void Inject(IControls controls, [InjectOptional] IPlayerStartPointProvider startPointProvider, AutomationPlayerController player, [InjectOptional(Id = "PlayerFollowCam")] CinemachineVirtualCamera followPlayerCam)
	{
		_followPlayerCamera = followPlayerCam;
		_controls = controls;
		_player = player;
		_spawnInfo = startPointProvider;
	}

	public void SetMinMaxCameraZoom(float min, float max)
	{
		_minCameraZoom = min;
		_maxCameraZoom = max;
	}

	public void OnEnable()
	{
		GlobalGameplayEvents.MenuInteraction += OnMenuInteraction;
	}

	public void OnDisable()
	{
		GlobalGameplayEvents.MenuInteraction -= OnMenuInteraction;
	}

	protected void Awake()
	{
		_currentCamera = _followPlayerCamera;
		_defaultCameraCullingLayers = _mainCamera.cullingMask;
		HideLayers(hide: true);
	}

	protected void Update()
	{
		if (UnityUtils.IsCameraZoomSupported() && !(_followPlayerCamera == null) && _currentCamera == _followPlayerCamera)
		{
			float axis = _controls.GetAxis(Controls.MovementAxis.Zoom);
			if (axis != 0f)
			{
				CinemachineFramingTransposer cinemachineComponent = _followPlayerCamera.GetCinemachineComponent<CinemachineFramingTransposer>();
				cinemachineComponent.m_CameraDistance = Mathf.MoveTowards(target: (axis < 0f) ? _maxCameraZoom : _minCameraZoom, current: cinemachineComponent.m_CameraDistance, maxDelta: _playerCameraZoomSpeed * Time.deltaTime);
			}
		}
	}

	public void SetFollowCameraAtSpawnPoint()
	{
		_followPlayerCamera.Follow = _spawnInfo.PlayerSpawnPoint;
		_followPlayerCamera.LookAt = _spawnInfo.PlayerSpawnPoint;
		SwitchToCamera(_followPlayerCamera);
	}

	public void SetCameraFollowObject(GameObject targetObject)
	{
		_followPlayerCamera.Follow = targetObject.transform;
		_followPlayerCamera.LookAt = targetObject.transform;
		SwitchToCamera(_followPlayerCamera);
	}

	public void SetCameraFollowPlayer()
	{
		SetCameraFollowObject(_player.gameObject);
	}

	public void SetMoveToPosition(Vector3 position, float zoom, float duration = -1f)
	{
		if (duration == -1f)
		{
			_ = Constants.DEFAULT_CAMERA_MOVE_TIME;
		}
	}

	public void DoNothing()
	{
	}

	public void AnimateCameraShake(CameraShakeTriggers trig)
	{
		if (_shakeParams.ContainsKey(trig))
		{
			AnimateCameraShake(trig, _shakeParams[trig].duration);
		}
	}

	public void AnimateCameraShake(CameraShakeTriggers trig, float duration)
	{
		if (!(_cameraNoise != null) || _cameraNoise.m_AmplitudeGain == 0f)
		{
			_cameraNoise = _currentCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
			if (_cameraNoise != null && _shakeParams.ContainsKey(trig))
			{
				_cameraNoise.m_AmplitudeGain = _shakeParams[trig].amplitude;
				Invoke("EndCameraShakeInvoked", duration);
			}
			else if (_cameraNoise == null)
			{
				Debug.LogWarning("No camera noise setup on virtual camera: " + _currentCamera.name);
			}
			else
			{
				Debug.LogWarning("No shake params setup for CameraShakeTrigger." + trig);
			}
		}
	}

	public void EndCameraShakeInvoked()
	{
		if (!(_cameraNoise == null))
		{
			_cameraNoise.m_AmplitudeGain = 0f;
			_cameraNoise = null;
		}
	}

	public IEnumerator ZoomCameraCoroutine(float targetCameraDistance, float zoomTime, AnimationCurve zoomCurve)
	{
		float timer = 0f;
		CinemachineFramingTransposer transposer = _currentCamera.GetCinemachineComponent<CinemachineFramingTransposer>();
		if (transposer != null)
		{
			float startDistance = transposer.m_CameraDistance;
			while (timer < zoomTime)
			{
				timer += Time.deltaTime;
				transposer.m_CameraDistance = Mathf.Lerp(startDistance, targetCameraDistance, zoomCurve.Evaluate(timer / zoomTime));
				yield return null;
			}
		}
	}

	public void SetCameraZoomDistance(float distance)
	{
		_defaultCameraDistance = Mathf.Clamp(distance, _minCameraZoom, _maxCameraZoom);
		CinemachineFramingTransposer cinemachineComponent = _currentCamera.GetCinemachineComponent<CinemachineFramingTransposer>();
		if (cinemachineComponent != null)
		{
			float cameraDistance = Mathf.Clamp(distance, _minCameraZoom, _maxCameraZoom);
			cinemachineComponent.m_CameraDistance = cameraDistance;
		}
	}

	public Texture2D GetScreenCapture()
	{
		if (_screenCapCamera == null)
		{
			Debug.LogError("No screen capture camera setup on Camera Controller. Needed for saving thumbnail so save slots.");
			return null;
		}
		if (_screenCapPostProcessing != null)
		{
			_screenCapPostProcessing.enabled = true;
		}
		Texture2D screenCapture = _screenCapCamera.GetScreenCapture();
		if (_screenCapPostProcessing != null)
		{
			_screenCapPostProcessing.enabled = false;
		}
		return screenCapture;
	}

	public void SwitchToCamera(CinemachineVirtualCamera virtualCamera)
	{
		if (_currentCamera != null)
		{
			_currentCamera.Priority = 1;
		}
		_currentCamera = virtualCamera;
		_currentCamera.Priority = 10;
	}

	public void ResetCameraDistance()
	{
		StartCoroutine(ResetCameraZoomCoroutine());
	}

	private IEnumerator ResetCameraZoomCoroutine()
	{
		CinemachineFramingTransposer transposer = _followPlayerCamera.GetCinemachineComponent<CinemachineFramingTransposer>();
		if (transposer != null)
		{
			while (transposer.m_CameraDistance != _defaultCameraDistance)
			{
				transposer.m_CameraDistance = Mathf.MoveTowards(transposer.m_CameraDistance, _defaultCameraDistance, _defaultZoomSpeed * Time.deltaTime);
				yield return null;
			}
		}
	}

	private void OnMenuInteraction(object sender, MenuInteractionEventArgs e)
	{
		int num;
		if (!(e.menu == GameMenusEnum.CRAFTING))
		{
			num = ((e.menu == GameMenusEnum.GAME) ? 1 : 0);
			if (num == 0 && e.action == MenuInteractionEventArgs.Action.Open)
			{
				HideLayers(hide: true);
			}
		}
		else
		{
			num = 1;
		}
		if (num == 0 && e.action == MenuInteractionEventArgs.Action.Close)
		{
			HideLayers(hide: false);
		}
	}

	public void HideLayers(bool hide)
	{
		if (!hide)
		{
			_mainCamera.cullingMask = _defaultCameraCullingLayers;
		}
		else
		{
			_mainCamera.cullingMask = ~(int)_layersToHide;
		}
	}

	public void DisableMainCamera()
	{
		_mainCamera.gameObject.SetActive(value: false);
	}

	public void EnableMainCamera()
	{
		_mainCamera.gameObject.SetActive(value: true);
	}

	[ContextMenu("Get View area diagonal width")]
	public float GetScreenDiagonalSizeWorldCoord()
	{
		Vector3 viewPortPositionOnGround = UnityUtils.GetViewPortPositionOnGround(new Vector2(0f, 0f));
		Vector3 viewPortPositionOnGround2 = UnityUtils.GetViewPortPositionOnGround(new Vector2(1f, 1f));
		return Vector3.Distance(viewPortPositionOnGround, viewPortPositionOnGround2);
	}
}
