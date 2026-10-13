using UnityEngine;

namespace PixelCrushers;

[AddComponentMenu("")]
public class SaveSystemMethods : MonoBehaviour
{
	[Tooltip("Scene to load in LoadOrRestart method if no saved game exists yet.")]
	public string defaultStartingSceneName;

	public void SaveSlot(int slotNumber)
	{
		SaveSystem.SaveToSlot(slotNumber);
	}

	public void LoadFromSlot(int slotNumber)
	{
		SaveSystem.LoadFromSlot(slotNumber);
	}

	public void LoadScene(string sceneNameAndSpawnpoint)
	{
		SaveSystem.LoadScene(sceneNameAndSpawnpoint);
	}

	public void RestartGame(string startingSceneName)
	{
		SaveSystem.RestartGame(startingSceneName);
	}

	public void LoadOrRestart(int slotNumber)
	{
		if (SaveSystem.HasSavedGameInSlot(slotNumber))
		{
			SaveSystem.LoadFromSlot(slotNumber);
		}
		else
		{
			SaveSystem.RestartGame(defaultStartingSceneName);
		}
	}

	public void DeleteSavedGameInSlot(int slotNumber)
	{
		SaveSystem.DeleteSavedGameInSlot(slotNumber);
	}

	public void RecordSavedGameData()
	{
		SaveSystem.RecordSavedGameData();
	}

	public void ApplySavedGameData()
	{
		SaveSystem.ApplySavedGameData();
	}

	public void LoadAdditiveScene(string sceneName)
	{
		SaveSystem.LoadAdditiveScene(sceneName);
	}

	public void UnloadAdditiveScene(string sceneName)
	{
		SaveSystem.UnloadAdditiveScene(sceneName);
	}
}
