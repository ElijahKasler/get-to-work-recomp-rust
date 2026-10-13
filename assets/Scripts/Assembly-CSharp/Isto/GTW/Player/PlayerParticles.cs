using System;
using System.Collections.Generic;
using UnityEngine;

namespace Isto.GTW.Player;

public class PlayerParticles : MonoBehaviour
{
	[Serializable]
	public class ParticleObject
	{
		public ParticleSystem particle;

		public TrailRenderer trailRenderer;

		public Transform targetTransform;

		public void PlayParticle(bool isPlaying)
		{
			if (particle != null)
			{
				if (isPlaying && !particle.isPlaying)
				{
					particle.Play();
				}
				else if (!isPlaying && particle.isPlaying)
				{
					particle.Stop();
				}
			}
			if (trailRenderer != null)
			{
				trailRenderer.emitting = isPlaying;
			}
		}

		public void UpdatePosition()
		{
			if (particle != null)
			{
				particle.transform.position = targetTransform.position;
			}
			if (trailRenderer != null)
			{
				trailRenderer.transform.position = targetTransform.position;
			}
		}

		public void UpdateRotation(Quaternion rotation)
		{
			if (particle != null)
			{
				particle.transform.rotation = rotation;
			}
		}
	}

	[SerializeField]
	private bool _particleEnabled;

	[SerializeField]
	private List<ParticleObject> _particles = new List<ParticleObject>();

	private PlayerController _playerController;

	private PlayerAnimation _playerAnimation;

	private float _defaultRateOverTime;

	public PlayerCollisionHandler PlayerCollisionHandler => _playerController.PlayerCollisionHandler;

	public PlayerModelController PlayerModelController => _playerController.PlayerModelController;

	private void Awake()
	{
		_playerController = GetComponentInParent<PlayerController>();
		_playerAnimation = _playerController.GetComponentInChildren<PlayerAnimation>();
	}

	private void LateUpdate()
	{
		float airForwardInput = _playerAnimation.AirForwardInput;
		bool flag = (!PlayerCollisionHandler.IsGrounded || _playerController.CurrentSpeedKPH > 35f) && airForwardInput > 0.1f;
		foreach (ParticleObject particle in _particles)
		{
			particle.PlayParticle(flag && _particleEnabled);
			particle.UpdatePosition();
			particle.UpdateRotation(PlayerModelController.transform.rotation * Quaternion.Euler(0f, 180f, 0f));
		}
	}
}
