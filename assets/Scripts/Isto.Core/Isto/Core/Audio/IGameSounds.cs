using UnityEngine;

namespace Isto.Core.Audio;

public interface IGameSounds
{
	void PlayOneShot(string eventRef, Vector3 position);

	void PlayOneShot(SoundEventEnum soundEvent, Vector3 position);

	void PlayLoop(string eventRef, Vector3 position, string loopEndParameter = "FadeOut");

	void PlayLoop(SoundEventEnum sfx, Vector3 position, string loopEndParameter = "FadeOut");

	void StopLoop(string eventRef, string loopEndParameter = "FadeOut");

	void StopLoop(SoundEventEnum sfx, string loopEndParameter = "FadeOut");

	void SetGlobalParameter(string parameter, float value, float lerpTime = 0f);

	float GetGlobalParameter(string parameter);

	void SetSnapshot(string shapshotName);
}
