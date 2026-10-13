using System.Linq;
using FMOD;
using FMOD.Studio;
using FMODUnity;
using Isto.Core.Configuration;
using Isto.Core.Enums;
using UnityEngine;
using Zenject;

namespace Isto.Core.Audio;

public class Music : MonoBehaviour, IGameMusic
{
	private EventInstance _runningInstance;

	private AudioTrackReferences _audioTrackReferences;

	private Isto.Core.Configuration.Settings _settings;

	[Inject]
	public virtual void Inject(Isto.Core.Configuration.Settings settings)
	{
		_settings = settings;
	}

	private void Awake()
	{
		_audioTrackReferences = _settings.AudioReferences;
	}

	private void OnDestroy()
	{
		_runningInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
		_runningInstance.release();
	}

	public bool IsMusicPlaying()
	{
		if (!_runningInstance.isValid())
		{
			return false;
		}
		_runningInstance.getPlaybackState(out var state);
		return state == PLAYBACK_STATE.PLAYING;
	}

	private MusicTrackEnum GetRandomMusicTrack()
	{
		return Int32Enum<MusicTrackEnum>.GetByValue(Random.Range(0, _audioTrackReferences.GameMusicTracks.Length));
	}

	public void StopMusic()
	{
		if (_runningInstance.isValid())
		{
			_runningInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
		}
	}

	public void PlayMusic(MusicTrack musicTrack)
	{
		switch (musicTrack)
		{
		case MusicTrack.Title:
			PlayMusicTrackEnum(MusicTrackEnum.TITLE);
			break;
		case MusicTrack.EndGame:
			PlayMusicTrackEnum(MusicTrackEnum.END_GAME);
			break;
		case MusicTrack.Random:
			PlayRandomMusic();
			break;
		case MusicTrack.NoMusic:
			StopMusic();
			break;
		}
	}

	public void PauseMusic(bool paused)
	{
		_runningInstance.setPaused(paused);
	}

	public void PlayMusic(string musicRef)
	{
		StopMusic();
		if (RuntimeManager.StudioSystem.getEvent(musicRef, out var _) == RESULT.OK)
		{
			_runningInstance = RuntimeManager.CreateInstance(musicRef);
			_runningInstance.start();
		}
		else
		{
			UnityEngine.Debug.LogError("Unable to locate music event reference [" + musicRef + "], please check that it exists.", this);
		}
	}

	private void PlayRandomMusic()
	{
		if (_audioTrackReferences.GameMusicTracks.Length != 0)
		{
			MusicTrackEnum randomMusicTrack = GetRandomMusicTrack();
			PlayMusicTrackEnum(randomMusicTrack);
		}
	}

	private void PlayMusicTrackEnum(MusicTrackEnum musicTrack)
	{
		EventReference? eventReference = null;
		eventReference = _audioTrackReferences.GameMusicTracks.FirstOrDefault((AudioTrackReferences.MusicReference musicRef) => musicRef.musicEnum == musicTrack.Value)?.eventRef;
		if (eventReference.HasValue)
		{
			PlayEventReference(eventReference.Value);
		}
		else
		{
			UnityEngine.Debug.LogWarning("Cannot find EventReference for music track " + musicTrack.Name + ". Ensure that it has been correctlyadded to the Audio Track References scriptable object located in Default Settings.");
		}
	}

	public void PlayEventReference(EventReference musicRef)
	{
		StopMusic();
		if (RuntimeManager.StudioSystem.getEventByID(musicRef.Guid, out var _) == RESULT.OK)
		{
			_runningInstance = RuntimeManager.CreateInstance(musicRef);
			_runningInstance.start();
		}
		else
		{
			UnityEngine.Debug.LogError($"Unable to locate music event reference [{musicRef}], please check that it exists.", this);
		}
	}
}
