using Isto.Core.Cameras;
using UnityEngine;
using Zenject;

namespace Isto.Core;

public class ScreenShake : MonoBehaviour
{
	private CameraController _cameraControl;

	[Inject]
	public void Inject(CameraController controller)
	{
		_cameraControl = controller;
	}

	public void Shake(CameraController.CameraShakeTriggers shakeTrigger)
	{
		_cameraControl.AnimateCameraShake(shakeTrigger);
	}

	public void Shake(CameraController.CameraShakeTriggers shakeTrigger, float duration)
	{
		_cameraControl.AnimateCameraShake(shakeTrigger, duration);
	}

	public void ShakeVeryLight()
	{
		Shake(CameraController.CameraShakeTriggers.shakeVeryLight);
	}

	public void ShakeLight()
	{
		Shake(CameraController.CameraShakeTriggers.shakeLight);
	}

	public void ShakeNormal()
	{
		Shake(CameraController.CameraShakeTriggers.shakeNormal);
	}

	public void ShakeHeavy()
	{
		Shake(CameraController.CameraShakeTriggers.shakeHeavy);
	}

	public void ShakeVeryLightLongTime()
	{
		Shake(CameraController.CameraShakeTriggers.shakeVeryLight, 1000f);
	}

	public void ShakeLightLongTime()
	{
		Shake(CameraController.CameraShakeTriggers.shakeLight, 1000f);
	}

	public void ShakeNormalLongTime()
	{
		Shake(CameraController.CameraShakeTriggers.shakeNormal, 1000f);
	}

	public void ShakeHeavyLongTime()
	{
		Shake(CameraController.CameraShakeTriggers.shakeHeavy, 1000f);
	}

	public void EndShake()
	{
		_cameraControl.AnimateCameraShake(CameraController.CameraShakeTriggers.none);
		_cameraControl.EndCameraShakeInvoked();
	}
}
