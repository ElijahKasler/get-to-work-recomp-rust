using System.Collections.Generic;
using Isto.Core.Achievements;
using Isto.Core.Enums;
using UnityEngine;
using Zenject;

namespace Isto.Core.Cheats;

[CreateAssetMenu(fileName = "New Unlock Achievement Action", menuName = "Scriptables/Dev Mode Actions/Player Unlock Achievement Action")]
public class UnlockAchievementDeveloperAction : CheatAction
{
	public override void Activate(params object[] args)
	{
		string text = args[0].ToString();
		if (!ExpandableEnum<Int32Enum<IAchievements.CoreAchievementsEnum>, int>.TryParse(text, ignoreCase: true, out var result))
		{
			throw new UnityException("Achievement " + text + " could not be parsed into a IAchievements.CoreAchievementsEnum value");
		}
		Object.FindObjectOfType<ProjectContext>().Container.Resolve<IAchievements>().TriggerAchievement(result as IAchievements.CoreAchievementsEnum);
	}

	public override void Deactivate()
	{
	}

	public override void OnUpdate()
	{
	}

	public override bool TryAutoCompleteParameters(string[] inputs, out string output)
	{
		List<string> validOutputs = new List<string>(ExpandableEnum<Int32Enum<IAchievements.CoreAchievementsEnum>, int>.GetAllNames());
		return TryAutoCompleteFromList(inputs, validOutputs, out output);
	}
}
