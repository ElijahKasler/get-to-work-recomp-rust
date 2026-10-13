using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Isto.Core.Game;
using Isto.Core.UI;
using Isto.GTW.Camera;
using Isto.GTW.Configuration;
using Isto.GTW.Leaderboards;
using Isto.GTW.Player;
using UnityEngine;
using Zenject;

namespace Isto.GTW.LevelFeatures;

public class CheckpointManager : MonoBehaviour
{
	[SerializeField]
	private CheckpointData _checkpointData;

	private CheckpointData.LevelCheckpointData _activeCheckpoint;

	private PlayerController _playerController;

	private Vector3 _defaultPlayerPosition = Vector3.zero;

	private Quaternion _defaultPlayerRotation = Quaternion.identity;

	private List<int> _seenCheckpointIds = new List<int>();

	private CanvasGroup _sceneBlackOutCanvas;

	private Coroutine _HideBlackOutAnimationCoroutine;

	private GTWGameState _gameState;

	private UIAccessManager _uiAccessManager;

	private ILeaderboard _leaderboard;

	public CheckpointData CheckpointData => _checkpointData;

	public CheckpointData.LevelCheckpointData StartingCheckpoint => CheckpointData.StartingCheckpoint;

	public int StartingCheckpointId => CheckpointData.startingCheckpointId;

	public PlayerController PlayerController
	{
		get
		{
			return _playerController;
		}
		set
		{
			_playerController = value;
			_defaultPlayerPosition = _playerController.PlayerTransform.position;
			_defaultPlayerRotation = _playerController.PlayerTransform.rotation;
		}
	}

	public PlayerVirtualCameraController PlayerVirtualCameraController => PlayerController.PlayerVirtualCameraController;

	public CheckpointData.LevelCheckpointData ActiveCheckpoint => _activeCheckpoint;

	public int FurthestCheckpointId
	{
		get
		{
			if (_seenCheckpointIds.Count <= 0)
			{
				return -1;
			}
			List<int> seenCheckpointIds = _seenCheckpointIds;
			return seenCheckpointIds[seenCheckpointIds.Count - 1];
		}
	}

	public CheckpointData.LevelCheckpointData FurthestCheckpoint
	{
		get
		{
			if (FurthestCheckpointId >= 0)
			{
				return CheckpointData.levelCheckpointDatas[FurthestCheckpointId];
			}
			return null;
		}
	}

	public event Action OnUpdateAllCheckpointIcons;

	[Inject]
	public void Inject(GTWGameState gameState, PlayerController playerController, UIAccessManager uiAccessManager, ILeaderboard leaderboard)
	{
		_gameState = gameState;
		PlayerController = playerController;
		PlayerController.CheckpointManager = this;
		_uiAccessManager = uiAccessManager;
		_leaderboard = leaderboard;
	}

	private void Start()
	{
		_sceneBlackOutCanvas = _uiAccessManager.GetSingleCanvasGroup(UIAccessManager.CanvasGroupId.SceneBlackOut);
		SetActiveCheckpoint(CheckpointData.StartingCheckpoint);
		if (GameState.GameModeLoadedFromGameState && _gameState.CurrentGameMode != null && _gameState.GameLevelDefinition != null)
		{
			GTWGameLevelDefinition gameLevelDefinition = _gameState.GameLevelDefinition;
			if (!_gameState.StartedWithoutGameMode && gameLevelDefinition.CheckpointNumber > 0 && gameLevelDefinition.CheckpointNumber < CheckpointData.levelCheckpointDatas.Count)
			{
				CheckpointData.LevelCheckpointData checkpoint = CheckpointData.levelCheckpointDatas[gameLevelDefinition.CheckpointNumber];
				SetActiveCheckpoint(checkpoint);
			}
		}
		StartCoroutine(RespawnPlayerWhenDoneLoading());
		_leaderboard.OnCheckpointsDownloaded += OnCheckpointsDownloaded;
		OnUpdateAllCheckpointIcons?.Invoke();
	}

	private void OnCheckpointsDownloaded()
	{
		OnUpdateAllCheckpointIcons?.Invoke();
	}

	private IEnumerator RespawnPlayerWhenDoneLoading()
	{
		PlayerController.ChangeToWaitForSectionLoadingState();
		while (GameState.CurrentlyLoading)
		{
			yield return null;
		}
		bool flag = true;
		if (GameState.LoadingFromSave && _gameState.GameLevelDefinition != null && _gameState.GameLevelDefinition.loadPlayerPositionFromSave)
		{
			flag = false;
		}
		if (flag)
		{
			Respawn();
		}
	}

	public bool SetActiveCheckpoint(CheckpointData.LevelCheckpointData checkpoint, bool idCheck = false)
	{
		int num = (checkpoint.checkpointId = _checkpointData.GetCheckpointId(checkpoint));
		if (!_seenCheckpointIds.Contains(num))
		{
			_seenCheckpointIds.Add(num);
			_seenCheckpointIds.Sort();
		}
		if (idCheck && _activeCheckpoint != null)
		{
			if (num > _checkpointData.GetCheckpointId(_activeCheckpoint))
			{
				_activeCheckpoint = checkpoint;
				OnUpdateAllCheckpointIcons?.Invoke();
				return true;
			}
			OnUpdateAllCheckpointIcons?.Invoke();
			return false;
		}
		_activeCheckpoint = checkpoint;
		OnUpdateAllCheckpointIcons?.Invoke();
		return true;
	}

	public bool SetInactiveCheckpoint(CheckpointData.LevelCheckpointData checkpoint)
	{
		int checkpointId = _checkpointData.GetCheckpointId(checkpoint);
		bool result = _seenCheckpointIds.Remove(checkpointId);
		if (_activeCheckpoint != null && checkpointId == _checkpointData.GetCheckpointId(_activeCheckpoint))
		{
			int index = ((_seenCheckpointIds.Count > 0) ? _seenCheckpointIds.Last() : 0);
			_activeCheckpoint = _checkpointData.levelCheckpointDatas[index];
			Action action = OnUpdateAllCheckpointIcons;
			if (action == null)
			{
				return result;
			}
			action();
		}
		return result;
	}

	public bool IsCheckpointActive(CheckpointData.LevelCheckpointData checkpoint)
	{
		int checkpointId = _checkpointData.GetCheckpointId(checkpoint);
		return _seenCheckpointIds.Contains(checkpointId);
	}

	public List<int> GetSeenCheckpoints()
	{
		return _seenCheckpointIds;
	}

	public bool HasSeenCheckpoint(int id)
	{
		return _seenCheckpointIds.Contains(id);
	}

	public void Respawn(bool showBlackOut = false)
	{
		if (showBlackOut)
		{
			ShowBlackOut();
		}
		if (ActiveCheckpoint != null)
		{
			Debug.Log("Respawning Player at active checkpoint");
			PlayerController.RespawnAtCheckpoint(ActiveCheckpoint);
		}
		else if (!RespawnAtStartingCheckpoint())
		{
			RespawnAtDefaultPosition();
		}
		if (showBlackOut)
		{
			HideBlackOut();
		}
	}

	public bool RespawnAtStartingCheckpoint()
	{
		if (StartingCheckpoint != null)
		{
			Debug.Log("Respawning Player at starting checkpoint");
			SetActiveCheckpoint(StartingCheckpoint);
			PlayerController.RespawnAtCheckpoint(ActiveCheckpoint);
			return true;
		}
		return false;
	}

	public bool RespawnAtDefaultPosition()
	{
		Debug.Log("Respawning Player at default position");
		PlayerController.Respawn();
		PlayerController.TeleportCharacter(_defaultPlayerPosition, _defaultPlayerRotation);
		PlayerController.ResetVelocityToZero();
		PlayerVirtualCameraController.UpdateCamera(instantUpdate: true);
		_playerController.ChangeToWaitForSectionLoadingState();
		return true;
	}

	private void ShowBlackOut()
	{
		_sceneBlackOutCanvas.gameObject.SetActive(value: true);
		_sceneBlackOutCanvas.alpha = 1f;
	}

	private void HideBlackOut()
	{
		_HideBlackOutAnimationCoroutine = StartCoroutine(HideBlackOutAnimation());
	}

	private IEnumerator HideBlackOutAnimation()
	{
		if (_HideBlackOutAnimationCoroutine != null)
		{
			StopCoroutine(_HideBlackOutAnimationCoroutine);
			_HideBlackOutAnimationCoroutine = null;
		}
		yield return new WaitForSeconds(0.1f);
		float alpha = _sceneBlackOutCanvas.alpha;
		while (alpha > 0f)
		{
			alpha -= Time.deltaTime;
			float num = Mathf.InverseLerp(0.5f, 1f, alpha);
			_sceneBlackOutCanvas.alpha = Mathf.Max(0f, alpha);
			PlayerVirtualCameraController.AnimatedCameraPositionOffset = new Vector3(0f, num * 0.2f, 0f);
			yield return null;
		}
		_sceneBlackOutCanvas.gameObject.SetActive(value: false);
		PlayerVirtualCameraController.AnimatedCameraPositionOffset = Vector3.zero;
		_HideBlackOutAnimationCoroutine = null;
	}
}
