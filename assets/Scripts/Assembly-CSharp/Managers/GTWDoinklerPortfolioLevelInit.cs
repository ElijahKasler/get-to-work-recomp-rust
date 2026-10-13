using System.Collections;
using Isto.Core.Game;
using Isto.GTW;
using Isto.GTW.Configuration;
using Isto.GTW.Managers;
using UnityEngine;
using Zenject;

namespace Managers;

public class GTWDoinklerPortfolioLevelInit : MonoBehaviour
{
	private GTWGameState _gameState;

	private DoinklerLevelVariables _doinklerLevelVariables;

	[Inject]
	public void Inject(GTWGameState gameState, DoinklerLevelVariables levelVariables)
	{
		_gameState = gameState;
		_doinklerLevelVariables = levelVariables;
	}

	private IEnumerator Start()
	{
		while (GameState.WaitingForSaveFileLoad)
		{
			yield return null;
		}
		if (GameState.GameModeLoadedFromGameState && _gameState.CurrentGameMode != null && _gameState.GameLevelDefinition != null)
		{
			GTWGameLevelDefinition gameLevelDefinition = _gameState.GameLevelDefinition;
			int num = _doinklerLevelVariables.GetInt(gameLevelDefinition.UniqueIDAttempts);
			_doinklerLevelVariables.SetInt(gameLevelDefinition.UniqueIDAttempts, num + 1);
		}
	}
}
