using Isto.Core.Audio;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Isto.Core.UI;

public class UISettingsAudioSubState : UISettingsBaseSubState
{
	[Header("Audio Settings")]
	[SerializeField]
	private UISettingsOptionSlider _masterVolumeSlider;

	[SerializeField]
	private UISettingsOptionSlider _musicVolumeSlider;

	[SerializeField]
	private UISettingsOptionSlider _sfxVolumeSlider;

	[SerializeField]
	private UISettingsOptionSlider _dialogueVolumeSlider;

	[SerializeField]
	private UISettingsOptionSlider _ambientVolumeSlider;

	[SerializeField]
	private UISettingsOptionToggle _subtitlesToggle;

	public static readonly string SUBTITLES_PLAYER_PREFS_KEY = "SubtitlesMenuSetting";

	private static readonly float DEFAULT_VOLUME = 0.8f;

	private static readonly float VOLUME_COMPARISON_TOLERANCE = 0.01f;

	private static readonly bool DEFAULT_SUBTITLE_SETTING = true;

	private float _previousMasterSliderAmount;

	private float _previousMusicSliderAmount;

	private float _previousSfxSliderAmount;

	private float _previousDialogueSliderAmount;

	private float _previousAmbientSliderAmount;

	private bool _previousSubtitlesToggleState;

	protected IGameVolume _gameVolume;

	public override bool HasChanges => IsAudioSettingsChanged();

	public override Selectable FirstSelectable => DefaultSelectable;

	public override Selectable DefaultSelectable => _masterVolumeSlider;

	public override SettingsSubMenusEnum SettingsSubMenu => SettingsSubMenusEnum.Audio;

	[Inject]
	public virtual void Inject(IGameVolume gameVolume)
	{
		_gameVolume = gameVolume;
	}

	private void Start()
	{
		InitializeMasterSlider();
		InitializeMusicSlider();
		InitializeSFXSlider();
		InitializeDialogueSlider();
		InitializeAmbientSlider();
		InitializeSubtitleToggle();
		SetupSelectableNavigation(base.transform);
	}

	protected override void OnDestroy()
	{
		base.OnDestroy();
	}

	protected override void RegisterEvents()
	{
		base.RegisterEvents();
		_masterVolumeSlider.OnValueChangedPercentage += MasterVolumeSlider_OnChangedPercentage;
		_musicVolumeSlider.OnValueChangedPercentage += MusicVolumeSlider_OnChangedPercentage;
		_sfxVolumeSlider.OnValueChangedPercentage += SfxVolumeSlider_OnChangedPercentage;
		_dialogueVolumeSlider.OnValueChangedPercentage += DialogueVolumeSlider_OnChangedPercentage;
		_ambientVolumeSlider.OnValueChangedPercentage += AmbientVolumeSlider_OnChangedPercentage;
		_subtitlesToggle.OnValueChanged += SubtitlesToggle_OnValueChanged;
		_applySettingsButton.OnSubmitEvent += ApplySettings_OnSubmit;
		_discardSettingsButton.OnSubmitEvent += base.DiscardSettings_OnSubmit;
	}

	protected override void UnregisterEvents()
	{
		base.UnregisterEvents();
		_masterVolumeSlider.OnValueChangedPercentage -= MasterVolumeSlider_OnChangedPercentage;
		_musicVolumeSlider.OnValueChangedPercentage -= MusicVolumeSlider_OnChangedPercentage;
		_sfxVolumeSlider.OnValueChangedPercentage -= SfxVolumeSlider_OnChangedPercentage;
		_dialogueVolumeSlider.OnValueChangedPercentage -= DialogueVolumeSlider_OnChangedPercentage;
		_ambientVolumeSlider.OnValueChangedPercentage -= AmbientVolumeSlider_OnChangedPercentage;
		_subtitlesToggle.OnValueChanged -= SubtitlesToggle_OnValueChanged;
		_applySettingsButton.OnSubmitEvent -= ApplySettings_OnSubmit;
		_discardSettingsButton.OnSubmitEvent -= base.DiscardSettings_OnSubmit;
	}

	public override void ResetToDefaults()
	{
		SetMasterSlider(DEFAULT_VOLUME);
		SetMusicSlider(DEFAULT_VOLUME);
		SetSfxSlider(DEFAULT_VOLUME);
		SetDialogueSlider(DEFAULT_VOLUME);
		SetAmbientSlider(DEFAULT_VOLUME);
		SetSubtitlesEnabled(DEFAULT_SUBTITLE_SETTING);
		ApplySettingsChanges();
	}

	public override void ApplySettingsChanges()
	{
		base.ApplySettingsChanges();
		_gameVolume.SaveVolumeSettings();
		_previousMasterSliderAmount = _gameVolume.GetMasterVolume();
		_previousMusicSliderAmount = _gameVolume.GetMusicVolume();
		_previousSfxSliderAmount = _gameVolume.GetSFXVolume();
		_previousDialogueSliderAmount = _gameVolume.GetDialogueVolume();
		int num = PlayerPrefs.GetInt(SUBTITLES_PLAYER_PREFS_KEY, -1);
		if (num != -1)
		{
			bool previousSubtitlesToggleState = num == 1;
			_previousSubtitlesToggleState = previousSubtitlesToggleState;
		}
	}

	public override void DiscardSettingsChanges()
	{
		base.DiscardSettingsChanges();
		SetMasterSlider(_previousMasterSliderAmount);
		SetMusicSlider(_previousMusicSliderAmount);
		SetSfxSlider(_previousSfxSliderAmount);
		SetDialogueSlider(_previousDialogueSliderAmount);
		SetAmbientSlider(_previousAmbientSliderAmount);
		SetSubtitlesEnabled(_previousSubtitlesToggleState);
		ApplySettingsChanges();
	}

	private void InitializeMasterSlider()
	{
		_previousMasterSliderAmount = _gameVolume.GetMasterVolume();
		_masterVolumeSlider.SetSliderAmountPercentage(_previousMasterSliderAmount);
	}

	private void InitializeMusicSlider()
	{
		_previousMusicSliderAmount = _gameVolume.GetMusicVolume();
		_musicVolumeSlider.SetSliderAmountPercentage(_previousMusicSliderAmount);
	}

	private void InitializeSFXSlider()
	{
		_previousSfxSliderAmount = _gameVolume.GetSFXVolume();
		_sfxVolumeSlider.SetSliderAmountPercentage(_previousSfxSliderAmount);
	}

	private void InitializeDialogueSlider()
	{
		_previousDialogueSliderAmount = _gameVolume.GetDialogueVolume();
		_dialogueVolumeSlider.SetSliderAmountPercentage(_previousDialogueSliderAmount);
	}

	private void InitializeAmbientSlider()
	{
		_previousAmbientSliderAmount = _gameVolume.GetAmbientVolume();
		_ambientVolumeSlider.SetSliderAmountPercentage(_previousAmbientSliderAmount);
	}

	private void InitializeSubtitleToggle()
	{
		bool toggleValue = (_previousSubtitlesToggleState = PlayerPrefs.GetInt(SUBTITLES_PLAYER_PREFS_KEY, 1) == 1);
		_subtitlesToggle.SetToggleValue(toggleValue);
	}

	private void SetMasterSlider(float volume)
	{
		_masterVolumeSlider.SetSliderAmountPercentage(volume);
		_gameVolume.SetMasterVolume(volume);
	}

	private void SetSfxSlider(float volume)
	{
		_sfxVolumeSlider.SetSliderAmountPercentage(volume);
		_gameVolume.SetSFXVolume(volume);
	}

	private void SetMusicSlider(float volume)
	{
		_musicVolumeSlider.SetSliderAmountPercentage(volume);
		_gameVolume.SetMusicVolume(volume);
	}

	private void SetDialogueSlider(float volume)
	{
		_dialogueVolumeSlider.SetSliderAmountPercentage(volume);
		_gameVolume.SetDialogueVolume(volume);
	}

	private void SetAmbientSlider(float volume)
	{
		_ambientVolumeSlider.SetSliderAmountPercentage(volume);
		_gameVolume.SetAmbientVolume(volume);
	}

	private void SetSubtitlesEnabled(bool isSubtitlesEnabled)
	{
		PlayerPrefs.SetInt(SUBTITLES_PLAYER_PREFS_KEY, isSubtitlesEnabled ? 1 : 0);
		_subtitlesToggle.SetToggleValueNoNotify(isSubtitlesEnabled);
	}

	private void MasterVolumeSlider_OnChangedPercentage(float updatedMasterVolume)
	{
		_gameVolume.SetMasterVolume(updatedMasterVolume);
		bool dirtyFlag = !_previousMasterSliderAmount.Approx(updatedMasterVolume, VOLUME_COMPARISON_TOLERANCE);
		_masterVolumeSlider.SetDirtyFlag(dirtyFlag);
	}

	private void MusicVolumeSlider_OnChangedPercentage(float updatedMusicVolume)
	{
		_gameVolume.SetMusicVolume(updatedMusicVolume);
		bool dirtyFlag = !_previousMusicSliderAmount.Approx(updatedMusicVolume, VOLUME_COMPARISON_TOLERANCE);
		_musicVolumeSlider.SetDirtyFlag(dirtyFlag);
	}

	private void SfxVolumeSlider_OnChangedPercentage(float updatedSFXVolume)
	{
		_gameVolume.SetSFXVolume(updatedSFXVolume);
		bool dirtyFlag = !_previousSfxSliderAmount.Approx(updatedSFXVolume, VOLUME_COMPARISON_TOLERANCE);
		_sfxVolumeSlider.SetDirtyFlag(dirtyFlag);
	}

	private void DialogueVolumeSlider_OnChangedPercentage(float updatedDialogueVolume)
	{
		_gameVolume.SetDialogueVolume(updatedDialogueVolume);
		bool dirtyFlag = !_previousDialogueSliderAmount.Approx(updatedDialogueVolume, VOLUME_COMPARISON_TOLERANCE);
		_dialogueVolumeSlider.SetDirtyFlag(dirtyFlag);
	}

	private void AmbientVolumeSlider_OnChangedPercentage(float updatedAmbientVolume)
	{
		_gameVolume.SetAmbientVolume(updatedAmbientVolume);
		bool dirtyFlag = !_previousAmbientSliderAmount.Approx(updatedAmbientVolume, VOLUME_COMPARISON_TOLERANCE);
		_ambientVolumeSlider.SetDirtyFlag(dirtyFlag);
	}

	private void SubtitlesToggle_OnValueChanged(bool isSubtitlesEnabled)
	{
		int value = (isSubtitlesEnabled ? 1 : 0);
		PlayerPrefs.SetInt(SUBTITLES_PLAYER_PREFS_KEY, value);
		_subtitlesToggle.SetDirtyFlag(_previousSubtitlesToggleState != isSubtitlesEnabled);
	}

	protected virtual bool IsAudioSettingsChanged()
	{
		float masterVolume = _gameVolume.GetMasterVolume();
		float musicVolume = _gameVolume.GetMusicVolume();
		float sFXVolume = _gameVolume.GetSFXVolume();
		float dialogueVolume = _gameVolume.GetDialogueVolume();
		float dialogueVolume2 = _gameVolume.GetDialogueVolume();
		bool flag = PlayerPrefs.GetInt(SUBTITLES_PLAYER_PREFS_KEY, 1) == 1;
		bool num = _previousMasterSliderAmount.Approx(masterVolume, VOLUME_COMPARISON_TOLERANCE);
		bool flag2 = _previousMusicSliderAmount.Approx(musicVolume, VOLUME_COMPARISON_TOLERANCE);
		bool flag3 = _previousSfxSliderAmount.Approx(sFXVolume, VOLUME_COMPARISON_TOLERANCE);
		bool flag4 = _previousDialogueSliderAmount.Approx(dialogueVolume, VOLUME_COMPARISON_TOLERANCE);
		bool flag5 = _previousAmbientSliderAmount.Approx(dialogueVolume2, VOLUME_COMPARISON_TOLERANCE);
		bool flag6 = _previousSubtitlesToggleState == flag;
		if (num && flag2 && flag3 && flag4 && flag5)
		{
			return !flag6;
		}
		return true;
	}
}
