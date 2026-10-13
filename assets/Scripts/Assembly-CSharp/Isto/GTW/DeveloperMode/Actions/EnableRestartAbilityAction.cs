using Isto.Core.Cheats;
using Isto.GTW.Player;
using UnityEngine;

namespace Isto.GTW.DeveloperMode.Actions;

[CreateAssetMenu(fileName = "DevMode - Enable Restart Ability Action", menuName = "Scriptables/Dev Mode Actions/Enable Restart Ability Action")]
public class EnableRestartAbilityAction : CheatAction
{
	public override void Activate(params object[] args)
	{
		bool? flag = ArgToBool(args[0]);
		if (!flag.HasValue)
		{
			throw new UnityException("Argument error. Usage: EnableRestartAbility True");
		}
		PlayerController.CurrentPlayer.restartAbilityAvailable = flag.Value;
		Debug.Log("Restart ability is " + (PlayerController.CurrentPlayer.restartAbilityAvailable ? "enabled" : "disabled"));
	}

	public override void OnUpdate()
	{
	}

	public override void Deactivate()
	{
		PlayerController.CurrentPlayer.restartAbilityAvailable = false;
		Debug.Log("Restart ability is disabled");
	}
}
