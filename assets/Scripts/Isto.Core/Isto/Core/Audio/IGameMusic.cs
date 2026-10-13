namespace Isto.Core.Audio;

public interface IGameMusic
{
	void PlayMusic(string musicRef);

	void PlayMusic(MusicTrack musicTrack);

	void PauseMusic(bool paused);

	void StopMusic();

	bool IsMusicPlaying();
}
