using Isto.Core.Cheats;
using Isto.GTW.Player;
using UnityEngine;

namespace Isto.GTW.DeveloperMode.Actions;

[CreateAssetMenu(fileName = "DevMode - Enable No Clip Ability Action", menuName = "Scriptables/Dev Mode Actions/Enable No Clip Ability Action")]
public class EnableNoClipAbilityAction : CheatAction
{
	public override void Activate(params object[] args)
	{
		bool? flag = ArgToBool(args[0]);
		if (!flag.HasValue)
		{
			throw new UnityException("Argument error. Usage: EnableNoClipAbility True");
		}
		PlayerController.CurrentPlayer.noClipAbilityAvailable = flag.Value;
		Debug.Log("No clip ability is " + (PlayerController.CurrentPlayer.noClipAbilityAvailable ? "enabled" : "disabled"));
	}

	public override void OnUpdate()
	{
	}

	public override void Deactivate()
	{
		PlayerController.CurrentPlayer.noClipAbilityAvailable = false;
		Debug.Log("No clip ability is disabled");
	}
}
