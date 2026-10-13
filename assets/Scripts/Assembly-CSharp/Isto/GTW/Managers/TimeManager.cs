using System.Collections;
using UnityEngine;
using Zenject;

namespace Isto.GTW.Managers;

public class TimeManager : MonoBehaviour
{
	[SerializeField]
	private float _slowMotionTimeScale = 0.25f;

	[SerializeField]
	private float _slowMotionChangeSpeed = 1f;

	private float _totalGameTime;

	private float _totalGameTimeUnscaled;

	private float _sessionTime;

	private bool _isSlowMotionActive;

	private Coroutine _changeTimeScaleCoroutine;

	private GTWGameState _gameState;

	public float TotalGameTime
	{
		get
		{
			return _totalGameTime;
		}
		set
		{
			_totalGameTime = value;
		}
	}

	public float TotalGameTimeUnscaled
	{
		get
		{
			return _totalGameTimeUnscaled;
		}
		set
		{
			_totalGameTimeUnscaled = value;
		}
	}

	public float SessionTime => _sessionTime;

	public bool IsSlowMotionActive => _isSlowMotionActive;

	public float SlowMotionTimeScale => _slowMotionTimeScale;

	public float SlowTimeWeight => Mathf.InverseLerp(1f, _slowMotionTimeScale, Time.timeScale);

	[Inject]
	public void Inject(GTWGameState gameState)
	{
		_gameState = gameState;
		_gameState.TimeManager = this;
	}

	private void Update()
	{
		_totalGameTime += Time.deltaTime;
		_totalGameTimeUnscaled += Time.unscaledDeltaTime;
		_sessionTime += Time.deltaTime;
	}

	private IEnumerator ChangeTimeScale(float timeScaleTarget, float changeSpeed)
	{
		if (_changeTimeScaleCoroutine != null)
		{
			StopCoroutine(_changeTimeScaleCoroutine);
			_changeTimeScaleCoroutine = null;
		}
		do
		{
			Time.timeScale = Mathf.MoveTowards(Time.timeScale, timeScaleTarget, Time.unscaledDeltaTime * changeSpeed);
			yield return null;
		}
		while (!Mathf.Approximately(Time.timeScale, timeScaleTarget));
		_changeTimeScaleCoroutine = null;
	}

	public void SetTimeScale(float timeScaleTarget, float changeSpeed = 0f)
	{
		if (changeSpeed <= 0f)
		{
			Time.timeScale = timeScaleTarget;
			if (_changeTimeScaleCoroutine != null)
			{
				StopCoroutine(_changeTimeScaleCoroutine);
				_changeTimeScaleCoroutine = null;
			}
		}
		else
		{
			_changeTimeScaleCoroutine = StartCoroutine(ChangeTimeScale(timeScaleTarget, changeSpeed));
		}
	}

	public void SetSlowMotionActive(bool isActive, bool instant = false)
	{
		if (_isSlowMotionActive != isActive || instant)
		{
			_isSlowMotionActive = isActive;
			SetTimeScale(isActive ? _slowMotionTimeScale : 1f, instant ? 0f : _slowMotionChangeSpeed);
		}
	}

	public void StopTimeScaleCoroutine()
	{
		if (_changeTimeScaleCoroutine != null)
		{
			StopCoroutine(_changeTimeScaleCoroutine);
			_changeTimeScaleCoroutine = null;
		}
	}
}
