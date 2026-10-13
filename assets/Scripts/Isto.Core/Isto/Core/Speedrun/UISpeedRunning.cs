using UnityEngine;
using Zenject;

namespace Isto.Core.Speedrun;

public class UISpeedRunning : MonoBehaviour
{
	[SerializeField]
	private GameObject _speedrunTimerPrefab;

	private GameObject _speedRunTimerObject;

	private bool _initialized;

	private bool _previousSetting;

	private SpeedrunSettings _speedrunSettings;

	[Inject]
	public void Inject([InjectOptional] SpeedrunSettings speedrunSettings)
	{
		_speedrunSettings = speedrunSettings;
	}

	private void Start()
	{
		if (_previousSetting = IsSpeedrunTimerUIActive())
		{
			if (!_initialized)
			{
				InstatiateSpeedRunTimer();
			}
			_speedRunTimerObject.SetActive(value: true);
		}
	}

	private void Update()
	{
		bool flag = IsSpeedrunTimerUIActive();
		if (flag == _previousSetting)
		{
			return;
		}
		if (flag)
		{
			if (!_initialized)
			{
				InstatiateSpeedRunTimer();
			}
			_speedRunTimerObject.SetActive(value: true);
		}
		else
		{
			_speedRunTimerObject.SetActive(value: false);
		}
		_previousSetting = flag;
	}

	private bool IsSpeedrunTimerUIActive()
	{
		bool result = PlayerPrefs.GetInt(SpeedrunSettings.MENU_ACTIVE_PLAYER_PREFS_KEY, 0) == 1;
		if (_speedrunSettings == null || _speedrunSettings.CanUserToggleTimer())
		{
			return result;
		}
		if (_speedrunSettings.GetTimerConfigsCount() > 0)
		{
			return true;
		}
		return _speedrunSettings.GetDefaultTimerIsOnSetting();
	}

	private void InstatiateSpeedRunTimer()
	{
		_speedRunTimerObject = Object.Instantiate(_speedrunTimerPrefab, base.transform);
		_initialized = true;
	}
}
