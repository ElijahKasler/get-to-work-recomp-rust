using Rewired;
using UnityEngine;

namespace Isto.Core.Cheats;

[CreateAssetMenu(fileName = "New Joystick Sensitivity Override Action", menuName = "Scriptables/Dev Mode Actions/Joystick Sensitivity Override Action")]
public class SetJoystickSensitivity : CheatAction
{
	public override void Activate(params object[] args)
	{
		InputBehavior inputBehavior = ReInput.players.GetPlayer(0).controllers.maps.GetInputBehavior("UI Behavior");
		if (float.TryParse(args[0].ToString(), out var result))
		{
			inputBehavior.joystickAxisSensitivity = result;
		}
	}

	public override void Deactivate()
	{
	}

	public override void OnUpdate()
	{
	}
}
