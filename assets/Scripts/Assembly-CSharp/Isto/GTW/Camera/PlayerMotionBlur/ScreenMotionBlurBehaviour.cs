using Code.Scripts.UI.Speedometer;
using Isto.GTW.Player;
using UnityEngine;
using Zenject;

namespace Isto.GTW.Camera.PlayerMotionBlur;

public class ScreenMotionBlurBehaviour : MonoBehaviour
{
	[SerializeField]
	private Material _blurMaterial;

	[SerializeField]
	private float _minSpeedToShowBlur = 60f;

	[SerializeField]
	private float _maxSpeedToShowBlur = 180f;

	private static readonly string MIN_SPEED_FOR_BLUR_SHADER_NAME = "_MinSpeedToShowBlur";

	private static readonly string MAX_SPEED_FOR_BLUR_SHADER_NAME = "_MaxSpeedToShowBlur";

	private static readonly string CURRENT_SPEED_FOR_BLUR_SHADER_NAME = "_CurrentSpeed";

	private PlayerController _playerController;

	private Speedometer _speedometer;

	[Inject]
	private void Inject(PlayerController playerController, Speedometer speedometer)
	{
		_playerController = playerController;
		_speedometer = speedometer;
	}

	private void Awake()
	{
		_blurMaterial.SetFloat(MIN_SPEED_FOR_BLUR_SHADER_NAME, _minSpeedToShowBlur);
		_blurMaterial.SetFloat(MAX_SPEED_FOR_BLUR_SHADER_NAME, _maxSpeedToShowBlur);
	}

	private void Update()
	{
		float num = (_playerController.IsGrabLinkActive ? 0f : _playerController.BodySpeedKPH);
		num *= _speedometer.SpeedMultiplier;
		_blurMaterial.SetFloat(CURRENT_SPEED_FOR_BLUR_SHADER_NAME, num);
	}

	private void OnDestroy()
	{
		_blurMaterial.SetFloat(CURRENT_SPEED_FOR_BLUR_SHADER_NAME, 0f);
	}
}
