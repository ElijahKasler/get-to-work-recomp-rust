using System.Collections;
using Isto.Core.Inputs;
using Isto.Core.StateMachine;
using UnityEngine;
using Zenject;

namespace Isto.Core.Beings;

[RequireComponent(typeof(PlayerAbilities))]
[RequireComponent(typeof(PlayerHealth))]
public abstract class CorePlayerController : ScriptableStateMachine, IPlayerController
{
	protected PlayerAbilities _abilities;

	protected PlayerHealth _playerHealth;

	protected bool _statesPaused;

	protected IControls _controls;

	protected abstract Collider MainHitBox { get; }

	public State CurrentState => _currentState;

	public PlayerAbilities Abilities => _abilities;

	public abstract State MovementState { get; }

	public abstract bool IsMoving { get; }

	[Inject]
	private void Inject(IControls controls)
	{
		_controls = controls;
	}

	protected virtual void Awake()
	{
		_abilities = GetComponent<PlayerAbilities>();
		_playerHealth = GetComponent<PlayerHealth>();
	}

	protected virtual void OnEnable()
	{
		RegisterEvents();
	}

	protected virtual void OnDisable()
	{
		UnregisterEvents();
	}

	protected virtual void Update()
	{
		if (!_statesPaused && !(_currentState == null))
		{
			State state = _currentState.Run(this) as State;
			if (state != _currentState)
			{
				ChangeState(state);
			}
		}
	}

	private void RegisterEvents()
	{
		_playerHealth.Killed += OnPlayerKilled;
		_playerHealth.TookDamage += OnPlayerTakeDamage;
	}

	private void UnregisterEvents()
	{
		_playerHealth.TookDamage -= OnPlayerTakeDamage;
		_playerHealth.Killed -= OnPlayerKilled;
	}

	protected abstract void OnPlayerTakeDamage(object sender, HealthEventArgs e);

	protected abstract void OnPlayerKilled(object sender, HealthEventArgs e);

	public virtual Vector3 GetPlayerPosition()
	{
		return base.transform.position;
	}

	public virtual void SetPlayerPosition(Vector3 pos)
	{
		base.transform.position = pos;
	}

	public virtual void SetPlayerColliderState(bool state)
	{
		MainHitBox.enabled = state;
	}

	public virtual void DisableAllPlayerControls(float time)
	{
		_controls.DisableControls(time);
	}

	public virtual void EnablePlayerControls()
	{
		_controls.EnableControls();
	}

	public virtual void SetPlayerPauseState(bool paused, float resetTime = 0f)
	{
		_statesPaused = paused;
		if (resetTime != 0f)
		{
			Invoke("UnPausePlayer", resetTime);
		}
	}

	private void UnPausePlayer()
	{
		_statesPaused = false;
	}

	public virtual IEnumerator DisablePlayerForTimeRoutine(float time)
	{
		SetPlayerPauseState(paused: true);
		yield return new WaitForSeconds(time);
		SetPlayerPauseState(paused: false);
	}

	public abstract void SetMovementEnabled(bool active);

	public abstract void ChangeToMoveState();

	public abstract void ChangeToCustomState(State state);

	public virtual void Respawn()
	{
		_playerHealth.Respawn();
	}
}
