using System;
using Rewired.Integration.UnityUI;
using UnityEngine;

namespace Isto.Core.Cheats;

[CreateAssetMenu(fileName = "New UI Repeat Rate Override Action", menuName = "Scriptables/Dev Mode Actions/UI Repeat Rate Override Action")]
public class SetUIRepeatRate : CheatAction
{
	public override void Activate(params object[] args)
	{
		RewiredStandaloneInputModule rewiredStandaloneInputModule = UnityEngine.Object.FindObjectOfType<RewiredStandaloneInputModule>();
		if (float.TryParse(args[0].ToString(), out var result))
		{
			rewiredStandaloneInputModule.inputActionsPerSecond = result;
		}
		if (float.TryParse(args[1].ToString(), out var result2))
		{
			rewiredStandaloneInputModule.repeatDelay = result2;
		}
	}

	public override void Deactivate()
	{
		throw new NotImplementedException();
	}

	public override void OnUpdate()
	{
		throw new NotImplementedException();
	}
}
