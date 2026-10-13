using FMOD.Studio;
using FMODUnity;
using UnityEngine;

namespace Isto.GTW.Audio;

public class ObstacleAudioLooping : MonoBehaviour
{
	[SerializeField]
	private EventReference _soundEvent;

	private EventInstance _soundInstance;

	private void Start()
	{
		if (!_soundEvent.IsNull)
		{
			_soundInstance = RuntimeManager.CreateInstance(_soundEvent);
			RuntimeManager.AttachInstanceToGameObject(_soundInstance, base.transform);
			_soundInstance.start();
		}
	}

	private void OnDestroy()
	{
		_soundInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
	}
}
