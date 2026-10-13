namespace Isto.Core.Audio;

public interface IGameVolume
{
	void SetMasterVolume(float volume);

	void SetMusicVolume(float volume);

	void SetSFXVolume(float volume);

	void SetDialogueVolume(float volume);

	void SetAmbientVolume(float volume);

	float GetMasterVolume();

	float GetMusicVolume();

	float GetSFXVolume();

	float GetDialogueVolume();

	float GetAmbientVolume();

	void SaveVolumeSettings();
}
