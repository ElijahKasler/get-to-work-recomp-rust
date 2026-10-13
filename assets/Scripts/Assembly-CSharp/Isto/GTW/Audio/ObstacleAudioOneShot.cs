using FMODUnity;
using UnityEngine;

namespace Isto.GTW.Audio;

public class ObstacleAudioOneShot : MonoBehaviour
{
	[SerializeField]
	private EventReference _soundEvent;

	[SerializeField]
	private Transform _soundTransformPosition;

	public void PlaySound()
	{
		if (!_soundEvent.IsNull)
		{
			RuntimeManager.PlayOneShot(_soundEvent, _soundTransformPosition.position);
		}
	}
}
