using Isto.Core.Research;
using UnityEngine;

namespace Isto.Core.Cheats;

[CreateAssetMenu(fileName = "New Set Research Tree Complete Action", menuName = "Scriptables/Dev Mode Actions/Set Research Tree Complete Action")]
public class SetResearchTreeCompleteDeveloperAction : CheatAction
{
	public override void Activate(params object[] args)
	{
		bool? flag = ArgToBool(args[0]);
		if (!flag.HasValue)
		{
			throw new UnityException("Argument error. Useage: SetResearchTreeComplete True");
		}
		PlayerResearchModule playerResearchModule = Object.FindObjectOfType<PlayerResearchModule>();
		if (flag.Value)
		{
			playerResearchModule.CompleteAllResearch();
		}
		else
		{
			playerResearchModule.DeleteAllResearch();
		}
	}

	public override void Deactivate()
	{
	}

	public override void OnUpdate()
	{
	}

	public override bool TryAutoCompleteParameters(string[] inputs, out string output)
	{
		return TryAutoCompleteBoolean(inputs, out output);
	}
}
