using I2.Loc;
using Isto.Core.Configuration;
using Isto.Core.Data;
using Isto.Core.Speedrun;
using Isto.Core.UI;
using UnityEngine;
using Zenject;

namespace Isto.GTW.UI;

public class NewGameButton : MonoBehaviour
{
	[SerializeField]
	private GameModeDefinition _gameMode;

	[SerializeField]
	private GTWGameState.SaveSlotId _saveSlot;

	[Header("Save Data Override popup config")]
	[SerializeField]
	private LocalizedString _title;

	[SerializeField]
	private LocalizedString _description;

	[SerializeField]
	private LocalizedString _question;

	[Header("Speedrun Settings for Main Gameplay")]
	[SerializeField]
	private SpeedrunSettings _mainGameSpeedrunSettings;

	private GTWGameState _gameState;

	private IGameData _gameData;

	private UIModalChoicePopup _choicePopup;

	[Inject]
	public void Inject(IGameData gameData, GTWGameState gameState, UIModalChoicePopup choicePopup)
	{
		_gameState = gameState;
		_gameData = gameData;
		_choicePopup = choicePopup;
	}

	public void Button_OnClick()
	{
		_gameState.GameLevelDefinition = null;
		RebindSpeedrunSettings();
		int saveSlot = (int)_saveSlot;
		_gameData.HasSaveData(saveSlot, (bool dataExists) =>
		{
			if (dataExists)
			{
				ShowOverridePopup();
			}
			else
			{
				StartGame();
			}
		});
	}

	private void OnModalChoicePopup_Yes()
	{
		int saveSlot = (int)_saveSlot;
		_gameState.LoadSaveSlotMetaData(saveSlot, (bool gameStateData) =>
		{
			StartGame();
		});
	}

	private void OnModalChoicePopup_No()
	{
	}

	private void ShowOverridePopup()
	{
		_choicePopup.DisplayChoice(UIModalChoicePopup.ChoicePopupType.YesNoChoice, _question, OnModalChoicePopup_Yes, OnModalChoicePopup_No, _description, _title);
	}

	private void StartGame()
	{
		_gameState.SaveSlot = (int)_saveSlot;
		_gameState.StartGameMode(_gameMode);
	}

	private void RebindSpeedrunSettings()
	{
		DiContainer container = ProjectContext.Instance.Container;
		container.Rebind(typeof(SpeedrunSettings)).FromInstance(_mainGameSpeedrunSettings).AsCached()
			.NonLazy();
		container.Inject(_gameData);
	}
}
