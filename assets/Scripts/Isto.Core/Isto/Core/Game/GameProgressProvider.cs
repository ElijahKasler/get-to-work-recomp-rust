using System.Collections.Generic;
using Isto.Core.Localization;
using Isto.Core.Speedrun;
using UnityEngine;
using Zenject;

namespace Isto.Core.Game;

public class GameProgressProvider : MonoBehaviour, IGameProgressProvider
{
	private LocTerm.Factory _localizedStringFactory;

	private SpeedrunSettings _speedrunSettings;

	[Inject]
	public void Inject(LocTerm.Factory localizedStringFactory, [InjectOptional] SpeedrunSettings speedrunSettings)
	{
		_localizedStringFactory = localizedStringFactory;
		_speedrunSettings = speedrunSettings;
	}

	public virtual int GetCurrentGameProgressLevel()
	{
		return 0;
	}

	public virtual int GetMaxGameProgressLevel()
	{
		return 1;
	}

	public virtual bool IsLastProgressLevel()
	{
		return GetCurrentGameProgressLevel() == GetMaxGameProgressLevel();
	}

	public virtual float GetGameSecondsElapsedInLevel(int progressLevel)
	{
		return Time.timeSinceLevelLoad;
	}

	public virtual float GetGameSecondsElapsedInCurrentProgressLevel()
	{
		return GetGameSecondsElapsedInLevel(GetCurrentGameProgressLevel());
	}

	public virtual float GetTotalGameSecondsElapsedInPlaythrough()
	{
		return Time.timeSinceLevelLoad;
	}

	public virtual string GetGameProgressLevelInternalName(int progressLevel)
	{
		return "LevelNotFound";
	}

	public virtual LocTerm GetGameProgressLevelName(int progressLevel)
	{
		if (_speedrunSettings != null)
		{
			string localizationKey = _speedrunSettings.GetLocalizationKey(progressLevel);
			if (localizationKey != null && localizationKey != null)
			{
				return _localizedStringFactory.Create(LocTerm.LocalizationType.Localized, localizationKey);
			}
		}
		return _localizedStringFactory.Create(LocTerm.LocalizationType.NonLocalized, GetGameProgressLevelInternalName(progressLevel));
	}

	public virtual void LoadLevelTimes(Dictionary<int, float> dictionary)
	{
		Debug.LogWarning("Loading Game Progress Data Not Supported!");
	}
}
