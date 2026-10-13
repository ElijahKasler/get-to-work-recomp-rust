using Isto.Core.Beings;
using UnityEngine;

namespace Isto.Core.Cheats;

[CreateAssetMenu(fileName = "New Health Restore Action", menuName = "Scriptables/Dev Mode Actions/Player Health Restore Action")]
public class AddHealthDeveloperAction : CheatAction
{
	public float amount = 50f;

	public override void Activate(params object[] args)
	{
		PlayerHealth playerHealth = Object.FindObjectOfType<PlayerHealth>();
		if (playerHealth != null)
		{
			playerHealth.Heal(amount);
			Debug.LogFormat("Adding {0} player health", amount);
			return;
		}
		throw new UnityException("Cannot find Player health in scene.  Add Health action can only be performed in a running game");
	}

	public override void Deactivate()
	{
	}

	public override void OnUpdate()
	{
	}
}
