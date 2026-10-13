using System;
using Isto.GTW.Player;
using UnityEngine;
using Zenject;

namespace Code.Scripts.LevelFeatures.AnimatedPhysicsObject;

public class RotatingObject : MonoBehaviour
{
	[SerializeField]
	private Rigidbody _rigidbody;

	[SerializeField]
	private Vector3 _speed = Vector3.zero;

	[SerializeField]
	private bool _fixedUpdate = true;

	private Vector3 _defaultRotation;

	private PlayerController _playerController;

	[Inject]
	public void Inject(PlayerController playerController)
	{
		_playerController = playerController;
	}

	private void Awake()
	{
		_defaultRotation = _rigidbody.rotation.eulerAngles;
	}

	private void Start()
	{
		PlayerController playerController = _playerController;
		playerController.OnPlayerRespawn = (Action)Delegate.Combine(playerController.OnPlayerRespawn, new Action(PlayerRespawn));
	}

	private void OnDestroy()
	{
		PlayerController playerController = _playerController;
		playerController.OnPlayerRespawn = (Action)Delegate.Remove(playerController.OnPlayerRespawn, new Action(PlayerRespawn));
	}

	private void FixedUpdate()
	{
		if (_fixedUpdate && _rigidbody != null)
		{
			_rigidbody.MoveRotation(_rigidbody.rotation * Quaternion.Euler(_speed * Time.fixedDeltaTime));
		}
	}

	private void Update()
	{
		if (!_fixedUpdate)
		{
			base.transform.Rotate(_speed * Time.deltaTime);
		}
	}

	private void PlayerRespawn()
	{
		if (_fixedUpdate)
		{
			if (_rigidbody != null)
			{
				_rigidbody.rotation = Quaternion.Euler(_defaultRotation);
			}
		}
		else
		{
			base.transform.Rotate(_defaultRotation);
		}
	}
}
