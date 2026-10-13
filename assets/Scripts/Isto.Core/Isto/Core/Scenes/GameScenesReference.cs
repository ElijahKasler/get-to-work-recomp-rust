using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Isto.Core.Scenes;

[CreateAssetMenu(fileName = "CoreGameScenesReference", menuName = "Scriptables/Tools/Core Game Scenes Reference")]
public class GameScenesReference : ScriptableObject
{
	[SerializeField]
	[SceneReference]
	protected string _applicationStartup = "0ApplicationStartup";

	[SerializeField]
	[SceneReference]
	protected string _titleScreen = "1TitleScreen";

	[SerializeField]
	[SceneReference]
	protected string _loadingScreen = "3Loading";

	[SerializeField]
	[SceneReference]
	protected string _essentialsScene = "EssentialGameElementsScene";

	[SerializeField]
	[SceneReference]
	protected string _startingAreaScene = "4Story-Mode";

	public virtual string ApplicationStartup => _applicationStartup;

	public virtual string TitleScreen => _titleScreen;

	public virtual string LoadingScreen => _loadingScreen;

	public virtual string EssentialsScene => _essentialsScene;

	public virtual string StartingAreaScene => _startingAreaScene;

	public virtual HashSet<string> DialogueScenes { get; protected set; }

	public bool IsDialogueScene(string sceneName)
	{
		return DialogueScenes.Contains(sceneName);
	}

	public virtual string GetCurrentSceneName()
	{
		string result = "";
		for (int i = 0; i < SceneManager.sceneCount; i++)
		{
			if (SceneManager.GetSceneAt(i).name != EssentialsScene)
			{
				result = SceneManager.GetSceneAt(i).name;
				break;
			}
		}
		return result;
	}
}
