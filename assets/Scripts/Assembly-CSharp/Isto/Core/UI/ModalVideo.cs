using FMODUnity;
using Isto.Core.Audio;
using Isto.Core.Beings;
using Isto.Core.StateMachine;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Video;
using Zenject;

namespace Isto.Core.UI;

public class ModalVideo : MonoBehaviour
{
	[Header("Test")]
	[SerializeField]
	private CanvasGroup _canvasGroup;

	[SerializeField]
	private RectTransform _pauseLabel;

	[SerializeField]
	private VideoPlayer _player;

	[SerializeField]
	private State _playerCutsceneState;

	[SerializeField]
	private EventReference _fmodEvent;

	[SerializeField]
	private UnityEvent _onEnd;

	private bool _playing;

	private bool _paused;

	private IGameSounds _music;

	private IPlayerController _playerController;

	[Inject]
	public void Inject(IGameSounds music, IPlayerController player)
	{
		_music = music;
		_playerController = player;
	}

	private void Awake()
	{
		_pauseLabel.gameObject.SetActive(value: false);
		_player.playOnAwake = false;
		_player.Stop();
		_player.frame = 0L;
		_player.isLooping = false;
		_player.playbackSpeed = 1f;
	}

	private void OnDestroy()
	{
		UnregisterEvents();
	}

	private void Start()
	{
		RegisterEvents();
	}

	private void Update()
	{
		if (_playing && (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Space)))
		{
			_paused = !_paused;
			if (_paused)
			{
				Pause();
			}
			else
			{
				Resume();
			}
		}
	}

	private void RegisterEvents()
	{
		_player.loopPointReached += VideoPlayer_LoopEnded;
	}

	private void UnregisterEvents()
	{
		_player.loopPointReached -= VideoPlayer_LoopEnded;
	}

	private void VideoPlayer_LoopEnded(VideoPlayer source)
	{
		_playing = false;
		Time.timeScale = 1f;
		if (_onEnd != null)
		{
			_onEnd.Invoke();
		}
		base.gameObject.SetActive(value: false);
	}

	[ContextMenu("Start Video")]
	public void TriggerVideo()
	{
		if (!base.gameObject.activeSelf)
		{
			base.gameObject.SetActive(value: true);
		}
		Time.timeScale = 0f;
		_player.frame = 0L;
		_player.Play();
		_playing = true;
		RuntimeManager.PlayOneShot(_fmodEvent, _playerController.GetPlayerPosition());
	}

	[ContextMenu("Stop Video")]
	public void ForceEndVideo()
	{
		_player.Stop();
		VideoPlayer_LoopEnded(null);
	}

	private void Pause()
	{
		_pauseLabel.gameObject.SetActive(value: true);
		_player.Pause();
		RuntimeManager.PauseAllEvents(paused: true);
	}

	private void Resume()
	{
		_pauseLabel.gameObject.SetActive(value: false);
		_player.Play();
		RuntimeManager.PauseAllEvents(paused: false);
	}
}
