using Isto.Core.Cheats;
using Isto.GTW.Player;
using UnityEngine;

namespace Isto.GTW.DeveloperMode.Actions;

[CreateAssetMenu(fileName = "DevMode - Enable Rag Doll Ability Action", menuName = "Scriptables/Dev Mode Actions/Enable Rag Doll Ability Action")]
public class EnableRagDollAbilityAction : CheatAction
{
	public override void Activate(params object[] args)
	{
		bool? flag = ArgToBool(args[0]);
		if (!flag.HasValue)
		{
			throw new UnityException("Argument error. Usage: EnableRagDollAbility True");
		}
		PlayerController.CurrentPlayer.ragDollAbilityAvailable = flag.Value;
		Debug.Log("Rag Doll ability is " + (PlayerController.CurrentPlayer.ragDollAbilityAvailable ? "enabled" : "disabled"));
	}

	public override void OnUpdate()
	{
	}

	public override void Deactivate()
	{
	}
}
