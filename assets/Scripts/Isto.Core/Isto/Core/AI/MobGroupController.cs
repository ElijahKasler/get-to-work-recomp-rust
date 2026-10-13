using System.Collections.Generic;
using UnityEngine;

namespace Isto.Core.AI;

public class MobGroupController
{
	private HashSet<GameObject> _activeMobs;

	private HashSet<PushBackLungeAttack> _attackActions;

	private int _maxSimultaniousAttacks = 3;

	public MobGroupController()
	{
		_activeMobs = new HashSet<GameObject>();
		_attackActions = new HashSet<PushBackLungeAttack>();
	}

	public void AddToGroup(GameObject pushBack)
	{
		_activeMobs.Add(pushBack);
	}

	public void RemoveFromGroup(GameObject pushBack)
	{
		_activeMobs.Remove(pushBack);
	}

	public void RegisterAttack(PushBackLungeAttack pushBackLungeAttack)
	{
		_attackActions.Add(pushBackLungeAttack);
	}

	public void UnregisterAttack(PushBackLungeAttack pushBackLungeAttack)
	{
		_attackActions.Remove(pushBackLungeAttack);
	}

	public bool CanAttack(PushBackLungeAttack requestingAttack)
	{
		int num = 0;
		foreach (PushBackLungeAttack attackAction in _attackActions)
		{
			if (attackAction.IsAttacking)
			{
				num++;
			}
		}
		return num <= _maxSimultaniousAttacks;
	}

	public bool IsMobNearFromPosition(Vector3 position, float maxDistance, out Vector3 nearest)
	{
		bool result = false;
		nearest = Vector3.zero;
		float num = maxDistance;
		foreach (GameObject activeMob in _activeMobs)
		{
			float num2 = Vector3.Distance(activeMob.transform.position, position);
			if (num2 != 0f && num2 < num)
			{
				num = num2;
				nearest = activeMob.transform.position;
				result = true;
			}
		}
		return result;
	}
}
