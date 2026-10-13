using System.Collections.Generic;
using Isto.GTW.DebugTools;
using Isto.GTW.Player;
using Isto.GTW.UI;
using UnityEngine;
using Zenject;

namespace Isto.GTW.LevelFeatures;

public class Checkpoint : MonoBehaviour
{
	public enum CheckpointIconState
	{
		NEVER_SEEN = 0,
		ALREADY_REACHED = 1,
		CURRENT = 2,
		PREVIOUS = 3
	}

	[Tooltip("Forward (Z) axis used for spawn rotation.")]
	[SerializeField]
	private Transform _spawnPosition;

	[SerializeField]
	private bool _spawnOnGround = true;

	[SerializeField]
	private bool _showInSpeedrunTimer = true;

	[Header("State Visuals")]
	[SerializeField]
	private GameObject _neverReached;

	[SerializeField]
	private GameObject _reachedBefore;

	[SerializeField]
	private GameObject _current;

	[SerializeField]
	private GameObject _previous;

	[Space]
	[SerializeField]
	private GameObject _furthest;

	[Header("State Transitions")]
	[SerializeField]
	private GameObject _neverReachedToCurrent;

	[SerializeField]
	private GameObject _reachedBeforeOrPreviousToCurrent;

	private CheckpointIconState _iconState;

	private UIDoinklerLeaderboardCheckpoint _uiDoinklerLeaderboardCheckpoint;

	private CheckpointManager _checkpointManager;

	private PlayerController _playerController;

	public string CheckpointName => base.gameObject.name;

	public int CheckpointId { get; private set; } = -1;

	public string SceneName => base.gameObject.scene.name;

	public CheckpointManager CheckpointManager => _checkpointManager;

	public UIDoinklerLeaderboardCheckpoint UiDoinklerLeaderboardCheckpoint => _uiDoinklerLeaderboardCheckpoint;

	[Inject]
	public void Inject(CheckpointManager checkpointManager, PlayerController playerController)
	{
		_checkpointManager = checkpointManager;
		_playerController = playerController;
	}

	private void Awake()
	{
		_uiDoinklerLeaderboardCheckpoint = GetComponentInChildren<UIDoinklerLeaderboardCheckpoint>();
		CheckpointId = CheckpointManager.CheckpointData.GetCheckpointId(this);
		CheckpointManager.OnUpdateAllCheckpointIcons += UpdateCheckpointState;
		UpdateCheckpointState();
	}

	private void OnDestroy()
	{
		CheckpointManager.OnUpdateAllCheckpointIcons -= UpdateCheckpointState;
	}

	private void Reset()
	{
		_spawnPosition = base.transform;
	}

	private void OnDrawGizmos()
	{
		Gizmos.DrawIcon(base.transform.position, "Checkpoint", allowScaling: true, Color.red);
	}

	private void OnDrawGizmosSelected()
	{
		DebugExtensions.DrawArrow(base.transform.position, 0.3f, base.transform.forward, Color.red);
	}

	public CheckpointData.LevelCheckpointData ToLevelCheckpointData()
	{
		return new CheckpointData.LevelCheckpointData
		{
			checkpointName = CheckpointName,
			sceneName = SceneName,
			checkpointId = CheckpointId,
			position = _spawnPosition.position,
			forward = _spawnPosition.forward,
			spawnOnGround = _spawnOnGround,
			showInSpeedrunTimer = _showInSpeedrunTimer
		};
	}

	public void UpdateCheckpointState()
	{
		if (CheckpointManager.ActiveCheckpoint != null)
		{
			CheckpointIconState checkpointIconState = CheckpointIconState.CURRENT;
			checkpointIconState = ((CheckpointId == CheckpointManager.ActiveCheckpoint.checkpointId) ? CheckpointIconState.CURRENT : (CheckpointManager.HasSeenCheckpoint(CheckpointId) ? ((CheckpointId > CheckpointManager.ActiveCheckpoint.checkpointId) ? CheckpointIconState.ALREADY_REACHED : CheckpointIconState.PREVIOUS) : CheckpointIconState.NEVER_SEEN));
			UpdateCheckpointState(checkpointIconState);
			if (UiDoinklerLeaderboardCheckpoint != null)
			{
				UiDoinklerLeaderboardCheckpoint.UpdateLeaderboard();
			}
		}
	}

	private void UpdateCheckpointState(CheckpointIconState newState)
	{
		CheckpointIconState iconState = _iconState;
		_iconState = newState;
		if (_reachedBeforeOrPreviousToCurrent != null)
		{
			_reachedBeforeOrPreviousToCurrent.SetActive(value: false);
		}
		if (iconState == CheckpointIconState.NEVER_SEEN && newState == CheckpointIconState.CURRENT)
		{
			NeverReachedToCurrent();
		}
		else if ((iconState == CheckpointIconState.ALREADY_REACHED || iconState == CheckpointIconState.PREVIOUS) && newState == CheckpointIconState.CURRENT)
		{
			AlreadyReachedOrPreviousToCurrent();
		}
		if (_neverReached != null)
		{
			_neverReached.SetActive(_iconState == CheckpointIconState.NEVER_SEEN);
		}
		if (_reachedBefore != null)
		{
			_reachedBefore.SetActive(_iconState == CheckpointIconState.ALREADY_REACHED);
		}
		if (_current != null)
		{
			_current.SetActive(_iconState == CheckpointIconState.CURRENT);
		}
		if (_previous != null)
		{
			_previous.SetActive(_iconState == CheckpointIconState.PREVIOUS);
		}
		List<int> seenCheckpoints = CheckpointManager.GetSeenCheckpoints();
		if (_furthest != null)
		{
			GameObject furthest = _furthest;
			int active;
			if (seenCheckpoints.Count > 0)
			{
				List<int> seenCheckpoints2 = CheckpointManager.GetSeenCheckpoints();
				active = ((seenCheckpoints2[seenCheckpoints2.Count - 1] == CheckpointId) ? 1 : 0);
			}
			else
			{
				active = 0;
			}
			furthest.SetActive((byte)active != 0);
		}
	}

	private void AlreadyReachedOrPreviousToCurrent()
	{
		if (_reachedBeforeOrPreviousToCurrent != null)
		{
			_reachedBeforeOrPreviousToCurrent.SetActive(value: true);
		}
	}

	private void NeverReachedToCurrent()
	{
		if (_neverReachedToCurrent != null)
		{
			_neverReachedToCurrent.SetActive(value: true);
		}
	}
}
