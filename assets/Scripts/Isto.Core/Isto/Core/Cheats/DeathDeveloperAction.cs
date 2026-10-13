using Isto.Core.Beings;
using UnityEngine;

namespace Isto.Core.Cheats;

[CreateAssetMenu(fileName = "New Death Action", menuName = "Scriptables/Dev Mode Actions/Player Death Action")]
public class DeathDeveloperAction : CheatAction
{
	private float killingAmount = 120f;

	public override void Activate(params object[] args)
	{
		PlayerHealth playerHealth = Object.FindObjectOfType<PlayerHealth>();
		if (playerHealth != null)
		{
			playerHealth.TakeDamage(killingAmount, Health.DamageTypeEnum.PHYSICAL, Health.DamageSourceEnum.MOB);
			Debug.LogFormat("Dealing {0} damage to player", killingAmount);
			return;
		}
		throw new UnityException("Cannot find Player health in scene. Death action can only be performed in a running game");
	}

	public override void Deactivate()
	{
	}

	public override void OnUpdate()
	{
	}
}
