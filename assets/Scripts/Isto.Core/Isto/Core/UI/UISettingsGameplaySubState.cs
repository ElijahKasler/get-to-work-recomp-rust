using System.Collections.Generic;
using System.Linq;
using I2.Loc;
using Isto.Core.Cheats;
using Isto.Core.Configuration;
using Isto.Core.Data;
using Isto.Core.Enums;
using Isto.Core.Localization;
using Isto.Core.Speedrun;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Zenject;

namespace Isto.Core.UI;

public class UISettingsGameplaySubState : UISettingsBaseSubState
{
	[Header("Gameplay Settings")]
	[SerializeField]
	private UISettingsOptionCarousel _languageCarousel;

	[SerializeField]
	private UISettingsOptionCarousel _autoSaveFrequencyCarousel;

	[SerializeField]
	private UISettingsOptionToggle _cheatMenuToggle;

	[SerializeField]
	private UISettingsOptionToggle _speedRunToggle;

	[FormerlySerializedAs("_speedrunStyle")]
	[SerializeField]
	private UISettingsOptionCarousel _speedrunConfig;

	[SerializeField]
	private UISettingsOptionSlider _timerTopToBottomPosition;

	[SerializeField]
	private UISettingsOptionSlider _timerLeftToRightPosition;

	[Header("Auto Save Localization")]
	[SerializeField]
	private LocalizedString _settingNever;

	[SerializeField]
	private LocalizedString _minutesSuffix;

	public static readonly string CHEAT_MENU_PLAYER_PREFS_KEY = "CheatMenuSetting";

	private static readonly bool DEFAULT_CHEAT_MENU_SETTING = false;

	private static readonly int DEFAULT_SAVE_FREQUENCY = 2;

	private List<LocExpression> _currentAutoSaveOptions = new List<LocExpression>();

	private List<LocExpression> _currentLanguages = new List<LocExpression>();

	private List<LocExpression> _currentTimerConfigs = new List<LocExpression>();

	private bool _previousCheatMenuAllowed;

	private LocExpression _previousLanguage;

	private int _previousSaveFrequency;

	private bool _previousSpeedrunMenuAllowed;

	private float _previousSpeedrunVerticalPos;

	private float _previousSpeedrunHorizontalPos;

	private int _previousSpeedrunConfig;

	protected ILocalizationProvider _localization;

	private CheatSettings _cheatSettings;

	protected LanguageList _supportedLanguages;

	protected LocTerm.Factory _localizedStringFactory;

	protected Settings _settings;

	private SpeedrunSettings _speedrunSettings;

	public override bool HasChanges => IsGameplaySettingsChanged();

	public override Selectable FirstSelectable => DefaultSelectable;

	public override Selectable DefaultSelectable => _languageCarousel;

	public override SettingsSubMenusEnum SettingsSubMenu => SettingsSubMenusEnum.Gameplay;

	[Inject]
	public virtual void Inject(ILocalizationProvider localization, CheatSettings devConsole, [Inject(Id = "SupportedLanguages")] LanguageList supportedLanguages, LocTerm.Factory localizedFactory, Settings settings, [InjectOptional] SpeedrunSettings speedrunSettings)
	{
		_localization = localization;
		_cheatSettings = devConsole;
		_supportedLanguages = supportedLanguages;
		_localizedStringFactory = localizedFactory;
		_settings = settings;
		_speedrunSettings = speedrunSettings;
	}

	protected virtual void Awake()
	{
		if (_cheatMenuToggle != null && !_cheatSettings.CheatsEnabled)
		{
			_cheatMenuToggle.gameObject.SetActive(value: false);
		}
	}

	protected virtual void Start()
	{
		InitializeLanguageCarousel();
		InitializeAutoSaveFrequencyCarousel();
		InitializeCheatMenuToggle();
		InitializeSpeedRunSection();
		SetupSelectableNavigation(base.transform);
	}

	protected override void RegisterEvents()
	{
		base.RegisterEvents();
		_languageCarousel.OnValueChanged += LanguageCarousel_OnValueChanged;
		_autoSaveFrequencyCarousel.OnValueChanged += AutoSaveCarousel_OnValueChanged;
		_cheatMenuToggle.OnValueChanged += CheatMenuToggle_OnValueChanged;
		_speedRunToggle.OnValueChanged += SpeedRunToggle_OnValueChanged;
		_speedrunConfig.OnValueChanged += SpeedRunCarousel_OnValueChanged;
		_timerTopToBottomPosition.OnValueChangedPercentage += TimerVerticalPosSlider_OnValueChanged;
		_timerLeftToRightPosition.OnValueChangedPercentage += TimerHorizontalPosSlider_OnValueChanged;
	}

	protected override void UnregisterEvents()
	{
		base.UnregisterEvents();
		_languageCarousel.OnValueChanged -= LanguageCarousel_OnValueChanged;
		_autoSaveFrequencyCarousel.OnValueChanged -= AutoSaveCarousel_OnValueChanged;
		_cheatMenuToggle.OnValueChanged -= CheatMenuToggle_OnValueChanged;
		_speedRunToggle.OnValueChanged -= SpeedRunToggle_OnValueChanged;
		_speedrunConfig.OnValueChanged -= SpeedRunCarousel_OnValueChanged;
		_timerTopToBottomPosition.OnValueChangedPercentage -= TimerVerticalPosSlider_OnValueChanged;
		_timerLeftToRightPosition.OnValueChangedPercentage -= TimerHorizontalPosSlider_OnValueChanged;
	}

	private void LanguageCarousel_OnValueChanged(LocExpression newLanguage)
	{
		LanguageChanger.LanguageEnum language = ExpandableEnum<StringEnum<LanguageChanger.LanguageEnum>, string>.GetFromName((newLanguage as SingleTermLocExpression).GetTerm().GetKey()) as LanguageChanger.LanguageEnum;
		_localization.SetLanguage(language);
		_languageCarousel.SetDirtyFlag(!_previousLanguage.Equals(newLanguage));
	}

	private void AutoSaveCarousel_OnValueChanged(LocExpression newAutoSaveInterval)
	{
		AutoSaveManager.SetAutoSaveFrequencySetting(_currentAutoSaveOptions.IndexOf(newAutoSaveInterval));
		_autoSaveFrequencyCarousel.SetDirtyFlag(_previousSaveFrequency != AutoSaveManager.GetAutoSaveFrequencySetting());
	}

	private void CheatMenuToggle_OnValueChanged(bool isCheatMenuEnabled)
	{
		int value = (isCheatMenuEnabled ? 1 : 0);
		PlayerPrefs.SetInt(CHEAT_MENU_PLAYER_PREFS_KEY, value);
		_cheatMenuToggle.SetDirtyFlag(_previousCheatMenuAllowed != isCheatMenuEnabled);
	}

	private void SpeedRunToggle_OnValueChanged(bool isSpeedRunEnabled)
	{
		int value = (isSpeedRunEnabled ? 1 : 0);
		PlayerPrefs.SetInt(SpeedrunSettings.MENU_ACTIVE_PLAYER_PREFS_KEY, value);
		_speedRunToggle.SetDirtyFlag(_previousSpeedrunMenuAllowed != isSpeedRunEnabled);
	}

	private void SpeedRunCarousel_OnValueChanged(LocExpression value)
	{
		LocTerm term = (value as SingleTermLocExpression).GetTerm();
		int timerConfigIndex = _speedrunSettings.GetTimerConfigIndex(term.GetKey());
		if (timerConfigIndex != -1)
		{
			PlayerPrefs.SetInt(SpeedrunSettings.CONFIG_PLAYER_PREFS_KEY, timerConfigIndex);
			_speedrunConfig.SetDirtyFlag(_previousSpeedrunConfig != timerConfigIndex);
		}
	}

	private void TimerVerticalPosSlider_OnValueChanged(float pos)
	{
		PlayerPrefs.SetFloat(SpeedrunSettings.VERTICAL_POS_PLAYER_PREFS_KEY, pos);
		_timerTopToBottomPosition.SetDirtyFlag(!_previousSpeedrunVerticalPos.Approx(pos));
	}

	private void TimerHorizontalPosSlider_OnValueChanged(float pos)
	{
		PlayerPrefs.SetFloat(SpeedrunSettings.HORIZONTAL_POS_PLAYER_PREFS_KEY, pos);
		_timerLeftToRightPosition.SetDirtyFlag(!_previousSpeedrunHorizontalPos.Approx(pos));
	}

	protected virtual bool IsGameplaySettingsChanged()
	{
		bool flag = PlayerPrefs.GetInt(CHEAT_MENU_PLAYER_PREFS_KEY, 0) == 1;
		bool flag2 = PlayerPrefs.GetInt(SpeedrunSettings.MENU_ACTIVE_PLAYER_PREFS_KEY, 0) == 1;
		float b = PlayerPrefs.GetFloat(SpeedrunSettings.VERTICAL_POS_PLAYER_PREFS_KEY, 0f);
		float b2 = PlayerPrefs.GetFloat(SpeedrunSettings.HORIZONTAL_POS_PLAYER_PREFS_KEY, 0f);
		int defaultValue = _previousSpeedrunConfig;
		if (_speedrunSettings != null)
		{
			defaultValue = _speedrunSettings.GetDefaultTimerConfigIndex();
		}
		int num = PlayerPrefs.GetInt(SpeedrunSettings.CONFIG_PLAYER_PREFS_KEY, defaultValue);
		if (!(_previousLanguage.Localize() != _localization.GetCurrentLanguageName()) && _previousSaveFrequency == AutoSaveManager.GetAutoSaveFrequencySetting() && _previousCheatMenuAllowed == flag && _previousSpeedrunMenuAllowed == flag2 && _previousSpeedrunConfig == num && _previousSpeedrunVerticalPos.Approx(b))
		{
			return !_previousSpeedrunHorizontalPos.Approx(b2);
		}
		return true;
	}

	private void SetLanguage(LocExpression newLanguage)
	{
		if (!(newLanguage.Localize() == _localization.GetCurrentLanguageName()))
		{
			LanguageChanger.LanguageEnum language = ExpandableEnum<StringEnum<LanguageChanger.LanguageEnum>, string>.GetFromName(newLanguage.Localize()) as LanguageChanger.LanguageEnum;
			_localization.SetLanguage(language);
			_languageCarousel.SetCarouselSelectionNoNotify(newLanguage);
		}
	}

	private void SetSaveFrequency(int newSaveFrequency)
	{
		AutoSaveManager.SetAutoSaveFrequencySetting(newSaveFrequency);
		_autoSaveFrequencyCarousel.SetCarouselSelectionNoNotify(newSaveFrequency);
	}

	private void SetCheatMenu(bool isCheatMenuEnabled)
	{
		PlayerPrefs.SetInt(CHEAT_MENU_PLAYER_PREFS_KEY, isCheatMenuEnabled ? 1 : 0);
		_cheatMenuToggle.SetToggleValueNoNotify(isCheatMenuEnabled);
	}

	private void SetSpeedrunMenu(bool isSpeedrunTimerEnabled)
	{
		PlayerPrefs.SetInt(SpeedrunSettings.MENU_ACTIVE_PLAYER_PREFS_KEY, isSpeedrunTimerEnabled ? 1 : 0);
		_speedRunToggle.SetToggleValueNoNotify(isSpeedrunTimerEnabled);
	}

	private void SetSpeedrunUIStyle(int speedrunStyle)
	{
		PlayerPrefs.SetInt(SpeedrunSettings.CONFIG_PLAYER_PREFS_KEY, speedrunStyle);
		_speedrunConfig.SetCarouselSelectionNoNotify(speedrunStyle);
	}

	private void SetSpeedrunUIPositionVertical(float pos)
	{
		PlayerPrefs.SetFloat(SpeedrunSettings.VERTICAL_POS_PLAYER_PREFS_KEY, pos);
		_timerTopToBottomPosition.SetSliderAmountPercentage(pos);
	}

	private void SetSpeedrunUIPositionHorizontal(float pos)
	{
		PlayerPrefs.SetFloat(SpeedrunSettings.HORIZONTAL_POS_PLAYER_PREFS_KEY, pos);
		_timerLeftToRightPosition.SetSliderAmountPercentage(pos);
	}

	public override void ResetToDefaults()
	{
		SetSaveFrequency(DEFAULT_SAVE_FREQUENCY);
		SetCheatMenu(DEFAULT_CHEAT_MENU_SETTING);
		SetSpeedrunMenu(_speedrunSettings.GetDefaultTimerIsOnSetting());
		SetSpeedrunUIStyle(_speedrunSettings.GetDefaultTimerConfigIndex());
		SetSpeedrunUIPositionVertical(_speedrunSettings.GetDefaultScreenHeightRatio());
		SetSpeedrunUIPositionHorizontal(_speedrunSettings.GetDefaultScreenWidthRatio());
		ApplySettingsChanges();
	}

	private LocExpression ResetLanguageToSystem()
	{
		string currentDeviceLanguage = _localization.GetCurrentDeviceLanguage();
		LocExpression locExpression = new SingleTermLocExpression(_localizedStringFactory.Create(LocTerm.LocalizationType.NonLocalized, currentDeviceLanguage));
		if (!_currentLanguages.Contains(locExpression))
		{
			locExpression = _currentLanguages[0];
		}
		return locExpression;
	}

	public override void ApplySettingsChanges()
	{
		base.ApplySettingsChanges();
		LocTerm locTerm = _localizedStringFactory.Create(LocTerm.LocalizationType.NonLocalized, _localization.GetCurrentLanguageName());
		_previousLanguage = new SingleTermLocExpression(locTerm);
		_previousSaveFrequency = AutoSaveManager.GetAutoSaveFrequencySetting();
		int num = PlayerPrefs.GetInt(CHEAT_MENU_PLAYER_PREFS_KEY, -1);
		if (num != -1)
		{
			bool previousCheatMenuAllowed = num == 1;
			_previousCheatMenuAllowed = previousCheatMenuAllowed;
		}
		int num2 = PlayerPrefs.GetInt(SpeedrunSettings.MENU_ACTIVE_PLAYER_PREFS_KEY, -1);
		if (num2 != -1)
		{
			bool previousSpeedrunMenuAllowed = num2 == 1;
			_previousSpeedrunMenuAllowed = previousSpeedrunMenuAllowed;
		}
		int num3 = PlayerPrefs.GetInt(SpeedrunSettings.CONFIG_PLAYER_PREFS_KEY, -1);
		if (num3 != -1)
		{
			_previousSpeedrunConfig = num3;
		}
		float num4 = PlayerPrefs.GetFloat(SpeedrunSettings.VERTICAL_POS_PLAYER_PREFS_KEY, -1f);
		if (num4 > -0.1f)
		{
			_previousSpeedrunVerticalPos = num4;
		}
		float num5 = PlayerPrefs.GetFloat(SpeedrunSettings.HORIZONTAL_POS_PLAYER_PREFS_KEY, -1f);
		if (num5 > -0.1f)
		{
			_previousSpeedrunHorizontalPos = num5;
		}
	}

	public override void DiscardSettingsChanges()
	{
		base.DiscardSettingsChanges();
		SetLanguage(_previousLanguage);
		SetSaveFrequency(_previousSaveFrequency);
		SetCheatMenu(_previousCheatMenuAllowed);
		SetSpeedrunMenu(_previousSpeedrunMenuAllowed);
		SetSpeedrunUIStyle(_previousSpeedrunConfig);
		SetSpeedrunUIPositionVertical(_previousSpeedrunVerticalPos);
		SetSpeedrunUIPositionHorizontal(_previousSpeedrunHorizontalPos);
		ApplySettingsChanges();
	}

	private void InitializeLanguageCarousel()
	{
		_currentLanguages = new List<LocExpression>((from language in _supportedLanguages.GetLanguageNames()
			select new SingleTermLocExpression(_localizedStringFactory.Create(LocTerm.LocalizationType.NonLocalized, language))).ToList());
		LocTerm locTerm = _localizedStringFactory.Create(LocTerm.LocalizationType.NonLocalized, _localization.GetCurrentLanguageName());
		_previousLanguage = new SingleTermLocExpression(locTerm);
		_languageCarousel.SetCarouselList(_currentLanguages, _previousLanguage);
	}

	private void InitializeAutoSaveFrequencyCarousel()
	{
		_currentAutoSaveOptions = new List<LocExpression>();
		int[] autoSaveOptions = _settings.AutoSaveOptions;
		foreach (int num in autoSaveOptions)
		{
			if (num == 0)
			{
				LocTerm locTerm = _localizedStringFactory.Create(LocTerm.LocalizationType.Localized, _settingNever.mTerm);
				_currentAutoSaveOptions.Add(new SingleTermLocExpression(locTerm));
				continue;
			}
			LocTerm main = _localizedStringFactory.Create(LocTerm.LocalizationType.NonLocalized, $"{num}");
			LocTerm positionable = _localizedStringFactory.Create(LocTerm.LocalizationType.Localized, _minutesSuffix.mTerm);
			LocTerm separator = _localizedStringFactory.Create(LocTerm.LocalizationType.NonLocalized, " ");
			_currentAutoSaveOptions.Add(new RepositionableLocExpression(main, positionable, separator, LocTermAffixPositionEnum.SUFFIX));
		}
		_previousSaveFrequency = AutoSaveManager.GetAutoSaveFrequencySetting();
		_autoSaveFrequencyCarousel.SetCarouselList(_currentAutoSaveOptions, AutoSaveManager.GetAutoSaveFrequencySetting());
	}

	private void InitializeCheatMenuToggle()
	{
		bool toggleValue = (_previousCheatMenuAllowed = PlayerPrefs.GetInt(CHEAT_MENU_PLAYER_PREFS_KEY, 0) == 1);
		_cheatMenuToggle.SetToggleValue(toggleValue);
	}

	private void InitializeSpeedRunSection()
	{
		bool flag = false;
		bool flag2 = false;
		bool flag3 = false;
		if ((bool)_speedrunSettings)
		{
			flag = _speedrunSettings.CanUserToggleTimer();
			flag2 = _speedrunSettings.CanUserChangeTimerPosition();
			flag3 = _speedrunSettings.CanUserChangeTimerStyle();
		}
		_speedRunToggle.gameObject.SetActive(flag);
		PlayerPrefs.SetInt(SpeedrunSettings.MENU_ACTIVE_PLAYER_PREFS_KEY, flag ? 1 : 0);
		_previousSpeedrunMenuAllowed = flag;
		_speedRunToggle.SetToggleValue(flag);
		if (flag2)
		{
			if (!_timerTopToBottomPosition.gameObject.activeSelf)
			{
				_timerTopToBottomPosition.gameObject.SetActive(value: true);
			}
			if (!_timerLeftToRightPosition.gameObject.activeSelf)
			{
				_timerLeftToRightPosition.gameObject.SetActive(value: true);
			}
			float defaultScreenHeightRatio = _speedrunSettings.GetDefaultScreenHeightRatio();
			float defaultScreenWidthRatio = _speedrunSettings.GetDefaultScreenWidthRatio();
			defaultScreenHeightRatio = PlayerPrefs.GetFloat(SpeedrunSettings.VERTICAL_POS_PLAYER_PREFS_KEY, defaultScreenHeightRatio);
			defaultScreenWidthRatio = PlayerPrefs.GetFloat(SpeedrunSettings.HORIZONTAL_POS_PLAYER_PREFS_KEY, defaultScreenWidthRatio);
			_previousSpeedrunVerticalPos = defaultScreenHeightRatio;
			_timerTopToBottomPosition.SetSliderAmountPercentage(defaultScreenHeightRatio);
			_previousSpeedrunHorizontalPos = defaultScreenWidthRatio;
			_timerLeftToRightPosition.SetSliderAmountPercentage(defaultScreenWidthRatio);
		}
		else
		{
			if (_timerTopToBottomPosition.gameObject.activeSelf)
			{
				_timerTopToBottomPosition.gameObject.SetActive(value: false);
			}
			if (_timerLeftToRightPosition.gameObject.activeSelf)
			{
				_timerLeftToRightPosition.gameObject.SetActive(value: false);
			}
		}
		if (flag3)
		{
			if (!_speedrunConfig.gameObject.activeSelf)
			{
				_speedrunConfig.gameObject.SetActive(value: true);
			}
			int defaultTimerConfigIndex = _speedrunSettings.GetDefaultTimerConfigIndex();
			int timerConfigsCount = _speedrunSettings.GetTimerConfigsCount();
			int num = PlayerPrefs.GetInt(SpeedrunSettings.CONFIG_PLAYER_PREFS_KEY, defaultTimerConfigIndex);
			if (num < 0 || num >= timerConfigsCount)
			{
				num = defaultTimerConfigIndex;
			}
			for (int i = 0; i < _speedrunSettings.GetTimerConfigsCount(); i++)
			{
				SpeedrunSettings.SpeedrunTimerConfig timerConfig = _speedrunSettings.GetTimerConfig(i);
				LocTerm locTerm = (string.IsNullOrEmpty(timerConfig.setupNameLocKey) ? _localizedStringFactory.Create(LocTerm.LocalizationType.NonLocalized, timerConfig.internalName) : _localizedStringFactory.Create(LocTerm.LocalizationType.Localized, timerConfig.setupNameLocKey));
				LocExpression item = new SingleTermLocExpression(locTerm);
				_currentTimerConfigs.Add(item);
			}
			SpeedrunSettings.SpeedrunTimerConfig timerConfig2 = _speedrunSettings.GetTimerConfig(num);
			LocTerm locTerm2 = (string.IsNullOrEmpty(timerConfig2.setupNameLocKey) ? _localizedStringFactory.Create(LocTerm.LocalizationType.NonLocalized, timerConfig2.internalName) : _localizedStringFactory.Create(LocTerm.LocalizationType.Localized, timerConfig2.setupNameLocKey));
			_speedrunConfig.SetCarouselList(_currentTimerConfigs, new SingleTermLocExpression(locTerm2));
			_previousSpeedrunConfig = num;
			_speedrunConfig.SetCarouselSelectionNoNotify(num);
		}
		else if (_speedrunConfig.gameObject.activeSelf)
		{
			_speedrunConfig.gameObject.SetActive(value: false);
		}
	}
}
