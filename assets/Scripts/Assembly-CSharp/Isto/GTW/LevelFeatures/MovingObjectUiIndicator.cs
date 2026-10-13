using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Isto.GTW.LevelFeatures;

[RequireComponent(typeof(MovingObject))]
public class MovingObjectUiIndicator : MonoBehaviour
{
	[SerializeField]
	private Image _image;

	[SerializeField]
	private int _showAtStep;

	[SerializeField]
	private float _showDuration = 1f;

	[SerializeField]
	private float _resetDelay = 0.3f;

	[SerializeField]
	private float _hideDuration = 0.1f;

	private MovingObject _movingObject;

	private Coroutine _showIndicatorCoroutine;

	public MovingObject MovingObject
	{
		get
		{
			if (_movingObject == null)
			{
				_movingObject = GetComponent<MovingObject>();
			}
			return _movingObject;
		}
	}

	private void Awake()
	{
		MovingObject movingObject = MovingObject;
		movingObject.OnMoveStep = (Action<int>)Delegate.Combine(movingObject.OnMoveStep, new Action<int>(MovingObject_OnStartMoveToNextPoint));
	}

	private void OnDestroy()
	{
		MovingObject movingObject = MovingObject;
		movingObject.OnMoveStep = (Action<int>)Delegate.Remove(movingObject.OnMoveStep, new Action<int>(MovingObject_OnStartMoveToNextPoint));
	}

	private void MovingObject_OnStartMoveToNextPoint(int step)
	{
		if (IsShowIndicatorStep(step))
		{
			_showIndicatorCoroutine = StartCoroutine(ShowIndicator());
		}
	}

	public void ResetIndicator()
	{
		_image.fillAmount = 0f;
	}

	public bool IsShowIndicatorStep(int step)
	{
		return step == _showAtStep;
	}

	public IEnumerator ShowIndicator()
	{
		if (_showIndicatorCoroutine != null)
		{
			StopCoroutine(_showIndicatorCoroutine);
			_showIndicatorCoroutine = null;
		}
		float t = 0f;
		while (t < 1f)
		{
			t = Mathf.Clamp01(t + Time.deltaTime / _showDuration);
			_image.fillAmount = t;
			yield return null;
		}
		if (Application.isPlaying)
		{
			yield return new WaitForSeconds(_resetDelay);
		}
		else
		{
			yield return new WaitForSecondsRealtime(_resetDelay);
		}
		while (t > 0f)
		{
			t = Mathf.Clamp01(t - Time.deltaTime / _hideDuration);
			_image.fillAmount = t;
			yield return null;
		}
		_showIndicatorCoroutine = null;
	}
}
