using I2.Loc;
using Isto.Core;
using Isto.Core.Localization;
using TMPro;
using UnityEngine;
using Zenject;

public class ULastTimeSaved : MonoBehaviour
{
	[SerializeField]
	private TextMeshProUGUI _label;

	[SerializeField]
	private LocalizedString _lastAutoSaveLocKey;

	[SerializeField]
	private LocalizedString _secondsPrefixLocKey;

	[SerializeField]
	private LocalizedString _secondsSuffixLocKey;

	private float _lastAutoSaveTime;

	private int _secondsCountToDisplay;

	private string _autoSaveMessageLocalized;

	private string _timeUnitPrefixLocalized;

	private string _timeUnitSuffixLocalized;

	private ILocalizationProvider _locProvider;

	[Inject]
	private void Inject(ILocalizationProvider loc)
	{
		_locProvider = loc;
	}

	private void OnDestroy()
	{
		UnregisterEvents();
	}

	private void OnEnable()
	{
		UpdateLoc();
	}

	private void Start()
	{
		_lastAutoSaveTime = Time.unscaledTime;
		RegisterEvents();
	}

	private void Update()
	{
		int num = Mathf.FloorToInt(Time.unscaledTime - _lastAutoSaveTime);
		if (_secondsCountToDisplay != num)
		{
			_secondsCountToDisplay = num;
			UpdateLabel();
		}
	}

	private void RegisterEvents()
	{
		Events.Subscribe("GameAutoSaving", Events_OnAutoSave);
		LocalizationManager.OnLocalizeEvent += LocalizationManager_OnLocalizeEvent;
	}

	private void UnregisterEvents()
	{
		Events.UnSubscribe("GameAutoSaving", Events_OnAutoSave);
		LocalizationManager.OnLocalizeEvent -= LocalizationManager_OnLocalizeEvent;
	}

	private void Events_OnAutoSave()
	{
		_lastAutoSaveTime = Time.unscaledTime;
	}

	private void LocalizationManager_OnLocalizeEvent()
	{
		UpdateLoc();
	}

	private void UpdateLoc()
	{
		_autoSaveMessageLocalized = _locProvider.GetLocalizedText(_lastAutoSaveLocKey.mTerm);
		_timeUnitPrefixLocalized = _locProvider.GetLocalizedText(_secondsPrefixLocKey.mTerm);
		_timeUnitSuffixLocalized = _locProvider.GetLocalizedText(_secondsSuffixLocKey.mTerm);
	}

	private void UpdateLabel()
	{
		_label.text = $"{_autoSaveMessageLocalized} {_timeUnitPrefixLocalized}{_secondsCountToDisplay} {_timeUnitSuffixLocalized}";
	}
}
