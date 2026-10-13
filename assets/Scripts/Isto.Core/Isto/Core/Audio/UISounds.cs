using FMODUnity;
using Isto.Core.Configuration;
using UnityEngine;
using Zenject;

namespace Isto.Core.Audio;

[RequireComponent(typeof(StudioEventEmitter))]
public class UISounds : MonoBehaviour
{
	[EventRef]
	public string buttonErrorRef;

	[EventRef]
	public string buttonHoverRef;

	[SerializeField]
	private StudioEventEmitter _audio;

	[SerializeField]
	private AudioTrackReferences _tracks;

	private Isto.Core.Configuration.Settings _settings;

	[Inject]
	public void Inject(Isto.Core.Configuration.Settings settings)
	{
		_settings = settings;
	}

	public void PlayButtonClickSound()
	{
		if (!string.IsNullOrEmpty(_audio.Event))
		{
			_audio.Play();
		}
	}

	public void PlayButtonHoverSound()
	{
		PlayOneShot(buttonHoverRef);
	}

	public void PlayButtonErrorSound()
	{
		PlayOneShot(buttonErrorRef);
	}

	public void PlayOneShot(string path)
	{
		RuntimeManager.PlayOneShot(path, base.transform.position);
	}

	public void PlayOneShot(EventReference eventRef)
	{
		RuntimeManager.PlayOneShot(eventRef);
	}
}
