using Isto.GTW.Player;
using UnityEngine;
using Zenject;

namespace Isto.GTW.LevelFeatures.LevelEventTriggers;

public class PlayerPhysicsOverrideTrigger : LevelEventTrigger
{
	[Space]
	[SerializeField]
	private PlayerPhysicsOverride.PhysicsOverride _physicsOverride;

	protected PlayerController _playerController;

	public PlayerPhysicsOverride PlayerPhysicsOverride => _playerController.PlayerPhysicsOverride;

	[Inject]
	public void Inject(PlayerController playerController)
	{
		_playerController = playerController;
	}

	private void OnDestroy()
	{
		PlayerPhysicsOverride.RemovePhysicsOverride(this);
	}

	private void OnTriggerEnter(Collider other)
	{
		_physicsOverride.source = this;
		PlayerPhysicsOverride.AddPhysicsOverride(_physicsOverride);
	}

	private void OnTriggerExit(Collider other)
	{
		PlayerPhysicsOverride.RemovePhysicsOverride(this);
	}
}
