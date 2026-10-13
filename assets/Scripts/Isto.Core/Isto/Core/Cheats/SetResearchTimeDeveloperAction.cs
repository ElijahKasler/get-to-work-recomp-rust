using Isto.Core.Research;
using UnityEngine;

namespace Isto.Core.Cheats;

[CreateAssetMenu(fileName = "New Set Research Time Action", menuName = "Scriptables/Dev Mode Actions/Set Research Time Action")]
public class SetResearchTimeDeveloperAction : CheatAction
{
	public static readonly float MIN_FUNCTIONAL_RESEARCH_TIME = 0.01f;

	public override void Activate(params object[] args)
	{
		if (float.TryParse(args[0].ToString(), out var result))
		{
			if (result < MIN_FUNCTIONAL_RESEARCH_TIME)
			{
				result = MIN_FUNCTIONAL_RESEARCH_TIME;
			}
			Object.FindObjectOfType<PlayerResearchModule>().ResearchTimeOverride = result;
			return;
		}
		throw new UnityException("Argument error. Useage: SetResearchTime 300.0");
	}

	public override void Deactivate()
	{
	}

	public override void OnUpdate()
	{
	}
}
