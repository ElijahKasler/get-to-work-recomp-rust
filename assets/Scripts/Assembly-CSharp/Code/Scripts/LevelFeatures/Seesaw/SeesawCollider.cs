using Isto.GTW.Player;
using UnityEngine;

namespace Code.Scripts.LevelFeatures.Seesaw;

public class SeesawCollider : MonoBehaviour
{
	private Seesaw _seesaw;

	private PlayerCollisionHandler _playerCollisionHandler;

	private bool _isColliding;

	private void Awake()
	{
		_seesaw = GetComponentInParent<Seesaw>();
	}

	private void OnCollisionEnter(Collision other)
	{
		if (other.collider.CompareTag("Player"))
		{
			if (_playerCollisionHandler == null)
			{
				_playerCollisionHandler = other.collider.gameObject.GetComponent<PlayerCollisionHandler>();
			}
			if (_playerCollisionHandler != null)
			{
				_isColliding = true;
				_seesaw.PlayerCollision(_playerCollisionHandler.CurrentCurrentGroundHitData.hit.point);
			}
		}
	}

	private void LateUpdate()
	{
		if (_isColliding && _playerCollisionHandler.IsGrounded)
		{
			if (!_playerCollisionHandler.IsGrounded)
			{
				_isColliding = false;
			}
			else if (_playerCollisionHandler == null || _playerCollisionHandler.CurrentCurrentGroundHitData.hit.collider.gameObject != base.gameObject)
			{
				_isColliding = false;
			}
			else
			{
				_seesaw.PlayerCollision(_playerCollisionHandler.CurrentCurrentGroundHitData.hit.point);
			}
		}
	}
}
