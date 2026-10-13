using Isto.Core.Configuration;
using Isto.Core.Game;
using UnityEngine;
using Zenject;

public class LoadGameModeButton : MonoBehaviour
{
	[SerializeField]
	private GameModeDefinition _gameMode;

	private GameState _gameState;

	[Inject]
	public void Inject(GameState gameState)
	{
		_gameState = gameState;
	}

	public void LoadGameMode()
	{
		_gameState.StartGameMode(_gameMode);
	}
}
