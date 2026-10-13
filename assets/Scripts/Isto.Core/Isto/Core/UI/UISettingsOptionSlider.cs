using System;
using Isto.Core.Audio;
using Isto.Core.Enums;
using UnityEngine;

namespace Isto.Core.UI;

public class UISettingsOptionSlider : UISettingsSelectable
{
	[Header("Settings Hookup")]
	[SerializeField]
	private UISlider _uiSlider;

	[Header("Slider Configuration")]
	[SerializeField]
	private bool _playSliderSound;

	[EnumDropdown(typeof(SettingsSoundEnum))]
	[SerializeField]
	private int _settingsSoundEnum;

	public event Action<float> OnValueChangedPercentage;

	protected override void OnEnable()
	{
		RegisterEvents();
	}

	protected override void OnDisable()
	{
		UnregisterEvents();
	}

	private void RegisterEvents()
	{
		_uiSlider.Slider.onValueChanged.AddListener(UISlider_OnValueChanged);
		_uiSlider.OnPointerUp += PlaySound;
		OnDirectionRight = (Action)Delegate.Combine(OnDirectionRight, new Action(SettingsSelectable_OnDirectionRight));
		OnDirectionLeft = (Action)Delegate.Combine(OnDirectionLeft, new Action(SettingsSelectable_OnDirectionLeft));
	}

	private void UnregisterEvents()
	{
		_uiSlider.Slider.onValueChanged.RemoveListener(UISlider_OnValueChanged);
		_uiSlider.OnPointerUp -= PlaySound;
		OnDirectionRight = (Action)Delegate.Remove(OnDirectionRight, new Action(SettingsSelectable_OnDirectionRight));
		OnDirectionLeft = (Action)Delegate.Remove(OnDirectionLeft, new Action(SettingsSelectable_OnDirectionLeft));
	}

	private void SettingsSelectable_OnDirectionRight()
	{
		ChangeSliderValue(_uiSlider.IncreaseValue);
	}

	private void SettingsSelectable_OnDirectionLeft()
	{
		ChangeSliderValue(_uiSlider.DecreaseValue);
	}

	private void UISlider_OnValueChanged(float sliderValue)
	{
		OnValueChangedPercentage?.Invoke(sliderValue / _uiSlider.Slider.maxValue);
	}

	public void SetSliderAmountPercentage(float sliderPercentage)
	{
		_uiSlider.Slider.value = sliderPercentage * _uiSlider.Slider.maxValue;
	}

	private void PlaySound()
	{
		if (_playSliderSound)
		{
			SoundEventEnum byValue = Int32Enum<SoundEventEnum>.GetByValue(_settingsSoundEnum);
			if (byValue != null)
			{
				_gameSounds.PlayOneShot(byValue, base.transform.position);
			}
			else
			{
				Debug.LogError("You are trying to play a sound for slider " + base.name + " which is currently null. Make sure that the sound is not null or disable the PlaySound boolean in the Editor.");
			}
		}
	}

	private void ChangeSliderValue(Action sliderAction)
	{
		sliderAction();
		PlaySound();
	}
}
