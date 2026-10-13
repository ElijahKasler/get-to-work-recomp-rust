using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Isto.Core.Inputs;

public class CinematicPlayerController : MonoBehaviour
{
	public List<Transform> wayPoints;

	private ScriptedControls _controls;

	private void Awake()
	{
		_controls = Object.FindObjectOfType<ScriptedControls>();
		if (_controls == null)
		{
			Debug.LogError("No Scripted Controls found in scene by " + base.gameObject.name);
		}
	}

	public void MoveToWayPoint(int index)
	{
		if (index >= wayPoints.Count)
		{
			Debug.LogError($"Not enough waypoints in list on {base.gameObject.name}for call to MoveToWayPoint. Index:{index}");
		}
		else
		{
			StartCoroutine(MoveCoroutine(wayPoints[index].position));
		}
	}

	private IEnumerator MoveCoroutine(Vector3 targetGroundPosition)
	{
		_controls.ClearAction();
		_controls.mouseGroundPosition = targetGroundPosition;
		_controls.SetNextAction(UserActions.INTERACT);
		yield return null;
		_controls.ClearAction();
	}

	private IEnumerator TriggerActionCortoutine(UserActions action)
	{
		_controls.ClearAction();
		_controls.SetNextAction(action);
		yield return null;
		_controls.ClearAction();
	}

	[ContextMenu("Move to waypoint 0")]
	public void MoveToWaypointZero()
	{
		StartCoroutine(MoveCoroutine(wayPoints[0].position));
	}
}
