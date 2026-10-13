using Isto.Core.Beings;
using UnityEngine;

namespace Isto.Core.Cheats;

[CreateAssetMenu(fileName = "DevMode - TogglePlayerInvincible (new)", menuName = "Scriptables/Dev Mode Actions/TogglePlayerInvincible")]
public class TogglePlayerInvincible : CheatAction
{
	private PlayerHealth _playerHealth;

	public override void Activate(params object[] args)
	{
		_playerHealth = Object.FindObjectOfType<PlayerHealth>();
		_playerHealth.SetInvincible(invincible: true);
	}

	public override void Deactivate()
	{
		_playerHealth.SetInvincible(invincible: false);
	}

	public override void OnUpdate()
	{
	}
}
