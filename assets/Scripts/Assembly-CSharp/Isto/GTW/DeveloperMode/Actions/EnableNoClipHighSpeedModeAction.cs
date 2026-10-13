using Isto.Core.Cheats;
using Isto.GTW.Player;
using UnityEngine;

namespace Isto.GTW.DeveloperMode.Actions;

[CreateAssetMenu(fileName = "DevMode - Enable No Clip High Speed Mode Action", menuName = "Scriptables/Dev Mode Actions/Enable No Clip High Speed Mode Action")]
public class EnableNoClipHighSpeedModeAction : CheatAction
{
	public override void Activate(params object[] args)
	{
		bool? flag = ArgToBool(args[0]);
		if (!flag.HasValue)
		{
			throw new UnityException("Argument error. Usage: NoClipHighSpeedMode True");
		}
		PlayerController.CurrentPlayer.noClipHighSpeedMode = flag.Value;
		Debug.Log("No clip high speed is " + (PlayerController.CurrentPlayer.noClipHighSpeedMode ? "enabled" : "disabled"));
	}

	public override void OnUpdate()
	{
	}

	public override void Deactivate()
	{
		PlayerController.CurrentPlayer.noClipHighSpeedMode = false;
		Debug.Log("No clip high speed is disabled");
	}
}
