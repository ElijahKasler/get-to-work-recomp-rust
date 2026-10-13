using UnityEngine;

namespace Isto.Core.Audio;

[RequireComponent(typeof(AudioSource))]
public class DestroyAfterAudio : MonoBehaviour
{
	private AudioSource _audioSource;

	private bool _started;

	private void Awake()
	{
		_audioSource = GetComponent<AudioSource>();
		_started = false;
	}

	private void Update()
	{
		if (_audioSource.isPlaying && !_started)
		{
			_started = true;
		}
		else if (!_audioSource.isPlaying && _started)
		{
			Object.Destroy(base.gameObject);
		}
	}
}
