using System.Collections;
using Isto.Core;
using Isto.Core.Beings;
using Isto.Core.Data;
using Isto.Core.Game;
using Isto.GTW.Leaderboards;
using UnityEngine;
using Zenject;

namespace Isto.GTW.LevelFeatures.LevelEvents;

public class ActivateCheckpointEvent : LevelEvent
{
	[SerializeField]
	private Color _gizmoColor = new Color(0.5f, 0f, 0.65f, 0.5f);

	[SerializeField]
	private Checkpoint _checkpoint;

	[SerializeField]
	private bool _idCheck;

	[SerializeField]
	private float _deactivationOffsetY;

	[SerializeField]
	private bool _updateLeaderboard;

	private CheckpointData.LevelCheckpointData _checkpointData;

	private ILeaderboard _leaderboard;

	private CheckpointManager _checkpointManager;

	private BoxCollider _collider;

	private IGameData _gameData;

	private GTWGameState _gameState;

	private IPlayerController _playerController;

	private float DeactivationHeight
	{
		get
		{
			BoxCollider collider = Collider;
			if (collider == null)
			{
				return base.transform.position.y + _deactivationOffsetY;
			}
			return base.transform.position.y + _deactivationOffsetY + collider.center.y - collider.size.y * 0.5f;
		}
	}

	private BoxCollider Collider
	{
		get
		{
			if (_collider == null)
			{
				_collider = GetComponent<BoxCollider>();
			}
			return _collider;
		}
	}

	[Inject]
	public void Inject(CheckpointManager checkpointManager, IGameData gameData, GTWGameState gameState, IPlayerController playerController, ILeaderboard leaderboard)
	{
		_checkpointManager = checkpointManager;
		_gameData = gameData;
		_gameState = gameState;
		_playerController = playerController;
		_leaderboard = leaderboard;
	}

	protected override void Awake()
	{
		base.Awake();
		_checkpointData = _checkpoint.ToLevelCheckpointData();
	}

	private void Update()
	{
		if (!GameState.CurrentlyLoading && _checkpointManager.IsCheckpointActive(_checkpointData) && _playerController.GetPlayerPosition().y < DeactivationHeight)
		{
			Debug.Log($"Deactivating checkpoint #{_checkpointManager.CheckpointData.GetCheckpointId(_checkpointData)}");
			_checkpointManager.SetInactiveCheckpoint(_checkpointData);
			StartCoroutine(AutoSave());
		}
	}

	private void OnDrawGizmosSelected()
	{
		Vector3 center = new Vector3(base.transform.position.x, DeactivationHeight, base.transform.position.z);
		Vector3 size = new Vector3(10000f, 0.05f, 10000f);
		Color color = Gizmos.color;
		Gizmos.color = _gizmoColor;
		Gizmos.DrawCube(center, size);
		Gizmos.color = color;
	}

	public override void TriggerEvent(bool initialization = false)
	{
		Debug.Log($"Activating checkpoint #{_checkpointManager.CheckpointData.GetCheckpointId(_checkpointData)}");
		if (_checkpointManager.SetActiveCheckpoint(_checkpointData, _idCheck))
		{
			StartCoroutine(AutoSave());
			if (_gameState.IsDoinklerSpecial)
			{
				_leaderboard.UploadHighestCheckpoint(_checkpointData.checkpointId);
			}
		}
		if (_updateLeaderboard)
		{
			_leaderboard.DownloadFriendsEntries(5f);
		}
	}

	private IEnumerator AutoSave()
	{
		Debug.Log("ActivateCheckpointEvent.AutoSave()");
		Events.RaiseEvent("GameAutoSaving");
		yield return null;
		int slotNumber = _gameState.SaveSlot;
		_gameState.SelectSaveGame(slotNumber);
		_gameState.LoadGameStateData(null, -1);
		_gameData.SaveGameData(slotNumber, createBackup: false, (bool success) =>
		{
			if (success)
			{
				Events.RaiseEvent("GameSaved");
				_gameState.LoadSaveSlotMetaData(slotNumber, null);
			}
			else
			{
				Debug.LogError($"SaveGameData for slot#{slotNumber} has failed ");
			}
		});
	}

	[ContextMenu("Set to Tower Checkpoint")]
	private void SetToTowerLevelCheckpoint()
	{
		_idCheck = true;
		_deactivationOffsetY = 0f;
	}

	[ContextMenu("Set to Challenger Checkpoint")]
	private void SetToChallengerCheckpoint()
	{
		_idCheck = true;
		_deactivationOffsetY = float.MinValue;
	}

	[ContextMenu("Set to Challenger Tower Checkpoint")]
	private void SetToChallengerTowerCheckpoint()
	{
		_idCheck = false;
		_deactivationOffsetY = float.MinValue;
	}
}
