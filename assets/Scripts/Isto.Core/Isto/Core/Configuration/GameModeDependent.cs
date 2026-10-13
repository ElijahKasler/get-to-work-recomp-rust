using System.Collections.Generic;
using Isto.Core.Game;
using UnityEngine;
using Zenject;

namespace Isto.Core.Configuration;

public class GameModeDependent : MonoBehaviour
{
	public List<GameModeDefinition> compatibleGameModes;

	[Header("Testing utilities")]
	[Tooltip("Incompatible object will destroy itself at injection stage as if current game mode was not in compatible list")]
	public bool forceIncompatible;

	[Inject]
	public void Inject(GameState gameState)
	{
		if (!forceIncompatible && gameState.CurrentGameMode == null)
		{
			Debug.LogWarning("Game Mode Dependent object \"" + base.gameObject.name + "\" exists by default because Current Game Mode is null", this);
		}
		else if (forceIncompatible || (compatibleGameModes != null && !compatibleGameModes.Contains(gameState.CurrentGameMode)))
		{
			if (forceIncompatible)
			{
				Debug.LogWarning("Game Mode Dependent object \"" + base.gameObject.name + "\" forced to not exist");
			}
			Object.Destroy(base.gameObject);
		}
	}
}
