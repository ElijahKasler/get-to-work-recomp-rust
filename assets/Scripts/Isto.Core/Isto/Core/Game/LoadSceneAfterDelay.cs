using Isto.Core.Inputs;
using Isto.Core.Localization;
using Isto.Core.Scenes;
using UnityEngine;
using Zenject;

namespace Isto.Core.Game;

public class LoadSceneAfterDelay : MonoBehaviour
{
	[SerializeField]
	private float _delay = 5f;

	[SerializeField]
	private float _delayOnXbox = 10f;

	[SerializeField]
	[SceneReference]
	private string _sceneToLoad;

	[SerializeField]
	[SceneReference]
	private string _sceneToLoadOnXbox;

	[SerializeField]
	private bool _allowCancel;

	[SerializeField]
	private bool _forceEnglish;

	private GameState _gameState;

	private IControls _controls;

	[Inject]
	public void Inject(GameState gameState, IControls controls)
	{
		_gameState = gameState;
		_controls = controls;
	}

	protected void OnEnable()
	{
		float delay = _delay;
		Invoke("LoadScene", delay);
		if (_controls != null)
		{
			_controls.SetControlMode(Controls.Mode.UI);
		}
		if (_forceEnglish)
		{
			LanguageChanger.SetLanguage(LanguageChanger.LanguageEnum.ENGLISH);
		}
	}

	protected void OnDisable()
	{
		CancelInvoke();
	}

	protected void Update()
	{
		if (_allowCancel && _controls != null && _controls.GetButton(UserActions.UICANCEL))
		{
			CancelInvoke();
			LoadScene();
		}
	}

	private void LoadScene()
	{
		Time.timeScale = 1f;
		string sceneToLoad = _sceneToLoad;
		_gameState.LoadScene(sceneToLoad);
	}
}
