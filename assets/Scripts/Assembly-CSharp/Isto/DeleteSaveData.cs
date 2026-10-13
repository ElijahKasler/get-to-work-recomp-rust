using Isto.Core.Data;
using Isto.GTW;
using UnityEngine;
using Zenject;

namespace Isto;

public class DeleteSaveData : MonoBehaviour
{
	private IGameData _gameData;

	private GTWGameState _gameState;

	[Inject]
	public void Inject(IGameData gameData, GTWGameState gameState)
	{
		_gameData = gameData;
		_gameState = gameState;
	}

	public void DeleteAllSaveData()
	{
		PlayerPrefs.DeleteAll();
		_gameData.ClearAllSaveData(DoneDeletingData);
	}

	private void DoneDeletingData(bool success)
	{
		_gameState.LoadTitleScene();
	}
}
