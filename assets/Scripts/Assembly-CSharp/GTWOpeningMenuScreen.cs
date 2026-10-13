using System;
using I2.Loc;
using Isto.Core.Data;
using Isto.Core.Game;
using Isto.Core.Inputs;
using Isto.Core.Scenes;
using Isto.Core.UI;
using Rewired;
using UnityEngine;
using Zenject;

public class GTWOpeningMenuScreen : MonoBehaviour
{
	[Header("Go To Title Menu")]
	[SerializeField]
	[SceneReference]
	private string _sceneToLoad;

	[SerializeField]
	private CanvasGroup _uiGroup;

	[SerializeField]
	private float _fadeTime = 0.5f;

	[Header("Reset Controls to Defaults")]
	[SerializeField]
	private UISimpleConfirmModalState _resetToDefaultsSubState;

	[SerializeField]
	private LocalizedString _mappingsResetConfirmKey;

	private GameState _gameState;

	private IControls _controls;

	private UserKeybindingDataStore _bindingData;

	[Inject]
	public void Inject(GameState gameState, IControls controls, UserKeybindingDataStore bindingData)
	{
		_gameState = gameState;
		_controls = controls;
		_bindingData = bindingData;
	}

	private void Update()
	{
		if (_controls.GetStartGameAction())
		{
			StartCoroutine(UIUtils.FadeOutAndDisableCanvas(_uiGroup, _fadeTime, base.gameObject.GetComponent<Canvas>()));
			Invoke("LoadMenuScene", _fadeTime);
		}
		else if (_controls.GetResetMappingsButtonDown())
		{
			ResetButtonConfig();
			ShowResetMappingsPopup();
		}
	}

	private void LoadMenuScene()
	{
		Time.timeScale = 1f;
		_gameState.LoadScene(_sceneToLoad);
	}

	private void ResetButtonConfig()
	{
		Player player = ReInput.players.GetPlayer(Controls.DEFAULT_REWIRED_PLAYER_ID);
		foreach (ControllerType value in Enum.GetValues(typeof(ControllerType)))
		{
			player.controllers.maps.LoadDefaultMaps(value);
		}
		_bindingData.Save();
	}

	private void ShowResetMappingsPopup()
	{
		_resetToDefaultsSubState.SetMainText(_mappingsResetConfirmKey.ToString());
		_resetToDefaultsSubState.Enter(null);
		_resetToDefaultsSubState.SetDefaultSelection();
	}
}
