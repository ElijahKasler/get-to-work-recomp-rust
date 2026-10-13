using UnityEngine;

namespace Isto.GTW;

public class DisableAfterParticles : MonoBehaviour
{
	[Tooltip("Should the object be destroyed after the particle system is complete or just disabled?")]
	public bool destroyObject;

	public ParticleSystem system;

	private ParticleSystem _system;

	private float _enableTime;

	private void Awake()
	{
		_system = ((system == null) ? GetComponent<ParticleSystem>() : system);
	}

	private void OnEnable()
	{
		_enableTime = Time.time;
		_system.time = 0f;
		_system.Play();
	}

	private void Update()
	{
		if (!IsSystemActive())
		{
			if (!destroyObject)
			{
				base.gameObject.SetActive(value: false);
			}
			else
			{
				Object.Destroy(base.gameObject);
			}
		}
	}

	private bool IsSystemActive()
	{
		return _enableTime + _system.main.startLifetime.constantMax + _system.main.startDelay.constantMax > Time.time;
	}
}
