using System;
using System.Collections.Generic;
using FMOD;
using FMODUnity;
using Isto.Core.Configuration;
using UnityEngine;
using Zenject;

namespace Isto.Core.Audio;

public class FMODGameVolume : MonoBehaviour, IGameVolume
{
	private static readonly string PREFS_MASTER_KEY = "masterVolume";

	private static readonly string PREFS_MUSIC_KEY = "musicVolume";

	private static readonly string PREFS_SFX_KEY = "sfxVolume";

	private static readonly string PREFS_DIALOGUE_KEY = "dialogueVolume";

	private static readonly string PREFS_AMBIENT_KEY = "ambientVolume";

	private static readonly Dictionary<string, string> BUSES_DICT = new Dictionary<string, string>
	{
		{
			PREFS_MASTER_KEY,
			Constants.MASTER_BUS_PATH
		},
		{
			PREFS_MUSIC_KEY,
			Constants.MUSIC_BUS_PATH
		},
		{
			PREFS_SFX_KEY,
			Constants.SFX_BUS_PATH
		},
		{
			PREFS_DIALOGUE_KEY,
			Constants.DIALOGUE_BUS_PATH
		},
		{
			PREFS_AMBIENT_KEY,
			Constants.AMBIENT_BUS_PATH
		}
	};

	private Dictionary<string, float> _defaultVolumeDictionary;

	private Isto.Core.Configuration.Settings _settings;

	[Inject]
	public virtual void Inject(Isto.Core.Configuration.Settings settings)
	{
		_settings = settings;
	}

	private void Awake()
	{
		_defaultVolumeDictionary = new Dictionary<string, float>
		{
			{ PREFS_MASTER_KEY, _settings.DefaultMasterVolume },
			{ PREFS_MUSIC_KEY, _settings.DefaultMusicVolume },
			{ PREFS_SFX_KEY, _settings.DefaultSfxVolume },
			{ PREFS_DIALOGUE_KEY, _settings.DefaultDialogueVolume },
			{ PREFS_AMBIENT_KEY, _settings.DefaultAmbientVolume }
		};
	}

	private void Start()
	{
		InitializeAllVolumes();
	}

	public void SetMasterVolume(float volume)
	{
		SetVolume(PREFS_MASTER_KEY, volume);
	}

	public void SetMusicVolume(float volume)
	{
		SetVolume(PREFS_MUSIC_KEY, volume);
	}

	public void SetSFXVolume(float volume)
	{
		SetVolume(PREFS_SFX_KEY, volume);
	}

	public void SetDialogueVolume(float volume)
	{
		SetVolume(PREFS_DIALOGUE_KEY, volume);
	}

	public void SetAmbientVolume(float volume)
	{
		SetVolume(PREFS_AMBIENT_KEY, volume);
	}

	public float GetMasterVolume()
	{
		return GetVolume(PREFS_MASTER_KEY);
	}

	public float GetMusicVolume()
	{
		return GetVolume(PREFS_MUSIC_KEY);
	}

	public float GetSFXVolume()
	{
		return GetVolume(PREFS_SFX_KEY);
	}

	public float GetDialogueVolume()
	{
		return GetVolume(PREFS_DIALOGUE_KEY);
	}

	public float GetAmbientVolume()
	{
		return GetVolume(PREFS_AMBIENT_KEY);
	}

	private void SetVolume(string prefsKey, float volume)
	{
		volume = (float)Math.Round(volume, 1);
		if (RuntimeManager.GetBus(BUSES_DICT[prefsKey]).setVolume(volume) != RESULT.OK)
		{
			UnityEngine.Debug.LogError("Cannot set the volume for the FMOD bus " + BUSES_DICT[prefsKey] + ". Ensure it exists in the FMOD project.");
		}
	}

	private float GetVolume(string prefsKey)
	{
		_defaultVolumeDictionary.TryGetValue(prefsKey, out var value);
		if (RuntimeManager.GetBus(BUSES_DICT[prefsKey]).getVolume(out var volume) == RESULT.OK)
		{
			value = volume;
		}
		else
		{
			UnityEngine.Debug.LogError("Cannot read the volume for the FMOD bus " + BUSES_DICT[prefsKey] + ". Ensure it exists in the FMOD project.");
		}
		return (float)Math.Round(value, 1);
	}

	public void SaveVolumeSettings()
	{
		foreach (KeyValuePair<string, string> item in BUSES_DICT)
		{
			PlayerPrefs.SetFloat(item.Key, GetVolume(item.Key));
		}
		PlayerPrefs.Save();
	}

	private void InitializeAllVolumes()
	{
		foreach (KeyValuePair<string, string> item in BUSES_DICT)
		{
			InitializeVolume(item.Key);
		}
	}

	private void InitializeVolume(string prefsKey)
	{
		_defaultVolumeDictionary.TryGetValue(prefsKey, out var value);
		float volume = PlayerPrefs.GetFloat(prefsKey, value);
		SetVolume(prefsKey, volume);
	}
}
