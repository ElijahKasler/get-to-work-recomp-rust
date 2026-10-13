using System;
using System.Collections.Generic;
using FMODUnity;
using I2.Loc;
using Isto.Core.Analytics;
using Isto.Core.Audio;
using Isto.Core.Cameras;
using Isto.Core.Game;
using Isto.Core.Inputs;
using Isto.Core.Items;
using Isto.Core.Localization;
using Isto.Core.Scenes;
using Isto.Core.Tiles;
using Isto.Core.UI;
using UnityEngine;
using Zenject;

namespace Isto.Core.Beings;

public class PlayerHealth : MonoBehaviour, ISliderDisplay
{
	[Header("Core Health Config")]
	public float currentMaxHealth = 100f;

	public readonly float startingMaxHealth = 100f;

	public float healPerSecond = 2f;

	public float stunTimeAfterDamage = 0.5f;

	public float invincibleTimeAfterDamage = 0.5f;

	[Header("Core Health Status")]
	[SerializeField]
	protected float _currentHealth;

	[SerializeField]
	protected bool _isInvincible;

	[Header("Core Audio")]
	[EventRef]
	public string takeDamageAudioRef;

	[Header("Core Buffs and Resistances")]
	public BuffEffect activeBuff;

	public float buffTimeRemaining;

	public float buffDurationUpgrade;

	public List<ResistanceBuff> activeResistances;

	public float damageReduction;

	[SerializeField]
	private LocalizedString _buffExpiringMessage;

	[Header("Core Environment")]
	[SerializeField]
	protected TileGroundCheck _tileGroundCheck;

	private bool _buffWarningSent;

	private IControls _controls;

	protected IGameSounds _sounds;

	private IUIMessages _uIMessages;

	private IAnalyticsHandler _analytics;

	private UIDamageTextDisplay.Pool _dmgDisplayPool;

	protected CameraController _cameraControl;

	private GameScenesReference _gameScenesReference;

	public float CurrentHealth => _currentHealth;

	public float StunPercent => 0f;

	public bool Alive => _currentHealth > 0f;

	public event EventHandler<HealthEventArgs> Killed;

	public event EventHandler<HealthEventArgs> TookDamage;

	public event EventHandler<BuffEventArgs> NewBuffSet;

	public event System.EventHandler Respawned;

	[Inject]
	public void Inject(IControls controls, [InjectOptional] IGameSounds gameSounds, IAnalyticsHandler analytics, [InjectOptional(Id = UIMessageHandlerType.HighPriorityMessage)] IUIMessages messages, [InjectOptional] UIDamageTextDisplay.Pool dmgDisplayPool, GameScenesReference gameScenesReference, [InjectOptional] CameraController cameraController)
	{
		_controls = controls;
		_sounds = gameSounds;
		_analytics = analytics;
		_uIMessages = messages;
		_dmgDisplayPool = dmgDisplayPool;
		_gameScenesReference = gameScenesReference;
		_cameraControl = cameraController;
	}

	protected virtual void Awake()
	{
		_currentHealth = currentMaxHealth;
	}

	private void Update()
	{
		if (Alive)
		{
			_currentHealth = Mathf.Clamp(_currentHealth + healPerSecond * Time.deltaTime, 0f, currentMaxHealth);
		}
		UpdateBuffTimer();
		UpdateEnvironmentDamageAndResistances();
	}

	protected bool HasResistanceTo(Health.DamageTypeEnum damageType)
	{
		for (int i = 0; i < activeResistances.Count; i++)
		{
			if (activeResistances[i].DamageType == damageType)
			{
				return true;
			}
		}
		return false;
	}

	public void SetHealth(float value)
	{
		_currentHealth = value;
	}

	public void SetMaxHealth(float increaseFactor)
	{
		currentMaxHealth = startingMaxHealth + startingMaxHealth * increaseFactor;
	}

	public void SetInvincible(bool invincible)
	{
		_isInvincible = invincible;
	}

	public void SetInvincible(float time)
	{
		_isInvincible = true;
		CancelInvoke();
		Invoke("DisableInvicibleInvoked", time);
	}

	public float GetHealthRemaining(Health.DamageTypeEnum type)
	{
		return _currentHealth;
	}

	public float GetCurrentPercent()
	{
		return _currentHealth / currentMaxHealth;
	}

	public void TakeDamage(float damage, Health.DamageTypeEnum type, Health.DamageSourceEnum source, Transform damageSourceTransform = null)
	{
		if (type == null)
		{
			type = Health.DamageTypeEnum.PHYSICAL;
		}
		if (source == null)
		{
			source = Health.DamageSourceEnum.MOB;
		}
		if (Alive && !_isInvincible && !GameState.StoryAnimationActive)
		{
			for (int i = 0; i < activeResistances.Count; i++)
			{
				damage = activeResistances[i].ModifyDamage(type, damage);
			}
			damage -= damage * damageReduction;
			ApplyDamageByType(damage, type, source);
			_controls.VibrateController(Controls.VibrationMode.Long);
			TookDamage?.Invoke(this, new HealthEventArgs(damage, type, source, damageSourceTransform, stunTimeAfterDamage));
			_dmgDisplayPool?.Spawn(0f - damage, base.transform.position, type);
			CameraController.CameraShakeTriggers cameraShakeByType = GetCameraShakeByType(type);
			if (cameraShakeByType != CameraController.CameraShakeTriggers.none)
			{
				_cameraControl?.AnimateCameraShake(cameraShakeByType);
			}
			if (!Alive)
			{
				ResetAllElementTimers();
				SendDeathAnalyticsData(type);
				SetNewBuff(null);
				Killed?.Invoke(this, new HealthEventArgs(damage, type, source));
			}
			else
			{
				SetInvincible(invincibleTimeAfterDamage);
			}
		}
	}

	protected virtual void ApplyDamageByType(float damage, Health.DamageTypeEnum t, Health.DamageSourceEnum s)
	{
		if (t == Health.DamageTypeEnum.PHYSICAL)
		{
			_sounds?.PlayOneShot(takeDamageAudioRef, base.transform.position);
			_currentHealth -= damage;
		}
		else
		{
			Debug.LogError("CorePlayerHealth attempted to apply unsupported type of damage: " + t.Name);
		}
	}

	protected virtual CameraController.CameraShakeTriggers GetCameraShakeByType(Health.DamageTypeEnum t)
	{
		return CameraController.CameraShakeTriggers.shakeLight;
	}

	protected void SendDeathAnalyticsData(Health.DamageTypeEnum type)
	{
		string text = _gameScenesReference.GetCurrentSceneName();
		if (string.IsNullOrEmpty(text))
		{
			text = "unknown";
		}
		_analytics.RegisterPlayerDeath(text, base.gameObject.transform.position, new List<string> { type.Name });
	}

	public void Heal(float amount)
	{
		Heal(amount, Health.DamageTypeEnum.PHYSICAL);
	}

	public void Heal(float amount, Health.DamageTypeEnum type)
	{
		if (type == Health.DamageTypeEnum.PHYSICAL)
		{
			_currentHealth = Mathf.Clamp(_currentHealth + amount, 0f, currentMaxHealth);
			return;
		}
		throw new NotImplementedException("No handler for restoring health of type " + type.Name + " yet");
	}

	public void Respawn()
	{
		_currentHealth = currentMaxHealth;
		Respawned?.Invoke(this, EventArgs.Empty);
	}

	public void SetNewBuff(BuffEffect buffEffect)
	{
		bool flag = false;
		if (activeBuff != null)
		{
			activeBuff.ExpireBuff(base.gameObject);
			flag = true;
			_buffWarningSent = false;
		}
		activeBuff = buffEffect;
		if (activeBuff != null)
		{
			activeBuff.ActivateBuff(base.gameObject);
			buffTimeRemaining = buffEffect.effectDuration * (1f + buffDurationUpgrade);
			flag = true;
		}
		else
		{
			buffTimeRemaining = 0f;
		}
		if (flag)
		{
			NewBuffSet?.Invoke(this, new BuffEventArgs(activeBuff));
		}
	}

	protected virtual void UpdateBuffTimer()
	{
		if (GameState.StoryAnimationActive)
		{
			return;
		}
		buffTimeRemaining -= Time.deltaTime;
		if (buffTimeRemaining < 10f && !_buffWarningSent && activeBuff != null)
		{
			_buffWarningSent = true;
			_uIMessages.CreateHighPriorityMsg(Loc.Get(_buffExpiringMessage), HighPriorityMessage.MessageType.warning);
		}
		if (buffTimeRemaining < 0f)
		{
			if (activeBuff != null)
			{
				_uIMessages.CreateMessage(Loc.Get(_buffExpiringMessage));
			}
			SetNewBuff(null);
		}
		else if (activeBuff != null)
		{
			activeBuff.UpdateBuf(base.gameObject);
		}
	}

	[ContextMenu("Disable Buff")]
	public void DisableBuff()
	{
		buffTimeRemaining = 0f;
	}

	protected virtual void UpdateEnvironmentDamageAndResistances()
	{
	}

	protected virtual void ResetAllElementTimers()
	{
	}

	private void DisableInvicibleInvoked()
	{
		_isInvincible = false;
	}
}
