using FMOD.Studio;
using FMODUnity;
using Isto.GTW.Player;
using UnityEngine;
using Zenject;

namespace Isto.GTW.Audio;

public class VolumetricAmbience : MonoBehaviour
{
	[SerializeField]
	private EventReference _soundEvent;

	private EventInstance _soundInstance;

	private BoxCollider[] _colliders;

	private PlayerController _playerController;

	[Inject]
	public void Inject(PlayerController player)
	{
		_playerController = player;
	}

	private void Start()
	{
		if (!_soundEvent.IsNull)
		{
			_soundInstance = RuntimeManager.CreateInstance(_soundEvent);
			RuntimeManager.AttachInstanceToGameObject(_soundInstance, base.transform);
			_colliders = GetComponents<BoxCollider>();
		}
	}

	private void Update()
	{
		bool flag = false;
		BoxCollider[] colliders = _colliders;
		for (int i = 0; i < colliders.Length; i++)
		{
			if (colliders[i].bounds.Contains(_playerController.Rigidbody.transform.position))
			{
				flag = true;
			}
		}
		if (flag)
		{
			if (!IsPlaying())
			{
				_soundInstance.start();
			}
		}
		else if (IsPlaying())
		{
			_soundInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
		}
	}

	private void OnDestroy()
	{
		_soundInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
	}

	private bool IsPlaying()
	{
		_soundInstance.getPlaybackState(out var state);
		return state != PLAYBACK_STATE.STOPPED;
	}
}
