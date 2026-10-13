using System.Collections.Generic;
using System.Linq;
using Isto.Core.Beings;
using ModestTree;
using UnityEngine;
using Zenject;

namespace Isto.GTW.LevelFeatures.GoldenParachute;

public class GoldenParachuteRecovery : LevelEventTrigger
{
	[SerializeField]
	private Color _goldenParachuteGizmoColor = new Color(0.5f, 0f, 0.65f, 0.5f);

	[SerializeField]
	private float _deactivationHeight;

	[SerializeField]
	private string _checkpointName;

	[SerializeField]
	private string _sceneName;

	private bool _isInSpaceSection;

	private CheckpointManager _checkpointManager;

	private BoxCollider _collider;

	private IPlayerController _playerController;

	[Inject]
	public void Inject(CheckpointManager checkpointManager, IPlayerController playerController)
	{
		_checkpointManager = checkpointManager;
		_playerController = playerController;
	}

	private void Update()
	{
		int checkpointId = _checkpointManager.CheckpointData.GetCheckpointId(_checkpointName, _sceneName);
		List<int> seenCheckpoints = _checkpointManager.GetSeenCheckpoints();
		if (!seenCheckpoints.IsEmpty() && !_isInSpaceSection && seenCheckpoints.Last() >= checkpointId)
		{
			_isInSpaceSection = true;
		}
		if (_isInSpaceSection && _playerController.GetPlayerPosition().y < _deactivationHeight)
		{
			_checkpointManager.SetActiveCheckpoint(_checkpointManager.CheckpointData.levelCheckpointDatas[checkpointId]);
			_checkpointManager.Respawn();
			TriggerEvent();
		}
	}

	private new void OnDrawGizmosSelected()
	{
		Vector3 center = new Vector3(base.transform.position.x, _deactivationHeight, base.transform.position.z);
		Vector3 size = new Vector3(10000f, 0.05f, 10000f);
		Color color = Gizmos.color;
		Gizmos.color = _goldenParachuteGizmoColor;
		Gizmos.DrawCube(center, size);
		Gizmos.color = color;
	}
}
