using FMODUnity;
using Isto.GTW.LevelFeatures;
using Isto.GTW.Player;
using UnityEngine;
using Zenject;

namespace Code.Scripts.LevelFeatures.ForceTrigger;

public abstract class ForceTriggerBase : LevelEventTrigger
{
	[SerializeField]
	private bool _triggerOnEnter;

	[SerializeField]
	private float _triggerInterval = 2f;

	[SerializeField]
	protected float _force = 100f;

	[Space]
	[SerializeField]
	private Animator _animator;

	[SerializeField]
	private string _animationTrigger;

	[Space]
	[SerializeField]
	private EventReference _audioRef;

	[SerializeField]
	private bool _playHurtSound;

	private bool _readyToLaunch;

	private float _cooldown;

	private bool _launchPlayer;

	protected PlayerController _playerController;

	[Inject]
	public void Inject(PlayerController playerController)
	{
		_playerController = playerController;
	}

	private void Awake()
	{
		_cooldown = _triggerInterval;
	}

	private void Start()
	{
		if (_animator != null)
		{
			_animator.enabled = false;
		}
	}

	private void Update()
	{
		_cooldown -= Time.deltaTime;
		if (!(_cooldown <= 0f))
		{
			return;
		}
		_cooldown = _triggerInterval;
		if (!_triggerOnEnter)
		{
			PlayAnimation();
			PlayAudio();
			if (_readyToLaunch)
			{
				_launchPlayer = true;
				_readyToLaunch = false;
			}
		}
	}

	private void FixedUpdate()
	{
		if (_launchPlayer)
		{
			ApplyForce();
			_launchPlayer = false;
		}
	}

	protected abstract void ApplyForce();

	private void OnTriggerEnter(Collider other)
	{
		if (!(other.tag != "PlayerEventTrigger"))
		{
			if (_triggerOnEnter)
			{
				PlayAnimation();
				PlayAudio();
				_launchPlayer = true;
			}
			else
			{
				_readyToLaunch = true;
			}
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (!(other.tag != "PlayerEventTrigger"))
		{
			_readyToLaunch = false;
		}
	}

	private void PlayAnimation()
	{
		if (_animator != null)
		{
			_animator.enabled = true;
			_animator.SetTrigger(_animationTrigger);
		}
	}

	private void PlayAudio()
	{
		if (!_audioRef.IsNull)
		{
			RuntimeManager.PlayOneShot(_audioRef, base.transform.position);
		}
		if (_playHurtSound)
		{
			_playerController.PlayerAudio.Hurt(9000f);
		}
	}
}
