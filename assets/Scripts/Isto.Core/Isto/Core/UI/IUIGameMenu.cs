namespace Isto.Core.UI;

public interface IUIGameMenu : IUIMenu
{
	void EnterCutSceneState();

	void ExitCutSceneState();

	void HideHUD(float fadeTime);

	void ShowHUD(float fadeTime);
}
