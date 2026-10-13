using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using FMODUnity;
using Isto.Core.Audio;
using Isto.Core.Beings;
using Isto.Core.Cameras;
using Isto.Core.Configuration;
using Isto.Core.Data;
using Isto.Core.Game;
using Isto.Core.Inputs;
using Isto.Core.UI;
using UnityEngine;
using Zenject;

namespace Isto.Core.Items;

public class BuildingFirstConnectAction : GameProgressAction
{
	[SerializeField]
	private CinemachineVirtualCamera _focusCamera;

	[SerializeField]
	[EventRef]
	private string _buildingCinematicAudioRef;

	private IControls _controls;

	private CameraController _cameraController;

	private AutomationPlayerController _playerController;

	private IUIGameMenu _mainMenu;

	private IGameSounds _sounds;

	private List<CanvasGroup> _uiToHide;

	[Inject]
	public void Inject(IControls controls, CameraController cameraController, UIAccessManager uiAccessor, AutomationPlayerController playerController, IUIGameMenu mainMenu, IGameSounds gameSounds, GameplaySettings gameplaySettings)
	{
		_controls = controls;
		_cameraController = cameraController;
		_uiToHide = uiAccessor.GetCanvasGroups(UIAccessManager.CanvasGroupId.UIInitial);
		_playerController = playerController;
		_mainMenu = mainMenu;
		_sounds = gameSounds;
		_actionCompleted = !gameplaySettings.showBuildingConnectAnimations;
	}

	public override GameProgressData GetSaveData()
	{
		return new GameProgressData(actionID)
		{
			completed = _actionCompleted
		};
	}

	public override void LoadData(GameProgressData data)
	{
		_actionCompleted = data.completed;
	}

	public override void RegisterForEvents()
	{
	}

	public override void UnregisterForEvents()
	{
	}

	[ContextMenu("Start turn on Routine")]
	public void TriggerTurnOnRoutine()
	{
		StartCoroutine(BuildingTurnOnRoutine());
	}

	public IEnumerator BuildingTurnOnRoutine()
	{
		_mainMenu.EnterCutSceneState();
		GameState.StoryAnimationActive = true;
		SetCanvasValues(visible: false);
		if (!string.IsNullOrEmpty(_buildingCinematicAudioRef))
		{
			_sounds.PlayOneShot(_buildingCinematicAudioRef, Vector3.zero);
		}
		_playerController.PlaceAdvItemState.ForceCancelDrop();
		_playerController.SetCharacterIdle();
		_controls.SetControlMode(Controls.Mode.Disabled);
		if (_focusCamera != null)
		{
			_cameraController.SwitchToCamera(_focusCamera);
		}
		_cameraController.HideLayers(hide: true);
		yield return new WaitForSeconds(4f);
		_cameraController.HideLayers(hide: false);
		_cameraController.SetCameraFollowPlayer();
		_controls.SetControlMode(Controls.Mode.Gameplay);
		SetCanvasValues(visible: true);
		GameState.StoryAnimationActive = false;
		_mainMenu.ExitCutSceneState();
		_actionCompleted = true;
	}

	private void SetCanvasValues(bool visible)
	{
		for (int i = 0; i < _uiToHide.Count; i++)
		{
			StartCoroutine(UIUtils.SetCanvasAlpha(_uiToHide[i], visible ? 1 : 0, Constants.CANVAS_FADE_TIME, visible));
		}
	}
}
