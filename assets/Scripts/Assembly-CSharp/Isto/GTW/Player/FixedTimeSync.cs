using UnityEngine;

namespace Isto.GTW.Player;

public class FixedTimeSync : MonoBehaviour
{
	[SerializeField]
	private float _fixedDeltaTime = 0.0083333f;

	[Space]
	[SerializeField]
	private bool _enableAdaptiveFixedDeltaTime = true;

	[SerializeField]
	private int _updateFrameInterval = 30;

	[SerializeField]
	private int _minFixedFrameRate = 100;

	[SerializeField]
	private int _maxFixedFrameRate = 1000;

	private float[] _deltaTimes = new float[30];

	private int _frameCount = 30;

	public static float FixedDeltaTime
	{
		get
		{
			if (Physics.simulationMode != SimulationMode.Update)
			{
				return Time.fixedDeltaTime;
			}
			return Time.deltaTime;
		}
	}

	private void Awake()
	{
		Application.targetFrameRate = (int)Screen.currentResolution.refreshRateRatio.value;
		Time.fixedDeltaTime = _fixedDeltaTime;
		if (_maxFixedFrameRate < _minFixedFrameRate * 2 + 10)
		{
			_maxFixedFrameRate = _minFixedFrameRate * 2 + 10;
		}
	}

	private void Update()
	{
		if (_enableAdaptiveFixedDeltaTime)
		{
			UpdateFixedTimeSync();
		}
	}

	private void UpdateFixedTimeSync()
	{
		if (_deltaTimes.Length != _updateFrameInterval)
		{
			_deltaTimes = new float[_updateFrameInterval];
			_frameCount = _updateFrameInterval;
		}
		if (Mathf.Approximately(Time.timeScale, 0f))
		{
			return;
		}
		_frameCount--;
		_deltaTimes[_frameCount] = Time.deltaTime;
		if (_frameCount <= 0)
		{
			float num = 0f;
			float[] deltaTimes = _deltaTimes;
			foreach (float num2 in deltaTimes)
			{
				num += num2;
			}
			num /= 30f;
			Time.fixedDeltaTime = GetFixedDeltaTime(num, 1f / (float)_maxFixedFrameRate, 1f / (float)_minFixedFrameRate);
			_frameCount = _updateFrameInterval;
		}
	}

	private float GetFixedDeltaTime(float deltaTime, float minDeltaTime, float maxDeltaTime)
	{
		if (deltaTime < minDeltaTime)
		{
			return GetFixedDeltaTime(deltaTime * 2f, minDeltaTime, maxDeltaTime);
		}
		if (deltaTime > maxDeltaTime)
		{
			return GetFixedDeltaTime(deltaTime * 0.5f, minDeltaTime, maxDeltaTime);
		}
		return deltaTime;
	}
}
