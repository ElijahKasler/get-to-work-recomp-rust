using System;
using System.Collections;
using Isto.Core.Beings;
using Isto.Core.StateMachine;
using UnityEngine;
using Zenject;

namespace Isto.Core.AI;

public class PushBackLungeAttack : AIAction
{
	public float damage = 20f;

	public float impactForce = 50f;

	public AnimationCurve attackMoveCurve = AnimationCurve.Linear(0f, 0f, 1f, 1f);

	public float lungeAttackSpeed = 3f;

	public float lungeDistance = 3f;

	[Tooltip("How much +- the lunge distance will be randomly chosen")]
	public float lungeVariance = 2f;

	public float coolDown = 1f;

	[Header("Collision Checks")]
	[Tooltip("Checks that objects on these layers are not in the path of the lunge")]
	public LayerMask collisionLayers;

	[Tooltip("The layers that the lunge attack will cause damage to")]
	public LayerMask doesDamageToLayers;

	[Header("Effects")]
	[SerializeField]
	private ParticleSystem[] _smokeParticleSystems;

	[SerializeField]
	private LineRenderer _attackLine;

	private AutomationPlayerController _player;

	private Health _mobHealth;

	private Vector3 _startPosition;

	private Vector3 _endPosition;

	private Vector3 _attackDirection;

	private bool _readyForNextAttack;

	private RaycastHit _hitBuffer;

	public bool IsAttacking { get; private set; }

	[Inject]
	public void Inject(AutomationPlayerController playerController)
	{
		_player = playerController;
	}

	private void Awake()
	{
		_mobHealth = GetComponent<Health>();
	}

	private void OnEnable()
	{
		_mobHealth.TookDamage += OnTookDamage;
		_mobHealth.Killed += OnKilled;
		IStunnable mobHealth = _mobHealth;
		if (mobHealth != null)
		{
			mobHealth.Stunned += OnStunned;
		}
	}

	private void OnStunned(object sender, HealthEventArgs e)
	{
		StopAllCoroutines();
		isInteruptable = true;
		isRunning = false;
	}

	private void OnDisable()
	{
		_mobHealth.TookDamage -= OnTookDamage;
		_mobHealth.Killed -= OnKilled;
		IStunnable mobHealth = _mobHealth;
		if (mobHealth != null)
		{
			mobHealth.Stunned -= OnStunned;
		}
	}

	public void OnCollisionEnter(Collision collision)
	{
		HandleCollision(collision.gameObject);
	}

	public void OnTriggerEnter(Collider other)
	{
		HandleCollision(other.gameObject);
	}

	private void HandleCollision(GameObject hitObject)
	{
		if (!isRunning || !IsAttacking)
		{
			return;
		}
		if (collisionLayers.IsInLayerMask(hitObject.layer) || hitObject.layer == Layers.PLAYER)
		{
			StopAllCoroutines();
			StartCoroutine(CompleteAttackCoroutine());
		}
		if (doesDamageToLayers.IsInLayerMask(hitObject.layer))
		{
			Health componentInParent = hitObject.GetComponentInParent<Health>();
			if (componentInParent != null)
			{
				Vector3 force = _attackDirection * impactForce;
				componentInParent.TakeDamage(damage, force, Health.DamageTypeEnum.PHYSICAL, Health.DamageSourceEnum.MOB);
			}
		}
	}

	private void OnTookDamage(object sender, HealthEventArgs e)
	{
		StopAllCoroutines();
		if (isRunning)
		{
			StartCoroutine(CompleteAttackCoroutine());
		}
	}

	private void OnKilled(object sender, EventArgs args)
	{
		StopAllCoroutines();
		isInteruptable = true;
		isRunning = false;
	}

	public override void StartAction(MobStateMachine controller)
	{
		base.StartAction(controller);
		_controller.GroupController.RegisterAttack(this);
		StartAttack();
	}

	private void StartAttack()
	{
		IsAttacking = true;
		_readyForNextAttack = false;
		_startPosition = base.transform.position;
		_endPosition = GetEndPosition();
		_attackDirection = (_endPosition - _startPosition).normalized;
		_controller.StopMob();
		_controller.SetAnimationDirectionAndState(_attackDirection, AnimationController.AnimationType.pre_attack);
		if (_attackLine != null)
		{
			_attackLine.enabled = true;
			_attackLine.positionCount = 2;
			_attackLine.SetPosition(0, _startPosition);
			_attackLine.SetPosition(1, _endPosition);
		}
		EmitSmoke();
		isInteruptable = false;
	}

	private void EmitSmoke()
	{
		for (int i = 0; i < _smokeParticleSystems.Length; i++)
		{
			if (_smokeParticleSystems[i].gameObject.activeInHierarchy)
			{
				_smokeParticleSystems[i].Emit(40);
			}
		}
	}

	public override void UpdateAction()
	{
		if (_readyForNextAttack)
		{
			StartAttack();
		}
		CheckMobImpact();
	}

	private bool CheckMobImpact()
	{
		if (!IsAttacking)
		{
			return false;
		}
		Rigidbody component = GetComponent<Rigidbody>();
		if (Mathf.Abs(component.linearVelocity.x) > 0.1f || Mathf.Abs(component.linearVelocity.z) > 0.1f)
		{
			StopAllCoroutines();
			StartCoroutine(CompleteAttackCoroutine());
			return true;
		}
		return false;
	}

	public override void StopAction()
	{
		_controller.GroupController.UnregisterAttack(this);
		HideAttackLine();
		base.StopAction();
	}

	private void HideAttackLine()
	{
		if (_attackLine != null)
		{
			_attackLine.enabled = false;
			_attackLine.positionCount = 0;
		}
	}

	private void PreAttackComplete()
	{
		if (!CheckMobImpact())
		{
			_controller.SetAnimationDirectionAndState(_attackDirection, AnimationController.AnimationType.attack);
			StartCoroutine(LungeForward());
		}
	}

	private IEnumerator LungeForward()
	{
		float attackTimer = 0f;
		float totalattackTime = Vector3.Distance(_startPosition, _endPosition) / lungeAttackSpeed;
		while (attackTimer < totalattackTime)
		{
			attackTimer += Time.deltaTime;
			_controller.agent.Warp(Vector3.Lerp(_startPosition, _endPosition, attackMoveCurve.Evaluate(attackTimer / totalattackTime)));
			yield return null;
		}
		yield return CompleteAttackCoroutine();
	}

	private IEnumerator CompleteAttackCoroutine()
	{
		_controller.StopMob();
		_controller.SetAnimationDirectionAndState(_attackDirection, AnimationController.AnimationType.post_attack);
		IsAttacking = false;
		HideAttackLine();
		yield return new WaitForSeconds(0.25f);
		float timer = 0f;
		while (timer < coolDown)
		{
			Vector3 forward = _player.transform.position - base.transform.position;
			_controller.SetAnimationDirectionAndState(forward, AnimationController.AnimationType.idle);
			timer += Time.deltaTime;
			yield return null;
		}
		_readyForNextAttack = true;
		isInteruptable = true;
		yield return null;
	}

	private Vector3 GetEndPosition()
	{
		Ray ray = new Ray(base.transform.position, _player.transform.position - base.transform.position);
		float num = lungeDistance + UnityEngine.Random.Range(0f - lungeVariance, lungeVariance);
		if (Physics.Raycast(ray, out _hitBuffer, num, collisionLayers))
		{
			Vector3 point = _hitBuffer.point;
			point.y = 0f;
			return point;
		}
		return base.transform.position + ray.direction * num;
	}
}
