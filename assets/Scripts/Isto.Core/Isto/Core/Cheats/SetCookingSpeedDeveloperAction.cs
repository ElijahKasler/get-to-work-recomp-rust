using Isto.Core.Automation;
using UnityEngine;

namespace Isto.Core.Cheats;

[CreateAssetMenu(fileName = "New Set Cooking Speed Action", menuName = "Scriptables/Dev Mode Actions/Set Cooking Speed Action")]
public class SetCookingSpeedDeveloperAction : CheatAction
{
	public override void Activate(params object[] args)
	{
		if (float.TryParse(args[0].ToString(), out var result))
		{
			if (result < 0f)
			{
				result = 0f;
			}
			CraftingQueue craftingQueue = Object.FindObjectOfType<CraftingQueue>();
			if (craftingQueue != null)
			{
				craftingQueue.CookSpeedMultiplier = result;
				return;
			}
			throw new UnityException("Cannot find CraftingQueue in scene. Set Cooking Speed action can only be performed in a running game");
		}
		throw new UnityException("Argument error. Useage: SetCookingSpeed 2.0");
	}

	public override void Deactivate()
	{
	}

	public override void OnUpdate()
	{
	}
}
