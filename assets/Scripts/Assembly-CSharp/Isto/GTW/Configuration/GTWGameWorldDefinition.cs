using System.Collections.Generic;
using I2.Loc;
using UnityEngine;

namespace Isto.GTW.Configuration;

[CreateAssetMenu(fileName = "Scriptables/New GTW Game World Definition", menuName = "Scriptables/New GTW Game World Definition")]
public class GTWGameWorldDefinition : ScriptableObject
{
	public LocalizedString WorldTitle;

	public List<GTWGameLevelDefinition> GameLevels;

	public GTWGameState.SaveSlotId SaveSlotId;

	public bool IsWorldCompleted => GameLevels.TrueForAll((GTWGameLevelDefinition l) => l.IsCompleted);
}
