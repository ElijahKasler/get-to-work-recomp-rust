using Isto.Core.Audio;
using UnityEngine;

public class AudioDummy : IGameSounds, IGameMusic
{
	public float GetGlobalParameter(string parameter)
	{
		return 0f;
	}

	public void PlayLoop(string eventRef, Vector3 position, string loopEndParameter = "FadeOut")
	{
	}

	public void PlayLoop(SoundEventEnum sfx, Vector3 position, string loopEndParameter = "FadeOut")
	{
	}

	public void PlayOneShot(string eventRef, Vector3 position)
	{
	}

	public void PlayOneShot(SoundEventEnum soundEvent, Vector3 position)
	{
	}

	public void SetGlobalParameter(string parameter, float value, float lerpTime = 0f)
	{
	}

	public void SetSnapshot(string shapshotName)
	{
	}

	public void StopLoop(string eventRef, string loopEndParameter = "FadeOut")
	{
	}

	public void StopLoop(SoundEventEnum sfx, string loopEndParameter = "FadeOut")
	{
	}

	public void PlayMusic(string musicRef)
	{
	}

	public void PlayMusic(MusicTrack musicTrack)
	{
	}

	public void PauseMusic(bool paused)
	{
	}

	public void StopMusic()
	{
	}

	public void PlayRandomMusic()
	{
	}

	public bool IsMusicPlaying()
	{
		return false;
	}

	public void PlayTitleMusic()
	{
	}
}
