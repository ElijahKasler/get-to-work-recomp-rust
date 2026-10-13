using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using FMOD;
using FMOD.Studio;
using FMODUnity;
using UnityEngine;

namespace Isto.Core.Audio;

public class GameSounds : MonoBehaviour, IGameSounds
{
	[Header("Audio References")]
	public AudioTrackReferences _audioTrackReferences;

	protected readonly Dictionary<string, EventInstance> _runningInstances = new Dictionary<string, EventInstance>();

	private EventInstance _dialogueActiveSnapshot;

	private EventInstance _menuActiveSnapshot;

	private EventInstance _pauseMenuActiveSnapshot;

	private readonly Dictionary<string, Coroutine> _runningRoutines = new Dictionary<string, Coroutine>();

	public void SetGlobalParameter(string parameter, float value, float lerpTime = 0f)
	{
		if (lerpTime == 0f)
		{
			RuntimeManager.StudioSystem.setParameterByName(parameter, value);
			return;
		}
		if (_runningRoutines.TryGetValue(parameter, out var value2))
		{
			StopCoroutine(value2);
			_runningRoutines.Remove(parameter);
		}
		_runningRoutines.Add(parameter, StartCoroutine(SetGlobalParameterCoroutine(parameter, value, lerpTime)));
	}

	public float GetGlobalParameter(string parameter)
	{
		if (RuntimeManager.StudioSystem.getParameterByName(parameter, out var value) == RESULT.OK)
		{
			return value;
		}
		UnityEngine.Debug.LogError("Unable to find global parameter " + parameter + " for FMOD.", this);
		return 0f;
	}

	public void SetSnapshot(string snapshotName)
	{
		SnapShots snapshot = (SnapShots)Enum.Parse(typeof(SnapShots), snapshotName);
		SetSnapshot(snapshot);
	}

	public void SetSnapshot(SnapShots snapShot)
	{
		switch (snapShot)
		{
		case SnapShots.Gameplay:
			_menuActiveSnapshot.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
			_dialogueActiveSnapshot.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
			_pauseMenuActiveSnapshot.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
			break;
		case SnapShots.Menu:
			_menuActiveSnapshot.start();
			break;
		case SnapShots.Dialogue:
			_menuActiveSnapshot.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
			_dialogueActiveSnapshot.start();
			break;
		case SnapShots.PauseMenu:
			_pauseMenuActiveSnapshot.start();
			break;
		}
	}

	private IEnumerator SetGlobalParameterCoroutine(string parameter, float value, float lerpTime)
	{
		float timer = 0f;
		float startValue = GetGlobalParameter(parameter);
		while (timer < lerpTime)
		{
			timer += Time.deltaTime;
			float value2 = Mathf.Lerp(startValue, value, timer / lerpTime);
			RuntimeManager.StudioSystem.setParameterByName(parameter, value2);
			yield return null;
		}
		RuntimeManager.StudioSystem.setParameterByName(parameter, value);
	}

	public void PlayOneShot(string eventRef, Vector3 position)
	{
		if (!string.IsNullOrEmpty(eventRef))
		{
			RuntimeManager.PlayOneShot(eventRef, position);
		}
	}

	public void PlayOneShot(SoundEventEnum soundEvent, Vector3 position)
	{
		EventReference? eventReference = null;
		if (!(soundEvent is SettingsSoundEnum))
		{
			if (!(soundEvent is UISoundEnum))
			{
				if (soundEvent is GameSoundEnum)
				{
					eventReference = _audioTrackReferences.GameSounds.FirstOrDefault((AudioTrackReferences.GameSoundReference gameSoundRef) => gameSoundRef.soundEnum == soundEvent.Value)?.eventRef;
				}
				else
				{
					UnityEngine.Debug.LogWarning($"Type of {soundEvent.GetType()} is not playable. Ensure that the SoundEventEnum is " + "handled in GameSounds.cs.");
				}
			}
			else
			{
				eventReference = _audioTrackReferences.UISounds.FirstOrDefault((AudioTrackReferences.UISoundReference uiSoundRef) => uiSoundRef.soundEnum == soundEvent.Value)?.eventRef;
			}
		}
		else
		{
			eventReference = _audioTrackReferences.SettingsSounds.FirstOrDefault((AudioTrackReferences.SettingsSoundReference gameSoundRef) => gameSoundRef.soundEnum == soundEvent.Value)?.eventRef;
		}
		if (eventReference.HasValue)
		{
			PlayOneShot(eventReference.Value, position);
		}
		else
		{
			UnityEngine.Debug.LogWarning("PlayOneShot cannot find matching event data for sound " + soundEvent.Name);
		}
	}

	public void PlayLoop(string eventRef, Vector3 position, string loopEndParameter = "FadeOut")
	{
		if (!_runningInstances.ContainsKey(eventRef))
		{
			_runningInstances.Add(eventRef, RuntimeManager.CreateInstance(eventRef));
		}
		else if (_runningInstances.ContainsKey(eventRef) && !_runningInstances[eventRef].isValid())
		{
			_runningInstances[eventRef] = RuntimeManager.CreateInstance(eventRef);
		}
		else
		{
			_runningInstances[eventRef].setParameterByName(loopEndParameter, 0f);
		}
		_runningInstances[eventRef].set3DAttributes(position.To3DAttributes());
		if (_runningInstances[eventRef].getPlaybackState(out var state) == RESULT.OK && state != PLAYBACK_STATE.PLAYING)
		{
			_runningInstances[eventRef].start();
		}
	}

	public void PlayLoop(SoundEventEnum sfx, Vector3 position, string loopEndParameter = "FadeOut")
	{
	}

	public void StopLoop(string eventRef, string loopEndParameter = "FadeOut")
	{
		if (_runningInstances.ContainsKey(eventRef))
		{
			_runningInstances[eventRef].setParameterByName(loopEndParameter, 1f);
			_runningInstances[eventRef].stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
			_runningInstances[eventRef].release();
		}
	}

	public void StopLoop(SoundEventEnum sfx, string loopEndParameter = "FadeOut")
	{
	}

	private void PlayOneShot(EventReference eventRef, Vector3 position)
	{
		RuntimeManager.PlayOneShot(eventRef, position);
	}
}
