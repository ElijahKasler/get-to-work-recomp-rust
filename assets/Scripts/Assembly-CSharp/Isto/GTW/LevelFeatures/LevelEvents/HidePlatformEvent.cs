using System.Collections;
using System.Collections.Generic;
using FMODUnity;
using UnityEngine;
using UnityEngine.Rendering;

namespace Isto.GTW.LevelFeatures.LevelEvents;

public class HidePlatformEvent : LevelEvent
{
	private enum HidingMode
	{
		SHADOW_MODE = 0,
		DISABLE_RENDERER = 1
	}

	[SerializeField]
	private List<Renderer> _normalPlatform = new List<Renderer>();

	[SerializeField]
	private List<Renderer> _hiddenPlatform = new List<Renderer>();

	[SerializeField]
	private AnimationCurve _flickerRateCurve = AnimationCurve.Linear(0f, 0f, 1f, 1f);

	[SerializeField]
	private float _duration = 3f;

	[SerializeField]
	private float _slowFlickerInterval = 0.4f;

	[SerializeField]
	private float _fastFlickerInterval = 0.15f;

	[SerializeField]
	private HidingMode _mode;

	[Space]
	[SerializeField]
	private EventReference _hidePlatformAudioRef;

	[SerializeField]
	private EventReference _showPlatformAudioRef;

	private bool _platformVisible = true;

	private Coroutine _hidePlatformPrecessCoroutine;

	private static HidePlatformEvent _latestHidePlatformTrigger;

	public float Duration => Mathf.Max(0.1f, _duration);

	protected override void Awake()
	{
		base.Awake();
		ResetPlatform();
	}

	protected override void Reset()
	{
		base.Reset();
		_hidePlatformAudioRef = RuntimeManager.PathToEventReference("event:/SFX/TerrainFeatures/HidePlatform");
		_showPlatformAudioRef = RuntimeManager.PathToEventReference("event:/SFX/TerrainFeatures/ShowPlatform");
	}

	public override void TriggerEvent(bool initialization = false)
	{
		HidePlatform();
	}

	public void HidePlatform()
	{
		if (_platformVisible)
		{
			_platformVisible = false;
			_hidePlatformPrecessCoroutine = StartCoroutine(HidePlatformProcess());
		}
	}

	public void ResetPlatform()
	{
		if (_hidePlatformPrecessCoroutine != null)
		{
			StopCoroutine(_hidePlatformPrecessCoroutine);
			_hidePlatformPrecessCoroutine = null;
		}
		SetPlatformEnabled(isEnabled: true);
		SetPlatformRenderer(isVisible: true);
		_platformVisible = true;
	}

	private void SetPlatformEnabled(bool isEnabled)
	{
		foreach (Renderer item in _normalPlatform)
		{
			item.gameObject.SetActive(isEnabled);
		}
		foreach (Renderer item2 in _hiddenPlatform)
		{
			item2.gameObject.SetActive(isEnabled);
		}
	}

	private void SetPlatformRenderer(bool isVisible)
	{
		foreach (Renderer item in _normalPlatform)
		{
			if (_mode == HidingMode.SHADOW_MODE)
			{
				item.shadowCastingMode = (isVisible ? ShadowCastingMode.On : ShadowCastingMode.ShadowsOnly);
			}
			else if (_mode == HidingMode.DISABLE_RENDERER)
			{
				item.enabled = isVisible;
			}
		}
		foreach (Renderer item2 in _hiddenPlatform)
		{
			item2.enabled = !isVisible;
		}
	}

	private IEnumerator HidePlatformProcess()
	{
		if (_hidePlatformPrecessCoroutine != null)
		{
			yield break;
		}
		_latestHidePlatformTrigger = this;
		float time = 0f;
		float timeSinceLastflicker = 0f;
		bool isVisible = true;
		SetPlatformEnabled(isEnabled: true);
		SetPlatformRenderer(isVisible: true);
		while (time < Duration)
		{
			float time2 = time / Duration;
			float num = Mathf.Lerp(_slowFlickerInterval, _fastFlickerInterval, _flickerRateCurve.Evaluate(time2));
			if (timeSinceLastflicker >= num)
			{
				isVisible = !isVisible;
				timeSinceLastflicker = 0f;
				SetPlatformRenderer(isVisible);
				if (_latestHidePlatformTrigger == this)
				{
					if (isVisible)
					{
						RuntimeManager.PlayOneShot(_showPlatformAudioRef);
					}
					else
					{
						RuntimeManager.PlayOneShot(_hidePlatformAudioRef);
					}
				}
			}
			time += Time.deltaTime;
			timeSinceLastflicker += Time.deltaTime;
			yield return null;
		}
		SetPlatformEnabled(isEnabled: false);
		_hidePlatformPrecessCoroutine = null;
	}
}
