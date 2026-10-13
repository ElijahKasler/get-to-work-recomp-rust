using System.Collections;
using Isto.Core;
using Isto.Core.Audio;
using Isto.Core.Data;
using Isto.Core.UI;
using Isto.GTW.Audio;
using Isto.GTW.Configuration;
using Isto.GTW.Player;
using Isto.GTW.Providers;
using Isto.GTW.UI;
using UnityEngine;
using Zenject;

namespace Isto.GTW.LevelFeatures.LevelEvents;

public class LevelTransitionPopupEvent : LevelEvent
{
	[SerializeField]
	private GTWGameLevelDefinition _currentLevel;

	[SerializeField]
	private GTWGameLevelDefinition _nextLevel;

	[SerializeField]
	private GameObject _cashParticleSystem;

	[SerializeField]
	private GameObject _glassCapsule;

	[SerializeField]
	private float _popupDelay = 3f;

	private GTWUINextLevelPopup _nextLevelPopup;

	private PlayerController _playerController;

	private SimpleGameMenuStateMachine _gameMenuStateMachine;

	private GTWGameState _gameState;

	private IGameData _gameData;

	protected GTWGameSounds _sounds;

	private IDoinklerWorldDefinitionProvider _doinklerWorldDefinitionProvider;

	private Coroutine _levelCompletedCoroutine;

	public GTWGameLevelDefinition CurrentLevel => _currentLevel;

	[Inject]
	public void Inject(GTWUINextLevelPopup nextLevelPopup, SimpleGameMenuStateMachine gameMenuStateMachine, PlayerController playerController, GTWGameState gameState, IGameData gameData, IGameSounds sounds, IDoinklerWorldDefinitionProvider doinklerWorldDefinitionProvider)
	{
		_gameMenuStateMachine = gameMenuStateMachine;
		_nextLevelPopup = nextLevelPopup;
		_playerController = playerController;
		_gameState = gameState;
		_gameData = gameData;
		_sounds = sounds as GTWGameSounds;
		_doinklerWorldDefinitionProvider = doinklerWorldDefinitionProvider;
	}

	public override void TriggerEvent(bool initialization = false)
	{
		if (base.IsTriggerEventValid && !_nextLevelPopup.IsOpen)
		{
			Events.RaiseEvent(GTWEvents.DOINKLER_STAGE_COMPLETE);
			_levelCompletedCoroutine = StartCoroutine(LevelCompleted());
		}
	}

	private IEnumerator LevelCompleted()
	{
		foreach (GTWGameLevelDefinition gameLevel in _doinklerWorldDefinitionProvider.Current.GameLevels)
		{
			if (_currentLevel.UniqueID == gameLevel.UniqueID)
			{
				_currentLevel = gameLevel;
				break;
			}
		}
		_currentLevel.IsCompleted = true;
		if (_levelCompletedCoroutine != null)
		{
			StopCoroutine(_levelCompletedCoroutine);
			_levelCompletedCoroutine = null;
		}
		_cashParticleSystem.SetActive(value: true);
		_glassCapsule.SetActive(value: false);
		_playerController._freezeControlsState.ForceBrake = true;
		_playerController._freezeControlsState.ForceGrabAbility = false;
		_playerController.ChangeToFreezeControlsState();
		yield return new WaitForSeconds(_popupDelay);
		_playerController.ChangeToMoveState();
		_cashParticleSystem.SetActive(value: false);
		_glassCapsule.SetActive(value: true);
		_nextLevelPopup.SetLevelDefinitionData(_currentLevel, _nextLevel, ModalPopup_OnPlayerRespawn);
		_gameMenuStateMachine.EnterSubState(_nextLevelPopup);
		yield return null;
		_levelCompletedCoroutine = null;
	}

	protected virtual void ModalPopup_OnPlayerRespawn()
	{
		SetTriggered(triggered: false);
	}
}
