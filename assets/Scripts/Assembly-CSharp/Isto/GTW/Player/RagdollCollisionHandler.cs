using UnityEngine;

namespace Isto.GTW.Player;

public class RagdollCollisionHandler : MonoBehaviour
{
	private PlayerController _playerController;

	private int _playerModelLayer;

	private PlayerRagdoll PlayerRagdoll => _playerController.PlayerIkController.PlayerRagdoll;

	private void Awake()
	{
		_playerController = GetComponentInParent<PlayerController>();
		_playerModelLayer = LayerMask.NameToLayer("PlayerModel");
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.layer != _playerModelLayer)
		{
			PlayerRagdoll.RagdollCollisionHit(collision.impulse, base.transform);
		}
	}
}
