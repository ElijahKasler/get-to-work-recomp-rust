using Isto.Core.Cheats;
using Isto.GTW.Player;
using UnityEngine;

namespace Isto.GTW.DeveloperMode.Actions;

[CreateAssetMenu(fileName = "DevMode - Enable Grab Ability Action", menuName = "Scriptables/Dev Mode Actions/Enable Grab Ability Action")]
public class EnableGrabAbilityAction : CheatAction
{
	public override void Activate(params object[] args)
	{
		PlayerController.CurrentPlayer.grabAbilityAvailable = !PlayerController.CurrentPlayer.grabAbilityAvailable;
		Debug.Log("Grab ability is " + (PlayerController.CurrentPlayer.grabAbilityAvailable ? "enabled" : "disabled"));
	}

	public override void OnUpdate()
	{
	}

	public override void Deactivate()
	{
	}
}
