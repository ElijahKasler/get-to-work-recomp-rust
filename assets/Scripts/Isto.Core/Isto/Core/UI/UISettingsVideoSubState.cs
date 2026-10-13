using System;
using System.Collections.Generic;
using System.Linq;
using I2.Loc;
using Isto.Core.Localization;
using Isto.Core.StateMachine;
using Sirenix.Utilities;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Isto.Core.UI;

public class UISettingsVideoSubState : UISettingsBaseSubState
{
	[Header("Display Category")]
	[SerializeField]
	private UISettingsOptionCarousel _windowModeCarousel;

	[SerializeField]
	private UISettingsOptionLabel _windowModeLabel;

	[SerializeField]
	private UISettingsOptionCarousel _resolutionCarousel;

	[SerializeField]
	private UISettingsOptionLabel _resolutionLabel;

	[SerializeField]
	private UISettingsOptionCarousel _refreshRateCarousel;

	[SerializeField]
	private UISettingsOptionToggle _vSyncToggle;

	[SerializeField]
	private UISettingsOptionCarousel _qualityLevelCarousel;

	[Header("Window Mode Localization")]
	[SerializeField]
	private LocalizedString _displayModeWindowed;

	[SerializeField]
	private LocalizedString _displayModeMaximizedWindow;

	[SerializeField]
	private LocalizedString _displayModeFullScreenWindow;

	[SerializeField]
	private LocalizedString _displayModeExclusiveFullScreen;

	[Header("Measurement Units Localization")]
	[SerializeField]
	private LocalizedString _unitHertz;

	[Header("Quality Level Localization")]
	[SerializeField]
	private LocalizedString _levelLow;

	[SerializeField]
	private LocalizedString _levelMedium;

	[SerializeField]
	private LocalizedString _levelHigh;

	public static readonly string REFRESH_RATE_PLAYER_PREFS_KEY = "RefreshRateSetting";

	public static readonly string RESOLUTION_HEIGHT_PLAYER_PREFS_KEY = "ResolutionHeightSetting";

	public static readonly string RESOLUTION_WIDTH_PLAYER_PREFS_KEY = "ResolutionWidthSetting";

	public static readonly string VSYNC_PLAYER_PREFS_KEY = "VSyncSetting";

	public static readonly string QUALITY_LEVEL_PLAYER_PREFS_KEY = "QualityLevelSetting";

	private static readonly float REFRESH_RATE_COMPARISON_TOLERANCE = 0.001f;

	private static readonly bool VSYNC_DEFAULT_VALUE = true;

	private static readonly int QUALITY_LEVEL_DEFAULT_VALUE = 2;

	private List<RefreshRate> _availableRefreshRates = new List<RefreshRate>();

	private List<Resolution> _availableResolutions = new List<Resolution>();

	private FullScreenMode _incomingDisplayModeValue;

	private RefreshRate _incomingRefreshRate;

	private Resolution _incomingResolutionValue;

	private bool _incomingVSyncValue;

	private int _incomingQualityLevelValue;

	private FullScreenMode _previousDisplayModeValue;

	private RefreshRate _previousRefreshRate;

	private Resolution _previousResolutionValue;

	private bool _previousVSyncValue;

	private int _previousQualityLevelValue;

	private List<FullScreenMode> _windowModes = new List<FullScreenMode>();

	private Dictionary<FullScreenMode, LocExpression> _screenModeDictionary = new Dictionary<FullScreenMode, LocExpression>();

	private List<LocExpression> _qualityLevelOptions = new List<LocExpression>();

	protected LocTerm.Factory _locTermFactory;

	public override bool HasChanges => IsVideoSettingsChanged();

	public override Selectable FirstSelectable => DefaultSelectable;

	public override Selectable DefaultSelectable => GetDefaultSelectable();

	public override SettingsSubMenusEnum SettingsSubMenu => SettingsSubMenusEnum.Video;

	public override bool RequiresUserValidation => true;

	[Inject]
	public virtual void Inject(LocTerm.Factory locTermFactory)
	{
		_locTermFactory = locTermFactory;
		InitializeAllVideoSettings();
	}

	private void Awake()
	{
		InitializeScreenModeDictionary();
	}

	private void Start()
	{
		SetupSelectableNavigation(base.transform);
	}

	public override void Enter(MonoStateMachine controller)
	{
		base.Enter(controller);
		SetupPCDisplay();
		InitializeCarousels();
	}

	protected override void RegisterEvents()
	{
		base.RegisterEvents();
		_windowModeCarousel.OnValueChanged += WindowModeCarousel_OnValueChanged;
		_resolutionCarousel.OnValueChanged += ResolutionCarousel_OnValueChanged;
		_refreshRateCarousel.OnValueChanged += RefreshRate_OnValueChanged;
		_vSyncToggle.OnValueChanged += VSyncToggle_OnValueChanged;
		_qualityLevelCarousel.OnValueChanged += QualityLevelCarousel_OnValueChanged;
	}

	protected override void UnregisterEvents()
	{
		base.UnregisterEvents();
		_windowModeCarousel.OnValueChanged -= WindowModeCarousel_OnValueChanged;
		_resolutionCarousel.OnValueChanged -= ResolutionCarousel_OnValueChanged;
		_refreshRateCarousel.OnValueChanged -= RefreshRate_OnValueChanged;
		_vSyncToggle.OnValueChanged -= VSyncToggle_OnValueChanged;
		_qualityLevelCarousel.OnValueChanged -= QualityLevelCarousel_OnValueChanged;
	}

	protected override void ApplySettings_OnSubmit()
	{
		ApplySettingsForUserValidation();
		SetupConfirmationSubState();
	}

	private void WindowModeCarousel_OnValueChanged(LocExpression windowMode)
	{
		FullScreenMode key = _screenModeDictionary.FirstOrDefault((KeyValuePair<FullScreenMode, LocExpression> keyValuePair) => object.Equals(keyValuePair.Value, windowMode)).Key;
		_incomingDisplayModeValue = key;
		_windowModeCarousel.SetDirtyFlag(_previousDisplayModeValue != _incomingDisplayModeValue);
	}

	private void ResolutionCarousel_OnValueChanged(LocExpression resolutionLocExpression)
	{
		_incomingResolutionValue = ParseLocExpressionToResolution((MultiTermLocExpression)resolutionLocExpression);
		_resolutionCarousel.SetDirtyFlag(IsResolutionChanged());
	}

	private void RefreshRate_OnValueChanged(LocExpression refreshRateLocExpression)
	{
		_incomingRefreshRate = ParseLocExpressionToRefreshRate((MultiTermLocExpression)refreshRateLocExpression);
		_refreshRateCarousel.SetDirtyFlag(IsRefreshRateChanged());
	}

	private void VSyncToggle_OnValueChanged(bool isVsyncEnabled)
	{
		_incomingVSyncValue = isVsyncEnabled;
		_vSyncToggle.SetDirtyFlag(_previousVSyncValue != _incomingVSyncValue);
	}

	private void QualityLevelCarousel_OnValueChanged(LocExpression newQualityLevel)
	{
		_incomingQualityLevelValue = _qualityLevelOptions.IndexOf(newQualityLevel);
		_qualityLevelCarousel.SetDirtyFlag(_previousQualityLevelValue != _incomingQualityLevelValue);
	}

	protected virtual bool IsVideoSettingsChanged()
	{
		if (_previousDisplayModeValue == _incomingDisplayModeValue && !IsResolutionChanged() && !IsRefreshRateChanged() && _previousVSyncValue == _incomingVSyncValue)
		{
			return _previousQualityLevelValue != _incomingQualityLevelValue;
		}
		return true;
	}

	private void SetVSyncUI(bool isVsyncEnabled)
	{
		PlayerPrefs.SetInt(VSYNC_PLAYER_PREFS_KEY, isVsyncEnabled ? 1 : 0);
		_vSyncToggle.SetToggleValueNoNotify(isVsyncEnabled);
	}

	private void SetQualityLevel(int qualityLevel)
	{
		PlayerPrefs.SetInt(QUALITY_LEVEL_PLAYER_PREFS_KEY, qualityLevel);
		if (!_qualityLevelOptions.IsNullOrEmpty())
		{
			_qualityLevelCarousel.SetCarouselList(_qualityLevelOptions, _qualityLevelOptions[qualityLevel]);
		}
	}

	private void SetResolution(Resolution newResolution, RefreshRate newRefreshRate)
	{
		Screen.SetResolution(newResolution.width, newResolution.height, Screen.fullScreenMode, newRefreshRate);
		PlayerPrefs.SetInt(RESOLUTION_WIDTH_PLAYER_PREFS_KEY, newResolution.width);
		PlayerPrefs.SetInt(RESOLUTION_HEIGHT_PLAYER_PREFS_KEY, newResolution.height);
		PlayerPrefs.SetFloat(REFRESH_RATE_PLAYER_PREFS_KEY, (float)newRefreshRate.value);
		_resolutionCarousel.SetCarouselSelectionNoNotify(FormatResolutionToLocExpression(newResolution));
		if (!float.IsNaN((float)newRefreshRate.value))
		{
			_refreshRateCarousel.SetCarouselSelectionNoNotify(FormatRefreshRateToLocExpression(newRefreshRate));
		}
	}

	private bool IsResolutionChanged()
	{
		if (_incomingResolutionValue.width == _previousResolutionValue.width)
		{
			return _incomingResolutionValue.height != _previousResolutionValue.height;
		}
		return true;
	}

	private bool IsRefreshRateChanged()
	{
		bool result = false;
		if (Screen.fullScreenMode == FullScreenMode.ExclusiveFullScreen)
		{
			result = !_previousRefreshRate.value.Approx(_incomingRefreshRate.value, REFRESH_RATE_COMPARISON_TOLERANCE);
		}
		return result;
	}

	private void SetDisplayModeUI(FullScreenMode displayMode)
	{
		Screen.fullScreenMode = displayMode;
		_windowModeCarousel.SetCarouselSelectionNoNotify(GetWindowModeText(displayMode));
	}

	private LocExpression GetWindowModeText(FullScreenMode mode)
	{
		string param = "";
		switch (mode)
		{
		case FullScreenMode.ExclusiveFullScreen:
			param = _displayModeExclusiveFullScreen.mTerm;
			break;
		case FullScreenMode.FullScreenWindow:
			param = _displayModeFullScreenWindow.mTerm;
			break;
		case FullScreenMode.MaximizedWindow:
			param = _displayModeMaximizedWindow.mTerm;
			break;
		case FullScreenMode.Windowed:
			param = _displayModeWindowed.mTerm;
			break;
		default:
			Debug.LogError($"Cannot localize dropdown text for unexpected value of type FullScreenMode ({mode})");
			break;
		}
		return new SingleTermLocExpression(_locTermFactory.Create(LocTerm.LocalizationType.Localized, param));
	}

	private Resolution GetCurrentResolution()
	{
		return Screen.currentResolution;
	}

	private RefreshRate GetCurrentRefreshRate()
	{
		RefreshRate refreshRateRatio = GetCurrentResolution().refreshRateRatio;
		return GetRoundedRefreshRate(refreshRateRatio);
	}

	private RefreshRate GetRoundedRefreshRate(float refreshRateValue)
	{
		return new RefreshRate
		{
			numerator = (uint)Math.Round(refreshRateValue),
			denominator = 1u
		};
	}

	private RefreshRate GetRoundedRefreshRate(RefreshRate refreshRate)
	{
		return GetRoundedRefreshRate((float)refreshRate.value);
	}

	private UISettingsSelectable GetDefaultSelectable()
	{
		return _windowModeCarousel;
	}

	public override void ApplySettingsForUserValidation()
	{
		ApplyAllVideoSettings();
	}

	private void SetupPCDisplay()
	{
		_resolutionLabel.gameObject.SetActive(value: false);
		_windowModeLabel.gameObject.SetActive(value: false);
		_resolutionCarousel.gameObject.SetActive(value: true);
		_windowModeCarousel.gameObject.SetActive(value: true);
		UIUtils.SetNavigation(_windowModeCarousel, UIUtils.NavigationDirection.Down, _resolutionCarousel);
		UIUtils.SetNavigation(_resolutionCarousel, UIUtils.NavigationDirection.Up, _windowModeCarousel);
	}

	private void SetupXboxDisplay()
	{
		_resolutionLabel.gameObject.SetActive(value: true);
		_windowModeLabel.gameObject.SetActive(value: true);
		_resolutionCarousel.gameObject.SetActive(value: false);
		_windowModeCarousel.gameObject.SetActive(value: false);
		UIUtils.SetNavigation(_windowModeCarousel, UIUtils.NavigationDirection.Down, _vSyncToggle);
		UIUtils.SetNavigation(_vSyncToggle, UIUtils.NavigationDirection.Up, _windowModeCarousel);
	}

	public override void ApplySettingsChanges()
	{
		base.ApplySettingsChanges();
		UpdateSettingsValues();
		InitializeResolutionCarousel();
		InitializeRefreshRateCarousel();
		ApplyAllVideoSettings();
	}

	public override void DiscardSettingsChanges()
	{
		base.DiscardSettingsChanges();
		_previousResolutionValue.refreshRateRatio = _previousRefreshRate;
		_incomingResolutionValue = _previousResolutionValue;
		_incomingRefreshRate = _previousRefreshRate;
		_incomingDisplayModeValue = _previousDisplayModeValue;
		_incomingVSyncValue = _previousVSyncValue;
		_incomingQualityLevelValue = _previousQualityLevelValue;
		SetDisplayModeUI(_incomingDisplayModeValue);
		SetResolution(_incomingResolutionValue, _incomingRefreshRate);
		SetQualityLevel(_incomingQualityLevelValue);
		SetVSyncUI(_incomingVSyncValue);
		UpdateSettingsValues();
		DiscardRefreshRateCarousel();
		ApplyAllVideoSettings();
	}

	public override void ResetToDefaults()
	{
		_previousRefreshRate = GetCurrentRefreshRate();
		_previousResolutionValue = GetCurrentResolution();
		_previousDisplayModeValue = Screen.fullScreenMode;
		_previousVSyncValue = VSYNC_DEFAULT_VALUE;
		_previousQualityLevelValue = QUALITY_LEVEL_DEFAULT_VALUE;
		DiscardSettingsChanges();
	}

	private void SetupConfirmationSubState()
	{
		_confirmationSubState.SetTimer(10f);
		_confirmationSubState.SetCallbacks(ApplySettingsChanges, DiscardSettingsChanges);
		_confirmationSubState.SetMainText(Loc.GetString(Constants.UI_SETTINGS_MESSAGE_KEEP_SETTINGS));
		_menuController.EnterSubState(_confirmationSubState);
	}

	private void InitializeAllVideoSettings()
	{
		Debug.Log("init video settings");
		if (PlayerPrefs.HasKey(QUALITY_LEVEL_PLAYER_PREFS_KEY))
		{
			QualitySettings.SetQualityLevel(PlayerPrefs.GetInt(QUALITY_LEVEL_PLAYER_PREFS_KEY, QUALITY_LEVEL_DEFAULT_VALUE));
		}
		if (PlayerPrefs.HasKey(VSYNC_PLAYER_PREFS_KEY))
		{
			QualitySettings.vSyncCount = PlayerPrefs.GetInt(VSYNC_PLAYER_PREFS_KEY, Mathf.Min(QualitySettings.vSyncCount, 1));
		}
	}

	private void ApplyAllVideoSettings()
	{
		ApplyResolutionSettings();
		ApplyDisplayModeSettings();
		ApplyQualityLevelSettings();
		ApplyVsyncSettings();
		PlayerPrefs.Save();
	}

	private void ApplyResolutionSettings()
	{
		Resolution currentResolution = GetCurrentResolution();
		RefreshRate currentRefreshRate = GetCurrentRefreshRate();
		if (!_incomingResolutionValue.IsEquivalentTo(currentResolution) || !_incomingRefreshRate.value.Approx(currentRefreshRate.value, REFRESH_RATE_COMPARISON_TOLERANCE))
		{
			SetResolution(_incomingResolutionValue, _incomingRefreshRate);
		}
	}

	private void ApplyDisplayModeSettings()
	{
		if (_incomingDisplayModeValue != Screen.fullScreenMode)
		{
			Screen.fullScreenMode = _incomingDisplayModeValue;
		}
	}

	private void ApplyVsyncSettings()
	{
		bool flag = PlayerPrefs.GetInt(VSYNC_PLAYER_PREFS_KEY, Mathf.Min(QualitySettings.vSyncCount, 1)) == 1;
		if (_incomingVSyncValue != flag)
		{
			QualitySettings.vSyncCount = (_incomingVSyncValue ? 1 : 0);
			PlayerPrefs.SetInt(VSYNC_PLAYER_PREFS_KEY, _incomingVSyncValue ? 1 : 0);
		}
	}

	private void ApplyQualityLevelSettings()
	{
		int num = PlayerPrefs.GetInt(QUALITY_LEVEL_PLAYER_PREFS_KEY, QUALITY_LEVEL_DEFAULT_VALUE);
		if (_incomingQualityLevelValue != num)
		{
			QualitySettings.SetQualityLevel(_incomingQualityLevelValue);
			PlayerPrefs.SetInt(QUALITY_LEVEL_PLAYER_PREFS_KEY, _incomingQualityLevelValue);
		}
	}

	private void UpdateSettingsValues()
	{
		_previousResolutionValue = _incomingResolutionValue;
		_previousRefreshRate = _incomingRefreshRate;
		_previousDisplayModeValue = _incomingDisplayModeValue;
		_previousVSyncValue = _incomingVSyncValue;
		_previousQualityLevelValue = _incomingQualityLevelValue;
	}

	private void InitializeCarousels()
	{
		InitializeWindowModeCarousel();
		InitializeResolutionCarousel();
		InitializeRefreshRateCarousel();
		InitializeVsyncToggle();
		InitializeQualityLevelCarousel();
	}

	private void InitializeWindowModeCarousel()
	{
		_windowModes = new List<FullScreenMode>((FullScreenMode[])Enum.GetValues(typeof(FullScreenMode)));
		_previousDisplayModeValue = Screen.fullScreenMode;
		_incomingDisplayModeValue = _previousDisplayModeValue;
		_incomingQualityLevelValue = QualitySettings.GetQualityLevel();
		if (_windowModeLabel.gameObject.activeSelf)
		{
			_windowModeLabel.SetLabel(GetWindowModeText(_incomingDisplayModeValue));
			return;
		}
		List<LocExpression> list = new List<LocExpression>();
		foreach (FullScreenMode windowMode in _windowModes)
		{
			list.Add(GetWindowModeText(windowMode));
		}
		_windowModeCarousel.SetCarouselList(list, GetWindowModeText(_incomingDisplayModeValue));
		_windowModeCarousel.SetDirtyFlag(isDirty: false);
	}

	private void InitializeResolutionCarousel()
	{
		List<Resolution> list = Screen.resolutions.Select((Resolution resolution) => new Resolution
		{
			width = resolution.width,
			height = resolution.height
		}).Distinct().ToList();
		Resolution currentWindowResolution = new Resolution
		{
			width = Screen.width,
			height = Screen.height,
			refreshRateRatio = GetCurrentRefreshRate()
		};
		if (!list.Any((Resolution currentRes) => currentRes.width == currentWindowResolution.width && currentRes.height == currentWindowResolution.height))
		{
			list.Add(currentWindowResolution);
		}
		_availableResolutions = list.OrderBy((Resolution resolution) => resolution.height).ToList();
		_previousResolutionValue = currentWindowResolution;
		_incomingResolutionValue = _previousResolutionValue;
		MultiTermLocExpression multiTermLocExpression = FormatResolutionToLocExpression(_previousResolutionValue);
		if (_resolutionLabel.gameObject.activeSelf)
		{
			_resolutionLabel.SetLabel(multiTermLocExpression);
			return;
		}
		List<MultiTermLocExpression> list2 = new List<MultiTermLocExpression>();
		foreach (Resolution availableResolution in _availableResolutions)
		{
			list2.Add(FormatResolutionToLocExpression(availableResolution));
		}
		_resolutionCarousel.SetCarouselList(list2, multiTermLocExpression);
		_resolutionCarousel.SetDirtyFlag(isDirty: false);
	}

	private void InitializeRefreshRateCarousel()
	{
		SetupRefreshRateCarousel(GetCurrentRefreshRate());
	}

	private void DiscardRefreshRateCarousel()
	{
		RefreshRate initialRefreshRate = _incomingRefreshRate;
		if (double.IsNaN(initialRefreshRate.value))
		{
			initialRefreshRate = GetCurrentRefreshRate();
		}
		SetupRefreshRateCarousel(initialRefreshRate);
	}

	private void SetupRefreshRateCarousel(RefreshRate initialRefreshRate)
	{
		_refreshRateCarousel.gameObject.SetActive(Screen.fullScreenMode == FullScreenMode.ExclusiveFullScreen);
		if (Screen.fullScreenMode != FullScreenMode.ExclusiveFullScreen)
		{
			return;
		}
		Resolution resolution = _incomingResolutionValue;
		if (resolution.IsNullOrDestroyed())
		{
			resolution = GetCurrentResolution();
		}
		List<RefreshRate> list = new List<RefreshRate>();
		Resolution[] resolutions = Screen.resolutions;
		for (int i = 0; i < resolutions.Length; i++)
		{
			Resolution resolution2 = resolutions[i];
			if (resolution2.width == resolution.width && resolution2.height == resolution.height)
			{
				RefreshRate roundedRefreshRate = GetRoundedRefreshRate(resolution2.refreshRateRatio);
				if (!list.Contains(roundedRefreshRate))
				{
					list.Add(roundedRefreshRate);
				}
			}
		}
		if (!list.Contains(initialRefreshRate))
		{
			list.Add(initialRefreshRate);
		}
		_availableRefreshRates = list.OrderBy((RefreshRate refreshRate) => refreshRate.value).ToList();
		_previousRefreshRate = initialRefreshRate;
		_incomingRefreshRate = _previousRefreshRate;
		MultiTermLocExpression currentSelectionMultiTerm = FormatRefreshRateToLocExpression(_incomingRefreshRate);
		List<MultiTermLocExpression> list2 = new List<MultiTermLocExpression>();
		foreach (RefreshRate availableRefreshRate in _availableRefreshRates)
		{
			list2.Add(FormatRefreshRateToLocExpression(availableRefreshRate));
		}
		_refreshRateCarousel.SetCarouselList(list2, currentSelectionMultiTerm);
		_refreshRateCarousel.SetDirtyFlag(isDirty: false);
	}

	private void InitializeVsyncToggle()
	{
		bool previousVSyncValue = PlayerPrefs.GetInt(VSYNC_PLAYER_PREFS_KEY, Mathf.Min(QualitySettings.vSyncCount, 1)) == 1;
		_previousVSyncValue = previousVSyncValue;
		_incomingVSyncValue = _previousVSyncValue;
		_vSyncToggle.SetToggleValue(_incomingVSyncValue);
		_vSyncToggle.SetDirtyFlag(isDirty: false);
	}

	private void InitializeQualityLevelCarousel()
	{
		int num = PlayerPrefs.GetInt(QUALITY_LEVEL_PLAYER_PREFS_KEY, QUALITY_LEVEL_DEFAULT_VALUE);
		_qualityLevelOptions = new List<LocExpression>();
		LocTerm locTerm = _locTermFactory.Create(LocTerm.LocalizationType.Localized, _levelLow.mTerm);
		LocTerm locTerm2 = _locTermFactory.Create(LocTerm.LocalizationType.Localized, _levelMedium.mTerm);
		LocTerm locTerm3 = _locTermFactory.Create(LocTerm.LocalizationType.Localized, _levelHigh.mTerm);
		_qualityLevelOptions.Add(new SingleTermLocExpression(locTerm));
		_qualityLevelOptions.Add(new SingleTermLocExpression(locTerm2));
		_qualityLevelOptions.Add(new SingleTermLocExpression(locTerm3));
		_previousQualityLevelValue = num;
		_incomingQualityLevelValue = _previousQualityLevelValue;
		_qualityLevelCarousel.SetCarouselList(_qualityLevelOptions, _qualityLevelOptions[num]);
	}

	private MultiTermLocExpression FormatResolutionToLocExpression(Resolution resolution)
	{
		return new MultiTermLocExpression(new List<LocTerm>
		{
			_locTermFactory.Create(LocTerm.LocalizationType.NonLocalized, resolution.width.ToString()),
			_locTermFactory.Create(LocTerm.LocalizationType.NonLocalized, " x "),
			_locTermFactory.Create(LocTerm.LocalizationType.NonLocalized, resolution.height.ToString())
		});
	}

	private MultiTermLocExpression FormatRefreshRateToLocExpression(RefreshRate refreshRate)
	{
		return new MultiTermLocExpression(new List<LocTerm>
		{
			_locTermFactory.Create(LocTerm.LocalizationType.NonLocalized, refreshRate.value.ToString()),
			_locTermFactory.Create(LocTerm.LocalizationType.NonLocalized, " "),
			_locTermFactory.Create(LocTerm.LocalizationType.Localized, _unitHertz.mTerm)
		});
	}

	private Resolution ParseLocExpressionToResolution(MultiTermLocExpression resolution)
	{
		List<LocTerm> terms = resolution.GetTerms();
		int width = int.Parse(terms[0].GetKey());
		int height = int.Parse(terms[2].GetKey());
		return new Resolution
		{
			width = width,
			height = height,
			refreshRateRatio = GetCurrentRefreshRate()
		};
	}

	private RefreshRate ParseLocExpressionToRefreshRate(MultiTermLocExpression refreshRateExpression)
	{
		float refreshRateValue = float.Parse(refreshRateExpression.GetTerms()[0].GetKey());
		return GetRoundedRefreshRate(refreshRateValue);
	}

	private void InitializeScreenModeDictionary()
	{
		_screenModeDictionary = new Dictionary<FullScreenMode, LocExpression>
		{
			{
				FullScreenMode.ExclusiveFullScreen,
				GetWindowModeText(FullScreenMode.ExclusiveFullScreen)
			},
			{
				FullScreenMode.FullScreenWindow,
				GetWindowModeText(FullScreenMode.FullScreenWindow)
			},
			{
				FullScreenMode.MaximizedWindow,
				GetWindowModeText(FullScreenMode.MaximizedWindow)
			},
			{
				FullScreenMode.Windowed,
				GetWindowModeText(FullScreenMode.Windowed)
			}
		};
	}
}
