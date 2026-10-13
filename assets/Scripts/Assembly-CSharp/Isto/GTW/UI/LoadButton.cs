using Isto.Core.Data;
using Isto.Core.Speedrun;
using Isto.Core.UI;
using Isto.Core.UI.ButtonStyles;
using ModestTree;
using UnityEngine;
using Zenject;

namespace Isto.GTW.UI;

public class LoadButton : MonoBehaviour
{
	[SerializeField]
	private CoreButton _loadButton;

	[SerializeField]
	private CoreButtonTMPColor _loadButtonTextStates;

	[SerializeField]
	private SpeedrunSettings _mainGameSpeedrunSettings;

	[SerializeField]
	private ColorStyleRef _disabledButtonStyle;

	private ColorStyleRef _defaultbuttonStyle;

	private GTWGameState _gameState;

	private IGameData _gameData;

	[Inject]
	public void Inject(GTWGameState gameState, IGameData gameData)
	{
		_gameState = gameState;
		_gameData = gameData;
	}

	private void Awake()
	{
		_defaultbuttonStyle = _loadButtonTextStates.style as ColorStyleRef;
		Assert.That(_defaultbuttonStyle != null, "LoadButton color style could not be found!");
	}

	public void LoadFirstSlot()
	{
		if (!IsInteractable())
		{
			return;
		}
		_gameState.GameLevelDefinition = null;
		RebindSpeedrunSettings();
		int saveSlot = 0;
		_gameData.HasSaveData(saveSlot, (bool dataExists) =>
		{
			if (dataExists)
			{
				_gameState.LoadSaveSlotMetaData(saveSlot, (bool gameStateData) =>
				{
					_gameState.LoadSaveGame(saveSlot);
				});
			}
		});
	}

	private void RebindSpeedrunSettings()
	{
		DiContainer container = ProjectContext.Instance.Container;
		container.Rebind(typeof(SpeedrunSettings)).FromInstance(_mainGameSpeedrunSettings).AsCached()
			.NonLazy();
		container.Inject(_gameData);
	}

	public bool IsInteractable()
	{
		return _loadButtonTextStates.style == _defaultbuttonStyle;
	}

	public void MakeInteractable(bool interactable)
	{
		if (interactable)
		{
			_loadButtonTextStates.SetStyle(_defaultbuttonStyle);
		}
		else
		{
			_loadButtonTextStates.SetStyle(_disabledButtonStyle);
		}
	}
}
