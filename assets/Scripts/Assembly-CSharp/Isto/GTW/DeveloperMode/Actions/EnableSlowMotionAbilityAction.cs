using Isto.Core.Cheats;
using Isto.GTW.Player;
using UnityEngine;

namespace Isto.GTW.DeveloperMode.Actions;

[CreateAssetMenu(fileName = "DevMode - Enable Slow Motion Ability Action", menuName = "Scriptables/Dev Mode Actions/Enable Slow Motion Ability Action")]
public class EnableSlowMotionAbilityAction : CheatAction
{
	public override void Activate(params object[] args)
	{
		PlayerController.CurrentPlayer.slowMotionAbilityAvailable = !PlayerController.CurrentPlayer.slowMotionAbilityAvailable;
		Debug.Log("Slow Motion ability is " + (PlayerController.CurrentPlayer.slowMotionAbilityAvailable ? "enabled" : "disabled"));
	}

	public override void OnUpdate()
	{
	}

	public override void Deactivate()
	{
	}
}
