using Isto.Core.Inputs;
using UnityEngine;
using Zenject;

namespace Isto.GTW.Player;

public class TorquePlayerDebugHud : MonoBehaviour
{
	[SerializeField]
	private bool _showDebugHud = true;

	[SerializeField]
	private Color _hudColor = Color.green;

	private PlayerController _playerController;

	private GUIStyle _guiStyle = new GUIStyle();

	private float _timeBeforeUpdate = -1f;

	private float _fpsAverage;

	private float _fpsAverageAdd;

	private int _fpsAverageFrameCount;

	protected IControls _controls;

	[Inject]
	private void Inject(IControls controls)
	{
		_controls = controls;
	}

	private void Awake()
	{
		_playerController = GetComponent<PlayerController>();
	}

	private void OnGUI()
	{
		if (_showDebugHud && _controls.GetControlMode() == Controls.Mode.Gameplay)
		{
			_guiStyle.fontSize = 20;
			_guiStyle.alignment = TextAnchor.LowerLeft;
			_guiStyle.normal.textColor = _hudColor;
			float unscaledDeltaTime = Time.unscaledDeltaTime;
			float num = 1f / unscaledDeltaTime;
			num = Mathf.Round(num * 100f) / 100f;
			_fpsAverageAdd += num;
			_fpsAverageFrameCount++;
			if (_timeBeforeUpdate <= 0f)
			{
				_fpsAverage = _fpsAverageAdd / (float)_fpsAverageFrameCount;
				_fpsAverage = Mathf.Round(_fpsAverage * 100f) / 100f;
				_timeBeforeUpdate = 1f;
				_fpsAverageAdd = 0f;
				_fpsAverageFrameCount = 0;
			}
			_timeBeforeUpdate -= Time.unscaledDeltaTime;
			Vector3 playerPosition = _playerController.PlayerPosition;
			_ = _playerController.DirectionFlat;
			_ = _playerController.CurrentSpeed;
			_ = _playerController.CurrentBallSurfaceSpeedKPH;
			Mathf.Abs(_playerController.CurrentBallSurfaceSpeed - _playerController.Rigidbody.linearVelocity.magnitude);
			_ = _playerController.CurrentSpeedKPH;
			_ = _playerController.VelocityAccelerationSpeed;
			_ = _playerController.TorquePhysics.AccelerationCoefficient;
			_ = _playerController.MainBallCollider.material.dynamicFriction;
			Rect position = new Rect(10f, 10f, 100f, 60f);
			string[] obj = new string[8]
			{
				"FPS: ",
				_fpsAverage.ToString(),
				" (",
				num.ToString(),
				")\nFixedFPS: ",
				(1f / Time.fixedDeltaTime).ToString(),
				"\nPosition: ",
				null
			};
			Vector3 vector = playerPosition;
			obj[7] = vector.ToString();
			GUI.Label(position, string.Concat(obj), _guiStyle);
		}
	}
}
